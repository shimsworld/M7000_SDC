Imports CCommLib

Public Class frmTCNx1
    Inherits System.Windows.Forms.Form

#Region "Define"

    'Public fMain As frmMain
    '  Public cTempNx1 As CDevNX1 = New CDevNX1
    Dim m_Config As frmConfigDevice.sConfig
    Dim m_Main As frmMain
    Dim m_nSelDevGroup As Integer = 0

#End Region

    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_Main = main
        m_Config = config
        init()
    End Sub

    Public Sub init()
        '    cbSelAlarm1Type.DataSource = m_Main.cTC(m_nSelDevGroup).sAlarmTypes
        cbSelAlarm1Type.SelectedIndex = 0
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

        cbPort.Text = m_Config.TCConfig(m_nSelDevGroup).settings.sSerialInfo.sPortName
        cbBaudRate.SelectedItem = m_Config.TCConfig(m_nSelDevGroup).settings.sSerialInfo.nBaudRate

    End Sub

    Private Sub btnConnection_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        Dim rs232Config As CComSerial.sSerialPortInfo = Nothing

        rs232Config.sPortName = cbPort.Text
        rs232Config.nBaudRate = CInt(cbBaudRate.SelectedItem)
        rs232Config.nDataBits = 8
        rs232Config.nParity = m_Config.TCConfig(m_nSelDevGroup).settings.sSerialInfo.nParity
        rs232Config.nStopBits = m_Config.TCConfig(m_nSelDevGroup).settings.sSerialInfo.nStopBits
        rs232Config.sSendTerminator = vbCrLf 'm_Config.NX1Config(m_nSelDevGroup).sSerialInfo.sTerminator
        rs232Config.sRcvTerminator = vbCrLf 'm_Config.NX1Config(m_nSelDevGroup).sSerialInfo.sCMDTerminator ' vbCrLf

        'If m_Main.cNX1(m_nSelDevGroup).Connection(rs232Config) = True Then
        '    TextBox1.Text = "Connection Complete"
        'Else
        '    TextBox1.Text = "Connection Fail"
        'End If
    End Sub

    Private Sub btnDisconnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnection.Click
        '  m_Main.cNX1(m_nSelDevGroup).Disconnection()
        TextBox1.Text = "Disconnection Complete"
    End Sub

    Private Sub btnSetTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetTemp.Click
        Dim dSetTemp As Double = tbSetTemp.Text
        Dim nAddr As Integer = tbAddress.Text
        'If m_Main.cNX1(m_nSelDevGroup).SetTemperature(nAddr, dSetTemp) = False Then
        '    TextBox1.Text = "Temp Set Fail"
        '    Exit Sub
        'End If

        TextBox1.Text = "Temp Set OK"
    End Sub


    Private Sub btnGetTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetTemp.Click
        Dim dGetTemp As Double '= tbGetTemp.Text
        Dim dRetSetTemp As Double = 0
        Dim nAddr As Integer = tbAddress.Text
        'If m_Main.cNX1(m_nSelDevGroup).GetTemperature(nAddr, dGetTemp, dRetSetTemp) = False Then
        '    TextBox1.Text = "Temp Get Fail"
        '    Exit Sub
        'End If

        tbGetTemp.Text = CStr(dGetTemp)
        TextBox1.Text = "Temp Get OK"

    End Sub




#Region "Alarm"


#End Region

    Private Sub btnSetAlarm1Type_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAlarm1Type.Click
        Dim nType As Integer = cbSelAlarm1Type.SelectedIndex
        Dim nAddr As Integer = tbAddress.Text
        'If m_Main.cNX1(m_nSelDevGroup).SetAlarm1Type(nAddr, nType) = False Then
        '    TextBox1.Text = "Set Fail"
        '    Exit Sub
        'End If

        TextBox1.Text = "Set OK"
    End Sub

    Private Sub btnSetAlarm1DeadBand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAlarm1DeadBand.Click
        Dim dValue As Double = tbAlarm1DeadBand.Text
        Dim nAddr As Integer = tbAddress.Text
        'If m_Main.cNX1(m_nSelDevGroup).SetAlarm1DeadBand(nAddr, dValue) = False Then
        '    TextBox1.Text = "Set Fail"
        '    Exit Sub
        'End If

        TextBox1.Text = "Set OK"
    End Sub

    Private Sub btnSetAlarm1Value_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAlarm1Value.Click
        Dim dValue As Double = tbAlarm1Value.Text
        Dim nAddr As Integer = tbAddress.Text
        'If m_Main.cNX1(m_nSelDevGroup).SetAlarm1Value(nAddr, dValue) = False Then
        '    TextBox1.Text = "Set Fail"
        '    Exit Sub
        'End If

        TextBox1.Text = "Set OK"
    End Sub

    Private Sub btnGetAlarm1Type_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetAlarm1Type.Click
        Dim nType As Integer
        Dim nAddr As Integer = tbAddress.Text
        'If m_Main.cNX1(m_nSelDevGroup).GetAlarm1Type(nAddr, nType) = False Then
        '    TextBox1.Text = "Set Fail"
        '    Exit Sub
        'End If
        cbSelAlarm1Type.SelectedIndex = nType - 1
        TextBox1.Text = "Set OK"
    End Sub

    Private Sub btnGetAlarm1DeadBand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetAlarm1DeadBand.Click
        Dim dValue As Double
        Dim nAddr As Integer = tbAddress.Text
        'If m_Main.cNX1(m_nSelDevGroup).GetAlarm1DeadBand(nAddr, dValue) = False Then
        '    TextBox1.Text = "Set Fail"
        '    Exit Sub
        'End If
        tbAlarm1DeadBand.Text = dValue
        TextBox1.Text = "Set OK"
    End Sub

    Private Sub btnGetAlarm1Value_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetAlarm1Value.Click
        Dim dValue As Double
        Dim nAddr As Integer = tbAddress.Text
        'If m_Main.cNX1(m_nSelDevGroup).GetAlarm1Value(nAddr, dValue) = False Then
        '    TextBox1.Text = "Set Fail"
        '    Exit Sub
        'End If
        tbAlarm1Value.Text = dValue
        TextBox1.Text = "Set OK"
    End Sub
End Class