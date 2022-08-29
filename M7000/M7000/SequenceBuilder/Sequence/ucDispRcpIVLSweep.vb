Imports CSMULib

Public Class ucDispRcpIVLSweep


#Region "Define"


    Dim m_bIsVisibleOnlyCell As Boolean = True
    Dim m_VisibleMode As ucSequenceBuilder.eRcpMode = ucSequenceBuilder.eRcpMode.eCell_IVL

    Dim m_sampleInfos As ucSampleInfos.sSampleInfos   'Target 샘플의 정보를 저장
    Dim m_IVLSweepInfos As ucSequenceBuilder.sRcpIVLSweep   'IVLSweep과 관련 된 정보를 저장

    Public Shared m_sCaptions_BiasMode() As String = New String() {"CC", "CV"}
    Public Shared m_sCaptions_NormalFastMode() As String = New String() {"Normal", "Fast"}
    Dim sMeasureMode() As String = New String() {"IV", "IVL"} 'IVLS PR시리즈 Spectrum Data 측정 시간 확인 필요. 차이가 있으면 IVLS 모드 추가 해야 함 _PSK
    Dim sSweepMode() As String = New String() {"Single", "Cycle"}
    Dim sSweepMethod() As String = New String() {"Stair", "Pulse", "Pulse_N_OffSet"}
    Dim sDelayState() As String = New String() {"OFF", "ON"}

    Dim sSweepLine() As String = New String() {"ELVDD", "ELVSS", "Red", "Green", "Blue", "White"}
    Public Event evADDIVLSweepRcp(ByVal infos As ucSequenceBuilder.sRcpIVLSweep)
    Public Event evUpdateIVLSweepRcp(ByVal infos As ucSequenceBuilder.sRcpIVLSweep)

    Dim m_InitKeithleySettings As ucKeithleySMUSettings.sKeithley

#End Region

#Region "Enum"

    Public Enum eSweepType
        eStandard
        eUserPattern
        eRGBPattern '220826 Update by JKY
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

    Public Enum eSweepLine
        eELVDD
        eELVSS
        eRed
        eGreen
        eBlue
        eWhite
    End Enum

    Public Enum eDetectorMode
        eNormal
        eFast
    End Enum

#End Region

#Region "Structure"

    Public Structure sIVLSweepCommonInfos
        Dim sMeasPoints As ucDispPointSetting.sMeasurePointInfos
        Dim sweepMethod As eSweepMethod
        Dim measItem As eMeasureItems
        Dim biasMode As eBiasMode
        Dim sweepMode As eSweepMode
        Dim sweepType As eSweepType
        Dim sweepLine As eSweepLine
        Dim sMeasureSweepParameter() As ucMeasureSweepRegion.sSetSweepRegion
        Dim sMeasureRGBSweepParameter() As ucMeasureRGBSweepRegion.sSetSweepRegion '220826 Update by JKY
        ' Dim sMeasureUserSweepList() As Double
        Dim dSweepList() As Double
        Dim nColorList() As ucMeasureColorList.eColor
        Dim dOffsetBias As Double
        Dim dMeasureDelay As Double
        Dim dCycleDelay As Double
        Dim nAverage As Integer
        Dim dSweepDelay As Double
        Dim dLMeasLevel As Double
        Dim fastBiasMode As eBiasMode
        Dim ValueforFast As Double
        Dim DetectorMode As eDetectorMode
        Dim DelayState As eOutputState
        Dim dViewingAngle As Double
        Dim bFirstSweep As Boolean
        Dim dLMeasLimit As Double
        Dim dCurrentLimit As Double
        Dim dLumiCorrection As Double
        Dim dBiasInvert As Boolean
        Dim LimitCompareAnd As Boolean
    End Structure

