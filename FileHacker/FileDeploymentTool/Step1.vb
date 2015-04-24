Imports FileDeploymentTool.PowerManager
Imports System.IO

Public Class Step1
    Dim vf As String = Tools.GetRandomText
    Private Sub Step1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VerifyText.Text = vf
        'LoadingForm.Close()
    End Sub
    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        If MessageBox.Show("本当によろしいですか？" & vbCrLf & "間違えると、本当にシャットダウンします。", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.No Then
            Return
        End If
        If vf <> TextBox1.Text Then
            AdjustToken()
            ExitWindowsEx(ExitWindows.EWX_POWEROFF Or ExitWindows.EWX_FORCE, 0)
            Application.Exit()
            Return
        End If
        Step2.Show()
        Me.Close()
    End Sub
    Private Sub ReadDifficult_Click(sender As Object, e As EventArgs) Handles ReadDifficult.Click
        vf = Tools.GetRandomText
        VerifyText.Text = vf
    End Sub

    Private Sub Quiz_Click(sender As Object, e As EventArgs) Handles Quiz.Click
        Step1_Quiz.Show()
        Me.Close()
    End Sub
End Class
