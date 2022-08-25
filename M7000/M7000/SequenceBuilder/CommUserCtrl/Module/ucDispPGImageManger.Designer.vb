<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispPGImageManger
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
        Me.components = New System.ComponentModel.Container()
        Dim ShellItem1 As MBTreeViewExplorer.ShellItem = New MBTreeViewExplorer.ShellItem()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.spContainer = New System.Windows.Forms.SplitContainer()
        Me.pnFolderBrowser = New System.Windows.Forms.Panel()
        Me.folderbrowser = New MBTreeViewExplorer.MBTreeViewExplorer()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.pnPreview = New System.Windows.Forms.Panel()
        Me.FilmstripControl1 = New Filmstrip.FilmstripControl()
        Me.pnFileSercher = New System.Windows.Forms.Panel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.tlpMain.SuspendLayout()
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spContainer.Panel1.SuspendLayout()
        Me.spContainer.Panel2.SuspendLayout()
        Me.spContainer.SuspendLayout()
        Me.pnFolderBrowser.SuspendLayout()
        Me.pnPreview.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.50838!))
        Me.tlpMain.Controls.Add(Me.spContainer, 0, 0)
        Me.tlpMain.Controls.Add(Me.pnFileSercher, 0, 1)
        Me.tlpMain.Location = New System.Drawing.Point(21, 14)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.18278!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9.0!))
        Me.tlpMain.Size = New System.Drawing.Size(1114, 603)
        Me.tlpMain.TabIndex = 0
        '
        'spContainer
        '
        Me.spContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spContainer.Location = New System.Drawing.Point(3, 3)
        Me.spContainer.Name = "spContainer"
        '
        'spContainer.Panel1
        '
        Me.spContainer.Panel1.Controls.Add(Me.pnFolderBrowser)
        '
        'spContainer.Panel2
        '
        Me.spContainer.Panel2.Controls.Add(Me.btnDownload)
        Me.spContainer.Panel2.Controls.Add(Me.btnUpload)
        Me.spContainer.Panel2.Controls.Add(Me.pnPreview)
        Me.spContainer.Size = New System.Drawing.Size(1108, 589)
        Me.spContainer.SplitterDistance = 312
        Me.spContainer.TabIndex = 0
        '
        'pnFolderBrowser
        '
        Me.pnFolderBrowser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnFolderBrowser.Controls.Add(Me.folderbrowser)
        Me.pnFolderBrowser.Location = New System.Drawing.Point(3, 0)
        Me.pnFolderBrowser.Name = "pnFolderBrowser"
        Me.pnFolderBrowser.Size = New System.Drawing.Size(283, 585)
        Me.pnFolderBrowser.TabIndex = 0
        '
        'folderbrowser
        '
        Me.folderbrowser.Location = New System.Drawing.Point(3, -1)
        Me.folderbrowser.Name = "folderbrowser"
        Me.folderbrowser.SelectedFile = ShellItem1
        Me.folderbrowser.Size = New System.Drawing.Size(275, 581)
        Me.folderbrowser.TabIndex = 0
        '
        'btnDownload
        '
        Me.btnDownload.Location = New System.Drawing.Point(636, 550)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(121, 35)
        Me.btnDownload.TabIndex = 2
        Me.btnDownload.Text = "DownLoad"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(491, 550)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(121, 35)
        Me.btnUpload.TabIndex = 1
        Me.btnUpload.Text = "UpLoad"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'pnPreview
        '
        Me.pnPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnPreview.Controls.Add(Me.FilmstripControl1)
        Me.pnPreview.Location = New System.Drawing.Point(3, 1)
        Me.pnPreview.Name = "pnPreview"
        Me.pnPreview.Size = New System.Drawing.Size(786, 549)
        Me.pnPreview.TabIndex = 0
        '
        'FilmstripControl1
        '
        Me.FilmstripControl1.BackColor = System.Drawing.SystemColors.Control
        Me.FilmstripControl1.Location = New System.Drawing.Point(13, 3)
        Me.FilmstripControl1.Name = "FilmstripControl1"
        Me.FilmstripControl1.Size = New System.Drawing.Size(740, 541)
        Me.FilmstripControl1.TabIndex = 0
        '
        'pnFileSercher
        '
        Me.pnFileSercher.AutoScroll = True
        Me.pnFileSercher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnFileSercher.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnFileSercher.Location = New System.Drawing.Point(3, 598)
        Me.pnFileSercher.Name = "pnFileSercher"
        Me.pnFileSercher.Size = New System.Drawing.Size(1108, 2)
        Me.pnFileSercher.TabIndex = 1
        Me.pnFileSercher.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'ucDispPGImageManger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucDispPGImageManger"
        Me.Size = New System.Drawing.Size(1149, 641)
        Me.tlpMain.ResumeLayout(False)
        Me.spContainer.Panel1.ResumeLayout(False)
        Me.spContainer.Panel2.ResumeLayout(False)
        CType(Me.spContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spContainer.ResumeLayout(False)
        Me.pnFolderBrowser.ResumeLayout(False)
        Me.pnPreview.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents pnFileSercher As System.Windows.Forms.Panel
    Friend WithEvents spContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents pnFolderBrowser As System.Windows.Forms.Panel
    Friend WithEvents folderbrowser As MBTreeViewExplorer.MBTreeViewExplorer
    Friend WithEvents pnPreview As System.Windows.Forms.Panel
    Friend WithEvents FilmstripControl1 As Filmstrip.FilmstripControl
    Friend WithEvents btnDownload As System.Windows.Forms.Button
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog


 
End Class
