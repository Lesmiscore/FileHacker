Public Interface FHRemoteHost
    Sub SendShutDown()
    Sub SendSignOut()
    Sub SendReboot()
    Sub SendCursorLock()
    Sub SendCursorUnlock()
    Sub SendWallpaperChange(ByRef bmp As Bitmap)
    Sub CheckResponse()
    Sub SendMusicPlay(ByRef fn As String)
    Sub SendMusicStop()
    Sub ShowKakuSeikyuu()
End Interface
