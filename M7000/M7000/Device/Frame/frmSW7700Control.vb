Imports CCommLib
Imports System.Threading
Public Class frmSW7700Control
    Dim myParent As frmMain
    Dim m_nSelDevGroup As Integer = 0
    Dim cSW7700 As CDevSW7700 = New CDevSW7700
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

        If cSW7700.Connection(Config) = True Then
            tbConnectionStatus.Text = "Connection Complete"
        Else
            tbConnectionStatus.Text = "Connection Fail"
        End If

    End Sub

    Private Sub btnDisconnection_Click(sender As Object, e As EventArgs) Handles btnDisconnection.Click
        cSW7700.Disconnection()
        tbConnectionStatus.Text = "Disconnection Complete"
    End Sub

    Private Sub btnSelectOn_Click(sender As Object, e As EventArgs) Handles btnSelectOn.Click
        Dim nDevNum As Integer
        Dim nChNum As Integer

        Try
            nDevNum = CInt(tbSelectDevNumber.Text)
            nChNum = CInt(tbSelectChNumber.Text)

        Catch ex As Exception
            nDevNum = 0
            nChNum = 0
        End Try

        If cSW7700.SwitchON(nDevNum, nChNum) = True Then
            tbConnectionStatus.Text = "Set Switch On Complete"
        Else
            tbConnectionStatus.Text = "Set Switch On Fail"
        End If
    End Sub

    Private Sub btnSelectOff_Click(sender As Object, e As EventArgs) Handles btnSelectOff.Click
        Dim nDevNum As Integer
        Dim nChNum As Integer

        Try
            nDevNum = CInt(tbSelectDevNumber.Text)
            nChNum = CInt(tbSelectChNumber.Text)
        Catch ex As Exception
            nDevNum = 0
            nChNum = 0
        End Try

        If cSW7700.SwitchOFF(nDevNum, nChNum) = True Then
            tbConnectionStatus.Text = "Set Switch Off Complete"
        Else
            tbConnectionStatus.Text = "Set Switch Off Fail"
        End If
    End Sub

    Private Sub btnAllOn_Click(sender As Object, e As EventArgs) Handles btnAllOn.Click
        Dim nDevNum As Integer
        Try
            nDevNum = CInt(tbSelectDevNumber.Text)
        Catch ex As Exception
            nDevNum = 0
        End Try
        If cSW7700.AllON(nDevNum) = True Then
            tbConnectionStatus.Text = "All Channel On Complete"
        Else
            tbConnectionStatus.Text = "All Channel On Fail"
        End If
    End Sub

    Private Sub btnAllOff_Click(sender As Object, e As EventArgs) Handles btnAllOff.Click
        Dim nDevNum As Integer
        Try
            nDevNum = CInt(tbSelectDevNumber.Text)
        Catch ex As Exception
            nDevNum = 0
        End Try
        If cSW7700.AllOFF(nDevNum) = True Then
            tbConnectionStatus.Text = "All Channel On Complete"
        Else
            tbConnectionStatus.Text = "All Channel On Fail"
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
        Dim nDevNum As Integer
        Dim nStart As Integer
        Dim nEnd As Integer
        Dim nDelay As Integer

        Try
            nDevNum = CInt(tbDevNumver.Text)
            nStart = CInt(tbStart.Text)
            nEnd = CInt(tbEnd.Text)
            nDelay = CInt(tbDelay.Text)
        Catch ex As Exception
            MsgBox("입력 값이 잘 못 되었습니다...")
            Exit Sub
        End Try

        For i As Integer = nStart To nEnd
            If bStopTrdSwitch = False Then
                If cSW7700.SwitchON(nDevNum, i) = False Then Exit Sub
                Application.DoEvents()
                Thread.Sleep(nDelay)
                If cSW7700.SwitchOFF(nDevNum, i) = False Then Exit Sub
            Else
                Exit Sub
            End If
        Next

    End Sub
#End Region
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        StartTrdSwitch()
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        StopTrdSwitch()
    End Sub
End Class