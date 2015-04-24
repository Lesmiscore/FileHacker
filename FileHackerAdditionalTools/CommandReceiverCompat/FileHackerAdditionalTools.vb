'FileHackerコマンドレシーバー　(旧互換)
Imports System.ComponentModel
Imports FHCodePack

Public Class FileHackerAdditionalTools
    Public Function GetWorkers(sender As Object) As BackgroundWorker()
        Dim dbg As New BackgroundWorker
        AddHandler dbg.DoWork,
            Sub(sender_ As Object, e As DoWorkEventArgs)
                Dim host As String = "192.168.1." & (92 + SchoolPCChecker.GetPCID)
                Dim port = 14009
                While True
                    Try
                        'ListenするIPアドレスを決める
                        Dim enc As System.Text.Encoding = System.Text.Encoding.UTF8
                        'ローカルポート番号localPortにバインドする
                        Dim udp As New System.Net.Sockets.UdpClient(port)
                        'データを受信する
                        Dim remoteEP As System.Net.IPEndPoint = Nothing
                        Dim rcvBytes As Byte() = udp.Receive(remoteEP)
                        Dim rcvMsg As String = enc.GetString(rcvBytes)
                        Console.WriteLine("受信したデータ:{0}", rcvMsg)
                        Console.WriteLine("送信元アドレス:{0}/ポート番号:{1}", _
                            remoteEP.Address, remoteEP.Port)
                        'UDP接続を終了
                        udp.Close()
                        'FHのフォームのDoCommandを呼び出してコマンド実行
                        'e.Argument.DoCommand(rcvMsg)
                        e.Argument.GetType.InvokeMember("DoCommand",
                                                        Reflection.BindingFlags.Public Or Reflection.BindingFlags.InvokeMethod,
                                                        Nothing,
                                                        e.Argument,
                                                        New Object() {rcvMsg})
                    Catch ex As Exception
                    End Try
                End While
            End Sub
        Return {dbg}
    End Function
End Class
