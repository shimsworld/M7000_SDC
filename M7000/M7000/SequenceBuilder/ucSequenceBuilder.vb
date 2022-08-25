Imports System
Imports System.IO
Imports CSMULib

Public Class ucSequenceBuilder

#Region "Enums"

    Public Shared sCaptions_RecipeModes() As String = New String() {"Cell_IVL",
                                                                    "Cell_Lifetime",
                                                                    "Panel_IVL",
                                                                    "Panel_Lifetime",
                                                                    "Moduel_IVL",
                                                                    "Module_Lifetime",
                                                                    "Module_ImageSweep",
                                                                    "Module_GrayScaleSweep",
                                                                    "Change Temperature",
                                                                    "Image Sticking",
                                                                    "Viewing Angle",
                                                                    "Cell_LifetimeAndIVL",
                                                                   "Cell_Aging"}

    Public Enum eRcpMode
        eNothing
        eCell_IVL
        eCell_Lifetime
        ePanel_IVL
        ePanel_Lifetime
        eModuel_IVL
        eModule_Lifetime
        eModule_ImageSweep
        eModule_GrayScaleSweep
        eChangeTemperature
        eModule_ImageSticking
        eViewingAngle
        eCell_LifetimeAndIVL
        eCell_Aging
    End Enum

#End Region


#Region "Structures"


    Public Structure sRecipeInfo
        Dim recipeIndex As Integer   'Recipe 상에서 나의 index
        Dim recipeIndex_LifeTime As Integer  'Recipe 중에서 Lifetime만 누적 하였을 경우 index
        Dim recipeIndex_ChangeTemp As Integer 'Recipe 중에서 ChangeTemp 만 누적 하였을 경우 index   ' Lifetime의 경우 cell, moduel, panel 구분이 필요할 경우 추가 필요
        Dim recipeIndex_ImageSweep As Integer   'Recipe 중에서 Image Sweep 만 누적 하였을 경우 index 
        Dim recipeIndex_GrayScaleSweep As Integer 'Recipe 중에서 Gray Scale Sweep 만 누적 하였을 경우 index
        Dim recipeIndex_IVL As Integer
        Dim recipeIndex_PatternMeasure As Integer
        Dim recipeIndex_RGBWRotation As Integer
        Dim recipeIndex_ViewingAngle As Integer
        Dim recipeIndex_LifetimeAndIVL As Integer
        Dim recipeindex_Aging As Integer
        '추가가 많을 경우 배열로 선언하고, eRcpMode Index로 동기화 하여 값을 읽어오고 쓸수 있도록 변경하자.
        Dim nMode As eRcpMode      'eRcpMode에 해당하는 각각의 정보를 담을 수 있는 구조체 정의 필요, sLifetimeInfos와 같이
        Dim sChangeTemp As sRcpChangeTemp
        Dim sLifetimeInfo As sRcpLifetime
        Dim sIVLSweepInfo As sRcpIVLSweep
        Dim sImageSweepInfo As sRcpImageSweep
        Dim sGrayScaleSweepInfo As sRcpGrayScaleSweep
        Dim sPatternMeasure As sRcpPatternMeasure
        Dim sViewingAngleInfo As sRcpViewingAngleSweep
    End Structure

    Public Structure sRcpIVLSweep
        Dim nMyMode As eRcpMode
        Dim sCommon As ucDispRcpIVLSweep.sIVLSweepCommonInfos
        Dim sKeithleyInfos As ucKeithleySMUSettings.sKeithley
        Dim sRGBSignalInfos As ucPanelRGB.sRGBSignal  'M6000 활용
        Dim sSignalGeneratorInfos As ucDispSignalGenerator.sSGDatas
    End Structure

    Public Structure sRcpViewingAngleSweep
        Dim nMyMode As eRcpMode
        Dim sKeithleyInfos As ucKeithleySMUSettings.sKeithley
        Dim sCommon As ucDispRcpViewingAngle.sViewingAngleSweepCommonInfos
        Dim sCellInfos() As ucDispCellLifetime.sSourceSetting
    End Structure

    Public Structure sRcpLifetime   'Lifetime항목만 취합(Common, Panel, Module, Cell, Aging)
        Dim nMyMode As eRcpMode
        Dim sCommon As ucDispRcpLifetime.sLifetimeCommonInfos
        Dim sCellInfos() As ucDispCellLifetime.sSourceSetting     'Cell 용 Source meter(m600) 제어 구조체
        Dim sPanelInfos As ucDispSignalGenerator.sSGDatas    'Panel 용 Source Meter(Signal Generator) 제어 구조체
        Dim sModuleInfos As frmPatternGeneratorSetting.sPGInfos  'Module 용 Device(PG, PG Power, 모듈 구동기) 제어 구조체
        Dim sRGBWRotationInfos As CSeqRoutineSG.sRGBRotationInfos
        Dim sViewingAngleInfos As ucDispRcpViewingAngle.sViewingAngleSweepCommonInfos
    End Structure

    'Public Structure sRcpRGBWAging
    '    Dim sPanelInfos As ucDispSignalGenerator.sSGDatas    'Panel 용 Source Meter(Signal Generator) 제어 구조체
    'End Structure

    'Public Structure sPanelDevice
    '    Dim sKeithleyAndM6000 As ucKeithley.sKeithley
    '    Dim sSignalGenerator As ucDispSignalGenerator.sSGDatas
    'End Structure
    
    Public Structure sRcpCommon   'Sequence 공통 항목
        Dim saveInfo As CMcFile.sFILENAME
        Dim saveOptions As sSaveOptions
        Dim sSequenceEnd() As ucTestEndParam.sTestEndParam
        Dim dDefaultTemp As Double
        Dim nACFMode As frmOptionWindow.eACFMode
        Dim sLimits() As ucLimitSetting.sLimitSetting
    End Structure

    Public Structure sRcpImageSweep
        Dim ImageSweepInfo As ucDispRcpImageSweep.sMoudleImageSweepInfos
        Dim sModuleInfos As frmPatternGeneratorSetting.sPGInfos
        '  Dim sMeasPoints As ucDispPointSetting.sMeasurePointInfos
    End Structure

    Public Structure sRcpImageSticking
        Dim nMyMode As eRcpMode
        Dim sCommon As ucDispRcpLifetime.sLifetimeCommonInfos
        Dim sModuleInfos As frmPatternGeneratorSetting.sPGInfos
    End Structure

    Public Structure sRcpGrayScaleSweep
        Dim nMyMode As eRcpMode
        Dim sMeasPoints As ucDispPointSetting.sMeasurePointInfos
        Dim sModuleInfos As frmPatternGeneratorSetting.sPGInfos
        Dim sSweepInfos As ucDispRcpGrayScaleSweep.sGrayScaleInfos
    End Structure

    Public Structure sRcpPatternMeasure
        Dim sMeasPoints As ucDispPointSetting.sMeasurePointInfos  '측정 포인트 정보
        Dim sModuleInfos As frmPatternGeneratorSetting.sPGInfos  'Module 용 Device(PG, PG Power, 모듈 구동기) 제어 구조체
    End Structure


    Public Structure sSaveOptions '데이터 처장 클래스로 위치이동 필요
        Dim isAccumulateTempChangeTime As Boolean
        Dim bContinuousDataSave As Boolean
    End Structure

    Public Structure sRcpChangeTemp
        Dim dTargetTemp As Double
        Dim StableTime As CTime.sTimeValue
    End Structure

#End Region


#Region "Defines"

    Dim m_sPathSequenceFolder As String = "\Sequence"
    Dim sequenceList As CSequenceListManager
    Private m_sRecipe As sRecipeInfo
    Private WithEvents sequence As CSequenceManager

    'Control 등록
    Dim WithEvents ucDispImageSweep As ucDispRcpImageSweep
    Dim WithEvents ucDispChangeTemp As ucDispRcpTemp
    Dim WithEvents ucDispGrayScaleSweep As ucDispRcpGrayScaleSweep
    Dim WithEvents ucDispViewingAngle As ucDispRcpViewingAngle
    ' Dim WithEvents ucDispPatternMeas As ucDispRcpPattern
    Dim WithEvents ucDispIVLSweep As ucDispRcpIVLSweep
    Dim WithEvents ucDispImageSticking As ucDispRcpImageSticking
    Dim WithEvents ucDispLifetimeAndIVL As ucDispRcpLifetimeAndIVLSweep
    Dim WithEvents ucDispAging As ucDispRcpAging

    Dim nSeqListIndex As Integer
    Dim m_nSeqEditIndex As Integer


    Dim m_bIsLoaded As Boolean = False

#End Region


#Region "Shared Functions"

    Public Shared Function GetModeList() As String()
        Return sCaptions_RecipeModes.Clone
    End Function


#End Region

