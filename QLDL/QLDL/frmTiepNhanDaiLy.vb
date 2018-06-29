Imports QLDLBUS
Imports QLDLDTO
Imports Utility



Public Class frmTiepNhanDaiLy
    Private hoSoDaiLyBus As HoSoDaiLyBUS
    Private loaiDaiLyBus As LoaiDaiLyBus
    Private quanBus As QuanBUS

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Dim DaiLy As HoSoDaiLyDTO
        DaiLy = New HoSoDaiLyDTO

        DaiLy.TenDaiLy = tbTen.Text
        DaiLy.DiaChi = tbDiaChi.Text
        DaiLy.Email = tbEmail.Text
        DaiLy.NgayTiepNhan = dtpNgayTiepNhan.Value
        DaiLy.MaQuan = Convert.ToInt32(cbQuan.SelectedValue)
        DaiLy.MaLoaiDaiLy = Convert.ToInt32(cbLoaiDaiLy.SelectedValue)
        DaiLy.DienThoai = tbDienThoai.Text
        DaiLy.NoCuaDaiLy = TBNDL.Text
        Dim result As Result
        result = hoSoDaiLyBus.insert(DaiLy)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm đại lý thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Thêm đại lý không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If


    End Sub

    Private Sub frmTiepNhanDaiLy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hoSoDaiLyBus = New HoSoDaiLyBUS
        loaiDaiLyBus = New LoaiDaiLyBus
        quanBus = New QuanBUS
        Dim result As Result
        'load danh sach loaiDaiLy
        Dim listLoaiDaiLy = New List(Of LoaiDaiLyDTO)
        result = loaiDaiLyBus.selectAll(listLoaiDaiLy)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Loại đại lý không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Close()
            Return
        End If
        cbLoaiDaiLy.DataSource = New BindingSource(listLoaiDaiLy, String.Empty)
        cbLoaiDaiLy.DisplayMember = "TenLoaiDaiLy"
        cbLoaiDaiLy.ValueMember = "MaLoaiDaiLy"
        'load danh sach quan hợp lệ
        Dim listQuan = New List(Of QuanDTO)
        result = quanBus.selectAvailableQuan(listQuan)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách quận không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Close()
            Return
        End If
        cbQuan.DataSource = New BindingSource(listQuan, String.Empty)
        cbQuan.DisplayMember = "TenQuan"
        cbQuan.ValueMember = "MaQuan"
        Dim nextMaDaiLy = "1"
        result = hoSoDaiLyBus.buildMaDaiLy(nextMaDaiLy)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh tự động mã Đại Lý không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        TBMDL.Text = nextMaDaiLy
        TBMDL.Enabled = False


    End Sub

    Private Sub cbLoaiDaiLy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLoaiDaiLy.SelectedIndexChanged

    End Sub
End Class