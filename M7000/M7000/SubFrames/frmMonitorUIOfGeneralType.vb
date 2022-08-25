Imports System.Threading

Public Class frmMonitorUIOfGeneralType


#Region "Define"

    Dim sCommonHeaders() As String = New String() {"TEG", "Filename", "Status", "Target", "Progress", "Cycle", "Total Time", "Mode Time", "Message"}
    Dim sCellDataHeadersForM7000() As String = New String() {"TEG", "Current(mA)", "Current(%)", "Current Density(mA/cm^2)", "Luminance_Fill(cd/m2)", "Luminance(cd/m2)", "Luminance(%)", "Current Efficiency(Cd/A)", "Current Efficiency(%)"}
    '  Dim sCellDataHeadersForM7000ViewAngle() As String = New String() {"TEG", "T('C)", _
    '   "R_Bias V(V)", "R_Bias I(mA)", "R_Amp.V(V)", "R_Amp.I(mA)",
    '  "G_Bias V(V)", "G_Bias I(mA)", "G_Amp.V(V)", "G_Amp.I(mA)",
    '  "B_Bias V(V)", "B_Bias I(mA)", "B_Amp.V(V)", "B_Amp.I(mA)",
    '  "Color", "Angle(')", "Lumi(Cd/m2)", "Lumi(%)"}

    '[Luminance_0'(cd/m^2)]	[Luminance_0'(%)]	[Current Efficiency_0'(cd/A)]	[Power Efficiency_0'(lm/W)]	[QE_0'(%)]	[CIE_x_0']	[CIE_y_0']	[CIE_u'_0']	[CIE_v'_0']	[CCT_0']


    Dim sPanelDataHeaders() As String = New String() {"Ch", "ELVDD Voltage", "ELVDD Current", "ELVSS Voltage", "ELVSS Current", "PD Current", "Luminance(%)", "Stop Lumi(%)", "Temp"}
    Dim sModuleDataHeaders() As String = New String() {"Ch", "Pattern Idx", "IDD(mA)", "ICI(mA)", "IBAT(mA)", "Meas. Point", "Luminance(cd/m2)", "CIE x", "CIE y", "CCT", "MPCD", "u'", "v'", "Luminance(%)"}

    Shared nCellDataColumnType() As ucDataGridView.eContollerType = {ucDataGridView.eContollerType.eTextBox,
                                                                     ucDataGridView.eContollerType.eTextBox,
                                                                     ucDataGridView.eContollerType.eTextBox,
                                                                     ucDataGridView.eContollerType.eTextBox,
                                                                     ucDataGridView.eContollerType.eTextBox,
                                                                     ucDataGridView.eContollerType.eTextBox,
                                                                     ucDataGridView.eContollerType.eTextBox,
                                                                     ucDataGridView.eContollerType.eTextBox}
    ' Shared nCellDataColumnType() As ucDataGridView.eContollerType = {ucDataGridView.eContollerType.eTextBox, ucDataGridView.eContollerType.eTextBox,
    '   ucDataGridView.eContollerType.eTextBox, ucDataGridView.eContollerType.eTextBox, ucDataGridView.eContollerType.eTextBox, ucDataGridView.eContollerType.eTextBox,
    '   ucDataGridView.eContollerType.eTextBox, ucDataGridView.eContollerType.eTextBox, ucDataGridView.eContollerType.eTextBox, ucDataGridView.eContollerType.eTextBox,
    '  ucDataGridView.eContollerType.eTextBox, ucDataGridView.eContollerType.eTextBox, ucDataGridView.eContollerType.eTextBox, ucDataGridView.eContollerType.eTextBox,
    '   ucDataGridView.eContollerType.eComboBox,
    '  ucDataGridView.eContollerType.eComboBox,
    '  ucDataGridView.eContollerType.eTextBox,
    ' ucDataGridView.eContollerType.eTextBox}

    Shared nModuleDataColumnType() As ucDataGridView.eContollerType = {ucDataGridView.eContollerType.eTextBox,
                                                                       ucDataGridView.eContollerType.eComboBox,
                                                                       ucDataGridView.eContollerType.eTextBox,
                                                                       ucDataGridView.eContollerType.eTextBox,
                                                                       ucDataGridView.eContollerType.eTextBox,
                                                                       ucDataGridView.eContollerType.eComboBox,
                                                                       ucDataGridView.eContollerType.eTextBox,
                                                                       ucDataGridView.eContollerType.eTextBox,
                                                                       ucDataGridView.eContollerType.eTextBox,
                                                                       ucDataGridView.eContollerType.eTextBox,
                                                                       ucDataGridView.eContollerType.eTextBox,
                                                                       ucDataGridView.eContollerType.eTextBox,
                                                                       ucDataGridView.eContollerType.eTextBox,
                                                                       ucDataGridView.eContollerType.eTextBox}

    Public fMain As frmMain
    Dim m_nMaxCh As Integer

    Dim m_nSelDispDataType As ucSampleInfos.eSampleType = ucSampleInfos.eSampleType.eCell

    Dim m_SelectedPatternIdx() As Integer
    Dim m_SelectedMeasPoint() As Integer
    Dim m_SelectedAngleIndx() As Integer
    Dim m_SelectedColorIndx() As Integer

    Dim m_sCommonData() As sCommonInfo


    Public Structure sCommonInfo
        Dim nChannel As Integer
        Dim nStatus As CScheduler.eChSchedulerSTATE
        Dim nTarget As ucSampleInfos.eSampleType
        Dim CurrentRcpIndex As Integer  'Progress 정보 표시 1 Of n
        Dim numOfRcp As Integer       'Progress 정보 표시 1 Of n
        Dim nCycleCnt As Integer
        Dim totalTime_Currnet As CTime.sTimeValue   '현재 진행시간
        Dim totalTime_Set As CTime.sTimeValue       '설정 시간
        Dim modeTime_Current As CTime.sTimeValue
        Dim modeTime_Set As CTime.sTimeValue
        Dim sMessage As String
    End Structure

#Region "Delegate"

    Delegate Sub DelLIst(ByVal ch As Integer, ByVal str() As String)
    Delegate Sub DelLIst1(ByVal str() As String)
    Private Delegate Sub DelCallSub()

    Public Sub ShowFrame()
        If Me.InvokeRequired = True Then
            Dim Del2 As DelCallSub = New DelCallSub(AddressOf ShowFrame)
            Try
                Invoke(Del2, Nothing)
            Catch ex As Exception
                Exit Sub
            End Try
        Else

            Try
                Me.Show()

            Catch w As System.ComponentModel.Win32Exception

                Console.WriteLine(w.Message)
                Console.WriteLine(w.ErrorCode.ToString())
                Console.WriteLine(w.NativeErrorCode.ToString())
                Console.WriteLine(w.StackTrace)
                Console.WriteLine(w.Source)
                Dim e As New Exception()
                e = w.GetBaseException()
                Console.WriteLine(e.Message)
            End Try


        End If
    End Sub

    Public Sub HideFrame()
        If Me.InvokeRequired = True Then
            Dim Del2 As DelCallSub = New DelCallSub(AddressOf HideFrame)
            Try
                Invoke(Del2, Nothing)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            Me.Hide()
        End If
    End Sub

#End Region

#End Region

#Region "Propertye"

    Public WriteOnly Property Message(ByVal nCh As Integer) As String
        Set(ByVal value As String)
            m_sCommonData(nCh).sMessage = value
        End Set
    End Property

    Public WriteOnly Property ModeTime_SetValue(ByVal nCh As Integer) As CTime.sTimeValue
        Set(ByVal value As CTime.sTimeValue)
            m_sCommonData(nCh).modeTime_Set = value
        End Set
    End Property

    Public WriteOnly Property ModeTime_Current(ByVal nCh As Integer) As CTime.sTimeValue
        Set(ByVal value As CTime.sTimeValue)
            m_sCommonData(nCh).modeTime_Current = value
        End Set
    End Property

    Public WriteOnly Property TotalTime_SetValue(ByVal nCh As Integer) As CTime.sTimeValue
        Set(ByVal value As CTime.sTimeValue)
            m_sCommonData(nCh).totalTime_Set = value
        End Set
    End Property

    Public WriteOnly Property TotalTime_Current(ByVal nCh As Integer) As CTime.sTimeValue
        Set(ByVal value As CTime.sTimeValue)
            m_sCommonData(nCh).totalTime_Currnet = value
        End Set
    End Property

    Public WriteOnly Property Cycle(ByVal nCh As Integer) As Integer
        Set(ByVal value As Integer)
            m_sCommonData(nCh).nCycleCnt = value
        End Set
    End Property

    Public WriteOnly Property numOfRcp(ByVal nCh As Integer) As Integer
        Set(ByVal value As Integer)
            m_sCommonData(nCh).numOfRcp = value
        End Set
    End Property

    Public WriteOnly Property CurrentRcpIndex(ByVal nCh As Integer) As Integer
        Set(ByVal value As Integer)
            m_sCommonData(nCh).CurrentRcpIndex = value
        End Set
    End Property

    Public WriteOnly Property Status(ByVal nCh As Integer) As CScheduler.eChSchedulerSTATE
        Set(ByVal value As CScheduler.eChSchedulerSTATE)
            m_sCommonData(nCh).nStatus = value
        End Set
    End Property

    Public WriteOnly Property TargetSample(ByVal nCh As Integer) As ucSampleInfos.eSampleType
        Set(ByVal value As ucSampleInfos.eSampleType)
            m_sCommonData(nCh).nTarget = value
        End Set
    End Property

    Public Property EnableDispUpdate() As Boolean
        Get
            Return Timer1.Enabled
        End Get
        Set(ByVal value As Boolean)
            Timer1.Enabled = value
        End Set
    End Property

#End Region


#Region "Creator & Init"

    Public Sub New(ByVal maxCh As Integer)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_nMaxCh = maxCh

        init()
        InitDataIndicator(m_nMaxCh)

    End Sub

    Private Sub init()

        ReDim m_sCommonData(m_nMaxCh - 1)
        Timer1.Enabled = False
        ucDispListStatus.UseCheckBoxex = False
        ucDispListDatas.UseCheckBoxex = False

        spcMain.Location = New System.Drawing.Point(0, 0)
        spcMain.Dock = DockStyle.Fill

        pnStatus.Location = New System.Drawing.Point(0, 0)
        pnStatus.Dock = DockStyle.Fill


        pnDatas.Location = New System.Drawing.Point(0, 0)
        pnDatas.Dock = DockStyle.Fill

        '  ucDispListDatas.Location = New System.Drawing.Point(3, Label1.Location.Y + Label1.Size.Height + Label1.Margin.Bottom)
        ucDispListDatas.Dock = DockStyle.Fill

        '  ucDataGrid.Location = New System.Drawing.Point(3, Label1.Location.Y + Label1.Size.Height + Label1.Margin.Bottom)
        ucDataGrid.Dock = DockStyle.Fill

        ucDispListStatus.Dock = DockStyle.Fill

        ucDataGrid.RowHeaderVisible = False
        ucDataGrid.RowHeaderSize = 6


        ReDim m_SelectedMeasPoint(m_nMaxCh - 1)
        ReDim m_SelectedPatternIdx(m_nMaxCh - 1)
        ReDim m_SelectedAngleIndx(m_nMaxCh - 1)
        ReDim m_SelectedColorIndx(m_nMaxCh - 1)

        For i As Integer = 0 To m_nMaxCh - 1
            m_SelectedMeasPoint(i) = -1
            m_SelectedPatternIdx(i) = -1
            m_SelectedAngleIndx(i) = -1
            m_SelectedColorIndx(i) = -1
        Next



    End Sub

    Private Sub InitDataIndicator(ByVal MaxCh As Integer)
        Dim sData() As String

        ucDispListDatas.Visible = False
        ucDataGrid.Visible = False

        Select Case m_nSelDispDataType

            Case ucSampleInfos.eSampleType.eCell
                ucDispListDatas.Visible = True
                ReDim sData(sCellDataHeadersForM7000.Length - 1)
                ucDispListDatas.ColHeader = sCellDataHeadersForM7000.Clone
                Dim colWidthRatio As String
                colWidthRatio = "5"
                Dim nWidth As Integer = Fix(97 / (sCellDataHeadersForM7000.Length - 1))

                For i As Integer = 1 To sCellDataHeadersForM7000.Length - 1
                    colWidthRatio = colWidthRatio & "," & CStr(nWidth)
                Next
                ucDispListDatas.ColHeaderWidthRatio = colWidthRatio.Clone
                ' ucDataGrid.zContollerType = nCellDataColumnType
                ucDispListDatas.ClearAllData()
                For i As Integer = 0 To (MaxCh * 10) - 1
                    For n As Integer = 0 To sCellDataHeadersForM7000.Length - 1
                        If n = 0 Then
                            If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                                sData(n) = Format(i + 1, "00")
                            ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                                sData(n) = ucDispJIG.convertIncNumberToMatrixValue_Monitoring(i) '& "-" & ucDispJIG.convertIncPixel(i)
                            End If
                        Else
                            sData(n) = "-"
                        End If
                    Next
                    ucDispListDatas.AddRowData(sData)
                Next

            Case ucSampleInfos.eSampleType.ePanel
                ReDim sData(sPanelDataHeaders.Length - 2)
                ucDispListDatas.ColHeader = sPanelDataHeaders.Clone
                Dim colWidthRatio As String
                colWidthRatio = 3
                Dim nWidth As Integer = Fix(97 / (sPanelDataHeaders.Length - 2))
                For i As Integer = 1 To sPanelDataHeaders.Length - 1
                    colWidthRatio = colWidthRatio & "," & CStr(nWidth)
                Next
                ucDispListDatas.ColHeaderWidthRatio = colWidthRatio
                ucDispListDatas.ClearAllData()
                For i As Integer = 0 To MaxCh - 1
                    '  sData(0) = Format(CStr(i + 1), "000")
                    sData(0) = "-"
                    sData(1) = "-"
                    sData(2) = "-"
                    sData(3) = "-"
                    sData(4) = "-"
                    sData(5) = "-"
                    sData(6) = "-" 'fMain.g_MeasuredDatas(nCh).sCellLTParams.d   'Stop Luminance
                    sData(7) = "-"

                    ucDispListDatas.AddRowData(sData)
                Next
            Case ucSampleInfos.eSampleType.eModule
                ucDataGrid.Visible = True
                ReDim sData(sModuleDataHeaders.Length - 2)
                ucDataGrid.ControllerHeaderText = sModuleDataHeaders.Clone
                Dim colWidthRatio As String
                colWidthRatio = 3
                Dim nWidth As Integer = Fix(97 / (sModuleDataHeaders.Length - 1))
                For i As Integer = 1 To sModuleDataHeaders.Length - 1

                    If i = 6 Or i = sModuleDataHeaders.Length - 1 Then
                        colWidthRatio = colWidthRatio & "," & CStr(nWidth + 3)
                    Else
                        colWidthRatio = colWidthRatio & "," & CStr(nWidth)
                    End If

                Next
                ucDataGrid.ColHeaderWidthRatio = colWidthRatio.Clone
                ucDataGrid.zContollerType = nModuleDataColumnType
                ucDataGrid.ClearRow()
                For i As Integer = 0 To MaxCh - 1
                    ' sData(0) = Format(CStr(i + 1), "000")
                    For n As Integer = 0 To sModuleDataHeaders.Length - 2
                        sData(n) = "-"
                    Next
                    ucDataGrid.AddRowData(sData)
                Next
        End Select


        ReDim sData(sCommonHeaders.Length - 1)
        ucDispListStatus.ClearAllData()
        For i As Integer = 0 To MaxCh - 1

            If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                sData(0) = Format(i + 1, "00")
            ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                sData(0) = ucDispJIG.convertIncNumberToMatrixValue(i) '& "-" & ucDispJIG.convertIncPixel(i)
            End If
            'sData(0) = Format(i + 1, "00") 'ucDispJIG.convertIncNumberToMatrixValue(i) 'Format(i + 1, "000")
            sData(1) = "-"
            sData(2) = "-"
            sData(3) = "-"
            sData(4) = "-"
            sData(5) = "-"
            sData(6) = "-"
            sData(7) = "-"
            ucDispListStatus.AddRowData(sData)

            'UpdateDataIndicateTest(i)
        Next

        'ReDim sData(sCellDataHeadersForM7000ViewAngle.Length - 3)

        'For nCh As Integer = 0 To MaxCh - 1
        '    sData(0) = ucDispJIG.convertIncNumberToMatrixValue(nCh) ' Format(nCh + 1, "000")
        '    ucDataGrid.SetCellData(0, nCh, sData(0))
        '    sData(1) = "-"
        '    ucDataGrid.SetCellData(1, nCh, sData(1))
        '    sData(2) = "-"
        '    ucDataGrid.SetCellData(3, nCh, sData(2))
        '    sData(3) = "-"
        '    ucDataGrid.SetCellData(4, nCh, sData(3))
        '    sData(4) = "-"
        '    ucDataGrid.SetCellData(5, nCh, sData(4))
        '    sData(5) = "-"
        '    ucDataGrid.SetCellData(6, nCh, sData(5))
        '    sData(6) = "-"
        '    ucDataGrid.SetCellData(7, nCh, sData(6))
        '    sData(7) = "-"
        '    ucDataGrid.SetCellData(8, nCh, sData(7))
        '    sData(8) = "-"
        '    ucDataGrid.SetCellData(10, nCh, sData(8))
        '    sData(9) = "-"
        '    ucDataGrid.SetCellData(11, nCh, sData(9))
        'Next
       

    End Sub

    Private Sub fitDefaultLayout()

        Dim frmSize As Size = Me.Size

        spcMain.SplitterDistance = frmSize.Width * 0.4

    End Sub

    'Private Sub frmMonitorUIOfGeneralType_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
    '    InitDataIndicator(m_nMaxCh)
    'End Sub


    Private Sub ucDispMonCtrlUI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fitDefaultLayout()
    End Sub

#End Region

    Public Sub UpdateCommonIndicate(ByVal nCh As Integer)
        Dim sData(sCommonHeaders.Length - 1) As String
        ' "Ch", "Status", "Target", "Progress", "Cycle", "Total Time", "Mode Time", "Message"

        If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
            sData(0) = Format(nCh + 1, "00")
        ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
            sData(0) = ucDispJIG.convertIncNumberToMatrixValue(nCh) '& "-" & ucDispJIG.convertIncPixel(nCh)
        End If

        'sData(0) = Format(nCh + 1, "00") 'ucDispJIG.convertIncNumberToMatrixValue(nCh) 'Format(nCh + 1, "000")
        If fMain.frmControlUI.ControlUI.control.IsLoadedSavePath(nCh) = True Then
            sData(1) = fMain.SequenceList(nCh).SequenceInfo.sCommon.saveInfo.strOnlyFName
        Else
            sData(1) = "-"
        End If

        If m_sCommonData(nCh).nStatus = CScheduler.eChSchedulerSTATE.eIdle Then
            ' MsgBox("dd")
        End If
        sData(2) = CScheduler.GetStateCaptions(m_sCommonData(nCh).nStatus)
        sData(3) = m_sCommonData(nCh).nTarget.ToString
        sData(4) = CStr(m_sCommonData(nCh).CurrentRcpIndex) & " Of " & CStr(m_sCommonData(nCh).numOfRcp)
        sData(5) = m_sCommonData(nCh).nCycleCnt
        sData(6) = CTime.Convert_HourToHMS(m_sCommonData(nCh).totalTime_Currnet.dHour) & "[" & CTime.Convert_HourToHMS(m_sCommonData(nCh).totalTime_Set.dHour) & "]"
        sData(7) = CTime.Convert_HourToHMS(m_sCommonData(nCh).modeTime_Current.dHour) & "[" & CTime.Convert_HourToHMS(m_sCommonData(nCh).modeTime_Set.dHour) & "]"
        sData(8) = m_sCommonData(nCh).sMessage
        SetCommonList(nCh, sData)
    End Sub

    Public Sub UpdateDataIndicate(ByVal nCh As Integer)

        If fMain Is Nothing Then Exit Sub
        If fMain.g_MeasuredDatas Is Nothing Then Exit Sub
        Select Case m_sCommonData(nCh).nTarget

            Case ucSampleInfos.eSampleType.eCell
                '0 ~ 9
                Dim sData(sCellDataHeadersForM7000.Length - 1) As String

                'If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                '    sData(0) = Format(nCh + 1, "00")
                'ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                '    sData(0) = ucDispJIG.convertIncNumberToMatrixValue_Monitoring((nCh * 10)) '& "-" & ucDispJIG.convertIncPixel(nCh)
                'End If
              
                '   Data Display 필요
                If fMain.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eLifeTime_Running Then
                    For j As Integer = 0 To fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData.Length - 1

                        If fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.sSpectrometerData.D5.s4Intensity Is Nothing = False Then
                            ' sData(0) = fMain.g_MeasuredDatas(nCh).dTemp
                            ' sData(1) = Format(fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData.eletricalData.dVoltage, "0.000")
                            If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                                sData(0) = Format(nCh + 1, "00")
                            ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                                sData(0) = ucDispJIG.convertIncNumberToMatrixValue_Monitoring((nCh * 10) + j) '& "-" & ucDispJIG.convertIncPixel(nCh)
                            End If

                            sData(1) = Format(fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).eletricalData.dCurrent, "0.00000")
                            sData(2) = Format(fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).eletricalData.dCurrent_Per, "0.00")
                            sData(3) = Format(fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).dCurrentDensity, "0.000")
                            ' sData(4) = Format(fMain.g_MeasuredDatas(nCh).sCellLTParams.RealTimeData.eachPixelMeasData.dVoltage_Amplitude, "0.000")
                            '  sData(5) = Format(fMain.g_MeasuredDatas(nCh).sCellLTParams.RealTimeData.eachPixelMeasData.dCurrent_Amplitude, "0.00000E-0")
                            sData(4) = Format(fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dLumi_Fill_Cd_m2, "0.000")
                            sData(5) = Format(fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dLumi_Cd_m2, "0.000")
                            sData(6) = Format(fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dLumi_Percent, "0.00")
                            sData(7) = Format(fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dLumi_Cd_A, "0.000E-0")
                            sData(8) = Format(fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dLumi_Cd_A_Percent, "0.00")

                            SetDataList((nCh * 10) + j, sData)
                        End If

                    Next

                Else

                    For j As Integer = 0 To 9
                        If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                            sData(0) = Format(nCh + 1, "00")
                        ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                            sData(0) = ucDispJIG.convertIncNumberToMatrixValue_Monitoring((nCh * 10) + j) '& "-" & ucDispJIG.convertIncPixel(nCh)
                        End If
                        sData(1) = "-"
                        sData(2) = "-"
                        sData(3) = "-"
                        sData(4) = "-"
                        sData(5) = "-"
                        sData(6) = "-"
                        sData(7) = "-"
                        sData(8) = "-"
                        SetDataList((nCh * 10) + j, sData)
                    Next

                End If

            Case ucSampleInfos.eSampleType.ePanel
                Dim sData(sPanelDataHeaders.Length - 2) As String
                '"Ch", "ELVDD Voltage", "ELVDD Current", "ELVSS Voltage", "ELVSS Current", "PD Current", "Luminance(%)", "Stop Lumi(%)", "Temp"
                ' sData(0) = Format(CStr(nCh + 1), "000")
                sData(0) = fMain.g_MeasuredDatas(nCh).sPanelLTParams.sMeasuredValues.dELVDD_V
                sData(1) = fMain.g_MeasuredDatas(nCh).sPanelLTParams.sMeasuredValues.dELVDD_I
                sData(2) = fMain.g_MeasuredDatas(nCh).sPanelLTParams.sMeasuredValues.dELVSS_V
                sData(3) = fMain.g_MeasuredDatas(nCh).sPanelLTParams.sMeasuredValues.dELVSS_I
                sData(4) = fMain.g_MeasuredDatas(nCh).sPanelLTParams.sMeasuredValues.dPD_I
                sData(5) = fMain.g_MeasuredDatas(nCh).sPanelLTParams.dLumi_Percent
                sData(6) = "-" 'fMain.g_MeasuredDatas(nCh).sCellLTParams.d   'Stop Luminance
                sData(7) = fMain.g_MeasuredDatas(nCh).dTemp
                SetDataList(nCh, sData)
            Case ucSampleInfos.eSampleType.eModule
                Dim sData(sModuleDataHeaders.Length - 1) As String
                '"Ch", "Pattern Idx", "IDD(mA)", "ICI(mA)", "IBAT(mA)", "Meas. Point", "Luminance(cd/m2)", "CIE x", "CIE y", "CCT", "MPCD", "u", "v", "Luminance(%)"

                sData(0) = Format(nCh + 1, "000")
                ucDataGrid.SetCellData(0, nCh, sData(0))
                If fMain.g_MeasuredDatas(nCh).sModuleLTParams.sMeasuredValues Is Nothing = False Then

                    Dim cbPatternIdx As DataGridViewComboBoxCell

                    If m_SelectedPatternIdx(nCh) = -1 Then
                        cbPatternIdx = ucDataGrid.DataGridView.Rows(nCh).Cells(1)
                        cbPatternIdx.ReadOnly = False
                        cbPatternIdx.Items.Clear()
                        For pattIdx As Integer = 0 To fMain.g_MeasuredDatas(nCh).sModuleLTParams.sMeasuredValues.Length - 1
                            cbPatternIdx.Items.AddRange(Format(pattIdx + 1, "00"))
                        Next
                        m_SelectedPatternIdx(nCh) = 0
                        cbPatternIdx.Value = Format(m_SelectedPatternIdx(nCh) + 1, "00")
                    End If

                    If m_SelectedPatternIdx(nCh) >= 0 Then

                        sData(1) = Format(fMain.g_MeasuredDatas(nCh).sModuleLTParams.sMeasuredValues(m_SelectedPatternIdx(nCh)).sG4S.IDD_mA, "0.00")
                        ucDataGrid.SetCellData(2, nCh, sData(1))
                        sData(2) = Format(fMain.g_MeasuredDatas(nCh).sModuleLTParams.sMeasuredValues(m_SelectedPatternIdx(nCh)).sG4S.ICI_mA, "0.00")
                        ucDataGrid.SetCellData(3, nCh, sData(2))
                        sData(3) = Format(fMain.g_MeasuredDatas(nCh).sModuleLTParams.sMeasuredValues(m_SelectedPatternIdx(nCh)).sG4S.IBAT_mA, "0.00")
                        ucDataGrid.SetCellData(4, nCh, sData(3))

                        If fMain.g_MeasuredDatas(nCh).sModuleLTParams.sColorAnalyzer(m_SelectedPatternIdx(nCh)).sCA310 Is Nothing = False Then

                            Dim cbMeasPtIdx As DataGridViewComboBoxCell

                            If m_SelectedMeasPoint(nCh) = -1 Then
                                cbMeasPtIdx = ucDataGrid.DataGridView.Rows(nCh).Cells(5)
                                cbMeasPtIdx.ReadOnly = False
                                cbMeasPtIdx.Items.Clear()
                                For pt As Integer = 0 To fMain.g_MeasuredDatas(nCh).sModuleLTParams.sColorAnalyzer(m_SelectedPatternIdx(nCh)).sCA310.Length - 1
                                    cbMeasPtIdx.Items.AddRange(Format(pt + 1, "00"))
                                Next
                                m_SelectedMeasPoint(nCh) = 0
                                cbMeasPtIdx.Value = Format(m_SelectedMeasPoint(nCh) + 1, "00")
                            End If

                            If m_SelectedMeasPoint(nCh) >= 0 Then
                                If fMain.g_MeasuredDatas(nCh).sModuleLTParams.sColorAnalyzer(0).sCA310 Is Nothing = False Then
                                    sData(4) = Format(fMain.g_MeasuredDatas(nCh).sModuleLTParams.sColorAnalyzer(m_SelectedPatternIdx(nCh)).sCA310(m_SelectedMeasPoint(nCh)).Lv, "0.00")
                                    ucDataGrid.SetCellData(6, nCh, sData(4))
                                    sData(5) = Format(fMain.g_MeasuredDatas(nCh).sModuleLTParams.sColorAnalyzer(m_SelectedPatternIdx(nCh)).sCA310(m_SelectedMeasPoint(nCh)).sx, "0.0000")
                                    ucDataGrid.SetCellData(7, nCh, sData(5))
                                    sData(6) = Format(fMain.g_MeasuredDatas(nCh).sModuleLTParams.sColorAnalyzer(m_SelectedPatternIdx(nCh)).sCA310(m_SelectedMeasPoint(nCh)).sy, "0.0000")
                                    ucDataGrid.SetCellData(8, nCh, sData(6))
                                    sData(7) = Format(fMain.g_MeasuredDatas(nCh).sModuleLTParams.sColorAnalyzer(m_SelectedPatternIdx(nCh)).sCA310(m_SelectedMeasPoint(nCh)).CCT, "0.00")
                                    ucDataGrid.SetCellData(9, nCh, sData(7))
                                    sData(8) = Format(fMain.g_MeasuredDatas(nCh).sModuleLTParams.sColorAnalyzer(m_SelectedPatternIdx(nCh)).sCA310(m_SelectedMeasPoint(nCh)).MPCD, "0.00")
                                    ucDataGrid.SetCellData(10, nCh, sData(8))
                                    sData(9) = Format(fMain.g_MeasuredDatas(nCh).sModuleLTParams.sColorAnalyzer(m_SelectedPatternIdx(nCh)).sCA310(m_SelectedMeasPoint(nCh)).ud, "0.0000")
                                    ucDataGrid.SetCellData(11, nCh, sData(9))
                                    sData(10) = Format(fMain.g_MeasuredDatas(nCh).sModuleLTParams.sColorAnalyzer(m_SelectedPatternIdx(nCh)).sCA310(m_SelectedMeasPoint(nCh)).vd, "0.0000")
                                    ucDataGrid.SetCellData(12, nCh, sData(10))
                                    sData(11) = Format(fMain.g_MeasuredDatas(nCh).sModuleLTParams.dLumi_Percent(m_SelectedPatternIdx(nCh))(m_SelectedMeasPoint(nCh)), "0.00")
                                    ucDataGrid.SetCellData(13, nCh, sData(11))

                                Else
                                    sData(4) = "-"
                                    ucDataGrid.SetCellData(6, nCh, sData(4))
                                    sData(5) = "-"
                                    ucDataGrid.SetCellData(7, nCh, sData(5))
                                    sData(6) = "-"
                                    ucDataGrid.SetCellData(8, nCh, sData(6))
                                    sData(7) = "-"
                                    ucDataGrid.SetCellData(9, nCh, sData(7))
                                    sData(8) = "-"
                                    ucDataGrid.SetCellData(10, nCh, sData(8))
                                    sData(9) = "-"
                                    ucDataGrid.SetCellData(11, nCh, sData(9))
                                    sData(10) = "-"
                                    ucDataGrid.SetCellData(12, nCh, sData(10))
                                    sData(11) = "-"
                                    ucDataGrid.SetCellData(13, nCh, sData(11))
                                End If
                            End If


                        Else
                            sData(4) = "-"
                            ucDataGrid.SetCellData(6, nCh, sData(4))
                            sData(5) = "-"
                            ucDataGrid.SetCellData(7, nCh, sData(5))
                            sData(6) = "-"
                            ucDataGrid.SetCellData(8, nCh, sData(6))
                            sData(7) = "-"
                            ucDataGrid.SetCellData(9, nCh, sData(7))
                            sData(8) = "-"
                            ucDataGrid.SetCellData(10, nCh, sData(8))
                            sData(9) = "-"
                            ucDataGrid.SetCellData(11, nCh, sData(9))
                            sData(10) = "-"
                            ucDataGrid.SetCellData(12, nCh, sData(10))
                            sData(11) = "-"
                            ucDataGrid.SetCellData(13, nCh, sData(11))
                        End If
                    End If


                Else
                    sData(1) = "-"
                    ucDataGrid.SetCellData(2, nCh, sData(1))
                    sData(2) = "-"
                    ucDataGrid.SetCellData(3, nCh, sData(2))
                    sData(3) = "-"
                    ucDataGrid.SetCellData(4, nCh, sData(3))
                    sData(4) = "-"
                    ucDataGrid.SetCellData(6, nCh, sData(4))
                    sData(5) = "-"
                    ucDataGrid.SetCellData(7, nCh, sData(5))
                    sData(6) = "-"
                    ucDataGrid.SetCellData(8, nCh, sData(6))
                    sData(7) = "-"
                    ucDataGrid.SetCellData(9, nCh, sData(7))
                    sData(8) = "-"
                    ucDataGrid.SetCellData(10, nCh, sData(8))
                    sData(9) = "-"
                    ucDataGrid.SetCellData(11, nCh, sData(9))
                    sData(10) = "-"
                    ucDataGrid.SetCellData(12, nCh, sData(10))
                    sData(11) = "-"
                    ucDataGrid.SetCellData(13, nCh, sData(11))
                End If

        End Select

    End Sub



    Private Sub SetCommonList(ByVal nch As Integer, ByVal sData() As String)
        If ucDispListStatus.InvokeRequired = True Then
            Dim Del2 As DelLIst = New DelLIst(AddressOf SetCommonList)
            Try
                Invoke(Del2, nch, sData)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            ucDispListStatus.SetRowData(nch, sData)   ' , nch + 1)
        End If
    End Sub


    Private Sub SetDataList(ByVal ch As Integer, ByVal sData() As String)
        If ucDispListDatas.InvokeRequired = True Then
            Dim Del2 As DelLIst = New DelLIst(AddressOf SetDataList)
            Try
                Invoke(Del2, ch, sData)
            Catch ex As Exception
                Exit Sub
            End Try
        Else

            ' ucDispListDatas.AddRowData(sData)
            ucDispListDatas.SetRowData(ch, sData)   ' , nch + 1)
        End If
    End Sub


    'Private Sub cbSelData_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    m_nSelDispDataType = cbSelData.SelectedIndex
    '    InitDataIndicator(m_nMaxCh)
    'End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        '간혹 에러발생 시 모니터링이 중단될 수 있으므로 try처리함, 예외발생시 로그기록
        Try
            Timer1.Enabled = False

            'Stop되었을때 상태갱신
            For i = 0 To m_nMaxCh - 1
                If fMain.cTimeScheduler.g_ChSchedulerStatus(i) = CScheduler.eChSchedulerSTATE.eStop Then
                    m_sCommonData(i).nStatus = CScheduler.eChSchedulerSTATE.eIdle
                    UpdateCommonIndicate(i)
                End If
            Next

            Thread.Sleep(20)
            Application.DoEvents()

            For i As Integer = 0 To m_nMaxCh - 1
                If fMain.cTimeScheduler.g_ChSchedulerStatus(i) <> CScheduler.eChSchedulerSTATE.eIdle Then
                    Thread.Sleep(5)
                    Application.DoEvents()
                    UpdateCommonIndicate(i)
                    UpdateDataIndicate(i)
                Else

                    m_SelectedMeasPoint(i) = -1
                    m_SelectedPatternIdx(i) = -1
                    m_SelectedAngleIndx(i) = -1
                    m_SelectedColorIndx(i) = -1
                End If

            Next

            Thread.Sleep(20)
            Application.DoEvents()
            Timer1.Enabled = True

        Catch ex As Exception
            fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_PAUSED, "Monitoring UI 갱신 오류")
        End Try

    End Sub

    Private Sub ucDataGrid_evCompoboxSelectedIndexChanged(ByVal selectedItemIdx As Integer, ByVal nRaw As Integer, ByVal ncol As Integer) Handles ucDataGrid.evCompoboxSelectedIndexChanged

        If ncol = 1 Then
            m_SelectedPatternIdx(nRaw) = selectedItemIdx
        ElseIf ncol = 14 Then
            m_SelectedColorIndx(nRaw) = selectedItemIdx
        ElseIf ncol = 5 Then
            m_SelectedMeasPoint(nRaw) = selectedItemIdx
        ElseIf ncol = 15 Then
            m_SelectedAngleIndx(nRaw) = selectedItemIdx
        End If
    End Sub

  
  
End Class