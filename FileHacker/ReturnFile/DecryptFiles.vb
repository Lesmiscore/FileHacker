Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports ReturnFile.SchoolPCChecker

Public Class DecryptFiles
    Dim cfFolder As String = Path.GetDirectoryName(Assembly.GetEntryAssembly.Location)
    Dim queue As New Queue(Of Object())
    Dim cfd As Integer = 0

    Private Sub DecryptFiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FileSearcher.RunWorkerAsync()
        FileConfiscater.RunWorkerAsync()
        FormUpdater.RunWorkerAsync()
    End Sub
    Private Sub FileSearcher_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles FileSearcher.DoWork
        While True
            Try
                Confiscation.FileSearch(Path.Combine(cfFolder, "Confiscation"), queue, cfFolder, False, False)
                Exit While
            Catch ex As Exception
                Console.WriteLine(ex.GetType.Name)
                Console.WriteLine(ex.Message)
                Console.WriteLine(ex.StackTrace)
            End Try
        End While
    End Sub
    Private Sub FileConfiscater_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles FileConfiscater.DoWork
        While True
            If queue.Count = 0 Then
                Thread.Sleep(10000)
            End If
            While queue.Count <> 0
                Dim f = queue.Dequeue
                Try
                    Dim fp As String = GetFileName(f(0))
                    If Confiscation.DecryptFile(f(0), f(1)) Then
                        cfd += 1
                        File.Delete(fp)
                    Else
                        queue.Enqueue(f)
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.GetType.Name)
                    Console.WriteLine(ex.Message)
                    Console.WriteLine(ex.StackTrace)
                    queue.Enqueue(f)
                End Try
            End While
            If queue.Count = 0 Then
                Exit While
            End If
        End While
        Directory.Delete(Path.Combine(cfFolder, "Confiscation"), True)
    End Sub
    Public Function GetFileName(o As Object) As String
        Try
            Return CType(o, String)
        Catch ex As Exception
            Return CType(o, FileStream).Name
        End Try
    End Function
    Private Sub FormUpdater_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles FormUpdater.DoWork
        While True
            Me.Invoke(Sub()
                          FoundFiles.Text = queue.Count
                          ConfiscatedFiles.Text = cfd
                      End Sub)
        End While
    End Sub
    Private Sub FileConfiscater_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles FileConfiscater.RunWorkerCompleted
         Me.Close()
    End Sub
End Class