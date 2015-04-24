Imports FileDeploymentTool.Tools
Imports System.IO

Namespace My

    ' 次のイベントは MyApplication に対して利用できます:
    ' 
    ' Startup: アプリケーションが開始されたとき、スタートアップ フォームが作成される前に発生します。
    ' Shutdown: アプリケーション フォームがすべて閉じられた後に発生します。このイベントは、通常の終了以外の方法でアプリケーションが終了されたときには発生しません。
    ' UnhandledException: ハンドルされていない例外がアプリケーションで発生したときに発生するイベントです。
    ' StartupNextInstance: 単一インスタンス アプリケーションが起動され、それが既にアクティブであるときに発生します。
    ' NetworkAvailabilityChanged: ネットワーク接続が接続されたとき、または切断されたときに発生します。
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles MyBase.Startup
            If e.CommandLine.Contains("passwordCheck") Then
                ForceStop()
                Return
            End If
            Return
            If Me.MainForm.GetType <> GetType(LoadingForm) Then
                Dim d = SignEntry.GetResourcesSign
                If d Is Nothing Then
                    MessageBox.Show("署名ファイルが見つからないか、壊れています。" & vbCrLf & "署名ツールで修復または署名して下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ForceStop()
                End If
                If Not d.CheckBrokenOrMissingFiles Then
                    MessageBox.Show("リソースフォルダにある分割されたファイル群が壊れています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ForceStop()
                End If
                Dim tfn = Path.ChangeExtension(Path.GetTempFileName, "exe")
                File.WriteAllBytes(tfn, My.Resources.FileHacker)
                Process.Start(tfn)
            End If
        End Sub
    End Class
End Namespace

