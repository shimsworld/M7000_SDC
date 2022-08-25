<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDispCtrlUIOfCustomTypeForQC
    Inherits M7000.ucDispCtrlUICommonNode

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
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.spcModeTime = New System.Windows.Forms.TableLayoutPanel()
        Me.lblModeTime_Current = New System.Windows.Forms.Label()
        Me.lblModeTime_SetValue = New System.Windows.Forms.Label()
        Me.tlpFuncButton = New System.Windows.Forms.TableLayoutPanel()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.spcTotalTime = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTotalTime_Current = New System.Windows.Forms.Label()
        Me.lblTotalTime_SetValue = New System.Windows.Forms.Label()
        Me.labelReserve = New System.Windows.Forms.Label()
        Me.lblReserve = New System.Windows.Forms.Label()
        Me.lblLoopCounter = New System.Windows.Forms.Label()
        Me.labelLoop = New System.Windows.Forms.Label()
        Me.labelTemp = New System.Windows.Forms.Label()
        Me.lblTemp = New System.Windows.Forms.Label()
        Me.lblRecipeName = New System.Windows.Forms.Label()
        Me.labelRecipe = New System.Windows.Forms.Label()
        Me.labelModeTime = New System.Windows.Forms.Label()
        Me.labelTotalTime = New System.Windows.Forms.Label()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.labelProgress = New System.Windows.Forms.Label()
        Me.labelResult = New System.Windows.Forms.Label()
        Me.labelState = New System.Windows.Forms.Label()
        Me.pnChSelector = New System.Windows.Forms.Panel()
        Me.chkCh = New System.Windows.Forms.CheckBox()
        Me.tlpMain.SuspendLayout()
        Me.spcModeTime.SuspendLayout()
        Me.tlpFuncButton.SuspendLayout()
        Me.spcTotalTime.SuspendLayout()
        Me.pnChSelector.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.tlpMain.ColumnCount = 11
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.757235!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.05662!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.578942!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.524575!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.71515!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.6676!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.73049!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.429088!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.540288!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 401.0!))
        Me.tlpMain.Controls.Add(Me.spcModeTime, 5, 1)
        Me.tlpMain.Controls.Add(Me.tlpFuncButton, 10, 0)
        Me.tlpMain.Controls.Add(Me.spcTotalTime, 4, 1)
        Me.tlpMain.Controls.Add(Me.labelReserve, 9, 0)
        Me.tlpMain.Controls.Add(Me.lblReserve, 9, 1)
        Me.tlpMain.Controls.Add(Me.lblLoopCounter, 8, 1)
        Me.tlpMain.Controls.Add(Me.labelLoop, 8, 0)
        Me.tlpMain.Controls.Add(Me.labelTemp, 7, 0)
        Me.tlpMain.Controls.Add(Me.lblTemp, 7, 1)
        Me.tlpMain.Controls.Add(Me.lblRecipeName, 6, 1)
        Me.tlpMain.Controls.Add(Me.labelRecipe, 6, 0)
        Me.tlpMain.Controls.Add(Me.labelModeTime, 5, 0)
        Me.tlpMain.Controls.Add(Me.labelTotalTime, 4, 0)
        Me.tlpMain.Controls.Add(Me.lblProgress, 3, 1)
        Me.tlpMain.Controls.Add(Me.lblResult, 2, 1)
        Me.tlpMain.Controls.Add(Me.lblStatus, 1, 1)
        Me.tlpMain.Controls.Add(Me.labelProgress, 3, 0)
        Me.tlpMain.Controls.Add(Me.labelResult, 2, 0)
        Me.tlpMain.Controls.Add(Me.labelState, 1, 0)
        Me.tlpMain.Controls.Add(Me.pnChSelector, 0, 0)
        Me.tlpMain.Location = New System.Drawing.Point(3, 3)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(1440, 107)
        Me.tlpMain.TabIndex = 1
        '
        'spcModeTime
        '
        Me.spcModeTime.ColumnCount = 1
        Me.spcModeTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.spcModeTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.spcModeTime.Controls.Add(Me.lblModeTime_Current, 0, 1)
        Me.spcModeTime.Controls.Add(Me.lblModeTime_SetValue, 0, 0)
        Me.spcModeTime.Location = New System.Drawing.Point(489, 30)
        Me.spcModeTime.Name = "spcModeTime"
        Me.spcModeTime.RowCount = 2
        Me.spcModeTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.spcModeTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.spcModeTime.Size = New System.Drawing.Size(99, 64)
        Me.spcModeTime.TabIndex = 3
        '
        'lblModeTime_Current
        '
        Me.lblModeTime_Current.BackColor = System.Drawing.Color.Transparent
        Me.lblModeTime_Current.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModeTime_Current.ForeColor = System.Drawing.Color.Black
        Me.lblModeTime_Current.Location = New System.Drawing.Point(9, 37)
        Me.lblModeTime_Current.Margin = New System.Windows.Forms.Padding(9, 5, 4, 11)
        Me.lblModeTime_Current.Name = "lblModeTime_Current"
        Me.lblModeTime_Current.Size = New System.Drawing.Size(84, 16)
        Me.lblModeTime_Current.TabIndex = 12
        Me.lblModeTime_Current.Text = "00:00:00"
        Me.lblModeTime_Current.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblModeTime_SetValue
        '
        Me.lblModeTime_SetValue.BackColor = System.Drawing.Color.Transparent
        Me.lblModeTime_SetValue.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModeTime_SetValue.ForeColor = System.Drawing.Color.Black
        Me.lblModeTime_SetValue.Location = New System.Drawing.Point(9, 5)
        Me.lblModeTime_SetValue.Margin = New System.Windows.Forms.Padding(9, 5, 4, 11)
        Me.lblModeTime_SetValue.Name = "lblModeTime_SetValue"
        Me.lblModeTime_SetValue.Size = New System.Drawing.Size(84, 15)
        Me.lblModeTime_SetValue.TabIndex = 12
        Me.lblModeTime_SetValue.Text = "00:00:00"
        Me.lblModeTime_SetValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tlpFuncButton
        '
        Me.tlpFuncButton.BackColor = System.Drawing.Color.White
        Me.tlpFuncButton.ColumnCount = 1
        Me.tlpFuncButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFuncButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.tlpFuncButton.Controls.Add(Me.btnEdit, 0, 2)
        Me.tlpFuncButton.Controls.Add(Me.btnLoad, 0, 0)
        Me.tlpFuncButton.Controls.Add(Me.btnSave, 0, 1)
        Me.tlpFuncButton.Location = New System.Drawing.Point(1033, 2)
        Me.tlpFuncButton.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpFuncButton.Name = "tlpFuncButton"
        Me.tlpFuncButton.RowCount = 3
        Me.tlpMain.SetRowSpan(Me.tlpFuncButton, 2)
        Me.tlpFuncButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpFuncButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpFuncButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpFuncButton.Size = New System.Drawing.Size(40, 79)
        Me.tlpFuncButton.TabIndex = 29
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(3, 55)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(34, 21)
        Me.btnEdit.TabIndex = 21
        Me.btnEdit.Text = "EDIT"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(3, 3)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(34, 20)
        Me.btnLoad.TabIndex = 19
        Me.btnLoad.Text = "LOAD"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 29)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(34, 20)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'spcTotalTime
        '
        Me.spcTotalTime.ColumnCount = 1
        Me.spcTotalTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.spcTotalTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.spcTotalTime.Controls.Add(Me.lblTotalTime_Current, 0, 1)
        Me.spcTotalTime.Controls.Add(Me.lblTotalTime_SetValue, 0, 0)
        Me.spcTotalTime.Location = New System.Drawing.Point(391, 30)
        Me.spcTotalTime.Name = "spcTotalTime"
        Me.spcTotalTime.RowCount = 2
        Me.spcTotalTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.spcTotalTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.spcTotalTime.Size = New System.Drawing.Size(89, 59)
        Me.spcTotalTime.TabIndex = 2
        '
        'lblTotalTime_Current
        '
        Me.lblTotalTime_Current.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalTime_Current.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalTime_Current.ForeColor = System.Drawing.Color.Black
        Me.lblTotalTime_Current.Location = New System.Drawing.Point(9, 34)
        Me.lblTotalTime_Current.Margin = New System.Windows.Forms.Padding(9, 5, 4, 11)
        Me.lblTotalTime_Current.Name = "lblTotalTime_Current"
        Me.lblTotalTime_Current.Size = New System.Drawing.Size(76, 13)
        Me.lblTotalTime_Current.TabIndex = 12
        Me.lblTotalTime_Current.Text = "00:00:00"
        Me.lblTotalTime_Current.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalTime_SetValue
        '
        Me.lblTotalTime_SetValue.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalTime_SetValue.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalTime_SetValue.ForeColor = System.Drawing.Color.Black
        Me.lblTotalTime_SetValue.Location = New System.Drawing.Point(9, 5)
        Me.lblTotalTime_SetValue.Margin = New System.Windows.Forms.Padding(9, 5, 4, 11)
        Me.lblTotalTime_SetValue.Name = "lblTotalTime_SetValue"
        Me.lblTotalTime_SetValue.Size = New System.Drawing.Size(69, 11)
        Me.lblTotalTime_SetValue.TabIndex = 12
        Me.lblTotalTime_SetValue.Text = "00:00:00"
        Me.lblTotalTime_SetValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelReserve
        '
        Me.labelReserve.AutoSize = True
        Me.labelReserve.BackColor = System.Drawing.Color.Black
        Me.labelReserve.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.labelReserve.ForeColor = System.Drawing.Color.White
        Me.labelReserve.Location = New System.Drawing.Point(924, 2)
        Me.labelReserve.Name = "labelReserve"
        Me.labelReserve.Size = New System.Drawing.Size(56, 15)
        Me.labelReserve.TabIndex = 26
        Me.labelReserve.Text = "RESERVE"
        Me.labelReserve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblReserve
        '
        Me.lblReserve.BackColor = System.Drawing.Color.Transparent
        Me.lblReserve.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblReserve.ForeColor = System.Drawing.Color.Black
        Me.lblReserve.Location = New System.Drawing.Point(930, 32)
        Me.lblReserve.Margin = New System.Windows.Forms.Padding(9, 5, 4, 11)
        Me.lblReserve.Name = "lblReserve"
        Me.lblReserve.Size = New System.Drawing.Size(60, 62)
        Me.lblReserve.TabIndex = 6
        Me.lblReserve.Text = "Etc"
        Me.lblReserve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLoopCounter
        '
        Me.lblLoopCounter.BackColor = System.Drawing.Color.Transparent
        Me.lblLoopCounter.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblLoopCounter.ForeColor = System.Drawing.Color.Black
        Me.lblLoopCounter.Location = New System.Drawing.Point(860, 32)
        Me.lblLoopCounter.Margin = New System.Windows.Forms.Padding(9, 5, 4, 11)
        Me.lblLoopCounter.Name = "lblLoopCounter"
        Me.lblLoopCounter.Size = New System.Drawing.Size(34, 62)
        Me.lblLoopCounter.TabIndex = 7
        Me.lblLoopCounter.Text = "Cnt"
        Me.lblLoopCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelLoop
        '
        Me.labelLoop.AutoSize = True
        Me.labelLoop.BackColor = System.Drawing.Color.Black
        Me.labelLoop.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.labelLoop.ForeColor = System.Drawing.Color.White
        Me.labelLoop.Location = New System.Drawing.Point(854, 2)
        Me.labelLoop.Name = "labelLoop"
        Me.labelLoop.Size = New System.Drawing.Size(37, 15)
        Me.labelLoop.TabIndex = 25
        Me.labelLoop.Text = "Cycle"
        Me.labelLoop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelTemp
        '
        Me.labelTemp.AutoSize = True
        Me.labelTemp.BackColor = System.Drawing.Color.Black
        Me.labelTemp.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.labelTemp.ForeColor = System.Drawing.Color.White
        Me.labelTemp.Location = New System.Drawing.Point(794, 2)
        Me.labelTemp.Name = "labelTemp"
        Me.labelTemp.Size = New System.Drawing.Size(39, 15)
        Me.labelTemp.TabIndex = 24
        Me.labelTemp.Text = "TEMP"
        Me.labelTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTemp
        '
        Me.lblTemp.BackColor = System.Drawing.Color.Transparent
        Me.lblTemp.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblTemp.ForeColor = System.Drawing.Color.Black
        Me.lblTemp.Location = New System.Drawing.Point(800, 32)
        Me.lblTemp.Margin = New System.Windows.Forms.Padding(9, 5, 4, 11)
        Me.lblTemp.Name = "lblTemp"
        Me.lblTemp.Size = New System.Drawing.Size(45, 62)
        Me.lblTemp.TabIndex = 8
        Me.lblTemp.Text = "T(℃)"
        Me.lblTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRecipeName
        '
        Me.lblRecipeName.BackColor = System.Drawing.Color.Transparent
        Me.lblRecipeName.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblRecipeName.ForeColor = System.Drawing.Color.Black
        Me.lblRecipeName.Location = New System.Drawing.Point(602, 32)
        Me.lblRecipeName.Margin = New System.Windows.Forms.Padding(9, 5, 4, 11)
        Me.lblRecipeName.Name = "lblRecipeName"
        Me.lblRecipeName.Size = New System.Drawing.Size(109, 62)
        Me.lblRecipeName.TabIndex = 9
        Me.lblRecipeName.Text = "Recipe Title"
        Me.lblRecipeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelRecipe
        '
        Me.labelRecipe.AutoSize = True
        Me.labelRecipe.BackColor = System.Drawing.Color.Black
        Me.labelRecipe.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.labelRecipe.ForeColor = System.Drawing.Color.White
        Me.labelRecipe.Location = New System.Drawing.Point(596, 2)
        Me.labelRecipe.Name = "labelRecipe"
        Me.labelRecipe.Size = New System.Drawing.Size(46, 15)
        Me.labelRecipe.TabIndex = 23
        Me.labelRecipe.Text = "RECIPE"
        Me.labelRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelModeTime
        '
        Me.labelModeTime.AutoSize = True
        Me.labelModeTime.BackColor = System.Drawing.Color.Black
        Me.labelModeTime.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.labelModeTime.ForeColor = System.Drawing.Color.White
        Me.labelModeTime.Location = New System.Drawing.Point(489, 2)
        Me.labelModeTime.Name = "labelModeTime"
        Me.labelModeTime.Size = New System.Drawing.Size(76, 15)
        Me.labelModeTime.TabIndex = 22
        Me.labelModeTime.Text = "MODE TIME"
        Me.labelModeTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelTotalTime
        '
        Me.labelTotalTime.AutoSize = True
        Me.labelTotalTime.BackColor = System.Drawing.Color.Black
        Me.labelTotalTime.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.labelTotalTime.ForeColor = System.Drawing.Color.White
        Me.labelTotalTime.Location = New System.Drawing.Point(391, 2)
        Me.labelTotalTime.Name = "labelTotalTime"
        Me.labelTotalTime.Size = New System.Drawing.Size(77, 15)
        Me.labelTotalTime.TabIndex = 21
        Me.labelTotalTime.Text = "TOTAL TIME"
        Me.labelTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProgress
        '
        Me.lblProgress.BackColor = System.Drawing.Color.Transparent
        Me.lblProgress.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblProgress.ForeColor = System.Drawing.Color.Black
        Me.lblProgress.Location = New System.Drawing.Point(309, 32)
        Me.lblProgress.Margin = New System.Windows.Forms.Padding(9, 5, 4, 11)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(68, 62)
        Me.lblProgress.TabIndex = 11
        Me.lblProgress.Text = "Progress"
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblResult
        '
        Me.lblResult.BackColor = System.Drawing.Color.Transparent
        Me.lblResult.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblResult.ForeColor = System.Drawing.Color.Black
        Me.lblResult.Location = New System.Drawing.Point(230, 32)
        Me.lblResult.Margin = New System.Windows.Forms.Padding(9, 5, 4, 11)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(64, 62)
        Me.lblResult.TabIndex = 14
        Me.lblResult.Text = "Result"
        Me.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(92, 32)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(9, 5, 4, 11)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(116, 62)
        Me.lblStatus.TabIndex = 13
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelProgress
        '
        Me.labelProgress.AutoSize = True
        Me.labelProgress.BackColor = System.Drawing.Color.Black
        Me.labelProgress.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.labelProgress.ForeColor = System.Drawing.Color.White
        Me.labelProgress.Location = New System.Drawing.Point(303, 2)
        Me.labelProgress.Name = "labelProgress"
        Me.labelProgress.Size = New System.Drawing.Size(68, 15)
        Me.labelProgress.TabIndex = 20
        Me.labelProgress.Text = "PROGRESS"
        Me.labelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelResult
        '
        Me.labelResult.AutoSize = True
        Me.labelResult.BackColor = System.Drawing.Color.Black
        Me.labelResult.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.labelResult.ForeColor = System.Drawing.Color.White
        Me.labelResult.Location = New System.Drawing.Point(224, 2)
        Me.labelResult.Name = "labelResult"
        Me.labelResult.Size = New System.Drawing.Size(50, 15)
        Me.labelResult.TabIndex = 19
        Me.labelResult.Text = "RESULT"
        Me.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelState
        '
        Me.labelState.AutoSize = True
        Me.labelState.BackColor = System.Drawing.Color.Black
        Me.labelState.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.labelState.ForeColor = System.Drawing.Color.White
        Me.labelState.Location = New System.Drawing.Point(86, 2)
        Me.labelState.Name = "labelState"
        Me.labelState.Size = New System.Drawing.Size(52, 15)
        Me.labelState.TabIndex = 18
        Me.labelState.Text = "STATUS"
        Me.labelState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnChSelector
        '
        Me.pnChSelector.BackColor = System.Drawing.Color.White
        Me.pnChSelector.Controls.Add(Me.chkCh)
        Me.pnChSelector.Location = New System.Drawing.Point(2, 2)
        Me.pnChSelector.Margin = New System.Windows.Forms.Padding(0)
        Me.pnChSelector.Name = "pnChSelector"
        Me.tlpMain.SetRowSpan(Me.pnChSelector, 2)
        Me.pnChSelector.Size = New System.Drawing.Size(54, 96)
        Me.pnChSelector.TabIndex = 30
        '
        'chkCh
        '
        Me.chkCh.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkCh.BackColor = System.Drawing.Color.LightGray
        Me.chkCh.Location = New System.Drawing.Point(3, 8)
        Me.chkCh.Name = "chkCh"
        Me.chkCh.Size = New System.Drawing.Size(48, 86)
        Me.chkCh.TabIndex = 18
        Me.chkCh.Text = "CHXX"
        Me.chkCh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkCh.UseVisualStyleBackColor = False
        '
        'ucDispCtrlUIOfCustomTypeForQC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucDispCtrlUIOfCustomTypeForQC"
        Me.Size = New System.Drawing.Size(1477, 120)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.spcModeTime.ResumeLayout(False)
        Me.tlpFuncButton.ResumeLayout(False)
        Me.spcTotalTime.ResumeLayout(False)
        Me.pnChSelector.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Private WithEvents lblReserve As System.Windows.Forms.Label
    Private WithEvents lblLoopCounter As System.Windows.Forms.Label
    Private WithEvents lblTemp As System.Windows.Forms.Label
    Private WithEvents lblRecipeName As System.Windows.Forms.Label
    Private WithEvents lblProgress As System.Windows.Forms.Label
    Private WithEvents lblResult As System.Windows.Forms.Label
    Private WithEvents lblStatus As System.Windows.Forms.Label
    Protected WithEvents chkCh As System.Windows.Forms.CheckBox
    Friend WithEvents labelReserve As System.Windows.Forms.Label
    Friend WithEvents labelLoop As System.Windows.Forms.Label
    Friend WithEvents labelTemp As System.Windows.Forms.Label
    Friend WithEvents labelRecipe As System.Windows.Forms.Label
    Friend WithEvents labelModeTime As System.Windows.Forms.Label
    Friend WithEvents labelTotalTime As System.Windows.Forms.Label
    Friend WithEvents labelProgress As System.Windows.Forms.Label
    Friend WithEvents labelResult As System.Windows.Forms.Label
    Friend WithEvents labelState As System.Windows.Forms.Label
    Private WithEvents lblModeTime_SetValue As System.Windows.Forms.Label
    Private WithEvents lblModeTime_Current As System.Windows.Forms.Label
    Private WithEvents lblTotalTime_SetValue As System.Windows.Forms.Label
    Private WithEvents lblTotalTime_Current As System.Windows.Forms.Label
    Friend WithEvents tlpFuncButton As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnChSelector As System.Windows.Forms.Panel
    Friend WithEvents spcModeTime As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents spcTotalTime As System.Windows.Forms.TableLayoutPanel

End Class
