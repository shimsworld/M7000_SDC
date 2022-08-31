Imports System
Imports System.IO


Public Class frmBuilderSettings


    'Display는 TreeView control에....
    'Add View Setting Parameter
    'Caption 및 Enum 추가
    'CSeqBuilderSettingsINI 의 Enum 및 Caption 추가
    'SaveSeqBuilderSetting, LoadSeqBuilderSetting Update

#Region "Define"

    Dim m_sViewSettingCaptions()() As String



    Public Shared m_sViewSettingGroupCaptions() As String = New String() {"Recipe",
                                                                "Common Settings",
                                                                "IVL Settings",
                                                                "Lifetime Settings",
                                                                "Lifetime + IVL Settings",
                                                                "Temperature Settings",
                                                                "ViewingAngel Settings",
                                                                          "Aging Settings"}

    Shared m_sViewSettingRcpItemCaptions() As String = New String() {"Common Recipe",
                                                                  "IVL Sweep Recipe",
                                                                  "Lifetime Recipe",
                                                                  "Lifetime + IVL Recipe",
                                                                  "Temperature Recipe",
                                                                  "GrayScale Sweep Recipe",
                                                                  "Image Sweep Recipe",
                                                                  "RGBW Aging Recipe",
                                                                  "Pattern Recipe",
                                                                  "Viewing Angle",
                                                                     "Aging Recipe"}

    Shared m_sViewSettingCommonRcpItemCaptions() As String = New String() {"Sequence Title",
                                                                        "Sample Type",
                                                                        "Sample Color",
                                                                        "Sample Size",
                                                                        "Fill Factor",
                                                                        "Comment",
                                                                        "Default Temp",
                                                                        "ACF Mode",
                                                                        "Limit Settings",
                                                                        "Sequence End Settings"}


    Shared m_sViewSettingIVLRcpItemCaptions() As String = New String() {"IVL Sweep Detail Settings",
                                                                    "IVL Sweep Common Bias Mode",
                                                                    "IVL Sweep Common Measuremnet Mode",
                                                                    "IVL Sweep Common Sweep Type",
                                                                    "IVL Sweep Common Luminance Measure Level",
                                                                    "IVL Sweep Common Luminance Measure Limit",
                                                                    "IVL Sweep Common Current Measure Limit",
                                                                    "IVL Sweep Common Sweep Region Settings",
                                                                    "IVL Sweep Common Viewing Angle",
                                                                    "IVL Sweep Common Color List",
                                                                    "IVLRcpGrp_Common_LumiCorrection",
                                                                    "IVL Sweep K26xx Bias Mode",
                                                                    "IVL Sweep K26xx Wire Mode",
                                                                    "IVL Sweep K26xx Terminal Mode",
                                                                    "IVL Sweep K26xx Source Settings",
                                                                    "IVL Sweep K26xx Measure Settings"}

   

    Shared m_sViewSettingLifetimeRcpItemCaptions() As String = New String() {"Lifetime Common Operation Mode",
                                                                          "Lifetime Common Ref. Luminance Settings",
                                                                          "Lifetime Common End Action",
                                                                          "Lifetime Common Save Interval Settings",
                                                                          "Lifetime Common End Condition Settings",
                                                                          "Lifetime M6000 ChkEnable",
                                                                          "Lifetime M6000 Source Mode",
                                                                          "Lifetime M6000 SetRev",
                                                                          "Lifetime M6000 Bias",
                                                                          "Lifetime M6000 Amplitude",
                                                                          "Lifetime M6000 Frequency",
                                                                          "Lifetime M6000 Duty",
                                                                          "Lifetime M6000 Constant Brightness",
                                                                          "Lifetime M6000 BtnADD",
                                                                          "Lifetime McSG Signal Editor",
                                                                          "Lifetime McSG RGBW Rotation",
                                                                          "Lifetime McPG Init Code Editor",
                                                                          "Lifetime McPG Power Control",
                                                                          "Lifetime McPG Pattern Editor",
                                                                          "Lifetime Viewing Angle Settings"}

    Shared m_sViewSettingTemperatureItemCaptions() As String = New String() {"Temperature Rcp Target Temperature",
                                                                          "Temperature Rcp Stabilization Time"}


    Shared m_sViewSettingViewingAngleRcpItemCaptions() As String = New String() {"ViewingAngle Common Device Unit",
                                                                              "ViewingAngle Common BiasMode",
                                                                              "ViewingAngle Common Bias",
                                                                              "ViewingAngle Common Sweep Type",
                                                                              "ViewingAngel Common Sweep Region Settings",
                                                                              "ViewingAngle M6000_ChkEnabl",
                                                                              "ViewingAngle M6000 Source Mode",
                                                                              "ViewingAngle M6000 SetRev",
                                                                              "ViewingAngle M6000 Bias",
                                                                              "ViewingAngle M6000 Amplitude",
                                                                              "ViewingAngle M6000 Frequency",
                                                                              "ViewingAngle M6000 Duty",
                                                                              "ViewingAngle M6000 Constant Brightness",
                                                                              "ViewingAngle M6000 BtnADD",
                                                                              "ViewingAngle K26xx Bias Mode",
                                                                              "ViewingAngle K26xx Wire Mode",
                                                                              "ViewingAngle K26xx Terminal Mode",
                                                                              "ViewingAngle K26xx Source Settings",
                                                                              "ViewingAngle K26xx Measure Settings"}

    Shared m_sViewSettingLifetimeAndIVLItemCaptions() As String = New String() {""}
    Shared m_sViewSettingAgingItemCaptions() As String = New String() {""}

    'Dim m_sViewSettingItemCaptions() As String = New String() {"Common Recipe", "IVL Sweep Recipe", "Lifetime Recipe", "Temperature Recipe", _
    '   "Sequence Title", "Sample Type", "Sample Color", "Sample Size", "Fill Factor", "Comment", "Default Temp", "ACF Mode", "Limit Settings", "Sequence End Settings", _
    '   "IVL Sweep Detail Settings", "IVL Sweep Common Bias Mode", "IVL Sweep Common Measuremnet Mode", "IVL Sweep Common Sweep Type", "IVL Sweep Common Luminance Measure Level", "IVL Sweep Common Sweep Region Settings", _
    '   "IVL Sweep K26xx Bias Mode", "IVL Sweep K26xx Wire Mode", "IVL Sweep K26xx Terminal Mode", "IVL Sweep K26xx Source Settings", "IVL Sweep K26xx Measure Settings", _
    '   "Lifetime Common Operation Mode", "Lifetime Common Ref. Luminance Settings", "Lifetime Common End Action", "Lifetime Common Save Interval Settings", "Lifetime Common End Condition Settings",
    '   "Lifetime M6000 Source Mode", "Lifetime M6000 SetRev", "Lifetime M6000 Bias", "Lifetime M6000 Amplitude", "Lifetime M6000 Frequency", "Lifetime M6000 Duty", "Lifetime M6000 Constant Brightness", "Lifetime M6000 BtnADD",
    '   "Temperature Rcp Target Temperature", "Temperature Rcp Stabilization Time"}


    Public Enum eViewSettingGroup
        _Recipe
        _Common
        _IVL
        _Lifetime
        _LifetimeAndIVL
        _Temperature
        _ViewingAngle
        _Aging
    End Enum

    Public Enum eViewSettingRcpItems
        _Common
        _IVLSweep
        _Lifetime
        _LifetimeAndIVL
        _Temperature
        _GrayScaleSweep
        _ImageSweep
        _RGBWAging
        _Pattern
        _ViewingAngle
        _Aging
    End Enum

    Public Enum eViewSettingCommonRcpItems
        _CommonGrp_SequenceTitle
        _CommonGrp_SampleType
        _CommonGrp_SampleColor
        _CommonGrp_SampleSize
        _CommonGrp_FillFactor
        _CommonGrp_Comment
        _CommonGrp_DefaultTemp
        _CommonGrp_ACFMode
        _CommonGrp_LimitSetting
        _CommonGrp_SequenceEndSetting
    End Enum

    Public Enum eViewSettingIVLRcpItems
        _IVLRcpGrp_Common_DetailSettings
        _IVLRcpGrp_Common_BiasMode
        _IVLRcpGrp_Common_MeasurementMode
        _IVLRcpGrp_Common_SweepType
        _IVLRcpGrp_Common_LuminanceMeasureLevel
        _IVLRcpGrp_Common_LuminanceMeasureLimit
        _IVLRcpGrp_Common_CurrentMeasureLimit
        _IVLRcpGrp_Common_SweepRegionSettings
        _IVLRcpGrp_Common_ViewingAngle
        _IVLRcpGrp_Common_ColorList
        _IVLRcpGrp_Common_LumiCorrection
        _IVLRcpGrp_K26xx_BiasMode
        _IVLRcpGrp_K26xx_WireMode
        _IVLRcpGrp_K26xx_TermianlMode
        _IVLRcpGrp_K26xx_SourceSettings
        _IVLRcpGrp_K26xx_MeasureSettings
    End Enum

    Public Enum eViewSettingViewingAngleItems
        _ViewingAngleRcpGrp_Common_DeviceUnit
        _ViewingAngleRcpGrp_Common_BiasMode
        _ViewingAngleRcpGrp_Common_Bias
        _ViewingAngleRcpGrp_Common_SweepType
        _ViewingAngleRcpGrp_Common_SweepRegionSettings
        _ViewingAngleRcpGrp_M6000_ChkEnabl
        _ViewingAngleRcpGrp_M6000_SourceMode
        _ViewingAngleRcpGrp_M6000_SetRev
        _ViewingAngleRcpGrp_M6000_Bias
        _ViewingAngleRcpGrp_M6000_Amplitude
        _ViewingAngleRcpGrp_M6000_Frequency
        _ViewingAngleRcpGrp_M6000_Duty
        _ViewingAngleRcpGrp_M6000_ConstantBrightness
        _ViewingAngleRcpGrp_M6000_BtnADD
        _ViewingAngleRcpGrp_K26xx_BiasMode
        _ViewingAngleRcpGrp_K26xx_WireMode
        _ViewingAngleRcpGrp_K26xx_TermianlMode
        _ViewingAngleRcpGrp_K26xx_SourceSettings
        _ViewingAngleRcpGrp_K26xx_MeasureSettings
    End Enum

    Public Enum eViewSettingLifetimeRcpItems
        _LTRcpGrp_Common_OperationMode
        _LTRcpGrp_Common_RefLuminanceSettings
        _LTRcpGrp_Common_EndAction
        _LTRcpGrp_Common_SaveIntervalSettings
        _LTRcpGrp_Common_EndConditionSettings
        _LTRcpGrp_M6000_ChkEnable
        _LTRcpGrp_M6000_SourceMode
        _LTRcpGrp_M6000_SetRev
        _LTRcpGrp_M6000_Bias
        _LTRcpGrp_M6000_Amplitude
        _LTRcpGrp_M6000_Frequency
        _LTRcpGrp_M6000_Duty
        _LTRcpGrp_M6000_ConstantBrightness
        _LTRcpGrp_M6000_BtnADD
        _LTRcpGrp_McSG_SignalEditor
        _LTRcpGrp_McSG_RGBWRotation
        _LTRcpGrp_McPG_InitCodeEditor
        _LTRcpGrp_McPG_PowerControl
        _LTRcpGrp_McPG_PatternEditor
        _LTRcpGrp_ViewingAngleSettings
    End Enum

    Public Enum eViewSettingTempRcpItems
        _TempRcpGrp_Common_TargetTemperature
        _TempRcpGrp_Common_StabilizationTime
    End Enum


    Dim m_SeqBuilderSettings As sSeqBuilderSettings

    Public Structure sSeqBuilderSettings
        Dim bViewSettings()() As Boolean   '2차항 : eViewSettingGroup 항목으로 인덱스 매칭 , 1차항 : 각 Group or Recipe의 Item
        Dim settings_UsedSequenceEndParam() As ucTestEndParam.eTestEndParam
        Dim settings_UsedRcpEndParam() As ucTestEndParam.eTestEndParam
        Dim settings_UsedIVLSweepMeasParam() As ucTestEndParam.eTestEndParam
        Dim settings_UsedAgingEndParam() As ucTestEndParam.eTestEndParam

        Dim sDefaultValues As Double

        Dim dMeasureIntervalMin As Double
        Dim dMeasureIntervalMax As Double
        Dim dMeasureAngleMin As Double
        Dim dMeasureAngleMax As Double
        Dim sLimitSettings() As ucLimitSetting.sLimitSetting
        Dim sTestEndParam() As ucTestEndParam.sTestEndParam
        Dim dDefaultTemp As Double
        Dim dWidth As Double
        Dim dHight As Double
        Dim dFillFactor As Double
        Dim UISettings As sUISettings
    End Structure


    Public Structure sUISettings
        Dim nSeqList_SplitterDistance As Integer
        Dim nSeqEdit_SplitterDistance As Integer
        Dim nSeqEditList_SplitterDistance As Integer
        Dim nRcp_LT_SplitterDistance As Integer
        Dim nRcp_IVL_SplitterDistance As Integer
        Dim nRcp_IVL_Common_SplitterDistance01 As Integer
        Dim nRcp_IVL_Common_SplitterDistance02 As Integer
        Dim nRcp_ViewingAngle_SplitterDistance As Integer
        Dim nRcp_LifetimeAndIVL_SplitterDistance As Integer
        Dim nRcp_LifetimeAndIVL_Common_SplitterDistance01 As Integer
        Dim nRcp_LifetimeAndIVL_Common_SplitterDistance02 As Integer
        Dim nRcp_Aging_SplitterDistance As Integer
        Dim nFrameSize_Height As Integer
        Dim nFrameSize_Width As Integer
    End Structure