#End Region

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

        tlpPanel2.Location = New System.Drawing.Point(0, 0)
        tlpPanel2.Dock = DockStyle.Fill

        Panel1.Location = New System.Drawing.Point(0, 0)
        Panel1.Dock = DockStyle.Fill

        SplitContainer1.Location = New System.Drawing.Point(0, 0)
        SplitContainer1.Dock = DockStyle.Fill


        gbIVLSweepCommon.Location = New System.Drawing.Point(0, 0)
        gbIVLSweepCommon.Dock = DockStyle.Fill

        'gbSettings.Location = New System.Drawing.Point(0, 0)
        'gbSettings.Dock = DockStyle.Fill


        tcCommon.Location = New System.Drawing.Point(0, 0)
        tcCommon.Dock = DockStyle.Fill

        SplitContainer2.Location = New System.Drawing.Point(0, 0)
        SplitContainer2.Dock = DockStyle.Fill

        '  SplitContainer1.Location = New System.Drawing.Point(0, 0)
        '  SplitContainer1.Dock = DockStyle.Fill
        ucSweepSetting.Dock = DockStyle.Fill

        'ucDispSignalGenerator.Location = New System.Drawing.Point(0, 0)
        'ucDispSignalGenerator.Dock = DockStyle.Fill

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

        tbCycleDelay.Text = 0
        tbLMeasLevel.Text = 0
        tbOffsetBias.Text = 0
        tbMeasureDelay.Text = 0
        tbAverage.Text = 1
        tbSweepDelay.Text = 0
        tbLMeasLimit.Text = 0
        tbCurrentLimit.Text = 0
        tbLumiCorrection.Text = 0

        tbValueForFast.Text = 0


        ucDispKeithley.DisplayMode = g_ConfigInfos.SMUForIVLConfig(0).device
        If g_ConfigInfos.SMUForIVLConfig(0).sRangeList.dCurrentListValue Is Nothing = False Then
            ucDispKeithley.ControlUI = g_ConfigInfos.SMUForIVLConfig(0).sRangeList
        End If

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

        'With cbSweepType
        '    .Items.Clear()
        '    For i As Integer = 0 To m_sCaptions_SweepType.Length - 1
        '        .Items.Add(m_sCaptions_SweepType(i))
        '    Next
        '    .SelectedIndex = 0
        'End With

        With cbSweepLine
            .Items.Clear()
            For i As Integer = 0 To sSweepLine.Length - 1
                .Items.Add(sSweepLine(i))
            Next
            .SelectedIndex = 0
        End With

        With cbNormalFastSelect
            .Items.Clear()

            For i As Integer = 0 To m_sCaptions_NormalFastMode.Length - 1
                .Items.Add(m_sCaptions_NormalFastMode(i))
            Next
            .SelectedIndex = 0
        End With


        With cbFastBiasMode
            .Items.Clear()
            For i As Integer = 0 To m_sCaptions_BiasMode.Length - 1
                .Items.Add(m_sCaptions_BiasMode(i))
            Next
            .SelectedIndex = 0
        End With

        Select Case g_ConfigInfos.SMUForIVLConfig(0).device
            Case CDevSMUCommonNode.eModel.KEITHLEY_K236 To CDevSMUCommonNode.eModel.kEITHLEY_K238
                m_InitKeithleySettings = ucDispKeithley.Settings
                m_InitKeithleySettings.nIntegTimeIndex = 2
                ucDispKeithley.Settings = m_InitKeithleySettings
        End Select

    End Sub



#End Region

#Region "Properties"

    Public Property VisibleMode As ucSequenceBuilder.eRcpMode
        Get
            Return m_VisibleMode
        End Get
        Set(ByVal value As ucSequenceBuilder.eRcpMode)
            m_VisibleMode = value
            SelectSettingMode()
        End Set
    End Property

    Public Property IVLRecipe As ucSequenceBuilder.sRcpIVLSweep
        Get
            GetValueFromUI()
            Return m_IVLSweepInfos
        End Get
        Set(ByVal value As ucSequenceBuilder.sRcpIVLSweep)
            m_IVLSweepInfos = value
            SetValueToUI()
        End Set
    End Property

    Public WriteOnly Property SampleInfos As ucSampleInfos.sSampleInfos
        Set(ByVal value As ucSampleInfos.sSampleInfos)
            m_sampleInfos = value
        End Set
    End Property

    Public Property IsVisibleOnlyCell As Boolean
        Get
            Return m_bIsVisibleOnlyCell
        End Get
        Set(ByVal value As Boolean)
            m_bIsVisibleOnlyCell = value
            If m_bIsVisibleOnlyCell = False Then
                SplitContainer1.Panel1.Show()
            Else
                SplitContainer1.Panel1.Hide()
            End If

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

    Public WriteOnly Property VisibleLumiCorrection As Boolean
        Set(ByVal value As Boolean)
            lblLumiCorrection.Visible = value
            lblLumiCorrectionUnit.Visible = value
            tbLumiCorrection.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleSweepRegionSettings As Boolean
        Set(ByVal value As Boolean)
            ucSweepSetting.ucUserPatternList.Visible = value
            ucSweepSetting.ucSweepRegion.Visible = value
            ucSweepSetting.ucRGBSweepRegion.Visible = value
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

