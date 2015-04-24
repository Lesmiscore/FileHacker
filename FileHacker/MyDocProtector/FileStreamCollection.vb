Imports System.IO

Public Class FileStreamCollection
    Inherits CollectionBase
    Implements ICollection(Of FileStream)
    Dim arr As FileStream() = {}
    Public Sub Add(item As FileStream) Implements ICollection(Of FileStream).Add
        If item Is Nothing Then
            Return
        End If
        arr = arr.Concat({item}).ToArray
    End Sub
    Public Sub Clear1() Implements ICollection(Of FileStream).Clear
        arr = {}
    End Sub
    Public Function Contains(item As FileStream) As Boolean Implements ICollection(Of FileStream).Contains
        Return arr.Contains(item)
    End Function
    Public Sub CopyTo(array() As FileStream, arrayIndex As Integer) Implements ICollection(Of FileStream).CopyTo
        Throw New NotSupportedException
    End Sub
    Public ReadOnly Property Count1 As Integer Implements ICollection(Of FileStream).Count
        Get
            Return arr.Length
        End Get
    End Property
    Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of FileStream).IsReadOnly
        Get
            Return arr.IsReadOnly
        End Get
    End Property
    Public Function Remove(item As FileStream) As Boolean Implements ICollection(Of FileStream).Remove
        Throw New NotSupportedException
    End Function
    Public Function GetEnumerator1() As IEnumerator(Of FileStream) Implements IEnumerable(Of FileStream).GetEnumerator
        Return Me
    End Function
End Class
