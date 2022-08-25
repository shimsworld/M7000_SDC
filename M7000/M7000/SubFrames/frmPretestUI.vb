Imports System.Threading
Imports CSpectrometerLib
Public Class frmPretestUI

#Region "Define"
    Dim sCellDataHeaders() As String = New String() {"No.", "Mode", "Area(cm^2)", "Voltage(V)", "Current(A)", "ABS_I(A)", _
                                                  "J(mA/cm^2)", "Abs J(mA/cm^2)", "Luminance(Cd/m^2)", "Current Efficiency(cd/A)", _
                                                  "Power Efficiency(Im/W)", "QE(%)", "CIE_x", "CIE_y", "Log10(Abs Current)", "Temp('C)"}


    Dim sPanelDataHeaders() As String = New String() {"No.", "ELVDD Voltage", "ELVDD Current", "ELVSS Voltage", "ELVSS Current", "PD Current", "Luminance(%)", "Stop Lumi(%)", "Temp"}
    Dim sModuleDataHeaders() As String = New String() {"No.", "V1(V)", "V2(V)", "V3(V)", "V4(V)", "V5(V)", "I1(mA)", "I2(mA)", "I3(mA)", "I4(mA)", "I5(mA)",
                                                       "Luminance(%)", "Stop Lumi(%)", "Temp", "Luminance(cd/m2)", "X", "Y", "Z", "x", "y", "u'", "v'"}

    Dim myParent As frmMain
    Dim m_nMaxCh As Integer

    Dim m_PretestSequenceInfo As CSequenceManager.sSequenceInfo
    Dim meas_queue As New Queue
    Dim singleTestWind As frmSinglePointMeas
    Dim sData() As String

    Public Structure sProcessParams
        Dim index As Integer
        Dim cmd As eProcessState
        Dim sSampleInfos As ucSampleInfos.sSampleInfos
        Dim recipe As ucSequenceBuilder.sRecipeInfo
    End Structure

    Public Enum eProcessState
        LifeTimeSet
        LifeTimeMeas
        LifeTimeStop
        ImageSweep
        GrayScaleSweep
        IVLSweep
        ModulePatternMeasure
    End Enum
#End Region

#Region "Delegate"

    Private Delegate Sub DelCallSub()
    Private Delegate Sub DelLIst()
    Private Delegate Sub DelSetString(ByVal str As String)
    Private Delegate Sub DelPlotData(ByVal sData() As frmMain.sCellIVLMeasure)
    Private Delegate Sub DelPlotItem(ByVal nMode As ucDispGraph.eIVLPlotMode)


    Private Delegate Sub DelSetBool(ByVal trueOrFalse As Boolean)

    Public Sub Enable_gbControl(ByVal trueOrFalse As Boolean)
        If gbControl.InvokeRequired = True Then
            Dim Del2 As DelSetBool = New DelSetBool(AddressOf Enable_gbControl)
            Invoke(Del2, trueOrFalse)
        Else
            gbControl.Enabled = trueOrFalse
        End If
    End Sub

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


    Public Sub QueueCounter(ByVal str As String)  'ByVal label As System.Windows.Forms.StatusStrip,
        If lblQueueCount.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf QueueCounter)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblQueueCount.Text = str
        End If
    End Sub

    Private Sub StatusMsg(ByVal str As String)
        If lblMeasStatus.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf StatusMsg)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblMeasStatus.Text = str
        End If
    End Sub

    Private Sub SetRowData()
        If ucDispListDatas.InvokeRequired = True Then
            Dim Del2 As DelLIst = New DelLIst(AddressOf SetRowData)
            Try
                Invoke(Del2)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            ucDispListDatas.AddRowData(sData)
        End If
    End Sub

    Private Sub TemperatureMsg(ByVal str As String)
        If lblTemperature.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf TemperatureMsg)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblTemperature.Text = str
        End If

    End Sub
#End Region

#Region "Creator & Init"

    Public Sub New(ByVal parent As frmMain, ByVal maxCh As Integer)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = parent
        m_nMaxCh = maxCh

        init()
    End Sub


    Private Sub init()

        '    Dim SeqTitle() As String = {"NO", "Param", "Value"}
        '    Dim MeasTitle() As String = {"NO1", "Bias", "ELvss(V)", "ELvss(A)", "ELvdd(V)", "ELvdd(A)", "Red Bias(V)", "Greed Bias(V)", "Blue Bias(V)"}

        gbControl.Dock = DockStyle.Fill
        gbMeasuredData.Dock = DockStyle.Fill
        '   tlpGraph.Dock = DockStyle.Fill

        dispIVLGraph.Dock = DockStyle.Fill
        '    graph2.Dock = DockStyle.Fill
        spMain.Dock = DockStyle.Fill

        ucDispListDatas.Dock = DockStyle.Fill

        singleTestWind = New frmSinglePointMeas(myParent)

        With cbChannel
            .Items.Clear()
            For i As Integer = 0 To g_nMaxCh - 1
                .Items.Add(Format(i + 1, "000"))
            Next
            .SelectedIndex = 0
        End With

    End Sub