#End Region



#Region "Functions"

    Private Sub SelectSettingMode()
        Select Case m_VisibleMode

            Case ucSequenceBuilder.eRcpMode.eCell_IVL
                ucDispKeithley.Visible = False '220829 Update by JKY
                'ucDispSignalGenerator.Visible = False

                IsVisibleOnlyCell = True
                btnEdit.Enabled = False
                btnMeasPoint.Enabled = True
            Case ucSequenceBuilder.eRcpMode.ePanel_IVL
                btnMeasPoint.Enabled = True
                For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
                    If g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.eSMU_IVL Then
                        ucDispKeithley.Visible = True
                        'ucDispSignalGenerator.Visible = False
                        btnEdit.Enabled = False
                        ucDispRGBSignal.Visible = True
                    ElseIf g_ConfigInfos.nDevice(i) = frmConfigSystem.eDeviceItem.eMcSG Then
                        ucDispKeithley.Visible = False
                        'ucDispSignalGenerator.Visible = True
                        btnEdit.Enabled = True
                        ucDispRGBSignal.Visible = False
                    End If
                Next

                IsVisibleOnlyCell = False
            Case Else
                MsgBox("This parameter is not available.")
                '  m_VisibleMode = ucSequenceBuilder.eRcpMode.eCell_Lifetime
                '  ucDispPanel.Visible = False
                '  ucDispModule.Visible = False
                ' ucDispCell.Visible = True
        End Select
    End Sub


    Private Function GetValueFromUI() As Boolean


        m_IVLSweepInfos.nMyMode = m_VisibleMode

        With m_IVLSweepInfos.sCommon
            '이재하
            .measItem = cbMeasureMode.SelectedIndex
            .biasMode = cbBiasMode.SelectedIndex
            .DelayState = cbDelayState.SelectedIndex
            .sweepMethod = cbSweepMethod.SelectedIndex
            .sweepMode = cbSweepMode.SelectedIndex
            ' .sweepType = ucSweepSetting.SweepType
            .sweepLine = cbSweepLine.SelectedIndex

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
                .dLumiCorrection = CDbl(tbLumiCorrection.Text)
                .dBiasInvert = CBool(chkBiasInvert.Checked)
                .ValueforFast = CDbl(tbValueForFast.Text)
                .fastBiasMode = cbFastBiasMode.SelectedIndex
                .DetectorMode = cbNormalFastSelect.SelectedIndex
                .LimitCompareAnd = CBool(ChkAnd.Checked)
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
                Return False
            End Try

            '.sMeasureSweepParameter = ucSweepSetting.ucSweepRegion.Setting

            m_IVLSweepInfos.sCommon.sweepType = ucSweepSetting.SweepType
            Select Case m_IVLSweepInfos.sCommon.sweepType
                Case ucDispRcpIVLSweep.eSweepType.eStandard
                    m_IVLSweepInfos.sCommon.sMeasureSweepParameter = ucSweepSetting.ucSweepRegion.Setting
                    m_IVLSweepInfos.sCommon.dSweepList = CSeqProcessor.MakeSweepList(m_IVLSweepInfos.sCommon.sMeasureSweepParameter)
                Case ucDispRcpIVLSweep.eSweepType.eUserPattern
                    m_IVLSweepInfos.sCommon.dSweepList = ucSweepSetting.ucUserPatternList.Setting
                Case ucDispRcpIVLSweep.eSweepType.eRGBPattern '220826 Update by JKY
                    m_IVLSweepInfos.sCommon.sMeasureRGBSweepParameter = ucSweepSetting.ucRGBSweepRegion.Setting
                    m_IVLSweepInfos.sCommon.dSweepList = CSeqProcessor.MakeRGBSweepList(m_IVLSweepInfos.sCommon.sMeasureRGBSweepParameter)
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

            'If .sweepType = eSweepType.eStandard Then
            '    .dSweepList = CSeqProcessor.MakeSweepList(m_IVLSweepInfos.sCommon) 'ucMeasurementSweepSetting.SweepList
            'Else
            '    .dSweepList = ucSweepSetting.ucUserPatternList.Setting
            'End If

            'If .dSweepList Is Nothing Then Return False

            'UI Device 정보를 전부 다 넘겨 줌  Lifetime은 Mode별로 넘겨 줌. 전부 넘겨주고 필요한 것만 쓰면 됨. _PSK
            m_IVLSweepInfos.sKeithleyInfos = ucDispKeithley.Settings
            m_IVLSweepInfos.sRGBSignalInfos = ucDispRGBSignal.Setting
            'm_IVLSweepInfos.sSignalGeneratorInfos = ucDispSignalGenerator.Settings
            ' .sMeasPoints()? _PSK


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

    Public Sub SetValueToUI()
        m_VisibleMode = m_IVLSweepInfos.nMyMode

        With m_IVLSweepInfos.sCommon

            cbMeasureMode.SelectedIndex = .measItem
            cbBiasMode.SelectedIndex = .biasMode
            cbDelayState.SelectedIndex = .DelayState
            cbSweepMethod.SelectedIndex = .sweepMethod
            cbSweepMode.SelectedIndex = .sweepMode
            ucSweepSetting.SweepType = .sweepType
            cbSweepLine.SelectedIndex = .sweepLine

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
            chkBiasInvert.Checked = .dBiasInvert
            tbLumiCorrection.Text = .dLumiCorrection
            tbValueForFast.Text = .ValueforFast
            cbNormalFastSelect.SelectedIndex = .DetectorMode
            cbFastBiasMode.SelectedIndex = .fastBiasMode
            ChkAnd.Checked = .LimitCompareAnd
            'If .sweepType = eSweepType.eStandard Then
            '    ucSweepSetting.ucSweepRegion.Setting = .sMeasureSweepParameter
            'Else
            '    ucSweepSetting.ucUserPatternList.Setting = .dSweepList
            'End If
            ucSweepSetting.SweepType = m_IVLSweepInfos.sCommon.sweepType
            Select Case m_IVLSweepInfos.sCommon.sweepType
                Case ucDispRcpIVLSweep.eSweepType.eStandard
                    ucSweepSetting.ucSweepRegion.Setting = m_IVLSweepInfos.sCommon.sMeasureSweepParameter
                Case ucDispRcpIVLSweep.eSweepType.eUserPattern
                    ucSweepSetting.ucUserPatternList.Setting = m_IVLSweepInfos.sCommon.dSweepList
                Case ucDispRcpIVLSweep.eSweepType.eRGBPattern '220826 Update by JKY
                    ucSweepSetting.ucRGBSweepRegion.Setting = m_IVLSweepInfos.sCommon.sMeasureRGBSweepParameter
            End Select

            '220829 Update by JKY
            UcDispListView1.ClearAllData()
            For i As Integer = 0 To m_IVLSweepInfos.sCommon.sMeasPoints.MeasPoint.Length - 1
                Dim sData(1) As String
                sData(0) = Format(m_IVLSweepInfos.sCommon.sMeasPoints.MeasPoint(i).X, "0.0")
                sData(1) = Format(m_IVLSweepInfos.sCommon.sMeasPoints.MeasPoint(i).Y, "0.0")
                UcDispListView1.AddRowData_AutoCountListNo(sData)
            Next

            'Add 20150319
            ucColorSetting.Setting = .nColorList

        End With

        ucDispKeithley.Settings = m_IVLSweepInfos.sKeithleyInfos
        ucDispRGBSignal.Setting = m_IVLSweepInfos.sRGBSignalInfos
        ' ucDispSignalGenerator.Settings = m_IVLSweepInfos.sSignalGeneratorInfos

        'Add 20150217
        tbViewingAngle.Text = CStr(m_IVLSweepInfos.sCommon.dViewingAngle)



    End Sub
