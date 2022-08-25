Imports System.Threading
Imports CSpectrometerLib
Imports CSMULib
Imports System.IO

Public Class ucKeithleyOrM6000AndSW7000Manual
    Dim myParent As frmMain

    Dim sMeasMode() As String = New String() {"IV", "IVL"}
    Dim sBiasMode() As String = New String() {"CC", "CV"}
    '  Dim sDataHeader() As String = New String() {"No", "Mode", "Area(cm^2)", "Voltage(V)", "Current(mA)", "CurrentDensity(mA/cm^2)", _
    '   "Luminance(cd/m^2)", "Current Efficiency(cd/A)", "Power Efficiency(lm/W)", "QE(%)", "CIE_x", "CIE_y", "CIE_u'", "CIE_v'", "CCT"}

    ' Dim sDataHeader() As String = New String() {"No", "Mode", "Area(cm^2)", "Red_Voltage(V)", "Green_Voltage(V)", "Blue_Voltage(V)", "Red_Current(mA)", "Green_Current(mA)", " Blue_Current(mA)", "Tot_Current(mA)", "Tot_CurrentDensity(mA/cm^2)", _
    '                                            "Luminance(cd/m^2)", "CIE_x", "CIE_y", "CIE_u'", "CIE_v'", "CCT"}
    Dim sDataHeader() As String = New String() {"No", "Mode", "Area(cm^2)", "Current(mA)", "CurrentDensity(mA/cm^2)", _
                                           "Luminance_Fill(cd/m^2)", "Luminance(cd/m^2)", "CIE_x", "CIE_y", "CIE_u'", "CIE_v'", "CCT"}
    Dim sSpectrumDataHeader() As String = New String() {"No."}
    Dim nCnt As Integer = 0
    Dim m_KeithleySettings As CSMULib.ucKeithleySMUSettings.sKeithley
    Dim m_SourceComponent As eManualSourceComponent = eManualSourceComponent.eM6000AndKeithley
    Dim m_Loop As Boolean = False
    ' Dim m_SourceMode() As CDevM6000.eMode
#Region "Enum"
    Public Enum eManualSourceComponent
        eM6000
        eKeithley
        eM6000AndKeithley
    End Enum
#End Region


    Public WriteOnly Property DeviceOption As frmMain.sDeviceOptions
        Set(ByVal value As frmMain.sDeviceOptions)
            SetDeviceOption(value)
        End Set
    End Property

    Private Sub SetDeviceOption(ByVal sOption As frmMain.sDeviceOptions)
        With cbAperture
            .Items.Clear()
            If sOption.sSpectrometer.ApertureList Is Nothing = False Then
                For i As Integer = 0 To g_SystemOptions.sDeviceOption.sSpectrometer.ApertureList.Length - 1
                    .Items.Add(g_SystemOptions.sDeviceOption.sSpectrometer.ApertureList(i).sApertureName)
                Next
                cbAperture.SelectedIndex = g_SystemOptions.sOptionData.Spectrometer.nAperture
            Else
                .Items.Add("Nothing")
            End If

        End With

        'With cbSpeedMode
        '    .Items.Clear()
        '    If sOption.sSpectrometer.MeasSpeedList Is Nothing = False Then
        '        For i As Integer = 0 To g_SystemOptions.sDeviceOption.sSpectrometer.MeasSpeedList.Length - 1
        '            .Items.Add(g_SystemOptions.sDeviceOption.sSpectrometer.MeasSpeedList(i).sSpeedName)
        '        Next
        '        cbSpeedMode.SelectedIndex = g_SystemOptions.sOptionData.IVLSpectrometer.nSpeedMode
        '    Else
        '        .Items.Add("Nothing")
        '    End If


        'End With
    End Sub

#Region "Creator And Disposer"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = Parent
        init()
    End Sub

    Public Sub New(ByVal parent As frmMain, ByVal nComponent As eManualSourceComponent)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = parent
        m_SourceComponent = nComponent
        init()

    End Sub

    Private Sub init()
        Dim m_InitKeithleySettings As CSMULib.ucKeithleySMUSettings.sKeithley

        m_InitKeithleySettings.WireMode = CSMULib.ucKeithleySMUSettings.eProve.e2Prove

        m_InitKeithleySettings.LimitCurrent = 0.1

        gbFreeRun.Location = New System.Drawing.Point(0, 0)

        'With cbChannel
        '    .Items.Clear()
        '    For i As Integer = 0 To g_nMaxCh - 1
        '        .Items.Add(Format(i + 1, "000"))
        '    Next
        '    .SelectedIndex = 0
        'End With

        With cbMeasMode
            .Items.Clear()
            For i As Integer = 0 To sMeasMode.Length - 1
                .Items.Add(sMeasMode(i))
            Next
            .SelectedIndex = 0
        End With

        With cbBiasMode
            .Items.Clear()
            For i As Integer = 0 To sBiasMode.Length - 1
                .Items.Add(sBiasMode(i))
            Next
            .SelectedIndex = 1
        End With

        rdoM6000.Checked = True

        ucMeasDataListview.Location = New System.Drawing.Point(0, 0)
        ucMeasDataListview.Dock = DockStyle.Fill

        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100

        With cbAperture
            .Items.Clear()
            If g_SystemOptions.sDeviceOption.sSpectrometer.ApertureList Is Nothing Then
                .Items.Add("Nothing")
            Else
                For i As Integer = 0 To g_SystemOptions.sDeviceOption.sSpectrometer.ApertureList.Length - 1
                    .Items.Add(g_SystemOptions.sDeviceOption.sSpectrometer.ApertureList(i).sApertureName)
                Next
            End If
            cbAperture.SelectedIndex = 0
        End With

        With cbSpeedMode
            .Items.Clear()
            .Items.Add("Nothing")
            cbSpeedMode.SelectedIndex = 0
        End With

        tbSampleHeight.Text = g_SystemOptions.sOptionData.SampleInfos.dHeight
        tbSampleWidth.Text = g_SystemOptions.sOptionData.SampleInfos.dWidth
        tbFill.Text = g_SystemOptions.sOptionData.SampleInfos.dFillFactor

        If m_SourceComponent <> eManualSourceComponent.eM6000 Then
            ucKeithleySMUSettings.DisplayMode = g_ConfigInfos.SMUForIVLConfig(0).device
            ' ucKeithleySMUSettings.ControlUI = g_ConfigInfos.SMUForIVLConfig(0).sRangeList

            '희성소재 Defalut Set
            m_InitKeithleySettings = ucKeithleySMUSettings.Settings
            m_InitKeithleySettings.TerminalMode = CSMULib.ucKeithleySMUSettings.eTerminalMode.eRear
            m_InitKeithleySettings.LimitCurrent = 0.1
            m_InitKeithleySettings.WireMode = CSMULib.ucKeithleySMUSettings.eProve.e2Prove
            m_InitKeithleySettings.NumOfMeasData = 1000
            m_InitKeithleySettings.SourceMode = CSMULib.ucKeithleySMUSettings.eSMUMode.eVoltage

            ucKeithleySMUSettings.Settings = m_InitKeithleySettings

            ucKeithleySMUSettings.rbCC.Enabled = False
            ucKeithleySMUSettings.rbCV.Enabled = False

            rdoKeithley.Enabled = True
            rdoKeithley.Checked = True


            'Select Case myParent.cIVLSMU(0).mySMU.Model


            '    Case CDevSMUCommonNode.eModel.KEITHLEY_K236 To CDevSMUCommonNode.eModel.kEITHLEY_K238
            '        m_InitKeithleySettings = ucKeithleySMUSettings.Settings
            '        m_InitKeithleySettings.nIntegTimeIndex = 2
            '        m_InitKeithleySettings.SourceMode = CSMULib.ucKeithleySMUSettings.eSMUMode.eVoltage
            '        ucKeithleySMUSettings.Settings = m_InitKeithleySettings
            'End Select
        ElseIf m_SourceComponent = eManualSourceComponent.eM6000 Then
            '  rdoKeithley.Visible = False
            ' ucKeithleySMUSettings.Visible = False
            rdoM6000.Enabled = True
            rdoM6000.Checked = True
        End If
       
        InitDataIndicator()

    
    End Sub


    Private Sub InitDataIndicator()
        Dim sData() As String


        ReDim sData(sDataHeader.Length - 1)
        ucMeasDataListview.ColHeader = sDataHeader.Clone
        Dim colWidthRatio As String
        colWidthRatio = "6,9,12" ',15,15,15,15,15,15,10,10,10,10,10,10,10,10"
        Dim nWidth As Integer = Fix(200 / (sDataHeader.Length - 3))
        For i As Integer = 1 To sDataHeader.Length - 3
            colWidthRatio = colWidthRatio & "," & CStr(nWidth)
        Next
        ucMeasDataListview.ColHeaderWidthRatio = colWidthRatio
        ucMeasDataListview.ClearAllData()

        ReDim sSpectrumDataHeader(sSpectrumDataHeader.Length + 400)

        sSpectrumDataHeader(0) = "No."
        For i As Integer = 1 To sSpectrumDataHeader.Length - 1
            sSpectrumDataHeader(i) = 379 + i
        Next

        ReDim sData(sSpectrumDataHeader.Length - 1)

        UcDispListView1.ColHeader = sSpectrumDataHeader.Clone
        ' Dim colWidthRatio As String
        colWidthRatio = "6" '',15,15,15,15,15,15,10,10,10,10,10,10,10,10"
        nWidth = Fix(4000 / (sSpectrumDataHeader.Length - 1))
        For i As Integer = 1 To sSpectrumDataHeader.Length - 1
            colWidthRatio = colWidthRatio & "," & CStr(nWidth)
        Next
        UcDispListView1.ColHeaderWidthRatio = colWidthRatio
        UcDispListView1.ClearAllData()
    End Sub
