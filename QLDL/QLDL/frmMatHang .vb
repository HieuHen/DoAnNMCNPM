Imports QLDLBUS
Imports QLDLDTO
Imports Utility

Public Class frmMatHang
    Private mathangBus As MatHangBUS
    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmMatHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mathangBus = New MatHangBUS()
        mathangBus = New MatHangBUS()

        ' Load LoaiHocSinh list
        Dim listMatHang = New List(Of MatHangDTO)
        Dim result As Result
        result = mathangBus.selectAll(listMatHang)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách loại mặt hàng không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If

        'set MSSH auto
        Dim nextMatHang = "1"
        result = mathangBus.buildMaMatHang(nextMatHang)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh tự động mã Mặt hàng không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        TBMMH.Text = nextMatHang
        TBMMH.Enabled = False
    End Sub

    Private Sub BTNhap_Click(sender As Object, e As EventArgs) Handles BTNhap.Click
        mathangBus = New MatHangBUS()
        Dim MatHang As MatHangDTO
        MatHang = New MatHangDTO


        MatHang.TenMatHang = TBTMH.Text
        MatHang.SoLuongTon = TBSLT.Text

        Dim result As Result
        result = mathangBus.insert(MatHang)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Mặt Hàng thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Thêm Mặt Hàng không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If


    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TBMMH.TextChanged

    End Sub
End Class