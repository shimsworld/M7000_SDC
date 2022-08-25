Public Class ucDispSampleUnitCell
    Inherits ucDispSampleCommonNode

#Region "Define"


#End Region


#Region "Delegate Functions"

    Private Delegate Sub DelSetDouble(ByVal dValue As Double)
    Private Delegate Sub DelSetString(ByVal str As String)
    Dim time As Double
    Dim ConvertTime As Integer
    Private Sub DispTemp(ByVal dValue As Double)  'ByVal label As System.Windows.Forms.StatusStrip,
        If lblIndicator_Temp.InvokeRequired = True Then
            Dim del2 As DelSetDouble = New DelSetDouble(AddressOf DispTemp)
            Try
                Invoke(del2, dValue)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblIndicator_Temp.Text = CStr(dValue)
        End If
    End Sub

    Private Sub DispStatus(ByVal str As String)
        If lblCellArea.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf DispStatus)
            Invoke(del2, str)
        Else
            lblCellArea.Text = str
        End If
    End Sub

#End Region

#Region "Properties"

    Public Overrides Property Title As String
        Get
            Return MyBase.m_sCellTitle
        End Get
        Set(ByVal value As String)
            MyBase.m_sCellTitle = value
            lblTitle.Text = MyBase.m_sCellTitle

        End Set
    End Property




    Public Overrides Property Channel As Integer
        Get
            Return MyBase.Channel
        End Get
        Set(ByVal value As Integer)
            MyBase.Channel = value
            Me.ToolTip1.SetToolTip(Me.lblTitle, "Channel = " & Format(MyBase.m_nChNo + 1, "000"))
        End Set
    End Property

    Public Overrides Property OutlineWidth As Double
        Get
            Return m_dOutlineWidth
        End Get
        Set(ByVal value As Double)
            m_dOutlineWidth = value
            sizeFit()
        End Set
    End Property

    Public Overrides Property OutlineColor_Selected As Color
        Get
            Return m_OutlineColor_Selected
        End Get
        Set(ByVal value As Color)
            m_OutlineColor_UnSelected = value
            updateDisplay()
        End Set
    End Property

    Public Overrides Property OutlineColor_Unselected As Color
        Get
            Return m_OutlineColor_UnSelected
        End Get
        Set(ByVal value As Color)
            m_OutlineColor_UnSelected = value
            updateDisplay()
        End Set
    End Property

    Public Overrides Property IsSelected As Boolean
        Get
            Return m_bIsSelected
        End Get
        Set(ByVal value As Boolean)
            m_bIsSelected = value
            updateDisplay()
        End Set
    End Property

    Public Overrides Property CellStatus As eCellState
        Get
            Return m_CellSatus
        End Get
        Set(ByVal value As eCellState)
            m_CellSatus = value
            updateDisplay()
        End Set
    End Property

    Public Overrides Property CellColor_ON As Color
        Get
            Return m_CellColor_ON
        End Get
        Set(ByVal value As Color)
            m_CellColor_ON = value
            updateDisplay()
        End Set
    End Property

    Public Overrides Property CellColor_OFF As Color
        Get
            Return m_CellColor_OFF
        End Get
        Set(ByVal value As Color)
            m_CellColor_OFF = value
            updateDisplay()
        End Set
    End Property

    Public Overrides Property CellColor_Meas As Color
        Get
            Return m_CellColor_Meas
        End Get
        Set(ByVal value As Color)
            m_CellColor_Meas = value
            updateDisplay()
        End Set
    End Property


    Public Overrides Property IsLoadedSequenceInfo As Boolean
        Get
            Return m_bIsLoadedSeq
        End Get
        Set(ByVal value As Boolean)
            m_bIsLoadedSeq = value
            If m_bIsLoadedSeq = True Then
                lblSeqLoadStatus.BackColor = Color.OrangeRed
            Else
                lblSeqLoadStatus.BackColor = Color.Transparent
            End If
        End Set
    End Property


    Public Overrides Property IsLoadedSavePath As Boolean
        Get
            Return MyBase.IsLoadedSavePath
        End Get
        Set(ByVal value As Boolean)
            MyBase.IsLoadedSavePath = value
            If m_bIsLoadedSavePath = True Then
                lblSavePath.BackColor = Color.SkyBlue
            Else
                lblSavePath.BackColor = Color.Transparent
            End If
        End Set
    End Property


    Public Overrides WriteOnly Property RecipeTitle As String
        Set(ByVal value As String)
            m_sRcpTitle = value
            Me.ToolTip1.SetToolTip(Me.lblSeqLoadStatus, m_sRcpTitle)
        End Set
    End Property

    Public Overrides WriteOnly Property SavePath As String
        Set(ByVal value As String)
            MyBase.SavePath = value
            Me.ToolTip1.SetToolTip(Me.lblSavePath, value)
        End Set
    End Property

    Public Overrides Property Status As CScheduler.eChSchedulerSTATE
        Get
            Return MyBase.Status
        End Get
        Set(ByVal value As CScheduler.eChSchedulerSTATE)
            MyBase.Status = value

            updateStatus()

            'If MyBase.m_nStatus = CScheduler.eChSchedulerSTATE.eChangeTemp_Stabilization Then
            '    DispStatus(CScheduler.GetStateCaptions(value) & vbLf & _
            '        Format(m_ModeTime_Current.Hours, "00") & ":" & Format(m_ModeTime_Current.Minutes, "00") & ":" & Format(m_ModeTime_Current.Seconds, "00") & vbLf & _
            '        "[" & CTime.Convert_HourToHMS(m_ModeTime_SetValue.dHour) & "]")
            'ElseIf MyBase.m_nStatus = CScheduler.eChSchedulerSTATE.eLifeTime_Running Then
            '    DispStatus(CScheduler.GetStateCaptions(value) & vbLf & _
            '                        Format(m_ModeTime_Current.Hours, "00") & ":" & Format(m_ModeTime_Current.Minutes, "00") & ":" & Format(m_ModeTime_Current.Seconds, "00") & vbLf & _
            '                        "[" & CTime.Convert_HourToHMS(m_ModeTime_SetValue.dHour) & "]")
            'Else
            '    DispStatus(CScheduler.GetStateCaptions(value))
            'End If

            '       lblCellArea.Text = value
        End Set
    End Property

    Public Overrides Property StatusFont As System.Drawing.Font
        Get
            Return m_StatusFont
        End Get
        Set(ByVal value As System.Drawing.Font)
            MyBase.StatusFont = value
            lblCellArea.Font = value
        End Set
    End Property

    Public Overrides Property Temperatuer As Double
        Get
            Return MyBase.Temperatuer
        End Get
        Set(ByVal value As Double)
            MyBase.Temperatuer = value
            DispTemp(value)
        End Set
    End Property

    Public Overrides Property VisibleTemp As Boolean
        Get
            Return MyBase.VisibleTemp
        End Get
        Set(ByVal value As Boolean)
            MyBase.VisibleTemp = value
            lblIndicator_Temp.Visible = value
        End Set
    End Property


