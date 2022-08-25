<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfigRs232
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
        Me.gbTitle = New System.Windows.Forms.GroupBox()
        Me.cbSendTerminator = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbRcvTerminator = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbComports = New System.Windows.Forms.ComboBox()
        Me.cbDataLen = New System.Windows.Forms.ComboBox()
        Me.cbStop = New System.Windows.Forms.ComboBox()
        Me.cbParity = New System.Windows.Forms.ComboBox()
        Me.cbBaudRate = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTitle
        '
        Me.gbTitle.AutoSize = True
        Me.gbTitle.Controls.Add(Me.cbSendTerminator)
        Me.gbTitle.Controls.Add(Me.Label7)
        Me.gbTitle.Controls.Add(Me.cbRcvTerminator)
        Me.gbTitle.Controls.Add(Me.Label8)
        Me.gbTitle.Controls.Add(Me.cbComports)
        Me.gbTitle.Controls.Add(Me.cbDataLen)
        Me.gbTitle.Controls.Add(Me.cbStop)
        Me.gbTitle.Controls.Add(Me.cbParity)
        Me.gbTitle.Controls.Add(Me.cbBaudRate)
        Me.gbTitle.Controls.Add(Me.Label5)
        Me.gbTitle.Controls.Add(Me.Label4)
        Me.gbTitle.Controls.Add(Me.Label3)
        Me.gbTitle.Controls.Add(Me.Label2)
        Me.gbTitle.Controls.Add(Me.Label1)
        Me.gbTitle.Location = New System.Drawing.Point(13, 3)
        Me.gbTitle.Name = "gbTitle"
        Me.gbTitle.Size = New System.Drawing.Size(243, 215)
        Me.gbTitle.TabIndex = 0
        Me.gbTitle.TabStop = False
        Me.gbTitle.Text = "RS232"
        '
        'cbSendTerminator
        '
        Me.cbSendTerminator.FormattingEnabled = True
        Me.cbSendTerminator.Location = New System.Drawing.Point(140, 175)
        Me.cbSendTerminator.Name = "cbSendTerminator"
        Me.cbSendTerminator.Size = New System.Drawing.Size(91, 20)
        Me.cbSendTerminator.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 12)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Send Terminator :"
        '
        'cbRcvTerminator
        '
        Me.cbRcvTerminator.FormattingEnabled = True
        Me.cbRcvTerminator.Location = New System.Drawing.Point(140, 149)
        Me.cbRcvTerminator.Name = "cbRcvTerminator"
        Me.cbRcvTerminator.Size = New System.Drawing.Size(91, 20)
        Me.cbRcvTerminator.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 12)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Receive Terminator :"
        '
        'cbComports
        '
        Me.cbComports.FormattingEnabled = True
        Me.cbComports.Location = New System.Drawing.Point(139, 12)
        Me.cbComports.Name = "cbComports"
        Me.cbComports.Size = New System.Drawing.Size(91, 20)
        Me.cbComports.TabIndex = 10
        '
        'cbDataLen
        '
        Me.cbDataLen.FormattingEnabled = True
        Me.cbDataLen.Location = New System.Drawing.Point(139, 122)
        Me.cbDataLen.Name = "cbDataLen"
        Me.cbDataLen.Size = New System.Drawing.Size(91, 20)
        Me.cbDataLen.TabIndex = 9
        '
        'cbStop
        '
        Me.cbStop.FormattingEnabled = True
        Me.cbStop.Location = New System.Drawing.Point(139, 96)
        Me.cbStop.Name = "cbStop"
        Me.cbStop.Size = New System.Drawing.Size(91, 20)
        Me.cbStop.TabIndex = 8
        '
        'cbParity
        '
        Me.cbParity.FormattingEnabled = True
        Me.cbParity.Location = New System.Drawing.Point(139, 67)
        Me.cbParity.Name = "cbParity"
        Me.cbParity.Size = New System.Drawing.Size(91, 20)
        Me.cbParity.TabIndex = 7
        '
        'cbBaudRate
        '
        Me.cbBaudRate.FormattingEnabled = True
        Me.cbBaudRate.Location = New System.Drawing.Point(139, 41)
        Me.cbBaudRate.Name = "cbBaudRate"
        Me.cbBaudRate.Size = New System.Drawing.Size(91, 20)
        Me.cbBaudRate.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(52, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Data Length :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(76, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Stop Bit :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(87, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Parity :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(95, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "BPS :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "COM Port :"
        '
        'ucConfigRs232
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbTitle)
        Me.Name = "ucConfigRs232"
        Me.Size = New System.Drawing.Size(275, 227)
        Me.gbTitle.ResumeLayout(False)
        Me.gbTitle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents gbTitle As System.Windows.Forms.GroupBox
    Private WithEvents cbDataLen As System.Windows.Forms.ComboBox
    Private WithEvents cbStop As System.Windows.Forms.ComboBox
    Private WithEvents cbParity As System.Windows.Forms.ComboBox
    Private WithEvents cbBaudRate As System.Windows.Forms.ComboBox
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents cbComports As System.Windows.Forms.ComboBox
    Private WithEvents cbSendTerminator As System.Windows.Forms.ComboBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents cbRcvTerminator As System.Windows.Forms.ComboBox
    Private WithEvents Label8 As System.Windows.Forms.Label

End Class
