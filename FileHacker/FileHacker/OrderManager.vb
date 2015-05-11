Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.IO
'FH本体
Public Class OrderManager
    Shared addresses As IEnumerable(Of KeyValuePair(Of String, UShort)) = Iterator Function() As IEnumerable(Of KeyValuePair(Of String, Integer))
                                                                              Yield New KeyValuePair(Of String, Integer)("nao20010128nao.dip.jp", 4127)
                                                                              Yield New KeyValuePair(Of String, Integer)("nao20010128nao.jpn.ph", 4127)
                                                                              Yield New KeyValuePair(Of String, Integer)("nao20010128nao.dip.jp", 5917)
                                                                              Yield New KeyValuePair(Of String, Integer)("nao20010128nao.jpn.ph", 5917)
                                                                              Yield New KeyValuePair(Of String, Integer)("localhost", 4127)
                                                                              Yield New KeyValuePair(Of String, Integer)("localhost", 5917)
                                                                          End Function()
    Shared handlers As New List(Of Action(Of String))
    Shared starter = Function() As Object
                         Dim bw As New BackgroundWorker
                         AddHandler bw.DoWork, AddressOf DoConnectFirst
                         bw.RunWorkerAsync()
                         Return bw
                     End Function()
    Shared orders As New List(Of String)
    Shared writer As StreamWriter
    Shared reader As StreamReader
    Public Shared Sub RegisterOrderHandler(handler As Action(Of String))
        If handler Is Nothing Then
            Return
        End If
        handlers.Add(handler)
    End Sub
    Private Shared Sub DoConnectFirst(s As Object, e As DoWorkEventArgs)
        Dim tcp As TcpClient
        For Each i In addresses
            Try
                Dim ipOrHost As String = i.Key
                Dim port As Integer = i.Value
                tcp = New System.Net.Sockets.TcpClient(ipOrHost, port)
                Console.WriteLine("サーバー({0}:{1})と接続しました({2}:{3})。", _
                    DirectCast(tcp.Client.RemoteEndPoint, System.Net.IPEndPoint).Address, _
                    DirectCast(tcp.Client.RemoteEndPoint, System.Net.IPEndPoint).Port, _
                    DirectCast(tcp.Client.LocalEndPoint, System.Net.IPEndPoint).Address, _
                    DirectCast(tcp.Client.LocalEndPoint, System.Net.IPEndPoint).Port)
                Dim ns As NetworkStream = tcp.GetStream()
                ns.ReadTimeout = 10000
                ns.WriteTimeout = 10000
                writer = New StreamWriter(ns)
                reader = New StreamReader(ns)
                writer.WriteLine("CONNECTING:" + SchoolPCChecker.GetPCID)
                If reader.ReadLine <> "CONNECT_ACCEPT" Then
                    writer.Close()
                    reader.Close()
                    tcp.Close()
                    Continue For
                End If
                Dim downloader As New BackgroundWorker
                AddHandler downloader.DoWork, Sub(s_ As Object, e_ As DoWorkEventArgs)
                                                  Dim order = reader.ReadLine
                                                  For Each j In handlers
                                                      Try
                                                          j(order)
                                                      Catch ex As Exception

                                                      End Try
                                                  Next
                                              End Sub
                downloader.RunWorkerAsync()
                Return
            Catch ex As Exception

            End Try
        Next
    End Sub
    Public Shared Sub SendReply(s As String)
        writer.WriteLine(s)
    End Sub
End Class