#End Region

#Region "Event"
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ucMeasDataListview.ClearAllData()
        nCnt = 0
    End Sub
    Public Sub EnableUI()

    End Sub
    Private Sub btnON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnON.Click
        Dim nCh As Integer
        Dim sErrorMessage As String = Nothing

        If CheckChannelNumberToSelectSourcemeter(sErrorMessage) = False Then
            MsgBox(sErrorMessage)
        End If

        EventDisplayEnabled(False)

        Try
            nCh = myParent.frmMotionUI.GetChannelComboBoxToSelectNumber 'cbChannel.SelectedIndex
        Catch ex As Exception
            MsgBox("Please Check the Channel Number...")
            EventDisplayEnabled(True)
            Exit Sub
        End Try

        '실험 중인 채널은 컨트롤 할 수 없음.
        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) <> CScheduler.eChSchedulerSTATE.eIdle Then
            myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Can_use_in_IDLE_STATUE, "")
            EventDisplayEnabled(True)
            Exit Sub
        End If

        '예외처리 1~7번 테그는 M6000으로만 소스제어하고 8번 테그는 키슬리로만 제어한다. Allocation 따라감 YJS
        Dim bLTUsed As Boolean = True
        Dim bIVLUsed As Boolean = True
        bLTUsed = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eLifetimeUse)
        bIVLUsed = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eIVLUse)
        If rdoKeithley.Checked = True Then
            If bLTUsed = False Then
                MsgBox("해당 채널은 SourceComponent로 Keithley를 사용할 수 없습니다." & vbCrLf & " M6000을 선택해주십시오.")
                EventDisplayEnabled(True)
                Exit Sub
            End If
        End If

        If rdoM6000.Checked = True Then
            If bIVLUsed = False Then
                MsgBox("해당 채널은 SourceComponent로 M6000을 사용할 수 없습니다." & vbCrLf & " Keithley를 선택해주십시오.")
                EventDisplayEnabled(True)
                Exit Sub
            End If
        End If

        If rdoKeithley.Checked = True Then
            myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSystem_Manual_Cell_ONOFF, nCh + 1 & " : Keithley Cell On")
            'If SourceOnOffSW7000(nCh, False) = False Then
            '    EventDisplayEnabled(True)
            '    Exit Sub
            'End If

            '  If SourceOnOffKeithley(nCh, False) = False Then
            'EventDisplayEnabled(True)
            '  Exit Sub
            ' End If

            'If SourceOnOffSW7000(nCh, True) = False Then
            '    EventDisplayEnabled(True)
            '    Exit Sub
            'End If
            If SourceOnOffKeithley(nCh, True) = False Then
                EventDisplayEnabled(True)
                Exit Sub
            End If

        ElseIf rdoM6000.Checked = True Then
            myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSystem_Manual_Cell_ONOFF, nCh + 1 & " : M6000 Cell On")
            If SourceOnOffM6000(nCh, True) = False Then
                EventDisplayEnabled(True)
                Exit Sub
            End If
        Else
            MsgBox("Error(Not Selected.Keithley or M6000...)")
            EventDisplayEnabled(True)
            Exit Sub
        End If

        'keithley Or M6000 Source On, Off    True = On   False = Off  On는 M6000 or keithley 하나씩 컨트롤 해야 함...

        EventDisplayEnabled(True)
    End Sub

    Private Sub btnOFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOFF.Click
        Dim nCh As Integer
        Dim sErrorMessage As String = Nothing

        If CheckChannelNumberToSelectSourcemeter(sErrorMessage) = False Then
            MsgBox(sErrorMessage)
        End If

        EventDisplayEnabled(False)

        Try
            nCh = myParent.frmMotionUI.GetChannelComboBoxToSelectNumber 'cbChannel.SelectedIndex
        Catch ex As Exception
            MsgBox("Please Check the Channel Number...")
            EventDisplayEnabled(True)
            Exit Sub
        End Try

        '실험 중인 채널은 컨트롤 할 수 없음.
        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) <> CScheduler.eChSchedulerSTATE.eIdle Then
            myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Selected_Ch_Alredy_Running)
            EventDisplayEnabled(True)
            Exit Sub
        End If

        '예외처리 1~7번 테그는 M6000으로만 소스제어하고 8번 테그는 키슬리로만 제어한다. Allocation 따라감 YJS
        Dim bLTUsed As Boolean = True
        Dim bIVLUsed As Boolean = True
        bLTUsed = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eLifetimeUse)
        bIVLUsed = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eIVLUse)
        If rdoKeithley.Checked = True Then
            If bLTUsed = False Then
                MsgBox("해당 채널은 SourceComponent로 Keithley를 사용할 수 없습니다." & vbCrLf & " M6000을 선택해주십시오.")
                EventDisplayEnabled(True)
                Exit Sub
            End If
        End If

        If rdoM6000.Checked = True Then
            If bIVLUsed = False Then
                MsgBox("해당 채널은 SourceComponent로 M6000을 사용할 수 없습니다." & vbCrLf & " Keithley를 선택해주십시오.")
                EventDisplayEnabled(True)
                Exit Sub
            End If
        End If


        'keithley Or M6000 Source On, Off    True = On   False = Off   Off는 M6000 And keithley 전부 해도 상관 없음...
        If rdoKeithley.Checked = True Then
            myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSystem_Manual_Cell_ONOFF, nCh + 1 & " : Keithley Cell OFF")
            If SourceOnOffKeithley(nCh, False) = False Then
                EventDisplayEnabled(True)
                Exit Sub
            End If

            'If SourceOnOffSW7000(nCh, False) = False Then
            '    EventDisplayEnabled(True)
            '    Exit Sub
            'End If

        ElseIf rdoM6000.Checked = True Then
            myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eSystem_Manual_Cell_ONOFF, nCh + 1 & " : M6000 Cell OFF")
            If SourceOnOffM6000(nCh, False) = False Then
                EventDisplayEnabled(True)
                Exit Sub
            End If
        Else
            MsgBox("Error(Keithley or M6000 선택되어 있지 않습니다...)")
            EventDisplayEnabled(True)
            Exit Sub
        End If

        EventDisplayEnabled(True)
    End Sub

    Private Sub btnMeas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeas.Click
        Dim nCh As Integer = myParent.frmMotionUI.GetChannelComboBoxToSelectNumber 'cbChannel.SelectedIndex
        Dim MeasMode As ucDispRcpIVLSweep.eMeasureItems = cbMeasMode.SelectedIndex
        Dim sData() As String = Nothing
        Dim MeasValOfM6000 As CDevM6000PLUS.sMeasParams = Nothing
        Dim SampleInfos As ucSampleInfos.sSampleInfos = Nothing
        Dim dAngleValue As Double = tbAngleValue.Text

        Dim sErrorMessage As String = Nothing

        If CheckChannelNumberToSelectSourcemeter(sErrorMessage) = False Then
            MsgBox(sErrorMessage)
        End If

        EventDisplayEnabled(False)

        Try
            SampleInfos.dFillFactor = CDbl(tbFill.Text)
            SampleInfos.SampleSize.Height = CDbl(tbSampleHeight.Text)
            SampleInfos.SampleSize.Width = CDbl(tbSampleWidth.Text)
        Catch ex As Exception
            SampleInfos.dFillFactor = 100
            SampleInfos.SampleSize.Height = 2
            SampleInfos.SampleSize.Width = 2
        End Try

        ''If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) <> CScheduler.eChSchedulerSTATE.eIdle Then
        ''    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Can_use_in_IDLE_STATUE, "")
        ''    EventDisplayEnabled(True)
        ''    Exit Sub
        ''End If


        Dim sMeasureDatas As frmMain.sRealTimeDataOfM6000 = Nothing

        sMeasureDatas.eachPixelMeasData = Nothing

        sMeasureDatas.eachPixelMeasData.dVoltage_Bias = 0
        sMeasureDatas.eachPixelMeasData.dVoltage_Amplitude = 0
        sMeasureDatas.eachPixelMeasData.dCurrent_Bias = 0
        sMeasureDatas.eachPixelMeasData.dCurrent_Amplitude = 0
        sMeasureDatas.eachPixelMeasData.dPDCurrent = 0
        Dim nChOfSwitch As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSwitch)
        Dim nDevSwitch As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
        Dim nChOfPairSwitch As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfPairSwitch)
        '2. Data Read Keithley or M6000
        If rdoKeithley.Checked = True Then

            ''Dim nDeviceNoOfSMU As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
            ''Dim nChOfSMUDevice As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSMU_IVL)
            ''Dim dVoltage As Double
            Dim dCurrent As Double

            ''If myParent.cIVLSMU(nDeviceNoOfSMU).mySMU.Measure(dVoltage, dCurrent) = False Then
            ''End If

            ''sMeasureDatas.eachPixelMeasData.dVoltage_Bias = dVoltage
            ''sMeasureDatas.eachPixelMeasData.dCurrent_Bias = dCurrent

            If myParent.cSwitch(nDevSwitch).mySwitch.SwitchON(nChOfSwitch) = False Then

            End If

            If myParent.cSwitch(nDevSwitch).mySwitch.SwitchON(nChOfPairSwitch) = False Then
                '예외처리
            End If


            'If myParent.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch) = False Then

            'End If
            '여기에 DMM전류 읽기 추가
            If myParent.cDMM(0).Measure(dCurrent) = False Then
                '예외처리 필요
            End If

            For i As Integer = 0 To 4
                Application.DoEvents()
                Thread.Sleep(50)
                If myParent.cDMM(0).Measure(dCurrent) = True Then
                    dCurrent += dCurrent
                End If
            Next

            dCurrent = dCurrent / 5

            sMeasureDatas.eachPixelMeasData.dCurrent_Bias = dCurrent

            Application.DoEvents()
            Thread.Sleep(100)
            If myParent.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfPairSwitch) = False Then

            End If

            '읽고 난 후 원복
            If myParent.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch) = False Then
                '예외처리
            End If

        ElseIf rdoM6000.Checked = True Then
            sMeasureDatas = myParent.cQueueProcessor.UpdateRealTimeData(nCh)
            sMeasureDatas.eachPixelMeasData.dCurrent_Bias = sMeasureDatas.eachPixelMeasData.dCurrent_Bias / 1000
        End If

        sMeasureDatas.dTotCurrent = sMeasureDatas.eachPixelMeasData.dCurrent_Bias
        '3. Data Cal 
        Dim sSpectrumData() As Double = Nothing
        sData = CalculateKeithleyOrM6000DataForM7000(nCh, SampleInfos, sMeasureDatas, MeasMode, sSpectrumData)


        '4. Display
        ucMeasDataListview.AddRowData(sData)
        UcDispListView1.AddRowData(sSpectrumData)

        nCnt += 1

        'If myParent.cSwitch(nDevSwitch).mySwitch.SwitchOFF(nChOfSwitch) = False Then

        'End If

        EventDisplayEnabled(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveTestData()
    End Sub

    'Private Sub cbChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim nCh As Integer

    '    Try
    '        nCh = cbChannel.SelectedIndex
    '    Catch ex As Exception
    '        MsgBox("Please Check the Channel Number...")
    '        Exit Sub
    '    End Try

    '    If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) <> CScheduler.eChSchedulerSTATE.eIdle Then
    '        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Can_use_in_IDLE_STATUE, "")
    '        For i As Integer = 0 To g_nMaxCh - 1
    '            If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
    '                cbChannel.SelectedItem = i
    '                Exit Sub
    '            End If
    '        Next
    '        Exit Sub
    '    End If

    'End Sub

    Private Sub btnAllOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllOff.Click
        'Dim sErrorMessage As String = Nothing
        'If CheckChannelNumberToSelectSourcemeter(sErrorMessage) = False Then
        '    MsgBox(sErrorMessage)
        'End If

        'EventDisplayEnabled(False)

        'If Experiment() = False Then
        '    MsgBox("All-Off fail.....")
        '    EventDisplayEnabled(True)
        'End If

        'EventDisplayEnabled(True)

        'switch all off

        'test check
        For nCh As Integer = 0 To g_nMaxCh - 1
            If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
                MsgBox("Cannot use to Test")
                Exit Sub
            End If
        Next

        myParent.cSwitch(0).mySwitch.AllOFF()

        Dim settings As ucKeithleySMUSettings.sKeithley = ucKeithleySMUSettings.Settings

        If myParent.cIVLSMU(0).mySMU.InitializeSweep(settings) = False Then
            Exit Sub
        End If
        myParent.cIVLSMU(0).mySMU.OutputOff()

    End Sub

    Private Sub cbBiasMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBiasMode.SelectedIndexChanged
        Dim settings As ucKeithleySMUSettings.sKeithley = ucKeithleySMUSettings.Settings

        If cbBiasMode.SelectedIndex = CDevM6000PLUS.eMode.eCC Then
            lblBiasUnit.Text = "mA"
            lblBiasUnit.Text = "mA"
            settings.SourceMode = CSMULib.ucKeithleySMUSettings.eSMUMode.eCurrent
        ElseIf cbBiasMode.SelectedIndex = CDevM6000PLUS.eMode.eCV Then
            lblBiasUnit.Text = "V"
            lblBiasUnit.Text = "V"
            settings.SourceMode = CSMULib.ucKeithleySMUSettings.eSMUMode.eVoltage
        End If
        settings.TerminalMode = CSMULib.ucKeithleySMUSettings.eTerminalMode.eFront
        ucKeithleySMUSettings.Settings = settings

    End Sub

    Private Sub rdoKeithley_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoKeithley.CheckedChanged
        If rdoKeithley.Checked = True Then
            ucKeithleySMUSettings.Enabled = True
            btnSelectColorAllOn.Enabled = True
            ProgressBar2.Enabled = False
        Else
            ucKeithleySMUSettings.Enabled = False
            btnSelectColorAllOn.Enabled = True
            ProgressBar2.Enabled = True
        End If
    End Sub

    Private Sub btnMotionMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMotionMove.Click
        '   Dim nCh As Integer = myParent.frmMotionUI.GetChannelComboBoxToNumber
        Dim dAngle As Double = tbAngleValue.Text
        Dim dDistance As Double = Nothing

        Try
            dAngle = tbAngleValue.Text
        Catch ex As Exception
            MsgBox("Please check the angle value")
            Exit Sub
        End Try

        If dAngle < 0 And dAngle > 60 Then
            MsgBox("Please check the angle value(Min = Value,  Max = Value)")
            Exit Sub
        End If

        EventDisplayEnabled(False)

        ''X,Y,Z축 Move
        'If myParent.cMotion.SetPositionXYAxisMovingFirst(g_motionPosSpectrometer(nCh)) = False Then
        '    EventDisplayEnabled(True)
        '    Exit Sub
        '    '예외처리 'LEX
        'End If

        'myParent.cMotion.MoveCompletedAllAxis()
        'Application.DoEvents()
        'Thread.Sleep(100)

        'Wad Move
        'dDistance 각도에 따른 거리 계산 필요
        dDistance = dAngle '* 1도당 계산 튜닝 값

        If myParent.m_bThetaAxisUsed = True Then
            myParent.cMotion.ViewAngleMove(dDistance, True)
        End If

        'myParent.cMotion.MoveCompletedAllAxis()
        Application.DoEvents()
        Thread.Sleep(100)

        EventDisplayEnabled(True)
    End Sub
#End Region

#Region "Function"
    Public Function SaveTestData() As Boolean
        Dim cFile As New CMcFile
        Dim sLineBuf As String = ""
        Dim m_FileInfo As CMcFile.sFILENAME = Nothing
        Dim m_nFileNum As Integer = 10
        Dim datas() As ListViewItem.ListViewSubItem = Nothing
        Dim sSpectrumHeader() As String = Nothing
        Dim sr As StreamWriter
        Dim srsp As StreamWriter
        If cFile.GetSaveFileName(CMcFile.eFileType._CSV, m_FileInfo) = False Then Return False

        Try
            sr = New StreamWriter(m_FileInfo.strPathAndFName, True)
            '   FileOpen(m_nFileNum, m_FileInfo.strPathAndFName, OpenMode.Append, OpenAccess.Write, OpenShare.Shared) '파일을 열고
        Catch ex As Exception
            ' FileClose(m_nFileNum)
            sr.Close()
            Return False
        End Try

        For i As Integer = 0 To sDataHeader.Length - 1
            sLineBuf = sLineBuf & sDataHeader(i) & ","
        Next
        sr.WriteLine(sLineBuf)
        'PrintLine(m_nFileNum, sLineBuf)

        For i As Integer = 0 To ucMeasDataListview.GetListItemCount - 1
            ucMeasDataListview.GetRowData(i, datas)
            sLineBuf = ""
            For j As Integer = 0 To datas.Length - 1
                sLineBuf = sLineBuf & datas(j).Text & ","
            Next
            sr.WriteLine(sLineBuf)
            ' PrintLine(m_nFileNum, sLineBuf)
        Next

        Try
            srsp = New StreamWriter(m_FileInfo.strFPath & m_FileInfo.strOnlyFName & "_SP.csv", True)
            '   FileOpen(m_nFileNum, m_FileInfo.strPathAndFName, OpenMode.Append, OpenAccess.Write, OpenShare.Shared) '파일을 열고
        Catch ex As Exception
            ' FileClose(m_nFileNum)
            srsp.Close()
            Return False
        End Try

        sLineBuf = ""
        datas = Nothing
        For i As Integer = 0 To sSpectrumDataHeader.Length - 1
            sLineBuf = sLineBuf & sSpectrumDataHeader(i) & ","
        Next
        srsp.WriteLine(sLineBuf)

        For i As Integer = 0 To UcDispListView1.GetListItemCount - 1
            UcDispListView1.GetRowData(i, datas)
            sLineBuf = ""
            For j As Integer = 0 To datas.Length - 1
                sLineBuf = sLineBuf & datas(j).Text & ","
            Next
            srsp.WriteLine(sLineBuf)
            ' PrintLine(m_nFileNum, sLineBuf)
        Next


        '  sLineBuf = ""

        sr.Close()
        srsp.Close()
        'FileClose(m_nFileNum)

        Return True
    End Function

    Private Function timer_Sec() As Single
        Return CSng((Now.Minute * 60) + Now.Second + (Now.Millisecond / 1000))
    End Function

    Private Sub EventDisplayEnabled(ByVal bool As Boolean)
        btnON.Enabled = bool
        btnOFF.Enabled = bool
        btnMeas.Enabled = bool
        btnClear.Enabled = bool
        btnSave.Enabled = bool
        btnAllOff.Enabled = bool
    End Sub

    Public Function CalculateKeithleyOrM6000DataForM7000(ByVal nCh As Integer, ByVal SampleInfos As ucSampleInfos.sSampleInfos, ByVal sMeasureDatasOfM6000 As frmMain.sRealTimeDataOfM6000, ByVal MeasMode As ucDispRcpIVLSweep.eMeasureItems, ByRef sSpectrumData() As Double) As String()
        Dim dLumi As Double
        Dim sDatas() As String = Nothing
        Dim cDataQE As CDataQECal = New CDataQECal
        Dim nTimeOutCnt As Integer = 0
        Dim dSampleArea As Double = SampleInfos.SampleSize.Height * SampleInfos.SampleSize.Width / 100

        Dim sMeasureDatas As frmMain.sCellLTMeasureParam = Nothing

        'sMeasureDatas.eletricalData(sMeasureDatasOfM6000.eachPixelMeasData.Length - 1)

        '  For i As Integer = 0 To sMeasureDatasOfM6000.eachPixelMeasData.Length - 1
        sMeasureDatas.eletricalData.dCurrent = sMeasureDatasOfM6000.eachPixelMeasData.dCurrent_Bias * 1000
        sMeasureDatas.eletricalData.dHighCurrent = sMeasureDatasOfM6000.eachPixelMeasData.dCurrent_Amplitude
        sMeasureDatas.eletricalData.dVoltage = sMeasureDatasOfM6000.eachPixelMeasData.dVoltage_Bias
        sMeasureDatas.eletricalData.dHighVoltage = sMeasureDatasOfM6000.eachPixelMeasData.dVoltage_Amplitude
        '  Next

        sMeasureDatas.dTotCurrent = sMeasureDatasOfM6000.dTotCurrent * 1000
        sMeasureDatas.dTotVoltage = sMeasureDatasOfM6000.dTotVoltage
        sMeasureDatas.dTotPDCurrent = sMeasureDatasOfM6000.dTotPDCurrent

        sMeasureDatas.dCurrentDensity = sMeasureDatas.dTotCurrent / (dSampleArea * SampleInfos.dFillFactor) * 100  ' (((SampleInfos.SampleSize.Height * SampleInfos.SampleSize.Width / 100) * SampleInfos.dFillFactor) / 100)

        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Step2. Measurement PR705(Multi-Point Measurement)   'LEX

        ReDim sDatas(sDataHeader.Length - 1)
        ' ReDim sMeasureDatas.opticalData(0) '.sPR705(0)

        sDatas(0) = nCnt
        sDatas(1) = MeasMode.ToString
        sDatas(2) = dSampleArea
        ' sDatas(3) = Format(sMeasureDatas.eletricalData.dVoltage, "0.000")

        'If m_SourceMode(nCh) = CDevM6000.eMode.eCC Or m_SourceMode(nCh) = CDevM6000.eMode.eCV Then
        '    sDatas(4) = ""
        '    sDatas(6) = ""
        'Else
        '    sDatas(4) = sMeasureDatas.dHighVoltage
        '    sDatas(6) = sMeasureDatas.dHighCurrent
        'End If

        sDatas(3) = Format(sMeasureDatas.eletricalData.dCurrent, "0.00000E-0")
        sDatas(4) = Format(sMeasureDatas.dCurrentDensity, "0.00000E-0")
        '  sDatas(6) = Math.Abs(sMeasureDatas.dCurrentDensity)

        If MeasMode = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
            Dim measData As CDevSpectrometerCommonNode.tData = Nothing
            Dim nWavelengthInterval As Integer = Nothing
            Dim cColorName As cDataColorName = New cDataColorName
            Dim nColor As cDataColorName.eColor

            If myParent.cSpectormeter(0).mySpectrometer.SetAperture(g_SystemOptions.sOptionData.Spectrometer.nAperture) = False Then
                ' myParent.g_StateMsgHandler.messageToUserErrorCode(idx, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "SetAperture")
                '예외처리
            End If

            If myParent.cQueueProcessor.MeasureSpectrometer(nCh, measData, g_SystemOptions.sOptionData.Spectrometer.nAperture, cbSpeedMode.SelectedIndex) = False Then
                myParent.g_StateMsgHandler.messageToUserErrorCode(nCh, CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "CalculateKeithleyOrM6000DataForM7000")
            End If

            dLumi = (measData.D6.s2YY * SampleInfos.dFillFactor) / 100
            sMeasureDatas.opticalData.dLumi_Cd_m2 = measData.D6.s2YY
            sMeasureDatas.opticalData.dLumi_Fill_Cd_m2 = dLumi
            '# Calculation cd/A
            '   sMeasureDatas.opticalData(0).dLumi_Cd_A = dLumi / (sMeasureDatas.dCurrentDensity * 10)

            '# Calculation lm/W
            '  sMeasureDatas.opticalData(0).dlmW = sMeasureDatas.opticalData(0).dLumi_Cd_A / sMeasureDatas.dTotVoltage * Math.PI

            '스펙트럼 간격별로 QE계산 함수 호출 할 수 있도록 변경 해야 함.
            If measData.D5.i3nm Is Nothing = False Then
                nWavelengthInterval = measData.D5.i3nm(1) - measData.D5.i3nm(0)
                sMeasureDatas.opticalData.dQE = cDataQE.QuantumEfficiency(dLumi, sMeasureDatas.dCurrentDensity, dSampleArea, _
                                                                                                     measData.D5.s4Intensity, nWavelengthInterval)
            Else
                sMeasureDatas.opticalData.dQE = 0
            End If

            sSpectrumData = measData.D5.s4Intensity.Clone

            sDatas(5) = measData.D6.s2YY
            sDatas(6) = dLumi 'dLumi_Cd_m2
            '  sDatas(7) = Format(sMeasureDatas.sEachMeasData(0).dLumi_Cd_A, "0.0000")
            '   sDatas(8) = Format(sMeasureDatas.sEachMeasData(0).dlmW, "0.0000")
            'sDatas(9) = Format(sMeasureDatas.sEachMeasData(0).dQE, "0.0000")
            sDatas(7) = measData.D6.s3xx
            sDatas(8) = measData.D6.s4yy
            sDatas(9) = measData.D6.s5uu
            sDatas(10) = measData.D6.s6vv
            sDatas(11) = measData.D4.s3KelvinT


            'For n As Integer = 0 To measData.D5.i3nm.Length - 1
            '    sDatas(n + 12) = measData.D5.s4Intensity(n)
            'Next


        Else
            sDatas(5) = ""
            sDatas(6) = ""
            sDatas(7) = ""
            sDatas(8) = ""
            sDatas(9) = ""
            sDatas(10) = ""
            sDatas(11) = ""
        End If


        Return sDatas.Clone
    End Function

#Region "SourceOnOff"

    Private Function SourceOnOffM6000(ByVal nCh As Integer, ByVal bSourceOnoff As Boolean) As Boolean
        Dim settings As CDevM6000PLUS.sSettingParams
        Dim nDevNoM6000 As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
        Dim nChNoM6000 As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfM6000)
        Dim sStartTime As Single
        Dim sDeltaTime As Single
        Dim m_dTimeOut As Double = 30

        settings.source.dBiasValue = CDbl(tbBias.Text)

        If bSourceOnoff = True Then
            With settings
                .bOutputState = CDevM6000PLUS.eONOFF.eON
                .source.dAmplitude = 0
                .source.Pulse.dDuty = 0
                .source.Pulse.dFrequency = 0
                If cbBiasMode.SelectedIndex = CDevM6000PLUS.eMode.eCC Then
                    .source.Mode = CDevM6000PLUS.eMode.eCC
                ElseIf cbBiasMode.SelectedIndex = CDevM6000PLUS.eMode.eCV Then
                    .source.Mode = CDevM6000PLUS.eMode.eCV
                End If

            End With

            If myParent.cM6000(nDevNoM6000).Request(nChNoM6000, CSeqRoutineM6000.eSequenceState.eSetSource, settings, Nothing) = True Then
            End If
            sStartTime = timer_Sec()

            Do
                Thread.Sleep(100)
                Application.DoEvents()
                '시간 Check
                sDeltaTime = timer_Sec() - sStartTime
                If sDeltaTime < 0 Then sDeltaTime = sDeltaTime + 3600
                If sDeltaTime > m_dTimeOut Then
                    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_ERROR_SEQ_PROCESS_TIMEOUT, "Lifetime Setting, Lifetime Measuring Timeout")
                    EventDisplayEnabled(True)
                    Exit Do
                End If
            Loop Until myParent.cM6000(nDevNoM6000).ChannelStatus(nChNoM6000) = CSeqRoutineM6000.eSequenceState.eMeasuring

        Else
            If myParent.cM6000(nDevNoM6000).Request(nChNoM6000, CSeqRoutineM6000.eSequenceState.eReset, settings, Nothing) = False Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Function FastSourceOnM6000(ByVal nCh As Integer) As Boolean
        Dim settings As CDevM6000PLUS.sSettingParams
        Dim nDevNoM6000 As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
        Dim nChNoM6000 As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfM6000)
        '   Dim sStartTime As Single
        '   Dim sDeltaTime As Single
        '   Dim m_dTimeOut As Double = 30

        Try
            settings.source.dBiasValue = CDbl(tbBias.Text)
        Catch ex As Exception
            Return False
        End Try


        With settings
            .bOutputState = CDevM6000PLUS.eONOFF.eON
            .source.dAmplitude = 0
            .source.Pulse.dDuty = 0
            .source.Pulse.dFrequency = 0
            If cbBiasMode.SelectedIndex = CDevM6000PLUS.eMode.eCC Then
                .source.Mode = CDevM6000PLUS.eMode.eCC
            ElseIf cbBiasMode.SelectedIndex = CDevM6000PLUS.eMode.eCV Then
                .source.Mode = CDevM6000PLUS.eMode.eCV
            End If
        End With

        If myParent.cM6000(nDevNoM6000).Request(nChNoM6000, CSeqRoutineM6000.eSequenceState.eFastSetSource, settings, Nothing) = False Then Return False

        'sStartTime = timer_Sec()
        'Do
        '    Thread.Sleep(100)
        '    Application.DoEvents()
        '    '시간 Check
        '    sDeltaTime = timer_Sec() - sStartTime
        '    If sDeltaTime < 0 Then sDeltaTime = sDeltaTime + 3600
        '    If sDeltaTime > m_dTimeOut Then
        '        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_ERROR_SEQ_PROCESS_TIMEOUT, "Lifetime Setting, Lifetime Measuring Timeout")
        '        EventDisplayEnabled(True)
        '        Exit Do
        '    End If
        'Loop Until myParent.cM6000(nDevNoM6000).ChannelStatus(nChNoM6000) = CSeqRoutineM6000.eSequenceState.eMeasuring

        Return True
    End Function

    Public Function SourceOnOffKeithley(ByVal nCh As Integer, ByVal bSourceOnoff As Boolean) As Boolean
        Dim nDevNoKeithley As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
        Dim nChNoKeithley As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSMU_IVL)
        Dim settings As ucKeithleySMUSettings.sKeithley = ucKeithleySMUSettings.Settings
        Dim dVoltage As Double = 0
        Dim dCurrent As Double = 0

        If bSourceOnoff = True Then
            Dim dBias As Double

            Try
                dBias = CDbl(tbBias.Text)
            Catch ex As Exception
                MsgBox(ex.ToString)
                Return False
            End Try

            If settings.SourceMode = CSMULib.ucKeithleySMUSettings.eSMUMode.eCurrent Then
                dBias = dBias / 1000
            End If

            'If m_KeithleySettings.bEnableSinkMode = settings.bEnableSinkMode Then

            'End If

            'Manual Mode에서 키슬리 Init을 매번 할 필요가 없음.... 초기에 한번 해주고 키슬리 Setting이 변경 될 때마다 하게 변경.

            m_KeithleySettings = settings
            If myParent.cIVLSMU(nDevNoKeithley).mySMU.InitializeSweep(settings) = False Then
                Return False
            End If

            If myParent.cIVLSMU(nDevNoKeithley).mySMU.SetBias(0) = False Then
                Return False
            End If

            If myParent.cIVLSMU(nDevNoKeithley).mySMU.OutputOn = False Then
                Return False
            End If


            If myParent.cIVLSMU(nDevNoKeithley).mySMU.SetBias(dBias) = False Then
                Return False
            End If

            If myParent.cIVLSMU(nDevNoKeithley).mySMU.Measure(dVoltage, dCurrent) = False Then Return False

        Else
            If myParent.cIVLSMU(nDevNoKeithley).mySMU.OutputOff = False Then
                Return False
            End If
            'If myParent.cIVLSMU(nDevNoKeithley).mySMU.FinalizeSweep() = False Then
            '    Return False
            'End If
        End If

        Return True
    End Function

    Private Function CheckKeithleySetting(ByVal settings As CSMULib.ucKeithleySMUSettings.sKeithley) As Boolean

        If m_KeithleySettings.LimitCurrent <> settings.LimitCurrent Then Return False
        If m_KeithleySettings.LimitVoltage <> settings.LimitVoltage Then Return False
        If m_KeithleySettings.IntegTime_Sec <> settings.IntegTime_Sec Then Return False
        If m_KeithleySettings.nIntegTimeIndex <> settings.nIntegTimeIndex Then Return False
        If m_KeithleySettings.MeasureDelay_Sec <> settings.MeasureDelay_Sec Then Return False
        If m_KeithleySettings.SourceDelay_Sec <> settings.SourceDelay_Sec Then Return False
        If m_KeithleySettings.MeasureMode <> settings.MeasureMode Then Return False
        If m_KeithleySettings.MeasureValueType <> settings.MeasureValueType Then Return False
        If m_KeithleySettings.nCurrentRangeIndex <> settings.nCurrentRangeIndex Then Return False
        If m_KeithleySettings.nVoltageRangeIndex <> settings.nVoltageRangeIndex Then Return False
        If m_KeithleySettings.WireMode <> settings.WireMode Then Return False
        If m_KeithleySettings.TerminalMode <> settings.TerminalMode Then Return False

        Return True
    End Function
    Public Function SourceOnOffSW7000(ByVal nCh As Integer, ByVal bSourceOnoff As Boolean) As Boolean
        Dim nDevNoSW7000 As Integer
        Dim nChNoSW7000 As Integer

        nDevNoSW7000 = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSwitch)
        nChNoSW7000 = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSwitch)

        If bSourceOnoff = True Then
            If myParent.cSwitch(nDevNoSW7000).mySwitch.SwitchON(nChNoSW7000) = False Then
                Return False
            End If
        Else
            For i As Integer = 0 To myParent.cSwitch.Length - 1
                For ch As Integer = 0 To g_nMaxCh - 1
                    If myParent.cSwitch(i).mySwitch.SwitchOFF(ch) = False Then
                        Return False
                    End If
                Next
            Next

        End If

        Return True
    End Function

    Private Function Experiment() As Boolean
        Dim nCnt As Integer
        Dim nDevM6000 As Integer

        For nCh As Integer = 0 To g_nMaxCh - 1

            ProgressBar1.Value = ((nCh) / g_nMaxCh) * 100

            nDevM6000 = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfM6000)

            If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
                If nDevM6000 > -1 Then
                    If SourceOnOffM6000(nCh, False) = False Then
                        Return False
                    End If
                End If

                'Keithley 한번만 해주면 됌...why? 전 채널에 공통으로 사용하기 때문에...만약 IVL Sweep중 Pause상태로 들어 갈때는 Sweep종료하고 들어가야 함.
                If nCnt = 0 Then
                    For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
                        If g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.eSMU_IVL Then
                            If SourceOnOffKeithley(nCh, False) = False Then
                                Return False
                            End If
                            Exit For
                        End If
                    Next

                    For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
                        If g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.eSwitch Then
                            If SourceOnOffSW7000(nCh, False) = False Then
                                Return False
                            End If
                        End If
                    Next

                End If
                nCnt += 1
            End If
            Application.DoEvents()
            Thread.Sleep(1)
        Next

        Return True
    End Function
