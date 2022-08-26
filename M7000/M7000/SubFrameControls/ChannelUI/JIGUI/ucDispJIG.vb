Public Class ucDispJIG

#Region "Define"

    Dim m_bIsLoaded As Boolean = False

    Dim m_nJIGNo As Integer 'cell identification number on the JIG
    Dim m_ChannelNo As Integer
    Dim m_OutlineColor_Selected As Color = Color.Lime  'd
    Dim m_OutlineColor_UnSelected As Color = Color.Black
    Dim m_bIsSelected As Boolean
    Dim m_blsChannelSelected As Boolean
    Dim m_dOutlineWidth As Double = 3
    Dim m_JIGColor As Color = Color.LightGray

    Dim m_nPreviouslySelectedCellIdx As Integer '이전에 선택 되었던 채널의 인덱스

    Dim m_bEnableMultiSelect As Boolean

    Dim m_StatusMsgFont As System.Drawing.Font
    Dim m_AddText As String
    Dim m_CellLayout() As Integer = New Integer() {1, 1}  'Col , Row

    Public Shared m_numOfCell As Integer

    Dim Cell() As ucDispSampleUI
    Dim unitCellSize As Size = New System.Drawing.Size(50, 50)
    Dim unitCellMargine As System.Windows.Forms.Padding = New System.Windows.Forms.Padding(2)

    Dim m_cellType As ucSampleInfos.eSampleType '= ucDispRcpCommon.eSampleType.eCell

    Dim m_dTemp As Double



    Public Event evRunExperiment(ByVal nJIGNo As Integer)
    Public Event evStopExperiment(ByVal nJIGNo As Integer)
    Public Event evClickLoadSequence(ByVal nJIGNo As Integer)
    Public Event evClickUnloadSeqeunce(ByVal nJIGNo As Integer)
    Public Event evClickEditSequence()
    Public Event evSavePath(ByVal nJIGNo As Integer)

    Public Event evClickTempIndicator(ByVal nJIGNo As Integer)

#End Region

#Region "Properties"

    Public Property JIGNo As Integer
        Get
            Return m_nJIGNo
        End Get
        Set(ByVal value As Integer)
            m_nJIGNo = value
        End Set
    End Property
  
    Public Property ChannelNo As Integer
        Get
            Return m_ChannelNo
        End Get
        Set(ByVal value As Integer)
            m_ChannelNo = value
        End Set
    End Property

    Public Property OutlineWidth As Double
        Get
            Return m_dOutlineWidth
        End Get
        Set(ByVal value As Double)
            m_dOutlineWidth = value
            updateDisplay()
        End Set
    End Property

    Public Property OutlineColor_Selected As Color
        Get
            Return m_OutlineColor_Selected
        End Get
        Set(ByVal value As Color)
            m_OutlineColor_Selected = value
            updateDisplay()
        End Set
    End Property

    Public Property OutlineColor_Unselected As Color
        Get
            Return m_OutlineColor_UnSelected
        End Get
        Set(ByVal value As Color)
            m_OutlineColor_UnSelected = value
            updateDisplay()
        End Set
    End Property

    Public Property IsSelectedChannel As Boolean
        Get
            Return m_blsChannelSelected
        End Get
        Set(ByVal value As Boolean)
            m_blsChannelSelected = value
            ChNumberSelectDisplay()
        End Set
    End Property

    Public Property IsSelected As Boolean
        Get
            Return m_bIsSelected
        End Get
        Set(ByVal value As Boolean)
            m_bIsSelected = value
            updateDisplay()
        End Set
    End Property


    Public Property JIGColor As Color
        Get
            Return m_JIGColor
        End Get
        Set(ByVal value As Color)
            m_JIGColor = value
            updateDisplay()
        End Set
    End Property

    Public Property CellLayout_Col As Integer
        Get
            Return m_CellLayout(0)
        End Get
        Set(ByVal value As Integer)
            m_CellLayout(0) = value
            SetLocationAndSize()
        End Set
    End Property

    Public Property CellLayout_Row As Integer
        Get
            Return m_CellLayout(1)
        End Get
        Set(ByVal value As Integer)
            m_CellLayout(1) = value
            SetLocationAndSize()
        End Set
    End Property

    Public Property NumberOfCell As Integer
        Get
            Return m_numOfCell
        End Get
        Set(ByVal value As Integer)
            m_numOfCell = value
            AddCell()
            SetLocationAndSize()
        End Set
    End Property

    Public Property SampleType As ucSampleInfos.eSampleType
        Get
            Return m_cellType
        End Get
        Set(ByVal value As ucSampleInfos.eSampleType)
            m_cellType = value
            AddCell()
            SetLocationAndSize()
        End Set
    End Property

    Public WriteOnly Property EnableUI As Boolean
        Set(ByVal value As Boolean)
            EnabledJIG(value)
        End Set
    End Property

    Public WriteOnly Property Temp As Double
        Set(ByVal value As Double)
            m_dTemp = value
            IndicatorTemp(m_dTemp)
        End Set
    End Property


    Public WriteOnly Property VisibleTemp As Boolean
        Set(ByVal value As Boolean)
            lblIndicator_Temp.Visible = value
        End Set
    End Property

    Public Property StatusMsgFont As System.Drawing.Font
        Get
            Return m_StatusMsgFont
        End Get
        Set(ByVal value As System.Drawing.Font)
            m_StatusMsgFont = value
        End Set
    End Property

    Public Property PreviouslySelectedCellIdx As Integer
        Get
            Return m_nPreviouslySelectedCellIdx
        End Get
        Set(value As Integer)
            m_nPreviouslySelectedCellIdx = value
        End Set
    End Property

    Public Property EnabelMultiSelect As Boolean
        Get
            Return m_bEnableMultiSelect
        End Get
        Set(value As Boolean)
            m_bEnableMultiSelect = value
        End Set
    End Property

    Public ReadOnly Property GetJIGNumberToTEGName(ByVal nJIG As Integer) As String
        Get
            Return convertIncNumberToMatrixValue(nJIG)
        End Get
    End Property

