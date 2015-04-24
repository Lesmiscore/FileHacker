Imports System.IO
Imports System.Reflection

Namespace My

    ' 次のイベントは MyApplication に対して利用できます:
    ' 
    ' Startup: アプリケーションが開始されたとき、スタートアップ フォームが作成される前に発生します。
    ' Shutdown: アプリケーション フォームがすべて閉じられた後に発生します。このイベントは、通常の終了以外の方法でアプリケーションが終了されたときには発生しません。
    ' UnhandledException: ハンドルされていない例外がアプリケーションで発生したときに発生するイベントです。
    ' StartupNextInstance: 単一インスタンス アプリケーションが起動され、それが既にアクティブであるときに発生します。
    ' NetworkAvailabilityChanged: ネットワーク接続が接続されたとき、または切断されたときに発生します。
    Partial Friend Class MyApplication
        Dim n As String
        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            If Application.CommandLineArgs.Contains("passwordCheck") Then
                System.Windows.Forms.Application.Exit()
                Process.GetCurrentProcess.Kill()
                'ElseIf Not Application.CommandLineArgs.Contains("copied") Then
                '    File.WriteAllBytes(l(Path.ChangeExtension(Path.GetTempFileName, "exe")), File.ReadAllBytes(Assembly.GetEntryAssembly.Location))
                '    Process.Start(n, "copied")
                '    System.Windows.Forms.Application.Exit()
                '    Process.GetCurrentProcess.Kill()
            End If
        End Sub
        Function l(s As String) As String
            n = s
            Return s
        End Function
    End Class
End Namespace

