Public Class EditExceptionMode_Form
    Private Sub EditExceptionMode_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigXmlParser.GetUserExceptionMode(ListView1)
    End Sub
    Dim last As ListViewItem
    Private Sub ListView1_ItemCheck(sender As Object, e As ItemCheckedEventArgs) Handles ListView1.ItemChecked
        last = e.Item '.SubItems(1).Text = AskMode.AskMode(e.Item.SubItems(1).Text)
    End Sub
    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        ListView1.Items.Remove(last)
        last = Nothing
    End Sub
    Private Sub MakeNew_Click(sender As Object, e As EventArgs) Handles MakeNew.Click
        Dim s As String() = New MakeNew().AskMode()
        If s Is Nothing Then
            Return
        End If
        ListView1.Items.Add(New ListViewItem(s))
    End Sub
    Private Sub Change_Click(sender As Object, e As EventArgs) Handles Change.Click
        last.SubItems(1).Text = AskMode.AskMode(last.SubItems(1).Text)
    End Sub
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
    Private Sub Apply_Click(sender As Object, e As EventArgs) Handles Apply.Click
        Dim exp = ConfigXmlParser.GetXDocument.<FileHacker>.<exceptions>(0)
        exp.Value = ""
        For a = 0 To ListView1.Items.Count - 1
            Dim i = ListView1.Items(a)
            exp.Value += "<user name=""" & i.Text & """ mode=""" & i.SubItems(1).Text & """ />" & vbCrLf
        Next
        Me.Close()
    End Sub
End Class