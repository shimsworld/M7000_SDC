Imports System.Threading
Imports CCommLib
Imports CSpectrometerLib


Public Class frmPR705Control

    '  Dim m_Config As frmConfigDevice.sConfig
    Dim m_Main As frmMain
    Dim cPR705 As CDevPR705 = New CDevPR705

#Region "Create, Dispose and init"

    Public Sub New(ByVal main As frmMain)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_Main = main
        '  m_Config = config
    End Sub

#End Region

    Private Sub btnPR705Connection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPR705Connection.Click
        Dim Config As CComCommonNode.sCommInfo = Nothing
        Dim Accessoryname() As String = Nothing
        Dim Aperturename() As String = Nothing
        '  Dim nCnt As Integer
        Dim sRcv As String = ""

        Config.commType = CComCommonNode.eCommType.eSerial
        Config.sSerialInfo.sPortName = ucCfgRS232PR705.COMPORT
        Config.sSerialInfo.nBaudRate = ucCfgRS232PR705.BAUDRATE
        Config.sSerialInfo.nDataBits = ucCfgRS232PR705.DATABIT     '8
        Config.sSerialInfo.nParity = ucCfgRS232PR705.PARITYBIT     'System.IO.Ports.Parity.None
        Config.sSerialInfo.nStopBits = ucCfgRS232PR705.STOPBIT     'System.IO.Ports.StopBits.One
        Config.sSerialInfo.sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucCfgRS232PR705.SendTerminator)
        Config.sSerialInfo.sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucCfgRS232PR705.RcvTerminator)

        If cPR705.Connection(Config) = True Then
            tbPR705ConnectionStatus.Text = "Connection Complete"
        Else
            tbPR705ConnectionStatus.Text = "Connection Fail"
        End If

        cbLensType_PR705.Items.Clear()
        cbApertureType_PR705.Items.Clear()

        Application.DoEvents()
        Thread.Sleep(50)

        'If cPR705.GetAccessory(Accessoryname) = False Then

        'Else
        '    For nCnt = 0 To Accessoryname.Length - 2
        '        cbLensType_PR705.Items.Add(Accessoryname(nCnt))
        '    Next
        '    cbLensType_PR705.SelectedIndex = 0
        'End If


        'If cPR705.GetApertures(Aperturename) = False Then

        'Else
        '    For nCnt = 0 To Aperturename.Length - 2
        '        cbApertureType_PR705.Items.Add(Aperturename(nCnt))
        '    Next
        '    cbApertureType_PR705.SelectedIndex = 0
        'End If
    End Sub

    Private Sub btnPR705Disconnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPR705Disconnection.Click
        cPR705.Disconnection()
        tbPR705ConnectionStatus.Text = "Disconnection Complete"
    End Sub

    Private Sub btnSetBacklight_PR705_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetBacklight_PR705.Click
        If cPR705.SetBacklight(cbBacklight_PR705.SelectedIndex) = False Then

        Else

        End If
    End Sub

    Private Sub btnGetLens_PR705_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetLens_PR705.Click
        'Dim Accessoryname() As String = Nothing
        'Dim nCnt As Integer

        'cbLensType_PR705.Items.Clear()

        'If m_Main.cPR705.GetAccessory(Accessoryname) = False Then

        'Else
        '    For nCnt = 0 To Accessoryname.Length - 2
        '        cbLensType_PR705.Items.Add(Accessoryname(nCnt))
        '    Next
        '    cbLensType_PR705.SelectedIndex = 0
        'End If
    End Sub

    Private Sub btnGetAperture_PR705_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetAperture_PR705.Click
        'Dim Aperturename() As String = Nothing
        'Dim nCnt As Integer

        'cbApertureType_PR705.Items.Clear()

        'If m_Main.cPR705.GetApertures(Aperturename) = False Then

        'Else
        '    For nCnt = 0 To Aperturename.Length - 2
        '        cbApertureType_PR705.Items.Add(Aperturename(nCnt))
        '    Next
        '    cbApertureType_PR705.SelectedIndex = 0
        'End If
    End Sub

    Private Sub btnGetOption_PR705_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetOption_PR705.Click
        Dim sRcv As String = ""
        Dim m_PR705Instrument As CDevPR705.tData = Nothing

        If cPR705.GetInstrumentSetup(sRcv, m_PR705Instrument) = False Then
            lblGetSettings.Text = "recive failed"
        Else
            With m_PR705Instrument.GetInfo
                cbLensType_PR705.SelectedItem = .sLensName
                cbApertureType_PR705.SelectedItem = .sApertureName
                cbExposureMode.SelectedItem = .sExposureMode
                cbPhotometricUnits.SelectedIndex = .nPhotoUnit
                tbExposureTime.Text = .nExposureTime
                tbMeasAverage.Text = .nAverage
            End With

            lblGetSettings.Text = sRcv
        End If
    End Sub

    Private Sub btnSetOption_PR705_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetOption_PR705.Click
        Dim Accessorycode As Integer = cbLensType_PR705.SelectedIndex
        Dim Aperturecode As CDevPR705.eAperture
        Dim PhotoUnit As Integer = cbPhotometricUnits.SelectedIndex
        Dim sMeasAverage As String = tbMeasAverage.Text
        Dim sExposureTime As String = ""

        If cbApertureType_PR705.SelectedItem = "1 deg." Then
            Aperturecode = CDevPR705.eAperture.e1
        ElseIf cbApertureType_PR705.SelectedItem = "1/2 deg." Then
            Aperturecode = CDevPR705.eAperture.e0R5
        ElseIf cbApertureType_PR705.SelectedItem = "1/4 deg." Then
            Aperturecode = CDevPR705.eAperture.e0R25
        ElseIf cbApertureType_PR705.SelectedItem = "1/8 deg." Then
            Aperturecode = CDevPR705.eAperture.e0R125
        ElseIf cbApertureType_PR705.SelectedItem = "2 deg." Then
            Aperturecode = CDevPR705.eAperture.e2
        End If

        If cbExposureMode.SelectedIndex = 0 Then
            sExposureTime = 0
        Else
            sExposureTime = tbExposureTime.Text
        End If
        If cPR705.SetSetup(CStr(Accessorycode), CStr(Aperturecode), CStr(PhotoUnit), sMeasAverage, sExposureTime) = False Then

        Else

        End If
    End Sub

    Private Sub btnRemoteOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoteOn.Click
        If cPR705.SetRemoteMode = False Then

        Else

        End If
    End Sub

    Private Sub btnRemoteOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoteOff.Click
        If cPR705.QuitRemoteMode = False Then

        Else

        End If
    End Sub

    Private Sub btnMeasStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeasStart.Click
        Dim measData As CDevPR705.tData = Nothing
        Dim nMode As CDevPR705.eMeasMode

        nMode = cbSelectMeasData.SelectedIndex + 1

        tbMeasData.AppendText("Measureing..." & vbCrLf)

        tbMeasData.AppendText("M" & nMode & ">>>>" & vbCrLf)

        If cPR705.Meas(nMode, measData) = False Then
            tbMeasData.AppendText("Meas Fail..." & vbCrLf)
            Exit Sub
        Else
            DataDisplay(nMode, measData)
        End If

        tbMeasData.AppendText("Meas End..." & vbCrLf & vbCrLf)
    End Sub

    Private Sub btnDataRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDataRead.Click
        Dim measData As CDevPR705.tData = Nothing
        Dim nMode As CDevPR705.eMeasMode

        nMode = cbSelectMeasData.SelectedIndex + 1

        tbMeasData.AppendText("Reading..." & vbCrLf)

        tbMeasData.AppendText("D" & nMode & ">>>>" & vbCrLf)

        If cPR705.ReadData(nMode, measData) = False Then
            tbMeasData.AppendText("Read fail..." & vbCrLf)
            Exit Sub
        Else
            DataDisplay(nMode, measData)
        End If

        tbMeasData.AppendText("Read End..." & vbCrLf & vbCrLf)
    End Sub

    Private Sub btnMeasDataClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeasDataClear.Click
        tbMeasData.Text = ""
    End Sub

    Private Sub btnSetCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetCommand.Click
        Dim sCmd As String

        sCmd = tbCommand.Text


        Dim sRcv As String = Nothing
        If cPR705.communicator.Communicator.SendToString(sCmd, sRcv) = CComCommonNode.eReturnCode.OK Then
            lblRcvMsg.Text = sRcv
        Else
            lblRcvMsg.Text = "recive failed"
        End If

        'If m_Main.cPR705.communicator.Communicator.SendToString(sCmd) = CComCommonNode.eReturnCode.OK Then
        '    lblRcvMsg.Text = "Completed Data Send"
        'Else
        '    lblRcvMsg.Text = "Failed Data Send"
        'End If
    End Sub

    Private Sub DataDisplay(ByVal nMode As CDevPR705.eMeasMode, ByVal measData As CDevPR705.tData)

        With measData
            Select Case nMode
                Case CDevPR705.eMeasMode.eCIE1931_Yxy
                    tbMeasData.AppendText("Luminance = " & .D1.s2YY & vbCrLf)
                    tbMeasData.AppendText("CIEx = " & .D1.s3xx & vbCrLf)
                    tbMeasData.AppendText("CIEy = " & .D1.s4yy & vbCrLf)
                Case CDevPR705.eMeasMode.eXYZ
                    tbMeasData.AppendText("X = " & .D2.s2XX & vbCrLf)
                    tbMeasData.AppendText("Y = " & .D2.s3YY & vbCrLf)
                    tbMeasData.AppendText("Z = " & .D2.s4ZZ & vbCrLf)
                Case CDevPR705.eMeasMode.eCIE1976_Yuv
                    tbMeasData.AppendText("Luminance = " & .D3.s2YY & vbCrLf)
                    tbMeasData.AppendText("CIEu' = " & .D3.s3uu & vbCrLf)
                    tbMeasData.AppendText("CIEy' = " & .D3.s4vv & vbCrLf)
                Case CDevPR705.eMeasMode.eYCd
                    tbMeasData.AppendText("Luminance = " & .D4.s2YY & vbCrLf)
                    tbMeasData.AppendText("CCT = " & .D4.s3KelvinT & vbCrLf)
                    tbMeasData.AppendText("uv deviation = " & .D4.s4DevOfColorCoord & vbCrLf)
                Case CDevPR705.eMeasMode.eSpectrumData
                    tbMeasData.AppendText("Peak WL = " & .D5.iMax & vbCrLf)
                    tbMeasData.AppendText("WL" & vbTab & "Spectral Data" & vbCrLf)

                    For nCnt As Integer = 0 To .D5.i3nm.Length - 1
                        tbMeasData.AppendText(.D5.i3nm(nCnt) & vbTab & .D5.s4Intensity(nCnt) & vbCrLf)
                    Next

                Case CDevPR705.eMeasMode.eCIE1931CIE1976_Yxyuv
                    tbMeasData.AppendText("Luminance = " & .D6.s2YY & vbCrLf)
                    tbMeasData.AppendText("CIEx = " & .D6.s3xx & vbCrLf)
                    tbMeasData.AppendText("CIEy = " & .D6.s4yy & vbCrLf)
                    tbMeasData.AppendText("CIEu' = " & .D6.s5uu & vbCrLf)
                    tbMeasData.AppendText("CIEv' = " & .D6.s6vv & vbCrLf)
            End Select
        End With

    End Sub

    Private Sub cbExposureMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbExposureMode.SelectedIndexChanged
        If cbExposureMode.SelectedIndex = 0 Then
            tbExposureTime.Enabled = False
        Else
            tbExposureTime.Enabled = True
        End If
    End Sub
End Class