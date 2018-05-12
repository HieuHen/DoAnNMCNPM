Imports QLDLDAL
Imports QLDLDTO
Imports Utility

Public Class QuanBUS
    Private quanDAL As QuanDAL
    Public Sub New()
        quanDAL = New QuanDAL()
    End Sub
    Public Sub New(connectionString As String)
        quanDAL = New QuanDAL(connectionString)
    End Sub

    Public Function selectAvailableQuan(ByRef listQuan As List(Of QuanDTO)) As Result

        Return quanDAL.selectAvailableQuan(listQuan)
    End Function
End Class
