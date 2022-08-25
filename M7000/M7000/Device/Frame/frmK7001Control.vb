Imports System.Threading
Imports System.IO
Imports CCommLib


Public Class frmK7001Control

#Region "Define"
    Dim m_nSelDevNum As Integer = 0
    Dim m_Main As frmMain
    Dim cK7001 As CDevK7001 = New CDevK7001
#End Region

    Public Sub New(ByVal main As frmMain)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_Main = main
        '  m_Config = config
    End Sub


    Private Sub btnK7001Connection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnK7001Connection.Click
        Dim Config As CComGPIB.sGPIBInfos = Nothing

        Config.nAddress = CInt(tbAddressNumber.Text)

        If cK7001.Connection(Config) = True Then
            tbConnectionStatus.Text = "Connection Complete"
        Else
            tbConnectionStatus.Text = "Connection Fail"
        End If
    End Sub

 
    Private Sub btnK7001Disconnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnK7001Disconnection.Click
        cK7001.Disconnection()
    End Sub

    Private Sub btnIDN_K7001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIDN_K7001.Click
        Dim sDevInfos As CDevK7001.sIDNInfo = Nothing

        If cK7001.IDN(sDevInfos) = True Then
            tbManufacture.Text = sDevInfos.sManufacture
            tbModel.Text = sDevInfos.sModel
            tbSerial.Text = sDevInfos.sSerial
            tbFWVersion.Text = sDevInfos.sFirmware
        Else
            tbManufacture.Text = "Failed"
            tbModel.Text = "Failed"
            tbSerial.Text = "Failed"
            tbFWVersion.Text = "Failed"
        End If

        cK7001.Reset()
    End Sub

    Private Sub btnReset_K7001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset_K7001.Click
        If cK7001.Reset() = True Then
            tbConnectionStatus.Text = "Reset Ok... "
        Else
            tbConnectionStatus.Text = "Reset Fail... "
        End If
    End Sub

    Private Sub btnAllOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllOpen.Click
        If cK7001.AllOFF() = True Then
            tbConnectionStatus.Text = "AllOpen Ok... "
        Else
            tbConnectionStatus.Text = "AllOpen Fail... "
        End If
    End Sub

    Private Sub btnSelectOpen_K7001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectOpen_K7001.Click
        '  Dim sCardNumber As String
        Dim sChNumber As String

        '  sCardNumber = tbSelectCardNumber.Text
        sChNumber = tbSelectChNumber.Text

        If cK7001.SwitchOFF(sChNumber) = True Then
            tbConnectionStatus.Text = "Open Ok... "
        Else
            tbConnectionStatus.Text = "Open Fail... "
        End If
    End Sub

    Private Sub btnSelectClose_K7001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectClose_K7001.Click
        ' Dim sCardNumber As String
        Dim sChNumber As String

        '  sCardNumber = tbSelectCardNumber.Text
        sChNumber = tbSelectChNumber.Text

        If cK7001.SwitchON(sChNumber) = True Then
            tbConnectionStatus.Text = "Close Ok... "
        Else
            tbConnectionStatus.Text = "Close Fail... "
        End If
    End Sub
End Class