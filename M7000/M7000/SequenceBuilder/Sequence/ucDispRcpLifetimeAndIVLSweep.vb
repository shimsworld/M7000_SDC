Imports CSMULib

Public Class ucDispRcpLifetimeAndIVLSweep

#Region "Define"

    'Common
    Dim m_bIsVisibleOnlyCell As Boolean = True
    Dim m_VisibleMode As ucSequenceBuilder.eRcpMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
    Dim m_sampleInfos As ucSampleInfos.sSampleInfos   'Target 샘플의 정보를 저장
    Dim m_IVLSweepInfos As ucSequenceBuilder.sRcpIVLSweep   'IVLSweep과 관련 된 정보를 저장

    Public Event evADDLifetimeAndIVLSweepRcp(ByVal LifetimeInfos As ucSequenceBuilder.sRcpLifetime, ByVal IVLInfos As ucSequenceBuilder.sRcpIVLSweep)
    Public Event evUpdateLifetimeAndIVLSweepRcp(ByVal LifetimeInfos As ucSequenceBuilder.sRcpLifetime, ByVal IVLInfos As ucSequenceBuilder.sRcpIVLSweep)

    'Lifetime
    Dim m_LifetimeInfos As ucSequenceBuilder.sRcpLifetime   'Lifetime과 관련 된 정보를 저장

    'IVL
    Public Shared m_sCaptions_BiasMode() As String = New String() {"CC", "CV"}
    Dim sMeasureMode() As String = New String() {"IV", "IVL"} 'IVLS PR시리즈 Spectrum Data 측정 시간 확인 필요. 차이가 있으면 IVLS 모드 추가 해야 함 _PSK
    Dim sSweepMode() As String = New String() {"Single", "Cycle"}
    Dim sSweepMethod() As String = New String() {"Stair", "Pulse", "Pulse_N_OffSet"}
    Dim sDelayState() As String = New String() {"OFF", "ON"}

    Dim m_InitKeithleySettings As ucKeithleySMUSettings.sKeithley

#End Region


#Region "Enums"
    'Lifetime
    Public Enum eLifeTimeMode
        Keeping
        Operation
    End Enum

    'IVL
    Public Enum eSweepType
        eStandard
        eUserPattern
    End Enum
    Public Enum eSweepMethod
        eStair
        ePulse
        ePulse_N_Offset
    End Enum
    Public Enum eMeasureItems
        eIV
        eIVL
        '    eIVLS
    End Enum
    Public Enum eBiasMode
        eCC
        eCV
    End Enum
    Public Enum eSweepMode
        eSingle
        eCycle
    End Enum
    Public Enum eOutputState
        eOFF
        eON
    End Enum
#End Region

#Region "Structure"
    'Lifetime
    Public Structure sLifetimeCommonInfos
        Dim nMode As eLifeTimeMode
        Dim sLifetimeEnd() As ucTestEndParam.sTestEndParam
        Dim sEndStateInfos As sEndState
        Dim sMeasureInterval() As ucMeasureIntervalSetting.sSetTime
        Dim sSetInfosTheRefPD As ucRefPDSetting.sLuminance
        Dim sMeasPoints As ucDispPointSetting.sMeasurePointInfos  '측정 포인트 정보
    End Structure

    Public Structure sEndState   'Lifetime이 종료될때의 상태 설정
        Dim bBiasOutput As Boolean  'Lifetime 종료시 Bias ON/OFF 설정용 , True = Output ON, False = Output Off
    End Structure

    'IVL
    Public Structure sIVLSweepCommonInfos
        Dim sMeasPoints As ucDispPointSetting.sMeasurePointInfos
        Dim sweepMethod As eSweepMethod
        Dim measItem As eMeasureItems
        Dim biasMode As eBiasMode
        Dim sweepMode As eSweepMode
        Dim sweepType As eSweepType
        Dim sMeasureSweepParameter() As ucMeasureSweepRegion.sSetSweepRegion
        Dim dSweepList() As Double
        Dim nColorList() As ucMeasureColorList.eColor
        Dim dOffsetBias As Double
        Dim dMeasureDelay As Double
        Dim dCycleDelay As Double
        Dim nAverage As Integer
        Dim dSweepDelay As Double
        Dim dLMeasLevel As Double
        Dim DelayState As eOutputState
        Dim dViewingAngle As Double
    End Structure
