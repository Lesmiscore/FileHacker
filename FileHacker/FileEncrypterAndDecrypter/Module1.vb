Imports System.IO

Module Module1
    Sub Main(args As String())
        Try
            If args.Length <> 2 Then
                Console.WriteLine("Error:Command is wrong")
                Environment.ExitCode = 1
                Return
            End If
            Dim from As String = args(0)
            Dim top As String = args(1)
            If Not File.Exists(from) Then
                Console.WriteLine("Error:From file does not exist")
                Environment.ExitCode = 2
                Return
            End If
            Dim i As Byte() = File.ReadAllBytes(from)
            For a = 0 To i.Length - 1
                i(a) = i(a) Xor 170
            Next
            If File.Exists(top) Then
                File.Delete(top)
            End If
            File.WriteAllBytes(top, i)
            Console.WriteLine("Finished!!!")
            Environment.ExitCode = 0
        Catch
            Environment.ExitCode = 3
            Return
        End Try
    End Sub
    Public Class XOREncrypt
        Inherits Stream
        Dim from As Stream

        Public Sub New(from As Stream)
            Me.from = from
        End Sub

        Public Overrides ReadOnly Property CanRead As Boolean
            Get
                Return from.CanRead
            End Get
        End Property

        Public Overrides ReadOnly Property CanSeek As Boolean
            Get
                Return from.CanSeek
            End Get
        End Property

        Public Overrides ReadOnly Property CanWrite As Boolean
            Get
                Return from.CanWrite
            End Get
        End Property

        Public Overrides Sub Flush()
            from.Flush()
        End Sub

        Public Overrides ReadOnly Property Length As Long
            Get
                Return from.Length
            End Get
        End Property

        Public Overrides Property Position As Long
            Get
                Return from.Position
            End Get
            Set(value As Long)
                from.Position = value
            End Set
        End Property

        Public Overrides Function Read(buffer() As Byte, offset As Integer, count As Integer) As Integer
            Return from.Read(buffer, offset, count)
        End Function

        Public Overrides Function Seek(offset As Long, origin As SeekOrigin) As Long
            Return from.Seek(offset, origin)
        End Function

        Public Overrides Sub SetLength(value As Long)
            from.SetLength(value)
        End Sub

        Public Overrides Sub Write(buffer() As Byte, offset As Integer, count As Integer)
            For a = offset To offset + count
                from.WriteByte(buffer(a) Xor 170)
            Next
        End Sub
    End Class

End Module
