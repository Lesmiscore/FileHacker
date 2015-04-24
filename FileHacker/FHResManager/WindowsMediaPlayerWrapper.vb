Imports AxWMPLib
Imports WMPLib

Public Class WindowsMediaPlayerWrapper
    Implements IDisposable
    Dim wmp As AxWindowsMediaPlayer
    Dim wmc As IWMPControls
    Public Sub New()
        wmp = New AxWindowsMediaPlayer
        wmc = wmp.Ctlcontrols
    End Sub
    Public Sub New(url As String)
        Me.New()
        wmp.URL = url
    End Sub
    Public Property URL As String
        Get
            Return wmp.URL
        End Get
        Set(value As String)
            wmp.URL = value
        End Set
    End Property
    Public Sub Play()
        wmc.play()
    End Sub
    Public Sub Pause()
        wmc.pause()
    End Sub
    Public Sub [Stop]()
        wmc.stop()
    End Sub
    Public Sub Prevoius()
        wmc.previous()
    End Sub
    Public Sub [Next]()
        wmc.next()
    End Sub
    Public Sub FastForward()
        wmc.fastForward()
    End Sub
    Public Sub FastReverse()
        wmc.fastReverse()
    End Sub
#Region "IDisposable Support"
    Private disposedValue As Boolean ' 重複する呼び出しを検出するには

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: マネージ状態を破棄します (マネージ オブジェクト)。
            End If

            ' TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下の Finalize() をオーバーライドします。
            ' TODO: 大きなフィールドを null に設定します。
            [Stop]()
            wmp.Dispose()
            wmp = Nothing
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: 上の Dispose(ByVal disposing As Boolean) にアンマネージ リソースを解放するコードがある場合にのみ、Finalize() をオーバーライドします。
    'Protected Overrides Sub Finalize()
    '    ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(ByVal disposing As Boolean) に記述します。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
