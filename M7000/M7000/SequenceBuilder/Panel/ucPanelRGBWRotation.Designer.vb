<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPanelRGBWRotation
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
        Me.gbRGBSignal = New System.Windows.Forms.GroupBox()
        Me.rdoWhite = New System.Windows.Forms.RadioButton()
        Me.rdoBlue = New System.Windows.Forms.RadioButton()
        Me.rdoGreen = New System.Windows.Forms.RadioButton()
        Me.rdoRed = New System.Windows.Forms.RadioButton()
        Me.gbRGBValue = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbRGBDelay = New System.Windows.Forms.TextBox()
        Me.tbOffBias = New System.Windows.Forms.TextBox()
        Me.lblStep = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbRGBValue = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.chkRotationUse = New System.Windows.Forms.CheckBox()
        Me.grbRotationSettings = New System.Windows.Forms.GroupBox()
        Me.ucListRGB = New M7000.ucDispListView()
        Me.gbRGBSignal.SuspendLayout()
        Me.gbRGBValue.SuspendLayout()
        Me.grbRotationSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbRGBSignal
        '
        Me.gbRGBSignal.Controls.Add(Me.rdoWhite)
        Me.gbRGBSignal.Controls.Add(Me.rdoBlue)
        Me.gbRGBSignal.Controls.Add(Me.rdoGreen)
        Me.gbRGBSignal.Controls.Add(Me.rdoRed)
        Me.gbRGBSignal.Location = New System.Drawing.Point(12, 40)
        Me.gbRGBSignal.Name = "gbRGBSignal"
        Me.gbRGBSignal.Size = New System.Drawing.Size(380, 53)
        Me.gbRGBSignal.TabIndex = 1
        Me.gbRGBSignal.TabStop = False
        Me.gbRGBSignal.Text = "RGBW Select"
        '
        'rdoWhite
        '
        Me.rdoWhite.AutoSize = True
        Me.rdoWhite.Location = New System.Drawing.Point(295, 21)
        Me.rdoWhite.Name = "rdoWhite"
        Me.rdoWhite.Size = New System.Drawing.Size(53, 16)
        Me.rdoWhite.TabIndex = 38
        Me.rdoWhite.Text = "White"
        Me.rdoWhite.UseVisualStyleBackColor = True
        '
        'rdoBlue
        '
        Me.rdoBlue.AutoSize = True
        Me.rdoBlue.Location = New System.Drawing.Point(203, 21)
        Me.rdoBlue.Name = "rdoBlue"
        Me.rdoBlue.Size = New System.Drawing.Size(48, 16)
        Me.rdoBlue.TabIndex = 38
        Me.rdoBlue.Text = "Blue"
        Me.rdoBlue.UseVisualStyleBackColor = True
        '
        'rdoGreen
        '
        Me.rdoGreen.AutoSize = True
        Me.rdoGreen.Location = New System.Drawing.Point(107, 21)
        Me.rdoGreen.Name = "rdoGreen"
        Me.rdoGreen.Size = New System.Drawing.Size(57, 16)
        Me.rdoGreen.TabIndex = 38
        Me.rdoGreen.Text = "Green"
        Me.rdoGreen.UseVisualStyleBackColor = True
        '
        'rdoRed
        '
        Me.rdoRed.AutoSize = True
        Me.rdoRed.Checked = True
        Me.rdoRed.Location = New System.Drawing.Point(21, 21)
        Me.rdoRed.Name = "rdoRed"
        Me.rdoRed.Size = New System.Drawing.Size(45, 16)
        Me.rdoRed.TabIndex = 37
        Me.rdoRed.TabStop = True
        Me.rdoRed.Text = "Red"
        Me.rdoRed.UseVisualStyleBackColor = True
        '
        'gbRGBValue
        '
        Me.gbRGBValue.Controls.Add(Me.Label3)
        Me.gbRGBValue.Controls.Add(Me.Label4)
        Me.gbRGBValue.Controls.Add(Me.tbRGBDelay)
        Me.gbRGBValue.Controls.Add(Me.tbOffBias)
        Me.gbRGBValue.Controls.Add(Me.lblStep)
        Me.gbRGBValue.Controls.Add(Me.Label1)
        Me.gbRGBValue.Controls.Add(Me.Label2)
        Me.gbRGBValue.Controls.Add(Me.Label5)
        Me.gbRGBValue.Controls.Add(Me.tbRGBValue)
        Me.gbRGBValue.Location = New System.Drawing.Point(12, 104)
        Me.gbRGBValue.Name = "gbRGBValue"
        Me.gbRGBValue.Size = New System.Drawing.Size(380, 70)
        Me.gbRGBValue.TabIndex = 37
        Me.gbRGBValue.TabStop = False
        Me.gbRGBValue.Text = "Value And Delay"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 12)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Off Bias :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(150, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 12)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "V"
        '
        'tbRGBDelay
        '
        Me.tbRGBDelay.Location = New System.Drawing.Point(250, 19)
        Me.tbRGBDelay.Name = "tbRGBDelay"
        Me.tbRGBDelay.Size = New System.Drawing.Size(58, 21)
        Me.tbRGBDelay.TabIndex = 35
        Me.tbRGBDelay.Text = "1"
        Me.tbRGBDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbRGBDelay.Visible = False
        '
        'tbOffBias
        '
        Me.tbOffBias.Location = New System.Drawing.Point(72, 43)
        Me.tbOffBias.Name = "tbOffBias"
        Me.tbOffBias.Size = New System.Drawing.Size(72, 21)
        Me.tbOffBias.TabIndex = 45
        Me.tbOffBias.Text = "0"
        Me.tbOffBias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStep
        '
        Me.lblStep.AutoSize = True
        Me.lblStep.Location = New System.Drawing.Point(199, 22)
        Me.lblStep.Name = "lblStep"
        Me.lblStep.Size = New System.Drawing.Size(45, 12)
        Me.lblStep.TabIndex = 34
        Me.lblStep.Text = "Delay :"
        Me.lblStep.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 12)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "On Bias :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(150, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 12)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "V"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(314, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 12)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Sec"
        Me.Label5.Visible = False
        '
        'tbRGBValue
        '
        Me.tbRGBValue.Location = New System.Drawing.Point(72, 19)
        Me.tbRGBValue.Name = "tbRGBValue"
        Me.tbRGBValue.Size = New System.Drawing.Size(72, 21)
        Me.tbRGBValue.TabIndex = 39
        Me.tbRGBValue.Text = "0"
        Me.tbRGBValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(416, 48)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(142, 30)
        Me.btnAdd.TabIndex = 26
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(416, 121)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(142, 30)
        Me.btnClear.TabIndex = 27
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(416, 83)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(142, 30)
        Me.btnDelete.TabIndex = 28
        Me.btnDelete.Text = "DEL"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'chkRotationUse
        '
        Me.chkRotationUse.AutoSize = True
        Me.chkRotationUse.Location = New System.Drawing.Point(12, 18)
        Me.chkRotationUse.Name = "chkRotationUse"
        Me.chkRotationUse.Size = New System.Drawing.Size(134, 16)
        Me.chkRotationUse.TabIndex = 38
        Me.chkRotationUse.Text = "Use RGBW Rotation"
        Me.chkRotationUse.UseVisualStyleBackColor = True
        '
        'grbRotationSettings
        '
        Me.grbRotationSettings.Controls.Add(Me.chkRotationUse)
        Me.grbRotationSettings.Controls.Add(Me.btnClear)
        Me.grbRotationSettings.Controls.Add(Me.gbRGBValue)
        Me.grbRotationSettings.Controls.Add(Me.btnDelete)
        Me.grbRotationSettings.Controls.Add(Me.gbRGBSignal)
        Me.grbRotationSettings.Controls.Add(Me.btnAdd)
        Me.grbRotationSettings.Controls.Add(Me.ucListRGB)
        Me.grbRotationSettings.Enabled = False
        Me.grbRotationSettings.Location = New System.Drawing.Point(3, 3)
        Me.grbRotationSettings.Name = "grbRotationSettings"
        Me.grbRotationSettings.Size = New System.Drawing.Size(570, 334)
        Me.grbRotationSettings.TabIndex = 9
        Me.grbRotationSettings.TabStop = False
        Me.grbRotationSettings.Text = "RGBW Rotation Settings"
        '
        'ucListRGB
        '
        Me.ucListRGB.AutoScroll = True
        Me.ucListRGB.ColHeader = New String() {"No.", "Display Name", "Delay(Sec)", "Red(V)", "Green(V)", "Blue(V)"}
        Me.ucListRGB.ColHeaderWidthRatio = "10,24,20,17,17,17"
        Me.ucListRGB.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ucListRGB.FullRawSelection = True
        Me.ucListRGB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ucListRGB.Location = New System.Drawing.Point(12, 180)
        Me.ucListRGB.Name = "ucListRGB"
        Me.ucListRGB.Size = New System.Drawing.Size(547, 138)
        Me.ucListRGB.TabIndex = 25
        Me.ucListRGB.UseCheckBoxex = False
        '
        'ucPanelRGBWRotation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.grbRotationSettings)
        Me.Name = "ucPanelRGBWRotation"
        Me.Size = New System.Drawing.Size(652, 360)
        Me.gbRGBSignal.ResumeLayout(False)
        Me.gbRGBSignal.PerformLayout()
        Me.gbRGBValue.ResumeLayout(False)
        Me.gbRGBValue.PerformLayout()
        Me.grbRotationSettings.ResumeLayout(False)
        Me.grbRotationSettings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbRGBSignal As System.Windows.Forms.GroupBox
    Friend WithEvents rdoWhite As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBlue As System.Windows.Forms.RadioButton
    Friend WithEvents rdoGreen As System.Windows.Forms.RadioButton
    Friend WithEvents rdoRed As System.Windows.Forms.RadioButton
    Friend WithEvents gbRGBValue As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblStep As System.Windows.Forms.Label
    Friend WithEvents tbRGBValue As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbRGBDelay As System.Windows.Forms.TextBox
    Friend WithEvents ucListRGB As M7000.ucDispListView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents chkRotationUse As System.Windows.Forms.CheckBox
    Friend WithEvents grbRotationSettings As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbOffBias As System.Windows.Forms.TextBox

End Class
