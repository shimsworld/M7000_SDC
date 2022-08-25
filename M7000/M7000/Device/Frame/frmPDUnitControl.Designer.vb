<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPDUnitControl
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
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.tbQueryMsg = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.btnReadCalibrationData = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnReadPDCurrent = New System.Windows.Forms.Button()
        Me.lbPDCurrent = New System.Windows.Forms.Label()
        Me.cbChannel = New System.Windows.Forms.ComboBox()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.UcConfigRs232 = New CCommLib.ucConfigRs232()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboSelDevice = New System.Windows.Forms.ComboBox()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(12, 253)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(106, 34)
        Me.btnConnection.TabIndex = 1
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(125, 253)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(105, 34)
        Me.btnDisconnect.TabIndex = 2
        Me.btnDisconnect.Text = "Disconnection"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.btnClear)
        Me.GroupBox14.Controls.Add(Me.tbQueryMsg)
        Me.GroupBox14.Location = New System.Drawing.Point(18, 293)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(216, 286)
        Me.GroupBox14.TabIndex = 9
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Query Message"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnClear.Location = New System.Drawing.Point(10, 245)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(195, 33)
        Me.btnClear.TabIndex = 16
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'tbQueryMsg
        '
        Me.tbQueryMsg.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.tbQueryMsg.Location = New System.Drawing.Point(10, 20)
        Me.tbQueryMsg.Multiline = True
        Me.tbQueryMsg.Name = "tbQueryMsg"
        Me.tbQueryMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbQueryMsg.Size = New System.Drawing.Size(195, 212)
        Me.tbQueryMsg.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(176, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "OFFSET"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.HotPink
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(75, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "RATIO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(15, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 23)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "CH1"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(15, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 23)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "CH2"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Black
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(15, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 23)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "CH4"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Black
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(15, 103)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 23)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "CH3"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Black
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(15, 228)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 23)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "CH8"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Black
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(15, 203)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 23)
        Me.Label18.TabIndex = 46
        Me.Label18.Text = "CH7"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Black
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(15, 178)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(57, 23)
        Me.Label21.TabIndex = 41
        Me.Label21.Text = "CH6"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Black
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(15, 153)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(57, 23)
        Me.Label24.TabIndex = 36
        Me.Label24.Text = "CH5"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Black
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(15, 428)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(57, 23)
        Me.Label27.TabIndex = 91
        Me.Label27.Text = "CH16"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Black
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(15, 403)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(57, 23)
        Me.Label30.TabIndex = 86
        Me.Label30.Text = "CH15"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Black
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(15, 378)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(57, 23)
        Me.Label33.TabIndex = 81
        Me.Label33.Text = "CH14"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Black
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(15, 353)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(57, 23)
        Me.Label36.TabIndex = 76
        Me.Label36.Text = "CH13"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Black
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.Location = New System.Drawing.Point(15, 328)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(57, 23)
        Me.Label39.TabIndex = 71
        Me.Label39.Text = "CH12"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Black
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.Location = New System.Drawing.Point(15, 303)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(57, 23)
        Me.Label42.TabIndex = 66
        Me.Label42.Text = "CH11"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Black
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(15, 278)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(57, 23)
        Me.Label45.TabIndex = 61
        Me.Label45.Text = "CH10"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Black
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(15, 253)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(57, 23)
        Me.Label48.TabIndex = 56
        Me.Label48.Text = "CH9"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Controls.Add(Me.Label40)
        Me.GroupBox1.Controls.Add(Me.Label44)
        Me.GroupBox1.Controls.Add(Me.Label49)
        Me.GroupBox1.Controls.Add(Me.Label52)
        Me.GroupBox1.Controls.Add(Me.Label55)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Controls.Add(Me.Label61)
        Me.GroupBox1.Controls.Add(Me.Label64)
        Me.GroupBox1.Controls.Add(Me.Label67)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label42)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label45)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label48)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(242, 115)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(824, 464)
        Me.GroupBox1.TabIndex = 92
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Calibration Data Read/Write"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(417, 428)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 23)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "CH32"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.HotPink
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(477, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "RATIO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Black
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(417, 403)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 23)
        Me.Label13.TabIndex = 168
        Me.Label13.Text = "CH31"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Location = New System.Drawing.Point(578, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 23)
        Me.Label14.TabIndex = 97
        Me.Label14.Text = "OFFSET"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Black
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(417, 53)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 23)
        Me.Label17.TabIndex = 98
        Me.Label17.Text = "CH17"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Black
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(417, 378)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(57, 23)
        Me.Label22.TabIndex = 163
        Me.Label22.Text = "CH30"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Black
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(417, 78)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(57, 23)
        Me.Label26.TabIndex = 103
        Me.Label26.Text = "CH18"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Black
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(417, 353)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(57, 23)
        Me.Label31.TabIndex = 158
        Me.Label31.Text = "CH29"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Black
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(417, 103)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(57, 23)
        Me.Label35.TabIndex = 108
        Me.Label35.Text = "CH19"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Black
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(417, 328)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(57, 23)
        Me.Label40.TabIndex = 153
        Me.Label40.Text = "CH28"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Black
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(417, 128)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(57, 23)
        Me.Label44.TabIndex = 113
        Me.Label44.Text = "CH20"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Black
        Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label49.ForeColor = System.Drawing.Color.White
        Me.Label49.Location = New System.Drawing.Point(417, 303)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(57, 23)
        Me.Label49.TabIndex = 148
        Me.Label49.Text = "CH27"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Black
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(417, 153)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(57, 23)
        Me.Label52.TabIndex = 118
        Me.Label52.Text = "CH21"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.Black
        Me.Label55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label55.ForeColor = System.Drawing.Color.White
        Me.Label55.Location = New System.Drawing.Point(417, 278)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(57, 23)
        Me.Label55.TabIndex = 143
        Me.Label55.Text = "CH26"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.Black
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label58.ForeColor = System.Drawing.Color.White
        Me.Label58.Location = New System.Drawing.Point(417, 178)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(57, 23)
        Me.Label58.TabIndex = 123
        Me.Label58.Text = "CH22"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.Color.Black
        Me.Label61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label61.ForeColor = System.Drawing.Color.White
        Me.Label61.Location = New System.Drawing.Point(417, 253)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(57, 23)
        Me.Label61.TabIndex = 138
        Me.Label61.Text = "CH25"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.Black
        Me.Label64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label64.ForeColor = System.Drawing.Color.White
        Me.Label64.Location = New System.Drawing.Point(417, 203)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(57, 23)
        Me.Label64.TabIndex = 128
        Me.Label64.Text = "CH23"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.Color.Black
        Me.Label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label67.ForeColor = System.Drawing.Color.White
        Me.Label67.Location = New System.Drawing.Point(417, 228)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(57, 23)
        Me.Label67.TabIndex = 133
        Me.Label67.Text = "CH24"
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnReadCalibrationData
        '
        Me.btnReadCalibrationData.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnReadCalibrationData.Location = New System.Drawing.Point(242, 54)
        Me.btnReadCalibrationData.Name = "btnReadCalibrationData"
        Me.btnReadCalibrationData.Size = New System.Drawing.Size(260, 43)
        Me.btnReadCalibrationData.TabIndex = 17
        Me.btnReadCalibrationData.Text = "READ Cal. Data"
        Me.btnReadCalibrationData.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnReadPDCurrent)
        Me.GroupBox2.Controls.Add(Me.lbPDCurrent)
        Me.GroupBox2.Controls.Add(Me.cbChannel)
        Me.GroupBox2.Location = New System.Drawing.Point(520, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(544, 77)
        Me.GroupBox2.TabIndex = 93
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Measure PD Current"
        '
        'btnReadPDCurrent
        '
        Me.btnReadPDCurrent.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnReadPDCurrent.Location = New System.Drawing.Point(362, 33)
        Me.btnReadPDCurrent.Name = "btnReadPDCurrent"
        Me.btnReadPDCurrent.Size = New System.Drawing.Size(139, 31)
        Me.btnReadPDCurrent.TabIndex = 94
        Me.btnReadPDCurrent.Text = "READ PD Current"
        Me.btnReadPDCurrent.UseVisualStyleBackColor = True
        '
        'lbPDCurrent
        '
        Me.lbPDCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbPDCurrent.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbPDCurrent.Location = New System.Drawing.Point(138, 33)
        Me.lbPDCurrent.Name = "lbPDCurrent"
        Me.lbPDCurrent.Size = New System.Drawing.Size(203, 31)
        Me.lbPDCurrent.TabIndex = 1
        Me.lbPDCurrent.Text = "-"
        Me.lbPDCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbChannel
        '
        Me.cbChannel.FormattingEnabled = True
        Me.cbChannel.Location = New System.Drawing.Point(17, 33)
        Me.cbChannel.Name = "cbChannel"
        Me.cbChannel.Size = New System.Drawing.Size(106, 20)
        Me.cbChannel.TabIndex = 0
        '
        'lbStatus
        '
        Me.lbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbStatus.Location = New System.Drawing.Point(242, 20)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(260, 31)
        Me.lbStatus.TabIndex = 95
        Me.lbStatus.Text = "STATUS"
        Me.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UcConfigRs232
        '
        Me.UcConfigRs232.BAUDRATE = 19200
        Me.UcConfigRs232.COMPORT = "COM13"
        Me.UcConfigRs232.DATABIT = 8
        Me.UcConfigRs232.Location = New System.Drawing.Point(13, 54)
        Me.UcConfigRs232.Name = "UcConfigRs232"
        Me.UcConfigRs232.PARITYBIT = System.IO.Ports.Parity.None
        Me.UcConfigRs232.Size = New System.Drawing.Size(221, 193)
        Me.UcConfigRs232.STOPBIT = System.IO.Ports.StopBits.One
        Me.UcConfigRs232.TabIndex = 0
        Me.UcConfigRs232.SendTerminator = CCommLib.ucConfigRs232.eTerminator.McScience_EOT
        Me.UcConfigRs232.Title = "RS232"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 12)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "Sel. Device"
        '
        'cboSelDevice
        '
        Me.cboSelDevice.FormattingEnabled = True
        Me.cboSelDevice.Location = New System.Drawing.Point(91, 26)
        Me.cboSelDevice.Name = "cboSelDevice"
        Me.cboSelDevice.Size = New System.Drawing.Size(139, 20)
        Me.cboSelDevice.TabIndex = 97
        '
        'frmPDUnitControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1157, 620)
        Me.Controls.Add(Me.cboSelDevice)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbStatus)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnReadCalibrationData)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox14)
        Me.Controls.Add(Me.btnDisconnect)
        Me.Controls.Add(Me.btnConnection)
        Me.Controls.Add(Me.UcConfigRs232)
        Me.Name = "frmPDUnitControl"
        Me.Text = "Photo Current Measurement"
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UcConfigRs232 As CCommLib.ucConfigRs232
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents tbQueryMsg As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents btnReadCalibrationData As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReadPDCurrent As System.Windows.Forms.Button
    Friend WithEvents lbPDCurrent As System.Windows.Forms.Label
    Friend WithEvents cbChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboSelDevice As System.Windows.Forms.ComboBox

End Class
