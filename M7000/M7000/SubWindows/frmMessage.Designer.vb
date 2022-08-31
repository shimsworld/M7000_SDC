<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMessage
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.label89 = New System.Windows.Forms.Label()
        Me.label110 = New System.Windows.Forms.Label()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.dgWeakAlarm = New System.Windows.Forms.DataGridView()
        Me.dgStrongAlarm = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.dgWeakAlarm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgStrongAlarm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1263, 688)
        Me.SplitContainer1.SplitterDistance = 69
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.label89)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.label110)
        Me.SplitContainer2.Size = New System.Drawing.Size(1263, 69)
        Me.SplitContainer2.SplitterDistance = 629
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 0
        '
        'label89
        '
        Me.label89.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.label89.Dock = System.Windows.Forms.DockStyle.Fill
        Me.label89.Font = New System.Drawing.Font("맑은 고딕", 20.0!, System.Drawing.FontStyle.Bold)
        Me.label89.ForeColor = System.Drawing.Color.White
        Me.label89.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.label89.Location = New System.Drawing.Point(0, 0)
        Me.label89.Margin = New System.Windows.Forms.Padding(3)
        Me.label89.Name = "label89"
        Me.label89.Size = New System.Drawing.Size(629, 69)
        Me.label89.TabIndex = 1068
        Me.label89.Text = "Light Alarm"
        Me.label89.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label110
        '
        Me.label110.BackColor = System.Drawing.Color.Red
        Me.label110.Dock = System.Windows.Forms.DockStyle.Fill
        Me.label110.Font = New System.Drawing.Font("맑은 고딕", 20.0!, System.Drawing.FontStyle.Bold)
        Me.label110.ForeColor = System.Drawing.Color.White
        Me.label110.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.label110.Location = New System.Drawing.Point(0, 0)
        Me.label110.Margin = New System.Windows.Forms.Padding(3)
        Me.label110.Name = "label110"
        Me.label110.Size = New System.Drawing.Size(633, 69)
        Me.label110.TabIndex = 1069
        Me.label110.Text = "heavy Alarm"
        Me.label110.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.dgWeakAlarm)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.dgStrongAlarm)
        Me.SplitContainer3.Size = New System.Drawing.Size(1263, 618)
        Me.SplitContainer3.SplitterDistance = 629
        Me.SplitContainer3.SplitterWidth = 1
        Me.SplitContainer3.TabIndex = 0
        '
        'dgWeakAlarm
        '
        Me.dgWeakAlarm.AllowUserToAddRows = False
        Me.dgWeakAlarm.AllowUserToDeleteRows = False
        Me.dgWeakAlarm.AllowUserToResizeColumns = False
        Me.dgWeakAlarm.AllowUserToResizeRows = False
        Me.dgWeakAlarm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgWeakAlarm.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgWeakAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgWeakAlarm.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column13, Me.Column14})
        Me.dgWeakAlarm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgWeakAlarm.Location = New System.Drawing.Point(0, 0)
        Me.dgWeakAlarm.MultiSelect = False
        Me.dgWeakAlarm.Name = "dgWeakAlarm"
        Me.dgWeakAlarm.ReadOnly = True
        Me.dgWeakAlarm.RowHeadersVisible = False
        Me.dgWeakAlarm.RowTemplate.Height = 23
        Me.dgWeakAlarm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgWeakAlarm.Size = New System.Drawing.Size(629, 618)
        Me.dgWeakAlarm.TabIndex = 1072
        '
        'dgStrongAlarm
        '
        Me.dgStrongAlarm.AllowUserToAddRows = False
        Me.dgStrongAlarm.AllowUserToDeleteRows = False
        Me.dgStrongAlarm.AllowUserToResizeColumns = False
        Me.dgStrongAlarm.AllowUserToResizeRows = False
        Me.dgStrongAlarm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgStrongAlarm.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgStrongAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgStrongAlarm.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgStrongAlarm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgStrongAlarm.Location = New System.Drawing.Point(0, 0)
        Me.dgStrongAlarm.MultiSelect = False
        Me.dgStrongAlarm.Name = "dgStrongAlarm"
        Me.dgStrongAlarm.ReadOnly = True
        Me.dgStrongAlarm.RowHeadersVisible = False
        Me.dgStrongAlarm.RowTemplate.Height = 23
        Me.dgStrongAlarm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgStrongAlarm.Size = New System.Drawing.Size(633, 618)
        Me.dgStrongAlarm.TabIndex = 1073
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 46.1419!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Alarm Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 135.6572!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Alarm Message"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column13
        '
        Me.Column13.FillWeight = 46.1419!
        Me.Column13.HeaderText = "Alarm Name"
        Me.Column13.MinimumWidth = 10
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column14
        '
        Me.Column14.FillWeight = 135.6572!
        Me.Column14.HeaderText = "Alarm Message"
        Me.Column14.MinimumWidth = 10
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'frmMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1263, 688)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMessage"
        Me.Text = "frmMessage"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.dgWeakAlarm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgStrongAlarm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Private WithEvents label89 As Label
    Private WithEvents label110 As Label
    Friend WithEvents SplitContainer3 As SplitContainer
    Public WithEvents dgWeakAlarm As DataGridView
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Public WithEvents dgStrongAlarm As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
End Class
