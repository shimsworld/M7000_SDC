Imports System.Windows.Forms

Public Class ucKeithleySMUSettings

#Region "Define"
    Dim m_sSettings As sKeithley
    Dim m_DeviceModel As CDevSMUCommonNode.eModel
#End Region

#Region "Property"
    Public WriteOnly Property ControlUI As CDevSMUCommonNode.sRangeAndIntegTime
        Set(ByVal value As CDevSMUCommonNode.sRangeAndIntegTime)
            ControlUIInit(value)
        End Set
    End Property

    Public Property Settings As sKeithley
        Get
            GetFormUI()
            Return m_sSettings
        End Get
        Set(ByVal value As sKeithley)
            SetFormUI(value)
            m_sSettings = value
        End Set
    End Property

    Public WriteOnly Property DisplayMode As CDevSMUCommonNode.eModel
        Set(ByVal value As CDevSMUCommonNode.eModel)
            SelectSettingDisplayMode(value)
        End Set
    End Property

#End Region

#Region " Enum"
    Public Enum eSMUMode
        eCurrent
        eVoltage
        ePulseCurrent
        ePulseVoltage
    End Enum

    Public Enum eMeasValue
        eCurrent
        eVoltage
        ePower
        eResistance
    End Enum

    Public Enum eProve
        e2Prove
        e4Prove
    End Enum

    Public Enum eTerminalMode
        eRear
        eFront
    End Enum

    Public Enum eSMUCH
        eChA
        eChB
    End Enum
#End Region

#Region "Structure"
    Public Structure sKeithley
        Dim SourceChannel As eSMUCH
        Dim SourceMode As eSMUMode
        Dim WireMode As eProve
        Dim SourceDelay_Sec As Double
        Dim LimitVoltage As Double
        Dim LimitCurrent As Double
        Dim TerminalMode As eTerminalMode
        Dim MeasureMode As eMeasValue
        Dim NumOfMeasData As Integer
        Dim MeasureDelay_Sec As Double
        Dim IntegTime_Sec As Double
        Dim CurrentAutoRange As Boolean
        Dim VoltageAutoRange As Boolean
        Dim Amplitude As Double 'pulse
        Dim PulseOnTime As Double 'pulse
        Dim PulseOffTime As Double 'pulse 
        Dim NumberOfPulse As Double 'pulse
        ' Dim SourceRange As Double  차 후 Manual Range 설정 부분 필요 _PSK
        '  Dim MeasureRange As Double
        Dim MeasureValueType As eMeasValue
        Dim MeasureDelayAuto As Boolean
        Dim nIntegTimeIndex As Integer
        Dim nVoltageRangeIndex As Integer
        Dim nCurrentRangeIndex As Integer
        ' Dim sRange As CDevSMUCommonNode.sRange
        ' Dim sIntegTime() As String
    End Structure
