Public Class frmMain
    Private Sub TiếpNhậnĐạiLýToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiếpNhậnĐạiLýToolStripMenuItem.Click
        Dim frmTNDL As frmTiepNhanDaiLy = New frmTiepNhanDaiLy()
        frmTNDL.MdiParent = Me
        frmTNDL.Show()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CậpNhậtXóaĐạiLýToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CậpNhậtXóaĐạiLýToolStripMenuItem.Click
        Dim frm As frmQLDaiLy = New frmQLDaiLy()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ThêmMặtHàngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmMặtHàngToolStripMenuItem.Click
        Dim frm As frmMatHang = New frmMatHang()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CậpXóaMặtHàngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CậpXóaMặtHàngToolStripMenuItem.Click
        Dim frm As frmQLMatHang = New frmQLMatHang()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ThêmQuậnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmQuậnToolStripMenuItem.Click
        Dim frm As frmTiepNhanQuan = New frmTiepNhanQuan()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CậpNhậtXóaQuậnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CậpNhậtXóaQuậnToolStripMenuItem.Click
        Dim frm As frmQLQuan = New frmQLQuan()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ThêmLoạiĐạiLyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmLoạiĐạiLyToolStripMenuItem.Click
        Dim frm As frmTiepNhanLoaiDaiLy = New frmTiepNhanLoaiDaiLy()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CậpNhậtXóaLoạiĐạiLýToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CậpNhậtXóaLoạiĐạiLýToolStripMenuItem.Click
        Dim frm As frmQLLoaiDaiLy = New frmQLLoaiDaiLy()
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class
