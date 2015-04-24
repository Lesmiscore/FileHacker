Imports System.ComponentModel

Public Class ScreenLocker
    Inherits Form
    'WithEvents ColorChanger As BackgroundWorker, StopTimer As New Timer
    Private Sub ColorChanger_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ColorChanger.DoWork
        While Not CType(sender, BackgroundWorker).CancellationPending
            Dim r, g, b As Byte
            r = New Random(DateTime.Now.Day And DateTime.Now.Millisecond).Next And 255
            g = New Random(DateTime.Now.Millisecond And DateTime.Now.Ticks).Next And 255
            b = New Random(DateTime.Now.Minute And DateTime.Now.Month).Next And 255
            Me.Invoke(Sub()
                          Me.BackColor = Color.FromArgb(r, g, b)
                      End Sub)
        End While
    End Sub
    Public Sub StartWithColorful()
        ColorChanger.RunWorkerAsync()
        Me.Show()
    End Sub
    Public Overloads Sub Close()
        MyBase.Close()
    End Sub
    Public Shadows Sub Show()
        MyBase.Show()
        StopTimer.Interval = 1000 * 60
        StopTimer.Start()
    End Sub
    Private Sub StopTimer_Tick(sender As Object, e As EventArgs) Handles StopTimer.Tick
        StopTimer.Stop()
        Me.Close()
    End Sub
End Class