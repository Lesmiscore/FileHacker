Imports System.Windows.Forms
Imports System.IO

Public Class Main
    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' この親のすべての子フォームを閉じます
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub
    Private m_ChildFormNumber As Integer
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim f As New Controller
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub SendShutDown_Click(sender As Object, e As EventArgs) Handles SendShutDown.Click
        For Each i As FHRemoteHost In Me.MdiChildren
            i.SendShutDown()
        Next
    End Sub
    Private Sub SendReboot_Click(sender As Object, e As EventArgs) Handles SendReboot.Click
        For Each i As FHRemoteHost In Me.MdiChildren
            i.SendReboot()
        Next
    End Sub
    Private Sub SendSignout_Click(sender As Object, e As EventArgs) Handles SendSignout.Click
        For Each i As FHRemoteHost In Me.MdiChildren
            i.SendSignOut()
        Next
    End Sub
    Private Sub SendCursorLock_Click(sender As Object, e As EventArgs) Handles SendCursorLock.Click
        For Each i As FHRemoteHost In Me.MdiChildren
            i.SendCursorLock()
        Next
    End Sub
    Private Sub SendCursorUnlock_Click(sender As Object, e As EventArgs) Handles SendCursorUnlock.Click
        For Each i As FHRemoteHost In Me.MdiChildren
            i.SendCursorUnlock()
        Next
    End Sub
    Private Sub SendMusicStop_Click(sender As Object, e As EventArgs) Handles SendMusicStop.Click
        For Each i As FHRemoteHost In Me.MdiChildren
            i.SendMusicStop()
        Next
    End Sub
    Private Sub SendMusicPlay_Click(sender As Object, e As EventArgs) Handles SendMusicPlay.Click
        MusicSelector.ShowDialog()
    End Sub
    Private Sub PictureSelector_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PictureSelector.FileOk
        Dim n As New FileStream(PictureSelector.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        Dim c As Bitmap = Bitmap.FromStream(n)
        n.Close()
        n.Dispose()
        For Each i As FHRemoteHost In Me.MdiChildren
            i.SendWallpaperChange(c)
        Next
    End Sub
    Private Sub MusicSelector_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MusicSelector.FileOk
        For Each i As FHRemoteHost In Me.MdiChildren
            i.SendMusicPlay(MusicSelector.FileName)
        Next
    End Sub
    Private Sub SendChengeWallpaper_Click(sender As Object, e As EventArgs) Handles SendChengeWallpaper.Click
        PictureSelector.ShowDialog()
    End Sub
End Class
