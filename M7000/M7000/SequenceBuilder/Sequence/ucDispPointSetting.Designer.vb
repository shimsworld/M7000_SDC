<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispPointSetting
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
        Me.btnDown = New System.Windows.Forms.Button()
        Me.gbPointList = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.UcDispListView1 = New M7000.ucDispListView()
        Me.gbMargin = New System.Windows.Forms.GroupBox()
        Me.tbMarginY = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbMarginX = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtnShortCut_P1 = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnShortCut_P2by2 = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnShortCut_P3by3 = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnShortCut_P3by4 = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnShortCut_P5by5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtnPointColor1 = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnPointColor2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripColorPicker2 = New OfficePickers.ColorPicker.ToolStripColorPicker()
        Me.spcMain = New System.Windows.Forms.SplitContainer()
        Me.UcDispTarget_PanelModuel1 = New M7000.ucDispTarget_PanelModuel()
        Me.gbPosition = New System.Windows.Forms.GroupBox()
        Me.btnPosAdd = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbInput_YPos = New System.Windows.Forms.TextBox()
        Me.tbInput_XPos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbPointList.SuspendLayout()
        Me.gbMargin.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.spcMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcMain.Panel1.SuspendLayout()
        Me.spcMain.Panel2.SuspendLayout()
        Me.spcMain.SuspendLayout()
        Me.gbPosition.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDown
        '
        Me.btnDown.Location = New System.Drawing.Point(70, 277)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(60, 37)
        Me.btnDown.TabIndex = 7
        Me.btnDown.Text = "DOWN"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'gbPointList
        '
        Me.gbPointList.Controls.Add(Me.btnDelete)
        Me.gbPointList.Controls.Add(Me.btnUp)
        Me.gbPointList.Controls.Add(Me.btnClear)
        Me.gbPointList.Controls.Add(Me.UcDispListView1)
        Me.gbPointList.Controls.Add(Me.btnDown)
        Me.gbPointList.Location = New System.Drawing.Point(3, 59)
        Me.gbPointList.Name = "gbPointList"
        Me.gbPointList.Size = New System.Drawing.Size(263, 321)
        Me.gbPointList.TabIndex = 11
        Me.gbPointList.TabStop = False
        Me.gbPointList.Text = "Point List"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(135, 277)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 37)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Location = New System.Drawing.Point(5, 277)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(60, 37)
        Me.btnUp.TabIndex = 9
        Me.btnUp.Text = "UP"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(200, 277)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(60, 37)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'UcDispListView1
        '
        Me.UcDispListView1.ColHeader = New String() {"Point", "Position X(mm)", "Position Y(mm)"}
        Me.UcDispListView1.ColHeaderWidthRatio = "20,40,40"
        Me.UcDispListView1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcDispListView1.FullRawSelection = True
        Me.UcDispListView1.HideSelection = False
        Me.UcDispListView1.LabelEdit = True
        Me.UcDispListView1.LabelWrap = True
        Me.UcDispListView1.Location = New System.Drawing.Point(5, 14)
        Me.UcDispListView1.Name = "UcDispListView1"
        Me.UcDispListView1.Size = New System.Drawing.Size(255, 260)
        Me.UcDispListView1.TabIndex = 0
        Me.UcDispListView1.UseCheckBoxex = False
        '
        'gbMargin
        '
        Me.gbMargin.Controls.Add(Me.tbMarginY)
        Me.gbMargin.Controls.Add(Me.Label2)
        Me.gbMargin.Controls.Add(Me.tbMarginX)
        Me.gbMargin.Controls.Add(Me.Label1)
        Me.gbMargin.Location = New System.Drawing.Point(4, 384)
        Me.gbMargin.Name = "gbMargin"
        Me.gbMargin.Size = New System.Drawing.Size(261, 54)
        Me.gbMargin.TabIndex = 13
        Me.gbMargin.TabStop = False
        Me.gbMargin.Text = "Margin"
        Me.gbMargin.Visible = False
        '
        'tbMarginY
        '
        Me.tbMarginY.Location = New System.Drawing.Point(172, 22)
        Me.tbMarginY.Name = "tbMarginY"
        Me.tbMarginY.Size = New System.Drawing.Size(61, 21)
        Me.tbMarginY.TabIndex = 17
        Me.tbMarginY.Text = "0"
        Me.tbMarginY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(146, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 12)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = " Y :"
        '
        'tbMarginX
        '
        Me.tbMarginX.Location = New System.Drawing.Point(45, 22)
        Me.tbMarginX.Name = "tbMarginX"
        Me.tbMarginX.Size = New System.Drawing.Size(61, 21)
        Me.tbMarginX.TabIndex = 15
        Me.tbMarginX.Text = "0"
        Me.tbMarginX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 12)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = " X :"
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.SystemColors.MenuBar
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton6, Me.ToolStripSeparator1, Me.tsBtnShortCut_P1, Me.tsBtnShortCut_P2by2, Me.tsBtnShortCut_P3by3, Me.tsBtnShortCut_P3by4, Me.tsBtnShortCut_P5by5, Me.ToolStripSeparator2, Me.tsBtnPointColor1, Me.tsBtnPointColor2, Me.ToolStripColorPicker2})
        Me.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip.Size = New System.Drawing.Size(659, 25)
        Me.ToolStrip.TabIndex = 16
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.AutoSize = False
        Me.ToolStripButton6.Image = Global.M7000.My.Resources.Resources.ImageSelect
        Me.ToolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(50, 50)
        Me.ToolStripButton6.Text = "Image"
        Me.ToolStripButton6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton6.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsBtnShortCut_P1
        '
        Me.tsBtnShortCut_P1.AutoSize = False
        Me.tsBtnShortCut_P1.Image = Global.M7000.My.Resources.Resources.P1
        Me.tsBtnShortCut_P1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnShortCut_P1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnShortCut_P1.Name = "tsBtnShortCut_P1"
        Me.tsBtnShortCut_P1.Size = New System.Drawing.Size(50, 50)
        Me.tsBtnShortCut_P1.Text = "1"
        Me.tsBtnShortCut_P1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsBtnShortCut_P1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsBtnShortCut_P1.Visible = False
        '
        'tsBtnShortCut_P2by2
        '
        Me.tsBtnShortCut_P2by2.AutoSize = False
        Me.tsBtnShortCut_P2by2.Image = Global.M7000.My.Resources.Resources.P2by2
        Me.tsBtnShortCut_P2by2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnShortCut_P2by2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnShortCut_P2by2.Name = "tsBtnShortCut_P2by2"
        Me.tsBtnShortCut_P2by2.Size = New System.Drawing.Size(50, 50)
        Me.tsBtnShortCut_P2by2.Text = "2 * 2"
        Me.tsBtnShortCut_P2by2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsBtnShortCut_P2by2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsBtnShortCut_P2by2.Visible = False
        '
        'tsBtnShortCut_P3by3
        '
        Me.tsBtnShortCut_P3by3.AutoSize = False
        Me.tsBtnShortCut_P3by3.Image = Global.M7000.My.Resources.Resources.P3by3
        Me.tsBtnShortCut_P3by3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnShortCut_P3by3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnShortCut_P3by3.Name = "tsBtnShortCut_P3by3"
        Me.tsBtnShortCut_P3by3.Size = New System.Drawing.Size(50, 50)
        Me.tsBtnShortCut_P3by3.Text = "3 * 3"
        Me.tsBtnShortCut_P3by3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsBtnShortCut_P3by3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsBtnShortCut_P3by3.Visible = False
        '
        'tsBtnShortCut_P3by4
        '
        Me.tsBtnShortCut_P3by4.AutoSize = False
        Me.tsBtnShortCut_P3by4.Image = Global.M7000.My.Resources.Resources.P3by4
        Me.tsBtnShortCut_P3by4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnShortCut_P3by4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnShortCut_P3by4.Name = "tsBtnShortCut_P3by4"
        Me.tsBtnShortCut_P3by4.Size = New System.Drawing.Size(50, 50)
        Me.tsBtnShortCut_P3by4.Text = "3 * 4"
        Me.tsBtnShortCut_P3by4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsBtnShortCut_P3by4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsBtnShortCut_P3by4.Visible = False
        '
        'tsBtnShortCut_P5by5
        '
        Me.tsBtnShortCut_P5by5.AutoSize = False
        Me.tsBtnShortCut_P5by5.Image = Global.M7000.My.Resources.Resources.P5by5
        Me.tsBtnShortCut_P5by5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnShortCut_P5by5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnShortCut_P5by5.Name = "tsBtnShortCut_P5by5"
        Me.tsBtnShortCut_P5by5.Size = New System.Drawing.Size(50, 50)
        Me.tsBtnShortCut_P5by5.Text = "5 * 5"
        Me.tsBtnShortCut_P5by5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsBtnShortCut_P5by5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsBtnShortCut_P5by5.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsBtnPointColor1
        '
        Me.tsBtnPointColor1.AutoSize = False
        Me.tsBtnPointColor1.Image = Global.M7000.My.Resources.Resources._1_menu
        Me.tsBtnPointColor1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnPointColor1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnPointColor1.Name = "tsBtnPointColor1"
        Me.tsBtnPointColor1.Size = New System.Drawing.Size(40, 50)
        Me.tsBtnPointColor1.Text = "색1"
        Me.tsBtnPointColor1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsBtnPointColor1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsBtnPointColor1.Visible = False
        '
        'tsBtnPointColor2
        '
        Me.tsBtnPointColor2.AutoSize = False
        Me.tsBtnPointColor2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnPointColor2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnPointColor2.Name = "tsBtnPointColor2"
        Me.tsBtnPointColor2.Size = New System.Drawing.Size(40, 50)
        Me.tsBtnPointColor2.Text = "색2"
        Me.tsBtnPointColor2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tsBtnPointColor2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsBtnPointColor2.Visible = False
        '
        'ToolStripColorPicker2
        '
        Me.ToolStripColorPicker2.AutoSize = False
        Me.ToolStripColorPicker2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripColorPicker2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripColorPicker2.ButtonDisplayStyle = OfficePickers.ColorPicker.ToolStripColorPickerDisplayType.NormalImage
        Me.ToolStripColorPicker2.Color = System.Drawing.Color.Black
        Me.ToolStripColorPicker2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripColorPicker2.Image = Global.M7000.My.Resources.Resources.Color
        Me.ToolStripColorPicker2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripColorPicker2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripColorPicker2.Name = "ToolStripColorPicker2"
        Me.ToolStripColorPicker2.Size = New System.Drawing.Size(50, 50)
        Me.ToolStripColorPicker2.Text = "aaa"
        Me.ToolStripColorPicker2.ToolTipText = ""
        Me.ToolStripColorPicker2.Visible = False
        '
        'spcMain
        '
        Me.spcMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spcMain.IsSplitterFixed = True
        Me.spcMain.Location = New System.Drawing.Point(3, 61)
        Me.spcMain.Name = "spcMain"
        '
        'spcMain.Panel1
        '
        Me.spcMain.Panel1.Controls.Add(Me.UcDispTarget_PanelModuel1)
        '
        'spcMain.Panel2
        '
        Me.spcMain.Panel2.Controls.Add(Me.gbPosition)
        Me.spcMain.Panel2.Controls.Add(Me.gbMargin)
        Me.spcMain.Panel2.Controls.Add(Me.gbPointList)
        Me.spcMain.Size = New System.Drawing.Size(646, 460)
        Me.spcMain.SplitterDistance = 370
        Me.spcMain.SplitterWidth = 3
        Me.spcMain.TabIndex = 17
        '
        'UcDispTarget_PanelModuel1
        '
        Me.UcDispTarget_PanelModuel1.Location = New System.Drawing.Point(88, 7)
        Me.UcDispTarget_PanelModuel1.Name = "UcDispTarget_PanelModuel1"
        Me.UcDispTarget_PanelModuel1.PointColor = System.Drawing.Color.Empty
        Me.UcDispTarget_PanelModuel1.Size = New System.Drawing.Size(217, 378)
        Me.UcDispTarget_PanelModuel1.TabIndex = 12
        Me.UcDispTarget_PanelModuel1.TargetType = M7000.ucSampleInfos.eSampleType.eCell
        Me.UcDispTarget_PanelModuel1.Temp = 0.0R
        '
        'gbPosition
        '
        Me.gbPosition.Controls.Add(Me.btnPosAdd)
        Me.gbPosition.Controls.Add(Me.Label4)
        Me.gbPosition.Controls.Add(Me.tbInput_YPos)
        Me.gbPosition.Controls.Add(Me.tbInput_XPos)
        Me.gbPosition.Controls.Add(Me.Label3)
        Me.gbPosition.Location = New System.Drawing.Point(4, 5)
        Me.gbPosition.Name = "gbPosition"
        Me.gbPosition.Size = New System.Drawing.Size(261, 47)
        Me.gbPosition.TabIndex = 19
        Me.gbPosition.TabStop = False
        Me.gbPosition.Text = "Position Add"
        '
        'btnPosAdd
        '
        Me.btnPosAdd.Location = New System.Drawing.Point(186, 13)
        Me.btnPosAdd.Name = "btnPosAdd"
        Me.btnPosAdd.Size = New System.Drawing.Size(63, 28)
        Me.btnPosAdd.TabIndex = 23
        Me.btnPosAdd.Text = "Add"
        Me.btnPosAdd.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 12)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = " X :"
        '
        'tbInput_YPos
        '
        Me.tbInput_YPos.Location = New System.Drawing.Point(120, 15)
        Me.tbInput_YPos.Name = "tbInput_YPos"
        Me.tbInput_YPos.Size = New System.Drawing.Size(54, 21)
        Me.tbInput_YPos.TabIndex = 22
        Me.tbInput_YPos.Text = "0"
        Me.tbInput_YPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbInput_XPos
        '
        Me.tbInput_XPos.Location = New System.Drawing.Point(41, 15)
        Me.tbInput_XPos.Name = "tbInput_XPos"
        Me.tbInput_XPos.Size = New System.Drawing.Size(54, 21)
        Me.tbInput_XPos.TabIndex = 20
        Me.tbInput_XPos.Text = "0"
        Me.tbInput_XPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(96, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 12)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = " Y :"
        '
        'ucDispPointSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.spcMain)
        Me.Controls.Add(Me.ToolStrip)
        Me.DoubleBuffered = True
        Me.Name = "ucDispPointSetting"
        Me.Size = New System.Drawing.Size(659, 524)
        Me.gbPointList.ResumeLayout(False)
        Me.gbMargin.ResumeLayout(False)
        Me.gbMargin.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.spcMain.Panel1.ResumeLayout(False)
        Me.spcMain.Panel2.ResumeLayout(False)
        CType(Me.spcMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcMain.ResumeLayout(False)
        Me.gbPosition.ResumeLayout(False)
        Me.gbPosition.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents gbPointList As System.Windows.Forms.GroupBox
    Friend WithEvents UcDispListView1 As M7000.ucDispListView
    Friend WithEvents UcDispTarget_PanelModuel1 As M7000.ucDispTarget_PanelModuel
    Friend WithEvents gbMargin As System.Windows.Forms.GroupBox
    Friend WithEvents tbMarginY As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbMarginX As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsBtnShortCut_P1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnShortCut_P2by2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnShortCut_P3by3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnShortCut_P3by4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnShortCut_P5by5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripColorPicker2 As OfficePickers.ColorPicker.ToolStripColorPicker
    Friend WithEvents tsBtnPointColor1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnPointColor2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents spcMain As System.Windows.Forms.SplitContainer
    Friend WithEvents gbPosition As System.Windows.Forms.GroupBox
    Friend WithEvents btnPosAdd As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbInput_YPos As System.Windows.Forms.TextBox
    Friend WithEvents tbInput_XPos As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