#End Region


#Region "Button Event"

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click
        If GetValueFromUI() = False Then
            MsgBox("Check the Settings")
            Exit Sub
        End If

        RaiseEvent evADDIVLSweepRcp(m_IVLSweepInfos)
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If GetValueFromUI() = False Then
            MsgBox("Check the Settings")
            Exit Sub
        End If

        RaiseEvent evUpdateIVLSweepRcp(m_IVLSweepInfos)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Select Case m_VisibleMode

            Case ucSequenceBuilder.eRcpMode.eCell_IVL
            Case ucSequenceBuilder.eRcpMode.ePanel_IVL
                Dim dlg As frmSignalGenerator = New frmSignalGenerator

                'dlg.UcDispSignalGenerator1.Settings = ucDispSignalGenerator.Settings

                If dlg.ShowDialog = DialogResult.OK Then

                    'ucDispSignalGenerator.Settings = dlg.UcDispSignalGenerator1.Settings

                End If
            Case ucSequenceBuilder.eRcpMode.eModule_Lifetime

            Case Else

        End Select
    End Sub

    Private Sub btnMeasPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeasPoint.Click
        Dim dlg As frmMeasPointSetting = New frmMeasPointSetting
        dlg.Settings = m_IVLSweepInfos.sCommon.sMeasPoints
        dlg.targetSize = m_sampleInfos.SampleSize
        dlg.TargetType = m_sampleInfos.sampleType

        If dlg.ShowDialog = DialogResult.OK Then
            m_IVLSweepInfos.sCommon.sMeasPoints = dlg.Settings

            '220829 Update by JKY
            UcDispListView1.ClearAllData()
            For i As Integer = 0 To m_IVLSweepInfos.sCommon.sMeasPoints.MeasPoint.Length - 1
                Dim sData(1) As String
                sData(0) = Format(m_IVLSweepInfos.sCommon.sMeasPoints.MeasPoint(i).X, "0.0")
                sData(1) = Format(m_IVLSweepInfos.sCommon.sMeasPoints.MeasPoint(i).Y, "0.0")
                UcDispListView1.AddRowData_AutoCountListNo(sData)
            Next

        End If
    End Sub
