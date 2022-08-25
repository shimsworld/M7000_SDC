Imports System.Threading

Public Class frmPLCControl

    Dim m_Main As frmMain


#Region "Create, Dispose and Init"

    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_Main = main
        Dim StatusCaptions() As String = m_Main.cPLC.PLCSignalInfo.sStatusCaptions.Clone  ' CDevPLC.sStatusCaption.Clone
        Dim SupplyStatusCaptions() As String = m_Main.cPLC.PLCSignalInfo.sMagazineInfos.sSupply.sStatusCaption.Clone
        Dim ExhausStatusCaption() As String = m_Main.cPLC.PLCSignalInfo.sMagazineInfos.sExhaus.sStatusCaption.Clone
        Dim ContactInspectionCaption() As String = m_Main.cPLC.PLCSignalInfo.sMagazineInfos.sContact.sContactIspectionStatusCaption.Clone
        Dim EQPStatusCaption() As String = m_Main.cPLC.PLCSignalInfo.nEQPStatusCaption.Clone

        With cbSelStatus
            .Items.Clear()
            For i As Integer = 0 To StatusCaptions.Length - 1
                .Items.Add(StatusCaptions(i))
            Next
            .SelectedIndex = 0
        End With

        With cbSelEQPState
            .Items.Clear()
            For i As Integer = 0 To EQPStatusCaption.Length - 1
                .Items.Add(EQPStatusCaption(i))
            Next
            .SelectedIndex = 0
        End With

        With cbSelSupplyStatus
            .Items.Clear()
            For i As Integer = 0 To SupplyStatusCaptions.Length - 1
                .Items.Add(SupplyStatusCaptions(i))
            Next
            .SelectedIndex = 0
        End With

        With cbSelExhausStatus
            .Items.Clear()
            For i As Integer = 0 To ExhausStatusCaption.Length - 1
                .Items.Add(ExhausStatusCaption(i))
            Next
            .SelectedIndex = 0
        End With

        With cbSelContactInspectionStatus
            .Items.Clear()
            For i As Integer = 0 To ContactInspectionCaption.Length - 1
                .Items.Add(ContactInspectionCaption(i))
            Next
            .SelectedIndex = 0
        End With

        ' cbBaudRate.SelectedIndex = 2
    End Sub
