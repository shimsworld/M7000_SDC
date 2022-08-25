<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptionWindow
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tcOptions = New System.Windows.Forms.TabControl()
        Me.tpSave = New System.Windows.Forms.TabPage()
        Me.GroupBox27 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkLTRenewalTime = New System.Windows.Forms.CheckBox()
        Me.chkLTFileversion = New System.Windows.Forms.CheckBox()
        Me.chkLTFilename = New System.Windows.Forms.CheckBox()
        Me.chkLTMeasMode = New System.Windows.Forms.CheckBox()
        Me.chkLTBiasMode = New System.Windows.Forms.CheckBox()
        Me.GroupBox24 = New System.Windows.Forms.GroupBox()
        Me.ucDispLTDataIndex = New M7000.ucDispListView()
        Me.cboLTDataFormat = New System.Windows.Forms.ComboBox()
        Me.btn_LifetimeDataDel = New System.Windows.Forms.Button()
        Me.btn_LifetimeDataADD = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.chkIVLLumiMeasLevel = New System.Windows.Forms.CheckBox()
        Me.chkIVLSweepMode = New System.Windows.Forms.CheckBox()
        Me.chkIVLBiasMode = New System.Windows.Forms.CheckBox()
        Me.chkIVLMeasMode = New System.Windows.Forms.CheckBox()
        Me.chkIVLFilename = New System.Windows.Forms.CheckBox()
        Me.chkIVLFileversion = New System.Windows.Forms.CheckBox()
        Me.GroupBox23 = New System.Windows.Forms.GroupBox()
        Me.ucDispIVLDataIndex = New M7000.ucDispListView()
        Me.cboIVLDataFormat = New System.Windows.Forms.ComboBox()
        Me.btn_IVLDataDel = New System.Windows.Forms.Button()
        Me.btn_IVLDataADD = New System.Windows.Forms.Button()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.tbLumiPerSpectrumSave = New System.Windows.Forms.TextBox()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnDefSavePath = New System.Windows.Forms.Button()
        Me.tbDefSavePath = New System.Windows.Forms.TextBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.cbFileType = New System.Windows.Forms.ComboBox()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.chkSaveOpt_AddDate = New System.Windows.Forms.CheckBox()
        Me.chkSaveOpt_AddExpMode = New System.Windows.Forms.CheckBox()
        Me.chkSaveOpt_AddUserInputFileName = New System.Windows.Forms.CheckBox()
        Me.chkSaveOpt_AddChNum = New System.Windows.Forms.CheckBox()
        Me.tpMotion = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkEndHomming = New System.Windows.Forms.CheckBox()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.btnCheckContact = New System.Windows.Forms.Button()
        Me.btnWADFactor = New System.Windows.Forms.Button()
        Me.GroupBox31 = New System.Windows.Forms.GroupBox()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.tbThetaOffset = New System.Windows.Forms.TextBox()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.tbThetaRatio = New System.Windows.Forms.TextBox()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.tbThetaDeviation = New System.Windows.Forms.TextBox()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.GroupBox28 = New System.Windows.Forms.GroupBox()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.tbCCDtoHEXAPos_X = New System.Windows.Forms.TextBox()
        Me.tbCCDtoHEXAPos_Y = New System.Windows.Forms.TextBox()
        Me.tbCCDtoHEXAPos_Z = New System.Windows.Forms.TextBox()
        Me.btnCalCCDtoHEXADistance = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbCCDtoSpectrometerPos_X = New System.Windows.Forms.TextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.tbCCDtoSpectrometerPos_Y = New System.Windows.Forms.TextBox()
        Me.btnCalCCDtoMCRDistance = New System.Windows.Forms.Button()
        Me.tbCCDtoSpectrometerPos_Z = New System.Windows.Forms.TextBox()
        Me.tbCCDtoMCRPos_Z = New System.Windows.Forms.TextBox()
        Me.btnCalCCDtoSpectrometerDistance = New System.Windows.Forms.Button()
        Me.tbCCDtoMCRPos_Y = New System.Windows.Forms.TextBox()
        Me.tbCCDtoMCRPos_X = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tbHEXAPos_Y = New System.Windows.Forms.TextBox()
        Me.tbHEXAPos_X = New System.Windows.Forms.TextBox()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.tbHEXAPos_Z = New System.Windows.Forms.TextBox()
        Me.btnGetHEXAPos = New System.Windows.Forms.Button()
        Me.tbSpectrometerPos_Y = New System.Windows.Forms.TextBox()
        Me.btnGetMCRPos = New System.Windows.Forms.Button()
        Me.tbCCDPos_X = New System.Windows.Forms.TextBox()
        Me.tbMCRPos_Z = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbMCRPos_Y = New System.Windows.Forms.TextBox()
        Me.tbSpectrometerPos_X = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbMCRPos_X = New System.Windows.Forms.TextBox()
        Me.tbCCDPos_Y = New System.Windows.Forms.TextBox()
        Me.tbCCDPos_Z = New System.Windows.Forms.TextBox()
        Me.tbSpectrometerPos_Z = New System.Windows.Forms.TextBox()
        Me.btnGetCurrentCCDPos = New System.Windows.Forms.Button()
        Me.btnGetSpectrometePos = New System.Windows.Forms.Button()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.Label115 = New System.Windows.Forms.Label()
        Me.tbDistance_Theta_Y = New System.Windows.Forms.TextBox()
        Me.lblDistance_Theta = New System.Windows.Forms.Label()
        Me.tbDistance_Theta = New System.Windows.Forms.TextBox()
        Me.lblDistance_Z = New System.Windows.Forms.Label()
        Me.tbDistance_Z = New System.Windows.Forms.TextBox()
        Me.lblDistance_Y = New System.Windows.Forms.Label()
        Me.lblDistance_X = New System.Windows.Forms.Label()
        Me.btnSetDistance = New System.Windows.Forms.Button()
        Me.tbDistance_Y = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.tbDistance_X = New System.Windows.Forms.TextBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.tbPosPerDistance_Theta = New System.Windows.Forms.TextBox()
        Me.lblMotionPos_Theta = New System.Windows.Forms.Label()
        Me.btnCalPosPerDistance = New System.Windows.Forms.Button()
        Me.tbCalPos_Theta = New System.Windows.Forms.TextBox()
        Me.tbEndPos_Theta = New System.Windows.Forms.TextBox()
        Me.tbStartPos_Theta = New System.Windows.Forms.TextBox()
        Me.tbPosPerDistance_Z = New System.Windows.Forms.TextBox()
        Me.lblMotionPos_Z = New System.Windows.Forms.Label()
        Me.tbCalPos_Z = New System.Windows.Forms.TextBox()
        Me.tbEndPos_Z = New System.Windows.Forms.TextBox()
        Me.tbStartPos_Z = New System.Windows.Forms.TextBox()
        Me.chkCalPosPerDistance = New System.Windows.Forms.CheckBox()
        Me.tbPosPerDistance_Y = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.tbPosPerDistance_X = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.lblMotionPos_Y = New System.Windows.Forms.Label()
        Me.lblMotionPos_X = New System.Windows.Forms.Label()
        Me.btnGetEndPos = New System.Windows.Forms.Button()
        Me.btnGetStartPos = New System.Windows.Forms.Button()
        Me.tbCalPos_Y = New System.Windows.Forms.TextBox()
        Me.tbEndPos_Y = New System.Windows.Forms.TextBox()
        Me.tbStartPos_Y = New System.Windows.Forms.TextBox()
        Me.tbCalPos_X = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.tbEndPos_X = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.tbStartPos_X = New System.Windows.Forms.TextBox()
        Me.tpTemp = New System.Windows.Forms.TabPage()
        Me.GroupBox22 = New System.Windows.Forms.GroupBox()
        Me.GroupBox26 = New System.Windows.Forms.GroupBox()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.chkSpectroMeasureMode = New System.Windows.Forms.CheckBox()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.cbIVLSweepSpeedMode = New System.Windows.Forms.ComboBox()
        Me.tbExposureTime = New System.Windows.Forms.TextBox()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.cbIVLSweepAperture = New System.Windows.Forms.ComboBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.GroupBox25 = New System.Windows.Forms.GroupBox()
        Me.cbSpeedMode = New System.Windows.Forms.ComboBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.cbAperture = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cbAngleGain = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbTemp_LimitAlarmHigh = New System.Windows.Forms.TextBox()
        Me.cbLifetimeGain = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.tbTemp_LimitAlarmLow = New System.Windows.Forms.TextBox()
        Me.cbIVLSweepGain = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tbTemp_Margin = New System.Windows.Forms.TextBox()
        Me.tpDisplay = New System.Windows.Forms.TabPage()
        Me.tbDispDigit_Integral_Relative = New System.Windows.Forms.TextBox()
        Me.ucSelDispType_Photocurrent = New M7000.ucSelectValueTypeAndUnit()
        Me.tbDispDigit_Integral = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.gbSampleInfos = New System.Windows.Forms.GroupBox()
        Me.tbSampleHeight = New System.Windows.Forms.TextBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.tbSampleWidth = New System.Windows.Forms.TextBox()
        Me.tbFill = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.GroupBox21 = New System.Windows.Forms.GroupBox()
        Me.chkVisibleAngleMoveButton = New System.Windows.Forms.CheckBox()
        Me.chkVisibleChannelMoveButton = New System.Windows.Forms.CheckBox()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.chkFilenameTEGtoTEGChannel = New System.Windows.Forms.CheckBox()
        Me.rdoDispCh_JIGAndCellNo = New System.Windows.Forms.RadioButton()
        Me.rdoDispCh_Channel = New System.Windows.Forms.RadioButton()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.gnNumOfOutdataDsipMDX = New System.Windows.Forms.GroupBox()
        Me.ChkOut_5 = New System.Windows.Forms.CheckBox()
        Me.ChkOut_4 = New System.Windows.Forms.CheckBox()
        Me.ChkOut_3 = New System.Windows.Forms.CheckBox()
        Me.ChkOut_2 = New System.Windows.Forms.CheckBox()
        Me.ChkOut_1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.ucSelDispType_Current = New M7000.ucSelectValueTypeAndUnit()
        Me.ucSelDispType_Volt = New M7000.ucSelectValueTypeAndUnit()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.tbDispDigit_Current = New System.Windows.Forms.TextBox()
        Me.tbDispDigit_Volt = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.tbDispDigit_Photocurrent = New System.Windows.Forms.TextBox()
        Me.tpStatusColor = New System.Windows.Forms.TabPage()
        Me.ucDispFontColorList = New M7000.ucDispListView()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.btnColorAdd = New System.Windows.Forms.Button()
        Me.btnColorDel = New System.Windows.Forms.Button()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.lbColor = New System.Windows.Forms.Label()
        Me.tpCCD = New System.Windows.Forms.TabPage()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.cbAnalysisMode = New System.Windows.Forms.ComboBox()
        Me.GroupBox32 = New System.Windows.Forms.GroupBox()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.tbCaptureLevel = New System.Windows.Forms.TextBox()
        Me.btnCaptureImgPathFind = New System.Windows.Forms.Button()
        Me.tbCaptureImagePath = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.tbAttributeString = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.tbCCDExposureValue = New System.Windows.Forms.TextBox()
        Me.btnGetCCDValRange = New System.Windows.Forms.Button()
        Me.btnSetCCDAttribute = New System.Windows.Forms.Button()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.tbAttributeValue = New System.Windows.Forms.TextBox()
        Me.cbAttributes = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.tpParamRange = New System.Windows.Forms.TabPage()
        Me.gbMDXSetting = New System.Windows.Forms.GroupBox()
        Me.gbAMXSetting = New System.Windows.Forms.GroupBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtHighSignal = New System.Windows.Forms.TextBox()
        Me.txtHighSubPower = New System.Windows.Forms.TextBox()
        Me.txtHighMainPower = New System.Windows.Forms.TextBox()
        Me.txtLowSignal = New System.Windows.Forms.TextBox()
        Me.txtLowSubPower = New System.Windows.Forms.TextBox()
        Me.txtLowMainPower = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.gbPMXSetting = New System.Windows.Forms.GroupBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.lblDutyPercent = New System.Windows.Forms.Label()
        Me.lblFrequencyUnit = New System.Windows.Forms.Label()
        Me.lblAmpUnit = New System.Windows.Forms.Label()
        Me.lblValueUnit = New System.Windows.Forms.Label()
        Me.txtHighDuty = New System.Windows.Forms.TextBox()
        Me.txtHighFrequency = New System.Windows.Forms.TextBox()
        Me.txtHighAmplitude = New System.Windows.Forms.TextBox()
        Me.txtBiasHighValue = New System.Windows.Forms.TextBox()
        Me.txtLowDuty = New System.Windows.Forms.TextBox()
        Me.txtLowFrequency = New System.Windows.Forms.TextBox()
        Me.txtLowAmplitude = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.txtBiasLowValue = New System.Windows.Forms.TextBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.tpACF = New System.Windows.Forms.TabPage()
        Me.grbACFPixelPerDistance = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbPixelPerDistance_Hight = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbPixelPerDistance_Width = New System.Windows.Forms.TextBox()
        Me.grbACFImageProcessingParam = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cbBlobFilter = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tbGrayLevelLimit = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tbLowIntensityLimit = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbCCDHigh = New System.Windows.Forms.TextBox()
        Me.Label08 = New System.Windows.Forms.Label()
        Me.Label09 = New System.Windows.Forms.Label()
        Me.tbCCDWidth = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbHighThresholdVal = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbMinBlobRadius = New System.Windows.Forms.TextBox()
        Me.Label07 = New System.Windows.Forms.Label()
        Me.tbLowThresholdVal = New System.Windows.Forms.TextBox()
        Me.Label06 = New System.Windows.Forms.Label()
        Me.tbThreshold = New System.Windows.Forms.TextBox()
        Me.Label05 = New System.Windows.Forms.Label()
        Me.grbACFOptions = New System.Windows.Forms.GroupBox()
        Me.cbSelACFMode = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbFocusParam = New System.Windows.Forms.TextBox()
        Me.Label04 = New System.Windows.Forms.Label()
        Me.tbScanResolution = New System.Windows.Forms.TextBox()
        Me.Label03 = New System.Windows.Forms.Label()
        Me.tbScanRegion_Stop = New System.Windows.Forms.TextBox()
        Me.Label02 = New System.Windows.Forms.Label()
        Me.tbScanRegion_Start = New System.Windows.Forms.TextBox()
        Me.Label01 = New System.Windows.Forms.Label()
        Me.grbACF = New System.Windows.Forms.GroupBox()
        Me.btnIntensityAdj_SrcSettings = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.lbACFStopUnit = New System.Windows.Forms.Label()
        Me.lbACFStepUnit = New System.Windows.Forms.Label()
        Me.lbACFStartUnit = New System.Windows.Forms.Label()
        Me.cbACFSrcMode = New System.Windows.Forms.ComboBox()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbIntesityAdj_Step = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbIntesityAdj_Limit = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbIntesityAdj_Start = New System.Windows.Forms.TextBox()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.tbMdlPatternNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tpLink = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.chkEnableDataViewerLink_LT = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnFindPathOfDataViewer_LT = New System.Windows.Forms.Button()
        Me.tbPathOfDataViewer_LT = New System.Windows.Forms.TextBox()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.chkEnableDataViewerLink_IVL = New System.Windows.Forms.CheckBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.btnFindPathOfDataViewer_IVL = New System.Windows.Forms.Button()
        Me.tbPathOfDataViewer_IVL = New System.Windows.Forms.TextBox()
        Me.btnOptionSave = New System.Windows.Forms.Button()
        Me.btnOptionLoad = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tcOptions.SuspendLayout()
        Me.tpSave.SuspendLayout()
        Me.GroupBox27.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox24.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox23.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.tpMotion.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox31.SuspendLayout()
        Me.GroupBox28.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.tpTemp.SuspendLayout()
        Me.GroupBox22.SuspendLayout()
        Me.GroupBox26.SuspendLayout()
        Me.GroupBox25.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.tpDisplay.SuspendLayout()
        Me.gbSampleInfos.SuspendLayout()
        Me.GroupBox21.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.gnNumOfOutdataDsipMDX.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.tpStatusColor.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.tpCCD.SuspendLayout()
        Me.GroupBox32.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.tpParamRange.SuspendLayout()
        Me.gbAMXSetting.SuspendLayout()
        Me.gbPMXSetting.SuspendLayout()
        Me.tpACF.SuspendLayout()
        Me.grbACFPixelPerDistance.SuspendLayout()
        Me.grbACFImageProcessingParam.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grbACFOptions.SuspendLayout()
        Me.grbACF.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.tpLink.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcOptions
        '
        Me.tcOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcOptions.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcOptions.Controls.Add(Me.tpSave)
        Me.tcOptions.Controls.Add(Me.tpMotion)
        Me.tcOptions.Controls.Add(Me.tpTemp)
        Me.tcOptions.Controls.Add(Me.tpDisplay)
        Me.tcOptions.Controls.Add(Me.tpStatusColor)
        Me.tcOptions.Controls.Add(Me.tpCCD)
        Me.tcOptions.Controls.Add(Me.tpParamRange)
        Me.tcOptions.Controls.Add(Me.tpACF)
        Me.tcOptions.Controls.Add(Me.tpLink)
        Me.tcOptions.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcOptions.Location = New System.Drawing.Point(7, 12)
        Me.tcOptions.Name = "tcOptions"
        Me.tcOptions.SelectedIndex = 0
        Me.tcOptions.Size = New System.Drawing.Size(759, 673)
        Me.tcOptions.TabIndex = 0
        '
        'tpSave
        '
        Me.tpSave.Controls.Add(Me.GroupBox27)
        Me.tpSave.Controls.Add(Me.GroupBox20)
        Me.tpSave.Controls.Add(Me.GroupBox19)
        Me.tpSave.Controls.Add(Me.GroupBox9)
        Me.tpSave.Location = New System.Drawing.Point(4, 27)
        Me.tpSave.Name = "tpSave"
        Me.tpSave.Size = New System.Drawing.Size(751, 642)
        Me.tpSave.TabIndex = 9
        Me.tpSave.Text = "Save"
        Me.tpSave.UseVisualStyleBackColor = True
        '
        'GroupBox27
        '
        Me.GroupBox27.Controls.Add(Me.TabControl1)
        Me.GroupBox27.Location = New System.Drawing.Point(5, 203)
        Me.GroupBox27.Name = "GroupBox27"
        Me.GroupBox27.Size = New System.Drawing.Size(637, 379)
        Me.GroupBox27.TabIndex = 9
        Me.GroupBox27.TabStop = False
        Me.GroupBox27.Text = "DataFormatSettings"
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(9, 23)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(595, 350)
        Me.TabControl1.TabIndex = 8
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkLTRenewalTime)
        Me.TabPage1.Controls.Add(Me.chkLTFileversion)
        Me.TabPage1.Controls.Add(Me.chkLTFilename)
        Me.TabPage1.Controls.Add(Me.chkLTMeasMode)
        Me.TabPage1.Controls.Add(Me.chkLTBiasMode)
        Me.TabPage1.Controls.Add(Me.GroupBox24)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(587, 319)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Lifetime"
        Me.TabPage1.UseVisualStyleBackColor = True
        Me.TabPage1.UseWaitCursor = True
        '
        'chkLTRenewalTime
        '
        Me.chkLTRenewalTime.AutoSize = True
        Me.chkLTRenewalTime.Checked = True
        Me.chkLTRenewalTime.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLTRenewalTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLTRenewalTime.Location = New System.Drawing.Point(401, 129)
        Me.chkLTRenewalTime.Name = "chkLTRenewalTime"
        Me.chkLTRenewalTime.Size = New System.Drawing.Size(103, 19)
        Me.chkLTRenewalTime.TabIndex = 17
        Me.chkLTRenewalTime.Text = "Renewal Time"
        Me.chkLTRenewalTime.UseVisualStyleBackColor = True
        Me.chkLTRenewalTime.UseWaitCursor = True
        '
        'chkLTFileversion
        '
        Me.chkLTFileversion.AutoSize = True
        Me.chkLTFileversion.Checked = True
        Me.chkLTFileversion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLTFileversion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLTFileversion.Location = New System.Drawing.Point(401, 21)
        Me.chkLTFileversion.Name = "chkLTFileversion"
        Me.chkLTFileversion.Size = New System.Drawing.Size(84, 19)
        Me.chkLTFileversion.TabIndex = 13
        Me.chkLTFileversion.Text = "FileVersion"
        Me.chkLTFileversion.UseVisualStyleBackColor = True
        Me.chkLTFileversion.UseWaitCursor = True
        '
        'chkLTFilename
        '
        Me.chkLTFilename.AutoSize = True
        Me.chkLTFilename.Checked = True
        Me.chkLTFilename.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLTFilename.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLTFilename.Location = New System.Drawing.Point(401, 48)
        Me.chkLTFilename.Name = "chkLTFilename"
        Me.chkLTFilename.Size = New System.Drawing.Size(75, 19)
        Me.chkLTFilename.TabIndex = 14
        Me.chkLTFilename.Text = "Filename"
        Me.chkLTFilename.UseVisualStyleBackColor = True
        Me.chkLTFilename.UseWaitCursor = True
        '
        'chkLTMeasMode
        '
        Me.chkLTMeasMode.AutoSize = True
        Me.chkLTMeasMode.Checked = True
        Me.chkLTMeasMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLTMeasMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLTMeasMode.Location = New System.Drawing.Point(401, 75)
        Me.chkLTMeasMode.Name = "chkLTMeasMode"
        Me.chkLTMeasMode.Size = New System.Drawing.Size(89, 19)
        Me.chkLTMeasMode.TabIndex = 15
        Me.chkLTMeasMode.Text = "Meas. Mode"
        Me.chkLTMeasMode.UseVisualStyleBackColor = True
        Me.chkLTMeasMode.UseWaitCursor = True
        '
        'chkLTBiasMode
        '
        Me.chkLTBiasMode.AutoSize = True
        Me.chkLTBiasMode.Checked = True
        Me.chkLTBiasMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLTBiasMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLTBiasMode.Location = New System.Drawing.Point(401, 102)
        Me.chkLTBiasMode.Name = "chkLTBiasMode"
        Me.chkLTBiasMode.Size = New System.Drawing.Size(81, 19)
        Me.chkLTBiasMode.TabIndex = 16
        Me.chkLTBiasMode.Text = "Bias Mode"
        Me.chkLTBiasMode.UseVisualStyleBackColor = True
        Me.chkLTBiasMode.UseWaitCursor = True
        '
        'GroupBox24
        '
        Me.GroupBox24.Controls.Add(Me.ucDispLTDataIndex)
        Me.GroupBox24.Controls.Add(Me.cboLTDataFormat)
        Me.GroupBox24.Controls.Add(Me.btn_LifetimeDataDel)
        Me.GroupBox24.Controls.Add(Me.btn_LifetimeDataADD)
        Me.GroupBox24.Location = New System.Drawing.Point(5, 7)
        Me.GroupBox24.Name = "GroupBox24"
        Me.GroupBox24.Size = New System.Drawing.Size(367, 252)
        Me.GroupBox24.TabIndex = 7
        Me.GroupBox24.TabStop = False
        Me.GroupBox24.Text = "Lifetime Data"
        Me.GroupBox24.UseWaitCursor = True
        '
        'ucDispLTDataIndex
        '
        Me.ucDispLTDataIndex.ColHeader = New String() {"No", "Data"}
        Me.ucDispLTDataIndex.ColHeaderWidthRatio = "15,80"
        Me.ucDispLTDataIndex.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucDispLTDataIndex.FullRawSelection = True
        Me.ucDispLTDataIndex.HideSelection = False
        Me.ucDispLTDataIndex.LabelEdit = True
        Me.ucDispLTDataIndex.LabelWrap = True
        Me.ucDispLTDataIndex.Location = New System.Drawing.Point(9, 80)
        Me.ucDispLTDataIndex.Name = "ucDispLTDataIndex"
        Me.ucDispLTDataIndex.Size = New System.Drawing.Size(341, 157)
        Me.ucDispLTDataIndex.TabIndex = 17
        Me.ucDispLTDataIndex.UseCheckBoxex = False
        Me.ucDispLTDataIndex.UseWaitCursor = True
        '
        'cboLTDataFormat
        '
        Me.cboLTDataFormat.FormattingEnabled = True
        Me.cboLTDataFormat.Location = New System.Drawing.Point(9, 35)
        Me.cboLTDataFormat.Name = "cboLTDataFormat"
        Me.cboLTDataFormat.Size = New System.Drawing.Size(194, 23)
        Me.cboLTDataFormat.TabIndex = 16
        Me.cboLTDataFormat.UseWaitCursor = True
        '
        'btn_LifetimeDataDel
        '
        Me.btn_LifetimeDataDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_LifetimeDataDel.Location = New System.Drawing.Point(290, 33)
        Me.btn_LifetimeDataDel.Name = "btn_LifetimeDataDel"
        Me.btn_LifetimeDataDel.Size = New System.Drawing.Size(60, 25)
        Me.btn_LifetimeDataDel.TabIndex = 15
        Me.btn_LifetimeDataDel.Text = "DEL"
        Me.btn_LifetimeDataDel.UseVisualStyleBackColor = True
        Me.btn_LifetimeDataDel.UseWaitCursor = True
        '
        'btn_LifetimeDataADD
        '
        Me.btn_LifetimeDataADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_LifetimeDataADD.Location = New System.Drawing.Point(225, 33)
        Me.btn_LifetimeDataADD.Name = "btn_LifetimeDataADD"
        Me.btn_LifetimeDataADD.Size = New System.Drawing.Size(60, 25)
        Me.btn_LifetimeDataADD.TabIndex = 14
        Me.btn_LifetimeDataADD.Text = "ADD"
        Me.btn_LifetimeDataADD.UseVisualStyleBackColor = True
        Me.btn_LifetimeDataADD.UseWaitCursor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.chkIVLLumiMeasLevel)
        Me.TabPage2.Controls.Add(Me.chkIVLSweepMode)
        Me.TabPage2.Controls.Add(Me.chkIVLBiasMode)
        Me.TabPage2.Controls.Add(Me.chkIVLMeasMode)
        Me.TabPage2.Controls.Add(Me.chkIVLFilename)
        Me.TabPage2.Controls.Add(Me.chkIVLFileversion)
        Me.TabPage2.Controls.Add(Me.GroupBox23)
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(587, 319)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'chkIVLLumiMeasLevel
        '
        Me.chkIVLLumiMeasLevel.AutoSize = True
        Me.chkIVLLumiMeasLevel.Checked = True
        Me.chkIVLLumiMeasLevel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIVLLumiMeasLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIVLLumiMeasLevel.Location = New System.Drawing.Point(401, 142)
        Me.chkIVLLumiMeasLevel.Name = "chkIVLLumiMeasLevel"
        Me.chkIVLLumiMeasLevel.Size = New System.Drawing.Size(150, 19)
        Me.chkIVLLumiMeasLevel.TabIndex = 22
        Me.chkIVLLumiMeasLevel.Text = "Luminance Meas Level"
        Me.chkIVLLumiMeasLevel.UseVisualStyleBackColor = True
        Me.chkIVLLumiMeasLevel.Visible = False
        '
        'chkIVLSweepMode
        '
        Me.chkIVLSweepMode.AutoSize = True
        Me.chkIVLSweepMode.Checked = True
        Me.chkIVLSweepMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIVLSweepMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIVLSweepMode.Location = New System.Drawing.Point(401, 115)
        Me.chkIVLSweepMode.Name = "chkIVLSweepMode"
        Me.chkIVLSweepMode.Size = New System.Drawing.Size(94, 19)
        Me.chkIVLSweepMode.TabIndex = 21
        Me.chkIVLSweepMode.Text = "Sweep Mode"
        Me.chkIVLSweepMode.UseVisualStyleBackColor = True
        Me.chkIVLSweepMode.Visible = False
        '
        'chkIVLBiasMode
        '
        Me.chkIVLBiasMode.AutoSize = True
        Me.chkIVLBiasMode.Checked = True
        Me.chkIVLBiasMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIVLBiasMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIVLBiasMode.Location = New System.Drawing.Point(401, 88)
        Me.chkIVLBiasMode.Name = "chkIVLBiasMode"
        Me.chkIVLBiasMode.Size = New System.Drawing.Size(81, 19)
        Me.chkIVLBiasMode.TabIndex = 20
        Me.chkIVLBiasMode.Text = "Bias Mode"
        Me.chkIVLBiasMode.UseVisualStyleBackColor = True
        Me.chkIVLBiasMode.Visible = False
        '
        'chkIVLMeasMode
        '
        Me.chkIVLMeasMode.AutoSize = True
        Me.chkIVLMeasMode.Checked = True
        Me.chkIVLMeasMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIVLMeasMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIVLMeasMode.Location = New System.Drawing.Point(401, 61)
        Me.chkIVLMeasMode.Name = "chkIVLMeasMode"
        Me.chkIVLMeasMode.Size = New System.Drawing.Size(89, 19)
        Me.chkIVLMeasMode.TabIndex = 19
        Me.chkIVLMeasMode.Text = "Meas. Mode"
        Me.chkIVLMeasMode.UseVisualStyleBackColor = True
        Me.chkIVLMeasMode.Visible = False
        '
        'chkIVLFilename
        '
        Me.chkIVLFilename.AutoSize = True
        Me.chkIVLFilename.Checked = True
        Me.chkIVLFilename.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIVLFilename.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIVLFilename.Location = New System.Drawing.Point(401, 34)
        Me.chkIVLFilename.Name = "chkIVLFilename"
        Me.chkIVLFilename.Size = New System.Drawing.Size(75, 19)
        Me.chkIVLFilename.TabIndex = 18
        Me.chkIVLFilename.Text = "Filename"
        Me.chkIVLFilename.UseVisualStyleBackColor = True
        Me.chkIVLFilename.Visible = False
        '
        'chkIVLFileversion
        '
        Me.chkIVLFileversion.AutoSize = True
        Me.chkIVLFileversion.Checked = True
        Me.chkIVLFileversion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIVLFileversion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIVLFileversion.Location = New System.Drawing.Point(401, 7)
        Me.chkIVLFileversion.Name = "chkIVLFileversion"
        Me.chkIVLFileversion.Size = New System.Drawing.Size(84, 19)
        Me.chkIVLFileversion.TabIndex = 17
        Me.chkIVLFileversion.Text = "FileVersion"
        Me.chkIVLFileversion.UseVisualStyleBackColor = True
        Me.chkIVLFileversion.Visible = False
        '
        'GroupBox23
        '
        Me.GroupBox23.Controls.Add(Me.ucDispIVLDataIndex)
        Me.GroupBox23.Controls.Add(Me.cboIVLDataFormat)
        Me.GroupBox23.Controls.Add(Me.btn_IVLDataDel)
        Me.GroupBox23.Controls.Add(Me.btn_IVLDataADD)
        Me.GroupBox23.Location = New System.Drawing.Point(5, 7)
        Me.GroupBox23.Name = "GroupBox23"
        Me.GroupBox23.Size = New System.Drawing.Size(381, 306)
        Me.GroupBox23.TabIndex = 6
        Me.GroupBox23.TabStop = False
        Me.GroupBox23.Text = "IVL Data"
        Me.GroupBox23.Visible = False
        '
        'ucDispIVLDataIndex
        '
        Me.ucDispIVLDataIndex.ColHeader = New String() {"No", "Data"}
        Me.ucDispIVLDataIndex.ColHeaderWidthRatio = "15,80"
        Me.ucDispIVLDataIndex.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucDispIVLDataIndex.FullRawSelection = True
        Me.ucDispIVLDataIndex.HideSelection = False
        Me.ucDispIVLDataIndex.LabelEdit = True
        Me.ucDispIVLDataIndex.LabelWrap = True
        Me.ucDispIVLDataIndex.Location = New System.Drawing.Point(9, 80)
        Me.ucDispIVLDataIndex.Name = "ucDispIVLDataIndex"
        Me.ucDispIVLDataIndex.Size = New System.Drawing.Size(358, 207)
        Me.ucDispIVLDataIndex.TabIndex = 16
        Me.ucDispIVLDataIndex.UseCheckBoxex = False
        '
        'cboIVLDataFormat
        '
        Me.cboIVLDataFormat.FormattingEnabled = True
        Me.cboIVLDataFormat.Location = New System.Drawing.Point(9, 35)
        Me.cboIVLDataFormat.Name = "cboIVLDataFormat"
        Me.cboIVLDataFormat.Size = New System.Drawing.Size(227, 23)
        Me.cboIVLDataFormat.TabIndex = 15
        '
        'btn_IVLDataDel
        '
        Me.btn_IVLDataDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_IVLDataDel.Location = New System.Drawing.Point(307, 33)
        Me.btn_IVLDataDel.Name = "btn_IVLDataDel"
        Me.btn_IVLDataDel.Size = New System.Drawing.Size(60, 25)
        Me.btn_IVLDataDel.TabIndex = 14
        Me.btn_IVLDataDel.Text = "DEL"
        Me.btn_IVLDataDel.UseVisualStyleBackColor = True
        '
        'btn_IVLDataADD
        '
        Me.btn_IVLDataADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_IVLDataADD.Location = New System.Drawing.Point(242, 33)
        Me.btn_IVLDataADD.Name = "btn_IVLDataADD"
        Me.btn_IVLDataADD.Size = New System.Drawing.Size(60, 25)
        Me.btn_IVLDataADD.TabIndex = 13
        Me.btn_IVLDataADD.Text = "ADD"
        Me.btn_IVLDataADD.UseVisualStyleBackColor = True
        '
        'GroupBox20
        '
        Me.GroupBox20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox20.Controls.Add(Me.Label26)
        Me.GroupBox20.Controls.Add(Me.Label25)
        Me.GroupBox20.Controls.Add(Me.Label24)
        Me.GroupBox20.Controls.Add(Me.tbLumiPerSpectrumSave)
        Me.GroupBox20.Location = New System.Drawing.Point(5, 137)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(637, 60)
        Me.GroupBox20.TabIndex = 5
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Spcetrum data save "
        Me.GroupBox20.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(236, 18)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(355, 30)
        Me.Label26.TabIndex = 4
        Me.Label26.Text = "Set the spectrum data to be saved when the luminance value is " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "changed by the in" & _
    "put value"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(163, 29)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(18, 15)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "%"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(12, 28)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(75, 15)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "Luminance :"
        '
        'tbLumiPerSpectrumSave
        '
        Me.tbLumiPerSpectrumSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbLumiPerSpectrumSave.Location = New System.Drawing.Point(90, 27)
        Me.tbLumiPerSpectrumSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbLumiPerSpectrumSave.Name = "tbLumiPerSpectrumSave"
        Me.tbLumiPerSpectrumSave.Size = New System.Drawing.Size(72, 21)
        Me.tbLumiPerSpectrumSave.TabIndex = 1
        '
        'GroupBox19
        '
        Me.GroupBox19.Controls.Add(Me.Label8)
        Me.GroupBox19.Controls.Add(Me.btnDefSavePath)
        Me.GroupBox19.Controls.Add(Me.tbDefSavePath)
        Me.GroupBox19.Location = New System.Drawing.Point(5, 67)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(637, 64)
        Me.GroupBox19.TabIndex = 4
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "Save Path Settings"
        Me.GroupBox19.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(51, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 15)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Path :"
        '
        'btnDefSavePath
        '
        Me.btnDefSavePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDefSavePath.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btnDefSavePath.Location = New System.Drawing.Point(549, 25)
        Me.btnDefSavePath.Name = "btnDefSavePath"
        Me.btnDefSavePath.Size = New System.Drawing.Size(68, 22)
        Me.btnDefSavePath.TabIndex = 1
        Me.btnDefSavePath.Text = "Find..."
        Me.btnDefSavePath.UseVisualStyleBackColor = True
        '
        'tbDefSavePath
        '
        Me.tbDefSavePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDefSavePath.Location = New System.Drawing.Point(92, 26)
        Me.tbDefSavePath.Name = "tbDefSavePath"
        Me.tbDefSavePath.Size = New System.Drawing.Size(451, 21)
        Me.tbDefSavePath.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox9.Controls.Add(Me.cbFileType)
        Me.GroupBox9.Controls.Add(Me.Label99)
        Me.GroupBox9.Controls.Add(Me.chkSaveOpt_AddDate)
        Me.GroupBox9.Controls.Add(Me.chkSaveOpt_AddExpMode)
        Me.GroupBox9.Controls.Add(Me.chkSaveOpt_AddUserInputFileName)
        Me.GroupBox9.Controls.Add(Me.chkSaveOpt_AddChNum)
        Me.GroupBox9.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(637, 58)
        Me.GroupBox9.TabIndex = 1
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "File name creation rule"
        '
        'cbFileType
        '
        Me.cbFileType.FormattingEnabled = True
        Me.cbFileType.Location = New System.Drawing.Point(76, 56)
        Me.cbFileType.Name = "cbFileType"
        Me.cbFileType.Size = New System.Drawing.Size(66, 23)
        Me.cbFileType.TabIndex = 17
        Me.cbFileType.Visible = False
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Location = New System.Drawing.Point(12, 60)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(58, 15)
        Me.Label99.TabIndex = 4
        Me.Label99.Text = "FileType :"
        Me.Label99.Visible = False
        '
        'chkSaveOpt_AddDate
        '
        Me.chkSaveOpt_AddDate.AutoSize = True
        Me.chkSaveOpt_AddDate.Checked = True
        Me.chkSaveOpt_AddDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSaveOpt_AddDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSaveOpt_AddDate.Location = New System.Drawing.Point(217, 25)
        Me.chkSaveOpt_AddDate.Name = "chkSaveOpt_AddDate"
        Me.chkSaveOpt_AddDate.Size = New System.Drawing.Size(71, 19)
        Me.chkSaveOpt_AddDate.TabIndex = 3
        Me.chkSaveOpt_AddDate.Text = "Add date"
        Me.chkSaveOpt_AddDate.UseVisualStyleBackColor = True
        Me.chkSaveOpt_AddDate.Visible = False
        '
        'chkSaveOpt_AddExpMode
        '
        Me.chkSaveOpt_AddExpMode.AutoSize = True
        Me.chkSaveOpt_AddExpMode.Checked = True
        Me.chkSaveOpt_AddExpMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSaveOpt_AddExpMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSaveOpt_AddExpMode.Location = New System.Drawing.Point(217, 60)
        Me.chkSaveOpt_AddExpMode.Name = "chkSaveOpt_AddExpMode"
        Me.chkSaveOpt_AddExpMode.Size = New System.Drawing.Size(229, 19)
        Me.chkSaveOpt_AddExpMode.TabIndex = 2
        Me.chkSaveOpt_AddExpMode.Text = "Add experimnet mode(IVL or Lifetime)"
        Me.chkSaveOpt_AddExpMode.UseVisualStyleBackColor = True
        Me.chkSaveOpt_AddExpMode.Visible = False
        '
        'chkSaveOpt_AddUserInputFileName
        '
        Me.chkSaveOpt_AddUserInputFileName.AutoSize = True
        Me.chkSaveOpt_AddUserInputFileName.Checked = True
        Me.chkSaveOpt_AddUserInputFileName.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSaveOpt_AddUserInputFileName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSaveOpt_AddUserInputFileName.Location = New System.Drawing.Point(394, 25)
        Me.chkSaveOpt_AddUserInputFileName.Name = "chkSaveOpt_AddUserInputFileName"
        Me.chkSaveOpt_AddUserInputFileName.Size = New System.Drawing.Size(156, 19)
        Me.chkSaveOpt_AddUserInputFileName.TabIndex = 1
        Me.chkSaveOpt_AddUserInputFileName.Text = "Add user input file name"
        Me.chkSaveOpt_AddUserInputFileName.UseVisualStyleBackColor = True
        Me.chkSaveOpt_AddUserInputFileName.Visible = False
        '
        'chkSaveOpt_AddChNum
        '
        Me.chkSaveOpt_AddChNum.AutoSize = True
        Me.chkSaveOpt_AddChNum.Checked = True
        Me.chkSaveOpt_AddChNum.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSaveOpt_AddChNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSaveOpt_AddChNum.Location = New System.Drawing.Point(14, 25)
        Me.chkSaveOpt_AddChNum.Name = "chkSaveOpt_AddChNum"
        Me.chkSaveOpt_AddChNum.Size = New System.Drawing.Size(184, 19)
        Me.chkSaveOpt_AddChNum.TabIndex = 0
        Me.chkSaveOpt_AddChNum.Text = "Add channel number(CH00X)"
        Me.chkSaveOpt_AddChNum.UseVisualStyleBackColor = True
        '
        'tpMotion
        '
        Me.tpMotion.Controls.Add(Me.GroupBox4)
        Me.tpMotion.Controls.Add(Me.GroupBox11)
        Me.tpMotion.Location = New System.Drawing.Point(4, 27)
        Me.tpMotion.Name = "tpMotion"
        Me.tpMotion.Size = New System.Drawing.Size(751, 642)
        Me.tpMotion.TabIndex = 1
        Me.tpMotion.Text = "Motion & Component"
        Me.tpMotion.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.chkEndHomming)
        Me.GroupBox4.Controls.Add(Me.Label107)
        Me.GroupBox4.Controls.Add(Me.btnCheckContact)
        Me.GroupBox4.Controls.Add(Me.btnWADFactor)
        Me.GroupBox4.Controls.Add(Me.GroupBox31)
        Me.GroupBox4.Controls.Add(Me.GroupBox28)
        Me.GroupBox4.Controls.Add(Me.GroupBox3)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 260)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(724, 314)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "CalPosition"
        '
        'chkEndHomming
        '
        Me.chkEndHomming.AutoSize = True
        Me.chkEndHomming.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkEndHomming.Location = New System.Drawing.Point(558, 10)
        Me.chkEndHomming.Name = "chkEndHomming"
        Me.chkEndHomming.Size = New System.Drawing.Size(49, 19)
        Me.chkEndHomming.TabIndex = 7
        Me.chkEndHomming.Text = "Use."
        Me.chkEndHomming.UseVisualStyleBackColor = True
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.Location = New System.Drawing.Point(427, 11)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(129, 15)
        Me.Label107.TabIndex = 11
        Me.Label107.Text = "IDLE Homming State :"
        '
        'btnCheckContact
        '
        Me.btnCheckContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckContact.Location = New System.Drawing.Point(509, 278)
        Me.btnCheckContact.Name = "btnCheckContact"
        Me.btnCheckContact.Size = New System.Drawing.Size(98, 26)
        Me.btnCheckContact.TabIndex = 70
        Me.btnCheckContact.Text = "Check Contact"
        Me.btnCheckContact.UseVisualStyleBackColor = True
        Me.btnCheckContact.Visible = False
        '
        'btnWADFactor
        '
        Me.btnWADFactor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWADFactor.Location = New System.Drawing.Point(509, 250)
        Me.btnWADFactor.Name = "btnWADFactor"
        Me.btnWADFactor.Size = New System.Drawing.Size(98, 26)
        Me.btnWADFactor.TabIndex = 69
        Me.btnWADFactor.Text = "WAD Settings"
        Me.btnWADFactor.UseVisualStyleBackColor = True
        Me.btnWADFactor.Visible = False
        '
        'GroupBox31
        '
        Me.GroupBox31.Controls.Add(Me.Label106)
        Me.GroupBox31.Controls.Add(Me.Label105)
        Me.GroupBox31.Controls.Add(Me.tbThetaOffset)
        Me.GroupBox31.Controls.Add(Me.Label102)
        Me.GroupBox31.Controls.Add(Me.tbThetaRatio)
        Me.GroupBox31.Controls.Add(Me.Label103)
        Me.GroupBox31.Controls.Add(Me.tbThetaDeviation)
        Me.GroupBox31.Controls.Add(Me.Label104)
        Me.GroupBox31.Controls.Add(Me.Button2)
        Me.GroupBox31.Controls.Add(Me.TextBox7)
        Me.GroupBox31.Controls.Add(Me.TextBox8)
        Me.GroupBox31.Controls.Add(Me.TextBox9)
        Me.GroupBox31.Location = New System.Drawing.Point(7, 242)
        Me.GroupBox31.Name = "GroupBox31"
        Me.GroupBox31.Size = New System.Drawing.Size(496, 63)
        Me.GroupBox31.TabIndex = 41
        Me.GroupBox31.TabStop = False
        Me.GroupBox31.Text = "Theta Calibration Factor"
        Me.GroupBox31.Visible = False
        '
        'Label106
        '
        Me.Label106.AutoSize = True
        Me.Label106.Location = New System.Drawing.Point(193, 32)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(30, 15)
        Me.Label106.TabIndex = 68
        Me.Label106.Text = "Deg"
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.Location = New System.Drawing.Point(362, 30)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(39, 15)
        Me.Label105.TabIndex = 37
        Me.Label105.Text = "Offset"
        '
        'tbThetaOffset
        '
        Me.tbThetaOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbThetaOffset.Location = New System.Drawing.Point(404, 27)
        Me.tbThetaOffset.Name = "tbThetaOffset"
        Me.tbThetaOffset.Size = New System.Drawing.Size(80, 21)
        Me.tbThetaOffset.TabIndex = 36
        Me.tbThetaOffset.Text = "0"
        Me.tbThetaOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label102
        '
        Me.Label102.AutoSize = True
        Me.Label102.Location = New System.Drawing.Point(230, 31)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(36, 15)
        Me.Label102.TabIndex = 35
        Me.Label102.Text = "Ratio"
        '
        'tbThetaRatio
        '
        Me.tbThetaRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbThetaRatio.Location = New System.Drawing.Point(269, 28)
        Me.tbThetaRatio.Name = "tbThetaRatio"
        Me.tbThetaRatio.Size = New System.Drawing.Size(80, 21)
        Me.tbThetaRatio.TabIndex = 34
        Me.tbThetaRatio.Text = "0"
        Me.tbThetaRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.Location = New System.Drawing.Point(12, 29)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(95, 15)
        Me.Label103.TabIndex = 28
        Me.Label103.Text = "Home Deviation"
        '
        'tbThetaDeviation
        '
        Me.tbThetaDeviation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbThetaDeviation.Location = New System.Drawing.Point(110, 27)
        Me.tbThetaDeviation.Name = "tbThetaDeviation"
        Me.tbThetaDeviation.Size = New System.Drawing.Size(80, 21)
        Me.tbThetaDeviation.TabIndex = 15
        Me.tbThetaDeviation.Text = "0"
        Me.tbThetaDeviation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label104
        '
        Me.Label104.AutoSize = True
        Me.Label104.Location = New System.Drawing.Point(45, 94)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(122, 15)
        Me.Label104.TabIndex = 33
        Me.Label104.Text = "CCDtoMCRPosition :"
        Me.Label104.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(512, 88)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(62, 28)
        Me.Button2.TabIndex = 32
        Me.Button2.Text = "Cal"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(386, 92)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(112, 21)
        Me.TextBox7.TabIndex = 31
        Me.TextBox7.Text = "0"
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox7.Visible = False
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(271, 92)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(112, 21)
        Me.TextBox8.TabIndex = 30
        Me.TextBox8.Text = "0"
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox8.Visible = False
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(156, 92)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(112, 21)
        Me.TextBox9.TabIndex = 29
        Me.TextBox9.Text = "0"
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox9.Visible = False
        '
        'GroupBox28
        '
        Me.GroupBox28.Controls.Add(Me.Label101)
        Me.GroupBox28.Controls.Add(Me.tbCCDtoHEXAPos_X)
        Me.GroupBox28.Controls.Add(Me.tbCCDtoHEXAPos_Y)
        Me.GroupBox28.Controls.Add(Me.tbCCDtoHEXAPos_Z)
        Me.GroupBox28.Controls.Add(Me.btnCalCCDtoHEXADistance)
        Me.GroupBox28.Controls.Add(Me.Label1)
        Me.GroupBox28.Controls.Add(Me.tbCCDtoSpectrometerPos_X)
        Me.GroupBox28.Controls.Add(Me.Label79)
        Me.GroupBox28.Controls.Add(Me.tbCCDtoSpectrometerPos_Y)
        Me.GroupBox28.Controls.Add(Me.btnCalCCDtoMCRDistance)
        Me.GroupBox28.Controls.Add(Me.tbCCDtoSpectrometerPos_Z)
        Me.GroupBox28.Controls.Add(Me.tbCCDtoMCRPos_Z)
        Me.GroupBox28.Controls.Add(Me.btnCalCCDtoSpectrometerDistance)
        Me.GroupBox28.Controls.Add(Me.tbCCDtoMCRPos_Y)
        Me.GroupBox28.Controls.Add(Me.tbCCDtoMCRPos_X)
        Me.GroupBox28.Location = New System.Drawing.Point(5, 154)
        Me.GroupBox28.Name = "GroupBox28"
        Me.GroupBox28.Size = New System.Drawing.Size(606, 82)
        Me.GroupBox28.TabIndex = 40
        Me.GroupBox28.TabStop = False
        Me.GroupBox28.Text = "Cal"
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.Location = New System.Drawing.Point(28, 51)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(111, 15)
        Me.Label101.TabIndex = 38
        Me.Label101.Text = "CCDtoCAPosition :"
        Me.Label101.Visible = False
        '
        'tbCCDtoHEXAPos_X
        '
        Me.tbCCDtoHEXAPos_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCCDtoHEXAPos_X.Location = New System.Drawing.Point(156, 48)
        Me.tbCCDtoHEXAPos_X.Name = "tbCCDtoHEXAPos_X"
        Me.tbCCDtoHEXAPos_X.Size = New System.Drawing.Size(112, 21)
        Me.tbCCDtoHEXAPos_X.TabIndex = 34
        Me.tbCCDtoHEXAPos_X.Text = "0"
        Me.tbCCDtoHEXAPos_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbCCDtoHEXAPos_X.Visible = False
        '
        'tbCCDtoHEXAPos_Y
        '
        Me.tbCCDtoHEXAPos_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCCDtoHEXAPos_Y.Location = New System.Drawing.Point(271, 48)
        Me.tbCCDtoHEXAPos_Y.Name = "tbCCDtoHEXAPos_Y"
        Me.tbCCDtoHEXAPos_Y.Size = New System.Drawing.Size(112, 21)
        Me.tbCCDtoHEXAPos_Y.TabIndex = 35
        Me.tbCCDtoHEXAPos_Y.Text = "0"
        Me.tbCCDtoHEXAPos_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbCCDtoHEXAPos_Y.Visible = False
        '
        'tbCCDtoHEXAPos_Z
        '
        Me.tbCCDtoHEXAPos_Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCCDtoHEXAPos_Z.Location = New System.Drawing.Point(386, 48)
        Me.tbCCDtoHEXAPos_Z.Name = "tbCCDtoHEXAPos_Z"
        Me.tbCCDtoHEXAPos_Z.Size = New System.Drawing.Size(112, 21)
        Me.tbCCDtoHEXAPos_Z.TabIndex = 36
        Me.tbCCDtoHEXAPos_Z.Text = "0"
        Me.tbCCDtoHEXAPos_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbCCDtoHEXAPos_Z.Visible = False
        '
        'btnCalCCDtoHEXADistance
        '
        Me.btnCalCCDtoHEXADistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalCCDtoHEXADistance.Location = New System.Drawing.Point(512, 45)
        Me.btnCalCCDtoHEXADistance.Name = "btnCalCCDtoHEXADistance"
        Me.btnCalCCDtoHEXADistance.Size = New System.Drawing.Size(62, 26)
        Me.btnCalCCDtoHEXADistance.TabIndex = 37
        Me.btnCalCCDtoHEXADistance.Text = "Cal"
        Me.btnCalCCDtoHEXADistance.UseVisualStyleBackColor = True
        Me.btnCalCCDtoHEXADistance.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 15)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "CCDtoSpecPosition :"
        '
        'tbCCDtoSpectrometerPos_X
        '
        Me.tbCCDtoSpectrometerPos_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCCDtoSpectrometerPos_X.Location = New System.Drawing.Point(156, 18)
        Me.tbCCDtoSpectrometerPos_X.Name = "tbCCDtoSpectrometerPos_X"
        Me.tbCCDtoSpectrometerPos_X.Size = New System.Drawing.Size(112, 21)
        Me.tbCCDtoSpectrometerPos_X.TabIndex = 15
        Me.tbCCDtoSpectrometerPos_X.Text = "0"
        Me.tbCCDtoSpectrometerPos_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbCCDtoSpectrometerPos_X.Visible = False
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(45, 94)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(122, 15)
        Me.Label79.TabIndex = 33
        Me.Label79.Text = "CCDtoMCRPosition :"
        Me.Label79.Visible = False
        '
        'tbCCDtoSpectrometerPos_Y
        '
        Me.tbCCDtoSpectrometerPos_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCCDtoSpectrometerPos_Y.Location = New System.Drawing.Point(271, 18)
        Me.tbCCDtoSpectrometerPos_Y.Name = "tbCCDtoSpectrometerPos_Y"
        Me.tbCCDtoSpectrometerPos_Y.Size = New System.Drawing.Size(112, 21)
        Me.tbCCDtoSpectrometerPos_Y.TabIndex = 18
        Me.tbCCDtoSpectrometerPos_Y.Text = "0"
        Me.tbCCDtoSpectrometerPos_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCalCCDtoMCRDistance
        '
        Me.btnCalCCDtoMCRDistance.Location = New System.Drawing.Point(512, 88)
        Me.btnCalCCDtoMCRDistance.Name = "btnCalCCDtoMCRDistance"
        Me.btnCalCCDtoMCRDistance.Size = New System.Drawing.Size(62, 28)
        Me.btnCalCCDtoMCRDistance.TabIndex = 32
        Me.btnCalCCDtoMCRDistance.Text = "Cal"
        Me.btnCalCCDtoMCRDistance.UseVisualStyleBackColor = True
        Me.btnCalCCDtoMCRDistance.Visible = False
        '
        'tbCCDtoSpectrometerPos_Z
        '
        Me.tbCCDtoSpectrometerPos_Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCCDtoSpectrometerPos_Z.Location = New System.Drawing.Point(386, 18)
        Me.tbCCDtoSpectrometerPos_Z.Name = "tbCCDtoSpectrometerPos_Z"
        Me.tbCCDtoSpectrometerPos_Z.Size = New System.Drawing.Size(112, 21)
        Me.tbCCDtoSpectrometerPos_Z.TabIndex = 21
        Me.tbCCDtoSpectrometerPos_Z.Text = "0"
        Me.tbCCDtoSpectrometerPos_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbCCDtoMCRPos_Z
        '
        Me.tbCCDtoMCRPos_Z.Location = New System.Drawing.Point(386, 92)
        Me.tbCCDtoMCRPos_Z.Name = "tbCCDtoMCRPos_Z"
        Me.tbCCDtoMCRPos_Z.Size = New System.Drawing.Size(112, 21)
        Me.tbCCDtoMCRPos_Z.TabIndex = 31
        Me.tbCCDtoMCRPos_Z.Text = "0"
        Me.tbCCDtoMCRPos_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbCCDtoMCRPos_Z.Visible = False
        '
        'btnCalCCDtoSpectrometerDistance
        '
        Me.btnCalCCDtoSpectrometerDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalCCDtoSpectrometerDistance.Location = New System.Drawing.Point(512, 16)
        Me.btnCalCCDtoSpectrometerDistance.Name = "btnCalCCDtoSpectrometerDistance"
        Me.btnCalCCDtoSpectrometerDistance.Size = New System.Drawing.Size(62, 26)
        Me.btnCalCCDtoSpectrometerDistance.TabIndex = 24
        Me.btnCalCCDtoSpectrometerDistance.Text = "Cal"
        Me.btnCalCCDtoSpectrometerDistance.UseVisualStyleBackColor = True
        '
        'tbCCDtoMCRPos_Y
        '
        Me.tbCCDtoMCRPos_Y.Location = New System.Drawing.Point(271, 92)
        Me.tbCCDtoMCRPos_Y.Name = "tbCCDtoMCRPos_Y"
        Me.tbCCDtoMCRPos_Y.Size = New System.Drawing.Size(112, 21)
        Me.tbCCDtoMCRPos_Y.TabIndex = 30
        Me.tbCCDtoMCRPos_Y.Text = "0"
        Me.tbCCDtoMCRPos_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbCCDtoMCRPos_Y.Visible = False
        '
        'tbCCDtoMCRPos_X
        '
        Me.tbCCDtoMCRPos_X.Location = New System.Drawing.Point(156, 92)
        Me.tbCCDtoMCRPos_X.Name = "tbCCDtoMCRPos_X"
        Me.tbCCDtoMCRPos_X.Size = New System.Drawing.Size(112, 21)
        Me.tbCCDtoMCRPos_X.TabIndex = 29
        Me.tbCCDtoMCRPos_X.Text = "0"
        Me.tbCCDtoMCRPos_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbCCDtoMCRPos_X.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tbHEXAPos_Y)
        Me.GroupBox3.Controls.Add(Me.tbHEXAPos_X)
        Me.GroupBox3.Controls.Add(Me.Label100)
        Me.GroupBox3.Controls.Add(Me.tbHEXAPos_Z)
        Me.GroupBox3.Controls.Add(Me.btnGetHEXAPos)
        Me.GroupBox3.Controls.Add(Me.tbSpectrometerPos_Y)
        Me.GroupBox3.Controls.Add(Me.btnGetMCRPos)
        Me.GroupBox3.Controls.Add(Me.tbCCDPos_X)
        Me.GroupBox3.Controls.Add(Me.tbMCRPos_Z)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.tbMCRPos_Y)
        Me.GroupBox3.Controls.Add(Me.tbSpectrometerPos_X)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label80)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.tbMCRPos_X)
        Me.GroupBox3.Controls.Add(Me.tbCCDPos_Y)
        Me.GroupBox3.Controls.Add(Me.tbCCDPos_Z)
        Me.GroupBox3.Controls.Add(Me.tbSpectrometerPos_Z)
        Me.GroupBox3.Controls.Add(Me.btnGetCurrentCCDPos)
        Me.GroupBox3.Controls.Add(Me.btnGetSpectrometePos)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 28)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(606, 124)
        Me.GroupBox3.TabIndex = 39
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Get Position"
        '
        'tbHEXAPos_Y
        '
        Me.tbHEXAPos_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbHEXAPos_Y.Location = New System.Drawing.Point(271, 92)
        Me.tbHEXAPos_Y.Name = "tbHEXAPos_Y"
        Me.tbHEXAPos_Y.Size = New System.Drawing.Size(112, 21)
        Me.tbHEXAPos_Y.TabIndex = 41
        Me.tbHEXAPos_Y.Text = "0"
        Me.tbHEXAPos_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbHEXAPos_Y.Visible = False
        '
        'tbHEXAPos_X
        '
        Me.tbHEXAPos_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbHEXAPos_X.Location = New System.Drawing.Point(156, 92)
        Me.tbHEXAPos_X.Name = "tbHEXAPos_X"
        Me.tbHEXAPos_X.Size = New System.Drawing.Size(112, 21)
        Me.tbHEXAPos_X.TabIndex = 40
        Me.tbHEXAPos_X.Text = "0"
        Me.tbHEXAPos_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbHEXAPos_X.Visible = False
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Location = New System.Drawing.Point(54, 96)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(91, 15)
        Me.Label100.TabIndex = 39
        Me.Label100.Text = "HEXA Position :"
        Me.Label100.Visible = False
        '
        'tbHEXAPos_Z
        '
        Me.tbHEXAPos_Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbHEXAPos_Z.Location = New System.Drawing.Point(386, 92)
        Me.tbHEXAPos_Z.Name = "tbHEXAPos_Z"
        Me.tbHEXAPos_Z.Size = New System.Drawing.Size(112, 21)
        Me.tbHEXAPos_Z.TabIndex = 42
        Me.tbHEXAPos_Z.Text = "0"
        Me.tbHEXAPos_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbHEXAPos_Z.Visible = False
        '
        'btnGetHEXAPos
        '
        Me.btnGetHEXAPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetHEXAPos.Location = New System.Drawing.Point(512, 91)
        Me.btnGetHEXAPos.Name = "btnGetHEXAPos"
        Me.btnGetHEXAPos.Size = New System.Drawing.Size(62, 25)
        Me.btnGetHEXAPos.TabIndex = 43
        Me.btnGetHEXAPos.Text = "Get"
        Me.btnGetHEXAPos.UseVisualStyleBackColor = True
        Me.btnGetHEXAPos.Visible = False
        '
        'tbSpectrometerPos_Y
        '
        Me.tbSpectrometerPos_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSpectrometerPos_Y.Location = New System.Drawing.Point(271, 63)
        Me.tbSpectrometerPos_Y.Name = "tbSpectrometerPos_Y"
        Me.tbSpectrometerPos_Y.Size = New System.Drawing.Size(112, 21)
        Me.tbSpectrometerPos_Y.TabIndex = 17
        Me.tbSpectrometerPos_Y.Text = "0"
        Me.tbSpectrometerPos_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnGetMCRPos
        '
        Me.btnGetMCRPos.Location = New System.Drawing.Point(512, 128)
        Me.btnGetMCRPos.Name = "btnGetMCRPos"
        Me.btnGetMCRPos.Size = New System.Drawing.Size(62, 28)
        Me.btnGetMCRPos.TabIndex = 38
        Me.btnGetMCRPos.Text = "Get"
        Me.btnGetMCRPos.UseVisualStyleBackColor = True
        Me.btnGetMCRPos.Visible = False
        '
        'tbCCDPos_X
        '
        Me.tbCCDPos_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCCDPos_X.Location = New System.Drawing.Point(156, 35)
        Me.tbCCDPos_X.Name = "tbCCDPos_X"
        Me.tbCCDPos_X.Size = New System.Drawing.Size(112, 21)
        Me.tbCCDPos_X.TabIndex = 11
        Me.tbCCDPos_X.Text = "0"
        Me.tbCCDPos_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbCCDPos_X.Visible = False
        '
        'tbMCRPos_Z
        '
        Me.tbMCRPos_Z.Location = New System.Drawing.Point(386, 132)
        Me.tbMCRPos_Z.Name = "tbMCRPos_Z"
        Me.tbMCRPos_Z.Size = New System.Drawing.Size(112, 21)
        Me.tbMCRPos_Z.TabIndex = 37
        Me.tbMCRPos_Z.Text = "0"
        Me.tbMCRPos_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbMCRPos_Z.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(57, 38)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 15)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "CCD Position :"
        '
        'tbMCRPos_Y
        '
        Me.tbMCRPos_Y.Location = New System.Drawing.Point(271, 132)
        Me.tbMCRPos_Y.Name = "tbMCRPos_Y"
        Me.tbMCRPos_Y.Size = New System.Drawing.Size(112, 21)
        Me.tbMCRPos_Y.TabIndex = 36
        Me.tbMCRPos_Y.Text = "0"
        Me.tbMCRPos_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbMCRPos_Y.Visible = False
        '
        'tbSpectrometerPos_X
        '
        Me.tbSpectrometerPos_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSpectrometerPos_X.Location = New System.Drawing.Point(156, 63)
        Me.tbSpectrometerPos_X.Name = "tbSpectrometerPos_X"
        Me.tbSpectrometerPos_X.Size = New System.Drawing.Size(112, 21)
        Me.tbSpectrometerPos_X.TabIndex = 13
        Me.tbSpectrometerPos_X.Text = "0"
        Me.tbSpectrometerPos_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbSpectrometerPos_X.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(422, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 15)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "Z Axis"
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Location = New System.Drawing.Point(75, 134)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(88, 15)
        Me.Label80.TabIndex = 34
        Me.Label80.Text = "MCR Position :"
        Me.Label80.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(308, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 15)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "Y Axis"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(135, 15)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Spectrometer Position :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(190, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 15)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "X Axis"
        Me.Label16.Visible = False
        '
        'tbMCRPos_X
        '
        Me.tbMCRPos_X.Location = New System.Drawing.Point(156, 132)
        Me.tbMCRPos_X.Name = "tbMCRPos_X"
        Me.tbMCRPos_X.Size = New System.Drawing.Size(112, 21)
        Me.tbMCRPos_X.TabIndex = 35
        Me.tbMCRPos_X.Text = "0"
        Me.tbMCRPos_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbMCRPos_X.Visible = False
        '
        'tbCCDPos_Y
        '
        Me.tbCCDPos_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCCDPos_Y.Location = New System.Drawing.Point(271, 35)
        Me.tbCCDPos_Y.Name = "tbCCDPos_Y"
        Me.tbCCDPos_Y.Size = New System.Drawing.Size(112, 21)
        Me.tbCCDPos_Y.TabIndex = 16
        Me.tbCCDPos_Y.Text = "0"
        Me.tbCCDPos_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbCCDPos_Z
        '
        Me.tbCCDPos_Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCCDPos_Z.Location = New System.Drawing.Point(386, 35)
        Me.tbCCDPos_Z.Name = "tbCCDPos_Z"
        Me.tbCCDPos_Z.Size = New System.Drawing.Size(112, 21)
        Me.tbCCDPos_Z.TabIndex = 19
        Me.tbCCDPos_Z.Text = "0"
        Me.tbCCDPos_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbSpectrometerPos_Z
        '
        Me.tbSpectrometerPos_Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSpectrometerPos_Z.Location = New System.Drawing.Point(386, 63)
        Me.tbSpectrometerPos_Z.Name = "tbSpectrometerPos_Z"
        Me.tbSpectrometerPos_Z.Size = New System.Drawing.Size(112, 21)
        Me.tbSpectrometerPos_Z.TabIndex = 20
        Me.tbSpectrometerPos_Z.Text = "0"
        Me.tbSpectrometerPos_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnGetCurrentCCDPos
        '
        Me.btnGetCurrentCCDPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetCurrentCCDPos.Location = New System.Drawing.Point(512, 34)
        Me.btnGetCurrentCCDPos.Name = "btnGetCurrentCCDPos"
        Me.btnGetCurrentCCDPos.Size = New System.Drawing.Size(63, 25)
        Me.btnGetCurrentCCDPos.TabIndex = 22
        Me.btnGetCurrentCCDPos.Text = "Get"
        Me.btnGetCurrentCCDPos.UseVisualStyleBackColor = True
        '
        'btnGetSpectrometePos
        '
        Me.btnGetSpectrometePos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetSpectrometePos.Location = New System.Drawing.Point(512, 63)
        Me.btnGetSpectrometePos.Name = "btnGetSpectrometePos"
        Me.btnGetSpectrometePos.Size = New System.Drawing.Size(62, 25)
        Me.btnGetSpectrometePos.TabIndex = 23
        Me.btnGetSpectrometePos.Text = "Get"
        Me.btnGetSpectrometePos.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.GroupBox14)
        Me.GroupBox11.Controls.Add(Me.GroupBox12)
        Me.GroupBox11.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(725, 251)
        Me.GroupBox11.TabIndex = 2
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Position To Distance Calibration"
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.Label115)
        Me.GroupBox14.Controls.Add(Me.tbDistance_Theta_Y)
        Me.GroupBox14.Controls.Add(Me.lblDistance_Theta)
        Me.GroupBox14.Controls.Add(Me.tbDistance_Theta)
        Me.GroupBox14.Controls.Add(Me.lblDistance_Z)
        Me.GroupBox14.Controls.Add(Me.tbDistance_Z)
        Me.GroupBox14.Controls.Add(Me.lblDistance_Y)
        Me.GroupBox14.Controls.Add(Me.lblDistance_X)
        Me.GroupBox14.Controls.Add(Me.btnSetDistance)
        Me.GroupBox14.Controls.Add(Me.tbDistance_Y)
        Me.GroupBox14.Controls.Add(Me.Label46)
        Me.GroupBox14.Controls.Add(Me.tbDistance_X)
        Me.GroupBox14.Location = New System.Drawing.Point(8, 20)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(711, 64)
        Me.GroupBox14.TabIndex = 2
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Real Distance"
        '
        'Label115
        '
        Me.Label115.AutoSize = True
        Me.Label115.Location = New System.Drawing.Point(403, 15)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(102, 15)
        Me.Label115.TabIndex = 49
        Me.Label115.Text = "Theta Y Axis(mm)"
        Me.Label115.Visible = False
        '
        'tbDistance_Theta_Y
        '
        Me.tbDistance_Theta_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDistance_Theta_Y.Location = New System.Drawing.Point(412, 33)
        Me.tbDistance_Theta_Y.Name = "tbDistance_Theta_Y"
        Me.tbDistance_Theta_Y.Size = New System.Drawing.Size(86, 21)
        Me.tbDistance_Theta_Y.TabIndex = 48
        Me.tbDistance_Theta_Y.Text = "0"
        Me.tbDistance_Theta_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbDistance_Theta_Y.Visible = False
        '
        'lblDistance_Theta
        '
        Me.lblDistance_Theta.AutoSize = True
        Me.lblDistance_Theta.Location = New System.Drawing.Point(503, 15)
        Me.lblDistance_Theta.Name = "lblDistance_Theta"
        Me.lblDistance_Theta.Size = New System.Drawing.Size(93, 15)
        Me.lblDistance_Theta.TabIndex = 47
        Me.lblDistance_Theta.Text = "Theta Axis(Deg)"
        Me.lblDistance_Theta.Visible = False
        '
        'tbDistance_Theta
        '
        Me.tbDistance_Theta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDistance_Theta.Location = New System.Drawing.Point(502, 33)
        Me.tbDistance_Theta.Name = "tbDistance_Theta"
        Me.tbDistance_Theta.Size = New System.Drawing.Size(86, 21)
        Me.tbDistance_Theta.TabIndex = 46
        Me.tbDistance_Theta.Text = "0"
        Me.tbDistance_Theta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbDistance_Theta.Visible = False
        '
        'lblDistance_Z
        '
        Me.lblDistance_Z.AutoSize = True
        Me.lblDistance_Z.Location = New System.Drawing.Point(337, 15)
        Me.lblDistance_Z.Name = "lblDistance_Z"
        Me.lblDistance_Z.Size = New System.Drawing.Size(68, 15)
        Me.lblDistance_Z.TabIndex = 45
        Me.lblDistance_Z.Text = "Z Axis(mm)"
        '
        'tbDistance_Z
        '
        Me.tbDistance_Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDistance_Z.Location = New System.Drawing.Point(323, 33)
        Me.tbDistance_Z.Name = "tbDistance_Z"
        Me.tbDistance_Z.Size = New System.Drawing.Size(86, 21)
        Me.tbDistance_Z.TabIndex = 44
        Me.tbDistance_Z.Text = "0"
        Me.tbDistance_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDistance_Y
        '
        Me.lblDistance_Y.AutoSize = True
        Me.lblDistance_Y.Location = New System.Drawing.Point(247, 15)
        Me.lblDistance_Y.Name = "lblDistance_Y"
        Me.lblDistance_Y.Size = New System.Drawing.Size(68, 15)
        Me.lblDistance_Y.TabIndex = 43
        Me.lblDistance_Y.Text = "Y Axis(mm)"
        '
        'lblDistance_X
        '
        Me.lblDistance_X.AutoSize = True
        Me.lblDistance_X.Location = New System.Drawing.Point(157, 15)
        Me.lblDistance_X.Name = "lblDistance_X"
        Me.lblDistance_X.Size = New System.Drawing.Size(68, 15)
        Me.lblDistance_X.TabIndex = 42
        Me.lblDistance_X.Text = "X Axis(mm)"
        '
        'btnSetDistance
        '
        Me.btnSetDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetDistance.Location = New System.Drawing.Point(604, 29)
        Me.btnSetDistance.Name = "btnSetDistance"
        Me.btnSetDistance.Size = New System.Drawing.Size(63, 28)
        Me.btnSetDistance.TabIndex = 39
        Me.btnSetDistance.Text = "Set"
        Me.btnSetDistance.UseVisualStyleBackColor = True
        '
        'tbDistance_Y
        '
        Me.tbDistance_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDistance_Y.Location = New System.Drawing.Point(233, 33)
        Me.tbDistance_Y.Name = "tbDistance_Y"
        Me.tbDistance_Y.Size = New System.Drawing.Size(86, 21)
        Me.tbDistance_Y.TabIndex = 33
        Me.tbDistance_Y.Text = "0"
        Me.tbDistance_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(22, 35)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(115, 15)
        Me.Label46.TabIndex = 28
        Me.Label46.Text = "Standard Distance :"
        '
        'tbDistance_X
        '
        Me.tbDistance_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDistance_X.Location = New System.Drawing.Point(143, 33)
        Me.tbDistance_X.Name = "tbDistance_X"
        Me.tbDistance_X.Size = New System.Drawing.Size(86, 21)
        Me.tbDistance_X.TabIndex = 29
        Me.tbDistance_X.Text = "0"
        Me.tbDistance_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.tbPosPerDistance_Theta)
        Me.GroupBox12.Controls.Add(Me.lblMotionPos_Theta)
        Me.GroupBox12.Controls.Add(Me.btnCalPosPerDistance)
        Me.GroupBox12.Controls.Add(Me.tbCalPos_Theta)
        Me.GroupBox12.Controls.Add(Me.tbEndPos_Theta)
        Me.GroupBox12.Controls.Add(Me.tbStartPos_Theta)
        Me.GroupBox12.Controls.Add(Me.tbPosPerDistance_Z)
        Me.GroupBox12.Controls.Add(Me.lblMotionPos_Z)
        Me.GroupBox12.Controls.Add(Me.tbCalPos_Z)
        Me.GroupBox12.Controls.Add(Me.tbEndPos_Z)
        Me.GroupBox12.Controls.Add(Me.tbStartPos_Z)
        Me.GroupBox12.Controls.Add(Me.chkCalPosPerDistance)
        Me.GroupBox12.Controls.Add(Me.tbPosPerDistance_Y)
        Me.GroupBox12.Controls.Add(Me.Label41)
        Me.GroupBox12.Controls.Add(Me.tbPosPerDistance_X)
        Me.GroupBox12.Controls.Add(Me.Label40)
        Me.GroupBox12.Controls.Add(Me.lblMotionPos_Y)
        Me.GroupBox12.Controls.Add(Me.lblMotionPos_X)
        Me.GroupBox12.Controls.Add(Me.btnGetEndPos)
        Me.GroupBox12.Controls.Add(Me.btnGetStartPos)
        Me.GroupBox12.Controls.Add(Me.tbCalPos_Y)
        Me.GroupBox12.Controls.Add(Me.tbEndPos_Y)
        Me.GroupBox12.Controls.Add(Me.tbStartPos_Y)
        Me.GroupBox12.Controls.Add(Me.tbCalPos_X)
        Me.GroupBox12.Controls.Add(Me.Label38)
        Me.GroupBox12.Controls.Add(Me.tbEndPos_X)
        Me.GroupBox12.Controls.Add(Me.Label39)
        Me.GroupBox12.Controls.Add(Me.tbStartPos_X)
        Me.GroupBox12.Location = New System.Drawing.Point(8, 89)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(711, 153)
        Me.GroupBox12.TabIndex = 0
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Motion Position"
        '
        'tbPosPerDistance_Theta
        '
        Me.tbPosPerDistance_Theta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPosPerDistance_Theta.Location = New System.Drawing.Point(414, 117)
        Me.tbPosPerDistance_Theta.Name = "tbPosPerDistance_Theta"
        Me.tbPosPerDistance_Theta.Size = New System.Drawing.Size(86, 21)
        Me.tbPosPerDistance_Theta.TabIndex = 67
        Me.tbPosPerDistance_Theta.Text = "0"
        Me.tbPosPerDistance_Theta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbPosPerDistance_Theta.Visible = False
        '
        'lblMotionPos_Theta
        '
        Me.lblMotionPos_Theta.AutoSize = True
        Me.lblMotionPos_Theta.Location = New System.Drawing.Point(427, 15)
        Me.lblMotionPos_Theta.Name = "lblMotionPos_Theta"
        Me.lblMotionPos_Theta.Size = New System.Drawing.Size(62, 15)
        Me.lblMotionPos_Theta.TabIndex = 66
        Me.lblMotionPos_Theta.Text = "Theta Axis"
        Me.lblMotionPos_Theta.Visible = False
        '
        'btnCalPosPerDistance
        '
        Me.btnCalPosPerDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalPosPerDistance.Location = New System.Drawing.Point(604, 89)
        Me.btnCalPosPerDistance.Name = "btnCalPosPerDistance"
        Me.btnCalPosPerDistance.Size = New System.Drawing.Size(63, 25)
        Me.btnCalPosPerDistance.TabIndex = 41
        Me.btnCalPosPerDistance.Text = "Cal."
        Me.btnCalPosPerDistance.UseVisualStyleBackColor = True
        '
        'tbCalPos_Theta
        '
        Me.tbCalPos_Theta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCalPos_Theta.Location = New System.Drawing.Point(414, 89)
        Me.tbCalPos_Theta.Name = "tbCalPos_Theta"
        Me.tbCalPos_Theta.Size = New System.Drawing.Size(86, 21)
        Me.tbCalPos_Theta.TabIndex = 65
        Me.tbCalPos_Theta.Text = "0"
        Me.tbCalPos_Theta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbCalPos_Theta.Visible = False
        '
        'tbEndPos_Theta
        '
        Me.tbEndPos_Theta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbEndPos_Theta.Location = New System.Drawing.Point(414, 60)
        Me.tbEndPos_Theta.Name = "tbEndPos_Theta"
        Me.tbEndPos_Theta.Size = New System.Drawing.Size(86, 21)
        Me.tbEndPos_Theta.TabIndex = 64
        Me.tbEndPos_Theta.Text = "0"
        Me.tbEndPos_Theta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbEndPos_Theta.Visible = False
        '
        'tbStartPos_Theta
        '
        Me.tbStartPos_Theta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbStartPos_Theta.Location = New System.Drawing.Point(414, 32)
        Me.tbStartPos_Theta.Name = "tbStartPos_Theta"
        Me.tbStartPos_Theta.Size = New System.Drawing.Size(86, 21)
        Me.tbStartPos_Theta.TabIndex = 63
        Me.tbStartPos_Theta.Text = "0"
        Me.tbStartPos_Theta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbStartPos_Theta.Visible = False
        '
        'tbPosPerDistance_Z
        '
        Me.tbPosPerDistance_Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPosPerDistance_Z.Location = New System.Drawing.Point(322, 118)
        Me.tbPosPerDistance_Z.Name = "tbPosPerDistance_Z"
        Me.tbPosPerDistance_Z.Size = New System.Drawing.Size(86, 21)
        Me.tbPosPerDistance_Z.TabIndex = 62
        Me.tbPosPerDistance_Z.Text = "0"
        Me.tbPosPerDistance_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMotionPos_Z
        '
        Me.lblMotionPos_Z.AutoSize = True
        Me.lblMotionPos_Z.Location = New System.Drawing.Point(350, 16)
        Me.lblMotionPos_Z.Name = "lblMotionPos_Z"
        Me.lblMotionPos_Z.Size = New System.Drawing.Size(38, 15)
        Me.lblMotionPos_Z.TabIndex = 61
        Me.lblMotionPos_Z.Text = "Z Axis"
        '
        'tbCalPos_Z
        '
        Me.tbCalPos_Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCalPos_Z.Location = New System.Drawing.Point(322, 90)
        Me.tbCalPos_Z.Name = "tbCalPos_Z"
        Me.tbCalPos_Z.Size = New System.Drawing.Size(86, 21)
        Me.tbCalPos_Z.TabIndex = 60
        Me.tbCalPos_Z.Text = "0"
        Me.tbCalPos_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbEndPos_Z
        '
        Me.tbEndPos_Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbEndPos_Z.Location = New System.Drawing.Point(322, 61)
        Me.tbEndPos_Z.Name = "tbEndPos_Z"
        Me.tbEndPos_Z.Size = New System.Drawing.Size(86, 21)
        Me.tbEndPos_Z.TabIndex = 59
        Me.tbEndPos_Z.Text = "0"
        Me.tbEndPos_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbStartPos_Z
        '
        Me.tbStartPos_Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbStartPos_Z.Location = New System.Drawing.Point(322, 33)
        Me.tbStartPos_Z.Name = "tbStartPos_Z"
        Me.tbStartPos_Z.Size = New System.Drawing.Size(86, 21)
        Me.tbStartPos_Z.TabIndex = 58
        Me.tbStartPos_Z.Text = "0"
        Me.tbStartPos_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkCalPosPerDistance
        '
        Me.chkCalPosPerDistance.AutoSize = True
        Me.chkCalPosPerDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkCalPosPerDistance.Location = New System.Drawing.Point(613, 119)
        Me.chkCalPosPerDistance.Name = "chkCalPosPerDistance"
        Me.chkCalPosPerDistance.Size = New System.Drawing.Size(49, 19)
        Me.chkCalPosPerDistance.TabIndex = 3
        Me.chkCalPosPerDistance.Text = "Use."
        Me.chkCalPosPerDistance.UseVisualStyleBackColor = True
        '
        'tbPosPerDistance_Y
        '
        Me.tbPosPerDistance_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPosPerDistance_Y.Location = New System.Drawing.Point(232, 118)
        Me.tbPosPerDistance_Y.Name = "tbPosPerDistance_Y"
        Me.tbPosPerDistance_Y.Size = New System.Drawing.Size(86, 21)
        Me.tbPosPerDistance_Y.TabIndex = 57
        Me.tbPosPerDistance_Y.Text = "0"
        Me.tbPosPerDistance_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(5, 120)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(134, 15)
        Me.Label41.TabIndex = 55
        Me.Label41.Text = "Cal Pos. Per Distance :"
        '
        'tbPosPerDistance_X
        '
        Me.tbPosPerDistance_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPosPerDistance_X.Location = New System.Drawing.Point(142, 118)
        Me.tbPosPerDistance_X.Name = "tbPosPerDistance_X"
        Me.tbPosPerDistance_X.Size = New System.Drawing.Size(86, 21)
        Me.tbPosPerDistance_X.TabIndex = 56
        Me.tbPosPerDistance_X.Text = "0"
        Me.tbPosPerDistance_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbPosPerDistance_X.Visible = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(49, 92)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(83, 15)
        Me.Label40.TabIndex = 45
        Me.Label40.Text = "Cal. Position :"
        '
        'lblMotionPos_Y
        '
        Me.lblMotionPos_Y.AutoSize = True
        Me.lblMotionPos_Y.Location = New System.Drawing.Point(259, 16)
        Me.lblMotionPos_Y.Name = "lblMotionPos_Y"
        Me.lblMotionPos_Y.Size = New System.Drawing.Size(38, 15)
        Me.lblMotionPos_Y.TabIndex = 43
        Me.lblMotionPos_Y.Text = "Y Axis"
        '
        'lblMotionPos_X
        '
        Me.lblMotionPos_X.AutoSize = True
        Me.lblMotionPos_X.Location = New System.Drawing.Point(173, 16)
        Me.lblMotionPos_X.Name = "lblMotionPos_X"
        Me.lblMotionPos_X.Size = New System.Drawing.Size(38, 15)
        Me.lblMotionPos_X.TabIndex = 42
        Me.lblMotionPos_X.Text = "X Axis"
        Me.lblMotionPos_X.Visible = False
        '
        'btnGetEndPos
        '
        Me.btnGetEndPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetEndPos.Location = New System.Drawing.Point(604, 60)
        Me.btnGetEndPos.Name = "btnGetEndPos"
        Me.btnGetEndPos.Size = New System.Drawing.Size(63, 25)
        Me.btnGetEndPos.TabIndex = 40
        Me.btnGetEndPos.Text = "Get"
        Me.btnGetEndPos.UseVisualStyleBackColor = True
        '
        'btnGetStartPos
        '
        Me.btnGetStartPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetStartPos.Location = New System.Drawing.Point(604, 32)
        Me.btnGetStartPos.Name = "btnGetStartPos"
        Me.btnGetStartPos.Size = New System.Drawing.Size(63, 25)
        Me.btnGetStartPos.TabIndex = 39
        Me.btnGetStartPos.Text = "Get"
        Me.btnGetStartPos.UseVisualStyleBackColor = True
        '
        'tbCalPos_Y
        '
        Me.tbCalPos_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCalPos_Y.Location = New System.Drawing.Point(232, 90)
        Me.tbCalPos_Y.Name = "tbCalPos_Y"
        Me.tbCalPos_Y.Size = New System.Drawing.Size(86, 21)
        Me.tbCalPos_Y.TabIndex = 35
        Me.tbCalPos_Y.Text = "0"
        Me.tbCalPos_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbEndPos_Y
        '
        Me.tbEndPos_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbEndPos_Y.Location = New System.Drawing.Point(232, 61)
        Me.tbEndPos_Y.Name = "tbEndPos_Y"
        Me.tbEndPos_Y.Size = New System.Drawing.Size(86, 21)
        Me.tbEndPos_Y.TabIndex = 34
        Me.tbEndPos_Y.Text = "0"
        Me.tbEndPos_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbStartPos_Y
        '
        Me.tbStartPos_Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbStartPos_Y.Location = New System.Drawing.Point(232, 33)
        Me.tbStartPos_Y.Name = "tbStartPos_Y"
        Me.tbStartPos_Y.Size = New System.Drawing.Size(86, 21)
        Me.tbStartPos_Y.TabIndex = 33
        Me.tbStartPos_Y.Text = "0"
        Me.tbStartPos_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbCalPos_X
        '
        Me.tbCalPos_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCalPos_X.Location = New System.Drawing.Point(142, 90)
        Me.tbCalPos_X.Name = "tbCalPos_X"
        Me.tbCalPos_X.Size = New System.Drawing.Size(86, 21)
        Me.tbCalPos_X.TabIndex = 32
        Me.tbCalPos_X.Text = "0"
        Me.tbCalPos_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbCalPos_X.Visible = False
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(49, 64)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(83, 15)
        Me.Label38.TabIndex = 30
        Me.Label38.Text = "End Position :"
        '
        'tbEndPos_X
        '
        Me.tbEndPos_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbEndPos_X.Location = New System.Drawing.Point(142, 61)
        Me.tbEndPos_X.Name = "tbEndPos_X"
        Me.tbEndPos_X.Size = New System.Drawing.Size(86, 21)
        Me.tbEndPos_X.TabIndex = 31
        Me.tbEndPos_X.Text = "0"
        Me.tbEndPos_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbEndPos_X.Visible = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(46, 36)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(86, 15)
        Me.Label39.TabIndex = 28
        Me.Label39.Text = "Start Position :"
        '
        'tbStartPos_X
        '
        Me.tbStartPos_X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbStartPos_X.Location = New System.Drawing.Point(142, 33)
        Me.tbStartPos_X.Name = "tbStartPos_X"
        Me.tbStartPos_X.Size = New System.Drawing.Size(86, 21)
        Me.tbStartPos_X.TabIndex = 29
        Me.tbStartPos_X.Text = "0"
        Me.tbStartPos_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbStartPos_X.Visible = False
        '
        'tpTemp
        '
        Me.tpTemp.Controls.Add(Me.GroupBox22)
        Me.tpTemp.Controls.Add(Me.GroupBox6)
        Me.tpTemp.Location = New System.Drawing.Point(4, 27)
        Me.tpTemp.Name = "tpTemp"
        Me.tpTemp.Size = New System.Drawing.Size(751, 642)
        Me.tpTemp.TabIndex = 10
        Me.tpTemp.Text = "Temp & Spectrometer"
        Me.tpTemp.UseVisualStyleBackColor = True
        '
        'GroupBox22
        '
        Me.GroupBox22.Controls.Add(Me.GroupBox26)
        Me.GroupBox22.Controls.Add(Me.GroupBox25)
        Me.GroupBox22.Location = New System.Drawing.Point(5, 107)
        Me.GroupBox22.Name = "GroupBox22"
        Me.GroupBox22.Size = New System.Drawing.Size(681, 162)
        Me.GroupBox22.TabIndex = 7
        Me.GroupBox22.TabStop = False
        Me.GroupBox22.Text = "Spectrometer"
        '
        'GroupBox26
        '
        Me.GroupBox26.Controls.Add(Me.Label114)
        Me.GroupBox26.Controls.Add(Me.chkSpectroMeasureMode)
        Me.GroupBox26.Controls.Add(Me.Label109)
        Me.GroupBox26.Controls.Add(Me.cbIVLSweepSpeedMode)
        Me.GroupBox26.Controls.Add(Me.tbExposureTime)
        Me.GroupBox26.Controls.Add(Me.Label108)
        Me.GroupBox26.Controls.Add(Me.Label77)
        Me.GroupBox26.Controls.Add(Me.cbIVLSweepAperture)
        Me.GroupBox26.Controls.Add(Me.Label78)
        Me.GroupBox26.Location = New System.Drawing.Point(11, 20)
        Me.GroupBox26.Name = "GroupBox26"
        Me.GroupBox26.Size = New System.Drawing.Size(346, 126)
        Me.GroupBox26.TabIndex = 31
        Me.GroupBox26.TabStop = False
        Me.GroupBox26.Text = "IVL Sweep"
        Me.GroupBox26.Visible = False
        '
        'Label114
        '
        Me.Label114.AutoSize = True
        Me.Label114.Location = New System.Drawing.Point(40, 51)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(94, 15)
        Me.Label114.TabIndex = 42
        Me.Label114.Text = "Measure Mode :"
        Me.Label114.Visible = False
        '
        'chkSpectroMeasureMode
        '
        Me.chkSpectroMeasureMode.AutoSize = True
        Me.chkSpectroMeasureMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkSpectroMeasureMode.Location = New System.Drawing.Point(163, 51)
        Me.chkSpectroMeasureMode.Name = "chkSpectroMeasureMode"
        Me.chkSpectroMeasureMode.Size = New System.Drawing.Size(72, 19)
        Me.chkSpectroMeasureMode.TabIndex = 41
        Me.chkSpectroMeasureMode.Text = "MANUAL"
        Me.chkSpectroMeasureMode.UseVisualStyleBackColor = True
        Me.chkSpectroMeasureMode.Visible = False
        '
        'Label109
        '
        Me.Label109.AutoSize = True
        Me.Label109.Location = New System.Drawing.Point(225, 79)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(57, 15)
        Me.Label109.TabIndex = 40
        Me.Label109.Text = "(6~6000)"
        '
        'cbIVLSweepSpeedMode
        '
        Me.cbIVLSweepSpeedMode.FormattingEnabled = True
        Me.cbIVLSweepSpeedMode.Items.AddRange(New Object() {"Nomal", "Fast"})
        Me.cbIVLSweepSpeedMode.Location = New System.Drawing.Point(219, 22)
        Me.cbIVLSweepSpeedMode.Name = "cbIVLSweepSpeedMode"
        Me.cbIVLSweepSpeedMode.Size = New System.Drawing.Size(67, 23)
        Me.cbIVLSweepSpeedMode.TabIndex = 37
        '
        'tbExposureTime
        '
        Me.tbExposureTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbExposureTime.Location = New System.Drawing.Point(135, 76)
        Me.tbExposureTime.Name = "tbExposureTime"
        Me.tbExposureTime.Size = New System.Drawing.Size(84, 21)
        Me.tbExposureTime.TabIndex = 38
        Me.tbExposureTime.Text = "0"
        Me.tbExposureTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.Location = New System.Drawing.Point(15, 79)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(125, 15)
        Me.Label108.TabIndex = 39
        Me.Label108.Text = "Exposure Time(ms) : "
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(136, 25)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(85, 15)
        Me.Label77.TabIndex = 36
        Me.Label77.Text = "Speed Mode : "
        '
        'cbIVLSweepAperture
        '
        Me.cbIVLSweepAperture.FormattingEnabled = True
        Me.cbIVLSweepAperture.Items.AddRange(New Object() {"2'", "1'", "0.2'", "0.1'"})
        Me.cbIVLSweepAperture.Location = New System.Drawing.Point(69, 22)
        Me.cbIVLSweepAperture.Name = "cbIVLSweepAperture"
        Me.cbIVLSweepAperture.Size = New System.Drawing.Size(61, 23)
        Me.cbIVLSweepAperture.TabIndex = 35
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(9, 25)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(62, 15)
        Me.Label78.TabIndex = 34
        Me.Label78.Text = "Aperture : "
        '
        'GroupBox25
        '
        Me.GroupBox25.Controls.Add(Me.cbSpeedMode)
        Me.GroupBox25.Controls.Add(Me.Label44)
        Me.GroupBox25.Controls.Add(Me.cbAperture)
        Me.GroupBox25.Controls.Add(Me.Label37)
        Me.GroupBox25.Location = New System.Drawing.Point(365, 20)
        Me.GroupBox25.Name = "GroupBox25"
        Me.GroupBox25.Size = New System.Drawing.Size(289, 57)
        Me.GroupBox25.TabIndex = 30
        Me.GroupBox25.TabStop = False
        Me.GroupBox25.Text = "Lifetime"
        '
        'cbSpeedMode
        '
        Me.cbSpeedMode.FormattingEnabled = True
        Me.cbSpeedMode.Items.AddRange(New Object() {"Nomal", "Fast"})
        Me.cbSpeedMode.Location = New System.Drawing.Point(210, 22)
        Me.cbSpeedMode.Name = "cbSpeedMode"
        Me.cbSpeedMode.Size = New System.Drawing.Size(67, 23)
        Me.cbSpeedMode.TabIndex = 37
        Me.cbSpeedMode.Visible = False
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(128, 25)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(85, 15)
        Me.Label44.TabIndex = 36
        Me.Label44.Text = "Speed Mode : "
        Me.Label44.Visible = False
        '
        'cbAperture
        '
        Me.cbAperture.FormattingEnabled = True
        Me.cbAperture.Items.AddRange(New Object() {"2'", "1'", "0.2'", "0.1'"})
        Me.cbAperture.Location = New System.Drawing.Point(64, 22)
        Me.cbAperture.Name = "cbAperture"
        Me.cbAperture.Size = New System.Drawing.Size(61, 23)
        Me.cbAperture.TabIndex = 35
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 25)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(62, 15)
        Me.Label37.TabIndex = 34
        Me.Label37.Text = "Aperture : "
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cbAngleGain)
        Me.GroupBox6.Controls.Add(Me.Label27)
        Me.GroupBox6.Controls.Add(Me.Label43)
        Me.GroupBox6.Controls.Add(Me.Label23)
        Me.GroupBox6.Controls.Add(Me.Label29)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.tbTemp_LimitAlarmHigh)
        Me.GroupBox6.Controls.Add(Me.cbLifetimeGain)
        Me.GroupBox6.Controls.Add(Me.Label30)
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Controls.Add(Me.tbTemp_LimitAlarmLow)
        Me.GroupBox6.Controls.Add(Me.cbIVLSweepGain)
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Controls.Add(Me.Label21)
        Me.GroupBox6.Controls.Add(Me.tbTemp_Margin)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(606, 98)
        Me.GroupBox6.TabIndex = 6
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Temperature"
        Me.GroupBox6.Visible = False
        '
        'cbAngleGain
        '
        Me.cbAngleGain.FormattingEnabled = True
        Me.cbAngleGain.Items.AddRange(New Object() {"Auto Gain", "1 Gain Fix", "2 Gain Fix", "3 Gain Fix", "4 Gain Fix"})
        Me.cbAngleGain.Location = New System.Drawing.Point(269, 63)
        Me.cbAngleGain.Name = "cbAngleGain"
        Me.cbAngleGain.Size = New System.Drawing.Size(65, 23)
        Me.cbAngleGain.TabIndex = 28
        Me.cbAngleGain.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(186, 63)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(21, 15)
        Me.Label27.TabIndex = 26
        Me.Label27.Text = "°C"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(370, 29)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(74, 15)
        Me.Label43.TabIndex = 21
        Me.Label43.Text = "IVL Sweep : "
        Me.Label43.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(380, 61)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(60, 15)
        Me.Label23.TabIndex = 24
        Me.Label23.Text = "Lifetime : "
        Me.Label23.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(10, 63)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(106, 15)
        Me.Label29.TabIndex = 24
        Me.Label29.Text = "Limit Alarm High : "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(217, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 15)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Angle : "
        Me.Label9.Visible = False
        '
        'tbTemp_LimitAlarmHigh
        '
        Me.tbTemp_LimitAlarmHigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbTemp_LimitAlarmHigh.Location = New System.Drawing.Point(119, 60)
        Me.tbTemp_LimitAlarmHigh.Name = "tbTemp_LimitAlarmHigh"
        Me.tbTemp_LimitAlarmHigh.Size = New System.Drawing.Size(65, 21)
        Me.tbTemp_LimitAlarmHigh.TabIndex = 25
        Me.tbTemp_LimitAlarmHigh.Text = "0"
        Me.tbTemp_LimitAlarmHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbLifetimeGain
        '
        Me.cbLifetimeGain.FormattingEnabled = True
        Me.cbLifetimeGain.Items.AddRange(New Object() {"Auto Gain", "1 Gain Fix", "2 Gain Fix", "3 Gain Fix", "4 Gain Fix"})
        Me.cbLifetimeGain.Location = New System.Drawing.Point(445, 57)
        Me.cbLifetimeGain.Name = "cbLifetimeGain"
        Me.cbLifetimeGain.Size = New System.Drawing.Size(79, 23)
        Me.cbLifetimeGain.TabIndex = 26
        Me.cbLifetimeGain.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(186, 31)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(21, 15)
        Me.Label30.TabIndex = 23
        Me.Label30.Text = "°C"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(13, 31)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(103, 15)
        Me.Label36.TabIndex = 21
        Me.Label36.Text = "Limit Alarm Low : "
        '
        'tbTemp_LimitAlarmLow
        '
        Me.tbTemp_LimitAlarmLow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbTemp_LimitAlarmLow.Location = New System.Drawing.Point(119, 28)
        Me.tbTemp_LimitAlarmLow.Name = "tbTemp_LimitAlarmLow"
        Me.tbTemp_LimitAlarmLow.Size = New System.Drawing.Size(65, 21)
        Me.tbTemp_LimitAlarmLow.TabIndex = 22
        Me.tbTemp_LimitAlarmLow.Text = "0"
        Me.tbTemp_LimitAlarmLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbIVLSweepGain
        '
        Me.cbIVLSweepGain.FormattingEnabled = True
        Me.cbIVLSweepGain.Items.AddRange(New Object() {"Auto Gain", "1 Gain Fix", "2 Gain Fix", "3 Gain Fix", "4 Gain Fix"})
        Me.cbIVLSweepGain.Location = New System.Drawing.Point(445, 26)
        Me.cbIVLSweepGain.Name = "cbIVLSweepGain"
        Me.cbIVLSweepGain.Size = New System.Drawing.Size(79, 23)
        Me.cbIVLSweepGain.TabIndex = 25
        Me.cbIVLSweepGain.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(336, 31)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(21, 15)
        Me.Label22.TabIndex = 16
        Me.Label22.Text = "°C"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(215, 31)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 15)
        Me.Label21.TabIndex = 12
        Me.Label21.Text = "Margin : "
        '
        'tbTemp_Margin
        '
        Me.tbTemp_Margin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbTemp_Margin.Location = New System.Drawing.Point(269, 28)
        Me.tbTemp_Margin.Name = "tbTemp_Margin"
        Me.tbTemp_Margin.Size = New System.Drawing.Size(65, 21)
        Me.tbTemp_Margin.TabIndex = 13
        Me.tbTemp_Margin.Text = "0"
        Me.tbTemp_Margin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tpDisplay
        '
        Me.tpDisplay.Controls.Add(Me.tbDispDigit_Integral_Relative)
        Me.tpDisplay.Controls.Add(Me.ucSelDispType_Photocurrent)
        Me.tpDisplay.Controls.Add(Me.tbDispDigit_Integral)
        Me.tpDisplay.Controls.Add(Me.Label83)
        Me.tpDisplay.Controls.Add(Me.gbSampleInfos)
        Me.tpDisplay.Controls.Add(Me.Label82)
        Me.tpDisplay.Controls.Add(Me.GroupBox21)
        Me.tpDisplay.Controls.Add(Me.GroupBox16)
        Me.tpDisplay.Controls.Add(Me.Label68)
        Me.tpDisplay.Controls.Add(Me.gnNumOfOutdataDsipMDX)
        Me.tpDisplay.Controls.Add(Me.GroupBox15)
        Me.tpDisplay.Controls.Add(Me.tbDispDigit_Photocurrent)
        Me.tpDisplay.Location = New System.Drawing.Point(4, 27)
        Me.tpDisplay.Name = "tpDisplay"
        Me.tpDisplay.Size = New System.Drawing.Size(751, 642)
        Me.tpDisplay.TabIndex = 6
        Me.tpDisplay.Text = "Display"
        Me.tpDisplay.UseVisualStyleBackColor = True
        '
        'tbDispDigit_Integral_Relative
        '
        Me.tbDispDigit_Integral_Relative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDispDigit_Integral_Relative.Location = New System.Drawing.Point(440, 550)
        Me.tbDispDigit_Integral_Relative.Name = "tbDispDigit_Integral_Relative"
        Me.tbDispDigit_Integral_Relative.Size = New System.Drawing.Size(68, 21)
        Me.tbDispDigit_Integral_Relative.TabIndex = 89
        Me.tbDispDigit_Integral_Relative.Text = "4"
        Me.tbDispDigit_Integral_Relative.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbDispDigit_Integral_Relative.Visible = False
        '
        'ucSelDispType_Photocurrent
        '
        Me.ucSelDispType_Photocurrent.CanSelectValueType = True
        Me.ucSelDispType_Photocurrent.Location = New System.Drawing.Point(102, 457)
        Me.ucSelDispType_Photocurrent.Margin = New System.Windows.Forms.Padding(3, 8, 3, 8)
        Me.ucSelDispType_Photocurrent.Name = "ucSelDispType_Photocurrent"
        Me.ucSelDispType_Photocurrent.SelectedUnit = New M7000.CUnitCommonNode.eMKSUnit() {M7000.CUnitCommonNode.eMKSUnit.Def, M7000.CUnitCommonNode.eMKSUnit.Exa}
        Me.ucSelDispType_Photocurrent.Size = New System.Drawing.Size(225, 41)
        Me.ucSelDispType_Photocurrent.TabIndex = 27
        Me.ucSelDispType_Photocurrent.ValueType = M7000.CUnitConverter.eType.Ampere
        Me.ucSelDispType_Photocurrent.Visible = False
        '
        'tbDispDigit_Integral
        '
        Me.tbDispDigit_Integral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDispDigit_Integral.Location = New System.Drawing.Point(440, 517)
        Me.tbDispDigit_Integral.Name = "tbDispDigit_Integral"
        Me.tbDispDigit_Integral.Size = New System.Drawing.Size(68, 21)
        Me.tbDispDigit_Integral.TabIndex = 88
        Me.tbDispDigit_Integral.Text = "4"
        Me.tbDispDigit_Integral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbDispDigit_Integral.Visible = False
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Location = New System.Drawing.Point(63, 556)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(101, 15)
        Me.Label83.TabIndex = 87
        Me.Label83.Text = "Integral Relative :"
        Me.Label83.Visible = False
        '
        'gbSampleInfos
        '
        Me.gbSampleInfos.Controls.Add(Me.tbSampleHeight)
        Me.gbSampleInfos.Controls.Add(Me.Label74)
        Me.gbSampleInfos.Controls.Add(Me.tbSampleWidth)
        Me.gbSampleInfos.Controls.Add(Me.tbFill)
        Me.gbSampleInfos.Controls.Add(Me.Label75)
        Me.gbSampleInfos.Controls.Add(Me.Label76)
        Me.gbSampleInfos.Location = New System.Drawing.Point(12, 315)
        Me.gbSampleInfos.Name = "gbSampleInfos"
        Me.gbSampleInfos.Size = New System.Drawing.Size(487, 55)
        Me.gbSampleInfos.TabIndex = 86
        Me.gbSampleInfos.TabStop = False
        Me.gbSampleInfos.Text = "Manual UI SampleInfos"
        Me.gbSampleInfos.Visible = False
        '
        'tbSampleHeight
        '
        Me.tbSampleHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSampleHeight.Location = New System.Drawing.Point(88, 21)
        Me.tbSampleHeight.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbSampleHeight.Name = "tbSampleHeight"
        Me.tbSampleHeight.Size = New System.Drawing.Size(70, 21)
        Me.tbSampleHeight.TabIndex = 78
        Me.tbSampleHeight.Text = "2.772"
        Me.tbSampleHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(9, 24)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(82, 15)
        Me.Label74.TabIndex = 79
        Me.Label74.Text = "Height(mm) : "
        '
        'tbSampleWidth
        '
        Me.tbSampleWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSampleWidth.Location = New System.Drawing.Point(234, 21)
        Me.tbSampleWidth.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbSampleWidth.Name = "tbSampleWidth"
        Me.tbSampleWidth.Size = New System.Drawing.Size(70, 21)
        Me.tbSampleWidth.TabIndex = 80
        Me.tbSampleWidth.Text = "2.772"
        Me.tbSampleWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbFill
        '
        Me.tbFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbFill.Location = New System.Drawing.Point(371, 21)
        Me.tbFill.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbFill.Name = "tbFill"
        Me.tbFill.Size = New System.Drawing.Size(70, 21)
        Me.tbFill.TabIndex = 82
        Me.tbFill.Text = "13.19"
        Me.tbFill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(163, 24)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(77, 15)
        Me.Label75.TabIndex = 81
        Me.Label75.Text = "Width(mm) : "
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(322, 24)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(51, 15)
        Me.Label76.TabIndex = 83
        Me.Label76.Text = "Fill(%) : "
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Location = New System.Drawing.Point(111, 523)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(54, 15)
        Me.Label82.TabIndex = 27
        Me.Label82.Text = "Integral :"
        Me.Label82.Visible = False
        '
        'GroupBox21
        '
        Me.GroupBox21.Controls.Add(Me.chkVisibleAngleMoveButton)
        Me.GroupBox21.Controls.Add(Me.chkVisibleChannelMoveButton)
        Me.GroupBox21.Location = New System.Drawing.Point(12, 254)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Size = New System.Drawing.Size(487, 55)
        Me.GroupBox21.TabIndex = 6
        Me.GroupBox21.TabStop = False
        Me.GroupBox21.Text = "Motion UI"
        Me.GroupBox21.Visible = False
        '
        'chkVisibleAngleMoveButton
        '
        Me.chkVisibleAngleMoveButton.AutoSize = True
        Me.chkVisibleAngleMoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkVisibleAngleMoveButton.Location = New System.Drawing.Point(155, 22)
        Me.chkVisibleAngleMoveButton.Name = "chkVisibleAngleMoveButton"
        Me.chkVisibleAngleMoveButton.Size = New System.Drawing.Size(117, 19)
        Me.chkVisibleAngleMoveButton.TabIndex = 1
        Me.chkVisibleAngleMoveButton.Text = "AngleMoveButton"
        Me.chkVisibleAngleMoveButton.UseVisualStyleBackColor = True
        '
        'chkVisibleChannelMoveButton
        '
        Me.chkVisibleChannelMoveButton.AutoSize = True
        Me.chkVisibleChannelMoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkVisibleChannelMoveButton.Location = New System.Drawing.Point(12, 22)
        Me.chkVisibleChannelMoveButton.Name = "chkVisibleChannelMoveButton"
        Me.chkVisibleChannelMoveButton.Size = New System.Drawing.Size(133, 19)
        Me.chkVisibleChannelMoveButton.TabIndex = 0
        Me.chkVisibleChannelMoveButton.Text = "ChannelMoveButton"
        Me.chkVisibleChannelMoveButton.UseVisualStyleBackColor = True
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.chkFilenameTEGtoTEGChannel)
        Me.GroupBox16.Controls.Add(Me.rdoDispCh_JIGAndCellNo)
        Me.GroupBox16.Controls.Add(Me.rdoDispCh_Channel)
        Me.GroupBox16.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(487, 122)
        Me.GroupBox16.TabIndex = 5
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Channel Number Display"
        Me.GroupBox16.Visible = False
        '
        'chkFilenameTEGtoTEGChannel
        '
        Me.chkFilenameTEGtoTEGChannel.AutoSize = True
        Me.chkFilenameTEGtoTEGChannel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkFilenameTEGtoTEGChannel.Location = New System.Drawing.Point(14, 90)
        Me.chkFilenameTEGtoTEGChannel.Name = "chkFilenameTEGtoTEGChannel"
        Me.chkFilenameTEGtoTEGChannel.Size = New System.Drawing.Size(378, 19)
        Me.chkFilenameTEGtoTEGChannel.TabIndex = 2
        Me.chkFilenameTEGtoTEGChannel.Text = "File name Storage type is TEG number - Channel number of TEG"
        Me.chkFilenameTEGtoTEGChannel.UseVisualStyleBackColor = True
        '
        'rdoDispCh_JIGAndCellNo
        '
        Me.rdoDispCh_JIGAndCellNo.AutoSize = True
        Me.rdoDispCh_JIGAndCellNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoDispCh_JIGAndCellNo.Location = New System.Drawing.Point(14, 55)
        Me.rdoDispCh_JIGAndCellNo.Name = "rdoDispCh_JIGAndCellNo"
        Me.rdoDispCh_JIGAndCellNo.Size = New System.Drawing.Size(352, 19)
        Me.rdoDispCh_JIGAndCellNo.TabIndex = 1
        Me.rdoDispCh_JIGAndCellNo.TabStop = True
        Me.rdoDispCh_JIGAndCellNo.Text = "Displays the channel number as JIG number + Cell number."
        Me.rdoDispCh_JIGAndCellNo.UseVisualStyleBackColor = True
        '
        'rdoDispCh_Channel
        '
        Me.rdoDispCh_Channel.AutoSize = True
        Me.rdoDispCh_Channel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdoDispCh_Channel.Location = New System.Drawing.Point(14, 28)
        Me.rdoDispCh_Channel.Name = "rdoDispCh_Channel"
        Me.rdoDispCh_Channel.Size = New System.Drawing.Size(430, 19)
        Me.rdoDispCh_Channel.TabIndex = 0
        Me.rdoDispCh_Channel.TabStop = True
        Me.rdoDispCh_Channel.Text = "Displays the channel number from 1 to the maximum number of channels."
        Me.rdoDispCh_Channel.UseVisualStyleBackColor = True
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(23, 462)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(86, 15)
        Me.Label68.TabIndex = 24
        Me.Label68.Text = "PhotoCurrent :"
        Me.Label68.Visible = False
        '
        'gnNumOfOutdataDsipMDX
        '
        Me.gnNumOfOutdataDsipMDX.Controls.Add(Me.ChkOut_5)
        Me.gnNumOfOutdataDsipMDX.Controls.Add(Me.ChkOut_4)
        Me.gnNumOfOutdataDsipMDX.Controls.Add(Me.ChkOut_3)
        Me.gnNumOfOutdataDsipMDX.Controls.Add(Me.ChkOut_2)
        Me.gnNumOfOutdataDsipMDX.Controls.Add(Me.ChkOut_1)
        Me.gnNumOfOutdataDsipMDX.Location = New System.Drawing.Point(556, 327)
        Me.gnNumOfOutdataDsipMDX.Name = "gnNumOfOutdataDsipMDX"
        Me.gnNumOfOutdataDsipMDX.Size = New System.Drawing.Size(43, 112)
        Me.gnNumOfOutdataDsipMDX.TabIndex = 4
        Me.gnNumOfOutdataDsipMDX.TabStop = False
        Me.gnNumOfOutdataDsipMDX.Text = "Number Of Output Display Setting (Only MDX)"
        Me.gnNumOfOutdataDsipMDX.Visible = False
        '
        'ChkOut_5
        '
        Me.ChkOut_5.AutoSize = True
        Me.ChkOut_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChkOut_5.Location = New System.Drawing.Point(246, 55)
        Me.ChkOut_5.Name = "ChkOut_5"
        Me.ChkOut_5.Size = New System.Drawing.Size(55, 19)
        Me.ChkOut_5.TabIndex = 4
        Me.ChkOut_5.Text = "V5(I5)"
        Me.ChkOut_5.UseVisualStyleBackColor = True
        '
        'ChkOut_4
        '
        Me.ChkOut_4.AutoSize = True
        Me.ChkOut_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChkOut_4.Location = New System.Drawing.Point(185, 55)
        Me.ChkOut_4.Name = "ChkOut_4"
        Me.ChkOut_4.Size = New System.Drawing.Size(55, 19)
        Me.ChkOut_4.TabIndex = 3
        Me.ChkOut_4.Text = "V4(I4)"
        Me.ChkOut_4.UseVisualStyleBackColor = True
        '
        'ChkOut_3
        '
        Me.ChkOut_3.AutoSize = True
        Me.ChkOut_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChkOut_3.Location = New System.Drawing.Point(129, 55)
        Me.ChkOut_3.Name = "ChkOut_3"
        Me.ChkOut_3.Size = New System.Drawing.Size(55, 19)
        Me.ChkOut_3.TabIndex = 2
        Me.ChkOut_3.Text = "V3(I3)"
        Me.ChkOut_3.UseVisualStyleBackColor = True
        '
        'ChkOut_2
        '
        Me.ChkOut_2.AutoSize = True
        Me.ChkOut_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChkOut_2.Location = New System.Drawing.Point(68, 55)
        Me.ChkOut_2.Name = "ChkOut_2"
        Me.ChkOut_2.Size = New System.Drawing.Size(55, 19)
        Me.ChkOut_2.TabIndex = 1
        Me.ChkOut_2.Text = "V2(I2)"
        Me.ChkOut_2.UseVisualStyleBackColor = True
        '
        'ChkOut_1
        '
        Me.ChkOut_1.AutoSize = True
        Me.ChkOut_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChkOut_1.Location = New System.Drawing.Point(7, 55)
        Me.ChkOut_1.Name = "ChkOut_1"
        Me.ChkOut_1.Size = New System.Drawing.Size(55, 19)
        Me.ChkOut_1.TabIndex = 0
        Me.ChkOut_1.Text = "V1(I1)"
        Me.ChkOut_1.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.ucSelDispType_Current)
        Me.GroupBox15.Controls.Add(Me.ucSelDispType_Volt)
        Me.GroupBox15.Controls.Add(Me.Label69)
        Me.GroupBox15.Controls.Add(Me.Label70)
        Me.GroupBox15.Controls.Add(Me.tbDispDigit_Current)
        Me.GroupBox15.Controls.Add(Me.tbDispDigit_Volt)
        Me.GroupBox15.Controls.Add(Me.Label71)
        Me.GroupBox15.Controls.Add(Me.Label72)
        Me.GroupBox15.Controls.Add(Me.Label73)
        Me.GroupBox15.Location = New System.Drawing.Point(12, 133)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(487, 115)
        Me.GroupBox15.TabIndex = 3
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Data Appearance"
        '
        'ucSelDispType_Current
        '
        Me.ucSelDispType_Current.CanSelectValueType = True
        Me.ucSelDispType_Current.Location = New System.Drawing.Point(112, 69)
        Me.ucSelDispType_Current.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ucSelDispType_Current.Name = "ucSelDispType_Current"
        Me.ucSelDispType_Current.SelectedUnit = New M7000.CUnitCommonNode.eMKSUnit() {M7000.CUnitCommonNode.eMKSUnit.Def, M7000.CUnitCommonNode.eMKSUnit.Exa}
        Me.ucSelDispType_Current.Size = New System.Drawing.Size(259, 30)
        Me.ucSelDispType_Current.TabIndex = 26
        Me.ucSelDispType_Current.ValueType = M7000.CUnitConverter.eType.Ampere
        Me.ucSelDispType_Current.Visible = False
        '
        'ucSelDispType_Volt
        '
        Me.ucSelDispType_Volt.CanSelectValueType = True
        Me.ucSelDispType_Volt.Location = New System.Drawing.Point(113, 34)
        Me.ucSelDispType_Volt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ucSelDispType_Volt.Name = "ucSelDispType_Volt"
        Me.ucSelDispType_Volt.SelectedUnit = New M7000.CUnitCommonNode.eMKSUnit() {M7000.CUnitCommonNode.eMKSUnit.Def, M7000.CUnitCommonNode.eMKSUnit.Exa}
        Me.ucSelDispType_Volt.Size = New System.Drawing.Size(264, 30)
        Me.ucSelDispType_Volt.TabIndex = 25
        Me.ucSelDispType_Volt.ValueType = M7000.CUnitConverter.eType.Voltage
        Me.ucSelDispType_Volt.Visible = False
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(54, 76)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(54, 15)
        Me.Label69.TabIndex = 23
        Me.Label69.Text = "Current :"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(54, 42)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(53, 15)
        Me.Label70.TabIndex = 12
        Me.Label70.Text = "Voltage :"
        '
        'tbDispDigit_Current
        '
        Me.tbDispDigit_Current.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDispDigit_Current.Location = New System.Drawing.Point(383, 73)
        Me.tbDispDigit_Current.Name = "tbDispDigit_Current"
        Me.tbDispDigit_Current.Size = New System.Drawing.Size(68, 21)
        Me.tbDispDigit_Current.TabIndex = 7
        Me.tbDispDigit_Current.Text = "3"
        Me.tbDispDigit_Current.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbDispDigit_Volt
        '
        Me.tbDispDigit_Volt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDispDigit_Volt.Location = New System.Drawing.Point(383, 38)
        Me.tbDispDigit_Volt.Name = "tbDispDigit_Volt"
        Me.tbDispDigit_Volt.Size = New System.Drawing.Size(68, 21)
        Me.tbDispDigit_Volt.TabIndex = 6
        Me.tbDispDigit_Volt.Text = "3"
        Me.tbDispDigit_Volt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label71
        '
        Me.Label71.Location = New System.Drawing.Point(211, 16)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(99, 22)
        Me.Label71.TabIndex = 14
        Me.Label71.Text = "Unit"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label71.Visible = False
        '
        'Label72
        '
        Me.Label72.Location = New System.Drawing.Point(106, 16)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(99, 22)
        Me.Label72.TabIndex = 13
        Me.Label72.Text = "Data"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label72.Visible = False
        '
        'Label73
        '
        Me.Label73.Location = New System.Drawing.Point(366, 16)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(102, 22)
        Me.Label73.TabIndex = 12
        Me.Label73.Text = "Digit"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbDispDigit_Photocurrent
        '
        Me.tbDispDigit_Photocurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDispDigit_Photocurrent.Location = New System.Drawing.Point(376, 462)
        Me.tbDispDigit_Photocurrent.Name = "tbDispDigit_Photocurrent"
        Me.tbDispDigit_Photocurrent.Size = New System.Drawing.Size(36, 21)
        Me.tbDispDigit_Photocurrent.TabIndex = 22
        Me.tbDispDigit_Photocurrent.Text = "3"
        Me.tbDispDigit_Photocurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbDispDigit_Photocurrent.Visible = False
        '
        'tpStatusColor
        '
        Me.tpStatusColor.Controls.Add(Me.ucDispFontColorList)
        Me.tpStatusColor.Controls.Add(Me.GroupBox13)
        Me.tpStatusColor.Location = New System.Drawing.Point(4, 27)
        Me.tpStatusColor.Name = "tpStatusColor"
        Me.tpStatusColor.Size = New System.Drawing.Size(751, 642)
        Me.tpStatusColor.TabIndex = 4
        Me.tpStatusColor.Text = "Status Color"
        Me.tpStatusColor.UseVisualStyleBackColor = True
        '
        'ucDispFontColorList
        '
        Me.ucDispFontColorList.ColHeader = New String() {"No", "Status", "Color"}
        Me.ucDispFontColorList.ColHeaderWidthRatio = "10,65,25"
        Me.ucDispFontColorList.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ucDispFontColorList.FullRawSelection = True
        Me.ucDispFontColorList.HideSelection = False
        Me.ucDispFontColorList.LabelEdit = True
        Me.ucDispFontColorList.LabelWrap = True
        Me.ucDispFontColorList.Location = New System.Drawing.Point(14, 121)
        Me.ucDispFontColorList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ucDispFontColorList.Name = "ucDispFontColorList"
        Me.ucDispFontColorList.Size = New System.Drawing.Size(561, 328)
        Me.ucDispFontColorList.TabIndex = 18
        Me.ucDispFontColorList.UseCheckBoxex = True
        Me.ucDispFontColorList.Visible = False
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.btnColorAdd)
        Me.GroupBox13.Controls.Add(Me.btnColorDel)
        Me.GroupBox13.Controls.Add(Me.cbStatus)
        Me.GroupBox13.Controls.Add(Me.lbColor)
        Me.GroupBox13.Location = New System.Drawing.Point(14, 28)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(561, 86)
        Me.GroupBox13.TabIndex = 17
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Select Display Color"
        Me.GroupBox13.Visible = False
        '
        'btnColorAdd
        '
        Me.btnColorAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnColorAdd.Location = New System.Drawing.Point(410, 43)
        Me.btnColorAdd.Name = "btnColorAdd"
        Me.btnColorAdd.Size = New System.Drawing.Size(64, 25)
        Me.btnColorAdd.TabIndex = 13
        Me.btnColorAdd.Text = "ADD"
        Me.btnColorAdd.UseVisualStyleBackColor = True
        '
        'btnColorDel
        '
        Me.btnColorDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnColorDel.Location = New System.Drawing.Point(479, 43)
        Me.btnColorDel.Name = "btnColorDel"
        Me.btnColorDel.Size = New System.Drawing.Size(64, 25)
        Me.btnColorDel.TabIndex = 15
        Me.btnColorDel.Text = "DEL"
        Me.btnColorDel.UseVisualStyleBackColor = True
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(25, 43)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(127, 23)
        Me.cbStatus.TabIndex = 12
        '
        'lbColor
        '
        Me.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbColor.Location = New System.Drawing.Point(197, 43)
        Me.lbColor.Name = "lbColor"
        Me.lbColor.Size = New System.Drawing.Size(135, 25)
        Me.lbColor.TabIndex = 14
        '
        'tpCCD
        '
        Me.tpCCD.Controls.Add(Me.Label110)
        Me.tpCCD.Controls.Add(Me.cbAnalysisMode)
        Me.tpCCD.Controls.Add(Me.GroupBox32)
        Me.tpCCD.Controls.Add(Me.GroupBox10)
        Me.tpCCD.Location = New System.Drawing.Point(4, 27)
        Me.tpCCD.Name = "tpCCD"
        Me.tpCCD.Size = New System.Drawing.Size(751, 642)
        Me.tpCCD.TabIndex = 3
        Me.tpCCD.Text = "CCD"
        Me.tpCCD.UseVisualStyleBackColor = True
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.Enabled = False
        Me.Label110.Location = New System.Drawing.Point(20, 16)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(123, 15)
        Me.Label110.TabIndex = 20
        Me.Label110.Text = "Image Analysis Mode"
        Me.Label110.Visible = False
        '
        'cbAnalysisMode
        '
        Me.cbAnalysisMode.FormattingEnabled = True
        Me.cbAnalysisMode.Items.AddRange(New Object() {"IMAGE_BLOB_ANALYSIS", "IMAGE_EDGE_FIND_ANALYSIS"})
        Me.cbAnalysisMode.Location = New System.Drawing.Point(149, 13)
        Me.cbAnalysisMode.Name = "cbAnalysisMode"
        Me.cbAnalysisMode.Size = New System.Drawing.Size(171, 23)
        Me.cbAnalysisMode.TabIndex = 15
        Me.cbAnalysisMode.Visible = False
        '
        'GroupBox32
        '
        Me.GroupBox32.Controls.Add(Me.Label113)
        Me.GroupBox32.Controls.Add(Me.Label112)
        Me.GroupBox32.Controls.Add(Me.Label111)
        Me.GroupBox32.Controls.Add(Me.tbCaptureLevel)
        Me.GroupBox32.Controls.Add(Me.btnCaptureImgPathFind)
        Me.GroupBox32.Controls.Add(Me.tbCaptureImagePath)
        Me.GroupBox32.Enabled = False
        Me.GroupBox32.Location = New System.Drawing.Point(10, 216)
        Me.GroupBox32.Name = "GroupBox32"
        Me.GroupBox32.Size = New System.Drawing.Size(557, 100)
        Me.GroupBox32.TabIndex = 5
        Me.GroupBox32.TabStop = False
        Me.GroupBox32.Text = "Capture Image"
        Me.GroupBox32.Visible = False
        '
        'Label113
        '
        Me.Label113.AutoSize = True
        Me.Label113.Location = New System.Drawing.Point(221, 65)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(41, 15)
        Me.Label113.TabIndex = 29
        Me.Label113.Text = "Cdm2"
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.Location = New System.Drawing.Point(18, 28)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(32, 15)
        Me.Label112.TabIndex = 28
        Me.Label112.Text = "Path"
        '
        'Label111
        '
        Me.Label111.AutoSize = True
        Me.Label111.Location = New System.Drawing.Point(15, 64)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(108, 15)
        Me.Label111.TabIndex = 27
        Me.Label111.Text = "Capture Level (>=)"
        '
        'tbCaptureLevel
        '
        Me.tbCaptureLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCaptureLevel.Location = New System.Drawing.Point(126, 60)
        Me.tbCaptureLevel.Name = "tbCaptureLevel"
        Me.tbCaptureLevel.Size = New System.Drawing.Size(89, 21)
        Me.tbCaptureLevel.TabIndex = 2
        Me.tbCaptureLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCaptureImgPathFind
        '
        Me.btnCaptureImgPathFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCaptureImgPathFind.Location = New System.Drawing.Point(470, 21)
        Me.btnCaptureImgPathFind.Name = "btnCaptureImgPathFind"
        Me.btnCaptureImgPathFind.Size = New System.Drawing.Size(75, 26)
        Me.btnCaptureImgPathFind.TabIndex = 1
        Me.btnCaptureImgPathFind.Text = "Find..."
        Me.btnCaptureImgPathFind.UseVisualStyleBackColor = True
        '
        'tbCaptureImagePath
        '
        Me.tbCaptureImagePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCaptureImagePath.Location = New System.Drawing.Point(57, 24)
        Me.tbCaptureImagePath.Name = "tbCaptureImagePath"
        Me.tbCaptureImagePath.Size = New System.Drawing.Size(396, 21)
        Me.tbCaptureImagePath.TabIndex = 0
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Label31)
        Me.GroupBox10.Controls.Add(Me.tbAttributeString)
        Me.GroupBox10.Controls.Add(Me.Label32)
        Me.GroupBox10.Controls.Add(Me.tbCCDExposureValue)
        Me.GroupBox10.Controls.Add(Me.btnGetCCDValRange)
        Me.GroupBox10.Controls.Add(Me.btnSetCCDAttribute)
        Me.GroupBox10.Controls.Add(Me.lblCategory)
        Me.GroupBox10.Controls.Add(Me.Label34)
        Me.GroupBox10.Controls.Add(Me.Label33)
        Me.GroupBox10.Controls.Add(Me.tbAttributeValue)
        Me.GroupBox10.Controls.Add(Me.cbAttributes)
        Me.GroupBox10.Controls.Add(Me.Label28)
        Me.GroupBox10.Enabled = False
        Me.GroupBox10.Location = New System.Drawing.Point(10, 44)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(424, 166)
        Me.GroupBox10.TabIndex = 0
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Attributes"
        Me.GroupBox10.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(275, 30)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(21, 15)
        Me.Label31.TabIndex = 19
        Me.Label31.Text = "us"
        '
        'tbAttributeString
        '
        Me.tbAttributeString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbAttributeString.Location = New System.Drawing.Point(185, 95)
        Me.tbAttributeString.Name = "tbAttributeString"
        Me.tbAttributeString.Size = New System.Drawing.Size(113, 21)
        Me.tbAttributeString.TabIndex = 26
        Me.tbAttributeString.Text = "0"
        Me.tbAttributeString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(15, 30)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(140, 15)
        Me.Label32.TabIndex = 17
        Me.Label32.Text = "Default Exposure Value :"
        '
        'tbCCDExposureValue
        '
        Me.tbCCDExposureValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCCDExposureValue.Location = New System.Drawing.Point(158, 27)
        Me.tbCCDExposureValue.Name = "tbCCDExposureValue"
        Me.tbCCDExposureValue.Size = New System.Drawing.Size(113, 21)
        Me.tbCCDExposureValue.TabIndex = 18
        Me.tbCCDExposureValue.Text = "0"
        Me.tbCCDExposureValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnGetCCDValRange
        '
        Me.btnGetCCDValRange.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetCCDValRange.Location = New System.Drawing.Point(307, 92)
        Me.btnGetCCDValRange.Name = "btnGetCCDValRange"
        Me.btnGetCCDValRange.Size = New System.Drawing.Size(108, 28)
        Me.btnGetCCDValRange.TabIndex = 25
        Me.btnGetCCDValRange.Text = "Get Value Range"
        Me.btnGetCCDValRange.UseVisualStyleBackColor = True
        Me.btnGetCCDValRange.Visible = False
        '
        'btnSetCCDAttribute
        '
        Me.btnSetCCDAttribute.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetCCDAttribute.Location = New System.Drawing.Point(307, 62)
        Me.btnSetCCDAttribute.Name = "btnSetCCDAttribute"
        Me.btnSetCCDAttribute.Size = New System.Drawing.Size(108, 28)
        Me.btnSetCCDAttribute.TabIndex = 24
        Me.btnSetCCDAttribute.Text = "Set"
        Me.btnSetCCDAttribute.UseVisualStyleBackColor = True
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Location = New System.Drawing.Point(69, 129)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(0, 15)
        Me.lblCategory.TabIndex = 22
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(10, 129)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(62, 15)
        Me.Label34.TabIndex = 21
        Me.Label34.Text = "Category :"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(27, 99)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(43, 15)
        Me.Label33.TabIndex = 19
        Me.Label33.Text = "Value :"
        '
        'tbAttributeValue
        '
        Me.tbAttributeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbAttributeValue.Location = New System.Drawing.Point(70, 95)
        Me.tbAttributeValue.Name = "tbAttributeValue"
        Me.tbAttributeValue.Size = New System.Drawing.Size(113, 21)
        Me.tbAttributeValue.TabIndex = 20
        Me.tbAttributeValue.Text = "0"
        Me.tbAttributeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbAttributes
        '
        Me.cbAttributes.FormattingEnabled = True
        Me.cbAttributes.Location = New System.Drawing.Point(70, 62)
        Me.cbAttributes.Name = "cbAttributes"
        Me.cbAttributes.Size = New System.Drawing.Size(228, 23)
        Me.cbAttributes.TabIndex = 17
        Me.cbAttributes.Text = "ComboBox"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(15, 65)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(57, 15)
        Me.Label28.TabIndex = 16
        Me.Label28.Text = "Attribute :"
        '
        'tpParamRange
        '
        Me.tpParamRange.Controls.Add(Me.gbMDXSetting)
        Me.tpParamRange.Controls.Add(Me.gbAMXSetting)
        Me.tpParamRange.Controls.Add(Me.gbPMXSetting)
        Me.tpParamRange.Location = New System.Drawing.Point(4, 27)
        Me.tpParamRange.Name = "tpParamRange"
        Me.tpParamRange.Size = New System.Drawing.Size(751, 642)
        Me.tpParamRange.TabIndex = 5
        Me.tpParamRange.Text = "Parameter Range"
        Me.tpParamRange.UseVisualStyleBackColor = True
        '
        'gbMDXSetting
        '
        Me.gbMDXSetting.Location = New System.Drawing.Point(15, 353)
        Me.gbMDXSetting.Name = "gbMDXSetting"
        Me.gbMDXSetting.Size = New System.Drawing.Size(539, 146)
        Me.gbMDXSetting.TabIndex = 5
        Me.gbMDXSetting.TabStop = False
        Me.gbMDXSetting.Text = "Bias Settings(MDX)"
        Me.gbMDXSetting.Visible = False
        '
        'gbAMXSetting
        '
        Me.gbAMXSetting.Controls.Add(Me.Label35)
        Me.gbAMXSetting.Controls.Add(Me.Label42)
        Me.gbAMXSetting.Controls.Add(Me.Label45)
        Me.gbAMXSetting.Controls.Add(Me.Label47)
        Me.gbAMXSetting.Controls.Add(Me.Label48)
        Me.gbAMXSetting.Controls.Add(Me.Label49)
        Me.gbAMXSetting.Controls.Add(Me.Label50)
        Me.gbAMXSetting.Controls.Add(Me.Label51)
        Me.gbAMXSetting.Controls.Add(Me.Label52)
        Me.gbAMXSetting.Controls.Add(Me.txtHighSignal)
        Me.gbAMXSetting.Controls.Add(Me.txtHighSubPower)
        Me.gbAMXSetting.Controls.Add(Me.txtHighMainPower)
        Me.gbAMXSetting.Controls.Add(Me.txtLowSignal)
        Me.gbAMXSetting.Controls.Add(Me.txtLowSubPower)
        Me.gbAMXSetting.Controls.Add(Me.txtLowMainPower)
        Me.gbAMXSetting.Controls.Add(Me.Label53)
        Me.gbAMXSetting.Controls.Add(Me.Label54)
        Me.gbAMXSetting.Controls.Add(Me.Label55)
        Me.gbAMXSetting.Location = New System.Drawing.Point(15, 200)
        Me.gbAMXSetting.Name = "gbAMXSetting"
        Me.gbAMXSetting.Size = New System.Drawing.Size(539, 146)
        Me.gbAMXSetting.TabIndex = 4
        Me.gbAMXSetting.TabStop = False
        Me.gbAMXSetting.Text = "Bias Settings(AMX)"
        Me.gbAMXSetting.Visible = False
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label35.Location = New System.Drawing.Point(198, 99)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(24, 8)
        Me.Label35.TabIndex = 44
        Me.Label35.Text = "Max"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label42.Location = New System.Drawing.Point(107, 99)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(22, 8)
        Me.Label42.TabIndex = 44
        Me.Label42.Text = "Min"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label45.Location = New System.Drawing.Point(198, 69)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(24, 8)
        Me.Label45.TabIndex = 43
        Me.Label45.Text = "Max"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label47.Location = New System.Drawing.Point(198, 40)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(24, 8)
        Me.Label47.TabIndex = 42
        Me.Label47.Text = "Max"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label48.Location = New System.Drawing.Point(107, 69)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(22, 8)
        Me.Label48.TabIndex = 43
        Me.Label48.Text = "Min"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(286, 104)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(14, 15)
        Me.Label49.TabIndex = 32
        Me.Label49.Text = "V"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label50.Location = New System.Drawing.Point(107, 40)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(22, 8)
        Me.Label50.TabIndex = 42
        Me.Label50.Text = "Min"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(286, 75)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(14, 15)
        Me.Label51.TabIndex = 31
        Me.Label51.Text = "V"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(286, 46)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(14, 15)
        Me.Label52.TabIndex = 30
        Me.Label52.Text = "V"
        '
        'txtHighSignal
        '
        Me.txtHighSignal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHighSignal.Location = New System.Drawing.Point(223, 99)
        Me.txtHighSignal.Name = "txtHighSignal"
        Me.txtHighSignal.Size = New System.Drawing.Size(56, 21)
        Me.txtHighSignal.TabIndex = 27
        Me.txtHighSignal.Text = "0"
        Me.txtHighSignal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHighSubPower
        '
        Me.txtHighSubPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHighSubPower.Location = New System.Drawing.Point(223, 69)
        Me.txtHighSubPower.Name = "txtHighSubPower"
        Me.txtHighSubPower.Size = New System.Drawing.Size(56, 21)
        Me.txtHighSubPower.TabIndex = 28
        Me.txtHighSubPower.Text = "0"
        Me.txtHighSubPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHighMainPower
        '
        Me.txtHighMainPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHighMainPower.Location = New System.Drawing.Point(223, 40)
        Me.txtHighMainPower.Name = "txtHighMainPower"
        Me.txtHighMainPower.Size = New System.Drawing.Size(56, 21)
        Me.txtHighMainPower.TabIndex = 26
        Me.txtHighMainPower.Text = "0"
        Me.txtHighMainPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLowSignal
        '
        Me.txtLowSignal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLowSignal.Location = New System.Drawing.Point(131, 99)
        Me.txtLowSignal.Name = "txtLowSignal"
        Me.txtLowSignal.Size = New System.Drawing.Size(56, 21)
        Me.txtLowSignal.TabIndex = 16
        Me.txtLowSignal.Text = "0"
        Me.txtLowSignal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLowSubPower
        '
        Me.txtLowSubPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLowSubPower.Location = New System.Drawing.Point(131, 69)
        Me.txtLowSubPower.Name = "txtLowSubPower"
        Me.txtLowSubPower.Size = New System.Drawing.Size(56, 21)
        Me.txtLowSubPower.TabIndex = 17
        Me.txtLowSubPower.Text = "0"
        Me.txtLowSubPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLowMainPower
        '
        Me.txtLowMainPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLowMainPower.Location = New System.Drawing.Point(131, 40)
        Me.txtLowMainPower.Name = "txtLowMainPower"
        Me.txtLowMainPower.Size = New System.Drawing.Size(56, 21)
        Me.txtLowMainPower.TabIndex = 15
        Me.txtLowMainPower.Text = "0"
        Me.txtLowMainPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(33, 102)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(51, 15)
        Me.Label53.TabIndex = 13
        Me.Label53.Text = "Signal : "
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(6, 43)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(80, 15)
        Me.Label54.TabIndex = 11
        Me.Label54.Text = "Main Power : "
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(11, 73)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(76, 15)
        Me.Label55.TabIndex = 14
        Me.Label55.Text = "Sub Power : "
        '
        'gbPMXSetting
        '
        Me.gbPMXSetting.Controls.Add(Me.Label56)
        Me.gbPMXSetting.Controls.Add(Me.Label57)
        Me.gbPMXSetting.Controls.Add(Me.Label58)
        Me.gbPMXSetting.Controls.Add(Me.Label59)
        Me.gbPMXSetting.Controls.Add(Me.Label60)
        Me.gbPMXSetting.Controls.Add(Me.Label61)
        Me.gbPMXSetting.Controls.Add(Me.Label62)
        Me.gbPMXSetting.Controls.Add(Me.Label63)
        Me.gbPMXSetting.Controls.Add(Me.lblDutyPercent)
        Me.gbPMXSetting.Controls.Add(Me.lblFrequencyUnit)
        Me.gbPMXSetting.Controls.Add(Me.lblAmpUnit)
        Me.gbPMXSetting.Controls.Add(Me.lblValueUnit)
        Me.gbPMXSetting.Controls.Add(Me.txtHighDuty)
        Me.gbPMXSetting.Controls.Add(Me.txtHighFrequency)
        Me.gbPMXSetting.Controls.Add(Me.txtHighAmplitude)
        Me.gbPMXSetting.Controls.Add(Me.txtBiasHighValue)
        Me.gbPMXSetting.Controls.Add(Me.txtLowDuty)
        Me.gbPMXSetting.Controls.Add(Me.txtLowFrequency)
        Me.gbPMXSetting.Controls.Add(Me.txtLowAmplitude)
        Me.gbPMXSetting.Controls.Add(Me.Label64)
        Me.gbPMXSetting.Controls.Add(Me.txtBiasLowValue)
        Me.gbPMXSetting.Controls.Add(Me.Label65)
        Me.gbPMXSetting.Controls.Add(Me.Label66)
        Me.gbPMXSetting.Controls.Add(Me.Label67)
        Me.gbPMXSetting.Location = New System.Drawing.Point(15, 20)
        Me.gbPMXSetting.Name = "gbPMXSetting"
        Me.gbPMXSetting.Size = New System.Drawing.Size(539, 174)
        Me.gbPMXSetting.TabIndex = 3
        Me.gbPMXSetting.TabStop = False
        Me.gbPMXSetting.Text = "Bias Settings(PMX)"
        Me.gbPMXSetting.Visible = False
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label56.Location = New System.Drawing.Point(198, 128)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(24, 8)
        Me.Label56.TabIndex = 41
        Me.Label56.Text = "Max"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label57.Location = New System.Drawing.Point(198, 99)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(24, 8)
        Me.Label57.TabIndex = 40
        Me.Label57.Text = "Max"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label58.Location = New System.Drawing.Point(198, 69)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(24, 8)
        Me.Label58.TabIndex = 39
        Me.Label58.Text = "Max"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label59.Location = New System.Drawing.Point(198, 40)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(24, 8)
        Me.Label59.TabIndex = 38
        Me.Label59.Text = "Max"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label60.Location = New System.Drawing.Point(107, 128)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(22, 8)
        Me.Label60.TabIndex = 37
        Me.Label60.Text = "Min"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label61.Location = New System.Drawing.Point(107, 99)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(22, 8)
        Me.Label61.TabIndex = 36
        Me.Label61.Text = "Min"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label62.Location = New System.Drawing.Point(107, 69)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(22, 8)
        Me.Label62.TabIndex = 35
        Me.Label62.Text = "Min"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("굴림", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label63.Location = New System.Drawing.Point(107, 40)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(22, 8)
        Me.Label63.TabIndex = 34
        Me.Label63.Text = "Min"
        '
        'lblDutyPercent
        '
        Me.lblDutyPercent.AutoSize = True
        Me.lblDutyPercent.Location = New System.Drawing.Point(287, 133)
        Me.lblDutyPercent.Name = "lblDutyPercent"
        Me.lblDutyPercent.Size = New System.Drawing.Size(18, 15)
        Me.lblDutyPercent.TabIndex = 33
        Me.lblDutyPercent.Text = "%"
        '
        'lblFrequencyUnit
        '
        Me.lblFrequencyUnit.AutoSize = True
        Me.lblFrequencyUnit.Location = New System.Drawing.Point(287, 104)
        Me.lblFrequencyUnit.Name = "lblFrequencyUnit"
        Me.lblFrequencyUnit.Size = New System.Drawing.Size(21, 15)
        Me.lblFrequencyUnit.TabIndex = 32
        Me.lblFrequencyUnit.Text = "Hz"
        '
        'lblAmpUnit
        '
        Me.lblAmpUnit.AutoSize = True
        Me.lblAmpUnit.Location = New System.Drawing.Point(287, 75)
        Me.lblAmpUnit.Name = "lblAmpUnit"
        Me.lblAmpUnit.Size = New System.Drawing.Size(105, 15)
        Me.lblAmpUnit.TabIndex = 31
        Me.lblAmpUnit.Text = "Voltage or Current"
        '
        'lblValueUnit
        '
        Me.lblValueUnit.AutoSize = True
        Me.lblValueUnit.Location = New System.Drawing.Point(287, 46)
        Me.lblValueUnit.Name = "lblValueUnit"
        Me.lblValueUnit.Size = New System.Drawing.Size(105, 15)
        Me.lblValueUnit.TabIndex = 30
        Me.lblValueUnit.Text = "Voltage or Current"
        '
        'txtHighDuty
        '
        Me.txtHighDuty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHighDuty.Location = New System.Drawing.Point(224, 128)
        Me.txtHighDuty.Name = "txtHighDuty"
        Me.txtHighDuty.Size = New System.Drawing.Size(56, 21)
        Me.txtHighDuty.TabIndex = 29
        Me.txtHighDuty.Text = "0"
        Me.txtHighDuty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHighFrequency
        '
        Me.txtHighFrequency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHighFrequency.Location = New System.Drawing.Point(224, 99)
        Me.txtHighFrequency.Name = "txtHighFrequency"
        Me.txtHighFrequency.Size = New System.Drawing.Size(56, 21)
        Me.txtHighFrequency.TabIndex = 27
        Me.txtHighFrequency.Text = "0"
        Me.txtHighFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHighAmplitude
        '
        Me.txtHighAmplitude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHighAmplitude.Location = New System.Drawing.Point(224, 69)
        Me.txtHighAmplitude.Name = "txtHighAmplitude"
        Me.txtHighAmplitude.Size = New System.Drawing.Size(56, 21)
        Me.txtHighAmplitude.TabIndex = 28
        Me.txtHighAmplitude.Text = "0"
        Me.txtHighAmplitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBiasHighValue
        '
        Me.txtBiasHighValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBiasHighValue.Location = New System.Drawing.Point(224, 40)
        Me.txtBiasHighValue.Name = "txtBiasHighValue"
        Me.txtBiasHighValue.Size = New System.Drawing.Size(56, 21)
        Me.txtBiasHighValue.TabIndex = 26
        Me.txtBiasHighValue.Text = "0"
        Me.txtBiasHighValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLowDuty
        '
        Me.txtLowDuty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLowDuty.Location = New System.Drawing.Point(131, 128)
        Me.txtLowDuty.Name = "txtLowDuty"
        Me.txtLowDuty.Size = New System.Drawing.Size(56, 21)
        Me.txtLowDuty.TabIndex = 18
        Me.txtLowDuty.Text = "0"
        Me.txtLowDuty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLowFrequency
        '
        Me.txtLowFrequency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLowFrequency.Location = New System.Drawing.Point(131, 99)
        Me.txtLowFrequency.Name = "txtLowFrequency"
        Me.txtLowFrequency.Size = New System.Drawing.Size(56, 21)
        Me.txtLowFrequency.TabIndex = 16
        Me.txtLowFrequency.Text = "0"
        Me.txtLowFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLowAmplitude
        '
        Me.txtLowAmplitude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLowAmplitude.Location = New System.Drawing.Point(131, 69)
        Me.txtLowAmplitude.Name = "txtLowAmplitude"
        Me.txtLowAmplitude.Size = New System.Drawing.Size(56, 21)
        Me.txtLowAmplitude.TabIndex = 17
        Me.txtLowAmplitude.Text = "0"
        Me.txtLowAmplitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(32, 131)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(49, 15)
        Me.Label64.TabIndex = 12
        Me.Label64.Text = "    Duty :"
        '
        'txtBiasLowValue
        '
        Me.txtBiasLowValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBiasLowValue.Location = New System.Drawing.Point(131, 40)
        Me.txtBiasLowValue.Name = "txtBiasLowValue"
        Me.txtBiasLowValue.Size = New System.Drawing.Size(56, 21)
        Me.txtBiasLowValue.TabIndex = 15
        Me.txtBiasLowValue.Text = "0"
        Me.txtBiasLowValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(16, 102)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(70, 15)
        Me.Label65.TabIndex = 13
        Me.Label65.Text = "Frequency :"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(45, 43)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(38, 15)
        Me.Label66.TabIndex = 11
        Me.Label66.Text = "Bias :"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(22, 73)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(65, 15)
        Me.Label67.TabIndex = 14
        Me.Label67.Text = "Ampitude :"
        '
        'tpACF
        '
        Me.tpACF.Controls.Add(Me.grbACFPixelPerDistance)
        Me.tpACF.Controls.Add(Me.grbACFImageProcessingParam)
        Me.tpACF.Controls.Add(Me.grbACFOptions)
        Me.tpACF.Controls.Add(Me.grbACF)
        Me.tpACF.Location = New System.Drawing.Point(4, 27)
        Me.tpACF.Name = "tpACF"
        Me.tpACF.Size = New System.Drawing.Size(751, 642)
        Me.tpACF.TabIndex = 0
        Me.tpACF.Text = "AUTO Centering & Focusing"
        Me.tpACF.UseVisualStyleBackColor = True
        '
        'grbACFPixelPerDistance
        '
        Me.grbACFPixelPerDistance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbACFPixelPerDistance.Controls.Add(Me.Label13)
        Me.grbACFPixelPerDistance.Controls.Add(Me.tbPixelPerDistance_Hight)
        Me.grbACFPixelPerDistance.Controls.Add(Me.Label12)
        Me.grbACFPixelPerDistance.Controls.Add(Me.tbPixelPerDistance_Width)
        Me.grbACFPixelPerDistance.Location = New System.Drawing.Point(12, 277)
        Me.grbACFPixelPerDistance.Name = "grbACFPixelPerDistance"
        Me.grbACFPixelPerDistance.Size = New System.Drawing.Size(620, 54)
        Me.grbACFPixelPerDistance.TabIndex = 2
        Me.grbACFPixelPerDistance.TabStop = False
        Me.grbACFPixelPerDistance.Text = "Convert Param"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(310, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(183, 15)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Pixel per distance(1mm)_Hight :"
        '
        'tbPixelPerDistance_Hight
        '
        Me.tbPixelPerDistance_Hight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPixelPerDistance_Hight.Location = New System.Drawing.Point(498, 24)
        Me.tbPixelPerDistance_Hight.Name = "tbPixelPerDistance_Hight"
        Me.tbPixelPerDistance_Hight.Size = New System.Drawing.Size(83, 21)
        Me.tbPixelPerDistance_Hight.TabIndex = 15
        Me.tbPixelPerDistance_Hight.Text = "0"
        Me.tbPixelPerDistance_Hight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(23, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(185, 15)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Pixel per distance(1mm)_Width :"
        '
        'tbPixelPerDistance_Width
        '
        Me.tbPixelPerDistance_Width.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPixelPerDistance_Width.Location = New System.Drawing.Point(211, 21)
        Me.tbPixelPerDistance_Width.Name = "tbPixelPerDistance_Width"
        Me.tbPixelPerDistance_Width.Size = New System.Drawing.Size(79, 21)
        Me.tbPixelPerDistance_Width.TabIndex = 13
        Me.tbPixelPerDistance_Width.Text = "0"
        Me.tbPixelPerDistance_Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grbACFImageProcessingParam
        '
        Me.grbACFImageProcessingParam.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbACFImageProcessingParam.Controls.Add(Me.GroupBox5)
        Me.grbACFImageProcessingParam.Controls.Add(Me.GroupBox2)
        Me.grbACFImageProcessingParam.Controls.Add(Me.GroupBox1)
        Me.grbACFImageProcessingParam.Location = New System.Drawing.Point(12, 108)
        Me.grbACFImageProcessingParam.Name = "grbACFImageProcessingParam"
        Me.grbACFImageProcessingParam.Size = New System.Drawing.Size(620, 169)
        Me.grbACFImageProcessingParam.TabIndex = 1
        Me.grbACFImageProcessingParam.TabStop = False
        Me.grbACFImageProcessingParam.Text = "Image Processing Param"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.cbBlobFilter)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.tbGrayLevelLimit)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.tbLowIntensityLimit)
        Me.GroupBox5.Location = New System.Drawing.Point(290, 79)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(315, 83)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Filter"
        '
        'cbBlobFilter
        '
        Me.cbBlobFilter.FormattingEnabled = True
        Me.cbBlobFilter.Items.AddRange(New Object() {"EXCLUDE_AREA_LESS_EQUAL_50", "EXCLUDE_AREA_OUT_RANGE_50_50000", "EXCLUDE_COMPACTNESS_LESS_EQUAL_1_5", "EXCLUDE_AREA_OUT_RANGE_1000_50000"})
        Me.cbBlobFilter.Location = New System.Drawing.Point(88, 46)
        Me.cbBlobFilter.Name = "cbBlobFilter"
        Me.cbBlobFilter.Size = New System.Drawing.Size(227, 23)
        Me.cbBlobFilter.TabIndex = 13
        Me.cbBlobFilter.Text = "ComboBox"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(170, 20)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 15)
        Me.Label20.TabIndex = 12
        Me.Label20.Text = "Gray Level limit :"
        '
        'tbGrayLevelLimit
        '
        Me.tbGrayLevelLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbGrayLevelLimit.Location = New System.Drawing.Point(268, 16)
        Me.tbGrayLevelLimit.Name = "tbGrayLevelLimit"
        Me.tbGrayLevelLimit.Size = New System.Drawing.Size(45, 21)
        Me.tbGrayLevelLimit.TabIndex = 13
        Me.tbGrayLevelLimit.Text = "0"
        Me.tbGrayLevelLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 15)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Blob Filter :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(10, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(110, 15)
        Me.Label19.TabIndex = 10
        Me.Label19.Text = "Low intensity limit :"
        '
        'tbLowIntensityLimit
        '
        Me.tbLowIntensityLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbLowIntensityLimit.Location = New System.Drawing.Point(120, 15)
        Me.tbLowIntensityLimit.Name = "tbLowIntensityLimit"
        Me.tbLowIntensityLimit.Size = New System.Drawing.Size(42, 21)
        Me.tbLowIntensityLimit.TabIndex = 11
        Me.tbLowIntensityLimit.Text = "0"
        Me.tbLowIntensityLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbCCDHigh)
        Me.GroupBox2.Controls.Add(Me.Label08)
        Me.GroupBox2.Controls.Add(Me.Label09)
        Me.GroupBox2.Controls.Add(Me.tbCCDWidth)
        Me.GroupBox2.Location = New System.Drawing.Point(290, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(302, 54)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CCD Resolution"
        '
        'tbCCDHigh
        '
        Me.tbCCDHigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCCDHigh.Location = New System.Drawing.Point(232, 20)
        Me.tbCCDHigh.Name = "tbCCDHigh"
        Me.tbCCDHigh.Size = New System.Drawing.Size(56, 21)
        Me.tbCCDHigh.TabIndex = 11
        Me.tbCCDHigh.Text = "0"
        Me.tbCCDHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label08
        '
        Me.Label08.AutoSize = True
        Me.Label08.Location = New System.Drawing.Point(8, 23)
        Me.Label08.Name = "Label08"
        Me.Label08.Size = New System.Drawing.Size(78, 15)
        Me.Label08.TabIndex = 8
        Me.Label08.Text = "Width(Pixel) :"
        '
        'Label09
        '
        Me.Label09.AutoSize = True
        Me.Label09.Location = New System.Drawing.Point(154, 23)
        Me.Label09.Name = "Label09"
        Me.Label09.Size = New System.Drawing.Size(76, 15)
        Me.Label09.TabIndex = 10
        Me.Label09.Text = "Hight(Pixel) :"
        '
        'tbCCDWidth
        '
        Me.tbCCDWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCCDWidth.Location = New System.Drawing.Point(88, 20)
        Me.tbCCDWidth.Name = "tbCCDWidth"
        Me.tbCCDWidth.Size = New System.Drawing.Size(58, 21)
        Me.tbCCDWidth.TabIndex = 9
        Me.tbCCDWidth.Text = "0"
        Me.tbCCDWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbHighThresholdVal)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.tbMinBlobRadius)
        Me.GroupBox1.Controls.Add(Me.Label07)
        Me.GroupBox1.Controls.Add(Me.tbLowThresholdVal)
        Me.GroupBox1.Controls.Add(Me.Label06)
        Me.GroupBox1.Controls.Add(Me.tbThreshold)
        Me.GroupBox1.Controls.Add(Me.Label05)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(275, 144)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Threshold Value(Gray Scale)"
        '
        'tbHighThresholdVal
        '
        Me.tbHighThresholdVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbHighThresholdVal.Location = New System.Drawing.Point(188, 80)
        Me.tbHighThresholdVal.Name = "tbHighThresholdVal"
        Me.tbHighThresholdVal.Size = New System.Drawing.Size(74, 21)
        Me.tbHighThresholdVal.TabIndex = 11
        Me.tbHighThresholdVal.Text = "0"
        Me.tbHighThresholdVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(80, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 15)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Min Blob Radius :"
        '
        'tbMinBlobRadius
        '
        Me.tbMinBlobRadius.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbMinBlobRadius.Location = New System.Drawing.Point(188, 109)
        Me.tbMinBlobRadius.Name = "tbMinBlobRadius"
        Me.tbMinBlobRadius.Size = New System.Drawing.Size(74, 21)
        Me.tbMinBlobRadius.TabIndex = 11
        Me.tbMinBlobRadius.Text = "0"
        Me.tbMinBlobRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label07
        '
        Me.Label07.AutoSize = True
        Me.Label07.Location = New System.Drawing.Point(7, 83)
        Me.Label07.Name = "Label07"
        Me.Label07.Size = New System.Drawing.Size(179, 15)
        Me.Label07.TabIndex = 10
        Me.Label07.Text = "High Intensity Threshold Value :"
        '
        'tbLowThresholdVal
        '
        Me.tbLowThresholdVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbLowThresholdVal.Location = New System.Drawing.Point(188, 52)
        Me.tbLowThresholdVal.Name = "tbLowThresholdVal"
        Me.tbLowThresholdVal.Size = New System.Drawing.Size(74, 21)
        Me.tbLowThresholdVal.TabIndex = 9
        Me.tbLowThresholdVal.Text = "0"
        Me.tbLowThresholdVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label06
        '
        Me.Label06.AutoSize = True
        Me.Label06.Location = New System.Drawing.Point(9, 52)
        Me.Label06.Name = "Label06"
        Me.Label06.Size = New System.Drawing.Size(176, 15)
        Me.Label06.TabIndex = 8
        Me.Label06.Text = "Low Intensity Threshold Value :"
        '
        'tbThreshold
        '
        Me.tbThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbThreshold.Location = New System.Drawing.Point(188, 23)
        Me.tbThreshold.Name = "tbThreshold"
        Me.tbThreshold.Size = New System.Drawing.Size(74, 21)
        Me.tbThreshold.TabIndex = 7
        Me.tbThreshold.Text = "0"
        Me.tbThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label05
        '
        Me.Label05.AutoSize = True
        Me.Label05.Location = New System.Drawing.Point(39, 26)
        Me.Label05.Name = "Label05"
        Me.Label05.Size = New System.Drawing.Size(144, 15)
        Me.Label05.TabIndex = 6
        Me.Label05.Text = "Default Threshold Value :"
        '
        'grbACFOptions
        '
        Me.grbACFOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbACFOptions.Controls.Add(Me.cbSelACFMode)
        Me.grbACFOptions.Controls.Add(Me.Label5)
        Me.grbACFOptions.Controls.Add(Me.tbFocusParam)
        Me.grbACFOptions.Controls.Add(Me.Label04)
        Me.grbACFOptions.Controls.Add(Me.tbScanResolution)
        Me.grbACFOptions.Controls.Add(Me.Label03)
        Me.grbACFOptions.Controls.Add(Me.tbScanRegion_Stop)
        Me.grbACFOptions.Controls.Add(Me.Label02)
        Me.grbACFOptions.Controls.Add(Me.tbScanRegion_Start)
        Me.grbACFOptions.Controls.Add(Me.Label01)
        Me.grbACFOptions.Location = New System.Drawing.Point(12, 21)
        Me.grbACFOptions.Name = "grbACFOptions"
        Me.grbACFOptions.Size = New System.Drawing.Size(620, 85)
        Me.grbACFOptions.TabIndex = 0
        Me.grbACFOptions.TabStop = False
        Me.grbACFOptions.Text = "Auto Focusing & Centering Options"
        Me.grbACFOptions.Visible = False
        '
        'cbSelACFMode
        '
        Me.cbSelACFMode.FormattingEnabled = True
        Me.cbSelACFMode.Location = New System.Drawing.Point(414, 18)
        Me.cbSelACFMode.Name = "cbSelACFMode"
        Me.cbSelACFMode.Size = New System.Drawing.Size(183, 23)
        Me.cbSelACFMode.TabIndex = 14
        Me.cbSelACFMode.Text = "ComboBox"
        Me.cbSelACFMode.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(344, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "ACF Mode :"
        Me.Label5.Visible = False
        '
        'tbFocusParam
        '
        Me.tbFocusParam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbFocusParam.Location = New System.Drawing.Point(485, 57)
        Me.tbFocusParam.Name = "tbFocusParam"
        Me.tbFocusParam.Size = New System.Drawing.Size(77, 21)
        Me.tbFocusParam.TabIndex = 7
        Me.tbFocusParam.Text = "0"
        Me.tbFocusParam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label04
        '
        Me.Label04.AutoSize = True
        Me.Label04.Location = New System.Drawing.Point(339, 61)
        Me.Label04.Name = "Label04"
        Me.Label04.Size = New System.Drawing.Size(146, 15)
        Me.Label04.TabIndex = 6
        Me.Label04.Text = "Focusing Distance(mm) :"
        '
        'tbScanResolution
        '
        Me.tbScanResolution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbScanResolution.Location = New System.Drawing.Point(197, 55)
        Me.tbScanResolution.Name = "tbScanResolution"
        Me.tbScanResolution.Size = New System.Drawing.Size(52, 21)
        Me.tbScanResolution.TabIndex = 5
        Me.tbScanResolution.Text = "0"
        Me.tbScanResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label03
        '
        Me.Label03.AutoSize = True
        Me.Label03.Location = New System.Drawing.Point(8, 57)
        Me.Label03.Name = "Label03"
        Me.Label03.Size = New System.Drawing.Size(188, 15)
        Me.Label03.TabIndex = 4
        Me.Label03.Text = "Focusing Scan Resolution(mm) :"
        '
        'tbScanRegion_Stop
        '
        Me.tbScanRegion_Stop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbScanRegion_Stop.Location = New System.Drawing.Point(272, 21)
        Me.tbScanRegion_Stop.Name = "tbScanRegion_Stop"
        Me.tbScanRegion_Stop.Size = New System.Drawing.Size(55, 21)
        Me.tbScanRegion_Stop.TabIndex = 3
        Me.tbScanRegion_Stop.Text = "0"
        Me.tbScanRegion_Stop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label02
        '
        Me.Label02.AutoSize = True
        Me.Label02.Location = New System.Drawing.Point(254, 24)
        Me.Label02.Name = "Label02"
        Me.Label02.Size = New System.Drawing.Size(14, 15)
        Me.Label02.TabIndex = 2
        Me.Label02.Text = "~"
        '
        'tbScanRegion_Start
        '
        Me.tbScanRegion_Start.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbScanRegion_Start.Location = New System.Drawing.Point(197, 21)
        Me.tbScanRegion_Start.Name = "tbScanRegion_Start"
        Me.tbScanRegion_Start.Size = New System.Drawing.Size(52, 21)
        Me.tbScanRegion_Start.TabIndex = 1
        Me.tbScanRegion_Start.Text = "0"
        Me.tbScanRegion_Start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label01
        '
        Me.Label01.AutoSize = True
        Me.Label01.Location = New System.Drawing.Point(25, 24)
        Me.Label01.Name = "Label01"
        Me.Label01.Size = New System.Drawing.Size(168, 15)
        Me.Label01.TabIndex = 0
        Me.Label01.Text = "Focusing Scan Region(mm) :"
        '
        'grbACF
        '
        Me.grbACF.Controls.Add(Me.btnIntensityAdj_SrcSettings)
        Me.grbACF.Controls.Add(Me.GroupBox7)
        Me.grbACF.Controls.Add(Me.GroupBox17)
        Me.grbACF.Location = New System.Drawing.Point(3, 3)
        Me.grbACF.Name = "grbACF"
        Me.grbACF.Size = New System.Drawing.Size(698, 573)
        Me.grbACF.TabIndex = 7
        Me.grbACF.TabStop = False
        Me.grbACF.Text = "ACF"
        '
        'btnIntensityAdj_SrcSettings
        '
        Me.btnIntensityAdj_SrcSettings.Location = New System.Drawing.Point(19, 454)
        Me.btnIntensityAdj_SrcSettings.Name = "btnIntensityAdj_SrcSettings"
        Me.btnIntensityAdj_SrcSettings.Size = New System.Drawing.Size(60, 28)
        Me.btnIntensityAdj_SrcSettings.TabIndex = 25
        Me.btnIntensityAdj_SrcSettings.Text = "Settings"
        Me.btnIntensityAdj_SrcSettings.UseVisualStyleBackColor = True
        Me.btnIntensityAdj_SrcSettings.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.lbACFStopUnit)
        Me.GroupBox7.Controls.Add(Me.lbACFStepUnit)
        Me.GroupBox7.Controls.Add(Me.lbACFStartUnit)
        Me.GroupBox7.Controls.Add(Me.cbACFSrcMode)
        Me.GroupBox7.Controls.Add(Me.Label84)
        Me.GroupBox7.Controls.Add(Me.Label4)
        Me.GroupBox7.Controls.Add(Me.tbIntesityAdj_Step)
        Me.GroupBox7.Controls.Add(Me.Label2)
        Me.GroupBox7.Controls.Add(Me.tbIntesityAdj_Limit)
        Me.GroupBox7.Controls.Add(Me.Label3)
        Me.GroupBox7.Controls.Add(Me.tbIntesityAdj_Start)
        Me.GroupBox7.Location = New System.Drawing.Point(9, 335)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(227, 147)
        Me.GroupBox7.TabIndex = 5
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Cell Intensity Adjust"
        Me.GroupBox7.Visible = False
        '
        'lbACFStopUnit
        '
        Me.lbACFStopUnit.AutoSize = True
        Me.lbACFStopUnit.Location = New System.Drawing.Point(137, 102)
        Me.lbACFStopUnit.Name = "lbACFStopUnit"
        Me.lbACFStopUnit.Size = New System.Drawing.Size(14, 15)
        Me.lbACFStopUnit.TabIndex = 29
        Me.lbACFStopUnit.Text = "V"
        '
        'lbACFStepUnit
        '
        Me.lbACFStepUnit.AutoSize = True
        Me.lbACFStepUnit.Location = New System.Drawing.Point(137, 76)
        Me.lbACFStepUnit.Name = "lbACFStepUnit"
        Me.lbACFStepUnit.Size = New System.Drawing.Size(14, 15)
        Me.lbACFStepUnit.TabIndex = 28
        Me.lbACFStepUnit.Text = "V"
        '
        'lbACFStartUnit
        '
        Me.lbACFStartUnit.AutoSize = True
        Me.lbACFStartUnit.Location = New System.Drawing.Point(137, 49)
        Me.lbACFStartUnit.Name = "lbACFStartUnit"
        Me.lbACFStartUnit.Size = New System.Drawing.Size(14, 15)
        Me.lbACFStartUnit.TabIndex = 27
        Me.lbACFStartUnit.Text = "V"
        '
        'cbACFSrcMode
        '
        Me.cbACFSrcMode.FormattingEnabled = True
        Me.cbACFSrcMode.Location = New System.Drawing.Point(78, 17)
        Me.cbACFSrcMode.Name = "cbACFSrcMode"
        Me.cbACFSrcMode.Size = New System.Drawing.Size(58, 23)
        Me.cbACFSrcMode.TabIndex = 26
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Location = New System.Drawing.Point(30, 20)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(43, 15)
        Me.Label84.TabIndex = 16
        Me.Label84.Text = "Mode: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Step Bias :"
        '
        'tbIntesityAdj_Step
        '
        Me.tbIntesityAdj_Step.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbIntesityAdj_Step.Location = New System.Drawing.Point(78, 71)
        Me.tbIntesityAdj_Step.Name = "tbIntesityAdj_Step"
        Me.tbIntesityAdj_Step.Size = New System.Drawing.Size(58, 21)
        Me.tbIntesityAdj_Step.TabIndex = 15
        Me.tbIntesityAdj_Step.Text = "0"
        Me.tbIntesityAdj_Step.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "limit :"
        '
        'tbIntesityAdj_Limit
        '
        Me.tbIntesityAdj_Limit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbIntesityAdj_Limit.Location = New System.Drawing.Point(78, 98)
        Me.tbIntesityAdj_Limit.Name = "tbIntesityAdj_Limit"
        Me.tbIntesityAdj_Limit.Size = New System.Drawing.Size(58, 21)
        Me.tbIntesityAdj_Limit.TabIndex = 13
        Me.tbIntesityAdj_Limit.Text = "0"
        Me.tbIntesityAdj_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Start Bias :"
        '
        'tbIntesityAdj_Start
        '
        Me.tbIntesityAdj_Start.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbIntesityAdj_Start.Location = New System.Drawing.Point(78, 44)
        Me.tbIntesityAdj_Start.Name = "tbIntesityAdj_Start"
        Me.tbIntesityAdj_Start.Size = New System.Drawing.Size(58, 21)
        Me.tbIntesityAdj_Start.TabIndex = 11
        Me.tbIntesityAdj_Start.Text = "0"
        Me.tbIntesityAdj_Start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.tbMdlPatternNo)
        Me.GroupBox17.Controls.Add(Me.Label7)
        Me.GroupBox17.Location = New System.Drawing.Point(257, 335)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(162, 107)
        Me.GroupBox17.TabIndex = 6
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "Module Pattern"
        Me.GroupBox17.Visible = False
        '
        'tbMdlPatternNo
        '
        Me.tbMdlPatternNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbMdlPatternNo.Location = New System.Drawing.Point(87, 18)
        Me.tbMdlPatternNo.Name = "tbMdlPatternNo"
        Me.tbMdlPatternNo.Size = New System.Drawing.Size(63, 21)
        Me.tbMdlPatternNo.TabIndex = 12
        Me.tbMdlPatternNo.Text = "0"
        Me.tbMdlPatternNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 15)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Pattern No. :"
        '
        'tpLink
        '
        Me.tpLink.Controls.Add(Me.GroupBox8)
        Me.tpLink.Controls.Add(Me.GroupBox18)
        Me.tpLink.Location = New System.Drawing.Point(4, 27)
        Me.tpLink.Name = "tpLink"
        Me.tpLink.Size = New System.Drawing.Size(751, 642)
        Me.tpLink.TabIndex = 8
        Me.tpLink.Text = "Link"
        Me.tpLink.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.chkEnableDataViewerLink_LT)
        Me.GroupBox8.Controls.Add(Me.Label6)
        Me.GroupBox8.Controls.Add(Me.btnFindPathOfDataViewer_LT)
        Me.GroupBox8.Controls.Add(Me.tbPathOfDataViewer_LT)
        Me.GroupBox8.Location = New System.Drawing.Point(13, 134)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(583, 86)
        Me.GroupBox8.TabIndex = 3
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Lifetime Data Viewer"
        Me.GroupBox8.Visible = False
        '
        'chkEnableDataViewerLink_LT
        '
        Me.chkEnableDataViewerLink_LT.AutoSize = True
        Me.chkEnableDataViewerLink_LT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkEnableDataViewerLink_LT.Location = New System.Drawing.Point(22, 22)
        Me.chkEnableDataViewerLink_LT.Name = "chkEnableDataViewerLink_LT"
        Me.chkEnableDataViewerLink_LT.Size = New System.Drawing.Size(149, 19)
        Me.chkEnableDataViewerLink_LT.TabIndex = 3
        Me.chkEnableDataViewerLink_LT.Text = "Enable data viewer link"
        Me.chkEnableDataViewerLink_LT.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Path :"
        '
        'btnFindPathOfDataViewer_LT
        '
        Me.btnFindPathOfDataViewer_LT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindPathOfDataViewer_LT.Location = New System.Drawing.Point(505, 46)
        Me.btnFindPathOfDataViewer_LT.Name = "btnFindPathOfDataViewer_LT"
        Me.btnFindPathOfDataViewer_LT.Size = New System.Drawing.Size(64, 28)
        Me.btnFindPathOfDataViewer_LT.TabIndex = 1
        Me.btnFindPathOfDataViewer_LT.Text = "Find..."
        Me.btnFindPathOfDataViewer_LT.UseVisualStyleBackColor = True
        '
        'tbPathOfDataViewer_LT
        '
        Me.tbPathOfDataViewer_LT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPathOfDataViewer_LT.Location = New System.Drawing.Point(50, 49)
        Me.tbPathOfDataViewer_LT.Name = "tbPathOfDataViewer_LT"
        Me.tbPathOfDataViewer_LT.Size = New System.Drawing.Size(451, 21)
        Me.tbPathOfDataViewer_LT.TabIndex = 0
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.chkEnableDataViewerLink_IVL)
        Me.GroupBox18.Controls.Add(Me.Label81)
        Me.GroupBox18.Controls.Add(Me.btnFindPathOfDataViewer_IVL)
        Me.GroupBox18.Controls.Add(Me.tbPathOfDataViewer_IVL)
        Me.GroupBox18.Location = New System.Drawing.Point(13, 21)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(583, 86)
        Me.GroupBox18.TabIndex = 2
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "IVL Data Viewer"
        Me.GroupBox18.Visible = False
        '
        'chkEnableDataViewerLink_IVL
        '
        Me.chkEnableDataViewerLink_IVL.AutoSize = True
        Me.chkEnableDataViewerLink_IVL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkEnableDataViewerLink_IVL.Location = New System.Drawing.Point(22, 22)
        Me.chkEnableDataViewerLink_IVL.Name = "chkEnableDataViewerLink_IVL"
        Me.chkEnableDataViewerLink_IVL.Size = New System.Drawing.Size(149, 19)
        Me.chkEnableDataViewerLink_IVL.TabIndex = 3
        Me.chkEnableDataViewerLink_IVL.Text = "Enable data viewer link"
        Me.chkEnableDataViewerLink_IVL.UseVisualStyleBackColor = True
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(12, 51)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(38, 15)
        Me.Label81.TabIndex = 2
        Me.Label81.Text = "Path :"
        '
        'btnFindPathOfDataViewer_IVL
        '
        Me.btnFindPathOfDataViewer_IVL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindPathOfDataViewer_IVL.Location = New System.Drawing.Point(505, 46)
        Me.btnFindPathOfDataViewer_IVL.Name = "btnFindPathOfDataViewer_IVL"
        Me.btnFindPathOfDataViewer_IVL.Size = New System.Drawing.Size(64, 28)
        Me.btnFindPathOfDataViewer_IVL.TabIndex = 1
        Me.btnFindPathOfDataViewer_IVL.Text = "Find..."
        Me.btnFindPathOfDataViewer_IVL.UseVisualStyleBackColor = True
        '
        'tbPathOfDataViewer_IVL
        '
        Me.tbPathOfDataViewer_IVL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPathOfDataViewer_IVL.Location = New System.Drawing.Point(50, 49)
        Me.tbPathOfDataViewer_IVL.Name = "tbPathOfDataViewer_IVL"
        Me.tbPathOfDataViewer_IVL.Size = New System.Drawing.Size(451, 21)
        Me.tbPathOfDataViewer_IVL.TabIndex = 0
        '
        'btnOptionSave
        '
        Me.btnOptionSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOptionSave.Location = New System.Drawing.Point(364, 694)
        Me.btnOptionSave.Name = "btnOptionSave"
        Me.btnOptionSave.Size = New System.Drawing.Size(70, 38)
        Me.btnOptionSave.TabIndex = 23
        Me.btnOptionSave.Text = "Save"
        Me.btnOptionSave.UseVisualStyleBackColor = True
        Me.btnOptionSave.Visible = False
        '
        'btnOptionLoad
        '
        Me.btnOptionLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOptionLoad.Location = New System.Drawing.Point(440, 694)
        Me.btnOptionLoad.Name = "btnOptionLoad"
        Me.btnOptionLoad.Size = New System.Drawing.Size(70, 38)
        Me.btnOptionLoad.TabIndex = 24
        Me.btnOptionLoad.Text = "Load"
        Me.btnOptionLoad.UseVisualStyleBackColor = True
        Me.btnOptionLoad.Visible = False
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Location = New System.Drawing.Point(627, 691)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(70, 38)
        Me.btnOk.TabIndex = 25
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(702, 691)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 38)
        Me.btnCancel.TabIndex = 26
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmOptionWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(778, 734)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnOptionLoad)
        Me.Controls.Add(Me.btnOptionSave)
        Me.Controls.Add(Me.tcOptions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmOptionWindow"
        Me.Text = "Option Windows"
        Me.tcOptions.ResumeLayout(False)
        Me.tpSave.ResumeLayout(False)
        Me.GroupBox27.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox24.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox23.ResumeLayout(False)
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout
        Me.GroupBox19.ResumeLayout(false)
        Me.GroupBox19.PerformLayout
        Me.GroupBox9.ResumeLayout(false)
        Me.GroupBox9.PerformLayout
        Me.tpMotion.ResumeLayout(false)
        Me.GroupBox4.ResumeLayout(false)
        Me.GroupBox4.PerformLayout
        Me.GroupBox31.ResumeLayout(false)
        Me.GroupBox31.PerformLayout
        Me.GroupBox28.ResumeLayout(false)
        Me.GroupBox28.PerformLayout
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        Me.GroupBox11.ResumeLayout(false)
        Me.GroupBox14.ResumeLayout(false)
        Me.GroupBox14.PerformLayout
        Me.GroupBox12.ResumeLayout(false)
        Me.GroupBox12.PerformLayout
        Me.tpTemp.ResumeLayout(false)
        Me.GroupBox22.ResumeLayout(false)
        Me.GroupBox26.ResumeLayout(false)
        Me.GroupBox26.PerformLayout
        Me.GroupBox25.ResumeLayout(false)
        Me.GroupBox25.PerformLayout
        Me.GroupBox6.ResumeLayout(false)
        Me.GroupBox6.PerformLayout
        Me.tpDisplay.ResumeLayout(false)
        Me.tpDisplay.PerformLayout
        Me.gbSampleInfos.ResumeLayout(false)
        Me.gbSampleInfos.PerformLayout
        Me.GroupBox21.ResumeLayout(false)
        Me.GroupBox21.PerformLayout
        Me.GroupBox16.ResumeLayout(false)
        Me.GroupBox16.PerformLayout
        Me.gnNumOfOutdataDsipMDX.ResumeLayout(false)
        Me.gnNumOfOutdataDsipMDX.PerformLayout
        Me.GroupBox15.ResumeLayout(false)
        Me.GroupBox15.PerformLayout
        Me.tpStatusColor.ResumeLayout(false)
        Me.GroupBox13.ResumeLayout(false)
        Me.tpCCD.ResumeLayout(false)
        Me.tpCCD.PerformLayout
        Me.GroupBox32.ResumeLayout(false)
        Me.GroupBox32.PerformLayout
        Me.GroupBox10.ResumeLayout(false)
        Me.GroupBox10.PerformLayout
        Me.tpParamRange.ResumeLayout(false)
        Me.gbAMXSetting.ResumeLayout(false)
        Me.gbAMXSetting.PerformLayout
        Me.gbPMXSetting.ResumeLayout(false)
        Me.gbPMXSetting.PerformLayout
        Me.tpACF.ResumeLayout(false)
        Me.grbACFPixelPerDistance.ResumeLayout(false)
        Me.grbACFPixelPerDistance.PerformLayout
        Me.grbACFImageProcessingParam.ResumeLayout(false)
        Me.GroupBox5.ResumeLayout(false)
        Me.GroupBox5.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.grbACFOptions.ResumeLayout(false)
        Me.grbACFOptions.PerformLayout
        Me.grbACF.ResumeLayout(false)
        Me.GroupBox7.ResumeLayout(false)
        Me.GroupBox7.PerformLayout
        Me.GroupBox17.ResumeLayout(false)
        Me.GroupBox17.PerformLayout
        Me.tpLink.ResumeLayout(false)
        Me.GroupBox8.ResumeLayout(false)
        Me.GroupBox8.PerformLayout
        Me.GroupBox18.ResumeLayout(false)
        Me.GroupBox18.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents tcOptions As System.Windows.Forms.TabControl
    Friend WithEvents tpACF As System.Windows.Forms.TabPage
    Friend WithEvents tpMotion As System.Windows.Forms.TabPage
    Friend WithEvents tpCCD As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents grbACFPixelPerDistance As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbPixelPerDistance_Hight As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbPixelPerDistance_Width As System.Windows.Forms.TextBox
    Friend WithEvents grbACFImageProcessingParam As System.Windows.Forms.GroupBox
    Friend WithEvents cbBlobFilter As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbMinBlobRadius As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tbCCDHigh As System.Windows.Forms.TextBox
    Friend WithEvents Label08 As System.Windows.Forms.Label
    Friend WithEvents Label09 As System.Windows.Forms.Label
    Friend WithEvents tbCCDWidth As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbHighThresholdVal As System.Windows.Forms.TextBox
    Friend WithEvents Label07 As System.Windows.Forms.Label
    Friend WithEvents tbLowThresholdVal As System.Windows.Forms.TextBox
    Friend WithEvents Label06 As System.Windows.Forms.Label
    Friend WithEvents tbThreshold As System.Windows.Forms.TextBox
    Friend WithEvents Label05 As System.Windows.Forms.Label
    Friend WithEvents grbACFOptions As System.Windows.Forms.GroupBox
    Friend WithEvents tbFocusParam As System.Windows.Forms.TextBox
    Friend WithEvents Label04 As System.Windows.Forms.Label
    Friend WithEvents tbScanResolution As System.Windows.Forms.TextBox
    Friend WithEvents Label03 As System.Windows.Forms.Label
    Friend WithEvents tbScanRegion_Stop As System.Windows.Forms.TextBox
    Friend WithEvents Label02 As System.Windows.Forms.Label
    Friend WithEvents tbScanRegion_Start As System.Windows.Forms.TextBox
    Friend WithEvents Label01 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tbGrayLevelLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tbLowIntensityLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents tbCCDExposureValue As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGetCCDValRange As System.Windows.Forms.Button
    Friend WithEvents btnSetCCDAttribute As System.Windows.Forms.Button
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents tbAttributeValue As System.Windows.Forms.TextBox
    Friend WithEvents cbAttributes As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents btnOptionSave As System.Windows.Forms.Button
    Friend WithEvents btnOptionLoad As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMotionPos_Y As System.Windows.Forms.Label
    Friend WithEvents lblMotionPos_X As System.Windows.Forms.Label
    Friend WithEvents btnCalPosPerDistance As System.Windows.Forms.Button
    Friend WithEvents btnGetEndPos As System.Windows.Forms.Button
    Friend WithEvents btnGetStartPos As System.Windows.Forms.Button
    Friend WithEvents tbCalPos_Y As System.Windows.Forms.TextBox
    Friend WithEvents tbEndPos_Y As System.Windows.Forms.TextBox
    Friend WithEvents tbStartPos_Y As System.Windows.Forms.TextBox
    Friend WithEvents tbCalPos_X As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents tbEndPos_X As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents tbStartPos_X As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDistance_Y As System.Windows.Forms.Label
    Friend WithEvents lblDistance_X As System.Windows.Forms.Label
    Friend WithEvents btnSetDistance As System.Windows.Forms.Button
    Friend WithEvents tbDistance_Y As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents tbDistance_X As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents tbPosPerDistance_Y As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents tbPosPerDistance_X As System.Windows.Forms.TextBox
    Friend WithEvents chkCalPosPerDistance As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents tpStatusColor As System.Windows.Forms.TabPage
    Friend WithEvents ucDispFontColorList As M7000.ucDispListView
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents btnColorAdd As System.Windows.Forms.Button
    Friend WithEvents btnColorDel As System.Windows.Forms.Button
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lbColor As System.Windows.Forms.Label
    Friend WithEvents tpParamRange As System.Windows.Forms.TabPage
    Friend WithEvents gbMDXSetting As System.Windows.Forms.GroupBox
    Friend WithEvents gbAMXSetting As System.Windows.Forms.GroupBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtHighSignal As System.Windows.Forms.TextBox
    Friend WithEvents txtHighSubPower As System.Windows.Forms.TextBox
    Friend WithEvents txtHighMainPower As System.Windows.Forms.TextBox
    Friend WithEvents txtLowSignal As System.Windows.Forms.TextBox
    Friend WithEvents txtLowSubPower As System.Windows.Forms.TextBox
    Public WithEvents txtLowMainPower As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents gbPMXSetting As System.Windows.Forms.GroupBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents lblDutyPercent As System.Windows.Forms.Label
    Friend WithEvents lblFrequencyUnit As System.Windows.Forms.Label
    Friend WithEvents lblAmpUnit As System.Windows.Forms.Label
    Friend WithEvents lblValueUnit As System.Windows.Forms.Label
    Friend WithEvents txtHighDuty As System.Windows.Forms.TextBox
    Friend WithEvents txtHighFrequency As System.Windows.Forms.TextBox
    Friend WithEvents txtHighAmplitude As System.Windows.Forms.TextBox
    Friend WithEvents txtBiasHighValue As System.Windows.Forms.TextBox
    Friend WithEvents txtLowDuty As System.Windows.Forms.TextBox
    Friend WithEvents txtLowFrequency As System.Windows.Forms.TextBox
    Friend WithEvents txtLowAmplitude As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Public WithEvents txtBiasLowValue As System.Windows.Forms.TextBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents tpDisplay As System.Windows.Forms.TabPage
    Friend WithEvents gnNumOfOutdataDsipMDX As System.Windows.Forms.GroupBox
    Friend WithEvents ChkOut_5 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkOut_4 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkOut_3 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkOut_2 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkOut_1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents tbDispDigit_Photocurrent As System.Windows.Forms.TextBox
    Friend WithEvents tbDispDigit_Current As System.Windows.Forms.TextBox
    Friend WithEvents tbDispDigit_Volt As System.Windows.Forms.TextBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents tpLink As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEnableDataViewerLink_IVL As System.Windows.Forms.CheckBox
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents btnFindPathOfDataViewer_IVL As System.Windows.Forms.Button
    Friend WithEvents tbPathOfDataViewer_IVL As System.Windows.Forms.TextBox
    Friend WithEvents ucSelDispType_Photocurrent As M7000.ucSelectValueTypeAndUnit
    Friend WithEvents ucSelDispType_Current As M7000.ucSelectValueTypeAndUnit
    Friend WithEvents ucSelDispType_Volt As M7000.ucSelectValueTypeAndUnit
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnIntensityAdj_SrcSettings As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbIntesityAdj_Step As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbIntesityAdj_Limit As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbIntesityAdj_Start As System.Windows.Forms.TextBox
    Friend WithEvents cbSelACFMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEnableDataViewerLink_LT As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnFindPathOfDataViewer_LT As System.Windows.Forms.Button
    Friend WithEvents tbPathOfDataViewer_LT As System.Windows.Forms.TextBox
    Friend WithEvents tpSave As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSaveOpt_AddDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkSaveOpt_AddExpMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkSaveOpt_AddUserInputFileName As System.Windows.Forms.CheckBox
    Friend WithEvents chkSaveOpt_AddChNum As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoDispCh_JIGAndCellNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDispCh_Channel As System.Windows.Forms.RadioButton
    Friend WithEvents tbAttributeString As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents tbMdlPatternNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnDefSavePath As System.Windows.Forms.Button
    Friend WithEvents tbDefSavePath As System.Windows.Forms.TextBox
    Friend WithEvents lblDistance_Theta As System.Windows.Forms.Label
    Friend WithEvents tbDistance_Theta As System.Windows.Forms.TextBox
    Friend WithEvents lblDistance_Z As System.Windows.Forms.Label
    Friend WithEvents tbDistance_Z As System.Windows.Forms.TextBox
    Friend WithEvents tbPosPerDistance_Theta As System.Windows.Forms.TextBox
    Friend WithEvents lblMotionPos_Theta As System.Windows.Forms.Label
    Friend WithEvents tbCalPos_Theta As System.Windows.Forms.TextBox
    Friend WithEvents tbEndPos_Theta As System.Windows.Forms.TextBox
    Friend WithEvents tbStartPos_Theta As System.Windows.Forms.TextBox
    Friend WithEvents tbPosPerDistance_Z As System.Windows.Forms.TextBox
    Friend WithEvents lblMotionPos_Z As System.Windows.Forms.Label
    Friend WithEvents tbCalPos_Z As System.Windows.Forms.TextBox
    Friend WithEvents tbEndPos_Z As System.Windows.Forms.TextBox
    Friend WithEvents tbStartPos_Z As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents tbLumiPerSpectrumSave As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox21 As System.Windows.Forms.GroupBox
    Friend WithEvents chkVisibleAngleMoveButton As System.Windows.Forms.CheckBox
    Friend WithEvents chkVisibleChannelMoveButton As System.Windows.Forms.CheckBox
    Friend WithEvents gbSampleInfos As System.Windows.Forms.GroupBox
    Friend WithEvents tbSampleHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents tbSampleWidth As System.Windows.Forms.TextBox
    Friend WithEvents tbFill As System.Windows.Forms.TextBox
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents GroupBox24 As System.Windows.Forms.GroupBox
    Friend WithEvents ucDispLTDataIndex As M7000.ucDispListView
    Friend WithEvents cboLTDataFormat As System.Windows.Forms.ComboBox
    Friend WithEvents btn_LifetimeDataDel As System.Windows.Forms.Button
    Friend WithEvents btn_LifetimeDataADD As System.Windows.Forms.Button
    Friend WithEvents GroupBox23 As System.Windows.Forms.GroupBox
    Friend WithEvents ucDispIVLDataIndex As M7000.ucDispListView
    Friend WithEvents cboIVLDataFormat As System.Windows.Forms.ComboBox
    Friend WithEvents btn_IVLDataDel As System.Windows.Forms.Button
    Friend WithEvents btn_IVLDataADD As System.Windows.Forms.Button
    Friend WithEvents GroupBox27 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents chkLTFileversion As System.Windows.Forms.CheckBox
    Friend WithEvents chkLTFilename As System.Windows.Forms.CheckBox
    Friend WithEvents chkLTMeasMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkLTBiasMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkIVLBiasMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkIVLMeasMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkIVLFilename As System.Windows.Forms.CheckBox
    Friend WithEvents chkIVLFileversion As System.Windows.Forms.CheckBox
    Friend WithEvents chkIVLSweepMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkIVLLumiMeasLevel As System.Windows.Forms.CheckBox
    Friend WithEvents chkLTRenewalTime As System.Windows.Forms.CheckBox
    Friend WithEvents grbACF As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox28 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbCCDtoSpectrometerPos_X As System.Windows.Forms.TextBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents tbCCDtoSpectrometerPos_Y As System.Windows.Forms.TextBox
    Friend WithEvents btnCalCCDtoMCRDistance As System.Windows.Forms.Button
    Friend WithEvents tbCCDtoSpectrometerPos_Z As System.Windows.Forms.TextBox
    Friend WithEvents tbCCDtoMCRPos_Z As System.Windows.Forms.TextBox
    Friend WithEvents btnCalCCDtoSpectrometerDistance As System.Windows.Forms.Button
    Friend WithEvents tbCCDtoMCRPos_Y As System.Windows.Forms.TextBox
    Friend WithEvents tbCCDtoMCRPos_X As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents tbSpectrometerPos_Y As System.Windows.Forms.TextBox
    Friend WithEvents btnGetMCRPos As System.Windows.Forms.Button
    Friend WithEvents tbCCDPos_X As System.Windows.Forms.TextBox
    Friend WithEvents tbMCRPos_Z As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbMCRPos_Y As System.Windows.Forms.TextBox
    Friend WithEvents tbSpectrometerPos_X As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tbMCRPos_X As System.Windows.Forms.TextBox
    Friend WithEvents tbCCDPos_Y As System.Windows.Forms.TextBox
    Friend WithEvents tbCCDPos_Z As System.Windows.Forms.TextBox
    Friend WithEvents tbSpectrometerPos_Z As System.Windows.Forms.TextBox
    Friend WithEvents btnGetCurrentCCDPos As System.Windows.Forms.Button
    Friend WithEvents btnGetSpectrometePos As System.Windows.Forms.Button
    Friend WithEvents tpTemp As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox22 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox26 As System.Windows.Forms.GroupBox
    Friend WithEvents cbIVLSweepSpeedMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents cbIVLSweepAperture As System.Windows.Forms.ComboBox
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents GroupBox25 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSpeedMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents cbAperture As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cbAngleGain As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbTemp_LimitAlarmHigh As System.Windows.Forms.TextBox
    Friend WithEvents cbLifetimeGain As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents tbTemp_LimitAlarmLow As System.Windows.Forms.TextBox
    Friend WithEvents cbIVLSweepGain As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tbTemp_Margin As System.Windows.Forms.TextBox
    Friend WithEvents cbFileType As System.Windows.Forms.ComboBox
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents chkFilenameTEGtoTEGChannel As System.Windows.Forms.CheckBox
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents tbCCDtoHEXAPos_X As System.Windows.Forms.TextBox
    Friend WithEvents tbCCDtoHEXAPos_Y As System.Windows.Forms.TextBox
    Friend WithEvents tbCCDtoHEXAPos_Z As System.Windows.Forms.TextBox
    Friend WithEvents btnCalCCDtoHEXADistance As System.Windows.Forms.Button
    Friend WithEvents tbHEXAPos_Y As System.Windows.Forms.TextBox
    Friend WithEvents tbHEXAPos_X As System.Windows.Forms.TextBox
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents tbHEXAPos_Z As System.Windows.Forms.TextBox
    Friend WithEvents btnGetHEXAPos As System.Windows.Forms.Button
    Friend WithEvents GroupBox31 As System.Windows.Forms.GroupBox
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents tbThetaOffset As System.Windows.Forms.TextBox
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents tbThetaRatio As System.Windows.Forms.TextBox
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents tbThetaDeviation As System.Windows.Forms.TextBox
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents btnWADFactor As System.Windows.Forms.Button
    Friend WithEvents btnCheckContact As System.Windows.Forms.Button
    Friend WithEvents chkEndHomming As System.Windows.Forms.CheckBox
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents GroupBox32 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCaptureImgPathFind As System.Windows.Forms.Button
    Friend WithEvents tbCaptureImagePath As System.Windows.Forms.TextBox
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents tbExposureTime As System.Windows.Forms.TextBox
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents cbAnalysisMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents tbCaptureLevel As System.Windows.Forms.TextBox
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents chkSpectroMeasureMode As System.Windows.Forms.CheckBox
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents tbDistance_Theta_Y As System.Windows.Forms.TextBox
    Friend WithEvents tbDispDigit_Integral_Relative As System.Windows.Forms.TextBox
    Friend WithEvents tbDispDigit_Integral As System.Windows.Forms.TextBox
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents cbACFSrcMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents lbACFStopUnit As System.Windows.Forms.Label
    Friend WithEvents lbACFStepUnit As System.Windows.Forms.Label
    Friend WithEvents lbACFStartUnit As System.Windows.Forms.Label

End Class
