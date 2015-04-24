Imports System.Net
Imports System.ComponentModel

Public Class Form1
    Public Const MaxParallel As Integer = 20
    Dim locks As Object()
    Dim locksOffset As Integer = 0
    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Dim l As New List(Of Object)
        For i As UInt32 = 0 To MaxParallel
            l.Add(New Object)
        Next
        locks = l.ToArray
    End Sub
    Public Function GetLockObject() As Object
        Try
            Return locks(locksOffset)
        Finally
            locksOffset = (locksOffset + 1) Mod locks.Length
        End Try
    End Function
    Public Property Status As String
        Get
            Return Invoke(Function()
                              Return IPCheckStatus.Text
                          End Function)
        End Get
        Set(value As String)
            Invoke(Sub()
                       IPCheckStatus.Text = value
                   End Sub)
        End Set
    End Property
    Public ReadOnly Property Port As Integer
        Get
            Return Invoke(Function()
                              Return PortNum.Value
                          End Function)
        End Get
    End Property
    Public Function GenerateIPAddress(o1 As Byte, o2 As Byte, o3 As Byte, o4 As Byte, port As Int32) As String
        Return o1 & "." & o2 & "." & o3 & "." & o4 & ":" & port
    End Function
    Public Sub AddList(o1 As Byte, o2 As Byte, o3 As Byte, o4 As Byte, port As Int32)
        If port <= 0 Or port >= 65536 Then
            Return
        End If
        If o1 < 0 Then
            Return
        End If
        If o2 < 0 Then
            Return
        End If
        If o3 < 0 Then
            Return
        End If
        If o4 < 0 Then
            Return
        End If
        Dim host As String = GenerateIPAddress(o1, o2, o3, o4, port)
        Invoke(Sub()
                   IPList.Items.Add(host)
               End Sub)
    End Sub
    Public Function CheckIPAvaliable(o1 As Byte, o2 As Byte, o3 As Byte, o4 As Byte, port As Int32) As Boolean
        If port <= 0 Or port >= 65536 Then
            Return False
        End If
        SyncLock GetLockObject()
            Dim p As New Process
            p.StartInfo = New ProcessStartInfo() With {.Arguments = GenerateIPAddress(o1, o2, o3, o4, port),
                                                       .FileName = "ping",
                                                       .UseShellExecute = False,
                                                       .CreateNoWindow = True}
            p.Start()
            p.WaitForExit()
            Return p.ExitCode = 0
        End SyncLock

        Dim host As String = "http://" & GenerateIPAddress(o1, o2, o3, o4, port) & "/"
        Try
            Dim wc As New WebClient
            'wc.DownloadData(host)
            wc.DownloadString(host)
            Return True
        Catch
            Return False
        End Try
    End Function
    Public Sub Process(o1 As Byte, o2 As Byte, o3 As Byte, o4 As Byte, port As Int32)
        Status = GenerateIPAddress(o1, o2, o3, o4, port) & "の検証を開始しています。"
        Dim bw As New BackgroundWorker
        AddHandler bw.DoWork, Sub(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
                                  Try
                                      If CheckIPAvaliable(o1, o2, o3, o4, port) Then
                                          'If My.Computer.Network.Ping("http://" & GenerateIPAddress(o1, o2, o3, o4, port) & "/") Then
                                          AddList(o1, o2, o3, o4, port)
                                      End If
                                  Catch
                                  End Try
                              End Sub
        bw.RunWorkerAsync()
    End Sub
    Private Sub Checker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Checker.DoWork
        '192.168.0.0～192.168.255.255（192.168.0.0/16）
        For a = 0 To 255
            For b = 0 To 255
                Process(192, 168, a, b, Port)
            Next
        Next
        '10.0.0.0～10.255.255.255（10.0.0.0/8）
        For a = 0 To 255
            For b = 0 To 255
                For c = 0 To 255
                    Process(10, a, b, c, Port)
                Next
            Next
        Next
        '172.16.0.0～172.31.255.255（172.16.0.0/12）
        For a = 16 To 31
            For b = 0 To 255
                For c = 0 To 255
                    Process(172, a, b, c, Port)
                Next
            Next
        Next
        Status = "終了までお待ち下さい..."
    End Sub
    Private Sub StartCheck_Click(sender As Object, e As EventArgs) Handles StartCheck.Click
        IPList.Items.Clear()
        Checker.RunWorkerAsync()
        StartCheck.Enabled = False
        PortNum.Enabled = False
    End Sub
    Private Sub Checker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Checker.RunWorkerCompleted
        StartCheck.Enabled = True
        PortNum.Enabled = True
    End Sub
End Class
