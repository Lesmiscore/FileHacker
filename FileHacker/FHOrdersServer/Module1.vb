Imports System.Net
Imports System.IO
Imports System.ComponentModel
Imports System.Net.Sockets

Module Module1
    Public Sub Main()
        Dim connections As New Dictionary(Of String, Tuple(Of TextReader, TextWriter, NetworkStream, BackgroundWorker, TcpClient))
        Dim controllers As New List(Of Tuple(Of TextReader, TextWriter, NetworkStream, BackgroundWorker, TcpClient))
        Dim uploadQueue As New Queue(Of Tuple(Of String, String))
        Dim ipAdd As System.Net.IPAddress = IPAddress.Any
        Dim port As Integer = 4127

        'TcpListenerオブジェクトを作成する
        Dim listener As New TcpListener(ipAdd, port)

        'Listenを開始する
        listener.Start()
        Dim uploader As New BackgroundWorker
        AddHandler uploader.DoWork, Sub(sender As Object, e As DoWorkEventArgs)
                                        While True
                                            Dim job As Tuple(Of String, String)
                                            SyncLock uploadQueue
                                                job = uploadQueue.Dequeue
                                            End SyncLock
                                            If job Is Nothing Then
                                                Continue While
                                            End If
                                            If job.Item1 = "CONTROLLER" Then
                                                For Each i In controllers
                                                    Try
                                                        SyncLock i.Item3
                                                            i.Item2.WriteLine(job.Item2)
                                                        End SyncLock
                                                    Catch ex As Exception

                                                    End Try
                                                Next
                                            Else
                                                Try
                                                    Dim i = connections(job.Item1)
                                                    SyncLock i.Item3
                                                        i.Item2.WriteLine(job.Item2)
                                                    End SyncLock
                                                Catch ex As Exception

                                                End Try
                                            End If
                                        End While
                                    End Sub
        uploader.RunWorkerAsync()
        While True
            Dim client As System.Net.Sockets.TcpClient = listener.AcceptTcpClient()
            Console.WriteLine("クライアント({0}:{1})と接続しました。", _
                DirectCast(client.Client.RemoteEndPoint, IPEndPoint).Address, _
                DirectCast(client.Client.RemoteEndPoint, IPEndPoint).Port)

            'NetworkStreamを取得
            Dim ns As NetworkStream = client.GetStream()
            Dim writer As New StreamWriter(ns)
            Dim reader As New StreamReader(ns)
            Dim receiver As New BackgroundWorker
            AddHandler receiver.DoWork, Sub(sender As Object, e As DoWorkEventArgs)
                                            Dim tuple As Tuple(Of TextReader, TextWriter, NetworkStream, BackgroundWorker, TcpClient) = e.Argument
                                            Dim read = tuple.Item1
                                            Dim write = tuple.Item2
                                            Dim from = read.ReadLine
                                            If Not from.StartsWith("CONNECTING:") Then
                                                Console.WriteLine("Invalid client detected!")
                                                read.Close()
                                                writer.Close()
                                                tuple.Item3.Close()
                                                tuple.Item5.Close()
                                                Return
                                            End If
                                            If from.Split(":").Last = "CONTROLLER" Then
                                                controllers.Add(tuple)
                                                While True
                                                    Dim sendTo As String
                                                    Dim message As String
                                                    SyncLock tuple.Item3
                                                        sendTo = read.ReadLine
                                                        message = read.ReadLine
                                                    End SyncLock
                                                    Console.WriteLine("Queued """ & message & """ to " & sendTo & " from the controller.")
                                                    SyncLock uploadQueue
                                                        uploadQueue.Enqueue(New Tuple(Of String, String)(sendTo, message))
                                                    End SyncLock
                                                End While
                                            Else
                                                connections(from.Split(":").Last) = tuple
                                                While True
                                                    Dim message As String
                                                    SyncLock tuple.Item3
                                                        message = read.ReadLine
                                                    End SyncLock
                                                    Console.WriteLine("Queued """ & message & """ to the controllers from " & from.Split(":").Last & ".")
                                                    SyncLock uploadQueue
                                                        uploadQueue.Enqueue(New Tuple(Of String, String)("CONTROLLER", message))
                                                    End SyncLock
                                                End While
                                            End If

                                        End Sub
            receiver.RunWorkerAsync(New Tuple(Of TextReader, TextWriter, NetworkStream, BackgroundWorker, TcpClient)(reader, writer, ns, receiver, client))
        End While
    End Sub
End Module
