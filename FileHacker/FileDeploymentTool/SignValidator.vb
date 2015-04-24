Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Security.Cryptography

Public Class SignEntry
    Dim filePath_ As String
    Dim md5hash_, sha256hash_, sha384hash_, sha512hash_ As Byte()
    Public Shared Function GetResourcesSign() As ResourcesSign
        Try
            Dim xd As XDocument = XDocument.Parse(File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly.Location), "Resources", "Sign.xml")))
            Dim main = xd.<Sign>
            Dim entriesCount As Integer = Integer.Parse(main.@count)
            Dim entries = main.<Entry>
            Dim rs As New ResourcesSign(entriesCount - 1)
            For i = 0 To entries.Count - 1
                rs(i) = New SignEntry
                rs(i).filePath_ = entries(i).<FilePath>(0).Value
                rs(i).md5hash_ = Convert.FromBase64String(entries(i).<MD5Hash>(0).Value)
                rs(i).sha256hash_ = Convert.FromBase64String(entries(i).<SHA256Hash>(0).Value)
                rs(i).sha384hash_ = Convert.FromBase64String(entries(i).<SHA384Hash>(0).Value)
                rs(i).sha512hash_ = Convert.FromBase64String(entries(i).<SHA512Hash>(0).Value)
            Next
            Return rs
        Catch
            Return Nothing
        End Try
    End Function
    Public Function CheckBrokenOrMissingFile() As Boolean
        Try
            If Not File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly.Location), "Resources", filePath_)) Then
                Return False
            End If
            Dim data = File.ReadAllBytes(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly.Location), "Resources", filePath_))
            If B(md5hash_) <> B(GetHash(data, New MD5Cng)) Then
                Return False
            End If
            If B(sha256hash_) <> B(GetHash(data, New SHA256Managed)) Then
                Return False
            End If
            If B(sha384hash_) <> B(GetHash(data, New SHA384Managed)) Then
                Return False
            End If
            If B(sha512hash_) <> B(GetHash(data, New SHA512Managed)) Then
                Return False
            End If
        Catch
            Return False
        End Try
        Return True
    End Function
    Private Function B(by As Byte()) As String
        Return Convert.ToBase64String(by)
    End Function
    Private Function GetHash(data As Byte(), ha As HashAlgorithm) As Byte()
        'ハッシュ値を計算する
        Dim bs As Byte() = ha.ComputeHash(Data)
        'リソースを解放する
        ha.Clear()
        'ここの部分は次のようにもできる
        Return bs
    End Function
    Public ReadOnly Property FilePath As String
        Get
            Return filePath_
        End Get
    End Property
    Public ReadOnly Property MD5Hash As Byte()
        Get
            Return md5hash_
        End Get
    End Property
    Public ReadOnly Property SHA256Hash As Byte()
        Get
            Return sha256hash_
        End Get
    End Property
    Public ReadOnly Property SHA384Hash As Byte()
        Get
            Return sha384hash_
        End Get
    End Property
    Public ReadOnly Property SHA512Hash As Byte()
        Get
            Return sha512hash_
        End Get
    End Property
End Class
Public Class ResourcesSign
    Implements IEnumerable(Of SignEntry)
    Dim ien As SignEntry()
    Public Sub New(capacity As Integer)
        ien = New SignEntry(capacity) {}
    End Sub

    Public Function GetEnumerator() As IEnumerator(Of SignEntry) Implements IEnumerable(Of SignEntry).GetEnumerator
        Return CType(ien.ToArray, Array)
    End Function

    Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return CType(ien.ToArray, Array)
    End Function

    Default Public Property Item(index As Integer) As SignEntry
        Get
            Return ien(index)
        End Get
        Set(value As SignEntry)
            ien(index) = value
        End Set
    End Property

    Public Function CheckBrokenOrMissingFiles() As Boolean
        For Each i In ien
            If Not i.CheckBrokenOrMissingFile Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function ToArray() As IEnumerable(Of SignEntry)
        Return ien
    End Function
End Class
