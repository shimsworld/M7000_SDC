Imports CCommLib

Public Class frmEIPPGControl
    Dim myParent As frmMain
    Dim m_nSelDevGroup As Integer = 0
    Dim cEIPPG As CDevEIPPG = New CDevEIPPG
    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = main
        '  m_Config = config
        ucCfgRS232.COMPORT = config.PGConfig.EIPPGConfig.sSerialInfo.sPortName
        ucCfgRS232.BAUDRATE = config.PGConfig.EIPPGConfig.sSerialInfo.nBaudRate
        ucCfgRS232.DATABIT = config.PGConfig.EIPPGConfig.sSerialInfo.nDataBits
        ucCfgRS232.PARITYBIT = config.PGConfig.EIPPGConfig.sSerialInfo.nParity
        ucCfgRS232.STOPBIT = config.PGConfig.EIPPGConfig.sSerialInfo.nStopBits
        ucCfgRS232.COMPORT = config.PGConfig.EIPPGConfig.sSerialInfo.sPortName
        ucCfgRS232.SendTerminator = ucConfigRs232.ConvertStringToIntTerminator(config.PGConfig.EIPPGConfig.sSerialInfo.sSendTerminator)
        ucCfgRS232.RcvTerminator = ucConfigRs232.ConvertStringToIntTerminator(config.PGConfig.EIPPGConfig.sSerialInfo.sRcvTerminator)
    End Sub

    Private Sub btnConnection_Click(sender As Object, e As EventArgs) Handles btnConnection.Click
        Dim Config As CComSerial.sCommInfo = Nothing

        Config.commType = CComCommonNode.eCommType.eSerial
        Config.sSerialInfo.sPortName = ucCfgRS232.COMPORT
        Config.sSerialInfo.nBaudRate = ucCfgRS232.BAUDRATE
        Config.sSerialInfo.nDataBits = ucCfgRS232.DATABIT     '8
        Config.sSerialInfo.nParity = ucCfgRS232.PARITYBIT     'System.IO.Ports.Parity.None
        Config.sSerialInfo.nStopBits = ucCfgRS232.STOPBIT     'System.IO.Ports.StopBits.One
        Config.sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucCfgRS232.SendTerminator)
        Config.sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucCfgRS232.RcvTerminator)

        If cEIPPG.Connection(Config) = True Then
            tbConnectionStatus.Text = "Connection Complete"
        Else
            tbConnectionStatus.Text = "Connection Fail"
        End If
    End Sub

    Private Sub btnDisconnection_Click(sender As Object, e As EventArgs) Handles btnDisconnection.Click
        cEIPPG.Disconnection()
        tbConnectionStatus.Text = "Disconnection Complete"
    End Sub

    Private Sub btnSelectOn_Click(sender As Object, e As EventArgs) Handles btnSelectOn.Click
        If cEIPPG.EIPPG_ON() = False Then
            MessageBox.Show("Fail")
        End If

    End Sub

    Private Sub btnSelectOff_Click(sender As Object, e As EventArgs) Handles btnSelectOff.Click
        If cEIPPG.EIPPG_OFF() = False Then
            MessageBox.Show("Fail")
        End If
    End Sub
End Class
