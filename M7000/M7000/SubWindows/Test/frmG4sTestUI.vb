Imports System
Imports System.Threading

Public Class frmG4sTestUI



#Region "Define"


    Dim myParent As frmMain
    Dim WithEvents cG4S As CDevPGAPI 'New CDevG4S(11, 15)
    Dim m_ConfigInfo As CDevG4S.sInitParam
    Dim m_nDevID As Integer = 0

    Dim m_sModelNames() As String
    Dim m_sPatternNames() As String

    Dim m_nIP As Integer = 0
    Dim m_JustCtrlMode As Boolean


    Private Delegate Sub DelString(ByVal str As String)

    Public Sub tbClientText(ByVal str As String)
        If tbClients.InvokeRequired = True Then
            Dim del2 As DelString = New DelString(AddressOf tbClientText)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tbClients.Text = str
        End If
        'If tbClients.InvokeRequired = True Then

        'Else

        'End If
    End Sub

    Public Sub tbServerMsgText(ByVal str As String)
        If tbServerMsg.InvokeRequired = True Then
            Dim del2 As DelString = New DelString(AddressOf tbServerMsgText)
            Try
                Invoke(del2, str)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            tbServerMsg.Text = str & vbCrLf & tbServerMsg.Text
        End If
        'If tbClients.InvokeRequired = True Then

        'Else

        'End If
    End Sub

#End Region

#Region "Creator And Disposer"

    Public Sub New(ByVal objPG As CDevPGAPI, ByVal configInfo As CDevG4S.sInitParam, ByVal parent As frmMain, ByVal ctrlMode As Boolean)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        cG4S = objPG
        cG4S.PatternGenerator(0).EnableEvent = True
        m_ConfigInfo = configInfo
        myParent = parent
        m_JustCtrlMode = ctrlMode
        init()
    End Sub

    Private Sub init()
        With cbSelDev
            cbSelDev.Items.Clear()
            For i As Integer = 0 To 249
                .Items.Add(CStr(i))
            Next
            .SelectedIndex = 0
        End With


        With cbSelChannel
            cbSelChannel.Items.Clear()
            For i As Integer = 0 To g_ConfigInfos.PGConfig.G4sConfig.iAllocationCh.Length - 1
                cbSelChannel.Items.Add(Format(g_ConfigInfos.PGConfig.G4sConfig.iAllocationCh(i) + 1, "000"))
            Next
            cbSelChannel.SelectedIndex = 0
        End With

        If m_JustCtrlMode = True Then
            btnConnection.Visible = False
            btnDisconnection.Visible = False
        Else
            btnConnection.Visible = True
            btnDisconnection.Visible = True
        End If
    End Sub

    'Private Sub frmG4sTestUI_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    cG4S.Disconnection()
    'End Sub

    'Private Sub frmMain_FormClosing(sender As Object, e As System.EventArgs) Handles Me.FormClosing
    '    cG4S.Disconnection()
    'End Sub


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        btnUpdateModelInfo_Click(btnUpdateModelInfo, Nothing)

    End Sub

#End Region

