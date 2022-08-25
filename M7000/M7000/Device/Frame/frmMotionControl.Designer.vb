<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMotionControl
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnZmove = New System.Windows.Forms.Button()
        Me.btnYmove = New System.Windows.Forms.Button()
        Me.btnXmove = New System.Windows.Forms.Button()
        Me.chkZ = New System.Windows.Forms.CheckBox()
        Me.rbAbs = New System.Windows.Forms.RadioButton()
        Me.rbMicroAdjust = New System.Windows.Forms.RadioButton()
        Me.txtPosition = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnRD = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnLD = New System.Windows.Forms.Button()
        Me.btnR = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnL = New System.Windows.Forms.Button()
        Me.btnRU = New System.Windows.Forms.Button()
        Me.btnUP = New System.Windows.Forms.Button()
        Me.btnLU = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txt_speed = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_pulse = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_decel = New System.Windows.Forms.TextBox()
        Me.txt_accel = New System.Windows.Forms.TextBox()
        Me.txt_velocity = New System.Windows.Forms.TextBox()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbo_encodermethod = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_pulsemethod = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_axiscount = New System.Windows.Forms.ComboBox()
        Me.btn_Initialize = New System.Windows.Forms.Button()
        Me.btn_getLimitlv = New System.Windows.Forms.Button()
        Me.set_maxspeed = New System.Windows.Forms.Button()
        Me.btn_GetPosition = New System.Windows.Forms.Button()
        Me.btn_SetPosition = New System.Windows.Forms.Button()
        Me.btn_stop = New System.Windows.Forms.Button()
        Me.btn_Zmove = New System.Windows.Forms.Button()
        Me.btn_Ymove = New System.Windows.Forms.Button()
        Me.btn_Xmove = New System.Windows.Forms.Button()
        Me.btn_XRYD = New System.Windows.Forms.Button()
        Me.btn_XLYD = New System.Windows.Forms.Button()
        Me.btn_XRYU = New System.Windows.Forms.Button()
        Me.btn_XLYU = New System.Windows.Forms.Button()
        Me.btn_Zdown = New System.Windows.Forms.Button()
        Me.btn_Zup = New System.Windows.Forms.Button()
        Me.btn_YDown = New System.Windows.Forms.Button()
        Me.btn_Yup = New System.Windows.Forms.Button()
        Me.JogXL = New System.Windows.Forms.Button()
        Me.btn_JogXR = New System.Windows.Forms.Button()
        Me.btn_emgallStop = New System.Windows.Forms.Button()
        Me.btn_allStop = New System.Windows.Forms.Button()
        Me.btn_Homing = New System.Windows.Forms.Button()
        Me.btn_ServoOff = New System.Windows.Forms.Button()
        Me.btn_ServoOn = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_AxisTheta = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbl_AxisZ = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_AxisY = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_AxisX = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.chkSlowLimit_Minus = New System.Windows.Forms.CheckBox()
        Me.chkSlowLimit_Plus = New System.Windows.Forms.CheckBox()
        Me.lblIO_SLimit_M = New System.Windows.Forms.Label()
        Me.lblIO_SLimit_P = New System.Windows.Forms.Label()
        Me.chkAlarm = New System.Windows.Forms.CheckBox()
        Me.chkSpeedLimit_Minus = New System.Windows.Forms.CheckBox()
        Me.chkSpeedLimit_Plus = New System.Windows.Forms.CheckBox()
        Me.lblIO_Alarm = New System.Windows.Forms.Label()
        Me.lblIO_Limit_M = New System.Windows.Forms.Label()
        Me.lblIO_Limit_P = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox7)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1326, 643)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.btnRD)
        Me.GroupBox4.Controls.Add(Me.btnDown)
        Me.GroupBox4.Controls.Add(Me.btnLD)
        Me.GroupBox4.Controls.Add(Me.btnR)
        Me.GroupBox4.Controls.Add(Me.btnStop)
        Me.GroupBox4.Controls.Add(Me.btnL)
        Me.GroupBox4.Controls.Add(Me.btnRU)
        Me.GroupBox4.Controls.Add(Me.btnUP)
        Me.GroupBox4.Controls.Add(Me.btnLU)
        Me.GroupBox4.Location = New System.Drawing.Point(670, 240)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(576, 374)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Motion Command"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Controls.Add(Me.btnZmove)
        Me.GroupBox5.Controls.Add(Me.btnYmove)
        Me.GroupBox5.Controls.Add(Me.btnXmove)
        Me.GroupBox5.Controls.Add(Me.chkZ)
        Me.GroupBox5.Controls.Add(Me.rbAbs)
        Me.GroupBox5.Controls.Add(Me.rbMicroAdjust)
        Me.GroupBox5.Controls.Add(Me.txtPosition)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Location = New System.Drawing.Point(367, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(194, 359)
        Me.GroupBox5.TabIndex = 9
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Set Parameter"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(22, 322)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(142, 38)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Z Axis Move"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnZmove
        '
        Me.btnZmove.Location = New System.Drawing.Point(23, 284)
        Me.btnZmove.Name = "btnZmove"
        Me.btnZmove.Size = New System.Drawing.Size(142, 38)
        Me.btnZmove.TabIndex = 8
        Me.btnZmove.Text = "Z Axis Move"
        Me.btnZmove.UseVisualStyleBackColor = True
        '
        'btnYmove
        '
        Me.btnYmove.Location = New System.Drawing.Point(23, 240)
        Me.btnYmove.Name = "btnYmove"
        Me.btnYmove.Size = New System.Drawing.Size(142, 38)
        Me.btnYmove.TabIndex = 7
        Me.btnYmove.Text = "Y Axis Move"
        Me.btnYmove.UseVisualStyleBackColor = True
        '
        'btnXmove
        '
        Me.btnXmove.Location = New System.Drawing.Point(23, 196)
        Me.btnXmove.Name = "btnXmove"
        Me.btnXmove.Size = New System.Drawing.Size(142, 38)
        Me.btnXmove.TabIndex = 6
        Me.btnXmove.Text = "X Axis Move"
        Me.btnXmove.UseVisualStyleBackColor = True
        '
        'chkZ
        '
        Me.chkZ.AutoSize = True
        Me.chkZ.Location = New System.Drawing.Point(38, 163)
        Me.chkZ.Name = "chkZ"
        Me.chkZ.Size = New System.Drawing.Size(61, 16)
        Me.chkZ.TabIndex = 5
        Me.chkZ.Text = "Z Axis"
        Me.chkZ.UseVisualStyleBackColor = True
        '
        'rbAbs
        '
        Me.rbAbs.AutoSize = True
        Me.rbAbs.Location = New System.Drawing.Point(38, 141)
        Me.rbAbs.Name = "rbAbs"
        Me.rbAbs.Size = New System.Drawing.Size(44, 16)
        Me.rbAbs.TabIndex = 4
        Me.rbAbs.Text = "abs"
        Me.rbAbs.UseVisualStyleBackColor = True
        '
        'rbMicroAdjust
        '
        Me.rbMicroAdjust.AutoSize = True
        Me.rbMicroAdjust.Checked = True
        Me.rbMicroAdjust.Location = New System.Drawing.Point(38, 119)
        Me.rbMicroAdjust.Name = "rbMicroAdjust"
        Me.rbMicroAdjust.Size = New System.Drawing.Size(103, 16)
        Me.rbMicroAdjust.TabIndex = 3
        Me.rbMicroAdjust.TabStop = True
        Me.rbMicroAdjust.Text = "micro - adjust"
        Me.rbMicroAdjust.UseVisualStyleBackColor = True
        '
        'txtPosition
        '
        Me.txtPosition.Location = New System.Drawing.Point(23, 83)
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Size = New System.Drawing.Size(142, 21)
        Me.txtPosition.TabIndex = 2
        Me.txtPosition.Text = "0.1"
        Me.txtPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label2.Location = New System.Drawing.Point(21, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Position (mm)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRD
        '
        Me.btnRD.BackgroundImage = Global.M7000.My.Resources.Resources._8
        Me.btnRD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRD.Location = New System.Drawing.Point(251, 252)
        Me.btnRD.Name = "btnRD"
        Me.btnRD.Size = New System.Drawing.Size(110, 110)
        Me.btnRD.TabIndex = 8
        Me.btnRD.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.BackgroundImage = Global.M7000.My.Resources.Resources._7
        Me.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDown.Location = New System.Drawing.Point(135, 252)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(110, 110)
        Me.btnDown.TabIndex = 7
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnLD
        '
        Me.btnLD.BackgroundImage = Global.M7000.My.Resources.Resources._6
        Me.btnLD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLD.Location = New System.Drawing.Point(19, 252)
        Me.btnLD.Name = "btnLD"
        Me.btnLD.Size = New System.Drawing.Size(110, 110)
        Me.btnLD.TabIndex = 6
        Me.btnLD.UseVisualStyleBackColor = True
        '
        'btnR
        '
        Me.btnR.BackgroundImage = Global.M7000.My.Resources.Resources._5
        Me.btnR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnR.Location = New System.Drawing.Point(251, 136)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(110, 110)
        Me.btnR.TabIndex = 5
        Me.btnR.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.BackgroundImage = Global.M7000.My.Resources.Resources._stop
        Me.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnStop.Location = New System.Drawing.Point(135, 136)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(110, 110)
        Me.btnStop.TabIndex = 4
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnL
        '
        Me.btnL.BackgroundImage = Global.M7000.My.Resources.Resources._4
        Me.btnL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnL.Location = New System.Drawing.Point(19, 136)
        Me.btnL.Name = "btnL"
        Me.btnL.Size = New System.Drawing.Size(110, 110)
        Me.btnL.TabIndex = 3
        Me.btnL.UseVisualStyleBackColor = True
        '
        'btnRU
        '
        Me.btnRU.AccessibleRole = System.Windows.Forms.AccessibleRole.Border
        Me.btnRU.BackgroundImage = Global.M7000.My.Resources.Resources._3
        Me.btnRU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRU.Location = New System.Drawing.Point(251, 20)
        Me.btnRU.Name = "btnRU"
        Me.btnRU.Size = New System.Drawing.Size(110, 110)
        Me.btnRU.TabIndex = 2
        Me.btnRU.UseVisualStyleBackColor = True
        '
        'btnUP
        '
        Me.btnUP.BackgroundImage = Global.M7000.My.Resources.Resources._2
        Me.btnUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUP.Location = New System.Drawing.Point(135, 20)
        Me.btnUP.Name = "btnUP"
        Me.btnUP.Size = New System.Drawing.Size(110, 110)
        Me.btnUP.TabIndex = 1
        Me.btnUP.UseVisualStyleBackColor = True
        '
        'btnLU
        '
        Me.btnLU.BackgroundImage = Global.M7000.My.Resources.Resources._1
        Me.btnLU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLU.Location = New System.Drawing.Point(19, 20)
        Me.btnLU.Name = "btnLU"
        Me.btnLU.Size = New System.Drawing.Size(110, 110)
        Me.btnLU.TabIndex = 0
        Me.btnLU.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.GroupBox6)
        Me.GroupBox3.Controls.Add(Me.btn_getLimitlv)
        Me.GroupBox3.Controls.Add(Me.set_maxspeed)
        Me.GroupBox3.Controls.Add(Me.btn_GetPosition)
        Me.GroupBox3.Controls.Add(Me.btn_SetPosition)
        Me.GroupBox3.Controls.Add(Me.btn_stop)
        Me.GroupBox3.Controls.Add(Me.btn_Zmove)
        Me.GroupBox3.Controls.Add(Me.btn_Ymove)
        Me.GroupBox3.Controls.Add(Me.btn_Xmove)
        Me.GroupBox3.Controls.Add(Me.btn_XRYD)
        Me.GroupBox3.Controls.Add(Me.btn_XLYD)
        Me.GroupBox3.Controls.Add(Me.btn_XRYU)
        Me.GroupBox3.Controls.Add(Me.btn_XLYU)
        Me.GroupBox3.Controls.Add(Me.btn_Zdown)
        Me.GroupBox3.Controls.Add(Me.btn_Zup)
        Me.GroupBox3.Controls.Add(Me.btn_YDown)
        Me.GroupBox3.Controls.Add(Me.btn_Yup)
        Me.GroupBox3.Controls.Add(Me.JogXL)
        Me.GroupBox3.Controls.Add(Me.btn_JogXR)
        Me.GroupBox3.Controls.Add(Me.btn_emgallStop)
        Me.GroupBox3.Controls.Add(Me.btn_allStop)
        Me.GroupBox3.Controls.Add(Me.btn_Homing)
        Me.GroupBox3.Controls.Add(Me.btn_ServoOff)
        Me.GroupBox3.Controls.Add(Me.btn_ServoOn)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 14)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(658, 600)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Motion Command"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(442, 493)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(139, 45)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Test"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txt_speed)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.txt_pulse)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Controls.Add(Me.txt_decel)
        Me.GroupBox6.Controls.Add(Me.txt_accel)
        Me.GroupBox6.Controls.Add(Me.txt_velocity)
        Me.GroupBox6.Controls.Add(Me.lbl1)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.cbo_encodermethod)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.cbo_pulsemethod)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.cbo_axiscount)
        Me.GroupBox6.Controls.Add(Me.btn_Initialize)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 20)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(637, 200)
        Me.GroupBox6.TabIndex = 25
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Init Set"
        '
        'txt_speed
        '
        Me.txt_speed.Enabled = False
        Me.txt_speed.Location = New System.Drawing.Point(556, 63)
        Me.txt_speed.Name = "txt_speed"
        Me.txt_speed.Size = New System.Drawing.Size(74, 21)
        Me.txt_speed.TabIndex = 46
        Me.txt_speed.Text = "1"
        Me.txt_speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label15.Location = New System.Drawing.Point(472, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 20)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Axis Speed"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_pulse
        '
        Me.txt_pulse.Location = New System.Drawing.Point(556, 42)
        Me.txt_pulse.Name = "txt_pulse"
        Me.txt_pulse.Size = New System.Drawing.Size(74, 21)
        Me.txt_pulse.TabIndex = 40
        Me.txt_pulse.Text = "0.01"
        Me.txt_pulse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label10.Location = New System.Drawing.Point(472, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 20)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "Axis Pulse"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_decel
        '
        Me.txt_decel.Location = New System.Drawing.Point(286, 133)
        Me.txt_decel.Name = "txt_decel"
        Me.txt_decel.Size = New System.Drawing.Size(145, 21)
        Me.txt_decel.TabIndex = 38
        Me.txt_decel.Text = "800"
        Me.txt_decel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_accel
        '
        Me.txt_accel.Location = New System.Drawing.Point(286, 110)
        Me.txt_accel.Name = "txt_accel"
        Me.txt_accel.Size = New System.Drawing.Size(145, 21)
        Me.txt_accel.TabIndex = 37
        Me.txt_accel.Text = "350"
        Me.txt_accel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_velocity
        '
        Me.txt_velocity.Location = New System.Drawing.Point(286, 86)
        Me.txt_velocity.Name = "txt_velocity"
        Me.txt_velocity.Size = New System.Drawing.Size(145, 21)
        Me.txt_velocity.TabIndex = 36
        Me.txt_velocity.Text = "70"
        Me.txt_velocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl1
        '
        Me.lbl1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl1.Location = New System.Drawing.Point(167, 133)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(117, 20)
        Me.lbl1.TabIndex = 35
        Me.lbl1.Text = "Deceleration"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label9.Location = New System.Drawing.Point(167, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 20)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Acceleration"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label8.Location = New System.Drawing.Point(167, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 20)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Velocity"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label7.Location = New System.Drawing.Point(167, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 20)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Encoder Method"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbo_encodermethod
        '
        Me.cbo_encodermethod.FormattingEnabled = True
        Me.cbo_encodermethod.Items.AddRange(New Object() {"eUpDownMode", "eSqr1Mode        ", "eSqr2Mode          ", "eSqr4Mode         "})
        Me.cbo_encodermethod.Location = New System.Drawing.Point(286, 64)
        Me.cbo_encodermethod.Name = "cbo_encodermethod"
        Me.cbo_encodermethod.Size = New System.Drawing.Size(145, 20)
        Me.cbo_encodermethod.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label5.Location = New System.Drawing.Point(167, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 20)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Pulse  Method"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbo_pulsemethod
        '
        Me.cbo_pulsemethod.FormattingEnabled = True
        Me.cbo_pulsemethod.Items.AddRange(New Object() {"eOneHighLowHigh ", "eOneHighHighLow", "eOneLowLowHigh", "eOneLowHighLow", "eTwoCcwCwHigh", "eTwoCcwCwLow", "eTwoCwCcwHigh", "eTwoCwCcwLow"})
        Me.cbo_pulsemethod.Location = New System.Drawing.Point(286, 41)
        Me.cbo_pulsemethod.Name = "cbo_pulsemethod"
        Me.cbo_pulsemethod.Size = New System.Drawing.Size(145, 20)
        Me.cbo_pulsemethod.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label3.Location = New System.Drawing.Point(167, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 20)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Aixs Count"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbo_axiscount
        '
        Me.cbo_axiscount.FormattingEnabled = True
        Me.cbo_axiscount.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cbo_axiscount.Location = New System.Drawing.Point(286, 18)
        Me.cbo_axiscount.Name = "cbo_axiscount"
        Me.cbo_axiscount.Size = New System.Drawing.Size(145, 20)
        Me.cbo_axiscount.TabIndex = 24
        '
        'btn_Initialize
        '
        Me.btn_Initialize.Location = New System.Drawing.Point(17, 18)
        Me.btn_Initialize.Name = "btn_Initialize"
        Me.btn_Initialize.Size = New System.Drawing.Size(139, 45)
        Me.btn_Initialize.TabIndex = 0
        Me.btn_Initialize.Text = "Initialize"
        Me.btn_Initialize.UseVisualStyleBackColor = True
        '
        'btn_getLimitlv
        '
        Me.btn_getLimitlv.Location = New System.Drawing.Point(441, 544)
        Me.btn_getLimitlv.Name = "btn_getLimitlv"
        Me.btn_getLimitlv.Size = New System.Drawing.Size(139, 45)
        Me.btn_getLimitlv.TabIndex = 23
        Me.btn_getLimitlv.Text = "Get Limit Level"
        Me.btn_getLimitlv.UseVisualStyleBackColor = True
        '
        'set_maxspeed
        '
        Me.set_maxspeed.Location = New System.Drawing.Point(296, 544)
        Me.set_maxspeed.Name = "set_maxspeed"
        Me.set_maxspeed.Size = New System.Drawing.Size(139, 45)
        Me.set_maxspeed.TabIndex = 22
        Me.set_maxspeed.Text = "Set Max Speed"
        Me.set_maxspeed.UseVisualStyleBackColor = True
        '
        'btn_GetPosition
        '
        Me.btn_GetPosition.Location = New System.Drawing.Point(150, 544)
        Me.btn_GetPosition.Name = "btn_GetPosition"
        Me.btn_GetPosition.Size = New System.Drawing.Size(139, 45)
        Me.btn_GetPosition.TabIndex = 21
        Me.btn_GetPosition.Text = "Get Position"
        Me.btn_GetPosition.UseVisualStyleBackColor = True
        '
        'btn_SetPosition
        '
        Me.btn_SetPosition.Location = New System.Drawing.Point(6, 544)
        Me.btn_SetPosition.Name = "btn_SetPosition"
        Me.btn_SetPosition.Size = New System.Drawing.Size(139, 45)
        Me.btn_SetPosition.TabIndex = 20
        Me.btn_SetPosition.Text = "Set Postion"
        Me.btn_SetPosition.UseVisualStyleBackColor = True
        '
        'btn_stop
        '
        Me.btn_stop.Location = New System.Drawing.Point(6, 493)
        Me.btn_stop.Name = "btn_stop"
        Me.btn_stop.Size = New System.Drawing.Size(139, 45)
        Me.btn_stop.TabIndex = 19
        Me.btn_stop.Text = "Stop"
        Me.btn_stop.UseVisualStyleBackColor = True
        '
        'btn_Zmove
        '
        Me.btn_Zmove.Location = New System.Drawing.Point(296, 442)
        Me.btn_Zmove.Name = "btn_Zmove"
        Me.btn_Zmove.Size = New System.Drawing.Size(139, 45)
        Me.btn_Zmove.TabIndex = 18
        Me.btn_Zmove.Text = "Z Move"
        Me.btn_Zmove.UseVisualStyleBackColor = True
        '
        'btn_Ymove
        '
        Me.btn_Ymove.Location = New System.Drawing.Point(150, 442)
        Me.btn_Ymove.Name = "btn_Ymove"
        Me.btn_Ymove.Size = New System.Drawing.Size(139, 45)
        Me.btn_Ymove.TabIndex = 17
        Me.btn_Ymove.Text = "Y Move"
        Me.btn_Ymove.UseVisualStyleBackColor = True
        '
        'btn_Xmove
        '
        Me.btn_Xmove.Location = New System.Drawing.Point(6, 442)
        Me.btn_Xmove.Name = "btn_Xmove"
        Me.btn_Xmove.Size = New System.Drawing.Size(139, 45)
        Me.btn_Xmove.TabIndex = 16
        Me.btn_Xmove.Text = "X Move"
        Me.btn_Xmove.UseVisualStyleBackColor = True
        '
        'btn_XRYD
        '
        Me.btn_XRYD.Location = New System.Drawing.Point(150, 379)
        Me.btn_XRYD.Name = "btn_XRYD"
        Me.btn_XRYD.Size = New System.Drawing.Size(139, 45)
        Me.btn_XRYD.TabIndex = 15
        Me.btn_XRYD.Text = "Jog XR && YD"
        Me.btn_XRYD.UseVisualStyleBackColor = True
        '
        'btn_XLYD
        '
        Me.btn_XLYD.Location = New System.Drawing.Point(6, 379)
        Me.btn_XLYD.Name = "btn_XLYD"
        Me.btn_XLYD.Size = New System.Drawing.Size(139, 45)
        Me.btn_XLYD.TabIndex = 14
        Me.btn_XLYD.Text = "Jog XL && YD"
        Me.btn_XLYD.UseVisualStyleBackColor = True
        '
        'btn_XRYU
        '
        Me.btn_XRYU.Location = New System.Drawing.Point(441, 328)
        Me.btn_XRYU.Name = "btn_XRYU"
        Me.btn_XRYU.Size = New System.Drawing.Size(139, 45)
        Me.btn_XRYU.TabIndex = 13
        Me.btn_XRYU.Text = "Jog XR && YU"
        Me.btn_XRYU.UseVisualStyleBackColor = True
        '
        'btn_XLYU
        '
        Me.btn_XLYU.Location = New System.Drawing.Point(296, 328)
        Me.btn_XLYU.Name = "btn_XLYU"
        Me.btn_XLYU.Size = New System.Drawing.Size(139, 45)
        Me.btn_XLYU.TabIndex = 12
        Me.btn_XLYU.Text = "Jog XL && YU"
        Me.btn_XLYU.UseVisualStyleBackColor = True
        '
        'btn_Zdown
        '
        Me.btn_Zdown.Location = New System.Drawing.Point(150, 328)
        Me.btn_Zdown.Name = "btn_Zdown"
        Me.btn_Zdown.Size = New System.Drawing.Size(139, 45)
        Me.btn_Zdown.TabIndex = 11
        Me.btn_Zdown.Text = "Jog Z Down"
        Me.btn_Zdown.UseVisualStyleBackColor = True
        '
        'btn_Zup
        '
        Me.btn_Zup.Location = New System.Drawing.Point(6, 328)
        Me.btn_Zup.Name = "btn_Zup"
        Me.btn_Zup.Size = New System.Drawing.Size(139, 45)
        Me.btn_Zup.TabIndex = 10
        Me.btn_Zup.Text = "Jog Z Up"
        Me.btn_Zup.UseVisualStyleBackColor = True
        '
        'btn_YDown
        '
        Me.btn_YDown.Location = New System.Drawing.Point(441, 277)
        Me.btn_YDown.Name = "btn_YDown"
        Me.btn_YDown.Size = New System.Drawing.Size(139, 45)
        Me.btn_YDown.TabIndex = 9
        Me.btn_YDown.Text = "Jog Y Down"
        Me.btn_YDown.UseVisualStyleBackColor = True
        '
        'btn_Yup
        '
        Me.btn_Yup.Location = New System.Drawing.Point(296, 277)
        Me.btn_Yup.Name = "btn_Yup"
        Me.btn_Yup.Size = New System.Drawing.Size(139, 45)
        Me.btn_Yup.TabIndex = 8
        Me.btn_Yup.Text = "Jog Y Up"
        Me.btn_Yup.UseVisualStyleBackColor = True
        '
        'JogXL
        '
        Me.JogXL.Location = New System.Drawing.Point(150, 277)
        Me.JogXL.Name = "JogXL"
        Me.JogXL.Size = New System.Drawing.Size(139, 45)
        Me.JogXL.TabIndex = 7
        Me.JogXL.Text = "Jog X Left"
        Me.JogXL.UseVisualStyleBackColor = True
        '
        'btn_JogXR
        '
        Me.btn_JogXR.Location = New System.Drawing.Point(6, 277)
        Me.btn_JogXR.Name = "btn_JogXR"
        Me.btn_JogXR.Size = New System.Drawing.Size(139, 45)
        Me.btn_JogXR.TabIndex = 6
        Me.btn_JogXR.Text = "Jog X Right"
        Me.btn_JogXR.UseVisualStyleBackColor = True
        '
        'btn_emgallStop
        '
        Me.btn_emgallStop.Location = New System.Drawing.Point(296, 493)
        Me.btn_emgallStop.Name = "btn_emgallStop"
        Me.btn_emgallStop.Size = New System.Drawing.Size(139, 45)
        Me.btn_emgallStop.TabIndex = 5
        Me.btn_emgallStop.Text = "Emg All Stop"
        Me.btn_emgallStop.UseVisualStyleBackColor = True
        '
        'btn_allStop
        '
        Me.btn_allStop.Location = New System.Drawing.Point(150, 493)
        Me.btn_allStop.Name = "btn_allStop"
        Me.btn_allStop.Size = New System.Drawing.Size(139, 45)
        Me.btn_allStop.TabIndex = 4
        Me.btn_allStop.Text = "All Stop"
        Me.btn_allStop.UseVisualStyleBackColor = True
        '
        'btn_Homing
        '
        Me.btn_Homing.Location = New System.Drawing.Point(296, 226)
        Me.btn_Homing.Name = "btn_Homing"
        Me.btn_Homing.Size = New System.Drawing.Size(139, 45)
        Me.btn_Homing.TabIndex = 3
        Me.btn_Homing.Text = "Homing"
        Me.btn_Homing.UseVisualStyleBackColor = True
        '
        'btn_ServoOff
        '
        Me.btn_ServoOff.Location = New System.Drawing.Point(150, 226)
        Me.btn_ServoOff.Name = "btn_ServoOff"
        Me.btn_ServoOff.Size = New System.Drawing.Size(139, 45)
        Me.btn_ServoOff.TabIndex = 2
        Me.btn_ServoOff.Text = "Servo Off"
        Me.btn_ServoOff.UseVisualStyleBackColor = True
        '
        'btn_ServoOn
        '
        Me.btn_ServoOn.Location = New System.Drawing.Point(6, 226)
        Me.btn_ServoOn.Name = "btn_ServoOn"
        Me.btn_ServoOn.Size = New System.Drawing.Size(139, 45)
        Me.btn_ServoOn.TabIndex = 1
        Me.btn_ServoOn.Text = "Servo On"
        Me.btn_ServoOn.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_AxisTheta)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.lbl_AxisZ)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lbl_AxisY)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lbl_AxisX)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(670, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(367, 220)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Target Position"
        '
        'lbl_AxisTheta
        '
        Me.lbl_AxisTheta.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_AxisTheta.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbl_AxisTheta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_AxisTheta.Location = New System.Drawing.Point(141, 150)
        Me.lbl_AxisTheta.Name = "lbl_AxisTheta"
        Me.lbl_AxisTheta.Size = New System.Drawing.Size(192, 32)
        Me.lbl_AxisTheta.TabIndex = 7
        Me.lbl_AxisTheta.Text = "0.000"
        Me.lbl_AxisTheta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label12.Location = New System.Drawing.Point(29, 150)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 32)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Theta Axis "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_AxisZ
        '
        Me.lbl_AxisZ.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_AxisZ.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbl_AxisZ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_AxisZ.Location = New System.Drawing.Point(141, 115)
        Me.lbl_AxisZ.Name = "lbl_AxisZ"
        Me.lbl_AxisZ.Size = New System.Drawing.Size(192, 32)
        Me.lbl_AxisZ.TabIndex = 5
        Me.lbl_AxisZ.Text = "0.000"
        Me.lbl_AxisZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label6.Location = New System.Drawing.Point(29, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 32)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Z Axis "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_AxisY
        '
        Me.lbl_AxisY.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_AxisY.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbl_AxisY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_AxisY.Location = New System.Drawing.Point(141, 80)
        Me.lbl_AxisY.Name = "lbl_AxisY"
        Me.lbl_AxisY.Size = New System.Drawing.Size(192, 32)
        Me.lbl_AxisY.TabIndex = 3
        Me.lbl_AxisY.Text = "0.000"
        Me.lbl_AxisY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label4.Location = New System.Drawing.Point(29, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 32)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Y Axis "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_AxisX
        '
        Me.lbl_AxisX.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbl_AxisX.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbl_AxisX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_AxisX.Location = New System.Drawing.Point(141, 45)
        Me.lbl_AxisX.Name = "lbl_AxisX"
        Me.lbl_AxisX.Size = New System.Drawing.Size(192, 32)
        Me.lbl_AxisX.TabIndex = 1
        Me.lbl_AxisX.Text = "0.000"
        Me.lbl_AxisX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label1.Location = New System.Drawing.Point(29, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "X Axis "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.chkSlowLimit_Minus)
        Me.GroupBox7.Controls.Add(Me.chkSlowLimit_Plus)
        Me.GroupBox7.Controls.Add(Me.lblIO_SLimit_M)
        Me.GroupBox7.Controls.Add(Me.lblIO_SLimit_P)
        Me.GroupBox7.Controls.Add(Me.chkAlarm)
        Me.GroupBox7.Controls.Add(Me.chkSpeedLimit_Minus)
        Me.GroupBox7.Controls.Add(Me.chkSpeedLimit_Plus)
        Me.GroupBox7.Controls.Add(Me.lblIO_Alarm)
        Me.GroupBox7.Controls.Add(Me.lblIO_Limit_M)
        Me.GroupBox7.Controls.Add(Me.lblIO_Limit_P)
        Me.GroupBox7.Location = New System.Drawing.Point(1046, 14)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(200, 218)
        Me.GroupBox7.TabIndex = 138
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "I/O"
        '
        'chkSlowLimit_Minus
        '
        Me.chkSlowLimit_Minus.AutoSize = True
        Me.chkSlowLimit_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSlowLimit_Minus.Location = New System.Drawing.Point(157, 110)
        Me.chkSlowLimit_Minus.Name = "chkSlowLimit_Minus"
        Me.chkSlowLimit_Minus.Size = New System.Drawing.Size(12, 11)
        Me.chkSlowLimit_Minus.TabIndex = 147
        Me.chkSlowLimit_Minus.UseVisualStyleBackColor = True
        '
        'chkSlowLimit_Plus
        '
        Me.chkSlowLimit_Plus.AutoSize = True
        Me.chkSlowLimit_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSlowLimit_Plus.Location = New System.Drawing.Point(157, 87)
        Me.chkSlowLimit_Plus.Name = "chkSlowLimit_Plus"
        Me.chkSlowLimit_Plus.Size = New System.Drawing.Size(12, 11)
        Me.chkSlowLimit_Plus.TabIndex = 146
        Me.chkSlowLimit_Plus.UseVisualStyleBackColor = True
        '
        'lblIO_SLimit_M
        '
        Me.lblIO_SLimit_M.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblIO_SLimit_M.Location = New System.Drawing.Point(12, 107)
        Me.lblIO_SLimit_M.Name = "lblIO_SLimit_M"
        Me.lblIO_SLimit_M.Size = New System.Drawing.Size(133, 18)
        Me.lblIO_SLimit_M.TabIndex = 145
        Me.lblIO_SLimit_M.Text = "I/O Slow Limit(-)"
        Me.lblIO_SLimit_M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIO_SLimit_P
        '
        Me.lblIO_SLimit_P.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblIO_SLimit_P.Location = New System.Drawing.Point(12, 84)
        Me.lblIO_SLimit_P.Name = "lblIO_SLimit_P"
        Me.lblIO_SLimit_P.Size = New System.Drawing.Size(133, 18)
        Me.lblIO_SLimit_P.TabIndex = 144
        Me.lblIO_SLimit_P.Text = "I/O Slow Limit(+)"
        Me.lblIO_SLimit_P.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkAlarm
        '
        Me.chkAlarm.AutoSize = True
        Me.chkAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAlarm.Location = New System.Drawing.Point(157, 135)
        Me.chkAlarm.Name = "chkAlarm"
        Me.chkAlarm.Size = New System.Drawing.Size(12, 11)
        Me.chkAlarm.TabIndex = 143
        Me.chkAlarm.UseVisualStyleBackColor = True
        '
        'chkSpeedLimit_Minus
        '
        Me.chkSpeedLimit_Minus.AutoSize = True
        Me.chkSpeedLimit_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSpeedLimit_Minus.Location = New System.Drawing.Point(157, 64)
        Me.chkSpeedLimit_Minus.Name = "chkSpeedLimit_Minus"
        Me.chkSpeedLimit_Minus.Size = New System.Drawing.Size(12, 11)
        Me.chkSpeedLimit_Minus.TabIndex = 142
        Me.chkSpeedLimit_Minus.UseVisualStyleBackColor = True
        '
        'chkSpeedLimit_Plus
        '
        Me.chkSpeedLimit_Plus.AutoSize = True
        Me.chkSpeedLimit_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSpeedLimit_Plus.Location = New System.Drawing.Point(157, 41)
        Me.chkSpeedLimit_Plus.Name = "chkSpeedLimit_Plus"
        Me.chkSpeedLimit_Plus.Size = New System.Drawing.Size(12, 11)
        Me.chkSpeedLimit_Plus.TabIndex = 141
        Me.chkSpeedLimit_Plus.UseVisualStyleBackColor = True
        '
        'lblIO_Alarm
        '
        Me.lblIO_Alarm.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblIO_Alarm.Location = New System.Drawing.Point(12, 132)
        Me.lblIO_Alarm.Name = "lblIO_Alarm"
        Me.lblIO_Alarm.Size = New System.Drawing.Size(133, 18)
        Me.lblIO_Alarm.TabIndex = 140
        Me.lblIO_Alarm.Text = "I/O ALARM"
        Me.lblIO_Alarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIO_Limit_M
        '
        Me.lblIO_Limit_M.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblIO_Limit_M.Location = New System.Drawing.Point(12, 61)
        Me.lblIO_Limit_M.Name = "lblIO_Limit_M"
        Me.lblIO_Limit_M.Size = New System.Drawing.Size(133, 18)
        Me.lblIO_Limit_M.TabIndex = 139
        Me.lblIO_Limit_M.Text = "I/O Limit(-)"
        Me.lblIO_Limit_M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIO_Limit_P
        '
        Me.lblIO_Limit_P.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblIO_Limit_P.Location = New System.Drawing.Point(12, 38)
        Me.lblIO_Limit_P.Name = "lblIO_Limit_P"
        Me.lblIO_Limit_P.Size = New System.Drawing.Size(133, 18)
        Me.lblIO_Limit_P.TabIndex = 138
        Me.lblIO_Limit_P.Text = "I/O Limit(+)"
        Me.lblIO_Limit_P.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMotionControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1326, 643)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmMotionControl"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRD As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnLD As System.Windows.Forms.Button
    Friend WithEvents btnR As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnL As System.Windows.Forms.Button
    Friend WithEvents btnRU As System.Windows.Forms.Button
    Friend WithEvents btnUP As System.Windows.Forms.Button
    Friend WithEvents btnLU As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_AxisZ As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_AxisY As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_AxisX As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnZmove As System.Windows.Forms.Button
    Friend WithEvents btnYmove As System.Windows.Forms.Button
    Friend WithEvents btnXmove As System.Windows.Forms.Button
    Friend WithEvents chkZ As System.Windows.Forms.CheckBox
    Friend WithEvents rbAbs As System.Windows.Forms.RadioButton
    Friend WithEvents rbMicroAdjust As System.Windows.Forms.RadioButton
    Friend WithEvents txtPosition As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_Initialize As System.Windows.Forms.Button
    Friend WithEvents btn_ServoOff As System.Windows.Forms.Button
    Friend WithEvents btn_ServoOn As System.Windows.Forms.Button
    Friend WithEvents btn_Homing As System.Windows.Forms.Button
    Friend WithEvents btn_emgallStop As System.Windows.Forms.Button
    Friend WithEvents btn_allStop As System.Windows.Forms.Button
    Friend WithEvents btn_Zdown As System.Windows.Forms.Button
    Friend WithEvents btn_Zup As System.Windows.Forms.Button
    Friend WithEvents btn_YDown As System.Windows.Forms.Button
    Friend WithEvents btn_Yup As System.Windows.Forms.Button
    Friend WithEvents JogXL As System.Windows.Forms.Button
    Friend WithEvents btn_JogXR As System.Windows.Forms.Button
    Friend WithEvents btn_XRYD As System.Windows.Forms.Button
    Friend WithEvents btn_XLYD As System.Windows.Forms.Button
    Friend WithEvents btn_XRYU As System.Windows.Forms.Button
    Friend WithEvents btn_XLYU As System.Windows.Forms.Button
    Friend WithEvents btn_Xmove As System.Windows.Forms.Button
    Friend WithEvents btn_Zmove As System.Windows.Forms.Button
    Friend WithEvents btn_Ymove As System.Windows.Forms.Button
    Friend WithEvents btn_stop As System.Windows.Forms.Button
    Friend WithEvents btn_GetPosition As System.Windows.Forms.Button
    Friend WithEvents btn_SetPosition As System.Windows.Forms.Button
    Friend WithEvents set_maxspeed As System.Windows.Forms.Button
    Friend WithEvents btn_getLimitlv As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_encodermethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_pulsemethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_axiscount As System.Windows.Forms.ComboBox
    Friend WithEvents txt_decel As System.Windows.Forms.TextBox
    Friend WithEvents txt_accel As System.Windows.Forms.TextBox
    Friend WithEvents txt_velocity As System.Windows.Forms.TextBox
    Friend WithEvents txt_pulse As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_speed As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lbl_AxisTheta As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSlowLimit_Minus As System.Windows.Forms.CheckBox
    Friend WithEvents chkSlowLimit_Plus As System.Windows.Forms.CheckBox
    Friend WithEvents lblIO_SLimit_M As System.Windows.Forms.Label
    Friend WithEvents lblIO_SLimit_P As System.Windows.Forms.Label
    Friend WithEvents chkAlarm As System.Windows.Forms.CheckBox
    Friend WithEvents chkSpeedLimit_Minus As System.Windows.Forms.CheckBox
    Friend WithEvents chkSpeedLimit_Plus As System.Windows.Forms.CheckBox
    Friend WithEvents lblIO_Alarm As System.Windows.Forms.Label
    Friend WithEvents lblIO_Limit_M As System.Windows.Forms.Label
    Friend WithEvents lblIO_Limit_P As System.Windows.Forms.Label

End Class
