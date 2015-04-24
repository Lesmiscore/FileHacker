'FileHacker互換受信機
Public Class UDPConnetor
    Public Shared Function Main(PCID As Integer) As String
        'ListenするIPアドレスを決める
        Dim host As String = "192.168.1." & (92 + PCID)
        Dim port = 14009
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
        Return rcvMsg
    End Function
    Public Shared Sub Main(PCID As Integer, sendMsg As String)
        'ListenするIPアドレスを決める
        Dim host As String = "192.168.1." & (92 + PCID)
        Dim port = 14009
        Dim enc As System.Text.Encoding = System.Text.Encoding.UTF8
        'ローカルポート番号localPortにバインドする
        Dim udp As New System.Net.Sockets.UdpClient(port)
        Dim sendBytes As Byte() = enc.GetBytes(sendMsg)
        'リモートホストを指定してデータを送信する
        udp.Send(sendBytes, sendBytes.Length, host, port)
        'UDP接続を終了
        udp.Close()
    End Sub
    Public Shared Function Main(PCID As Integer, sendMsg As Char()) As String
        'ListenするIPアドレスを決める
        Dim host As String = "192.168.1." & (92 + PCID)
        Dim port = 14009
        Dim enc As System.Text.Encoding = System.Text.Encoding.UTF8
        'ローカルポート番号localPortにバインドする
        Dim udp As New System.Net.Sockets.UdpClient(port)
        '送信するデータを読み込む
        Dim sendBytes As Byte() = enc.GetBytes(sendMsg)
        'リモートホストを指定してデータを送信する
        udp.Send(sendBytes, sendBytes.Length, host, port)
        'データを受信する
        Dim remoteEP As System.Net.IPEndPoint = Nothing
        Dim rcvBytes As Byte() = udp.Receive(remoteEP)
        Dim rcvMsg As String = enc.GetString(rcvBytes)
        Console.WriteLine("受信したデータ:{0}", rcvMsg)
        Console.WriteLine("送信元アドレス:{0}/ポート番号:{1}", _
            remoteEP.Address, remoteEP.Port)
        'UDP接続を終了
        udp.Close()
        Return rcvMsg
    End Function
End Class
