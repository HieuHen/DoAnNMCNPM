Public Class HoSoDaiLyDTO
    Private iMaDaiLy As Integer
    Private strTen As String
    Private iMaLoaiDaiLy As Integer
    Private strDienThoai As String
    Private strDiaChi As String
    Private iMaQuan As Integer
    Private dateNgayTiepNhan As DateTime
    Private strEmail As String

    Public Property MaDaiLy As Integer
        Get
            Return iMaDaiLy
        End Get
        Set(value As Integer)
            iMaDaiLy = value
        End Set
    End Property

    Public Property Ten As String
        Get
            Return strTen
        End Get
        Set(value As String)
            strTen = value
        End Set
    End Property

    Public Property MaLoaiDaiLy As Integer
        Get
            Return iMaLoaiDaiLy
        End Get
        Set(value As Integer)
            iMaLoaiDaiLy = value
        End Set
    End Property

    Public Property DienThoai As String
        Get
            Return strDienThoai
        End Get
        Set(value As String)
            strDienThoai = value
        End Set
    End Property

    Public Property DiaChi As String
        Get
            Return strDiaChi
        End Get
        Set(value As String)
            strDiaChi = value
        End Set
    End Property

    Public Property MaQuan As Integer
        Get
            Return iMaQuan
        End Get
        Set(value As Integer)
            iMaQuan = value
        End Set
    End Property

    Public Property NgayTiepNhan As Date
        Get
            Return dateNgayTiepNhan
        End Get
        Set(value As Date)
            dateNgayTiepNhan = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return strEmail
        End Get
        Set(value As String)
            strEmail = value
        End Set
    End Property
End Class
