Public Class Browser
    Private Sub Browser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub
    Private Sub Browser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.DocumentText = My.Resources.KakuSeikyu_Show.Replace("app-page:pay", "app-page://pay")
    End Sub
    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        WebBrowser1.DocumentText = My.Resources.KakuSeikyu_Pay.Replace("app-page:pay", "app-page://pay")
    End Sub
End Class