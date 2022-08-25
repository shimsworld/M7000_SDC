Imports System.IO
Imports CSMULib
Imports CSpectrometerLib

Public Class frmOptionWindow

#Region "Define"
    Dim fMain As frmMain
    '  Public optData As sOPTIONDATa
    Dim sMode() As String = New String() {"CC", "CV", "PC", "PV", "PCV"}
    Public cSpectormeter() As CDevSpectrometerAPI
    Dim m_Option As sOPTIONDATa
    '   Public sysOptionini As String = New String(Application.StartupPath & "sysOption.ini")

    Dim m_sAttributes() As String

    Private Shared sIVLDataPlotItems() As String = New String() {"Empty(Row)", "Point", "Mode", "Area(cm^2)", "Temperature('C)", "Voltage(V)", "Current(mA)", "ABS Current(mA)", _
                                                                 "Luminance_Fill(Cd/m^2)", "Luminance(Cd/m^2)", "CIE1931 x", "CIE1931 y", _
                                                                 "CCT", "Current Efficiency(Cd/A)", "J(mA/cm^2)", "CIE1976 u'", "CIE1976 v'", _
                                                                 "Power Efficiency(lm/W)", "ABS Current Density(mA/cm^2)", "QE(%)", _
                                                                  "FWHM", "Angle(Deg)", "Duv", "X", "Y", "Z", "Le"}



    Private Shared sVADataPlotItems() As String = New String() {"Empty(Row)", "Point", "Mode", "Area(cm^2)", "Temperature('C)", "Voltage(V)", "Current(mA)", "Luminance_Fill(cd/m^2)", "Luminance(cd/m^2)", "CIE1931 x", "CIE1931 y", _
                                                     "CCT", "Current Efficiency(cd/A)", "J(mA/cm^2)", "CIE1976 u'", "CIE1976 v'", "Power Efficiency(lm/W)", "Abs J(mA/cm^2)", "QE(%)", _
                                                      "FWHM", "Delta_u'v'", "Angle(Deg)"}


    Private Shared sLTDataPlotItems() As String = New String() {"Empty(Row)", "Hour Pass(hrs)", "Time", "Area(cm^2)", "Temp('C)", "Voltage(V)", "Delta Voltage(V)", "Amplitude Voltage(V)", _
                                                     "Current(mA)", "Delta Current(mA)", "Current(%)", "Amplitude Current(mA)", "J(mA/cm^2)", "Luminance_Fill(cd/m^2)", "Luminance(cd/m^2)", "Power Efficiency(lm/W)", _
                                                   "Luminance(%)", "Current Efficiency(cd/A)", "Current Efficiency(%)", "QE(%)", "CIE_x", "CIE_y", "CIE_u'", "CIE_v'", "delta_u'v'", "CCT", "SpectrumSum(%)", "EL Max", "FWHM", "CH Num", "Luminance_Fill(%)"}

    Dim sFileType() As String = New String() {"CSV", "Excel"}

    Dim sSpeedMode() As String = New String() {"Auto", "Manual"}
    Dim sACFSoruceMode() As String = New String() {"CV", "CC"}
#End Region

#Region "Enum"
    Public Enum eApertureAngle
        e0R1
        e0R2
        e1
        e2
    End Enum

    Public Enum eMeasSpeed
        eNomal
        eHigh
    End Enum

    Public Enum eBlobFilter
        EXCLUDE_AREA_LESS_EQUAL_50
        EXCLUDE_AREA_OUT_RANGE_50_50000
        EXCLUDE_COMPACTNESS_LESS_EQUAL_1_5
        EXCLUDE_AREA_OUT_RANGE_1000_50000
    End Enum

    Dim sCaption_ACFModes() As String = New String() {"Disable(Fixed Position)", "Auto Centering"} ', "Auto Centering And Focusing"}

    Public Enum eACFMode
        eDisable_FixedPosition = 0
        eEnable_AutoCentering
        'eEnable_AutoCenteringAndFocusing
    End Enum

    Public Enum eIVLDataIndex
        eEmpty = 0
        eNo
        eMode
        eArea
        eTemperature
        eVoltage
        eCurrent
        eABSCurrent
        eLuminance_Fill
        eLuminance
        eCIEx
        eCIEy
        eCCT
        eCurrentEfficiency
        eJ
        eCIEu
        eCIEv
        ePowerEfficiency
        eAbsJ
        eQE
        eFWHM
        eViewingAngle
        eDuv
        eX
        eY
        eZ
        eLe
        'eBR_Red
        'eBR_Green
        'eBR_Blue
        'eBR_White
        'eLR_Red
        'eLR_Green
        'eLR_Blue
        'eLR_White
        'eIntegrationTime
        'eCRI
        'eELmaxIntensity
        'eELmax
        'eDuprimevprime
        'eTime
    End Enum

    Public Enum eVADataIndex
        eEmpty = 0
        eNo
        eMode
        eArea
        eTemperature
        eVoltage
        eCurrent
        eLuminance_Fill
        eLuminance
        eCIEx
        eCIEy
        eCCT
        eCurrentEfficiency
        eJ
        eCIEu
        eCIEv
        ePowerEfficiency
        eAbsJ
        eQE
        eFWHM
        eDeltauv
        eAngle
        eDuv
        eCRI
        eELmaxIntensity
        eELmax
        eDuprimevprime
        eTime
    End Enum

    Public Enum eLTDataIndex
        eEmpty = 0
        eHourPass = 1
        eTime
        eArea
        eTemp
        eVoltage
        eDeltaVoltage
        eAmplitudeVoltage
        eCurrent
        eDeltaCurrent
        eCurrent_Per
        eAmplitudeCurrent
        eCurrentDensity
        eLuminance_Fill_cdm2
        eLuminance_cdm2
        ePowerEfficiency
        eLuminanace_Per
        eCurrentEfficiency
        eCurrentEfficiency_Per
        eQE
        eCIEx
        eCIEy
        eCIEu
        eCIEv
        eDeltauv
        eCCT
        eSpectrumSum_Per
        eELMax
        eFHWM
        eCHNum
        eLuminance_Fill_Per
        eIntegWL1
        eIntegWL2
        eIntegWL3
        eIntegWL4
        eIntegWL_Photopic1
        eIntegWL_Photopic2
        eIntegWL_Photopic3
        eIntegWL_Photopic4
        eIntegWL1_Per
        eIntegWL2_Per
        eIntegWL3_Per
        eIntegWL4_Per
        eIntegWL_Photopic1_Per
        eIntegWL_Photopic2_Per
        eIntegWL_Photopic3_Per
        eIntegWL_Photopic4_Per
    End Enum

#End Region

#Region "Structure"
    '탭 단위로 구조체를 만듬.
    Public Structure sOPTIONDATa
        Dim ACFData As sACF
        Dim MotionData As sMotion
        Dim TemperatureData As sTemperature
        Dim Spectrometer As sSpectrometer
        Dim IVLSpectrometer As sSpectrometer
        '  Dim LifetimeAndIVLSpectrometer As sSpectrometer

        '  Dim SpectrometerData As sSpectrometer
        Dim CCDData As sCCD
        Dim SGData As sSignalGenerator
        Dim PGData As sPatternGenerator
        Dim PLC As sPLC
        Dim ParamRange As sParamRange
        Dim DispGroup As sOption_Disp
        Dim StateSetting As sStateSetting
        Dim bMDXOutData() As Boolean
        '  Dim CalData As sCalOption
        '  Dim ConsBright As sConstantBrightSetting
        Dim bEnableDataViewerLink_IVL As Boolean
        Dim sPathOfDataViewer_IVL As String
        Dim bEnableDataViewerLink_LT As Boolean
        Dim sPathOfDataViewer_LT As String
        Dim SaveOptions As sSaveOptions
        Dim SystemAdmin As sAdmin
        Dim SafetyAdmin As sAdmin
        Dim VisibleDisplay As sVisibleDisplay
        Dim SampleInfos As sSampleInfos
        Dim MaterialData As CDataQECal.sMaterial
        Dim sCheckContact As sContact
    End Structure

    Public Structure sContact
        Dim dContactBias As Double
        Dim dPassLevel As Double
        Dim dBiasMargin As Double
    End Structure

    Public Structure sVisibleDisplay
        Dim bChannelMoveButton As Boolean
        Dim bAngleMoveButton As Boolean
    End Structure

    Public Structure sSampleInfos
        Dim dHeight As Double
        Dim dWidth As Double
        Dim dFillFactor As Double
    End Structure

    Public Structure sAdmin
        Dim strPassword As String
        Dim bLogInStatus As Boolean
    End Structure

    Public Structure sACF

        Dim nACFMode As eACFMode
        Dim dACFRegion_Start As Double
        Dim dACFRegion_Stop As Double
        Dim dScanResolution As Double
        Dim nFocusParam As Integer

        'ACF --> ImageProcessingData
        Dim nDefThreshold As Integer
        Dim nLowThreshold As Integer
        Dim nHighThreshold As Integer
        Dim nCCDResolutionWidth As Integer
        Dim nCCDResolutionHigh As Integer
        Dim nCCDCenterPos_X As Integer
        Dim nCCDCenterPos_Y As Integer
        Dim eBlobFilter As eBlobFilter
        Dim nMinBlobRadius As Integer

        'ACF --> Distance Value (CCD to Spectrometer)
        Dim dCCDtoSpectrometerPosX As Double
        Dim dCCDtoSpectrometerPosY As Double
        Dim dCCDtoSpectrometerPosZ As Double
        Dim dCCDtoMCRPosX As Double
        Dim dCCDtoMCRPosY As Double
        Dim dCCDtoMCRPosZ As Double
        Dim dCCDtoHEXAPosX As Double
        Dim dCCDtoHEXAPosY As Double
        Dim dCCDtoHEXAPosZ As Double

        Dim dCCDPosX As Double
        Dim dCCDPosY As Double
        Dim dCCDPosZ As Double
        Dim dSpectrometerPosX As Double
        Dim dSpectrometerPosY As Double
        Dim dSpectrometerPosZ As Double
        Dim dMCRPosX As Double
        Dim dMCRPosY As Double
        Dim dMCRPosZ As Double
        Dim dHEXAPosX As Double
        Dim dHEXAPosY As Double
        Dim dHEXAPosZ As Double

        'ACF --> Filter
        Dim dLowIntensityLimit As Double
        Dim nGrayLevelLimit As Integer

        'ACF --> Param
        Dim dPixelPerDistance_1mm_Width As Double
        Dim dPixelPerDistance_1mm_High As Double
        Dim dDistanceOfOnePixel_X As Double
        Dim dDistanceOfOnePixel_Y As Double
        Dim sSoruceMode As ACFSourceMode
        Dim dIntensityAdj_Bias As Double
        Dim dIntensityAdj_Step As Double
        Dim dIntensityAdj_Limit As Double
        Dim sIntensityAdj_Settings As ucKeithleySMUSettings.sKeithley

        Dim nModulePatternNo As Integer
    End Structure

#Region "Motion Structure"
    Public Structure sMotion
        Dim sStartPos As sMotionAxis
        Dim sEndPos As sMotionAxis
        Dim sCalPos As sMotionAxis
        Dim sCalPosPerDistance As sMotionAxis
        Dim sStandardDistance As sMotionAxis
        Dim bCalPosPerDistanceUse As Boolean
        Dim sThetaCal As sThetaCalFactor
        Dim sWADCalFactor As sWADCalFactor
    End Structure
    Public Enum ACFSourceMode
        eCV = 0
        eCC
    End Enum
    Public Structure sMotionAxis
        Dim dAxis_X As Double
        Dim dAxis_Y As Double
        Dim dAxis_Z As Double
        Dim dAxis_Theta_Y As Double
        Dim dAxis_Theta As Double
    End Structure

    Public Structure sThetaCalFactor
        Dim dDeviation As Double
        Dim dRatio As Double
        Dim dOffset As Double
    End Structure

    Public Structure sWADCalFactor
        Dim dWAD_X() As String
        Dim dWAD_Y() As String
        Dim dWAD_Z() As String
    End Structure

#End Region

    Public Structure sTemperature
        Dim dMargin As Double
        Dim dLimitAlarmHigh As Double
        Dim dLimitAlarmLow As Double
    End Structure

    Public Structure sSpectrometer
        Dim nIVLSweepGain As Integer
        Dim nLifetimeGain As Integer
        Dim nAngleGain As Integer
        Dim nAperture As Integer
        Dim nSpeedMode As Integer
        Dim nExposureTime As Integer
        Dim MeasureMode As CSpectrometerLib.cDevCS2000A.eMeasureMode
        Dim nLTAperture As Integer
        Dim nLTSpeedMode As Integer
        Dim nIVLAperture As Integer
        Dim nIVLSpeedMode As Integer
        Dim nVAAperture As Integer
    End Structure

    Public Structure sCCD
        Dim dCCDExposureValue As Double
        Dim strCaptureCCDPath As String
        Dim dCaptureLevel As Double
        Dim ImageAnalysisMode As CDevVisionCameraCommonNode.eCenteringAnalysisMode
    End Structure

    Public Structure sSignalGenerator

    End Structure

    Public Structure sPatternGenerator

    End Structure

    Public Structure sPLC

    End Structure

    Public Structure sParamName
        Dim sAMXParamName As sAMXParam
        Dim sMDXParamName As sMDXPaaram
    End Structure

    Public Structure sParamRange
        Dim sPMX As sPMXRange
        Dim sAMX As sAMXRange
        Dim sMDX As sMDXRange
    End Structure

    Public Structure sPMXRange
        Dim Min As ucDispCellLifetime.sSourceSetting
        Dim Max As ucDispCellLifetime.sSourceSetting
    End Structure

    Public Structure sAMXRange
        Dim Low As sAMXSourceSetting
        Dim High As sAMXSourceSetting
    End Structure

    Public Structure sMDXRange
        Dim Low As sMDXSourceSetting
        Dim High As sMDXSourceSetting
    End Structure

    Public Structure sAMXSourceSetting
        Dim dMainPower As Double
        Dim dSubPower As Double
        Dim dSignal As Double
    End Structure

    Public Structure sMDXSourceSetting
        Dim dVoltage As Double
        Dim dCurrent As Double
    End Structure

    Public Structure sStateSetting
        Dim NumOfState As Integer
        Dim StatusColor() As sStatusColor
    End Structure
    Public Structure sStatusColor
        Dim g_lineColor As Integer
        Dim g_status As String 'CScheduler.eChSchedulerSTATE
    End Structure

    Public Structure sCalOption
        Dim bCalDataApply As Boolean
        Dim Degree As Integer
    End Structure

    Public Structure sConstantBrightSetting
        Dim dPDDeviation As Double
        Dim dBiasRangeLV_CC As Double
        Dim dBiasRangeLV_CV As Double
    End Structure

    Public Structure sAMXParam
        Dim ELVDD_V As String
        Dim ELVDD_I As String
        Dim ELVSS_V As String
        Dim ELVSS_I As String
        Dim SubPower_10 As String
        Dim SubPower_11 As String
        Dim SubPower_12 As String
    End Structure

    Public Structure sMDXPaaram
        Dim Voltage_01 As String
        Dim Voltage_02 As String
        Dim Voltage_03 As String
        Dim Voltage_04 As String
        Dim Voltage_05 As String
        Dim Current_01 As String
        Dim Current_02 As String
        Dim Current_03 As String
        Dim Current_04 As String
        Dim Current_05 As String
    End Structure

    Public Structure sOption_Disp
        Dim dispVolt As CUnitConverter.sValueDisp
        Dim dispCurrent As CUnitConverter.sValueDisp
        Dim dispPhotocurrent As CUnitConverter.sValueDisp
        Dim dispPower As CUnitConverter.sValueDisp
        Dim dispResistance As CUnitConverter.sValueDisp
        Dim dispArea As CUnitConverter.sValueDisp
        Dim dispCurrentDensity As CUnitConverter.sValueDisp
        Dim ChDispType As CChDisp.eChannelDispType
        Dim nIntegral As Integer
        Dim nIntegralRelative As Integer
    End Structure

    Public Structure sSaveOptions
        Dim bFileName_AddChNum As Boolean
        Dim bFileName_AddUserInput As Boolean
        Dim bFileName_AddDate As Boolean
        Dim bFileName_AddExpMode As Boolean
        Dim sDefaultSavePath As String
        Dim sBackupSavePath As String
        Dim bUsedBackupPath As Boolean

        Dim nIntegralWL_Pick1_Start As Integer
        Dim nIntegralWL_Pick1_end As Integer

        Dim nIntegralWL_Pick2_start As Integer
        Dim nIntegralWL_Pick2_end As Integer

        Dim nIntegralWL_Pick3_Start As Integer
        Dim nIntegralWL_Pick3_end As Integer
      
        Dim nIntegralWL_Pick4_start As Integer
        Dim nIntegralWL_Pick4_end As Integer

        Dim dLuminancePerSpectrumSave As Double
        Dim nDataIVLPlotItems() As eIVLDataIndex
        Dim nDataVAPlotItems() As eVADataIndex
        Dim nDataLTPlotItems() As eLTDataIndex
        Dim nDataIVLPlotItemName() As String
        Dim nDataVAPlotItemName() As String
        Dim nDataLTPlotItemName() As String
        Dim sLifetimeHeader As sLifetimeHeader
        Dim sIVLHeader As sIVLHeader
        Dim sVAHeader As sIVLHeader
        Dim nFileType As cDataOutput.eFileType
        Dim bCalRealCurrentSave As Boolean
        Dim bFilenameTEGtoTEGChannel As Boolean ' 덕산만 사용
    End Structure

    Public Structure sLifetimeHeader
        Dim bFileversion As Boolean
        Dim bFilename As Boolean
        Dim bMeasMode As Boolean
        Dim bBiasMode As Boolean
        Dim bRenewalTime As Boolean
    End Structure

    Public Structure sIVLHeader
        Dim bFileversion As Boolean
        Dim bFilename As Boolean
        Dim bMeasMode As Boolean
        Dim bBiasMode As Boolean
        Dim bSweepMode As Boolean
        Dim bLuminanceMeasLevel As Boolean
    End Structure

    Public Structure sVAHeader
        Dim bFileversion As Boolean
        Dim bFilename As Boolean
        Dim bMeasMode As Boolean
        Dim bBiasMode As Boolean
    End Structure

    Dim ConfigInfo As frmConfigDevice.sConfig = Nothing

#End Region


#Region "Property"


    Public Property Settings As sOPTIONDATa
        Get
            '  LoadSystemOption(g_sSystemOption)
            Return m_Option
        End Get
        Set(ByVal value As sOPTIONDATa)
            m_Option = value
        End Set
    End Property

#End Region

    Public Sub New(ByVal parent As frmMain)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        fMain = parent
        init()
    End Sub

    Public Sub init()


        'With cbBiasMode
        '    .Items.Clear()

        '    For idx As Integer = 0 To sMode.Length - 1
        '        .Items.Add(sMode(idx))
        '    Next
        '    .SelectedIndex = 0
        'End With

        With cbStatus
            .Items.Clear()
            For idx As Integer = 0 To g_status.Length - 1
                .Items.Add(g_status(idx))
            Next
            .SelectedIndex = 0
        End With

        With cbSelACFMode
            .Items.Clear()
            For idx As Integer = 0 To sCaption_ACFModes.Length - 1
                .Items.Add(sCaption_ACFModes(idx))
            Next
            .SelectedIndex = 0
        End With

        ' ReDim fMain.g_SystemOptions.sOptionData.bMDXOutData(4)
        ReDim m_Option.bMDXOutData(4)


        cbAperture.Items.Clear()
        cbIVLSweepAperture.Items.Clear()

        If g_SystemOptions.sDeviceOption.sSpectrometer.ApertureList Is Nothing = False Then
            For i As Integer = 0 To g_SystemOptions.sDeviceOption.sSpectrometer.ApertureList.Length - 1
                cbAperture.Items.Add(g_SystemOptions.sDeviceOption.sSpectrometer.ApertureList(i).sApertureName)
                cbIVLSweepAperture.Items.Add(g_SystemOptions.sDeviceOption.sSpectrometer.ApertureList(i).sApertureName)
            Next
        Else
            cbAperture.Items.Add("Nothing")
            cbIVLSweepAperture.Items.Add("Nothing")
        End If

        cbAperture.SelectedIndex = 0
        cbIVLSweepAperture.SelectedIndex = 0

        cbSpeedMode.Items.Clear()
        cbIVLSweepSpeedMode.Items.Clear()

        'If g_SystemOptions.sDeviceOption.sSpectrometer.MeasSpeedList Is Nothing = False Then
        '    For i As Integer = 0 To g_SystemOptions.sDeviceOption.sSpectrometer.MeasSpeedList.Length - 1
        '        cbSpeedMode.Items.Add(g_SystemOptions.sDeviceOption.sSpectrometer.MeasSpeedList(i).sSpeedName)
        '        cbIVLSweepSpeedMode.Items.Add(g_SystemOptions.sDeviceOption.sSpectrometer.MeasSpeedList(i).sSpeedName)
        '    Next
        'Else
        '    cbSpeedMode.Items.Add("Nothing")
        '    cbIVLSweepSpeedMode.Items.Add("Nothing")
        'End If

        For i As Integer = 0 To sSpeedMode.Length - 1
            cbSpeedMode.Items.Add(sSpeedMode(i))
            cbIVLSweepSpeedMode.Items.Add(sSpeedMode(i))
        Next

        cbSpeedMode.SelectedIndex = 0
        cbIVLSweepSpeedMode.SelectedIndex = 0

        With cboIVLDataFormat
            .Items.Clear()
            For i As Integer = 0 To sIVLDataPlotItems.Length - 1
                .Items.Add(sIVLDataPlotItems(i))
            Next
            .SelectedIndex = 0
        End With

        'With cboVADataFormat
        '    .Items.Clear()
        '    For i As Integer = 0 To sVADataPlotItems.Length - 1
        '        .Items.Add(sVADataPlotItems(i))
        '    Next
        '    .SelectedIndex = 0
        'End With

        With cboLTDataFormat
            .Items.Clear()
            For i As Integer = 0 To sLTDataPlotItems.Length - 1
                .Items.Add(sLTDataPlotItems(i))
            Next
            .SelectedIndex = 0
        End With

        With cbFileType
            .Items.Clear()
            For i As Integer = 0 To sFileType.Length - 1
                .Items.Add(sFileType(i))
            Next
            .SelectedIndex = 0
        End With

        With cbACFSrcMode
            .Items.Clear()
            For i As Integer = 0 To sACFSoruceMode.Length - 1
                .Items.Add(sACFSoruceMode(i))
            Next
            .SelectedIndex = 0
        End With


        cbAnalysisMode.SelectedIndex = 0

        frmConfigDevice.LoadConfiguration(ConfigInfo)

    End Sub

    Private Sub frmOptionWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If LoadSystemOption(m_Option) = True Then
            SetValueToUI()
        Else
            fMain.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_ALARM_Check_Options)
        End If

        If fMain.cVision Is Nothing = False Then
            If fMain.cVision.myVisionCamera.Model <> CDevVisionCameraCommonNode.eModel._SVSCamera Then
                If fMain.cVision.myVisionCamera.GetAttributeList(m_sAttributes) = True Then
                    cbAttributes.Items.Clear()
                    For i As Integer = 0 To m_sAttributes.Length - 1
                        cbAttributes.Items.Add(m_sAttributes(i))
                    Next
                    cbAttributes.SelectedIndex = 0
                End If
            End If

            grbACF.Visible = True
        End If
    End Sub

