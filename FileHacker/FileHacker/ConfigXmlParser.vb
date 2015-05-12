Imports System.IO
Imports System.Text

Public Class ConfigXmlParser
    Shared doc As XDocument
    Private Shared Function GetXMLText() As String
        Return File.ReadAllText("\\pcjhkhsv01\生徒共用\FileHacker\Resources\FileHackerConfig.xml", New UTF8Encoding)
    End Function
    Private Shared Function GetXDocument() As XDocument
        If doc Is Nothing Then
            doc = XDocument.Parse(GetXMLText)
        End If
        Return doc
    End Function
    Public Shared Function GetUserExceptionMode() As ExceptionsXmlModes
        'XMLデータの取得
        Dim doc = GetXDocument()
        'userタグを解析
        Dim result As String
        Try
            result = (From n In doc.<FileHacker>.<exceptions>.<user> Where n.@name = SchoolPCChecker.GetUN).First.@mode '1行で解析プログラム完成。
            '         #               userタグの抽出               #       # ユーザー名からuserタグを取得 ## ﾓｰド取得 #
        Catch ex As Exception
            result = "allow"
        End Try
        '結果の判定
        Return GetValue2(result)
    End Function
    Public Shared Sub debug()
        Dim sb As New StringBuilder
        For Each i In [Enum].GetNames(GetType(ExceptionsXmlModes))
            sb.AppendLine(i)
        Next
        MessageBox.Show(sb.ToString)
    End Sub
    Public Shared Function GetValue2(result As String) As ExceptionsXmlModes
        Dim list As String() = [Enum].GetNames(GetType(ExceptionsXmlModes))
        If Not list.Contains(result.ToLower) Then
            Return ExceptionsXmlModes.allow
        Else
            Return [Enum].Parse(GetType(ExceptionsXmlModes), result.ToLower)
        End If
    End Function
    Public Shared Function GetToPath() As String
        Return GetXDocument().<FileHacker>.<config>.<ToPath>(0).Value
    End Function
    Public Shared Function GetFatManUserName() As String
        Return GetXDocument().<FileHacker>.<config>.<FatManUserName>(0).Value
    End Function
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
        special3 = &H40 Or special2
        spnc3 = special3 Or nocopy
    End Enum
End Class