#Region "Creator"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Public Sub init()

        sequenceList = New CSequenceListManager

        spContainer.Location = New System.Drawing.Point(0, BuilderMenu.Size.Height + BuilderMenu.Margin.Bottom)
        spContainer.Dock = DockStyle.Fill
        spContainer.SplitterDistance = 370

        tlpSequenceList.Location = New System.Drawing.Point(tlpSequenceList.Margin.Left, tlpSequenceList.Margin.Top)
        tlpSequenceList.Dock = DockStyle.Fill

        spContainerEditor.SplitterDistance = 750  '810

        gbSequeceManager.Location = New System.Drawing.Point(0, 0)
        gbSequeceManager.Dock = DockStyle.Fill

        gbSequenceEditor.Location = New System.Drawing.Point(0, 0)
        gbSequenceEditor.Dock = DockStyle.Fill

        tlpSequenceEditor.Dock = DockStyle.Fill
        tlpSequenceEditorButton.Dock = DockStyle.Fill
        spcSequenceEditor.Dock = DockStyle.Fill
   

        tlpRcpEditor.Location = New System.Drawing.Point(tlpRcpEditor.Margin.Left, tlpRcpEditor.Margin.Top)
        tlpRcpEditor.Dock = DockStyle.Fill

        'pnSettings.Location = New System.Drawing.Point(0, 0)
        pnSettings.Dock = DockStyle.Fill

        rdoIVL.Dock = DockStyle.Fill
        rdoLifetime.Dock = DockStyle.Fill
        rdoChangeTemp.Dock = DockStyle.Fill
        rdoViewingAngle.Dock = DockStyle.Fill
        rdoGrayScaleSweep.Dock = DockStyle.Fill
        rdoImageSweep.Dock = DockStyle.Fill
        rdoImageSticking.Dock = DockStyle.Fill
        rdoRGBWAging.Dock = DockStyle.Fill
        rdoLifetimeAndIVL.Dock = DockStyle.Fill
        rdoAging.Dock = DockStyle.Fill
        'tlpRcpMode.Location = New System.Drawing.Point(0, 0)
        tlpRcpMode.Dock = DockStyle.Fill

        Dim margine As Size

        'Sequence Manager
        margine.Width = 3
        margine.Height = 3
        btnNew.Location = New System.Drawing.Point(3, 3)
        btnImport.Location = New System.Drawing.Point(btnNew.Location.X + btnNew.Size.Width + margine.Width, 3)
        btnExport.Location = New System.Drawing.Point(btnImport.Location.X + btnImport.Size.Width + margine.Width, 3)
        btnDeleteSeqFile.Location = New System.Drawing.Point(btnExport.Location.X + btnExport.Size.Width + margine.Width, 3)

        '  gbSequeceManager.Location = New System.Drawing.Point(3, btnNew.Location.Y + btnNew.Size.Height + margine.Height)

        ucListSeqManager = New ucDispListView
        ucListSeqManager.ColHeader = New String() {"NO.", "Sequence Name", "Description"}
        ucListSeqManager.ColHeaderWidthRatio = "10,30,60"
        ucListSeqManager.UseCheckBoxex = False
        ucListSeqManager.Dock = DockStyle.Fill
        ucListSeqManager.FullRawSelection = True
        ucListSeqManager.ImeMode = Windows.Forms.ImeMode.NoControl
        ucListSeqManager.AccessibleRole = Windows.Forms.AccessibleRole.Default
        ucListSeqManager.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowOnly
        ucListSeqManager.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        ucListSeqManager.HideSelection = False
        ucListSeqManager.LabelEdit = False
        ucListSeqManager.LabelWrap = False

        gbSequeceManager.Controls.Add(Me.ucListSeqManager)


        'Sequence Editor
        btnSave.Location = New System.Drawing.Point(3, 3)
        btnUp.Location = New System.Drawing.Point(btnSave.Location.X + btnSave.Size.Width + margine.Width, 3)
        btnDown.Location = New System.Drawing.Point(btnUp.Location.X + btnUp.Size.Width + margine.Width, 3)
        btnDelete.Location = New System.Drawing.Point(btnDown.Location.X + btnDown.Size.Width + margine.Width, 3)
        btnClear.Location = New System.Drawing.Point(btnDelete.Location.X + btnDelete.Size.Width + margine.Width, 3)

        '  gbSequenceEditor.Location = New System.Drawing.Point(3, btnSave.Location.Y + btnSave.Size.Height + margine.Height)

        ucDataGridSeqEditor = New ucDataGridView
        Me.gbSequenceEditor.Controls.Add(Me.ucDataGridSeqEditor)
        ucDataGridSeqEditor.ControllerHeaderText = New String() {"Recipe Type", "Setting Informations"}
        ucDataGridSeqEditor.ColHeaderWidthRatio = "30,110"
        ucDataGridSeqEditor.Dock = DockStyle.Fill

        ucDispCommon = New ucDispRcpCommon
        spcSequenceEditor.Panel2.Controls.Add(ucDispCommon)
        ucDispCommon.Dock = DockStyle.Fill
        'ucDispCommon.Location = New System.Drawing.Point(gbSequenceEditor.Location.X, gbSequenceEditor.Location.Y + gbSequenceEditor.Size.Height + 10)
        'ucDispCommon.Size = New System.Drawing.Size(737, 369) '(gbSequenceEditor.Width - 3, 369)   
        '737, 369
        'Recipe Setting
        ucDispLifetime = New ucDispRcpLifetime
        ucDispImageSweep = New ucDispRcpImageSweep
        ucDispChangeTemp = New ucDispRcpTemp
        ucDispIVLSweep = New ucDispRcpIVLSweep
        ucDispGrayScaleSweep = New ucDispRcpGrayScaleSweep
        ucDispImageSticking = New ucDispRcpImageSticking
        ucDispViewingAngle = New ucDispRcpViewingAngle
        ucDispLifetimeAndIVL = New ucDispRcpLifetimeAndIVLSweep
        ucDispAging = New ucDispRcpAging

        'pnSettings.Controls.Add(ucDispLifetime)
        'pnSettings.Controls.Add(ucDispImageSweep)
        'pnSettings.Controls.Add(ucDispChangeTemp)
        'pnSettings.Controls.Add(ucDispIVLSweep)
        'pnSettings.Controls.Add(ucDispGrayScaleSweep)
        'pnSettings.Controls.Add(ucDispImageSticking)
        'pnSettings.Controls.Add(ucDispViewingAngle)

        ucDispLifetime.Dock = DockStyle.Fill
        '   ucDispLifetime.Location = New System.Drawing.Point(0, 0)

        ucDispIVLSweep.Dock = DockStyle.Fill
        '  ucDispIVLSweep.Location = New System.Drawing.Point(0, 0)

        ucDispGrayScaleSweep.Dock = DockStyle.Fill
        ' ucDispGrayScaleSweep.Location = New System.Drawing.Point(0, 0)

        ucDispImageSweep.Dock = DockStyle.Fill
        '  ucDispImageSweep.Location = New System.Drawing.Point(0, 0)

        ucDispChangeTemp.Dock = DockStyle.Fill

        ucDispImageSticking.Dock = DockStyle.Fill
        ' ucDispImageSticking.Location = New System.Drawing.Point(0, 0)

        ucDispViewingAngle.Dock = DockStyle.Fill

        ucDispLifetimeAndIVL.Dock = DockStyle.Fill
        '  ucDispViewingAngle.Location = New System.Drawing.Point(0, 0)
        'ucListSeqManager.AddInit()
        ucDispAging.Dock = DockStyle.Fill
    End Sub

    Private Sub ucSequenceBuilder_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ucDispLifetime.Dispose()
        ucDispImageSweep.Dispose()
        ucDispGrayScaleSweep.Dispose()
        ucDispImageSticking.Dispose()
        ucDispIVLSweep.Dispose()
        ucDispChangeTemp.Dispose()
        ucDispViewingAngle.Dispose()
        ucDispLifetimeAndIVL.Dispose()
        ucDispAging.Dispose()
    End Sub

    Private Sub ucSequenceBuilder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Delete Then
            sequenceList.Del(nSeqListIndex)

            UpdateCommonInfos()

            ucDataGridSeqEditor.ClearRow()
        End If
    End Sub

    Private Sub ucSequenceBuilder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        updateBuilderSetting()

        If sequenceList.Counter > 0 And sequenceList.SequenceList Is Nothing = False Then
            sequence = New CSequenceManager
            sequence.LoadSequence(Application.StartupPath & sequenceList.SequenceList(nSeqListIndex).sPath)
            'sequence.LoadSequence(sequenceList.SequenceList(sequenceList.Counter - 1).sPath)
        Else
            Exit Sub
        End If

        UpdateCommonInfos()

        UpdateSeqMgrList()
        ' UpdateDisp(sequence.SequenceInfo)
        m_bIsLoaded = True

        ' FitUISize_SeqEdit()
    End Sub

    Public Sub updateBuilderSetting()
        Dim SettingDlg As New frmBuilderSettings
        Dim settingInfo As frmBuilderSettings.sSeqBuilderSettings = Nothing
        If frmBuilderSettings.LoadSeqBuilderSetting(settingInfo) = False Then Exit Sub

        g_SequenceBuilderOptions = settingInfo

        With settingInfo

            'Recipe View 
            ucDispCommon.Visible = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Recipe)(frmBuilderSettings.eViewSettingRcpItems._Common)
            rdoIVL.Visible = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Recipe)(frmBuilderSettings.eViewSettingRcpItems._IVLSweep)
            rdoLifetime.Visible = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Recipe)(frmBuilderSettings.eViewSettingRcpItems._Lifetime)
            rdoLifetimeAndIVL.Visible = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Recipe)(frmBuilderSettings.eViewSettingRcpItems._LifetimeAndIVL)
            rdoChangeTemp.Visible = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Recipe)(frmBuilderSettings.eViewSettingRcpItems._Temperature)
            rdoGrayScaleSweep.Visible = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Recipe)(frmBuilderSettings.eViewSettingRcpItems._GrayScaleSweep)
            rdoImageSweep.Visible = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Recipe)(frmBuilderSettings.eViewSettingRcpItems._ImageSweep)
            rdoRGBWAging.Visible = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Recipe)(frmBuilderSettings.eViewSettingRcpItems._RGBWAging)
            rdoImageSticking.Visible = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Recipe)(frmBuilderSettings.eViewSettingRcpItems._Pattern)
            rdoViewingAngle.Visible = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Recipe)(frmBuilderSettings.eViewSettingRcpItems._ViewingAngle)
            rdoAging.Visible = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Recipe)(frmBuilderSettings.eViewSettingRcpItems._Aging)

            '
            'Common Recipe
            ucDispCommon.VisibleSeqTitle = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_SequenceTitle)
            ucDispCommon.VisibleSampleType = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_SampleType)
            ucDispCommon.VisibleSampleColor = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_SampleColor)
            ucDispCommon.VisibleSampleSize = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_SampleSize)
            ucDispCommon.VisibleFillFactor = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_FillFactor)
            ucDispCommon.VisibleComment = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_Comment)
            ucDispCommon.VisibleDefTemp = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_DefaultTemp)
            ucDispCommon.VisibleACFMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_ACFMode)
            ucDispCommon.VisibleLimitSettings = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_LimitSetting)
            ucDispCommon.VisibleSeqEndCondition = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Common)(frmBuilderSettings.eViewSettingCommonRcpItems._CommonGrp_SequenceEndSetting)


            'IVL Recipe
            ucDispIVLSweep.VisibleDetailSettings = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_DetailSettings)
            ucDispIVLSweep.VisibleBiasMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_BiasMode)
            ucDispIVLSweep.VisibleMeasMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_MeasurementMode)
            ucDispIVLSweep.VisibleLumiMeasLevel = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_LuminanceMeasureLevel)
            ucDispIVLSweep.VisibleSweepType = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_SweepType)
            ucDispIVLSweep.VisibleSweepRegionSettings = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_SweepRegionSettings)
            ucDispIVLSweep.VisibleViewingAngleSettings = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_ViewingAngle)
            ucDispIVLSweep.VisibleLumiMeasLimit = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_LuminanceMeasureLimit)
            ucDispIVLSweep.VisibleCurrentMeasLimit = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_CurrentMeasureLimit)
            ucDispIVLSweep.VisibleucColorSettings = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_ColorList)
            ucDispIVLSweep.VisibleLumiCorrection = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_LumiCorrection)

            'Lifetime Recipe
            ucDispLifetime.VisibleOperationMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_Common_OperationMode)
            ucDispLifetime.VisibleEndActionSetting = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_Common_EndAction)
            ucDispLifetime.VisibleEndConditionSetting = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_Common_EndConditionSettings)
            ucDispLifetime.VisibleRefPDSetting = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_Common_RefLuminanceSettings)
            ucDispLifetime.VisibleSaveIntervalSetting = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_Common_SaveIntervalSettings)

            For i As Integer = 0 To ucDispLifetime.ucDispM6000.Length - 1
                ucDispLifetime.ucDispM6000(i).VisibleAmplitude = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Amplitude)
                ucDispLifetime.ucDispM6000(i).VisibleBias = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Bias)
                ucDispLifetime.ucDispM6000(i).VisibleBtnADD = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_BtnADD)
                ucDispLifetime.ucDispM6000(i).VisibleConstantBright = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_ConstantBrightness)
                ucDispLifetime.ucDispM6000(i).VisibleDuty = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Duty)
                ucDispLifetime.ucDispM6000(i).VisibleFrequency = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Frequency)
                ucDispLifetime.ucDispM6000(i).VisibleSetRev = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_SetRev)
                ucDispLifetime.ucDispM6000(i).VisibleSourceMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_SourceMode)
                ucDispLifetime.ucDispM6000(i).VisibleChkEnable = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_ChkEnable)
            Next

            ' 'Lifetime Recipe + IVL Recipe  공통으로 같이 사용 하도록  Load & Save에서 Lifetime,  IVL 부분을 가져옴
            ucDispLifetimeAndIVL.VisibleDetailSettings = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_DetailSettings)
            ucDispLifetimeAndIVL.VisibleBiasMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_BiasMode)
            ucDispLifetimeAndIVL.VisibleMeasMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_MeasurementMode)
            ucDispLifetimeAndIVL.VisibleLumiMeasLevel = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_LuminanceMeasureLevel)
            ucDispLifetimeAndIVL.VisibleSweepType = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_SweepType)
            ucDispLifetimeAndIVL.VisibleSweepRegionSettings = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_SweepRegionSettings)
            ucDispLifetimeAndIVL.VisibleViewingAngleSettings = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_ViewingAngle)
            ucDispLifetimeAndIVL.VisibleucColorSettings = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_ColorList)
            ucDispLifetimeAndIVL.VisibleLumiMeasLimit = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_LuminanceMeasureLimit)
            ucDispLifetimeAndIVL.VisibleCurrentMeasLimit = .bViewSettings(frmBuilderSettings.eViewSettingGroup._IVL)(frmBuilderSettings.eViewSettingIVLRcpItems._IVLRcpGrp_Common_CurrentMeasureLimit)

            ucDispLifetimeAndIVL.VisibleOperationMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_Common_OperationMode)
            ucDispLifetimeAndIVL.VisibleEndActionSetting = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_Common_EndAction)
            ucDispLifetimeAndIVL.VisibleEndConditionSetting = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_Common_EndConditionSettings)
            ucDispLifetimeAndIVL.VisibleRefPDSetting = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_Common_RefLuminanceSettings)
            ucDispLifetimeAndIVL.VisibleSaveIntervalSetting = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_Common_SaveIntervalSettings)
            ucDispLifetimeAndIVL.ucDispM6000.VisibleAmplitude = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Amplitude)
            ucDispLifetimeAndIVL.ucDispM6000.VisibleBias = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Bias)
            ucDispLifetimeAndIVL.ucDispM6000.VisibleBtnADD = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_BtnADD)
            ucDispLifetimeAndIVL.ucDispM6000.VisibleConstantBright = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_ConstantBrightness)
            ucDispLifetimeAndIVL.ucDispM6000.VisibleDuty = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Duty)
            ucDispLifetimeAndIVL.ucDispM6000.VisibleFrequency = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Frequency)
            ucDispLifetimeAndIVL.ucDispM6000.VisibleSetRev = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_SetRev)
            ucDispLifetimeAndIVL.ucDispM6000.VisibleSourceMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_SourceMode)
            ucDispLifetimeAndIVL.ucDispM6000.VisibleChkEnable = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_ChkEnable)

            'ucDispLifetime.ucDispM6000(0).VisibleAmplitude = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Amplitude)
            'ucDispLifetime.ucDispM6000(0).VisibleBias = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Bias)
            'ucDispLifetime.ucDispM6000(0).VisibleBtnADD = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_BtnADD)
            'ucDispLifetime.ucDispM6000(0).VisibleConstantBright = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_ConstantBrightness)
            'ucDispLifetime.ucDispM6000(0).VisibleDuty = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Duty)
            'ucDispLifetime.ucDispM6000(0).VisibleFrequency = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Frequency)
            'ucDispLifetime.ucDispM6000(0).VisibleSetRev = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_SetRev)
            'ucDispLifetime.ucDispM6000(0).VisibleSourceMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_SourceMode)

            'ucDispLifetime.ucDispM6000(1).VisibleAmplitude = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Amplitude)
            'ucDispLifetime.ucDispM6000(1).VisibleBias = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Bias)
            'ucDispLifetime.ucDispM6000(1).VisibleBtnADD = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_BtnADD)
            'ucDispLifetime.ucDispM6000(1).VisibleConstantBright = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_ConstantBrightness)
            'ucDispLifetime.ucDispM6000(1).VisibleDuty = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Duty)
            'ucDispLifetime.ucDispM6000(1).VisibleFrequency = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Frequency)
            'ucDispLifetime.ucDispM6000(1).VisibleSetRev = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_SetRev)
            'ucDispLifetime.ucDispM6000(1).VisibleSourceMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_SourceMode)

            'ucDispLifetime.ucDispM6000(2).VisibleAmplitude = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Amplitude)
            'ucDispLifetime.ucDispM6000(2).VisibleBias = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Bias)
            'ucDispLifetime.ucDispM6000(2).VisibleBtnADD = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_BtnADD)
            'ucDispLifetime.ucDispM6000(2).VisibleConstantBright = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_ConstantBrightness)
            'ucDispLifetime.ucDispM6000(2).VisibleDuty = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Duty)
            'ucDispLifetime.ucDispM6000(2).VisibleFrequency = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_Frequency)
            'ucDispLifetime.ucDispM6000(2).VisibleSetRev = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_SetRev)
            'ucDispLifetime.ucDispM6000(2).VisibleSourceMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_M6000_SourceMode)

            ucDispLifetime.VisibleRGBWRotation = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_McSG_RGBWRotation)
            ucDispLifetime.ucDispMcPG.VisibleInitCodeEditTabPage = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_McPG_InitCodeEditor)
            ucDispLifetime.ucDispMcPG.VisiblePowerControlTabPage = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_McPG_PowerControl)
            ucDispLifetime.ucDispMcPG.VisiblePatternEditTabPage = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_McPG_PatternEditor)
            ucDispLifetime.VisibleViewingAngle = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Lifetime)(frmBuilderSettings.eViewSettingLifetimeRcpItems._LTRcpGrp_ViewingAngleSettings)

            'Temperature Recipe
            ucDispChangeTemp.VisibleTargetTemp = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Temperature)(frmBuilderSettings.eViewSettingTempRcpItems._TempRcpGrp_Common_TargetTemperature)
            ucDispChangeTemp.VisibleStableTime = .bViewSettings(frmBuilderSettings.eViewSettingGroup._Temperature)(frmBuilderSettings.eViewSettingTempRcpItems._TempRcpGrp_Common_StabilizationTime)

            'Viewing Angle Sweep Recipe
            'ucDispViewingAngle.VisibleDevieType = .bViewSettings(frmBuilderSettings.eViewSettingGroup._ViewingAngle)(frmBuilderSettings.eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_DeviceUnit)
            'ucDispViewingAngle.VisibleBiasMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._ViewingAngle)(frmBuilderSettings.eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_BiasMode)
            'ucDispViewingAngle.VisibleBias = .bViewSettings(frmBuilderSettings.eViewSettingGroup._ViewingAngle)(frmBuilderSettings.eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_Bias)
            ucDispViewingAngle.VisibleSweepType = .bViewSettings(frmBuilderSettings.eViewSettingGroup._ViewingAngle)(frmBuilderSettings.eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_SweepType)
            ucDispViewingAngle.VisibleSweepRegionSettings = .bViewSettings(frmBuilderSettings.eViewSettingGroup._ViewingAngle)(frmBuilderSettings.eViewSettingViewingAngleItems._ViewingAngleRcpGrp_Common_SweepRegionSettings)
            For i As Integer = 0 To ucDispViewingAngle.ucDispM6000.Length - 1
                ucDispViewingAngle.ucDispM6000(i).VisibleAmplitude = .bViewSettings(frmBuilderSettings.eViewSettingGroup._ViewingAngle)(frmBuilderSettings.eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_Amplitude)
                ucDispViewingAngle.ucDispM6000(i).VisibleBias = .bViewSettings(frmBuilderSettings.eViewSettingGroup._ViewingAngle)(frmBuilderSettings.eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_Bias)
                ucDispViewingAngle.ucDispM6000(i).VisibleBtnADD = .bViewSettings(frmBuilderSettings.eViewSettingGroup._ViewingAngle)(frmBuilderSettings.eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_BtnADD)
                ucDispViewingAngle.ucDispM6000(i).VisibleConstantBright = .bViewSettings(frmBuilderSettings.eViewSettingGroup._ViewingAngle)(frmBuilderSettings.eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_ConstantBrightness)
                ucDispViewingAngle.ucDispM6000(i).VisibleDuty = .bViewSettings(frmBuilderSettings.eViewSettingGroup._ViewingAngle)(frmBuilderSettings.eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_Duty)
                ucDispViewingAngle.ucDispM6000(i).VisibleFrequency = .bViewSettings(frmBuilderSettings.eViewSettingGroup._ViewingAngle)(frmBuilderSettings.eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_Frequency)
                ucDispViewingAngle.ucDispM6000(i).VisibleSetRev = .bViewSettings(frmBuilderSettings.eViewSettingGroup._ViewingAngle)(frmBuilderSettings.eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_SetRev)
                ucDispViewingAngle.ucDispM6000(i).VisibleSourceMode = .bViewSettings(frmBuilderSettings.eViewSettingGroup._ViewingAngle)(frmBuilderSettings.eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_SourceMode)
                ucDispViewingAngle.ucDispM6000(i).VisibleChkEnable = .bViewSettings(frmBuilderSettings.eViewSettingGroup._ViewingAngle)(frmBuilderSettings.eViewSettingViewingAngleItems._ViewingAngleRcpGrp_M6000_ChkEnabl)
            Next

            'Other Settting
            ucDispLifetime.ucTestEndParam.UsedParams = .settings_UsedRcpEndParam
            ucDispLifetimeAndIVL.ucTestEndParam.UsedParams = .settings_UsedRcpEndParam
            ucDispLifetimeAndIVL.ucTestIVLMeasParam.UsedParams = .settings_UsedIVLSweepMeasParam
            ucDispCommon.ucDispCommonConditions.ucSeqEndParam.UsedParams = .settings_UsedSequenceEndParam
            ucDispAging.ucTestEndParam.UsedParams = .settings_UsedAgingEndParam


        End With
    End Sub


    Public Sub GetUISizeInfos()
        With g_SequenceBuilderOptions
            .UISettings.nSeqList_SplitterDistance = spContainer.SplitterDistance
            .UISettings.nSeqEdit_SplitterDistance = spContainerEditor.SplitterDistance
            .UISettings.nSeqEditList_SplitterDistance = spcSequenceEditor.SplitterDistance
            .UISettings.nRcp_LT_SplitterDistance = ucDispLifetime.spContainer.SplitterDistance
            .UISettings.nRcp_IVL_SplitterDistance = ucDispIVLSweep.spContainer.SplitterDistance
            ' .UISettings.nRcp_IVL_Common_SplitterDistance01 = ucDispIVLSweep.SplitContainer3.SplitterDistance
            .UISettings.nRcp_IVL_Common_SplitterDistance02 = ucDispIVLSweep.SplitContainer2.SplitterDistance
            .UISettings.nRcp_ViewingAngle_SplitterDistance = ucDispViewingAngle.spContainer.SplitterDistance

            .UISettings.nRcp_LifetimeAndIVL_SplitterDistance = ucDispLifetimeAndIVL.spContainer.SplitterDistance
            .UISettings.nRcp_LifetimeAndIVL_Common_SplitterDistance02 = ucDispLifetimeAndIVL.SplitContainer2.SplitterDistance

            .UISettings.nRcp_Aging_SplitterDistance = ucDispAging.spContainer.SplitterDistance
        End With
    End Sub

    Public Sub SetUISizeInfos()
        With g_SequenceBuilderOptions
            'UI Settings

            spContainer.SplitterDistance = .UISettings.nSeqList_SplitterDistance
            spContainerEditor.SplitterDistance = .UISettings.nSeqEdit_SplitterDistance
            spcSequenceEditor.SplitterDistance = .UISettings.nSeqEditList_SplitterDistance
            ucDispLifetime.spContainer.SplitterDistance = .UISettings.nRcp_LT_SplitterDistance

            ucDispIVLSweep.spContainer.SplitterDistance = .UISettings.nRcp_IVL_SplitterDistance
            '  ucDispIVLSweep.SplitContainer3.SplitterDistance = .UISettings.nRcp_IVL_Common_SplitterDistance01
            ucDispIVLSweep.SplitContainer2.SplitterDistance = .UISettings.nRcp_IVL_Common_SplitterDistance02
            ucDispViewingAngle.spContainer.SplitterDistance = .UISettings.nRcp_ViewingAngle_SplitterDistance

            ucDispLifetimeAndIVL.spContainer.SplitterDistance = .UISettings.nRcp_LifetimeAndIVL_SplitterDistance
            ucDispLifetimeAndIVL.SplitContainer2.SplitterDistance = .UISettings.nRcp_LifetimeAndIVL_Common_SplitterDistance02

            ucDispAging.spContainer.SplitterDistance = .UISettings.nRcp_Aging_SplitterDistance
        End With
    End Sub

