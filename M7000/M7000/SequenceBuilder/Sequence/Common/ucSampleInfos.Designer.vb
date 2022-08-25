<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSampleInfos
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
        Me.gbComment = New System.Windows.Forms.GroupBox()
        Me.tbComment = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbSizeArea = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbSeqTitle = New System.Windows.Forms.TextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbFillFactor = New System.Windows.Forms.GroupBox()
        Me.tbFillFactor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbSampleColor = New System.Windows.Forms.ComboBox()
        Me.lblSampleColor = New System.Windows.Forms.Label()
        Me.gbSampleSize = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbSizeHight = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbSizeWidth = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSelSampleType = New System.Windows.Forms.ComboBox()
        Me.lblSampleType = New System.Windows.Forms.Label()
        Me.gbComment.SuspendLayout()
        Me.gbFillFactor.SuspendLayout()
        Me.gbSampleSize.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbComment
        '
        Me.gbComment.Controls.Add(Me.tbComment)
        Me.gbComment.Location = New System.Drawing.Point(6, 140)
        Me.gbComment.Name = "gbComment"
        Me.gbComment.Size = New System.Drawing.Size(400, 194)
        Me.gbComment.TabIndex = 7
        Me.gbComment.TabStop = False
        Me.gbComment.Text = "Comment"
        '
        'tbComment
        '
        Me.tbComment.Location = New System.Drawing.Point(5, 22)
        Me.tbComment.Multiline = True
        Me.tbComment.Name = "tbComment"
        Me.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbComment.Size = New System.Drawing.Size(385, 69)
        Me.tbComment.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(239, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 15)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "mm^2"
        Me.Label1.Visible = False
        '
        'tbSizeArea
        '
        Me.tbSizeArea.BackColor = System.Drawing.SystemColors.Control
        Me.tbSizeArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSizeArea.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSizeArea.Location = New System.Drawing.Point(175, 77)
        Me.tbSizeArea.Name = "tbSizeArea"
        Me.tbSizeArea.Size = New System.Drawing.Size(61, 21)
        Me.tbSizeArea.TabIndex = 30
        Me.tbSizeArea.Text = "0"
        Me.tbSizeArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbSizeArea.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(130, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Area"
        Me.Label4.Visible = False
        '
        'tbSeqTitle
        '
        Me.tbSeqTitle.BackColor = System.Drawing.SystemColors.Control
        Me.tbSeqTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSeqTitle.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSeqTitle.Location = New System.Drawing.Point(115, 13)
        Me.tbSeqTitle.Name = "tbSeqTitle"
        Me.tbSeqTitle.Size = New System.Drawing.Size(268, 21)
        Me.tbSeqTitle.TabIndex = 0
        Me.tbSeqTitle.Text = "Sequence"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(14, 16)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(91, 15)
        Me.lblTitle.TabIndex = 29
        Me.lblTitle.Text = "Sequence Title"
        '
        'gbFillFactor
        '
        Me.gbFillFactor.Controls.Add(Me.tbFillFactor)
        Me.gbFillFactor.Controls.Add(Me.Label7)
        Me.gbFillFactor.Location = New System.Drawing.Point(300, 75)
        Me.gbFillFactor.Name = "gbFillFactor"
        Me.gbFillFactor.Size = New System.Drawing.Size(104, 59)
        Me.gbFillFactor.TabIndex = 27
        Me.gbFillFactor.TabStop = False
        Me.gbFillFactor.Text = "Fill Factor"
        '
        'tbFillFactor
        '
        Me.tbFillFactor.BackColor = System.Drawing.SystemColors.Control
        Me.tbFillFactor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbFillFactor.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbFillFactor.Location = New System.Drawing.Point(14, 27)
        Me.tbFillFactor.Name = "tbFillFactor"
        Me.tbFillFactor.Size = New System.Drawing.Size(61, 21)
        Me.tbFillFactor.TabIndex = 6
        Me.tbFillFactor.Text = "0"
        Me.tbFillFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(80, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 15)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "%"
        '
        'cbSampleColor
        '
        Me.cbSampleColor.FormattingEnabled = True
        Me.cbSampleColor.Location = New System.Drawing.Point(288, 47)
        Me.cbSampleColor.Name = "cbSampleColor"
        Me.cbSampleColor.Size = New System.Drawing.Size(81, 23)
        Me.cbSampleColor.TabIndex = 2
        '
        'lblSampleColor
        '
        Me.lblSampleColor.AutoSize = True
        Me.lblSampleColor.Location = New System.Drawing.Point(202, 51)
        Me.lblSampleColor.Name = "lblSampleColor"
        Me.lblSampleColor.Size = New System.Drawing.Size(83, 15)
        Me.lblSampleColor.TabIndex = 25
        Me.lblSampleColor.Text = "Sample Color"
        '
        'gbSampleSize
        '
        Me.gbSampleSize.Controls.Add(Me.Label1)
        Me.gbSampleSize.Controls.Add(Me.Label3)
        Me.gbSampleSize.Controls.Add(Me.tbSizeHight)
        Me.gbSampleSize.Controls.Add(Me.tbSizeArea)
        Me.gbSampleSize.Controls.Add(Me.Label4)
        Me.gbSampleSize.Controls.Add(Me.Label9)
        Me.gbSampleSize.Controls.Add(Me.Label8)
        Me.gbSampleSize.Controls.Add(Me.tbSizeWidth)
        Me.gbSampleSize.Controls.Add(Me.Label2)
        Me.gbSampleSize.Location = New System.Drawing.Point(3, 75)
        Me.gbSampleSize.Name = "gbSampleSize"
        Me.gbSampleSize.Size = New System.Drawing.Size(291, 59)
        Me.gbSampleSize.TabIndex = 3
        Me.gbSampleSize.TabStop = False
        Me.gbSampleSize.Text = "Sample Size"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(259, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 15)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "mm"
        '
        'tbSizeHight
        '
        Me.tbSizeHight.BackColor = System.Drawing.SystemColors.Control
        Me.tbSizeHight.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSizeHight.Location = New System.Drawing.Point(193, 26)
        Me.tbSizeHight.Name = "tbSizeHight"
        Me.tbSizeHight.Size = New System.Drawing.Size(61, 21)
        Me.tbSizeHight.TabIndex = 5
        Me.tbSizeHight.Text = "0"
        Me.tbSizeHight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(145, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 15)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Height :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(115, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 15)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "mm"
        '
        'tbSizeWidth
        '
        Me.tbSizeWidth.BackColor = System.Drawing.SystemColors.Control
        Me.tbSizeWidth.ForeColor = System.Drawing.Color.OrangeRed
        Me.tbSizeWidth.Location = New System.Drawing.Point(49, 23)
        Me.tbSizeWidth.Name = "tbSizeWidth"
        Me.tbSizeWidth.Size = New System.Drawing.Size(61, 21)
        Me.tbSizeWidth.TabIndex = 4
        Me.tbSizeWidth.Text = "0"
        Me.tbSizeWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Width :"
        '
        'cbSelSampleType
        '
        Me.cbSelSampleType.Enabled = False
        Me.cbSelSampleType.FormattingEnabled = True
        Me.cbSelSampleType.Location = New System.Drawing.Point(115, 47)
        Me.cbSelSampleType.Name = "cbSelSampleType"
        Me.cbSelSampleType.Size = New System.Drawing.Size(82, 23)
        Me.cbSelSampleType.TabIndex = 1
        '
        'lblSampleType
        '
        Me.lblSampleType.AutoSize = True
        Me.lblSampleType.Location = New System.Drawing.Point(26, 50)
        Me.lblSampleType.Name = "lblSampleType"
        Me.lblSampleType.Size = New System.Drawing.Size(79, 15)
        Me.lblSampleType.TabIndex = 22
        Me.lblSampleType.Text = "Sample Type"
        '
        'ucSampleInfos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.gbComment)
        Me.Controls.Add(Me.gbSampleSize)
        Me.Controls.Add(Me.tbSeqTitle)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.gbFillFactor)
        Me.Controls.Add(Me.cbSampleColor)
        Me.Controls.Add(Me.lblSampleColor)
        Me.Controls.Add(Me.cbSelSampleType)
        Me.Controls.Add(Me.lblSampleType)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucSampleInfos"
        Me.Size = New System.Drawing.Size(406, 326)
        Me.gbComment.ResumeLayout(False)
        Me.gbComment.PerformLayout()
        Me.gbFillFactor.ResumeLayout(False)
        Me.gbFillFactor.PerformLayout()
        Me.gbSampleSize.ResumeLayout(False)
        Me.gbSampleSize.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbComment As System.Windows.Forms.GroupBox
    Friend WithEvents tbComment As System.Windows.Forms.TextBox
    Friend WithEvents tbSeqTitle As System.Windows.Forms.TextBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents gbFillFactor As System.Windows.Forms.GroupBox
    Friend WithEvents tbFillFactor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbSampleColor As System.Windows.Forms.ComboBox
    Friend WithEvents lblSampleColor As System.Windows.Forms.Label
    Friend WithEvents gbSampleSize As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbSizeHight As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbSizeWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbSelSampleType As System.Windows.Forms.ComboBox
    Friend WithEvents lblSampleType As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbSizeArea As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
