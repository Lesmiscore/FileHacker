Imports System.IO
Imports System.Text

Public Class Main
    Private Sub UnPakRes_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles UnPakRes.DoWork
        e.Result = False
        StatusText = "リソースフォルダーをチェックしています..."
        If Not Directory.Exists("\\pcjhkhsv01\生徒共用\FileHacker\Resources\") Then
            Directory.CreateDirectory("\\pcjhkhsv01\生徒共用\FileHacker\Resources\")
        End If
        StatusText = "設定ファイルを展開しています..."
        If Not File.Exists("\\pcjhkhsv01\生徒共用\FileHacker\Resources\FileHackerConfig.xml") Then
            File.WriteAllBytes("\\pcjhkhsv01\生徒共用\FileHacker\Resources\FileHackerConfig.xml", My.Resources.FileHackerConfig)
        End If
        StatusText = "音声ファイルを展開しています..."
        If Not File.Exists("\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music01.wav") Then
            File.WriteAllBytes("\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music01.wav", ToArrayFromStream(My.Resources.M01))
        End If
        StatusText = "リソースのチェック及び展開が完了しました。"
        MessageBox.Show("このプログラムは正しく動作しないため、[OK]を押したら閉じることを推奨します。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error)
        e.Result = True
    End Sub
    Private Function ToArrayFromStream(stream As Stream) As Byte()
        Dim ms As New MemoryStream
        stream.CopyTo(ms)
        Return ms.ToArray
    End Function
    Public Property StatusText As String
        Get
            Return Me.Invoke(Function()
                                 Return Status.Text
                             End Function)
        End Get
        Set(value As String)
            Me.Invoke(Sub()
                          Status.Text = value
                      End Sub)
        End Set
    End Property
    Private Sub EditExceptionMode_Click(sender As Object, e As EventArgs) Handles EditExceptionMode.Click
        EditExceptionMode_Form.ShowDialog()
    End Sub
    Private Sub ChangeSpecialModeMusic_Click(sender As Object, e As EventArgs) Handles ChangeSpecialModeMusic.Click
        ChangeSpecialModeMusic_Form.ShowDialog()
    End Sub
    Private Sub InitAll_Click(sender As Object, e As EventArgs) Handles InitAll.Click
        EditExceptionMode.Enabled = False
        ChangeSpecialModeMusic.Enabled = False
        InitAll.Enabled = False
        Directory.Delete("\\pcjhkhsv01\生徒共用\FileHacker\Resources\", True)
        UnPakRes.RunWorkerAsync()
    End Sub
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UnPakRes.RunWorkerAsync()
    End Sub
    Private Sub UnPakRes_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles UnPakRes.RunWorkerCompleted
        If e.Result Then
            EditExceptionMode.Enabled = True
            ChangeSpecialModeMusic.Enabled = True
            InitAll.Enabled = True
        Else
            Application.Exit()
        End If
    End Sub
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        StatusText = "設定のXMLファイルをアップロードしています..."
        ConfigXmlParser.UpdateChanges()
        Try
            StatusText = "音声ファイルをアップロードしています..."
            If File.Exists("\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music02.wav") Then
                File.Move("\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music02.wav", "\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music01.wav")
                'File.Delete("\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music02.wav")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
