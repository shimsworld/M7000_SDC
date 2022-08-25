Imports CCommLib

Public Class frmTCTTM004




#Region "Define"

    'Public fMain As frmMain
    Public cTTM004 As CDevTTM004 '= New CDevTTM004(g_ConfigInfos.TCConfig(0).numberOfDevice - 1)

    'Dim cTC() As CSeqRoutineTemp
    Dim m_Config As frmConfigDevice.sConfig
    Dim m_Main As frmMain
    Dim m_nSelDevGroup As Integer = 0

#End Region

    Public Sub New(ByVal myParent As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

        m_Main = myParent
        m_Config = config


        init()
    End Sub

    Public Sub init()
        '    cbSelAlarm1Type.DataSource = m_Main.cTC(m_nSelDevGroup).sAlarmTypes
    End Sub

    Private Sub frmNx1TempController_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strPortNames() As String = Nothing

        CComSerial.FindComPorts(strPortNames)

        If strPortNames Is Nothing = False Then
            cbPort.Items.Clear()
            For i As Integer = 0 To strPortNames.Length - 1
                cbPort.Items.Add(strPortNames(i))
            Next
            cbPort.SelectedIndex = 0
        End If

        cbBaudRate.SelectedIndex = 2

        If g_ConfigInfos.TCConfig Is Nothing = False Then
            tbNumOfDevice.Text = g_ConfigInfos.TCConfig(0).numberOfDevice
            cbPort.SelectedItem = m_Config.TCConfig(0).settings.sSerialInfo.sPortName
            cbBaudRate.SelectedItem = m_Config.TCConfig(0).settings.sSerialInfo.nBaudRate
        End If

        'cbPort.Text = m_Config.TCConfig(m_nSelDevGroup).settings.sSerialInfo.sPortName
        'cbBaudRate.SelectedItem = m_Config.TCConfig(m_nSelDevGroup).settings.sSerialInfo.nBaudRate

    End Sub

    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        Dim rs232Config As CComSerial.sSerialPortInfo = Nothing
        Dim nNumOfDevice As Integer = 0

        If cTTM004 Is Nothing Then
            If g_ConfigInfos.TCConfig Is Nothing = False Then
                nNumOfDevice = g_ConfigInfos.TCConfig(0).numberOfDevice - 1
            Else
                Try
                    nNumOfDevice = CInt(tbNumOfDevice.Text)
                Catch ex As Exception
                    MsgBox("Device Configuration setting(TC) Or NumOfDevice 확인 해 주십시오...")
                    Exit Sub
                End Try
            End If

            cTTM004 = New CDevTTM004(nNumOfDevice)
        End If

        rs232Config.sPortName = cbPort.Text
        rs232Config.nBaudRate = CInt(cbBaudRate.SelectedItem)
        rs232Config.nDataBits = 8
        rs232Config.nParity = IO.Ports.Parity.None ' m_Config.TCConfig(m_nSelDevGroup).settings.sSerialInfo.nParity
        rs232Config.nStopBits = IO.Ports.StopBits.Two ' m_Config.TCConfig(m_nSelDevGroup).settings.sSerialInfo.nStopBits
        rs232Config.sSendTerminator = "" 'vbCrLf 'm_Config.NX1Config(m_nSelDevGroup).sSerialInfo.sTerminator
        rs232Config.sRcvTerminator = Chr(&H3)  ' vbCrLf 'm_Config.NX1Config(m_nSelDevGroup).sSerialInfo.sCMDTerminator ' vbCrLf
        rs232Config.enableTerminator = False

        If cTTM004.Connection(rs232Config) = True Then
            TextBox1.Text = "Connection Complete"
        Else
            TextBox1.Text = "Connection Fail"
        End If
    End Sub

    Private Sub btnDisconnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnection.Click
        cTTM004.Disconnection()
        TextBox1.Text = "Disconnection Complete"
    End Sub

    Private Sub btnSetTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetTemp.Click

        Dim dSetTemp As Double = frmBuilderSettings.ConvertToDouble(tbSetTemp.Text)
        Dim nAddr As Integer = frmBuilderSettings.ConvertToInteger(tbAddress.Text)
        Dim retCode As CDevTCCommonNode.eReturnCode
        Dim nNumChannel As Integer = 0
        Dim i As Integer = 0
        Dim j As Integer = 0

        If cbAllChannel.Checked = True Then
            nNumChannel = g_ConfigInfos.TCConfig(0).numberOfDevice - 1
        Else
            nNumChannel = nAddr
            j = nAddr
        End If

        For i = j To nNumChannel
            retCode = cTTM004.SetTemperature(i, dSetTemp)
            If retCode <> CDevTCCommonNode.eReturnCode.OK Then
                TextBox1.Text = "Ch : " & i & vbTab & retCode.ToString
                Exit Sub
            End If
        Next

        TextBox1.Text = "Temp Set OK"
    End Sub

    Private Sub btnGetTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetTemp.Click
        Dim dGetTemp As Double '= tbGetTemp.Text
        Dim nAddr As Integer = frmBuilderSettings.ConvertToInteger(tbAddress.Text)

        If cTTM004.GetTemperature(nAddr, dGetTemp) = False Then
            TextBox1.Text = "Temp Get Fail"
            Exit Sub
        End If

        tbGetTemp.Text = CStr(dGetTemp)
        TextBox1.Text = "Temp Get OK"

    End Sub

    Private Sub btnGetSettingTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetSettingTemp.Click
        Dim dGetTemp As Double '= tbGetTemp.Text
        Dim nAddr As Integer = frmBuilderSettings.ConvertToInteger(tbAddress.Text)

        If cTTM004.GetSetTemperature(nAddr, dGetTemp) = False Then
            TextBox1.Text = "Fail"
            Exit Sub
        End If

        tbGetSettingTemp.Text = CStr(dGetTemp)
        TextBox1.Text = "Set Temp Get OK"

    End Sub


#Region "Alarm"


#End Region

  
    Private Sub btnGetDPInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDPInfo.Click
        Dim nAddr As Integer = frmBuilderSettings.ConvertToInteger(tbAddress.Text)
        If cTTM004.GetDecimalPoint(nAddr) = False Then
            TextBox1.Text = "Update Failed"
            Exit Sub
        End If

        TextBox1.Text = "Update OK"
    End Sub

    Private Sub btnSetLimitAlarm1_High_Click(sender As System.Object, e As System.EventArgs) Handles btnSetLimitAlarm1_High.Click
        Dim nAddr As Integer = frmBuilderSettings.ConvertToInteger(tbAddress.Text)
        Dim value As Double = frmBuilderSettings.ConvertToDouble(tbLimitAlarm1_High.Text)

        If cTTM004.SetEventAlarm1_High(nAddr, value) = False Then
            TextBox1.Text = "Update Failed"
            Exit Sub
        End If

        TextBox1.Text = "Update OK"
    End Sub

    Private Sub btnSetLimitAlarm1_Low_Click(sender As System.Object, e As System.EventArgs) Handles btnSetLimitAlarm1_Low.Click
        Dim nAddr As Integer = frmBuilderSettings.ConvertToInteger(tbAddress.Text)
        Dim value As Double = frmBuilderSettings.ConvertToDouble(tbLimitAlarm1_Low.Text)

        If cTTM004.SetEventAlarm1_Low(nAddr, value) = False Then
            TextBox1.Text = "Update Failed"
            Exit Sub
        End If

        TextBox1.Text = "Update OK"
    End Sub

    Private Sub btnGetLimitAlarm1_High_Click(sender As System.Object, e As System.EventArgs) Handles btnGetLimitAlarm1_High.Click
        Dim dGetTemp As Double '= tbGetTemp.Text
        Dim nAddr As Integer = frmBuilderSettings.ConvertToInteger(tbAddress.Text)

        If cTTM004.GetEventAlarm1_High(nAddr, dGetTemp) = False Then
            TextBox1.Text = "Fail"
            Exit Sub
        End If

        tbLimitAlarm1_High.Text = CStr(dGetTemp)
        TextBox1.Text = "OK"
    End Sub

    Private Sub btnGetLimitAlarm1_Low_Click(sender As System.Object, e As System.EventArgs) Handles btnGetLimitAlarm1_Low.Click
        Dim dGetTemp As Double '= tbGetTemp.Text
        Dim nAddr As Integer = frmBuilderSettings.ConvertToInteger(tbAddress.Text)

        If cTTM004.GetEventAlarm1_Low(nAddr, dGetTemp) = False Then
            TextBox1.Text = "Fail"
            Exit Sub
        End If

        tbLimitAlarm1_Low.Text = CStr(dGetTemp)
        TextBox1.Text = "OK"
    End Sub


    Private Sub btnGetEvent1Status_Click(sender As System.Object, e As System.EventArgs) Handles btnGetEvent1Status.Click
        Dim nAddr As Integer = frmBuilderSettings.ConvertToInteger(tbAddress.Text)
        Dim state As Boolean
        If cTTM004.GetEvent1Status(nAddr, state) = False Then
            TextBox1.Text = "Failed"
            Exit Sub
        End If

        chkEnableEvent1.Checked = state

        TextBox1.Text = "OK, State = " & CStr(state)
    End Sub

    Private Sub chkEnableEvent1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkEnableEvent1.CheckedChanged
        Dim nAddr As Integer = frmBuilderSettings.ConvertToInteger(tbAddress.Text)

        If cTTM004.SetEvent1Status(nAddr, chkEnableEvent1.Checked) = False Then
            TextBox1.Text = "Failed"
            Exit Sub
        End If

        TextBox1.Text = "OK"
    End Sub

  
    Private Sub btnGetOutputStauts_Click(sender As System.Object, e As System.EventArgs) Handles btnGetOutputStauts.Click
        Dim nStatusValue() As CDevTCCommonNode.eOutputStatus = Nothing '= tbGetTemp.Text
        Dim nAddr As Integer = frmBuilderSettings.ConvertToInteger(tbAddress.Text)

        If cTTM004.GetOutputStatus(nAddr, nStatusValue) = False Then
            TextBox1.Text = "Fail"
            Exit Sub
        End If

        If nStatusValue Is Nothing = False Then
            Dim sLine As String = ""
            For i As Integer = 0 To nStatusValue.Length - 1
                sLine = sLine & " / " & nStatusValue(i).ToString
            Next
            TextBox1.Text = "OK = " & sLine
        End If
    End Sub

    Private Sub btnGetSensityivity_Click(sender As System.Object, e As System.EventArgs) Handles btnGetSensityivity.Click
        Dim sensitivity As Double '= tbGetTemp.Text
        Dim nAddr As Integer = frmBuilderSettings.ConvertToInteger(tbAddress.Text)

        If cTTM004.GetEventAlarm1Sensitivity(nAddr, sensitivity) = False Then
            TextBox1.Text = "Fail"
            Exit Sub
        End If

        TextBox1.Text = "OK  " & CStr(sensitivity)
    End Sub

    Private Sub btnGetDelayTimer_Click(sender As System.Object, e As System.EventArgs) Handles btnGetDelayTimer.Click
        Dim delayTimer As Double '= tbGetTemp.Text
        Dim nAddr As Integer = frmBuilderSettings.ConvertToInteger(tbAddress.Text)

        If cTTM004.GetEventAlarm1DelayTimer(nAddr, delayTimer) = False Then
            TextBox1.Text = "Fail"
            Exit Sub
        End If

        'tbLimitAlarm1_Low.Text = CStr(delayTimer)
        TextBox1.Text = "OK" & CStr(delayTimer)
    End Sub

    Private Sub btnGetPolarity_Click(sender As System.Object, e As System.EventArgs) Handles btnGetPolarity.Click
        Dim polarity As Double '= tbGetTemp.Text
        Dim nAddr As Integer = frmBuilderSettings.ConvertToInteger(tbAddress.Text)

        If cTTM004.GetEventAlarm1Polarity(nAddr, polarity) = False Then
            TextBox1.Text = "Fail"
            Exit Sub
        End If

        'tbLimitAlarm1_Low.Text = CStr(dGetTemp)
        TextBox1.Text = "OK " & CStr(polarity)
    End Sub

 
  
End Class