Imports System.Configuration
Imports System.Data.SqlClient
Imports QLDLBUS
Imports QLDLDTO
Imports Utility


Public Class frmQLLoaiDaiLy
    Private ldlBus As LoaiDaiLyBus
    Private Sub frmQLLoaiDaiLy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ldlBus = New LoaiDaiLyBus()


        loadListLoaiDaiLy()
        TBMLDL.Enabled = False
    End Sub
    Private Sub loadListLoaiDaiLy()
        Dim listLoaiDaiLy = New List(Of LoaiDaiLyDTO)
        Dim result As Result
        result = ldlBus.selectAll(listLoaiDaiLy)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Loại Đại Lý  không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        'dgvListHS.SuspendLayout()
        dgvLoaiDaiLy.Columns.Clear()
        dgvLoaiDaiLy.DataSource = Nothing

        dgvLoaiDaiLy.AutoGenerateColumns = False
        dgvLoaiDaiLy.AllowUserToAddRows = False
        dgvLoaiDaiLy.DataSource = listLoaiDaiLy

        Dim clMaLoaiDaiLy = New DataGridViewTextBoxColumn()
        clMaLoaiDaiLy.Name = "MaLoaiDaiLy"
        clMaLoaiDaiLy.HeaderText = "Mã Loại Đại Lý"
        clMaLoaiDaiLy.DataPropertyName = "MaLoaiDaiLy"
        dgvLoaiDaiLy.Columns.Add(clMaLoaiDaiLy)


        Dim clTenLoaiDaiLy = New DataGridViewTextBoxColumn()
        clTenLoaiDaiLy.Name = "TenLoaiDaiLy"
        clTenLoaiDaiLy.HeaderText = "Tên Loại Đại Lý"
        clTenLoaiDaiLy.DataPropertyName = "TenLoaiDaiLy"
        dgvLoaiDaiLy.Columns.Add(clTenLoaiDaiLy)

        Dim clNoToiDa = New DataGridViewTextBoxColumn()
        clNoToiDa.Name = "NoToiDa"
        clNoToiDa.HeaderText = "Nợ Tối Đa"
        clNoToiDa.DataPropertyName = "NoToiDa"
        dgvLoaiDaiLy.Columns.Add(clNoToiDa)
    End Sub
    Private Sub loadListLoaiDaiLy(maLoaiDaiLy As String)
        Dim listLoaiDaiLy = New List(Of LoaiDaiLyDTO)
        Dim result As Result
        result = ldlBus.selectALL_ByMaLoaiDaiLy(maLoaiDaiLy, listLoaiDaiLy)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Loại Đại lý theo loại không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        'dgvListHS.SuspendLayout()
        dgvLoaiDaiLy.Columns.Clear()
        dgvLoaiDaiLy.DataSource = Nothing

        dgvLoaiDaiLy.AutoGenerateColumns = False
        dgvLoaiDaiLy.AllowUserToAddRows = False
        dgvLoaiDaiLy.DataSource = listLoaiDaiLy

        Dim clMaLoaiDaiLy = New DataGridViewTextBoxColumn()
        clMaLoaiDaiLy.Name = "MaLoaiDaiLy"
        clMaLoaiDaiLy.HeaderText = "Mã Loại Đại Lý"
        clMaLoaiDaiLy.DataPropertyName = "MaLoaiDaiLy"
        dgvLoaiDaiLy.Columns.Add(clMaLoaiDaiLy)


        Dim clTenLoaiDaiLy = New DataGridViewTextBoxColumn()
        clTenLoaiDaiLy.Name = "TenLoaiDaiLy"
        clTenLoaiDaiLy.HeaderText = "Tên Loại Đại Lý"
        clTenLoaiDaiLy.DataPropertyName = "TenLoaiDaiLy"
        dgvLoaiDaiLy.Columns.Add(clTenLoaiDaiLy)

        Dim clNoToiDa = New DataGridViewTextBoxColumn()
        clNoToiDa.Name = "NoToiDa"
        clNoToiDa.HeaderText = "Nợ Tối Đa"
        clNoToiDa.DataPropertyName = "NoToiDa"
        dgvLoaiDaiLy.Columns.Add(clNoToiDa)
    End Sub

    Private Sub BTCapNhat_Click(sender As Object, e As EventArgs) Handles BTCapNhat.Click
        Dim currentRowIndex As Integer = dgvLoaiDaiLy.CurrentCellAddress.Y 'current row selected
        'Verify that indexing OK
        If (-2 < currentRowIndex And currentRowIndex < dgvLoaiDaiLy.RowCount) Then
            Try
                Dim LoaiDaiLy As LoaiDaiLyDTO
                LoaiDaiLy = New LoaiDaiLyDTO()

                '1. Mapping data from GUI control


                LoaiDaiLy.MaLoaiDaiLy = TBMLDL.Text
                LoaiDaiLy.TenLoaiDaiLy = TBTLDL.Text
                LoaiDaiLy.NoToiDa = TBNDL.Text




                '3. Insert to DB
                Dim result As Result
                result = ldlBus.update(LoaiDaiLy)
                If (result.FlagResult = True) Then
                    ' Re-Load HocSinh list
                    'loadListMatHang(TBMMH.Text)
                    ' Hightlight the row has been updated on table
                    dgvLoaiDaiLy.Rows(currentRowIndex).Selected = True

                    MessageBox.Show("Cập nhật Loại Đại Lý thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật Loại Đại Lý không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub BTXoa_Click(sender As Object, e As EventArgs) Handles BTXoa.Click
        Dim currentRowIndex As Integer = dgvLoaiDaiLy.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvLoaiDaiLy.RowCount) Then
            Select Case MsgBox("Bạn có thực sự muốn xóa mặt hàng có mã số: " + TBMLDL.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try
                        '1. Delete from DB
                        Dim result As Result
                        result = ldlBus.delete(TBMLDL.Text)
                        If (result.FlagResult = True) Then

                            ' Re-Load LoaiHocSinh list
                            'loadListMatHang(TBMMH.Text)

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvLoaiDaiLy.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvLoaiDaiLy.Rows(currentRowIndex).Selected = True
                            End If

                            MessageBox.Show("Xóa Loại Đại Lý thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa Loại Đại Lý không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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



    Private Sub dgvLoaiDaiLy_SelectionChanged(sender As Object, e As EventArgs) Handles dgvLoaiDaiLy.SelectionChanged
        Dim currentRowIndex As Integer = dgvLoaiDaiLy.CurrentCellAddress.Y 'current row selected

        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK

        If (-1 < currentRowIndex And currentRowIndex < dgvLoaiDaiLy.RowCount) Then
            Try
                Dim ldl = CType(dgvLoaiDaiLy.Rows(currentRowIndex).DataBoundItem, LoaiDaiLyDTO)
                TBMLDL.Text = ldl.MaLoaiDaiLy
                TBTLDL.Text = ldl.TenLoaiDaiLy
                TBNDL.Text = ldl.NoToiDa



            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub
End Class