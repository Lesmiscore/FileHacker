Imports System.Text
Imports FileDeploymentTool.PowerManager

Public Class Step1_Quiz
    Dim a As String
    Private Sub Step1_Quiz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MoreQuiz_Click(sender, e)
    End Sub

    Private Sub MoreQuiz_Click(sender As Object, e As EventArgs) Handles MoreQuiz.Click
        Dim n = Tools.GetRandomQuiz
        QuizData.Text = New StringBuilder().AppendLine(n(0)).AppendLine(n(1)).ToString
        a = n(2)
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        If MessageBox.Show("本当によろしいですか？" & vbCrLf & "間違えると、本当にシャットダウンします。", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.No Then
            Return
        End If
        If a <> TextBox1.Text Then
            AdjustToken()
            ExitWindowsEx(ExitWindows.EWX_POWEROFF Or ExitWindows.EWX_FORCE, 0)
            Application.Exit()
            Return
        End If
        Step2.Show()
        Me.Close()
    End Sub

    Private Sub TextReading_Click(sender As Object, e As EventArgs) Handles TextReading.Click
        Step1.Show()
        Me.Close()
    End Sub
End Class