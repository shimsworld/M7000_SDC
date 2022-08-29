Public Class CRcpINI
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub

    Private strSection() As String = New String() {"File Info", "Common Settings", "Recipe"}


    Private strKey() As String = New String() {
"Recipe List",
"SeqCommon_PathAndFName", "SeqCommon_OnlyFName", "SeqCommon_FNameAndExt", "SeqCommon_OnlyExt", "SeqCommon_FPath", "SeqCommon_Date",
"SeqCommon_Counter_TestEndSetting", "SeqCommon_TestEndParam_TypeOfParam", "SeqCommon_TestEndParam_Value",
"SeqCommon_DefaultTemp", "SeqCommon_ACFMode",
"SeqCommon_Counter_LimitedSetting", "SeqCommon_Limited_TypeOfParam", "SeqCommon_Limited_MaxValue", "SeqCommon_Limited_MinValue",
"SeqCommon_SampleInfo_Type", "SeqCommon_SampleInfo_ColorType", "SeqCommon_SampleInfo_Color", "SeqCommon_Title", "SeqCommon_SampleInfo_Size",
"SeqCommon_SampleInfo_FF", "SeqCommon_SampleInfo_Comment",
"SeqCommon_AccumulateTempChangeTime", "SeqCommon_ContinuousDataSave",
"SeqCommon_CounterTestRecipe", "SeqCommon_CounterLifeTimeMode", "SeqCommon_CounterChangeTemp", "SeqCommon_CounterIVLSweep",
"SeqCommon_CounterImageSweep", "SeqCommon_CounterGrayScaleSweep", "SeqCommon_CounterPatternMeas", "SeqCommon_CounterViewingAngle", "SeqCommon_CounterLifetimeAndIVL",
"Mode",
"LTCommon_Mode", "LTCommon_RefPDSet_EnableRenewal", "LTCommon_RefPDSet_RenewalTime",
"LTCommon_Counter_TestEndSetting", "LTCommon_TestEndParam_TypeOfParam", "LTCommon_TestEndParam_Value",
"LTCommon_Counter_MeasSetting", "LTCommon_MeasSetting_Interval", "LTCommon_MeasSetting_ChangeTime",
"LTCommon_EndBiasStatus", "LTCommon_Counter_TestIVLSweepMeasSetting", "LTCommon_TestIVLSweepMeasParam_TypeOfParam", "LTCommon_TestIVLSweepMeasParam_Value",
"ChangeTemp_TargetTemp", "ChangeTemp_StableTime",
"CellLT_Counter_M6000SrcSetting", "CellLT_Enable_M6000SrcSetting", "CellLT_Src_Mode", "CellLT_Src_EnableRevMode", "CellLT_Src_Bias", "CellLT_Src_Amplitude",
"CellLT_Src_Pulse_Frequency", "CellLT_Src_Pulse_Duty", "CellLT_Src_Pulse_EnableDutyDivision",
"CellLT_IntegralWLCount", "CellLT_WL1_START", "CellLT_WL1_STOP", "CellLT_WL2_START", "CellLT_WL2_STOP", "CellLT_WL3_START", "CellLT_WL3_STOP", "CellLT_WL4_START", "CellLT_WL4_STOP",
"PanelLT_Counter_SignalLine", "PanelLT_Signal_Name", "PanelLT_Signal_SrcMode", "PanelLT_Signal_VLow", "PanelLT_Signal_VHigh",
"PanelLT_Signal_Pulse_Delay", "PanelLT_Signal_Pulse_Width", "PanelLT_Signal_Pulse_Period",
"Panel_Signal_Limit_Current", "Panel_Signal_Limit_Temp", "Panel_Signal_Limit_Average",
"Module Counter PwrLine", "Module Pwr Ch", "Module Pwr Volt", "Module Pwr CurrentLimit", "Module Pwr ONDelay", "Module Pwr OFFDelay",
"Module Counter Image", "Module MeasImage IsSelected", "Module MeasImage ImageName", "Module MeasImage FilePath", "Module MeasImage DelayTime",
"Module SlideImage IsSelected", "Module SlideImage ImageName", "Module SlideImage FilePath", "Module SlideImage DelayTime",
"Module GrayScale White", "Module GrayScale Red", "Module GrayScale Green", "Module GrayScale Blue", "Module Def. Pattern", "Module Counter Reg",
"Module Reg Name", "Module Reg CMD", "Module Reg LenOfValue", "Module Reg Value", "Module_GnT_ModelName", "Module_GnT_Enable_ModelDownload", "Module_GnT_ACFImageIdx",
"ImageSweep_Counter_Image", "ImageSweep_IsSelected", "ImageSweep_ImageName", "ImageSweep_FilePath", "ImageSweep_DelayTime",
"MeasPos_Counter", "MeasPos_Margin_X", "MeasPos_Margin_Y", "MeasPos_X", "MeasPos_Y", "MeasPoint_color",
"GrayScaleSweep_Mode", "GrayScaleSweep_LenSweepValue", "GrayScaleSweep_SweepValue_White", "GrayScaleSweep_SweepValue_Red", "GrayScaleSweep_SweepValue_Green", "GrayScaleSweep_SweepValue_Blue",
"IVLCommon_Average", "IVLCommon_BiasMode", "IVLCommon_CycleDelay", "IVLCommon_DelayState", "IVLCommon_LMeasLevel", "IVLCommon_MeasItem", "IVLCommon_MeasureDelay", "IVLCommon_OffsetBias",
"IVLCommon_SweepMode", "IVLCommon_SweepMethod", "IVLCommon_SweepType", "IVLCommon_SweepDelay", "IVLCommon_SweepLine",
"IVLCommon_Count_SweepSetting", "IVLCommon_SweepSetting_Number", "IVLCommon_SweepSetting_Start", "IVLCommon_SweepSetting_Stop", "IVLCommon_SweepSetting_Step", "IVLCommon_SweepSetting_Point", "IVLCommon_SweepSetting_Level",
"IVLCommon_SweepSetting_Type", "IVLCommon_PowerSetting_Type1", "IVLCommon_PowerSetting_StopV1", "IVLCommon_PowerSetting_StopC1",
"IVLCommon_PowerSetting_Type2", "IVLCommon_PowerSetting_StopV2", "IVLCommon_PowerSetting_StopC2", "IVLCommon_PowerSetting_Type3", "IVLCommon_PowerSetting_StopV3",
"IVLCommon_PowerSetting_StopC3", "IVLCommon_PowerSetting_Type4", "IVLCommon_PowerSetting_StopV4", "IVLCommon_PowerSetting_StopC4",
"IVLCommon_PowerSetting_Type5", "IVLCommon_PowerSetting_StopV5", "IVLCommon_PowerSetting_StopC5",
"IVLCommon_Count_SweepList", "IVLCommon_UserSweepSetting_Bias", "IVLCommon_Count_ColorList", "IVLCommon_SweepColor_Number", "IVLCommon_ViewingAngle", "IVLCommon_FirstSweep",
"IVLCommon_LMeasLimit", "IVLCommon_CurrentLimit", "IVLCommon_LumiCorrection", "IVLCommon_BiasInvert", "IVLCommon_ValueForFast", "IVLCommon_FastNormalMode", "IVLCommon_FastBiasMode", "IVLCommon_LimitIsAnd",
"IVLDevice_Keithley_IntegTime", "IVLDevice_Keithley_IntegTimeIndex", "IVLDevice_Keithley_LimitVoltage", "IVLDevice_Keithley_LimitCurrent", "IVLDevice_Keithley_MeasureMode", "IVLDevice_keithley_MeasureDelay", "IVLDevice_Keithley_MeasureDelayAuto",
"IVLDevice_Keithley_MeasureAuroRange", "IVLDevice_Keithley_NumofMeasData", "IVLDevice_Keithley_SourceMode", "IVLDevice_Keithley_SourceDelay",
"IVLDevice_Keithley_SourceAutoRange", "IVLDevice_Keithley_TerminalMode", "IVLDevice_Keithley_WireMode",
"IVLRGBSignal_Red", "IVLRGBSignal_Green", "IVLRGBSignal_Blue",
     "ViewingAngle_Common_SweepType",
 "ViewingAngle_Common_SrcDevice", "ViewingAngle_Common_BiasMode", "ViewingAngle_Common_BiasValue", "ViewingAngle_Common_LumiCorrection", "ViewingAngle_Count_SweepSetting",
 "ViewingAngle_SweepSetting_Number", "ViewingAngle_SweepSetting_Start", "ViewingAngle_SweepSetting_Stop", "ViewingAngle_SweepSetting_Step",
 "ViewingAngle_SweepSetting_Point", "ViewingAngle_SweepSetting_Level", "ViewingAngle_Count_SweepList", "ViewingAngle_SweepList_Bias",
 "ViewingAngleDevice_Keithley_IntegTime", "ViewingAngleDevice_Keithley_IntegTimeIndex", "ViewingAngleDevice_Keithley_LimitVoltage", "ViewingAngleDevice_Keithley_LimitCurrent", "ViewingAngleDevice_Keithley_MeasureMode", "ViewingAngleDevice_keithley_MeasureDelay", "ViewingAngleDevice_Keithley_MeasureDelayAuto",
"ViewingAngleDevice_Keithley_MeasureAuroRange", "ViewingAngleDevicee_Keithley_NumofMeasData", "ViewingAngleDevice_Keithley_SourceMode", "ViewingAngleDevice_Keithley_SourceDelay",
"ViewingAngleDevice_Keithley_SourceAutoRange", "ViewingAngleDevice_Keithley_TerminalMode", "ViewingAngleDevice_Keithley_WireMode",
"Aging_Mode", "Aging_EndBiasStatus", "Aging_Counter_TestEndStting", "Aging_TestEndParam_Typeofparm", "Aging_TestEndParam_Value"}


    Public Enum eSecID
        eFileInfo
        eCommonSettings
        eRecipe
    End Enum

    Public Enum eKeyID
        FileTitle
        SeqCommon_SaveInfo_PathAndName  'Test End
        SeqCommon_SaveInfo_OnlyFName
        SeqCommon_SaveInfo_FNameAndExt
        SeqCommon_SaveInfo_OnlyExt
        SeqCommon_SaveInfo_FPath
        SeqCommon_SaveInfo_Date
        SeqCommon_Counter_TestEndSetting
        SeqCommon_TestEndParam_TypeOfParam
        SeqCommon_TestEndParam_Value
        SeqCommon_Default_Temp
        SeqCommon_ACFMode
        SeqCommon_Counter_LimitSetting             '
        SeqCommon_Limit_TypeOfParam                '
        SeqCommon_Limit_MaxValue
        SeqCommon_Limit_MinValue
        SeqCommon_SampleInfo_Type
        SeqCommon_SampleInfo_ColorType
        SeqCommon_SampleInfo_Color
        SeqCommon_Title
        SeqCommon_SampleInfo_Size
        SeqCommon_SampleInfo_FF
        SeqCommon_SampleInfo_Comment
        SeqCommon_SaveOpt_AccumulateTempChangeTime
        SeqCommon_SaveOpt_ContinuousDataSave
        SeqCommon_Counter_TestRecipe
        SeqCommon_Counter_LifeTimeMode
        SeqCommon_Counter_ChangeTemp
        SeqCommon_Counter_IVLSweep
        SeqCommon_Counter_ImageSweep
        SeqCommon_Counter_GrayScasleSweep
        SeqCommon_Counter_PatternMeas
        SeqCommon_Counter_ViewingAngle
        SeqCommon_Counter_LifetimeAndIVL
        eMode      'LifeTime, Change Temperatuer, IVL, Image Sweep, Gray Scale Sweep 등
        eLTCommon_Mode   'Keeping or Operation
        eLTCommon_RefPDSet_EnableRenewal
        eLTCommon_RefPDSet_RenewalTime
        eLTCommon_Counter_TestEndSetting
        eLTCommon_TestEndParam_TypeOfParam
        eLTCommon_TestEndParam_Value
        eLTCommon_Counter_MeasSetting
        eLTCommon_MeasSetting_Interval
        eLTCommon_MeasSetting_ChangeTime
        eLTCommon_EndBiasStatus 'LifeTime 종료 시점에 Source 계속 유지 할지 말지 설정 2013-03-28 승현
        eLTCommon_Counter_TestIVLSweepMeasSetting
        eLTCommon_TestIVLSweepMeasParam_TypeOfParam
        eLTCommon_TestIVLSweepMeasParam_Value
        eChangeTemp_TargetTemp
        eChangeTemp_StableTime
        sCell_Counter_M6000SrcSetting
        sCell_Enable_M6000SrcSetting
        eCell_M6000SrcSetting_Mode 'CC, CV, PV, PCV   'M6000 장비가  Cell Lifetime 전용 이므로, 만얀 다른 장비가 추가되면 이름을 M6000_SrcSetting_Mode로 변경 해야 함.
        eCell_M6000SrcSetting_EnableRevMode '
        eCell_M6000SrcSetting_Bias
        eCell_M6000SrcSetting_Amplitude
        eCell_M6000SrcSetting_Pulse_Frequency
        eCell_M6000SrcSetting_Pulse_Duty
        eCell_M6000SrcSetting_Pulse_EnableDutyDivision
        eCell_IntegralWLCount
        eCell_WL1_START
        eCell_WL1_STOP
        eCell_WL2_START
        eCell_WL2_STOP
        eCell_WL3_START
        eCell_WL3_STOP
        eCell_WL4_START
        eCell_WL4_STOP
        ePanel_Counter_SignalLine   'Panel
        ePanel_Signal_Name
        ePanel_Signal_SrcMode
        ePanel_Signal_VLow
        ePanel_Signal_VHigh
        ePanel_Signal_Pulse_Delay
        ePanel_Signal_Pulse_Width
        ePanel_Signal_Pulse_Period
        ePanel_Signal_Limit_Current
        ePanel_Signal_Limit_Temp
        ePanel_Signal_Limit_Average
        eModule_Counter_PwrLine   'Module
        eModule_Pwr_Ch
        eModule_Pwr_Volt
        eModule_Pwr_CurrentLimit
        eModule_Pwr_ONDelay
        eModule_Pwr_OFFDelay
        eModule_Counter_Image
        eModule_MeasImage_IsSelected
        eModule_MeasImage_ImageName
        eModule_MeasImage_FilePath
        eModule_MeasImage_DelayTime
        eModule_SlideImage_IsSelected
        eModule_SlideImage_ImageName
        eModule_SlideImage_FilePath
        eModule_SlideImage_DelayTime
        eModule_GrayScale_White
        eModule_GrayScale_Red
        eModule_GrayScale_Green
        eModule_GrayScale_Blue
        eModule_Def_Pattern
        eModule_Counter_Reg
        eModule_Reg_Name
        eModule_Reg_CMD
        eModule_Reg_LenOfValue
        eModule_Reg_Value
        eModule_GnT_ModelName
        eModule_GnT_Enable_ModelDownload
        eModule_GnT_ACFImageIdx
        eImageSweep_Counter_Image   'Module Image Sweep
        eImageSweep_IsSelected
        eImageSweep_ImageName
        eImageSweep_FilePath
        eImageSweep_DelayTime
        eMeasPos_Counter    'Measurement Position
        eMeasPos_Margin_X
        eMeasPos_Margin_Y
        eMeasPos_X
        eMeasPos_Y
        eMeasPtColor
        eGrayScaleSweep_Mode   'Gray Scale Sweep
        eGrayScaleSweep_LenSweepValue
        eGrayScaleSweep_SweepValue_White
        eGrayScaleSweep_SweepValue_Red
        eGrayScaleSweep_SweepValue_Green
        eGrayScaleSweep_SweepValue_Blue
        eIVLCommon_Average    'IVL Sweep Common
        eIVLCommon_BiasMode
        eIVLCommon_CycleDelay
        eIVLCommon_DelayState
        eIVLCommon_LMeasLevel
        eIVLCommon_MeasItem
        eIVLCommon_MeasureDelay
        eIVLCommon_OffsetBias
        eIVLCommon_SweepMode
        eIVLCommon_SweepMethod
        eIVLCommon_SweepType
        eIVLCommon_SweepDelay
        eIVLCommon_SweepLine
        eIVLCommon_Count_SweepSetting
        eIVLCommon_SweepSetting_Number
        eIVLCommon_SweepSetting_Start
        eIVLCommon_SweepSetting_Stop
        eIVLCommon_SweepSetting_Step
        eIVLCommon_SweepSetting_Point
        eIVLCommon_SweepSetting_Level
        eIVLCommon_SweepSetting_Type '220829 Update by JKY
        eIVLCommon_PowerSetting_Type1
        eIVLCommon_PowerSetting_StopV1
        eIVLCommon_PowerSetting_StopC1
        eIVLCommon_PowerSetting_Type2
        eIVLCommon_PowerSetting_StopV2
        eIVLCommon_PowerSetting_StopC2
        eIVLCommon_PowerSetting_Type3
        eIVLCommon_PowerSetting_StopV3
        eIVLCommon_PowerSetting_StopC3
        eIVLCommon_PowerSetting_Type4
        eIVLCommon_PowerSetting_StopV4
        eIVLCommon_PowerSetting_StopC4
        eIVLCommon_PowerSetting_Type5
        eIVLCommon_PowerSetting_StopV5
        eIVLCommon_PowerSetting_StopC5 ' ===
        eIVLCommon_Count_SweepList
        eIVLCommon_SweepList_Bias
        eIVLCommon_Count_ColorList
        eIVLCommon_SweepList_Color
        eIVLCommon_ViewingAngle
        eIVLCommon_FirstSweep
        eIVLCommon_LMeasLimit
        eIVLCommon_CurrentLimit
        eIVLCommon_LumiCorrection
        eIVLCommon_BiasInvert
        eIVLCommon_ValueForFast  '추가
        eIVLCommon_FastNormalMode
        eIVLCommon_FastBiasMode
        eIVLCommon_LimitIsAnd
        eIVLDevice_Keithley_IntegTime   'IVL Device Keithley
        eIVLDevice_Keithley_IntegTimeIndex
        eIVLDevice_Keithley_LimitVoltage
        eIVLDevice_Keithley_LimitCurrent
        eIVLDevice_Keithley_MeasureMode
        eIVLDevice_keithley_MeasureDelay
        eIVLDevice_Keithley_MeasureDelayAuto
        eIVLDevice_Keithley_CurrentRange
        eIVLDevice_Keithley_NumofMeasData
        eIVLDevice_Keithley_SourceMode
        eIVLDevice_Keithley_SourceDelay
        eIVLDevice_Keithley_VoltageRange
        eIVLDevice_Keithley_TerminalMode
        eIVLDevice_Keithley_WireMode
        eIVLRGBSignal_Red
        eIVLRGBSignal_Green
        eIVLRGBSignal_Blue
        eViewingAngle_Common_SweepType
        eViewingAngle_Common_SrcDevice
        eViewingAngle_Common_BiasMode
        eViewingAngle_Common_BiasValue
        eViewingAngle_Common_LumiCorrection
        eViewingAngle_Count_SweepSetting   'Viewing Angle
        eViewingAngle_SweepSetting_Number
        eViewingAngle_SweepSetting_Start
        eViewingAngle_SweepSetting_Stop
        eViewingAngle_SweepSetting_Step
        eViewingAngle_SweepSetting_Point
        eViewingAngle_SweepSetting_Level
        eViewingAngle_Count_SweepList
        eViewingAngle_SweepList_Bias
        eViewingAngle_Keithley_IntegTime   'IVL Device Keithley
        eViewingAngle_Keithley_IntegTimeIndex
        eViewingAngle_Keithley_LimitVoltage
        eViewingAngle_Keithley_LimitCurrent
        eViewingAngle_Keithley_MeasureMode
        eViewingAngle_keithley_MeasureDelay
        eViewingAngle_Keithley_MeasureDelayAuto
        eViewingAngle_Keithley_CurrentRange
        eViewingAngle_Keithley_NumofMeasData
        eViewingAngle_Keithley_SourceMode
        eViewingAngle_Keithley_SourceDelay
        eViewingAngle_Keithley_VoltageRange
        eViewingAngle_Keithley_TerminalMode
        eViewingAngle_Keithley_WireMode
        eAging_Mode
        eAging_EndBiasStatus
        eAging_Counter_TestEndSetting
        eAging_TestEndParam_TypeofParam
        eAging_TestEndParam_Value
    End Enum

    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal value As String)
        Dim sSection As String
        If nSection = eSecID.eRecipe Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        IniWriteValue(sSection, strKey(nKey), value)
    End Sub


    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String)
        Dim sSection As String
        Dim sKey As String
        If nSection = eSecID.eRecipe Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        sKey = strKey(nKey) & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID) As String
        Dim sSection As String
        If nSection = eSecID.eRecipe Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        Return IniReadValue(sSection, strKey(nkey))
    End Function

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID, ByVal keyIndex As Integer) As String
        Dim sSection As String
        Dim sKey As String
        If nSection = eSecID.eRecipe Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        sKey = strKey(nkey) & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function


End Class
