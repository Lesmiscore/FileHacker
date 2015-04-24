Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Windows.Forms

Public Class CaptureScreen
    Const SRCCOPY As Integer = 13369376
    Const CAPTUREBLT As Integer = 1073741824

    <DllImport("user32.dll")> _
    Private Shared Function GetDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("gdi32.dll")> _
    Private Shared Function BitBlt(ByVal hDestDC As IntPtr, _
    ByVal x As Integer, ByVal y As Integer, _
    ByVal nWidth As Integer, ByVal nHeight As Integer, _
    ByVal hSrcDC As IntPtr, _
    ByVal xSrc As Integer, ByVal ySrc As Integer, _
    ByVal dwRop As Integer) As Integer
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function ReleaseDC(ByVal hwnd As IntPtr, _
    ByVal hdc As IntPtr) As IntPtr
    End Function

    ''' <summary>
    ''' プライマリスクリーンの画像を取得する
    ''' </summary>
    ''' <returns>プライマリスクリーンの画像</returns>
    Public Shared Function CaptureScreen() As Bitmap
        'プライマリモニタのデバイスコンテキストを取得
        Dim disDC As IntPtr = GetDC(IntPtr.Zero)
        'Bitmapの作成
        Dim bmp As New Bitmap(Screen.PrimaryScreen.Bounds.Width, _
            Screen.PrimaryScreen.Bounds.Height)
        'Graphicsの作成
        Dim g As Graphics = Graphics.FromImage(bmp)
        'Graphicsのデバイスコンテキストを取得
        Dim hDC As IntPtr = g.GetHdc()
        'Bitmapに画像をコピーする
        BitBlt(hDC, 0, 0, bmp.Width, bmp.Height, disDC, 0, 0, SRCCOPY)
        '解放
        g.ReleaseHdc(hDC)
        g.Dispose()
        ReleaseDC(IntPtr.Zero, disDC)

        Return bmp
    End Function

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    <DllImport("user32.dll")> _
    Private Shared Function GetWindowDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function GetWindowRect(ByVal hwnd As IntPtr, _
    ByRef lpRect As RECT) As Integer
    End Function

    ''' <summary>
    ''' アクティブなウィンドウの画像を取得する
    ''' </summary>
    ''' <returns>アクティブなウィンドウの画像</returns>
    Public Shared Function CaptureActiveWindow() As Bitmap
        'アクティブなウィンドウのデバイスコンテキストを取得
        Dim hWnd As IntPtr = GetForegroundWindow()
        Dim winDC As IntPtr = GetWindowDC(hWnd)
        'ウィンドウの大きさを取得
        Dim winRect As New RECT
        GetWindowRect(hWnd, winRect)
        'Bitmapの作成
        Dim bmp As New Bitmap(winRect.right - winRect.left, _
            winRect.bottom - winRect.top)
        'Graphicsの作成
        Dim g As Graphics = Graphics.FromImage(bmp)
        'Graphicsのデバイスコンテキストを取得
        Dim hDC As IntPtr = g.GetHdc()
        'Bitmapに画像をコピーする
        BitBlt(hDC, 0, 0, bmp.Width, bmp.Height, winDC, 0, 0, SRCCOPY)
        '解放
        g.ReleaseHdc(hDC)
        g.Dispose()
        ReleaseDC(hWnd, winDC)

        Return bmp
    End Function
End Class
