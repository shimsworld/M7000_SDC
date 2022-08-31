Imports System.Threading

Public Class frmPLCControl

    Dim m_Main As frmMain

    '정현기 알람 추가
    '경알람
    Dim ledWeak1Alarm() As LBSoft.IndustrialCtrls.Leds.LBLed
    Dim ledWeak2Alarm() As LBSoft.IndustrialCtrls.Leds.LBLed
    '중알람
    Dim ledEMSAlarm() As LBSoft.IndustrialCtrls.Leds.LBLed
    Dim ledTempAlarm() As LBSoft.IndustrialCtrls.Leds.LBLed
    Dim ledEOCRAlarm() As LBSoft.IndustrialCtrls.Leds.LBLed
    Dim ledSSR1Alarm() As LBSoft.IndustrialCtrls.Leds.LBLed
    Dim ledSSR2Alarm() As LBSoft.IndustrialCtrls.Leds.LBLed
    Dim ledTempSensor1Alarm() As LBSoft.IndustrialCtrls.Leds.LBLed
    Dim ledTempSensor2Alarm() As LBSoft.IndustrialCtrls.Leds.LBLed
    Dim ledDoorAlarm() As LBSoft.IndustrialCtrls.Leds.LBLed
    Dim ledXAxisAlarm() As LBSoft.IndustrialCtrls.Leds.LBLed
    Dim ledY1AxisAlarm() As LBSoft.IndustrialCtrls.Leds.LBLed
    Dim ledY2AxisAlarm() As LBSoft.IndustrialCtrls.Leds.LBLed
    Dim ledZAxisAlarm() As LBSoft.IndustrialCtrls.Leds.LBLed
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


        '정현기 알람 추가-----------------------------------------------------
        '경알람
        ledWeak1Alarm = New LBSoft.IndustrialCtrls.Leds.LBLed() {ledWeak1Alarm_0, ledWeak1Alarm_1, ledWeak1Alarm_2, ledWeak1Alarm_3, ledWeak1Alarm_4, ledWeak1Alarm_5, ledWeak1Alarm_6, ledWeak1Alarm_7, ledWeak1Alarm_8, ledWeak1Alarm_9, ledWeak1Alarm_10, ledWeak1Alarm_11, ledWeak1Alarm_12, ledWeak1Alarm_13, ledWeak1Alarm_14}
        ledWeak2Alarm = New LBSoft.IndustrialCtrls.Leds.LBLed() {ledWeak2Alarm_0, ledWeak2Alarm_1, ledWeak2Alarm_2, ledWeak2Alarm_3, ledWeak2Alarm_4, ledWeak2Alarm_5, ledWeak2Alarm_6}
        '중알람
        ledEMSAlarm = New LBSoft.IndustrialCtrls.Leds.LBLed() {ledEMSAlarm_0, ledEMSAlarm_1, ledEMSAlarm_2, ledEMSAlarm_3, ledEMSAlarm_4, ledEMSAlarm_5, ledEMSAlarm_6, ledEMSAlarm_7}
        ledTempAlarm = New LBSoft.IndustrialCtrls.Leds.LBLed() {ledTempAlarm_0, ledTempAlarm_1, ledTempAlarm_2, ledTempAlarm_3, ledTempAlarm_4}
        ledEOCRAlarm = New LBSoft.IndustrialCtrls.Leds.LBLed() {ledEOCRAlarm_0, ledEOCRAlarm_1, ledEOCRAlarm_2, ledEOCRAlarm_3, ledEOCRAlarm_4}
        ledSSR1Alarm = New LBSoft.IndustrialCtrls.Leds.LBLed() {ledSSR1Alarm_0, ledSSR1Alarm_1, ledSSR1Alarm_2, ledSSR1Alarm_3, ledSSR1Alarm_4}
        ledSSR2Alarm = New LBSoft.IndustrialCtrls.Leds.LBLed() {ledSSR2Alarm_0, ledSSR2Alarm_1, ledSSR2Alarm_2, ledSSR2Alarm_3, ledSSR2Alarm_4}
        ledTempSensor1Alarm = New LBSoft.IndustrialCtrls.Leds.LBLed() {ledTS1Alarm_0, ledTS1Alarm_1, ledTS1Alarm_2, ledTS1Alarm_3, ledTS1Alarm_4}
        ledTempSensor2Alarm = New LBSoft.IndustrialCtrls.Leds.LBLed() {ledTS2Alarm_0, ledTS2Alarm_1, ledTS2Alarm_2, ledTS2Alarm_3, ledTS2Alarm_4}
        ledDoorAlarm = New LBSoft.IndustrialCtrls.Leds.LBLed() {ledDoorAlarm_0, ledDoorAlarm_1, ledDoorAlarm_2, ledDoorAlarm_3}
        ledXAxisAlarm = New LBSoft.IndustrialCtrls.Leds.LBLed() {ledXAlarm_0, ledXAlarm_1, ledXAlarm_2, ledXAlarm_3, ledXAlarm_4, ledXAlarm_5, ledXAlarm_6, ledXAlarm_7, ledXAlarm_8, ledXAlarm_9}
        ledY1AxisAlarm = New LBSoft.IndustrialCtrls.Leds.LBLed() {ledY1Alarm_0, ledY1Alarm_1, ledY1Alarm_2, ledY1Alarm_3, ledY1Alarm_4, ledY1Alarm_5, ledY1Alarm_6, ledY1Alarm_7, ledY1Alarm_8, ledY1Alarm_9, ledY1Alarm_10}
        ledY2AxisAlarm = New LBSoft.IndustrialCtrls.Leds.LBLed() {ledY2Alarm_0, ledY2Alarm_1, ledY2Alarm_2, ledY2Alarm_3, ledY2Alarm_4, ledY2Alarm_5, ledY2Alarm_6, ledY2Alarm_7, ledY2Alarm_8, ledY2Alarm_9}
        ledZAxisAlarm = New LBSoft.IndustrialCtrls.Leds.LBLed() {ledZAlarm_0, ledZAlarm_1, ledZAlarm_2, ledZAlarm_3, ledZAlarm_4, ledZAlarm_5, ledZAlarm_6, ledZAlarm_7, ledZAlarm_8, ledZAlarm_9}
        '----------------------------------------------------------------------------
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

        ledConnectionStateCheck.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off


        '정현기 알람 추가--------------------------
        '경알람
        AlarmWeak1LEDInit()
        AlarmWeak2LEDInit()
        '중알람
        AlarmEMSLEDInit()
        AlarmTempLEDInit()
        AlarmEOCRLEDInit()
        AlarmSSR1LEDInit()
        AlarmSSR2LEDInit()
        AlarmTempSensor1LEDInit()
        AlarmTempSensor2LEDInit()
        AlarmDoorLEDInit()
        AlarmXAxisLEDInit()
        AlarmY1AxisLEDInit()
        AlarmY2AxisLEDInit()
        AlarmZAxisLEDInit()
        '------------------------------------------

        MagazineSlotLEDInit(eMagazineShape.eSupply)

        ServoAlarmLEDInit()
        EQPStatusLEDInit()

        MagazineSlotLEDInit(eMagazineShape.eExhaus)

        AlarmDoorLEDInit()

    End Sub

    Public Enum eMagazineShape
        eSupply
        eExhaus
    End Enum