#End Region

    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click

        Dim sConfigInfo As CCommLib.CComCommonNode.sCommInfo = Nothing '.sSerialPortInfo 'CCommLib.CComCommonNode.sCommInfo = Nothing

        With sConfigInfo.sSerialInfo
            Dim Address As String = txtIP1.Text & "." & txtIP2.Text & "." & txtIP3.Text & "." & txtIP4.Text
            sConfigInfo.sLanInfo.sIPAddress = Address

        End With

        ' m_Main.cPLC.Disconnection()

        If m_Main.cPLC.Connection(sConfigInfo) = False Then
            MsgBox("Open Fail...")
            btnSend.Enabled = False
            ledConnectionStateCheck.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
            Exit Sub
        End If

        ledConnectionStateCheck.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink

        Timer1.Enabled = True
        btnSend.Enabled = True
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnection.Click
        m_Main.cPLC.Disconnection()
        btnSend.Enabled = False
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Dim sCommand As String '= "00WSS0106%DW0200001" '& "00RSS0106%DW010"
        Dim sRcvData As String = ""

        sCommand = TextBox1.Text
        'aaa m_Main.cPLC.myPLC.SendTestCommand(sCommand, sRcvData)

        TextBox2.Text = sRcvData
    End Sub


    Private Sub btnSetStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetStatus.Click

        Dim selIdx As Integer = cbSelStatus.SelectedIndex

        Dim state As CDevPLCCommonNode.eSystemStatus = selIdx
        'Dim state As CDevPLCCommonNode.eSystemStatus = CDevPLC.nStatusValue(selIdx)

        'If selIdx = 0 Then
        '    state = CDevPLC.eSystemStatus.eDown
        'Else
        '    state = 2 ^ (selIdx - 1)
        'End If

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eSetStatus
        reqInfo.nSYSStatus = state ' CDevPLC.eSystemStatus.ePauseAndProcess 'state

        m_Main.cPLC.Request(reqInfo)

    End Sub

    Private Sub btnGetStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetStatus.Click
    End Sub
    Private Sub btnGetSupplyStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetSupplyStatus.Click
    End Sub
    Private Sub btnGetExhausStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetExhausStatus.Click
    End Sub
    Private Sub btnGetContactInspectionStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetContactInspectionStatus.Click
    End Sub

    Private Sub btnSetSupplyStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetSupplyStatus.Click
        Dim selIdx As Integer = cbSelSupplyStatus.SelectedIndex

        Dim state As CDevPLCCommonNode.eMagazineStatus = selIdx

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eSetMagazineSupplyStatus
        reqInfo.nMagazineStatus = state

        m_Main.cPLC.Request(reqInfo)
    End Sub

    Private Sub btnSetExhausStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetExhausStatus.Click
        Dim selIdx As Integer = cbSelExhausStatus.SelectedIndex

        Dim state As CDevPLCCommonNode.eMagazineStatus = selIdx

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eSetMagazineExhausStatus
        reqInfo.nMagazineStatus = state

        m_Main.cPLC.Request(reqInfo)
    End Sub

    Private Sub btnSetContactInspectionStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetContactInspectionStatus.Click
        Dim selIdx As Integer = cbSelContactInspectionStatus.SelectedIndex

        Dim state As CDevPLCCommonNode.eMagazineStatus = selIdx

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eSetMagazineContactInspection
        reqInfo.nMagazineContactInspection = state

        m_Main.cPLC.Request(reqInfo)
    End Sub



    Private Sub btnSetDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDI.Click
        'Dim selIdx As Integer = cbSelStatus.SelectedIndex

        'Dim state As CDevPLC.eSystemStatus ' = 2 ^ selIdx

        'If selIdx = 0 Then
        '    state = CDevPLC.eSystemStatus.eDown
        'Else
        '    state = 2 ^ (selIdx - 1)
        'End If
        'If cPLC.SetAlarm(state) = False Then
        '    MsgBox("Error")
        'End If
    End Sub

    Private Sub btnGetDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDI.Click
        'Dim state() As CDevPLC.eDISignal
        'If cPLC.GetAlarm(state) = False Then
        '    MsgBox("Error")
        'End If
    End Sub

    Private Sub btnSetDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDO.Click
        'Dim selIdx As Integer = cbSelStatus.SelectedIndex

        'Dim state As CDevPLC.eSystemStatus ' = 2 ^ selIdx

        'If selIdx = 0 Then
        '    state = CDevPLC.eSystemStatus.eDown
        'Else
        '    state = 2 ^ (selIdx - 1)
        'End If

        'If cPLC.SetDOSignal(state) = False Then
        '    MsgBox("Error")
        'End If

        Dim selIdx As Integer = cbSelDOSignal.SelectedIndex

        Dim state As CDevPLCCommonNode.eMagazineStatus = selIdx

        Dim reqInfo As CDevPLCCommonNode.sRequestInfo

        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eSetDOStatus
        reqInfo.nDOStatus = state

        m_Main.cPLC.Request(reqInfo)

    End Sub

    Private Sub btnGetDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDO.Click
        Dim Datas As CDevPLCCommonNode.sPLCDatas = Nothing

        Datas = m_Main.cPLC.Datas

        ' Datas.nDOSignal()


        'Dim state() As CDevPLC.eDOSignal
        'If cPLC.GetDOSignal(state) = False Then
        '    MsgBox("Error")
        'End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        m_Main.cPLC.Dispose()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cbSelStatus.SelectedIndex = 0
        cbSelDISignal.SelectedIndex = 0
        cbSelDOSignal.SelectedIndex = 0
        cbSelSupplyStatus.SelectedIndex = 0
        cbSelExhausStatus.SelectedIndex = 0
        cbSelEQPState.SelectedIndex = 0

        ledSysStatus_PowerON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_PowerDown.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
        ledSysStatus_TeachingMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_AutoMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_ManualMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_Processing.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_SystemLoading.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

        ledAlarm_Hitter_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

        ledConnectionStateCheck.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

        MagazineSlotLEDInit(eMagazineShape.eSupply)

        EQPAlarmLEDInit()
        AxisAlarmLEDInit()
        ServoAlarmLEDInit()
        EQPStatusLEDInit()

        MagazineSlotLEDInit(eMagazineShape.eExhaus)

        AlarmDoorLEDInit()
        EmsAlarmLEDInit()
        HitterAlarmLEDInit()
        HitterEOCRAlarmLEDInit()
        HitterSSRAlarmLEDInit()
        HitterOverZone1AlarmLEDInit()
        HitterOverZone2AlarmLEDInit()
        LoaderAxisAlarmLEDInit()
        UnLoaderAxisAlarmLEDInit()
        HitterAxisAlarmLEDInit()
        XAxisAlarmLEDInit()
        YAxisAlarmLEDInit()
        ZAxisAlarmLEDInit()

    End Sub

    Public Enum eMagazineShape
        eSupply
        eExhaus
    End Enum

