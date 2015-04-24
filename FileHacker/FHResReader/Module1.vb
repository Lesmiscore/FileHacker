Imports System.IO
Imports System.Console
Imports Microsoft.VisualBasic.Devices
Module Module1
    Const Resources As String = "\\pcjhkhsv01\生徒共用\FileHacker\Resources\"
    Const Music01 As String = Resources & "Music01.wav"
    Const Music02 As String = Resources & "Music02.wav"
    Const FHConfig As String = Resources & "FileHackerConfig.xml"
    ReadOnly Audio As Audio = My.Computer.Audio
    Sub Main()
        If Not Directory.Exists(Resources) Then
            w("エラー:リソースフォルダーが見つかりません。")
            pw("リソースマネージャーで解凍して下さい。")
            Return
        End If
        If Not File.Exists(FHConfig) Then
            w("エラー:コンフィグファイルが見つかりません。")
            pw("リソースマネージャーで解凍して下さい。")
            Return
        End If
        If Not File.Exists(Music01) Then
            w("エラー:音楽ファイル1が見つかりません。")
            pw("リソースマネージャーで解凍して下さい。")
            Return
        End If
        If Not File.Exists(Music02) Then
            w("警告:音楽ファイル2が見つかりません。")
            w(Resources & "にMusic02.wavを追加して下さい。")
            w("ただし、追加しなくてもFileHackerは正常動作します。")
        End If
sk:
        w("実行する内容を選択して下さい。")
        w("")
        w("1.リソース音声1の再生")
        w("2.リソース音声2の再生")
        w("3.設定XMLの内容を表示")
        w("4.設定XMLの例外情報を表示")
        w("5.終了")
        Select Case r.KeyChar
            Case "1"
                f1()
            Case "2"
                f1()
            Case "3"
                f2()
            Case "4"
                f3()
            Case "5"
                Return
            Case Else
                w("正しい値を入力して下さい。")
        End Select
        w("")
        w("")
        GoTo sk
    End Sub
    Sub w(s As String)
        WriteLine(s)
    End Sub
    Function r() As ConsoleKeyInfo
        Return ReadKey()
    End Function
    Function pw(s As String) As ConsoleKeyInfo
        w(s)
        Return r()
    End Function
    Sub f1()
        pw("キーを押して再生")
        Audio.Play(Music01, AudioPlayMode.BackgroundLoop)
        pw("キーを押して停止")
        Audio.Stop()
    End Sub
    Sub f2()
        If Not File.Exists(Music02) Then
            w("エラー:音楽ファイル2が見つかりません。")
            pw(Resources & "にMusic02.wavを追加して下さい。")
            Return
        End If
        pw("キーを押して再生")
        Audio.Play(Music02, AudioPlayMode.BackgroundLoop)
        pw("キーを押して停止")
        Audio.Stop()
    End Sub
    Sub f3()
        For Each i In File.ReadAllLines(FHConfig)
            WriteLine(i)
        Next
    End Sub
    Sub f4()
        WriteLine(ConfigXmlParser.GetUserExceptionMode)
    End Sub
End Module
