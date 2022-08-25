<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSGControl
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.btnDisconnection = New System.Windows.Forms.Button()
        Me.cbBaudRate = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPort = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_err = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbError = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cbSelDevice = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.btn_getadcoffset = New System.Windows.Forms.Button()
        Me.btn_setadcoffset = New System.Windows.Forms.Button()
        Me.btn_getadcslope = New System.Windows.Forms.Button()
        Me.btn_setadcslope = New System.Windows.Forms.Button()
        Me.btn_getdacoffset = New System.Windows.Forms.Button()
        Me.btn_setdacoffset = New System.Windows.Forms.Button()
        Me.btn_getdacslope = New System.Windows.Forms.Button()
        Me.btn_setdacslope = New System.Windows.Forms.Button()
        Me.btn_getCalApply = New System.Windows.Forms.Button()
        Me.btn_setCalApply = New System.Windows.Forms.Button()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.btn_getgpo_out_onoff = New System.Windows.Forms.Button()
        Me.btn_setgpo_out_onoff = New System.Windows.Forms.Button()
        Me.btn_getgpio_out_onoff = New System.Windows.Forms.Button()
        Me.btn_setgpio_out_onoff = New System.Windows.Forms.Button()
        Me.btn_gpio_Inputget = New System.Windows.Forms.Button()
        Me.btn_gpio_Inputset = New System.Windows.Forms.Button()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.btn_getaverallch = New System.Windows.Forms.Button()
        Me.btn_Setaverallch = New System.Windows.Forms.Button()
        Me.btn_getlimitTempallch = New System.Windows.Forms.Button()
        Me.btn_setlimitTempallch = New System.Windows.Forms.Button()
        Me.btn_GetlimitTemp1ch = New System.Windows.Forms.Button()
        Me.btn_setlimitTemp1ch = New System.Windows.Forms.Button()
        Me.btn_getlimitallch = New System.Windows.Forms.Button()
        Me.btn_setlimitallch = New System.Windows.Forms.Button()
        Me.btn_getlimit1ch = New System.Windows.Forms.Button()
        Me.btn_setlimit1ch = New System.Windows.Forms.Button()
        Me.btn_getaver1ch = New System.Windows.Forms.Button()
        Me.btn_Setaver1ch = New System.Windows.Forms.Button()
        Me.btn_readadcallch = New System.Windows.Forms.Button()
        Me.btn_readadc1ch = New System.Windows.Forms.Button()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.bnt_getallchpulse = New System.Windows.Forms.Button()
        Me.bnt_setallchpulse = New System.Windows.Forms.Button()
        Me.bnt_get1chpulse = New System.Windows.Forms.Button()
        Me.bnt_set1chpulse = New System.Windows.Forms.Button()
        Me.bnt_getallchfOutput = New System.Windows.Forms.Button()
        Me.bnt_setallchfOutput = New System.Windows.Forms.Button()
        Me.bnt_Get1chfOutput = New System.Windows.Forms.Button()
        Me.bnt_set1chfOutput = New System.Windows.Forms.Button()
        Me.bnt_getallchOnoff = New System.Windows.Forms.Button()
        Me.bnt_setallchOnoff = New System.Windows.Forms.Button()
        Me.bnt_get1chOnoff = New System.Windows.Forms.Button()
        Me.bnt_set1chOnoff = New System.Windows.Forms.Button()
        Me.btn_getmodeallch = New System.Windows.Forms.Button()
        Me.btn_setmodeallch = New System.Windows.Forms.Button()
        Me.btn_Getmode1ch = New System.Windows.Forms.Button()
        Me.btn_setmode1ch = New System.Windows.Forms.Button()
        Me.btn_getallch = New System.Windows.Forms.Button()
        Me.btn_setallch = New System.Windows.Forms.Button()
        Me.btn_get1ch = New System.Windows.Forms.Button()
        Me.btn_set1ch = New System.Windows.Forms.Button()
        Me.btn_GetAalarm = New System.Windows.Forms.Button()
        Me.btn_setalarm = New System.Windows.Forms.Button()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.UcSingleList1 = New M7000.ucSingleList()
        Me.btn_chaddrset = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_ch = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_addrs = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.GroupBox21 = New System.Windows.Forms.GroupBox()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.chk_mainall = New System.Windows.Forms.CheckBox()
        Me.cbo_Mainch = New System.Windows.Forms.ComboBox()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.chk_sigall = New System.Windows.Forms.CheckBox()
        Me.cbo_sigch = New System.Windows.Forms.ComboBox()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.lblUnitPulseDelay = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblUnitPulsePeriod = New System.Windows.Forms.Label()
        Me.txtwidth = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtdelay = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtperiod = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chk_suball = New System.Windows.Forms.CheckBox()
        Me.cbo_subch = New System.Windows.Forms.ComboBox()
        Me.btnSetDAC_Low = New System.Windows.Forms.Button()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.rdo_subpusle = New System.Windows.Forms.RadioButton()
        Me.rdo_subdc = New System.Windows.Forms.RadioButton()
        Me.txt_SubLow = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_SubHigh = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbl_dacnum1 = New System.Windows.Forms.Label()
        Me.rdo_sublow = New System.Windows.Forms.RadioButton()
        Me.lbl_dacnum2 = New System.Windows.Forms.Label()
        Me.rdo_subhigh = New System.Windows.Forms.RadioButton()
        Me.Ucgpio1 = New M7000.Ucgpio()
        Me.UcADcFrame1 = New M7000.UcADcFrame()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txt_sCh1 = New System.Windows.Forms.TextBox()
        Me.grb_Adc = New System.Windows.Forms.GroupBox()
        Me.txt_limit = New System.Windows.Forms.TextBox()
        Me.txt_limitTemp = New System.Windows.Forms.TextBox()
        Me.btn_multiLimitCurr = New System.Windows.Forms.Button()
        Me.txt_avercount = New System.Windows.Forms.TextBox()
        Me.btn_reset = New System.Windows.Forms.Button()
        Me.btn_multiaverset = New System.Windows.Forms.Button()
        Me.btn_read = New System.Windows.Forms.Button()
        Me.btn_multiLimittemp = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txt_sCh = New System.Windows.Forms.TextBox()
        Me.grb_Dac = New System.Windows.Forms.GroupBox()
        Me.btn_DacmultichSet = New System.Windows.Forms.Button()
        Me.btn_dacmultichoff = New System.Windows.Forms.Button()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_delay = New System.Windows.Forms.TextBox()
        Me.txt_width = New System.Windows.Forms.TextBox()
        Me.txt_period = New System.Windows.Forms.TextBox()
        Me.rdo_pulseMode = New System.Windows.Forms.RadioButton()
        Me.rdo_dcMode = New System.Windows.Forms.RadioButton()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.txt_dacLsetmulti = New System.Windows.Forms.TextBox()
        Me.txt_dacHsetmulti = New System.Windows.Forms.TextBox()
        Me.rdo_ch2 = New System.Windows.Forms.RadioButton()
        Me.rdo_ch1 = New System.Windows.Forms.RadioButton()
        Me.chk_Sync = New System.Windows.Forms.CheckBox()
        Me.btn_dacmultichOnoff = New System.Windows.Forms.Button()
        Me.btn_DacmultichRead = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.chk_CalApply = New System.Windows.Forms.CheckBox()
        Me.Chk_All = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox21.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.grb_Adc.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.grb_Dac.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(185, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 35)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Ping"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(6, 181)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 35)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Reset"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(268, 38)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 35)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "frmLog"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(9, 20)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 35)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Board Info"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(302, 13)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(73, 35)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Register Init"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(6, 13)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(71, 35)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "Register Read"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(6, 12)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(94, 35)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "Get Complete"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(92, 181)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(80, 35)
        Me.Button8.TabIndex = 7
        Me.Button8.Text = "Save Data"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(6, 38)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(80, 36)
        Me.btnConnection.TabIndex = 8
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'btnDisconnection
        '
        Me.btnDisconnection.Location = New System.Drawing.Point(89, 38)
        Me.btnDisconnection.Name = "btnDisconnection"
        Me.btnDisconnection.Size = New System.Drawing.Size(94, 36)
        Me.btnDisconnection.TabIndex = 9
        Me.btnDisconnection.Text = "DisConnection"
        Me.btnDisconnection.UseVisualStyleBackColor = True
        '
        'cbBaudRate
        '
        Me.cbBaudRate.FormattingEnabled = True
        Me.cbBaudRate.Location = New System.Drawing.Point(215, 18)
        Me.cbBaudRate.Name = "cbBaudRate"
        Me.cbBaudRate.Size = New System.Drawing.Size(103, 20)
        Me.cbBaudRate.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(143, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 11)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Baud Rate"
        '
        'cboPort
        '
        Me.cboPort.FormattingEnabled = True
        Me.cboPort.Location = New System.Drawing.Point(45, 18)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Size = New System.Drawing.Size(91, 20)
        Me.cboPort.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 11)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Port"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.Location = New System.Drawing.Point(139, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 11)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Err Text"
        '
        'txt_err
        '
        Me.txt_err.Enabled = False
        Me.txt_err.Location = New System.Drawing.Point(199, 47)
        Me.txt_err.Multiline = True
        Me.txt_err.Name = "txt_err"
        Me.txt_err.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_err.Size = New System.Drawing.Size(182, 34)
        Me.txt_err.TabIndex = 46
        Me.txt_err.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 11)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Err Code"
        '
        'tbError
        '
        Me.tbError.Enabled = False
        Me.tbError.Location = New System.Drawing.Point(73, 47)
        Me.tbError.Name = "tbError"
        Me.tbError.Size = New System.Drawing.Size(48, 21)
        Me.tbError.TabIndex = 44
        Me.tbError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 215)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(379, 54)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(80, 13)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox2.Size = New System.Drawing.Size(216, 35)
        Me.TextBox2.TabIndex = 8
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextBox1)
        Me.GroupBox4.Controls.Add(Me.Button7)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 268)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(379, 52)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(114, 20)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(241, 21)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox5
        '
        Me.GroupBox5.AutoSize = True
        Me.GroupBox5.Controls.Add(Me.cbSelDevice)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.GroupBox13)
        Me.GroupBox5.Controls.Add(Me.GroupBox12)
        Me.GroupBox5.Controls.Add(Me.GroupBox11)
        Me.GroupBox5.Controls.Add(Me.GroupBox10)
        Me.GroupBox5.Controls.Add(Me.btn_GetAalarm)
        Me.GroupBox5.Controls.Add(Me.btn_setalarm)
        Me.GroupBox5.Controls.Add(Me.GroupBox9)
        Me.GroupBox5.Controls.Add(Me.btn_chaddrset)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.txt_ch)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.txt_addrs)
        Me.GroupBox5.Controls.Add(Me.GroupBox4)
        Me.GroupBox5.Controls.Add(Me.GroupBox3)
        Me.GroupBox5.Controls.Add(Me.btnDisconnection)
        Me.GroupBox5.Controls.Add(Me.btnConnection)
        Me.GroupBox5.Controls.Add(Me.Button8)
        Me.GroupBox5.Controls.Add(Me.Button3)
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Location = New System.Drawing.Point(9, 102)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(472, 942)
        Me.GroupBox5.TabIndex = 22
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Command"
        '
        'cbSelDevice
        '
        Me.cbSelDevice.FormattingEnabled = True
        Me.cbSelDevice.Location = New System.Drawing.Point(71, 13)
        Me.cbSelDevice.Name = "cbSelDevice"
        Me.cbSelDevice.Size = New System.Drawing.Size(59, 20)
        Me.cbSelDevice.TabIndex = 68
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label17.Location = New System.Drawing.Point(7, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 11)
        Me.Label17.TabIndex = 48
        Me.Label17.Text = "Device :"
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.btn_getadcoffset)
        Me.GroupBox13.Controls.Add(Me.btn_setadcoffset)
        Me.GroupBox13.Controls.Add(Me.btn_getadcslope)
        Me.GroupBox13.Controls.Add(Me.btn_setadcslope)
        Me.GroupBox13.Controls.Add(Me.btn_getdacoffset)
        Me.GroupBox13.Controls.Add(Me.btn_setdacoffset)
        Me.GroupBox13.Controls.Add(Me.btn_getdacslope)
        Me.GroupBox13.Controls.Add(Me.btn_setdacslope)
        Me.GroupBox13.Controls.Add(Me.btn_getCalApply)
        Me.GroupBox13.Controls.Add(Me.btn_setCalApply)
        Me.GroupBox13.Location = New System.Drawing.Point(9, 791)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(456, 131)
        Me.GroupBox13.TabIndex = 67
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "보상 값"
        '
        'btn_getadcoffset
        '
        Me.btn_getadcoffset.Location = New System.Drawing.Point(96, 87)
        Me.btn_getadcoffset.Name = "btn_getadcoffset"
        Me.btn_getadcoffset.Size = New System.Drawing.Size(94, 35)
        Me.btn_getadcoffset.TabIndex = 31
        Me.btn_getadcoffset.Text = "Get ADC  Offset"
        Me.btn_getadcoffset.UseVisualStyleBackColor = True
        '
        'btn_setadcoffset
        '
        Me.btn_setadcoffset.Location = New System.Drawing.Point(2, 87)
        Me.btn_setadcoffset.Name = "btn_setadcoffset"
        Me.btn_setadcoffset.Size = New System.Drawing.Size(94, 35)
        Me.btn_setadcoffset.TabIndex = 30
        Me.btn_setadcoffset.Text = "Set ADC  Offset"
        Me.btn_setadcoffset.UseVisualStyleBackColor = True
        '
        'btn_getadcslope
        '
        Me.btn_getadcslope.Location = New System.Drawing.Point(283, 51)
        Me.btn_getadcslope.Name = "btn_getadcslope"
        Me.btn_getadcslope.Size = New System.Drawing.Size(94, 35)
        Me.btn_getadcslope.TabIndex = 29
        Me.btn_getadcslope.Text = "Get ADC  Slope"
        Me.btn_getadcslope.UseVisualStyleBackColor = True
        '
        'btn_setadcslope
        '
        Me.btn_setadcslope.Location = New System.Drawing.Point(190, 51)
        Me.btn_setadcslope.Name = "btn_setadcslope"
        Me.btn_setadcslope.Size = New System.Drawing.Size(94, 35)
        Me.btn_setadcslope.TabIndex = 28
        Me.btn_setadcslope.Text = "Set ADC  Slope"
        Me.btn_setadcslope.UseVisualStyleBackColor = True
        '
        'btn_getdacoffset
        '
        Me.btn_getdacoffset.Location = New System.Drawing.Point(96, 51)
        Me.btn_getdacoffset.Name = "btn_getdacoffset"
        Me.btn_getdacoffset.Size = New System.Drawing.Size(94, 35)
        Me.btn_getdacoffset.TabIndex = 27
        Me.btn_getdacoffset.Text = "Get DAC  Offset"
        Me.btn_getdacoffset.UseVisualStyleBackColor = True
        '
        'btn_setdacoffset
        '
        Me.btn_setdacoffset.Location = New System.Drawing.Point(2, 51)
        Me.btn_setdacoffset.Name = "btn_setdacoffset"
        Me.btn_setdacoffset.Size = New System.Drawing.Size(94, 35)
        Me.btn_setdacoffset.TabIndex = 26
        Me.btn_setdacoffset.Text = "Set DAC  Offset"
        Me.btn_setdacoffset.UseVisualStyleBackColor = True
        '
        'btn_getdacslope
        '
        Me.btn_getdacslope.Location = New System.Drawing.Point(283, 15)
        Me.btn_getdacslope.Name = "btn_getdacslope"
        Me.btn_getdacslope.Size = New System.Drawing.Size(94, 35)
        Me.btn_getdacslope.TabIndex = 25
        Me.btn_getdacslope.Text = "Get DAC  Slope"
        Me.btn_getdacslope.UseVisualStyleBackColor = True
        '
        'btn_setdacslope
        '
        Me.btn_setdacslope.Location = New System.Drawing.Point(190, 15)
        Me.btn_setdacslope.Name = "btn_setdacslope"
        Me.btn_setdacslope.Size = New System.Drawing.Size(94, 35)
        Me.btn_setdacslope.TabIndex = 24
        Me.btn_setdacslope.Text = "Set DAC  Slope"
        Me.btn_setdacslope.UseVisualStyleBackColor = True
        '
        'btn_getCalApply
        '
        Me.btn_getCalApply.Enabled = False
        Me.btn_getCalApply.Location = New System.Drawing.Point(96, 15)
        Me.btn_getCalApply.Name = "btn_getCalApply"
        Me.btn_getCalApply.Size = New System.Drawing.Size(94, 35)
        Me.btn_getCalApply.TabIndex = 23
        Me.btn_getCalApply.Text = "Get Cal Apply"
        Me.btn_getCalApply.UseVisualStyleBackColor = True
        '
        'btn_setCalApply
        '
        Me.btn_setCalApply.Enabled = False
        Me.btn_setCalApply.Location = New System.Drawing.Point(2, 15)
        Me.btn_setCalApply.Name = "btn_setCalApply"
        Me.btn_setCalApply.Size = New System.Drawing.Size(94, 35)
        Me.btn_setCalApply.TabIndex = 22
        Me.btn_setCalApply.Text = "Set Cal Apply"
        Me.btn_setCalApply.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Button14)
        Me.GroupBox12.Controls.Add(Me.btn_getgpo_out_onoff)
        Me.GroupBox12.Controls.Add(Me.btn_setgpo_out_onoff)
        Me.GroupBox12.Controls.Add(Me.btn_getgpio_out_onoff)
        Me.GroupBox12.Controls.Add(Me.btn_setgpio_out_onoff)
        Me.GroupBox12.Controls.Add(Me.btn_gpio_Inputget)
        Me.GroupBox12.Controls.Add(Me.btn_gpio_Inputset)
        Me.GroupBox12.Location = New System.Drawing.Point(9, 692)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(456, 94)
        Me.GroupBox12.TabIndex = 66
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "GPIO Control"
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(192, 51)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(94, 35)
        Me.Button14.TabIndex = 28
        Me.Button14.Text = "Get GPIO  In Read"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'btn_getgpo_out_onoff
        '
        Me.btn_getgpo_out_onoff.Location = New System.Drawing.Point(96, 51)
        Me.btn_getgpo_out_onoff.Name = "btn_getgpo_out_onoff"
        Me.btn_getgpo_out_onoff.Size = New System.Drawing.Size(94, 35)
        Me.btn_getgpo_out_onoff.TabIndex = 27
        Me.btn_getgpo_out_onoff.Text = "Get GPO   OnOFF"
        Me.btn_getgpo_out_onoff.UseVisualStyleBackColor = True
        '
        'btn_setgpo_out_onoff
        '
        Me.btn_setgpo_out_onoff.Location = New System.Drawing.Point(2, 51)
        Me.btn_setgpo_out_onoff.Name = "btn_setgpo_out_onoff"
        Me.btn_setgpo_out_onoff.Size = New System.Drawing.Size(94, 35)
        Me.btn_setgpo_out_onoff.TabIndex = 26
        Me.btn_setgpo_out_onoff.Text = "Set GPO   OnOFF"
        Me.btn_setgpo_out_onoff.UseVisualStyleBackColor = True
        '
        'btn_getgpio_out_onoff
        '
        Me.btn_getgpio_out_onoff.Location = New System.Drawing.Point(283, 15)
        Me.btn_getgpio_out_onoff.Name = "btn_getgpio_out_onoff"
        Me.btn_getgpio_out_onoff.Size = New System.Drawing.Size(94, 35)
        Me.btn_getgpio_out_onoff.TabIndex = 25
        Me.btn_getgpio_out_onoff.Text = "Get GPIO   OnOFF"
        Me.btn_getgpio_out_onoff.UseVisualStyleBackColor = True
        '
        'btn_setgpio_out_onoff
        '
        Me.btn_setgpio_out_onoff.Location = New System.Drawing.Point(190, 15)
        Me.btn_setgpio_out_onoff.Name = "btn_setgpio_out_onoff"
        Me.btn_setgpio_out_onoff.Size = New System.Drawing.Size(94, 35)
        Me.btn_setgpio_out_onoff.TabIndex = 24
        Me.btn_setgpio_out_onoff.Text = "Set GPIO   OnOFF"
        Me.btn_setgpio_out_onoff.UseVisualStyleBackColor = True
        '
        'btn_gpio_Inputget
        '
        Me.btn_gpio_Inputget.Location = New System.Drawing.Point(96, 15)
        Me.btn_gpio_Inputget.Name = "btn_gpio_Inputget"
        Me.btn_gpio_Inputget.Size = New System.Drawing.Size(94, 35)
        Me.btn_gpio_Inputget.TabIndex = 23
        Me.btn_gpio_Inputget.Text = "Get GPIO           Input"
        Me.btn_gpio_Inputget.UseVisualStyleBackColor = True
        '
        'btn_gpio_Inputset
        '
        Me.btn_gpio_Inputset.Location = New System.Drawing.Point(2, 15)
        Me.btn_gpio_Inputset.Name = "btn_gpio_Inputset"
        Me.btn_gpio_Inputset.Size = New System.Drawing.Size(94, 35)
        Me.btn_gpio_Inputset.TabIndex = 22
        Me.btn_gpio_Inputset.Text = "Set GPIO           Input"
        Me.btn_gpio_Inputset.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.btn_getaverallch)
        Me.GroupBox11.Controls.Add(Me.btn_Setaverallch)
        Me.GroupBox11.Controls.Add(Me.btn_getlimitTempallch)
        Me.GroupBox11.Controls.Add(Me.btn_setlimitTempallch)
        Me.GroupBox11.Controls.Add(Me.btn_GetlimitTemp1ch)
        Me.GroupBox11.Controls.Add(Me.btn_setlimitTemp1ch)
        Me.GroupBox11.Controls.Add(Me.btn_getlimitallch)
        Me.GroupBox11.Controls.Add(Me.btn_setlimitallch)
        Me.GroupBox11.Controls.Add(Me.btn_getlimit1ch)
        Me.GroupBox11.Controls.Add(Me.btn_setlimit1ch)
        Me.GroupBox11.Controls.Add(Me.btn_getaver1ch)
        Me.GroupBox11.Controls.Add(Me.btn_Setaver1ch)
        Me.GroupBox11.Controls.Add(Me.btn_readadcallch)
        Me.GroupBox11.Controls.Add(Me.btn_readadc1ch)
        Me.GroupBox11.Location = New System.Drawing.Point(5, 528)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(460, 160)
        Me.GroupBox11.TabIndex = 65
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "ADC Control"
        '
        'btn_getaverallch
        '
        Me.btn_getaverallch.Location = New System.Drawing.Point(283, 50)
        Me.btn_getaverallch.Name = "btn_getaverallch"
        Me.btn_getaverallch.Size = New System.Drawing.Size(94, 35)
        Me.btn_getaverallch.TabIndex = 35
        Me.btn_getaverallch.Text = "Get Average     All Channel"
        Me.btn_getaverallch.UseVisualStyleBackColor = True
        '
        'btn_Setaverallch
        '
        Me.btn_Setaverallch.Location = New System.Drawing.Point(190, 50)
        Me.btn_Setaverallch.Name = "btn_Setaverallch"
        Me.btn_Setaverallch.Size = New System.Drawing.Size(94, 35)
        Me.btn_Setaverallch.TabIndex = 34
        Me.btn_Setaverallch.Text = "Set Average     All Channel"
        Me.btn_Setaverallch.UseVisualStyleBackColor = True
        '
        'btn_getlimitTempallch
        '
        Me.btn_getlimitTempallch.Location = New System.Drawing.Point(283, 120)
        Me.btn_getlimitTempallch.Name = "btn_getlimitTempallch"
        Me.btn_getlimitTempallch.Size = New System.Drawing.Size(94, 35)
        Me.btn_getlimitTempallch.TabIndex = 33
        Me.btn_getlimitTempallch.Text = "Get Limit(T)     All Channel"
        Me.btn_getlimitTempallch.UseVisualStyleBackColor = True
        '
        'btn_setlimitTempallch
        '
        Me.btn_setlimitTempallch.Location = New System.Drawing.Point(190, 120)
        Me.btn_setlimitTempallch.Name = "btn_setlimitTempallch"
        Me.btn_setlimitTempallch.Size = New System.Drawing.Size(94, 35)
        Me.btn_setlimitTempallch.TabIndex = 32
        Me.btn_setlimitTempallch.Text = "Set Limit(T)     All Channel"
        Me.btn_setlimitTempallch.UseVisualStyleBackColor = True
        '
        'btn_GetlimitTemp1ch
        '
        Me.btn_GetlimitTemp1ch.Location = New System.Drawing.Point(94, 120)
        Me.btn_GetlimitTemp1ch.Name = "btn_GetlimitTemp1ch"
        Me.btn_GetlimitTemp1ch.Size = New System.Drawing.Size(94, 35)
        Me.btn_GetlimitTemp1ch.TabIndex = 31
        Me.btn_GetlimitTemp1ch.Text = "Get Limit(T)       1 Channel"
        Me.btn_GetlimitTemp1ch.UseVisualStyleBackColor = True
        '
        'btn_setlimitTemp1ch
        '
        Me.btn_setlimitTemp1ch.Location = New System.Drawing.Point(1, 120)
        Me.btn_setlimitTemp1ch.Name = "btn_setlimitTemp1ch"
        Me.btn_setlimitTemp1ch.Size = New System.Drawing.Size(94, 35)
        Me.btn_setlimitTemp1ch.TabIndex = 30
        Me.btn_setlimitTemp1ch.Text = "Set Limit(T)       1 Channel"
        Me.btn_setlimitTemp1ch.UseVisualStyleBackColor = True
        '
        'btn_getlimitallch
        '
        Me.btn_getlimitallch.Location = New System.Drawing.Point(283, 85)
        Me.btn_getlimitallch.Name = "btn_getlimitallch"
        Me.btn_getlimitallch.Size = New System.Drawing.Size(94, 35)
        Me.btn_getlimitallch.TabIndex = 29
        Me.btn_getlimitallch.Text = "Get Limit(A)     All Channel"
        Me.btn_getlimitallch.UseVisualStyleBackColor = True
        '
        'btn_setlimitallch
        '
        Me.btn_setlimitallch.Location = New System.Drawing.Point(190, 85)
        Me.btn_setlimitallch.Name = "btn_setlimitallch"
        Me.btn_setlimitallch.Size = New System.Drawing.Size(94, 35)
        Me.btn_setlimitallch.TabIndex = 28
        Me.btn_setlimitallch.Text = "Set Limit(A)     All Channel"
        Me.btn_setlimitallch.UseVisualStyleBackColor = True
        '
        'btn_getlimit1ch
        '
        Me.btn_getlimit1ch.Location = New System.Drawing.Point(96, 85)
        Me.btn_getlimit1ch.Name = "btn_getlimit1ch"
        Me.btn_getlimit1ch.Size = New System.Drawing.Size(94, 35)
        Me.btn_getlimit1ch.TabIndex = 27
        Me.btn_getlimit1ch.Text = "Get Limit(A)       1 Channel"
        Me.btn_getlimit1ch.UseVisualStyleBackColor = True
        '
        'btn_setlimit1ch
        '
        Me.btn_setlimit1ch.Location = New System.Drawing.Point(2, 85)
        Me.btn_setlimit1ch.Name = "btn_setlimit1ch"
        Me.btn_setlimit1ch.Size = New System.Drawing.Size(94, 35)
        Me.btn_setlimit1ch.TabIndex = 26
        Me.btn_setlimit1ch.Text = "Set Limit(A)       1 Channel"
        Me.btn_setlimit1ch.UseVisualStyleBackColor = True
        '
        'btn_getaver1ch
        '
        Me.btn_getaver1ch.Location = New System.Drawing.Point(96, 50)
        Me.btn_getaver1ch.Name = "btn_getaver1ch"
        Me.btn_getaver1ch.Size = New System.Drawing.Size(94, 35)
        Me.btn_getaver1ch.TabIndex = 25
        Me.btn_getaver1ch.Text = "Get Average     1 Channel"
        Me.btn_getaver1ch.UseVisualStyleBackColor = True
        '
        'btn_Setaver1ch
        '
        Me.btn_Setaver1ch.Location = New System.Drawing.Point(2, 50)
        Me.btn_Setaver1ch.Name = "btn_Setaver1ch"
        Me.btn_Setaver1ch.Size = New System.Drawing.Size(94, 35)
        Me.btn_Setaver1ch.TabIndex = 24
        Me.btn_Setaver1ch.Text = "Set Average     1 Channel"
        Me.btn_Setaver1ch.UseVisualStyleBackColor = True
        '
        'btn_readadcallch
        '
        Me.btn_readadcallch.Location = New System.Drawing.Point(96, 15)
        Me.btn_readadcallch.Name = "btn_readadcallch"
        Me.btn_readadcallch.Size = New System.Drawing.Size(94, 35)
        Me.btn_readadcallch.TabIndex = 23
        Me.btn_readadcallch.Text = "Read ADC      All Channel"
        Me.btn_readadcallch.UseVisualStyleBackColor = True
        '
        'btn_readadc1ch
        '
        Me.btn_readadc1ch.Location = New System.Drawing.Point(2, 15)
        Me.btn_readadc1ch.Name = "btn_readadc1ch"
        Me.btn_readadc1ch.Size = New System.Drawing.Size(94, 35)
        Me.btn_readadc1ch.TabIndex = 22
        Me.btn_readadc1ch.Text = "Read ADC      1 Channel"
        Me.btn_readadc1ch.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Button17)
        Me.GroupBox10.Controls.Add(Me.bnt_getallchpulse)
        Me.GroupBox10.Controls.Add(Me.bnt_setallchpulse)
        Me.GroupBox10.Controls.Add(Me.bnt_get1chpulse)
        Me.GroupBox10.Controls.Add(Me.bnt_set1chpulse)
        Me.GroupBox10.Controls.Add(Me.bnt_getallchfOutput)
        Me.GroupBox10.Controls.Add(Me.bnt_setallchfOutput)
        Me.GroupBox10.Controls.Add(Me.bnt_Get1chfOutput)
        Me.GroupBox10.Controls.Add(Me.bnt_set1chfOutput)
        Me.GroupBox10.Controls.Add(Me.bnt_getallchOnoff)
        Me.GroupBox10.Controls.Add(Me.bnt_setallchOnoff)
        Me.GroupBox10.Controls.Add(Me.bnt_get1chOnoff)
        Me.GroupBox10.Controls.Add(Me.bnt_set1chOnoff)
        Me.GroupBox10.Controls.Add(Me.btn_getmodeallch)
        Me.GroupBox10.Controls.Add(Me.btn_setmodeallch)
        Me.GroupBox10.Controls.Add(Me.btn_Getmode1ch)
        Me.GroupBox10.Controls.Add(Me.btn_setmode1ch)
        Me.GroupBox10.Controls.Add(Me.btn_getallch)
        Me.GroupBox10.Controls.Add(Me.btn_setallch)
        Me.GroupBox10.Controls.Add(Me.btn_get1ch)
        Me.GroupBox10.Controls.Add(Me.btn_set1ch)
        Me.GroupBox10.Location = New System.Drawing.Point(6, 322)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(458, 202)
        Me.GroupBox10.TabIndex = 64
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "DAC Control"
        '
        'Button17
        '
        Me.Button17.Location = New System.Drawing.Point(378, 88)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(75, 35)
        Me.Button17.TabIndex = 64
        Me.Button17.Text = "Set Sync On"
        Me.Button17.UseVisualStyleBackColor = True
        '
        'bnt_getallchpulse
        '
        Me.bnt_getallchpulse.Location = New System.Drawing.Point(283, 161)
        Me.bnt_getallchpulse.Name = "bnt_getallchpulse"
        Me.bnt_getallchpulse.Size = New System.Drawing.Size(94, 35)
        Me.bnt_getallchpulse.TabIndex = 63
        Me.bnt_getallchpulse.Text = "Get Pulse     All Channel"
        Me.bnt_getallchpulse.UseVisualStyleBackColor = True
        '
        'bnt_setallchpulse
        '
        Me.bnt_setallchpulse.Location = New System.Drawing.Point(190, 161)
        Me.bnt_setallchpulse.Name = "bnt_setallchpulse"
        Me.bnt_setallchpulse.Size = New System.Drawing.Size(94, 35)
        Me.bnt_setallchpulse.TabIndex = 62
        Me.bnt_setallchpulse.Text = "Set Pulse     All Channel"
        Me.bnt_setallchpulse.UseVisualStyleBackColor = True
        '
        'bnt_get1chpulse
        '
        Me.bnt_get1chpulse.Location = New System.Drawing.Point(96, 161)
        Me.bnt_get1chpulse.Name = "bnt_get1chpulse"
        Me.bnt_get1chpulse.Size = New System.Drawing.Size(94, 35)
        Me.bnt_get1chpulse.TabIndex = 61
        Me.bnt_get1chpulse.Text = "Get Pulse       1 Channel"
        Me.bnt_get1chpulse.UseVisualStyleBackColor = True
        '
        'bnt_set1chpulse
        '
        Me.bnt_set1chpulse.Location = New System.Drawing.Point(2, 161)
        Me.bnt_set1chpulse.Name = "bnt_set1chpulse"
        Me.bnt_set1chpulse.Size = New System.Drawing.Size(94, 35)
        Me.bnt_set1chpulse.TabIndex = 60
        Me.bnt_set1chpulse.Text = "Set Pulse       1 Channel"
        Me.bnt_set1chpulse.UseVisualStyleBackColor = True
        '
        'bnt_getallchfOutput
        '
        Me.bnt_getallchfOutput.Location = New System.Drawing.Point(283, 125)
        Me.bnt_getallchfOutput.Name = "bnt_getallchfOutput"
        Me.bnt_getallchfOutput.Size = New System.Drawing.Size(94, 35)
        Me.bnt_getallchfOutput.TabIndex = 56
        Me.bnt_getallchfOutput.Text = "Get Foutput     All Channel"
        Me.bnt_getallchfOutput.UseVisualStyleBackColor = True
        '
        'bnt_setallchfOutput
        '
        Me.bnt_setallchfOutput.Location = New System.Drawing.Point(190, 125)
        Me.bnt_setallchfOutput.Name = "bnt_setallchfOutput"
        Me.bnt_setallchfOutput.Size = New System.Drawing.Size(94, 35)
        Me.bnt_setallchfOutput.TabIndex = 55
        Me.bnt_setallchfOutput.Text = "Set Foutput     All Channel"
        Me.bnt_setallchfOutput.UseVisualStyleBackColor = True
        '
        'bnt_Get1chfOutput
        '
        Me.bnt_Get1chfOutput.Location = New System.Drawing.Point(96, 125)
        Me.bnt_Get1chfOutput.Name = "bnt_Get1chfOutput"
        Me.bnt_Get1chfOutput.Size = New System.Drawing.Size(94, 35)
        Me.bnt_Get1chfOutput.TabIndex = 54
        Me.bnt_Get1chfOutput.Text = "Get Foutput       1 Channel"
        Me.bnt_Get1chfOutput.UseVisualStyleBackColor = True
        '
        'bnt_set1chfOutput
        '
        Me.bnt_set1chfOutput.Location = New System.Drawing.Point(2, 125)
        Me.bnt_set1chfOutput.Name = "bnt_set1chfOutput"
        Me.bnt_set1chfOutput.Size = New System.Drawing.Size(94, 35)
        Me.bnt_set1chfOutput.TabIndex = 53
        Me.bnt_set1chfOutput.Text = "Set Foutput       1 Channel"
        Me.bnt_set1chfOutput.UseVisualStyleBackColor = True
        '
        'bnt_getallchOnoff
        '
        Me.bnt_getallchOnoff.Location = New System.Drawing.Point(283, 88)
        Me.bnt_getallchOnoff.Name = "bnt_getallchOnoff"
        Me.bnt_getallchOnoff.Size = New System.Drawing.Size(94, 35)
        Me.bnt_getallchOnoff.TabIndex = 52
        Me.bnt_getallchOnoff.Text = "Get OnOff       All Channel"
        Me.bnt_getallchOnoff.UseVisualStyleBackColor = True
        '
        'bnt_setallchOnoff
        '
        Me.bnt_setallchOnoff.Location = New System.Drawing.Point(190, 88)
        Me.bnt_setallchOnoff.Name = "bnt_setallchOnoff"
        Me.bnt_setallchOnoff.Size = New System.Drawing.Size(94, 35)
        Me.bnt_setallchOnoff.TabIndex = 51
        Me.bnt_setallchOnoff.Text = "Set OnOff       All Channel"
        Me.bnt_setallchOnoff.UseVisualStyleBackColor = True
        '
        'bnt_get1chOnoff
        '
        Me.bnt_get1chOnoff.Location = New System.Drawing.Point(96, 88)
        Me.bnt_get1chOnoff.Name = "bnt_get1chOnoff"
        Me.bnt_get1chOnoff.Size = New System.Drawing.Size(94, 35)
        Me.bnt_get1chOnoff.TabIndex = 31
        Me.bnt_get1chOnoff.Text = "Get OnOff       1 Channel"
        Me.bnt_get1chOnoff.UseVisualStyleBackColor = True
        '
        'bnt_set1chOnoff
        '
        Me.bnt_set1chOnoff.Location = New System.Drawing.Point(2, 88)
        Me.bnt_set1chOnoff.Name = "bnt_set1chOnoff"
        Me.bnt_set1chOnoff.Size = New System.Drawing.Size(94, 35)
        Me.bnt_set1chOnoff.TabIndex = 30
        Me.bnt_set1chOnoff.Text = "Set OnOff       1 Channel"
        Me.bnt_set1chOnoff.UseVisualStyleBackColor = True
        '
        'btn_getmodeallch
        '
        Me.btn_getmodeallch.Location = New System.Drawing.Point(283, 51)
        Me.btn_getmodeallch.Name = "btn_getmodeallch"
        Me.btn_getmodeallch.Size = New System.Drawing.Size(94, 35)
        Me.btn_getmodeallch.TabIndex = 29
        Me.btn_getmodeallch.Text = "Get Mode       All Channel"
        Me.btn_getmodeallch.UseVisualStyleBackColor = True
        '
        'btn_setmodeallch
        '
        Me.btn_setmodeallch.Location = New System.Drawing.Point(190, 51)
        Me.btn_setmodeallch.Name = "btn_setmodeallch"
        Me.btn_setmodeallch.Size = New System.Drawing.Size(94, 35)
        Me.btn_setmodeallch.TabIndex = 28
        Me.btn_setmodeallch.Text = "Set Mode       All Channel"
        Me.btn_setmodeallch.UseVisualStyleBackColor = True
        '
        'btn_Getmode1ch
        '
        Me.btn_Getmode1ch.Location = New System.Drawing.Point(96, 51)
        Me.btn_Getmode1ch.Name = "btn_Getmode1ch"
        Me.btn_Getmode1ch.Size = New System.Drawing.Size(94, 35)
        Me.btn_Getmode1ch.TabIndex = 27
        Me.btn_Getmode1ch.Text = "Get Mode       1 Channel"
        Me.btn_Getmode1ch.UseVisualStyleBackColor = True
        '
        'btn_setmode1ch
        '
        Me.btn_setmode1ch.Location = New System.Drawing.Point(2, 51)
        Me.btn_setmode1ch.Name = "btn_setmode1ch"
        Me.btn_setmode1ch.Size = New System.Drawing.Size(94, 35)
        Me.btn_setmode1ch.TabIndex = 26
        Me.btn_setmode1ch.Text = "Set Mode       1 Channel"
        Me.btn_setmode1ch.UseVisualStyleBackColor = True
        '
        'btn_getallch
        '
        Me.btn_getallch.Location = New System.Drawing.Point(283, 15)
        Me.btn_getallch.Name = "btn_getallch"
        Me.btn_getallch.Size = New System.Drawing.Size(94, 35)
        Me.btn_getallch.TabIndex = 25
        Me.btn_getallch.Text = "Get Output     All Channel"
        Me.btn_getallch.UseVisualStyleBackColor = True
        '
        'btn_setallch
        '
        Me.btn_setallch.Location = New System.Drawing.Point(190, 15)
        Me.btn_setallch.Name = "btn_setallch"
        Me.btn_setallch.Size = New System.Drawing.Size(94, 35)
        Me.btn_setallch.TabIndex = 24
        Me.btn_setallch.Text = "Set Output     All Channel"
        Me.btn_setallch.UseVisualStyleBackColor = True
        '
        'btn_get1ch
        '
        Me.btn_get1ch.Location = New System.Drawing.Point(96, 15)
        Me.btn_get1ch.Name = "btn_get1ch"
        Me.btn_get1ch.Size = New System.Drawing.Size(94, 35)
        Me.btn_get1ch.TabIndex = 23
        Me.btn_get1ch.Text = "Get Output     1 Channel"
        Me.btn_get1ch.UseVisualStyleBackColor = True
        '
        'btn_set1ch
        '
        Me.btn_set1ch.Location = New System.Drawing.Point(2, 15)
        Me.btn_set1ch.Name = "btn_set1ch"
        Me.btn_set1ch.Size = New System.Drawing.Size(94, 35)
        Me.btn_set1ch.TabIndex = 22
        Me.btn_set1ch.Text = "Set Output     1 Channel"
        Me.btn_set1ch.UseVisualStyleBackColor = True
        '
        'btn_GetAalarm
        '
        Me.btn_GetAalarm.Location = New System.Drawing.Point(264, 181)
        Me.btn_GetAalarm.Name = "btn_GetAalarm"
        Me.btn_GetAalarm.Size = New System.Drawing.Size(80, 35)
        Me.btn_GetAalarm.TabIndex = 59
        Me.btn_GetAalarm.Text = "Get Reg Limit Alarm"
        Me.btn_GetAalarm.UseVisualStyleBackColor = True
        '
        'btn_setalarm
        '
        Me.btn_setalarm.Location = New System.Drawing.Point(178, 181)
        Me.btn_setalarm.Name = "btn_setalarm"
        Me.btn_setalarm.Size = New System.Drawing.Size(80, 35)
        Me.btn_setalarm.TabIndex = 58
        Me.btn_setalarm.Text = "Set Reg Limit Alarm"
        Me.btn_setalarm.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.UcSingleList1)
        Me.GroupBox9.Controls.Add(Me.Button4)
        Me.GroupBox9.Location = New System.Drawing.Point(6, 74)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(381, 106)
        Me.GroupBox9.TabIndex = 57
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Board Info"
        '
        'UcSingleList1
        '
        Me.UcSingleList1.AutoScroll = True
        Me.UcSingleList1.ColHeader = New String() {"No", "Name", "Description"}
        Me.UcSingleList1.ColHeaderWidthRatio = "10,30,30"
        Me.UcSingleList1.Location = New System.Drawing.Point(96, 20)
        Me.UcSingleList1.Name = "UcSingleList1"
        Me.UcSingleList1.Size = New System.Drawing.Size(271, 81)
        Me.UcSingleList1.TabIndex = 4
        '
        'btn_chaddrset
        '
        Me.btn_chaddrset.Location = New System.Drawing.Point(378, 14)
        Me.btn_chaddrset.Name = "btn_chaddrset"
        Me.btn_chaddrset.Size = New System.Drawing.Size(80, 21)
        Me.btn_chaddrset.TabIndex = 50
        Me.btn_chaddrset.Text = "Set"
        Me.btn_chaddrset.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(248, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 11)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Channel"
        '
        'txt_ch
        '
        Me.txt_ch.Location = New System.Drawing.Point(315, 14)
        Me.txt_ch.Name = "txt_ch"
        Me.txt_ch.Size = New System.Drawing.Size(48, 21)
        Me.txt_ch.TabIndex = 48
        Me.txt_ch.Text = "00"
        Me.txt_ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(136, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 11)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Addrs"
        '
        'txt_addrs
        '
        Me.txt_addrs.Location = New System.Drawing.Point(185, 13)
        Me.txt_addrs.Name = "txt_addrs"
        Me.txt_addrs.Size = New System.Drawing.Size(48, 21)
        Me.txt_addrs.TabIndex = 46
        Me.txt_addrs.Text = "00"
        Me.txt_addrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.cbBaudRate)
        Me.GroupBox6.Controls.Add(Me.txt_err)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.tbError)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.cboPort)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(465, 87)
        Me.GroupBox6.TabIndex = 23
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "GroupBox6"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoScroll = True
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.19697!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.80303!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1370, 746)
        Me.TableLayoutPanel1.TabIndex = 24
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(444, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(923, 740)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.86259!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.13741!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(923, 740)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.Ucgpio1)
        Me.Panel4.Controls.Add(Me.UcADcFrame1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 209)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(917, 528)
        Me.Panel4.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Button23)
        Me.Panel5.Controls.Add(Me.Button22)
        Me.Panel5.Controls.Add(Me.Button21)
        Me.Panel5.Controls.Add(Me.Button20)
        Me.Panel5.Controls.Add(Me.Button19)
        Me.Panel5.Controls.Add(Me.Button18)
        Me.Panel5.Controls.Add(Me.GroupBox21)
        Me.Panel5.Controls.Add(Me.GroupBox20)
        Me.Panel5.Controls.Add(Me.GroupBox19)
        Me.Panel5.Controls.Add(Me.GroupBox17)
        Me.Panel5.Controls.Add(Me.GroupBox18)
        Me.Panel5.Controls.Add(Me.txt_SubLow)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Controls.Add(Me.txt_SubHigh)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.lbl_dacnum1)
        Me.Panel5.Controls.Add(Me.rdo_sublow)
        Me.Panel5.Controls.Add(Me.lbl_dacnum2)
        Me.Panel5.Controls.Add(Me.rdo_subhigh)
        Me.Panel5.Location = New System.Drawing.Point(36, 184)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1018, 501)
        Me.Panel5.TabIndex = 3
        Me.Panel5.Visible = False
        '
        'Button23
        '
        Me.Button23.Location = New System.Drawing.Point(867, 165)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(114, 50)
        Me.Button23.TabIndex = 79
        Me.Button23.Text = "Curr Limit Set all"
        Me.Button23.UseVisualStyleBackColor = True
        '
        'Button22
        '
        Me.Button22.Location = New System.Drawing.Point(747, 165)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(114, 50)
        Me.Button22.TabIndex = 78
        Me.Button22.Text = "Curr Limit Set 1ch"
        Me.Button22.UseVisualStyleBackColor = True
        '
        'Button21
        '
        Me.Button21.Location = New System.Drawing.Point(867, 109)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(114, 50)
        Me.Button21.TabIndex = 77
        Me.Button21.Text = "Temp Limit Set all"
        Me.Button21.UseVisualStyleBackColor = True
        '
        'Button20
        '
        Me.Button20.Location = New System.Drawing.Point(747, 109)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(114, 50)
        Me.Button20.TabIndex = 76
        Me.Button20.Text = "Temp Limit Set 1ch"
        Me.Button20.UseVisualStyleBackColor = True
        '
        'Button19
        '
        Me.Button19.Location = New System.Drawing.Point(867, 52)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(114, 50)
        Me.Button19.TabIndex = 75
        Me.Button19.Text = "Averge Set all"
        Me.Button19.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.Location = New System.Drawing.Point(747, 52)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(114, 50)
        Me.Button18.TabIndex = 74
        Me.Button18.Text = "Averge Set 1ch"
        Me.Button18.UseVisualStyleBackColor = True
        '
        'GroupBox21
        '
        Me.GroupBox21.Controls.Add(Me.Button15)
        Me.GroupBox21.Controls.Add(Me.CheckBox3)
        Me.GroupBox21.Controls.Add(Me.chk_mainall)
        Me.GroupBox21.Controls.Add(Me.cbo_Mainch)
        Me.GroupBox21.Controls.Add(Me.Button16)
        Me.GroupBox21.Location = New System.Drawing.Point(31, 325)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Size = New System.Drawing.Size(310, 95)
        Me.GroupBox21.TabIndex = 73
        Me.GroupBox21.TabStop = False
        Me.GroupBox21.Text = "Main Power"
        '
        'Button15
        '
        Me.Button15.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button15.Location = New System.Drawing.Point(206, 30)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(75, 47)
        Me.Button15.TabIndex = 70
        Me.Button15.Text = "OFF"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(61, 29)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(53, 16)
        Me.CheckBox3.TabIndex = 69
        Me.CheckBox3.Text = "Sync"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'chk_mainall
        '
        Me.chk_mainall.AutoSize = True
        Me.chk_mainall.Location = New System.Drawing.Point(17, 30)
        Me.chk_mainall.Name = "chk_mainall"
        Me.chk_mainall.Size = New System.Drawing.Size(38, 16)
        Me.chk_mainall.TabIndex = 66
        Me.chk_mainall.Text = "All"
        Me.chk_mainall.UseVisualStyleBackColor = True
        '
        'cbo_Mainch
        '
        Me.cbo_Mainch.FormattingEnabled = True
        Me.cbo_Mainch.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16"})
        Me.cbo_Mainch.Location = New System.Drawing.Point(16, 51)
        Me.cbo_Mainch.Name = "cbo_Mainch"
        Me.cbo_Mainch.Size = New System.Drawing.Size(89, 20)
        Me.cbo_Mainch.TabIndex = 65
        '
        'Button16
        '
        Me.Button16.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button16.Location = New System.Drawing.Point(128, 29)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(75, 47)
        Me.Button16.TabIndex = 57
        Me.Button16.Text = "SET"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'GroupBox20
        '
        Me.GroupBox20.Controls.Add(Me.Button12)
        Me.GroupBox20.Controls.Add(Me.CheckBox2)
        Me.GroupBox20.Controls.Add(Me.chk_sigall)
        Me.GroupBox20.Controls.Add(Me.cbo_sigch)
        Me.GroupBox20.Controls.Add(Me.Button13)
        Me.GroupBox20.Location = New System.Drawing.Point(348, 219)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(310, 95)
        Me.GroupBox20.TabIndex = 72
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "SIG Power"
        '
        'Button12
        '
        Me.Button12.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button12.Location = New System.Drawing.Point(206, 30)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 47)
        Me.Button12.TabIndex = 70
        Me.Button12.Text = "OFF"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(61, 29)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(53, 16)
        Me.CheckBox2.TabIndex = 69
        Me.CheckBox2.Text = "Sync"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'chk_sigall
        '
        Me.chk_sigall.AutoSize = True
        Me.chk_sigall.Location = New System.Drawing.Point(17, 30)
        Me.chk_sigall.Name = "chk_sigall"
        Me.chk_sigall.Size = New System.Drawing.Size(38, 16)
        Me.chk_sigall.TabIndex = 66
        Me.chk_sigall.Text = "All"
        Me.chk_sigall.UseVisualStyleBackColor = True
        '
        'cbo_sigch
        '
        Me.cbo_sigch.FormattingEnabled = True
        Me.cbo_sigch.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26"})
        Me.cbo_sigch.Location = New System.Drawing.Point(16, 51)
        Me.cbo_sigch.Name = "cbo_sigch"
        Me.cbo_sigch.Size = New System.Drawing.Size(89, 20)
        Me.cbo_sigch.TabIndex = 65
        '
        'Button13
        '
        Me.Button13.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button13.Location = New System.Drawing.Point(128, 29)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(75, 47)
        Me.Button13.TabIndex = 57
        Me.Button13.Text = "SET"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'GroupBox19
        '
        Me.GroupBox19.Controls.Add(Me.lblUnitPulseDelay)
        Me.GroupBox19.Controls.Add(Me.Label13)
        Me.GroupBox19.Controls.Add(Me.lblUnitPulsePeriod)
        Me.GroupBox19.Controls.Add(Me.txtwidth)
        Me.GroupBox19.Controls.Add(Me.Label14)
        Me.GroupBox19.Controls.Add(Me.txtdelay)
        Me.GroupBox19.Controls.Add(Me.Label15)
        Me.GroupBox19.Controls.Add(Me.txtperiod)
        Me.GroupBox19.Controls.Add(Me.Label16)
        Me.GroupBox19.Location = New System.Drawing.Point(258, 116)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(385, 43)
        Me.GroupBox19.TabIndex = 71
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "Pulse Set"
        '
        'lblUnitPulseDelay
        '
        Me.lblUnitPulseDelay.AutoSize = True
        Me.lblUnitPulseDelay.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblUnitPulseDelay.Location = New System.Drawing.Point(101, 24)
        Me.lblUnitPulseDelay.Name = "lblUnitPulseDelay"
        Me.lblUnitPulseDelay.Size = New System.Drawing.Size(21, 11)
        Me.lblUnitPulseDelay.TabIndex = 57
        Me.lblUnitPulseDelay.Text = "us"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.Location = New System.Drawing.Point(213, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(21, 11)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "us"
        '
        'lblUnitPulsePeriod
        '
        Me.lblUnitPulsePeriod.AutoSize = True
        Me.lblUnitPulsePeriod.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblUnitPulsePeriod.Location = New System.Drawing.Point(359, 25)
        Me.lblUnitPulsePeriod.Name = "lblUnitPulsePeriod"
        Me.lblUnitPulsePeriod.Size = New System.Drawing.Size(21, 11)
        Me.lblUnitPulsePeriod.TabIndex = 49
        Me.lblUnitPulsePeriod.Text = "us"
        '
        'txtwidth
        '
        Me.txtwidth.Location = New System.Drawing.Point(163, 17)
        Me.txtwidth.Name = "txtwidth"
        Me.txtwidth.Size = New System.Drawing.Size(49, 21)
        Me.txtwidth.TabIndex = 36
        Me.txtwidth.Text = "2000"
        Me.txtwidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(127, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 23)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Width"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtdelay
        '
        Me.txtdelay.Location = New System.Drawing.Point(52, 15)
        Me.txtdelay.Name = "txtdelay"
        Me.txtdelay.Size = New System.Drawing.Size(49, 21)
        Me.txtdelay.TabIndex = 38
        Me.txtdelay.Text = "0"
        Me.txtdelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 23)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Delay"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtperiod
        '
        Me.txtperiod.Location = New System.Drawing.Point(281, 17)
        Me.txtperiod.Name = "txtperiod"
        Me.txtperiod.Size = New System.Drawing.Size(76, 21)
        Me.txtperiod.TabIndex = 34
        Me.txtperiod.Text = "4000"
        Me.txtperiod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(234, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 23)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Period"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.Button11)
        Me.GroupBox17.Controls.Add(Me.CheckBox1)
        Me.GroupBox17.Controls.Add(Me.chk_suball)
        Me.GroupBox17.Controls.Add(Me.cbo_subch)
        Me.GroupBox17.Controls.Add(Me.btnSetDAC_Low)
        Me.GroupBox17.Location = New System.Drawing.Point(31, 219)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(310, 95)
        Me.GroupBox17.TabIndex = 1
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "Sub Power"
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button11.Location = New System.Drawing.Point(206, 30)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(75, 47)
        Me.Button11.TabIndex = 70
        Me.Button11.Text = "OFF"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(61, 29)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(53, 16)
        Me.CheckBox1.TabIndex = 69
        Me.CheckBox1.Text = "Sync"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chk_suball
        '
        Me.chk_suball.AutoSize = True
        Me.chk_suball.Location = New System.Drawing.Point(17, 30)
        Me.chk_suball.Name = "chk_suball"
        Me.chk_suball.Size = New System.Drawing.Size(38, 16)
        Me.chk_suball.TabIndex = 66
        Me.chk_suball.Text = "All"
        Me.chk_suball.UseVisualStyleBackColor = True
        '
        'cbo_subch
        '
        Me.cbo_subch.FormattingEnabled = True
        Me.cbo_subch.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cbo_subch.Location = New System.Drawing.Point(16, 51)
        Me.cbo_subch.Name = "cbo_subch"
        Me.cbo_subch.Size = New System.Drawing.Size(89, 20)
        Me.cbo_subch.TabIndex = 65
        '
        'btnSetDAC_Low
        '
        Me.btnSetDAC_Low.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnSetDAC_Low.Location = New System.Drawing.Point(128, 29)
        Me.btnSetDAC_Low.Name = "btnSetDAC_Low"
        Me.btnSetDAC_Low.Size = New System.Drawing.Size(75, 47)
        Me.btnSetDAC_Low.TabIndex = 57
        Me.btnSetDAC_Low.Text = "SET"
        Me.btnSetDAC_Low.UseVisualStyleBackColor = True
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.rdo_subpusle)
        Me.GroupBox18.Controls.Add(Me.rdo_subdc)
        Me.GroupBox18.Location = New System.Drawing.Point(146, 40)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(106, 119)
        Me.GroupBox18.TabIndex = 70
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "Mode"
        '
        'rdo_subpusle
        '
        Me.rdo_subpusle.AutoSize = True
        Me.rdo_subpusle.Location = New System.Drawing.Point(10, 78)
        Me.rdo_subpusle.Name = "rdo_subpusle"
        Me.rdo_subpusle.Size = New System.Drawing.Size(91, 16)
        Me.rdo_subpusle.TabIndex = 46
        Me.rdo_subpusle.Text = "Pulse Mode"
        Me.rdo_subpusle.UseVisualStyleBackColor = True
        '
        'rdo_subdc
        '
        Me.rdo_subdc.AutoSize = True
        Me.rdo_subdc.Checked = True
        Me.rdo_subdc.Location = New System.Drawing.Point(10, 26)
        Me.rdo_subdc.Name = "rdo_subdc"
        Me.rdo_subdc.Size = New System.Drawing.Size(76, 16)
        Me.rdo_subdc.TabIndex = 45
        Me.rdo_subdc.TabStop = True
        Me.rdo_subdc.Text = "DC Mode"
        Me.rdo_subdc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdo_subdc.UseVisualStyleBackColor = True
        '
        'txt_SubLow
        '
        Me.txt_SubLow.Location = New System.Drawing.Point(348, 81)
        Me.txt_SubLow.Name = "txt_SubLow"
        Me.txt_SubLow.Size = New System.Drawing.Size(100, 21)
        Me.txt_SubLow.TabIndex = 58
        Me.txt_SubLow.Text = "-2"
        Me.txt_SubLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.Location = New System.Drawing.Point(454, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(14, 11)
        Me.Label12.TabIndex = 56
        Me.Label12.Text = "V"
        '
        'txt_SubHigh
        '
        Me.txt_SubHigh.Location = New System.Drawing.Point(348, 57)
        Me.txt_SubHigh.Name = "txt_SubHigh"
        Me.txt_SubHigh.Size = New System.Drawing.Size(100, 21)
        Me.txt_SubHigh.TabIndex = 60
        Me.txt_SubHigh.Text = "2"
        Me.txt_SubHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.Location = New System.Drawing.Point(454, 88)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(14, 11)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "V"
        '
        'lbl_dacnum1
        '
        Me.lbl_dacnum1.Location = New System.Drawing.Point(282, 57)
        Me.lbl_dacnum1.Name = "lbl_dacnum1"
        Me.lbl_dacnum1.Size = New System.Drawing.Size(59, 18)
        Me.lbl_dacnum1.TabIndex = 61
        Me.lbl_dacnum1.Text = "DAC 00"
        Me.lbl_dacnum1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdo_sublow
        '
        Me.rdo_sublow.AutoSize = True
        Me.rdo_sublow.Location = New System.Drawing.Point(269, 87)
        Me.rdo_sublow.Name = "rdo_sublow"
        Me.rdo_sublow.Size = New System.Drawing.Size(14, 13)
        Me.rdo_sublow.TabIndex = 64
        Me.rdo_sublow.UseVisualStyleBackColor = True
        '
        'lbl_dacnum2
        '
        Me.lbl_dacnum2.Location = New System.Drawing.Point(268, 84)
        Me.lbl_dacnum2.Name = "lbl_dacnum2"
        Me.lbl_dacnum2.Size = New System.Drawing.Size(92, 18)
        Me.lbl_dacnum2.TabIndex = 62
        Me.lbl_dacnum2.Text = "DAC 01"
        Me.lbl_dacnum2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdo_subhigh
        '
        Me.rdo_subhigh.AutoSize = True
        Me.rdo_subhigh.Checked = True
        Me.rdo_subhigh.Location = New System.Drawing.Point(269, 59)
        Me.rdo_subhigh.Name = "rdo_subhigh"
        Me.rdo_subhigh.Size = New System.Drawing.Size(14, 13)
        Me.rdo_subhigh.TabIndex = 63
        Me.rdo_subhigh.TabStop = True
        Me.rdo_subhigh.UseVisualStyleBackColor = True
        '
        'Ucgpio1
        '
        Me.Ucgpio1.AutoScroll = True
        Me.Ucgpio1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ucgpio1.Location = New System.Drawing.Point(0, 0)
        Me.Ucgpio1.Name = "Ucgpio1"
        Me.Ucgpio1.Size = New System.Drawing.Size(1054, 685)
        Me.Ucgpio1.TabIndex = 2
        Me.Ucgpio1.Visible = False
        '
        'UcADcFrame1
        '
        Me.UcADcFrame1.AutoScroll = True
        Me.UcADcFrame1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcADcFrame1.Location = New System.Drawing.Point(0, 0)
        Me.UcADcFrame1.Name = "UcADcFrame1"
        Me.UcADcFrame1.Size = New System.Drawing.Size(1054, 685)
        Me.UcADcFrame1.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(917, 200)
        Me.Panel3.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox8)
        Me.GroupBox1.Controls.Add(Me.grb_Adc)
        Me.GroupBox1.Controls.Add(Me.GroupBox7)
        Me.GroupBox1.Controls.Add(Me.grb_Dac)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(917, 200)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control "
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.txt_sCh1)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox8.Location = New System.Drawing.Point(890, 17)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(206, 180)
        Me.GroupBox8.TabIndex = 7
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Select Channel"
        '
        'txt_sCh1
        '
        Me.txt_sCh1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_sCh1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txt_sCh1.Location = New System.Drawing.Point(3, 17)
        Me.txt_sCh1.Multiline = True
        Me.txt_sCh1.Name = "txt_sCh1"
        Me.txt_sCh1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_sCh1.Size = New System.Drawing.Size(200, 160)
        Me.txt_sCh1.TabIndex = 0
        '
        'grb_Adc
        '
        Me.grb_Adc.Controls.Add(Me.txt_limit)
        Me.grb_Adc.Controls.Add(Me.txt_limitTemp)
        Me.grb_Adc.Controls.Add(Me.btn_multiLimitCurr)
        Me.grb_Adc.Controls.Add(Me.txt_avercount)
        Me.grb_Adc.Controls.Add(Me.btn_reset)
        Me.grb_Adc.Controls.Add(Me.btn_multiaverset)
        Me.grb_Adc.Controls.Add(Me.btn_read)
        Me.grb_Adc.Controls.Add(Me.btn_multiLimittemp)
        Me.grb_Adc.Dock = System.Windows.Forms.DockStyle.Left
        Me.grb_Adc.Enabled = False
        Me.grb_Adc.Location = New System.Drawing.Point(633, 17)
        Me.grb_Adc.Name = "grb_Adc"
        Me.grb_Adc.Size = New System.Drawing.Size(257, 180)
        Me.grb_Adc.TabIndex = 6
        Me.grb_Adc.TabStop = False
        Me.grb_Adc.Text = "Adc Multi Channel"
        '
        'txt_limit
        '
        Me.txt_limit.Location = New System.Drawing.Point(17, 169)
        Me.txt_limit.Name = "txt_limit"
        Me.txt_limit.Size = New System.Drawing.Size(81, 21)
        Me.txt_limit.TabIndex = 64
        Me.txt_limit.Text = "0"
        Me.txt_limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_limitTemp
        '
        Me.txt_limitTemp.Location = New System.Drawing.Point(17, 123)
        Me.txt_limitTemp.Name = "txt_limitTemp"
        Me.txt_limitTemp.Size = New System.Drawing.Size(81, 21)
        Me.txt_limitTemp.TabIndex = 63
        Me.txt_limitTemp.Text = "0"
        Me.txt_limitTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_multiLimitCurr
        '
        Me.btn_multiLimitCurr.Location = New System.Drawing.Point(104, 161)
        Me.btn_multiLimitCurr.Name = "btn_multiLimitCurr"
        Me.btn_multiLimitCurr.Size = New System.Drawing.Size(94, 34)
        Me.btn_multiLimitCurr.TabIndex = 62
        Me.btn_multiLimitCurr.Text = "Limit Current Set"
        Me.btn_multiLimitCurr.UseVisualStyleBackColor = True
        '
        'txt_avercount
        '
        Me.txt_avercount.Location = New System.Drawing.Point(17, 82)
        Me.txt_avercount.Name = "txt_avercount"
        Me.txt_avercount.Size = New System.Drawing.Size(81, 21)
        Me.txt_avercount.TabIndex = 61
        Me.txt_avercount.Text = "0"
        Me.txt_avercount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_reset
        '
        Me.btn_reset.Location = New System.Drawing.Point(104, 23)
        Me.btn_reset.Name = "btn_reset"
        Me.btn_reset.Size = New System.Drawing.Size(94, 34)
        Me.btn_reset.TabIndex = 3
        Me.btn_reset.Text = "Reset"
        Me.btn_reset.UseVisualStyleBackColor = True
        '
        'btn_multiaverset
        '
        Me.btn_multiaverset.Location = New System.Drawing.Point(104, 77)
        Me.btn_multiaverset.Name = "btn_multiaverset"
        Me.btn_multiaverset.Size = New System.Drawing.Size(94, 34)
        Me.btn_multiaverset.TabIndex = 2
        Me.btn_multiaverset.Text = "Average Set"
        Me.btn_multiaverset.UseVisualStyleBackColor = True
        '
        'btn_read
        '
        Me.btn_read.Location = New System.Drawing.Point(6, 23)
        Me.btn_read.Name = "btn_read"
        Me.btn_read.Size = New System.Drawing.Size(94, 34)
        Me.btn_read.TabIndex = 1
        Me.btn_read.Text = "Read"
        Me.btn_read.UseVisualStyleBackColor = True
        '
        'btn_multiLimittemp
        '
        Me.btn_multiLimittemp.Location = New System.Drawing.Point(104, 117)
        Me.btn_multiLimittemp.Name = "btn_multiLimittemp"
        Me.btn_multiLimittemp.Size = New System.Drawing.Size(94, 34)
        Me.btn_multiLimittemp.TabIndex = 0
        Me.btn_multiLimittemp.Text = "Limit Temp Set"
        Me.btn_multiLimittemp.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txt_sCh)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox7.Location = New System.Drawing.Point(427, 17)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(206, 180)
        Me.GroupBox7.TabIndex = 5
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Select Channel"
        '
        'txt_sCh
        '
        Me.txt_sCh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_sCh.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txt_sCh.Location = New System.Drawing.Point(3, 17)
        Me.txt_sCh.Multiline = True
        Me.txt_sCh.Name = "txt_sCh"
        Me.txt_sCh.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_sCh.Size = New System.Drawing.Size(200, 160)
        Me.txt_sCh.TabIndex = 0
        '
        'grb_Dac
        '
        Me.grb_Dac.Controls.Add(Me.btn_DacmultichSet)
        Me.grb_Dac.Controls.Add(Me.btn_dacmultichoff)
        Me.grb_Dac.Controls.Add(Me.GroupBox15)
        Me.grb_Dac.Controls.Add(Me.GroupBox14)
        Me.grb_Dac.Controls.Add(Me.chk_Sync)
        Me.grb_Dac.Controls.Add(Me.btn_dacmultichOnoff)
        Me.grb_Dac.Controls.Add(Me.btn_DacmultichRead)
        Me.grb_Dac.Dock = System.Windows.Forms.DockStyle.Left
        Me.grb_Dac.Enabled = False
        Me.grb_Dac.Location = New System.Drawing.Point(170, 17)
        Me.grb_Dac.Name = "grb_Dac"
        Me.grb_Dac.Size = New System.Drawing.Size(257, 180)
        Me.grb_Dac.TabIndex = 3
        Me.grb_Dac.TabStop = False
        Me.grb_Dac.Text = "Dac Multi Channel"
        '
        'btn_DacmultichSet
        '
        Me.btn_DacmultichSet.Location = New System.Drawing.Point(129, 171)
        Me.btn_DacmultichSet.Name = "btn_DacmultichSet"
        Me.btn_DacmultichSet.Size = New System.Drawing.Size(110, 40)
        Me.btn_DacmultichSet.TabIndex = 63
        Me.btn_DacmultichSet.Text = "Set"
        Me.btn_DacmultichSet.UseVisualStyleBackColor = True
        '
        'btn_dacmultichoff
        '
        Me.btn_dacmultichoff.Location = New System.Drawing.Point(168, 219)
        Me.btn_dacmultichoff.Name = "btn_dacmultichoff"
        Me.btn_dacmultichoff.Size = New System.Drawing.Size(63, 38)
        Me.btn_dacmultichoff.TabIndex = 62
        Me.btn_dacmultichoff.Text = "Off"
        Me.btn_dacmultichoff.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.Label10)
        Me.GroupBox15.Controls.Add(Me.Label9)
        Me.GroupBox15.Controls.Add(Me.Label8)
        Me.GroupBox15.Controls.Add(Me.txt_delay)
        Me.GroupBox15.Controls.Add(Me.txt_width)
        Me.GroupBox15.Controls.Add(Me.txt_period)
        Me.GroupBox15.Controls.Add(Me.rdo_pulseMode)
        Me.GroupBox15.Controls.Add(Me.rdo_dcMode)
        Me.GroupBox15.Location = New System.Drawing.Point(5, 70)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(246, 98)
        Me.GroupBox15.TabIndex = 61
        Me.GroupBox15.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.Location = New System.Drawing.Point(29, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 11)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Delay"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.Location = New System.Drawing.Point(80, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 11)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Width"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.Location = New System.Drawing.Point(149, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 11)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "Period"
        '
        'txt_delay
        '
        Me.txt_delay.Enabled = False
        Me.txt_delay.Location = New System.Drawing.Point(27, 71)
        Me.txt_delay.Name = "txt_delay"
        Me.txt_delay.Size = New System.Drawing.Size(49, 21)
        Me.txt_delay.TabIndex = 51
        Me.txt_delay.Text = "0.1"
        Me.txt_delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_width
        '
        Me.txt_width.Enabled = False
        Me.txt_width.Location = New System.Drawing.Point(77, 71)
        Me.txt_width.Name = "txt_width"
        Me.txt_width.Size = New System.Drawing.Size(49, 21)
        Me.txt_width.TabIndex = 50
        Me.txt_width.Text = "0.2"
        Me.txt_width.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_period
        '
        Me.txt_period.Enabled = False
        Me.txt_period.Location = New System.Drawing.Point(127, 71)
        Me.txt_period.Name = "txt_period"
        Me.txt_period.Size = New System.Drawing.Size(91, 21)
        Me.txt_period.TabIndex = 49
        Me.txt_period.Text = "0.4"
        Me.txt_period.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rdo_pulseMode
        '
        Me.rdo_pulseMode.AutoSize = True
        Me.rdo_pulseMode.Location = New System.Drawing.Point(12, 36)
        Me.rdo_pulseMode.Name = "rdo_pulseMode"
        Me.rdo_pulseMode.Size = New System.Drawing.Size(119, 16)
        Me.rdo_pulseMode.TabIndex = 48
        Me.rdo_pulseMode.Text = "Pulse Mode (us)"
        Me.rdo_pulseMode.UseVisualStyleBackColor = True
        '
        'rdo_dcMode
        '
        Me.rdo_dcMode.AutoSize = True
        Me.rdo_dcMode.Checked = True
        Me.rdo_dcMode.Location = New System.Drawing.Point(12, 15)
        Me.rdo_dcMode.Name = "rdo_dcMode"
        Me.rdo_dcMode.Size = New System.Drawing.Size(76, 16)
        Me.rdo_dcMode.TabIndex = 47
        Me.rdo_dcMode.TabStop = True
        Me.rdo_dcMode.Text = "DC Mode"
        Me.rdo_dcMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdo_dcMode.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.txt_dacLsetmulti)
        Me.GroupBox14.Controls.Add(Me.txt_dacHsetmulti)
        Me.GroupBox14.Controls.Add(Me.rdo_ch2)
        Me.GroupBox14.Controls.Add(Me.rdo_ch1)
        Me.GroupBox14.Location = New System.Drawing.Point(6, 10)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(245, 61)
        Me.GroupBox14.TabIndex = 60
        Me.GroupBox14.TabStop = False
        '
        'txt_dacLsetmulti
        '
        Me.txt_dacLsetmulti.Location = New System.Drawing.Point(98, 37)
        Me.txt_dacLsetmulti.Name = "txt_dacLsetmulti"
        Me.txt_dacLsetmulti.Size = New System.Drawing.Size(81, 21)
        Me.txt_dacLsetmulti.TabIndex = 61
        Me.txt_dacLsetmulti.Text = "0"
        Me.txt_dacLsetmulti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_dacHsetmulti
        '
        Me.txt_dacHsetmulti.Location = New System.Drawing.Point(99, 13)
        Me.txt_dacHsetmulti.Name = "txt_dacHsetmulti"
        Me.txt_dacHsetmulti.Size = New System.Drawing.Size(81, 21)
        Me.txt_dacHsetmulti.TabIndex = 60
        Me.txt_dacHsetmulti.Text = "0"
        Me.txt_dacHsetmulti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rdo_ch2
        '
        Me.rdo_ch2.AutoSize = True
        Me.rdo_ch2.Location = New System.Drawing.Point(15, 36)
        Me.rdo_ch2.Name = "rdo_ch2"
        Me.rdo_ch2.Size = New System.Drawing.Size(73, 16)
        Me.rdo_ch2.TabIndex = 59
        Me.rdo_ch2.Text = "Dac Low"
        Me.rdo_ch2.UseVisualStyleBackColor = True
        '
        'rdo_ch1
        '
        Me.rdo_ch1.AutoSize = True
        Me.rdo_ch1.Checked = True
        Me.rdo_ch1.Location = New System.Drawing.Point(14, 14)
        Me.rdo_ch1.Name = "rdo_ch1"
        Me.rdo_ch1.Size = New System.Drawing.Size(74, 16)
        Me.rdo_ch1.TabIndex = 58
        Me.rdo_ch1.TabStop = True
        Me.rdo_ch1.Text = "Dac High"
        Me.rdo_ch1.UseVisualStyleBackColor = True
        '
        'chk_Sync
        '
        Me.chk_Sync.AutoSize = True
        Me.chk_Sync.Location = New System.Drawing.Point(45, 231)
        Me.chk_Sync.Name = "chk_Sync"
        Me.chk_Sync.Size = New System.Drawing.Size(53, 16)
        Me.chk_Sync.TabIndex = 50
        Me.chk_Sync.Text = "Sync"
        Me.chk_Sync.UseVisualStyleBackColor = True
        '
        'btn_dacmultichOnoff
        '
        Me.btn_dacmultichOnoff.Location = New System.Drawing.Point(104, 219)
        Me.btn_dacmultichOnoff.Name = "btn_dacmultichOnoff"
        Me.btn_dacmultichOnoff.Size = New System.Drawing.Size(63, 38)
        Me.btn_dacmultichOnoff.TabIndex = 5
        Me.btn_dacmultichOnoff.Text = "On"
        Me.btn_dacmultichOnoff.UseVisualStyleBackColor = True
        '
        'btn_DacmultichRead
        '
        Me.btn_DacmultichRead.Location = New System.Drawing.Point(14, 171)
        Me.btn_DacmultichRead.Name = "btn_DacmultichRead"
        Me.btn_DacmultichRead.Size = New System.Drawing.Size(110, 40)
        Me.btn_DacmultichRead.TabIndex = 4
        Me.btn_DacmultichRead.Text = "Read"
        Me.btn_DacmultichRead.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox16)
        Me.GroupBox2.Controls.Add(Me.chk_CalApply)
        Me.GroupBox2.Controls.Add(Me.Chk_All)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cboType)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox2.Location = New System.Drawing.Point(3, 17)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(167, 180)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.btnLoad)
        Me.GroupBox16.Location = New System.Drawing.Point(7, 143)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(154, 66)
        Me.GroupBox16.TabIndex = 50
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Test Setting"
        '
        'btnLoad
        '
        Me.btnLoad.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnLoad.Location = New System.Drawing.Point(40, 26)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 31)
        Me.btnLoad.TabIndex = 58
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'chk_CalApply
        '
        Me.chk_CalApply.AutoSize = True
        Me.chk_CalApply.Location = New System.Drawing.Point(54, 107)
        Me.chk_CalApply.Name = "chk_CalApply"
        Me.chk_CalApply.Size = New System.Drawing.Size(79, 16)
        Me.chk_CalApply.TabIndex = 3
        Me.chk_CalApply.Text = "Apply Cal"
        Me.chk_CalApply.UseVisualStyleBackColor = True
        '
        'Chk_All
        '
        Me.Chk_All.AutoSize = True
        Me.Chk_All.Location = New System.Drawing.Point(54, 80)
        Me.Chk_All.Name = "Chk_All"
        Me.Chk_All.Size = New System.Drawing.Size(64, 16)
        Me.Chk_All.TabIndex = 49
        Me.Chk_All.Text = "All Chk"
        Me.Chk_All.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 11)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Type"
        '
        'cboType
        '
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"DAC", "ADC", "GPIO"})
        Me.cboType.Location = New System.Drawing.Point(43, 38)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(108, 20)
        Me.cboType.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(435, 740)
        Me.Panel1.TabIndex = 0
        '
        'frmSGControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1370, 746)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmSGControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "2013 08 02"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.GroupBox21.ResumeLayout(False)
        Me.GroupBox21.PerformLayout()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.grb_Adc.ResumeLayout(False)
        Me.grb_Adc.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.grb_Dac.ResumeLayout(False)
        Me.grb_Dac.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents btnDisconnection As System.Windows.Forms.Button
    Friend WithEvents cbBaudRate As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_err As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbError As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboType As System.Windows.Forms.ComboBox

    Friend WithEvents btn_getallch As System.Windows.Forms.Button
    Friend WithEvents btn_setallch As System.Windows.Forms.Button
    Friend WithEvents btn_get1ch As System.Windows.Forms.Button
    Friend WithEvents btn_set1ch As System.Windows.Forms.Button
    Friend WithEvents btn_Getmode1ch As System.Windows.Forms.Button
    Friend WithEvents btn_setmode1ch As System.Windows.Forms.Button
    Friend WithEvents btn_getmodeallch As System.Windows.Forms.Button
    Friend WithEvents btn_setmodeallch As System.Windows.Forms.Button
    Friend WithEvents bnt_get1chOnoff As System.Windows.Forms.Button
    Friend WithEvents bnt_set1chOnoff As System.Windows.Forms.Button
    Friend WithEvents btn_chaddrset As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_ch As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_addrs As System.Windows.Forms.TextBox
    Friend WithEvents bnt_getallchOnoff As System.Windows.Forms.Button
    Friend WithEvents bnt_setallchOnoff As System.Windows.Forms.Button
    Friend WithEvents bnt_Get1chfOutput As System.Windows.Forms.Button
    Friend WithEvents bnt_set1chfOutput As System.Windows.Forms.Button
    Friend WithEvents bnt_getallchfOutput As System.Windows.Forms.Button
    Friend WithEvents UcADcFrame1 As UcADcFrame
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Ucgpio1 As Ucgpio
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Chk_All As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grb_Dac As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_sCh As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_sCh1 As System.Windows.Forms.TextBox
    Friend WithEvents grb_Adc As System.Windows.Forms.GroupBox
    Friend WithEvents btn_multiaverset As System.Windows.Forms.Button
    Friend WithEvents btn_read As System.Windows.Forms.Button
    Friend WithEvents btn_multiLimittemp As System.Windows.Forms.Button
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents UcSingleList1 As ucSingleList
    Friend WithEvents btn_GetAalarm As System.Windows.Forms.Button
    Friend WithEvents btn_setalarm As System.Windows.Forms.Button
    Friend WithEvents bnt_getallchpulse As System.Windows.Forms.Button
    Friend WithEvents bnt_setallchpulse As System.Windows.Forms.Button
    Friend WithEvents bnt_get1chpulse As System.Windows.Forms.Button
    Friend WithEvents bnt_set1chpulse As System.Windows.Forms.Button
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_getlimitallch As System.Windows.Forms.Button
    Friend WithEvents btn_setlimitallch As System.Windows.Forms.Button
    Friend WithEvents btn_getlimit1ch As System.Windows.Forms.Button
    Friend WithEvents btn_setlimit1ch As System.Windows.Forms.Button
    Friend WithEvents btn_getaver1ch As System.Windows.Forms.Button
    Friend WithEvents btn_Setaver1ch As System.Windows.Forms.Button
    Friend WithEvents btn_readadcallch As System.Windows.Forms.Button
    Friend WithEvents btn_readadc1ch As System.Windows.Forms.Button
    Friend WithEvents btn_GetlimitTemp1ch As System.Windows.Forms.Button
    Friend WithEvents btn_setlimitTemp1ch As System.Windows.Forms.Button
    Friend WithEvents btn_getlimitTempallch As System.Windows.Forms.Button
    Friend WithEvents btn_setlimitTempallch As System.Windows.Forms.Button
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_getgpo_out_onoff As System.Windows.Forms.Button
    Friend WithEvents btn_setgpo_out_onoff As System.Windows.Forms.Button
    Friend WithEvents btn_getgpio_out_onoff As System.Windows.Forms.Button
    Friend WithEvents btn_setgpio_out_onoff As System.Windows.Forms.Button
    Friend WithEvents btn_gpio_Inputget As System.Windows.Forms.Button
    Friend WithEvents btn_gpio_Inputset As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_getdacoffset As System.Windows.Forms.Button
    Friend WithEvents btn_setdacoffset As System.Windows.Forms.Button
    Friend WithEvents btn_getdacslope As System.Windows.Forms.Button
    Friend WithEvents btn_setdacslope As System.Windows.Forms.Button
    Friend WithEvents btn_getCalApply As System.Windows.Forms.Button
    Friend WithEvents btn_setCalApply As System.Windows.Forms.Button
    Friend WithEvents btn_getadcoffset As System.Windows.Forms.Button
    Friend WithEvents btn_setadcoffset As System.Windows.Forms.Button
    Friend WithEvents btn_getadcslope As System.Windows.Forms.Button
    Friend WithEvents btn_setadcslope As System.Windows.Forms.Button
    Friend WithEvents chk_CalApply As System.Windows.Forms.CheckBox
    Friend WithEvents btn_dacmultichOnoff As System.Windows.Forms.Button
    Friend WithEvents btn_DacmultichRead As System.Windows.Forms.Button
    Friend WithEvents chk_Sync As System.Windows.Forms.CheckBox
    Friend WithEvents btn_getaverallch As System.Windows.Forms.Button
    Friend WithEvents btn_Setaverallch As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents bnt_setallchfOutput As System.Windows.Forms.Button
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_dacLsetmulti As System.Windows.Forms.TextBox
    Friend WithEvents txt_dacHsetmulti As System.Windows.Forms.TextBox
    Friend WithEvents rdo_ch2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_ch1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents rdo_pulseMode As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_dcMode As System.Windows.Forms.RadioButton
    Friend WithEvents btn_dacmultichoff As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_delay As System.Windows.Forms.TextBox
    Friend WithEvents txt_width As System.Windows.Forms.TextBox
    Friend WithEvents txt_period As System.Windows.Forms.TextBox
    Friend WithEvents btn_reset As System.Windows.Forms.Button
    Friend WithEvents txt_limit As System.Windows.Forms.TextBox
    Friend WithEvents txt_limitTemp As System.Windows.Forms.TextBox
    Friend WithEvents btn_multiLimitCurr As System.Windows.Forms.Button
    Friend WithEvents txt_avercount As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btn_DacmultichSet As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_suball As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_subch As System.Windows.Forms.ComboBox
    Friend WithEvents rdo_sublow As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_subhigh As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_dacnum2 As System.Windows.Forms.Label
    Friend WithEvents lbl_dacnum1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_SubHigh As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnSetDAC_Low As System.Windows.Forms.Button
    Friend WithEvents txt_SubLow As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents rdo_subpusle As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_subdc As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUnitPulseDelay As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblUnitPulsePeriod As System.Windows.Forms.Label
    Friend WithEvents txtwidth As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtdelay As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtperiod As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_sigall As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_sigch As System.Windows.Forms.ComboBox
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents GroupBox21 As System.Windows.Forms.GroupBox
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_mainall As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_Mainch As System.Windows.Forms.ComboBox
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents cbSelDevice As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label

End Class
