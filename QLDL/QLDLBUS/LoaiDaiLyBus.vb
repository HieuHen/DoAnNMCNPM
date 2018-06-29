Imports QLDLDAL
Imports QLDLDTO
Imports Utility



Public Class LoaiDaiLyBus
    Private loaiDaiLyDAL As LoaiDaiLyDAL
    Public Sub New()
        loaiDaiLyDAL = New LoaiDaiLyDAL()
    End Sub
    Public Sub New(connectionString As String)
        loaiDaiLyDAL = New LoaiDaiLyDAL(connectionString)
    End Sub
    Public Function insert(LoaiDaiLy As LoaiDaiLyDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return loaiDaiLyDAL.insert(LoaiDaiLy)
        Return New Result(False)

    End Function
    Public Function update(LoaiDaiLy As LoaiDaiLyDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return loaiDaiLyDAL.update(LoaiDaiLy)
    End Function
    Public Function delete(LoaiDaiLy As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return loaiDaiLyDAL.delete(LoaiDaiLy)
    End Function
    Public Function selectAll(ByRef listLoaiDaiLy As List(Of LoaiDaiLyDTO)) As Result

        Return loaiDaiLyDAL.selectALL(listLoaiDaiLy)
    End Function
    Public Function selectALL_ByMaLoaiDaiLy(iMaLoaiDaiLy As Integer, ByRef listMaLoaiDaiLy As List(Of LoaiDaiLyDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return loaiDaiLyDAL.selectALL_ByMaLoaiDaiLy(iMaLoaiDaiLy, listMaLoaiDaiLy)
    End Function
    Public Function buildMaLoaiDaiLy(ByRef nextMaLoaiDaiLy As Integer) As Result
        Return loaiDaiLyDAL.buildMaLoaiDaiLy(nextMaLoaiDaiLy)
    End Function
End Class
