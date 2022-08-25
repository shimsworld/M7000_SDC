Imports System.Threading
Imports System.IO

Public Class CStateInfo
    Dim fmain As frmMain

    Public Sub New(ByVal main As frmMain)
        fmain = main

        If Directory.Exists(g_sSaveDirectory_StateInfo) = False Then
            Directory.CreateDirectory(g_sSaveDirectory_StateInfo)
        End If

    End Sub


    Public Sub Dispose()
        Me.Finalize()
    End Sub

    Private trdTimer As Thread
    Dim g_fStopTrdTimer As Boolean

    Public Sub StartTrdTimer()
        trdTimer = New Thread(AddressOf StateInfoLoop)
        trdTimer.Priority = ThreadPriority.Normal
        trdTimer.TrySetApartmentState(ApartmentState.MTA)
        trdTimer.Start()
        g_fStopTrdTimer = False
    End Sub

    Dim nCnt As Integer = 0

    Public Sub StateInfoLoop()
        Do

            If g_fStopTrdTimer = True Then
                Exit Do
            End If


            Application.DoEvents()
            Thread.Sleep(10)

            If nCnt = g_nMaxCh Then
                SaveStateOfChannel()
                nCnt = 0
            End If

            nCnt += 1

        Loop
    End Sub

    Public Sub StopTrdTimer()
        g_fStopTrdTimer = True
    End Sub

    Public Sub SaveStateOfChannel()

        Dim Saver As New CChannelStatusINI(g_sSavePath_StateOfChannel)

        Saver.SaveIniValue(CChannelStatusINI.eSecID.eCommInfo, 0, CChannelStatusINI.eKeyID.numOfCh, g_nMaxCh)

        For nCh As Integer = 0 To g_nMaxCh - 1
            If g_SystemInfo.bCanUpdateStateInfoOfCh(nCh) = True Then  '스레드가 시작 될때 초기 상태를 무조건 갱신하는 것을 방지, 사용자가 명령을 내렸거나, 이어붙이기가 시작된 다음부터 정보를 갱신

                If fmain.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SchedulerStatus, fmain.cTimeScheduler.g_ChSchedulerStatus(nCh).ToString)
                Else
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SchedulerStatus, fmain.cTimeScheduler.g_ChSchedulerStatus(nCh).ToString)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IsSavedModeStartTime, CStr(fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).IsSavedModeStartTime))
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_ModeStartTime, fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).ModeStartTime.ToString)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IsSavedTestStartTime, fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).IsSavedTestStartTime.ToString)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_TestStartTime, fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).TestStartTime.ToString)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IntervalStartTime, fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).IntervalStartTime.ToString)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IsSavedIntervalStartTime, fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).IsSavedIntervalStartTime.ToString)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_Lifetime_Hour, fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).LifeTime.dHour)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_Lifetime_Min, fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).LifeTime.dMin)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_Lifetime_Second, fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).LifeTime.nSecound)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IsSavedLifeTime, CStr(fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).IsSavedLifeTime))
                    '-------------------------
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_Count, fmain.g_DataSaver(nCh).numberOfSaveFile)
                    '  For n As Integer = 0 To fmain.g_DataSaver(nCh).numberOfSaveFile - 1 '패널당 멀티포인트로 측정하는 것 때문에 Numberofsavefile로 나누지 않고, MeasPoint로 개수 생성
                    For n As Integer = 0 To fmain.SequenceList(nCh).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT, n, fmain.g_DataSaver(nCh).m_sSavePath_LT(n))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT_BackUp, n, fmain.g_DataSaver(nCh).m_sSavePath_LT_Backup(n))
                        '  Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT_Mirroring_BackUp, n, fmain.g_DataSaver(nCh).m_sSavePath_LT_Mirroring(n))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT_Spectrum, n, fmain.g_DataSaver(nCh).m_sSavePath_LT_SpectrumData(n))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT_Spectrum_BackUp, n, fmain.g_DataSaver(nCh).m_sSavePath_LT_SpectrumData_Backup(n))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_TestStartTime, n, fmain.g_DataSaver(nCh).StartTime(n).ToString)
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntSaveData, n, CStr(fmain.g_DataSaver(nCh).SavedDataCounter(n)))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntREDSaveData, n, CStr(fmain.g_DataSaver(nCh).RedSavedDataCounter(n)))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntGREENSaveData, n, CStr(fmain.g_DataSaver(nCh).GreenSavedDataCounter(n)))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntBLUESaveData, n, CStr(fmain.g_DataSaver(nCh).BlueSavedDataCounter(n)))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntBLACKSaveData, n, CStr(fmain.g_DataSaver(nCh).BlackSavedDataCounter(n)))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_Lifetime, n, fmain.g_DataSaver(nCh).Lifetime(n).TotalHours.ToString)

                    Next
                    '--------------
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_Index, fmain.SequenceList(nCh).Index)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx, fmain.SequenceList(nCh).CurrentRecipeIndex)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_LT, fmain.SequenceList(nCh).CurrentRecipeIndex_LifeTime)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_ChangeTemp, fmain.SequenceList(nCh).CurrentRecipeIndex_ChangeTemp)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_IVLSweep, fmain.SequenceList(nCh).CurrentRecipeIndex_IVLSweep)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_ViewingAngle, fmain.SequenceList(nCh).CurrentRecipeIndex_ViewingAngle)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_CurrentRcpIdx_LifetimeAndIVL, fmain.SequenceList(nCh).CurrentRecipeIndex_LifetimeAndIVL)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_MeasCount_LifetimeAfterIVLSweep, fmain.SequenceList(nCh).IVLSweepMeasCount)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_MeasInterval_TimeVal_Hour, fmain.SequenceList(nCh).MeasInterval.dHour)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_MeasInterval_TimeVal_Min, fmain.SequenceList(nCh).MeasInterval.dMin)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_MeasInterval_TimeVal_Second, fmain.SequenceList(nCh).MeasInterval.nSecound)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_ChangeInterval_TimeVal_Hour, fmain.SequenceList(nCh).ChangeInterval.dHour)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_ChangeInterval_TimeVal_Min, fmain.SequenceList(nCh).ChangeInterval.dMin)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_ChangeInterval_TimeVal_Second, fmain.SequenceList(nCh).ChangeInterval.nSecound)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_NextMeasureTime_TimeVal_Hour, fmain.SequenceList(nCh).NextMeasureTime.dHour)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_NextMeasureTime_TimeVal_Min, fmain.SequenceList(nCh).NextMeasureTime.dMin)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_NextMeasureTime_TimeVal_Second, fmain.SequenceList(nCh).NextMeasureTime.nSecound)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_RequestTest, fmain.SequenceList(nCh).RequestTest)
                    ' Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SeqMgr_RequestFirstTest, fMain.SequenceList(i).RequestFirstTest)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_IsLastSequence, fmain.SequenceList(nCh).IsLastSequence)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqMgr_LoopCount, fmain.SequenceList(nCh).LoopCount)

                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_PD_Saved_Status, fmain.g_MeasuredDatas(nCh).bIsSavedRefPDCurrent)
                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_PD_Value, fmain.g_MeasuredDatas(nCh).dRefValue)



                    '=====================
                    For i As Integer = 0 To fmain.SequenceList(nCh).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Color_Type, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).type.ToString)
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).eletricalData.dRefVoltage)
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).eletricalData.dRefCurrent)
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).eletricalData.dCurrent_Per)
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dRefLumi))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dLumi_Percent))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dRefLumi_Percent))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dRefSpectrum_Percent))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dRefud))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dRefvd))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dLumi_Cd_A_RefValue))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dLumi_Cd_A_Percent))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dSpectrumSum_Ref))
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dSpectrumSum_Per))
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak1_Integral_RefValue))
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak2_Integral_RefValue))
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak3_Integral_RefValue))
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak4_Integral_RefValue))
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak1_Integral_RefValue_Lumi))
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak2_Integral_RefValue_Lumi))
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak3_Integral_RefValue_Lumi))
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak4_Integral_RefValue_Lumi))

                    Next


                    '=====================
                    For i As Integer = 0 To fmain.SequenceList(nCh).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Color_Type, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).type.ToString, "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).eletricalData.dRefVoltage, "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).eletricalData.dRefCurrent, "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).eletricalData.dCurrent_Per, "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dRefLumi), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dLumi_Percent), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dRefLumi_Percent), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dRefSpectrum_Percent), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dRefud), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dRefvd), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dLumi_Cd_A_RefValue), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dLumi_Cd_A_Percent), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dSpectrumSum_Ref), "RED")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dSpectrumSum_Per), "RED")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dPeak1_Integral_RefValue), "RED")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dPeak2_Integral_RefValue), "RED")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dPeak3_Integral_RefValue), "RED")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dPeak4_Integral_RefValue), "RED")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dPeak1_Integral_RefValue_Lumi), "RED")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dPeak2_Integral_RefValue_Lumi), "RED")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dPeak3_Integral_RefValue_Lumi), "RED")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dPeak4_Integral_RefValue_Lumi), "RED")

                    Next


                    '=====================
                    For i As Integer = 0 To fmain.SequenceList(nCh).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Color_Type, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).type.ToString, "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).eletricalData.dRefVoltage, "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).eletricalData.dRefCurrent, "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).eletricalData.dCurrent_Per, "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dRefLumi), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dLumi_Percent), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dRefLumi_Percent), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dRefSpectrum_Percent), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dRefud), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dRefvd), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dLumi_Cd_A_RefValue), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dLumi_Cd_A_Percent), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dSpectrumSum_Ref), "GREEN")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dSpectrumSum_Per), "GREEN")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dPeak1_Integral_RefValue), "GREEN")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dPeak2_Integral_RefValue), "GREEN")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dPeak3_Integral_RefValue), "GREEN")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dPeak4_Integral_RefValue), "GREEN")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dPeak1_Integral_RefValue_Lumi), "GREEN")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dPeak2_Integral_RefValue_Lumi), "GREEN")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dPeak3_Integral_RefValue_Lumi), "GREEN")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dPeak4_Integral_RefValue_Lumi), "GREEN")

                    Next


                    '=====================
                    For i As Integer = 0 To fmain.SequenceList(nCh).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Color_Type, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).type.ToString, "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).eletricalData.dRefVoltage, "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).eletricalData.dRefCurrent, "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).eletricalData.dCurrent_Per, "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dRefLumi), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dLumi_Percent), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dRefLumi_Percent), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dRefSpectrum_Percent), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dRefud), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dRefvd), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dLumi_Cd_A_RefValue), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dLumi_Cd_A_Percent), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dSpectrumSum_Ref), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dSpectrumSum_Per), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak1_Integral_RefValue), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak2_Integral_RefValue), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak3_Integral_RefValue), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak4_Integral_RefValue), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak1_Integral_RefValue_Lumi), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak2_Integral_RefValue_Lumi), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak3_Integral_RefValue_Lumi), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak4_Integral_RefValue_Lumi), "BLUE")

                    Next

                    For i As Integer = 0 To fmain.SequenceList(nCh).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Color_Type, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).type.ToString, "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).eletricalData.dRefVoltage, "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).eletricalData.dRefCurrent, "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, i, fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).eletricalData.dCurrent_Per, "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dRefLumi), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dLumi_Percent), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dRefLumi_Percent), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dRefSpectrum_Percent), "BLUE")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dRefud), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dRefvd), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dLumi_Cd_A_RefValue), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dLumi_Cd_A_Percent), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dSpectrumSum_Ref), "BLACK")
                        Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dSpectrumSum_Per), "BLACK")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak1_Integral_RefValue), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak2_Integral_RefValue), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak3_Integral_RefValue), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak4_Integral_RefValue), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak1_Integral_RefValue_Lumi), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak2_Integral_RefValue_Lumi), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak3_Integral_RefValue_Lumi), "BLUE")
                        'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ_Lumi, i, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dPeak4_Integral_RefValue_Lumi), "BLUE")

                    Next

                    'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ_Percent, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData.opticalData.dPeak1_Integral_RefValu))
                    'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ_Percent, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData.opticalData.dPeak2_Integral_RefValue))
                    'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ_Percent, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData.opticalData.dPeak3_Integral_RefValue))
                    'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ_Percent, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData.opticalData.dPeak4_Integral_RefValue))

                    'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ_Lumi_Percent, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData.opticalData.dPeak1_Integral_RefValue_Lumi))
                    'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ_Lumi_Percent, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData.opticalData.dPeak2_Integral_RefValue_Lumi))
                    'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ_Lumi_Percent, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData.opticalData.dPeak3_Integral_RefValue_Lumi))
                    'Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ_Lumi_Percent, CStr(fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData.opticalData.dPeak4_Integral_RefValue_Lumi))

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
                                Try
                                    Dim nDevNoOfM6000 As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                                    Dim nChNoOfM6000 As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfM6000)
                                    If nDevNoOfM6000 >= 0 And nChNoOfM6000 >= 0 Then
                                        If fmain.cM6000 Is Nothing = False Then
                                            Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.M6000SeqRoutine_Status, fmain.cM6000(nDevNoOfM6000).ChannelStatus(nChNoOfM6000).ToString)
                                        End If
                                    End If
                                Catch ex As Exception
                                    fmain.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSystem_Allocation_value_error,
                                                                         "SaveStateOfChannel GetAllocationValue Error [Channel : " & Format(nCh, "00") & " ]")
                                End Try

                            Case frmConfigSystem.eDeviceItem.eMcSG
                                Dim nGroupNoOfSG As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eGroupOfSG)
                                Dim nChNoOfSG As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSG)
                                If fmain.cMcSG Is Nothing = False Then
                                    Saver.SaveIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SGSeqRoutine_Status, fmain.cMcSG(nGroupNoOfSG).ChannelStatus(nChNoOfSG).ToString)
                                End If
                            Case frmConfigSystem.eDeviceItem.ePG

                            Case frmConfigSystem.eDeviceItem.eTC

                        End Select
                    Next

                End If

            End If
        Next
    End Sub

    Public Function LoadStateInfoOfChannel(ByVal nCh As Integer, ByRef sequenceInfo As CSequenceManager, ByRef dataSaver As cDataOutput) As Boolean
        Dim Loader As New CChannelStatusINI(g_sSavePath_StateOfChannel)
        Dim nMaxCh As Integer

        nMaxCh = Loader.LoadIniValue(CChannelStatusINI.eSecID.eCommInfo, 0, CChannelStatusINI.eKeyID.numOfCh)

        If nCh >= nMaxCh Then Return False


        ''Load 된 기본 Sequence 정보에 , 마지막 상태를 적용함.
        fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).IsSavedModeStartTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IsSavedModeStartTime)
        fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).ModeStartTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_ModeStartTime)
        fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).IsSavedTestStartTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IsSavedTestStartTime)
        fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).TestStartTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_TestStartTime)
        fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).IntervalStartTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IntervalStartTime)
        fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).IsSavedIntervalStartTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IsSavedIntervalStartTime)
        fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).LifeTime.dHour = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_Lifetime_Hour)
        fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).LifeTime.dMin = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_Lifetime_Min)
        fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).LifeTime.nSecound = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_Lifetime_Second)
        fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).IsSavedLifeTime = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SystemTime_IsSavedLifeTime)
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
        timeSpanVal1 = Now.Subtract(fmain.cTimeScheduler.g_SYSTIMEInfo(nCh).ModeStartTime)
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
        dataSaver = New cDataOutput(sequenceInfo.SequenceInfo, nCh, g_SystemOptions.sOptionData.SaveOptions.nFileType)

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
        'Dim sTempSavePath_Mirroring_Backup(dataSaver.numberOfSaveFile - 1) As String
        'Dim sTempDataCnt(dataSaver.numberOfSaveFile - 1) As Integer
        Dim sTempSavePath(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As String
        Dim sTempSavePath_Backup(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As String
        Dim sTempSavePathSpectrum(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As String
        Dim sTempSavePathSpectrum_Backup(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As String
        Dim sTempStartTime(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As Date
        Dim sTempSavePath_Mirroring_Backup(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As String
        Dim sTempDataCnt(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As Integer
        Dim sTempREDDataCnt(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As Integer
        Dim sTempGREENDataCnt(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As Integer
        Dim sTempBLUEDataCnt(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As Integer
        Dim sTempBLACKDataCnt(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1) As Integer
        'For n As Integer = 0 To dataSaver.numberOfSaveFile - 1 '패널당 멀티포인트로 측정하는 것 때문에, NumberofSaveFile이 아니라 MeasPoint로 개수 생성
        For i As Integer = 0 To sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
            sTempSavePath(i) = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT, i)
            sTempSavePath_Backup(i) = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT_BackUp, i)
            sTempSavePathSpectrum(i) = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT_Spectrum, i)
            sTempSavePathSpectrum_Backup(i) = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT_Spectrum_BackUp, i)
            sTempSavePath_Mirroring_Backup(i) = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_SavePath_LT_Mirroring_BackUp, i)

            sTemp = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_TestStartTime, i)
            sTempStartTime(i) = sTemp

            sTemp = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntSaveData, i)
            sTempDataCnt(i) = CInt(sTemp)

            sTemp = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntREDSaveData, i)
            sTempREDDataCnt(i) = CInt(sTemp)
            sTemp = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntGREENSaveData, i)
            sTempGREENDataCnt(i) = CInt(sTemp)
            sTemp = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntBLUESaveData, i)
            sTempBLUEDataCnt(i) = CInt(sTemp)
            sTemp = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SaveInfo_nCntBLACKSaveData, i)
            sTempBLACKDataCnt(i) = CInt(sTemp)
            ' dataSaver.Lifetime(n).TotalHours = Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, i, CChannelStatusINI.eKeyID.SaveInfo_Lifetime, n)
        Next
        dataSaver.m_sSavePath_LT = sTempSavePath.Clone
        dataSaver.m_sSavePath_LT_Backup = sTempSavePath_Backup.Clone
        dataSaver.m_sSavePath_LT_SpectrumData = sTempSavePathSpectrum.Clone
        '  dataSaver.m_sSavePath_LT_Mirroring = sTempSavePath_Mirroring_Backup.Clone
        dataSaver.m_sSavePath_LT_SpectrumData_Backup = sTempSavePathSpectrum_Backup.Clone
        dataSaver.StartTime = sTempStartTime.Clone
        dataSaver.SavedDataCounter = sTempDataCnt.Clone
        dataSaver.RedSavedDataCounter = sTempREDDataCnt.Clone
        dataSaver.GreenSavedDataCounter = sTempGREENDataCnt.Clone
        dataSaver.BlueSavedDataCounter = sTempBLUEDataCnt.Clone
        dataSaver.BlackSavedDataCounter = sTempBLACKDataCnt.Clone
        '--------------

        ReDim fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)
        ReDim fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)
        ReDim fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)
        ReDim fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)
        ReDim fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)
        '======================================
        For i As Integer = 0 To sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
            fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).eletricalData.dRefVoltage = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, i))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).eletricalData.dRefCurrent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, i))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).eletricalData.dCurrent_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, i))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dRefLumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, i))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, i))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dRefLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, i))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dRefSpectrum_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, i))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dRefud = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, i))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dRefvd = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, i))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dLumi_Cd_A_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, i))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dLumi_Cd_A_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, i))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dSpectrumSum_Ref = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, i))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dSpectrumSum_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak1_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak2_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak3_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak4_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak1_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak2_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak3_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak4_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ_Lumi, i))
        Next

        '======================================
        For i As Integer = 0 To sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
            fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).eletricalData.dRefVoltage = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, i, "RED"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).eletricalData.dRefCurrent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, i, "RED"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).eletricalData.dCurrent_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, i, "RED"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dRefLumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, i, "RED"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, i, "RED"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dRefLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, i, "RED"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dRefSpectrum_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, i, "RED"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dRefud = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, i, "RED"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dRefvd = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, i, "RED"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dLumi_Cd_A_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, i, "RED"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dLumi_Cd_A_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, i, "RED"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dSpectrumSum_Ref = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, i, "RED"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.RedLTData(i).opticalData.dSpectrumSum_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, i, "RED"))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak1_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak2_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak3_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak4_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak1_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak2_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak3_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak4_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ_Lumi, i))
        Next

        '======================================
        For i As Integer = 0 To sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
            fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).eletricalData.dRefVoltage = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, i, "GREEN"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).eletricalData.dRefCurrent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, i, "GREEN"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).eletricalData.dCurrent_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, i, "GREEN"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dRefLumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, i, "GREEN"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, i, "GREEN"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dRefLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, i, "GREEN"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dRefSpectrum_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, i, "GREEN"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dRefud = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, i, "GREEN"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dRefvd = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, i, "GREEN"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dLumi_Cd_A_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, i, "GREEN"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dLumi_Cd_A_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, i, "GREEN"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dSpectrumSum_Ref = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, i, "GREEN"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.GreenLTData(i).opticalData.dSpectrumSum_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, i, "GREEN"))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak1_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak2_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak3_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak4_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak1_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak2_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak3_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak4_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ_Lumi, i))
        Next

        '======================================
        For i As Integer = 0 To sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).eletricalData.dRefVoltage = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, i, "BLUE"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).eletricalData.dRefCurrent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, i, "BLUE"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).eletricalData.dCurrent_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, i, "BLUE"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dRefLumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, i, "BLUE"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, i, "BLUE"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dRefLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, i, "BLUE"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dRefSpectrum_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, i, "BLUE"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dRefud = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, i, "BLUE"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dRefvd = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, i, "BLUE"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dLumi_Cd_A_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, i, "BLUE"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dLumi_Cd_A_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, i, "BLUE"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dSpectrumSum_Ref = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, i, "BLUE"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlueLTData(i).opticalData.dSpectrumSum_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, i, "BLUE"))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak1_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak2_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak3_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak4_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak1_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak2_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak3_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak4_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ_Lumi, i))
        Next

        '======================================
        For i As Integer = 0 To sequenceInfo.SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).eletricalData.dRefVoltage = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Voltage, i, "BLACK"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).eletricalData.dRefCurrent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current, i, "BLACK"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).eletricalData.dCurrent_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Current_Per, i, "BLACK"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dRefLumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi, i, "BLACK"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent, i, "BLACK"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dRefLumi_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Lumi_Percent_Delta, i, "BLACK"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dRefSpectrum_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Save_Percent, i, "BLACK"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dRefud = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEud, i, "BLACK"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dRefvd = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CIEvd, i, "BLACK"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dLumi_Cd_A_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA, i, "BLACK"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dLumi_Cd_A_Percent = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_CdA_Percent, i, "BLACK"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dSpectrumSum_Ref = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum, i, "BLACK"))
            fmain.g_MeasuredDatas(nCh).sCellLTParams.BlackLTData(i).opticalData.dSpectrumSum_Per = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Spectrum_Percent, i, "BLACK"))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak1_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak2_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak3_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak4_Integral_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak1_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak2_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak3_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak3Integ_Lumi, i))
            'fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData(i).opticalData.dPeak4_Integral_RefValue_Lumi = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak4Integ_Lumi, i))
        Next

        '   fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData.opticalData.dPeak1_Lamda_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak1WaveLength))
        ' fmain.g_MeasuredDatas(nCh).sCellLTParams.LTData.opticalData.dPeak2_Lamda_RefValue = CDbl(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SeqInfo_Ref_Peak2WaveLength))
        '==================================================

        For n As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
            Select Case g_ConfigInfos.nDevice(n)

                Case frmConfigSystem.eDeviceItem.eSMU_M6000
                    Dim nDevNoOfM6000 As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                    Dim nChNoOfM6000 As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfM6000)
                    Dim m6000Set As CSeqRoutineM6000.sSettingInfo = Nothing

                    If fmain.cM6000 Is Nothing = False Then
                        Dim seqRoutineStateOfM600 As CSeqRoutineM6000.eSequenceState
                        seqRoutineStateOfM600 = CSeqRoutineM6000.ConvertStringSequenceStateToInteger(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.M6000SeqRoutine_Status))

                        If seqRoutineStateOfM600 = CSeqRoutineM6000.eSequenceState.eMeasuring Then
                            If CSeqRoutineM6000.ConvertM6000RecipeToSeqRoutineSettings(sequenceInfo.Current.sLifetimeInfo.sCellInfos(0), m6000Set) = False Then

                            End If
                            If fmain.cM6000(nDevNoOfM6000).Request(nChNoOfM6000, seqRoutineStateOfM600, m6000Set.SourceSetting) = False Then

                            End If

                            'fmain.cM6000(nDevNoOfM6000).ChannelStatus(nChNoOfM6000) = seqRoutineStateOfM600
                        ElseIf seqRoutineStateOfM600 < 0 Then
                            fmain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_M6000_MSG_Sub_routine_Status_Error) '  MsgBox("SubRoutine Status Error")
                            Return False
                        Else
                            fmain.cM6000(nDevNoOfM6000).ChannelStatus(nChNoOfM6000) = CSeqRoutineM6000.eSequenceState.eidle
                        End If
                    End If

                Case frmConfigSystem.eDeviceItem.eMcSG
                    Dim nGroupNoOfSG As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eGroupOfSG)
                    Dim nChNoOfSG As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSG)
                    If fmain.cMcSG Is Nothing = False Then

                        Dim lastStateOfSGRoutine As CSeqRoutineSG.eSequenceState

                        lastStateOfSGRoutine = CSeqRoutineSG.ConvertStringSequenceStateToInteger(Loader.LoadIniValue(CChannelStatusINI.eSecID.eChStateInfo, nCh, CChannelStatusINI.eKeyID.SGSeqRoutine_Status))

                        If lastStateOfSGRoutine < 0 Then '정보 자체가 잘못 저장 되었거나, 이전에 실행된 적이 없었던 상태

                            fmain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SG_MSG_Sub_routine_Status_Error)
                            Return False

                        ElseIf lastStateOfSGRoutine = CSeqRoutineSG.eSequenceState.eMeasuring Then  '측정이 진행중이었던 상태
                            Dim sgSet As CSeqRoutineSG.sSettingParam = Nothing

                            If CSeqRoutineSG.ConvertSGRecipeToSeqRoutineSettings(sequenceInfo.Current.sLifetimeInfo.sPanelInfos, sgSet) = False Then
                                fmain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SG_MSG_Wrong_Input_Signal)
                            End If

                            If fmain.cMcSG(nGroupNoOfSG).Request(nChNoOfSG, lastStateOfSGRoutine, sgSet) = False Then
                                fmain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SG_MSG_Wrong_Input_Signal)
                            End If

                        Else   '소스 셋팅 중이었거나, 소스 Off중인 상태 였으므로

                            fmain.cMcSG(nGroupNoOfSG).ChannelStatus(nChNoOfSG) = CSeqRoutineSG.eSequenceState.eidle

                        End If

                    End If
                Case frmConfigSystem.eDeviceItem.ePG

                Case frmConfigSystem.eDeviceItem.eTC

            End Select
        Next

        Return True
    End Function

End Class
