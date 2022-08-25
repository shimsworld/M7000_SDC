<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispMultiCtrlOfListTypeForQC
    Inherits M7000.ucDispMultiCtrlCommonNode

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
        Me.gridList = New M7000.ucDataGridView()
        Me.SuspendLayout()
        '
        'gridList
        '
        Me.gridList.AutoScroll = True
        Me.gridList.AutoSizeCoulumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.gridList.CellColor = Nothing
        Me.gridList.ColHeaderWidthRatio = "5,20,10,10,5,15,15,20"
        Me.gridList.ColumnSelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridList.ColumnSortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gridList.ContentAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.gridList.ControllerHeaderText = New String() {"Target", "Status", "Result", "Progress", "Loop", "Total Time", "Mode Time", "Recipe Name"}
        Me.gridList.Location = New System.Drawing.Point(3, 12)
        Me.gridList.Name = "gridList"
        Me.gridList.RowHeaderSize = 50
        Me.gridList.RowLineNum = 0
        Me.gridList.Size = New System.Drawing.Size(1034, 227)
        Me.gridList.TabIndex = 1
        Me.gridList.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridList.zContollerType = New M7000.ucDataGridView.eContollerType() {M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox, M7000.ucDataGridView.eContollerType.eTextBox}
        '
        'ucDispMultiCtrlOfListTypeForQC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Channel = New Integer() {0}
        Me.Controls.Add(Me.gridList)
        Me.Name = "ucDispMultiCtrlOfListTypeForQC"
        Me.Size = New System.Drawing.Size(1160, 430)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridList As M7000.ucDataGridView

End Class
