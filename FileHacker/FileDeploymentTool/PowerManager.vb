Public Class PowerManager
    Public Enum ExitWindows
        EWX_LOGOFF = &H0
        EWX_SHUTDOWN = &H1
        EWX_REBOOT = &H2
        EWX_POWEROFF = &H8
        EWX_RESTARTAPPS = &H40
        EWX_FORCE = &H4
        EWX_FORCEIFHUNG = &H10
    End Enum

    <System.Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)> _
    Public Shared Function ExitWindowsEx(ByVal uFlags As ExitWindows, _
    ByVal dwReason As Integer) As Boolean
    End Function
    <System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError:=True)> _
    Private Shared Function GetCurrentProcess() As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("advapi32.dll", SetLastError:=True)> _
    Private Shared Function OpenProcessToken(ByVal ProcessHandle As IntPtr, _
    ByVal DesiredAccess As Integer, _
    ByRef TokenHandle As IntPtr) As Boolean
    End Function

    <System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError:=True)> _
    Private Shared Function CloseHandle(ByVal hHandle As IntPtr) As Boolean
    End Function

    <System.Runtime.InteropServices.DllImport("advapi32.dll", SetLastError:=True, _
        CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function LookupPrivilegeValue(ByVal lpSystemName As String, _
    ByVal lpName As String, _
    ByRef lpLuid As Long) As Boolean
    End Function

    <System.Runtime.InteropServices.StructLayout( _
        System.Runtime.InteropServices.LayoutKind.Sequential, Pack:=1)> _
    Private Structure TOKEN_PRIVILEGES
        Public PrivilegeCount As Integer
        Public Luid As Long
        Public Attributes As Integer
    End Structure

    <System.Runtime.InteropServices.DllImport("advapi32.dll", SetLastError:=True)> _
    Private Shared Function AdjustTokenPrivileges(ByVal TokenHandle As IntPtr, _
    ByVal DisableAllPrivileges As Boolean, _
    ByRef NewState As TOKEN_PRIVILEGES, _
    ByVal BufferLength As Integer, _
    ByVal PreviousState As IntPtr, _
    ByVal ReturnLength As IntPtr) As Boolean
    End Function

    'シャットダウンするためのセキュリティ特権を有効にする
    Public Shared Sub AdjustToken()
        Const TOKEN_ADJUST_PRIVILEGES As Integer = &H20
        Const TOKEN_QUERY As Integer = &H8
        Const SE_PRIVILEGE_ENABLED As Integer = &H2
        Const SE_SHUTDOWN_NAME As String = "SeShutdownPrivilege"

        If Environment.OSVersion.Platform <> PlatformID.Win32NT Then
            Return
        End If

        Dim procHandle As IntPtr = GetCurrentProcess()

        'トークンを取得する
        Dim tokenHandle As IntPtr
        OpenProcessToken(procHandle, _
            TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, tokenHandle)
        'LUIDを取得する
        Dim tp As New TOKEN_PRIVILEGES()
        tp.Attributes = SE_PRIVILEGE_ENABLED
        tp.PrivilegeCount = 1
        LookupPrivilegeValue(Nothing, SE_SHUTDOWN_NAME, tp.Luid)
        '特権を有効にする
        AdjustTokenPrivileges(tokenHandle, False, tp, 0, IntPtr.Zero, IntPtr.Zero)

        '閉じる
        CloseHandle(tokenHandle)
    End Sub
End Class
