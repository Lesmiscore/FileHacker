Option Compare Binary

Imports System.Threading

Public Class LockScreen
    Private Sub LockScreen_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Me.Select()
        Me.Activate()
        Me.BringToFront()
    End Sub
    Dim allowclose As Boolean = False
    Private Sub LockScreen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = Not allowclose
    End Sub
    Dim s As String
    Dim t As New Thread(Sub()
                            While True
                                For Each i In (From j In Process.GetProcesses Where j.ProcessName.Contains("explorer"))
                                    Try
                                        i.Kill()
                                    Catch ex As Exception
                                        If TypeOf ex Is ThreadAbortException Then
                                            Return
                                        End If
                                    End Try
                                Next
                            End While
                        End Sub)
    Public Shadows Sub Show(s As String)
        Me.s = s
        MyBase.Show()
        LockScreen_Deactivate(Nothing, Nothing)
        t.IsBackground = True
        t.Start()
    End Sub
    Private Sub LockScreen_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If AskString.AskString("パスワードを入力して下さい。", "再現不可文字列", "玉") = s Then
            'Me.Dispose(True)
            allowclose = True
            t.Abort()
            Dim p = Process.Start(New ProcessStartInfo With {.FileName = "cmd", .RedirectStandardInput = True, .RedirectStandardOutput = True, .UseShellExecute = False, .CreateNoWindow = True})
            p.StandardInput.WriteLine("explorer")
            p.StandardInput.WriteLine("exit")
            Me.Close()
            Process.GetCurrentProcess.Kill()
        End If
    End Sub
    Private Sub LockScreen_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.WindowState = FormWindowState.Maximized
        LockScreen_Deactivate(Nothing, Nothing)
    End Sub
End Class