#End Region

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        gbKeithley.Location = New System.Drawing.Point(0, 0)
        gbKeithley.Dock = Windows.Forms.DockStyle.Fill

        With cbCurrentRange
            .Items.Clear()
            .Items.Add("Nothing")
        End With

        With cbVoltageRange
            .Items.Clear()
            .Items.Add("Nothing")
        End With

        With cbIntegTime
            .Items.Clear()
            .Items.Add("Nothing")
        End With

        With cboBiasMode
            .Items.Clear()
            .Items.Add("Nothing")
        End With
    End Sub

    Private Sub GetFormUI()

        With m_sSettings

            If rbChA.Checked = True Then
                .SourceChannel = eSMUCH.eChA
            Else
                .SourceChannel = eSMUCH.eChB
            End If

            'If rbCC.Checked = True Then
            '    .SourceMode = CDevK26xx.eSMUMode.eCurrent
            '    .MeasureMode = CDevK26xx.eSMUMode.eVoltage
            '    .MeasureValueType = CDevK26xx.eSMUMode.eVoltage
            'Else
            '    .SourceMode = CDevK26xx.eSMUMode.eVoltage
            '    .MeasureMode = CDevK26xx.eSMUMode.eCurrent
            '    .MeasureValueType = CDevK26xx.eSMUMode.eCurrent
            'End If

            If cboBiasMode.SelectedIndex = eSMUMode.eCurrent Then
                .SourceMode = eSMUMode.eCurrent
                .MeasureMode = eMeasValue.eVoltage
                .MeasureValueType = eMeasValue.eVoltage
            ElseIf cboBiasMode.SelectedIndex = eSMUMode.eVoltage Then
                .SourceMode = CDevK26xx.eSMUMode.eVoltage
                .MeasureMode = CDevK26xx.eSMUMode.eCurrent
                .MeasureValueType = CDevK26xx.eSMUMode.eCurrent
            ElseIf cboBiasMode.SelectedIndex = eSMUMode.ePulseCurrent Then
                .SourceMode = eSMUMode.eCurrent
                .MeasureMode = eMeasValue.eVoltage
                .MeasureValueType = eMeasValue.eVoltage
            ElseIf cboBiasMode.SelectedIndex = eSMUMode.ePulseVoltage Then
                .SourceMode = CDevK26xx.eSMUMode.eVoltage
                .MeasureMode = CDevK26xx.eSMUMode.eCurrent
                .MeasureValueType = CDevK26xx.eSMUMode.eCurrent
            End If

            If rb2Wire.Checked = True Then
                .WireMode = eProve.e2Prove
            Else
                .WireMode = eProve.e4Prove
            End If

            If rbRear.Checked = True Then
                .TerminalMode = eTerminalMode.eRear
            Else
                .TerminalMode = eTerminalMode.eFront
            End If

            .MeasureDelayAuto = cbAutoDelay_Measure.Checked
            .IntegTime_Sec = CDbl(tbIntegTime.Text)
            .LimitCurrent = CDbl(tbCurrentLimit.Text)
            .LimitVoltage = CDbl(tbVoltLimit.Text)

            .MeasureDelay_Sec = CDbl(tbMeasDelay.Text)
            .NumOfMeasData = CDbl(tbNumofMeasData.Text)
            .SourceDelay_Sec = CDbl(tbSourceDelay.Text)

            .nIntegTimeIndex = cbIntegTime.SelectedIndex
            .nVoltageRangeIndex = cbVoltageRange.SelectedIndex
            .nCurrentRangeIndex = cbCurrentRange.SelectedIndex
            .PulseOnTime = CDbl(tbPulseontime.Text)
            .PulseOffTime = CDbl(tbPulseofftime.Text)
            .NumberOfPulse = CDbl(tbNumofpulse.Text)

            '.CurrentAutoRange = cbAutoRange_Measure.Checked
            ' .VoltageAutoRange = cbAutoRange_Source.Checked

            If .nVoltageRangeIndex = 0 Then
                .VoltageAutoRange = True
            Else
                .VoltageAutoRange = False
            End If

            If .nCurrentRangeIndex = 0 Then
                .CurrentAutoRange = True
            Else
                .CurrentAutoRange = False
            End If

        End With

    End Sub

    Private Sub SetFormUI(ByVal Settings As sKeithley)
        With Settings
            If .SourceChannel = eSMUCH.eChA Then
                rbChA.Checked = True
            Else
                rbChB.Checked = True
            End If

            'If .SourceMode = eSMUMode.eCurrent Then
            '    rbCC.Checked = True
            'Else
            '    rbCV.Checked = True
            'End If
           
            Try
                cboBiasMode.SelectedIndex = .SourceMode
            Catch ex As Exception
                cboBiasMode.SelectedIndex = 0
            End Try


            If .TerminalMode = eTerminalMode.eFront Then
                rbFront.Checked = True
            Else
                rbRear.Checked = True
            End If

            If .WireMode = eProve.e2Prove Then
                rb2Wire.Checked = True
            Else
                rb4Wire.Checked = True
            End If

            'If .VoltageAutoRange = True Then
            '    cbAutoRange_Source.Checked = True
            'Else
            '    cbAutoRange_Source.Checked = False
            'End If

            'If .CurrentAutoRange = True Then
            '    cbAutoRange_Measure.Checked = True
            'Else
            '    cbAutoRange_Measure.Checked = False
            'End If

            If .MeasureDelayAuto = True Then
                cbAutoDelay_Measure.Checked = True
            Else
                cbAutoDelay_Measure.Checked = False
            End If

            tbSourceDelay.Text = CStr(.SourceDelay_Sec)
            tbMeasDelay.Text = CStr(.MeasureDelay_Sec)
            tbNumofMeasData.Text = CStr(.NumOfMeasData)
            tbIntegTime.Text = CStr(.IntegTime_Sec)
            tbCurrentLimit.Text = CStr(.LimitCurrent)
            tbVoltLimit.Text = CStr(.LimitVoltage)
            tbPulseontime.Text = CStr(.PulseOnTime)
            tbPulseofftime.Text = CStr(.PulseOffTime)
            tbNumofpulse.Text = CStr(.NumberOfPulse)

            Try
                cbIntegTime.SelectedIndex = .nIntegTimeIndex
            Catch ex As Exception
                cbIntegTime.SelectedIndex = 0
            End Try


            cbVoltageRange.SelectedIndex = .nVoltageRangeIndex
            cbCurrentRange.SelectedIndex = .nCurrentRangeIndex

        End With
    End Sub

    Private Sub ControlUIInit(ByVal sInfos As CDevSMUCommonNode.sRangeAndIntegTime)

        With cbCurrentRange
            .Items.Clear()
            For i As Integer = 0 To sInfos.sCurrentListName.Length - 1
                .Items.Add(sInfos.sCurrentListName(i))
            Next
            .SelectedIndex = 0
        End With

        With cbVoltageRange
            .Items.Clear()
            For i As Integer = 0 To sInfos.sVoltageListName.Length - 1
                .Items.Add(sInfos.sVoltageListName(i))
            Next
            .SelectedIndex = 0
        End With

        If m_DeviceModel = CDevSMUCommonNode.eModel.KEITHLEY_K236 Then
            With cbIntegTime
                .Items.Clear()
                For i As Integer = 0 To sInfos.sIntegTimeListName.Length - 1
                    .Items.Add(sInfos.sIntegTimeListName(i))
                Next
                .SelectedIndex = 0
            End With
        End If

        With cboBiasMode
            .Items.Clear()
            For i As Integer = 0 To sInfos.sSourceModeName.Length - 1
                .Items.Add(sInfos.sSourceModeName(i))
            Next
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub SelectSettingDisplayMode(ByVal DisplayMode As CDevSMUCommonNode.eModel)

        m_DeviceModel = DisplayMode

        Select Case m_DeviceModel
            Case CDevSMUCommonNode.eModel.KEITHLEY_K236 To CDevSMUCommonNode.eModel.kEITHLEY_K238
                cbIntegTime.Visible = True
                lblIntegTime.Visible = False
                tbIntegTime.Visible = False

                gbWireMode.Visible = False
                gbTerminalMode.Visible = False
                gbSMUCH.Visible = False
                cbAutoDelay_Measure.Visible = False

                Label10.Visible = False
                Label11.Visible = False
                Label15.Visible = False
                Label16.Visible = False
                Label18.Visible = False
                tbPulseontime.Visible = False
                tbPulseofftime.Visible = False
                tbNumofpulse.Visible = False
            Case CDevSMUCommonNode.eModel.KEITHLEY_K2400 To CDevSMUCommonNode.eModel.KEITHLEY_K2450
                cbIntegTime.Visible = False
                lblIntegTime.Visible = True
                tbIntegTime.Visible = True

                gbWireMode.Visible = True
                gbTerminalMode.Visible = True
                gbSMUCH.Visible = False
                cbAutoDelay_Measure.Visible = False

                Label10.Visible = False
                Label11.Visible = False
                Label15.Visible = False
                Label16.Visible = False
                Label18.Visible = False
                tbPulseontime.Visible = False
                tbPulseofftime.Visible = False
                tbNumofpulse.Visible = False
            Case CDevSMUCommonNode.eModel.KEITHLEY_K2601

                cbIntegTime.Visible = False
                lblIntegTime.Visible = True
                tbIntegTime.Visible = True

                gbWireMode.Visible = True
                gbTerminalMode.Visible = False
                gbSMUCH.Visible = True
                cbAutoDelay_Measure.Visible = True

                Label10.Visible = False
                Label11.Visible = False
                Label15.Visible = False
                Label16.Visible = False
                Label18.Visible = False
                tbPulseontime.Visible = False
                tbPulseofftime.Visible = False
                tbNumofpulse.Visible = False
            Case CDevSMUCommonNode.eModel.KEITHLEY_K2602
                cbIntegTime.Visible = False
                lblIntegTime.Visible = True
                tbIntegTime.Visible = True

                gbWireMode.Visible = True
                gbTerminalMode.Visible = False
                gbSMUCH.Visible = True
                cbAutoDelay_Measure.Visible = True
                Label10.Visible = True
                Label11.Visible = True
                Label15.Visible = True
                Label16.Visible = True
                Label18.Visible = True
                tbPulseontime.Visible = True
                tbPulseofftime.Visible = True
                tbNumofpulse.Visible = True
            Case CDevSMUCommonNode.eModel.KEITHLEY_K2635 To CDevSMUCommonNode.eModel.KEITHLEY_K2636
                cbIntegTime.Visible = False
                lblIntegTime.Visible = True
                tbIntegTime.Visible = True

                gbWireMode.Visible = True
                gbTerminalMode.Visible = False
                gbSMUCH.Visible = True
                cbAutoDelay_Measure.Visible = True
                Label10.Visible = False
                Label11.Visible = False
                Label15.Visible = False
                Label16.Visible = False
                Label18.Visible = False
                tbPulseontime.Visible = False
                tbPulseofftime.Visible = False
                tbNumofpulse.Visible = False
        End Select

    End Sub
End Class
