Imports System.IO

Public Class ChangeSpecialModeMusic_Form
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub ChangeSpecialModeMusic_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not File.Exists("\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music02.wav") Then
            File.Copy("\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music01.wav", "\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music02.wav")
        End If
    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        File.Copy(OpenFileDialog1.FileName, "\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music02.wav")
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Computer.Audio.Play("\\pcjhkhsv01\生徒共用\FileHacker\Resources\Music02.wav")
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Computer.Audio.Stop()
    End Sub
End Class