#End Region


#Region "Creator, Disposer, Init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()

        treeView.Dock = DockStyle.Fill

        '변수 초기화
        ReDim m_SeqBuilderSettings.bViewSettings(m_sViewSettingGroupCaptions.Length - 1)
        ReDim m_SeqBuilderSettings.bViewSettings(eViewSettingGroup._Recipe)(m_sViewSettingRcpItemCaptions.Length - 1)
        ReDim m_SeqBuilderSettings.bViewSettings(eViewSettingGroup._Common)(m_sViewSettingCommonRcpItemCaptions.Length - 1)
        ReDim m_SeqBuilderSettings.bViewSettings(eViewSettingGroup._IVL)(m_sViewSettingIVLRcpItemCaptions.Length - 1)
        ReDim m_SeqBuilderSettings.bViewSettings(eViewSettingGroup._Lifetime)(m_sViewSettingLifetimeRcpItemCaptions.Length - 1)
        ReDim m_SeqBuilderSettings.bViewSettings(eViewSettingGroup._Temperature)(m_sViewSettingTemperatureItemCaptions.Length - 1)
        ReDim m_SeqBuilderSettings.bViewSettings(eViewSettingGroup._ViewingAngle)(m_sViewSettingViewingAngleRcpItemCaptions.Length - 1)
        ReDim m_SeqBuilderSettings.bViewSettings(eViewSettingGroup._LifetimeAndIVL)(m_sViewSettingLifetimeAndIVLItemCaptions.Length - 1)
        ReDim m_SeqBuilderSettings.bViewSettings(eViewSettingGroup._Aging)(m_sViewSettingAgingItemCaptions.Length - 1)

        ReDim m_sViewSettingCaptions(m_sViewSettingGroupCaptions.Length - 1)
        m_sViewSettingCaptions(eViewSettingGroup._Recipe) = m_sViewSettingRcpItemCaptions.Clone
        m_sViewSettingCaptions(eViewSettingGroup._Common) = m_sViewSettingCommonRcpItemCaptions.Clone
        m_sViewSettingCaptions(eViewSettingGroup._IVL) = m_sViewSettingIVLRcpItemCaptions.Clone
        m_sViewSettingCaptions(eViewSettingGroup._Lifetime) = m_sViewSettingLifetimeRcpItemCaptions.Clone
        m_sViewSettingCaptions(eViewSettingGroup._Temperature) = m_sViewSettingTemperatureItemCaptions.Clone
        m_sViewSettingCaptions(eViewSettingGroup._ViewingAngle) = m_sViewSettingViewingAngleRcpItemCaptions.Clone
        m_sViewSettingCaptions(eViewSettingGroup._LifetimeAndIVL) = m_sViewSettingLifetimeAndIVLItemCaptions.Clone
        m_sViewSettingCaptions(eViewSettingGroup._Aging) = m_sViewSettingAgingItemCaptions.Clone
        dispViewSettingInfos()

    End Sub


