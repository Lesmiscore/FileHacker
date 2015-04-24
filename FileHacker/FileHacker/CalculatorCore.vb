Public Class CalculatorCore
    Public Shared Function ContainsBitMask(input As Integer, bits As Integer) As Boolean
        Return (input And bits) = bits
    End Function
    Public Shared Function MergeBitMask(input As Integer, bits As Integer) As Integer
        Return input Or bits
    End Function
    Public Shared Function SwitchBitMask(input As Integer, bits As Integer) As Integer
        Return input Xor bits
    End Function
    Public Shared Function DeleteBitMask(input As Integer, bits As Integer) As Integer
        Return input And Not bits
    End Function
    Public Shared Function BitMaskMatches(input As Integer, bits As Integer) As Integer
        Return input And bits
    End Function
End Class