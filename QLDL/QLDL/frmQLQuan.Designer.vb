<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQLQuan
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
        Me.dgvListQuan = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBMQ = New System.Windows.Forms.TextBox()
        Me.TBTQ = New System.Windows.Forms.TextBox()
        Me.TBSLDLTD = New System.Windows.Forms.TextBox()
        Me.BTCapNhat = New System.Windows.Forms.Button()
        Me.BTXoa = New System.Windows.Forms.Button()
        CType(Me.dgvListQuan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvListQuan
        '
        Me.dgvListQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListQuan.Location = New System.Drawing.Point(119, 25)
        Me.dgvListQuan.Name = "dgvListQuan"
        Me.dgvListQuan.RowTemplate.Height = 24
        Me.dgvListQuan.Size = New System.Drawing.Size(528, 161)
        Me.dgvListQuan.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(76, 223)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mã Quận"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(76, 279)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tên Quận"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(76, 336)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(209, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Số Lượng Đại Lý Tối Đa"
        '
        'TBMQ
        '
        Me.TBMQ.Location = New System.Drawing.Point(346, 221)
        Me.TBMQ.Name = "TBMQ"
        Me.TBMQ.Size = New System.Drawing.Size(264, 22)
        Me.TBMQ.TabIndex = 1
        '
        'TBTQ
        '
        Me.TBTQ.Location = New System.Drawing.Point(346, 277)
        Me.TBTQ.Name = "TBTQ"
        Me.TBTQ.Size = New System.Drawing.Size(264, 22)
        Me.TBTQ.TabIndex = 2
        '
        'TBSLDLTD
        '
        Me.TBSLDLTD.Location = New System.Drawing.Point(346, 334)
        Me.TBSLDLTD.Name = "TBSLDLTD"
        Me.TBSLDLTD.Size = New System.Drawing.Size(264, 22)
        Me.TBSLDLTD.TabIndex = 3
        '
        'BTCapNhat
        '
        Me.BTCapNhat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTCapNhat.Location = New System.Drawing.Point(167, 385)
        Me.BTCapNhat.Name = "BTCapNhat"
        Me.BTCapNhat.Size = New System.Drawing.Size(166, 53)
        Me.BTCapNhat.TabIndex = 4
        Me.BTCapNhat.Text = "Cập Nhật"
        Me.BTCapNhat.UseVisualStyleBackColor = True
        '
        'BTXoa
        '
        Me.BTXoa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTXoa.Location = New System.Drawing.Point(422, 385)
        Me.BTXoa.Name = "BTXoa"
        Me.BTXoa.Size = New System.Drawing.Size(166, 53)
        Me.BTXoa.TabIndex = 5
        Me.BTXoa.Text = "Xóa"
        Me.BTXoa.UseVisualStyleBackColor = True
        '
        'frmQLQuan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.BTXoa)
        Me.Controls.Add(Me.BTCapNhat)
        Me.Controls.Add(Me.TBSLDLTD)
        Me.Controls.Add(Me.TBTQ)
        Me.Controls.Add(Me.TBMQ)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvListQuan)
        Me.Name = "frmQLQuan"
        Me.Text = "frmQLQuan"
        CType(Me.dgvListQuan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvListQuan As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TBMQ As TextBox
    Friend WithEvents TBTQ As TextBox
    Friend WithEvents TBSLDLTD As TextBox
    Friend WithEvents BTCapNhat As Button
    Friend WithEvents BTXoa As Button
End Class