#Region "Set/Get Option Function"

    Private Sub SetValueToUI()

        With m_Option
            'ACF
            cbSelACFMode.SelectedIndex = .ACFData.nACFMode

            tbScanRegion_Start.Text = CStr(.ACFData.dACFRegion_Start)
            tbScanRegion_Stop.Text = CStr(.ACFData.dACFRegion_Stop)
            tbScanResolution.Text = CStr(.ACFData.dScanResolution)
            tbFocusParam.Text = CStr(.ACFData.nFocusParam)

            'ACF --> Image Process
            tbThreshold.Text = CStr(.ACFData.nDefThreshold)
            tbLowThresholdVal.Text = CStr(.ACFData.nLowThreshold)
            tbHighThresholdVal.Text = CStr(.ACFData.nHighThreshold)
            tbCCDWidth.Text = CStr(.ACFData.nCCDResolutionWidth)
            tbCCDHigh.Text = CStr(.ACFData.nCCDResolutionHigh)
            cbBlobFilter.SelectedIndex = CStr(.ACFData.eBlobFilter)
            tbMinBlobRadius.Text = CStr(.ACFData.nMinBlobRadius)

            'ACF --> Distance
            tbCCDtoSpectrometerPos_X.Text = CStr(.ACFData.dCCDtoSpectrometerPosX)
            tbCCDtoSpectrometerPos_Y.Text = CStr(.ACFData.dCCDtoSpectrometerPosY)
            tbCCDtoSpectrometerPos_Z.Text = CStr(.ACFData.dCCDtoSpectrometerPosZ)

            tbCCDtoHEXAPos_X.Text = CStr(.ACFData.dCCDtoHEXAPosX)
            tbCCDtoHEXAPos_Y.Text = CStr(.ACFData.dCCDtoHEXAPosY)
            tbCCDtoHEXAPos_Z.Text = CStr(.ACFData.dCCDtoHEXAPosZ)

            tbCCDtoMCRPos_X.Text = CStr(.ACFData.dCCDtoMCRPosX)
            tbCCDtoMCRPos_Y.Text = CStr(.ACFData.dCCDtoMCRPosY)
            tbCCDtoMCRPos_Z.Text = CStr(.ACFData.dCCDtoMCRPosZ)

            tbCCDPos_X.Text = CStr(.ACFData.dCCDPosX)
            tbCCDPos_Y.Text = CStr(.ACFData.dCCDPosY)
            tbCCDPos_Z.Text = CStr(.ACFData.dCCDPosZ)
            tbSpectrometerPos_X.Text = CStr(.ACFData.dSpectrometerPosX)
            tbSpectrometerPos_Y.Text = CStr(.ACFData.dSpectrometerPosY)
            tbSpectrometerPos_Z.Text = CStr(.ACFData.dSpectrometerPosZ)
            tbHEXAPos_X.Text = CStr(.ACFData.dHEXAPosX)
            tbHEXAPos_Y.Text = CStr(.ACFData.dHEXAPosY)
            tbHEXAPos_Z.Text = CStr(.ACFData.dHEXAPosZ)

            'ACF -->Filter
            tbLowIntensityLimit.Text = CStr(.ACFData.dLowIntensityLimit)
            tbGrayLevelLimit.Text = CStr(.ACFData.nGrayLevelLimit)

            'ACF --> Param
            cbACFSrcMode.SelectedIndex = CInt(.ACFData.sSoruceMode)
            tbPixelPerDistance_Width.Text = CStr(.ACFData.dPixelPerDistance_1mm_Width)
            tbPixelPerDistance_Hight.Text = CStr(.ACFData.dPixelPerDistance_1mm_High)

            tbIntesityAdj_Start.Text = CStr(.ACFData.dIntensityAdj_Bias)
            tbIntesityAdj_Step.Text = CStr(.ACFData.dIntensityAdj_Step)
            tbIntesityAdj_Limit.Text = CStr(.ACFData.dIntensityAdj_Limit)

            tbMdlPatternNo.Text = CStr(.ACFData.nModulePatternNo)



            'Motion
            tbDistance_X.Text = CStr(.MotionData.sStandardDistance.dAxis_X)
            tbDistance_Y.Text = CStr(.MotionData.sStandardDistance.dAxis_Y)
            tbDistance_Z.Text = CStr(.MotionData.sStandardDistance.dAxis_Z)
            tbDistance_Theta_Y.Text = CStr(.MotionData.sStandardDistance.dAxis_Theta_Y)
            tbDistance_Theta.Text = CStr(.MotionData.sStandardDistance.dAxis_Theta)

            tbStartPos_X.Text = CStr(.MotionData.sStartPos.dAxis_X)
            tbStartPos_Y.Text = CStr(.MotionData.sStartPos.dAxis_Y)
            tbStartPos_Z.Text = CStr(.MotionData.sStartPos.dAxis_Z)
            '  tbStartPos_Theta_Y.Text = CStr(.MotionData.sStartPos.dAxis_Theta_Y)
            tbStartPos_Theta.Text = CStr(.MotionData.sStartPos.dAxis_Theta)

            tbThetaDeviation.Text = CStr(.MotionData.sThetaCal.dDeviation)
            tbThetaRatio.Text = CStr(.MotionData.sThetaCal.dRatio)
            tbThetaOffset.Text = CStr(.MotionData.sThetaCal.dOffset)

            tbEndPos_X.Text = CStr(.MotionData.sEndPos.dAxis_X)
            tbEndPos_Y.Text = CStr(.MotionData.sEndPos.dAxis_Y)
            tbEndPos_Z.Text = CStr(.MotionData.sEndPos.dAxis_Z)
            ' tbEndPos_Theta_Y.Text = CStr(.MotionData.sEndPos.dAxis_Theta_Y)
            tbEndPos_Theta.Text = CStr(.MotionData.sEndPos.dAxis_Theta)

            tbCalPos_X.Text = CStr(.MotionData.sCalPos.dAxis_X)
            tbCalPos_Y.Text = CStr(.MotionData.sCalPos.dAxis_Y)
            tbCalPos_Z.Text = CStr(.MotionData.sCalPos.dAxis_Z)
            '  tbCalPos_Theta_Y.Text = CStr(.MotionData.sCalPos.dAxis_Theta_Y)
            tbCalPos_Theta.Text = CStr(.MotionData.sCalPos.dAxis_Theta)

            tbPosPerDistance_X.Text = CStr(.MotionData.sCalPosPerDistance.dAxis_X)
            tbPosPerDistance_Y.Text = CStr(.MotionData.sCalPosPerDistance.dAxis_Y)
            tbPosPerDistance_Z.Text = CStr(.MotionData.sCalPosPerDistance.dAxis_Z)
            '  tbPosPerDistance_Theta_Y.Text = CStr(.MotionData.sCalPosPerDistance.dAxis_Theta_Y)
            tbPosPerDistance_Theta.Text = CStr(.MotionData.sCalPosPerDistance.dAxis_Theta)

            'fMain.cMotion.CalDataRealDistanceX = .MotionData.sCalPosPerDistance.dAxis_X
            'fMain.cMotion.CalDataRealDistanceY = .MotionData.sCalPosPerDistance.dAxis_Y
            'fMain.cMotion.CalDataRealDistanceZ = .MotionData.sCalPosPerDistance.dAxis_Z
            'fMain.cMotion.CalDataRealDistanceTheta = .MotionData.sCalPosPerDistance.dAxis_Theta
            'fMain.cMotion.CalDataDeviationTheta = .MotionData.sThetaCal.dDeviation
            'fMain.cMotion.CalDataRatioTheta = .MotionData.sThetaCal.dRatio
            'fMain.cMotion.CalDataOffsetTheta = .MotionData.sThetaCal.dOffset

            If .MotionData.bCalPosPerDistanceUse = True Then
                chkCalPosPerDistance.Checked = True
            Else
                chkCalPosPerDistance.Checked = False
            End If

            'Temp
            tbTemp_Margin.Text = CStr(.TemperatureData.dMargin)
            tbTemp_LimitAlarmLow.Text = CStr(.TemperatureData.dLimitAlarmLow)
            tbTemp_LimitAlarmHigh.Text = CStr(.TemperatureData.dLimitAlarmHigh)

            'Spectrometer
            cbIVLSweepGain.SelectedIndex = .Spectrometer.nIVLSweepGain
            cbLifetimeGain.SelectedIndex = .Spectrometer.nLifetimeGain
            cbAngleGain.SelectedIndex = .Spectrometer.nAngleGain

            Try
                cbAperture.SelectedIndex = .Spectrometer.nAperture
                cbSpeedMode.SelectedIndex = .Spectrometer.nSpeedMode
                cbIVLSweepAperture.SelectedIndex = .IVLSpectrometer.nAperture
                cbIVLSweepSpeedMode.SelectedIndex = .IVLSpectrometer.nSpeedMode
                tbExposureTime.Text = .IVLSpectrometer.nExposureTime
            Catch ex As Exception
                cbAperture.SelectedIndex = 0
                cbSpeedMode.SelectedIndex = 0
                cbIVLSweepAperture.SelectedIndex = 0
                cbIVLSweepSpeedMode.SelectedIndex = 0
            End Try

            If .IVLSpectrometer.MeasureMode = CSpectrometerLib.cDevCS2000A.eMeasureMode._Auto Then
                chkSpectroMeasureMode.Checked = True
            Else
                chkSpectroMeasureMode.Checked = False
            End If

            'CCD
            tbCCDExposureValue.Text = CStr(.CCDData.dCCDExposureValue)
            tbCaptureImagePath.Text = CStr(.CCDData.strCaptureCCDPath)
            tbCaptureLevel.Text = CStr(.CCDData.dCaptureLevel)
            cbAnalysisMode.SelectedIndex = .CCDData.ImageAnalysisMode

            txtBiasLowValue.Text = .ParamRange.sPMX.Min.dBias
            txtBiasHighValue.Text = .ParamRange.sPMX.Max.dBias
            txtLowAmplitude.Text = .ParamRange.sPMX.Min.dAmplitude
            txtHighAmplitude.Text = .ParamRange.sPMX.Max.dAmplitude
            txtLowDuty.Text = .ParamRange.sPMX.Min.Pulse.dDuty
            txtHighDuty.Text = .ParamRange.sPMX.Max.Pulse.dDuty
            txtLowFrequency.Text = .ParamRange.sPMX.Min.Pulse.dFrequency
            txtHighFrequency.Text = .ParamRange.sPMX.Max.Pulse.dFrequency
            txtHighMainPower.Text = .ParamRange.sAMX.High.dMainPower
            txtLowMainPower.Text = .ParamRange.sAMX.Low.dMainPower
            txtHighSubPower.Text = .ParamRange.sAMX.High.dSubPower
            txtLowSubPower.Text = .ParamRange.sAMX.Low.dSubPower
            txtHighSignal.Text = .ParamRange.sAMX.High.dSignal
            txtLowSignal.Text = .ParamRange.sAMX.Low.dSignal

            'Display Unit
            ucSelDispType_Volt.ValueType = .DispGroup.dispVolt.nTypeOfVal
            ucSelDispType_Volt.SelectedUnit = .DispGroup.dispVolt.nUnit
            tbDispDigit_Volt.Text = .DispGroup.dispVolt.nDispDigit

            ucSelDispType_Current.ValueType = .DispGroup.dispCurrent.nTypeOfVal
            ucSelDispType_Current.SelectedUnit = .DispGroup.dispCurrent.nUnit
            tbDispDigit_Current.Text = .DispGroup.dispCurrent.nDispDigit

            ucSelDispType_Photocurrent.ValueType = .DispGroup.dispPhotocurrent.nTypeOfVal
            ucSelDispType_Photocurrent.SelectedUnit = .DispGroup.dispPhotocurrent.nUnit
            tbDispDigit_Photocurrent.Text = .DispGroup.dispPhotocurrent.nDispDigit

            tbDispDigit_Integral.Text = .DispGroup.nIntegral
            tbDispDigit_Integral_Relative.Text = .DispGroup.nIntegralRelative

            If .DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                rdoDispCh_Channel.Checked = True
            ElseIf .DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                rdoDispCh_JIGAndCellNo.Checked = True
            End If

            Dim sData(0) As Object

            For idx As Integer = 0 To .StateSetting.NumOfState - 1
                sData(0) = .StateSetting.StatusColor(idx).g_status
                ucDispFontColorList.AddRowData(sData, .StateSetting.StatusColor(idx).g_lineColor)
            Next

            ChkOut_1.Checked = .bMDXOutData(0)
            ChkOut_2.Checked = .bMDXOutData(1)
            ChkOut_3.Checked = .bMDXOutData(2)
            ChkOut_4.Checked = .bMDXOutData(3)
            ChkOut_5.Checked = .bMDXOutData(4)

            chkEnableDataViewerLink_IVL.Checked = .bEnableDataViewerLink_IVL
            tbPathOfDataViewer_IVL.Text = .sPathOfDataViewer_IVL
            chkEnableDataViewerLink_LT.Checked = .bEnableDataViewerLink_LT
            tbPathOfDataViewer_LT.Text = .sPathOfDataViewer_LT

            'Save Options
            chkSaveOpt_AddChNum.Checked = .SaveOptions.bFileName_AddChNum
            chkSaveOpt_AddDate.Checked = .SaveOptions.bFileName_AddDate
            chkSaveOpt_AddExpMode.Checked = .SaveOptions.bFileName_AddExpMode
            chkSaveOpt_AddUserInputFileName.Checked = .SaveOptions.bFileName_AddUserInput

            tbDefSavePath.Text = .SaveOptions.sDefaultSavePath
            tbLumiPerSpectrumSave.Text = .SaveOptions.dLuminancePerSpectrumSave
            chkFilenameTEGtoTEGChannel.Checked = .SaveOptions.bFilenameTEGtoTEGChannel
            'ChkUseBackupPath.Checked = .SaveOptions.bUsedBackupPath
            'tbBackupSavePath.Text = .SaveOptions.sBackupSavePath

            'txtSpectrumJIG17_24_Peak1_1.Text = .SaveOptions.nJIG17_24_Pick1_Start
            'txtSpectrumJIG17_24_Peak1_2.Text = .SaveOptions.nJIG17_24_Pick1_end
            'txtSpectrumJIG17_24_Peak2_1.Text = .SaveOptions.nJIG17_24_Pick2_start
            'txtSpectrumJIG17_24_Peak2_2.Text = .SaveOptions.nJIG17_24_Pick2_end

            'txtSpectrumJIG25_32_Peak1_1.Text = .SaveOptions.nJIG25_32_Pick1_Start
            'txtSpectrumJIG25_32_Peak1_2.Text = .SaveOptions.nJIG25_32_Pick1_end
            'txtSpectrumJIG25_32_Peak2_1.Text = .SaveOptions.nJIG25_32_Pick2_start
            'txtSpectrumJIG25_32_Peak2_2.Text = .SaveOptions.nJIG25_32_Pick2_end

            Try
                cbFileType.SelectedIndex = .SaveOptions.nFileType
                '    chkRealCurrent.Checked = .SaveOptions.bCalRealCurrentSave
            Catch ex As Exception
                cbFileType.SelectedIndex = 0
                '   chkRealCurrent.Checked = False
            End Try

            Dim sData_1(1) As String

            'IVL Data format
            ucDispIVLDataIndex.ClearAllData()
            If .SaveOptions.nDataIVLPlotItems Is Nothing = False Then
                For i As Integer = 0 To .SaveOptions.nDataIVLPlotItems.Length - 1
                    sData_1(0) = ucDispIVLDataIndex.GetListItemCount + 1
                    sData_1(1) = sIVLDataPlotItems(.SaveOptions.nDataIVLPlotItems(i))
                    ucDispIVLDataIndex.AddRowData(sData_1)
                Next
            End If

            chkIVLFileversion.Checked = .SaveOptions.sIVLHeader.bFileversion
            chkIVLFilename.Checked = .SaveOptions.sIVLHeader.bFilename
            chkIVLMeasMode.Checked = .SaveOptions.sIVLHeader.bMeasMode
            chkIVLBiasMode.Checked = .SaveOptions.sIVLHeader.bBiasMode
            chkIVLSweepMode.Checked = .SaveOptions.sIVLHeader.bSweepMode
            chkIVLLumiMeasLevel.Checked = .SaveOptions.sIVLHeader.bLuminanceMeasLevel

            'ucDispVADataIndex.ClearAllData()
            'If .SaveOptions.nDataVAPlotItems Is Nothing = False Then
            '    For i As Integer = 0 To .SaveOptions.nDataVAPlotItems.Length - 1
            '        sData_1(0) = ucDispVADataIndex.GetListItemCount + 1
            '        sData_1(1) = sVADataPlotItems(.SaveOptions.nDataVAPlotItems(i))
            '        ucDispVADataIndex.AddRowData(sData_1)
            '    Next
            'End If

            'chkVAFileversion.Checked = .SaveOptions.sVAHeader.bFileversion
            'chkVAFilename.Checked = .SaveOptions.sVAHeader.bFilename
            'chkVAMeasMode.Checked = .SaveOptions.sVAHeader.bMeasMode
            'chkVABiasMode.Checked = .SaveOptions.sVAHeader.bBiasMode
            'chkVASweepMode.Checked = .SaveOptions.sVAHeader.bSweepMode

            'Lifetime Data format
            ucDispLTDataIndex.ClearAllData()
            If .SaveOptions.nDataLTPlotItems Is Nothing = False Then
                For i As Integer = 0 To .SaveOptions.nDataLTPlotItems.Length - 1
                    sData_1(0) = ucDispLTDataIndex.GetListItemCount + 1
                    sData_1(1) = sLTDataPlotItems(.SaveOptions.nDataLTPlotItems(i))
                    ucDispLTDataIndex.AddRowData(sData_1)
                Next
            End If
            chkLTFileversion.Checked = .SaveOptions.sLifetimeHeader.bFileversion
            chkLTFilename.Checked = .SaveOptions.sLifetimeHeader.bFilename
            chkLTMeasMode.Checked = .SaveOptions.sLifetimeHeader.bMeasMode
            chkLTBiasMode.Checked = .SaveOptions.sLifetimeHeader.bBiasMode
            chkLTRenewalTime.Checked = .SaveOptions.sLifetimeHeader.bRenewalTime

            'Visible Display Options
            chkVisibleChannelMoveButton.Checked = .VisibleDisplay.bChannelMoveButton
            chkVisibleAngleMoveButton.Checked = .VisibleDisplay.bAngleMoveButton

            'SampleInfos Options
            tbSampleHeight.Text = .SampleInfos.dHeight
            tbSampleWidth.Text = .SampleInfos.dWidth
            tbFill.Text = .SampleInfos.dFillFactor

            'sMaterialDatas Option
            'tbRed_x.Text = .MaterialData.sRed.dCIEx
            'tbRed_y.Text = .MaterialData.sRed.dCIEy
            'tbRed_ApertureRatio.Text = .MaterialData.sRed.dApertureRatio
            'tbRed_TransmittancePolarizers.Text = .MaterialData.sRed.dTransmittancePolarizers

            'tbGreen_x.Text = .MaterialData.sGreen.dCIEx
            'tbGreen_y.Text = .MaterialData.sGreen.dCIEy
            'tbGreen_ApertureRatio.Text = .MaterialData.sGreen.dApertureRatio
            'tbGreen_TransmittancePolarizers.Text = .MaterialData.sGreen.dTransmittancePolarizers

            'tbBlue_x.Text = .MaterialData.sBlue.dCIEx
            'tbBlue_y.Text = .MaterialData.sBlue.dCIEy
            'tbBlue_ApertureRatio.Text = .MaterialData.sBlue.dApertureRatio
            'tbBlue_TransmittancePolarizers.Text = .MaterialData.sBlue.dTransmittancePolarizers

            'tbWhite_x.Text = .MaterialData.sWhite.dCIEx
            'tbWhite_y.Text = .MaterialData.sWhite.dCIEy
            'tbWhite_ApertureRatio.Text = .MaterialData.sWhite.dApertureRatio
            'tbWhite_TransmittancePolarizers.Text = .MaterialData.sWhite.dTransmittancePolarizers
            'tbWhite_BrightnessRequirements.Text = .MaterialData.sWhite.dBrightnessRequirements
        End With


    End Sub

    Private Function GetValueFromUI() As Boolean

        With m_Option
            Dim nRowCnt As Integer
            Dim sData(0) As Object
            Dim nDataListCnt As Integer

            'RANGE Settings
            .ParamRange.sPMX.Min.dBias = txtBiasLowValue.Text
            .ParamRange.sPMX.Max.dBias = txtBiasHighValue.Text
            .ParamRange.sPMX.Min.dAmplitude = txtLowAmplitude.Text
            .ParamRange.sPMX.Max.dAmplitude = txtHighAmplitude.Text
            .ParamRange.sPMX.Min.Pulse.dDuty = txtLowDuty.Text
            .ParamRange.sPMX.Max.Pulse.dDuty = txtHighDuty.Text
            .ParamRange.sPMX.Min.Pulse.dFrequency = txtLowFrequency.Text
            .ParamRange.sPMX.Max.Pulse.dFrequency = txtHighFrequency.Text

            .ParamRange.sAMX.High.dMainPower = txtHighMainPower.Text
            .ParamRange.sAMX.Low.dMainPower = txtLowMainPower.Text
            .ParamRange.sAMX.High.dSubPower = txtHighSubPower.Text
            .ParamRange.sAMX.Low.dSubPower = txtLowSubPower.Text
            .ParamRange.sAMX.High.dSignal = txtHighSignal.Text
            .ParamRange.sAMX.Low.dSignal = txtLowSignal.Text

            'Display Unit
            .DispGroup.dispVolt.nTypeOfVal = ucSelDispType_Volt.ValueType

            If .DispGroup.dispVolt.nUnit Is Nothing = False Then
                .DispGroup.dispVolt.nUnit = ucSelDispType_Volt.SelectedUnit
            Else
                .DispGroup.dispVolt.nUnit = ucSelDispType_Current.SelectedUnit
            End If
            .DispGroup.dispVolt.nDispDigit = tbDispDigit_Volt.Text

            .DispGroup.dispCurrent.nTypeOfVal = ucSelDispType_Current.ValueType

            .DispGroup.dispCurrent.nUnit = ucSelDispType_Current.SelectedUnit
            .DispGroup.dispCurrent.nDispDigit = tbDispDigit_Current.Text

            .DispGroup.dispPhotocurrent.nTypeOfVal = ucSelDispType_Photocurrent.ValueType
            .DispGroup.dispPhotocurrent.nUnit = ucSelDispType_Photocurrent.SelectedUnit
            .DispGroup.dispPhotocurrent.nDispDigit = tbDispDigit_Photocurrent.Text

            .DispGroup.nIntegral = tbDispDigit_Integral.Text
            .DispGroup.nIntegralRelative = tbDispDigit_Integral_Relative.Text

            If rdoDispCh_Channel.Checked = True Then
                .DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel
            ElseIf rdoDispCh_JIGAndCellNo.Checked = True Then
                .DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo
            Else
                .DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel
            End If

            'DISPLAY COLOR
            .StateSetting.NumOfState = ucDispFontColorList.GetNumOfRowData(nRowCnt)

            ReDim .StateSetting.StatusColor(nRowCnt - 1)

            For idx As Integer = 0 To nRowCnt - 1
                ucDispFontColorList.GetRowData(idx, sData, LineColorInfo)
                .StateSetting.StatusColor(idx).g_lineColor = LineColorInfo.ToArgb
                .StateSetting.StatusColor(idx).g_status = sData(0)
            Next

            .StateSetting.NumOfState = nRowCnt

            'Number Of Outdata Display (MDX0
            .bMDXOutData(0) = ChkOut_1.Checked
            .bMDXOutData(1) = ChkOut_2.Checked
            .bMDXOutData(2) = ChkOut_3.Checked
            .bMDXOutData(3) = ChkOut_4.Checked
            .bMDXOutData(4) = ChkOut_5.Checked

            'Link
            .bEnableDataViewerLink_IVL = chkEnableDataViewerLink_IVL.Checked
            .sPathOfDataViewer_IVL = tbPathOfDataViewer_IVL.Text
            .bEnableDataViewerLink_LT = chkEnableDataViewerLink_LT.Checked
            .sPathOfDataViewer_LT = tbPathOfDataViewer_LT.Text

            'ACF
            .ACFData.sSoruceMode = cbACFSrcMode.SelectedIndex

            .ACFData.dACFRegion_Start = frmBuilderSettings.ConvertToDouble(tbScanRegion_Start.Text)
            .ACFData.dACFRegion_Stop = frmBuilderSettings.ConvertToDouble(tbScanRegion_Stop.Text)
            .ACFData.dScanResolution = frmBuilderSettings.ConvertToDouble(tbScanResolution.Text)
            .ACFData.nFocusParam = frmBuilderSettings.ConvertToInteger(tbFocusParam.Text)

            'ACF --> Image Process
            .ACFData.nDefThreshold = frmBuilderSettings.ConvertToInteger(tbThreshold.Text)
            .ACFData.nLowThreshold = frmBuilderSettings.ConvertToInteger(tbLowThresholdVal.Text)
            .ACFData.nHighThreshold = frmBuilderSettings.ConvertToInteger(tbHighThresholdVal.Text)
            .ACFData.nCCDResolutionWidth = frmBuilderSettings.ConvertToInteger(tbCCDWidth.Text)
            .ACFData.nCCDResolutionHigh = frmBuilderSettings.ConvertToInteger(tbCCDHigh.Text)
            .ACFData.nCCDCenterPos_X = frmBuilderSettings.ConvertToInteger(.ACFData.nCCDResolutionWidth / 2)
            .ACFData.nCCDCenterPos_Y = frmBuilderSettings.ConvertToInteger(.ACFData.nCCDResolutionHigh / 2)

            .ACFData.eBlobFilter = cbBlobFilter.SelectedIndex
            .ACFData.nMinBlobRadius = frmBuilderSettings.ConvertToInteger(tbMinBlobRadius.Text)

            'ACF --> Distance
            .ACFData.dCCDPosX = frmBuilderSettings.ConvertToDouble(tbCCDPos_X.Text)
            .ACFData.dCCDPosY = frmBuilderSettings.ConvertToDouble(tbCCDPos_Y.Text)
            .ACFData.dCCDPosZ = frmBuilderSettings.ConvertToDouble(tbCCDPos_Z.Text)
            .ACFData.dSpectrometerPosX = frmBuilderSettings.ConvertToDouble(tbSpectrometerPos_X.Text)
            .ACFData.dSpectrometerPosY = frmBuilderSettings.ConvertToDouble(tbSpectrometerPos_Y.Text)
            .ACFData.dSpectrometerPosZ = frmBuilderSettings.ConvertToDouble(tbSpectrometerPos_Z.Text)
            .ACFData.dHEXAPosX = frmBuilderSettings.ConvertToDouble(tbHEXAPos_X.Text)
            .ACFData.dHEXAPosY = frmBuilderSettings.ConvertToDouble(tbHEXAPos_Y.Text)
            .ACFData.dHEXAPosZ = frmBuilderSettings.ConvertToDouble(tbHEXAPos_Z.Text)

            .ACFData.dCCDtoSpectrometerPosX = frmBuilderSettings.ConvertToDouble(tbCCDtoSpectrometerPos_X.Text)
            .ACFData.dCCDtoSpectrometerPosY = frmBuilderSettings.ConvertToDouble(tbCCDtoSpectrometerPos_Y.Text)
            .ACFData.dCCDtoSpectrometerPosZ = frmBuilderSettings.ConvertToDouble(tbCCDtoSpectrometerPos_Z.Text)
            .ACFData.dCCDtoHEXAPosX = frmBuilderSettings.ConvertToDouble(tbCCDtoHEXAPos_X.Text)
            .ACFData.dCCDtoHEXAPosY = frmBuilderSettings.ConvertToDouble(tbCCDtoHEXAPos_Y.Text)
            .ACFData.dCCDtoHEXAPosZ = frmBuilderSettings.ConvertToDouble(tbCCDtoHEXAPos_Z.Text)

            .ACFData.dCCDtoMCRPosX = frmBuilderSettings.ConvertToDouble(tbCCDtoMCRPos_X.Text)
            .ACFData.dCCDtoMCRPosY = frmBuilderSettings.ConvertToDouble(tbCCDtoMCRPos_Y.Text)
            .ACFData.dCCDtoMCRPosZ = frmBuilderSettings.ConvertToDouble(tbCCDtoMCRPos_Z.Text)

            'ACF -->Filter
            .ACFData.dLowIntensityLimit = frmBuilderSettings.ConvertToDouble(tbLowIntensityLimit.Text)
            .ACFData.nGrayLevelLimit = frmBuilderSettings.ConvertToDouble(tbGrayLevelLimit.Text)

            'ACF --> Param
            .ACFData.dPixelPerDistance_1mm_Width = frmBuilderSettings.ConvertToDouble(tbPixelPerDistance_Width.Text)
            .ACFData.dPixelPerDistance_1mm_High = frmBuilderSettings.ConvertToDouble(tbPixelPerDistance_Hight.Text)
            .ACFData.dDistanceOfOnePixel_X = 1 / frmBuilderSettings.ConvertToDouble(.ACFData.dPixelPerDistance_1mm_Width)
            .ACFData.dDistanceOfOnePixel_Y = 1 / frmBuilderSettings.ConvertToDouble(.ACFData.dPixelPerDistance_1mm_High)

            'ACF --> Intensity Adjust
            .ACFData.nACFMode = cbACFSrcMode.SelectedIndex
            .ACFData.dIntensityAdj_Bias = frmBuilderSettings.ConvertToDouble(tbIntesityAdj_Start.Text)
            .ACFData.dIntensityAdj_Step = frmBuilderSettings.ConvertToDouble(tbIntesityAdj_Step.Text)
            .ACFData.dIntensityAdj_Limit = frmBuilderSettings.ConvertToDouble(tbIntesityAdj_Limit.Text)
            .ACFData.nModulePatternNo = frmBuilderSettings.ConvertToInteger(tbMdlPatternNo.Text)

            'Motion
            .MotionData.sStandardDistance.dAxis_X = frmBuilderSettings.ConvertToDouble(tbDistance_X.Text)
            .MotionData.sStandardDistance.dAxis_Y = frmBuilderSettings.ConvertToDouble(tbDistance_Y.Text)
            .MotionData.sStandardDistance.dAxis_Z = frmBuilderSettings.ConvertToDouble(tbDistance_Z.Text)
            .MotionData.sStandardDistance.dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(tbDistance_Theta_Y.Text)
            .MotionData.sStandardDistance.dAxis_Theta = frmBuilderSettings.ConvertToDouble(tbDistance_Theta.Text)

            .MotionData.sStartPos.dAxis_X = frmBuilderSettings.ConvertToDouble(tbStartPos_X.Text)
            .MotionData.sStartPos.dAxis_Y = frmBuilderSettings.ConvertToDouble(tbStartPos_Y.Text)
            .MotionData.sStartPos.dAxis_Z = frmBuilderSettings.ConvertToDouble(tbStartPos_Z.Text)
            '  .MotionData.sStartPos.dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(tbStartPos_Theta_Y.Text)
            .MotionData.sStartPos.dAxis_Theta = frmBuilderSettings.ConvertToDouble(tbStartPos_Theta.Text)

            .MotionData.sEndPos.dAxis_X = frmBuilderSettings.ConvertToDouble(tbEndPos_X.Text)
            .MotionData.sEndPos.dAxis_Y = frmBuilderSettings.ConvertToDouble(tbEndPos_Y.Text)
            .MotionData.sEndPos.dAxis_Z = frmBuilderSettings.ConvertToDouble(tbEndPos_Z.Text)
            ' .MotionData.sEndPos.dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(tbEndPos_Theta_Y.Text)
            .MotionData.sEndPos.dAxis_Theta = frmBuilderSettings.ConvertToDouble(tbEndPos_Theta.Text)

            .MotionData.sCalPos.dAxis_X = frmBuilderSettings.ConvertToDouble(tbCalPos_X.Text)
            .MotionData.sCalPos.dAxis_Y = frmBuilderSettings.ConvertToDouble(tbCalPos_Y.Text)
            .MotionData.sCalPos.dAxis_Z = frmBuilderSettings.ConvertToDouble(tbCalPos_Z.Text)
            '   .MotionData.sCalPos.dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(tbCalPos_Theta_Y.Text)
            .MotionData.sCalPos.dAxis_Theta = frmBuilderSettings.ConvertToDouble(tbCalPos_Theta.Text)

            .MotionData.sCalPosPerDistance.dAxis_X = frmBuilderSettings.ConvertToDouble(tbPosPerDistance_X.Text)
            .MotionData.sCalPosPerDistance.dAxis_Y = frmBuilderSettings.ConvertToDouble(tbPosPerDistance_Y.Text)
            .MotionData.sCalPosPerDistance.dAxis_Z = frmBuilderSettings.ConvertToDouble(tbPosPerDistance_Z.Text)
            '  .MotionData.sCalPosPerDistance.dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(tbPosPerDistance_Theta_Y.Text)
            .MotionData.sCalPosPerDistance.dAxis_Theta = frmBuilderSettings.ConvertToDouble(tbPosPerDistance_Theta.Text)

            .MotionData.sThetaCal.dDeviation = frmBuilderSettings.ConvertToDouble(tbThetaDeviation.Text)
            .MotionData.sThetaCal.dRatio = frmBuilderSettings.ConvertToDouble(tbThetaRatio.Text)
            .MotionData.sThetaCal.dOffset = frmBuilderSettings.ConvertToDouble(tbThetaOffset.Text)

            If chkCalPosPerDistance.Checked = True Then
                .MotionData.bCalPosPerDistanceUse = True
            Else
                .MotionData.bCalPosPerDistanceUse = False
            End If

            'Temp
            .TemperatureData.dMargin = frmBuilderSettings.ConvertToDouble(tbTemp_Margin.Text)
            .TemperatureData.dLimitAlarmLow = frmBuilderSettings.ConvertToDouble(tbTemp_LimitAlarmLow.Text)
            .TemperatureData.dLimitAlarmHigh = frmBuilderSettings.ConvertToDouble(tbTemp_LimitAlarmHigh.Text)

            'CCD
            .CCDData.dCCDExposureValue = frmBuilderSettings.ConvertToDouble(tbCCDExposureValue.Text)
            .CCDData.strCaptureCCDPath = tbCaptureImagePath.Text
            .CCDData.dCaptureLevel = CDbl(tbCaptureLevel.Text)
            .CCDData.ImageAnalysisMode = cbAnalysisMode.SelectedIndex

            'Save Options
            .SaveOptions.bFileName_AddChNum = chkSaveOpt_AddChNum.Checked
            .SaveOptions.bFileName_AddDate = chkSaveOpt_AddDate.Checked
            .SaveOptions.bFileName_AddExpMode = chkSaveOpt_AddExpMode.Checked
            .SaveOptions.bFileName_AddUserInput = chkSaveOpt_AddUserInputFileName.Checked
            .SaveOptions.sDefaultSavePath = tbDefSavePath.Text
            '.SaveOptions.sBackupSavePath = tbBackupSavePath.Text
            '.SaveOptions.bUsedBackupPath = ChkUseBackupPath.Checked
            .SaveOptions.dLuminancePerSpectrumSave = ConvertToDouble(tbLumiPerSpectrumSave.Text)
            .SaveOptions.nFileType = cbFileType.SelectedIndex
            '.SaveOptions.bCalRealCurrentSave = chkRealCurrent.Checked
            .SaveOptions.bFilenameTEGtoTEGChannel = chkFilenameTEGtoTEGChannel.Checked
            '
            '숫자 아닌 값들이 들어왔을때 예외처리'
            ''====

            'Try
            '    .SaveOptions.nJIG17_24_Pick1_Start = CInt(txtSpectrumJIG17_24_Peak1_1.Text)
            'Catch ex As Exception
            '    .SaveOptions.nJIG17_24_Pick1_Start = 2
            'End Try

            'Try
            '    .SaveOptions.nJIG17_24_Pick1_end = CInt(txtSpectrumJIG17_24_Peak1_2.Text)
            'Catch ex As Exception
            '    .SaveOptions.nJIG17_24_Pick1_end = 2
            'End Try

            'Try
            '    .SaveOptions.nJIG17_24_Pick2_start = CInt(txtSpectrumJIG17_24_Peak2_1.Text)
            'Catch ex As Exception
            '    .SaveOptions.nJIG17_24_Pick2_start = 2
            'End Try

            'Try
            '    .SaveOptions.nJIG17_24_Pick2_end = CInt(txtSpectrumJIG17_24_Peak2_2.Text)
            'Catch ex As Exception
            '    .SaveOptions.nJIG17_24_Pick2_end = 2
            'End Try

            ''=====
            'Try
            '    .SaveOptions.nJIG25_32_Pick1_Start = CInt(txtSpectrumJIG25_32_Peak1_1.Text)
            'Catch ex As Exception
            '    .SaveOptions.nJIG25_32_Pick1_Start = 2
            'End Try

            'Try
            '    .SaveOptions.nJIG25_32_Pick1_end = CInt(txtSpectrumJIG25_32_Peak1_2.Text)
            'Catch ex As Exception
            '    .SaveOptions.nJIG25_32_Pick1_end = 2
            'End Try

            'Try
            '    .SaveOptions.nJIG25_32_Pick2_start = CInt(txtSpectrumJIG25_32_Peak2_1.Text)
            'Catch ex As Exception
            '    .SaveOptions.nJIG25_32_Pick2_start = 2
            'End Try

            'Try
            '    .SaveOptions.nJIG25_32_Pick2_end = CInt(txtSpectrumJIG25_32_Peak2_2.Text)
            'Catch ex As Exception
            '    .SaveOptions.nJIG25_32_Pick2_end = 2
            'End Try

            '각 Peak값들에 대한 예외처리 (2nm 간격이며 380~780사이의 값이여함)
            'If .SaveOptions.nIntegralWL_Pick1_Start Mod 2 <> 0 Or .SaveOptions.nIntegralWL_Pick1_Start < 380 Or .SaveOptions.nIntegralWL_Pick1_Start > 780 Then
            '    MsgBox("JIG 1-8 Peak1 Start 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
            '    Return False
            'End If

            'If .SaveOptions.nIntegralWL_Pick1_end Mod 2 <> 0 Or .SaveOptions.nIntegralWL_Pick1_end < 380 Or .SaveOptions.nIntegralWL_Pick1_end > 780 Then
            '    MsgBox("JIG 1-8 Peak1 End 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
            '    Return False
            'End If

            'If .SaveOptions.nIntegralWL_Pick2_start Mod 2 <> 0 Or .SaveOptions.nIntegralWL_Pick2_start < 380 Or .SaveOptions.nIntegralWL_Pick2_start > 780 Then
            '    MsgBox("JIG 1-8 Peak2 Start 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
            '    Return False
            'End If

            'If .SaveOptions.nIntegralWL_Pick2_end Mod 2 <> 0 Or .SaveOptions.nIntegralWL_Pick2_end < 380 Or .SaveOptions.nIntegralWL_Pick2_end > 780 Then
            '    MsgBox("JIG 1-8 Peak2 End 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
            '    Return False
            'End If

            'If .SaveOptions.nIntegralWL_Pick3_Start Mod 2 <> 0 Or .SaveOptions.nIntegralWL_Pick3_Start < 380 Or .SaveOptions.nIntegralWL_Pick3_Start > 780 Then
            '    MsgBox("JIG 9-16 Peak1 Start 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
            '    Return False
            'End If

            'If .SaveOptions.nIntegralWL_Pick3_end Mod 2 <> 0 Or .SaveOptions.nIntegralWL_Pick3_end < 380 Or .SaveOptions.nIntegralWL_Pick3_end > 780 Then
            '    MsgBox("JIG 9-16 Peak1 End 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
            '    Return False
            'End If

            'If .SaveOptions.nIntegralWL_Pick4_start Mod 2 <> 0 Or .SaveOptions.nIntegralWL_Pick4_start < 380 Or .SaveOptions.nIntegralWL_Pick4_start > 780 Then
            '    MsgBox("JIG 9-16 Peak2 Start 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
            '    Return False
            'End If

            'If .SaveOptions.nIntegralWL_Pick4_end Mod 2 <> 0 Or .SaveOptions.nIntegralWL_Pick4_end < 380 Or .SaveOptions.nIntegralWL_Pick4_end > 780 Then
            '    MsgBox("JIG 9-16 Peak2 End 설정이 잘못되었습니다. 다시 설정해주십시오." & vbCrLf & "(Interval : 2nm, Range : 380~780)")
            '    Return False
            'End If


            ''각 Peak 지점의 Start 값이 End 값보다 작거나 같아야함
            'If .SaveOptions.nIntegralWL_Pick1_Start > .SaveOptions.nIntegralWL_Pick1_end Then
            '    MsgBox("JIG 1-8 Peak1 Start 값이 End 값보다 큽니다. 다시 설정해주십시오.")
            '    Return False
            'End If

            'If .SaveOptions.nIntegralWL_Pick2_start > .SaveOptions.nIntegralWL_Pick2_end Then
            '    MsgBox("JIG 1-8 Peak2 Start 값이 End 값보다 큽니다. 다시 설정해주십시오.")
            '    Return False
            'End If

            'If .SaveOptions.nIntegralWL_Pick3_Start > .SaveOptions.nIntegralWL_Pick3_end Then
            '    MsgBox("JIG 9-16 Peak1 Start 값이 End 값보다 큽니다. 다시 설정해주십시오.")
            '    Return False
            'End If

            'If .SaveOptions.nIntegralWL_Pick4_start > .SaveOptions.nIntegralWL_Pick4_end Then
            '    MsgBox("JIG 9-16 Peak2 Start 값이 End 값보다 큽니다. 다시 설정해주십시오.")
            '    Return False
            'End If

           
            'IVL Data format
            nDataListCnt = ucDispIVLDataIndex.GetListItemCount
            ReDim .SaveOptions.nDataIVLPlotItems(nDataListCnt - 1)
            ReDim .SaveOptions.nDataIVLPlotItemName(nDataListCnt - 1)
            For i As Integer = 0 To nDataListCnt - 1
                Dim sBufData() As String = Nothing
                ucDispIVLDataIndex.GetRowData(i, sBufData)
                .SaveOptions.nDataIVLPlotItems(i) = ConvertStringToIVLDataPlotItems(sBufData(0))
                .SaveOptions.nDataIVLPlotItemName(i) = sBufData(0)
            Next

            .SaveOptions.sIVLHeader.bFileversion = chkIVLFileversion.Checked
            .SaveOptions.sIVLHeader.bFilename = chkIVLFilename.Checked
            .SaveOptions.sIVLHeader.bMeasMode = chkIVLMeasMode.Checked
            .SaveOptions.sIVLHeader.bBiasMode = chkIVLBiasMode.Checked
            .SaveOptions.sIVLHeader.bSweepMode = chkIVLSweepMode.Checked
            .SaveOptions.sIVLHeader.bLuminanceMeasLevel = chkIVLLumiMeasLevel.Checked


            'Veiwing Angle Data format
            'nDataListCnt = ucDispVADataIndex.GetListItemCount
            'ReDim .SaveOptions.nDataVAPlotItems(nDataListCnt - 1)
            'ReDim .SaveOptions.nDataVAPlotItemName(nDataListCnt - 1)

            'For i As Integer = 0 To nDataListCnt - 1
            '    Dim sBufData() As String = Nothing
            '    ucDispVADataIndex.GetRowData(i, sBufData)
            '    .SaveOptions.nDataVAPlotItems(i) = ConvertStringToVADataPlotItems(sBufData(0))
            '    .SaveOptions.nDataVAPlotItemName(i) = sBufData(0)
            'Next

            '.SaveOptions.sVAHeader.bFileversion = chkVAFileversion.Checked
            '.SaveOptions.sVAHeader.bFilename = chkVAFilename.Checked
            '.SaveOptions.sVAHeader.bMeasMode = chkVAMeasMode.Checked
            '.SaveOptions.sVAHeader.bBiasMode = chkVABiasMode.Checked
            '.SaveOptions.sVAHeader.bSweepMode = chkVASweepMode.Checked

            'Lifetime Data format
            nDataListCnt = ucDispLTDataIndex.GetListItemCount
            ReDim .SaveOptions.nDataLTPlotItems(nDataListCnt - 1)
            ReDim .SaveOptions.nDataLTPlotItemName(nDataListCnt - 1)
            For i As Integer = 0 To nDataListCnt - 1
                Dim sBufData() As String = Nothing
                ucDispLTDataIndex.GetRowData(i, sBufData)
                .SaveOptions.nDataLTPlotItems(i) = ConvertStringToLTDataPlotItems(sBufData(0))
                .SaveOptions.nDataLTPlotItemName(i) = sBufData(0)
            Next

            .SaveOptions.sLifetimeHeader.bFileversion = chkLTFileversion.Checked
            .SaveOptions.sLifetimeHeader.bFilename = chkLTFilename.Checked
            .SaveOptions.sLifetimeHeader.bMeasMode = chkLTMeasMode.Checked
            .SaveOptions.sLifetimeHeader.bBiasMode = chkLTBiasMode.Checked
            .SaveOptions.sLifetimeHeader.bRenewalTime = chkLTRenewalTime.Checked

            'SpectrometerGain & Aperture
            If g_ConnectedSpectrometer = True Then  '연결될때만 체크한다.
                .Spectrometer.nIVLSweepGain = cbIVLSweepGain.SelectedIndex
                .Spectrometer.nLifetimeGain = cbLifetimeGain.SelectedIndex
                .Spectrometer.nAngleGain = cbAngleGain.SelectedIndex
                .Spectrometer.nAperture = cbAperture.SelectedIndex
                .Spectrometer.nSpeedMode = cbSpeedMode.SelectedIndex

                .IVLSpectrometer.nAperture = cbIVLSweepAperture.SelectedIndex
                .IVLSpectrometer.nSpeedMode = cbIVLSweepSpeedMode.SelectedIndex
                .IVLSpectrometer.nExposureTime = tbExposureTime.Text

                If chkSpectroMeasureMode.Checked = True Then
                    .IVLSpectrometer.MeasureMode = CSpectrometerLib.cDevCS2000A.eMeasureMode._Auto
                Else
                    .IVLSpectrometer.MeasureMode = CSpectrometerLib.cDevCS2000A.eMeasureMode._Manual
                End If
            End If

            'Visible Display Options
            If chkVisibleChannelMoveButton.Checked = True Then
                .VisibleDisplay.bChannelMoveButton = True
            Else
                .VisibleDisplay.bChannelMoveButton = False
            End If

            If chkVisibleAngleMoveButton.Checked = True Then
                .VisibleDisplay.bAngleMoveButton = True
            Else
                .VisibleDisplay.bAngleMoveButton = False
            End If

            'SampleInfos Options
            .SampleInfos.dHeight = tbSampleHeight.Text
            .SampleInfos.dWidth = tbSampleWidth.Text
            .SampleInfos.dFillFactor = tbFill.Text


            'sMaterialDatas Option
            '.MaterialData.sRed.dCIEx = tbRed_x.Text
            '.MaterialData.sRed.dCIEy = tbRed_y.Text
            '.MaterialData.sRed.dApertureRatio = tbRed_ApertureRatio.Text
            '.MaterialData.sRed.dTransmittancePolarizers = tbRed_TransmittancePolarizers.Text

            '.MaterialData.sGreen.dCIEx = tbGreen_x.Text
            '.MaterialData.sGreen.dCIEy = tbGreen_y.Text
            '.MaterialData.sGreen.dApertureRatio = tbGreen_ApertureRatio.Text
            '.MaterialData.sGreen.dTransmittancePolarizers = tbGreen_TransmittancePolarizers.Text

            '.MaterialData.sBlue.dCIEx = tbBlue_x.Text
            '.MaterialData.sBlue.dCIEy = tbBlue_y.Text
            '.MaterialData.sBlue.dApertureRatio = tbBlue_ApertureRatio.Text
            '.MaterialData.sBlue.dTransmittancePolarizers = tbBlue_TransmittancePolarizers.Text

            '.MaterialData.sWhite.dCIEx = tbWhite_x.Text
            '.MaterialData.sWhite.dCIEy = tbWhite_y.Text
            '.MaterialData.sWhite.dApertureRatio = tbWhite_ApertureRatio.Text
            '.MaterialData.sWhite.dTransmittancePolarizers = tbWhite_TransmittancePolarizers.Text
            '.MaterialData.sWhite.dBrightnessRequirements = tbWhite_BrightnessRequirements.Text


        End With

        Return True
    End Function

