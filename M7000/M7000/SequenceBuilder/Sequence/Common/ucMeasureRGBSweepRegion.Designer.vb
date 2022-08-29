<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMeasureRGBSweepRegion
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
        Me.gbSweepCommon = New System.Windows.Forms.GroupBox()
        Me.rbSweep5 = New System.Windows.Forms.RadioButton()
        Me.rbSweep4 = New System.Windows.Forms.RadioButton()
        Me.rbSweep3 = New System.Windows.Forms.RadioButton()
        Me.rbSweep2 = New System.Windows.Forms.RadioButton()
        Me.rbSweep1 = New System.Windows.Forms.RadioButton()
        Me.cbUse5 = New System.Windows.Forms.CheckBox()
        Me.cbUse4 = New System.Windows.Forms.CheckBox()
        Me.cbUse3 = New System.Windows.Forms.CheckBox()
        Me.cbUse2 = New System.Windows.Forms.CheckBox()
        Me.cbUse1 = New System.Windows.Forms.CheckBox()
        Me.tbPoint = New System.Windows.Forms.TextBox()
        Me.tbStep = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblSweepPS = New System.Windows.Forms.Label()
        Me.lblCurrent = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblVoltage = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.tbC5 = New System.Windows.Forms.TextBox()
        Me.tbC4 = New System.Windows.Forms.TextBox()
        Me.tbC3 = New System.Windows.Forms.TextBox()
        Me.tbC2 = New System.Windows.Forms.TextBox()
        Me.tbC1 = New System.Windows.Forms.TextBox()
        Me.tbV5 = New System.Windows.Forms.TextBox()
        Me.tbV4 = New System.Windows.Forms.TextBox()
        Me.tbV3 = New System.Windows.Forms.TextBox()
        Me.tbV2 = New System.Windows.Forms.TextBox()
        Me.tbV1 = New System.Windows.Forms.TextBox()
        Me.tbStop = New System.Windows.Forms.TextBox()
        Me.tbStart = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.lblPoint = New System.Windows.Forms.Label()
        Me.lblStep = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ucListMeasSweep = New M7000.ucDispListView()
        Me.gbSweepCommon.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbSweepCommon
        '
        Me.gbSweepCommon.Controls.Add(Me.rbSweep5)
        Me.gbSweepCommon.Controls.Add(Me.rbSweep4)
        Me.gbSweepCommon.Controls.Add(Me.rbSweep3)
        Me.gbSweepCommon.Controls.Add(Me.rbSweep2)
        Me.gbSweepCommon.Controls.Add(Me.rbSweep1)
        Me.gbSweepCommon.Controls.Add(Me.cbUse5)
        Me.gbSweepCommon.Controls.Add(Me.cbUse4)
        Me.gbSweepCommon.Controls.Add(Me.cbUse3)
        Me.gbSweepCommon.Controls.Add(Me.cbUse2)
        Me.gbSweepCommon.Controls.Add(Me.cbUse1)
        Me.gbSweepCommon.Controls.Add(Me.tbPoint)
        Me.gbSweepCommon.Controls.Add(Me.ucListMeasSweep)
        Me.gbSweepCommon.Controls.Add(Me.tbStep)
        Me.gbSweepCommon.Controls.Add(Me.btnAdd)
        Me.gbSweepCommon.Controls.Add(Me.lblSweepPS)
        Me.gbSweepCommon.Controls.Add(Me.lblCurrent)
        Me.gbSweepCommon.Controls.Add(Me.Label2)
        Me.gbSweepCommon.Controls.Add(Me.Label1)
        Me.gbSweepCommon.Controls.Add(Me.lblVoltage)
        Me.gbSweepCommon.Controls.Add(Me.btnClear)
        Me.gbSweepCommon.Controls.Add(Me.btnDelete)
        Me.gbSweepCommon.Controls.Add(Me.tbC5)
        Me.gbSweepCommon.Controls.Add(Me.tbC4)
        Me.gbSweepCommon.Controls.Add(Me.tbC3)
        Me.gbSweepCommon.Controls.Add(Me.tbC2)
        Me.gbSweepCommon.Controls.Add(Me.tbC1)
        Me.gbSweepCommon.Controls.Add(Me.tbV5)
        Me.gbSweepCommon.Controls.Add(Me.tbV4)
        Me.gbSweepCommon.Controls.Add(Me.tbV3)
        Me.gbSweepCommon.Controls.Add(Me.tbV2)
        Me.gbSweepCommon.Controls.Add(Me.tbV1)
        Me.gbSweepCommon.Controls.Add(Me.tbStop)
        Me.gbSweepCommon.Controls.Add(Me.tbStart)
        Me.gbSweepCommon.Controls.Add(Me.Label4)
        Me.gbSweepCommon.Controls.Add(Me.lblStart)
        Me.gbSweepCommon.Controls.Add(Me.lblPoint)
        Me.gbSweepCommon.Controls.Add(Me.lblStep)
        Me.gbSweepCommon.Location = New System.Drawing.Point(5, 3)
        Me.gbSweepCommon.Name = "gbSweepCommon"
        Me.gbSweepCommon.Size = New System.Drawing.Size(264, 294)
        Me.gbSweepCommon.TabIndex = 50
        Me.gbSweepCommon.TabStop = False
        Me.gbSweepCommon.Tag = ""
        Me.gbSweepCommon.Text = "IVL RGB Sweep Region"
        '
        'rbSweep5
        '
        Me.rbSweep5.AutoSize = True
        Me.rbSweep5.Enabled = False
        Me.rbSweep5.Location = New System.Drawing.Point(213, 20)
        Me.rbSweep5.Margin = New System.Windows.Forms.Padding(2)
        Me.rbSweep5.Name = "rbSweep5"
        Me.rbSweep5.Size = New System.Drawing.Size(14, 13)
        Me.rbSweep5.TabIndex = 39
        Me.rbSweep5.UseVisualStyleBackColor = True
        '
        'rbSweep4
        '
        Me.rbSweep4.AutoSize = True
        Me.rbSweep4.Enabled = False
        Me.rbSweep4.Location = New System.Drawing.Point(175, 20)
        Me.rbSweep4.Margin = New System.Windows.Forms.Padding(2)
        Me.rbSweep4.Name = "rbSweep4"
        Me.rbSweep4.Size = New System.Drawing.Size(14, 13)
        Me.rbSweep4.TabIndex = 39
        Me.rbSweep4.UseVisualStyleBackColor = True
        '
        'rbSweep3
        '
        Me.rbSweep3.AutoSize = True
        Me.rbSweep3.Enabled = False
        Me.rbSweep3.Location = New System.Drawing.Point(135, 20)
        Me.rbSweep3.Margin = New System.Windows.Forms.Padding(2)
        Me.rbSweep3.Name = "rbSweep3"
        Me.rbSweep3.Size = New System.Drawing.Size(14, 13)
        Me.rbSweep3.TabIndex = 39
        Me.rbSweep3.UseVisualStyleBackColor = True
        '
        'rbSweep2
        '
        Me.rbSweep2.AutoSize = True
        Me.rbSweep2.Enabled = False
        Me.rbSweep2.Location = New System.Drawing.Point(95, 20)
        Me.rbSweep2.Margin = New System.Windows.Forms.Padding(2)
        Me.rbSweep2.Name = "rbSweep2"
        Me.rbSweep2.Size = New System.Drawing.Size(14, 13)
        Me.rbSweep2.TabIndex = 39
        Me.rbSweep2.UseVisualStyleBackColor = True
        '
        'rbSweep1
        '
        Me.rbSweep1.AutoSize = True
        Me.rbSweep1.Enabled = False
        Me.rbSweep1.Location = New System.Drawing.Point(51, 20)
        Me.rbSweep1.Margin = New System.Windows.Forms.Padding(2)
        Me.rbSweep1.Name = "rbSweep1"
        Me.rbSweep1.Size = New System.Drawing.Size(14, 13)
        Me.rbSweep1.TabIndex = 39
        Me.rbSweep1.UseVisualStyleBackColor = True
        '
        'cbUse5
        '
        Me.cbUse5.AutoSize = True
        Me.cbUse5.Location = New System.Drawing.Point(213, 36)
        Me.cbUse5.Margin = New System.Windows.Forms.Padding(2)
        Me.cbUse5.Name = "cbUse5"
        Me.cbUse5.Size = New System.Drawing.Size(41, 19)
        Me.cbUse5.TabIndex = 38
        Me.cbUse5.Text = "Db"
        Me.cbUse5.UseVisualStyleBackColor = True
        '
        'cbUse4
        '
        Me.cbUse4.AutoSize = True
        Me.cbUse4.Location = New System.Drawing.Point(175, 36)
        Me.cbUse4.Margin = New System.Windows.Forms.Padding(2)
        Me.cbUse4.Name = "cbUse4"
        Me.cbUse4.Size = New System.Drawing.Size(41, 19)
        Me.cbUse4.TabIndex = 38
        Me.cbUse4.Text = "Dg"
        Me.cbUse4.UseVisualStyleBackColor = True
        '
        'cbUse3
        '
        Me.cbUse3.AutoSize = True
        Me.cbUse3.Location = New System.Drawing.Point(137, 36)
        Me.cbUse3.Margin = New System.Windows.Forms.Padding(2)
        Me.cbUse3.Name = "cbUse3"
        Me.cbUse3.Size = New System.Drawing.Size(39, 19)
        Me.cbUse3.TabIndex = 38
        Me.cbUse3.Text = "Dr"
        Me.cbUse3.UseVisualStyleBackColor = True
        '
        'cbUse2
        '
        Me.cbUse2.AutoSize = True
        Me.cbUse2.Location = New System.Drawing.Point(95, 36)
        Me.cbUse2.Margin = New System.Windows.Forms.Padding(2)
        Me.cbUse2.Name = "cbUse2"
        Me.cbUse2.Size = New System.Drawing.Size(48, 19)
        Me.cbUse2.TabIndex = 38
        Me.cbUse2.Text = "Vss"
        Me.cbUse2.UseVisualStyleBackColor = True
        '
        'cbUse1
        '
        Me.cbUse1.AutoSize = True
        Me.cbUse1.Location = New System.Drawing.Point(51, 36)
        Me.cbUse1.Margin = New System.Windows.Forms.Padding(2)
        Me.cbUse1.Name = "cbUse1"
        Me.cbUse1.Size = New System.Drawing.Size(48, 19)
        Me.cbUse1.TabIndex = 38
        Me.cbUse1.Text = "Vdd"
        Me.cbUse1.UseVisualStyleBackColor = True
        '
        'tbPoint
        '
        Me.tbPoint.BackColor = System.Drawing.SystemColors.Control
        Me.tbPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPoint.Enabled = False
        Me.tbPoint.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbPoint.Location = New System.Drawing.Point(201, 118)
        Me.tbPoint.Name = "tbPoint"
        Me.tbPoint.Size = New System.Drawing.Size(53, 21)
        Me.tbPoint.TabIndex = 3
        Me.tbPoint.Text = "0"
        Me.tbPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbStep
        '
        Me.tbStep.BackColor = System.Drawing.SystemColors.Control
        Me.tbStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbStep.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbStep.Location = New System.Drawing.Point(201, 100)
        Me.tbStep.Name = "tbStep"
        Me.tbStep.Size = New System.Drawing.Size(53, 21)
        Me.tbStep.TabIndex = 2
        Me.tbStep.Text = "20"
        Me.tbStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.Silver
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(4, 145)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(68, 23)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'lblSweepPS
        '
        Me.lblSweepPS.AutoSize = True
        Me.lblSweepPS.Location = New System.Drawing.Point(3, 102)
        Me.lblSweepPS.Name = "lblSweepPS"
        Me.lblSweepPS.Size = New System.Drawing.Size(57, 15)
        Me.lblSweepPS.TabIndex = 27
        Me.lblSweepPS.Text = "V Sweep"
        '
        'lblCurrent
        '
        Me.lblCurrent.AutoSize = True
        Me.lblCurrent.Location = New System.Drawing.Point(3, 77)
        Me.lblCurrent.Name = "lblCurrent"
        Me.lblCurrent.Size = New System.Drawing.Size(50, 15)
        Me.lblCurrent.TabIndex = 27
        Me.lblCurrent.Text = "Current"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Sweep"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 15)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Use"
        '
        'lblVoltage
        '
        Me.lblVoltage.AutoSize = True
        Me.lblVoltage.Location = New System.Drawing.Point(3, 56)
        Me.lblVoltage.Name = "lblVoltage"
        Me.lblVoltage.Size = New System.Drawing.Size(49, 15)
        Me.lblVoltage.TabIndex = 27
        Me.lblVoltage.Text = "Voltage"
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.Silver
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Location = New System.Drawing.Point(168, 145)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(68, 23)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.Silver
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(86, 145)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(68, 23)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "DEL"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'tbC5
        '
        Me.tbC5.BackColor = System.Drawing.SystemColors.Control
        Me.tbC5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbC5.Enabled = False
        Me.tbC5.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbC5.Location = New System.Drawing.Point(213, 73)
        Me.tbC5.Name = "tbC5"
        Me.tbC5.Size = New System.Drawing.Size(41, 21)
        Me.tbC5.TabIndex = 1
        Me.tbC5.Text = "0"
        Me.tbC5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbC4
        '
        Me.tbC4.BackColor = System.Drawing.SystemColors.Control
        Me.tbC4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbC4.Enabled = False
        Me.tbC4.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbC4.Location = New System.Drawing.Point(175, 73)
        Me.tbC4.Name = "tbC4"
        Me.tbC4.Size = New System.Drawing.Size(41, 21)
        Me.tbC4.TabIndex = 1
        Me.tbC4.Text = "0"
        Me.tbC4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbC3
        '
        Me.tbC3.BackColor = System.Drawing.SystemColors.Control
        Me.tbC3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbC3.Enabled = False
        Me.tbC3.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbC3.Location = New System.Drawing.Point(135, 73)
        Me.tbC3.Name = "tbC3"
        Me.tbC3.Size = New System.Drawing.Size(41, 21)
        Me.tbC3.TabIndex = 1
        Me.tbC3.Text = "0"
        Me.tbC3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbC2
        '
        Me.tbC2.BackColor = System.Drawing.SystemColors.Control
        Me.tbC2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbC2.Enabled = False
        Me.tbC2.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbC2.Location = New System.Drawing.Point(95, 73)
        Me.tbC2.Name = "tbC2"
        Me.tbC2.Size = New System.Drawing.Size(41, 21)
        Me.tbC2.TabIndex = 1
        Me.tbC2.Text = "10"
        Me.tbC2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbC1
        '
        Me.tbC1.BackColor = System.Drawing.SystemColors.Control
        Me.tbC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbC1.Enabled = False
        Me.tbC1.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbC1.Location = New System.Drawing.Point(55, 73)
        Me.tbC1.Name = "tbC1"
        Me.tbC1.Size = New System.Drawing.Size(41, 21)
        Me.tbC1.TabIndex = 1
        Me.tbC1.Text = "10"
        Me.tbC1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbV5
        '
        Me.tbV5.BackColor = System.Drawing.SystemColors.Control
        Me.tbV5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbV5.Enabled = False
        Me.tbV5.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbV5.Location = New System.Drawing.Point(213, 55)
        Me.tbV5.Name = "tbV5"
        Me.tbV5.Size = New System.Drawing.Size(41, 21)
        Me.tbV5.TabIndex = 1
        Me.tbV5.Text = "0"
        Me.tbV5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbV4
        '
        Me.tbV4.BackColor = System.Drawing.SystemColors.Control
        Me.tbV4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbV4.Enabled = False
        Me.tbV4.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbV4.Location = New System.Drawing.Point(175, 55)
        Me.tbV4.Name = "tbV4"
        Me.tbV4.Size = New System.Drawing.Size(41, 21)
        Me.tbV4.TabIndex = 1
        Me.tbV4.Text = "0"
        Me.tbV4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbV3
        '
        Me.tbV3.BackColor = System.Drawing.SystemColors.Control
        Me.tbV3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbV3.Enabled = False
        Me.tbV3.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbV3.Location = New System.Drawing.Point(135, 55)
        Me.tbV3.Name = "tbV3"
        Me.tbV3.Size = New System.Drawing.Size(41, 21)
        Me.tbV3.TabIndex = 1
        Me.tbV3.Text = "0"
        Me.tbV3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbV2
        '
        Me.tbV2.BackColor = System.Drawing.SystemColors.Control
        Me.tbV2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbV2.Enabled = False
        Me.tbV2.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbV2.Location = New System.Drawing.Point(95, 55)
        Me.tbV2.Name = "tbV2"
        Me.tbV2.Size = New System.Drawing.Size(41, 21)
        Me.tbV2.TabIndex = 1
        Me.tbV2.Text = "10"
        Me.tbV2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbV1
        '
        Me.tbV1.BackColor = System.Drawing.SystemColors.Control
        Me.tbV1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbV1.Enabled = False
        Me.tbV1.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbV1.Location = New System.Drawing.Point(55, 55)
        Me.tbV1.Name = "tbV1"
        Me.tbV1.Size = New System.Drawing.Size(41, 21)
        Me.tbV1.TabIndex = 1
        Me.tbV1.Text = "10"
        Me.tbV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbStop
        '
        Me.tbStop.BackColor = System.Drawing.SystemColors.Control
        Me.tbStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbStop.Enabled = False
        Me.tbStop.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbStop.Location = New System.Drawing.Point(103, 118)
        Me.tbStop.Name = "tbStop"
        Me.tbStop.Size = New System.Drawing.Size(53, 21)
        Me.tbStop.TabIndex = 0
        Me.tbStop.Text = "0"
        Me.tbStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbStart
        '
        Me.tbStart.BackColor = System.Drawing.SystemColors.Control
        Me.tbStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbStart.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbStart.Location = New System.Drawing.Point(103, 100)
        Me.tbStart.Name = "tbStart"
        Me.tbStart.Size = New System.Drawing.Size(53, 21)
        Me.tbStart.TabIndex = 0
        Me.tbStart.Text = "-10"
        Me.tbStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(67, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 15)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Stop:"
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(67, 102)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(38, 15)
        Me.lblStart.TabIndex = 24
        Me.lblStart.Text = "Start:"
        '
        'lblPoint
        '
        Me.lblPoint.AutoSize = True
        Me.lblPoint.Location = New System.Drawing.Point(161, 120)
        Me.lblPoint.Name = "lblPoint"
        Me.lblPoint.Size = New System.Drawing.Size(39, 15)
        Me.lblPoint.TabIndex = 37
        Me.lblPoint.Text = "Point:"
        '
        'lblStep
        '
        Me.lblStep.AutoSize = True
        Me.lblStep.Location = New System.Drawing.Point(163, 102)
        Me.lblStep.Name = "lblStep"
        Me.lblStep.Size = New System.Drawing.Size(36, 15)
        Me.lblStep.TabIndex = 34
        Me.lblStep.Text = "Step:"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Silver
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(212, 148)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Update"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'ucListMeasSweep
        '
        Me.ucListMeasSweep.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucListMeasSweep.ColHeader = New String() {"No.", "SweepType", "Start", "Stop", "Step", "Point", "else"}
        Me.ucListMeasSweep.ColHeaderWidthRatio = "10,20,15,15,15,15,20"
        Me.ucListMeasSweep.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucListMeasSweep.FullRawSelection = True
        Me.ucListMeasSweep.HideSelection = False
        Me.ucListMeasSweep.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ucListMeasSweep.LabelEdit = True
        Me.ucListMeasSweep.LabelWrap = True
        Me.ucListMeasSweep.Location = New System.Drawing.Point(6, 171)
        Me.ucListMeasSweep.Margin = New System.Windows.Forms.Padding(4)
        Me.ucListMeasSweep.Name = "ucListMeasSweep"
        Me.ucListMeasSweep.Size = New System.Drawing.Size(246, 116)
        Me.ucListMeasSweep.TabIndex = 25
        Me.ucListMeasSweep.UseCheckBoxex = False
        '
        'ucMeasureRGBSweepRegion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.Controls.Add(Me.gbSweepCommon)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximumSize = New System.Drawing.Size(289, 300)
        Me.MinimumSize = New System.Drawing.Size(261, 237)
        Me.Name = "ucMeasureRGBSweepRegion"
        Me.Size = New System.Drawing.Size(272, 300)
        Me.gbSweepCommon.ResumeLayout(False)
        Me.gbSweepCommon.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbSweepCommon As System.Windows.Forms.GroupBox
    Friend WithEvents ucListMeasSweep As M7000.ucDispListView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents tbStart As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblPoint As System.Windows.Forms.Label
    Friend WithEvents tbPoint As System.Windows.Forms.TextBox
    Friend WithEvents lblStep As System.Windows.Forms.Label
    Friend WithEvents tbStep As System.Windows.Forms.TextBox
    Friend WithEvents lblVoltage As System.Windows.Forms.Label
    Friend WithEvents tbV1 As System.Windows.Forms.TextBox
    Friend WithEvents cbUse1 As CheckBox
    Friend WithEvents rbSweep1 As RadioButton
    Friend WithEvents cbUse5 As CheckBox
    Friend WithEvents cbUse4 As CheckBox
    Friend WithEvents cbUse3 As CheckBox
    Friend WithEvents cbUse2 As CheckBox
    Friend WithEvents lblCurrent As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents rbSweep5 As RadioButton
    Friend WithEvents rbSweep4 As RadioButton
    Friend WithEvents rbSweep3 As RadioButton
    Friend WithEvents rbSweep2 As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents tbC5 As TextBox
    Friend WithEvents tbC4 As TextBox
    Friend WithEvents tbC3 As TextBox
    Friend WithEvents tbC2 As TextBox
    Friend WithEvents tbC1 As TextBox
    Friend WithEvents tbV5 As TextBox
    Friend WithEvents tbV4 As TextBox
    Friend WithEvents tbV3 As TextBox
    Friend WithEvents tbV2 As TextBox
    Friend WithEvents lblSweepPS As Label
    Friend WithEvents tbStop As TextBox
    Friend WithEvents Label4 As Label
End Class
