Public Class frmMcM600


    Dim fMain As frmMain
    Dim configInfos() As ucM6000Config.sM6000Config

    Public Sub New(ByVal myParent As frmMain, ByVal configs() As ucM6000Config.sM6000Config)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        fMain = myParent
        configInfos = configs.Clone
        init()
    End Sub

    Private Sub init()

        With cbSelChannel
            .Items.Clear()
            For i As Integer = 0 To g_nMaxCh - 1
                .Items.Add(Format(i, "000"))
            Next
            .SelectedIndex = 0
        End With
    End Sub


    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        If fMain.cM6000 Is Nothing Then Exit Sub

        For i As Integer = 0 To fMain.cM6000.Length - 1
            If fMain.cM6000(i).McSMU.IsConnected = False Then
                If fMain.cM6000(i).Connection(configInfos(i).settings) = False Then
                    MsgBox("Connection Failure, Device : " & Format(i, "00"))
                Else
                    tsStatus.Text = "Device Connecting..." & Format(i + 1, "00") & " / " & Format(fMain.cM6000.Length, "00")
                End If

            End If
        Next

    End Sub

    Private Sub btnCtrl_Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtrl_Reset.Click

        Dim ch As Integer = cbSelChannel.SelectedIndex

        Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(ch, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
        Dim nNumOfCh As Integer = frmSettingWind.GetAllocationValue(ch, frmSettingWind.eChAllocationItem.eChOfM6000)


        If fMain.cM6000(nDevNo).McSMU.IsConnected = False Then tsStatus.Text = "need to connection" : Exit Sub

        If fMain.cM6000(nDevNo).Request(nNumOfCh, CSeqRoutineM6000.eSequenceState.eReset) = False Then
            tsStatus.Text = "Function Failed, Device : " & Format(nDevNo, "00") & " Ch : " & Format(nNumOfCh, "00")
        End If
    End Sub

    Private Sub btnCtrl_SrcOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtrl_SrcOn.Click
        Dim ch As Integer = cbSelChannel.SelectedIndex

        Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(ch, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
        Dim nNumOfCh As Integer = frmSettingWind.GetAllocationValue(ch, frmSettingWind.eChAllocationItem.eChOfM6000)

        Dim Settings As CDevM6000PLUS.sSettingParams
        Dim uiSettings As ucDispCellLifetime.sSourceSetting = ucDispM6000Setting.Settings

        Settings.source.Mode = uiSettings.Mode
        Settings.source.Pulse.dDuty = uiSettings.Pulse.dDuty
        Settings.source.Pulse.dFrequency = uiSettings.Pulse.dFrequency
        Settings.source.dBiasValue = uiSettings.dBias
        Settings.source.dAmplitude = uiSettings.dAmplitude
        Settings.bOutputState = CDevM6000PLUS.eONOFF.eON

        If fMain.cM6000(nDevNo).McSMU.IsConnected = False Then tsStatus.Text = "need to connection" : Exit Sub

        If fMain.cM6000(nDevNo).Request(nNumOfCh, CSeqRoutineM6000.eSequenceState.eSetSource, Settings, Nothing) = False Then
            tsStatus.Text = "Function Failed, Device : " & Format(nDevNo, "00") & " Ch : " & Format(nNumOfCh, "00")
        End If
    End Sub

    Private Sub btnCtrl_SrcOFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtrl_SrcOFF.Click
        Dim ch As Integer = cbSelChannel.SelectedIndex

        Dim nDevNo As Integer = frmSettingWind.GetAllocationValue(ch, frmSettingWind.eChAllocationItem.eDevNoOfM6000)
        Dim nNumOfCh As Integer = frmSettingWind.GetAllocationValue(ch, frmSettingWind.eChAllocationItem.eChOfM6000)

        Dim Settings As CDevM6000PLUS.sSettingParams
        Dim uiSettings As ucDispCellLifetime.sSourceSetting = ucDispM6000Setting.Settings

        Settings.source.Mode = uiSettings.Mode
        Settings.source.Pulse.dDuty = uiSettings.Pulse.dDuty
        Settings.source.Pulse.dFrequency = uiSettings.Pulse.dFrequency
        Settings.source.dBiasValue = uiSettings.dBias
        Settings.source.dAmplitude = uiSettings.dAmplitude
        Settings.bOutputState = CDevM6000PLUS.eONOFF.eOFF

        If fMain.cM6000(nDevNo).McSMU.IsConnected = False Then tsStatus.Text = "need to connection" : Exit Sub

        If fMain.cM6000(nDevNo).Request(nNumOfCh, CSeqRoutineM6000.eSequenceState.eSetSource, Settings, Nothing) = False Then
            tsStatus.Text = "Function Failed, Device : " & Format(nDevNo, "00") & " Ch : " & Format(nNumOfCh, "00")
        End If

    End Sub
End Class