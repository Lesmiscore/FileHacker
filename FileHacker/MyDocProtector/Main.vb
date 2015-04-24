Imports System.IO
Imports System.ComponentModel

Public Class Main
    Dim folname As String
    Dim fsc As FileStreamCollection
    Dim failedqueue, deletequeue As Queue(Of String)
    Dim endcheck As Boolean = False
    Dim count As Integer = 0
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetPath(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
        fsc = New FileStreamCollection
        failedqueue = New Queue(Of String)
        deletequeue = New Queue(Of String)
    End Sub
    Private Sub SetPath(s As String)
        FolderPath.Text = s
        folname = s
        FolderSelector.SelectedPath = s
    End Sub
    Private Sub FolderChange_Click(sender As Object, e As EventArgs) Handles FolderChange.Click
        FolderSelector.ShowDialog()
        SetPath(FolderSelector.SelectedPath)
    End Sub
    Private Sub LockButton_Click(sender As Object, e As EventArgs) Handles LockButton.Click
        If PasswordMain.Text.Length = 0 Or 0 = PasswordVerify.Text.Length Then
            MessageBox.Show("パスワードか確認が入力されていません。")
            Return
        End If
        If PasswordMain.Text <> PasswordVerify.Text Then
            MessageBox.Show("パスワードと確認が違います。")
            Return
        End If
        If TaskManagerStopping.Checked Then tmstop.RunWorkerAsync()
        TaskNotifyIcon.Visible = True
        TaskNotifyIcon.Text = "ファイルをロックしています..."
        Me.Enabled = False
        Me.WindowState = FormWindowState.Minimized
        Me.ShowInTaskbar = False
        Me.Visible = False
        FileLocker.RunWorkerAsync()
        FailedFileLocker.RunWorkerAsync()
        CreatedDataDeleter.RunWorkerAsync()
        StartDetect()
    End Sub
    Private Sub FileLocker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles FileLocker.DoWork
        endcheck = False
        LockDirectory(folname)
        endcheck = True
    End Sub
    Private Sub FileSystemChangesWatcher_Created(sender As Object, e As IO.FileSystemEventArgs) Handles FileSystemChangesWatcher.Created
        If e.Name.EndsWith(".nofiles") And File.Exists(e.FullPath) Then
            Return
        End If
        count += 1
        Try
            If File.Exists(e.FullPath) Then
                ShowBallonTip("ファイル " & Path.GetFileName(e.Name) & " が作成されたため、削除します。")
                Console.WriteLine("Created:File:" & e.Name)
                File.Delete(e.FullPath)
            ElseIf Directory.Exists(e.FullPath) Then
                ShowBallonTip("フォルダ " & Path.GetFileName(e.Name) & " が作成されたため、削除します。")
                Console.WriteLine("Created:Directory:" & e.Name)
                Directory.Delete(e.FullPath)
            End If
        Catch ex As Exception
            deletequeue.Enqueue(e.FullPath)
        End Try
        If LockIf10TimeChange.Checked And count Mod 10 = 0 Then
            ScreenLocker.StartWithColorful()
        End If
    End Sub
    Public Sub ShowBallonTip(text As String)
        TaskNotifyIcon.ShowBalloonTip(10, "マイドキュメント保護プログラム", text, ToolTipIcon.Info)
    End Sub
    Public Sub LockDirectory(ByVal sourceDirName As String)
        'コピー元のディレクトリにあるファイルをコピー
        Dim fs As String() = System.IO.Directory.GetFiles(sourceDirName)
        Dim f As String
        If fs.Length = 0 Then GoTo dir
        For Each f In fs
            If Path.GetFileName(f) = ".nofiles" Then
                File.Delete(f)
                GoTo passfile
            End If
            fsc.Add(LockFile(f))
passfile:
        Next
dir:
        'コピー元のディレクトリにあるディレクトリをコピー
        Dim dirs As String() = System.IO.Directory.GetDirectories(sourceDirName)
        '空ディレクトリ対策
        If fs.Concat(dirs).Count = 0 Then
            Console.WriteLine("LockDirectory:BlankDirectory:" & sourceDirName)
            File.WriteAllBytes(sourceDirName & "\.nofiles", {})
            File.SetAttributes(sourceDirName & "\.nofiles", File.GetAttributes(sourceDirName & "\.nofiles") Or FileAttributes.Hidden)
            fsc.Add(LockFile(sourceDirName & "\.nofiles"))
            Return
        End If
        Dim dir As String
        For Each dir In dirs
            LockDirectory(dir)
        Next
    End Sub
    Public Function LockFile(f As String) As FileStream
        Console.WriteLine("LockFile:Path:" & f)
        'StatusText = "ファイルをロックしています: " & f
        Try
            Return New FileStream(f, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
        Catch ex As Exception
            failedqueue.Enqueue(f)
            Console.WriteLine("-=File Opening Error Start=-")
            Console.WriteLine("==File Name:" & f)
            Console.WriteLine("==Exception Class:" & ex.GetType.Name)
            Console.WriteLine("==Exception Message==")
            Console.WriteLine(ex.Message)
            Console.WriteLine("==Stack Trace==")
            Console.WriteLine(ex.StackTrace)
            Console.WriteLine("==Source==")
            Console.WriteLine(ex.Source)
            Console.WriteLine("-=File Opening Error End=-")
            Return Nothing
        End Try
    End Function
    Private Sub FileLocker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles FileLocker.RunWorkerCompleted
        TaskNotifyIcon.Text = "フォルダを保護中です"
        If Not endcheck Then
            ShowBallonTip("ファイルのロックは途中で終了しました。")
        End If
        Console.WriteLine("EndCheck:" & endcheck)
        StartDetect()
    End Sub
    Private Sub StartDetect()
        FileSystemChangesWatcher.Path = folname
        FileSystemChangesWatcher.SynchronizingObject = Me
        FileSystemChangesWatcher.IncludeSubdirectories = True
        FileSystemChangesWatcher.EnableRaisingEvents = True
    End Sub
    Private Sub TaskNotifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TaskNotifyIcon.MouseDoubleClick
        If PasswordMain.Text <> AskString.AskString("パスワードを入力して下さい。", "再現不可能文字列", "玉"c) Then
            MessageBox.Show("パスワードが違います。")
            Return
        End If
        FileUnLocker.RunWorkerAsync()
        ShowBallonTip("パスワードを正解したため、アンロックを開始します。")
    End Sub
    Private Sub FileUnLocker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles FileUnLocker.DoWork
        endcheck = False
        For Each i As FileStream In fsc.ToArray
            Console.WriteLine("FileUnLocker:Dispose:" & i.Name)
            i.Close()
            i.Dispose()
        Next
        endcheck = True
    End Sub
    Private Sub FileUnLocker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles FileUnLocker.RunWorkerCompleted
        Console.WriteLine("EndCheck:" & endcheck)
        Me.Close()
    End Sub
    Public Property StatusText As String
        Get
            Return Me.Invoke(Function()
                                 Return TaskNotifyIcon.Text
                             End Function)
        End Get
        Set(value As String)
            Me.Invoke(Sub()
                          TaskNotifyIcon.Text = value
                      End Sub)
        End Set
    End Property
    Private Sub FailedFileLocker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles FailedFileLocker.DoWork
        While True
            While failedqueue.Count <> 0
                fsc.Add(LockFile(failedqueue.Dequeue))
            End While
        End While
    End Sub
    Private Sub CreatedDataDeleter_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles CreatedDataDeleter.DoWork
        While True
            While deletequeue.Count <> 0
                Dim f As String = deletequeue.Dequeue
                Try
                    If File.Exists(f) Then
                        File.Delete(f)
                    ElseIf Directory.Exists(f) Then
                        Directory.Delete(f)
                    End If
                Catch ex As Exception
                    deletequeue.Enqueue(f)
                End Try
            End While
        End While
    End Sub
    Private Sub TaskManagerStopper(sender As Object, e As DoWorkEventArgs) Handles tmstop.DoWork
        While True
            Try
                For Each i In Process.GetProcessesByName("taskmgr")
                    i.Kill()
                Next
            Catch ex As Exception : End Try
        End While
    End Sub
End Class
