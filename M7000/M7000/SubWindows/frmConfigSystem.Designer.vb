<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigSystem
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
        Me.cbSelDevice = New System.Windows.Forms.ComboBox()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ucDispList = New M7000.ucDispListView()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.UpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.ctxMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbSelDevice
        '
        Me.cbSelDevice.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbSelDevice.FormattingEnabled = True
        Me.cbSelDevice.Location = New System.Drawing.Point(114, 21)
        Me.cbSelDevice.Name = "cbSelDevice"
        Me.cbSelDevice.Size = New System.Drawing.Size(194, 20)
        Me.cbSelDevice.TabIndex = 0
        '
        'btnADD
        '
        Me.btnADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnADD.Location = New System.Drawing.Point(316, 20)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(84, 25)
        Me.btnADD.TabIndex = 1
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select Device"
        '
        'ucDispList
        '
        Me.ucDispList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ucDispList.ColHeader = New String() {"No.", "Device"}
        Me.ucDispList.ColHeaderWidthRatio = "10,90"
        Me.ucDispList.ContextMenuStrip = Me.ctxMenu
        Me.ucDispList.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucDispList.FullRawSelection = True
        Me.ucDispList.HideSelection = False
        Me.ucDispList.LabelEdit = True
        Me.ucDispList.LabelWrap = True
        Me.ucDispList.Location = New System.Drawing.Point(12, 53)
        Me.ucDispList.Name = "ucDispList"
        Me.ucDispList.Size = New System.Drawing.Size(388, 243)
        Me.ucDispList.TabIndex = 3
        Me.ucDispList.UseCheckBoxex = True
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DelToolStripMenuItem, Me.ToolStripMenuItem1, Me.UpToolStripMenuItem, Me.DownToolStripMenuItem, Me.ToolStripMenuItem2, Me.ClearToolStripMenuItem})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(107, 104)
        '
        'DelToolStripMenuItem
        '
        Me.DelToolStripMenuItem.Name = "DelToolStripMenuItem"
        Me.DelToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.DelToolStripMenuItem.Text = "Del"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(103, 6)
        '
        'UpToolStripMenuItem
        '
        Me.UpToolStripMenuItem.Name = "UpToolStripMenuItem"
        Me.UpToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.UpToolStripMenuItem.Text = "Up"
        '
        'DownToolStripMenuItem
        '
        Me.DownToolStripMenuItem.Name = "DownToolStripMenuItem"
        Me.DownToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.DownToolStripMenuItem.Text = "Down"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(103, 6)
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(302, 302)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(96, 30)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Location = New System.Drawing.Point(201, 302)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(96, 30)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmConfigSystem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 342)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ucDispList)
        Me.Controls.Add(Me.btnADD)
        Me.Controls.Add(Me.cbSelDevice)
        Me.Name = "frmConfigSystem"
        Me.Text = "System Configuration"
        Me.ctxMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbSelDevice As System.Windows.Forms.ComboBox
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ucDispList As M7000.ucDispListView
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
