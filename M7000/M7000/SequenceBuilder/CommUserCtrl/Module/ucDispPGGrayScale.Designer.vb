<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispPGGrayScale
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
        Me.txtBlue = New System.Windows.Forms.TextBox()
        Me.txtGreen = New System.Windows.Forms.TextBox()
        Me.txtRed = New System.Windows.Forms.TextBox()
        Me.txtWhite = New System.Windows.Forms.TextBox()
        Me.txtColorSet = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.trackbarB = New System.Windows.Forms.TrackBar()
        Me.trackbarG = New System.Windows.Forms.TrackBar()
        Me.trackbarR = New System.Windows.Forms.TrackBar()
        Me.trackbarW = New System.Windows.Forms.TrackBar()
        Me.GroupBox1.SuspendLayout()
        CType(Me.trackbarB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackbarG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackbarR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackbarW, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtBlue)
        Me.GroupBox1.Controls.Add(Me.txtGreen)
        Me.GroupBox1.Controls.Add(Me.txtRed)
        Me.GroupBox1.Controls.Add(Me.txtWhite)
        Me.GroupBox1.Controls.Add(Me.txtColorSet)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.trackbarB)
        Me.GroupBox1.Controls.Add(Me.trackbarG)
        Me.GroupBox1.Controls.Add(Me.trackbarR)
        Me.GroupBox1.Controls.Add(Me.trackbarW)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(454, 238)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Gray Scale"
        '
        'txtBlue
        '
        Me.txtBlue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBlue.Location = New System.Drawing.Point(370, 124)
        Me.txtBlue.Name = "txtBlue"
        Me.txtBlue.Size = New System.Drawing.Size(74, 21)
        Me.txtBlue.TabIndex = 12
        '
        'txtGreen
        '
        Me.txtGreen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGreen.Location = New System.Drawing.Point(370, 91)
        Me.txtGreen.Name = "txtGreen"
        Me.txtGreen.Size = New System.Drawing.Size(74, 21)
        Me.txtGreen.TabIndex = 11
        '
        'txtRed
        '
        Me.txtRed.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRed.Location = New System.Drawing.Point(370, 63)
        Me.txtRed.Name = "txtRed"
        Me.txtRed.Size = New System.Drawing.Size(74, 21)
        Me.txtRed.TabIndex = 10
        '
        'txtWhite
        '
        Me.txtWhite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWhite.Location = New System.Drawing.Point(370, 32)
        Me.txtWhite.Name = "txtWhite"
        Me.txtWhite.Size = New System.Drawing.Size(74, 21)
        Me.txtWhite.TabIndex = 9
        '
        'txtColorSet
        '
        Me.txtColorSet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtColorSet.Location = New System.Drawing.Point(16, 161)
        Me.txtColorSet.Multiline = True
        Me.txtColorSet.Name = "txtColorSet"
        Me.txtColorSet.Size = New System.Drawing.Size(427, 63)
        Me.txtColorSet.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "B"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "G"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "R"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "W"
        '
        'trackbarB
        '
        Me.trackbarB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trackbarB.Location = New System.Drawing.Point(36, 127)
        Me.trackbarB.Name = "trackbarB"
        Me.trackbarB.Size = New System.Drawing.Size(327, 45)
        Me.trackbarB.TabIndex = 3
        Me.trackbarB.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'trackbarG
        '
        Me.trackbarG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trackbarG.Location = New System.Drawing.Point(36, 94)
        Me.trackbarG.Name = "trackbarG"
        Me.trackbarG.Size = New System.Drawing.Size(327, 45)
        Me.trackbarG.TabIndex = 2
        Me.trackbarG.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'trackbarR
        '
        Me.trackbarR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trackbarR.Location = New System.Drawing.Point(36, 63)
        Me.trackbarR.Name = "trackbarR"
        Me.trackbarR.Size = New System.Drawing.Size(327, 45)
        Me.trackbarR.TabIndex = 1
        Me.trackbarR.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'trackbarW
        '
        Me.trackbarW.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trackbarW.Location = New System.Drawing.Point(36, 32)
        Me.trackbarW.Name = "trackbarW"
        Me.trackbarW.Size = New System.Drawing.Size(327, 45)
        Me.trackbarW.TabIndex = 0
        Me.trackbarW.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'ucDispPGGrayScale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ucDispPGGrayScale"
        Me.Size = New System.Drawing.Size(461, 247)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.trackbarB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackbarG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackbarR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackbarW, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents trackbarB As System.Windows.Forms.TrackBar
    Friend WithEvents trackbarG As System.Windows.Forms.TrackBar
    Friend WithEvents trackbarR As System.Windows.Forms.TrackBar
    Friend WithEvents trackbarW As System.Windows.Forms.TrackBar
    Friend WithEvents txtBlue As System.Windows.Forms.TextBox
    Friend WithEvents txtGreen As System.Windows.Forms.TextBox
    Friend WithEvents txtRed As System.Windows.Forms.TextBox
    Friend WithEvents txtWhite As System.Windows.Forms.TextBox
    Friend WithEvents txtColorSet As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
