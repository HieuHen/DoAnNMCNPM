Imports System.Configuration
Imports System.Data.SqlClient
Imports QLDLBUS
Imports QLDLDTO
Imports Utility

Public Class frmQLMatHang
    Private mhBus As MatHangBUS
    Private Sub frmQLMatHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mhBus = New MatHangBUS()


        loadListMatHang()
        TBMMH.Enabled = False

    End Sub



    Private Sub BTCapnhat_Click(sender As Object, e As EventArgs) Handles BTCapnhat.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListMH.CurrentCellAddress.Y 'current row selected
        'Verify that indexing OK
        If (-2 < currentRowIndex And currentRowIndex < dgvListMH.RowCount) Then
            Try
                Dim MatHang As MatHangDTO
                MatHang = New MatHangDTO()

                '1. Mapping data from GUI control


                MatHang.MaMatHang = TBMMH.Text
                MatHang.TenMatHang = TBTMH.Text
                MatHang.SoLuongTon = TBSLT.Text




                '3. Insert to DB
                Dim result As Result
                result = mhBus.update(MatHang)
                If (result.FlagResult = True) Then
                    ' Re-Load HocSinh list
                    'loadListMatHang(TBMMH.Text)
                    ' Hightlight the row has been updated on table
                    dgvListMH.Rows(currentRowIndex).Selected = True

                    MessageBox.Show("Cập nhật Mặt Hàng thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Cập nhật Mặt Hàng không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Console.WriteLine(result.SystemMessage)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub
    Private Sub loadListMatHang()
        Dim listMatHang = New List(Of MatHangDTO)
        Dim result As Result
        result = mhBus.selectAll(listMatHang)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Mặt Hàng  không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        'dgvListHS.SuspendLayout()
        dgvListMH.Columns.Clear()
        dgvListMH.DataSource = Nothing

        dgvListMH.AutoGenerateColumns = False
        dgvListMH.AllowUserToAddRows = False
        dgvListMH.DataSource = listMatHang

        Dim clMaMH = New DataGridViewTextBoxColumn()
        clMaMH.Name = "MaMatHang"
        clMaMH.HeaderText = "Mã Mặt Hàng"
        clMaMH.DataPropertyName = "MaMatHang"
        dgvListMH.Columns.Add(clMaMH)


        Dim clTenMH = New DataGridViewTextBoxColumn()
        clTenMH.Name = "TenMatHang"
        clTenMH.HeaderText = "Tên Mặt Hàng "
        clTenMH.DataPropertyName = "TenMatHang"
        dgvListMH.Columns.Add(clTenMH)

        Dim clSoLuongTon = New DataGridViewTextBoxColumn()
        clSoLuongTon.Name = "SoLuongTon"
        clSoLuongTon.HeaderText = "Số Lượng Tốn"
        clSoLuongTon.DataPropertyName = "SoLuongTon"
        dgvListMH.Columns.Add(clSoLuongTon)
    End Sub
    Private Sub loadListMatHang(maMatHang As String)
        Dim listMatHang = New List(Of MatHangDTO)
        Dim result As Result
        result = mhBus.selectALL_ByMaMatHang(maMatHang, listMatHang)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách mặt hàng theo loại không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        'dgvListHS.SuspendLayout()
        dgvListMH.Columns.Clear()
        dgvListMH.DataSource = Nothing

        dgvListMH.AutoGenerateColumns = False
        dgvListMH.AllowUserToAddRows = False
        dgvListMH.DataSource = listMatHang

        Dim clMaMH = New DataGridViewTextBoxColumn()
        clMaMH.Name = "MaMatHang"
        clMaMH.HeaderText = "Mã Mặt Hàng"
        clMaMH.DataPropertyName = "MaMatHang"
        dgvListMH.Columns.Add(clMaMH)


        Dim clTenMH = New DataGridViewTextBoxColumn()
        clTenMH.Name = "TenMatHang"
        clTenMH.HeaderText = "Tên Mặt Hàng "
        clTenMH.DataPropertyName = "TenMatHang"
        dgvListMH.Columns.Add(clTenMH)

        Dim clSoLuongTon = New DataGridViewTextBoxColumn()
        clSoLuongTon.Name = "SoLuongTon"
        clSoLuongTon.HeaderText = "Số Lượng Tốn"
        clSoLuongTon.DataPropertyName = "SoLuongTon"
        dgvListMH.Columns.Add(clSoLuongTon)
    End Sub

    Private Sub BTXoa_Click(sender As Object, e As EventArgs) Handles BTXoa.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListMH.CurrentCellAddress.Y 'current row selected


        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvListMH.RowCount) Then
            Select Case MsgBox("Bạn có thực sự muốn xóa mặt hàng có mã số: " + TBMMH.Text, MsgBoxStyle.YesNo, "Information")
                Case MsgBoxResult.Yes
                    Try
                        '1. Delete from DB
                        Dim result As Result
                        result = mhBus.delete(TBMMH.Text)
                        If (result.FlagResult = True) Then

                            ' Re-Load LoaiHocSinh list
                            'loadListMatHang(TBMMH.Text)

                            ' Hightlight the next row on table
                            If (currentRowIndex >= dgvListMH.Rows.Count) Then
                                currentRowIndex = currentRowIndex - 1
                            End If
                            If (currentRowIndex >= 0) Then
                                dgvListMH.Rows(currentRowIndex).Selected = True
                            End If

                            MessageBox.Show("Xóa Mặt Hàng thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Xóa Mặt Hàng không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Private Sub dgvListMH_SelectionChanged(sender As Object, e As EventArgs) Handles dgvListMH.SelectionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvListMH.CurrentCellAddress.Y 'current row selected

        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK

        If (-1 < currentRowIndex And currentRowIndex < dgvListMH.RowCount) Then
            Try
                Dim mh = CType(dgvListMH.Rows(currentRowIndex).DataBoundItem, MatHangDTO)
                TBMMH.Text = mh.MaMatHang
                TBTMH.Text = mh.TenMatHang
                TBSLT.Text = mh.SoLuongTon



            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub dgvListMH_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListMH.CellContentClick

    End Sub
End Class