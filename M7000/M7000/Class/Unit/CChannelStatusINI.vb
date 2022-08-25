Public Class CChannelStatusINI
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub

    Private strSection() As String = New String() {"Common Information", "State Information Of Channel"}

    Private strKey() As String = New String() {"numOfCh",
        "SchedulerStatus",
        "SystemTime_IsSavedModeStartTime",
        "SystemTime_ModeStartTime",
        "SystemTime_IsSavedTestStartTime",
        "SystemTime_TestStartTime",
        "SystemTime_IntervalStartTime",
        "SystemTime_IsSavedIntervalStartTime",
        "SystemTime_Lifetime_Second",
        "SystemTime_Lifetime_Min",
        "SystemTime_Lifetime_Hour",
        "SystemTime_IsSavedLifeTime",
        "SaveInfo_Count",
        "SaveInfo_SavePath_LT",
        "SaveInfo_SavePath_LT_BackUp",
        "SaveInfo_SavePath_LT_Mirroring_BackUp",
        "SaveInfo_SavePath_LT_Spectrum",
        "SaveInfo_SavePath_LT_Spectrum_BackUp",
        "SaveInfo_TestStartTime",
        "SaveInfo_Lifetime",
        "SaveInfo_nCntSaveData",
        "SaveInfo_nCntREDSaveData",
        "SaveInfo_nCntGREENSaveData",
        "SaveInfo_nCntBLUESaveData",
        "SaveInfo_nCntBLACKSaveData",
        "SeqMgr_Index",
        "SeqMgr_CurrentRcpIdx",
        "SeqMgr_CurrentRcpIdx_LT",
        "SeqMgr_CurrentRcpIdx_ChangeTemp",
        "SeqMgr_CurrentRcpIdx_IVLSweep",
        "SeqMgr_CurrentRcpIdx_ViewingAngle",
        "SeqMgr_CurrentRcpIdx_LifetimeAndIVL",
        "SeqMgr_MeasCount_LifetimeAfterIVLSweep",
        "SeqMgr_MeasInterval_TimeVal_Second",
        "SeqMgr_MeasInterval_TimeVal_Min",
        "SeqMgr_MeasInterval_TimeVal_Hour",
        "SeqMgr_ChangeInterval_TimeVal_Second",
        "SeqMgr_ChangeInterval_TimeVal_Min",
        "SeqMgr_ChangeInterval_TimeVal_Hour",
        "SeqMgr_NextMeasureTime_TimeVal_Second",
        "SeqMgr_NextMeasureTime_TimeVal_Min",
        "SeqMgr_NextMeasureTime_TimeVal_Hour",
         "SeqMgr_RequestTest",
        "SeqMgr_RequestFirstTest",
        "SeqMgr_IsLastSequence",
        "SeqMgr_LoopCount",
        "M6000SeqRoutine_Status",
        "SGSeqRoutine_Status",
        "PGSeqRoutine_Status",
        "SeqInfo_Ref_PD_Saved_Status",
        "SeqInfo_Ref_PD_Value",
         "SeqInfo_Num_Of_Meas_Image",
        "SeqInfo_Num_Of_Meas_Point",
        "SeqInfo_Num_Of_Total_Meas_Point",
        "SeqInfo_Num_Of_Meas_OptcalDataList",
        "SeqInfo_Num_Of_Meas_EletricalDataList",
        "SeqInfo_Ref_Lumi",
        "SeqInfo_Ref_Lumi_Percent",
        "SeqInfo_Ref_Lumi_Percent_Delta",
        "SeqInfo_Ref_Voltage",
        "SeqInfo_Ref_Current",
        "SeqInfo_Ref_Current_Per",
        "SeqInfo_Ref_Spectrum_Save_Percent",
        "SeqInfo_Ref_CIEud",
        "SeqInfo_Ref_CIEvd",
        "SeqInfo_Ref_CdA",
        "SeqInfo_Ref_CdA_Percent",
                                               "SeqInfo_Ref_Spectrum",
                                               "SeqInfo_Ref_Spectrum_Percent",
        "SeqInfo_Ref_Peak1Integ",
        "SeqInfo_Ref_Peak2Integ",
        "SeqInfo_Ref_Peak3Integ",
        "SeqInfo_Ref_Peak4Integ",
        "SeqInfo_Ref_Peak1Integ_Lumi",
        "SeqInfo_Ref_Peak2Integ_Lumi",
        "SeqInfo_Ref_Peak3Integ_Lumi",
        "SeqInfo_Ref_Peak4Integ_Lumi",
        "SeqInfo_Ref_Peak1Integ_Percent",
        "SeqInfo_Ref_Peak2Integ_Percent",
        "SeqInfo_Ref_Peak3Integ_Percent",
        "SeqInfo_Ref_Peak4Integ_Percent",
        "SeqInfo_Ref_Peak1Integ_Lumi_Percent",
        "SeqInfo_Ref_Peak2Integ_Lumi_Percent",
        "SeqInfo_Ref_Peak3Integ_Lumi_Percent",
        "SeqInfo_Ref_Peak4Integ_Lumi_Percent",
        "SeqInfo_Ref_Peak1WaveLength",
        "SeqInfo_Ref_Peak2WaveLength",
        "SeqInfo_Num_Of_Meas_Color",
        "SeqInfo_Color_Type"}   ', "SeqMgr_SeqFilePath"
  
    Public Enum eSecID
        eCommInfo
        eChStateInfo
    End Enum

    Public Enum eKeyID
        numOfCh   'Common Info 
        SchedulerStatus    'Each Channel Status Info
        SystemTime_IsSavedModeStartTime
        SystemTime_ModeStartTime
        SystemTime_IsSavedTestStartTime
        SystemTime_TestStartTime
        SystemTime_IntervalStartTime
        SystemTime_IsSavedIntervalStartTime
        SystemTime_Lifetime_Second
        SystemTime_Lifetime_Min
        SystemTime_Lifetime_Hour
        SystemTime_IsSavedLifeTime
        SaveInfo_Count     '한채널에서 저장할 데이터 파일의 수 Recipe수와 같거나 ,Recipe 수 +1
        SaveInfo_SavePath_LT
        SaveInfo_SavePath_LT_BackUp
        SaveInfo_SavePath_LT_Mirroring_BackUp
        SaveInfo_SavePath_LT_Spectrum
        SaveInfo_SavePath_LT_Spectrum_BackUp
        SaveInfo_TestStartTime
        SaveInfo_Lifetime
        SaveInfo_nCntSaveData
        SaveInfo_nCntREDSaveData
        SaveInfo_nCntGREENSaveData
        SaveInfo_nCntBLUESaveData
        SaveInfo_nCntBLACKSaveData
        SeqMgr_Index
        SeqMgr_CurrentRcpIdx
        SeqMgr_CurrentRcpIdx_LT
        SeqMgr_CurrentRcpIdx_ChangeTemp
        SeqMgr_CurrentRcpIdx_IVLSweep
        SeqMgr_CurrentRcpIdx_ViewingAngle
        SeqMgr_CurrentRcpIdx_LifetimeAndIVL
        SeqMgr_MeasCount_LifetimeAfterIVLSweep
        SeqMgr_MeasInterval_TimeVal_Second
        SeqMgr_MeasInterval_TimeVal_Min
        SeqMgr_MeasInterval_TimeVal_Hour
        SeqMgr_ChangeInterval_TimeVal_Second
        SeqMgr_ChangeInterval_TimeVal_Min
        SeqMgr_ChangeInterval_TimeVal_Hour
        SeqMgr_NextMeasureTime_TimeVal_Second
        SeqMgr_NextMeasureTime_TimeVal_Min
        SeqMgr_NextMeasureTime_TimeVal_Hour
        SeqMgr_RequestTest
        SeqMgr_RequestFirstTest
        SeqMgr_IsLastSequence
        SeqMgr_LoopCount
        M6000SeqRoutine_Status
        SGSeqRoutine_Status
        PGSeqRoutine_Status
        SeqInfo_Ref_PD_Saved_Status
        SeqInfo_Ref_PD_Value
        SeqInfo_Num_Of_Meas_Image
        SeqInfo_Num_Of_Meas_Point
        SeqInfo_Num_Of_Total_Meas_Point
        SeqInfo_Num_Of_Meas_OptcalDataList
        SeqInfo_Num_Of_Meas_EletricalDataList
        SeqInfo_Ref_Lumi
        SeqInfo_Ref_Lumi_Percent
        SeqInfo_Ref_Lumi_Percent_Delta
        SeqInfo_Ref_Voltage
        SeqInfo_Ref_Current
        SeqInfo_Ref_Current_Per
        SeqInfo_Ref_Spectrum_Save_Percent
        SeqInfo_Ref_CIEud
        SeqInfo_Ref_CIEvd
        SeqInfo_Ref_CdA
        SeqInfo_Ref_CdA_Percent
        SeqInfo_Ref_Spectrum
        SeqInfo_Ref_Spectrum_Percent
        SeqInfo_Ref_Peak1Integ
        SeqInfo_Ref_Peak2Integ
        SeqInfo_Ref_Peak3Integ
        SeqInfo_Ref_Peak4Integ
        SeqInfo_Ref_Peak1Integ_Lumi
        SeqInfo_Ref_Peak2Integ_Lumi
        SeqInfo_Ref_Peak3Integ_Lumi
        SeqInfo_Ref_Peak4Integ_Lumi
        SeqInfo_Ref_Peak1Integ_Percent
        SeqInfo_Ref_Peak2Integ_Percent
        SeqInfo_Ref_Peak3Integ_Percent
        SeqInfo_Ref_Peak4Integ_Percent
        SeqInfo_Ref_Peak1Integ_Lumi_Percent
        SeqInfo_Ref_Peak2Integ_Lumi_Percent
        SeqInfo_Ref_Peak3Integ_Lumi_Percent
        SeqInfo_Ref_Peak4Integ_Lumi_Percent
        SeqInfo_Ref_Peak1WaveLength
        SeqInfo_Ref_Peak2WaveLength
        SeqInfo_Num_Of_Meas_Color
        SeqInfo_Color_Type
    End Enum

    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal value As String)

        Dim sSection As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")

        IniWriteValue(sSection, strKey(nKey), value)
    End Sub


    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String, Optional ByVal subKeyValue As String = "")
        Dim sSection As String
        Dim sKey As String

        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")

        sKey = strKey(nKey) & subKeyValue & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID) As String
        Dim sSection As String

        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
   
        Return IniReadValue(sSection, strKey(nkey))
    End Function

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID, ByVal keyIndex As Integer, Optional ByVal subKey As String = "") As String
        Dim sSection As String
        Dim sKey As String

        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")

        sKey = strKey(nkey) & subKey & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function

End Class