#End Region

    Public Sub deleteMeasQueue()
        SyncLock meas_queue.SyncRoot

            meas_queue.Clear()

        End SyncLock

    End Sub

    Public Sub requestMeas(ByVal seq As CSeqProcessor.sProcessParams)
        SyncLock meas_queue.SyncRoot
            meas_queue.Enqueue(seq)

        End SyncLock
    End Sub

    Private trdProcess As Thread
    Private bStopTrdProcess As Boolean

    Public Sub StartTrdProcess()
        trdProcess = New Thread(AddressOf ProcessLoop)
        bStopTrdProcess = False
        trdProcess.Priority = ThreadPriority.Lowest
        trdProcess.Start()
    End Sub

    Public Sub StopTrdProcess()
        bStopTrdProcess = True
    End Sub


    Private Sub ProcessLoop()

        Dim check_Process As Boolean = False
        ' Dim rcp As ucSequenceBuilder.sRecipeInfo = Nothing
        Dim procParam As sProcessParams = Nothing

        Do
            Application.DoEvents()
            Thread.Sleep(200)

            If bStopTrdProcess = True Then
                Exit Do
            End If

            If meas_queue.Count <= 0 Then
                StatusMsg("Standby")
                QueueCounter("-")
                TemperatureMsg("-")
                Exit Do
            End If

            SyncLock meas_queue.SyncRoot
                If meas_queue.Count Then
                    procParam = meas_queue.Dequeue
                    check_Process = True

                End If
                '     myParent.QueueCounter("Queue Counter = " & CStr(myParent.meas_queue.Count))
            End SyncLock

            If check_Process Then
                QueueCounter(m_PretestSequenceInfo.nCounter - meas_queue.Count & "/" & m_PretestSequenceInfo.nCounter)
                Select Case procParam.recipe.nMode
                    Case ucSequenceBuilder.eRcpMode.eCell_IVL
                        StatusMsg("IVL Sweep")

                        IVLSweepRoutine(procParam)

                    Case ucSequenceBuilder.eRcpMode.eChangeTemperature
                        Dim nGroup As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eGroupOfTC)
                        Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfTC)
                        Dim nChNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfTC)
                        Dim dTempData As CDevTCCommonNode.sParams

                        myParent.cTC(nGroup).SetTemp(nDevNo, nChNo, procParam.recipe.sChangeTemp.dTargetTemp)

                        Do

                            dTempData = myParent.cTC(nGroup).MeasuredData(nDevNo, nChNo)

                            TemperatureMsg(dTempData.measTemp & "('C)" & "/" & procParam.recipe.sChangeTemp.dTargetTemp & "('C)")
                            StatusMsg("Wait Temp")

                            Thread.Sleep(1000)
                            If dTempData.measTemp <= procParam.recipe.sChangeTemp.dTargetTemp + g_SystemOptions.sOptionData.TemperatureData.dMargin And
                              dTempData.measTemp >= procParam.recipe.sChangeTemp.dTargetTemp - g_SystemOptions.sOptionData.TemperatureData.dMargin Then
                                Exit Do
                            End If

                            If bStopTrdProcess = True Then
                                Exit Do
                            End If

                            Application.DoEvents()
                            Thread.Sleep(1000)
                        Loop
                End Select

                check_Process = False

            Else

            End If

        Loop

    End Sub


    Private Function InitListView(ByVal SampleType As ucSampleInfos.eSampleType) As Boolean
        Select Case SampleType

            Case ucSampleInfos.eSampleType.eCell
                ReDim sData(sCellDataHeaders.Length - 1)
                ucDispListDatas.ColHeader = sCellDataHeaders.Clone
                Dim colWidthRatio As String
                colWidthRatio = "4,6,6"

                Dim nWidth As Integer = Fix(95 / (sCellDataHeaders.Length - 2))
                For i As Integer = 0 To sCellDataHeaders.Length - 4
                    colWidthRatio = colWidthRatio & "," & CStr(nWidth)
                Next

                ucDispListDatas.ColHeaderWidthRatio = colWidthRatio
                ucDispListDatas.ClearAllData()

            Case ucSampleInfos.eSampleType.ePanel
                ReDim sData(sPanelDataHeaders.Length - 1)
                ucDispListDatas.ColHeader = sPanelDataHeaders.Clone
                Dim colWidthRatio As String
                colWidthRatio = 4

                Dim nWidth As Integer = Fix(80 / (sPanelDataHeaders.Length - 2))
                For i As Integer = 0 To sPanelDataHeaders.Length - 2
                    colWidthRatio = colWidthRatio & "," & CStr(nWidth)
                Next

                ucDispListDatas.ColHeaderWidthRatio = colWidthRatio
                ucDispListDatas.ClearAllData()


            Case ucSampleInfos.eSampleType.eModule
                ReDim sData(sModuleDataHeaders.Length - 1)
                ucDispListDatas.ColHeader = sModuleDataHeaders.Clone
                Dim colWidthRatio As String
                colWidthRatio = 4

                Dim nWidth As Integer = Fix(110 / (sModuleDataHeaders.Length - 2))
                For i As Integer = 0 To sModuleDataHeaders.Length - 2
                    colWidthRatio = colWidthRatio & "," & CStr(nWidth)
                Next

                ucDispListDatas.ColHeaderWidthRatio = colWidthRatio
                ucDispListDatas.ClearAllData()

        End Select


        Return True
    End Function

    Public Shared Function MakeSweepList(ByVal sIVLCominfos As ucDispRcpIVLSweep.sIVLSweepCommonInfos) As Double()
        Dim dStartValue, dStopValue, dStepValue As Double
        Dim nPoint, nTotPoint As Integer

        Dim dArrSweepList() As Double = Nothing
        Dim arrSweepList() As Double

        Dim i, nCnt As Integer


        For nCnt = 0 To sIVLCominfos.sMeasureSweepParameter.Length - 1

            dStartValue = sIVLCominfos.sMeasureSweepParameter(nCnt).dStart 'SweepParameter(nCnt).dStart
            dStopValue = sIVLCominfos.sMeasureSweepParameter(nCnt).dStop
            dStepValue = sIVLCominfos.sMeasureSweepParameter(nCnt).dStep
            nPoint = sIVLCominfos.sMeasureSweepParameter(nCnt).nPoint

            If dStartValue < dStopValue Then   '정방향 Sweep -Bias --> +Bias

            Else   '역방향 Sweep +Bias --> -Bias
                dStepValue = -Math.Abs(dStepValue)
            End If


            ReDim Preserve dArrSweepList(nPoint + nTotPoint - 1)

            dArrSweepList(0 + nTotPoint) = dStartValue
            For i = 1 To nPoint - 1
                dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue))
            Next

            nTotPoint = nTotPoint + nPoint

        Next

        With sIVLCominfos

            If .sweepMode = ucDispRcpIVLSweep.eSweepMode.eCycle Then
                Dim dArrBuf(dArrSweepList.Length - 1) As Double

                ReDim Preserve dArrSweepList(dArrSweepList.Length + dArrBuf.Length - 1)

                For j As Integer = dArrBuf.Length To dArrSweepList.Length - 1
                    dArrSweepList(i) = dArrSweepList(dArrSweepList.Length - i - 1)
                Next
            End If
        End With

        arrSweepList = dArrSweepList.Clone

        Return arrSweepList

    End Function

    Public Sub IVLSweepRoutine(ByVal procParam As sProcessParams)

        'Dim IVL_V As Double
        'Dim IVL_I As Double

        'Dim measCnt As Integer = 0
        'Dim spectrumCnt As Integer = 0
        'Dim nTimeOutCnt As Integer = 0

        'Dim nCh As Integer = procParam.index
        'Dim dSampleWidth As Double = procParam.sSampleInfos.SampleSize.Width
        'Dim dSampleHeight As Double = procParam.sSampleInfos.SampleSize.Height
        'Dim dFillFactor As Double = procParam.sSampleInfos.dFillFactor

        'Dim dSampleArea As Double = dSampleWidth * dSampleHeight / 100

        'Dim measuredData() As frmMain.sCellIVLMeasureParams = Nothing
        'Dim bufSpectrumData As CDevPR705.tData = Nothing
        'Dim cDataQE As CDataQECal = New CDataQECal

        'Dim dLum As Double
        'Dim dQE As Double
        'Dim dcdA As Double
        'Dim dlmW As Double


        'Dim spectrumMeasBiasList() As Double = Nothing

        'Dim nDevSwitch As Integer
        'Dim nChOfSwitch As Integer
        'Dim nDevKeithley As Integer
        'Dim nChOfKeithley As Integer
        'Dim nGroupTc As Integer
        'Dim nDevTc As Integer
        'Dim nChOfTc As Integer


        'nChOfSwitch = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eRedChOfSwitch)
        'nDevSwitch = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eRedDevNoOfSwitch)

        'nDevKeithley = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
        'nChOfKeithley = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfSMU_IVL)

        'nGroupTc = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eGroupOfTC)
        'nDevTc = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfTC)
        'nChOfTc = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfTC)

        ''***** GetSweepList *****
        'procParam.recipe.sIVLSweepInfo.sCommon.dSweepList = MakeSweepList(procParam.recipe.sIVLSweepInfo.sCommon)

        ''2. SW장비 AllOff
        'If myParent.cSwitch(nDevSwitch).mySwitch.AllOFF() = False Then
        '    '예외처리
        '    Exit Sub
        'End If

        'ucDispListDatas.ClearAllData()


        ''lblMeasStatus.Text = "IVL Sweep 대기 중"

        ''3. Spectrometer 모션 좌표 이동  채널좌표 Multi Point
        ''////////////////////////////////////////////////

        'If procParam.recipe.sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
        '    'lblMeasStatus.Text = "Motion Moveing"
        '    If myParent.cMotion.SetPosition(g_motionPosSpectrometer(nCh)) = False Then

        '        Exit Sub
        '    End If

        '    myParent.cMotion.MoveCompletedAllAxis()
        '    Application.DoEvents()
        '    Thread.Sleep(1000)


        '    ' 초기 측정 시 Aperature  1'  Change 
        '    'lblMeasStatus.Text = "Aperature Change"
        '    If myParent.cSpectormeter(0).mySpectrometer.StartApertureChange() = False Then
        '        '예외처리
        '    End If

        'End If

        ''4. SW장비 Ch On
        'If myParent.cSwitch(nDevSwitch).mySwitch.SwitchON(nChOfSwitch) = False Then
        '    '예외처리
        '    Exit Sub
        'End If

        ''5. SMU 초기화
        'If myParent.cIVLSMU(nDevKeithley).mySMU.InitializeSweep(procParam.recipe.sIVLSweepInfo.sKeithleyInfos) = False Then
        '    '   MsgBox("SMU 초기화 오류")
        '    Exit Sub
        'End If


        ''6. ACF



        'If myParent.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
        '    myParent.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellColor_ON = Color.White
        '    myParent.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellStatus = ucDispSampleCommonNode.eCellState.eON
        'End If

        ''7. 초기 Bias Setting
        'If myParent.cIVLSMU(nDevKeithley).mySMU.SetBias(procParam.recipe.sIVLSweepInfo.sCommon.dSweepList(measCnt)) = False Then
        '    '   MsgBox("Bias Setting Error...")
        '    Exit Sub
        'End If

        ' ''8 Servo Off
        ''myParent.cMotion.SERVO_OFF()

        ''9. IVL Sweep
        'Do
        '    Application.DoEvents()
        '    Thread.Sleep(1)

        '    'IVL Sweep 정지 시 플래그 필요
        '    ReDim Preserve myParent.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(measCnt)


        '    IVL_I = 0
        '    IVL_V = 0


        '    If procParam.recipe.sIVLSweepInfo.sCommon.sweepMethod = ucDispRcpIVLSweep.eSweepMethod.ePulse Then
        '        If myParent.cIVLSMU(nDevKeithley).mySMU.SetBias(0) = False Then
        '            '예외처리
        '            Exit Do
        '        End If

        '    ElseIf procParam.recipe.sIVLSweepInfo.sCommon.sweepMethod = ucDispRcpIVLSweep.eSweepMethod.ePulse_N_Offset Then
        '        If myParent.cIVLSMU(nDevKeithley).mySMU.SetBias(procParam.recipe.sIVLSweepInfo.sCommon.dOffsetBias) = False Then
        '            '예외처리
        '            Exit Do
        '        End If
        '    Else

        '    End If

        '    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '    '8.1 Sweeplist  Bias setting
        '    If myParent.cIVLSMU(nDevKeithley).mySMU.SetBias(procParam.recipe.sIVLSweepInfo.sCommon.dSweepList(measCnt)) = False Then
        '        '   MsgBox("Bias Setting Error...")
        '        Exit Do
        '    End If


        '    '8.2 Measdelay K2635를 제외하고 K24XX, K23X는 장비의 Measdelay 설정 부분이 없음.
        '    Application.DoEvents()
        '    Thread.Sleep(procParam.recipe.sIVLSweepInfo.sCommon.dMeasureDelay)


        '    'lblMeasStatus.Text = "IV Meas"
        '    '8.3 Voltage, Current Meas  2번 읽음 초기 측정 데이터 문제 발생 방지
        '    If myParent.cIVLSMU(nDevKeithley).mySMU.Measure(IVL_V, IVL_I) = False Then
        '        Exit Do
        '    End If

        '    Application.DoEvents()
        '    Thread.Sleep(10)

        '    If myParent.cIVLSMU(nDevKeithley).mySMU.Measure(IVL_V, IVL_I) = False Then
        '        Exit Do
        '    End If

        '    With myParent.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(measCnt)
        '        .nMeasMode = ucDispRcpIVLSweep.eMeasureItems.eIV
        '        .nCh = nCh
        '        .dVoltage = IVL_V
        '        .dCurrent = IVL_I
        '        .dAbs_Current_Log = Math.Log10(Math.Abs(.dCurrent))
        '        .dArea_cm = dSampleArea
        '        .dJ = (IVL_I * 1000) / (dSampleArea * dFillFactor) * 100  '(dI * 1000)  // 전류는 mA로 읽고있음  Unit : mA/cm2
        '        .dAbs_J = Math.Abs(.dJ)
        '        .dABS_I = Math.Abs(.dCurrent)
        '        .dTemperature = myParent.cTC(nGroupTc).MeasuredData(nDevTc, nChOfTc).measTemp
        '        TemperatureMsg(.dTemperature & "('C)")

        '    End With


        '    '8.4 Measurement Data of PR705

        '    If procParam.recipe.sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
        '        If procParam.recipe.sIVLSweepInfo.sCommon.dSweepList(measCnt) >= procParam.recipe.sIVLSweepInfo.sCommon.dLMeasLevel Then
        '            'lblMeasStatus.Text = "L Meas"
        '            ReDim Preserve myParent.g_MeasuredDatas(procParam.index).sCellIVLParams.sSpectrometer(spectrumCnt)
        '            ReDim Preserve spectrumMeasBiasList(spectrumCnt)

        '            spectrumMeasBiasList(spectrumCnt) = procParam.recipe.sIVLSweepInfo.sCommon.dSweepList(measCnt)

        '            Dim measData As CDevSpectrometerCommonNode.tData = Nothing
        '            Dim nWavelengthInterval As Integer = Nothing

        '            nTimeOutCnt = 0
        '            Do
        '                If nTimeOutCnt > 5 Then
        '                    myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_COMMON_MSG_Retry_TimeOut_Cnt)
        '                    'frmIVLDisplayWind.IsStopIVL = True
        '                    Exit Do
        '                End If

        '                If myParent.cSpectormeter(0).mySpectrometer.Measure(measData) = True Then
        '                    Exit Do
        '                End If
        '                nTimeOutCnt += 1
        '            Loop

        '            'If myParent.cSpectormeter(0).mySpectrometer.Measure(measData) = False Then
        '            '    '예외처리
        '            '    '   MsgBox("Error")

        '            'Else
        '            nTimeOutCnt = 0
        '            Do
        '                If nTimeOutCnt > 5 Then
        '                    myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_COMMON_MSG_Retry_TimeOut_Cnt)
        '                    'frmIVLDisplayWind.IsStopIVL = True
        '                    Exit Do
        '                End If

        '                If myParent.cSpectormeter(0).mySpectrometer.DownloadData(measData) = True Then
        '                    Exit Do
        '                End If
        '                nTimeOutCnt += 1
        '            Loop

        '            myParent.g_MeasuredDatas(procParam.index).sCellIVLParams.sSpectrometer(spectrumCnt) = measData

        '            dLum = measData.D6.s2YY

        '            '# Calculation cd/A
        '            dcdA = dLum / (myParent.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(measCnt).dJ * 10)

        '            '# Calculation lm/W
        '            dlmW = dcdA / IVL_V * Math.PI

        '            ' dQE = CData.QuantumEfficiency(SweepSet.dCellArea_cm, dI, SpectrumData(spectrumCnt).D5.s4Intensity)
        '            '스펙트럼 간격별로 QE계산 함수 호출 할 수 있도록 변경 해야 함.
        '            nWavelengthInterval = measData.D5.i3nm(1) - measData.D5.i3nm(0)

        '            dQE = cDataQE.QuantumEfficiency(dLum, myParent.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(measCnt).dJ, dSampleArea, measData.D5.s4Intensity, nWavelengthInterval)
        '            ' dQE = cDataQE.QuantumEfficiencyWaveLen1nm(dLum, fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(measCnt).dJ, dSampleArea, measData.D5.s4Intensity, nWavelengthInterval)
        '            '*************************************************************************************



        '            With myParent.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(measCnt)
        '                .nMeasMode = ucDispRcpIVLSweep.eMeasureItems.eIVL
        '                .dCdA = dcdA
        '                .dCdm2 = dLum
        '                .dCIEx = measData.D6.s3xx
        '                .dCIEy = measData.D6.s4yy
        '                .dlmW = dlmW
        '                .dQE = dQE
        '            End With

        '            spectrumCnt += 1

        '        End If

        '        ' fMain.frmIVLDisplayWind.SetPlotData(fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure)
        '    End If


        '    '  fMain.frmIVLDisplayWind.SetDisplayList(measCnt + 1, fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(measCnt))

        '    With myParent.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(measCnt)
        '        sData(0) = measCnt + 1
        '        sData(1) = .nMeasMode.ToString
        '        sData(2) = .dArea_cm
        '        sData(3) = Format(.dVoltage, "0.000")
        '        sData(4) = Format(.dCurrent, "0.00000E-0")
        '        sData(5) = Format(.dABS_I, "0.00000E-0")
        '        sData(6) = Format(.dJ, "0.000E-0")
        '        sData(7) = Format(.dAbs_J, "0.000E-0")
        '        sData(8) = Format(.dCdm2, "0.000")
        '        sData(9) = Format(.dCdA, "0.000")
        '        sData(10) = Format(.dlmW, "0.000")
        '        sData(11) = Format(.dQE, "0.000")
        '        sData(12) = .dCIEx
        '        sData(13) = .dCIEy
        '        sData(15) = .dTemperature

        '        SetRowData()
        '        '   ucDispListDatas.AddRowData(sData)
        '    End With

        '    '    dispIVLGraph.WritePlotData = myParent.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure
        '    '   dispIVLGraph.WritePlotMode = ucDispGraph.eIVLPlotMode.eVvsC
        '    dispIVLGraph.SetPlotData(myParent.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure)
        '    dispIVLGraph.PlotIVLData(ucDispGraph.eIVLPlotMode.eVvsC)

        '    measCnt += 1

        'Loop Until measCnt > procParam.recipe.sIVLSweepInfo.sCommon.dSweepList.Length - 1 'g_SweepSet.dBiasList.Length - 1


        ' ''9 Servo On
        ''myParent.cMotion.SERVO_ON()


        ''10. SW장비 Off
        'If myParent.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch) = False Then
        '    '예외처리
        '    Exit Sub
        'End If

        ''11. Keithley 
        'If myParent.cIVLSMU(nDevKeithley).mySMU.FinalizeSweep() = False Then
        '    '예외처리
        '    Exit Sub
        'End If

        'If myParent.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
        '    myParent.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellColor_OFF = Color.Black
        '    myParent.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellStatus = ucDispSampleCommonNode.eCellState.eOFF
        'End If


        '' IVL 완료 시 Aperature  1'  Change
        ''If myParent.cSpectormeter(0).mySpectrometer.EndApertureChange() = False Then
        ''    '예외처리
        ''End If


        ''12.  DataPlot


        ''13.  DataSave
        ''   If myParent.DataSaver(procParam.index).SaveDataIVL(procParam.recipe.recipeIndex_IVL, myParent.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure) = False Then
        ''예외처리
        ''Exit Sub
        ''   End If

        ''  If procParam.recipe.sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
        ''If myParent.DataSaver(procParam.index).SaveIVLSpectrumData(procParam.recipe.recipeIndex_IVL, myParent.g_MeasuredDatas(procParam.index).sCellIVLParams.sSpectrometer, spectrumMeasBiasList) = False Then
        ''예외처리
        ''Exit Sub
        ''   End If
        ''   End If

        ''  frmIVLDisplayWind.Close()
        ''   frmIVLDisplayWind.Dispose()

    End Sub




