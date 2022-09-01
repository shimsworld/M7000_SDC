Imports System.Threading
Imports CSpectrometerLib

Public Class CSeqProcessor


#Region "Defines"

    Dim fMain As frmMain
    Dim cDataQE As CDataQECal = New CDataQECal


    Public Structure sProcessParams
        Dim index As Integer
        Dim cmd As eProcessState
        Dim sSampleInfos As ucSampleInfos.sSampleInfos
        Dim CommonInfo As ucSequenceBuilder.sRcpCommon
        Dim recipe As ucSequenceBuilder.sRecipeInfo
        Dim requestTime As Date
        Dim beforStateModeTime As TimeSpan
        Dim bLastPointSave As Boolean
        Dim bFirstSourcing As Boolean
        Dim sColor As String
    End Structure

    Public Enum eProcessState
        LifeTimeSet
        LifeTimeMeas
        LifeTimeStop
        ImageSweep
        GrayScaleSweep
        IVLSweep
        ModulePatternMeasure
        ViewingAngle
        LifetimeAndIVL
        LifeTimeMeas_Manual
    End Enum

#End Region

#Region "Creator and Disposer"


    Public Sub New(ByVal main As frmMain)
        fMain = main

    End Sub

    Public Sub Dispose()
        Finalize()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

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

    Public ReadOnly Property CheckProcess As Boolean
        Get
            Return check_Process
        End Get
    End Property
    Dim check_Process As Boolean = False

    Dim sDataTypeFolder() As String = New String() {"IVL Sweep\", "Lifetime\", "Viewing Angle\", "Lifetime_IVL\"}
    Private Sub ProcessLoop()

        ' Dim rcp As ucSequenceBuilder.sRecipeInfo = Nothing
        Dim procParam As sProcessParams = Nothing
        Dim check_MotionHome As Boolean = True
        'for timeout check
        'Dim sStartTime As Single
        'Dim sDeltaTime As Single
        Dim m_dTimeOut As Double = 10
        Dim Check_AutoMode As Boolean = False

        fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_THREAD_START, "Process Start")

        Do
            Application.DoEvents()
            Thread.Sleep(200)

            If bStopTrdProcess = True Then
                Exit Do
            End If

            SyncLock fMain.meas_queue.SyncRoot

                If fMain.g_EmergencyCtrl.getState = CV7000Emergency.eEMSTATe.eEMERGENCY Then  'Emergency Stop 상태 확인
                    fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_EMERGENCY_STOP)
                ElseIf fMain.g_EmergencyCtrl.getState = CV7000Emergency.eEMSTATe.eResetEM Then
                    fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_RELEASE_EMERGENCY)
                    '모션 초기화
                    'InitAxt()
                    'inixMotion()

                    'fMain.cMotion.SERVO_ON()

                    'Thread.Sleep(1000)
                    fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_HOMMING)

                    'Z축을 올리고 이동
                    fMain.frmMotionUI.ZMove(10, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
                    Application.DoEvents()
                    Thread.Sleep(1000)
                    fMain.frmMotionUI.MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eZ)

                    ' fMain.frmMotionUI.Homming()

                    'Homming을 진행하지 않고 0좌표로 이동한다.
                    'fMain.frmMotionUI.XMove(0, g_ConfigInfos.MotionConfig(0).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
                    'Application.DoEvents()
                    'Thread.Sleep(1000)

                    fMain.frmMotionUI.YMove(0, g_ConfigInfos.MotionConfig(1).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
                    Application.DoEvents()
                    Thread.Sleep(1000)
                    '   fMain.frmMotionUI.MoveCompletedAllAxis()

                    fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_HOMMING_END)

                    fMain.g_EmergencyCtrl.Reset()
                    'ElseIf fMain.cPLC.m_PLCDatas.nEQPState(0) = CDevPLCCommonNode.eEQPStatus.eStop Or fMain.cPLC.m_PLCDatas.nEQPState(0) = CDevPLCCommonNode.eEQPStatus.ePause Or fMain.cPLC.m_PLCDatas.nEQPState(0) = CDevPLCCommonNode.eEQPStatus.eReset Then
                    '    If fMain.cPLC Is Nothing = False Then
                    '        check_Process = False
                    '        '    If fMain.cPLCScheduler.g_ChSchedulerPLCStatus = CSheduler_PLC.eChSchedulerPLCSTATE.eProcess Then
                    '        '        If fMain.meas_queue.Count Then
                    '        '            procParam = fMain.meas_queue.Dequeue
                    '        '            check_Process = True

                    '        '        End If
                    '        '    End If
                    '        'Else
                    '        '    check_Process = True
                    '        '    If fMain.meas_queue.Count Then
                    '        '        procParam = fMain.meas_queue.Dequeue
                    '        '        check_Process = True

                    '        '    End If
                    '        'End If
                    '    End If
                    ' fMain.QueueCounter("Queue Counter = " & CStr(fMain.meas_queue.Count))              '명구
                Else

                    If fMain.g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.eNotUse Or fMain.g_PauseCtrl.GetHomeState = CPauseControl.ePAUSEHomming.eHome Then 'Pause 기능 사용중에는 큐의 데이터를 처리하지 않는다.

                        If fMain.cPLC Is Nothing = False Then
                            ' check_Process = True
                            '  If fMain.cPLCScheduler.g_ChSchedulerPLCStatus = CSheduler_PLC.eChSchedulerPLCSTATE.eProcess Then
                            If fMain.meas_queue.Count Then
                                procParam = fMain.meas_queue.Dequeue
                                check_Process = True

                                'End If
                            End If
                        Else
                            ' check_Process = True
                            If fMain.meas_queue.Count Then
                                procParam = fMain.meas_queue.Dequeue
                                check_Process = True

                            End If
                        End If

                        fMain.QueueCounter("Queue Counter = " & CStr(fMain.meas_queue.Count))
                    ElseIf fMain.g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.ePaused Then
                        If fMain.cPLC Is Nothing = False Then
                            ' check_Process = True
                            '  If fMain.cPLCScheduler.g_ChSchedulerPLCStatus = CSheduler_PLC.eChSchedulerPLCSTATE.eProcess Then

                            If fMain.meas_manualqueqe.Count Then
                                procParam = fMain.meas_manualqueqe.Dequeue
                                check_Process = True

                                'End If
                            End If
                        Else
                            ' check_Process = True
                            If fMain.meas_manualqueqe.Count Then
                                procParam = fMain.meas_manualqueqe.Dequeue
                                check_Process = True

                            End If
                        End If
                        fMain.ManualQueueCounter("M_Queue Counter = " & CStr(fMain.meas_manualqueqe.Count))
                    End If

                End If


            End SyncLock
            ' check_Process = False
            If check_Process Then
                check_MotionHome = False
                ' updateDispChannel(index, rcp)


                Select Case procParam.cmd

                    'Case eProcessState.TempSet

                    '    Dim nGroup As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eGroupOfTC)
                    '    Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfTC)
                    '    Dim nChNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfTC)

                    '    fMain.ctc(nGroup).SetTemp(nDevNo, nChNo, procParam.recipe.sChangeTemp.dTargetTemp)

                    Case eProcessState.LifeTimeSet

                        If procParam.recipe.sLifetimeInfo.nMyMode = ucSequenceBuilder.eRcpMode.eModule_Lifetime Then
                            If g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._G4S Then

                                If procParam.recipe.sLifetimeInfo.sModuleInfos.sImageInfos.bEnableModelDownload = True Then
                                    Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
                                    'If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
                                    Dim devStatus As CDevPGCommonNode.eSequenceState
                                    fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).Information = "Model Down."
                                    If nDevNo <> -1 Then
                                        fMain.cPG.PatternGenerator(0).Request(nDevNo, CDevG4S.eSequenceState.eGnT_Update_DriveData_All, procParam.recipe.sLifetimeInfo.sModuleInfos.sImageInfos.modelName)

                                        Do
                                            Thread.Sleep(100)
                                            Application.DoEvents()
                                            devStatus = fMain.cPG.PatternGenerator(0).BeforStatus(nDevNo)
                                        Loop Until devStatus = CDevPGCommonNode.eSequenceState.eGnT_Update_DriveData_OK Or devStatus = CDevPGCommonNode.eSequenceState.eGnT_Update_DriveData_Faild

                                        If devStatus = CDevPGCommonNode.eSequenceState.eGnT_Update_DriveData_Faild Then
                                            fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).Information = "Failed"
                                            fMain.frmMonitorUI.Message(procParam.index) = "Model Download Failed"
                                            fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) = CScheduler.eChSchedulerSTATE.eStop
                                            Exit Select
                                        Else
                                            fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).Information = "Download OK"
                                            Application.DoEvents()
                                            Thread.Sleep(1000)
                                        End If

                                    End If

                                End If

                            End If
                        End If


                        If g_SystemInfo.bCompleted_ACF_CH(procParam.index) = False Then
                            Application.DoEvents()
                            Thread.Sleep(500)
                            'If fMain.frmMotionUI.RunACF(procParam.index, fMain.g_SystemOptions.sOptionData.ACFData.dIntensityAdj_Bias, fMain.g_SystemOptions.sOptionData.ACFData.nACFMode) = False Then
                            Dim ACFOptions As frmOptionWindow.sACF = g_SystemOptions.sOptionData.ACFData

                            ACFOptions.nModulePatternNo = procParam.recipe.sLifetimeInfo.sModuleInfos.sImageInfos.nACFImageIdx

                            If fMain.frmMotionUI.RunACF(procParam.index,
                                                        ACFOptions, procParam.CommonInfo.nACFMode,
                                                        procParam.sSampleInfos.sampleType,
                                                        procParam.CommonInfo.saveInfo, procParam.recipe.nMode, False) = False Then
                                fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) = CScheduler.eChSchedulerSTATE.eStop
                                Exit Select
                            End If
                            g_SystemInfo.bCompleted_ACF_CH(procParam.index) = True
                        End If

                        Select Case procParam.recipe.sLifetimeInfo.nMyMode

                            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL

                                Dim nDevNoOfSwitch As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
                                Dim nChNoOfSwitch As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfSwitch)
                                Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                                Dim nChNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfM6000)

                                'LT내부에서 진행하므로 필요없음
                                'If fMain.cSwitch Is Nothing = False Then
                                '    If nDevNoOfSwitch >= 0 And nChNoOfSwitch >= 0 Then
                                '        If fMain.cSwitch(nDevNoOfSwitch).mySwitch.SwitchOFF(nChNoOfSwitch) = False Then
                                '            '예외처리

                                '        End If
                                '    End If
                                'End If
                                'If fMain.cSwitch(nDevNoOfSwitch).mySwitch.SwitchON(nChNoOfSwitch) = False Then

                                'End If

                                If procParam.recipe.sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation Then
                                    If fMain.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
                                        fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellColor_ON = Color.White
                                        fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellStatus = ucDispSampleCommonNode.eCellState.eON
                                    End If

                                    'Bias Setting
                                    ' SetSourceOfM6000(nDevNo, nChNo, CSeqRoutineM6000.eSequenceState.eSetSource, procParam.recipe.sLifetimeInfo.sCellInfos(0), procParam.CommonInfo.sLimits)
                                    '데이터 측정 상태 확인
                                    ' CompletedSettingsOfM6000(nDevNo, nChNo, 10, CSeqRoutineM6000.eSequenceState.eMeasuring)
                                    'source Setting과 데이터 저장을 분리하였던, Setting과 데이터 저장 사이에 다른 채널의 명령에 의한 처리 대기에 영향을 제거하기 위해서
                                    ReDim fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(procParam.recipe.sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)
                                    ReDim fMain.g_MeasuredDatas(procParam.index).sCellLTParams.RedLTData(procParam.recipe.sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)
                                    ReDim fMain.g_MeasuredDatas(procParam.index).sCellLTParams.GreenLTData(procParam.recipe.sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)
                                    ReDim fMain.g_MeasuredDatas(procParam.index).sCellLTParams.BlueLTData(procParam.recipe.sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)
                                    ReDim fMain.g_MeasuredDatas(procParam.index).sCellLTParams.BlackLTData(procParam.recipe.sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)

                                    For i As Integer = 0 To procParam.recipe.sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                                        LifetimeMeasurement(procParam, i, True)
                                    Next

                                Else
                                    '예외처리 추가
                                    'fMain.cTimeScheduler.g_ChSchedulerStauts(procParam.index) = CScheduler.eChSchedulerSTATE.eLifeTime_Running
                                    '  fMain.SequenceList(procParam.index).RequestTest = False
                                End If
                            Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime


                                Dim settings As CDevM6000PLUS.sSettingParams = Nothing
                                Dim nGroup As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eGroupOfSG)
                                Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfSG)
                                Dim nChNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfSG)

                                If procParam.recipe.sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation Then
                                    Dim setting As ucDispSignalGenerator.sSGDatas
                                    Dim sgSet As CSeqRoutineSG.sSettingParam = Nothing

                                    Dim nCntMainPwr As Integer = Nothing
                                    Dim nCntSubPwr As Integer = Nothing
                                    Dim nCntSignal As Integer = Nothing

                                    Dim mainPwr() As CDevSG.sSettingParam = Nothing
                                    Dim subPwr() As CDevSG.sSettingParam = Nothing
                                    Dim signal() As CDevSG.sSettingParam = Nothing
                                    Dim mainPwrLimit() As CDevSG.sLimit = Nothing

                                    setting = procParam.recipe.sLifetimeInfo.sPanelInfos 'UcDispSignalGenerator1.Settings

                                    'Step1. Panel Source Settings
                                    For i As Integer = 0 To setting.nLenSignal - 1
                                        If setting.sParamData(i).eSignal = ucDispSignalGenerator.ePGSignal.MainPower1 Then
                                            ReDim Preserve mainPwr(nCntMainPwr)
                                            ReDim Preserve mainPwrLimit(nCntMainPwr)
                                            mainPwr(nCntMainPwr).Mode = setting.sParamData(i).eSrcMode
                                            If mainPwr(nCntMainPwr).Mode = CDevSG.eDacMode.eDCMode Then
                                                mainPwr(nCntMainPwr).DCOutputCh = CDevSG.eFoutput.eHigh
                                            End If
                                            mainPwr(nCntMainPwr).dBias = setting.sParamData(i).dBias
                                            mainPwr(nCntMainPwr).dAmplitude = setting.sParamData(i).dAmplitude
                                            mainPwr(nCntMainPwr).PulseParam = setting.sParamData(i).sPulse

                                            mainPwrLimit(nCntMainPwr) = setting.sParamData(i).sLimit

                                            nCntMainPwr += 1
                                        ElseIf setting.sParamData(i).eSignal = ucDispSignalGenerator.ePGSignal.MainPower2 Then
                                            ReDim Preserve mainPwr(nCntMainPwr)
                                            ReDim Preserve mainPwrLimit(nCntMainPwr)
                                            mainPwr(nCntMainPwr).Mode = setting.sParamData(i).eSrcMode
                                            If mainPwr(nCntMainPwr).Mode = CDevSG.eDacMode.eDCMode Then
                                                mainPwr(nCntMainPwr).DCOutputCh = CDevSG.eFoutput.eHigh
                                            End If
                                            mainPwr(nCntMainPwr).dBias = setting.sParamData(i).dBias
                                            mainPwr(nCntMainPwr).dAmplitude = setting.sParamData(i).dAmplitude
                                            mainPwr(nCntMainPwr).PulseParam = setting.sParamData(i).sPulse

                                            mainPwrLimit(nCntMainPwr) = setting.sParamData(i).sLimit

                                            nCntMainPwr += 1
                                        ElseIf setting.sParamData(i).eSignal >= ucDispSignalGenerator.ePGSignal.SubPower1 And setting.sParamData(i).eSignal <= ucDispSignalGenerator.ePGSignal.SubPower12 Then
                                            ReDim Preserve subPwr(nCntSubPwr)

                                            subPwr(nCntSubPwr).nIdx = Math.Abs(setting.sParamData(i).eSignal - ucDispSignalGenerator.ePGSignal.SubPower1)
                                            subPwr(nCntSubPwr).Mode = setting.sParamData(i).eSrcMode
                                            If subPwr(nCntSubPwr).Mode = CDevSG.eDacMode.eDCMode Then
                                                subPwr(nCntSubPwr).DCOutputCh = CDevSG.eFoutput.eHigh
                                            End If
                                            subPwr(nCntSubPwr).dBias = setting.sParamData(i).dBias
                                            subPwr(nCntSubPwr).dAmplitude = setting.sParamData(i).dAmplitude
                                            subPwr(nCntSubPwr).PulseParam = setting.sParamData(i).sPulse
                                            nCntSubPwr += 1
                                        Else
                                            ReDim Preserve signal(nCntSignal)
                                            signal(nCntSignal).nIdx = Math.Abs(setting.sParamData(i).eSignal - ucDispSignalGenerator.ePGSignal.Signal1)
                                            signal(nCntSignal).Mode = setting.sParamData(i).eSrcMode
                                            If signal(nCntSignal).Mode = CDevSG.eDacMode.eDCMode Then
                                                signal(nCntSignal).DCOutputCh = CDevSG.eFoutput.eHigh
                                            End If
                                            signal(nCntSignal).dBias = setting.sParamData(i).dBias
                                            signal(nCntSignal).dAmplitude = setting.sParamData(i).dAmplitude
                                            signal(nCntSignal).PulseParam = setting.sParamData(i).sPulse
                                            nCntSignal += 1
                                        End If

                                    Next

                                    sgSet.MainPower = mainPwr.Clone
                                    sgSet.SubPower = subPwr.Clone
                                    sgSet.Signal = signal.Clone
                                    sgSet.MainPowerLimit = mainPwrLimit.Clone


                                    If fMain.cMcSG(nGroup).Request(nDevNo, nChNo, CSeqRoutineSG.eSequenceState.eSetSource, sgSet) = False Then
                                        MsgBox("잘못된 입력 입니다.")
                                    End If


                                End If

                            Case ucSequenceBuilder.eRcpMode.eModule_Lifetime

                                Dim settings As frmPatternGeneratorSetting.sPGInfos = procParam.recipe.sLifetimeInfo.sModuleInfos ' UcDispModule1.Settings
                                Dim nCh As Integer = procParam.index

                                If fMain.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
                                    fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellColor_ON = Color.White
                                    fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellStatus = ucDispSampleCommonNode.eCellState.eON
                                    fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).Information = "Align"
                                End If

                                Select Case g_ConfigInfos.PGConfig.nDeviceType

                                    Case CDevPGCommonNode.eDevModel._G4S

                                        Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)

                                        If nDevNo <> -1 Then
                                            fMain.cPG.PatternGenerator(0).Request(nDevNo, CDevPGCommonNode.eSequenceState.eON)

                                            Do
                                                Thread.Sleep(100)
                                                Application.DoEvents()
                                            Loop Until fMain.cPG.PatternGenerator(0).ChannelStatus(nDevNo) = CDevPGCommonNode.eSequenceState.eMeasuring
                                        End If

                                    Case CDevPGCommonNode.eDevModel._McPG
                                        Dim SeqSettings As CSeqRoutineMcPG.sSettingParam

                                        'Dim nGroup As Integer = frmChAllocation.GetAllocationValue(procParam.index, frmChAllocation.eChAllocationItem.eGroupOfpg)
                                        SeqSettings.sPGSettings = settings

                                        'Lex _ I must modify information the channel assign 
                                        If fMain.cPG.PatternGenerator(0).Request(nCh, CSeqRoutineMcPG.eSequenceState.eON, SeqSettings) = False Then

                                        End If

                                End Select

                                For j As Integer = 0 To procParam.recipe.sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                                    LifetimeMeasurement(procParam, j)
                                Next


                        End Select


                    Case eProcessState.LifeTimeMeas '저장 
                        Dim sMsg As String = Nothing

                        '1. Lifetime Meas.
                        For i As Integer = 0 To procParam.recipe.sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                            If LifetimeMeasurement(procParam, i, False, sMsg) = True Then   'LifetimeAndIVL 실험에서 Lifetime 실험이 종료 조건에 만족하면 True 넘겨 받아서 IVL Sweep 측정후 다음 recipe 변경

                                Application.DoEvents()    'Recipe 종료 조건을 만족하면 스케쥴러 상태가 변경 되는데 상태 변경 전에 체크 될 수 있어서 딜레이 추가.
                                Thread.Sleep(1000)

                                If fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) = CScheduler.eChSchedulerSTATE.eLifeTime_Running Then
                                    fMain.SequenceList(procParam.index).RequestIVLSweep = True
                                    Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                                    Dim nChNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfM6000)

                                    'Lifetime Source Off
                                    'If fMain.cM6000(nDevNo).Request(nChNo, CSeqRoutineM6000.eSequenceState.eReset) = True Then
                                    '    CompletedSettingsOfM6000(nDevNo, nChNo, 10, CSeqRoutineM6000.eSequenceState.eidle)
                                    'Else
                                    '    fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) = CScheduler.eChSchedulerSTATE.eIdle
                                    '    fMain.SequenceList(procParam.index).RequestIVLSweep = False
                                    '    fMain.SequenceList(procParam.index).RequestTest = False
                                    '    '예외처리
                                    'End If

                                    '3. IVL Sweep
                                    fMain.g_SweepStop(procParam.index) = False
                                    ' IVLSweepRoutine(procParam, fMain.frmIVLDispWind, g_SystemOptions.sOptionData.Spectrometer.nAperture, g_SystemOptions.sOptionData.Spectrometer.nSpeedMode)

                                    '4. Recipe Change
                                    '  If fMain.SequenceList(procParam.index).IVLSweepMeasCount >= fMain.SequenceList(procParam.index).Current.sLifetimeInfo.sCommon.sIVLSweepMeas.Length Then
                                    'f fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) <> CScheduler.eChSchedulerSTATE.eIdle Then
                                    'fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) = CScheduler.eChSchedulerSTATE.eChangeNextSeq
                                    '  End If

                                    'Else
                                    'Lifetime Source On
                                    If fMain.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
                                        fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellColor_ON = Color.White
                                        fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellStatus = ucDispSampleCommonNode.eCellState.eON
                                    End If

                                    'Bias Setting
                                    ' SetSourceOfM6000(nDevNo, nChNo, CSeqRoutineM6000.eSequenceState.eSetSource, procParam.recipe.sLifetimeInfo.sCellInfos(0), procParam.CommonInfo.sLimits)
                                    '데이터 측정 상태 확인
                                    ' CompletedSettingsOfM6000(nDevNo, nChNo, 10, CSeqRoutineM6000.eSequenceState.eMeasuring)
                                    'source Setting과 데이터 저장을 분리하였던, Setting과 데이터 저장 사이에 다른 채널의 명령에 의한 처리 대기에 영향을 제거하기 위해서
                                    ' LifetimeMeasurement(procParam)
                                    '  End If

                                    fMain.SequenceList(procParam.index).RequestIVLSweep = False
                                    fMain.SequenceList(procParam.index).RequestTest = False
                                    fMain.SequenceList(procParam.index).RequestLifetimeAndIVL = False
                                    '  fMain.frmMonitorUI.Message(procParam.index) = sMsg
                                End If
                            End If
                        Next





                        'If fMain.SequenceList(procParam.index).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then
                        '    '2. Recipe 종료 조건 체크
                        '    If IsCheckedEndConditions(procParam, fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData, fMain.SequenceList(procParam.index).Current.sLifetimeInfo.sCommon.sLifetimeEnd) = True Then

                        '        fMain.SequenceList(procParam.index).RequestIVLSweep = True

                        '        Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                        '        Dim nChNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfM6000)

                        '        'Lifetime Source Off
                        '        If fMain.cM6000(nDevNo).Request(nChNo, CSeqRoutineM6000.eSequenceState.eReset) = True Then
                        '            CompletedSettingsOfM6000(nDevNo, nChNo, 10, CSeqRoutineM6000.eSequenceState.eidle)
                        '        Else
                        '            fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) = CScheduler.eChSchedulerSTATE.eIdle
                        '            fMain.SequenceList(procParam.index).RequestIVLSweep = False
                        '            fMain.SequenceList(procParam.index).RequestTest = False
                        '            '예외처리
                        '        End If

                        '        '3. IVL Sweep
                        '        fMain.g_SweepStop(procParam.index) = False
                        '        IVLSweepRoutine(procParam, fMain.frmIVLDispWind)

                        '        '4. Recipe Change
                        '        If fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) <> CScheduler.eChSchedulerSTATE.eIdle Then
                        '            fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) = CScheduler.eChSchedulerSTATE.eChangeNextSeq
                        '        End If

                        '        fMain.SequenceList(procParam.index).RequestIVLSweep = False
                        '        fMain.SequenceList(procParam.index).RequestTest = False
                        '    End If
                        'End If
                    Case eProcessState.LifeTimeMeas_Manual  '저장 
                        Dim sMsg As String = Nothing

                        '1. Lifetime Meas.
                        For i As Integer = 0 To procParam.recipe.sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                            Dim sJIGName As String = Nothing

                            If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                                sJIGName = CStr(Format(procParam.index + 1, "00"))
                            ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                                sJIGName = ucDispJIG.convertIncNumberToMatrixValue(procParam.index)
                            End If
                            Dim sCaptionAndTEGNumber As String = "PANEL" & Format(procParam.index + 1, "00") 'ucDispJIG.convertIncNumberToMatrixValue(m_nCh)

                            If procParam.sColor = "RED" Then
                                Dim nCount As Integer = fMain.g_DataSaver(procParam.index).RedSavedDataCounter(i)
                                If nCount = 0 Then
                                    fMain.g_DataSaver(procParam.index).SaveHeaderInfoOfCellLifetime_RGB(procParam.index, fMain.SequenceList(procParam.index).SequenceInfo.sCommon.saveInfo.strFPath & sCaptionAndTEGNumber & "_" & fMain.SequenceList(procParam.index).SequenceInfo.sCommon.saveInfo.strOnlyFName & "_" & "RED" & "_P" & i + 1 & "_" & fMain.SequenceList(procParam.index).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(i).X & "_" & fMain.SequenceList(procParam.index).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(i).Y & ".csv", fMain.SequenceList(procParam.index).Current.sLifetimeInfo, i)
                                    procParam.bFirstSourcing = True
                                Else
                                    procParam.bFirstSourcing = False
                                End If

                            ElseIf procParam.sColor = "GREEN" Then
                                Dim nCount As Integer = fMain.g_DataSaver(procParam.index).GreenSavedDataCounter(i)
                                If nCount = 0 Then
                                    fMain.g_DataSaver(procParam.index).SaveHeaderInfoOfCellLifetime_RGB(procParam.index, fMain.SequenceList(procParam.index).SequenceInfo.sCommon.saveInfo.strFPath & sCaptionAndTEGNumber & "_" & fMain.SequenceList(procParam.index).SequenceInfo.sCommon.saveInfo.strOnlyFName & "_" & "GREEN" & "_P" & i + 1 & "_" & fMain.SequenceList(procParam.index).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(i).X & "_" & fMain.SequenceList(procParam.index).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(i).Y & ".csv", fMain.SequenceList(procParam.index).Current.sLifetimeInfo, i)
                                    procParam.bFirstSourcing = True
                                Else
                                    procParam.bFirstSourcing = False
                                End If

                            ElseIf procParam.sColor = "BLUE" Then
                                Dim nCount As Integer = fMain.g_DataSaver(procParam.index).BlueSavedDataCounter(i)
                                If nCount = 0 Then
                                    fMain.g_DataSaver(procParam.index).SaveHeaderInfoOfCellLifetime_RGB(procParam.index, fMain.SequenceList(procParam.index).SequenceInfo.sCommon.saveInfo.strFPath & sCaptionAndTEGNumber & "_" & fMain.SequenceList(procParam.index).SequenceInfo.sCommon.saveInfo.strOnlyFName & "_" & "BLUE" & "_P" & i + 1 & "_" & fMain.SequenceList(procParam.index).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(i).X & "_" & fMain.SequenceList(procParam.index).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(i).Y & ".csv", fMain.SequenceList(procParam.index).Current.sLifetimeInfo, i)
                                    procParam.bFirstSourcing = True
                                Else
                                    procParam.bFirstSourcing = False
                                End If


                            ElseIf procParam.sColor = "BLACK" Then
                                Dim nCount As Integer = fMain.g_DataSaver(procParam.index).BlackSavedDataCounter(i)
                                If nCount = 0 Then
                                    fMain.g_DataSaver(procParam.index).SaveHeaderInfoOfCellLifetime_RGB(procParam.index, fMain.SequenceList(procParam.index).SequenceInfo.sCommon.saveInfo.strFPath & sCaptionAndTEGNumber & "_" & fMain.SequenceList(procParam.index).SequenceInfo.sCommon.saveInfo.strOnlyFName & "_" & "BLACK" & "_P" & i + 1 & "_" & fMain.SequenceList(procParam.index).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(i).X & "_" & fMain.SequenceList(procParam.index).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(i).Y & ".csv", fMain.SequenceList(procParam.index).Current.sLifetimeInfo, i)
                                    procParam.bFirstSourcing = True
                                Else
                                    procParam.bFirstSourcing = False
                                End If

                            End If
                           
                            If LifetimeMeasurement(procParam.sColor, procParam.index, i, procParam.bFirstSourcing) = True Then '(procParam, i, False, sMsg) = True Then   'LifetimeAndIVL 실험에서 Lifetime 실험이 종료 조건에 만족하면 True 넘겨 받아서 IVL Sweep 측정후 다음 recipe 변경

                               
                            End If
                        Next


                    Case eProcessState.LifeTimeStop

                        Select Case procParam.recipe.nMode

                            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL


                                Dim nDevNoOfSwitch As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
                                Dim nChNoOfSwitch As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfSwitch)

                                Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                                Dim nChNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfM6000)

                                If fMain.cSwitch Is Nothing = False Then
                                    If nDevNoOfSwitch >= 0 And nChNoOfSwitch >= 0 Then
                                        If fMain.cSwitch(nDevNoOfSwitch).mySwitch.SwitchOFF(nChNoOfSwitch) = False Then
                                            '예외처리
                                        End If

                                       
                                    End If
                                End If

                                'If fMain.cM6000(nDevNo).Request(nChNo, CSeqRoutineM6000.eSequenceState.eReset) = False Then

                                'End If

                            Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                                Dim nGroup As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eGroupOfSG)
                                Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfSG)
                                Dim nChNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfSG)
                                If fMain.cMcSG(nGroup).Request(nDevNo, nChNo, CSeqRoutineSG.eSequenceState.eReset) = False Then
                                    'LEX 예외 처리 필요

                                End If


                            Case ucSequenceBuilder.eRcpMode.eModule_Lifetime

                                Select Case g_ConfigInfos.PGConfig.nDeviceType

                                    Case CDevPGCommonNode.eDevModel._G4S
                                        Dim nCh As Integer = procParam.index
                                        Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)

                                        If nDevNo <> -1 Then
                                            fMain.cPG.PatternGenerator(0).Request(nDevNo, CDevPGCommonNode.eSequenceState.eReset)
                                            Do
                                                Thread.Sleep(100)
                                                Application.DoEvents()
                                            Loop Until fMain.cPG.PatternGenerator(0).ChannelStatus(nDevNo) = CDevPGCommonNode.eSequenceState.eidle
                                        End If


                                    Case CDevPGCommonNode.eDevModel._McPG

                                        Dim nCh As Integer = procParam.index
                                        'Lex _ I must modify information the channel assign 
                                        If fMain.cPG.PatternGenerator(0).Request(nCh, CSeqRoutineMcPG.eSequenceState.eReset) = False Then
                                            'LEX 예외처리 필요
                                        End If

                                End Select


                            Case ucSequenceBuilder.eRcpMode.eChangeTemperature
                                For j As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
                                    Select Case g_ConfigInfos.nDevice(j)
                                        Case frmConfigSystem.eDeviceItem.eSMU_M6000
                                            Dim nDevNoOfSwitch As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
                                            Dim nChNoOfSwitch As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfSwitch)
                                            Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                                            Dim nChNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfM6000)

                                            If fMain.cSwitch Is Nothing = False Then
                                                If nDevNoOfSwitch >= 0 And nChNoOfSwitch >= 0 Then
                                                    If fMain.cSwitch(nDevNoOfSwitch).mySwitch.SwitchOFF(nChNoOfSwitch) = False Then
                                                        '예외처리
                                                    End If

                                                    Application.DoEvents()
                                                    Thread.Sleep(1000)

                                                    If fMain.cSwitch(nDevNoOfSwitch).mySwitch.SwitchOFF(nChNoOfSwitch + 12) = False Then
                                                        '예외처리
                                                    End If
                                                End If
                                            End If


                                            'If fMain.cM6000(nDevNo).Request(nChNo, CSeqRoutineM6000.eSequenceState.eReset) = False Then

                                            'End If

                                            Exit For
                                        Case frmConfigSystem.eDeviceItem.eMcSG

                                        Case frmConfigSystem.eDeviceItem.ePG

                                    End Select

                                Next


                        End Select

                        If fMain.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
                            fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellColor_OFF = Color.Black
                            fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellStatus = ucDispSampleCommonNode.eCellState.eOFF
                            fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).Information = "Stop"
                        End If

                    Case eProcessState.ModulePatternMeasure
                        'Begine Module Pattern Measure ===============================================================
                        '1 PG Source Setting
                        Dim settings As frmPatternGeneratorSetting.sPGInfos = procParam.recipe.sPatternMeasure.sModuleInfos ' UcDispModule1.Settings
                        Dim SeqSettings As CSeqRoutineMcPG.sSettingParam
                        Dim nCh As Integer = procParam.index
                        Dim measuredData As CDevPGCommonNode.sMeasuredDatas = Nothing ' CSeqRoutineMcPG.sMeasuredData = Nothing
                        Dim nTimeOutCnt As Integer = 0
                        Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)

                        If nDevNo <> -1 Then
                            '2. Waiting until source setting
                            Do
                                Thread.Sleep(100)
                                Application.DoEvents()
                            Loop Until fMain.cPG.PatternGenerator(0).ChannelStatus(nDevNo) = CSeqRoutineMcPG.eSequenceState.eidle

                            SeqSettings.sPGSettings = settings

                            'Lex _ I must modify information the channel assign 
                            If fMain.cPG.PatternGenerator(0).Request(nDevNo, CSeqRoutineMcPG.eSequenceState.eON, SeqSettings) = False Then

                            End If



                            '2. Waiting until source setting
                            Do
                                Thread.Sleep(100)
                                Application.DoEvents()
                            Loop Until fMain.cPG.PatternGenerator(0).ChannelStatus(nDevNo) = CSeqRoutineMcPG.eSequenceState.eMeasuring

                            'Lex _ I must modify information the channel assign
                            '3. Get Measurement Data form Signal Generator
                            measuredData = fMain.cPG.PatternGenerator(0).MeasuredData(nDevNo)

                            fMain.g_MeasuredDatas(procParam.index).sModuleLTParams.sMeasuredValues(0) = measuredData ' measuredData.sMcPG
                        End If


                        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        '4. Measurement PR730(Multi-Point Measurement)   'LEX
                        ReDim fMain.g_MeasuredDatas(procParam.index).sSpectrometer(procParam.recipe.sPatternMeasure.sMeasPoints.MeasPoint.Length - 1)
                        For i As Integer = 0 To procParam.recipe.sPatternMeasure.sMeasPoints.MeasPoint.Length - 1
                            'Move Motion Position
                            fMain.frmMotionUI.Move_SetPos(procParam.index, frmMotionUI.eMotionMode.eSpectrometer,
                                                          procParam.recipe.sPatternMeasure.sMeasPoints.MeasPoint(i).X + procParam.recipe.sPatternMeasure.sMeasPoints.marginFromAlignMark.X,
                                                          procParam.recipe.sPatternMeasure.sMeasPoints.MeasPoint(i).Y + procParam.recipe.sPatternMeasure.sMeasPoints.marginFromAlignMark.Y)


                            'Measurement Data of PR730
                            Dim measData As CDevSpectrometerCommonNode.tData = Nothing

                            MeasureSpectrometer(procParam.index, measData)

                            'nTimeOutCnt = 0
                            'Do
                            '    If nTimeOutCnt > 5 Then
                            '        fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_COMMON_MSG_Retry_TimeOut_Cnt)
                            '        'frmIVLDisplayWind.IsStopIVL = True
                            '        Exit Do
                            '    End If

                            '    If fMain.cSpectormeter(0).mySpectrometer.Measure(measData) = True Then
                            '        Exit Do
                            '    End If
                            '    nTimeOutCnt += 1
                            'Loop


                            'nTimeOutCnt = 0
                            'Do
                            '    If nTimeOutCnt > 5 Then
                            '        fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_COMMON_MSG_Retry_TimeOut_Cnt)
                            '        'frmIVLDisplayWind.IsStopIVL = True
                            '        Exit Do
                            '    End If

                            '    If fMain.cSpectormeter(0).mySpectrometer.DownloadData(measData) = True Then
                            '        Exit Do
                            '    End If
                            '    nTimeOutCnt += 1
                            'Loop

                            fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sSpectrometer(i) = measData

                        Next

                        '5. Module Sourcing Off
                        If fMain.cPG.PatternGenerator(0).Request(nCh, CSeqRoutineMcPG.eSequenceState.eReset) = False Then
                            'LEX 예외처리 필요
                        End If

                        '7. Output Data
                        fMain.g_DataSaver(nCh).SaveDataPointImageSticking(procParam.recipe.recipeIndex,
                                                                        fMain.g_MeasuredDatas(procParam.index).sModuleLTParams.sMeasuredValues(0).sMcPG,
                                                                        fMain.g_MeasuredDatas(procParam.index).sSpectrometer)

                        fMain.g_DataSaver(nCh).SaveLTSpectrumDataPoint(procParam.recipe.recipeIndex, _
                                                                       fMain.g_MeasuredDatas(procParam.index).sSpectrometer, _
                                                                       fMain.g_MeasuredDatas(procParam.index).sPanelLTParams.dLumi_Percent)

                        '2. Waiting until source setting
                        Do
                            Thread.Sleep(100)
                            Application.DoEvents()
                        Loop Until fMain.cPG.PatternGenerator(0).ChannelStatus(nCh) = CSeqRoutineMcPG.eSequenceState.eidle


                        '8. Reciep Change
                        fMain.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eChangeNextSeq

                        fMain.SequenceList(procParam.index).RequestTest = False


                        'End Module Pattern Measure ===============================================================
                    Case eProcessState.IVLSweep

                        Dim dACFBias As Double
                        Dim sResult As String = Nothing

                        If procParam.recipe.sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
                            If g_SystemInfo.bCompleted_ACF_CH(procParam.index) = False Then
                                If fMain.frmMotionUI.RunACF(procParam.index,
                                                            g_SystemOptions.sOptionData.ACFData, procParam.CommonInfo.nACFMode,
                                                            procParam.sSampleInfos.sampleType,
                                                            procParam.CommonInfo.saveInfo, procParam.recipe.nMode, False, dACFBias) = False Then

                                    'VCR 측정
                                    '   If fMain.frmMotionUI.RunMCR(procParam.index, sResult) = False Then
                                    'fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) = CScheduler.eChSchedulerSTATE.eStop
                                    '  Exit Select
                                    '  Else
                                    '   fMain.MCR_SEND(procParam.index, sResult)
                                    ' End If

                                    fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) = CScheduler.eChSchedulerSTATE.eStop
                                    Exit Select
                                Else
                                    'If g_SystemOptions.sOptionData.ACFData.bLMeasLevelUse = True Then
                                    '    procParam.recipe.sIVLSweepInfo.sCommon.dLMeasLevel = dACFBias
                                    'End If

                                End If
                                g_SystemInfo.bCompleted_ACF_CH(procParam.index) = True

                            End If
                        End If

                        '   g_SystemInfo.bCompleted_ACF_CH(procParam.index) = True
                        '===========================================================================

                        ' IVLSweepRoutine(procParam, fMain.frmIVLDispWind)

                        ' fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.est, "")

                        If procParam.recipe.sIVLSweepInfo.sCommon.bFirstSweep = True Then
                            IVLSweepRoutine(procParam, fMain.frmIVLDispWind, g_SystemOptions.sOptionData.Spectrometer.nAperture, g_SystemOptions.sOptionData.Spectrometer.nSpeedMode)
                        Else
                            IVLSweepRoutine(procParam, fMain.frmIVLDispWind, g_SystemOptions.sOptionData.IVLSpectrometer.nAperture, g_SystemOptions.sOptionData.IVLSpectrometer.nSpeedMode)
                        End If
                        '  fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMsg_State_Log_Meas_State_Text, CStateMsg.eStateMsg.eIVL_SWEEP_END, "")


                        If fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) <> CScheduler.eChSchedulerSTATE.eIdle And fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) <> CScheduler.eChSchedulerSTATE.eStop Then
                            If procParam.recipe.sIVLSweepInfo.sCommon.bFirstSweep = True And fMain.SequenceList(procParam.index).LoopCount = 0 Then
                                fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) = CScheduler.eChSchedulerSTATE.eLifeTime_SetSourcing
                            Else
                                fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) = CScheduler.eChSchedulerSTATE.eChangeNextSeq
                            End If
                        End If

                        '8. Reciep Change
                        fMain.SequenceList(procParam.index).RequestTest = False

                    Case eProcessState.ViewingAngle

                        'IVLSweepRoutine(procParam, fMain.frmIVLDispWind)
                        AngleSweepRoutine(procParam, fMain.frmIVLDispWind)

                        If fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) <> CScheduler.eChSchedulerSTATE.eIdle Then
                            fMain.cTimeScheduler.g_ChSchedulerStatus(procParam.index) = CScheduler.eChSchedulerSTATE.eChangeNextSeq
                        End If

                        '8. Reciep Change
                        fMain.SequenceList(procParam.index).RequestTest = False

                End Select

                '라이프 타임 동작마다 상태 저장. 2013-03-21 승현
                'If fMain.SaveChannelLastStatusInfo(procParam.index + 1) = False Then Exit Sub '유저가 보기에는  채널 시작번지가 1 임으로 +1


                check_Process = False

            Else  'Pause와 EQP STOP일때만 진행한다.
                If fMain.g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.eRequest Then
                    fMain.g_PauseCtrl.paused()
                    fMain.tsBtnTestPauseText("Reset Pause")
                    'fMain.EnableTsBtnTestPause(True)
                    fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_PAUSED)
                End If


                'If fMain.g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.ePaused Then
                '    For i As Integer = 0 To fMain.cPLC.Datas.nSystemStatus.Length - 1
                '        If fMain.cPLC.Datas.nSystemStatus(i) = CDevPLCCommonNode.eSystemStatus.eAuto_Mode Then
                '            Check_AutoMode = True
                '            Exit For
                '        Else
                '            Check_AutoMode = False
                '        End If
                '    Next

                '    If Check_AutoMode = True Then
                '        If fMain.g_PauseCtrl.getEQPState = CPauseControl.eEQPState.eStop Then

                '            fMain.frmMessageUI.Message = "Homming...."
                '            fMain.frmMessageUI.ShowFrame()
                '            If fMain.frmMotionUI.ZMove(10, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) Then
                '                Application.DoEvents()
                '                Thread.Sleep(1000)
                '                '    fMain.frmMotionUI.MoveCompletedAllAxis(CDevPLCCommonNode.eAxis.eZ)

                '                fMain.frmMotionUI.YMove(5, g_ConfigInfos.MotionConfig(1).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
                '                Application.DoEvents()
                '                Thread.Sleep(1000)

                '                '  fMain.g_PauseCtrl.paused() '대기로 들어오면 Pause가 완료됨
                '                ' fMain.tsBtnTestPauseImage(My.Resources.Reset_Pause)
                '                ' fMain.tsBtnTestPauseText("STOP")
                '                fMain.g_PauseCtrl.ResetPause()
                '                fMain.EnableTsBtnTestPause(True)
                '                fMain.frmMessageUI.HideFrame()
                '                fMain.g_PauseCtrl.HomePauseState = CPauseControl.ePAUSEHomming.eHome
                '                fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_PAUSED)
                '            End If
                '        End If
                '    End If
                'End If
                Dim nCnt As Integer = 0

                ''If check_MotionHome = False And fMain.meas_queue.Count = 0 Then

                ''    '스케쥴러 모든 채널이 IDEL이고 큐 카운터가 0이면 배출을 시작한다

                ''    'Z축을 올리고 이동
                ''    ' fMain.frmMotionUI.ZMove(10, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)

                ''    Application.DoEvents()
                ''    Thread.Sleep(1000)

                ''    ' fMain.frmMotionUI.MoveCompletedAllAxis()

                ''    'fMain.frmMotionUI.Homming()

                ''    'Application.DoEvents()
                ''    'Thread.Sleep(1000)

                ''    'fMain.frmMotionUI.MoveCompletedAllAxis()

                ''    check_MotionHome = True
                ''    ' fMain.ucMeasurementState.MeasurementState = ucMultiMeasurementState.eState.eEND
                ''    ''End If
                ''End If


                'For nCh As Integer = 0 To g_nMaxCh - 1
                '    If fMain.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
                '        nCnt += 1
                '    End If
                'Next

                'If nCnt = g_nMaxCh Then
                '    If fMain.cPLC Is Nothing = False Then
                '        If fMain.cPLCScheduler.ExhausStart = True Then
                '            fMain.cPLCScheduler.ExhausStart = False
                '            fMain.cPLCScheduler.RequestTest = False
                '            fMain.cPLCScheduler.g_ChSchedulerPLCStatus = CSheduler_PLC.eChSchedulerPLCSTATE.eExhaus
                '        End If
                '    End If
                'End If

                'If check_MotionHome = False Then ' And fMain.meas_queue.Count = 0 Then

                '    'Z축을 올리고 이동
                '    fMain.cMotion.ZMove(10, True)
                '    fMain.cMotion.MoveCompletedAllAxis()
                '    Application.DoEvents()
                '    Thread.Sleep(100)

                '    fMain.cMotion.Homming()
                '    fMain.cMotion.MoveCompletedAllAxis()
                '    check_MotionHome = True

                '    ' 휘도계 Range 초기화  빛이 없는 상태 Dark를 측정하면 Rangel 초기화 됨   PSI업체 휘도계
                '    If fMain.cSpectormeter(0).mySpectrometer.MeasureFixedAperture(Imsimeasdata) = False Then
                '        fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "Source off Measure")
                '    End If
                'End If

                End If

        Loop

        fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_THREAD_STOP, "Process Stop")

    End Sub

    Public Sub CheckThetaPosition(ByVal index As Integer, ByRef degree As Double)

        If index = 0 Or index = 1 Or index = 2 Or index = 6 Or index = 7 Or index = 8 Or index = 12 Or index = 13 Or index = 14 Or index = 18 Or index = 19 Or index = 20 Then
            degree = -90
        Else
            degree = 90
        End If
    End Sub
    Public Function LifetimeMeasurement(ByVal procParam As sProcessParams, ByVal MeasPointNum As Integer, Optional ByVal bSourcingRoutine As Boolean = False, Optional ByRef sMsg As String = "") As Boolean
        Dim bIVLMeasReturn As Boolean = False
        Dim dThetaDegree As Double = 0

        '3. Spectrometer 모션 좌표 이동  채널좌표 Multi Point
        '////////////////////////////////////////////////
        'fMain.cMotion.ZMove(10, True)

        'fMain.frmMotionUI.Move_SetPos(procParam.index, frmMotionUI.eMotionMode.eSpectrometer,
        '                                      procParam.recipe.sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint(0).X + procParam.recipe.sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.X,
        '                                      procParam.recipe.sIVLSweepInfo.sCommon.sMeasPoints.MeasPoint(0).Y + procParam.recipe.sIVLSweepInfo.sCommon.sMeasPoints.marginFromAlignMark.Y)

        'Application.DoEvents()
        'Thread.Sleep(1000)
        fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_RUNNING, "")

        If fMain.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellColor_Meas = Color.Lime
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellStatus = ucDispSampleCommonNode.eCellState.eMeasuring
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).Information = "Measuring..."
        End If
        '////////////////////////////////////////////////

        Select Case procParam.recipe.sLifetimeInfo.nMyMode

            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL

                ' Dim settings(2) As CDevM6000.sSettingParams

                ' Dim measItems As ucSampleInfos.eSampleColor = Nothing
                Dim dCurrent As Double = Nothing
                Dim dSumCurrent As Double = 0
                Dim dTemperature As Double = Nothing
                Dim MeasValOfSpectrometer As CDevSpectrometerCommonNode.tData = Nothing
                Dim buffMeasValOfSpectrometer As CDevSpectrometerCommonNode.tData = Nothing

                Dim dComPos() As Double = Nothing
                Dim dActPos() As Double = Nothing
                Dim dRealPos(2) As Double

                Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                Dim nChNo As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfM6000)
                Dim nChOfSwitch As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfSwitch)
                Dim nDevSwitch As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
                Dim nChOfPairSwitch As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfPairSwitch)
                Dim nChOfPallet As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.ePallet_No)
                Dim nChOfJIG As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eJIG_No)
                Dim nDevOfTC As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfTC)
                Dim nChOfTC As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfTC)


                If procParam.recipe.sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation Then


                    ' X,Y,Z축 Move 
                    If fMain.frmMotionUI.SetPositionXYAxisMovingFirst(g_motionPosSpectrometer(procParam.index), procParam.recipe.sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(MeasPointNum).X, _
                                                                      procParam.recipe.sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(MeasPointNum).Y) = False Then
                        fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "SetPositionXYAxisMovingFirst Function")
                    End If
                 

                    ' fMain.frmMotionUI.MoveCompletedAllAxis()
                    Application.DoEvents()
                    Thread.Sleep(100)
                    CheckThetaPosition(nChOfJIG, dThetaDegree)

                    If nChOfPallet = 0 Then
                        If fMain.frmMotionUI.Theta1Move(dThetaDegree, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                            fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta1 Move Function")
                        End If
                    ElseIf nChOfPallet = 1 Then
                        If fMain.frmMotionUI.Theta2Move(dThetaDegree, g_ConfigInfos.MotionConfig(3).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                            fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta2 Move Function")
                        End If
                    ElseIf nChOfPallet = 2 Then
                        If fMain.frmMotionUI.Theta3Move(dThetaDegree, g_ConfigInfos.MotionConfig(4).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                            fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta3 Move Function")
                        End If
                    ElseIf nChOfPallet = 3 Then
                        If fMain.frmMotionUI.Theta4Move(dThetaDegree, g_ConfigInfos.MotionConfig(5).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                            fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta4 Move Function")
                        End If
                    End If

                    Application.DoEvents()
                    Thread.Sleep(100)
                    'Dim RealDistance() As Double

                    'RealDistance = fMain.cMotion.RealDistance

                    'RealDistance = fMain.frmMotionUI.r
                    ''현재 위치정보 저장 LOG용 테스트용도만 씀 이거쓰면 데이터 졸라쌓임 ㄴㄴㄴ
                    'dComPos = fMain.cMotion.GetCommandPosition.Clone
                    'dActPos = fMain.cMotion.GetActualPosition.Clone

                    'If fMain.g_DataSaver(procParam.index).PostionLog(procParam.recipe.recipeIndex, procParam.index, dComPos, dActPos, RealDistance) = False Then
                    'End If

                    '전류 읽기 전 스위칭 변환
                    If fMain.cSwitch(nDevSwitch).mySwitch.SwitchON(nChOfSwitch) = False Then
                        '예외처리
                    End If

                    '1초 Delay 필요
                    Application.DoEvents()
                    Thread.Sleep(100)

                    If fMain.cSwitch(nDevSwitch).mySwitch.SwitchON(nChOfPairSwitch) = False Then
                        '예외처리
                    End If


                    'If fMain.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch) = False Then

                    'End If
                    '여기에 DMM전류 읽기 추가
                    If fMain.cDMM(0).Measure(dCurrent) = False Then
                        '예외처리 필요
                    End If
                    Application.DoEvents()
                    Thread.Sleep(100)

                    dSumCurrent = 0
                    For i As Integer = 0 To 4
                        Application.DoEvents()
                        Thread.Sleep(50)
                        If fMain.cDMM(0).Measure(dCurrent) = True Then
                            dSumCurrent += dCurrent
                        End If
                    Next

                    dCurrent = dSumCurrent / 5

                    Application.DoEvents()
                    Thread.Sleep(100)
                    If fMain.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfPairSwitch) = False Then

                    End If

                    '읽고 난 후 원복
                    If fMain.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch) = False Then
                        '예외처리
                    End If


                    'Aperture Set
                    Dim nAperture As Integer
                    nAperture = g_SystemOptions.sOptionData.Spectrometer.nAperture
                    If fMain.cSpectormeter(0).mySpectrometer.SetAperture(nAperture) = False Then
                        fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "LifeTime SetAperture")
                    End If

                    Application.DoEvents()
                    Thread.Sleep(50)


                    '휘도측정
                    MeasureSpectrometer(procParam.index, buffMeasValOfSpectrometer, g_SystemOptions.sOptionData.Spectrometer.nAperture, g_SystemOptions.sOptionData.Spectrometer.nSpeedMode)

                    MeasValOfSpectrometer = buffMeasValOfSpectrometer


                    If fMain.cTCMC(nDevOfTC).GetTemp(1, nChOfTC + 1, dTemperature) = False Then
                        'fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateM, "LifeTime SetAperture")
                    End If

                    'If nChOfPallet = 0 Then
                    '    If fMain.frmMotionUI.Theta1Move(0, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                    '        fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta1 Move Function")
                    '    End If
                    'ElseIf nChOfPallet = 1 Then
                    '    If fMain.frmMotionUI.Theta2Move(0, g_ConfigInfos.MotionConfig(3).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                    '        fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta2 Move Function")
                    '    End If
                    'ElseIf nChOfPallet = 2 Then
                    '    If fMain.frmMotionUI.Theta3Move(0, g_ConfigInfos.MotionConfig(4).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                    '        fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta3 Move Function")
                    '    End If
                    'ElseIf nChOfPallet = 3 Then
                    '    If fMain.frmMotionUI.Theta4Move(0, g_ConfigInfos.MotionConfig(5).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                    '        fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta4 Move Function")
                    '    End If
                    'End If

                End If


                '============================데이터 처리================================================
                'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dAngleList = procParam.recipe.sLifetimeInfo.sViewingAngleInfos.dSweepList.Clone

                Dim sDatas As frmMain.sMeasureParams = UpdateAndCalculateCellLifetimeDataForM7000(procParam, dCurrent, dTemperature, MeasValOfSpectrometer, MeasPointNum, bSourcingRoutine)
                Dim sTemp As String = Nothing
                Dim sRecipeMode As Integer

                'LifetimeAndIVL 모드일 경우에 종료 체크 후 IVL Sweep 할 수 있도록
                If fMain.SequenceList(procParam.index).Current.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then

                    '2. IVL Sweep 측정 체크
                    If fMain.SequenceList(procParam.index).IVLSweepMeasCount < fMain.SequenceList(procParam.index).Current.sLifetimeInfo.sCommon.sIVLSweepMeas.Length Then
                        If IsCheckedIVLSweepMeasConditions(procParam, fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(0).opticalData, fMain.SequenceList(procParam.index).Current.sLifetimeInfo.sCommon.sIVLSweepMeas, sMsg) = True Then
                            bIVLMeasReturn = True
                            sTemp = "Before IVL Meas."
                        End If
                    End If

                Else
                    bIVLMeasReturn = False
                End If


                If procParam.recipe.sLifetimeInfo.nMyMode = ucSequenceBuilder.eRcpMode.eCell_Lifetime Then
                    sRecipeMode = procParam.recipe.recipeIndex_LifeTime
                    '   fMain.g_DataSaver(procParam.index).SaveLTDataPoint(procParam.recipe.recipeIndex_LifeTime, sDatas)
                ElseIf procParam.recipe.sLifetimeInfo.nMyMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then
                    sRecipeMode = procParam.recipe.recipeIndex_LifetimeAndIVL

                End If

                fMain.g_DataSaver(procParam.index).SaveLTDataPoint(sRecipeMode, sDatas, MeasPointNum, sTemp)


                '스펙트럼 데이터 저장 확인
                Dim nSaveDataCount As Integer

                nSaveDataCount = fMain.g_DataSaver(procParam.index).SavedDataCounter(sRecipeMode)

                '  If ChkSpectrumDataSave(procParam, fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum).opticalData, g_SystemOptions.sOptionData.SaveOptions.dLuminancePerSpectrumSave, nSaveDataCount, MeasPointNum) = True Or procParam.bLastPointSave = True Then
                fMain.g_DataSaver(procParam.index).SaveLTAngleSpectrumDataPoint(sRecipeMode, procParam.recipe, fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum), MeasPointNum)
                '  End If

                ' fMain.frmMotionUI.ZMove(10, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)   'Z 축 상
                Application.DoEvents()
                Thread.Sleep(100)

            Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime

            Case ucSequenceBuilder.eRcpMode.eModule_Lifetime

        End Select

        If fMain.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellColor_ON = Color.White
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).CellStatus = ucDispSampleCommonNode.eCellState.eON
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(procParam.index).Information = "LifeTime Running..."
        End If


        Return bIVLMeasReturn

    End Function

   
    Public Function LifetimeMeasurement(ByVal MeasColor As String, ByVal in_ch As Integer, ByVal MeasPointNum As Integer, Optional ByVal bSourcingRoutine As Boolean = False, Optional ByRef sMsg As String = "") As Boolean
        Dim bIVLMeasReturn As Boolean = False
        Dim dThetaDegree As Double = 0
        Dim dSumCurrent As Double = 0


        If fMain.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(in_ch).CellColor_Meas = Color.Lime
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(in_ch).CellStatus = ucDispSampleCommonNode.eCellState.eMeasuring
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(in_ch).Information = "Measuring..."
        End If
        '////////////////////////////////////////////////

        Select Case fMain.SequenceList(in_ch).SequenceInfo.sRecipes(0).sLifetimeInfo.nMyMode

            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL

                ' Dim settings(2) As CDevM6000.sSettingParams

                ' Dim measItems As ucSampleInfos.eSampleColor = Nothing
                Dim dCurrent As Double = Nothing
                Dim dTemperature As Double = Nothing
                Dim MeasValOfSpectrometer As CDevSpectrometerCommonNode.tData = Nothing
                Dim buffMeasValOfSpectrometer As CDevSpectrometerCommonNode.tData = Nothing

                Dim dComPos() As Double = Nothing
                Dim dActPos() As Double = Nothing
                Dim dRealPos(2) As Double

                Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                Dim nChNo As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eChOfM6000)
                Dim nChOfSwitch As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eChOfSwitch)
                Dim nDevSwitch As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
                Dim nChOfPairSwitch As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eChOfPairSwitch)
                Dim nChOfPallet As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.ePallet_No)
                Dim nChOfJIG As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eJIG_No)
                Dim nDevOfTC As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eDevNoOfTC)
                Dim nChOfTC As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eChOfTC)

                fMain.g_StateMsgHandler.messageToUserErrorCode(in_ch, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eManulMeasuring, " Color : " & MeasColor & ", Channel : " & in_ch + 1 & ", Point : " & MeasPointNum + 1)

                If fMain.SequenceList(in_ch).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation Then

                    Application.DoEvents()
                    Thread.Sleep(50)
                    'X,Y,Z축 Move 
                    If MeasColor <> "BLACK" Then
                        If fMain.frmMotionUI.SetPositionXYAxisMovingFirst(g_motionPosSpectrometer(in_ch), fMain.SequenceList(in_ch).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(MeasPointNum).X, _
                                                                          fMain.SequenceList(in_ch).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(MeasPointNum).Y) = False Then
                            fMain.g_StateMsgHandler.messageToUserErrorCode(in_ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "SetPositionXYAxisMovingFirst Function")
                        End If

                     
                        '' fMain.frmMotionUI.MoveCompletedAllAxis()
                        Application.DoEvents()
                        Thread.Sleep(50)
                        CheckThetaPosition(nChOfJIG, dThetaDegree)

                        If nChOfPallet = 0 Then
                            If fMain.frmMotionUI.Theta1Move(dThetaDegree, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                                fMain.g_StateMsgHandler.messageToUserErrorCode(in_ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta1 Move Function")
                            End If
                        ElseIf nChOfPallet = 1 Then
                            If fMain.frmMotionUI.Theta2Move(dThetaDegree, g_ConfigInfos.MotionConfig(3).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                                fMain.g_StateMsgHandler.messageToUserErrorCode(in_ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta2 Move Function")
                            End If
                        ElseIf nChOfPallet = 2 Then
                            If fMain.frmMotionUI.Theta3Move(dThetaDegree, g_ConfigInfos.MotionConfig(4).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                                fMain.g_StateMsgHandler.messageToUserErrorCode(in_ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta3 Move Function")
                            End If
                        ElseIf nChOfPallet = 3 Then
                            If fMain.frmMotionUI.Theta4Move(dThetaDegree, g_ConfigInfos.MotionConfig(5).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
                                fMain.g_StateMsgHandler.messageToUserErrorCode(in_ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta4 Move Function")
                            End If
                        End If

                    End If


                    Application.DoEvents()
                    Thread.Sleep(100)
                    'Dim RealDistance() As Double

                    '전류 읽기 전 스위칭 변환
                    If fMain.cSwitch(nDevSwitch).mySwitch.SwitchON(nChOfSwitch) = False Then
                        '예외처리
                    End If

                    '1초 Delay 필요
                    Application.DoEvents()
                    Thread.Sleep(100)

                    If fMain.cSwitch(nDevSwitch).mySwitch.SwitchON(nChOfPairSwitch) = False Then
                        '예외처리
                    End If


                    'If cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch) = False Then

                    'End If
                    '여기에 DMM전류 읽기 추가
                    If fMain.cDMM(0).Measure(dCurrent) = False Then
                        '예외처리 필요
                    End If
                    Application.DoEvents()
                    Thread.Sleep(100)
                    dSumCurrent = 0
                    For i As Integer = 0 To 4
                        Application.DoEvents()
                        Thread.Sleep(50)
                        If fMain.cDMM(0).Measure(dCurrent) = True Then
                            dSumCurrent += dCurrent
                        End If
                    Next

                    dCurrent = dSumCurrent / 5

                    Application.DoEvents()
                    Thread.Sleep(100)
                    If fMain.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfPairSwitch) = False Then

                    End If

                    '읽고 난 후 원복
                    If fMain.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch) = False Then
                        '예외처리
                    End If


                    If MeasColor <> "BLACK" Then
                        'Aperture Set
                        Dim nAperture As Integer
                        nAperture = g_SystemOptions.sOptionData.Spectrometer.nAperture
                        If fMain.cSpectormeter(0).mySpectrometer.SetAperture(nAperture) = False Then
                            fMain.g_StateMsgHandler.messageToUserErrorCode(in_ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "LifeTime SetAperture")
                        End If

                        Application.DoEvents()
                        Thread.Sleep(50)


                        '휘도측정
                        MeasureSpectrometer(in_ch, buffMeasValOfSpectrometer, g_SystemOptions.sOptionData.Spectrometer.nAperture, g_SystemOptions.sOptionData.Spectrometer.nSpeedMode)

                    End If

                    MeasValOfSpectrometer = buffMeasValOfSpectrometer


                    If fMain.cTCMC(nDevOfTC).GetTemp(1, nChOfTC + 1, dTemperature) = False Then
                        'fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateM, "LifeTime SetAperture")
                    End If

                End If


                '============================데이터 처리================================================
                'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dAngleList = procParam.recipe.sLifetimeInfo.sViewingAngleInfos.dSweepList.Clone
                Dim sDatas As frmMain.sMeasureParams = Nothing
                If MeasColor = "RED" Then
                    sDatas = UpdateAndCalculateCellLifetimeDataForM7000_RED(in_ch, dCurrent, dTemperature, MeasValOfSpectrometer, MeasPointNum, bSourcingRoutine)
                    ' g_MeasuredDatas(in_ch).sCellLTParams.RedLTData(MeasPointNum) = sDatas
                ElseIf MeasColor = "GREEN" Then
                    sDatas = UpdateAndCalculateCellLifetimeDataForM7000_GREEN(in_ch, dCurrent, dTemperature, MeasValOfSpectrometer, MeasPointNum, bSourcingRoutine)
                ElseIf MeasColor = "BLUE" Then
                    sDatas = UpdateAndCalculateCellLifetimeDataForM7000_BLUE(in_ch, dCurrent, dTemperature, MeasValOfSpectrometer, MeasPointNum, bSourcingRoutine)
                ElseIf MeasColor = "BLACK" Then
                    sDatas = UpdateAndCalculateCellLifetimeDataForM7000_BLACK(in_ch, dCurrent, dTemperature, MeasValOfSpectrometer, MeasPointNum, bSourcingRoutine)
                End If



                Dim sTemp As String = Nothing
                Dim sRecipeMode As Integer


                bIVLMeasReturn = False



                sRecipeMode = fMain.SequenceList(in_ch).SequenceInfo.sRecipes(0).recipeIndex_LifeTime
                '   fMain.g_DataSaver(procParam.index).SaveLTDataPoint(procParam.recipe.recipeIndex_LifeTime, sDatas)

                Dim nSaveDataCount As Integer
                If MeasColor = "RED" Then
                    fMain.g_DataSaver(in_ch).SaveLTRedDataPoint(sRecipeMode, sDatas, MeasPointNum, sTemp)
                    nSaveDataCount = fMain.g_DataSaver(in_ch).RedSavedDataCounter(sRecipeMode)
                    fMain.g_DataSaver(in_ch).SaveLTAngleSpectrumDataPoint_RED(sRecipeMode, fMain.g_MeasuredDatas(in_ch).sCellLTParams.RedLTData(MeasPointNum), MeasPointNum)
                ElseIf MeasColor = "GREEN" Then
                    fMain.g_DataSaver(in_ch).SaveLTGreenDataPoint(sRecipeMode, sDatas, MeasPointNum, sTemp)
                    nSaveDataCount = fMain.g_DataSaver(in_ch).GreenSavedDataCounter(sRecipeMode)
                    fMain.g_DataSaver(in_ch).SaveLTAngleSpectrumDataPoint_GREEN(sRecipeMode, fMain.g_MeasuredDatas(in_ch).sCellLTParams.GreenLTData(MeasPointNum), MeasPointNum)
                ElseIf MeasColor = "BLUE" Then
                    fMain.g_DataSaver(in_ch).SaveLTBlueDataPoint(sRecipeMode, sDatas, MeasPointNum, sTemp)
                    nSaveDataCount = fMain.g_DataSaver(in_ch).BlueSavedDataCounter(sRecipeMode)
                    fMain.g_DataSaver(in_ch).SaveLTAngleSpectrumDataPoint_BLUE(sRecipeMode, fMain.g_MeasuredDatas(in_ch).sCellLTParams.BlueLTData(MeasPointNum), MeasPointNum)
                ElseIf MeasColor = "BLACK" Then
                    fMain.g_DataSaver(in_ch).SaveLTBlackDataPoint(sRecipeMode, sDatas, MeasPointNum, sTemp)
                    nSaveDataCount = fMain.g_DataSaver(in_ch).BlackSavedDataCounter(sRecipeMode)
                    '   fMain.g_DataSaver(in_ch).SaveLTAngleSpectrumDataPoint_Black(sRecipeMode, fMain.g_MeasuredDatas(in_ch).sCellLTParams.BlueLTData(MeasPointNum), MeasPointNum)
                End If

                '  g_DataSaver(in_ch).SaveLTDataPoint(sRecipeMode, sDatas, MeasPointNum, sTemp)


                ''  If ChkSpectrumDataSave(procParam, fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum).opticalData, g_SystemOptions.sOptionData.SaveOptions.dLuminancePerSpectrumSave, nSaveDataCount, MeasPointNum) = True Or procParam.bLastPointSave = True Then
                'g_DataSaver(in_ch).SaveLTAngleSpectrumDataPoint(sRecipeMode, procParam.recipe, fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum), MeasPointNum)
                ''  End If

                ' fMain.frmMotionUI.ZMove(10, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)   'Z 축 상
                Application.DoEvents()
                Thread.Sleep(100)

            Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime

            Case ucSequenceBuilder.eRcpMode.eModule_Lifetime

        End Select

        If fMain.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(in_ch).CellColor_ON = Color.White
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(in_ch).CellStatus = ucDispSampleCommonNode.eCellState.eON
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(in_ch).Information = "LifeTime Running..."
        End If
        fMain.g_StateMsgHandler.messageToUserErrorCode(in_ch, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eManulMeasureEnd, " Color : " & MeasColor & ", Channel : " & in_ch + 1 & ", Point : " & MeasPointNum + 1)

        Return bIVLMeasReturn

    End Function

    Public Function UpdateAndCalculateCellLifetimeDataForM7000_RED(ByVal in_ch As Integer, ByVal dCurrent As Double, ByVal dTemp As Double,
                                                             ByVal MeasValOfSpectrometer As CDevSpectrometerCommonNode.tData, ByVal MeasPointNum As Integer, Optional ByVal bFirstSettings As Boolean = False) As frmMain.sMeasureParams
        'Dim dMeasData As frmMain.sMeasureParams

        Dim dLumi As Double
        Dim dDeltaudvd As Double
        Dim dCd_a As Double
        '   Dim sDatas() As String = Nothing
        Dim cDataQE As CDataQECal = New CDataQECal
        Dim nTimeOutCnt As Integer = 0
        Const NumOfCol_OpticalData As Integer = 10
        Dim dSum As Double = 0
        Dim nTotalColunmCnt As Integer
        Dim Normspectrum() As Double = Nothing
        Dim nELmax As Integer = 0
        Dim dFWHM As Double = 0
        Dim nSpectrumSize As Integer
        Dim dSpectrum As Double
        fMain.g_MeasuredDatas(in_ch).sCellLTParams.dCHNum = in_ch + 1
        fMain.g_MeasuredDatas(in_ch).sCellLTParams.dCellArea = (fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Height * fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Width) / 100
        nTotalColunmCnt += 1

        fMain.g_MeasuredDatas(in_ch).dTemp = dTemp

        With fMain.g_MeasuredDatas(in_ch).sCellLTParams.RedLTData(MeasPointNum)

            .dTotCurrent = 0

            '데이터 복사
            '  .eletricalData.colorType = electricalDataIdx

            .eletricalData.dCurrent = dCurrent * 1000

            .dTotCurrent = .eletricalData.dCurrent


            ''데이터 정렬용 카운트 증가
            'If .eletricalData.mode = CDevM6000PLUS.eMode.eCC Or
            '    .eletricalData.mode = CDevM6000PLUS.eMode.eCV Then '이값을 사용하지 않고 M6000 데이터에 모드를 추가해서 사용
            '    nTotalColunmCnt += NumOfCol_EletricalData
            'Else
            '    nTotalColunmCnt += numOfCol_EletricalData_Pulse
            'End If

            .dCurrentDensity = (.dTotCurrent) / ((fMain.g_MeasuredDatas(in_ch).sCellLTParams.dCellArea * fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.dFillFactor) / 100)


            ' .dCurrentDensity = Format((.dTotCurrent * 1000) / ((fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * procParam.sSampleInfos.dFillFactor) / 100), "0.00000E-0")
            'Step2. Measurement (Multi-Point Measurement)   'LEX

            Dim nWavelengthInterval As Integer = Nothing

            .opticalData.sSpectrometerData = MeasValOfSpectrometer
            dLumi = (.opticalData.sSpectrometerData.D6.s2YY * 100) / fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.dFillFactor
            .opticalData.dLumi_Cd_m2 = .opticalData.sSpectrometerData.D6.s2YY
            .opticalData.dLumi_Fill_Cd_m2 = dLumi
            '# Calculation cd/A
            '.opticalData(opticalDataIdx).dLumi_Cd_A = dLumi / (.dCurrentDensity * 10)
            .opticalData.dLumi_Cd_A = FormatNumber(dLumi / (.dCurrentDensity * 10), 3) '((.dTotCurrent * 1000 / (fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * 100) * 100) * 10)

            '# Calculation lm/W
            'lm/W 확인 필요
            .opticalData.dlmW = FormatNumber(.opticalData.dLumi_Cd_A / .eletricalData.dVoltage * Math.PI, 3)
            '     fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dLumi_Cd_A / fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dVoltage * Math.PI



            '스펙트럼 간격별로 QE계산 함수 호출 할 수 있도록 변경 해야 함.
            If .opticalData.sSpectrometerData.D5.i3nm Is Nothing = False Then
                nWavelengthInterval = .opticalData.sSpectrometerData.D5.i3nm(1) - .opticalData.sSpectrometerData.D5.i3nm(0)

                .opticalData.dQE = FormatNumber(cDataQE.QuantumEfficiency(dLumi, .dCurrentDensity, fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Height * fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Width, _
                                                                         .opticalData.sSpectrometerData.D5.s4Intensity, nWavelengthInterval), 3)
                For idx As Integer = 0 To .opticalData.sSpectrometerData.D5.s4Intensity.Length - 1
                    dSum += .opticalData.sSpectrometerData.D5.s4Intensity(idx)
                Next
                .opticalData.dSpectrumSum = dSum

                Dim PeakVal As Double = 0
                Dim PeakLength As Integer = 0
                For i As Integer = 0 To .opticalData.sSpectrometerData.D5.i3nm.Length - 1
                    If .opticalData.sSpectrometerData.D5.s4Intensity(i) > PeakVal Then
                        PeakLength = .opticalData.sSpectrometerData.D5.i3nm(i)
                        PeakVal = .opticalData.sSpectrometerData.D5.s4Intensity(i)
                    End If
                Next
                .opticalData.dELMax = PeakLength
            Else
                .opticalData.dSpectrumSum = 0
                .opticalData.dQE = 0
            End If

            nSpectrumSize = 1
            Normspectrum = DataNormalization(.opticalData.sSpectrometerData.D5.s4Intensity, nSpectrumSize, nELmax)

            'Cal FWHM
            Cal_FWHM(nELmax, Normspectrum, .opticalData.sSpectrometerData.D5.i3nm, nSpectrumSize, dFWHM)

            .opticalData.dFWHM = dFWHM

            If bFirstSettings = True Then
                .opticalData.dRefLumi = MeasValOfSpectrometer.D6.s2YY 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s2YY
                .opticalData.dRefud = MeasValOfSpectrometer.D6.s5uu  'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s5uu
                .opticalData.dRefvd = MeasValOfSpectrometer.D6.s6vv 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s6vv
                '   fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dRefVoltage = MeasValOfM6000.dVoltage_Bias 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dVoltage
                .eletricalData.dRefCurrent = .eletricalData.dCurrent 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dCurrent
                .opticalData.dLumi_Cd_A_RefValue = .opticalData.dLumi_Cd_A
                .opticalData.dSpectrumSum_Ref = .opticalData.dSpectrumSum
                '  g_MeasuredDatas(in_ch).bIsSavedRefPDCurrent = True
                ' g_MeasuredDatas(in_ch).bRequestedMeasRefValue = False
            End If

            If bFirstSettings = False Then  '기준 값이 저장 되었으면...

                .eletricalData.dDeltaVoltage = .eletricalData.dVoltage - .eletricalData.dRefVoltage
                .eletricalData.dDeltaCurrent = .eletricalData.dCurrent - .eletricalData.dRefCurrent
                .eletricalData.dCurrent_Per = (.eletricalData.dCurrent / .eletricalData.dRefCurrent) * 100
            Else
                .eletricalData.dDeltaVoltage = 0
                .eletricalData.dDeltaCurrent = 0
                .eletricalData.dCurrent_Per = 100
            End If

            If bFirstSettings = False Then  '기준 값이 저장 되었으면...
                dLumi = (.opticalData.sSpectrometerData.D6.s2YY / .opticalData.dRefLumi) * 100
                dDeltaudvd = Math.Sqrt((.opticalData.dRefud - .opticalData.sSpectrometerData.D6.s5uu) ^ 2 + (.opticalData.dRefvd - .opticalData.sSpectrometerData.D6.s6vv) ^ 2)
                dCd_a = (.opticalData.dLumi_Cd_A / .opticalData.dLumi_Cd_A_RefValue) * 100
                dSpectrum = (.opticalData.dSpectrumSum / .opticalData.dSpectrumSum_Ref) * 100
            Else
                dCd_a = 100
                dLumi = 100
                dDeltaudvd = 0
                dSpectrum = 100
            End If

            .opticalData.dLumi_Percent = dLumi
            .opticalData.dLumi_Cd_A_Percent = dCd_a
            .opticalData.dDeltaudvd = dDeltaudvd
            .opticalData.dSpectrumSum_Per = dSpectrum

            '데이터 정렬용 카운트 증가
            nTotalColunmCnt += NumOfCol_OpticalData
            ' Next

        End With

        Return fMain.g_MeasuredDatas(in_ch)
    End Function


    Public Function UpdateAndCalculateCellLifetimeDataForM7000_GREEN(ByVal in_ch As Integer, ByVal dCurrent As Double, ByVal dTemp As Double,
                                                             ByVal MeasValOfSpectrometer As CDevSpectrometerCommonNode.tData, ByVal MeasPointNum As Integer, Optional ByVal bFirstSettings As Boolean = False) As frmMain.sMeasureParams
        'Dim dMeasData As frmMain.sMeasureParams

        Dim dLumi As Double
        Dim dDeltaudvd As Double
        Dim dCd_a As Double
        '   Dim sDatas() As String = Nothing
        Dim cDataQE As CDataQECal = New CDataQECal
        Dim nTimeOutCnt As Integer = 0
        Const NumOfCol_OpticalData As Integer = 10
        Dim dSum As Double = 0
        Dim nTotalColunmCnt As Integer
        Dim Normspectrum() As Double = Nothing
        Dim nELmax As Integer = 0
        Dim dFWHM As Double = 0
        Dim nSpectrumSize As Integer
        Dim dSpectrum As Double
        fMain.g_MeasuredDatas(in_ch).sCellLTParams.dCHNum = in_ch + 1
        fMain.g_MeasuredDatas(in_ch).sCellLTParams.dCellArea = (fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Height * fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Width) / 100
        nTotalColunmCnt += 1

        fMain.g_MeasuredDatas(in_ch).dTemp = dTemp

        With fMain.g_MeasuredDatas(in_ch).sCellLTParams.GreenLTData(MeasPointNum)

            .dTotCurrent = 0

            '데이터 복사
            '  .eletricalData.colorType = electricalDataIdx

            .eletricalData.dCurrent = dCurrent * 1000

            .dTotCurrent = .eletricalData.dCurrent


            ''데이터 정렬용 카운트 증가
            'If .eletricalData.mode = CDevM6000PLUS.eMode.eCC Or
            '    .eletricalData.mode = CDevM6000PLUS.eMode.eCV Then '이값을 사용하지 않고 M6000 데이터에 모드를 추가해서 사용
            '    nTotalColunmCnt += NumOfCol_EletricalData
            'Else
            '    nTotalColunmCnt += numOfCol_EletricalData_Pulse
            'End If

            .dCurrentDensity = (.dTotCurrent) / ((fMain.g_MeasuredDatas(in_ch).sCellLTParams.dCellArea * fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.dFillFactor) / 100)


            ' .dCurrentDensity = Format((.dTotCurrent * 1000) / ((fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * procParam.sSampleInfos.dFillFactor) / 100), "0.00000E-0")
            'Step2. Measurement (Multi-Point Measurement)   'LEX

            Dim nWavelengthInterval As Integer = Nothing

            .opticalData.sSpectrometerData = MeasValOfSpectrometer
            dLumi = (.opticalData.sSpectrometerData.D6.s2YY * 100) / fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.dFillFactor
            .opticalData.dLumi_Cd_m2 = .opticalData.sSpectrometerData.D6.s2YY
            .opticalData.dLumi_Fill_Cd_m2 = dLumi
            '# Calculation cd/A
            '.opticalData(opticalDataIdx).dLumi_Cd_A = dLumi / (.dCurrentDensity * 10)
            .opticalData.dLumi_Cd_A = FormatNumber(dLumi / (.dCurrentDensity * 10), 3) '((.dTotCurrent * 1000 / (fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * 100) * 100) * 10)

            '# Calculation lm/W
            'lm/W 확인 필요
            .opticalData.dlmW = FormatNumber(.opticalData.dLumi_Cd_A / .eletricalData.dVoltage * Math.PI, 3)
            '     fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dLumi_Cd_A / fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dVoltage * Math.PI


            '스펙트럼 간격별로 QE계산 함수 호출 할 수 있도록 변경 해야 함.
            If .opticalData.sSpectrometerData.D5.i3nm Is Nothing = False Then
                nWavelengthInterval = .opticalData.sSpectrometerData.D5.i3nm(1) - .opticalData.sSpectrometerData.D5.i3nm(0)

                .opticalData.dQE = FormatNumber(cDataQE.QuantumEfficiency(dLumi, .dCurrentDensity, fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Height * fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Width, _
                                                                         .opticalData.sSpectrometerData.D5.s4Intensity, nWavelengthInterval), 3)
                For idx As Integer = 0 To .opticalData.sSpectrometerData.D5.s4Intensity.Length - 1
                    dSum += .opticalData.sSpectrometerData.D5.s4Intensity(idx)
                Next
                .opticalData.dSpectrumSum = dSum
                Dim PeakVal As Double = 0
                Dim PeakLength As Integer = 0
                For i As Integer = 0 To .opticalData.sSpectrometerData.D5.i3nm.Length - 1
                    If .opticalData.sSpectrometerData.D5.s4Intensity(i) > PeakVal Then
                        PeakLength = .opticalData.sSpectrometerData.D5.i3nm(i)
                        PeakVal = .opticalData.sSpectrometerData.D5.s4Intensity(i)
                    End If
                Next
                .opticalData.dELMax = PeakLength
            Else
                .opticalData.dQE = 0
                .opticalData.dSpectrumSum = 0
            End If

            nSpectrumSize = 1
            Normspectrum = DataNormalization(.opticalData.sSpectrometerData.D5.s4Intensity, nSpectrumSize, nELmax)

            'Cal FWHM
            Cal_FWHM(nELmax, Normspectrum, .opticalData.sSpectrometerData.D5.i3nm, nSpectrumSize, dFWHM)

            .opticalData.dFWHM = dFWHM
            If bFirstSettings = True Then
                .opticalData.dRefLumi = MeasValOfSpectrometer.D6.s2YY 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s2YY
                .opticalData.dRefud = MeasValOfSpectrometer.D6.s5uu  'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s5uu
                .opticalData.dRefvd = MeasValOfSpectrometer.D6.s6vv 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s6vv
                '   fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dRefVoltage = MeasValOfM6000.dVoltage_Bias 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dVoltage
                .eletricalData.dRefCurrent = .eletricalData.dCurrent 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dCurrent
                .opticalData.dLumi_Cd_A_RefValue = .opticalData.dLumi_Cd_A
                .opticalData.dSpectrumSum_Ref = .opticalData.dSpectrumSum
                'g_MeasuredDatas(in_ch).bIsSavedRefPDCurrent = True
                ' g_MeasuredDatas(in_ch).bRequestedMeasRefValue = False
            End If

            If bFirstSettings = False Then  '기준 값이 저장 되었으면...
                .eletricalData.dDeltaVoltage = .eletricalData.dVoltage - .eletricalData.dRefVoltage
                .eletricalData.dDeltaCurrent = .eletricalData.dCurrent - .eletricalData.dRefCurrent
                .eletricalData.dCurrent_Per = (.eletricalData.dCurrent / .eletricalData.dRefCurrent) * 100
            Else
                .eletricalData.dDeltaVoltage = 0
                .eletricalData.dDeltaCurrent = 0
                .eletricalData.dCurrent_Per = 100
            End If

            If bFirstSettings = False Then  '기준 값이 저장 되었으면...
                dLumi = (.opticalData.sSpectrometerData.D6.s2YY / .opticalData.dRefLumi) * 100
                dDeltaudvd = Math.Sqrt((.opticalData.dRefud - .opticalData.sSpectrometerData.D6.s5uu) ^ 2 + (.opticalData.dRefvd - .opticalData.sSpectrometerData.D6.s6vv) ^ 2)
                dCd_a = (.opticalData.dLumi_Cd_A / .opticalData.dLumi_Cd_A_RefValue) * 100
                dSpectrum = (.opticalData.dSpectrumSum / .opticalData.dSpectrumSum_Ref) * 100
            Else
                dCd_a = 100
                dLumi = 100
                dDeltaudvd = 0
                dSpectrum = 100
            End If

            .opticalData.dLumi_Percent = dLumi
            .opticalData.dLumi_Cd_A_Percent = dCd_a
            .opticalData.dDeltaudvd = dDeltaudvd
            .opticalData.dSpectrumSum_Per = dSpectrum

            '데이터 정렬용 카운트 증가
            nTotalColunmCnt += NumOfCol_OpticalData
            ' Next

        End With

        Return fMain.g_MeasuredDatas(in_ch)
    End Function


    Public Function UpdateAndCalculateCellLifetimeDataForM7000_BLUE(ByVal in_ch As Integer, ByVal dCurrent As Double, ByVal dTemp As Double,
                                                             ByVal MeasValOfSpectrometer As CDevSpectrometerCommonNode.tData, ByVal MeasPointNum As Integer, Optional ByVal bFirstSettings As Boolean = False) As frmMain.sMeasureParams
        'Dim dMeasData As frmMain.sMeasureParams

        Dim dLumi As Double
        Dim dDeltaudvd As Double
        Dim dCd_a As Double
        Dim dSpectrum As Double
        '   Dim sDatas() As String = Nothing
        Dim cDataQE As CDataQECal = New CDataQECal
        Dim nTimeOutCnt As Integer = 0
        Const NumOfCol_OpticalData As Integer = 10
        Dim dSum As Double = 0
        Dim nTotalColunmCnt As Integer
        Dim Normspectrum() As Double = Nothing
        Dim nELmax As Integer = 0
        Dim dFWHM As Double = 0
        Dim nSpectrumSize As Integer
        fMain.g_MeasuredDatas(in_ch).sCellLTParams.dCHNum = in_ch + 1
        fMain.g_MeasuredDatas(in_ch).sCellLTParams.dCellArea = (fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Height * fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Width) / 100
        nTotalColunmCnt += 1

        fMain.g_MeasuredDatas(in_ch).dTemp = dTemp

        With fMain.g_MeasuredDatas(in_ch).sCellLTParams.BlueLTData(MeasPointNum)

            .dTotCurrent = 0

            '데이터 복사
            '  .eletricalData.colorType = electricalDataIdx

            .eletricalData.dCurrent = dCurrent * 1000

            .dTotCurrent = .eletricalData.dCurrent


            ''데이터 정렬용 카운트 증가
            'If .eletricalData.mode = CDevM6000PLUS.eMode.eCC Or
            '    .eletricalData.mode = CDevM6000PLUS.eMode.eCV Then '이값을 사용하지 않고 M6000 데이터에 모드를 추가해서 사용
            '    nTotalColunmCnt += NumOfCol_EletricalData
            'Else
            '    nTotalColunmCnt += numOfCol_EletricalData_Pulse
            'End If

            .dCurrentDensity = (.dTotCurrent) / ((fMain.g_MeasuredDatas(in_ch).sCellLTParams.dCellArea * fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.dFillFactor) / 100)


            ' .dCurrentDensity = Format((.dTotCurrent * 1000) / ((fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * procParam.sSampleInfos.dFillFactor) / 100), "0.00000E-0")
            'Step2. Measurement (Multi-Point Measurement)   'LEX

            Dim nWavelengthInterval As Integer = Nothing

            .opticalData.sSpectrometerData = MeasValOfSpectrometer
            dLumi = (.opticalData.sSpectrometerData.D6.s2YY * 100) / fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.dFillFactor
            .opticalData.dLumi_Cd_m2 = .opticalData.sSpectrometerData.D6.s2YY
            .opticalData.dLumi_Fill_Cd_m2 = dLumi
            '# Calculation cd/A
            '.opticalData(opticalDataIdx).dLumi_Cd_A = dLumi / (.dCurrentDensity * 10)
            .opticalData.dLumi_Cd_A = FormatNumber(dLumi / (.dCurrentDensity * 10), 3) '((.dTotCurrent * 1000 / (fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * 100) * 100) * 10)

            '# Calculation lm/W
            'lm/W 확인 필요
            .opticalData.dlmW = FormatNumber(.opticalData.dLumi_Cd_A / .eletricalData.dVoltage * Math.PI, 3)
            '     fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dLumi_Cd_A / fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dVoltage * Math.PI


            '스펙트럼 간격별로 QE계산 함수 호출 할 수 있도록 변경 해야 함.
            If .opticalData.sSpectrometerData.D5.i3nm Is Nothing = False Then
                nWavelengthInterval = .opticalData.sSpectrometerData.D5.i3nm(1) - .opticalData.sSpectrometerData.D5.i3nm(0)

                .opticalData.dQE = FormatNumber(cDataQE.QuantumEfficiency(dLumi, .dCurrentDensity, fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Height * fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Width, _
                                                                         .opticalData.sSpectrometerData.D5.s4Intensity, nWavelengthInterval), 3)
                For idx As Integer = 0 To .opticalData.sSpectrometerData.D5.s4Intensity.Length - 1
                    dSum += .opticalData.sSpectrometerData.D5.s4Intensity(idx)
                Next
                .opticalData.dSpectrumSum = dSum
                Dim PeakVal As Double = 0
                Dim PeakLength As Integer = 0
                For i As Integer = 0 To .opticalData.sSpectrometerData.D5.i3nm.Length - 1
                    If .opticalData.sSpectrometerData.D5.s4Intensity(i) > PeakVal Then
                        PeakLength = .opticalData.sSpectrometerData.D5.i3nm(i)
                        PeakVal = .opticalData.sSpectrometerData.D5.s4Intensity(i)
                    End If
                Next
                .opticalData.dELMax = PeakLength
            Else
                .opticalData.dQE = 0
                .opticalData.dSpectrumSum = 0
            End If
            nSpectrumSize = 1
            Normspectrum = DataNormalization(.opticalData.sSpectrometerData.D5.s4Intensity, nSpectrumSize, nELmax)

            'Cal FWHM
            Cal_FWHM(nELmax, Normspectrum, .opticalData.sSpectrometerData.D5.i3nm, nSpectrumSize, dFWHM)

            .opticalData.dFWHM = dFWHM

            If bFirstSettings = True Then
                .opticalData.dRefLumi = MeasValOfSpectrometer.D6.s2YY 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s2YY
                .opticalData.dRefud = MeasValOfSpectrometer.D6.s5uu  'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s5uu
                .opticalData.dRefvd = MeasValOfSpectrometer.D6.s6vv 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s6vv
                '   fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dRefVoltage = MeasValOfM6000.dVoltage_Bias 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dVoltage
                .eletricalData.dRefCurrent = .eletricalData.dCurrent 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dCurrent
                .opticalData.dLumi_Cd_A_RefValue = .opticalData.dLumi_Cd_A
                .opticalData.dSpectrumSum_Ref = .opticalData.dSpectrumSum

                '  g_MeasuredDatas(in_ch).bIsSavedRefPDCurrent = True
                ' g_MeasuredDatas(in_ch).bRequestedMeasRefValue = False
            End If

            If bFirstSettings = False Then  '기준 값이 저장 되었으면...
                .eletricalData.dDeltaVoltage = .eletricalData.dVoltage - .eletricalData.dRefVoltage
                .eletricalData.dDeltaCurrent = .eletricalData.dCurrent - .eletricalData.dRefCurrent
                .eletricalData.dCurrent_Per = (.eletricalData.dCurrent / .eletricalData.dRefCurrent) * 100
            Else
                .eletricalData.dDeltaVoltage = 0
                .eletricalData.dDeltaCurrent = 0
                .eletricalData.dCurrent_Per = 100
            End If

            If bFirstSettings = False Then  '기준 값이 저장 되었으면...
                dLumi = (.opticalData.sSpectrometerData.D6.s2YY / .opticalData.dRefLumi) * 100
                dDeltaudvd = Math.Sqrt((.opticalData.dRefud - .opticalData.sSpectrometerData.D6.s5uu) ^ 2 + (.opticalData.dRefvd - .opticalData.sSpectrometerData.D6.s6vv) ^ 2)
                dCd_a = (.opticalData.dLumi_Cd_A / .opticalData.dLumi_Cd_A_RefValue) * 100
                dSpectrum = (.opticalData.dSpectrumSum / .opticalData.dSpectrumSum_Ref) * 100
            Else
                dCd_a = 100
                dLumi = 100
                dDeltaudvd = 0
                dSpectrum = 100
            End If

            .opticalData.dLumi_Percent = dLumi
            .opticalData.dLumi_Cd_A_Percent = dCd_a
            .opticalData.dDeltaudvd = dDeltaudvd
            .opticalData.dSpectrumSum_Per = dSpectrum


            '데이터 정렬용 카운트 증가
            nTotalColunmCnt += NumOfCol_OpticalData
            ' Next

        End With

        Return fMain.g_MeasuredDatas(in_ch)
    End Function

    Public Function UpdateAndCalculateCellLifetimeDataForM7000_BLACK(ByVal in_ch As Integer, ByVal dCurrent As Double, ByVal dTemp As Double,
                                                             ByVal MeasValOfSpectrometer As CDevSpectrometerCommonNode.tData, ByVal MeasPointNum As Integer, Optional ByVal bFirstSettings As Boolean = False) As frmMain.sMeasureParams
        'Dim dMeasData As frmMain.sMeasureParams

        Dim dLumi As Double
        Dim dDeltaudvd As Double
        Dim dCd_a As Double
        '   Dim sDatas() As String = Nothing
        Dim cDataQE As CDataQECal = New CDataQECal
        Dim nTimeOutCnt As Integer = 0
        Const NumOfCol_OpticalData As Integer = 10
        Dim dSum As Double = 0
        Dim nTotalColunmCnt As Integer

        fMain.g_MeasuredDatas(in_ch).sCellLTParams.dCHNum = in_ch + 1
        fMain.g_MeasuredDatas(in_ch).sCellLTParams.dCellArea = (fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Height * fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Width) / 100
        nTotalColunmCnt += 1

        fMain.g_MeasuredDatas(in_ch).dTemp = dTemp

        With fMain.g_MeasuredDatas(in_ch).sCellLTParams.BlackLTData(MeasPointNum)

            .dTotCurrent = 0

            '데이터 복사
            '  .eletricalData.colorType = electricalDataIdx

            .eletricalData.dCurrent = dCurrent * 1000

            .dTotCurrent = .eletricalData.dCurrent


            ''데이터 정렬용 카운트 증가
            'If .eletricalData.mode = CDevM6000PLUS.eMode.eCC Or
            '    .eletricalData.mode = CDevM6000PLUS.eMode.eCV Then '이값을 사용하지 않고 M6000 데이터에 모드를 추가해서 사용
            '    nTotalColunmCnt += NumOfCol_EletricalData
            'Else
            '    nTotalColunmCnt += numOfCol_EletricalData_Pulse
            'End If

            .dCurrentDensity = (.dTotCurrent) / ((fMain.g_MeasuredDatas(in_ch).sCellLTParams.dCellArea * fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.dFillFactor) / 100)


            ' .dCurrentDensity = Format((.dTotCurrent * 1000) / ((fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * procParam.sSampleInfos.dFillFactor) / 100), "0.00000E-0")
            'Step2. Measurement (Multi-Point Measurement)   'LEX


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim nWavelengthInterval As Integer = Nothing

            '.opticalData.sSpectrometerData = MeasValOfSpectrometer
            'dLumi = (.opticalData.sSpectrometerData.D6.s2YY * 100)
            '.opticalData.dLumi_Cd_m2 = .opticalData.sSpectrometerData.D6.s2YY
            '.opticalData.dLumi_Fill_Cd_m2 = dLumi
            ''# Calculation cd/A
            ''.opticalData(opticalDataIdx).dLumi_Cd_A = dLumi / (.dCurrentDensity * 10)
            '.opticalData.dLumi_Cd_A = FormatNumber(dLumi / (.dCurrentDensity * 10), 3) '((.dTotCurrent * 1000 / (fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * 100) * 100) * 10)

            ''# Calculation lm/W
            ''lm/W 확인 필요
            '.opticalData.dlmW = FormatNumber(.opticalData.dLumi_Cd_A / .eletricalData.dVoltage * Math.PI, 3)
            ''     fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dLumi_Cd_A / fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dVoltage * Math.PI


            ''스펙트럼 간격별로 QE계산 함수 호출 할 수 있도록 변경 해야 함.
            'If .opticalData.sSpectrometerData.D5.i3nm Is Nothing = False Then
            '    nWavelengthInterval = .opticalData.sSpectrometerData.D5.i3nm(1) - .opticalData.sSpectrometerData.D5.i3nm(0)

            '    .opticalData.dQE = FormatNumber(cDataQE.QuantumEfficiency(dLumi, .dCurrentDensity, fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Height * fMain.SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Width, _
            '                                                             .opticalData.sSpectrometerData.D5.s4Intensity, nWavelengthInterval), 3)
            'Else
            '    .opticalData.dQE = 0
            'End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If bFirstSettings = True Then
                .opticalData.dRefLumi = MeasValOfSpectrometer.D6.s2YY 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s2YY
                .opticalData.dRefud = MeasValOfSpectrometer.D6.s5uu  'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s5uu
                .opticalData.dRefvd = MeasValOfSpectrometer.D6.s6vv 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s6vv
                '   fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dRefVoltage = MeasValOfM6000.dVoltage_Bias 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dVoltage
                .eletricalData.dRefCurrent = .eletricalData.dCurrent 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dCurrent
                .opticalData.dLumi_Cd_A_RefValue = .opticalData.dLumi_Cd_A

                '  g_MeasuredDatas(in_ch).bIsSavedRefPDCurrent = True
                ' g_MeasuredDatas(in_ch).bRequestedMeasRefValue = False
            End If

            If bFirstSettings = False Then  '기준 값이 저장 되었으면...
                .eletricalData.dDeltaVoltage = .eletricalData.dVoltage - .eletricalData.dRefVoltage
                .eletricalData.dDeltaCurrent = .eletricalData.dCurrent - .eletricalData.dRefCurrent
                .eletricalData.dCurrent_Per = (.eletricalData.dCurrent / .eletricalData.dRefCurrent) * 100
            Else
                .eletricalData.dDeltaVoltage = 0
                .eletricalData.dDeltaCurrent = 0
                .eletricalData.dCurrent_Per = 100
            End If

            If bFirstSettings = False Then  '기준 값이 저장 되었으면...
                dLumi = (.opticalData.sSpectrometerData.D6.s2YY / .opticalData.dRefLumi) * 100
                dDeltaudvd = Math.Sqrt((.opticalData.dRefud - .opticalData.sSpectrometerData.D6.s5uu) ^ 2 + (.opticalData.dRefvd - .opticalData.sSpectrometerData.D6.s6vv) ^ 2)
                dCd_a = (.opticalData.dLumi_Cd_A / .opticalData.dLumi_Cd_A_RefValue) * 100

            Else
                dCd_a = 100
                dLumi = 100
                dDeltaudvd = 0
            End If

            .opticalData.dLumi_Percent = dLumi
            .opticalData.dLumi_Cd_A_Percent = dCd_a
            .opticalData.dDeltaudvd = dDeltaudvd


            '데이터 정렬용 카운트 증가
            nTotalColunmCnt += NumOfCol_OpticalData
            ' Next

        End With

        Return fMain.g_MeasuredDatas(in_ch)
    End Function


    Private Function IsCheckedIVLSweepMeasConditions(ByVal procParam As sProcessParams, ByVal sMeasData As frmMain.sOpticalMeasData, ByVal TestEndConditions() As ucTestEndParam.sTestEndParam, ByRef sMsg As String) As Boolean
        Dim nEndParam As ucTestEndParam.eTestEndParam
        Dim dEndValue As Double
        Dim nCh As Integer = procParam.index
        Dim nIVLMeasCount As Integer

        If TestEndConditions Is Nothing Then Return True
        nIVLMeasCount = fMain.SequenceList(procParam.index).IVLSweepMeasCount

        nEndParam = TestEndConditions(nIVLMeasCount).nTypeOfParam
        dEndValue = TestEndConditions(nIVLMeasCount).dValue

        If fMain.g_DataSaver(nCh).SavedDataCounter(procParam.recipe.recipeIndex_LifetimeAndIVL) <= 1 Then
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(0).opticalData.dRefLumi_Percent = 100
            fMain.g_MeasuredDatas(nCh).sCellLTParams.LTData(0).nLifetimeAfterIVLCnt += 1
        Else
            If fMain.g_MeasuredDatas(procParam.index).bIsSavedRefPDCurrent = True Then
                ' If sMeasData.dLumi_Percent <= sMeasData.dRefLumi_Percent - dEndValue Or sMeasData.dLumi_Percent >= sMeasData.dRefLumi_Percent + dEndValue Then
                If sMeasData.dLumi_Percent <= dEndValue Then
                    fMain.SequenceList(procParam.index).IVLSweepMeasCount += 1

                    'IVL Sweep 측정 조건이 남아 있고, 휘도%가 다음 IVL Sweep 측정 조건보다 더 떨어졌을 경우 그 다음 IVL Sweep 측정 조건으로 변경 한다.
                    For nCnt As Integer = fMain.SequenceList(procParam.index).IVLSweepMeasCount To fMain.SequenceList(procParam.index).Current.sLifetimeInfo.sCommon.sIVLSweepMeas.Length
                        If fMain.SequenceList(procParam.index).IVLSweepMeasCount < fMain.SequenceList(procParam.index).Current.sLifetimeInfo.sCommon.sIVLSweepMeas.Length Then
                            dEndValue = TestEndConditions(fMain.SequenceList(procParam.index).IVLSweepMeasCount).dValue
                            If sMeasData.dLumi_Percent <= dEndValue Then
                                fMain.SequenceList(procParam.index).IVLSweepMeasCount += 1
                            Else
                                Exit For
                            End If
                        End If
                    Next

                    Return True
                End If
                ' End If
            End If
        End If

        Return False
    End Function

    Private Function ChkSpectrumDataSave(ByVal procParam As sProcessParams, ByVal sMeasData As frmMain.sOpticalMeasData, ByVal dPercentSave As Double, ByVal nSaveDataCount As Integer, ByVal MeasPointNum As Integer) As Boolean

        If nSaveDataCount <= 1 Then
            fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum).opticalData.dRefSpectrum_Percent = 100
            fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum).nSpecSaveCnt += 1
        Else
            If fMain.g_MeasuredDatas(procParam.index).bIsSavedRefPDCurrent = True Then
                'If fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.nSpecSaveCnt = 1 Then
                '    fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.dRefSpectrum_Percent = fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.dLumi_Percent
                '    fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.nSpecSaveCnt += 1
                '    Return True
                'End If

                If sMeasData.dLumi_Percent <= sMeasData.dRefSpectrum_Percent - dPercentSave Or sMeasData.dLumi_Percent >= sMeasData.dRefSpectrum_Percent + dPercentSave Then
                    fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum).opticalData.dRefSpectrum_Percent = fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum).opticalData.dLumi_Percent
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If

        Return True
    End Function

    Public Function IVLSweepRoutine(ByVal procParam As sProcessParams, ByRef IVLIndicator As frmIVLDisplay, ByVal nAperture As Integer, ByVal nSpeedMode As Integer) As Boolean

        Dim IVL_V As Double
        Dim IVL_I As Double
        Dim IVLIndicatorDlg As frmIVLDisplay = New frmIVLDisplay(procParam.recipe.nMode)

        Dim dispCh As New CChDisp
        Dim LimitChk As Boolean = False
        Dim SpecMeasChk As Boolean = False
        dispCh.ChannelNo = procParam.index
        dispCh.DispType = CChDisp.eChannelDispType.eJIGAndCellNo

        '   IVLIndicatorDlg.Text = "IVL Sweep Indicator" & " [Channel : " & Format(procParam.index + 1, "000") & "] [JIG No. : " & dispCh.DispChannel & "]"
        'IVLIndicatorDlg.Text = "IVL Sweep Indicator" & " [TEG : " & Format(procParam.index + 1, "00") & "]" 'ucDispJIG.convertIncNumberToMatrixValue(procParam.index) & "]" '[JIG No. : " & dispCh.DispChannel & "]"

        'IVLIndicatorDlg.Text = "IVL Sweep Indicator" & ucDispJIG.convertIncNumberToMatrixValue(procParam.index) & "]" '[JIG No. : " & dispCh.DispChannel & "]"
        IVLIndicatorDlg.ChannelInfo(procParam.index)
        IVLIndicatorDlg.SweepMode("Sweep IVL")

        IVLIndicator = IVLIndicatorDlg
        Dim measCnt As Integer = 0
        Dim spectrumCnt As Integer = 0
        Dim nTimeOutCnt As Integer = 0

        Dim nCh As Integer = procParam.index
        Dim dFillFactor As Double = procParam.sSampleInfos.dFillFactor
        Dim dSampleArea As Double = procParam.sSampleInfos.SampleSize.Width * procParam.sSampleInfos.SampleSize.Height / 100

        Dim measuredData() As frmMain.sCellIVLMeasureParams = Nothing
        Dim bufSpectrumData As CDevPR705.tData = Nothing
        Dim cDataQE As CDataQECal = New CDataQECal
        Dim cColorName As cDataColorName = New cDataColorName
        Dim nColor As cDataColorName.eColor
        Dim sMeteralValue As CDataQECal.sMaterial = Nothing

        'Dim dLumi As Double
        'Dim dQE As Double
        'Dim dFWHM As Double
        ' Dim dNormalData() As Double
        'Dim nELmax As Integer
        'Dim dcdA As Double
        'Dim dlmW As Double
        Dim spectrumMeasBiasList()() As Double = Nothing

        Dim nDevSwitch As Integer
        Dim nChOfSwitch As Integer

        Dim nDevKeithley As Integer
        Dim nChOfKeithley As Integer
        Dim nGroupTc As Integer
        Dim nDevTc As Integer
        Dim nChOfTc As Integer
        Dim sData(18) As String

        Dim Imsimeasdata As CDevSpectrometerCommonNode.tData = Nothing
        ' Dim ColorAnalyzeroutdata As CDevColorAnalyzerCommonNode.sDataInfos = Nothing

        nDevKeithley = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
        nChOfKeithley = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSMU_IVL)

        nGroupTc = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eGroupOfTC)
        nDevTc = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfTC)
        nChOfTc = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfTC)

        '*****1. GetSweepList *****
        If procParam.recipe.sIVLSweepInfo.sCommon.sweepType = ucDispRcpIVLSweep.eSweepType.eRGBPattern Then
            procParam.recipe.sIVLSweepInfo.sCommon.dSweepList = MakeRGBSweepList(procParam.recipe.sIVLSweepInfo.sCommon)
        Else
            procParam.recipe.sIVLSweepInfo.sCommon.dSweepList = MakeSweepList(procParam.recipe.sIVLSweepInfo.sCommon)
        End If

        IVLIndicatorDlg.StartPosition = FormStartPosition.CenterParent
        IVLIndicatorDlg.ShowFrame()
        IVLIndicatorDlg.dispGraph.PlotMode = ucDispGraph.eIVLPlotMode.eVvsC
        IVLIndicatorDlg.dispGraph2.PlotMode = ucDispGraph.eIVLPlotMode.eVvsCdm2
        IVLIndicatorDlg.dispGraph3.PlotMode = ucDispGraph.eIVLPlotMode.eQEvsCdm2
        IVLIndicatorDlg.dispGraph4.PlotMode = ucDispGraph.eIVLPlotMode.eVvsQE
        'IVLIndicatorDlg.dispGraph5.PlotMode = ucDispGraph.eIVLPlotMode.eQEvsCdm2
        'IVLIndicatorDlg.dispGraph6.PlotMode = ucDispGraph.eIVLPlotMode.eVvsABS_J

        IVLIndicatorDlg.dispListView.ClearAllData()

        '2. Spectrometer 모션 좌표 이동  채널좌표 Multi Point
        '////////////////////////////////////////////////
        If procParam.recipe.sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
            IVLIndicatorDlg.lblMeasStatus.Text = "Motion Moving"

            'Z축 위치를 모르기 때문에 상승을 먼저 시킨다. 이시스템에선 필요없을 듯
            ' fMain.frmMotionUI.ZMove(20, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)   'Z 축 상승

            Application.DoEvents()
            Thread.Sleep(100)

            ''Theta Y축 먼저 이동
            'If fMain.cMotion.SetPosition(g_motionPosThetaY(nCh)) = False Then
            '    IVLIndicatorDlg.Close()
            '    IVLIndicatorDlg.Dispose()
            '    IVLIndicator = Nothing
            '    Return False
            'End If

            'X,Y축 먼저 움직이고 Z축 이동 - Detector Mode
            If procParam.recipe.sIVLSweepInfo.sCommon.DetectorMode = ucDispRcpIVLSweep.eDetectorMode.eNormal Then
                If fMain.cMotion.SetPositionXYAxisMovingFirst(g_motionPosSpectrometer(nCh)) = False Then
                    IVLIndicatorDlg.Close()
                    IVLIndicatorDlg.Dispose()
                    IVLIndicator = Nothing
                    Return False
                End If
            ElseIf procParam.recipe.sIVLSweepInfo.sCommon.DetectorMode = ucDispRcpIVLSweep.eDetectorMode.eFast Then
                If fMain.cMotion.SetPositionXYAxisMovingFirst(g_motionPosColorAnalyzer(nCh)) = False Then
                    IVLIndicatorDlg.Close()
                    IVLIndicatorDlg.Dispose()
                    IVLIndicator = Nothing
                    Return False
                End If
            End If

            'fMain.cMotion.MoveCompletedAllAxis()
            'fMain.cMotion.MoveCompletedAllAxis()
            Application.DoEvents()
            Thread.Sleep(100)

            'Angle축 이동
            'If fMain.cMotion.ViewAngleMove(procParam.recipe.sIVLSweepInfo.sCommon.dViewingAngle, True) = False Then  '각도 거리, 상대이동 = True = False Then
            '    Exit Sub
            'End If

            'fMain.cMotion.MoveCompletedAllAxis()
            'Application.DoEvents()
            'Thread.Sleep(100)

            '  Dim nAperture As Integer = g_SystemOptions.sOptionData.IVLSpectrometer.nAperture
            '  Dim nSpeedMode As Integer = g_SystemOptions.sOptionData.IVLSpectrometer.nSpeedMode

            'CS2000 Aperture Manaul 조절
            If fMain.cSpectormeter(0).mySpectrometer.SetAperture(nAperture) = False Then
                fMain.g_StateMsgHandler.messageToUserErrorCode(nCh, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "SetAperture")
                IVLIndicatorDlg.Close()
                IVLIndicatorDlg.Dispose()
                IVLIndicator = Nothing
                Return False
            End If

            If fMain.cSpectormeter(0).mySpectrometer.Model = CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000 Then
                If g_SystemOptions.sOptionData.Spectrometer.nSpeedMode = 0 Then
                    nSpeedMode = 1
                End If
            ElseIf fMain.cSpectormeter(0).mySpectrometer.Model = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR655 Or fMain.cSpectormeter(0).mySpectrometer.Model = CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR670 Then
                If nSpeedMode = 0 Then
                    nSpeedMode = 0
                ElseIf nSpeedMode = 1 Then
                    nSpeedMode = g_SystemOptions.sOptionData.IVLSpectrometer.nExposureTime
                End If
            ElseIf fMain.cSpectormeter(0).mySpectrometer.Model = CDevSpectrometerCommonNode.eModel.SPECTROMETER_SR3AR Then
                '220830 Update by JKY : NEED CHECK
            End If

            If fMain.cSpectormeter(0).mySpectrometer.SetMeasSpeed(nSpeedMode) = False Then
                fMain.g_StateMsgHandler.messageToUserErrorCode(nCh, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "SetSpeedMode")
                IVLIndicatorDlg.Close()
                IVLIndicatorDlg.Dispose()
                IVLIndicator = Nothing
                Return False
            End If

        Else
            IVLIndicatorDlg.lblMeasStatus.Text = "IV Sweep Starting"
        End If

        If fMain.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellColor_ON = Color.Lime
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellStatus = ucDispSampleCommonNode.eCellState.eON
        End If

        '10. 스위칭 장비 All Off
        'For i As Integer = 0 To fMain.cSwitch.Length - 1
        '    For ch As Integer = 0 To g_nMaxCh - 1
        '        If fMain.cSwitch(i).mySwitch.SwitchOFF(ch) = False Then
        '            IVLIndicatorDlg.Close()
        '            IVLIndicatorDlg.Dispose()
        '            IVLIndicator = Nothing
        '        End If
        '    Next
        'Next

        '안씀
        'If fMain.cIVLSMU(nDevKeithley).mySMU.OutputOff() = False Then
        '    '   MsgBox("Bias Setting Error...")
        '    IVLIndicatorDlg.Close()
        '    IVLIndicatorDlg.Dispose()
        '    IVLIndicator = Nothing
        '    Return False
        'End If

        ReDim fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)
        ReDim fMain.g_MeasuredDatas(nCh).sCellIVLParams.sArrySpectrometer(0)
        ReDim fMain.g_MeasuredDatas(nCh).sCellIVLParams.sNormalSpectrometer(0)
        ReDim spectrumMeasBiasList(0)

        '  For colorIdx As Integer = 0 To procParam.recipe.sIVLSweepInfo.sCommon.nColorList.Length - 1

        measCnt = 0
        spectrumCnt = 0
        IVLIndicatorDlg.dispListView.ClearAllData()
        ReDim Preserve fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt)
        ' ReDim fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(measCnt)
        ' ReDim fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sSpectrometer(measCnt)
        ' ReDim spectrumMeasBiasList(spectrumCnt)

        Select Case procParam.recipe.sIVLSweepInfo.sCommon.nColorList(0) 'NEED CHECK
            Case ucMeasureColorList.eColor._Red
                nDevSwitch = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
                nChOfSwitch = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfSwitch)
        End Select

        'If fMain.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch + 64) = False Then
        '    IVLIndicatorDlg.Close()
        '    IVLIndicatorDlg.Dispose()
        '    IVLIndicator = Nothing

        '    Return False
        'End If
        ' 4. SW장비 Ch On
        'Thread.Sleep(10)
        'If fMain.cSwitch(nDevSwitch).mySwitch.SwitchON(nChOfSwitch) = False Then
        '    '예외처리
        '    IVLIndicatorDlg.Close()
        '    IVLIndicatorDlg.Dispose()
        '    IVLIndicator = Nothing
        '    Return False
        'End If

        '2. SMU 초기화  '안씀
        'If fMain.cIVLSMU(nDevKeithley).mySMU.InitializeSweep(procParam.recipe.sIVLSweepInfo.sKeithleyInfos) = False Then
        '    '   MsgBox("SMU 초기화 오류")
        '    IVLIndicatorDlg.Close()
        '    IVLIndicatorDlg.Dispose()
        '    IVLIndicator = Nothing
        '    Return False
        'End If

        ' 휘도계 Range 초기화  빛이 없는 상태 Dark를 측정하면 Rangel 초기화 됨   PSI업체 휘도계
        'If fMain.cSpectormeter(0).mySpectrometer.MeasureFixedAperture(Imsimeasdata) = False Then
        '    fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "Source off Measure")
        'End If

        '5. 초기 Bias Setting

        Dim nFactor As Integer = 1

        If procParam.recipe.sIVLSweepInfo.sCommon.dBiasInvert = True Then
            nFactor = -1
        Else
            nFactor = 1
        End If

        '안씀
        'If fMain.cIVLSMU(nDevKeithley).mySMU.SetBias(procParam.recipe.sIVLSweepInfo.sCommon.dSweepList(measCnt) * nFactor) = False Then
        '    '   MsgBox("Bias Setting Error...")
        '    IVLIndicatorDlg.Close()
        '    IVLIndicatorDlg.Dispose()
        '    IVLIndicator = Nothing
        '    Return False
        'End If

        '6. IVL Sweep
        If procParam.recipe.sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
            IVLIndicatorDlg.lblMeasStatus.Text = "IVL Sweep"
        Else

            IVLIndicatorDlg.lblMeasStatus.Text = "IV Sweep"
        End If

        Dim bCheckedIVLLoopState As Boolean = True

        Do

            bCheckedIVLLoopState = True

            If IVLIndicatorDlg.IsStopIVL = True Or fMain.g_SweepStop(nCh) = True Then
                Exit Do
            End If

            Application.DoEvents()
            Thread.Sleep(1)

            '  ReDim Preserve fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(measCnt)
            ReDim Preserve fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt)

            IVL_I = 0
            IVL_V = 0

            If procParam.recipe.sIVLSweepInfo.sCommon.sweepMethod = ucDispRcpIVLSweep.eSweepMethod.ePulse Then
                If fMain.cIVLSMU(nDevKeithley).mySMU.SetBias(0) = False Then
                    '예외처리
                    bCheckedIVLLoopState = False
                    Exit Do
                End If

            ElseIf procParam.recipe.sIVLSweepInfo.sCommon.sweepMethod = ucDispRcpIVLSweep.eSweepMethod.ePulse_N_Offset Then
                If fMain.cIVLSMU(nDevKeithley).mySMU.SetBias(procParam.recipe.sIVLSweepInfo.sCommon.dOffsetBias) = False Then
                    '예외처리
                    bCheckedIVLLoopState = False
                    Exit Do
                End If
            Else

            End If

            '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '8.1 Sweeplist  Bias setting
            Try
                If fMain.cIVLSMU(nDevKeithley).mySMU.SetBias(procParam.recipe.sIVLSweepInfo.sCommon.dSweepList(measCnt) * nFactor) = False Then
                    '   MsgBox("Bias Setting Error...")
                    fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "SMU Set Bias Error")
                    bCheckedIVLLoopState = False
                    Exit Do
                End If
            Catch ex As Exception
                MsgBox("Bias Setting Error...")
            End Try



            '8.2 Measdelay K2635를 제외하고 K24XX, K23X는 장비의 Measdelay 설정 부분이 없음.
            Application.DoEvents()
            Thread.Sleep(procParam.recipe.sIVLSweepInfo.sCommon.dMeasureDelay)

            '8.3 Voltage, Current Meas  2번 읽음 초기 측정 데이터 문제 발생 방지
            Try
                If fMain.cIVLSMU(nDevKeithley).mySMU.Measure(IVL_V, IVL_I) = False Then
                    Thread.Sleep(500)
                    If fMain.cIVLSMU(nDevKeithley).mySMU.Measure(IVL_V, IVL_I) = False Then
                        fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "SMU Failed")
                        bCheckedIVLLoopState = False
                        Exit Do
                    End If
                End If
            Catch ex As Exception
                fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "SMU Failed")
                'Thread.Sleep(500)
                'If fMain.cIVLSMU(nDevKeithley).mySMU.Measure(IVL_V, IVL_I) = False Then
                '    fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Function_Error, "SMU Failed")
                '    bCheckedIVLLoopState = False
                '    Exit Do
                'End If
            End Try

            'JKY test
            Try
                For i = 0 To 4
                    fMain.cIVLPowerSupply(i).Volt = 10
                    fMain.cIVLPowerSupply(i).Current = 10
                Next
            Catch ex As Exception

            End Try


            If fMain.cIVLSMU(nDevKeithley).mySMU.Measure(IVL_V, IVL_I) = False Then
                bCheckedIVLLoopState = False
                Exit Do
            End If

            With fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt)
                .nMeasMode = ucDispRcpIVLSweep.eMeasureItems.eIV
                .nCh = nCh
                .dVoltage = Format(IVL_V, "0.000")
                .dCurrent = Format(IVL_I * 1000, "0.000") 'Format(IVL_I, "0.00E-0")
                .dAbs_Current_Log = Format(Math.Log10(Math.Abs(.dCurrent)), "0.00E-0")
                .dArea_cm = dSampleArea
                .dJ = Format((IVL_I * 1000) / ((dSampleArea * dFillFactor) / 100), "0.000") '(dI * 1000)'Format((IVL_I * 1000) / ((dSampleArea * dFillFactor) / 100), "0.00E-0")      '(dI * 1000),  // 전류는 mA로 읽고있음  Unit : mA/cm2
                ' .dJ = Format((IVL_I * 1000) / ((dSampleArea * 100) / 100), "0.00000E-0")
                .dAbs_J = Math.Abs(.dJ)
                .dABS_I = Math.Abs(.dCurrent)
                .dTemperature = fMain.g_MeasuredDatas(nCh).dTemp 'cTC(nGroupTc).MeasuredData(nDevTc, nChOfTc).measTemp
                .dAngle = procParam.recipe.sIVLSweepInfo.sCommon.dViewingAngle
            End With

            '8.4 Measurement Data of Spectrometer
            If procParam.recipe.sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
                If procParam.recipe.sIVLSweepInfo.sCommon.dSweepList(measCnt) >= procParam.recipe.sIVLSweepInfo.sCommon.dLMeasLevel Then
                    '    If procParam.recipe.sIVLSweepInfo.sCommon.dSweepList(measCnt) >= procParam.recipe.sIVLSweepInfo.sCommon.sMeasureSweepParameter(measCnt).nLevel / 1000 Then
                    IVLIndicatorDlg.lblMeasStatus.Text = "L Meas."

                    ReDim Preserve fMain.g_MeasuredDatas(nCh).sCellIVLParams.sArrySpectrometer(0)(spectrumCnt)
                    ReDim Preserve fMain.g_MeasuredDatas(nCh).sCellIVLParams.sNormalSpectrometer(spectrumCnt)
                    ReDim Preserve spectrumMeasBiasList(0)(spectrumCnt)

                    spectrumMeasBiasList(0)(spectrumCnt) = procParam.recipe.sIVLSweepInfo.sCommon.dSweepList(measCnt)

                    Dim measData As CDevSpectrometerCommonNode.tData = Nothing
                    Dim nWavelengthInterval As Integer = Nothing

                    'If procParam.recipe.sIVLSweepInfo.sCommon.DetectorMode = ucDispRcpIVLSweep.eDetectorMode.eNormal Then
                    '    If MeasureSpectrometer(nCh, measData, 0, nSpeedMode) = False Then
                    '        SpecMeasChk = True
                    '        fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellColor_OFF = Color.Orange
                    '        fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellStatus = ucDispSampleCommonNode.eCellState.eOFF
                    '        fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).Information = "Spec Meas Fail"
                    '        bCheckedIVLLoopState = False

                    '        ReDim Preserve fMain.g_MeasuredDatas(nCh).sCellIVLParams.sArrySpectrometer(0)(spectrumCnt - 1)
                    '        ReDim Preserve fMain.g_MeasuredDatas(nCh).sCellIVLParams.sNormalSpectrometer(spectrumCnt - 1)
                    '        ReDim Preserve spectrumMeasBiasList(0)(spectrumCnt - 1)

                    '        Exit Do
                    '    End If

                    'measData.D6.s2YY
                    'If m_bCapture = False Then
                    '    ' Dim lumiRange As Double = g_SystemOptions.sOptionData.CCDData.dCaptureLevel * 0.1
                    '    If measData.D6.s2YY >= g_SystemOptions.sOptionData.CCDData.dCaptureLevel Then
                    '        Dim FileName As String = procParam.CommonInfo.saveInfo.strOnlyFName & "_" & ucDispJIG.convertIncPixel(nCh) & "_CAM_Volt_" & fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dVoltage & "_Lumi_" & measData.D6.s2YY
                    '        fMain.cScreenCapture.CaptureImage(FileName)
                    '        m_bCapture = True
                    '    End If
                    'End If

                    If DataProcessToResultData(procParam, measData, measCnt, spectrumCnt) = False Then
                        bCheckedIVLLoopState = False
                        Exit Do
                    End If

                    spectrumCnt += 1
                    'If measData.D5.i3nm Is Nothing = False Then
                    '    fMain.g_MeasuredDatas(nCh).sCellIVLParams.sArrySpectrometer(0)(spectrumCnt) = measData

                    '    dLumi = dLumi * procParam.recipe.sIVLSweepInfo.sCommon.dLumiCorrection * 0.01 'g_SystemOptions.sOptionData.SaveOptions.dLumiCorrection * 0.01
                    '    measData.D6.s2YY = measData.D6.s2YY * procParam.recipe.sIVLSweepInfo.sCommon.dLumiCorrection * 0.01 'g_SystemOptions.sOptionData.SaveOptions.dLumiCorrection * 0.01

                    '    dLumi = measData.D6.s2YY * 100 / dFillFactor

                    '    '# Calculation cd/A
                    '    '  dcdA = dLumi / (((IVL_I * 1000) / (dSampleArea * 100) * 100) * 10)
                    '    dcdA = dLumi / (fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dJ * 10)

                    '    '# Calculation lm/W
                    '    dlmW = dcdA / IVL_V * Math.PI

                    '    ' dQE = CData.QuantumEfficiency(SweepSet.dCellArea_cm, dI, SpectrumData(spectrumCnt).D5.s4Intensity)
                    '    '스펙트럼 간격별로 QE계산 함수 호출 할 수 있도록 변경 해야 함.
                    '    nWavelengthInterval = measData.D5.i3nm(1) - measData.D5.i3nm(0)

                    '    dQE = cDataQE.QuantumEfficiency(dLumi, fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(0)(measCnt).dJ, dSampleArea, measData.D5.s4Intensity, nWavelengthInterval)

                    '    'Cal Normalization

                    '    fMain.g_MeasuredDatas(nCh).sCellIVLParams.sNormalSpectrometer(spectrumCnt) = cDataQE.DataNormalization(measData.D5.s4Intensity, nELmax)

                    '    'Cal FWHM
                    '    cDataQE.Cal_FWHM(nELmax, fMain.g_MeasuredDatas(nCh).sCellIVLParams.sNormalSpectrometer(spectrumCnt), measData.D5.i3nm, dFWHM)

                    '    ' fMain.g_MeasuredDatas(nCh).sCellIVLParams.sNormalSpectrometer(spectrumCnt) = dNormalData.Clone

                    '    '*************************************************************************************
                    '    With fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt)

                    '        .nMeasMode = ucDispRcpIVLSweep.eMeasureItems.eIVL
                    '        .dCdA = Format(dcdA, "0.0000")
                    '        .dLuminance_Fill_Cdm2 = Format(dLumi, "0.000")
                    '        .dLuminance_Cdm2 = Format(measData.D6.s2YY, "0.000")
                    '        .dCIEx = Format(measData.D6.s3xx, "0.0000") '1931
                    '        .dCIEy = Format(measData.D6.s4yy, "0.0000")
                    '        .dCIEu = Format(measData.D6.s5uu, "0.0000") '1976
                    '        .dCIEv = Format(measData.D6.s6vv, "0.0000")
                    '        .dCCT = Format(measData.D4.s3KelvinT, "0.0000")
                    '        .dlmW = Format(dlmW, "0.0000")
                    '        .dQE = Format(dQE, "0.0000")
                    '        .dFWHM = Format(dFWHM, "0.0")

                    '        .dX = Format(measData.D2.s2XX, "0.000")
                    '        .dY = Format(measData.D2.s3YY, "0.000")
                    '        .dZ = Format(measData.D2.s4ZZ, "0.000")

                    '        .dDelta_CIE1960 = Format(measData.D4.s4DevOfColorCoord, "0.0000E-0")
                    '        .dLe = Format(measData.D5.s2IntegIntensity, "0.0000")

                    '    End With

                    'End If

                    'SDC 기흥 고삼일 수석 적용 Color
                    '요구휘도 Cal(SDC기준) 계산해서 구동 전류 값을 Interpolation  시킨다... 마지막 포인트로 계산을 하면 된다.
                    'If measCnt + 1 > procParam.recipe.sIVLSweepInfo.sCommon.dSweepList.Length - 1 Then
                    '    'Color 분석
                    '    If cColorName.ColorAnalysis(measData.D6.s3xx, measData.D6.s4yy, nColor) = False Then
                    '        '예외처리
                    '    End If

                    '    cDataQE.BrightnessRequirementsCalculationToRealCurrent(g_SystemOptions.sOptionData.MaterialData, sMeteralValue, fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure, measData.D6.s3xx, measData.D6.s4yy, nColor)

                    '    With fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt)
                    '        .sMeteralValue.sRed.dBrightnessRequirements = Format(sMeteralValue.sRed.dBrightnessRequirements, "0.0")
                    '        .sMeteralValue.sGreen.dBrightnessRequirements = Format(sMeteralValue.sGreen.dBrightnessRequirements, "0.0")
                    '        .sMeteralValue.sBlue.dBrightnessRequirements = Format(sMeteralValue.sBlue.dBrightnessRequirements, "0.0")
                    '        .sMeteralValue.sWhite.dBrightnessRequirements = Format(sMeteralValue.sWhite.dBrightnessRequirements, "0.0")
                    '        .sMeteralValue.sRed.dLuminanceRatio = Format(sMeteralValue.sRed.dLuminanceRatio, "0.0")
                    '        .sMeteralValue.sGreen.dLuminanceRatio = Format(sMeteralValue.sGreen.dLuminanceRatio, "0.0")
                    '        .sMeteralValue.sBlue.dLuminanceRatio = Format(sMeteralValue.sBlue.dLuminanceRatio, "0.0")
                    '        .sMeteralValue.sWhite.dLuminanceRatio = Format(sMeteralValue.sWhite.dLuminanceRatio, "0.0")
                    '        .sMeteralValue.sColorName = sMeteralValue.sColorName
                    '        .sMeteralValue.dRealCurrent = sMeteralValue.dRealCurrent
                    '    End With

                    'End If

                    'ElseIf procParam.recipe.sIVLSweepInfo.sCommon.DetectorMode = ucDispRcpIVLSweep.eDetectorMode.eFast Then

                    '    If fMain.cColorAnalyzer(0).myColorAnalyzer.DeviceInfos.sHEXA50Settings.Mode = CDevHEXA50.eMeasMode.eAuto Then
                    '        If fMain.cColorAnalyzer(0).myColorAnalyzer.AutoRangeMeasure(ColorAnalyzeroutdata) = False Then
                    '            bCheckedIVLLoopState = False
                    '            Exit Do
                    '        End If
                    '    ElseIf fMain.cColorAnalyzer(0).myColorAnalyzer.DeviceInfos.sHEXA50Settings.Mode = CDevHEXA50.eMeasMode.eManual Then
                    '        If fMain.cColorAnalyzer(0).myColorAnalyzer.Measure(ColorAnalyzeroutdata) = False Then
                    '            bCheckedIVLLoopState = False
                    '            Exit Do
                    '        End If
                    '    End If

                    '    Dim UserCalColorAnalyzeroutdata As CDevColorAnalyzerCommonNode.sDataInfos = Nothing
                    '    Dim KFactorIndex As Integer = fMain.cColorAnalyzer(0).myColorAnalyzer.DeviceInfos.sHEXA50Settings.nKFactorIndx
                    '    Dim KFactor(,) As Double = fMain.cColorAnalyzer(0).myColorAnalyzer.DeviceInfos.sHEXA50Settings.CalibrationData(KFactorIndex).KFactor
                    '    Dim useUserCal As Boolean

                    '    If useUserCal = True Then
                    '        fMain.UserCalibrationDataProcess(ColorAnalyzeroutdata, KFactor, UserCalColorAnalyzeroutdata) '매트릭스  userkfactor 처리
                    '        DataProcessToResultData(procParam, UserCalColorAnalyzeroutdata, measCnt)
                    '    Else
                    '        DataProcessToResultData(procParam, ColorAnalyzeroutdata, measCnt)
                    '    End If
                    'End If
                Else
                    IVLIndicatorDlg.lblMeasStatus.Text = "IV Meas."
                End If

            Else
                IVLIndicatorDlg.lblMeasStatus.Text = "IV Meas."
            End If

            'Col 추가 필요 CIEu', CIEv', CCT, 등

            fMain.g_DataSaver(nCh).ConvertIVLDataToArray(fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt), measCnt, sData, False) '20151015 CJS 데이터 Indexing 

            IVLIndicatorDlg.dispListView.AddRowData(sData)
            IVLIndicatorDlg.dispGraph.SetPlotData(fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(0))
            IVLIndicatorDlg.dispGraph.PlotIVLData()
            IVLIndicatorDlg.dispGraph2.SetPlotData(fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(0))
            IVLIndicatorDlg.dispGraph2.PlotIVLData()
            IVLIndicatorDlg.dispGraph3.SetPlotData(fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(0))
            IVLIndicatorDlg.dispGraph3.PlotIVLData()
            IVLIndicatorDlg.dispGraph4.SetPlotData(fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(0))
            IVLIndicatorDlg.dispGraph4.PlotIVLData()
            'IVLIndicatorDlg.dispGraph5.SetPlotData(fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(0))
            'IVLIndicatorDlg.dispGraph5.PlotIVLData()
            'IVLIndicatorDlg.dispGraph6.SetPlotData(fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(0))
            'IVLIndicatorDlg.dispGraph6.PlotIVLData()

            If procParam.recipe.sIVLSweepInfo.sCommon.LimitCompareAnd = True Then
                If procParam.recipe.sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIV Then
                    If procParam.recipe.sIVLSweepInfo.sCommon.dCurrentLimit < fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dCurrent * 1000 Then
                        Exit Do
                    End If

                ElseIf procParam.recipe.sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
                    If procParam.recipe.sIVLSweepInfo.sCommon.dSweepList(measCnt) >= procParam.recipe.sIVLSweepInfo.sCommon.dLMeasLevel Then
                        If procParam.recipe.sIVLSweepInfo.sCommon.dCurrentLimit < fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dCurrent * 1000 And procParam.recipe.sIVLSweepInfo.sCommon.dLMeasLimit < fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dLuminance_Cdm2 Then
                            Exit Do
                        End If
                    End If
                End If
            Else
                'Current Limit 조건 판단   측정 전류가 크면 종료 시킨다...  mA
                If procParam.recipe.sIVLSweepInfo.sCommon.dCurrentLimit < fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dCurrent Then
                    Exit Do
                End If

                'Luminance Limit 조건 판단   측정 휘도가 크면 종료 시킨다...
                If procParam.recipe.sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
                    If procParam.recipe.sIVLSweepInfo.sCommon.dSweepList(measCnt) >= procParam.recipe.sIVLSweepInfo.sCommon.dLMeasLevel Then
                        If procParam.recipe.sIVLSweepInfo.sCommon.dLMeasLimit < fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dLuminance_Cdm2 Then
                            Exit Do
                        End If
                    End If
                End If
            End If

            'Voltage Seq Limit Condition
            If procParam.CommonInfo.sLimits(0).LimitValue.dMin >= fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dVoltage Then
                LimitChk = True
                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellColor_OFF = Color.Red
                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellStatus = ucDispSampleCommonNode.eCellState.eOFF
                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).Information = "Sequence Voltage Limit"
                Exit Do
            End If

            'Voltage Seq Limit Condition
            If procParam.CommonInfo.sLimits(0).LimitValue.dMax <= fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dVoltage Then
                LimitChk = True
                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellColor_OFF = Color.Red
                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellStatus = ucDispSampleCommonNode.eCellState.eOFF
                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).Information = "Sequence Voltage Limit"
                Exit Do
            End If

            'Current Seq Limit Condition
            If procParam.CommonInfo.sLimits(1).LimitValue.dMin >= fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dCurrent Then
                LimitChk = True
                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellColor_OFF = Color.Red
                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellStatus = ucDispSampleCommonNode.eCellState.eOFF
                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).Information = "Sequence Current Limit"
                Exit Do
            End If

            'Current Seq Limit Condition
            If procParam.CommonInfo.sLimits(1).LimitValue.dMax <= fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dCurrent Then
                LimitChk = True
                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellColor_OFF = Color.Red
                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellStatus = ucDispSampleCommonNode.eCellState.eOFF
                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).Information = "Sequence Current Limit"
                Exit Do
            End If
            measCnt += 1

            Application.DoEvents()
            Thread.Sleep(5)

        Loop Until measCnt > procParam.recipe.sIVLSweepInfo.sCommon.dSweepList.Length - 1 'g_SweepSet.dBiasList.Length - 1

        'Loop Check Flag
        If bCheckedIVLLoopState = False Then
            IVLIndicatorDlg.Close()
            IVLIndicatorDlg.Dispose()
            IVLIndicator = Nothing
            'Return False
        End If

        '  Next

        '10. SW장비 Off
        'If fMain.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch) = False Then
        '    '예외처리
        '    IVLIndicatorDlg.Close()
        '    IVLIndicatorDlg.Dispose()
        '    IVLIndicator = Nothing

        '    Return False
        'End If

        '11. Keithley 
        If fMain.cIVLSMU(nDevKeithley).mySMU.FinalizeSweep() = False Then
            '예외처리
            IVLIndicatorDlg.Close()
            IVLIndicatorDlg.Dispose()
            IVLIndicator = Nothing

            Return False
        End If

        '' 휘도계 Range 초기화 빛이 없는 상태 Dark를 측정하면 Rangel 초기화 됨   PSI업체 휘도계
        'If fMain.cSpectormeter(0).mySpectrometer.MeasureFixedAperture(Imsimeasdata) = False Then
        '    fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "Source off Measure")
        'End If

        '==========================================================================================================================================================================
        'If IVLIndicatorDlg.IsStopIVL = False And fMain.g_SweepStop(nCh) = False Then
        '12.  DataSave

        'Create Save File
        fMain.g_DataSaver(nCh).CreateSaveFile(procParam.recipe.recipeIndex, True)

        'SaveIVLDataHeader
        fMain.g_DataSaver(nCh).SaveHeaderInfoOfIVL(procParam.recipe.recipeIndex, procParam.recipe, dSampleArea, dFillFactor)

        'SavePeakDataHeader
        ' fMain.g_DataSaver(nCh).SaveHeaderInfoOfIVLPeak(procParam.recipe.recipeIndex, procParam.recipe, dSampleArea, dFillFactor)

        If g_SystemOptions.sOptionData.SaveOptions.nFileType = cDataOutput.eFileType.eCSV Then
            'Save data
            If fMain.g_DataSaver(nCh).SaveDataIVL(procParam.recipe, fMain.g_MeasuredDatas(procParam.index).sCellIVLParams) = False Then
                Return False
                '예외처리
            End If
            '    ImageLevelCapture(procParam, fMain.g_MeasuredDatas(procParam.index).sCellIVLParams)

            If procParam.recipe.sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
                If fMain.g_DataSaver(nCh).SaveIVLSpectrumData(procParam.recipe, fMain.g_MeasuredDatas(procParam.index).sCellIVLParams, spectrumMeasBiasList) = False Then
                    If fMain.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
                        If LimitChk = False And SpecMeasChk = False Then
                            fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellColor_OFF = Color.Black
                            fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellStatus = ucDispSampleCommonNode.eCellState.eOFF
                        End If
                    End If
                    IVLIndicatorDlg.Close()
                    IVLIndicatorDlg.Dispose()
                    IVLIndicator = Nothing
                    '  m_bCapture = False
                    Return True
                    '예외처리
                End If
            End If

        ElseIf g_SystemOptions.sOptionData.SaveOptions.nFileType = cDataOutput.eFileType.eExcel Then
            'Save
            If fMain.g_DataSaver(nCh).SaveDataIVLExcel(procParam.recipe, fMain.g_MeasuredDatas(procParam.index).sCellIVLParams, spectrumMeasBiasList, g_SystemOptions.sOptionData.SaveOptions.bCalRealCurrentSave) = False Then
                Return False
                '예외처리
            End If
        End If

        'End If

        'Z축 위치를 모르기 때문에 상승을 먼저 시킨다
        ' fMain.cMotion.ViewAngleMove(0, True) '시야각 0'로 이동
        'fMain.cMotion.ZMove(10, True)   'Z 축 상승
        'fMain.cMotion.MoveCompletedAllAxis()
        'Application.DoEvents()
        'Thread.Sleep(100)
        If fMain.m_bThetaAxisUsed = True Then
            fMain.cMotion.ViewAngleMove(0, True) '시야각 0'로 이동
        End If

        fMain.cMotion.ZMove(20, True)   'Z 축 상승
        Thread.Sleep(100)
        '==========================================================================================================================================================================

        If fMain.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
            If LimitChk = False And SpecMeasChk = False Then
                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellColor_OFF = Color.Black
                fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellStatus = ucDispSampleCommonNode.eCellState.eOFF
            End If
        End If

        IVLIndicatorDlg.Close()
        IVLIndicatorDlg.Dispose()
        IVLIndicator = Nothing
        ' m_bCapture = False

        Return True

    End Function

    Public Sub AngleSweepRoutine(ByVal procParam As sProcessParams, ByRef IVLIndicator As frmIVLDisplay)

        Dim IVL_V As Double
        Dim IVL_I As Double

        Dim IVLIndicatorDlg As frmIVLDisplay = New frmIVLDisplay(procParam.recipe.nMode)

        Dim dispCh As New CChDisp

        dispCh.ChannelNo = procParam.index
        dispCh.DispType = CChDisp.eChannelDispType.eJIGAndCellNo

        ' IVLIndicatorDlg.Text = "Angle Sweep Indicator" & " [Channel : " & Format(procParam.index + 1, "000") & "] [JIG No. : " & dispCh.DispChannel & "]"

        IVLIndicatorDlg.Text = "Angle Sweep Indicator" & " [TEG : " & Format(procParam.index + 1, "00") & "]" 'ucDispJIG.convertIncNumberToMatrixValue(procParam.index) & "]" '[JIG No. : " & dispCh.DispChannel & "]"

        IVLIndicator = IVLIndicatorDlg
        Dim measCnt As Integer = 0
        Dim nTimeOutCnt As Integer = 0

        Dim nCh As Integer = procParam.index
        Dim dFillFactor As Double = procParam.sSampleInfos.dFillFactor
        Dim dSampleArea As Double = procParam.sSampleInfos.SampleSize.Width * procParam.sSampleInfos.SampleSize.Height / 100

        Dim measuredData() As frmMain.sCellIVLMeasureParams = Nothing
        Dim cDataQE As CDataQECal = New CDataQECal

        Dim dLumi As Double
        Dim dQE As Double
        Dim dcdA As Double
        Dim dRef_Luminance As Double
        Dim dRef_ud As Double
        Dim dRef_vd As Double

        ' Dim dlmW As Double
        Dim spectrumMeasAngleList()() As Double = Nothing

        Dim nWavelengthInterval As Integer = Nothing
        Dim measData As CDevSpectrometerCommonNode.tData = Nothing
        Dim buffMeasValOfM6000 As CDevM6000PLUS.sMeasParams = Nothing
        Dim nDevNo6000 As Integer
        Dim nChNoM6000 As Integer

        nDevNo6000 = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
        nChNoM6000 = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eChOfM6000)


        Dim sData(23) As String

        Dim settings As CDevM6000PLUS.sSettingParams
        Dim Imsimeasdata As CDevSpectrometerCommonNode.tData = Nothing

        '   Dim MeasValOfM6000() As CDevM6000.sMeasParams = Nothing

        '***** GetSweepList *****
        '1. Angle SweepList로 변경 해야 함...... 확인 해야 함..... List를 여기서 만들 것인지.....시퀀스 파일 로드 할 때 만들 것인지...
        'procParam.recipe.sViewingAngleInfo.sCommon.dSweepList = MakeSweepList(procParam.recipe.sViewingAngleInfo.sCommon.sMeasureSweepParameter)

        IVLIndicatorDlg.StartPosition = FormStartPosition.CenterParent
        IVLIndicatorDlg.ShowFrame()
        IVLIndicatorDlg.dispGraph.PlotMode = ucDispGraph.eIVLPlotMode.eAnglevsCdm2
        IVLIndicatorDlg.dispListView.ClearAllData()

        '3. Spectrometer 모션 좌표 이동  채널좌표 Multi Point
        '////////////////////////////////////////////////
        '   If procParam.recipe.sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
        IVLIndicatorDlg.lblMeasStatus.Text = "Angle Sweep 대기 중"

        'Z축 위치를 모르기 때문에 상승을 먼저 시킨다
        fMain.cMotion.ZMove(10, True)   'Z 축 상승
        fMain.cMotion.MoveCompletedAllAxis()
        Application.DoEvents()
        Thread.Sleep(100)

        IVLIndicatorDlg.lblMeasStatus.Text = "Motion Moving"

        'X,Y축 먼저 움직이고 Z축 이동
        'IVLIndicatorDlg.lblMeasStatus.Text = "Motion Moveing"
        If fMain.cMotion.SetPositionXYAxisMovingFirst(g_motionPosSpectrometer(nCh)) = False Then
            Exit Sub
        End If
        fMain.cMotion.MoveCompletedAllAxis()
        Application.DoEvents()
        Thread.Sleep(100)

        '6. UI
        If fMain.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellColor_ON = Color.Lime
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellStatus = ucDispSampleCommonNode.eCellState.eON
        End If

        '7. 초기화 및 Bias Setting
        IVLIndicatorDlg.lblMeasStatus.Text = "Bias Setting"

        Dim nColorCnt As Integer = 0

        ' 휘도계 Range 초기화  빛이 없는 상태 Dark를 측정하면 Rangel 초기화 됨   PSI업체 휘도계
        If fMain.cSpectormeter(0).mySpectrometer.MeasureFixedAperture(Imsimeasdata) = False Then
            fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "Source off Measure")
        End If

        SetSourceOfM6000(nCh, procParam.recipe.sViewingAngleInfo.sCellInfos, procParam.CommonInfo.sLimits)

        CompletedSettingsAllChOfM6000(nCh, 10, CSeqRoutineM6000.eSequenceState.eMeasuring, procParam.recipe.sViewingAngleInfo.sCellInfos)


        ReDim fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)
        ReDim fMain.g_MeasuredDatas(nCh).sCellIVLParams.sArrySpectrometer(0)
        ReDim spectrumMeasAngleList(0)
        '8. IVL Sweep
        Do

            If IVLIndicatorDlg.IsStopIVL = True Or fMain.g_SweepStop(nCh) = True Then
                Exit Do
            End If

            Application.DoEvents()
            Thread.Sleep(1)

            'IVL Sweep 정지 시 플래그 필요
            ReDim Preserve fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt)
            ReDim Preserve fMain.g_MeasuredDatas(nCh).sCellIVLParams.sArrySpectrometer(0)(measCnt)

            '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '8.1 Sweeplist  Angle setting
            'Angle축 이동
            IVLIndicatorDlg.lblMeasStatus.Text = "Angle Move"
            If fMain.cMotion.ViewAngleMove(procParam.recipe.sViewingAngleInfo.sCommon.dSweepList(measCnt), True) = False Then  '각도 거리, 상대이동 = True = False Then
                Exit Sub
            End If
            fMain.cMotion.MoveCompletedAllAxis()
            Application.DoEvents()
            Thread.Sleep(100)

            '8.2 IV Meas
            IVLIndicatorDlg.lblMeasStatus.Text = "IVL Meas."

            buffMeasValOfM6000 = GetMeasuredDatasOfM60000(nCh)

            IVL_V = buffMeasValOfM6000.dVoltage_Bias
            IVL_I = buffMeasValOfM6000.dCurrent_Bias

            With fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt)
                .nMeasMode = ucDispRcpIVLSweep.eMeasureItems.eIV
                .nCh = nCh
                .dVoltage = Format(IVL_V, "0.000")
                .dCurrent = Format(IVL_I, "0.00000E-0")
                .dAbs_Current_Log = Format(Math.Log10(Math.Abs(.dCurrent)), "0.00000E-0")
                .dArea_cm = dSampleArea
                .dJ = Format((.dCurrent) / (dSampleArea * dFillFactor) * 100, "0.00000E-0") '(dI * 1000),  // 전류는 mA로 읽고있음  Unit : mA/cm2  M6000 전류 A로 읽을 시에만 * 1000을 해 줌
                .dAbs_J = Math.Abs(.dJ)
                .dABS_I = Math.Abs(.dCurrent)
                .dTemperature = fMain.g_MeasuredDatas(procParam.index).dTemp
                .dAngle = procParam.recipe.sViewingAngleInfo.sCommon.dSweepList(measCnt)
            End With


            '8.4 Measurement Data of Spectormeter
            '*********************************************************************************

            MeasureSpectrometer(nCh, measData, g_SystemOptions.sOptionData.Spectrometer.nAngleGain)

            If measData.D5.i3nm Is Nothing = False Then
                fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sArrySpectrometer(0)(measCnt) = measData

                dLumi = measData.D6.s2YY

                '# Calculation cd/A
                ' dcdA = dLumi / (fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dJ * 10)
                dcdA = dLumi / ((IVL_I / (dSampleArea * 100) * 100) * 10)
                '# Calculation lm/W  'M6000으로 소스 보낼 경우 계산 하지 않음.. Why? 기본 전압을 어떤걸로 해야 할 지 모름..(3채널이여서)
                ' dlmW = dcdA / IVL_V * Math.PI

                ' dQE = CData.QuantumEfficiency(SweepSet.dCellArea_cm, dI, SpectrumData(spectrumCnt).D5.s4Intensity)
                '스펙트럼 간격별로 QE계산 함수 호출 할 수 있도록 변경 해야 함.
                nWavelengthInterval = measData.D5.i3nm(1) - measData.D5.i3nm(0)

                dQE = cDataQE.QuantumEfficiency(dLumi, fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dJ, dSampleArea, measData.D5.s4Intensity, nWavelengthInterval)
                ' dQE = cDataQE.QuantumEfficiencyWaveLen1nm(dLum, fMain.g_MeasuredDatas(procParam.index).sCellIVLParams.sIVLMeasure(measCnt).dJ, dSampleArea, measData.D5.s4Intensity, nWavelengthInterval)
                '*************************************************************************************

                'Col 추가 필요 CIEu', CIEv', CCT, 등

                With fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt)
                    .nMeasMode = ucDispRcpIVLSweep.eMeasureItems.eIVL
                    .dCdA = Format(dcdA, "0.0000")
                    .dLuminance_Cdm2 = Format(dLumi, "0.000")
                    .dCIEx = Format(measData.D6.s3xx, "0.0000")
                    .dCIEy = Format(measData.D6.s4yy, "0.0000")
                    .dCIEu = Format(measData.D6.s5uu, "0.0000")
                    .dCIEv = Format(measData.D6.s6vv, "0.0000")
                    .dCCT = Format(measData.D4.s3KelvinT, "0.0000")
                    '  .dlmW = Format(dlmW, "0.0000")
                    .dQE = Format(dQE, "0.0000")

                    If measCnt = 0 Then
                        .dLumi_Percent = 100
                        dRef_Luminance = .dLuminance_Cdm2

                        .dDelta_udvd = 0
                        dRef_ud = .dCIEu
                        dRef_vd = .dCIEv
                    Else
                        .dLumi_Percent = Format(.dLuminance_Cdm2 / dRef_Luminance * 100, "0.00")
                        .dDelta_udvd = Format(Math.Sqrt((dRef_ud - .dCIEu) ^ 2 + (dRef_vd - .dCIEv) ^ 2), "0.0000")
                    End If

                End With

            End If

            With fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt)
                sData(0) = measCnt + 1
                sData(1) = .nMeasMode.ToString
                sData(2) = .dArea_cm
                sData(3) = .dTemperature
                sData(4) = .dVoltage
                sData(5) = .dCurrent
                sData(6) = .dJ
                sData(7) = .dAbs_J
                sData(8) = .dAngle
                sData(9) = .dLuminance_Cdm2
                sData(10) = .dCdA
                sData(11) = .dQE
                sData(12) = .dCIEx
                sData(13) = .dCIEy
                sData(14) = .dCIEu
                sData(15) = .dCIEv
                sData(16) = .dDelta_udvd
                sData(17) = .dCCT

                IVLIndicatorDlg.dispListView.AddRowData(sData)
            End With

            IVLIndicatorDlg.dispGraph.SetPlotData(fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0))
            IVLIndicatorDlg.dispGraph.PlotIVLData()

            measCnt += 1

        Loop Until measCnt > procParam.recipe.sViewingAngleInfo.sCommon.dSweepList.Length - 1 'g_SweepSet.dBiasList.Length - 1

        spectrumMeasAngleList(0) = procParam.recipe.sViewingAngleInfo.sCommon.dSweepList.Clone

        '11. Source Off
        For i As Integer = 0 To procParam.recipe.sViewingAngleInfo.sCellInfos.Length - 1
            If procParam.recipe.sViewingAngleInfo.sCellInfos(i).bEnable = True Then
                If fMain.cM6000(nDevNo6000).Request(nChNoM6000, CSeqRoutineM6000.eSequenceState.eReset, settings, procParam.CommonInfo.sLimits) = False Then
                End If
            End If
        Next

        If fMain.frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellColor_OFF = Color.Black
            fMain.frmControlUI.ControlUI.control.DispChSampleUI(nCh).CellStatus = ucDispSampleCommonNode.eCellState.eOFF
        End If

        ' 휘도계 Range 초기화  빛이 없는 상태 Dark를 측정하면 Rangel 초기화 됨   PSI업체 휘도계
        If fMain.cSpectormeter(0).mySpectrometer.MeasureFixedAperture(Imsimeasdata) = False Then
            fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "Source off Measure")
        End If


        '=================================================================================================================================================================
        '13.  DataSave
        '=================================================================================================================================================================
        If IVLIndicatorDlg.IsStopIVL = False And fMain.g_SweepStop(nCh) = False Then
            'Create Save File
            fMain.g_DataSaver(nCh).CreateSaveFile(procParam.recipe.recipeIndex)

            'SaveIVLDataHeader
            fMain.g_DataSaver(nCh).SaveHeaderInfoOfIVL(procParam.recipe.recipeIndex, procParam.recipe)

            'Save data
            If fMain.g_DataSaver(nCh).SaveDataIVL(procParam.recipe, fMain.g_MeasuredDatas(procParam.index).sCellIVLParams) = False Then
                '예외처리
            End If

            If fMain.g_DataSaver(nCh).SaveIVLSpectrumData(procParam.recipe, fMain.g_MeasuredDatas(procParam.index).sCellIVLParams, spectrumMeasAngleList) = False Then
                '예외처리
            End If
        End If

        'Z축 위치를 모르기 때문에 상승을 먼저 시킨다
        fMain.cMotion.ViewAngleMove(0, True) '시야각 0'로 이동
        fMain.cMotion.ZMove(10, True)   'Z 축 상승
        fMain.cMotion.MoveCompletedAllAxis()
        Application.DoEvents()
        Thread.Sleep(100)

        '=================================================================================================================================================================

        IVLIndicatorDlg.Close()
        IVLIndicatorDlg.Dispose()
        IVLIndicator = Nothing
    End Sub
    Public Function DataNormalization(ByVal inData() As Double, ByVal RowCount As Integer, ByRef nELmax As Integer) As Double()

        Dim nNumOfDataPoint As Integer
        Dim nCntDPoint As Integer
        Dim dMaxValue As Double = 0
        Dim nIndexOfMaxVal As Integer
        Dim dDataBuf As Double
        Dim dNormalizedData() As Double

        nNumOfDataPoint = inData.Length
        ReDim dNormalizedData(nNumOfDataPoint - 1)

        '1. Max값 찾기
        dMaxValue = GetMaxValue(inData, nIndexOfMaxVal)

        '2. Max값을 기준으로 Normalization 시작
        For nCntDPoint = 0 To nNumOfDataPoint - 1
            dDataBuf = inData(nCntDPoint) / dMaxValue

            dNormalizedData(nCntDPoint) = dDataBuf
        Next

        nELmax = (nIndexOfMaxVal * RowCount) + 380
        Return dNormalizedData

    End Function

    Public Function GetMaxValue(ByVal inData() As Double, ByRef out_index As Integer) As Double

        Dim nNumOfDataPoint As Integer
        Dim nCntDPoint As Integer
        Dim dMaxValue As Double = 0
        Dim dIndexOfMaxVal As Integer

        nNumOfDataPoint = inData.Length
        '1. Max값 찾기
        For nCntDPoint = 0 To nNumOfDataPoint - 1
            If dMaxValue < inData(nCntDPoint) Then
                dMaxValue = inData(nCntDPoint)
                dIndexOfMaxVal = nCntDPoint
            End If
        Next
        out_index = dIndexOfMaxVal
        Return dMaxValue
    End Function

    Public Function Cal_FWHM(ByVal nELmax As Integer, ByVal dNomrIntensity() As Double, ByVal nWavelength() As Integer, ByVal nRowCount As Integer, ByRef dFWHM As Double) As Boolean
        Dim sELData As sSpectrumData
        Dim dL_EL_Wavelength, dR_EL_Wavelength As Double
        Dim dBuf_Intensity As Double
        Dim nLSerchNumber As Integer
        Dim nRSerchNumber As Integer
        Dim dStandardValue As Double = 0.5
        Dim dWave() As Double = Nothing
        Dim dIntensity() As Double = Nothing
        Dim cnt As Integer = 0

        nLSerchNumber = nELmax - nWavelength(0)
        nRSerchNumber = nWavelength(nWavelength.Length - 1) - nELmax

        'Serch Left Min(top), Max(botton)
        For i As Integer = 0 To nLSerchNumber Step nRowCount
            dBuf_Intensity = dStandardValue - dNomrIntensity(cnt)

            'dStandard 값이 -면 top, +면 botton
            If dBuf_Intensity <= 0 Then
                'top
                If dBuf_Intensity > sELData.dLeft_Top_Intensity Or sELData.dLeft_Top_Intensity = 0 Then
                    sELData.dLeft_Top_Intensity = dBuf_Intensity
                    sELData.dLeft_Top_Wavelength = nWavelength(cnt)
                End If
            Else
                'botton
                If dBuf_Intensity <= sELData.dLeft_Botton_Intensity Or sELData.dLeft_Botton_Intensity = 0 Then
                    sELData.dLeft_Botton_Intensity = dBuf_Intensity
                    sELData.dLeft_Botton_Wavelength = nWavelength(cnt)
                End If
            End If
            cnt += 1
        Next

        cnt = 0
        Dim nStartIndex As Integer = nLSerchNumber / nRowCount
        'Serch Right Min(top), Max(botton)
        For i As Integer = nLSerchNumber To nRSerchNumber + nLSerchNumber Step nRowCount
            dBuf_Intensity = dStandardValue - dNomrIntensity(nStartIndex + cnt)

            'dStandard 값이 -면 top, +면 botton
            If dBuf_Intensity <= 0 Then
                'top
                If dBuf_Intensity > sELData.dRight_Top_Intensity Or sELData.dRight_Top_Intensity = 0 Then
                    sELData.dRight_Top_Intensity = dBuf_Intensity
                    sELData.dRight_Top_Wavelength = nWavelength(nStartIndex + cnt)
                End If
            Else
                'botton
                If dBuf_Intensity <= sELData.dRight_Botton_Intensity Or sELData.dRight_Botton_Intensity = 0 Then
                    sELData.dRight_Botton_Intensity = dBuf_Intensity
                    sELData.dRight_Botton_Wavelength = nWavelength(nStartIndex + cnt)
                End If
            End If
            cnt += 1
        Next

        'Interpolation

        ReDim dWave(1)
        ReDim dIntensity(1)

        dWave(0) = sELData.dLeft_Botton_Wavelength
        dWave(1) = sELData.dLeft_Top_Wavelength
        dIntensity(0) = sELData.dLeft_Botton_Intensity
        dIntensity(1) = sELData.dLeft_Top_Intensity

        Interpolation(dWave, dIntensity, dL_EL_Wavelength, 0)

        ReDim dWave(1)
        ReDim dIntensity(1)

        dWave(0) = sELData.dRight_Botton_Wavelength
        dWave(1) = sELData.dRight_Top_Wavelength
        dIntensity(0) = sELData.dRight_Botton_Intensity
        dIntensity(1) = sELData.dRight_Top_Intensity

        Interpolation(dWave, dIntensity, dR_EL_Wavelength, 0)


        'sELData()
        'dL_EL_Intensity_Top, dL_EL_Intensity_Botton, dR_EL_Intensity_Top, dR_EL_Intensity_Botton
        'dL_EL_Wavelength_Top, dL_EL_Wavelength_Botton, dR_EL_Wavelength_Top, dR_EL_Wavelength_Botton

        'return dL_EL_Wavelength, dR_EL_Wavelength
        dFWHM = Math.Abs(dR_EL_Wavelength - dL_EL_Wavelength)

        Return True
    End Function

    Public Function Interpolation(ByVal x() As Double, ByVal y() As Double, ByRef ref_x As Double, ByVal ref_y As Double) As Boolean

        'ref_y = ((y(1) - y(0)) / (x(1) - x(0))) * (ref_x - x(0)) + y(0)
        '  ref_x = ((x(1) - x(0)) / (ref_y - y(0))) * (y(1) - ref_y) + x(0)
        ref_x = (x(1) - x(0)) * (ref_y - y(0)) / (y(1) - y(0)) + x(0)
        Return True
    End Function

    Public Function UpdateAndCalculateCellLifetimeDataForM7000(ByVal procParam As sProcessParams,
                                                              ByVal dCurrent As Double, ByVal dTemp As Double,
                                                              ByVal MeasValOfSpectrometer As CDevSpectrometerCommonNode.tData, ByVal MeasPointNum As Integer, Optional ByVal bFirstSettings As Boolean = False) As frmMain.sMeasureParams
        Dim dLumi As Double
        Dim dDeltaudvd As Double
        Dim dCd_a As Double
        '   Dim sDatas() As String = Nothing
        Dim cDataQE As CDataQECal = New CDataQECal
        Dim nTimeOutCnt As Integer = 0
        Const NumOfCol_OpticalData As Integer = 10
        Dim dSum As Double = 0
        Dim nTotalColunmCnt As Integer
        Dim Normspectrum() As Double = Nothing
        Dim nELmax As Integer = 0
        Dim dFWHM As Double = 0
        Dim nSpectrumSize As Integer
        Dim dSpectrum As Double
        fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCHNum = procParam.index + 1
        fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea = (procParam.sSampleInfos.SampleSize.Height * procParam.sSampleInfos.SampleSize.Width) / 100
        nTotalColunmCnt += 1

        fMain.g_MeasuredDatas(procParam.index).dTemp = dTemp

        With fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum)

            .dTotCurrent = 0

            '데이터 복사
            '  .eletricalData.colorType = electricalDataIdx

            .eletricalData.dCurrent = dCurrent * 1000

            .dTotCurrent = .eletricalData.dCurrent


            ''데이터 정렬용 카운트 증가
            'If .eletricalData.mode = CDevM6000PLUS.eMode.eCC Or
            '    .eletricalData.mode = CDevM6000PLUS.eMode.eCV Then '이값을 사용하지 않고 M6000 데이터에 모드를 추가해서 사용
            '    nTotalColunmCnt += NumOfCol_EletricalData
            'Else
            '    nTotalColunmCnt += numOfCol_EletricalData_Pulse
            'End If

            .dCurrentDensity = (.dTotCurrent) / ((fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * procParam.sSampleInfos.dFillFactor) / 100)

            ' .dCurrentDensity = Format((.dTotCurrent * 1000) / ((fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * procParam.sSampleInfos.dFillFactor) / 100), "0.00000E-0")
            'Step2. Measurement (Multi-Point Measurement)   'LEX

            Dim nWavelengthInterval As Integer = Nothing

            .opticalData.sSpectrometerData = MeasValOfSpectrometer
            dLumi = (.opticalData.sSpectrometerData.D6.s2YY * 100) / procParam.sSampleInfos.dFillFactor
            .opticalData.dLumi_Cd_m2 = .opticalData.sSpectrometerData.D6.s2YY
            .opticalData.dLumi_Fill_Cd_m2 = dLumi
            '# Calculation cd/A
            '.opticalData(opticalDataIdx).dLumi_Cd_A = dLumi / (.dCurrentDensity * 10)
            .opticalData.dLumi_Cd_A = FormatNumber(dLumi / (.dCurrentDensity * 10), 3) '((.dTotCurrent * 1000 / (fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * 100) * 100) * 10)

            '# Calculation lm/W
            'lm/W 확인 필요
            .opticalData.dlmW = FormatNumber(.opticalData.dLumi_Cd_A / .eletricalData.dVoltage * Math.PI, 3)
            '     fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dLumi_Cd_A / fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dVoltage * Math.PI


            '스펙트럼 간격별로 QE계산 함수 호출 할 수 있도록 변경 해야 함.
            If .opticalData.sSpectrometerData.D5.i3nm Is Nothing = False Then
                nWavelengthInterval = .opticalData.sSpectrometerData.D5.i3nm(1) - .opticalData.sSpectrometerData.D5.i3nm(0)

                .opticalData.dQE = FormatNumber(cDataQE.QuantumEfficiency(dLumi, .dCurrentDensity, procParam.sSampleInfos.SampleSize.Height * procParam.sSampleInfos.SampleSize.Width,
                                                                         .opticalData.sSpectrometerData.D5.s4Intensity, nWavelengthInterval), 3)
                For idx As Integer = 0 To .opticalData.sSpectrometerData.D5.s4Intensity.Length - 1
                    dSum += .opticalData.sSpectrometerData.D5.s4Intensity(idx)
                Next
                .opticalData.dSpectrumSum = dSum
                Dim PeakVal As Double = 0
                Dim PeakLength As Integer = 0
                For i As Integer = 0 To .opticalData.sSpectrometerData.D5.i3nm.Length - 1
                    If .opticalData.sSpectrometerData.D5.s4Intensity(i) > PeakVal Then
                        PeakLength = .opticalData.sSpectrometerData.D5.i3nm(i)
                        PeakVal = .opticalData.sSpectrometerData.D5.s4Intensity(i)
                    End If
                Next
                .opticalData.dELMax = PeakLength
            Else
                .opticalData.dQE = 0
                .opticalData.dSpectrumSum = 0
                .opticalData.dELMax = 0
            End If

            nSpectrumSize = 1
            Normspectrum = DataNormalization(.opticalData.sSpectrometerData.D5.s4Intensity, nSpectrumSize, nELmax)

            'Cal FWHM
            Cal_FWHM(nELmax, Normspectrum, .opticalData.sSpectrometerData.D5.i3nm, nSpectrumSize, dFWHM)

            .opticalData.dFWHM = dFWHM

            If bFirstSettings = True Then
                fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum).opticalData.dRefLumi = MeasValOfSpectrometer.D6.s2YY 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s2YY
                fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum).opticalData.dRefud = MeasValOfSpectrometer.D6.s5uu  'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s5uu
                fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum).opticalData.dRefvd = MeasValOfSpectrometer.D6.s6vv 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s6vv
                '   fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dRefVoltage = MeasValOfM6000.dVoltage_Bias 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dVoltage
                fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum).eletricalData.dRefCurrent = .eletricalData.dCurrent 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dCurrent
                fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum).opticalData.dLumi_Cd_A_RefValue = .opticalData.dLumi_Cd_A
                fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum).opticalData.dSpectrumSum_Ref = .opticalData.dSpectrumSum
                fMain.g_MeasuredDatas(procParam.index).bIsSavedRefPDCurrent = True
                fMain.g_MeasuredDatas(procParam.index).bRequestedMeasRefValue = False
            End If

            If fMain.g_MeasuredDatas(procParam.index).bIsSavedRefPDCurrent = True Then  '기준 값이 저장 되었으면...
                .eletricalData.dDeltaVoltage = .eletricalData.dVoltage - .eletricalData.dRefVoltage
                .eletricalData.dDeltaCurrent = .eletricalData.dCurrent - .eletricalData.dRefCurrent
                .eletricalData.dCurrent_Per = (.eletricalData.dCurrent / .eletricalData.dRefCurrent) * 100
            Else
                .eletricalData.dDeltaVoltage = 0
                .eletricalData.dDeltaCurrent = 0
                .eletricalData.dCurrent_Per = 100
            End If

            If fMain.g_MeasuredDatas(procParam.index).bIsSavedRefPDCurrent = True Then  '기준 값이 저장 되었으면...
                dLumi = (.opticalData.sSpectrometerData.D6.s2YY / .opticalData.dRefLumi) * 100
                dDeltaudvd = Math.Sqrt((.opticalData.dRefud - .opticalData.sSpectrometerData.D6.s5uu) ^ 2 + (.opticalData.dRefvd - .opticalData.sSpectrometerData.D6.s6vv) ^ 2)
                dCd_a = (.opticalData.dLumi_Cd_A / .opticalData.dLumi_Cd_A_RefValue) * 100
                dSpectrum = (.opticalData.dSpectrumSum / .opticalData.dSpectrumSum_Ref) * 100
            Else
                dCd_a = 100
                dLumi = 100
                dDeltaudvd = 0
                dSpectrum = 100
            End If

            .opticalData.dLumi_Percent = dLumi
            .opticalData.dLumi_Cd_A_Percent = dCd_a
            .opticalData.dDeltaudvd = dDeltaudvd
            .opticalData.dSpectrumSum_Per = dSpectrum

            '데이터 정렬용 카운트 증가
            nTotalColunmCnt += NumOfCol_OpticalData
            ' Next

        End With

        '  Next

        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        'Calculate Luminance------------------------------------------------------------------
        ''If fMain.g_MeasuredDatas(procParam.index).bRequestedMeasRefValue = True Then 'Aging 시간 이후에 기준값 저장 Flag가 True 가 되면, 기준 값을 저장 하고 초기 값을 산출
        ''    fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.dRefLumi = fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s2YY
        ''    fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.dRefud = fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s5uu
        ''    fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.dRefvd = fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s6vv
        ''    fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dRefVoltage = fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dVoltage
        ''    fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dRefCurrent = fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dCurrent

        ''    fMain.g_MeasuredDatas(procParam.index).bRequestedMeasRefValue = False
        ''    fMain.g_MeasuredDatas(procParam.index).bIsSavedRefPDCurrent = True
        ''End If

        Return fMain.g_MeasuredDatas(procParam.index)
    End Function

    'Public Function UpdateAndCalculateCellLifetimeDataForM7000(ByVal procParam As sProcessParams,
    '                                                           ByVal MeasValOfM6000 As CDevM6000.sMeasParams,
    '                                                           ByVal MeasValOfSpectrometer As CDevSpectrometerCommonNode.tData) As String()
    '    Dim dLumi As Double
    '    Dim dDeltaudvd As Double
    '    Dim sDatas() As String = Nothing
    '    Dim cDataQE As CDataQECal = New CDataQECal
    '    Dim nTimeOutCnt As Integer = 0

    '    Const NumOfCol_EletricalData As Integer = 5 ' Volt, Delta V, Current, Delta I, Current Density
    '    Const numOfCol_EletricalData_Pulse As Integer = 5 ' Volt Bias, Volt Ampli, Current Bias, Current Ampli, Current Density
    '    Const NumOfCol_OpticalData As Integer = 10

    '    Dim nTotalColunmCnt As Integer

    '    fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea = (procParam.sSampleInfos.SampleSize.Height * procParam.sSampleInfos.SampleSize.Width) / 100
    '    nTotalColunmCnt += 1

    '    With fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData

    '        .dTotCurrent = 0

    '        '데이터 복사
    '        '  .eletricalData.colorType = electricalDataIdx

    '        .eletricalData.mode = MeasValOfM6000.Mode
    '        .eletricalData.dCurrent = MeasValOfM6000.dCurrent_Bias
    '        .eletricalData.dVoltage = MeasValOfM6000.dVoltage_Bias
    '        .eletricalData.dHighVoltage = MeasValOfM6000.dVoltage_Amplitude
    '        .eletricalData.dHighCurrent = MeasValOfM6000.dCurrent_Amplitude

    '        .dTotCurrent = .eletricalData.dCurrent

    '        If fMain.g_MeasuredDatas(procParam.index).bIsSavedRefPDCurrent = True Then  '기준 값이 저장 되었으면...
    '            .eletricalData.dDeltaVoltage = .eletricalData.dVoltage - .eletricalData.dRefVoltage
    '            .eletricalData.dDeltaCurrent = .eletricalData.dCurrent - .eletricalData.dRefCurrent
    '        Else
    '            .eletricalData.dDeltaVoltage = 0
    '            .eletricalData.dDeltaCurrent = 0
    '        End If

    '        '데이터 정렬용 카운트 증가
    '        If .eletricalData.mode = CDevM6000.eMode.eCC Or
    '            .eletricalData.mode = CDevM6000.eMode.eCV Then '이값을 사용하지 않고 M6000 데이터에 모드를 추가해서 사용
    '            nTotalColunmCnt += NumOfCol_EletricalData
    '        Else
    '            nTotalColunmCnt += numOfCol_EletricalData_Pulse
    '        End If

    '        .dCurrentDensity = .dTotCurrent / (fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * procParam.sSampleInfos.dFillFactor) * 100

    '        'Step2. Measurement (Multi-Point Measurement)   'LEX

    '        Dim nWavelengthInterval As Integer = Nothing

    '        .opticalData.sSpectrometerData = MeasValOfSpectrometer
    '        dLumi = .opticalData.sSpectrometerData.D6.s2YY
    '        .opticalData.dLumi_Cd_m2 = dLumi
    '        '# Calculation cd/A
    '        '.opticalData(opticalDataIdx).dLumi_Cd_A = dLumi / (.dCurrentDensity * 10)
    '        .opticalData.dLumi_Cd_A = dLumi / ((.dTotCurrent / (fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * 100) * 100) * 10)

    '        '# Calculation lm/W
    '        'lm/W 확인 필요
    '        .opticalData.dlmW = .opticalData.dLumi_Cd_A / .eletricalData.dVoltage * Math.PI
    '        '     fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dLumi_Cd_A / fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dVoltage * Math.PI


    '        '스펙트럼 간격별로 QE계산 함수 호출 할 수 있도록 변경 해야 함.
    '        If .opticalData.sSpectrometerData.D5.i3nm Is Nothing = False Then
    '            nWavelengthInterval = .opticalData.sSpectrometerData.D5.i3nm(1) - .opticalData.sSpectrometerData.D5.i3nm(0)

    '            .opticalData.dQE = cDataQE.QuantumEfficiency(dLumi, .dCurrentDensity, procParam.sSampleInfos.SampleSize.Height * procParam.sSampleInfos.SampleSize.Width, _
    '                                                                     .opticalData.sSpectrometerData.D5.s4Intensity, nWavelengthInterval)
    '        Else
    '            .opticalData.dQE = 0
    '        End If

    '        If fMain.g_MeasuredDatas(procParam.index).bIsSavedRefPDCurrent = True Then  '기준 값이 저장 되었으면...
    '            dLumi = (.opticalData.sSpectrometerData.D6.s2YY / .opticalData.dRefLumi) * 100
    '            dDeltaudvd = Math.Sqrt((.opticalData).dRefud - .opticalData.sSpectrometerData.D6.s5uu) ^ 2 + (.opticalData.dRefvd - .opticalData.sSpectrometerData.D6.s6vv) ^ 2

    '        Else
    '            dLumi = 100
    '            dDeltaudvd = 0
    '        End If
    '        .opticalData.dLumi_Percent = dLumi
    '        .opticalData.dDeltaudvd = dDeltaudvd

    '        '데이터 정렬용 카운트 증가
    '        nTotalColunmCnt += NumOfCol_OpticalData
    '        ' Next

    '    End With

    '    '  Next

    '    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '    ReDim sDatas(nTotalColunmCnt) '온도 데이터를 포함해야 해서 -1을 하지 않음.

    '    Dim nCnt As Integer = 0

    '    'Output Measured Value-----------------------------------------------
    '    sDatas(nCnt) = CStr(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea) : nCnt += 1
    '    sDatas(nCnt) = CStr(fMain.g_MeasuredDatas(procParam.index).dTemp) : nCnt += 1

    '    ' For dataIdx As Integer = 0 To fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.Length - 1

    '    '   For eleDataIdx As Integer = 0 To fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(dataIdx).eletricalData.Length - 1

    '    If fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.mode = CDevM6000.eMode.eCC Or
    '        fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.mode = CDevM6000.eMode.eCV Then

    '        sDatas(nCnt) = CStr(Format(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dVoltage, "0.000")) : nCnt += 1
    '        sDatas(nCnt) = CStr(Format(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dDeltaVoltage, "0.000")) : nCnt += 1
    '        sDatas(nCnt) = CStr(Format(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dCurrent, "0.00000E-0")) : nCnt += 1
    '        sDatas(nCnt) = CStr(Format(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dDeltaCurrent, "0.000")) : nCnt += 1

    '    Else   '펄스모드 일때도 Detal V, I 필요한가 ?  
    '        sDatas(nCnt) = CStr(Format(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dVoltage, "0.000")) : nCnt += 1
    '        sDatas(nCnt) = CStr(Format(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dHighVoltage, "0.000")) : nCnt += 1
    '        sDatas(nCnt) = CStr(Format(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dCurrent, "0.00000E-0")) : nCnt += 1
    '        sDatas(nCnt) = CStr(Format(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dHighCurrent, "0.00000E-0")) : nCnt += 1
    '    End If

    '    sDatas(nCnt) = CStr(Format(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.dCurrentDensity, "0.00000E-0")) : nCnt += 1
    '    sDatas(nCnt) = CStr(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s2YY) : nCnt += 1
    '    sDatas(nCnt) = CStr(Format(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.dLumi_Percent, "0.0")) : nCnt += 1
    '    sDatas(nCnt) = CStr(Format(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.dLumi_Cd_A, "0.0000")) : nCnt += 1
    '    sDatas(nCnt) = CStr(Format(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.dQE, "0.0000")) : nCnt += 1
    '    sDatas(nCnt) = CStr(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s3xx) : nCnt += 1
    '    sDatas(nCnt) = CStr(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s4yy) : nCnt += 1
    '    sDatas(nCnt) = CStr(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s5uu) : nCnt += 1
    '    sDatas(nCnt) = CStr(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s6vv) : nCnt += 1
    '    sDatas(nCnt) = CStr(Format(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.dDeltaudvd, "0.0000")) : nCnt += 1
    '    sDatas(nCnt) = CStr(fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D4.s3KelvinT) : nCnt += 1

    '    'Calculate Luminance------------------------------------------------------------------
    '    If fMain.g_MeasuredDatas(procParam.index).bRequestedMeasRefValue = True Then 'Aging 시간 이후에 기준값 저장 Flag가 True 가 되면, 기준 값을 저장 하고 초기 값을 산출
    '        fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.dRefLumi = fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s2YY
    '        fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.dRefud = fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s5uu
    '        fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.dRefvd = fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s6vv
    '        fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dRefVoltage = fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dVoltage
    '        fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dRefCurrent = fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dCurrent

    '        fMain.g_MeasuredDatas(procParam.index).bRequestedMeasRefValue = False
    '        fMain.g_MeasuredDatas(procParam.index).bIsSavedRefPDCurrent = True
    '    End If


    '    Return sDatas.Clone
    'End Function


    Private Function timer_Sec() As Single
        Return CSng((Now.Minute * 60) + Now.Second + (Now.Millisecond / 1000))
    End Function


