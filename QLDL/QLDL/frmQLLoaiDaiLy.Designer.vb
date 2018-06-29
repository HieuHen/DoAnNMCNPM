<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQLLoaiDaiLy
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
        Me.dgvLoaiDaiLy = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBMLDL = New System.Windows.Forms.TextBox()
        Me.TBTLDL = New System.Windows.Forms.TextBox()
        Me.TBNDL = New System.Windows.Forms.TextBox()
        Me.BTCapNhat = New System.Windows.Forms.Button()
        Me.BTXoa = New System.Windows.Forms.Button()
        CType(Me.dgvLoaiDaiLy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvLoaiDaiLy
        '
        Me.dgvLoaiDaiLy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLoaiDaiLy.Location = New System.Drawing.Point(133, 24)
        Me.dgvLoaiDaiLy.Name = "dgvLoaiDaiLy"
        Me.dgvLoaiDaiLy.RowTemplate.Height = 24
        Me.dgvLoaiDaiLy.Size = New System.Drawing.Size(502, 180)
        Me.dgvLoaiDaiLy.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(129, 237)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mã Loại Đại Lý"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(129, 286)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tên Loại Đại Lý"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(129, 329)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Nợ Tối Đa"
        '
        'TBMLDL
        '
        Me.TBMLDL.Location = New System.Drawing.Point(303, 235)
        Me.TBMLDL.Name = "TBMLDL"
        Me.TBMLDL.Size = New System.Drawing.Size(267, 22)
        Me.TBMLDL.TabIndex = 2
        '
        'TBTLDL
        '
        Me.TBTLDL.Location = New System.Drawing.Point(303, 284)
        Me.TBTLDL.Name = "TBTLDL"
        Me.TBTLDL.Size = New System.Drawing.Size(267, 22)
        Me.TBTLDL.TabIndex = 2
        '
        'TBNDL
        '
        Me.TBNDL.Location = New System.Drawing.Point(303, 327)
        Me.TBNDL.Name = "TBNDL"
        Me.TBNDL.Size = New System.Drawing.Size(267, 22)
        Me.TBNDL.TabIndex = 2
        '
        'BTCapNhat
        '
        Me.BTCapNhat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTCapNhat.Location = New System.Drawing.Point(195, 371)
        Me.BTCapNhat.Name = "BTCapNhat"
        Me.BTCapNhat.Size = New System.Drawing.Size(161, 55)
        Me.BTCapNhat.TabIndex = 3
        Me.BTCapNhat.Text = "Cập Nhật"
        Me.BTCapNhat.UseVisualStyleBackColor = True
        '
        'BTXoa
        '
        Me.BTXoa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTXoa.Location = New System.Drawing.Point(458, 371)
        Me.BTXoa.Name = "BTXoa"
        Me.BTXoa.Size = New System.Drawing.Size(161, 55)
        Me.BTXoa.TabIndex = 3
        Me.BTXoa.Text = "Xoá"
        Me.BTXoa.UseVisualStyleBackColor = True
        '
        'frmQLLoaiDaiLy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.BTXoa)
        Me.Controls.Add(Me.BTCapNhat)
        Me.Controls.Add(Me.TBNDL)
        Me.Controls.Add(Me.TBTLDL)
        Me.Controls.Add(Me.TBMLDL)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvLoaiDaiLy)
        Me.Name = "frmQLLoaiDaiLy"
        Me.Text = "frmQLLoaiDaiLy"
        CType(Me.dgvLoaiDaiLy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvLoaiDaiLy As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TBMLDL As TextBox
    Friend WithEvents TBTLDL As TextBox
    Friend WithEvents TBNDL As TextBox
    Friend WithEvents BTCapNhat As Button
    Friend WithEvents BTXoa As Button
End Class