#Region "Control Event Functions"

    Private Sub frmPretestUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim seqBuilder As New frmSequenceBuilder
        seqBuilder.ShowDialog()
    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        Dim nCntCH As Integer = cbChannel.SelectedIndex

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCntCH) <> CScheduler.eChSchedulerSTATE.eIdle Then Exit Sub

        Dim process As sProcessParams = Nothing

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCntCH) <> CScheduler.eChSchedulerSTATE.eIdle Then
            MsgBox("Experimental channels are not available.")
            Exit Sub
        End If

        ' 실험 Suquence 파일이 IVL or ChangeTemperature 아니면 종료 하는 부분 추가 해야 함.
        For i As Integer = 0 To m_PretestSequenceInfo.nCounter - 1
            Select Case m_PretestSequenceInfo.sRecipes(i).nMode
                Case ucSequenceBuilder.eRcpMode.eCell_IVL, ucSequenceBuilder.eRcpMode.eChangeTemperature

                    '추가 필요
                Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eModule_Lifetime, ucSequenceBuilder.eRcpMode.ePanel_Lifetime, ucSequenceBuilder.eRcpMode.eNothing
                    Exit Sub
            End Select

        Next

        For i As Integer = 0 To m_PretestSequenceInfo.nCounter - 1
            process.index = nCntCH
            process.sSampleInfos = m_PretestSequenceInfo.sSampleInfos
            process.recipe = m_PretestSequenceInfo.sRecipes(i)
            meas_queue.Enqueue(process)
        Next

        InitListView(m_PretestSequenceInfo.sSampleInfos.sampleType)
        StartTrdProcess()
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim seqMgr As New CSequenceManager


        If seqMgr.LoadTestSequence = True Then
            m_PretestSequenceInfo = seqMgr.SequenceInfo
            For i As Integer = 0 To m_PretestSequenceInfo.nCounter - 1
                If m_PretestSequenceInfo.sRecipes(i).nMode <> ucSequenceBuilder.eRcpMode.eCell_IVL And m_PretestSequenceInfo.sRecipes(i).nMode <> ucSequenceBuilder.eRcpMode.eChangeTemperature Then
                    MsgBox("fail recipe file")
                    Exit Sub
                Else

                End If
            Next
            UpdateSeqTreeView()
        End If

    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        deleteMeasQueue()
        StopTrdProcess()
    End Sub

    Private Sub btnSourceControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSourceControl.Click
        singleTestWind.Channel = cbChannel.SelectedIndex
        singleTestWind.ShowDialog()
    End Sub


    'Private Sub Set_TypeParam(ByVal sampleType As ucDispRcpCommon.eSampleType)

    '    Dim CellTitle() As String = {"NO1", "Mode", "Area", "Volt", "Current", "J", "Curr Efficiency", "PowerEfficiency", "Luminance", "Test"}
    '    Dim PanelTitle() As String = {"NO2", "Mode", "Area", "Volt", "Current", "J", "Curr Efficiency", "PowerEfficiency", "Luminance"}
    '    Dim ModuleTitle() As String = {"NO3", "Mode", "Area", "Volt", "Current", "J", "Curr Efficiency", "PowerEfficiency", "Luminance"}
    '    Dim nCount As Integer = 0

    '    'Select Case Mode
    '    '    Case eOledType.eCell
    '    '        nCount = PanelTitle.Length
    '    '        grdMeasView.grdGridView.Rows = 1
    '    '        grdMeasView.grdGridView.Cols = nCount

    '    '        grdSequenView.grdGridView.Rows = 1
    '    '        grdSequenView.grdGridView.Cols = nCount

    '    '        For i As Integer = 0 To nCount - 1
    '    '            grdMeasView.grdGridView.set_TextMatrix(0, i, PanelTitle(i))
    '    '            grdSequenView.grdGridView.set_TextMatrix(0, i, ModuleTitle(i))
    '    '        Next
    '    '        For i = 1 To 3
    '    '            grdMeasView.grdGridView.AddItem("test" & i)
    '    '            grdSequenView.grdGridView.AddItem("test" & i)
    '    '        Next
    '    '    Case eOledType.ePanel

    '    '    Case eOledType.eModule

    '    'End Select


    'End Sub

