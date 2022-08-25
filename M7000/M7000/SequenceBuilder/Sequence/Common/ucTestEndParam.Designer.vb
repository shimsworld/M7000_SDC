<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucTestEndParam
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
        Me.gbTestEndPara = New System.Windows.Forms.GroupBox()
        Me.txtEndValue = New System.Windows.Forms.TextBox()
        Me.cbEndPara = New System.Windows.Forms.ComboBox()
        Me.lblEndpara = New System.Windows.Forms.Label()
        Me.lblEndValue = New System.Windows.Forms.Label()
        Me.ucListTestEnd = New M7000.ucDispListView()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.gbTestEndPara.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTestEndPara
        '
        Me.gbTestEndPara.Controls.Add(Me.txtEndValue)
        Me.gbTestEndPara.Controls.Add(Me.cbEndPara)
        Me.gbTestEndPara.Controls.Add(Me.lblEndpara)
        Me.gbTestEndPara.Controls.Add(Me.lblEndValue)
        Me.gbTestEndPara.Controls.Add(Me.ucListTestEnd)
        Me.gbTestEndPara.Controls.Add(Me.btnDel)
        Me.gbTestEndPara.Controls.Add(Me.btnAdd)
        Me.gbTestEndPara.Location = New System.Drawing.Point(30, 25)
        Me.gbTestEndPara.Name = "gbTestEndPara"
        Me.gbTestEndPara.Size = New System.Drawing.Size(307, 243)
        Me.gbTestEndPara.TabIndex = 0
        Me.gbTestEndPara.TabStop = False
        Me.gbTestEndPara.Text = "TEST END"
        '
        'txtEndValue
        '
        Me.txtEndValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEndValue.BackColor = System.Drawing.SystemColors.Control
        Me.txtEndValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEndValue.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtEndValue.Location = New System.Drawing.Point(84, 42)
        Me.txtEndValue.Name = "txtEndValue"
        Me.txtEndValue.Size = New System.Drawing.Size(147, 21)
        Me.txtEndValue.TabIndex = 2
        Me.txtEndValue.Text = "0"
        Me.txtEndValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbEndPara
        '
        Me.cbEndPara.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbEndPara.FormattingEnabled = True
        Me.cbEndPara.Location = New System.Drawing.Point(84, 16)
        Me.cbEndPara.Name = "cbEndPara"
        Me.cbEndPara.Size = New System.Drawing.Size(147, 23)
        Me.cbEndPara.TabIndex = 1
        '
        'lblEndpara
        '
        Me.lblEndpara.AutoSize = True
        Me.lblEndpara.Location = New System.Drawing.Point(8, 20)
        Me.lblEndpara.Name = "lblEndpara"
        Me.lblEndpara.Size = New System.Drawing.Size(68, 15)
        Me.lblEndpara.TabIndex = 6
        Me.lblEndpara.Text = "Parameter"
        '
        'lblEndValue
        '
        Me.lblEndValue.Location = New System.Drawing.Point(7, 43)
        Me.lblEndValue.Name = "lblEndValue"
        Me.lblEndValue.Size = New System.Drawing.Size(69, 16)
        Me.lblEndValue.TabIndex = 5
        Me.lblEndValue.Text = "Value"
        Me.lblEndValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucListTestEnd
        '
        Me.ucListTestEnd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucListTestEnd.ColHeader = New String() {"No", "Parameter", "Vlaue"}
        Me.ucListTestEnd.ColHeaderWidthRatio = "20,45,35"
        Me.ucListTestEnd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucListTestEnd.FullRawSelection = True
        Me.ucListTestEnd.HideSelection = False
        Me.ucListTestEnd.LabelEdit = True
        Me.ucListTestEnd.LabelWrap = True
        Me.ucListTestEnd.Location = New System.Drawing.Point(7, 68)
        Me.ucListTestEnd.Name = "ucListTestEnd"
        Me.ucListTestEnd.Size = New System.Drawing.Size(294, 169)
        Me.ucListTestEnd.TabIndex = 5
        Me.ucListTestEnd.UseCheckBoxex = False
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDel.BackColor = System.Drawing.Color.Silver
        Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDel.Location = New System.Drawing.Point(241, 41)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(58, 23)
        Me.btnDel.TabIndex = 4
        Me.btnDel.Text = "DEL"
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.Silver
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(241, 15)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(58, 23)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'ucTestEndParam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.gbTestEndPara)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucTestEndParam"
        Me.Size = New System.Drawing.Size(388, 303)
        Me.gbTestEndPara.ResumeLayout(False)
        Me.gbTestEndPara.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbTestEndPara As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtEndValue As System.Windows.Forms.TextBox
    Friend WithEvents cbEndPara As System.Windows.Forms.ComboBox
    Friend WithEvents lblEndpara As System.Windows.Forms.Label
    Friend WithEvents lblEndValue As System.Windows.Forms.Label
    Friend WithEvents ucListTestEnd As ucDispListView
    Friend WithEvents btnDel As System.Windows.Forms.Button

End Class