#End Region

#Region "Delegate Functions"

    Private Delegate Sub DelSetDouble(ByVal dValue As Double)
    Private Delegate Sub DelSetBoolean(ByVal bool As Boolean)

    Private Sub EnabledJIG(ByVal bool As Boolean)
        If tlpMain.InvokeRequired = True Then
            Dim del2 As DelSetBoolean = New DelSetBoolean(AddressOf EnabledJIG)
            Try
                Invoke(del2, bool)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tlpMain.Enabled = bool
        End If
    End Sub

    Private Sub IndicatorTemp(ByVal dValue As Double)  'ByVal label As System.Windows.Forms.StatusStrip,
        If lblIndicator_Temp.InvokeRequired = True Then
            Dim del2 As DelSetDouble = New DelSetDouble(AddressOf IndicatorTemp)
            Try
                Invoke(del2, dValue)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblIndicator_Temp.Text = CStr(dValue) '& " ℃"
        End If
    End Sub

#End Region

#Region "Creator And Initilization"

    Public Sub New()
        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Public Sub New(ByVal dispCh() As ucDispSampleUI, ByVal JIGInfos As frmSettingWind.sJIGLayoutInfo)
        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        Cell = dispCh
        m_numOfCell = dispCh.Length
        m_cellType = JIGInfos.sampleType
        m_CellLayout(0) = JIGInfos.CellLayoutCol
        m_CellLayout(1) = JIGInfos.CellLayoutRow
        m_nJIGNo = JIGInfos.JIGNo
        m_dOutlineWidth = JIGInfos.JIGOutlineWidth
        m_OutlineColor_Selected = JIGInfos.JIGOutlineColor_Selected
        m_OutlineColor_UnSelected = JIGInfos.JIGOutlineColor_Unselected
        m_JIGColor = JIGInfos.JIGBackgroundColor
        m_StatusMsgFont = JIGInfos.statusMsgFont
        m_bEnableMultiSelect = JIGInfos.JIGSelectToMultiChannelSelect
        m_AddText = JIGInfos.AddText
        ' m_numOfCell = JIGInfos.numOfSample
        init()
    End Sub

    Private Sub init()

        tlpMain.Location = New System.Drawing.Point(0, 0)
        tlpMain.Dock = DockStyle.Fill
        pnJIGOutline.Dock = DockStyle.Fill
        lblTitle.Dock = DockStyle.Fill

        '220826 Update by JKY : Panel -> TEG, CH명으로 라벨링
        Dim teg = frmSettingWind.GetAllocationValue(m_nJIGNo, frmSettingWind.eChAllocationItem.eChannel)
        If m_AddText = "" Then
            lblTitle.Text = "TEG " & Format(teg + 1, "00") 'convertIncNumberToMatrixValue(m_nJIGNo)  'Format(m_nJIGNo + 1, "00")   'JIG
        Else
            lblTitle.Text = "TEG " & Format(teg + 1, "00") & " (" & m_AddText & ")"
        End If
        lblIndicator_Temp.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        lblIndicator_Temp.ForeColor = Color.OrangeRed
        m_nPreviouslySelectedCellIdx = 0
        '  m_bEnableMultiSelect = False
        AddCell()
        SetLocationAndSize()
        '  lblContactPIN.Dock = DockStyle.Fill
        'If m_numOfCell <= 4 Then
        '    lblContactPIN.Text = ""
        'Else
        '    lblContactPIN.Text = "↓ CONTACT PIN ↓"
        '    lblContactPIN.Font = New System.Drawing.Font("Calibri", 17.0!, System.Drawing.FontStyle.Bold)
        'End If

    End Sub

    Public Shared Function convertIncPixel(ByVal IncNumber As Integer) As String

        Dim matrixRow As Integer = m_numOfCell

        Dim Invalue As Integer = IncNumber

        Dim stdVal As Double = 1 / matrixRow
        Dim devideVaue1 As Double = Invalue / matrixRow
        Dim Value As Integer = Fix(devideVaue1)
        Dim value1 As String = CStr(devideVaue1) - CStr(Value)

        Dim resultValue As String

        Dim cnt As Integer
        Dim Value3 As Double
        Dim Value2 As Double

        Do
            cnt += 1
            If value1 = 0 And Value2 = 0 Then
                Value3 = 100
            Else
                Value3 = CalRate(value1, Value2)
            End If
            Value2 = Value2 + stdVal
        Loop Until (Value3 > 99) And (Value3 < 101)

        ' resultValue = CStr(Format(Value + 1, "00")) & "-p" & CStr(Format(cnt, "00"))

        resultValue = CStr(Format(cnt, "0")) '& "p"
        Return resultValue
    End Function

    Public Shared Function convertIncNumberToMatrixValue(ByVal IncNumber As Integer) As String

        Dim matrixRow As Integer = m_numOfCell

        Dim Invalue As Integer = IncNumber

        Dim stdVal As Double = 1 / matrixRow
        Dim devideVaue1 As Double = Invalue / matrixRow
        Dim Value As Integer = Fix(devideVaue1)
        Dim value1 As String = CStr(devideVaue1) - CStr(Value)

        Dim resultValue As String

        Dim cnt As Integer
        Dim Value3 As Double
        Dim Value2 As Double

        Do
            cnt += 1
            If value1 = 0 And Value2 = 0 Then
                Value3 = 100
            Else
                Value3 = CalRate(value1, Value2)
            End If
            Value2 = Value2 + stdVal
        Loop Until (Value3 > 99) And (Value3 < 101)

        resultValue = CStr(Format(Value + 1, "00")) '& "-" & CStr(Format(cnt, "00"))

        'resultValue = CStr(Format(cnt, "0")) & "L"
        Return resultValue
    End Function

    Public Shared Function convertIncNumberToMatrixValue_Monitoring(ByVal IncNumber As Integer) As String

        Dim matrixRow As Integer = 10

        Dim Invalue As Integer = IncNumber

        Dim stdVal As Double = 1 / matrixRow
        Dim devideVaue1 As Double = Invalue / matrixRow
        Dim Value As Integer = Fix(devideVaue1)
        Dim value1 As String = CStr(devideVaue1) - CStr(Value)

        Dim resultValue As String

        Dim cnt As Integer
        Dim Value3 As Double
        Dim Value2 As Double

        Do
            cnt += 1
            If value1 = 0 And Value2 = 0 Then
                Value3 = 100
            Else
                Value3 = CalRate(value1, Value2)
            End If
            Value2 = Value2 + stdVal
        Loop Until (Value3 > 99) And (Value3 < 101)

        resultValue = CStr(Format(Value + 1, "0")) & "-" & CStr(Format(cnt, "00"))

        'resultValue = CStr(Format(cnt, "0")) & "L"
        Return resultValue
    End Function

    Public Shared Function convertIncNumberToMatrixValue2(ByVal IncNumber As Integer) As String

        Dim matrixRow As Integer = m_numOfCell

        Dim Invalue As Integer = IncNumber

        Dim stdVal As Double = 1 / matrixRow
        Dim devideVaue1 As Double = Invalue / matrixRow
        Dim Value As Integer = Fix(devideVaue1)
        Dim value1 As String = CStr(devideVaue1) - CStr(Value)

        Dim resultValue As String

        Dim cnt As Integer
        Dim Value3 As Double
        Dim Value2 As Double

        Do
            cnt += 1
            If value1 = 0 And Value2 = 0 Then
                Value3 = 100
            Else
                Value3 = CalRate(value1, Value2)
            End If
            Value2 = Value2 + stdVal
        Loop Until (Value3 > 99) And (Value3 < 101)

        resultValue = CStr(Format(Value + 1, "00")) & "-" & CStr(Format(cnt, "00"))

        'resultValue = CStr(Format(cnt, "0")) & "L"
        Return resultValue
    End Function
    Public Shared Function convertChannelNumberToJIGChannelNumber(ByVal IncNumber As Integer, ByRef nJIGNumber As Integer) As String

        Dim matrixRow As Integer = m_numOfCell

        Dim Invalue As Integer = IncNumber

        Dim stdVal As Double = 1 / matrixRow
        Dim devideVaue1 As Double = Invalue / matrixRow
        Dim Value As Integer = Fix(devideVaue1)
        Dim value1 As String = CStr(devideVaue1) - CStr(Value)

        Dim resultValue As String

        Dim cnt As Integer
        Dim Value3 As Double
        Dim Value2 As Double

        Do
            cnt += 1
            If value1 = 0 And Value2 = 0 Then
                Value3 = 100
            Else
                Value3 = CalRate(value1, Value2)
            End If
            Value2 = Value2 + stdVal
        Loop Until (Value3 > 99) And (Value3 < 101)

        resultValue = CStr(cnt)

        nJIGNumber = CStr(Value + 1)
        Return resultValue
    End Function

    Public Shared Function convertIncNumberToMatrixValue_ForJIGNum(ByVal IncNumber As Integer) As String    '지그번호만 보기 위해 만듬

        Dim matrixRow As Integer = 4

        Dim Invalue As Integer = IncNumber

        Dim stdVal As Double = 1 / matrixRow
        Dim devideVaue1 As Double = Invalue / matrixRow
        Dim Value As Integer = Fix(devideVaue1)
        Dim value1 As String = CStr(devideVaue1) - CStr(Value)

        Dim resultValue As String

        Dim cnt As Integer
        Dim Value3 As Double
        Dim Value2 As Double

        Do
            cnt += 1
            If value1 = 0 And Value2 = 0 Then
                Value3 = 100
            Else
                Value3 = CalRate(value1, Value2)
            End If
            Value2 = Value2 + stdVal
        Loop Until (Value3 > 99) And (Value3 < 101)

        resultValue = CStr(Format(Value + 1, "00"))

        Return resultValue
    End Function

    Private Shared Function CalRate(ByVal val1 As Double, ByVal val2 As Double) As Double
        Return (Math.Abs(val1) / Math.Abs(val2)) * 100
    End Function

    Private Sub AddCell()
        If Cell Is Nothing Then
            ReDim Cell(m_numOfCell - 1)
            For i As Integer = 0 To m_numOfCell - 1
                Cell(i) = New ucDispSampleUI(m_cellType, Nothing)
                ' AddHandler Cell(i).evSelected, AddressOf Cell_Selected
            Next
        ElseIf Cell.Length <> m_numOfCell Then
            ReDim Cell(m_numOfCell - 1)
            For i As Integer = 0 To m_numOfCell - 1
                Cell(i) = New ucDispSampleUI(m_cellType, Nothing)
                '  AddHandler Cell(i).evSelected, AddressOf Cell_Selected
            Next
        End If

        pnJIGArea.Controls.Clear()
        For i As Integer = 0 To m_numOfCell - 1
            '    AddHandler Cell(i).evSelectStateChange, AddressOf SelectStateChange
            pnJIGArea.Controls.Add(Cell(i))
        Next
    End Sub

    Private Sub SetLocationAndSize()

        Dim xFactor As Integer = 0
        Dim yFactor As Integer = 2
        Dim bChkFlag As Boolean = False
        Dim nChkCnt As Integer = 0
        Dim Tmpvalue As Integer = 0
        Dim outlineSize As Size = pnJIGOutline.Size

        pnJIGArea.Location = New System.Drawing.Point(m_dOutlineWidth, m_dOutlineWidth)

        pnJIGArea.Size = New System.Drawing.Size(outlineSize.Width - (m_dOutlineWidth * 2), outlineSize.Height - (m_dOutlineWidth * 2))

        'Cell을 JIGㅇ에 대칭으로 배치 : JIG에 놓여질 셀의 수를 반으로 나누면 가로 세로 비율이 대칭이 된다. 홀수 일 경우는 반올림
        Dim nCol As Integer = m_CellLayout(0) 'Col
        Dim nRow As Integer = m_CellLayout(1) 'Row

        Dim cellArea As Size

        If nCol = 0 Then
            cellArea = New System.Drawing.Size(pnJIGArea.Size.Width, pnJIGArea.Size.Height / nRow)
        ElseIf nRow = 0 Then
            cellArea = New System.Drawing.Size(pnJIGArea.Size.Width / nCol, pnJIGArea.Size.Height)
        Else
            If m_numOfCell <= 4 Then
                cellArea = New System.Drawing.Size(pnJIGArea.Size.Width / nRow, pnJIGArea.Size.Height / nCol)
            Else
                cellArea = New System.Drawing.Size(pnJIGArea.Size.Width / nRow, pnJIGArea.Size.Height / nCol)
            End If
        End If

        If m_numOfCell = 1 Then

            Cell(0).Size = New System.Drawing.Size(cellArea.Width - unitCellMargine.Left - unitCellMargine.Right, cellArea.Height - unitCellMargine.Top - unitCellMargine.Left)
            Cell(0).Location = New System.Drawing.Point(unitCellMargine.Left, unitCellMargine.Top)
        Else

            Dim nCellCnt As Integer = 0
            Dim nColumnCnt As Integer = 0

            For n As Integer = 0 To nRow - 1
                For i As Integer = 0 To nCol - 1
                    If nCellCnt >= m_numOfCell Then Exit For
                    If nCellCnt >= Cell.Length Then Exit For
                    Cell(n * nCol + i).Size = New System.Drawing.Size(cellArea.Width - unitCellMargine.Left - unitCellMargine.Right, cellArea.Height - unitCellMargine.Top - unitCellMargine.Left)

                    '==================MC==================
                    'If nCellCnt = 0 Then
                    '    Cell(n * nCol + i).Location = New System.Drawing.Point(1 * cellArea.Width + unitCellMargine.Left, 0 * cellArea.Height + unitCellMargine.Top)
                    'ElseIf nCellCnt = 1 Then
                    '    Cell(n * nCol + i).Location = New System.Drawing.Point(1 * cellArea.Width + unitCellMargine.Left, 1 * cellArea.Height + unitCellMargine.Top)
                    'ElseIf nCellCnt = 2 Then
                    '    Cell(n * nCol + i).Location = New System.Drawing.Point(0 * cellArea.Width + unitCellMargine.Left, 1 * cellArea.Height + unitCellMargine.Top)
                    'ElseIf nCellCnt = 3 Then
                    '    Cell(n * nCol + i).Location = New System.Drawing.Point(0 * cellArea.Width + unitCellMargine.Left, 0 * cellArea.Height + unitCellMargine.Top)
                    'End If

                    '==================SDC==================

                    If m_numOfCell <= 4 Then
                        If nCellCnt = 0 Then
                            Cell(n * nCol + i).Location = New System.Drawing.Point(0 * cellArea.Width + unitCellMargine.Left, 0 * cellArea.Height + unitCellMargine.Top)
                        ElseIf nCellCnt = 1 Then
                            Cell(n * nCol + i).Location = New System.Drawing.Point(0 * cellArea.Width + unitCellMargine.Left, 1 * cellArea.Height + unitCellMargine.Top)
                        ElseIf nCellCnt = 2 Then
                            Cell(n * nCol + i).Location = New System.Drawing.Point(0 * cellArea.Width + unitCellMargine.Left, 2 * cellArea.Height + unitCellMargine.Top)
                            'ElseIf nCellCnt = 3 Then
                            '    Cell(n * nCol + i).Location = New System.Drawing.Point(0 * cellArea.Width + unitCellMargine.Left, 1 * cellArea.Height + unitCellMargine.Top)
                            'End If
                        End If
                    Else
                        'If n = 0 Then
                        '    Cell(n * nCol + i).Location = New System.Drawing.Point(n * cellArea.Width + unitCellMargine.Left, (nColumnCnt) * cellArea.Height + unitCellMargine.Top)
                        '    'ElseIf n = 1 Then
                        '    '    Cell(n * nCol + i).Location = New System.Drawing.Point(n * cellArea.Width + unitCellMargine.Left, (nCol - nColumnCnt - 1) * cellArea.Height + unitCellMargine.Top)
                        '    'ElseIf n = 2 Then
                        '    '    Cell(n * nCol + i).Location = New System.Drawing.Point(n * cellArea.Width + unitCellMargine.Left, (nCol - nColumnCnt - 1) * cellArea.Height + unitCellMargine.Top)
                        '    'End If
                        'Else
                        '    Cell(n * nCol + i).Location = New System.Drawing.Point(n + 1 * cellArea.Width + unitCellMargine.Left, (nColumnCnt) * cellArea.Height + unitCellMargine.Top)
                        'End If

                        'If i <> 0 Then
                        '    If i Mod 3 = 0 Then
                        '        nColumnCnt += 1
                        '    End If
                        'End If

                            'SDC IVL 개조건 CASE
                            Cell(n * nCol + i).Location = New System.Drawing.Point(((xFactor) * cellArea.Width + unitCellMargine.Left), ((yFactor) * cellArea.Height + unitCellMargine.Top))

                            'If n = 0 Then
                            '    Cell(n * nCol + i).Location = New System.Drawing.Point(n * cellArea.Width + unitCellMargine.Left, (nColumnCnt) * cellArea.Height + unitCellMargine.Top)
                            'Else
                            '    Cell(n * nCol + i).Location = New System.Drawing.Point(n + 1 * cellArea.Width + unitCellMargine.Left, (nColumnCnt) * cellArea.Height + unitCellMargine.Top)
                            'End If

                        End If
                        If bChkFlag = False Then
                            yFactor -= 1
                        Else
                            yFactor += 1
                        End If

                        If (n * nCol + i) <> 0 Then
                            If i = nCol - 1 Then
                                xFactor += 1
                                yFactor = 0
                                nChkCnt += 1
                                bChkFlag = True
                        End If


                        '한번 체크하고 안들어야됨
                        If nChkCnt <> 0 Then
                            If Tmpvalue <> nChkCnt Then
                                If nChkCnt Mod 2 = 0 Then
                                    Tmpvalue = nChkCnt
                                    yFactor = 2
                                    bChkFlag = False
                                End If
                            End If
                        End If
                        'If (n * nCol + i) Mod 2 = 0 Then
                        '    xFactor += 1
                        '    yFactor = 0
                        '    bChkFlag = True
                        'End If
                    End If


                    'If xFactor = 8 Then
                    '    xFactor = 0
                    '    nColumnCnt += 1
                    'End If
                    ''==================Standard==================
                    'Cell(n * nCol + i).Location = New System.Drawing.Point(i * cellArea.Width + unitCellMargine.Left, n * cellArea.Height + unitCellMargine.Top)



                    'If nColumnCnt = 3 Then
                    '    nColumnCnt = 0
                    'End If
                    ' If nColumnCnt = 4 Then nColumnCnt = 0
                    'If nColumnCnt = 3 Then nColumnCnt = 0
                    ' If nCol = nColumnCnt Then nColumnCnt = 0
                    ' If nCol = nColumnCnt Then xFactor = 0
                    '  If i = nCol - 1 Then xFactor = 0
                    nCellCnt += 1
                Next
            Next
        End If



    End Sub

