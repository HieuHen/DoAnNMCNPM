Public Class BaoCaoCongNoDTO
    Private iMaPhieuDCongNo As Integer
    Private iMaDaiLy As Integer
    Private dateThang As DateTime
    Private iNoDau As Integer
    Private iPhatSinh As Integer
    Private iNoCuoi As Integer
    Public Sub New()
    End Sub
    Public Sub New(iMaPhieuDCongNo As Integer, iMaDaiLy As Integer, dateThang As DateTime, iNoDau As Integer, iPhatSinh As Integer, iNoCuoi As Integer)
        Me.iMaPhieuDCongNo = iMaPhieuDCongNo
        Me.iMaDaiLy = iMaDaiLy
        Me.dateThang = dateThang
        Me.iNoDau = iNoDau
        Me.iPhatSinh = iPhatSinh
        Me.iNoCuoi = iNoCuoi
    End Sub
    Public Property MaPhieuDCongNo As Integer
        Get
            Return iMaPhieuDCongNo
        End Get
        Set(value As Integer)
            iMaPhieuDCongNo = value
        End Set
    End Property

    Public Property MaDaiLy As Integer
        Get
            Return iMaDaiLy
        End Get
        Set(value As Integer)
            iMaDaiLy = value
        End Set
    End Property

    Public Property Thang As Date
        Get
            Return dateThang
        End Get
        Set(value As Date)
            dateThang = value
        End Set
    End Property

    Public Property NoDau As Integer
        Get
            Return iNoDau
        End Get
        Set(value As Integer)
            iNoDau = value
        End Set
    End Property

    Public Property PhatSinh As Integer
        Get
            Return iPhatSinh
        End Get
        Set(value As Integer)
            iPhatSinh = value
        End Set
    End Property

    Public Property NoCuoi As Integer
        Get
            Return iNoCuoi
        End Get
        Set(value As Integer)
            iNoCuoi = value
        End Set
    End Property
End Class
