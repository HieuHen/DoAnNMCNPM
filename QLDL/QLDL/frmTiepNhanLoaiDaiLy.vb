Imports QLDLBUS
Imports QLDLDTO
Imports Utility


Public Class frmTiepNhanLoaiDaiLy
    Private loaidailyBus As LoaiDaiLyBus
    Private Sub frmTiepNhanLoaiDaiLy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaidailyBus = New LoaiDaiLyBus()


        ' Load LoaiHocSinh list
        Dim listLoaiDaiLy = New List(Of LoaiDaiLyDTO)
        Dim result As Result
        result = loaidailyBus.selectAll(listLoaiDaiLy)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Loại Đại Lý không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If

        'set MSSH auto
        Dim nextMaLoaiDaiLy = "1"
        result = loaidailyBus.buildMaLoaiDaiLy(nextMaLoaiDaiLy)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh tự động mã Đại Lý không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        TBMLDL.Text = nextMaLoaiDaiLy
        TBMLDL.Enabled = False
    End Sub

    Private Sub BTNhap_Click(sender As Object, e As EventArgs) Handles BTNhap.Click
        loaidailyBus = New LoaiDaiLyBus()
        Dim LoaiDaiLy As LoaiDaiLyDTO
        LoaiDaiLy = New LoaiDaiLyDTO


        LoaiDaiLy.TenLoaiDaiLy = TBTLDL.Text
        LoaiDaiLy.NoToiDa = TBNDL.Text

        Dim result As Result
        result = loaidailyBus.insert(LoaiDaiLy)
        If (result.FlagResult = True) Then
            MessageBox.Show("Thêm Loại Đại Lý thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Thêm Loại Đại Lý không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub


End Class