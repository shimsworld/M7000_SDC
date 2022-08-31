<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMotionUI
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
        Me.gbJOG = New System.Windows.Forms.GroupBox()
        Me.tlpJOG = New System.Windows.Forms.TableLayoutPanel()
        Me.btnR = New System.Windows.Forms.Button()
        Me.btnRD = New System.Windows.Forms.Button()
        Me.btnLU = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUP = New System.Windows.Forms.Button()
        Me.btnLD = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnRU = New System.Windows.Forms.Button()
        Me.btnL = New System.Windows.Forms.Button()
        Me.gbManualCtrl = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkTheta4 = New System.Windows.Forms.CheckBox()
        Me.chkTheta3 = New System.Windows.Forms.CheckBox()
        Me.chkTheta2 = New System.Windows.Forms.CheckBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnJOGMode_OFF = New System.Windows.Forms.Button()
        Me.btnJOGMode_ON = New System.Windows.Forms.Button()
        Me.txtPosition = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnThetaMove = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_Homing = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnZmove = New System.Windows.Forms.Button()
        Me.chkTheta1 = New System.Windows.Forms.CheckBox()
        Me.btnYmove = New System.Windows.Forms.Button()
        Me.rbMicroAdjust = New System.Windows.Forms.RadioButton()
        Me.rbAbs = New System.Windows.Forms.RadioButton()
        Me.btnXmove = New System.Windows.Forms.Button()
        Me.gbMotion = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.btnSetPositionOffset = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tbXOffset = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tbYPos = New System.Windows.Forms.TextBox()
        Me.tbYCurrPos = New System.Windows.Forms.TextBox()
        Me.tbXCurrPos = New System.Windows.Forms.TextBox()
        Me.tbYOffset = New System.Windows.Forms.TextBox()
        Me.tbXPos = New System.Windows.Forms.TextBox()
        Me.tbZPos = New System.Windows.Forms.TextBox()
        Me.tbZOffset = New System.Windows.Forms.TextBox()
        Me.tbZCurrPos = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.chkManualPos = New System.Windows.Forms.CheckBox()
        Me.btnLampOnOff = New System.Windows.Forms.Button()
        Me.btnAutoCenteringOffset = New System.Windows.Forms.Button()
        Me.btnSetLampLevel = New System.Windows.Forms.Button()
        Me.tbSetLampLevel = New System.Windows.Forms.TextBox()
        Me.cbChangePosition = New System.Windows.Forms.CheckBox()
        Me.txtLoadPositionName = New System.Windows.Forms.TextBox()
        Me.cbChannel = New System.Windows.Forms.ComboBox()
        Me.btnMove = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPositionSave = New System.Windows.Forms.Button()
        Me.btnLoadPosition = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cbIndex = New System.Windows.Forms.ComboBox()
        Me.rbSpectrometer = New System.Windows.Forms.RadioButton()
        Me.rbCCD = New System.Windows.Forms.RadioButton()
        Me.btn_ServoOff = New System.Windows.Forms.Button()
        Me.btn_ServoOn = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.pnDispProcImage = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbACFCtrl = New System.Windows.Forms.GroupBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.rbCaptWebcam = New System.Windows.Forms.RadioButton()
        Me.rbCaptCCD = New System.Windows.Forms.RadioButton()
        Me.btnCaptureArea = New System.Windows.Forms.Button()
        Me.btnCaptureImage = New System.Windows.Forms.Button()
        Me.listACFInfo = New System.Windows.Forms.ListView()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnRunACF = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnAnalysisImage = New System.Windows.Forms.Button()
        Me.btnAutoFocusing = New System.Windows.Forms.Button()
        Me.btnIntensityAdj = New System.Windows.Forms.Button()
        Me.btnAutoCentering = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.pnDispGrabImg = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.gbACFMeas = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbACFMeasState = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbACFSavePath = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbACFChannel = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSavePath = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnACFStop = New System.Windows.Forms.Button()
        Me.btnACFStart = New System.Windows.Forms.Button()
        Me.gbACFCameraCtrl = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnInitCamera = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAlliedStart = New System.Windows.Forms.Button()
        Me.btnAlliedStop = New System.Windows.Forms.Button()
        Me.ucMotionIndicator = New M7000.ucMotionIndicator()
        Me.UcAlarmTest1 = New M7000.ucAlarmTest()
        Me.gbJOG.SuspendLayout()
        Me.tlpJOG.SuspendLayout()
        Me.gbManualCtrl.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gbMotion.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbACFCtrl.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.gbACFMeas.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.gbACFCameraCtrl.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbJOG
        '
        Me.gbJOG.Controls.Add(Me.tlpJOG)
        Me.gbJOG.Location = New System.Drawing.Point(10, 230)
        Me.gbJOG.Name = "gbJOG"
        Me.gbJOG.Size = New System.Drawing.Size(302, 237)
        Me.gbJOG.TabIndex = 4
        Me.gbJOG.TabStop = False
        '
        'tlpJOG
        '
        Me.tlpJOG.ColumnCount = 3
        Me.tlpJOG.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpJOG.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlpJOG.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlpJOG.Controls.Add(Me.btnR, 2, 1)
        Me.tlpJOG.Controls.Add(Me.btnRD, 2, 2)
        Me.tlpJOG.Controls.Add(Me.btnLU, 0, 0)
        Me.tlpJOG.Controls.Add(Me.btnDown, 1, 2)
        Me.tlpJOG.Controls.Add(Me.btnUP, 1, 0)
        Me.tlpJOG.Controls.Add(Me.btnLD, 0, 2)
        Me.tlpJOG.Controls.Add(Me.btnStop, 1, 1)
        Me.tlpJOG.Controls.Add(Me.btnRU, 2, 0)
        Me.tlpJOG.Controls.Add(Me.btnL, 0, 1)
        Me.tlpJOG.Location = New System.Drawing.Point(34, 14)
        Me.tlpJOG.Name = "tlpJOG"
        Me.tlpJOG.RowCount = 3
        Me.tlpJOG.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpJOG.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpJOG.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpJOG.Size = New System.Drawing.Size(241, 219)
        Me.tlpJOG.TabIndex = 10
        '
        'btnR
        '
        Me.btnR.BackgroundImage = Global.M7000.My.Resources.Resources.JogR
        Me.btnR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnR.Location = New System.Drawing.Point(163, 76)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(75, 65)
        Me.btnR.TabIndex = 5
        Me.btnR.UseVisualStyleBackColor = True
        '
        'btnRD
        '
        Me.btnRD.BackgroundImage = Global.M7000.My.Resources.Resources.JogRDown
        Me.btnRD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRD.Location = New System.Drawing.Point(163, 149)
        Me.btnRD.Name = "btnRD"
        Me.btnRD.Size = New System.Drawing.Size(75, 67)
        Me.btnRD.TabIndex = 8
        Me.btnRD.UseVisualStyleBackColor = True
        Me.btnRD.Visible = False
        '
        'btnLU
        '
        Me.btnLU.BackgroundImage = Global.M7000.My.Resources.Resources.JogLUP
        Me.btnLU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLU.Location = New System.Drawing.Point(3, 3)
        Me.btnLU.Name = "btnLU"
        Me.btnLU.Size = New System.Drawing.Size(74, 65)
        Me.btnLU.TabIndex = 0
        Me.btnLU.UseVisualStyleBackColor = True
        Me.btnLU.Visible = False
        '
        'btnDown
        '
        Me.btnDown.BackgroundImage = Global.M7000.My.Resources.Resources.JogDown
        Me.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDown.Location = New System.Drawing.Point(83, 149)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(74, 67)
        Me.btnDown.TabIndex = 7
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUP
        '
        Me.btnUP.BackgroundImage = Global.M7000.My.Resources.Resources.JogUp
        Me.btnUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUP.Location = New System.Drawing.Point(83, 3)
        Me.btnUP.Name = "btnUP"
        Me.btnUP.Size = New System.Drawing.Size(74, 65)
        Me.btnUP.TabIndex = 1
        Me.btnUP.UseVisualStyleBackColor = True
        '
        'btnLD
        '
        Me.btnLD.BackgroundImage = Global.M7000.My.Resources.Resources.JogLDown
        Me.btnLD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLD.Location = New System.Drawing.Point(3, 149)
        Me.btnLD.Name = "btnLD"
        Me.btnLD.Size = New System.Drawing.Size(74, 67)
        Me.btnLD.TabIndex = 6
        Me.btnLD.UseVisualStyleBackColor = True
        Me.btnLD.Visible = False
        '
        'btnStop
        '
        Me.btnStop.BackgroundImage = Global.M7000.My.Resources.Resources.JogStop
        Me.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStop.Location = New System.Drawing.Point(83, 76)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(74, 65)
        Me.btnStop.TabIndex = 4
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnRU
        '
        Me.btnRU.AccessibleRole = System.Windows.Forms.AccessibleRole.Border
        Me.btnRU.BackColor = System.Drawing.Color.Transparent
        Me.btnRU.BackgroundImage = Global.M7000.My.Resources.Resources.JogRUP
        Me.btnRU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRU.Location = New System.Drawing.Point(163, 3)
        Me.btnRU.Name = "btnRU"
        Me.btnRU.Size = New System.Drawing.Size(75, 65)
        Me.btnRU.TabIndex = 2
        Me.btnRU.UseVisualStyleBackColor = False
        Me.btnRU.Visible = False
        '
        'btnL
        '
        Me.btnL.BackgroundImage = Global.M7000.My.Resources.Resources.JogL
        Me.btnL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnL.Location = New System.Drawing.Point(3, 76)
        Me.btnL.Name = "btnL"
        Me.btnL.Size = New System.Drawing.Size(74, 65)
        Me.btnL.TabIndex = 3
        Me.btnL.UseVisualStyleBackColor = True
        '
        'gbManualCtrl
        '
        Me.gbManualCtrl.Controls.Add(Me.Panel2)
        Me.gbManualCtrl.Location = New System.Drawing.Point(8, 465)
        Me.gbManualCtrl.Name = "gbManualCtrl"
        Me.gbManualCtrl.Size = New System.Drawing.Size(305, 224)
        Me.gbManualCtrl.TabIndex = 9
        Me.gbManualCtrl.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.chkTheta4)
        Me.Panel2.Controls.Add(Me.chkTheta3)
        Me.Panel2.Controls.Add(Me.chkTheta2)
        Me.Panel2.Controls.Add(Me.btnJOGMode_OFF)
        Me.Panel2.Controls.Add(Me.btnJOGMode_ON)
        Me.Panel2.Controls.Add(Me.txtPosition)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.btn_Homing)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.btnZmove)
        Me.Panel2.Controls.Add(Me.chkTheta1)
        Me.Panel2.Controls.Add(Me.btnYmove)
        Me.Panel2.Controls.Add(Me.rbMicroAdjust)
        Me.Panel2.Controls.Add(Me.rbAbs)
        Me.Panel2.Controls.Add(Me.btnXmove)
        Me.Panel2.Location = New System.Drawing.Point(10, 17)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(280, 197)
        Me.Panel2.TabIndex = 66
        '
        'chkTheta4
        '
        Me.chkTheta4.AutoSize = True
        Me.chkTheta4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTheta4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTheta4.Location = New System.Drawing.Point(209, 78)
        Me.chkTheta4.Name = "chkTheta4"
        Me.chkTheta4.Size = New System.Drawing.Size(67, 19)
        Me.chkTheta4.TabIndex = 76
        Me.chkTheta4.Text = "Ɵ4 Axis"
        Me.chkTheta4.UseVisualStyleBackColor = True
        Me.chkTheta4.Visible = False
        '
        'chkTheta3
        '
        Me.chkTheta3.AutoSize = True
        Me.chkTheta3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTheta3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTheta3.Location = New System.Drawing.Point(142, 78)
        Me.chkTheta3.Name = "chkTheta3"
        Me.chkTheta3.Size = New System.Drawing.Size(67, 19)
        Me.chkTheta3.TabIndex = 75
        Me.chkTheta3.Text = "Ɵ3 Axis"
        Me.chkTheta3.UseVisualStyleBackColor = True
        Me.chkTheta3.Visible = False
        '
        'chkTheta2
        '
        Me.chkTheta2.AutoSize = True
        Me.chkTheta2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTheta2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTheta2.Location = New System.Drawing.Point(76, 78)
        Me.chkTheta2.Name = "chkTheta2"
        Me.chkTheta2.Size = New System.Drawing.Size(67, 19)
        Me.chkTheta2.TabIndex = 74
        Me.chkTheta2.Text = "Ɵ2 Axis"
        Me.chkTheta2.UseVisualStyleBackColor = True
        Me.chkTheta2.Visible = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Silver
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Location = New System.Drawing.Point(727, 802)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(61, 25)
        Me.Button5.TabIndex = 73
        Me.Button5.Text = "Ɵ4 Axis Move"
        Me.Button5.UseVisualStyleBackColor = False
        Me.Button5.Visible = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Silver
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(661, 802)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(61, 25)
        Me.Button4.TabIndex = 72
        Me.Button4.Text = "Ɵ3 Axis Move"
        Me.Button4.UseVisualStyleBackColor = False
        Me.Button4.Visible = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Silver
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(595, 802)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(61, 25)
        Me.Button3.TabIndex = 71
        Me.Button3.Text = "Ɵ2 Axis Move"
        Me.Button3.UseVisualStyleBackColor = False
        Me.Button3.Visible = False
        '
        'btnJOGMode_OFF
        '
        Me.btnJOGMode_OFF.BackColor = System.Drawing.Color.Silver
        Me.btnJOGMode_OFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnJOGMode_OFF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJOGMode_OFF.Location = New System.Drawing.Point(149, 163)
        Me.btnJOGMode_OFF.Name = "btnJOGMode_OFF"
        Me.btnJOGMode_OFF.Size = New System.Drawing.Size(118, 23)
        Me.btnJOGMode_OFF.TabIndex = 70
        Me.btnJOGMode_OFF.Text = "JOG MODE OFF"
        Me.btnJOGMode_OFF.UseVisualStyleBackColor = False
        '
        'btnJOGMode_ON
        '
        Me.btnJOGMode_ON.BackColor = System.Drawing.Color.Silver
        Me.btnJOGMode_ON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnJOGMode_ON.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJOGMode_ON.Location = New System.Drawing.Point(15, 163)
        Me.btnJOGMode_ON.Name = "btnJOGMode_ON"
        Me.btnJOGMode_ON.Size = New System.Drawing.Size(128, 23)
        Me.btnJOGMode_ON.TabIndex = 69
        Me.btnJOGMode_ON.Text = "JOG MODE ON"
        Me.btnJOGMode_ON.UseVisualStyleBackColor = False
        '
        'txtPosition
        '
        Me.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPosition.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPosition.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtPosition.Location = New System.Drawing.Point(205, 27)
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Size = New System.Drawing.Size(69, 21)
        Me.txtPosition.TabIndex = 2
        Me.txtPosition.Text = "0.1"
        Me.txtPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(17, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(188, 15)
        Me.Label14.TabIndex = 67
        Me.Label14.Text = "Position(mm)   . . . . . . . . . . . . . . . . "
        '
        'btnThetaMove
        '
        Me.btnThetaMove.BackColor = System.Drawing.Color.Silver
        Me.btnThetaMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnThetaMove.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThetaMove.ForeColor = System.Drawing.Color.Black
        Me.btnThetaMove.Location = New System.Drawing.Point(528, 802)
        Me.btnThetaMove.Name = "btnThetaMove"
        Me.btnThetaMove.Size = New System.Drawing.Size(61, 25)
        Me.btnThetaMove.TabIndex = 9
        Me.btnThetaMove.Text = "Ɵ1 Axis Move"
        Me.btnThetaMove.UseVisualStyleBackColor = False
        Me.btnThetaMove.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Silver
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(14, 180)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 25)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "WAD Move"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'btn_Homing
        '
        Me.btn_Homing.BackColor = System.Drawing.Color.Silver
        Me.btn_Homing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Homing.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Homing.Location = New System.Drawing.Point(15, 134)
        Me.btn_Homing.Name = "btn_Homing"
        Me.btn_Homing.Size = New System.Drawing.Size(251, 25)
        Me.btn_Homing.TabIndex = 13
        Me.btn_Homing.Text = "Homing"
        Me.btn_Homing.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 22)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Manual Control"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DarkGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Orange
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(278, 22)
        Me.Label6.TabIndex = 16
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnZmove
        '
        Me.btnZmove.BackColor = System.Drawing.Color.Silver
        Me.btnZmove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZmove.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZmove.ForeColor = System.Drawing.Color.Black
        Me.btnZmove.Location = New System.Drawing.Point(186, 105)
        Me.btnZmove.Name = "btnZmove"
        Me.btnZmove.Size = New System.Drawing.Size(81, 25)
        Me.btnZmove.TabIndex = 8
        Me.btnZmove.Text = "Z Axis Move"
        Me.btnZmove.UseVisualStyleBackColor = False
        '
        'chkTheta1
        '
        Me.chkTheta1.AutoSize = True
        Me.chkTheta1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTheta1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTheta1.Location = New System.Drawing.Point(11, 78)
        Me.chkTheta1.Name = "chkTheta1"
        Me.chkTheta1.Size = New System.Drawing.Size(67, 19)
        Me.chkTheta1.TabIndex = 5
        Me.chkTheta1.Text = "Ɵ1 Axis"
        Me.chkTheta1.UseVisualStyleBackColor = True
        Me.chkTheta1.Visible = False
        '
        'btnYmove
        '
        Me.btnYmove.BackColor = System.Drawing.Color.Silver
        Me.btnYmove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYmove.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYmove.ForeColor = System.Drawing.Color.Black
        Me.btnYmove.Location = New System.Drawing.Point(100, 105)
        Me.btnYmove.Name = "btnYmove"
        Me.btnYmove.Size = New System.Drawing.Size(81, 25)
        Me.btnYmove.TabIndex = 7
        Me.btnYmove.Text = "Y Axis Move"
        Me.btnYmove.UseVisualStyleBackColor = False
        '
        'rbMicroAdjust
        '
        Me.rbMicroAdjust.AutoSize = True
        Me.rbMicroAdjust.Checked = True
        Me.rbMicroAdjust.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbMicroAdjust.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMicroAdjust.Location = New System.Drawing.Point(15, 55)
        Me.rbMicroAdjust.Name = "rbMicroAdjust"
        Me.rbMicroAdjust.Size = New System.Drawing.Size(102, 19)
        Me.rbMicroAdjust.TabIndex = 3
        Me.rbMicroAdjust.TabStop = True
        Me.rbMicroAdjust.Text = "Micro - Adjust"
        Me.rbMicroAdjust.UseVisualStyleBackColor = True
        '
        'rbAbs
        '
        Me.rbAbs.AutoSize = True
        Me.rbAbs.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbAbs.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAbs.Location = New System.Drawing.Point(125, 55)
        Me.rbAbs.Name = "rbAbs"
        Me.rbAbs.Size = New System.Drawing.Size(48, 19)
        Me.rbAbs.TabIndex = 4
        Me.rbAbs.Text = "ABS"
        Me.rbAbs.UseVisualStyleBackColor = True
        '
        'btnXmove
        '
        Me.btnXmove.BackColor = System.Drawing.Color.Silver
        Me.btnXmove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXmove.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXmove.ForeColor = System.Drawing.Color.Black
        Me.btnXmove.Location = New System.Drawing.Point(15, 105)
        Me.btnXmove.Name = "btnXmove"
        Me.btnXmove.Size = New System.Drawing.Size(81, 25)
        Me.btnXmove.TabIndex = 6
        Me.btnXmove.Text = "X Axis Move"
        Me.btnXmove.UseVisualStyleBackColor = False
        '
        'gbMotion
        '
        Me.gbMotion.Controls.Add(Me.GroupBox1)
        Me.gbMotion.Controls.Add(Me.GroupBox2)
        Me.gbMotion.Controls.Add(Me.ucMotionIndicator)
        Me.gbMotion.Controls.Add(Me.gbManualCtrl)
        Me.gbMotion.Controls.Add(Me.gbJOG)
        Me.gbMotion.Location = New System.Drawing.Point(4, 4)
        Me.gbMotion.Name = "gbMotion"
        Me.gbMotion.Size = New System.Drawing.Size(322, 899)
        Me.gbMotion.TabIndex = 10
        Me.gbMotion.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel9)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 862)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(302, 168)
        Me.GroupBox1.TabIndex = 81
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.White
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.btnSetPositionOffset)
        Me.Panel9.Controls.Add(Me.Label25)
        Me.Panel9.Controls.Add(Me.Label24)
        Me.Panel9.Controls.Add(Me.Label23)
        Me.Panel9.Controls.Add(Me.Label22)
        Me.Panel9.Controls.Add(Me.Label20)
        Me.Panel9.Controls.Add(Me.Label19)
        Me.Panel9.Controls.Add(Me.Label21)
        Me.Panel9.Controls.Add(Me.Label18)
        Me.Panel9.Controls.Add(Me.tbXOffset)
        Me.Panel9.Controls.Add(Me.Button2)
        Me.Panel9.Controls.Add(Me.tbYPos)
        Me.Panel9.Controls.Add(Me.tbYCurrPos)
        Me.Panel9.Controls.Add(Me.tbXCurrPos)
        Me.Panel9.Controls.Add(Me.tbYOffset)
        Me.Panel9.Controls.Add(Me.tbXPos)
        Me.Panel9.Controls.Add(Me.tbZPos)
        Me.Panel9.Controls.Add(Me.tbZOffset)
        Me.Panel9.Controls.Add(Me.tbZCurrPos)
        Me.Panel9.Location = New System.Drawing.Point(7, 12)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(281, 164)
        Me.Panel9.TabIndex = 67
        Me.Panel9.Visible = False
        '
        'btnSetPositionOffset
        '
        Me.btnSetPositionOffset.BackColor = System.Drawing.Color.Silver
        Me.btnSetPositionOffset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetPositionOffset.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetPositionOffset.Location = New System.Drawing.Point(118, 127)
        Me.btnSetPositionOffset.Name = "btnSetPositionOffset"
        Me.btnSetPositionOffset.Size = New System.Drawing.Size(147, 27)
        Me.btnSetPositionOffset.TabIndex = 70
        Me.btnSetPositionOffset.Text = "Set Offset All Channel"
        Me.btnSetPositionOffset.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(10, 102)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(14, 15)
        Me.Label25.TabIndex = 84
        Me.Label25.Text = "Z"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(10, 75)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(14, 15)
        Me.Label24.TabIndex = 83
        Me.Label24.Text = "Y"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(10, 48)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(15, 15)
        Me.Label23.TabIndex = 82
        Me.Label23.Text = "X"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(206, 28)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(42, 15)
        Me.Label22.TabIndex = 81
        Me.Label22.Text = "Offset"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Gainsboro
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DimGray
        Me.Label20.Location = New System.Drawing.Point(0, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(136, 22)
        Me.Label20.TabIndex = 15
        Me.Label20.Text = "Position Offset"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(113, 28)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 15)
        Me.Label19.TabIndex = 80
        Me.Label19.Text = "Modify Pos"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.DarkGray
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label21.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Orange
        Me.Label21.Location = New System.Drawing.Point(0, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(279, 22)
        Me.Label21.TabIndex = 16
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(37, 28)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 15)
        Me.Label18.TabIndex = 71
        Me.Label18.Text = " Move Pos"
        '
        'tbXOffset
        '
        Me.tbXOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbXOffset.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbXOffset.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbXOffset.Location = New System.Drawing.Point(190, 46)
        Me.tbXOffset.Name = "tbXOffset"
        Me.tbXOffset.Size = New System.Drawing.Size(75, 21)
        Me.tbXOffset.TabIndex = 78
        Me.tbXOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Silver
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(31, 127)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 27)
        Me.Button2.TabIndex = 79
        Me.Button2.Text = "Set Offset"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'tbYPos
        '
        Me.tbYPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbYPos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbYPos.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbYPos.Location = New System.Drawing.Point(31, 73)
        Me.tbYPos.Name = "tbYPos"
        Me.tbYPos.Size = New System.Drawing.Size(75, 21)
        Me.tbYPos.TabIndex = 70
        Me.tbYPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbYCurrPos
        '
        Me.tbYCurrPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbYCurrPos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbYCurrPos.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbYCurrPos.Location = New System.Drawing.Point(110, 73)
        Me.tbYCurrPos.Name = "tbYCurrPos"
        Me.tbYCurrPos.Size = New System.Drawing.Size(75, 21)
        Me.tbYCurrPos.TabIndex = 71
        Me.tbYCurrPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbXCurrPos
        '
        Me.tbXCurrPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbXCurrPos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbXCurrPos.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbXCurrPos.Location = New System.Drawing.Point(110, 46)
        Me.tbXCurrPos.Name = "tbXCurrPos"
        Me.tbXCurrPos.Size = New System.Drawing.Size(75, 21)
        Me.tbXCurrPos.TabIndex = 77
        Me.tbXCurrPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbYOffset
        '
        Me.tbYOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbYOffset.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbYOffset.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbYOffset.Location = New System.Drawing.Point(190, 73)
        Me.tbYOffset.Name = "tbYOffset"
        Me.tbYOffset.Size = New System.Drawing.Size(75, 21)
        Me.tbYOffset.TabIndex = 72
        Me.tbYOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbXPos
        '
        Me.tbXPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbXPos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbXPos.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbXPos.Location = New System.Drawing.Point(31, 46)
        Me.tbXPos.Name = "tbXPos"
        Me.tbXPos.Size = New System.Drawing.Size(75, 21)
        Me.tbXPos.TabIndex = 76
        Me.tbXPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbZPos
        '
        Me.tbZPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbZPos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbZPos.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbZPos.Location = New System.Drawing.Point(31, 100)
        Me.tbZPos.Name = "tbZPos"
        Me.tbZPos.Size = New System.Drawing.Size(75, 21)
        Me.tbZPos.TabIndex = 73
        Me.tbZPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbZOffset
        '
        Me.tbZOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbZOffset.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbZOffset.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbZOffset.Location = New System.Drawing.Point(190, 100)
        Me.tbZOffset.Name = "tbZOffset"
        Me.tbZOffset.Size = New System.Drawing.Size(75, 21)
        Me.tbZOffset.TabIndex = 75
        Me.tbZOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbZCurrPos
        '
        Me.tbZCurrPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbZCurrPos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbZCurrPos.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbZCurrPos.Location = New System.Drawing.Point(110, 100)
        Me.tbZCurrPos.Name = "tbZCurrPos"
        Me.tbZCurrPos.Size = New System.Drawing.Size(75, 21)
        Me.tbZCurrPos.TabIndex = 74
        Me.tbZCurrPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox2.Controls.Add(Me.Panel3)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 694)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(305, 162)
        Me.GroupBox2.TabIndex = 67
        Me.GroupBox2.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.chkManualPos)
        Me.Panel3.Controls.Add(Me.btnLampOnOff)
        Me.Panel3.Controls.Add(Me.btnAutoCenteringOffset)
        Me.Panel3.Controls.Add(Me.btnSetLampLevel)
        Me.Panel3.Controls.Add(Me.tbSetLampLevel)
        Me.Panel3.Controls.Add(Me.cbChangePosition)
        Me.Panel3.Controls.Add(Me.txtLoadPositionName)
        Me.Panel3.Controls.Add(Me.cbChannel)
        Me.Panel3.Controls.Add(Me.btnMove)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.btnPositionSave)
        Me.Panel3.Location = New System.Drawing.Point(10, 13)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(280, 143)
        Me.Panel3.TabIndex = 67
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Silver
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(534, 841)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(143, 30)
        Me.Button6.TabIndex = 88
        Me.Button6.Text = "Theta Homing"
        Me.Button6.UseVisualStyleBackColor = False
        Me.Button6.Visible = False
        '
        'chkManualPos
        '
        Me.chkManualPos.AutoSize = True
        Me.chkManualPos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkManualPos.Location = New System.Drawing.Point(12, 143)
        Me.chkManualPos.Name = "chkManualPos"
        Me.chkManualPos.Size = New System.Drawing.Size(64, 16)
        Me.chkManualPos.TabIndex = 87
        Me.chkManualPos.Text = "Manual"
        Me.chkManualPos.UseVisualStyleBackColor = True
        Me.chkManualPos.Visible = False
        '
        'btnLampOnOff
        '
        Me.btnLampOnOff.BackColor = System.Drawing.Color.Silver
        Me.btnLampOnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLampOnOff.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLampOnOff.Location = New System.Drawing.Point(31, 136)
        Me.btnLampOnOff.Name = "btnLampOnOff"
        Me.btnLampOnOff.Size = New System.Drawing.Size(45, 27)
        Me.btnLampOnOff.TabIndex = 79
        Me.btnLampOnOff.Text = "On"
        Me.btnLampOnOff.UseVisualStyleBackColor = False
        Me.btnLampOnOff.Visible = False
        '
        'btnAutoCenteringOffset
        '
        Me.btnAutoCenteringOffset.BackColor = System.Drawing.Color.SandyBrown
        Me.btnAutoCenteringOffset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoCenteringOffset.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoCenteringOffset.Location = New System.Drawing.Point(31, 129)
        Me.btnAutoCenteringOffset.Name = "btnAutoCenteringOffset"
        Me.btnAutoCenteringOffset.Size = New System.Drawing.Size(186, 30)
        Me.btnAutoCenteringOffset.TabIndex = 83
        Me.btnAutoCenteringOffset.Text = "Set All Channel Align Offset"
        Me.btnAutoCenteringOffset.UseVisualStyleBackColor = False
        Me.btnAutoCenteringOffset.Visible = False
        '
        'btnSetLampLevel
        '
        Me.btnSetLampLevel.BackColor = System.Drawing.Color.Silver
        Me.btnSetLampLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetLampLevel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetLampLevel.Location = New System.Drawing.Point(20, 143)
        Me.btnSetLampLevel.Name = "btnSetLampLevel"
        Me.btnSetLampLevel.Size = New System.Drawing.Size(109, 27)
        Me.btnSetLampLevel.TabIndex = 78
        Me.btnSetLampLevel.Text = "Set Lamp Level"
        Me.btnSetLampLevel.UseVisualStyleBackColor = False
        Me.btnSetLampLevel.Visible = False
        '
        'tbSetLampLevel
        '
        Me.tbSetLampLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSetLampLevel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSetLampLevel.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSetLampLevel.Location = New System.Drawing.Point(14, 176)
        Me.tbSetLampLevel.Name = "tbSetLampLevel"
        Me.tbSetLampLevel.Size = New System.Drawing.Size(89, 21)
        Me.tbSetLampLevel.TabIndex = 77
        Me.tbSetLampLevel.Text = "255"
        Me.tbSetLampLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbSetLampLevel.Visible = False
        '
        'cbChangePosition
        '
        Me.cbChangePosition.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbChangePosition.BackColor = System.Drawing.Color.Silver
        Me.cbChangePosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbChangePosition.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbChangePosition.Location = New System.Drawing.Point(10, 37)
        Me.cbChangePosition.Name = "cbChangePosition"
        Me.cbChangePosition.Size = New System.Drawing.Size(141, 30)
        Me.cbChangePosition.TabIndex = 67
        Me.cbChangePosition.Text = "CCD ⇔ Spectrometer"
        Me.cbChangePosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cbChangePosition.UseVisualStyleBackColor = False
        '
        'txtLoadPositionName
        '
        Me.txtLoadPositionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoadPositionName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadPositionName.Location = New System.Drawing.Point(10, 109)
        Me.txtLoadPositionName.Name = "txtLoadPositionName"
        Me.txtLoadPositionName.Size = New System.Drawing.Size(254, 21)
        Me.txtLoadPositionName.TabIndex = 69
        Me.txtLoadPositionName.Visible = False
        '
        'cbChannel
        '
        Me.cbChannel.FormattingEnabled = True
        Me.cbChannel.Location = New System.Drawing.Point(108, 11)
        Me.cbChannel.Name = "cbChannel"
        Me.cbChannel.Size = New System.Drawing.Size(158, 20)
        Me.cbChannel.TabIndex = 64
        '
        'btnMove
        '
        Me.btnMove.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMove.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMove.Location = New System.Drawing.Point(159, 37)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(107, 30)
        Me.btnMove.TabIndex = 66
        Me.btnMove.Text = "MOVE"
        Me.btnMove.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 15)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Select Channel"
        '
        'btnPositionSave
        '
        Me.btnPositionSave.BackColor = System.Drawing.Color.LightCoral
        Me.btnPositionSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPositionSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPositionSave.Location = New System.Drawing.Point(159, 73)
        Me.btnPositionSave.Name = "btnPositionSave"
        Me.btnPositionSave.Size = New System.Drawing.Size(107, 30)
        Me.btnPositionSave.TabIndex = 63
        Me.btnPositionSave.Text = "Save Position"
        Me.btnPositionSave.UseVisualStyleBackColor = False
        '
        'btnLoadPosition
        '
        Me.btnLoadPosition.BackColor = System.Drawing.Color.Silver
        Me.btnLoadPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPosition.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadPosition.Location = New System.Drawing.Point(338, 815)
        Me.btnLoadPosition.Name = "btnLoadPosition"
        Me.btnLoadPosition.Size = New System.Drawing.Size(140, 30)
        Me.btnLoadPosition.TabIndex = 68
        Me.btnLoadPosition.Text = "Load Position File"
        Me.btnLoadPosition.UseVisualStyleBackColor = False
        Me.btnLoadPosition.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(680, 957)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(74, 15)
        Me.Label26.TabIndex = 86
        Me.Label26.Text = "Select Pixel"
        Me.Label26.Visible = False
        '
        'cbIndex
        '
        Me.cbIndex.FormattingEnabled = True
        Me.cbIndex.Items.AddRange(New Object() {"1L", "2L", "3L", "4L"})
        Me.cbIndex.Location = New System.Drawing.Point(766, 954)
        Me.cbIndex.Name = "cbIndex"
        Me.cbIndex.Size = New System.Drawing.Size(75, 20)
        Me.cbIndex.TabIndex = 85
        Me.cbIndex.Visible = False
        '
        'rbSpectrometer
        '
        Me.rbSpectrometer.AutoSize = True
        Me.rbSpectrometer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbSpectrometer.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSpectrometer.Location = New System.Drawing.Point(392, 857)
        Me.rbSpectrometer.Name = "rbSpectrometer"
        Me.rbSpectrometer.Size = New System.Drawing.Size(103, 19)
        Me.rbSpectrometer.TabIndex = 70
        Me.rbSpectrometer.Text = "Spectrometer"
        Me.rbSpectrometer.UseVisualStyleBackColor = True
        Me.rbSpectrometer.Visible = False
        '
        'rbCCD
        '
        Me.rbCCD.AutoSize = True
        Me.rbCCD.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbCCD.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCCD.Location = New System.Drawing.Point(338, 857)
        Me.rbCCD.Name = "rbCCD"
        Me.rbCCD.Size = New System.Drawing.Size(48, 19)
        Me.rbCCD.TabIndex = 68
        Me.rbCCD.Text = "CCD"
        Me.rbCCD.UseVisualStyleBackColor = True
        Me.rbCCD.Visible = False
        '
        'btn_ServoOff
        '
        Me.btn_ServoOff.BackColor = System.Drawing.Color.Silver
        Me.btn_ServoOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ServoOff.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ServoOff.Location = New System.Drawing.Point(426, 748)
        Me.btn_ServoOff.Name = "btn_ServoOff"
        Me.btn_ServoOff.Size = New System.Drawing.Size(80, 30)
        Me.btn_ServoOff.TabIndex = 12
        Me.btn_ServoOff.Text = "Servo Off"
        Me.btn_ServoOff.UseVisualStyleBackColor = False
        Me.btn_ServoOff.Visible = False
        '
        'btn_ServoOn
        '
        Me.btn_ServoOn.BackColor = System.Drawing.Color.Silver
        Me.btn_ServoOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ServoOn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ServoOn.Location = New System.Drawing.Point(342, 748)
        Me.btn_ServoOn.Name = "btn_ServoOn"
        Me.btn_ServoOn.Size = New System.Drawing.Size(80, 30)
        Me.btn_ServoOn.TabIndex = 11
        Me.btn_ServoOn.Text = "Servo On"
        Me.btn_ServoOn.UseVisualStyleBackColor = False
        Me.btn_ServoOn.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel8, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(338, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.42756!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.57244!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1141, 566)
        Me.TableLayoutPanel1.TabIndex = 65
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.pnDispProcImage)
        Me.Panel8.Controls.Add(Me.Label16)
        Me.Panel8.Controls.Add(Me.Label17)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(573, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(565, 352)
        Me.Panel8.TabIndex = 69
        '
        'pnDispProcImage
        '
        Me.pnDispProcImage.BackColor = System.Drawing.Color.Black
        Me.pnDispProcImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnDispProcImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnDispProcImage.Location = New System.Drawing.Point(0, 22)
        Me.pnDispProcImage.Name = "pnDispProcImage"
        Me.pnDispProcImage.Size = New System.Drawing.Size(563, 328)
        Me.pnDispProcImage.TabIndex = 62
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Gainsboro
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(169, 22)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Image Analyzer View"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DarkGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Orange
        Me.Label17.Location = New System.Drawing.Point(0, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(563, 22)
        Me.Label17.TabIndex = 16
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.gbACFCtrl)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 361)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1135, 202)
        Me.Panel1.TabIndex = 0
        '
        'gbACFCtrl
        '
        Me.gbACFCtrl.Controls.Add(Me.Panel6)
        Me.gbACFCtrl.Location = New System.Drawing.Point(3, 6)
        Me.gbACFCtrl.Name = "gbACFCtrl"
        Me.gbACFCtrl.Size = New System.Drawing.Size(811, 189)
        Me.gbACFCtrl.TabIndex = 59
        Me.gbACFCtrl.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.rbCaptWebcam)
        Me.Panel6.Controls.Add(Me.rbCaptCCD)
        Me.Panel6.Controls.Add(Me.btnCaptureArea)
        Me.Panel6.Controls.Add(Me.btnCaptureImage)
        Me.Panel6.Controls.Add(Me.listACFInfo)
        Me.Panel6.Controls.Add(Me.btnClear)
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Controls.Add(Me.btnRunACF)
        Me.Panel6.Controls.Add(Me.Label13)
        Me.Panel6.Controls.Add(Me.btnAnalysisImage)
        Me.Panel6.Controls.Add(Me.btnAutoFocusing)
        Me.Panel6.Controls.Add(Me.btnIntensityAdj)
        Me.Panel6.Controls.Add(Me.btnAutoCentering)
        Me.Panel6.Location = New System.Drawing.Point(6, 12)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(799, 172)
        Me.Panel6.TabIndex = 69
        '
        'rbCaptWebcam
        '
        Me.rbCaptWebcam.AutoSize = True
        Me.rbCaptWebcam.Checked = True
        Me.rbCaptWebcam.Font = New System.Drawing.Font("Segoe UI Symbol", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCaptWebcam.Location = New System.Drawing.Point(535, 46)
        Me.rbCaptWebcam.Name = "rbCaptWebcam"
        Me.rbCaptWebcam.Size = New System.Drawing.Size(58, 16)
        Me.rbCaptWebcam.TabIndex = 69
        Me.rbCaptWebcam.TabStop = True
        Me.rbCaptWebcam.Text = "Webcam"
        Me.rbCaptWebcam.UseVisualStyleBackColor = True
        Me.rbCaptWebcam.Visible = False
        '
        'rbCaptCCD
        '
        Me.rbCaptCCD.AutoSize = True
        Me.rbCaptCCD.Font = New System.Drawing.Font("Segoe UI Symbol", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCaptCCD.Location = New System.Drawing.Point(535, 29)
        Me.rbCaptCCD.Name = "rbCaptCCD"
        Me.rbCaptCCD.Size = New System.Drawing.Size(41, 16)
        Me.rbCaptCCD.TabIndex = 68
        Me.rbCaptCCD.Text = "CCD"
        Me.rbCaptCCD.UseVisualStyleBackColor = True
        Me.rbCaptCCD.Visible = False
        '
        'btnCaptureArea
        '
        Me.btnCaptureArea.BackColor = System.Drawing.Color.LightSalmon
        Me.btnCaptureArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCaptureArea.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCaptureArea.Location = New System.Drawing.Point(683, 33)
        Me.btnCaptureArea.Name = "btnCaptureArea"
        Me.btnCaptureArea.Size = New System.Drawing.Size(66, 25)
        Me.btnCaptureArea.TabIndex = 67
        Me.btnCaptureArea.Text = "Set Area"
        Me.btnCaptureArea.UseVisualStyleBackColor = False
        Me.btnCaptureArea.Visible = False
        '
        'btnCaptureImage
        '
        Me.btnCaptureImage.BackColor = System.Drawing.Color.LightSalmon
        Me.btnCaptureImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCaptureImage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCaptureImage.Location = New System.Drawing.Point(601, 33)
        Me.btnCaptureImage.Name = "btnCaptureImage"
        Me.btnCaptureImage.Size = New System.Drawing.Size(76, 25)
        Me.btnCaptureImage.TabIndex = 66
        Me.btnCaptureImage.Text = "Capture"
        Me.btnCaptureImage.UseVisualStyleBackColor = False
        Me.btnCaptureImage.Visible = False
        '
        'listACFInfo
        '
        Me.listACFInfo.BackColor = System.Drawing.Color.Gainsboro
        Me.listACFInfo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listACFInfo.HideSelection = False
        Me.listACFInfo.Location = New System.Drawing.Point(9, 65)
        Me.listACFInfo.Name = "listACFInfo"
        Me.listACFInfo.Size = New System.Drawing.Size(781, 100)
        Me.listACFInfo.TabIndex = 13
        Me.listACFInfo.UseCompatibleStateImageBehavior = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Silver
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(442, 33)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(81, 25)
        Me.btnClear.TabIndex = 15
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Gainsboro
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(0, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(240, 22)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "ACF (Auto centering && Focusing)"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRunACF
        '
        Me.btnRunACF.BackColor = System.Drawing.Color.Silver
        Me.btnRunACF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRunACF.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRunACF.Location = New System.Drawing.Point(9, 33)
        Me.btnRunACF.Name = "btnRunACF"
        Me.btnRunACF.Size = New System.Drawing.Size(81, 25)
        Me.btnRunACF.TabIndex = 14
        Me.btnRunACF.Text = "Run ACF"
        Me.btnRunACF.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DarkGray
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label13.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Orange
        Me.Label13.Location = New System.Drawing.Point(0, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(797, 22)
        Me.Label13.TabIndex = 16
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAnalysisImage
        '
        Me.btnAnalysisImage.BackColor = System.Drawing.Color.Silver
        Me.btnAnalysisImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnalysisImage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnalysisImage.Location = New System.Drawing.Point(356, 33)
        Me.btnAnalysisImage.Name = "btnAnalysisImage"
        Me.btnAnalysisImage.Size = New System.Drawing.Size(81, 25)
        Me.btnAnalysisImage.TabIndex = 12
        Me.btnAnalysisImage.Text = "Analysis"
        Me.btnAnalysisImage.UseVisualStyleBackColor = False
        '
        'btnAutoFocusing
        '
        Me.btnAutoFocusing.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnAutoFocusing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoFocusing.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoFocusing.Location = New System.Drawing.Point(96, 33)
        Me.btnAutoFocusing.Name = "btnAutoFocusing"
        Me.btnAutoFocusing.Size = New System.Drawing.Size(81, 25)
        Me.btnAutoFocusing.TabIndex = 9
        Me.btnAutoFocusing.Text = "Focusing"
        Me.btnAutoFocusing.UseVisualStyleBackColor = False
        Me.btnAutoFocusing.Visible = False
        '
        'btnIntensityAdj
        '
        Me.btnIntensityAdj.BackColor = System.Drawing.Color.Silver
        Me.btnIntensityAdj.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIntensityAdj.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIntensityAdj.Location = New System.Drawing.Point(269, 33)
        Me.btnIntensityAdj.Name = "btnIntensityAdj"
        Me.btnIntensityAdj.Size = New System.Drawing.Size(81, 25)
        Me.btnIntensityAdj.TabIndex = 11
        Me.btnIntensityAdj.Text = "Adjusting"
        Me.btnIntensityAdj.UseVisualStyleBackColor = False
        '
        'btnAutoCentering
        '
        Me.btnAutoCentering.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnAutoCentering.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoCentering.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoCentering.Location = New System.Drawing.Point(183, 33)
        Me.btnAutoCentering.Name = "btnAutoCentering"
        Me.btnAutoCentering.Size = New System.Drawing.Size(81, 25)
        Me.btnAutoCentering.TabIndex = 10
        Me.btnAutoCentering.Text = "Centering"
        Me.btnAutoCentering.UseVisualStyleBackColor = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.pnDispGrabImg)
        Me.Panel7.Controls.Add(Me.Label11)
        Me.Panel7.Controls.Add(Me.Label15)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(564, 352)
        Me.Panel7.TabIndex = 68
        '
        'pnDispGrabImg
        '
        Me.pnDispGrabImg.BackColor = System.Drawing.Color.Black
        Me.pnDispGrabImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnDispGrabImg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnDispGrabImg.Location = New System.Drawing.Point(0, 22)
        Me.pnDispGrabImg.Name = "pnDispGrabImg"
        Me.pnDispGrabImg.Size = New System.Drawing.Size(562, 328)
        Me.pnDispGrabImg.TabIndex = 61
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Gainsboro
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(129, 22)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "CCD View"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DarkGray
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label15.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Orange
        Me.Label15.Location = New System.Drawing.Point(0, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(562, 22)
        Me.Label15.TabIndex = 16
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbACFMeas
        '
        Me.gbACFMeas.Controls.Add(Me.Panel5)
        Me.gbACFMeas.Location = New System.Drawing.Point(1147, 591)
        Me.gbACFMeas.Name = "gbACFMeas"
        Me.gbACFMeas.Size = New System.Drawing.Size(307, 191)
        Me.gbACFMeas.TabIndex = 66
        Me.gbACFMeas.TabStop = False
        Me.gbACFMeas.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.tbACFMeasState)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.tbACFSavePath)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.tbACFChannel)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.btnSavePath)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.btnACFStop)
        Me.Panel5.Controls.Add(Me.btnACFStart)
        Me.Panel5.Location = New System.Drawing.Point(5, 13)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(297, 172)
        Me.Panel5.TabIndex = 68
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 15)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "ACF State"
        '
        'tbACFMeasState
        '
        Me.tbACFMeasState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbACFMeasState.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbACFMeasState.Location = New System.Drawing.Point(7, 143)
        Me.tbACFMeasState.Name = "tbACFMeasState"
        Me.tbACFMeasState.Size = New System.Drawing.Size(278, 21)
        Me.tbACFMeasState.TabIndex = 63
        Me.tbACFMeasState.Text = "IDEL"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 22)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "ACF Measure"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbACFSavePath
        '
        Me.tbACFSavePath.BackColor = System.Drawing.Color.Gainsboro
        Me.tbACFSavePath.Location = New System.Drawing.Point(7, 84)
        Me.tbACFSavePath.Multiline = True
        Me.tbACFSavePath.Name = "tbACFSavePath"
        Me.tbACFSavePath.ReadOnly = True
        Me.tbACFSavePath.Size = New System.Drawing.Size(278, 35)
        Me.tbACFSavePath.TabIndex = 62
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DarkGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Orange
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(295, 22)
        Me.Label9.TabIndex = 16
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbACFChannel
        '
        Me.tbACFChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbACFChannel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbACFChannel.Location = New System.Drawing.Point(93, 59)
        Me.tbACFChannel.Name = "tbACFChannel"
        Me.tbACFChannel.Size = New System.Drawing.Size(191, 21)
        Me.tbACFChannel.TabIndex = 60
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 15)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Channel"
        '
        'btnSavePath
        '
        Me.btnSavePath.BackColor = System.Drawing.Color.Silver
        Me.btnSavePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSavePath.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSavePath.Location = New System.Drawing.Point(3, 28)
        Me.btnSavePath.Name = "btnSavePath"
        Me.btnSavePath.Size = New System.Drawing.Size(57, 25)
        Me.btnSavePath.TabIndex = 61
        Me.btnSavePath.Text = "SavePath"
        Me.btnSavePath.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(205, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 12)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "(ex. 1,2,1-10)"
        '
        'btnACFStop
        '
        Me.btnACFStop.BackColor = System.Drawing.Color.Silver
        Me.btnACFStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnACFStop.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnACFStop.Location = New System.Drawing.Point(123, 28)
        Me.btnACFStop.Name = "btnACFStop"
        Me.btnACFStop.Size = New System.Drawing.Size(57, 25)
        Me.btnACFStop.TabIndex = 54
        Me.btnACFStop.Text = "Stop"
        Me.btnACFStop.UseVisualStyleBackColor = False
        '
        'btnACFStart
        '
        Me.btnACFStart.BackColor = System.Drawing.Color.Silver
        Me.btnACFStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnACFStart.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnACFStart.Location = New System.Drawing.Point(63, 28)
        Me.btnACFStart.Name = "btnACFStart"
        Me.btnACFStart.Size = New System.Drawing.Size(57, 25)
        Me.btnACFStart.TabIndex = 57
        Me.btnACFStart.Text = "Start"
        Me.btnACFStart.UseVisualStyleBackColor = False
        '
        'gbACFCameraCtrl
        '
        Me.gbACFCameraCtrl.Controls.Add(Me.Panel4)
        Me.gbACFCameraCtrl.Location = New System.Drawing.Point(338, 576)
        Me.gbACFCameraCtrl.Name = "gbACFCameraCtrl"
        Me.gbACFCameraCtrl.Size = New System.Drawing.Size(296, 166)
        Me.gbACFCameraCtrl.TabIndex = 63
        Me.gbACFCameraCtrl.TabStop = False
        Me.gbACFCameraCtrl.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.ListBox1)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.btnInitCamera)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.btnAlliedStart)
        Me.Panel4.Controls.Add(Me.btnAlliedStop)
        Me.Panel4.Location = New System.Drawing.Point(9, 14)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(274, 139)
        Me.Panel4.TabIndex = 67
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(8, 64)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(255, 38)
        Me.ListBox1.TabIndex = 56
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Gainsboro
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(158, 22)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "ACF Camera Control"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnInitCamera
        '
        Me.btnInitCamera.BackColor = System.Drawing.Color.Silver
        Me.btnInitCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInitCamera.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInitCamera.Location = New System.Drawing.Point(8, 32)
        Me.btnInitCamera.Name = "btnInitCamera"
        Me.btnInitCamera.Size = New System.Drawing.Size(81, 25)
        Me.btnInitCamera.TabIndex = 57
        Me.btnInitCamera.Text = "Init"
        Me.btnInitCamera.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DarkGray
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Orange
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(272, 22)
        Me.Label8.TabIndex = 16
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAlliedStart
        '
        Me.btnAlliedStart.BackColor = System.Drawing.Color.Silver
        Me.btnAlliedStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlliedStart.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlliedStart.Location = New System.Drawing.Point(94, 32)
        Me.btnAlliedStart.Name = "btnAlliedStart"
        Me.btnAlliedStart.Size = New System.Drawing.Size(81, 25)
        Me.btnAlliedStart.TabIndex = 54
        Me.btnAlliedStart.Text = "Start"
        Me.btnAlliedStart.UseVisualStyleBackColor = False
        '
        'btnAlliedStop
        '
        Me.btnAlliedStop.BackColor = System.Drawing.Color.Silver
        Me.btnAlliedStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlliedStop.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlliedStop.Location = New System.Drawing.Point(181, 32)
        Me.btnAlliedStop.Name = "btnAlliedStop"
        Me.btnAlliedStop.Size = New System.Drawing.Size(81, 25)
        Me.btnAlliedStop.TabIndex = 55
        Me.btnAlliedStop.Text = "Stop"
        Me.btnAlliedStop.UseVisualStyleBackColor = False
        '
        'ucMotionIndicator
        '
        Me.ucMotionIndicator.BackColor = System.Drawing.Color.White
        Me.ucMotionIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ucMotionIndicator.Channel = Nothing
        Me.ucMotionIndicator.Location = New System.Drawing.Point(12, 14)
        Me.ucMotionIndicator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ucMotionIndicator.Name = "ucMotionIndicator"
        Me.ucMotionIndicator.OpticalHeaderPos = Nothing
        Me.ucMotionIndicator.Size = New System.Drawing.Size(298, 219)
        Me.ucMotionIndicator.TabIndex = 3
        Me.ucMotionIndicator.Theta1Pos = 0R
        Me.ucMotionIndicator.Theta2Pos = 0R
        Me.ucMotionIndicator.Theta3Pos = 0R
        Me.ucMotionIndicator.Theta4Pos = 0R
        Me.ucMotionIndicator.Title = Nothing
        Me.ucMotionIndicator.XPos = 0R
        Me.ucMotionIndicator.YPos = 0R
        Me.ucMotionIndicator.ZPos = 0R
        '
        'UcAlarmTest1
        '
        Me.UcAlarmTest1.Location = New System.Drawing.Point(808, 631)
        Me.UcAlarmTest1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UcAlarmTest1.Name = "UcAlarmTest1"
        Me.UcAlarmTest1.Size = New System.Drawing.Size(379, 68)
        Me.UcAlarmTest1.TabIndex = 1
        Me.UcAlarmTest1.Visible = False
        '
        'frmMotionUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1590, 1058)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.gbACFMeas)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.gbACFCameraCtrl)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.cbIndex)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.gbMotion)
        Me.Controls.Add(Me.btn_ServoOff)
        Me.Controls.Add(Me.btnLoadPosition)
        Me.Controls.Add(Me.btn_ServoOn)
        Me.Controls.Add(Me.btnThetaMove)
        Me.Controls.Add(Me.UcAlarmTest1)
        Me.Controls.Add(Me.rbSpectrometer)
        Me.Controls.Add(Me.rbCCD)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMotionUI"
        Me.gbJOG.ResumeLayout(False)
        Me.tlpJOG.ResumeLayout(False)
        Me.gbManualCtrl.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.gbMotion.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.gbACFCtrl.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.gbACFMeas.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.gbACFCameraCtrl.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UcAlarmTest1 As M7000.ucAlarmTest
    Friend WithEvents ucMotionIndicator As M7000.ucMotionIndicator
    Friend WithEvents gbJOG As System.Windows.Forms.GroupBox
    Friend WithEvents gbManualCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents btnZmove As System.Windows.Forms.Button
    Friend WithEvents btnYmove As System.Windows.Forms.Button
    Friend WithEvents btnXmove As System.Windows.Forms.Button
    Friend WithEvents chkTheta1 As System.Windows.Forms.CheckBox
    Friend WithEvents rbAbs As System.Windows.Forms.RadioButton
    Friend WithEvents rbMicroAdjust As System.Windows.Forms.RadioButton
    Friend WithEvents txtPosition As System.Windows.Forms.TextBox
    Friend WithEvents btnRD As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnLD As System.Windows.Forms.Button
    Friend WithEvents btnR As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnL As System.Windows.Forms.Button
    Friend WithEvents btnRU As System.Windows.Forms.Button
    Friend WithEvents btnUP As System.Windows.Forms.Button
    Friend WithEvents btnLU As System.Windows.Forms.Button
    Friend WithEvents tlpJOG As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gbMotion As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Homing As System.Windows.Forms.Button
    Friend WithEvents btn_ServoOff As System.Windows.Forms.Button
    Friend WithEvents btn_ServoOn As System.Windows.Forms.Button
    '  Friend WithEvents UcDispListView1 As M7000.ucDispListView
    Friend WithEvents btnThetaMove As System.Windows.Forms.Button
    Friend WithEvents cbChangePosition As System.Windows.Forms.CheckBox
    Friend WithEvents btnMove As System.Windows.Forms.Button
    Friend WithEvents btnPositionSave As System.Windows.Forms.Button
    Friend WithEvents cbChannel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gbACFCameraCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents btnInitCamera As System.Windows.Forms.Button
    Friend WithEvents btnAlliedStart As System.Windows.Forms.Button
    Friend WithEvents btnAlliedStop As System.Windows.Forms.Button
    Friend WithEvents gbACFCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRunACF As System.Windows.Forms.Button
    Friend WithEvents listACFInfo As System.Windows.Forms.ListView
    Friend WithEvents btnAnalysisImage As System.Windows.Forms.Button
    Friend WithEvents btnIntensityAdj As System.Windows.Forms.Button
    Friend WithEvents btnAutoCentering As System.Windows.Forms.Button
    Friend WithEvents btnAutoFocusing As System.Windows.Forms.Button
    Friend WithEvents pnDispGrabImg As System.Windows.Forms.Panel
    Friend WithEvents pnDispProcImage As System.Windows.Forms.Panel
    Friend WithEvents gbACFMeas As System.Windows.Forms.GroupBox
    Friend WithEvents btnACFStart As System.Windows.Forms.Button
    Friend WithEvents btnACFStop As System.Windows.Forms.Button
    Friend WithEvents tbACFSavePath As System.Windows.Forms.TextBox
    Friend WithEvents btnSavePath As System.Windows.Forms.Button
    Friend WithEvents tbACFChannel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbACFMeasState As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnCaptureImage As System.Windows.Forms.Button
    Friend WithEvents btnLoadPosition As System.Windows.Forms.Button
    Friend WithEvents txtLoadPositionName As System.Windows.Forms.TextBox
    Friend WithEvents btnSetPositionOffset As System.Windows.Forms.Button
    Friend WithEvents tbYPos As System.Windows.Forms.TextBox
    Friend WithEvents tbYCurrPos As System.Windows.Forms.TextBox
    Friend WithEvents tbYOffset As System.Windows.Forms.TextBox
    Friend WithEvents tbZOffset As System.Windows.Forms.TextBox
    Friend WithEvents tbZCurrPos As System.Windows.Forms.TextBox
    Friend WithEvents tbZPos As System.Windows.Forms.TextBox
    Friend WithEvents tbXOffset As System.Windows.Forms.TextBox
    Friend WithEvents tbXCurrPos As System.Windows.Forms.TextBox
    Friend WithEvents tbXPos As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSpectrometer As System.Windows.Forms.RadioButton
    Friend WithEvents rbCCD As System.Windows.Forms.RadioButton
    Friend WithEvents btnLampOnOff As System.Windows.Forms.Button
    Friend WithEvents btnSetLampLevel As System.Windows.Forms.Button
    Friend WithEvents tbSetLampLevel As System.Windows.Forms.TextBox
    Friend WithEvents btnCaptureArea As System.Windows.Forms.Button
    Friend WithEvents rbCaptWebcam As System.Windows.Forms.RadioButton
    Friend WithEvents rbCaptCCD As System.Windows.Forms.RadioButton
    Friend WithEvents cbIndex As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents chkManualPos As System.Windows.Forms.CheckBox
    Friend WithEvents btnAutoCenteringOffset As System.Windows.Forms.Button
    Friend WithEvents btnJOGMode_OFF As System.Windows.Forms.Button
    Friend WithEvents btnJOGMode_ON As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents chkTheta4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkTheta3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkTheta2 As System.Windows.Forms.CheckBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    '  Friend WithEvents UcSingleList1 As M7000.ucSingleList
End Class
