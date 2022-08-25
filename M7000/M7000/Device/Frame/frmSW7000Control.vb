Imports CCommLib
Imports System.Threading

Public Class frmSW7000Control
    Dim myParent As frmMain
    Dim m_nSelDevGroup As Integer = 0
    Dim cSW7000 As CDevSW7000 = New CDevSW7000
   
    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = main
        '  m_Config = config

        ucCfgRS232.COMPORT = config.SwitchConfig(0).settings.sSerialInfo.sPortName
        ucCfgRS232.BAUDRATE = config.SwitchConfig(0).settings.sSerialInfo.nBaudRate
        ucCfgRS232.DATABIT = config.SwitchConfig(0).settings.sSerialInfo.nDataBits
        ucCfgRS232.PARITYBIT = config.SwitchConfig(0).settings.sSerialInfo.nParity
        ucCfgRS232.STOPBIT = config.SwitchConfig(0).settings.sSerialInfo.nStopBits
        ucCfgRS232.COMPORT = config.SwitchConfig(0).settings.sSerialInfo.sPortName
        ucCfgRS232.SendTerminator = ucConfigRs232.ConvertStringToIntTerminator(config.SwitchConfig(0).settings.sSerialInfo.sSendTerminator)
        ucCfgRS232.RcvTerminator = ucConfigRs232.ConvertStringToIntTerminator(config.SwitchConfig(0).settings.sSerialInfo.sRcvTerminator)
    End Sub

  
    Private Sub btnSW7000Connection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        Dim Config As CComSerial.sCommInfo = Nothing

        Config.commType = CComCommonNode.eCommType.eSerial
        Config.sSerialInfo.sPortName = ucCfgRS232.COMPORT
        Config.sSerialInfo.nBaudRate = ucCfgRS232.BAUDRATE
        Config.sSerialInfo.nDataBits = ucCfgRS232.DATABIT     '8
        Config.sSerialInfo.nParity = ucCfgRS232.PARITYBIT     'System.IO.Ports.Parity.None
        Config.sSerialInfo.nStopBits = ucCfgRS232.STOPBIT     'System.IO.Ports.StopBits.One
        Config.sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucCfgRS232.SendTerminator)
        Config.sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucCfgRS232.RcvTerminator)

        If cSW7000.Connection(Config) = True Then
            tbConnectionStatus.Text = "Connection Complete"
        Else
            tbConnectionStatus.Text = "Connection Fail"
        End If

    End Sub

    Private Sub btnSW7000Disconnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnection.Click
        cSW7000.Disconnection()
        tbConnectionStatus.Text = "Disconnection Complete"
    End Sub

    Private Sub btnSelectOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectOn.Click
        Dim nChNum As Integer

        Try
            nChNum = CInt(tbSelectChNumber.Text)
        Catch ex As Exception
            nChNum = 0
        End Try

        If cSW7000.SwitchON(nChNum) = True Then
            tbConnectionStatus.Text = "Set Switch On Complete"
        Else
            tbConnectionStatus.Text = "Set Switch On Fail"
        End If
    End Sub

    Private Sub btnSelectOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectOff.Click
        Dim nChNum As Integer = CInt(tbSelectChNumber.Text)

        Try
            nChNum = CInt(tbSelectChNumber.Text)
        Catch ex As Exception
            nChNum = 0
        End Try

        If cSW7000.SwitchOFF(nChNum) = True Then
            tbConnectionStatus.Text = "Set Switch Off Complete"
        Else
            tbConnectionStatus.Text = "Set Switch Off Fail"
        End If
    End Sub

    Private Sub btnAllOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllOn.Click
        If cSW7000.AllON() = True Then
            tbConnectionStatus.Text = "All Channel On Complete"
        Else
            tbConnectionStatus.Text = "All Channel On Fail"
        End If
    End Sub

    Private Sub btnAllOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllOff.Click
        If cSW7000.AllOFF() = True Then
            tbConnectionStatus.Text = "All Channel Off Complete"
        Else
            tbConnectionStatus.Text = "All Channel Off Fail"
        End If
    End Sub

#Region "ThreadLoop"
    Private trdSwitch As Thread
    Private bStopTrdSwitch As Boolean

    Private Sub StartTrdSwitch()
        trdSwitch = New Thread(AddressOf SwitchLoop)
        bStopTrdSwitch = False
        trdSwitch.Priority = ThreadPriority.Lowest
        trdSwitch.Start()
    End Sub

    Private Sub StopTrdSwitch()
        bStopTrdSwitch = True
    End Sub

    Private Sub SwitchLoop()
        Dim nStart As Integer
        Dim nEnd As Integer
        Dim nDelay As Integer

        Try
            nStart = CInt(tbStart.Text)
            nEnd = CInt(tbEnd.Text)
            nDelay = CInt(tbDelay.Text)
        Catch ex As Exception
            MsgBox("입력 값이 잘 못 되었습니다...")
            Exit Sub
        End Try

        For i As Integer = nStart To nEnd
            If bStopTrdSwitch = False Then
                If cSW7000.SwitchON(i) = False Then Exit Sub
                Application.DoEvents()
                Thread.Sleep(nDelay)
                If cSW7000.SwitchOFF(i) = False Then Exit Sub
            Else
                Exit Sub
            End If
        Next

    End Sub
#End Region

  

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        StartTrdSwitch()
    End Sub

    Private Sub btnEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnd.Click
        StopTrdSwitch()
    End Sub
End Class