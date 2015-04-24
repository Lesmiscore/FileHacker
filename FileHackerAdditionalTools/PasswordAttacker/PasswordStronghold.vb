Imports System.Security.Cryptography
Imports System.Text

Public Class PasswordStronghold
    Public パスワード As String
    Public MD5ハッシュ, SHA256ハッシュ, SHA384ハッシュ, SHA512ハッシュ As Byte()
    Public Sub New(pw As String)
        Me.パスワード = pw
        MD5ハッシュ = GetHash(pw, New MD5Cng)
        SHA256ハッシュ = GetHash(pw, New SHA256Managed)
        SHA384ハッシュ = GetHash(pw, New SHA384Managed)
        SHA512ハッシュ = GetHash(pw, New SHA512Managed)
    End Sub
    Public Sub New()

    End Sub
    Private Function GetHash(s As String, ha As HashAlgorithm) As Byte()
        '文字列をbyte型配列に変換する
        Dim data As Byte() = Encoding.UTF8.GetBytes(s)
        'ハッシュ値を計算する
        Dim bs As Byte() = ha.ComputeHash(data)
        'リソースを解放する
        ha.Clear()
        'ここの部分は次のようにもできる
        Return bs
    End Function
End Class
