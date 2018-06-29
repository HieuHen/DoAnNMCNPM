Imports QLDLBUS
Imports QLDLDTO
Imports Utility


Public Class frmTiepNhanQuan
    Private quanBus As QuanBUS
    Private Sub frmTiepNhanQuan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        quanBus = New QuanBUS()
        quanBus = New QuanBUS()

        ' Load LoaiHocSinh list
        Dim listQuan = New List(Of QuanDTO)
        Dim result As Result
        result = quanBus.selectAvailableQuan(listQuan)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Quận không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If

        'set MSSH auto
        Dim nextMaQuan = "1"
        result = quanBus.buildMaQuan(nextMaQuan)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh tự động mã Quận không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        TBMQ.Text = nextMaQuan
        TBMQ.Enabled = False
    End Sub

    Private Sub TBNhap_Click(sender As Object, e As EventArgs) Handles TBNhap.Click
        quanBus = New QuanBUS()
        Dim Quan As QuanDTO
        Quan = New QuanDTO


        Quan.TenQuan = TBTQ.Text
        Quan.SoLuongDaiLyToida = TBSLDLTD.Text

        Dim result As Result
        result = quanBus.insert(Quan)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Quận thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Thêm Quận không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If

    End Sub
End Class