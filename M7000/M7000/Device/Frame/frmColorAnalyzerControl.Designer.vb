<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColorAnalyzerControl
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbSelDeviceNo = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 558)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(522, 21)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "CS100A : BPS : 4800, Parity : Even, Stop bit : 2, Data Len : 7, Terminator :CR + " & _
            "LF"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 541)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(522, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "CA310 : BPS : 38400, Parity : Even, Stop bit : 2, Data Len : 7, Terminator :cr"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Select Device No. :"
        '
        'cbSelDeviceNo
        '
        Me.cbSelDeviceNo.FormattingEnabled = True
        Me.cbSelDeviceNo.Location = New System.Drawing.Point(143, 6)
        Me.cbSelDeviceNo.Name = "cbSelDeviceNo"
        Me.cbSelDeviceNo.Size = New System.Drawing.Size(68, 20)
        Me.cbSelDeviceNo.TabIndex = 13
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(1, 579)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(522, 21)
        Me.lblStatus.TabIndex = 14
        Me.lblStatus.Text = "Status"
        '
        'frmColorAnalyzerControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(881, 600)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.cbSelDeviceNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmColorAnalyzerControl"
        Me.Text = "Color Analyzer Tester"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbSelDeviceNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
End Class
