<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPR705Control
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnDataRead = New System.Windows.Forms.Button()
        Me.btnMeasDataClear = New System.Windows.Forms.Button()
        Me.btnMeasStart = New System.Windows.Forms.Button()
        Me.btnRemoteOn = New System.Windows.Forms.Button()
        Me.tbMeasData = New System.Windows.Forms.TextBox()
        Me.btnRemoteOff = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbSelectMeasData = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbExposureTime = New System.Windows.Forms.TextBox()
        Me.cbExposureMode = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblGetSettings = New System.Windows.Forms.Label()
        Me.btnGetOption_PR705 = New System.Windows.Forms.Button()
        Me.cbPhotometricUnits = New System.Windows.Forms.ComboBox()
        Me.tbMeasAverage = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSetOption_PR705 = New System.Windows.Forms.Button()
        Me.btnGetAperture_PR705 = New System.Windows.Forms.Button()
        Me.btnGetLens_PR705 = New System.Windows.Forms.Button()
        Me.cbBacklight_PR705 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSetBacklight_PR705 = New System.Windows.Forms.Button()
        Me.cbApertureType_PR705 = New System.Windows.Forms.ComboBox()
        Me.cbLensType_PR705 = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblRcvMsg = New System.Windows.Forms.Label()
        Me.btnSetCommand = New System.Windows.Forms.Button()
        Me.tbCommand = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ucCfgRS232PR705 = New CCommLib.ucConfigRs232()
        Me.tbPR705ConnectionStatus = New System.Windows.Forms.TextBox()
        Me.btnPR705Connection = New System.Windows.Forms.Button()
        Me.btnPR705Disconnection = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnDataRead)
        Me.GroupBox2.Controls.Add(Me.btnMeasDataClear)
        Me.GroupBox2.Controls.Add(Me.btnMeasStart)
        Me.GroupBox2.Controls.Add(Me.btnRemoteOn)
        Me.GroupBox2.Controls.Add(Me.tbMeasData)
        Me.GroupBox2.Controls.Add(Me.btnRemoteOff)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cbSelectMeasData)
        Me.GroupBox2.Location = New System.Drawing.Point(640, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(380, 372)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Control"
        '
        'btnDataRead
        '
        Me.btnDataRead.Location = New System.Drawing.Point(162, 91)
        Me.btnDataRead.Name = "btnDataRead"
        Me.btnDataRead.Size = New System.Drawing.Size(103, 35)
        Me.btnDataRead.TabIndex = 32
        Me.btnDataRead.Text = "Read."
        Me.btnDataRead.UseVisualStyleBackColor = True
        '
        'btnMeasDataClear
        '
        Me.btnMeasDataClear.Location = New System.Drawing.Point(271, 91)
        Me.btnMeasDataClear.Name = "btnMeasDataClear"
        Me.btnMeasDataClear.Size = New System.Drawing.Size(103, 35)
        Me.btnMeasDataClear.TabIndex = 31
        Me.btnMeasDataClear.Text = "Clear"
        Me.btnMeasDataClear.UseVisualStyleBackColor = True
        '
        'btnMeasStart
        '
        Me.btnMeasStart.Location = New System.Drawing.Point(53, 91)
        Me.btnMeasStart.Name = "btnMeasStart"
        Me.btnMeasStart.Size = New System.Drawing.Size(103, 35)
        Me.btnMeasStart.TabIndex = 30
        Me.btnMeasStart.Text = "Meas."
        Me.btnMeasStart.UseVisualStyleBackColor = True
        '
        'btnRemoteOn
        '
        Me.btnRemoteOn.Location = New System.Drawing.Point(8, 20)
        Me.btnRemoteOn.Name = "btnRemoteOn"
        Me.btnRemoteOn.Size = New System.Drawing.Size(109, 35)
        Me.btnRemoteOn.TabIndex = 20
        Me.btnRemoteOn.Text = "RemoteOn"
        Me.btnRemoteOn.UseVisualStyleBackColor = True
        '
        'tbMeasData
        '
        Me.tbMeasData.Location = New System.Drawing.Point(6, 132)
        Me.tbMeasData.Multiline = True
        Me.tbMeasData.Name = "tbMeasData"
        Me.tbMeasData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbMeasData.Size = New System.Drawing.Size(368, 230)
        Me.tbMeasData.TabIndex = 23
        '
        'btnRemoteOff
        '
        Me.btnRemoteOff.Location = New System.Drawing.Point(123, 20)
        Me.btnRemoteOff.Name = "btnRemoteOff"
        Me.btnRemoteOff.Size = New System.Drawing.Size(109, 35)
        Me.btnRemoteOff.TabIndex = 21
        Me.btnRemoteOff.Text = "RemoteOff"
        Me.btnRemoteOff.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "MeasMode :"
        '
        'cbSelectMeasData
        '
        Me.cbSelectMeasData.FormattingEnabled = True
        Me.cbSelectMeasData.Items.AddRange(New Object() {"CIE1931_Yxy", "XYZ", "CIE1976_Yuv", "YCd", "SpectrumData", "CIE1931CIE1976_Yxyuv"})
        Me.cbSelectMeasData.Location = New System.Drawing.Point(97, 63)
        Me.cbSelectMeasData.Name = "cbSelectMeasData"
        Me.cbSelectMeasData.Size = New System.Drawing.Size(277, 20)
        Me.cbSelectMeasData.TabIndex = 27
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.tbExposureTime)
        Me.GroupBox4.Controls.Add(Me.cbExposureMode)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.lblGetSettings)
        Me.GroupBox4.Controls.Add(Me.btnGetOption_PR705)
        Me.GroupBox4.Controls.Add(Me.cbPhotometricUnits)
        Me.GroupBox4.Controls.Add(Me.tbMeasAverage)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.btnSetOption_PR705)
        Me.GroupBox4.Controls.Add(Me.btnGetAperture_PR705)
        Me.GroupBox4.Controls.Add(Me.btnGetLens_PR705)
        Me.GroupBox4.Controls.Add(Me.cbBacklight_PR705)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.btnSetBacklight_PR705)
        Me.GroupBox4.Controls.Add(Me.cbApertureType_PR705)
        Me.GroupBox4.Controls.Add(Me.cbLensType_PR705)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(288, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(346, 372)
        Me.GroupBox4.TabIndex = 31
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Options"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 175)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 12)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Exposure Time :"
        '
        'tbExposureTime
        '
        Me.tbExposureTime.Location = New System.Drawing.Point(118, 172)
        Me.tbExposureTime.Name = "tbExposureTime"
        Me.tbExposureTime.Size = New System.Drawing.Size(75, 21)
        Me.tbExposureTime.TabIndex = 41
        Me.tbExposureTime.Text = "1"
        '
        'cbExposureMode
        '
        Me.cbExposureMode.FormattingEnabled = True
        Me.cbExposureMode.Items.AddRange(New Object() {"Adptv", "Fixed"})
        Me.cbExposureMode.Location = New System.Drawing.Point(118, 146)
        Me.cbExposureMode.Name = "cbExposureMode"
        Me.cbExposureMode.Size = New System.Drawing.Size(75, 20)
        Me.cbExposureMode.TabIndex = 40
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(200, 175)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 12)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "25 ~ 60,000 = fixed"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(200, 154)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 12)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "0 = Adaptive."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 12)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Exposure Mode :"
        '
        'lblGetSettings
        '
        Me.lblGetSettings.AutoSize = True
        Me.lblGetSettings.Location = New System.Drawing.Point(14, 305)
        Me.lblGetSettings.Name = "lblGetSettings"
        Me.lblGetSettings.Size = New System.Drawing.Size(58, 12)
        Me.lblGetSettings.TabIndex = 35
        Me.lblGetSettings.Text = "Message"
        '
        'btnGetOption_PR705
        '
        Me.btnGetOption_PR705.Location = New System.Drawing.Point(16, 239)
        Me.btnGetOption_PR705.Name = "btnGetOption_PR705"
        Me.btnGetOption_PR705.Size = New System.Drawing.Size(118, 48)
        Me.btnGetOption_PR705.TabIndex = 34
        Me.btnGetOption_PR705.Text = "Get"
        Me.btnGetOption_PR705.UseVisualStyleBackColor = True
        '
        'cbPhotometricUnits
        '
        Me.cbPhotometricUnits.FormattingEnabled = True
        Me.cbPhotometricUnits.Items.AddRange(New Object() {"fL", "Cd/m^2"})
        Me.cbPhotometricUnits.Location = New System.Drawing.Point(118, 120)
        Me.cbPhotometricUnits.Name = "cbPhotometricUnits"
        Me.cbPhotometricUnits.Size = New System.Drawing.Size(75, 20)
        Me.cbPhotometricUnits.TabIndex = 33
        '
        'tbMeasAverage
        '
        Me.tbMeasAverage.Location = New System.Drawing.Point(118, 199)
        Me.tbMeasAverage.Name = "tbMeasAverage"
        Me.tbMeasAverage.Size = New System.Drawing.Size(75, 21)
        Me.tbMeasAverage.TabIndex = 31
        Me.tbMeasAverage.Text = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 12)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Meas. Average :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 12)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Photometric Unit :"
        '
        'btnSetOption_PR705
        '
        Me.btnSetOption_PR705.Location = New System.Drawing.Point(148, 239)
        Me.btnSetOption_PR705.Name = "btnSetOption_PR705"
        Me.btnSetOption_PR705.Size = New System.Drawing.Size(117, 48)
        Me.btnSetOption_PR705.TabIndex = 21
        Me.btnSetOption_PR705.Text = "Set"
        Me.btnSetOption_PR705.UseVisualStyleBackColor = True
        '
        'btnGetAperture_PR705
        '
        Me.btnGetAperture_PR705.Location = New System.Drawing.Point(198, 86)
        Me.btnGetAperture_PR705.Name = "btnGetAperture_PR705"
        Me.btnGetAperture_PR705.Size = New System.Drawing.Size(60, 29)
        Me.btnGetAperture_PR705.TabIndex = 27
        Me.btnGetAperture_PR705.Text = "Get"
        Me.btnGetAperture_PR705.UseVisualStyleBackColor = True
        '
        'btnGetLens_PR705
        '
        Me.btnGetLens_PR705.Location = New System.Drawing.Point(198, 55)
        Me.btnGetLens_PR705.Name = "btnGetLens_PR705"
        Me.btnGetLens_PR705.Size = New System.Drawing.Size(60, 29)
        Me.btnGetLens_PR705.TabIndex = 26
        Me.btnGetLens_PR705.Text = "Get"
        Me.btnGetLens_PR705.UseVisualStyleBackColor = True
        '
        'cbBacklight_PR705
        '
        Me.cbBacklight_PR705.FormattingEnabled = True
        Me.cbBacklight_PR705.Items.AddRange(New Object() {"Off", "Low", "Medium", "Full"})
        Me.cbBacklight_PR705.Location = New System.Drawing.Point(119, 28)
        Me.cbBacklight_PR705.Name = "cbBacklight_PR705"
        Me.cbBacklight_PR705.Size = New System.Drawing.Size(75, 20)
        Me.cbBacklight_PR705.TabIndex = 25
        Me.cbBacklight_PR705.Tag = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 12)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Backlight :"
        '
        'btnSetBacklight_PR705
        '
        Me.btnSetBacklight_PR705.Location = New System.Drawing.Point(198, 23)
        Me.btnSetBacklight_PR705.Name = "btnSetBacklight_PR705"
        Me.btnSetBacklight_PR705.Size = New System.Drawing.Size(60, 29)
        Me.btnSetBacklight_PR705.TabIndex = 24
        Me.btnSetBacklight_PR705.Text = "SET"
        Me.btnSetBacklight_PR705.UseVisualStyleBackColor = True
        '
        'cbApertureType_PR705
        '
        Me.cbApertureType_PR705.FormattingEnabled = True
        Me.cbApertureType_PR705.Location = New System.Drawing.Point(119, 91)
        Me.cbApertureType_PR705.Name = "cbApertureType_PR705"
        Me.cbApertureType_PR705.Size = New System.Drawing.Size(75, 20)
        Me.cbApertureType_PR705.TabIndex = 22
        Me.cbApertureType_PR705.Text = "Nothing"
        '
        'cbLensType_PR705
        '
        Me.cbLensType_PR705.FormattingEnabled = True
        Me.cbLensType_PR705.Location = New System.Drawing.Point(119, 58)
        Me.cbLensType_PR705.Name = "cbLensType_PR705"
        Me.cbLensType_PR705.Size = New System.Drawing.Size(75, 20)
        Me.cbLensType_PR705.TabIndex = 20
        Me.cbLensType_PR705.Text = "Nothing"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(39, 61)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(74, 12)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Accessory :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(53, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Aperture :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblRcvMsg)
        Me.GroupBox1.Controls.Add(Me.btnSetCommand)
        Me.GroupBox1.Controls.Add(Me.tbCommand)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(288, 390)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(699, 69)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Command Test"
        '
        'lblRcvMsg
        '
        Me.lblRcvMsg.AutoSize = True
        Me.lblRcvMsg.Location = New System.Drawing.Point(83, 46)
        Me.lblRcvMsg.Name = "lblRcvMsg"
        Me.lblRcvMsg.Size = New System.Drawing.Size(30, 12)
        Me.lblRcvMsg.TabIndex = 23
        Me.lblRcvMsg.Text = "msg"
        '
        'btnSetCommand
        '
        Me.btnSetCommand.Location = New System.Drawing.Point(388, 17)
        Me.btnSetCommand.Name = "btnSetCommand"
        Me.btnSetCommand.Size = New System.Drawing.Size(63, 29)
        Me.btnSetCommand.TabIndex = 22
        Me.btnSetCommand.Text = "SET"
        Me.btnSetCommand.UseVisualStyleBackColor = True
        '
        'tbCommand
        '
        Me.tbCommand.Location = New System.Drawing.Point(85, 20)
        Me.tbCommand.Name = "tbCommand"
        Me.tbCommand.Size = New System.Drawing.Size(297, 21)
        Me.tbCommand.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 12)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Command :"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ucCfgRS232PR705)
        Me.GroupBox5.Controls.Add(Me.tbPR705ConnectionStatus)
        Me.GroupBox5.Controls.Add(Me.btnPR705Connection)
        Me.GroupBox5.Controls.Add(Me.btnPR705Disconnection)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(270, 372)
        Me.GroupBox5.TabIndex = 29
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Communication"
        '
        'ucCfgRS232PR705
        '
        Me.ucCfgRS232PR705.BAUDRATE = 9600
        Me.ucCfgRS232PR705.COMPORT = "COM1"
        Me.ucCfgRS232PR705.DATABIT = 8
        Me.ucCfgRS232PR705.Location = New System.Drawing.Point(12, 66)
        Me.ucCfgRS232PR705.Name = "ucCfgRS232PR705"
        Me.ucCfgRS232PR705.PARITYBIT = System.IO.Ports.Parity.None
        Me.ucCfgRS232PR705.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        Me.ucCfgRS232PR705.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CR
        Me.ucCfgRS232PR705.Size = New System.Drawing.Size(239, 235)
        Me.ucCfgRS232PR705.STOPBIT = System.IO.Ports.StopBits.One
        Me.ucCfgRS232PR705.TabIndex = 6
        Me.ucCfgRS232PR705.Title = "RS232"
        '
        'tbPR705ConnectionStatus
        '
        Me.tbPR705ConnectionStatus.Location = New System.Drawing.Point(12, 307)
        Me.tbPR705ConnectionStatus.Multiline = True
        Me.tbPR705ConnectionStatus.Name = "tbPR705ConnectionStatus"
        Me.tbPR705ConnectionStatus.Size = New System.Drawing.Size(231, 55)
        Me.tbPR705ConnectionStatus.TabIndex = 5
        '
        'btnPR705Connection
        '
        Me.btnPR705Connection.Location = New System.Drawing.Point(12, 20)
        Me.btnPR705Connection.Name = "btnPR705Connection"
        Me.btnPR705Connection.Size = New System.Drawing.Size(114, 35)
        Me.btnPR705Connection.TabIndex = 0
        Me.btnPR705Connection.Text = "Connection"
        Me.btnPR705Connection.UseVisualStyleBackColor = True
        '
        'btnPR705Disconnection
        '
        Me.btnPR705Disconnection.Location = New System.Drawing.Point(132, 20)
        Me.btnPR705Disconnection.Name = "btnPR705Disconnection"
        Me.btnPR705Disconnection.Size = New System.Drawing.Size(119, 35)
        Me.btnPR705Disconnection.TabIndex = 1
        Me.btnPR705Disconnection.Text = "Disconnection"
        Me.btnPR705Disconnection.UseVisualStyleBackColor = True
        '
        'frmPR705Control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1086, 597)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Name = "frmPR705Control"
        Me.Text = "frmPR705Control"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDataRead As System.Windows.Forms.Button
    Friend WithEvents btnMeasDataClear As System.Windows.Forms.Button
    Friend WithEvents btnMeasStart As System.Windows.Forms.Button
    Friend WithEvents btnRemoteOn As System.Windows.Forms.Button
    Friend WithEvents tbMeasData As System.Windows.Forms.TextBox
    Friend WithEvents btnRemoteOff As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbSelectMeasData As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbExposureTime As System.Windows.Forms.TextBox
    Friend WithEvents cbExposureMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblGetSettings As System.Windows.Forms.Label
    Friend WithEvents btnGetOption_PR705 As System.Windows.Forms.Button
    Friend WithEvents cbPhotometricUnits As System.Windows.Forms.ComboBox
    Friend WithEvents tbMeasAverage As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSetOption_PR705 As System.Windows.Forms.Button
    Friend WithEvents btnGetAperture_PR705 As System.Windows.Forms.Button
    Friend WithEvents btnGetLens_PR705 As System.Windows.Forms.Button
    Friend WithEvents cbBacklight_PR705 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSetBacklight_PR705 As System.Windows.Forms.Button
    Friend WithEvents cbApertureType_PR705 As System.Windows.Forms.ComboBox
    Friend WithEvents cbLensType_PR705 As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRcvMsg As System.Windows.Forms.Label
    Friend WithEvents btnSetCommand As System.Windows.Forms.Button
    Friend WithEvents tbCommand As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ucCfgRS232PR705 As CCommLib.ucConfigRs232
    Friend WithEvents tbPR705ConnectionStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnPR705Connection As System.Windows.Forms.Button
    Friend WithEvents btnPR705Disconnection As System.Windows.Forms.Button
End Class