#Region "LEDInit"
    '정현기 알람 추가-----------------------------------------------------------------------
    '경알람
    Private Sub AlarmWeak1LEDInit()
        For i = 0 To ledWeak1Alarm.Length - 1
            ledWeak1Alarm(i).State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Next
    End Sub
    Private Sub AlarmWeak2LEDInit()
        For i = 0 To ledWeak2Alarm.Length - 1
            ledWeak2Alarm(i).State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Next
    End Sub
    '중알람
    Private Sub AlarmEMSLEDInit()
        For i = 0 To ledEMSAlarm.Length - 1
            ledEMSAlarm(i).State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Next
    End Sub
    Private Sub AlarmTempLEDInit()
        For i = 0 To ledTempAlarm.Length - 1
            ledTempAlarm(i).State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Next
    End Sub
    Private Sub AlarmEOCRLEDInit()
        For i = 0 To ledEOCRAlarm.Length - 1
            ledEOCRAlarm(i).State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Next
    End Sub
    Private Sub AlarmSSR1LEDInit()
        For i = 0 To ledSSR1Alarm.Length - 1
            ledSSR1Alarm(i).State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Next
    End Sub
    Private Sub AlarmSSR2LEDInit()
        For i = 0 To ledSSR2Alarm.Length - 1
            ledSSR2Alarm(i).State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Next
    End Sub
    Private Sub AlarmTempSensor1LEDInit()
        For i = 0 To ledTempSensor1Alarm.Length - 1
            ledTempSensor1Alarm(i).State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Next
    End Sub
    Private Sub AlarmTempSensor2LEDInit()
        For i = 0 To ledTempSensor2Alarm.Length - 1
            ledTempSensor2Alarm(i).State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Next
    End Sub
    Private Sub AlarmDoorLEDInit()
        For i = 0 To ledDoorAlarm.Length - 1
            ledDoorAlarm(i).State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Next
    End Sub
    Private Sub AlarmXAxisLEDInit()
        For i = 0 To ledXAxisAlarm.Length - 1
            ledXAxisAlarm(i).State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Next
    End Sub
    Private Sub AlarmY1AxisLEDInit()
        For i = 0 To ledY1AxisAlarm.Length - 1
            ledY1AxisAlarm(i).State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Next
    End Sub
    Private Sub AlarmY2AxisLEDInit()
        For i = 0 To ledY2AxisAlarm.Length - 1
            ledY2AxisAlarm(i).State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Next
    End Sub
    Private Sub AlarmZAxisLEDInit()
        For i = 0 To ledZAxisAlarm.Length - 1
            ledZAxisAlarm(i).State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off
        Next
    End Sub
    '---------------------------------------------------------------------------------------

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

        ServoAlramLEDControl()
        EQPStateLEDControl()
        '정현기 알람추가-----------------------------------------------------------------------------------
        '경알람
        Weak1AlarmLEDControl()
        Weak2AlarmLEDControl()
        '중알람
        EMSLEDControl()
        TempAlarmLEDControl()
        EOCRAlarmLEDControl()
        SSR1AlarmLEDControl()
        SSR2AlarmLEDControl()
        TempSensor1AlarmLEDControl()
        TempSensor2AlarmLEDControl()
        DoorAlarmLEDControl()
        XAxisAlarmLEDControl()
        Y1AxisAlarmLEDControl()
        Y2AxisAlarmLEDControl()
        ZAxisAlarmLEDControl()
        '--------------------------------------------------------------------------------------------------
        Timer1.Enabled = True
    End Sub

