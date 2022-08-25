<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMotionControl
    Inherits System.Windows.Forms.UserControl

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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
        Me.btnSaveTarget = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnPositionChange = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnYAxisMove = New System.Windows.Forms.Button()
        Me.btnZAxisMove = New System.Windows.Forms.Button()
        Me.btnXAxisMove = New System.Windows.Forms.Button()
        Me.chkAxisZ = New System.Windows.Forms.CheckBox()
        Me.rdoAbs = New System.Windows.Forms.RadioButton()
        Me.rdoMicroAdjsut = New System.Windows.Forms.RadioButton()
        Me.txtPosition = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnBottomRight = New System.Windows.Forms.Button()
        Me.btnBottom = New System.Windows.Forms.Button()
        Me.btnBottomLeft = New System.Windows.Forms.Button()
        Me.btnRigth = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnLeft = New System.Windows.Forms.Button()
        Me.btnPositionReset = New System.Windows.Forms.Button()
        Me.btnServoOff = New System.Windows.Forms.Button()
        Me.btnServoOn = New System.Windows.Forms.Button()
        Me.btnRightUpper = New System.Windows.Forms.Button()
        Me.btnAbove = New System.Windows.Forms.Button()
        Me.btnLeftUpper = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSaveTarget)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnBottomRight)
        Me.GroupBox1.Controls.Add(Me.btnBottom)
        Me.GroupBox1.Controls.Add(Me.btnBottomLeft)
        Me.GroupBox1.Controls.Add(Me.btnRigth)
        Me.GroupBox1.Controls.Add(Me.btnStop)
        Me.GroupBox1.Controls.Add(Me.btnLeft)
        Me.GroupBox1.Controls.Add(Me.btnPositionReset)
        Me.GroupBox1.Controls.Add(Me.btnServoOff)
        Me.GroupBox1.Controls.Add(Me.btnServoOn)
        Me.GroupBox1.Controls.Add(Me.btnRightUpper)
        Me.GroupBox1.Controls.Add(Me.btnAbove)
        Me.GroupBox1.Controls.Add(Me.btnLeftUpper)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(493, 347)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Motion Control"
        '
        'btnSaveTarget
        '
        Me.btnSaveTarget.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnSaveTarget.Location = New System.Drawing.Point(227, 295)
        Me.btnSaveTarget.Name = "btnSaveTarget"
        Me.btnSaveTarget.Size = New System.Drawing.Size(134, 33)
        Me.btnSaveTarget.TabIndex = 34
        Me.btnSaveTarget.Text = "Save Target" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Position"
        Me.btnSaveTarget.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnPositionChange)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 273)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(211, 59)
        Me.GroupBox3.TabIndex = 33
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Position Change"
        '
        'btnPositionChange
        '
        Me.btnPositionChange.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnPositionChange.Location = New System.Drawing.Point(5, 22)
        Me.btnPositionChange.Name = "btnPositionChange"
        Me.btnPositionChange.Size = New System.Drawing.Size(197, 33)
        Me.btnPositionChange.TabIndex = 34
        Me.btnPositionChange.Text = "Spectrometer <-> CCD Carmera"
        Me.btnPositionChange.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btnYAxisMove)
        Me.GroupBox2.Controls.Add(Me.btnZAxisMove)
        Me.GroupBox2.Controls.Add(Me.btnXAxisMove)
        Me.GroupBox2.Controls.Add(Me.chkAxisZ)
        Me.GroupBox2.Controls.Add(Me.rdoAbs)
        Me.GroupBox2.Controls.Add(Me.rdoMicroAdjsut)
        Me.GroupBox2.Controls.Add(Me.txtPosition)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Location = New System.Drawing.Point(227, 62)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(134, 205)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Set Parameter"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 12)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Z Axis"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 12)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Abs"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "micro-adjust"
        '
        'btnYAxisMove
        '
        Me.btnYAxisMove.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnYAxisMove.Location = New System.Drawing.Point(6, 149)
        Me.btnYAxisMove.Name = "btnYAxisMove"
        Me.btnYAxisMove.Size = New System.Drawing.Size(90, 23)
        Me.btnYAxisMove.TabIndex = 37
        Me.btnYAxisMove.Text = "Y Axis Move"
        Me.btnYAxisMove.UseVisualStyleBackColor = False
        '
        'btnZAxisMove
        '
        Me.btnZAxisMove.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnZAxisMove.Location = New System.Drawing.Point(6, 177)
        Me.btnZAxisMove.Name = "btnZAxisMove"
        Me.btnZAxisMove.Size = New System.Drawing.Size(90, 23)
        Me.btnZAxisMove.TabIndex = 36
        Me.btnZAxisMove.Text = "Z Axis Move"
        Me.btnZAxisMove.UseVisualStyleBackColor = False
        '
        'btnXAxisMove
        '
        Me.btnXAxisMove.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnXAxisMove.Location = New System.Drawing.Point(6, 121)
        Me.btnXAxisMove.Name = "btnXAxisMove"
        Me.btnXAxisMove.Size = New System.Drawing.Size(90, 23)
        Me.btnXAxisMove.TabIndex = 34
        Me.btnXAxisMove.Text = "X Axis Move"
        Me.btnXAxisMove.UseVisualStyleBackColor = False
        '
        'chkAxisZ
        '
        Me.chkAxisZ.AutoSize = True
        Me.chkAxisZ.Location = New System.Drawing.Point(10, 99)
        Me.chkAxisZ.Name = "chkAxisZ"
        Me.chkAxisZ.Size = New System.Drawing.Size(15, 14)
        Me.chkAxisZ.TabIndex = 33
        Me.chkAxisZ.UseVisualStyleBackColor = True
        '
        'rdoAbs
        '
        Me.rdoAbs.AutoSize = True
        Me.rdoAbs.Location = New System.Drawing.Point(10, 78)
        Me.rdoAbs.Name = "rdoAbs"
        Me.rdoAbs.Size = New System.Drawing.Size(14, 13)
        Me.rdoAbs.TabIndex = 35
        Me.rdoAbs.TabStop = True
        Me.rdoAbs.UseVisualStyleBackColor = True
        '
        'rdoMicroAdjsut
        '
        Me.rdoMicroAdjsut.AutoSize = True
        Me.rdoMicroAdjsut.Location = New System.Drawing.Point(10, 56)
        Me.rdoMicroAdjsut.Name = "rdoMicroAdjsut"
        Me.rdoMicroAdjsut.Size = New System.Drawing.Size(14, 13)
        Me.rdoMicroAdjsut.TabIndex = 32
        Me.rdoMicroAdjsut.TabStop = True
        Me.rdoMicroAdjsut.UseVisualStyleBackColor = True
        '
        'txtPosition
        '
        Me.txtPosition.Location = New System.Drawing.Point(6, 30)
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.ReadOnly = True
        Me.txtPosition.Size = New System.Drawing.Size(102, 21)
        Me.txtPosition.TabIndex = 29
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label19.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Label19.Location = New System.Drawing.Point(7, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 12)
        Me.Label19.TabIndex = 28
        Me.Label19.Text = "  Position  (mm)"
        '
        'btnBottomRight
        '
        Me.btnBottomRight.Image = Global.M7000.My.Resources.Resources.motionRDOWN
        Me.btnBottomRight.Location = New System.Drawing.Point(136, 202)
        Me.btnBottomRight.Name = "btnBottomRight"
        Me.btnBottomRight.Size = New System.Drawing.Size(69, 65)
        Me.btnBottomRight.TabIndex = 31
        Me.btnBottomRight.UseVisualStyleBackColor = True
        '
        'btnBottom
        '
        Me.btnBottom.Image = Global.M7000.My.Resources.Resources.motionDOWN
        Me.btnBottom.Location = New System.Drawing.Point(73, 202)
        Me.btnBottom.Name = "btnBottom"
        Me.btnBottom.Size = New System.Drawing.Size(69, 65)
        Me.btnBottom.TabIndex = 30
        Me.btnBottom.UseVisualStyleBackColor = True
        '
        'btnBottomLeft
        '
        Me.btnBottomLeft.Image = Global.M7000.My.Resources.Resources.motionLDOWN
        Me.btnBottomLeft.Location = New System.Drawing.Point(7, 202)
        Me.btnBottomLeft.Name = "btnBottomLeft"
        Me.btnBottomLeft.Size = New System.Drawing.Size(69, 65)
        Me.btnBottomLeft.TabIndex = 29
        Me.btnBottomLeft.UseVisualStyleBackColor = True
        '
        'btnRigth
        '
        Me.btnRigth.Image = Global.M7000.My.Resources.Resources.motionR
        Me.btnRigth.Location = New System.Drawing.Point(136, 138)
        Me.btnRigth.Name = "btnRigth"
        Me.btnRigth.Size = New System.Drawing.Size(69, 65)
        Me.btnRigth.TabIndex = 28
        Me.btnRigth.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.BackColor = System.Drawing.Color.White
        Me.btnStop.Font = New System.Drawing.Font("굴림", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnStop.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnStop.Location = New System.Drawing.Point(73, 138)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(69, 65)
        Me.btnStop.TabIndex = 27
        Me.btnStop.Text = "STOP"
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'btnLeft
        '
        Me.btnLeft.Image = Global.M7000.My.Resources.Resources.motionL
        Me.btnLeft.Location = New System.Drawing.Point(10, 138)
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.Size = New System.Drawing.Size(68, 65)
        Me.btnLeft.TabIndex = 26
        Me.btnLeft.UseVisualStyleBackColor = True
        '
        'btnPositionReset
        '
        Me.btnPositionReset.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnPositionReset.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnPositionReset.Location = New System.Drawing.Point(227, 23)
        Me.btnPositionReset.Name = "btnPositionReset"
        Me.btnPositionReset.Size = New System.Drawing.Size(134, 33)
        Me.btnPositionReset.TabIndex = 25
        Me.btnPositionReset.Text = "Position Reset" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  (Homming)"
        Me.btnPositionReset.UseVisualStyleBackColor = False
        '
        'btnServoOff
        '
        Me.btnServoOff.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnServoOff.Location = New System.Drawing.Point(111, 22)
        Me.btnServoOff.Name = "btnServoOff"
        Me.btnServoOff.Size = New System.Drawing.Size(94, 33)
        Me.btnServoOff.TabIndex = 24
        Me.btnServoOff.Text = "Servo OFF"
        Me.btnServoOff.UseVisualStyleBackColor = False
        '
        'btnServoOn
        '
        Me.btnServoOn.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnServoOn.Location = New System.Drawing.Point(10, 22)
        Me.btnServoOn.Name = "btnServoOn"
        Me.btnServoOn.Size = New System.Drawing.Size(94, 33)
        Me.btnServoOn.TabIndex = 23
        Me.btnServoOn.Text = "Servo ON"
        Me.btnServoOn.UseVisualStyleBackColor = False
        '
        'btnRightUpper
        '
        Me.btnRightUpper.Image = Global.M7000.My.Resources.Resources.motionRUP
        Me.btnRightUpper.Location = New System.Drawing.Point(138, 74)
        Me.btnRightUpper.Name = "btnRightUpper"
        Me.btnRightUpper.Size = New System.Drawing.Size(69, 65)
        Me.btnRightUpper.TabIndex = 16
        Me.btnRightUpper.UseVisualStyleBackColor = True
        '
        'btnAbove
        '
        Me.btnAbove.Image = Global.M7000.My.Resources.Resources.motionUP
        Me.btnAbove.Location = New System.Drawing.Point(73, 74)
        Me.btnAbove.Name = "btnAbove"
        Me.btnAbove.Size = New System.Drawing.Size(69, 65)
        Me.btnAbove.TabIndex = 15
        Me.btnAbove.UseVisualStyleBackColor = True
        '
        'btnLeftUpper
        '
        Me.btnLeftUpper.Image = Global.M7000.My.Resources.Resources.motionLUP
        Me.btnLeftUpper.Location = New System.Drawing.Point(9, 74)
        Me.btnLeftUpper.Name = "btnLeftUpper"
        Me.btnLeftUpper.Size = New System.Drawing.Size(69, 65)
        Me.btnLeftUpper.TabIndex = 14
        Me.btnLeftUpper.UseVisualStyleBackColor = True
        '
        'ucMotionControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ucMotionControl"
        Me.Size = New System.Drawing.Size(517, 355)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRightUpper As System.Windows.Forms.Button
    Friend WithEvents btnAbove As System.Windows.Forms.Button
    Friend WithEvents btnLeftUpper As System.Windows.Forms.Button
    Friend WithEvents btnPositionReset As System.Windows.Forms.Button
    Friend WithEvents btnServoOff As System.Windows.Forms.Button
    Friend WithEvents btnServoOn As System.Windows.Forms.Button
    Friend WithEvents btnBottomRight As System.Windows.Forms.Button
    Friend WithEvents btnBottom As System.Windows.Forms.Button
    Friend WithEvents btnBottomLeft As System.Windows.Forms.Button
    Friend WithEvents btnRigth As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnLeft As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtPosition As System.Windows.Forms.TextBox
    Friend WithEvents btnXAxisMove As System.Windows.Forms.Button
    Friend WithEvents chkAxisZ As System.Windows.Forms.CheckBox
    Friend WithEvents rdoAbs As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMicroAdjsut As System.Windows.Forms.RadioButton
    Friend WithEvents btnSaveTarget As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPositionChange As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnYAxisMove As System.Windows.Forms.Button
    Friend WithEvents btnZAxisMove As System.Windows.Forms.Button

End Class