#End Region

    'Common
    Public WriteOnly Property SampleInfos As ucSampleInfos.sSampleInfos
        Set(ByVal value As ucSampleInfos.sSampleInfos)
            m_sampleInfos = value
        End Set
    End Property

    Public Property VisibleMode As ucSequenceBuilder.eRcpMode
        Get
            Return m_VisibleMode
        End Get
        Set(ByVal value As ucSequenceBuilder.eRcpMode)
            If m_VisibleMode <> value Then
                m_VisibleMode = value
                SelectSettingMode()
            End If
        End Set
    End Property

    'Lifetime


    Public Property LifetimeRecipe As ucSequenceBuilder.sRcpLifetime
        Get
            Get_Lifetime_ValueFromUI()
            Return m_LifetimeInfos
        End Get
        Set(ByVal value As ucSequenceBuilder.sRcpLifetime)
            m_LifetimeInfos = value
            Set_Lifetime_ValueToUI()
        End Set
    End Property


    Public WriteOnly Property VisibleOperationMode As Boolean
        Set(ByVal value As Boolean)
            gbStressMode.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleRefPDSetting As Boolean
        Set(ByVal value As Boolean)
            ucRefPDSetting.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleEndActionSetting As Boolean
        Set(ByVal value As Boolean)
            gbLifeTimeEndSourceSetting.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleSaveIntervalSetting As Boolean
        Set(ByVal value As Boolean)
            ucMeasureIntervalSetting.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleEndConditionSetting As Boolean
        Set(ByVal value As Boolean)
            ucTestEndParam.Visible = value
        End Set
    End Property

    'IVL
    Public Property IVLRecipe As ucSequenceBuilder.sRcpIVLSweep
        Get
            Get_IVL_ValueFromUI()
            Return m_IVLSweepInfos
        End Get
        Set(ByVal value As ucSequenceBuilder.sRcpIVLSweep)
            m_IVLSweepInfos = value
            Set_IVL_ValueToUI()
        End Set
    End Property

    Public WriteOnly Property VisibleDetailSettings As Boolean
        Set(ByVal value As Boolean)
            gbDetailSettings.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleBiasMode As Boolean
        Set(ByVal value As Boolean)
            lblBiasMode.Visible = value
            cbBiasMode.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleMeasMode As Boolean
        Set(ByVal value As Boolean)
            lblMeasMode.Visible = value
            cbMeasureMode.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleSweepType As Boolean
        Set(ByVal value As Boolean)
            ucSweepSetting.Label1.Visible = value
            ucSweepSetting.cbSelSweepType.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleLumiMeasLevel As Boolean
        Set(ByVal value As Boolean)
            lblLMeasLevel.Visible = value
            lblLMeasValueUnit.Visible = value
            tbLMeasLevel.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleLumiMeasLimit As Boolean
        Set(ByVal value As Boolean)
            lblLMeasLimit.Visible = value
            lblLMeasLimitUnit.Visible = value
            tbLMeasLimit.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleCurrentMeasLimit As Boolean
        Set(ByVal value As Boolean)
            lblCurrentLimit.Visible = value
            lblCurrentLimitUnit.Visible = value
            tbCurrentLimit.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleSweepRegionSettings As Boolean
        Set(ByVal value As Boolean)
            ucSweepSetting.ucUserPatternList.Visible = value
            ucSweepSetting.ucSweepRegion.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleViewingAngleSettings As Boolean
        Set(ByVal value As Boolean)
            lblViewingAngle.Visible = value
            tbViewingAngle.Visible = value
            lblViewingAngleUnit.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleucColorSettings As Boolean
        Set(ByVal value As Boolean)
            ucColorSetting.Visible = value
        End Set
    End Property