#End Region


#Region "Save/Load Option Function"

    Const sFileTitle As String = "System Option Information"
    Const sVersion As String = "1.0.0"

    Public Shared Function SaveSystemOption(ByVal optionInfos As sOPTIONDATa) As Boolean
        Dim fileInfo As CMcFile.sFILENAME = Nothing
        Dim optionLoader As New COptionINI(g_sFilePath_SystemOption)
        '지우기전에 Load한번 하고 시작한다.

        If g_ConnectedSpectrometer = False Then
            With optionInfos
                Try
                    .Spectrometer.nIVLSweepGain = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_GAIN_IVL))
                    .Spectrometer.nLifetimeGain = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_GAIN_LIFETIME))
                    .Spectrometer.nAngleGain = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_GAIN_ANGLE))
                    .Spectrometer.nAperture = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_APERTURE))
                    .Spectrometer.nSpeedMode = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_SPEEDMODE))
                    .IVLSpectrometer.nAperture = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_APERTURE))
                    .IVLSpectrometer.nSpeedMode = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_SPEEDMODE))
                    .IVLSpectrometer.nExposureTime = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_EXPOSURETIME))
                    .IVLSpectrometer.MeasureMode = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_MEASUREMODE))

                Catch ex As Exception
                    .Spectrometer.nIVLSweepGain = 1
                    .Spectrometer.nLifetimeGain = 1
                    .Spectrometer.nAngleGain = 1
                    .Spectrometer.nAperture = 0
                    .Spectrometer.nSpeedMode = 0
                    .IVLSpectrometer.nAperture = 0
                    .IVLSpectrometer.nSpeedMode = 0
                    .IVLSpectrometer.nExposureTime = 5000
                    .IVLSpectrometer.MeasureMode = CSpectrometerLib.cDevCS2000A.eMeasureMode._Auto
                End Try
            End With
        End If
        If Directory.Exists(g_sPATH_SYSTEM_OPTION) = False Then
            Directory.CreateDirectory(g_sPATH_SYSTEM_OPTION)
        End If

        If File.Exists(g_sFilePath_SystemOption) = True Then
            File.Delete(g_sFilePath_SystemOption)
        End If

        Try
            Dim optionSaver As New COptionINI(g_sFilePath_SystemOption)

            'Save File Infos
            optionSaver.SaveIniValue(COptionINI.eSecID.eFileInfo, 0, COptionINI.eKeyID.FILE_TITLE, sFileTitle)
            optionSaver.SaveIniValue(COptionINI.eSecID.eFileInfo, 0, COptionINI.eKeyID.FILE_VERSION, sVersion)

            With optionInfos

                'System Admin
                optionSaver.SaveIniValue(COptionINI.eSecID.eSystemAdmin, 0, COptionINI.eKeyID.ADMIN_PASS, .SystemAdmin.strPassword)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSystemAdmin, 0, COptionINI.eKeyID.ADMIN_LOGIN_STATUS, .SystemAdmin.bLogInStatus)

                optionSaver.SaveIniValue(COptionINI.eSecID.eSystemAdmin, 0, COptionINI.eKeyID.SAFETY_PASS, .SafetyAdmin.strPassword)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSystemAdmin, 0, COptionINI.eKeyID.SAFETY_LOGIN_STATUS, .SafetyAdmin.bLogInStatus)

                'Param Range

                optionSaver.SaveIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_HIGH_BIAS, .ParamRange.sPMX.Max.dBias)
                optionSaver.SaveIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_LOW_BIAS, .ParamRange.sPMX.Min.dBias)
                optionSaver.SaveIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_HIGH_AMPLITUDE, .ParamRange.sPMX.Max.dAmplitude)
                optionSaver.SaveIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_LOW_AMPLITUDE, .ParamRange.sPMX.Min.dAmplitude)
                optionSaver.SaveIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_HIGH_PULSE_DUTY, .ParamRange.sPMX.Max.Pulse.dDuty)
                optionSaver.SaveIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_LOW_PULSE_DUTY, .ParamRange.sPMX.Min.Pulse.dDuty)
                optionSaver.SaveIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_HIGH_PULSE_FREQUENCY, .ParamRange.sPMX.Max.Pulse.dFrequency)
                optionSaver.SaveIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_LOW_PULSE_FREQUENCY, .ParamRange.sPMX.Min.Pulse.dFrequency)
                'AMX Range 추가
                optionSaver.SaveIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.AMX_RANGE_HIGH_MAINPOWER, .ParamRange.sAMX.High.dMainPower)
                optionSaver.SaveIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.AMX_RANGE_LOW_MAINPOWER, .ParamRange.sAMX.Low.dMainPower)
                optionSaver.SaveIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.AMX_RANGE_HIGH_SUBPOWER, .ParamRange.sAMX.High.dSubPower)
                optionSaver.SaveIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.AMX_RANGE_LOW_SUBPOWER, .ParamRange.sAMX.Low.dSubPower)
                optionSaver.SaveIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.AMX_RANGE_HIGH_SIGNAL, .ParamRange.sAMX.High.dSignal)
                optionSaver.SaveIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.AMX_RANGE_LOW_SIGNAL, .ParamRange.sAMX.Low.dSignal)


                ''DISPLAY
                'Unit
                optionSaver.SaveIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_DIGIT_VOLTAGE, .DispGroup.dispVolt.nDispDigit)
                optionSaver.SaveIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_UNIT_VOLTAGE, .DispGroup.dispVolt.nUnit(0))

                optionSaver.SaveIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_DIGIT_CURRENT, .DispGroup.dispCurrent.nDispDigit)
                optionSaver.SaveIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_UNIT_CURRENT, .DispGroup.dispCurrent.nUnit(0))

                optionSaver.SaveIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_DIGIT_PHOTOCURRENT, .DispGroup.dispPhotocurrent.nDispDigit)
                optionSaver.SaveIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_UNIT_PHOTOCURRENT, .DispGroup.dispPhotocurrent.nUnit(0))

                optionSaver.SaveIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_DIGIT_INTEGRAL, .DispGroup.nIntegral)
                optionSaver.SaveIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_DIGIT_INTEGRALRELATIVE, .DispGroup.nIntegralRelative)

                'Disp Type
                optionSaver.SaveIniValue(COptionINI.eSecID.eDisplayCommon, 0, COptionINI.eKeyID.DISP_CH_DISP_TYPE, CInt(.DispGroup.ChDispType))

                'State Channel Color
                optionSaver.SaveIniValue(COptionINI.eSecID.eDisplayColor, 0, COptionINI.eKeyID.DISP_COLOR_NUM_OF_STATE, .StateSetting.NumOfState)

                For idx As Integer = 0 To .StateSetting.NumOfState - 1
                    optionSaver.SaveIniValue(COptionINI.eSecID.eDisplayColor, idx, COptionINI.eKeyID.DISP_COLOR_STATE, .StateSetting.StatusColor(idx).g_status.ToString)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eDisplayColor, idx, COptionINI.eKeyID.DISP_COLOR_VALUE, .StateSetting.StatusColor(idx).g_lineColor)
                Next


                'Constant Bright
                'optionSaver.SaveIniValue(COptionINI.eSecID.eConstantBrightness, 0, COptionINI.eKeyID.CONSTANT_B_CAL_APPLY, .CalData.bCalDataApply)
                'optionSaver.SaveIniValue(COptionINI.eSecID.eConstantBrightness, 0, COptionINI.eKeyID.CONSTANT_B_DEGREE, .CalData.Degree)
                'optionSaver.SaveIniValue(COptionINI.eSecID.eConstantBrightness, 0, COptionINI.eKeyID.CONSTANT_B_PD_DEVIATION, .ConsBright.dPDDeviation)
                'optionSaver.SaveIniValue(COptionINI.eSecID.eConstantBrightness, 0, COptionINI.eKeyID.CONSTANT_B_BIAS_RANGE_CC, .ConsBright.dBiasRangeLV_CC)
                'optionSaver.SaveIniValue(COptionINI.eSecID.eConstantBrightness, 0, COptionINI.eKeyID.CONSTANT_B_BIAS_RANGE_CV, .ConsBright.dBiasRangeLV_CV)


                'Number Of Outdata display (MDX0
                For idx As Integer = 0 To 4
                    optionSaver.SaveIniValue(COptionINI.eSecID.OutDataDisplay_MDX, 0, COptionINI.eKeyID.NUMOF_OUTDATA_DISPLAY_MDX, idx, .bMDXOutData(idx))
                Next

                'Link
                optionSaver.SaveIniValue(COptionINI.eSecID.eLink, 0, COptionINI.eKeyID.LINK_ENABLE_DATA_VIEWER_LINK, .bEnableDataViewerLink_IVL.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eLink, 0, COptionINI.eKeyID.LINK_PATH_OF_DATA_VIEWER, .sPathOfDataViewer_IVL)

                optionSaver.SaveIniValue(COptionINI.eSecID.eLink, 1, COptionINI.eKeyID.LINK_ENABLE_DATA_VIEWER_LINK, .bEnableDataViewerLink_LT.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eLink, 1, COptionINI.eKeyID.LINK_PATH_OF_DATA_VIEWER, .sPathOfDataViewer_LT)

                'Auto Focusing & Centering Options
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.ACF_MODE, CStr(.ACFData.sSoruceMode))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.FOCUSING_REGION_START, .ACFData.dACFRegion_Start)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.FOCUSING_REGION_STOP, .ACFData.dACFRegion_Stop)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.FOCUSING_SCAN_RESOLUTION, .ACFData.dScanResolution)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.FOCUSING_PARAM, .ACFData.nFocusParam)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.DEFINE_THRESHOLD, .ACFData.nDefThreshold)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.LOW_INTENSITY_THRESHOLD, .ACFData.nLowThreshold)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.HIGH_INTENSITY_THRESHOLD, .ACFData.nHighThreshold)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_RESOLUTION_WIDTH, .ACFData.nCCDResolutionWidth)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_RESOLUTION_HIGH, .ACFData.nCCDResolutionHigh)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_SPECTROMETER_DISTANCE_X, .ACFData.dCCDtoSpectrometerPosX)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_SPECTROMETER_DISTANCE_Y, .ACFData.dCCDtoSpectrometerPosY)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_SPECTROMETER_DISTANCE_Z, .ACFData.dCCDtoSpectrometerPosZ)
                'CCD to HEXA Distance
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_HEXA_DISTANCE_X, .ACFData.dCCDtoHEXAPosX)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_HEXA_DISTANCE_Y, .ACFData.dCCDtoHEXAPosY)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_HEXA_DISTANCE_Z, .ACFData.dCCDtoHEXAPosZ)

                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_MCR_DISTANCE_X, .ACFData.dCCDtoMCRPosX)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_MCR_DISTANCE_Y, .ACFData.dCCDtoMCRPosY)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_MCR_DISTANCE_Z, .ACFData.dCCDtoMCRPosZ)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_POSITION_X, .ACFData.dCCDPosX)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_POSITION_Y, .ACFData.dCCDPosY)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_POSITION_Z, .ACFData.dCCDPosZ)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.SPECTROMETER_POSITION_X, .ACFData.dSpectrometerPosX)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.SPECTROMETER_POSITION_Y, .ACFData.dSpectrometerPosY)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.SPECTROMETER_POSITION_Z, .ACFData.dSpectrometerPosZ)
                'Hexa Position
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.HEXA_POSITION_X, .ACFData.dHEXAPosX)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.HEXA_POSITION_Y, .ACFData.dHEXAPosY)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.HEXA_POSITION_Z, .ACFData.dHEXAPosZ)

                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.BLOD_FILTER, .ACFData.eBlobFilter.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.MIN_BLOB_RADIUS, .ACFData.nMinBlobRadius)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.PIXEL_PER_DISTANCE_WIDTH, .ACFData.dPixelPerDistance_1mm_Width)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.PIXEL_PER_DISTANCE_HIGH, .ACFData.dPixelPerDistance_1mm_High)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.LOW_INTENSITY_LIMIT, .ACFData.dLowIntensityLimit)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.GRAY_LEVEL_LIMIT, .ACFData.nGrayLevelLimit)

                'ACF Intensity Adjust
                'Cell
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SOURCEMODE, CDbl(.ACFData.sSoruceMode))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_BIAS, CDbl(.ACFData.dIntensityAdj_Bias))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_STEP, CDbl(.ACFData.dIntensityAdj_Step))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_LIMIT, CDbl(.ACFData.dIntensityAdj_Limit))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_SRC_MODE, CInt(.ACFData.sIntensityAdj_Settings.SourceMode))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_WIRE_MODE, CInt(.ACFData.sIntensityAdj_Settings.WireMode))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_LIMIT_V, CDbl(.ACFData.sIntensityAdj_Settings.LimitVoltage))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_LIMIT_I, CDbl(.ACFData.sIntensityAdj_Settings.LimitCurrent))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_CURRENG_RANGE, CInt(.ACFData.sIntensityAdj_Settings.nCurrentRangeIndex))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_TERMINAL_MODE, CInt(.ACFData.sIntensityAdj_Settings.TerminalMode))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_MEAS_MODE, CInt(.ACFData.sIntensityAdj_Settings.MeasureMode))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_NUM_OF_MEASDATA, CStr(.ACFData.sIntensityAdj_Settings.NumOfMeasData))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_MEAS_DELAY_SEC, CStr(.ACFData.sIntensityAdj_Settings.MeasureDelay_Sec))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_INTEG_TIME_SEC, CStr(.ACFData.sIntensityAdj_Settings.IntegTime_Sec))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_INTEG_TIME_INDEX, CStr(.ACFData.sIntensityAdj_Settings.nIntegTimeIndex))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_VOLTAGE_RANGE, CInt(.ACFData.sIntensityAdj_Settings.nVoltageRangeIndex))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_MEAS_VAL_TYPE, CInt(.ACFData.sIntensityAdj_Settings.MeasureValueType))
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_MEAS_DELAY_AUTO, CStr(.ACFData.sIntensityAdj_Settings.MeasureDelayAuto))


                'Module
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.MODULE_CONDITION_PATTERN_NO, CStr(.ACFData.nModulePatternNo))

                'Motion Pos To Real Distance
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.STANDARD_DISTANCE_X, .MotionData.sStandardDistance.dAxis_X)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.STANDARD_DISTANCE_Y, .MotionData.sStandardDistance.dAxis_Y)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.STANDARD_DISTANCE_Z, .MotionData.sStandardDistance.dAxis_Z)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.STANDARD_DISTANCE_Theta_Y, .MotionData.sStandardDistance.dAxis_Theta_Y)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.STANDARD_DISTANCE_Theta, .MotionData.sStandardDistance.dAxis_Theta)

                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.START_POSITION_X, .MotionData.sStartPos.dAxis_X)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.START_POSITION_Y, .MotionData.sStartPos.dAxis_Y)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.START_POSITION_Z, .MotionData.sStartPos.dAxis_Z)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.START_POSITION_Theta_Y, .MotionData.sStartPos.dAxis_Theta_Y)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.START_POSITION_Theta, .MotionData.sStartPos.dAxis_Theta)

                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.END_POSITION_X, .MotionData.sEndPos.dAxis_X)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.END_POSITION_Y, .MotionData.sEndPos.dAxis_Y)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.END_POSITION_Z, .MotionData.sEndPos.dAxis_Z)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.END_POSITION_Theta_Y, .MotionData.sEndPos.dAxis_Theta_Y)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.END_POSITION_Theta, .MotionData.sEndPos.dAxis_Theta)

                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_POSITION_X, .MotionData.sCalPos.dAxis_X)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_POSITION_Y, .MotionData.sCalPos.dAxis_Y)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_POSITION_Z, .MotionData.sCalPos.dAxis_Z)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_POSITION_Theta_Y, .MotionData.sCalPos.dAxis_Theta_Y)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_POSITION_Theta, .MotionData.sCalPos.dAxis_Theta)

                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.POSITION_PER_DISTANCE_X, .MotionData.sCalPosPerDistance.dAxis_X)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.POSITION_PER_DISTANCE_Y, .MotionData.sCalPosPerDistance.dAxis_Y)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.POSITION_PER_DISTANCE_Z, .MotionData.sCalPosPerDistance.dAxis_Z)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.POSITION_PER_DISTANCE_Theta_Y, .MotionData.sCalPosPerDistance.dAxis_Theta_Y)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.POSITION_PER_DISTANCE_Theta, .MotionData.sCalPosPerDistance.dAxis_Theta)

                'Theta Calibration Factor -20170414
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_THETA_DEVIATION, .MotionData.sThetaCal.dDeviation)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_THETA_RATIO, .MotionData.sThetaCal.dRatio)
                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_THETA_OFFSET, .MotionData.sThetaCal.dOffset)

                'WAD Calibration Factor -20170414
                For idx As Integer = 0 To .MotionData.sWADCalFactor.dWAD_X.Length - 1
                    optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_WAD_FACTOR_X, idx, .MotionData.sWADCalFactor.dWAD_X(idx))
                Next

                For idx As Integer = 0 To .MotionData.sWADCalFactor.dWAD_Y.Length - 1
                    optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_WAD_FACTOR_Y, idx, .MotionData.sWADCalFactor.dWAD_Y(idx))
                Next

                For idx As Integer = 0 To .MotionData.sWADCalFactor.dWAD_Z.Length - 1
                    optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_WAD_FACTOR_Z, idx, .MotionData.sWADCalFactor.dWAD_Z(idx))
                Next


                'Contact Check
                optionSaver.SaveIniValue(COptionINI.eSecID.eCheckContact, 0, COptionINI.eKeyID.CONTACT_BIAS, .sCheckContact.dContactBias)
                optionSaver.SaveIniValue(COptionINI.eSecID.eCheckContact, 0, COptionINI.eKeyID.CONTACT_PASSLV, .sCheckContact.dPassLevel)
                optionSaver.SaveIniValue(COptionINI.eSecID.eCheckContact, 0, COptionINI.eKeyID.CONTACT_MARGIN, .sCheckContact.dBiasMargin)

                optionSaver.SaveIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.POSITION_PER_DISTANCE_USE, .MotionData.bCalPosPerDistanceUse.ToString)

                'Temp
                optionSaver.SaveIniValue(COptionINI.eSecID.eTemperature, 0, COptionINI.eKeyID.TEMPERATURE_MARGIN, .TemperatureData.dMargin)
                optionSaver.SaveIniValue(COptionINI.eSecID.eTemperature, 0, COptionINI.eKeyID.TEMPERATURE_LIMIT_ALARM_LOW, .TemperatureData.dLimitAlarmLow)
                optionSaver.SaveIniValue(COptionINI.eSecID.eTemperature, 0, COptionINI.eKeyID.TEMPERATURE_LIMIT_ALARM_HIGH, .TemperatureData.dLimitAlarmHigh)

                'CCD
                optionSaver.SaveIniValue(COptionINI.eSecID.eCCD, 0, COptionINI.eKeyID.CCD_EXPOSURE_VALUE, .CCDData.dCCDExposureValue)
                optionSaver.SaveIniValue(COptionINI.eSecID.eCCD, 0, COptionINI.eKeyID.CCD_CAPTURE_IMAGE_PATH, .CCDData.strCaptureCCDPath)
                optionSaver.SaveIniValue(COptionINI.eSecID.eCCD, 0, COptionINI.eKeyID.CCD_CAPTURE_IMAGE_LEVEL, .CCDData.dCaptureLevel)
                optionSaver.SaveIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.IMAGE_ANALYSIS_MODE, CInt(.CCDData.ImageAnalysisMode))


                'Save Options
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_FILE_NAME_RULE_ADD_CH_NUM, .SaveOptions.bFileName_AddChNum.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_FILE_NAME_RULE_ADD_DATE, .SaveOptions.bFileName_AddDate.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_FILE_NAME_RULE_ADD_EXP_MODE, .SaveOptions.bFileName_AddExpMode.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_FILE_NAME_RULE_ADD_USER_INPUT, .SaveOptions.bFileName_AddUserInput.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_DEFAULT_PATH, .SaveOptions.sDefaultSavePath)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_LUMINANCE_PERCENT_SPECTRUM_DATA_SAVE, .SaveOptions.dLuminancePerSpectrumSave)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_FILETYPE, .SaveOptions.nFileType)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_CAL_REAL_CURRENT, .SaveOptions.bCalRealCurrentSave.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_FILE_NAME_RULE_TEG_TO_TEGCHANNEL, .SaveOptions.bFilenameTEGtoTEGChannel.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 1, COptionINI.eKeyID.SAVE_IVLDATAINDEXCOUNT, .SaveOptions.nDataIVLPlotItems.Length)

                'Peak 관련
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_BACKUP_PATH, .SaveOptions.sBackupSavePath)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_USED_BACKUP_PATH, .SaveOptions.bUsedBackupPath)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK1_START, .SaveOptions.nIntegralWL_Pick1_Start)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK1_END, .SaveOptions.nIntegralWL_Pick1_end)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK2_START, .SaveOptions.nIntegralWL_Pick2_start)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK2_END, .SaveOptions.nIntegralWL_Pick2_end)

                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK3_START, .SaveOptions.nIntegralWL_Pick3_Start)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK3_END, .SaveOptions.nIntegralWL_Pick3_end)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK4_START, .SaveOptions.nIntegralWL_Pick4_start)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK4_END, .SaveOptions.nIntegralWL_Pick4_end)

                'optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG17_24_PICK1_START, .SaveOptions.nJIG17_24_Pick1_Start)
                'optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG17_24_PICK1_END, .SaveOptions.nJIG17_24_Pick1_end)
                'optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG17_24_PICK2_START, .SaveOptions.nJIG17_24_Pick2_start)
                'optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG17_24_PICK2_END, .SaveOptions.nJIG17_24_Pick2_end)

                'optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG25_32_PICK1_START, .SaveOptions.nJIG25_32_Pick1_Start)
                'optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG25_32_PICK1_END, .SaveOptions.nJIG25_32_Pick1_end)
                'optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG25_32_PICK2_START, .SaveOptions.nJIG25_32_Pick2_start)
                'optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG25_32_PICK2_END, .SaveOptions.nJIG25_32_Pick2_end)

                For i As Integer = 0 To .SaveOptions.nDataIVLPlotItems.Length - 1
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 1, COptionINI.eKeyID.SAVE_IVLDATAINDEX, i, .SaveOptions.nDataIVLPlotItems(i))
                Next
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 1, COptionINI.eKeyID.SAVE_LTDATAINDEXCOUNT, .SaveOptions.nDataLTPlotItems.Length)
                For i As Integer = 0 To .SaveOptions.nDataLTPlotItems.Length - 1
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 1, COptionINI.eKeyID.SAVE_LTDATAINDEX, i, .SaveOptions.nDataLTPlotItems(i))
                Next

                'optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 1, COptionINI.eKeyID.SAVE_VADATAINDEXCOUNT, .SaveOptions.nDataVAPlotItems.Length)
                'For i As Integer = 0 To .SaveOptions.nDataVAPlotItems.Length - 1
                '    optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 1, COptionINI.eKeyID.SAVE_VADATAINDEX, i, .SaveOptions.nDataVAPlotItems(i))
                'Next

                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_IVLHEADER_FILEVERSION, .SaveOptions.sIVLHeader.bFileversion.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_IVLHEADER_FILENAME, .SaveOptions.sIVLHeader.bFilename.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_IVLHEADER_MEASMODE, .SaveOptions.sIVLHeader.bMeasMode.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_IVLHEADER_BIASMODE, .SaveOptions.sIVLHeader.bBiasMode.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_IVLHEADER_SWEEPMODE, .SaveOptions.sIVLHeader.bSweepMode.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_IVLHEADER_LUMINANCEMEASLEVEL, .SaveOptions.sIVLHeader.bLuminanceMeasLevel.ToString)

                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_LTHEADER_FILEVERSION, .SaveOptions.sLifetimeHeader.bFileversion.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_LTHEADER_FILENAME, .SaveOptions.sLifetimeHeader.bFilename.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_LTHEADER_MEASMODE, .SaveOptions.sLifetimeHeader.bMeasMode.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_LTHEADER_BIASMODE, .SaveOptions.sLifetimeHeader.bBiasMode.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_LTHEADER_RENEWALTIME, .SaveOptions.sLifetimeHeader.bRenewalTime.ToString)

                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_VAHEADER_FILEVERSION, .SaveOptions.sVAHeader.bFileversion.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_VAHEADER_FILENAME, .SaveOptions.sVAHeader.bFilename.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_VAHEADER_MEASMODE, .SaveOptions.sVAHeader.bMeasMode.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_VAHEADER_BIASMODE, .SaveOptions.sVAHeader.bBiasMode.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_VAHEADER_SWEEPMODE, .SaveOptions.sVAHeader.bSweepMode.ToString)


                'Spectrometer   'Save는 Spectrometer가 연결되어 있을때만 한다.
                If g_ConnectedSpectrometer = True Then  '연결되어있을때는 설정된 정보를 저장한다.
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_GAIN_IVL, .Spectrometer.nIVLSweepGain)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_GAIN_LIFETIME, .Spectrometer.nLifetimeGain)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_GAIN_ANGLE, .Spectrometer.nAngleGain)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_APERTURE, .Spectrometer.nAperture)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_SPEEDMODE, .Spectrometer.nSpeedMode)

                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_APERTURE, .IVLSpectrometer.nAperture)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_SPEEDMODE, .IVLSpectrometer.nSpeedMode)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_EXPOSURETIME, .IVLSpectrometer.nExposureTime)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_MEASUREMODE, .IVLSpectrometer.MeasureMode)
                Else    '연결되지 않았을때는 기존 정보를 불러온 후 Save한다.

                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_GAIN_IVL, .Spectrometer.nIVLSweepGain)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_GAIN_LIFETIME, .Spectrometer.nLifetimeGain)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_GAIN_ANGLE, .Spectrometer.nAngleGain)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_APERTURE, .Spectrometer.nAperture)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_SPEEDMODE, .Spectrometer.nSpeedMode)

                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_APERTURE, .IVLSpectrometer.nAperture)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_SPEEDMODE, .IVLSpectrometer.nSpeedMode)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_EXPOSURETIME, .IVLSpectrometer.nExposureTime)
                    optionSaver.SaveIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_MEASUREMODE, .IVLSpectrometer.MeasureMode)

                End If

                'Visible Display Options
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.VISIBLE_DISPLAY_CHANNEL_MOVE_BUTTON, .VisibleDisplay.bChannelMoveButton.ToString)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.VISIBLE_DISPLAY_ANGLE_MOVE_BUTTON, .VisibleDisplay.bAngleMoveButton.ToString)

                'SampleInfos Options
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAMPLEINFO_HEIGHT, .SampleInfos.dHeight)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAMPLEINFO_WIDTH, .SampleInfos.dWidth)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAMPLEINFO_FILLFACTOR, .SampleInfos.dFillFactor)


                'sMaterialDatas Option
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_RED_CIEx, .MaterialData.sRed.dCIEx)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_RED_CIEy, .MaterialData.sRed.dCIEy)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_RED_APERTURERATIO, .MaterialData.sRed.dApertureRatio)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_RED_TRANSMITTANCEPOLARIZERS, .MaterialData.sRed.dTransmittancePolarizers)

                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_GREEN_CIEx, .MaterialData.sGreen.dCIEx)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_GREEN_CIEy, .MaterialData.sGreen.dCIEy)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_GREEN_APERTURERATIO, .MaterialData.sGreen.dApertureRatio)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_GREEN_TRANSMITTANCEPOLARIZERS, .MaterialData.sGreen.dTransmittancePolarizers)

                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_BLUE_CIEx, .MaterialData.sBlue.dCIEx)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_BLUE_CIEy, .MaterialData.sBlue.dCIEy)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_BLUE_APERTURERATIO, .MaterialData.sBlue.dApertureRatio)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_BLUE_TRANSMITTANCEPOLARIZERS, .MaterialData.sBlue.dTransmittancePolarizers)

                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_WHITE_CIEx, .MaterialData.sWhite.dCIEx)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_WHITE_CIEy, .MaterialData.sWhite.dCIEy)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_WHITE_APERTURERATIO, .MaterialData.sWhite.dApertureRatio)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_WHITE_TRANSMITTANCEPOLARIZERS, .MaterialData.sWhite.dTransmittancePolarizers)
                optionSaver.SaveIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_WHITE_BRIGHTNESSREQUIREMENTS, .MaterialData.sWhite.dBrightnessRequirements)

            End With
        Catch ex As Exception

            Return False
        End Try

        Return True
    End Function

    Public Shared Function LoadSystemOption(ByRef optionInfos As sOPTIONDATa) As Boolean

        Dim sTemp As String

        If File.Exists(g_sFilePath_SystemOption) = False Then
            Return False
        End If

        Dim optionLoader As New COptionINI(g_sFilePath_SystemOption)

        'Load File Infos
        Try


            sTemp = optionLoader.LoadIniValue(COptionINI.eSecID.eFileInfo, 0, COptionINI.eKeyID.FILE_TITLE)
            If sTemp <> sFileTitle Then Return False
            sTemp = optionLoader.LoadIniValue(COptionINI.eSecID.eFileInfo, 0, COptionINI.eKeyID.FILE_VERSION)
            If sTemp <> sVersion Then Return False

            With optionInfos

                'System Admin
                Try
                    .SystemAdmin.strPassword = optionLoader.LoadIniValue(COptionINI.eSecID.eSystemAdmin, 0, COptionINI.eKeyID.ADMIN_PASS)
                    .SystemAdmin.bLogInStatus = optionLoader.LoadIniValue(COptionINI.eSecID.eSystemAdmin, 0, COptionINI.eKeyID.ADMIN_LOGIN_STATUS)

                    .SafetyAdmin.strPassword = optionLoader.LoadIniValue(COptionINI.eSecID.eSystemAdmin, 0, COptionINI.eKeyID.SAFETY_PASS)
                    .SafetyAdmin.bLogInStatus = optionLoader.LoadIniValue(COptionINI.eSecID.eSystemAdmin, 0, COptionINI.eKeyID.SAFETY_LOGIN_STATUS)
                Catch ex As Exception

                End Try

                'Param Range Settings 
                .ParamRange.sPMX.Max.dBias = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_HIGH_BIAS))
                .ParamRange.sPMX.Min.dBias = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_LOW_BIAS))
                .ParamRange.sPMX.Max.dAmplitude = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_HIGH_AMPLITUDE))
                .ParamRange.sPMX.Min.dAmplitude = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_LOW_AMPLITUDE))
                .ParamRange.sPMX.Max.Pulse.dDuty = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_HIGH_PULSE_DUTY))
                .ParamRange.sPMX.Min.Pulse.dDuty = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_LOW_PULSE_DUTY))
                .ParamRange.sPMX.Max.Pulse.dFrequency = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_HIGH_PULSE_FREQUENCY))
                .ParamRange.sPMX.Min.Pulse.dFrequency = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.PMX_RANGE_LOW_PULSE_FREQUENCY))

                .ParamRange.sAMX.High.dMainPower = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.AMX_RANGE_HIGH_MAINPOWER))
                .ParamRange.sAMX.Low.dMainPower = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.AMX_RANGE_LOW_MAINPOWER))
                .ParamRange.sAMX.High.dSubPower = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.AMX_RANGE_HIGH_SUBPOWER))
                .ParamRange.sAMX.Low.dSubPower = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.AMX_RANGE_LOW_SUBPOWER))
                .ParamRange.sAMX.High.dSignal = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.AMX_RANGE_HIGH_SIGNAL))
                .ParamRange.sAMX.Low.dSignal = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eParameterRange, 0, COptionINI.eKeyID.AMX_RANGE_LOW_SIGNAL))


                ''DISPLAY
                'Digit/Unit
                ReDim .DispGroup.dispVolt.nUnit(0)
                ReDim .DispGroup.dispCurrent.nUnit(0)
                ReDim .DispGroup.dispPhotocurrent.nUnit(0)

                .DispGroup.dispVolt.nDispDigit = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_DIGIT_VOLTAGE))
                .DispGroup.dispVolt.nUnit(0) = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_UNIT_VOLTAGE))
                .DispGroup.dispVolt.nTypeOfVal = CUnitConverter.eType.Voltage
                .DispGroup.dispCurrent.nDispDigit = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_DIGIT_CURRENT))
                .DispGroup.dispCurrent.nUnit(0) = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_UNIT_CURRENT))
                .DispGroup.dispCurrent.nTypeOfVal = CUnitConverter.eType.Ampere
                .DispGroup.dispPhotocurrent.nDispDigit = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_DIGIT_PHOTOCURRENT))
                .DispGroup.dispPhotocurrent.nUnit(0) = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_UNIT_PHOTOCURRENT))
                .DispGroup.dispPhotocurrent.nTypeOfVal = CUnitConverter.eType.Ampere

                Try
                    .DispGroup.nIntegral = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_DIGIT_INTEGRAL))
                Catch ex As Exception
                    .DispGroup.nIntegral = 0
                End Try
                Try
                    .DispGroup.nIntegralRelative = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eDisplayUnit, 0, COptionINI.eKeyID.DISP_DIGIT_INTEGRALRELATIVE))
                Catch ex As Exception
                    .DispGroup.nIntegralRelative = 0
                End Try
                'Disp Type
                Try
                    .DispGroup.ChDispType = optionLoader.LoadIniValue(COptionINI.eSecID.eDisplayCommon, 0, COptionINI.eKeyID.DISP_CH_DISP_TYPE)
                Catch ex As Exception
                    .DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel
                End Try


                'State Channel Color
                Dim Cnt As Integer = 0

                .StateSetting.NumOfState = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eDisplayColor, 0, COptionINI.eKeyID.DISP_COLOR_NUM_OF_STATE))

                Cnt = .StateSetting.NumOfState

                ReDim .StateSetting.StatusColor(Cnt - 1)

                For idx As Integer = 0 To .StateSetting.NumOfState - 1
                    .StateSetting.StatusColor(idx).g_status = optionLoader.LoadIniValue(COptionINI.eSecID.eDisplayColor, idx, COptionINI.eKeyID.DISP_COLOR_STATE)
                    .StateSetting.StatusColor(idx).g_lineColor = optionLoader.LoadIniValue(COptionINI.eSecID.eDisplayColor, idx, COptionINI.eKeyID.DISP_COLOR_VALUE)
                Next


                'Constant Bright
                '.CalData.bCalDataApply = CBool(optionLoader.LoadIniValue(COptionINI.eSecID.eConstantBrightness, 0, COptionINI.eKeyID.CONSTANT_B_CAL_APPLY))
                '.CalData.Degree = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eConstantBrightness, 0, COptionINI.eKeyID.CONSTANT_B_DEGREE))
                '.ConsBright.dPDDeviation = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eConstantBrightness, 0, COptionINI.eKeyID.CONSTANT_B_PD_DEVIATION))
                '.ConsBright.dBiasRangeLV_CC = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eConstantBrightness, 0, COptionINI.eKeyID.CONSTANT_B_BIAS_RANGE_CC))
                '.ConsBright.dBiasRangeLV_CV = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eConstantBrightness, 0, COptionINI.eKeyID.CONSTANT_B_BIAS_RANGE_CV))


                'Number of Outdata display MDX
                ReDim .bMDXOutData(4)
                For idx As Integer = 0 To 4
                    .bMDXOutData(idx) = CBool(optionLoader.LoadIniValue(COptionINI.eSecID.OutDataDisplay_MDX, 0, COptionINI.eKeyID.NUMOF_OUTDATA_DISPLAY_MDX, idx))
                Next

                'Link
                Try
                    .bEnableDataViewerLink_IVL = optionLoader.LoadIniValue(COptionINI.eSecID.eLink, 0, COptionINI.eKeyID.LINK_ENABLE_DATA_VIEWER_LINK)
                Catch ex As Exception
                    .bEnableDataViewerLink_IVL = False
                End Try
                .sPathOfDataViewer_IVL = optionLoader.LoadIniValue(COptionINI.eSecID.eLink, 0, COptionINI.eKeyID.LINK_PATH_OF_DATA_VIEWER)

                Try
                    .bEnableDataViewerLink_LT = optionLoader.LoadIniValue(COptionINI.eSecID.eLink, 1, COptionINI.eKeyID.LINK_ENABLE_DATA_VIEWER_LINK)
                Catch ex As Exception
                    .bEnableDataViewerLink_LT = False
                End Try
                .sPathOfDataViewer_LT = optionLoader.LoadIniValue(COptionINI.eSecID.eLink, 1, COptionINI.eKeyID.LINK_PATH_OF_DATA_VIEWER)


                ''Auto Focusing & Centering Options
                Try
                    .ACFData.nACFMode = optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.ACF_MODE)
                Catch ex As Exception
                    .ACFData.nACFMode = eACFMode.eDisable_FixedPosition
                End Try

                .ACFData.dACFRegion_Start = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.FOCUSING_REGION_START))
                .ACFData.dACFRegion_Stop = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.FOCUSING_REGION_STOP))
                .ACFData.dScanResolution = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.FOCUSING_SCAN_RESOLUTION))
                .ACFData.nFocusParam = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.FOCUSING_PARAM))
                .ACFData.nDefThreshold = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.DEFINE_THRESHOLD))
                .ACFData.nLowThreshold = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.LOW_INTENSITY_THRESHOLD))
                .ACFData.nHighThreshold = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.HIGH_INTENSITY_THRESHOLD))
                .ACFData.nCCDResolutionHigh = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_RESOLUTION_HIGH))
                .ACFData.nCCDCenterPos_Y = CInt(.ACFData.nCCDResolutionHigh / 2)
                .ACFData.nCCDResolutionWidth = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_RESOLUTION_WIDTH))
                .ACFData.nCCDCenterPos_X = CInt(.ACFData.nCCDResolutionWidth / 2)
                .ACFData.dCCDtoSpectrometerPosX = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_SPECTROMETER_DISTANCE_X))
                .ACFData.dCCDtoSpectrometerPosY = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_SPECTROMETER_DISTANCE_Y))
                .ACFData.dCCDtoSpectrometerPosZ = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_SPECTROMETER_DISTANCE_Z))

                'CCD to HEXA Position
                Try
                    .ACFData.dCCDtoHEXAPosX = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_HEXA_DISTANCE_X))
                    .ACFData.dCCDtoHEXAPosY = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_HEXA_DISTANCE_Y))
                    .ACFData.dCCDtoHEXAPosZ = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_HEXA_DISTANCE_Z))
                Catch ex As Exception
                    .ACFData.dCCDtoHEXAPosX = 0
                    .ACFData.dCCDtoHEXAPosY = 0
                    .ACFData.dCCDtoHEXAPosZ = 0
                End Try

                Try
                    .ACFData.dCCDtoMCRPosX = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_MCR_DISTANCE_X))
                    .ACFData.dCCDtoMCRPosY = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_MCR_DISTANCE_Y))
                    .ACFData.dCCDtoMCRPosZ = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_TO_MCR_DISTANCE_Z))

                Catch ex As Exception
                    .ACFData.dCCDtoMCRPosX = 0
                    .ACFData.dCCDtoMCRPosY = 0
                    .ACFData.dCCDtoMCRPosZ = 0

                End Try

                .ACFData.dCCDPosX = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_POSITION_X))
                .ACFData.dCCDPosY = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_POSITION_Y))
                .ACFData.dCCDPosZ = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.CCD_POSITION_Z))
                .ACFData.dSpectrometerPosX = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.SPECTROMETER_POSITION_X))
                .ACFData.dSpectrometerPosY = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.SPECTROMETER_POSITION_Y))
                .ACFData.dSpectrometerPosZ = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.SPECTROMETER_POSITION_Z))

                'HEXA Position
                Try
                    .ACFData.dHEXAPosX = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.HEXA_POSITION_X))
                    .ACFData.dHEXAPosY = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.HEXA_POSITION_Y))
                    .ACFData.dHEXAPosZ = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.HEXA_POSITION_Z))
                Catch ex As Exception
                    .ACFData.dHEXAPosX = 0
                    .ACFData.dHEXAPosY = 0
                    .ACFData.dHEXAPosZ = 0
                End Try

                sTemp = optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.BLOD_FILTER)
                If eBlobFilter.EXCLUDE_AREA_LESS_EQUAL_50.ToString() = sTemp Then
                    .ACFData.eBlobFilter = eBlobFilter.EXCLUDE_AREA_LESS_EQUAL_50
                ElseIf eBlobFilter.EXCLUDE_AREA_OUT_RANGE_1000_50000.ToString() = sTemp Then
                    .ACFData.eBlobFilter = eBlobFilter.EXCLUDE_AREA_OUT_RANGE_1000_50000
                ElseIf eBlobFilter.EXCLUDE_AREA_OUT_RANGE_50_50000.ToString() = sTemp Then
                    .ACFData.eBlobFilter = eBlobFilter.EXCLUDE_AREA_OUT_RANGE_50_50000
                ElseIf eBlobFilter.EXCLUDE_COMPACTNESS_LESS_EQUAL_1_5.ToString() = sTemp Then
                    .ACFData.eBlobFilter = eBlobFilter.EXCLUDE_COMPACTNESS_LESS_EQUAL_1_5
                Else

                End If

                .ACFData.nMinBlobRadius = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.MIN_BLOB_RADIUS))
                .ACFData.dPixelPerDistance_1mm_High = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.PIXEL_PER_DISTANCE_HIGH))
                .ACFData.dDistanceOfOnePixel_Y = 1 / .ACFData.dPixelPerDistance_1mm_High
                .ACFData.dPixelPerDistance_1mm_Width = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.PIXEL_PER_DISTANCE_WIDTH))
                .ACFData.dDistanceOfOnePixel_X = 1 / .ACFData.dPixelPerDistance_1mm_Width
                .ACFData.dLowIntensityLimit = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.LOW_INTENSITY_LIMIT))
                .ACFData.nGrayLevelLimit = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.GRAY_LEVEL_LIMIT))

                'ACF Intensity Adjust
                Try
                    'Cell
                    .ACFData.sSoruceMode = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SOURCEMODE))
                    .ACFData.dIntensityAdj_Bias = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_BIAS))
                    .ACFData.dIntensityAdj_Step = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_STEP))
                    .ACFData.dIntensityAdj_Limit = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_LIMIT))
                    .ACFData.sIntensityAdj_Settings.SourceMode = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_SRC_MODE))
                    .ACFData.sIntensityAdj_Settings.WireMode = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_WIRE_MODE))
                    .ACFData.sIntensityAdj_Settings.LimitVoltage = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_LIMIT_V))
                    .ACFData.sIntensityAdj_Settings.LimitCurrent = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_LIMIT_I))
                    .ACFData.sIntensityAdj_Settings.nCurrentRangeIndex = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_CURRENG_RANGE))
                    .ACFData.sIntensityAdj_Settings.TerminalMode = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_TERMINAL_MODE))
                    .ACFData.sIntensityAdj_Settings.MeasureMode = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_MEAS_MODE))
                    .ACFData.sIntensityAdj_Settings.NumOfMeasData = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_NUM_OF_MEASDATA))
                    .ACFData.sIntensityAdj_Settings.MeasureDelay_Sec = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_MEAS_DELAY_SEC))
                    .ACFData.sIntensityAdj_Settings.IntegTime_Sec = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_INTEG_TIME_SEC))
                    .ACFData.sIntensityAdj_Settings.nIntegTimeIndex = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_INTEG_TIME_INDEX))
                    .ACFData.sIntensityAdj_Settings.nVoltageRangeIndex = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_VOLTAGE_RANGE))
                    .ACFData.sIntensityAdj_Settings.MeasureValueType = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_MEAS_VAL_TYPE))
                    .ACFData.sIntensityAdj_Settings.MeasureDelayAuto = CBool(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.INTENSITY_ADJ_SETTING_MEAS_DELAY_AUTO))

                    'Module
                    .ACFData.nModulePatternNo = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.MODULE_CONDITION_PATTERN_NO))

                Catch ex As Exception
                    .ACFData.sSoruceMode = ACFSourceMode.eCV
                    .ACFData.dIntensityAdj_Bias = 1
                    .ACFData.dIntensityAdj_Step = 2
                    .ACFData.dIntensityAdj_Limit = 3
                    .ACFData.sIntensityAdj_Settings.SourceMode = ucKeithleySMUSettings.eSMUMode.eVoltage
                    .ACFData.sIntensityAdj_Settings.WireMode = ucKeithleySMUSettings.eProve.e2Prove
                    .ACFData.sIntensityAdj_Settings.LimitVoltage = 10
                    .ACFData.sIntensityAdj_Settings.LimitCurrent = 1
                    .ACFData.sIntensityAdj_Settings.nCurrentRangeIndex = 0
                    .ACFData.sIntensityAdj_Settings.TerminalMode = ucKeithleySMUSettings.eTerminalMode.eRear
                    .ACFData.sIntensityAdj_Settings.MeasureMode = ucKeithleySMUSettings.eMeasValue.eCurrent
                    .ACFData.sIntensityAdj_Settings.NumOfMeasData = 100
                    .ACFData.sIntensityAdj_Settings.MeasureDelay_Sec = 0
                    .ACFData.sIntensityAdj_Settings.IntegTime_Sec = 1
                    .ACFData.sIntensityAdj_Settings.nIntegTimeIndex = 0
                    .ACFData.sIntensityAdj_Settings.nVoltageRangeIndex = 0
                    .ACFData.sIntensityAdj_Settings.MeasureValueType = ucKeithleySMUSettings.eMeasValue.eCurrent
                    .ACFData.sIntensityAdj_Settings.MeasureDelayAuto = True
                    .ACFData.nModulePatternNo = 0
                End Try

                If .ACFData.sIntensityAdj_Settings.nCurrentRangeIndex = 0 Then
                    .ACFData.sIntensityAdj_Settings.CurrentAutoRange = True
                Else
                    .ACFData.sIntensityAdj_Settings.CurrentAutoRange = False
                End If
                If .ACFData.sIntensityAdj_Settings.nVoltageRangeIndex = 0 Then
                    .ACFData.sIntensityAdj_Settings.VoltageAutoRange = True
                Else
                    .ACFData.sIntensityAdj_Settings.VoltageAutoRange = False
                End If

                'Motion Pos To Real Distance
                .MotionData.sStandardDistance.dAxis_X = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.STANDARD_DISTANCE_X))
                .MotionData.sStandardDistance.dAxis_Y = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.STANDARD_DISTANCE_Y))
                .MotionData.sStandardDistance.dAxis_Z = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.STANDARD_DISTANCE_Z))
                Try
                    .MotionData.sStandardDistance.dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.STANDARD_DISTANCE_Theta_Y))
                Catch ex As Exception
                    .MotionData.sStandardDistance.dAxis_Theta_Y = 0
                End Try

                .MotionData.sStandardDistance.dAxis_Theta = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.STANDARD_DISTANCE_Theta))

                .MotionData.sStartPos.dAxis_X = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.START_POSITION_X))
                .MotionData.sStartPos.dAxis_Y = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.START_POSITION_Y))
                .MotionData.sStartPos.dAxis_Z = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.START_POSITION_Z))

                Try
                    .MotionData.sStartPos.dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.START_POSITION_Theta_Y))
                Catch ex As Exception
                    .MotionData.sStartPos.dAxis_Theta_Y = 0
                End Try
                .MotionData.sStartPos.dAxis_Theta = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.START_POSITION_Theta))

                .MotionData.sEndPos.dAxis_X = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.END_POSITION_X))
                .MotionData.sEndPos.dAxis_Y = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.END_POSITION_Y))
                .MotionData.sEndPos.dAxis_Z = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.END_POSITION_Z))

                Try
                    .MotionData.sEndPos.dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.END_POSITION_Theta_Y))
                Catch ex As Exception
                    .MotionData.sEndPos.dAxis_Theta_Y = 0
                End Try
                .MotionData.sEndPos.dAxis_Theta = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.END_POSITION_Theta))

                .MotionData.sCalPos.dAxis_X = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_POSITION_X))
                .MotionData.sCalPos.dAxis_Y = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_POSITION_Y))
                .MotionData.sCalPos.dAxis_Z = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_POSITION_Z))

                Try
                    .MotionData.sCalPos.dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_POSITION_Theta_Y))
                Catch ex As Exception
                    .MotionData.sCalPos.dAxis_Theta_Y = 0
                End Try

                .MotionData.sCalPos.dAxis_Theta = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_POSITION_Theta))

                .MotionData.sCalPosPerDistance.dAxis_X = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.POSITION_PER_DISTANCE_X))
                .MotionData.sCalPosPerDistance.dAxis_Y = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.POSITION_PER_DISTANCE_Y))
                .MotionData.sCalPosPerDistance.dAxis_Z = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.POSITION_PER_DISTANCE_Z))
                Try
                    .MotionData.sCalPosPerDistance.dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.POSITION_PER_DISTANCE_Theta_Y))
                Catch ex As Exception
                    .MotionData.sCalPosPerDistance.dAxis_Theta_Y = 0
                End Try
                .MotionData.sCalPosPerDistance.dAxis_Theta = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.POSITION_PER_DISTANCE_Theta))

                'Theta Calibration Factor -20170414
                Try
                    .MotionData.sThetaCal.dDeviation = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_THETA_DEVIATION))
                Catch ex As Exception
                    .MotionData.sThetaCal.dDeviation = 0
                End Try

                Try
                    .MotionData.sThetaCal.dRatio = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_THETA_RATIO))
                Catch ex As Exception
                    .MotionData.sThetaCal.dRatio = 1
                End Try

                Try
                    .MotionData.sThetaCal.dOffset = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_THETA_OFFSET))
                Catch ex As Exception
                    .MotionData.sThetaCal.dOffset = 0
                End Try

                'WAD Calibration Factor -20170414
                ReDim .MotionData.sWADCalFactor.dWAD_X(frmWADSet.nNumOfFactor - 1)
                For idx As Integer = 0 To frmWADSet.nNumOfFactor - 1
                    .MotionData.sWADCalFactor.dWAD_X(idx) = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_WAD_FACTOR_X, idx))
                Next

                ReDim .MotionData.sWADCalFactor.dWAD_Y(frmWADSet.nNumOfFactor - 1)
                For idx As Integer = 0 To frmWADSet.nNumOfFactor - 1
                    .MotionData.sWADCalFactor.dWAD_Y(idx) = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_WAD_FACTOR_Y, idx))
                Next

                ReDim .MotionData.sWADCalFactor.dWAD_Z(frmWADSet.nNumOfFactor - 1)
                For idx As Integer = 0 To frmWADSet.nNumOfFactor - 1
                    .MotionData.sWADCalFactor.dWAD_Z(idx) = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.CAL_WAD_FACTOR_Z, idx))
                Next

                'Contact Check
                Try
                    .sCheckContact.dContactBias = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eCheckContact, 0, COptionINI.eKeyID.CONTACT_BIAS))
                Catch ex As Exception
                    .sCheckContact.dContactBias = 1
                End Try

                Try
                    .sCheckContact.dPassLevel = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eCheckContact, 0, COptionINI.eKeyID.CONTACT_PASSLV))
                Catch ex As Exception
                    .sCheckContact.dPassLevel = 1
                End Try

                Try
                    .sCheckContact.dBiasMargin = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eCheckContact, 0, COptionINI.eKeyID.CONTACT_MARGIN))
                Catch ex As Exception
                    .sCheckContact.dBiasMargin = 100
                End Try



                sTemp = optionLoader.LoadIniValue(COptionINI.eSecID.eMotion, 0, COptionINI.eKeyID.POSITION_PER_DISTANCE_USE)
                If sTemp = "True" Then
                    .MotionData.bCalPosPerDistanceUse = True
                Else
                    .MotionData.bCalPosPerDistanceUse = False
                End If

                'Temp
                Try
                    .TemperatureData.dMargin = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eTemperature, 0, COptionINI.eKeyID.TEMPERATURE_MARGIN))
                    .TemperatureData.dLimitAlarmLow = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eTemperature, 0, COptionINI.eKeyID.TEMPERATURE_LIMIT_ALARM_LOW))
                    .TemperatureData.dLimitAlarmHigh = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eTemperature, 0, COptionINI.eKeyID.TEMPERATURE_LIMIT_ALARM_HIGH))
                Catch ex As Exception
                    .TemperatureData.dMargin = 0
                    .TemperatureData.dLimitAlarmLow = 20
                    .TemperatureData.dLimitAlarmHigh = 85
                End Try

                'Spectrometer
                Try
                    .Spectrometer.nIVLSweepGain = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_GAIN_IVL))
                    .Spectrometer.nLifetimeGain = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_GAIN_LIFETIME))
                    .Spectrometer.nAngleGain = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_GAIN_ANGLE))
                    .Spectrometer.nAperture = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_APERTURE))
                    .Spectrometer.nSpeedMode = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_SPEEDMODE))
                    .IVLSpectrometer.nAperture = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_APERTURE))
                    .IVLSpectrometer.nSpeedMode = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_SPEEDMODE))
                    .IVLSpectrometer.nExposureTime = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_EXPOSURETIME))
                    .IVLSpectrometer.MeasureMode = frmBuilderSettings.ConvertToInteger(optionLoader.LoadIniValue(COptionINI.eSecID.eSpectrometer, 0, COptionINI.eKeyID.SPECTROMETER_IVL_MEASUREMODE))

                Catch ex As Exception
                    .Spectrometer.nIVLSweepGain = 1
                    .Spectrometer.nLifetimeGain = 1
                    .Spectrometer.nAngleGain = 1
                    .Spectrometer.nAperture = 0
                    .Spectrometer.nSpeedMode = 0
                    .IVLSpectrometer.nAperture = 0
                    .IVLSpectrometer.nSpeedMode = 0
                    .IVLSpectrometer.nExposureTime = 5000
                    .IVLSpectrometer.MeasureMode = CSpectrometerLib.cDevCS2000A.eMeasureMode._Auto
                End Try


                'CCD
                .CCDData.dCCDExposureValue = frmBuilderSettings.ConvertToDouble(optionLoader.LoadIniValue(COptionINI.eSecID.eCCD, 0, COptionINI.eKeyID.CCD_EXPOSURE_VALUE))
                .CCDData.strCaptureCCDPath = optionLoader.LoadIniValue(COptionINI.eSecID.eCCD, 0, COptionINI.eKeyID.CCD_CAPTURE_IMAGE_PATH)

                Try
                    .CCDData.dCaptureLevel = CDbl(optionLoader.LoadIniValue(COptionINI.eSecID.eCCD, 0, COptionINI.eKeyID.CCD_CAPTURE_IMAGE_LEVEL))
                Catch ex As Exception
                    .CCDData.dCaptureLevel = 0
                End Try


                Try
                    .CCDData.ImageAnalysisMode = CInt(optionLoader.LoadIniValue(COptionINI.eSecID.eACF, 0, COptionINI.eKeyID.IMAGE_ANALYSIS_MODE))
                Catch ex As Exception
                    .CCDData.ImageAnalysisMode = 0
                End Try


                'Save Options
                Try
                    .SaveOptions.bFileName_AddChNum = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_FILE_NAME_RULE_ADD_CH_NUM)
                    .SaveOptions.bFileName_AddDate = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_FILE_NAME_RULE_ADD_DATE)
                    .SaveOptions.bFileName_AddExpMode = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_FILE_NAME_RULE_ADD_EXP_MODE)
                    .SaveOptions.bFileName_AddUserInput = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_FILE_NAME_RULE_ADD_USER_INPUT)
                    .SaveOptions.sDefaultSavePath = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_DEFAULT_PATH)
                    .SaveOptions.dLuminancePerSpectrumSave = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_LUMINANCE_PERCENT_SPECTRUM_DATA_SAVE)
                    .SaveOptions.bUsedBackupPath = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_USED_BACKUP_PATH)
                    .SaveOptions.sBackupSavePath = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_BACKUP_PATH)
                    Try
                        .SaveOptions.nIntegralWL_Pick1_Start = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK1_START)
                        .SaveOptions.nIntegralWL_Pick1_end = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK1_END)
                        .SaveOptions.nIntegralWL_Pick2_start = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK2_START)
                        .SaveOptions.nIntegralWL_Pick2_end = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK2_END)

                        .SaveOptions.nIntegralWL_Pick3_Start = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK3_START)
                        .SaveOptions.nIntegralWL_Pick3_end = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK3_END)
                        .SaveOptions.nIntegralWL_Pick4_start = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK4_START)
                        .SaveOptions.nIntegralWL_Pick4_end = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_PICK4_END)

                        '.SaveOptions.nJIG17_24_Pick1_Start = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG17_24_PICK1_START)
                        '.SaveOptions.nJIG17_24_Pick1_end = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG17_24_PICK1_END)
                        '.SaveOptions.nJIG17_24_Pick2_start = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG17_24_PICK2_START)
                        '.SaveOptions.nJIG17_24_Pick2_end = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG17_24_PICK2_END)

                        '.SaveOptions.nJIG25_32_Pick1_Start = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG25_32_PICK1_START)
                        '.SaveOptions.nJIG25_32_Pick1_end = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG25_32_PICK1_END)
                        '.SaveOptions.nJIG25_32_Pick2_start = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG25_32_PICK2_START)
                        '.SaveOptions.nJIG25_32_Pick2_end = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_SPECTRUM_JIG25_32_PICK2_END)
                    Catch ex As Exception
                        .SaveOptions.nIntegralWL_Pick1_Start = 0
                        .SaveOptions.nIntegralWL_Pick1_end = 0
                        .SaveOptions.nIntegralWL_Pick2_start = 0
                        .SaveOptions.nIntegralWL_Pick2_end = 0
                        .SaveOptions.nIntegralWL_Pick3_Start = 0
                        .SaveOptions.nIntegralWL_Pick3_end = 0
                        .SaveOptions.nIntegralWL_Pick4_start = 0
                        .SaveOptions.nIntegralWL_Pick4_end = 0
                        '.SaveOptions.nJIG17_24_Pick1_Start = 0
                        '.SaveOptions.nJIG17_24_Pick1_end = 0
                        '.SaveOptions.nJIG17_24_Pick2_start = 0
                        '.SaveOptions.nJIG17_24_Pick2_end = 0
                        '.SaveOptions.nJIG25_32_Pick1_Start = 0
                        '.SaveOptions.nJIG25_32_Pick1_end = 0
                        '.SaveOptions.nJIG25_32_Pick2_start = 0
                        '.SaveOptions.nJIG25_32_Pick2_end = 0
                    End Try

                    Try
                        .SaveOptions.bFilenameTEGtoTEGChannel = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_FILE_NAME_RULE_TEG_TO_TEGCHANNEL)
                    Catch ex As Exception
                        .SaveOptions.bFilenameTEGtoTEGChannel = False
                    End Try

                    Try
                        .SaveOptions.nFileType = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_FILETYPE)
                        .SaveOptions.bCalRealCurrentSave = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_CAL_REAL_CURRENT)
                    Catch ex As Exception
                        .SaveOptions.nFileType = 0
                        .SaveOptions.bCalRealCurrentSave = False
                    End Try

                    Dim ncount As Integer = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 1, COptionINI.eKeyID.SAVE_IVLDATAINDEXCOUNT)
                    ReDim .SaveOptions.nDataIVLPlotItems(ncount - 1)
                    ReDim .SaveOptions.nDataIVLPlotItemName(ncount - 1)
                    For i As Integer = 0 To ncount - 1
                        .SaveOptions.nDataIVLPlotItems(i) = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 1, COptionINI.eKeyID.SAVE_IVLDATAINDEX, i)
                        .SaveOptions.nDataIVLPlotItemName(i) = sIVLDataPlotItems(.SaveOptions.nDataIVLPlotItems(i))
                    Next


                    ncount = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 1, COptionINI.eKeyID.SAVE_LTDATAINDEXCOUNT)
                    ReDim .SaveOptions.nDataLTPlotItems(ncount - 1)
                    ReDim .SaveOptions.nDataLTPlotItemName(ncount - 1)
                    For i As Integer = 0 To ncount - 1
                        .SaveOptions.nDataLTPlotItems(i) = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 1, COptionINI.eKeyID.SAVE_LTDATAINDEX, i)
                        .SaveOptions.nDataLTPlotItemName(i) = sLTDataPlotItems(.SaveOptions.nDataLTPlotItems(i))
                    Next

                    'ncount = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 1, COptionINI.eKeyID.SAVE_VADATAINDEXCOUNT)
                    'ReDim .SaveOptions.nDataVAPlotItems(ncount - 1)
                    'ReDim .SaveOptions.nDataVAPlotItemName(ncount - 1)
                    'For i As Integer = 0 To ncount - 1
                    '    .SaveOptions.nDataVAPlotItems(i) = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 1, COptionINI.eKeyID.SAVE_VADATAINDEX, i)
                    '    .SaveOptions.nDataVAPlotItemName(i) = sVADataPlotItems(.SaveOptions.nDataVAPlotItems(i))
                    'Next

                    Try
                        .SaveOptions.sIVLHeader.bFileversion = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_IVLHEADER_FILEVERSION)
                        .SaveOptions.sIVLHeader.bFilename = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_IVLHEADER_FILENAME)
                        .SaveOptions.sIVLHeader.bMeasMode = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_IVLHEADER_MEASMODE)
                        .SaveOptions.sIVLHeader.bBiasMode = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_IVLHEADER_BIASMODE)
                        .SaveOptions.sIVLHeader.bSweepMode = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_IVLHEADER_SWEEPMODE)
                        .SaveOptions.sIVLHeader.bLuminanceMeasLevel = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_IVLHEADER_LUMINANCEMEASLEVEL)

                        .SaveOptions.sLifetimeHeader.bFileversion = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_LTHEADER_FILEVERSION)
                        .SaveOptions.sLifetimeHeader.bFilename = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_LTHEADER_FILENAME)
                        .SaveOptions.sLifetimeHeader.bMeasMode = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_LTHEADER_MEASMODE)
                        .SaveOptions.sLifetimeHeader.bBiasMode = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_LTHEADER_BIASMODE)
                        .SaveOptions.sLifetimeHeader.bRenewalTime = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_LTHEADER_RENEWALTIME)

                        .SaveOptions.sVAHeader.bFileversion = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_VAHEADER_FILEVERSION)
                        .SaveOptions.sVAHeader.bFilename = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_VAHEADER_FILENAME)
                        .SaveOptions.sVAHeader.bMeasMode = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_VAHEADER_MEASMODE)
                        .SaveOptions.sVAHeader.bBiasMode = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_VAHEADER_BIASMODE)
                        .SaveOptions.sVAHeader.bSweepMode = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_VAHEADER_SWEEPMODE)
                        '   .SaveOptions.sVAHeader.bRenewalTime = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAVE_LTHEADER_RENEWALTIME)

                    Catch ex As Exception
                        .SaveOptions.sIVLHeader.bFileversion = True
                        .SaveOptions.sIVLHeader.bFilename = True
                        .SaveOptions.sIVLHeader.bMeasMode = True
                        .SaveOptions.sIVLHeader.bBiasMode = True
                        .SaveOptions.sIVLHeader.bSweepMode = True
                        .SaveOptions.sIVLHeader.bLuminanceMeasLevel = True

                        .SaveOptions.sLifetimeHeader.bFileversion = True
                        .SaveOptions.sLifetimeHeader.bFilename = True
                        .SaveOptions.sLifetimeHeader.bMeasMode = True
                        .SaveOptions.sLifetimeHeader.bBiasMode = True
                        .SaveOptions.sLifetimeHeader.bRenewalTime = True

                        .SaveOptions.sVAHeader.bFileversion = True
                        .SaveOptions.sVAHeader.bFilename = True
                        .SaveOptions.sVAHeader.bMeasMode = True
                        .SaveOptions.sVAHeader.bBiasMode = True
                        .SaveOptions.sVAHeader.bSweepMode = True
                    End Try

                Catch ex As Exception
                    .SaveOptions.bFileName_AddChNum = True
                    .SaveOptions.bFileName_AddDate = True
                    .SaveOptions.bFileName_AddExpMode = True
                    .SaveOptions.bFileName_AddUserInput = True
                    .SaveOptions.dLuminancePerSpectrumSave = 0
                    .SaveOptions.nDataIVLPlotItems = Nothing
                    .SaveOptions.nDataLTPlotItems = Nothing
                    .SaveOptions.nDataVAPlotItems = Nothing
                    .SaveOptions.sBackupSavePath = ""
                    .SaveOptions.bUsedBackupPath = False
                End Try

                'Visible Display Options
                Try
                    .VisibleDisplay.bChannelMoveButton = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.VISIBLE_DISPLAY_CHANNEL_MOVE_BUTTON)
                    .VisibleDisplay.bAngleMoveButton = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.VISIBLE_DISPLAY_ANGLE_MOVE_BUTTON)
                Catch ex As Exception
                    .VisibleDisplay.bChannelMoveButton = True
                    .VisibleDisplay.bAngleMoveButton = True
                End Try

                'SampleInfos Options
                Try
                    .SampleInfos.dHeight = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAMPLEINFO_HEIGHT)
                    .SampleInfos.dWidth = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAMPLEINFO_WIDTH)
                    .SampleInfos.dFillFactor = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.SAMPLEINFO_FILLFACTOR)
                Catch ex As Exception
                    .SampleInfos.dHeight = 2
                    .SampleInfos.dWidth = 2
                    .SampleInfos.dFillFactor = 100
                End Try

                'sMaterialDatas Option
                Try
                    .MaterialData.sRed.dCIEx = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_RED_CIEx)
                    .MaterialData.sRed.dCIEy = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_RED_CIEy)
                    .MaterialData.sRed.dApertureRatio = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_RED_APERTURERATIO)
                    .MaterialData.sRed.dTransmittancePolarizers = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_RED_TRANSMITTANCEPOLARIZERS)
                    .MaterialData.sGreen.dCIEx = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_GREEN_CIEx)
                    .MaterialData.sGreen.dCIEy = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_GREEN_CIEy)
                    .MaterialData.sGreen.dApertureRatio = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_GREEN_APERTURERATIO)
                    .MaterialData.sGreen.dTransmittancePolarizers = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_GREEN_TRANSMITTANCEPOLARIZERS)
                    .MaterialData.sBlue.dCIEx = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_BLUE_CIEx)
                    .MaterialData.sBlue.dCIEy = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_BLUE_CIEy)
                    .MaterialData.sBlue.dApertureRatio = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_BLUE_APERTURERATIO)
                    .MaterialData.sBlue.dTransmittancePolarizers = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_BLUE_TRANSMITTANCEPOLARIZERS)
                    .MaterialData.sWhite.dCIEx = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_WHITE_CIEx)
                    .MaterialData.sWhite.dCIEy = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_WHITE_CIEy)
                    .MaterialData.sWhite.dApertureRatio = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_WHITE_APERTURERATIO)
                    .MaterialData.sWhite.dTransmittancePolarizers = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_WHITE_TRANSMITTANCEPOLARIZERS)
                    .MaterialData.sWhite.dBrightnessRequirements = optionLoader.LoadIniValue(COptionINI.eSecID.eSaveOptions, 0, COptionINI.eKeyID.MATERIALDATA_WHITE_BRIGHTNESSREQUIREMENTS)
                Catch ex As Exception
                    .MaterialData.sRed.dCIEx = 0
                    .MaterialData.sRed.dCIEy = 0
                    .MaterialData.sRed.dApertureRatio = 0
                    .MaterialData.sRed.dTransmittancePolarizers = 0
                    .MaterialData.sGreen.dCIEx = 0
                    .MaterialData.sGreen.dCIEy = 0
                    .MaterialData.sGreen.dApertureRatio = 0
                    .MaterialData.sGreen.dTransmittancePolarizers = 0
                    .MaterialData.sBlue.dCIEx = 0
                    .MaterialData.sBlue.dCIEy = 0
                    .MaterialData.sBlue.dApertureRatio = 0
                    .MaterialData.sBlue.dTransmittancePolarizers = 0
                    .MaterialData.sWhite.dCIEx = 0
                    .MaterialData.sWhite.dCIEy = 0
                    .MaterialData.sWhite.dApertureRatio = 0
                    .MaterialData.sWhite.dTransmittancePolarizers = 0
                    .MaterialData.sWhite.dBrightnessRequirements = 0
                End Try

            End With

        Catch ex As Exception
            '   MsgBox("File Load Error")
            Return False
        End Try

        Return True

    End Function
