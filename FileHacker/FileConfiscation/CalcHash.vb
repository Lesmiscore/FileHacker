Imports System.Text

Public Class CalcHash
    Public Shared ReadOnly Property Main(s As String) As Byte()
        Get
            Return Main(New UTF8Encoding().GetBytes(s))
        End Get
    End Property
    Public Shared ReadOnly Property Main(data As Byte()) As Byte()
        Get
            Dim sha256 As New System.Security.Cryptography.SHA256CryptoServiceProvider()
            Dim bs As Byte() = sha256.ComputeHash(data)
            sha256.Clear()
            Return bs
        End Get
    End Property
    Public Shared ReadOnly Property Main2(data As Byte()) As Byte()
        Get
            Dim sha1 As New System.Security.Cryptography.SHA1CryptoServiceProvider()
            Dim bs As Byte() = sha1.ComputeHash(data)
            sha1.Clear()
            Return bs
        End Get
    End Property
End Class
