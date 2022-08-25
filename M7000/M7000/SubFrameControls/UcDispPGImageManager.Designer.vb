<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcDispPGImageManager
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pbImageView = New System.Windows.Forms.PictureBox()
        Me.btnAddImage = New System.Windows.Forms.Button()
        Me.btnDelImage = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ucDispDataGrid = New ucDataGridView()
        Me.ucImageList = New ucDispListView()
        Me.btnChangeImage = New System.Windows.Forms.Button()
        Me.cboImageIndex = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbImageName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbImagePath = New System.Windows.Forms.TextBox()
        Me.btnImageOpen = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkImageSync = New System.Windows.Forms.CheckBox()
        Me.btnClearImage = New System.Windows.Forms.Button()
        Me.lblBtnHighlight = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImageView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pbImageView)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(392, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 189)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Image Viewer"
        '
        'pbImageView
        '
        Me.pbImageView.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pbImageView.Location = New System.Drawing.Point(16, 20)
        Me.pbImageView.Name = "pbImageView"
        Me.pbImageView.Size = New System.Drawing.Size(277, 155)
        Me.pbImageView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImageView.TabIndex = 2
        Me.pbImageView.TabStop = False
        '
        'btnAddImage
        '
        Me.btnAddImage.Location = New System.Drawing.Point(20, 251)
        Me.btnAddImage.Name = "btnAddImage"
        Me.btnAddImage.Size = New System.Drawing.Size(133, 46)
        Me.btnAddImage.TabIndex = 4
        Me.btnAddImage.Text = "ADD"
        Me.btnAddImage.UseVisualStyleBackColor = True
        '
        'btnDelImage
        '
        Me.btnDelImage.Location = New System.Drawing.Point(154, 251)
        Me.btnDelImage.Name = "btnDelImage"
        Me.btnDelImage.Size = New System.Drawing.Size(133, 46)
        Me.btnDelImage.TabIndex = 5
        Me.btnDelImage.Text = "DELETE"
        Me.btnDelImage.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ucDispDataGrid)
        Me.GroupBox2.Controls.Add(Me.ucImageList)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(386, 671)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Image List"
        '
        'ucDispDataGrid
        '
        Me.ucDispDataGrid.AutoScroll = True
        Me.ucDispDataGrid.AutoSizeCoulumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ucDispDataGrid.CellColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))}
        Me.ucDispDataGrid.ColHeaderWidthRatio = "10,20,120"
        Me.ucDispDataGrid.ColumnSelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ucDispDataGrid.ColumnSortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ucDispDataGrid.ContentAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet
        Me.ucDispDataGrid.ControllerHeaderText = New String() {"Index", "Image Name", "Image Path"}
        Me.ucDispDataGrid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucDispDataGrid.Location = New System.Drawing.Point(10, 20)
        Me.ucDispDataGrid.Name = "ucDispDataGrid"
        Me.ucDispDataGrid.RowHeaderSize = 10
        Me.ucDispDataGrid.RowLineNum = 0.0R
        Me.ucDispDataGrid.Size = New System.Drawing.Size(369, 643)
        Me.ucDispDataGrid.TabIndex = 11
        Me.ucDispDataGrid.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ucDispDataGrid.zContollerType = New ucDataGridView.eContollerType() {ucDataGridView.eContollerType.eTextBox, ucDataGridView.eContollerType.eTextBox, ucDataGridView.eContollerType.eTextBox}
        '
        'ucImageList
        '
        Me.ucImageList.ColHeader = New String() {"No", "Name", "Path"}
        Me.ucImageList.ColHeaderWidthRatio = "15,40,45"
        Me.ucImageList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucImageList.FullRawSelection = True
        Me.ucImageList.Location = New System.Drawing.Point(11, 29)
        Me.ucImageList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ucImageList.Name = "ucImageList"
        Me.ucImageList.Size = New System.Drawing.Size(220, 460)
        Me.ucImageList.TabIndex = 10
        Me.ucImageList.UseCheckBoxex = False
        Me.ucImageList.Visible = False
        '
        'btnChangeImage
        '
        Me.btnChangeImage.Location = New System.Drawing.Point(20, 355)
        Me.btnChangeImage.Name = "btnChangeImage"
        Me.btnChangeImage.Size = New System.Drawing.Size(267, 46)
        Me.btnChangeImage.TabIndex = 12
        Me.btnChangeImage.Text = "CHANGE Image"
        Me.btnChangeImage.UseVisualStyleBackColor = True
        '
        'cboImageIndex
        '
        Me.cboImageIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImageIndex.FormattingEnabled = True
        Me.cboImageIndex.Location = New System.Drawing.Point(19, 43)
        Me.cboImageIndex.Name = "cboImageIndex"
        Me.cboImageIndex.Size = New System.Drawing.Size(98, 23)
        Me.cboImageIndex.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Image Slot :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(137, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 15)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Image Name :"
        '
        'tbImageName
        '
        Me.tbImageName.Location = New System.Drawing.Point(139, 45)
        Me.tbImageName.Name = "tbImageName"
        Me.tbImageName.Size = New System.Drawing.Size(142, 21)
        Me.tbImageName.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Image Path :"
        '
        'tbImagePath
        '
        Me.tbImagePath.Location = New System.Drawing.Point(19, 100)
        Me.tbImagePath.Multiline = True
        Me.tbImagePath.Name = "tbImagePath"
        Me.tbImagePath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbImagePath.Size = New System.Drawing.Size(268, 92)
        Me.tbImagePath.TabIndex = 19
        '
        'btnImageOpen
        '
        Me.btnImageOpen.Location = New System.Drawing.Point(19, 199)
        Me.btnImageOpen.Name = "btnImageOpen"
        Me.btnImageOpen.Size = New System.Drawing.Size(267, 46)
        Me.btnImageOpen.TabIndex = 21
        Me.btnImageOpen.Text = "OPEN Image"
        Me.btnImageOpen.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkImageSync)
        Me.GroupBox3.Controls.Add(Me.lblBtnHighlight)
        Me.GroupBox3.Controls.Add(Me.btnClearImage)
        Me.GroupBox3.Controls.Add(Me.cboImageIndex)
        Me.GroupBox3.Controls.Add(Me.btnImageOpen)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.btnChangeImage)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.tbImageName)
        Me.GroupBox3.Controls.Add(Me.tbImagePath)
        Me.GroupBox3.Controls.Add(Me.btnDelImage)
        Me.GroupBox3.Controls.Add(Me.btnAddImage)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(392, 209)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(307, 470)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Image Info"
        '
        'chkImageSync
        '
        Me.chkImageSync.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkImageSync.Location = New System.Drawing.Point(21, 406)
        Me.chkImageSync.Margin = New System.Windows.Forms.Padding(10)
        Me.chkImageSync.Name = "chkImageSync"
        Me.chkImageSync.Size = New System.Drawing.Size(263, 42)
        Me.chkImageSync.TabIndex = 24
        Me.chkImageSync.Text = "SYNC"
        Me.chkImageSync.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkImageSync.UseVisualStyleBackColor = True
        '
        'btnClearImage
        '
        Me.btnClearImage.Location = New System.Drawing.Point(20, 303)
        Me.btnClearImage.Name = "btnClearImage"
        Me.btnClearImage.Size = New System.Drawing.Size(267, 46)
        Me.btnClearImage.TabIndex = 22
        Me.btnClearImage.Text = "CLEAR ALL"
        Me.btnClearImage.UseVisualStyleBackColor = True
        '
        'lblBtnHighlight
        '
        Me.lblBtnHighlight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblBtnHighlight.Location = New System.Drawing.Point(19, 404)
        Me.lblBtnHighlight.Name = "lblBtnHighlight"
        Me.lblBtnHighlight.Size = New System.Drawing.Size(267, 46)
        Me.lblBtnHighlight.TabIndex = 25
        '
        'UcDispPGImageManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "UcDispPGImageManager"
        Me.Size = New System.Drawing.Size(722, 687)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.pbImageView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImageView As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddImage As System.Windows.Forms.Button
    Friend WithEvents btnDelImage As System.Windows.Forms.Button
    Friend WithEvents ucImageList As ucDispListView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnChangeImage As System.Windows.Forms.Button
    Friend WithEvents ucDispDataGrid As ucDataGridView
    Friend WithEvents cboImageIndex As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbImageName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbImagePath As System.Windows.Forms.TextBox
    Friend WithEvents btnImageOpen As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClearImage As System.Windows.Forms.Button
    Friend WithEvents chkImageSync As System.Windows.Forms.CheckBox
    Friend WithEvents lblBtnHighlight As System.Windows.Forms.Label

End Class
