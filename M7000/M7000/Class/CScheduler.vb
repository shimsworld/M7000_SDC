Imports System.Threading
Imports System.IO

Public Class CScheduler



#Region "Defines"

    Dim fMain As frmMain

    Public Shared sCaptions_State() As String = New String() {"IDLE",
                                                              "RUN",
                                                              "STOP",
                                                              "Temp. Setting",
                                                              "Temp. Change",
                                                              "Temp. Stabilization",
                                                              "Next Sequence",
                                                              "Lifetime Setting",
                                                              "Lifetime Running",
                                                              "Lifetime End",
                                                              "Emergency Stopped",
                                                              "IVL Sweep",
                                                              "",
                                                              "",
                                                              "",
                                                              "Viewing Angle",
                                                              "FirstIVLSweep"}

    Public Structure sSYSTIMECNt
        Dim IsSavedModeStartTime As Boolean
        Dim ModeStartTime As Date  '저장 형식 "2/16/1992 13:15:12"   'Sequence의 각 Recipe의 시작 시간, Stress 가 시작 된 시간
        Dim IsSavedTestStartTime As Boolean
        Dim TestStartTime As Date
        Dim IntervalStartTime As Date
        Dim IsSavedIntervalStartTime As Boolean
        Dim LifeTime As CTime.sTimeValue
        Dim IsSavedLifeTime As Boolean
        'Dim PrimaryLifeTimeStartTime As Date '맨 처음 Ref PD 측정하기 위한 LifeTime 시작 PrimaryLifeTimeStartTime시간 값을 저장 2013-04-17 승현
        'Dim IsPrimaryLifeTimeStartTime As Boolean '맨 처음 초기 시간 값을 저장 여부
    End Structure

    Public Enum eChSchedulerSTATE
        eIdle = 0
        eRun = 1
        eStop
        eChangeTemp_Set
        eChangeTemp_WaitingTemp
        eChangeTemp_Stabilization
        eChangeNextSeq
        eLifeTime_SetSourcing     '채널 하나에 Cell,  모듈, 패널이 같이 존재 하지 않기 때문에, 변돌로 분리 하지 않는다.
        eLifeTime_Running
        eLifeTime_StopSourcing     'IVL , Image Sweep, Gray Scale Sweep 추가
        eModule_PatternMeasure
        eIVLSweep
        eResetAllTime
        eResetModeTime
        eResetInterval
        eViewingAngle
        eFirstIVLSweepAfterLifetime
        eAging_SetSourcing
        eAging_Running
        eAging_StopSourcing
    End Enum

#End Region


#Region "Creator & Disposer"

    Public Sub New(ByVal main As frmMain)
        fMain = main
        ReDim g_ChSchedulerStatus(g_nMaxCh - 1)
        ReDim g_SYSTIMEInfo(g_nMaxCh - 1)
        ReDim g_BoardErrorStatus(g_nMaxCh - 1)
        If Directory.Exists(g_sSaveDirectory_StateInfo) = False Then
            Directory.CreateDirectory(g_sSaveDirectory_StateInfo)
        End If

        For idx As Integer = 0 To g_nMaxCh - 1
            g_BoardErrorStatus(idx) = False
        Next

    End Sub

    Public Sub Dispose()
        Me.Finalize()
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region


