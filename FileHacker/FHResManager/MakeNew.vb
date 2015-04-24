Public Class MakeNew
    Dim mode As String, cancelled As Boolean = False
    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        For Each i In {strict, normal, allow, special, nocopy, spnc, debug}
            If i.Checked Then
                mode = i.Text
            End If
        Next
        Me.Close()
    End Sub
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
        cancelled = True
    End Sub
    Public Function AskMode() As String()
        Me.ShowDialog()
        Return IIf(cancelled, Nothing, {TextBox1.Text, mode})
    End Function
End Class