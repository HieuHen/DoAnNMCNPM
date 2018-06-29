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
    Public Function update(daily As HoSoDaiLyDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return daiLyDAL.update(daily)
    End Function
    Public Function delete(MaDaiLy As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return daiLyDAL.delete(MaDaiLy)
    End Function
    Public Function selectAll(ByRef listLoaiDaiLy As List(Of HoSoDaiLyDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return daiLyDAL.selectALL(listLoaiDaiLy)
    End Function
    Public Function selectALL_ByType(maLoaiDaiLy As Integer, ByRef listDL As List(Of HoSoDaiLyDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return daiLyDAL.selectALL_ByType(maLoaiDaiLy, listDL)
    End Function
    Public Function buildMaDaiLy(ByRef nextMaDaiLy As Integer) As Result
        Return daiLyDAL.buildMaDaiLy(nextMaDaiLy)
    End Function
End Class