#End Region


    Private Sub ChNumberSelectDisplay()
        Dim nChannelToSelectJigChannel As Integer

        nChannelToSelectJigChannel = m_ChannelNo Mod m_numOfCell

        Cell(nChannelToSelectJigChannel).IsSelected = m_blsChannelSelected

    End Sub

    Private Sub updateDisplay()

        If m_bIsLoaded = False Then Exit Sub

        Dim outlineSize As Size = pnJIGOutline.Size

        pnJIGArea.Location = New System.Drawing.Point(m_dOutlineWidth, m_dOutlineWidth)

        pnJIGArea.Size = New System.Drawing.Size(outlineSize.Width - (m_dOutlineWidth * 2), outlineSize.Height - (m_dOutlineWidth * 2))

        pnJIGArea.BackColor = m_JIGColor

        If m_bIsSelected = True Then
            pnJIGOutline.BackColor = m_OutlineColor_Selected
        Else
            pnJIGOutline.BackColor = m_OutlineColor_UnSelected
        End If

        For i As Integer = 0 To Cell.Length - 1
            Cell(i).StatusFont = m_StatusMsgFont
        Next

        If m_bEnableMultiSelect = True Then
            For i As Integer = 0 To Cell.Length - 1
                Cell(i).IsSelected = m_bIsSelected
            Next
        Else
            Cell(m_nPreviouslySelectedCellIdx).IsSelected = m_bIsSelected
        End If

    End Sub

    Private Sub tlpMain_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tlpMain.MouseClick
        '220825 Update by JKY : CellEvent_Selected 이벤트에서만 처리하도록 수정
        'If m_bIsSelected = True Then
        '    m_bIsSelected = False
        'Else
        '    m_bIsSelected = True
        'End If
        'updateDisplay()
    End Sub

    Private Sub pnCellOutline_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnJIGOutline.MouseClick
        '220825 Update by JKY : CellEvent_Selected 이벤트에서만 처리하도록 수정
        'If m_bIsSelected = True Then
        '    m_bIsSelected = False
        'Else
        '    m_bIsSelected = True
        'End If
        'updateDisplay()
    End Sub

    Private Sub pnJIGArea_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnJIGArea.MouseClick
        '220825 Update by JKY : CellEvent_Selected 이벤트에서만 처리하도록 수정
        'If m_bIsSelected = True Then
        '    m_bIsSelected = False
        'Else
        '    m_bIsSelected = True
        'End If
        'updateDisplay()
    End Sub

    Private Sub ucDispUnitCellJIG_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_bIsLoaded = True
        updateDisplay()
        SetLocationAndSize()
    End Sub


    Private Sub ucDispUnitCell_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover

    End Sub

    Private Sub ucDispUnitCell_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave

    End Sub




    Private Sub ucDispUnitCell_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If m_bIsLoaded = False Then Exit Sub
        SetLocationAndSize()
    End Sub

    Private Sub 실험시작ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 실험시작ToolStripMenuItem.Click
        RaiseEvent evRunExperiment(m_nJIGNo)
    End Sub

    Private Sub 실험정지ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 실험정지ToolStripMenuItem.Click
        RaiseEvent evStopExperiment(m_nJIGNo)
    End Sub

    Private Sub LoadSequenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadSequenceToolStripMenuItem.Click
        RaiseEvent evClickLoadSequence(m_nJIGNo)
    End Sub

    Private Sub UnloadSequenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnloadSequenceToolStripMenuItem.Click
        RaiseEvent evClickUnloadSeqeunce(m_nJIGNo)
    End Sub

    Private Sub EditSequenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditSequenceToolStripMenuItem.Click
        RaiseEvent evClickEditSequence()
    End Sub

    Private Sub SavePathToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePathToolStripMenuItem.Click
        RaiseEvent evSavePath(m_nJIGNo)
    End Sub


    'Private Sub SelectStateChange(ByVal nCh As Integer, ByVal bIsSelected As Boolean)
    '    'Dim combindChNum() As Integer
    '    'combindChNum = frmSettingWind.CheckCombined(nJIGNo)
    '    If m_numOfCell = 1 Then
    '        m_bIsSelected = bIsSelected
    '        updateDisplay()
    '    End If

    'End Sub

    Private Sub lblIndicator_Temp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblIndicator_Temp.Click
        RaiseEvent evClickTempIndicator(m_nJIGNo)
    End Sub

    Private Sub lblIndicator_Temp_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblIndicator_Temp.MouseHover
        lblIndicator_Temp.BackColor = Color.Ivory
    End Sub

    Private Sub lblIndicator_Temp_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblIndicator_Temp.MouseLeave
        lblIndicator_Temp.BackColor = Color.Transparent
    End Sub


End Class
