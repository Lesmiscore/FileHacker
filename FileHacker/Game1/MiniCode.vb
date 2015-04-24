Imports System.Console
Module Main
    Const あいうえお順平仮名 As String = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわをんぁぃぅぇぉゃゅょがぎぐげござじずぜぞだぢづでどばびぶべぼっ"
    Const あいうえお順片仮名 As String = "アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲンァィゥェォャュョガギグゲゴザジズゼゾダヂヅデドバビブベボッ"
    Sub Main()
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