#End Region

#Region "Creator And Initilization"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Public Sub New(ByVal seqMgr As CSequenceManager)
        MyBase.New()
        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        '  MyBase.sequenceMgr = seqMgr
        init()
    End Sub

    Private Sub init()

        tlpMain.Location = New System.Drawing.Point(0, 0)
        tlpMain.Dock = DockStyle.Fill
        pnCellOutline.Dock = DockStyle.Fill
        lblTitle.Dock = DockStyle.Fill
        lblTitle.Text = Format(MyBase.m_nCellNo + 1, "00")
        Me.ToolTip1.SetToolTip(Me.lblTitle, "Channel = " & Format(MyBase.m_nChNo + 1, "000"))
        'm_OutlineColor_Selected = Color.Lime 'd
        'm_OutlineColor_UnSelected = Color.Black
        'm_CellColor_ON = Color.White
        'm_CellColor_OFF = Color.Black
        'm_dOutlineWidth = 3

        sizeFit()
        updateDisplay()
    End Sub

#End Region


#Region "Functions"

    Private Sub sizeFit()

        Dim outlineSize As Size = pnCellOutline.Size

        lblCellArea.Location = New System.Drawing.Point(m_dOutlineWidth, m_dOutlineWidth)

        lblCellArea.Size = New System.Drawing.Size(outlineSize.Width - (m_dOutlineWidth * 2), outlineSize.Height - (m_dOutlineWidth * 2))

    End Sub

    Private Sub updateDisplay()

        'settings.JIGLayoutInfos(i).JIGBackgroundColor = Color.FromArgb(CInt(arrBuf(arrBuf.Length - 1)))     'Color.FromName
        '        settings.JIGLayoutInfos(i).JIGLocation = CSequenceManager.ConvertStringToPoint(AllocationLoa
        Select Case m_CellSatus
            Case eCellState.eOFF
                lblCellArea.BackColor = m_CellColor_OFF
            Case eCellState.eON
                lblCellArea.BackColor = m_CellColor_ON
            Case eCellState.eMeasuring
                lblCellArea.BackColor = m_CellColor_Meas
        End Select

        Dim StateTextColor As Color = Color.FromArgb(Math.Abs(lblCellArea.BackColor.R - 255), Math.Abs(lblCellArea.BackColor.G - 255), Math.Abs(lblCellArea.BackColor.B - 255))
        lblCellArea.ForeColor = StateTextColor

        If m_bIsSelected = True Then
            pnCellOutline.BackColor = m_OutlineColor_Selected
        Else
            pnCellOutline.BackColor = m_OutlineColor_UnSelected
        End If

    End Sub

    Private Sub updateStatus()
        Select Case MyBase.m_nStatus

            Case CScheduler.eChSchedulerSTATE.eChangeTemp_WaitingTemp

                DispStatus(CScheduler.GetStateCaptions(MyBase.m_nStatus) & vbLf & _
                             Format(m_ModeTime_Current.Hours, "00") & ":" & Format(m_ModeTime_Current.Minutes, "00") & ":" & Format(m_ModeTime_Current.Seconds, "00"))

            Case CScheduler.eChSchedulerSTATE.eChangeTemp_Stabilization

                DispStatus(CScheduler.GetStateCaptions(MyBase.m_nStatus) & vbLf & _
                              Format(m_ModeTime_Current.Hours, "00") & ":" & Format(m_ModeTime_Current.Minutes, "00") & ":" & Format(m_ModeTime_Current.Seconds, "00") & vbLf & _
                              "[" & CTime.Convert_HourToHMS(m_ModeTime_SetValue.dHour) & "]")

            Case CScheduler.eChSchedulerSTATE.eLifeTime_SetSourcing

                DispStatus(CScheduler.GetStateCaptions(MyBase.m_nStatus) & vbLf & _
                         Format(m_ModeTime_Current.Hours, "00") & ":" & Format(m_ModeTime_Current.Minutes, "00") & ":" & Format(m_ModeTime_Current.Seconds, "00"))

            Case CScheduler.eChSchedulerSTATE.eAging_Running
                Dim msg As String = Nothing

                msg = CScheduler.GetStateCaptions(MyBase.m_nStatus) & vbLf & Format(m_ModeTime_Current.TotalHours, "00") & ":" & Format(m_ModeTime_Current.Minutes, "00") & ":" & Format(m_ModeTime_Current.Seconds, "00") ' CTime.Convert_HourToHMS(m_ModeTime_Current.Hours) 
                '   DispStatus(CScheduler.GetStateCaptions(MyBase.m_nStatus) & vbLf & _
                '    Format(m_ModeTime_Current.TotalHours, "00") & ":" & Format(m_ModeTime_Current.Minutes, "00") & ":" & Format(m_ModeTime_Current.Seconds, "00") & vbLf & _
                '    "[" & CTime.Convert_HourToHMS(m_ModeTime_SetValue.dHour) & "]")


                If m_DispDatas Is Nothing = False Then
                    For i As Integer = 0 To m_DispDatas.Length - 1
                        msg = msg & vbLf & m_DispDatas(i)
                    Next
                End If

                DispStatus(msg)

            Case CScheduler.eChSchedulerSTATE.eLifeTime_Running
                Dim msg As String = Nothing

                '   msg = CScheduler.GetStateCaptions(MyBase.m_nStatus) & vbLf & Format(m_ModeTime_Current.TotalHours, "00") & ":" & Format(m_ModeTime_Current.Minutes, "00") & ":" & Format(m_ModeTime_Current.Seconds, "00") ' CTime.Convert_HourToHMS(m_ModeTime_Current.Hours) 
                '   DispStatus(CScheduler.GetStateCaptions(MyBase.m_nStatus) & vbLf & _
                '    Format(m_ModeTime_Current.TotalHours, "00") & ":" & Format(m_ModeTime_Current.Minutes, "00") & ":" & Format(m_ModeTime_Current.Seconds, "00") & vbLf & _
                '    "[" & CTime.Convert_HourToHMS(m_ModeTime_SetValue.dHour) & "]")

                '시간반올림되는 현상으로 인해 아래코드 추가함
                time = m_ModeTime_Current.TotalHours
                ConvertTime = Math.Truncate(time)
                '     msg = CScheduler.GetStateCaptions(MyBase.m_nStatus) & vbLf & Format(ConvertTime, "00") & ":" & Format(m_ModeTime_Current.Minutes, "00") & ":" & Format(m_ModeTime_Current.Seconds, "00")

                msg = Format(ConvertTime, "00") & ":" & Format(m_ModeTime_Current.Minutes, "00") & ":" & Format(m_ModeTime_Current.Seconds, "00")

                If m_DispDatas Is Nothing = False Then
                    For i As Integer = 0 To m_DispDatas.Length - 1
                        msg = msg & vbLf & m_DispDatas(i)
                    Next
                End If

                DispStatus(msg)

            Case CScheduler.eChSchedulerSTATE.eIVLSweep

                DispStatus(CScheduler.GetStateCaptions(MyBase.m_nStatus) & vbLf & _
                          Format(m_ModeTime_Current.Hours, "00") & ":" & Format(m_ModeTime_Current.Minutes, "00") & ":" & Format(m_ModeTime_Current.Seconds, "00"))

            Case CScheduler.eChSchedulerSTATE.eChangeNextSeq

                DispStatus(CScheduler.GetStateCaptions(MyBase.m_nStatus) & vbLf & _
                         Format(m_ModeTime_Current.Hours, "00") & ":" & Format(m_ModeTime_Current.Minutes, "00") & ":" & Format(m_ModeTime_Current.Seconds, "00"))
            Case Else
                DispStatus(CScheduler.GetStateCaptions(MyBase.m_nStatus))

        End Select
    End Sub

