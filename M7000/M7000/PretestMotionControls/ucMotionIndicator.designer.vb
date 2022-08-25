<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMotionIndicator
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
        Me.lblOpticalHeaderPos = New System.Windows.Forms.Label()
        Me.lblChannel = New System.Windows.Forms.Label()
        Me.tbZPos = New System.Windows.Forms.TextBox()
        Me.tbYPos = New System.Windows.Forms.TextBox()
        Me.tbXPos = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbTheta1Pos = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbTheta2Pos = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbTheta3Pos = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbTheta4Pos = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblOpticalHeaderPos
        '
        Me.lblOpticalHeaderPos.BackColor = System.Drawing.SystemColors.ControlText
        Me.lblOpticalHeaderPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpticalHeaderPos.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblOpticalHeaderPos.ForeColor = System.Drawing.Color.Orange
        Me.lblOpticalHeaderPos.Location = New System.Drawing.Point(148, 27)
        Me.lblOpticalHeaderPos.Name = "lblOpticalHeaderPos"
        Me.lblOpticalHeaderPos.Size = New System.Drawing.Size(137, 24)
        Me.lblOpticalHeaderPos.TabIndex = 12
        Me.lblOpticalHeaderPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblChannel
        '
        Me.lblChannel.BackColor = System.Drawing.SystemColors.ControlText
        Me.lblChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChannel.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblChannel.ForeColor = System.Drawing.Color.Orange
        Me.lblChannel.Location = New System.Drawing.Point(7, 27)
        Me.lblChannel.Name = "lblChannel"
        Me.lblChannel.Size = New System.Drawing.Size(137, 24)
        Me.lblChannel.TabIndex = 11
        Me.lblChannel.Text = "CH"
        Me.lblChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbZPos
        '
        Me.tbZPos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbZPos.BackColor = System.Drawing.Color.White
        Me.tbZPos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbZPos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbZPos.Location = New System.Drawing.Point(206, 109)
        Me.tbZPos.Name = "tbZPos"
        Me.tbZPos.ReadOnly = True
        Me.tbZPos.Size = New System.Drawing.Size(75, 15)
        Me.tbZPos.TabIndex = 29
        '
        'tbYPos
        '
        Me.tbYPos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbYPos.BackColor = System.Drawing.Color.White
        Me.tbYPos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbYPos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbYPos.Location = New System.Drawing.Point(206, 87)
        Me.tbYPos.Name = "tbYPos"
        Me.tbYPos.ReadOnly = True
        Me.tbYPos.Size = New System.Drawing.Size(75, 15)
        Me.tbYPos.TabIndex = 28
        '
        'tbXPos
        '
        Me.tbXPos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbXPos.BackColor = System.Drawing.Color.White
        Me.tbXPos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbXPos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbXPos.Location = New System.Drawing.Point(206, 84)
        Me.tbXPos.Name = "tbXPos"
        Me.tbXPos.ReadOnly = True
        Me.tbXPos.Size = New System.Drawing.Size(75, 15)
        Me.tbXPos.TabIndex = 27
        Me.tbXPos.Visible = False
        '
        'Label16
        '
        Me.Label16.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(38, 109)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(171, 15)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Y Axis   . . . . . . . . . . . . . . . . . . . . "
        '
        'Label15
        '
        Me.Label15.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(38, 87)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(172, 15)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "X Axis   . . . . . . . . . . . . . . . . . . . . "
        '
        'Label14
        '
        Me.Label14.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(37, 86)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(172, 15)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "X Axis   . . . . . . . . . . . . . . . . . . . . "
        Me.Label14.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(-2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 22)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Indicator"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Orange
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(295, 22)
        Me.Label3.TabIndex = 14
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(7, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 21)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Target Position(mm)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbTheta1Pos
        '
        Me.tbTheta1Pos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTheta1Pos.BackColor = System.Drawing.Color.White
        Me.tbTheta1Pos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbTheta1Pos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTheta1Pos.Location = New System.Drawing.Point(206, 130)
        Me.tbTheta1Pos.Name = "tbTheta1Pos"
        Me.tbTheta1Pos.ReadOnly = True
        Me.tbTheta1Pos.Size = New System.Drawing.Size(75, 15)
        Me.tbTheta1Pos.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(203, 15)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Theta1 Axis   . . . . . . . . . . . . . . . . . . . . "
        '
        'tbTheta2Pos
        '
        Me.tbTheta2Pos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTheta2Pos.BackColor = System.Drawing.Color.White
        Me.tbTheta2Pos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbTheta2Pos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTheta2Pos.Location = New System.Drawing.Point(206, 151)
        Me.tbTheta2Pos.Name = "tbTheta2Pos"
        Me.tbTheta2Pos.ReadOnly = True
        Me.tbTheta2Pos.Size = New System.Drawing.Size(75, 15)
        Me.tbTheta2Pos.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(203, 15)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Theta2 Axis   . . . . . . . . . . . . . . . . . . . . "
        '
        'tbTheta3Pos
        '
        Me.tbTheta3Pos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTheta3Pos.BackColor = System.Drawing.Color.White
        Me.tbTheta3Pos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbTheta3Pos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTheta3Pos.Location = New System.Drawing.Point(206, 172)
        Me.tbTheta3Pos.Name = "tbTheta3Pos"
        Me.tbTheta3Pos.ReadOnly = True
        Me.tbTheta3Pos.Size = New System.Drawing.Size(75, 15)
        Me.tbTheta3Pos.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(203, 15)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Theta3 Axis   . . . . . . . . . . . . . . . . . . . . "
        '
        'tbTheta4Pos
        '
        Me.tbTheta4Pos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTheta4Pos.BackColor = System.Drawing.Color.White
        Me.tbTheta4Pos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbTheta4Pos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTheta4Pos.Location = New System.Drawing.Point(206, 193)
        Me.tbTheta4Pos.Name = "tbTheta4Pos"
        Me.tbTheta4Pos.ReadOnly = True
        Me.tbTheta4Pos.Size = New System.Drawing.Size(75, 15)
        Me.tbTheta4Pos.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 194)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(203, 15)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Theta4 Axis   . . . . . . . . . . . . . . . . . . . . "
        '
        'ucMotionIndicator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.tbTheta4Pos)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbTheta3Pos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbTheta2Pos)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbTheta1Pos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbZPos)
        Me.Controls.Add(Me.tbYPos)
        Me.Controls.Add(Me.lblOpticalHeaderPos)
        Me.Controls.Add(Me.tbXPos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblChannel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Name = "ucMotionIndicator"
        Me.Size = New System.Drawing.Size(295, 219)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblOpticalHeaderPos As System.Windows.Forms.Label
    Friend WithEvents lblChannel As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbYPos As System.Windows.Forms.TextBox
    Friend WithEvents tbXPos As System.Windows.Forms.TextBox
    Friend WithEvents tbZPos As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbTheta1Pos As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbTheta2Pos As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbTheta3Pos As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbTheta4Pos As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