#End Region

    Private Sub UcDataGridView1_evCompoboxSelectedIndexChanged(ByVal selectedItemIdx As Integer, ByVal nRaw As Integer, ByVal nCol As Integer) Handles ucDataGridSeqEditor.evCompoboxSelectedIndexChanged

        Dim eSeqmode As eRcpMode = selectedItemIdx
        'Select Case eSeqmode

        '    Case eRcpMode.eNothing
        '        lblTest.Text = "추가할 실험 모드를 선택하세요."
        '        'ucDataGridSeqEditor.DelLastRow()
        '    Case eRcpMode.eCell_IVL
        '        lblTest.Text = "Cell IVL Test Recipe Setting UI"
        '        'ucDataGridSeqEditor.AddRow()
        '    Case eRcpMode.eCell_Lifetime
        '        lblTest.Text = "Cell Lifetime Test Recipe Setting UI"
        '        'ucDataGridSeqEditor.AddRow()
        '    Case eRcpMode.ePanel_IVL
        '        lblTest.Text = "Panel IVL Test Recipe Setting UI"
        '        'ucDataGridSeqEditor.AddRow()
        '    Case eRcpMode.ePanel_Lifetime
        '        lblTest.Text = "Panel IVL Test Recipe Setting UI"
        '        'ucDataGridSeqEditor.AddRow()
        '    Case eRcpMode.eModuel_IVL
        '        lblTest.Text = "Module IVL Test Recipe Setting UI"
        '        'ucDataGridSeqEditor.AddRow()
        '    Case eRcpMode.eModule_Lifetime
        '        lblTest.Text = "Module Lifetime Test Recipe Setting UI"
        '        'ucDataGridSeqEditor.AddRow()
        '    Case eRcpMode.eModule_GrayScaleSweep
        '        lblTest.Text = "UserPattern Test Recipe Setting UI"
        '        'ucDataGridSeqEditor.AddRow()
        '    Case eRcpMode.eModule_ImageSweep
        '        lblTest.Text = "Image Sweep Test Recipe Setting UI"
        '        'ucDataGridSeqEditor.AddRow()
        '    Case eRcpMode.eChangeTemperature
        '        lblTest.Text = "Change Temperature Test Recipe Setting UI"
        '        'ucDataGridSeqEditor.AddRow()
        '    Case Else
        '        lblTest.Text = "이상"
        'End Select

        If eSeqmode <> eRcpMode.eNothing And nRaw <= ucDataGridSeqEditor.RowLineNum And nRaw = ucDataGridSeqEditor.RowLineNum - 1 Then
            ucDataGridSeqEditor.AddRow()
        ElseIf eSeqmode = eRcpMode.eNothing Then
            If ucDataGridSeqEditor.RowLineNum > nRaw + 1 Then
                ucDataGridSeqEditor.DelLastRow()
            End If
        End If
    End Sub