#End Region


    'Private Sub tlpMain_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tlpMain.MouseClick
    '    If m_bIsSelected = True Then
    '        m_bIsSelected = False
    '    Else
    '        m_bIsSelected = True
    '    End If
    '    updateDisplay()
    'End Sub

#Region "About UI event handler functions"

    Private Sub ucDispUnitCell_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        sizeFit()
    End Sub

#End Region

#Region "Mouse action event handler functions"

    Private Sub pnCellOutline_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnCellOutline.MouseClick

        '  If e.Button = System.Windows.Forms.MouseButtons.Left Then


        cellSelectorUnselect(e)


        ' End If

    End Sub

    Private Sub lblCellArea_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCellArea.MouseClick

        cellSelectorUnselect(e)
        'If e.Button = System.Windows.Forms.MouseButtons.Left Then
        '    If e.Clicks = 1 Then
        '        For i As Integer = 0 To e.Clicks - 1
        '            If m_bIsSelected = True Then
        '                m_bIsSelected = False
        '            Else
        '                m_bIsSelected = True
        '            End If

        '            updateDisplay()

        '            MyBase.SelectStateChange(m_bIsSelected)
        '        Next

        '    End If
        'End If
    End Sub


    Private Sub lblTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTitle.Click
        cellSelectorUnselect(e)
    End Sub

    Private Sub lblSeqLoadStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSeqLoadStatus.Click
        cellSelectorUnselect(e)
    End Sub

    Private Sub lblSavePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSavePath.Click
        cellSelectorUnselect(e)
    End Sub

    Private Sub lblIndicator_Temp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblIndicator_Temp.Click
        cellSelectorUnselect(e)
    End Sub


    Private Sub tlpMain_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tlpMain.MouseClick
        cellSelectorUnselect(e)
    End Sub

    Private Sub tlpTopLayer_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tlpTopLayer.MouseClick
        cellSelectorUnselect(e)
    End Sub

    'Private Sub lblCellArea_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCellArea.MouseDoubleClick
    '    If e.Button = System.Windows.Forms.MouseButtons.Left Then

    '        If e.Clicks = 2 Then

    '        End If

    '        'Dim dlg As New CMcFile
    '        'Dim fileInfo As CMcFile.sFILENAME

    '        'If dlg.GetLoadFileName(CMcFile.eFileType.eCSV, fileInfo) = True Then

    '        'End If
    '        'For i As Integer = 0 To e.Clicks - 1
    '        '    If m_bIsSelected = True Then
    '        '        m_bIsSelected = False
    '        '    Else
    '        '        m_bIsSelected = True
    '        '    End If

    '        '    updateDisplay()
    '        'Next

    '    End If
    'End Sub

    Private Sub ucDispUnitCell_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover

    End Sub

    Private Sub ucDispUnitCell_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave

    End Sub

#End Region


#Region "Context Menu Event handler functions"


    Private Sub 실험시작ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub 실험정지ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    'Private Sub LoadSequenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If sequenceMgr.LoadTestSequence() = False Then
    '        MsgBox("Canceled")
    '    Else
    '        '   dispCh(ch).RecipeTitle(sequenceMgr(ch).SequenceInfo.sSampleInfos.sTitle)
    '        'm_SampleInfo()
    '    End If

    'End Sub

    Private Sub SaveSequenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub EditSequenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim builder As New frmSequenceBuilder

        If builder.ShowDialog = DialogResult.OK Then

            'MyBase.sequenceMgr(ch) = builder.se
        End If
    End Sub

#End Region


    Private Sub cellSelectorUnselect(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = System.Windows.Forms.MouseButtons.Left Then

            For i As Integer = 0 To e.Clicks - 1
                If m_bIsSelected = True Then
                    m_bIsSelected = False
                Else
                    m_bIsSelected = True
                End If

                updateDisplay()


                MyBase.SelectStateChange(m_bIsSelected)
            Next

        End If

    End Sub



End Class
