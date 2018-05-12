Public Class QuanDTO
    Private iMaQuan As Integer
    Private strTenQuan As String
    Private iSoLuongDaiLyToida As Integer

    Public Sub New(iMaQuan As Integer, strTenQuan As String, iSoLuongDaiLyToida As Integer)
        Me.iMaQuan = iMaQuan
        Me.strTenQuan = strTenQuan
        Me.iSoLuongDaiLyToida = iSoLuongDaiLyToida
    End Sub

    Public Property MaQuan As Integer
        Get
            Return iMaQuan
        End Get
        Set(value As Integer)
            iMaQuan = value
        End Set
    End Property

    Public Property TenQuan As String
        Get
            Return strTenQuan
        End Get
        Set(value As String)
            strTenQuan = value
        End Set
    End Property

    Public Property SoLuongDaiLyToida As Integer
        Get
            Return iSoLuongDaiLyToida
        End Get
        Set(value As Integer)
            iSoLuongDaiLyToida = value
        End Set
    End Property

    Public Sub New()
    End Sub

End Class
