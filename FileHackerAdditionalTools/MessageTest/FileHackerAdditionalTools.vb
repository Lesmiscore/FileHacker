Imports System.ComponentModel
Imports System.Windows.Forms

Public Class FileHackerAdditionalTools
    Public Function GetWorkers(sender As Object) As BackgroundWorker()
        Dim dbg As New BackgroundWorker
        AddHandler dbg.DoWork,
            Sub(sender_ As Object, e As DoWorkEventArgs)
                MessageBox.Show("TestMessage")
            End Sub
        Return {dbg}
    End Function
End Class
