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

    Public Function selectAll(ByRef listLoaiDaiLy As List(Of LoaiDaiLyDTO)) As Result

        Return loaiDaiLyDAL.selectALL(listLoaiDaiLy)
    End Function
End Class
