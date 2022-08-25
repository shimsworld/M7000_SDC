Imports CCommLib

Public Class frmStrobeControl

    Dim myParent As frmMain
    Dim m_nSelDevGroup As Integer = 0
    Dim cstrobe As CDevStrobe = New CDevStrobe
    Dim m_com As CCommLib.CComCommonNode.sCommInfo

    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = main
        '  m_Config = config
        ucCfgRS232.COMPORT = config.StrobeConfig(0).settings.sSerialInfo.sPortName
        ucCfgRS232.BAUDRATE = config.StrobeConfig(0).settings.sSerialInfo.nBaudRate
        ucCfgRS232.DATABIT = config.StrobeConfig(0).settings.sSerialInfo.nDataBits
        ucCfgRS232.PARITYBIT = config.StrobeConfig(0).settings.sSerialInfo.nParity
        ucCfgRS232.STOPBIT = config.StrobeConfig(0).settings.sSerialInfo.nStopBits
        ucCfgRS232.SendTerminator = ucConfigRs232.ConvertStringToIntTerminator(config.StrobeConfig(0).settings.sSerialInfo.sSendTerminator)
        ucCfgRS232.RcvTerminator = ucConfigRs232.ConvertStringToIntTerminator(config.StrobeConfig(0).settings.sSerialInfo.sRcvTerminator)

        m_com.commType = CComCommonNode.eCommType.eSerial
        m_com.sSerialInfo = config.StrobeConfig(0).settings.sSerialInfo

    End Sub


    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        cstrobe.Connection(m_com)

    End Sub

    Private Sub btnDisconnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnection.Click
        cstrobe.Disconnection()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim bState As Boolean = False

        If cstrobe.GetOnOff(bState) = True Then
            If bState = False Then
                cstrobe.TurnOn()
                Button1.Text = "ON"
                Button1.BackColor = Color.OrangeRed
            Else
                cstrobe.TurnOff()
                Button1.Text = "OFF"
                Button1.BackColor = Color.Gainsboro
            End If
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim nLevel As Integer = tbLevel.Text

        cstrobe.SetBrightness(nLevel)

    End Sub

    Private Sub btnRemote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemote.Click
        Dim bMode As Boolean = False
        If cstrobe.GetMode(bMode) = True Then
            If bMode = False Then
                cstrobe.SetMode(True)
                btnRemote.Text = "Remote"
                btnRemote.BackColor = Color.OrangeRed

            Else
                cstrobe.SetMode(False)
                btnRemote.Text = "Local"
                btnRemote.BackColor = Color.Gainsboro
            End If
        End If
    End Sub

    Private Sub btnGetBright_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetBright.Click
        Dim nBright As Integer = cstrobe.GetBrightness

        tbLevel.Text = nBright

    End Sub
End Class