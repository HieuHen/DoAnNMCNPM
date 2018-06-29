Imports System.Configuration
Imports System.Data.SqlClient
Imports QLDLBUS
Imports QLDLDTO
Imports Utility
Public Class frmQLQuan
    Private quBus As QuanBUS

    Private Sub frmQLQuan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        quBus = New QuanBUS()


        loadListQuan()
        TBMQ.Enabled = False

    End Sub
    Private Sub loadListQuan()
        Dim listQuan = New List(Of QuanDTO)
        Dim result As Result
        result = quBus.selectALL(listQuan)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Quận  không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        'dgvListHS.SuspendLayout()
        dgvListQuan.Columns.Clear()
        dgvListQuan.DataSource = Nothing

        dgvListQuan.AutoGenerateColumns = False
        dgvListQuan.AllowUserToAddRows = False
        dgvListQuan.DataSource = listQuan

        Dim clMaQuan = New DataGridViewTextBoxColumn()
        clMaQuan.Name = "MaQuan"
        clMaQuan.HeaderText = "Mã Quận"
        clMaQuan.DataPropertyName = "MaQuan"
        dgvListQuan.Columns.Add(clMaQuan)


        Dim clTenQuan = New DataGridViewTextBoxColumn()
        clTenQuan.Name = "TenQuan"
        clTenQuan.HeaderText = "Tên Quận"
        clTenQuan.DataPropertyName = "TenQuan"
        dgvListQuan.Columns.Add(clTenQuan)

        Dim clSoLuongDaiLyToiDa = New DataGridViewTextBoxColumn()
        clSoLuongDaiLyToiDa.Name = "SoLuongDaiLyToiDa"
        clSoLuongDaiLyToiDa.HeaderText = "Số Lượng Đại Lý Tối Đa"
        clSoLuongDaiLyToiDa.DataPropertyName = "SoLuongDaiLyToiDa"
        dgvListQuan.Columns.Add(clSoLuongDaiLyToiDa)
    End Sub
    Private Sub loadListQuan(maQuan As String)
        Dim listQuan = New List(Of QuanDTO)
        Dim result As Result
        result = quBus.selectALL_ByMaQuan(maQuan, listQuan)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Quận theo loại không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        'dgvListHS.SuspendLayout()
        dgvListQuan.Columns.Clear()
        dgvListQuan.DataSource = Nothing

        dgvListQuan.AutoGenerateColumns = False
        dgvListQuan.AllowUserToAddRows = False
        dgvListQuan.DataSource = listQuan

        Dim clMaQuan = New DataGridViewTextBoxColumn()
        clMaQuan.Name = "MaQuan"
        clMaQuan.HeaderText = "Mã Quận"
        clMaQuan.DataPropertyName = "MaQuan"
        dgvListQuan.Columns.Add(clMaQuan)


        Dim clTenQuan = New DataGridViewTextBoxColumn()
        clTenQuan.Name = "TenQuan"
        clTenQuan.HeaderText = "Tên Quận"
        clTenQuan.DataPropertyName = "TenQuan"
        dgvListQuan.Columns.Add(clTenQuan)

        Dim clSoLuongDaiLyToiDa = New DataGridViewTextBoxColumn()
        clSoLuongDaiLyToiDa.Name = "SoLuongDaiLyToiDa"
        clSoLuongDaiLyToiDa.HeaderText = "Số Lượng Đại Lý Tối Đa"
        clSoLuongDaiLyToiDa.DataPropertyName = "SoLuongDaiLyToiDa"
        dgvListQuan.Columns.Add(clSoLuongDaiLyToiDa)
    End Sub

    Private Sub BTXoa_Click(sender As Object, e As EventArgs) Handles BTXoa.Click
        Dim currentRowIndex As Integer = dgvListQuan.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListQuan.RowCount) Then
            Select Case MsgBox("Bạn có thực sự muốn xóa mặt hàng có mã số: " + TBMQ.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try
                        '1. Delete from DB
                        Dim result As Result
                        result = quBus.delete(TBMQ.Text)
                        If (result.FlagResult = True) Then

                            ' Re-Load LoaiHocSinh list
                            'loadListMatHang(TBMMH.Text)

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvListQuan.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvListQuan.Rows(currentRowIndex).Selected = True
                            End If

                            MessageBox.Show("Xóa Quận thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa Quận không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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



    Private Sub dgvListQuan_SelectionChanged(sender As Object, e As EventArgs) Handles dgvListQuan.SelectionChanged
        Dim currentRowIndex As Integer = dgvListQuan.CurrentCellAddress.Y 'current row selected

        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK

        If (-1 < currentRowIndex And currentRowIndex < dgvListQuan.RowCount) Then
            Try
                Dim qu = CType(dgvListQuan.Rows(currentRowIndex).DataBoundItem, QuanDTO)
                TBMQ.Text = qu.MaQuan
                TBTQ.Text = qu.TenQuan
                TBSLDLTD.Text = qu.SoLuongDaiLyToida



            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If

    End Sub

    Private Sub BTCapNhat_Click(sender As Object, e As EventArgs) Handles BTCapNhat.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListQuan.CurrentCellAddress.Y 'current row selected
        'Verify that indexing OK
        If (-2 < currentRowIndex And currentRowIndex < dgvListQuan.RowCount) Then
            Try
                Dim Quan As QuanDTO
                Quan = New QuanDTO()

                '1. Mapping data from GUI control


                Quan.MaQuan = TBMQ.Text
                Quan.TenQuan = TBTQ.Text
                Quan.SoLuongDaiLyToida = TBSLDLTD.Text




                '3. Insert to DB
                Dim result As Result
                result = quBus.update(Quan)
                If (result.FlagResult = True) Then
                    ' Re-Load HocSinh list
                    'loadListMatHang(TBMMH.Text)
                    ' Hightlight the row has been updated on table
                    dgvListQuan.Rows(currentRowIndex).Selected = True

                    MessageBox.Show("Cập nhật Quận thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật Quận không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub
End Class