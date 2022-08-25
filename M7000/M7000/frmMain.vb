Imports CCommLib
Imports System.Threading
Imports System.IO
Imports CSMULib
Imports CSpectrometerLib
Imports CColorAnalyzerLib


Public Class frmMain

#Region "Defines"

    Public meas_queue As New Queue
    Public meas_manualqueqe As New Queue
    'Sub Frame
    Public frmControlUI As frmCtrlUI
    Public frmMonitorUI As frmMonitorUIOfGeneralType
    Public frmMotionUI As frmMotionUI
    Public frmPretestUI As frmPretestUI
    Public frmLog As frmLogWin
    Public frmMessageUI As frmMessage
    Dim chkPassWind As frmCheckPassword
    Public frmPLCAlarm As frmPLCAlarm

    'Object
    Public cPLCScheduler As CSheduler_PLC
    Public cTimeScheduler As CScheduler
    Public cQueueProcessor As CSeqProcessor
    Public WithEvents g_StateMsgHandler As New CStateMsg
    Dim m_ChannelCheckMethod As eChannelCheckMethod
    Public cState As CStateInfo

    'Device Component
    '===============================================================
    Public cM6000() As CSeqRoutineM6000
    Public cMcSG() As CSeqRoutineSG
    Public WithEvents cPG As CDevPGAPI 'Module Driver
    'Public cMCPG() As CSeqRoutineMcPG
    'Public cPGPower() As cDevPGPower
    'Public cPGCtrl() As cDevPGControl
    'Public cPG() As cDevPG
    Public cTC() As CSeqRoutineTemp
    Public cTCMC() As CDevMcTC

    'Public cMC9() As CSeqRoutineMC9
    'Public cNX1() As CDevNX1
    Public WithEvents cPLC As CSeqRoutinePLC
    Public cMotion As CDevMotion_AJIN
    'Giga-E Camera for Auto Centering & Focusing
    ' Public cPR730 As CDevPR730
    'Public cPDMeasureUnit As CDevPDUnit
    Public cTHC98585 As CDevTHC98585

    Public cIVLSMU() As CDevSMUAPI

    Public cSwitch() As CDevSwitchAPI
    Public cDMM() As CDevDMM6500
    Public cBCR() As CDevVoyager1250

    Public cStrobe() As CDevStrobe

    Public cSpectormeter() As CDevSpectrometerAPI
    Public cColorAnalyzer() As CColorAnalyzerLib.CDevColorAnalyzerAPI
    Public cVision As CDevVisionCameraAPI

    Public WithEvents g_PauseCtrl As New CPauseControl
    Public g_EmergencyCtrl As New CV7000Emergency
    Public g_StateLamp As New CV7000StateLamp
    Public g_AlarmStatus() As CDevPLCCommonNode.eDISignal
    ' Public cPR705 As CDevPR705
    ' Public cSR3AR As CDevSR_3AR

    '================================================================

    Public g_DataSaver() As cDataOutput
    Public SequenceList() As CSequenceManager
    Public g_MeasuredDatas() As sMeasureParams
    Public g_SweepStop() As Boolean

    Public frmIVLDispWind As frmIVLDisplay '= New frmIVLDisplay

    Dim m_bIsLoaded As Boolean = False

    Friend tlHWStatus() As System.Windows.Forms.ToolStripStatusLabel

    Public cCalibration As CCalibration = New CCalibration

    Public m_bThetaAxisUsed As Boolean = False  'Config 추가 필요

    Public cScreenCapture As cScreenCapture

#Region "Structure"

    Public Structure sSStatus
        Dim isConnected As Boolean
        '  Dim bIsLoadedLastRecipe() As Boolean  '이전 실험 정보의 존재 유무 확인(없으면...이어서 붙이는건 안됨)
        '  Dim bIsLoadedLastSchedulerState() As Boolean    '채널의 이전 상태 정보 유무 확인(없으면, PC & HW Connection을 통한 이어 붙이기 안됨)
        Dim bIsLoadedLastSequence() As Boolean  '이전 실험 정보의 존재 유무 확인(없으면...이어서 붙이는건 안됨)
        Dim bCanUpdateStateInfoOfCh() As Boolean   'Schedulr의 상태 정보를 저장을 허가 하는 플레그, Scheduler Thread가 동작 하면  상태 정보가 무조건 갱신 됨, 그러면 모두 Idle로 바뀜는 문제를 방지하기 위해,
        Dim bIsShowMessageAlram As Boolean '동작 전에 Message Box 경고 사용 유무. 2013-03-29 승현
        Dim bSequenceLoadChk As Boolean
        Dim m_ChannelCheckMethod As eChannelCheckMethod
        Dim bCompleted_ACF_CH() As Boolean
        Dim dispMode As eFrameMode
    End Structure

    Public Structure sSOptions
        Dim bEnableAlarm As Boolean
        Dim sOptionData As frmOptionWindow.sOPTIONDATa
        Dim sDeviceOption As sDeviceOptions
    End Structure

    Public Structure sDeviceOptions
        Dim sSpectrometer As CSpectrometerLib.CDevSpectrometerCommonNode.DeviceOption
    End Structure
    Public Structure sMeasureParams
        Dim totalTime As CTime.sTimeValue
        Dim lifeTime As CTime.sTimeValue
        Dim modeTime As TimeSpan
        Dim dTemp As Double
        Dim bRequestedMeasRefValue As Boolean 'Luminance(%) 산출을 위한 기준 휘도값 or 기준 PD Current 저장 요청 Flag
        Dim bIsSavedRefPDCurrent As Boolean 'Luminance(%) 산출을 위한 기준 휘도값 or 기준 PD Current 저장 되었는지 나타내는 Flag
        Dim dRefLuminance As Double   '밝기의 비율 산출을 위한값, PD Current 또는 Luminance 값
        Dim dLuminance As Double
        Dim sCellLTParams As sCellLTMeasureParams
        Dim sPanelLTParams As sPanelLTMeasureParams
        Dim sModuleLTParams As sModuleLTMeasureParams
        Dim sCellIVLParams As sCellIVLMeasureParams
        Dim sSpectrometer() As CDevSpectrometerCommonNode.tData '
        Dim dRefValue As Double
    End Structure

    Public Structure sCellIVLMeasureParams
        Dim sSpectrometer() As CDevSpectrometerCommonNode.tData 'sSpectrometerData
        Dim sArrySpectrometer()() As CDevSpectrometerCommonNode.tData '
        Dim sIVLMeasure()() As sCellIVLMeasure
        Dim sNormalSpectrometer()() As Double
    End Structure

    'Public Structure sSpectrometerData
    '    Dim sPR730() As CDevPR730.tData
    '    Dim sPR705() As CDevPR705.tData
    '    Dim sSR3AR() As CDevSR_3AR
    'End Structure

    Public Structure sColorAnalyzerData
        Dim sCA310() As CDevCAxxxCMD.sDatas
    End Structure

    Public Structure sCellLTMeasureParams
        Dim dCellArea As Double
        Dim dCHNum As Double
        ' Dim dAngleList() As Double
        Dim LTData() As sCellLTMeasureParam  '측정 데이터 색상이 여러개 일때, Mixed Color(White 및 다른 조합 색상), Single color R, Single color G, Single color B 를 모두 측정 할경우 배열 Length = 4 로 초기화
        Dim RedLTData() As sCellLTMeasureParam
        Dim GreenLTData() As sCellLTMeasureParam
        Dim BlueLTData() As sCellLTMeasureParam
        Dim BlackLTData() As sCellLTMeasureParam
        Dim measPoint() As ucDispPointSetting.sPoint
        '  Dim LTDataLoadBak() As sCellLTMeasureParam
        ' Dim RealTimeData As sRealTimeDataOfM6000   '실시간 데이터 저장용, 측정 인터벌 보다 빠른 갱신 처리가 필요 할때  
    End Structure

    Public Structure sCellLTMeasureParam
        Dim type As ucSampleInfos.eSampleColor
        Dim dCurrentDensity As Double
        Dim dTotCurrent As Double   '색상이 Pixel이 한개 이상일때, 전체 전류를 더함
        Dim dTotPDCurrent As Double  '측정 색상이 단색이 아닐때, R,G,B 각각의 PD전류를 더함
        Dim dTotVoltage As Double
        Dim eletricalData As sEletricalMeasData
        Dim opticalData As sOpticalMeasData  '
        Dim nSpecSaveCnt As Integer    '안정화 시간 이후에 한번 저장 해야 함... Lumi % 저장 때문에
        Dim nLifetimeAfterIVLCnt As Integer 'Lifetime + IVL 실험에서 Lifetime 실험 초기 데이터  RefLumi = 100 %  저장 때문에
    End Structure

    Public Structure sOpticalMeasData
        Dim dLumi_Percent As Double
        Dim dRefLumi As Double
        Dim dLumi_Cd_m2 As Double
        Dim dLumi_Fill_Cd_m2 As Double
        Dim dLumi_Cd_A As Double
        Dim dLumi_Cd_A_Percent As Double
        Dim dLumi_Cd_A_RefValue As Double
        Dim dlmW As Double
        Dim dQE As Double
        Dim sSpectrometerData As CDevSpectrometerCommonNode.tData
        Dim dRefSpectrum_Percent As Double
        Dim dRefLumi_Percent As Double
        Dim dDeltaudvd As Double
        Dim dRefud As Double
        Dim dRefvd As Double
        Dim dSpectrumSum As Double
        Dim dSpectrumSum_Per As Double
        Dim dSpectrumSum_Ref As Double
        Dim dFWHM As Double
        Dim dELMax As Double
        Dim dPeak1_Integ As Double
        Dim dPeak2_Integ As Double
        Dim dPeak3_Integ As Double
        Dim dPeak4_Integ As Double
        Dim dPeak1_Integral_Relative As Double
        Dim dPeak2_Integral_Relative As Double
        Dim dPeak3_Integral_Relative As Double
        Dim dPeak4_Integral_Relative As Double
        Dim dPeak1_Integral_RefValue As Double
        Dim dPeak2_Integral_RefValue As Double
        Dim dPeak3_Integral_RefValue As Double
        Dim dPeak4_Integral_RefValue As Double
        Dim dPeak1_Integ_Lumi As Double
        Dim dPeak2_Integ_Lumi As Double
        Dim dPeak3_Integ_Lumi As Double
        Dim dPeak4_Integ_Lumi As Double
        Dim dPeak1_Integral_Relative_Lumi As Double
        Dim dPeak2_Integral_Relative_Lumi As Double
        Dim dPeak3_Integral_Relative_Lumi As Double
        Dim dPeak4_Integral_Relative_Lumi As Double
        Dim dPeak1_Integral_RefValue_Lumi As Double
        Dim dPeak2_Integral_RefValue_Lumi As Double
        Dim dPeak3_Integral_RefValue_Lumi As Double
        Dim dPeak4_Integral_RefValue_Lumi As Double
        'Dim dPeak1_Lamda_Relative As Double
        'Dim nPeak1_Lamda As Integer
        'Dim nPeak2_Lamda As Integer
        'Dim dPeak2_Lamda_Relative As Double
        'Dim dPeak1_Lamda_RefValue As Double
        'Dim dPeak2_Lamda_RefValue As Double
    End Structure

    Public Structure sEletricalMeasData
        Dim colorType As ucSampleInfos.eSampleColor 'Single Color 가 아닐때 데이터 배열에서 어느 컬러의 데이터인지 나타냄
        Dim mode As CDevM6000PLUS.eMode
        Dim dVoltage As Double        '단색 일때는 배열을 1개로, 혼합한 Pixel의 수만큼
        Dim dCurrent As Double
        Dim dCurrent_Per As Double
        Dim dPDCurrent As Double
        Dim dRefVoltage As Double
        Dim dRefCurrent As Double
        Dim dDeltaVoltage As Double
        Dim dDeltaCurrent As Double
        Dim dHighVoltage As Double
        Dim dHighCurrent As Double
    End Structure

    Public Structure sRealTimeDataOfM6000
        Dim eachPixelMeasData As CDevM6000PLUS.sMeasParams '채널당 R,G,B  3개의 배열 값을 가지고 있음
        Dim dTotCurrent As Double
        Dim dTotVoltage As Double
        Dim dTotPDCurrent As Double
    End Structure

    'Public Structure sEchoWadData
    '    Dim dLumi_Percent As Double
    '    Dim dLumi_Cd_m2 As Double
    '    Dim dLumi_Cd_A As Double
    '    Dim dlmW As Double
    '    Dim dQE As Double
    '    Dim sSpectrometerData As CDevSpectrometerCommonNode.tData 'sSpectrometerData
    'End Structure

    Public Structure sPanelLTMeasureParams
        Dim dLumi_Percent As Double
        Dim sMeasuredValues As CSeqRoutineSG.sMeasuredData
        Dim sSpectrometer() As CDevSpectrometerCommonNode.tData '
    End Structure

    Public Structure sModuleLTMeasureParams
        Dim dLumi_Percent()() As Double
        Dim dRefLumi()() As Double
        Dim dRefCIE1976_ud()() As Double
        Dim dRefCIE1976_vd()() As Double
        Dim dDelta_udvd()() As Double
        Dim sMeasuredValues() As CDevPGCommonNode.sMeasuredDatas ' CSeqRoutineMcPG.sMeasuredData
        Dim sSpectrometer() As CDevSpectrometerCommonNode.tData '
        Dim sColorAnalyzer() As sColorAnalyzerData
        Dim measPoint() As ucDispPointSetting.sPoint
        Dim cmdPoint() As ucDispPointSetting.sPoint
    End Structure



    Public Structure sCellIVLMeasure
        Dim nCh As Integer        '1
        Dim dVoltage As Double  '2
        Dim dCurrent As Double '3
        Dim dArea_cm As Double '4
        Dim dJ As Double '5
        Dim dCdA As Double '6
        Dim dlmW As Double '7
        Dim dQE As Double '8
        Dim dLuminance_Fill_Cdm2 As Double
        Dim dLuminance_Cdm2 As Double '9
        Dim dLumi_Percent As Double
        Dim dCIEx As Double '10 'CIE1931
        Dim dCIEy As Double '11 'CIE1931
        Dim dCIEu As Double   ''CIE1976
        Dim dCIEv As Double     'CIE1976
        Dim dDelta_CIE1976 As Double
        Dim dDelta_udvd As Double
        Dim dCCT As Double
        Dim dAbs_J As Double '12
        Dim dABS_I As Double
        Dim dAbs_Current_Log As Double '13
        Dim nMeasMode As ucDispRcpIVLSweep.eMeasureItems '14
        Dim dTemperature As Double '15
        Dim dIVLSweepTime_min As Double
        Dim dIVLSweepStandbyTime_min As Double
        Dim dAngle As Double
        Dim sColorName As String
        Dim dFWHM As Double
        Dim dRealCurrent As Double
        Dim sMeteralValue As CDataQECal.sMaterial
        Dim dX As Double
        Dim dY As Double
        Dim dZ As Double
        Dim dLe As Double
        Dim dDelta_CIE1960 As Double ''Delta CIE1960
        Dim dWavePeakValue As Double
        Dim nWavePeaklength As Integer
        Dim nIntegrationTime As Double
        Dim dTotalEQE As Double
        Dim dTotalFlux As Double
        Dim time As Double
        Dim dCRI As Double
        Dim dIntensity() As Double
        Dim dLamda() As Double
        Dim dPeak1_Integ As Double
        Dim dPeak2_Integ As Double
        Dim dPeak1_Integral_Relative As Double
        Dim dPeak2_Integral_Relative As Double
        Dim dPeak1_Integral_RefValue As Double
        Dim dPeak2_Integral_RefValue As Double
        Dim dPeak1_Lamda_RefValue As Double
        Dim dPeak2_Lamda_RefValue As Double
        Dim dPeak1_Lamda As Double
        Dim dPeak2_Lamda As Double
        Dim dPeak1_Lamda_Relative As Double
        Dim dPeak2_Lamda_Relative As Double

    End Structure

    Public Structure sPanelIVLMeasure
        Dim nCh As Integer             '1
        Dim nMeasMode As ucDispRcpIVLSweep.eMeasureItems '14
        Dim dArea_cm As Double   '7
        Dim dELVDD_V As Double  '2
        Dim dELVDD_I As Double   '3
        Dim dELVSS_V As Double  '4
        Dim dELVSS_I As Double   '5
        Dim dTotal_I As Double       '6
        Dim dJ As Double '5
        Dim dCdA As Double '6
        Dim dlmW As Double '7
        Dim dQE As Double '8
        Dim dCdm2 As Double '9
        Dim dX As Double
        Dim dY As Double
        Dim dZ As Double
        Dim dCIEx As Double '10
        Dim dCIEy As Double '11
        Dim dCIEu As Double
        Dim dCIEv As Double
        Dim dAbs_J As Double '12
        Dim dABS_Total_I As Double  '13
        Dim dAbs_Current_Log As Double '14
        Dim dTemperature As Double '15
        Dim dRed As Double
        Dim dGreen As Double
        Dim dBlue As Double
    End Structure

    Public Structure sModuleGrayMeasure
        Dim nCh As Integer             '1
        Dim nSweepMode As ucDispRcpGrayScaleSweep.eGrayScaleMode '2
        Dim dArea_cm As Double   '3
        Dim dV() As Double  '4
        Dim dI() As Double   '5
        Dim dTotV As Double  '6
        Dim dTotI As Double   '7
        Dim dJ As Double '8
        Dim dCdA As Double '9
        Dim dlmW As Double '10
        Dim dQE As Double '11
        Dim dCdm2 As Double '12
        Dim dX As Double     '13
        Dim dY As Double     '14
        Dim dZ As Double     '15
        Dim dCIEx As Double '16
        Dim dCIEy As Double '17
        Dim dCIEu As Double  '18
        Dim dCIEv As Double  '19
        Dim dAbs_J As Double '20
        Dim dABS_Total_I As Double  '21
        Dim dAbs_Current_Log As Double '22
        Dim dTemperature As Double '23
        Dim dRed As Double
        Dim dGreen As Double
        Dim dBlue As Double
    End Structure

#End Region

#Region "Enums"

    Public Enum eTestStartMode
        eNew        '새로 시작
        eAppend      '이전 정보를 사용하여, 이전에 측정 하던 파일에 이어서 시작
    End Enum

    Public Enum eFrameMode
        eControlUIOfJIGLayout
        eControlUIOfListType
        eControlUIOfCustomTypeForQC
        eControlUIOfListTypeForQC
        eMonitoringUI
        eMotionUI
        ePretestUI
    End Enum

    Public Enum eMeasureItem 'High Volt/Curr 추가 2013-03-21 승현
        Temp
        Cell_Voltage
        Cell_Current
        PD_Current
        Luminance_Rate
        Cell_HighVolatege
        Cell_HighCurrent
    End Enum

    Enum eChannelCheckMethod
        Each_Ch = 0
        Board_to_Ch = 1
        JIG_to_Ch = 2
    End Enum

    Public ReadOnly Property ChannelCheckMode As eChannelCheckMethod
        Get
            Return m_ChannelCheckMethod
        End Get
    End Property

    Public Enum eConnectionMode
        ePCConnection     'PC 만  다운되었을경우(SW 에러  또는 PC 오류 등으로)
        eHWConnection      'PC와 H/W 가 동시에 다운되었을 경우(정전 등에 의하여 모두 다운되었을 경우)
    End Enum

#End Region

#End Region

#Region "Delegate"

    Private Delegate Sub DelSetString(ByVal str As String)
    Private Delegate Sub DelSetBoolean(ByVal bool As Boolean)
    Private Delegate Sub DelSetImage(ByVal img As Image)
    Private Delegate Sub DelSetColor(ByVal ccolor As Color)
    Private Delegate Sub DelColor(ByVal inch As Integer, ByVal ccolor As Color)


    Public Sub EnableTsBtnTestPause(ByVal bool As Boolean)  'ByVal label As System.Windows.Forms.StatusStrip,
        If MainToolStrip.InvokeRequired = True Then
            Dim del2 As DelSetBoolean = New DelSetBoolean(AddressOf EnableTsBtnTestPause)
            Try
                Invoke(del2, bool)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tsBtnTestPAUSE.Enabled = False 'bool 장비에서 Teach와 Auto 키 로 대체하기 때문에 S/W에서는 버튼을 누를 일이 없음...누르게 되면 중복되어서 문제가 발생 하기 때문에 누르지 못 하게 함.
        End If
    End Sub

    Public Sub tsBtnTestPauseText(ByVal str As String)  'ByVal label As System.Windows.Forms.StatusStrip,
        If MainToolStrip.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf tsBtnTestPauseText)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tsBtnTestPAUSE.Text = str
        End If
    End Sub

    Public Sub tsBtnTestPauseImage(ByVal img As Image)  'ByVal label As System.Windows.Forms.StatusStrip,
        If MainToolStrip.InvokeRequired = True Then
            Dim del2 As DelSetImage = New DelSetImage(AddressOf tsBtnTestPauseImage)
            Try
                Invoke(del2, img)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tsBtnTestPAUSE.Image = img
        End If
    End Sub

    Public Sub tsBtnTestPauseColor(ByVal ccolor As Color)  'ByVal label As System.Windows.Forms.StatusStrip,
        If MainToolStrip.InvokeRequired = True Then
            Dim del2 As DelSetColor = New DelSetColor(AddressOf tsBtnTestPauseColor)
            Try
                Invoke(del2, ccolor)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tsBtnTestPAUSE.BackColor = ccolor
        End If
    End Sub


    Public Sub QueueCounter(ByVal str As String)  'ByVal label As System.Windows.Forms.StatusStrip,
        If mainStatus.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf QueueCounter)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tlQueueCounter.Text = str
        End If
    End Sub
    Public Sub ManualQueueCounter(ByVal str As String)  'ByVal label As System.Windows.Forms.StatusStrip,
        If mainStatus.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf ManualQueueCounter)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tlManualQueueCounter.Text = str
        End If
    End Sub
    Public Sub PLCQueueCounter(ByVal str As String)  'ByVal label As System.Windows.Forms.StatusStrip,
        If mainStatus.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf PLCQueueCounter)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tlPLCQueueCounter.Text = str
        End If
    End Sub

    Private Sub BCRInfo_ChangedValue(ByVal str As String)
        If mainStatus.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf BCRInfo_ChangedValue)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            If g_SystemInfo.isConnected = True Then
                tlBCRInfo.Text = str
            End If
        End If
    End Sub

    Private Sub StatusMsg(ByVal str As String)
        If mainStatus.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf StatusMsg)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tlStatus.Text = str
        End If
    End Sub


    Public Sub RemainTime(ByVal str As String)
        If mainStatus.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf RemainTime)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tslRemainTime.Text = str
        End If
    End Sub
    Public Sub HWStatusColor(ByVal nch As Integer, ByVal cColor As Color)
        If mainStatus.InvokeRequired = True Then
            Dim del2 As DelColor = New DelColor(AddressOf HWStatusColor)
            Try
                Invoke(del2, nch, cColor)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tlHWStatus(nch).BackColor = cColor
        End If
    End Sub
    Public Sub HWStatusMsg(ByVal STR As String)
        If mainStatus.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf HWStatusMsg)
            Try
                Invoke(del2, STR)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tlPLCQueue.Text = STR
        End If
    End Sub

    Public Sub AlarmMsg(ByVal STR As String)
        If mainStatus.InvokeRequired = True Then
            Dim del2 As DelSetString = New DelSetString(AddressOf AlarmMsg)
            Try
                Invoke(del2, STR)
            Catch ex As Exception

                Exit Sub
            End Try
        Else
            tlAlarm.Text = STR
        End If
    End Sub

    Public Sub WriteLogMsg(ByVal STR As String)
        Dim sr As StreamWriter

        Try
            sr = New StreamWriter(g_sFilePath_SystemLog, True)
        Catch ex As Exception
            sr.Close()
        End Try
        Dim cYear As String = Now.Year 'Format(Now, "yyyy")
        Dim cMonth As String = Now.Month ' Format(Now, "MM")
        Dim cDay As String = Now.Day  'Format(Now, "dd")

        Dim cHour As String = Now.Hour '(Now, "HH")
        Dim cMin As String = Now.Minute ' Format(Now, "mm")
        Dim cSec As String = Now.Second 'Format(Now, "ss")

        STR = cYear & "-" & cMonth & "-" & cDay & " " & cHour & ":" & cMin & ":" & cSec & "  " & STR

        sr.WriteLine(STR)

        sr.Close()
        'Try
        '    FileOpen(4, g_sFilePath_SystemLog, OpenMode.Append, OpenAccess.Write, OpenShare.Shared) '파일을 열고
        'Catch ex As Exception
        '    FileClose(4)
        'End Try

        'Dim cYear As String = Now.Year 'Format(Now, "yyyy")
        'Dim cMonth As String = Now.Month ' Format(Now, "MM")
        'Dim cDay As String = Now.Day  'Format(Now, "dd")

        'Dim cHour As String = Now.Hour '(Now, "HH")
        'Dim cMin As String = Now.Minute ' Format(Now, "mm")
        'Dim cSec As String = Now.Second 'Format(Now, "ss")

        'STR = cYear & "-" & cMonth & "-" & cDay & " " & cHour & ":" & cMin & ":" & cSec & "  " & STR

        'PrintLine(4, STR)

        ''파일에 쓰고
        'FileClose(4)
    End Sub

    Dim m_KeyShft As Boolean = False

    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Shift = True Then
            RUN()

        End If

    End Sub

#End Region


#Region "Creator and initialization"


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

        init()
    End Sub

    Public Function CaptureImage(ByVal strName As String) As Boolean

        If cVision.myVisionCamera.SaveGrabImage(g_SystemOptions.sOptionData.CCDData.strCaptureCCDPath & "\" & strName & ".bmp") = False Then
            Return False
        End If

        Return True
    End Function

    Private Sub init()

        'If Process_Kill() = False Then
        '    Exit Sub
        'End If

        'Dim frmSelect As New frmSelectUI

        'If frmSelect.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Type = frmSelect.TypeSelect
        'End If
        ' Type = "Type2_"
        Me.Text = g_strMainTitle & "[Ver : " & g_strSWVer & "]"

        'System Directory Create
        If Directory.Exists(g_sPATH_SHARED_DATA) = False Then
            Directory.CreateDirectory(g_sPATH_SHARED_DATA)
        End If

        If Directory.Exists(g_sPATH_ViewerData) = False Then
            Directory.CreateDirectory(g_sPATH_ViewerData)
        End If


        If frmConfigSystem.LoadInfo(g_ConfigInfos.nDevice) = True Then
            If frmConfigDevice.LoadConfiguration(g_ConfigInfos) = True Then
                If frmOptionWindow.LoadSystemOption(g_SystemOptions.sOptionData) = False Then
                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_ALARM_Check_Options)
                    Exit Sub
                Else
                    If updateDeviceConfig() = False Then
                        g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_Popup_Log, CStateMsg.eStateMsg.eSYSTEM_ALARM_Failed_Create_Device)
                        Exit Sub
                    End If

                End If
            Else
                g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_ALARM_Check_DeviceConfig)
                Exit Sub
            End If

            CreatHWStatusBar()

        Else
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_ALARM_Check_SystemConfig)
            Exit Sub
        End If

        If frmChannelRangeSetttings.LoadRangeData(g_ChRangeInfo) = True Then
        Else
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_ALARM_Check_LoadRangeData)
            Exit Sub
        End If

        If frmSettingWind.LoadSystemSettings(g_SystemSettings) = True Then

            If InitChildFrame() = False Then
                MsgBox("Check the channel allocation informations")
                Exit Sub
            End If
        Else
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_ALARM_Check_SystemSettings)
            Exit Sub
        End If

        '   If frmOptionWindow.LoadSystemOption(g_SystemOptions.sOptionData) = False Then
        '  g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_ALARM_Check_Options)
        'Exit Sub
        ' Else

        chkPassWind = New frmCheckPassword(g_SystemOptions.sOptionData.SafetyAdmin.strPassword)

        applyOptions()
        '  End If

        'If cMotion Is Nothing = False Then
        '    cMotion.CalDataRealDistanceUse = g_SystemOptions.sOptionData.MotionData.bCalPosPerDistanceUse
        '    cMotion.CalDataRealDistanceX = g_SystemOptions.sOptionData.MotionData.sCalPosPerDistance.dAxis_X
        '    cMotion.CalDataRealDistanceY = g_SystemOptions.sOptionData.MotionData.sCalPosPerDistance.dAxis_Y

        '    'For i As Integer = 0 To g_nMaxCh - 1
        '    '    frmControlUI.ControlUI.control.IndicatorTitle(i) = dlgOpt.Settings
        '    '    ' frmControlUI.ControlUI.control.IndicatorSettingTitle(i) = dlgOpt.Settings
        '    'Next

        'End If

        m_bIsLoaded = True

    End Sub

    Private Sub CreatHWStatusBar()
        Dim nCount As Integer = 0
        Dim bUseM600 As Boolean = False
        If g_ConfigInfos.nDevice Is Nothing = False Then
            ReDim tlHWStatus(g_ConfigInfos.nDevice.Length - 1)

            For idx As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
                If g_ConfigInfos.nDevice(idx) = frmConfigSystem.eDeviceItem.eSMU_M6000 Then
                    bUseM600 = True
                    Exit For
                End If
            Next

            '수명설비 사용할때만
            If bUseM600 = True Then
                ReDim tlHWStatus((g_ConfigInfos.nDevice.Length - 1) + (g_ConfigInfos.M6000Config.Length - 1))   'nDevice에 m6000이 포함되므로 -2해야됨
            End If
        End If

        Me.mainStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlInnerTemp, Me.tlInnerHumi, Me.tlStatus, Me.tlQueueCounter, Me.tlManualQueueCounter, Me.tlPLCQueue, Me.tlAlarm})

        If tlHWStatus Is Nothing = False Then
            For idx As Integer = 0 To tlHWStatus.Length - 1
                tlHWStatus(idx + nCount) = New System.Windows.Forms.ToolStripStatusLabel
                tlHWStatus(idx + nCount).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                tlHWStatus(idx + nCount).Size = New System.Drawing.Size(70, 20)
                tlHWStatus(idx + nCount).AutoSize = True
                tlHWStatus(idx + nCount).BorderStyle = Border3DStyle.Flat
                tlHWStatus(idx + nCount).BorderSides = ToolStripStatusLabelBorderSides.None
                tlHWStatus(idx + nCount).Text = frmConfigSystem.ConvertDeviceItemToString(g_ConfigInfos.nDevice(idx)).ToString() 'g_ConfigInfos.nDevice(idx).ToString

                If tlHWStatus(idx + nCount).Text = "M6000" Then
                    g_nHWM6000StartIndex = idx + nCount
                    For i As Integer = 0 To g_ConfigInfos.M6000Config.Length - 1
                        tlHWStatus(idx + nCount) = New System.Windows.Forms.ToolStripStatusLabel
                        tlHWStatus(idx + nCount).Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        tlHWStatus(idx + nCount).Size = New System.Drawing.Size(70, 20)
                        tlHWStatus(idx + nCount).AutoSize = True
                        tlHWStatus(idx + nCount).BorderStyle = Border3DStyle.Flat
                        tlHWStatus(idx + nCount).BorderSides = ToolStripStatusLabelBorderSides.None
                        tlHWStatus(idx + nCount).Text = "M6000" & "_" & i + 1
                        tlHWStatus(idx + nCount).BackColor = Color.Silver
                        tlHWStatus(idx + nCount).ForeColor = Color.White
                        Dim margin As System.Windows.Forms.Padding
                        margin.Left = 1
                        margin.Right = 1
                        margin.Top = 1
                        margin.Bottom = 1

                        tlHWStatus(idx + nCount).Margin = margin

                        Me.mainStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {tlHWStatus(idx + nCount)})

                        If nCount <> g_ConfigInfos.M6000Config.Length - 1 Then
                            nCount += 1
                        Else
                            nCount = nCount
                        End If
                    Next
                Else
                    tlHWStatus(idx + nCount).BackColor = Color.Silver
                    tlHWStatus(idx + nCount).ForeColor = Color.White
                    Dim margin1 As System.Windows.Forms.Padding
                    margin1.Left = 1
                    margin1.Right = 1
                    margin1.Top = 1
                    margin1.Bottom = 1

                    tlHWStatus(idx + nCount).Margin = margin1

                    Me.mainStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {tlHWStatus(idx + nCount)})

                    If idx + nCount = tlHWStatus.Length - 1 Then
                        Exit Sub
                    End If
                End If
            Next
        End If

    End Sub


    Public Function updateDeviceConfig() As Boolean
        'Dim PGInitInfo() As CSeqRoutineMcPG.sInitParam = Nothing
        Dim PGInitInfo As CDevPGCommonNode.sPGConfigParams = Nothing

        Try
            g_nMaxCh = g_ConfigInfos.MaxCh
            g_nMaxJIG = g_ConfigInfos.numOfJIG
            'Dim PGCommInfo(0) As CSeqRoutinePG.sCommInfo

            If g_ConfigInfos.PGConfig.McPGGroup Is Nothing = False Then
                ReDim PGInitInfo.sMcPGConfig(g_ConfigInfos.PGConfig.McPGGroup.Length - 1)
            End If

            ReDim SequenceList(g_nMaxCh - 1)
            ReDim g_MeasuredDatas(g_nMaxCh - 1)
            ReDim g_DataSaver(g_nMaxCh - 1)
            ReDim g_SweepStop(g_nMaxCh - 1)

            ReDim g_SystemInfo.bIsLoadedLastSequence(g_nMaxCh - 1)
            ReDim g_SystemInfo.bCanUpdateStateInfoOfCh(g_nMaxCh - 1)

            ReDim g_SystemInfo.bCompleted_ACF_CH(g_nMaxCh - 1)

            For i As Integer = 0 To g_nMaxCh - 1
                g_SystemInfo.bCanUpdateStateInfoOfCh(i) = False
                g_SystemInfo.bCompleted_ACF_CH(i) = False
                g_SweepStop(i) = False
            Next

            g_SystemInfo.bIsShowMessageAlram = True

            tlAlarm.Visible = False
            tlPLCQueue.Visible = False
            tlInnerTemp.Visible = False
            tlInnerHumi.Visible = False

            '  Dim nPGCnt() As Integer = New Integer() {0, 0, 0}
            For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
                Select Case g_ConfigInfos.nDevice(i)

                    Case frmConfigSystem.eDeviceItem.eSMU_M6000
                        If g_ConfigInfos.M6000Config Is Nothing = False Then
                            ReDim cM6000(g_ConfigInfos.M6000Config.Length - 1)
                        Else
                            cM6000 = Nothing
                        End If
                    Case frmConfigSystem.eDeviceItem.ePG

                        PGInitInfo.nDevice = g_ConfigInfos.PGConfig.nDeviceType

                        If PGInitInfo.nDevice = CDevPGCommonNode.eDevModel._McPG Then

                            For n As Integer = 0 To g_ConfigInfos.PGConfig.McPGGroup.Length - 1

                                PGInitInfo.sMcPGConfig(n).nSeedCh = g_ConfigInfos.PGConfig.McPGGroup(n).nSeedCh
                                PGInitInfo.sMcPGConfig(n).sPG.bEnable = g_ConfigInfos.PGConfig.McPGGroup(n).bEnablePG
                                If g_ConfigInfos.PGConfig.McPGGroup(n).bEnablePG = True Then
                                    PGInitInfo.sMcPGConfig(n).sPG.nNumOfDev = g_ConfigInfos.PGConfig.McPGGroup(n).nPGNo.Length   'PG의 수량, 소캣 통신 포트수와 같음.
                                Else
                                    PGInitInfo.sMcPGConfig(n).sPG.nNumOfDev = 0
                                End If

                                PGInitInfo.sMcPGConfig(n).sPGCtrl.bEnable = g_ConfigInfos.PGConfig.McPGGroup(n).bEnablePGCtrl
                                If g_ConfigInfos.PGConfig.McPGGroup(n).bEnablePGCtrl = True Then
                                    PGInitInfo.sMcPGConfig(n).sPGCtrl.nNumOfDev = g_ConfigInfos.PGConfig.McPGCtrlBDConfig(g_ConfigInfos.PGConfig.McPGGroup(n).nPGCtrlBDNo).numberOfDevice  '485 통신 포트에 연결된 Device의 수
                                    PGInitInfo.sMcPGConfig(n).sPGCtrl.nSeedAddress = g_ConfigInfos.PGConfig.McPGCtrlBDConfig(g_ConfigInfos.PGConfig.McPGGroup(n).nPGCtrlBDNo).nSeedAddress
                                Else
                                    PGInitInfo.sMcPGConfig(n).sPGCtrl.nNumOfDev = 0
                                    PGInitInfo.sMcPGConfig(n).sPGCtrl.nSeedAddress = 0
                                End If

                                PGInitInfo.sMcPGConfig(n).sPGPower.bEnable = g_ConfigInfos.PGConfig.McPGGroup(n).bEnablePGPwr
                                If g_ConfigInfos.PGConfig.McPGPwrConfig Is Nothing = False Then
                                    If g_ConfigInfos.PGConfig.McPGGroup(n).bEnablePGPwr = True Then
                                        PGInitInfo.sMcPGConfig(n).sPGPower.nNumOfDev = g_ConfigInfos.PGConfig.McPGPwrConfig(g_ConfigInfos.PGConfig.McPGGroup(n).nPGPwrNo).numberOfDevice
                                        PGInitInfo.sMcPGConfig(n).sPGPower.nSeedAddress = g_ConfigInfos.PGConfig.McPGPwrConfig(g_ConfigInfos.PGConfig.McPGGroup(n).nPGPwrNo).nSeedAddress
                                    Else
                                        PGInitInfo.sMcPGConfig(n).sPGPower.nNumOfDev = 0
                                        PGInitInfo.sMcPGConfig(n).sPGPower.nSeedAddress = 0
                                    End If
                                End If

                            Next

                        ElseIf PGInitInfo.nDevice = CDevPGCommonNode.eDevModel._G4S Then
                            PGInitInfo.sG4SConfig = g_ConfigInfos.PGConfig.G4sConfig
                        ElseIf PGInitInfo.nDevice = -1 Then
                            Return False
                        End If

                    Case frmConfigSystem.eDeviceItem.eMcSG
                        If g_ConfigInfos.SGConfig Is Nothing = False Then
                            ReDim cMcSG(g_ConfigInfos.SGConfig.Length - 1)
                        Else
                            cMcSG = Nothing
                        End If

                    Case frmConfigSystem.eDeviceItem.eMotion
                        cMotion = New CDevMotion_AJIN(Me, g_ConfigInfos.MotionComConfig.Length - 1)
                        cMotion.Settings = g_ConfigInfos.MotionConfig

                        m_bThetaAxisUsed = False

                        For idx As Integer = 0 To cMotion.Settings.Length - 1
                            If cMotion.Settings(idx).eMotionAxis = CDevMotion_AJIN.eMotionAxis.eTheta_Axis Then
                                m_bThetaAxisUsed = True
                                Exit For
                            End If
                        Next

                        'cMotion = New CDevMotion_EZ(Me, g_ConfigInfos.MotionConfig.Length - 1) ' CDevMotion_AJIN
                    Case frmConfigSystem.eDeviceItem.ePDMeasurement

                        'PG가 등록되어야 함
                        If g_ConfigInfos.PGConfig.McPGGroup Is Nothing = False Then
                            For n As Integer = 0 To g_ConfigInfos.PGConfig.McPGGroup.Length - 1
                                PGInitInfo.sMcPGConfig(n).sPDUnit.bEnable = g_ConfigInfos.PGConfig.McPGGroup(n).bEnablePDUnit
                                If g_ConfigInfos.PGConfig.McPGGroup(n).bEnablePDUnit = True Then
                                    PGInitInfo.sMcPGConfig(n).sPDUnit.nNumOfDev = g_ConfigInfos.PGConfig.McPGGroup(n).nPDUnitNo.Length
                                Else
                                    PGInitInfo.sMcPGConfig(n).sPDUnit.nNumOfDev = 0
                                End If
                            Next
                        End If

                    Case frmConfigSystem.eDeviceItem.ePLC

                        If g_ConfigInfos.PLCConfig Is Nothing = False Then

                            Try
                                cPLC = New CSeqRoutinePLC(g_ConfigInfos.PLCConfig(0).device, Me)
                            Catch ex As Exception
                                cPLC = Nothing
                            End Try

                            'If cPLC.myPLC.Model = CDevPLCCommonNode.eModel.MITSUBISHI Then
                            '    cPLC.myPLC.ComType = CDevPLC_MITSUBISHI.eType._Prog
                            'End If

                            tlAlarm.Visible = True
                            tlAlarm.Text = ""
                            tlPLCQueue.Visible = True
                        Else
                            cPLC = Nothing
                        End If

                    Case frmConfigSystem.eDeviceItem.eSpectroradiometer
                        If g_ConfigInfos.SpectrometerConfig Is Nothing = False Then
                            ReDim cSpectormeter(g_ConfigInfos.SpectrometerConfig.Length - 1)
                            For nCnt As Integer = 0 To cSpectormeter.Length - 1
                                cSpectormeter(nCnt) = New CDevSpectrometerAPI(g_ConfigInfos.SpectrometerConfig(nCnt).device)

                                AddHandler cSpectormeter(nCnt).evError, AddressOf SpectroRadiometerErrorEventHandler
                            Next
                        Else
                            cSwitch = Nothing
                        End If

                        'Case frmConfigSystem.eDeviceItem.ePR705
                        '    cPR705 = New CDevPR705

                        'Case frmConfigSystem.eDeviceItem.eSR3AR
                        '    cSR3AR = New CDevSR_3AR

                    Case frmConfigSystem.eDeviceItem.eColorAnalyzer

                        Dim devType As CColorAnalyzerLib.CDevColorAnalyzerCommonNode.eModel

                        ReDim cColorAnalyzer(g_ConfigInfos.ColorAnalyzerConfig.Length - 1)

                        For idx As Integer = 0 To g_ConfigInfos.ColorAnalyzerConfig.Length - 1
                            devType = g_ConfigInfos.ColorAnalyzerConfig(idx).device
                            cColorAnalyzer(idx) = New CColorAnalyzerLib.CDevColorAnalyzerAPI(devType)
                        Next

                    Case frmConfigSystem.eDeviceItem.eTC
                        If g_ConfigInfos.TCConfig Is Nothing = False Then
                            Dim settings As CDevTCCommonNode.sParams = Nothing

                            settings.dEvent1LimitVal_High = g_SystemOptions.sOptionData.TemperatureData.dLimitAlarmHigh
                            settings.dEvent1LimitVal_Low = g_SystemOptions.sOptionData.TemperatureData.dLimitAlarmLow

                            '  ReDim cTC(g_ConfigInfos.TCConfig.Length - 1)

                            If g_ConfigInfos.TCConfig(0).device <> 6 Then
                                ReDim cTC(g_ConfigInfos.TCConfig.Length - 1)
                                For idx As Integer = 0 To cTC.Length - 1
                                    cTC(idx) = New CSeqRoutineTemp(g_ConfigInfos.TCConfig(idx).device, g_ConfigInfos.TCConfig(idx).numberOfDevice, _
                                                                            g_ConfigInfos.TCConfig(idx).nSeedAddress, settings)

                                    AddHandler cTC(idx).evChangedOutputState, AddressOf TemperatureCtrl_ChangedOutputStatus
                                Next
                            Else
                                ReDim cTCMC(g_ConfigInfos.TCConfig.Length - 1)
                                For idx As Integer = 0 To cTCMC.Length - 1
                                    cTCMC(idx) = New CDevMcTC()
                                Next
                            End If

                        Else
                            cTC = Nothing
                            cTCMC = Nothing
                        End If

                        'Case frmConfigSystem.eDeviceItem.eTHC_98585
                        ' cTHC98585 = New CDevTHC98585
                    Case frmConfigSystem.eDeviceItem.eCamera


                    Case frmConfigSystem.eDeviceItem.eSMU_IVL
                        If g_ConfigInfos.SMUForIVLConfig Is Nothing = False Then
                            ReDim cIVLSMU(g_ConfigInfos.SMUForIVLConfig.Length - 1)
                            For nCnt As Integer = 0 To cIVLSMU.Length - 1
                                cIVLSMU(nCnt) = New CDevSMUAPI(g_ConfigInfos.SMUForIVLConfig(nCnt).device)
                                cIVLSMU(nCnt).mySMU.GetRangeList(g_ConfigInfos.SMUForIVLConfig(nCnt).sRangeList)
                            Next
                        Else
                            cIVLSMU = Nothing
                        End If
                    Case frmConfigSystem.eDeviceItem.eSwitch
                        If g_ConfigInfos.SwitchConfig Is Nothing = False Then
                            ReDim cSwitch(g_ConfigInfos.SwitchConfig.Length - 1)
                            For nCnt As Integer = 0 To cSwitch.Length - 1
                                '  If g_ConfigInfos.SwitchConfig(nCnt).device = CDevSwitchCommonNode.eModel.MC_SW7000 Then
                                cSwitch(nCnt) = New CDevSwitchAPI(g_ConfigInfos.SwitchConfig(nCnt).device)
                                'ElseIf g_ConfigInfos.SwitchConfig(nCnt).device = CDevSwitchCommonNode.eModel.KEITHLEY_K7001 Then
                                ' cSwitch(nCnt) = New CDevSwitchAPI(CDevSwitchCommonNode.eModel.KEITHLEY_K7001)
                                '  End If

                            Next
                        Else
                            cSwitch = Nothing
                        End If

                    Case frmConfigSystem.eDeviceItem.eBCR
                        If g_ConfigInfos.BCRConfig Is Nothing = False Then
                            'tlBCR.Visible = True
                            ReDim cBCR(g_ConfigInfos.BCRConfig.Length - 1)

                            For idx As Integer = 0 To cBCR.Length - 1
                                cBCR(idx) = New CDevVoyager1250

                                AddHandler cBCR(idx).evRecieveData, AddressOf BCRInfo_ChangedValue
                            Next
                        Else
                            cBCR = Nothing
                        End If

                    Case frmConfigSystem.eDeviceItem.eStrobe
                        If g_ConfigInfos.StrobeConfig Is Nothing = False Then
                            ReDim cStrobe(g_ConfigInfos.StrobeConfig.Length - 1)

                            For idx As Integer = 0 To cStrobe.Length - 1
                                cStrobe(idx) = New CDevStrobe
                            Next
                        Else
                            cStrobe = Nothing
                        End If
                    Case frmConfigSystem.eDeviceItem.eDMM
                        If g_ConfigInfos.DMMConfig Is Nothing = False Then
                            ReDim cDMM(g_ConfigInfos.DMMConfig.Length - 1)

                            For Idx As Integer = 0 To cDMM.Length - 1
                                cDMM(Idx) = New CDevDMM6500
                            Next
                        Else
                            cDMM = Nothing
                        End If
                End Select
            Next

            '======Create Device Component Object==========================================================
            'PG Object Create
            'it confirm the information for PG object creation
            If g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._McPG Then
                If g_ConfigInfos.PGConfig.McPGGroup Is Nothing = True Then
                    Return False
                End If
            End If

            'PG Object creation
            If g_ConfigInfos.PGConfig.nDeviceType <> CDevPGCommonNode.eDevModel._Nothing Then
                cPG = New CDevPGAPI(Me, PGInitInfo)
            End If

            '====================================================================
            'If g_ConfigInfos.PGConfig.McPGGroup Is Nothing = False Then
            '    ReDim cMCPG(g_ConfigInfos.PGConfig.McPGGroup.Length - 1)
            '    For i As Integer = 0 To g_ConfigInfos.PGConfig.McPGGroup.Length - 1
            '        cMCPG(i) = New CSeqRoutineMcPG(Me, PGInitInfo.sMcPGConfig(i))
            '    Next
            'End If
            '=====================================================================

            'M6000 Object Create
            If g_ConfigInfos.M6000Config Is Nothing = False Then
                If cM6000 Is Nothing = False Then
                    For i As Integer = 0 To cM6000.Length - 1
                        cM6000(i) = New CSeqRoutineM6000(i, g_ConfigInfos.M6000Config(i).numberOfBoard, g_ConfigInfos.M6000Config(i).nAllocationCh_From, Me)
                        AddHandler cM6000(i).evAlarm, AddressOf M6000_Alarm
                    Next
                End If
            End If

            'If g_ConfigInfos.MC9Config Is Nothing = False Then
            '    For i As Integer = 0 To cMC9.Length - 1
            '        cMC9(i) = New CSeqRoutineMC9(g_ConfigInfos.MC9Config(i).numberOfDevice, g_ConfigInfos.MC9Config(i).nSeedAddress)
            '    Next
            'End If

            'If g_ConfigInfos.NX1Config Is Nothing = False Then
            '    For i As Integer = 0 To cNX1.Length - 1
            '        cNX1(i) = New CDevNX1
            '    Next
            'End If


            'If g_ConfigInfos.PGConfig Is Nothing = False Then
            '    For i As Integer = 0 To cPG.Length - 1
            '        cPG(i) = New cDevPG
            '    Next
            'End If

            'If g_ConfigInfos.PGPwrConfig Is Nothing = False Then
            '    For i As Integer = 0 To cPGPower.Length - 1
            '        cPGPower(i) = New cDevPGPower
            '    Next
            'End If

            'If g_ConfigInfos.PGCtrlBDConfig Is Nothing = False Then
            '    For i As Integer = 0 To cPGCtrl.Length - 1
            '        cPGCtrl(i) = New cDevPGControl
            '    Next
            'End If

            'SG Object Create
            If g_ConfigInfos.SGConfig Is Nothing = False Then

                Dim initParam As CDevSG.sInitialParam
                Dim nNumOfDACCh As Integer = CDevSG.Max_DAC_Channel / 2
                Dim nNumOfADCCh As Integer = CDevSG.Max_ADC_Channel

                ReDim initParam.dDACMaxValue(nNumOfDACCh - 1)
                For i As Integer = 0 To nNumOfDACCh - 1
                    If i >= 0 And i <= 25 Then
                        initParam.dDACMaxValue(i) = 15
                    ElseIf i > 25 And i <= 37 Then
                        initParam.dDACMaxValue(i) = 18
                    Else
                        initParam.dDACMaxValue(i) = 25
                    End If
                Next

                ReDim initParam.dADCMaxValue(nNumOfADCCh - 1)

                For i As Integer = 0 To nNumOfADCCh - 1
                    '사용 목적에 따라, 온도, 전류, PD 전류 측정 용으로 구분해야 하며, 각각의 전류 최대치를 설정해야 한다.
                    If i >= 0 And i <= 23 Then  'PD 전류 측정 채널
                        initParam.dADCMaxValue(i) = 100 'uA 단위, Max = +- 100uA
                    ElseIf i >= 24 And i <= 39 Then '온도 측정 채널
                        initParam.dADCMaxValue(i) = 150 '도씨 단위
                    Else '전류 측정 채널
                        initParam.dADCMaxValue(i) = 1  'A 단위, +-1A
                    End If
                Next

                If cMcSG Is Nothing = False Then
                    For i As Integer = 0 To cMcSG.Length - 1
                        cMcSG(i) = New CSeqRoutineSG(Me, g_ConfigInfos.SGConfig(i).numberOfDevice, g_ConfigInfos.SGConfig(i).nSeedAddress, g_ConfigInfos.SGConfig(i).nAllocationCh_From, initParam)
                    Next
                End If

            End If
            '================================================================================================

            cPLCScheduler = New CSheduler_PLC(Me)
            cTimeScheduler = New CScheduler(Me)
            cQueueProcessor = New CSeqProcessor(Me)
            cState = New CStateInfo(Me)
            'cMeasurementor = New CDataAcquistor(Me)



            'Dim tempSchedulerState(g_nMaxCh - 1) As CScheduler.eChSchedulerSTATE
            'SystemInfo.LastSchedulerState = tempSchedulerState.Clone
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

#End Region

#Region "Frame Event Handler Functions"


    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'LastRecipeDataSave()
        If MsgBox("Exit SW. Please check if all channels are stopped. Data may be corrupted if the SW ends during measurement.", MsgBoxStyle.OkCancel, g_strMainTitle) = MsgBoxResult.Cancel Then
            e.Cancel = True
        Else

            If g_SystemInfo.isConnected = True Then

                'If cPLCScheduler Is Nothing = False Then
                '    cPLCScheduler.StopTrdPLC()
                'End If

                Application.DoEvents()
                Thread.Sleep(200)

                'g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_MOTION_CONNECTED_FAILURE, "plc stop fail")
                If cTimeScheduler Is Nothing = False Then
                    cTimeScheduler.StopTrdTimer()
                End If

                Application.DoEvents()
                Thread.Sleep(50)


                If cState Is Nothing = False Then
                    cState.StopTrdTimer()
                End If

                Application.DoEvents()
                Thread.Sleep(50)

                If cQueueProcessor Is Nothing = False Then
                    cQueueProcessor.StopTrdProcess()
                End If

                DisconnectToDevice()

                'Vision
                If cVision Is Nothing = False Then
                    ' g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_MOTION_CONNECTED_FAILURE, "Vision0")
                    cVision.myVisionCamera.GrabStop()
                    ' g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_MOTION_CONNECTED_FAILURE, "Vision1")
                    Thread.Sleep(2000)
                    cVision.myVisionCamera.Dispose()
                    'g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_MOTION_CONNECTED_FAILURE, "Vision2")
                End If

                'Thread 종료 루틴 추가
                If cPG Is Nothing = False Then
                    cPG.Dispose()
                    'For i As Integer = 0 To cPG.PatternGenerator.Length - 1
                    '    cMCPG(i).Dispose()
                    'Next
                ElseIf cM6000 Is Nothing = False Then
                    For i As Integer = 0 To cM6000.Length - 1
                        cM6000(i).Dispose()
                    Next

                ElseIf cMcSG Is Nothing = False Then
                    For i As Integer = 0 To cMcSG.Length - 1
                        cMcSG(i).Dispose()
                    Next
                End If


                If cTC Is Nothing = False Then
                    For i As Integer = 0 To cTC.Length - 1
                        cTC(i).Dispose()
                    Next
                End If

                If cTCMC Is Nothing = False Then
                    For i As Integer = 0 To cTCMC.Length - 1
                        ' cTCMC(i).()
                    Next
                End If

                'Motion Servo OFF
                If cMotion Is Nothing = False Then
                    If cMotion.IsConnected = True Then
                        cMotion.SERVO_OFF()
                        ' cMotion.Disconnection()
                    End If
                End If

            Else
                If cVision Is Nothing = False Then
                    cVision.myVisionCamera.Dispose()
                End If
            End If

            ProcessKill()

        End If

    End Sub


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        g_SystemInfo.dispMode = eFrameMode.eControlUIOfJIGLayout

        ' LoadLastRecipeData()

        '초기 상태값 추가. 2013-04-03 승현
        '   SystemInfo.bIsShowMessageAlram = True

        ' m_bIsLoaded = True



        '  LoadLastSequenceFile()

        g_SystemInfo.m_ChannelCheckMethod = eChannelCheckMethod.Each_Ch

        g_SystemInfo.bIsShowMessageAlram = True
        tsBtnCare.BackColor = Color.Orange
        g_SystemOptions.bEnableAlarm = True
        tsBtnAlarm.BackColor = Color.OrangeRed

        '  tsBtnMainUIMode.BackColor = Color.LightYellow
        '  tsBtnDataListViewMode.BackColor = Color.Transparent

        m_bIsLoaded = True

        If File.Exists(g_sPATH_SYSTEM_LOG) = False Then
            Directory.CreateDirectory(g_sPATH_SYSTEM_LOG)
        End If

        '  Dim fs As System.IO.FileStream

        '  fs = File.Create(g_sFilePath_SystemLog)
        '  fs.Close()
        If g_SystemOptions.sOptionData.SystemAdmin.bLogInStatus = True Then
            ItemVisibleHide(True)
        Else
            ItemVisibleHide(False)
        End If

        ' frmOptionWindow.LoadSystemOption(sSystemOption)

        '  CUnitConverter.GetCaptionAndUnit("", sSystemOption.DispGroup.dispVolt)

        'CUnitConverter.GetCaptionAndUnit(Label1, sSystemOption.DispGroup.dispCurrent, Label1.Text)
        'CUnitConverter.updateDispUnit(Label1, sSystemOption.DispGroup.dispVolt)

        'CUnitConverter.updateDispUnit(Label1, sSystemOption.DispGroup.dispVolt)
        'str = Label1.Text


        ''자리수 출력
        'str = CUnitConverter.ValueConvertToFormatted(sSystemOption.DispGroup.dispVolt, "2.3333333")
        'str2 = CUnitConverter.ValueConvertToFormatted(sSystemOption.DispGroup.dispCurrent, "1.2222222")

        '  cScreenCapture = New cScreenCapture

        KeyPreview = True

    End Sub

    Dim CalData(,) As String = Nothing

    Public Function CalculatePDCd(ByVal nCh As Integer) As Double
        Dim ChannelBuff() As String
        Dim PDCurr As Double = 0.5
        Dim x As Double
        Dim y As Double
        Dim cnt As Integer = 0

        x = PDCurr
        y = 0

        ReDim ChannelBuff(g_CalDegree)

        For idx As Integer = ChannelBuff.Length - 1 To 0 Step -1
            ChannelBuff(cnt) = CalData(idx, nCh)

            y = y + (x ^ cnt * CDbl(ChannelBuff(cnt)))
            cnt = cnt + 1
        Next

        Return y
    End Function

    Private Sub frmMain_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        FitChilFrame()
    End Sub

    Public Sub LoadLastSequenceFile(ByVal nCh As Integer)

        '  If SystemInfo.dispMode = eFrameMode.eControlUIOfCustomTypeForQC Then
        If frmControlUI Is Nothing Then Exit Sub

        ' For i As Integer = 0 To g_nMaxCh - 1

        g_SystemInfo.bIsLoadedLastSequence(nCh) = frmControlUI.ControlUI.control.LoadDefaultSequence(nCh)
        ' SystemInfo.bIsLoadedLastRecipe(i) = frmControlTwoStpeCyle.target(i).LoadDefaultRecipe()
        ' Next

        'ElseIf SystemInfo.dispMode = eFrameMode.eControlUIOfListTypeForQC Then
        '    Dim SeqInfo As CSequenceManager.sSequenceInfo = Nothing

        '    For idx As Integer = 0 To g_nMaxCh - 1

        '    Next
        'End If

    End Sub

#Region "Function"



    Private Function InitChildFrame() As Boolean

        Try
            Dim Size_H, Size_W As Double
            frmLog = New frmLogWin(g_nMaxCh)

            frmControlUI = New frmCtrlUI(g_nMaxCh, g_SystemSettings.DisplayMode)
            frmControlUI.Visible = False
            frmControlUI.MdiParent = Me
            frmControlUI.myParent = Me
            frmControlUI.Location = New System.Drawing.Point(0, 0)
            frmControlUI.Size = New System.Drawing.Size(Size_W, Size_H)
            frmControlUI.Dock = DockStyle.Fill
            frmControlUI.ShowFrame()

            frmMonitorUI = New frmMonitorUIOfGeneralType(g_nMaxCh) ' g_nMaxCh)
            frmMonitorUI.Visible = False
            frmMonitorUI.fMain = Me
            frmMonitorUI.MdiParent = Me
            frmMonitorUI.Location = New System.Drawing.Point(0, 0)
            frmMonitorUI.Size = New System.Drawing.Size(Size_W, Size_H)
            frmMonitorUI.Dock = DockStyle.Fill

            '20160425_PSK
            frmMotionUI = New frmMotionUI(g_nMaxCh, Me) ' g_nMaxCh)
            frmMotionUI.Visible = False
            frmMotionUI.MdiParent = Me
            frmMotionUI.Location = New System.Drawing.Point(0, 0)
            frmMotionUI.Size = New System.Drawing.Size(Size_W, Size_H)
            frmMotionUI.Dock = DockStyle.Fill
            frmMotionUI.Enable_gbMotion(False)
            '  frmMotionUI.Enable_gbSourceCtrl(False)
            frmMotionUI.Enable_gbACFCameraCtrl(False)
            frmMotionUI.Enable_gbACFCtrl(False)
            frmMotionUI.Enable_gbACFMeas(False)

            frmPretestUI = New frmPretestUI(Me, g_nMaxCh) ' g_nMaxCh)
            frmPretestUI.Visible = False
            frmPretestUI.MdiParent = Me
            frmPretestUI.Location = New System.Drawing.Point(0, 0)
            frmPretestUI.Size = New System.Drawing.Size(Size_W, Size_H)
            frmPretestUI.Dock = DockStyle.Fill

            frmMotionUI.gbMotion.Enabled = False
            '  frmMotionUI.gbSourceCtrl.Enabled = False

            frmMessageUI = New frmMessage()
            frmMessageUI.Visible = False
            frmMessageUI.Location = New System.Drawing.Point(600, 400)
            frmMessageUI.ShowFrame()
            frmMessageUI.HideFrame()

            '  frmMotionUI.gbACFCameraCtrl.Enabled = False
            'frmMotionUI.gbACFCtrl.Enabled = False

            frmPretestUI.gbControl.Enabled = True   'Lex_20141021

            'PLC Alarm Add
            'frmPLCAlarm = New frmPLCAlarm()
            'frmPLCAlarm.MdiParent = Me
            'frmPLCAlarm.Location = New System.Drawing.Point(0, 0)
            'frmPLCAlarm.Dock = DockStyle.Fill
            'frmPLCAlarm.ShowFrame()
            'SplitContainer1.Panel2.Controls.Add(frmPLCAlarm)

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Sub FitChilFrame()

        If m_bIsLoaded = False Then Exit Sub

        Dim Size_H, Size_W As Double
        Size_H = Me.ClientSize.Height '- mainStatus.Height - mainMenu.Height - mainToolStrip.Height - 4
        Size_W = Me.ClientSize.Width - 4

        'If frmMonitorUI Is Nothing = False Then
        '    With frmMonitorUI
        '        .Location = New System.Drawing.Point(0, 0)
        '        .Size = New System.Drawing.Size(Size_W, Size_H)
        '    End With
        'End If

        'If frmMotionUI Is Nothing = False Then
        '    With frmMotionUI
        '        .Location = New System.Drawing.Point(0, 0)
        '        .Size = New System.Drawing.Size(Size_W, Size_H + 4)
        '        .AutoScroll = True
        '    End With
        'End If

        'If frmPretestUI Is Nothing = False Then
        '    With frmPretestUI
        '        .Location = New System.Drawing.Point(0, 0)
        '        .Size = New System.Drawing.Size(Size_W, Size_H)
        '    End With
        'End If

        'If frmControlUI Is Nothing = False Then
        '    With frmControlUI
        '        .Location = New System.Drawing.Point(0, 0)
        '        .Size = New System.Drawing.Size(Size_W, Size_H)
        '    End With
        'End If

        tlStatus.Size = New System.Drawing.Size(Size_W * 0.3, tlStatus.Size.Height)
        ''frmControlUI.ControlUI.Focus()
        '' frmControlUI.= True
    End Sub

#End Region

#End Region

#Region "Queue Control"

    Public Sub requestMeas(ByVal seq As CSeqProcessor.sProcessParams)

        SyncLock meas_queue.SyncRoot
            meas_queue.Enqueue(seq)
            If seq.cmd <> CSeqProcessor.eProcessState.LifeTimeMeas_Manual Then
                QueueCounter("Queue Counter = " & CStr(meas_queue.Count))
            End If

        End SyncLock
    End Sub

    Public Sub ManaulrequestMeas(ByVal seq As CSeqProcessor.sProcessParams)

        SyncLock meas_manualqueqe.SyncRoot
            meas_manualqueqe.Enqueue(seq)
            If seq.cmd = CSeqProcessor.eProcessState.LifeTimeMeas_Manual Then
                ManualQueueCounter("M_Queue Counter = " & CStr(meas_manualqueqe.Count))
            End If

        End SyncLock
    End Sub

    Public Sub deleteMeasQueue(ByVal in_Ch As Integer)

        Dim updateQueue As Queue = New Queue
        Dim i As Integer
        Dim seq As CSeqProcessor.sProcessParams

        SyncLock meas_queue.SyncRoot

            For i = 0 To meas_queue.Count - 1
                seq = meas_queue.Dequeue

                If seq.index <> in_Ch Then
                    updateQueue.Enqueue(seq)
                End If
            Next
            meas_queue.Clear()
            meas_queue = updateQueue.Clone()
            QueueCounter("Queue Counter = " & CStr(meas_queue.Count))
        End SyncLock

    End Sub

    Public Sub ManauldeleteMeasQueue()

        Dim updateQueue As Queue = New Queue
        Dim i As Integer
        Dim seq As CSeqProcessor.sProcessParams

        SyncLock meas_manualqueqe.SyncRoot

            'For i = 0 To meas_manualqueqe.Count - 1
            '    seq = meas_manualqueqe.Dequeue

            '    'If seq.index <> in_Ch Then
            '    '    updateQueue.Enqueue(seq)
            '    'End If
            'Next
            meas_manualqueqe.Clear()
            'meas_manualqueqe = updateQueue.Clone()
            ManualQueueCounter("M_Queue Counter = " & CStr(meas_manualqueqe.Count))
        End SyncLock

    End Sub
    Public Sub AutoRundeleteMeasQueue()

        Dim updateQueue As Queue = New Queue
        Dim i As Integer
        Dim seq As CSeqProcessor.sProcessParams

        SyncLock meas_queue.SyncRoot

            'For i = 0 To meas_manualqueqe.Count - 1
            '    seq = meas_manualqueqe.Dequeue

            '    'If seq.index <> in_Ch Then
            '    '    updateQueue.Enqueue(seq)
            '    'End If
            'Next
            meas_queue.Clear()
            'meas_manualqueqe = updateQueue.Clone()
            QueueCounter("Queue Counter = " & CStr(meas_queue.Count))
        End SyncLock

    End Sub
#End Region

#Region "프로세스 종료 관련"

    Private Function Process_Kill() As Boolean

        Dim ProcF As System.Diagnostics.Process
        Dim pList() As Process
        Dim FirstProcessId As Integer

        pList = Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)

        If pList.Length = 1 Then
            'Process ID Save
            Dim ProcessIDSaver As New COptionINI(g_sFilePath_ProcessID)

            If File.Exists(g_sFilePath_ProcessID) = True Then
                File.Delete(g_sFilePath_ProcessID)
            End If

            Try
                ProcessIDSaver.SaveIniValue(COptionINI.eSecID.eProcess, 0, COptionINI.eKeyID.PROCESSID, pList(0).Id)
            Catch ex As Exception
                Return False
            End Try
        Else
            'Process ID Load
            Dim ProcessIDLoader As New COptionINI(g_sFilePath_ProcessID)

            Try
                FirstProcessId = CInt(ProcessIDLoader.LoadIniValue(COptionINI.eSecID.eProcess, 0, COptionINI.eKeyID.PROCESSID))
            Catch ex As Exception
                Return False
            End Try
        End If


        For Each ProcF In pList
            ' Dim res As MsgBoxResult
            If pList.Length > 1 Then
                If FirstProcessId <> ProcF.Id Then
                    If MsgBox("[Warning] " & "(" & ProcF.ProcessName & ")" & " is in used. Terminate it or continuous use would case fatal errors.", MsgBoxStyle.OkOnly, g_strMainTitle) = MsgBoxResult.Ok Then
                        ProcF.Kill()
                        Return False
                    End If
                End If
            End If

        Next

        Return True
    End Function

    Private Sub ProcessKill()
        Dim proc As System.Diagnostics.Process
        Dim pList() As Process
        Dim sTest As String

        pList = Process.GetProcessesByName("M7000")

        If pList.Length = 0 Then
            pList = Process.GetProcessesByName("M7000.vshost")
            sTest = pList(0).ProcessName

        End If

        For Each proc In pList
            proc.Kill()
        Next

    End Sub

#End Region

#Region "Connection & Disconnection"

    Public Function Connection(ByVal mode As eConnectionMode) As Boolean
        Dim rst As Boolean
        '  HWConnectionToolStripMenu.Enabled = False
        '  SWConnectionToolStripMenu.Enabled = False
        '  tsBtnPCConnection.Enabled = False
        tsBtnConnection.Enabled = False

        If ConnectToDevice() = True Then

            '스레드(시작)
            '''''''20160601 CJS 잠시 주석   

            'If cPLC Is Nothing = False Then
            '    cPLCScheduler.StartTrdPLC()
            'End If


          

            cTimeScheduler.StartTrdTimer()

            cState.StartTrdTimer()

            cQueueProcessor.StartTrdProcess()

            frmMonitorUI.EnableDispUpdate = True
            'cMeasurementor.trdMeasStart()
            'ReDim g_MeasuredDatas(0).sSpectrometerData(0)

            rst = True
        Else
            '     tsBtnPCConnection.Enabled = True
            tsBtnConnection.Enabled = True

            DisconnectToDevice()
            rst = False
        End If

        g_SystemInfo.isConnected = rst

        '  If rst = True Then

        'MsgBox("CA310의 Zero-Cal. 상태 및 Sync. 모드 설정 상태를 확인하여 주십시오.", MsgBoxStyle.OkOnly, g_strMainTitle)

        '  End If

        '        aaa()

        '실제 통신 열결된 체널을 확인 하고 UI Enable or Disable
        UpdateChannelUI()


        '  SWConnectionToolStripMenu.Enabled = True
        '  HWConnectionToolStripMenu.Enabled = True
        '  tsBtnHWConnection.Enabled = True
        Return rst
    End Function


    Public Sub UpdateChannelUI()

        If g_SystemInfo.isConnected = False Then Exit Sub

        '  Dim nDevNo As Integer

        Dim nCnt As Integer = 0

        '문창윤 G4s 연결 상태 확인 해서 UI Enable 부분..... 정진욱 측은 M6000 확인해서 변경 해야 함...
        'For i As Integer = 0 To g_ConfigInfos.PGConfig.G4sConfig.iAllocationCh.Length - 1
        '    nDevNo = frmSettingWind.GetAllocationValue(g_ConfigInfos.PGConfig.G4sConfig.iAllocationCh(i), frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        '    If cPG.PatternGenerator(0).IsConnectedSubChannel(nDevNo) = True Then

        '        '  frmControlUI.ControlUI.control.dispJIG(g_ConfigInfos.PGConfig.G4sConfig.iAllocationCh(i)).Enabled = True
        '        frmControlUI.ControlUI.control.dispJIG(g_ConfigInfos.PGConfig.G4sConfig.iAllocationCh(i)).EnableUI = True
        '        nCnt += 1
        '    Else
        '        ' frmControlUI.ControlUI.control.dispJIG(g_ConfigInfos.PGConfig.G4sConfig.iAllocationCh(i)).Enabled = False
        '        frmControlUI.ControlUI.control.dispJIG(g_ConfigInfos.PGConfig.G4sConfig.iAllocationCh(i)).EnableUI = False
        '    End If
        'Next



        For dev As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
            If g_ConfigInfos.nDevice(dev) = frmConfigSystem.eDeviceItem.ePG Then
                If g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._McPG Then
                    If nCnt = g_nMaxCh Then
                        tlHWStatus(dev).BackColor = Color.Lime
                        tlHWStatus(dev).Text = "PG"
                    Else
                        tlHWStatus(dev).BackColor = Color.OrangeRed
                        tlHWStatus(dev).Text = CStr(nCnt)
                    End If

                End If
            End If
        Next

    End Sub

    Public Function ConnectToDevice() As Boolean
     
        'Return True
        Dim strMsg As String
        Dim ncount As Integer = 0

        For n As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
            tlHWStatus(n + ncount).BackColor = Color.Yellow

            Application.DoEvents()
            Thread.Sleep(10)

            Select Case g_ConfigInfos.nDevice(n)
                Case frmConfigSystem.eDeviceItem.eMotion

                    cMotion.Settings = g_ConfigInfos.MotionConfig
                    If cMotion.InitAxt() = False Then
                        tlHWStatus(n + ncount).BackColor = Color.Red
                        Return False
                    End If
                    cMotion.initMotion()
                    cMotion.InitVariableSet()

                    Application.DoEvents()
                    Thread.Sleep(1000)

                    cMotion.SERVO_ON()

                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_HOMMING)

                    cMotion.Homming(False)
                    cMotion.MoveCompletedAllAxis()

                    '아진에서 홈센서를 인식하고 바로 정지하지 않고 밀려서 정지가 되서 홈센서를 지나쳐 버림....그래서 홈 다시 찾기. 
                    '맨 처음 홈 찾을 때는 속도를 빠르게 하고 두번째 부터는 홈에서 20mm,20mm,10mm(X,Y,Z) 떨어진 거리에서 속도를 50으로 천천히 움직이면서 찾는다.
                    cMotion.Homming()
                    cMotion.MoveCompletedAllAxis()

                    tlHWStatus(n + ncount).BackColor = Color.LimeGreen

                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_HOMMING_END)

                Case frmConfigSystem.eDeviceItem.eStrobe
                    If g_ConfigInfos.StrobeConfig Is Nothing Then Return False

                    For i As Integer = 0 To g_ConfigInfos.StrobeConfig.Length - 1
                        If cStrobe(i).Connection(g_ConfigInfos.StrobeConfig(i).settings) = False Then
                            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_STROBE_CONNECTED_FAILURE, "[Device = " & CStr(i + 1) & "]")
                            tlHWStatus(n + ncount).BackColor = Color.Red
                        Else
                            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_STROBE_CONNECTED, "[Device = " & CStr(i + 1) & "]")
                            tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                        End If

                        Application.DoEvents()
                        Thread.Sleep(10)
                    Next

                Case frmConfigSystem.eDeviceItem.eSMU_M6000

                    If g_ConfigInfos.M6000Config Is Nothing Then Return False

                    For i As Integer = 0 To g_ConfigInfos.M6000Config.Length - 1
                        tlHWStatus(g_nHWM6000StartIndex + i).BackColor = Color.Yellow
                        If cM6000(i).Connection(g_ConfigInfos.M6000Config(i).settings) = False Then
                            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_M6000_ConnectionFailed, "[Device = " & CStr(i + 1) & "]")
                            tlHWStatus(g_nHWM6000StartIndex + i).BackColor = Color.Red
                            'Return False
                        Else
                            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_M6000_Connected, "[Device = " & CStr(i + 1) & "]")
                            tlHWStatus(g_nHWM6000StartIndex + i).BackColor = Color.LimeGreen
                        End If

                        Application.DoEvents()
                        Thread.Sleep(10)
                        If ncount <> g_ConfigInfos.M6000Config.Length - 1 Then
                            ncount += 1
                        End If
                    Next
                    '  tlHWStatus(n).BackColor = Color.LimeGreen

                Case frmConfigSystem.eDeviceItem.ePLC
                    Dim Reqinfo As CDevPLCCommonNode.sRequestInfo = Nothing
                    Dim EQPStatus() As CDevPLCCommonNode.eEQPStatus = Nothing
                    ' Reqinfo.nEQPStatus = CDevPLCCommonNode.eEQPStatus.eRun
                    If cPLC.Connection(g_ConfigInfos.PLCConfig(0).settings) = False Then
                        tlHWStatus(n + ncount).BackColor = Color.Red
                        'Return False
                    Else


                        '연결 시 Homming 진행, 별도의 homming은 없고 0위치로 보낸다. y축의 경우 homming 위치에 따라 원점 위치를 바꿔줘야한다
                        'y축은 현재 5가 원점으로 잡혀있으므로 5mm로 보냄
                        'frmMotionUI.XMove(0, g_ConfigInfos.MotionConfig(0).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
                        'Thread.Sleep(10)
                      
                        'frmMotionUI.YMove(0, g_ConfigInfos.MotionConfig(0).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
                        'Thread.Sleep(10)

                        'frmMotionUI.ZMove(0, g_ConfigInfos.MotionConfig(1).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)
                        'Thread.Sleep(10)
                        Thread.Sleep(1000)
                        Application.DoEvents()
                        'Do
                        '    Thread.Sleep(10)
                        '    Application.DoEvents()

                        'Loop Until cPLC.ConnectCount = 2
                        Dim bAutoMode As Boolean = False
                        For i As Integer = 0 To cPLC.m_PLCDatas.nSystemStatus.Length - 1
                            If cPLC.m_PLCDatas.nSystemStatus(i) = CDevPLCCommonNode.eSystemStatus.eAuto_Mode Then
                                bAutoMode = True
                            End If
                        Next

                        If bAutoMode = False Then
                            If cPLC.SetChangeMode(CDevPLCCommonNode.eRunningMode.eAuto) = False Then
                                MsgBox("Auto Mode로 변경할 수 없습니다. Key Switch 상태를 확인해주시기 바랍니다.")
                                Return False
                            End If
                        End If

                        Thread.Sleep(100)
                        Application.DoEvents()
                        cPLC.GetEQPStatue(EQPStatus)
                        If EQPStatus(0) <> CDevPLCCommonNode.eEQPStatus.eStop Then
                            Reqinfo.nEQPStatus = CDevPLCCommonNode.eEQPStatus.eStop
                            cPLC.SetEQPStatus(Reqinfo)
                        End If

                        Thread.Sleep(500)
                        Application.DoEvents()
                        Reqinfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
                        Reqinfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eAll_Reset
                        Reqinfo.Param = Nothing
                        cPLC.Request(Reqinfo)

                        cPLC.CanAllReset = False

                        Do
                            Thread.Sleep(100)
                            Application.DoEvents()
                        Loop Until cPLC.Reset = True And cPLC.CanAllReset = True

                        Thread.Sleep(500)
                        Application.DoEvents()

                        Reqinfo.nEQPStatus = CDevPLCCommonNode.eEQPStatus.eRun
                        cPLC.SetEQPStatus(Reqinfo)
                        tlHWStatus(n + ncount).BackColor = Color.LimeGreen


                        'frmMotionUI.SetPositionXYAxisMovingFirst("0,0,500,300")
                        'Application.DoEvents()
                        'Thread.Sleep(100)
                        'frmMotionUI.Theta1Move(90, 10, CDevPLCCommonNode.eMovingMethod.eABS)


                    End If

                    'Component 추가
                Case frmConfigSystem.eDeviceItem.eSpectroradiometer
                    If g_ConfigInfos.SpectrometerConfig Is Nothing = False Then
                        For i As Integer = 0 To g_ConfigInfos.SpectrometerConfig.Length - 1
                            cSpectormeter(i).mySpectrometer.CalReadUsed = False
                            cSpectormeter(i).mySpectrometer.CloseUpLenseUsed = True
                            cSpectormeter(i).mySpectrometer.ExposureTime = g_SystemOptions.sOptionData.IVLSpectrometer.nExposureTime

                            If cSpectormeter(i).mySpectrometer.Connection(g_ConfigInfos.SpectrometerConfig(i).settings) = False Then
                                tlHWStatus(n + ncount).BackColor = Color.Red
                                'Return False
                            Else
                                Dim sData As String = Nothing

                                If cSpectormeter(i).mySpectrometer.Model = CDevSpectrometerCommonNode.eModel.SPECTROMETER_DarsaPro Then
                                    If cSpectormeter(i).mySpectrometer.DarkMeasure() = False Then
                                        tlHWStatus(n + ncount).BackColor = Color.Red
                                        'Return False
                                    End If
                                Else
                                    If cSpectormeter(i).mySpectrometer.StartApertureChange = False Then
                                        tlHWStatus(n + ncount).BackColor = Color.Red
                                        'Return False
                                    Else
                                        tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                                        g_ConnectedSpectrometer = True
                                    End If

                                    If cSpectormeter(i).mySpectrometer.GetDeviceInfos(g_SystemOptions.sDeviceOption.sSpectrometer) = False Then
                                        tlHWStatus(n + ncount).BackColor = Color.Red
                                        'Return False
                                    Else
                                        tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                                        g_ConnectedSpectrometer = True
                                    End If
                                End If
                            End If
                        Next

                        'tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                        'g_ConnectedSpectrometer = True             '명구
                    End If

                Case frmConfigSystem.eDeviceItem.eColorAnalyzer
                    If g_ConfigInfos.ColorAnalyzerConfig Is Nothing = False Then

                        For i As Integer = 0 To g_ConfigInfos.ColorAnalyzerConfig.Length - 1

                            'ConnectToColorAnalyzer(i, g_ConfigInfos.ColorAnalyzerConfig(i).settings, settings)
                            If cColorAnalyzer(i).myColorAnalyzer.Connection() = False Then
                                tlHWStatus(n + ncount).BackColor = Color.Red
                                'Return False
                            Else

                                If GetHexaSettings(i, cColorAnalyzer(i).myColorAnalyzer.DeviceInfos) = False Then
                                    tlHWStatus(n + ncount).BackColor = Color.Red
                                    'Return False
                                Else
                                    If SetHexaSettings(i, cColorAnalyzer(i).myColorAnalyzer.DeviceInfos) = False Then
                                        tlHWStatus(n + ncount).BackColor = Color.Red
                                        'Return False
                                    Else
                                        tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                                    End If
                                End If
                            End If
                        Next

                    End If

                Case frmConfigSystem.eDeviceItem.eSMU_IVL
                    If g_ConfigInfos.SMUForIVLConfig Is Nothing = False Then
                        For i As Integer = 0 To g_ConfigInfos.SMUForIVLConfig.Length - 1
                            If cIVLSMU(i).mySMU.Connection(g_ConfigInfos.SMUForIVLConfig(i).settings) = False Then
                                tlHWStatus(n + ncount).BackColor = Color.Red
                                'Return False
                            Else
                                cIVLSMU(i).mySMU.OutputOff()    '연결시 outputoff
                                tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                            End If
                        Next
                    End If
                Case frmConfigSystem.eDeviceItem.eSwitch
                    If g_ConfigInfos.SwitchConfig Is Nothing = False Then
                        For i As Integer = 0 To g_ConfigInfos.SwitchConfig.Length - 1
                            If cSwitch(i).mySwitch.Connection(g_ConfigInfos.SwitchConfig(i).settings) = False Then
                                tlHWStatus(n + ncount).BackColor = Color.Red
                                'Return False
                            Else
                                '처음 연결 시 모드 OFF시킴.
                                'For ch As Integer = 0 To g_nMaxCh - 1
                                '    cSwitch(i).mySwitch.SwitchOFF(ch)
                                'Next

                                'LT는 다시 킨다.
                                'For ch As Integer = 0 To g_nMaxCh - 1
                                '    cSwitch(i).mySwitch.SwitchON(ch + 64)
                                'Next
                                tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                            End If
                        Next

                    End If

                Case frmConfigSystem.eDeviceItem.eDMM
                    If g_ConfigInfos.DMMConfig Is Nothing = False Then
                        For i As Integer = 0 To g_ConfigInfos.DMMConfig.Length - 1
                            If cDMM(i).Connection(g_ConfigInfos.DMMConfig(i).settings) = False Then
                                tlHWStatus(n + ncount).BackColor = Color.Red
                            Else
                                '값 변동이 없으므로 처음연결할 때 init진행
                                Dim s_Setting As CDevDMM6500.sSetting = Nothing
                                s_Setting.CurrentAutoRange = True
                                s_Setting.MeasureDelayAuto = True
                                s_Setting.nCurrentRangeIndex = 0
                                s_Setting.nVoltageRangeIndex = 0
                                s_Setting.MeasureDelay_Sec = 0.1
                                s_Setting.IntegTime_Sec = 1
                                s_Setting.NumOfMeasData = 100
                                s_Setting.TerminalMode = CDevDMM6500.eTerminalMode.eRear
                                If cDMM(i).InitializeSweep(s_Setting) = True Then
                                    tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                                Else
                                    tlHWStatus(n + ncount).BackColor = Color.Red
                                End If
                            End If
                        Next
                    End If

                Case frmConfigSystem.eDeviceItem.eTC
                    If g_ConfigInfos.TCConfig Is Nothing = False Then
                        For i As Integer = 0 To g_ConfigInfos.TCConfig.Length - 1
                            Application.DoEvents()
                            Thread.Sleep(10)
                            If g_ConfigInfos.TCConfig(i).device <> 6 Then
                                If cTC(i).Connection(g_ConfigInfos.TCConfig(i).settings) = False Then
                                    DisconnectToDevice()  '간혹 연결이 안될 경우가 생김...why?  TTM004  확인 필요 임시방편

                                    If cTC(i).Connection(g_ConfigInfos.TCConfig(i).settings) = False Then
                                        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_TC_ConnectionFailed, "[Device = " & CStr(i + 1) & "]")
                                        tlHWStatus(n + ncount).BackColor = Color.Red
                                        'Return False
                                    Else
                                        tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                                        For j = g_ConfigInfos.TCConfig(i).nAllocationCh_From To g_ConfigInfos.TCConfig(i).nAllocationCh_To
                                            frmControlUI.ControlUI.control.dispJIG(j).VisibleTemp = True
                                        Next
                                    End If

                                    ''   g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_TC_ConnectionFailed, "[Device = " & CStr(i + 1) & "]")
                                    ''  tlHWStatus(n).BackColor = Color.Red
                                    ''  Return False
                                Else
                                    tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                                    For j = g_ConfigInfos.TCConfig(i).nAllocationCh_From To g_ConfigInfos.TCConfig(i).nAllocationCh_To
                                        frmControlUI.ControlUI.control.dispJIG(j).VisibleTemp = True
                                    Next
                                End If
                            Else
                                If cTCMC(i).Connection(g_ConfigInfos.TCConfig(i).settings) = False Then
                                    'DisconnectToDevice()  '간혹 연결이 안될 경우가 생김...why?  TTM004  확인 필요 임시방편

                                    If cTCMC(i).Connection(g_ConfigInfos.TCConfig(i).settings) = False Then
                                        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_TC_ConnectionFailed, "[Device = " & CStr(i + 1) & "]")
                                        tlHWStatus(n + ncount).BackColor = Color.Red
                                        'Return False
                                    Else
                                        tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                                        For j = g_ConfigInfos.TCConfig(i).nAllocationCh_From To g_ConfigInfos.TCConfig(i).nAllocationCh_To
                                            frmControlUI.ControlUI.control.dispJIG(j).VisibleTemp = True
                                        Next
                                    End If

                                    ''   g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_TC_ConnectionFailed, "[Device = " & CStr(i + 1) & "]")
                                    ''  tlHWStatus(n).BackColor = Color.Red
                                    ''  Return False
                                Else
                                    tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                                    'For j = g_ConfigInfos.TCConfig(i).nAllocationCh_From To g_ConfigInfos.TCConfig(i).nAllocationCh_To
                                    '    frmControlUI.ControlUI.control.dispJIG(j).VisibleTemp = True

                                    'Next
                                End If
                            End If


                            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_TC_Connected, "[Device = " & CStr(i + 1) & "]")
                        Next
                    End If


                    'Case frmConfigSystem.eDeviceItem.eTHC_98585
                    '    'If cTHC98585.Connection(g_ConfigInfos.THC98585) = False Then
                    '    '    Return False
                    '    'End If
                Case frmConfigSystem.eDeviceItem.eCamera
                    strMsg = ""
                    Dim sAttribute() As String = Nothing

                    If cVision.myVisionCamera.InitAllied(strMsg) = True Then


                        If cVision.myVisionCamera.GetAttributeList(sAttribute) = False Then
                            g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_ACF_CAMERA_ConnectionFailed)
                            Return False
                        End If

                        If cVision.myVisionCamera.SetAttributeValue("ExposureValue", g_SystemOptions.sOptionData.CCDData.dCCDExposureValue, "", Nothing) = False Then
                            g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_ACF_CAMERA_ConnectionFailed)
                            Return False
                        End If

                        'Trigger Mode 추가
                        If cVision.myVisionCamera.SetAttributeValue("FrameStartTriggerMode", 0, "Freerun", Nothing) = False Then
                            g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_ACF_CAMERA_ConnectionFailed)
                            Return False
                        End If

                        cVision.myVisionCamera.DispControlFit()

                        cVision.myVisionCamera.GrabStart()
                        tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                        g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_ACF_CAMERA_Connected)
                    Else
                        tlHWStatus(n + ncount).BackColor = Color.Red
                        g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_ACF_CAMERA_ConnectionFailed)
                        'Return False
                    End If




                Case frmConfigSystem.eDeviceItem.eBCR
                    If cBCR Is Nothing = False Then
                        For i As Integer = 0 To g_ConfigInfos.BCRConfig.Length - 1

                            If cBCR(i).Connection(g_ConfigInfos.BCRConfig(i).settings) = False Then
                                tlHWStatus(n + ncount).BackColor = Color.Red
                                'Return False
                            End If
                        Next

                        tlHWStatus(n + ncount).BackColor = Color.LimeGreen

                    End If

                Case frmConfigSystem.eDeviceItem.ePG

                    If g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._McPG Then

                        'If g_ConfigInfos.PGConfig.McPGGroup Is Nothing = False Then
                        '    Dim PGCommInfo(g_ConfigInfos.PGConfig.McPGGroup.Length - 1) As CSeqRoutineMcPG.sCommInfo
                        '    For i As Integer = 0 To g_ConfigInfos.PGConfig.McPGGroup.Length - 1

                        '        PGCommInfo(i).bEnablePGCtrlBD = g_ConfigInfos.PGConfig.McPGGroup(i).bEnablePGCtrl
                        '        PGCommInfo(i).sPGCtrl = g_ConfigInfos.PGCtrlBDConfig(g_ConfigInfos.PGGroup(i).nPGCtrlBDNo).sSerialInfo

                        '        PGCommInfo(i).bEnablePGPwr = g_ConfigInfos.PGGroup(i).bEnablePGPwr
                        '        PGCommInfo(i).sPGPwr = g_ConfigInfos.PGPwrConfig(g_ConfigInfos.PGGroup(i).nPGPwrNo).sSerialInfo


                        '        PGCommInfo(i).bEnablePG = g_ConfigInfos.PGGroup(i).bEnablePG
                        '        If PGCommInfo(i).bEnablePG = True Then
                        '            ReDim PGCommInfo(i).sPG(g_ConfigInfos.PGGroup(i).nPGNo.Length - 1)

                        '            For k As Integer = 0 To g_ConfigInfos.PGGroup(i).nPGNo.Length - 1
                        '                PGCommInfo(i).sPG(k) = g_ConfigInfos.PGConfig(g_ConfigInfos.PGGroup(i).nPGNo(k)).settings
                        '            Next
                        '        Else
                        '            PGCommInfo(i).sPG = Nothing
                        '        End If


                        '        PGCommInfo(i).bEnablePDUnit = g_ConfigInfos.PGGroup(i).bEnablePDUnit
                        '        If PGCommInfo(i).bEnablePDUnit = True Then
                        '            ReDim PGCommInfo(i).sPDUnit(g_ConfigInfos.PGGroup(i).nPDUnitNo.Length - 1)

                        '            For k As Integer = 0 To g_ConfigInfos.PGGroup(i).nPDUnitNo.Length - 1
                        '                PGCommInfo(i).sPDUnit(k) = g_ConfigInfos.PDMeasurementUnit(g_ConfigInfos.PGGroup(i).nPDUnitNo(k)).sSerialInfo
                        '            Next
                        '        Else
                        '            PGCommInfo(i).sPDUnit = Nothing
                        '        End If

                        '        If cMCPG(i).Connection(PGCommInfo(i)) = False Then
                        '            tlHWStatus(n).BackColor = Color.Red
                        '            Return False
                        '        Else
                        '            tlHWStatus(n).BackColor = Color.Lime
                        '        End If
                        '    Next
                        'End If

                    ElseIf g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._G4S Then
                        Dim sockInfo As CCommLib.CComSocket.sSockInfos = Nothing

                        sockInfo.sIPAddress = g_ConfigInfos.PGConfig.G4sConfig.sServerIP
                        sockInfo.nPort = g_ConfigInfos.PGConfig.G4sConfig.nServerPort

                        If cPG.Connection(sockInfo, g_ConfigInfos.PGConfig.G4sConfig.nServerOpenTime_sec) = False Then
                            tlHWStatus(n + ncount).BackColor = Color.Red

                            'Return False
                        Else
                            tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                        End If


                    End If
                Case frmConfigSystem.eDeviceItem.eMcSG
                    If g_ConfigInfos.SGConfig Is Nothing = False Then
                        For i As Integer = 0 To g_ConfigInfos.SGConfig.Length - 1

                            Application.DoEvents()
                            Thread.Sleep(10)

                            If cMcSG(i).Connection(g_ConfigInfos.SGConfig(i)) = False Then
                                tlHWStatus(n + ncount).BackColor = Color.Red
                                'Return False
                            Else
                                tlHWStatus(n + ncount).BackColor = Color.LimeGreen
                            End If
                        Next
                    End If
                Case frmConfigSystem.eDeviceItem.ePDMeasurement
                    'If cPDMeasureUnit.Connection(g_ConfigInfos.PDMeasurementUnit) = False Then0
                    '    Return False
                    'End If
            End Select
        Next

        Return True
    End Function

#Region "HEXA" '-이동/정리 필요 함

    Private Function GetHexaSettings(ByVal nDevNo As Integer, ByRef settings As CDevColorAnalyzerCommonNode.sSetInfos) As Boolean
        If cColorAnalyzer(nDevNo).myColorAnalyzer.Model = CDevColorAnalyzerCommonNode.eModel.eColorAnalyzer_HEXA50 Then
            LoadHEXA50Ini(settings)

            ReDim settings.sHEXA50Settings.CalibrationData(7)
            ReDim settings.sHEXA50Settings.SettingInfo(7)

            For i As Integer = 0 To 7
                With settings.sHEXA50Settings.CalibrationData(i)
                    If LoadCalibrationData(Application.StartupPath & g_sPATH_HEXAKFactorParam & "KFactor" & i & ".csv", .KFactor, .ReferenceData, .SensorData, .ElecOffset, .BWOffset, settings.sHEXA50Settings.SettingInfo(i)) = False Then
                    End If

                    settings.sHEXA50Settings.CalibrationData(i).KFactor = .KFactor.Clone
                    'UserKFactor = .KFactor.Clone
                End With
            Next

            'cColorAnalyzer(0).myColorAnalyzer.DeviceInfos.sHEXA50Settings.CalibrationData(0).KFactor() 'userKfactor
            'cColorAnalyzer(0).myColorAnalyzer.DeviceInfos.sHEXA50Settings.RangeValue() 'RangeValue
            If LoadRangeValue(Application.StartupPath & g_sPATH_HEXAKFactorParam & "RangeValue.csv", cColorAnalyzer(nDevNo).myColorAnalyzer.DeviceInfos.sHEXA50Settings.RangeValue) = True Then

            End If

            If LoadFitParam(settings.sHEXA50Settings.FitParam) = False Then Return False
        End If
        'cColorAnalyzer(nDevNo).myColorAnalyzer.DeviceInfos = settings

        cColorAnalyzer(nDevNo).myColorAnalyzer.OriginCalibration = settings

        Return True
    End Function

    Private Function SetHexaSettings(ByVal nDevNo As Integer, ByRef settings As CDevColorAnalyzerCommonNode.sSetInfos) As Boolean
        If settings.sHEXA50Settings.Range = CDevHEXA50.eRange.eAuto Then

            If cColorAnalyzer(nDevNo).myColorAnalyzer.SetSettings(settings) = True Then
                Return True
                'g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_Connected, "COA") = CStateMsg.eStateMsg.eSYSTEM_STATUS_Connected
            Else
                Return False
                'g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_ConnectionFailed, "COA") = CStateMsg.eStateMsg.eSYSTEM_STATUS_ConnectionFailed
            End If
        Else
            If cColorAnalyzer(nDevNo).myColorAnalyzer.SetSettingsOneRange(settings.sHEXA50Settings.Range + 2, settings) = True Then
                Return True
                'g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_Connected, "COA") = CStateMsg.eStateMsg.eSYSTEM_STATUS_Connected
            Else
                Return False
                'g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_ConnectionFailed, "COA") = CStateMsg.eStateMsg.eSYSTEM_STATUS_ConnectionFailed
            End If
        End If

        Return True
    End Function

    Public Function LoadFitParam(ByRef data() As CDevHEXA50.sFitParam) As Boolean
        If File.Exists(g_SPATH_Data & InIHEXA50FitParam) = False Then Return False

        Dim inicls As New cls_INI(g_SPATH_Data & InIHEXA50FitParam)
        Dim nCount As Integer = inicls.IniReadValue("FitParamRange", "Count")

        ReDim data(nCount - 1)

        For i As Integer = 0 To nCount - 1
            data(i).XFitA = inicls.IniReadValue("FitParamRange" & i + 1, "XA")
            data(i).XFitB = inicls.IniReadValue("FitParamRange" & i + 1, "XB")
            data(i).XFitC = inicls.IniReadValue("FitParamRange" & i + 1, "XC")
            data(i).XFitD = inicls.IniReadValue("FitParamRange" & i + 1, "XD")
            data(i).XFitE = inicls.IniReadValue("FitParamRange" & i + 1, "XE")
            data(i).XFitF = inicls.IniReadValue("FitParamRange" & i + 1, "XF")

            data(i).YFitA = inicls.IniReadValue("FitParamRange" & i + 1, "YA")
            data(i).YFitB = inicls.IniReadValue("FitParamRange" & i + 1, "YB")
            data(i).YFitC = inicls.IniReadValue("FitParamRange" & i + 1, "YC")
            data(i).YFitD = inicls.IniReadValue("FitParamRange" & i + 1, "YD")
            data(i).YFitE = inicls.IniReadValue("FitParamRange" & i + 1, "YE")
            data(i).YFitF = inicls.IniReadValue("FitParamRange" & i + 1, "YF")

            data(i).ZFitA = inicls.IniReadValue("FitParamRange" & i + 1, "ZA")
            data(i).ZFitB = inicls.IniReadValue("FitParamRange" & i + 1, "ZB")
            data(i).ZFitC = inicls.IniReadValue("FitParamRange" & i + 1, "ZC")
            data(i).ZFitD = inicls.IniReadValue("FitParamRange" & i + 1, "ZD")
            data(i).ZFitE = inicls.IniReadValue("FitParamRange" & i + 1, "ZE")
            data(i).ZFitF = inicls.IniReadValue("FitParamRange" & i + 1, "ZF")

            data(i).LFit = inicls.IniReadValue("FitParamRange" & i + 1, "L")
            data(i).xFit = inicls.IniReadValue("FitParamRange" & i + 1, "CIEX")
            data(i).yFit = inicls.IniReadValue("FitParamRange" & i + 1, "CIEY")
        Next

        Return True
    End Function

    Public Function LoadHEXA50Ini(ByRef sInfos As CDevHEXA50.sSetInfos) As Boolean
        If File.Exists(g_sPATH_CONFIG_DEVICE & InIHEXA50) Then
            Dim inicls As New cls_INI(g_sPATH_CONFIG_DEVICE & InIHEXA50)

            Try
                sInfos.sHEXA50Settings.Mode = inicls.IniReadValue("HEXA50", "Mode")
                sInfos.sHEXA50Settings.Range = inicls.IniReadValue("HEXA50", "Range")
            Catch ex As Exception

            End Try
            'Try
            '    With sInfos
            '        .sHEXA50Settings.IntegTime = inicls.IniReadValue("HEXA50", "IntegrationTime")
            '        .sHEXA50Settings.IntegTimeVal = inicls.IniReadValue("HEXA50", "IntegrationTime Value")
            '        .sHEXA50Settings.ReferenceCurrent = inicls.IniReadValue("HEXA50", "ReferenceCurrent")
            '        .sHEXA50Settings.Divider = inicls.IniReadValue("HEXA50", "Divider")
            '        .sHEXA50Settings.Offset = inicls.IniReadValue("HEXA50", "Offset")
            '        .sHEXA50Settings.Range = inicls.IniReadValue("HEXA50", "Range")
            '        .sHEXA50Settings.RangeIndex = inicls.IniReadValue("HEXA50", "RangeIndex")
            '    End With
            'Catch ex As Exception

            'End Try
        End If
        Return True
    End Function

    Public Function LoadRangeValue(ByVal sPath As String, ByRef Value() As Double) As Boolean

        Dim sLine As String
        Dim sbufData() As String = Nothing
        Dim nCount As Integer = 0
        ' Dim sbufDisData()() As String

        If File.Exists(sPath) = False Then
            '  MsgBox("Reference Data isn't exist")
            Return False
        End If
        FileOpen(1, sPath, OpenMode.Input)

        Do Until EOF(1)
            sLine = LineInput(1)
            ReDim Preserve Value(nCount)
            Value(nCount) = sLine
            nCount += 1
        Loop
        FileClose(1)
        Return True
    End Function

    Public Function LoadCalibrationData(ByVal sPath As String, ByRef Matrix(,) As Double, ByRef Target(,) As Double, ByRef sensor(,) As Double, ByRef elecOffset() As Double, ByRef bwOffset() As Double, ByRef config As CDevHEXA50.sSubSettings) As Boolean
        '    Dim row As Integer
        Dim column As Integer
        Dim sLine As String
        Dim sbufData() As String
        ' Dim sbufDisData()() As String

        Try
            If File.Exists(sPath) = False Then
                MsgBox("Calibration Data isn't exist")
                Return False
            End If
            FileOpen(1, sPath, OpenMode.Input)

            sLine = LineInput(1)
            If sLine.Substring(1, 6) <> "Header" Then
                MsgBox("Calibration Factor file is not correctly")
                Return False
            End If

            Do Until EOF(1)
                sLine = LineInput(1)
                If sLine = "" Then
                    Exit Do
                End If
                sbufData = sLine.Split(",")
                If sbufData(1) = CDevHEXA50.eMode.eCommand.ToString.TrimStart("e") Then
                    config.Mode = CDevHEXA50.eMode.eCommand
                ElseIf sbufData(1) = CDevHEXA50.eMode.eContinuous.ToString.TrimStart("e") Then
                    config.Mode = CDevHEXA50.eMode.eContinuous
                ElseIf sbufData(1) = CDevHEXA50.eIntegTime.e1ms.ToString.TrimStart("e") Then
                    config.IntegTime = CDevHEXA50.eIntegTime.e1ms
                    config.IntegTimeVal = 1
                ElseIf sbufData(1) = CDevHEXA50.eIntegTime.e2ms.ToString.TrimStart("e") Then
                    config.IntegTime = CDevHEXA50.eIntegTime.e2ms
                    config.IntegTimeVal = 2
                ElseIf sbufData(1) = CDevHEXA50.eIntegTime.e4ms.ToString.TrimStart("e") Then
                    config.IntegTime = CDevHEXA50.eIntegTime.e4ms
                    config.IntegTimeVal = 4
                ElseIf sbufData(1) = CDevHEXA50.eIntegTime.e8ms.ToString.TrimStart("e") Then
                    config.IntegTime = CDevHEXA50.eIntegTime.e8ms
                    config.IntegTimeVal = 8
                ElseIf sbufData(1) = CDevHEXA50.eIntegTime.e16ms.ToString.TrimStart("e") Then
                    config.IntegTime = CDevHEXA50.eIntegTime.e16ms
                    config.IntegTimeVal = 16
                ElseIf sbufData(1) = CDevHEXA50.eIntegTime.e32ms.ToString.TrimStart("e") Then
                    config.IntegTime = CDevHEXA50.eIntegTime.e32ms
                    config.IntegTimeVal = 32
                ElseIf sbufData(1) = CDevHEXA50.eIntegTime.e64ms.ToString.TrimStart("e") Then
                    config.IntegTime = CDevHEXA50.eIntegTime.e64ms
                    config.IntegTimeVal = 64
                ElseIf sbufData(1) = CDevHEXA50.eIntegTime.e128ms.ToString.TrimStart("e") Then
                    config.IntegTime = CDevHEXA50.eIntegTime.e128ms
                    config.IntegTimeVal = 128
                ElseIf sbufData(1) = CDevHEXA50.eIntegTime.e256ms.ToString.TrimStart("e") Then
                    config.IntegTime = CDevHEXA50.eIntegTime.e256ms
                    config.IntegTimeVal = 256
                ElseIf sbufData(1) = CDevHEXA50.eIntegTime.e512ms.ToString.TrimStart("e") Then
                    config.IntegTime = CDevHEXA50.eIntegTime.e512ms
                    config.IntegTimeVal = 512
                ElseIf sbufData(1) = CDevHEXA50.eIntegTime.e1024ms.ToString.TrimStart("e") Then
                    config.IntegTime = CDevHEXA50.eIntegTime.e1024ms
                    config.IntegTimeVal = 1024
                ElseIf sbufData(1) = CDevHEXA50.eRefCurrent.e20.ToString.TrimStart("e") Then
                    config.ReferenceCurrent = CDevHEXA50.eRefCurrent.e20
                ElseIf sbufData(1) = CDevHEXA50.eRefCurrent.e80.ToString.TrimStart("e") Then
                    config.ReferenceCurrent = CDevHEXA50.eRefCurrent.e80
                ElseIf sbufData(1) = CDevHEXA50.eRefCurrent.e320.ToString.TrimStart("e") Then
                    config.ReferenceCurrent = CDevHEXA50.eRefCurrent.e320
                ElseIf sbufData(1) = CDevHEXA50.eRefCurrent.e1280.ToString.TrimStart("e") Then
                    config.ReferenceCurrent = CDevHEXA50.eRefCurrent.e1280
                ElseIf sbufData(1) = CDevHEXA50.eRefCurrent.e5120.ToString.TrimStart("e") Then
                    config.ReferenceCurrent = CDevHEXA50.eRefCurrent.e5120
                ElseIf sbufData(1) = CDevHEXA50.eDivider.e1.ToString.TrimStart("e") Then
                    config.Divider = CDevHEXA50.eDivider.e1
                ElseIf sbufData(1) = CDevHEXA50.eDivider.e2.ToString.TrimStart("e") Then
                    config.Divider = CDevHEXA50.eDivider.e2
                ElseIf sbufData(1) = CDevHEXA50.eDivider.e4.ToString.TrimStart("e") Then
                    config.Divider = CDevHEXA50.eDivider.e4
                ElseIf sbufData(1) = CDevHEXA50.eDivider.e8.ToString.TrimStart("e") Then
                    config.Divider = CDevHEXA50.eDivider.e8
                ElseIf sbufData(1) = CDevHEXA50.eDivider.e16.ToString.TrimStart("e") Then
                    config.Divider = CDevHEXA50.eDivider.e16
                ElseIf sbufData(1) = CDevHEXA50.eOffset.e0.ToString.TrimStart("e") Then
                    config.Offset = CDevHEXA50.eOffset.e0
                ElseIf sbufData(1) = CDevHEXA50.eOffset.e15.ToString.TrimStart("e") Then
                    config.Offset = CDevHEXA50.eOffset.e15
                ElseIf sbufData(1) = CDevHEXA50.eOffset.e31.ToString.TrimStart("e") Then
                    config.Offset = CDevHEXA50.eOffset.e31
                ElseIf sbufData(1) = CDevHEXA50.eOffset.e63.ToString.TrimStart("e") Then
                    config.Offset = CDevHEXA50.eOffset.e63
                End If
            Loop

            '     Dim ncnt As Integer = 0
            sLine = LineInput(1)
            ReDim Matrix(2, 2)
            Try
                Do

                    For i As Integer = 0 To 2
                        sLine = LineInput(1)
                        If sLine = "" Then Exit Do
                        sbufData = sLine.Split(",")
                        column = sbufData.Length
                        For j As Integer = 0 To 2
                            Matrix(i, j) = sbufData(j)
                        Next
                    Next
                Loop
            Catch ex As Exception

            End Try

            sLine = LineInput(1)
            ReDim Target(2, 2)
            Try
                Do

                    For i As Integer = 0 To 2
                        sLine = LineInput(1)
                        If sLine = "" Then Exit Do
                        sbufData = sLine.Split(",")
                        ReDim Preserve Target(2, sbufData.Length - 1)
                        column = sbufData.Length
                        For j As Integer = 0 To column - 1
                            Target(i, j) = sbufData(j)
                        Next
                    Next
                Loop
            Catch ex As Exception

            End Try

            sLine = LineInput(1)
            ReDim sensor(2, 2)
            Try
                Do

                    For i As Integer = 0 To 2
                        sLine = LineInput(1)
                        If sLine = "" Then Exit Do
                        sbufData = sLine.Split(",")
                        ReDim Preserve sensor(2, sbufData.Length - 1)
                        column = sbufData.Length
                        For j As Integer = 0 To column - 1
                            sensor(i, j) = sbufData(j)
                        Next
                    Next
                Loop
            Catch ex As Exception

            End Try

            ReDim elecOffset(2)
            ReDim bwOffset(2)

            Do Until EOF(1)
                sLine = LineInput(1)

                For i As Integer = 0 To 2
                    sLine = LineInput(1)
                    elecOffset(i) = CDbl(sLine)
                Next
                Exit Do
            Loop

            Do Until EOF(1)
                sLine = LineInput(1)
                For i As Integer = 0 To 2
                    sLine = LineInput(1)
                    bwOffset(i) = CDbl(sLine)
                Next
                Exit Do
            Loop

        Catch ex As Exception
            FileClose(1)
        End Try

        FileClose(1)

        Return True
    End Function

    Public Function FastModeCalibrationDataProcess(ByVal nDevNo As Integer, ByVal ReferenceData() As Double, ByVal OriginCalibrationData As CDevColorAnalyzerCommonNode.sSetInfos, ByRef processCalibrationData As CDevColorAnalyzerCommonNode.sSetInfos) As Boolean
        Dim outdata As CDevColorAnalyzerCommonNode.sDataInfos = Nothing
        Dim S2Prime(,) As Double = Nothing
        Dim S2PrimeTrans(,) As Double = Nothing
        Dim Result1(,) As Double = Nothing
        Dim Result2(,) As Double = Nothing
        Dim Buff(,) As Double = Nothing
        Dim FinalResult(,) As Double = Nothing

        For i As Integer = 1 To 7

            If cColorAnalyzer(nDevNo).myColorAnalyzer.SetSettingsOneRange(i, OriginCalibrationData) = False Then Return False

            If cColorAnalyzer(nDevNo).myColorAnalyzer.Measure(outdata) = True Then

                ' MsgBox("aa")
                ReDim Preserve OriginCalibrationData.sHEXA50Settings.CalibrationData(i).ReferenceData(2, 3)
                OriginCalibrationData.sHEXA50Settings.CalibrationData(i).ReferenceData(0, 3) = ReferenceData(0)
                OriginCalibrationData.sHEXA50Settings.CalibrationData(i).ReferenceData(1, 3) = ReferenceData(1)
                OriginCalibrationData.sHEXA50Settings.CalibrationData(i).ReferenceData(2, 3) = ReferenceData(2)

                ReDim Preserve OriginCalibrationData.sHEXA50Settings.CalibrationData(i).SensorData(2, 3)
                OriginCalibrationData.sHEXA50Settings.CalibrationData(i).SensorData(0, 3) = outdata.Data.dADCX
                OriginCalibrationData.sHEXA50Settings.CalibrationData(i).SensorData(1, 3) = outdata.Data.dADCY
                OriginCalibrationData.sHEXA50Settings.CalibrationData(i).SensorData(2, 3) = outdata.Data.dADCZ


                ReDim Preserve S2Prime(2, 3)
                For row As Integer = 0 To 2
                    For column As Integer = 0 To 3
                        S2Prime(row, column) = OriginCalibrationData.sHEXA50Settings.CalibrationData(i).SensorData(row, column) - OriginCalibrationData.sHEXA50Settings.CalibrationData(i).ElecOffset(row) - OriginCalibrationData.sHEXA50Settings.CalibrationData(i).BWOffset(row)
                    Next
                Next

                '   MsgBox("aaa")
                If cCalibration.MatrixTrans(S2Prime, S2PrimeTrans) = False Then
                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_HEXA_TRANSPOSE_ERROR)
                    Return False
                End If

                If cCalibration.MatrixMulti(OriginCalibrationData.sHEXA50Settings.CalibrationData(i).ReferenceData, S2PrimeTrans, Result1) = False Then
                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_HEXA_MULTIPLY_ERROR)
                    Return False
                End If

                If cCalibration.MatrixMulti(S2Prime, S2PrimeTrans, Buff) = False Then
                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_HEXA_MULTIPLY_ERROR)
                    Return False
                Else
                    If cCalibration.MatrixInverse(Buff, Result2) = False Then
                        g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_HEXA_INVERSE_ERROR)
                        Return False
                    End If
                End If

                If cCalibration.MatrixMulti(Result1, Result2, FinalResult) = False Then
                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_HEXA_K_FACTOR_CALIBRATION_ERROR)
                    Return False
                Else
                    OriginCalibrationData.sHEXA50Settings.CalibrationData(i).KFactor = FinalResult.Clone
                End If


            End If
        Next

        processCalibrationData = OriginCalibrationData

        Return True
    End Function

    Public Function UserCalibrationDataProcess(ByVal data As CDevColorAnalyzerCommonNode.sDataInfos, ByVal UserKFactor(,) As Double, ByRef processdata As CDevColorAnalyzerCommonNode.sDataInfos) As Boolean
        Dim RAWXYZ(,) As Double = Nothing
        Dim ProcessXYZ(,) As Double = Nothing
        Dim XDD As Double = 0
        Dim YDD As Double = 0
        Dim ZDD As Double = 0
        Dim uprime, vprime, u, v As Double

        ReDim RAWXYZ(2, 0)
        RAWXYZ(0, 0) = data.Data.dX
        RAWXYZ(1, 0) = data.Data.dY
        RAWXYZ(2, 0) = data.Data.dZ

        If cCalibration.MatrixMulti(UserKFactor, RAWXYZ, ProcessXYZ) = False Then Return False

        XDD = ProcessXYZ(0, 0) / ProcessXYZ(1, 0) * 100
        YDD = ProcessXYZ(1, 0) / ProcessXYZ(1, 0) * 100
        ZDD = ProcessXYZ(2, 0) / ProcessXYZ(1, 0) * 100

        processdata.Data.dX = ProcessXYZ(0, 0)
        processdata.Data.dY = ProcessXYZ(1, 0)
        processdata.Data.dZ = ProcessXYZ(2, 0)
        Try
            processdata.Data.dCIEx = XDD / (XDD + YDD + ZDD)
            processdata.Data.dCIEy = YDD / (XDD + YDD + ZDD)

            If (processdata.Data.dX + processdata.Data.dY + processdata.Data.dZ) = 0 Then
                processdata.Data.dCIEx = 0
                processdata.Data.dCIEy = 0
                processdata.Data.CCT = 0
            Else
                n = (processdata.Data.dCIEx - 0.332) / (processdata.Data.dCIEy - 0.1858)
                cct = 5520.33 - (6823.3 * n) + (3535 * n * n) - (449 * n * n * n)
                processdata.Data.CCT = cct
            End If
        Catch ex As Exception

        End Try
        Try
            uprime = 4 * XDD / (XDD + YDD * 15 + ZDD * 3)
            vprime = 9 * YDD / (XDD + YDD * 15 + ZDD * 3)
            u = 4 * XDD / (XDD + YDD * 15 + ZDD * 3)
            v = 6 * YDD / (XDD + YDD * 15 + ZDD * 3)
            If (XDD + YDD * 15 + ZDD * 3) = 0 Then
                uprime = 0
                vprime = 0
                u = 0
                v = 0
            End If
        Catch ex As Exception

        End Try

        processdata.Data.dLuminance = processdata.Data.dY
        Dim xn, yn, zn, fx, fy, fz, Lprime, aprime, bprime As Double

        xn = processdata.Data.dX / 94.811
        yn = processdata.Data.dY / 100
        zn = processdata.Data.dZ / 107.304

        If xn > 0.008856 Then
            fx = Math.Pow(xn, 1 / 3)
        Else
            fx = (903.3 * xn + 16) / 116
        End If
        If yn > 0.008856 Then
            fy = Math.Pow(yn, 1 / 3)
        Else
            fy = (903.3 * yn + 16) / 116
        End If
        If zn > 0.008856 Then
            fz = Math.Pow(zn, 1 / 3)
        Else
            fz = (903.3 * zn + 16) / 116
        End If

        Lprime = 116 * fy - 16
        aprime = 500 * (fx - fy)
        bprime = 200 * (fy - fz)

        processdata.Data.dCIE1960u = u
        processdata.Data.dCIE1960v = v
        processdata.Data.dCIE1976u = uprime
        processdata.Data.dCIE1976v = vprime
        processdata.Data.dLprime = Lprime
        processdata.Data.dApirme = aprime
        processdata.Data.dBprime = bprime


        If processdata.Data.dX < 0 Then
            processdata.Data.dX = 0
        End If
        If processdata.Data.dY < 0 Then
            processdata.Data.dY = 0
        End If
        If processdata.Data.dZ < 0 Then
            processdata.Data.dZ = 0
        End If
        If processdata.Data.dCIEx < 0 Then
            processdata.Data.dCIEx = 0
        End If
        If processdata.Data.dCIEy < 0 Then
            processdata.Data.dCIEy = 0
        End If
        If processdata.Data.dCIE1960u < 0 Then
            processdata.Data.dCIE1960u = 0
        End If
        If processdata.Data.dCIE1960v < 0 Then
            processdata.Data.dCIE1960v = 0
        End If
        If processdata.Data.dCIE1976u < 0 Then
            processdata.Data.dCIE1976u = 0
        End If
        If processdata.Data.dCIE1976v < 0 Then
            processdata.Data.dCIE1976v = 0
        End If
        If processdata.Data.CCT < 0 Then
            processdata.Data.CCT = 0
        End If
        Return True
    End Function

#End Region

    Public Sub DisconnectToDevice()

        'If cMC9 Is Nothing = False Then
        '    For i As Integer = 0 To cMC9.Length - 1
        '        cMC9(i).Disconnection()
        '    Next
        'End If

        g_SystemInfo.isConnected = False

        For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
            Select Case g_ConfigInfos.nDevice(i)

                Case frmConfigSystem.eDeviceItem.eSMU_M6000
                    For j As Integer = 0 To g_ConfigInfos.M6000Config.Length - 1
                        cM6000(j).Disconnection()
                    Next
                    '  tlHWStatus(i).BackColor = Color.Red
                Case frmConfigSystem.eDeviceItem.ePG
                    cPG.Disconnection()

                    tlHWStatus(i).BackColor = Color.Red
                Case frmConfigSystem.eDeviceItem.eMcSG
                    cMcSG(i).Disconnection()
                    '  tlHWStatus(i).BackColor = Color.Red
                    'SMU
                Case frmConfigSystem.eDeviceItem.eSMU_IVL
                    For j As Integer = 0 To g_ConfigInfos.SMUForIVLConfig.Length - 1
                        If cIVLSMU(j).mySMU.IsConnected = True Then
                            cIVLSMU(j).mySMU.OutputOff()    '전체 off
                            cIVLSMU(j).mySMU.Disconnection()
                        End If

                    Next
                    ' tlHWStatus(i).BackColor = Color.Red
                    'Spectrometer
                Case frmConfigSystem.eDeviceItem.eSpectroradiometer
                    For j As Integer = 0 To g_ConfigInfos.SpectrometerConfig.Length - 1
                        If cSpectormeter(j).mySpectrometer.IsConnected = True Then
                            ' cSpectormeter(j).mySpectrometer.LocalMode()
                            cSpectormeter(j).mySpectrometer.Disconnection()
                        End If
                    Next

                    'Switching Unit
                Case frmConfigSystem.eDeviceItem.eSwitch
                    For j As Integer = 0 To g_ConfigInfos.SwitchConfig.Length - 1
                        If cSwitch(j).mySwitch.IsConnected = True Then
                            'cSwitch(j).mySwitch.AllOFF() '전체 off
                            For ch As Integer = 0 To g_nMaxCh - 1
                                cSwitch(j).mySwitch.SwitchOFF(ch)
                            Next
                            cSwitch(j).mySwitch.Disconnection()
                        End If

                    Next

                    '  tlHWStatus(i).BackColor = Color.Red
                Case frmConfigSystem.eDeviceItem.eMotion
                    cMotion.SERVO_OFF()

                    '  tlHWStatus(i).BackColor = Color.Red
                Case frmConfigSystem.eDeviceItem.eCamera

                Case frmConfigSystem.eDeviceItem.eTC
                    If cTC Is Nothing = False Then

                        For j As Integer = 0 To cTC.Length - 1
                            cTC(j).Disconnection()
                        Next
                    End If

                    '  tlHWStatus(i).BackColor = Color.Red

                Case frmConfigSystem.eDeviceItem.ePLC

                    If cPLC Is Nothing = False Then
                        '   g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_MOTION_CONNECTED_FAILURE, "PLC0")
                        cPLC.Disconnection()
                        '  g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_MOTION_CONNECTED_FAILURE, "PLC1")
                    End If
                    '  cVision.Dispose()


                Case frmConfigSystem.eDeviceItem.eBCR
                    If cBCR Is Nothing = False Then
                        For j As Integer = 0 To cBCR.Length - 1
                            cBCR(j).Disconnection()
                        Next
                    End If

            End Select

        Next

    End Sub

#End Region

#Region "Sequence Data Save/Load"

    'Public Function SaveChannelLastStatusInfo(ByVal nCH As Integer) As Boolean
    '    ' If cTimeScheduler Is Nothing Or SequenceList(nCH) Is Nothing Then Return False

    '    If Directory.Exists(g_SPATH_SystemData) = False Then
    '        Directory.CreateDirectory(g_SPATH_SystemData)
    '    End If

    '    Dim configSaver As New CSequenceInfo(g_SPATH_SystemData & "Ch" & nCH + 1 & "_Seq" & ".ini")

    '    configSaver.SaveIniValue(CSequenceInfo.eSecID.File_Info, 0, CSequenceInfo.eKeyID.Ch_Num, nCH + 1)

    '    With cTimeScheduler

    '        configSaver.SaveIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.ScheduleStatus, .g_ChSchedulerStatus(nCH).ToString)

    '        With .g_SYSTIMEInfo(nCH)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.IntervalStartTime, .IntervalStartTime.ToString)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.IsSavedIntervalStartTime, .IsSavedIntervalStartTime.ToString)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.IsSavedModeStartTime, .IsSavedModeStartTime.ToString)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.IsSavedTestStartTime, .IsSavedTestStartTime.ToString)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.ModeStartTime, .ModeStartTime.ToString)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.TestStartTime, .TestStartTime.ToString)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.LifeTime, .LifeTime.dHour.ToString)
    '        End With
    '    End With

    '    If SequenceList(nCH) Is Nothing Then 'SequenceList가 초기화 되지 않았을경우 Default 값을 저장
    '        configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.Counter, 0)
    '        configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.CountLifeTime, 0)
    '        configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.CounterChangedTemp, 0)
    '        configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.nCurrentSeqIndex, 0)  'sequencelist(nch).currentRecipeIndex   '.nCurrentSeqIndex
    '        configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.Current_MeasInterval, 0)
    '        configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.Current_ChangeInterval, 0)
    '        configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.NextMeasTime, 0)
    '        configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.LoopCounter, 0)
    '        configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.CurrentSeqIndex_LifeTime, 0)
    '        configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.CurrentSeqIndex_ChangeTemp, 0)
    '    Else
    '        With SequenceList(nCH).SequenceInfo
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.Counter, .nCounter)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.CountLifeTime, .nCounterLifeTime)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.CounterChangedTemp, .nCounterChangedTemp)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.nCurrentSeqIndex, SequenceList(nCH).CurrentRecipeIndex)  'sequencelist(nch).currentRecipeIndex   '.nCurrentSeqIndex
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.Current_MeasInterval, SequenceList(nCH).MeasInterval.nSecond.ToString)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.Current_ChangeInterval, SequenceList(nCH).ChangeInterval.nSecond.ToString)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.NextMeasTime, SequenceList(nCH).NextMeasureTime.nSecond.ToString)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.LoopCounter, SequenceList(nCH).LoopCount.ToString)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.CurrentSeqIndex_LifeTime, SequenceList(nCH).CurrentRecipeIndex_LifeTime.ToString)
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.CurrentSeqIndex_ChangeTemp, SequenceList(nCH).CurrentRecipeIndex_ChangeTemp.ToString)
    '        End With
    '    End If


    '    configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.Meas_isRefPDCurr, g_MeasuredDatas(nCH).bIsSavedRefPDCurrent.ToString)
    '    configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.Meas_RefPDCurr, g_MeasuredDatas(nCH).dRefValue)

    '    If cTimeScheduler.g_ChSchedulerStatus(nCH) <> CScheduler.eChSchedulerSTATE.eIdle Then
    '        If DataSaver(nCH) Is Nothing = False Then
    '            Dim nCnt As Integer = DataSaver(nCH).numberOfSaveFile
    '            Dim startTime() As Date = DataSaver(nCH).StartTime.Clone
    '            Dim SavedDataCounter() As Integer = DataSaver(nCH).SavedDataCounter
    '            configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.DataSaver_numOfInfos, CStr(nCnt))
    '            For i As Integer = 0 To nCnt - 1
    '                configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.DataSaver_StartTime, i, DataSaver(nCH).StartTime(i).ToString)
    '                configSaver.SaveIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.DataSaver_SavedPointCounter, i, CStr(DataSaver(nCH).SavedDataCounter(i)))
    '            Next
    '        End If
    '    End If


    '    Return True
    'End Function

    Public Function LoadLastStatusInfo(ByVal nCH As Integer, ByRef lastState As CScheduler.eChSchedulerSTATE, ByRef sequenceInfo As CSequenceManager, _
                                             ByRef startTime() As Date, ByRef SavedDataCounter() As Integer) As Boolean

        Dim LoadPath As String

        If Directory.Exists(g_SPATH_SystemData) = False Then
            Directory.CreateDirectory(g_SPATH_SystemData)
        End If

        'If File.Exists(g_SPATH_SystemData & "Ch" & nCH + 1 & "_Seq" & ".bak") = True Then
        '    LoadPath = g_SPATH_SystemData & "Ch" & nCH + 1 & "_Seq" & ".bak"
        'Else
        If File.Exists(g_SPATH_SystemData & "Ch" & nCH + 1 & "_Seq" & ".ini") = True Then
            LoadPath = g_SPATH_SystemData & "Ch" & nCH + 1 & "_Seq" & ".ini"
        Else
            Return False
        End If

        Dim configLoad As New CSequenceInfo(LoadPath)

        Dim fileNo As String = configLoad.LoadIniValue(CSequenceInfo.eSecID.File_Info, 0, CSequenceInfo.eKeyID.Ch_Num)

        If fileNo Is Nothing = True Or fileNo = "" Then Return False

        If nCH <> (configLoad.LoadIniValue(CSequenceInfo.eSecID.File_Info, 0, CSequenceInfo.eKeyID.Ch_Num) - 1) Then
            Return False
        End If

        With cTimeScheduler

            '1. 채널의 최종 상태를 읽어서 대기상태가 아니면, 진행중에 멈춘 것으로 판단하고, 상태를 복원한다.
            Dim sTemp As String = configLoad.LoadIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.ScheduleStatus)

            lastState = CScheduler.ConvertScheduleStateStringToInt(sTemp)

            '3. 
            If lastState = -1 Then
                .g_ChSchedulerStatus(nCH) = CScheduler.eChSchedulerSTATE.eIdle
                Return False
            End If

            '3. 채널 측정중 멈춰진 채널은 이어붙이기 위한 나머지 정보를 읽어 온다.
            With .g_SYSTIMEInfo(nCH)
                .IntervalStartTime = CDate(configLoad.LoadIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.IntervalStartTime))
                .IsSavedIntervalStartTime = CBool(configLoad.LoadIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.IsSavedIntervalStartTime))
                .IsSavedIntervalStartTime = CBool(configLoad.LoadIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.IsSavedIntervalStartTime))
                .IsSavedModeStartTime = CBool(configLoad.LoadIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.IsSavedModeStartTime))
                .IsSavedTestStartTime = CBool(configLoad.LoadIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.IsSavedTestStartTime))
                .ModeStartTime = CDate(configLoad.LoadIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.ModeStartTime))
                .TestStartTime = CDate(configLoad.LoadIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.TestStartTime))
                Try
                    .LifeTime = CTime.Convert_HoureToTimeValue(configLoad.LoadIniValue(CSequenceInfo.eSecID.Time_Info, 0, CSequenceInfo.eKeyID.LifeTime))
                Catch ex As Exception
                    .LifeTime = CTime.Convert_HoureToTimeValue(0)
                End Try

            End With

        End With

        Try
            sequenceInfo.CurrentRecipeIndex = CInt(configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.nCurrentSeqIndex))
            sequenceInfo.CurrentRecipeIndex_LifeTime = configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.CurrentSeqIndex_LifeTime)   ', SequenceList(nCH).CurrentRecipeIndex_LifeTime.ToString
            sequenceInfo.CurrentRecipeIndex_ChangeTemp = configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.CurrentSeqIndex_ChangeTemp)   ', SequenceList(nCH).CurrentRecipeIndex_ChangeTemp.ToString
            sequenceInfo.CurrentRecipeIndex_IVLSweep = configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.CurrentRecipeIndex_IVLSweep)
            sequenceInfo.CurrentRecipeIndex_ViewingAngle = configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.CurrentRecipeIndex_ViewingAngle)
            sequenceInfo.CurrentRecipeIndex_LifetimeAndIVL = configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.CurrentRecipeIndex_LifeTimeAndIVL)

            sequenceInfo.MeasInterval = CTime.Convert_SecToTimeValue(configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.Current_MeasInterval))
            sequenceInfo.ChangeInterval = CTime.Convert_SecToTimeValue(configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.Current_ChangeInterval))    ', SequenceList(nCH).ChangeInterval.nSecound.ToString
            sequenceInfo.NextMeasureTime = CTime.Convert_SecToTimeValue(configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.NextMeasTime))  ', SequenceList(nCH).NextMeasureTime.nSecound.ToString)
            sequenceInfo.LoopCount = configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.LoopCounter)   ', SequenceList(nCH).LoopCount.ToString
        Catch ex As Exception
            sequenceInfo.CurrentRecipeIndex = 0
            sequenceInfo.MeasInterval = CTime.Convert_SecToTimeValue(0)
            sequenceInfo.ChangeInterval = CTime.Convert_SecToTimeValue(0)
            sequenceInfo.NextMeasureTime = CTime.Convert_SecToTimeValue(0)
            sequenceInfo.LoopCount = 0
            sequenceInfo.CurrentRecipeIndex_LifeTime = 0
            sequenceInfo.CurrentRecipeIndex_ChangeTemp = 0
            sequenceInfo.CurrentRecipeIndex_IVLSweep = 0
            sequenceInfo.CurrentRecipeIndex_ViewingAngle = 0
            sequenceInfo.CurrentRecipeIndex_LifetimeAndIVL = 0
            '  sequenceInfo.currentrecipeindex_a()
        End Try

        g_MeasuredDatas(nCH).bIsSavedRefPDCurrent = CBool(configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.Meas_isRefPDCurr))

        If g_MeasuredDatas(nCH).bIsSavedRefPDCurrent = True Then
            g_MeasuredDatas(nCH).dRefValue = CDbl(configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.Meas_RefPDCurr))
        Else
            g_MeasuredDatas(nCH).dRefValue = 0
        End If

        Dim nCnt As Integer  'YSR_20130422 --> DataSave의 정보를 읽어와서 정보를 이어 붙여야 함.


        nCnt = configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.DataSaver_numOfInfos)
        ReDim startTime(nCnt - 1)
        ReDim SavedDataCounter(nCnt - 1)
        For i As Integer = 0 To nCnt - 1
            Try
                startTime(i) = configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.DataSaver_StartTime, i)
            Catch ex As Exception   '오류 날 이유가 없지만, 초기 저장 포멧이 이상하면 날수 있음, 오류가 나면 무시해도 됨.
            End Try

            Try
                SavedDataCounter(i) = configLoad.LoadIniValue(CSequenceInfo.eSecID.Sequence_Info, 0, CSequenceInfo.eKeyID.DataSaver_SavedPointCounter, i)
            Catch ex As Exception
            End Try

        Next

        Return True
    End Function

#End Region

#Region "Test Control function"


    Private Sub applyOptions()

        If cVision Is Nothing = False Then
            cVision.myVisionCamera.DefaultThresholdValue = g_SystemOptions.sOptionData.ACFData.nDefThreshold
            cVision.myVisionCamera.ThresholdValue1 = g_SystemOptions.sOptionData.ACFData.nLowThreshold
            cVision.myVisionCamera.ThresholdValue2 = g_SystemOptions.sOptionData.ACFData.nHighThreshold
            cVision.myVisionCamera.CCDResolutionX = g_SystemOptions.sOptionData.ACFData.nCCDResolutionWidth
            cVision.myVisionCamera.CCDResolutionY = g_SystemOptions.sOptionData.ACFData.nCCDResolutionHigh
        End If

        If cMotion Is Nothing = False Then
            cMotion.CalDataRealDistanceUse = g_SystemOptions.sOptionData.MotionData.bCalPosPerDistanceUse
            cMotion.CalDataRealDistanceX = g_SystemOptions.sOptionData.MotionData.sCalPosPerDistance.dAxis_X
            cMotion.CalDataRealDistanceY = g_SystemOptions.sOptionData.MotionData.sCalPosPerDistance.dAxis_Y
            cMotion.CalDataRealDistanceZ = g_SystemOptions.sOptionData.MotionData.sCalPosPerDistance.dAxis_Z
            cMotion.CalDataRealDistanceTheta = g_SystemOptions.sOptionData.MotionData.sCalPosPerDistance.dAxis_Theta
            'cMotion.CalDataDeviationTheta = g_SystemOptions.sOptionData.MotionData.sThetaCal.dDeviation
            'cMotion.CalDataRatioTheta = g_SystemOptions.sOptionData.MotionData.sThetaCal.dRatio
            'cMotion.CalDataOffsetTheta = g_SystemOptions.sOptionData.MotionData.sThetaCal.dOffset

        End If

        frmControlUI.ControlUI.control.DefaultSavePath = g_SystemOptions.sOptionData.SaveOptions.sDefaultSavePath

    End Sub
    Public Sub RedTest()
      
        Dim SelectedChannels() As Integer = Nothing
        Dim nCnt As Integer

       
        '======================================================================================
        For i As Integer = 0 To g_nMaxCh - 1

            If frmControlUI.ControlUI.control.IsSelected(i) = True Then
              
                '정가운데 채널 외에는 Viewing Angle 구동 X
               
                    ReDim Preserve SelectedChannels(nCnt)
                    SelectedChannels(nCnt) = i
                    nCnt += 1
                  
                Else
                    g_StateMsgHandler.messageToUserErrorCode(i, CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Selected_Ch_Alredy_Running, "")
                End If

        Next


        If SelectedChannels Is Nothing Then Exit Sub
        Dim nCh As Integer

        For n As Integer = 0 To SelectedChannels.Length - 1

            nCh = SelectedChannels(n)


            frmControlUI.ControlUI.control.IsSelected(nCh) = False
          
        Next

        '  RunToolStripMenuItem.Enabled = True
        ' tsBtnTestRUN.Enabled = True
    End Sub
    Public Sub RunTest(ByVal startMode As eTestStartMode)
        RunToolStripMenuItem.Enabled = False
        '  tsBtnTestRUN.Enabled = False

        'For LGC==================================================================================
        'Dim BGroupBegin As Integer = 25
        'Dim BGroupEnd As Integer = 33
        Dim SelectedChannels() As Integer = Nothing
        Dim nCnt As Integer

        ''B Group 먼저 스캔해서 배열에 넣고
        'For i As Integer = BGroupBegin To BGroupEnd
        '    If frmControlUI.ControlUI.control.IsSelected(i) = True Then
        '        If cTimeScheduler.g_ChSchedulerStatus(i) = CScheduler.eChSchedulerSTATE.eIdle Then
        '            ReDim Preserve SelectedChannels(nCnt)
        '            SelectedChannels(nCnt) = i
        '            nCnt += 1
        '        Else
        '            g_StateMsgHandler.messageToUserErrorCode(i, CStateMsg.eStateMsg.eSYSTEM_MSG_Selected_Ch_Alredy_Running, "")
        '        End If
        '    End If
        'Next

        ''C Group
        'For i As Integer = BGroupEnd + 1 To g_nMaxCh - 1
        '    If frmControlUI.ControlUI.control.IsSelected(i) = True Then
        '        If cTimeScheduler.g_ChSchedulerStatus(i) = CScheduler.eChSchedulerSTATE.eIdle Then
        '            ReDim Preserve SelectedChannels(nCnt)
        '            SelectedChannels(nCnt) = i
        '            nCnt += 1
        '            'Else
        '            '    g_StateMsgHandler.messageToUserErrorCode(i, CStateMsg.eStateMsg.eSYSTEM_MSG_Selected_Ch_Alredy_Running, "")
        '        End If
        '    End If
        'Next


        ''A Group
        'For i As Integer = 0 To BGroupBegin - 1
        '    If frmControlUI.ControlUI.control.IsSelected(i) = True Then
        '        If cTimeScheduler.g_ChSchedulerStatus(i) <> CScheduler.eChSchedulerSTATE.eIdle Then
        '            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Selected_JIG_Alredy_Running)
        '            Exit Sub
        '        End If
        '    End If

        'Next

        'For i As Integer = 0 To BGroupBegin - 1

        '    If frmControlUI.ControlUI.control.IsSelected(i) = True Then
        '        If cTimeScheduler.g_ChSchedulerStatus(i) = CScheduler.eChSchedulerSTATE.eIdle Then
        '            ReDim Preserve SelectedChannels(nCnt)
        '            SelectedChannels(nCnt) = i
        '            nCnt += 1
        '        Else
        '            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Popup, i, CStateMsg.eStateMsg.eSYSTEM_MSG_Selected_Ch_Alredy_Running, "")
        '        End If
        '    End If
        'Next

        '======================================================================================
        For i As Integer = 0 To g_nMaxCh - 1

            If frmControlUI.ControlUI.control.IsSelected(i) = True Then
                SequenceList(i) = New CSequenceManager
                SequenceList(i) = frmControlUI.ControlUI.control.SequenceList(i)

                'Check Sequence Information
                If CheckSequenceInfo(i) = False Then
                    Exit Sub
                End If

                'Dim nCombineViewingCh() As Integer
                'nCombineViewingCh = frmSettingWind.CheckCombinedChannelAsJIG(4)

                '정가운데 채널 외에는 Viewing Angle 구동 X
                If cTimeScheduler.g_ChSchedulerStatus(i) = CScheduler.eChSchedulerSTATE.eIdle Then

                    ReDim Preserve SelectedChannels(nCnt)
                    SelectedChannels(nCnt) = i
                    nCnt += 1
                    'If i < nCombineViewingCh(0) And i > nCombineViewingCh(nCombineViewingCh.Length - 1) Then
                    '    ReDim Preserve SelectedChannels(nCnt)
                    '    SelectedChannels(nCnt) = i
                    '    nCnt += 1
                    'Else
                    '    If SequenceList(i).SequenceInfo.nCounterViewingAngle = 0 Then
                    '        ReDim Preserve SelectedChannels(nCnt)
                    '        SelectedChannels(nCnt) = i
                    '        nCnt += 1
                    '    End If
                    'End If

                Else
                    g_StateMsgHandler.messageToUserErrorCode(i, CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Selected_Ch_Alredy_Running, "")
                End If
            End If
        Next


        If SelectedChannels Is Nothing Then Exit Sub
        Dim nCh As Integer

        For n As Integer = 0 To SelectedChannels.Length - 1

            nCh = SelectedChannels(n)

            '-----------------------------------Append Start-----------------------------------------------------------------------------------------------------------------------------------------
            If startMode = eTestStartMode.eAppend Then

                If g_SystemInfo.bIsLoadedLastSequence(nCh) = False Then '채널의 상태 정보가 없으면, 이어서 할 필요가 없음.
                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_Popup_Log, CStateMsg.eStateMsg.eSYSTEM_ALARM_Check_ChannelLastSequenceInfo)
                    Exit Sub
                End If

                Dim startTime() As Date = Nothing
                Dim savedPoint() As Integer = Nothing

                'SequenceList(nCh) = New CSequenceManager
                'SequenceList(nCh) = frmControlUI.ControlUI.control.SequenceList(nCh)

                g_DataSaver(nCh) = New cDataOutput(SequenceList(nCh).SequenceInfo, nCh, g_SystemOptions.sOptionData.SaveOptions.nFileType)

                If cState.LoadStateInfoOfChannel(nCh, SequenceList(nCh), g_DataSaver(nCh)) = True Then
                    SequenceList(nCh).SetCurrentRecipe(SequenceList(nCh).CurrentRecipeIndex)

                    ''Check Sequence Information

                    'If CheckSequenceInfo(nCh) = False Then
                    '    Exit Sub
                    'End If

                    ''  InitVariable(nCh)
                    ''    g_MeasuredDatas(nCh).sCellLTParams.LTData = g_MeasuredDatas(nCh).sCellLTParams.LTDataLoadBak

                    SequenceList(nCh).ChangeNextRecipe(True) 'New에서는 시작 시 Run에서 ChangeNextRecipe 호출  Append에서는 없음

                    'Start Test
                    If CScheduler.CheckLastStatusOfChannel(nCh, cTimeScheduler.g_ChSchedulerStatus(nCh)) = False Then '상태 정보 전달. 실제 이어서 시작하기 실행
                        g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_Popup_Log, CStateMsg.eStateMsg.eSYSTEM_ALARM_Check_ChannelLastSequenceInfo)
                        Exit Sub
                    End If


                Else
                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_Popup_Log, CStateMsg.eStateMsg.eSYSTEM_ALARM_Check_ChannelLastSequenceInfo)
                    Exit Sub
                End If

                '------------------------------New Start ----------------------------------------------------------------------------------------------------------------------------------------------
            ElseIf startMode = eTestStartMode.eNew Then

                'SequenceList(nCh) = New CSequenceManager
                'SequenceList(nCh) = frmControlUI.ControlUI.control.SequenceList(nCh)
                SequenceList(nCh).ResetSequenceState()
                cTimeScheduler.g_SYSTIMEInfo(nCh).LifeTime = CTime.Convert_HoureToTimeValue(0)

                ''Check Sequence Information
                'If CheckSequenceInfo(nCh) = False Then
                '    Exit Sub
                'End If

                InitVariable(nCh)

                'If Directory.Exists(SequenceList(i).SequenceInfo.sCommon.saveInfo.strFPath) = False Then  '저장 어떻게 할지.. 임시 Default 경로 
                '    cTimeScheduler.g_ChSchedulerStatus(i) = CScheduler.eChSchedulerSTATE.eIdle
                'Else
                g_DataSaver(nCh) = New cDataOutput(SequenceList(nCh).SequenceInfo, nCh, g_SystemOptions.sOptionData.SaveOptions.nFileType)


                'End If

                'Test Information을 저장
                If SequenceList(nCh).SaveTestSequence(nCh) = False Then '유저가 보기에는  채널 시작번지가 1 임으로 +1
                    '예외처리 필요
                End If

                '  cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eRun  'Test 시작

            End If

            ' frmControlUI.ControlUI.DisableGroupSelection = True
            frmControlUI.ControlUI.control.IsSelected(nCh) = False
            '  frmControlUI.ControlUI.DisableGroupSelection = False
            g_SystemInfo.bCanUpdateStateInfoOfCh(nCh) = True
            g_SystemInfo.bCompleted_ACF_CH(nCh) = False

        Next

        For i As Integer = 0 To SelectedChannels.Length - 1
            nCh = SelectedChannels(i)
            If cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then  '이어서 시작 할때, 이전 상태가 아이들(정상종료)이었다면,
                cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eRun
                Application.DoEvents()
                Thread.Sleep(1500)
            End If
        Next

        RunToolStripMenuItem.Enabled = True
        ' tsBtnTestRUN.Enabled = True
    End Sub

    Public Sub StopTest()

        For i As Integer = 0 To g_nMaxCh - 1

            If frmControlUI.ControlUI.control.IsSelected(i) = True Then

                ' Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                '  Dim nChNo As Integer = frmSettingWind.GetAllocationValue(i, frmSettingWind.eChAllocationItem.eChOfM6000)

                ' frmControlUI.ControlUI.DisableGroupSelection = True
                frmControlUI.ControlUI.control.IsSelected(i) = False
                ' frmControlUI.ControlUI.DisableGroupSelection = False

                If cTimeScheduler.g_ChSchedulerStatus(i) <> CScheduler.eChSchedulerSTATE.eIdle Then
                    SequenceList(i).RequestTest = False
                    cTimeScheduler.g_ChSchedulerStatus(i) = CScheduler.eChSchedulerSTATE.eStop

                    'frmControlTwoStpeCyle.target(i).EnableSetting = True '컨트롤러 측정 종료시 Enable 처리 2013-04-17 승현

                End If

            End If
        Next

        tsBtnTestRUN.Enabled = True
    End Sub


    Public Function CheckSequenceInfo(ByVal nCh As Integer) As Boolean

        If SequenceList(nCh).SequenceInfo.nCounter <= 0 Then   'Check Lifetime recipe
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSEQUENCE_Nothing_Recipe)
            Return False
        Else

            For i As Integer = 0 To SequenceList(nCh).SequenceInfo.sRecipes.Length - 1

                If SequenceList(nCh).SequenceInfo.sRecipes(i).nMode = ucSequenceBuilder.eRcpMode.eModule_Lifetime Then

                    If SequenceList(nCh).SequenceInfo.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.measImage Is Nothing Then 'Check Image Info for Measurement
                        g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSEQUENCE_Check_SequenceInfo_After_ReTry)
                        Return False
                    End If

                    If SequenceList(nCh).SequenceInfo.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.SlideImage Is Nothing Then  'Check Image Info for Autoslide(Aging)
                        g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSEQUENCE_Check_SequenceInfo_After_ReTry)
                        Return False
                    End If

                    Dim imgCnt As Integer = 0

                    For idx As Integer = 0 To SequenceList(nCh).SequenceInfo.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.measImage.Length - 1
                        If SequenceList(nCh).SequenceInfo.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.measImage(idx).bIsSelected = True Then
                            imgCnt += 1
                        End If
                    Next

                    If imgCnt <= 0 Then  'Measurement Image Nothing
                        g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSEQUENCE_Check_SequenceInfo_After_ReTry)
                        Return False
                    End If

                    imgCnt = 0   'Aging Image Nothing
                    For idx As Integer = 0 To SequenceList(nCh).SequenceInfo.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.SlideImage.Length - 1
                        If SequenceList(nCh).SequenceInfo.sRecipes(i).sLifetimeInfo.sModuleInfos.sImageInfos.SlideImage(idx).bIsSelected = True Then
                            imgCnt += 1
                        End If
                    Next

                    If imgCnt <= 0 Then
                        g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSEQUENCE_Check_SequenceInfo_After_ReTry)
                        Return False
                    End If


                    'Measurement Point Setting
                    For idx As Integer = 0 To SequenceList(nCh).SequenceInfo.sRecipes.Length - 1
                        If SequenceList(nCh).SequenceInfo.sRecipes(idx).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint Is Nothing Then
                            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSEQUENCE_Check_SequenceInfo_After_ReTry)
                            Return False
                        End If
                    Next

                ElseIf SequenceList(nCh).SequenceInfo.sRecipes(i).nMode = ucSequenceBuilder.eRcpMode.eCell_Lifetime Then

                End If
            Next

        End If

        'Dim WADJIGs() As Integer = New Integer() {5, 6, 7, 8, 9, 10}

        'Dim IVLJIGs() As Integer = New Integer() {0, 1, 2, 3, 4, 11, 12, 13, 14, 15}
        'Dim JIGNo As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eJIG_No)
        Dim bVAUse As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eVAUse)

        For i As Integer = 0 To SequenceList(nCh).SequenceInfo.sRecipes.Length - 1

            If SequenceList(nCh).SequenceInfo.sRecipes(i).nMode = ucSequenceBuilder.eRcpMode.eViewingAngle Then

                If bVAUse = -1 Then
                    MsgBox("Channel[" & Format(nCh + 1, "00") & "] can not be tested for viewing angle.")
                    Return False
                End If

                'For n As Integer = 0 To IVLJIGs.Length - 1

                '    If IVLJIGs(n) = JIGNo Then
                '        MsgBox("Channel[" & Format(nCh + 1, "00") & "] can not be tested for viewing angle.")
                '        Return False
                '    End If
                'Next

            End If
        Next




        'If SequenceList(i).SequenceInfo.nCounterLifeTime <= 0 Then
        '    g_StateMsgHandler.messageToString = CStateMsg.eStateMsg.eSEQUENCE_Check_SequenceInfo_After_ReTry
        '    Exit For
        'End If

        Return True
    End Function

    Private Sub InitVariable(ByVal ch As Integer)

        g_MeasuredDatas(ch) = Nothing

        With SequenceList(ch).SequenceInfo

            For idx As Integer = 0 To .sRecipes.Length - 1
                Select Case .sRecipes(idx).nMode
                    Case ucSequenceBuilder.eRcpMode.eCell_IVL

                    Case ucSequenceBuilder.eRcpMode.eCell_Lifetime
                        '  Dim measItem() As ucSampleInfos.eSampleColor = CSeqProcessor.GetMeasColorItemInfoFromLTRcp(.sRecipes(idx).sLifetimeInfo)

                        ' ReDim g_MeasuredDatas(ch).sCellLTParams.LTData(measItem.Length - 1)
                        '   ReDim g_MeasuredDatas(ch).sCellLTParams.RealTimeData.eachPixelMeasData(2)  'R,G,B 3색으로

                        '  For i As Integer = 0 To measItem.Length - 1
                        ' Select Case measItem(i)
                        '  Case ucSampleInfos.eSampleColor._SingleColor_R
                        ReDim g_MeasuredDatas(ch).sCellLTParams.LTData(.sRecipes(idx).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)
                        ReDim g_MeasuredDatas(ch).sCellLTParams.RedLTData(.sRecipes(idx).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)
                        ReDim g_MeasuredDatas(ch).sCellLTParams.GreenLTData(.sRecipes(idx).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)
                        ReDim g_MeasuredDatas(ch).sCellLTParams.BlueLTData(.sRecipes(idx).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)
                        ReDim g_MeasuredDatas(ch).sCellLTParams.BlackLTData(.sRecipes(idx).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1)

                        For i As Integer = 0 To .sRecipes(idx).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                            g_MeasuredDatas(ch).sCellLTParams.LTData(i).eletricalData = Nothing
                            g_MeasuredDatas(ch).sCellLTParams.LTData(i).opticalData = Nothing
                            g_MeasuredDatas(ch).sCellLTParams.LTData(i).eletricalData.colorType = ucSampleInfos.eSampleColor._SingleColor_W
                            g_MeasuredDatas(ch).sCellLTParams.RedLTData(i).eletricalData = Nothing
                            g_MeasuredDatas(ch).sCellLTParams.RedLTData(i).opticalData = Nothing
                            g_MeasuredDatas(ch).sCellLTParams.RedLTData(i).eletricalData.colorType = ucSampleInfos.eSampleColor._SingleColor_R
                            g_MeasuredDatas(ch).sCellLTParams.GreenLTData(i).eletricalData = Nothing
                            g_MeasuredDatas(ch).sCellLTParams.GreenLTData(i).opticalData = Nothing
                            g_MeasuredDatas(ch).sCellLTParams.GreenLTData(i).eletricalData.colorType = ucSampleInfos.eSampleColor._SingleColor_G
                            g_MeasuredDatas(ch).sCellLTParams.BlueLTData(i).eletricalData = Nothing
                            g_MeasuredDatas(ch).sCellLTParams.BlueLTData(i).opticalData = Nothing
                            g_MeasuredDatas(ch).sCellLTParams.BlueLTData(i).eletricalData.colorType = ucSampleInfos.eSampleColor._SingleColor_B
                            g_MeasuredDatas(ch).sCellLTParams.BlackLTData(i).eletricalData = Nothing
                            g_MeasuredDatas(ch).sCellLTParams.BlackLTData(i).opticalData = Nothing
                            g_MeasuredDatas(ch).sCellLTParams.BlackLTData(i).eletricalData.colorType = ucSampleInfos.eSampleColor._SingleColor_B
                        Next

                        'End Select
                        '  Next
                    Case ucSequenceBuilder.eRcpMode.eViewingAngle

                End Select
            Next

        End With

    End Sub
    Public Sub CheckThetaPosition(ByVal index As Integer, ByRef degree As Double)

        If index = 0 Or index = 1 Or index = 2 Or index = 6 Or index = 7 Or index = 8 Or index = 12 Or index = 13 Or index = 14 Or index = 18 Or index = 19 Or index = 20 Then
            degree = -90
        Else
            degree = 90
        End If
    End Sub
    'Public Function LifetimeMeasurement(ByVal MeasColor As String, ByVal in_ch As Integer, ByVal MeasPointNum As Integer, Optional ByVal bSourcingRoutine As Boolean = False, Optional ByRef sMsg As String = "") As Boolean
    '    Dim bIVLMeasReturn As Boolean = False
    '    Dim dThetaDegree As Double = 0



    '    If frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
    '        frmControlUI.ControlUI.control.DispChSampleUI(in_ch).CellColor_Meas = Color.Lime
    '        frmControlUI.ControlUI.control.DispChSampleUI(in_ch).CellStatus = ucDispSampleCommonNode.eCellState.eMeasuring
    '        frmControlUI.ControlUI.control.DispChSampleUI(in_ch).Information = "Measuring..."
    '    End If
    '    '////////////////////////////////////////////////

    '    Select Case SequenceList(in_ch).SequenceInfo.sRecipes(0).sLifetimeInfo.nMyMode

    '        Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL

    '            ' Dim settings(2) As CDevM6000.sSettingParams

    '            ' Dim measItems As ucSampleInfos.eSampleColor = Nothing
    '            Dim dCurrent As Double = Nothing
    '            Dim dTemperature As Double = Nothing
    '            Dim MeasValOfSpectrometer As CDevSpectrometerCommonNode.tData = Nothing
    '            Dim buffMeasValOfSpectrometer As CDevSpectrometerCommonNode.tData = Nothing

    '            Dim dComPos() As Double = Nothing
    '            Dim dActPos() As Double = Nothing
    '            Dim dRealPos(2) As Double

    '            Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
    '            Dim nChNo As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eChOfM6000)
    '            Dim nChOfSwitch As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eChOfSwitch)
    '            Dim nDevSwitch As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
    '            Dim nChOfPairSwitch As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eChOfPairSwitch)
    '            Dim nChOfPallet As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.ePallet_No)
    '            Dim nChOfJIG As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eJIG_No)
    '            Dim nDevOfTC As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eDevNoOfTC)
    '            Dim nChOfTC As Integer = frmSettingWind.GetAllocationValue(in_ch, frmSettingWind.eChAllocationItem.eChOfTC)


    '            If SequenceList(in_ch).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.nMode = ucDispRcpLifetime.eLifeTimeMode.Operation Then


    '                'X,Y,Z축 Move 
    '                If frmMotionUI.SetPositionXYAxisMovingFirst(g_motionPosSpectrometer(in_ch), SequenceList(in_ch).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(MeasPointNum).X, SequenceList(in_ch).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(MeasPointNum).Y) = False Then
    '                    g_StateMsgHandler.messageToUserErrorCode(in_ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "SetPositionXYAxisMovingFirst Function")
    '                End If


    '                ' fMain.frmMotionUI.MoveCompletedAllAxis()
    '                Application.DoEvents()
    '                Thread.Sleep(100)
    '                CheckThetaPosition(nChOfJIG, dThetaDegree)

    '                If nChOfPallet = 0 Then
    '                    If frmMotionUI.Theta1Move(dThetaDegree, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
    '                        g_StateMsgHandler.messageToUserErrorCode(in_ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta1 Move Function")
    '                    End If
    '                ElseIf nChOfPallet = 1 Then
    '                    If frmMotionUI.Theta2Move(dThetaDegree, g_ConfigInfos.MotionConfig(3).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
    '                        g_StateMsgHandler.messageToUserErrorCode(in_ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta2 Move Function")
    '                    End If
    '                ElseIf nChOfPallet = 2 Then
    '                    If frmMotionUI.Theta3Move(dThetaDegree, g_ConfigInfos.MotionConfig(4).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
    '                        g_StateMsgHandler.messageToUserErrorCode(in_ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta3 Move Function")
    '                    End If
    '                ElseIf nChOfPallet = 3 Then
    '                    If frmMotionUI.Theta4Move(dThetaDegree, g_ConfigInfos.MotionConfig(5).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS) = False Then
    '                        g_StateMsgHandler.messageToUserErrorCode(in_ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "Theta4 Move Function")
    '                    End If
    '                End If

    '                Application.DoEvents()
    '                Thread.Sleep(100)
    '                'Dim RealDistance() As Double

    '                '전류 읽기 전 스위칭 변환
    '                If cSwitch(nDevSwitch).mySwitch.SwitchON(nChOfSwitch) = False Then
    '                    '예외처리
    '                End If

    '                '1초 Delay 필요
    '                Application.DoEvents()
    '                Thread.Sleep(100)

    '                If cSwitch(nDevSwitch).mySwitch.SwitchON(nChOfPairSwitch) = False Then
    '                    '예외처리
    '                End If


    '                'If cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch) = False Then

    '                'End If
    '                '여기에 DMM전류 읽기 추가
    '                If cDMM(0).Measure(dCurrent) = False Then
    '                    '예외처리 필요
    '                End If
    '                Application.DoEvents()
    '                Thread.Sleep(100)

    '                For i As Integer = 0 To 4
    '                    Application.DoEvents()
    '                    Thread.Sleep(50)
    '                    If cDMM(0).Measure(dCurrent) = True Then
    '                        dCurrent += dCurrent
    '                    End If
    '                Next

    '                dCurrent = dCurrent / 5

    '                Application.DoEvents()
    '                Thread.Sleep(100)
    '                If cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfPairSwitch) = False Then

    '                End If

    '                '읽고 난 후 원복
    '                If cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch) = False Then
    '                    '예외처리
    '                End If


    '                'Aperture Set
    '                Dim nAperture As Integer
    '                nAperture = g_SystemOptions.sOptionData.Spectrometer.nAperture
    '                If cSpectormeter(0).mySpectrometer.SetAperture(nAperture) = False Then
    '                    g_StateMsgHandler.messageToUserErrorCode(in_ch, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "LifeTime SetAperture")
    '                End If

    '                Application.DoEvents()
    '                Thread.Sleep(50)


    '                '휘도측정
    '                MeasureSpectrometer(in_ch, buffMeasValOfSpectrometer, g_SystemOptions.sOptionData.Spectrometer.nAperture, g_SystemOptions.sOptionData.Spectrometer.nSpeedMode)

    '                MeasValOfSpectrometer = buffMeasValOfSpectrometer


    '                If cTCMC(nDevOfTC).GetTemp(1, nChOfTC + 1, dTemperature) = False Then
    '                    'fMain.g_StateMsgHandler.messageToUserErrorCode(procParam.index, CStateMsg.eType.eMSG_Log, CStateMsg.eStateM, "LifeTime SetAperture")
    '                End If

    '            End If


    '            '============================데이터 처리================================================
    '            'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dAngleList = procParam.recipe.sLifetimeInfo.sViewingAngleInfos.dSweepList.Clone
    '            Dim sDatas As frmMain.sMeasureParams = Nothing
    '            If MeasColor = "RED" Then
    '                sDatas = UpdateAndCalculateCellLifetimeDataForM7000_RED(in_ch, dCurrent, dTemperature, MeasValOfSpectrometer, MeasPointNum, bSourcingRoutine)
    '                ' g_MeasuredDatas(in_ch).sCellLTParams.RedLTData(MeasPointNum) = sDatas
    '            ElseIf MeasColor = "GREEN" Then
    '                sDatas = UpdateAndCalculateCellLifetimeDataForM7000_GREEN(in_ch, dCurrent, dTemperature, MeasValOfSpectrometer, MeasPointNum, bSourcingRoutine)
    '            ElseIf MeasColor = "BLUE" Then
    '                sDatas = UpdateAndCalculateCellLifetimeDataForM7000_BLUE(in_ch, dCurrent, dTemperature, MeasValOfSpectrometer, MeasPointNum, bSourcingRoutine)
    '            End If



    '            Dim sTemp As String = Nothing
    '            Dim sRecipeMode As Integer


    '            bIVLMeasReturn = False



    '            sRecipeMode = SequenceList(in_ch).SequenceInfo.sRecipes(0).recipeIndex_LifeTime
    '            '   fMain.g_DataSaver(procParam.index).SaveLTDataPoint(procParam.recipe.recipeIndex_LifeTime, sDatas)

    '            Dim nSaveDataCount As Integer
    '            If MeasColor = "RED" Then
    '                g_DataSaver(in_ch).SaveLTRedDataPoint(sRecipeMode, sDatas, MeasPointNum, sTemp)
    '                nSaveDataCount = g_DataSaver(in_ch).RedSavedDataCounter(sRecipeMode)
    '                g_DataSaver(in_ch).SaveLTAngleSpectrumDataPoint_RED(sRecipeMode, g_MeasuredDatas(in_ch).sCellLTParams.RedLTData(MeasPointNum), MeasPointNum)
    '            ElseIf MeasColor = "GREEN" Then
    '                g_DataSaver(in_ch).SaveLTGreenDataPoint(sRecipeMode, sDatas, MeasPointNum, sTemp)
    '                nSaveDataCount = g_DataSaver(in_ch).GreenSavedDataCounter(sRecipeMode)
    '                g_DataSaver(in_ch).SaveLTAngleSpectrumDataPoint_GREEN(sRecipeMode, g_MeasuredDatas(in_ch).sCellLTParams.GreenLTData(MeasPointNum), MeasPointNum)
    '            ElseIf MeasColor = "BLUE" Then
    '                g_DataSaver(in_ch).SaveLTBlueDataPoint(sRecipeMode, sDatas, MeasPointNum, sTemp)
    '                nSaveDataCount = g_DataSaver(in_ch).BlueSavedDataCounter(sRecipeMode)
    '                g_DataSaver(in_ch).SaveLTAngleSpectrumDataPoint_BLUE(sRecipeMode, g_MeasuredDatas(in_ch).sCellLTParams.BlueLTData(MeasPointNum), MeasPointNum)
    '            End If

    '            '  g_DataSaver(in_ch).SaveLTDataPoint(sRecipeMode, sDatas, MeasPointNum, sTemp)


    '            ''  If ChkSpectrumDataSave(procParam, fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum).opticalData, g_SystemOptions.sOptionData.SaveOptions.dLuminancePerSpectrumSave, nSaveDataCount, MeasPointNum) = True Or procParam.bLastPointSave = True Then
    '            'g_DataSaver(in_ch).SaveLTAngleSpectrumDataPoint(sRecipeMode, procParam.recipe, fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData(MeasPointNum), MeasPointNum)
    '            ''  End If

    '            ' fMain.frmMotionUI.ZMove(10, g_ConfigInfos.MotionConfig(2).dVelocity, CDevPLCCommonNode.eMovingMethod.eABS)   'Z 축 상
    '            Application.DoEvents()
    '            Thread.Sleep(100)

    '        Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime

    '        Case ucSequenceBuilder.eRcpMode.eModule_Lifetime

    '    End Select

    '    If frmControlUI.ControlUI.control.Type = ucDispMultiCtrlCommonNode.eType.JIGLayout Then
    '        frmControlUI.ControlUI.control.DispChSampleUI(in_ch).CellColor_ON = Color.White
    '        frmControlUI.ControlUI.control.DispChSampleUI(in_ch).CellStatus = ucDispSampleCommonNode.eCellState.eON
    '        frmControlUI.ControlUI.control.DispChSampleUI(in_ch).Information = "LifeTime Running..."
    '    End If


    '    Return bIVLMeasReturn

    'End Function

    'Public Function UpdateAndCalculateCellLifetimeDataForM7000_RED(ByVal in_ch As Integer, ByVal dCurrent As Double, ByVal dTemp As Double,
    '                                                         ByVal MeasValOfSpectrometer As CDevSpectrometerCommonNode.tData, ByVal MeasPointNum As Integer, Optional ByVal bFirstSettings As Boolean = False) As sMeasureParams
    '    'Dim dMeasData As frmMain.sMeasureParams

    '    Dim dLumi As Double
    '    Dim dDeltaudvd As Double
    '    Dim dCd_a As Double
    '    '   Dim sDatas() As String = Nothing
    '    Dim cDataQE As CDataQECal = New CDataQECal
    '    Dim nTimeOutCnt As Integer = 0
    '    Const NumOfCol_OpticalData As Integer = 10

    '    Dim nTotalColunmCnt As Integer

    '    ' g_MeasuredDatas(in_ch).sCellLTParams.dCellArea = (procParam.sSampleInfos.SampleSize.Height * procParam.sSampleInfos.SampleSize.Width) / 100
    '    nTotalColunmCnt += 1

    '    g_MeasuredDatas(in_ch).dTemp = dTemp

    '    With g_MeasuredDatas(in_ch).sCellLTParams.RedLTData(MeasPointNum)

    '        .dTotCurrent = 0

    '        '데이터 복사
    '        '  .eletricalData.colorType = electricalDataIdx

    '        .eletricalData.dCurrent = dCurrent * 1000

    '        .dTotCurrent = .eletricalData.dCurrent


    '        ''데이터 정렬용 카운트 증가
    '        'If .eletricalData.mode = CDevM6000PLUS.eMode.eCC Or
    '        '    .eletricalData.mode = CDevM6000PLUS.eMode.eCV Then '이값을 사용하지 않고 M6000 데이터에 모드를 추가해서 사용
    '        '    nTotalColunmCnt += NumOfCol_EletricalData
    '        'Else
    '        '    nTotalColunmCnt += numOfCol_EletricalData_Pulse
    '        'End If

    '        .dCurrentDensity = (.dTotCurrent) / ((g_MeasuredDatas(in_ch).sCellLTParams.dCellArea))

    '        ' .dCurrentDensity = Format((.dTotCurrent * 1000) / ((fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * procParam.sSampleInfos.dFillFactor) / 100), "0.00000E-0")
    '        'Step2. Measurement (Multi-Point Measurement)   'LEX

    '        Dim nWavelengthInterval As Integer = Nothing

    '        .opticalData.sSpectrometerData = MeasValOfSpectrometer
    '        dLumi = (.opticalData.sSpectrometerData.D6.s2YY * 100)
    '        .opticalData.dLumi_Cd_m2 = .opticalData.sSpectrometerData.D6.s2YY
    '        .opticalData.dLumi_Fill_Cd_m2 = dLumi
    '        '# Calculation cd/A
    '        '.opticalData(opticalDataIdx).dLumi_Cd_A = dLumi / (.dCurrentDensity * 10)
    '        .opticalData.dLumi_Cd_A = FormatNumber(dLumi / (.dCurrentDensity * 10), 3) '((.dTotCurrent * 1000 / (fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * 100) * 100) * 10)

    '        '# Calculation lm/W
    '        'lm/W 확인 필요
    '        .opticalData.dlmW = FormatNumber(.opticalData.dLumi_Cd_A / .eletricalData.dVoltage * Math.PI, 3)
    '        '     fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dLumi_Cd_A / fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dVoltage * Math.PI


    '        '스펙트럼 간격별로 QE계산 함수 호출 할 수 있도록 변경 해야 함.
    '        If .opticalData.sSpectrometerData.D5.i3nm Is Nothing = False Then
    '            nWavelengthInterval = .opticalData.sSpectrometerData.D5.i3nm(1) - .opticalData.sSpectrometerData.D5.i3nm(0)

    '            .opticalData.dQE = FormatNumber(cDataQE.QuantumEfficiency(dLumi, .dCurrentDensity, SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Height * SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Width, _
    '                                                                     .opticalData.sSpectrometerData.D5.s4Intensity, nWavelengthInterval), 3)
    '        Else
    '            .opticalData.dQE = 0
    '        End If

    '        If bFirstSettings = True Then
    '            .opticalData.dRefLumi = MeasValOfSpectrometer.D6.s2YY 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s2YY
    '            .opticalData.dRefud = MeasValOfSpectrometer.D6.s5uu  'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s5uu
    '            .opticalData.dRefvd = MeasValOfSpectrometer.D6.s6vv 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s6vv
    '            '   fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dRefVoltage = MeasValOfM6000.dVoltage_Bias 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dVoltage
    '            .eletricalData.dRefCurrent = .eletricalData.dCurrent 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dCurrent
    '            .opticalData.dLumi_Cd_A_RefValue = .opticalData.dLumi_Cd_A

    '            '  g_MeasuredDatas(in_ch).bIsSavedRefPDCurrent = True
    '            ' g_MeasuredDatas(in_ch).bRequestedMeasRefValue = False
    '        End If

    '        If bFirstSettings = True Then  '기준 값이 저장 되었으면...
    '            .eletricalData.dDeltaVoltage = .eletricalData.dVoltage - .eletricalData.dRefVoltage
    '            .eletricalData.dDeltaCurrent = .eletricalData.dCurrent - .eletricalData.dRefCurrent
    '            .eletricalData.dCurrent_Per = (.eletricalData.dCurrent / .eletricalData.dRefCurrent) * 100
    '        Else
    '            .eletricalData.dDeltaVoltage = 0
    '            .eletricalData.dDeltaCurrent = 0
    '            .eletricalData.dCurrent_Per = 100
    '        End If

    '        If bFirstSettings = True Then  '기준 값이 저장 되었으면...
    '            dLumi = (.opticalData.sSpectrometerData.D6.s2YY / .opticalData.dRefLumi) * 100
    '            dDeltaudvd = Math.Sqrt((.opticalData.dRefud - .opticalData.sSpectrometerData.D6.s5uu) ^ 2 + (.opticalData.dRefvd - .opticalData.sSpectrometerData.D6.s6vv) ^ 2)
    '            dCd_a = (.opticalData.dLumi_Cd_A / .opticalData.dLumi_Cd_A_RefValue) * 100

    '        Else
    '            dCd_a = 100
    '            dLumi = 100
    '            dDeltaudvd = 0
    '        End If

    '        .opticalData.dLumi_Percent = dLumi
    '        .opticalData.dLumi_Cd_A_Percent = dCd_a
    '        .opticalData.dDeltaudvd = dDeltaudvd


    '        '데이터 정렬용 카운트 증가
    '        nTotalColunmCnt += NumOfCol_OpticalData
    '        ' Next

    '    End With

    '    Return g_MeasuredDatas(in_ch)
    'End Function


    'Public Function UpdateAndCalculateCellLifetimeDataForM7000_GREEN(ByVal in_ch As Integer, ByVal dCurrent As Double, ByVal dTemp As Double,
    '                                                         ByVal MeasValOfSpectrometer As CDevSpectrometerCommonNode.tData, ByVal MeasPointNum As Integer, Optional ByVal bFirstSettings As Boolean = False) As sMeasureParams
    '    'Dim dMeasData As frmMain.sMeasureParams

    '    Dim dLumi As Double
    '    Dim dDeltaudvd As Double
    '    Dim dCd_a As Double
    '    '   Dim sDatas() As String = Nothing
    '    Dim cDataQE As CDataQECal = New CDataQECal
    '    Dim nTimeOutCnt As Integer = 0
    '    Const NumOfCol_OpticalData As Integer = 10

    '    Dim nTotalColunmCnt As Integer

    '    ' g_MeasuredDatas(in_ch).sCellLTParams.dCellArea = (procParam.sSampleInfos.SampleSize.Height * procParam.sSampleInfos.SampleSize.Width) / 100
    '    nTotalColunmCnt += 1

    '    g_MeasuredDatas(in_ch).dTemp = dTemp

    '    With g_MeasuredDatas(in_ch).sCellLTParams.GreenLTData(MeasPointNum)

    '        .dTotCurrent = 0

    '        '데이터 복사
    '        '  .eletricalData.colorType = electricalDataIdx

    '        .eletricalData.dCurrent = dCurrent * 1000

    '        .dTotCurrent = .eletricalData.dCurrent


    '        ''데이터 정렬용 카운트 증가
    '        'If .eletricalData.mode = CDevM6000PLUS.eMode.eCC Or
    '        '    .eletricalData.mode = CDevM6000PLUS.eMode.eCV Then '이값을 사용하지 않고 M6000 데이터에 모드를 추가해서 사용
    '        '    nTotalColunmCnt += NumOfCol_EletricalData
    '        'Else
    '        '    nTotalColunmCnt += numOfCol_EletricalData_Pulse
    '        'End If

    '        .dCurrentDensity = (.dTotCurrent) / ((g_MeasuredDatas(in_ch).sCellLTParams.dCellArea))

    '        ' .dCurrentDensity = Format((.dTotCurrent * 1000) / ((fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * procParam.sSampleInfos.dFillFactor) / 100), "0.00000E-0")
    '        'Step2. Measurement (Multi-Point Measurement)   'LEX

    '        Dim nWavelengthInterval As Integer = Nothing

    '        .opticalData.sSpectrometerData = MeasValOfSpectrometer
    '        dLumi = (.opticalData.sSpectrometerData.D6.s2YY * 100)
    '        .opticalData.dLumi_Cd_m2 = .opticalData.sSpectrometerData.D6.s2YY
    '        .opticalData.dLumi_Fill_Cd_m2 = dLumi
    '        '# Calculation cd/A
    '        '.opticalData(opticalDataIdx).dLumi_Cd_A = dLumi / (.dCurrentDensity * 10)
    '        .opticalData.dLumi_Cd_A = FormatNumber(dLumi / (.dCurrentDensity * 10), 3) '((.dTotCurrent * 1000 / (fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * 100) * 100) * 10)

    '        '# Calculation lm/W
    '        'lm/W 확인 필요
    '        .opticalData.dlmW = FormatNumber(.opticalData.dLumi_Cd_A / .eletricalData.dVoltage * Math.PI, 3)
    '        '     fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dLumi_Cd_A / fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dVoltage * Math.PI


    '        '스펙트럼 간격별로 QE계산 함수 호출 할 수 있도록 변경 해야 함.
    '        If .opticalData.sSpectrometerData.D5.i3nm Is Nothing = False Then
    '            nWavelengthInterval = .opticalData.sSpectrometerData.D5.i3nm(1) - .opticalData.sSpectrometerData.D5.i3nm(0)

    '            .opticalData.dQE = FormatNumber(cDataQE.QuantumEfficiency(dLumi, .dCurrentDensity, SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Height * SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Width, _
    '                                                                     .opticalData.sSpectrometerData.D5.s4Intensity, nWavelengthInterval), 3)
    '        Else
    '            .opticalData.dQE = 0
    '        End If

    '        If bFirstSettings = True Then
    '            .opticalData.dRefLumi = MeasValOfSpectrometer.D6.s2YY 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s2YY
    '            .opticalData.dRefud = MeasValOfSpectrometer.D6.s5uu  'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s5uu
    '            .opticalData.dRefvd = MeasValOfSpectrometer.D6.s6vv 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s6vv
    '            '   fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dRefVoltage = MeasValOfM6000.dVoltage_Bias 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dVoltage
    '            .eletricalData.dRefCurrent = .eletricalData.dCurrent 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dCurrent
    '            .opticalData.dLumi_Cd_A_RefValue = .opticalData.dLumi_Cd_A

    '            '  g_MeasuredDatas(in_ch).bIsSavedRefPDCurrent = True
    '            ' g_MeasuredDatas(in_ch).bRequestedMeasRefValue = False
    '        End If

    '        If bFirstSettings = True Then  '기준 값이 저장 되었으면...
    '            .eletricalData.dDeltaVoltage = .eletricalData.dVoltage - .eletricalData.dRefVoltage
    '            .eletricalData.dDeltaCurrent = .eletricalData.dCurrent - .eletricalData.dRefCurrent
    '            .eletricalData.dCurrent_Per = (.eletricalData.dCurrent / .eletricalData.dRefCurrent) * 100
    '        Else
    '            .eletricalData.dDeltaVoltage = 0
    '            .eletricalData.dDeltaCurrent = 0
    '            .eletricalData.dCurrent_Per = 100
    '        End If

    '        If bFirstSettings = True Then  '기준 값이 저장 되었으면...
    '            dLumi = (.opticalData.sSpectrometerData.D6.s2YY / .opticalData.dRefLumi) * 100
    '            dDeltaudvd = Math.Sqrt((.opticalData.dRefud - .opticalData.sSpectrometerData.D6.s5uu) ^ 2 + (.opticalData.dRefvd - .opticalData.sSpectrometerData.D6.s6vv) ^ 2)
    '            dCd_a = (.opticalData.dLumi_Cd_A / .opticalData.dLumi_Cd_A_RefValue) * 100

    '        Else
    '            dCd_a = 100
    '            dLumi = 100
    '            dDeltaudvd = 0
    '        End If

    '        .opticalData.dLumi_Percent = dLumi
    '        .opticalData.dLumi_Cd_A_Percent = dCd_a
    '        .opticalData.dDeltaudvd = dDeltaudvd


    '        '데이터 정렬용 카운트 증가
    '        nTotalColunmCnt += NumOfCol_OpticalData
    '        ' Next

    '    End With

    '    Return g_MeasuredDatas(in_ch)
    'End Function


    'Public Function UpdateAndCalculateCellLifetimeDataForM7000_BLUE(ByVal in_ch As Integer, ByVal dCurrent As Double, ByVal dTemp As Double,
    '                                                         ByVal MeasValOfSpectrometer As CDevSpectrometerCommonNode.tData, ByVal MeasPointNum As Integer, Optional ByVal bFirstSettings As Boolean = False) As sMeasureParams
    '    'Dim dMeasData As frmMain.sMeasureParams

    '    Dim dLumi As Double
    '    Dim dDeltaudvd As Double
    '    Dim dCd_a As Double
    '    '   Dim sDatas() As String = Nothing
    '    Dim cDataQE As CDataQECal = New CDataQECal
    '    Dim nTimeOutCnt As Integer = 0
    '    Const NumOfCol_OpticalData As Integer = 10

    '    Dim nTotalColunmCnt As Integer

    '    ' g_MeasuredDatas(in_ch).sCellLTParams.dCellArea = (procParam.sSampleInfos.SampleSize.Height * procParam.sSampleInfos.SampleSize.Width) / 100
    '    nTotalColunmCnt += 1

    '    g_MeasuredDatas(in_ch).dTemp = dTemp

    '    With g_MeasuredDatas(in_ch).sCellLTParams.BlueLTData(MeasPointNum)

    '        .dTotCurrent = 0

    '        '데이터 복사
    '        '  .eletricalData.colorType = electricalDataIdx

    '        .eletricalData.dCurrent = dCurrent * 1000

    '        .dTotCurrent = .eletricalData.dCurrent


    '        ''데이터 정렬용 카운트 증가
    '        'If .eletricalData.mode = CDevM6000PLUS.eMode.eCC Or
    '        '    .eletricalData.mode = CDevM6000PLUS.eMode.eCV Then '이값을 사용하지 않고 M6000 데이터에 모드를 추가해서 사용
    '        '    nTotalColunmCnt += NumOfCol_EletricalData
    '        'Else
    '        '    nTotalColunmCnt += numOfCol_EletricalData_Pulse
    '        'End If

    '        .dCurrentDensity = (.dTotCurrent) / ((g_MeasuredDatas(in_ch).sCellLTParams.dCellArea))

    '        ' .dCurrentDensity = Format((.dTotCurrent * 1000) / ((fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * procParam.sSampleInfos.dFillFactor) / 100), "0.00000E-0")
    '        'Step2. Measurement (Multi-Point Measurement)   'LEX

    '        Dim nWavelengthInterval As Integer = Nothing

    '        .opticalData.sSpectrometerData = MeasValOfSpectrometer
    '        dLumi = (.opticalData.sSpectrometerData.D6.s2YY * 100)
    '        .opticalData.dLumi_Cd_m2 = .opticalData.sSpectrometerData.D6.s2YY
    '        .opticalData.dLumi_Fill_Cd_m2 = dLumi
    '        '# Calculation cd/A
    '        '.opticalData(opticalDataIdx).dLumi_Cd_A = dLumi / (.dCurrentDensity * 10)
    '        .opticalData.dLumi_Cd_A = FormatNumber(dLumi / (.dCurrentDensity * 10), 3) '((.dTotCurrent * 1000 / (fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dCellArea * 100) * 100) * 10)

    '        '# Calculation lm/W
    '        'lm/W 확인 필요
    '        .opticalData.dlmW = FormatNumber(.opticalData.dLumi_Cd_A / .eletricalData.dVoltage * Math.PI, 3)
    '        '     fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dLumi_Cd_A / fMain.g_MeasuredDatas(procParam.index).sCellLTParams.dVoltage * Math.PI


    '        '스펙트럼 간격별로 QE계산 함수 호출 할 수 있도록 변경 해야 함.
    '        If .opticalData.sSpectrometerData.D5.i3nm Is Nothing = False Then
    '            nWavelengthInterval = .opticalData.sSpectrometerData.D5.i3nm(1) - .opticalData.sSpectrometerData.D5.i3nm(0)

    '            .opticalData.dQE = FormatNumber(cDataQE.QuantumEfficiency(dLumi, .dCurrentDensity, SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Height * SequenceList(in_ch).SequenceInfo.sSampleInfos.SampleSize.Width, _
    '                                                                     .opticalData.sSpectrometerData.D5.s4Intensity, nWavelengthInterval), 3)
    '        Else
    '            .opticalData.dQE = 0
    '        End If

    '        If bFirstSettings = True Then
    '            .opticalData.dRefLumi = MeasValOfSpectrometer.D6.s2YY 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s2YY
    '            .opticalData.dRefud = MeasValOfSpectrometer.D6.s5uu  'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s5uu
    '            .opticalData.dRefvd = MeasValOfSpectrometer.D6.s6vv 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.opticalData.sSpectrometerData.D6.s6vv
    '            '   fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dRefVoltage = MeasValOfM6000.dVoltage_Bias 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dVoltage
    '            .eletricalData.dRefCurrent = .eletricalData.dCurrent 'fMain.g_MeasuredDatas(procParam.index).sCellLTParams.LTData.eletricalData.dCurrent
    '            .opticalData.dLumi_Cd_A_RefValue = .opticalData.dLumi_Cd_A

    '            '  g_MeasuredDatas(in_ch).bIsSavedRefPDCurrent = True
    '            ' g_MeasuredDatas(in_ch).bRequestedMeasRefValue = False
    '        End If

    '        If bFirstSettings = True Then  '기준 값이 저장 되었으면...
    '            .eletricalData.dDeltaVoltage = .eletricalData.dVoltage - .eletricalData.dRefVoltage
    '            .eletricalData.dDeltaCurrent = .eletricalData.dCurrent - .eletricalData.dRefCurrent
    '            .eletricalData.dCurrent_Per = (.eletricalData.dCurrent / .eletricalData.dRefCurrent) * 100
    '        Else
    '            .eletricalData.dDeltaVoltage = 0
    '            .eletricalData.dDeltaCurrent = 0
    '            .eletricalData.dCurrent_Per = 100
    '        End If

    '        If bFirstSettings = True Then  '기준 값이 저장 되었으면...
    '            dLumi = (.opticalData.sSpectrometerData.D6.s2YY / .opticalData.dRefLumi) * 100
    '            dDeltaudvd = Math.Sqrt((.opticalData.dRefud - .opticalData.sSpectrometerData.D6.s5uu) ^ 2 + (.opticalData.dRefvd - .opticalData.sSpectrometerData.D6.s6vv) ^ 2)
    '            dCd_a = (.opticalData.dLumi_Cd_A / .opticalData.dLumi_Cd_A_RefValue) * 100

    '        Else
    '            dCd_a = 100
    '            dLumi = 100
    '            dDeltaudvd = 0
    '        End If

    '        .opticalData.dLumi_Percent = dLumi
    '        .opticalData.dLumi_Cd_A_Percent = dCd_a
    '        .opticalData.dDeltaudvd = dDeltaudvd


    '        '데이터 정렬용 카운트 증가
    '        nTotalColunmCnt += NumOfCol_OpticalData
    '        ' Next

    '    End With

    '    Return g_MeasuredDatas(in_ch)
    'End Function

    'Public Function MeasureSpectrometer(ByVal idx As Integer, ByRef measData As CDevSpectrometerCommonNode.tData, Optional ByVal nAperture As Integer = 0, Optional ByVal nSpeedMode As Integer = 0) As Boolean

    '    'Dim measData As CDevSpectrometerCommonNode.tData = Nothing
    '    Dim nWavelengthInterval As Integer = Nothing
    '    Dim nTimeOutCnt As Integer
    '    Dim fRst As Boolean = True

    '    '  If fMain.cSpectormeter(0).mySpectrometer.Model = CDevSpectrometerCommonNode.eModel.SPECTROMETER_DarsaPro Or _
    '    ' fMain.cSpectormeter(0).mySpectrometer.Model = CDevSpectrometerCommonNode.eModel.SPECTROMETER_SR3AR Then
    '    'If fMain.cSpectormeter(0).mySpectrometer.SetAperture(nAperture) = False Then
    '    '    fMain.g_StateMsgHandler.messageToUserErrorCode(idx, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "SetAperture")
    '    '    '예외처리
    '    'End If

    '    'If fMain.cSpectormeter(0).mySpectrometer.SetMeasSpeed(nSpeedMode) = False Then
    '    '    fMain.g_StateMsgHandler.messageToUserErrorCode(idx, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "SetSpeedMode")
    '    '    '예외처리
    '    'End If
    '    ' End If


    '    ' 초기 측정 시 Aperature  1'  Change 
    '    If cSpectormeter(0).mySpectrometer.EndApertureChange() = False Then  '1/8도 Aperture 로 고정
    '        g_StateMsgHandler.messageToUserErrorCode(idx, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "EndApertureChange")
    '        '예외처리
    '    End If

    '    nTimeOutCnt = 0
    '    Do
    '        If nTimeOutCnt > 5 Then
    '            g_StateMsgHandler.messageToUserErrorCode(idx, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_COMMON_MSG_Retry_TimeOut_Cnt, "SpectroRadiometer Meas")
    '            fRst = False
    '            Exit Do
    '        End If

    '        If cSpectormeter(0).mySpectrometer.Measure(measData) = True Then
    '            Exit Do
    '        End If
    '        nTimeOutCnt += 1
    '    Loop

    '    nTimeOutCnt = 0
    '    Do
    '        If nTimeOutCnt > 5 Then
    '            g_StateMsgHandler.messageToUserErrorCode(idx, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_COMMON_MSG_Retry_TimeOut_Cnt, "SpectroRadiometer DownloadData")
    '            fRst = False
    '            Exit Do
    '        End If

    '        If cSpectormeter(0).mySpectrometer.DownloadData(measData) = True Then
    '            Exit Do
    '        End If
    '        nTimeOutCnt += 1
    '    Loop

    '    Return fRst
    'End Function

#Region "Pause Control Function"

    Dim m_dPausePosition(5) As Double

    '///////////////////////////////////////////////////////
    '일시정지 이벤트IO_StateCheck
    Public Sub SetPause()

        g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_REQUEST_PAUSE)

        '현재 위치정보 저장
        'X
        ' m_dPausePosition(0) = frmMotionUI.ucMotionIndicator.XPos
        'Y
        'm_dPausePosition(0) = frmMotionUI.ucMotionIndicator.YPos
        ''Z
        'm_dPausePosition(1) = frmMotionUI.ucMotionIndicator.ZPos
        ''Theta Y
        'm_dPausePosition(2) = frmMotionUI.ucMotionIndicator.Theta1Pos

        'm_dPausePosition(3) = frmMotionUI.ucMotionIndicator.Theta2Pos

        'm_dPausePosition(4) = frmMotionUI.ucMotionIndicator.Theta3Pos

        'm_dPausePosition(5) = frmMotionUI.ucMotionIndicator.Theta4Pos

        '  m_dPausePosition(3) = frmMotionUI.ucMotionIndicator.AnglePos

        'cMotion.Set_Stop()
        'frmMeasurementWnd.bMotionPause = True  '측정 중지 플레그

        ' tsBtnTestPAUSE.Image = My.Resources.Reset_Pause
        '  Dim Reqinfo As CDevPLCCommonNode.sRequestInfo = Nothing
        '  Dim EQPStatus() As CDevPLCCommonNode.eEQPStatus = Nothing

        'cPLC.GetEQPStatue(EQPStatus)
        'If EQPStatus(0) <> CDevPLCCommonNode.eEQPStatus.eStop Then
        '    Reqinfo.nEQPStatus = CDevPLCCommonNode.eEQPStatus.eStop
        '    cPLC.SetEQPStatus(Reqinfo)
        'End If

        'tsBtnTestPAUSE.Text = "Release Pause"
        tsBtnTestPauseText("Reset Pause")
        tsBtnTestPauseColor(Color.Orange)
        tsBtnTestPauseImage(My.Resources.Reset_Pause_1)
        ' tsBtnTestPAUSE.Enabled = False

        '  tsBtnTestRUN.Enabled = False
        ' tsBtnTestSTOP.Enabled = False
        'EnableTsBtnTestPause(False)


        'g_StateMsgHandler.messageToString = CStateMsg.eStateMsg.eSYSTEM_STATUS_PAUSED

    End Sub

    Public Sub ResetPause()

        'g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_RELEASE_PAUSE)
        '20160425_PSK
        'frmMotionUI.Enable_gbMotion(False)
        'frmMotionUI.Enable_gbSourceCtrl(False)
        'frmMotionUI.Enable_gbACFCameraCtrl(False)
        'frmMotionUI.Enable_gbACFCtrl(False)
        'frmMotionUI.Enable_gbACFMeas(False)
        'frmPretestUI.Enable_gbControl(False)

        ' g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_HOMMING)

        'Z축을 올리고 이동
        ' cMotion.ZMove(20, True)   'Z 축 상승
        'cMotion.ZMove(5000, True)
        'cMotion.MoveCompletedAllAxis()
        Application.DoEvents()
        Thread.Sleep(100)

        ' cMotion.Homming()
        'cMotion.MoveCompletedAllAxis()
        ' g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_HOMMING_END)


        g_PauseCtrl.ResetPause()

        'tsBtnTestPAUSE.Image = My.Resources.pause
        ' tsBtnTestPauseImage(My.Resources.pause)
        'tsBtnTestPAUSE.Text = "Pause"
        tsBtnTestPauseText("Pause")
        tsBtnTestPauseColor(Color.White)
        tsBtnTestPauseImage(My.Resources._06Pause)
        '   tsBtnTestRUN.Enabled = True
        ' tsBtnTestSTOP.Enabled = True
        'tsBtnTestPAUSE.Enabled = True
        ' EnableTsBtnTestPause(True)
        ' g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_RELEASE_PAUSE)
        g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSYEM_STATUS_AUTO)
    End Sub


    Private Sub g_PauseCtrl_evPaused() Handles g_PauseCtrl.evPaused
        '20160425_PSK
        'frmMotionUI.Enable_gbMotion(True)
        'frmMotionUI.Enable_gbSourceCtrl(True)
        'frmMotionUI.Enable_gbACFCameraCtrl(True)
        'frmMotionUI.Enable_gbACFCtrl(True)
        'frmMotionUI.Enable_gbACFMeas(True)
        'frmPretestUI.Enable_gbControl(True)
    End Sub

#End Region


#End Region
    Public Function PLC_SupplySlotCheck(ByVal nSupplySlot As CDevPLCCommonNode.eSlotSignal) As Boolean

        Return True
    End Function


    Public Function PLC_PositionCheck(ByVal nSupplySlot As CDevPLCCommonNode.eSlotSignal, ByVal nSupplyPosition As CDevPLCCommonNode.ePositionSignal, _
                                        ByVal nExhausSlot As CDevPLCCommonNode.eSlotSignal, ByVal nExhausPosition As CDevPLCCommonNode.ePositionSignal, _
                                        ByRef sMagazineControl As CSheduler_PLC.sMagazineControl) As Boolean


        '위치를 잡기전에 팔레트 체크가 되어 있는지 확인을 하고 위치 조정을 해야한다.....

        '   If g_PalletInfos.bCheckPallet(nSupplySlot) = False Then

        ' End If

        '맨 위 위치가 10번일 경우
        'If nSupplySlot > nSupplyPosition Then
        '    sMagazineControl.nSupply = CSheduler_PLC.eMagazinePositionControl.eDown
        'ElseIf nSupplySlot < nSupplyPosition Then
        '    sMagazineControl.nSupply = CSheduler_PLC.eMagazinePositionControl.eUp
        'ElseIf nSupplySlot = nSupplyPosition Then
        '    sMagazineControl.nSupply = CSheduler_PLC.eMagazinePositionControl.eOk
        'End If

        'If nExhausSlot > nExhausPosition Then
        '    sMagazineControl.nExhaus = CSheduler_PLC.eMagazinePositionControl.eDown
        'ElseIf nExhausSlot < nExhausPosition Then
        '    sMagazineControl.nExhaus = CSheduler_PLC.eMagazinePositionControl.eUp
        'ElseIf nExhausSlot = nExhausPosition Then
        '    sMagazineControl.nExhaus = CSheduler_PLC.eMagazinePositionControl.eOk
        'End If

        '맨 위 위치가 1번일 경우
        If nSupplySlot > nSupplyPosition Then
            sMagazineControl.nSupply = CSheduler_PLC.eMagazinePositionControl.eUp
        ElseIf nSupplySlot < nSupplyPosition Then
            sMagazineControl.nSupply = CSheduler_PLC.eMagazinePositionControl.eDown
        ElseIf nSupplySlot = nSupplyPosition Then
            sMagazineControl.nSupply = CSheduler_PLC.eMagazinePositionControl.eOk
        End If

        If nExhausSlot > nExhausPosition Then
            sMagazineControl.nExhaus = CSheduler_PLC.eMagazinePositionControl.eUp
        ElseIf nExhausSlot < nExhausPosition Then
            sMagazineControl.nExhaus = CSheduler_PLC.eMagazinePositionControl.eDown
        ElseIf nExhausSlot = nExhausPosition Then
            sMagazineControl.nExhaus = CSheduler_PLC.eMagazinePositionControl.eOk
        End If


        Return True
    End Function

      Public Function PLC_StatusCheck(ByVal nSupplySlot As CDevPLCCommonNode.eSlotSignal, ByVal nExhausSlot As CDevPLCCommonNode.eSlotSignal, ByVal nSupplyPosition As CDevPLCCommonNode.ePositionSignal, ByVal nExhaustPositin As CDevPLCCommonNode.ePositionSignal, ByRef ErrorMsg As String) As Boolean
        Dim bCheckSupplyStatus As Boolean = False
        Dim bCheckExhausStatus As Boolean = False
        Dim bCheckContactStatus As Boolean = False
        Dim bCheckSupplySlot As Boolean = False
        Dim bCheckExhausSlot As Boolean = False
        Dim bCheckSupplyPosition As Boolean = False
        Dim bCheckExhausPosition As Boolean = False

        Dim nCheckCnt As Integer = 0

        If cPLC Is Nothing Then
            Return True
        End If

        '공급슬롯 없으면 실험 진행시키면 안됨
        '=================== 공급 슬롯 확인 ===================================
        If cPLC.m_PLCDatas.nSupplySlotSignal(0) = CDevPLCCommonNode.eSlotSignal.eNone Then
            bCheckExhausSlot = True
            nCheckCnt = 0
        Else
            bCheckSupplySlot = True
            nCheckCnt += 1
        End If

        If nCheckCnt = 0 Then
            ErrorMsg = " 공급슬롯이 비어있습니다. 공급부를 확인해주십시오."
            Return False
        End If

        nCheckCnt = 0

        '배출 슬롯이 비어있을때만 실험이 가능하다.
        If cPLC.m_PLCDatas.nExhausSlotSignal(0) = CDevPLCCommonNode.ePositionSignal.eNone Then
            bCheckExhausSlot = True
            nCheckCnt += 1
        Else
            bCheckExhausSlot = True
            nCheckCnt = 0
        End If
        'End If
        If nCheckCnt = 0 Then
            ErrorMsg = "배출슬롯이 비어있지 않습니다. 배출부를 확인해주십시오."
            Return False
        End If

        Return True
    End Function

#Region "ICON Toolbar Event Handler Functions"

    Public Sub MeasRun()
        For idx As Integer = 0 To g_nMaxCh - 1

            If frmControlUI.ControlUI.control.IsLoadedSequenceInfo(idx) = True Or frmControlUI.ControlUI.control.IsLoadedSavePath(idx) = True Then
                frmControlUI.ControlUI.control.IsSelected(idx) = True
            End If
            '  Application.DoEvents()
            ' Thread.Sleep(1000)
        Next

        If Channel_checkStart() = False Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_ChannelSelection)
        Else

            For idx As Integer = 0 To g_nMaxCh - 1

                '    If frmControlUI.ControlUI.control.IsLoadedSequenceInfo(idx) = True Or frmControlUI.ControlUI.control.IsLoadedSavePath(idx) = True Then
                'frmControlUI.ControlUI.control.IsSelected(idx) = True
                '   End If

                If frmControlUI.ControlUI.control.IsSelected(idx) = True Then
                    If frmControlUI.ControlUI.control.IsLoadedSequenceInfo(idx) = False Or frmControlUI.ControlUI.control.IsLoadedSavePath(idx) = False Then
                        Dim sJIGName As String = Nothing

                        If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                            sJIGName = CStr(Format(idx + 1, "00"))
                        ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                            sJIGName = ucDispJIG.convertIncNumberToMatrixValue(idx)
                        End If

                        '  sJIGName = CStr(Format(idx + 1, "00")) 'ucDispJIG.convertIncNumberToMatrixValue(idx)

                        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_Sequencefile_Savepath, "TEG = " & sJIGName) 'idx + 1)
                        '  MsgBox("Please Check the Sequence file or Save path...")
                        RunToolStripMenuItem.Enabled = True
                        tsBtnTestRUN.Enabled = True
                        Exit Sub
                    End If
                End If
            Next

            'MCR Scan 후 True면 채널 선택 -> 실험정보 로드(시퀀스 파일?) -> Save path 설정?
            RunTest(eTestStartMode.eNew)
            RunToolStripMenuItem.Enabled = True
            'tsBtnTestRUN.Enabled = True
        End If
    End Sub
    'Private Function DataProcessToResultData(ByVal procParam As Integer, ByVal outdata As CDevColorAnalyzerCommonNode.sDataInfos, Optional ByVal measCnt As Integer = 0, Optional ByVal uprime0 As Double = Nothing, Optional ByVal vprime0 As Double = Nothing, Optional ByVal angle As Double = Nothing) As Boolean
    '    Dim Data As sCellIVLMeasure
    '    With Data
    '        .dCIEx = Format(outdata.Data.dCIEx, "0.0000") 'CIE1931
    '        .dCIEy = Format(outdata.Data.dCIEy, "0.0000")
    '        .dY = Format(outdata.Data.dY, "0.000") 'Format(outdata.Data.dY / (procParam.sSampleInfos.dFillFactor / 100), "0.000")
    '        .dX = Format(outdata.Data.dX, "0.000")
    '        .dZ = Format(outdata.Data.dZ, "0.000")
    '        .dLuminance_Cdm2 = outdata.Data.dY
    '        .dLuminance_Fill_Cdm2 = Format(outdata.Data.dLuminance, "0.00") '/ (procParam.sSampleInfos.dFillFactor / 100), "0.00")
    '        .dCIEu = 0 ' Format(outdata.Data.dCIE1976u, "0.0000") 'CIE1976
    '        .dCIEv = 0 'Format(outdata.Data.dCIE1976v, "0.0000")
    '        .dCCT = Format(outdata.Data.CCT, "0")
    '        .dCdA = Format(.dLuminance_Fill_Cdm2 / .dJ, "0.0000E-0")
    '        .dlmW = Format(.dCdA / .dVoltage * Math.PI, "0.0000E-0")
    '        .dDelta_CIE1960 = Format(outdata.Data.duv, "0.0000E-0")
    '        .dWavePeakValue = 0
    '        .nWavePeaklength = 0
    '        .dQE = 0
    '        'MeasurementValue.Radiance = 0
    '        'MeasurementValue.CRI = 0
    '        'MeasurementValue.Intensity = Nothing
    '        'MeasurementValue.Lamda = Nothing
    '        If angle = 0 Then
    '            .dDelta_CIE1976 = Format(0, "0.0000")
    '        Else
    '            .dDelta_CIE1976 = Format(Math.Sqrt(Math.Pow((uprime0 - .dCIEu), 2) + Math.Pow((vprime0 - .dCIEv), 2)), "0.0000")
    '        End If

    '    End With
    '    Return True
    'End Function

    Private Sub RUN()

        If g_SystemInfo.isConnected = True Then

            If g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.eNotUse Then  'Not Pause Mode

                'For i As Integer = 0 To g_AlarmStatus.Length - 1
                '    If g_AlarmStatus(i) = CDevPLCCommonNode.eDISignal.eCylinder Then
                '        If MsgBox("Please check the JIG cover.", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                '            Exit Sub
                '        End If
                '    End If
                'Next

                If g_SystemInfo.bIsShowMessageAlram = True Then
                    If MsgBox("Start Test." & vbCrLf & "Deleting Previous Data.", MsgBoxStyle.OkCancel, "Care !") <> MsgBoxResult.Ok Then
                        Exit Sub
                    End If
                End If

                'CCD 연결해제 시 재연결 진행 (필요없음)
                'If cVision Is Nothing = False Then
                '    If cVision.myVisionCamera.IsConnectedToCamera = False Then
                '        If cVision.myVisionCamera.Reconnection() = False Then
                '            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_List_Log, CStateMsg.eStateMsg.eDEV_ACF_CAMERA_Connected, "Can not Reconnection ACF CAMERA, Please Restart software.")
                '        Else
                '            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_List_Log, CStateMsg.eStateMsg.eDEV_ACF_CAMERA_Connected, "Start to Reconnection ACF CAMERA")
                '        End If
                '    End If
                'End If

                If Channel_checkStart() = False Then
                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_ChannelSelection)
                Else

                    For idx As Integer = 0 To g_nMaxCh - 1
                        If frmControlUI.ControlUI.control.IsSelected(idx) = True Then
                            If frmControlUI.ControlUI.control.IsLoadedSequenceInfo(idx) = False Then ' Or frmControlUI.ControlUI.control.IsLoadedSavePath(idx) = False Then
                                Dim sJIGName As String = Nothing

                                If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                                    sJIGName = CStr(Format(idx + 1, "00"))
                                ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                                    sJIGName = ucDispJIG.convertIncNumberToMatrixValue(idx)
                                End If

                                '  sJIGName = CStr(Format(idx + 1, "00")) 'ucDispJIG.convertIncNumberToMatrixValue(idx)

                                g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_Sequencefile_Savepath, "TEG = " & sJIGName) 'idx + 1)
                                '  MsgBox("Please Check the Sequence file or Save path...")
                                RunToolStripMenuItem.Enabled = True
                                tsBtnTestRUN.Enabled = True
                                Exit Sub
                            End If
                        End If
                    Next
                    RunTest(eTestStartMode.eNew)
                    RunToolStripMenuItem.Enabled = True
                    tsBtnTestRUN.Enabled = True
                End If



            Else  'Pause Mode

                g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_STATUS_PAUSED)

            End If

        Else
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_Connection)   '   MsgBox("시스템 연결 후 사용 하십시오")
        End If



        'If SystemInfo.bIsShowMessageAlram = True Then
        '    If MsgBox("Start Test." & vbCrLf & "Deleting Previous Data.", MsgBoxStyle.OkCancel, "Care !") <> MsgBoxResult.Ok Then
        '        Exit Sub
        '    End If
        'End If

        'RunTest(eTestStartMode.eNew)
        'Else
        '    MsgBox("시스템 연결 후 사용 하십시오")
        'End If
    End Sub

    Private Sub tsBtnTestRUN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnTestRUN.Click
        'cVision.myVisionCamera.AnalysisGrabImage()
        '   cScreenCapture.frmCaptureArea.Hide()

        RUN()
    End Sub

    Private Sub tsBtnTestAppendRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If g_SystemInfo.isConnected = True Then
            If g_SystemInfo.bIsShowMessageAlram = True Then
                If MsgBox("Start Test." & vbCrLf & "saved after the previous data.", MsgBoxStyle.OkCancel, "Care !") <> MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If

            If Channel_checkStart() = False Then
                g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_ChannelSelection)
            Else
                RunTest(eTestStartMode.eAppend)
                RunToolStripMenuItem.Enabled = True
                tsBtnTestRUN.Enabled = True
            End If
        Else
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_Connection)
        End If
    End Sub

    Private Sub tsBtnTestSTOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnTestSTOP.Click
        If g_SystemInfo.isConnected = False Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_Connection)   '   MsgBox("시스템 연결 후 사용 하십시오")
            Exit Sub
        End If

        If g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.eNotUse Then  'Not Pause Mode

            If g_SystemInfo.bIsShowMessageAlram = True Then
                If MsgBox("Really Stop?", MsgBoxStyle.OkCancel, "Care !") <> MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If

            If Channel_checkStart() = False Then
                g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_ChannelSelection)
            Else
                StopTest()
            End If

        Else 'Pause Mode

            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_STATUS_PAUSED)

        End If



        'If SystemInfo.bIsShowMessageAlram = True Then
        '    If MsgBox("Really Stop?", MsgBoxStyle.OkCancel, "Care !") <> MsgBoxResult.Ok Then
        '        Exit Sub
        '    End If
        'End If

        'StopTest()

    End Sub

    Private Sub tsBtnTestPAUSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnTestPAUSE.Click
        'If g_SystemInfo.isConnected = False Then
        '    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_Connection)   '   MsgBox("시스템 연결 후 사용 하십시오")
        '    Exit Sub
        'End If

        'If chkPassWind.ShowDialog <> Windows.Forms.DialogResult.OK Then
        '    '  tsBtnTestPAUSE_Click(tsBtnTestPAUSE, Nothing)
        '    chkPassWind.tbPassword.Text = ""

        '    '  PLC_SafetyModeToPWInputState(CDevPLCCommonNode.eSystemStatus.eSafetyMode_Auto)
        '    Exit Sub
        'End If
        Dim EQPStatus() As CDevPLCCommonNode.eEQPStatus = Nothing
        Dim ReqInfo As CDevPLCCommonNode.sRequestInfo = Nothing

        Dim btn As ToolStripButton = sender

        If g_SystemInfo.isConnected = False Then
            Exit Sub
        End If

        If g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.ePaused Then
            If frmMotionUI.ACFMeas = True Then
                '  MsgBox("Please check ACF experiment status...")
                'MessageBox.Show("Please check ACF experiment status...")
                Exit Sub
            End If

            ' If MsgBox("Pause mode is off.", MsgBoxStyle.OkOnly, g_strMainTitle) = DialogResult.OK Then ' SW Pause를 해제하면 HW의 SAFETY MODE를 Auto로 변경 하십시오.", MsgBoxStyle.OkOnly, g_strMainTitle) = DialogResult.OK Then
            ' If MessageBox.Show("Pause Mode is OFF.", MessageBoxButtons.OK, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
            '  If MessageBox.Show("Pause Mode is OFF", g_strMainTitle, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) = Windows.Forms.DialogResult.OK Then
            If g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.ePaused Then  'Pause 모드 이면
                'Dim bAutoMode As Boolean = False
                'For i As Integer = 0 To cPLC.m_PLCDatas.nSystemStatus.Length - 1
                '    If cPLC.m_PLCDatas.nSystemStatus(i) = CDevPLCCommonNode.eSystemStatus.eAuto_Mode Then
                '        bAutoMode = True
                '    End If
                'Next


                ' If chkPassWind.ShowDialog = Windows.Forms.DialogResult.OK Then
                ' 'tsBtnTestPAUSE_Click(tsBtnTestPAUSE, Nothing)
                ' chkPassWind.tbPassword.Text = ""



                g_PauseCtrl.HomePauseState = CPauseControl.ePAUSEHomming.eNotUse


                ' ''If cPLC.GetCanChange() = False Then
                ' ''    MsgBox("Key Switch 상태를 확인하여 주시기 바랍니다.")
                ' ''    Exit Sub
                ' ''End If

                PLC_SafetyModeToPWInputState(CDevPLCCommonNode.eSystemStatus.eAuto_Mode)

              

                '  Else
                ' '   MsgBox("패스워드 인증에 실패하였습니다. 안전 모드 스위치를 TEACH 모드로 원복 하십시오.")
                '   MsgBox("패스워드 인증에 실패하였습니다. 안전 모드 스위치를 TEACH 모드로 원복 하십시오(안전 모드 스위치를 AUTO 모드로 전환 하기 위해서는 샘플을 재 로딩 해야 합니다)")
                '  End If

            End If
            ResetPause()
            'End If

        ElseIf g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.eRequest Then

            g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_REQUEST_PAUSE)

        Else
            g_PauseCtrl.request()
            SetPause()
        End If

    End Sub

    Private Function Channel_checkStart() As Boolean
        Dim cnt As Integer = 0

        For idx As Integer = 0 To g_nMaxCh - 1
            If frmControlUI.ControlUI.control.IsSelected(idx) = False Then
                cnt = cnt + 1
            End If
        Next

        If cnt = g_nMaxCh Then
            Return False
        End If

        Return True
    End Function

#End Region

#Region "Menu Item Event Handler Functions"

    '======================================================Menu ====================================================================
    'File
    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub


    Private Sub LogInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogInToolStripMenuItem.Click
        Dim dlg As New frmLogInWnd(frmLogInWnd.eLogInMode._Admin)
        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If

        If dlg.bLoginInfo = True Then
            ItemVisibleHide(True)
        ElseIf dlg.bLoginInfo = False Then
            ItemVisibleHide(False)
        End If
    End Sub

    Private Sub SAFETYModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAFETYModeToolStripMenuItem.Click
        Dim dlg As New frmLogInWnd(frmLogInWnd.eLogInMode._Safety)
        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub ItemVisibleHide(ByVal bVal As Boolean)
        SystemConfigurationToolStripMenuItem.Visible = bVal
        ConfigurationToolStripMenuItem.Visible = bVal
        ChannelAllocationToolStripMenuItem.Visible = bVal

        'CalbrationToolStripMenuItem.Visible = bVal

        'If frmControlUI.ControlUI.control.m_nType = ucDispCtrlUICommonNode.eMode.PMXForCommon Then
        '    CalbrationToolStripMenuItem.Visible = False
        'Else
        '    CalbrationToolStripMenuItem.Visible = bVal
        'End If

        TestToolStripMenuItem.Visible = bVal
        ViewToolStripMenuItem.Visible = bVal
        ControlToolStripMenuItem.Visible = bVal
        FunctionTestToolStripMenuItem.Visible = bVal

        If frmMotionUI IsNot Nothing Then
            frmMotionUI.ControlEnable(bVal)
        End If

        'ToolStripMenuItem2.Visible = bVal
        'tsBtnSequenceBuilder.Visible = bVal

        'If frmMonitorUI Is Nothing = False Then

        '    Try
        '        frmMotionUI.Enable_gbMotion(bVal)
        '        frmMotionUI.Enable_gbSourceCtrl(bVal)
        '        frmMotionUI.Enable_gbACFCameraCtrl(bVal)
        '        frmMotionUI.Enable_gbACFCtrl(bVal)

        '    Catch ex As Exception
        '        MsgBox(ex.ToString)
        '    End Try

        'End If



        If frmPretestUI Is Nothing = False Then
            frmPretestUI.Enable_gbControl(bVal)
        End If



    End Sub

    'System
    Private Sub HWConnectionToolStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HWConnectionToolStripMenu.Click
        If g_SystemInfo.bIsShowMessageAlram = True Then
            If MsgBox("System Connection Button," & vbCrLf & "Use when [SW & HW Down And Restart]", MsgBoxStyle.OkCancel, "Care !") <> MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If

        If g_SystemInfo.isConnected = True Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Alrady_Connected)
            Exit Sub
        End If

        g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_Connecting)


        If Connection(eConnectionMode.eHWConnection) = True Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_Connected)


            Dim unnormalStopChannels() As Integer = Nothing

            If cTimeScheduler.IsExistsUnnormalStopChannel(unnormalStopChannels) = True Then
                '    Dim strMsg As String = "비정상적으로 실험이 종료된 채널이 있습니다. 이어서 측정 하시겠습니까? [Target Channel : "
                '    For i As Integer = 0 To unnormalStopChannels.Length - 1
                '        strMsg = strMsg & CStr(i + 1) & ","
                '    Next
                '    strMsg = strMsg & "]"
                '    If MsgBox(strMsg, MsgBoxStyle.OkCancel, g_strMainTitle) = MsgBoxResult.Ok Then   'Append Start

                '        For i As Integer = 0 To unnormalStopChannels.Length - 1
                '            frmControlUI.ControlUI.control.IsSelected(unnormalStopChannels(i)) = True
                '        Next

                '        RunTest(eTestStartMode.eAppend)  '

                '    End If
            End If

        Else
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_ConnectionFailed)
        End If
    End Sub


    Private Sub SWConnectionToolStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SWConnectionToolStripMenu.Click
        If g_SystemInfo.bIsShowMessageAlram = True Then

            If MsgBox("System Connection Button," & vbCrLf & "Use when [Initial Start] or [SW Down And Restart]", MsgBoxStyle.OkCancel, "Care !") <> MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If

        If g_SystemInfo.isConnected = True Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Alrady_Connected)
            Exit Sub
        End If

        g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_Connecting)

        If Connection(eConnectionMode.ePCConnection) = True Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_Connected)

            Dim unnormalStopChannels() As Integer = Nothing

            If cTimeScheduler.IsExistsUnnormalStopChannel(unnormalStopChannels) = True Then
                '    Dim strMsg As String = "비정상적으로 실험이 종료된 채널이 있습니다. 이어서 측정 하시겠습니까? [Target Channel : "
                '    For i As Integer = 0 To unnormalStopChannels.Length - 1
                '        strMsg = strMsg & CStr(i + 1) & ","
                '    Next
                '    strMsg = strMsg & "]"
                '    If MsgBox(strMsg, MsgBoxStyle.OkCancel, g_strMainTitle) = MsgBoxResult.Ok Then   'Append Start

                '        For i As Integer = 0 To unnormalStopChannels.Length - 1
                '            frmControlUI.ControlUI.control.IsSelected(unnormalStopChannels(i)) = True
                '        Next

                '        RunTest(eTestStartMode.eAppend)  '

                '    End If
            End If
        Else
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_ConnectionFailed)
        End If
    End Sub

    Private Sub DisconnectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisconnectionToolStripMenuItem.Click
        DisconnectToDevice()


        ' tsBtnPCConnection.Enabled = True
        tsBtnConnection.Enabled = True
    End Sub



    Private Sub SystemConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemConfigurationToolStripMenuItem.Click
        Dim dlg As New frmConfigSystem

        dlg.Settings = g_ConfigInfos.nDevice
        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            g_ConfigInfos.nDevice = dlg.Settings
        End If

    End Sub

    Private Sub ConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigurationToolStripMenuItem.Click
        Dim dlg As New frmConfigDevice

        If g_ConfigInfos.nDevice Is Nothing = True Or g_ConfigInfos.nDevice.Length = 0 Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_ALARM_Check_SystemConfig)
            Exit Sub
        End If

        dlg.DeviceInfo = g_ConfigInfos.nDevice.Clone
        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            g_ConfigInfos = dlg.ConfigData
            ' cMotion.Settings = g_ConfigInfos.MotionConfig.Clone
        End If

    End Sub

    Private Sub ChannelAllocationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChannelAllocationToolStripMenuItem.Click
        Dim dlg As New frmSettingWind(g_ConfigInfos)

        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then


        End If

    End Sub

    'Settings
    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Dim dlg As New frmOptionWindow(Me)
        Dim OpenFlag As Boolean = True  '정상설정 될때까지 알람 오픈 위함.
        '   dlg.fMain = Me
        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            g_SystemOptions.sOptionData = dlg.Settings
            applyOptions()
        ElseIf Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            Do
                If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                    OpenFlag = False
                End If
            Loop While (OpenFlag)

        End If

    End Sub


    'Test



    Private Sub RunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunToolStripMenuItem.Click
        If g_SystemInfo.isConnected = True Then
            If g_SystemInfo.bIsShowMessageAlram = True Then
                If MsgBox("Start Test." & vbCrLf & "Deleting Previous Data.", MsgBoxStyle.OkCancel, "Care !") <> MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If

            If Channel_checkStart() = False Then
                g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_ChannelSelection)
            Else
                RunTest(eTestStartMode.eNew)
                RunToolStripMenuItem.Enabled = True
                tsBtnTestRUN.Enabled = True
            End If
        Else
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_Connection)
        End If
    End Sub

    Private Sub StopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripMenuItem.Click
        If g_SystemInfo.bIsShowMessageAlram = True Then
            If MsgBox("Really Stop?", MsgBoxStyle.OkCancel, "Care !") <> MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If

        If Channel_checkStart() = False Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_ChannelSelection)
        Else
            StopTest()
        End If
    End Sub

    Private Sub SequenceBuilderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SequenceBuilderToolStripMenuItem.Click
        Dim dlg As New frmSequenceBuilder

        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FunctionTestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FunctionTestToolStripMenuItem.Click

    End Sub

    Private Sub tsBtnAllCheckClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnAllCheckClear.Click
        If g_SystemInfo.isConnected = False Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_Connection)   '   MsgBox("시스템 연결 후 사용 하십시오")
            Exit Sub
        End If

        Dim bSelectJig As Boolean
        '  Dim nJig As Integer

        If g_SystemInfo.bSequenceLoadChk = False Then
            bSelectJig = False
            g_SystemInfo.bSequenceLoadChk = True
        Else
            bSelectJig = True
            g_SystemInfo.bSequenceLoadChk = False
        End If

        For idx As Integer = 0 To g_nMaxCh - 1
            If frmControlUI.ControlUI.control.IsLoadedSequenceInfo(idx) = True Then 'And frmControlUI.ControlUI.control.IsLoadedSavePath(idx) = True Then
                '    nJig = frmSettingWind.GetAllocationValue(idx, frmSettingWind.eChAllocationItem.eJIG_No)
                frmControlUI.SelectedSequenceLoadCh(idx) = bSelectJig
            End If
        Next


        'If frmControlUI.SelectedAllCh = True Then
        '    frmControlUI.SelectedAllCh = False
        'Else
        '    frmControlUI.SelectedAllCh = True
        'End If
    End Sub

    'View Mode
    Private Sub tbSplitSelectCtrlUI_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub JIGLayoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmMonitorUI.HideFrame()
        frmMotionUI.HideFrame()
        frmPretestUI.HideFrame()

        'frmControlUI = New frmCtrlUI(g_nMaxCh, ucDispMultiCtrlCommonNode.eType.JIGLayout)
        'frmControlUI.MdiParent = Me
        'frmControlUI.Location = New System.Drawing.Point(0, 0)
        'frmControlUI.Dock = DockStyle.Fill
        frmControlUI.ShowFrame()
    End Sub

    Private Sub CommonListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmMonitorUI.HideFrame()
        frmMotionUI.HideFrame()
        frmPretestUI.HideFrame()

        frmControlUI = New frmCtrlUI(g_nMaxCh, ucDispMultiCtrlCommonNode.eType.ListType)
        frmControlUI.MdiParent = Me
        frmControlUI.Location = New System.Drawing.Point(0, 0)
        frmControlUI.Dock = DockStyle.Fill
        frmControlUI.ShowFrame()
    End Sub

    Private Sub SimpleListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmMonitorUI.HideFrame()
        frmMotionUI.HideFrame()
        frmPretestUI.HideFrame()

        frmControlUI = New frmCtrlUI(g_nMaxCh, ucDispMultiCtrlCommonNode.eType.ListTypeForQC)
        frmControlUI.MdiParent = Me
        frmControlUI.Location = New System.Drawing.Point(0, 0)
        frmControlUI.Dock = DockStyle.Fill
        frmControlUI.ShowFrame()
    End Sub

    Private Sub CustomTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmMonitorUI.HideFrame()
        frmMotionUI.HideFrame()
        frmPretestUI.HideFrame()

        frmControlUI = New frmCtrlUI(g_nMaxCh, ucDispMultiCtrlCommonNode.eType.CustomTypeForQC)
        frmControlUI.MdiParent = Me
        frmControlUI.Location = New System.Drawing.Point(0, 0)
        frmControlUI.Dock = DockStyle.Fill
        frmControlUI.ShowFrame()
    End Sub

    Private Sub TestUIToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        frmControlUI.ShowFrame()

        frmMonitorUI.HideFrame()
        frmMotionUI.HideFrame()
        frmPretestUI.HideFrame()
    End Sub

    'Motion
    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSelUI_Motion.Click

        If g_SystemInfo.isConnected = False Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_Connection)   '   MsgBox("시스템 연결 후 사용 하십시오")
            Exit Sub
        End If

        ' If g_PLCState = PLCState.eTeach Then

        frmMotionUI.Enable_gbMotion(True)
        frmMotionUI.Enable_gbSourceCtrl(True)
        frmMotionUI.Enable_gbACFCameraCtrl(True)
        frmMotionUI.Enable_gbACFCtrl(True)
        frmMotionUI.Enable_gbACFMeas(True)
        Thread.Sleep(100)
        If cQueueProcessor.CheckProcess = True Then
            frmMotionUI.Enable_btnThetaHomming(False)
        Else
            frmMotionUI.Enable_btnThetaHomming(True)
        End If

        'Else
        'frmMotionUI.Enable_gbMotion(False)
        '' frmMotionUI.Enable_gbSourceCtrl(False)
        'frmMotionUI.Enable_gbACFCameraCtrl(False)
        'frmMotionUI.Enable_gbACFCtrl(False)
        'frmMotionUI.Enable_gbACFMeas(False)
        'End If

        frmMotionUI.SetAperture()   '이동시 설정된 Aperture 적용
        Thread.Sleep(100)
        frmMotionUI.ShowFrame()
        frmMonitorUI.HideFrame()
        frmPretestUI.HideFrame()

    End Sub

     Public Function PLCScan(ByVal nPLCStatus As CSheduler_PLC.eChSchedulerPLCSTATE, ByVal nCurrentSlot As Integer) As Boolean
       Dim reqInfo As CDevPLCCommonNode.sRequestInfo = Nothing
        Dim nCnt As Integer = 0

        PLCQueueCounter("PLC State = " & nPLCStatus.ToString)

        Select Case nPLCStatus
            Case CSheduler_PLC.eChSchedulerPLCSTATE.eIDLE

            Case CSheduler_PLC.eChSchedulerPLCSTATE.eHome

                'If bSupplyHome = False Then
                '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eSetMagazineSupplyStatus
                '    '  reqInfo.nMagazineStatus = CDevPLCCommonNode.eMagazineStatus.ePallet_Up
                '    reqInfo.nMagazineStatus = CDevPLCCommonNode.eMagazineStatus.eHome
                '    If cPLC.SetMagazineSupplyStatus(reqInfo) = False Then
                '        'ㅕㅛㅛ쇼()
                '    End If
                'End If

                'If bExhausHome = False Then
                '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eSetMagazineExhausStatus
                '    '  reqInfo.nMagazineStatus = CDevPLCCommonNode.eMagazineStatus.ePallet_Up
                '    reqInfo.nMagazineStatus = CDevPLCCommonNode.eMagazineStatus.eHome
                '    If cPLC.SetMagazineExhausStatus(reqInfo) = False Then

                '    End If
                'End If

                'If bSupplyHome = False Then
                '    Do
                '        Application.DoEvents()
                '        Thread.Sleep(100)
                '        For i As Integer = 0 To cPLC.m_PLCDatas.nSupplyMagazineStatus.Length - 1
                '            '  If cPLC.m_PLCDatas.nSupplyMagazineStatus(i) = CDevPLCCommonNode.eMagazineStatus.eUpDownEnd Then
                '            If cPLC.m_PLCDatas.nSupplyMagazineStatus(i) = CDevPLCCommonNode.eMagazineStatus.eHomeEnd Then
                '                Exit Do
                '            End If
                '        Next
                '    Loop


                '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eSetMagazineSupplyStatus
                '    reqInfo.nMagazineStatus = CDevPLCCommonNode.eMagazineStatus.eReady
                '    If cPLC.SetMagazineSupplyStatus(reqInfo) = False Then

                '    End If

                '    Do
                '        nCnt = 0
                '        Application.DoEvents()
                '        Thread.Sleep(100)
                '        For i As Integer = 0 To cPLC.m_PLCDatas.nSupplyMagazineStatus.Length - 1
                '            ' If cPLC.m_PLCDatas.nSupplyMagazineStatus(i) = CDevPLCCommonNode.eMagazineStatus.eUpDownEnd Then
                '            If cPLC.m_PLCDatas.nSupplyMagazineStatus(i) = CDevPLCCommonNode.eMagazineStatus.eHomeEnd Then
                '                nCnt += 1
                '            End If
                '        Next
                '    Loop Until nCnt = 0
                'End If


                'If bExhausHome = False Then
                '    Do
                '        Application.DoEvents()
                '        Thread.Sleep(100)
                '        For i As Integer = 0 To cPLC.m_PLCDatas.nExhausMagazineStatus.Length - 1
                '            If cPLC.m_PLCDatas.nExhausMagazineStatus(i) = CDevPLCCommonNode.eMagazineStatus.eHomeEnd Then
                '                Exit Do
                '            End If
                '        Next
                '    Loop


                '    reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eSetMagazineExhausStatus
                '    reqInfo.nMagazineStatus = CDevPLCCommonNode.eMagazineStatus.eReady
                '    If cPLC.SetMagazineExhausStatus(reqInfo) = False Then

                '    End If

                '    Do
                '        nCnt = 0
                '        Application.DoEvents()
                '        Thread.Sleep(100)
                '        For i As Integer = 0 To cPLC.m_PLCDatas.nExhausMagazineStatus.Length - 1
                '            If cPLC.m_PLCDatas.nExhausMagazineStatus(i) = CDevPLCCommonNode.eMagazineStatus.eHomeEnd Then
                '                nCnt += 1
                '            End If
                '        Next
                '    Loop Until nCnt = 0
                'End If

            Case CSheduler_PLC.eChSchedulerPLCSTATE.eRun
                Dim EQPState() As CDevPLCCommonNode.eEQPStatus = Nothing

                '리셋 진행하고 시작해야됨
                reqInfo.nEQPStatus = CDevPLCCommonNode.eEQPStatus.eReset
                If cPLC.SetEQPStatus(reqInfo) = False Then Return False

                Application.DoEvents()
                Thread.Sleep(500)

                reqInfo.nEQPStatus = CDevPLCCommonNode.eEQPStatus.eRun
                If cPLC.SetEQPStatus(reqInfo) = False Then Return False

                cPLC.GetEQPStatue(EQPState)

                Application.DoEvents()
                Thread.Sleep(500)

                Do
                    Application.DoEvents()
                    Thread.Sleep(300)
                    cPLC.GetEQPStatue(EQPState)
                Loop Until EQPState(0) = CDevPLCCommonNode.eEQPStatus.eRun

            Case CSheduler_PLC.eChSchedulerPLCSTATE.eProcess

            Case CSheduler_PLC.eChSchedulerPLCSTATE.eSupply

                'RUN 신호변경 후 SUPPLY 진입까지 대기 시간 필요함
                Application.DoEvents()
                Thread.Sleep(3000)

                '   Dim nSupplyCnt As Integer
                Dim bMoveCompleted As Boolean = False
                '투입 연속 동작 가능 상태 조회
                reqInfo.nSlotNumber = nCurrentSlot + 1
                If cPLC.SetSlotSupply(reqInfo) = False Then
                    'supply 실패 시 edle로 보냄
                    cPLCScheduler.g_ChSchedulerPLCStatus = CSheduler_PLC.eChSchedulerPLCSTATE.eIDLE
                    Return False

                Else
                    Do
                        Application.DoEvents()
                        Thread.Sleep(300)
                        If cPLC.GetSupplyMoveCompleted(bMoveCompleted) = False Then
                            'Return False
                        Else
                            If bMoveCompleted = True Then
                                Exit Do
                            End If
                        End If

                    Loop
                End If

                '투입 연속 동작 STATUS 확인

            Case CSheduler_PLC.eChSchedulerPLCSTATE.eExhaus
                Dim bMoveCompleted As Boolean = False
                '투입 연속 동작 가능 상태 조회
                reqInfo.nSlotNumber = nCurrentSlot + 1
                If cPLC.SetSlotExhaust(reqInfo) = False Then
                    'supply 실패 시 edle로 보냄
                    cPLCScheduler.g_ChSchedulerPLCStatus = CSheduler_PLC.eChSchedulerPLCSTATE.eIDLE
                    Return False
                Else
                    Do
                        Application.DoEvents()
                        Thread.Sleep(300)

                        If cPLC.GetExhaustMoveCompleted(bMoveCompleted) = False Then
                            ' Return False
                        Else
                            If bMoveCompleted = True Then
                                Exit Do
                            End If
                        End If
                    Loop
                End If

        End Select

        Return True
    End Function

    'Pretest
    Private Sub pretert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPretestViewMode.Click
        'For i As Integer = 0 To g_nMaxCh - 1
        '    If cTimeScheduler.g_ChSchedulerStatus(i) <> CScheduler.eChSchedulerSTATE.eIdle Then
        '        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eStateMsg.eSYSTEM_MSG_Can_use_in_IDLE_STATUE, "[" & Format(i + 1, "000") & "번 채널이 실험 중입니다.")
        '        Exit Sub
        '    End If
        'Next
        Dim bCheckedState() As Boolean = Nothing

        ReDim bCheckedState(g_nMaxCh - 1)

        Dim KeithleyInfo As ucKeithleySMUSettings.sKeithley

        With KeithleyInfo
            .CurrentAutoRange = True
            .VoltageAutoRange = True
            .IntegTime_Sec = 1
            .LimitCurrent = 0.1
            .LimitVoltage = 20
            .MeasureDelay_Sec = 0.1
            .MeasureDelayAuto = 0.1
            .MeasureMode = CSMULib.ucKeithleySMUSettings.eMeasValue.eCurrent
            .NumOfMeasData = 1000
            .SourceChannel = CSMULib.ucKeithleySMUSettings.eSMUCH.eChA
            .SourceDelay_Sec = 0.1
            .SourceMode = CSMULib.ucKeithleySMUSettings.eSMUMode.eVoltage
            .WireMode = CSMULib.ucKeithleySMUSettings.eProve.e2Prove
        End With

        cIVLSMU(0).mySMU.InitializeSweep(KeithleyInfo)

        For idx As Integer = 0 To g_nMaxCh - 1
            If cTimeScheduler.g_ChSchedulerStatus(idx) = CScheduler.eChSchedulerSTATE.eIdle Then
                bCheckedState(idx) = cTimeScheduler.CheckedSampleContact(idx, KeithleyInfo)
            Else
                bCheckedState(idx) = False
            End If

            frmControlUI.ControlUI.control.DispChSampleUI(idx).CellColor_OFF = Color.Black
            frmControlUI.ControlUI.control.DispChSampleUI(idx).CellStatus = ucDispSampleCommonNode.eCellState.eOFF

            If bCheckedState(idx) = True Then
                frmControlUI.ControlUI.control.DispChSampleUI(idx).CellColor_OFF = Color.PowderBlue
            Else
                frmControlUI.ControlUI.control.DispChSampleUI(idx).CellColor_OFF = Color.Red
            End If
        Next

        'cSwitch(0).mySwitch.AllOFF()
        For ch As Integer = 0 To g_nMaxCh - 1
            cSwitch(0).mySwitch.SwitchOFF(ch)
        Next

        'frmPretestUI.ShowFrame()
        'frmMonitorUI.HideFrame()
        'frmMotionUI.HideFrame()
    End Sub


    Private Sub tsbSelUI_Monitoring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSelUI_Monitoring.Click

        ' For i As Integer = 0 To 6
        'tlHWStatus(i).BackColor = Color.Lime
        '  Next


        frmMonitorUI.ShowFrame()
        'frmMotionUI.HideFrame()
        'frmPretestUI.HideFrame()           '명구
    End Sub

    Private Sub tsIVLDisplayShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsIVLDisplayShow.Click
        'frmIVLDisplayWind.Hide()
        If frmIVLDispWind Is Nothing Then Exit Sub

        frmIVLDispWind.HideFrame()
        frmIVLDispWind.ShowFrame()
    End Sub

    ' Private Sub tsBtnCharViewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnCharViewer.Click
    ' ''If sSystemOption.bEnableDataViewerLink = False Then
    ' ''    'Message 추가
    ' ''    Exit Sub
    ' ''Else
    ' ''    If File.Exists(sSystemOption.sPathOfDataViewre) = False Then
    ' ''        'Message 추가
    ' ''        Exit Sub
    ' ''    End If
    ' ''End If

    ' ''Dim sSavePath() As String = Nothing
    ' ''Dim nCnt As Integer

    ' ''For i As Integer = 0 To g_nMaxCh - 1
    ' ''    If frmControlUI.ControlUI.control.IsSelected(i) = True Then

    ' ''        If DataSaver(i) Is Nothing = False Then
    ' ''            If DataSaver(i).m_sSavePath Is Nothing = False Then
    ' ''                For n As Integer = 0 To DataSaver(i).m_sSavePath.Length - 1
    ' ''                    ReDim Preserve sSavePath(nCnt)
    ' ''                    sSavePath(nCnt) = DataSaver(i).m_sSavePath(n)
    ' ''                    nCnt += 1
    ' ''                Next
    ' ''            End If

    ' ''        End If
    ' ''    End If

    ' ''Next

    ' ''If File.Exists(g_sFilePath_ViewerData) = True Then
    ' ''    File.Delete(g_sFilePath_ViewerData)
    ' ''End If

    ' ''Dim Saver As New CViewerLinkInfoINI(g_sFilePath_ViewerData)

    ' ''If sSavePath Is Nothing = False Then
    ' ''    Saver.SaveIniValue(CViewerLinkInfoINI.eSecID.eCommon, 0, CViewerLinkInfoINI.eKeyID.NumberOfLinkFile, CStr(sSavePath.Length))

    ' ''    For i As Integer = 0 To sSavePath.Length - 1
    ' ''        Saver.SaveIniValue(CViewerLinkInfoINI.eSecID.eCommon, 0, CViewerLinkInfoINI.eKeyID.Path, i, sSavePath(i))
    ' ''    Next
    ' ''Else
    ' ''    Saver.SaveIniValue(CViewerLinkInfoINI.eSecID.eCommon, 0, CViewerLinkInfoINI.eKeyID.NumberOfLinkFile, CInt(0))
    ' ''End If

    ' ''Process.Start(sSystemOption.sPathOfDataViewre)


    '' ''m_M6000Viewer = Shell(FilePath, AppWinStyle.NormalNoFocus)
    ' End Sub

    ''Public Function DataViewerFindPath() As String  '고온수명 Data 데이터 경로 확인 및 File List 확인'ByRef ViewDataFilePaths() As sFileInfo

    ' ''Dim FilePath() As String = Split(Application.StartupPath, "\")
    ' ''Dim SaveFilePath As String = ""
    ' ''Dim ReadFilePath() As String = Nothing
    ' ''Dim ReadFileName() As String = Nothing


    ' ''If FilePath.Length > 0 Then

    ' ''    For i As Integer = 0 To FilePath.Length - 1

    ' ''        SaveFilePath = SaveFilePath & FilePath(i) & "\"

    ' ''        If Directory.Exists(SaveFilePath & m_PATH_ViewerFolder & "\") = True Then

    ' ''            SaveFilePath = SaveFilePath & m_PATH_ViewerFolder & "\"

    ' ''            Exit For
    ' ''        End If
    ' ''    Next

    ' ''End If


    ' ''Dim RetSaveFath As String = SaveFilePath
    ' ''Dim idx As Integer = 0

    ' ''Do

    ' ''    ReadFilePath = Directory.GetDirectories(SaveFilePath)

    ' ''    If ReadFilePath.Length = 0 Or Nothing Then
    ' ''        SaveFilePath = RetSaveFath
    ' ''        idx += 1
    ' ''    Else
    ' ''        SaveFilePath = ReadFilePath(idx)
    ' ''    End If

    ' ''    ReadFilePath = Directory.GetFiles(SaveFilePath, "Viewer.exe")

    ' ''    If ReadFilePath.Length <> 0 Then
    ' ''        RetSaveFath = ReadFilePath(0)
    ' ''        Exit Do
    ' ''    End If

    ' ''Loop

    ' ''Return RetSaveFath

    '' End Function

    'For a Test (AutoUpdate) 20130705
    ' ''Private Function CopyViewData(ByRef ErrChannel As Integer) As Boolean  '선택된 채널 파일 저장  Function 2013-04-25 승현

    ' ''    Dim FilePath() As String = Split(Application.StartupPath, "\")
    ' ''    Dim SaveFilePath As String = ""
    ' ''    Dim sMsg() As String

    ' ''    Try

    ' ''        Dim sViewDataList() As String = Nothing

    ' ''        For i As Integer = 0 To FilePath.Length - 1
    ' ''            SaveFilePath = SaveFilePath & FilePath(i) & "\"

    ' ''            If Directory.Exists(SaveFilePath & g_SPATH_ROOT_MCSCIENCE & "\") = True Then
    ' ''                SaveFilePath = SaveFilePath & g_SPATH_ROOT_MCSCIENCE & "\"
    ' ''                Exit For
    ' ''            End If
    ' ''        Next

    ' ''        g_sPATH_ViewerData = SaveFilePath & "ViewerData" & "\"

    ' ''        If Directory.Exists(g_sPATH_ViewerData) = False Then '폴더 없으면 새로 생성
    ' ''            Directory.CreateDirectory(g_sPATH_ViewerData)
    ' ''        End If

    ' ''        sViewDataList = Directory.GetFiles(g_sPATH_ViewerData) '폴더 내의 파일 개수 확인

    ' ''        If sViewDataList.Length > 0 Then '파일 있으면 폴더 삭제 후 다시 선언
    ' ''            Directory.Delete(g_sPATH_ViewerData, True)
    ' ''            Directory.CreateDirectory(g_sPATH_ViewerData)
    ' ''        End If

    ' ''        Dim NewSavePath As String = Nothing

    ' ''        NewSavePath = g_sPATH_ViewerData & g_ViewerData_FileName '"DataViewInfo.csv"

    ' ''        Dim DataSaver As cDataOutput

    ' ''        DataSaver = New cDataOutput(SequenceList(g_nMaxCh - 1).SequenceInfo, g_nMaxCh - 1)
    ' ''        'DataSaver = New cDataOutput(SequenceList(g_nMaxCh - 1).SequenceInfo, g_nMaxCh - 1)

    ' ''        DataSaver.CrateSaveFile(NewSavePath)
    ' ''        '   CrateSaveFile(NewSavePath)


    ' ''        ReDim sMsg(g_nMaxCh - 1)

    ' ''        For i As Integer = 0 To g_nMaxCh - 1 '전 채널 중
    ' ''            If frmControlUI.ControlUI.control.IsSelected(i) = True Then '체크 된 채널이면
    ' ''                Dim FileName As String = Nothing
    ' ''                Dim TempFilePath() As String

    ' ''                sMsg(i) = SequenceList(i).SequenceInfo.sCommon.saveInfo.strPathAndFName 'CommSettings.SavePathInfo.strPathAndFName

    ' ''                TempFilePath = Split(SequenceList(i).SequenceInfo.sCommon.saveInfo.strOnlyFName, "_") ' 데이터 형식 확인

    ' ''                If TempFilePath.Length > 0 Then
    ' ''                    FileName = SequenceList(i).SequenceInfo.sCommon.saveInfo.strFPath & "CH" & Format(i + 1, "000") & "_" & SequenceList(i).SequenceInfo.sCommon.saveInfo.strOnlyFName & "_Index1." & SequenceList(i).SequenceInfo.sCommon.saveInfo.strOnlyExt
    ' ''                End If

    ' ''                sMsg(i) = FileName
    ' ''            End If
    ' ''        Next


    ' ''        '데이터 개수 때문에 추가됨
    ' ''        Dim sMsgEnd() As String
    ' ''        Dim cnt As Integer = 0

    ' ''        For i As Integer = 0 To sMsg.Length - 1
    ' ''            If sMsg(i) <> Nothing Then
    ' ''                cnt = cnt + 1
    ' ''            End If
    ' ''        Next

    ' ''        ReDim sMsgEnd(cnt - 1)
    ' ''        Dim j As Integer = 0
    ' ''        For i As Integer = 0 To sMsg.Length - 1
    ' ''            If sMsg(i) <> Nothing Then
    ' ''                sMsgEnd(j) = sMsg(i)
    ' ''                j = j + 1
    ' ''            End If
    ' ''        Next

    ' ''        DataSaver.WriteFile(NewSavePath, sMsgEnd)

    ' ''        Return True

    ' ''    Catch ex As Exception

    ' ''        Return False

    ' ''    End Try

    ' ''End Function


    Private Sub tsBtnCare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnCare.Click
        If g_SystemInfo.bIsShowMessageAlram = False Then
            g_SystemInfo.bIsShowMessageAlram = True
            tsBtnCare.BackColor = Color.Orange '.LightYellow
        Else
            g_SystemInfo.bIsShowMessageAlram = False
            tsBtnCare.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub tsBtnAlarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnAlarm.Click
        If g_SystemOptions.bEnableAlarm = False Then
            g_SystemOptions.bEnableAlarm = True
            tsBtnAlarm.BackColor = Color.OrangeRed 'Color.LightYellow
        Else
            g_SystemOptions.bEnableAlarm = False
            tsBtnAlarm.BackColor = Color.Transparent
        End If
    End Sub


    Private Sub tsBtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnExit.Click
        Me.Close()
    End Sub

    '================================================ICON TOOL Bar==================================================
    ' Connection And Disconnection

    Private Sub tsbConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnConnection.Click
        If g_SystemInfo.bIsShowMessageAlram = True Then
            If MsgBox("System Connection Button," & vbCrLf & "Use when [SW & HW Down And Restart]", MsgBoxStyle.OkCancel, "Care !") <> MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If

        If g_SystemInfo.isConnected = True Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Alrady_Connected)
            Exit Sub
        End If

        g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_Connecting)

        If Connection(eConnectionMode.eHWConnection) = True Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_Connected)

            Dim unnormalStopChannels() As Integer = Nothing

            If cTimeScheduler.IsExistsUnnormalStopChannel(unnormalStopChannels) = True Then

                'LEX
                Dim strMsg As String = "비정상적으로 실험이 종료된 채널이 있습니다. 이어서 측정 하시겠습니까? [Target Channel : "
                Dim sJIGName As String = Nothing

                For i As Integer = 0 To unnormalStopChannels.Length - 1
                    If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                        sJIGName = "PANEL" & Format(unnormalStopChannels(i) + 1, "00") & ","
                    ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                        sJIGName = "PANEL" & ucDispJIG.convertIncNumberToMatrixValue(unnormalStopChannels(i)) & ","
                    End If

                    strMsg = strMsg & sJIGName '"TEG " & Format(unnormalStopChannels(i) + 1, "00") & "," 'ucDispJIG.convertIncNumberToMatrixValue(unnormalStopChannels(i)) & ","
                Next
                strMsg = strMsg & "]"
                If MsgBox(strMsg, MsgBoxStyle.OkCancel, g_strMainTitle) = MsgBoxResult.Ok Then   'Append Start
                    For i As Integer = 0 To unnormalStopChannels.Length - 1
                        LoadLastSequenceFile(unnormalStopChannels(i))
                        frmControlUI.ControlUI.control.IsSelected(unnormalStopChannels(i)) = True
                    Next
                    RunTest(eTestStartMode.eAppend)  '
                    RunToolStripMenuItem.Enabled = True
                    tsBtnTestRUN.Enabled = True
                Else
                    For i As Integer = 0 To unnormalStopChannels.Length - 1
                        g_SystemInfo.bCanUpdateStateInfoOfCh(unnormalStopChannels(i)) = True

                        For j As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
                            '각 채널별로 한번씩 초기화 시켜 준다.
                            If g_ConfigInfos.nDevice(j) = frmConfigSystem.eDeviceItem.eSMU_M6000 Then
                                Dim nDevNo As Integer
                                Dim nChNo As Integer
                                nDevNo = frmSettingWind.GetAllocationValue(unnormalStopChannels(i), frmSettingWind.eChAllocationItem.eDevNoOfM6000)
                                nChNo = frmSettingWind.GetAllocationValue(unnormalStopChannels(i), frmSettingWind.eChAllocationItem.eChOfM6000)

                                If cM6000(nDevNo).Request(nChNo, CSeqRoutineM6000.eSequenceState.eReset) = True Then
                                End If
                            End If

                            '각 장비별로 한번씩만 초기화 시켜 준다.
                            If i = 0 Then
                                If g_ConfigInfos.nDevice(j) = frmConfigSystem.eDeviceItem.eSMU_IVL Then
                                    For nDevKeithleyNumber As Integer = 0 To g_ConfigInfos.SMUForIVLConfig.Length - 1
                                        If cIVLSMU(nDevKeithleyNumber).mySMU.FinalizeSweep() = False Then
                                        End If
                                    Next
                                ElseIf g_ConfigInfos.nDevice(j) = frmConfigSystem.eDeviceItem.eSwitch Then
                                    For nDevSWNumber As Integer = 0 To g_ConfigInfos.SwitchConfig.Length - 1
                                        For ch As Integer = 0 To g_nMaxCh - 1
                                            cSwitch(nDevSWNumber).mySwitch.SwitchOFF(ch)
                                        Next
                                    Next
                                End If
                            End If
                        Next
                    Next
                End If
            End If

            '컴포넌트에 대한 값들을 장비에서 읽어와서 Manual Mode에 Set 통신 연결이 되어 있어야 하기 때문에 이부분에 추가 시킴 
            frmMotionUI.ManualDeviceOption(g_SystemOptions.sDeviceOption)
        Else
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State_Log_Popup, CStateMsg.eStateMsg.eSYSTEM_STATUS_ConnectionFailed)
        End If
    End Sub

    Private Sub tsbSWConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSWConnection.Click
        If g_SystemInfo.bIsShowMessageAlram = True Then

            If MsgBox("System Connection Button," & vbCrLf & "Use when [Initial Start] or [SW Down And Restart]", MsgBoxStyle.OkCancel, "Care !") <> MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If

        If g_SystemInfo.isConnected = True Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Alrady_Connected)
            Exit Sub
        End If

        g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_Connecting)

        If Connection(eConnectionMode.ePCConnection) = True Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_Connected)

            Dim unnormalStopChannels() As Integer = Nothing

            If cTimeScheduler.IsExistsUnnormalStopChannel(unnormalStopChannels) = True Then
                'Dim strMsg As String = "비정상적으로 실험이 종료된 채널이 있습니다. 이어서 측정 하시겠습니까? [Target Channel : "
                ''For i As Integer = 0 To unnormalStopChannels.Length - 1
                ''    strMsg = strMsg & CStr(i + 1) & ","
                ''Next
                'For i As Integer = 0 To unnormalStopChannels.Length - 1
                '    strMsg = strMsg & CStr(unnormalStopChannels(i) + 1) & ","
                'Next

                'strMsg = strMsg & "]"
                'If MsgBox(strMsg, MsgBoxStyle.OkCancel, g_strMainTitle) = MsgBoxResult.Ok Then   'Append Start

                '    For i As Integer = 0 To unnormalStopChannels.Length - 1
                '        frmControlUI.ControlUI.control.IsSelected(unnormalStopChannels(i)) = True
                '    Next

                '    RunTest(eTestStartMode.eAppend)  '

                'End If
            End If

            '컴포넌트에 대한 값들을 장비에서 읽어와서 Manual Mode에 Set 통신 연결이 되어 있어야 하기 때문에 이부분에 추가 시킴 
            frmMotionUI.ManualDeviceOption(g_SystemOptions.sDeviceOption)
        Else
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State_Log_Popup, CStateMsg.eStateMsg.eSYSTEM_STATUS_ConnectionFailed)
        End If
    End Sub

    Private Sub tsBtnDisconnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnDisconnection.Click
        ' cMeasurementor.trdMeasStop()


        If g_SystemInfo.bIsShowMessageAlram = True Then

            If MsgBox("Disconnect the system. Disconnecting the system while an experiment is in progress can cause serious problems. Do you really want to turn it off?", MsgBoxStyle.OkCancel, "Care !") = MsgBoxResult.Cancel Then
                Exit Sub
            End If

        End If

        DisconnectToDevice()


        '실제 통신 열결된 체널을 확인 하고 UI Enable or Disable
        UpdateChannelUI()

        '    tsBtnPCConnection.Enabled = True
        tsBtnConnection.Enabled = True

        g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eSYSTEM_STATUS_Disconnected)
    End Sub

#End Region

#Region "Menu : Component Control"

    'Component control
    Private Sub MotionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MotionToolStripMenuItem.Click
      Dim dlg As New frmPLCMotionControl(Me, g_ConfigInfos)
        If dlg.ShowDialog = DialogResult.OK Then
        End If
    End Sub

    Private Sub PDMeasurementUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDMeasurementUnitToolStripMenuItem.Click
        Dim dlg As New frmPDUnitControl(Me, g_ConfigInfos)
        If dlg.ShowDialog = DialogResult.OK Then

        End If
    End Sub

    Private Sub PLCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLCToolStripMenuItem.Click
        Dim dlg As New frmPLCControl(Me, g_ConfigInfos)
        If dlg.ShowDialog = DialogResult.OK Then

        End If
    End Sub

    Private Sub MC9ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MC9ToolStripMenuItem.Click
        'Dim dlg As New frmPDUnitControl(Me, g_ConfigInfos)
        'If dlg.ShowDialog = DialogResult.OK Then

        'End If
    End Sub

    Private Sub NX1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NX1ToolStripMenuItem.Click
        Dim dlg As New frmTCNx1(Me, g_ConfigInfos)
        If dlg.ShowDialog = DialogResult.OK Then

        End If
    End Sub

    Private Sub THC98585ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles THC98585ToolStripMenuItem.Click
        Dim dlg As New frmTHCControl(Me, g_ConfigInfos)
        If dlg.ShowDialog = DialogResult.OK Then

        End If
    End Sub

    Private Sub TTM004ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TTM004ToolStripMenuItem.Click
        Dim dlg As New frmTCTTM004(Me, g_ConfigInfos)

        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub SpectrometerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpectrometerToolStripMenuItem.Click
        Dim dlg As New frmSpectrometer(Me, g_ConfigInfos)

        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub


    Private Sub M6000ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M6000ToolStripMenuItem.Click
        Dim dlg As New frmMcM600(Me, g_ConfigInfos.M6000Config)

        If dlg.ShowDialog = DialogResult.OK Then
        End If
    End Sub

    Private Sub SignalGeneratorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SignalGeneratorToolStripMenuItem.Click
        Dim dlg As New frmSGControl(Me, g_ConfigInfos)

        If cMcSG Is Nothing Then
            g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State_Log_Popup, CStateMsg.eStateMsg.eDEV_COMMON_MSG_CanNotInit)
            Exit Sub
        End If
        For i As Integer = 0 To cMcSG.Length - 1
            cMcSG(i).EnableSequenceRoutinePaused = True
        Next

        If dlg.ShowDialog = DialogResult.OK Then

        End If

        For i As Integer = 0 To cMcSG.Length - 1
            cMcSG(i).EnableSequenceRoutinePaused = False
        Next
    End Sub

    Private Sub PatternGeneratorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatternGeneratorToolStripMenuItem.Click


        'Select Case g_ConfigInfos.PGConfig.nDeviceType

        '    Case CDevPGCommonNode.eModel._G4S

        '    Case CDevPGCommonNode.eModel._McPG
        '        Dim dlg As New frmMcPGControl(Me, g_ConfigInfos)
        '        If cPG Is Nothing Then Exit Sub
        '        For i As Integer = 0 To cPG.PatternGenerator.Length - 1
        '            cPG.PatternGenerator(i).EnableSequenceRoutinePaused = True
        '        Next

        '        dlg.ShowDialog()
        '        'If dlg.ShowDialog = DialogResult.OK Then
        '        'End If

        '        For i As Integer = 0 To cPG.PatternGenerator.Length - 1
        '            cPG.PatternGenerator(i).EnableSequenceRoutinePaused = False
        '        Next
        '    Case Else

        'End Select


        Dim bExistPGDev As Boolean = False

        For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
            If g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.ePG Then
                If g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._G4S Or _
                    g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._McPG Then
                    bExistPGDev = True
                End If
            End If
        Next

        If bExistPGDev = False Then
            MsgBox("The function can not use")
            Exit Sub
        End If

        Select Case g_ConfigInfos.PGConfig.nDeviceType

            Case CDevPGCommonNode.eDevModel._McPG
                Dim dlg As New frmMcPGTestUI(Me, g_ConfigInfos)
                If dlg.ShowDialog = DialogResult.OK Then

                End If
            Case CDevPGCommonNode.eDevModel._G4S
                Dim dlg As New frmG4sTestUI(cPG, g_ConfigInfos.PGConfig.G4sConfig, Me, False)
                dlg.ShowDialog()


                '실제 통신 열결된 체널을 확인 하고 UI Enable or Disable
                UpdateChannelUI()

                'Dim nDevNo As Integer
                'For i As Integer = 0 To g_ConfigInfos.PGConfig.G4sConfig.iAllocationCh.Length - 1
                '    nDevNo = frmSettingWind.GetAllocationValue(g_ConfigInfos.PGConfig.G4sConfig.iAllocationCh(i), frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
                '    If cPG.PatternGenerator(0).IsConnectedSubChannel(nDevNo) = True Then
                '        frmControlUI.ControlUI.control.dispJIG(g_ConfigInfos.PGConfig.G4sConfig.iAllocationCh(i)).Enabled = True
                '    Else
                '        frmControlUI.ControlUI.control.dispJIG(g_ConfigInfos.PGConfig.G4sConfig.iAllocationCh(i)).Enabled = False
                '    End If
                'Next

        End Select

    End Sub

    Private Sub K26XXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K26XXToolStripMenuItem.Click
        Dim dlg As New frmK26XXControl(Me)
        If dlg.ShowDialog = DialogResult.OK Then

        End If
    End Sub

    Private Sub K24XXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K24XXToolStripMenuItem.Click
        Dim dlg As New frmK24XXControl(Me)
        If dlg.ShowDialog = DialogResult.OK Then

        End If
    End Sub

    Private Sub K23XToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K23XToolStripMenuItem.Click
        Dim dlg As New frmK23XControl(Me)
        If dlg.ShowDialog = DialogResult.OK Then

        End If
    End Sub
#End Region

    Private Sub ShowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowToolStripMenuItem.Click
        frmLog.Show()
    End Sub

    Private Sub HideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolStripMenuItem.Click
        frmLog.Hide()
    End Sub


    Private Sub TestUIToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestUIToolStripMenuItem2.Click
        Dim bDevExist As Boolean = False
        For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
            If g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.eMcSG Then
                bDevExist = True
                Exit For
            End If
        Next

        If bDevExist = False Then
            MsgBox("Unavailable feature.")
            Exit Sub
        End If

        Dim dlg As New frmSGTestUI(Me, g_ConfigInfos)

        If dlg.ShowDialog = DialogResult.OK Then

        End If
    End Sub

    Private Sub PGTestUIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PGTestUIToolStripMenuItem.Click

        Dim bExistPGDev As Boolean = False

        For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
            If g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.ePG Then
                If g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._G4S Or _
                    g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._McPG Then
                    bExistPGDev = True
                End If
            End If
        Next

        If bExistPGDev = False Then
            MsgBox("The function can not use")
            Exit Sub
        End If

        Select Case g_ConfigInfos.PGConfig.nDeviceType

            Case CDevPGCommonNode.eDevModel._McPG
                Dim dlg As New frmMcPGTestUI(Me, g_ConfigInfos)
                If dlg.ShowDialog = DialogResult.OK Then

                End If
            Case CDevPGCommonNode.eDevModel._G4S
                Dim dlg As New frmG4sTestUI(cPG, g_ConfigInfos.PGConfig.G4sConfig, Me, False)
                dlg.ShowDialog()

        End Select

    End Sub

    Private Sub ProcessThreadRUNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessThreadRUNToolStripMenuItem.Click
        '스레드(시작)
        cTimeScheduler.StartTrdTimer()
        cQueueProcessor.StartTrdProcess()
    End Sub

    Private Sub ProcessThreadStopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessThreadStopToolStripMenuItem.Click
        '스레드(시작)
        cTimeScheduler.StopTrdTimer()
        cState.StopTrdTimer()
        cQueueProcessor.StopTrdProcess()
    End Sub

    Private Sub UITestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UITestToolStripMenuItem.Click
        Dim dlg As frmUITest = New frmUITest

        If dlg.ShowDialog(Me) = DialogResult.OK Then

        End If

    End Sub


    Private Sub PR705ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PR705ToolStripMenuItem.Click
        Dim dlg As New frmPR705Control(Me)
        If dlg.ShowDialog = DialogResult.OK Then

        End If
    End Sub


    Private Sub ColorAnalyzerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorAnalyzerToolStripMenuItem.Click
        Dim dlg As New frmColorAnalyzerControl(cColorAnalyzer, g_ConfigInfos.ColorAnalyzerConfig)

        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub


    Private Sub Channel_GropCheckClear(ByVal nCh As Integer, ByVal GroupUnit As Integer, ByVal Chektype As Boolean)
        Dim nMod As Integer = (nCh + 1) Mod GroupUnit

        If nMod = 0 Then
            For i As Integer = 0 To GroupUnit - 1
                Chennel_Check((nCh + 1) - (GroupUnit) + i, Chektype)
            Next

        Else
            If nCh < GroupUnit Then
                For i As Integer = 0 To GroupUnit - 1
                    Chennel_Check(i, Chektype)
                Next
            Else
                For i As Integer = 0 To GroupUnit - 1
                    Chennel_Check((nCh + 1) - nMod + i, Chektype)
                Next
            End If

        End If

    End Sub

    Private Sub Chennel_Check(ByVal nch As Integer, ByVal CheckType As Boolean)
        frmControlUI.ControlUI.control.IsSelected(nch) = CheckType

    End Sub

#Region "E-Stop Thread"

    Public trdE_Stop As Thread
    Public btrdE_Stop As Boolean
    Public bE_Stop As Boolean


    Public Sub trdE_StopStart()
        trdE_Stop = New Thread(AddressOf trdE_StopLoop)
        trdE_Stop.Start()
        btrdE_Stop = False
    End Sub

    Public Sub trdE_StopExit()
        btrdE_Stop = True
    End Sub

    Private Sub trdE_StopLoop()

        Dim ret As Byte
        bE_Stop = False

        Do
            Application.DoEvents()

            If btrdE_Stop = True Then
                Exit Do
            End If

            ret = CFS20get_alarm_switch(0)

            If ret = 0 Then  'E Stop Switch On
                If g_EmergencyCtrl.EM_State <> CV7000Emergency.eEMSTATe.eEMERGENCY Then
                    bE_Stop = True
                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_State, CStateMsg.eStateMsg.eSYSTEM_STATUS_EMERGENCY_STOP)
                    MainToolStrip.Enabled = False
                    g_EmergencyCtrl.EmergencyStop()

                End If
            Else   'E Stop Switch OFF
                If g_EmergencyCtrl.EM_State <> CV7000Emergency.eEMSTATe.eIDEL Then
                    bE_Stop = False
                    MainToolStrip.Enabled = True
                    g_EmergencyCtrl.RequestReset()

                End If
            End If

            Thread.Sleep(100)

        Loop
    End Sub
#End Region

#Region "PLC"
    'Public Event evChangeMagazineSupplySlot(ByVal state() As CDevPLCCommonNode.eMagazineSlotSignal)
    'Public Event evChangeMagazineSupplyPosition(ByVal state() As CDevPLCCommonNode.eMagazinePositionSignal)
    'Public Event evChangeMagazineSupplyStatus(ByVal state() As CDevPLCCommonNode.eMagazineStatus)
    'Public Event evChangeMagazineExhausSlot(ByVal state() As CDevPLCCommonNode.eMagazineSlotSignal)
    'Public Event evChangeMagazineExhausPosition(ByVal state() As CDevPLCCommonNode.eMagazinePositionSignal)
    'Public Event evChangeMagazineExhausStatus(ByVal state() As CDevPLCCommonNode.eMagazineStatus)
    'Public Event evChangeMagazineAlarm(ByVal alarm() As CDevPLCCommonNode.eMagazineError)
    'Public Event evChangeMagazineContactInspection(ByVal state() As CDevPLCCommonNode.eMagazineContactIspection)

    Dim m_bTC_Strange_Alarm As Boolean = False  '온도이상
    Dim m_bTC_EOCR_Alarm As Boolean = False 'EOCR
    Dim m_bTC_SSR_Alarm As Boolean = False ' SSR
    Dim m_bTC_HighTemp_Alarm_Zone1 As Boolean = False '고온 ZONE 1
    Dim m_bTC_HighTemp_Alarm_Zone2 As Boolean = False '고온 ZONE 2
    Dim m_Servo_Alarm As Boolean = False    '각 축 Servo 알람
    'Dim m_bTC_Control_Alarm As Boolean = False
    Dim m_bAlarmMessageShow As Boolean = False
    '  Dim m_bAxis_Alarm As Boolean = False
    ' Dim m_EQP_Alarm As Boolean = False
    Dim m_bEMS_Alarm As Boolean = False
    Dim m_bDoor_Alarm As Boolean = False
    Dim m_bAxis_X_Alarm As Boolean = False
    Dim m_bAxis_Y_Alarm As Boolean = False
    Dim m_bAxis_Z_Alarm As Boolean = False
    Dim m_bAxis_Theta1_Alarm As Boolean = False
    Dim m_bAxis_Theta2_Alarm As Boolean = False
    Dim m_bAxis_Theta3_Alarm As Boolean = False
    Dim m_bAxis_Theta4_Alarm As Boolean = False

    ' Dim m_bAxis_Hitter_Alarm As Boolean = False
    ' Dim m_bAxis_Loader_Alarm As Boolean = False
    ' Dim m_bAxis_UnLoader_Alarm As Boolean = False
    Dim sPLCAlarmStr As String = ""

    Private Sub cPLC_evChangeAxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAllAxisAlarm) Handles cPLC.evChangeAxisAlarm
        'For i As Integer = 0 To alarm.Length - 1
        '    If alarm(i) = CDevPLCCommonNode.eEMSAlarm.eNoError Then
        '        m_bAxisAlarm = False
        '    Else
        '        Select Case alarm(i)
        '            Case CDevPLCCommonNode.eAllAxisAlarm.eX_Axis_Alarm
        '                sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sAxisAlarm(2).ToString & ", "
        '                m_bAxisAlarm = True
        '            Case CDevPLCCommonNode.eAllAxisAlarm.eY1_Axis_Alarm
        '                sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sAxisAlarm(0).ToString & ", "
        '                m_bAxisAlarm = True
        '            Case CDevPLCCommonNode.eAllAxisAlarm.eY2_Axis_Alarm
        '                sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sAxisAlarm(1).ToString & ", "
        '                m_bAxisAlarm = True
        '            Case CDevPLCCommonNode.eAllAxisAlarm.eZ_Axis_Alarm
        '                sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sAxisAlarm(3).ToString & ", "
        '                m_bAxisAlarm = True
        '        End Select
        '    End If
        'Next

        'If m_bAxisAlarm = True Then
        '    ' sPLCAlarmStr &= sPLCAlarmStr
        'End If

        'frmMessageUI.Message = sPLCAlarmStr & vbCrLf

        'If m_bAxisAlarm = True Then
        '    frmMessageUI.ShowFrame()
        '    g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, sPLCAlarmStr)
        'Else
        '    frmMessageUI.HideFrame()
        '    g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_MOTION_Function_Error, "OK...")
        '    sPLCAlarmStr = ""
        'End If
        'AlarmMsg(sPLCAlarmStr)
    End Sub

    Private Sub PLC_ChangeSystemStatus(ByVal state() As CDevPLCCommonNode.eSystemStatus) Handles cPLC.evChangeSystemStatus

        If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

        Dim sTemp As String = ""
        For i As Integer = 0 To state.Length - 1

            Select Case state(i)

                Case CDevPLCCommonNode.eSystemStatus.ePower_Down
                    sTemp = sTemp & "[Down]"

                    '    If MsgBox("Emergency 또는 HW 전원 차단 등에 의하여 HW와 통신 할 수 없어 SW가 종료됩니다.", MsgBoxStyle.OkOnly, g_strMainTitle) = MsgBoxResult.Ok Then
                    '   If MsgBox("Emergency 동작으로 HW와 통신 할 수 없어 SW가 종료됩니다.", MsgBoxStyle.OkOnly, g_strMainTitle) = MsgBoxResult.Ok Then
                    '   If MsgBox("HW와 통신 할 수 없어 SW가 종료됩니다.", MsgBoxStyle.OkOnly, g_strMainTitle) = MsgBoxResult.Ok Then
                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_ALARM_EMERGENCY_CLOSED)

                    'Application.DoEvents()
                    'Thread.Sleep(100)

                    '  ProcessKill()
                    ' End If

                Case CDevPLCCommonNode.eSystemStatus.eIDEL
                    sTemp = sTemp & "[Ready]"

                Case CDevPLCCommonNode.eSystemStatus.eProcessing
                    sTemp = sTemp & "[Process]"

                    'Case CDevPLCCommonNode.eSystemStatus.eMaintenance
                    '    sTemp = sTemp & "[Maintenance]"

                Case CDevPLCCommonNode.eSystemStatus.eAlarm
                    sTemp = sTemp & "[Alarm]"

                    'For idx As Integer = 0 To m6000Controller.Length - 1
                    '    m6000Controller(idx).StopThread()
                    'Next


                    'cMeasurementor.trdMeasStop()

                    'cMeasureLifetime.trdMeasStop()

                    'For idx As Integer = 0 To m6000Controller.Length - 1
                    '    m6000Controller(idx).Disconnection()


                    'If g_ConfigInfos.MC9Config Is Nothing = False Then
                    '    For idx As Integer = 0 To TCController.Length - 1
                    '        TCController(idx).Disconnection()
                    '    Next
                    'End If

                    'g_SystemInfo.isConnected = False


                    'Case CDevPLCCommonNode.eSystemStatus.eReserved01
                    '    sTemp = sTemp & "[Res01]"

                Case CDevPLCCommonNode.eSystemStatus.eAuto_Mode
                    sTemp = sTemp & "[SAFETY MODE = AUTO]"

                    ' ''If g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.ePaused Then  'Pause 모드 이면

                    ' ''    If chkPassWind.ShowDialog = Windows.Forms.DialogResult.OK Then
                    ' ''        tsBtnTestPAUSE_Click(tsBtnTestPAUSE, Nothing)
                    ' ''        chkPassWind.tbPassword.Text = ""

                    ' ''        PLC_SafetyModeToPWInputState(CDevPLCCommonNode.eSystemStatus.eAuto_Mode)

                    ' ''        g_PauseCtrl.HomePauseState = CPauseControl.ePAUSEHomming.eNotUse
                    ' ''        'Teach -> Auto 전화하면 PLC Scan을 해야 함.
                    ' ''        ' cPLCScheduler.RequestTest = True
                    ' ''    Else
                    ' ''        '   MsgBox("패스워드 인증에 실패하였습니다. 안전 모드 스위치를 TEACH 모드로 원복 하십시오.")
                    ' ''        MsgBox("패스워드 인증에 실패하였습니다. 안전 모드 스위치를 TEACH 모드로 원복 하십시오(안전 모드 스위치를 AUTO 모드로 전환 하기 위해서는 샘플을 재 로딩 해야 합니다)")
                    ' ''    End If

                    ' ''End If

                Case CDevPLCCommonNode.eSystemStatus.eTeaching_Mode
                    sTemp = sTemp & "[SAFETY MODE = TEACH]"

                    If g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.eNotUse Then


                        ' If chkPassWind.ShowDialog = Windows.Forms.DialogResult.OK Then
                        tsBtnTestPAUSE_Click(tsBtnTestPAUSE, Nothing)
                        'chkPassWind.tbPassword.Text = ""

                        PLC_SafetyModeToPWInputState(CDevPLCCommonNode.eSystemStatus.eTeaching_Mode)

                        ' Else
                        '     MsgBox("패스워드 인증에 실패하였습니다. 안전 모드 스위치를 AUTO 모드로 원복 하십시오(안전 모드 스위치를 AUTO 모드로 전환 하기 위해서는 샘플을 재 로딩 해야 합니다)")

                        ' End If
                    ElseIf g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.ePaused Then
                        PLC_SafetyModeToPWInputState(CDevPLCCommonNode.eSystemStatus.eTeaching_Mode)
                    End If



                    'Case CDevPLCCommonNode.eSystemStatus.ePause
                    '    sTemp = sTemp & "[Pause]"
            End Select
        Next

        HWStatusMsg(sTemp)

    End Sub

    'SatetyMode에 따라서 패스워드를 입력 할 경우 Door Open 할 수 있게 비트 신호 변경
    Private Sub PLC_SafetyModeToPWInputState(ByVal nSafetyMode As CDevPLCCommonNode.eSystemStatus)
        Dim Reqinfo As CDevPLCCommonNode.sRequestInfo = Nothing
        Dim EQPStatus() As CDevPLCCommonNode.eEQPStatus = Nothing
        Dim nState As CDevPLCCommonNode.eSystemStatus = Nothing

        For i As Integer = 0 To cPLC.Datas.nSystemStatus.Length - 1
            If cPLC.Datas.nSystemStatus(i) = CDevPLCCommonNode.eSystemStatus.eProcessing Or cPLC.Datas.nSystemStatus(i) = CDevPLCCommonNode.eSystemStatus.eIDEL Then
                nState = cPLC.Datas.nSystemStatus(i)
                Exit For
            End If
        Next

        If nSafetyMode = CDevPLCCommonNode.eSystemStatus.eTeaching_Mode Then
            Thread.Sleep(500)
            Application.DoEvents()
            Reqinfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            Reqinfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Mode_Teach ' CDevPLC.eSystemStatus.ePauseAndProcess 'state

            cPLC.Request(Reqinfo)
        End If
    
        If nSafetyMode = CDevPLCCommonNode.eSystemStatus.eAuto_Mode Then
            Thread.Sleep(500)
            Application.DoEvents()
            Reqinfo.nCMD = CDevPLCCommonNode.eRequestCMD.eMotionCtrl
            Reqinfo.nSYSStatus = CDevPLCCommonNode.eSystemStatus.eMotion_JOG_Mode_Auto  ' CDevPLC.eSystemStatus.ePauseAndProcess 'state

            cPLC.Request(Reqinfo)



            'Reqinfo.nEQPStatus = CDevPLCCommonNode.eEQPStatus.eRun
            'cPLC.SetEQPStatus(Reqinfo)
        End If

        ' Dim reqInfo As CDevPLCCommonNode.sRequestInfo


    End Sub

    Private Sub PLC_ChangeAlarm(ByVal alarm() As CDevPLCCommonNode.eDISignal) Handles cPLC.evChangeAlarm
        'Dim sTemp As String = ""
        '   Dim bAlarmMessageShow As Boolean = True
        Dim nCnt As Integer = 0
        For i As Integer = 0 To alarm.Length - 1

            If alarm(i) = CDevPLCCommonNode.eDISignal.eNoError Then
                m_bAlarmMessageShow = False
            Else
                m_bAlarmMessageShow = True
            End If

            Select Case alarm(i)
                Case CDevPLCCommonNode.eDISignal.eNoError
                    ' frmMessageUI.HideFrame()
                    sPLCAlarmStr = sPLCAlarmStr & "[No Error]" ' alarm(i).ToString
                    ' AlarmMsg(alarm(i).ToString)

                Case CDevPLCCommonNode.eDISignal.eEmergency
                    sPLCAlarmStr = sPLCAlarmStr & "[Emergency]"
                    'If MsgBox("Emergency 동작으로 HW와 통신 할 수 없어 SW가 종료됩니다.", MsgBoxStyle.OkOnly, g_strMainTitle) = MsgBoxResult.Ok Then
                    '    '  If MsgBox("Emergency 또는 HW 전원 차단 등 의 영향으로 시스템을 재시작 해야 합니다. SW가 종료됩니다.", MsgBoxStyle.OkOnly, g_strMainTitle) = MsgBoxResult.Ok Then
                    '    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSYSTEM_ALARM_EMERGENCY_CLOSED)

                    '    Application.DoEvents()
                    '    Thread.Sleep(100)



                    '    'ProcessKill()

                    'End If

                    'AlarmMsg(alarm(i).ToString)
                Case CDevPLCCommonNode.eDISignal.eFire
                    sPLCAlarmStr = sPLCAlarmStr & "[Fire]"
                    'AlarmMsg(alarm(i).ToString)

                Case CDevPLCCommonNode.eDISignal.eHeater
                    sPLCAlarmStr = sPLCAlarmStr & "[Heater]"
                    'AlarmMsg(alarm(i).ToString)


                Case CDevPLCCommonNode.eDISignal.eCurrentLimit
                    sPLCAlarmStr = sPLCAlarmStr & "[Current Limit]"
                    ' AlarmMsg(alarm(i).ToString)

                Case CDevPLCCommonNode.eDISignal.eInterlock
                    '  sTemp = sTemp & "[Interlock]"
                    'AlarmMsg(alarm(i).ToString) 

                Case CDevPLCCommonNode.eDISignal.eCylinder
                    sPLCAlarmStr = sPLCAlarmStr & "[Cylinder]"
                    'AlarmMsg(alarm(i).ToString)

                Case CDevPLCCommonNode.eDISignal.eDoorOpen
                    sPLCAlarmStr = sPLCAlarmStr & "[Door Open]"
                    'AlarmMsg(alarm(i).ToString)

                Case CDevPLCCommonNode.eDISignal.eSupply
                    sPLCAlarmStr = sPLCAlarmStr & "[Supply]"
                    'AlarmMsg(alarm(i).ToString)

                Case CDevPLCCommonNode.eDISignal.eInspectionStage
                    sPLCAlarmStr = sPLCAlarmStr & "[InspectionStage]"
                    'AlarmMsg(alarm(i).ToString)

                Case CDevPLCCommonNode.eDISignal.eExhaus
                    sPLCAlarmStr = sPLCAlarmStr & "[Exhaus]"
                    'AlarmMsg(alarm(i).ToString)

            End Select

            nCnt += 1
        Next

        frmMessageUI.Message = sPLCAlarmStr & vbCrLf

        If m_bAlarmMessageShow = False Then
            frmMessageUI.HideFrame()
        Else
            frmMessageUI.ShowFrame()
        End If

        AlarmMsg(sPLCAlarmStr)

    End Sub

#End Region

#Region "State Message Handler Function"

    Private Sub g_StateMsgHandler_ChStatusEventMsg(ByVal targetCh As Integer, ByVal type As CStateMsg.eType, ByVal strMsg As String) Handles g_StateMsgHandler.ChStatusEventMsg

        Dim dispCh As New CChDisp

        dispCh.ChannelNo = targetCh
        dispCh.DispType = g_SystemOptions.sOptionData.DispGroup.ChDispType

        ucDispJIG.convertIncNumberToMatrixValue(targetCh)

        strMsg = "[TEG " & dispCh.DispChannel & "] " & strMsg 'ucDispJIG.convertIncNumberToMatrixValue(dispCh.DispChannel - 1) & "] " & strMsg

        ' strMsg = "[TEG " & Format(dispCh.DispChannel, "00") & "] " & strMsg 'ucDispJIG.convertIncNumberToMatrixValue(dispCh.DispChannel - 1) & "] " & strMsg

        UpdateStateMsg(type, strMsg, targetCh)

    End Sub

    Private Sub g_StateMsgHandler_StatusEvent(ByVal type As CStateMsg.eType, ByVal strMsg As String) Handles g_StateMsgHandler.StatusEventMsg

        UpdateStateMsg(type, strMsg)
    End Sub




    Private Sub SpectroRadiometerErrorEventHandler(ByVal errCode As Integer)
        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "Measure, Error Code " & CStr(errCode))
    End Sub


    Private Sub UpdateStateMsg(ByVal type As CStateMsg.eType, ByVal sMsg As String, Optional ByVal targetCh As Integer = -1)

        Select Case type

            Case CStateMsg.eType.eMSG_Popup    '중요한 메시지로 팝업 창으로 표시  
                If g_SystemInfo.bIsShowMessageAlram = True Then
                    MsgBox(sMsg)
                End If
            Case CStateMsg.eType.eMSG_Log      'Log 파일에 저장
                WriteLogMsg(sMsg)
            Case CStateMsg.eType.eMSG_List

                If targetCh >= 0 Then
                    frmMonitorUI.Message(targetCh) = sMsg
                End If

            Case CStateMsg.eType.eMSG_State   '상태 정보를 나타내는 기능으로 상태표시바로 출력
                StatusMsg(sMsg)
            Case CStateMsg.eType.eMsg_List_Log
                If targetCh >= 0 Then
                    frmMonitorUI.Message(targetCh) = sMsg
                End If
                WriteLogMsg(sMsg)
            Case CStateMsg.eType.eMsg_Popup_Log
                WriteLogMsg(sMsg)
                If g_SystemInfo.bIsShowMessageAlram = True Then
                    MsgBox(sMsg)
                End If
            Case CStateMsg.eType.eMsg_State_Log
                StatusMsg(sMsg)
                WriteLogMsg(sMsg)
            Case CStateMsg.eType.eMSG_State_Log_Popup
                WriteLogMsg(sMsg)
                StatusMsg(sMsg)
                If g_SystemInfo.bIsShowMessageAlram = True Then
                    MsgBox(sMsg)
                End If
            Case CStateMsg.eType.eMsg_State_Log_Alarm_Text
                StatusMsg(sMsg)
                WriteLogMsg(sMsg)
                ' ucAlarmLogMessage.LogMessage = sMsg
        End Select
    End Sub

#End Region

#Region "Other Device Event Handler Functions"

    Private Sub M6000_Alarm(ByVal DevID As Integer, ByVal chOfDev As Integer, ByVal alarmInfo As CSeqRoutineM6000.eAlarm)

        Dim systemChannel As Integer = frmSettingWind.GetChannelNoFromM6000DevNoAndCh(DevID, chOfDev)
        Dim sMsg As String = ""
        Select Case alarmInfo
            Case CSeqRoutineM6000.eAlarm._LimitAlarm_Bias_OverVolt
                sMsg = "SW Limit Over Volt[Bias]"
            Case CSeqRoutineM6000.eAlarm._LimitAlarm_Bias_OverCurrent
                sMsg = "SW Limit Over Curr[Bias]"
            Case CSeqRoutineM6000.eAlarm._LimitAlarm_Amplitude_OverVolt
                sMsg = "SW Limit Over Volt[Amplitude]"
            Case CSeqRoutineM6000.eAlarm._LimitAlarm_Amplitude_OverCurrent
                sMsg = "SW Limit Over Curr[Amplitude]"
        End Select

        frmMonitorUI.Message(systemChannel) = sMsg
        g_StateMsgHandler.messageToUserErrorCode(systemChannel, CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_M6000_Limit_Alarm, sMsg)

        'Me.cTimeScheduler.g_ChSchedulerStatus(systemChannel) = CScheduler.eChSchedulerSTATE.eStop

    End Sub

    Private Sub TemperatureCtrl_ChangedOutputStatus(ByVal NumOfDev As Integer, ByVal settings() As CDevTCCommonNode.sSettings, ByVal bDisplayAlarm As Boolean)
        Dim systemChannel As Integer
        Dim sJIGName As String = Nothing
        Dim sMessage As String = Nothing

        If bDisplayAlarm = False Then
            '   frmMessageUI.HideFrame()
            Exit Sub
        End If

        For nDevID As Integer = 0 To NumOfDev - 1

            systemChannel = frmSettingWind.GetTCNumberToJIGNumber(nDevID)

            If settings(nDevID).Setting(0).nOutputState Is Nothing = False Then
                For nStateNum As Integer = 0 To settings(nDevID).Setting(0).nOutputState.Length - 1

                    Select Case settings(nDevID).Setting(0).nOutputState(nStateNum)
                        Case CDevTCCommonNode.eOutputStatus._Nothing

                        Case CDevTCCommonNode.eOutputStatus._OUT1

                        Case CDevTCCommonNode.eOutputStatus._OUT2

                        Case CDevTCCommonNode.eOutputStatus._Limit_Alarm_EV1
                            frmMonitorUI.Message(systemChannel) = "Temp. Limit"

                            If Me.cTimeScheduler.g_ChSchedulerStatus(systemChannel) <> CScheduler.eChSchedulerSTATE.eIdle Then
                                SequenceList(systemChannel).RequestTest = False
                                Me.cTimeScheduler.g_ChSchedulerStatus(systemChannel) = CScheduler.eChSchedulerSTATE.eStop
                            End If

                            If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                                sJIGName = sJIGName & "TEG" & Format(systemChannel + 1, "00") & ","
                            ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                                sJIGName = sJIGName & "TEG" & ucDispJIG.convertIncNumberToMatrixValue(systemChannel) & ","
                            End If

                            '  sJIGName = sJIGName & "TEG" & ucDispJIG.convertIncNumberToMatrixValue(systemChannel) & "," 'Format(systemChannel + 1, "00") & "," 
                            sMessage = sJIGName.TrimEnd(",") & vbCrLf & "채널의 온도 제어에 문제가 발생하여, 실험중인 채널은 자동 종료 됩니다."
                            frmMessageUI.Message = sMessage

                        Case CDevTCCommonNode.eOutputStatus._Limit_Alarm_EV2

                        Case CDevTCCommonNode.eOutputStatus._Undefiend
                    End Select
                Next
            End If

        Next

        If sJIGName = Nothing Or sJIGName = "" Then
            Exit Sub
        End If

        '  frmMessageUI.ShowFrame()


        'Dim systemChannel As Integer = frmSettingWind.GetTCNumberToJIGNumber(DevID)
        'Dim sJIGName As String

        ''실험 중지 및 알람 

        'If systemChannel < 0 Then Exit Sub

        'sJIGName = sJIGName & "TEG" & ucDispJIG.convertIncNumberToMatrixValue(systemChannel)

        'For i As Integer = 0 To status.Length - 1

        '    Select Case status(i)

        '        Case CDevTCCommonNode.eOutputStatus._Nothing

        '        Case CDevTCCommonNode.eOutputStatus._OUT1

        '        Case CDevTCCommonNode.eOutputStatus._OUT2

        '        Case CDevTCCommonNode.eOutputStatus._Limit_Alarm_EV1
        '            frmMonitorUI.Message(systemChannel) = "Temp. Limit"

        '            If Me.cTimeScheduler.g_ChSchedulerStatus(systemChannel) = CScheduler.eChSchedulerSTATE.eIdle Then
        '                MsgBox(sJIGName & "채널의 온도 제어에 문제가 발생하여, 실험중인 채널은 자동 종료 됩니다.", MsgBoxStyle.Critical, g_strMainTitle)
        '                Exit Sub
        '            End If

        '            Me.cTimeScheduler.g_ChSchedulerStatus(systemChannel) = CScheduler.eChSchedulerSTATE.eStop
        '            MsgBox(sJIGName & "채널의 온도 제어에 문제가 발생하여, 실험중인 채널은 자동 종료 됩니다.", MsgBoxStyle.Critical, g_strMainTitle)


        '        Case CDevTCCommonNode.eOutputStatus._Limit_Alarm_EV2

        '        Case CDevTCCommonNode.eOutputStatus._Undefiend

        '    End Select
        'Next

    End Sub

#End Region

    Private Sub K7001ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles K7001ToolStripMenuItem.Click
        Dim dlg As New frmK7001Control(Me)
        If dlg.ShowDialog = DialogResult.OK Then

        End If
    End Sub

    Private Sub SW7000ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SW7000ToolStripMenuItem.Click
        Dim dlg As New frmSW7000Control(Me, g_ConfigInfos)
        If dlg.ShowDialog = DialogResult.OK Then

        End If
    End Sub

    Private Sub StrobeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StrobeToolStripMenuItem.Click
        Dim dlg As New frmStrobeControl(Me, g_ConfigInfos)
        If dlg.ShowDialog = DialogResult.OK Then

        End If
    End Sub

    Private Sub SVSCameraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SVSCameraToolStripMenuItem.Click
        Dim dlg As New frmSVSCamera

        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub tsbControlViewMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbControlViewMode.Click
        frmMonitorUI.HideFrame()
        frmMotionUI.HideFrame()
        'frmPretestUI.HideFrame()
        frmControlUI.ShowFrame()
    End Sub

    Private Sub tsbIVLGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbIVLGraph.Click
        SequenceBuidlerOpen()
        'If g_SystemOptions.sOptionData.bEnableDataViewerLink_IVL = False Then
        '    Exit Sub
        'Else
        '    If File.Exists(g_SystemOptions.sOptionData.sPathOfDataViewer_IVL) = False Then
        '        Exit Sub
        '    End If
        'End If

        'Process.Start(g_SystemOptions.sOptionData.sPathOfDataViewer_IVL)
    End Sub
    Private Sub SequenceBuidlerOpen()
        Dim dlg As New frmSequenceBuilder

        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            'dlg.UcSequenceBuilder1.ucDispLifetime.ucDispModule.ucPGImageSweep.FlushImageMemory()
        End If

        dlg.Dispose()
    End Sub
    Private Sub tsbLTGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSequenceBulider.Click
        SequenceBuidlerOpen()
        'If g_SystemOptions.sOptionData.bEnableDataViewerLink_LT = False Then
        '    Exit Sub
        'Else
        '    If File.Exists(g_SystemOptions.sOptionData.sPathOfDataViewer_LT) = False Then
        '        Exit Sub
        '    End If
        'End If

        'Process.Start(g_SystemOptions.sOptionData.sPathOfDataViewer_LT)
    End Sub



    Private Sub PGImageManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PGImageManagerToolStripMenuItem.Click
        'For i As Integer = 0 To cMCPG.Length - 1
        '    If cMCPG(0).IsConnected = True Then
        '        MsgBox("Need to system disconnection")
        '        Exit Sub
        '    End If
        'Next

        '   g_StateMsgHandler.messageToString(CStateMsg.eStateType.eMSGOutput_And_Popup) = CStateMsg.eStateMsg.eSYSTEM_MSG_Need_Connection

        Dim dlg As New frmImageManager

        If dlg.ShowDialog = DialogResult.OK Then
            dlg.Close()
        End If
    End Sub

    Private Sub ZeroCalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZeroCalToolStripMenuItem.Click

        ZeroCalToolStripMenuItem.Enabled = False
        g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_COLORANALYZER_ZEROCAL)

        If MsgBox("Perform a 0-Cal operation. Adjust the measurement probe to 0-Cal state. When the 0-Cal operation is completed, the probe should be changed to the Meas state.", MsgBoxStyle.OkCancel, g_strMainTitle) = MsgBoxResult.Ok Then
            cColorAnalyzer(0).myColorAnalyzer.ZeroCalibration()
        Else
            MsgBox("0-Cal job canceled.")
        End If

        Application.DoEvents()
        Thread.Sleep(5000)

        Dim settings As CColorAnalyzerLib.CDevColorAnalyzerCommonNode.sSetInfos = Nothing

        If cColorAnalyzer(0).myColorAnalyzer.GetSettings(settings) = True Then

            settings.sCAxxxSettings.syncMode = 0   '0 : NTFS  '1 : PAL
            settings.sCAxxxSettings.dispMode = CDevCAxxxCMD.eDispMode.Lvxy

            If cColorAnalyzer(0).myColorAnalyzer.SetSettings(settings) = False Then
                MsgBox("Error")
            End If

        End If

        g_StateMsgHandler.messageToString(CStateMsg.eType.eMsg_State_Log, CStateMsg.eStateMsg.eDEV_COLORANALYZER_COMPLETE_ZEROCAL)
        ZeroCalToolStripMenuItem.Enabled = True
    End Sub


    Private Sub cPG_evChangedConnectedClients(ByVal list() As String) Handles cPG.evChangedConnectedClients

        ' Dim aaaa As Integer
        'aaaa = 10

        UpdateChannelUI()

    End Sub



    Private Sub TestToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Sequence As CSequenceManager.sSequenceInfo = Nothing
        Dim rcpInfo As ucSequenceBuilder.sRecipeInfo = Nothing
        Dim sData As frmMain.sCellIVLMeasureParams = Nothing
        Dim SpectrumBiasList()() As Double = Nothing

        Dim CVT As cDataOutput = New cDataOutput(Sequence, g_SystemOptions.sOptionData.SaveOptions.nFileType, 0)


        'CVT.SaveDataIVLExcel(rcpInfo, sData, SpectrumBiasList)



    End Sub

    'Private Sub cPLC_evChangeSystemAlarm(ByVal state() As CDevPLCCommonNode.eDIFanSignal) Handles cPLC.evChangeSystemAlarm
    '    If g_SystemInfo.isConnected = False Then Exit Sub '연결되지 않았을떄의 이벤트 무시함

    '    Dim sErrormsg As String = Nothing

    '    'State Reset
    '    For idx As Integer = 0 To frmPLCAlarm.ucMonitoring(0).ucCH.Length - 1
    '        frmPLCAlarm.ucMonitoring(0).ucCH(idx).ledStatus.LedColor = Color.DarkGray
    '        frmPLCAlarm.ucMonitoring(0).ucCH(idx).lblName.BackColor = Color.Gray
    '    Next

    '    If state(0) = CDevPLCCommonNode.eDIFanSignal.eNoError Then
    '        m_b_Alarm = False
    '    Else
    '        For i As Integer = 0 To state.Length - 1
    '            If state(i) <> CDevPLCCommonNode.eDIFanSignal.eNoError Then
    '                frmPLCAlarm.ucMonitoring(0).ucCH(i).ledStatus.LedColor = Color.Red
    '                frmPLCAlarm.ucMonitoring(0).ucCH(i).lblName.BackColor = Color.Red
    '                sErrormsg &= state(i).ToString & ",     "
    '                m_b_Alarm = True
    '            End If
    '        Next
    '    End If

    '    'For jdx As Integer = 0 To frmPLCAlarm.ucMonitoring(0).ucCH.Length - 1
    '    '    frmPLCAlarm.ucMonitoring(0).ucCH(jdx).ledStatus.LedColor = Color.Red
    '    '    frmPLCAlarm.ucMonitoring(0).ucCH(jdx).lblName.BackColor = Color.Red
    '    '    m_b_Alarm = True
    '    'Next

    '    If m_b_Alarm = False Then
    '        frmMessageUI.HideFrame()
    '    Else
    '        frmMessageUI.ShowFrame()
    '    End If

    '    AlarmMsg(sErrormsg)
    'End Sub

    Private Sub RangeSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RangeSettingsToolStripMenuItem.Click
        If g_SystemInfo.isConnected = True Then
            Dim dlg As New frmChannelRangeSetttings(Me)

            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                g_ChRangeInfo = dlg.RangeSet.Clone
            End If
        Else
            MsgBox("Please Use After Connection")
        End If

    End Sub

    Private Sub cPLC_evChangeEQPState(ByVal alarm() As CDevPLCCommonNode.eEQPStatus) Handles cPLC.evChangeEQPState
        If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

        Dim sTemp As String = ""
        For i As Integer = 0 To alarm.Length - 1

            Select Case alarm(i)

                Case CDevPLCCommonNode.eEQPStatus.eRun
                    If g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.ePaused Then
                        If frmMotionUI.ACFMeas = True Then
                            'ACF 중이면 상태 변경 안함
                            Exit Sub
                        End If
                        ResetPause()
                        g_PauseCtrl.ResetEQPState()
                    End If
                Case CDevPLCCommonNode.eEQPStatus.eStop
                    ' g_PauseCtrl.request()
                    '  g_PauseCtrl.EQPRequest()
                    '  SetPause()
                Case CDevPLCCommonNode.eEQPStatus.ePause
                    Dim Reqinfo As CDevPLCCommonNode.sRequestInfo = Nothing
                    Dim EQPStatus() As CDevPLCCommonNode.eEQPStatus = Nothing
                    'g_PauseCtrl.request()
                    'g_PauseCtrl.EQPRequest()
                    'SetPause()
                    Reqinfo.nEQPStatus = CDevPLCCommonNode.eEQPStatus.eStop
                    cPLC.SetEQPStatus(Reqinfo)
            End Select
        Next

    End Sub

    Private Sub cPLC_evChangeEMSAlarm(ByVal alarm() As CDevPLCCommonNode.eEMSAlarm) Handles cPLC.evChangeEMSAlarm
        If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

        Dim sTemp As String = ""
        '   Dim bAlarm As Boolean = True
        For i As Integer = 0 To alarm.Length - 1
            If alarm(i) = CDevPLCCommonNode.eEMSAlarm.eNoError Then
                m_bEMS_Alarm = False
            Else
                Select Case alarm(i)
                    Case CDevPLCCommonNode.eEMSAlarm.eEMS1
                        sTemp = sTemp & CDevPLCCommonNode.sEMSAlarm(0).ToString & ", "
                        m_bEMS_Alarm = True
                    Case CDevPLCCommonNode.eEMSAlarm.eEMS2
                        sTemp = sTemp & CDevPLCCommonNode.sEMSAlarm(1).ToString & ", "
                        m_bEMS_Alarm = True
                    Case CDevPLCCommonNode.eEMSAlarm.eSafety_Control_Alarm1
                        sTemp = sTemp & CDevPLCCommonNode.sEMSAlarm(4).ToString & ", "
                        m_bEMS_Alarm = True
                    Case CDevPLCCommonNode.eEMSAlarm.eSafety_Control_Alarm2
                        sTemp = sTemp & CDevPLCCommonNode.sEMSAlarm(5).ToString & ", "
                        m_bEMS_Alarm = True
                    Case CDevPLCCommonNode.eEMSAlarm.eMC1_POWEROFF_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.sEMSAlarm(8).ToString & ", "
                        m_bEMS_Alarm = True
                    Case CDevPLCCommonNode.eEMSAlarm.eMC2_POWEROFF_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.sEMSAlarm(9).ToString & ", "
                        m_bEMS_Alarm = True
                    Case CDevPLCCommonNode.eEMSAlarm.eControlBoxTempLightAlarm
                        sTemp = sTemp & CDevPLCCommonNode.sEMSAlarm(10).ToString & ", "
                        m_bEMS_Alarm = True
                    Case CDevPLCCommonNode.eEMSAlarm.eControlBoxTempHeavyAlarm
                        sTemp = sTemp & CDevPLCCommonNode.sEMSAlarm(11).ToString & ", "
                        m_bEMS_Alarm = True
                    Case CDevPLCCommonNode.eEMSAlarm.eControlBoxSmokeAlarm
                        sTemp = sTemp & CDevPLCCommonNode.sEMSAlarm(12).ToString & ", "
                        m_bEMS_Alarm = True
                End Select

            End If
        Next

        If m_bEMS_Alarm = True Then
            sPLCAlarmStr &= sTemp
        End If

        frmMessageUI.Message = sPLCAlarmStr & vbCrLf

        If m_bAlarmMessageShow = False And m_bEMS_Alarm = False Then 'And m_bAxis_X_Alarm = False And m_bAxis_Y_Alarm = False And m_bAxis_Z_Alarm = False Then
            frmMessageUI.HideFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_EMS_AND_CONTROLBOX, "OK...")
            sPLCAlarmStr = ""
        Else
            frmMessageUI.ShowFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_EMS_AND_CONTROLBOX, sPLCAlarmStr)
        End If

        AlarmMsg(sPLCAlarmStr)
    End Sub

    'Private Sub cPLC_evChangeEOCRAlarm(ByVal alarm() As CDevPLCCommonNode.eTemperatureAlarm) Handles cPLC.evChangeEOCRAlarm
    '    If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

    '    ' Dim sTemp As String = ""
    '    '   Dim bAlarm As Boolean = True
    '    For i As Integer = 0 To alarm.Length - 1
    '        If alarm(i) = CDevPLCCommonNode.eTemperatureAlarm.eNoError Then
    '            m_bTC_EOCR_Alarm = False
    '        Else
    '            Select Case alarm(i)
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT1
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(0).ToString & ", "
    '                    m_bTC_EOCR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(1).ToString & ", "
    '                    m_bTC_EOCR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(2).ToString & ", "
    '                    m_bTC_EOCR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(3).ToString & ", "
    '                    m_bTC_EOCR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(4).ToString & ", "
    '                    m_bTC_EOCR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT6
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(5).ToString & ", "
    '                    m_bTC_EOCR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT7
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(6).ToString & ", "
    '                    m_bTC_EOCR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT8
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(7).ToString & ", "
    '                    m_bTC_EOCR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT9
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(8).ToString & ", "
    '                    m_bTC_EOCR_Alarm = True
    '            End Select

    '        End If
    '    Next
    '    If m_bTC_EOCR_Alarm = True Then
    '        sPLCAlarmStr = "EOCR 상태 이상 = " & sPLCAlarmStr
    '    End If

    '    frmMessageUI.Message = sPLCAlarmStr & vbCrLf

    '    If m_bTC_Strange_Alarm = False And m_bTC_EOCR_Alarm = False And m_bTC_SSR_Alarm = False And m_bTC_HighTemp_Alarm_Zone1 = False And m_bTC_HighTemp_Alarm_Zone2 = False And m_bAlarmMessageShow = False And m_bEMS_Alarm = False And m_bAxis_X_Alarm = False And m_bAxis_Y_Alarm = False And m_bAxis_Z_Alarm = False Then
    '        frmMessageUI.HideFrame()
    '        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_TEMP_EOCR, "OK...")
    '        sPLCAlarmStr = ""
    '    Else
    '        frmMessageUI.ShowFrame()
    '        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_TEMP_EOCR, sPLCAlarmStr)
    '    End If

    '    AlarmMsg(sPLCAlarmStr)
    'End Sub

    'Private Sub cPLC_evChangeOverTempZone1Alarm(ByVal alarm() As CDevPLCCommonNode.eTemperatureAlarm) Handles cPLC.evChangeOverTempZone1Alarm
    '    If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

    '    'Dim sTemp As String = ""
    '    '   Dim bAlarm As Boolean = True
    '    For i As Integer = 0 To alarm.Length - 1
    '        If alarm(i) = CDevPLCCommonNode.eTemperatureAlarm.eNoError Then
    '            m_bTC_HighTemp_Alarm_Zone1 = False
    '        Else
    '            Select Case alarm(i)
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT1
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone1(0).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone1 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone1(1).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone1 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone1(2).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone1 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone1(3).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone1 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone1(4).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone1 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT6
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone1(5).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone1 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT7
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone1(6).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone1 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT8
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone1(7).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone1 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT9
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone1(8).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone1 = True
    '            End Select

    '        End If
    '    Next

    '    If m_bTC_HighTemp_Alarm_Zone1 = True Then
    '        sPLCAlarmStr = "과온 알람 Zone1 = " & sPLCAlarmStr
    '    End If

    '    frmMessageUI.Message = sPLCAlarmStr & vbCrLf

    '    If m_bTC_Strange_Alarm = False And m_bTC_EOCR_Alarm = False And m_bTC_SSR_Alarm = False And m_bTC_HighTemp_Alarm_Zone1 = False And m_bTC_HighTemp_Alarm_Zone2 = False And m_bAlarmMessageShow = False And m_bEMS_Alarm = False And m_bAxis_X_Alarm = False And m_bAxis_Y_Alarm = False And m_bAxis_Z_Alarm = False Then
    '        frmMessageUI.HideFrame()
    '        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_TEMP_OVER, "OK...")
    '        sPLCAlarmStr = ""
    '    Else
    '        frmMessageUI.ShowFrame()
    '        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_TEMP_OVER, sPLCAlarmStr)
    '    End If
    '    AlarmMsg(sPLCAlarmStr)
    'End Sub

    'Private Sub cPLC_evChangeOverTempZone2Alarm(ByVal alarm() As CDevPLCCommonNode.eTemperatureAlarm) Handles cPLC.evChangeOverTempZone2Alarm
    '    If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

    '    'Dim sTemp As String = ""
    '    '   Dim bAlarm As Boolean = True
    '    For i As Integer = 0 To alarm.Length - 1
    '        If alarm(i) = CDevPLCCommonNode.eTemperatureAlarm.eNoError Then
    '            m_bTC_HighTemp_Alarm_Zone2 = False
    '        Else
    '            Select Case alarm(i)
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT1
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone2(0).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone2 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone2(1).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone2 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone2(2).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone2 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone2(3).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone2 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone2(4).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone2 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT6
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone2(5).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone2 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT7
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone2(6).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone2 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT8
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone2(7).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone2 = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT9
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarmZone2(8).ToString & ", "
    '                    m_bTC_HighTemp_Alarm_Zone2 = True
    '            End Select

    '        End If
    '    Next
    '    If m_bTC_HighTemp_Alarm_Zone2 = True Then
    '        sPLCAlarmStr = "과온 알람 Zone2 = " & sPLCAlarmStr
    '    End If

    '    frmMessageUI.Message = sPLCAlarmStr & vbCrLf

    '    If m_bTC_Strange_Alarm = False And m_bTC_EOCR_Alarm = False And m_bTC_SSR_Alarm = False And m_bTC_HighTemp_Alarm_Zone1 = False And m_bTC_HighTemp_Alarm_Zone2 = False And m_bAlarmMessageShow = False And m_bEMS_Alarm = False And m_bAxis_X_Alarm = False And m_bAxis_Y_Alarm = False And m_bAxis_Z_Alarm = False Then
    '        frmMessageUI.HideFrame()
    '        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_TEMP_OVER, "OK...")
    '        sPLCAlarmStr = ""
    '    Else
    '        frmMessageUI.ShowFrame()
    '        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_TEMP_OVER, sPLCAlarmStr)
    '    End If
    '    AlarmMsg(sPLCAlarmStr)
    'End Sub

    'Private Sub cPLC_evChangeSSRAlarm(ByVal alarm() As CDevPLCCommonNode.eTemperatureAlarm) Handles cPLC.evChangeSSRAlarm
    '    If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

    '    '       Dim sTemp As String = ""
    '    '   Dim bAlarm As Boolean = True
    '    For i As Integer = 0 To alarm.Length - 1
    '        If alarm(i) = CDevPLCCommonNode.eTemperatureAlarm.eNoError Then
    '            m_bTC_SSR_Alarm = False
    '        Else
    '            Select Case alarm(i)
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT1
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(0).ToString & ", "
    '                    m_bTC_SSR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(1).ToString & ", "
    '                    m_bTC_SSR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(2).ToString & ", "
    '                    m_bTC_SSR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(3).ToString & ", "
    '                    m_bTC_SSR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(4).ToString & ", "
    '                    m_bTC_SSR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT6
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(5).ToString & ", "
    '                    m_bTC_SSR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT7
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(6).ToString & ", "
    '                    m_bTC_SSR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT8
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(7).ToString & ", "
    '                    m_bTC_SSR_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT9
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(8).ToString & ", "
    '                    m_bTC_SSR_Alarm = True
    '            End Select

    '        End If
    '    Next
    '    If m_bTC_SSR_Alarm = True Then
    '        sPLCAlarmStr = "SSR 80도 알람 = " & sPLCAlarmStr
    '    End If

    '    frmMessageUI.Message = sPLCAlarmStr & vbCrLf

    '    If m_bTC_Strange_Alarm = False And m_bTC_EOCR_Alarm = False And m_bTC_SSR_Alarm = False And m_bTC_HighTemp_Alarm_Zone1 = False And m_bTC_HighTemp_Alarm_Zone2 = False And m_bAlarmMessageShow = False And m_bEMS_Alarm = False And m_bAxis_X_Alarm = False And m_bAxis_Y_Alarm = False And m_bAxis_Z_Alarm = False Then
    '        frmMessageUI.HideFrame()
    '        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_TEMP_SSR, "OK...")
    '        sPLCAlarmStr = ""
    '    Else
    '        frmMessageUI.ShowFrame()
    '        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_TEMP_SSR, sPLCAlarmStr)
    '    End If
    '    AlarmMsg(sPLCAlarmStr)
    'End Sub

    'Private Sub cPLC_evChangeStrangeTempAlarm(alarm() As CDevPLCCommonNode.eTemperatureAlarm) Handles cPLC.evChangeStrangeTempAlarm
    '    If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

    '    '   Dim sTemp As String = ""
    '    '   Dim bAlarm As Boolean = True
    '    For i As Integer = 0 To alarm.Length - 1
    '        If alarm(i) = CDevPLCCommonNode.eTemperatureAlarm.eNoError Then
    '            m_bTC_Strange_Alarm = False
    '        Else
    '            Select Case alarm(i)
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT1
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(0).ToString & ", "
    '                    m_bTC_Strange_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(1).ToString & ", "
    '                    m_bTC_Strange_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(2).ToString & ", "
    '                    m_bTC_Strange_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(3).ToString & ", "
    '                    m_bTC_Strange_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(4).ToString & ", "
    '                    m_bTC_Strange_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT6
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(5).ToString & ", "
    '                    m_bTC_Strange_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT7
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(6).ToString & ", "
    '                    m_bTC_Strange_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT8
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(7).ToString & ", "
    '                    m_bTC_Strange_Alarm = True
    '                Case CDevPLCCommonNode.eTemperatureAlarm.eT9
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.sTempAlarm(8).ToString & ", "
    '                    m_bTC_Strange_Alarm = True
    '            End Select
    '        End If
    '    Next
    '    If m_bTC_Strange_Alarm = True Then
    '        sPLCAlarmStr = "온도 이상" & sPLCAlarmStr
    '    End If

    '    frmMessageUI.Message = sPLCAlarmStr & vbCrLf

    '    If m_bTC_Strange_Alarm = False And m_bTC_EOCR_Alarm = False And m_bTC_SSR_Alarm = False And m_bTC_HighTemp_Alarm_Zone1 = False And m_bTC_HighTemp_Alarm_Zone2 = False And m_bAlarmMessageShow = False And m_bEMS_Alarm = False And m_bAxis_X_Alarm = False And m_bAxis_Y_Alarm = False And m_bAxis_Z_Alarm = False Then
    '        frmMessageUI.HideFrame()
    '        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_TEMP_STRANGE, "OK...")
    '        sPLCAlarmStr = ""
    '    Else
    '        frmMessageUI.ShowFrame()
    '        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_TEMP_STRANGE, sPLCAlarmStr)
    '    End If

    '    AlarmMsg(sPLCAlarmStr)
    'End Sub

    'Private Sub cPLC_evChangeXAxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAxisAlarm) Handles cPLC.evChangeXAxisAlarm
    '    If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

    '    '   Dim sTemp As String = ""
    '    '   Dim bAlarm As Boolean = True
    '    For i As Integer = 0 To alarm.Length - 1
    '        If alarm(i) = CDevPLCCommonNode.eAxisAlarm.eNoError Then
    '            m_bAxis_X_Alarm = False
    '        Else
    '            Select Case alarm(i)
    '                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Alarm
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.AxisAlarm(0) & ", "
    '                    m_bAxis_X_Alarm = True
    '                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Servo_Alarm
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.AxisAlarm(1) & ", "
    '                    m_bAxis_X_Alarm = True
    '                Case CDevPLCCommonNode.eAxisAlarm.eAxis_RLS_Limit_Alarm
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.AxisAlarm(2) & ", "
    '                    m_bAxis_X_Alarm = True
    '                Case CDevPLCCommonNode.eAxisAlarm.eAxis_FLS_Limit_Alarm
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.AxisAlarm(3) & ", "
    '                    m_bAxis_X_Alarm = True
    '                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Crush_Alarm
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.AxisAlarm(4) & ", "
    '                    m_bAxis_X_Alarm = True
    '                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Homming_Timeout
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.AxisAlarm(5) & ", "
    '                    m_bAxis_X_Alarm = True
    '                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Moving_Timeout
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.AxisAlarm(6) & ", "
    '                    m_bAxis_X_Alarm = True
    '                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.AxisAlarm(7) & ", "
    '                    m_bAxis_X_Alarm = True
    '                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
    '                    sPLCAlarmStr = sPLCAlarmStr & CDevPLCCommonNode.AxisAlarm(8) & ", "
    '                    m_bAxis_X_Alarm = True
    '            End Select
    '        End If
    '    Next

    '    If m_bAxis_X_Alarm = True Then
    '        sPLCAlarmStr = "IVL-X Axis Alarm  = " & sPLCAlarmStr
    '    End If

    '    frmMessageUI.Message = sPLCAlarmStr & vbCrLf

    '    If m_bTC_Strange_Alarm = False And m_bTC_EOCR_Alarm = False And m_bTC_SSR_Alarm = False And m_bTC_HighTemp_Alarm_Zone1 = False And m_bTC_HighTemp_Alarm_Zone2 = False And m_bAlarmMessageShow = False And m_bEMS_Alarm = False And m_bAxis_X_Alarm = False And m_bAxis_Y_Alarm = False And m_bAxis_Z_Alarm = False Then
    '        frmMessageUI.HideFrame()
    '        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_AXIS, "OK...")
    '        sPLCAlarmStr = ""
    '    Else
    '        frmMessageUI.ShowFrame()
    '        g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_AXIS, sPLCAlarmStr)
    '    End If
    '    AlarmMsg(sPLCAlarmStr)
    'End Sub

    Private Sub cPLC_evChangeYAxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAxisAlarm) Handles cPLC.evChangeYAxisAlarm
        If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

        Dim sTemp As String = ""
        '   Dim bAlarm As Boolean = True
        For i As Integer = 0 To alarm.Length - 1
            If alarm(i) = CDevPLCCommonNode.eAxisAlarm.eNoError Then
                m_bAxis_Y_Alarm = False
            Else
                Select Case alarm(i)
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(0) & ", "
                        m_bAxis_Y_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Servo_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(1) & ", "
                        m_bAxis_Y_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_RLS_Limit_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(2) & ", "
                        m_bAxis_Y_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_FLS_Limit_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(3) & ", "
                        m_bAxis_Y_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Crush_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(4) & ", "
                        m_bAxis_Y_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Homming_Timeout
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(5) & ", "
                        m_bAxis_Y_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Moving_Timeout
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(6) & ", "
                        m_bAxis_Y_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(7) & ", "
                        m_bAxis_Y_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(8) & ", "
                        m_bAxis_Y_Alarm = True
                End Select
            End If
        Next
        If m_bAxis_Y_Alarm = True Then
            sPLCAlarmStr += "IVL-Y Axis Alarm = " & sTemp
        End If

        frmMessageUI.Message = sPLCAlarmStr & vbCrLf

        If m_bAlarmMessageShow = False And m_bEMS_Alarm = False And m_bAxis_X_Alarm = False And m_bAxis_Y_Alarm = False And m_bAxis_Z_Alarm = False Then
            frmMessageUI.HideFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_AXIS, "OK...")
            sPLCAlarmStr = ""
        Else
            frmMessageUI.ShowFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_AXIS, sPLCAlarmStr)
        End If
        AlarmMsg(sPLCAlarmStr)
    End Sub

    Private Sub cPLC_evChangeZAxisAlarm(ByVal alarm() As CDevPLCCommonNode.eAxisAlarm) Handles cPLC.evChangeZAxisAlarm
        If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

        Dim sTemp As String = ""
        '   Dim bAlarm As Boolean = True
        For i As Integer = 0 To alarm.Length - 1
            If alarm(i) = CDevPLCCommonNode.eAxisAlarm.eNoError Then
                m_bAxis_Z_Alarm = False
            Else
                Select Case alarm(i)
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(0) & ", "
                        m_bAxis_Z_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Servo_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(1) & ", "
                        m_bAxis_Z_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_RLS_Limit_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(2) & ", "
                        m_bAxis_Z_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_FLS_Limit_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(3) & ", "
                        m_bAxis_Z_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Crush_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(4) & ", "
                        m_bAxis_Z_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Homming_Timeout
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(5) & ", "
                        m_bAxis_Z_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Moving_Timeout
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(6) & ", "
                        m_bAxis_Z_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(7) & ", "
                        m_bAxis_Z_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(8) & ", "
                        m_bAxis_Z_Alarm = True
                End Select

            End If
        Next
        If m_bAxis_Z_Alarm = True Then
            sPLCAlarmStr += "IVL-Z Axis Alarm = " & sTemp
        End If

        frmMessageUI.Message = sPLCAlarmStr & vbCrLf

        If m_bAlarmMessageShow = False And m_bEMS_Alarm = False And m_bAxis_X_Alarm = False And m_bAxis_Y_Alarm = False And m_bAxis_Z_Alarm = False Then
            frmMessageUI.HideFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_AXIS, "OK...")
            sPLCAlarmStr = ""
        Else
            frmMessageUI.ShowFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_AXIS, sPLCAlarmStr)
        End If
        AlarmMsg(sPLCAlarmStr)
    End Sub

    Private Sub cPLC_evChangeTheta1AxisAlarm(alarm() As CDevPLCCommonNode.eAxisAlarm) Handles cPLC.evChangeTheta1AxisAlarm
        If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

        Dim sTemp As String = ""
        '   Dim bAlarm As Boolean = True
        For i As Integer = 0 To alarm.Length - 1
            If alarm(i) = CDevPLCCommonNode.eAxisAlarm.eNoError Then
                m_bAxis_Theta1_Alarm = False
            Else
                Select Case alarm(i)
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(0) & ", "
                        m_bAxis_Theta1_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Servo_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(1) & ", "
                        m_bAxis_Theta1_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_RLS_Limit_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(2) & ", "
                        m_bAxis_Theta1_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_FLS_Limit_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(3) & ", "
                        m_bAxis_Theta1_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Crush_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(4) & ", "
                        m_bAxis_Theta1_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Homming_Timeout
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(5) & ", "
                        m_bAxis_Theta1_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Moving_Timeout
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(6) & ", "
                        m_bAxis_Theta1_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(7) & ", "
                        m_bAxis_Theta1_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(8) & ", "
                        m_bAxis_Theta1_Alarm = True
                End Select

            End If
        Next
        If m_bAxis_Theta1_Alarm = True Then
            sPLCAlarmStr += "IVL-Theta1 Axis Alarm = " & sTemp
        End If

        frmMessageUI.Message = sPLCAlarmStr & vbCrLf

        If m_bAlarmMessageShow = False And m_bEMS_Alarm = False And m_bAxis_Y_Alarm = False And m_bAxis_Z_Alarm = False And m_bAxis_Theta1_Alarm = False And m_bAxis_Theta2_Alarm = False And m_bAxis_Theta3_Alarm = False And m_bAxis_Theta4_Alarm = False Then
            frmMessageUI.HideFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_AXIS, "OK...")
            sPLCAlarmStr = ""
        Else
            frmMessageUI.ShowFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_AXIS, sPLCAlarmStr)
        End If
        AlarmMsg(sPLCAlarmStr)
    End Sub

    Private Sub cPLC_evChangeTheta2AxisAlarm(alarm() As CDevPLCCommonNode.eAxisAlarm) Handles cPLC.evChangeTheta2AxisAlarm
        If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

        Dim sTemp As String = ""
        '   Dim bAlarm As Boolean = True
        For i As Integer = 0 To alarm.Length - 1
            If alarm(i) = CDevPLCCommonNode.eAxisAlarm.eNoError Then
                m_bAxis_Theta2_Alarm = False
            Else
                Select Case alarm(i)
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(0) & ", "
                        m_bAxis_Theta2_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Servo_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(1) & ", "
                        m_bAxis_Theta2_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_RLS_Limit_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(2) & ", "
                        m_bAxis_Theta2_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_FLS_Limit_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(3) & ", "
                        m_bAxis_Theta2_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Crush_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(4) & ", "
                        m_bAxis_Theta2_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Homming_Timeout
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(5) & ", "
                        m_bAxis_Theta2_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Moving_Timeout
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(6) & ", "
                        m_bAxis_Theta2_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(7) & ", "
                        m_bAxis_Theta2_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(8) & ", "
                        m_bAxis_Theta2_Alarm = True
                End Select

            End If
        Next
        If m_bAxis_Theta2_Alarm = True Then
            sPLCAlarmStr += "IVL-Theta2 Axis Alarm = " & sTemp
        End If

        frmMessageUI.Message = sPLCAlarmStr & vbCrLf

        If m_bAlarmMessageShow = False And m_bEMS_Alarm = False And m_bAxis_X_Alarm = False And m_bAxis_Y_Alarm = False And m_bAxis_Z_Alarm = False And m_bAxis_Theta1_Alarm = False And m_bAxis_Theta2_Alarm = False And m_bAxis_Theta3_Alarm = False And m_bAxis_Theta4_Alarm = False Then
            frmMessageUI.HideFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_AXIS, "OK...")
            sPLCAlarmStr = ""
        Else
            frmMessageUI.ShowFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_AXIS, sPLCAlarmStr)
        End If
        AlarmMsg(sPLCAlarmStr)
    End Sub

    Private Sub cPLC_evChangeTheta3AxisAlarm(alarm() As CDevPLCCommonNode.eAxisAlarm) Handles cPLC.evChangeTheta3AxisAlarm
        If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

        Dim sTemp As String = ""
        '   Dim bAlarm As Boolean = True
        For i As Integer = 0 To alarm.Length - 1
            If alarm(i) = CDevPLCCommonNode.eAxisAlarm.eNoError Then
                m_bAxis_Theta3_Alarm = False
            Else
                Select Case alarm(i)
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(0) & ", "
                        m_bAxis_Theta3_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Servo_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(1) & ", "
                        m_bAxis_Theta3_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_RLS_Limit_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(2) & ", "
                        m_bAxis_Theta3_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_FLS_Limit_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(3) & ", "
                        m_bAxis_Theta3_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Crush_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(4) & ", "
                        m_bAxis_Theta3_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Homming_Timeout
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(5) & ", "
                        m_bAxis_Theta3_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Moving_Timeout
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(6) & ", "
                        m_bAxis_Theta3_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(7) & ", "
                        m_bAxis_Theta3_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(8) & ", "
                        m_bAxis_Theta3_Alarm = True
                End Select

            End If
        Next
        If m_bAxis_Theta3_Alarm = True Then
            sPLCAlarmStr += "IVL-Theta3 Axis Alarm = " & sTemp
        End If

        frmMessageUI.Message = sPLCAlarmStr & vbCrLf

        If m_bAlarmMessageShow = False And m_bEMS_Alarm = False And m_bAxis_X_Alarm = False And m_bAxis_Y_Alarm = False And m_bAxis_Z_Alarm = False And m_bAxis_Theta1_Alarm = False And m_bAxis_Theta2_Alarm = False And m_bAxis_Theta3_Alarm = False And m_bAxis_Theta4_Alarm = False Then
            frmMessageUI.HideFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_AXIS, "OK...")
            sPLCAlarmStr = ""
        Else
            frmMessageUI.ShowFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_AXIS, sPLCAlarmStr)
        End If
        AlarmMsg(sPLCAlarmStr)
    End Sub

    Private Sub cPLC_evChangeTheta4AxisAlarm(alarm() As CDevPLCCommonNode.eAxisAlarm) Handles cPLC.evChangeTheta4AxisAlarm
        If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

        Dim sTemp As String = ""
        '   Dim bAlarm As Boolean = True
        For i As Integer = 0 To alarm.Length - 1
            If alarm(i) = CDevPLCCommonNode.eAxisAlarm.eNoError Then
                m_bAxis_Theta4_Alarm = False
            Else
                Select Case alarm(i)
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(0) & ", "
                        m_bAxis_Theta4_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Servo_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(1) & ", "
                        m_bAxis_Theta4_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_RLS_Limit_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(2) & ", "
                        m_bAxis_Theta4_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_FLS_Limit_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(3) & ", "
                        m_bAxis_Theta4_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Crush_Alarm
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(4) & ", "
                        m_bAxis_Theta4_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Homming_Timeout
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(5) & ", "
                        m_bAxis_Theta4_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAxis_Moving_Timeout
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(6) & ", "
                        m_bAxis_Theta4_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(7) & ", "
                        m_bAxis_Theta4_Alarm = True
                    Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                        sTemp = sTemp & CDevPLCCommonNode.AxisAlarm(8) & ", "
                        m_bAxis_Theta4_Alarm = True
                End Select

            End If
        Next
        If m_bAxis_Theta4_Alarm = True Then
            sPLCAlarmStr += "IVL-Theta4 Axis Alarm = " & sTemp
        End If

        frmMessageUI.Message = sPLCAlarmStr & vbCrLf

        If m_bAlarmMessageShow = False And m_bEMS_Alarm = False And m_bAxis_X_Alarm = False And m_bAxis_Y_Alarm = False And m_bAxis_Z_Alarm = False And m_bAxis_Theta1_Alarm = False And m_bAxis_Theta2_Alarm = False And m_bAxis_Theta3_Alarm = False And m_bAxis_Theta4_Alarm = False Then
            frmMessageUI.HideFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_AXIS, "OK...")
            sPLCAlarmStr = ""
        Else
            frmMessageUI.ShowFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_AXIS, sPLCAlarmStr)
        End If
        AlarmMsg(sPLCAlarmStr)
    End Sub
    Dim sDataTypeFolder() As String = New String() {"IVL Sweep\", "Lifetime\", "Viewing Angle\", "Lifetime_IVL\"}
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsBtnTestRed.Click

        If g_SystemInfo.isConnected = True Then

            If g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.eNotUse Then  'Not Pause Mode
                g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_STATUS_RUNNING)
            Else
                If Channel_checkStart() = False Then
                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_ChannelSelection)
                Else

                    For idx As Integer = 0 To g_nMaxCh - 1

                        '    If frmControlUI.ControlUI.control.IsLoadedSequenceInfo(idx) = True Or frmControlUI.ControlUI.control.IsLoadedSavePath(idx) = True Then
                        'frmControlUI.ControlUI.control.IsSelected(idx) = True
                        '   End If

                        If frmControlUI.ControlUI.control.IsSelected(idx) = True Then
                            If cTimeScheduler.g_ChSchedulerStatus(idx) = CScheduler.eChSchedulerSTATE.eLifeTime_Running Then
                                tsBtnTestRed.Enabled = False
                                Application.DoEvents()
                                Thread.Sleep(10)

                                Dim process As CSeqProcessor.sProcessParams = Nothing
                                process.bLastPointSave = False
                                process.cmd = CSeqProcessor.eProcessState.LifeTimeMeas_Manual
                                process.index = idx
                                process.CommonInfo = SequenceList(idx).SequenceInfo.sCommon
                                process.sSampleInfos = SequenceList(idx).SequenceInfo.sSampleInfos
                                process.recipe = SequenceList(idx).Current
                                process.bFirstSourcing = True
                                process.sColor = "RED"
                                ManaulrequestMeas(process)   '데이터 측정 요청
                                tsBtnTestRed.Enabled = True
                                'Exit Sub
                                ' End If
                            End If
                        End If
                    Next
                End If

            End If
        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles tsBtnTestGreen.Click
        If g_SystemInfo.isConnected = True Then

            If g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.eNotUse Then  'Not Pause Mode
                g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_STATUS_RUNNING)
            Else
                If Channel_checkStart() = False Then
                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_ChannelSelection)
                Else

                    For idx As Integer = 0 To g_nMaxCh - 1

                        If frmControlUI.ControlUI.control.IsSelected(idx) = True Then
                            If cTimeScheduler.g_ChSchedulerStatus(idx) = CScheduler.eChSchedulerSTATE.eLifeTime_Running Then
                                tsBtnTestGreen.Enabled = False
                                Application.DoEvents()
                                Thread.Sleep(10)

                                Dim process As CSeqProcessor.sProcessParams = Nothing
                                process.bLastPointSave = False
                                process.cmd = CSeqProcessor.eProcessState.LifeTimeMeas_Manual
                                process.index = idx
                                process.CommonInfo = SequenceList(idx).SequenceInfo.sCommon
                                process.sSampleInfos = SequenceList(idx).SequenceInfo.sSampleInfos
                                process.recipe = SequenceList(idx).Current
                                process.bFirstSourcing = True
                                process.sColor = "GREEN"
                                ManaulrequestMeas(process)   '데이터 측정 요청

                                tsBtnTestGreen.Enabled = True

                            End If

                        End If
                    Next
                End If

            End If
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles tsBtnTestBlue.Click
        If g_SystemInfo.isConnected = True Then

            If g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.eNotUse Then  'Not Pause Mode
                g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_STATUS_RUNNING)
            Else
                If Channel_checkStart() = False Then
                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_ChannelSelection)
                Else

                    For idx As Integer = 0 To g_nMaxCh - 1

                        '    If frmControlUI.ControlUI.control.IsLoadedSequenceInfo(idx) = True Or frmControlUI.ControlUI.control.IsLoadedSavePath(idx) = True Then
                        'frmControlUI.ControlUI.control.IsSelected(idx) = True
                        '   End If

                        If frmControlUI.ControlUI.control.IsSelected(idx) = True Then
                            If cTimeScheduler.g_ChSchedulerStatus(idx) = CScheduler.eChSchedulerSTATE.eLifeTime_Running Then
                                tsBtnTestBlue.Enabled = False
                                Application.DoEvents()
                                Thread.Sleep(10)

                                Dim process As CSeqProcessor.sProcessParams = Nothing
                                process.bLastPointSave = False
                                process.cmd = CSeqProcessor.eProcessState.LifeTimeMeas_Manual
                                process.index = idx
                                process.CommonInfo = SequenceList(idx).SequenceInfo.sCommon
                                process.sSampleInfos = SequenceList(idx).SequenceInfo.sSampleInfos
                                process.recipe = SequenceList(idx).Current
                                process.bFirstSourcing = True
                                process.sColor = "BLUE"
                                ManaulrequestMeas(process)   '데이터 측정 요청
                                'Dim sJIGName As String = Nothing

                                'If g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eChannel Then
                                '    sJIGName = CStr(Format(idx + 1, "00"))
                                'ElseIf g_SystemOptions.sOptionData.DispGroup.ChDispType = CChDisp.eChannelDispType.eJIGAndCellNo Then
                                '    sJIGName = ucDispJIG.convertIncNumberToMatrixValue(idx)
                                'End If

                                'Dim sCaptionAndTEGNumber As String = "TEG" & Format(idx + 1, "00") 'ucDispJIG.convertIncNumberToMatrixValue(m_nCh)

                                'For i As Integer = 0 To SequenceList(idx).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                                '    Application.DoEvents()
                                '    Thread.Sleep(10)
                                '    Dim nCount As Integer = g_DataSaver(idx).BlueSavedDataCounter(i)
                                '    If nCount = 0 Then
                                '        g_DataSaver(idx).SaveHeaderInfoOfCellLifetime_RGB(idx, SequenceList(idx).SequenceInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(1) & sCaptionAndTEGNumber & "_" & SequenceList(idx).SequenceInfo.sCommon.saveInfo.strOnlyFName & "_" & "BLUE" & "_" & SequenceList(idx).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(i).X & "_" & SequenceList(idx).SequenceInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(i).Y & ".csv", SequenceList(idx).Current.sLifetimeInfo, i)
                                '        cQueueProcessor.LifetimeMeasurement("BLUE", idx, i, True)
                                '    Else
                                '        cQueueProcessor.LifetimeMeasurement("BLUE", idx, i)
                                '    End If

                                'Next


                                tsBtnTestBlue.Enabled = True

                            End If

                        End If
                    Next
                End If

            End If
        End If
    End Sub

    Private Sub tsBtnTestBlack_Click(sender As Object, e As EventArgs) Handles tsBtnTestBlack.Click
        If g_SystemInfo.isConnected = True Then

            If g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.eNotUse Then  'Not Pause Mode
                g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_STATUS_RUNNING)
            Else
                If Channel_checkStart() = False Then
                    g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Need_ChannelSelection)
                Else

                    For idx As Integer = 0 To g_nMaxCh - 1

                        '    If frmControlUI.ControlUI.control.IsLoadedSequenceInfo(idx) = True Or frmControlUI.ControlUI.control.IsLoadedSavePath(idx) = True Then
                        'frmControlUI.ControlUI.control.IsSelected(idx) = True
                        '   End If

                        If frmControlUI.ControlUI.control.IsSelected(idx) = True Then
                            If cTimeScheduler.g_ChSchedulerStatus(idx) = CScheduler.eChSchedulerSTATE.eLifeTime_Running Then
                                tsBtnTestBlack.Enabled = False
                                Application.DoEvents()
                                Thread.Sleep(10)


                                Dim process As CSeqProcessor.sProcessParams = Nothing
                                process.bLastPointSave = False
                                process.cmd = CSeqProcessor.eProcessState.LifeTimeMeas_Manual
                                process.index = idx
                                process.CommonInfo = SequenceList(idx).SequenceInfo.sCommon
                                process.sSampleInfos = SequenceList(idx).SequenceInfo.sSampleInfos
                                process.recipe = SequenceList(idx).Current
                                process.bFirstSourcing = True
                                process.sColor = "BLACK"
                                ManaulrequestMeas(process)   '데이터 측정 요청
                                tsBtnTestBlack.Enabled = True
                                'Exit Sub
                                ' End If
                            End If

                        End If
                    Next
                End If

            End If
        End If
    End Sub

    Private Sub cPLC_evChangeDoorAlarm(ByVal alarm() As CDevPLCCommonNode.eDoorAlarm) Handles cPLC.evChangeDoorAlarm
        If g_SystemInfo.isConnected = False Then Exit Sub '시스템이 연결되지 않은 상태의 이벤트는 무시한다.

        Dim sTemp As String = ""
        '   Dim bAlarm As Boolean = True
        For i As Integer = 0 To alarm.Length - 1
            If alarm(i) = CDevPLCCommonNode.eAxisAlarm.eNoError Then
                m_bDoor_Alarm = False
            Else
                Select Case alarm(i)
                    Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_Loop
                        sTemp = sTemp & CDevPLCCommonNode.sDoorOpenAlarm(0) & ", "
                        m_bDoor_Alarm = True
                    Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_1
                        sTemp = sTemp & CDevPLCCommonNode.sDoorOpenAlarm(1) & ", "
                        m_bDoor_Alarm = True
                    Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_2
                        sTemp = sTemp & CDevPLCCommonNode.sDoorOpenAlarm(2) & ", "
                        m_bDoor_Alarm = True
                    Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_3
                        sTemp = sTemp & CDevPLCCommonNode.sDoorOpenAlarm(3) & ", "
                        m_bDoor_Alarm = True
                    Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_4
                        sTemp = sTemp & CDevPLCCommonNode.sDoorOpenAlarm(4) & ", "
                        m_bDoor_Alarm = True
                    Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_5
                        sTemp = sTemp & CDevPLCCommonNode.sDoorOpenAlarm(5) & ", "
                        m_bDoor_Alarm = True
                    Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_6
                        sTemp = sTemp & CDevPLCCommonNode.sDoorOpenAlarm(6) & ", "
                        m_bDoor_Alarm = True
                    Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_7
                        sTemp = sTemp & CDevPLCCommonNode.sDoorOpenAlarm(7) & ", "
                        m_bDoor_Alarm = True
                    Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_8
                        sTemp = sTemp & CDevPLCCommonNode.sDoorOpenAlarm(8) & ", "
                        m_bDoor_Alarm = True
                End Select
            End If
        Next
        If m_bDoor_Alarm = True Then
            sPLCAlarmStr &= "Door Alarm = " & sTemp
        End If

        frmMessageUI.Message = sPLCAlarmStr & vbCrLf

        If m_bAlarmMessageShow = False And m_bEMS_Alarm = False And m_bAxis_X_Alarm = False And m_bAxis_Y_Alarm = False And m_bAxis_Z_Alarm = False And m_bDoor_Alarm = False Then
            frmMessageUI.HideFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_DOOR_SAFETY1, "OK...")
            sPLCAlarmStr = ""
        Else
            frmMessageUI.ShowFrame()
            g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMsg_State_Log_Alarm_Text, CStateMsg.eStateMsg.ePLC_ALARM_DOOR_SAFETY1, sPLCAlarmStr)
        End If
        AlarmMsg(sPLCAlarmStr)
    End Sub

   
    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If g_SystemInfo.isConnected = True Then

            If g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.eNotUse Then  'Not Pause Mode
                g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_STATUS_RUNNING)
            Else
                Thread.Sleep(100)
                Application.DoEvents()
                ManauldeleteMeasQueue()   '데이터 측정 요청
            End If

        End If
    End Sub

  
    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If g_SystemInfo.isConnected = True Then

            If g_PauseCtrl.getState = CPauseControl.ePAUSESTATe.eNotUse Then  'Not Pause Mode
                g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_STATUS_RUNNING)
            Else
                Thread.Sleep(100)
                Application.DoEvents()
                AutoRundeleteMeasQueue()   '데이터 측정 요청
            End If

        End If
    End Sub
End Class