#Region "Functions"


    Private Sub btnPowerON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerON.Click
        Dim nDevNo As Integer
        Dim nCh As Integer
        Try
            nCh = cbSelChannel.SelectedIndex
            nDevNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        Catch ex As Exception
            Exit Sub
        End Try

        If nDevNo = -1 Then
            MsgBox("해당 채널은 제어할 수 있는 구동기가 없습니다.")
            Exit Sub
        End If

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) <> CScheduler.eChSchedulerSTATE.eIdle Then
            cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevG4S.eSequenceState.eON)
        Else
            MsgBox("Select Channel is not IDEL")
        End If

        'If cG4S.PatternGenerator(m_nDevID).ChannelStatus(nDevNo) = CDevPGCommonNode.eSequenceState.eidle Then
        'Else
        'End If
    End Sub

    Private Sub btnPowerOFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerOFF.Click
        Dim nDevNo As Integer
        Dim nCh As Integer
        Try
            nCh = cbSelChannel.SelectedIndex
            nDevNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        Catch ex As Exception
            Exit Sub
        End Try

        If nDevNo = -1 Then
            MsgBox("해당 채널은 제어할 수 있는 구동기가 없습니다.")
            Exit Sub
        End If

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) <> CScheduler.eChSchedulerSTATE.eIdle Then
            cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevG4S.eSequenceState.eReset)
        Else
            MsgBox("Select Channel is not IDEL")
        End If

        'If cG4S.PatternGenerator(m_nDevID).ChannelStatus(nDevNo) = CDevPGCommonNode.eSequenceState.eidle Then
        'Else
        'End If
    End Sub

    Private Sub btnGetCurrent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetCurrent.Click
        Dim nDevNo As Integer
        Dim nCh As Integer
        Try
            nCh = cbSelChannel.SelectedIndex
            nDevNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        Catch ex As Exception
            Exit Sub
        End Try

        If nDevNo = -1 Then
            MsgBox("해당 채널은 제어할 수 있는 구동기가 없습니다.")
            Exit Sub
        End If

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) <> CScheduler.eChSchedulerSTATE.eIdle Then
            cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevG4S.eSequenceState.eMeasuring)
        Else
            MsgBox("Select Channel is not IDEL")
        End If

        'If cG4S.PatternGenerator(m_nDevID).ChannelStatus(nDevNo) = CDevPGCommonNode.eSequenceState.eidle Then
        'Else
        'End If
    End Sub

    Private Sub btnGetRealtimeData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetRealtimeData.Click
        Dim data As CDevG4S.sG4SDatas

        Dim nDevNo As Integer
        Dim nCh As Integer
        Try
            nCh = cbSelChannel.SelectedIndex
            nDevNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        Catch ex As Exception
            Exit Sub
        End Try

        If nDevNo = -1 Then
            MsgBox("해당 채널은 제어할 수 있는 구동기가 없습니다.")
            Exit Sub
        End If

        If cG4S.PatternGenerator(0).IsConnectedSubChannel(nDevNo) = False Then
            MsgBox("구동기가 연결 되지 않았습니다.")
            Exit Sub
        End If

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
            data = cG4S.PatternGenerator(m_nDevID).MeasuredData(nDevNo).sG4S

            lblRealTimeDatas.Text = "Pattern Index = " & CStr(data.nPatternIdx) & vbCrLf
            lblRealTimeDatas.Text = lblRealTimeDatas.Text & "IDD(mA) = " & CStr(data.IDD_mA) & vbCrLf
            lblRealTimeDatas.Text = lblRealTimeDatas.Text & "ICI(mA) = " & CStr(data.ICI_mA) & vbCrLf
            lblRealTimeDatas.Text = lblRealTimeDatas.Text & "IBAT(mA) = " & CStr(data.IBAT_mA) & vbCrLf
            lblRealTimeDatas.Text = lblRealTimeDatas.Text & "Color_Red = " & CStr(data.nColor_Red) & vbCrLf
            lblRealTimeDatas.Text = lblRealTimeDatas.Text & "Color_Green = " & CStr(data.nColor_Green) & vbCrLf
            lblRealTimeDatas.Text = lblRealTimeDatas.Text & "Color_Blue = " & CStr(data.nColor_Blue) & vbCrLf
            lblRealTimeDatas.Text = lblRealTimeDatas.Text & "Device = " & data.Device.ToString & vbCrLf
            lblRealTimeDatas.Text = lblRealTimeDatas.Text & "Power State = " & data.PowerState.ToString & vbCrLf
            lblRealTimeDatas.Text = lblRealTimeDatas.Text & "Measure State = " & data.MeasState.ToString & vbCrLf
        Else
            MsgBox("Select Channel is not IDEL")
        End If

        'If cG4S.PatternGenerator(m_nDevID).ChannelStatus(nDevNo) = CDevPGCommonNode.eSequenceState.eidle Then
        'Else
        'End If

    End Sub

    Private Sub btnPatternNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatternNext.Click
        Dim nCh As Integer
        Dim nDevNo As Integer
        Try
            nCh = cbSelChannel.SelectedIndex
            nDevNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        Catch ex As Exception
            Exit Sub
        End Try

        If nDevNo = -1 Then
            MsgBox("해당 채널은 제어할 수 있는 구동기가 없습니다.")
            Exit Sub
        End If

        If cG4S.PatternGenerator(0).IsConnectedSubChannel(nDevNo) = False Then
            MsgBox("구동기가 연결 되지 않았습니다.")
            Exit Sub
        End If

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
            cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevG4S.eSequenceState.eChangePattern_Next)
        Else
            MsgBox("Select Channel is not IDEL")
        End If

        'If cG4S.PatternGenerator(m_nDevID).ChannelStatus(nDevNo) = CDevPGCommonNode.eSequenceState.eidle Then
        '    cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevG4S.eSequenceState.eChangePattern_Next)
        'Else
        '    MsgBox("Select Channel is not IDEL")
        'End If
    End Sub

    Private Sub btnPatternBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatternBack.Click
        Dim nCh As Integer
        Dim nDevNo As Integer
        Try
            nCh = cbSelChannel.SelectedIndex
            nDevNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        Catch ex As Exception
            Exit Sub
        End Try

        If nDevNo = -1 Then
            MsgBox("해당 채널은 제어할 수 있는 구동기가 없습니다.")
            Exit Sub
        End If

        If cG4S.PatternGenerator(0).IsConnectedSubChannel(nDevNo) = False Then
            MsgBox("구동기가 연결 되지 않았습니다.")
            Exit Sub
        End If

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
            cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevPGCommonNode.eSequenceState.eChangePattern_Befor)
        Else
            MsgBox("Select Channel is not IDEL")
        End If


        'If cG4S.PatternGenerator(m_nDevID).ChannelStatus(nDevNo) = CDevPGCommonNode.eSequenceState.eidle Then
        '    cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevPGCommonNode.eSequenceState.eChangePattern_Befor)
        'Else
        '    MsgBox("Select Channel is not IDEL")
        'End If

    End Sub

    Private Sub btnPatternChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatternChange.Click
        Dim nPatternNo As Integer
        Dim nCh As Integer
        Dim nDevNo As Integer
        Try
            nPatternNo = CInt(tbPatternNumber.Text)
            nCh = cbSelChannel.SelectedIndex
            nDevNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Exit Sub
        End Try

        If nDevNo = -1 Then
            MsgBox("해당 채널은 제어할 수 있는 구동기가 없습니다.")
            Exit Sub
        End If

        If cG4S.PatternGenerator(0).IsConnectedSubChannel(nDevNo) = False Then
            MsgBox("구동기가 연결 되지 않았습니다.")
            Exit Sub
        End If

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
            cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevPGCommonNode.eSequenceState.eSetPattern, nPatternNo)
        Else
            MsgBox("Select Channel is not IDEL")
        End If

        'If cG4S.PatternGenerator(m_nDevID).ChannelStatus(nDevNo) = CDevPGCommonNode.eSequenceState.eidle Then
        '    cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevPGCommonNode.eSequenceState.eSetPattern, nPatternNo)
        'Else
        '    MsgBox("Select Channel is not IDEL")
        'End If

    End Sub



    Private Sub cbSelDev_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelDev.SelectedIndexChanged
        m_nIP = cbSelDev.SelectedIndex
    End Sub



    Private Sub frmG4sTestUI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sTemp As String = ""

        If cG4S.PatternGenerator(m_nDevID).IsConnected = True Then
            Dim list() As String = cG4S.PatternGenerator(m_nDevID).ClientList
            For i As Integer = 0 To list.Length - 1
                sTemp = sTemp & list(i) & vbCrLf
            Next
            tbClientText(sTemp)
        End If

    End Sub



    Private Sub cG4S_evChangedConnectedClients(ByVal list() As String) Handles cG4S.evChangedConnectedClients

        Dim sTemp As String = ""

        For i As Integer = 0 To list.Length - 1
            sTemp = sTemp & list(i) & vbCrLf
        Next

        tbClientText(sTemp)
    End Sub

    Private Sub cG4S_evStatusMessage(ByVal msg As String) Handles cG4S.evStatusMessage
        tbServerMsgText(msg)
    End Sub


    '======================================================

    Private Sub btnSeqPowerON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeqPowerON.Click

        Dim nDevNo As Integer
        Dim nCh As Integer
        Try
            nCh = cbSelChannel.SelectedIndex
            nDevNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        Catch ex As Exception
            Exit Sub
        End Try

        If nDevNo = -1 Then
            MsgBox("해당 채널은 제어할 수 있는 구동기가 없습니다.")
            Exit Sub
        End If

        If cG4S.PatternGenerator(m_nDevID).IsConnectedSubChannel(nDevNo) = False Then
            MsgBox("구동기가 연결 되지 않았습니다.")
            Exit Sub
        End If

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
            cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevG4S.eSequenceState.eON)
        Else
            MsgBox("Select Channel is not IDEL")
        End If

    End Sub

    Private Sub btnSeqPowerOFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeqPowerOFF.Click
        Dim nCh As Integer
        Dim nDevNo As Integer
        Try
            nCh = cbSelChannel.SelectedIndex
            nDevNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        Catch ex As Exception
            Exit Sub
        End Try

        If nDevNo = -1 Then
            MsgBox("해당 채널은 제어할 수 있는 구동기가 없습니다.")
            Exit Sub
        End If

        If cG4S.PatternGenerator(0).IsConnectedSubChannel(nDevNo) = False Then
            MsgBox("구동기가 연결 되지 않았습니다.")
            Exit Sub
        End If

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
            cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevG4S.eSequenceState.eReset)
        Else
            MsgBox("Select Channel is not IDEL")
        End If


    End Sub

    Private Sub btnSeqAutoSlide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeqAutoSlide.Click
        Dim nCh As Integer
        Dim nDevNo As Integer
        Dim autoSlideInfos As CDevG4S.sG4SAutoSlideSettings
        Dim nPatternIdx() As Integer = New Integer() {0, 1, 2, 3, 4, 5, 6}
        Dim nPatternDelays() As Single = New Single() {0.5, 1, 1.5, 2, 2.5, 3, 3.5}   '{0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7}
        Try
            nCh = cbSelChannel.SelectedIndex
            nDevNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
            autoSlideInfos.nAutoSlidePatternIdx = nPatternIdx.Clone
            autoSlideInfos.dAutoSlideDelays = nPatternDelays.Clone
        Catch ex As Exception
            Exit Sub
        End Try

        If nDevNo = -1 Then
            MsgBox("해당 채널은 제어할 수 있는 구동기가 없습니다.")
            Exit Sub
        End If

        If cG4S.PatternGenerator(0).IsConnectedSubChannel(nDevNo) = False Then
            MsgBox("구동기가 연결 되지 않았습니다.")
            Exit Sub
        End If

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
            cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevG4S.eSequenceState.eAutoSlide, autoSlideInfos)
        Else
            MsgBox("Select Channel is not IDEL")
        End If

        'If cG4S.PatternGenerator(m_nDevID).ChannelStatus(nDevNo) = CDevPGCommonNode.eSequenceState.eidle Then
        '    cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevG4S.eSequenceState.eAutoSlide, autoSlideInfos)
        'Else
        '    MsgBox("Select Channel is not IDEL")
        'End If
    End Sub

    Private Sub btnSeqReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeqReset.Click
        Dim nCh As Integer
        Dim nDevNo As Integer
        Try
            nCh = cbSelChannel.SelectedIndex
            nDevNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        Catch ex As Exception
            Exit Sub
        End Try

        If nDevNo = -1 Then
            MsgBox("해당 채널은 제어할 수 있는 구동기가 없습니다.")
            Exit Sub
        End If

        If cG4S.PatternGenerator(0).IsConnectedSubChannel(nDevNo) = False Then
            MsgBox("구동기가 연결 되지 않았습니다.")
            Exit Sub
        End If

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
            cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevG4S.eSequenceState.eReset)
        Else
            MsgBox("Select Channel is not IDEL")
        End If

    End Sub


    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click

        btnConnection.Enabled = False
        cbSelChannel.Enabled = False
        GroupBox3.Enabled = False

        Dim sockInfos As CCommLib.CComSocket.sSockInfos
        sockInfos.sIPAddress = m_ConfigInfo.sServerIP
        sockInfos.nPort = m_ConfigInfo.nServerPort
        sockInfos.sRcvTerminator = ""
        sockInfos.sSendTerminator = ""
        cG4S.PatternGenerator(m_nDevID).Connection(sockInfos, m_ConfigInfo.nServerOpenTime_sec)

        'Application.DoEvents()
        'Thread.Sleep(m_ConfigInfo.nServerOpenTime_sec * 1000)


        btnConnection.Enabled = True
        cbSelChannel.Enabled = True
        GroupBox3.Enabled = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        cG4S.PatternGenerator(0).EnableEvent = False
        Me.Hide()
    End Sub


