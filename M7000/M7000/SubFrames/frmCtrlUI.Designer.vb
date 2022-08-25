<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCtrlUI
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
        Me.lblSystemStatus = New System.Windows.Forms.Label()
        Me.UcDispStateMsg1 = New M7000.ucDispStateMsg()
        Me.UcMotionIndicator1 = New M7000.ucMotionIndicator()
        Me.SuspendLayout()
        '
        'lblSystemStatus
        '
        Me.lblSystemStatus.BackColor = System.Drawing.Color.DarkGray
        Me.lblSystemStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSystemStatus.Font = New System.Drawing.Font("굴림", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblSystemStatus.Location = New System.Drawing.Point(653, 31)
        Me.lblSystemStatus.Name = "lblSystemStatus"
        Me.lblSystemStatus.Size = New System.Drawing.Size(522, 67)
        Me.lblSystemStatus.TabIndex = 1
        Me.lblSystemStatus.Text = "SYSTEM STATUS"
        Me.lblSystemStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSystemStatus.Visible = False
        '
        'UcDispStateMsg1
        '
        Me.UcDispStateMsg1.Location = New System.Drawing.Point(12, 614)
        Me.UcDispStateMsg1.Name = "UcDispStateMsg1"
        Me.UcDispStateMsg1.Size = New System.Drawing.Size(1122, 148)
        Me.UcDispStateMsg1.TabIndex = 2
        Me.UcDispStateMsg1.Visible = False
        '
        'UcMotionIndicator1
        '
        Me.UcMotionIndicator1.BackColor = System.Drawing.Color.White
        Me.UcMotionIndicator1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcMotionIndicator1.Channel = Nothing
        Me.UcMotionIndicator1.Location = New System.Drawing.Point(12, 3)
        Me.UcMotionIndicator1.Name = "UcMotionIndicator1"
        Me.UcMotionIndicator1.OpticalHeaderPos = Nothing
        Me.UcMotionIndicator1.Size = New System.Drawing.Size(283, 163)
        Me.UcMotionIndicator1.TabIndex = 0
        '  Me.UcMotionIndicator1.ThetaPos = 0.0R
        '  Me.UcMotionIndicator1.ThetaYPos = 0.0R
        Me.UcMotionIndicator1.Title = Nothing
        Me.UcMotionIndicator1.Visible = False
        Me.UcMotionIndicator1.XPos = 0.0R
        Me.UcMotionIndicator1.YPos = 0.0R
        Me.UcMotionIndicator1.ZPos = 0.0R
        Me.UcMotionIndicator1.Theta1Pos = 0.0R
        Me.UcMotionIndicator1.Theta2Pos = 0.0R
        Me.UcMotionIndicator1.Theta3Pos = 0.0R
        Me.UcMotionIndicator1.Theta4Pos = 0.0R
        '
        'frmCtrlUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1187, 774)
        Me.ControlBox = False
        Me.Controls.Add(Me.UcDispStateMsg1)
        Me.Controls.Add(Me.lblSystemStatus)
        Me.Controls.Add(Me.UcMotionIndicator1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCtrlUI"
        Me.Text = "frmCtrlUI"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcMotionIndicator1 As M7000.ucMotionIndicator
    Friend WithEvents lblSystemStatus As System.Windows.Forms.Label
    Friend WithEvents UcDispStateMsg1 As M7000.ucDispStateMsg
End Class
