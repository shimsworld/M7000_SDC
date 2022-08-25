<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfigMotion
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.gbConfig = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb_AixsInverting = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbHomeSpeed = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_DirectionInverting = New System.Windows.Forms.ComboBox()
        Me.btnModify = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.cbo_axis = New System.Windows.Forms.ComboBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnListDel = New System.Windows.Forms.Button()
        Me.ConfigList = New M7000.ucDispListView()
        Me.tbMaximumSpeed = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tbStartSpeed = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbUnitPulse = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbDecel = New System.Windows.Forms.TextBox()
        Me.tbAccel = New System.Windows.Forms.TextBox()
        Me.tbVelocity = New System.Windows.Forms.TextBox()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbo_encodermethod = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_pulsemethod = New System.Windows.Forms.ComboBox()
        Me.gbConfig.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbConfig
        '
        Me.gbConfig.Controls.Add(Me.Label4)
        Me.gbConfig.Controls.Add(Me.cb_AixsInverting)
        Me.gbConfig.Controls.Add(Me.Label2)
        Me.gbConfig.Controls.Add(Me.tbHomeSpeed)
        Me.gbConfig.Controls.Add(Me.Label1)
        Me.gbConfig.Controls.Add(Me.cbo_DirectionInverting)
        Me.gbConfig.Controls.Add(Me.btnModify)
        Me.gbConfig.Controls.Add(Me.Label3)
        Me.gbConfig.Controls.Add(Me.btnADD)
        Me.gbConfig.Controls.Add(Me.cbo_axis)
        Me.gbConfig.Controls.Add(Me.btnClear)
        Me.gbConfig.Controls.Add(Me.btnListDel)
        Me.gbConfig.Controls.Add(Me.ConfigList)
        Me.gbConfig.Controls.Add(Me.tbMaximumSpeed)
        Me.gbConfig.Controls.Add(Me.Label18)
        Me.gbConfig.Controls.Add(Me.tbStartSpeed)
        Me.gbConfig.Controls.Add(Me.Label15)
        Me.gbConfig.Controls.Add(Me.tbUnitPulse)
        Me.gbConfig.Controls.Add(Me.Label10)
        Me.gbConfig.Controls.Add(Me.tbDecel)
        Me.gbConfig.Controls.Add(Me.tbAccel)
        Me.gbConfig.Controls.Add(Me.tbVelocity)
        Me.gbConfig.Controls.Add(Me.lbl1)
        Me.gbConfig.Controls.Add(Me.Label9)
        Me.gbConfig.Controls.Add(Me.Label8)
        Me.gbConfig.Controls.Add(Me.Label7)
        Me.gbConfig.Controls.Add(Me.cbo_encodermethod)
        Me.gbConfig.Controls.Add(Me.Label5)
        Me.gbConfig.Controls.Add(Me.cbo_pulsemethod)
        Me.gbConfig.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.gbConfig.Location = New System.Drawing.Point(14, 17)
        Me.gbConfig.Name = "gbConfig"
        Me.gbConfig.Size = New System.Drawing.Size(1205, 306)
        Me.gbConfig.TabIndex = 1
        Me.gbConfig.TabStop = False
        Me.gbConfig.Text = "Settings"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Orange
        Me.Label4.Location = New System.Drawing.Point(17, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 18)
        Me.Label4.TabIndex = 115
        Me.Label4.Text = "Real Aixs Inverting"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cb_AixsInverting
        '
        Me.cb_AixsInverting.FormattingEnabled = True
        Me.cb_AixsInverting.Items.AddRange(New Object() {"Not Use", "Y Axis", "Z Axis", "Angle Axis", "Angle2 Axis", "Angle3 Axis", "Angle4 Axis"})
        Me.cb_AixsInverting.Location = New System.Drawing.Point(104, 45)
        Me.cb_AixsInverting.Name = "cb_AixsInverting"
        Me.cb_AixsInverting.Size = New System.Drawing.Size(75, 20)
        Me.cb_AixsInverting.TabIndex = 114
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Orange
        Me.Label2.Location = New System.Drawing.Point(648, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 18)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "home Speed"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbHomeSpeed
        '
        Me.tbHomeSpeed.Location = New System.Drawing.Point(733, 88)
        Me.tbHomeSpeed.Name = "tbHomeSpeed"
        Me.tbHomeSpeed.Size = New System.Drawing.Size(74, 21)
        Me.tbHomeSpeed.TabIndex = 110
        Me.tbHomeSpeed.Text = "70"
        Me.tbHomeSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Orange
        Me.Label1.Location = New System.Drawing.Point(189, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 18)
        Me.Label1.TabIndex = 109
        Me.Label1.Text = "Direction Inverting"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbo_DirectionInverting
        '
        Me.cbo_DirectionInverting.FormattingEnabled = True
        Me.cbo_DirectionInverting.Items.AddRange(New Object() {"False", "True"})
        Me.cbo_DirectionInverting.Location = New System.Drawing.Point(308, 68)
        Me.cbo_DirectionInverting.Name = "cbo_DirectionInverting"
        Me.cbo_DirectionInverting.Size = New System.Drawing.Size(100, 20)
        Me.cbo_DirectionInverting.TabIndex = 108
        '
        'btnModify
        '
        Me.btnModify.Location = New System.Drawing.Point(343, 106)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(82, 28)
        Me.btnModify.TabIndex = 107
        Me.btnModify.Text = "Modify"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Orange
        Me.Label3.Location = New System.Drawing.Point(18, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 18)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Aixs"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnADD
        '
        Me.btnADD.Location = New System.Drawing.Point(241, 106)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(82, 28)
        Me.btnADD.TabIndex = 106
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'cbo_axis
        '
        Me.cbo_axis.FormattingEnabled = True
        Me.cbo_axis.Items.AddRange(New Object() {"Not Use", "Y Axis", "Z Axis", "Angle Axis", "Angle2 Axis", "Angle3 Axis", "Angle4 Axis"})
        Me.cbo_axis.Location = New System.Drawing.Point(104, 20)
        Me.cbo_axis.Name = "cbo_axis"
        Me.cbo_axis.Size = New System.Drawing.Size(76, 20)
        Me.cbo_axis.TabIndex = 53
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(549, 106)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(82, 28)
        Me.btnClear.TabIndex = 105
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnListDel
        '
        Me.btnListDel.Location = New System.Drawing.Point(446, 106)
        Me.btnListDel.Name = "btnListDel"
        Me.btnListDel.Size = New System.Drawing.Size(82, 28)
        Me.btnListDel.TabIndex = 104
        Me.btnListDel.Text = "DELETE"
        Me.btnListDel.UseVisualStyleBackColor = True
        '
        'ConfigList
        '
        Me.ConfigList.ColHeader = New String() {"Axis Idx", "Pulse Method", "Encoder Method", "Axis", "Real Axis", "Velocity", "Acceleration", "Deceleraton", "Unit/Pulse", "Start Speed", "Speed Limit", "Direction", "Home Speed"}
        Me.ConfigList.ColHeaderWidthRatio = "6,11,12,6,6,7,9,9,8,9,9,7,9"
        Me.ConfigList.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConfigList.FullRawSelection = True
        Me.ConfigList.HideSelection = False
        Me.ConfigList.LabelEdit = True
        Me.ConfigList.LabelWrap = True
        Me.ConfigList.Location = New System.Drawing.Point(19, 145)
        Me.ConfigList.Name = "ConfigList"
        Me.ConfigList.Size = New System.Drawing.Size(1165, 134)
        Me.ConfigList.TabIndex = 103
        Me.ConfigList.UseCheckBoxex = False
        '
        'tbMaximumSpeed
        '
        Me.tbMaximumSpeed.Location = New System.Drawing.Point(733, 18)
        Me.tbMaximumSpeed.Name = "tbMaximumSpeed"
        Me.tbMaximumSpeed.Size = New System.Drawing.Size(74, 21)
        Me.tbMaximumSpeed.TabIndex = 102
        Me.tbMaximumSpeed.Text = "70"
        Me.tbMaximumSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Orange
        Me.Label18.Location = New System.Drawing.Point(648, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 18)
        Me.Label18.TabIndex = 101
        Me.Label18.Text = "Speed Limit"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbStartSpeed
        '
        Me.tbStartSpeed.Location = New System.Drawing.Point(733, 40)
        Me.tbStartSpeed.Name = "tbStartSpeed"
        Me.tbStartSpeed.Size = New System.Drawing.Size(74, 21)
        Me.tbStartSpeed.TabIndex = 96
        Me.tbStartSpeed.Text = "1"
        Me.tbStartSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Orange
        Me.Label15.Location = New System.Drawing.Point(648, 43)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 18)
        Me.Label15.TabIndex = 95
        Me.Label15.Text = "Start Speed"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbUnitPulse
        '
        Me.tbUnitPulse.Location = New System.Drawing.Point(733, 64)
        Me.tbUnitPulse.Name = "tbUnitPulse"
        Me.tbUnitPulse.Size = New System.Drawing.Size(74, 21)
        Me.tbUnitPulse.TabIndex = 90
        Me.tbUnitPulse.Text = "0.01"
        Me.tbUnitPulse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Orange
        Me.Label10.Location = New System.Drawing.Point(648, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 18)
        Me.Label10.TabIndex = 89
        Me.Label10.Text = "unit/pulse"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbDecel
        '
        Me.tbDecel.Location = New System.Drawing.Point(549, 67)
        Me.tbDecel.Name = "tbDecel"
        Me.tbDecel.Size = New System.Drawing.Size(87, 21)
        Me.tbDecel.TabIndex = 88
        Me.tbDecel.Text = "800"
        Me.tbDecel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbAccel
        '
        Me.tbAccel.Location = New System.Drawing.Point(549, 43)
        Me.tbAccel.Name = "tbAccel"
        Me.tbAccel.Size = New System.Drawing.Size(87, 21)
        Me.tbAccel.TabIndex = 87
        Me.tbAccel.Text = "350"
        Me.tbAccel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbVelocity
        '
        Me.tbVelocity.Location = New System.Drawing.Point(549, 17)
        Me.tbVelocity.Name = "tbVelocity"
        Me.tbVelocity.Size = New System.Drawing.Size(87, 21)
        Me.tbVelocity.TabIndex = 86
        Me.tbVelocity.Text = "70"
        Me.tbVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl1
        '
        Me.lbl1.BackColor = System.Drawing.Color.Orange
        Me.lbl1.Location = New System.Drawing.Point(459, 70)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(87, 18)
        Me.lbl1.TabIndex = 85
        Me.lbl1.Text = "Deceleration"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Orange
        Me.Label9.Location = New System.Drawing.Point(459, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 18)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Acceleration"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Orange
        Me.Label8.Location = New System.Drawing.Point(459, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 18)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Velocity"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Orange
        Me.Label7.Location = New System.Drawing.Point(189, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 18)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Encoder Method"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbo_encodermethod
        '
        Me.cbo_encodermethod.FormattingEnabled = True
        Me.cbo_encodermethod.Items.AddRange(New Object() {"eUpDownMode", "eSqr1Mode        ", "eSqr2Mode          ", "eSqr4Mode         "})
        Me.cbo_encodermethod.Location = New System.Drawing.Point(308, 46)
        Me.cbo_encodermethod.Name = "cbo_encodermethod"
        Me.cbo_encodermethod.Size = New System.Drawing.Size(145, 20)
        Me.cbo_encodermethod.TabIndex = 81
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Orange
        Me.Label5.Location = New System.Drawing.Point(189, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 18)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "Pulse  Method"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbo_pulsemethod
        '
        Me.cbo_pulsemethod.FormattingEnabled = True
        Me.cbo_pulsemethod.Items.AddRange(New Object() {"eOneHighLowHigh ", "eOneHighHighLow", "eOneLowLowHigh", "eOneLowHighLow", "eTwoCcwCwHigh", "eTwoCcwCwLow", "eTwoCwCcwHigh", "eTwoCwCcwLow"})
        Me.cbo_pulsemethod.Location = New System.Drawing.Point(308, 20)
        Me.cbo_pulsemethod.Name = "cbo_pulsemethod"
        Me.cbo_pulsemethod.Size = New System.Drawing.Size(145, 20)
        Me.cbo_pulsemethod.TabIndex = 79
        '
        'ucConfigMotion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.gbConfig)
        Me.Name = "ucConfigMotion"
        Me.Size = New System.Drawing.Size(1277, 348)
        Me.gbConfig.ResumeLayout(false)
        Me.gbConfig.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents gbConfig As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbHomeSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_DirectionInverting As System.Windows.Forms.ComboBox
    Friend WithEvents btnModify As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents cbo_axis As System.Windows.Forms.ComboBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnListDel As System.Windows.Forms.Button
    Friend WithEvents ConfigList As M7000.ucDispListView
    Friend WithEvents tbMaximumSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbStartSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbUnitPulse As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbDecel As System.Windows.Forms.TextBox
    Friend WithEvents tbAccel As System.Windows.Forms.TextBox
    Friend WithEvents tbVelocity As System.Windows.Forms.TextBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_encodermethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_pulsemethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cb_AixsInverting As System.Windows.Forms.ComboBox

End Class
