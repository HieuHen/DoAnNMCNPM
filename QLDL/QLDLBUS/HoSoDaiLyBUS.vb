Imports QLDLDAL
Imports QLDLDTO
Imports Utility

Public Class HoSoDaiLyBUS
    Private daiLyDAL As HoSoDaiLyDAL
    Public Sub New()
        daiLyDAL = New HoSoDaiLyDAL()
    End Sub
    Public Sub New(connectionString As String)
        daiLyDAL = New HoSoDaiLyDAL(connectionString)
    End Sub
    Public Function insert(daiLy As HoSoDaiLyDTO) As Result
        '1. verify data here!!

        Return daiLyDAL.insert(daiLy)


        Return New Result(False)
    End Function
    Public Function buildMaDaiLy(ByRef nextMaDaiLy As Integer) As Result
        Return daiLyDAL.buildMaDaiLy(nextMaDaiLy)
    End Function
End Class
