<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTiepNhanLoaiDaiLy
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBTLDL = New System.Windows.Forms.TextBox()
        Me.TBMLDL = New System.Windows.Forms.TextBox()
        Me.BTNhap = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBNDL = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(116, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Mã Loại Đại Lý"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(116, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tên Loại Đại Lý"
        '
        'TBTLDL
        '
        Me.TBTLDL.Location = New System.Drawing.Point(307, 156)
        Me.TBTLDL.Name = "TBTLDL"
        Me.TBTLDL.Size = New System.Drawing.Size(307, 22)
        Me.TBTLDL.TabIndex = 2
        '
        'TBMLDL
        '
        Me.TBMLDL.Location = New System.Drawing.Point(307, 93)
        Me.TBMLDL.Name = "TBMLDL"
        Me.TBMLDL.Size = New System.Drawing.Size(307, 22)
        Me.TBMLDL.TabIndex = 1
        '
        'BTNhap
        '
        Me.BTNhap.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNhap.Location = New System.Drawing.Point(279, 334)
        Me.BTNhap.Name = "BTNhap"
        Me.BTNhap.Size = New System.Drawing.Size(205, 47)
        Me.BTNhap.TabIndex = 4
        Me.BTNhap.Text = "Nhập"
        Me.BTNhap.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(116, 247)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Nợ Của Đại Lý"
        '
        'TBNDL
        '
        Me.TBNDL.Location = New System.Drawing.Point(307, 245)
        Me.TBNDL.Name = "TBNDL"
        Me.TBNDL.Size = New System.Drawing.Size(307, 22)
        Me.TBNDL.TabIndex = 3
        '
        'frmTiepNhanLoaiDaiLy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.BTNhap)
        Me.Controls.Add(Me.TBMLDL)
        Me.Controls.Add(Me.TBNDL)
        Me.Controls.Add(Me.TBTLDL)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmTiepNhanLoaiDaiLy"
        Me.Text = "frmTiepNhanLoaiDaiLy"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TBTLDL As TextBox
    Friend WithEvents TBMLDL As TextBox
    Friend WithEvents BTNhap As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TBNDL As TextBox
End Class
