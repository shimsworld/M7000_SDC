<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucConfigPG
    Inherits System.Windows.Forms.UserControl

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.gbPGConfig = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbSelPGDevice = New System.Windows.Forms.ComboBox()
        Me.ucPGConfig = New CCommLib.ucConfigSocket()
        Me.ucPGCtrlBD = New CCommLib.ucConfigRS485()
        Me.ucPGPower = New CCommLib.ucConfigRS485()
        Me.ucDispRs232 = New CCommLib.ucConfigRs232()
        Me.ucG4SConfig = New M7000.ucG4SConfig()
        Me.ucPGGroup = New M7000.ucConfigMcPGGroup()
        Me.gbPGConfig.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbPGConfig
        '
        Me.gbPGConfig.Controls.Add(Me.ucDispRs232)
        Me.gbPGConfig.Controls.Add(Me.ucG4SConfig)
        Me.gbPGConfig.Controls.Add(Me.Label3)
        Me.gbPGConfig.Controls.Add(Me.cbSelPGDevice)
        Me.gbPGConfig.Controls.Add(Me.ucPGGroup)
        Me.gbPGConfig.Controls.Add(Me.ucPGConfig)
        Me.gbPGConfig.Controls.Add(Me.ucPGCtrlBD)
        Me.gbPGConfig.Controls.Add(Me.ucPGPower)
        Me.gbPGConfig.Location = New System.Drawing.Point(3, 4)
        Me.gbPGConfig.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbPGConfig.Name = "gbPGConfig"
        Me.gbPGConfig.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gbPGConfig.Size = New System.Drawing.Size(1091, 925)
        Me.gbPGConfig.TabIndex = 8
        Me.gbPGConfig.TabStop = False
        Me.gbPGConfig.Text = "Settings"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Device select :"
        '
        'cbSelPGDevice
        '
        Me.cbSelPGDevice.FormattingEnabled = True
        Me.cbSelPGDevice.Location = New System.Drawing.Point(112, 16)
        Me.cbSelPGDevice.Name = "cbSelPGDevice"
        Me.cbSelPGDevice.Size = New System.Drawing.Size(178, 20)
        Me.cbSelPGDevice.TabIndex = 10
        '
        'ucPGConfig
        '
        Me.ucPGConfig.AutoScroll = True
        Me.ucPGConfig.DispMode = CCommLib.ucConfigSocket.eDispMode.eHorizontalArrange
        Me.ucPGConfig.Location = New System.Drawing.Point(8, 216)
        Me.ucPGConfig.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ucPGConfig.Name = "ucPGConfig"
        Me.ucPGConfig.Setting = Nothing
        Me.ucPGConfig.Size = New System.Drawing.Size(816, 137)
        Me.ucPGConfig.TabIndex = 8
        Me.ucPGConfig.Title = "PG"
        '
        'ucPGCtrlBD
        '
        Me.ucPGCtrlBD.AutoScroll = True
        Me.ucPGCtrlBD.AutoScrollMinSize = New System.Drawing.Size(640, 310)
        Me.ucPGCtrlBD.DispMode = CCommLib.ucConfigRS485.eDispMode.eVerticalArrange
        Me.ucPGCtrlBD.Location = New System.Drawing.Point(20, 580)
        Me.ucPGCtrlBD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ucPGCtrlBD.Name = "ucPGCtrlBD"
        Me.ucPGCtrlBD.Setting = Nothing
        Me.ucPGCtrlBD.Size = New System.Drawing.Size(1038, 308)
        Me.ucPGCtrlBD.TabIndex = 7
        Me.ucPGCtrlBD.Title = "PG Control"
        '
        'ucPGPower
        '
        Me.ucPGPower.AutoScroll = True
        Me.ucPGPower.AutoScrollMinSize = New System.Drawing.Size(640, 310)
        Me.ucPGPower.DispMode = CCommLib.ucConfigRS485.eDispMode.eHorizontalArrange
        Me.ucPGPower.Location = New System.Drawing.Point(9, 361)
        Me.ucPGPower.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ucPGPower.Name = "ucPGPower"
        Me.ucPGPower.Setting = Nothing
        Me.ucPGPower.Size = New System.Drawing.Size(1103, 224)
        Me.ucPGPower.TabIndex = 6
        Me.ucPGPower.Title = "PG Power"
        '
        'ucDispRs232
        '
        Me.ucDispRs232.BAUDRATE = 19200
        Me.ucDispRs232.COMPORT = "COM3"
        Me.ucDispRs232.DATABIT = 8
        Me.ucDispRs232.Location = New System.Drawing.Point(830, 199)
        Me.ucDispRs232.Name = "ucDispRs232"
        Me.ucDispRs232.PARITYBIT = System.IO.Ports.Parity.None
        Me.ucDispRs232.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucDispRs232.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucDispRs232.Size = New System.Drawing.Size(241, 202)
        Me.ucDispRs232.STOPBIT = System.IO.Ports.StopBits.One
        Me.ucDispRs232.TabIndex = 20
        Me.ucDispRs232.Title = "RS232"
        '
        'ucG4SConfig
        '
        Me.ucG4SConfig.Location = New System.Drawing.Point(812, 53)
        Me.ucG4SConfig.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ucG4SConfig.Name = "ucG4SConfig"
        Me.ucG4SConfig.Size = New System.Drawing.Size(269, 124)
        Me.ucG4SConfig.TabIndex = 12
        Me.ucG4SConfig.Title = "Settings"
        '
        'ucPGGroup
        '
        Me.ucPGGroup.Location = New System.Drawing.Point(9, 41)
        Me.ucPGGroup.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ucPGGroup.Name = "ucPGGroup"
        Me.ucPGGroup.Setting = Nothing
        Me.ucPGGroup.Size = New System.Drawing.Size(751, 166)
        Me.ucPGGroup.TabIndex = 9
        '
        'ucConfigPG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbPGConfig)
        Me.Name = "ucConfigPG"
        Me.Size = New System.Drawing.Size(1338, 995)
        Me.gbPGConfig.ResumeLayout(False)
        Me.gbPGConfig.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPGConfig As System.Windows.Forms.GroupBox
    Friend WithEvents ucG4SConfig As M7000.ucG4SConfig
    '김세훈 8.25 EIP Config추가
    Friend WithEvents ucEIPConfig As CCommLib.ucConfigRs232
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbSelPGDevice As System.Windows.Forms.ComboBox
    Friend WithEvents ucPGGroup As M7000.ucConfigMcPGGroup
    Friend WithEvents ucPGConfig As CCommLib.ucConfigSocket
    Friend WithEvents ucPGCtrlBD As CCommLib.ucConfigRS485
    Friend WithEvents ucPGPower As CCommLib.ucConfigRS485
    Friend WithEvents ucDispRs232 As CCommLib.ucConfigRs232
End Class
