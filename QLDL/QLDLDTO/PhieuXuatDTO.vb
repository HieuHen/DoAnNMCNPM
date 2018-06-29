Public Class PhieuXuatDTO
    Private iMaPhieuXuat As Integer
    Private dateNgayLapPhieu As DateTime
    Public Sub New()
    End Sub
    Public Sub New(iMaPhieuXuat As Integer, dateNgayLapPhieu As DateTime)
        Me.iMaPhieuXuat = iMaPhieuXuat
        Me.dateNgayLapPhieu = dateNgayLapPhieu
    End Sub
    Public Property MaPhieuXuat As Integer
        Get
            Return iMaPhieuXuat
        End Get
        Set(value As Integer)
            iMaPhieuXuat = value
        End Set
    End Property
    Public Property NgayLapPhieu As Date
        Get
            Return dateNgayLapPhieu
        End Get
        Set(value As Date)
            dateNgayLapPhieu = value
        End Set
    End Property
End Class
