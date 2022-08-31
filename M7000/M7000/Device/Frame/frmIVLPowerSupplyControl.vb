Imports CCommLib

Public Class frmIVLPowerSupplyControl
    Dim myParent As frmMain
    Dim MaxDev As Integer
    Dim m_nSelDevGroup As Integer = 0
    Dim cIVLPowerSupply() As CDevIVLPowersupply
    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = main

        For i = 0 To UcMcIVLPowerSupplyConfig1.m_ColorLabel.Length - 1
            If i < config.IVLPowerSupplyConfig.settings.Length Then
                UcMcIVLPowerSupplyConfig1.m_ColorLabel(i).Visible = True
                UcMcIVLPowerSupplyConfig1.m_ColorLabel(i).Text = UcMcIVLPowerSupplyConfig1.m_ColorType(config.IVLPowerSupplyConfig.DevType(i)).ToString()
                UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).Visible = True
            Else
                UcMcIVLPowerSupplyConfig1.m_ColorLabel(i).Visible = False
                UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).Visible = False
            End If
        Next
        MaxDev = config.IVLPowerSupplyConfig.settings.Length
        ReDim cIVLPowerSupply(MaxDev - 1)

        For i = 0 To config.IVLPowerSupplyConfig.settings.Length - 1
            cIVLPowerSupply(i) = New CDevIVLPowersupply
            UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).COMPORT = config.IVLPowerSupplyConfig.settings(i).sSerialInfo.sPortName
            UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).BAUDRATE = config.IVLPowerSupplyConfig.settings(i).sSerialInfo.nBaudRate
            UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).RcvTerminator = ConvertStringToTerminator(config.IVLPowerSupplyConfig.settings(i).sSerialInfo.sRcvTerminator)
            UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).DATABIT = config.IVLPowerSupplyConfig.settings(i).sSerialInfo.nDataBits
            UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).PARITYBIT = config.IVLPowerSupplyConfig.settings(i).sSerialInfo.nParity
            UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).STOPBIT = config.IVLPowerSupplyConfig.settings(i).sSerialInfo.nStopBits
            UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).SendTerminator = ConvertStringToTerminator(config.IVLPowerSupplyConfig.settings(i).sSerialInfo.sSendTerminator)
            cbDevSelect.Items.Add(UcMcIVLPowerSupplyConfig1.m_ColorType(config.IVLPowerSupplyConfig.DevType(i)).ToString())

        Next


        cbDevSelect.SelectedIndex = 0
    End Sub
    Public Shared Function ConvertStringToTerminator(ByVal str As String) As ucMcIVLPowerSupplyConfig.eTerminator
        Dim type As ucMcIVLPowerSupplyConfig.eTerminator
        type = Integer.Parse(str)
        Return type
    End Function

    Private Sub btnConnection_Click(sender As Object, e As EventArgs) Handles btnConnection.Click
        Dim Config As CComSerial.sCommInfo = Nothing
        For i = 0 To MaxDev - 1


            Config.commType = CComCommonNode.eCommType.eSerial
            Config.sSerialInfo.sPortName = UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).COMPORT
            Config.sSerialInfo.nBaudRate = UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).BAUDRATE
            Config.sSerialInfo.nDataBits = UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).DATABIT     '8
            Config.sSerialInfo.nParity = UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).PARITYBIT     'System.IO.Ports.Parity.None
            Config.sSerialInfo.nStopBits = UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).STOPBIT     'System.IO.Ports.StopBits.One
            Config.sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).SendTerminator)
            Config.sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(UcMcIVLPowerSupplyConfig1.m_ucRs232Dev(i).RcvTerminator)

            If cIVLPowerSupply(i).Connection(Config) = True Then
                tbConnectionStatus.Text = $"Dev { i + 1 } Connection Complete"
            Else
                tbConnectionStatus.Text = $"Dev { i + 1 } Connection Fail"
            End If
        Next

    End Sub

    Private Sub btnDisconnection_Click(sender As Object, e As EventArgs) Handles btnDisconnection.Click
        For i = 0 To MaxDev - 1
            cIVLPowerSupply(i).Disconnection()
            tbConnectionStatus.Text = $"Dev { i + 1 } Disconnection Complete"
        Next
    End Sub

    Private Sub btnSetV_Click(sender As Object, e As EventArgs) Handles btnSetV.Click
        cIVLPowerSupply(cbDevSelect.SelectedIndex).Volt = CInt(txtVoltage.Text)
    End Sub

    Private Sub btnSetI_Click(sender As Object, e As EventArgs) Handles btnSetI.Click
        cIVLPowerSupply(cbDevSelect.SelectedIndex).Current = CInt(txtCurrent.Text)
    End Sub

    Private Sub btnGetV_Click(sender As Object, e As EventArgs) Handles btnGetV.Click
        Dim Volt As Double = cIVLPowerSupply(cbDevSelect.SelectedIndex).Volt

        Dim Current As Double = cIVLPowerSupply(cbDevSelect.SelectedIndex).Current
        lblOutputPower.Text = $"{Volt.ToString()}V, {Current.ToString()}C"
    End Sub


    Private Sub btnPowerOn_Click(sender As Object, e As EventArgs) Handles btnPowerOn.Click
        cIVLPowerSupply(cbDevSelect.SelectedIndex).OUTPUT = True
    End Sub

    Private Sub btnPowerOff_Click(sender As Object, e As EventArgs) Handles btnPowerOff.Click
        cIVLPowerSupply(cbDevSelect.SelectedIndex).OUTPUT = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim str As String = cIVLPowerSupply(cbDevSelect.SelectedIndex).IDN
        MessageBox.Show(str)
    End Sub
End Class