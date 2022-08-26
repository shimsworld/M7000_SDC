Imports CCommLib

Public Class ucConfigPG



#Region "Defines"

    '모듈화 되지 않았지만 같은 기능을 하는 디바이스 목록을 정의
    'Define the Device list of module tester, It was not integrated but it does the same function
    Dim m_sPGDeviceLists() As String = New String() {"Nothing", "McScience", "G4S", "EIP"}   'Device List of Module tester


    'Dim McPGGroup() As ucConfigMcPGGroup.sMcPGGroupInfos
    'Dim McPGConfig() As ucConfigSocket.sConfig
    'Dim McPGPwrConfig() As ucConfigRS485.sRS485Config
    'Dim McPGCtrlBDConfig() As ucConfigRS485.sRS485Config

    Dim m_sPGConfig As sConfigs

    Public Structure sConfigs
        Dim nDeviceType As CDevPGCommonNode.eDevModel
        Dim G4sConfig As CDevG4S.sInitParam
        '김세훈8.25 PG EIP추가
        Dim EIPPGConfig As CComCommonNode.sCommInfo
        Dim McPGGroup() As ucConfigMcPGGroup.sMcPGGroupInfos
        Dim McPGConfig() As ucConfigSocket.sConfig
        Dim McPGPwrConfig() As ucConfigRS485.sRS485Config
        Dim McPGCtrlBDConfig() As ucConfigRS485.sRS485Config
    End Structure

#End Region


#Region "Properties"


    Public Property Setting As sConfigs
        Get
            GetValueFromUI()
            Return m_sPGConfig
        End Get
        Set(value As sConfigs)
            m_sPGConfig = value
            SetValueToUI()
        End Set
    End Property
#End Region




#Region "Creator, Disposer and init"


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Public Sub init()

        With cbSelPGDevice
            .Items.Clear()
            For i As Integer = 0 To m_sPGDeviceLists.Length - 1
                .Items.Add(m_sPGDeviceLists(i))
            Next
            .SelectedIndex = 0
        End With

        gbPGConfig.Dock = DockStyle.Fill

        ucG4SConfig.Location = New System.Drawing.Point(11, 41)
        ucG4SConfig.Size = New System.Drawing.Size(1250, 300)


        ucPGGroup.Location = New System.Drawing.Point(11, 41)
        ucPGGroup.Size = New System.Drawing.Size(1250, 166)

        '김세훈 
        'ucEIPConfig.Location = New System.Drawing.Point(11, 41)
        'ucEIPConfig.Size = New System.Drawing.Size(1250, 165)

        ucPGConfig.DispMode = ucConfigRS485.eDispMode.eHorizontalArrange
        ucPGConfig.Size = New System.Drawing.Size(1250, 137)
        ucPGConfig.Location = New System.Drawing.Point(11, ucPGGroup.Location.Y + ucPGGroup.Size.Height)

        ucPGPower.Size = New System.Drawing.Size(1250, 224)    '310
        ucPGPower.DispMode = ucConfigRS485.eDispMode.eHorizontalArrange
        ucPGPower.Location = New System.Drawing.Point(11, ucPGConfig.Location.Y + ucPGConfig.Size.Height)

        ucPGCtrlBD.Size = New System.Drawing.Size(1250, 224)   '310
        ucPGCtrlBD.DispMode = ucConfigRS485.eDispMode.eHorizontalArrange
        ucPGCtrlBD.Location = New System.Drawing.Point(11, ucPGPower.Location.Y + ucPGPower.Size.Height)

        '정현기
        ucDispRs232.Size = New System.Drawing.Size(241, 202)
        ucDispRs232.Location = New System.Drawing.Point(11, 41)

    End Sub


