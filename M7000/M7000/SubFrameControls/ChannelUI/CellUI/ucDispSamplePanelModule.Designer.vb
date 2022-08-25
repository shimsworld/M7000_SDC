<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispSamplePanelModule
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
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpTopLayer = New System.Windows.Forms.TableLayoutPanel()
        Me.lblInformation = New System.Windows.Forms.Label()
        Me.lblIndicator_Temp = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSavePath = New System.Windows.Forms.Label()
        Me.lblSeqLoadStatus = New System.Windows.Forms.Label()
        Me.pnCellOutline = New System.Windows.Forms.Panel()
        Me.lblCellArea = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tlpMain.SuspendLayout()
        Me.tlpTopLayer.SuspendLayout()
        Me.pnCellOutline.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.Controls.Add(Me.tlpTopLayer, 0, 0)
        Me.tlpMain.Controls.Add(Me.pnCellOutline, 0, 1)
        Me.tlpMain.Location = New System.Drawing.Point(35, 30)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(454, 241)
        Me.tlpMain.TabIndex = 4
        '
        'tlpTopLayer
        '
        Me.tlpTopLayer.ColumnCount = 5
        Me.tlpTopLayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpTopLayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpTopLayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpTopLayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpTopLayer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpTopLayer.Controls.Add(Me.lblInformation, 1, 0)
        Me.tlpTopLayer.Controls.Add(Me.lblIndicator_Temp, 4, 0)
        Me.tlpTopLayer.Controls.Add(Me.lblTitle, 0, 0)
        Me.tlpTopLayer.Controls.Add(Me.lblSavePath, 3, 0)
        Me.tlpTopLayer.Controls.Add(Me.lblSeqLoadStatus, 2, 0)
        Me.tlpTopLayer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpTopLayer.Location = New System.Drawing.Point(0, 0)
        Me.tlpTopLayer.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpTopLayer.Name = "tlpTopLayer"
        Me.tlpTopLayer.RowCount = 1
        Me.tlpTopLayer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTopLayer.Size = New System.Drawing.Size(454, 17)
        Me.tlpTopLayer.TabIndex = 5
        '
        'lblInformation
        '
        Me.lblInformation.AutoSize = True
        Me.lblInformation.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblInformation.Location = New System.Drawing.Point(93, 0)
        Me.lblInformation.Name = "lblInformation"
        Me.lblInformation.Size = New System.Drawing.Size(78, 12)
        Me.lblInformation.TabIndex = 4
        Me.lblInformation.Text = "Information"
        Me.lblInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIndicator_Temp
        '
        Me.lblIndicator_Temp.AutoSize = True
        Me.lblIndicator_Temp.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblIndicator_Temp.Location = New System.Drawing.Point(410, 0)
        Me.lblIndicator_Temp.Name = "lblIndicator_Temp"
        Me.lblIndicator_Temp.Size = New System.Drawing.Size(26, 12)
        Me.lblIndicator_Temp.TabIndex = 3
        Me.lblIndicator_Temp.Text = "100"
        Me.lblIndicator_Temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(3, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(29, 12)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "title"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSavePath
        '
        Me.lblSavePath.AutoSize = True
        Me.lblSavePath.BackColor = System.Drawing.Color.Red
        Me.lblSavePath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSavePath.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblSavePath.Location = New System.Drawing.Point(365, 0)
        Me.lblSavePath.Name = "lblSavePath"
        Me.lblSavePath.Size = New System.Drawing.Size(39, 17)
        Me.lblSavePath.TabIndex = 6
        Me.lblSavePath.Text = " "
        Me.lblSavePath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSeqLoadStatus
        '
        Me.lblSeqLoadStatus.AutoSize = True
        Me.lblSeqLoadStatus.BackColor = System.Drawing.Color.Red
        Me.lblSeqLoadStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSeqLoadStatus.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblSeqLoadStatus.Location = New System.Drawing.Point(320, 0)
        Me.lblSeqLoadStatus.Name = "lblSeqLoadStatus"
        Me.lblSeqLoadStatus.Size = New System.Drawing.Size(39, 17)
        Me.lblSeqLoadStatus.TabIndex = 5
        Me.lblSeqLoadStatus.Text = " "
        Me.lblSeqLoadStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnCellOutline
        '
        Me.pnCellOutline.BackColor = System.Drawing.Color.Red
        Me.pnCellOutline.Controls.Add(Me.lblCellArea)
        Me.pnCellOutline.Location = New System.Drawing.Point(3, 20)
        Me.pnCellOutline.Name = "pnCellOutline"
        Me.pnCellOutline.Size = New System.Drawing.Size(408, 182)
        Me.pnCellOutline.TabIndex = 2
        '
        'lblCellArea
        '
        Me.lblCellArea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCellArea.BackColor = System.Drawing.Color.Transparent
        Me.lblCellArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCellArea.ForeColor = System.Drawing.Color.White
        Me.lblCellArea.Location = New System.Drawing.Point(7, 6)
        Me.lblCellArea.Name = "lblCellArea"
        Me.lblCellArea.Size = New System.Drawing.Size(224, 85)
        Me.lblCellArea.TabIndex = 6
        Me.lblCellArea.Text = "Status"
        Me.lblCellArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ucDispSamplePanelModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucDispSamplePanelModule"
        Me.Size = New System.Drawing.Size(572, 415)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpTopLayer.ResumeLayout(False)
        Me.tlpTopLayer.PerformLayout()
        Me.pnCellOutline.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnCellOutline As System.Windows.Forms.Panel
    Friend WithEvents lblInformation As System.Windows.Forms.Label
    Friend WithEvents lblIndicator_Temp As System.Windows.Forms.Label
    Friend WithEvents lblSeqLoadStatus As System.Windows.Forms.Label
    Friend WithEvents lblSavePath As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tlpTopLayer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCellArea As System.Windows.Forms.Label

End Class
