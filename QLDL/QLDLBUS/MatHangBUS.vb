Imports QLDLDAL
Imports QLDLDTO
Imports Utility

Public Class MatHangBUS
    Private MatHangDAL As MatHangDAL
    Public Sub New()
        MatHangDAL = New MatHangDAL()
    End Sub
    Public Sub New(connectionString As String)
        MatHangDAL = New MatHangDAL(connectionString)
    End Sub
    Public Function insert(MatHang As MatHangDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return MatHangDAL.insert(MatHang)
        Return New Result(False)

    End Function
    Public Function update(MatHang As MatHangDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return MatHangDAL.update(MatHang)
    End Function
    Public Function delete(MatHang As Integer) As Result
        '1. verify data here!!

        '2. insert to DB
        Return MatHangDAL.delete(MatHang)
    End Function
    Public Function selectAll(ByRef listMatHang As List(Of MatHangDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return MatHangDAL.selectALL(listMatHang)
    End Function
    Public Function selectALL_ByMaMatHang(iMaMatHang As Integer, ByRef listMatHang As List(Of MatHangDTO)) As Result
        '1. verify data here!!

        '2. insert to DB
        Return MatHangDAL.selectALL_ByMaMatHang(iMaMatHang, listMatHang)
    End Function
    Public Function buildMaMatHang(ByRef nextMaMatHang As Integer) As Result
        Return MatHangDAL.buildMaMatHang(nextMaMatHang)
    End Function
End Class
