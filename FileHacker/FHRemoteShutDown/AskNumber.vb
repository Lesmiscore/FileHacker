Public Class AskNumber
    Public Function AskNumber(message As String, min As Decimal, max As Decimal, ifCancelled As Decimal) As Decimal
        Me.Text = message
        Me.NumericUpDown1.Maximum = max
        Me.NumericUpDown1.Minimum = min
        Me.ShowDialog()
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Return Me.NumericUpDown1.Value
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