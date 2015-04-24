Imports System.Text.RegularExpressions

Public Class FHFinder
    Private Sub FHFinder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Public Function StartDetect(f As Controller) As Integer
        Me.Show()
        Dim p As String
ask:
        p = InputBox("PC番号を入力して下さい。" & vbCrLf & "空にすると、終了します。", "FHFinder")
        If p = "" Then
            Debug.WriteLine("p is blank.")
            Me.Close()
            f.ResevationStop()
        ElseIf Not Integer.TryParse(p, 0) OrElse Integer.Parse(p) > 26 OrElse Integer.Parse(p) = 0 Then
            MessageBox.Show("正しいPC番号を入力して下さい。")
            GoTo ask
            'ElseIf Not TryCatch(Of Boolean)(Function()
            '                                    Return UDPConnetor.Main(Integer.Parse(p), "FILEHACKER_SEND_TEST") = "TEST_CONNECT_ALLOW"
            '                                End Function) Then
            '    Select Case MessageBox.Show("PCを検出できませんでした。" & vbCrLf & "このまま続行しますか？", "エラー", MessageBoxButtons.YesNoCancel)
            '        Case Windows.Forms.DialogResult.Yes
            '            GoTo ret
            '        Case Windows.Forms.DialogResult.No
            '            Me.Close()
            '            f.ResevationStop()
            '        Case Windows.Forms.DialogResult.Cancel
            '            GoTo ask
            '    End Select
            '    GoTo ask
        End If
ret:
        Return Integer.Parse(p)
    End Function
    Delegate Function TryCatchDelegate(Of T)() As T
    Function TryCatch(Of T)(a As TryCatchDelegate(Of T)) As T
        Try
            Return (Function() As T
                        a()
                    End Function)()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class