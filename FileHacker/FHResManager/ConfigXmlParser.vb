Imports System.IO
Imports System.Text

Public Class ConfigXmlParser
    Shared doc As XDocument
    Private Shared Function GetXMLText() As String
        Return File.ReadAllText("\\pcjhkhsv01\生徒共用\FileHacker\Resources\FileHackerConfig.xml", New UTF8Encoding)
    End Function
    Public Shared Function GetXDocument() As XDocument
        If doc Is Nothing Then
            doc = XDocument.Parse(GetXMLText)
        End If
        Return doc
    End Function
    Public Shared Sub UpdateChanges()
        GetXDocument.Save("\\pcjhkhsv01\生徒共用\FileHacker\Resources\FileHackerConfig.xml")
    End Sub
    Public Shared Sub GetUserExceptionMode(lv As ListView)
        'XMLデータの取得
        lv.Items.Clear()
        Dim doc = GetXDocument()
        For Each i In doc.<FileHacker>.<exceptions>.<user>
            lv.Items.Add(New ListViewItem({i.@name, i.@mode}))
        Next
    End Sub
    Public Shared Function GetConfigVariable(name As String) As String
        Return (From n In doc.<FileHacker>.<ConfigVariable>.<data> Where n.@name = name)(0).@data
    End Function
    Public Enum ExceptionsXmlModes
        allow = &H1
        normal = &H4
        strict = &H2 Or normal
        special = &H8 Or allow
        nocopy = &H10
        [error] = normal 'Or strict
        debug = normal 'Or strict
        spnc = nocopy Or special
        special2 = &H20 Or special
        spnc2 = special2 Or nocopy
    End Enum
End Class
