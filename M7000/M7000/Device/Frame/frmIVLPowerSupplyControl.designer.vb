<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIVLPowerSupplyControl
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIVLPowerSupplyControl))
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblOutputPower = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSetI = New System.Windows.Forms.Button()
        Me.btnSetV = New System.Windows.Forms.Button()
        Me.btnGetV = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbDevSelect = New System.Windows.Forms.ComboBox()
        Me.btnPowerOff = New System.Windows.Forms.Button()
        Me.btnPowerOn = New System.Windows.Forms.Button()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.txtCurrent = New System.Windows.Forms.TextBox()
        Me.txtVoltage = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.btnDisconnection = New System.Windows.Forms.Button()
        Me.tbConnectionStatus = New System.Windows.Forms.TextBox()
        Me.UcMcIVLPowerSupplyConfig1 = New M7000.ucMcIVLPowerSupplyConfig()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.lblOutputPower)
        Me.groupBox3.Location = New System.Drawing.Point(507, 279)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(227, 86)
        Me.groupBox3.TabIndex = 4
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Output Power"
        '
        'lblOutputPower
        '
        Me.lblOutputPower.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblOutputPower.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutputPower.ForeColor = System.Drawing.Color.White
        Me.lblOutputPower.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblOutputPower.Location = New System.Drawing.Point(7, 20)
        Me.lblOutputPower.Margin = New System.Windows.Forms.Padding(3)
        Me.lblOutputPower.Name = "lblOutputPower"
        Me.lblOutputPower.Size = New System.Drawing.Size(210, 55)
        Me.lblOutputPower.TabIndex = 1162
        Me.lblOutputPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.btnSetI)
        Me.groupBox2.Controls.Add(Me.btnSetV)
        Me.groupBox2.Controls.Add(Me.btnGetV)
        Me.groupBox2.Controls.Add(Me.Label1)
        Me.groupBox2.Controls.Add(Me.cbDevSelect)
        Me.groupBox2.Controls.Add(Me.btnPowerOff)
        Me.groupBox2.Controls.Add(Me.btnPowerOn)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.label6)
        Me.groupBox2.Controls.Add(Me.txtCurrent)
        Me.groupBox2.Controls.Add(Me.txtVoltage)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.label3)
        Me.groupBox2.Location = New System.Drawing.Point(274, 279)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(227, 198)
        Me.groupBox2.TabIndex = 3
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Setting Value"
        '
        'btnSetI
        '
        Me.btnSetI.Location = New System.Drawing.Point(125, 107)
        Me.btnSetI.Name = "btnSetI"
        Me.btnSetI.Size = New System.Drawing.Size(92, 24)
        Me.btnSetI.TabIndex = 10
        Me.btnSetI.Text = "Set Current"
        Me.btnSetI.UseVisualStyleBackColor = True
        '
        'btnSetV
        '
        Me.btnSetV.Location = New System.Drawing.Point(10, 107)
        Me.btnSetV.Name = "btnSetV"
        Me.btnSetV.Size = New System.Drawing.Size(92, 24)
        Me.btnSetV.TabIndex = 11
        Me.btnSetV.Text = "Set Voltage"
        Me.btnSetV.UseVisualStyleBackColor = True
        '
        'btnGetV
        '
        Me.btnGetV.Location = New System.Drawing.Point(10, 137)
        Me.btnGetV.Name = "btnGetV"
        Me.btnGetV.Size = New System.Drawing.Size(207, 24)
        Me.btnGetV.TabIndex = 9
        Me.btnGetV.Text = "Get Voltage / Current"
        Me.btnGetV.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Device Select"
        '
        'cbDevSelect
        '
        Me.cbDevSelect.FormattingEnabled = True
        Me.cbDevSelect.Location = New System.Drawing.Point(96, 22)
        Me.cbDevSelect.Name = "cbDevSelect"
        Me.cbDevSelect.Size = New System.Drawing.Size(118, 20)
        Me.cbDevSelect.TabIndex = 6
        '
        'btnPowerOff
        '
        Me.btnPowerOff.Location = New System.Drawing.Point(125, 167)
        Me.btnPowerOff.Name = "btnPowerOff"
        Me.btnPowerOff.Size = New System.Drawing.Size(92, 24)
        Me.btnPowerOff.TabIndex = 4
        Me.btnPowerOff.Text = "Power Off"
        Me.btnPowerOff.UseVisualStyleBackColor = True
        '
        'btnPowerOn
        '
        Me.btnPowerOn.Location = New System.Drawing.Point(10, 167)
        Me.btnPowerOn.Name = "btnPowerOn"
        Me.btnPowerOn.Size = New System.Drawing.Size(92, 24)
        Me.btnPowerOn.TabIndex = 5
        Me.btnPowerOn.Text = "Power On"
        Me.btnPowerOn.UseVisualStyleBackColor = True
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(201, 83)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(13, 12)
        Me.label5.TabIndex = 3
        Me.label5.Text = "A"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(201, 54)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(13, 12)
        Me.label6.TabIndex = 4
        Me.label6.Text = "V"
        '
        'txtCurrent
        '
        Me.txtCurrent.Location = New System.Drawing.Point(96, 77)
        Me.txtCurrent.Name = "txtCurrent"
        Me.txtCurrent.Size = New System.Drawing.Size(100, 21)
        Me.txtCurrent.TabIndex = 2
        Me.txtCurrent.Text = "5"
        '
        'txtVoltage
        '
        Me.txtVoltage.Location = New System.Drawing.Point(96, 48)
        Me.txtVoltage.Name = "txtVoltage"
        Me.txtVoltage.Size = New System.Drawing.Size(100, 21)
        Me.txtVoltage.TabIndex = 2
        Me.txtVoltage.Text = "2"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(43, 80)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(46, 12)
        Me.label4.TabIndex = 2
        Me.label4.Text = "Current"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(43, 51)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(47, 12)
        Me.label3.TabIndex = 2
        Me.label3.Text = "Voltage"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnConnection)
        Me.GroupBox1.Controls.Add(Me.btnDisconnection)
        Me.GroupBox1.Controls.Add(Me.tbConnectionStatus)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 279)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 175)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Setting Value"
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(6, 25)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(115, 35)
        Me.btnConnection.TabIndex = 7
        Me.btnConnection.Text = "All Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'btnDisconnection
        '
        Me.btnDisconnection.Location = New System.Drawing.Point(133, 25)
        Me.btnDisconnection.Name = "btnDisconnection"
        Me.btnDisconnection.Size = New System.Drawing.Size(115, 35)
        Me.btnDisconnection.TabIndex = 8
        Me.btnDisconnection.Text = "All Disconnection"
        Me.btnDisconnection.UseVisualStyleBackColor = True
        '
        'tbConnectionStatus
        '
        Me.tbConnectionStatus.Location = New System.Drawing.Point(6, 66)
        Me.tbConnectionStatus.Multiline = True
        Me.tbConnectionStatus.Name = "tbConnectionStatus"
        Me.tbConnectionStatus.Size = New System.Drawing.Size(242, 55)
        Me.tbConnectionStatus.TabIndex = 6
        '
        '
        '
        'UcMcIVLPowerSupplyConfig1
        '
        Me.UcMcIVLPowerSupplyConfig1.Location = New System.Drawing.Point(-4, -5)
        Me.UcMcIVLPowerSupplyConfig1.Name = "UcMcIVLPowerSupplyConfig1"
        Me.UcMcIVLPowerSupplyConfig1.Size = New System.Drawing.Size(1275, 259)
        Me.UcMcIVLPowerSupplyConfig1.TabIndex = 0
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(507, 371)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(92, 24)
        Me.Button5.TabIndex = 12
        Me.Button5.Text = "IDN"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'frmIVLPowerSupplyControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1255, 498)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.UcMcIVLPowerSupplyConfig1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmIVLPowerSupplyControl"
        Me.Text = "frmIVLPowerSupplyControl"
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UcMcIVLPowerSupplyConfig1 As ucMcIVLPowerSupplyConfig
    Private WithEvents groupBox3 As GroupBox
    Public WithEvents lblOutputPower As Label
    Private WithEvents groupBox2 As GroupBox
    Private WithEvents Label1 As Label
    Friend WithEvents cbDevSelect As ComboBox
    Private WithEvents btnPowerOff As Button
    Private WithEvents btnPowerOn As Button
    Private WithEvents label5 As Label
    Private WithEvents label6 As Label
    Private WithEvents txtCurrent As TextBox
    Private WithEvents txtVoltage As TextBox
    Private WithEvents label4 As Label
    Private WithEvents label3 As Label
    Private WithEvents GroupBox1 As GroupBox
    Friend WithEvents tbConnectionStatus As TextBox
    Private WithEvents btnSetI As Button
    Private WithEvents btnSetV As Button
    Private WithEvents btnGetV As Button
    Friend WithEvents btnConnection As Button
    Friend WithEvents btnDisconnection As Button
    Friend WithEvents cbasd As ComboBox
    Private WithEvents Button4 As Button
    Private WithEvents Button3 As Button
    Private WithEvents Button2 As Button
    Private WithEvents Button1 As Button
    Private WithEvents Button5 As Button
End Class
