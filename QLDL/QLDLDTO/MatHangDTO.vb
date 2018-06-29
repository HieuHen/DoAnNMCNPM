Public Class MatHangDTO
    Private iMaMatHang As Integer
    Private strTenMatHang As String
    Private iSoLuonTon As Integer
    Public Sub New()
    End Sub
    Public Sub New(iMaMatHang As Integer, strTenMatHang As String, iSoLuongTon As Integer)
        Me.iMaMatHang = iMaMatHang
        Me.strTenMatHang = strTenMatHang
        Me.iSoLuonTon = iSoLuongTon
    End Sub
    Public Property MaMatHang As Integer
        Get
            Return iMaMatHang
        End Get
        Set(value As Integer)
            iMaMatHang = value
        End Set
    End Property
    Public Property TenMatHang As String
        Get
            Return strTenMatHang
        End Get
        Set(value As String)
            strTenMatHang = value
        End Set
    End Property
    Public Property SoLuongTon As Integer
        Get
            Return iSoLuonTon
        End Get
        Set(value As Integer)
            iSoLuonTon = value
        End Set
    End Property

End Class
