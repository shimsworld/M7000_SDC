<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMonitorParam
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ledStatus = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.lblName = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblName, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ledStatus, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 14)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(170, 15)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ledStatus
        '
        Me.ledStatus.BackColor = System.Drawing.Color.Transparent
        Me.ledStatus.BlinkInterval = 500
        Me.ledStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ledStatus.ForeColor = System.Drawing.Color.Black
        Me.ledStatus.Label = ""
        Me.ledStatus.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Bottom
        Me.ledStatus.LedColor = System.Drawing.Color.DarkGray
        Me.ledStatus.LedSize = New System.Drawing.SizeF(12.0!, 12.0!)
        Me.ledStatus.Location = New System.Drawing.Point(0, 0)
        Me.ledStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.ledStatus.Name = "ledStatus"
        Me.ledStatus.Renderer = Nothing
        Me.ledStatus.Size = New System.Drawing.Size(25, 15)
        Me.ledStatus.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledStatus.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular
        Me.ledStatus.TabIndex = 111
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Gray
        Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(25, 0)
        Me.lblName.Margin = New System.Windows.Forms.Padding(0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(145, 15)
        Me.lblName.TabIndex = 112
        Me.lblName.Text = "NAME"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ucMonitorParam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ucMonitorParam"
        Me.Size = New System.Drawing.Size(263, 47)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents ledStatus As LBSoft.IndustrialCtrls.Leds.LBLed

End Class
