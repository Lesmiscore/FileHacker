Imports System.IO

Public Class FHTools
    Public Shared Function GetFHPath() As String
        Return "\\pcjhkhsv01\生徒共用\FileHacker\"
    End Function
    Public Shared Function GetFHPath(ParamArray s As String()) As String
        Dim tmp As String = GetFHPath()
        For Each i In s
            tmp = Path.Combine(tmp, i)
        Next
        Console.WriteLine("Reqested:" & tmp)
        Return tmp
    End Function
End Class