#Region "LEDInit"

    Private Sub AlarmDoorLEDInit()
        ledDoorAlarm_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledDoorAlarm_Safety_Door.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledDoorAlarm_Door1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledDoorAlarm_Door2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledDoorAlarm_Door3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledDoorAlarm_Door4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledDoorAlarm_Door5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledDoorAlarm_Door6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledDoorAlarm_Door7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledDoorAlarm_Door8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub

    Private Sub AlarmTemperatureLEDInit()
        ledAxisAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
        ledAxisAlarm_YAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_ZAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_Y2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_THETA1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_THETA2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_THETA3Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_THETA4Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_NONE2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_NONE3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub

    Private Sub AlarmTemperatureControlLEDInit()
        ledEQPAlarm_None.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
        ledEQPAlarm_None2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEQPAlarm_Light.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEQPAlarm_Heavy.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub


    Private Sub MagazineErrorLEDInit()
        ledMagazineErrorStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
        ledMagazineErrorStatus_Reserved01.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledMagazineErrorStatus_Reserved02.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledMagazineErrorStatus_Reserved03.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledMagazineErrorStatus_Reserved04.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledMagazineErrorStatus_Reserved05.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledMagazineErrorStatus_Reserved06.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledMagazineErrorStatus_Reserved07.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub MagazineStatusLEDInit(ByVal nMagazine As eMagazineShape)
        Select Case nMagazine
            Case eMagazineShape.eSupply
                ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                ledSupplySLOT1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

            Case eMagazineShape.eExhaus
                ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                ledExhausSLOT1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        End Select

    End Sub
    Private Sub MagazinePositionLEDInit(ByVal nMagazine As eMagazineShape)
        Select Case nMagazine
            Case eMagazineShape.eSupply
                ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplyPositionStatus_Slot01.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplyPositionStatus_Slot02.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplyPositionStatus_Slot03.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplyPositionStatus_Slot04.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplyPositionStatus_Slot05.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplyPositionStatus_Slot06.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplyPositionStatus_Slot07.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplyPositionStatus_Slot08.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplyPositionStatus_Slot09.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplyPositionStatus_Slot10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

            Case eMagazineShape.eExhaus
                ledExhausPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausPositionStatus_Slot01.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausPositionStatus_Slot02.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausPositionStatus_Slot03.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausPositionStatus_Slot04.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausPositionStatus_Slot05.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausPositionStatus_Slot06.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausPositionStatus_Slot07.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausPositionStatus_Slot08.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausPositionStatus_Slot09.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausPositionStatus_Slot10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        End Select
    End Sub
    Private Sub EQPStatusLEDInit()
        ledEQPStatus_RUN.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEQPStatus_STOP.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEQPStatus_PAUSE.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEQPStatus_Reset.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub MagazineSlotLEDInit(ByVal nMagazine As eMagazineShape)
        Select Case nMagazine
            Case eMagazineShape.eSupply
                ledSupplyNone.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledSupplySLOT10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

            Case eMagazineShape.eExhaus
                ledExhausNone.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                ledExhausSLOT10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        End Select
    End Sub
    Private Sub EQPAlarmLEDInit()
        ledEQPAlarm_None.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEQPAlarm_None2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEQPAlarm_Light.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEQPAlarm_Heavy.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub

    Private Sub AxisAlarmLEDInit()
        ledAxisAlarm_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

        ledAxisAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_YAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_ZAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off


        ledAxisAlarm_Y2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_THETA1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_THETA2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

        ledAxisAlarm_THETA3Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_THETA4Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_NONE2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_NONE3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

        ledAxisAlarm_STOPERAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_ALIGNAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAxisAlarm_ContactAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

    End Sub

    Private Sub ServoAlarmLEDInit()
        ledServoAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledServoAlarm_Y1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledServoAlarm_ZAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

        ledServoAlarm_Y2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledServoAlarm_Theta1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledServoAlarm_Theta2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

        ledServoAlarm_Theta3Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledServoAlarm_Theta4Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledServoAlarm_NONE2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledServoAlarm_NONE3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

        ledServoAlarm_Stoper.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledServoAlarm_Align.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledServoAlarm_Contact.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub

    Private Sub EmsAlarmLEDInit()
        ledEMSAlarm_NO_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEMSAlarm_EMS.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEMSAlarm_EMS2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEMSAlarm_TempLight.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEMSAlarm_TempHeavy.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEMSAlarm_SMOKE.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEMSAlarm_MC1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEMSAlarm_MC2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEMSAlarm_Safety1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledEMSAlarm_Safety2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub HitterAlarmLEDInit()
        ledAlarm_Hitter_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub HitterEOCRAlarmLEDInit()
        ledAlarm_HitterEOCR_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterEOCR_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterEOCR_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterEOCR_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterEOCR_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterEOCR_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterEOCR_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterEOCR_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterEOCR_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterEOCR_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub HitterSSRAlarmLEDInit()
        ledAlarm_HitterSSR_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterSSR_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterSSR_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterSSR_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterSSR_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterSSR_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterSSR_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterSSR_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterSSR_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterSSR_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub HitterOverZone1AlarmLEDInit()
        ledAlarm_HitterOverZone1_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone1_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone1_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone1_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone1_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone1_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone1_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone1_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone1_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone1_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub HitterOverZone2AlarmLEDInit()
        ledAlarm_HitterOverZone2_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone2_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone2_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone2_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone2_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone2_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone2_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone2_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone2_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterOverZone2_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub LoaderAxisAlarmLEDInit()
        ledAlarm_LoaderAxis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_LoaderAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_LoaderAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub UnLoaderAxisAlarmLEDInit()
        ledAlarm_UnLoaderAxis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_UnLoaderAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_UnLoaderAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub HitterAxisAlarmLEDInit()
        ledAlarm_HitterAxis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_HitterAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub XAxisAlarmLEDInit()
        ledAlarm_XAxis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_XAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_XAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub YAxisAlarmLEDInit()
        ledAlarm_YAxis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_YAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_YAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub ZAxisAlarmLEDInit()
        ledAlarm_ZAxis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_ZAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_ZAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub Theta1AxisAlarmLEDInit()
        ledAlarm_Theta1Axis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Theta1Axis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Theta1Axis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub Theta2AxisAlarmLEDInit()
        ledAlarm_Theta2Axis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Theta2Axis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Theta2Axis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub Theta3AxisAlarmLEDInit()
        ledAlarm_Theta3Axis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Theta3Axis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Theta3Axis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
    Private Sub Theta4AxisAlarmLEDInit()
        ledAlarm_Theta4Axis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Theta4Axis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Theta4Axis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
    End Sub
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim nInValue As Integer = tbInDex.Text
        Dim nBinery(7) As Integer

        If nInValue < 0 Or nInValue > 255 Then
            MsgBox("Input Value : 0 ~ 255")
            Exit Sub
        End If

        'aaaaaaaa
        nBinery = CDevPLCCommonNode.DecToBinery(nInValue) ' CDevPLC.DecToBinery(nInValue)

        Dim str As String = ""

        For i As Integer = nBinery.Length - 1 To 0 Step -1
            str = str & CStr(nBinery(i))
        Next
        tbOutBinery.Text = str
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim nInValue As String = TextBox3.Text
        Dim nBinery() As Integer = Nothing
        'If nInValue < 0 Or nInValue > 255 Then
        '    MsgBox("Input Value : 0 ~ 255")
        '    Exit Sub
        'End If


        'aaa nBinery = m_Main.cPLC.myPLC.hex2bin(nInValue)

        Dim str As String = ""

        Try
            For i As Integer = nBinery.Length - 1 To 0 Step -1
                str = str & CStr(nBinery(i))
            Next
        Catch ex As Exception
            MsgBox("입력 값을 확인해 주세요...")
        End Try

        TextBox4.Text = str

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Timer1.Enabled = False

        ledSysStatus_PowerDown.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_TeachingMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_AutoMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_ManualMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_Processing.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledSysStatus_SystemLoading.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

        For i As Integer = 0 To m_Main.cPLC.Datas.nSystemStatus.Length - 1

            Select Case m_Main.cPLC.Datas.nSystemStatus(i)

                Case CDevPLCCommonNode.eSystemStatus.ePower_On
                    ledSysStatus_PowerON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledConnectionStateCheck.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledConnectionStateCheck.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink
                Case CDevPLCCommonNode.eSystemStatus.ePower_Down
                    ledSysStatus_PowerDown.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledConnectionStateCheck.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    ' ledSysStatus_PowerON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eSystemStatus.eTeaching_Mode
                    ledSysStatus_TeachingMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ' ledSysStatus_PowerON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eSystemStatus.eAuto_Mode
                    ledSysStatus_AutoMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    'ledSysStatus_PowerON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eSystemStatus.eManual_Mode
                    ledSysStatus_ManualMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ' ledSysStatus_PowerON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eSystemStatus.eProcessing
                    ledSysStatus_Processing.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eSystemStatus.eLoading
                    ledSysStatus_SystemLoading.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledSysStatus_SystemIDLE.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eSystemStatus.eIDEL
                    ledSysStatus_SystemIDLE.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledSysStatus_SystemLoading.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
            End Select
        Next

        ledAlarm_Hitter_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        ledAlarm_Hitter_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off

        For i As Integer = 0 To m_Main.cPLC.Datas.nDISignal.Length - 1
            Select Case m_Main.cPLC.Datas.nDISignal(i)

                Case CDevPLCCommonNode.eDISignal.eNoError
                    ledAlarm_Hitter_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    ledAlarm_Hitter_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    ledAlarm_Hitter_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    ledAlarm_Hitter_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    ledAlarm_Hitter_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    ledAlarm_Hitter_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    ledAlarm_Hitter_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    ledAlarm_Hitter_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    ledAlarm_Hitter_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    ledAlarm_Hitter_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eDISignal.eEmergency
                    ledAlarm_Hitter_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDISignal.eFire
                    ledAlarm_Hitter_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDISignal.eHeater
                    ledAlarm_Hitter_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDISignal.eCurrentLimit
                    ledAlarm_Hitter_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDISignal.eInterlock
                    ledAlarm_Hitter_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDISignal.eCylinder
                    ledAlarm_Hitter_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDISignal.eDoorOpen
                    ledAlarm_Hitter_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDISignal.eSupply
                    ledAlarm_Hitter_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDISignal.eInspectionStage
                    ledAlarm_Hitter_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDISignal.eExhaus
                    ledAlarm_Hitter_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next

        'MagazineSlotLEDControl(eMagazineShape.eSupply)
        'MagazineSlotLEDControl(eMagazineShape.eExhaus)

        EQPAlramLEDControl()
        AxisAlarmLEDControl()
        ServoAlramLEDControl()
        EQPStateLEDControl()

        DoorAlarmLEDControl()
        EMSAlarmLEDControl()
        'HitterAlarmLEDControl()
        'HitterEOCRAlarmLEDControl()
        'HitterSSRAlarmLEDControl()
        'HitterOVERZONE1AlarmLEDControl()
        'HitterOVERZONE2AlarmLEDControl()
        'LoaderAxisAlarmLEDControl()
        'UnLoaderAxisAlarmLEDControl()
        ' HitterAxisAlarmLEDControl()
        xAxisAlarmLEDControl()
        YAxisAlarmLEDControl()
        zAxisAlarmLEDControl()
        Theta1AxisAlarmLEDControl()
        Theta2AxisAlarmLEDControl()
        Theta3AxisAlarmLEDControl()
        Theta4AxisAlarmLEDControl()

        'MagazinePositionLEDControl(eMagazineShape.eSupply)
        'MagazineStatusLEDControl(eMagazineShape.eSupply)

        'MagazineSlotLEDControl(eMagazineShape.eExhaus)
        'MagazinePositionLEDControl(eMagazineShape.eExhaus)
        'MagazineStatusLEDControl(eMagazineShape.eExhaus)

        'MagazineErrorLEDControl()
        ''   MagazineInspectionStatusLEDControl()

        'AlarmDoorLEDControl()
        'AlarmTemperatureLEDControl()
        'AlarmTemperatureControlLEDControl()
        '  AlarmPCBInfoLEDControl()
        '  AlarmConbareLEDControl()
        '  AlarmLiftSensorLEDControl()

        Timer1.Enabled = True
    End Sub

