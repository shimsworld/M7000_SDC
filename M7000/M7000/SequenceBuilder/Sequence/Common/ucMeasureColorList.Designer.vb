<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMeasureColorList
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
        Me.gbColorList = New System.Windows.Forms.GroupBox()
        Me.cbSelColorType = New System.Windows.Forms.ComboBox()
        Me.ucListMeasColor = New M7000.ucDispListView()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.gbColorList.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbColorList
        '
        Me.gbColorList.Controls.Add(Me.cbSelColorType)
        Me.gbColorList.Controls.Add(Me.ucListMeasColor)
        Me.gbColorList.Controls.Add(Me.btnAdd)
        Me.gbColorList.Controls.Add(Me.Label1)
        Me.gbColorList.Controls.Add(Me.btnClear)
        Me.gbColorList.Controls.Add(Me.btnDelete)
        Me.gbColorList.Location = New System.Drawing.Point(13, 17)
        Me.gbColorList.Name = "gbColorList"
        Me.gbColorList.Size = New System.Drawing.Size(238, 221)
        Me.gbColorList.TabIndex = 50
        Me.gbColorList.TabStop = False
        Me.gbColorList.Text = "Measurement Color List"
        '
        'cbSelColorType
        '
        Me.cbSelColorType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSelColorType.FormattingEnabled = True
        Me.cbSelColorType.Location = New System.Drawing.Point(100, 20)
        Me.cbSelColorType.Name = "cbSelColorType"
        Me.cbSelColorType.Size = New System.Drawing.Size(62, 20)
        Me.cbSelColorType.TabIndex = 0
        '
        'ucListMeasColor
        '
        Me.ucListMeasColor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucListMeasColor.AutoScroll = True
        Me.ucListMeasColor.ColHeader = New String() {"No.", "Color"}
        Me.ucListMeasColor.ColHeaderWidthRatio = "35,65"
        Me.ucListMeasColor.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ucListMeasColor.FullRawSelection = True
        Me.ucListMeasColor.HideSelection = False
        Me.ucListMeasColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ucListMeasColor.LabelEdit = True
        Me.ucListMeasColor.LabelWrap = True
        Me.ucListMeasColor.Location = New System.Drawing.Point(6, 52)
        Me.ucListMeasColor.Name = "ucListMeasColor"
        Me.ucListMeasColor.Size = New System.Drawing.Size(156, 163)
        Me.ucListMeasColor.TabIndex = 25
        Me.ucListMeasColor.UseCheckBoxex = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(172, 20)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(60, 23)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 12)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Select Color  :"
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(172, 79)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(60, 23)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(172, 50)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 23)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "DEL"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'ucMeasureColorList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.gbColorList)
        Me.Name = "ucMeasureColorList"
        Me.Size = New System.Drawing.Size(265, 250)
        Me.gbColorList.ResumeLayout(False)
        Me.gbColorList.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbColorList As System.Windows.Forms.GroupBox
    Friend WithEvents ucListMeasColor As M7000.ucDispListView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents cbSelColorType As System.Windows.Forms.ComboBox

End Class
