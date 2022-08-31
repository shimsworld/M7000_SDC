<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPLCMotionControl
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
        Me.components = New System.ComponentModel.Container()
        Me.gbManualCtrl = New System.Windows.Forms.GroupBox()
        Me.chkTheta4 = New System.Windows.Forms.CheckBox()
        Me.chkTheta3 = New System.Windows.Forms.CheckBox()
        Me.chkTheta2 = New System.Windows.Forms.CheckBox()
        Me.btnHomming = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.lblY2Pos = New System.Windows.Forms.Label()
        Me.lblTheta4Pos = New System.Windows.Forms.Label()
        Me.lblTheta2Pos = New System.Windows.Forms.Label()
        Me.lblTheta3Pos = New System.Windows.Forms.Label()
        Me.lblTheta1Pos = New System.Windows.Forms.Label()
        Me.lblYPos = New System.Windows.Forms.Label()
        Me.btnGetPosition = New System.Windows.Forms.Button()
        Me.lblZPos = New System.Windows.Forms.Label()
        Me.lblXPos = New System.Windows.Forms.Label()
        Me.txtVelocity = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnZmove = New System.Windows.Forms.Button()
        Me.btnYmove = New System.Windows.Forms.Button()
        Me.btnXmove = New System.Windows.Forms.Button()
        Me.chkTheta1 = New System.Windows.Forms.CheckBox()
        Me.rbAbs = New System.Windows.Forms.RadioButton()
        Me.rbMicroAdjust = New System.Windows.Forms.RadioButton()
        Me.txtPosition = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btn_Theta4Move = New System.Windows.Forms.Button()
        Me.btn_Theta3Move = New System.Windows.Forms.Button()
        Me.btn_Theta2Move = New System.Windows.Forms.Button()
        Me.btnTheta1Move = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbSelStatus = New System.Windows.Forms.ComboBox()
        Me.btnSetStatus = New System.Windows.Forms.Button()
        Me.tbStatusValue = New System.Windows.Forms.TextBox()
        Me.btnGetStatus = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbSelDISignal = New System.Windows.Forms.ComboBox()
        Me.tbDIValue = New System.Windows.Forms.TextBox()
        Me.btnSetDI = New System.Windows.Forms.Button()
        Me.btnGetDI = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbSelDOSignal = New System.Windows.Forms.ComboBox()
        Me.tbDOValue = New System.Windows.Forms.TextBox()
        Me.btnSetDO = New System.Windows.Forms.Button()
        Me.btnGetDO = New System.Windows.Forms.Button()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.btnSetVelocity = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbVelocity_Z = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbVelocity_X = New System.Windows.Forms.TextBox()
        Me.tbVelocity_Y = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbVelocity_Theta = New System.Windows.Forms.TextBox()
        Me.gbJOG = New System.Windows.Forms.GroupBox()
        Me.tlpJOG = New System.Windows.Forms.TableLayoutPanel()
        Me.btnR = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUP = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnL = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tbIPAdress4 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tbIPAdress3 = New System.Windows.Forms.TextBox()
        Me.tbIPAdress2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.tbIPAdress1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnDisconnection = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.ledSysStatus_MotorMoving = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.LbLed3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_Pause = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_SafetyMode_Teach = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_SystemManualMode = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_Processing = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_ManualMode = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_AutoMode = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_TeachingMode = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_PowerDown = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_PowerON = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledConnectionStateCheck = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbInDex = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbOutBinery = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnAllReset = New System.Windows.Forms.Button()
        Me.BtnAlaramReset = New System.Windows.Forms.Button()
        Me.btnJogOFF = New System.Windows.Forms.Button()
        Me.btnJogON = New System.Windows.Forms.Button()
        Me.btnInterrock = New System.Windows.Forms.Button()
        Me.chkY = New System.Windows.Forms.CheckBox()
        Me.chkZ = New System.Windows.Forms.CheckBox()
        Me.btnSWReadyOFF = New System.Windows.Forms.Button()
        Me.btnSWReadyON = New System.Windows.Forms.Button()
        Me.gbManualCtrl.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.gbJOG.SuspendLayout()
        Me.tlpJOG.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbManualCtrl
        '
        Me.gbManualCtrl.Controls.Add(Me.btnHomming)
        Me.gbManualCtrl.Controls.Add(Me.GroupBox8)
        Me.gbManualCtrl.Controls.Add(Me.txtVelocity)
        Me.gbManualCtrl.Controls.Add(Me.Label15)
        Me.gbManualCtrl.Controls.Add(Me.btnZmove)
        Me.gbManualCtrl.Controls.Add(Me.btnYmove)
        Me.gbManualCtrl.Controls.Add(Me.btnXmove)
        Me.gbManualCtrl.Controls.Add(Me.rbAbs)
        Me.gbManualCtrl.Controls.Add(Me.rbMicroAdjust)
        Me.gbManualCtrl.Controls.Add(Me.txtPosition)
        Me.gbManualCtrl.Controls.Add(Me.Label14)
        Me.gbManualCtrl.Location = New System.Drawing.Point(396, 360)
        Me.gbManualCtrl.Name = "gbManualCtrl"
        Me.gbManualCtrl.Size = New System.Drawing.Size(287, 475)
        Me.gbManualCtrl.TabIndex = 58
        Me.gbManualCtrl.TabStop = False
        Me.gbManualCtrl.Text = "Manual Control"
        '
        'chkTheta4
        '
        Me.chkTheta4.AutoSize = True
        Me.chkTheta4.Location = New System.Drawing.Point(268, 763)
        Me.chkTheta4.Name = "chkTheta4"
        Me.chkTheta4.Size = New System.Drawing.Size(91, 16)
        Me.chkTheta4.TabIndex = 57
        Me.chkTheta4.Text = "Theta4 Axis"
        Me.chkTheta4.UseVisualStyleBackColor = True
        Me.chkTheta4.Visible = False
        '
        'chkTheta3
        '
        Me.chkTheta3.AutoSize = True
        Me.chkTheta3.Location = New System.Drawing.Point(268, 741)
        Me.chkTheta3.Name = "chkTheta3"
        Me.chkTheta3.Size = New System.Drawing.Size(91, 16)
        Me.chkTheta3.TabIndex = 56
        Me.chkTheta3.Text = "Theta3 Axis"
        Me.chkTheta3.UseVisualStyleBackColor = True
        Me.chkTheta3.Visible = False
        '
        'chkTheta2
        '
        Me.chkTheta2.AutoSize = True
        Me.chkTheta2.Location = New System.Drawing.Point(268, 720)
        Me.chkTheta2.Name = "chkTheta2"
        Me.chkTheta2.Size = New System.Drawing.Size(91, 16)
        Me.chkTheta2.TabIndex = 55
        Me.chkTheta2.Text = "Theta2 Axis"
        Me.chkTheta2.UseVisualStyleBackColor = True
        Me.chkTheta2.Visible = False
        '
        'btnHomming
        '
        Me.btnHomming.Location = New System.Drawing.Point(172, 201)
        Me.btnHomming.Name = "btnHomming"
        Me.btnHomming.Size = New System.Drawing.Size(105, 42)
        Me.btnHomming.TabIndex = 10
        Me.btnHomming.Text = "Homming"
        Me.btnHomming.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.lblY2Pos)
        Me.GroupBox8.Controls.Add(Me.lblTheta4Pos)
        Me.GroupBox8.Controls.Add(Me.lblTheta2Pos)
        Me.GroupBox8.Controls.Add(Me.lblTheta3Pos)
        Me.GroupBox8.Controls.Add(Me.lblTheta1Pos)
        Me.GroupBox8.Controls.Add(Me.lblYPos)
        Me.GroupBox8.Controls.Add(Me.btnGetPosition)
        Me.GroupBox8.Controls.Add(Me.lblZPos)
        Me.GroupBox8.Controls.Add(Me.lblXPos)
        Me.GroupBox8.Location = New System.Drawing.Point(9, 286)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(268, 183)
        Me.GroupBox8.TabIndex = 50
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Current Position"
        '
        'lblY2Pos
        '
        Me.lblY2Pos.AutoSize = True
        Me.lblY2Pos.Location = New System.Drawing.Point(138, 72)
        Me.lblY2Pos.Name = "lblY2Pos"
        Me.lblY2Pos.Size = New System.Drawing.Size(39, 12)
        Me.lblY2Pos.TabIndex = 57
        Me.lblY2Pos.Text = "Y Pos"
        '
        'lblTheta4Pos
        '
        Me.lblTheta4Pos.AutoSize = True
        Me.lblTheta4Pos.Location = New System.Drawing.Point(10, 156)
        Me.lblTheta4Pos.Name = "lblTheta4Pos"
        Me.lblTheta4Pos.Size = New System.Drawing.Size(47, 12)
        Me.lblTheta4Pos.TabIndex = 56
        Me.lblTheta4Pos.Text = "θ4 Pos"
        Me.lblTheta4Pos.Visible = False
        '
        'lblTheta2Pos
        '
        Me.lblTheta2Pos.AutoSize = True
        Me.lblTheta2Pos.Location = New System.Drawing.Point(10, 112)
        Me.lblTheta2Pos.Name = "lblTheta2Pos"
        Me.lblTheta2Pos.Size = New System.Drawing.Size(47, 12)
        Me.lblTheta2Pos.TabIndex = 55
        Me.lblTheta2Pos.Text = "θ2 Pos"
        Me.lblTheta2Pos.Visible = False
        '
        'lblTheta3Pos
        '
        Me.lblTheta3Pos.AutoSize = True
        Me.lblTheta3Pos.Location = New System.Drawing.Point(10, 135)
        Me.lblTheta3Pos.Name = "lblTheta3Pos"
        Me.lblTheta3Pos.Size = New System.Drawing.Size(47, 12)
        Me.lblTheta3Pos.TabIndex = 54
        Me.lblTheta3Pos.Text = "θ3 Pos"
        Me.lblTheta3Pos.Visible = False
        '
        'lblTheta1Pos
        '
        Me.lblTheta1Pos.AutoSize = True
        Me.lblTheta1Pos.Location = New System.Drawing.Point(10, 88)
        Me.lblTheta1Pos.Name = "lblTheta1Pos"
        Me.lblTheta1Pos.Size = New System.Drawing.Size(47, 12)
        Me.lblTheta1Pos.TabIndex = 53
        Me.lblTheta1Pos.Text = "θ1 Pos"
        Me.lblTheta1Pos.Visible = False
        '
        'lblYPos
        '
        Me.lblYPos.AutoSize = True
        Me.lblYPos.Location = New System.Drawing.Point(138, 46)
        Me.lblYPos.Name = "lblYPos"
        Me.lblYPos.Size = New System.Drawing.Size(39, 12)
        Me.lblYPos.TabIndex = 52
        Me.lblYPos.Text = "Y Pos"
        '
        'btnGetPosition
        '
        Me.btnGetPosition.Location = New System.Drawing.Point(13, 20)
        Me.btnGetPosition.Name = "btnGetPosition"
        Me.btnGetPosition.Size = New System.Drawing.Size(104, 25)
        Me.btnGetPosition.TabIndex = 49
        Me.btnGetPosition.Text = "Get Current Pos"
        Me.btnGetPosition.UseVisualStyleBackColor = True
        '
        'lblZPos
        '
        Me.lblZPos.AutoSize = True
        Me.lblZPos.Location = New System.Drawing.Point(138, 98)
        Me.lblZPos.Name = "lblZPos"
        Me.lblZPos.Size = New System.Drawing.Size(39, 12)
        Me.lblZPos.TabIndex = 51
        Me.lblZPos.Text = "Z Pos"
        '
        'lblXPos
        '
        Me.lblXPos.AutoSize = True
        Me.lblXPos.Location = New System.Drawing.Point(138, 22)
        Me.lblXPos.Name = "lblXPos"
        Me.lblXPos.Size = New System.Drawing.Size(39, 12)
        Me.lblXPos.TabIndex = 50
        Me.lblXPos.Text = "X Pos"
        '
        'txtVelocity
        '
        Me.txtVelocity.Location = New System.Drawing.Point(19, 96)
        Me.txtVelocity.Name = "txtVelocity"
        Me.txtVelocity.Size = New System.Drawing.Size(142, 21)
        Me.txtVelocity.TabIndex = 12
        Me.txtVelocity.Text = "100"
        Me.txtVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label15.Location = New System.Drawing.Point(19, 71)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(143, 24)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Velocity (mm/s)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnZmove
        '
        Me.btnZmove.Location = New System.Drawing.Point(167, 80)
        Me.btnZmove.Name = "btnZmove"
        Me.btnZmove.Size = New System.Drawing.Size(105, 26)
        Me.btnZmove.TabIndex = 8
        Me.btnZmove.Text = "Z Axis Move"
        Me.btnZmove.UseVisualStyleBackColor = True
        '
        'btnYmove
        '
        Me.btnYmove.Location = New System.Drawing.Point(167, 50)
        Me.btnYmove.Name = "btnYmove"
        Me.btnYmove.Size = New System.Drawing.Size(105, 27)
        Me.btnYmove.TabIndex = 7
        Me.btnYmove.Text = "Y Axis Move"
        Me.btnYmove.UseVisualStyleBackColor = True
        '
        'btnXmove
        '
        Me.btnXmove.Location = New System.Drawing.Point(167, 20)
        Me.btnXmove.Name = "btnXmove"
        Me.btnXmove.Size = New System.Drawing.Size(105, 27)
        Me.btnXmove.TabIndex = 6
        Me.btnXmove.Text = "X Axis Move"
        Me.btnXmove.UseVisualStyleBackColor = True
        '
        'chkTheta1
        '
        Me.chkTheta1.AutoSize = True
        Me.chkTheta1.Location = New System.Drawing.Point(268, 698)
        Me.chkTheta1.Name = "chkTheta1"
        Me.chkTheta1.Size = New System.Drawing.Size(91, 16)
        Me.chkTheta1.TabIndex = 5
        Me.chkTheta1.Text = "Theta1 Axis"
        Me.chkTheta1.UseVisualStyleBackColor = True
        Me.chkTheta1.Visible = False
        '
        'rbAbs
        '
        Me.rbAbs.AutoSize = True
        Me.rbAbs.Checked = True
        Me.rbAbs.Location = New System.Drawing.Point(21, 146)
        Me.rbAbs.Name = "rbAbs"
        Me.rbAbs.Size = New System.Drawing.Size(44, 16)
        Me.rbAbs.TabIndex = 4
        Me.rbAbs.TabStop = True
        Me.rbAbs.Text = "abs"
        Me.rbAbs.UseVisualStyleBackColor = True
        '
        'rbMicroAdjust
        '
        Me.rbMicroAdjust.AutoSize = True
        Me.rbMicroAdjust.Location = New System.Drawing.Point(21, 124)
        Me.rbMicroAdjust.Name = "rbMicroAdjust"
        Me.rbMicroAdjust.Size = New System.Drawing.Size(103, 16)
        Me.rbMicroAdjust.TabIndex = 3
        Me.rbMicroAdjust.Text = "micro - adjust"
        Me.rbMicroAdjust.UseVisualStyleBackColor = True
        '
        'txtPosition
        '
        Me.txtPosition.Location = New System.Drawing.Point(19, 45)
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Size = New System.Drawing.Size(142, 21)
        Me.txtPosition.TabIndex = 2
        Me.txtPosition.Text = "20"
        Me.txtPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label14.Location = New System.Drawing.Point(19, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(143, 24)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Position (mm)"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_Theta4Move
        '
        Me.btn_Theta4Move.Location = New System.Drawing.Point(737, 787)
        Me.btn_Theta4Move.Name = "btn_Theta4Move"
        Me.btn_Theta4Move.Size = New System.Drawing.Size(105, 26)
        Me.btn_Theta4Move.TabIndex = 54
        Me.btn_Theta4Move.Text = "θ4 Axis Move"
        Me.btn_Theta4Move.UseVisualStyleBackColor = True
        Me.btn_Theta4Move.Visible = False
        '
        'btn_Theta3Move
        '
        Me.btn_Theta3Move.Location = New System.Drawing.Point(737, 757)
        Me.btn_Theta3Move.Name = "btn_Theta3Move"
        Me.btn_Theta3Move.Size = New System.Drawing.Size(105, 26)
        Me.btn_Theta3Move.TabIndex = 53
        Me.btn_Theta3Move.Text = "θ3 Axis Move"
        Me.btn_Theta3Move.UseVisualStyleBackColor = True
        Me.btn_Theta3Move.Visible = False
        '
        'btn_Theta2Move
        '
        Me.btn_Theta2Move.Location = New System.Drawing.Point(737, 727)
        Me.btn_Theta2Move.Name = "btn_Theta2Move"
        Me.btn_Theta2Move.Size = New System.Drawing.Size(105, 26)
        Me.btn_Theta2Move.TabIndex = 52
        Me.btn_Theta2Move.Text = "θ2 Axis Move"
        Me.btn_Theta2Move.UseVisualStyleBackColor = True
        Me.btn_Theta2Move.Visible = False
        '
        'btnTheta1Move
        '
        Me.btnTheta1Move.Location = New System.Drawing.Point(737, 698)
        Me.btnTheta1Move.Name = "btnTheta1Move"
        Me.btnTheta1Move.Size = New System.Drawing.Size(105, 26)
        Me.btnTheta1Move.TabIndex = 51
        Me.btnTheta1Move.Text = "θ1 Axis Move"
        Me.btnTheta1Move.UseVisualStyleBackColor = True
        Me.btnTheta1Move.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.GroupBox1)
        Me.GroupBox7.Controls.Add(Me.GroupBox2)
        Me.GroupBox7.Controls.Add(Me.GroupBox3)
        Me.GroupBox7.Location = New System.Drawing.Point(396, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(287, 333)
        Me.GroupBox7.TabIndex = 57
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Controls"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbSelStatus)
        Me.GroupBox1.Controls.Add(Me.btnSetStatus)
        Me.GroupBox1.Controls.Add(Me.tbStatusValue)
        Me.GroupBox1.Controls.Add(Me.btnGetStatus)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(271, 85)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "System Status"
        '
        'cbSelStatus
        '
        Me.cbSelStatus.FormattingEnabled = True
        Me.cbSelStatus.Items.AddRange(New Object() {"Power On", "Power Down", "Teaching Mode", "Auto Mode", "Manual Mode", "Processing", "PLC 수동조작 (NOT USE)", "Motor Moving (NOT USE)"})
        Me.cbSelStatus.Location = New System.Drawing.Point(15, 20)
        Me.cbSelStatus.Name = "cbSelStatus"
        Me.cbSelStatus.Size = New System.Drawing.Size(180, 20)
        Me.cbSelStatus.TabIndex = 25
        '
        'btnSetStatus
        '
        Me.btnSetStatus.Location = New System.Drawing.Point(201, 21)
        Me.btnSetStatus.Name = "btnSetStatus"
        Me.btnSetStatus.Size = New System.Drawing.Size(61, 18)
        Me.btnSetStatus.TabIndex = 24
        Me.btnSetStatus.Text = "Set"
        Me.btnSetStatus.UseVisualStyleBackColor = True
        '
        'tbStatusValue
        '
        Me.tbStatusValue.Location = New System.Drawing.Point(15, 48)
        Me.tbStatusValue.Name = "tbStatusValue"
        Me.tbStatusValue.Size = New System.Drawing.Size(180, 21)
        Me.tbStatusValue.TabIndex = 26
        Me.tbStatusValue.Visible = False
        '
        'btnGetStatus
        '
        Me.btnGetStatus.Location = New System.Drawing.Point(201, 50)
        Me.btnGetStatus.Name = "btnGetStatus"
        Me.btnGetStatus.Size = New System.Drawing.Size(61, 18)
        Me.btnGetStatus.TabIndex = 27
        Me.btnGetStatus.Text = "Get"
        Me.btnGetStatus.UseVisualStyleBackColor = True
        Me.btnGetStatus.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbSelDISignal)
        Me.GroupBox2.Controls.Add(Me.tbDIValue)
        Me.GroupBox2.Controls.Add(Me.btnSetDI)
        Me.GroupBox2.Controls.Add(Me.btnGetDI)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 111)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(271, 101)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Digital Input(Alarm)"
        Me.GroupBox2.Visible = False
        '
        'cbSelDISignal
        '
        Me.cbSelDISignal.FormattingEnabled = True
        Me.cbSelDISignal.Items.AddRange(New Object() {"No Error", "Emergency", "Fire", "Heater", "Current Limit", "Interrock"})
        Me.cbSelDISignal.Location = New System.Drawing.Point(15, 22)
        Me.cbSelDISignal.Name = "cbSelDISignal"
        Me.cbSelDISignal.Size = New System.Drawing.Size(180, 20)
        Me.cbSelDISignal.TabIndex = 30
        '
        'tbDIValue
        '
        Me.tbDIValue.Location = New System.Drawing.Point(15, 62)
        Me.tbDIValue.Name = "tbDIValue"
        Me.tbDIValue.Size = New System.Drawing.Size(180, 21)
        Me.tbDIValue.TabIndex = 28
        '
        'btnSetDI
        '
        Me.btnSetDI.Location = New System.Drawing.Point(201, 20)
        Me.btnSetDI.Name = "btnSetDI"
        Me.btnSetDI.Size = New System.Drawing.Size(61, 30)
        Me.btnSetDI.TabIndex = 28
        Me.btnSetDI.Text = "Set"
        Me.btnSetDI.UseVisualStyleBackColor = True
        '
        'btnGetDI
        '
        Me.btnGetDI.Location = New System.Drawing.Point(201, 56)
        Me.btnGetDI.Name = "btnGetDI"
        Me.btnGetDI.Size = New System.Drawing.Size(61, 30)
        Me.btnGetDI.TabIndex = 29
        Me.btnGetDI.Text = "Get"
        Me.btnGetDI.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbSelDOSignal)
        Me.GroupBox3.Controls.Add(Me.tbDOValue)
        Me.GroupBox3.Controls.Add(Me.btnSetDO)
        Me.GroupBox3.Controls.Add(Me.btnGetDO)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 218)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(271, 101)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Digital Output(Tower Lamp)"
        Me.GroupBox3.Visible = False
        '
        'cbSelDOSignal
        '
        Me.cbSelDOSignal.FormattingEnabled = True
        Me.cbSelDOSignal.Items.AddRange(New Object() {"All OFF", "RED", "YELLOW", "GREEN", "BLUE"})
        Me.cbSelDOSignal.Location = New System.Drawing.Point(15, 22)
        Me.cbSelDOSignal.Name = "cbSelDOSignal"
        Me.cbSelDOSignal.Size = New System.Drawing.Size(180, 20)
        Me.cbSelDOSignal.TabIndex = 30
        '
        'tbDOValue
        '
        Me.tbDOValue.Location = New System.Drawing.Point(15, 62)
        Me.tbDOValue.Name = "tbDOValue"
        Me.tbDOValue.Size = New System.Drawing.Size(180, 21)
        Me.tbDOValue.TabIndex = 28
        '
        'btnSetDO
        '
        Me.btnSetDO.Location = New System.Drawing.Point(201, 20)
        Me.btnSetDO.Name = "btnSetDO"
        Me.btnSetDO.Size = New System.Drawing.Size(61, 30)
        Me.btnSetDO.TabIndex = 28
        Me.btnSetDO.Text = "Set"
        Me.btnSetDO.UseVisualStyleBackColor = True
        '
        'btnGetDO
        '
        Me.btnGetDO.Location = New System.Drawing.Point(201, 56)
        Me.btnGetDO.Name = "btnGetDO"
        Me.btnGetDO.Size = New System.Drawing.Size(61, 30)
        Me.btnGetDO.TabIndex = 29
        Me.btnGetDO.Text = "Get"
        Me.btnGetDO.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.chkZ)
        Me.GroupBox12.Controls.Add(Me.btnSetVelocity)
        Me.GroupBox12.Controls.Add(Me.chkY)
        Me.GroupBox12.Controls.Add(Me.Label11)
        Me.GroupBox12.Controls.Add(Me.tbVelocity_Z)
        Me.GroupBox12.Controls.Add(Me.Label13)
        Me.GroupBox12.Controls.Add(Me.Label12)
        Me.GroupBox12.Controls.Add(Me.tbVelocity_X)
        Me.GroupBox12.Controls.Add(Me.tbVelocity_Y)
        Me.GroupBox12.Location = New System.Drawing.Point(13, 516)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(172, 151)
        Me.GroupBox12.TabIndex = 56
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "JOG Control"
        '
        'btnSetVelocity
        '
        Me.btnSetVelocity.Location = New System.Drawing.Point(72, 112)
        Me.btnSetVelocity.Name = "btnSetVelocity"
        Me.btnSetVelocity.Size = New System.Drawing.Size(93, 25)
        Me.btnSetVelocity.TabIndex = 49
        Me.btnSetVelocity.Text = "1.Set Velocity"
        Me.btnSetVelocity.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 12)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "X Velocity :"
        '
        'tbVelocity_Z
        '
        Me.tbVelocity_Z.Location = New System.Drawing.Point(94, 76)
        Me.tbVelocity_Z.Name = "tbVelocity_Z"
        Me.tbVelocity_Z.Size = New System.Drawing.Size(72, 21)
        Me.tbVelocity_Z.TabIndex = 47
        Me.tbVelocity_Z.Text = "50"
        Me.tbVelocity_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 12)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Z Velocity :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 12)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Y Velocity :"
        '
        'tbVelocity_X
        '
        Me.tbVelocity_X.Location = New System.Drawing.Point(94, 22)
        Me.tbVelocity_X.Name = "tbVelocity_X"
        Me.tbVelocity_X.Size = New System.Drawing.Size(72, 21)
        Me.tbVelocity_X.TabIndex = 43
        Me.tbVelocity_X.Text = "50"
        Me.tbVelocity_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbVelocity_Y
        '
        Me.tbVelocity_Y.Location = New System.Drawing.Point(94, 49)
        Me.tbVelocity_Y.Name = "tbVelocity_Y"
        Me.tbVelocity_Y.Size = New System.Drawing.Size(72, 21)
        Me.tbVelocity_Y.TabIndex = 45
        Me.tbVelocity_Y.Text = "50"
        Me.tbVelocity_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 698)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 12)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "θ Velocity : "
        Me.Label3.Visible = False
        '
        'tbVelocity_Theta
        '
        Me.tbVelocity_Theta.Location = New System.Drawing.Point(100, 693)
        Me.tbVelocity_Theta.Name = "tbVelocity_Theta"
        Me.tbVelocity_Theta.Size = New System.Drawing.Size(72, 21)
        Me.tbVelocity_Theta.TabIndex = 49
        Me.tbVelocity_Theta.Text = "10"
        Me.tbVelocity_Theta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbVelocity_Theta.Visible = False
        '
        'gbJOG
        '
        Me.gbJOG.Controls.Add(Me.tlpJOG)
        Me.gbJOG.Location = New System.Drawing.Point(13, 222)
        Me.gbJOG.Name = "gbJOG"
        Me.gbJOG.Size = New System.Drawing.Size(377, 285)
        Me.gbJOG.TabIndex = 55
        Me.gbJOG.TabStop = False
        Me.gbJOG.Text = "Jog Control"
        '
        'tlpJOG
        '
        Me.tlpJOG.ColumnCount = 3
        Me.tlpJOG.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpJOG.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlpJOG.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlpJOG.Controls.Add(Me.btnR, 2, 1)
        Me.tlpJOG.Controls.Add(Me.btnDown, 1, 2)
        Me.tlpJOG.Controls.Add(Me.btnUP, 1, 0)
        Me.tlpJOG.Controls.Add(Me.btnStop, 1, 1)
        Me.tlpJOG.Controls.Add(Me.btnL, 0, 1)
        Me.tlpJOG.Location = New System.Drawing.Point(9, 11)
        Me.tlpJOG.Name = "tlpJOG"
        Me.tlpJOG.RowCount = 3
        Me.tlpJOG.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpJOG.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpJOG.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpJOG.Size = New System.Drawing.Size(345, 268)
        Me.tlpJOG.TabIndex = 10
        '
        'btnR
        '
        Me.btnR.BackgroundImage = Global.M7000.My.Resources.Resources._5
        Me.btnR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnR.Location = New System.Drawing.Point(232, 92)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(96, 60)
        Me.btnR.TabIndex = 5
        Me.btnR.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.BackgroundImage = Global.M7000.My.Resources.Resources._7
        Me.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDown.Location = New System.Drawing.Point(117, 181)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(93, 62)
        Me.btnDown.TabIndex = 7
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUP
        '
        Me.btnUP.BackgroundImage = Global.M7000.My.Resources.Resources._2
        Me.btnUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUP.Location = New System.Drawing.Point(117, 3)
        Me.btnUP.Name = "btnUP"
        Me.btnUP.Size = New System.Drawing.Size(93, 60)
        Me.btnUP.TabIndex = 1
        Me.btnUP.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.BackgroundImage = Global.M7000.My.Resources.Resources._stop
        Me.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnStop.Location = New System.Drawing.Point(117, 92)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(93, 60)
        Me.btnStop.TabIndex = 4
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnL
        '
        Me.btnL.BackgroundImage = Global.M7000.My.Resources.Resources._4
        Me.btnL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnL.Location = New System.Drawing.Point(3, 92)
        Me.btnL.Name = "btnL"
        Me.btnL.Size = New System.Drawing.Size(93, 60)
        Me.btnL.TabIndex = 3
        Me.btnL.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.tbIPAdress4)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.tbIPAdress3)
        Me.GroupBox5.Controls.Add(Me.tbIPAdress2)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.btnConnection)
        Me.GroupBox5.Controls.Add(Me.tbIPAdress1)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.btnDisconnection)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.TextBox2)
        Me.GroupBox5.Controls.Add(Me.TextBox1)
        Me.GroupBox5.Controls.Add(Me.btnSend)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(375, 204)
        Me.GroupBox5.TabIndex = 54
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Communication"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(293, 30)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(9, 12)
        Me.Label21.TabIndex = 29
        Me.Label21.Text = "."
        '
        'tbIPAdress4
        '
        Me.tbIPAdress4.Location = New System.Drawing.Point(303, 24)
        Me.tbIPAdress4.Name = "tbIPAdress4"
        Me.tbIPAdress4.Size = New System.Drawing.Size(55, 21)
        Me.tbIPAdress4.TabIndex = 28
        Me.tbIPAdress4.Text = "10"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(226, 29)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(9, 12)
        Me.Label20.TabIndex = 27
        Me.Label20.Text = "."
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(157, 30)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(9, 12)
        Me.Label19.TabIndex = 26
        Me.Label19.Text = "."
        '
        'tbIPAdress3
        '
        Me.tbIPAdress3.Location = New System.Drawing.Point(236, 23)
        Me.tbIPAdress3.Name = "tbIPAdress3"
        Me.tbIPAdress3.Size = New System.Drawing.Size(55, 21)
        Me.tbIPAdress3.TabIndex = 24
        Me.tbIPAdress3.Text = "1"
        '
        'tbIPAdress2
        '
        Me.tbIPAdress2.Location = New System.Drawing.Point(167, 23)
        Me.tbIPAdress2.Name = "tbIPAdress2"
        Me.tbIPAdress2.Size = New System.Drawing.Size(55, 21)
        Me.tbIPAdress2.TabIndex = 23
        Me.tbIPAdress2.Text = "168"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "IP Adress : "
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(130, 59)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(105, 37)
        Me.btnConnection.TabIndex = 0
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'tbIPAdress1
        '
        Me.tbIPAdress1.Location = New System.Drawing.Point(100, 22)
        Me.tbIPAdress1.Name = "tbIPAdress1"
        Me.tbIPAdress1.Size = New System.Drawing.Size(55, 21)
        Me.tbIPAdress1.TabIndex = 2
        Me.tbIPAdress1.Text = "192"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(108, 186)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 12)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "00RSS0106%DW010"
        '
        'btnDisconnection
        '
        Me.btnDisconnection.Location = New System.Drawing.Point(242, 59)
        Me.btnDisconnection.Name = "btnDisconnection"
        Me.btnDisconnection.Size = New System.Drawing.Size(105, 37)
        Me.btnDisconnection.TabIndex = 15
        Me.btnDisconnection.Text = "Disconnection"
        Me.btnDisconnection.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 158)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 12)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Rcv Data :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 12)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Command : "
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(94, 155)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(152, 21)
        Me.TextBox2.TabIndex = 18
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(94, 131)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(152, 21)
        Me.TextBox1.TabIndex = 13
        '
        'btnSend
        '
        Me.btnSend.Enabled = False
        Me.btnSend.Location = New System.Drawing.Point(252, 155)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(112, 21)
        Me.btnSend.TabIndex = 16
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_MotorMoving)
        Me.GroupBox9.Controls.Add(Me.LbLed3)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_Pause)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_SafetyMode_Teach)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_SystemManualMode)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_Processing)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_ManualMode)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_AutoMode)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_TeachingMode)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_PowerDown)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_PowerON)
        Me.GroupBox9.Location = New System.Drawing.Point(703, 24)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(210, 380)
        Me.GroupBox9.TabIndex = 61
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "System Status"
        '
        'ledSysStatus_MotorMoving
        '
        Me.ledSysStatus_MotorMoving.AutoSize = True
        Me.ledSysStatus_MotorMoving.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_MotorMoving.BlinkInterval = 500
        Me.ledSysStatus_MotorMoving.Label = "Motor Moving"
        Me.ledSysStatus_MotorMoving.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_MotorMoving.LedColor = System.Drawing.Color.Blue
        Me.ledSysStatus_MotorMoving.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_MotorMoving.Location = New System.Drawing.Point(11, 340)
        Me.ledSysStatus_MotorMoving.Name = "ledSysStatus_MotorMoving"
        Me.ledSysStatus_MotorMoving.Renderer = Nothing
        Me.ledSysStatus_MotorMoving.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_MotorMoving.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_MotorMoving.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_MotorMoving.TabIndex = 10
        '
        'LbLed3
        '
        Me.LbLed3.AutoSize = True
        Me.LbLed3.BackColor = System.Drawing.Color.Transparent
        Me.LbLed3.BlinkInterval = 500
        Me.LbLed3.Label = ""
        Me.LbLed3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.LbLed3.LedColor = System.Drawing.Color.Blue
        Me.LbLed3.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.LbLed3.Location = New System.Drawing.Point(11, 308)
        Me.LbLed3.Name = "LbLed3"
        Me.LbLed3.Renderer = Nothing
        Me.LbLed3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LbLed3.Size = New System.Drawing.Size(191, 32)
        Me.LbLed3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.LbLed3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.LbLed3.TabIndex = 9
        '
        'ledSysStatus_Pause
        '
        Me.ledSysStatus_Pause.AutoSize = True
        Me.ledSysStatus_Pause.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_Pause.BlinkInterval = 500
        Me.ledSysStatus_Pause.Label = ""
        Me.ledSysStatus_Pause.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_Pause.LedColor = System.Drawing.Color.Blue
        Me.ledSysStatus_Pause.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_Pause.Location = New System.Drawing.Point(11, 276)
        Me.ledSysStatus_Pause.Name = "ledSysStatus_Pause"
        Me.ledSysStatus_Pause.Renderer = Nothing
        Me.ledSysStatus_Pause.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_Pause.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_Pause.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_Pause.TabIndex = 8
        '
        'ledSysStatus_SafetyMode_Teach
        '
        Me.ledSysStatus_SafetyMode_Teach.AutoSize = True
        Me.ledSysStatus_SafetyMode_Teach.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_SafetyMode_Teach.BlinkInterval = 500
        Me.ledSysStatus_SafetyMode_Teach.Label = ""
        Me.ledSysStatus_SafetyMode_Teach.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_SafetyMode_Teach.LedColor = System.Drawing.Color.Blue
        Me.ledSysStatus_SafetyMode_Teach.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_SafetyMode_Teach.Location = New System.Drawing.Point(11, 244)
        Me.ledSysStatus_SafetyMode_Teach.Name = "ledSysStatus_SafetyMode_Teach"
        Me.ledSysStatus_SafetyMode_Teach.Renderer = Nothing
        Me.ledSysStatus_SafetyMode_Teach.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_SafetyMode_Teach.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_SafetyMode_Teach.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_SafetyMode_Teach.TabIndex = 7
        '
        'ledSysStatus_SystemManualMode
        '
        Me.ledSysStatus_SystemManualMode.AutoSize = True
        Me.ledSysStatus_SystemManualMode.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_SystemManualMode.BlinkInterval = 500
        Me.ledSysStatus_SystemManualMode.Label = "PLC 수동 조작"
        Me.ledSysStatus_SystemManualMode.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_SystemManualMode.LedColor = System.Drawing.Color.Blue
        Me.ledSysStatus_SystemManualMode.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_SystemManualMode.Location = New System.Drawing.Point(11, 212)
        Me.ledSysStatus_SystemManualMode.Name = "ledSysStatus_SystemManualMode"
        Me.ledSysStatus_SystemManualMode.Renderer = Nothing
        Me.ledSysStatus_SystemManualMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ledSysStatus_SystemManualMode.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_SystemManualMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_SystemManualMode.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_SystemManualMode.TabIndex = 6
        '
        'ledSysStatus_Processing
        '
        Me.ledSysStatus_Processing.AutoSize = True
        Me.ledSysStatus_Processing.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_Processing.BlinkInterval = 500
        Me.ledSysStatus_Processing.Label = "Processing"
        Me.ledSysStatus_Processing.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_Processing.LedColor = System.Drawing.Color.Blue
        Me.ledSysStatus_Processing.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_Processing.Location = New System.Drawing.Point(11, 180)
        Me.ledSysStatus_Processing.Name = "ledSysStatus_Processing"
        Me.ledSysStatus_Processing.Renderer = Nothing
        Me.ledSysStatus_Processing.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_Processing.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_Processing.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_Processing.TabIndex = 5
        '
        'ledSysStatus_ManualMode
        '
        Me.ledSysStatus_ManualMode.AutoSize = True
        Me.ledSysStatus_ManualMode.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_ManualMode.BlinkInterval = 500
        Me.ledSysStatus_ManualMode.Label = "Manual Mode"
        Me.ledSysStatus_ManualMode.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_ManualMode.LedColor = System.Drawing.Color.Red
        Me.ledSysStatus_ManualMode.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_ManualMode.Location = New System.Drawing.Point(11, 148)
        Me.ledSysStatus_ManualMode.Name = "ledSysStatus_ManualMode"
        Me.ledSysStatus_ManualMode.Renderer = Nothing
        Me.ledSysStatus_ManualMode.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_ManualMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_ManualMode.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_ManualMode.TabIndex = 4
        '
        'ledSysStatus_AutoMode
        '
        Me.ledSysStatus_AutoMode.AutoSize = True
        Me.ledSysStatus_AutoMode.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_AutoMode.BlinkInterval = 500
        Me.ledSysStatus_AutoMode.Label = "Auto Mode"
        Me.ledSysStatus_AutoMode.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_AutoMode.LedColor = System.Drawing.Color.DarkOrange
        Me.ledSysStatus_AutoMode.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_AutoMode.Location = New System.Drawing.Point(11, 116)
        Me.ledSysStatus_AutoMode.Name = "ledSysStatus_AutoMode"
        Me.ledSysStatus_AutoMode.Renderer = Nothing
        Me.ledSysStatus_AutoMode.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_AutoMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_AutoMode.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_AutoMode.TabIndex = 3
        '
        'ledSysStatus_TeachingMode
        '
        Me.ledSysStatus_TeachingMode.AutoSize = True
        Me.ledSysStatus_TeachingMode.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_TeachingMode.BlinkInterval = 500
        Me.ledSysStatus_TeachingMode.Label = "Teaching Mode"
        Me.ledSysStatus_TeachingMode.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_TeachingMode.LedColor = System.Drawing.Color.Lime
        Me.ledSysStatus_TeachingMode.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_TeachingMode.Location = New System.Drawing.Point(11, 84)
        Me.ledSysStatus_TeachingMode.Name = "ledSysStatus_TeachingMode"
        Me.ledSysStatus_TeachingMode.Renderer = Nothing
        Me.ledSysStatus_TeachingMode.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_TeachingMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_TeachingMode.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_TeachingMode.TabIndex = 2
        '
        'ledSysStatus_PowerDown
        '
        Me.ledSysStatus_PowerDown.AutoSize = True
        Me.ledSysStatus_PowerDown.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_PowerDown.BlinkInterval = 500
        Me.ledSysStatus_PowerDown.Label = "Power Down"
        Me.ledSysStatus_PowerDown.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_PowerDown.LedColor = System.Drawing.Color.Red
        Me.ledSysStatus_PowerDown.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_PowerDown.Location = New System.Drawing.Point(11, 52)
        Me.ledSysStatus_PowerDown.Name = "ledSysStatus_PowerDown"
        Me.ledSysStatus_PowerDown.Renderer = Nothing
        Me.ledSysStatus_PowerDown.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_PowerDown.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_PowerDown.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_PowerDown.TabIndex = 1
        '
        'ledSysStatus_PowerON
        '
        Me.ledSysStatus_PowerON.AutoSize = True
        Me.ledSysStatus_PowerON.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_PowerON.BlinkInterval = 500
        Me.ledSysStatus_PowerON.Label = "Power On"
        Me.ledSysStatus_PowerON.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_PowerON.LedColor = System.Drawing.Color.Lime
        Me.ledSysStatus_PowerON.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_PowerON.Location = New System.Drawing.Point(11, 20)
        Me.ledSysStatus_PowerON.Name = "ledSysStatus_PowerON"
        Me.ledSysStatus_PowerON.Renderer = Nothing
        Me.ledSysStatus_PowerON.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_PowerON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_PowerON.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_PowerON.TabIndex = 0
        '
        'ledConnectionStateCheck
        '
        Me.ledConnectionStateCheck.AutoSize = True
        Me.ledConnectionStateCheck.BackColor = System.Drawing.Color.Transparent
        Me.ledConnectionStateCheck.BlinkInterval = 500
        Me.ledConnectionStateCheck.Label = "Connection State"
        Me.ledConnectionStateCheck.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top
        Me.ledConnectionStateCheck.LedColor = System.Drawing.Color.Blue
        Me.ledConnectionStateCheck.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledConnectionStateCheck.Location = New System.Drawing.Point(703, 407)
        Me.ledConnectionStateCheck.Name = "ledConnectionStateCheck"
        Me.ledConnectionStateCheck.Renderer = Nothing
        Me.ledConnectionStateCheck.Size = New System.Drawing.Size(137, 51)
        Me.ledConnectionStateCheck.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledConnectionStateCheck.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledConnectionStateCheck.TabIndex = 60
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.GroupBox11)
        Me.GroupBox6.Controls.Add(Me.GroupBox4)
        Me.GroupBox6.Location = New System.Drawing.Point(703, 464)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(286, 216)
        Me.GroupBox6.TabIndex = 59
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Function Test"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Label9)
        Me.GroupBox11.Controls.Add(Me.Label10)
        Me.GroupBox11.Controls.Add(Me.TextBox3)
        Me.GroupBox11.Controls.Add(Me.Button2)
        Me.GroupBox11.Controls.Add(Me.TextBox4)
        Me.GroupBox11.Location = New System.Drawing.Point(11, 115)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(246, 88)
        Me.GroupBox11.TabIndex = 37
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "HEX To Binery"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 12)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Input :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 12)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Output :"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(59, 25)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(96, 21)
        Me.TextBox3.TabIndex = 33
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(161, 30)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(73, 41)
        Me.Button2.TabIndex = 35
        Me.Button2.Text = "Convert"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(59, 52)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(96, 21)
        Me.TextBox4.TabIndex = 34
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.tbInDex)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.tbOutBinery)
        Me.GroupBox4.Location = New System.Drawing.Point(13, 21)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(246, 88)
        Me.GroupBox4.TabIndex = 36
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Dec To Binery"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 12)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Input :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 12)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Output :"
        '
        'tbInDex
        '
        Me.tbInDex.Location = New System.Drawing.Point(59, 25)
        Me.tbInDex.Name = "tbInDex"
        Me.tbInDex.Size = New System.Drawing.Size(96, 21)
        Me.tbInDex.TabIndex = 33
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(161, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 41)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "Convert"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbOutBinery
        '
        Me.tbOutBinery.Location = New System.Drawing.Point(59, 52)
        Me.tbOutBinery.Name = "tbOutBinery"
        Me.tbOutBinery.Size = New System.Drawing.Size(96, 21)
        Me.tbOutBinery.TabIndex = 34
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'btnAllReset
        '
        Me.btnAllReset.Location = New System.Drawing.Point(292, 532)
        Me.btnAllReset.Name = "btnAllReset"
        Me.btnAllReset.Size = New System.Drawing.Size(95, 25)
        Me.btnAllReset.TabIndex = 66
        Me.btnAllReset.Text = "전체 초기화"
        Me.btnAllReset.UseVisualStyleBackColor = True
        '
        'BtnAlaramReset
        '
        Me.BtnAlaramReset.Location = New System.Drawing.Point(191, 531)
        Me.BtnAlaramReset.Name = "BtnAlaramReset"
        Me.BtnAlaramReset.Size = New System.Drawing.Size(95, 25)
        Me.BtnAlaramReset.TabIndex = 65
        Me.BtnAlaramReset.Text = "Alarm Reset"
        Me.BtnAlaramReset.UseVisualStyleBackColor = True
        '
        'btnJogOFF
        '
        Me.btnJogOFF.Location = New System.Drawing.Point(292, 562)
        Me.btnJogOFF.Name = "btnJogOFF"
        Me.btnJogOFF.Size = New System.Drawing.Size(95, 24)
        Me.btnJogOFF.TabIndex = 63
        Me.btnJogOFF.Text = "JOG OFF"
        Me.btnJogOFF.UseVisualStyleBackColor = True
        '
        'btnJogON
        '
        Me.btnJogON.Location = New System.Drawing.Point(191, 562)
        Me.btnJogON.Name = "btnJogON"
        Me.btnJogON.Size = New System.Drawing.Size(95, 25)
        Me.btnJogON.TabIndex = 62
        Me.btnJogON.Text = "JOG ON"
        Me.btnJogON.UseVisualStyleBackColor = True
        '
        'btnInterrock
        '
        Me.btnInterrock.Location = New System.Drawing.Point(139, 734)
        Me.btnInterrock.Name = "btnInterrock"
        Me.btnInterrock.Size = New System.Drawing.Size(79, 38)
        Me.btnInterrock.TabIndex = 64
        Me.btnInterrock.Text = "Interrock ON"
        Me.btnInterrock.UseVisualStyleBackColor = True
        Me.btnInterrock.Visible = False
        '
        'chkY
        '
        Me.chkY.AutoSize = True
        Me.chkY.Location = New System.Drawing.Point(5, 106)
        Me.chkY.Name = "chkY"
        Me.chkY.Size = New System.Drawing.Size(61, 16)
        Me.chkY.TabIndex = 67
        Me.chkY.Text = "Y Axis"
        Me.chkY.UseVisualStyleBackColor = True
        '
        'chkZ
        '
        Me.chkZ.AutoSize = True
        Me.chkZ.Location = New System.Drawing.Point(5, 125)
        Me.chkZ.Name = "chkZ"
        Me.chkZ.Size = New System.Drawing.Size(61, 16)
        Me.chkZ.TabIndex = 68
        Me.chkZ.Text = "Z Axis"
        Me.chkZ.UseVisualStyleBackColor = True
        '
        'btnSWReadyOFF
        '
        Me.btnSWReadyOFF.Location = New System.Drawing.Point(292, 589)
        Me.btnSWReadyOFF.Name = "btnSWReadyOFF"
        Me.btnSWReadyOFF.Size = New System.Drawing.Size(95, 24)
        Me.btnSWReadyOFF.TabIndex = 68
        Me.btnSWReadyOFF.Text = "Ready OFF"
        Me.btnSWReadyOFF.UseVisualStyleBackColor = True
        '
        'btnSWReadyON
        '
        Me.btnSWReadyON.Location = New System.Drawing.Point(191, 589)
        Me.btnSWReadyON.Name = "btnSWReadyON"
        Me.btnSWReadyON.Size = New System.Drawing.Size(95, 25)
        Me.btnSWReadyON.TabIndex = 67
        Me.btnSWReadyON.Text = "Ready ON"
        Me.btnSWReadyON.UseVisualStyleBackColor = True
        '
        'frmPLCMotionControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 861)
        Me.Controls.Add(Me.btnSWReadyOFF)
        Me.Controls.Add(Me.btnSWReadyON)
        Me.Controls.Add(Me.chkTheta4)
        Me.Controls.Add(Me.btnAllReset)
        Me.Controls.Add(Me.chkTheta3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkTheta2)
        Me.Controls.Add(Me.tbVelocity_Theta)
        Me.Controls.Add(Me.BtnAlaramReset)
        Me.Controls.Add(Me.btnJogOFF)
        Me.Controls.Add(Me.btn_Theta4Move)
        Me.Controls.Add(Me.btnJogON)
        Me.Controls.Add(Me.btn_Theta3Move)
        Me.Controls.Add(Me.btnInterrock)
        Me.Controls.Add(Me.btn_Theta2Move)
        Me.Controls.Add(Me.chkTheta1)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.btnTheta1Move)
        Me.Controls.Add(Me.ledConnectionStateCheck)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.gbManualCtrl)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.gbJOG)
        Me.Controls.Add(Me.GroupBox5)
        Me.Name = "frmPLCMotionControl"
        Me.Text = "FrmPLCMotionControl"
        Me.gbManualCtrl.ResumeLayout(False)
        Me.gbManualCtrl.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.gbJOG.ResumeLayout(False)
        Me.tlpJOG.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbManualCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents lblYPos As System.Windows.Forms.Label
    Friend WithEvents btnGetPosition As System.Windows.Forms.Button
    Friend WithEvents lblZPos As System.Windows.Forms.Label
    Friend WithEvents lblXPos As System.Windows.Forms.Label
    Friend WithEvents txtVelocity As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnHomming As System.Windows.Forms.Button
    Friend WithEvents btnZmove As System.Windows.Forms.Button
    Friend WithEvents btnYmove As System.Windows.Forms.Button
    Friend WithEvents btnXmove As System.Windows.Forms.Button
    Friend WithEvents chkTheta1 As System.Windows.Forms.CheckBox
    Friend WithEvents rbAbs As System.Windows.Forms.RadioButton
    Friend WithEvents rbMicroAdjust As System.Windows.Forms.RadioButton
    Friend WithEvents txtPosition As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetStatus As System.Windows.Forms.Button
    Friend WithEvents tbStatusValue As System.Windows.Forms.TextBox
    Friend WithEvents btnGetStatus As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelDISignal As System.Windows.Forms.ComboBox
    Friend WithEvents tbDIValue As System.Windows.Forms.TextBox
    Friend WithEvents btnSetDI As System.Windows.Forms.Button
    Friend WithEvents btnGetDI As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelDOSignal As System.Windows.Forms.ComboBox
    Friend WithEvents tbDOValue As System.Windows.Forms.TextBox
    Friend WithEvents btnSetDO As System.Windows.Forms.Button
    Friend WithEvents btnGetDO As System.Windows.Forms.Button
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetVelocity As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbVelocity_Z As System.Windows.Forms.TextBox
    Friend WithEvents tbVelocity_X As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbVelocity_Y As System.Windows.Forms.TextBox
    Friend WithEvents gbJOG As System.Windows.Forms.GroupBox
    Friend WithEvents tlpJOG As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnR As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUP As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnL As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tbIPAdress4 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tbIPAdress3 As System.Windows.Forms.TextBox
    Friend WithEvents tbIPAdress2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents tbIPAdress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnDisconnection As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents ledSysStatus_MotorMoving As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents LbLed3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_Pause As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_SafetyMode_Teach As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_SystemManualMode As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_Processing As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_ManualMode As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_AutoMode As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_TeachingMode As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_PowerDown As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_PowerON As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledConnectionStateCheck As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbInDex As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tbOutBinery As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnAllReset As System.Windows.Forms.Button
    Friend WithEvents BtnAlaramReset As System.Windows.Forms.Button
    Friend WithEvents btnJogOFF As System.Windows.Forms.Button
    Friend WithEvents btnJogON As System.Windows.Forms.Button
    Friend WithEvents btnInterrock As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbVelocity_Theta As System.Windows.Forms.TextBox
    Friend WithEvents btn_Theta4Move As System.Windows.Forms.Button
    Friend WithEvents btn_Theta3Move As System.Windows.Forms.Button
    Friend WithEvents btn_Theta2Move As System.Windows.Forms.Button
    Friend WithEvents btnTheta1Move As System.Windows.Forms.Button
    Friend WithEvents lblTheta4Pos As System.Windows.Forms.Label
    Friend WithEvents lblTheta2Pos As System.Windows.Forms.Label
    Friend WithEvents lblTheta3Pos As System.Windows.Forms.Label
    Friend WithEvents lblTheta1Pos As System.Windows.Forms.Label
    Friend WithEvents chkTheta4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkTheta2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkTheta3 As System.Windows.Forms.CheckBox
    Friend WithEvents lblY2Pos As Label
    Friend WithEvents chkZ As CheckBox
    Friend WithEvents chkY As CheckBox
    Friend WithEvents btnSWReadyOFF As Button
    Friend WithEvents btnSWReadyON As Button
End Class