#Region "Timer Count Loop and Sequence ADD(trdTimeCunt)"

    Dim arrTime As Array
    Public g_BoardErrorStatus() As Boolean
    Dim g_fPasueTrdTimer As Boolean
    Dim g_fStopTrdTimer As Boolean
    Private trdTimer As Thread

    Public g_ChSchedulerStatus() As eChSchedulerSTATE
    Public g_SYSTIMEInfo() As sSYSTIMECNt


    Public Sub StartTrdTimer()
        trdTimer = New Thread(AddressOf TimeScheduleLoop)
        trdTimer.Priority = ThreadPriority.BelowNormal
        trdTimer.TrySetApartmentState(ApartmentState.MTA)
        trdTimer.Start()
        g_fPasueTrdTimer = False
        g_fStopTrdTimer = False
    End Sub

    Public Sub StopTrdTimer()
        g_fPasueTrdTimer = False
        g_fStopTrdTimer = True
    End Sub

    Public Sub ResumeTrdTimer()
        If trdTimer.IsAlive = True Then
            Dim state As ThreadState = trdTimer.ThreadState
            Select Case state
                Case ThreadState.Aborted
                    '  trdTimer.Start()
                Case ThreadState.AbortRequested
                    '   trdTimer.Start()
                Case ThreadState.Background

                Case ThreadState.Running

                Case ThreadState.Stopped
                    '  trdTimer.Start()
                Case ThreadState.StopRequested
                    ' trdTimer.Start()
                Case ThreadState.Suspended
                    ' trdTimer.Start()
                Case ThreadState.SuspendRequested
                    '  trdTimer.Start()
                Case ThreadState.Unstarted
                    '   trdTimer.Start()
                Case ThreadState.WaitSleepJoin
                    trdTimer.Abort()
                    Application.DoEvents()
                    Thread.Sleep(100)
                    StartTrdTimer()
            End Select
        End If

    End Sub

    Private Sub TimeScheduleLoop()
        Dim nCntCH As Integer
        Dim bReadyToMeas As Boolean = False
        Dim TotalTestTime() As TimeSpan  '현재 채널의 총 가동시간 SequenceList에 등록된 모든 Test Recipe의 구동 시간 총합, Run, Stop 에만 갱신
        Dim ModeTime() As TimeSpan    'SequenceList에 등록된 각 Test Recipe(Change Temp or Lifetime) 단위의 진행시간, Next Recipe로 전환될때 갱신 된다.
        Dim DeltaT() As TimeSpan  '측정 인터벌 시간 체크용

        ' Dim ModeDeltaTime As TimeSpan  '남은
        Dim strCurrTime As String
        Dim nCntidleCh As Integer = 0

        Dim nTestCnt As Integer = 0

        ReDim TotalTestTime(g_nMaxCh - 1)
        ReDim ModeTime(g_nMaxCh - 1)
        ReDim DeltaT(g_nMaxCh - 1)

        fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_THREAD_START, "Scheduler Start")

        Do

            '' ''SDC 시계 Test 추가  -   삭제해도 무관 함.
            ' ''If fMain.m_bTime = True Then
            ' ''    strCurrTime = CTime.Get_HMS
            ' ''    fMain.lblRealTime.Text = strCurrTime '"HH : MM : SS"
            ' ''End If

            Application.DoEvents()
            '  Thread.Sleep(100)
            Thread.Sleep(10)


            'If g_ConfigInfos.CIMConfig.bCIMUsed = True Then
            '    LabelOnlineState()
            'End If

            If g_fStopTrdTimer = True Then
                Exit Do
            End If

            fMain.frmLog.SchedulerCounter(Format(nCntCH, "000"))

            strCurrTime = CTime.GetCurrentTimeToStringType

            Select Case g_ChSchedulerStatus(nCntCH)

                Case eChSchedulerSTATE.eIdle   '대기상태 아무것도 하면 안됨. 심지어 초기화 조차도.
                    '=================================================================================
                    fMain.frmLog.SetStateMsg(nCntCH, "TIMER STATE : IDLE")
                    nCntidleCh += 1


                    '    fMain.SetCbPalletChange(nTestCnt)
                    '   nTestCnt += 1
                    '  If nTestCnt >= 10 Then
                    'nTestCnt = 0
                    '  End If
                    '  Thread.Sleep(1000)
                Case eChSchedulerSTATE.eRun

                    '=================================================================================
                    fMain.frmLog.SetStateMsg(nCntCH, "TIMER STATE : Run")

                    bReadyToMeas = True

                    fMain.frmControlUI.ControlUI.control.StopReason(nCntCH) = "[-]"

                    'For Only LGC : B Group 의 채널중 하나라도 실행 중이면  B Group의 다른 채널을 포함하여 모두 대기해야 함.

                    Dim myJIGNumner As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eJIG_No)

                    '            fMain.bDCOL_MoveOut_JIG(myJIGNumner) = True

                    ' If CanChangeNextSequence(nCntCH) = True Then
                    '-----------------------------------------------------------------------
                    fMain.SequenceList(nCntCH).RequestTest = False
                    fMain.g_SweepStop(nCntCH) = False
                    fMain.SequenceList(nCntCH).RequestIVLSweep = False
                    fMain.SequenceList(nCntCH).RequestLifetimeAndIVL = False
                    '  fMain.SequenceList(nCntCH).IVLSweepMeasCount = 0

                    '   fMain.SequenceList(nCntCH).RequestFirstTest = False
                    '----------------------------------------------
                    fMain.SequenceList(nCntCH).ChangeNextRecipe()

                    Select Case fMain.SequenceList(nCntCH).Current.nMode

                        Case ucSequenceBuilder.eRcpMode.eChangeTemperature
                            g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eChangeTemp_Set
                        Case ucSequenceBuilder.eRcpMode.eCell_IVL, ucSequenceBuilder.eRcpMode.ePanel_IVL, ucSequenceBuilder.eRcpMode.eModuel_IVL
                            g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIVLSweep

                        Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.ePanel_Lifetime, ucSequenceBuilder.eRcpMode.eModule_Lifetime, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                            If fMain.SequenceList(nCntCH).LoopCount = 0 Then '처음에만 헤더값을 저장. 
                                For i As Integer = 0 To fMain.SequenceList(nCntCH).SequenceInfo.sRecipes(fMain.SequenceList(nCntCH).CurrentRecipeIndex).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                                    fMain.g_DataSaver(nCntCH).CreateSaveFile(fMain.SequenceList(nCntCH).CurrentRecipeIndex, i)
                                    fMain.SequenceList(nCntCH).IVLSweepMeasCount = 0  '초기화  위치 변경 필요
                                    If fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then
                                        fMain.g_DataSaver(nCntCH).SaveHeaderInfoOfLT(fMain.SequenceList(nCntCH).Current.recipeIndex_LifetimeAndIVL, fMain.SequenceList(nCntCH).Current)
                                    Else
                                        fMain.g_DataSaver(nCntCH).SaveHeaderInfoOfLT(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current, i)
                                    End If
                                Next

                                '  fMain.g_DataSaver(nCntCH).SaveHeaderInfoOfLT(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current)
                            End If

                            If fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then
                                'LoopCount = 0 And 초기 IVL 측정 플레그  = True
                                If fMain.SequenceList(nCntCH).LoopCount = 0 And fMain.SequenceList(nCntCH).Current.sIVLSweepInfo.sCommon.bFirstSweep = True Then 'Then '
                                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eFirstIVLSweepAfterLifetime
                                Else
                                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_SetSourcing
                                End If
                            Else
                                g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_SetSourcing
                            End If


                            'Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                            '    If fMain.SequenceList(nCntCH).LoopCount = 0 Then '처음에만 헤더값을 저장. 
                            '        fMain.g_DataSaver(nCntCH).CreateSaveFile(fMain.SequenceList(nCntCH).CurrentRecipeIndex)
                            '        fMain.g_DataSaver(nCntCH).SaveHeaderInfoOfLT(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current)
                            '    End If
                            '    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_SetSourcing

                            'Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                            '    If fMain.SequenceList(nCntCH).LoopCount = 0 Then '처음에만 헤더값을 저장. 
                            '        fMain.g_DataSaver(nCntCH).CreateSaveFile(fMain.SequenceList(nCntCH).CurrentRecipeIndex)
                            '        fMain.g_DataSaver(nCntCH).SaveHeaderInfoOfLT(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current)
                            '    End If
                            '    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_SetSourcing
                        Case ucSequenceBuilder.eRcpMode.eModule_ImageSweep

                        Case ucSequenceBuilder.eRcpMode.eModule_GrayScaleSweep

                        Case ucSequenceBuilder.eRcpMode.eViewingAngle
                            g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eViewingAngle
                    End Select

                    'If fMain.SequenceList(nCntCH).LoopCount = 0 Then '처음에만 헤더값을 저장. 
                    '    fMain.DataSaver(nCntCH).SaveHeaderInfo(fMain.SequenceList(nCntCH).Current.recipeIndex, fMain.SequenceList(nCntCH).Current)
                    'End If

                    With g_SYSTIMEInfo(nCntCH)
                        If .IsSavedTestStartTime = False Then
                            .TestStartTime = Date.Parse(strCurrTime)
                            .IsSavedTestStartTime = True
                        End If

                        If .IsSavedModeStartTime = False Then
                            .ModeStartTime = Date.Parse(strCurrTime)
                            .IsSavedModeStartTime = True
                        End If

                        fMain.frmLog.SetStartTime(nCntCH, CStr(.TestStartTime) & "||" & CStr(.ModeStartTime))
                    End With

                    fMain.g_StateMsgHandler.messageToUserErrorCode(nCntCH, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_CH_TEST_BEGIN, "")
                    '-----------------------------------------------------------------------
                    ' End If

                Case eChSchedulerSTATE.eResetAllTime
                    '=================================================================================

                    With g_SYSTIMEInfo(nCntCH)
                        .IsSavedTestStartTime = False
                        .IsSavedModeStartTime = False
                    End With
                    'g_CHTimerSTATe(nCntCH) = eCHTimerSTATE.eRunning

                Case eChSchedulerSTATE.eResetModeTime
                    '=================================================================================
                    With g_SYSTIMEInfo(nCntCH)
                        .IsSavedModeStartTime = False
                    End With
                    'g_CHTimerSTATe(nCntCH) = eCHTimerSTATE.eRunning


                Case eChSchedulerSTATE.eChangeTemp_Set
                    '=================================================================================
                    Dim nGroup As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eGroupOfTC)
                    Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfTC)
                    Dim nChNo As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eChOfTC)

                    fMain.cTC(nGroup).SetTemp(nDevNo, nChNo, fMain.SequenceList(nCntCH).Current.sChangeTemp.dTargetTemp)

                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eChangeTemp_WaitingTemp
                    g_SYSTIMEInfo(nCntCH).ModeStartTime = Date.Parse(strCurrTime)

                Case eChSchedulerSTATE.eChangeTemp_Stabilization
                    '=================================================================================
                    'DeltaT(nCntCH) = Now.Subtract(g_SYSTIMEInfo(nCntCH).IntervalStartTime)

                    If fMain.SequenceList(nCntCH).SequenceInfo.nCounterChangedTemp = 1 Then
                        If fMain.SequenceList(nCntCH).LoopCount > 0 Then
                            g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eChangeNextSeq
                            g_SYSTIMEInfo(nCntCH).IsSavedIntervalStartTime = False
                        End If
                    End If

                    ModeTime(nCntCH) = Now.Subtract(g_SYSTIMEInfo(nCntCH).ModeStartTime)

                    Dim m_mode As String
                    Dim sMsg As String
                    m_mode = "Temp"
                    sMsg = CStr(nCntCH + 1) & _
                           "| MODE : " & m_mode & _
                           "| Stable Time : " & Format(ModeTime(nCntCH).TotalSeconds, "0000")
                    '"| Stable Time : " & Format(DeltaT(nCntCH).TotalSeconds, "0000")

                    fMain.frmLog.SetStateMsg(nCntCH, sMsg)

                    If ModeTime(nCntCH).TotalSeconds >= fMain.SequenceList(nCntCH).Current.sChangeTemp.StableTime.nSecound Then
                        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eChangeNextSeq
                        g_SYSTIMEInfo(nCntCH).IsSavedIntervalStartTime = False
                    End If

                    'If DeltaT(nCntCH).TotalSeconds >= fMain.SequenceList(nCntCH).Current.sChangeTemp.StableTime.nSecound Then
                    '    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eChangeNextSeq
                    '    g_SYSTIMEInfo(nCntCH).IsSavedIntervalStartTime = False
                    'End If

                Case eChSchedulerSTATE.eChangeTemp_WaitingTemp
                    '=================================================================================
                    If fMain.g_MeasuredDatas(nCntCH).dTemp <= fMain.SequenceList(nCntCH).Current.sChangeTemp.dTargetTemp + 0.2 And
                        fMain.g_MeasuredDatas(nCntCH).dTemp >= fMain.SequenceList(nCntCH).Current.sChangeTemp.dTargetTemp - 0.2 Then

                        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eChangeTemp_Stabilization
                        g_SYSTIMEInfo(nCntCH).ModeStartTime = Date.Parse(strCurrTime)
                        '    g_SYSTIMEInfo(nCntCH).IntervalStartTime = Date.Parse(strCurrTime)
                        ' g_SYSTIMEInfo(nCntCH).IsSavedIntervalStartTime = True
                    Else
                        ModeTime(nCntCH) = Now.Subtract(g_SYSTIMEInfo(nCntCH).ModeStartTime)
                    End If

                Case eChSchedulerSTATE.eChangeNextSeq
                    '=================================================================================
                    Dim combinedCh() As Integer = Nothing
                    Dim stateCounter As Integer = 0
                    Dim dTimeBuffer As Double
                    Dim bTempEnable As Boolean = False
                    Dim sMsg_StopReason As String = ""

                    For idx As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
                        If g_ConfigInfos.nDevice(idx) = frmConfigSystem.eDeviceItem.eTC Then
                            bTempEnable = True
                        End If
                    Next

                    If bTempEnable = True Then
                        combinedCh = ChekCombinedChannel(nCntCH)
                    End If
                    '  combinedCh = frmSettingWind.ChekCombinedChannelAsTC(nCntCH)

                    '시간 누적 관리
                    ModeTime(nCntCH) = Now.Subtract(g_SYSTIMEInfo(nCntCH).ModeStartTime)
                    If g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = False Then
                        If fMain.SequenceList(nCntCH).SequenceInfo.sCommon.saveOptions.isAccumulateTempChangeTime = True Then  'LifeTime에 온도 변경시간을 누적
                            dTimeBuffer = g_SYSTIMEInfo(nCntCH).LifeTime.dHour + ModeTime(nCntCH).TotalHours
                            g_SYSTIMEInfo(nCntCH).LifeTime = CTime.Convert_HoureToTimeValue(dTimeBuffer)
                        Else
                            If fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_Lifetime Or
                                fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.ePanel_Lifetime Or
                                fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eModule_Lifetime Or
                                 fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then
                                dTimeBuffer = g_SYSTIMEInfo(nCntCH).LifeTime.dHour + ModeTime(nCntCH).TotalHours 'LifeTime에 Aging시간만 누적
                                g_SYSTIMEInfo(nCntCH).LifeTime = CTime.Convert_HoureToTimeValue(dTimeBuffer)
                            End If
                        End If
                        g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = True
                    End If


                    '전환 조건 체크
                    'If CanChangeNextSequence(nCntCH) = True Then
                    '----------------------------------------------------------
                    '같은 지그를 사용하는 채널중 1개의 채널이라도 Aging이 끝나지 않았으면, 온도를 변경하지 않기 위하여, 다음 Sequence로 전화하지 않는 코드
                    If bTempEnable = True Then
                        For i As Integer = 0 To combinedCh.Length - 1
                            If g_ChSchedulerStatus(combinedCh(i)) = eChSchedulerSTATE.eLifeTime_Running Then

                                stateCounter += 1
                            End If
                        Next
                    Else
                        stateCounter = 0
                    End If


                    If stateCounter = 0 Then '모두 Lifetime이 아니므로 다음 상태로 전환 할 수 있다.  LifeTime --> Temp

                        'If fMain.SequenceList(nCntCH).IsLastSequence = True Then
                        '    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eStop
                        '    g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = False
                        'Else
                        'Seq 상태 저장 추가 2013-03-21
                        fMain.SequenceList(nCntCH).ChangeNextRecipe()
                        Select Case fMain.SequenceList(nCntCH).Current.nMode
                            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                                If fMain.SequenceList(nCntCH).LoopCount = 0 Then '처음에만 헤더값을 저장. 
                                    fMain.g_DataSaver(nCntCH).CreateSaveFile(fMain.SequenceList(nCntCH).CurrentRecipeIndex)

                                    Select Case fMain.SequenceList(nCntCH).Current.nMode
                                        Case ucSequenceBuilder.eRcpMode.eCell_Lifetime
                                            fMain.g_DataSaver(nCntCH).SaveHeaderInfoOfLT(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current) '  헤더 출력 2번 lifeTime 으로 변경 2013-04-08 승현
                                        Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                                            fMain.g_DataSaver(nCntCH).SaveHeaderInfoOfLT(fMain.SequenceList(nCntCH).Current.recipeIndex_LifetimeAndIVL, fMain.SequenceList(nCntCH).Current) '  헤더 출력 2번 lifeTime 으로 변경 2013-04-08 승현
                                    End Select

                                End If

                                If IsCheckedEndConditions(nCntCH, fMain.SequenceList(nCntCH).SequenceInfo.sCommon.sSequenceEnd, sMsg_StopReason) = True Then
                                    If fMain.cTC Is Nothing = False Then
                                        Dim nGroupOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eGroupOfTC)
                                        Dim nDevNoOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfTC)
                                        Dim nChNoOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eChOfTC)

                                        If nGroupOfTC >= 0 And nDevNoOfTC >= 0 And nChNoOfTC >= 0 Then
                                            fMain.cTC(nGroupOfTC).SetTemp(nDevNoOfTC, nChNoOfTC, fMain.SequenceList(nCntCH).SequenceInfo.sCommon.dDefaultTemp)
                                        End If
                                    End If

                                    'UI 상태 초기화
                                    fMain.frmControlUI.ControlUI.control.IsLoadedSequenceInfo(nCntCH) = False
                                    fMain.frmControlUI.ControlUI.control.IsLoadedSavePath(nCntCH) = False
                                    fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCntCH).Information = "Stop"
                                    fMain.g_StateMsgHandler.messageToUserErrorCode(nCntCH, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_CH_TEST_END, "")
                                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIdle
                                    bReadyToMeas = False
                                Else

                                    'LoopCount = 0 And 초기 IVL 측정 플레그  = True
                                    If fMain.SequenceList(nCntCH).LoopCount = 0 And fMain.SequenceList(nCntCH).Current.sIVLSweepInfo.sCommon.bFirstSweep = True Then 'Then '
                                        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eFirstIVLSweepAfterLifetime
                                    Else
                                        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_SetSourcing
                                    End If

                                    ' g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_SetSourcing
                                End If

                                '   g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_SetSourcing
                                g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = False
                            Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                                If fMain.SequenceList(nCntCH).LoopCount = 0 Then '처음에만 헤더값을 저장. 
                                    '     fMain.DataSaver(nCntCH).SaveHeaderInfo(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current) ' 이쪽
                                    fMain.g_DataSaver(nCntCH).CreateSaveFile(fMain.SequenceList(nCntCH).CurrentRecipeIndex)
                                    fMain.g_DataSaver(nCntCH).SaveHeaderInfoOfLT(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current) '  헤더 출력 2번 lifeTime 으로 변경 2013-04-08 승현
                                End If
                                g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_SetSourcing
                                g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = False
                            Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                                If fMain.SequenceList(nCntCH).LoopCount = 0 Then '처음에만 헤더값을 저장. 
                                    '     fMain.DataSaver(nCntCH).SaveHeaderInfo(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current) ' 이쪽
                                    fMain.g_DataSaver(nCntCH).CreateSaveFile(fMain.SequenceList(nCntCH).CurrentRecipeIndex)
                                    fMain.g_DataSaver(nCntCH).SaveHeaderInfoOfLT(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current) '  헤더 출력 2번 lifeTime 으로 변경 2013-04-08 승현
                                End If

                                ''Check End Conditions
                                'Check End Conditions
                                '==================================================================================================
                                If IsCheckedEndConditions(nCntCH, fMain.SequenceList(nCntCH).SequenceInfo.sCommon.sSequenceEnd, sMsg_StopReason) = True Then
                                    fMain.frmControlUI.ControlUI.control.StopReason(nCntCH) = sMsg_StopReason
                                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIdle
                                Else
                                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_SetSourcing
                                End If
                                '=============================================================================================================================================

                                g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = False
                            Case ucSequenceBuilder.eRcpMode.eChangeTemperature
                                g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eChangeTemp_Set
                                g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = False


                                If IsCheckedEndConditions(nCntCH, fMain.SequenceList(nCntCH).SequenceInfo.sCommon.sSequenceEnd, sMsg_StopReason) = True Then
                                    fMain.frmControlUI.ControlUI.control.StopReason(nCntCH) = sMsg_StopReason
                                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIdle

                                    If fMain.cTC Is Nothing = False Then
                                        Dim nGroupOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eGroupOfTC)
                                        Dim nDevNoOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfTC)
                                        Dim nChNoOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eChOfTC)

                                        If nGroupOfTC >= 0 And nDevNoOfTC >= 0 And nChNoOfTC >= 0 Then
                                            fMain.cTC(nGroupOfTC).SetTemp(nDevNoOfTC, nChNoOfTC, fMain.SequenceList(nCntCH).SequenceInfo.sCommon.dDefaultTemp)
                                        End If
                                    End If

                                    fMain.frmControlUI.ControlUI.control.IsLoadedSequenceInfo(nCntCH) = False
                                    fMain.frmControlUI.ControlUI.control.IsLoadedSavePath(nCntCH) = False
                                    fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCntCH).Information = "Stop"
                                    fMain.g_StateMsgHandler.messageToUserErrorCode(nCntCH, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_CH_TEST_END, "")

                                End If


                            Case ucSequenceBuilder.eRcpMode.eCell_IVL, ucSequenceBuilder.eRcpMode.ePanel_IVL, ucSequenceBuilder.eRcpMode.eModuel_IVL, ucSequenceBuilder.eRcpMode.eViewingAngle
                                If IsCheckedEndConditions(nCntCH, fMain.SequenceList(nCntCH).SequenceInfo.sCommon.sSequenceEnd, sMsg_StopReason) = True Then
                                    'g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIdle
                                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eStop
                                    If fMain.cTC Is Nothing = False Then
                                        Dim nGroupOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eGroupOfTC)
                                        Dim nDevNoOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfTC)
                                        Dim nChNoOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eChOfTC)

                                        If nGroupOfTC >= 0 And nDevNoOfTC >= 0 And nChNoOfTC >= 0 Then
                                            fMain.cTC(nGroupOfTC).SetTemp(nDevNoOfTC, nChNoOfTC, fMain.SequenceList(nCntCH).SequenceInfo.sCommon.dDefaultTemp)
                                        End If
                                    End If

                                    'UI 상태 초기화
                                    '   fMain.frmControlUI.ControlUI.control.IsLoadedSequenceInfo(nCntCH) = False
                                    '   fMain.frmControlUI.ControlUI.control.IsLoadedSavePath(nCntCH) = False
                                    fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCntCH).Information = "Stop"
                                    fMain.g_StateMsgHandler.messageToUserErrorCode(nCntCH, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_CH_TEST_END, "")
                                    bReadyToMeas = False
                                Else
                                    If fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eViewingAngle Then
                                        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eViewingAngle
                                    Else
                                        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIVLSweep
                                    End If
                                End If
                                g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = False

                                'Case ucSequenceBuilder.eRcpMode.eViewingAngle
                                '    If IsCheckedEndConditions(nCntCH, fMain.SequenceList(nCntCH).SequenceInfo.sCommon.sSequenceEnd, sMsg_StopReason) = True Then
                                '        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIdle
                                '    Else
                                '        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eViewingAngle
                                '    End If
                                '    g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = False
                        End Select

                        'If fMain.SequenceList(nCntCH).LoopCount = 0 Then '처음에만 헤더값을 저장. 
                        '    '     fMain.DataSaver(nCntCH).SaveHeaderInfo(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current) ' 이쪽
                        '    fMain.DataSaver(nCntCH).SaveHeaderInfo(fMain.SequenceList(nCntCH).Current.recipeIndex, fMain.SequenceList(nCntCH).Current) '  헤더 출력 2번 lifeTime 으로 변경 2013-04-08 승현
                        'End If

                        'End If

                    Else '만약 현재 채널의 상태가 온도가변이라면 LifeTime으로 전환해도 됨. Temp --> LifeTime으로

                        If fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then
                            'Seq 상태 저장 추가 2013-03-21
                            fMain.SequenceList(nCntCH).ChangeNextRecipe()
                            Select Case fMain.SequenceList(nCntCH).Current.nMode
                                Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                                    If fMain.SequenceList(nCntCH).LoopCount = 0 Then '처음에만 헤더값을 저장. 
                                        fMain.g_DataSaver(nCntCH).CreateSaveFile(fMain.SequenceList(nCntCH).CurrentRecipeIndex)
                                        fMain.g_DataSaver(nCntCH).SaveHeaderInfoOfLT(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current)
                                    End If
                                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_SetSourcing
                                    g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = False
                                Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                                    If fMain.SequenceList(nCntCH).LoopCount = 0 Then '처음에만 헤더값을 저장. 
                                        '     fMain.DataSaver(nCntCH).SaveHeaderInfo(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current) ' 이쪽
                                        fMain.g_DataSaver(nCntCH).CreateSaveFile(fMain.SequenceList(nCntCH).CurrentRecipeIndex)
                                        fMain.g_DataSaver(nCntCH).SaveHeaderInfoOfLT(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current) '  헤더 출력 2번 lifeTime 으로 변경 2013-04-08 승현
                                    End If
                                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_SetSourcing
                                    g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = False
                                Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                                    If fMain.SequenceList(nCntCH).LoopCount = 0 Then '처음에만 헤더값을 저장. 
                                        '     fMain.DataSaver(nCntCH).SaveHeaderInfo(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current) ' 이쪽
                                        fMain.g_DataSaver(nCntCH).CreateSaveFile(fMain.SequenceList(nCntCH).CurrentRecipeIndex)
                                        fMain.g_DataSaver(nCntCH).SaveHeaderInfoOfLT(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current) '  헤더 출력 2번 lifeTime 으로 변경 2013-04-08 승현
                                    End If

                                    ''Check End Conditions
                                    'Check End Conditions
                                    '==================================================================================================
                                    If IsCheckedEndConditions(nCntCH, fMain.SequenceList(nCntCH).SequenceInfo.sCommon.sSequenceEnd, sMsg_StopReason) = True Then
                                        fMain.frmControlUI.ControlUI.control.StopReason(nCntCH) = sMsg_StopReason
                                        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIdle
                                    Else
                                        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_SetSourcing
                                    End If
                                    '=============================================================================================================================================
                                    g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = False
                                Case ucSequenceBuilder.eRcpMode.eChangeTemperature
                                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eChangeTemp_Set
                                    g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = False

                                Case ucSequenceBuilder.eRcpMode.eCell_IVL, ucSequenceBuilder.eRcpMode.ePanel_IVL, ucSequenceBuilder.eRcpMode.eModuel_IVL, ucSequenceBuilder.eRcpMode.eViewingAngle
                                    If IsCheckedEndConditions(nCntCH, fMain.SequenceList(nCntCH).SequenceInfo.sCommon.sSequenceEnd, sMsg_StopReason) = True Then
                                        fMain.frmControlUI.ControlUI.control.StopReason(nCntCH) = sMsg_StopReason
                                        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIdle
                                        bReadyToMeas = False

                                        If fMain.cTC Is Nothing = False Then
                                            Dim nGroupOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eGroupOfTC)
                                            Dim nDevNoOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfTC)
                                            Dim nChNoOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eChOfTC)

                                            If nGroupOfTC >= 0 And nDevNoOfTC >= 0 And nChNoOfTC >= 0 Then
                                                fMain.cTC(nGroupOfTC).SetTemp(nDevNoOfTC, nChNoOfTC, fMain.SequenceList(nCntCH).SequenceInfo.sCommon.dDefaultTemp)
                                            End If
                                        End If

                                        'UI 상태 초기화
                                        '   fMain.frmControlUI.ControlUI.control.IsLoadedSequenceInfo(nCntCH) = False
                                        '   fMain.frmControlUI.ControlUI.control.IsLoadedSavePath(nCntCH) = False
                                        fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCntCH).Information = "Stop"
                                        fMain.g_StateMsgHandler.messageToUserErrorCode(nCntCH, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_CH_TEST_END, "")

                                    Else
                                        If fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eViewingAngle Then
                                            g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eViewingAngle
                                        Else
                                            g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIVLSweep
                                        End If

                                        fMain.g_DataSaver(nCntCH).CreateSaveFile(fMain.SequenceList(nCntCH).CurrentRecipeIndex)
                                    End If

                                    g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = False

                                    'Case ucSequenceBuilder.eRcpMode.eViewingAngle
                                    '    If IsCheckedEndConditions(nCntCH, fMain.SequenceList(nCntCH).SequenceInfo.sCommon.sSequenceEnd, sMsg_StopReason) = True Then
                                    '        fMain.frmControlUI.ControlUI.control.StopReason(nCntCH) = sMsg_StopReason
                                    '        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIdle
                                    '    Else
                                    '        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eViewingAngle
                                    '        fMain.g_DataSaver(nCntCH).CreateSaveFile(fMain.SequenceList(nCntCH).CurrentRecipeIndex)
                                    '    End If

                                    '    g_SYSTIMEInfo(nCntCH).IsSavedLifeTime = False

                            End Select

                            'If fMain.SequenceList(nCntCH).LoopCount = 0 Then '처음에만 헤더값을 저장. 
                            '    '     fMain.DataSaver(nCntCH).SaveHeaderInfo(fMain.SequenceList(nCntCH).Current.recipeIndex_LifeTime, fMain.SequenceList(nCntCH).Current) ' 이쪽
                            '    fMain.DataSaver(nCntCH).SaveHeaderInfo(fMain.SequenceList(nCntCH).Current.recipeIndex, fMain.SequenceList(nCntCH).Current) '  헤더 출력 2번 lifeTime 으로 변경 2013-04-08 승현
                            'End If


                        End If
                        '같은 지그에 있는 채널이 모두 Lifetime이 종료 될때 까지 대기
                    End If
                    '----------------------------------------------------------
                    'End If

                Case eChSchedulerSTATE.eFirstIVLSweepAfterLifetime

                    If fMain.SequenceList(nCntCH).RequestTest = False Then
                        fMain.SequenceList(nCntCH).RequestTest = True
                        Dim process As CSeqProcessor.sProcessParams
                        process.cmd = CSeqProcessor.eProcessState.IVLSweep
                        process.index = nCntCH
                        process.CommonInfo = fMain.SequenceList(nCntCH).SequenceInfo.sCommon
                        process.sSampleInfos = fMain.SequenceList(nCntCH).SequenceInfo.sSampleInfos
                        process.beforStateModeTime = ModeTime(nCntCH) '이전 상태에서의 누적 시간
                        process.recipe = fMain.SequenceList(nCntCH).Current
                        g_SYSTIMEInfo(nCntCH).ModeStartTime = Date.Parse(strCurrTime)
                        process.requestTime = g_SYSTIMEInfo(nCntCH).ModeStartTime
                        fMain.requestMeas(process)
                    Else
                        ModeTime(nCntCH) = Now.Subtract(g_SYSTIMEInfo(nCntCH).ModeStartTime)
                    End If

                Case eChSchedulerSTATE.eLifeTime_SetSourcing

                    '=================================================================================
                    If fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation Then

                        If fMain.SequenceList(nCntCH).RequestTest = False Then  'Source Output 설정이 완료되기 전에 다음 스텝으로 넘어 가는 것을 방지 하기 위해서, 완료되기 전에 연속으로 설정되는 것도 방지
                            fMain.SequenceList(nCntCH).RequestTest = True
                            Dim process As CSeqProcessor.sProcessParams = Nothing
                            process.cmd = CSeqProcessor.eProcessState.LifeTimeSet
                            process.index = nCntCH
                            process.CommonInfo = fMain.SequenceList(nCntCH).SequenceInfo.sCommon
                            process.sSampleInfos = fMain.SequenceList(nCntCH).SequenceInfo.sSampleInfos
                            process.recipe = fMain.SequenceList(nCntCH).Current
                            process.beforStateModeTime = ModeTime(nCntCH) '이전 상태에서의 누적 시간
                            process.requestTime = Date.Parse(strCurrTime)
                            fMain.requestMeas(process)
                            'fMain.m6000Controller(g_ChAllocationInfos(nCntCH).nDevNoOfM6000).ChannelStatus(g_ChAllocationInfos(nCntCH).nChOfM6000) = CSeqRoutineM6000.eSequenceState.eMeasuring
                        End If

                        Select Case fMain.SequenceList(nCntCH).Current.sLifetimeInfo.nMyMode

                            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL

                                '다른 판별 조건 필요

                                'ACF와 겹치지 않기 위해 처리되고 나서 Running으로 전환시킴
                                If g_SystemInfo.bCompleted_ACF_CH(nCntCH) = True Then
                                    'If fMain.cQueueProcessor.CheckStatusOfM6000(nCntCH, CSeqRoutineM6000.eSequenceState.eMeasuring, fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCellInfos) = True Then
                                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_Running
                                    fMain.SequenceList(nCntCH).RequestTest = False
                                    g_SYSTIMEInfo(nCntCH).ModeStartTime = Date.Parse(strCurrTime)
                                    'source Setting과 데이터 저장을 분리하였던, Setting과 데이터 저장 사이에 다른 채널의 명령에 의한 처리 대기에 영향을 제거하기 위해서
                                    fMain.SequenceList(nCntCH).AccumulateMeasTime() '초기 데이터를 측정하지 않기 위해서...초기 데이터 저장은 ProcessRoutine으로. 'Lex Yang_20140602
                                    'End If
                                End If
                                'If fMain.cM6000(nDevNo_Red).ChannelStatus(nChNo_Red) = CSeqRoutineM6000.eSequenceState.eMeasuring And
                                '    fMain.cM6000(nDevNo_Green).ChannelStatus(nChNo_Green) = CSeqRoutineM6000.eSequenceState.eMeasuring And
                                '    fMain.cM6000(nDevNo_Blue).ChannelStatus(nChNo_Blue) = CSeqRoutineM6000.eSequenceState.eMeasuring Then
                                'End If
                            Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                                Dim nGroup As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfSG)
                                Dim nChNoOfSGGroup As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eChOfSG)
                                If fMain.cMcSG(nGroup).ChannelStatus(nCntCH) = CSeqRoutineSG.eSequenceState.eMeasuring Then
                                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_Running
                                    fMain.SequenceList(nCntCH).RequestTest = False
                                    g_SYSTIMEInfo(nCntCH).ModeStartTime = Date.Parse(strCurrTime)
                                    'source Setting과 데이터 저장을 분리하였던, Setting과 데이터 저장 사이에 다른 채널의 명령에 의한 처리 대기에 영향을 제거하기 위해서
                                    fMain.SequenceList(nCntCH).AccumulateMeasTime() '초기 데이터를 측정하지 않기 위해서...초기 데이터 저장은 ProcessRoutine으로. 'Lex Yang_20140602
                                End If

                            Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                                Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
                                ' Dim nChOfModule As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eChOfModuleGroup)
                                If nDevNo <> -1 Then
                                    If fMain.cPG.PatternGenerator(0).ChannelStatus(nDevNo) = CDevPGCommonNode.eSequenceState.eMeasuring And
                                     g_SystemInfo.bCompleted_ACF_CH(nCntCH) = True Then
                                        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_Running
                                        fMain.SequenceList(nCntCH).RequestTest = False
                                        g_SYSTIMEInfo(nCntCH).ModeStartTime = Date.Parse(strCurrTime)
                                        'source Setting과 데이터 저장을 분리하였던, Setting과 데이터 저장 사이에 다른 채널의 명령에 의한 처리 대기에 영향을 제거하기 위해서
                                        fMain.SequenceList(nCntCH).AccumulateMeasTime() '초기 데이터를 측정하지 않기 위해서...초기 데이터 저장은 ProcessRoutine으로. 'Lex Yang_20140602
                                    End If
                                Else
                                    If g_SystemInfo.bCompleted_ACF_CH(nCntCH) = True Then
                                        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_Running
                                        fMain.SequenceList(nCntCH).RequestTest = False
                                        g_SYSTIMEInfo(nCntCH).ModeStartTime = Date.Parse(strCurrTime)
                                        'source Setting과 데이터 저장을 분리하였던, Setting과 데이터 저장 사이에 다른 채널의 명령에 의한 처리 대기에 영향을 제거하기 위해서
                                        fMain.SequenceList(nCntCH).AccumulateMeasTime() '초기 데이터를 측정하지 않기 위해서...초기 데이터 저장은 ProcessRoutine으로. 'Lex Yang_20140602
                                    End If

                                End If
                        End Select

                    Else 'Keeping Mode
                        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eLifeTime_Running
                        fMain.SequenceList(nCntCH).RequestTest = False
                        g_SYSTIMEInfo(nCntCH).ModeStartTime = Date.Parse(strCurrTime)
                    End If

                Case eChSchedulerSTATE.eLifeTime_Running
                    '=================================================================================
                    TotalTestTime(nCntCH) = Now.Subtract(g_SYSTIMEInfo(nCntCH).TestStartTime)
                    ModeTime(nCntCH) = Now.Subtract(g_SYSTIMEInfo(nCntCH).ModeStartTime)

                    If fMain.SequenceList(nCntCH).RequestIVLSweep = False And fMain.SequenceList(nCntCH).RequestLifetimeAndIVL = False Then
                        '       If fMain.cQueueProcessor.CheckStatusOfM6000(nCntCH, CSeqRoutineM6000.eSequenceState.eMeasuring, fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCellInfos) = True Then
                        ChekLifetimeMeasInterval(nCntCH, TotalTestTime(nCntCH).TotalSeconds, ModeTime(nCntCH).TotalSeconds)
                        'End If
                    End If

                Case eChSchedulerSTATE.eLifeTime_StopSourcing
                    '=================================================================================
                    If fMain.SequenceList(nCntCH).RequestTest = False Then
                        fMain.SequenceList(nCntCH).RequestTest = True

                        If fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = False Then ' 'False : Source Off, True : Source ON 
                            Dim process As CSeqProcessor.sProcessParams = Nothing
                            process.cmd = CSeqProcessor.eProcessState.LifeTimeStop
                            process.index = nCntCH
                            process.beforStateModeTime = ModeTime(nCntCH) '이전 상태에서의 누적 시간
                            process.CommonInfo = fMain.SequenceList(nCntCH).SequenceInfo.sCommon
                            process.sSampleInfos = fMain.SequenceList(nCntCH).SequenceInfo.sSampleInfos
                            process.recipe = fMain.SequenceList(nCntCH).Current
                            process.requestTime = Date.Parse(strCurrTime)

                            'Lifetime + IVL 모드에서는 Processor 루틴에서 Lifetime  종료되고 IVL Sweep이 진행 상태면 소스 Off를 따로 할 필요 없음
                            'If fMain.SequenceList(nCntCH).RequestIVLSweep = True Then
                            '    fMain.g_SweepStop(nCntCH) = True   'IVL Sweep 종료
                            '    Do
                            '        Application.DoEvents()
                            '        Thread.Sleep(50)
                            '    Loop Until fMain.g_SweepStop(nCntCH) = False
                            'Else

                            fMain.requestMeas(process)   'M6000 Sourcing 중단 요청
                            'End If

                        Else '소싱을 끄지 않고 다음 Recip로 넘어가기 --> 온도 변화 중에도 소싱을 계속 한다.
                            g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eChangeNextSeq
                        End If

                    End If

                    Select Case fMain.SequenceList(nCntCH).Current.sLifetimeInfo.nMyMode
                        Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL

                            'If fMain.cQueueProcessor.CheckStatusOfM6000(nCntCH, CSeqRoutineM6000.eSequenceState.eidle, fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCellInfos) = True Then
                            '    '임시방편.....스케쥴러에서는 실험이 종료되어서 보이는데 프로세스에서 Stop이 안됌.....원인 파악중
                            '    Thread.Sleep(2000)
                            '    If fMain.cQueueProcessor.CheckStatusOfM6000(nCntCH, CSeqRoutineM6000.eSequenceState.eidle, fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCellInfos) = True Then
                            g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eChangeNextSeq
                            fMain.SequenceList(nCntCH).RequestTest = False
                            '    End If

                            'End If

                        Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                            Dim nGroupOfSG As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eGroupOfSG)
                            Dim nChNoOfSGGroup As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eChOfSG)
                            If fMain.cMcSG(nGroupOfSG).ChannelStatus(nChNoOfSGGroup) = CSeqRoutineSG.eSequenceState.eidle Then   'Errorr nGroup
                                g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eChangeNextSeq
                                fMain.SequenceList(nCntCH).RequestTest = False
                            End If

                        Case ucSequenceBuilder.eRcpMode.eModule_Lifetime

                            Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)

                            If nDevNo <> -1 Then
                                If fMain.cPG.PatternGenerator(0).ChannelStatus(nDevNo) = CDevPGCommonNode.eSequenceState.eidle Then
                                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eChangeNextSeq
                                    fMain.SequenceList(nCntCH).RequestTest = False
                                End If
                            Else
                                g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eChangeNextSeq
                                fMain.SequenceList(nCntCH).RequestTest = False
                            End If

                        Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL

                    End Select

                Case eChSchedulerSTATE.eStop
                    '=================================================================================
                    ' fMain.g_SweepStop(nCntCH) = True

                    If fMain.SequenceList(nCntCH).RequestTest = False Then
                        fMain.SequenceList(nCntCH).RequestTest = True

                        bReadyToMeas = False

                        With g_SYSTIMEInfo(nCntCH)
                            .IsSavedTestStartTime = False
                            .IsSavedModeStartTime = False
                        End With
                        '  frmMainWnd.lblSystemStatus.Text = "[" & CStr(nCntCH + 1) & "]번 채널 종료중."
                        fMain.deleteMeasQueue(nCntCH)
                        ' fMain.SequenceList(nCntCH).ChageCurrentRecipeToTestEnd() 승현
                        Dim process As CSeqProcessor.sProcessParams = Nothing

                        If fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_Lifetime Or _
                            fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.ePanel_Lifetime Or _
                            fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eModule_Lifetime Or _
                            fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Or _
                            fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then

                            'Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
                            '' Dim nChOfModule As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eChOfModuleGroup)
                            'If nDevNo <> -1 Then
                            '    If fMain.cPG.PatternGenerator(0).ChannelStatus(nDevNo) <> CDevPGCommonNode.eSequenceState.eidle Then  'Lifetime Setting 전(실험 시작 전)에 채널을 중지 시켰을 때는 종료 측정 필요 없음
                            '        process.cmd = CSeqProcessor.eProcessState.LifeTimeMeas
                            '        process.index = nCntCH
                            '        process.CommonInfo = fMain.SequenceList(nCntCH).SequenceInfo.sCommon
                            '        process.sSampleInfos = fMain.SequenceList(nCntCH).SequenceInfo.sSampleInfos
                            '        process.recipe = fMain.SequenceList(nCntCH).Current
                            '        fMain.requestMeas(process)   '데이터 측정 요청
                            '    End If
                            'End If

                            process.cmd = CSeqProcessor.eProcessState.LifeTimeStop
                            process.index = nCntCH
                            process.CommonInfo = fMain.SequenceList(nCntCH).SequenceInfo.sCommon
                            process.sSampleInfos = fMain.SequenceList(nCntCH).SequenceInfo.sSampleInfos
                            process.recipe = fMain.SequenceList(nCntCH).Current

                            'Lifetime + IVL 모드에서는 Processor 루틴에서Lifetime이 종료되고 IVL Sweep이 진행 상태면 종료시 측정하는 부분이 필요 없음.
                            If fMain.SequenceList(nCntCH).RequestIVLSweep = False Then
                                fMain.requestMeas(process)   'M6000 Sourcing 중단 요청
                            End If
                        End If

                        If fMain.cTC Is Nothing = False Then
                            Dim nGroupOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eGroupOfTC)
                            Dim nDevNoOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfTC)
                            Dim nChNoOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eChOfTC)

                            If nGroupOfTC >= 0 And nDevNoOfTC >= 0 And nChNoOfTC >= 0 Then
                                fMain.cTC(nGroupOfTC).SetTemp(nDevNoOfTC, nChNoOfTC, fMain.SequenceList(nCntCH).SequenceInfo.sCommon.dDefaultTemp)
                            End If

                        End If

                    End If


                    Select Case fMain.SequenceList(nCntCH).Current.sLifetimeInfo.nMyMode
                        Case ucSequenceBuilder.eRcpMode.eCell_Lifetime Or ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL

                            'Dim nDevNoOfM6000_R As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eRedDevNoOfM6000)
                            'Dim nChNoOfM6000_R As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eRedChOfM6000)
                            'Dim nDevNoOfM6000_G As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eGreenDevNoOfM6000)
                            'Dim nChNoOfM6000_G As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eGreenChOfM6000)
                            'Dim nDevNoOfM6000_B As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eBlueDevNoOfM6000)
                            'Dim nChNoOfM6000_B As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eBlueChOfM6000)

                            'If fMain.cM6000(nDevNoOfM6000_R).ChannelStatus(nChNoOfM6000_R) = CSeqRoutineM6000.eSequenceState.eidle And
                            '    fMain.cM6000(nDevNoOfM6000_G).ChannelStatus(nChNoOfM6000_G) = CSeqRoutineM6000.eSequenceState.eidle And
                            '    fMain.cM6000(nDevNoOfM6000_B).ChannelStatus(nChNoOfM6000_B) = CSeqRoutineM6000.eSequenceState.eidle Then
                            '    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIdle
                            '    fMain.SequenceList(nCntCH).RequestTest = False

                            '    'UI 상태 초기화
                            '    fMain.frmControlUI.ControlUI.control.IsLoadedSequenceInfo(nCntCH) = False
                            '    fMain.frmControlUI.ControlUI.control.IsLoadedSavePath(nCntCH) = False

                            '    fMain.g_StateMsgHandler.messageToUserErrorCode(nCntCH, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_CH_TEST_END, "")
                            'End If

                            '  If fMain.cQueueProcessor.CheckStatusOfM6000(nCntCH, CSeqRoutineM6000.eSequenceState.eidle, fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCellInfos) = True Then

                            'IVL Sweep 실험이 진행 중이면 종료 시킨다.
                            'If fMain.SequenceList(nCntCH).RequestIVLSweep = True Then
                            fMain.g_SweepStop(nCntCH) = True
                            '    End If

                            g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIdle
                            fMain.SequenceList(nCntCH).RequestTest = False

                            'UI 상태 초기화
                            fMain.frmControlUI.ControlUI.control.IsLoadedSequenceInfo(nCntCH) = False
                            fMain.frmControlUI.ControlUI.control.IsLoadedSavePath(nCntCH) = False

                            fMain.g_StateMsgHandler.messageToUserErrorCode(nCntCH, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_CH_TEST_END, "")
                            '   End If

                        Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                            Dim nGroupOfSG As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eGroupOfSG)
                            Dim nChNoOfSGGroup As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eChOfSG)
                            If fMain.cMcSG(nGroupOfSG).ChannelStatus(nChNoOfSGGroup) = CSeqRoutineSG.eSequenceState.eidle Then   'Errorr nGroup
                                g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIdle
                                fMain.SequenceList(nCntCH).RequestTest = False

                                'UI 상태 초기화
                                fMain.frmControlUI.ControlUI.control.IsLoadedSequenceInfo(nCntCH) = False
                                fMain.frmControlUI.ControlUI.control.IsLoadedSavePath(nCntCH) = False

                                fMain.g_StateMsgHandler.messageToUserErrorCode(nCntCH, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_CH_TEST_END, "")
                            End If

                        Case ucSequenceBuilder.eRcpMode.eModule_Lifetime

                            Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)

                            If nDevNo <> -1 Then
                                If fMain.cPG.PatternGenerator(0).ChannelStatus(nDevNo) = CDevPGCommonNode.eSequenceState.eidle Then
                                    g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIdle
                                    fMain.SequenceList(nCntCH).RequestTest = False

                                    'UI 상태 초기화
                                    fMain.frmControlUI.ControlUI.control.IsLoadedSequenceInfo(nCntCH) = False
                                    fMain.frmControlUI.ControlUI.control.IsLoadedSavePath(nCntCH) = False
                                    fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCntCH).Information = "Stop"

                                    fMain.g_StateMsgHandler.messageToUserErrorCode(nCntCH, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_CH_TEST_END, "")
                                End If
                            Else
                                g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIdle
                                fMain.SequenceList(nCntCH).RequestTest = False

                                'UI 상태 초기화
                                fMain.frmControlUI.ControlUI.control.IsLoadedSequenceInfo(nCntCH) = False
                                fMain.frmControlUI.ControlUI.control.IsLoadedSavePath(nCntCH) = False
                                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCntCH).Information = "Stop"

                                fMain.g_StateMsgHandler.messageToUserErrorCode(nCntCH, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_CH_TEST_END, "")
                            End If

                        Case Else
                            g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eIdle
                            fMain.SequenceList(nCntCH).RequestTest = False
                            fMain.g_SweepStop(nCntCH) = True
                            'UI 상태 초기화
                            ' fMain.frmControlUI.ControlUI.control.IsLoadedSequenceInfo(nCntCH) = False
                            ' fMain.frmControlUI.ControlUI.control.IsLoadedSavePath(nCntCH) = False
                            fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCntCH).Information = "Stop"

                            fMain.g_StateMsgHandler.messageToUserErrorCode(nCntCH, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_CH_TEST_END, "")


                            ' ''If g_ConfigInfos.CIMConfig.bCIMUsed = True Then
                            ' ''    Dim combinedCh() As Integer = Nothing
                            ' ''    Dim stateCounter As Integer = 0

                            ' ''    combinedCh = ChekCombinedJIGToChannel(nCntCH)

                            ' ''    Dim strFilePath As String = DataSaveToFileServer(nCntCH, ucDispRcpIVLSweep.eMeasureItems.eIV)

                            ' ''    For i As Integer = 0 To combinedCh.Length - 1
                            ' ''        If g_ChSchedulerStatus(combinedCh(i)) <> eChSchedulerSTATE.eIdle Then
                            ' ''            stateCounter += 1
                            ' ''        End If
                            ' ''    Next


                            ' ''    '20160810_PSK
                            ' ''    If stateCounter = 0 And g_SystemInfo.bCompleted_VCR_CH(nCntCH) = True Then
                            ' ''        If g_ConfigInfos.CIMConfig.bCIMUsed = True Then
                            ' ''            If fMain.routineScenario.OnlineStat <> CMESStructure.eMCMD._OFFLINE Then

                            ' ''                Dim state As CRoutineScenario.sSTATE = Nothing
                            ' ''                Dim nIndex As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfTC)

                            ' ''                If EQUIPMENT_NAME = "R1ENI" Then
                            ' ''                    state.INDEX = CRoutineScenario.eINDEXER._IV01
                            ' ''                    state.MODULEID = EQUIPMENT_FULLNAME & "_" & fMain.routineScenario.strINDEXER(state.INDEX)
                            ' ''                ElseIf EQUIPMENT_NAME = "R1ENL" Then
                            ' ''                    state.INDEX = CRoutineScenario.eINDEXER._LT01
                            ' ''                    state.MODULEID = EQUIPMENT_FULLNAME & "_" & fMain.routineScenario.strINDEXER(state.INDEX)
                            ' ''                ElseIf EQUIPMENT_NAME = "R1ENH" Then
                            ' ''                    state.INDEX = CRoutineScenario.eINDEXER._HT01
                            ' ''                    state.MODULEID = EQUIPMENT_FULLNAME & "_" & fMain.routineScenario.strINDEXER(state.INDEX)
                            ' ''                End If

                            ' ''                state.STATE = CRoutineScenario.eSTATE._GLASS_MOVE_OUT

                            ' ''                state.nGLASSIndex = nCntCH
                            ' ''                fMain.routineScenario.requestCHANGE_STATE(state)


                            ' ''                state.STATE = CRoutineScenario.eSTATE._GLASS_DCOLL_REPORT
                            ' ''                state.MODULEID = EQUIPMENT_FULLNAME '& "_" & fMain.routineScenario.strINDEXER(state.INDEX)
                            ' ''                state.nGLASSIndex = nCntCH

                            ' ''                If g_SystemOptions.sMESOptionData.sETC.DCOL_DISK = "LOCALDISK" Then
                            ' ''                    'IVL일 경우를 찾아서 넘겨준다.
                            ' ''                    state.strFILEPATH = fMain.g_DataSaver(nCntCH).m_sSavePath_Sweep_Backup(0) '20160823_PSK 수정을 해야 한다
                            ' ''                    'm_sSavePath_Sweep_SpectrumData_Backup(idx)
                            ' ''                    ' state.strFILEPATH = fMain.SequenceList(nCntCH).SequenceInfo.sCommon.saveInfo.strFPath & fMain.SequenceList(nCntCH).SequenceInfo.sCommon.saveInfo.strOnlyFName
                            ' ''                ElseIf g_SystemOptions.sMESOptionData.sETC.DCOL_DISK = "FILESERVER" Then
                            ' ''                    state.strFILEPATH = strFilePath
                            ' ''                End If



                            ' ''                fMain.routineScenario.requestCHANGE_STATE(state)
                            ' ''            End If

                            ' ''        End If
                            ' ''    End If
                            ' ''End If

                    End Select




                Case eChSchedulerSTATE.eModule_PatternMeasure

                    If fMain.SequenceList(nCntCH).RequestTest = False Then  'Source Output 설정이 완료되기 전에 다음 스텝으로 넘어 가는 것을 방지 하기 위해서, 완료되기 전에 연속으로 설정되는 것도 방지
                        fMain.SequenceList(nCntCH).RequestTest = True
                        Dim process As CSeqProcessor.sProcessParams = Nothing
                        process.cmd = CSeqProcessor.eProcessState.ModulePatternMeasure
                        process.index = nCntCH
                        process.CommonInfo = fMain.SequenceList(nCntCH).SequenceInfo.sCommon
                        process.sSampleInfos = fMain.SequenceList(nCntCH).SequenceInfo.sSampleInfos
                        process.recipe = fMain.SequenceList(nCntCH).Current
                        fMain.requestMeas(process)
                        'fMain.m6000Controller(g_ChAllocationInfos(nCntCH).nDevNoOfM6000).ChannelStatus(g_ChAllocationInfos(nCntCH).nChOfM6000) = CSeqRoutineM6000.eSequenceState.eMeasuring
                    End If
                    '=================================================================================

                Case eChSchedulerSTATE.eIVLSweep

                    If fMain.SequenceList(nCntCH).RequestTest = False Then  'Source Output 설정이 완료되기 전에 다음 스텝으로 넘어 가는 것을 방지 하기 위해서, 완료되기 전에 연속으로 설정되는 것도 방지
                        fMain.SequenceList(nCntCH).RequestTest = True
                        Dim process As CSeqProcessor.sProcessParams
                        process.cmd = CSeqProcessor.eProcessState.IVLSweep
                        process.index = nCntCH
                        process.CommonInfo = fMain.SequenceList(nCntCH).SequenceInfo.sCommon
                        process.sSampleInfos = fMain.SequenceList(nCntCH).SequenceInfo.sSampleInfos
                        process.beforStateModeTime = ModeTime(nCntCH) '이전 상태에서의 누적 시간
                        process.recipe = fMain.SequenceList(nCntCH).Current
                        g_SYSTIMEInfo(nCntCH).ModeStartTime = Date.Parse(strCurrTime)
                        process.requestTime = g_SYSTIMEInfo(nCntCH).ModeStartTime
                        fMain.requestMeas(process)
                        bReadyToMeas = False
                        'fMain.m6000Controller(g_ChAllocationInfos(nCntCH).nDevNoOfM6000).ChannelStatus(g_ChAllocationInfos(nCntCH).nChOfM6000) = CSeqRoutineM6000.eSequenceState.eMeasuring
                    Else
                        ModeTime(nCntCH) = Now.Subtract(g_SYSTIMEInfo(nCntCH).ModeStartTime)
                    End If

                Case eChSchedulerSTATE.eViewingAngle

                    If fMain.SequenceList(nCntCH).RequestTest = False Then
                        fMain.SequenceList(nCntCH).RequestTest = True
                        Dim process As CSeqProcessor.sProcessParams
                        process.cmd = CSeqProcessor.eProcessState.ViewingAngle
                        process.index = nCntCH
                        process.CommonInfo = fMain.SequenceList(nCntCH).SequenceInfo.sCommon
                        process.sSampleInfos = fMain.SequenceList(nCntCH).SequenceInfo.sSampleInfos
                        process.beforStateModeTime = ModeTime(nCntCH) '이전 상태에서의 누적 시간
                        process.recipe = fMain.SequenceList(nCntCH).Current
                        g_SYSTIMEInfo(nCntCH).ModeStartTime = Date.Parse(strCurrTime)
                        process.requestTime = g_SYSTIMEInfo(nCntCH).ModeStartTime
                        fMain.requestMeas(process)
                    End If

            End Select

            ''Update Display------------------------------------------------------------
            fMain.frmControlUI.ControlUI.control.Status(nCntCH) = g_ChSchedulerStatus(nCntCH)
            fMain.frmMonitorUI.Status(nCntCH) = g_ChSchedulerStatus(nCntCH) 'Monitor UI

            '   fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCntCH).CellColor_ON = Color.White
            '   fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCntCH).CellStatus = ucDispSampleCommonNode.eCellState.eON


            If g_ChSchedulerStatus(nCntCH) <> eChSchedulerSTATE.eIdle And g_ChSchedulerStatus(nCntCH) <> eChSchedulerSTATE.eRun Then

                If fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_Lifetime Or fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then

                    ' fMain.g_MeasuredDatas(nCntCH).sCellLTParams.RealTimeData = fMain.cQueueProcessor.UpdateRealTimeData(nCntCH)

                    Dim dispData(fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd.Length - 1) As String

                    For i As Integer = 0 To fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd.Length - 1
                        Dim endCondition As ucTestEndParam.sTestEndParam = fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd(i)
                        If endCondition.nTypeOfParam = ucTestEndParam.eTestEndParam.eTime Then
                            dispData(ucTestEndParam.eTestEndParam.eTime) = "[" & CTime.Convert_HourToHMS(CTime.Convert_SecToTimeValue(fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd(i).dValue).dHour) & "]"

                            If dispData.Length = 1 Then
                                If fMain.g_MeasuredDatas(nCntCH).bIsSavedRefPDCurrent = True And fMain.SequenceList(nCntCH).RequestIVLSweep = False Then
                                    If fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then
                                        If fMain.SequenceList(nCntCH).IVLSweepMeasCount < fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sIVLSweepMeas.Length Then
                                            dispData(ucTestEndParam.eTestEndParam.eTime) = dispData(ucTestEndParam.eTestEndParam.eTime) & vbLf & Format(fMain.g_MeasuredDatas(nCntCH).sCellLTParams.LTData(0).opticalData.dLumi_Percent, "0.0") & "%" & vbLf & _
                                                                                        "***" & fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sIVLSweepMeas(fMain.SequenceList(nCntCH).IVLSweepMeasCount).dValue & "%***"
                                        End If
                                    Else
                                        dispData(ucTestEndParam.eTestEndParam.eTime) = dispData(ucTestEndParam.eTestEndParam.eTime) & vbLf & Format(fMain.g_MeasuredDatas(nCntCH).sCellLTParams.LTData(0).opticalData.dLumi_Percent, "0.0") & "%"
                                    End If
                                End If
                            End If
                        ElseIf endCondition.nTypeOfParam = ucTestEndParam.eTestEndParam.eLumi Then
                            If fMain.g_MeasuredDatas(nCntCH).bIsSavedRefPDCurrent = True And fMain.SequenceList(nCntCH).RequestIVLSweep = False Then
                                If fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then
                                    If fMain.SequenceList(nCntCH).IVLSweepMeasCount < fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sIVLSweepMeas.Length Then
                                        dispData(dispData.Length - 1) = Format(fMain.g_MeasuredDatas(nCntCH).sCellLTParams.LTData(0).opticalData.dLumi_Percent, "0.0") & "%" & vbLf & _
                                                                  "[" & fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd(i).dValue & "%]" & vbLf & _
                                                                   "***" & fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sIVLSweepMeas(fMain.SequenceList(nCntCH).IVLSweepMeasCount).dValue & "%***"
                                    End If
                                Else
                                    dispData(dispData.Length - 1) = Format(fMain.g_MeasuredDatas(nCntCH).sCellLTParams.LTData(0).opticalData.dLumi_Percent, "0.0") & "%" & " / " & _
                                                                  "[" & fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd(i).dValue & "%]"
                                End If
                            Else
                                dispData(dispData.Length - 1) = ""
                            End If
                        End If
                    Next

                    fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCntCH).sample.Datas = dispData

                ElseIf fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then
                    'Dim dispData(fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd.Length - 1) As String

                    'For i As Integer = 0 To fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd.Length - 1
                    '    Dim endCondition As ucTestEndParam.sTestEndParam = fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd(i)
                    '    If endCondition.nTypeOfParam = ucTestEndParam.eTestEndParam.eTime Then
                    '        dispData(ucTestEndParam.eTestEndParam.eTime) = "[" & CTime.Convert_HourToHMS(CTime.Convert_SecToTimeValue(fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd(i).dValue).dHour) & "]"

                    '        If dispData.Length = 1 Then
                    '            If fMain.g_MeasuredDatas(nCntCH).bIsSavedRefPDCurrent = True And fMain.SequenceList(nCntCH).RequestIVLSweep = False Then
                    '                dispData(ucTestEndParam.eTestEndParam.eTime) = dispData(ucTestEndParam.eTestEndParam.eTime) & vbLf & Format(fMain.g_MeasuredDatas(nCntCH).sCellLTParams.LTData.opticalData.dLumi_Percent, "0.0") & "%"
                    '            End If
                    '        End If
                    '    ElseIf endCondition.nTypeOfParam = ucTestEndParam.eTestEndParam.eLumi Then
                    '        If fMain.g_MeasuredDatas(nCntCH).bIsSavedRefPDCurrent = True And fMain.SequenceList(nCntCH).RequestIVLSweep = False Then

                    '            '    Format(fMain.g_MeasuredDatas(nCntCH).sCellLTParams.LTData.opticalData.dRefLumi_Percent, "0.0") & "%±"
                    '            'fMain.g_MeasuredDatas(nCntCH).sCellLTParams.LTData.opticalData.dRefLumi_Percent + fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd(i).dValue
                    '            ' fMain.g_MeasuredDatas(nCntCH).sCellLTParams.LTData.opticalData.dRefLumi_Percent - fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd(i).dValue
                    '        Else
                    '            dispData(dispData.Length - 1) = ""
                    '        End If

                    '    End If
                    'Next

                    'fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCntCH).sample.Datas = dispData

                ElseIf fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.ePanel_Lifetime Then
                    Dim MeasValOfSG As CSeqRoutineSG.sMeasuredData
                    Dim nGroupOfSg As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eGroupOfSG)
                    Dim nDevNoOfSg As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfSG)
                    Dim nChNoOfSg As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eChOfSG)

                    MeasValOfSG = fMain.cMcSG(nGroupOfSg).MeasuredData(nChNoOfSg)

                    With fMain.g_MeasuredDatas(nCntCH).sPanelLTParams.sMeasuredValues
                        .dELVDD_V = MeasValOfSG.dELVDD_V
                        .dELVSS_V = MeasValOfSG.dELVSS_V
                        .dELVDD_I = MeasValOfSG.dELVDD_I
                        .dELVSS_I = MeasValOfSG.dELVSS_I
                        .dELVDD_Temp = MeasValOfSG.dELVDD_Temp
                        .dELVSS_Temp = MeasValOfSG.dELVSS_Temp
                        .dTOTAL_I = MeasValOfSG.dTOTAL_I
                        .dPD_I = MeasValOfSG.dPD_I
                        ' .dLuminance = MeasValOfSG.dLuminance
                    End With

                ElseIf fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eModule_Lifetime Then
                    Dim MeasValOfPG As CDevPGCommonNode.sMeasuredDatas ' CSeqRoutineMcPG.sMeasuredData
                    Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)

                    If nDevNo <> -1 Then
                        MeasValOfPG = fMain.cPG.PatternGenerator(0).MeasuredData(nDevNo)

                        Dim dispData(0) As String

                        dispData(0) = "IBAT(mA) = " & Format(MeasValOfPG.sG4S.IBAT_mA, "0.00")
                        fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCntCH).sample.Datas = dispData
                    End If
                End If

                'For idx As Integer = 0 To fMain.SequenceList(nCntCH).SequenceInfo.sRecipes.Length - 1
                '    For jdx As Integer = 0 To fMain.SequenceList(nCntCH).SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sLifetimeEnd.Length - 1
                '        If fMain.SequenceList(nCntCH).SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sLifetimeEnd(jdx).nTypeOfParam = ucTestEndParam.eTestEndParam.eTime Then
                '            Dim sTime() As Long

                '            sTime = CTime.Convert_SecToHMS(fMain.SequenceList(nCntCH).SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sLifetimeEnd(fMain.SequenceList(nCntCH).SequenceInfo.numOfRcpSteps).dValue)

                '            fMain.frmControlUI.ControlUI.control.ModeTime_SetValue(nCntCH) = sTime

                '        End If
                '    Next

                'Next

                'Check End Conditions
                '==================================================================================================
                Dim sMsg_StopReason As String = ""
                If g_ChSchedulerStatus(nCntCH) <> eChSchedulerSTATE.eIVLSweep And g_ChSchedulerStatus(nCntCH) <> eChSchedulerSTATE.eViewingAngle Then
                    If IsCheckedEndConditions(nCntCH, fMain.SequenceList(nCntCH).SequenceInfo.sCommon.sSequenceEnd, sMsg_StopReason) = True Then
                        fMain.frmControlUI.ControlUI.control.StopReason(nCntCH) = sMsg_StopReason
                        g_ChSchedulerStatus(nCntCH) = eChSchedulerSTATE.eStop
                    End If
                End If
                '=============================================================================================================================================
                'End If

                fMain.frmControlUI.ControlUI.control.TotalTime_Current(nCntCH) = TotalTestTime(nCntCH)
                fMain.frmControlUI.ControlUI.control.ModeTime_Current(nCntCH) = ModeTime(nCntCH)

                fMain.frmMonitorUI.TargetSample(nCntCH) = fMain.SequenceList(nCntCH).SequenceInfo.sSampleInfos.sampleType

                fMain.frmMonitorUI.CurrentRcpIndex(nCntCH) = fMain.SequenceList(nCntCH).CurrentRecipeIndex + 1
                fMain.frmControlUI.ControlUI.control.CurrentRcpIndex(nCntCH) = fMain.SequenceList(nCntCH).CurrentRecipeIndex + 1

                fMain.frmMonitorUI.numOfRcp(nCntCH) = fMain.SequenceList(nCntCH).SequenceInfo.sRecipes.Length
                fMain.frmControlUI.ControlUI.control.NumOfRcp(nCntCH) = fMain.SequenceList(nCntCH).SequenceInfo.sRecipes.Length

                fMain.frmMonitorUI.Cycle(nCntCH) = fMain.SequenceList(nCntCH).LoopCount
                fMain.frmControlUI.ControlUI.control.Cycle(nCntCH) = fMain.SequenceList(nCntCH).LoopCount

                fMain.frmMonitorUI.TotalTime_Current(nCntCH) = CTime.Convert_HoureToTimeValue(TotalTestTime(nCntCH).TotalHours) 'fMain.g_MeasuredDatas(nCntCH).lifeTime

                If fMain.SequenceList(nCntCH).SequenceInfo.sCommon.sSequenceEnd Is Nothing = False Then
                    For i As Integer = 0 To fMain.SequenceList(nCntCH).SequenceInfo.sCommon.sSequenceEnd.Length - 1
                        Dim endCondition As ucTestEndParam.sTestEndParam = fMain.SequenceList(nCntCH).SequenceInfo.sCommon.sSequenceEnd(i)
                        If endCondition.nTypeOfParam = ucTestEndParam.eTestEndParam.eTime Then
                            fMain.frmMonitorUI.TotalTime_SetValue(nCntCH) = CTime.Convert_SecToTimeValue(fMain.SequenceList(nCntCH).SequenceInfo.sCommon.sSequenceEnd(i).dValue) 'LEX
                            fMain.frmControlUI.ControlUI.control.TotalTime_setValue(nCntCH) = CTime.Convert_SecToTimeValue(fMain.SequenceList(nCntCH).SequenceInfo.sCommon.sSequenceEnd(i).dValue)
                        End If
                    Next
                End If
                fMain.frmMonitorUI.ModeTime_Current(nCntCH) = CTime.Convert_HoureToTimeValue(ModeTime(nCntCH).TotalHours) 'fMain.g_MeasuredDatas(nCntCH).modeTime.TotalHours)

                If fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_Lifetime Or
                   fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.ePanel_Lifetime Or
                   fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eModule_Lifetime Or
                   fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then

                    If fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd Is Nothing = False Then
                        For i As Integer = 0 To fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd.Length - 1
                            Dim endCondition As ucTestEndParam.sTestEndParam = fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd(i)
                            If endCondition.nTypeOfParam = ucTestEndParam.eTestEndParam.eTime Then
                                fMain.frmMonitorUI.ModeTime_SetValue(nCntCH) = CTime.Convert_SecToTimeValue(fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd(i).dValue) 'LEX
                                fMain.frmControlUI.ControlUI.control.ModeTime_SetValue(nCntCH) = CTime.Convert_SecToTimeValue(fMain.SequenceList(nCntCH).Current.sLifetimeInfo.sCommon.sLifetimeEnd(i).dValue)

                            ElseIf endCondition.nTypeOfParam = ucTestEndParam.eTestEndParam.eLumi_Delta Then
                                '        fMain.frmControlUI.ControlUI.control.ModeTime_SetValue(nCntCH) = CTime.Convert_SecToTimeValue(0)
                            End If
                        Next

                    End If

                ElseIf fMain.SequenceList(nCntCH).Current.nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then
                    fMain.frmMonitorUI.ModeTime_SetValue(nCntCH) = CTime.Convert_SecToTimeValue(fMain.SequenceList(nCntCH).Current.sChangeTemp.StableTime.nSecound)
                    fMain.frmControlUI.ControlUI.control.ModeTime_SetValue(nCntCH) = CTime.Convert_SecToTimeValue(fMain.SequenceList(nCntCH).Current.sChangeTemp.StableTime.nSecound)
                End If


                'ModeTime = Now.Subtract(g_SYSTIMEInfo(nCntCH).ModeStartTime)
                'TotalTestTime = Now.Subtract(g_SYSTIMEInfo(nCntCH).TestStartTime)
                'Dim TotalTimeBuff() As Long
                'Dim ModetimeBuff() As Long
                'TotalTimeBuff = CTime.Convert_SecToHMS(TotalTestTime.TotalSeconds)
                'ModetimeBuff = CTime.Convert_SecToHMS(ModeTime.TotalSeconds)
                'For i As Integer = 0 To fMain.frmControl.Length - 1
                '    If nCntCH >= fMain.frmControl(i).SeedIndex And nCntCH < fMain.frmControl(i).SeedIndex + fMain.frmControl(i).numberOfChannel Then
                '        fMain.frmControl(i).target(nCntCH).UcIndicator1.TotalTime(Format(TotalTimeBuff(0), "00") & ":" & Format(TotalTimeBuff(1), "00") & ":" & Format(TotalTimeBuff(2), "00"))
                '        fMain.frmControl(i).target(nCntCH).UcIndicator1.ModeTime(Format(ModetimeBuff(0), "00") & ":" & Format(ModetimeBuff(1), "00") & ":" & Format(ModetimeBuff(2), "00"))
                '    End If
                'Next

                'fMain.frmControlTwoStpeCyle.target(nCntCH).UcIndicator1.TotalTime(Format(TotalTimeBuff(0), "00") & ":" & Format(TotalTimeBuff(1), "00") & ":" & Format(TotalTimeBuff(2), "00"))
                'fMain.frmControlTwoStpeCyle.target(nCntCH).UcIndicator1.ModeTime(Format(ModetimeBuff(0), "00") & ":" & Format(ModetimeBuff(1), "00") & ":" & Format(ModetimeBuff(2), "00"))

            End If


            If g_ConfigInfos.TCConfig Is Nothing = False Then

                If fMain.cTC Is Nothing = False Then

                    Dim nGroupOfTC As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eGroupOfTC)
                    Dim nDevOfTCGroup As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eDevNoOfTC)
                    Dim nChOfTCDev As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eChOfTC)
                    Dim dTemp As Double

                    If nGroupOfTC >= 0 And nDevOfTCGroup >= 0 And nChOfTCDev >= 0 Then
                        dTemp = fMain.cTC(nGroupOfTC).MeasuredData(nDevOfTCGroup, nChOfTCDev).measTemp

                        fMain.frmControlUI.ControlUI.control.Temperature(nCntCH) = dTemp
                        fMain.g_MeasuredDatas(nCntCH).dTemp = dTemp

                        If fMain.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
                            Dim JigNo As Integer = frmSettingWind.GetAllocationValue(nCntCH, frmSettingWind.eChAllocationItem.eJIG_No)
                            fMain.frmControlUI.ControlUI.control.dispJIG(JigNo).Temp = dTemp
                        End If
                    End If


                End If

            End If

            'fMain.frmMonitorUI.UpdateDataIndicate(nCntCH)
            'fMain.frmMonitorUI.UpdateCommonIndicate(nCntCH)


            '-------------------------------------------------------------------------------------------------------------------------------------------------------

            nCntCH += 1

            If nCntCH >= g_nMaxCh Then

                '  If g_SystemInfo.bCanUpdateStateInfoOfCh(nCntCH) = True Then  '스레드가 시작 될때 초기 상태를 무조건 갱신하는 것을 방지, 사용자가 명령을 내렸거나, 이어붙이기가 시작된 다음부터 정보를 갱신
                SaveStateOfChannel()
                'End If

                If fMain.g_EmergencyCtrl.getState = CV7000Emergency.eEMSTATe.eIDEL Then
                    If fMain.g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.eNotUse Then
                        'If nCntidleCh >= g_nMaxCh Then
                        If fMain.cPLC Is Nothing = False Then
                            ' Dim PLCStatusInIDEL As Boolean = False
                            Dim Test As Boolean = False
                            'If fMain.cPLC.Datas.nSystemStatus Is Nothing = False Then
                            '    For i As Integer = 0 To fMain.cPLC.Datas.nSystemStatus.Length - 1
                            '        If fMain.cPLC.Datas.nSystemStatus(i) = CDevPLCCommonNode.eSystemStatus.eIDEL Then
                            '            PLCStatusInIDEL = True

                            '        End If
                            '    Next
                            'End If
                            'If PLCStatusInIDEL = False Then
                            'Dim info As CDevPLCCommonNode.sRequestInfo


                            'info.nCMD = CDevPLCCommonNode.eRequestCMD.eSetStatus
                            'info.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eIDEL
                            'fMain.cPLC.Request(info)
                            'Application.DoEvents()
                            'Thread.Sleep(1000)

                            'Application.DoEvents()
                            'Thread.Sleep(1000)

                            ''갱신 필요
                            'For i As Integer = 0 To g_nMaxCh - 1
                            '    g_ChSchedulerStatus(i) = g_ChSchedulerStatus(i)
                            'Next

                            'Application.DoEvents()
                            'Thread.Sleep(1000)

                            '스캔중에 Run신호가 들어올 수 있으므로 한번 더 읽을 필요가 있음
                            'For i As Integer = 0 To g_nMaxCh - 1
                            '    If g_ChSchedulerStatus(i) <> eChSchedulerSTATE.eIdle Then
                            '        Test = False
                            '        Exit For
                            '    Else
                            '        Test = True

                            '    End If
                            '  Next

                            Application.DoEvents()
                            Thread.Sleep(100)

                            'For i As Integer = 0 To g_nMaxCh - 1
                            '    If g_ChSchedulerStatus(i) <> eChSchedulerSTATE.eIdle Then
                            '        Test = False
                            '        Exit For
                            '    Else
                            '        Test = True
                            '    End If
                            'Next

                            ' false일떄 자동분기로 한번 더 읽음 테스트 중..
                            'If fMain.cPLCScheduler.StartChk = True Then
                            '    fMain.cPLCScheduler.StartChk = False
                            '    GoTo test1
                            'End If

                            'If fMain.cPLC Is Nothing = False Then
                            '    If fMain.cPLCScheduler.ExhausStart = True And fMain.meas_queue.Count = 0 And fMain.cPLCScheduler.RequestTest = True And Test = True Then

                            '        fMain.cPLCScheduler.g_ChSchedulerPLCStatus = CSheduler_PLC.eChSchedulerPLCSTATE.eExhaus
                            '        fMain.cPLCScheduler.ExhausStart = False
                            '        fMain.cPLCScheduler.RequestTest = False
                            '        '  fMain.EnableTsBtnTestStart(True)
                            '    End If

                            'End If

                        End If

                        'Else
                        '    fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_READY)
                        'End If
                    Else

                        If fMain.cPLC Is Nothing = False Then  'PLC 가 있을경우는 시스템 상태를 PLC를 통해서

                            ''Dim PLCStatusInProcess As Boolean = False
                            ''For i As Integer = 0 To fMain.cPLC.Datas.nSystemStatus.Length - 1
                            ''    If fMain.cPLC.Datas.nSystemStatus(i) = CDevPLCCommonNode.eSystemStatus.eProcessing Then
                            ''        PLCStatusInProcess = True
                            ''    End If
                            ''Next

                            ''If PLCStatusInProcess = False Then

                            ''    Dim info As CDevPLCCommonNode.sRequestInfo

                            ''    info.nCMD = CDevPLCCommonNode.eRequestCMD.eSetStatus
                            ''    info.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eProcessing
                            ''    fMain.cPLC.Request(info)
                            ''    Application.DoEvents()
                            ''    Thread.Sleep(1000)
                            ''End If

                        Else
                            ' fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_RUNNING)
                        End If

                    End If
                End If
                'test1:
                nCntidleCh = 0
                nCntCH = 0
            End If

            '    bMeasurementEndHomeMoved = False
            'End If

            ' End If

        Loop

        fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_THREAD_STOP, "Scheduler Stop")

    End Sub


    '같은 지그에 위치한 채널(즉, 동일한 온도 설정이 적용되는 채널)의 번호를 배열로 정렬하여 리턴 한다.
    Public Function ChekCombinedChannel(ByVal nCh As Integer) As Integer()
        Dim combinedChIndex() As Integer = Nothing
        Dim cnt As Integer = 0
        Dim myGroupOfTC As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eGroupOfTC)
        Dim myDevOfTC As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfTC)
        Dim myChOfTC As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfTC) ' g_ChAllocationInfos(nCh).nJIG_No

        For i As Integer = 0 To g_nMaxCh - 1
            If frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eGroupOfTC) = myGroupOfTC And
                frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eDevNoOfTC) = myDevOfTC And
               frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eChOfTC) = myChOfTC Then
                ReDim Preserve combinedChIndex(cnt)
                combinedChIndex(cnt) = i
                cnt += 1
            End If
        Next
        Return combinedChIndex
    End Function


    Public Function ChekCombinedJIGToChannel(ByVal nCh As Integer) As Integer()
        Dim combinedChIndex() As Integer = Nothing
        Dim cnt As Integer = 0
        Dim myJIGNumner As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eJIG_No)

        For i As Integer = 0 To g_nMaxCh - 1
            If frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eJIG_No) = myJIGNumner Then
                ReDim Preserve combinedChIndex(cnt)
                combinedChIndex(cnt) = i
                cnt += 1
            End If
        Next
        Return combinedChIndex
    End Function
    Public Function CheckedSampleContact(ByVal nCh As Integer, Optional ByVal sourceInfo As CSMULib.ucKeithleySMUSettings.sKeithley = Nothing) As Boolean

        Dim nDevNoOfKeithley As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
        Dim nChNoOfKeithley As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSMU_IVL)
        Dim nDevSwitch As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
        Dim nChOfSwitch As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSwitch)

        'Dim dMargin As Double = g_SystemOptions.sOptionData.sCheckContact.dPassLevel * (g_SystemOptions.sOptionData.sCheckContact.dBiasMargin / 100)
        Dim IVL_V As Double = 0
        Dim IVL_I As Double = 0
        Dim nCnt As Integer = 0

        fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellColor_ON = Color.White
        fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellStatus = ucDispSampleCommonNode.eCellState.eON


        If fMain.cSwitch(nDevSwitch).mySwitch.SwitchON(nChOfSwitch) = True Then
            If fMain.cIVLSMU(nDevNoOfKeithley).mySMU.OutputOn() = False Then
                Return False
            End If

            If fMain.cIVLSMU(nDevNoOfKeithley).mySMU.SetBias(g_SystemOptions.sOptionData.sCheckContact.dContactBias) = False Then
                Return False
            End If
        Else
            Return False
        End If


        Do
            If fMain.cIVLSMU(nDevNoOfKeithley).mySMU.Measure(IVL_V, IVL_I) = True Then
                Application.DoEvents()
                Thread.Sleep(50)

                nCnt += 1
            End If

            Dim HighLv As Double = 0 'g_SystemOptions.sOptionData.sCheckContact.dMaxPassLevel
            Dim LowLv As Double = 0 'g_SystemOptions.sOptionData.sCheckContact.dMinPassLevel
            Dim Current As Double = IVL_I * 1000    'mA Unit

            If Current < HighLv And
                 Current > LowLv Then
                If fMain.cIVLSMU(nDevNoOfKeithley).mySMU.OutputOff = True Then
                    fMain.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch)
                    Return True
                End If
            End If

            If nCnt > 2 Then
                If Current < HighLv And
                 Current > LowLv Then
                    If fMain.cIVLSMU(nDevNoOfKeithley).mySMU.OutputOff = True Then
                        fMain.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch)
                        Return True
                    End If
                Else

                    If fMain.cIVLSMU(nDevNoOfKeithley).mySMU.OutputOff = True Then
                        fMain.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch)
                        Return False
                    End If

                End If
            End If
        Loop


        Return True
    End Function

    Private Sub ChekLifetimeMeasInterval(ByVal in_Ch As Integer, ByVal totalTestTime As Long, ByVal modeTime_sec As Long)
        Try
            If fMain.SequenceList(in_Ch) Is Nothing = False Then

                If modeTime_sec >= fMain.SequenceList(in_Ch).ChangeInterval.nSecound Then  'Interval Change '>= 되어 있어Mode 타임이 체인지 타임이상이면 계속 인터벌
                    fMain.SequenceList(in_Ch).ChangeMeasInterval()
                End If

                '기준 Luminance PD 값 선정 부분
                If fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = False Then

                    'Once 모드 : 안정화 시간 적용을 최초 Lifetime Recipe 에서 한번 만 적용
                    'ChangeRecipe : 안정화 시간 적용을 Lifetime Recipe가 전환 될때 마다 적용
                    If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.Once Or
                        fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.ChangeRecipe Then


                        Select Case fMain.SequenceList(in_Ch).Current.sLifetimeInfo.nMyMode

                            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                                If modeTime_sec >= fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sSetInfosTheRefPD.RenewalTime.nSecound Then
                                    fMain.g_MeasuredDatas(in_Ch).bRequestedMeasRefValue = True

                                End If
                            Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                                If modeTime_sec >= fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sSetInfosTheRefPD.RenewalTime.nSecound Then
                                    If fMain.g_MeasuredDatas(in_Ch).sPanelLTParams.sMeasuredValues.dPD_I <> 0 Then
                                        fMain.g_MeasuredDatas(in_Ch).dRefLuminance = fMain.g_MeasuredDatas(in_Ch).dLuminance
                                        fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = True
                                    End If
                                End If
                            Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                                If modeTime_sec >= fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sSetInfosTheRefPD.RenewalTime.nSecound Then
                                    fMain.g_MeasuredDatas(in_Ch).bRequestedMeasRefValue = True
                                    'If fMain.g_MeasuredDatas(in_Ch).sModuleLTParams.sColorAnalyzer(0).sCA310(0).Lv <> 0 Then
                                    '    fMain.g_MeasuredDatas(in_Ch).dRefLuminance = fMain.g_MeasuredDatas(in_Ch).dLuminance
                                    '    fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = True
                                    'End If
                                End If
                        End Select


                    Else  'If fMain.SequenceList(in_Ch).Current.LifeTimeModeParams.sLuminanceSettings.bEnableRenewalMode = ucRefPDSetting.eRefPDMode.OFF Then
                        'OFF : 안정화 시간을 적용하지 않고 최초 Lifetime Recipe에서 한번만 적용

                        Select Case fMain.SequenceList(in_Ch).Current.sLifetimeInfo.nMyMode

                            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                                fMain.g_MeasuredDatas(in_Ch).bRequestedMeasRefValue = True

                            Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                                If fMain.g_MeasuredDatas(in_Ch).sPanelLTParams.sMeasuredValues.dPD_I <> 0 Then
                                    fMain.g_MeasuredDatas(in_Ch).dRefLuminance = fMain.g_MeasuredDatas(in_Ch).dLuminance
                                    fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = True
                                End If
                            Case ucSequenceBuilder.eRcpMode.eModule_Lifetime

                                fMain.g_MeasuredDatas(in_Ch).bRequestedMeasRefValue = True
                                'If fMain.g_MeasuredDatas(in_Ch).sModuleLTParams.sColorAnalyzer Is Nothing = False Then
                                '    If fMain.g_MeasuredDatas(in_Ch).sModuleLTParams.sColorAnalyzer(0).sCA310(0).Lv <> 0 Then
                                '        fMain.g_MeasuredDatas(in_Ch).dRefLuminance = fMain.g_MeasuredDatas(in_Ch).dLuminance
                                '        fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = True
                                '    End If
                                'End If
                        End Select

                    End If

                End If

                If modeTime_sec >= fMain.SequenceList(in_Ch).NextMeasureTime.nSecound Then
                    If fMain.g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.eNotUse Then
                        Dim process As CSeqProcessor.sProcessParams = Nothing
                        process.bLastPointSave = False
                        process.cmd = CSeqProcessor.eProcessState.LifeTimeMeas
                        process.index = in_Ch
                        process.CommonInfo = fMain.SequenceList(in_Ch).SequenceInfo.sCommon
                        process.sSampleInfos = fMain.SequenceList(in_Ch).SequenceInfo.sSampleInfos
                        process.recipe = fMain.SequenceList(in_Ch).Current

                        '마지막 포인트 측정 할 때 Spec 저장을 위해서
                        With fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon
                            For i As Integer = 0 To .sLifetimeEnd.Length - 1
                                If .sLifetimeEnd(i).dValue <> 0 Then
                                    Select Case .sLifetimeEnd(i).nTypeOfParam
                                        Case M7000.ucTestEndParam.eTestEndParam.eTime
                                            If modeTime_sec >= .sLifetimeEnd(i).dValue Then
                                                process.bLastPointSave = True
                                            End If
                                    End Select
                                End If
                            Next
                        End With

                        fMain.requestMeas(process)   '데이터 측정 요청
                    End If

                    fMain.SequenceList(in_Ch).AccumulateMeasTime() '다음 측정 시간 누적
                End If

                '실험 종료 조건 비교(측정 종료 조건 만족 하는 다음 측정 조건으로 넘어감)  --> IsCheckedEndConditions 로 대체 가능한지 확인 필요
                If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sLifetimeEnd Is Nothing = False Then '.LifeTimeModeParams.sTestEndParams
                    Dim ucTestEndParam() As ucTestEndParam.sTestEndParam = fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sLifetimeEnd

                    Dim MeasValOfM6000 As CDevM6000PLUS.sMeasParams = Nothing
                    Dim MeasValOfSG As CSeqRoutineSG.sMeasuredData = Nothing
                    Dim MeasValOfPG As CDevPGCommonNode.sMeasuredDatas = Nothing 'CSeqRoutineMcPG.sMeasuredData = Nothing
                    Dim dLumi_Percent As Double
                    Dim bCheckTestEnd As Boolean

                    Select Case fMain.SequenceList(in_Ch).Current.sLifetimeInfo.nMyMode

                        Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL

                            If fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = True Then
                                bCheckTestEnd = True
                                dLumi_Percent = fMain.g_MeasuredDatas(in_Ch).sCellLTParams.LTData(0).opticalData.dLumi_Percent
                            Else
                                bCheckTestEnd = False
                            End If

                        Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime, ucSequenceBuilder.eRcpMode.eModule_Lifetime

                            If fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = True Then
                                bCheckTestEnd = True
                            Else
                                bCheckTestEnd = False
                            End If

                            'Case ucSequenceBuilder.eRcpMode.eModule_Lifetime

                            '    If fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = True Then
                            '        bCheckTestEnd = True
                            '    Else
                            '        bCheckTestEnd = False
                            '    End If

                    End Select


                    For i As Integer = 0 To ucTestEndParam.Length - 1
                        If ucTestEndParam(i).dValue <> 0 Then '종료값이 0 이 아닐때
                            Select Case ucTestEndParam(i).nTypeOfParam
                                Case M7000.ucTestEndParam.eTestEndParam.eTime
                                    If modeTime_sec >= ucTestEndParam(i).dValue Then

                                        'If fMain.SequenceList(in_Ch).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then
                                        '    Dim process As CSeqProcessor.sProcessParams = Nothing
                                        '    process.bLastPointSave = False
                                        '    process.cmd = CSeqProcessor.eProcessState.LifeTimeMeas
                                        '    process.index = in_Ch
                                        '    process.CommonInfo = fMain.SequenceList(in_Ch).SequenceInfo.sCommon
                                        '    process.sSampleInfos = fMain.SequenceList(in_Ch).SequenceInfo.sSampleInfos
                                        '    process.recipe = fMain.SequenceList(in_Ch).Current

                                        '    '마지막 포인트 측정 할 때 Spec 저장을 위해서
                                        '    With fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon
                                        '        For nCnt As Integer = 0 To .sLifetimeEnd.Length - 1
                                        '            If .sLifetimeEnd(nCnt).dValue <> 0 Then
                                        '                Select Case .sLifetimeEnd(nCnt).nTypeOfParam
                                        '                    Case M7000.ucTestEndParam.eTestEndParam.eTime
                                        '                        If modeTime_sec >= .sLifetimeEnd(nCnt).dValue Then
                                        '                            process.bLastPointSave = True
                                        '                        End If
                                        '                End Select
                                        '            End If
                                        '        Next
                                        '    End With

                                        '    fMain.requestMeas(process)   '데이터 측정 요청
                                        '    fMain.SequenceList(in_Ch).AccumulateMeasTime() '다음 측정 시간 누적
                                        '    fMain.SequenceList(in_Ch).RequestLifetimeAndIVL = True
                                        ' Else
                                        If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = False Then  'False : Source Off, True : Source ON 
                                            '소싱을 끄고 다음 단계로 이동
                                            g_ChSchedulerStatus(in_Ch) = eChSchedulerSTATE.eLifeTime_StopSourcing
                                        Else '소싱을 끄지 않고 다음 단계로 이동
                                            g_ChSchedulerStatus(in_Ch) = eChSchedulerSTATE.eChangeNextSeq
                                        End If
                                        '  End If

                                        'Luminace 산출  PD값 갱신 Flag 초기화 단, ChangeRecipe 모드 일때만
                                        If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.ChangeRecipe Then
                                            fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = False
                                        End If
                                        fMain.frmMonitorUI.Message(in_Ch) = "Stop[ModeTime]"
                                        '  fMain.frmControlTwoStpeCyle.target(in_Ch).SetIndicate_StopMessage = "Stop ModeTime" 동작마다 계속 보임으로 삭제 2013-04-19 승현
                                    End If
                                Case M7000.ucTestEndParam.eTestEndParam.eVolt
                                    'YSR_20130404
                                    If bCheckTestEnd = True Then
                                        If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation Then
                                            '동작 모드일때만 비교, 보관 모드일때는 소싱을 하지 않으므로 값이 모두 0이다, 따라서, 비교할 의미가 없다.
                                            If MeasValOfM6000.dVoltage_Bias >= ucTestEndParam(i).dValue Then

                                                If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = False Then  'False : Source Off, True : Source ON 
                                                    '소싱을 끄고 다음 단계로 이동
                                                    g_ChSchedulerStatus(in_Ch) = eChSchedulerSTATE.eLifeTime_StopSourcing
                                                Else '소싱을 끄지 않고 다음 단계로 이동
                                                    g_ChSchedulerStatus(in_Ch) = eChSchedulerSTATE.eChangeNextSeq
                                                End If
                                                'Luminace 산출  PD값 갱신 Flag 초기화 단, ChangeRecipe 모드 일때만
                                                If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.ChangeRecipe Then
                                                    fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = False
                                                End If
                                                fMain.frmMonitorUI.Message(in_Ch) = "Stop[End Voltage]"
                                                ' fMain.frmControlTwoStpeCyle.target(in_Ch).SetIndicate_StopMessage = "Stop LifeMode Volt"
                                            End If
                                        End If

                                    End If


                                Case M7000.ucTestEndParam.eTestEndParam.eCurr
                                    'Current 종료 조건 추가 2013-04-14 승현
                                    If bCheckTestEnd = True Then
                                        If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation Then

                                            '동작 모드일때만 비교, 보관 모드일때는 소싱을 하지 않으므로 값이 모두 0이다, 따라서, 비교할 의미가 없다.
                                            If MeasValOfM6000.dCurrent_Bias >= ucTestEndParam(i).dValue Then
                                                If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = False Then  'False : Source Off, True : Source ON 
                                                    '소싱을 끄고 다음 단계로 이동
                                                    g_ChSchedulerStatus(in_Ch) = eChSchedulerSTATE.eLifeTime_StopSourcing
                                                Else '소싱을 끄지 않고 다음 단계로 이동
                                                    g_ChSchedulerStatus(in_Ch) = eChSchedulerSTATE.eChangeNextSeq
                                                End If
                                                'Luminace 산출  PD값 갱신 Flag 초기화 단, ChangeRecipe 모드 일때만
                                                If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.ChangeRecipe Then
                                                    fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = False
                                                End If
                                                fMain.frmMonitorUI.Message(in_Ch) = "Stop[End Current]"
                                                'fMain.frmControlTwoStpeCyle.target(in_Ch).SetIndicate_StopMessage = "Stop LifeMode Curr"
                                            End If

                                        End If
                                    End If



                                Case M7000.ucTestEndParam.eTestEndParam.ePDCurr
                                    'Current 종료 조건 추가 2013-04-14 승현
                                    If bCheckTestEnd = True Then
                                        If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation Then

                                            '동작 모드일때만 비교, 보관 모드일때는 소싱을 하지 않으므로 값이 모두 0이다, 따라서, 비교할 의미가 없다.
                                            If MeasValOfM6000.dPDCurrent >= ucTestEndParam(i).dValue Then
                                                If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = False Then  'False : Source Off, True : Source ON 
                                                    '소싱을 끄고 다음 단계로 이동
                                                    g_ChSchedulerStatus(in_Ch) = eChSchedulerSTATE.eLifeTime_StopSourcing
                                                Else '소싱을 끄지 않고 다음 단계로 이동
                                                    g_ChSchedulerStatus(in_Ch) = eChSchedulerSTATE.eChangeNextSeq
                                                End If
                                                'Luminace 산출  PD값 갱신 Flag 초기화 단, ChangeRecipe 모드 일때만
                                                If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.ChangeRecipe Then
                                                    fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = False
                                                End If
                                                fMain.frmMonitorUI.Message(in_Ch) = "Stop[End PD Current]"
                                                'fMain.frmControlTwoStpeCyle.target(in_Ch).SetIndicate_StopMessage = "Stop LifeMode PD Curr"
                                            End If

                                        End If
                                    End If


                                Case M7000.ucTestEndParam.eTestEndParam.eLumi
                                    If bCheckTestEnd = True Then
                                        If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation Then

                                            '동작 모드일때만 비교, 보관 모드일때는 소싱을 하지 않으므로 값이 모두 0이다, 따라서, 비교할 의미가 없다.
                                            If dLumi_Percent <= ucTestEndParam(i).dValue Then  'YSR_20130404 '조건문 < 에서 <= 로 변경 승현2013-04-14

                                                If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = False Then  'False : Source Off, True : Source ON 
                                                    '소싱을 끄고 다음 단계로 이동
                                                    g_ChSchedulerStatus(in_Ch) = eChSchedulerSTATE.eLifeTime_StopSourcing
                                                Else '소싱을 끄지 않고 다음 단계로 이동
                                                    g_ChSchedulerStatus(in_Ch) = eChSchedulerSTATE.eChangeNextSeq
                                                End If

                                                'Luminace 산출  PD값 갱신 Flag 초기화 단, ChangeRecipe 모드 일때만
                                                If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.ChangeRecipe Then
                                                    fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = False
                                                End If
                                                fMain.frmMonitorUI.Message(in_Ch) = "Stop[End Luminance]"
                                                'fMain.frmControlTwoStpeCyle.target(in_Ch).SetIndicate_StopMessage = "Stop LifeMode Luminance"
                                                'If fMain.SequenceList(in_Ch).Current.LifeTimeModeParams.bEndBiasStatus = False Then  'False : Source Off, True : Source ON 
                                                '    '소싱을 끄고 다음 단계로 이동
                                                '    g_ChSchedulerStauts(in_Ch) = eChSchedulerSTATE.eLifeTime_StopSourcing
                                                'Else '소싱을 끄지 않고 다음 단계로 이동
                                                '    g_ChSchedulerStauts(in_Ch) = eChSchedulerSTATE.eChangeNextSeq
                                                'End If
                                            End If

                                        End If
                                    End If



                                Case M7000.ucTestEndParam.eTestEndParam.eHightVolt '신규 종료조건 추가 2013-04-14 승현
                                    If bCheckTestEnd = True Then
                                        If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation Then
                                            '동작 모드일때만 비교, 보관 모드일때는 소싱을 하지 않으므로 값이 모두 0이다, 따라서, 비교할 의미가 없다.
                                            If MeasValOfM6000.dVoltage_Amplitude >= ucTestEndParam(i).dValue Then

                                                If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = False Then  'False : Source Off, True : Source ON 
                                                    '소싱을 끄고 다음 단계로 이동
                                                    g_ChSchedulerStatus(in_Ch) = eChSchedulerSTATE.eLifeTime_StopSourcing
                                                Else '소싱을 끄지 않고 다음 단계로 이동
                                                    g_ChSchedulerStatus(in_Ch) = eChSchedulerSTATE.eChangeNextSeq
                                                End If

                                                'Luminace 산출  PD값 갱신 Flag 초기화 단, ChangeRecipe 모드 일때만
                                                If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.ChangeRecipe Then
                                                    fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = False
                                                End If
                                            End If
                                            fMain.frmMonitorUI.Message(in_Ch) = "Stop[End Volt]"
                                            'fMain.frmControlTwoStpeCyle.target(in_Ch).SetIndicate_StopMessage = "Stop LifeMode High Volt"
                                        End If
                                    End If



                                Case M7000.ucTestEndParam.eTestEndParam.eHighCurrent '신규 종료조건 추가 2013-04-14 승현
                                    If bCheckTestEnd = True Then
                                        If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation Then
                                            '동작 모드일때만 비교, 보관 모드일때는 소싱을 하지 않으므로 값이 모두 0이다, 따라서, 비교할 의미가 없다.
                                            If MeasValOfM6000.dCurrent_Amplitude >= ucTestEndParam(i).dValue Then

                                                If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = False Then  'False : Source Off, True : Source ON 
                                                    '소싱을 끄고 다음 단계로 이동
                                                    g_ChSchedulerStatus(in_Ch) = eChSchedulerSTATE.eLifeTime_StopSourcing
                                                Else '소싱을 끄지 않고 다음 단계로 이동
                                                    g_ChSchedulerStatus(in_Ch) = eChSchedulerSTATE.eChangeNextSeq
                                                End If

                                                'Luminace 산출  PD값 갱신 Flag 초기화 단, ChangeRecipe 모드 일때만
                                                If fMain.SequenceList(in_Ch).Current.sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode = ucRefPDSetting.eRefPDMode.ChangeRecipe Then
                                                    fMain.g_MeasuredDatas(in_Ch).bIsSavedRefPDCurrent = False
                                                End If
                                                fMain.frmMonitorUI.Message(in_Ch) = "Stop[End Current]"
                                                'fMain.frmControlTwoStpeCyle.target(in_Ch).SetIndicate_StopMessage = "Stop LifeMode High Curr"
                                            End If

                                        End If
                                    End If

                            End Select
                        End If
                    Next
                End If




                With fMain.SequenceList(in_Ch)

                    Dim remainTime As Long = .NextMeasureTime.nSecound - modeTime_sec
                    Dim m_mode As String
                    Dim sMsg As String

                    'dispChannel(in_Ch).TotalTime(totalTestTime)
                    'dispChannel(in_Ch).RemainTime(remainTime)

                    m_mode = "Life-Time"
                    sMsg = CStr(in_Ch + 1) & _
                           "| MODE : " & m_mode & _
                           "| Total Time : " & Format(totalTestTime, "0000") & _
                           "| Mode Time : " & Format(modeTime_sec, "0000") & _
                           "| Interval : " & Format(fMain.SequenceList(in_Ch).MeasInterval.nSecound, "0000") & _
                           "| Change : " & Format(fMain.SequenceList(in_Ch).ChangeInterval.nSecound, "0000") & _
                           "| dT(Meas) : " & Format(remainTime, "0000")
                    fMain.frmLog.SetStateMsg(in_Ch, sMsg)
                    'ElseIf .Current.Mode = ucControlPannel.eOperationMode.eTemp Then
                    'm_mode = "ChangeTemp"
                    'sMsg = CStr(in_Ch + 1) & _
                    '      "| MODE : " & m_mode & _
                    '      "| Meas Func : " & .Current.Mode.ToString & _
                    '      "| Total Time : " & Format(totalTestTime, "0000") & _
                    '      "| Mode Time : " & Format(modeTime, "0000") & _
                    '      "| Mode Delta Time : " & Format(modeDeltaTime, "0000")
                    'fMain.frmLog.SetStateMsg(in_Ch, sMsg)
                    'Else
                    'm_mode = "Other"
                    'sMsg = CStr(in_Ch + 1) & " | " & " MODE : " & m_mode
                    'fMain.frmLog.SetStateMsg(in_Ch, sMsg)
                    'End If
                End With

                'If fMain.SaveChannelLastStatusInfo(in_Ch) = False Then '상태 저장
                '    '예외 처리 필요
                'End If


            Else
                '  T.Text = TimeData(index - 1)
                '  T.ForeColor = Color.Blue
            End If
        Catch ex As Exception
            Dim test As Integer = 100
            Console.WriteLine(ex.Source.ToString)
            Console.WriteLine(ex.Message.ToString)
        End Try

    End Sub

    Private Function IsCheckedEndConditions(ByVal nCh As Integer, ByVal TestEndConditions() As ucTestEndParam.sTestEndParam, ByRef sStopReason As String) As Boolean

        Dim nEndParam As ucTestEndParam.eTestEndParam
        Dim dEndValue As Double
        If TestEndConditions Is Nothing Then Return True
        For idx As Integer = 0 To TestEndConditions.Length - 1

            nEndParam = TestEndConditions(idx).nTypeOfParam
            dEndValue = TestEndConditions(idx).dValue

            Select Case nEndParam

                Case ucTestEndParam.eTestEndParam.eTime
                    Dim HourPass As TimeSpan
                    HourPass = Now.Subtract(fMain.cTimeScheduler.g_SYSTIMEInfo(nCh).TestStartTime)
                    If dEndValue <= HourPass.TotalSeconds Then
                        sStopReason = "[End TotalTime]"  'fMain.frmControlUI.ControlUI.control.StopReason(nCh)
                        Return True ' g_ChSchedulerStatus(nCh) = eChSchedulerSTATE.eStop
                    End If

                Case ucTestEndParam.eTestEndParam.eLoopCount

                    If fMain.SequenceList(nCh).LoopCount >= dEndValue Then
                        sStopReason = "[End Loop Count]" 'fMain.frmControlUI.ControlUI.control.StopReason(nCh)
                        Return True
                    End If

                Case ucTestEndParam.eTestEndParam.eLumi
                    Select Case fMain.SequenceList(nCh).Current.sLifetimeInfo.nMyMode
                        Case ucSequenceBuilder.eRcpMode.eCell_Lifetime
                            If fMain.g_MeasuredDatas(nCh).bIsSavedRefPDCurrent = True Then
                                '  If fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData Is Nothing = False Then
                                If dEndValue >= fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(0).opticalData.dLumi_Percent Then  '첫번째 색상을 기준으로
                                    sStopReason = "[End Luminance]"  'fMain.frmControlUI.ControlUI.control.StopReason(nCh)
                                    Return True ' g_ChSchedulerStatus(nCh) = eChSchedulerSTATE.eStop
                                End If
                                'End If
                            End If

                        Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                            If fMain.g_MeasuredDatas(nCh).sPanelLTParams.dLumi_Percent <> 0 Then
                                If dEndValue >= fMain.g_MeasuredDatas(nCh).sPanelLTParams.dLumi_Percent Then
                                    sStopReason = "[End Luminance]"  ' fMain.frmControlUI.ControlUI.control.StopReason(nCh)
                                    Return True ' g_ChSchedulerStatus(nCh) = eChSchedulerSTATE.eStop
                                End If
                            End If

                        Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                            If fMain.g_MeasuredDatas(nCh).bIsSavedRefPDCurrent = True Then
                                If fMain.g_MeasuredDatas(nCh).sModuleLTParams.dLumi_Percent Is Nothing = False Then
                                    If dEndValue >= fMain.g_MeasuredDatas(nCh).sModuleLTParams.dLumi_Percent(0)(0) Then
                                        sStopReason = "[End Luminance]"   '  fMain.frmControlUI.ControlUI.control.StopReason(nCh)
                                        Return True '  g_ChSchedulerStatus(nCh) = eChSchedulerSTATE.eStop
                                    End If
                                End If
                            End If
                    End Select
                Case ucTestEndParam.eTestEndParam.ePDCurr
                    Select Case fMain.SequenceList(nCh).Current.sLifetimeInfo.nMyMode
                        Case ucSequenceBuilder.eRcpMode.eCell_Lifetime
                            If (dEndValue >= fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(0).dTotPDCurrent) Then
                                sStopReason = "[End PD Current]"  'fMain.frmControlUI.ControlUI.control.StopReason(nCh)
                                Return True '  g_ChSchedulerStatus(nCh) = eChSchedulerSTATE.eStop
                            End If
                        Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                            If dEndValue >= fMain.g_MeasuredDatas(nCh).sPanelLTParams.sMeasuredValues.dPD_I Then
                                sStopReason = "[End PD Current]"  'fMain.frmControlUI.ControlUI.control.StopReason(nCh)
                                Return True '  g_ChSchedulerStatus(nCh) = eChSchedulerSTATE.eStop
                            End If
                        Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                            If dEndValue >= fMain.g_MeasuredDatas(nCh).sModuleLTParams.sColorAnalyzer(0).sCA310(0).Lv Then
                                sStopReason = "[End PD Current]"  'fMain.frmControlUI.ControlUI.control.StopReason(nCh)
                                Return True '  g_ChSchedulerStatus(nCh) = eChSchedulerSTATE.eStop
                            End If
                    End Select

                Case ucTestEndParam.eTestEndParam.eVolt

                    Select Case fMain.SequenceList(nCh).Current.sLifetimeInfo.nMyMode
                        Case ucSequenceBuilder.eRcpMode.eCell_Lifetime
                            If dEndValue > fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(0).dTotVoltage Then
                                sStopReason = "[End Voltage]"  'fMain.frmControlUI.ControlUI.control.StopReason(nCh)
                                Return True ' g_ChSchedulerStatus(nCh) = eChSchedulerSTATE.eStop
                            End If
                        Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                            If dEndValue > Math.Abs(fMain.g_MeasuredDatas(nCh).sPanelLTParams.sMeasuredValues.dELVDD_V) Or _
                                dEndValue > Math.Abs(fMain.g_MeasuredDatas(nCh).sPanelLTParams.sMeasuredValues.dELVSS_V) Then
                                sStopReason = "[End Voltage]"   'fMain.frmControlUI.ControlUI.control.StopReason(nCh)
                                Return True ' g_ChSchedulerStatus(nCh) = eChSchedulerSTATE.eStop
                            End If
                        Case ucSequenceBuilder.eRcpMode.eModule_Lifetime

                    End Select

                Case ucTestEndParam.eTestEndParam.eCurr

                    Select Case fMain.SequenceList(nCh).Current.sLifetimeInfo.nMyMode
                        Case ucSequenceBuilder.eRcpMode.eCell_Lifetime
                            If (fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(0).dTotCurrent >= dEndValue) Then
                                sStopReason = "[End Current]"  'fMain.frmControlUI.ControlUI.control.StopReason(nCh)
                                Return True ' g_ChSchedulerStatus(nCh) = eChSchedulerSTATE.eStop
                            End If
                        Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                            If Math.Abs(fMain.g_MeasuredDatas(nCh).sPanelLTParams.sMeasuredValues.dELVDD_I) > dEndValue Or _
                                Math.Abs(fMain.g_MeasuredDatas(nCh).sPanelLTParams.sMeasuredValues.dELVSS_I) > dEndValue Then
                                sStopReason = "[End Current]"   'fMain.frmControlUI.ControlUI.control.StopReason(nCh)
                                Return True '  g_ChSchedulerStatus(nCh) = eChSchedulerSTATE.eStop
                            End If

                        Case ucSequenceBuilder.eRcpMode.eModule_Lifetime

                    End Select
            End Select

        Next

        Return False
    End Function


    Private Function CanChangeNextSequence(ByVal inCh As Integer) As Boolean
        '============================================================
        '2. 무조건 채널 번호가 빠른 채널 1개씩 실행
        Dim nIdleCnt As Integer = 0
        Dim nCntProgerssState As Integer

        '실험 진행중인 채널이 있으면, 대기 상태
        For idx As Integer = 0 To g_nMaxCh - 1
            If g_ChSchedulerStatus(idx) <> eChSchedulerSTATE.eIdle And g_ChSchedulerStatus(idx) <> eChSchedulerSTATE.eRun Then
                nCntProgerssState += 1
            End If
        Next

        If nCntProgerssState >= 1 Then Return False

        'Run 대기중인 채널중에 나보다 채널번호가 빠른 채널이 있으면, inCh는 대기
        For idx As Integer = 0 To g_nMaxCh - 1
            If g_ChSchedulerStatus(idx) = eChSchedulerSTATE.eRun Then
                If idx < inCh Then Return False
            End If
        Next
        '=================================

        Return True

    End Function

    'LG화학
    'Private Function CanChangeNextSequence(ByVal inCh As Integer) As Boolean
    '    Dim BGroupBegin As Integer = 25
    '    Dim BGroupEnd As Integer = 33
    '    Dim AGroupEnd As Integer = 24

    '    'B Group의 채널이 돌고 있을때는 다른 채널은 실험을 할 수 없음.
    '    For i As Integer = 25 To BGroupEnd
    '        '채널 상태가 IDEL 또는 Run 이라면 실제 실험이 시작 되지는 않았음.


    '        If g_ChSchedulerStatus(i) <> eChSchedulerSTATE.eIdle Then 'And g_ChSchedulerStatus(i) <> eChSchedulerSTATE.eRun And g_ChSchedulerStatus(i) <> eChSchedulerSTATE.eChangeNextSeq Then
    '            If inCh < BGroupBegin Or inCh > BGroupEnd Then
    '                Return False
    '            End If
    '            If i <> inCh Then
    '                Return False
    '            Else
    '                Return True
    '            End If


    '        End If




    '    Next


    '    'A group의 채널이 IVL을 측정 중일때 다음 시퀸스로 변경 할 수 없음. 모두다 하고 넘어가야함.
    '    Dim RcpIdx(AGroupEnd) As Integer
    '    Dim CycleIdx(AGroupEnd) As Integer

    '    If inCh >= 0 And inCh <= AGroupEnd Then

    '        Dim myRcpIdx As Integer = fMain.SequenceList(inCh).Current.recipeIndex
    '        Dim myCycleIdx As Integer = fMain.SequenceList(inCh).LoopCount

    '        If g_ChSchedulerStatus(inCh) = eChSchedulerSTATE.eRun Then Return True

    '        For i As Integer = 0 To AGroupEnd

    '            If g_ChSchedulerStatus(i) <> eChSchedulerSTATE.eIdle Then
    '                If i <> inCh Then

    '                    If fMain.SequenceList(i).Current.recipeIndex < myRcpIdx Then

    '                        If fMain.SequenceList(i).LoopCount = myCycleIdx Then
    '                            If g_ChSchedulerStatus(i) <> eChSchedulerSTATE.eIdle Then
    '                                'If i < inCh Then
    '                                Return False
    '                                'End If
    '                            End If
    '                        End If


    '                    ElseIf fMain.SequenceList(i).LoopCount < myCycleIdx Then

    '                        If g_ChSchedulerStatus(i) <> eChSchedulerSTATE.eIdle Then
    '                            Return False
    '                        End If

    '                    Else

    '                        If g_ChSchedulerStatus(i) = eChSchedulerSTATE.eIVLSweep Then
    '                            If i <> inCh Then
    '                                Return False
    '                            End If
    '                        End If

    '                    End If
    '                End If
    '            End If

    '        Next


    '        For i As Integer = 0 To AGroupEnd
    '            If g_ChSchedulerStatus(i) <> eChSchedulerSTATE.eIdle Then
    '                If i <> inCh Then
    '                    RcpIdx(i) = fMain.SequenceList(i).Current.recipeIndex
    '                    CycleIdx(i) = fMain.SequenceList(i).LoopCount
    '                End If
    '            End If
    '        Next


    '        Dim RcpIdxBuf() As Integer = Nothing
    '        Dim nCntIdxBuf As Integer = 0
    '        Dim CycleIdxBuf() As Integer = Nothing
    '        Dim nCntCycleIdxBuf As Integer = 0




    '        For i As Integer = 0 To AGroupEnd

    '            If g_ChSchedulerStatus(i) = eChSchedulerSTATE.eChangeNextSeq Then  '현재 채널 이외에도 Next Sequence 전환 대기 상태의 채널이 있는지 확인
    '                If i < inCh Then  'Next Seq 상태의 채널에서 나보다 채널 번호가 빠른 채널이 있으면 우선 전환 해야 하므로, 채널번호가 작으면

    '                    If RcpIdx(i) <= myRcpIdx Then  'recipe index 가 작거나 같으면 빠른 채널부터 전환해야 하므로 나는 대기   'And CycleIdx(i) < myCycleIdx
    '                        Return False
    '                    End If

    '                    If CycleIdx(i) < myCycleIdx Then 'cycle index가 작거나 같으면 빠른 채널 부터 전환해야 하므로 나는 대기
    '                        Return False
    '                    End If



    '                End If
    '            End If
    '        Next

    '        'For i As Integer = 0 To AGroupEnd

    '        '    If g_ChSchedulerStatus(i) <> eChSchedulerSTATE.eIdle Then
    '        '        If i <> inCh Then
    '        '            If RcpIdx(i) < myRcpIdx Then
    '        '                ReDim Preserve RcpIdxBuf(nCntIdxBuf)
    '        '                RcpIdxBuf(nCntIdxBuf) = i
    '        '                nCntIdxBuf += 1
    '        '            End If
    '        '            If CycleIdx(i) < myCycleIdx Then
    '        '                ReDim Preserve CycleIdxBuf(nCntCycleIdxBuf)
    '        '                CycleIdxBuf(nCntCycleIdxBuf) = i
    '        '                nCntCycleIdxBuf += 1
    '        '            End If
    '        '        End If
    '        '    End If
    '        'Next



    '        'If RcpIdxBuf Is Nothing = False Then
    '        '    For i As Integer = 0 To RcpIdxBuf.Length - 1
    '        '        If RcpIdxBuf(i) <> inCh Then
    '        '            If RcpIdxBuf(i) < myRcpIdx Then
    '        '                Return False
    '        '            End If
    '        '        End If
    '        '    Next

    '        'End If

    '        'If CycleIdxBuf Is Nothing = False Then
    '        '    For i As Integer = 0 To CycleIdxBuf.Length - 1
    '        '        If CycleIdxBuf(i) <> inCh Then
    '        '            If CycleIdxBuf(i) < myCycleIdx Then
    '        '                Return False
    '        '            End If
    '        '        End If
    '        '    Next
    '        'End If



    '        'For ii As Integer = 0 To AGroupEnd
    '        '    If g_ChSchedulerStatus(ii) = eChSchedulerSTATE.eIVLSweep Then
    '        '        If ii <> inCh Then
    '        '            Return False
    '        '        End If
    '        '    End If
    '        'Next
    '        Return True
    '    End If


    '    Return True

    'End Function

