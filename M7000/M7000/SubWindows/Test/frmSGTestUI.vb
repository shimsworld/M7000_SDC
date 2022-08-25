Imports CCommLib

Public Class frmSGTestUI

    Public myParent As frmMain
    Dim m_Config() As ucConfigRS485.sRS485Config
    Dim m_nSelGroup As Integer  '통신포트단위

    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = main
        m_Config = config.SGConfig
        m_nSelGroup = 0
    End Sub



    Private Sub frmSGTestUI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Init()
    End Sub



    Public Sub Init()
        With cbSelGroup
            .Items.Clear()
            For i As Integer = 0 To m_Config.Length - 1
                .Items.Add(i + 1)
            Next
            .SelectedIndex = m_nSelGroup
        End With
    End Sub

    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        Dim configinfo As CComSerial.sSerialPortInfo = m_Config(m_nSelGroup).sSerialInfo
        'configinfo.sPortName = cboPort.Text
        'configinfo.nBaudRate = cbBaudRate.Text
        'configinfo.nDataBits = 8
        'configinfo.nHandShake = Ports.Handshake.None
        'configinfo.nParity = Ports.Parity.None
        'configinfo.nStopBits = Ports.StopBits.One
        'configinfo.sTerminator = vbCrLf
        'configinfo.sCMDTerminator = vbCrLf

        If myParent.cMcSG(m_nSelGroup).cSG.IsConnected = False Then

            If myParent.cMcSG(m_nSelGroup).Connection(m_Config(m_nSelGroup)) = True Then
                'cDevSG.PowerReadCal(devAddr, devCH)
                'cDevSG.SenseReadCal(devAddr, devCH)
                'InitDAc()
                'DacReadSetData()
                ' txt_err.Text = "Connect"
                MsgBox("연결 성공", MsgBoxStyle.Critical, "Care!!")
                btnConnection.BackColor = Color.Green
                btnConnection.Enabled = False
            Else
                'txt_err.Text = "DisConnect"
                myParent.cMcSG(m_nSelGroup).Disconnection()
                MsgBox("연결 실패", MsgBoxStyle.Critical, "Care!!")
                btnConnection.BackColor = Color.Red
                btnConnection.Enabled = True
            End If
        End If
    End Sub

    Private Sub cbSelDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelGroup.SelectedIndexChanged
        m_nSelGroup = cbSelGroup.SelectedIndex
        If myParent.cMcSG(m_nSelGroup).cSG.IsConnected = True Then
            btnConnection.Enabled = False
        Else
            btnConnection.Enabled = True
        End If
    End Sub


    Private Sub btnDisconnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnection.Click
        myParent.cMcSG(m_nSelGroup).Disconnection()
        btnConnection.BackColor = Color.Red
        btnConnection.Enabled = True
    End Sub

    Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click
        Dim setting As ucDispSignalGenerator.sSGDatas
        Dim sgSet As CSeqRoutineSG.sSettingParam = Nothing

        Dim nCntMainPwr As Integer
        Dim nCntSubPwr As Integer
        Dim nCntSignal As Integer

        Dim mainPwr() As cDevSG.sSettingParam = Nothing
        Dim subPwr() As cDevSG.sSettingParam = Nothing
        Dim signal() As cDevSG.sSettingParam = Nothing
        Dim mainPwrLimit() As cDevSG.sLimit = Nothing

        setting = UcDispSignalGenerator1.Settings

        For i As Integer = 0 To setting.nLenSignal - 1
            If setting.sParamData(i).eSignal = ucDispSignalGenerator.ePGSignal.MainPower1 Then
                ReDim Preserve mainPwr(nCntMainPwr)
                ReDim Preserve mainPwrLimit(nCntMainPwr)
                mainPwr(nCntMainPwr).Mode = setting.sParamData(i).eSrcMode
                If mainPwr(nCntMainPwr).Mode = CDevSG.eDacMode.eDCMode Then
                    mainPwr(nCntMainPwr).DCOutputCh = CDevSG.eFoutput.eHigh
                End If
                mainPwr(nCntMainPwr).dBias = setting.sParamData(i).dBias
                mainPwr(nCntMainPwr).dAmplitude = setting.sParamData(i).dAmplitude
                mainPwr(nCntMainPwr).PulseParam = setting.sParamData(i).sPulse

                mainPwrLimit(nCntMainPwr) = setting.sParamData(i).sLimit

                nCntMainPwr += 1
            ElseIf setting.sParamData(i).eSignal = ucDispSignalGenerator.ePGSignal.MainPower2 Then
                ReDim Preserve mainPwr(nCntMainPwr)
                ReDim Preserve mainPwrLimit(nCntMainPwr)
                mainPwr(nCntMainPwr).Mode = setting.sParamData(i).eSrcMode
                If mainPwr(nCntMainPwr).Mode = CDevSG.eDacMode.eDCMode Then
                    mainPwr(nCntMainPwr).DCOutputCh = CDevSG.eFoutput.eHigh
                End If
                mainPwr(nCntMainPwr).dBias = setting.sParamData(i).dBias
                mainPwr(nCntMainPwr).dAmplitude = setting.sParamData(i).dAmplitude
                mainPwr(nCntMainPwr).PulseParam = setting.sParamData(i).sPulse

                mainPwrLimit(nCntMainPwr) = setting.sParamData(i).sLimit

                nCntMainPwr += 1
            ElseIf setting.sParamData(i).eSignal >= ucDispSignalGenerator.ePGSignal.SubPower1 And setting.sParamData(i).eSignal <= ucDispSignalGenerator.ePGSignal.SubPower12 Then
                ReDim Preserve subPwr(nCntSubPwr)

                subPwr(nCntSubPwr).nIdx = Math.Abs(setting.sParamData(i).eSignal - ucDispSignalGenerator.ePGSignal.SubPower1)
                subPwr(nCntSubPwr).Mode = setting.sParamData(i).eSrcMode
                If subPwr(nCntSubPwr).Mode = CDevSG.eDacMode.eDCMode Then
                    subPwr(nCntSubPwr).DCOutputCh = CDevSG.eFoutput.eHigh
                End If
                subPwr(nCntSubPwr).dBias = setting.sParamData(i).dBias
                subPwr(nCntSubPwr).dAmplitude = setting.sParamData(i).dAmplitude
                subPwr(nCntSubPwr).PulseParam = setting.sParamData(i).sPulse
                nCntSubPwr += 1
            Else
                ReDim Preserve signal(nCntSignal)
                signal(nCntSignal).nIdx = Math.Abs(setting.sParamData(i).eSignal - ucDispSignalGenerator.ePGSignal.Signal1)
                signal(nCntSignal).Mode = setting.sParamData(i).eSrcMode
                If signal(nCntSignal).Mode = CDevSG.eDacMode.eDCMode Then
                    signal(nCntSignal).DCOutputCh = CDevSG.eFoutput.eHigh
                End If
                signal(nCntSignal).dBias = setting.sParamData(i).dBias
                signal(nCntSignal).dAmplitude = setting.sParamData(i).dAmplitude
                signal(nCntSignal).PulseParam = setting.sParamData(i).sPulse
                nCntSignal += 1
            End If

            Select Case setting.sParamData(i).eSignal
                Case ucDispSignalGenerator.ePGSignal.MainPower1

                Case ucDispSignalGenerator.ePGSignal.MainPower2

                Case ucDispSignalGenerator.ePGSignal.SubPower1
            End Select
        Next
        ' sgSet.SubPower()

        sgSet.MainPower = mainPwr.Clone
        sgSet.SubPower = subPwr.Clone
        sgSet.Signal = signal.Clone
        sgSet.MainPowerLimit = mainPwrLimit.Clone

        Dim device As Integer = tbDevice.Text
        Dim ch As Integer = tbChannel.Text

        If myParent.cMcSG(m_nSelGroup).Request(device, ch, CSeqRoutineSG.eSequenceState.eSetSource, sgSet) = False Then
            MsgBox("잘못된 입력 입니다.")
        End If
    End Sub

   
    Private Sub btnMeas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeas.Click
        Dim data As CSeqRoutineSG.sMeasuredData
        Dim ch As Integer = tbSystempCh.Text

        data = myParent.cMcSG(m_nSelGroup).MeasuredData(ch)

        tbELVDD_I.Text = data.dELVDD_I
        tbELVDD_T.Text = data.dELVDD_Temp
        tbELVSS_I.Text = data.dELVSS_I
        tbELVSS_T.Text = data.dELVSS_Temp
        tbPD_I.Text = data.dPD_I

    End Sub


    Private Sub btn_off_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_off.Click
        Dim device As Integer = tbDevice.Text
        Dim ch As Integer = tbChannel.Text

        If myParent.cMcSG(m_nSelGroup).Request(device, ch, CSeqRoutineSG.eSequenceState.eReset) = False Then
            MsgBox("잘못된 입력 입니다.")
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dcc As cDevSG.sLimit
        dcc.dCurrentLimit = 1
        dcc.dTempLimit = 100
        myParent.cMcSG(m_nSelGroup).cSG.MainPower_TempLimitSet(0, 0, dcc)
    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub tbChannel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbChannel.TextChanged

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub tbDevice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbDevice.TextChanged

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub tbSystempCh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSystempCh.TextChanged

    End Sub
End Class