#Region "M6000 Functions"



    Public Function UpdateRealTimeData(ByVal ch As Integer) As frmMain.sRealTimeDataOfM6000

        Dim realTimeData As frmMain.sRealTimeDataOfM6000

        realTimeData.eachPixelMeasData = GetMeasuredDatasOfM60000(ch)

        '   For i As Integer = 0 To realTimeData.eachPixelMeasData.Length - 1
        realTimeData.dTotCurrent = realTimeData.eachPixelMeasData.dCurrent_Bias
        realTimeData.dTotVoltage = realTimeData.eachPixelMeasData.dVoltage_Bias
        realTimeData.dTotPDCurrent = realTimeData.eachPixelMeasData.dPDCurrent
        '  Next

        Return realTimeData
    End Function

    Public Function GetMeasuredDatasOfM60000(ByVal ch As Integer) As CDevM6000PLUS.sMeasParams
        Dim MeasValOfM6000 As CDevM6000PLUS.sMeasParams

        Dim nDevNo As Integer
        Dim nChNo As Integer

        nDevNo = frmSettingWind.GetAllocationValue(ch, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
        nChNo = frmSettingWind.GetAllocationValue(ch, frmSettingWind.eChAllocationItem.eChOfM6000)

        MeasValOfM6000 = fMain.cM6000(nDevNo).MeasuredData(nChNo)

        Return MeasValOfM6000
    End Function

    Public Function GetMeasuredDataOfM6000(ByVal nDevNo As Integer, ByVal nChNo As Integer) As CDevM6000PLUS.sMeasParams
        Return fMain.cM6000(nDevNo).MeasuredData(nChNo)
    End Function


    Public Sub SetSourceOfM6000(ByVal index As Integer, ByVal CellInfos() As ucDispCellLifetime.sSourceSetting, ByVal Limit() As ucLimitSetting.sLimitSetting)
        Dim settings As CDevM6000PLUS.sSettingParams
        Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(index, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
        Dim nChNo As Integer = frmSettingWind.GetAllocationValue(index, frmSettingWind.eChAllocationItem.eChOfM6000)

        '  For i As Integer = 0 To 2
        With settings
            If CellInfos(0).bEnable = True Then
                .bOutputState = CDevM6000PLUS.eONOFF.eON
            Else
                .bOutputState = CDevM6000PLUS.eONOFF.eOFF
            End If
            .source.dAmplitude = CellInfos(0).dAmplitude
            If CellInfos(0).bEnableRevMode = True Then
                .source.dBiasValue = CellInfos(0).dBias * -1
            Else
                .source.dBiasValue = CellInfos(0).dBias
            End If
            .source.Mode = CellInfos(0).Mode
            .source.Pulse.dDuty = CellInfos(0).Pulse.dDuty
            .source.Pulse.dFrequency = CellInfos(0).Pulse.dFrequency
        End With

        If settings.bOutputState = CDevM6000PLUS.eONOFF.eON Then
            If fMain.cM6000(nDevNo).Request(nChNo, CSeqRoutineM6000.eSequenceState.eSetSource, settings, Limit) = False Then
                fMain.cTimeScheduler.g_ChSchedulerStatus(index) = CScheduler.eChSchedulerSTATE.eIdle
                fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_ERROR_SEQ_PROCESS_LT_REQUEST_FUNCTION)
            End If
        End If

        ' Next
    End Sub

    Public Sub SetSourceOfM6000(ByVal DevNo As Integer, ByVal ChNo As Integer, ByVal SetSourceState As CSeqRoutineM6000.eSequenceState, ByVal CellInfos As ucDispCellLifetime.sSourceSetting, ByVal Limit() As ucLimitSetting.sLimitSetting)

        'Dim nDevNoOfSwitch As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eRedDevNoOfSwitch)
        'Dim nChNoOfSwitch As Integer = frmSettingWind.GetAllocationValue(procParam.index, frmSettingWind.eChAllocationItem.eRedChOfSwitch)
        Dim settings As CDevM6000PLUS.sSettingParams


        With settings
            If CellInfos.bEnable = True Then
                .bOutputState = CDevM6000PLUS.eONOFF.eON
            Else
                .bOutputState = CDevM6000PLUS.eONOFF.eOFF
            End If
            .source.dAmplitude = CellInfos.dAmplitude
            If CellInfos.bEnableRevMode = True Then
                .source.dBiasValue = CellInfos.dBias * -1
            Else
                .source.dBiasValue = CellInfos.dBias
            End If
            .source.Mode = CellInfos.Mode
            .source.Pulse.dDuty = CellInfos.Pulse.dDuty
            .source.Pulse.dFrequency = CellInfos.Pulse.dFrequency
        End With

        If settings.bOutputState = CDevM6000PLUS.eONOFF.eON Then
            If fMain.cM6000(DevNo).Request(ChNo, SetSourceState, settings, Limit) = False Then
                fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_ERROR_SEQ_PROCESS_LT_REQUEST_FUNCTION)
            End If
        End If

    End Sub


    Public Function CompletedSettingsOfM6000(ByVal nDevNo As Integer, ByVal nChNo As Integer, ByVal dTimeOut As Double, ByVal checkStatus As CSeqRoutineM6000.eSequenceState) As Boolean
        Dim sStartTime As Single
        Dim sDeltaTime As Single

        sStartTime = timer_Sec()
        Do
            Thread.Sleep(100)
            Application.DoEvents()
            '시간 Check
            sDeltaTime = timer_Sec() - sStartTime
            If sDeltaTime < 0 Then sDeltaTime = sDeltaTime + 3600
            If sDeltaTime > dTimeOut Then
                fMain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_ERROR_SEQ_PROCESS_TIMEOUT, checkStatus.ToString & " | Lifetime Timeout")
                Return False
            End If
        Loop Until (fMain.cM6000(nDevNo).ChannelStatus(nChNo) = checkStatus)

        Return True
    End Function

    Public Function CheckStatusOfM6000(ByVal ch As Integer, ByVal state As CSeqRoutineM6000.eSequenceState, ByVal cellInfos() As ucDispCellLifetime.sSourceSetting) As Boolean
        Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(ch, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
        Dim nChNo As Integer = frmSettingWind.GetAllocationValue(ch, frmSettingWind.eChAllocationItem.eChOfM6000)

        If CheckStatusOfM6000(nDevNo, nChNo, state, cellInfos(0)) = False Then Return False

        Return True
    End Function

    Public Function CheckStatusOfM6000(ByVal nDevNo As Integer, ByVal nChNo As Integer, ByVal state As CSeqRoutineM6000.eSequenceState, ByVal CellInfos As ucDispCellLifetime.sSourceSetting) As Boolean

        If CellInfos.bEnable = True Then
            If fMain.cM6000(nDevNo).ChannelStatus(nChNo) <> state Then Return False
        End If
        Return True
    End Function

    Private Sub CompletedSettingsAllChOfM6000(ByVal index As Integer, ByVal dTimeOut As Double, ByVal checkStatus As CSeqRoutineM6000.eSequenceState, ByVal CellInfos() As ucDispCellLifetime.sSourceSetting)

        Dim settings As CDevM6000PLUS.sSettingParams
        Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(index, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
        Dim nChNo As Integer = frmSettingWind.GetAllocationValue(index, frmSettingWind.eChAllocationItem.eChOfM6000)

        If CellInfos Is Nothing = False Then
            With settings
                If CellInfos(0).bEnable = True Then
                    .bOutputState = CDevM6000PLUS.eONOFF.eON
                Else
                    .bOutputState = CDevM6000PLUS.eONOFF.eOFF
                End If
                .source.dAmplitude = CellInfos(0).dAmplitude
                If CellInfos(0).bEnableRevMode = True Then
                    .source.dBiasValue = CellInfos(0).dBias * -1
                Else
                    .source.dBiasValue = CellInfos(0).dBias
                End If
                .source.Mode = CellInfos(0).Mode
                .source.Pulse.dDuty = CellInfos(0).Pulse.dDuty
                .source.Pulse.dFrequency = CellInfos(0).Pulse.dFrequency
            End With

            If settings.bOutputState = CDevM6000PLUS.eONOFF.eON Then
                If CompletedSettingsOfM6000(nDevNo, nChNo, dTimeOut, checkStatus) = False Then
                    '예외 처리 : Log Message
                End If
            End If
        Else
            If CompletedSettingsOfM6000(nDevNo, nChNo, dTimeOut, checkStatus) = False Then
                '예외 처리 : Log Message
            End If
        End If
    End Sub
#End Region


#Region "Spectrometer Functions"

    Public Function MeasureSpectrometer(ByVal idx As Integer, ByRef measData As CDevSpectrometerCommonNode.tData, Optional ByVal nAperture As Integer = 0, Optional ByVal nSpeedMode As Integer = 0) As Boolean

        'Dim measData As CDevSpectrometerCommonNode.tData = Nothing
        Dim nWavelengthInterval As Integer = Nothing
        Dim nTimeOutCnt As Integer
        Dim fRst As Boolean = True

        '  If fMain.cSpectormeter(0).mySpectrometer.Model = CDevSpectrometerCommonNode.eModel.SPECTROMETER_DarsaPro Or _
        ' fMain.cSpectormeter(0).mySpectrometer.Model = CDevSpectrometerCommonNode.eModel.SPECTROMETER_SR3AR Then
        'If fMain.cSpectormeter(0).mySpectrometer.SetAperture(nAperture) = False Then
        '    fMain.g_StateMsgHandler.messageToUserErrorCode(idx, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "SetAperture")
        '    '예외처리
        'End If

        'If fMain.cSpectormeter(0).mySpectrometer.SetMeasSpeed(nSpeedMode) = False Then
        '    fMain.g_StateMsgHandler.messageToUserErrorCode(idx, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "SetSpeedMode")
        '    '예외처리
        'End If
        ' End If


        ' 초기 측정 시 Aperature  1'  Change 
        If fMain.cSpectormeter(0).mySpectrometer.EndApertureChange() = False Then  '1/8도 Aperture 로 고정
            fMain.g_StateMsgHandler.messageToUserErrorCode(idx, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "EndApertureChange")
            '예외처리
        End If

        nTimeOutCnt = 0
        Do
            If nTimeOutCnt > 5 Then
                fMain.g_StateMsgHandler.messageToUserErrorCode(idx, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_COMMON_MSG_Retry_TimeOut_Cnt, "SpectroRadiometer Meas")
                fRst = False
                Exit Do
            End If

            If fMain.cSpectormeter(0).mySpectrometer.Measure(measData) = True Then
                Exit Do
            End If
            nTimeOutCnt += 1
        Loop

        nTimeOutCnt = 0
        Do
            If nTimeOutCnt > 5 Then
                fMain.g_StateMsgHandler.messageToUserErrorCode(idx, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_COMMON_MSG_Retry_TimeOut_Cnt, "SpectroRadiometer DownloadData")
                fRst = False
                Exit Do
            End If

            If fMain.cSpectormeter(0).mySpectrometer.DownloadData(measData) = True Then
                Exit Do
            End If
            nTimeOutCnt += 1
        Loop

        Return fRst
    End Function
#End Region

#Region "Shared Functions"

    Public Shared Function MakeSweepList(ByVal sIVLCominfos As ucDispRcpIVLSweep.sIVLSweepCommonInfos) As Double()
        Try
            Dim dStartValue, dStopValue, dStepValue As Double
            Dim nPoint, nTotPoint As Integer

            Dim dArrSweepList() As Double = Nothing
            Dim arrSweepList() As Double

            Dim i, nCnt As Integer
            Dim ChkCC As Boolean = False

            If sIVLCominfos.sweepType = ucDispRcpIVLSweep.eSweepType.eUserPattern Then
                Return sIVLCominfos.dSweepList.Clone
            End If

            If sIVLCominfos.biasMode = ucDispRcpIVLSweep.eBiasMode.eCC Then
                ChkCC = True
            End If
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
                If ChkCC = True Then
                    dArrSweepList(0 + nTotPoint) = dStartValue / 1000
                Else
                    dArrSweepList(0 + nTotPoint) = dStartValue
                End If

                If nPoint = 1 Then

                    For i = 1 To nPoint - 1
                        If ChkCC = True Then
                            dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue / 1000))
                        ElseIf ChkCC = False Then
                            dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue))
                        End If
                    Next

                Else

                    For i = 1 To nPoint - 1
                        If ChkCC = True Then
                            dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue / 1000))
                        ElseIf ChkCC = False Then
                            dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue))
                        End If

                    Next

                End If

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
        Catch ex As Exception
            Dim Rslt() As Double = Nothing
            Return Rslt
        End Try
    End Function

    '220826 Update by JKY : RGB Sweep List
    Public Shared Function MakeRGBSweepList(ByVal sIVLCominfos As ucDispRcpIVLSweep.sIVLSweepCommonInfos) As Double()
        Try
            Dim dStartValue, dStopValue, dStepValue As Double
            Dim nPoint, nTotPoint As Integer

            Dim dArrSweepList() As Double = Nothing
            Dim arrSweepList() As Double

            Dim i, nCnt As Integer
            Dim ChkCC As Boolean = False

            If sIVLCominfos.biasMode = ucDispRcpIVLSweep.eBiasMode.eCC Then
                ChkCC = True
            End If
            For nCnt = 0 To sIVLCominfos.sMeasureRGBSweepParameter.Length - 1

                dStartValue = sIVLCominfos.sMeasureRGBSweepParameter(nCnt).dStart 'SweepParameter(nCnt).dStart
                dStopValue = sIVLCominfos.sMeasureRGBSweepParameter(nCnt).dStop
                dStepValue = sIVLCominfos.sMeasureRGBSweepParameter(nCnt).dStep
                nPoint = sIVLCominfos.sMeasureRGBSweepParameter(nCnt).nPoint

                If dStartValue < dStopValue Then   '정방향 Sweep -Bias --> +Bias

                Else   '역방향 Sweep +Bias --> -Bias
                    dStepValue = -Math.Abs(dStepValue)
                End If

                ReDim Preserve dArrSweepList(nPoint + nTotPoint - 1)
                If ChkCC = True Then
                    dArrSweepList(0 + nTotPoint) = dStartValue / 1000
                Else
                    dArrSweepList(0 + nTotPoint) = dStartValue
                End If

                If nPoint = 1 Then

                    For i = 1 To nPoint - 1
                        If ChkCC = True Then
                            dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue / 1000))
                        ElseIf ChkCC = False Then
                            dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue))
                        End If
                    Next

                Else

                    For i = 1 To nPoint - 1
                        If ChkCC = True Then
                            dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue / 1000))
                        ElseIf ChkCC = False Then
                            dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue))
                        End If

                    Next

                End If

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
        Catch ex As Exception
            Dim Rslt() As Double = Nothing
            Return Rslt
        End Try
    End Function

    Private Function DataProcessToResultData(ByVal procParam As sProcessParams, ByVal measData As CDevSpectrometerCommonNode.tData, Optional ByVal measCnt As Integer = Nothing, Optional ByVal spectrumCnt As Integer = Nothing, Optional ByVal uprime0 As Double = Nothing, Optional ByVal vprime0 As Double = Nothing, Optional ByVal angle As Double = Nothing) As Boolean
        Dim dLumi As Double
        Dim dcdA As Double
        Dim dlmW As Double
        Dim dWavelengthInterval As Double
        Dim dQE As Double
        Dim dFWHM As Double
        Dim dELmax As Double
        Dim nCh As Integer = procParam.index '
        Dim nSpectrumSize As Integer
        Dim dTotalFlux As Double
        Dim nStepDegree As Double
        Dim SpecMeasCnt As Integer = 0
        Dim dPeak1Integral As Double
        Dim dPeak2Integral As Double
        'Dim IVLCnt As Integer
        Dim nPeak1Start As Integer
        Dim nPeak1End As Integer
        Dim nPeak2Start As Integer
        Dim nPeak2End As Integer

        'If procParam.index <= 15 Then '0~8  , (0~15)
        '    nPeak1Start = g_SystemOptions.sOptionData.SaveOptions.nJIG1_8_Pick1_Start
        '    nPeak1End = g_SystemOptions.sOptionData.SaveOptions.nJIG1_8_Pick1_end
        '    nPeak2Start = g_SystemOptions.sOptionData.SaveOptions.nJIG1_8_Pick2_start
        '    nPeak2End = g_SystemOptions.sOptionData.SaveOptions.nJIG1_8_Pick2_end
        'ElseIf procParam.index >= 16 And procParam.index <= 31 Then '9~16         ,(16~31)
        '    nPeak1Start = g_SystemOptions.sOptionData.SaveOptions.nJIG9_16_Pick1_Start
        '    nPeak1End = g_SystemOptions.sOptionData.SaveOptions.nJIG9_16_Pick1_end
        '    nPeak2Start = g_SystemOptions.sOptionData.SaveOptions.nJIG9_16_Pick2_start
        '    nPeak2End = g_SystemOptions.sOptionData.SaveOptions.nJIG9_16_Pick2_end
        'ElseIf procParam.index >= 32 And procParam.index <= 47 Then '17~24       ,(32~47)
        '    nPeak1Start = g_SystemOptions.sOptionData.SaveOptions.nJIG17_24_Pick1_Start
        '    nPeak1End = g_SystemOptions.sOptionData.SaveOptions.nJIG17_24_Pick1_end
        '    nPeak2Start = g_SystemOptions.sOptionData.SaveOptions.nJIG17_24_Pick2_start
        '    nPeak2End = g_SystemOptions.sOptionData.SaveOptions.nJIG17_24_Pick2_end
        'ElseIf procParam.index >= 48 And procParam.index <= 63 Then '25~32         (48~63)
        '    nPeak1Start = g_SystemOptions.sOptionData.SaveOptions.nJIG25_32_Pick1_Start
        '    nPeak1End = g_SystemOptions.sOptionData.SaveOptions.nJIG25_32_Pick1_end
        '    nPeak2Start = g_SystemOptions.sOptionData.SaveOptions.nJIG25_32_Pick2_start
        '    nPeak2End = g_SystemOptions.sOptionData.SaveOptions.nJIG25_32_Pick2_end
        'End If

        If measData.D5.i3nm.Length = 401 Then
            nSpectrumSize = 1
        ElseIf measData.D5.i3nm.Length = 101 Then
            nSpectrumSize = 4
        ElseIf measData.D5.i3nm.Length = 201 Then
            nSpectrumSize = 2
        Else
            nSpectrumSize = 1
        End If

        If measData.D5.i3nm Is Nothing = False Then

            'IVLCnt += 1
            'ReDim fMain.g_MeasuredDatas(nCh).sCellIVLParams.sArrySpectrometer(0)
            'ReDim fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)
            'ReDim fMain.g_MeasuredDatas(nCh).sCellIVLParams.sNormalSpectrometer(0)
            'ReDim fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)

            'If measCnt = Nothing Then
            '    ReDim fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(0)
            'End If

            'If spectrumCnt = Nothing Then
            '    ReDim fMain.g_MeasuredDatas(nCh).sCellIVLParams.sArrySpectrometer(0)(0)
            'End If

            fMain.g_MeasuredDatas(nCh).sCellIVLParams.sArrySpectrometer(0)(spectrumCnt) = measData

            If procParam.cmd = eProcessState.IVLSweep Then
                dLumi = dLumi * procParam.recipe.sIVLSweepInfo.sCommon.dLumiCorrection * 0.01 'g_SystemOptions.sOptionData.SaveOptions.dLumiCorrection * 0.01
                measData.D6.s2YY = measData.D6.s2YY * procParam.recipe.sIVLSweepInfo.sCommon.dLumiCorrection * 0.01 'g_SystemOptions.sOptionData.SaveOptions.dLumiCorrection * 0.01

            ElseIf procParam.cmd = eProcessState.ViewingAngle Then
                dLumi = dLumi * procParam.recipe.sViewingAngleInfo.sCommon.dLumiCorrection * 0.01 'g_SystemOptions.sOptionData.SaveOptions.dLumiCorrection * 0.01
                measData.D6.s2YY = measData.D6.s2YY * procParam.recipe.sViewingAngleInfo.sCommon.dLumiCorrection * 0.01 'g_SystemOptions.sOptionData.SaveOptions.dLumiCorrection * 0.01
                nStepDegree = procParam.recipe.sViewingAngleInfo.sCommon.sMeasureSweepParameter(0).dStep
            End If

            'Fill Factor 적용 수정
            'dLumi = measData.D6.s2YY * 100 / procParam.sSampleInfos.dFillFactor
            dLumi = measData.D6.s2YY / (procParam.sSampleInfos.dFillFactor / 100)

            '# Calculation cd/A
            '  dcdA = dLumi / (((IVL_I * 1000) / (dSampleArea * 100) * 100) * 10)
            dcdA = dLumi / (fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dJ * 10)

            '# Calculation lm/W
            dlmW = dcdA / fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dVoltage * Math.PI

            ' dQE = CData.QuantumEfficiency(SweepSet.dCellArea_cm, dI, SpectrumData(spectrumCnt).D5.s4Intensity)
            '스펙트럼 간격별로 QE계산 함수 호출 할 수 있도록 변경 해야 함.
            dWavelengthInterval = measData.D5.i3nm(1) - measData.D5.i3nm(0)

            dQE = cDataQE.QuantumEfficiency(dLumi, fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dJ, fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dArea_cm, measData.D5.s4Intensity, dWavelengthInterval)
            dTotalFlux = cDataQE.CalculateTotalFlux(measData.D5.s4Intensity, dWavelengthInterval)

            'Peak1, 2 Integral
            'dPeak1Integral = cDataQE.IntegralToData(measData.D5.s4Intensity, measData.D5.i3nm, nPeak1Start, nPeak1End, nSpectrumSize)
            'dPeak2Integral = cDataQE.IntegralToData(measData.D5.s4Intensity, measData.D5.i3nm, nPeak2Start, nPeak2End, nSpectrumSize)

            '''''   fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.dRefLumi = fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s2YY
            'Cal Normalization
            fMain.g_MeasuredDatas(nCh).sCellIVLParams.sNormalSpectrometer(spectrumCnt) = cDataQE.DataNormalization(measData.D5.s4Intensity, nSpectrumSize, dELmax)

            'Cal FWHM
            cDataQE.Cal_FWHM(dELmax, fMain.g_MeasuredDatas(nCh).sCellIVLParams.sNormalSpectrometer(spectrumCnt), measData.D5.i3nm, nSpectrumSize, dFWHM)

            ' fMain.g_MeasuredDatas(nCh).sCellIVLParams.sNormalSpectrometer(spectrumCnt) = dNormalData.Clone

            Dim PeakVal As Double
            Dim PeakLength As Integer

            For i As Integer = 0 To measData.D5.i3nm.Length - 1
                If measData.D5.s4Intensity(i) > PeakVal Then
                    PeakLength = measData.D5.i3nm(i)
                    PeakVal = measData.D5.s4Intensity(i)
                End If
            Next
            measData.D5.iMax = PeakLength
            measData.D5.nMaxIntensity = PeakVal

            'Dim Peak1Val As Double
            'Dim Peak1Length As Integer
            'Dim Peak2Val As Double
            'Dim Peak2Length As Integer

            ''Peak1 Search
            'For idx As Integer = 0 To measData.D5.i3nm.Length - 1
            '    If measData.D5.i3nm(idx) > nPeak1Start - 1 And measData.D5.i3nm(idx) < nPeak1End + 1 Then
            '        If measData.D5.s4Intensity(idx) > Peak1Val Then
            '            Peak1Length = measData.D5.i3nm(idx)
            '            Peak1Val = measData.D5.s4Intensity(idx)
            '        End If
            '    End If
            'Next

            ''Peak2 Search
            'For idx As Integer = 0 To measData.D5.i3nm.Length - 1
            '    If measData.D5.i3nm(idx) > nPeak2Start - 1 And measData.D5.i3nm(idx) < nPeak2End + 1 Then
            '        If measData.D5.s4Intensity(idx) > Peak2Val Then
            '            Peak2Length = measData.D5.i3nm(idx)
            '            Peak2Val = measData.D5.s4Intensity(idx)
            '        End If
            '    End If
            'Next
            '*************************************************************************************
            With fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt)

                .nMeasMode = ucDispRcpIVLSweep.eMeasureItems.eIVL
                .dCdA = Format(dcdA, "0.00")
                .dLuminance_Fill_Cdm2 = Format(dLumi, "0.00")
                .dLuminance_Cdm2 = Format(measData.D6.s2YY, "0.00")
                .dCIEx = Format(measData.D6.s3xx, "0.000") '1931
                .dCIEy = Format(measData.D6.s4yy, "0.000")
                .dCIEu = Format(measData.D6.s5uu, "0.000") '1976
                .dCIEv = Format(measData.D6.s6vv, "0.000")
                .dCCT = Format(measData.D4.s3KelvinT, "0.00")
                .dlmW = Format(dlmW, "0.00")
                .dQE = Format(dQE, "0.00")
                .dFWHM = Format(dFWHM, "0.0")
                .nIntegrationTime = measData.IntegrationTime
                .dX = Format(measData.D2.s2XX, "0.000")
                .dY = Format(measData.D2.s3YY, "0.000")
                .dZ = Format(measData.D2.s4ZZ, "0.000")

                .dDelta_CIE1960 = Format(measData.D4.s4DevOfColorCoord, "0.00E-0")
                .dLe = Format(measData.D5.s2IntegIntensity, "0.00") 'Radiance
                .dTotalFlux = dTotalFlux
                .dWavePeakValue = measData.D5.nMaxIntensity
                .nWavePeaklength = measData.D5.iMax
                '.dPeak1_Integ = Format(dPeak1Integral, "0.00")
                '.dPeak2_Integ = Format(dPeak2Integral, "0.00")
                '.dPeak1_Lamda = Format(Peak1Length, "0.0")
                '.dPeak2_Lamda = Format(Peak2Length, "0.0")

                'If spectrumCnt = 0 Then
                '    .dPeak1_Integral_RefValue = Format(dPeak1Integral, "0.00")
                '    .dPeak2_Integral_RefValue = Format(dPeak2Integral, "0.00")
                '    .dPeak1_Lamda_RefValue = Format(Peak1Length, "0.00")
                '    .dPeak2_Lamda_RefValue = Format(Peak2Length, "0.00")
                'End If

                'If spectrumCnt = 0 Then
                '    .dPeak1_Integral_Relative = Format(100, "0.00")
                '    .dPeak2_Integral_Relative = Format(100, "0.00")
                '    .dPeak1_Lamda_Relative = Format(100, "0.00")
                '    .dPeak2_Lamda_Relative = Format(100, "0.00")
                '    SpecMeasCnt = measCnt
                'Else
                '    '초기 저장 대비 상대값 추출
                '    .dPeak1_Integral_Relative = Format((dPeak1Integral / fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt - spectrumCnt).dPeak1_Integral_RefValue) * 100, "0.0")
                '    .dPeak2_Integral_Relative = Format((dPeak2Integral / fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt - spectrumCnt).dPeak2_Integral_RefValue) * 100, "0.0")
                '    .dPeak1_Lamda_Relative = Format((Peak1Length / fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt - spectrumCnt).dPeak1_Lamda_RefValue) * 100, "0.0")
                '    .dPeak2_Lamda_Relative = Format((Peak2Length / fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt - spectrumCnt).dPeak2_Lamda_RefValue) * 100, "0.0")
                'End If

                If angle = 0 Then
                    .dDelta_CIE1976 = Format(0, "0.00")
                Else
                    .dDelta_CIE1976 = Format(Math.Sqrt(Math.Pow((uprime0 - .dCIEu), 2) + Math.Pow((vprime0 - .dCIEv), 2)), "0.00")
                End If

                'If m_bCapture = False Then
                '    ' Dim lumiRange As Double = g_SystemOptions.sOptionData.CCDData.dCaptureLevel * 0.1
                '    If .dLuminance_Cdm2 >= g_SystemOptions.sOptionData.CCDData.dCaptureLevel Then
                '        Dim FileName As String = procParam.CommonInfo.saveInfo.strOnlyFName & "_" & ucDispJIG.convertIncPixel(nCh) & "_CAM_Volt_" & fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dVoltage & "_Lumi_" & fMain.g_MeasuredDatas(nCh).sCellIVLParams.sIVLMeasure(0)(measCnt).dLuminance_Cdm2
                '        fMain.cScreenCapture.CaptureImage(FileName)
                '        m_bCapture = True

                '    End If
                'End If

            End With
        End If

        Return True
    End Function
    Public Shared Function MakeSweepList(ByVal SweepRegionSettings() As ucMeasureSweepRegion.sSetSweepRegion) As Double()
        Try
            Dim dStartValue, dStopValue, dStepValue As Double
            Dim nPoint, nTotPoint As Integer

            Dim dArrSweepList() As Double = Nothing
            Dim arrSweepList() As Double

            Dim i, nCnt As Integer

            For nCnt = 0 To SweepRegionSettings.Length - 1

                dStartValue = SweepRegionSettings(nCnt).dStart 'SweepParameter(nCnt).dStart
                dStopValue = SweepRegionSettings(nCnt).dStop
                dStepValue = SweepRegionSettings(nCnt).dStep
                nPoint = SweepRegionSettings(nCnt).nPoint

                If dStartValue < dStopValue Then   '정방향 Sweep -Bias --> +Bias

                Else   '역방향 Sweep +Bias --> -Bias
                    dStepValue = -Math.Abs(dStepValue)
                End If


                ReDim Preserve dArrSweepList(nPoint + nTotPoint - 1)

                dArrSweepList(0 + nTotPoint) = dStartValue


                If nPoint = 1 Then
                    For i = 1 To nPoint - 1
                        dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue))
                    Next
                Else
                    For i = 1 To nPoint - 1
                        dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue))
                    Next

                End If

                nTotPoint = nTotPoint + nPoint

            Next


            arrSweepList = dArrSweepList.Clone

            Return arrSweepList
        Catch ex As Exception
            Dim Rslt() As Double = Nothing
            Return Rslt
        End Try
    End Function

    '220826 Update by JKY : RGB Sweep List
    Public Shared Function MakeRGBSweepList(ByVal SweepRegionSettings() As ucMeasureRGBSweepRegion.sSetSweepRegion) As Double()
        Try
            Dim dStartValue, dStopVValue, dStepValue As Double
            Dim nPoint, nTotPoint As Integer

            Dim dArrSweepList() As Double = Nothing
            Dim arrSweepList() As Double

            Dim i, nCnt As Integer

            For nCnt = 0 To SweepRegionSettings.Length - 1

                dStartValue = SweepRegionSettings(nCnt).dStart 'SweepParameter(nCnt).dStart
                dStopVValue = SweepRegionSettings(nCnt).dStop
                dStepValue = SweepRegionSettings(nCnt).dStep
                nPoint = SweepRegionSettings(nCnt).nPoint

                If dStartValue < dStopVValue Then   '정방향 Sweep -Bias --> +Bias

                Else   '역방향 Sweep +Bias --> -Bias
                    dStepValue = -Math.Abs(dStepValue)
                End If


                ReDim Preserve dArrSweepList(nPoint + nTotPoint - 1)

                dArrSweepList(0 + nTotPoint) = dStartValue

                If nPoint = 1 Then
                    For i = 1 To nPoint - 1
                        dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue))
                    Next
                Else
                    For i = 1 To nPoint - 1
                        dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue))
                    Next

                End If

                nTotPoint = nTotPoint + nPoint

            Next


            arrSweepList = dArrSweepList.Clone

            Return arrSweepList
        Catch ex As Exception
            Dim Rslt() As Double = Nothing
            Return Rslt
        End Try
    End Function

#End Region


#Region "Support Functions"

    Public Shared Function GetMeasColorItemInfoFromLTRcp(ByVal LTRcp As ucSequenceBuilder.sRcpLifetime) As ucSampleInfos.eSampleColor()
        Dim measItems() As ucSampleInfos.eSampleColor = Nothing
        Dim measItemCnt As Integer

        'sCellInfos의 Length = 3, 배열 0 = R, 배열 1 = G, 배열 2 = B 형태의 고정 배열로 데이터를 전달함, 즉 i가 R=0,G=1,B=2 임
        For i As Integer = 0 To LTRcp.sCellInfos.Length - 1
            If LTRcp.sCellInfos(i).bEnable = True Then
                ReDim Preserve measItems(measItemCnt)
                Select Case i
                    Case 0
                        measItems(measItemCnt) = ucSampleInfos.eSampleColor._SingleColor_R
                    Case 1
                        measItems(measItemCnt) = ucSampleInfos.eSampleColor._SingleColor_G
                    Case 2
                        measItems(measItemCnt) = ucSampleInfos.eSampleColor._SingleColor_B
                End Select
                measItemCnt += 1
            End If
        Next

        If measItemCnt > 1 Then
            ReDim Preserve measItems(measItemCnt)
            measItems(measItemCnt) = ucSampleInfos.eSampleColor._MixedColor
            measItemCnt += 1
        End If

        Return measItems
    End Function
#End Region

End Class
