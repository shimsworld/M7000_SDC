<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSGCalibration
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tb_CalOffset = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tb_CalRatio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tb_Real2 = New System.Windows.Forms.TextBox()
        Me.tb_Real1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnReadData2 = New System.Windows.Forms.Button()
        Me.btnReadData1 = New System.Windows.Forms.Button()
        Me.tb_Disp2 = New System.Windows.Forms.TextBox()
        Me.tb_Disp1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Calibration = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(575, 169)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 38)
        Me.btnClose.TabIndex = 16
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tb_CalOffset
        '
        Me.tb_CalOffset.Location = New System.Drawing.Point(89, 179)
        Me.tb_CalOffset.Name = "tb_CalOffset"
        Me.tb_CalOffset.Size = New System.Drawing.Size(122, 21)
        Me.tb_CalOffset.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 182)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 12)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Offset"
        '
        'tb_CalRatio
        '
        Me.tb_CalRatio.Location = New System.Drawing.Point(89, 143)
        Me.tb_CalRatio.Name = "tb_CalRatio"
        Me.tb_CalRatio.Size = New System.Drawing.Size(122, 21)
        Me.tb_CalRatio.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 12)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Ratio"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tb_Real2)
        Me.GroupBox2.Controls.Add(Me.tb_Real1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(350, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 103)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Real"
        '
        'tb_Real2
        '
        Me.tb_Real2.Location = New System.Drawing.Point(86, 62)
        Me.tb_Real2.Name = "tb_Real2"
        Me.tb_Real2.Size = New System.Drawing.Size(122, 21)
        Me.tb_Real2.TabIndex = 5
        '
        'tb_Real1
        '
        Me.tb_Real1.Location = New System.Drawing.Point(86, 25)
        Me.tb_Real1.Name = "tb_Real1"
        Me.tb_Real1.Size = New System.Drawing.Size(122, 21)
        Me.tb_Real1.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "R_Data2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "R_Data1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnReadData2)
        Me.GroupBox1.Controls.Add(Me.btnReadData1)
        Me.GroupBox1.Controls.Add(Me.tb_Disp2)
        Me.GroupBox1.Controls.Add(Me.tb_Disp1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(311, 103)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Display"
        '
        'btnReadData2
        '
        Me.btnReadData2.Location = New System.Drawing.Point(222, 62)
        Me.btnReadData2.Name = "btnReadData2"
        Me.btnReadData2.Size = New System.Drawing.Size(65, 23)
        Me.btnReadData2.TabIndex = 5
        Me.btnReadData2.Text = "read"
        Me.btnReadData2.UseVisualStyleBackColor = True
        '
        'btnReadData1
        '
        Me.btnReadData1.Location = New System.Drawing.Point(222, 23)
        Me.btnReadData1.Name = "btnReadData1"
        Me.btnReadData1.Size = New System.Drawing.Size(65, 23)
        Me.btnReadData1.TabIndex = 4
        Me.btnReadData1.Text = "read"
        Me.btnReadData1.UseVisualStyleBackColor = True
        '
        'tb_Disp2
        '
        Me.tb_Disp2.Location = New System.Drawing.Point(77, 62)
        Me.tb_Disp2.Name = "tb_Disp2"
        Me.tb_Disp2.Size = New System.Drawing.Size(122, 21)
        Me.tb_Disp2.TabIndex = 3
        '
        'tb_Disp1
        '
        Me.tb_Disp1.Location = New System.Drawing.Point(77, 25)
        Me.tb_Disp1.Name = "tb_Disp1"
        Me.tb_Disp1.Size = New System.Drawing.Size(122, 21)
        Me.tb_Disp1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "D_Data2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "D_Data1"
        '
        'btn_Calibration
        '
        Me.btn_Calibration.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Calibration.Location = New System.Drawing.Point(261, 156)
        Me.btn_Calibration.Name = "btn_Calibration"
        Me.btn_Calibration.Size = New System.Drawing.Size(185, 38)
        Me.btn_Calibration.TabIndex = 9
        Me.btn_Calibration.Text = "Calibration"
        Me.btn_Calibration.UseVisualStyleBackColor = False
        '
        'frmCalibration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 249)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.tb_CalOffset)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tb_CalRatio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_Calibration)
        Me.Name = "frmCalibration"
        Me.Text = "frmCalibration"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tb_CalOffset As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tb_CalRatio As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_Real2 As System.Windows.Forms.TextBox
    Friend WithEvents tb_Real1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReadData2 As System.Windows.Forms.Button
    Friend WithEvents btnReadData1 As System.Windows.Forms.Button
    Friend WithEvents tb_Disp2 As System.Windows.Forms.TextBox
    Friend WithEvents tb_Disp1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Calibration As System.Windows.Forms.Button
End Class