#End Region



    Private Sub SetValueToUI()
        With m_sPGConfig

            cbSelPGDevice.SelectedIndex = .nDeviceType

            Select Case .nDeviceType

                Case CDevPGCommonNode.eDevModel._McPG
                    'McPG
                    ucPGGroup.Setting = .McPGGroup
                    ucPGConfig.Setting = .McPGConfig
                    ucPGCtrlBD.Setting = .McPGCtrlBDConfig
                    ucPGPower.Setting = .McPGPwrConfig

                Case CDevPGCommonNode.eDevModel._G4S
                    ucG4SConfig.Setting = .G4sConfig

            End Select

        End With


        ucDispRs232.COMPORT = m_sPGConfig.EIPPGConfig.sSerialInfo.sPortName
        ucDispRs232.BAUDRATE = m_sPGConfig.EIPPGConfig.sSerialInfo.nBaudRate
        ucDispRs232.RcvTerminator = ConvertStringToTerminator(m_sPGConfig.EIPPGConfig.sSerialInfo.sRcvTerminator)
        ucDispRs232.DATABIT = m_sPGConfig.EIPPGConfig.sSerialInfo.nDataBits
        ucDispRs232.PARITYBIT = m_sPGConfig.EIPPGConfig.sSerialInfo.nParity
        ucDispRs232.STOPBIT = m_sPGConfig.EIPPGConfig.sSerialInfo.nStopBits
        ucDispRs232.SendTerminator = ConvertStringToTerminator(m_sPGConfig.EIPPGConfig.sSerialInfo.sSendTerminator)
    End Sub


    Private Sub GetValueFromUI()
        With m_sPGConfig

            .nDeviceType = cbSelPGDevice.SelectedIndex

            Select Case .nDeviceType

                Case CDevPGCommonNode.eDevModel._McPG
                    'PG
                    .McPGGroup = ucPGGroup.Setting
                    .McPGConfig = ucPGConfig.Setting
                    .McPGCtrlBDConfig = ucPGCtrlBD.Setting
                    .McPGPwrConfig = ucPGPower.Setting

                    .G4sConfig = Nothing

                Case CDevPGCommonNode.eDevModel._G4S
                    'PG
                    .McPGGroup = Nothing
                    .McPGConfig = Nothing
                    .McPGCtrlBDConfig = Nothing
                    .McPGPwrConfig = Nothing

                    .G4sConfig = ucG4SConfig.Setting
                Case CDevPGCommonNode.eDevModel._Nothing
                    .McPGGroup = Nothing
                    .McPGConfig = Nothing
                    .McPGCtrlBDConfig = Nothing
                    .McPGPwrConfig = Nothing

                    .G4sConfig = Nothing
                Case CDevPGCommonNode.eDevModel._EIP
                    .McPGGroup = Nothing
                    .McPGConfig = Nothing
                    .McPGCtrlBDConfig = Nothing
                    .McPGPwrConfig = Nothing

                    .G4sConfig = Nothing
                Case Else
                    .McPGGroup = Nothing
                    .McPGConfig = Nothing
                    .McPGCtrlBDConfig = Nothing
                    .McPGPwrConfig = Nothing

                    .G4sConfig = Nothing
            End Select


        End With

        m_sPGConfig.EIPPGConfig.sSerialInfo.sPortName = ucDispRs232.COMPORT
        m_sPGConfig.EIPPGConfig.sSerialInfo.nBaudRate = ucDispRs232.BAUDRATE
        m_sPGConfig.EIPPGConfig.sSerialInfo.sRcvTerminator = ucDispRs232.RcvTerminator
        m_sPGConfig.EIPPGConfig.sSerialInfo.nDataBits = ucDispRs232.DATABIT
        m_sPGConfig.EIPPGConfig.sSerialInfo.nParity = ucDispRs232.PARITYBIT
        m_sPGConfig.EIPPGConfig.sSerialInfo.nStopBits = ucDispRs232.STOPBIT
        m_sPGConfig.EIPPGConfig.sSerialInfo.sSendTerminator = ucDispRs232.SendTerminator
    End Sub



    Private Sub cbSelPGDevice_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbSelPGDevice.SelectedIndexChanged
        Select Case cbSelPGDevice.SelectedIndex
            Case 0
                ucPGGroup.Visible = False
                ucPGConfig.Visible = False
                ucPGPower.Visible = False
                ucPGCtrlBD.Visible = False

                ucG4SConfig.Visible = False
                ucDispRs232.Visible = False
            Case 1
                ucPGGroup.Visible = True
                ucPGConfig.Visible = True
                ucPGPower.Visible = True
                ucPGCtrlBD.Visible = True

                ucG4SConfig.Visible = False
                ucDispRs232.Visible = False
            Case 2
                ucG4SConfig.Visible = True

                ucPGGroup.Visible = False
                ucPGConfig.Visible = False
                ucPGPower.Visible = False
                ucPGCtrlBD.Visible = False
                '정현기
            Case 3
                ucG4SConfig.Visible = False
                ucPGGroup.Visible = False
                ucPGConfig.Visible = False
                ucPGPower.Visible = False
                ucPGCtrlBD.Visible = False

                ucDispRs232.Visible = True
        End Select
    End Sub
    Public Shared Function ConvertStringToTerminator(ByVal str As String) As ucMcIVLPowerSupplyConfig.eTerminator
        Dim type As ucMcIVLPowerSupplyConfig.eTerminator
        type = Integer.Parse(str)
        Return type
    End Function
End Class
