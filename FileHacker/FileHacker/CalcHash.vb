Public Class CalcHash
    Default Public ReadOnly Property Main(s As String) As String
        Get
            Dim data As Byte() = System.Text.Encoding.UTF8.GetBytes(s)
            Dim sha256 As New System.Security.Cryptography.SHA256CryptoServiceProvider()
            Dim bs As Byte() = sha256.ComputeHash(data)
            sha256.Clear()
            Dim result As New System.Text.StringBuilder()
            Dim b As Byte
            For Each b In bs
                result.Append(b.ToString("x2"))
            Next b
            Return result.ToString
        End Get
    End Property
    Public Shared Function X() As CalcHash
        Return New CalcHash
    End Function
End Class
