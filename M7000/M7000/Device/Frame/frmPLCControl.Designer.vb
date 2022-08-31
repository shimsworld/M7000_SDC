<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPLCControl
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.LABEL2 = New System.Windows.Forms.Label()
        Me.txtIP4 = New System.Windows.Forms.TextBox()
        Me.txtIP3 = New System.Windows.Forms.TextBox()
        Me.txtIP2 = New System.Windows.Forms.TextBox()
        Me.txtIP1 = New System.Windows.Forms.TextBox()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.ledConnectionStateCheck = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.btnDisconnection = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GroupBox25 = New System.Windows.Forms.GroupBox()
        Me.cbSelEQPState = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cbSelContactInspectionStatus = New System.Windows.Forms.ComboBox()
        Me.btnSetContactInspectionStatus = New System.Windows.Forms.Button()
        Me.cbGetContactInspectionStatus = New System.Windows.Forms.TextBox()
        Me.btnGetContactInspectionStatus = New System.Windows.Forms.Button()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbInDex = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbOutBinery = New System.Windows.Forms.TextBox()
        Me.GroupBox23 = New System.Windows.Forms.GroupBox()
        Me.cbSelExhausStatus = New System.Windows.Forms.ComboBox()
        Me.btnSetExhausStatus = New System.Windows.Forms.Button()
        Me.tbExhausStatusValue = New System.Windows.Forms.TextBox()
        Me.btnGetExhausStatus = New System.Windows.Forms.Button()
        Me.GroupBox22 = New System.Windows.Forms.GroupBox()
        Me.cbSelSupplyStatus = New System.Windows.Forms.ComboBox()
        Me.btnSetSupplyStatus = New System.Windows.Forms.Button()
        Me.tbSupplyStatusValue = New System.Windows.Forms.TextBox()
        Me.btnGetSupplyStatus = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbSelStatus = New System.Windows.Forms.ComboBox()
        Me.btnSetStatus = New System.Windows.Forms.Button()
        Me.tbStatusValue = New System.Windows.Forms.TextBox()
        Me.btnGetStatus = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbSelDOSignal = New System.Windows.Forms.ComboBox()
        Me.tbDOValue = New System.Windows.Forms.TextBox()
        Me.btnSetDO = New System.Windows.Forms.Button()
        Me.btnGetDO = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbSelDISignal = New System.Windows.Forms.ComboBox()
        Me.tbDIValue = New System.Windows.Forms.TextBox()
        Me.btnSetDI = New System.Windows.Forms.Button()
        Me.btnGetDI = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox26 = New System.Windows.Forms.GroupBox()
        Me.ledEMSAlarm_5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.ledTempAlarm_4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledTempAlarm_3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledTempAlarm_2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledTempAlarm_1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.ledEOCRAlarm_4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEOCRAlarm_3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEOCRAlarm_2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEOCRAlarm_1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.ledSSR1Alarm_4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSSR1Alarm_3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSSR1Alarm_2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSSR1Alarm_1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox27 = New System.Windows.Forms.GroupBox()
        Me.ledSSR2Alarm_4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSSR2Alarm_3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSSR2Alarm_2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSSR2Alarm_1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox28 = New System.Windows.Forms.GroupBox()
        Me.ledTS1Alarm_4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledTS1Alarm_3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledTS1Alarm_2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledTS1Alarm_1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox29 = New System.Windows.Forms.GroupBox()
        Me.ledTS2Alarm_4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledTS2Alarm_3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledTS2Alarm_2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledTS2Alarm_1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox30 = New System.Windows.Forms.GroupBox()
        Me.ledDoorAlarm_3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledDoorAlarm_2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledDoorAlarm_1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox31 = New System.Windows.Forms.GroupBox()
        Me.ledXAlarm_5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledXAlarm_4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledXAlarm_3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledXAlarm_2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledXAlarm_7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledXAlarm_6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledXAlarm_1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledXAlarm_0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledXAlarm_9 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledXAlarm_8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox32 = New System.Windows.Forms.GroupBox()
        Me.ledY1Alarm_9 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY1Alarm_8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY1Alarm_5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY1Alarm_4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY1Alarm_3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY1Alarm_2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY1Alarm_7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY1Alarm_6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY1Alarm_1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY1Alarm_0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox33 = New System.Windows.Forms.GroupBox()
        Me.ledY2Alarm_9 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY2Alarm_8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY2Alarm_5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY2Alarm_4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY2Alarm_3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY2Alarm_2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY2Alarm_7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY2Alarm_6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY2Alarm_1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY2Alarm_0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox34 = New System.Windows.Forms.GroupBox()
        Me.ledZAlarm_9 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledZAlarm_8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledZAlarm_5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledZAlarm_4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledZAlarm_3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledZAlarm_2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledZAlarm_7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledZAlarm_6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledZAlarm_1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledZAlarm_0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox36 = New System.Windows.Forms.GroupBox()
        Me.ledWeak2Alarm_4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak2Alarm_3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak2Alarm_2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak2Alarm_1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak2Alarm_6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak2Alarm_5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox37 = New System.Windows.Forms.GroupBox()
        Me.ledWeak1Alarm_0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak1Alarm_1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak1Alarm_6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak1Alarm_7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak1Alarm_2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak1Alarm_3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak1Alarm_4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak1Alarm_5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak1Alarm_8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak1Alarm_9 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak1Alarm_10 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak1Alarm_11 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak1Alarm_12 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak1Alarm_13 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledWeak1Alarm_14 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox35 = New System.Windows.Forms.GroupBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.ledSysStatus_PowerON = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_PowerDown = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_TeachingMode = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_AutoMode = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_ManualMode = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_Processing = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_SystemLoading = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_SystemIDLE = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.ledSupplySLOT0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT9 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT10 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyNone = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.ledMagazineErrorStatus_Down = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledMagazineErrorStatus_Reserved01 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledMagazineErrorStatus_Reserved02 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledMagazineErrorStatus_Reserved03 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledMagazineErrorStatus_Reserved04 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledMagazineErrorStatus_Reserved05 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledMagazineErrorStatus_Reserved06 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledMagazineErrorStatus_Reserved07 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.ledExhausSLOT0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT9 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT10 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausNone = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.ledSupplySlotStatus_None = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot01 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot02 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot03 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot04 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot05 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot06 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot07 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot08 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot09 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot10 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox21 = New System.Windows.Forms.GroupBox()
        Me.ledEQPStatus_RUN = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEQPStatus_PAUSE = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEQPStatus_STOP = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEQPStatus_Reset = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.ledSupplyPositionStatus_Down = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot01 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot02 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot03 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot04 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot05 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot06 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot07 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot08 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot09 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot10 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.ledExhausSlotStatus_None = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot01 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot02 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot03 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot04 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot05 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot06 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot07 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot08 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot09 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot10 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.ledExhausPositionStatus_Down = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot01 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot02 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot03 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot04 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot05 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot06 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot07 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot08 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot09 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot10 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox24 = New System.Windows.Forms.GroupBox()
        Me.ledServoAlarm_Y1Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_ZAxis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_XAxis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Y2Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Theta1Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Theta2Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Theta3Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Theta4Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_NONE2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_NONE3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Stoper = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Align = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Contact = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox38 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.ledWeak2Alarm_0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledTempAlarm_0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEOCRAlarm_0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSSR1Alarm_0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSSR2Alarm_0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledTS1Alarm_0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledTS2Alarm_0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledDoorAlarm_0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledY1Alarm_10 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox25.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox23.SuspendLayout()
        Me.GroupBox22.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox26.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox27.SuspendLayout()
        Me.GroupBox28.SuspendLayout()
        Me.GroupBox29.SuspendLayout()
        Me.GroupBox30.SuspendLayout()
        Me.GroupBox31.SuspendLayout()
        Me.GroupBox32.SuspendLayout()
        Me.GroupBox33.SuspendLayout()
        Me.GroupBox34.SuspendLayout()
        Me.GroupBox36.SuspendLayout()
        Me.GroupBox37.SuspendLayout()
        Me.GroupBox35.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox21.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox24.SuspendLayout()
        Me.GroupBox38.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.LABEL2)
        Me.GroupBox5.Controls.Add(Me.txtIP4)
        Me.GroupBox5.Controls.Add(Me.txtIP3)
        Me.GroupBox5.Controls.Add(Me.txtIP2)
        Me.GroupBox5.Controls.Add(Me.txtIP1)
        Me.GroupBox5.Controls.Add(Me.btnConnection)
        Me.GroupBox5.Controls.Add(Me.ledConnectionStateCheck)
        Me.GroupBox5.Controls.Add(Me.btnDisconnection)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(291, 204)
        Me.GroupBox5.TabIndex = 44
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Communication"
        '
        'LABEL2
        '
        Me.LABEL2.AutoSize = True
        Me.LABEL2.Location = New System.Drawing.Point(28, 30)
        Me.LABEL2.Name = "LABEL2"
        Me.LABEL2.Size = New System.Drawing.Size(60, 12)
        Me.LABEL2.TabIndex = 20
        Me.LABEL2.Text = "IP Adress"
        '
        'txtIP4
        '
        Me.txtIP4.Location = New System.Drawing.Point(205, 49)
        Me.txtIP4.Name = "txtIP4"
        Me.txtIP4.Size = New System.Drawing.Size(54, 21)
        Me.txtIP4.TabIndex = 19
        Me.txtIP4.Text = "10"
        '
        'txtIP3
        '
        Me.txtIP3.Location = New System.Drawing.Point(145, 49)
        Me.txtIP3.Name = "txtIP3"
        Me.txtIP3.Size = New System.Drawing.Size(54, 21)
        Me.txtIP3.TabIndex = 18
        Me.txtIP3.Text = "1"
        '
        'txtIP2
        '
        Me.txtIP2.Location = New System.Drawing.Point(86, 49)
        Me.txtIP2.Name = "txtIP2"
        Me.txtIP2.Size = New System.Drawing.Size(54, 21)
        Me.txtIP2.TabIndex = 17
        Me.txtIP2.Text = "168"
        '
        'txtIP1
        '
        Me.txtIP1.Location = New System.Drawing.Point(26, 49)
        Me.txtIP1.Name = "txtIP1"
        Me.txtIP1.Size = New System.Drawing.Size(54, 21)
        Me.txtIP1.TabIndex = 16
        Me.txtIP1.Text = "192"
        '
        'btnConnection
        '
        Me.btnConnection.Location = New System.Drawing.Point(35, 85)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(94, 24)
        Me.btnConnection.TabIndex = 0
        Me.btnConnection.Text = "Connection"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'ledConnectionStateCheck
        '
        Me.ledConnectionStateCheck.AutoSize = True
        Me.ledConnectionStateCheck.BackColor = System.Drawing.Color.Transparent
        Me.ledConnectionStateCheck.BlinkInterval = 500
        Me.ledConnectionStateCheck.Label = "Connection State"
        Me.ledConnectionStateCheck.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top
        Me.ledConnectionStateCheck.LedColor = System.Drawing.Color.Blue
        Me.ledConnectionStateCheck.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledConnectionStateCheck.Location = New System.Drawing.Point(13, 132)
        Me.ledConnectionStateCheck.Name = "ledConnectionStateCheck"
        Me.ledConnectionStateCheck.Renderer = Nothing
        Me.ledConnectionStateCheck.Size = New System.Drawing.Size(258, 59)
        Me.ledConnectionStateCheck.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledConnectionStateCheck.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledConnectionStateCheck.TabIndex = 9
        '
        'btnDisconnection
        '
        Me.btnDisconnection.Location = New System.Drawing.Point(152, 84)
        Me.btnDisconnection.Name = "btnDisconnection"
        Me.btnDisconnection.Size = New System.Drawing.Size(94, 25)
        Me.btnDisconnection.TabIndex = 15
        Me.btnDisconnection.Text = "Disconnection"
        Me.btnDisconnection.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.GroupBox25)
        Me.GroupBox7.Controls.Add(Me.GroupBox6)
        Me.GroupBox7.Controls.Add(Me.GroupBox11)
        Me.GroupBox7.Controls.Add(Me.GroupBox4)
        Me.GroupBox7.Controls.Add(Me.GroupBox23)
        Me.GroupBox7.Controls.Add(Me.GroupBox22)
        Me.GroupBox7.Controls.Add(Me.GroupBox1)
        Me.GroupBox7.Controls.Add(Me.GroupBox3)
        Me.GroupBox7.Controls.Add(Me.GroupBox2)
        Me.GroupBox7.Location = New System.Drawing.Point(309, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(1100, 204)
        Me.GroupBox7.TabIndex = 45
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Controls"
        '
        'GroupBox25
        '
        Me.GroupBox25.Controls.Add(Me.cbSelEQPState)
        Me.GroupBox25.Controls.Add(Me.Button3)
        Me.GroupBox25.Controls.Add(Me.TextBox5)
        Me.GroupBox25.Controls.Add(Me.Button4)
        Me.GroupBox25.Location = New System.Drawing.Point(818, 20)
        Me.GroupBox25.Name = "GroupBox25"
        Me.GroupBox25.Size = New System.Drawing.Size(195, 85)
        Me.GroupBox25.TabIndex = 39
        Me.GroupBox25.TabStop = False
        Me.GroupBox25.Text = "EQP Status"
        '
        'cbSelEQPState
        '
        Me.cbSelEQPState.FormattingEnabled = True
        Me.cbSelEQPState.Items.AddRange(New Object() {"Down", "IDEL", "Process", "Maintenance", "Alarm", "Safety_Auto(Not Use.)", "Safety_Teach(Not Use.)", "Pause"})
        Me.cbSelEQPState.Location = New System.Drawing.Point(15, 20)
        Me.cbSelEQPState.Name = "cbSelEQPState"
        Me.cbSelEQPState.Size = New System.Drawing.Size(103, 20)
        Me.cbSelEQPState.TabIndex = 25
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(124, 13)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(61, 30)
        Me.Button3.TabIndex = 24
        Me.Button3.Text = "Set"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(15, 48)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(103, 21)
        Me.TextBox5.TabIndex = 26
        Me.TextBox5.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(124, 43)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(61, 28)
        Me.Button4.TabIndex = 27
        Me.Button4.Text = "Get"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cbSelContactInspectionStatus)
        Me.GroupBox6.Controls.Add(Me.btnSetContactInspectionStatus)
        Me.GroupBox6.Controls.Add(Me.cbGetContactInspectionStatus)
        Me.GroupBox6.Controls.Add(Me.btnGetContactInspectionStatus)
        Me.GroupBox6.Location = New System.Drawing.Point(617, 20)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(195, 85)
        Me.GroupBox6.TabIndex = 38
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "ContactInspection Status"
        '
        'cbSelContactInspectionStatus
        '
        Me.cbSelContactInspectionStatus.FormattingEnabled = True
        Me.cbSelContactInspectionStatus.Items.AddRange(New Object() {"Down", "IDEL", "Process", "Maintenance", "Alarm", "Safety_Auto(Not Use.)", "Safety_Teach(Not Use.)", "Pause"})
        Me.cbSelContactInspectionStatus.Location = New System.Drawing.Point(15, 20)
        Me.cbSelContactInspectionStatus.Name = "cbSelContactInspectionStatus"
        Me.cbSelContactInspectionStatus.Size = New System.Drawing.Size(103, 20)
        Me.cbSelContactInspectionStatus.TabIndex = 25
        '
        'btnSetContactInspectionStatus
        '
        Me.btnSetContactInspectionStatus.Location = New System.Drawing.Point(124, 13)
        Me.btnSetContactInspectionStatus.Name = "btnSetContactInspectionStatus"
        Me.btnSetContactInspectionStatus.Size = New System.Drawing.Size(61, 30)
        Me.btnSetContactInspectionStatus.TabIndex = 24
        Me.btnSetContactInspectionStatus.Text = "Set"
        Me.btnSetContactInspectionStatus.UseVisualStyleBackColor = True
        '
        'cbGetContactInspectionStatus
        '
        Me.cbGetContactInspectionStatus.Location = New System.Drawing.Point(15, 48)
        Me.cbGetContactInspectionStatus.Name = "cbGetContactInspectionStatus"
        Me.cbGetContactInspectionStatus.Size = New System.Drawing.Size(103, 21)
        Me.cbGetContactInspectionStatus.TabIndex = 26
        Me.cbGetContactInspectionStatus.Visible = False
        '
        'btnGetContactInspectionStatus
        '
        Me.btnGetContactInspectionStatus.Location = New System.Drawing.Point(124, 43)
        Me.btnGetContactInspectionStatus.Name = "btnGetContactInspectionStatus"
        Me.btnGetContactInspectionStatus.Size = New System.Drawing.Size(61, 28)
        Me.btnGetContactInspectionStatus.TabIndex = 27
        Me.btnGetContactInspectionStatus.Text = "Get"
        Me.btnGetContactInspectionStatus.UseVisualStyleBackColor = True
        Me.btnGetContactInspectionStatus.Visible = False
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Label9)
        Me.GroupBox11.Controls.Add(Me.Label10)
        Me.GroupBox11.Controls.Add(Me.TextBox3)
        Me.GroupBox11.Controls.Add(Me.Button2)
        Me.GroupBox11.Controls.Add(Me.TextBox4)
        Me.GroupBox11.Location = New System.Drawing.Point(258, 110)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(246, 75)
        Me.GroupBox11.TabIndex = 37
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "HEX To Binery"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 12)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Input :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 12)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Output :"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(55, 16)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(96, 21)
        Me.TextBox3.TabIndex = 33
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(157, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(73, 41)
        Me.Button2.TabIndex = 35
        Me.Button2.Text = "Convert"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(55, 43)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(96, 21)
        Me.TextBox4.TabIndex = 34
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.tbInDex)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.tbOutBinery)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 110)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(246, 75)
        Me.GroupBox4.TabIndex = 36
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Dec To Binery"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 12)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Input :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 12)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Output :"
        '
        'tbInDex
        '
        Me.tbInDex.Location = New System.Drawing.Point(58, 17)
        Me.tbInDex.Name = "tbInDex"
        Me.tbInDex.Size = New System.Drawing.Size(96, 21)
        Me.tbInDex.TabIndex = 33
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(160, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 41)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "Convert"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbOutBinery
        '
        Me.tbOutBinery.Location = New System.Drawing.Point(58, 44)
        Me.tbOutBinery.Name = "tbOutBinery"
        Me.tbOutBinery.Size = New System.Drawing.Size(96, 21)
        Me.tbOutBinery.TabIndex = 34
        '
        'GroupBox23
        '
        Me.GroupBox23.Controls.Add(Me.cbSelExhausStatus)
        Me.GroupBox23.Controls.Add(Me.btnSetExhausStatus)
        Me.GroupBox23.Controls.Add(Me.tbExhausStatusValue)
        Me.GroupBox23.Controls.Add(Me.btnGetExhausStatus)
        Me.GroupBox23.Location = New System.Drawing.Point(417, 20)
        Me.GroupBox23.Name = "GroupBox23"
        Me.GroupBox23.Size = New System.Drawing.Size(195, 85)
        Me.GroupBox23.TabIndex = 34
        Me.GroupBox23.TabStop = False
        Me.GroupBox23.Text = "ExhausStatus"
        '
        'cbSelExhausStatus
        '
        Me.cbSelExhausStatus.FormattingEnabled = True
        Me.cbSelExhausStatus.Items.AddRange(New Object() {"Down", "IDEL", "Process", "Maintenance", "Alarm", "Safety_Auto(Not Use.)", "Safety_Teach(Not Use.)", "Pause"})
        Me.cbSelExhausStatus.Location = New System.Drawing.Point(15, 20)
        Me.cbSelExhausStatus.Name = "cbSelExhausStatus"
        Me.cbSelExhausStatus.Size = New System.Drawing.Size(103, 20)
        Me.cbSelExhausStatus.TabIndex = 25
        '
        'btnSetExhausStatus
        '
        Me.btnSetExhausStatus.Location = New System.Drawing.Point(124, 13)
        Me.btnSetExhausStatus.Name = "btnSetExhausStatus"
        Me.btnSetExhausStatus.Size = New System.Drawing.Size(61, 30)
        Me.btnSetExhausStatus.TabIndex = 24
        Me.btnSetExhausStatus.Text = "Set"
        Me.btnSetExhausStatus.UseVisualStyleBackColor = True
        '
        'tbExhausStatusValue
        '
        Me.tbExhausStatusValue.Location = New System.Drawing.Point(15, 48)
        Me.tbExhausStatusValue.Name = "tbExhausStatusValue"
        Me.tbExhausStatusValue.Size = New System.Drawing.Size(103, 21)
        Me.tbExhausStatusValue.TabIndex = 26
        Me.tbExhausStatusValue.Visible = False
        '
        'btnGetExhausStatus
        '
        Me.btnGetExhausStatus.Location = New System.Drawing.Point(124, 43)
        Me.btnGetExhausStatus.Name = "btnGetExhausStatus"
        Me.btnGetExhausStatus.Size = New System.Drawing.Size(61, 28)
        Me.btnGetExhausStatus.TabIndex = 27
        Me.btnGetExhausStatus.Text = "Get"
        Me.btnGetExhausStatus.UseVisualStyleBackColor = True
        Me.btnGetExhausStatus.Visible = False
        '
        'GroupBox22
        '
        Me.GroupBox22.Controls.Add(Me.cbSelSupplyStatus)
        Me.GroupBox22.Controls.Add(Me.btnSetSupplyStatus)
        Me.GroupBox22.Controls.Add(Me.tbSupplyStatusValue)
        Me.GroupBox22.Controls.Add(Me.btnGetSupplyStatus)
        Me.GroupBox22.Location = New System.Drawing.Point(210, 20)
        Me.GroupBox22.Name = "GroupBox22"
        Me.GroupBox22.Size = New System.Drawing.Size(195, 85)
        Me.GroupBox22.TabIndex = 33
        Me.GroupBox22.TabStop = False
        Me.GroupBox22.Text = "Supply Status"
        '
        'cbSelSupplyStatus
        '
        Me.cbSelSupplyStatus.FormattingEnabled = True
        Me.cbSelSupplyStatus.Items.AddRange(New Object() {"Down", "IDEL", "Process", "Maintenance", "Alarm", "Safety_Auto(Not Use.)", "Safety_Teach(Not Use.)", "Pause"})
        Me.cbSelSupplyStatus.Location = New System.Drawing.Point(15, 20)
        Me.cbSelSupplyStatus.Name = "cbSelSupplyStatus"
        Me.cbSelSupplyStatus.Size = New System.Drawing.Size(103, 20)
        Me.cbSelSupplyStatus.TabIndex = 25
        '
        'btnSetSupplyStatus
        '
        Me.btnSetSupplyStatus.Location = New System.Drawing.Point(124, 13)
        Me.btnSetSupplyStatus.Name = "btnSetSupplyStatus"
        Me.btnSetSupplyStatus.Size = New System.Drawing.Size(61, 30)
        Me.btnSetSupplyStatus.TabIndex = 24
        Me.btnSetSupplyStatus.Text = "Set"
        Me.btnSetSupplyStatus.UseVisualStyleBackColor = True
        '
        'tbSupplyStatusValue
        '
        Me.tbSupplyStatusValue.Location = New System.Drawing.Point(15, 48)
        Me.tbSupplyStatusValue.Name = "tbSupplyStatusValue"
        Me.tbSupplyStatusValue.Size = New System.Drawing.Size(103, 21)
        Me.tbSupplyStatusValue.TabIndex = 26
        Me.tbSupplyStatusValue.Visible = False
        '
        'btnGetSupplyStatus
        '
        Me.btnGetSupplyStatus.Location = New System.Drawing.Point(124, 43)
        Me.btnGetSupplyStatus.Name = "btnGetSupplyStatus"
        Me.btnGetSupplyStatus.Size = New System.Drawing.Size(61, 28)
        Me.btnGetSupplyStatus.TabIndex = 27
        Me.btnGetSupplyStatus.Text = "Get"
        Me.btnGetSupplyStatus.UseVisualStyleBackColor = True
        Me.btnGetSupplyStatus.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbSelStatus)
        Me.GroupBox1.Controls.Add(Me.btnSetStatus)
        Me.GroupBox1.Controls.Add(Me.tbStatusValue)
        Me.GroupBox1.Controls.Add(Me.btnGetStatus)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(195, 85)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "System Status"
        '
        'cbSelStatus
        '
        Me.cbSelStatus.FormattingEnabled = True
        Me.cbSelStatus.Items.AddRange(New Object() {"Down", "IDEL", "Process", "Maintenance", "Alarm", "Safety_Auto(Not Use.)", "Safety_Teach(Not Use.)", "Pause"})
        Me.cbSelStatus.Location = New System.Drawing.Point(15, 20)
        Me.cbSelStatus.Name = "cbSelStatus"
        Me.cbSelStatus.Size = New System.Drawing.Size(103, 20)
        Me.cbSelStatus.TabIndex = 25
        '
        'btnSetStatus
        '
        Me.btnSetStatus.Location = New System.Drawing.Point(124, 13)
        Me.btnSetStatus.Name = "btnSetStatus"
        Me.btnSetStatus.Size = New System.Drawing.Size(61, 30)
        Me.btnSetStatus.TabIndex = 24
        Me.btnSetStatus.Text = "Set"
        Me.btnSetStatus.UseVisualStyleBackColor = True
        '
        'tbStatusValue
        '
        Me.tbStatusValue.Location = New System.Drawing.Point(15, 48)
        Me.tbStatusValue.Name = "tbStatusValue"
        Me.tbStatusValue.Size = New System.Drawing.Size(103, 21)
        Me.tbStatusValue.TabIndex = 26
        Me.tbStatusValue.Visible = False
        '
        'btnGetStatus
        '
        Me.btnGetStatus.Location = New System.Drawing.Point(124, 43)
        Me.btnGetStatus.Name = "btnGetStatus"
        Me.btnGetStatus.Size = New System.Drawing.Size(61, 28)
        Me.btnGetStatus.TabIndex = 27
        Me.btnGetStatus.Text = "Get"
        Me.btnGetStatus.UseVisualStyleBackColor = True
        Me.btnGetStatus.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbSelDOSignal)
        Me.GroupBox3.Controls.Add(Me.tbDOValue)
        Me.GroupBox3.Controls.Add(Me.btnSetDO)
        Me.GroupBox3.Controls.Add(Me.btnGetDO)
        Me.GroupBox3.Location = New System.Drawing.Point(708, 110)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(178, 75)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Digital Output(Tower Lamp)"
        '
        'cbSelDOSignal
        '
        Me.cbSelDOSignal.FormattingEnabled = True
        Me.cbSelDOSignal.Items.AddRange(New Object() {"All OFF", "RED", "YELLOW", "GREEN", "BLUE"})
        Me.cbSelDOSignal.Location = New System.Drawing.Point(15, 22)
        Me.cbSelDOSignal.Name = "cbSelDOSignal"
        Me.cbSelDOSignal.Size = New System.Drawing.Size(89, 20)
        Me.cbSelDOSignal.TabIndex = 30
        '
        'tbDOValue
        '
        Me.tbDOValue.Location = New System.Drawing.Point(15, 48)
        Me.tbDOValue.Name = "tbDOValue"
        Me.tbDOValue.Size = New System.Drawing.Size(89, 21)
        Me.tbDOValue.TabIndex = 28
        '
        'btnSetDO
        '
        Me.btnSetDO.Location = New System.Drawing.Point(110, 16)
        Me.btnSetDO.Name = "btnSetDO"
        Me.btnSetDO.Size = New System.Drawing.Size(61, 30)
        Me.btnSetDO.TabIndex = 28
        Me.btnSetDO.Text = "Set"
        Me.btnSetDO.UseVisualStyleBackColor = True
        '
        'btnGetDO
        '
        Me.btnGetDO.Location = New System.Drawing.Point(110, 47)
        Me.btnGetDO.Name = "btnGetDO"
        Me.btnGetDO.Size = New System.Drawing.Size(61, 29)
        Me.btnGetDO.TabIndex = 29
        Me.btnGetDO.Text = "Get"
        Me.btnGetDO.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbSelDISignal)
        Me.GroupBox2.Controls.Add(Me.tbDIValue)
        Me.GroupBox2.Controls.Add(Me.btnSetDI)
        Me.GroupBox2.Controls.Add(Me.btnGetDI)
        Me.GroupBox2.Location = New System.Drawing.Point(510, 110)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(192, 75)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Digital Input(Alarm)"
        Me.GroupBox2.Visible = False
        '
        'cbSelDISignal
        '
        Me.cbSelDISignal.FormattingEnabled = True
        Me.cbSelDISignal.Items.AddRange(New Object() {"No Error", "Emergency", "Fire", "Heater", "Current Limit", "Interrock"})
        Me.cbSelDISignal.Location = New System.Drawing.Point(15, 22)
        Me.cbSelDISignal.Name = "cbSelDISignal"
        Me.cbSelDISignal.Size = New System.Drawing.Size(103, 20)
        Me.cbSelDISignal.TabIndex = 30
        '
        'tbDIValue
        '
        Me.tbDIValue.Location = New System.Drawing.Point(15, 48)
        Me.tbDIValue.Name = "tbDIValue"
        Me.tbDIValue.Size = New System.Drawing.Size(103, 21)
        Me.tbDIValue.TabIndex = 28
        '
        'btnSetDI
        '
        Me.btnSetDI.Location = New System.Drawing.Point(124, 13)
        Me.btnSetDI.Name = "btnSetDI"
        Me.btnSetDI.Size = New System.Drawing.Size(61, 30)
        Me.btnSetDI.TabIndex = 28
        Me.btnSetDI.Text = "Set"
        Me.btnSetDI.UseVisualStyleBackColor = True
        '
        'btnGetDI
        '
        Me.btnGetDI.Location = New System.Drawing.Point(124, 43)
        Me.btnGetDI.Name = "btnGetDI"
        Me.btnGetDI.Size = New System.Drawing.Size(61, 30)
        Me.btnGetDI.TabIndex = 29
        Me.btnGetDI.Text = "Get"
        Me.btnGetDI.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1511, 51)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(152, 21)
        Me.TextBox1.TabIndex = 46
        '
        'btnSend
        '
        Me.btnSend.Enabled = False
        Me.btnSend.Location = New System.Drawing.Point(1527, 129)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(112, 33)
        Me.btnSend.TabIndex = 48
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1525, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 12)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "00RSS0106%DW010"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(1511, 75)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(152, 21)
        Me.TextBox2.TabIndex = 49
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1434, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 12)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "Command : "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1443, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 12)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "Rcv Data :"
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.GroupBox38)
        Me.Panel2.Controls.Add(Me.GroupBox37)
        Me.Panel2.Location = New System.Drawing.Point(541, 222)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1247, 821)
        Me.Panel2.TabIndex = 61
        '
        'GroupBox26
        '
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_5)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_4)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_3)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_2)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_7)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_6)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_1)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_0)
        Me.GroupBox26.Location = New System.Drawing.Point(14, 17)
        Me.GroupBox26.Name = "GroupBox26"
        Me.GroupBox26.Size = New System.Drawing.Size(232, 275)
        Me.GroupBox26.TabIndex = 59
        Me.GroupBox26.TabStop = False
        Me.GroupBox26.Text = "EMS Alarm(D9200)"
        '
        'ledEMSAlarm_5
        '
        Me.ledEMSAlarm_5.AutoSize = True
        Me.ledEMSAlarm_5.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_5.BlinkInterval = 500
        Me.ledEMSAlarm_5.Label = "구동부 메인 M/C2 POWER OFF"
        Me.ledEMSAlarm_5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_5.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_5.Location = New System.Drawing.Point(11, 179)
        Me.ledEMSAlarm_5.Name = "ledEMSAlarm_5"
        Me.ledEMSAlarm_5.Renderer = Nothing
        Me.ledEMSAlarm_5.Size = New System.Drawing.Size(215, 32)
        Me.ledEMSAlarm_5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_5.TabIndex = 8
        '
        'ledEMSAlarm_4
        '
        Me.ledEMSAlarm_4.AutoSize = True
        Me.ledEMSAlarm_4.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_4.BlinkInterval = 500
        Me.ledEMSAlarm_4.Label = "구동부 메인 M/C1 POWER OFF"
        Me.ledEMSAlarm_4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_4.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_4.Location = New System.Drawing.Point(11, 147)
        Me.ledEMSAlarm_4.Name = "ledEMSAlarm_4"
        Me.ledEMSAlarm_4.Renderer = Nothing
        Me.ledEMSAlarm_4.Size = New System.Drawing.Size(215, 32)
        Me.ledEMSAlarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_4.TabIndex = 7
        '
        'ledEMSAlarm_3
        '
        Me.ledEMSAlarm_3.AutoSize = True
        Me.ledEMSAlarm_3.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_3.BlinkInterval = 500
        Me.ledEMSAlarm_3.Label = "세이프티 컨트롤러-2 알람"
        Me.ledEMSAlarm_3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_3.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_3.Location = New System.Drawing.Point(11, 115)
        Me.ledEMSAlarm_3.Name = "ledEMSAlarm_3"
        Me.ledEMSAlarm_3.Renderer = Nothing
        Me.ledEMSAlarm_3.Size = New System.Drawing.Size(215, 32)
        Me.ledEMSAlarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_3.TabIndex = 6
        '
        'ledEMSAlarm_2
        '
        Me.ledEMSAlarm_2.AutoSize = True
        Me.ledEMSAlarm_2.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_2.BlinkInterval = 500
        Me.ledEMSAlarm_2.Label = "세이프티 컨트롤러-1 알람"
        Me.ledEMSAlarm_2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_2.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_2.Location = New System.Drawing.Point(11, 83)
        Me.ledEMSAlarm_2.Name = "ledEMSAlarm_2"
        Me.ledEMSAlarm_2.Renderer = Nothing
        Me.ledEMSAlarm_2.Size = New System.Drawing.Size(215, 32)
        Me.ledEMSAlarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_2.TabIndex = 5
        '
        'ledEMSAlarm_7
        '
        Me.ledEMSAlarm_7.AutoSize = True
        Me.ledEMSAlarm_7.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_7.BlinkInterval = 500
        Me.ledEMSAlarm_7.Label = "컨트롤박스 연기감지 센서 알람"
        Me.ledEMSAlarm_7.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_7.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_7.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_7.Location = New System.Drawing.Point(11, 242)
        Me.ledEMSAlarm_7.Name = "ledEMSAlarm_7"
        Me.ledEMSAlarm_7.Renderer = Nothing
        Me.ledEMSAlarm_7.Size = New System.Drawing.Size(215, 32)
        Me.ledEMSAlarm_7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_7.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_7.TabIndex = 3
        '
        'ledEMSAlarm_6
        '
        Me.ledEMSAlarm_6.AutoSize = True
        Me.ledEMSAlarm_6.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_6.BlinkInterval = 500
        Me.ledEMSAlarm_6.Label = "컨트롤박스 내부 온도 알람"
        Me.ledEMSAlarm_6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_6.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_6.Location = New System.Drawing.Point(11, 210)
        Me.ledEMSAlarm_6.Name = "ledEMSAlarm_6"
        Me.ledEMSAlarm_6.Renderer = Nothing
        Me.ledEMSAlarm_6.Size = New System.Drawing.Size(215, 32)
        Me.ledEMSAlarm_6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_6.TabIndex = 2
        '
        'ledEMSAlarm_1
        '
        Me.ledEMSAlarm_1.AutoSize = True
        Me.ledEMSAlarm_1.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_1.BlinkInterval = 500
        Me.ledEMSAlarm_1.Label = "긴급정지 알람 (EMS -1)"
        Me.ledEMSAlarm_1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_1.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_1.Location = New System.Drawing.Point(11, 51)
        Me.ledEMSAlarm_1.Name = "ledEMSAlarm_1"
        Me.ledEMSAlarm_1.Renderer = Nothing
        Me.ledEMSAlarm_1.Size = New System.Drawing.Size(215, 32)
        Me.ledEMSAlarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_1.TabIndex = 1
        '
        'ledEMSAlarm_0
        '
        Me.ledEMSAlarm_0.AutoSize = True
        Me.ledEMSAlarm_0.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_0.BlinkInterval = 500
        Me.ledEMSAlarm_0.Label = "None"
        Me.ledEMSAlarm_0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_0.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_0.Location = New System.Drawing.Point(11, 19)
        Me.ledEMSAlarm_0.Name = "ledEMSAlarm_0"
        Me.ledEMSAlarm_0.Renderer = Nothing
        Me.ledEMSAlarm_0.Size = New System.Drawing.Size(215, 32)
        Me.ledEMSAlarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_0.TabIndex = 0
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.ledTempAlarm_0)
        Me.GroupBox10.Controls.Add(Me.ledTempAlarm_4)
        Me.GroupBox10.Controls.Add(Me.ledTempAlarm_3)
        Me.GroupBox10.Controls.Add(Me.ledTempAlarm_2)
        Me.GroupBox10.Controls.Add(Me.ledTempAlarm_1)
        Me.GroupBox10.Location = New System.Drawing.Point(249, 17)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(232, 179)
        Me.GroupBox10.TabIndex = 60
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Temperature Alarm(D9201)"
        '
        'ledTempAlarm_4
        '
        Me.ledTempAlarm_4.AutoSize = True
        Me.ledTempAlarm_4.BackColor = System.Drawing.Color.Transparent
        Me.ledTempAlarm_4.BlinkInterval = 500
        Me.ledTempAlarm_4.Label = "히터유닛 CH.4 온도 이상"
        Me.ledTempAlarm_4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTempAlarm_4.LedColor = System.Drawing.Color.Red
        Me.ledTempAlarm_4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTempAlarm_4.Location = New System.Drawing.Point(11, 143)
        Me.ledTempAlarm_4.Name = "ledTempAlarm_4"
        Me.ledTempAlarm_4.Renderer = Nothing
        Me.ledTempAlarm_4.Size = New System.Drawing.Size(215, 32)
        Me.ledTempAlarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTempAlarm_4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTempAlarm_4.TabIndex = 6
        '
        'ledTempAlarm_3
        '
        Me.ledTempAlarm_3.AutoSize = True
        Me.ledTempAlarm_3.BackColor = System.Drawing.Color.Transparent
        Me.ledTempAlarm_3.BlinkInterval = 500
        Me.ledTempAlarm_3.Label = "히터유닛 CH.3 온도 이상"
        Me.ledTempAlarm_3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTempAlarm_3.LedColor = System.Drawing.Color.Red
        Me.ledTempAlarm_3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTempAlarm_3.Location = New System.Drawing.Point(11, 111)
        Me.ledTempAlarm_3.Name = "ledTempAlarm_3"
        Me.ledTempAlarm_3.Renderer = Nothing
        Me.ledTempAlarm_3.Size = New System.Drawing.Size(215, 32)
        Me.ledTempAlarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTempAlarm_3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTempAlarm_3.TabIndex = 5
        '
        'ledTempAlarm_2
        '
        Me.ledTempAlarm_2.AutoSize = True
        Me.ledTempAlarm_2.BackColor = System.Drawing.Color.Transparent
        Me.ledTempAlarm_2.BlinkInterval = 500
        Me.ledTempAlarm_2.Label = "히터유닛 CH.2 온도 이상"
        Me.ledTempAlarm_2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTempAlarm_2.LedColor = System.Drawing.Color.Red
        Me.ledTempAlarm_2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTempAlarm_2.Location = New System.Drawing.Point(11, 79)
        Me.ledTempAlarm_2.Name = "ledTempAlarm_2"
        Me.ledTempAlarm_2.Renderer = Nothing
        Me.ledTempAlarm_2.Size = New System.Drawing.Size(215, 32)
        Me.ledTempAlarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTempAlarm_2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTempAlarm_2.TabIndex = 1
        '
        'ledTempAlarm_1
        '
        Me.ledTempAlarm_1.AutoSize = True
        Me.ledTempAlarm_1.BackColor = System.Drawing.Color.Transparent
        Me.ledTempAlarm_1.BlinkInterval = 500
        Me.ledTempAlarm_1.Label = "히터유닛 CH.1 온도 이상"
        Me.ledTempAlarm_1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTempAlarm_1.LedColor = System.Drawing.Color.Red
        Me.ledTempAlarm_1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTempAlarm_1.Location = New System.Drawing.Point(11, 47)
        Me.ledTempAlarm_1.Name = "ledTempAlarm_1"
        Me.ledTempAlarm_1.Renderer = Nothing
        Me.ledTempAlarm_1.Size = New System.Drawing.Size(215, 32)
        Me.ledTempAlarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTempAlarm_1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTempAlarm_1.TabIndex = 0
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.ledEOCRAlarm_0)
        Me.GroupBox12.Controls.Add(Me.ledEOCRAlarm_4)
        Me.GroupBox12.Controls.Add(Me.ledEOCRAlarm_3)
        Me.GroupBox12.Controls.Add(Me.ledEOCRAlarm_2)
        Me.GroupBox12.Controls.Add(Me.ledEOCRAlarm_1)
        Me.GroupBox12.Location = New System.Drawing.Point(484, 17)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(232, 179)
        Me.GroupBox12.TabIndex = 61
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "EOCR Alarm(D9202)"
        '
        'ledEOCRAlarm_4
        '
        Me.ledEOCRAlarm_4.AutoSize = True
        Me.ledEOCRAlarm_4.BackColor = System.Drawing.Color.Transparent
        Me.ledEOCRAlarm_4.BlinkInterval = 500
        Me.ledEOCRAlarm_4.Label = "히터유닛 CH.4 EOCR 상태 이상"
        Me.ledEOCRAlarm_4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEOCRAlarm_4.LedColor = System.Drawing.Color.Red
        Me.ledEOCRAlarm_4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEOCRAlarm_4.Location = New System.Drawing.Point(11, 144)
        Me.ledEOCRAlarm_4.Name = "ledEOCRAlarm_4"
        Me.ledEOCRAlarm_4.Renderer = Nothing
        Me.ledEOCRAlarm_4.Size = New System.Drawing.Size(215, 32)
        Me.ledEOCRAlarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEOCRAlarm_4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEOCRAlarm_4.TabIndex = 6
        '
        'ledEOCRAlarm_3
        '
        Me.ledEOCRAlarm_3.AutoSize = True
        Me.ledEOCRAlarm_3.BackColor = System.Drawing.Color.Transparent
        Me.ledEOCRAlarm_3.BlinkInterval = 500
        Me.ledEOCRAlarm_3.Label = "히터유닛 CH.3 EOCR 상태 이상"
        Me.ledEOCRAlarm_3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEOCRAlarm_3.LedColor = System.Drawing.Color.Red
        Me.ledEOCRAlarm_3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEOCRAlarm_3.Location = New System.Drawing.Point(11, 112)
        Me.ledEOCRAlarm_3.Name = "ledEOCRAlarm_3"
        Me.ledEOCRAlarm_3.Renderer = Nothing
        Me.ledEOCRAlarm_3.Size = New System.Drawing.Size(215, 32)
        Me.ledEOCRAlarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEOCRAlarm_3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEOCRAlarm_3.TabIndex = 5
        '
        'ledEOCRAlarm_2
        '
        Me.ledEOCRAlarm_2.AutoSize = True
        Me.ledEOCRAlarm_2.BackColor = System.Drawing.Color.Transparent
        Me.ledEOCRAlarm_2.BlinkInterval = 500
        Me.ledEOCRAlarm_2.Label = "히터유닛 CH.2 EOCR 상태 이상"
        Me.ledEOCRAlarm_2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEOCRAlarm_2.LedColor = System.Drawing.Color.Red
        Me.ledEOCRAlarm_2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEOCRAlarm_2.Location = New System.Drawing.Point(11, 80)
        Me.ledEOCRAlarm_2.Name = "ledEOCRAlarm_2"
        Me.ledEOCRAlarm_2.Renderer = Nothing
        Me.ledEOCRAlarm_2.Size = New System.Drawing.Size(215, 32)
        Me.ledEOCRAlarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEOCRAlarm_2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEOCRAlarm_2.TabIndex = 1
        '
        'ledEOCRAlarm_1
        '
        Me.ledEOCRAlarm_1.AutoSize = True
        Me.ledEOCRAlarm_1.BackColor = System.Drawing.Color.Transparent
        Me.ledEOCRAlarm_1.BlinkInterval = 500
        Me.ledEOCRAlarm_1.Label = "히터유닛 CH.1 EOCR 상태 이상"
        Me.ledEOCRAlarm_1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEOCRAlarm_1.LedColor = System.Drawing.Color.Red
        Me.ledEOCRAlarm_1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEOCRAlarm_1.Location = New System.Drawing.Point(11, 48)
        Me.ledEOCRAlarm_1.Name = "ledEOCRAlarm_1"
        Me.ledEOCRAlarm_1.Renderer = Nothing
        Me.ledEOCRAlarm_1.Size = New System.Drawing.Size(215, 32)
        Me.ledEOCRAlarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEOCRAlarm_1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEOCRAlarm_1.TabIndex = 0
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.ledSSR1Alarm_0)
        Me.GroupBox18.Controls.Add(Me.ledSSR1Alarm_4)
        Me.GroupBox18.Controls.Add(Me.ledSSR1Alarm_3)
        Me.GroupBox18.Controls.Add(Me.ledSSR1Alarm_2)
        Me.GroupBox18.Controls.Add(Me.ledSSR1Alarm_1)
        Me.GroupBox18.Location = New System.Drawing.Point(719, 17)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(232, 179)
        Me.GroupBox18.TabIndex = 62
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "SSR1 Alarm(D9203)"
        '
        'ledSSR1Alarm_4
        '
        Me.ledSSR1Alarm_4.AutoSize = True
        Me.ledSSR1Alarm_4.BackColor = System.Drawing.Color.Transparent
        Me.ledSSR1Alarm_4.BlinkInterval = 500
        Me.ledSSR1Alarm_4.Label = "히터유닛 CH.4 SSR 80도 알람"
        Me.ledSSR1Alarm_4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSSR1Alarm_4.LedColor = System.Drawing.Color.Red
        Me.ledSSR1Alarm_4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSSR1Alarm_4.Location = New System.Drawing.Point(11, 143)
        Me.ledSSR1Alarm_4.Name = "ledSSR1Alarm_4"
        Me.ledSSR1Alarm_4.Renderer = Nothing
        Me.ledSSR1Alarm_4.Size = New System.Drawing.Size(215, 32)
        Me.ledSSR1Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSSR1Alarm_4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSSR1Alarm_4.TabIndex = 6
        '
        'ledSSR1Alarm_3
        '
        Me.ledSSR1Alarm_3.AutoSize = True
        Me.ledSSR1Alarm_3.BackColor = System.Drawing.Color.Transparent
        Me.ledSSR1Alarm_3.BlinkInterval = 500
        Me.ledSSR1Alarm_3.Label = "히터유닛 CH.3 SSR 80도 알람"
        Me.ledSSR1Alarm_3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSSR1Alarm_3.LedColor = System.Drawing.Color.Red
        Me.ledSSR1Alarm_3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSSR1Alarm_3.Location = New System.Drawing.Point(11, 111)
        Me.ledSSR1Alarm_3.Name = "ledSSR1Alarm_3"
        Me.ledSSR1Alarm_3.Renderer = Nothing
        Me.ledSSR1Alarm_3.Size = New System.Drawing.Size(215, 32)
        Me.ledSSR1Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSSR1Alarm_3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSSR1Alarm_3.TabIndex = 5
        '
        'ledSSR1Alarm_2
        '
        Me.ledSSR1Alarm_2.AutoSize = True
        Me.ledSSR1Alarm_2.BackColor = System.Drawing.Color.Transparent
        Me.ledSSR1Alarm_2.BlinkInterval = 500
        Me.ledSSR1Alarm_2.Label = "히터유닛 CH.2 SSR 80도 알람"
        Me.ledSSR1Alarm_2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSSR1Alarm_2.LedColor = System.Drawing.Color.Red
        Me.ledSSR1Alarm_2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSSR1Alarm_2.Location = New System.Drawing.Point(11, 79)
        Me.ledSSR1Alarm_2.Name = "ledSSR1Alarm_2"
        Me.ledSSR1Alarm_2.Renderer = Nothing
        Me.ledSSR1Alarm_2.Size = New System.Drawing.Size(215, 32)
        Me.ledSSR1Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSSR1Alarm_2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSSR1Alarm_2.TabIndex = 1
        '
        'ledSSR1Alarm_1
        '
        Me.ledSSR1Alarm_1.AutoSize = True
        Me.ledSSR1Alarm_1.BackColor = System.Drawing.Color.Transparent
        Me.ledSSR1Alarm_1.BlinkInterval = 500
        Me.ledSSR1Alarm_1.Label = "히터유닛 CH.1 SSR 80도 알람"
        Me.ledSSR1Alarm_1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSSR1Alarm_1.LedColor = System.Drawing.Color.Red
        Me.ledSSR1Alarm_1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSSR1Alarm_1.Location = New System.Drawing.Point(11, 47)
        Me.ledSSR1Alarm_1.Name = "ledSSR1Alarm_1"
        Me.ledSSR1Alarm_1.Renderer = Nothing
        Me.ledSSR1Alarm_1.Size = New System.Drawing.Size(215, 32)
        Me.ledSSR1Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSSR1Alarm_1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSSR1Alarm_1.TabIndex = 0
        '
        'GroupBox27
        '
        Me.GroupBox27.Controls.Add(Me.ledSSR2Alarm_0)
        Me.GroupBox27.Controls.Add(Me.ledSSR2Alarm_4)
        Me.GroupBox27.Controls.Add(Me.ledSSR2Alarm_3)
        Me.GroupBox27.Controls.Add(Me.ledSSR2Alarm_2)
        Me.GroupBox27.Controls.Add(Me.ledSSR2Alarm_1)
        Me.GroupBox27.Location = New System.Drawing.Point(249, 203)
        Me.GroupBox27.Name = "GroupBox27"
        Me.GroupBox27.Size = New System.Drawing.Size(232, 179)
        Me.GroupBox27.TabIndex = 63
        Me.GroupBox27.TabStop = False
        Me.GroupBox27.Text = "SSR2 Alarm(D9204)"
        '
        'ledSSR2Alarm_4
        '
        Me.ledSSR2Alarm_4.AutoSize = True
        Me.ledSSR2Alarm_4.BackColor = System.Drawing.Color.Transparent
        Me.ledSSR2Alarm_4.BlinkInterval = 500
        Me.ledSSR2Alarm_4.Label = "히터유닛 CH.4 SSR 60도 알람"
        Me.ledSSR2Alarm_4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSSR2Alarm_4.LedColor = System.Drawing.Color.Red
        Me.ledSSR2Alarm_4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSSR2Alarm_4.Location = New System.Drawing.Point(13, 143)
        Me.ledSSR2Alarm_4.Name = "ledSSR2Alarm_4"
        Me.ledSSR2Alarm_4.Renderer = Nothing
        Me.ledSSR2Alarm_4.Size = New System.Drawing.Size(215, 32)
        Me.ledSSR2Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSSR2Alarm_4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSSR2Alarm_4.TabIndex = 6
        '
        'ledSSR2Alarm_3
        '
        Me.ledSSR2Alarm_3.AutoSize = True
        Me.ledSSR2Alarm_3.BackColor = System.Drawing.Color.Transparent
        Me.ledSSR2Alarm_3.BlinkInterval = 500
        Me.ledSSR2Alarm_3.Label = "히터유닛 CH.3 SSR 60도 알람"
        Me.ledSSR2Alarm_3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSSR2Alarm_3.LedColor = System.Drawing.Color.Red
        Me.ledSSR2Alarm_3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSSR2Alarm_3.Location = New System.Drawing.Point(13, 111)
        Me.ledSSR2Alarm_3.Name = "ledSSR2Alarm_3"
        Me.ledSSR2Alarm_3.Renderer = Nothing
        Me.ledSSR2Alarm_3.Size = New System.Drawing.Size(215, 32)
        Me.ledSSR2Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSSR2Alarm_3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSSR2Alarm_3.TabIndex = 5
        '
        'ledSSR2Alarm_2
        '
        Me.ledSSR2Alarm_2.AutoSize = True
        Me.ledSSR2Alarm_2.BackColor = System.Drawing.Color.Transparent
        Me.ledSSR2Alarm_2.BlinkInterval = 500
        Me.ledSSR2Alarm_2.Label = "히터유닛 CH.2 SSR 60도 알람"
        Me.ledSSR2Alarm_2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSSR2Alarm_2.LedColor = System.Drawing.Color.Red
        Me.ledSSR2Alarm_2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSSR2Alarm_2.Location = New System.Drawing.Point(13, 79)
        Me.ledSSR2Alarm_2.Name = "ledSSR2Alarm_2"
        Me.ledSSR2Alarm_2.Renderer = Nothing
        Me.ledSSR2Alarm_2.Size = New System.Drawing.Size(215, 32)
        Me.ledSSR2Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSSR2Alarm_2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSSR2Alarm_2.TabIndex = 1
        '
        'ledSSR2Alarm_1
        '
        Me.ledSSR2Alarm_1.AutoSize = True
        Me.ledSSR2Alarm_1.BackColor = System.Drawing.Color.Transparent
        Me.ledSSR2Alarm_1.BlinkInterval = 500
        Me.ledSSR2Alarm_1.Label = "히터유닛 CH.1 SSR 60도 알람"
        Me.ledSSR2Alarm_1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSSR2Alarm_1.LedColor = System.Drawing.Color.Red
        Me.ledSSR2Alarm_1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSSR2Alarm_1.Location = New System.Drawing.Point(13, 47)
        Me.ledSSR2Alarm_1.Name = "ledSSR2Alarm_1"
        Me.ledSSR2Alarm_1.Renderer = Nothing
        Me.ledSSR2Alarm_1.Size = New System.Drawing.Size(215, 32)
        Me.ledSSR2Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSSR2Alarm_1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSSR2Alarm_1.TabIndex = 0
        '
        'GroupBox28
        '
        Me.GroupBox28.Controls.Add(Me.ledTS1Alarm_0)
        Me.GroupBox28.Controls.Add(Me.ledTS1Alarm_4)
        Me.GroupBox28.Controls.Add(Me.ledTS1Alarm_3)
        Me.GroupBox28.Controls.Add(Me.ledTS1Alarm_2)
        Me.GroupBox28.Controls.Add(Me.ledTS1Alarm_1)
        Me.GroupBox28.Location = New System.Drawing.Point(484, 203)
        Me.GroupBox28.Name = "GroupBox28"
        Me.GroupBox28.Size = New System.Drawing.Size(232, 179)
        Me.GroupBox28.TabIndex = 64
        Me.GroupBox28.TabStop = False
        Me.GroupBox28.Text = "Temperture Sensor1 Alarm(D9205)"
        '
        'ledTS1Alarm_4
        '
        Me.ledTS1Alarm_4.AutoSize = True
        Me.ledTS1Alarm_4.BackColor = System.Drawing.Color.Transparent
        Me.ledTS1Alarm_4.BlinkInterval = 500
        Me.ledTS1Alarm_4.Label = "히터 온도센서 4-1 과온 알람"
        Me.ledTS1Alarm_4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTS1Alarm_4.LedColor = System.Drawing.Color.Red
        Me.ledTS1Alarm_4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTS1Alarm_4.Location = New System.Drawing.Point(13, 143)
        Me.ledTS1Alarm_4.Name = "ledTS1Alarm_4"
        Me.ledTS1Alarm_4.Renderer = Nothing
        Me.ledTS1Alarm_4.Size = New System.Drawing.Size(215, 32)
        Me.ledTS1Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTS1Alarm_4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTS1Alarm_4.TabIndex = 6
        '
        'ledTS1Alarm_3
        '
        Me.ledTS1Alarm_3.AutoSize = True
        Me.ledTS1Alarm_3.BackColor = System.Drawing.Color.Transparent
        Me.ledTS1Alarm_3.BlinkInterval = 500
        Me.ledTS1Alarm_3.Label = "히터 온도센서 3-1 과온 알람"
        Me.ledTS1Alarm_3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTS1Alarm_3.LedColor = System.Drawing.Color.Red
        Me.ledTS1Alarm_3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTS1Alarm_3.Location = New System.Drawing.Point(13, 111)
        Me.ledTS1Alarm_3.Name = "ledTS1Alarm_3"
        Me.ledTS1Alarm_3.Renderer = Nothing
        Me.ledTS1Alarm_3.Size = New System.Drawing.Size(215, 32)
        Me.ledTS1Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTS1Alarm_3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTS1Alarm_3.TabIndex = 5
        '
        'ledTS1Alarm_2
        '
        Me.ledTS1Alarm_2.AutoSize = True
        Me.ledTS1Alarm_2.BackColor = System.Drawing.Color.Transparent
        Me.ledTS1Alarm_2.BlinkInterval = 500
        Me.ledTS1Alarm_2.Label = "히터 온도센서 2-1 과온 알람"
        Me.ledTS1Alarm_2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTS1Alarm_2.LedColor = System.Drawing.Color.Red
        Me.ledTS1Alarm_2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTS1Alarm_2.Location = New System.Drawing.Point(13, 79)
        Me.ledTS1Alarm_2.Name = "ledTS1Alarm_2"
        Me.ledTS1Alarm_2.Renderer = Nothing
        Me.ledTS1Alarm_2.Size = New System.Drawing.Size(215, 32)
        Me.ledTS1Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTS1Alarm_2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTS1Alarm_2.TabIndex = 1
        '
        'ledTS1Alarm_1
        '
        Me.ledTS1Alarm_1.AutoSize = True
        Me.ledTS1Alarm_1.BackColor = System.Drawing.Color.Transparent
        Me.ledTS1Alarm_1.BlinkInterval = 500
        Me.ledTS1Alarm_1.Label = "히터 온도센서 1-1 과온 알람"
        Me.ledTS1Alarm_1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTS1Alarm_1.LedColor = System.Drawing.Color.Red
        Me.ledTS1Alarm_1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTS1Alarm_1.Location = New System.Drawing.Point(13, 47)
        Me.ledTS1Alarm_1.Name = "ledTS1Alarm_1"
        Me.ledTS1Alarm_1.Renderer = Nothing
        Me.ledTS1Alarm_1.Size = New System.Drawing.Size(215, 32)
        Me.ledTS1Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTS1Alarm_1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTS1Alarm_1.TabIndex = 0
        '
        'GroupBox29
        '
        Me.GroupBox29.Controls.Add(Me.ledTS2Alarm_0)
        Me.GroupBox29.Controls.Add(Me.ledTS2Alarm_4)
        Me.GroupBox29.Controls.Add(Me.ledTS2Alarm_3)
        Me.GroupBox29.Controls.Add(Me.ledTS2Alarm_2)
        Me.GroupBox29.Controls.Add(Me.ledTS2Alarm_1)
        Me.GroupBox29.Location = New System.Drawing.Point(719, 203)
        Me.GroupBox29.Name = "GroupBox29"
        Me.GroupBox29.Size = New System.Drawing.Size(232, 179)
        Me.GroupBox29.TabIndex = 65
        Me.GroupBox29.TabStop = False
        Me.GroupBox29.Text = "Temperture Sensor2 Alarm(D9206)"
        '
        'ledTS2Alarm_4
        '
        Me.ledTS2Alarm_4.AutoSize = True
        Me.ledTS2Alarm_4.BackColor = System.Drawing.Color.Transparent
        Me.ledTS2Alarm_4.BlinkInterval = 500
        Me.ledTS2Alarm_4.Label = "히터 온도센서 4-2 과온 알람"
        Me.ledTS2Alarm_4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTS2Alarm_4.LedColor = System.Drawing.Color.Red
        Me.ledTS2Alarm_4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTS2Alarm_4.Location = New System.Drawing.Point(13, 143)
        Me.ledTS2Alarm_4.Name = "ledTS2Alarm_4"
        Me.ledTS2Alarm_4.Renderer = Nothing
        Me.ledTS2Alarm_4.Size = New System.Drawing.Size(215, 32)
        Me.ledTS2Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTS2Alarm_4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTS2Alarm_4.TabIndex = 6
        '
        'ledTS2Alarm_3
        '
        Me.ledTS2Alarm_3.AutoSize = True
        Me.ledTS2Alarm_3.BackColor = System.Drawing.Color.Transparent
        Me.ledTS2Alarm_3.BlinkInterval = 500
        Me.ledTS2Alarm_3.Label = "히터 온도센서 3-2 과온 알람"
        Me.ledTS2Alarm_3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTS2Alarm_3.LedColor = System.Drawing.Color.Red
        Me.ledTS2Alarm_3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTS2Alarm_3.Location = New System.Drawing.Point(13, 111)
        Me.ledTS2Alarm_3.Name = "ledTS2Alarm_3"
        Me.ledTS2Alarm_3.Renderer = Nothing
        Me.ledTS2Alarm_3.Size = New System.Drawing.Size(215, 32)
        Me.ledTS2Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTS2Alarm_3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTS2Alarm_3.TabIndex = 5
        '
        'ledTS2Alarm_2
        '
        Me.ledTS2Alarm_2.AutoSize = True
        Me.ledTS2Alarm_2.BackColor = System.Drawing.Color.Transparent
        Me.ledTS2Alarm_2.BlinkInterval = 500
        Me.ledTS2Alarm_2.Label = "히터 온도센서 2-2 과온 알람"
        Me.ledTS2Alarm_2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTS2Alarm_2.LedColor = System.Drawing.Color.Red
        Me.ledTS2Alarm_2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTS2Alarm_2.Location = New System.Drawing.Point(13, 79)
        Me.ledTS2Alarm_2.Name = "ledTS2Alarm_2"
        Me.ledTS2Alarm_2.Renderer = Nothing
        Me.ledTS2Alarm_2.Size = New System.Drawing.Size(215, 32)
        Me.ledTS2Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTS2Alarm_2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTS2Alarm_2.TabIndex = 1
        '
        'ledTS2Alarm_1
        '
        Me.ledTS2Alarm_1.AutoSize = True
        Me.ledTS2Alarm_1.BackColor = System.Drawing.Color.Transparent
        Me.ledTS2Alarm_1.BlinkInterval = 500
        Me.ledTS2Alarm_1.Label = "히터 온도센서 1-2 과온 알람"
        Me.ledTS2Alarm_1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTS2Alarm_1.LedColor = System.Drawing.Color.Red
        Me.ledTS2Alarm_1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTS2Alarm_1.Location = New System.Drawing.Point(13, 47)
        Me.ledTS2Alarm_1.Name = "ledTS2Alarm_1"
        Me.ledTS2Alarm_1.Renderer = Nothing
        Me.ledTS2Alarm_1.Size = New System.Drawing.Size(215, 32)
        Me.ledTS2Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTS2Alarm_1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTS2Alarm_1.TabIndex = 0
        '
        'GroupBox30
        '
        Me.GroupBox30.Controls.Add(Me.ledDoorAlarm_0)
        Me.GroupBox30.Controls.Add(Me.ledDoorAlarm_3)
        Me.GroupBox30.Controls.Add(Me.ledDoorAlarm_2)
        Me.GroupBox30.Controls.Add(Me.ledDoorAlarm_1)
        Me.GroupBox30.Location = New System.Drawing.Point(14, 292)
        Me.GroupBox30.Name = "GroupBox30"
        Me.GroupBox30.Size = New System.Drawing.Size(232, 139)
        Me.GroupBox30.TabIndex = 66
        Me.GroupBox30.TabStop = False
        Me.GroupBox30.Text = "Door Alarm(D9208)"
        '
        'ledDoorAlarm_3
        '
        Me.ledDoorAlarm_3.AutoSize = True
        Me.ledDoorAlarm_3.BackColor = System.Drawing.Color.Transparent
        Me.ledDoorAlarm_3.BlinkInterval = 500
        Me.ledDoorAlarm_3.Label = "세이프티 도어-2 개방 (X016)"
        Me.ledDoorAlarm_3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledDoorAlarm_3.LedColor = System.Drawing.Color.Red
        Me.ledDoorAlarm_3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledDoorAlarm_3.Location = New System.Drawing.Point(11, 104)
        Me.ledDoorAlarm_3.Name = "ledDoorAlarm_3"
        Me.ledDoorAlarm_3.Renderer = Nothing
        Me.ledDoorAlarm_3.Size = New System.Drawing.Size(215, 32)
        Me.ledDoorAlarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledDoorAlarm_3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledDoorAlarm_3.TabIndex = 5
        '
        'ledDoorAlarm_2
        '
        Me.ledDoorAlarm_2.AutoSize = True
        Me.ledDoorAlarm_2.BackColor = System.Drawing.Color.Transparent
        Me.ledDoorAlarm_2.BlinkInterval = 500
        Me.ledDoorAlarm_2.Label = "세이프티 도어-1 개방 (X00C)"
        Me.ledDoorAlarm_2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledDoorAlarm_2.LedColor = System.Drawing.Color.Red
        Me.ledDoorAlarm_2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledDoorAlarm_2.Location = New System.Drawing.Point(11, 72)
        Me.ledDoorAlarm_2.Name = "ledDoorAlarm_2"
        Me.ledDoorAlarm_2.Renderer = Nothing
        Me.ledDoorAlarm_2.Size = New System.Drawing.Size(215, 32)
        Me.ledDoorAlarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledDoorAlarm_2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledDoorAlarm_2.TabIndex = 1
        '
        'ledDoorAlarm_1
        '
        Me.ledDoorAlarm_1.AutoSize = True
        Me.ledDoorAlarm_1.BackColor = System.Drawing.Color.Transparent
        Me.ledDoorAlarm_1.BlinkInterval = 500
        Me.ledDoorAlarm_1.Label = "세이프티 도어 루프 에러"
        Me.ledDoorAlarm_1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledDoorAlarm_1.LedColor = System.Drawing.Color.Red
        Me.ledDoorAlarm_1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledDoorAlarm_1.Location = New System.Drawing.Point(11, 40)
        Me.ledDoorAlarm_1.Name = "ledDoorAlarm_1"
        Me.ledDoorAlarm_1.Renderer = Nothing
        Me.ledDoorAlarm_1.Size = New System.Drawing.Size(215, 32)
        Me.ledDoorAlarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledDoorAlarm_1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledDoorAlarm_1.TabIndex = 0
        '
        'GroupBox31
        '
        Me.GroupBox31.Controls.Add(Me.ledXAlarm_9)
        Me.GroupBox31.Controls.Add(Me.ledXAlarm_8)
        Me.GroupBox31.Controls.Add(Me.ledXAlarm_5)
        Me.GroupBox31.Controls.Add(Me.ledXAlarm_4)
        Me.GroupBox31.Controls.Add(Me.ledXAlarm_3)
        Me.GroupBox31.Controls.Add(Me.ledXAlarm_2)
        Me.GroupBox31.Controls.Add(Me.ledXAlarm_7)
        Me.GroupBox31.Controls.Add(Me.ledXAlarm_6)
        Me.GroupBox31.Controls.Add(Me.ledXAlarm_1)
        Me.GroupBox31.Controls.Add(Me.ledXAlarm_0)
        Me.GroupBox31.Location = New System.Drawing.Point(14, 448)
        Me.GroupBox31.Name = "GroupBox31"
        Me.GroupBox31.Size = New System.Drawing.Size(232, 349)
        Me.GroupBox31.TabIndex = 60
        Me.GroupBox31.TabStop = False
        Me.GroupBox31.Text = "X Axis Alarm(D9212)"
        '
        'ledXAlarm_5
        '
        Me.ledXAlarm_5.AutoSize = True
        Me.ledXAlarm_5.BackColor = System.Drawing.Color.Transparent
        Me.ledXAlarm_5.BlinkInterval = 500
        Me.ledXAlarm_5.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledXAlarm_5.Label = "[Ax.03] IVL-X 충돌감지 알람"
        Me.ledXAlarm_5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledXAlarm_5.LedColor = System.Drawing.Color.Red
        Me.ledXAlarm_5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledXAlarm_5.Location = New System.Drawing.Point(11, 176)
        Me.ledXAlarm_5.Name = "ledXAlarm_5"
        Me.ledXAlarm_5.Renderer = Nothing
        Me.ledXAlarm_5.Size = New System.Drawing.Size(215, 32)
        Me.ledXAlarm_5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledXAlarm_5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledXAlarm_5.TabIndex = 8
        '
        'ledXAlarm_4
        '
        Me.ledXAlarm_4.AutoSize = True
        Me.ledXAlarm_4.BackColor = System.Drawing.Color.Transparent
        Me.ledXAlarm_4.BlinkInterval = 500
        Me.ledXAlarm_4.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledXAlarm_4.Label = "[Ax.03] IVL-X FLS 리밋센서 알람"
        Me.ledXAlarm_4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledXAlarm_4.LedColor = System.Drawing.Color.Red
        Me.ledXAlarm_4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledXAlarm_4.Location = New System.Drawing.Point(11, 144)
        Me.ledXAlarm_4.Name = "ledXAlarm_4"
        Me.ledXAlarm_4.Renderer = Nothing
        Me.ledXAlarm_4.Size = New System.Drawing.Size(215, 32)
        Me.ledXAlarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledXAlarm_4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledXAlarm_4.TabIndex = 7
        '
        'ledXAlarm_3
        '
        Me.ledXAlarm_3.AutoSize = True
        Me.ledXAlarm_3.BackColor = System.Drawing.Color.Transparent
        Me.ledXAlarm_3.BlinkInterval = 500
        Me.ledXAlarm_3.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledXAlarm_3.Label = "[Ax.03] IVL-X RLS 리밋센서 알람"
        Me.ledXAlarm_3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledXAlarm_3.LedColor = System.Drawing.Color.Red
        Me.ledXAlarm_3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledXAlarm_3.Location = New System.Drawing.Point(11, 112)
        Me.ledXAlarm_3.Name = "ledXAlarm_3"
        Me.ledXAlarm_3.Renderer = Nothing
        Me.ledXAlarm_3.Size = New System.Drawing.Size(215, 32)
        Me.ledXAlarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledXAlarm_3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledXAlarm_3.TabIndex = 6
        '
        'ledXAlarm_2
        '
        Me.ledXAlarm_2.AutoSize = True
        Me.ledXAlarm_2.BackColor = System.Drawing.Color.Transparent
        Me.ledXAlarm_2.BlinkInterval = 500
        Me.ledXAlarm_2.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledXAlarm_2.Label = "[Ax.03] IVL-X 서보 알람"
        Me.ledXAlarm_2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledXAlarm_2.LedColor = System.Drawing.Color.Red
        Me.ledXAlarm_2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledXAlarm_2.Location = New System.Drawing.Point(11, 80)
        Me.ledXAlarm_2.Name = "ledXAlarm_2"
        Me.ledXAlarm_2.Renderer = Nothing
        Me.ledXAlarm_2.Size = New System.Drawing.Size(215, 32)
        Me.ledXAlarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledXAlarm_2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledXAlarm_2.TabIndex = 5
        '
        'ledXAlarm_7
        '
        Me.ledXAlarm_7.AutoSize = True
        Me.ledXAlarm_7.BackColor = System.Drawing.Color.Transparent
        Me.ledXAlarm_7.BlinkInterval = 500
        Me.ledXAlarm_7.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledXAlarm_7.Label = "[Ax.03] IVL-X 위치운전 타임아웃"
        Me.ledXAlarm_7.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledXAlarm_7.LedColor = System.Drawing.Color.Red
        Me.ledXAlarm_7.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledXAlarm_7.Location = New System.Drawing.Point(11, 239)
        Me.ledXAlarm_7.Name = "ledXAlarm_7"
        Me.ledXAlarm_7.Renderer = Nothing
        Me.ledXAlarm_7.Size = New System.Drawing.Size(215, 32)
        Me.ledXAlarm_7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledXAlarm_7.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledXAlarm_7.TabIndex = 3
        '
        'ledXAlarm_6
        '
        Me.ledXAlarm_6.AutoSize = True
        Me.ledXAlarm_6.BackColor = System.Drawing.Color.Transparent
        Me.ledXAlarm_6.BlinkInterval = 500
        Me.ledXAlarm_6.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledXAlarm_6.Label = "[Ax.03] IVL-X 원점운전 타임아웃"
        Me.ledXAlarm_6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledXAlarm_6.LedColor = System.Drawing.Color.Red
        Me.ledXAlarm_6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledXAlarm_6.Location = New System.Drawing.Point(11, 207)
        Me.ledXAlarm_6.Name = "ledXAlarm_6"
        Me.ledXAlarm_6.Renderer = Nothing
        Me.ledXAlarm_6.Size = New System.Drawing.Size(215, 32)
        Me.ledXAlarm_6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledXAlarm_6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledXAlarm_6.TabIndex = 2
        '
        'ledXAlarm_1
        '
        Me.ledXAlarm_1.AutoSize = True
        Me.ledXAlarm_1.BackColor = System.Drawing.Color.Transparent
        Me.ledXAlarm_1.BlinkInterval = 500
        Me.ledXAlarm_1.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledXAlarm_1.Label = "[Ax.03] IVL-X 축 알람"
        Me.ledXAlarm_1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledXAlarm_1.LedColor = System.Drawing.Color.Red
        Me.ledXAlarm_1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledXAlarm_1.Location = New System.Drawing.Point(11, 48)
        Me.ledXAlarm_1.Name = "ledXAlarm_1"
        Me.ledXAlarm_1.Renderer = Nothing
        Me.ledXAlarm_1.Size = New System.Drawing.Size(215, 32)
        Me.ledXAlarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledXAlarm_1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledXAlarm_1.TabIndex = 1
        '
        'ledXAlarm_0
        '
        Me.ledXAlarm_0.AutoSize = True
        Me.ledXAlarm_0.BackColor = System.Drawing.Color.Transparent
        Me.ledXAlarm_0.BlinkInterval = 500
        Me.ledXAlarm_0.Label = "None"
        Me.ledXAlarm_0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledXAlarm_0.LedColor = System.Drawing.Color.Red
        Me.ledXAlarm_0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledXAlarm_0.Location = New System.Drawing.Point(11, 16)
        Me.ledXAlarm_0.Name = "ledXAlarm_0"
        Me.ledXAlarm_0.Renderer = Nothing
        Me.ledXAlarm_0.Size = New System.Drawing.Size(215, 32)
        Me.ledXAlarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledXAlarm_0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledXAlarm_0.TabIndex = 0
        '
        'ledXAlarm_9
        '
        Me.ledXAlarm_9.AutoSize = True
        Me.ledXAlarm_9.BackColor = System.Drawing.Color.Transparent
        Me.ledXAlarm_9.BlinkInterval = 500
        Me.ledXAlarm_9.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledXAlarm_9.Label = "[Ax.03] IVL-X 과전류 알람"
        Me.ledXAlarm_9.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledXAlarm_9.LedColor = System.Drawing.Color.Red
        Me.ledXAlarm_9.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledXAlarm_9.Location = New System.Drawing.Point(11, 303)
        Me.ledXAlarm_9.Name = "ledXAlarm_9"
        Me.ledXAlarm_9.Renderer = Nothing
        Me.ledXAlarm_9.Size = New System.Drawing.Size(215, 32)
        Me.ledXAlarm_9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledXAlarm_9.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledXAlarm_9.TabIndex = 10
        '
        'ledXAlarm_8
        '
        Me.ledXAlarm_8.AutoSize = True
        Me.ledXAlarm_8.BackColor = System.Drawing.Color.Transparent
        Me.ledXAlarm_8.BlinkInterval = 500
        Me.ledXAlarm_8.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledXAlarm_8.Label = "[Ax.03] IVL-X AMP 과온 알람"
        Me.ledXAlarm_8.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledXAlarm_8.LedColor = System.Drawing.Color.Red
        Me.ledXAlarm_8.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledXAlarm_8.Location = New System.Drawing.Point(11, 271)
        Me.ledXAlarm_8.Name = "ledXAlarm_8"
        Me.ledXAlarm_8.Renderer = Nothing
        Me.ledXAlarm_8.Size = New System.Drawing.Size(215, 32)
        Me.ledXAlarm_8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledXAlarm_8.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledXAlarm_8.TabIndex = 9
        '
        'GroupBox32
        '
        Me.GroupBox32.Controls.Add(Me.ledY1Alarm_10)
        Me.GroupBox32.Controls.Add(Me.ledY1Alarm_9)
        Me.GroupBox32.Controls.Add(Me.ledY1Alarm_8)
        Me.GroupBox32.Controls.Add(Me.ledY1Alarm_5)
        Me.GroupBox32.Controls.Add(Me.ledY1Alarm_4)
        Me.GroupBox32.Controls.Add(Me.ledY1Alarm_3)
        Me.GroupBox32.Controls.Add(Me.ledY1Alarm_2)
        Me.GroupBox32.Controls.Add(Me.ledY1Alarm_7)
        Me.GroupBox32.Controls.Add(Me.ledY1Alarm_6)
        Me.GroupBox32.Controls.Add(Me.ledY1Alarm_1)
        Me.GroupBox32.Controls.Add(Me.ledY1Alarm_0)
        Me.GroupBox32.Location = New System.Drawing.Point(249, 417)
        Me.GroupBox32.Name = "GroupBox32"
        Me.GroupBox32.Size = New System.Drawing.Size(232, 380)
        Me.GroupBox32.TabIndex = 61
        Me.GroupBox32.TabStop = False
        Me.GroupBox32.Text = "Y1 Axis Alarm(D9210)"
        '
        'ledY1Alarm_9
        '
        Me.ledY1Alarm_9.AutoSize = True
        Me.ledY1Alarm_9.BackColor = System.Drawing.Color.Transparent
        Me.ledY1Alarm_9.BlinkInterval = 500
        Me.ledY1Alarm_9.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY1Alarm_9.Label = "[Ax.01] IVL-Y1 과전류 알람"
        Me.ledY1Alarm_9.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY1Alarm_9.LedColor = System.Drawing.Color.Red
        Me.ledY1Alarm_9.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY1Alarm_9.Location = New System.Drawing.Point(11, 303)
        Me.ledY1Alarm_9.Name = "ledY1Alarm_9"
        Me.ledY1Alarm_9.Renderer = Nothing
        Me.ledY1Alarm_9.Size = New System.Drawing.Size(215, 32)
        Me.ledY1Alarm_9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY1Alarm_9.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY1Alarm_9.TabIndex = 10
        '
        'ledY1Alarm_8
        '
        Me.ledY1Alarm_8.AutoSize = True
        Me.ledY1Alarm_8.BackColor = System.Drawing.Color.Transparent
        Me.ledY1Alarm_8.BlinkInterval = 500
        Me.ledY1Alarm_8.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY1Alarm_8.Label = "[Ax.01] IVL-Y1 AMP 과온 알람"
        Me.ledY1Alarm_8.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY1Alarm_8.LedColor = System.Drawing.Color.Red
        Me.ledY1Alarm_8.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY1Alarm_8.Location = New System.Drawing.Point(11, 271)
        Me.ledY1Alarm_8.Name = "ledY1Alarm_8"
        Me.ledY1Alarm_8.Renderer = Nothing
        Me.ledY1Alarm_8.Size = New System.Drawing.Size(215, 32)
        Me.ledY1Alarm_8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY1Alarm_8.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY1Alarm_8.TabIndex = 9
        '
        'ledY1Alarm_5
        '
        Me.ledY1Alarm_5.AutoSize = True
        Me.ledY1Alarm_5.BackColor = System.Drawing.Color.Transparent
        Me.ledY1Alarm_5.BlinkInterval = 500
        Me.ledY1Alarm_5.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY1Alarm_5.Label = "[Ax.01] IVL-Y1 충돌감지 알람"
        Me.ledY1Alarm_5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY1Alarm_5.LedColor = System.Drawing.Color.Red
        Me.ledY1Alarm_5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY1Alarm_5.Location = New System.Drawing.Point(11, 176)
        Me.ledY1Alarm_5.Name = "ledY1Alarm_5"
        Me.ledY1Alarm_5.Renderer = Nothing
        Me.ledY1Alarm_5.Size = New System.Drawing.Size(215, 32)
        Me.ledY1Alarm_5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY1Alarm_5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY1Alarm_5.TabIndex = 8
        '
        'ledY1Alarm_4
        '
        Me.ledY1Alarm_4.AutoSize = True
        Me.ledY1Alarm_4.BackColor = System.Drawing.Color.Transparent
        Me.ledY1Alarm_4.BlinkInterval = 500
        Me.ledY1Alarm_4.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY1Alarm_4.Label = "[Ax.01] IVL-Y1 FLS 리밋센서 알람"
        Me.ledY1Alarm_4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY1Alarm_4.LedColor = System.Drawing.Color.Red
        Me.ledY1Alarm_4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY1Alarm_4.Location = New System.Drawing.Point(11, 144)
        Me.ledY1Alarm_4.Name = "ledY1Alarm_4"
        Me.ledY1Alarm_4.Renderer = Nothing
        Me.ledY1Alarm_4.Size = New System.Drawing.Size(215, 32)
        Me.ledY1Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY1Alarm_4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY1Alarm_4.TabIndex = 7
        '
        'ledY1Alarm_3
        '
        Me.ledY1Alarm_3.AutoSize = True
        Me.ledY1Alarm_3.BackColor = System.Drawing.Color.Transparent
        Me.ledY1Alarm_3.BlinkInterval = 500
        Me.ledY1Alarm_3.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY1Alarm_3.Label = "[Ax.01] IVL-Y1 RLS 리밋센서 알람"
        Me.ledY1Alarm_3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY1Alarm_3.LedColor = System.Drawing.Color.Red
        Me.ledY1Alarm_3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY1Alarm_3.Location = New System.Drawing.Point(11, 112)
        Me.ledY1Alarm_3.Name = "ledY1Alarm_3"
        Me.ledY1Alarm_3.Renderer = Nothing
        Me.ledY1Alarm_3.Size = New System.Drawing.Size(215, 32)
        Me.ledY1Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY1Alarm_3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY1Alarm_3.TabIndex = 6
        '
        'ledY1Alarm_2
        '
        Me.ledY1Alarm_2.AutoSize = True
        Me.ledY1Alarm_2.BackColor = System.Drawing.Color.Transparent
        Me.ledY1Alarm_2.BlinkInterval = 500
        Me.ledY1Alarm_2.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY1Alarm_2.Label = "[Ax.01] IVL-Y1 서보 알람"
        Me.ledY1Alarm_2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY1Alarm_2.LedColor = System.Drawing.Color.Red
        Me.ledY1Alarm_2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY1Alarm_2.Location = New System.Drawing.Point(11, 80)
        Me.ledY1Alarm_2.Name = "ledY1Alarm_2"
        Me.ledY1Alarm_2.Renderer = Nothing
        Me.ledY1Alarm_2.Size = New System.Drawing.Size(215, 32)
        Me.ledY1Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY1Alarm_2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY1Alarm_2.TabIndex = 5
        '
        'ledY1Alarm_7
        '
        Me.ledY1Alarm_7.AutoSize = True
        Me.ledY1Alarm_7.BackColor = System.Drawing.Color.Transparent
        Me.ledY1Alarm_7.BlinkInterval = 500
        Me.ledY1Alarm_7.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY1Alarm_7.Label = "[Ax.01] IVL-Y1 위치운전 타임아웃"
        Me.ledY1Alarm_7.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY1Alarm_7.LedColor = System.Drawing.Color.Red
        Me.ledY1Alarm_7.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY1Alarm_7.Location = New System.Drawing.Point(11, 239)
        Me.ledY1Alarm_7.Name = "ledY1Alarm_7"
        Me.ledY1Alarm_7.Renderer = Nothing
        Me.ledY1Alarm_7.Size = New System.Drawing.Size(215, 32)
        Me.ledY1Alarm_7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY1Alarm_7.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY1Alarm_7.TabIndex = 3
        '
        'ledY1Alarm_6
        '
        Me.ledY1Alarm_6.AutoSize = True
        Me.ledY1Alarm_6.BackColor = System.Drawing.Color.Transparent
        Me.ledY1Alarm_6.BlinkInterval = 500
        Me.ledY1Alarm_6.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY1Alarm_6.Label = "[Ax.01] IVL-Y1 원점운전 타임아웃"
        Me.ledY1Alarm_6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY1Alarm_6.LedColor = System.Drawing.Color.Red
        Me.ledY1Alarm_6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY1Alarm_6.Location = New System.Drawing.Point(11, 207)
        Me.ledY1Alarm_6.Name = "ledY1Alarm_6"
        Me.ledY1Alarm_6.Renderer = Nothing
        Me.ledY1Alarm_6.Size = New System.Drawing.Size(215, 32)
        Me.ledY1Alarm_6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY1Alarm_6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY1Alarm_6.TabIndex = 2
        '
        'ledY1Alarm_1
        '
        Me.ledY1Alarm_1.AutoSize = True
        Me.ledY1Alarm_1.BackColor = System.Drawing.Color.Transparent
        Me.ledY1Alarm_1.BlinkInterval = 500
        Me.ledY1Alarm_1.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY1Alarm_1.Label = "[Ax.01] IVL-Y1 축 알람"
        Me.ledY1Alarm_1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY1Alarm_1.LedColor = System.Drawing.Color.Red
        Me.ledY1Alarm_1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY1Alarm_1.Location = New System.Drawing.Point(11, 48)
        Me.ledY1Alarm_1.Name = "ledY1Alarm_1"
        Me.ledY1Alarm_1.Renderer = Nothing
        Me.ledY1Alarm_1.Size = New System.Drawing.Size(215, 32)
        Me.ledY1Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY1Alarm_1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY1Alarm_1.TabIndex = 1
        '
        'ledY1Alarm_0
        '
        Me.ledY1Alarm_0.AutoSize = True
        Me.ledY1Alarm_0.BackColor = System.Drawing.Color.Transparent
        Me.ledY1Alarm_0.BlinkInterval = 500
        Me.ledY1Alarm_0.Label = "None"
        Me.ledY1Alarm_0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY1Alarm_0.LedColor = System.Drawing.Color.Red
        Me.ledY1Alarm_0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY1Alarm_0.Location = New System.Drawing.Point(11, 16)
        Me.ledY1Alarm_0.Name = "ledY1Alarm_0"
        Me.ledY1Alarm_0.Renderer = Nothing
        Me.ledY1Alarm_0.Size = New System.Drawing.Size(215, 32)
        Me.ledY1Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY1Alarm_0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY1Alarm_0.TabIndex = 0
        '
        'GroupBox33
        '
        Me.GroupBox33.Controls.Add(Me.ledY2Alarm_9)
        Me.GroupBox33.Controls.Add(Me.ledY2Alarm_8)
        Me.GroupBox33.Controls.Add(Me.ledY2Alarm_5)
        Me.GroupBox33.Controls.Add(Me.ledY2Alarm_4)
        Me.GroupBox33.Controls.Add(Me.ledY2Alarm_3)
        Me.GroupBox33.Controls.Add(Me.ledY2Alarm_2)
        Me.GroupBox33.Controls.Add(Me.ledY2Alarm_7)
        Me.GroupBox33.Controls.Add(Me.ledY2Alarm_6)
        Me.GroupBox33.Controls.Add(Me.ledY2Alarm_1)
        Me.GroupBox33.Controls.Add(Me.ledY2Alarm_0)
        Me.GroupBox33.Location = New System.Drawing.Point(484, 453)
        Me.GroupBox33.Name = "GroupBox33"
        Me.GroupBox33.Size = New System.Drawing.Size(232, 349)
        Me.GroupBox33.TabIndex = 62
        Me.GroupBox33.TabStop = False
        Me.GroupBox33.Text = "Y2 Axis Alarm(D9211)"
        '
        'ledY2Alarm_9
        '
        Me.ledY2Alarm_9.AutoSize = True
        Me.ledY2Alarm_9.BackColor = System.Drawing.Color.Transparent
        Me.ledY2Alarm_9.BlinkInterval = 500
        Me.ledY2Alarm_9.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY2Alarm_9.Label = "[Ax.02] IVL-Y2 과전류 알람"
        Me.ledY2Alarm_9.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY2Alarm_9.LedColor = System.Drawing.Color.Red
        Me.ledY2Alarm_9.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY2Alarm_9.Location = New System.Drawing.Point(11, 303)
        Me.ledY2Alarm_9.Name = "ledY2Alarm_9"
        Me.ledY2Alarm_9.Renderer = Nothing
        Me.ledY2Alarm_9.Size = New System.Drawing.Size(215, 32)
        Me.ledY2Alarm_9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY2Alarm_9.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY2Alarm_9.TabIndex = 10
        '
        'ledY2Alarm_8
        '
        Me.ledY2Alarm_8.AutoSize = True
        Me.ledY2Alarm_8.BackColor = System.Drawing.Color.Transparent
        Me.ledY2Alarm_8.BlinkInterval = 500
        Me.ledY2Alarm_8.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY2Alarm_8.Label = "[Ax.02] IVL-Y2 AMP 과온 알람"
        Me.ledY2Alarm_8.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY2Alarm_8.LedColor = System.Drawing.Color.Red
        Me.ledY2Alarm_8.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY2Alarm_8.Location = New System.Drawing.Point(11, 271)
        Me.ledY2Alarm_8.Name = "ledY2Alarm_8"
        Me.ledY2Alarm_8.Renderer = Nothing
        Me.ledY2Alarm_8.Size = New System.Drawing.Size(215, 32)
        Me.ledY2Alarm_8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY2Alarm_8.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY2Alarm_8.TabIndex = 9
        '
        'ledY2Alarm_5
        '
        Me.ledY2Alarm_5.AutoSize = True
        Me.ledY2Alarm_5.BackColor = System.Drawing.Color.Transparent
        Me.ledY2Alarm_5.BlinkInterval = 500
        Me.ledY2Alarm_5.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY2Alarm_5.Label = "[Ax.02] IVL-Y2 충돌감지 알람"
        Me.ledY2Alarm_5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY2Alarm_5.LedColor = System.Drawing.Color.Red
        Me.ledY2Alarm_5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY2Alarm_5.Location = New System.Drawing.Point(11, 176)
        Me.ledY2Alarm_5.Name = "ledY2Alarm_5"
        Me.ledY2Alarm_5.Renderer = Nothing
        Me.ledY2Alarm_5.Size = New System.Drawing.Size(215, 32)
        Me.ledY2Alarm_5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY2Alarm_5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY2Alarm_5.TabIndex = 8
        '
        'ledY2Alarm_4
        '
        Me.ledY2Alarm_4.AutoSize = True
        Me.ledY2Alarm_4.BackColor = System.Drawing.Color.Transparent
        Me.ledY2Alarm_4.BlinkInterval = 500
        Me.ledY2Alarm_4.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY2Alarm_4.Label = "[Ax.02] IVL-Y2 FLS 리밋센서 알람"
        Me.ledY2Alarm_4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY2Alarm_4.LedColor = System.Drawing.Color.Red
        Me.ledY2Alarm_4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY2Alarm_4.Location = New System.Drawing.Point(11, 144)
        Me.ledY2Alarm_4.Name = "ledY2Alarm_4"
        Me.ledY2Alarm_4.Renderer = Nothing
        Me.ledY2Alarm_4.Size = New System.Drawing.Size(215, 32)
        Me.ledY2Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY2Alarm_4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY2Alarm_4.TabIndex = 7
        '
        'ledY2Alarm_3
        '
        Me.ledY2Alarm_3.AutoSize = True
        Me.ledY2Alarm_3.BackColor = System.Drawing.Color.Transparent
        Me.ledY2Alarm_3.BlinkInterval = 500
        Me.ledY2Alarm_3.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY2Alarm_3.Label = "[Ax.02] IVL-Y2 RLS 리밋센서 알람"
        Me.ledY2Alarm_3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY2Alarm_3.LedColor = System.Drawing.Color.Red
        Me.ledY2Alarm_3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY2Alarm_3.Location = New System.Drawing.Point(11, 112)
        Me.ledY2Alarm_3.Name = "ledY2Alarm_3"
        Me.ledY2Alarm_3.Renderer = Nothing
        Me.ledY2Alarm_3.Size = New System.Drawing.Size(215, 32)
        Me.ledY2Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY2Alarm_3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY2Alarm_3.TabIndex = 6
        '
        'ledY2Alarm_2
        '
        Me.ledY2Alarm_2.AutoSize = True
        Me.ledY2Alarm_2.BackColor = System.Drawing.Color.Transparent
        Me.ledY2Alarm_2.BlinkInterval = 500
        Me.ledY2Alarm_2.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY2Alarm_2.Label = "[Ax.02] IVL-Y2 서보 알람"
        Me.ledY2Alarm_2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY2Alarm_2.LedColor = System.Drawing.Color.Red
        Me.ledY2Alarm_2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY2Alarm_2.Location = New System.Drawing.Point(11, 80)
        Me.ledY2Alarm_2.Name = "ledY2Alarm_2"
        Me.ledY2Alarm_2.Renderer = Nothing
        Me.ledY2Alarm_2.Size = New System.Drawing.Size(215, 32)
        Me.ledY2Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY2Alarm_2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY2Alarm_2.TabIndex = 5
        '
        'ledY2Alarm_7
        '
        Me.ledY2Alarm_7.AutoSize = True
        Me.ledY2Alarm_7.BackColor = System.Drawing.Color.Transparent
        Me.ledY2Alarm_7.BlinkInterval = 500
        Me.ledY2Alarm_7.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY2Alarm_7.Label = "[Ax.02] IVL-Y2 위치운전 타임아웃"
        Me.ledY2Alarm_7.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY2Alarm_7.LedColor = System.Drawing.Color.Red
        Me.ledY2Alarm_7.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY2Alarm_7.Location = New System.Drawing.Point(11, 239)
        Me.ledY2Alarm_7.Name = "ledY2Alarm_7"
        Me.ledY2Alarm_7.Renderer = Nothing
        Me.ledY2Alarm_7.Size = New System.Drawing.Size(215, 32)
        Me.ledY2Alarm_7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY2Alarm_7.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY2Alarm_7.TabIndex = 3
        '
        'ledY2Alarm_6
        '
        Me.ledY2Alarm_6.AutoSize = True
        Me.ledY2Alarm_6.BackColor = System.Drawing.Color.Transparent
        Me.ledY2Alarm_6.BlinkInterval = 500
        Me.ledY2Alarm_6.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY2Alarm_6.Label = "[Ax.02] IVL-Y2 원점운전 타임아웃"
        Me.ledY2Alarm_6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY2Alarm_6.LedColor = System.Drawing.Color.Red
        Me.ledY2Alarm_6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY2Alarm_6.Location = New System.Drawing.Point(11, 207)
        Me.ledY2Alarm_6.Name = "ledY2Alarm_6"
        Me.ledY2Alarm_6.Renderer = Nothing
        Me.ledY2Alarm_6.Size = New System.Drawing.Size(215, 32)
        Me.ledY2Alarm_6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY2Alarm_6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY2Alarm_6.TabIndex = 2
        '
        'ledY2Alarm_1
        '
        Me.ledY2Alarm_1.AutoSize = True
        Me.ledY2Alarm_1.BackColor = System.Drawing.Color.Transparent
        Me.ledY2Alarm_1.BlinkInterval = 500
        Me.ledY2Alarm_1.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY2Alarm_1.Label = "[Ax.02] IVL-Y2 축 알람"
        Me.ledY2Alarm_1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY2Alarm_1.LedColor = System.Drawing.Color.Red
        Me.ledY2Alarm_1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY2Alarm_1.Location = New System.Drawing.Point(11, 48)
        Me.ledY2Alarm_1.Name = "ledY2Alarm_1"
        Me.ledY2Alarm_1.Renderer = Nothing
        Me.ledY2Alarm_1.Size = New System.Drawing.Size(215, 32)
        Me.ledY2Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY2Alarm_1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY2Alarm_1.TabIndex = 1
        '
        'ledY2Alarm_0
        '
        Me.ledY2Alarm_0.AutoSize = True
        Me.ledY2Alarm_0.BackColor = System.Drawing.Color.Transparent
        Me.ledY2Alarm_0.BlinkInterval = 500
        Me.ledY2Alarm_0.Label = "None"
        Me.ledY2Alarm_0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY2Alarm_0.LedColor = System.Drawing.Color.Red
        Me.ledY2Alarm_0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY2Alarm_0.Location = New System.Drawing.Point(11, 16)
        Me.ledY2Alarm_0.Name = "ledY2Alarm_0"
        Me.ledY2Alarm_0.Renderer = Nothing
        Me.ledY2Alarm_0.Size = New System.Drawing.Size(215, 32)
        Me.ledY2Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY2Alarm_0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY2Alarm_0.TabIndex = 0
        '
        'GroupBox34
        '
        Me.GroupBox34.Controls.Add(Me.ledZAlarm_9)
        Me.GroupBox34.Controls.Add(Me.ledZAlarm_8)
        Me.GroupBox34.Controls.Add(Me.ledZAlarm_5)
        Me.GroupBox34.Controls.Add(Me.ledZAlarm_4)
        Me.GroupBox34.Controls.Add(Me.ledZAlarm_3)
        Me.GroupBox34.Controls.Add(Me.ledZAlarm_2)
        Me.GroupBox34.Controls.Add(Me.ledZAlarm_7)
        Me.GroupBox34.Controls.Add(Me.ledZAlarm_6)
        Me.GroupBox34.Controls.Add(Me.ledZAlarm_1)
        Me.GroupBox34.Controls.Add(Me.ledZAlarm_0)
        Me.GroupBox34.Location = New System.Drawing.Point(719, 453)
        Me.GroupBox34.Name = "GroupBox34"
        Me.GroupBox34.Size = New System.Drawing.Size(232, 348)
        Me.GroupBox34.TabIndex = 63
        Me.GroupBox34.TabStop = False
        Me.GroupBox34.Text = "Z Axis Alarm(D9213)"
        '
        'ledZAlarm_9
        '
        Me.ledZAlarm_9.AutoSize = True
        Me.ledZAlarm_9.BackColor = System.Drawing.Color.Transparent
        Me.ledZAlarm_9.BlinkInterval = 500
        Me.ledZAlarm_9.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledZAlarm_9.Label = "[Ax.04] IVL-Z 과전류 알람"
        Me.ledZAlarm_9.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledZAlarm_9.LedColor = System.Drawing.Color.Red
        Me.ledZAlarm_9.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledZAlarm_9.Location = New System.Drawing.Point(11, 303)
        Me.ledZAlarm_9.Name = "ledZAlarm_9"
        Me.ledZAlarm_9.Renderer = Nothing
        Me.ledZAlarm_9.Size = New System.Drawing.Size(215, 32)
        Me.ledZAlarm_9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledZAlarm_9.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledZAlarm_9.TabIndex = 10
        '
        'ledZAlarm_8
        '
        Me.ledZAlarm_8.AutoSize = True
        Me.ledZAlarm_8.BackColor = System.Drawing.Color.Transparent
        Me.ledZAlarm_8.BlinkInterval = 500
        Me.ledZAlarm_8.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledZAlarm_8.Label = "[Ax.04] IVL-Z AMP 과온 알람"
        Me.ledZAlarm_8.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledZAlarm_8.LedColor = System.Drawing.Color.Red
        Me.ledZAlarm_8.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledZAlarm_8.Location = New System.Drawing.Point(11, 271)
        Me.ledZAlarm_8.Name = "ledZAlarm_8"
        Me.ledZAlarm_8.Renderer = Nothing
        Me.ledZAlarm_8.Size = New System.Drawing.Size(215, 32)
        Me.ledZAlarm_8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledZAlarm_8.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledZAlarm_8.TabIndex = 9
        '
        'ledZAlarm_5
        '
        Me.ledZAlarm_5.AutoSize = True
        Me.ledZAlarm_5.BackColor = System.Drawing.Color.Transparent
        Me.ledZAlarm_5.BlinkInterval = 500
        Me.ledZAlarm_5.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledZAlarm_5.Label = "[Ax.04] IVL-Z 충돌감지 알람"
        Me.ledZAlarm_5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledZAlarm_5.LedColor = System.Drawing.Color.Red
        Me.ledZAlarm_5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledZAlarm_5.Location = New System.Drawing.Point(11, 176)
        Me.ledZAlarm_5.Name = "ledZAlarm_5"
        Me.ledZAlarm_5.Renderer = Nothing
        Me.ledZAlarm_5.Size = New System.Drawing.Size(215, 32)
        Me.ledZAlarm_5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledZAlarm_5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledZAlarm_5.TabIndex = 8
        '
        'ledZAlarm_4
        '
        Me.ledZAlarm_4.AutoSize = True
        Me.ledZAlarm_4.BackColor = System.Drawing.Color.Transparent
        Me.ledZAlarm_4.BlinkInterval = 500
        Me.ledZAlarm_4.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledZAlarm_4.Label = "[Ax.04] IVL-Z FLS 리밋센서 알람"
        Me.ledZAlarm_4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledZAlarm_4.LedColor = System.Drawing.Color.Red
        Me.ledZAlarm_4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledZAlarm_4.Location = New System.Drawing.Point(11, 144)
        Me.ledZAlarm_4.Name = "ledZAlarm_4"
        Me.ledZAlarm_4.Renderer = Nothing
        Me.ledZAlarm_4.Size = New System.Drawing.Size(215, 32)
        Me.ledZAlarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledZAlarm_4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledZAlarm_4.TabIndex = 7
        '
        'ledZAlarm_3
        '
        Me.ledZAlarm_3.AutoSize = True
        Me.ledZAlarm_3.BackColor = System.Drawing.Color.Transparent
        Me.ledZAlarm_3.BlinkInterval = 500
        Me.ledZAlarm_3.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledZAlarm_3.Label = "[Ax.04] IVL-Z RLS 리밋센서 알람"
        Me.ledZAlarm_3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledZAlarm_3.LedColor = System.Drawing.Color.Red
        Me.ledZAlarm_3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledZAlarm_3.Location = New System.Drawing.Point(11, 112)
        Me.ledZAlarm_3.Name = "ledZAlarm_3"
        Me.ledZAlarm_3.Renderer = Nothing
        Me.ledZAlarm_3.Size = New System.Drawing.Size(215, 32)
        Me.ledZAlarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledZAlarm_3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledZAlarm_3.TabIndex = 6
        '
        'ledZAlarm_2
        '
        Me.ledZAlarm_2.AutoSize = True
        Me.ledZAlarm_2.BackColor = System.Drawing.Color.Transparent
        Me.ledZAlarm_2.BlinkInterval = 500
        Me.ledZAlarm_2.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledZAlarm_2.Label = "[Ax.04] IVL-Z 서보 알람"
        Me.ledZAlarm_2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledZAlarm_2.LedColor = System.Drawing.Color.Red
        Me.ledZAlarm_2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledZAlarm_2.Location = New System.Drawing.Point(11, 80)
        Me.ledZAlarm_2.Name = "ledZAlarm_2"
        Me.ledZAlarm_2.Renderer = Nothing
        Me.ledZAlarm_2.Size = New System.Drawing.Size(215, 32)
        Me.ledZAlarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledZAlarm_2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledZAlarm_2.TabIndex = 5
        '
        'ledZAlarm_7
        '
        Me.ledZAlarm_7.AutoSize = True
        Me.ledZAlarm_7.BackColor = System.Drawing.Color.Transparent
        Me.ledZAlarm_7.BlinkInterval = 500
        Me.ledZAlarm_7.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledZAlarm_7.Label = "[Ax.04] IVL-Z 위치운전 타임아웃"
        Me.ledZAlarm_7.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledZAlarm_7.LedColor = System.Drawing.Color.Red
        Me.ledZAlarm_7.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledZAlarm_7.Location = New System.Drawing.Point(11, 239)
        Me.ledZAlarm_7.Name = "ledZAlarm_7"
        Me.ledZAlarm_7.Renderer = Nothing
        Me.ledZAlarm_7.Size = New System.Drawing.Size(215, 32)
        Me.ledZAlarm_7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledZAlarm_7.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledZAlarm_7.TabIndex = 3
        '
        'ledZAlarm_6
        '
        Me.ledZAlarm_6.AutoSize = True
        Me.ledZAlarm_6.BackColor = System.Drawing.Color.Transparent
        Me.ledZAlarm_6.BlinkInterval = 500
        Me.ledZAlarm_6.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledZAlarm_6.Label = "[Ax.04] IVL-Z 원점운전 타임아웃"
        Me.ledZAlarm_6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledZAlarm_6.LedColor = System.Drawing.Color.Red
        Me.ledZAlarm_6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledZAlarm_6.Location = New System.Drawing.Point(11, 207)
        Me.ledZAlarm_6.Name = "ledZAlarm_6"
        Me.ledZAlarm_6.Renderer = Nothing
        Me.ledZAlarm_6.Size = New System.Drawing.Size(215, 32)
        Me.ledZAlarm_6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledZAlarm_6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledZAlarm_6.TabIndex = 2
        '
        'ledZAlarm_1
        '
        Me.ledZAlarm_1.AutoSize = True
        Me.ledZAlarm_1.BackColor = System.Drawing.Color.Transparent
        Me.ledZAlarm_1.BlinkInterval = 500
        Me.ledZAlarm_1.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledZAlarm_1.Label = "[Ax.04] IVL-Z 축 알람"
        Me.ledZAlarm_1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledZAlarm_1.LedColor = System.Drawing.Color.Red
        Me.ledZAlarm_1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledZAlarm_1.Location = New System.Drawing.Point(11, 48)
        Me.ledZAlarm_1.Name = "ledZAlarm_1"
        Me.ledZAlarm_1.Renderer = Nothing
        Me.ledZAlarm_1.Size = New System.Drawing.Size(215, 32)
        Me.ledZAlarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledZAlarm_1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledZAlarm_1.TabIndex = 1
        '
        'ledZAlarm_0
        '
        Me.ledZAlarm_0.AutoSize = True
        Me.ledZAlarm_0.BackColor = System.Drawing.Color.Transparent
        Me.ledZAlarm_0.BlinkInterval = 500
        Me.ledZAlarm_0.Label = "None"
        Me.ledZAlarm_0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledZAlarm_0.LedColor = System.Drawing.Color.Red
        Me.ledZAlarm_0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledZAlarm_0.Location = New System.Drawing.Point(11, 16)
        Me.ledZAlarm_0.Name = "ledZAlarm_0"
        Me.ledZAlarm_0.Renderer = Nothing
        Me.ledZAlarm_0.Size = New System.Drawing.Size(215, 32)
        Me.ledZAlarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledZAlarm_0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledZAlarm_0.TabIndex = 0
        '
        'GroupBox36
        '
        Me.GroupBox36.Controls.Add(Me.ledWeak2Alarm_0)
        Me.GroupBox36.Controls.Add(Me.ledWeak2Alarm_6)
        Me.GroupBox36.Controls.Add(Me.ledWeak2Alarm_5)
        Me.GroupBox36.Controls.Add(Me.ledWeak2Alarm_4)
        Me.GroupBox36.Controls.Add(Me.ledWeak2Alarm_3)
        Me.GroupBox36.Controls.Add(Me.ledWeak2Alarm_2)
        Me.GroupBox36.Controls.Add(Me.ledWeak2Alarm_1)
        Me.GroupBox36.Location = New System.Drawing.Point(10, 533)
        Me.GroupBox36.Name = "GroupBox36"
        Me.GroupBox36.Size = New System.Drawing.Size(232, 242)
        Me.GroupBox36.TabIndex = 67
        Me.GroupBox36.TabStop = False
        Me.GroupBox36.Text = "Weak2 Alarm(D9149)"
        '
        'ledWeak2Alarm_4
        '
        Me.ledWeak2Alarm_4.AutoSize = True
        Me.ledWeak2Alarm_4.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak2Alarm_4.BlinkInterval = 500
        Me.ledWeak2Alarm_4.Label = "쿨링 팬#16 알람 (X08F)"
        Me.ledWeak2Alarm_4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak2Alarm_4.LedColor = System.Drawing.Color.Red
        Me.ledWeak2Alarm_4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak2Alarm_4.Location = New System.Drawing.Point(11, 142)
        Me.ledWeak2Alarm_4.Name = "ledWeak2Alarm_4"
        Me.ledWeak2Alarm_4.Renderer = Nothing
        Me.ledWeak2Alarm_4.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak2Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak2Alarm_4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak2Alarm_4.TabIndex = 6
        '
        'ledWeak2Alarm_3
        '
        Me.ledWeak2Alarm_3.AutoSize = True
        Me.ledWeak2Alarm_3.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak2Alarm_3.BlinkInterval = 500
        Me.ledWeak2Alarm_3.Label = "쿨링 팬#15 알람 (X08E)"
        Me.ledWeak2Alarm_3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak2Alarm_3.LedColor = System.Drawing.Color.Red
        Me.ledWeak2Alarm_3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak2Alarm_3.Location = New System.Drawing.Point(11, 110)
        Me.ledWeak2Alarm_3.Name = "ledWeak2Alarm_3"
        Me.ledWeak2Alarm_3.Renderer = Nothing
        Me.ledWeak2Alarm_3.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak2Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak2Alarm_3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak2Alarm_3.TabIndex = 5
        '
        'ledWeak2Alarm_2
        '
        Me.ledWeak2Alarm_2.AutoSize = True
        Me.ledWeak2Alarm_2.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak2Alarm_2.BlinkInterval = 500
        Me.ledWeak2Alarm_2.Label = "쿨링 팬#14 알람 (X08D)"
        Me.ledWeak2Alarm_2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak2Alarm_2.LedColor = System.Drawing.Color.Red
        Me.ledWeak2Alarm_2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak2Alarm_2.Location = New System.Drawing.Point(11, 78)
        Me.ledWeak2Alarm_2.Name = "ledWeak2Alarm_2"
        Me.ledWeak2Alarm_2.Renderer = Nothing
        Me.ledWeak2Alarm_2.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak2Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak2Alarm_2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak2Alarm_2.TabIndex = 1
        '
        'ledWeak2Alarm_1
        '
        Me.ledWeak2Alarm_1.AutoSize = True
        Me.ledWeak2Alarm_1.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak2Alarm_1.BlinkInterval = 500
        Me.ledWeak2Alarm_1.Label = "쿨링 팬#13 알람 (X08C)"
        Me.ledWeak2Alarm_1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak2Alarm_1.LedColor = System.Drawing.Color.Red
        Me.ledWeak2Alarm_1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak2Alarm_1.Location = New System.Drawing.Point(11, 46)
        Me.ledWeak2Alarm_1.Name = "ledWeak2Alarm_1"
        Me.ledWeak2Alarm_1.Renderer = Nothing
        Me.ledWeak2Alarm_1.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak2Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak2Alarm_1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak2Alarm_1.TabIndex = 0
        '
        'ledWeak2Alarm_6
        '
        Me.ledWeak2Alarm_6.AutoSize = True
        Me.ledWeak2Alarm_6.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak2Alarm_6.BlinkInterval = 500
        Me.ledWeak2Alarm_6.Label = "쿨링 팬#18 알람 (X091)"
        Me.ledWeak2Alarm_6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak2Alarm_6.LedColor = System.Drawing.Color.Red
        Me.ledWeak2Alarm_6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak2Alarm_6.Location = New System.Drawing.Point(11, 206)
        Me.ledWeak2Alarm_6.Name = "ledWeak2Alarm_6"
        Me.ledWeak2Alarm_6.Renderer = Nothing
        Me.ledWeak2Alarm_6.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak2Alarm_6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak2Alarm_6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak2Alarm_6.TabIndex = 8
        '
        'ledWeak2Alarm_5
        '
        Me.ledWeak2Alarm_5.AutoSize = True
        Me.ledWeak2Alarm_5.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak2Alarm_5.BlinkInterval = 500
        Me.ledWeak2Alarm_5.Label = "쿨링 팬#17 알람 (X090)"
        Me.ledWeak2Alarm_5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak2Alarm_5.LedColor = System.Drawing.Color.Red
        Me.ledWeak2Alarm_5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak2Alarm_5.Location = New System.Drawing.Point(11, 174)
        Me.ledWeak2Alarm_5.Name = "ledWeak2Alarm_5"
        Me.ledWeak2Alarm_5.Renderer = Nothing
        Me.ledWeak2Alarm_5.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak2Alarm_5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak2Alarm_5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak2Alarm_5.TabIndex = 7
        '
        'GroupBox37
        '
        Me.GroupBox37.Controls.Add(Me.GroupBox26)
        Me.GroupBox37.Controls.Add(Me.GroupBox10)
        Me.GroupBox37.Controls.Add(Me.GroupBox34)
        Me.GroupBox37.Controls.Add(Me.GroupBox12)
        Me.GroupBox37.Controls.Add(Me.GroupBox33)
        Me.GroupBox37.Controls.Add(Me.GroupBox18)
        Me.GroupBox37.Controls.Add(Me.GroupBox32)
        Me.GroupBox37.Controls.Add(Me.GroupBox27)
        Me.GroupBox37.Controls.Add(Me.GroupBox31)
        Me.GroupBox37.Controls.Add(Me.GroupBox28)
        Me.GroupBox37.Controls.Add(Me.GroupBox30)
        Me.GroupBox37.Controls.Add(Me.GroupBox29)
        Me.GroupBox37.Location = New System.Drawing.Point(269, 10)
        Me.GroupBox37.Name = "GroupBox37"
        Me.GroupBox37.Size = New System.Drawing.Size(962, 805)
        Me.GroupBox37.TabIndex = 60
        Me.GroupBox37.TabStop = False
        Me.GroupBox37.Text = "Strang Alarm"
        '
        'ledWeak1Alarm_0
        '
        Me.ledWeak1Alarm_0.AutoSize = True
        Me.ledWeak1Alarm_0.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_0.BlinkInterval = 500
        Me.ledWeak1Alarm_0.Label = "None"
        Me.ledWeak1Alarm_0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_0.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_0.Location = New System.Drawing.Point(11, 16)
        Me.ledWeak1Alarm_0.Name = "ledWeak1Alarm_0"
        Me.ledWeak1Alarm_0.Renderer = Nothing
        Me.ledWeak1Alarm_0.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_0.TabIndex = 0
        '
        'ledWeak1Alarm_1
        '
        Me.ledWeak1Alarm_1.AutoSize = True
        Me.ledWeak1Alarm_1.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_1.BlinkInterval = 500
        Me.ledWeak1Alarm_1.Label = "쿨링 팬#1 알람 (X080)"
        Me.ledWeak1Alarm_1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_1.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_1.Location = New System.Drawing.Point(11, 48)
        Me.ledWeak1Alarm_1.Name = "ledWeak1Alarm_1"
        Me.ledWeak1Alarm_1.Renderer = Nothing
        Me.ledWeak1Alarm_1.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_1.TabIndex = 1
        '
        'ledWeak1Alarm_6
        '
        Me.ledWeak1Alarm_6.AutoSize = True
        Me.ledWeak1Alarm_6.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_6.BlinkInterval = 500
        Me.ledWeak1Alarm_6.Label = "쿨링 팬#6 알람 (X085)"
        Me.ledWeak1Alarm_6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_6.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_6.Location = New System.Drawing.Point(11, 207)
        Me.ledWeak1Alarm_6.Name = "ledWeak1Alarm_6"
        Me.ledWeak1Alarm_6.Renderer = Nothing
        Me.ledWeak1Alarm_6.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_6.TabIndex = 2
        '
        'ledWeak1Alarm_7
        '
        Me.ledWeak1Alarm_7.AutoSize = True
        Me.ledWeak1Alarm_7.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_7.BlinkInterval = 500
        Me.ledWeak1Alarm_7.Label = "쿨링 팬#7 알람 (X086)"
        Me.ledWeak1Alarm_7.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_7.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_7.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_7.Location = New System.Drawing.Point(11, 239)
        Me.ledWeak1Alarm_7.Name = "ledWeak1Alarm_7"
        Me.ledWeak1Alarm_7.Renderer = Nothing
        Me.ledWeak1Alarm_7.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_7.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_7.TabIndex = 3
        '
        'ledWeak1Alarm_2
        '
        Me.ledWeak1Alarm_2.AutoSize = True
        Me.ledWeak1Alarm_2.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_2.BlinkInterval = 500
        Me.ledWeak1Alarm_2.Label = "쿨링 팬#2 알람 (X081)"
        Me.ledWeak1Alarm_2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_2.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_2.Location = New System.Drawing.Point(11, 80)
        Me.ledWeak1Alarm_2.Name = "ledWeak1Alarm_2"
        Me.ledWeak1Alarm_2.Renderer = Nothing
        Me.ledWeak1Alarm_2.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_2.TabIndex = 5
        '
        'ledWeak1Alarm_3
        '
        Me.ledWeak1Alarm_3.AutoSize = True
        Me.ledWeak1Alarm_3.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_3.BlinkInterval = 500
        Me.ledWeak1Alarm_3.Label = "쿨링 팬#3 알람 (X082)"
        Me.ledWeak1Alarm_3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_3.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_3.Location = New System.Drawing.Point(11, 112)
        Me.ledWeak1Alarm_3.Name = "ledWeak1Alarm_3"
        Me.ledWeak1Alarm_3.Renderer = Nothing
        Me.ledWeak1Alarm_3.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_3.TabIndex = 6
        '
        'ledWeak1Alarm_4
        '
        Me.ledWeak1Alarm_4.AutoSize = True
        Me.ledWeak1Alarm_4.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_4.BlinkInterval = 500
        Me.ledWeak1Alarm_4.Label = "쿨링 팬#4 알람 (X083)"
        Me.ledWeak1Alarm_4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_4.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_4.Location = New System.Drawing.Point(11, 144)
        Me.ledWeak1Alarm_4.Name = "ledWeak1Alarm_4"
        Me.ledWeak1Alarm_4.Renderer = Nothing
        Me.ledWeak1Alarm_4.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_4.TabIndex = 7
        '
        'ledWeak1Alarm_5
        '
        Me.ledWeak1Alarm_5.AutoSize = True
        Me.ledWeak1Alarm_5.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_5.BlinkInterval = 500
        Me.ledWeak1Alarm_5.Label = "쿨링 팬#5 알람 (X084)"
        Me.ledWeak1Alarm_5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_5.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_5.Location = New System.Drawing.Point(11, 176)
        Me.ledWeak1Alarm_5.Name = "ledWeak1Alarm_5"
        Me.ledWeak1Alarm_5.Renderer = Nothing
        Me.ledWeak1Alarm_5.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_5.TabIndex = 8
        '
        'ledWeak1Alarm_8
        '
        Me.ledWeak1Alarm_8.AutoSize = True
        Me.ledWeak1Alarm_8.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_8.BlinkInterval = 500
        Me.ledWeak1Alarm_8.Label = "쿨링 팬#8 알람 (X087)"
        Me.ledWeak1Alarm_8.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_8.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_8.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_8.Location = New System.Drawing.Point(11, 271)
        Me.ledWeak1Alarm_8.Name = "ledWeak1Alarm_8"
        Me.ledWeak1Alarm_8.Renderer = Nothing
        Me.ledWeak1Alarm_8.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_8.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_8.TabIndex = 9
        '
        'ledWeak1Alarm_9
        '
        Me.ledWeak1Alarm_9.AutoSize = True
        Me.ledWeak1Alarm_9.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_9.BlinkInterval = 500
        Me.ledWeak1Alarm_9.Label = "쿨링 팬#9 알람 (X088)"
        Me.ledWeak1Alarm_9.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_9.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_9.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_9.Location = New System.Drawing.Point(11, 303)
        Me.ledWeak1Alarm_9.Name = "ledWeak1Alarm_9"
        Me.ledWeak1Alarm_9.Renderer = Nothing
        Me.ledWeak1Alarm_9.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_9.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_9.TabIndex = 10
        '
        'ledWeak1Alarm_10
        '
        Me.ledWeak1Alarm_10.AutoSize = True
        Me.ledWeak1Alarm_10.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_10.BlinkInterval = 500
        Me.ledWeak1Alarm_10.Label = "쿨링 팬#10 알람 (X089)"
        Me.ledWeak1Alarm_10.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_10.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_10.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_10.Location = New System.Drawing.Point(11, 335)
        Me.ledWeak1Alarm_10.Name = "ledWeak1Alarm_10"
        Me.ledWeak1Alarm_10.Renderer = Nothing
        Me.ledWeak1Alarm_10.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_10.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_10.TabIndex = 11
        '
        'ledWeak1Alarm_11
        '
        Me.ledWeak1Alarm_11.AutoSize = True
        Me.ledWeak1Alarm_11.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_11.BlinkInterval = 500
        Me.ledWeak1Alarm_11.Label = "쿨링 팬#11 알람 (X08A)"
        Me.ledWeak1Alarm_11.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_11.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_11.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_11.Location = New System.Drawing.Point(11, 367)
        Me.ledWeak1Alarm_11.Name = "ledWeak1Alarm_11"
        Me.ledWeak1Alarm_11.Renderer = Nothing
        Me.ledWeak1Alarm_11.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_11.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_11.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_11.TabIndex = 12
        '
        'ledWeak1Alarm_12
        '
        Me.ledWeak1Alarm_12.AutoSize = True
        Me.ledWeak1Alarm_12.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_12.BlinkInterval = 500
        Me.ledWeak1Alarm_12.Label = "쿨링 팬#12 알람 (X08B)"
        Me.ledWeak1Alarm_12.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_12.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_12.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_12.Location = New System.Drawing.Point(11, 399)
        Me.ledWeak1Alarm_12.Name = "ledWeak1Alarm_12"
        Me.ledWeak1Alarm_12.Renderer = Nothing
        Me.ledWeak1Alarm_12.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_12.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_12.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_12.TabIndex = 13
        '
        'ledWeak1Alarm_13
        '
        Me.ledWeak1Alarm_13.AutoSize = True
        Me.ledWeak1Alarm_13.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_13.BlinkInterval = 500
        Me.ledWeak1Alarm_13.Label = "온도 센서 알람 (도어오픈금지)"
        Me.ledWeak1Alarm_13.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_13.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_13.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_13.Location = New System.Drawing.Point(11, 431)
        Me.ledWeak1Alarm_13.Name = "ledWeak1Alarm_13"
        Me.ledWeak1Alarm_13.Renderer = Nothing
        Me.ledWeak1Alarm_13.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_13.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_13.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_13.TabIndex = 14
        '
        'ledWeak1Alarm_14
        '
        Me.ledWeak1Alarm_14.AutoSize = True
        Me.ledWeak1Alarm_14.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak1Alarm_14.BlinkInterval = 500
        Me.ledWeak1Alarm_14.Label = "컨트롤박스 내부 온도 알람 "
        Me.ledWeak1Alarm_14.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak1Alarm_14.LedColor = System.Drawing.Color.Red
        Me.ledWeak1Alarm_14.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak1Alarm_14.Location = New System.Drawing.Point(11, 463)
        Me.ledWeak1Alarm_14.Name = "ledWeak1Alarm_14"
        Me.ledWeak1Alarm_14.Renderer = Nothing
        Me.ledWeak1Alarm_14.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak1Alarm_14.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak1Alarm_14.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak1Alarm_14.TabIndex = 15
        '
        'GroupBox35
        '
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_14)
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_13)
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_12)
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_11)
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_10)
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_9)
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_8)
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_5)
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_4)
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_3)
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_2)
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_7)
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_6)
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_1)
        Me.GroupBox35.Controls.Add(Me.ledWeak1Alarm_0)
        Me.GroupBox35.Location = New System.Drawing.Point(10, 25)
        Me.GroupBox35.Name = "GroupBox35"
        Me.GroupBox35.Size = New System.Drawing.Size(232, 500)
        Me.GroupBox35.TabIndex = 63
        Me.GroupBox35.TabStop = False
        Me.GroupBox35.Text = "Weak1 Alarm(D9148)"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_SystemIDLE)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_SystemLoading)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_Processing)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_ManualMode)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_AutoMode)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_TeachingMode)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_PowerDown)
        Me.GroupBox9.Controls.Add(Me.ledSysStatus_PowerON)
        Me.GroupBox9.Location = New System.Drawing.Point(10, 20)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(210, 380)
        Me.GroupBox9.TabIndex = 1
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "System Status"
        '
        'ledSysStatus_PowerON
        '
        Me.ledSysStatus_PowerON.AutoSize = True
        Me.ledSysStatus_PowerON.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_PowerON.BlinkInterval = 500
        Me.ledSysStatus_PowerON.Label = "Power On"
        Me.ledSysStatus_PowerON.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_PowerON.LedColor = System.Drawing.Color.Lime
        Me.ledSysStatus_PowerON.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_PowerON.Location = New System.Drawing.Point(11, 20)
        Me.ledSysStatus_PowerON.Name = "ledSysStatus_PowerON"
        Me.ledSysStatus_PowerON.Renderer = Nothing
        Me.ledSysStatus_PowerON.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_PowerON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_PowerON.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_PowerON.TabIndex = 0
        '
        'ledSysStatus_PowerDown
        '
        Me.ledSysStatus_PowerDown.AutoSize = True
        Me.ledSysStatus_PowerDown.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_PowerDown.BlinkInterval = 500
        Me.ledSysStatus_PowerDown.Label = "Power Down"
        Me.ledSysStatus_PowerDown.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_PowerDown.LedColor = System.Drawing.Color.Red
        Me.ledSysStatus_PowerDown.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_PowerDown.Location = New System.Drawing.Point(11, 52)
        Me.ledSysStatus_PowerDown.Name = "ledSysStatus_PowerDown"
        Me.ledSysStatus_PowerDown.Renderer = Nothing
        Me.ledSysStatus_PowerDown.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_PowerDown.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_PowerDown.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_PowerDown.TabIndex = 1
        '
        'ledSysStatus_TeachingMode
        '
        Me.ledSysStatus_TeachingMode.AutoSize = True
        Me.ledSysStatus_TeachingMode.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_TeachingMode.BlinkInterval = 500
        Me.ledSysStatus_TeachingMode.Label = "Teaching Mode"
        Me.ledSysStatus_TeachingMode.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_TeachingMode.LedColor = System.Drawing.Color.Lime
        Me.ledSysStatus_TeachingMode.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_TeachingMode.Location = New System.Drawing.Point(11, 84)
        Me.ledSysStatus_TeachingMode.Name = "ledSysStatus_TeachingMode"
        Me.ledSysStatus_TeachingMode.Renderer = Nothing
        Me.ledSysStatus_TeachingMode.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_TeachingMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_TeachingMode.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_TeachingMode.TabIndex = 2
        '
        'ledSysStatus_AutoMode
        '
        Me.ledSysStatus_AutoMode.AutoSize = True
        Me.ledSysStatus_AutoMode.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_AutoMode.BlinkInterval = 500
        Me.ledSysStatus_AutoMode.Label = "Auto Mode"
        Me.ledSysStatus_AutoMode.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_AutoMode.LedColor = System.Drawing.Color.DarkOrange
        Me.ledSysStatus_AutoMode.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_AutoMode.Location = New System.Drawing.Point(11, 116)
        Me.ledSysStatus_AutoMode.Name = "ledSysStatus_AutoMode"
        Me.ledSysStatus_AutoMode.Renderer = Nothing
        Me.ledSysStatus_AutoMode.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_AutoMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_AutoMode.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_AutoMode.TabIndex = 3
        '
        'ledSysStatus_ManualMode
        '
        Me.ledSysStatus_ManualMode.AutoSize = True
        Me.ledSysStatus_ManualMode.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_ManualMode.BlinkInterval = 500
        Me.ledSysStatus_ManualMode.Label = "Manual Mode"
        Me.ledSysStatus_ManualMode.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_ManualMode.LedColor = System.Drawing.Color.Red
        Me.ledSysStatus_ManualMode.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_ManualMode.Location = New System.Drawing.Point(11, 148)
        Me.ledSysStatus_ManualMode.Name = "ledSysStatus_ManualMode"
        Me.ledSysStatus_ManualMode.Renderer = Nothing
        Me.ledSysStatus_ManualMode.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_ManualMode.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_ManualMode.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_ManualMode.TabIndex = 4
        '
        'ledSysStatus_Processing
        '
        Me.ledSysStatus_Processing.AutoSize = True
        Me.ledSysStatus_Processing.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_Processing.BlinkInterval = 500
        Me.ledSysStatus_Processing.Label = "Processing"
        Me.ledSysStatus_Processing.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_Processing.LedColor = System.Drawing.Color.Blue
        Me.ledSysStatus_Processing.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_Processing.Location = New System.Drawing.Point(11, 180)
        Me.ledSysStatus_Processing.Name = "ledSysStatus_Processing"
        Me.ledSysStatus_Processing.Renderer = Nothing
        Me.ledSysStatus_Processing.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_Processing.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_Processing.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_Processing.TabIndex = 5
        '
        'ledSysStatus_SystemLoading
        '
        Me.ledSysStatus_SystemLoading.AutoSize = True
        Me.ledSysStatus_SystemLoading.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_SystemLoading.BlinkInterval = 500
        Me.ledSysStatus_SystemLoading.Label = "Loading"
        Me.ledSysStatus_SystemLoading.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_SystemLoading.LedColor = System.Drawing.Color.Blue
        Me.ledSysStatus_SystemLoading.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_SystemLoading.Location = New System.Drawing.Point(11, 212)
        Me.ledSysStatus_SystemLoading.Name = "ledSysStatus_SystemLoading"
        Me.ledSysStatus_SystemLoading.Renderer = Nothing
        Me.ledSysStatus_SystemLoading.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ledSysStatus_SystemLoading.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_SystemLoading.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_SystemLoading.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_SystemLoading.TabIndex = 6
        '
        'ledSysStatus_SystemIDLE
        '
        Me.ledSysStatus_SystemIDLE.AutoSize = True
        Me.ledSysStatus_SystemIDLE.BackColor = System.Drawing.Color.Transparent
        Me.ledSysStatus_SystemIDLE.BlinkInterval = 500
        Me.ledSysStatus_SystemIDLE.Label = "IDLE"
        Me.ledSysStatus_SystemIDLE.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSysStatus_SystemIDLE.LedColor = System.Drawing.Color.Blue
        Me.ledSysStatus_SystemIDLE.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledSysStatus_SystemIDLE.Location = New System.Drawing.Point(11, 244)
        Me.ledSysStatus_SystemIDLE.Name = "ledSysStatus_SystemIDLE"
        Me.ledSysStatus_SystemIDLE.Renderer = Nothing
        Me.ledSysStatus_SystemIDLE.Size = New System.Drawing.Size(191, 32)
        Me.ledSysStatus_SystemIDLE.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSysStatus_SystemIDLE.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSysStatus_SystemIDLE.TabIndex = 7
        '
        'GroupBox19
        '
        Me.GroupBox19.Controls.Add(Me.ledSupplyNone)
        Me.GroupBox19.Controls.Add(Me.ledSupplySLOT10)
        Me.GroupBox19.Controls.Add(Me.ledSupplySLOT9)
        Me.GroupBox19.Controls.Add(Me.ledSupplySLOT8)
        Me.GroupBox19.Controls.Add(Me.ledSupplySLOT7)
        Me.GroupBox19.Controls.Add(Me.ledSupplySLOT6)
        Me.GroupBox19.Controls.Add(Me.ledSupplySLOT5)
        Me.GroupBox19.Controls.Add(Me.ledSupplySLOT4)
        Me.GroupBox19.Controls.Add(Me.ledSupplySLOT3)
        Me.GroupBox19.Controls.Add(Me.ledSupplySLOT2)
        Me.GroupBox19.Controls.Add(Me.ledSupplySLOT1)
        Me.GroupBox19.Controls.Add(Me.ledSupplySLOT0)
        Me.GroupBox19.Location = New System.Drawing.Point(13, 406)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(128, 430)
        Me.GroupBox19.TabIndex = 46
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "Supply Slot Status"
        Me.GroupBox19.Visible = False
        '
        'ledSupplySLOT0
        '
        Me.ledSupplySLOT0.AutoSize = True
        Me.ledSupplySLOT0.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySLOT0.BlinkInterval = 500
        Me.ledSupplySLOT0.Label = "C/V SLOT - 0"
        Me.ledSupplySLOT0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySLOT0.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySLOT0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySLOT0.Location = New System.Drawing.Point(11, 57)
        Me.ledSupplySLOT0.Name = "ledSupplySLOT0"
        Me.ledSupplySLOT0.Renderer = Nothing
        Me.ledSupplySLOT0.Size = New System.Drawing.Size(111, 32)
        Me.ledSupplySLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySLOT0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySLOT0.TabIndex = 0
        '
        'ledSupplySLOT1
        '
        Me.ledSupplySLOT1.AutoSize = True
        Me.ledSupplySLOT1.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySLOT1.BlinkInterval = 500
        Me.ledSupplySLOT1.Label = "SLOT-1"
        Me.ledSupplySLOT1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySLOT1.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySLOT1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySLOT1.Location = New System.Drawing.Point(11, 89)
        Me.ledSupplySLOT1.Name = "ledSupplySLOT1"
        Me.ledSupplySLOT1.Renderer = Nothing
        Me.ledSupplySLOT1.Size = New System.Drawing.Size(111, 32)
        Me.ledSupplySLOT1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySLOT1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySLOT1.TabIndex = 1
        '
        'ledSupplySLOT2
        '
        Me.ledSupplySLOT2.AutoSize = True
        Me.ledSupplySLOT2.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySLOT2.BlinkInterval = 500
        Me.ledSupplySLOT2.Label = "SLOT-2"
        Me.ledSupplySLOT2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySLOT2.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySLOT2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySLOT2.Location = New System.Drawing.Point(11, 121)
        Me.ledSupplySLOT2.Name = "ledSupplySLOT2"
        Me.ledSupplySLOT2.Renderer = Nothing
        Me.ledSupplySLOT2.Size = New System.Drawing.Size(111, 32)
        Me.ledSupplySLOT2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySLOT2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySLOT2.TabIndex = 2
        '
        'ledSupplySLOT3
        '
        Me.ledSupplySLOT3.AutoSize = True
        Me.ledSupplySLOT3.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySLOT3.BlinkInterval = 500
        Me.ledSupplySLOT3.Label = "SLOT-3"
        Me.ledSupplySLOT3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySLOT3.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySLOT3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySLOT3.Location = New System.Drawing.Point(11, 153)
        Me.ledSupplySLOT3.Name = "ledSupplySLOT3"
        Me.ledSupplySLOT3.Renderer = Nothing
        Me.ledSupplySLOT3.Size = New System.Drawing.Size(111, 32)
        Me.ledSupplySLOT3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySLOT3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySLOT3.TabIndex = 3
        '
        'ledSupplySLOT4
        '
        Me.ledSupplySLOT4.AutoSize = True
        Me.ledSupplySLOT4.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySLOT4.BlinkInterval = 500
        Me.ledSupplySLOT4.Label = "SLOT-4"
        Me.ledSupplySLOT4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySLOT4.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySLOT4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySLOT4.Location = New System.Drawing.Point(11, 185)
        Me.ledSupplySLOT4.Name = "ledSupplySLOT4"
        Me.ledSupplySLOT4.Renderer = Nothing
        Me.ledSupplySLOT4.Size = New System.Drawing.Size(111, 32)
        Me.ledSupplySLOT4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySLOT4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySLOT4.TabIndex = 4
        '
        'ledSupplySLOT5
        '
        Me.ledSupplySLOT5.AutoSize = True
        Me.ledSupplySLOT5.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySLOT5.BlinkInterval = 500
        Me.ledSupplySLOT5.Label = "SLOT-5"
        Me.ledSupplySLOT5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySLOT5.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySLOT5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySLOT5.Location = New System.Drawing.Point(11, 217)
        Me.ledSupplySLOT5.Name = "ledSupplySLOT5"
        Me.ledSupplySLOT5.Renderer = Nothing
        Me.ledSupplySLOT5.Size = New System.Drawing.Size(111, 32)
        Me.ledSupplySLOT5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySLOT5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySLOT5.TabIndex = 5
        '
        'ledSupplySLOT6
        '
        Me.ledSupplySLOT6.AutoSize = True
        Me.ledSupplySLOT6.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySLOT6.BlinkInterval = 500
        Me.ledSupplySLOT6.Label = "SLOT-6"
        Me.ledSupplySLOT6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySLOT6.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySLOT6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySLOT6.Location = New System.Drawing.Point(11, 249)
        Me.ledSupplySLOT6.Name = "ledSupplySLOT6"
        Me.ledSupplySLOT6.Renderer = Nothing
        Me.ledSupplySLOT6.Size = New System.Drawing.Size(111, 32)
        Me.ledSupplySLOT6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySLOT6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySLOT6.TabIndex = 6
        '
        'ledSupplySLOT7
        '
        Me.ledSupplySLOT7.AutoSize = True
        Me.ledSupplySLOT7.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySLOT7.BlinkInterval = 500
        Me.ledSupplySLOT7.Label = "SLOT-7"
        Me.ledSupplySLOT7.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySLOT7.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySLOT7.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySLOT7.Location = New System.Drawing.Point(11, 281)
        Me.ledSupplySLOT7.Name = "ledSupplySLOT7"
        Me.ledSupplySLOT7.Renderer = Nothing
        Me.ledSupplySLOT7.Size = New System.Drawing.Size(111, 32)
        Me.ledSupplySLOT7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySLOT7.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySLOT7.TabIndex = 7
        '
        'ledSupplySLOT8
        '
        Me.ledSupplySLOT8.AutoSize = True
        Me.ledSupplySLOT8.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySLOT8.BlinkInterval = 500
        Me.ledSupplySLOT8.Label = "SLOT-8"
        Me.ledSupplySLOT8.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySLOT8.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySLOT8.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySLOT8.Location = New System.Drawing.Point(11, 313)
        Me.ledSupplySLOT8.Name = "ledSupplySLOT8"
        Me.ledSupplySLOT8.Renderer = Nothing
        Me.ledSupplySLOT8.Size = New System.Drawing.Size(111, 32)
        Me.ledSupplySLOT8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySLOT8.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySLOT8.TabIndex = 8
        '
        'ledSupplySLOT9
        '
        Me.ledSupplySLOT9.AutoSize = True
        Me.ledSupplySLOT9.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySLOT9.BlinkInterval = 500
        Me.ledSupplySLOT9.Label = "SLOT-9"
        Me.ledSupplySLOT9.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySLOT9.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySLOT9.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySLOT9.Location = New System.Drawing.Point(11, 345)
        Me.ledSupplySLOT9.Name = "ledSupplySLOT9"
        Me.ledSupplySLOT9.Renderer = Nothing
        Me.ledSupplySLOT9.Size = New System.Drawing.Size(111, 32)
        Me.ledSupplySLOT9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySLOT9.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySLOT9.TabIndex = 9
        '
        'ledSupplySLOT10
        '
        Me.ledSupplySLOT10.AutoSize = True
        Me.ledSupplySLOT10.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySLOT10.BlinkInterval = 500
        Me.ledSupplySLOT10.Label = "SLOT-10"
        Me.ledSupplySLOT10.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySLOT10.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySLOT10.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySLOT10.Location = New System.Drawing.Point(11, 377)
        Me.ledSupplySLOT10.Name = "ledSupplySLOT10"
        Me.ledSupplySLOT10.Renderer = Nothing
        Me.ledSupplySLOT10.Size = New System.Drawing.Size(111, 32)
        Me.ledSupplySLOT10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySLOT10.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySLOT10.TabIndex = 11
        '
        'ledSupplyNone
        '
        Me.ledSupplyNone.AutoSize = True
        Me.ledSupplyNone.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplyNone.BlinkInterval = 500
        Me.ledSupplyNone.Label = "None"
        Me.ledSupplyNone.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplyNone.LedColor = System.Drawing.Color.Lime
        Me.ledSupplyNone.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplyNone.Location = New System.Drawing.Point(11, 25)
        Me.ledSupplyNone.Name = "ledSupplyNone"
        Me.ledSupplyNone.Renderer = Nothing
        Me.ledSupplyNone.Size = New System.Drawing.Size(111, 32)
        Me.ledSupplyNone.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplyNone.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplyNone.TabIndex = 12
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.ledMagazineErrorStatus_Reserved07)
        Me.GroupBox17.Controls.Add(Me.ledMagazineErrorStatus_Reserved06)
        Me.GroupBox17.Controls.Add(Me.ledMagazineErrorStatus_Reserved05)
        Me.GroupBox17.Controls.Add(Me.ledMagazineErrorStatus_Reserved04)
        Me.GroupBox17.Controls.Add(Me.ledMagazineErrorStatus_Reserved03)
        Me.GroupBox17.Controls.Add(Me.ledMagazineErrorStatus_Reserved02)
        Me.GroupBox17.Controls.Add(Me.ledMagazineErrorStatus_Reserved01)
        Me.GroupBox17.Controls.Add(Me.ledMagazineErrorStatus_Down)
        Me.GroupBox17.Location = New System.Drawing.Point(1210, 20)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(115, 284)
        Me.GroupBox17.TabIndex = 47
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "Magazine Error Status"
        '
        'ledMagazineErrorStatus_Down
        '
        Me.ledMagazineErrorStatus_Down.AutoSize = True
        Me.ledMagazineErrorStatus_Down.BackColor = System.Drawing.Color.Transparent
        Me.ledMagazineErrorStatus_Down.BlinkInterval = 500
        Me.ledMagazineErrorStatus_Down.Label = "NoError"
        Me.ledMagazineErrorStatus_Down.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledMagazineErrorStatus_Down.LedColor = System.Drawing.Color.Red
        Me.ledMagazineErrorStatus_Down.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledMagazineErrorStatus_Down.Location = New System.Drawing.Point(11, 20)
        Me.ledMagazineErrorStatus_Down.Name = "ledMagazineErrorStatus_Down"
        Me.ledMagazineErrorStatus_Down.Renderer = Nothing
        Me.ledMagazineErrorStatus_Down.Size = New System.Drawing.Size(130, 32)
        Me.ledMagazineErrorStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledMagazineErrorStatus_Down.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledMagazineErrorStatus_Down.TabIndex = 0
        '
        'ledMagazineErrorStatus_Reserved01
        '
        Me.ledMagazineErrorStatus_Reserved01.AutoSize = True
        Me.ledMagazineErrorStatus_Reserved01.BackColor = System.Drawing.Color.Transparent
        Me.ledMagazineErrorStatus_Reserved01.BlinkInterval = 500
        Me.ledMagazineErrorStatus_Reserved01.Label = "Reserved01"
        Me.ledMagazineErrorStatus_Reserved01.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledMagazineErrorStatus_Reserved01.LedColor = System.Drawing.Color.Red
        Me.ledMagazineErrorStatus_Reserved01.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledMagazineErrorStatus_Reserved01.Location = New System.Drawing.Point(11, 52)
        Me.ledMagazineErrorStatus_Reserved01.Name = "ledMagazineErrorStatus_Reserved01"
        Me.ledMagazineErrorStatus_Reserved01.Renderer = Nothing
        Me.ledMagazineErrorStatus_Reserved01.Size = New System.Drawing.Size(130, 32)
        Me.ledMagazineErrorStatus_Reserved01.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledMagazineErrorStatus_Reserved01.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledMagazineErrorStatus_Reserved01.TabIndex = 3
        '
        'ledMagazineErrorStatus_Reserved02
        '
        Me.ledMagazineErrorStatus_Reserved02.AutoSize = True
        Me.ledMagazineErrorStatus_Reserved02.BackColor = System.Drawing.Color.Transparent
        Me.ledMagazineErrorStatus_Reserved02.BlinkInterval = 500
        Me.ledMagazineErrorStatus_Reserved02.Label = "Reserved02"
        Me.ledMagazineErrorStatus_Reserved02.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledMagazineErrorStatus_Reserved02.LedColor = System.Drawing.Color.Red
        Me.ledMagazineErrorStatus_Reserved02.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledMagazineErrorStatus_Reserved02.Location = New System.Drawing.Point(11, 84)
        Me.ledMagazineErrorStatus_Reserved02.Name = "ledMagazineErrorStatus_Reserved02"
        Me.ledMagazineErrorStatus_Reserved02.Renderer = Nothing
        Me.ledMagazineErrorStatus_Reserved02.Size = New System.Drawing.Size(130, 32)
        Me.ledMagazineErrorStatus_Reserved02.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledMagazineErrorStatus_Reserved02.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledMagazineErrorStatus_Reserved02.TabIndex = 4
        '
        'ledMagazineErrorStatus_Reserved03
        '
        Me.ledMagazineErrorStatus_Reserved03.AutoSize = True
        Me.ledMagazineErrorStatus_Reserved03.BackColor = System.Drawing.Color.Transparent
        Me.ledMagazineErrorStatus_Reserved03.BlinkInterval = 500
        Me.ledMagazineErrorStatus_Reserved03.Label = "Reserved03"
        Me.ledMagazineErrorStatus_Reserved03.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledMagazineErrorStatus_Reserved03.LedColor = System.Drawing.Color.Red
        Me.ledMagazineErrorStatus_Reserved03.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledMagazineErrorStatus_Reserved03.Location = New System.Drawing.Point(11, 116)
        Me.ledMagazineErrorStatus_Reserved03.Name = "ledMagazineErrorStatus_Reserved03"
        Me.ledMagazineErrorStatus_Reserved03.Renderer = Nothing
        Me.ledMagazineErrorStatus_Reserved03.Size = New System.Drawing.Size(130, 32)
        Me.ledMagazineErrorStatus_Reserved03.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledMagazineErrorStatus_Reserved03.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledMagazineErrorStatus_Reserved03.TabIndex = 5
        '
        'ledMagazineErrorStatus_Reserved04
        '
        Me.ledMagazineErrorStatus_Reserved04.AutoSize = True
        Me.ledMagazineErrorStatus_Reserved04.BackColor = System.Drawing.Color.Transparent
        Me.ledMagazineErrorStatus_Reserved04.BlinkInterval = 500
        Me.ledMagazineErrorStatus_Reserved04.Label = "Reserved04"
        Me.ledMagazineErrorStatus_Reserved04.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledMagazineErrorStatus_Reserved04.LedColor = System.Drawing.Color.Red
        Me.ledMagazineErrorStatus_Reserved04.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledMagazineErrorStatus_Reserved04.Location = New System.Drawing.Point(11, 148)
        Me.ledMagazineErrorStatus_Reserved04.Name = "ledMagazineErrorStatus_Reserved04"
        Me.ledMagazineErrorStatus_Reserved04.Renderer = Nothing
        Me.ledMagazineErrorStatus_Reserved04.Size = New System.Drawing.Size(130, 32)
        Me.ledMagazineErrorStatus_Reserved04.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledMagazineErrorStatus_Reserved04.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledMagazineErrorStatus_Reserved04.TabIndex = 6
        '
        'ledMagazineErrorStatus_Reserved05
        '
        Me.ledMagazineErrorStatus_Reserved05.AutoSize = True
        Me.ledMagazineErrorStatus_Reserved05.BackColor = System.Drawing.Color.Transparent
        Me.ledMagazineErrorStatus_Reserved05.BlinkInterval = 500
        Me.ledMagazineErrorStatus_Reserved05.Label = "Reserved05"
        Me.ledMagazineErrorStatus_Reserved05.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledMagazineErrorStatus_Reserved05.LedColor = System.Drawing.Color.Red
        Me.ledMagazineErrorStatus_Reserved05.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledMagazineErrorStatus_Reserved05.Location = New System.Drawing.Point(11, 180)
        Me.ledMagazineErrorStatus_Reserved05.Name = "ledMagazineErrorStatus_Reserved05"
        Me.ledMagazineErrorStatus_Reserved05.Renderer = Nothing
        Me.ledMagazineErrorStatus_Reserved05.Size = New System.Drawing.Size(130, 32)
        Me.ledMagazineErrorStatus_Reserved05.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledMagazineErrorStatus_Reserved05.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledMagazineErrorStatus_Reserved05.TabIndex = 7
        '
        'ledMagazineErrorStatus_Reserved06
        '
        Me.ledMagazineErrorStatus_Reserved06.AutoSize = True
        Me.ledMagazineErrorStatus_Reserved06.BackColor = System.Drawing.Color.Transparent
        Me.ledMagazineErrorStatus_Reserved06.BlinkInterval = 500
        Me.ledMagazineErrorStatus_Reserved06.Label = "Reserved06"
        Me.ledMagazineErrorStatus_Reserved06.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledMagazineErrorStatus_Reserved06.LedColor = System.Drawing.Color.Red
        Me.ledMagazineErrorStatus_Reserved06.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledMagazineErrorStatus_Reserved06.Location = New System.Drawing.Point(11, 212)
        Me.ledMagazineErrorStatus_Reserved06.Name = "ledMagazineErrorStatus_Reserved06"
        Me.ledMagazineErrorStatus_Reserved06.Renderer = Nothing
        Me.ledMagazineErrorStatus_Reserved06.Size = New System.Drawing.Size(130, 32)
        Me.ledMagazineErrorStatus_Reserved06.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledMagazineErrorStatus_Reserved06.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledMagazineErrorStatus_Reserved06.TabIndex = 8
        '
        'ledMagazineErrorStatus_Reserved07
        '
        Me.ledMagazineErrorStatus_Reserved07.AutoSize = True
        Me.ledMagazineErrorStatus_Reserved07.BackColor = System.Drawing.Color.Transparent
        Me.ledMagazineErrorStatus_Reserved07.BlinkInterval = 500
        Me.ledMagazineErrorStatus_Reserved07.Label = "Reserved07"
        Me.ledMagazineErrorStatus_Reserved07.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledMagazineErrorStatus_Reserved07.LedColor = System.Drawing.Color.Red
        Me.ledMagazineErrorStatus_Reserved07.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledMagazineErrorStatus_Reserved07.Location = New System.Drawing.Point(11, 244)
        Me.ledMagazineErrorStatus_Reserved07.Name = "ledMagazineErrorStatus_Reserved07"
        Me.ledMagazineErrorStatus_Reserved07.Renderer = Nothing
        Me.ledMagazineErrorStatus_Reserved07.Size = New System.Drawing.Size(130, 32)
        Me.ledMagazineErrorStatus_Reserved07.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledMagazineErrorStatus_Reserved07.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledMagazineErrorStatus_Reserved07.TabIndex = 15
        '
        'GroupBox20
        '
        Me.GroupBox20.Controls.Add(Me.ledExhausNone)
        Me.GroupBox20.Controls.Add(Me.ledExhausSLOT10)
        Me.GroupBox20.Controls.Add(Me.ledExhausSLOT9)
        Me.GroupBox20.Controls.Add(Me.ledExhausSLOT8)
        Me.GroupBox20.Controls.Add(Me.ledExhausSLOT7)
        Me.GroupBox20.Controls.Add(Me.ledExhausSLOT6)
        Me.GroupBox20.Controls.Add(Me.ledExhausSLOT5)
        Me.GroupBox20.Controls.Add(Me.ledExhausSLOT4)
        Me.GroupBox20.Controls.Add(Me.ledExhausSLOT3)
        Me.GroupBox20.Controls.Add(Me.ledExhausSLOT2)
        Me.GroupBox20.Controls.Add(Me.ledExhausSLOT1)
        Me.GroupBox20.Controls.Add(Me.ledExhausSLOT0)
        Me.GroupBox20.Location = New System.Drawing.Point(147, 406)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(132, 432)
        Me.GroupBox20.TabIndex = 48
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Exhaus Slot Status"
        Me.GroupBox20.Visible = False
        '
        'ledExhausSLOT0
        '
        Me.ledExhausSLOT0.AutoSize = True
        Me.ledExhausSLOT0.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSLOT0.BlinkInterval = 500
        Me.ledExhausSLOT0.Label = "CV/ SLOT - 0"
        Me.ledExhausSLOT0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSLOT0.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSLOT0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSLOT0.Location = New System.Drawing.Point(6, 59)
        Me.ledExhausSLOT0.Name = "ledExhausSLOT0"
        Me.ledExhausSLOT0.Renderer = Nothing
        Me.ledExhausSLOT0.Size = New System.Drawing.Size(115, 32)
        Me.ledExhausSLOT0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSLOT0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSLOT0.TabIndex = 0
        '
        'ledExhausSLOT1
        '
        Me.ledExhausSLOT1.AutoSize = True
        Me.ledExhausSLOT1.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSLOT1.BlinkInterval = 500
        Me.ledExhausSLOT1.Label = "SLOT-1"
        Me.ledExhausSLOT1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSLOT1.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSLOT1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSLOT1.Location = New System.Drawing.Point(6, 91)
        Me.ledExhausSLOT1.Name = "ledExhausSLOT1"
        Me.ledExhausSLOT1.Renderer = Nothing
        Me.ledExhausSLOT1.Size = New System.Drawing.Size(115, 32)
        Me.ledExhausSLOT1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSLOT1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSLOT1.TabIndex = 1
        '
        'ledExhausSLOT2
        '
        Me.ledExhausSLOT2.AutoSize = True
        Me.ledExhausSLOT2.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSLOT2.BlinkInterval = 500
        Me.ledExhausSLOT2.Label = "SLOT-2"
        Me.ledExhausSLOT2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSLOT2.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSLOT2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSLOT2.Location = New System.Drawing.Point(6, 123)
        Me.ledExhausSLOT2.Name = "ledExhausSLOT2"
        Me.ledExhausSLOT2.Renderer = Nothing
        Me.ledExhausSLOT2.Size = New System.Drawing.Size(115, 32)
        Me.ledExhausSLOT2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSLOT2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSLOT2.TabIndex = 2
        '
        'ledExhausSLOT3
        '
        Me.ledExhausSLOT3.AutoSize = True
        Me.ledExhausSLOT3.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSLOT3.BlinkInterval = 500
        Me.ledExhausSLOT3.Label = "SLOT-3"
        Me.ledExhausSLOT3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSLOT3.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSLOT3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSLOT3.Location = New System.Drawing.Point(6, 155)
        Me.ledExhausSLOT3.Name = "ledExhausSLOT3"
        Me.ledExhausSLOT3.Renderer = Nothing
        Me.ledExhausSLOT3.Size = New System.Drawing.Size(115, 32)
        Me.ledExhausSLOT3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSLOT3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSLOT3.TabIndex = 3
        '
        'ledExhausSLOT4
        '
        Me.ledExhausSLOT4.AutoSize = True
        Me.ledExhausSLOT4.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSLOT4.BlinkInterval = 500
        Me.ledExhausSLOT4.Label = "SLOT-4"
        Me.ledExhausSLOT4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSLOT4.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSLOT4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSLOT4.Location = New System.Drawing.Point(6, 187)
        Me.ledExhausSLOT4.Name = "ledExhausSLOT4"
        Me.ledExhausSLOT4.Renderer = Nothing
        Me.ledExhausSLOT4.Size = New System.Drawing.Size(115, 32)
        Me.ledExhausSLOT4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSLOT4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSLOT4.TabIndex = 4
        '
        'ledExhausSLOT5
        '
        Me.ledExhausSLOT5.AutoSize = True
        Me.ledExhausSLOT5.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSLOT5.BlinkInterval = 500
        Me.ledExhausSLOT5.Label = "SLOT-5"
        Me.ledExhausSLOT5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSLOT5.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSLOT5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSLOT5.Location = New System.Drawing.Point(6, 219)
        Me.ledExhausSLOT5.Name = "ledExhausSLOT5"
        Me.ledExhausSLOT5.Renderer = Nothing
        Me.ledExhausSLOT5.Size = New System.Drawing.Size(115, 32)
        Me.ledExhausSLOT5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSLOT5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSLOT5.TabIndex = 5
        '
        'ledExhausSLOT6
        '
        Me.ledExhausSLOT6.AutoSize = True
        Me.ledExhausSLOT6.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSLOT6.BlinkInterval = 500
        Me.ledExhausSLOT6.Label = "SLOT-6"
        Me.ledExhausSLOT6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSLOT6.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSLOT6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSLOT6.Location = New System.Drawing.Point(6, 251)
        Me.ledExhausSLOT6.Name = "ledExhausSLOT6"
        Me.ledExhausSLOT6.Renderer = Nothing
        Me.ledExhausSLOT6.Size = New System.Drawing.Size(115, 32)
        Me.ledExhausSLOT6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSLOT6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSLOT6.TabIndex = 6
        '
        'ledExhausSLOT7
        '
        Me.ledExhausSLOT7.AutoSize = True
        Me.ledExhausSLOT7.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSLOT7.BlinkInterval = 500
        Me.ledExhausSLOT7.Label = "SLOT-7"
        Me.ledExhausSLOT7.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSLOT7.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSLOT7.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSLOT7.Location = New System.Drawing.Point(6, 283)
        Me.ledExhausSLOT7.Name = "ledExhausSLOT7"
        Me.ledExhausSLOT7.Renderer = Nothing
        Me.ledExhausSLOT7.Size = New System.Drawing.Size(115, 32)
        Me.ledExhausSLOT7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSLOT7.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSLOT7.TabIndex = 7
        '
        'ledExhausSLOT8
        '
        Me.ledExhausSLOT8.AutoSize = True
        Me.ledExhausSLOT8.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSLOT8.BlinkInterval = 500
        Me.ledExhausSLOT8.Label = "SLOT-8"
        Me.ledExhausSLOT8.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSLOT8.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSLOT8.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSLOT8.Location = New System.Drawing.Point(6, 315)
        Me.ledExhausSLOT8.Name = "ledExhausSLOT8"
        Me.ledExhausSLOT8.Renderer = Nothing
        Me.ledExhausSLOT8.Size = New System.Drawing.Size(115, 32)
        Me.ledExhausSLOT8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSLOT8.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSLOT8.TabIndex = 8
        '
        'ledExhausSLOT9
        '
        Me.ledExhausSLOT9.AutoSize = True
        Me.ledExhausSLOT9.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSLOT9.BlinkInterval = 500
        Me.ledExhausSLOT9.Label = "SLOT-9"
        Me.ledExhausSLOT9.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSLOT9.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSLOT9.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSLOT9.Location = New System.Drawing.Point(6, 347)
        Me.ledExhausSLOT9.Name = "ledExhausSLOT9"
        Me.ledExhausSLOT9.Renderer = Nothing
        Me.ledExhausSLOT9.Size = New System.Drawing.Size(115, 32)
        Me.ledExhausSLOT9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSLOT9.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSLOT9.TabIndex = 9
        '
        'ledExhausSLOT10
        '
        Me.ledExhausSLOT10.AutoSize = True
        Me.ledExhausSLOT10.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSLOT10.BlinkInterval = 500
        Me.ledExhausSLOT10.Label = "SLOT-10"
        Me.ledExhausSLOT10.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSLOT10.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSLOT10.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSLOT10.Location = New System.Drawing.Point(6, 379)
        Me.ledExhausSLOT10.Name = "ledExhausSLOT10"
        Me.ledExhausSLOT10.Renderer = Nothing
        Me.ledExhausSLOT10.Size = New System.Drawing.Size(115, 32)
        Me.ledExhausSLOT10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSLOT10.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSLOT10.TabIndex = 12
        '
        'ledExhausNone
        '
        Me.ledExhausNone.AutoSize = True
        Me.ledExhausNone.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausNone.BlinkInterval = 500
        Me.ledExhausNone.Label = "None"
        Me.ledExhausNone.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausNone.LedColor = System.Drawing.Color.Lime
        Me.ledExhausNone.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausNone.Location = New System.Drawing.Point(6, 27)
        Me.ledExhausNone.Name = "ledExhausNone"
        Me.ledExhausNone.Renderer = Nothing
        Me.ledExhausNone.Size = New System.Drawing.Size(111, 32)
        Me.ledExhausNone.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausNone.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausNone.TabIndex = 13
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.ledSupplySlotStatus_Slot10)
        Me.GroupBox14.Controls.Add(Me.ledSupplySlotStatus_Slot09)
        Me.GroupBox14.Controls.Add(Me.ledSupplySlotStatus_Slot08)
        Me.GroupBox14.Controls.Add(Me.ledSupplySlotStatus_Slot07)
        Me.GroupBox14.Controls.Add(Me.ledSupplySlotStatus_Slot06)
        Me.GroupBox14.Controls.Add(Me.ledSupplySlotStatus_Slot05)
        Me.GroupBox14.Controls.Add(Me.ledSupplySlotStatus_Slot04)
        Me.GroupBox14.Controls.Add(Me.ledSupplySlotStatus_Slot03)
        Me.GroupBox14.Controls.Add(Me.ledSupplySlotStatus_Slot02)
        Me.GroupBox14.Controls.Add(Me.ledSupplySlotStatus_Slot01)
        Me.GroupBox14.Controls.Add(Me.ledSupplySlotStatus_None)
        Me.GroupBox14.Location = New System.Drawing.Point(837, 20)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(94, 375)
        Me.GroupBox14.TabIndex = 50
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Supply Solt"
        '
        'ledSupplySlotStatus_None
        '
        Me.ledSupplySlotStatus_None.AutoSize = True
        Me.ledSupplySlotStatus_None.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySlotStatus_None.BlinkInterval = 500
        Me.ledSupplySlotStatus_None.Label = "None"
        Me.ledSupplySlotStatus_None.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySlotStatus_None.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySlotStatus_None.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySlotStatus_None.Location = New System.Drawing.Point(11, 20)
        Me.ledSupplySlotStatus_None.Name = "ledSupplySlotStatus_None"
        Me.ledSupplySlotStatus_None.Renderer = Nothing
        Me.ledSupplySlotStatus_None.Size = New System.Drawing.Size(77, 32)
        Me.ledSupplySlotStatus_None.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySlotStatus_None.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySlotStatus_None.TabIndex = 0
        '
        'ledSupplySlotStatus_Slot01
        '
        Me.ledSupplySlotStatus_Slot01.AutoSize = True
        Me.ledSupplySlotStatus_Slot01.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySlotStatus_Slot01.BlinkInterval = 500
        Me.ledSupplySlotStatus_Slot01.Label = "Solt01"
        Me.ledSupplySlotStatus_Slot01.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySlotStatus_Slot01.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySlotStatus_Slot01.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySlotStatus_Slot01.Location = New System.Drawing.Point(11, 52)
        Me.ledSupplySlotStatus_Slot01.Name = "ledSupplySlotStatus_Slot01"
        Me.ledSupplySlotStatus_Slot01.Renderer = Nothing
        Me.ledSupplySlotStatus_Slot01.Size = New System.Drawing.Size(77, 32)
        Me.ledSupplySlotStatus_Slot01.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySlotStatus_Slot01.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySlotStatus_Slot01.TabIndex = 1
        '
        'ledSupplySlotStatus_Slot02
        '
        Me.ledSupplySlotStatus_Slot02.AutoSize = True
        Me.ledSupplySlotStatus_Slot02.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySlotStatus_Slot02.BlinkInterval = 500
        Me.ledSupplySlotStatus_Slot02.Label = "Slot02"
        Me.ledSupplySlotStatus_Slot02.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySlotStatus_Slot02.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySlotStatus_Slot02.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySlotStatus_Slot02.Location = New System.Drawing.Point(11, 84)
        Me.ledSupplySlotStatus_Slot02.Name = "ledSupplySlotStatus_Slot02"
        Me.ledSupplySlotStatus_Slot02.Renderer = Nothing
        Me.ledSupplySlotStatus_Slot02.Size = New System.Drawing.Size(77, 32)
        Me.ledSupplySlotStatus_Slot02.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySlotStatus_Slot02.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySlotStatus_Slot02.TabIndex = 2
        '
        'ledSupplySlotStatus_Slot03
        '
        Me.ledSupplySlotStatus_Slot03.AutoSize = True
        Me.ledSupplySlotStatus_Slot03.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySlotStatus_Slot03.BlinkInterval = 500
        Me.ledSupplySlotStatus_Slot03.Label = "Slot03"
        Me.ledSupplySlotStatus_Slot03.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySlotStatus_Slot03.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySlotStatus_Slot03.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySlotStatus_Slot03.Location = New System.Drawing.Point(11, 116)
        Me.ledSupplySlotStatus_Slot03.Name = "ledSupplySlotStatus_Slot03"
        Me.ledSupplySlotStatus_Slot03.Renderer = Nothing
        Me.ledSupplySlotStatus_Slot03.Size = New System.Drawing.Size(77, 32)
        Me.ledSupplySlotStatus_Slot03.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySlotStatus_Slot03.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySlotStatus_Slot03.TabIndex = 3
        '
        'ledSupplySlotStatus_Slot04
        '
        Me.ledSupplySlotStatus_Slot04.AutoSize = True
        Me.ledSupplySlotStatus_Slot04.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySlotStatus_Slot04.BlinkInterval = 500
        Me.ledSupplySlotStatus_Slot04.Label = "Slot04"
        Me.ledSupplySlotStatus_Slot04.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySlotStatus_Slot04.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySlotStatus_Slot04.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySlotStatus_Slot04.Location = New System.Drawing.Point(11, 148)
        Me.ledSupplySlotStatus_Slot04.Name = "ledSupplySlotStatus_Slot04"
        Me.ledSupplySlotStatus_Slot04.Renderer = Nothing
        Me.ledSupplySlotStatus_Slot04.Size = New System.Drawing.Size(77, 32)
        Me.ledSupplySlotStatus_Slot04.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySlotStatus_Slot04.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySlotStatus_Slot04.TabIndex = 4
        '
        'ledSupplySlotStatus_Slot05
        '
        Me.ledSupplySlotStatus_Slot05.AutoSize = True
        Me.ledSupplySlotStatus_Slot05.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySlotStatus_Slot05.BlinkInterval = 500
        Me.ledSupplySlotStatus_Slot05.Label = "Slot05"
        Me.ledSupplySlotStatus_Slot05.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySlotStatus_Slot05.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySlotStatus_Slot05.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySlotStatus_Slot05.Location = New System.Drawing.Point(11, 180)
        Me.ledSupplySlotStatus_Slot05.Name = "ledSupplySlotStatus_Slot05"
        Me.ledSupplySlotStatus_Slot05.Renderer = Nothing
        Me.ledSupplySlotStatus_Slot05.Size = New System.Drawing.Size(77, 32)
        Me.ledSupplySlotStatus_Slot05.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySlotStatus_Slot05.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySlotStatus_Slot05.TabIndex = 5
        '
        'ledSupplySlotStatus_Slot06
        '
        Me.ledSupplySlotStatus_Slot06.AutoSize = True
        Me.ledSupplySlotStatus_Slot06.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySlotStatus_Slot06.BlinkInterval = 500
        Me.ledSupplySlotStatus_Slot06.Label = "Slot06"
        Me.ledSupplySlotStatus_Slot06.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySlotStatus_Slot06.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySlotStatus_Slot06.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySlotStatus_Slot06.Location = New System.Drawing.Point(11, 212)
        Me.ledSupplySlotStatus_Slot06.Name = "ledSupplySlotStatus_Slot06"
        Me.ledSupplySlotStatus_Slot06.Renderer = Nothing
        Me.ledSupplySlotStatus_Slot06.Size = New System.Drawing.Size(77, 32)
        Me.ledSupplySlotStatus_Slot06.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySlotStatus_Slot06.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySlotStatus_Slot06.TabIndex = 6
        '
        'ledSupplySlotStatus_Slot07
        '
        Me.ledSupplySlotStatus_Slot07.AutoSize = True
        Me.ledSupplySlotStatus_Slot07.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySlotStatus_Slot07.BlinkInterval = 500
        Me.ledSupplySlotStatus_Slot07.Label = "Slot07"
        Me.ledSupplySlotStatus_Slot07.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySlotStatus_Slot07.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySlotStatus_Slot07.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySlotStatus_Slot07.Location = New System.Drawing.Point(11, 244)
        Me.ledSupplySlotStatus_Slot07.Name = "ledSupplySlotStatus_Slot07"
        Me.ledSupplySlotStatus_Slot07.Renderer = Nothing
        Me.ledSupplySlotStatus_Slot07.Size = New System.Drawing.Size(77, 32)
        Me.ledSupplySlotStatus_Slot07.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySlotStatus_Slot07.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySlotStatus_Slot07.TabIndex = 7
        '
        'ledSupplySlotStatus_Slot08
        '
        Me.ledSupplySlotStatus_Slot08.AutoSize = True
        Me.ledSupplySlotStatus_Slot08.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySlotStatus_Slot08.BlinkInterval = 500
        Me.ledSupplySlotStatus_Slot08.Label = "Slot08"
        Me.ledSupplySlotStatus_Slot08.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySlotStatus_Slot08.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySlotStatus_Slot08.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySlotStatus_Slot08.Location = New System.Drawing.Point(11, 276)
        Me.ledSupplySlotStatus_Slot08.Name = "ledSupplySlotStatus_Slot08"
        Me.ledSupplySlotStatus_Slot08.Renderer = Nothing
        Me.ledSupplySlotStatus_Slot08.Size = New System.Drawing.Size(77, 32)
        Me.ledSupplySlotStatus_Slot08.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySlotStatus_Slot08.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySlotStatus_Slot08.TabIndex = 8
        '
        'ledSupplySlotStatus_Slot09
        '
        Me.ledSupplySlotStatus_Slot09.AutoSize = True
        Me.ledSupplySlotStatus_Slot09.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySlotStatus_Slot09.BlinkInterval = 500
        Me.ledSupplySlotStatus_Slot09.Label = "Slot09"
        Me.ledSupplySlotStatus_Slot09.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySlotStatus_Slot09.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySlotStatus_Slot09.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySlotStatus_Slot09.Location = New System.Drawing.Point(11, 308)
        Me.ledSupplySlotStatus_Slot09.Name = "ledSupplySlotStatus_Slot09"
        Me.ledSupplySlotStatus_Slot09.Renderer = Nothing
        Me.ledSupplySlotStatus_Slot09.Size = New System.Drawing.Size(77, 32)
        Me.ledSupplySlotStatus_Slot09.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySlotStatus_Slot09.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySlotStatus_Slot09.TabIndex = 9
        '
        'ledSupplySlotStatus_Slot10
        '
        Me.ledSupplySlotStatus_Slot10.AutoSize = True
        Me.ledSupplySlotStatus_Slot10.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplySlotStatus_Slot10.BlinkInterval = 500
        Me.ledSupplySlotStatus_Slot10.Label = "Slot10"
        Me.ledSupplySlotStatus_Slot10.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplySlotStatus_Slot10.LedColor = System.Drawing.Color.Lime
        Me.ledSupplySlotStatus_Slot10.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplySlotStatus_Slot10.Location = New System.Drawing.Point(11, 340)
        Me.ledSupplySlotStatus_Slot10.Name = "ledSupplySlotStatus_Slot10"
        Me.ledSupplySlotStatus_Slot10.Renderer = Nothing
        Me.ledSupplySlotStatus_Slot10.Size = New System.Drawing.Size(77, 32)
        Me.ledSupplySlotStatus_Slot10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplySlotStatus_Slot10.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplySlotStatus_Slot10.TabIndex = 10
        '
        'GroupBox21
        '
        Me.GroupBox21.Controls.Add(Me.ledEQPStatus_Reset)
        Me.GroupBox21.Controls.Add(Me.ledEQPStatus_STOP)
        Me.GroupBox21.Controls.Add(Me.ledEQPStatus_PAUSE)
        Me.GroupBox21.Controls.Add(Me.ledEQPStatus_RUN)
        Me.GroupBox21.Location = New System.Drawing.Point(344, 20)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Size = New System.Drawing.Size(161, 159)
        Me.GroupBox21.TabIndex = 49
        Me.GroupBox21.TabStop = False
        Me.GroupBox21.Text = "EQP Status"
        '
        'ledEQPStatus_RUN
        '
        Me.ledEQPStatus_RUN.AutoSize = True
        Me.ledEQPStatus_RUN.BackColor = System.Drawing.Color.Transparent
        Me.ledEQPStatus_RUN.BlinkInterval = 500
        Me.ledEQPStatus_RUN.Label = "RUN"
        Me.ledEQPStatus_RUN.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEQPStatus_RUN.LedColor = System.Drawing.Color.Lime
        Me.ledEQPStatus_RUN.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledEQPStatus_RUN.Location = New System.Drawing.Point(11, 20)
        Me.ledEQPStatus_RUN.Name = "ledEQPStatus_RUN"
        Me.ledEQPStatus_RUN.Renderer = Nothing
        Me.ledEQPStatus_RUN.Size = New System.Drawing.Size(169, 32)
        Me.ledEQPStatus_RUN.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEQPStatus_RUN.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEQPStatus_RUN.TabIndex = 0
        '
        'ledEQPStatus_PAUSE
        '
        Me.ledEQPStatus_PAUSE.AutoSize = True
        Me.ledEQPStatus_PAUSE.BackColor = System.Drawing.Color.Transparent
        Me.ledEQPStatus_PAUSE.BlinkInterval = 500
        Me.ledEQPStatus_PAUSE.Label = "PAUSE"
        Me.ledEQPStatus_PAUSE.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEQPStatus_PAUSE.LedColor = System.Drawing.Color.Lime
        Me.ledEQPStatus_PAUSE.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledEQPStatus_PAUSE.Location = New System.Drawing.Point(11, 84)
        Me.ledEQPStatus_PAUSE.Name = "ledEQPStatus_PAUSE"
        Me.ledEQPStatus_PAUSE.Renderer = Nothing
        Me.ledEQPStatus_PAUSE.Size = New System.Drawing.Size(169, 32)
        Me.ledEQPStatus_PAUSE.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEQPStatus_PAUSE.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEQPStatus_PAUSE.TabIndex = 2
        '
        'ledEQPStatus_STOP
        '
        Me.ledEQPStatus_STOP.AutoSize = True
        Me.ledEQPStatus_STOP.BackColor = System.Drawing.Color.Transparent
        Me.ledEQPStatus_STOP.BlinkInterval = 500
        Me.ledEQPStatus_STOP.Label = "STOP"
        Me.ledEQPStatus_STOP.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEQPStatus_STOP.LedColor = System.Drawing.Color.Lime
        Me.ledEQPStatus_STOP.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledEQPStatus_STOP.Location = New System.Drawing.Point(11, 52)
        Me.ledEQPStatus_STOP.Name = "ledEQPStatus_STOP"
        Me.ledEQPStatus_STOP.Renderer = Nothing
        Me.ledEQPStatus_STOP.Size = New System.Drawing.Size(169, 32)
        Me.ledEQPStatus_STOP.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEQPStatus_STOP.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEQPStatus_STOP.TabIndex = 9
        '
        'ledEQPStatus_Reset
        '
        Me.ledEQPStatus_Reset.AutoSize = True
        Me.ledEQPStatus_Reset.BackColor = System.Drawing.Color.Transparent
        Me.ledEQPStatus_Reset.BlinkInterval = 500
        Me.ledEQPStatus_Reset.Label = "Reset"
        Me.ledEQPStatus_Reset.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEQPStatus_Reset.LedColor = System.Drawing.Color.Lime
        Me.ledEQPStatus_Reset.LedSize = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.ledEQPStatus_Reset.Location = New System.Drawing.Point(11, 116)
        Me.ledEQPStatus_Reset.Name = "ledEQPStatus_Reset"
        Me.ledEQPStatus_Reset.Renderer = Nothing
        Me.ledEQPStatus_Reset.Size = New System.Drawing.Size(169, 32)
        Me.ledEQPStatus_Reset.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEQPStatus_Reset.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEQPStatus_Reset.TabIndex = 10
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.ledSupplyPositionStatus_Slot10)
        Me.GroupBox13.Controls.Add(Me.ledSupplyPositionStatus_Slot09)
        Me.GroupBox13.Controls.Add(Me.ledSupplyPositionStatus_Slot08)
        Me.GroupBox13.Controls.Add(Me.ledSupplyPositionStatus_Slot07)
        Me.GroupBox13.Controls.Add(Me.ledSupplyPositionStatus_Slot06)
        Me.GroupBox13.Controls.Add(Me.ledSupplyPositionStatus_Slot05)
        Me.GroupBox13.Controls.Add(Me.ledSupplyPositionStatus_Slot04)
        Me.GroupBox13.Controls.Add(Me.ledSupplyPositionStatus_Slot03)
        Me.GroupBox13.Controls.Add(Me.ledSupplyPositionStatus_Slot02)
        Me.GroupBox13.Controls.Add(Me.ledSupplyPositionStatus_Slot01)
        Me.GroupBox13.Controls.Add(Me.ledSupplyPositionStatus_Down)
        Me.GroupBox13.Location = New System.Drawing.Point(937, 20)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(81, 375)
        Me.GroupBox13.TabIndex = 51
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Supply Position"
        '
        'ledSupplyPositionStatus_Down
        '
        Me.ledSupplyPositionStatus_Down.AutoSize = True
        Me.ledSupplyPositionStatus_Down.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplyPositionStatus_Down.BlinkInterval = 500
        Me.ledSupplyPositionStatus_Down.Label = "None"
        Me.ledSupplyPositionStatus_Down.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplyPositionStatus_Down.LedColor = System.Drawing.Color.Lime
        Me.ledSupplyPositionStatus_Down.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplyPositionStatus_Down.Location = New System.Drawing.Point(11, 20)
        Me.ledSupplyPositionStatus_Down.Name = "ledSupplyPositionStatus_Down"
        Me.ledSupplyPositionStatus_Down.Renderer = Nothing
        Me.ledSupplyPositionStatus_Down.Size = New System.Drawing.Size(104, 32)
        Me.ledSupplyPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplyPositionStatus_Down.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplyPositionStatus_Down.TabIndex = 0
        '
        'ledSupplyPositionStatus_Slot01
        '
        Me.ledSupplyPositionStatus_Slot01.AutoSize = True
        Me.ledSupplyPositionStatus_Slot01.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplyPositionStatus_Slot01.BlinkInterval = 500
        Me.ledSupplyPositionStatus_Slot01.Label = "P01"
        Me.ledSupplyPositionStatus_Slot01.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplyPositionStatus_Slot01.LedColor = System.Drawing.Color.Lime
        Me.ledSupplyPositionStatus_Slot01.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplyPositionStatus_Slot01.Location = New System.Drawing.Point(11, 52)
        Me.ledSupplyPositionStatus_Slot01.Name = "ledSupplyPositionStatus_Slot01"
        Me.ledSupplyPositionStatus_Slot01.Renderer = Nothing
        Me.ledSupplyPositionStatus_Slot01.Size = New System.Drawing.Size(104, 32)
        Me.ledSupplyPositionStatus_Slot01.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplyPositionStatus_Slot01.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplyPositionStatus_Slot01.TabIndex = 1
        '
        'ledSupplyPositionStatus_Slot02
        '
        Me.ledSupplyPositionStatus_Slot02.AutoSize = True
        Me.ledSupplyPositionStatus_Slot02.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplyPositionStatus_Slot02.BlinkInterval = 500
        Me.ledSupplyPositionStatus_Slot02.Label = "P02"
        Me.ledSupplyPositionStatus_Slot02.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplyPositionStatus_Slot02.LedColor = System.Drawing.Color.Lime
        Me.ledSupplyPositionStatus_Slot02.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplyPositionStatus_Slot02.Location = New System.Drawing.Point(11, 84)
        Me.ledSupplyPositionStatus_Slot02.Name = "ledSupplyPositionStatus_Slot02"
        Me.ledSupplyPositionStatus_Slot02.Renderer = Nothing
        Me.ledSupplyPositionStatus_Slot02.Size = New System.Drawing.Size(104, 32)
        Me.ledSupplyPositionStatus_Slot02.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplyPositionStatus_Slot02.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplyPositionStatus_Slot02.TabIndex = 2
        '
        'ledSupplyPositionStatus_Slot03
        '
        Me.ledSupplyPositionStatus_Slot03.AutoSize = True
        Me.ledSupplyPositionStatus_Slot03.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplyPositionStatus_Slot03.BlinkInterval = 500
        Me.ledSupplyPositionStatus_Slot03.Label = "P03"
        Me.ledSupplyPositionStatus_Slot03.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplyPositionStatus_Slot03.LedColor = System.Drawing.Color.Lime
        Me.ledSupplyPositionStatus_Slot03.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplyPositionStatus_Slot03.Location = New System.Drawing.Point(11, 116)
        Me.ledSupplyPositionStatus_Slot03.Name = "ledSupplyPositionStatus_Slot03"
        Me.ledSupplyPositionStatus_Slot03.Renderer = Nothing
        Me.ledSupplyPositionStatus_Slot03.Size = New System.Drawing.Size(104, 32)
        Me.ledSupplyPositionStatus_Slot03.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplyPositionStatus_Slot03.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplyPositionStatus_Slot03.TabIndex = 3
        '
        'ledSupplyPositionStatus_Slot04
        '
        Me.ledSupplyPositionStatus_Slot04.AutoSize = True
        Me.ledSupplyPositionStatus_Slot04.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplyPositionStatus_Slot04.BlinkInterval = 500
        Me.ledSupplyPositionStatus_Slot04.Label = "P04"
        Me.ledSupplyPositionStatus_Slot04.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplyPositionStatus_Slot04.LedColor = System.Drawing.Color.Lime
        Me.ledSupplyPositionStatus_Slot04.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplyPositionStatus_Slot04.Location = New System.Drawing.Point(11, 148)
        Me.ledSupplyPositionStatus_Slot04.Name = "ledSupplyPositionStatus_Slot04"
        Me.ledSupplyPositionStatus_Slot04.Renderer = Nothing
        Me.ledSupplyPositionStatus_Slot04.Size = New System.Drawing.Size(104, 32)
        Me.ledSupplyPositionStatus_Slot04.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplyPositionStatus_Slot04.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplyPositionStatus_Slot04.TabIndex = 4
        '
        'ledSupplyPositionStatus_Slot05
        '
        Me.ledSupplyPositionStatus_Slot05.AutoSize = True
        Me.ledSupplyPositionStatus_Slot05.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplyPositionStatus_Slot05.BlinkInterval = 500
        Me.ledSupplyPositionStatus_Slot05.Label = "P05"
        Me.ledSupplyPositionStatus_Slot05.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplyPositionStatus_Slot05.LedColor = System.Drawing.Color.Lime
        Me.ledSupplyPositionStatus_Slot05.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplyPositionStatus_Slot05.Location = New System.Drawing.Point(11, 180)
        Me.ledSupplyPositionStatus_Slot05.Name = "ledSupplyPositionStatus_Slot05"
        Me.ledSupplyPositionStatus_Slot05.Renderer = Nothing
        Me.ledSupplyPositionStatus_Slot05.Size = New System.Drawing.Size(104, 32)
        Me.ledSupplyPositionStatus_Slot05.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplyPositionStatus_Slot05.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplyPositionStatus_Slot05.TabIndex = 5
        '
        'ledSupplyPositionStatus_Slot06
        '
        Me.ledSupplyPositionStatus_Slot06.AutoSize = True
        Me.ledSupplyPositionStatus_Slot06.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplyPositionStatus_Slot06.BlinkInterval = 500
        Me.ledSupplyPositionStatus_Slot06.Label = "P06"
        Me.ledSupplyPositionStatus_Slot06.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplyPositionStatus_Slot06.LedColor = System.Drawing.Color.Lime
        Me.ledSupplyPositionStatus_Slot06.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplyPositionStatus_Slot06.Location = New System.Drawing.Point(11, 212)
        Me.ledSupplyPositionStatus_Slot06.Name = "ledSupplyPositionStatus_Slot06"
        Me.ledSupplyPositionStatus_Slot06.Renderer = Nothing
        Me.ledSupplyPositionStatus_Slot06.Size = New System.Drawing.Size(104, 32)
        Me.ledSupplyPositionStatus_Slot06.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplyPositionStatus_Slot06.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplyPositionStatus_Slot06.TabIndex = 6
        '
        'ledSupplyPositionStatus_Slot07
        '
        Me.ledSupplyPositionStatus_Slot07.AutoSize = True
        Me.ledSupplyPositionStatus_Slot07.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplyPositionStatus_Slot07.BlinkInterval = 500
        Me.ledSupplyPositionStatus_Slot07.Label = "P07"
        Me.ledSupplyPositionStatus_Slot07.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplyPositionStatus_Slot07.LedColor = System.Drawing.Color.Lime
        Me.ledSupplyPositionStatus_Slot07.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplyPositionStatus_Slot07.Location = New System.Drawing.Point(11, 244)
        Me.ledSupplyPositionStatus_Slot07.Name = "ledSupplyPositionStatus_Slot07"
        Me.ledSupplyPositionStatus_Slot07.Renderer = Nothing
        Me.ledSupplyPositionStatus_Slot07.Size = New System.Drawing.Size(104, 32)
        Me.ledSupplyPositionStatus_Slot07.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplyPositionStatus_Slot07.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplyPositionStatus_Slot07.TabIndex = 7
        '
        'ledSupplyPositionStatus_Slot08
        '
        Me.ledSupplyPositionStatus_Slot08.AutoSize = True
        Me.ledSupplyPositionStatus_Slot08.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplyPositionStatus_Slot08.BlinkInterval = 500
        Me.ledSupplyPositionStatus_Slot08.Label = "P08"
        Me.ledSupplyPositionStatus_Slot08.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplyPositionStatus_Slot08.LedColor = System.Drawing.Color.Lime
        Me.ledSupplyPositionStatus_Slot08.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplyPositionStatus_Slot08.Location = New System.Drawing.Point(11, 276)
        Me.ledSupplyPositionStatus_Slot08.Name = "ledSupplyPositionStatus_Slot08"
        Me.ledSupplyPositionStatus_Slot08.Renderer = Nothing
        Me.ledSupplyPositionStatus_Slot08.Size = New System.Drawing.Size(104, 32)
        Me.ledSupplyPositionStatus_Slot08.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplyPositionStatus_Slot08.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplyPositionStatus_Slot08.TabIndex = 8
        '
        'ledSupplyPositionStatus_Slot09
        '
        Me.ledSupplyPositionStatus_Slot09.AutoSize = True
        Me.ledSupplyPositionStatus_Slot09.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplyPositionStatus_Slot09.BlinkInterval = 500
        Me.ledSupplyPositionStatus_Slot09.Label = "P09"
        Me.ledSupplyPositionStatus_Slot09.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplyPositionStatus_Slot09.LedColor = System.Drawing.Color.Lime
        Me.ledSupplyPositionStatus_Slot09.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplyPositionStatus_Slot09.Location = New System.Drawing.Point(11, 308)
        Me.ledSupplyPositionStatus_Slot09.Name = "ledSupplyPositionStatus_Slot09"
        Me.ledSupplyPositionStatus_Slot09.Renderer = Nothing
        Me.ledSupplyPositionStatus_Slot09.Size = New System.Drawing.Size(104, 32)
        Me.ledSupplyPositionStatus_Slot09.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplyPositionStatus_Slot09.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplyPositionStatus_Slot09.TabIndex = 9
        '
        'ledSupplyPositionStatus_Slot10
        '
        Me.ledSupplyPositionStatus_Slot10.AutoSize = True
        Me.ledSupplyPositionStatus_Slot10.BackColor = System.Drawing.Color.Transparent
        Me.ledSupplyPositionStatus_Slot10.BlinkInterval = 500
        Me.ledSupplyPositionStatus_Slot10.Label = "P10"
        Me.ledSupplyPositionStatus_Slot10.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSupplyPositionStatus_Slot10.LedColor = System.Drawing.Color.Lime
        Me.ledSupplyPositionStatus_Slot10.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSupplyPositionStatus_Slot10.Location = New System.Drawing.Point(11, 340)
        Me.ledSupplyPositionStatus_Slot10.Name = "ledSupplyPositionStatus_Slot10"
        Me.ledSupplyPositionStatus_Slot10.Renderer = Nothing
        Me.ledSupplyPositionStatus_Slot10.Size = New System.Drawing.Size(104, 32)
        Me.ledSupplyPositionStatus_Slot10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSupplyPositionStatus_Slot10.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSupplyPositionStatus_Slot10.TabIndex = 10
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.ledExhausSlotStatus_Slot10)
        Me.GroupBox16.Controls.Add(Me.ledExhausSlotStatus_Slot09)
        Me.GroupBox16.Controls.Add(Me.ledExhausSlotStatus_Slot08)
        Me.GroupBox16.Controls.Add(Me.ledExhausSlotStatus_Slot07)
        Me.GroupBox16.Controls.Add(Me.ledExhausSlotStatus_Slot06)
        Me.GroupBox16.Controls.Add(Me.ledExhausSlotStatus_Slot05)
        Me.GroupBox16.Controls.Add(Me.ledExhausSlotStatus_Slot04)
        Me.GroupBox16.Controls.Add(Me.ledExhausSlotStatus_Slot03)
        Me.GroupBox16.Controls.Add(Me.ledExhausSlotStatus_Slot02)
        Me.GroupBox16.Controls.Add(Me.ledExhausSlotStatus_Slot01)
        Me.GroupBox16.Controls.Add(Me.ledExhausSlotStatus_None)
        Me.GroupBox16.Location = New System.Drawing.Point(1024, 20)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(92, 375)
        Me.GroupBox16.TabIndex = 52
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Exhaus Solt"
        '
        'ledExhausSlotStatus_None
        '
        Me.ledExhausSlotStatus_None.AutoSize = True
        Me.ledExhausSlotStatus_None.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSlotStatus_None.BlinkInterval = 500
        Me.ledExhausSlotStatus_None.Label = "None"
        Me.ledExhausSlotStatus_None.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSlotStatus_None.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSlotStatus_None.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSlotStatus_None.Location = New System.Drawing.Point(11, 20)
        Me.ledExhausSlotStatus_None.Name = "ledExhausSlotStatus_None"
        Me.ledExhausSlotStatus_None.Renderer = Nothing
        Me.ledExhausSlotStatus_None.Size = New System.Drawing.Size(75, 32)
        Me.ledExhausSlotStatus_None.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSlotStatus_None.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSlotStatus_None.TabIndex = 0
        '
        'ledExhausSlotStatus_Slot01
        '
        Me.ledExhausSlotStatus_Slot01.AutoSize = True
        Me.ledExhausSlotStatus_Slot01.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSlotStatus_Slot01.BlinkInterval = 500
        Me.ledExhausSlotStatus_Slot01.Label = "Solt01"
        Me.ledExhausSlotStatus_Slot01.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSlotStatus_Slot01.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSlotStatus_Slot01.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSlotStatus_Slot01.Location = New System.Drawing.Point(11, 52)
        Me.ledExhausSlotStatus_Slot01.Name = "ledExhausSlotStatus_Slot01"
        Me.ledExhausSlotStatus_Slot01.Renderer = Nothing
        Me.ledExhausSlotStatus_Slot01.Size = New System.Drawing.Size(75, 32)
        Me.ledExhausSlotStatus_Slot01.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSlotStatus_Slot01.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSlotStatus_Slot01.TabIndex = 1
        '
        'ledExhausSlotStatus_Slot02
        '
        Me.ledExhausSlotStatus_Slot02.AutoSize = True
        Me.ledExhausSlotStatus_Slot02.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSlotStatus_Slot02.BlinkInterval = 500
        Me.ledExhausSlotStatus_Slot02.Label = "Slot02"
        Me.ledExhausSlotStatus_Slot02.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSlotStatus_Slot02.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSlotStatus_Slot02.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSlotStatus_Slot02.Location = New System.Drawing.Point(11, 84)
        Me.ledExhausSlotStatus_Slot02.Name = "ledExhausSlotStatus_Slot02"
        Me.ledExhausSlotStatus_Slot02.Renderer = Nothing
        Me.ledExhausSlotStatus_Slot02.Size = New System.Drawing.Size(75, 32)
        Me.ledExhausSlotStatus_Slot02.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSlotStatus_Slot02.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSlotStatus_Slot02.TabIndex = 2
        '
        'ledExhausSlotStatus_Slot03
        '
        Me.ledExhausSlotStatus_Slot03.AutoSize = True
        Me.ledExhausSlotStatus_Slot03.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSlotStatus_Slot03.BlinkInterval = 500
        Me.ledExhausSlotStatus_Slot03.Label = "Slot03"
        Me.ledExhausSlotStatus_Slot03.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSlotStatus_Slot03.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSlotStatus_Slot03.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSlotStatus_Slot03.Location = New System.Drawing.Point(11, 116)
        Me.ledExhausSlotStatus_Slot03.Name = "ledExhausSlotStatus_Slot03"
        Me.ledExhausSlotStatus_Slot03.Renderer = Nothing
        Me.ledExhausSlotStatus_Slot03.Size = New System.Drawing.Size(75, 32)
        Me.ledExhausSlotStatus_Slot03.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSlotStatus_Slot03.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSlotStatus_Slot03.TabIndex = 3
        '
        'ledExhausSlotStatus_Slot04
        '
        Me.ledExhausSlotStatus_Slot04.AutoSize = True
        Me.ledExhausSlotStatus_Slot04.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSlotStatus_Slot04.BlinkInterval = 500
        Me.ledExhausSlotStatus_Slot04.Label = "Slot04"
        Me.ledExhausSlotStatus_Slot04.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSlotStatus_Slot04.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSlotStatus_Slot04.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSlotStatus_Slot04.Location = New System.Drawing.Point(11, 148)
        Me.ledExhausSlotStatus_Slot04.Name = "ledExhausSlotStatus_Slot04"
        Me.ledExhausSlotStatus_Slot04.Renderer = Nothing
        Me.ledExhausSlotStatus_Slot04.Size = New System.Drawing.Size(75, 32)
        Me.ledExhausSlotStatus_Slot04.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSlotStatus_Slot04.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSlotStatus_Slot04.TabIndex = 4
        '
        'ledExhausSlotStatus_Slot05
        '
        Me.ledExhausSlotStatus_Slot05.AutoSize = True
        Me.ledExhausSlotStatus_Slot05.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSlotStatus_Slot05.BlinkInterval = 500
        Me.ledExhausSlotStatus_Slot05.Label = "Slot05"
        Me.ledExhausSlotStatus_Slot05.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSlotStatus_Slot05.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSlotStatus_Slot05.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSlotStatus_Slot05.Location = New System.Drawing.Point(11, 180)
        Me.ledExhausSlotStatus_Slot05.Name = "ledExhausSlotStatus_Slot05"
        Me.ledExhausSlotStatus_Slot05.Renderer = Nothing
        Me.ledExhausSlotStatus_Slot05.Size = New System.Drawing.Size(75, 32)
        Me.ledExhausSlotStatus_Slot05.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSlotStatus_Slot05.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSlotStatus_Slot05.TabIndex = 5
        '
        'ledExhausSlotStatus_Slot06
        '
        Me.ledExhausSlotStatus_Slot06.AutoSize = True
        Me.ledExhausSlotStatus_Slot06.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSlotStatus_Slot06.BlinkInterval = 500
        Me.ledExhausSlotStatus_Slot06.Label = "Slot06"
        Me.ledExhausSlotStatus_Slot06.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSlotStatus_Slot06.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSlotStatus_Slot06.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSlotStatus_Slot06.Location = New System.Drawing.Point(11, 212)
        Me.ledExhausSlotStatus_Slot06.Name = "ledExhausSlotStatus_Slot06"
        Me.ledExhausSlotStatus_Slot06.Renderer = Nothing
        Me.ledExhausSlotStatus_Slot06.Size = New System.Drawing.Size(75, 32)
        Me.ledExhausSlotStatus_Slot06.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSlotStatus_Slot06.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSlotStatus_Slot06.TabIndex = 6
        '
        'ledExhausSlotStatus_Slot07
        '
        Me.ledExhausSlotStatus_Slot07.AutoSize = True
        Me.ledExhausSlotStatus_Slot07.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSlotStatus_Slot07.BlinkInterval = 500
        Me.ledExhausSlotStatus_Slot07.Label = "Slot07"
        Me.ledExhausSlotStatus_Slot07.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSlotStatus_Slot07.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSlotStatus_Slot07.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSlotStatus_Slot07.Location = New System.Drawing.Point(11, 244)
        Me.ledExhausSlotStatus_Slot07.Name = "ledExhausSlotStatus_Slot07"
        Me.ledExhausSlotStatus_Slot07.Renderer = Nothing
        Me.ledExhausSlotStatus_Slot07.Size = New System.Drawing.Size(75, 32)
        Me.ledExhausSlotStatus_Slot07.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSlotStatus_Slot07.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSlotStatus_Slot07.TabIndex = 7
        '
        'ledExhausSlotStatus_Slot08
        '
        Me.ledExhausSlotStatus_Slot08.AutoSize = True
        Me.ledExhausSlotStatus_Slot08.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSlotStatus_Slot08.BlinkInterval = 500
        Me.ledExhausSlotStatus_Slot08.Label = "Slot08"
        Me.ledExhausSlotStatus_Slot08.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSlotStatus_Slot08.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSlotStatus_Slot08.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSlotStatus_Slot08.Location = New System.Drawing.Point(11, 276)
        Me.ledExhausSlotStatus_Slot08.Name = "ledExhausSlotStatus_Slot08"
        Me.ledExhausSlotStatus_Slot08.Renderer = Nothing
        Me.ledExhausSlotStatus_Slot08.Size = New System.Drawing.Size(75, 32)
        Me.ledExhausSlotStatus_Slot08.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSlotStatus_Slot08.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSlotStatus_Slot08.TabIndex = 8
        '
        'ledExhausSlotStatus_Slot09
        '
        Me.ledExhausSlotStatus_Slot09.AutoSize = True
        Me.ledExhausSlotStatus_Slot09.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSlotStatus_Slot09.BlinkInterval = 500
        Me.ledExhausSlotStatus_Slot09.Label = "Slot09"
        Me.ledExhausSlotStatus_Slot09.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSlotStatus_Slot09.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSlotStatus_Slot09.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSlotStatus_Slot09.Location = New System.Drawing.Point(11, 308)
        Me.ledExhausSlotStatus_Slot09.Name = "ledExhausSlotStatus_Slot09"
        Me.ledExhausSlotStatus_Slot09.Renderer = Nothing
        Me.ledExhausSlotStatus_Slot09.Size = New System.Drawing.Size(75, 32)
        Me.ledExhausSlotStatus_Slot09.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSlotStatus_Slot09.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSlotStatus_Slot09.TabIndex = 9
        '
        'ledExhausSlotStatus_Slot10
        '
        Me.ledExhausSlotStatus_Slot10.AutoSize = True
        Me.ledExhausSlotStatus_Slot10.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausSlotStatus_Slot10.BlinkInterval = 500
        Me.ledExhausSlotStatus_Slot10.Label = "Slot10"
        Me.ledExhausSlotStatus_Slot10.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausSlotStatus_Slot10.LedColor = System.Drawing.Color.Lime
        Me.ledExhausSlotStatus_Slot10.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausSlotStatus_Slot10.Location = New System.Drawing.Point(11, 340)
        Me.ledExhausSlotStatus_Slot10.Name = "ledExhausSlotStatus_Slot10"
        Me.ledExhausSlotStatus_Slot10.Renderer = Nothing
        Me.ledExhausSlotStatus_Slot10.Size = New System.Drawing.Size(75, 32)
        Me.ledExhausSlotStatus_Slot10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausSlotStatus_Slot10.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausSlotStatus_Slot10.TabIndex = 10
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.ledExhausPositionStatus_Slot10)
        Me.GroupBox15.Controls.Add(Me.ledExhausPositionStatus_Slot09)
        Me.GroupBox15.Controls.Add(Me.ledExhausPositionStatus_Slot08)
        Me.GroupBox15.Controls.Add(Me.ledExhausPositionStatus_Slot07)
        Me.GroupBox15.Controls.Add(Me.ledExhausPositionStatus_Slot06)
        Me.GroupBox15.Controls.Add(Me.ledExhausPositionStatus_Slot05)
        Me.GroupBox15.Controls.Add(Me.ledExhausPositionStatus_Slot04)
        Me.GroupBox15.Controls.Add(Me.ledExhausPositionStatus_Slot03)
        Me.GroupBox15.Controls.Add(Me.ledExhausPositionStatus_Slot02)
        Me.GroupBox15.Controls.Add(Me.ledExhausPositionStatus_Slot01)
        Me.GroupBox15.Controls.Add(Me.ledExhausPositionStatus_Down)
        Me.GroupBox15.Location = New System.Drawing.Point(1122, 20)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(82, 375)
        Me.GroupBox15.TabIndex = 53
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Exhaus Position"
        '
        'ledExhausPositionStatus_Down
        '
        Me.ledExhausPositionStatus_Down.AutoSize = True
        Me.ledExhausPositionStatus_Down.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausPositionStatus_Down.BlinkInterval = 500
        Me.ledExhausPositionStatus_Down.Label = "None"
        Me.ledExhausPositionStatus_Down.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausPositionStatus_Down.LedColor = System.Drawing.Color.Lime
        Me.ledExhausPositionStatus_Down.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausPositionStatus_Down.Location = New System.Drawing.Point(11, 20)
        Me.ledExhausPositionStatus_Down.Name = "ledExhausPositionStatus_Down"
        Me.ledExhausPositionStatus_Down.Renderer = Nothing
        Me.ledExhausPositionStatus_Down.Size = New System.Drawing.Size(98, 32)
        Me.ledExhausPositionStatus_Down.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausPositionStatus_Down.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausPositionStatus_Down.TabIndex = 0
        '
        'ledExhausPositionStatus_Slot01
        '
        Me.ledExhausPositionStatus_Slot01.AutoSize = True
        Me.ledExhausPositionStatus_Slot01.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausPositionStatus_Slot01.BlinkInterval = 500
        Me.ledExhausPositionStatus_Slot01.Label = "P01"
        Me.ledExhausPositionStatus_Slot01.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausPositionStatus_Slot01.LedColor = System.Drawing.Color.Lime
        Me.ledExhausPositionStatus_Slot01.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausPositionStatus_Slot01.Location = New System.Drawing.Point(11, 52)
        Me.ledExhausPositionStatus_Slot01.Name = "ledExhausPositionStatus_Slot01"
        Me.ledExhausPositionStatus_Slot01.Renderer = Nothing
        Me.ledExhausPositionStatus_Slot01.Size = New System.Drawing.Size(98, 32)
        Me.ledExhausPositionStatus_Slot01.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausPositionStatus_Slot01.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausPositionStatus_Slot01.TabIndex = 1
        '
        'ledExhausPositionStatus_Slot02
        '
        Me.ledExhausPositionStatus_Slot02.AutoSize = True
        Me.ledExhausPositionStatus_Slot02.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausPositionStatus_Slot02.BlinkInterval = 500
        Me.ledExhausPositionStatus_Slot02.Label = "P02"
        Me.ledExhausPositionStatus_Slot02.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausPositionStatus_Slot02.LedColor = System.Drawing.Color.Lime
        Me.ledExhausPositionStatus_Slot02.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausPositionStatus_Slot02.Location = New System.Drawing.Point(11, 84)
        Me.ledExhausPositionStatus_Slot02.Name = "ledExhausPositionStatus_Slot02"
        Me.ledExhausPositionStatus_Slot02.Renderer = Nothing
        Me.ledExhausPositionStatus_Slot02.Size = New System.Drawing.Size(98, 32)
        Me.ledExhausPositionStatus_Slot02.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausPositionStatus_Slot02.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausPositionStatus_Slot02.TabIndex = 2
        '
        'ledExhausPositionStatus_Slot03
        '
        Me.ledExhausPositionStatus_Slot03.AutoSize = True
        Me.ledExhausPositionStatus_Slot03.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausPositionStatus_Slot03.BlinkInterval = 500
        Me.ledExhausPositionStatus_Slot03.Label = "P03"
        Me.ledExhausPositionStatus_Slot03.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausPositionStatus_Slot03.LedColor = System.Drawing.Color.Lime
        Me.ledExhausPositionStatus_Slot03.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausPositionStatus_Slot03.Location = New System.Drawing.Point(11, 116)
        Me.ledExhausPositionStatus_Slot03.Name = "ledExhausPositionStatus_Slot03"
        Me.ledExhausPositionStatus_Slot03.Renderer = Nothing
        Me.ledExhausPositionStatus_Slot03.Size = New System.Drawing.Size(98, 32)
        Me.ledExhausPositionStatus_Slot03.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausPositionStatus_Slot03.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausPositionStatus_Slot03.TabIndex = 3
        '
        'ledExhausPositionStatus_Slot04
        '
        Me.ledExhausPositionStatus_Slot04.AutoSize = True
        Me.ledExhausPositionStatus_Slot04.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausPositionStatus_Slot04.BlinkInterval = 500
        Me.ledExhausPositionStatus_Slot04.Label = "P04"
        Me.ledExhausPositionStatus_Slot04.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausPositionStatus_Slot04.LedColor = System.Drawing.Color.Lime
        Me.ledExhausPositionStatus_Slot04.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausPositionStatus_Slot04.Location = New System.Drawing.Point(11, 148)
        Me.ledExhausPositionStatus_Slot04.Name = "ledExhausPositionStatus_Slot04"
        Me.ledExhausPositionStatus_Slot04.Renderer = Nothing
        Me.ledExhausPositionStatus_Slot04.Size = New System.Drawing.Size(98, 32)
        Me.ledExhausPositionStatus_Slot04.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausPositionStatus_Slot04.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausPositionStatus_Slot04.TabIndex = 4
        '
        'ledExhausPositionStatus_Slot05
        '
        Me.ledExhausPositionStatus_Slot05.AutoSize = True
        Me.ledExhausPositionStatus_Slot05.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausPositionStatus_Slot05.BlinkInterval = 500
        Me.ledExhausPositionStatus_Slot05.Label = "P05"
        Me.ledExhausPositionStatus_Slot05.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausPositionStatus_Slot05.LedColor = System.Drawing.Color.Lime
        Me.ledExhausPositionStatus_Slot05.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausPositionStatus_Slot05.Location = New System.Drawing.Point(11, 180)
        Me.ledExhausPositionStatus_Slot05.Name = "ledExhausPositionStatus_Slot05"
        Me.ledExhausPositionStatus_Slot05.Renderer = Nothing
        Me.ledExhausPositionStatus_Slot05.Size = New System.Drawing.Size(98, 32)
        Me.ledExhausPositionStatus_Slot05.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausPositionStatus_Slot05.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausPositionStatus_Slot05.TabIndex = 5
        '
        'ledExhausPositionStatus_Slot06
        '
        Me.ledExhausPositionStatus_Slot06.AutoSize = True
        Me.ledExhausPositionStatus_Slot06.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausPositionStatus_Slot06.BlinkInterval = 500
        Me.ledExhausPositionStatus_Slot06.Label = "P06"
        Me.ledExhausPositionStatus_Slot06.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausPositionStatus_Slot06.LedColor = System.Drawing.Color.Lime
        Me.ledExhausPositionStatus_Slot06.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausPositionStatus_Slot06.Location = New System.Drawing.Point(11, 212)
        Me.ledExhausPositionStatus_Slot06.Name = "ledExhausPositionStatus_Slot06"
        Me.ledExhausPositionStatus_Slot06.Renderer = Nothing
        Me.ledExhausPositionStatus_Slot06.Size = New System.Drawing.Size(98, 32)
        Me.ledExhausPositionStatus_Slot06.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausPositionStatus_Slot06.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausPositionStatus_Slot06.TabIndex = 6
        '
        'ledExhausPositionStatus_Slot07
        '
        Me.ledExhausPositionStatus_Slot07.AutoSize = True
        Me.ledExhausPositionStatus_Slot07.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausPositionStatus_Slot07.BlinkInterval = 500
        Me.ledExhausPositionStatus_Slot07.Label = "P07"
        Me.ledExhausPositionStatus_Slot07.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausPositionStatus_Slot07.LedColor = System.Drawing.Color.Lime
        Me.ledExhausPositionStatus_Slot07.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausPositionStatus_Slot07.Location = New System.Drawing.Point(11, 244)
        Me.ledExhausPositionStatus_Slot07.Name = "ledExhausPositionStatus_Slot07"
        Me.ledExhausPositionStatus_Slot07.Renderer = Nothing
        Me.ledExhausPositionStatus_Slot07.Size = New System.Drawing.Size(98, 32)
        Me.ledExhausPositionStatus_Slot07.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausPositionStatus_Slot07.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausPositionStatus_Slot07.TabIndex = 7
        '
        'ledExhausPositionStatus_Slot08
        '
        Me.ledExhausPositionStatus_Slot08.AutoSize = True
        Me.ledExhausPositionStatus_Slot08.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausPositionStatus_Slot08.BlinkInterval = 500
        Me.ledExhausPositionStatus_Slot08.Label = "P08"
        Me.ledExhausPositionStatus_Slot08.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausPositionStatus_Slot08.LedColor = System.Drawing.Color.Lime
        Me.ledExhausPositionStatus_Slot08.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausPositionStatus_Slot08.Location = New System.Drawing.Point(11, 276)
        Me.ledExhausPositionStatus_Slot08.Name = "ledExhausPositionStatus_Slot08"
        Me.ledExhausPositionStatus_Slot08.Renderer = Nothing
        Me.ledExhausPositionStatus_Slot08.Size = New System.Drawing.Size(98, 32)
        Me.ledExhausPositionStatus_Slot08.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausPositionStatus_Slot08.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausPositionStatus_Slot08.TabIndex = 8
        '
        'ledExhausPositionStatus_Slot09
        '
        Me.ledExhausPositionStatus_Slot09.AutoSize = True
        Me.ledExhausPositionStatus_Slot09.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausPositionStatus_Slot09.BlinkInterval = 500
        Me.ledExhausPositionStatus_Slot09.Label = "P09"
        Me.ledExhausPositionStatus_Slot09.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausPositionStatus_Slot09.LedColor = System.Drawing.Color.Lime
        Me.ledExhausPositionStatus_Slot09.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausPositionStatus_Slot09.Location = New System.Drawing.Point(11, 308)
        Me.ledExhausPositionStatus_Slot09.Name = "ledExhausPositionStatus_Slot09"
        Me.ledExhausPositionStatus_Slot09.Renderer = Nothing
        Me.ledExhausPositionStatus_Slot09.Size = New System.Drawing.Size(98, 32)
        Me.ledExhausPositionStatus_Slot09.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausPositionStatus_Slot09.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausPositionStatus_Slot09.TabIndex = 9
        '
        'ledExhausPositionStatus_Slot10
        '
        Me.ledExhausPositionStatus_Slot10.AutoSize = True
        Me.ledExhausPositionStatus_Slot10.BackColor = System.Drawing.Color.Transparent
        Me.ledExhausPositionStatus_Slot10.BlinkInterval = 500
        Me.ledExhausPositionStatus_Slot10.Label = "P10"
        Me.ledExhausPositionStatus_Slot10.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledExhausPositionStatus_Slot10.LedColor = System.Drawing.Color.Lime
        Me.ledExhausPositionStatus_Slot10.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledExhausPositionStatus_Slot10.Location = New System.Drawing.Point(11, 340)
        Me.ledExhausPositionStatus_Slot10.Name = "ledExhausPositionStatus_Slot10"
        Me.ledExhausPositionStatus_Slot10.Renderer = Nothing
        Me.ledExhausPositionStatus_Slot10.Size = New System.Drawing.Size(98, 32)
        Me.ledExhausPositionStatus_Slot10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledExhausPositionStatus_Slot10.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledExhausPositionStatus_Slot10.TabIndex = 10
        '
        'GroupBox24
        '
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_Contact)
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_Align)
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_Stoper)
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_NONE3)
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_NONE2)
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_Theta4Axis)
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_Theta3Axis)
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_Theta2Axis)
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_Theta1Axis)
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_Y2Axis)
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_XAxis)
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_ZAxis)
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_Y1Axis)
        Me.GroupBox24.Location = New System.Drawing.Point(226, 20)
        Me.GroupBox24.Name = "GroupBox24"
        Me.GroupBox24.Size = New System.Drawing.Size(112, 448)
        Me.GroupBox24.TabIndex = 59
        Me.GroupBox24.TabStop = False
        Me.GroupBox24.Text = "Servo On State"
        '
        'ledServoAlarm_Y1Axis
        '
        Me.ledServoAlarm_Y1Axis.AutoSize = True
        Me.ledServoAlarm_Y1Axis.BackColor = System.Drawing.Color.Transparent
        Me.ledServoAlarm_Y1Axis.BlinkInterval = 500
        Me.ledServoAlarm_Y1Axis.Label = "Y"
        Me.ledServoAlarm_Y1Axis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledServoAlarm_Y1Axis.LedColor = System.Drawing.Color.Lime
        Me.ledServoAlarm_Y1Axis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledServoAlarm_Y1Axis.Location = New System.Drawing.Point(12, 59)
        Me.ledServoAlarm_Y1Axis.Name = "ledServoAlarm_Y1Axis"
        Me.ledServoAlarm_Y1Axis.Renderer = Nothing
        Me.ledServoAlarm_Y1Axis.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_Y1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Y1Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Y1Axis.TabIndex = 1
        '
        'ledServoAlarm_ZAxis
        '
        Me.ledServoAlarm_ZAxis.AutoSize = True
        Me.ledServoAlarm_ZAxis.BackColor = System.Drawing.Color.Transparent
        Me.ledServoAlarm_ZAxis.BlinkInterval = 500
        Me.ledServoAlarm_ZAxis.Label = "Z"
        Me.ledServoAlarm_ZAxis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledServoAlarm_ZAxis.LedColor = System.Drawing.Color.Lime
        Me.ledServoAlarm_ZAxis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledServoAlarm_ZAxis.Location = New System.Drawing.Point(12, 91)
        Me.ledServoAlarm_ZAxis.Name = "ledServoAlarm_ZAxis"
        Me.ledServoAlarm_ZAxis.Renderer = Nothing
        Me.ledServoAlarm_ZAxis.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_ZAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_ZAxis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_ZAxis.TabIndex = 2
        '
        'ledServoAlarm_XAxis
        '
        Me.ledServoAlarm_XAxis.AutoSize = True
        Me.ledServoAlarm_XAxis.BackColor = System.Drawing.Color.Transparent
        Me.ledServoAlarm_XAxis.BlinkInterval = 500
        Me.ledServoAlarm_XAxis.Label = "X"
        Me.ledServoAlarm_XAxis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledServoAlarm_XAxis.LedColor = System.Drawing.Color.Lime
        Me.ledServoAlarm_XAxis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledServoAlarm_XAxis.Location = New System.Drawing.Point(12, 27)
        Me.ledServoAlarm_XAxis.Name = "ledServoAlarm_XAxis"
        Me.ledServoAlarm_XAxis.Renderer = Nothing
        Me.ledServoAlarm_XAxis.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_XAxis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_XAxis.TabIndex = 0
        '
        'ledServoAlarm_Y2Axis
        '
        Me.ledServoAlarm_Y2Axis.AutoSize = True
        Me.ledServoAlarm_Y2Axis.BackColor = System.Drawing.Color.Transparent
        Me.ledServoAlarm_Y2Axis.BlinkInterval = 500
        Me.ledServoAlarm_Y2Axis.Label = "Y2"
        Me.ledServoAlarm_Y2Axis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledServoAlarm_Y2Axis.LedColor = System.Drawing.Color.Lime
        Me.ledServoAlarm_Y2Axis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledServoAlarm_Y2Axis.Location = New System.Drawing.Point(12, 410)
        Me.ledServoAlarm_Y2Axis.Name = "ledServoAlarm_Y2Axis"
        Me.ledServoAlarm_Y2Axis.Renderer = Nothing
        Me.ledServoAlarm_Y2Axis.Size = New System.Drawing.Size(86, 32)
        Me.ledServoAlarm_Y2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Y2Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Y2Axis.TabIndex = 3
        Me.ledServoAlarm_Y2Axis.Visible = False
        '
        'ledServoAlarm_Theta1Axis
        '
        Me.ledServoAlarm_Theta1Axis.AutoSize = True
        Me.ledServoAlarm_Theta1Axis.BackColor = System.Drawing.Color.Transparent
        Me.ledServoAlarm_Theta1Axis.BlinkInterval = 500
        Me.ledServoAlarm_Theta1Axis.Label = "THETA1"
        Me.ledServoAlarm_Theta1Axis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledServoAlarm_Theta1Axis.LedColor = System.Drawing.Color.Lime
        Me.ledServoAlarm_Theta1Axis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledServoAlarm_Theta1Axis.Location = New System.Drawing.Point(12, 123)
        Me.ledServoAlarm_Theta1Axis.Name = "ledServoAlarm_Theta1Axis"
        Me.ledServoAlarm_Theta1Axis.Renderer = Nothing
        Me.ledServoAlarm_Theta1Axis.Size = New System.Drawing.Size(95, 32)
        Me.ledServoAlarm_Theta1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Theta1Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Theta1Axis.TabIndex = 4
        '
        'ledServoAlarm_Theta2Axis
        '
        Me.ledServoAlarm_Theta2Axis.AutoSize = True
        Me.ledServoAlarm_Theta2Axis.BackColor = System.Drawing.Color.Transparent
        Me.ledServoAlarm_Theta2Axis.BlinkInterval = 500
        Me.ledServoAlarm_Theta2Axis.Label = "THETA2"
        Me.ledServoAlarm_Theta2Axis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledServoAlarm_Theta2Axis.LedColor = System.Drawing.Color.Lime
        Me.ledServoAlarm_Theta2Axis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledServoAlarm_Theta2Axis.Location = New System.Drawing.Point(12, 155)
        Me.ledServoAlarm_Theta2Axis.Name = "ledServoAlarm_Theta2Axis"
        Me.ledServoAlarm_Theta2Axis.Renderer = Nothing
        Me.ledServoAlarm_Theta2Axis.Size = New System.Drawing.Size(95, 32)
        Me.ledServoAlarm_Theta2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Theta2Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Theta2Axis.TabIndex = 5
        '
        'ledServoAlarm_Theta3Axis
        '
        Me.ledServoAlarm_Theta3Axis.AutoSize = True
        Me.ledServoAlarm_Theta3Axis.BackColor = System.Drawing.Color.Transparent
        Me.ledServoAlarm_Theta3Axis.BlinkInterval = 500
        Me.ledServoAlarm_Theta3Axis.Label = "THETA3"
        Me.ledServoAlarm_Theta3Axis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledServoAlarm_Theta3Axis.LedColor = System.Drawing.Color.Lime
        Me.ledServoAlarm_Theta3Axis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledServoAlarm_Theta3Axis.Location = New System.Drawing.Point(12, 187)
        Me.ledServoAlarm_Theta3Axis.Name = "ledServoAlarm_Theta3Axis"
        Me.ledServoAlarm_Theta3Axis.Renderer = Nothing
        Me.ledServoAlarm_Theta3Axis.Size = New System.Drawing.Size(95, 32)
        Me.ledServoAlarm_Theta3Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Theta3Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Theta3Axis.TabIndex = 6
        '
        'ledServoAlarm_Theta4Axis
        '
        Me.ledServoAlarm_Theta4Axis.AutoSize = True
        Me.ledServoAlarm_Theta4Axis.BackColor = System.Drawing.Color.Transparent
        Me.ledServoAlarm_Theta4Axis.BlinkInterval = 500
        Me.ledServoAlarm_Theta4Axis.Label = "THETA4"
        Me.ledServoAlarm_Theta4Axis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledServoAlarm_Theta4Axis.LedColor = System.Drawing.Color.Lime
        Me.ledServoAlarm_Theta4Axis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledServoAlarm_Theta4Axis.Location = New System.Drawing.Point(12, 219)
        Me.ledServoAlarm_Theta4Axis.Name = "ledServoAlarm_Theta4Axis"
        Me.ledServoAlarm_Theta4Axis.Renderer = Nothing
        Me.ledServoAlarm_Theta4Axis.Size = New System.Drawing.Size(95, 32)
        Me.ledServoAlarm_Theta4Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Theta4Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Theta4Axis.TabIndex = 7
        '
        'ledServoAlarm_NONE2
        '
        Me.ledServoAlarm_NONE2.AutoSize = True
        Me.ledServoAlarm_NONE2.BackColor = System.Drawing.Color.Transparent
        Me.ledServoAlarm_NONE2.BlinkInterval = 500
        Me.ledServoAlarm_NONE2.Label = "NONE"
        Me.ledServoAlarm_NONE2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledServoAlarm_NONE2.LedColor = System.Drawing.Color.Lime
        Me.ledServoAlarm_NONE2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledServoAlarm_NONE2.Location = New System.Drawing.Point(12, 251)
        Me.ledServoAlarm_NONE2.Name = "ledServoAlarm_NONE2"
        Me.ledServoAlarm_NONE2.Renderer = Nothing
        Me.ledServoAlarm_NONE2.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_NONE2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_NONE2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_NONE2.TabIndex = 8
        '
        'ledServoAlarm_NONE3
        '
        Me.ledServoAlarm_NONE3.AutoSize = True
        Me.ledServoAlarm_NONE3.BackColor = System.Drawing.Color.Transparent
        Me.ledServoAlarm_NONE3.BlinkInterval = 500
        Me.ledServoAlarm_NONE3.Label = "NONE"
        Me.ledServoAlarm_NONE3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledServoAlarm_NONE3.LedColor = System.Drawing.Color.Lime
        Me.ledServoAlarm_NONE3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledServoAlarm_NONE3.Location = New System.Drawing.Point(12, 283)
        Me.ledServoAlarm_NONE3.Name = "ledServoAlarm_NONE3"
        Me.ledServoAlarm_NONE3.Renderer = Nothing
        Me.ledServoAlarm_NONE3.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_NONE3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_NONE3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_NONE3.TabIndex = 9
        '
        'ledServoAlarm_Stoper
        '
        Me.ledServoAlarm_Stoper.AutoSize = True
        Me.ledServoAlarm_Stoper.BackColor = System.Drawing.Color.Transparent
        Me.ledServoAlarm_Stoper.BlinkInterval = 500
        Me.ledServoAlarm_Stoper.Label = "Stoper"
        Me.ledServoAlarm_Stoper.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledServoAlarm_Stoper.LedColor = System.Drawing.Color.Lime
        Me.ledServoAlarm_Stoper.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledServoAlarm_Stoper.Location = New System.Drawing.Point(12, 315)
        Me.ledServoAlarm_Stoper.Name = "ledServoAlarm_Stoper"
        Me.ledServoAlarm_Stoper.Renderer = Nothing
        Me.ledServoAlarm_Stoper.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_Stoper.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Stoper.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Stoper.TabIndex = 10
        '
        'ledServoAlarm_Align
        '
        Me.ledServoAlarm_Align.AutoSize = True
        Me.ledServoAlarm_Align.BackColor = System.Drawing.Color.Transparent
        Me.ledServoAlarm_Align.BlinkInterval = 500
        Me.ledServoAlarm_Align.Label = "Align"
        Me.ledServoAlarm_Align.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledServoAlarm_Align.LedColor = System.Drawing.Color.Lime
        Me.ledServoAlarm_Align.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledServoAlarm_Align.Location = New System.Drawing.Point(12, 347)
        Me.ledServoAlarm_Align.Name = "ledServoAlarm_Align"
        Me.ledServoAlarm_Align.Renderer = Nothing
        Me.ledServoAlarm_Align.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_Align.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Align.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Align.TabIndex = 11
        '
        'ledServoAlarm_Contact
        '
        Me.ledServoAlarm_Contact.AutoSize = True
        Me.ledServoAlarm_Contact.BackColor = System.Drawing.Color.Transparent
        Me.ledServoAlarm_Contact.BlinkInterval = 500
        Me.ledServoAlarm_Contact.Label = "Contact"
        Me.ledServoAlarm_Contact.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledServoAlarm_Contact.LedColor = System.Drawing.Color.Lime
        Me.ledServoAlarm_Contact.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledServoAlarm_Contact.Location = New System.Drawing.Point(12, 379)
        Me.ledServoAlarm_Contact.Name = "ledServoAlarm_Contact"
        Me.ledServoAlarm_Contact.Renderer = Nothing
        Me.ledServoAlarm_Contact.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_Contact.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Contact.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Contact.TabIndex = 12
        '
        'GroupBox38
        '
        Me.GroupBox38.Controls.Add(Me.GroupBox36)
        Me.GroupBox38.Controls.Add(Me.GroupBox35)
        Me.GroupBox38.Location = New System.Drawing.Point(3, 10)
        Me.GroupBox38.Name = "GroupBox38"
        Me.GroupBox38.Size = New System.Drawing.Size(253, 780)
        Me.GroupBox38.TabIndex = 64
        Me.GroupBox38.TabStop = False
        Me.GroupBox38.Text = "Weak Alarm"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.GroupBox24)
        Me.GroupBox8.Controls.Add(Me.GroupBox15)
        Me.GroupBox8.Controls.Add(Me.GroupBox16)
        Me.GroupBox8.Controls.Add(Me.GroupBox13)
        Me.GroupBox8.Controls.Add(Me.GroupBox21)
        Me.GroupBox8.Controls.Add(Me.GroupBox14)
        Me.GroupBox8.Controls.Add(Me.GroupBox20)
        Me.GroupBox8.Controls.Add(Me.GroupBox17)
        Me.GroupBox8.Controls.Add(Me.GroupBox19)
        Me.GroupBox8.Controls.Add(Me.GroupBox9)
        Me.GroupBox8.Location = New System.Drawing.Point(25, 222)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(510, 696)
        Me.GroupBox8.TabIndex = 52
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Indicator"
        '
        'ledWeak2Alarm_0
        '
        Me.ledWeak2Alarm_0.AutoSize = True
        Me.ledWeak2Alarm_0.BackColor = System.Drawing.Color.Transparent
        Me.ledWeak2Alarm_0.BlinkInterval = 500
        Me.ledWeak2Alarm_0.Label = "None"
        Me.ledWeak2Alarm_0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledWeak2Alarm_0.LedColor = System.Drawing.Color.Red
        Me.ledWeak2Alarm_0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledWeak2Alarm_0.Location = New System.Drawing.Point(11, 16)
        Me.ledWeak2Alarm_0.Name = "ledWeak2Alarm_0"
        Me.ledWeak2Alarm_0.Renderer = Nothing
        Me.ledWeak2Alarm_0.Size = New System.Drawing.Size(215, 32)
        Me.ledWeak2Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledWeak2Alarm_0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledWeak2Alarm_0.TabIndex = 9
        '
        'ledTempAlarm_0
        '
        Me.ledTempAlarm_0.AutoSize = True
        Me.ledTempAlarm_0.BackColor = System.Drawing.Color.Transparent
        Me.ledTempAlarm_0.BlinkInterval = 500
        Me.ledTempAlarm_0.Label = "None"
        Me.ledTempAlarm_0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTempAlarm_0.LedColor = System.Drawing.Color.Red
        Me.ledTempAlarm_0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTempAlarm_0.Location = New System.Drawing.Point(11, 20)
        Me.ledTempAlarm_0.Name = "ledTempAlarm_0"
        Me.ledTempAlarm_0.Renderer = Nothing
        Me.ledTempAlarm_0.Size = New System.Drawing.Size(215, 32)
        Me.ledTempAlarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTempAlarm_0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTempAlarm_0.TabIndex = 7
        '
        'ledEOCRAlarm_0
        '
        Me.ledEOCRAlarm_0.AutoSize = True
        Me.ledEOCRAlarm_0.BackColor = System.Drawing.Color.Transparent
        Me.ledEOCRAlarm_0.BlinkInterval = 500
        Me.ledEOCRAlarm_0.Label = "None"
        Me.ledEOCRAlarm_0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEOCRAlarm_0.LedColor = System.Drawing.Color.Red
        Me.ledEOCRAlarm_0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEOCRAlarm_0.Location = New System.Drawing.Point(11, 19)
        Me.ledEOCRAlarm_0.Name = "ledEOCRAlarm_0"
        Me.ledEOCRAlarm_0.Renderer = Nothing
        Me.ledEOCRAlarm_0.Size = New System.Drawing.Size(215, 32)
        Me.ledEOCRAlarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEOCRAlarm_0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEOCRAlarm_0.TabIndex = 7
        '
        'ledSSR1Alarm_0
        '
        Me.ledSSR1Alarm_0.AutoSize = True
        Me.ledSSR1Alarm_0.BackColor = System.Drawing.Color.Transparent
        Me.ledSSR1Alarm_0.BlinkInterval = 500
        Me.ledSSR1Alarm_0.Label = "None"
        Me.ledSSR1Alarm_0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSSR1Alarm_0.LedColor = System.Drawing.Color.Red
        Me.ledSSR1Alarm_0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSSR1Alarm_0.Location = New System.Drawing.Point(11, 20)
        Me.ledSSR1Alarm_0.Name = "ledSSR1Alarm_0"
        Me.ledSSR1Alarm_0.Renderer = Nothing
        Me.ledSSR1Alarm_0.Size = New System.Drawing.Size(215, 32)
        Me.ledSSR1Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSSR1Alarm_0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSSR1Alarm_0.TabIndex = 7
        '
        'ledSSR2Alarm_0
        '
        Me.ledSSR2Alarm_0.AutoSize = True
        Me.ledSSR2Alarm_0.BackColor = System.Drawing.Color.Transparent
        Me.ledSSR2Alarm_0.BlinkInterval = 500
        Me.ledSSR2Alarm_0.Label = "None"
        Me.ledSSR2Alarm_0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledSSR2Alarm_0.LedColor = System.Drawing.Color.Red
        Me.ledSSR2Alarm_0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledSSR2Alarm_0.Location = New System.Drawing.Point(13, 19)
        Me.ledSSR2Alarm_0.Name = "ledSSR2Alarm_0"
        Me.ledSSR2Alarm_0.Renderer = Nothing
        Me.ledSSR2Alarm_0.Size = New System.Drawing.Size(215, 32)
        Me.ledSSR2Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledSSR2Alarm_0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledSSR2Alarm_0.TabIndex = 7
        '
        'ledTS1Alarm_0
        '
        Me.ledTS1Alarm_0.AutoSize = True
        Me.ledTS1Alarm_0.BackColor = System.Drawing.Color.Transparent
        Me.ledTS1Alarm_0.BlinkInterval = 500
        Me.ledTS1Alarm_0.Label = "None"
        Me.ledTS1Alarm_0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTS1Alarm_0.LedColor = System.Drawing.Color.Red
        Me.ledTS1Alarm_0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTS1Alarm_0.Location = New System.Drawing.Point(13, 19)
        Me.ledTS1Alarm_0.Name = "ledTS1Alarm_0"
        Me.ledTS1Alarm_0.Renderer = Nothing
        Me.ledTS1Alarm_0.Size = New System.Drawing.Size(215, 32)
        Me.ledTS1Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTS1Alarm_0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTS1Alarm_0.TabIndex = 7
        '
        'ledTS2Alarm_0
        '
        Me.ledTS2Alarm_0.AutoSize = True
        Me.ledTS2Alarm_0.BackColor = System.Drawing.Color.Transparent
        Me.ledTS2Alarm_0.BlinkInterval = 500
        Me.ledTS2Alarm_0.Label = "None"
        Me.ledTS2Alarm_0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledTS2Alarm_0.LedColor = System.Drawing.Color.Red
        Me.ledTS2Alarm_0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledTS2Alarm_0.Location = New System.Drawing.Point(13, 19)
        Me.ledTS2Alarm_0.Name = "ledTS2Alarm_0"
        Me.ledTS2Alarm_0.Renderer = Nothing
        Me.ledTS2Alarm_0.Size = New System.Drawing.Size(215, 32)
        Me.ledTS2Alarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledTS2Alarm_0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledTS2Alarm_0.TabIndex = 7
        '
        'ledDoorAlarm_0
        '
        Me.ledDoorAlarm_0.AutoSize = True
        Me.ledDoorAlarm_0.BackColor = System.Drawing.Color.Transparent
        Me.ledDoorAlarm_0.BlinkInterval = 500
        Me.ledDoorAlarm_0.Label = "None"
        Me.ledDoorAlarm_0.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledDoorAlarm_0.LedColor = System.Drawing.Color.Red
        Me.ledDoorAlarm_0.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledDoorAlarm_0.Location = New System.Drawing.Point(11, 13)
        Me.ledDoorAlarm_0.Name = "ledDoorAlarm_0"
        Me.ledDoorAlarm_0.Renderer = Nothing
        Me.ledDoorAlarm_0.Size = New System.Drawing.Size(215, 32)
        Me.ledDoorAlarm_0.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledDoorAlarm_0.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledDoorAlarm_0.TabIndex = 6
        '
        'ledY1Alarm_10
        '
        Me.ledY1Alarm_10.AutoSize = True
        Me.ledY1Alarm_10.BackColor = System.Drawing.Color.Transparent
        Me.ledY1Alarm_10.BlinkInterval = 500
        Me.ledY1Alarm_10.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.ledY1Alarm_10.Label = "[Ax.01] IVL-Y 동기축 위치편차 알람"
        Me.ledY1Alarm_10.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledY1Alarm_10.LedColor = System.Drawing.Color.Red
        Me.ledY1Alarm_10.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledY1Alarm_10.Location = New System.Drawing.Point(11, 335)
        Me.ledY1Alarm_10.Name = "ledY1Alarm_10"
        Me.ledY1Alarm_10.Renderer = Nothing
        Me.ledY1Alarm_10.Size = New System.Drawing.Size(215, 32)
        Me.ledY1Alarm_10.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledY1Alarm_10.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledY1Alarm_10.TabIndex = 11
        '
        'frmPLCControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1792, 1041)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox7)
        Me.Name = "frmPLCControl"
        Me.Text = "PLC Controls"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox25.ResumeLayout(False)
        Me.GroupBox25.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox23.ResumeLayout(False)
        Me.GroupBox23.PerformLayout()
        Me.GroupBox22.ResumeLayout(False)
        Me.GroupBox22.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox26.ResumeLayout(False)
        Me.GroupBox26.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox27.ResumeLayout(False)
        Me.GroupBox27.PerformLayout()
        Me.GroupBox28.ResumeLayout(False)
        Me.GroupBox28.PerformLayout()
        Me.GroupBox29.ResumeLayout(False)
        Me.GroupBox29.PerformLayout()
        Me.GroupBox30.ResumeLayout(False)
        Me.GroupBox30.PerformLayout()
        Me.GroupBox31.ResumeLayout(False)
        Me.GroupBox31.PerformLayout()
        Me.GroupBox32.ResumeLayout(False)
        Me.GroupBox32.PerformLayout()
        Me.GroupBox33.ResumeLayout(False)
        Me.GroupBox33.PerformLayout()
        Me.GroupBox34.ResumeLayout(False)
        Me.GroupBox34.PerformLayout()
        Me.GroupBox36.ResumeLayout(False)
        Me.GroupBox36.PerformLayout()
        Me.GroupBox37.ResumeLayout(False)
        Me.GroupBox35.ResumeLayout(False)
        Me.GroupBox35.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox21.ResumeLayout(False)
        Me.GroupBox21.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox24.ResumeLayout(False)
        Me.GroupBox24.PerformLayout()
        Me.GroupBox38.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents LABEL2 As System.Windows.Forms.Label
    Friend WithEvents txtIP4 As System.Windows.Forms.TextBox
    Friend WithEvents txtIP3 As System.Windows.Forms.TextBox
    Friend WithEvents txtIP2 As System.Windows.Forms.TextBox
    Friend WithEvents txtIP1 As System.Windows.Forms.TextBox
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents ledConnectionStateCheck As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents btnDisconnection As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox25 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelEQPState As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelContactInspectionStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetContactInspectionStatus As System.Windows.Forms.Button
    Friend WithEvents cbGetContactInspectionStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnGetContactInspectionStatus As System.Windows.Forms.Button
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbInDex As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tbOutBinery As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox23 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelExhausStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetExhausStatus As System.Windows.Forms.Button
    Friend WithEvents tbExhausStatusValue As System.Windows.Forms.TextBox
    Friend WithEvents btnGetExhausStatus As System.Windows.Forms.Button
    Friend WithEvents GroupBox22 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelSupplyStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetSupplyStatus As System.Windows.Forms.Button
    Friend WithEvents tbSupplyStatusValue As System.Windows.Forms.TextBox
    Friend WithEvents btnGetSupplyStatus As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetStatus As System.Windows.Forms.Button
    Friend WithEvents tbStatusValue As System.Windows.Forms.TextBox
    Friend WithEvents btnGetStatus As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelDOSignal As System.Windows.Forms.ComboBox
    Friend WithEvents tbDOValue As System.Windows.Forms.TextBox
    Friend WithEvents btnSetDO As System.Windows.Forms.Button
    Friend WithEvents btnGetDO As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSelDISignal As System.Windows.Forms.ComboBox
    Friend WithEvents tbDIValue As System.Windows.Forms.TextBox
    Friend WithEvents btnSetDI As System.Windows.Forms.Button
    Friend WithEvents btnGetDI As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox26 As System.Windows.Forms.GroupBox
    Friend WithEvents ledEMSAlarm_7 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents ledTempAlarm_4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledTempAlarm_3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledTempAlarm_2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledTempAlarm_1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents ledEOCRAlarm_4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEOCRAlarm_3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEOCRAlarm_2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEOCRAlarm_1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox31 As GroupBox
    Friend WithEvents ledXAlarm_9 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledXAlarm_8 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledXAlarm_5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledXAlarm_4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledXAlarm_3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledXAlarm_2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledXAlarm_7 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledXAlarm_6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledXAlarm_1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledXAlarm_0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox30 As GroupBox
    Friend WithEvents ledDoorAlarm_3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledDoorAlarm_2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledDoorAlarm_1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox29 As GroupBox
    Friend WithEvents ledTS2Alarm_4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledTS2Alarm_3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledTS2Alarm_2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledTS2Alarm_1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox28 As GroupBox
    Friend WithEvents ledTS1Alarm_4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledTS1Alarm_3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledTS1Alarm_2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledTS1Alarm_1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox27 As GroupBox
    Friend WithEvents ledSSR2Alarm_4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSSR2Alarm_3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSSR2Alarm_2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSSR2Alarm_1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox18 As GroupBox
    Friend WithEvents ledSSR1Alarm_4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSSR1Alarm_3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSSR1Alarm_2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSSR1Alarm_1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox34 As GroupBox
    Friend WithEvents ledZAlarm_9 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledZAlarm_8 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledZAlarm_5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledZAlarm_4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledZAlarm_3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledZAlarm_2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledZAlarm_7 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledZAlarm_6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledZAlarm_1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledZAlarm_0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox33 As GroupBox
    Friend WithEvents ledY2Alarm_9 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY2Alarm_8 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY2Alarm_5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY2Alarm_4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY2Alarm_3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY2Alarm_2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY2Alarm_7 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY2Alarm_6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY2Alarm_1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY2Alarm_0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox32 As GroupBox
    Friend WithEvents ledY1Alarm_9 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY1Alarm_8 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY1Alarm_5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY1Alarm_4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY1Alarm_3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY1Alarm_2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY1Alarm_7 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY1Alarm_6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY1Alarm_1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY1Alarm_0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox38 As GroupBox
    Friend WithEvents GroupBox36 As GroupBox
    Friend WithEvents ledWeak2Alarm_6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak2Alarm_5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak2Alarm_4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak2Alarm_3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak2Alarm_2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak2Alarm_1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox35 As GroupBox
    Friend WithEvents ledWeak1Alarm_14 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak1Alarm_13 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak1Alarm_12 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak1Alarm_11 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak1Alarm_10 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak1Alarm_9 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak1Alarm_8 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak1Alarm_5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak1Alarm_4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak1Alarm_3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak1Alarm_2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak1Alarm_7 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak1Alarm_6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak1Alarm_1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledWeak1Alarm_0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox37 As GroupBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents ledSysStatus_SystemIDLE As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_SystemLoading As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_Processing As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_ManualMode As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_AutoMode As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_TeachingMode As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_PowerDown As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_PowerON As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox19 As GroupBox
    Friend WithEvents ledSupplyNone As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySLOT10 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySLOT9 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySLOT8 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySLOT7 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySLOT6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySLOT5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySLOT4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySLOT3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySLOT2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySLOT1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySLOT0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox17 As GroupBox
    Friend WithEvents ledMagazineErrorStatus_Reserved07 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledMagazineErrorStatus_Reserved06 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledMagazineErrorStatus_Reserved05 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledMagazineErrorStatus_Reserved04 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledMagazineErrorStatus_Reserved03 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledMagazineErrorStatus_Reserved02 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledMagazineErrorStatus_Reserved01 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledMagazineErrorStatus_Down As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox20 As GroupBox
    Friend WithEvents ledExhausNone As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSLOT10 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSLOT9 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSLOT8 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSLOT7 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSLOT6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSLOT5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSLOT4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSLOT3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSLOT2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSLOT1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSLOT0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox14 As GroupBox
    Friend WithEvents ledSupplySlotStatus_Slot10 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySlotStatus_Slot09 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySlotStatus_Slot08 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySlotStatus_Slot07 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySlotStatus_Slot06 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySlotStatus_Slot05 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySlotStatus_Slot04 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySlotStatus_Slot03 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySlotStatus_Slot02 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySlotStatus_Slot01 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplySlotStatus_None As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox21 As GroupBox
    Friend WithEvents ledEQPStatus_Reset As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEQPStatus_STOP As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEQPStatus_PAUSE As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEQPStatus_RUN As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents ledSupplyPositionStatus_Slot10 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplyPositionStatus_Slot09 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplyPositionStatus_Slot08 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplyPositionStatus_Slot07 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplyPositionStatus_Slot06 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplyPositionStatus_Slot05 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplyPositionStatus_Slot04 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplyPositionStatus_Slot03 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplyPositionStatus_Slot02 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplyPositionStatus_Slot01 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSupplyPositionStatus_Down As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox16 As GroupBox
    Friend WithEvents ledExhausSlotStatus_Slot10 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSlotStatus_Slot09 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSlotStatus_Slot08 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSlotStatus_Slot07 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSlotStatus_Slot06 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSlotStatus_Slot05 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSlotStatus_Slot04 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSlotStatus_Slot03 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSlotStatus_Slot02 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSlotStatus_Slot01 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausSlotStatus_None As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox15 As GroupBox
    Friend WithEvents ledExhausPositionStatus_Slot10 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausPositionStatus_Slot09 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausPositionStatus_Slot08 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausPositionStatus_Slot07 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausPositionStatus_Slot06 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausPositionStatus_Slot05 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausPositionStatus_Slot04 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausPositionStatus_Slot03 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausPositionStatus_Slot02 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausPositionStatus_Slot01 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledExhausPositionStatus_Down As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox24 As GroupBox
    Friend WithEvents ledServoAlarm_Contact As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledServoAlarm_Align As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledServoAlarm_Stoper As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledServoAlarm_NONE3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledServoAlarm_NONE2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledServoAlarm_Theta4Axis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledServoAlarm_Theta3Axis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledServoAlarm_Theta2Axis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledServoAlarm_Theta1Axis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledServoAlarm_Y2Axis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledServoAlarm_XAxis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledServoAlarm_ZAxis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledServoAlarm_Y1Axis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents ledWeak2Alarm_0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledTempAlarm_0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEOCRAlarm_0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSSR1Alarm_0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSSR2Alarm_0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledTS1Alarm_0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledDoorAlarm_0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledTS2Alarm_0 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledY1Alarm_10 As LBSoft.IndustrialCtrls.Leds.LBLed
End Class
