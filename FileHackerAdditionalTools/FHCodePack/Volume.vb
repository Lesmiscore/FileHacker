Imports System.Runtime.InteropServices

Namespace MMDeviceApi


    Public Class CAEndpointVolume
        Implements IDisposable

        Private _realEnumerator As IMMDeviceEnumerator
        Private _realDevice As IMMDevice
        Private _realEndpoint As IAudioEndpointVolume

        Public Sub New()
            If (System.Environment.OSVersion.Version.Major < 6) Then
                'xp以下はアウト
                Throw New NotSupportedException("This functionality is only supported on Windows Vista or newer.")
            End If

            'immdevice enumerator生成
            _realEnumerator = CType(New _MMDeviceEnumerator(), IMMDeviceEnumerator)

            'device取得
            Marshal.ThrowExceptionForHR(_realEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, _realDevice))

            'endpoint取得
            Marshal.ThrowExceptionForHR(_realDevice.Activate(IID_IAudioEndpointVolume, CLSCTX.ALL, IntPtr.Zero, _realEndpoint))
        End Sub

        Sub Dispose() Implements IDisposable.Dispose
            Marshal.ReleaseComObject(_realEndpoint)
            Marshal.ReleaseComObject(_realDevice)
            Marshal.ReleaseComObject(_realEnumerator)
        End Sub

        Public Property Mute() As Boolean
            Get
                Dim ret As Boolean
                Marshal.ThrowExceptionForHR(_realEndpoint.GetMute(ret))
                Return ret
            End Get
            Set(ByVal value As Boolean)
                Marshal.ThrowExceptionForHR(_realEndpoint.SetMute(value, Guid.Empty))
            End Set
        End Property

        Public Property MasterVolume() As Single
            Get
                Dim ret As Single
                Marshal.ThrowExceptionForHR(_realEndpoint.GetMasterVolumeLevelScalar(ret))
                Return ret
            End Get
            Set(ByVal value As Single)
                Marshal.ThrowExceptionForHR(_realEndpoint.SetMasterVolumeLevelScalar(value, Guid.Empty))
            End Set
        End Property

    End Class

    <Flags()> _
    Public Enum CLSCTX As UInteger
        INPROC_SERVER = &H1
        INPROC_HANDLER = &H2
        LOCAL_SERVER = &H4
        INPROC_SERVER16 = &H8
        REMOTE_SERVER = &H10
        INPROC_HANDLER16 = &H20
        RESERVED1 = &H40
        RESERVED2 = &H80
        RESERVED3 = &H100
        RESERVED4 = &H200
        NO_CODE_DOWNLOAD = &H400
        RESERVED5 = &H800
        NO_CUSTOM_MARSHAL = &H1000
        ENABLE_CODE_DOWNLOAD = &H2000
        NO_FAILURE_LOG = &H4000
        DISABLE_AAA = &H8000
        ENABLE_AAA = &H10000
        FROM_DEFAULT_CONTEXT = &H20000
        INPROC = INPROC_SERVER Or INPROC_HANDLER
        SERVER = INPROC_SERVER Or LOCAL_SERVER Or REMOTE_SERVER
        ALL = SERVER Or INPROC_HANDLER
    End Enum


    Module MMDevGUID
        Public CLASS_IMMDeviceEnumerator As New Guid("{BCDE0395-E52F-467C-8E3D-C4579291692E}")
        Public IID_IMMDeviceEnumerator As New Guid("{A95664D2-9614-4F35-A746-DE8DB63617E6}")
        Public IID_IMMDevice As New Guid("{D666063F-1587-4E43-81F1-B948E807363F}")
        Public IID_IMMDeviceCollection As New Guid("{0BD7A1BE-7A1A-44DB-8397-CC5392387B5E}")
        Public IID_IAudioEndpointVolume As New Guid("{5CDF2C82-841E-4546-9722-0CF74078229A}")
        Public IID_IAudioMeterInformation As New Guid("{C02216F6-8C67-4B5B-9D00-D008E73E0064}")
        Public IID_IAudioEndpointVolumeCallback As New Guid("{657804FA-D6AD-4496-8A60-352752AF4F89}")
    End Module

    Public Enum EDataFlow
        eRender = 0
        eCapture
        eAll
        EDataFlow_enum_count
    End Enum

    Public Enum ERole
        eConsole = 0
        eMultimedia
        eCommunications
        ERole_enum_count
    End Enum

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure AUDIO_VOLUME_NOTIFICATION_DATA
        Public guidEventContext As Guid
        Public bMuted As Boolean
        Public fMasterVolume As Single
        Public nChannels As UInteger
        Public afChannelVolumes As Single
    End Structure


    <ComImport(), Guid("657804FA-D6AD-4496-8A60-352752AF4F89"), _
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IAudioEndpointVolumeCallback
        <PreserveSig()> Function OnNotify(ByVal pNotifyData As IntPtr) As Integer
    End Interface

    <ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IMMNotificationClient
    End Interface

    <ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IPropertyStore
    End Interface


    'IAudioEndpointVolume再定義
    <ComImport(), Guid("5CDF2C82-841E-4546-9722-0CF74078229A"), _
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IAudioEndpointVolume
        <PreserveSig()> Function RegisterControlChangeNotify(ByVal pNotify As IAudioEndpointVolumeCallback) As Integer
        <PreserveSig()> Function UnregisterControlChangeNotify(ByVal pNotify As IAudioEndpointVolumeCallback) As Integer
        <PreserveSig()> Function GetChannelCount(<Out()> ByRef pnChannelCount As Integer) As Integer
        <PreserveSig()> Function SetMasterVolumeLevel(ByVal fLevelDB As Single, ByVal pguidEventContext As Guid) As Integer
        <PreserveSig()> Function SetMasterVolumeLevelScalar(ByVal fLevel As Single, ByVal pguidEventContext As Guid) As Integer
        <PreserveSig()> Function GetMasterVolumeLevel(<Out()> ByRef pfLevelDB As Single) As Integer
        <PreserveSig()> Function GetMasterVolumeLevelScalar(<Out()> ByRef pfLevel As Single) As Integer
        <PreserveSig()> Function SetChannelVolumeLevel(ByVal nChannel As UInteger, ByVal fLevelDB As Single, ByVal pguidEventContext As Guid) As Integer
        <PreserveSig()> Function SetChannelVolumeLevelScalar(ByVal nChannel As UInteger, ByVal fLevel As Single, ByVal pguidEventContext As Guid) As Integer
        <PreserveSig()> Function GetChannelVolumeLevel(ByVal nChannel As UInteger, <Out()> ByRef pfLevelDB As Single) As Integer
        <PreserveSig()> Function GetChannelVolumeLevelScalar(ByVal nChannel As UInteger, <Out()> ByRef pfLevel As Single) As Integer
        <PreserveSig()> Function SetMute(<MarshalAs(UnmanagedType.Bool)> ByVal bMute As Boolean, ByVal pguidEventContext As Guid) As Integer
        <PreserveSig()> Function GetMute(<Out()> ByRef pbMute As Boolean) As Integer
        <PreserveSig()> Function GetVolumeStepInfo(<Out()> ByRef pnStep As UInteger, <Out()> ByRef pnStepCount As UInteger) As Integer
        <PreserveSig()> Function VolumeStepUp(ByVal pguidEventContext As Guid) As Integer
        <PreserveSig()> Function VolumeStepDown(ByVal pguidEventContext As Guid) As Integer
        <PreserveSig()> Function QueryHardwareSupport(<Out()> ByRef pdwHardwareSupportMask As UInteger) As Integer
        <PreserveSig()> Function GetVolumeRange(<Out()> ByRef pflVolumeMindB As Single, <Out()> ByRef pflVolumeMaxdB As Single, <Out()> ByRef pflVolumeIncrementdB As Single) As Integer
    End Interface


    <ComImport(), Guid("D666063F-1587-4E43-81F1-B948E807363F"), _
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IMMDevice
        <PreserveSig()> _
        Function Activate(ByRef iid As Guid, ByVal dwClsCtx As CLSCTX, ByVal pActivationParams As IntPtr, <MarshalAs(UnmanagedType.IUnknown), Out()> ByRef ppInterface As Object) As Integer
        <PreserveSig()> _
        Function OpenPropertyStore(ByVal stgmAccess As Integer, <Out()> ByRef propertyStore As IPropertyStore) As Integer
        <PreserveSig()> _
        Function GetId(<MarshalAs(UnmanagedType.LPWStr), Out()> ByVal ppstrId As String) As Integer
        <PreserveSig()> _
        Function GetState(<Out()> ByRef pdwState As Integer)
    End Interface

    <ComImport(), Guid("0BD7A1BE-7A1A-44DB-8397-CC5392387B5E"), _
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IMMDeviceCollection
        <PreserveSig()> _
        Function GetCount(<Out()> ByRef pcDevices As UInteger) As Integer
        <PreserveSig()> _
        Function Item(ByVal nDevice As UInteger, <Out()> ByRef Device As IMMDevice) As Integer
    End Interface

    <ComImport(), Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), _
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IMMDeviceEnumerator
        <PreserveSig()> _
        Function EnumAudioEndpoints(ByVal dataFlow As EDataFlow, ByVal StateMask As UInteger, <Out()> ByRef device As IMMDeviceCollection) As Integer
        <PreserveSig()> _
        Function GetDefaultAudioEndpoint(ByVal dataFlow As EDataFlow, ByVal role As ERole, <Out()> ByRef ppEndpoint As IMMDevice) As Integer
        <PreserveSig()> _
        Function GetDevice(ByVal pwstrId As String, <Out()> ByRef ppDevice As IMMDevice) As Integer
        <PreserveSig()> _
        Function RegisterEndpointNotificationCallback(ByVal pClient As IntPtr) As Integer
        <PreserveSig()> _
        Function UnregisterEndpointNotificationCallback(ByVal pClient As IntPtr) As Integer
    End Interface

    <ComImport(), Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")> _
    Friend Class _MMDeviceEnumerator
    End Class

End Namespace