#End Region


    Private Sub frmBuilderSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If LoadSeqBuilderSetting(m_SeqBuilderSettings) = True Then
            SetValueToUI()
        End If
    End Sub

    Private Sub dispViewSettingInfos()

        treeView.BeginUpdate()
        treeView.CheckBoxes = True

        For grp As Integer = 0 To m_sViewSettingCaptions.Length - 1
            treeView.Nodes.Add(m_sViewSettingGroupCaptions(grp))
            For item As Integer = 0 To m_sViewSettingCaptions(grp).Length - 1
                treeView.Nodes(grp).Nodes.Add(m_sViewSettingCaptions(grp)(item))
            Next
        Next

        treeView.EndUpdate()

    End Sub


    Private Function GetValueFromUI() As Boolean
        With m_SeqBuilderSettings
            '  m_SeqBuilderSettings = g_SequenceBuilderOptions
            'View
            ReDim m_SeqBuilderSettings.bViewSettings(treeView.Nodes.Count - 1)
            For grp As Integer = 0 To treeView.Nodes.Count - 1
                ReDim m_SeqBuilderSettings.bViewSettings(grp)(treeView.Nodes(grp).Nodes.Count - 1)
                For item As Integer = 0 To treeView.Nodes(grp).Nodes.Count - 1
                    .bViewSettings(grp)(item) = treeView.Nodes(grp).Nodes(item).Checked
                Next
            Next

            'Settings
            .settings_UsedSequenceEndParam = ucDispDefSequenceEndParam.Settings
            .settings_UsedRcpEndParam = UcDispDefRcpEndParam.Settings
            .settings_UsedIVLSweepMeasParam = UcDispDefIVLMeasParam.Settings
            .settings_UsedAgingEndParam = UcDispDefAgingRcpEndParam.Settings
            .sTestEndParam = ucTestEndSettings.Settings.Clone
            .sLimitSettings = ucLimitSettings.Settings.Clone

            .dMeasureIntervalMin = ConvertToDouble(tbMeasureIntervalMin.Text)
            .dMeasureIntervalMax = ConvertToDouble(tbMeasureIntervalMax.Text)
            .dMeasureAngleMin = ConvertToDouble(tbMeasureAngleMin.Text)
            .dMeasureAngleMax = ConvertToDouble(tbMeasureAngleMax.Text)
            .dDefaultTemp = ConvertToDouble(tbDefaultTemperature.Text)
            .dWidth = ConvertToDouble(tbSizeWidth.Text)
            .dHight = ConvertToDouble(tbSizeHight.Text)
            .dFillFactor = ConvertToDouble(tbFillFactor.Text)
        End With

        Return True
    End Function

    Private Sub SetValueToUI()
        With m_SeqBuilderSettings
            'ReDim m_SeqBuilderSettings.bViewSettings(treeView.Nodes.Count - 1)
            'For grp As Integer = 0 To treeView.Nodes.Count - 1
            '    ReDim m_SeqBuilderSettings.bViewSettings(grp)(treeView.Nodes(grp).Nodes.Count - 1)
            '    For item As Integer = 0 To treeView.Nodes(grp).Nodes.Count - 1
            '        .bViewSettings(grp)(item) = treeView.Nodes(grp).Nodes(item).Checked
            '    Next
            'Next
            For grp As Integer = 0 To .bViewSettings.Length - 1
                For item As Integer = 0 To .bViewSettings(grp).Length - 1
                    treeView.Nodes(grp).Nodes(item).Checked = .bViewSettings(grp)(item)
                Next
            Next

            'Settings
            If .settings_UsedSequenceEndParam Is Nothing = False Then
                ucDispDefSequenceEndParam.Settings = .settings_UsedSequenceEndParam.Clone
            Else
                MsgBox("Sequence End Parameter is not set.")
            End If

            If .settings_UsedRcpEndParam Is Nothing = False Then
                UcDispDefRcpEndParam.Settings = .settings_UsedRcpEndParam.Clone
            Else
                MsgBox("Recipe End Parameter is not set.")
            End If

            If .settings_UsedIVLSweepMeasParam Is Nothing = False Then
                UcDispDefIVLMeasParam.Settings = .settings_UsedIVLSweepMeasParam.Clone
            Else
                MsgBox("IVL Sweep Meas. Parameter is not set.")
            End If

            If .settings_UsedAgingEndParam Is Nothing = False Then
                UcDispDefAgingRcpEndParam.Settings = .settings_UsedAgingEndParam.Clone
            Else
                MsgBox("Aging End Parameter is not set.")
            End If

            ucTestEndSettings.UsedParams = .settings_UsedSequenceEndParam

            If .sTestEndParam Is Nothing = False Then

                ucTestEndSettings.Settings = .sTestEndParam.Clone
            Else
                MsgBox("Default Test End Settings is not set.")
            End If

            If .sLimitSettings Is Nothing = False Then
                ucLimitSettings.Settings = .sLimitSettings
            Else
                MsgBox("Default Limit is not set.")
            End If

            tbMeasureIntervalMin.Text = .dMeasureIntervalMin
            tbMeasureIntervalMax.Text = .dMeasureIntervalMax
            tbMeasureAngleMin.Text = .dMeasureAngleMin
            tbMeasureAngleMax.Text = .dMeasureAngleMax
            tbDefaultTemperature.Text = .dDefaultTemp
            tbSizeWidth.Text = .dWidth
            tbSizeHight.Text = .dHight
            tbFillFactor.Text = .dFillFactor
        End With
    End Sub



    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        GetValueFromUI()
        If SaveSeqBuilderSetting(m_SeqBuilderSettings) = False Then
            MsgBox("Sequence Value is not save.")
        End If

        g_SequenceBuilderOptions = m_SeqBuilderSettings
    End Sub