#Region "LEDControl"
    '정현기 알람추가-----------------------------------------------------------------------------------
    '경알람
    Private Sub Weak1AlarmLEDControl()
        AlarmWeak1LEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nWeakAlarm1.Length - 1
            Select Case m_Main.cPLC.Datas.nWeakAlarm1(i)
                Case CDevPLCCommonNode.eWeakAlarm.eNoError
                    ledWeak1Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError1
                    ledWeak1Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError2
                    ledWeak1Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError3
                    ledWeak1Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError4
                    ledWeak1Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError5
                    ledWeak1Alarm_5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError6
                    ledWeak1Alarm_6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError7
                    ledWeak1Alarm_7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError8
                    ledWeak1Alarm_8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError9
                    ledWeak1Alarm_9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError10
                    ledWeak1Alarm_10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError11
                    ledWeak1Alarm_11.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError12
                    ledWeak1Alarm_12.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError13
                    ledWeak1Alarm_13.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError14
                    '없음
                Case CDevPLCCommonNode.eWeakAlarm.eError15
                    '없음
                Case CDevPLCCommonNode.eWeakAlarm.eError16
                    ledWeak1Alarm_14.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On

            End Select
        Next
    End Sub
    Private Sub Weak2AlarmLEDControl()
        AlarmWeak2LEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nWeakAlarm2.Length - 1
            Select Case m_Main.cPLC.Datas.nWeakAlarm2(i)
                Case CDevPLCCommonNode.eWeakAlarm.eNoError
                    ledWeak2Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError1
                    ledWeak2Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError2
                    ledWeak2Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError3
                    ledWeak2Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError4
                    ledWeak2Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError5
                    ledWeak2Alarm_5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError6
                    ledWeak2Alarm_6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eWeakAlarm.eError7

                Case CDevPLCCommonNode.eWeakAlarm.eError8

                Case CDevPLCCommonNode.eWeakAlarm.eError9

                Case CDevPLCCommonNode.eWeakAlarm.eError10

                Case CDevPLCCommonNode.eWeakAlarm.eError11

                Case CDevPLCCommonNode.eWeakAlarm.eError12

                Case CDevPLCCommonNode.eWeakAlarm.eError13

                Case CDevPLCCommonNode.eWeakAlarm.eError14

                Case CDevPLCCommonNode.eWeakAlarm.eError15

                Case CDevPLCCommonNode.eWeakAlarm.eError16

            End Select
        Next
    End Sub
    '중알람
    Private Sub EMSLEDControl()
        AlarmEMSLEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nEmsAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nEmsAlarm(i)
                Case CDevPLCCommonNode.eEMSAlarm.eNoError
                    ledEMSAlarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eEMS1
                    ledEMSAlarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eSafety_Control_Alarm1
                    ledEMSAlarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eSafety_Control_Alarm2
                    ledEMSAlarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eMC1_POWEROFF_Alarm
                    ledEMSAlarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eMC2_POWEROFF_Alarm
                    ledEMSAlarm_5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eControlBoxTempLightAlarm
                    ledEMSAlarm_6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eEMSAlarm.eControlBoxSmokeAlarm
                    ledEMSAlarm_7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next
    End Sub
    Private Sub TempAlarmLEDControl()
        AlarmTempLEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nStrangeTempAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nStrangeTempAlarm(i)
                Case CDevPLCCommonNode.eTemperatureAlarm.eNoError
                    ledTempAlarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT1

                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
                    ledTempAlarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
                    ledTempAlarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
                    ledTempAlarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
                    ledTempAlarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT6

                Case CDevPLCCommonNode.eTemperatureAlarm.eT7

                Case CDevPLCCommonNode.eTemperatureAlarm.eT8

                Case CDevPLCCommonNode.eTemperatureAlarm.eT9

            End Select
        Next
    End Sub
    Private Sub EOCRAlarmLEDControl()
        AlarmEOCRLEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nEOCRTempAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nEOCRTempAlarm(i)
                Case CDevPLCCommonNode.eTemperatureAlarm.eNoError
                    ledEOCRAlarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT1

                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
                    ledEOCRAlarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
                    ledEOCRAlarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
                    ledEOCRAlarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
                    ledEOCRAlarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT6

                Case CDevPLCCommonNode.eTemperatureAlarm.eT7

                Case CDevPLCCommonNode.eTemperatureAlarm.eT8

                Case CDevPLCCommonNode.eTemperatureAlarm.eT9

            End Select
        Next
    End Sub
    Private Sub SSR1AlarmLEDControl()
        AlarmSSR1LEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nSSRTemp1Alarm.Length - 1
            Select Case m_Main.cPLC.Datas.nSSRTemp1Alarm(i)
                Case CDevPLCCommonNode.eTemperatureAlarm.eNoError
                    ledSSR1Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT1

                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
                    ledSSR1Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
                    ledSSR1Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
                    ledSSR1Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
                    ledSSR1Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT6

                Case CDevPLCCommonNode.eTemperatureAlarm.eT7

                Case CDevPLCCommonNode.eTemperatureAlarm.eT8

                Case CDevPLCCommonNode.eTemperatureAlarm.eT9

            End Select
        Next
    End Sub
    Private Sub SSR2AlarmLEDControl()
        AlarmSSR2LEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nSSRTemp2Alarm.Length - 1
            Select Case m_Main.cPLC.Datas.nSSRTemp2Alarm(i)
                Case CDevPLCCommonNode.eTemperatureAlarm.eNoError
                    ledSSR2Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT1

                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
                    ledSSR2Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
                    ledSSR2Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
                    ledSSR2Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
                    ledSSR2Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT6

                Case CDevPLCCommonNode.eTemperatureAlarm.eT7

                Case CDevPLCCommonNode.eTemperatureAlarm.eT8

                Case CDevPLCCommonNode.eTemperatureAlarm.eT9

            End Select
        Next
    End Sub
    Private Sub TempSensor1AlarmLEDControl()
        AlarmTempSensor1LEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nTempSensor1Alarm.Length - 1
            Select Case m_Main.cPLC.Datas.nTempSensor1Alarm(i)
                Case CDevPLCCommonNode.eTemperatureAlarm.eNoError
                    ledTS1Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT1

                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
                    ledTS1Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
                    ledTS1Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
                    ledTS1Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
                    ledTS1Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT6

                Case CDevPLCCommonNode.eTemperatureAlarm.eT7

                Case CDevPLCCommonNode.eTemperatureAlarm.eT8

                Case CDevPLCCommonNode.eTemperatureAlarm.eT9

            End Select
        Next
    End Sub
    Private Sub TempSensor2AlarmLEDControl()
        AlarmTempSensor2LEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nTempSensor2Alarm.Length - 1
            Select Case m_Main.cPLC.Datas.nTempSensor2Alarm(i)
                Case CDevPLCCommonNode.eTemperatureAlarm.eNoError
                    ledTS2Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT1

                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
                    ledTS2Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
                    ledTS2Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT4
                    ledTS2Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT5
                    ledTS2Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT6

                Case CDevPLCCommonNode.eTemperatureAlarm.eT7

                Case CDevPLCCommonNode.eTemperatureAlarm.eT8

                Case CDevPLCCommonNode.eTemperatureAlarm.eT9

            End Select
        Next
    End Sub
    Private Sub DoorAlarmLEDControl()
        AlarmDoorLEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nDoorAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nDoorAlarm(i)
                Case CDevPLCCommonNode.eTemperatureAlarm.eNoError
                    ledDoorAlarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT1
                    ledDoorAlarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT2
                    ledDoorAlarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT3
                    ledDoorAlarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eTemperatureAlarm.eT4

                Case CDevPLCCommonNode.eTemperatureAlarm.eT5

                Case CDevPLCCommonNode.eTemperatureAlarm.eT6

                Case CDevPLCCommonNode.eTemperatureAlarm.eT7

                Case CDevPLCCommonNode.eTemperatureAlarm.eT8

                Case CDevPLCCommonNode.eTemperatureAlarm.eT9

            End Select
        Next
    End Sub
    Private Sub XAxisAlarmLEDControl()
        AlarmXAxisLEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nXAxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nXAxisAlarm(i)
                Case CDevPLCCommonNode.eAxisAlarm.eNoError
                    ledXAlarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Alarm
                    ledXAlarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Servo_Alarm
                    ledXAlarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_RLS_Limit_Alarm
                    ledXAlarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_FLS_Limit_Alarm
                    ledXAlarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Crush_Alarm
                    ledXAlarm_5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Homming_Timeout
                    ledXAlarm_6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Moving_Timeout
                    ledXAlarm_7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                    ledXAlarm_8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                    ledXAlarm_9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eSynchronous_axispositional_alarm

            End Select
        Next
    End Sub
    Private Sub Y1AxisAlarmLEDControl()
        AlarmY1AxisLEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nY1AxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nY1AxisAlarm(i)
                Case CDevPLCCommonNode.eAxisAlarm.eNoError
                    ledY1Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Alarm
                    ledY1Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Servo_Alarm
                    ledY1Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_RLS_Limit_Alarm
                    ledY1Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_FLS_Limit_Alarm
                    ledY1Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Crush_Alarm
                    ledY1Alarm_5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Homming_Timeout
                    ledY1Alarm_6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Moving_Timeout
                    ledY1Alarm_7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                    ledY1Alarm_8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                    ledY1Alarm_9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eSynchronous_axispositional_alarm
                    ledY1Alarm_10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
            End Select
        Next
    End Sub
    Private Sub Y2AxisAlarmLEDControl()
        AlarmY2AxisLEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nY2AxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nY2AxisAlarm(i)
                Case CDevPLCCommonNode.eAxisAlarm.eNoError
                    ledY2Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Alarm
                    ledY2Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Servo_Alarm
                    ledY2Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_RLS_Limit_Alarm
                    ledY2Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_FLS_Limit_Alarm
                    ledY2Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Crush_Alarm
                    ledY2Alarm_5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Homming_Timeout
                    ledY2Alarm_6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Moving_Timeout
                    ledY2Alarm_7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                    ledY2Alarm_8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                    ledY2Alarm_9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eSynchronous_axispositional_alarm

            End Select
        Next
    End Sub
    Private Sub ZAxisAlarmLEDControl()
        AlarmZAxisLEDInit()
        For i As Integer = 0 To m_Main.cPLC.Datas.nZAxisAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nZAxisAlarm(i)
                Case CDevPLCCommonNode.eAxisAlarm.eNoError
                    ledZAlarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Alarm
                    ledZAlarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Servo_Alarm
                    ledZAlarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_RLS_Limit_Alarm
                    ledZAlarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_FLS_Limit_Alarm
                    ledZAlarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Crush_Alarm
                    ledZAlarm_5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Homming_Timeout
                    ledZAlarm_6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAxis_Moving_Timeout
                    ledZAlarm_7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eAMP_Over_Temp
                    ledZAlarm_8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eOver_Current
                    ledZAlarm_9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eAxisAlarm.eSynchronous_axispositional_alarm

            End Select
        Next
    End Sub
    '--------------------------------------------------------------------------------------------------
    Private Sub ServoAlramLEDControl()

        ServoAlarmLEDInit()

        For i As Integer = 0 To m_Main.cPLC.Datas.nServoAlarm.Length - 1
            Select Case m_Main.cPLC.Datas.nServoAlarm(i)
                Case CDevPLCCommonNode.eServoAlarm.eX_Axis_Servo_ON
                    ledServoAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eServoAlarm.eY1_Axis_Servo_ON
                    ledServoAlarm_Y1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                Case CDevPLCCommonNode.eServoAlarm.eZ_Axis_Servo_ON
                    ledServoAlarm_ZAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    'Case CDevPLCCommonNode.eServoAlarm.eTheta1_Axis_Servo_ON
                    '    ledServoAlarm_Theta1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    'Case CDevPLCCommonNode.eServoAlarm.eTheta2_Axis_Servo_ON
                    '    ledServoAlarm_Theta2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    'Case CDevPLCCommonNode.eServoAlarm.eTheta3_Axis_Servo_ON
                    '    ledServoAlarm_Theta3Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    'Case CDevPLCCommonNode.eServoAlarm.eTheta4_Axis_Servo_ON
                    '    ledServoAlarm_Theta4Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On
                    ' Case CDevPLCCommonNode.eServoAlarm.eY2_Axis_Servo_ON
                    '   ledServoAlarm_Y2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On

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


#End Region


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim selIdx As Integer = cbSelEQPState.SelectedIndex

        Dim state As CDevPLCCommonNode.eEQPStatus = selIdx
        Dim reqInfo As CDevPLCCommonNode.sRequestInfo
        reqInfo.nCMD = CDevPLCCommonNode.eRequestCMD.eSetEQPStatus
        reqInfo.nEQPStatus = state ' CDevPLC.eSystemStatus.ePauseAndProcess 'state

        m_Main.cPLC.Request(reqInfo)
    End Sub

    Private Sub ledTempAlarm_2_Load(sender As Object, e As EventArgs) Handles ledTempAlarm_2.Load

    End Sub

    Private Sub ledTempAlarm_3_Load(sender As Object, e As EventArgs) Handles ledTempAlarm_3.Load

    End Sub
End Class
