Imports System.Windows.Forms

Public Module Main
    Sub Main(args As String())
        Dim a As String() = {}
        For Each i In GetType(SystemInformation).GetProperties()
            a = a.Concat({String.Format(i.Name & ":{0}", GetType(SystemInformation).InvokeMember(i.Name,
                                                                                         Reflection.BindingFlags.GetProperty Or Reflection.BindingFlags.Static Or Reflection.BindingFlags.Public,
                                                                                         Nothing,
                                                                                         Nothing,
                                                                                         Nothing))}).ToArray
        Next
        Array.Sort(a)
        For Each i In a
            Console.WriteLine(i)
        Next
        Console.ReadKey()
    End Sub
End Module
