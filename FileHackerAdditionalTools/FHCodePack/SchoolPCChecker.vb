Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Public Class SchoolPCChecker
    Public Shared Function GetUN() As String
        Return Environment.UserName
    End Function
    Public Shared ReadOnly Property IsSchool As Boolean
        Get
            Return IsSchool(IsSchoolCheckMode.AllCheck)
            '(New Regex("\d\d\d\d\dkh05")).IsMatch(GetUN) Or
            'GetUN() = "kyotsu01" Or
            'GetUN() = "kyotsu02" Or
            'GetUN() = "kyotsu03" Or
            'GetUN() = "kyotsu04" Or
            'GetUN() = "kyotsu05" Or
            '(New Regex("ST\d\d")).IsMatch(SystemInformation.ComputerName()) Or
            '(New Regex("TE\d\d")).IsMatch(SystemInformation.ComputerName())
            ''説明
            ''1行目 個人(生徒)用アカウントか
            ''2行目 ｢共通01｣か
            ''3行目 ｢共通02｣か
            ''4行目 ｢共通03｣か
            ''5行目 ｢共通04｣か
            ''6行目 ｢共通05｣か
            ''7行目 生徒用PCか
            ''8行目 先生用PCか
        End Get
    End Property
    Public Shared ReadOnly Property IsSchool(mode As IsSchoolCheckMode) As Boolean
        Get
            Dim data As Boolean = False
            If (mode And IsSchoolCheckMode.AccountName) = IsSchoolCheckMode.AccountName Then
                data = data Or (New Regex("\d\d\d\d\dkh10")).IsMatch(GetUN)
            End If
            If (mode And IsSchoolCheckMode.IsKyotsu01) = IsSchoolCheckMode.IsKyotsu01 Then
                data = data Or GetUN() = "kyotsu01"
            End If
            If (mode And IsSchoolCheckMode.IsKyotsu02) = IsSchoolCheckMode.IsKyotsu02 Then
                data = data Or GetUN() = "kyotsu02"
            End If
            If (mode And IsSchoolCheckMode.IsKyotsu03) = IsSchoolCheckMode.IsKyotsu03 Then
                data = data Or GetUN() = "kyotsu03"
            End If
            If (mode And IsSchoolCheckMode.IsKyotsu04) = IsSchoolCheckMode.IsKyotsu04 Then
                data = data Or GetUN() = "kyotsu04"
            End If
            If (mode And IsSchoolCheckMode.IsKyotsu05) = IsSchoolCheckMode.IsKyotsu05 Then
                data = data Or GetUN() = "kyotsu05"
            End If
            If (mode And IsSchoolCheckMode.IsStudentPC) = IsSchoolCheckMode.IsStudentPC Then
                data = data Or (New Regex("ST\d\d")).IsMatch(SystemInformation.ComputerName())
            End If
            If (mode And IsSchoolCheckMode.IsTeacherPC) = IsSchoolCheckMode.IsTeacherPC Then
                data = data Or (New Regex("TE\d\d")).IsMatch(SystemInformation.ComputerName())
            End If
            Return data
        End Get
    End Property
    Public Enum IsSchoolCheckMode
        ''' <summary>
        ''' 個人(生徒)用アカウントか
        ''' </summary>
        ''' <remarks></remarks>
        AccountName = 0
        ''' <summary>
        ''' ｢共通01｣か
        ''' </summary>
        ''' <remarks></remarks>
        IsKyotsu01 = 1
        ''' <summary>
        ''' ｢共通02｣か
        ''' </summary>
        ''' <remarks></remarks>
        IsKyotsu02 = 2
        ''' <summary>
        ''' ｢共通03｣か
        ''' </summary>
        ''' <remarks></remarks>
        IsKyotsu03 = 4
        ''' <summary>
        ''' ｢共通04｣か
        ''' </summary>
        ''' <remarks></remarks>
        IsKyotsu04 = 8
        ''' <summary>
        ''' ｢共通05｣か
        ''' </summary>
        ''' <remarks></remarks>
        IsKyotsu05 = 16
        ''' <summary>
        ''' 共通アカウントか
        ''' </summary>
        ''' <remarks></remarks>
        IsKyotsuAll = IsKyotsu01 Or IsKyotsu02 Or IsKyotsu03 Or IsKyotsu04 Or IsKyotsu05
        ''' <summary>
        ''' 生徒用PCか
        ''' </summary>
        ''' <remarks></remarks>
        IsStudentPC = 32
        ''' <summary>
        ''' 先生用PCか
        ''' </summary>
        ''' <remarks></remarks>
        IsTeacherPC = 64
        ''' <summary>
        ''' PC室のPCか(ただし、NASとデータ保管用サーバーは除く)
        ''' </summary>
        ''' <remarks></remarks>
        IsAnyPCRoomPC = IsStudentPC Or IsTeacherPC
        ''' <summary>
        ''' 全てチェックします。
        ''' </summary>
        ''' <remarks></remarks>
        AllCheck = IsKyotsuAll Or IsAnyPCRoomPC
    End Enum
    Public Shared Function GetPCID() As Integer
        If Not IsSchool(IsSchoolCheckMode.IsStudentPC) Then
            Throw New Exception("このPCは生徒用PCではありません。")
        End If
        Return Integer.Parse(SystemInformation.ComputerName.Substring(2, 2))
    End Function
    Public Shared Function GetPCName() As String
        Return SystemInformation.ComputerName()
    End Function
End Class
