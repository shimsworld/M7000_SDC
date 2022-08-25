<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispSampleUnitCell
    Inherits ucDispSampleCommonNode

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
        Me.components = New System.ComponentModel.Container()
        Me.lblCellArea = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnCellOutline = New System.Windows.Forms.Panel()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpTopLayer = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSavePath = New System.Windows.Forms.Label()
        Me.lblSeqLoadStatus = New System.Windows.Forms.Label()
        Me.lblIndicator_Temp = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnCellOutline.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        Me.tlpTopLayer.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCellArea
        '
        Me.lblCellArea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCellArea.BackColor = System.Drawing.Color.Black
        Me.lblCellArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCellArea.Font = New System.Drawing.Font("굴림", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblCellArea.ForeColor = System.Drawing.Color.White
        Me.lblCellArea.Location = New System.Drawing.Point(4, 4)
        Me.lblCellArea.Name = "lblCellArea"
        Me.lblCellArea.Size = New System.Drawing.Size(256, 237)
        Me.lblCellArea.TabIndex = 0
        Me.lblCellArea.Text = "Status"
        Me.lblCellArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(3, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(101, 13)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Cell 1"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnCellOutline
        '
        Me.pnCellOutline.BackColor = System.Drawing.Color.Red
        Me.pnCellOutline.Controls.Add(Me.lblCellArea)
        Me.pnCellOutline.Location = New System.Drawing.Point(1, 15)
        Me.pnCellOutline.Margin = New System.Windows.Forms.Padding(0)
        Me.pnCellOutline.Name = "pnCellOutline"
        Me.pnCellOutline.Size = New System.Drawing.Size(264, 245)
        Me.pnCellOutline.TabIndex = 2
        '
        'tlpMain
        '
        Me.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.tlpTopLayer, 0, 0)
        Me.tlpMain.Controls.Add(Me.pnCellOutline, 0, 1)
        Me.tlpMain.Location = New System.Drawing.Point(22, 15)
        Me.tlpMain.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(359, 338)
        Me.tlpMain.TabIndex = 3
        '
        'tlpTopLayer
        '
        Me.tlpTopLayer.ColumnCount = 4
        Me.tlpTopLayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpTopLayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpTopLayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpTopLayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpTopLayer.Controls.Add(Me.lblSavePath, 2, 0)
        Me.tlpTopLayer.Controls.Add(Me.lblTitle, 0, 0)
        Me.tlpTopLayer.Controls.Add(Me.lblSeqLoadStatus, 1, 0)
        Me.tlpTopLayer.Controls.Add(Me.lblIndicator_Temp, 3, 0)
        Me.tlpTopLayer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpTopLayer.Location = New System.Drawing.Point(1, 1)
        Me.tlpTopLayer.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpTopLayer.Name = "tlpTopLayer"
        Me.tlpTopLayer.RowCount = 1
        Me.tlpTopLayer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTopLayer.Size = New System.Drawing.Size(357, 13)
        Me.tlpTopLayer.TabIndex = 5
        '
        'lblSavePath
        '
        Me.lblSavePath.BackColor = System.Drawing.Color.Transparent
        Me.lblSavePath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSavePath.Location = New System.Drawing.Point(181, 0)
        Me.lblSavePath.Name = "lblSavePath"
        Me.lblSavePath.Padding = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblSavePath.Size = New System.Drawing.Size(65, 13)
        Me.lblSavePath.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.lblSavePath, "Sequence Title(Unloaded)")
        '
        'lblSeqLoadStatus
        '
        Me.lblSeqLoadStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblSeqLoadStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSeqLoadStatus.Location = New System.Drawing.Point(110, 0)
        Me.lblSeqLoadStatus.Name = "lblSeqLoadStatus"
        Me.lblSeqLoadStatus.Padding = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblSeqLoadStatus.Size = New System.Drawing.Size(65, 13)
        Me.lblSeqLoadStatus.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.lblSeqLoadStatus, "Sequence Title(Unloaded)")
        '
        'lblIndicator_Temp
        '
        Me.lblIndicator_Temp.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblIndicator_Temp.Location = New System.Drawing.Point(252, 0)
        Me.lblIndicator_Temp.Name = "lblIndicator_Temp"
        Me.lblIndicator_Temp.Size = New System.Drawing.Size(77, 13)
        Me.lblIndicator_Temp.TabIndex = 6
        Me.lblIndicator_Temp.Text = "999.9"
        Me.lblIndicator_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucDispSampleUnitCell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucDispSampleUnitCell"
        Me.Size = New System.Drawing.Size(594, 400)
        Me.pnCellOutline.ResumeLayout(False)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpTopLayer.ResumeLayout(False)
        Me.tlpTopLayer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCellArea As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnCellOutline As System.Windows.Forms.Panel
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpTopLayer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSeqLoadStatus As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblIndicator_Temp As System.Windows.Forms.Label
    Friend WithEvents lblSavePath As System.Windows.Forms.Label

End Class
