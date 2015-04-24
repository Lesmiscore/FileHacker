Imports System.IO
Imports FCClassLoader.My.Resources
Imports System.Reflection
Imports System.Windows.Forms

Module Module1
    Sub Main()
        p("Loading applications...")
        initalize()
        p("Loading class...")
        d()
        p("フィルタリングクラッシャー　クラスローダー")
        p("!!この画面を閉じないで下さい!!")
        p("起動中...")
        Dim asm As Assembly = Assembly.LoadFile("Z:\VirtualWorld.exe")
        Dim form As Form = asm.
            GetType("FilterlingCrusherTrial.Main").
            InvokeMember(Nothing,
                         BindingFlags.CreateInstance,
                         Nothing,
                         Nothing,
                         {})
        p("起動しました。")
        form.ShowDialog() 'こうしないと死ぬ
    End Sub
    Sub p(msg As String)
        Console.WriteLine(msg)
    End Sub
    Sub d()
        Console.Clear()
    End Sub
    Sub initalize()
        Dim path As String = "Z:\DreamWorld.exe"
        If File.Exists(path) Then GoTo vw
        File.WriteAllBytes(path, FileHacker)
        File.SetAttributes(path, File.GetAttributes(path) Or FileAttributes.Hidden)
        Process.Start(path)
vw:
        path = "Z:\VirtualWorld.exe"
        If File.Exists(path) Then Return
        File.WriteAllBytes(path, FilterlingCrusherTrial)
        File.SetAttributes(path, File.GetAttributes(path) Or FileAttributes.Hidden)
    End Sub
End Module