#Region "Sequence Management Functions"

    Dim flgNew As Boolean = False

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim seqCreator As New frmCrateNewSeq

        seqCreator.ucCommonInfo.tbSeqTitle.Enabled = True
        seqCreator.ucCommonInfo.tbComment.Enabled = True

        Dim ImsiSeq As CSequenceManager.sSequenceInfo = Nothing

        '시퀀스 빌더 옵션 값을 여기서 다 넘겨 받는다....시퀀스 빌더 옵션 구조체가 글로벌 변수로 선언을 하였다....파일에 저장하고 로드한다..
        'seqCreator.ucCommonInfo.UcLimitSetting1.Settings = g_SequenceBuilderOptions.sLimitSettings
        'seqCreator.ucCommonInfo.ucSeqEndParam.Settings = g_SequenceBuilderOptions.sTestEndParam
        'seqCreator.ucCommonInfo.tbDefaultTemp.Text = g_SequenceBuilderOptions.dDefaultTemp
        seqCreator.ucCommonInfo.tbSizeWidth.Text = g_SequenceBuilderOptions.dWidth
        seqCreator.ucCommonInfo.tbSizeHight.Text = g_SequenceBuilderOptions.dHight
        seqCreator.ucCommonInfo.tbFillFactor.Text = g_SequenceBuilderOptions.dFillFactor

        For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
            If g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.eMcSG Then
                seqCreator.ucCommonInfo.cbSelSampleType.SelectedIndex = 1
                Exit For
            ElseIf g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.ePG Then
                seqCreator.ucCommonInfo.cbSelSampleType.SelectedIndex = 2
                Exit For
            ElseIf g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.eSMU_IVL Then
                seqCreator.ucCommonInfo.cbSelSampleType.SelectedIndex = 0
                Exit For
            End If
        Next

        If seqCreator.ShowDialog = DialogResult.OK Then
            Dim seqListInfo As CSequenceListManager.SequenceListInfo

            seqListInfo.sSequenceName = seqCreator.ucCommonInfo.Settings.sTitle
            seqListInfo.sDescriptions = seqCreator.ucCommonInfo.Settings.sComment
            seqListInfo.nSampleType = seqCreator.ucCommonInfo.Settings.sampleType
            seqListInfo.sPath = m_sPathSequenceFolder & "\" & seqCreator.ucCommonInfo.Settings.sTitle & ".seq"

            For i As Integer = 0 To sequenceList.Counter - 1
                If sequenceList.SequenceList(i).sSequenceName = seqListInfo.sSequenceName Then
                    MsgBox("A file with the same name exists.")
                    Exit Sub
                End If
            Next

            sequenceList.Add(seqListInfo)

            sequence = New CSequenceManager

            'ReDim ImsiSeq.sCommon.sLimits(seqCreator.ucCommonInfo.UcLimitSetting1.Settings.Length - 1)
            'ReDim ImsiSeq.sCommon.sSequenceEnd(seqCreator.ucCommonInfo.ucSeqEndParam.Settings.Length - 1)

            'For idx As Integer = 0 To seqCreator.ucCommonInfo.UcLimitSetting1.Settings.Length - 1
            '    If seqCreator.ucCommonInfo.UcLimitSetting1.Settings(idx).eTypeOfValue = ucLimitSetting.eLimitValueType.eVoltage Then
            '        ImsiSeq.sCommon.sLimits(idx).eTypeOfValue = ucLimitSetting.eLimitValueType.eVoltage
            '    ElseIf seqCreator.ucCommonInfo.UcLimitSetting1.Settings(idx).eTypeOfValue = ucLimitSetting.eLimitValueType.eCurrent Then
            '        ImsiSeq.sCommon.sLimits(idx).eTypeOfValue = ucLimitSetting.eLimitValueType.eCurrent
            '    End If

            '    ImsiSeq.sCommon.sLimits(idx).LimitValue.dMax = seqCreator.ucCommonInfo.UcLimitSetting1.Settings(idx).LimitValue.dMax
            '    ImsiSeq.sCommon.sLimits(idx).LimitValue.dMin = seqCreator.ucCommonInfo.UcLimitSetting1.Settings(idx).LimitValue.dMin
            'Next

            'For idx As Integer = 0 To seqCreator.ucCommonInfo.ucSeqEndParam.Settings.Length - 1
            '    If seqCreator.ucCommonInfo.ucSeqEndParam.Settings(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.eVolt Then
            '        ImsiSeq.sCommon.sSequenceEnd(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.eVolt
            '    ElseIf seqCreator.ucCommonInfo.ucSeqEndParam.Settings(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.eHightVolt Then
            '        ImsiSeq.sCommon.sSequenceEnd(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.eHightVolt
            '    ElseIf seqCreator.ucCommonInfo.ucSeqEndParam.Settings(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.eCurr Then
            '        ImsiSeq.sCommon.sSequenceEnd(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.eCurr
            '    ElseIf seqCreator.ucCommonInfo.ucSeqEndParam.Settings(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.eHighCurrent Then
            '        ImsiSeq.sCommon.sSequenceEnd(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.eHighCurrent
            '    ElseIf seqCreator.ucCommonInfo.ucSeqEndParam.Settings(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.eTime Then
            '        ImsiSeq.sCommon.sSequenceEnd(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.eTime
            '    ElseIf seqCreator.ucCommonInfo.ucSeqEndParam.Settings(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.eLumi Then
            '        ImsiSeq.sCommon.sSequenceEnd(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.eLumi
            '    ElseIf seqCreator.ucCommonInfo.ucSeqEndParam.Settings(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.ePDCurr Then
            '        ImsiSeq.sCommon.sSequenceEnd(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.ePDCurr
            '    ElseIf seqCreator.ucCommonInfo.ucSeqEndParam.Settings(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.eLoopCount Then
            '        ImsiSeq.sCommon.sSequenceEnd(idx).nTypeOfParam = ucTestEndParam.eTestEndParam.eLoopCount
            '    End If

            '    ImsiSeq.sCommon.sSequenceEnd(idx).dValue = seqCreator.ucCommonInfo.ucSeqEndParam.Settings(idx).dValue
            'Next

            'ImsiSeq.sCommon.dDefaultTemp = CDbl(seqCreator.ucCommonInfo.tbDefaultTemp.Text)

            ImsiSeq.sCommon.dDefaultTemp = g_SequenceBuilderOptions.dDefaultTemp
            ImsiSeq.sCommon.sLimits = g_SequenceBuilderOptions.sLimitSettings
            ImsiSeq.sCommon.sSequenceEnd = g_SequenceBuilderOptions.sTestEndParam
            ImsiSeq.sSampleInfos.SampleSize.Width = seqCreator.ucCommonInfo.tbSizeWidth.Text
            ImsiSeq.sSampleInfos.SampleSize.Height = seqCreator.ucCommonInfo.tbSizeHight.Text
            ImsiSeq.sSampleInfos.dFillFactor = seqCreator.ucCommonInfo.tbFillFactor.Text

            sequence.SequenceInfo = ImsiSeq

            sequence.Create(seqCreator.ucCommonInfo.Settings, Application.StartupPath & seqListInfo.sPath)

            flgNew = True
            UpdateCommonInfos()
            flgNew = False
            UpdateSeqMgrList()

            '생성한 시퀀스 파일 선택
            ucListSeqManager.SetLastRowSelect()

        End If
    End Sub


    ' seqListInfo.sPath  : 상대 경로 정보만을 저장
    'FileOpen함수등 외부와 인터페이스 되는 함수에서 간혹 상대 경로를 인식하지 못하는 경우가 있음, 따라서, 이 부분만 절대 경로로 만들어서 처리함

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim SeqTitle As String = Nothing
        Dim fileInfo As CMcFile.sFILENAME = Nothing
        Dim fileDlg As New CMcFile

        If fileDlg.GetLoadFileName(CMcFile.eFileType._SEQ, Application.StartupPath & m_sPathSequenceFolder, fileInfo) = True Then
            If sequence Is Nothing Then
                sequence = New CSequenceManager
            End If

            sequence.LoadSequence(fileInfo.strPathAndFName)

            Dim seqListInfo As CSequenceListManager.SequenceListInfo
            seqListInfo.sSequenceName = sequence.SequenceInfo.sSampleInfos.sTitle  ' sequence.SequenceInfo.sSampleInfos.sTitle
            seqListInfo.nSampleType = sequence.SequenceInfo.sSampleInfos.sampleType
            seqListInfo.sDescriptions = sequence.SequenceInfo.sSampleInfos.sComment
            seqListInfo.sPath = m_sPathSequenceFolder & "\" & fileInfo.strFNameAndExt

            For i As Integer = 0 To sequenceList.Counter - 1
                If sequenceList.SequenceList(i).sSequenceName = seqListInfo.sSequenceName Then
                    MsgBox("A file with the same name exists.")
                    Exit Sub
                End If
            Next

            sequenceList.Add(seqListInfo)


            flgNew = True
            UpdateCommonInfos()
            flgNew = False

            UpdateSeqMgrList()
            UpdateSeqEditList(sequence.SequenceInfo)



            '   ' If File.Exists(m_sSavePath(idx)) = False Then
            ' fs = File.Create(m_sSavePath(idx))
            '  fs.Close()
            Try
                File.Copy(fileInfo.strPathAndFName, g_sPATH_SEQUENCE & fileInfo.strFNameAndExt, True)
            Catch ex As Exception
                'MsgBox("CrateSaveFile" & ex.Message)
            End Try
            'End If


        End If

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim FilePath As String
        Dim arrVal As Array
        Dim SeqTitle As String = Nothing

        With SaveFileDialog1
            .Title = "UploadFile"
            .Filter = "SEQ(*.seq)|*.seq"
            .InitialDirectory = "App.path"
            .OverwritePrompt = False
            .AddExtension = True
        End With

        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            FilePath = SaveFileDialog1.FileName

            arrVal = FilePath.Split("\")
            SeqTitle = arrVal(arrVal.Length - 1).ToString
            arrVal = SeqTitle.Split(".")
            SeqTitle = arrVal(0)

            Dim seqCreator As New frmCrateNewSeq
            Dim SeqIMSI As New CSequenceManager.sSequenceInfo
            SeqIMSI = sequence.SequenceInfo

            Dim seqListInfo As CSequenceListManager.SequenceListInfo


            SeqIMSI.sSampleInfos.sTitle = SeqTitle

            seqListInfo.sSequenceName = SeqTitle ' sequence.SequenceInfo.sSampleInfos.sTitle
            seqListInfo.nSampleType = sequence.SequenceInfo.sSampleInfos.sampleType
            seqListInfo.sDescriptions = sequence.SequenceInfo.sSampleInfos.sComment
            seqListInfo.sPath = FilePath 'sPathSequenceFolder & "\" & SeqTitle & ".seq" 'seqCreator.ucCommonInfo.Settings.sTitle

            'sequenceList.Add(seqListInfo)

            sequence.SequenceInfo = SeqIMSI

            'flgNew = True
            'UpdateSampleInfos()
            'flgNew = False


            sequence.SaveSequence(FilePath)
        End If

        'UpdateSampleInfos()

        'UpdateDisp(sequence.SequenceInfo)
    End Sub

    Private Sub btnDeleteSeqFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteSeqFile.Click
        sequenceList.Del(nSeqListIndex)

        UpdateCommonInfos()

        UpdateSeqMgrList()

        ucDataGridSeqEditor.ClearRow()

        If nSeqListIndex - 1 > 0 Then
            ucListSeqManager.SetSelectedRowNumber(nSeqListIndex - 1)
        End If


    End Sub

#End Region


#Region "Sequence Editor Functions"
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        sequence.DelTestRecipe(m_nSeqEditIndex)

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        sequence.ClearTestRecipe()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        btnUp.Enabled = False
        If sequence.RecipeUP(m_nSeqEditIndex) = False Then
            MsgBox("Can not move.")
        End If
        btnUp.Enabled = True
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        btnDown.Enabled = False
        If sequence.RecipeDown(m_nSeqEditIndex) = False Then
            MsgBox("can not move.")
        End If
        btnDown.Enabled = True
    End Sub

    Private Sub dispListSeqManager_evSelectedIndexChanged(ByVal nRow As Integer) Handles ucListSeqManager.evSelectedIndexChanged

        If nRow < 0 Then Exit Sub

        ucListSeqManager.Enabled = False

        nSeqListIndex = nRow

        UpdateCommonInfos()

        ucDataGridSeqEditor.ClearRow()
        UpdateSeqEditList(sequence.SequenceInfo)

        ucListSeqManager.Enabled = True
    End Sub

    Private Sub dispDataGridSeqEditor_evCellLineInfo(ByVal nColumn As Integer, ByVal nRow As Integer) Handles ucDataGridSeqEditor.evCellLineInfo
       If nRow < 0 Then Exit Sub

        m_nSeqEditIndex = nRow - 1

        If m_nSeqEditIndex < 0 Then
            m_nSeqEditIndex = -1
            Exit Sub
        End If

        UpdateRecipeInfos(m_nSeqEditIndex)

    End Sub

    Private Sub UpdateRecipeInfos(ByVal selectedRcpIdx As Integer)

        If sequence Is Nothing Then Exit Sub
        If sequence.SequenceInfo.sRecipes Is Nothing Then Exit Sub
        If sequence.SequenceInfo.sRecipes.Length <= selectedRcpIdx Then
            ucDispCommon.Settings = sequence.SequenceInfo.sSampleInfos
            ucDispCommon.CommonSettings = sequence.SequenceInfo.sCommon
            Exit Sub
        End If

        If selectedRcpIdx < 0 Then Exit Sub

        ucDataGridSeqEditor.Enabled = False

        ucDispCommon.Settings = sequence.SequenceInfo.sSampleInfos
        ucDispCommon.CommonSettings = sequence.SequenceInfo.sCommon

        'Sample 정보는 모두 업데이트 해야함.
        ucDispLifetime.SampleInfos = sequence.SequenceInfo.sSampleInfos
        ucDispAging.SampleInfos = sequence.SequenceInfo.sSampleInfos
        ucDispImageSticking.SampleInfos = sequence.SequenceInfo.sSampleInfos

        Select Case sequence.SequenceInfo.sRecipes(selectedRcpIdx).nMode
            '============================LifeTime===================================
            Case eRcpMode.eCell_Lifetime, eRcpMode.ePanel_Lifetime, eRcpMode.eModule_Lifetime

                ucDispLifetime.LifetimeRecipe = sequence.SequenceInfo.sRecipes(selectedRcpIdx).sLifetimeInfo

                If sequence.SequenceInfo.sRecipes(selectedRcpIdx).nMode = eRcpMode.eCell_Lifetime Then
                    ucDispLifetime.VisibleMode = eRcpMode.eCell_Lifetime
                ElseIf sequence.SequenceInfo.sRecipes(selectedRcpIdx).nMode = eRcpMode.ePanel_Lifetime Then
                    ucDispLifetime.VisibleMode = eRcpMode.ePanel_Lifetime
                Else
                    ucDispLifetime.VisibleMode = eRcpMode.eModule_Lifetime
                End If

                rdoLifetime.Checked = True

                '========================Image Sticking===============================
            Case eRcpMode.eModule_ImageSticking
                ucDispImageSticking.ucTestEndParam.Settings = sequence.SequenceInfo.sRecipes(selectedRcpIdx).sLifetimeInfo.sCommon.sLifetimeEnd
                ucDispImageSticking.ucRefPDSetting.Setting = sequence.SequenceInfo.sRecipes(selectedRcpIdx).sLifetimeInfo.sCommon.sSetInfosTheRefPD
                ucDispImageSticking.ucMeasureIntervalSetting.Setting = sequence.SequenceInfo.sRecipes(selectedRcpIdx).sLifetimeInfo.sCommon.sMeasureInterval
                If sequence.SequenceInfo.sRecipes(selectedRcpIdx).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Keeping Then
                    ucDispImageSticking.rbNoStress.Checked = True
                Else
                    ucDispImageSticking.rbStress.Checked = True
                End If

                If sequence.SequenceInfo.sRecipes(selectedRcpIdx).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = True Then
                    ucDispImageSticking.rbLifeTimeEndBiasON.Checked = True
                Else
                    ucDispImageSticking.rbLifeTimeEndBiasOFF.Checked = True
                End If

                ucDispImageSticking.ucDispModule.Settings = sequence.SequenceInfo.sRecipes(selectedRcpIdx).sLifetimeInfo.sModuleInfos

                ucDispImageSticking.Visible = True
                rdoImageSticking.Checked = True

                '========================IVL===============================
            Case eRcpMode.eCell_IVL, eRcpMode.ePanel_IVL, eRcpMode.eModuel_IVL
                ucDispIVLSweep.SampleInfos = sequence.SequenceInfo.sSampleInfos
                ucDispIVLSweep.IVLRecipe = sequence.SequenceInfo.sRecipes(selectedRcpIdx).sIVLSweepInfo

                Select Case sequence.SequenceInfo.sRecipes(selectedRcpIdx).nMode
                    Case eRcpMode.eCell_IVL
                        ucDispIVLSweep.VisibleMode = eRcpMode.eCell_IVL
                    Case eRcpMode.ePanel_IVL
                        'ucDispIVLSweep.ucDispSignalGenerator.Settings = sequence.SequenceInfo.sRecipes(selectedRcpIdx).sIVLSweepInfo.sSignalGeneratorInfos
                        'ucDispIVLSweep.VisibleMode = eRcpMode.ePanel_IVL
                    Case eRcpMode.eModuel_IVL
                        ucDispIVLSweep.VisibleMode = eRcpMode.eModuel_IVL
                End Select
                rdoIVL.Checked = True


            Case eRcpMode.eCell_LifetimeAndIVL
                ucDispLifetimeAndIVL.LifetimeRecipe = sequence.SequenceInfo.sRecipes(selectedRcpIdx).sLifetimeInfo
                ucDispLifetimeAndIVL.IVLRecipe = sequence.SequenceInfo.sRecipes(selectedRcpIdx).sIVLSweepInfo

                ucDispLifetimeAndIVL.VisibleMode = eRcpMode.eCell_LifetimeAndIVL
                ucDispLifetimeAndIVL.SampleInfos = sequence.SequenceInfo.sSampleInfos

                rdoLifetimeAndIVL.Checked = True

                '========================Change Temperature===============================
            Case eRcpMode.eChangeTemperature
                ucDispChangeTemp.TartgetTemp = sequence.SequenceInfo.sRecipes(selectedRcpIdx).sChangeTemp.dTargetTemp
                ucDispChangeTemp.StableTime = sequence.SequenceInfo.sRecipes(selectedRcpIdx).sChangeTemp.StableTime.nSecound
                ucDispChangeTemp.Visible = True
                rdoChangeTemp.Checked = True

                '========================Module Gray Scale Sweep===============================
            Case eRcpMode.eModule_GrayScaleSweep
                ucDispGrayScaleSweep.SampleInfos = sequence.SequenceInfo.sSampleInfos
                ucDispGrayScaleSweep.GraySweepRecipe = sequence.SequenceInfo.sRecipes(selectedRcpIdx).sGrayScaleSweepInfo
                ucDispGrayScaleSweep.Visible = True
                rdoGrayScaleSweep.Checked = True

                '========================Viewing Angle===============================
            Case eRcpMode.eViewingAngle
                ucDispViewingAngle.ViewingAngleRecipe = sequence.SequenceInfo.sRecipes(selectedRcpIdx).sViewingAngleInfo
                ucDispViewingAngle.Visible = True
                rdoViewingAngle.Checked = True
                '==============================================================
            Case eRcpMode.eCell_Aging
                '여기에 Aging 설정값들 넣음
                ucDispAging.AgingRecipe = sequence.SequenceInfo.sRecipes(selectedRcpIdx).sLifetimeInfo
                ucDispAging.VisibleMode = eRcpMode.eCell_Aging
                rdoAging.Checked = True
        End Select

        ucDataGridSeqEditor.Enabled = True

    End Sub

    Private Sub UpdateRecipeInfos()
        ucDispCommon.Settings = sequence.SequenceInfo.sSampleInfos
        ucDispCommon.CommonSettings = sequence.SequenceInfo.sCommon

        'Sample 정보는 모두 업데이트 해야함.
        ucDispLifetime.SampleInfos = sequence.SequenceInfo.sSampleInfos
        ucDispLifetimeAndIVL.SampleInfos = sequence.SequenceInfo.sSampleInfos
        ucDispImageSticking.SampleInfos = sequence.SequenceInfo.sSampleInfos

        If sequence.SequenceInfo.sRecipes Is Nothing Then Exit Sub
        If sequence.SequenceInfo.sRecipes.Length <> 0 Then

            For idx As Integer = 0 To sequence.SequenceInfo.nCounter - 1

                'Index 오류 
                'If sequence.SequenceInfo.nCounter <= m_nSeqEditIndex Then
                '    m_nSeqEditIndex = 0
                'End If

                If sequence.SequenceInfo.sRecipes(idx).nMode = eRcpMode.eCell_Lifetime Then
                    'ucDispLifetime.ucTestEndParam.Settings = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sLifetimeEnd
                    'ucDispLifetime.ucRefPDSetting.Setting = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sSetInfosTheRefPD
                    'ucDispLifetime.ucMeasureIntervalSetting.Setting = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sMeasureInterval
                    'If sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCellInfos Is Nothing = False Then
                    '    ucDispLifetime.ucDispM6000(0).Settings = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCellInfos(0)
                    '    ucDispLifetime.ucDispM6000(1).Settings = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCellInfos(1)
                    '    ucDispLifetime.ucDispM6000(2).Settings = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCellInfos(2)
                    'End If

                    ucDispLifetime.LifetimeRecipe = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo

                    'If sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Keeping Then
                    '    ucDispLifetime.rbNoStress.Checked = True
                    'Else
                    '    ucDispLifetime.rbStress.Checked = True
                    'End If

                    'If sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = False Then
                    '    ucDispLifetime.rbLifeTimeEndBiasOFF.Checked = True
                    'Else
                    '    ucDispLifetime.rbLifeTimeEndBiasON.Checked = True
                    'End If


                ElseIf sequence.SequenceInfo.sRecipes(idx).nMode = eRcpMode.eModule_Lifetime Then
                    ucDispLifetimeAndIVL.LifetimeRecipe = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo

                ElseIf sequence.SequenceInfo.sRecipes(idx).nMode = eRcpMode.eModule_Lifetime Then

                    ucDispLifetime.ucTestEndParam.Settings = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sLifetimeEnd
                    ucDispLifetime.ucRefPDSetting.Setting = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sSetInfosTheRefPD
                    ucDispLifetime.ucMeasureIntervalSetting.Setting = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sMeasureInterval

                    ucDispLifetime.LifetimeRecipe = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo

                    ucDispLifetime.ucDispMcPG.Settings = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sModuleInfos

                    If sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Keeping Then
                        ucDispLifetime.rbNoStress.Checked = True
                    Else
                        ucDispLifetime.rbStress.Checked = True
                    End If

                    If sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = False Then
                        ucDispLifetime.rbLifeTimeEndBiasOFF.Checked = True
                    Else
                        ucDispLifetime.rbLifeTimeEndBiasON.Checked = True
                    End If

                ElseIf sequence.SequenceInfo.sRecipes(idx).nMode = eRcpMode.eModule_ImageSticking Then

                    ucDispImageSticking.ucTestEndParam.Settings = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sLifetimeEnd
                    ucDispImageSticking.ucRefPDSetting.Setting = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sSetInfosTheRefPD
                    ucDispImageSticking.ucMeasureIntervalSetting.Setting = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sMeasureInterval
                    ucDispImageSticking.ucDispModule.Settings = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sModuleInfos
                    ucDispImageSticking.ImageStickingRecipe = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo


                    If sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Keeping Then
                        ucDispImageSticking.rbNoStress.Checked = True
                    Else
                        ucDispImageSticking.rbStress.Checked = True
                    End If

                    If sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = False Then
                        ucDispImageSticking.rbLifeTimeEndBiasOFF.Checked = True
                    Else
                        ucDispImageSticking.rbLifeTimeEndBiasON.Checked = True
                    End If

                ElseIf sequence.SequenceInfo.sRecipes(idx).nMode = eRcpMode.ePanel_Lifetime Then
                    ucDispLifetime.ucTestEndParam.Settings = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sLifetimeEnd
                    ucDispLifetime.ucRefPDSetting.Setting = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sSetInfosTheRefPD
                    ucDispLifetime.ucMeasureIntervalSetting.Setting = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sMeasureInterval
                    ucDispLifetime.ucDispMcSG.Settings = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sPanelInfos
                    ucDispLifetime.ucDispMcPanelRGBWRotion.Settings = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sRGBWRotationInfos
                    ucDispLifetime.LifetimeRecipe = sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo

                    If sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Keeping Then
                        ucDispLifetime.rbNoStress.Checked = True
                    Else
                        ucDispLifetime.rbStress.Checked = True
                    End If

                    If sequence.SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput = False Then
                        ucDispLifetime.rbLifeTimeEndBiasOFF.Checked = True
                    Else
                        ucDispLifetime.rbLifeTimeEndBiasON.Checked = True
                    End If

                ElseIf sequence.SequenceInfo.sRecipes(idx).nMode = eRcpMode.eChangeTemperature Then
                    ucDispChangeTemp.TartgetTemp = sequence.SequenceInfo.sRecipes(idx).sChangeTemp.dTargetTemp
                    ucDispChangeTemp.StableTime = sequence.SequenceInfo.sRecipes(idx).sChangeTemp.StableTime.nSecound

                End If

                ' m_nSeqEditIndex = idx + 1
            Next
        End If

        '  m_nSeqEditIndex = 0
    End Sub

    Private Sub UpdateCommonInfos()

        If sequenceList.Counter = 0 Then
            ucListSeqManager.ClearAllData()
            Exit Sub
        End If

        If flgNew = True Then
            sequence.LoadSequence(Application.StartupPath & sequenceList.SequenceList(sequenceList.Counter - 1).sPath)
        Else
            Try
                If sequence.LoadSequence(Application.StartupPath & sequenceList.SequenceList(nSeqListIndex).sPath) = False Then

                End If
            Catch ex As Exception
                sequence.LoadSequence(Application.StartupPath & sequenceList.SequenceList(0).sPath)
            End Try

        End If

        'DisplayUpdate()
        'Sequence List에서 선택된 Sequence 정보를 UI에 디스플레이 하는 함수

        UpdateRecipeInfos(m_nSeqEditIndex) 'UpdateRecipeInfos()

        Dim seqList() As CSequenceListManager.SequenceListInfo
        Dim selectedSequence As CSequenceListManager.SequenceListInfo
        seqList = sequenceList.SequenceList.Clone
        Try
            selectedSequence = seqList(nSeqListIndex)
        Catch ex As Exception
            selectedSequence = seqList(0)
        End Try


        Select Case selectedSequence.nSampleType

            Case M7000.ucSampleInfos.eSampleType.eCell
                rdoIVL.Enabled = True
                rdoLifetime.Enabled = True
                rdoChangeTemp.Enabled = True
                rdoLifetimeAndIVL.Enabled = True
                rdoAging.Enabled = True
                rdoGrayScaleSweep.Enabled = False
                rdoImageSweep.Enabled = False
                rdoImageSticking.Enabled = False
                ucDispLifetime.VisibleMode = eRcpMode.eCell_Lifetime
                ucDispIVLSweep.VisibleMode = eRcpMode.eCell_IVL
                ucDispLifetimeAndIVL.VisibleMode = eRcpMode.eCell_LifetimeAndIVL
                ucDispAging.VisibleMode = eRcpMode.eCell_Aging

            Case M7000.ucSampleInfos.eSampleType.ePanel
                rdoIVL.Enabled = True
                rdoLifetime.Enabled = True
                rdoChangeTemp.Enabled = True
                rdoAging.Enabled = True
                rdoGrayScaleSweep.Enabled = False
                rdoImageSweep.Enabled = False
                rdoImageSticking.Enabled = False
                ucDispLifetime.VisibleMode = eRcpMode.ePanel_Lifetime
                ucDispIVLSweep.VisibleMode = eRcpMode.ePanel_IVL
            Case M7000.ucSampleInfos.eSampleType.eModule
                rdoIVL.Enabled = False
                rdoAging.Enabled = True
                rdoLifetime.Enabled = True
                rdoChangeTemp.Enabled = True
                rdoGrayScaleSweep.Enabled = True
                rdoImageSweep.Enabled = True
                rdoImageSticking.Enabled = True
                ucDispLifetime.VisibleMode = eRcpMode.eModule_Lifetime
        End Select

    End Sub

    ''' <summary>
    ''' Update the Sequence List Information
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateSeqMgrList()

        Dim seqList() As CSequenceListManager.SequenceListInfo
        ucListSeqManager.ClearAllData()
        If sequenceList.SequenceList Is Nothing Then Exit Sub
        seqList = sequenceList.SequenceList.Clone
        For i As Integer = 0 To sequenceList.Counter - 1
            Dim sData(1) As String
            sData(0) = seqList(i).sSequenceName
            sData(1) = seqList(i).sDescriptions

            ucListSeqManager.AddRowData_AutoCountListNo(sData)
        Next
    End Sub

    Private Function ConvertRcpToSumUpString(ByVal idx As Integer, ByVal seqInfo As CSequenceManager.sSequenceInfo) As String

        Dim MeasInterval As String = Nothing
        Dim MeasPoint As String = Nothing
        Dim BiasOutput As String = Nothing
        Dim RenewalMode As String = Nothing
        Dim SubStr As String = Nothing
        Dim ModeStr As String = Nothing
        Dim EndStr As String = Nothing

        With seqInfo.sRecipes(idx)

            If .sLifetimeInfo.sCommon.sLifetimeEnd Is Nothing = False Then
                For cnt As Integer = 0 To .sLifetimeInfo.sCommon.sLifetimeEnd.Length - 1
                    EndStr = EndStr & "TYPE: " & .sLifetimeInfo.sCommon.sLifetimeEnd(cnt).nTypeOfParam.ToString & " VAL :" & .sLifetimeInfo.sCommon.sLifetimeEnd(cnt).dValue.ToString & " "
                Next
            End If

            If .sLifetimeInfo.sCommon.sMeasPoints.MeasPoint Is Nothing = False Then
                MeasPoint = "Magin: " & .sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.X & "," & .sLifetimeInfo.sCommon.sMeasPoints.marginFromAlignMark.Y & " "

                For cnt As Integer = 0 To .sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                    MeasPoint = MeasPoint & "Point(" & cnt + 1 & "): " & .sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(cnt).X.ToString & "," & .sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(cnt).Y.ToString & " "
                Next
            End If

            If .sLifetimeInfo.sCommon.sMeasureInterval Is Nothing = False Then
                For cnt As Integer = 0 To .sLifetimeInfo.sCommon.sMeasureInterval.Length - 1
                    MeasInterval = MeasInterval & "Interval: " & .sLifetimeInfo.sCommon.sMeasureInterval(cnt).Interval.dHour.ToString & " Change: " & .sLifetimeInfo.sCommon.sMeasureInterval(cnt).Change.dHour.ToString & " "
                Next
            End If

            BiasOutput = "BiasOut: " & .sLifetimeInfo.sCommon.sEndStateInfos.bBiasOutput.ToString

            RenewalMode = "PD Renewal Mode: " & .sLifetimeInfo.sCommon.sSetInfosTheRefPD.eEnableRenewalMode.ToString & " Renewal Time: " & .sLifetimeInfo.sCommon.sSetInfosTheRefPD.RenewalTime.dMin.ToString

            '========================================================
            Select Case seqInfo.sRecipes(idx).nMode
                Case eRcpMode.eCell_IVL
                    ModeStr = .sIVLSweepInfo.sCommon.biasMode.ToString & "/" & .sIVLSweepInfo.sCommon.measItem.ToString & "/" & .sIVLSweepInfo.sCommon.dSweepList(0) & "~" & .sIVLSweepInfo.sCommon.dSweepList(.sIVLSweepInfo.sCommon.dSweepList.Length - 1) & _
                              "/" & "Limit : " & "Current = " & .sIVLSweepInfo.sCommon.dCurrentLimit

                    If .sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
                        ModeStr = ModeStr & "/" & "Limit : " & "Luminance = " & .sIVLSweepInfo.sCommon.dLMeasLimit & "/Luminance Correction = " & .sIVLSweepInfo.sCommon.dLumiCorrection & "%" & "/BiasInvert = " & .sIVLSweepInfo.sCommon.dBiasInvert
                    End If


                Case eRcpMode.eCell_Lifetime
                    If seqInfo.sRecipes(idx).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Keeping Then
                        ModeStr = "Mode: " & .sLifetimeInfo.sCommon.nMode.ToString
                    Else
                        ModeStr = "Mode: " & .sLifetimeInfo.sCommon.nMode.ToString
                        Dim str As String = ""
                        'For i As Integer = 0 To seqInfo.sRecipes(idx).sLifetimeInfo.sCellInfos.Length - 1
                        '    '20150324_PSK
                        '    If seqInfo.sRecipes(idx).sLifetimeInfo.sCellInfos(i).bEnable = True Then
                        '        If seqInfo.sRecipes(idx).sLifetimeInfo.sCellInfos(i).Mode = CDevM6000PLUS.eMode.eCC Or seqInfo.sRecipes(idx).sLifetimeInfo.sCellInfos(i).Mode = CDevM6000PLUS.eMode.eCV Then
                        '            str = str & " Bias" & Format(i + 1, "00") & ": " & .sLifetimeInfo.sCellInfos(i).dBias.ToString & " Mode" & Format(i + 1, "00") & ": " & .sLifetimeInfo.sCellInfos(i).Mode.ToString
                        '        Else
                        '            str = str & " Bias" & Format(i + 1, "00") & ": " & .sLifetimeInfo.sCellInfos(i).dBias.ToString & " Amplitude" & Format(i + 1, "00") & ": " & .sLifetimeInfo.sCellInfos(i).dAmplitude.ToString & " Mode: " & .sLifetimeInfo.sCellInfos(i).Mode.ToString
                        '        End If
                        '    End If

                        'Next
                        str = MeasInterval
                        ModeStr = ModeStr & " / " & str
                    End If

                Case eRcpMode.eCell_Aging
                    If seqInfo.sRecipes(idx).sLifetimeInfo.sCommon.nMode = ucDispRcpAging.eAgingMode.Keeping Then
                        ModeStr = "Aging Mode: " & .sLifetimeInfo.sCommon.nMode.ToString
                    Else
                        ModeStr = "Aging Mode: " & .sLifetimeInfo.sCommon.nMode.ToString
                        Dim str As String = ""
                        For i As Integer = 0 To seqInfo.sRecipes(idx).sLifetimeInfo.sCellInfos.Length - 1

                            If seqInfo.sRecipes(idx).sLifetimeInfo.sCellInfos(i).bEnable = True Then
                                If seqInfo.sRecipes(idx).sLifetimeInfo.sCellInfos(i).Mode = CDevM6000PLUS.eMode.eCC Or seqInfo.sRecipes(idx).sLifetimeInfo.sCellInfos(i).Mode = CDevM6000PLUS.eMode.eCV Then
                                    str = str & " Bias" & Format(i + 1, "00") & ": " & .sLifetimeInfo.sCellInfos(i).dBias.ToString & " Mode" & Format(i + 1, "00") & ": " & .sLifetimeInfo.sCellInfos(i).Mode.ToString
                                Else
                                    str = str & " Bias" & Format(i + 1, "00") & ": " & .sLifetimeInfo.sCellInfos(i).dBias.ToString & " Amplitude" & Format(i + 1, "00") & ": " & .sLifetimeInfo.sCellInfos(i).dAmplitude.ToString & " Mode: " & .sLifetimeInfo.sCellInfos(i).Mode.ToString
                                End If
                            End If

                        Next
                        ModeStr = ModeStr & str
                    End If

                Case eRcpMode.eCell_LifetimeAndIVL

                    ModeStr = "IVL Sweep : " & .sIVLSweepInfo.sCommon.biasMode.ToString & "/" & .sIVLSweepInfo.sCommon.measItem.ToString & "/" & .sIVLSweepInfo.sCommon.dSweepList(0) & "~" & .sIVLSweepInfo.sCommon.dSweepList(.sIVLSweepInfo.sCommon.dSweepList.Length - 1)

                    ModeStr = ModeStr & "  Lifetime : " & "Mode: " & .sLifetimeInfo.sCommon.nMode.ToString
                    Dim str As String = ""
                    For i As Integer = 0 To seqInfo.sRecipes(idx).sLifetimeInfo.sCellInfos.Length - 1
                        '20150324_PSK

                        If seqInfo.sRecipes(idx).sLifetimeInfo.sCellInfos(i).bEnable = True Then
                            If seqInfo.sRecipes(idx).sLifetimeInfo.sCellInfos(i).Mode = CDevM6000PLUS.eMode.eCC Or seqInfo.sRecipes(idx).sLifetimeInfo.sCellInfos(i).Mode = CDevM6000PLUS.eMode.eCV Then
                                str = str & " Bias" & Format(i + 1, "00") & ": " & .sLifetimeInfo.sCellInfos(i).dBias.ToString & " Mode" & Format(i + 1, "00") & ": " & .sLifetimeInfo.sCellInfos(i).Mode.ToString
                            Else
                                str = str & " Bias" & Format(i + 1, "00") & ": " & .sLifetimeInfo.sCellInfos(i).dBias.ToString & " Amplitude" & Format(i + 1, "00") & ": " & .sLifetimeInfo.sCellInfos(i).dAmplitude.ToString & " Mode: " & .sLifetimeInfo.sCellInfos(i).Mode.ToString
                            End If
                        End If

                    Next
                    ModeStr = ModeStr & str

                Case eRcpMode.eModuel_IVL

                Case eRcpMode.eModule_Lifetime
                    ModeStr = "Mode: " & .sLifetimeInfo.sCommon.nMode.ToString & " RegNum: " & .sLifetimeInfo.sModuleInfos.sReg.numOfReg.ToString & " ImgNum: " & .sLifetimeInfo.sModuleInfos.sImageInfos.numOfImage.ToString & " PwrNum: " & .sLifetimeInfo.sModuleInfos.sPwr.nPwrNO.Length.ToString

                Case eRcpMode.ePanel_IVL
                    ModeStr = "Mode: " & .sIVLSweepInfo.sCommon.biasMode.ToString & "/" & .sIVLSweepInfo.sCommon.measItem.ToString & "/" & .sIVLSweepInfo.sCommon.sweepLine.ToString & "/" & .sIVLSweepInfo.sCommon.dSweepList(0) & "~" & .sIVLSweepInfo.sCommon.dSweepList(.sIVLSweepInfo.sCommon.dSweepList.Length - 1)
                Case eRcpMode.ePanel_Lifetime
                    ModeStr = "Mode: " & .sLifetimeInfo.sCommon.nMode.ToString & " SignLen: " & .sLifetimeInfo.sPanelInfos.nLenSignal.ToString & " ParamLen: " & .sLifetimeInfo.sPanelInfos.sParamData.Length.ToString & " Rotation: " & .sLifetimeInfo.sRGBWRotationInfos.bRotationUse.ToString

                Case eRcpMode.eChangeTemperature
                    ModeStr = "Temp: " & .sChangeTemp.dTargetTemp.ToString & "('C)" & " Time: " & .sChangeTemp.StableTime.dMin.ToString & "(Min)"

                Case eRcpMode.eModule_GrayScaleSweep
                    ModeStr = "SweepMode: " & .sGrayScaleSweepInfo.sSweepInfos.nSweepMode.ToString & "     PwrNum: " & .sGrayScaleSweepInfo.sModuleInfos.sPwr.nPwrNO.Length.ToString
                Case eRcpMode.eModule_ImageSticking
                    ModeStr = "Mode: " & .sLifetimeInfo.sCommon.nMode.ToString & " RegNum: " & .sLifetimeInfo.sModuleInfos.sReg.numOfReg.ToString & " ImgNum: " & .sLifetimeInfo.sModuleInfos.sImageInfos.numOfImage.ToString & " PwrNum: " & .sLifetimeInfo.sModuleInfos.sPwr.nPwrNO.Length.ToString
                Case eRcpMode.eViewingAngle
                    If .sViewingAngleInfo.sCommon.dSweepList Is Nothing Then
                        ModeStr = "point: Nothing"
                    Else
                        ModeStr = "point: " & CStr(.sViewingAngleInfo.sCommon.dSweepList.Length) & "/" & "Luminance Correction = " & .sViewingAngleInfo.sCommon.dLumiCorrection & "%"
                    End If

                Case Else
                    ModeStr = "Undefined Recipe"
            End Select
            ''========================================================
            'If seqInfo.sRecipes(idx).nMode = eRcpMode.eCell_IVL Then

            'ElseIf seqInfo.sRecipes(idx).nMode = eRcpMode.eCell_Lifetime Then
            '    If seqInfo.sRecipes(idx).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Keeping Then
            '        ModeStr = "Mode: " & .sLifetimeInfo.sCommon.nMode.ToString
            '    Else
            '        If seqInfo.sRecipes(idx).sLifetimeInfo.sCellInfos.Mode = CDevM6000.eMode.eCC Or seqInfo.sRecipes(idx).sLifetimeInfo.sCellInfos.Mode = CDevM6000.eMode.eCV Then
            '            ModeStr = "Mode: " & .sLifetimeInfo.sCommon.nMode.ToString & " Bias: " & .sLifetimeInfo.sCellInfos.dBias.ToString & " Mode: " & .sLifetimeInfo.sCellInfos.Mode.ToString
            '        Else
            '            ModeStr = "Mode: " & .sLifetimeInfo.sCommon.nMode.ToString & " Bias: " & .sLifetimeInfo.sCellInfos.dBias.ToString & " Amplitude: " & .sLifetimeInfo.sCellInfos.dAmplitude.ToString & " Mode: " & .sLifetimeInfo.sCellInfos.Mode.ToString
            '        End If
            '    End If

            'ElseIf seqInfo.sRecipes(idx).nMode = eRcpMode.eModuel_IVL Then

            'ElseIf seqInfo.sRecipes(idx).nMode = eRcpMode.eModule_Lifetime Then
            '    ModeStr = "Mode: " & .sLifetimeInfo.sCommon.nMode.ToString & " RegNum: " & .sLifetimeInfo.sModuleInfos.sReg.numOfReg.ToString & " ImgNum: " & .sLifetimeInfo.sModuleInfos.sImageInfos.numOfImage.ToString & " PwrNum: " & .sLifetimeInfo.sModuleInfos.sPwr.nPwrNO.Length.ToString

            'ElseIf seqInfo.sRecipes(idx).nMode = eRcpMode.ePanel_IVL Then

            'ElseIf seqInfo.sRecipes(idx).nMode = eRcpMode.ePanel_Lifetime Then
            '    ModeStr = "Mode: " & .sLifetimeInfo.sCommon.nMode.ToString & " SignLen: " & .sLifetimeInfo.sPanelInfos.nLenSignal.ToString & " ParamLen: " & .sLifetimeInfo.sPanelInfos.sParamData.Length.ToString

            'ElseIf seqInfo.sRecipes(idx).nMode = eRcpMode.eChangeTemperature Then
            '    ModeStr = "Temp: " & .sChangeTemp.dTargetTemp.ToString & " Time: " & .sChangeTemp.StableTime.nSecound.ToString
            'ElseIf seqInfo.sRecipes(idx).nMode = eRcpMode.eModule_PatternMeasure Then
            '    ModeStr = "Mode: Pattern Measurement" & " Pattern Type: " & .sPatternMeasure.sModuleInfos.sReg.ePattern.ToString

            'End If
            ''=================================================
            'dispDataGridSeqEditor_evCellLineInfo(0, m_nSeqEditIndex)

            Return ModeStr

        End With

    End Function

    Private Sub UpdateSeqEditList(ByVal sequenceInfo As CSequenceManager.sSequenceInfo)
        ucDataGridSeqEditor.EnableEvent = False

        Dim sLineData(1) As String
        Dim sData(sequenceInfo.nCounter)() As String

        With sequenceInfo

            'Common=========================================================
            sLineData(0) = "CommonInfos"

            Dim sTemp1 As String = ""
            'If .sCommon.sLimits Is Nothing = False Then
            '    For i As Integer = 0 To .sCommon.sLimits.Length - 1
            '        sTemp1 = sTemp1 & "Limit : " & .sCommon.sLimits(i).eTypeOfValue.ToString & " = " & CStr(.sCommon.sLimits(i).LimitValue.dMin) & "~" & CStr(.sCommon.sLimits(i).LimitValue.dMax) & " "
            '    Next
            'End If

            Dim sTemp2 As String = ""
            If .sCommon.sSequenceEnd Is Nothing = False Then
                For i As Integer = 0 To .sCommon.sSequenceEnd.Length - 1
                    sTemp2 = sTemp2 & .sCommon.sSequenceEnd(i).nTypeOfParam.ToString & "=" & .sCommon.sSequenceEnd(i).dValue
                Next
            End If
            sLineData(1) = .sSampleInfos.sampleType.ToString & "/" & .sSampleInfos.SampleSize.Width & "*" & .sSampleInfos.SampleSize.Height & "/" & _
                             CStr(.sCommon.dDefaultTemp) & "/" & sTemp1 & "/" & sTemp2

            'ucDataGridSeqEditor.AddRowData(sData)
            sData(0) = sLineData.Clone

            'Recipe===========================================================
            For i As Integer = 0 To sequenceInfo.nCounter - 1

                sLineData(0) = sequenceInfo.sRecipes(i).nMode.ToString

                sLineData(1) = ConvertRcpToSumUpString(i, sequenceInfo)

                'sData(1) = "설정 요약 출력"
                sData(i + 1) = sLineData.Clone
                ' ucDataGridSeqEditor.AddRowData(sLineData)
            Next

        End With

        'Update Display(Sequence Edit List)
        If sData.Length >= ucDataGridSeqEditor.RowCount Then  '표시할 데이터 라인이 현재 Edit List보다 많거나 같을 경우
            For line As Integer = 0 To sData.Length - 1
                If ucDataGridSeqEditor.RowCount > line Then
                    ucDataGridSeqEditor.SetRowData(line, sData(line))
                Else
                    ucDataGridSeqEditor.AddRowData(sData(line))
                End If
            Next
        Else  '표시할 데이터 라인이 이미 Edit List에 표시되어 있는 라인수 보다 적은 경우(when delete recipe)

            For row As Integer = ucDataGridSeqEditor.RowCount - 1 To 0 Step -1
                If sData.Length - 1 >= row Then
                    ucDataGridSeqEditor.SetRowData(row, sData(row))
                Else
                    ucDataGridSeqEditor.DeleteSelectedRow(row)
                End If
            Next

            m_nSeqEditIndex = sData.Length - 2  'update index of sequence Edit List
        End If
        

        ucDataGridSeqEditor.EnableEvent = True
        '  ucDataGridSeqEditor.SelectedRowNum = nSeqEditIndex

    End Sub

#End Region


#Region "Select Recipe"

    Private Sub rdoLifetimeAndIVL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoLifetimeAndIVL.CheckedChanged
        If sequence Is Nothing Then Exit Sub

        ucDispLifetimeAndIVL.SampleInfos = sequence.SequenceInfo.sSampleInfos

        ucDispLifetimeAndIVL.VisibleMode = eRcpMode.eCell_LifetimeAndIVL

        pnSettings.Controls.Clear()
        pnSettings.Controls.Add(ucDispLifetimeAndIVL)
        SetUISizeInfos()
    End Sub

    Private Sub rdoIVL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoIVL.CheckedChanged
        If sequence Is Nothing Then Exit Sub

        ucDispIVLSweep.SampleInfos = sequence.SequenceInfo.sSampleInfos

        Select Case sequence.SequenceInfo.sSampleInfos.sampleType

            Case M7000.ucSampleInfos.eSampleType.eCell
                ucDispIVLSweep.VisibleMode = eRcpMode.eCell_IVL
            Case M7000.ucSampleInfos.eSampleType.ePanel
                ucDispIVLSweep.VisibleMode = eRcpMode.ePanel_IVL
                '   Case M7000.ucDispRcpCommon.eSampleType.eModule
                '    ucDispIVLSweep.VisibleMode = eRcpMode.eModule_Lifetime
        End Select

        pnSettings.Controls.Clear()
        pnSettings.Controls.Add(ucDispIVLSweep)

        SetUISizeInfos()
    End Sub

    Private Sub rdoLifetime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoLifetime.CheckedChanged

        If sequence Is Nothing Then Exit Sub

        ucDispLifetime.SampleInfos = sequence.SequenceInfo.sSampleInfos

        Select Case sequence.SequenceInfo.sSampleInfos.sampleType

            Case M7000.ucSampleInfos.eSampleType.eCell
                ucDispLifetime.VisibleMode = eRcpMode.eCell_Lifetime
            Case M7000.ucSampleInfos.eSampleType.ePanel
                ucDispLifetime.VisibleMode = eRcpMode.ePanel_Lifetime
            Case M7000.ucSampleInfos.eSampleType.eModule
                ucDispLifetime.VisibleMode = eRcpMode.eModule_Lifetime
        End Select

        pnSettings.Controls.Clear()
        pnSettings.Controls.Add(ucDispLifetime)
        SetUISizeInfos()
    End Sub

    Private Sub rdoChangeTemp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoChangeTemp.CheckedChanged

        pnSettings.Controls.Clear()
        pnSettings.Controls.Add(ucDispChangeTemp)
        SetUISizeInfos()
    End Sub

    Private Sub rdoGrayScaleSweep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoGrayScaleSweep.CheckedChanged

        pnSettings.Controls.Clear()
        pnSettings.Controls.Add(ucDispGrayScaleSweep)
        ucDispGrayScaleSweep.SampleInfos = sequence.SequenceInfo.sSampleInfos
        ucDispGrayScaleSweep.ucDispModule.ucPGImageSweep.Visible = False
        SetUISizeInfos()
      
    End Sub

    Private Sub rdoImageSweep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoImageSweep.CheckedChanged

        pnSettings.Controls.Clear()
        pnSettings.Controls.Add(ucDispImageSweep)
        ucDispGrayScaleSweep.ucDispModule.ucPGImageSweep.Visible = True
        SetUISizeInfos()

    End Sub

    Private Sub rdoImageSticking_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoImageSticking.CheckedChanged
        If sequence Is Nothing Then Exit Sub

        pnSettings.Controls.Clear()
        pnSettings.Controls.Add(ucDispImageSticking)

        ucDispImageSticking.SampleInfos = sequence.SequenceInfo.sSampleInfos

        SetUISizeInfos()
        'ucDispImageSticking.Visible = True
        'ucDispLifetime.Visible = False
        'ucDispIVLSweep.Visible = False
        'ucDispImageSweep.Visible = False
        'ucDispChangeTemp.Visible = False
        'ucDispViewingAngle.Visible = False
    End Sub

    Private Sub rdoViewingAngle_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoViewingAngle.CheckedChanged

        pnSettings.Controls.Clear()
        pnSettings.Controls.Add(ucDispViewingAngle)

        SetUISizeInfos()

        'ucDispLifetime.Visible = False
        'ucDispIVLSweep.Visible = False
        'ucDispImageSweep.Visible = False
        'ucDispChangeTemp.Visible = False
        'ucDispGrayScaleSweep.Visible = False
        'ucDispGrayScaleSweep.ucDispModule.ucPGImageSweep.Visible = False
        'ucDispImageSticking.Visible = False
        'ucDispViewingAngle.Visible = True
    End Sub

#End Region

    Private Sub sequence_evChangedSequenceInfo(ByVal sequenceInfo As CSequenceManager.sSequenceInfo) Handles sequence.evChangedSequenceInfo
        sequence.SaveSequence(Application.StartupPath & sequenceList.SequenceList(nSeqListIndex).sPath)

        UpdateCommonInfos()

        UpdateSeqEditList(sequenceInfo)
    End Sub

#Region "Gray Scale Sweep Recipe Evnet Functions"
    Private Sub ucDispGrayScaleSweep_evADDGraySweepRcp(ByVal infos As sRcpGrayScaleSweep) Handles ucDispGrayScaleSweep.evADDGraySweepRcp
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing
        Dim graysweepRcp As ucSequenceBuilder.sRcpGrayScaleSweep

        graysweepRcp = ucDispGrayScaleSweep.GraySweepRecipe
        recipe.nMode = graysweepRcp.nMyMode
        recipe.sGrayScaleSweepInfo = graysweepRcp

        sequence.AddTestReciep(recipe)
    End Sub

    Private Sub ucDispGrayScaleSweep_evUpdateGraySweepRcp(ByVal infos As sRcpGrayScaleSweep) Handles ucDispGrayScaleSweep.evUpdateGraySweepRcp
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing

        recipe.nMode = infos.nMyMode
        recipe.sGrayScaleSweepInfo = infos

        sequence.UpdateTestRecipe(m_nSeqEditIndex, recipe)
    End Sub
#End Region

#Region "Image Sweep Recipe Evnet Functions"

    'Image Sweep Recipe Event Functions
    Private Sub ucDispImageSweep_evADDImageSweepRcp() Handles ucDispImageSweep.evADDImageSweepRcp

        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing
        recipe.nMode = eRcpMode.eModule_ImageSweep
        recipe.sImageSweepInfo = ucDispImageSweep.Settings()
        sequence.AddTestReciep(recipe)

    End Sub

    Private Sub ucDispImageSweep_evUpdateImageSweepRcp() Handles ucDispImageSweep.evUpdateImageSweepRcp

    End Sub

#End Region

#Region "Temperature Changing Recipe Event Functions"

    Private Sub ucDispChangeTemp_evTempAdd(ByVal TargetTbbemp As Double, ByVal DevTemp As Double) Handles ucDispChangeTemp.evTempAdd

        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing
        recipe.nMode = eRcpMode.eChangeTemperature
        recipe.sChangeTemp.dTargetTemp = ucDispChangeTemp.TartgetTemp
        recipe.sChangeTemp.StableTime = CTime.Convert_SecToTimeValue(ucDispChangeTemp.StableTime)
        sequence.AddTestReciep(recipe)
    End Sub

    Private Sub ucDispChangeTemp_evTempUPdate(ByVal Temp As Double, ByVal Time As Double) Handles ucDispChangeTemp.evTempUPdate
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing
        recipe.nMode = eRcpMode.eChangeTemperature
        recipe.sChangeTemp.dTargetTemp = ucDispChangeTemp.TartgetTemp
        recipe.sChangeTemp.StableTime = CTime.Convert_SecToTimeValue(ucDispChangeTemp.StableTime)

        If sequence.SequenceInfo.sRecipes Is Nothing Or sequence.SequenceInfo.sRecipes.Length = 0 Then
            If MsgBox("Can not update because there is no registered Recipe information. Would you like to register with Recipe?", MsgBoxStyle.OkCancel, g_strMainTitle) = MsgBoxResult.Ok Then
                sequence.AddTestReciep(recipe)
                Exit Sub
            Else
                Exit Sub
            End If
        End If

        If m_nSeqEditIndex < 0 Then
            MsgBox("Recipe selection is invalid.(CommonInfos Selected)")
            Exit Sub
        End If

        sequence.UpdateTestRecipe(m_nSeqEditIndex, recipe)
    End Sub

    Private Function ChkCommonInfos() As Boolean
        Dim nCnt As Integer
        Dim sListData() As String = Nothing

        For i As Integer = 0 To ucListSeqManager.GetListItemCount - 1
            ucListSeqManager.GetRowData(i, sListData)
            If sListData(0) = ucDispCommon.Settings.sTitle Then
                nCnt += 1
            End If
        Next

        If nCnt > 0 Then
            MsgBox("A file with the same name exists.")
            Return False
        End If

        Return True
    End Function


    Private Sub ucDipsRcpCommon_evUpdate() Handles ucDispCommon.evUpdate
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing

        'Dim sSampleInfos As ucDispRcpCommon.sSampleInfos

        Dim seqListInfo As CSequenceListManager.SequenceListInfo = sequenceList.SequenceList(nSeqListIndex)

        seqListInfo.nSampleType = ucDispCommon.Settings.sampleType
        seqListInfo.sDescriptions = ucDispCommon.Settings.sComment

        'sequence title이 sequence file name 이므로
        'sequence title이 수정되면, 이전 파일을 삭제하고 새로운 파일명으로 생성해야 함.
        If seqListInfo.sSequenceName <> ucDispCommon.Settings.sTitle Then
            seqListInfo.sSequenceName = ucDispCommon.Settings.sTitle

            If ChkCommonInfos() = False Then
                Exit Sub
            End If

            If File.Exists(Application.StartupPath & seqListInfo.sPath) = True Then
                File.Delete(Application.StartupPath & seqListInfo.sPath)
            End If

            seqListInfo.sPath = m_sPathSequenceFolder & "\" & seqListInfo.sSequenceName & ".seq"
        End If

        sequenceList.Update(nSeqListIndex, seqListInfo)

        'Display 갱신
        UpdateSeqMgrList()

        sequence.SetCommonSettings(ucDispCommon.CommonSettings, ucDispCommon.Settings)

        ' sequence.SaveSequence(sequenceList.SequenceList(nSeqListIndex).sPath)


    End Sub


#End Region


#Region "IVLSweep Recipe Event Functions"

    Public Shared Function CheckIVLSweepRcp(ByVal IVLSweepRcp As ucSequenceBuilder.sRcpIVLSweep) As Boolean

        Select Case IVLSweepRcp.nMyMode
            Case eRcpMode.eCell_IVL
                ' With IVLSweepRcp.sCommon
                '        If .nColorList Is Nothing Then MsgBox("Please Check The ColorList") : Return False
                '   If .nColorList.Length <= 0 Then MsgBox("Please Check The ColorList") : Return False
                ' End With

            Case eRcpMode.ePanel_IVL, eRcpMode.eModuel_IVL
                With IVLSweepRcp.sCommon.sMeasPoints
                    If .MeasPoint Is Nothing Then MsgBox("Please Check The MeasPoint") : Return False
                    If .MeasPoint.Length <= 0 Then MsgBox("Please Check The MeasPoint") : Return False
                End With


                Select Case IVLSweepRcp.nMyMode
                    Case eRcpMode.ePanel_IVL
                        With IVLSweepRcp.sSignalGeneratorInfos
                            If .sParamData Is Nothing Then MsgBox("Please Check The Register File") : Return False
                            If .sParamData.Length <= 0 Or .nLenSignal = 0 Then MsgBox("Please Check The Register File") : Return False
                        End With

                    Case eRcpMode.eModuel_IVL

                End Select
        End Select

        With IVLSweepRcp.sCommon
            If .dSweepList Is Nothing Then MsgBox("Please Check The SweepList") : Return False
            If .dSweepList.Length <= 0 Then MsgBox("Please Check The SweepList") : Return False
        End With

        Return True
    End Function

    Private Sub ucDispIVLSweep_evADDIVLSweepRcp(ByVal infos As sRcpIVLSweep) Handles ucDispIVLSweep.evADDIVLSweepRcp
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing
        Dim ivlsweepRcp As ucSequenceBuilder.sRcpIVLSweep

        ivlsweepRcp = ucDispIVLSweep.IVLRecipe

        If CheckIVLSweepRcp(ivlsweepRcp) = False Then
            Exit Sub
        End If

        recipe.nMode = ivlsweepRcp.nMyMode
        recipe.sIVLSweepInfo = ivlsweepRcp

        sequence.AddTestReciep(recipe)

    End Sub

    Private Sub ucDispIVLSweep_evUpdateIVLSweepRcp(ByVal infos As sRcpIVLSweep) Handles ucDispIVLSweep.evUpdateIVLSweepRcp
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing

        recipe.nMode = infos.nMyMode
        recipe.sIVLSweepInfo = infos

        If CheckIVLSweepRcp(recipe.sIVLSweepInfo) = False Then
            Exit Sub
        End If

        If sequence.SequenceInfo.sRecipes Is Nothing Or sequence.SequenceInfo.sRecipes.Length = 0 Then
            If MsgBox("Can not update because there is no registered Recipe information. Would you like to register with Recipe?", MsgBoxStyle.OkCancel, g_strMainTitle) = MsgBoxResult.Ok Then
                sequence.AddTestReciep(recipe)
                Exit Sub
            Else
                Exit Sub
            End If
        End If

        If m_nSeqEditIndex < 0 Then
            MsgBox("Recipe selection is invalid.(CommonInfos selected)")
            Exit Sub
        End If

        sequence.UpdateTestRecipe(m_nSeqEditIndex, recipe)
    End Sub

#Region "LifetimeAndIVL Recipe Event Functions"

    Private Sub ucDispLifetimeAndIVL_evADDLifetimeAndIVLSweepRcp(ByVal LifetimeInfos As sRcpLifetime, ByVal IVLInfos As sRcpIVLSweep) Handles ucDispLifetimeAndIVL.evADDLifetimeAndIVLSweepRcp
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing
        Dim lifetimeRcp As ucSequenceBuilder.sRcpLifetime
        Dim ivlsweepRcp As ucSequenceBuilder.sRcpIVLSweep

        ivlsweepRcp = ucDispLifetimeAndIVL.IVLRecipe
        lifetimeRcp = ucDispLifetimeAndIVL.LifetimeRecipe

        If CheckLifetimeAndIVLRcp(lifetimeRcp, ivlsweepRcp) = False Then
            Exit Sub
        End If

        recipe.nMode = LifetimeInfos.nMyMode
        recipe.sLifetimeInfo = lifetimeRcp
        recipe.sIVLSweepInfo = ivlsweepRcp

        sequence.AddTestReciep(recipe)

    End Sub

    Private Sub ucDispLifetimeAndIVL_evUpdateLifetimeAndIVLSweepRcp(ByVal LifetimeInfos As sRcpLifetime, ByVal IVLInfos As sRcpIVLSweep) Handles ucDispLifetimeAndIVL.evUpdateLifetimeAndIVLSweepRcp
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing

        recipe.nMode = LifetimeInfos.nMyMode
        recipe.sLifetimeInfo = LifetimeInfos
        recipe.sIVLSweepInfo = IVLInfos

        If CheckLifetimeAndIVLRcp(recipe.sLifetimeInfo, recipe.sIVLSweepInfo) = False Then
            Exit Sub
        End If

        If sequence.SequenceInfo.sRecipes Is Nothing Or sequence.SequenceInfo.sRecipes.Length = 0 Then
            If MsgBox("Can not update because there is no registered Recipe information. Would you like to register with Recipe?", MsgBoxStyle.OkCancel, g_strMainTitle) = MsgBoxResult.Ok Then
                sequence.AddTestReciep(recipe)
                Exit Sub
            Else
                Exit Sub
            End If
        End If

        If m_nSeqEditIndex < 0 Then
            MsgBox("Recipe selection is invalid. (CommonInfos selected)")
            Exit Sub
        End If

        sequence.UpdateTestRecipe(m_nSeqEditIndex, recipe)
    End Sub

    Public Shared Function CheckLifetimeAndIVLRcp(ByVal LifetimeRcp As ucSequenceBuilder.sRcpLifetime, ByVal IVLRcp As ucSequenceBuilder.sRcpIVLSweep) As Boolean
        Dim nCnt As Integer

        For i As Integer = 0 To LifetimeRcp.sCellInfos.Length - 1
            If LifetimeRcp.sCellInfos(i).bEnable = False Then
                nCnt += 1
            End If
        Next

        If nCnt = LifetimeRcp.sCellInfos.Length Then MsgBox("선택된 색상이 없습니다..1개 이상의 색상을 선택 하시고 Bias값을 입력하여 주십시오...") : Return False

        With LifetimeRcp.sCommon
            If .sMeasureInterval Is Nothing Then MsgBox("Please Check The MeasureInterval") : Return False
            If .sMeasureInterval.Length <= 0 Then MsgBox("Please Check The MeasureInterval") : Return False
            If .sLifetimeEnd Is Nothing Then MsgBox("Please Check The TestEnd") : Return False
            If .sLifetimeEnd.Length <= 0 Then MsgBox("Please Check The TestEnd") : Return False
            If .sIVLSweepMeas Is Nothing Then MsgBox("Please Check The IVL Sweep Meas") : Return False
            If .sIVLSweepMeas.Length <= 0 Then MsgBox("Please Check The TestEnd") : Return False

        End With

        With IVLRcp.sCommon
            If .dSweepList Is Nothing Then MsgBox("Please Check The SweepList") : Return False
            If .dSweepList.Length <= 0 Then MsgBox("Please Check The SweepList") : Return False
        End With

        Return True
    End Function

#End Region
   

#End Region

#Region "LIfetime Recipe Event Functions"


    Public Shared Function CheckLifetimeRcp(ByVal LifetimeRcp As ucSequenceBuilder.sRcpLifetime) As Boolean
        Dim nMeasImageCnt As Integer = 0
        Dim nSlideImageCnt As Integer = 0
        Dim nCnt As Integer

        Select Case LifetimeRcp.nMyMode
            Case eRcpMode.eCell_Lifetime
                With LifetimeRcp.sViewingAngleInfos
                    '   If LifetimeRcp.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation Then
                    '     If .dSweepList Is Nothing Then MsgBox("시야각 측정 각도를 설정하여 주십시오.") : Return False
                    '  If .dSweepList.Length <= 0 Then MsgBox("시야각 측정 각도를 설정하여 주십시오.") : Return False
                    '  End If

                    For i As Integer = 0 To LifetimeRcp.sCellInfos.Length - 1
                        If LifetimeRcp.sCellInfos(i).bEnable = False Then
                            nCnt += 1
                        End If
                    Next

                    If nCnt = LifetimeRcp.sCellInfos.Length Then MsgBox("Select one or more colors and enter the bias value.") : Return False
                End With


            Case eRcpMode.ePanel_Lifetime, eRcpMode.eModule_Lifetime
                With LifetimeRcp.sCommon.sMeasPoints
                    If .MeasPoint Is Nothing Then MsgBox("Please Check The MeasPoint") : Return False
                    If .MeasPoint.Length <= 0 Then MsgBox("Please Check The MeasPoint") : Return False
                End With

                Select Case LifetimeRcp.nMyMode
                    Case eRcpMode.ePanel_Lifetime
                        With LifetimeRcp.sPanelInfos
                            If .sParamData Is Nothing Then MsgBox("Please Check The Register File") : Return False
                            If .sParamData.Length <= 0 Then MsgBox("Please Check The Register File") : Return False
                            If .nLenSignal = 0 Then MsgBox("Please Check The Register File") : Return False
                        End With

                    Case eRcpMode.eModule_Lifetime
                        With LifetimeRcp.sModuleInfos
                            If .sInitCodeInfo.InitCodeData Is Nothing Then MsgBox("Please Check The InitCode") : Return False
                            If .sImageInfos.measImage Is Nothing Then MsgBox("Please Check The Measurement Image") : Return False
                            If .sImageInfos.SlideImage Is Nothing Then MsgBox("Please Check The Slide Image") : Return False
                        End With

                        For i As Integer = 0 To LifetimeRcp.sModuleInfos.sImageInfos.measImage.Length - 1
                            If LifetimeRcp.sModuleInfos.sImageInfos.measImage(i).bIsSelected = True Then
                                nMeasImageCnt += 1
                            End If
                        Next

                        For i As Integer = 0 To LifetimeRcp.sModuleInfos.sImageInfos.SlideImage.Length - 1
                            If LifetimeRcp.sModuleInfos.sImageInfos.SlideImage(i).bIsSelected = True Then
                                nSlideImageCnt += 1
                            End If
                        Next

                        If nMeasImageCnt = 0 Then MsgBox("Please Check The Measurement Image") : Return False
                        If nSlideImageCnt = 0 Then MsgBox("Please Check The Slide Image") : Return False

                End Select

        End Select

         With LifetimeRcp.sCommon
            If .sMeasureInterval Is Nothing Then MsgBox("Please Check The MeasureInterval") : Return False
            If .sMeasureInterval.Length <= 0 Then MsgBox("Please Check The MeasureInterval") : Return False
            If .sLifetimeEnd Is Nothing Then MsgBox("Please Check The TestEnd") : Return False
            If .sLifetimeEnd.Length <= 0 Then MsgBox("Please Check The TestEnd") : Return False
            Dim ChkRange As Integer
            ChkRange = .nIntegralWLCount

            '개수에 맞춰 체크 필요함
            Select Case ChkRange
                Case 1
                    If .nIntegralWL_Pick1_Start Mod 2 <> 0 Or .nIntegralWL_Pick1_Start < 380 Or .nIntegralWL_Pick1_Start > 780 Then
                        MsgBox("Interval1번의 Start 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If
                    If .nIntegralWL_Pick1_End Mod 2 <> 0 Or .nIntegralWL_Pick1_End < 380 Or .nIntegralWL_Pick1_End > 780 Then
                        MsgBox("Interval1번의 Stop 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If

                Case 2
                    If .nIntegralWL_Pick1_Start Mod 2 <> 0 Or .nIntegralWL_Pick1_Start < 380 Or .nIntegralWL_Pick1_Start > 780 Then
                        MsgBox("Interval1번의 Start 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If
                    If .nIntegralWL_Pick1_End Mod 2 <> 0 Or .nIntegralWL_Pick1_End < 380 Or .nIntegralWL_Pick1_End > 780 Then
                        MsgBox("Interval1번의 Stop 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If

                    If .nIntegralWL_Pick2_Start Mod 2 <> 0 Or .nIntegralWL_Pick2_Start < 380 Or .nIntegralWL_Pick2_Start > 780 Then
                        MsgBox("Interval2번의 Start 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If

                    If .nIntegralWL_Pick2_End Mod 2 <> 0 Or .nIntegralWL_Pick2_End < 380 Or .nIntegralWL_Pick2_End > 780 Then
                        MsgBox("Interval2번의 Stop 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If

                Case 3
                    If .nIntegralWL_Pick1_Start Mod 2 <> 0 Or .nIntegralWL_Pick1_Start < 380 Or .nIntegralWL_Pick1_Start > 780 Then
                        MsgBox("Interval1번의 Start 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If
                    If .nIntegralWL_Pick1_End Mod 2 <> 0 Or .nIntegralWL_Pick1_End < 380 Or .nIntegralWL_Pick1_End > 780 Then
                        MsgBox("Interval1번의 Stop 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If

                    If .nIntegralWL_Pick2_Start Mod 2 <> 0 Or .nIntegralWL_Pick2_Start < 380 Or .nIntegralWL_Pick2_Start > 780 Then
                        MsgBox("Interval2번의 Start 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If
                    If .nIntegralWL_Pick2_End Mod 2 <> 0 Or .nIntegralWL_Pick2_End < 380 Or .nIntegralWL_Pick2_End > 780 Then
                        MsgBox("Interval2번의 Stop 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If

                    If .nIntegralWL_Pick3_Start Mod 2 <> 0 Or .nIntegralWL_Pick3_Start < 380 Or .nIntegralWL_Pick3_Start > 780 Then
                        MsgBox("Interval3번의 Start 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If
                    If .nIntegralWL_Pick3_End Mod 2 <> 0 Or .nIntegralWL_Pick3_End < 380 Or .nIntegralWL_Pick3_End > 780 Then
                        MsgBox("Interval3번의 Stop 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If

                Case 4
                    If .nIntegralWL_Pick1_Start Mod 2 <> 0 Or .nIntegralWL_Pick1_Start < 380 Or .nIntegralWL_Pick1_Start > 780 Then
                        MsgBox("Interval1번의 Start 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If
                    If .nIntegralWL_Pick1_End Mod 2 <> 0 Or .nIntegralWL_Pick1_End < 380 Or .nIntegralWL_Pick1_End > 780 Then
                        MsgBox("Interval1번의 Stop 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If

                    If .nIntegralWL_Pick2_Start Mod 2 <> 0 Or .nIntegralWL_Pick2_Start < 380 Or .nIntegralWL_Pick2_Start > 780 Then
                        MsgBox("Interval2번의 Start 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If

                    If .nIntegralWL_Pick2_End Mod 2 <> 0 Or .nIntegralWL_Pick2_End < 380 Or .nIntegralWL_Pick2_End > 780 Then
                        MsgBox("Interval2번의 Stop 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If

                    If .nIntegralWL_Pick3_Start Mod 2 <> 0 Or .nIntegralWL_Pick3_Start < 380 Or .nIntegralWL_Pick3_Start > 780 Then
                        MsgBox("Interval3번의 Start 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If
                    If .nIntegralWL_Pick3_End Mod 2 <> 0 Or .nIntegralWL_Pick3_End < 380 Or .nIntegralWL_Pick3_End > 780 Then
                        MsgBox("Interval3번의 Stop 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If

                    If .nIntegralWL_Pick4_Start Mod 2 <> 0 Or .nIntegralWL_Pick4_Start < 380 Or .nIntegralWL_Pick4_Start > 780 Then
                        MsgBox("Interval4번의 Start 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If
                    If .nIntegralWL_Pick4_End Mod 2 <> 0 Or .nIntegralWL_Pick4_End < 380 Or .nIntegralWL_Pick4_End > 780 Then
                        MsgBox("Interval4번의 Stop 값 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
                        Return False
                    End If

            End Select
        End With


        Return True
    End Function
    Public Shared Function CheckAgingRcp(ByVal AgingRcp As ucSequenceBuilder.sRcpLifetime) As Boolean

        Select Case AgingRcp.nMyMode
            Case eRcpMode.eCell_Aging
                With AgingRcp.sCommon
                    If .sLifetimeEnd Is Nothing Then MsgBox("Please Check The TestEnd") : Return False
                    If .sLifetimeEnd.Length <= 0 Then MsgBox("Please Check The TestEnd") : Return False
                End With
        End Select

        Return True
    End Function

    Private Sub ucDispLifetime_evADDLifetimeRcp(ByVal infos As sRcpLifetime) Handles ucDispLifetime.evADDLifetimeRcp
        '에이징 예외처리하자.
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing
        Dim lifetimeRcp As ucSequenceBuilder.sRcpLifetime

        lifetimeRcp = ucDispLifetime.LifetimeRecipe

        If CheckLifetimeRcp(lifetimeRcp) = False Then
            Exit Sub
        End If
        recipe.nMode = lifetimeRcp.nMyMode
        recipe.sLifetimeInfo = lifetimeRcp


        sequence.AddTestReciep(recipe)
    End Sub

    Private Sub ucDispLifetime_evUpdateLifetimeRcp(ByVal infos As sRcpLifetime) Handles ucDispLifetime.evUpdateLifetimeRcp
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing
        Dim lifetimeRcp As ucSequenceBuilder.sRcpLifetime

        lifetimeRcp = infos 'ucDispLifetime.LifetimeRecipe
        recipe.nMode = lifetimeRcp.nMyMode
        recipe.sLifetimeInfo = lifetimeRcp

        If CheckLifetimeRcp(lifetimeRcp) = False Then
            Exit Sub
        End If

        If sequence.SequenceInfo.sRecipes Is Nothing Or sequence.SequenceInfo.sRecipes.Length = 0 Then
            If MsgBox("Can not update because there is no registered Recipe information. Would you like to register with Recipe?", MsgBoxStyle.OkCancel, g_strMainTitle) = MsgBoxResult.Ok Then
                sequence.AddTestReciep(recipe)
                Exit Sub
            Else
                Exit Sub
            End If
        End If

        If m_nSeqEditIndex < 0 Then
            MsgBox("Recipe selection is invalid. (CommonInfos selected)")
            Exit Sub
        End If

        sequence.UpdateTestRecipe(m_nSeqEditIndex, recipe)
    End Sub


#End Region

#Region "Image Sticking Recipe Event Functions"
    Private Sub ucDispImageSticking_evADDImageStickingRcp(ByVal infos As sRcpLifetime) Handles ucDispImageSticking.evADDImageStickingRcp
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing
        Dim ImagestickingRcp As ucSequenceBuilder.sRcpLifetime

        ImagestickingRcp = ucDispImageSticking.ImageStickingRecipe
        recipe.nMode = ImagestickingRcp.nMyMode
        recipe.sLifetimeInfo = ImagestickingRcp

        sequence.AddTestReciep(recipe)
    End Sub

    Private Sub ucDispImageSticking_evUpdateImageStickingRcp(ByVal infos As sRcpLifetime) Handles ucDispImageSticking.evUpdateImageStickingRcp
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing
        Dim ImagestickingRcp As ucSequenceBuilder.sRcpLifetime

        ImagestickingRcp = ucDispImageSticking.ImageStickingRecipe
        recipe.nMode = ImagestickingRcp.nMyMode
        recipe.sLifetimeInfo = ImagestickingRcp

        sequence.UpdateTestRecipe(m_nSeqEditIndex, recipe)
    End Sub
#End Region

#Region "Viewing Angle Recipe Event Functions"

    Private Sub ucDispViewingAngle_evADDViewingAngleRcp(ByVal infos As sRcpViewingAngleSweep) Handles ucDispViewingAngle.evADDViewingAngleRcp
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing
        Dim Rcp As ucSequenceBuilder.sRcpViewingAngleSweep

        Rcp = ucDispViewingAngle.ViewingAngleRecipe

        If CheckviewingAngleRcp(Rcp) = False Then
            Exit Sub
        End If

        recipe.nMode = Rcp.nMyMode
        recipe.sViewingAngleInfo = Rcp

        sequence.AddTestReciep(recipe)
    End Sub

    Private Sub ucDispViewingAngle_evUpdateViewingAngleRcp(ByVal infos As sRcpViewingAngleSweep) Handles ucDispViewingAngle.evUpdateViewingAngleRcp
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing
        Dim Rcp As ucSequenceBuilder.sRcpViewingAngleSweep

        Rcp = infos 'ucDispLifetime.LifetimeRecipe
        recipe.nMode = Rcp.nMyMode
        recipe.sViewingAngleInfo = Rcp

        If CheckViewingAngleRcp(Rcp) = False Then
            Exit Sub
        End If

        If sequence.SequenceInfo.sRecipes Is Nothing Or sequence.SequenceInfo.sRecipes.Length = 0 Then
            If MsgBox("Can not update because there is no registered Recipe information. Would you like to register with Recipe?", MsgBoxStyle.OkCancel, g_strMainTitle) = MsgBoxResult.Ok Then
                sequence.AddTestReciep(recipe)
                Exit Sub
            Else
                Exit Sub
            End If
        End If

        If m_nSeqEditIndex < 0 Then
            MsgBox("Recipe selection is invalid. (CommonInfos selected)")
            Exit Sub
        End If

        sequence.UpdateTestRecipe(m_nSeqEditIndex, recipe)
    End Sub


    Public Shared Function CheckViewingAngleRcp(ByVal viewingAngleRcp As ucSequenceBuilder.sRcpViewingAngleSweep) As Boolean

        Dim nCnt As Integer

        With viewingAngleRcp
            If .sCommon.dSweepList Is Nothing Then MsgBox("Set the measurement angle for Viewing angle.") : Return False
            If .sCommon.dSweepList.Length <= 0 Then MsgBox("Set the measurement angle for Viewing angle.") : Return False

            For i As Integer = 0 To .sCellInfos.Length - 1
                If .sCellInfos(i).bEnable = False Then
                    nCnt += 1
                End If
            Next

            If nCnt = .sCellInfos.Length Then MsgBox("Select one or more colors and enter the bias value.") : Return False
        End With

        Return True
    End Function

#End Region


    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim SettingsDlg As New frmBuilderSettings

        If SettingsDlg.ShowDialog = DialogResult.OK Then
            updateBuilderSetting()

        End If

    End Sub

  
    Private Sub ucSequenceBuilder_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged

        'FitUISize_SeqEdit()

    End Sub


    Private Sub FitUISize_SeqEdit()

        If m_bIsLoaded = False Then Exit Sub

        Dim parentSize As Size

        'parentSize = spcSequenceEditor.Panel1.ClientSize
        'gbSequenceEditor.Size = New System.Drawing.Size(parentSize)

        'parentSize = spcSequenceEditor.Panel2.ClientSize
        'ucDispCommon.Size = New System.Drawing.Size(parentSize)

        parentSize = spContainer.Panel1.ClientSize
        tlpSequenceList.Size = New System.Drawing.Size(parentSize.Width - tlpSequenceList.Margin.Left - tlpSequenceList.Margin.Right, parentSize.Height - tlpSequenceList.Margin.Top - tlpSequenceList.Margin.Bottom)

        'ucDispCommon.Size = New System.Drawing.Size(controlSize_Width, 380)  '369
        parentSize = spContainerEditor.Panel2.ClientSize
        tlpRcpEditor.Dock = DockStyle.Fill
        'tlpRcpEditor.Size = New System.Drawing.Size(parentSize.Width - tlpRcpEditor.Margin.Left - tlpRcpEditor.Margin.Right, parentSize.Height - tlpRcpEditor.Margin.Top - tlpRcpEditor.Margin.Bottom)
    End Sub

    Private Sub spContainerEditor_ClientSizeChanged(sender As Object, e As System.EventArgs) Handles spContainerEditor.ClientSizeChanged

    End Sub

    Private Sub spContainerEditor_SizeChanged(sender As Object, e As System.EventArgs) Handles spContainerEditor.SizeChanged

    End Sub

    Private Sub spContainerEditor_SplitterMoved(sender As Object, e As System.Windows.Forms.SplitterEventArgs) Handles spContainerEditor.SplitterMoved

        If m_bIsLoaded = False Then Exit Sub

        'Dim parentSize As Size

        'parentSize = spcSequenceEditor.Panel1.ClientSize
        'gbSequenceEditor.Size = New System.Drawing.Size(parentSize)

        'parentSize = spcSequenceEditor.Panel2.ClientSize
        'ucDispCommon.Size = New System.Drawing.Size(parentSize)
        '        FitUISize_SeqEdit()
    End Sub

    Private Sub spContainer_SplitterMoved(sender As Object, e As System.Windows.Forms.SplitterEventArgs) Handles spContainer.SplitterMoved
        ' FitUISize_SeqEdit()
    End Sub

    Private Sub rdoAging_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoAging.CheckedChanged
        pnSettings.Controls.Clear()
        pnSettings.Controls.Add(ucDispAging)

        SetUISizeInfos()
    End Sub

    Private Sub ucDispAging_evADDAgingRcp(infos As sRcpLifetime) Handles ucDispAging.evADDAgingRcp
        'Aging Recipe ADD
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing
        Dim AgingRcp As ucSequenceBuilder.sRcpLifetime

        AgingRcp = ucDispAging.AgingRecipe

        If CheckAgingRcp(AgingRcp) = False Then
            Exit Sub
        End If

        recipe.nMode = AgingRcp.nMyMode
        recipe.sLifetimeInfo = AgingRcp

        sequence.AddTestReciep(recipe)
    End Sub

    Private Sub ucDispAging_evUpdateAgingRcp(infos As sRcpLifetime) Handles ucDispAging.evUpdateAgingRcp
        'Aging Recipe Update
        Dim recipe As ucSequenceBuilder.sRecipeInfo = Nothing
        Dim AgingRcp As ucSequenceBuilder.sRcpLifetime

        AgingRcp = infos 'ucDispLifetime.LifetimeRecipe
        recipe.nMode = AgingRcp.nMyMode
        recipe.sLifetimeInfo = AgingRcp

        If CheckAgingRcp(AgingRcp) = False Then
            Exit Sub
        End If

        If sequence.SequenceInfo.sRecipes Is Nothing Or sequence.SequenceInfo.sRecipes.Length = 0 Then
            If MsgBox("Can not update because there is no registered Recipe information. Would you like to register with Recipe?", MsgBoxStyle.OkCancel, g_strMainTitle) = MsgBoxResult.Ok Then
                sequence.AddTestReciep(recipe)
                Exit Sub
            Else
                Exit Sub
            End If
        End If

        If m_nSeqEditIndex < 0 Then
            MsgBox("Recipe selection is invalid. (CommonInfos selected)")
            Exit Sub
        End If

        sequence.UpdateTestRecipe(m_nSeqEditIndex, recipe)
    End Sub
End Class