#End Region

#End Region

    Private Function CheckChannelNumberToSelectSourcemeter(ByRef sMsg As String) As Boolean
        Dim nCh As Integer
        Dim nDevM6000 As Integer

        Try
            nCh = myParent.frmMotionUI.GetChannelComboBoxToSelectNumber 'cbChannel.SelectedIndex
        Catch ex As Exception
            sMsg = "Please Check the Channel Number..."
            Return False
        End Try

        nDevM6000 = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfM6000)

        If nDevM6000 <= -1 Then
            If rdoM6000.Checked = True Then
                sMsg = "Please Check the Select SMU..."
                Return False
            End If
        End If

        Return True
    End Function
    Private Sub btnSelectColorAllOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectColorAllOn.Click
        'Dim sErrorMessage As String = Nothing

        'If CheckChannelNumberToSelectSourcemeter(sErrorMessage) = False Then
        '    MsgBox(sErrorMessage)
        'End If

        'EventDisplayEnabled(False)

        'If SelectColorOnExperiment() = False Then
        '    MsgBox("Select Color All-On fail.....")
        '    EventDisplayEnabled(True)
        'End If

        'EventDisplayEnabled(True)

        'Dim nDevNoKeithley As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
        'Dim nChNoKeithley As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSMU_IVL)


        'test check
        For nCh As Integer = 0 To g_nMaxCh - 1
            If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
                MsgBox("Cannot use to Test")
                Exit Sub
            End If
        Next

        Dim dBias As Double

        Try
            dBias = CDbl(tbBias.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

        myParent.cSwitch(0).mySwitch.AllON()
        Dim settings As ucKeithleySMUSettings.sKeithley = ucKeithleySMUSettings.Settings
        If settings.SourceMode = CSMULib.ucKeithleySMUSettings.eSMUMode.eCurrent Then
            dBias = dBias / 1000
        End If

        If myParent.cIVLSMU(0).mySMU.InitializeSweep(settings) = False Then
            Exit Sub
        End If

        myParent.cIVLSMU(0).mySMU.SetBias(dBias)
        myParent.cIVLSMU(0).mySMU.OutputOn()
    End Sub

    Private Function SelectColorOnExperiment() As Boolean
        Dim nCnt As Integer
        Dim nDevM6000 As Integer

        For nCh As Integer = 0 To g_nMaxCh - 1

            ProgressBar2.Value = ((nCh) / g_nMaxCh) * 100

            nDevM6000 = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfM6000)

            If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then

                If nDevM6000 > -1 Then
                    If FastSourceOnM6000(nCh) = False Then
                        Return False
                    End If
                End If
            End If


            'Keithley 한번만 해주면 됌...why? 전 채널에 공통으로 사용하기 때문에...만약 IVL Sweep중 Pause상태로 들어 갈때는 Sweep종료하고 들어가야 함.
            If nCnt = 0 Then
                For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
                    If g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.eSMU_IVL Then
                        If SourceOnOffKeithley(nCh, False) = False Then
                            Return False
                        End If
                        Exit For
                    End If
                Next

                For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
                    If g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.eSwitch Then
                        If SourceOnOffSW7000(nCh, False) = False Then
                            Return False
                        End If
                    End If
                Next

            End If
            nCnt += 1

            Application.DoEvents()
            Thread.Sleep(1)
        Next

        Return True
    End Function


    Private Sub btnSetSpectrometer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetSpectrometer.Click
        Dim nAperture As Integer = cbAperture.SelectedIndex
        Dim nSpeedMode As Integer = cbSpeedMode.SelectedIndex
        Dim idx As Integer = myParent.frmMotionUI.GetChannelComboBoxToSelectNumber

        If myParent.cSpectormeter(0).mySpectrometer.Model = CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000 Then
            If nSpeedMode = 0 Then
                If MsgBox("Nomal Mode에서 측정 할 때 빛이 어두우면 Error가 발생 할 수 있습니다...그래도 진행 하시 겠습니까?", MsgBoxStyle.YesNo, "Care !") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        End If

        If myParent.cSpectormeter(0).mySpectrometer.SetAperture(nAperture) = False Then
            myParent.g_StateMsgHandler.messageToUserErrorCode(idx, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "SetAperture")
        End If

        'If myParent.cSpectormeter(0).mySpectrometer.SetMeasSpeed(nSpeedMode) = False Then
        '    myParent.g_StateMsgHandler.messageToUserErrorCode(idx, CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_SPECTRORADIOMTER_FUNC_ERROR, "SetSpeedMode")
        'End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '  Dim nCh As Integer = 1 'cbChannel.SelectedIndex
        Dim MeasMode As ucDispRcpIVLSweep.eMeasureItems = cbMeasMode.SelectedIndex
        Dim sData() As String = Nothing
        Dim MeasValOfM6000 As CDevM6000PLUS.sMeasParams = Nothing
        Dim SampleInfos As ucSampleInfos.sSampleInfos = Nothing
        Dim dAngleValue As Double = tbAngleValue.Text

        Dim sErrorMessage As String = Nothing


        m_Loop = False

        If myParent.cMotion.IsConnected = False Then
            MsgBox("Not Connected to Motion!!", MsgBoxStyle.Critical, "Care!!")
            Exit Sub
        End If


        Do
            For nCh As Integer = 0 To g_nMaxCh - 1

                If m_Loop = True Then
                    If SourceOnOffSW7000(nCh, False) = False Then
                        EventDisplayEnabled(True)
                        Exit Sub
                    End If
                    Exit For
                End If


                If CheckChannelNumberToSelectSourcemeter(sErrorMessage) = False Then
                    MsgBox(sErrorMessage)
                End If

                If rdoKeithley.Checked = True Then
                    If SourceOnOffSW7000(nCh, False) = False Then
                        EventDisplayEnabled(True)
                        Exit Sub
                    End If

                    If SourceOnOffSW7000(nCh, True) = False Then
                        EventDisplayEnabled(True)
                        Exit Sub
                    End If
                    If SourceOnOffKeithley(nCh, True) = False Then
                        EventDisplayEnabled(True)
                        Exit Sub
                    End If

                ElseIf rdoM6000.Checked = True Then
                    If SourceOnOffM6000(nCh, True) = False Then
                        EventDisplayEnabled(True)
                        Exit Sub
                    End If
                Else
                    MsgBox("Error(Not Selected.Keithley or M6000...)")
                    EventDisplayEnabled(True)
                    Exit Sub
                End If



                'Z축을 올리고 이동
                myParent.cMotion.ZMove(20, True)   'Z 축 상승
                'myParent.cMotion.ZMove(5000, True)
                'myParent.cMotion.MoveCompletedAllAxis()
                Application.DoEvents()
                Thread.Sleep(100)

                If myParent.frmMotionUI.Move_SetPos_XYAxisMovingFirst(nCh, frmMotionUI.eMotionMode.eSpectrometer, 0, 0) = False Then
                    MsgBox("Check the motion position data")
                End If

                If CheckChannelNumberToSelectSourcemeter(sErrorMessage) = False Then
                    MsgBox(sErrorMessage)
                End If


                Try
                    SampleInfos.dFillFactor = CDbl(tbFill.Text)
                    SampleInfos.SampleSize.Height = CDbl(tbSampleHeight.Text)
                    SampleInfos.SampleSize.Width = CDbl(tbSampleWidth.Text)
                Catch ex As Exception
                    SampleInfos.dFillFactor = 100
                    SampleInfos.SampleSize.Height = 2
                    SampleInfos.SampleSize.Width = 2
                End Try

                If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) <> CScheduler.eChSchedulerSTATE.eIdle Then
                    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Popup, CStateMsg.eStateMsg.eSYSTEM_MSG_Can_use_in_IDLE_STATUE, "")
                    EventDisplayEnabled(True)
                    Exit Sub
                End If


                Dim sMeasureDatas As frmMain.sRealTimeDataOfM6000 = Nothing

                sMeasureDatas.eachPixelMeasData = Nothing

                sMeasureDatas.eachPixelMeasData.dVoltage_Bias = 0
                sMeasureDatas.eachPixelMeasData.dVoltage_Amplitude = 0
                sMeasureDatas.eachPixelMeasData.dCurrent_Bias = 0
                sMeasureDatas.eachPixelMeasData.dCurrent_Amplitude = 0
                sMeasureDatas.eachPixelMeasData.dPDCurrent = 0

                '2. Data Read Keithley or M6000
                If rdoKeithley.Checked = True Then
                    Dim nDeviceNoOfSMU As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfSMU_IVL)
                    Dim nChOfSMUDevice As Integer = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eChOfSMU_IVL)
                    Dim dVoltage As Double
                    Dim dCurrent As Double

                    If myParent.cIVLSMU(nDeviceNoOfSMU).mySMU.Measure(dVoltage, dCurrent) = False Then
                    End If

                    sMeasureDatas.eachPixelMeasData.dVoltage_Bias = dVoltage
                    sMeasureDatas.eachPixelMeasData.dCurrent_Bias = dCurrent

                ElseIf rdoM6000.Checked = True Then
                    sMeasureDatas = myParent.cQueueProcessor.UpdateRealTimeData(nCh)
                    sMeasureDatas.eachPixelMeasData.dCurrent_Bias = sMeasureDatas.eachPixelMeasData.dCurrent_Bias / 1000
                End If

                sMeasureDatas.dTotCurrent = sMeasureDatas.eachPixelMeasData.dCurrent_Bias
                '3. Data Cal 
                Dim sSpectrumData() As Double = Nothing
                sData = CalculateKeithleyOrM6000DataForM7000(nCh, SampleInfos, sMeasureDatas, MeasMode, sSpectrumData)

                '4. Display
                ucMeasDataListview.AddRowData(sData)
                UcDispListView1.AddRowData(sSpectrumData)

                nCnt += 1

            Next
        Loop Until m_Loop = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        m_Loop = True
    End Sub

   
End Class