#End Region


    Private Sub cbBiasMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case 0
            Case "CC"
                lblValueUnit.Text = "mA"
                lblAmpUnit.Text = "mA"
                txtLowAmplitude.Enabled = False
                txtHighAmplitude.Enabled = False
                txtLowFrequency.Enabled = False
                txtHighFrequency.Enabled = False
                txtLowDuty.Enabled = False
                txtHighDuty.Enabled = False
            Case "CV"
                lblValueUnit.Text = "V"
                lblAmpUnit.Text = "V"
                txtLowAmplitude.Enabled = False
                txtHighAmplitude.Enabled = False
                txtLowFrequency.Enabled = False
                txtHighFrequency.Enabled = False
                txtLowDuty.Enabled = False
                txtHighDuty.Enabled = False
            Case "PC"
                lblValueUnit.Text = "mA"
                lblAmpUnit.Text = "mA"
                txtLowAmplitude.Enabled = True
                txtHighAmplitude.Enabled = True
                txtLowFrequency.Enabled = True
                txtHighFrequency.Enabled = True
                txtLowDuty.Enabled = True
                txtHighDuty.Enabled = True
            Case "PV"
                lblValueUnit.Text = "V"
                lblAmpUnit.Text = "V"
                txtLowAmplitude.Enabled = True
                txtHighAmplitude.Enabled = True
                txtLowFrequency.Enabled = True
                txtHighFrequency.Enabled = True
                txtLowDuty.Enabled = True
                txtHighDuty.Enabled = True
            Case "PCV"
                lblValueUnit.Text = "V"
                lblAmpUnit.Text = "mA"
                txtLowAmplitude.Enabled = True
                txtHighAmplitude.Enabled = True
                txtLowFrequency.Enabled = True
                txtHighFrequency.Enabled = True
                txtLowDuty.Enabled = True
                txtHighDuty.Enabled = True
        End Select
    End Sub

    Private Sub btnOptionSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionSave.Click
        SaveSystemOption(m_Option)
    End Sub

    Private Sub btnOptionLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionLoad.Click
        If LoadSystemOption(m_Option) = True Then
            SetValueToUI()
        End If
    End Sub

    Private Sub btnSetDistance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDistance.Click
        With m_Option.MotionData.sStandardDistance
            .dAxis_X = frmBuilderSettings.ConvertToDouble(tbDistance_X.Text)
            .dAxis_Y = frmBuilderSettings.ConvertToDouble(tbDistance_Y.Text)
            .dAxis_Z = frmBuilderSettings.ConvertToDouble(tbDistance_Z.Text)
            .dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(tbDistance_Theta_Y.Text)
            .dAxis_Theta = frmBuilderSettings.ConvertToDouble(tbDistance_Theta.Text)
            'm_Option.MotionData.sStartPos.dAxis_X = CDbl(tbStartPos_X.Text)
            'm_Option.MotionData.sStartPos.dAxis_Y = CDbl(tbStartPos_Y.Text)
            'm_Option.MotionData.sEndPos.dAxis_X = CDbl(tbEndPos_X.Text)
            'm_Option.MotionData.sEndPos.dAxis_Y = CDbl(tbEndPos_Y.Text)
        End With
    End Sub

    Private Sub btnGetStartPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetStartPos.Click

        tbStartPos_X.Text = fMain.frmMotionUI.ucMotionIndicator.tbXPos.Text
        tbStartPos_Y.Text = fMain.frmMotionUI.ucMotionIndicator.tbYPos.Text
        tbStartPos_Z.Text = fMain.frmMotionUI.ucMotionIndicator.tbZPos.Text
        ' tbStartPos_Theta_Y.Text = fMain.frmMotionUI.ucMotionIndicator.tbThetaYPos.Text
        tbStartPos_Theta.Text = fMain.frmMotionUI.ucMotionIndicator.tbTheta1Pos.Text

        m_Option.MotionData.sStartPos.dAxis_X = frmBuilderSettings.ConvertToDouble(tbStartPos_X.Text)
        m_Option.MotionData.sStartPos.dAxis_Y = frmBuilderSettings.ConvertToDouble(tbStartPos_Y.Text)
        m_Option.MotionData.sStartPos.dAxis_Z = frmBuilderSettings.ConvertToDouble(tbStartPos_Z.Text)
        ' m_Option.MotionData.sStartPos.dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(tbStartPos_Theta_Y.Text)
        m_Option.MotionData.sStartPos.dAxis_Theta = frmBuilderSettings.ConvertToDouble(tbStartPos_Theta.Text)

    End Sub

    Private Sub btnGetEndPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetEndPos.Click

        tbEndPos_X.Text = fMain.frmMotionUI.ucMotionIndicator.tbXPos.Text
        tbEndPos_Y.Text = fMain.frmMotionUI.ucMotionIndicator.tbYPos.Text
        tbEndPos_Z.Text = fMain.frmMotionUI.ucMotionIndicator.tbZPos.Text
        ' tbEndPos_Theta_Y.Text = fMain.frmMotionUI.ucMotionIndicator.tbThetaYPos.Text
        tbEndPos_Theta.Text = fMain.frmMotionUI.ucMotionIndicator.tbTheta1Pos.Text

        m_Option.MotionData.sEndPos.dAxis_X = frmBuilderSettings.ConvertToDouble(tbEndPos_X.Text)
        m_Option.MotionData.sEndPos.dAxis_Y = frmBuilderSettings.ConvertToDouble(tbEndPos_Y.Text)
        m_Option.MotionData.sEndPos.dAxis_Z = frmBuilderSettings.ConvertToDouble(tbEndPos_Z.Text)
        'm_Option.MotionData.sEndPos.dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(tbEndPos_Theta_Y.Text)
        m_Option.MotionData.sEndPos.dAxis_Theta = frmBuilderSettings.ConvertToDouble(tbEndPos_Theta.Text)

    End Sub

    Private Sub btnCalPosPerDistance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalPosPerDistance.Click
        With m_Option.MotionData

            .sStartPos.dAxis_X = frmBuilderSettings.ConvertToDouble(tbStartPos_X.Text)
            .sStartPos.dAxis_Y = frmBuilderSettings.ConvertToDouble(tbStartPos_Y.Text)
            .sStartPos.dAxis_Z = frmBuilderSettings.ConvertToDouble(tbStartPos_Z.Text)
            '  .sStartPos.dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(tbStartPos_Theta_Y.Text)
            .sStartPos.dAxis_Theta = frmBuilderSettings.ConvertToDouble(tbStartPos_Theta.Text)

            .sEndPos.dAxis_X = frmBuilderSettings.ConvertToDouble(tbEndPos_X.Text)
            .sEndPos.dAxis_Y = frmBuilderSettings.ConvertToDouble(tbEndPos_Y.Text)
            .sEndPos.dAxis_Z = frmBuilderSettings.ConvertToDouble(tbEndPos_Z.Text)
            ' .sEndPos.dAxis_Theta_Y = frmBuilderSettings.ConvertToDouble(tbEndPos_Theta_Y.Text)
            .sEndPos.dAxis_Theta = frmBuilderSettings.ConvertToDouble(tbEndPos_Theta.Text)

            .sCalPos.dAxis_X = Math.Abs(.sStartPos.dAxis_X - .sEndPos.dAxis_X)
            .sCalPos.dAxis_Y = Math.Abs(.sStartPos.dAxis_Y - .sEndPos.dAxis_Y)
            .sCalPos.dAxis_Z = Math.Abs(.sStartPos.dAxis_Z - .sEndPos.dAxis_Z)
            .sCalPos.dAxis_Theta_Y = Math.Abs(.sStartPos.dAxis_Theta_Y - .sEndPos.dAxis_Theta_Y)
            .sCalPos.dAxis_Theta = Math.Abs(.sStartPos.dAxis_Theta - .sEndPos.dAxis_Theta)

            .sCalPosPerDistance.dAxis_X = .sCalPos.dAxis_X / .sStandardDistance.dAxis_X
            .sCalPosPerDistance.dAxis_Y = .sCalPos.dAxis_Y / .sStandardDistance.dAxis_Y
            .sCalPosPerDistance.dAxis_Z = .sCalPos.dAxis_Z / .sStandardDistance.dAxis_Z
            .sCalPosPerDistance.dAxis_Theta_Y = .sCalPos.dAxis_Theta_Y / .sStandardDistance.dAxis_Theta_Y
            .sCalPosPerDistance.dAxis_Theta = .sCalPos.dAxis_Theta / .sStandardDistance.dAxis_Theta

            tbCalPos_X.Text = CStr(.sCalPos.dAxis_X)
            tbCalPos_Y.Text = CStr(.sCalPos.dAxis_Y)
            tbCalPos_Z.Text = CStr(.sCalPos.dAxis_Z)
            '   tbCalPos_Theta_Y.Text = CStr(.sCalPos.dAxis_Theta_Y)
            tbCalPos_Theta.Text = CStr(.sCalPos.dAxis_Theta)

            tbPosPerDistance_X.Text = CStr(.sCalPosPerDistance.dAxis_X)
            tbPosPerDistance_Y.Text = CStr(.sCalPosPerDistance.dAxis_Y)
            tbPosPerDistance_Z.Text = CStr(.sCalPosPerDistance.dAxis_Z)
            '  tbPosPerDistance_Theta_Y.Text = CStr(.sCalPosPerDistance.dAxis_Theta_Y)
            tbPosPerDistance_Theta.Text = CStr(.sCalPosPerDistance.dAxis_Theta)
        End With
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If GetValueFromUI() = False Then
            Me.DialogResult = Windows.Forms.DialogResult.Retry
            Exit Sub '예외적인 상황일땐 저장하지 않음
        End If
        SaveSystemOption(m_Option)
        g_SystemOptions.sOptionData = m_Option
        'fMain.cSpectormeter(0).mySpectrometer.ExposureTime = g_SystemOptions.sOptionData.IVLSpectrometer.nExposureTime

        fMain.frmMotionUI.Display()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub tbStartPos_X_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbStartPos_X.TextChanged

    End Sub

    Private Sub tbCalPos_X_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCalPos_X.TextChanged

    End Sub

    Private Sub tbEndPos_X_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbEndPos_X.TextChanged

    End Sub

