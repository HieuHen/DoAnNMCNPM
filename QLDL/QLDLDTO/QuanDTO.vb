Public Class QuanDTO
    Private iMaQuan As Integer
    Private strTenQuan As String
    Private iSoLuongDaiLyToiDa As Integer

    Public Sub New(iMaQuan As Integer, strTenQuan As String, iSoLuongDaiLyToiDa As Integer)
        Me.iMaQuan = iMaQuan
        Me.strTenQuan = strTenQuan
        Me.iSoLuongDaiLyToiDa = iSoLuongDaiLyToiDa

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

    Public Property SoLuongDaiLyToiDa As Integer
        Get
            Return iSoLuongDaiLyToiDa
        End Get
        Set(value As Integer)
            iSoLuongDaiLyToiDa = value
        End Set
    End Property

    Public Sub New()
    End Sub

End Class
