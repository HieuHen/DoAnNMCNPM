Imports System.Configuration
Imports QLDLBUS
Imports QLDLDTO
Imports Utility



Public Class frmQLDaiLy
    Private dlBus As HoSoDaiLyBUS
    Private ldlBus As LoaiDaiLyBus
    Private lqBus As QuanBUS




    Private Sub BTCapNhat_Click(sender As Object, e As EventArgs) Handles BTCapNhat.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListDL.CurrentCellAddress.Y 'current row selected
        'Verify that indexing OK
        If (-2 < currentRowIndex And currentRowIndex < dgvListDL.RowCount) Then
            Try
                Dim DaiLy As HoSoDaiLyDTO
                DaiLy = New HoSoDaiLyDTO()

                '1. Mapping data from GUI control


                DaiLy.MaDaiLy = TBMaDL.Text
                DaiLy.TenDaiLy = TBTenDL.Text
                DaiLy.DiaChi = TBDiaChi.Text
                DaiLy.NgayTiepNhan = DateTimeNgayTN.Value
                DaiLy.Email = TBEmail.Text
                DaiLy.DienThoai = TBDienThoai.Text
                DaiLy.NoCuaDaiLy = TBNoCuaDL.Text
                DaiLy.MaLoaiDaiLy = Convert.ToInt32(CBMĐLCapNhat.SelectedValue)
                DaiLy.MaQuan = Convert.ToInt32(CBQuan.SelectedValue)



                '3. Insert to DB
                Dim result As Result
                result = dlBus.update(DaiLy)
                If (result.FlagResult = True) Then
                    ' Re-Load HocSinh list
                    loadListDaiLy(CBMLĐL.SelectedValue)
                    ' Hightlight the row has been updated on table
                    dgvListDL.Rows(currentRowIndex).Selected = True

                    MessageBox.Show("Cập nhật Đại Lý thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật Đại Lý không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub
    Private Sub BTXoa_Click(sender As Object, e As EventArgs) Handles BTXoa.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListDL.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-2 < currentRowIndex And currentRowIndex < dgvListDL.RowCount) Then
            Select Case MsgBox("Bạn có thực sự muốn xóa Đại lý có mã số: " + TBMaDL.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try
                        '1. Delete from DB
                        Dim result As Result
                        result = dlBus.delete(TBMaDL.Text)
                        If (result.FlagResult = True) Then

                            ' Re-Load LoaiHocSinh list
                            'loadListDaiLy(CBMLĐL.SelectedValue)

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvListDL.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvListDL.Rows(currentRowIndex).Selected = True
                            End If

                            MessageBox.Show("Xóa Đại Lý thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa Đại Lý không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            System.Console.WriteLine(result.SystemMessage)
                        End If
                    Catch ex As Exception
                        Console.WriteLine(ex.StackTrace)
                    End Try
                Case MsgBoxResult.No
                    Return
            End Select


        End If
    End Sub

    Private Sub frmQLDaiLy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dlBus = New HoSoDaiLyBUS()
        ldlBus = New LoaiDaiLyBus()
        lqBus = New QuanBUS()
        TBMaDL.Enabled = False
        ' Load LoaiHocSinh list
        Dim listLoaiDaiLy = New List(Of LoaiDaiLyDTO)
        Dim result As Result
        result = ldlBus.selectAll(listLoaiDaiLy)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách loại Đại Lý không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        CBMLĐL.DataSource = New BindingSource(listLoaiDaiLy, String.Empty)
        CBMLĐL.DisplayMember = "TenLoaiDaiLy"
        CBMLĐL.ValueMember = "MaLoaiDaiLy"


        CBMĐLCapNhat.DataSource = New BindingSource(listLoaiDaiLy, String.Empty)
        CBMĐLCapNhat.DisplayMember = "TenLoaiDaiLy"
        CBMĐLCapNhat.ValueMember = "MaLoaiDaiLy"



        Dim listQuan = New List(Of QuanDTO)
        result = lqBus.selectALL(listQuan)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách quận không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        CBQuan.DataSource = New BindingSource(listQuan, String.Empty)
        CBQuan.DisplayMember = "TenQuan"
        CBQuan.ValueMember = "MaQuan"


        Dim nextDaiLy = "1"
        result = dlBus.buildMaDaiLy(nextDaiLy)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh tự động mã Đại Lý không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        TBMaDL.Text = nextDaiLy
    End Sub
    Private Sub loadListDaiLy()
        Dim listDaiLy = New List(Of HoSoDaiLyDTO)
        Dim result As Result
        result = dlBus.selectAll(listDaiLy)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Đại Lý  không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        'dgvListHS.SuspendLayout()
        dgvListDL.Columns.Clear()
        dgvListDL.DataSource = Nothing

        dgvListDL.AutoGenerateColumns = False
        dgvListDL.AllowUserToAddRows = False
        dgvListDL.DataSource = listDaiLy

        Dim clMaDL = New DataGridViewTextBoxColumn()
        clMaDL.Name = "MaDaiLy"
        clMaDL.HeaderText = "Mã Đại Lý"
        clMaDL.DataPropertyName = "MaDaiLy"
        dgvListDL.Columns.Add(clMaDL)

        Dim clLoaiDL = New DataGridView()
        'clLoaiHS.Name = "LoaiHS"
        'clLoaiHS.HeaderText = "Tên Loại"
        'clLoaiHS.DataPropertyName = "LoaiHS"
        'dgvListHS.Columns.Add(clLoaiHS)

        Dim clTenDaiLy = New DataGridViewTextBoxColumn()
        clTenDaiLy.Name = "TenDaiLy"
        clTenDaiLy.HeaderText = "Tên Đại Lý"
        clTenDaiLy.DataPropertyName = "TenDaiLy"
        dgvListDL.Columns.Add(clTenDaiLy)

        Dim clDiaChi = New DataGridViewTextBoxColumn()
        clDiaChi.Name = "DiaChi"
        clDiaChi.HeaderText = "Địa Chỉ"
        clDiaChi.DataPropertyName = "DiaChi"
        dgvListDL.Columns.Add(clDiaChi)

        Dim clNgayTiepNhan = New DataGridViewTextBoxColumn()
        clNgayTiepNhan.Name = "NgayTiepNhan"
        clNgayTiepNhan.HeaderText = "Ngày Tiếp Nhận"
        clNgayTiepNhan.DataPropertyName = "NgayTiepNhan"
        dgvListDL.Columns.Add(clNgayTiepNhan)
        'dgvListHS.ResumeLayout()

        Dim clEmailDL = New DataGridViewTextBoxColumn()
        clEmailDL.Name = "Email"
        clEmailDL.HeaderText = "Email"
        clEmailDL.DataPropertyName = "Email"
        dgvListDL.Columns.Add(clEmailDL)

        Dim clDienThoalDL = New DataGridViewTextBoxColumn()
        clDienThoalDL.Name = "DienThoai"
        clDienThoalDL.HeaderText = "Điện Thoại"
        clDienThoalDL.DataPropertyName = "DienThoai"
        dgvListDL.Columns.Add(clDienThoalDL)


        Dim clNoCuaDL = New DataGridViewTextBoxColumn()
        clNoCuaDL.Name = "NoCuaDaiLy"
        clNoCuaDL.HeaderText = "Nợ của Đại Lý"
        clNoCuaDL.DataPropertyName = "NoCuaDaiLy"
        dgvListDL.Columns.Add(clNoCuaDL)

    End Sub


    Private Sub loadListDaiLy(maDaiLy As String)
        Dim listDaiLy = New List(Of HoSoDaiLyDTO)
        Dim result As Result
        result = dlBus.selectALL_ByType(maDaiLy, listDaiLy)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Đại Lý theo loại không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        'dgvListHS.SuspendLayout()
        dgvListDL.Columns.Clear()
        dgvListDL.DataSource = Nothing

        dgvListDL.AutoGenerateColumns = False
        dgvListDL.AllowUserToAddRows = False
        dgvListDL.DataSource = listDaiLy

        Dim clMaDaiLy = New DataGridViewTextBoxColumn()
        clMaDaiLy.Name = "MaDaiLy"
        clMaDaiLy.HeaderText = "Mã Đại Lý"
        clMaDaiLy.DataPropertyName = "MaDaiLy"
        dgvListDL.Columns.Add(clMaDaiLy)

        Dim clQuan = New DataGridViewTextBoxColumn()
        clQuan.Name = "MaQuan"
        clQuan.HeaderText = "Quận"
        clQuan.DataPropertyName = "MaQuan"
        dgvListDL.Columns.Add(clQuan)

        Dim clTenDaiLy = New DataGridViewTextBoxColumn()
        clTenDaiLy.Name = "TenDaiLy"
        clTenDaiLy.HeaderText = "Tên Đại Lý"
        clTenDaiLy.DataPropertyName = "TenDaiLy"
        dgvListDL.Columns.Add(clTenDaiLy)

        Dim clDiaChi = New DataGridViewTextBoxColumn()
        clDiaChi.Name = "DiaChi"
        clDiaChi.HeaderText = "Địa Chỉ"
        clDiaChi.DataPropertyName = "DiaChi"
        dgvListDL.Columns.Add(clDiaChi)

        Dim clNgayTiepNhan = New DataGridViewTextBoxColumn()
        clNgayTiepNhan.Name = "NgayTiepNhan"
        clNgayTiepNhan.HeaderText = "Ngày Tiếp Nhận"
        clNgayTiepNhan.DataPropertyName = "NgayTiepNhan"
        dgvListDL.Columns.Add(clNgayTiepNhan)
        'dgvListHS.ResumeLayout()

        Dim clEmailDL = New DataGridViewTextBoxColumn()
        clEmailDL.Name = "Email"
        clEmailDL.HeaderText = "Email"
        clEmailDL.DataPropertyName = "Email"
        dgvListDL.Columns.Add(clEmailDL)

        Dim clDienThoalDL = New DataGridViewTextBoxColumn()
        clDienThoalDL.Name = "DienThoai"
        clDienThoalDL.HeaderText = "Điện Thoại"
        clDienThoalDL.DataPropertyName = "DienThoai"
        dgvListDL.Columns.Add(clDienThoalDL)


        Dim clNoCuaDL = New DataGridViewTextBoxColumn()
        clNoCuaDL.Name = "NoCuaDaiLy"
        clNoCuaDL.HeaderText = "Nợ của Đại Lý"
        clNoCuaDL.DataPropertyName = "NoCuaDaiLy"
        dgvListDL.Columns.Add(clNoCuaDL)
    End Sub

    Private Sub CBMLĐL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBMLĐL.SelectedIndexChanged
        Try
            Dim maLoaiDaiLy = CBMLĐL.SelectedValue
            loadListDaiLy(maLoaiDaiLy)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CBQuan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBQuan.SelectedIndexChanged

    End Sub

    Private Sub dgvListDL_SELECTionChanged(sender As Object, e As EventArgs) Handles dgvListDL.SelectionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListDL.CurrentCellAddress.Y 'current row selected

        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListDL.RowCount) Then
            Try
                Dim dl = CType(dgvListDL.Rows(currentRowIndex).DataBoundItem, HoSoDaiLyDTO)
                TBMaDL.Text = dl.MaDaiLy
                TBTenDL.Text = dl.TenDaiLy
                TBDiaChi.Text = dl.DiaChi
                DateTimeNgayTN.Value = dl.NgayTiepNhan
                TBDienThoai.Text = dl.DienThoai
                TBEmail.Text = dl.Email
                TBNoCuaDL.Text = dl.NoCuaDaiLy
                CBQuan.SelectedValue = dl.MaQuan
                CBMĐLCapNhat.SelectedIndex = CBMLĐL.SelectedIndex


            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub



    Private Sub dgvListDL_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListDL.CellContentClick

    End Sub


End Class