#End Region


#Region "Change Event"
    Private Sub cbBiasMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBiasMode.SelectedIndexChanged
        If cbBiasMode.SelectedIndex = eBiasMode.eCV Then
            lblOffsetBiasValueUnit.Text = "V"
            lblLMeasValueUnit.Text = "V"
            ucSweepSetting.ucUserPatternList.UnitType = ucSweepSetting.eUnitType._Voltage
            ucSweepSetting.ucSweepRegion.UnitType = ucSweepSetting.eUnitType._Voltage
            ucDispKeithley.cboBiasMode.SelectedItem = "Voltage"

        ElseIf cbBiasMode.SelectedIndex = eBiasMode.eCC Then
            lblOffsetBiasValueUnit.Text = "mA"
            lblLMeasValueUnit.Text = "mA"
            ucSweepSetting.ucUserPatternList.UnitType = ucSweepSetting.eUnitType._milliAmpere
            ucSweepSetting.ucSweepRegion.UnitType = ucSweepSetting.eUnitType._milliAmpere
            ucDispKeithley.cboBiasMode.SelectedItem = "Current"
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

    Private Sub cbMeasureMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMeasureMode.SelectedIndexChanged
        If cbMeasureMode.SelectedIndex = eMeasureItems.eIV Then
            tbLMeasLevel.Enabled = False
            tbLMeasLimit.Enabled = False
            tbLumiCorrection.Enabled = False
        ElseIf cbMeasureMode.SelectedIndex = eMeasureItems.eIVL Then
            tbLMeasLevel.Enabled = True
            tbLMeasLimit.Enabled = True
            tbLumiCorrection.Enabled = True
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
            Case M7000.ucSweepSetting.eSweepType._RGBPattern '220826 Update by JKY
                cbSweepMode.Enabled = True
                tbCycleDelay.Enabled = True
        End Select

    End Sub

#End Region



    Private Sub cbNormalFastSelect_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbNormalFastSelect.SelectedIndexChanged
        If cbNormalFastSelect.SelectedIndex = 0 Then
            tbValueForFast.Enabled = False
        Else
            tbValueForFast.Enabled = True
        End If
    End Sub

    Private Sub cbFastBiasMode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbFastBiasMode.SelectedIndexChanged
        If cbFastBiasMode.SelectedIndex = eBiasMode.eCV Then
            'ucDispKeithley.rbCV.Checked = True
            lblValueForFast.Text = "V"
        ElseIf cbFastBiasMode.SelectedIndex = eBiasMode.eCC Then
            'ucDispKeithley.rbCC.Checked = True
            lblValueForFast.Text = "mA"
        End If
    End Sub
End Class
