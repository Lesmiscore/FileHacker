'システム情報出力ツール
Imports System.ComponentModel
Imports System.Windows.Forms
Imports FHCodePack
Imports System.Text
Imports System.Drawing

Public Class FileHackerAdditionalTools
    Public Function GetWorkers(sender As Object) As BackgroundWorker()
        Dim dbg As New BackgroundWorker
        AddHandler dbg.DoWork,
            Sub(sender_ As Object, e As DoWorkEventArgs)
                Dim output As New StringBuilder
                output.AppendLine("-=Computer Info=-")
                Dim a As String() = {}
                For Each i In GetType(ComputerInfo).GetProperties()
                    a = a.Concat({String.Format(i.Name & ":{0}", GetType(ComputerInfo).InvokeMember(i.Name,
                                                                                                 Reflection.BindingFlags.GetProperty Or Reflection.BindingFlags.Static Or Reflection.BindingFlags.Public,
                                                                                                 Nothing,
                                                                                                 Nothing,
                                                                                                 Nothing))}).ToArray
                Next
                Array.Sort(a)
                For Each i In a
                    output.AppendLine(i)
                Next
                Erase a
                output.AppendLine("=-Computer Info End-=").AppendLine().AppendLine("-=System Directories Info=-")
                Dim cache As New StringBuilder
                For Each i In Sort([Enum].GetNames(GetType(Environment.SpecialFolder)))
                    cache.AppendLine(i & ":" & Environment.GetFolderPath([Enum].Parse(GetType(Environment.SpecialFolder), i)))
                Next
                output.AppendLine(cache.ToString).AppendLine("=-System Directories Info End-=").AppendLine().AppendLine("-=System Info=-")
                a = {}
                For Each i In GetType(SystemInformation).GetProperties()
                    a = a.Concat({String.Format(i.Name & ":{0}", GetType(SystemInformation).InvokeMember(i.Name,
                                                                                                 Reflection.BindingFlags.GetProperty Or Reflection.BindingFlags.Static Or Reflection.BindingFlags.Public,
                                                                                                 Nothing,
                                                                                                 Nothing,
                                                                                                 Nothing))}).ToArray
                Next
                Array.Sort(a)
                For Each i In a
                    output.AppendLine(i)
                Next
                Erase a
                output.AppendLine("=-System Info End-=").AppendLine().AppendLine("-=Installed Fonts Info=-")
                'InstalledFontCollectionオブジェクトの取得
                Dim ifc As New System.Drawing.Text.InstalledFontCollection
                'インストールされているすべてのフォントファミリアを取得
                Dim ffs As FontFamily() = ifc.Families

                Dim ff As FontFamily
                For Each ff In ffs
                    output.AppendLine(ff.GetName(&H11))
                Next ff
                Console.WriteLine(output.AppendLine("=-Installed Fonts Info End-=").ToString)
            End Sub
        Return {dbg}
    End Function
    Public Function Sort(Of T)(input As T()) As T()
        Dim copy = input.Clone
        Array.Sort(Of T)(copy)
        Return copy
    End Function
    Public Class ComputerInfo
        Public Shared ReadOnly Property ComputerName As String
            Get
                Return SchoolPCChecker.GetPCName
            End Get
        End Property
        Public Shared ReadOnly Property ComputerID As String
            Get
                Return SchoolPCChecker.GetPCID
            End Get
        End Property
        Public Shared ReadOnly Property UserName As String
            Get
                Return SchoolPCChecker.GetUN
            End Get
        End Property
        Public Shared ReadOnly Property SoftwareMode As String
            Get
                Return [Enum].GetName(GetType(ConfigXmlParser.ExceptionsXmlModes), ConfigXmlParser.GetUserExceptionMode)
            End Get
        End Property
        Public Shared ReadOnly Property SystemVolume As String
            Get
                Dim dev As MMDeviceApi.CAEndpointVolume
                Try
                    dev = New MMDeviceApi.CAEndpointVolume
                Catch ex As Exception : Return "" : End Try
                Return dev.MasterVolume
            End Get
        End Property
    End Class
End Class
