Imports System.Threading
Imports System.IO

Public Class frmTHCControl


    Dim myParent As frmMain
    Dim m_sPorts() As String
    Dim m_Config As CCommLib.CComSerial.sSerialPortInfo

    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = main
        'm_Config = config.TCConfig
        Init()
    End Sub

    Private Sub Init()
        btnMeasurement.Enabled = False
        btnDisconnection.Enabled = False

        CCommLib.CComSerial.FindComPorts(m_sPorts)

        cboComList.DataSource = m_sPorts
        cboComList.DropDownStyle = ComboBoxStyle.DropDownList
        cboComList.SelectedText = m_Config.sPortName
    End Sub


    Private Sub btnPortOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click

        'Dim comInfo As CCommLib.CComSerial.sSerialPortInfo = Nothing

        ''comInfo.commType = CCommLib.CComCommonNode.eCommType.eSerial
        'comInfo.sPortName = m_sPorts(cboComList.SelectedIndex)
        'comInfo.nBaudRate = 38400
        'comInfo.nDataBits = 8
        'comInfo.nParity = 0
        'comInfo.nStopBits = 1
        'comInfo.nHandShake = IO.Ports.Handshake.None
        'comInfo.enableTerminator = False
        'comInfo.sCMDTerminator = Nothing
        'comInfo.sTerminator = Nothing

        If myParent.cTHC98585.Connection(m_Config) = False Then
            MsgBox("Connection Failed")
        Else
            btnConnection.Enabled = False
            btnDisconnection.Enabled = True
            btnMeasurement.Enabled = True
        End If
    End Sub


    Private Sub btnDisconnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnection.Click
        myParent.cTHC98585.Disconnection()
        btnConnection.Enabled = True
        btnDisconnection.Enabled = False
        btnMeasurement.Enabled = False
        Timer1.Enabled = False
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        lbTemp.Text = CStr(myParent.cTHC98585.Temperatuer)
        lbHumidity.Text = CStr(myParent.cTHC98585.Humidity)

        Timer1.Enabled = True
    End Sub

    Private Sub btnMeasurement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeasurement.Click
        Timer1.Enabled = True
    End Sub

End Class