#Region "Save/Load Option Function"

    Const sFileTitle As String = "Sequence Builder Settings"
    Const sVersion As String = "1.0.0"

    Public Shared Function SaveSeqBuilderSetting(ByVal settings As sSeqBuilderSettings) As Boolean

        If Directory.Exists(g_sPATH_SEQUENCE) = False Then
            Directory.CreateDirectory(g_sPATH_SEQUENCE)
        End If

        If File.Exists(g_sFilePath_SeqBuilderSettings) = True Then
            File.Delete(g_sFilePath_SeqBuilderSettings)
        End If


        Try

            Dim cSaver As New CSeqBuilderSettingsINI(g_sFilePath_SeqBuilderSettings)

            'Save File Infos
            cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._FileInfo, 0, CSeqBuilderSettingsINI.eKeyID._FileInfo_File_Title, sFileTitle)
            cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._FileInfo, 0, CSeqBuilderSettingsINI.eKeyID._FileInfo_FILE_VERSION, sVersion)

            With settings

                'View Settings(View Tab)
                'Recipe Item
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_Common, settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._Common).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_IVL, settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._IVLSweep).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_Lifetime, settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._Lifetime).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_Temp, settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._Temperature).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_GrayScaleSweep, settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._GrayScaleSweep).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_ImageSweep, settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._ImageSweep).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_RGBWAging, settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._RGBWAging).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_Pattern, settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._Pattern).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_ViewingAngle, settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._ViewingAngle).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_LifetimeAndIVL, settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._LifetimeAndIVL).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_Aging, settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._Aging).ToString)

                'Common recipe Item
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_SequenceTitle, settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_SequenceTitle).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_SequenceEndSetting, settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_SequenceEndSetting).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_SampleType, settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_SampleType).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_SampleSize, settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_SampleSize).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_SampleColor, settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_SampleColor).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_LimitSetting, settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_LimitSetting).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_FillFactor, settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_FillFactor).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_DefaultTemp, settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_DefaultTemp).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_Comment, settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_Comment).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_ACFMode, settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_ACFMode).ToString)

                'IVL Sweep Recipe Item
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_DetailSettings, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_DetailSettings).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_BiasMode, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_BiasMode).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_LuminanceMeasureLevel, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_LuminanceMeasureLevel).ToString)

                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_LuminanceMeasureLimit, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_LuminanceMeasureLimit).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_CurrentMeasureLimit, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_CurrentMeasureLimit).ToString)

                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_MeasuremnetMode, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_MeasurementMode).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_SweepRegionSettings, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_SweepRegionSettings).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_SweepType, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_SweepType).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_ViewingAngle, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_ViewingAngle).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_ColorList, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_ColorList).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_LumiCorrection, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_LumiCorrection).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_K26xx_BiasMode, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_K26xx_BiasMode).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_K26xx_MeasureSettings, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_K26xx_MeasureSettings).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_K26xx_SourceSettings, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_K26xx_SourceSettings).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_K26xx_TermianlMode, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_K26xx_TermianlMode).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_K26xx_WireMode, settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_K26xx_WireMode).ToString)

                'Lifetime Recipe item
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_Common_EndAction, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_Common_EndAction).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_Common_EndConditionSettings, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_Common_EndConditionSettings).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_Common_OperationMode, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_Common_OperationMode).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_Common_RefLuminanceSettings, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_Common_RefLuminanceSettings).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_Common_SaveIntervalSettings, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_Common_SaveIntervalSettings).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_ChkEnable, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_ChkEnable).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_Amplitude, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Amplitude).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_Bias, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Bias).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_ConstantBrightness, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_ConstantBrightness).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_Duty, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Duty).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_Frequency, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Frequency).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_SetRev, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_SetRev).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_SourceMode, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_SourceMode).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_BtnADD, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_BtnADD).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_McSG_SignalEditor, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_McSG_SignalEditor).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_McSG_RGBWRotation, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_McSG_RGBWRotation).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_McPG_InitCodeEditor, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_McPG_InitCodeEditor).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_McPG_PowerControl, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_McPG_PowerControl).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_McPG_PatternEditor, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_McPG_PatternEditor).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_ViewingAngleSettings, settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_ViewingAngleSettings).ToString)


                'Temperature Recipe Item
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_TempRcpGrp_Common_StabilizationTime, settings.bViewSettings(eViewSettingGroup._Temperature)(eViewSettingTempRcpItems._TempRcpGrp_Common_StabilizationTime).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_TempRcpGrp_Common_TargetTemperature, settings.bViewSettings(eViewSettingGroup._Temperature)(eViewSettingTempRcpItems._TempRcpGrp_Common_TargetTemperature).ToString)

                'Viewing Angle Sweep Recipe Item
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_Common_DeviceUnit, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_DeviceUnit).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_Common_BiasMode, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_BiasMode).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_Common_Bias, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_Bias).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_Common_SweepType, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_SweepType).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_Common_SweepRegionSettings, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_SweepRegionSettings).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_ChkEnable, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_ChkEnabl).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_SourceMode, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_SourceMode).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_SetRev, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_SetRev).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_Bias, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_Bias).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_Amplitude, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_Amplitude).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_Frequency, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_Frequency).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_Duty, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_Duty).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_ConstantBrightness, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_ConstantBrightness).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_BtnADD, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_BtnADD).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_K26xx_BiasMode, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_K26xx_BiasMode).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_K26xx_WireMode, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_K26xx_WireMode).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_K26xx_TermianlMode, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_K26xx_TermianlMode).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_K26xx_SourceSettings, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_K26xx_SourceSettings).ToString)
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_K26xx_MeasureSettings, settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_K26xx_MeasureSettings).ToString)

                'Settings
                '1. Sequence End Param Settings
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 0, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Count, CStr(settings.settings_UsedSequenceEndParam.Length))
                For i As Integer = 0 To settings.settings_UsedSequenceEndParam.Length - 1
                    cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 0, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Item, i, settings.settings_UsedSequenceEndParam(i).ToString)
                Next

                '2. Recipe End Param Settings
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 1, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Count, CStr(settings.settings_UsedRcpEndParam.Length))
                For i As Integer = 0 To settings.settings_UsedRcpEndParam.Length - 1
                    cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 1, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Item, i, settings.settings_UsedRcpEndParam(i).ToString)
                Next

                '3. IVL Sweep Meas. Param Settings
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 2, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Count, CStr(settings.settings_UsedIVLSweepMeasParam.Length))
                For i As Integer = 0 To settings.settings_UsedIVLSweepMeasParam.Length - 1
                    cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 2, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Item, i, settings.settings_UsedIVLSweepMeasParam(i).ToString)
                Next

                '4. Aging Recipe End Param Settings
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 3, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Count, CStr(settings.settings_UsedAgingEndParam.Length))
                For i As Integer = 0 To settings.settings_UsedIVLSweepMeasParam.Length - 1
                    cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 3, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Item, i, settings.settings_UsedAgingEndParam(i).ToString)
                Next


                '1. Limit Param Param Settings
                If .sLimitSettings Is Nothing = True Then 'Limit Param
                    cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_Limit_Counter, CStr(0))
                Else
                    cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_Limit_Counter, CStr(.sLimitSettings.Length))
                    For n As Integer = 0 To .sLimitSettings.Length - 1
                        cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_Limit_TypeOfParam, n, .sLimitSettings(n).eTypeOfValue.ToString)
                        cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_Limit_MaxValue, n, CStr(.sLimitSettings(n).LimitValue.dMax))
                        cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_Limit_MinValue, n, CStr(.sLimitSettings(n).LimitValue.dMin))
                    Next
                End If

                '2. Test End Param Settings
                If .sTestEndParam Is Nothing = True Then 'TestEnd Param
                    cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_EndCondition_Counter, CStr(0))
                Else
                    cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_EndCondition_Counter, CStr(.sTestEndParam.Length))
                    For n As Integer = 0 To .sTestEndParam.Length - 1
                        cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_EndCondition_TypeOfParam, n, .sTestEndParam(n).nTypeOfParam.ToString)
                        cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._defValue_EndCondition_Value, n, CStr(.sTestEndParam(n).dValue))
                    Next
                End If

                '3. Define Settings
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_MeasureInterval_MaxValue, CStr(.dMeasureIntervalMax))
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_MeasureInterval_MinValue, CStr(.dMeasureIntervalMin))
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_Temperature, CStr(.dDefaultTemp))

                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_MeasureAngle_MaxValue, CStr(.dMeasureAngleMax))
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_MeasureAngle_MinValue, CStr(.dMeasureAngleMin))

                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_SampleSize_Width, CStr(.dWidth))
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_SampleSize_Hight, CStr(.dHight))
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_FillFactor, CStr(.dFillFactor))

                '4. UI Settings
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_SequenceList_SplitterDistance, CStr(.UISettings.nSeqList_SplitterDistance))
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_SequenceEdit_SplitterDistance, CStr(.UISettings.nSeqEdit_SplitterDistance))
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_SequenceEditList_splitterDistance, CStr(.UISettings.nSeqEditList_SplitterDistance))
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_LT_SplitterDistance, CStr(.UISettings.nRcp_LT_SplitterDistance))
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_IVL_SplitterDistance, 0, CStr(.UISettings.nRcp_IVL_SplitterDistance))
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_IVL_SplitterDistance, 1, CStr(.UISettings.nRcp_IVL_Common_SplitterDistance01)) 'nRcp_IVL_Common_SplitterDistance
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_IVL_SplitterDistance, 2, CStr(.UISettings.nRcp_IVL_Common_SplitterDistance02)) 'nRcp_IVL_Common_SplitterDistance
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_ViewingAngle_splitterDistance, CStr(.UISettings.nRcp_ViewingAngle_SplitterDistance))
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_FrameSize_Height, CStr(.UISettings.nFrameSize_Height))
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_FrameSize_Width, CStr(.UISettings.nFrameSize_Width))

                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_LifetimeAndIVL_SplitterDistance, 0, CStr(.UISettings.nRcp_LifetimeAndIVL_SplitterDistance))
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_LifetimeAndIVL_SplitterDistance, 1, CStr(.UISettings.nRcp_LifetimeAndIVL_Common_SplitterDistance01)) 'nRcp_IVL_Common_SplitterDistance
                cSaver.SaveIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_LifetimeAndIVL_SplitterDistance, 2, CStr(.UISettings.nRcp_LifetimeAndIVL_Common_SplitterDistance02)) 'nRcp_IVL_Common_SplitterDistance

            End With
        Catch ex As Exception

            Return False
        End Try

        Return True
    End Function

    Public Shared Function LoadSeqBuilderSetting(ByRef settings As sSeqBuilderSettings) As Boolean

        Dim nCnt As Integer
        Dim sTemp As String

        ReDim settings.bViewSettings(m_sViewSettingGroupCaptions.Length - 1)
        ReDim settings.bViewSettings(eViewSettingGroup._Recipe)(m_sViewSettingRcpItemCaptions.Length - 1)
        ReDim settings.bViewSettings(eViewSettingGroup._Common)(m_sViewSettingCommonRcpItemCaptions.Length - 1)
        ReDim settings.bViewSettings(eViewSettingGroup._IVL)(m_sViewSettingIVLRcpItemCaptions.Length - 1)
        ReDim settings.bViewSettings(eViewSettingGroup._Lifetime)(m_sViewSettingLifetimeRcpItemCaptions.Length - 1)
        ReDim settings.bViewSettings(eViewSettingGroup._Temperature)(m_sViewSettingTemperatureItemCaptions.Length - 1)
        ReDim settings.bViewSettings(eViewSettingGroup._ViewingAngle)(m_sViewSettingViewingAngleRcpItemCaptions.Length - 1)
        ReDim settings.bViewSettings(eViewSettingGroup._LifetimeAndIVL)(m_sViewSettingLifetimeAndIVLItemCaptions.Length - 1)
        ReDim settings.bViewSettings(eViewSettingGroup._Aging)(m_sViewSettingAgingItemCaptions.Length - 1)

        If File.Exists(g_sFilePath_SeqBuilderSettings) = False Then
            Return False
        End If

        Dim optionLoader As New CSeqBuilderSettingsINI(g_sFilePath_SeqBuilderSettings)

        'Load File Infos
        Try


            sTemp = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._FileInfo, 0, CSeqBuilderSettingsINI.eKeyID._FileInfo_File_Title)
            If sTemp <> sFileTitle Then Return False
            sTemp = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._FileInfo, 0, CSeqBuilderSettingsINI.eKeyID._FileInfo_FILE_VERSION)
            If sTemp <> sVersion Then Return False

            With settings

                'View Settings(View Tab)
                'Recipe Item
                settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._Common) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_Common)
                settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._IVLSweep) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_IVL)
                settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._Lifetime) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_Lifetime)
                settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._Temperature) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_Temp)

                settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._GrayScaleSweep) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_GrayScaleSweep)
                settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._ImageSweep) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_ImageSweep)
                settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._RGBWAging) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_RGBWAging)
                settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._Pattern) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_Pattern)
                settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._ViewingAngle) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_ViewingAngle)

                Try
                    settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._LifetimeAndIVL) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_LifetimeAndIVL)
                Catch ex As Exception
                    settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._LifetimeAndIVL) = True
                End Try

                Try
                    settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._Aging) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_RecipeGrp_Aging)
                Catch ex As Exception
                    settings.bViewSettings(eViewSettingGroup._Recipe)(eViewSettingRcpItems._Aging) = True
                End Try

                'Common recipe Item
                settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_SequenceTitle) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_SequenceTitle)
                settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_SequenceEndSetting) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_SequenceEndSetting)
                settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_SampleType) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_SampleType)
                settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_SampleSize) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_SampleSize)
                settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_SampleColor) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_SampleColor)
                settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_LimitSetting) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_LimitSetting)
                settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_FillFactor) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_FillFactor)
                settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_DefaultTemp) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_DefaultTemp)
                settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_Comment) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_Comment)
                settings.bViewSettings(eViewSettingGroup._Common)(eViewSettingCommonRcpItems._CommonGrp_ACFMode) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_CommonGrp_ACFMode)

                'IVL Sweep Recipe Item
                settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_DetailSettings) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_DetailSettings)
                settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_BiasMode) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_BiasMode)
                settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_LuminanceMeasureLevel) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_LuminanceMeasureLevel)
                settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_MeasurementMode) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_MeasuremnetMode)
                settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_SweepRegionSettings) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_SweepRegionSettings)
                settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_SweepType) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_SweepType)
                settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_ViewingAngle) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_ViewingAngle)

                Try
                    settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_LuminanceMeasureLimit) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_LuminanceMeasureLimit)
                    settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_CurrentMeasureLimit) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_CurrentMeasureLimit)
                Catch ex As Exception
                    settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_LuminanceMeasureLimit) = False
                    settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_CurrentMeasureLimit) = False
                End Try
            

                Try
                    settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_ColorList) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_ColorList)
                Catch ex As Exception
                    settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_ColorList) = False
                End Try

                Try
                    settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_LumiCorrection) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_Common_LumiCorrection)
                Catch ex As Exception
                    settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_Common_LumiCorrection) = False
                End Try


                settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_K26xx_BiasMode) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_K26xx_BiasMode)
                settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_K26xx_MeasureSettings) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_K26xx_MeasureSettings)
                settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_K26xx_SourceSettings) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_K26xx_SourceSettings)
                settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_K26xx_TermianlMode) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_K26xx_TermianlMode)
                settings.bViewSettings(eViewSettingGroup._IVL)(eViewSettingIVLRcpItems._IVLRcpGrp_K26xx_WireMode) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_IVLRcpGrp_K26xx_WireMode)

                'Lifetime Recipe item
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_Common_EndAction) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_Common_EndAction)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_Common_EndConditionSettings) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_Common_EndConditionSettings)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_Common_OperationMode) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_Common_OperationMode)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_Common_RefLuminanceSettings) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_Common_RefLuminanceSettings)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_Common_SaveIntervalSettings) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_Common_SaveIntervalSettings)
                Try
                    settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_ChkEnable) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_ChkEnable)
                Catch ex As Exception
                    settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_ChkEnable) = False
                End Try
                '  settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_ChkEnable) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_ChkEnable)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Amplitude) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_Amplitude)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Bias) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_Bias)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_ConstantBrightness) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_ConstantBrightness)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Duty) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_Duty)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Frequency) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_Frequency)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_SetRev) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_SetRev)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_SourceMode) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_SourceMode)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_BtnADD) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_M6000_BtnADD)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_McSG_SignalEditor) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_McSG_SignalEditor)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_McSG_RGBWRotation) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_McSG_RGBWRotation)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_McPG_InitCodeEditor) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_McPG_InitCodeEditor)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_McPG_PowerControl) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_McPG_PowerControl)
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_McPG_PatternEditor) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_McPG_PatternEditor)
                ' Try
                settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_ViewingAngleSettings) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_LTRcpGrp_ViewingAngleSettings)
                'Catch ex As Exception
                '    settings.bViewSettings(eViewSettingGroup._Lifetime)(eViewSettingLifetimeRcpItems._LTRcpGrp_ViewingAngleSettings) = False
                'End Try


                'Temperature Recipe Item
                settings.bViewSettings(eViewSettingGroup._Temperature)(eViewSettingTempRcpItems._TempRcpGrp_Common_StabilizationTime) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_TempRcpGrp_Common_StabilizationTime)
                settings.bViewSettings(eViewSettingGroup._Temperature)(eViewSettingTempRcpItems._TempRcpGrp_Common_TargetTemperature) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_TempRcpGrp_Common_TargetTemperature)


                'Viewing Angle Sweep Recipe Item
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_DeviceUnit) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_Common_DeviceUnit)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_BiasMode) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_Common_BiasMode)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_Bias) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_Common_Bias)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_SweepType) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_Common_SweepType)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_SweepRegionSettings) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_Common_SweepRegionSettings)
                Try
                    settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_ChkEnabl) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_ChkEnable)
                Catch ex As Exception
                    settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_ChkEnabl) = False
                End Try
                '    settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_ChkEnabl) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_ChkEnable)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_SourceMode) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_SourceMode)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_SetRev) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_SetRev)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_Bias) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_Bias)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_Amplitude) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_Amplitude)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_Frequency) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_Frequency)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_Duty) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_Duty)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_ConstantBrightness) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_ConstantBrightness)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_BtnADD) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_M6000_BtnADD)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_K26xx_BiasMode) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_K26xx_BiasMode)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_K26xx_WireMode) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_K26xx_WireMode)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_K26xx_TermianlMode) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_K26xx_TermianlMode)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_K26xx_SourceSettings) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_K26xx_SourceSettings)
                settings.bViewSettings(eViewSettingGroup._ViewingAngle)(eViewSettingViewingAngleItems._ViewingAngleRcpGrp_K26xx_MeasureSettings) = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._View, 0, CSeqBuilderSettingsINI.eKeyID._View_ViewingAngleRcpGrp_K26xx_MeasureSettings)


                'Settings
                '1. Sequence End Param Settings
                sTemp = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 0, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Count)
                If sTemp = "" Then
                    settings.settings_UsedSequenceEndParam = Nothing
                Else
                    ReDim .settings_UsedSequenceEndParam(CInt(sTemp) - 1)
                    For i As Integer = 0 To .settings_UsedSequenceEndParam.Length - 1
                        .settings_UsedSequenceEndParam(i) = ucTestEndParam.ConvertEnumEndParamStringToInt(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 0, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Item, i))
                    Next
                End If

                '2. Recipe End Param Settings
                sTemp = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 1, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Count)
                If sTemp = "" Then
                    settings.settings_UsedRcpEndParam = Nothing
                Else
                    ReDim .settings_UsedRcpEndParam(CInt(sTemp) - 1)
                    For i As Integer = 0 To .settings_UsedRcpEndParam.Length - 1
                        .settings_UsedRcpEndParam(i) = ucTestEndParam.ConvertEnumEndParamStringToInt(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 1, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Item, i))
                    Next
                End If

                '3. IVL Sweep Meas. Param Settings
                sTemp = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 2, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Count)
                If sTemp = "" Then
                    settings.settings_UsedIVLSweepMeasParam = Nothing
                Else
                    ReDim .settings_UsedIVLSweepMeasParam(CInt(sTemp) - 1)
                    For i As Integer = 0 To .settings_UsedIVLSweepMeasParam.Length - 1
                        .settings_UsedIVLSweepMeasParam(i) = ucTestEndParam.ConvertEnumEndParamStringToInt(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 2, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Item, i))
                    Next
                End If

                '4. Aging Recipe End Param Settings
                sTemp = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 3, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Count)
                If sTemp = "" Then
                    settings.settings_UsedAgingEndParam = Nothing
                Else
                    ReDim .settings_UsedAgingEndParam(CInt(sTemp) - 1)
                    For i As Integer = 0 To .settings_UsedAgingEndParam.Length - 1
                        .settings_UsedAgingEndParam(i) = ucTestEndParam.ConvertEnumEndParamStringToInt(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._Settings, 3, CSeqBuilderSettingsINI.eKeyID._Settings_TestEndParam_Item, i))
                    Next
                End If
                '1. Limit Param Settings
                Try
                    nCnt = CInt(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_Limit_Counter))
                Catch ex As Exception
                    nCnt = 0
                End Try

                If nCnt > 0 Then
                    Dim sLimits(nCnt - 1) As ucLimitSetting.sLimitSetting
                    For n As Integer = 0 To nCnt - 1
                        sTemp = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_Limit_TypeOfParam, n)
                        Select Case sTemp
                            Case ucLimitSetting.eLimitValueType.eVoltage.ToString
                                sLimits(n).eTypeOfValue = ucLimitSetting.eLimitValueType.eVoltage
                            Case ucLimitSetting.eLimitValueType.eCurrent.ToString
                                sLimits(n).eTypeOfValue = ucLimitSetting.eLimitValueType.eCurrent
                        End Select
                        sLimits(n).LimitValue.dMax = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_Limit_MaxValue, n)
                        sLimits(n).LimitValue.dMin = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_Limit_MinValue, n)
                    Next
                    .sLimitSettings = sLimits.Clone
                Else
                    .sLimitSettings = Nothing
                End If


                '2. Test End Param Settings
                Try
                    nCnt = CInt(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_EndCondition_Counter))
                Catch ex As Exception
                    nCnt = 0
                End Try

                If nCnt > 0 Then
                    Dim sEndCondition(nCnt - 1) As ucTestEndParam.sTestEndParam
                    For n As Integer = 0 To nCnt - 1
                        sEndCondition(n).nTypeOfParam = ucTestEndParam.ConvertEnumEndParamStringToInt(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_EndCondition_TypeOfParam, n))
                        sEndCondition(n).dValue = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._defValue_EndCondition_Value, n)
                    Next
                    .sTestEndParam = sEndCondition.Clone
                Else
                    .sTestEndParam = Nothing
                End If
                'Select Case sTemp
                '    Case ucTestEndParam.eTestEndParam.eTime.ToString
                '        sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eTime
                '    Case ucTestEndParam.eTestEndParam.eLoopCount.ToString
                '        sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eLoopCount

                '    Case ucTestEndParam.eTestEndParam.eVolt.ToString
                '        sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eVolt
                '    Case ucTestEndParam.eTestEndParam.eCurr.ToString
                '        sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eCurr
                '    Case ucTestEndParam.eTestEndParam.ePDCurr.ToString
                '        sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.ePDCurr
                '    Case ucTestEndParam.eTestEndParam.eLumi.ToString
                '        sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eLumi
                '    Case ucTestEndParam.eTestEndParam.eHightVolt.ToString
                '        sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eHightVolt
                '    Case ucTestEndParam.eTestEndParam.eHighCurrent.ToString
                '        sEndCondition(n).nTypeOfParam = ucTestEndParam.eTestEndParam.eHighCurrent
                'End Select




                Try
                    .dMeasureIntervalMax = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_MeasureInterval_MaxValue)
                    .dMeasureIntervalMin = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_MeasureInterval_MinValue)
                    .dMeasureAngleMax = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_MeasureAngle_MaxValue)
                    .dMeasureAngleMin = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_MeasureAngle_MinValue)

                    .dDefaultTemp = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_Temperature)

                    .dWidth = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_SampleSize_Width)
                    .dHight = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_SampleSize_Hight)
                    .dFillFactor = optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._DefValue, 0, CSeqBuilderSettingsINI.eKeyID._DefValue_FillFactor)

                Catch ex As Exception
                    .dMeasureIntervalMax = 1000000
                    .dMeasureIntervalMin = 0.001
                    .dMeasureAngleMax = 60
                    .dMeasureAngleMin = 0
                    .dDefaultTemp = 25
                    .dWidth = 2
                    .dHight = 2
                    .dFillFactor = 100
                End Try

                '4. UI Settings
                .UISettings.nSeqList_SplitterDistance = ConvertToInteger(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_SequenceList_SplitterDistance))
                .UISettings.nSeqEdit_SplitterDistance = ConvertToInteger(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_SequenceEdit_SplitterDistance))

                .UISettings.nSeqEditList_SplitterDistance = ConvertToInteger(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_SequenceEditList_splitterDistance))
                .UISettings.nRcp_LT_SplitterDistance = ConvertToInteger(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_LT_SplitterDistance))
                .UISettings.nRcp_IVL_SplitterDistance = ConvertToInteger(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_IVL_SplitterDistance, 0))
                .UISettings.nRcp_IVL_Common_SplitterDistance01 = ConvertToInteger(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_IVL_SplitterDistance, 1)) 'nRcp_IVL_Common_SplitterDistance
                .UISettings.nRcp_IVL_Common_SplitterDistance02 = ConvertToInteger(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_IVL_SplitterDistance, 2)) 'nRcp_IVL_Common_SplitterDistance

                .UISettings.nRcp_LifetimeAndIVL_SplitterDistance = ConvertToInteger(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_LifetimeAndIVL_SplitterDistance, 0))
                .UISettings.nRcp_LifetimeAndIVL_Common_SplitterDistance01 = ConvertToInteger(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_LifetimeAndIVL_SplitterDistance, 1)) 'nRcp_IVL_Common_SplitterDistance
                .UISettings.nRcp_LifetimeAndIVL_Common_SplitterDistance02 = ConvertToInteger(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_LifetimeAndIVL_SplitterDistance, 2)) 'nRcp_IVL_Common_SplitterDistance

                .UISettings.nRcp_ViewingAngle_SplitterDistance = ConvertToInteger(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_Rcp_ViewingAngle_splitterDistance))

                .UISettings.nFrameSize_Height = ConvertToInteger(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_FrameSize_Height))
                .UISettings.nFrameSize_Width = ConvertToInteger(optionLoader.LoadIniValue(CSeqBuilderSettingsINI.eSecID._UI_Settings, 0, CSeqBuilderSettingsINI.eKeyID._UISettings_FrameSize_Width))
                'If .UISettings.nFrameSize_Height < 500 Then .UISettings.nFrameSize_Height = 500
                'If .UISettings.nFrameSize_Width < 700 Then .UISettings.nFrameSize_Width = 700

            End With

        Catch ex As Exception
            '   MsgBox("File Load Error")
            Return False
        End Try

        Return True

    End Function

    Public Shared Function ConvertToDouble(ByVal strValue As String) As Double
        Try
            Return CDbl(strValue)
        Catch ex As Exception
            MsgBox("The input value is not a number.")
            Return 0
        End Try
    End Function


    Public Shared Function ConvertToInteger(ByVal strValue As String) As Integer
        Try
            Return CInt(strValue)
        Catch ex As Exception
            MsgBox("The input value is not a number.")
            Return 0
        End Try
    End Function

#End Region



End Class