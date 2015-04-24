'PC強制ロック
Public Class UDPConnetor
    Public Shared Sub Main(sendMsg As String)
        'ListenするIPアドレスを決める
        Dim host As String = "localhost"
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
End Class
