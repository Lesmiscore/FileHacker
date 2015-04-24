Public Class JudgeGate
    Public Sub New()

    End Sub
    Dim ex As JudgeGateCheckerEventArgs
    Public Event OnCheckerStarted(sender As Object, ByRef e As JudgeGateCheckerEventArgs)
    Public Event OnResultReturnsTrue(sender As Object, ByRef e As JudgeGateOnResultReturnsTrueEventArgs)
    Public Sub Raise()
        If ex.Result Then
            Return
        End If
        RaiseEvent OnCheckerStarted(Me, ex)
        If ex.Result Then
            RaiseEvent OnResultReturnsTrue(Me, New JudgeGateOnResultReturnsTrueEventArgs(ex))
        End If
    End Sub
    Public Class JudgeGateCheckerEventArgs
        Inherits EventArgs
        Public Property Result As Boolean
        Public Property Data As Object
    End Class
    Public Class JudgeGateOnResultReturnsTrueEventArgs
        Inherits EventArgs
        Dim jgcea As JudgeGateCheckerEventArgs
        Public ReadOnly Property JudgeGateCheckerEventArgs As JudgeGateCheckerEventArgs
            Get
                Return jgcea
            End Get
        End Property
        Public Sub New(jg As JudgeGateCheckerEventArgs)
            jgcea = jg
        End Sub
    End Class
End Class