#End Region

#Region "Save/Load Status Information"

    Public Sub SaveStateOfChannel()

        Dim Saver As New CChannelStatusINI(g_sSavePath_StateOfChannel)

        Saver.SaveIniValue(CChannelStatusINI.eSecID.eCommInfo, 0, CChannelStatusINI.eKeyID.numOfCh, g_nMaxCh)

        For i As Integer = 0 To g_nMaxCh - 1

            If g_SystemInfo.bCanUpdateStateInfoOfCh(i) = True Then  '스레드가 시작 될때 초기 상태를 무조건 갱신하는 것을 방지, 사용자가 명령을 내렸거나, 이어붙이기가 시작된 다음부터 정보를 갱신

                If g_ChSchedulerStatus(i) = eChSchedulerSTATE.eIdle Then
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SchedulerStatus, g_ChSchedulerStatus(i).ToString)
                Else
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SchedulerStatus, g_ChSchedulerStatus(i).ToString)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SystemTime_IsSavedModeStartTime, CStr(g_SYSTIMEInfo(i).IsSavedModeStartTime))
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SystemTime_ModeStartTime, g_SYSTIMEInfo(i).ModeStartTime.ToString)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SystemTime_IsSavedTestStartTime, g_SYSTIMEInfo(i).IsSavedTestStartTime.ToString)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SystemTime_TestStartTime, g_SYSTIMEInfo(i).TestStartTime.ToString)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SystemTime_IntervalStartTime, g_SYSTIMEInfo(i).IntervalStartTime.ToString)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SystemTime_IsSavedIntervalStartTime, g_SYSTIMEInfo(i).IsSavedIntervalStartTime.ToString)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SystemTime_Lifetime_Hour, g_SYSTIMEInfo(i).LifeTime.dHour)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SystemTime_Lifetime_Min, g_SYSTIMEInfo(i).LifeTime.dMin)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SystemTime_Lifetime_Second, g_SYSTIMEInfo(i).LifeTime.nSecound)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SystemTime_IsSavedLifeTime, CStr(g_SYSTIMEInfo(i).IsSavedLifeTime))
                    '-------------------------
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SaveInfo_Count, fMain.g_DataSaver(i).numberOfSaveFile)
                    '  For n As Integer = 0 To fMain.g_DataSaver(i).numberOfSaveFile - 1
                    For n As Integer = 0 To fMain.SequenceList(i).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT, n, fMain.g_DataSaver(i).m_sSavePath_LT(n))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT_BackUp, n, fMain.g_DataSaver(i).m_sSavePath_LT_Backup(n))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT_Spectrum, n, fMain.g_DataSaver(i).m_sSavePath_LT_SpectrumData(n))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT_Spectrum_BackUp, n, fMain.g_DataSaver(i).m_sSavePath_LT_SpectrumData_Backup(n))

                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SaveInfo_TestStartTime, n, fMain.g_DataSaver(i).StartTime(n).ToString)
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SaveInfo_nCntSaveData, n, CStr(fMain.g_DataSaver(i).SavedDataCounter(n)))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SaveInfo_nCntREDSaveData, n, CStr(fMain.g_DataSaver(i).RedSavedDataCounter(n)))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SaveInfo_nCntGREENSaveData, n, CStr(fMain.g_DataSaver(i).GreenSavedDataCounter(n)))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SaveInfo_nCntBLUESaveData, n, CStr(fMain.g_DataSaver(i).BlueSavedDataCounter(n)))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SaveInfo_nCntBLACKSaveData, n, CStr(fMain.g_DataSaver(i).BlackSavedDataCounter(n)))

                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SaveInfo_Lifetime, n, fMain.g_DataSaver(i).Lifetime(n).TotalHours.ToString)
                    Next
                    '--------------
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_Index, fMain.SequenceList(i).Index)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx, fMain.SequenceList(i).CurrentRecipeIndex)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_LT, fMain.SequenceList(i).CurrentRecipeIndex_LifeTime)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_ChangeTemp, fMain.SequenceList(i).CurrentRecipeIndex_ChangeTemp)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_IVLSweep, fMain.SequenceList(i).CurrentRecipeIndex_IVLSweep)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_ViewingAngle, fMain.SequenceList(i).CurrentRecipeIndex_ViewingAngle)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_LifetimeAndIVL, fMain.SequenceList(i).CurrentRecipeIndex_LifetimeAndIVL)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_MeasCount_LifetimeAfterIVLSweep, fMain.SequenceList(i).IVLSweepMeasCount)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_MeasInterval_TimeVal_Hour, fMain.SequenceList(i).MeasInterval.dHour)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_MeasInterval_TimeVal_Min, fMain.SequenceList(i).MeasInterval.dMin)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_MeasInterval_TimeVal_Second, fMain.SequenceList(i).MeasInterval.nSecound)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_ChangeInterval_TimeVal_Hour, fMain.SequenceList(i).ChangeInterval.dHour)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_ChangeInterval_TimeVal_Min, fMain.SequenceList(i).ChangeInterval.dMin)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_ChangeInterval_TimeVal_Second, fMain.SequenceList(i).ChangeInterval.nSecound)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_NextMeasureTime_TimeVal_Hour, fMain.SequenceList(i).NextMeasureTime.dHour)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_NextMeasureTime_TimeVal_Min, fMain.SequenceList(i).NextMeasureTime.dMin)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_NextMeasureTime_TimeVal_Second, fMain.SequenceList(i).NextMeasureTime.nSecound)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_RequestTest, fMain.SequenceList(i).RequestTest)
                    ' Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_RequestFirstTest, fMain.SequenceList(i).RequestFirstTest)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_IsLastSequence, fMain.SequenceList(i).IsLastSequence)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_LoopCount, fMain.SequenceList(i).LoopCount)

                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_PD_Saved_Status, fMain.g_MeasuredDatas(i).bIsSavedRefPDCurrent)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_PD_Value, fMain.g_MeasuredDatas(i).dRefValue)



                    '=====================

                    For j As Integer = 0 To fMain.SequenceList(i).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Color_Type, j, fMain.g_MeasuredDatas(i).sCellLTParams.LTData(j).type.ToString)
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, j, fMain.g_MeasuredDatas(i).sCellLTParams.LTData(j).eletricalData.dRefVoltage)
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, j, fMain.g_MeasuredDatas(i).sCellLTParams.LTData(j).eletricalData.dRefCurrent)
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, j, fMain.g_MeasuredDatas(i).sCellLTParams.LTData(j).eletricalData.dCurrent_Per)
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.LTData(j).opticalData.dRefLumi))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.LTData(j).opticalData.dLumi_Percent))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.LTData(j).opticalData.dRefLumi_Percent))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.LTData(j).opticalData.dRefSpectrum_Percent))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.LTData(j).opticalData.dRefud))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.LTData(j).opticalData.dRefvd))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.LTData(j).opticalData.dLumi_Cd_A_RefValue))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.LTData(j).opticalData.dLumi_Cd_A_Percent))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.LTData(j).opticalData.dSpectrumSum_Ref))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.LTData(j).opticalData.dSpectrumSum_Per))
                    Next

                    For j As Integer = 0 To fMain.SequenceList(i).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Color_Type, j, fMain.g_MeasuredDatas(i).sCellLTParams.RedLTData(j).type.ToString, "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, j, fMain.g_MeasuredDatas(i).sCellLTParams.RedLTData(j).eletricalData.dRefVoltage, "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, j, fMain.g_MeasuredDatas(i).sCellLTParams.RedLTData(j).eletricalData.dRefCurrent, "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, j, fMain.g_MeasuredDatas(i).sCellLTParams.RedLTData(j).eletricalData.dCurrent_Per, "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.RedLTData(j).opticalData.dRefLumi), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.RedLTData(j).opticalData.dLumi_Percent), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.RedLTData(j).opticalData.dRefLumi_Percent), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.RedLTData(j).opticalData.dRefSpectrum_Percent), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.RedLTData(j).opticalData.dRefud), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.RedLTData(j).opticalData.dRefvd), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.RedLTData(j).opticalData.dLumi_Cd_A_RefValue), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.RedLTData(j).opticalData.dLumi_Cd_A_Percent), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.RedLTData(j).opticalData.dSpectrumSum_Ref), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.RedLTData(j).opticalData.dSpectrumSum_Per), "RED")
                    Next

                    For j As Integer = 0 To fMain.SequenceList(i).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Color_Type, j, fMain.g_MeasuredDatas(i).sCellLTParams.GreenLTData(j).type.ToString, "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, j, fMain.g_MeasuredDatas(i).sCellLTParams.GreenLTData(j).eletricalData.dRefVoltage, "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, j, fMain.g_MeasuredDatas(i).sCellLTParams.GreenLTData(j).eletricalData.dRefCurrent, "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, j, fMain.g_MeasuredDatas(i).sCellLTParams.GreenLTData(j).eletricalData.dCurrent_Per, "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.GreenLTData(j).opticalData.dRefLumi), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.GreenLTData(j).opticalData.dLumi_Percent), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.GreenLTData(j).opticalData.dRefLumi_Percent), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.GreenLTData(j).opticalData.dRefSpectrum_Percent), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.GreenLTData(j).opticalData.dRefud), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.GreenLTData(j).opticalData.dRefvd), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.GreenLTData(j).opticalData.dLumi_Cd_A_RefValue), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.GreenLTData(j).opticalData.dLumi_Cd_A_Percent), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.GreenLTData(j).opticalData.dSpectrumSum_Ref), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.GreenLTData(j).opticalData.dSpectrumSum_Per), "GREEN")
                    Next

                    For j As Integer = 0 To fMain.SequenceList(i).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Color_Type, j, fMain.g_MeasuredDatas(i).sCellLTParams.BlueLTData(j).type.ToString, "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, j, fMain.g_MeasuredDatas(i).sCellLTParams.BlueLTData(j).eletricalData.dRefVoltage, "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, j, fMain.g_MeasuredDatas(i).sCellLTParams.BlueLTData(j).eletricalData.dRefCurrent, "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, j, fMain.g_MeasuredDatas(i).sCellLTParams.BlueLTData(j).eletricalData.dCurrent_Per, "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlueLTData(j).opticalData.dRefLumi), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlueLTData(j).opticalData.dLumi_Percent), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlueLTData(j).opticalData.dRefLumi_Percent), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlueLTData(j).opticalData.dRefSpectrum_Percent), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlueLTData(j).opticalData.dRefud), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlueLTData(j).opticalData.dRefvd), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlueLTData(j).opticalData.dLumi_Cd_A_RefValue), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlueLTData(j).opticalData.dLumi_Cd_A_Percent), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlueLTData(j).opticalData.dSpectrumSum_Ref), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlueLTData(j).opticalData.dSpectrumSum_Per), "BLUE")
                    Next

                    For j As Integer = 0 To fMain.SequenceList(i).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Color_Type, j, fMain.g_MeasuredDatas(i).sCellLTParams.BlackLTData(j).type.ToString, "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, j, fMain.g_MeasuredDatas(i).sCellLTParams.BlackLTData(j).eletricalData.dRefVoltage, "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, j, fMain.g_MeasuredDatas(i).sCellLTParams.BlackLTData(j).eletricalData.dRefCurrent, "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, j, fMain.g_MeasuredDatas(i).sCellLTParams.BlackLTData(j).eletricalData.dCurrent_Per, "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlackLTData(j).opticalData.dRefLumi), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlackLTData(j).opticalData.dLumi_Percent), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlackLTData(j).opticalData.dRefLumi_Percent), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlackLTData(j).opticalData.dRefSpectrum_Percent), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlackLTData(j).opticalData.dRefud), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlackLTData(j).opticalData.dRefvd), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlackLTData(j).opticalData.dLumi_Cd_A_RefValue), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlackLTData(j).opticalData.dLumi_Cd_A_Percent), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlackLTData(j).opticalData.dSpectrumSum_Ref), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, j, CStr(fMain.g_MeasuredDatas(i).sCellLTParams.BlackLTData(j).opticalData.dSpectrumSum_Per), "BLACK")
                    Next

                    '===================
                    'If fMain.g_MeasuredDatas(i).sModuleLTParams.dRefLumi Is Nothing = False And
                    '    fMain.g_MeasuredDatas(i).sModuleLTParams.dLumi_Percent Is Nothing = False Then
                    '    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Num_Of_Meas_Image, CStr(fMain.g_MeasuredDatas(i).sModuleLTParams.dRefLumi.Length))

                    '    If fMain.g_MeasuredDatas(i).sModuleLTParams.dRefLumi(0) Is Nothing = False And
                    '        fMain.g_MeasuredDatas(i).sModuleLTParams.dLumi_Percent(0) Is Nothing = False Then
                    '        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Num_Of_Meas_Point, CStr(fMain.g_MeasuredDatas(i).sModuleLTParams.dRefLumi(0).Length))
                    '        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqInfo_Num_Of_Total_Meas_Point, CStr(fMain.g_MeasuredDatas(i).sModuleLTParams.dRefLumi.Length * fMain.g_MeasuredDatas(i).sModuleLTParams.dRefLumi(0).Length))

                    '        Dim dataCnt As Integer = 0
                    '        For imgIdx As Integer = 0 To fMain.g_MeasuredDatas(i).sModuleLTParams.dRefLumi.Length - 1

                    '            For ptIdx As Integer = 0 To fMain.g_MeasuredDatas(i).sModuleLTParams.dRefLumi(imgIdx).Length - 1
                    '                dataCnt = (imgIdx + 1) * (ptIdx + 1)
                    '                Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, _
                    '                                   CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, dataCnt, CStr(fMain.g_MeasuredDatas(i).sModuleLTParams.dRefLumi(imgIdx)(ptIdx)))
                    '                Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, _
                    '                                 CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, dataCnt, CStr(fMain.g_MeasuredDatas(i).sModuleLTParams.dLumi_Percent(imgIdx)(ptIdx)))
                    '            Next
                    '        Next
                    '    End If

                    'End If

                    For n As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
                        Select Case g_ConfigInfos.nDevice(n)

                            Case frmConfigSystem.eDeviceItem.eSMU_M6000
                                Dim nDevNoOfM6000 As Integer = frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                                Dim nChNoOfM6000 As Integer = frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eChOfM6000)
                                If nDevNoOfM6000 >= 0 And nChNoOfM6000 >= 0 Then
                                    If fMain.cM6000 Is Nothing = False Then
                                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.M6000SeqRoutine_Status, fMain.cM6000(nDevNoOfM6000).ChannelStatus(nChNoOfM6000).ToString)
                                    End If
                                End If
                            Case frmConfigSystem.eDeviceItem.eMcSG
                                Dim nGroupNoOfSG As Integer = frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eGroupOfSG)
                                Dim nChNoOfSG As Integer = frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eChOfSG)
                                If fMain.cMcSG Is Nothing = False Then
                                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SGSeqRoutine_Status, fMain.cMcSG(nGroupNoOfSG).ChannelStatus(nChNoOfSG).ToString)
                                End If
                            Case frmConfigSystem.eDeviceItem.ePG

                            Case frmConfigSystem.eDeviceItem.eTC

                        End Select
                    Next

                End If

            End If

            ' Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_SeqFilePath, g_ChSchedulerStatus(i).ToString)
        Next

    End Sub

    ''' <summary>
    ''' Get the Status of each channel
    ''' </summary>
    ''' <param name="nCh">Select Channel</param>
    ''' <param name="status">Last Status Of Selected Channel</param>
    ''' <returns> Can Not Found Status Information</returns>
    ''' <remarks></remarks>
    Public Shared Function CheckLastStatusOfChannel(ByVal nCh As Integer, ByRef status As CScheduler.eChSchedulerSTATE) As Boolean
        If File.Exists(g_sSavePath_StateOfChannel) = False Then Return False
        Dim Loader As New CChannelStatusINI(g_sSavePath_StateOfChannel)
        Try
            status = CScheduler.ConvertScheduleStateStringToInt(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SchedulerStatus))
            If status = -1 Then  '저정된 값이 없을 때
                status = eChSchedulerSTATE.eIdle
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function IsExistsUnnormalStopChannel(ByRef TargetChNo() As Integer) As Boolean
        Dim nCnt As Integer = 0
        Dim channelNo() As Integer = Nothing
        Dim schedulerState As CScheduler.eChSchedulerSTATE
        For i As Integer = 0 To g_nMaxCh - 1
            If CheckLastStatusOfChannel(i, schedulerState) = True Then
                If schedulerState <> eChSchedulerSTATE.eIdle Then
                    ReDim Preserve channelNo(nCnt)
                    channelNo(nCnt) = i
                    nCnt += 1
                End If
            End If
        Next
        If nCnt = 0 Then Return False
        TargetChNo = channelNo.Clone
        Return True
    End Function


    Public Function LoadStateInfoOfChannel(ByVal nCh As Integer, ByRef sequenceInfo As CSequenceManager, ByRef dataSaver As cDataOutput) As Boolean
        Dim Loader As New CChannelStatusINI(g_sSavePath_StateOfChannel)
        Dim nMaxCh As Integer
        nMaxCh = Loader.LoadIniValue(CChannelStatusINI.eSecID.eCommInfo, 0, CChannelStatusINI.eKeyID.numOfCh)

        If nCh >= nMaxCh Then Return False


        ''Load 된 기본 Sequence 정보에 , 마지막 상태를 적용함.
        g_SYSTIMEInfo(nCh).IsSavedModeStartTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IsSavedModeStartTime)
        g_SYSTIMEInfo(nCh).ModeStartTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_ModeStartTime)
        g_SYSTIMEInfo(nCh).IsSavedTestStartTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IsSavedTestStartTime)
        g_SYSTIMEInfo(nCh).TestStartTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_TestStartTime)
        g_SYSTIMEInfo(nCh).IntervalStartTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IntervalStartTime)
        g_SYSTIMEInfo(nCh).IsSavedIntervalStartTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IsSavedIntervalStartTime)
        g_SYSTIMEInfo(nCh).LifeTime.dHour = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_Lifetime_Hour)
        g_SYSTIMEInfo(nCh).LifeTime.dMin = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_Lifetime_Min)
        g_SYSTIMEInfo(nCh).LifeTime.nSecound = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_Lifetime_Second)
        g_SYSTIMEInfo(nCh).IsSavedLifeTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IsSavedLifeTime)
        '-------------------------

        'SequenceManager Class 객체에  이전 상태 정보를 적용
        sequenceInfo.Index = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_Index)
        sequenceInfo.CurrentRecipeIndex(True) = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx)
        sequenceInfo.CurrentRecipeIndex_LifeTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_LT)
        sequenceInfo.CurrentRecipeIndex_ChangeTemp = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_ChangeTemp)
        sequenceInfo.CurrentRecipeIndex_IVLSweep = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_IVLSweep)
        sequenceInfo.CurrentRecipeIndex_ViewingAngle = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_ViewingAngle)
        sequenceInfo.CurrentRecipeIndex_LifetimeAndIVL = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_LifetimeAndIVL)
        sequenceInfo.IVLSweepMeasCount = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_MeasCount_LifetimeAfterIVLSweep)


        Dim timeVal1 As CTime.sTimeValue
        timeVal1.dHour = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_MeasInterval_TimeVal_Hour)
        timeVal1.dMin = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_MeasInterval_TimeVal_Min)
        timeVal1.nSecound = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_MeasInterval_TimeVal_Second)
        sequenceInfo.MeasInterval = timeVal1

        Dim timeVal2 As CTime.sTimeValue
        timeVal2.dHour = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_ChangeInterval_TimeVal_Hour)
        timeVal2.dMin = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_ChangeInterval_TimeVal_Min)
        timeVal2.nSecound = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_ChangeInterval_TimeVal_Second)
        sequenceInfo.ChangeInterval = timeVal2

        Dim timeVal3 As CTime.sTimeValue
        timeVal3.dHour = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_NextMeasureTime_TimeVal_Hour)
        timeVal3.dMin = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_NextMeasureTime_TimeVal_Min)
        timeVal3.nSecound = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_NextMeasureTime_TimeVal_Second)
        'sequenceInfo.NextMeasureTime = timeVal3 '  = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_NextMeasureTime_TimeVal_Hour)

        Dim timeSpanVal1 As TimeSpan
        timeSpanVal1 = Now.Subtract(g_SYSTIMEInfo(nCh).ModeStartTime)
        timeVal3 = CTime.Convert_SecToTimeValue(timeSpanVal1.TotalSeconds)
        sequenceInfo.NextMeasureTime = timeVal3

        sequenceInfo.RequestTest = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_RequestTest)
        '  sequenceInfo.RequestFirstTest = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_RequestFirstTest)
        ' sequenceInfo.IsLastSequence = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_IsLastSequence)
        sequenceInfo.LoopCount = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_LoopCount)

        'Current Recipe 값을 할당 및 갱신
        sequenceInfo.UpdateCurrentRecipe()

        fMain.g_MeasuredDatas(nCh).bIsSavedRefPDCurrent = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_PD_Saved_Status)
        fMain.g_MeasuredDatas(nCh).dRefValue = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_PD_Value)

        '데이터 저장 클래스 객체 생성 하고, 마지막 상태의 정보를 적용
        dataSaver = New cDataOutput(sequenceInfo.SequenceInfo, g_SystemOptions.sOptionData.SaveOptions.nFileType, nCh)

        Dim nCnt As Integer
        nCnt = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_Count)

        If dataSaver.numberOfSaveFile <> nCnt Then
            fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_Popup_Log, CStateMsg.eStateMsg.eSEQUENCE_Number_Error_Of_Save_File)
            'MsgBox("데이저 정보가 일치하지 않습니다.")
        End If

        Dim sTemp As String
        'Dim sTempSavePath(dataSaver.numberOfSaveFile - 1) As String
        'Dim sTempSavePath_Backup(dataSaver.numberOfSaveFile - 1) As String
        'Dim sTempSavePathSpectrum(dataSaver.numberOfSaveFile - 1) As String
        'Dim sTempSavePathSpectrum_Backup(dataSaver.numberOfSaveFile - 1) As String
        'Dim sTempStartTime(dataSaver.numberOfSaveFile - 1) As Date
        'Dim sTempDataCnt(dataSaver.numberOfSaveFile - 1) As Integer

        Dim sTempSavePath(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As String
        Dim sTempSavePath_Backup(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As String
        Dim sTempSavePathSpectrum(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As String
        Dim sTempSavePathSpectrum_Backup(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As String
        Dim sTempStartTime(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As Date
        Dim sTempDataCnt(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As Integer
        Dim sTempREDDataCnt(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As Integer
        Dim sTempGREENDataCnt(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As Integer
        Dim sTempBLUEDataCnt(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As Integer
        Dim sTempBLACKDataCnt(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As Integer

        '  For n As Integer = 0 To dataSaver.numberOfSaveFile - 1
        For n As Integer = 0 To sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
            sTempSavePath(n) = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT, n)
            sTempSavePath_Backup(n) = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT_BackUp, n)
            sTempSavePathSpectrum(n) = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT_Spectrum, n)
            sTempSavePathSpectrum_Backup(n) = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT_Spectrum_BackUp, n)


            sTemp = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_TestStartTime, n)
            sTempStartTime(n) = sTemp

            sTemp = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntSaveData, n)
            sTempDataCnt(n) = CInt(sTemp)

            sTemp = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntREDSaveData, n)
            sTempREDDataCnt(n) = CInt(sTemp)

            sTemp = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntGREENSaveData, n)
            sTempGREENDataCnt(n) = CInt(sTemp)

            sTemp = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntBLUESaveData, n)
            sTempBLUEDataCnt(n) = CInt(sTemp)

            sTemp = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntBLACKSaveData, n)
            sTempBLACKDataCnt(n) = CInt(sTemp)

            ' dataSaver.Lifetime(n).TotalHours = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SaveInfo_Lifetime, n)
        Next
        dataSaver.m_sSavePath_LT = sTempSavePath.Clone
        dataSaver.m_sSavePath_LT_Backup = sTempSavePath_Backup.Clone
        dataSaver.m_sSavePath_LT_SpectrumData = sTempSavePathSpectrum.Clone
        dataSaver.m_sSavePath_LT_SpectrumData_Backup = sTempSavePathSpectrum_Backup.Clone
        dataSaver.StartTime = sTempStartTime.Clone
        dataSaver.SavedDataCounter = sTempDataCnt.Clone
        dataSaver.RedSavedDataCounter = sTempREDDataCnt.Clone
        dataSaver.GreenSavedDataCounter = sTempGREENDataCnt.Clone
        dataSaver.BlueSavedDataCounter = sTempBLUEDataCnt.Clone
        dataSaver.blackSavedDataCounter = sTempBLACKDataCnt.Clone
        '--------------

        '======================================
        For j As Integer = 0 To sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).eletricalData.dRefVoltage = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, j))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).eletricalData.dRefCurrent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, j))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).eletricalData.dCurrent_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, j))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dRefLumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, j))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, j))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dRefLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, j))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dRefSpectrum_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, j))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dRefud = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, j))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dRefvd = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, j))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dLumi_Cd_A_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, j))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dLumi_Cd_A_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, j))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dSpectrumSum_Ref = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, j))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(j).opticalData.dSpectrumSum_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, j))
        Next

        '======================================
        For j As Integer = 0 To sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
            fMain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(j).eletricalData.dRefVoltage = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, j, "RED"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(j).eletricalData.dRefCurrent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, j, "RED"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(j).eletricalData.dCurrent_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, j, "RED"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(j).opticalData.dRefLumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, j, "RED"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(j).opticalData.dLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, j, "RED"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(j).opticalData.dRefLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, j, "RED"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(j).opticalData.dRefSpectrum_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, j, "RED"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(j).opticalData.dRefud = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, j, "RED"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(j).opticalData.dRefvd = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, j, "RED"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(j).opticalData.dLumi_Cd_A_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, j, "RED"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(j).opticalData.dLumi_Cd_A_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, j, "RED"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(j).opticalData.dSpectrumSum_Ref = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, j, "RED"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(j).opticalData.dSpectrumSum_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, j, "RED"))
        Next

        For j As Integer = 0 To sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
            fMain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(j).eletricalData.dRefVoltage = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, j, "GREEN"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(j).eletricalData.dRefCurrent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, j, "GREEN"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(j).eletricalData.dCurrent_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, j, "GREEN"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(j).opticalData.dRefLumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, j, "GREEN"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(j).opticalData.dLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, j, "GREEN"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(j).opticalData.dRefLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, j, "GREEN"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(j).opticalData.dRefSpectrum_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, j, "GREEN"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(j).opticalData.dRefud = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, j, "GREEN"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(j).opticalData.dRefvd = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, j, "GREEN"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(j).opticalData.dLumi_Cd_A_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, j, "GREEN"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(j).opticalData.dLumi_Cd_A_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, j, "GREEN"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(j).opticalData.dSpectrumSum_Ref = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, j, "GREEN"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(j).opticalData.dSpectrumSum_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, j, "GREEN"))
        Next

        For j As Integer = 0 To sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(j).eletricalData.dRefVoltage = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, j, "BLUE"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(j).eletricalData.dRefCurrent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, j, "BLUE"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(j).eletricalData.dCurrent_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, j, "BLUE"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(j).opticalData.dRefLumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, j, "BLUE"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(j).opticalData.dLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, j, "BLUE"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(j).opticalData.dRefLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, j, "BLUE"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(j).opticalData.dRefSpectrum_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, j, "BLUE"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(j).opticalData.dRefud = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, j, "BLUE"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(j).opticalData.dRefvd = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, j, "BLUE"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(j).opticalData.dLumi_Cd_A_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, j, "BLUE"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(j).opticalData.dLumi_Cd_A_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, j, "BLUE"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(j).opticalData.dSpectrumSum_Ref = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, j, "BLUE"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(j).opticalData.dSpectrumSum_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, j, "BLUE"))
        Next

        For j As Integer = 0 To sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(j).eletricalData.dRefVoltage = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, j, "BLACK"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(j).eletricalData.dRefCurrent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, j, "BLACK"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(j).eletricalData.dCurrent_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, j, "BLACK"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(j).opticalData.dRefLumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, j, "BLACK"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(j).opticalData.dLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, j, "BLACK"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(j).opticalData.dRefLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, j, "BLACK"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(j).opticalData.dRefSpectrum_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, j, "BLACK"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(j).opticalData.dRefud = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, j, "BLACK"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(j).opticalData.dRefvd = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, j, "BLACK"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(j).opticalData.dLumi_Cd_A_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, j, "BLACK"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(j).opticalData.dLumi_Cd_A_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, j, "BLACK"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(j).opticalData.dSpectrumSum_Ref = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, j, "BLACK"))
            fMain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(j).opticalData.dSpectrumSum_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, j, "BLACK"))
        Next
        '==================================================

        For n As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
            Select Case g_ConfigInfos.nDevice(n)

                Case frmConfigSystem.eDeviceItem.eSMU_M6000
                    Dim nDevNoOfM6000 As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                    Dim nChNoOfM6000 As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfM6000)
                    If fMain.cM6000 Is Nothing = False Then
                        Dim seqRoutineStateOfM600 As CSeqRoutineM6000.eSequenceState
                        seqRoutineStateOfM600 = CSeqRoutineM6000.ConvertStringSequenceStateToInteger(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.M6000SeqRoutine_Status))
                        If seqRoutineStateOfM600 = CSeqRoutineM6000.eSequenceState.eMeasuring Then
                            fMain.cM6000(nDevNoOfM6000).ChannelStatus(nChNoOfM6000) = seqRoutineStateOfM600
                        ElseIf seqRoutineStateOfM600 < 0 Then
                            fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Sub_routine_Status_Error) '  MsgBox("SubRoutine Status Error")
                            Return False
                        Else
                            fMain.cM6000(nDevNoOfM6000).ChannelStatus(nChNoOfM6000) = CSeqRoutineM6000.eSequenceState.eidle
                        End If
                    End If



                Case frmConfigSystem.eDeviceItem.eMcSG
                    Dim nGroupNoOfSG As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eGroupOfSG)
                    Dim nChNoOfSG As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSG)
                    If fMain.cMcSG Is Nothing = False Then

                        Dim lastStateOfSGRoutine As CSeqRoutineSG.eSequenceState

                        lastStateOfSGRoutine = CSeqRoutineSG.ConvertStringSequenceStateToInteger(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SGSeqRoutine_Status))

                        If lastStateOfSGRoutine < 0 Then '정보 자체가 잘못 저장 되었거나, 이전에 실행된 적이 없었던 상태

                            fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SG_MSG_Sub_routine_Status_Error)
                            Return False

                        ElseIf lastStateOfSGRoutine = CSeqRoutineSG.eSequenceState.eMeasuring Then  '측정이 진행중이었던 상태
                            Dim sgSet As CSeqRoutineSG.sSettingParam = Nothing

                            If CSeqRoutineSG.ConvertSGRecipeToSeqRoutineSettings(sequenceInfo.Current.sLifetimeInfo.sPanelInfos, sgSet) = False Then
                                fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SG_MSG_Wrong_Input_Signal)
                            End If

                            If fMain.cMcSG(nGroupNoOfSG).Request(nChNoOfSG, lastStateOfSGRoutine, sgSet) = False Then
                                fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SG_MSG_Wrong_Input_Signal)
                            End If

                        Else   '소스 셋팅 중이었거나, 소스 Off중인 상태 였으므로

                            fMain.cMcSG(nGroupNoOfSG).ChannelStatus(nChNoOfSG) = CSeqRoutineSG.eSequenceState.eidle

                        End If

                    End If
                Case frmConfigSystem.eDeviceItem.ePG

                Case frmConfigSystem.eDeviceItem.eTC

            End Select
        Next

        Return True
    End Function



#End Region


#Region "Support Functions"

    Public Shared Function ConvertScheduleStateStringToInt(ByVal sState As String) As Integer
        Dim rst As eChSchedulerSTATE
        Select Case sState
            Case eChSchedulerSTATE.eIdle.ToString
                rst = eChSchedulerSTATE.eIdle
            Case eChSchedulerSTATE.eRun.ToString
                rst = eChSchedulerSTATE.eRun
            Case eChSchedulerSTATE.eStop.ToString
                rst = eChSchedulerSTATE.eStop
            Case eChSchedulerSTATE.eChangeTemp_Set.ToString
                rst = eChSchedulerSTATE.eChangeTemp_Set
            Case eChSchedulerSTATE.eChangeTemp_WaitingTemp.ToString
                rst = eChSchedulerSTATE.eChangeTemp_WaitingTemp
            Case eChSchedulerSTATE.eChangeTemp_Stabilization.ToString
                rst = eChSchedulerSTATE.eChangeTemp_Stabilization
            Case eChSchedulerSTATE.eChangeNextSeq.ToString
                rst = eChSchedulerSTATE.eChangeNextSeq
            Case eChSchedulerSTATE.eLifeTime_SetSourcing.ToString
                rst = eChSchedulerSTATE.eLifeTime_SetSourcing
            Case eChSchedulerSTATE.eLifeTime_Running.ToString
                rst = eChSchedulerSTATE.eLifeTime_Running
            Case eChSchedulerSTATE.eLifeTime_StopSourcing.ToString
                rst = eChSchedulerSTATE.eLifeTime_StopSourcing
            Case eChSchedulerSTATE.eResetAllTime.ToString
                rst = eChSchedulerSTATE.eResetAllTime
            Case eChSchedulerSTATE.eResetModeTime.ToString
                rst = eChSchedulerSTATE.eResetModeTime
            Case eChSchedulerSTATE.eResetInterval.ToString
                rst = eChSchedulerSTATE.eResetInterval
            Case eChSchedulerSTATE.eFirstIVLSweepAfterLifetime.ToString
                rst = eChSchedulerSTATE.eFirstIVLSweepAfterLifetime
            Case Else
                rst = -1
        End Select
        Return rst
    End Function


    Public Shared Function GetStateCaptions(ByVal state As eChSchedulerSTATE) As String

        Dim sStatus() As String = New String() {"IDLE", "Test Run", "Test Stop", "Set Temp", "Wait Temp", _
                                       "Stabilization Temp", "Change Sequece", "Set Source", _
                                       "Lifetime Running", "Stop Source", "Pattern Measurement", "Reset Time", "Reset Mode Time", " Reset Interval", "Viewing Angle",
                                       "First IVL Sweep"}

        Return sCaptions_State(state)
    End Function

#End Region



End Class
