Public Class frmMain
    Private Sub TiếpNhậnĐạiLýToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiếpNhậnĐạiLýToolStripMenuItem.Click
        Dim frmTNDL As frmTiepNhanDaiLy = New frmTiepNhanDaiLy()
        frmTNDL.MdiParent = Me
        frmTNDL.Show()
    End Sub
End Class
