Imports System.IO
Imports System.Reflection
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms

Module Module1
    Dim at_workers As New Queue(Of BackgroundWorker)
    Public Sub Main()
        'MessageBox.Show("FuckYou")
        If Not Directory.Exists("AdditionalTools\") Then
            Console.WriteLine("Error:AdditionalTools folder is not found. This folder is created.")
            Directory.CreateDirectory("AdditionalTools\")
            'Return
            Thread.Sleep(1000 * 10)
        End If
        'MessageBox.Show("FuckYou")
        For Each i In Directory.GetFiles("AdditionalTools\")
            Console.WriteLine("Found:" & IO.Path.GetFileName(i))
            If Not (i.EndsWith(".dll") Or i.EndsWith(".exe")) Then
                Console.WriteLine("Error:" & IO.Path.GetFileName(i) & " is not binary file. This file is skipped.")
                Continue For
            End If
            Dim asm As Assembly
            Try
                asm = Assembly.LoadFrom(i)
                Dim typ = asm.GetType(IO.Path.GetFileNameWithoutExtension(i) & ".FileHackerAdditionalTools", True, True)
                Dim obj = typ.InvokeMember(Nothing,
                                           BindingFlags.CreateInstance,
                                           Nothing,
                                           Nothing,
                                           New Object() {})
                Dim workers As BackgroundWorker() = obj.GetWorkers(New Form()) 'typ.InvokeMember("GetWorkers",
                'BindingFlags.InvokeMethod Or BindingFlags.IgnoreCase Or BindingFlags.Public,
                'Nothing,
                'obj,
                '{Me})
                If workers Is Nothing Then
                    Console.WriteLine("Error:" & IO.Path.GetFileName(i) & " gives null. This file is skipped.")
                    Continue For
                End If
                If workers.Length = 0 Then
                    Console.WriteLine("Error:" & IO.Path.GetFileName(i) & " does not give anyone. This file is skipped.")
                    Continue For
                End If
                Console.WriteLine("Info:" & IO.Path.GetFileName(i) & " contains " & workers.Length & " workers. These workers will load and start.")
                For Each i_ In workers
                    at_workers.Enqueue(i_)
                Next
            Catch ex As Exception
                Console.WriteLine("Error:" & IO.Path.GetFileName(i) & " has an error. This file is skipped.")
                Console.WriteLine("-=Exception Info=-")
                Console.WriteLine("Exception Class:" & ex.GetType.Name)
                Console.WriteLine("Message:" & ex.Message)
            End Try
        Next

        Console.WriteLine(at_workers.Count)
        Console.ReadKey()
    End Sub
End Module