#Region "Creator"


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()


        spContainer.Location = New System.Drawing.Point(0, 0)
        spContainer.Dock = DockStyle.Fill

        gbLifetimeAndIVLSweepCommon.Location = New System.Drawing.Point(0, 0)
        gbLifetimeAndIVLSweepCommon.Dock = DockStyle.Fill


        tlpPanel2.Location = New System.Drawing.Point(0, 0)
        tlpPanel2.Dock = DockStyle.Fill

        Panel1.Location = New System.Drawing.Point(0, 0)
        Panel1.Dock = DockStyle.Fill

        gbComponent.Location = New System.Drawing.Point(0, 0)
        gbComponent.Dock = DockStyle.Fill

        SplitContainer2.Location = New System.Drawing.Point(0, 0)
        SplitContainer2.Dock = DockStyle.Fill

        TabControl1.Location = New System.Drawing.Point(0, 0)
        TabControl1.Dock = DockStyle.Fill

        tbIVL_Standard.Location = New System.Drawing.Point(0, 0)
        tbIVL_Standard.Dock = DockStyle.Fill

        tcCommon.Location = New System.Drawing.Point(0, 0)
        tcCommon.Dock = DockStyle.Fill

        ucSweepSetting.Dock = DockStyle.Fill


        ucTestIVLMeasParam.Location = New System.Drawing.Point(ucTestEndParam.Location.X + ucTestEndParam.Size.Width + 4, ucTestEndParam.Location.Y)

        ucDispKeithley.Location = New System.Drawing.Point(0, 0)
        ucDispKeithley.Dock = DockStyle.Fill

        btnADD.Location = New System.Drawing.Point(0, 0)
        btnADD.Dock = DockStyle.Fill
        btnUpdate.Location = New System.Drawing.Point(0, 0)
        btnUpdate.Dock = DockStyle.Fill
        btnEdit.Location = New System.Drawing.Point(0, 0)
        btnEdit.Dock = DockStyle.Fill
        btnMeasPoint.Location = New System.Drawing.Point(0, 0)
        btnMeasPoint.Dock = DockStyle.Fill

        btnEdit.Enabled = False
        btnMeasPoint.Enabled = False


        tbCycleDelay.Text = 0
        tbLMeasLevel.Text = 0
        tbOffsetBias.Text = 0
        tbMeasureDelay.Text = 0
        tbAverage.Text = 1
        tbSweepDelay.Text = 0
        tbCurrentLimit.Text = 0
        tbLMeasLimit.Text = 0

        With cbBiasMode
            .Items.Clear()
            For i As Integer = 0 To m_sCaptions_BiasMode.Length - 1
                .Items.Add(m_sCaptions_BiasMode(i))
            Next
            .SelectedIndex = 1
        End With

        With cbMeasureMode
            .Items.Clear()
            For i As Integer = 0 To sMeasureMode.Length - 1
                .Items.Add(sMeasureMode(i))
            Next
            .SelectedIndex = 0
        End With

        With cbSweepMode
            .Items.Clear()
            For i As Integer = 0 To sSweepMode.Length - 1
                .Items.Add(sSweepMode(i))
            Next
            .SelectedIndex = 0
        End With

        With cbSweepMethod
            .Items.Clear()
            For i As Integer = 0 To sSweepMethod.Length - 1
                .Items.Add(sSweepMethod(i))
            Next
            .SelectedIndex = 0
        End With

        With cbDelayState
            .Items.Clear()
            For i As Integer = 0 To sDelayState.Length - 1
                .Items.Add(sDelayState(i))
            Next
            .SelectedIndex = 0
        End With


        ucDispKeithley.rbCC.Enabled = False
        ucDispKeithley.rbCV.Enabled = False

        ucDispKeithley.DisplayMode = g_ConfigInfos.SMUForIVLConfig(0).device

        If g_ConfigInfos.SMUForIVLConfig(0).sRangeList.dCurrentListValue Is Nothing = False Then
            ucDispKeithley.ControlUI = g_ConfigInfos.SMUForIVLConfig(0).sRangeList
        End If


        Select Case g_ConfigInfos.SMUForIVLConfig(0).device
            Case CDevSMUCommonNode.eModel.KEITHLEY_K236 To CDevSMUCommonNode.eModel.kEITHLEY_K238
                m_InitKeithleySettings = ucDispKeithley.Settings
                m_InitKeithleySettings.nIntegTimeIndex = 2
                ucDispKeithley.Settings = m_InitKeithleySettings
        End Select

        ReDim m_LifetimeInfos.sCellInfos(0)
    End Sub



#End Region

