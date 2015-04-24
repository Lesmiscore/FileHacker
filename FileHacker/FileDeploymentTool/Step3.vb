Imports System.IO
Imports FileDeploymentTool.My.Resources
Imports System.Reflection
Imports System.Text
Imports System.Threading
Imports FileDeploymentTool.Tools
Imports FileDeploymentTool.SchoolPCChecker
Public Class Step3
    Dim selected As Boolean = False
    Dim tfn, pw As String
    Public Shadows Sub Show(pw As String)
        Me.pw = PasswordCheck(pw)
        MyBase.Show()
    End Sub
    Private Sub Step3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tfn = Path.ChangeExtension(Path.GetTempFileName, "exe")
        File.WriteAllBytes(tfn, My.Resources.FileEncrypterAndDecrypter)
    End Sub
    Private Function Fix(i As Integer) As String
        Return CType(i, String).PadLeft(3).Replace(" ", "0")
    End Function
    Private Sub FileSaver_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles FileSaver.DoWork
        Try
proc:
            Dim ef = Path.GetTempFileName
            Dim temp As New FileStream(ef, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None) 'MemoryStream(80000)
            For Each i In SignEntry.GetResourcesSign.ToArray
                Dim a As Byte() = File.ReadAllBytes(WL(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly.Location), "Resources", i.FilePath)))
                temp.Write(a, 0, a.Length)
            Next
            temp.Close()
            temp.Dispose()
            pw = PasswordCheck(pw)
            Dim psi As New ProcessStartInfo
            psi.FileName = tfn
            psi.Arguments = """" & ef & """ """ & SaveFileDialog1.FileName & """"
            psi.UseShellExecute = False
            psi.RedirectStandardError = True
            psi.RedirectStandardInput = True
            psi.RedirectStandardOutput = True
            psi.CreateNoWindow = True
            pw = PasswordCheck(pw)
            Dim p As New Process()
            p.StartInfo = psi
            pw = PasswordCheck(pw)
            p.Start()
            Thread.Sleep(1000 * 3)
            p.StandardInput.WriteLine("このウィンドウを閉じないで下さい。")
            p.WaitForExit()
            pw = PasswordCheck(pw)
            If Not File.Exists(SaveFileDialog1.FileName) Or p.ExitCode <> 0 Then
                If MessageBox.Show("書き出しに失敗しました。" & vbCrLf & "もう一回行いますか？", "エラー", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                    GoTo proc
                End If
            End If
        Catch ex As Exception
            If MessageBox.Show("書き出しに失敗しました。" & vbCrLf & "もう一回行いますか？" & vbCrLf & ex.GetType.Name & vbCrLf & ex.StackTrace & vbCrLf & ex.Message, "エラー", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                GoTo proc
            End If
        End Try
    End Sub
    Public Function WL(s As String) As String
        Console.WriteLine(s)
        Return s
    End Function
    Private Sub SelectFile_Click(sender As Object, e As EventArgs) Handles SelectFile.Click
        SaveFileDialog1.ShowDialog()
    End Sub
    Private Sub StartGet_Click(sender As Object, e As EventArgs) Handles StartGet.Click
        If Not selected Then
            MessageBox.Show("保存先が指定されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        FileSaver.RunWorkerAsync()
        StartGet.Enabled = False
        SelectFile.Enabled = False
    End Sub
    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        selected = True
        FileName.Text = SaveFileDialog1.FileName
    End Sub
    Private Sub FileSaver_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles FileSaver.RunWorkerCompleted
        Me.Close()
    End Sub
End Class