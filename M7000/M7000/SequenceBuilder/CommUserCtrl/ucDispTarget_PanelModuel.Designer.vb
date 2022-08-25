<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispTarget_PanelModuel
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
        Me.tlpLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.lblCurrentPos = New System.Windows.Forms.Label()
        Me.pbDisplay = New System.Windows.Forms.PictureBox()
        Me.tlpLayout.SuspendLayout()
        CType(Me.pbDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpLayout
        '
        Me.tlpLayout.ColumnCount = 1
        Me.tlpLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpLayout.Controls.Add(Me.lblInfo, 0, 0)
        Me.tlpLayout.Controls.Add(Me.lblCurrentPos, 0, 2)
        Me.tlpLayout.Controls.Add(Me.pbDisplay, 0, 1)
        Me.tlpLayout.Location = New System.Drawing.Point(65, 36)
        Me.tlpLayout.Name = "tlpLayout"
        Me.tlpLayout.RowCount = 3
        Me.tlpLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpLayout.Size = New System.Drawing.Size(477, 350)
        Me.tlpLayout.TabIndex = 1
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInfo.Location = New System.Drawing.Point(3, 0)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(471, 26)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "Type : Panel   Size : 700 * 500  Temp : 50"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrentPos
        '
        Me.lblCurrentPos.AutoSize = True
        Me.lblCurrentPos.Location = New System.Drawing.Point(3, 324)
        Me.lblCurrentPos.Name = "lblCurrentPos"
        Me.lblCurrentPos.Size = New System.Drawing.Size(125, 12)
        Me.lblCurrentPos.TabIndex = 2
        Me.lblCurrentPos.Text = "X : 00000     Y : 00000"
        Me.lblCurrentPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbDisplay
        '
        Me.pbDisplay.BackColor = System.Drawing.Color.Red
        Me.pbDisplay.Cursor = System.Windows.Forms.Cursors.Cross
        Me.pbDisplay.Location = New System.Drawing.Point(3, 29)
        Me.pbDisplay.Name = "pbDisplay"
        Me.pbDisplay.Size = New System.Drawing.Size(362, 149)
        Me.pbDisplay.TabIndex = 3
        Me.pbDisplay.TabStop = False
        '
        'ucDispTarget_PanelModuel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.tlpLayout)
        Me.Name = "ucDispTarget_PanelModuel"
        Me.Size = New System.Drawing.Size(584, 442)
        Me.tlpLayout.ResumeLayout(False)
        Me.tlpLayout.PerformLayout()
        CType(Me.pbDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents lblCurrentPos As System.Windows.Forms.Label
    Friend WithEvents pbDisplay As System.Windows.Forms.PictureBox

End Class