#Region "Status Color Settings"


#Region "define"
    Dim LineColorInfo As Color

    Public g_status() As String = New String() {"IDLE", "Run",
        "Stop",
        "ChangeTemp_Set",
        "ChangeTemp_WaitingTemp",
        "ChangeTemp_Stabilization",
        "ChangeNextSeq",
        "LifeTime_SetSourcing",
        "LifeTime_Running",
        "LifeTime_StopSourcing",
        "ResetAllTime",
        "ResetModeTime",
        "ResetInterval"}


#End Region

    Private Sub lbColor_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbColor.Click
        If e.Button = Windows.Forms.MouseButtons.Right Then
            go()

        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then

        End If
    End Sub

    Public Sub UcDispLlistView1_evSelectedIndexChanged(ByVal nRow As Integer) Handles ucDispFontColorList.evSelectedIndexChanged
        If nRow < 0 Then
            Exit Sub
        Else
            ucDispFontColorList.selectedIndexColor = nRow
        End If
    End Sub

    Public Sub go()

        Dim lineColor As Integer

        If GetColor(lineColor) Then
            'lbColor.BackColor = lineColor
            'lbColor.BackColor.ToString = lineColor
            lbColor.BackColor = Color.FromArgb(lineColor)

            LineColorInfo = Color.FromArgb(lineColor)
        Else
            Exit Sub
        End If
    End Sub

    Public Function GetColor(ByRef colorInfo As Integer) As Boolean
        Dim dlg As New System.Windows.Forms.ColorDialog

        Dim colorsam As Color

        If dlg.ShowDialog() = DialogResult.OK Then

            colorsam = dlg.Color
            colorInfo = colorsam.ToArgb
        Else
            Return False
        End If
        Return True

    End Function


    Private Sub btnColorAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorAdd.Click
        Dim sData(0) As Object
        Dim Item As CScheduler.eChSchedulerSTATE

        Item = cbStatus.SelectedIndex

        sData(0) = Item.ToString

        ucDispFontColorList.AddRowData(sData, LineColorInfo)

    End Sub

    Private Sub btnColorDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorDel.Click
        ucDispFontColorList.DelSelectedRow(ucDispFontColorList.selectedIndexColor)

    End Sub