#Region "LEDControl"

    Private Sub EQPAlramLEDControl()

        EQPAlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nEQPAlaram.Length - 1
            Select Case m_Main.cPLC.Datas.nEQPAlaram(i)
                Case CDevPLCCommonNode.eEQPLightAlaram.eNoError
                    ledEQPAlarm_None.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ' ledEQPAlarm_None2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEQPLightAlaram.eLightAlaram
                    ledEQPAlarm_Light.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEQPLightAlaram.eHeavyAlaram
                    ledEQPAlarm_Heavy.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next
    End Sub
    Private Sub DoorAlarmLEDControl()
        AlarmDoorLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nDoorAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nDoorAlarm(i)
                Case CDevPLCCommonNode.eDoorAlarm.eNoError
                    ledDoorAlarm_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_Loop
                    ledDoorAlarm_Safety_Door.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_1
                    ledDoorAlarm_Door1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_2
                    ledDoorAlarm_Door2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_3
                    ledDoorAlarm_Door3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_4
                    ledDoorAlarm_Door4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_5
                    ledDoorAlarm_Door5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_6
                    ledDoorAlarm_Door6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_7
                    ledDoorAlarm_Door7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eDoorAlarm.eSafety_Door_8
                    ledDoorAlarm_Door8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next
    End Sub

    Private Sub EMSAlarmLEDControl()
        EmsAlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nEmsAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nEmsAlarm(i)
                Case CDevPLCCommonNode.eEMSAlarm.eNoError
                    ledEMSAlarm_NO_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eEMS1
                    ledEMSAlarm_EMS.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eEMS2
                    ledEMSAlarm_EMS2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eControlBoxTempLightAlarm
                    ledEMSAlarm_TempLight.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eControlBoxTempHeavyAlarm
                    ledEMSAlarm_TempHeavy.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eControlBoxSmokeAlarm
                    ledEMSAlarm_SMOKE.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eSafety_Control_Alarm1
                    ledEMSAlarm_Safety1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eSafety_Control_Alarm2
                    ledEMSAlarm_Safety2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eMC1_POWEROFF_Alarm
                    ledEMSAlarm_MC1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eMC2_POWEROFF_Alarm
                    ledEMSAlarm_MC2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next

    End Sub
    Private Sub HitterAlarmLEDControl()
        HitterAlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nStrangeTempAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nStrangeTempAlarm(i)
                Case CDevPLCCommonNode.eTemperatureAlarm.eNoError
                    ledAlarm_Hitter_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT1
                    ledAlarm_Hitter_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
                    ledAlarm_Hitter_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
                    ledAlarm_Hitter_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
                    ledAlarm_Hitter_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
                    ledAlarm_Hitter_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT6
                    ledAlarm_Hitter_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT7
                    ledAlarm_Hitter_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT8
                    ledAlarm_Hitter_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT9
                    ledAlarm_Hitter_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next

    End Sub
    Private Sub HitterEOCRAlarmLEDControl()
        HitterEOCRAlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nEOCRTempAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nEOCRTempAlarm(i)
                Case CDevPLCCommonNode.eTemperatureAlarm.eNoError
                    ledAlarm_HitterEOCR_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT1
                    ledAlarm_HitterEOCR_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
                    ledAlarm_HitterEOCR_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
                    ledAlarm_HitterEOCR_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
                    ledAlarm_HitterEOCR_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
                    ledAlarm_HitterEOCR_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT6
                    ledAlarm_HitterEOCR_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT7
                    ledAlarm_HitterEOCR_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT8
                    ledAlarm_HitterEOCR_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT9
                    ledAlarm_HitterEOCR_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next

    End Sub
    Private Sub HitterSSRAlarmLEDControl()
        HitterSSRAlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nSSRTempAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nSSRTempAlarm(i)
                Case CDevPLCCommonNode.eTemperatureAlarm.eNoError
                    ledAlarm_HitterSSR_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT1
                    ledAlarm_HitterSSR_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
                    ledAlarm_HitterSSR_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
                    ledAlarm_HitterSSR_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
                    ledAlarm_HitterSSR_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
                    ledAlarm_HitterSSR_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT6
                    ledAlarm_HitterSSR_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT7
                    ledAlarm_HitterSSR_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT8
                    ledAlarm_HitterSSR_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT9
                    ledAlarm_HitterSSR_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next

    End Sub
    Private Sub HitterOVERZONE1AlarmLEDControl()
        HitterOverZone1AlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nOverTempAlarm_Zone1.Length - 1
            Select Case m_Main.cPLC.Datas.nOverTempAlarm_Zone1(i)
                Case CDevPLCCommonNode.eTemperatureAlarm.eNoError
                    ledAlarm_HitterOverZone1_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT1
                    ledAlarm_HitterOverZone1_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
                    ledAlarm_HitterOverZone1_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
                    ledAlarm_HitterOverZone1_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
                    ledAlarm_HitterOverZone1_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
                    ledAlarm_HitterOverZone1_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT6
                    ledAlarm_HitterOverZone1_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT7
                    ledAlarm_HitterOverZone1_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT8
                    ledAlarm_HitterOverZone1_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT9
                    ledAlarm_HitterOverZone1_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next
    End Sub
    Private Sub HitterOVERZONE2AlarmLEDControl()
        HitterOverZone2AlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nOverTempAlarm_Zone2.Length - 1
            Select Case m_Main.cPLC.Datas.nOverTempAlarm_Zone2(i)
                Case CDevPLCCommonNode.eTemperatureAlarm.eNoError
                    ledAlarm_HitterOverZone2_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT1
                    ledAlarm_HitterOverZone2_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
                    ledAlarm_HitterOverZone2_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
                    ledAlarm_HitterOverZone2_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
                    ledAlarm_HitterOverZone2_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
                    ledAlarm_HitterOverZone2_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT6
                    ledAlarm_HitterOverZone2_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT7
                    ledAlarm_HitterOverZone2_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT8
                    ledAlarm_HitterOverZone2_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT9
                    ledAlarm_HitterOverZone2_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next
    End Sub
    Private Sub LoaderAxisAlarmLEDControl()
        LoaderAxisAlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nLoaderAxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nLoaderAxisAlarm(i)
                Case CDevPLCCommonNode.eAxisAlarm.eNoError
                    ledAlarm_LoaderAxis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                    ledAlarm_LoaderAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                    ledAlarm_LoaderAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next

    End Sub
    Private Sub UnLoaderAxisAlarmLEDControl()
        UnLoaderAxisAlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nUnLoaderAxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nUnLoaderAxisAlarm(i)
                Case CDevPLCCommonNode.eAxisAlarm.eNoError
                    ledAlarm_UnLoaderAxis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                    ledAlarm_UnLoaderAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                    ledAlarm_UnLoaderAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next

    End Sub
    Private Sub HitterAxisAlarmLEDControl()
        HitterAxisAlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nHitterAxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nHitterAxisAlarm(i)
                Case CDevPLCCommonNode.eAxisAlarm.eNoError
                    ledAlarm_HitterAxis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                    ledAlarm_HitterAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                    ledAlarm_HitterAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next

    End Sub
    Private Sub xAxisAlarmLEDControl()
        XAxisAlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nXAxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nXAxisAlarm(i)
                Case CDevPLCCommonNode.eAxisAlarm.eNoError
                    ledAlarm_XAxis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                    ledAlarm_XAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                    ledAlarm_XAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next

    End Sub
    Private Sub YAxisAlarmLEDControl()
        YAxisAlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nYAxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nYAxisAlarm(i)
                Case CDevPLCCommonNode.eAxisAlarm.eNoError
                    ledAlarm_YAxis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                    ledAlarm_YAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                    ledAlarm_YAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next

    End Sub
    Private Sub zAxisAlarmLEDControl()
        ZAxisAlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nZAxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nZAxisAlarm(i)
                Case CDevPLCCommonNode.eAxisAlarm.eNoError
                    ledAlarm_ZAxis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                    ledAlarm_ZAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                    ledAlarm_ZAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next

    End Sub

    Private Sub Theta1AxisAlarmLEDControl()
        Theta1AxisAlarmLEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nTheta1AxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nTheta1AxisAlarm(i)
                Case CDevPLCCommonNode.eAxisAlarm.eNoError
                    ledAlarm_Theta1Axis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                    ledAlarm_Theta1Axis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                    ledAlarm_Theta1Axis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next
    End Sub
    Private Sub Theta2AxisAlarmLEDControl()
        Theta2AxisAlarmLEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nTheta2AxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nTheta2AxisAlarm(i)
                Case CDevPLCCommonNode.eAxisAlarm.eNoError
                    ledAlarm_Theta2Axis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                    ledAlarm_Theta2Axis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                    ledAlarm_Theta2Axis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On

            End Select
        Next
    End Sub
    Private Sub Theta3AxisAlarmLEDControl()
        Theta3AxisAlarmLEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nTheta3AxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nTheta3AxisAlarm(i)
                Case CDevPLCCommonNode.eAxisAlarm.eNoError
                    ledAlarm_Theta3Axis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                    ledAlarm_Theta3Axis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                    ledAlarm_Theta3Axis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On

            End Select
        Next
    End Sub
    Private Sub Theta4AxisAlarmLEDControl()
        Theta4AxisAlarmLEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nTheta4AxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nTheta4AxisAlarm(i)
                Case CDevPLCCommonNode.eAxisAlarm.eNoError
                    ledAlarm_Theta4Axis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                    ledAlarm_Theta4Axis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                    ledAlarm_Theta4Axis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next
    End Sub
    Private Sub ServoAlramLEDControl()

        ServoAlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nServoAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nServoAlarm(i)
                ' Case CDevPLCCommonNode.eServoAlarm.eX_Axis_Servo_ON
                ' ledServoAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eServoAlarm.eY1_Axis_Servo_ON
                    ledServoAlarm_Y1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eServoAlarm.eZ_Axis_Servo_ON
                    ledServoAlarm_ZAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eServoAlarm.eTheta1_Axis_Servo_ON
                    ledServoAlarm_Theta1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eServoAlarm.eTheta2_Axis_Servo_ON
                    ledServoAlarm_Theta2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eServoAlarm.eTheta3_Axis_Servo_ON
                    ledServoAlarm_Theta3Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eServoAlarm.eTheta4_Axis_Servo_ON
                    ledServoAlarm_Theta4Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ' Case CDevPLCCommonNode.eServoAlarm.eY2_Axis_Servo_ON
                    '   ledServoAlarm_Y2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On

            End Select
        Next
    End Sub

    Private Sub AxisAlarmLEDControl()

        AxisAlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nAxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nAxisAlarm(i)
                Case CDevPLCCommonNode.eAllAxisAlarm.eNoError
                    ledAxisAlarm_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    'Case CDevPLCCommonNode.eAllAxisAlarm.eX_Axis_Alarm
                    '    ledAxisAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAllAxisAlarm.eY1_Axis_Alarm
                    ledAxisAlarm_YAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAllAxisAlarm.eZ_Axis_Alarm
                    ledAxisAlarm_ZAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAllAxisAlarm.eTheta1_Axis_Alarm
                    ledAxisAlarm_THETA1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAllAxisAlarm.eTheta2_Axis_Alarm
                    ledAxisAlarm_THETA2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAllAxisAlarm.eTheta3_Axis_Alarm
                    ledAxisAlarm_THETA3Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAllAxisAlarm.eTheta4_Axis_Alarm
                    ledAxisAlarm_THETA4Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    'Case CDevPLCCommonNode.eAllAxisAlarm.eY2_Axis_Alarm
                    '    ledAxisAlarm_Y2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On

            End Select
        Next

    End Sub
    Private Sub EQPStateLEDControl()

        EQPStatusLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nEQPState.Length - 1
            Select Case m_Main.cPLC.Datas.nEQPState(i)
                Case CDevPLCCommonNode.eEQPStatus.eRun
                    ledEQPStatus_RUN.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEQPStatus.eStop
                    ledEQPStatus_STOP.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEQPStatus.ePause
                    ledEQPStatus_RUN.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEQPStatus.eReset
                    ledEQPStatus_Reset.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next
    End Sub

    Private Sub MagazineSlotLEDControl(ByVal nMagazineType As eMagazineShape)

        MagazineSlotLEDInit(nMagazineType)

        If nMagazineType = eMagazineShape.eSupply Then
            For i As Integer = 0 To m_Main.cPLC.Datas.nSupplySlotSignal.Length - 1
                Select Case m_Main.cPLC.Datas.nSupplySlotSignal(i)
                    Case CDevPLCCommonNode.eSlotSignal.eNone
                        ledSupplyNone.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot00
                        ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot01
                        ledSupplySLOT1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot02
                        ledSupplySLOT2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot03
                        ledSupplySLOT3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot04
                        ledSupplySLOT4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot05
                        ledSupplySLOT5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot06
                        ledSupplySLOT6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot07
                        ledSupplySLOT7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot08
                        ledSupplySLOT8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot09
                        ledSupplySLOT9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot10
                        ledSupplySLOT10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                End Select
            Next

        ElseIf nMagazineType = eMagazineShape.eExhaus Then
            For i As Integer = 0 To m_Main.cPLC.Datas.nExhausSlotSignal.Length - 1
                Select Case m_Main.cPLC.Datas.nExhausSlotSignal(i)
                    Case CDevPLCCommonNode.eSlotSignal.eNone
                        ledExhausNone.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot00
                        ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot01
                        ledExhausSLOT1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot02
                        ledExhausSLOT2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot03
                        ledExhausSLOT3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot04
                        ledExhausSLOT4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot05
                        ledExhausSLOT5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot06
                        ledExhausSLOT6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot07
                        ledExhausSLOT7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot08
                        ledExhausSLOT8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot09
                        ledExhausSLOT9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eSlotSignal.eSlot10
                        ledExhausSLOT10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                End Select
            Next
        End If

    End Sub

    Private Sub MagazinePositionLEDControl(ByVal nMagazineType As eMagazineShape)

        MagazinePositionLEDInit(nMagazineType)

        If nMagazineType = eMagazineShape.eSupply Then
            For i As Integer = 0 To m_Main.cPLC.Datas.nSupplyPositionSignal.Length - 1
                Select Case m_Main.cPLC.Datas.nSupplyPositionSignal(i)
                    Case CDevPLCCommonNode.ePositionSignal.eNone
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.ePositionSignal.ePosition01
                        ledSupplyPositionStatus_Slot01.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition02
                        ledSupplyPositionStatus_Slot02.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition03
                        ledSupplyPositionStatus_Slot03.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition04
                        ledSupplyPositionStatus_Slot04.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition05
                        ledSupplyPositionStatus_Slot05.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition06
                        ledSupplyPositionStatus_Slot06.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition07
                        ledSupplyPositionStatus_Slot07.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition08
                        ledSupplyPositionStatus_Slot08.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition09
                        ledSupplyPositionStatus_Slot09.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition10
                        ledSupplyPositionStatus_Slot10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                End Select
            Next
        ElseIf nMagazineType = eMagazineShape.eExhaus Then
            For i As Integer = 0 To m_Main.cPLC.Datas.nExhausPositionSignal.Length - 1
                Select Case m_Main.cPLC.Datas.nExhausPositionSignal(i)
                    Case CDevPLCCommonNode.ePositionSignal.eNone
                        ledExhausPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.ePositionSignal.ePosition01
                        ledExhausPositionStatus_Slot01.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition02
                        ledExhausPositionStatus_Slot02.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition03
                        ledExhausPositionStatus_Slot03.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition04
                        ledExhausPositionStatus_Slot04.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition05
                        ledExhausPositionStatus_Slot05.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition06
                        ledExhausPositionStatus_Slot06.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition07
                        ledExhausPositionStatus_Slot07.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition08
                        ledExhausPositionStatus_Slot08.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition09
                        ledExhausPositionStatus_Slot09.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.ePositionSignal.ePosition10
                        ledExhausPositionStatus_Slot10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                End Select
            Next
        End If

    End Sub

    Private Sub MagazineStatusLEDControl(ByVal nMagazineType As eMagazineShape)

        MagazineStatusLEDInit(nMagazineType)

        If nMagazineType = eMagazineShape.eSupply Then
            For i As Integer = 0 To m_Main.cPLC.Datas.nSupplyMagazineStatus.Length - 1
                Select Case m_Main.cPLC.Datas.nSupplyMagazineStatus(i)
                    Case CDevPLCCommonNode.eMagazineStatus.eIDEL
                        ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eMagazineStatus.eReady
                        ledSupplySLOT1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.eScan
                        ledSupplySLOT2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.eScanEnd
                        ledSupplySLOT3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.ePallet_Up
                        ledSupplySLOT4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.ePallet_Down
                        ledSupplySLOT5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.eReadyEnd
                        ledSupplySLOT6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.eStart
                        ledSupplySLOT7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.eProgress
                        ledSupplySLOT8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.eEND
                        ledSupplySLOT9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.eBusy
                        ledSupplySLOT10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                End Select
            Next
        ElseIf nMagazineType = eMagazineShape.eExhaus Then
            For i As Integer = 0 To m_Main.cPLC.Datas.nExhausMagazineStatus.Length - 1
                Select Case m_Main.cPLC.Datas.nExhausMagazineStatus(i)
                    Case CDevPLCCommonNode.eMagazineStatus.eIDEL
                        ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    Case CDevPLCCommonNode.eMagazineStatus.eReady
                        ledExhausSLOT1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.eScan
                        ledExhausSLOT2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.eScanEnd
                        ledExhausSLOT3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.ePallet_Up
                        ledExhausSLOT4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.ePallet_Down
                        ledExhausSLOT5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.eReadyEnd
                        ledExhausSLOT6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.eStart
                        ledExhausSLOT7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.eProgress
                        ledExhausSLOT8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.eEND
                        ledExhausSLOT9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                    Case CDevPLCCommonNode.eMagazineStatus.eBusy
                        ledExhausSLOT10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                        ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                End Select
            Next
        End If

    End Sub

    Private Sub MagazineErrorLEDControl()
        MagazineErrorLEDInit()
    End Sub

    Private Sub AlarmDoorLEDControl()
        AlarmDoorLEDInit()
    End Sub

    Private Sub AlarmTemperatureLEDControl()
        AlarmTemperatureLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nTemperatureAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nTemperatureAlarm(i)
                Case CDevPLCCommonNode.eTemperatureAlarm.eNoError
                    ledAxisAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT1
                    ledAxisAlarm_YAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledAxisAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
                    ledAxisAlarm_ZAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledAxisAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
                    ledAxisAlarm_Y2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledAxisAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
                    ledAxisAlarm_THETA1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledAxisAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
                    ledAxisAlarm_THETA2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledAxisAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eTemperatureAlarm.eT6
                    ledAxisAlarm_THETA3Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledAxisAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eTemperatureAlarm.eT7
                    ledAxisAlarm_THETA4Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledAxisAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eTemperatureAlarm.eT8
                    ledAxisAlarm_NONE2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledAxisAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eTemperatureAlarm.eT9
                    ledAxisAlarm_NONE3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledAxisAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
            End Select
        Next
    End Sub

    Private Sub AlarmTemperatureControlLEDControl()
        AlarmTemperatureControlLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nTemperatureControlAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nTemperatureControlAlarm(i)
                Case CDevPLCCommonNode.eTemperatureAlarm.eNoError
                    ledEQPAlarm_None.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT1
                    ledEQPAlarm_None2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledEQPAlarm_None.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
                    ledEQPAlarm_Light.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledEQPAlarm_None.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
                    ledEQPAlarm_Heavy.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ledEQPAlarm_None.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
            End Select
        Next
    End Sub
#End Region


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim selIdx As Integer = cbSelEQPState.SelectedIndex

        Dim state As CDevPLCCommonNode.eEQPStatus = selIdx
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo
        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eSetEQPStatus
        reqInfo.nEQPStatus = state ' CDevPLC.eSystemStatus.ePauseAndProcess 'state

        m_Main.cPLC.Request(reqInfo)
    End Sub
End Class
