<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMatHang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBTMH = New System.Windows.Forms.TextBox()
        Me.TBSLT = New System.Windows.Forms.TextBox()
        Me.BTNhap = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBMMH = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(152, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tên Mặt Hàng"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(152, 213)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Số Lượng Tồn"
        '
        'TBTMH
        '
        Me.TBTMH.Location = New System.Drawing.Point(277, 135)
        Me.TBTMH.Name = "TBTMH"
        Me.TBTMH.Size = New System.Drawing.Size(333, 22)
        Me.TBTMH.TabIndex = 1
        '
        'TBSLT
        '
        Me.TBSLT.Location = New System.Drawing.Point(277, 208)
        Me.TBSLT.Name = "TBSLT"
        Me.TBSLT.Size = New System.Drawing.Size(333, 22)
        Me.TBSLT.TabIndex = 2
        '
        'BTNhap
        '
        Me.BTNhap.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNhap.Location = New System.Drawing.Point(358, 301)
        Me.BTNhap.Name = "BTNhap"
        Me.BTNhap.Size = New System.Drawing.Size(140, 54)
        Me.BTNhap.TabIndex = 3
        Me.BTNhap.Text = "Nhập"
        Me.BTNhap.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(152, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Mã Mặt Hàng"
        '
        'TBMMH
        '
        Me.TBMMH.Location = New System.Drawing.Point(277, 65)
        Me.TBMMH.Name = "TBMMH"
        Me.TBMMH.Size = New System.Drawing.Size(333, 22)
        Me.TBMMH.TabIndex = 4
        '
        'frmMatHang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TBMMH)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTNhap)
        Me.Controls.Add(Me.TBSLT)
        Me.Controls.Add(Me.TBTMH)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmMatHang"
        Me.Text = "frmMatHang"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TBTMH As TextBox
    Friend WithEvents TBSLT As TextBox
    Friend WithEvents BTNhap As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TBMMH As TextBox
End Class
