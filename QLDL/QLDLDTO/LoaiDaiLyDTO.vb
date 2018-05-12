Public Class LoaiDaiLyDTO
    Private iMaLoaiDaiLy As Integer
    Private strTenLoaiDaiLy As String
    Public Sub New()
    End Sub
    Public Sub New(iMaLoaiDaiLy As Integer, strTenLoaiDaiLy As String)
        Me.iMaLoaiDaiLy = iMaLoaiDaiLy
        Me.strTenLoaiDaiLy = strTenLoaiDaiLy
    End Sub
    Public Property MaLoaiDaiLy As Integer
        Get
            Return iMaLoaiDaiLy
        End Get
        Set(value As Integer)
            iMaLoaiDaiLy = value
        End Set
    End Property

    Public Property TenLoaiDaiLy As String
        Get
            Return strTenLoaiDaiLy
        End Get
        Set(value As String)
            strTenLoaiDaiLy = value
        End Set
    End Property
End Class
