<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditJIGLayout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditJIGLayout))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsBtnOK = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tstbClientSizeWidth = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.tstbClientSizeHeight = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.tstbLocationX = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.tstbLocationY = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtnMove = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsBtnOK, Me.tsBtnCancel, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.tstbClientSizeWidth, Me.ToolStripSeparator2, Me.ToolStripLabel2, Me.tstbClientSizeHeight, Me.ToolStripSeparator3, Me.ToolStripLabel3, Me.ToolStripSeparator4, Me.ToolStripLabel4, Me.tstbLocationX, Me.ToolStripSeparator5, Me.ToolStripLabel5, Me.tstbLocationY, Me.ToolStripSeparator6, Me.tsBtnMove})
        Me.ToolStrip1.Location = New System.Drawing.Point(517, 9)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(712, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsBtnOK
        '
        Me.tsBtnOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsBtnOK.Image = CType(resources.GetObject("tsBtnOK.Image"), System.Drawing.Image)
        Me.tsBtnOK.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnOK.Name = "tsBtnOK"
        Me.tsBtnOK.Size = New System.Drawing.Size(27, 22)
        Me.tsBtnOK.Text = "OK"
        '
        'tsBtnCancel
        '
        Me.tsBtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsBtnCancel.Image = CType(resources.GetObject("tsBtnCancel.Image"), System.Drawing.Image)
        Me.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnCancel.Name = "tsBtnCancel"
        Me.tsBtnCancel.Size = New System.Drawing.Size(47, 22)
        Me.tsBtnCancel.Text = "Cancel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(46, 22)
        Me.ToolStripLabel1.Text = "Width :"
        '
        'tstbClientSizeWidth
        '
        Me.tstbClientSizeWidth.Name = "tstbClientSizeWidth"
        Me.tstbClientSizeWidth.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripLabel2.Text = "Height :"
        '
        'tstbClientSizeHeight
        '
        Me.tstbClientSizeHeight.Name = "tstbClientSizeHeight"
        Me.tstbClientSizeHeight.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Margin = New System.Windows.Forms.Padding(0, 0, 50, 0)
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripLabel3.Text = "Location"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(21, 22)
        Me.ToolStripLabel4.Text = "X :"
        '
        'tstbLocationX
        '
        Me.tstbLocationX.Name = "tstbLocationX"
        Me.tstbLocationX.Size = New System.Drawing.Size(50, 25)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(21, 22)
        Me.ToolStripLabel5.Text = "Y :"
        '
        'tstbLocationY
        '
        Me.tstbLocationY.Name = "tstbLocationY"
        Me.tstbLocationY.Size = New System.Drawing.Size(50, 25)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tsBtnMove
        '
        Me.tsBtnMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsBtnMove.Image = CType(resources.GetObject("tsBtnMove.Image"), System.Drawing.Image)
        Me.tsBtnMove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnMove.Name = "tsBtnMove"
        Me.tsBtnMove.Size = New System.Drawing.Size(41, 22)
        Me.tsBtnMove.Text = "Move"
        '
        'frmEditJIGLayout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1303, 579)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmEditJIGLayout"
        Me.Text = "JIG Location Editor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsBtnOK As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsBtnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstbClientSizeWidth As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstbClientSizeHeight As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstbLocationX As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstbLocationY As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsBtnMove As System.Windows.Forms.ToolStripButton
End Class
