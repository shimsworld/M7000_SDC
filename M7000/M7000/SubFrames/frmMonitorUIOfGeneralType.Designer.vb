<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitorUIOfGeneralType
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
        Me.components = New System.ComponentModel.Container()
        Me.pnDatas = New System.Windows.Forms.Panel()
        Me.ucDataGrid = New M7000.ucDataGridView()
        Me.ucDispListDatas = New M7000.ucDispListView()
        Me.pnStatus = New System.Windows.Forms.Panel()
        Me.ucDispListStatus = New M7000.ucDispListView()
        Me.spcMain = New System.Windows.Forms.SplitContainer()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnDatas.SuspendLayout()
        Me.pnStatus.SuspendLayout()
        CType(Me.spcMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcMain.Panel1.SuspendLayout()
        Me.spcMain.Panel2.SuspendLayout()
        Me.spcMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnDatas
        '
        Me.pnDatas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnDatas.Controls.Add(Me.ucDataGrid)
        Me.pnDatas.Controls.Add(Me.ucDispListDatas)
        Me.pnDatas.Location = New System.Drawing.Point(27, 34)
        Me.pnDatas.Name = "pnDatas"
        Me.pnDatas.Size = New System.Drawing.Size(543, 365)
        Me.pnDatas.TabIndex = 3
        '
        'ucDataGrid
        '
        Me.ucDataGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucDataGrid.AutoScroll = True
        Me.ucDataGrid.AutoSizeCoulumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ucDataGrid.CellColor = Nothing
        Me.ucDataGrid.ColHeaderWidthRatio = "20,20,20,20,20"
        Me.ucDataGrid.ColumnSelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ucDataGrid.ColumnSortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ucDataGrid.ContentAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet
        Me.ucDataGrid.ControllerHeaderText = New String(-1) {}
        Me.ucDataGrid.EnableEvent = True
        Me.ucDataGrid.Location = New System.Drawing.Point(3, 184)
        Me.ucDataGrid.Margin = New System.Windows.Forms.Padding(4)
        Me.ucDataGrid.Name = "ucDataGrid"
        Me.ucDataGrid.RowHeaderSize = 50
        Me.ucDataGrid.RowHeaderVisible = True
        Me.ucDataGrid.RowLineNum = 0
        Me.ucDataGrid.Size = New System.Drawing.Size(531, 160)
        Me.ucDataGrid.TabIndex = 5
        Me.ucDataGrid.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucDataGrid.zContollerType = New M7000.ucDataGridView.eContollerType(-1) {}
        '
        'ucDispListDatas
        '
        Me.ucDispListDatas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucDispListDatas.ColHeader = New String() {"Ch", "High Voltage", "Low Voltage", "High Current", "Low Current", "PD Current", "Luminance(%)", "Temp"}
        Me.ucDispListDatas.ColHeaderWidthRatio = "5,10,10,10,10,10,10,10"
        Me.ucDispListDatas.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucDispListDatas.FullRawSelection = True
        Me.ucDispListDatas.HideSelection = False
        Me.ucDispListDatas.LabelEdit = True
        Me.ucDispListDatas.LabelWrap = True
        Me.ucDispListDatas.Location = New System.Drawing.Point(3, 31)
        Me.ucDispListDatas.Margin = New System.Windows.Forms.Padding(4)
        Me.ucDispListDatas.Name = "ucDispListDatas"
        Me.ucDispListDatas.Size = New System.Drawing.Size(535, 147)
        Me.ucDispListDatas.TabIndex = 4
        Me.ucDispListDatas.UseCheckBoxex = True
        '
        'pnStatus
        '
        Me.pnStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnStatus.Controls.Add(Me.ucDispListStatus)
        Me.pnStatus.Location = New System.Drawing.Point(18, 34)
        Me.pnStatus.Name = "pnStatus"
        Me.pnStatus.Size = New System.Drawing.Size(411, 369)
        Me.pnStatus.TabIndex = 4
        '
        'ucDispListStatus
        '
        Me.ucDispListStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucDispListStatus.ColHeader = New String() {"TEG", "Filename", "Status", "Target", "Progress", "Cycle", "Total Time", "Mode Time", "Message"}
        Me.ucDispListStatus.ColHeaderWidthRatio = "7,10,14,9,14,8,14,14,14"
        Me.ucDispListStatus.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucDispListStatus.FullRawSelection = True
        Me.ucDispListStatus.HideSelection = False
        Me.ucDispListStatus.LabelEdit = True
        Me.ucDispListStatus.LabelWrap = True
        Me.ucDispListStatus.Location = New System.Drawing.Point(3, 31)
        Me.ucDispListStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.ucDispListStatus.Name = "ucDispListStatus"
        Me.ucDispListStatus.Size = New System.Drawing.Size(404, 333)
        Me.ucDispListStatus.TabIndex = 0
        Me.ucDispListStatus.UseCheckBoxex = True
        '
        'spcMain
        '
        Me.spcMain.Location = New System.Drawing.Point(30, 55)
        Me.spcMain.Name = "spcMain"
        '
        'spcMain.Panel1
        '
        Me.spcMain.Panel1.Controls.Add(Me.pnStatus)
        '
        'spcMain.Panel2
        '
        Me.spcMain.Panel2.Controls.Add(Me.pnDatas)
        Me.spcMain.Size = New System.Drawing.Size(1029, 440)
        Me.spcMain.SplitterDistance = 452
        Me.spcMain.SplitterWidth = 3
        Me.spcMain.TabIndex = 3
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmMonitorUIOfGeneralType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1109, 756)
        Me.ControlBox = False
        Me.Controls.Add(Me.spcMain)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMonitorUIOfGeneralType"
        Me.pnDatas.ResumeLayout(False)
        Me.pnStatus.ResumeLayout(False)
        Me.spcMain.Panel1.ResumeLayout(False)
        Me.spcMain.Panel2.ResumeLayout(False)
        CType(Me.spcMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucDispListDatas As M7000.ucDispListView
    Friend WithEvents pnDatas As System.Windows.Forms.Panel
    Friend WithEvents pnStatus As System.Windows.Forms.Panel
    Friend WithEvents ucDispListStatus As M7000.ucDispListView
    Friend WithEvents spcMain As System.Windows.Forms.SplitContainer
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ucDataGrid As M7000.ucDataGridView
End Class