#End Region


#Region "Functions"



    Private Sub UpdateSeqTreeView()

        sequenceTreeView.BeginUpdate()

        sequenceTreeView.Nodes.Clear()

        If m_PretestSequenceInfo.nCounter = 0 Then Exit Sub

        Dim rootNode As CommonTools.Node

        With m_PretestSequenceInfo

            'Common Infos
            rootNode = New CommonTools.Node("Common Infos")
            sequenceTreeView.Nodes.Add(rootNode)
            AddTreeViewNode(rootNode, .sCommon)

            'Sample Infos
            rootNode = New CommonTools.Node("Sample Infos")
            sequenceTreeView.Nodes.Add(rootNode)
            AddTreeViewNode(rootNode, .sSampleInfos)

            'Recipe
            For i As Integer = 0 To m_PretestSequenceInfo.sRecipes.Length - 1
                rootNode = New CommonTools.Node(New Object(1) {"Recipe" & Format(i + 1, "00"), m_PretestSequenceInfo.sRecipes(i).nMode.ToString})
                sequenceTreeView.Nodes.Add(rootNode)
                AddTreeViewNode(rootNode, .sRecipes(i))
            Next

        End With

        sequenceTreeView.EndUpdate()

    End Sub

    Private Sub AddTreeViewNode(ByVal parentNode As CommonTools.Node, ByVal commonInfo As ucSequenceBuilder.sRcpCommon)

        AddNode(parentNode, New CommonTools.Node(New Object(1) {"SavePath", commonInfo.saveInfo.strPathAndFName}))

        AddNode(parentNode, New CommonTools.Node(New Object(1) {"Default Temp", commonInfo.dDefaultTemp}))

        Dim Node As CommonTools.Node
        Node = New CommonTools.Node(New Object(1) {"Limit", "Length = " & CStr(commonInfo.sLimits.Length)})
        parentNode.Nodes.Add(Node)
        For i As Integer = 0 To commonInfo.sLimits.Length - 1
            AddNode(Node, New CommonTools.Node(New Object(1) {commonInfo.sLimits(i).eTypeOfValue.ToString, CStr(commonInfo.sLimits(i).LimitValue.dMin) & "~" & CStr(commonInfo.sLimits(i).LimitValue.dMax)}))
        Next

        Node = New CommonTools.Node(New Object(1) {"Test End Condition", "Length = " & CStr(commonInfo.sSequenceEnd.Length)})
        parentNode.Nodes.Add(Node)
        For i As Integer = 0 To commonInfo.sSequenceEnd.Length - 1
            AddNode(Node, New CommonTools.Node(New Object(1) {commonInfo.sSequenceEnd(i).nTypeOfParam.ToString, CStr(commonInfo.sSequenceEnd(i).dValue)}))
        Next

    End Sub

    Private Sub AddTreeViewNode(ByVal parentNode As CommonTools.Node, ByVal sampleInfo As ucSampleInfos.sSampleInfos)
        AddNode(parentNode, New CommonTools.Node(New Object(1) {"Title", sampleInfo.sTitle}))

        AddNode(parentNode, New CommonTools.Node(New Object(1) {"Type", sampleInfo.sampleType}))

        AddNode(parentNode, New CommonTools.Node(New Object(1) {"Color", sampleInfo.sampleColor.sampleColor.ToString}))
        AddNode(parentNode, New CommonTools.Node(New Object(1) {"Size", CStr(sampleInfo.SampleSize.Width) & "*" & CStr(sampleInfo.SampleSize.Height)}))
        AddNode(parentNode, New CommonTools.Node(New Object(1) {"Fill Factor", CStr(sampleInfo.dFillFactor)}))
        AddNode(parentNode, New CommonTools.Node(New Object(1) {"Comment", sampleInfo.sComment}))
    End Sub

    Private Sub AddTreeViewNode(ByVal parentNode As CommonTools.Node, ByVal Recipes As ucSequenceBuilder.sRecipeInfo)

        Dim Node As CommonTools.Node

        '  AddNode(parentNode, New CommonTools.Node(New Object(1) {"Mode", Recipes.nMode.ToString}))
        AddNode(parentNode, New CommonTools.Node(New Object(1) {"Index", Recipes.recipeIndex}))
        Select Case Recipes.nMode

            Case ucSequenceBuilder.eRcpMode.eCell_IVL, ucSequenceBuilder.eRcpMode.ePanel_IVL, ucSequenceBuilder.eRcpMode.eModuel_IVL

                '        AddNode(parentNode, New CommonTools.Node(New Object(1) {"Mode", Recipes.sIVLSweepInfo.nMyMode}))
                Node = New CommonTools.Node(New Object(1) {"Common", Nothing})
                parentNode.Nodes.Add(Node)
                AddNode(Node, New CommonTools.Node(New Object(1) {"Bias Mode", Recipes.sIVLSweepInfo.sCommon.biasMode.ToString}))
                AddNode(Node, New CommonTools.Node(New Object(1) {"Sweep Type", Recipes.sIVLSweepInfo.sCommon.sweepType.ToString}))
                AddNode(Node, New CommonTools.Node(New Object(1) {"Sweep Mode", Recipes.sIVLSweepInfo.sCommon.sweepMode.ToString}))
                AddNode(Node, New CommonTools.Node(New Object(1) {"Sweep Method", Recipes.sIVLSweepInfo.sCommon.sweepMethod.ToString}))
                AddNode(Node, New CommonTools.Node(New Object(1) {"Sweep Line", Recipes.sIVLSweepInfo.sCommon.sweepLine.ToString}))  'Panel
                Dim subNode As New CommonTools.Node(New Object(1) {"Sweep Region", "Length = " & Recipes.sIVLSweepInfo.sCommon.sMeasureSweepParameter.Length})
                parentNode.Nodes.Add(subNode)
                For i As Integer = 0 To Recipes.sIVLSweepInfo.sCommon.sMeasureSweepParameter.Length - 1
                    Dim subNode1 As New CommonTools.Node(New Object(1) {"Region" & Format(i + 1, "00"), Nothing})
                    subNode.Nodes.Add(subNode1)
                    AddNode(subNode1, New CommonTools.Node(New Object(1) {"Start", Recipes.sIVLSweepInfo.sCommon.sMeasureSweepParameter(i).dStart}))
                    AddNode(subNode1, New CommonTools.Node(New Object(1) {"Stop", Recipes.sIVLSweepInfo.sCommon.sMeasureSweepParameter(i).dStop}))
                    AddNode(subNode1, New CommonTools.Node(New Object(1) {"Step", Recipes.sIVLSweepInfo.sCommon.sMeasureSweepParameter(i).dStep}))
                    AddNode(subNode1, New CommonTools.Node(New Object(1) {"Points", Recipes.sIVLSweepInfo.sCommon.sMeasureSweepParameter(i).nSweepNumber}))
                Next

                'Panel, Module
                subNode = New CommonTools.Node(New Object(1) {"Points", Nothing})
                parentNode.Nodes.Add(subNode)
                AddNode(subNode, New CommonTools.Node(New Object(1) {"Align Mark Distance", Recipes.sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.X & " * " & Recipes.sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.Y}))
                If Recipes.sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint Is Nothing = False Then
                    For i As Integer = 0 To Recipes.sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                        AddNode(subNode, New CommonTools.Node(New Object(1) {"Point" & Format(i + 1, "00"), Recipes.sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint(i).X & " * " & Recipes.sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint(i).Y}))
                    Next
                End If

                AddNode(Node, New CommonTools.Node(New Object(1) {"Average", Recipes.sIVLSweepInfo.sCommon.nAverage}))
                AddNode(Node, New CommonTools.Node(New Object(1) {"Item", Recipes.sIVLSweepInfo.sCommon.measItem}))
                AddNode(Node, New CommonTools.Node(New Object(1) {"Sweep List Length", Recipes.sIVLSweepInfo.sCommon.dSweepList.Length}))
                AddNode(Node, New CommonTools.Node(New Object(1) {"Sweep Delay", Recipes.sIVLSweepInfo.sCommon.dSweepDelay}))
                AddNode(Node, New CommonTools.Node(New Object(1) {"Offset", Recipes.sIVLSweepInfo.sCommon.dOffsetBias}))
                AddNode(Node, New CommonTools.Node(New Object(1) {"Measure Delay", Recipes.sIVLSweepInfo.sCommon.dMeasureDelay}))
                AddNode(Node, New CommonTools.Node(New Object(1) {"Luminance Measure Level", Recipes.sIVLSweepInfo.sCommon.dLMeasLevel}))
                AddNode(Node, New CommonTools.Node(New Object(1) {"Delay Status", Recipes.sIVLSweepInfo.sCommon.DelayState.ToString}))
                AddNode(Node, New CommonTools.Node(New Object(1) {"Cycle Delay", Recipes.sIVLSweepInfo.sCommon.dCycleDelay}))

            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.ePanel_Lifetime, ucSequenceBuilder.eRcpMode.eModule_Lifetime

                '1.Common Settings
                Node = New CommonTools.Node(New Object(1) {"Common", Nothing})
                AddNode(parentNode, Node)
                AddNode(Node, New CommonTools.Node(New Object(1) {"Mode", Recipes.sLifetimeInfo.sCommon.nMode.ToString}))

                '1.1Save Interval
                Dim subNode1 As New CommonTools.Node(New Object(1) {"Save Interval", Nothing})
                AddNode(Node, subNode1)
                For i As Integer = 0 To Recipes.sLifetimeInfo.sCommon.sMeasureInterval.Length - 1
                    Dim subNode2 As New CommonTools.Node(New Object(1) {"Step" & Format(i + 1, "00"), Recipes.sLifetimeInfo.sCommon.sMeasureInterval(i).Interval})
                    AddNode(subNode1, subNode2)
                    AddNode(subNode2, New CommonTools.Node(New Object(1) {"Interval", CStr(Recipes.sLifetimeInfo.sCommon.sMeasureInterval(i).Interval.dHour)}))
                    AddNode(subNode2, New CommonTools.Node(New Object(1) {"Change", CStr(Recipes.sLifetimeInfo.sCommon.sMeasureInterval(i).Change.dHour)}))
                Next

                '1.2End State
                subNode1 = New CommonTools.Node(New Object(1) {"End State", Nothing})
                AddNode(Node, subNode1)
                AddNode(subNode1, New CommonTools.Node(New Object(1) {"Bias Output", CStr(Recipes.sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput)}))

                '1.3End Condition
                subNode1 = New CommonTools.Node(New Object(1) {"End Condition", Nothing})
                AddNode(Node, subNode1)
                For i As Integer = 0 To Recipes.sLifetimeInfo.sCommon.sLifetimeEnd.Length - 1
                    Dim subNode2 As New CommonTools.Node(New Object(1) {"Condition" & Format(i + 1, "00"), Recipes.sLifetimeInfo.sCommon.sMeasureInterval(i).Interval})
                    AddNode(subNode1, subNode2)
                    AddNode(subNode2, New CommonTools.Node(New Object(1) {"Type", Recipes.sLifetimeInfo.sCommon.sLifetimeEnd(i).nTypeOfParam.ToString}))
                    AddNode(subNode2, New CommonTools.Node(New Object(1) {"Value", Recipes.sLifetimeInfo.sCommon.sLifetimeEnd(i).dValue}))
                Next

                '1.4Panel, Module
                subNode1 = New CommonTools.Node(New Object(1) {"Points", Nothing})
                AddNode(Node, subNode1)
                AddNode(subNode1, New CommonTools.Node(New Object(1) {"Align Mark Distance", Recipes.sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.X & " * " & Recipes.sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.Y}))
                If Recipes.sLifetimeInfo.sCommon.sMeasPoints.MeasPoint Is Nothing = False Then
                    For i As Integer = 0 To Recipes.sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                        AddNode(subNode1, New CommonTools.Node(New Object(1) {"Point" & Format(i + 1, "00"), Recipes.sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint(i).X & " * " & Recipes.sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint(i).Y}))
                    Next
                End If

                '1.5Ref PD Mode
                subNode1 = New CommonTools.Node(New Object(1) {"Ref Luminance", Nothing})
                AddNode(Node, subNode1)
                AddNode(subNode1, New CommonTools.Node(New Object(1) {"Mode", Recipes.sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode.ToString}))
                AddNode(subNode1, New CommonTools.Node(New Object(1) {"Stabilize Time", Recipes.sLifetimeInfo.sCommon.sSetInfosTheRefPD.RenewalTime.nSecound}))

                '2. Unit Cell Info

                For i As Integer = 0 To Recipes.sLifetimeInfo.sCellInfos.Length - 1
                    Node = New CommonTools.Node(New Object(1) {"Cell Settinsg" & Format(i, "00"), Nothing})
                    AddNode(parentNode, Node)
                    AddNode(Node, New CommonTools.Node(New Object(1) {"Sourcing Mode", Recipes.sLifetimeInfo.sCellInfos(i).Mode.ToString}))
                    AddNode(Node, New CommonTools.Node(New Object(1) {"Bias", Recipes.sLifetimeInfo.sCellInfos(i).dBias}))
                    AddNode(Node, New CommonTools.Node(New Object(1) {"Amplitude", Recipes.sLifetimeInfo.sCellInfos(i).dAmplitude}))
                    AddNode(Node, New CommonTools.Node(New Object(1) {"Frequency", Recipes.sLifetimeInfo.sCellInfos(i).Pulse.dFrequency}))
                    AddNode(Node, New CommonTools.Node(New Object(1) {"Duty", Recipes.sLifetimeInfo.sCellInfos(i).Pulse.dDuty}))
                    AddNode(Node, New CommonTools.Node(New Object(1) {"Enable Duty Division", Recipes.sLifetimeInfo.sCellInfos(i).Pulse.bEnableDutyDivision}))
                    AddNode(Node, New CommonTools.Node(New Object(1) {"Enable Bias Reverse Mode", Recipes.sLifetimeInfo.sCellInfos(i).bEnableRevMode}))
                    AddNode(Node, New CommonTools.Node(New Object(1) {"Enable Constant Brightness Mode", Recipes.sLifetimeInfo.sCellInfos(i).nConstantBrightnessMode}))
                Next

                '3. Panel
                Node = New CommonTools.Node(New Object(1) {"Panel Settinsg", Nothing})
                AddNode(parentNode, Node)
                'Recipes.sLifetimeInfo.sPanelInfos.nLenSignal()
                'Recipes.sLifetimeInfo.sPanelInfos.sParamData(0).dAmplitude

                '4.Module 
                Node = New CommonTools.Node(New Object(1) {"Module Settinsg", Nothing})
                AddNode(parentNode, Node)

            Case ucSequenceBuilder.eRcpMode.eChangeTemperature
                AddNode(parentNode, New CommonTools.Node(New Object(1) {"Target Temp", Recipes.sChangeTemp.dTargetTemp}))
                AddNode(parentNode, New CommonTools.Node(New Object(1) {"Stablize Time(s)", Recipes.sChangeTemp.StableTime.nSecound}))
            Case ucSequenceBuilder.eRcpMode.eModule_ImageSweep

            Case ucSequenceBuilder.eRcpMode.eModule_GrayScaleSweep


        End Select

    End Sub

    Private Sub AddNode(ByVal parentNode As CommonTools.Node, ByVal Node As CommonTools.Node)
        parentNode.Nodes.Add(Node)
    End Sub

#End Region







End Class