#End Region

#Region "Calibration"
    Private Sub btnOpenCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim dlg As frmCalculation

        'dlg = New frmCalculation(tbDataNum.Text)

        'dlg.Show()
    End Sub

    Private Sub btnCalFrameOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dlg As frmBrightSetting
        Dim DegreeNum As Integer = g_CalDegree + 1 '계산 후 받아오기

        dlg = New frmBrightSetting(DegreeNum, g_nMaxCh)

        dlg.Show()
    End Sub
#End Region

#Region "Link "


    Private Sub chkEnableDataViewerLink_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableDataViewerLink_IVL.CheckedChanged
        tbPathOfDataViewer_IVL.Enabled = chkEnableDataViewerLink_IVL.Checked
        btnFindPathOfDataViewer_IVL.Enabled = chkEnableDataViewerLink_IVL.Checked
    End Sub

    Private Sub btnFindPathOfDataViewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindPathOfDataViewer_IVL.Click
        Dim fileDlg As New CMcFile()
        Dim fileInfo As CMcFile.sFILENAME = Nothing

        If fileDlg.GetLoadFileName(CMcFile.eFileType._EXE, fileInfo) = True Then
            tbPathOfDataViewer_IVL.Text = fileInfo.strPathAndFName
        End If

    End Sub


    Private Sub chkEnableDataViewerLink_LT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableDataViewerLink_LT.CheckedChanged
        tbPathOfDataViewer_LT.Enabled = chkEnableDataViewerLink_LT.Checked
        btnFindPathOfDataViewer_LT.Enabled = chkEnableDataViewerLink_LT.Checked
    End Sub

    Private Sub btnFindPathOfDataViewer_LT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindPathOfDataViewer_LT.Click
        Dim fileDlg As New CMcFile()
        Dim fileInfo As CMcFile.sFILENAME = Nothing

        If fileDlg.GetLoadFileName(CMcFile.eFileType._EXE, fileInfo) = True Then
            tbPathOfDataViewer_LT.Text = fileInfo.strPathAndFName
        End If

    End Sub

