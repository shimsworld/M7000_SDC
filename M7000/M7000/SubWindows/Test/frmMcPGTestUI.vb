Public Class frmMcPGTestUI

    Public myParent As frmMain
    Dim m_nSelGroup As Integer = 0

    Friend WithEvents UcDispModule1 As M7000.ucDispModule

    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = main
        ' m_Config = config.SGConfig
        m_nSelGroup = 0
        init()
    End Sub



    Private Sub init()
        Me.UcDispModule1 = New M7000.ucDispModule(6)
        '
        'UcDispModule1
        '
        Me.UcDispModule1.Location = New System.Drawing.Point(12, 46)
        Me.UcDispModule1.Name = "UcDispModule1"
        Me.UcDispModule1.Size = New System.Drawing.Size(807, 572)
        Me.UcDispModule1.TabIndex = 93
        Me.UcDispModule1.VisibleInitCodeEditTabPage = True
        Me.UcDispModule1.VisiblePatternEditTabPage = True
        Me.UcDispModule1.VisiblePowerControlTabPage = True
        Me.Controls.Add(Me.UcDispModule1)

    End Sub



    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        Dim PGCommInfo(0) As CSeqRoutineMcPG.sCommInfo
        'configinfo.sPortName = cboPort.Text
        'configinfo.nBaudRate = cbBaudRate.Text
        'configinfo.nDataBits = 8
        'configinfo.nHandShake = Ports.Handshake.None
        'configinfo.nParity = Ports.Parity.None
        'configinfo.nStopBits = Ports.StopBits.One
        'configinfo.sTerminator = vbCrLf
        'configinfo.sCMDTerminator = vbCrLf


        PGCommInfo(m_nSelGroup).bEnablePGCtrlBD = g_ConfigInfos.PGConfig.McPGGroup(m_nSelGroup).bEnablePGCtrl
        PGCommInfo(m_nSelGroup).sPGCtrl = g_ConfigInfos.PGConfig.McPGCtrlBDConfig(g_ConfigInfos.PGConfig.McPGGroup(m_nSelGroup).nPGCtrlBDNo).sSerialInfo

        PGCommInfo(m_nSelGroup).bEnablePGPwr = g_ConfigInfos.PGConfig.McPGGroup(m_nSelGroup).bEnablePGPwr
        PGCommInfo(m_nSelGroup).sPGPwr = g_ConfigInfos.PGConfig.McPGPwrConfig(g_ConfigInfos.PGConfig.McPGGroup(m_nSelGroup).nPGPwrNo).sSerialInfo

        PGCommInfo(m_nSelGroup).bEnablePG = g_ConfigInfos.PGConfig.McPGGroup(m_nSelGroup).bEnablePG
        If PGCommInfo(m_nSelGroup).bEnablePG = True Then
            ReDim PGCommInfo(m_nSelGroup).sPG(g_ConfigInfos.PGConfig.McPGGroup(m_nSelGroup).nPGNo.Length - 1)
            For i As Integer = 0 To g_ConfigInfos.PGConfig.McPGGroup(m_nSelGroup).nPGNo.Length - 1
                PGCommInfo(m_nSelGroup).sPG(i) = g_ConfigInfos.PGConfig.McPGConfig(g_ConfigInfos.PGConfig.McPGGroup(m_nSelGroup).nPGNo(i)).settings
            Next
        Else
            PGCommInfo(m_nSelGroup).sPG = Nothing
        End If

        PGCommInfo(m_nSelGroup).bEnablePDUnit = g_ConfigInfos.PGConfig.McPGGroup(m_nSelGroup).bEnablePDUnit
        If PGCommInfo(m_nSelGroup).bEnablePDUnit = True Then
            ReDim PGCommInfo(m_nSelGroup).sPDUnit(g_ConfigInfos.PGConfig.McPGGroup(m_nSelGroup).nPDUnitNo.Length - 1)
            For i As Integer = 0 To g_ConfigInfos.PGConfig.McPGGroup(m_nSelGroup).nPDUnitNo.Length - 1
                PGCommInfo(m_nSelGroup).sPDUnit(i) = g_ConfigInfos.PDMeasurementUnit(g_ConfigInfos.PGConfig.McPGGroup(m_nSelGroup).nPDUnitNo(i)).sSerialInfo
            Next
        Else
            PGCommInfo(m_nSelGroup).sPDUnit = Nothing
        End If

        If myParent.cPG.PatternGenerator(m_nSelGroup).IsConnected = False Then

            If myParent.cPG.PatternGenerator(m_nSelGroup).Connection(PGCommInfo(m_nSelGroup)) = True Then
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
                myParent.cPG.PatternGenerator(m_nSelGroup).Disconnection()
                MsgBox("연결 실패", MsgBoxStyle.Critical, "Care!!")
                btnConnection.BackColor = Color.Red
                btnConnection.Enabled = True
            End If
        End If
    End Sub

    Private Sub cbSelDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelGroup.SelectedIndexChanged, cbSelDevice.SelectedIndexChanged
        m_nSelGroup = cbSelDevice.SelectedIndex
        If myParent.cPG.PatternGenerator(m_nSelGroup).IsConnected = True Then
            btnConnection.Enabled = False
        Else
            btnConnection.Enabled = True
        End If
    End Sub

    Private Sub btnDisconnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnection.Click
        myParent.cPG.PatternGenerator(m_nSelGroup).Disconnection()
        btnConnection.BackColor = Color.Red
        btnConnection.Enabled = True
    End Sub

    Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click
        Dim settings As frmPatternGeneratorSetting.sPGInfos = UcDispModule1.Settings
        Dim SeqSettings As CSeqRoutineMcPG.sSettingParam
        Dim nCh As Integer = tbChannel.Text

        SeqSettings.sPGSettings = settings

        myParent.cPG.PatternGenerator(m_nSelGroup).Request(nCh, CSeqRoutineMcPG.eSequenceState.eON, SeqSettings)
    End Sub

    Private Sub btn_off_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_off.Click
        Dim nCh As Integer = tbChannel.Text
        myParent.cPG.PatternGenerator(m_nSelGroup).Request(nCh, CSeqRoutineMcPG.eSequenceState.eReset)
    End Sub

    Private Sub btnMeas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeas.Click
        Dim nch As Integer = tbChannel.Text
        Dim measuredData As CDevPGCommonNode.sMeasuredDatas = Nothing ' CSeqRoutineMcPG.sMeasuredData

        measuredData = myParent.cPG.PatternGenerator(m_nSelGroup).MeasuredData(nch)

        If myParent.cPG.PatternGenerator(m_nSelGroup).ChannelStatus(nch) = CSeqRoutineMcPG.eSequenceState.eMeasuring Then
            For i As Integer = 0 To measuredData.sMcPG.nPowerChNo.Length - 1
                Select Case measuredData.sMcPG.nPowerChNo(i)
                    Case 0
                        tbVolt01.Text = measuredData.sMcPG.dVoltage(i)
                        tbCurrent01.Text = measuredData.sMcPG.dCurrent(i)
                    Case 1
                        tbVolt02.Text = measuredData.sMcPG.dVoltage(i)
                        tbCurrent02.Text = measuredData.sMcPG.dCurrent(i)
                    Case 2
                        tbVolt03.Text = measuredData.sMcPG.dVoltage(i)
                        tbCurrent03.Text = measuredData.sMcPG.dCurrent(i)
                    Case 3
                        tbVolt04.Text = measuredData.sMcPG.dVoltage(i)
                        tbCurrent04.Text = measuredData.sMcPG.dCurrent(i)
                    Case 4
                        tbVolt05.Text = measuredData.sMcPG.dVoltage(i)
                        tbCurrent05.Text = measuredData.sMcPG.dCurrent(i)
                End Select
            Next
        Else
            tbVolt01.Text = myParent.cPG.PatternGenerator(m_nSelGroup).ChannelStatus(nch).ToString
        End If


        tbPDCurrent.Text = measuredData.sMcPG.dPD_I

    End Sub



End Class