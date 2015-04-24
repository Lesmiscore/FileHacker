Public Class AskMode
    Dim mode As String
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
    End Sub
    Public Function AskMode(def As String) As String
        mode = def
        Me.ShowDialog()
        Return mode
    End Function
End Class