#End Region

    Private Sub btnIntensityAdj_SrcSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIntensityAdj_SrcSettings.Click
        Dim settingDlg As New frmKeithleySMUSettings

        settingDlg.UcKeithleySMUSettings1.DisplayMode = g_ConfigInfos.SMUForIVLConfig(0).device
        settingDlg.UcKeithleySMUSettings1.ControlUI = g_ConfigInfos.SMUForIVLConfig(0).sRangeList

        settingDlg.UcKeithleySMUSettings1.Settings = m_Option.ACFData.sIntensityAdj_Settings

        If settingDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            m_Option.ACFData.sIntensityAdj_Settings = settingDlg.UcKeithleySMUSettings1.Settings
        End If

    End Sub

    Private Sub btnGetCurrentCCDPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetCurrentCCDPos.Click
        tbCCDPos_X.Text = fMain.frmMotionUI.ucMotionIndicator.XPos
        tbCCDPos_Y.Text = fMain.frmMotionUI.ucMotionIndicator.YPos
        tbCCDPos_Z.Text = fMain.frmMotionUI.ucMotionIndicator.ZPos
    End Sub

    Private Sub btnGetSpectrometePos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetSpectrometePos.Click
        tbSpectrometerPos_X.Text = fMain.frmMotionUI.ucMotionIndicator.XPos
        tbSpectrometerPos_Y.Text = fMain.frmMotionUI.ucMotionIndicator.YPos
        tbSpectrometerPos_Z.Text = fMain.frmMotionUI.ucMotionIndicator.ZPos
    End Sub

    Private Sub btnGetHEXAPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetHEXAPos.Click
        tbHEXAPos_X.Text = fMain.frmMotionUI.ucMotionIndicator.XPos
        tbHEXAPos_Y.Text = fMain.frmMotionUI.ucMotionIndicator.YPos
        tbHEXAPos_Z.Text = fMain.frmMotionUI.ucMotionIndicator.ZPos
    End Sub

    Private Sub btnGetMCRPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetMCRPos.Click
        tbMCRPos_X.Text = fMain.frmMotionUI.ucMotionIndicator.XPos
        tbMCRPos_Y.Text = fMain.frmMotionUI.ucMotionIndicator.YPos
        tbMCRPos_Z.Text = fMain.frmMotionUI.ucMotionIndicator.ZPos
    End Sub

    Private Sub btnCalCCTtoSpectrometerDistance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalCCDtoSpectrometerDistance.Click
        Try
            tbCCDtoSpectrometerPos_X.Text = CStr(CDbl(tbSpectrometerPos_X.Text) - CDbl(tbCCDPos_X.Text))
            tbCCDtoSpectrometerPos_Y.Text = CStr(CDbl(tbSpectrometerPos_Y.Text) - CDbl(tbCCDPos_Y.Text))
            tbCCDtoSpectrometerPos_Z.Text = CStr(CDbl(tbSpectrometerPos_Z.Text) - CDbl(tbCCDPos_Z.Text))
        Catch ex As Exception
            MsgBox("Cal fail(CCDtoSpectrometer)....")
        End Try

    End Sub

    Private Sub btnCalCCDtoHEXADistance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalCCDtoHEXADistance.Click
        Try
            tbCCDtoHEXAPos_X.Text = CStr(CDbl(tbHEXAPos_X.Text) - CDbl(tbCCDPos_X.Text))
            tbCCDtoHEXAPos_Y.Text = CStr(CDbl(tbHEXAPos_Y.Text) - CDbl(tbCCDPos_Y.Text))
            tbCCDtoHEXAPos_Z.Text = CStr(CDbl(tbHEXAPos_Z.Text) - CDbl(tbCCDPos_Z.Text))
        Catch ex As Exception
            MsgBox("Cal fail(CCDtoHEXA)....")
        End Try
    End Sub

    Private Sub btnCalCCTtoMCRDistance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalCCDtoMCRDistance.Click
        Try
            tbCCDtoMCRPos_X.Text = CStr(CDbl(tbCCDtoMCRPos_X.Text) - CDbl(tbCCDPos_X.Text))
            tbCCDtoMCRPos_Y.Text = CStr(CDbl(tbCCDtoMCRPos_X.Text) - CDbl(tbCCDPos_Y.Text))
            tbCCDtoMCRPos_Z.Text = CStr(CDbl(tbCCDtoMCRPos_X.Text) - CDbl(tbCCDPos_Z.Text))
        Catch ex As Exception
            MsgBox("Cal fail(CCDtoSpectrometer)....")
        End Try
    End Sub



    Private Sub btnSetCCDAttribute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetCCDAttribute.Click
        Dim attributeValue As Double
        Dim sCategory As String = ""

        If m_sAttributes Is Nothing Then Exit Sub

        If fMain.cVision Is Nothing Then Exit Sub

        Try
            attributeValue = CDbl(tbAttributeValue.Text)
        Catch ex As Exception
            MsgBox("Check Input Value")
            Exit Sub
        End Try

        If fMain.cVision.myVisionCamera.SetAttributeValue(m_sAttributes(cbAttributes.SelectedIndex), attributeValue, tbAttributeString.Text, sCategory) = False Then
            MsgBox("Failed")
        End If
    End Sub

    Private Sub btnGetCCDValRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetCCDValRange.Click

    End Sub

    Private Sub cbAttributes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAttributes.SelectedIndexChanged
        Dim attributeValue As Double
        Dim sCategory As String = New String(" ", 100)
        Dim sValue As String = Nothing

        If m_sAttributes Is Nothing Then Exit Sub

        If fMain.cVision Is Nothing Then Exit Sub

        If fMain.cVision.myVisionCamera.GetAttributeValue(m_sAttributes(cbAttributes.SelectedIndex), attributeValue, sValue, sCategory) = True Then
            lblCategory.Text = sCategory
            tbAttributeValue.Text = CStr(attributeValue)
            tbAttributeString.Text = sValue
        End If
    End Sub

    Private Sub btnDefSavePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefSavePath.Click
        Dim fileDlg As New CMcFile()
        Dim strPath As String = Nothing

        If fileDlg.FindFolder(strPath) = True Then
            tbDefSavePath.Text = strPath
        End If
    End Sub

    Private Function ConvertToDouble(ByVal str As String) As Double
        Try
            Return CDbl(str)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function ConvertStringToIVLDataPlotItems(ByVal str As String) As eIVLDataIndex

        Select Case str
            Case sIVLDataPlotItems(eIVLDataIndex.eEmpty)
                Return eIVLDataIndex.eEmpty
            Case sIVLDataPlotItems(eIVLDataIndex.eNo)
                Return eIVLDataIndex.eNo
            Case sIVLDataPlotItems(eIVLDataIndex.eMode)
                Return eIVLDataIndex.eMode
            Case sIVLDataPlotItems(eIVLDataIndex.eArea)
                Return eIVLDataIndex.eArea
            Case sIVLDataPlotItems(eIVLDataIndex.eTemperature)
                Return eIVLDataIndex.eTemperature
            Case sIVLDataPlotItems(eIVLDataIndex.eVoltage)
                Return eIVLDataIndex.eVoltage
            Case sIVLDataPlotItems(eIVLDataIndex.eCurrent)
                Return eIVLDataIndex.eCurrent
            Case sIVLDataPlotItems(eIVLDataIndex.eABSCurrent)
                Return eIVLDataIndex.eABSCurrent
            Case sIVLDataPlotItems(eIVLDataIndex.eLuminance_Fill)
                Return eIVLDataIndex.eLuminance_Fill
            Case sIVLDataPlotItems(eIVLDataIndex.eLuminance)
                Return eIVLDataIndex.eLuminance
            Case sIVLDataPlotItems(eIVLDataIndex.eCIEx)
                Return eIVLDataIndex.eCIEx
            Case sIVLDataPlotItems(eIVLDataIndex.eCIEy)
                Return eIVLDataIndex.eCIEy
            Case sIVLDataPlotItems(eIVLDataIndex.eCCT)
                Return eIVLDataIndex.eCCT
            Case sIVLDataPlotItems(eIVLDataIndex.eCurrentEfficiency)
                Return eIVLDataIndex.eCurrentEfficiency
            Case sIVLDataPlotItems(eIVLDataIndex.eJ)
                Return eIVLDataIndex.eJ
            Case sIVLDataPlotItems(eIVLDataIndex.eCIEu)
                Return eIVLDataIndex.eCIEu
            Case sIVLDataPlotItems(eIVLDataIndex.eCIEv)
                Return eIVLDataIndex.eCIEv
            Case sIVLDataPlotItems(eIVLDataIndex.ePowerEfficiency)
                Return eIVLDataIndex.ePowerEfficiency
            Case sIVLDataPlotItems(eIVLDataIndex.eAbsJ)
                Return eIVLDataIndex.eAbsJ
            Case sIVLDataPlotItems(eIVLDataIndex.eQE)
                Return eIVLDataIndex.eQE
                'Case sIVLDataPlotItems(eIVLDataIndex.eBR_Red)
                '    Return eIVLDataIndex.eBR_Red
                'Case sIVLDataPlotItems(eIVLDataIndex.eBR_Green)
                '    Return eIVLDataIndex.eBR_Green
                'Case sIVLDataPlotItems(eIVLDataIndex.eBR_Blue)
                '    Return eIVLDataIndex.eBR_Blue
                'Case sIVLDataPlotItems(eIVLDataIndex.eBR_White)
                '    Return eIVLDataIndex.eBR_White
                'Case sIVLDataPlotItems(eIVLDataIndex.eLR_Red)
                '    Return eIVLDataIndex.eLR_Red
                'Case sIVLDataPlotItems(eIVLDataIndex.eLR_Green)
                '    Return eIVLDataIndex.eLR_Green
                'Case sIVLDataPlotItems(eIVLDataIndex.eLR_Blue)
                '    Return eIVLDataIndex.eLR_Blue
                'Case sIVLDataPlotItems(eIVLDataIndex.eLR_White)
                '    Return eIVLDataIndex.eLR_White
            Case sIVLDataPlotItems(eIVLDataIndex.eFWHM)
                Return eIVLDataIndex.eFWHM

            Case sIVLDataPlotItems(eIVLDataIndex.eX)
                Return eIVLDataIndex.eX
            Case sIVLDataPlotItems(eIVLDataIndex.eY)
                Return eIVLDataIndex.eY
            Case sIVLDataPlotItems(eIVLDataIndex.eZ)
                Return eIVLDataIndex.eZ
            Case sIVLDataPlotItems(eIVLDataIndex.eDuv)
                Return eIVLDataIndex.eDuv
            Case sIVLDataPlotItems(eIVLDataIndex.eLe)
                Return eIVLDataIndex.eLe
            Case sIVLDataPlotItems(eIVLDataIndex.eViewingAngle)
                Return eIVLDataIndex.eViewingAngle
                'Case sIVLDataPlotItems(eIVLDataIndex.eIntegrationTime)
                '    Return eIVLDataIndex.eIntegrationTime
            Case Else
                Return -1
        End Select
    End Function


    Public Shared Function ConvertStringToVADataPlotItems(ByVal str As String) As eVADataIndex

        Select Case str
            Case sVADataPlotItems(eVADataIndex.eEmpty)
                Return eVADataIndex.eEmpty
            Case sVADataPlotItems(eVADataIndex.eNo)
                Return eVADataIndex.eNo
            Case sVADataPlotItems(eVADataIndex.eMode)
                Return eVADataIndex.eMode
            Case sVADataPlotItems(eVADataIndex.eArea)
                Return eVADataIndex.eArea
            Case sVADataPlotItems(eVADataIndex.eTemperature)
                Return eVADataIndex.eTemperature
            Case sVADataPlotItems(eVADataIndex.eVoltage)
                Return eVADataIndex.eVoltage
            Case sVADataPlotItems(eVADataIndex.eCurrent)
                Return eVADataIndex.eCurrent
            Case sVADataPlotItems(eVADataIndex.eLuminance_Fill)
                Return eVADataIndex.eLuminance_Fill
            Case sVADataPlotItems(eVADataIndex.eLuminance)
                Return eVADataIndex.eLuminance
            Case sVADataPlotItems(eVADataIndex.eCIEx)
                Return eVADataIndex.eCIEx
            Case sVADataPlotItems(eVADataIndex.eCIEy)
                Return eVADataIndex.eCIEy
            Case sVADataPlotItems(eVADataIndex.eCCT)
                Return eVADataIndex.eCCT
            Case sVADataPlotItems(eVADataIndex.eCurrentEfficiency)
                Return eVADataIndex.eCurrentEfficiency
            Case sVADataPlotItems(eVADataIndex.eJ)
                Return eVADataIndex.eJ
            Case sVADataPlotItems(eVADataIndex.eCIEu)
                Return eVADataIndex.eCIEu
            Case sVADataPlotItems(eVADataIndex.eCIEv)
                Return eVADataIndex.eCIEv
            Case sVADataPlotItems(eVADataIndex.ePowerEfficiency)
                Return eVADataIndex.ePowerEfficiency
            Case sVADataPlotItems(eVADataIndex.eAbsJ)
                Return eVADataIndex.eAbsJ
            Case sVADataPlotItems(eVADataIndex.eQE)
                Return eVADataIndex.eQE
            Case sVADataPlotItems(eVADataIndex.eFWHM)
                Return eVADataIndex.eFWHM
            Case sVADataPlotItems(eVADataIndex.eDeltauv)
                Return eVADataIndex.eDeltauv
            Case sVADataPlotItems(eVADataIndex.eAngle)
                Return eVADataIndex.eAngle

            Case Else
                Return -1
        End Select
    End Function

    Public Shared Function ConvertStringToLTDataPlotItems(ByVal str As String) As eLTDataIndex

        Select Case str
            Case sLTDataPlotItems(eLTDataIndex.eEmpty)
                Return eLTDataIndex.eEmpty
            Case sLTDataPlotItems(eLTDataIndex.eHourPass)
                Return eLTDataIndex.eHourPass
            Case sLTDataPlotItems(eLTDataIndex.eTime)
                Return eLTDataIndex.eTime
            Case sLTDataPlotItems(eLTDataIndex.eArea)
                Return eLTDataIndex.eArea
            Case sLTDataPlotItems(eLTDataIndex.eTemp)
                Return eLTDataIndex.eTemp
            Case sLTDataPlotItems(eLTDataIndex.eVoltage)
                Return eLTDataIndex.eVoltage
            Case sLTDataPlotItems(eLTDataIndex.eDeltaVoltage)
                Return eLTDataIndex.eDeltaVoltage
            Case sLTDataPlotItems(eLTDataIndex.eAmplitudeVoltage)
                Return eLTDataIndex.eAmplitudeVoltage
            Case sLTDataPlotItems(eLTDataIndex.eCurrent)
                Return eLTDataIndex.eCurrent
            Case sLTDataPlotItems(eLTDataIndex.eCurrent_Per)
                Return eLTDataIndex.eCurrent_Per
            Case sLTDataPlotItems(eLTDataIndex.eDeltaCurrent)
                Return eLTDataIndex.eDeltaCurrent
            Case sLTDataPlotItems(eLTDataIndex.eAmplitudeCurrent)
                Return eLTDataIndex.eAmplitudeCurrent
            Case sLTDataPlotItems(eLTDataIndex.eCurrentDensity)
                Return eLTDataIndex.eCurrentDensity
            Case sLTDataPlotItems(eLTDataIndex.eLuminance_Fill_cdm2)
                Return eLTDataIndex.eLuminance_Fill_cdm2
            Case sLTDataPlotItems(eLTDataIndex.eLuminance_cdm2)
                Return eLTDataIndex.eLuminance_cdm2
            Case sLTDataPlotItems(eLTDataIndex.eLuminanace_Per)
                Return eLTDataIndex.eLuminanace_Per
            Case sLTDataPlotItems(eLTDataIndex.eCurrentEfficiency)
                Return eLTDataIndex.eCurrentEfficiency
            Case sLTDataPlotItems(eLTDataIndex.eCurrentEfficiency_Per)
                Return eLTDataIndex.eCurrentEfficiency_Per
            Case sLTDataPlotItems(eLTDataIndex.eQE)
                Return eLTDataIndex.eQE
            Case sLTDataPlotItems(eLTDataIndex.eCIEx)
                Return eLTDataIndex.eCIEx
            Case sLTDataPlotItems(eLTDataIndex.eCIEy)
                Return eLTDataIndex.eCIEy
            Case sLTDataPlotItems(eLTDataIndex.eCIEu)
                Return eLTDataIndex.eCIEu
            Case sLTDataPlotItems(eLTDataIndex.eCIEv)
                Return eLTDataIndex.eCIEv
            Case sLTDataPlotItems(eLTDataIndex.eDeltauv)
                Return eLTDataIndex.eDeltauv
            Case sLTDataPlotItems(eLTDataIndex.eCCT)
                Return eLTDataIndex.eCCT
            Case sLTDataPlotItems(eLTDataIndex.eSpectrumSum_Per)
                Return eLTDataIndex.eSpectrumSum_Per
            Case sLTDataPlotItems(eLTDataIndex.eELMax)
                Return eLTDataIndex.eELMax
            Case sLTDataPlotItems(eLTDataIndex.eFHWM)
                Return eLTDataIndex.eFHWM
            Case sLTDataPlotItems(eLTDataIndex.eCHNum)
                Return eLTDataIndex.eCHNum
            Case sLTDataPlotItems(eLTDataIndex.eLuminance_Fill_Per)
                Return eLTDataIndex.eLuminance_Fill_Per
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL1)
                Return eLTDataIndex.eIntegWL1
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL2)
                Return eLTDataIndex.eIntegWL2
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL3)
                Return eLTDataIndex.eIntegWL3
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL4)
                Return eLTDataIndex.eIntegWL4
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL_Photopic1)
                Return eLTDataIndex.eIntegWL_Photopic1
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL_Photopic2)
                Return eLTDataIndex.eIntegWL_Photopic2
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL_Photopic3)
                Return eLTDataIndex.eIntegWL_Photopic3
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL_Photopic4)
                Return eLTDataIndex.eIntegWL_Photopic4
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL1_Per)
                Return eLTDataIndex.eIntegWL1_Per
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL2_Per)
                Return eLTDataIndex.eIntegWL2_Per
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL3_Per)
                Return eLTDataIndex.eIntegWL3_Per
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL4_Per)
                Return eLTDataIndex.eIntegWL4_Per
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL_Photopic1_Per)
                Return eLTDataIndex.eIntegWL_Photopic1_Per
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL_Photopic2_Per)
                Return eLTDataIndex.eIntegWL_Photopic2_Per
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL_Photopic3_Per)
                Return eLTDataIndex.eIntegWL_Photopic3_Per
            Case sLTDataPlotItems(eLTDataIndex.eIntegWL_Photopic4_Per)
                Return eLTDataIndex.eIntegWL_Photopic4_Per
            Case Else
                Return -1
        End Select
    End Function


    Private Sub btn_IVLDataADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_IVLDataADD.Click
        Dim sDev(1) As String
        Dim nrow As Integer
        Dim sReturn() As String = Nothing

        If ucDispIVLDataIndex.GetListItemCount <> 0 Then
            For i As Integer = 0 To ucDispIVLDataIndex.GetListItemCount - 1
                If ucDispIVLDataIndex.GetRowData(i, sReturn) = ucDispListView.eUcListErrCode.eNoError Then
                    If sReturn.Contains(sIVLDataPlotItems(cboIVLDataFormat.SelectedIndex)) = True Then
                        If MsgBox("The corresponding parameter has already been added. Do you want to add?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            nrow = cboIVLDataFormat.SelectedIndex
                            sDev(0) = ucDispIVLDataIndex.GetListItemCount + 1
                            sDev(1) = sIVLDataPlotItems(nrow)
                            ucDispIVLDataIndex.AddRowData(sDev)
                            Exit Sub
                        End If
                    End If
                End If
            Next
            nrow = cboIVLDataFormat.SelectedIndex
            sDev(0) = ucDispIVLDataIndex.GetListItemCount + 1
            sDev(1) = sIVLDataPlotItems(nrow)
            ucDispIVLDataIndex.AddRowData(sDev)
        Else
            nrow = cboIVLDataFormat.SelectedIndex
            sDev(0) = ucDispIVLDataIndex.GetListItemCount + 1
            sDev(1) = sIVLDataPlotItems(nrow)
            ucDispIVLDataIndex.AddRowData(sDev)
        End If

    End Sub

    Private Sub btn_IVLDataDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_IVLDataDel.Click
        Dim nrow As Integer

        ucDispIVLDataIndex.GetSelectedRowNumber(nrow)
        ucDispIVLDataIndex.DelSelectedRow(nrow)
    End Sub

    Private Sub btn_LifetimeDataADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_LifetimeDataADD.Click
        Dim sDev(1) As String
        Dim nrow As Integer
        Dim sReturn() As String = Nothing

        If ucDispLTDataIndex.GetListItemCount <> 0 Then
            For i As Integer = 0 To ucDispLTDataIndex.GetListItemCount - 1
                If ucDispLTDataIndex.GetRowData(i, sReturn) = ucDispListView.eUcListErrCode.eNoError Then
                    If sReturn.Contains(sLTDataPlotItems(cboLTDataFormat.SelectedIndex)) = True Then
                        If MsgBox("The corresponding parameter has already been added. Do you want to add?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            nrow = cboLTDataFormat.SelectedIndex
                            sDev(0) = ucDispLTDataIndex.GetListItemCount + 1
                            sDev(1) = sLTDataPlotItems(nrow)
                            ucDispLTDataIndex.AddRowData(sDev)
                            Exit Sub
                        End If
                    End If
                End If
            Next
            nrow = cboLTDataFormat.SelectedIndex
            sDev(0) = ucDispLTDataIndex.GetListItemCount + 1
            sDev(1) = sLTDataPlotItems(nrow)
            ucDispLTDataIndex.AddRowData(sDev)
        Else
            nrow = cboLTDataFormat.SelectedIndex
            sDev(0) = ucDispLTDataIndex.GetListItemCount + 1
            sDev(1) = sLTDataPlotItems(nrow)
            ucDispLTDataIndex.AddRowData(sDev)
        End If
    End Sub

    Private Sub btn_LifetimeDataDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_LifetimeDataDel.Click
        Dim nrow As Integer

        ucDispLTDataIndex.GetSelectedRowNumber(nrow)
        ucDispLTDataIndex.DelSelectedRow(nrow)
    End Sub


    Private Sub btn_VADataADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sDev(1) As String
        Dim nrow As Integer
        Dim sReturn() As String = Nothing

        'If ucDispVADataIndex.GetListItemCount <> 0 Then
        '    For i As Integer = 0 To ucDispVADataIndex.GetListItemCount - 1
        '        If ucDispVADataIndex.GetRowData(i, sReturn) = ucDispListView.eUcListErrCode.eNoError Then
        '            If sReturn.Contains(sVADataPlotItems(cboVADataFormat.SelectedIndex)) = True Then
        '                If MsgBox("The corresponding parameter has already been added. Do you want to add?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '                    nrow = cboVADataFormat.SelectedIndex
        '                    sDev(0) = ucDispVADataIndex.GetListItemCount + 1
        '                    sDev(1) = sVADataPlotItems(nrow)
        '                    ucDispVADataIndex.AddRowData(sDev)
        '                    Exit Sub
        '                End If
        '            End If
        '        End If
        '    Next
        '    nrow = cboVADataFormat.SelectedIndex
        '    sDev(0) = ucDispVADataIndex.GetListItemCount + 1
        '    sDev(1) = sVADataPlotItems(nrow)
        '    ucDispVADataIndex.AddRowData(sDev)
        'Else
        '    nrow = cboVADataFormat.SelectedIndex
        '    sDev(0) = ucDispVADataIndex.GetListItemCount + 1
        '    sDev(1) = sVADataPlotItems(nrow)
        '    ucDispVADataIndex.AddRowData(sDev)
        'End If
    End Sub

    Private Sub btn_VADataDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nrow As Integer

        'ucDispVADataIndex.GetSelectedRowNumber(nrow)
        'ucDispVADataIndex.DelSelectedRow(nrow)
    End Sub



    Private Sub btnWADFactor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWADFactor.Click
        Dim dlg As New frmWADSet
        '   dlg.fMain = Me
        dlg.Settings = m_Option.MotionData.sWADCalFactor

        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            m_Option.MotionData.sWADCalFactor = dlg.Settings
        End If


    End Sub

    Private Sub btnCheckContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckContact.Click
        Dim dlg As New frmCheckContact
        '   dlg.fMain = Me
        dlg.Settings = m_Option.sCheckContact

        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            m_Option.sCheckContact = dlg.Settings
        End If

    End Sub

    Private Sub btnCaptureImgPathFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCaptureImgPathFind.Click
        Dim FolderDlg As New FolderBrowserDialog

        If FolderDlg.ShowDialog() = DialogResult.OK Then
            tbCaptureImagePath.Text = FolderDlg.SelectedPath
        End If
    End Sub

    Private Sub chkSpectroMeasureMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSpectroMeasureMode.CheckedChanged
        If chkSpectroMeasureMode.Checked = True Then
            chkSpectroMeasureMode.Text = "AUTO"
            tbExposureTime.Enabled = False
        ElseIf chkSpectroMeasureMode.Checked = False Then
            chkSpectroMeasureMode.Text = "MANUAL"
            tbExposureTime.Enabled = True
        End If
    End Sub


    Private Sub cbIVLSweepSpeedMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIVLSweepSpeedMode.SelectedIndexChanged
        If cbIVLSweepSpeedMode.SelectedIndex = 0 Then
            tbExposureTime.Enabled = False
        Else
            tbExposureTime.Enabled = True
        End If
    End Sub

    Private Sub BtnBackupSavePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fileDlg As New CMcFile()
        Dim strPath As String = Nothing

        If fileDlg.FindFolder(strPath) = True Then
            '   tbBackupSavePath.Text = strPath
        End If
    End Sub

    Private Sub cbACFSrcMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbACFSrcMode.SelectedIndexChanged
        If cbACFSrcMode.SelectedIndex = 0 Then
            lbACFStartUnit.Text = "V"
            lbACFStepUnit.Text = "V"
            lbACFStopUnit.Text = "V"
        Else
            lbACFStartUnit.Text = "mA"
            lbACFStepUnit.Text = "mA"
            lbACFStopUnit.Text = "mA"
        End If
    End Sub
End Class


