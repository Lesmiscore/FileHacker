Imports System.Runtime.InteropServices

Public Class Main
    Private Sub ApplicationLock_CheckedChanged(sender As Object, e As EventArgs) Handles ApplicationLock.CheckedChanged
        GroupBox1.Enabled = ApplicationLock.Checked
    End Sub
    Private Sub DoWithFileHacker_CheckedChanged(sender As Object, e As EventArgs) Handles DoWithFileHacker.CheckedChanged
        If Process.GetProcessesByName("VirtualWorld").Concat(Process.GetProcessesByName("FileHacker")).Count <> 0 Then
            Return
        End If
        DoWithFileHacker.Checked = False
    End Sub
    Private Sub LockFromFileHacker_CheckedChanged(sender As Object, e As EventArgs) Handles LockFromFileHacker.CheckedChanged
        If ApplicationLock.Checked Then
            Return
        End If
        LockFromFileHacker.Checked = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not (ApplicationLock.Checked Or SystemLock.Checked) Then
            MessageBox.Show("ロック方法が指定されていません。")
            Return
        End If
        If ApplicationLock.Checked And (MaskedTextBox1.Text.Length = 0 Or 0 = MaskedTextBox2.Text.Length) Then
            MessageBox.Show("パスワードか確認が入力されていません。")
            Return
        End If
        If ApplicationLock.Checked And MaskedTextBox1.Text <> MaskedTextBox2.Text Then
            MessageBox.Show("パスワードと確認が違います。")
            Return
        End If
        If SystemLock.Checked And DoWithFileHacker.Checked Then
            UDPConnetor.Main("SYSTEM_LOCK")
        End If
        If SystemLock.Checked And Not DoWithFileHacker.Checked Then
            LockWorkStation()
        End If
        If ApplicationLock.Checked And LockFromFileHacker.Checked Then
            LockScreen.Text = "このシステムはFileHackerによって乗っ取られました"
        Else
            LockScreen.Text = "このシステムはロックされました"
        End If
        If ApplicationLock.Checked Then
            LockScreen.Show(MaskedTextBox1.Text)
        End If
        Me.Close()
    End Sub
    'システムをロックできるやつ
    '<DllImport("user32.dll")>
    'Public Shared Sub LockWorkStation()
    'End Sub
    Declare Sub LockWorkStation Lib "user32" ()
End Class