#Region "Functions"
    Private Sub SelectSettingMode()

        Select Case m_VisibleMode

            Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                btnEdit.Enabled = False
                btnMeasPoint.Enabled = False
                ucDispKeithley.Visible = True
            Case Else
                MsgBox("This parameter is not available.")
                m_VisibleMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL

        End Select

    End Sub


    Private Sub Get_Lifetime_ValueFromUI()
        m_LifetimeInfos.nMyMode = m_VisibleMode

        If rbNoStress.Checked = True Then
            m_LifetimeInfos.sCommon.nMode = eLifeTimeMode.Keeping
        Else
            m_LifetimeInfos.sCommon.nMode = eLifeTimeMode.Operation
        End If

        If rbLifeTimeEndBiasON.Checked = True Then
            m_LifetimeInfos.sCommon.sEndStateInfos.bBiasOutput = True
        Else
            m_LifetimeInfos.sCommon.sEndStateInfos.bBiasOutput = False
        End If

        m_LifetimeInfos.sCommon.sSetInfosTheRefPD = ucRefPDSetting.Setting
        m_LifetimeInfos.sCommon.sMeasureInterval = ucMeasureIntervalSetting.Setting
        m_LifetimeInfos.sCommon.sLifetimeEnd = ucTestEndParam.Settings
        m_LifetimeInfos.sCommon.sIVLSweepMeas = ucTestIVLMeasParam.Settings
        m_LifetimeInfos.sCellInfos(0) = ucDispM6000.Settings
        m_LifetimeInfos.sCellInfos(0).bEnable = True

    End Sub

    Public Sub Set_Lifetime_ValueToUI()
        m_VisibleMode = m_LifetimeInfos.nMyMode

        Select Case m_LifetimeInfos.sCommon.nMode

            Case eLifeTimeMode.Keeping
                rbNoStress.Checked = True
            Case eLifeTimeMode.Operation
                rbStress.Checked = True
        End Select

        If m_LifetimeInfos.sCommon.sEndStateInfos.bBiasOutput = True Then
            rbLifeTimeEndBiasON.Checked = True
        Else
            rbLifeTimeEndBiasOFF.Checked = True
        End If

        ucRefPDSetting.Setting = m_LifetimeInfos.sCommon.sSetInfosTheRefPD
        ucMeasureIntervalSetting.Setting = m_LifetimeInfos.sCommon.sMeasureInterval
        ucTestEndParam.Settings = m_LifetimeInfos.sCommon.sLifetimeEnd
        ucTestIVLMeasParam.Settings = m_LifetimeInfos.sCommon.sIVLSweepMeas
        ucDispM6000.Settings = m_LifetimeInfos.sCellInfos(0)

    End Sub


    Private Function Get_IVL_ValueFromUI() As Boolean
        m_IVLSweepInfos.nMyMode = m_VisibleMode

        With m_IVLSweepInfos.sCommon
            '이재하
            .measItem = cbMeasureMode.SelectedIndex
            .biasMode = cbBiasMode.SelectedIndex
            .DelayState = cbDelayState.SelectedIndex
            .sweepMethod = cbSweepMethod.SelectedIndex
            .sweepMode = cbSweepMode.SelectedIndex
            .bFirstSweep = chkFirstIVLSweep.Checked

            Try
                .dCycleDelay = CDbl(tbCycleDelay.Text)
                If .biasMode = eBiasMode.eCC Then
                    .dLMeasLevel = CDbl(tbLMeasLevel.Text) / 1000
                Else  'cv
                    .dLMeasLevel = CDbl(tbLMeasLevel.Text)
                End If

                .dLMeasLimit = CDbl(tbLMeasLimit.Text)
                .dCurrentLimit = CDbl(tbCurrentLimit.Text)

                .dOffsetBias = CDbl(tbOffsetBias.Text)
                .dMeasureDelay = CDbl(tbMeasureDelay.Text)
                .nAverage = CDbl(tbAverage.Text)
                .dSweepDelay = CDbl(tbSweepDelay.Text)
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
                Return False
            End Try

            m_IVLSweepInfos.sCommon.sweepType = ucSweepSetting.SweepType
            Select Case m_IVLSweepInfos.sCommon.sweepType
                Case ucDispRcpIVLSweep.eSweepType.eStandard
                    m_IVLSweepInfos.sCommon.sMeasureSweepParameter = ucSweepSetting.ucSweepRegion.Setting
                    m_IVLSweepInfos.sCommon.dSweepList = CSeqProcessor.MakeSweepList(m_IVLSweepInfos.sCommon.sMeasureSweepParameter)
                Case ucDispRcpIVLSweep.eSweepType.eUserPattern
                    m_IVLSweepInfos.sCommon.dSweepList = ucSweepSetting.ucUserPatternList.Setting
            End Select


            'Add 20150319
            .nColorList = ucColorSetting.Setting

            If .sweepMode = eSweepMode.eCycle Then
                Dim dArrBuf(.dSweepList.Length - 1) As Double

                ReDim Preserve .dSweepList(.dSweepList.Length + dArrBuf.Length - 1)

                For i As Integer = dArrBuf.Length To .dSweepList.Length - 1
                    .dSweepList(i) = .dSweepList(.dSweepList.Length - i - 1)
                Next
            End If


            'UI Device 정보를 전부 다 넘겨 줌  Lifetime은 Mode별로 넘겨 줌. 전부 넘겨주고 필요한 것만 쓰면 됨. _PSK
            m_IVLSweepInfos.sKeithleyInfos = ucDispKeithley.Settings

            'Add 20150217
            Try
                m_IVLSweepInfos.sCommon.dViewingAngle = CDbl(tbViewingAngle.Text)
            Catch ex As Exception
                MsgBox(ex.ToString)
                Return False
            End Try

        End With

        Return True
    End Function

    Public Sub Set_IVL_ValueToUI()
        m_VisibleMode = m_IVLSweepInfos.nMyMode

        With m_IVLSweepInfos.sCommon

            cbMeasureMode.SelectedIndex = .measItem
            cbBiasMode.SelectedIndex = .biasMode
            cbDelayState.SelectedIndex = .DelayState
            cbSweepMethod.SelectedIndex = .sweepMethod
            cbSweepMode.SelectedIndex = .sweepMode
            ucSweepSetting.SweepType = .sweepType
            chkFirstIVLSweep.Checked = .bFirstSweep

            tbCycleDelay.Text = .dCycleDelay
            If .biasMode = eBiasMode.eCC Then
                tbLMeasLevel.Text = .dLMeasLevel * 1000
            Else   'cv
                tbLMeasLevel.Text = .dLMeasLevel
            End If

            tbLMeasLimit.Text = .dLMeasLimit
            tbCurrentLimit.Text = .dCurrentLimit
            tbOffsetBias.Text = .dOffsetBias
            tbMeasureDelay.Text = .dMeasureDelay
            tbAverage.Text = .nAverage
            tbSweepDelay.Text = .dSweepDelay

            ucSweepSetting.SweepType = m_IVLSweepInfos.sCommon.sweepType
            Select Case m_IVLSweepInfos.sCommon.sweepType
                Case ucDispRcpIVLSweep.eSweepType.eStandard
                    ucSweepSetting.ucSweepRegion.Setting = m_IVLSweepInfos.sCommon.sMeasureSweepParameter
                Case ucDispRcpIVLSweep.eSweepType.eUserPattern
                    ucSweepSetting.ucUserPatternList.Setting = m_IVLSweepInfos.sCommon.dSweepList
            End Select

            'Add 20150319
            ucColorSetting.Setting = .nColorList
        End With

        ucDispKeithley.Settings = m_IVLSweepInfos.sKeithleyInfos

        'Add 20150217
        tbViewingAngle.Text = CStr(m_IVLSweepInfos.sCommon.dViewingAngle)

    End Sub
