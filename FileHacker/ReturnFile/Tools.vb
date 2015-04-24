Imports System.Text
Imports FileDeploymentTool.SchoolPCChecker
Imports System.Security
Imports System.IO

Public Class Tools
    Public Shared Sub SerializeObject(obj As Object, saveto As String)
        'ArrayListに追加されているオブジェクトを指定してXMLファイルに保存する
        Dim serializer As New System.Xml.Serialization.XmlSerializer( _
            obj.GetType)
        Dim sw As New System.IO.StreamWriter( _
           saveto, False, New System.Text.UTF8Encoding(False))
        serializer.Serialize(sw, obj)
        '閉じる
        sw.Close()
    End Sub
    Public Shared Sub MakeFolder(path As String)
        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If
    End Sub
    Public Shared Sub ForceStop()
        System.Windows.Forms.Application.Exit()
        Process.GetCurrentProcess.Kill()
    End Sub

End Class
