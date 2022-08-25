Public Class CSeqBuilderSettingsINI
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub

    Private strSection() As String = New String() {"File Info", "Common Settings", "Default Value", "View", "Settings", "UI Settings"}


    Private strKey() As String = New String() {"File Title", "File version",
                                               "Common",
                                               "DefValue_Counter_LimitedSetting", "DefValue_Limited_TypeOfParam", "DefValue_Limited_MaxValue", "DefValue_Limited_MinValue",
                                               "DefValue_Counter_EndCondition", "DefValue_EndConditon_TypeOfParam", "DefValue_EndCondition_Value",
                                               "DefValue_MeasureInterval_MaxValue", "DefValue_MeasureInterval_MinValue",
                                               "DefValue_MeasureAngle_MaxValue", "DefValue_MeasureAngle_MinValue", "DefValue_Temperature",
                                               "DefValue_SampleSize_Width", "DefValue_SampleSizeHight", "DefValue_FillFactor",
                                               "Common Recipe", "IVL Sweep Recipe", "Lifetime Recipe", "LifetimeAndIVL Recipe", "Temperature Recipe", "GrayScale Sweep Recipe", "Image Sweep Recipe", "RGBW Aging Recipe", "Pattern Recipe", "Viewing Angle Recipe", "Aging Recipe", _
       "Sequence Title", "Sample Type", "Sample Color", "Sample Size", "Fill Factor", "Comment", "Default Temp", "ACF Mode", "Limit Settings", "Sequence End Settings", _
       "IVL Sweep Detail Settings", "IVL Sweep Common Bias Mode", "IVL Sweep Common Measuremnet Mode", "IVL Sweep Common Sweep Type", "IVL Sweep Common Luminance Measure Level", _
       "IVL Sweep Common Luminance Measure Limit", "IVL Sweep Common Current Measure Limit", "IVL Sweep Common Sweep Region Settings", "IVL Sweep Common Viewing Angle", "IVL Sweep Common Color List", "IVL Common LumiCorrection", _
       "IVL Sweep K26xx Bias Mode", "IVL Sweep K26xx Wire Mode", "IVL Sweep K26xx Terminal Mode", "IVL Sweep K26xx Source Settings", "IVL Sweep K26xx Measure Settings", _
       "Lifetime Common Operation Mode", "Lifetime Common Ref. Luminance Settings", "Lifetime Common End Action", "Lifetime Common Save Interval Settings", "Lifetime Common End Condition Settings",
       "Lifetime M6000 ChkEnable", "Lifetime M6000 Source Mode", "Lifetime M6000 SetRev", "Lifetime M6000 Bias", "Lifetime M6000 Amplitude", "Lifetime M6000 Frequency", "Lifetime M6000 Duty", "Lifetime M6000 Constant Brightness", "Lifetime M6000 BtnADD", _
       "Lifetime McSG Signal Editor", "Lifetime McSG RGBW Rotation", "Lifetime McPG Init Code Editor", "Lifetime McPG Power Control", "Lifetime McPG Pattern Editor", "Lifetime Viewing Angle Settings",
       "Temperature Rcp Target Temperature", "Temperature Rcp Stabilization Time", _
                              "Viewing Angel Sweep Common Device", "Viewing Angel Sweep Common Bias Mode", "Viewing Angel Sweep Common Bias", "Viewing Angel Sweep Common Sweep Type", "Viewing Angel Sweep Common Sweep Region Settings", _
    "Viewing Angel Sweep M6000 ChkEnable", "Viewing Angel Sweep M6000 Source Mode", "Viewing Angel Sweep M6000 SetRev", "Viewing Angel Sweep M6000 Bias", "Viewing Angel Sweep M6000 Amplitude", "Viewing Angel Sweep M6000 Frequency", "Viewing Angel Sweep M6000 Duty", _
    "Viewing Angel Sweep M6000 Constant Brightness", "Viewing Angel Sweep M6000 BtnAdd", _
    "Viewing Angel Sweep K26XX Bias Mode", "Viewing Angel Sweep K26XX Wire Mode", "Viewing Angel Sweep K26XX Terminal Mode", "Viewing Angel Sweep K26XX Source Settings", "Viewing Angel Sweep K26XX Measure Settings",
                              "Test End Param Count", "Test End Param Item",
     "UISettings_SequenceList_SplitterDistance", "UISettings_SequenceEdit_SplitterDistance",
                                               "UISettings_SequenceEditList_splitterDistance",
                                               "UISettings_Rcp_LT_SplitterDistance",
                                               "UISettings_Rcp_IVL_SplitterDistance",
                                               "UISettings_Rcp_ViewingAngle_splitterDistance",
                                               "UISettings_Rcp_LifetimeAndIVL_SplitterDistance",
                                               "UISettings_FrameSize_Height", "UISettings_FrameSize_Width"}

    Public Enum eSecID
        _FileInfo
        _Common
        _DefValue
        _View
        _Settings
        _UI_Settings
    End Enum

    Public Enum eKeyID
        _FileInfo_File_Title
        _FileInfo_FILE_VERSION
        _Common_
        _DefValue_Limit_Counter
        _DefValue_Limit_TypeOfParam                '
        _DefValue_Limit_MaxValue
        _DefValue_Limit_MinValue
        _DefValue_EndCondition_Counter
        _DefValue_EndCondition_TypeOfParam
        _defValue_EndCondition_Value
        _DefValue_MeasureInterval_MaxValue
        _DefValue_MeasureInterval_MinValue
        _DefValue_MeasureAngle_MaxValue
        _DefValue_MeasureAngle_MinValue
        _DefValue_Temperature
        _DefValue_SampleSize_Width
        _DefValue_SampleSize_Hight
        _DefValue_FillFactor
        _View_RecipeGrp_Common
        _View_RecipeGrp_IVL
        _View_RecipeGrp_Lifetime
        _View_RecipeGrp_LifetimeAndIVL
        _View_RecipeGrp_Temp
        _View_RecipeGrp_GrayScaleSweep
        _View_RecipeGrp_ImageSweep
        _View_RecipeGrp_RGBWAging
        _View_RecipeGrp_Pattern
        _View_RecipeGrp_ViewingAngle
        _View_RecipeGrp_Aging
        _View_CommonGrp_SequenceTitle
        _View_CommonGrp_SampleType
        _View_CommonGrp_SampleColor
        _View_CommonGrp_SampleSize
        _View_CommonGrp_FillFactor
        _View_CommonGrp_Comment
        _View_CommonGrp_DefaultTemp
        _View_CommonGrp_ACFMode
        _View_CommonGrp_LimitSetting
        _View_CommonGrp_SequenceEndSetting
        _View_IVLRcpGrp_Common_DetailSettings
        _View_IVLRcpGrp_Common_BiasMode
        _View_IVLRcpGrp_Common_MeasuremnetMode
        _View_IVLRcpGrp_Common_SweepType
        _View_IVLRcpGrp_Common_LuminanceMeasureLevel
        _View_IVLRcpGrp_Common_LuminanceMeasureLimit
        _View_IVLRcpGrp_Common_CurrentMeasureLimit
        _View_IVLRcpGrp_Common_SweepRegionSettings
        _View_IVLRcpGrp_Common_ViewingAngle
        _View_IVLRcpGrp_Common_ColorList
        _View_IVLRcpGrp_Common_LumiCorrection
        _View_IVLRcpGrp_K26xx_BiasMode
        _View_IVLRcpGrp_K26xx_WireMode
        _View_IVLRcpGrp_K26xx_TermianlMode
        _View_IVLRcpGrp_K26xx_SourceSettings
        _View_IVLRcpGrp_K26xx_MeasureSettings
        _View_LTRcpGrp_Common_OperationMode
        _View_LTRcpGrp_Common_RefLuminanceSettings
        _View_LTRcpGrp_Common_EndAction
        _View_LTRcpGrp_Common_SaveIntervalSettings
        _View_LTRcpGrp_Common_EndConditionSettings
        _View_LTRcpGrp_M6000_ChkEnable
        _View_LTRcpGrp_M6000_SourceMode
        _View_LTRcpGrp_M6000_SetRev
        _View_LTRcpGrp_M6000_Bias
        _View_LTRcpGrp_M6000_Amplitude
        _View_LTRcpGrp_M6000_Frequency
        _View_LTRcpGrp_M6000_Duty
        _View_LTRcpGrp_M6000_ConstantBrightness
        _View_LTRcpGrp_M6000_BtnADD
        _View_LTRcpGrp_McSG_SignalEditor
        _View_LTRcpGrp_McSG_RGBWRotation
        _View_LTRcpGrp_McPG_InitCodeEditor
        _View_LTRcpGrp_McPG_PowerControl
        _View_LTRcpGrp_McPG_PatternEditor
        _View_LTRcpGrp_ViewingAngleSettings
        _View_TempRcpGrp_Common_TargetTemperature
        _View_TempRcpGrp_Common_StabilizationTime
        _View_ViewingAngleRcpGrp_Common_DeviceUnit
        _View_ViewingAngleRcpGrp_Common_BiasMode
        _View_ViewingAngleRcpGrp_Common_Bias
        _View_ViewingAngleRcpGrp_Common_SweepType
        _View_ViewingAngleRcpGrp_Common_SweepRegionSettings
        _View_ViewingAngleRcpGrp_M6000_ChkEnable
        _View_ViewingAngleRcpGrp_M6000_SourceMode
        _View_ViewingAngleRcpGrp_M6000_SetRev
        _View_ViewingAngleRcpGrp_M6000_Bias
        _View_ViewingAngleRcpGrp_M6000_Amplitude
        _View_ViewingAngleRcpGrp_M6000_Frequency
        _View_ViewingAngleRcpGrp_M6000_Duty
        _View_ViewingAngleRcpGrp_M6000_ConstantBrightness
        _View_ViewingAngleRcpGrp_M6000_BtnADD
        _View_ViewingAngleRcpGrp_K26xx_BiasMode
        _View_ViewingAngleRcpGrp_K26xx_WireMode
        _View_ViewingAngleRcpGrp_K26xx_TermianlMode
        _View_ViewingAngleRcpGrp_K26xx_SourceSettings
        _View_ViewingAngleRcpGrp_K26xx_MeasureSettings
        _Settings_TestEndParam_Count
        _Settings_TestEndParam_Item
        _UISettings_SequenceList_SplitterDistance
        _UISettings_SequenceEdit_SplitterDistance
        _UISettings_SequenceEditList_splitterDistance
        _UISettings_Rcp_LT_SplitterDistance
        _UISettings_Rcp_IVL_SplitterDistance
        _UISettings_Rcp_ViewingAngle_splitterDistance
        _UISettings_Rcp_LifetimeAndIVL_SplitterDistance
        _UISettings_FrameSize_Height
        _UISettings_FrameSize_Width
    End Enum



    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal nKey As eKeyID, ByVal value As String)
        Dim sSection As String

        sSection = strSection(nSection)

        IniWriteValue(sSection, strKey(nKey), value)
    End Sub

    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal nSectionIndex As Integer, ByVal nKey As eKeyID, ByVal value As String)
        Dim sSection As String

        sSection = strSection(nSection) & Format(nSectionIndex + 1, "00")

        IniWriteValue(sSection, strKey(nKey), value)
    End Sub

    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String)
        Dim sSection As String
        Dim sKey As String

        sSection = strSection(nSection)
        sKey = strKey(nKey) & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub


    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal nSectionIndex As Integer, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String)
        Dim sSection As String
        Dim sKey As String

        sSection = strSection(nSection) & Format(nSectionIndex + 1, "00")

        sKey = strKey(nKey) & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal nkey As eKeyID) As String
        Dim sSection As String

        sSection = strSection(nSection)

        Return IniReadValue(sSection, strKey(nkey))
    End Function

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal nSectionIndex As Integer, ByVal nkey As eKeyID) As String
        Dim sSection As String

        sSection = strSection(nSection) & Format(nSectionIndex + 1, "00")

        Return IniReadValue(sSection, strKey(nkey))
    End Function

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal nkey As eKeyID, ByVal keyIndex As Integer) As String
        Dim sSection As String
        Dim sKey As String

        sSection = strSection(nSection)

        sKey = strKey(nkey) & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function


    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal nSectionIndex As Integer, ByVal nkey As eKeyID, ByVal keyIndex As Integer) As String
        Dim sSection As String
        Dim sKey As String

        sSection = strSection(nSection) & Format(nSectionIndex + 1, "00")

        sKey = strKey(nkey) & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function


End Class