#End Region

#Region "Change Event"

    'Lifetime
    Private Sub rbNoStress_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNoStress.CheckedChanged, rbStress.CheckedChanged
        If rbNoStress.Checked = True Then
            m_LifetimeInfos.sCommon.nMode = eLifeTimeMode.Keeping
            ucDispM6000.Enabled = False

            rbLifeTimeEndBiasOFF.Checked = True

        ElseIf rbStress.Checked = True Then
            m_LifetimeInfos.sCommon.nMode = eLifeTimeMode.Operation

            ucDispM6000.Enabled = True
        End If
    End Sub

    'IVL
    Private Sub cbBiasMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cbBiasMode.SelectedIndex = eBiasMode.eCV Then
            lblOffsetBiasValueUnit.Text = "V"
            lblLMeasValueUnit.Text = "V"
            ucSweepSetting.ucUserPatternList.UnitType = ucSweepSetting.eUnitType._Voltage
            ucSweepSetting.ucSweepRegion.UnitType = ucSweepSetting.eUnitType._Voltage
            ucDispKeithley.rbCV.Checked = True
        ElseIf cbBiasMode.SelectedIndex = eBiasMode.eCC Then
            lblOffsetBiasValueUnit.Text = "mA"
            lblLMeasValueUnit.Text = "mA"
            ucSweepSetting.ucUserPatternList.UnitType = ucSweepSetting.eUnitType._milliAmpere
            ucSweepSetting.ucSweepRegion.UnitType = ucSweepSetting.eUnitType._milliAmpere
            ucDispKeithley.rbCC.Checked = True
        End If
    End Sub

    Private Sub cbSweepMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSweepMethod.SelectedIndexChanged
        If cbSweepMethod.SelectedIndex = eSweepMethod.eStair Then
            tbOffsetBias.Enabled = False
        ElseIf cbSweepMethod.SelectedIndex = eSweepMethod.ePulse Then
            tbOffsetBias.Enabled = False
        ElseIf cbSweepMethod.SelectedIndex = eSweepMethod.ePulse_N_Offset Then
            tbOffsetBias.Enabled = True
        End If
    End Sub

    Private Sub cbSweepMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSweepMode.SelectedIndexChanged
        If cbSweepMode.SelectedIndex = eSweepMode.eSingle Then
            tbCycleDelay.Enabled = False
        ElseIf cbSweepMode.SelectedIndex = eSweepMode.eCycle Then
            tbCycleDelay.Enabled = True
        End If
    End Sub

    Private Sub cbMeasureMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cbMeasureMode.SelectedIndex = eMeasureItems.eIV Then
            tbLMeasLevel.Enabled = False
        ElseIf cbMeasureMode.SelectedIndex = eMeasureItems.eIVL Then
            tbLMeasLevel.Enabled = True
        End If
    End Sub

    Private Sub tbAverage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbAverage.TextChanged
        Dim nAverage As Integer = CInt(tbAverage.Text)

        If nAverage > 1 Then
            tbSweepDelay.Enabled = True
        Else
            tbSweepDelay.Enabled = False
        End If
    End Sub

    Private Sub ChangedSweepType(ByVal type As ucSweepSetting.eSweepType) Handles ucSweepSetting.ChangedSweepType

        m_IVLSweepInfos.sCommon.sweepType = type

        Select Case type
            Case M7000.ucSweepSetting.eSweepType._Standard
                cbSweepMode.Enabled = True
                tbCycleDelay.Enabled = True
            Case M7000.ucSweepSetting.eSweepType._UserPattern
                cbSweepMode.Enabled = False
                tbCycleDelay.Enabled = False
        End Select

    End Sub

    Private Sub cbMeasureMode_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMeasureMode.SelectedIndexChanged
        If cbMeasureMode.SelectedIndex = 0 Then
            tbLMeasLevel.Enabled = False
        Else
            tbLMeasLevel.Enabled = True
        End If
    End Sub
#End Region

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click
        Get_Lifetime_ValueFromUI()
        If Get_IVL_ValueFromUI() = False Then
            MsgBox("Check the Settings")
            Exit Sub
        End If

        RaiseEvent evADDLifetimeAndIVLSweepRcp(m_LifetimeInfos, m_IVLSweepInfos)
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Get_Lifetime_ValueFromUI()
        If Get_IVL_ValueFromUI() = False Then
            MsgBox("Check the Settings")
            Exit Sub
        End If
        RaiseEvent evUpdateLifetimeAndIVLSweepRcp(m_LifetimeInfos, m_IVLSweepInfos)
    End Sub


    Public Shared Function ConvertStrLifetimeModeToInt(ByVal str As String) As eLifeTimeMode
        Select Case str
            Case eLifeTimeMode.Keeping.ToString
                Return eLifeTimeMode.Keeping
            Case eLifeTimeMode.Operation.ToString
                Return eLifeTimeMode.Operation
            Case Else
                Return -1
        End Select
    End Function

End Class
