Public Class AskString
    Public Function AskString(message As String, ifCancelled As String, Optional mask As Char = Nothing) As String
        Me.Text = message
        Me.TextBox1.PasswordChar = mask
        Me.TextBox1.Text = ""
        Me.ShowDialog()
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Return Me.TextBox1.Text
        Else
            Return ifCancelled
        End If
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class