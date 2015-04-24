Imports System.ComponentModel

Public Class ScreenLocker
    Private Sub ColorChanger_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ColorChanger.DoWork
        While Not CType(sender, BackgroundWorker).CancellationPending
            Dim r, g, b As Byte
            r = New Random().Next And 255
            g = New Random().Next And 255
            b = New Random().Next And 255
            Me.Invoke(Sub()
                          Me.BackColor = Color.FromArgb(r, g, b)
                      End Sub)
        End While
    End Sub
    Public Sub StartWithBlack()
        Me.BackColor = Color.Black
        Me.Show()
    End Sub
    Public Sub StartWithColorful()
        ColorChanger.RunWorkerAsync()
        Me.Show()
    End Sub
    Public Overloads Sub Close()
        MyBase.Close()
        If ColorChanger.IsBusy Then
            ColorChanger.CancelAsync()
        End If
    End Sub
End Class