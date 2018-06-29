<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQLMatHang
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBTMH = New System.Windows.Forms.TextBox()
        Me.TBSLT = New System.Windows.Forms.TextBox()
        Me.BTCapnhat = New System.Windows.Forms.Button()
        Me.BTXoa = New System.Windows.Forms.Button()
        Me.dgvListMH = New System.Windows.Forms.DataGridView()
        Me.TBMMH = New System.Windows.Forms.TextBox()
        CType(Me.dgvListMH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(205, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mã Mặt Hàng Cập Nhật"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(51, 287)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tên Mặt Hàng"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(51, 336)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Số Lượng Tồn"
        '
        'TBTMH
        '
        Me.TBTMH.Location = New System.Drawing.Point(335, 285)
        Me.TBTMH.Name = "TBTMH"
        Me.TBTMH.Size = New System.Drawing.Size(187, 22)
        Me.TBTMH.TabIndex = 2
        '
        'TBSLT
        '
        Me.TBSLT.Location = New System.Drawing.Point(335, 334)
        Me.TBSLT.Name = "TBSLT"
        Me.TBSLT.Size = New System.Drawing.Size(187, 22)
        Me.TBSLT.TabIndex = 3
        '
        'BTCapnhat
        '
        Me.BTCapnhat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTCapnhat.Location = New System.Drawing.Point(176, 385)
        Me.BTCapnhat.Name = "BTCapnhat"
        Me.BTCapnhat.Size = New System.Drawing.Size(135, 53)
        Me.BTCapnhat.TabIndex = 4
        Me.BTCapnhat.Text = "Cập Nhật"
        Me.BTCapnhat.UseVisualStyleBackColor = True
        '
        'BTXoa
        '
        Me.BTXoa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTXoa.Location = New System.Drawing.Point(473, 385)
        Me.BTXoa.Name = "BTXoa"
        Me.BTXoa.Size = New System.Drawing.Size(135, 53)
        Me.BTXoa.TabIndex = 5
        Me.BTXoa.Text = "Xóa"
        Me.BTXoa.UseVisualStyleBackColor = True
        '
        'dgvListMH
        '
        Me.dgvListMH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListMH.Location = New System.Drawing.Point(54, 21)
        Me.dgvListMH.MultiSelect = False
        Me.dgvListMH.Name = "dgvListMH"
        Me.dgvListMH.ReadOnly = True
        Me.dgvListMH.RowTemplate.Height = 24
        Me.dgvListMH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListMH.Size = New System.Drawing.Size(656, 135)
        Me.dgvListMH.TabIndex = 6
        '
        'TBMMH
        '
        Me.TBMMH.Location = New System.Drawing.Point(335, 237)
        Me.TBMMH.Name = "TBMMH"
        Me.TBMMH.Size = New System.Drawing.Size(187, 22)
        Me.TBMMH.TabIndex = 1
        '
        'frmQLMatHang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TBMMH)
        Me.Controls.Add(Me.BTXoa)
        Me.Controls.Add(Me.BTCapnhat)
        Me.Controls.Add(Me.dgvListMH)
        Me.Controls.Add(Me.TBSLT)
        Me.Controls.Add(Me.TBTMH)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmQLMatHang"
        Me.Text = "QLMatHang"
        CType(Me.dgvListMH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TBTMH As TextBox
    Friend WithEvents TBSLT As TextBox
    Friend WithEvents BTCapnhat As Button
    Friend WithEvents BTXoa As Button
    Friend WithEvents dgvListMH As DataGridView
    Friend WithEvents TBMMH As TextBox
End Class