#End Region




    Private Sub btnDisconnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnection.Click

        Dim nDevNo As Integer
        Dim nCh As Integer

        If MsgBox("선택한 채널의 연결을 해제합니다. 정말 해제하시겠습니까?", MsgBoxStyle.OkCancel, g_strMainTitle) = MsgBoxResult.Cancel Then Exit Sub

        Try
            nCh = cbSelChannel.SelectedIndex
            nDevNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        Catch ex As Exception
            Exit Sub
        End Try

        If nDevNo = -1 Then
            MsgBox("해당 채널은 제어할 수 있는 구동기가 없습니다.")
            Exit Sub
        End If

        If cG4S.PatternGenerator(m_nDevID).IsConnectedSubChannel(nDevNo) = False Then
            MsgBox("구동기가 연결 되지 않았습니다.")
            Exit Sub
        End If

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
            cG4S.PatternGenerator(m_nDevID).Disconnection(nDevNo)
        Else
            MsgBox("Select Channel is not IDEL")
        End If


    End Sub



    Private Sub btnUpdateModelInfo_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdateModelInfo.Click
        m_sModelNames = cG4S.PatternGenerator(0).ModelNames

        If m_sModelNames Is Nothing Then
            MsgBox("Select Model")
            Exit Sub
        End If

        With cbSelModel
            .Items.Clear()
            For i As Integer = 0 To m_sModelNames.Length - 1
                .Items.Add(m_sModelNames(i))
            Next
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub btnUpdateAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateAll.Click
        If m_sModelNames Is Nothing Then Exit Sub
        If m_sModelNames.Length = 0 Then Exit Sub
        If m_sModelNames.Length <= cbSelModel.SelectedIndex Then Exit Sub

        Dim selectedModelName As String

        selectedModelName = m_sModelNames(cbSelModel.SelectedIndex)

        Dim nCh As Integer
        Dim nDevNo As Integer
        Try
            nCh = cbSelChannel.SelectedIndex
            nDevNo = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eDevNoOfGNTPG)
        Catch ex As Exception
            Exit Sub
        End Try

        If nDevNo = -1 Then
            MsgBox("해당 채널은 제어할 수 있는 구동기가 없습니다.")
            Exit Sub
        End If

        If cG4S.PatternGenerator(0).IsConnectedSubChannel(nDevNo) = False Then
            MsgBox("구동기가 연결 되지 않았습니다.")
            Exit Sub
        End If

        If myParent.cTimeScheduler.g_ChSchedulerStatus(nCh) = CScheduler.eChSchedulerSTATE.eIdle Then
            cG4S.PatternGenerator(m_nDevID).Request(nDevNo, CDevG4S.eSequenceState.eGnT_Update_DriveData_All, selectedModelName)
        Else
            MsgBox("Select Channel is not IDEL, IDEL 상태에서만 가능합니다. Power OFF 또는 Reset 후 재시도 하십시오.")
        End If
    End Sub

    Private Sub btnSetModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetModel.Click

        'If cG4S.UpdateModel(m_nDevID) = False Then

        'End If
    End Sub

    Private Sub btnSetPattern_Click(sender As System.Object, e As System.EventArgs) Handles btnSetPattern.Click

        'If cG4S.SendPatternList(m_nDevID) = False Then

        'End If

        'If cG4S.SendBMPImage(m_nDevID) = False Then

        'End If
    End Sub

    Private Sub btnSetInitial_Click(sender As System.Object, e As System.EventArgs) Handles btnSetInitial.Click
        'Lex_2015
        'If cG4S.TestBaseInitial(m_nDevID) = False Then

        'End If
    End Sub



    Private Sub cbSelModel_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbSelModel.SelectedIndexChanged
        If m_sModelNames Is Nothing Then Exit Sub
        If m_sModelNames.Length = 0 Then Exit Sub
        If m_sModelNames.Length <= cbSelModel.SelectedIndex Then Exit Sub

        cG4S.PatternGenerator(0).GnT_DriveData.ModelName = m_sModelNames(cbSelModel.SelectedIndex)

        If cG4S.PatternGenerator(0).GnT_DriveData.UpdateModelInfo() = False Then
            MsgBox("Error")
        End If

        Dim modelData As G4SDataLibrary.CDriveData.sModelTimeData
        Dim scenario As G4SDataLibrary.CDriveData.GNTIBinFile


        modelData = cG4S.PatternGenerator(0).GnT_DriveData.Read
        scenario = cG4S.PatternGenerator(0).GnT_DriveData.GNTIScenario
        'modelData.PatternName

        If cG4S.PatternGenerator(0).GnT_DriveData.UpdatePatternList(m_sPatternNames) = False Then
            MsgBox("Error")
            Exit Sub
        Else
            With cbSelPattern
                .Items.Clear()
                .Text = ""
                For i As Integer = 0 To m_sPatternNames.Length - 1
                    .Items.Add(m_sPatternNames(i))
                Next
                .SelectedText = modelData.PatternName
            End With
        End If

        cbSelIniti.Text = scenario.Name

        '===============================
        If cG4S.PatternGenerator(0).GnT_DriveData.UpdatePatternListInfo(modelData.PatternName) = False Then
            MsgBox("Error Pattern Info")
            Exit Sub
        End If

        If cG4S.PatternGenerator(0).GnT_DriveData.UpdatePatternImage() = False Then
            MsgBox("Pattern Image Update Error")
            Exit Sub
        End If

        If cG4S.PatternGenerator(0).GnT_DriveData.LoadGNTIScenario() = False Then
            MsgBox("GNTI Scenario File not found")
            Exit Sub
        End If

    End Sub
End Class