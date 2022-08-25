Imports System.Threading
Imports System.IO
Imports CCommLib
Imports CSMULib

Public Class frmK26XXControl
    Dim sCommType() As String = New String() {"TCP/IP", "UDP", "Serial", "GPIB"}

    Dim m_Main As frmMain
    Dim m_ComType As CComCommonNode.eCommType
    Dim m_nSelDevNum As Integer = 0


    Public Sub New(ByVal main As frmMain)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_Main = main
        init()
    End Sub

    Public Sub init()
        gbConfig.Location = New System.Drawing.Point(0, 0)
        gbConfig.Dock = DockStyle.Fill

        With cbSelCommType
            .Items.Clear()
            For i As Integer = 0 To sCommType.Length - 1
                .Items.Add(sCommType(i))
            Next
            .SelectedIndex = 2
        End With

        txtIPBox1.Text = 192
        txtIPBox2.Text = 168
        txtIPBox3.Text = 0
        txtIPBox4.Text = 5
        txtPort.Text = 6000
        tbAddressNumber.Text = 16

        If g_ConfigInfos.SMUForIVLConfig(0).device = CDevSMUCommonNode.eModel.KEITHLEY_K2635 Then
            ucKeithleyCommon.DisplayMode = g_ConfigInfos.SMUForIVLConfig(0).device
            ucKeithleyCommon.ControlUI = g_ConfigInfos.SMUForIVLConfig(0).sRangeList
            ucConfigRs232.COMPORT = g_ConfigInfos.SMUForIVLConfig(0).settings.sSerialInfo.sPortName
            ucConfigRs232.BAUDRATE = g_ConfigInfos.SMUForIVLConfig(0).settings.sSerialInfo.nBaudRate
            ucConfigRs232.PARITYBIT = g_ConfigInfos.SMUForIVLConfig(0).settings.sSerialInfo.nParity
            ucConfigRs232.STOPBIT = g_ConfigInfos.SMUForIVLConfig(0).settings.sSerialInfo.nStopBits
            ucConfigRs232.DATABIT = g_ConfigInfos.SMUForIVLConfig(0).settings.sSerialInfo.nDataBits

            ucConfigRs232.RcvTerminator = CCommLib.ucConfigRs232.eTerminator.LF
            ucConfigRs232.SendTerminator = CCommLib.ucConfigRs232.eTerminator.CRLF
        End If

    End Sub


    Private Sub cbSelCommType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelCommType.SelectedIndexChanged
        Dim typeOfComm As CComCommonNode.eCommType = cbSelCommType.SelectedIndex
        Select Case typeOfComm
            Case CComCommonNode.eCommType.eSerial
                ucConfigRs232.Enabled = True
                gbIPSet.Enabled = False
                gbGPIBSet.Enabled = False
                m_ComType = CComCommonNode.eCommType.eSerial
            Case CComCommonNode.eCommType.eTCP
                gbIPSet.Enabled = True
                ucConfigRs232.Enabled = False
                gbGPIBSet.Enabled = False
                m_ComType = CComCommonNode.eCommType.eTCP
            Case CComCommonNode.eCommType.eUDP
                gbIPSet.Enabled = True
                ucConfigRs232.Enabled = False
                gbGPIBSet.Enabled = False
                m_ComType = CComCommonNode.eCommType.eUDP
            Case CComCommonNode.eCommType.eGPIB
                gbGPIBSet.Enabled = True
                ucConfigRs232.Enabled = False
                gbIPSet.Enabled = False
                m_ComType = CComCommonNode.eCommType.eGPIB
        End Select
    End Sub

    Private Sub btnK2635Connection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        Dim Config As CComCommonNode.sCommInfo = Nothing
        Dim iIP(3) As Integer

    
        Select Case m_ComType
            Case CComCommonNode.eCommType.eUDP Or CComCommonNode.eCommType.eTCP
                iIP(0) = CInt(txtIPBox1.Text)
                iIP(1) = CInt(txtIPBox2.Text)
                iIP(2) = CInt(txtIPBox3.Text)
                iIP(3) = CInt(txtIPBox4.Text)

                With Config.sLanInfo
                    .sIPAddress = iIP(0) & "." & iIP(1) & "." & iIP(2) & "." & iIP(3)
                    .nPort = CInt(txtPort.Text)
                End With

            Case CComCommonNode.eCommType.eSerial
                With Config.sSerialInfo
                    .sPortName = ucConfigRs232.COMPORT
                    .nBaudRate = ucConfigRs232.BAUDRATE
                    .nParity = ucConfigRs232.PARITYBIT
                    .nStopBits = ucConfigRs232.STOPBIT
                    .nDataBits = ucConfigRs232.DATABIT
                    .sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucConfigRs232.SendTerminator)
                    .sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucConfigRs232.RcvTerminator)
                End With
            Case CComCommonNode.eCommType.eGPIB
                With Config.sGPIBInfo
                    .nAddress = CInt(tbAddressNumber.Text)
                End With

        End Select

        Config.commType = m_ComType

       

        If m_Main.cIVLSMU(m_nSelDevNum).mySMU.Connection(Config) = True Then
            tbConnectionStatus.Text = "Connection Complete"
        Else
            tbConnectionStatus.Text = "Connection Fail"
        End If


    End Sub

    Private Sub btnK2635Disconnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnection.Click
        m_Main.cIVLSMU(m_nSelDevNum).mySMU.Disconnection()
    End Sub

    Private Sub btnK2635Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        tbConnectionStatus.Text = ""
    End Sub

    Private Sub btnSetBias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetBias.Click
        'm_Main.cK26XX(m_nSelDevNum).SetKeithleyInfos = ucKeithleyCommon.Settings

        If m_Main.cIVLSMU(m_nSelDevNum).mySMU.SetBias(CDbl(tbBiasValue.Text)) = True Then
            tbConnectionStatus.Text = "Bias Set Ok..."
        Else
            tbConnectionStatus.Text = "Bias Set Fail..."
        End If
    End Sub

    Private Sub btnCellOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCellOn.Click
        If m_Main.cIVLSMU(m_nSelDevNum).mySMU.InitializeSweep(ucKeithleyCommon.Settings) = True Then
            tbConnectionStatus.Text = "CellOn Ok..."
        Else
            tbConnectionStatus.Text = "CellOn Fail..."
        End If
    End Sub

    Private Sub btnCellOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCellOff.Click
        If m_Main.cIVLSMU(m_nSelDevNum).mySMU.FinalizeSweep = True Then
            tbConnectionStatus.Text = "CellOff Ok..."
        Else
            tbConnectionStatus.Text = "CellOff Fail..."
        End If
    End Sub

    Private Sub btnK2635Meas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeas.Click
        Dim dCurrent As Double
        Dim dVoltage As Double

        '        m_Main.cK26XX(m_nSelDevNum).SetKeithleyInfos = ucKeithleyCommon.Settings

        If m_Main.cIVLSMU(m_nSelDevNum).mySMU.Measure(dVoltage, dCurrent) = False Then
            MsgBox("Meas Fail(Current)")
        End If
        'If m_Main.cIVLSMU(m_nSelDevNum).mySMU.Measure(ucKeithleySMUSettings.eMeasValue.eCurrent, dCurrent) = False Then
        '    MsgBox("Meas Fail(Current)")
        'End If

        'If m_Main.cK26XX(m_nSelDevNum).Measure(ucKeithleySMUSettings.eMeasValue.eVoltage, dVoltage) = False Then
        '    MsgBox("Meas Fail(Voltage)")
        'End If

        tbReadVolt.Text = CStr(dVoltage)
        tbReadCurrent.Text = CStr(dCurrent)
    End Sub

    Private Sub btnK2635OptionSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptionSet.Click

        'm_Main.cK26XX(m_nSelDevNum).SetKeithleyInfos = ucKeithleyCommon.Settings

        If m_Main.cIVLSMU(m_nSelDevNum).mySMU.InitializeSweep(ucKeithleyCommon.Settings) = True Then
            tbConnectionStatus.Text = "Settings Set Ok..."
        Else
            tbConnectionStatus.Text = "Settings Set Fail..."
        End If
    End Sub

  
End Class