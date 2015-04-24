'マッハコピー(多重高速コピー)
Imports System.ComponentModel
Imports System.IO

Public Class FileHackerAdditionalTools
    Const MaxThreads = 120 '120個のワーカーを...  (PCｸﾗｯｼｭｽﾙﾜﾅ...ﾎﾞｿ)
    Public Function GetWorkers(a As Object) As BackgroundWorker()
        Dim w(MaxThreads) As BackgroundWorker
        For a = 0 To MaxThreads - 1
            w(a) = New BackgroundWorker
            AddHandler w(a).DoWork,
                Sub(sender As Object, e As DoWorkEventArgs)
                    Dim from As String = e.Argument.GetType.InvokeMember("from",
                                                                Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.GetField,
                                                                Nothing,
                                                                e.Argument,
                                                                New Object() {}) 'コピー元(マイドキュメント)s
                    Dim topath2 As String = e.Argument.GetType.InvokeMember("topath2",
                                                                Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.GetField,
                                                                Nothing,
                                                                e.Argument,
                                                                New Object() {}) 'コピー先(共有フォルダー)
                    While True
                        Try
                            'FHのコピーを流用(リカバリーコピーもできるし)
                            e.Argument.GetType.InvokeMember("CopyDirectory",
                                                                Reflection.BindingFlags.NonPublic Or _
                                                                Reflection.BindingFlags.Public Or _
                                                                Reflection.BindingFlags.InvokeMethod,
                                                                Nothing,
                                                                e.Argument,
                                                                New Object() {from, topath2})
                        Catch null As Exception
                        End Try
                    End While
                End Sub
        Next
        Return w
    End Function
End Class
