'標準出力リダイレクトプログラム
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports FHCodePack

Public Class FileHackerAdditionalTools
    ReadOnly UTF8BOM As Byte() = {&HEF, &HBB, &HBF} 'UTF-8のBOM (Wikipediaの"バイトオーダーマーク"より)
    Public Function GetWorkers(sender As Object) As BackgroundWorker()
        Dim dbg As New BackgroundWorker
        AddHandler dbg.DoWork,
            Sub(sender_ As Object, e As DoWorkEventArgs)
                Dim dir = FHTools.GetFHPath("DebugOutputs\")
                If Not Directory.Exists(dir) Then
                    Directory.CreateDirectory(dir)
                End If
                Dim fs As FileStream
                Dim filepath = dir & SchoolPCChecker.GetPCName & "_RedirectInput.txt"
                If File.Exists(filepath) Then
                    fs = New FileStream(filepath, FileMode.Truncate, FileAccess.Write, FileShare.Read)
                Else
                    fs = New FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read)
                End If
                fs.Write(UTF8BOM, 0, UTF8BOM.Length) 'UTF-8のBOMを書き込む  (メモ帳はこれがないと読まない)
                Dim sr As New StreamWriter(fs, New UTF8Encoding(False, False))
                While True
                    sr.Write(Console.In.ReadToEnd)
                End While
            End Sub
        Return {dbg}
    End Function
End Class
