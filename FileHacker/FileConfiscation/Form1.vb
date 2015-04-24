Public Class Form1

    Private Sub StartWipe_Click(sender As Object, e As EventArgs) Handles StartWipe.Click
        ConfiscationWindow.ShowDialog(FolderName.Text)
        Me.Close()
    End Sub
End Class
