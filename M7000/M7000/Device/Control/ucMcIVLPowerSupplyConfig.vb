Imports CCommLib

Public Class ucMcIVLPowerSupplyConfig
#Region "Define"
    '정현기
    Dim m_ColorLabel() As Label
    Dim m_ColorType() As String
    Dim m_ucRs232Dev() As ucConfigRs232


    Dim m_sConfigData As sConfig
#End Region
#Region "Enums"
    Public Enum eDevType
        _R
        _G
        _B
        _Vdd
        _Vss
    End Enum
    Public Enum eTerminator
        McScience_EOT
        CR
        LF
        CRLF
        caret '^
        Hex3
        Hex4
        QuestionMark
        None
    End Enum
#End Region
#Region "Structure"
    Structure sConfig
        'Dim subCommunicationType As Integer
        Dim settings() As CComCommonNode.sCommInfo
        Dim DevType() As eDevType
        'Dim numberOfDevice As Integer
        'Dim nSeedAddress As Integer
        'Dim nAllocationCh_From As Integer
        'Dim nAllocationCh_To As Integer
        'Dim iAllocationCh() As Integer
        'Dim bIsOffline As Boolean
    End Structure
#End Region
#Region "Property"

    Property Setting() As sConfig
        Get
            GetValueFromUI()
            Return m_sConfigData
        End Get
        Set(value As sConfig)
            m_sConfigData = value
            SetValueToUI()
        End Set
    End Property
#End Region
#Region "Creator, Dispose and Init"
    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()
        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub
    Public Sub init()
        m_ColorLabel = New Label() {lblIVLPSDev1, lblIVLPSDev2, lblIVLPSDev3, lblIVLPSDev4, lblIVLPSDev5}
        m_ColorType = New String() {"R", "G", "B", "Vdd", "Vss"}
        m_ucRs232Dev = New ucConfigRs232() {UcConfigRs232_01, UcConfigRs232_02, UcConfigRs232_03, UcConfigRs232_04, UcConfigRs232_05}
    End Sub
#End Region
    Private Sub SetValueToUI()

        For i = 0 To m_ColorLabel.Length - 1
            If i < m_sConfigData.settings.Length Then
                m_ColorLabel(i).Visible = True
                m_ColorLabel(i).Text = m_ColorType(m_sConfigData.DevType(i)).ToString()
                m_ucRs232Dev(i).Visible = True
            Else
                m_ColorLabel(i).Visible = False
                m_ucRs232Dev(i).Visible = False
            End If
        Next

        For i = 0 To m_sConfigData.settings.Length - 1

            m_ucRs232Dev(i).COMPORT = m_sConfigData.settings(i).sSerialInfo.sPortName
            m_ucRs232Dev(i).BAUDRATE = m_sConfigData.settings(i).sSerialInfo.nBaudRate
            m_ucRs232Dev(i).RcvTerminator = ConvertStringToTerminator(m_sConfigData.settings(i).sSerialInfo.sRcvTerminator)
            m_ucRs232Dev(i).DATABIT = m_sConfigData.settings(i).sSerialInfo.nDataBits
            m_ucRs232Dev(i).PARITYBIT = m_sConfigData.settings(i).sSerialInfo.nParity
            m_ucRs232Dev(i).STOPBIT = m_sConfigData.settings(i).sSerialInfo.nStopBits
            m_ucRs232Dev(i).SendTerminator = ConvertStringToTerminator(m_sConfigData.settings(i).sSerialInfo.sSendTerminator)

        Next

        'With m_sPGConfig

        '    cbSelPGDevice.SelectedIndex = .nDeviceType

        '    Select Case .nDeviceType

        '        Case CDevPGCommonNode.eDevModel._McPG
        '            'McPG
        '            ucPGGroup.Setting = .McPGGroup
        '            ucPGConfig.Setting = .McPGConfig
        '            ucPGCtrlBD.Setting = .McPGCtrlBDConfig
        '            ucPGPower.Setting = .McPGPwrConfig

        '        Case CDevPGCommonNode.eDevModel._G4S
        '            ucG4SConfig.Setting = .G4sConfig


        '    End Select

        'End With
    End Sub
    Public Shared Function ConvertStringToTerminator(ByVal str As String) As ucMcIVLPowerSupplyConfig.eTerminator
        Dim type As ucMcIVLPowerSupplyConfig.eTerminator
        type = Integer.Parse(str)
        Return type
    End Function
    Private Sub GetValueFromUI()

        For i = 0 To m_sConfigData.settings.Length - 1

            m_sConfigData.settings(i).sSerialInfo.sPortName = m_ucRs232Dev(i).COMPORT
            m_sConfigData.settings(i).sSerialInfo.nBaudRate = m_ucRs232Dev(i).BAUDRATE
            m_sConfigData.settings(i).sSerialInfo.sRcvTerminator = m_ucRs232Dev(i).RcvTerminator
            m_sConfigData.settings(i).sSerialInfo.nDataBits = m_ucRs232Dev(i).DATABIT
            m_sConfigData.settings(i).sSerialInfo.nParity = m_ucRs232Dev(i).PARITYBIT
            m_sConfigData.settings(i).sSerialInfo.nStopBits = m_ucRs232Dev(i).STOPBIT
            m_sConfigData.settings(i).sSerialInfo.sSendTerminator = m_ucRs232Dev(i).SendTerminator

        Next


    End Sub



End Class