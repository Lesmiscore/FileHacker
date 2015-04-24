Imports System.Drawing.Imaging
Imports System.IO

Public Class PictureTools
    Public Shared Function GetPictureBytes(ByVal img As Bitmap) As Byte()
        '1ピクセルあたりのバイト数を取得する
        Dim pixelSize As Integer = 3
        If img.PixelFormat = PixelFormat.Format24bppRgb Then
            pixelSize = 3
        ElseIf img.PixelFormat = PixelFormat.Format32bppArgb OrElse _
            img.PixelFormat = PixelFormat.Format32bppPArgb OrElse _
            img.PixelFormat = PixelFormat.Format32bppRgb Then
            pixelSize = 4
        Else
            Throw New ArgumentException( _
                "1ピクセルあたり24または32ビットの形式のイメージのみ有効です。", _
                "img")
        End If

        'Bitmapをロックする
        Dim bmpDate As BitmapData = _
            img.LockBits(New Rectangle(0, 0, img.Width, img.Height), _
                         ImageLockMode.ReadWrite, img.PixelFormat)

        'ピクセルデータをバイト型配列で取得する
        Dim ptr As IntPtr = bmpDate.Scan0
        Dim pixels As Byte() = New Byte(bmpDate.Stride * img.Height - 1) {}
        System.Runtime.InteropServices.Marshal.Copy(ptr, pixels, 0, pixels.Length)

        'ピクセルデータを元に戻す
        System.Runtime.InteropServices.Marshal.Copy(pixels, 0, ptr, pixels.Length)

        'ロックを解除する
        img.UnlockBits(bmpDate)
        Return pixels
    End Function

    Public Shared Sub SetPicturesBytes(ByVal img As Bitmap, pixels As Byte())
        '1ピクセルあたりのバイト数を取得する
        Dim pixelSize As Integer = 3
        If img.PixelFormat = PixelFormat.Format24bppRgb Then
            pixelSize = 3
        ElseIf img.PixelFormat = PixelFormat.Format32bppArgb OrElse _
            img.PixelFormat = PixelFormat.Format32bppPArgb OrElse _
            img.PixelFormat = PixelFormat.Format32bppRgb Then
            pixelSize = 4
        Else
            Throw New ArgumentException( _
                "1ピクセルあたり24または32ビットの形式のイメージのみ有効です。", _
                "img")
        End If

        'Bitmapをロックする
        Dim bmpDate As BitmapData = _
            img.LockBits(New Rectangle(0, 0, img.Width, img.Height), _
                         ImageLockMode.ReadWrite, img.PixelFormat)

        'ピクセルデータをバイト型配列で取得する
        Dim ptr As IntPtr = bmpDate.Scan0

        System.Runtime.InteropServices.Marshal.Copy(pixels, 0, ptr, pixels.Length)

        'ロックを解除する
        img.UnlockBits(bmpDate)
    End Sub

    Public Shared Function GetWallpaperChangeScriptText(bmp As Bitmap) As String
        Dim aaa As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\wp.bmp"
        bmp.Save(aaa, ImageFormat.Bmp)
        Dim a As String = "SYSTEM_WALLPAPER_CHANGE;"
        a += Convert.ToBase64String(File.ReadAllBytes(aaa))
        Return a
    End Function
End Class
