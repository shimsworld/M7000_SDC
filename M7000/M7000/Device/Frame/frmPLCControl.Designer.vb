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
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.GroupBox24 = New System.Windows.Forms.GroupBox()
        Me.ledServoAlarm_Contact = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Align = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Stoper = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_NONE3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_NONE2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Theta4Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Theta3Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Theta2Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Theta1Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Y2Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_ZAxis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_XAxis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledServoAlarm_Y1Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.ledExhausPositionStatus_Slot10 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot09 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot08 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot07 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot06 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot05 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot04 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot03 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot02 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Slot01 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausPositionStatus_Down = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.ledExhausSlotStatus_Slot10 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot09 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot08 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot07 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot06 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot05 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot04 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot03 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot02 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_Slot01 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSlotStatus_None = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.ledSupplyPositionStatus_Slot10 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot09 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot08 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot07 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot06 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot05 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot04 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot03 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot02 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Slot01 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplyPositionStatus_Down = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox21 = New System.Windows.Forms.GroupBox()
        Me.ledEQPStatus_Reset = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEQPStatus_STOP = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEQPStatus_PAUSE = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEQPStatus_RUN = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.ledSupplySlotStatus_Slot10 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot09 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot08 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot07 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot06 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot05 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot04 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot03 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot02 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_Slot01 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySlotStatus_None = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.ledExhausNone = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT10 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT9 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledExhausSLOT0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.ledMagazineErrorStatus_Reserved07 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledMagazineErrorStatus_Reserved06 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledMagazineErrorStatus_Reserved05 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledMagazineErrorStatus_Reserved04 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledMagazineErrorStatus_Reserved03 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledMagazineErrorStatus_Reserved02 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledMagazineErrorStatus_Reserved01 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledMagazineErrorStatus_Down = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.ledSupplyNone = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT10 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT9 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSupplySLOT0 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.ledSysStatus_SystemIDLE = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_SystemLoading = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_Processing = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_ManualMode = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_AutoMode = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_TeachingMode = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_PowerDown = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledSysStatus_PowerON = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox27 = New System.Windows.Forms.GroupBox()
        Me.GroupBox42 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_Theta4Axis_OVER_CURRENT = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Theta4Axis_AMP_OVER = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Theta4Axis_Axis_NoError = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox41 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_Theta3Axis_OVER_CURRENT = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Theta3Axis_AMP_OVER = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Theta3Axis_Axis_NoError = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox39 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_Theta2Axis_OVER_CURRENT = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Theta2Axis_AMP_OVER = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Theta2Axis_Axis_NoError = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox40 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_Theta1Axis_OVER_CURRENT = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Theta1Axis_AMP_OVER = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Theta1Axis_Axis_NoError = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox38 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_ZAxis_OVER_CURRENT = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_ZAxis_AMP_OVER = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_ZAxis_Axis_NoError = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox37 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_YAxis_OVER_CURRENT = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_YAxis_AMP_OVER = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_YAxis_Axis_NoError = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox32 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_HitterOverZone2_CH9 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone2_CH8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone2_CH7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone2_CH6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone2_CH5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone2_CH4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone2_CH3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone2_CH2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone2_CH1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone2_No_Error = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox31 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_HitterOverZone1_CH9 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone1_CH8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone1_CH7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone1_CH6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone1_CH5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone1_CH4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone1_CH3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone1_CH2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone1_CH1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterOverZone1_No_Error = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox30 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_HitterSSR_CH9 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterSSR_CH8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterSSR_CH7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterSSR_CH6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterSSR_CH5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterSSR_CH4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterSSR_CH3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterSSR_CH2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterSSR_CH1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterSSR_No_Error = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox29 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_HitterEOCR_CH9 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterEOCR_CH8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterEOCR_CH7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterEOCR_CH6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterEOCR_CH5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterEOCR_CH4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterEOCR_CH3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterEOCR_CH2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterEOCR_CH1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterEOCR_No_Error = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox26 = New System.Windows.Forms.GroupBox()
        Me.ledEMSAlarm_MC2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_MC1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_Safety2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_Safety1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_TempHeavy = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_SMOKE = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_TempLight = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_EMS = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_NO_Error = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox28 = New System.Windows.Forms.GroupBox()
        Me.ledDoorAlarm_Door8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledDoorAlarm_Door7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledDoorAlarm_Door6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledDoorAlarm_Door5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledDoorAlarm_Door4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledDoorAlarm_Door3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledDoorAlarm_Door2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledDoorAlarm_Door1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledDoorAlarm_Safety_Door = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledDoorAlarm_NoError = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_Hitter_CH9 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Hitter_CH8 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Hitter_CH7 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Hitter_CH6 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Hitter_CH5 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Hitter_CH4 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Hitter_CH3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Hitter_CH2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Hitter_CH1 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_Hitter_No_Error = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.ledAxisAlarm_NoError = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAxisAlarm_XAxis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAxisAlarm_ZAxis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAxisAlarm_Y2Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAxisAlarm_YAxis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAxisAlarm_THETA4Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAxisAlarm_THETA1Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAxisAlarm_THETA2Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAxisAlarm_THETA3Axis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAxisAlarm_ContactAxis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAxisAlarm_NONE2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAxisAlarm_NONE3 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAxisAlarm_ALIGNAxis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAxisAlarm_STOPERAxis = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.ledEQPAlarm_Heavy = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEQPAlarm_Light = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEQPAlarm_None2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEQPAlarm_None = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox36 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_XAxis_OVER_CURRENT = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_XAxis_AMP_OVER = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_XAxis_Axis_NoError = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox35 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_HitterAxis_OVER_CURRENT = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterAxis_AMP_OVER = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_HitterAxis_NoError = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox34 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_UnLoaderAxis_AMP_OVER = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_UnLoaderAxis_NoError = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.GroupBox33 = New System.Windows.Forms.GroupBox()
        Me.ledAlarm_LoaderAxis_OVER_CURRENT = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_LoaderAxis_AMP_OVER = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledAlarm_LoaderAxis_NoError = New LBSoft.IndustrialCtrls.Leds.LBLed()
        Me.ledEMSAlarm_EMS2 = New LBSoft.IndustrialCtrls.Leds.LBLed()
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
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox24.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox21.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox27.SuspendLayout()
        Me.GroupBox42.SuspendLayout()
        Me.GroupBox41.SuspendLayout()
        Me.GroupBox39.SuspendLayout()
        Me.GroupBox40.SuspendLayout()
        Me.GroupBox38.SuspendLayout()
        Me.GroupBox37.SuspendLayout()
        Me.GroupBox32.SuspendLayout()
        Me.GroupBox31.SuspendLayout()
        Me.GroupBox30.SuspendLayout()
        Me.GroupBox29.SuspendLayout()
        Me.GroupBox26.SuspendLayout()
        Me.GroupBox28.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox36.SuspendLayout()
        Me.GroupBox35.SuspendLayout()
        Me.GroupBox34.SuspendLayout()
        Me.GroupBox33.SuspendLayout()
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
        Me.GroupBox8.Location = New System.Drawing.Point(25, 232)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(808, 686)
        Me.GroupBox8.TabIndex = 52
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Indicator"
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
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_ZAxis)
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_XAxis)
        Me.GroupBox24.Controls.Add(Me.ledServoAlarm_Y1Axis)
        Me.GroupBox24.Location = New System.Drawing.Point(514, 18)
        Me.GroupBox24.Name = "GroupBox24"
        Me.GroupBox24.Size = New System.Drawing.Size(112, 448)
        Me.GroupBox24.TabIndex = 59
        Me.GroupBox24.TabStop = False
        Me.GroupBox24.Text = "Servo On State"
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
        Me.ledServoAlarm_Contact.Location = New System.Drawing.Point(11, 340)
        Me.ledServoAlarm_Contact.Name = "ledServoAlarm_Contact"
        Me.ledServoAlarm_Contact.Renderer = Nothing
        Me.ledServoAlarm_Contact.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_Contact.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Contact.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Contact.TabIndex = 12
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
        Me.ledServoAlarm_Align.Location = New System.Drawing.Point(11, 308)
        Me.ledServoAlarm_Align.Name = "ledServoAlarm_Align"
        Me.ledServoAlarm_Align.Renderer = Nothing
        Me.ledServoAlarm_Align.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_Align.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Align.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Align.TabIndex = 11
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
        Me.ledServoAlarm_Stoper.Location = New System.Drawing.Point(11, 276)
        Me.ledServoAlarm_Stoper.Name = "ledServoAlarm_Stoper"
        Me.ledServoAlarm_Stoper.Renderer = Nothing
        Me.ledServoAlarm_Stoper.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_Stoper.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Stoper.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Stoper.TabIndex = 10
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
        Me.ledServoAlarm_NONE3.Location = New System.Drawing.Point(11, 244)
        Me.ledServoAlarm_NONE3.Name = "ledServoAlarm_NONE3"
        Me.ledServoAlarm_NONE3.Renderer = Nothing
        Me.ledServoAlarm_NONE3.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_NONE3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_NONE3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_NONE3.TabIndex = 9
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
        Me.ledServoAlarm_NONE2.Location = New System.Drawing.Point(11, 212)
        Me.ledServoAlarm_NONE2.Name = "ledServoAlarm_NONE2"
        Me.ledServoAlarm_NONE2.Renderer = Nothing
        Me.ledServoAlarm_NONE2.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_NONE2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_NONE2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_NONE2.TabIndex = 8
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
        Me.ledServoAlarm_Theta4Axis.Location = New System.Drawing.Point(11, 180)
        Me.ledServoAlarm_Theta4Axis.Name = "ledServoAlarm_Theta4Axis"
        Me.ledServoAlarm_Theta4Axis.Renderer = Nothing
        Me.ledServoAlarm_Theta4Axis.Size = New System.Drawing.Size(95, 32)
        Me.ledServoAlarm_Theta4Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Theta4Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Theta4Axis.TabIndex = 7
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
        Me.ledServoAlarm_Theta3Axis.Location = New System.Drawing.Point(11, 148)
        Me.ledServoAlarm_Theta3Axis.Name = "ledServoAlarm_Theta3Axis"
        Me.ledServoAlarm_Theta3Axis.Renderer = Nothing
        Me.ledServoAlarm_Theta3Axis.Size = New System.Drawing.Size(95, 32)
        Me.ledServoAlarm_Theta3Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Theta3Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Theta3Axis.TabIndex = 6
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
        Me.ledServoAlarm_Theta2Axis.Location = New System.Drawing.Point(11, 116)
        Me.ledServoAlarm_Theta2Axis.Name = "ledServoAlarm_Theta2Axis"
        Me.ledServoAlarm_Theta2Axis.Renderer = Nothing
        Me.ledServoAlarm_Theta2Axis.Size = New System.Drawing.Size(95, 32)
        Me.ledServoAlarm_Theta2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Theta2Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Theta2Axis.TabIndex = 5
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
        Me.ledServoAlarm_Theta1Axis.Location = New System.Drawing.Point(11, 84)
        Me.ledServoAlarm_Theta1Axis.Name = "ledServoAlarm_Theta1Axis"
        Me.ledServoAlarm_Theta1Axis.Renderer = Nothing
        Me.ledServoAlarm_Theta1Axis.Size = New System.Drawing.Size(95, 32)
        Me.ledServoAlarm_Theta1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Theta1Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Theta1Axis.TabIndex = 4
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
        Me.ledServoAlarm_Y2Axis.Location = New System.Drawing.Point(11, 378)
        Me.ledServoAlarm_Y2Axis.Name = "ledServoAlarm_Y2Axis"
        Me.ledServoAlarm_Y2Axis.Renderer = Nothing
        Me.ledServoAlarm_Y2Axis.Size = New System.Drawing.Size(86, 32)
        Me.ledServoAlarm_Y2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Y2Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Y2Axis.TabIndex = 3
        Me.ledServoAlarm_Y2Axis.Visible = False
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
        Me.ledServoAlarm_ZAxis.Location = New System.Drawing.Point(11, 52)
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
        Me.ledServoAlarm_XAxis.Location = New System.Drawing.Point(11, 410)
        Me.ledServoAlarm_XAxis.Name = "ledServoAlarm_XAxis"
        Me.ledServoAlarm_XAxis.Renderer = Nothing
        Me.ledServoAlarm_XAxis.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_XAxis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_XAxis.TabIndex = 0
        Me.ledServoAlarm_XAxis.Visible = False
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
        Me.ledServoAlarm_Y1Axis.Location = New System.Drawing.Point(11, 20)
        Me.ledServoAlarm_Y1Axis.Name = "ledServoAlarm_Y1Axis"
        Me.ledServoAlarm_Y1Axis.Renderer = Nothing
        Me.ledServoAlarm_Y1Axis.Size = New System.Drawing.Size(75, 32)
        Me.ledServoAlarm_Y1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledServoAlarm_Y1Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledServoAlarm_Y1Axis.TabIndex = 1
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
        'GroupBox21
        '
        Me.GroupBox21.Controls.Add(Me.ledEQPStatus_Reset)
        Me.GroupBox21.Controls.Add(Me.ledEQPStatus_STOP)
        Me.GroupBox21.Controls.Add(Me.ledEQPStatus_PAUSE)
        Me.GroupBox21.Controls.Add(Me.ledEQPStatus_RUN)
        Me.GroupBox21.Location = New System.Drawing.Point(632, 18)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Size = New System.Drawing.Size(161, 159)
        Me.GroupBox21.TabIndex = 49
        Me.GroupBox21.TabStop = False
        Me.GroupBox21.Text = "EQP Status"
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
        Me.GroupBox20.Location = New System.Drawing.Point(370, 18)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(132, 432)
        Me.GroupBox20.TabIndex = 48
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Exhaus Slot Status"
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
        Me.GroupBox19.Location = New System.Drawing.Point(236, 20)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(128, 430)
        Me.GroupBox19.TabIndex = 46
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "Supply Slot Status"
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
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.GroupBox27)
        Me.Panel2.Location = New System.Drawing.Point(843, 241)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(936, 782)
        Me.Panel2.TabIndex = 61
        '
        'GroupBox27
        '
        Me.GroupBox27.Controls.Add(Me.GroupBox42)
        Me.GroupBox27.Controls.Add(Me.GroupBox41)
        Me.GroupBox27.Controls.Add(Me.GroupBox39)
        Me.GroupBox27.Controls.Add(Me.GroupBox40)
        Me.GroupBox27.Controls.Add(Me.GroupBox38)
        Me.GroupBox27.Controls.Add(Me.GroupBox37)
        Me.GroupBox27.Controls.Add(Me.GroupBox32)
        Me.GroupBox27.Controls.Add(Me.GroupBox31)
        Me.GroupBox27.Controls.Add(Me.GroupBox30)
        Me.GroupBox27.Controls.Add(Me.GroupBox29)
        Me.GroupBox27.Controls.Add(Me.GroupBox26)
        Me.GroupBox27.Controls.Add(Me.GroupBox28)
        Me.GroupBox27.Controls.Add(Me.GroupBox10)
        Me.GroupBox27.Controls.Add(Me.GroupBox12)
        Me.GroupBox27.Controls.Add(Me.GroupBox18)
        Me.GroupBox27.Location = New System.Drawing.Point(12, 11)
        Me.GroupBox27.Name = "GroupBox27"
        Me.GroupBox27.Size = New System.Drawing.Size(911, 763)
        Me.GroupBox27.TabIndex = 59
        Me.GroupBox27.TabStop = False
        Me.GroupBox27.Text = "Alarm"
        '
        'GroupBox42
        '
        Me.GroupBox42.Controls.Add(Me.ledAlarm_Theta4Axis_OVER_CURRENT)
        Me.GroupBox42.Controls.Add(Me.ledAlarm_Theta4Axis_AMP_OVER)
        Me.GroupBox42.Controls.Add(Me.ledAlarm_Theta4Axis_Axis_NoError)
        Me.GroupBox42.Location = New System.Drawing.Point(527, 633)
        Me.GroupBox42.Name = "GroupBox42"
        Me.GroupBox42.Size = New System.Drawing.Size(167, 121)
        Me.GroupBox42.TabIndex = 72
        Me.GroupBox42.TabStop = False
        Me.GroupBox42.Text = "Theta4 Axis Alarm"
        '
        'ledAlarm_Theta4Axis_OVER_CURRENT
        '
        Me.ledAlarm_Theta4Axis_OVER_CURRENT.AutoSize = True
        Me.ledAlarm_Theta4Axis_OVER_CURRENT.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Theta4Axis_OVER_CURRENT.BlinkInterval = 500
        Me.ledAlarm_Theta4Axis_OVER_CURRENT.Label = "T4축 과전류 알람"
        Me.ledAlarm_Theta4Axis_OVER_CURRENT.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Theta4Axis_OVER_CURRENT.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Theta4Axis_OVER_CURRENT.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Theta4Axis_OVER_CURRENT.Location = New System.Drawing.Point(11, 84)
        Me.ledAlarm_Theta4Axis_OVER_CURRENT.Name = "ledAlarm_Theta4Axis_OVER_CURRENT"
        Me.ledAlarm_Theta4Axis_OVER_CURRENT.Renderer = Nothing
        Me.ledAlarm_Theta4Axis_OVER_CURRENT.Size = New System.Drawing.Size(178, 32)
        Me.ledAlarm_Theta4Axis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Theta4Axis_OVER_CURRENT.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Theta4Axis_OVER_CURRENT.TabIndex = 2
        '
        'ledAlarm_Theta4Axis_AMP_OVER
        '
        Me.ledAlarm_Theta4Axis_AMP_OVER.AutoSize = True
        Me.ledAlarm_Theta4Axis_AMP_OVER.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Theta4Axis_AMP_OVER.BlinkInterval = 500
        Me.ledAlarm_Theta4Axis_AMP_OVER.Label = "T4축 AMP 과온 알람"
        Me.ledAlarm_Theta4Axis_AMP_OVER.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Theta4Axis_AMP_OVER.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Theta4Axis_AMP_OVER.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Theta4Axis_AMP_OVER.Location = New System.Drawing.Point(11, 52)
        Me.ledAlarm_Theta4Axis_AMP_OVER.Name = "ledAlarm_Theta4Axis_AMP_OVER"
        Me.ledAlarm_Theta4Axis_AMP_OVER.Renderer = Nothing
        Me.ledAlarm_Theta4Axis_AMP_OVER.Size = New System.Drawing.Size(194, 32)
        Me.ledAlarm_Theta4Axis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Theta4Axis_AMP_OVER.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Theta4Axis_AMP_OVER.TabIndex = 1
        '
        'ledAlarm_Theta4Axis_Axis_NoError
        '
        Me.ledAlarm_Theta4Axis_Axis_NoError.AutoSize = True
        Me.ledAlarm_Theta4Axis_Axis_NoError.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Theta4Axis_Axis_NoError.BlinkInterval = 500
        Me.ledAlarm_Theta4Axis_Axis_NoError.Label = "No Error"
        Me.ledAlarm_Theta4Axis_Axis_NoError.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Theta4Axis_Axis_NoError.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Theta4Axis_Axis_NoError.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Theta4Axis_Axis_NoError.Location = New System.Drawing.Point(11, 20)
        Me.ledAlarm_Theta4Axis_Axis_NoError.Name = "ledAlarm_Theta4Axis_Axis_NoError"
        Me.ledAlarm_Theta4Axis_Axis_NoError.Renderer = Nothing
        Me.ledAlarm_Theta4Axis_Axis_NoError.Size = New System.Drawing.Size(143, 32)
        Me.ledAlarm_Theta4Axis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Theta4Axis_Axis_NoError.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Theta4Axis_Axis_NoError.TabIndex = 0
        '
        'GroupBox41
        '
        Me.GroupBox41.Controls.Add(Me.ledAlarm_Theta3Axis_OVER_CURRENT)
        Me.GroupBox41.Controls.Add(Me.ledAlarm_Theta3Axis_AMP_OVER)
        Me.GroupBox41.Controls.Add(Me.ledAlarm_Theta3Axis_Axis_NoError)
        Me.GroupBox41.Location = New System.Drawing.Point(354, 633)
        Me.GroupBox41.Name = "GroupBox41"
        Me.GroupBox41.Size = New System.Drawing.Size(167, 121)
        Me.GroupBox41.TabIndex = 73
        Me.GroupBox41.TabStop = False
        Me.GroupBox41.Text = "Theta3 Axis Alarm"
        '
        'ledAlarm_Theta3Axis_OVER_CURRENT
        '
        Me.ledAlarm_Theta3Axis_OVER_CURRENT.AutoSize = True
        Me.ledAlarm_Theta3Axis_OVER_CURRENT.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Theta3Axis_OVER_CURRENT.BlinkInterval = 500
        Me.ledAlarm_Theta3Axis_OVER_CURRENT.Label = "T3축 과전류 알람"
        Me.ledAlarm_Theta3Axis_OVER_CURRENT.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Theta3Axis_OVER_CURRENT.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Theta3Axis_OVER_CURRENT.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Theta3Axis_OVER_CURRENT.Location = New System.Drawing.Point(11, 84)
        Me.ledAlarm_Theta3Axis_OVER_CURRENT.Name = "ledAlarm_Theta3Axis_OVER_CURRENT"
        Me.ledAlarm_Theta3Axis_OVER_CURRENT.Renderer = Nothing
        Me.ledAlarm_Theta3Axis_OVER_CURRENT.Size = New System.Drawing.Size(178, 32)
        Me.ledAlarm_Theta3Axis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Theta3Axis_OVER_CURRENT.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Theta3Axis_OVER_CURRENT.TabIndex = 2
        '
        'ledAlarm_Theta3Axis_AMP_OVER
        '
        Me.ledAlarm_Theta3Axis_AMP_OVER.AutoSize = True
        Me.ledAlarm_Theta3Axis_AMP_OVER.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Theta3Axis_AMP_OVER.BlinkInterval = 500
        Me.ledAlarm_Theta3Axis_AMP_OVER.Label = "T3축 AMP 과온 알람"
        Me.ledAlarm_Theta3Axis_AMP_OVER.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Theta3Axis_AMP_OVER.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Theta3Axis_AMP_OVER.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Theta3Axis_AMP_OVER.Location = New System.Drawing.Point(11, 52)
        Me.ledAlarm_Theta3Axis_AMP_OVER.Name = "ledAlarm_Theta3Axis_AMP_OVER"
        Me.ledAlarm_Theta3Axis_AMP_OVER.Renderer = Nothing
        Me.ledAlarm_Theta3Axis_AMP_OVER.Size = New System.Drawing.Size(194, 32)
        Me.ledAlarm_Theta3Axis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Theta3Axis_AMP_OVER.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Theta3Axis_AMP_OVER.TabIndex = 1
        '
        'ledAlarm_Theta3Axis_Axis_NoError
        '
        Me.ledAlarm_Theta3Axis_Axis_NoError.AutoSize = True
        Me.ledAlarm_Theta3Axis_Axis_NoError.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Theta3Axis_Axis_NoError.BlinkInterval = 500
        Me.ledAlarm_Theta3Axis_Axis_NoError.Label = "No Error"
        Me.ledAlarm_Theta3Axis_Axis_NoError.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Theta3Axis_Axis_NoError.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Theta3Axis_Axis_NoError.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Theta3Axis_Axis_NoError.Location = New System.Drawing.Point(11, 20)
        Me.ledAlarm_Theta3Axis_Axis_NoError.Name = "ledAlarm_Theta3Axis_Axis_NoError"
        Me.ledAlarm_Theta3Axis_Axis_NoError.Renderer = Nothing
        Me.ledAlarm_Theta3Axis_Axis_NoError.Size = New System.Drawing.Size(143, 32)
        Me.ledAlarm_Theta3Axis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Theta3Axis_Axis_NoError.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Theta3Axis_Axis_NoError.TabIndex = 0
        '
        'GroupBox39
        '
        Me.GroupBox39.Controls.Add(Me.ledAlarm_Theta2Axis_OVER_CURRENT)
        Me.GroupBox39.Controls.Add(Me.ledAlarm_Theta2Axis_AMP_OVER)
        Me.GroupBox39.Controls.Add(Me.ledAlarm_Theta2Axis_Axis_NoError)
        Me.GroupBox39.Location = New System.Drawing.Point(180, 633)
        Me.GroupBox39.Name = "GroupBox39"
        Me.GroupBox39.Size = New System.Drawing.Size(167, 121)
        Me.GroupBox39.TabIndex = 72
        Me.GroupBox39.TabStop = False
        Me.GroupBox39.Text = "Theta2 Axis Alarm"
        '
        'ledAlarm_Theta2Axis_OVER_CURRENT
        '
        Me.ledAlarm_Theta2Axis_OVER_CURRENT.AutoSize = True
        Me.ledAlarm_Theta2Axis_OVER_CURRENT.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Theta2Axis_OVER_CURRENT.BlinkInterval = 500
        Me.ledAlarm_Theta2Axis_OVER_CURRENT.Label = "T2축 과전류 알람"
        Me.ledAlarm_Theta2Axis_OVER_CURRENT.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Theta2Axis_OVER_CURRENT.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Theta2Axis_OVER_CURRENT.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Theta2Axis_OVER_CURRENT.Location = New System.Drawing.Point(11, 84)
        Me.ledAlarm_Theta2Axis_OVER_CURRENT.Name = "ledAlarm_Theta2Axis_OVER_CURRENT"
        Me.ledAlarm_Theta2Axis_OVER_CURRENT.Renderer = Nothing
        Me.ledAlarm_Theta2Axis_OVER_CURRENT.Size = New System.Drawing.Size(178, 32)
        Me.ledAlarm_Theta2Axis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Theta2Axis_OVER_CURRENT.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Theta2Axis_OVER_CURRENT.TabIndex = 2
        '
        'ledAlarm_Theta2Axis_AMP_OVER
        '
        Me.ledAlarm_Theta2Axis_AMP_OVER.AutoSize = True
        Me.ledAlarm_Theta2Axis_AMP_OVER.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Theta2Axis_AMP_OVER.BlinkInterval = 500
        Me.ledAlarm_Theta2Axis_AMP_OVER.Label = "T2축 AMP 과온 알람"
        Me.ledAlarm_Theta2Axis_AMP_OVER.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Theta2Axis_AMP_OVER.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Theta2Axis_AMP_OVER.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Theta2Axis_AMP_OVER.Location = New System.Drawing.Point(11, 52)
        Me.ledAlarm_Theta2Axis_AMP_OVER.Name = "ledAlarm_Theta2Axis_AMP_OVER"
        Me.ledAlarm_Theta2Axis_AMP_OVER.Renderer = Nothing
        Me.ledAlarm_Theta2Axis_AMP_OVER.Size = New System.Drawing.Size(194, 32)
        Me.ledAlarm_Theta2Axis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Theta2Axis_AMP_OVER.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Theta2Axis_AMP_OVER.TabIndex = 1
        '
        'ledAlarm_Theta2Axis_Axis_NoError
        '
        Me.ledAlarm_Theta2Axis_Axis_NoError.AutoSize = True
        Me.ledAlarm_Theta2Axis_Axis_NoError.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Theta2Axis_Axis_NoError.BlinkInterval = 500
        Me.ledAlarm_Theta2Axis_Axis_NoError.Label = "No Error"
        Me.ledAlarm_Theta2Axis_Axis_NoError.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Theta2Axis_Axis_NoError.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Theta2Axis_Axis_NoError.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Theta2Axis_Axis_NoError.Location = New System.Drawing.Point(11, 20)
        Me.ledAlarm_Theta2Axis_Axis_NoError.Name = "ledAlarm_Theta2Axis_Axis_NoError"
        Me.ledAlarm_Theta2Axis_Axis_NoError.Renderer = Nothing
        Me.ledAlarm_Theta2Axis_Axis_NoError.Size = New System.Drawing.Size(143, 32)
        Me.ledAlarm_Theta2Axis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Theta2Axis_Axis_NoError.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Theta2Axis_Axis_NoError.TabIndex = 0
        '
        'GroupBox40
        '
        Me.GroupBox40.Controls.Add(Me.ledAlarm_Theta1Axis_OVER_CURRENT)
        Me.GroupBox40.Controls.Add(Me.ledAlarm_Theta1Axis_AMP_OVER)
        Me.GroupBox40.Controls.Add(Me.ledAlarm_Theta1Axis_Axis_NoError)
        Me.GroupBox40.Location = New System.Drawing.Point(7, 633)
        Me.GroupBox40.Name = "GroupBox40"
        Me.GroupBox40.Size = New System.Drawing.Size(167, 121)
        Me.GroupBox40.TabIndex = 71
        Me.GroupBox40.TabStop = False
        Me.GroupBox40.Text = "Theta1 Axis Alarm"
        '
        'ledAlarm_Theta1Axis_OVER_CURRENT
        '
        Me.ledAlarm_Theta1Axis_OVER_CURRENT.AutoSize = True
        Me.ledAlarm_Theta1Axis_OVER_CURRENT.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Theta1Axis_OVER_CURRENT.BlinkInterval = 500
        Me.ledAlarm_Theta1Axis_OVER_CURRENT.Label = "T1축 과전류 알람"
        Me.ledAlarm_Theta1Axis_OVER_CURRENT.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Theta1Axis_OVER_CURRENT.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Theta1Axis_OVER_CURRENT.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Theta1Axis_OVER_CURRENT.Location = New System.Drawing.Point(11, 84)
        Me.ledAlarm_Theta1Axis_OVER_CURRENT.Name = "ledAlarm_Theta1Axis_OVER_CURRENT"
        Me.ledAlarm_Theta1Axis_OVER_CURRENT.Renderer = Nothing
        Me.ledAlarm_Theta1Axis_OVER_CURRENT.Size = New System.Drawing.Size(178, 32)
        Me.ledAlarm_Theta1Axis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Theta1Axis_OVER_CURRENT.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Theta1Axis_OVER_CURRENT.TabIndex = 2
        '
        'ledAlarm_Theta1Axis_AMP_OVER
        '
        Me.ledAlarm_Theta1Axis_AMP_OVER.AutoSize = True
        Me.ledAlarm_Theta1Axis_AMP_OVER.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Theta1Axis_AMP_OVER.BlinkInterval = 500
        Me.ledAlarm_Theta1Axis_AMP_OVER.Label = "T1축 AMP 과온 알람"
        Me.ledAlarm_Theta1Axis_AMP_OVER.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Theta1Axis_AMP_OVER.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Theta1Axis_AMP_OVER.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Theta1Axis_AMP_OVER.Location = New System.Drawing.Point(11, 52)
        Me.ledAlarm_Theta1Axis_AMP_OVER.Name = "ledAlarm_Theta1Axis_AMP_OVER"
        Me.ledAlarm_Theta1Axis_AMP_OVER.Renderer = Nothing
        Me.ledAlarm_Theta1Axis_AMP_OVER.Size = New System.Drawing.Size(194, 32)
        Me.ledAlarm_Theta1Axis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Theta1Axis_AMP_OVER.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Theta1Axis_AMP_OVER.TabIndex = 1
        '
        'ledAlarm_Theta1Axis_Axis_NoError
        '
        Me.ledAlarm_Theta1Axis_Axis_NoError.AutoSize = True
        Me.ledAlarm_Theta1Axis_Axis_NoError.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Theta1Axis_Axis_NoError.BlinkInterval = 500
        Me.ledAlarm_Theta1Axis_Axis_NoError.Label = "No Error"
        Me.ledAlarm_Theta1Axis_Axis_NoError.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Theta1Axis_Axis_NoError.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Theta1Axis_Axis_NoError.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Theta1Axis_Axis_NoError.Location = New System.Drawing.Point(11, 20)
        Me.ledAlarm_Theta1Axis_Axis_NoError.Name = "ledAlarm_Theta1Axis_Axis_NoError"
        Me.ledAlarm_Theta1Axis_Axis_NoError.Renderer = Nothing
        Me.ledAlarm_Theta1Axis_Axis_NoError.Size = New System.Drawing.Size(143, 32)
        Me.ledAlarm_Theta1Axis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Theta1Axis_Axis_NoError.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Theta1Axis_Axis_NoError.TabIndex = 0
        '
        'GroupBox38
        '
        Me.GroupBox38.Controls.Add(Me.ledAlarm_ZAxis_OVER_CURRENT)
        Me.GroupBox38.Controls.Add(Me.ledAlarm_ZAxis_AMP_OVER)
        Me.GroupBox38.Controls.Add(Me.ledAlarm_ZAxis_Axis_NoError)
        Me.GroupBox38.Location = New System.Drawing.Point(527, 501)
        Me.GroupBox38.Name = "GroupBox38"
        Me.GroupBox38.Size = New System.Drawing.Size(167, 121)
        Me.GroupBox38.TabIndex = 69
        Me.GroupBox38.TabStop = False
        Me.GroupBox38.Text = "Z Axis Alarm"
        '
        'ledAlarm_ZAxis_OVER_CURRENT
        '
        Me.ledAlarm_ZAxis_OVER_CURRENT.AutoSize = True
        Me.ledAlarm_ZAxis_OVER_CURRENT.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_ZAxis_OVER_CURRENT.BlinkInterval = 500
        Me.ledAlarm_ZAxis_OVER_CURRENT.Label = "Z축 과전류 알람"
        Me.ledAlarm_ZAxis_OVER_CURRENT.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_ZAxis_OVER_CURRENT.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_ZAxis_OVER_CURRENT.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_ZAxis_OVER_CURRENT.Location = New System.Drawing.Point(11, 84)
        Me.ledAlarm_ZAxis_OVER_CURRENT.Name = "ledAlarm_ZAxis_OVER_CURRENT"
        Me.ledAlarm_ZAxis_OVER_CURRENT.Renderer = Nothing
        Me.ledAlarm_ZAxis_OVER_CURRENT.Size = New System.Drawing.Size(178, 32)
        Me.ledAlarm_ZAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_ZAxis_OVER_CURRENT.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_ZAxis_OVER_CURRENT.TabIndex = 2
        '
        'ledAlarm_ZAxis_AMP_OVER
        '
        Me.ledAlarm_ZAxis_AMP_OVER.AutoSize = True
        Me.ledAlarm_ZAxis_AMP_OVER.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_ZAxis_AMP_OVER.BlinkInterval = 500
        Me.ledAlarm_ZAxis_AMP_OVER.Label = "Z축 AMP 과온 알람"
        Me.ledAlarm_ZAxis_AMP_OVER.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_ZAxis_AMP_OVER.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_ZAxis_AMP_OVER.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_ZAxis_AMP_OVER.Location = New System.Drawing.Point(11, 52)
        Me.ledAlarm_ZAxis_AMP_OVER.Name = "ledAlarm_ZAxis_AMP_OVER"
        Me.ledAlarm_ZAxis_AMP_OVER.Renderer = Nothing
        Me.ledAlarm_ZAxis_AMP_OVER.Size = New System.Drawing.Size(194, 32)
        Me.ledAlarm_ZAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_ZAxis_AMP_OVER.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_ZAxis_AMP_OVER.TabIndex = 1
        '
        'ledAlarm_ZAxis_Axis_NoError
        '
        Me.ledAlarm_ZAxis_Axis_NoError.AutoSize = True
        Me.ledAlarm_ZAxis_Axis_NoError.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_ZAxis_Axis_NoError.BlinkInterval = 500
        Me.ledAlarm_ZAxis_Axis_NoError.Label = "No Error"
        Me.ledAlarm_ZAxis_Axis_NoError.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_ZAxis_Axis_NoError.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_ZAxis_Axis_NoError.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_ZAxis_Axis_NoError.Location = New System.Drawing.Point(11, 20)
        Me.ledAlarm_ZAxis_Axis_NoError.Name = "ledAlarm_ZAxis_Axis_NoError"
        Me.ledAlarm_ZAxis_Axis_NoError.Renderer = Nothing
        Me.ledAlarm_ZAxis_Axis_NoError.Size = New System.Drawing.Size(143, 32)
        Me.ledAlarm_ZAxis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_ZAxis_Axis_NoError.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_ZAxis_Axis_NoError.TabIndex = 0
        '
        'GroupBox37
        '
        Me.GroupBox37.Controls.Add(Me.ledAlarm_YAxis_OVER_CURRENT)
        Me.GroupBox37.Controls.Add(Me.ledAlarm_YAxis_AMP_OVER)
        Me.GroupBox37.Controls.Add(Me.ledAlarm_YAxis_Axis_NoError)
        Me.GroupBox37.Location = New System.Drawing.Point(527, 369)
        Me.GroupBox37.Name = "GroupBox37"
        Me.GroupBox37.Size = New System.Drawing.Size(167, 121)
        Me.GroupBox37.TabIndex = 68
        Me.GroupBox37.TabStop = False
        Me.GroupBox37.Text = "Y Axis Alarm"
        '
        'ledAlarm_YAxis_OVER_CURRENT
        '
        Me.ledAlarm_YAxis_OVER_CURRENT.AutoSize = True
        Me.ledAlarm_YAxis_OVER_CURRENT.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_YAxis_OVER_CURRENT.BlinkInterval = 500
        Me.ledAlarm_YAxis_OVER_CURRENT.Label = "Y축 과전류 알람"
        Me.ledAlarm_YAxis_OVER_CURRENT.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_YAxis_OVER_CURRENT.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_YAxis_OVER_CURRENT.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_YAxis_OVER_CURRENT.Location = New System.Drawing.Point(11, 84)
        Me.ledAlarm_YAxis_OVER_CURRENT.Name = "ledAlarm_YAxis_OVER_CURRENT"
        Me.ledAlarm_YAxis_OVER_CURRENT.Renderer = Nothing
        Me.ledAlarm_YAxis_OVER_CURRENT.Size = New System.Drawing.Size(178, 32)
        Me.ledAlarm_YAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_YAxis_OVER_CURRENT.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_YAxis_OVER_CURRENT.TabIndex = 2
        '
        'ledAlarm_YAxis_AMP_OVER
        '
        Me.ledAlarm_YAxis_AMP_OVER.AutoSize = True
        Me.ledAlarm_YAxis_AMP_OVER.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_YAxis_AMP_OVER.BlinkInterval = 500
        Me.ledAlarm_YAxis_AMP_OVER.Label = "Y축 AMP 과온 알람"
        Me.ledAlarm_YAxis_AMP_OVER.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_YAxis_AMP_OVER.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_YAxis_AMP_OVER.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_YAxis_AMP_OVER.Location = New System.Drawing.Point(11, 52)
        Me.ledAlarm_YAxis_AMP_OVER.Name = "ledAlarm_YAxis_AMP_OVER"
        Me.ledAlarm_YAxis_AMP_OVER.Renderer = Nothing
        Me.ledAlarm_YAxis_AMP_OVER.Size = New System.Drawing.Size(194, 32)
        Me.ledAlarm_YAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_YAxis_AMP_OVER.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_YAxis_AMP_OVER.TabIndex = 1
        '
        'ledAlarm_YAxis_Axis_NoError
        '
        Me.ledAlarm_YAxis_Axis_NoError.AutoSize = True
        Me.ledAlarm_YAxis_Axis_NoError.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_YAxis_Axis_NoError.BlinkInterval = 500
        Me.ledAlarm_YAxis_Axis_NoError.Label = "No Error"
        Me.ledAlarm_YAxis_Axis_NoError.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_YAxis_Axis_NoError.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_YAxis_Axis_NoError.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_YAxis_Axis_NoError.Location = New System.Drawing.Point(11, 20)
        Me.ledAlarm_YAxis_Axis_NoError.Name = "ledAlarm_YAxis_Axis_NoError"
        Me.ledAlarm_YAxis_Axis_NoError.Renderer = Nothing
        Me.ledAlarm_YAxis_Axis_NoError.Size = New System.Drawing.Size(136, 32)
        Me.ledAlarm_YAxis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_YAxis_Axis_NoError.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_YAxis_Axis_NoError.TabIndex = 0
        '
        'GroupBox32
        '
        Me.GroupBox32.Controls.Add(Me.ledAlarm_HitterOverZone2_CH9)
        Me.GroupBox32.Controls.Add(Me.ledAlarm_HitterOverZone2_CH8)
        Me.GroupBox32.Controls.Add(Me.ledAlarm_HitterOverZone2_CH7)
        Me.GroupBox32.Controls.Add(Me.ledAlarm_HitterOverZone2_CH6)
        Me.GroupBox32.Controls.Add(Me.ledAlarm_HitterOverZone2_CH5)
        Me.GroupBox32.Controls.Add(Me.ledAlarm_HitterOverZone2_CH4)
        Me.GroupBox32.Controls.Add(Me.ledAlarm_HitterOverZone2_CH3)
        Me.GroupBox32.Controls.Add(Me.ledAlarm_HitterOverZone2_CH2)
        Me.GroupBox32.Controls.Add(Me.ledAlarm_HitterOverZone2_CH1)
        Me.GroupBox32.Controls.Add(Me.ledAlarm_HitterOverZone2_No_Error)
        Me.GroupBox32.Location = New System.Drawing.Point(764, 366)
        Me.GroupBox32.Name = "GroupBox32"
        Me.GroupBox32.Size = New System.Drawing.Size(141, 348)
        Me.GroupBox32.TabIndex = 63
        Me.GroupBox32.TabStop = False
        Me.GroupBox32.Text = "온도 과온 알람"
        Me.GroupBox32.Visible = False
        '
        'ledAlarm_HitterOverZone2_CH9
        '
        Me.ledAlarm_HitterOverZone2_CH9.AutoSize = True
        Me.ledAlarm_HitterOverZone2_CH9.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone2_CH9.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone2_CH9.Label = "CH9-2"
        Me.ledAlarm_HitterOverZone2_CH9.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone2_CH9.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone2_CH9.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone2_CH9.Location = New System.Drawing.Point(16, 308)
        Me.ledAlarm_HitterOverZone2_CH9.Name = "ledAlarm_HitterOverZone2_CH9"
        Me.ledAlarm_HitterOverZone2_CH9.Renderer = Nothing
        Me.ledAlarm_HitterOverZone2_CH9.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone2_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone2_CH9.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone2_CH9.TabIndex = 9
        '
        'ledAlarm_HitterOverZone2_CH8
        '
        Me.ledAlarm_HitterOverZone2_CH8.AutoSize = True
        Me.ledAlarm_HitterOverZone2_CH8.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone2_CH8.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone2_CH8.Label = "CH8-2"
        Me.ledAlarm_HitterOverZone2_CH8.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone2_CH8.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone2_CH8.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone2_CH8.Location = New System.Drawing.Point(16, 276)
        Me.ledAlarm_HitterOverZone2_CH8.Name = "ledAlarm_HitterOverZone2_CH8"
        Me.ledAlarm_HitterOverZone2_CH8.Renderer = Nothing
        Me.ledAlarm_HitterOverZone2_CH8.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone2_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone2_CH8.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone2_CH8.TabIndex = 8
        '
        'ledAlarm_HitterOverZone2_CH7
        '
        Me.ledAlarm_HitterOverZone2_CH7.AutoSize = True
        Me.ledAlarm_HitterOverZone2_CH7.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone2_CH7.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone2_CH7.Label = "CH7-2"
        Me.ledAlarm_HitterOverZone2_CH7.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone2_CH7.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone2_CH7.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone2_CH7.Location = New System.Drawing.Point(16, 244)
        Me.ledAlarm_HitterOverZone2_CH7.Name = "ledAlarm_HitterOverZone2_CH7"
        Me.ledAlarm_HitterOverZone2_CH7.Renderer = Nothing
        Me.ledAlarm_HitterOverZone2_CH7.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone2_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone2_CH7.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone2_CH7.TabIndex = 7
        '
        'ledAlarm_HitterOverZone2_CH6
        '
        Me.ledAlarm_HitterOverZone2_CH6.AutoSize = True
        Me.ledAlarm_HitterOverZone2_CH6.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone2_CH6.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone2_CH6.Label = "CH6-2"
        Me.ledAlarm_HitterOverZone2_CH6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone2_CH6.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone2_CH6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone2_CH6.Location = New System.Drawing.Point(16, 212)
        Me.ledAlarm_HitterOverZone2_CH6.Name = "ledAlarm_HitterOverZone2_CH6"
        Me.ledAlarm_HitterOverZone2_CH6.Renderer = Nothing
        Me.ledAlarm_HitterOverZone2_CH6.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone2_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone2_CH6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone2_CH6.TabIndex = 6
        '
        'ledAlarm_HitterOverZone2_CH5
        '
        Me.ledAlarm_HitterOverZone2_CH5.AutoSize = True
        Me.ledAlarm_HitterOverZone2_CH5.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone2_CH5.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone2_CH5.Label = "CH5-2"
        Me.ledAlarm_HitterOverZone2_CH5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone2_CH5.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone2_CH5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone2_CH5.Location = New System.Drawing.Point(16, 180)
        Me.ledAlarm_HitterOverZone2_CH5.Name = "ledAlarm_HitterOverZone2_CH5"
        Me.ledAlarm_HitterOverZone2_CH5.Renderer = Nothing
        Me.ledAlarm_HitterOverZone2_CH5.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone2_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone2_CH5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone2_CH5.TabIndex = 5
        '
        'ledAlarm_HitterOverZone2_CH4
        '
        Me.ledAlarm_HitterOverZone2_CH4.AutoSize = True
        Me.ledAlarm_HitterOverZone2_CH4.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone2_CH4.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone2_CH4.Label = "CH4-2"
        Me.ledAlarm_HitterOverZone2_CH4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone2_CH4.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone2_CH4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone2_CH4.Location = New System.Drawing.Point(16, 148)
        Me.ledAlarm_HitterOverZone2_CH4.Name = "ledAlarm_HitterOverZone2_CH4"
        Me.ledAlarm_HitterOverZone2_CH4.Renderer = Nothing
        Me.ledAlarm_HitterOverZone2_CH4.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone2_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone2_CH4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone2_CH4.TabIndex = 4
        '
        'ledAlarm_HitterOverZone2_CH3
        '
        Me.ledAlarm_HitterOverZone2_CH3.AutoSize = True
        Me.ledAlarm_HitterOverZone2_CH3.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone2_CH3.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone2_CH3.Label = "CH3-2"
        Me.ledAlarm_HitterOverZone2_CH3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone2_CH3.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone2_CH3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone2_CH3.Location = New System.Drawing.Point(16, 116)
        Me.ledAlarm_HitterOverZone2_CH3.Name = "ledAlarm_HitterOverZone2_CH3"
        Me.ledAlarm_HitterOverZone2_CH3.Renderer = Nothing
        Me.ledAlarm_HitterOverZone2_CH3.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone2_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone2_CH3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone2_CH3.TabIndex = 3
        '
        'ledAlarm_HitterOverZone2_CH2
        '
        Me.ledAlarm_HitterOverZone2_CH2.AutoSize = True
        Me.ledAlarm_HitterOverZone2_CH2.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone2_CH2.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone2_CH2.Label = "CH2-2"
        Me.ledAlarm_HitterOverZone2_CH2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone2_CH2.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone2_CH2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone2_CH2.Location = New System.Drawing.Point(16, 84)
        Me.ledAlarm_HitterOverZone2_CH2.Name = "ledAlarm_HitterOverZone2_CH2"
        Me.ledAlarm_HitterOverZone2_CH2.Renderer = Nothing
        Me.ledAlarm_HitterOverZone2_CH2.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone2_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone2_CH2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone2_CH2.TabIndex = 2
        '
        'ledAlarm_HitterOverZone2_CH1
        '
        Me.ledAlarm_HitterOverZone2_CH1.AutoSize = True
        Me.ledAlarm_HitterOverZone2_CH1.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone2_CH1.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone2_CH1.Label = "CH1-2"
        Me.ledAlarm_HitterOverZone2_CH1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone2_CH1.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone2_CH1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone2_CH1.Location = New System.Drawing.Point(16, 52)
        Me.ledAlarm_HitterOverZone2_CH1.Name = "ledAlarm_HitterOverZone2_CH1"
        Me.ledAlarm_HitterOverZone2_CH1.Renderer = Nothing
        Me.ledAlarm_HitterOverZone2_CH1.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone2_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone2_CH1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone2_CH1.TabIndex = 1
        '
        'ledAlarm_HitterOverZone2_No_Error
        '
        Me.ledAlarm_HitterOverZone2_No_Error.AutoSize = True
        Me.ledAlarm_HitterOverZone2_No_Error.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone2_No_Error.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone2_No_Error.Label = "No Error"
        Me.ledAlarm_HitterOverZone2_No_Error.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone2_No_Error.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone2_No_Error.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone2_No_Error.Location = New System.Drawing.Point(16, 20)
        Me.ledAlarm_HitterOverZone2_No_Error.Name = "ledAlarm_HitterOverZone2_No_Error"
        Me.ledAlarm_HitterOverZone2_No_Error.Renderer = Nothing
        Me.ledAlarm_HitterOverZone2_No_Error.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone2_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone2_No_Error.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone2_No_Error.TabIndex = 0
        '
        'GroupBox31
        '
        Me.GroupBox31.Controls.Add(Me.ledAlarm_HitterOverZone1_CH9)
        Me.GroupBox31.Controls.Add(Me.ledAlarm_HitterOverZone1_CH8)
        Me.GroupBox31.Controls.Add(Me.ledAlarm_HitterOverZone1_CH7)
        Me.GroupBox31.Controls.Add(Me.ledAlarm_HitterOverZone1_CH6)
        Me.GroupBox31.Controls.Add(Me.ledAlarm_HitterOverZone1_CH5)
        Me.GroupBox31.Controls.Add(Me.ledAlarm_HitterOverZone1_CH4)
        Me.GroupBox31.Controls.Add(Me.ledAlarm_HitterOverZone1_CH3)
        Me.GroupBox31.Controls.Add(Me.ledAlarm_HitterOverZone1_CH2)
        Me.GroupBox31.Controls.Add(Me.ledAlarm_HitterOverZone1_CH1)
        Me.GroupBox31.Controls.Add(Me.ledAlarm_HitterOverZone1_No_Error)
        Me.GroupBox31.Location = New System.Drawing.Point(713, 366)
        Me.GroupBox31.Name = "GroupBox31"
        Me.GroupBox31.Size = New System.Drawing.Size(141, 348)
        Me.GroupBox31.TabIndex = 62
        Me.GroupBox31.TabStop = False
        Me.GroupBox31.Text = "온도 과온 알람"
        Me.GroupBox31.Visible = False
        '
        'ledAlarm_HitterOverZone1_CH9
        '
        Me.ledAlarm_HitterOverZone1_CH9.AutoSize = True
        Me.ledAlarm_HitterOverZone1_CH9.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone1_CH9.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone1_CH9.Label = "CH9-1"
        Me.ledAlarm_HitterOverZone1_CH9.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone1_CH9.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone1_CH9.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone1_CH9.Location = New System.Drawing.Point(16, 308)
        Me.ledAlarm_HitterOverZone1_CH9.Name = "ledAlarm_HitterOverZone1_CH9"
        Me.ledAlarm_HitterOverZone1_CH9.Renderer = Nothing
        Me.ledAlarm_HitterOverZone1_CH9.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone1_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone1_CH9.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone1_CH9.TabIndex = 9
        '
        'ledAlarm_HitterOverZone1_CH8
        '
        Me.ledAlarm_HitterOverZone1_CH8.AutoSize = True
        Me.ledAlarm_HitterOverZone1_CH8.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone1_CH8.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone1_CH8.Label = "CH8-1"
        Me.ledAlarm_HitterOverZone1_CH8.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone1_CH8.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone1_CH8.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone1_CH8.Location = New System.Drawing.Point(16, 276)
        Me.ledAlarm_HitterOverZone1_CH8.Name = "ledAlarm_HitterOverZone1_CH8"
        Me.ledAlarm_HitterOverZone1_CH8.Renderer = Nothing
        Me.ledAlarm_HitterOverZone1_CH8.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone1_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone1_CH8.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone1_CH8.TabIndex = 8
        '
        'ledAlarm_HitterOverZone1_CH7
        '
        Me.ledAlarm_HitterOverZone1_CH7.AutoSize = True
        Me.ledAlarm_HitterOverZone1_CH7.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone1_CH7.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone1_CH7.Label = "CH7-1"
        Me.ledAlarm_HitterOverZone1_CH7.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone1_CH7.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone1_CH7.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone1_CH7.Location = New System.Drawing.Point(16, 244)
        Me.ledAlarm_HitterOverZone1_CH7.Name = "ledAlarm_HitterOverZone1_CH7"
        Me.ledAlarm_HitterOverZone1_CH7.Renderer = Nothing
        Me.ledAlarm_HitterOverZone1_CH7.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone1_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone1_CH7.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone1_CH7.TabIndex = 7
        '
        'ledAlarm_HitterOverZone1_CH6
        '
        Me.ledAlarm_HitterOverZone1_CH6.AutoSize = True
        Me.ledAlarm_HitterOverZone1_CH6.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone1_CH6.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone1_CH6.Label = "CH6-1"
        Me.ledAlarm_HitterOverZone1_CH6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone1_CH6.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone1_CH6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone1_CH6.Location = New System.Drawing.Point(16, 212)
        Me.ledAlarm_HitterOverZone1_CH6.Name = "ledAlarm_HitterOverZone1_CH6"
        Me.ledAlarm_HitterOverZone1_CH6.Renderer = Nothing
        Me.ledAlarm_HitterOverZone1_CH6.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone1_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone1_CH6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone1_CH6.TabIndex = 6
        '
        'ledAlarm_HitterOverZone1_CH5
        '
        Me.ledAlarm_HitterOverZone1_CH5.AutoSize = True
        Me.ledAlarm_HitterOverZone1_CH5.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone1_CH5.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone1_CH5.Label = "CH5-1"
        Me.ledAlarm_HitterOverZone1_CH5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone1_CH5.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone1_CH5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone1_CH5.Location = New System.Drawing.Point(16, 180)
        Me.ledAlarm_HitterOverZone1_CH5.Name = "ledAlarm_HitterOverZone1_CH5"
        Me.ledAlarm_HitterOverZone1_CH5.Renderer = Nothing
        Me.ledAlarm_HitterOverZone1_CH5.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone1_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone1_CH5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone1_CH5.TabIndex = 5
        '
        'ledAlarm_HitterOverZone1_CH4
        '
        Me.ledAlarm_HitterOverZone1_CH4.AutoSize = True
        Me.ledAlarm_HitterOverZone1_CH4.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone1_CH4.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone1_CH4.Label = "CH4-1"
        Me.ledAlarm_HitterOverZone1_CH4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone1_CH4.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone1_CH4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone1_CH4.Location = New System.Drawing.Point(16, 148)
        Me.ledAlarm_HitterOverZone1_CH4.Name = "ledAlarm_HitterOverZone1_CH4"
        Me.ledAlarm_HitterOverZone1_CH4.Renderer = Nothing
        Me.ledAlarm_HitterOverZone1_CH4.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone1_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone1_CH4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone1_CH4.TabIndex = 4
        '
        'ledAlarm_HitterOverZone1_CH3
        '
        Me.ledAlarm_HitterOverZone1_CH3.AutoSize = True
        Me.ledAlarm_HitterOverZone1_CH3.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone1_CH3.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone1_CH3.Label = "CH3-1"
        Me.ledAlarm_HitterOverZone1_CH3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone1_CH3.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone1_CH3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone1_CH3.Location = New System.Drawing.Point(16, 116)
        Me.ledAlarm_HitterOverZone1_CH3.Name = "ledAlarm_HitterOverZone1_CH3"
        Me.ledAlarm_HitterOverZone1_CH3.Renderer = Nothing
        Me.ledAlarm_HitterOverZone1_CH3.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone1_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone1_CH3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone1_CH3.TabIndex = 3
        '
        'ledAlarm_HitterOverZone1_CH2
        '
        Me.ledAlarm_HitterOverZone1_CH2.AutoSize = True
        Me.ledAlarm_HitterOverZone1_CH2.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone1_CH2.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone1_CH2.Label = "CH2-1"
        Me.ledAlarm_HitterOverZone1_CH2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone1_CH2.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone1_CH2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone1_CH2.Location = New System.Drawing.Point(16, 84)
        Me.ledAlarm_HitterOverZone1_CH2.Name = "ledAlarm_HitterOverZone1_CH2"
        Me.ledAlarm_HitterOverZone1_CH2.Renderer = Nothing
        Me.ledAlarm_HitterOverZone1_CH2.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone1_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone1_CH2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone1_CH2.TabIndex = 2
        '
        'ledAlarm_HitterOverZone1_CH1
        '
        Me.ledAlarm_HitterOverZone1_CH1.AutoSize = True
        Me.ledAlarm_HitterOverZone1_CH1.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone1_CH1.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone1_CH1.Label = "CH1-1"
        Me.ledAlarm_HitterOverZone1_CH1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone1_CH1.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone1_CH1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone1_CH1.Location = New System.Drawing.Point(16, 52)
        Me.ledAlarm_HitterOverZone1_CH1.Name = "ledAlarm_HitterOverZone1_CH1"
        Me.ledAlarm_HitterOverZone1_CH1.Renderer = Nothing
        Me.ledAlarm_HitterOverZone1_CH1.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone1_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone1_CH1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone1_CH1.TabIndex = 1
        '
        'ledAlarm_HitterOverZone1_No_Error
        '
        Me.ledAlarm_HitterOverZone1_No_Error.AutoSize = True
        Me.ledAlarm_HitterOverZone1_No_Error.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterOverZone1_No_Error.BlinkInterval = 500
        Me.ledAlarm_HitterOverZone1_No_Error.Label = "No Error"
        Me.ledAlarm_HitterOverZone1_No_Error.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterOverZone1_No_Error.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterOverZone1_No_Error.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterOverZone1_No_Error.Location = New System.Drawing.Point(16, 20)
        Me.ledAlarm_HitterOverZone1_No_Error.Name = "ledAlarm_HitterOverZone1_No_Error"
        Me.ledAlarm_HitterOverZone1_No_Error.Renderer = Nothing
        Me.ledAlarm_HitterOverZone1_No_Error.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterOverZone1_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterOverZone1_No_Error.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterOverZone1_No_Error.TabIndex = 0
        '
        'GroupBox30
        '
        Me.GroupBox30.Controls.Add(Me.ledAlarm_HitterSSR_CH9)
        Me.GroupBox30.Controls.Add(Me.ledAlarm_HitterSSR_CH8)
        Me.GroupBox30.Controls.Add(Me.ledAlarm_HitterSSR_CH7)
        Me.GroupBox30.Controls.Add(Me.ledAlarm_HitterSSR_CH6)
        Me.GroupBox30.Controls.Add(Me.ledAlarm_HitterSSR_CH5)
        Me.GroupBox30.Controls.Add(Me.ledAlarm_HitterSSR_CH4)
        Me.GroupBox30.Controls.Add(Me.ledAlarm_HitterSSR_CH3)
        Me.GroupBox30.Controls.Add(Me.ledAlarm_HitterSSR_CH2)
        Me.GroupBox30.Controls.Add(Me.ledAlarm_HitterSSR_CH1)
        Me.GroupBox30.Controls.Add(Me.ledAlarm_HitterSSR_No_Error)
        Me.GroupBox30.Location = New System.Drawing.Point(764, 12)
        Me.GroupBox30.Name = "GroupBox30"
        Me.GroupBox30.Size = New System.Drawing.Size(141, 348)
        Me.GroupBox30.TabIndex = 61
        Me.GroupBox30.TabStop = False
        Me.GroupBox30.Text = "히터 SSR"
        Me.GroupBox30.Visible = False
        '
        'ledAlarm_HitterSSR_CH9
        '
        Me.ledAlarm_HitterSSR_CH9.AutoSize = True
        Me.ledAlarm_HitterSSR_CH9.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterSSR_CH9.BlinkInterval = 500
        Me.ledAlarm_HitterSSR_CH9.Label = "CH9"
        Me.ledAlarm_HitterSSR_CH9.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterSSR_CH9.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterSSR_CH9.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterSSR_CH9.Location = New System.Drawing.Point(16, 308)
        Me.ledAlarm_HitterSSR_CH9.Name = "ledAlarm_HitterSSR_CH9"
        Me.ledAlarm_HitterSSR_CH9.Renderer = Nothing
        Me.ledAlarm_HitterSSR_CH9.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterSSR_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterSSR_CH9.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterSSR_CH9.TabIndex = 9
        '
        'ledAlarm_HitterSSR_CH8
        '
        Me.ledAlarm_HitterSSR_CH8.AutoSize = True
        Me.ledAlarm_HitterSSR_CH8.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterSSR_CH8.BlinkInterval = 500
        Me.ledAlarm_HitterSSR_CH8.Label = "CH8"
        Me.ledAlarm_HitterSSR_CH8.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterSSR_CH8.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterSSR_CH8.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterSSR_CH8.Location = New System.Drawing.Point(16, 276)
        Me.ledAlarm_HitterSSR_CH8.Name = "ledAlarm_HitterSSR_CH8"
        Me.ledAlarm_HitterSSR_CH8.Renderer = Nothing
        Me.ledAlarm_HitterSSR_CH8.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterSSR_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterSSR_CH8.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterSSR_CH8.TabIndex = 8
        '
        'ledAlarm_HitterSSR_CH7
        '
        Me.ledAlarm_HitterSSR_CH7.AutoSize = True
        Me.ledAlarm_HitterSSR_CH7.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterSSR_CH7.BlinkInterval = 500
        Me.ledAlarm_HitterSSR_CH7.Label = "CH7"
        Me.ledAlarm_HitterSSR_CH7.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterSSR_CH7.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterSSR_CH7.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterSSR_CH7.Location = New System.Drawing.Point(16, 244)
        Me.ledAlarm_HitterSSR_CH7.Name = "ledAlarm_HitterSSR_CH7"
        Me.ledAlarm_HitterSSR_CH7.Renderer = Nothing
        Me.ledAlarm_HitterSSR_CH7.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterSSR_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterSSR_CH7.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterSSR_CH7.TabIndex = 7
        '
        'ledAlarm_HitterSSR_CH6
        '
        Me.ledAlarm_HitterSSR_CH6.AutoSize = True
        Me.ledAlarm_HitterSSR_CH6.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterSSR_CH6.BlinkInterval = 500
        Me.ledAlarm_HitterSSR_CH6.Label = "CH6"
        Me.ledAlarm_HitterSSR_CH6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterSSR_CH6.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterSSR_CH6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterSSR_CH6.Location = New System.Drawing.Point(16, 212)
        Me.ledAlarm_HitterSSR_CH6.Name = "ledAlarm_HitterSSR_CH6"
        Me.ledAlarm_HitterSSR_CH6.Renderer = Nothing
        Me.ledAlarm_HitterSSR_CH6.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterSSR_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterSSR_CH6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterSSR_CH6.TabIndex = 6
        '
        'ledAlarm_HitterSSR_CH5
        '
        Me.ledAlarm_HitterSSR_CH5.AutoSize = True
        Me.ledAlarm_HitterSSR_CH5.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterSSR_CH5.BlinkInterval = 500
        Me.ledAlarm_HitterSSR_CH5.Label = "CH5"
        Me.ledAlarm_HitterSSR_CH5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterSSR_CH5.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterSSR_CH5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterSSR_CH5.Location = New System.Drawing.Point(16, 180)
        Me.ledAlarm_HitterSSR_CH5.Name = "ledAlarm_HitterSSR_CH5"
        Me.ledAlarm_HitterSSR_CH5.Renderer = Nothing
        Me.ledAlarm_HitterSSR_CH5.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterSSR_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterSSR_CH5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterSSR_CH5.TabIndex = 5
        '
        'ledAlarm_HitterSSR_CH4
        '
        Me.ledAlarm_HitterSSR_CH4.AutoSize = True
        Me.ledAlarm_HitterSSR_CH4.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterSSR_CH4.BlinkInterval = 500
        Me.ledAlarm_HitterSSR_CH4.Label = "CH4"
        Me.ledAlarm_HitterSSR_CH4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterSSR_CH4.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterSSR_CH4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterSSR_CH4.Location = New System.Drawing.Point(16, 148)
        Me.ledAlarm_HitterSSR_CH4.Name = "ledAlarm_HitterSSR_CH4"
        Me.ledAlarm_HitterSSR_CH4.Renderer = Nothing
        Me.ledAlarm_HitterSSR_CH4.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterSSR_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterSSR_CH4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterSSR_CH4.TabIndex = 4
        '
        'ledAlarm_HitterSSR_CH3
        '
        Me.ledAlarm_HitterSSR_CH3.AutoSize = True
        Me.ledAlarm_HitterSSR_CH3.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterSSR_CH3.BlinkInterval = 500
        Me.ledAlarm_HitterSSR_CH3.Label = "CH3"
        Me.ledAlarm_HitterSSR_CH3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterSSR_CH3.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterSSR_CH3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterSSR_CH3.Location = New System.Drawing.Point(16, 116)
        Me.ledAlarm_HitterSSR_CH3.Name = "ledAlarm_HitterSSR_CH3"
        Me.ledAlarm_HitterSSR_CH3.Renderer = Nothing
        Me.ledAlarm_HitterSSR_CH3.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterSSR_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterSSR_CH3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterSSR_CH3.TabIndex = 3
        '
        'ledAlarm_HitterSSR_CH2
        '
        Me.ledAlarm_HitterSSR_CH2.AutoSize = True
        Me.ledAlarm_HitterSSR_CH2.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterSSR_CH2.BlinkInterval = 500
        Me.ledAlarm_HitterSSR_CH2.Label = "CH2"
        Me.ledAlarm_HitterSSR_CH2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterSSR_CH2.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterSSR_CH2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterSSR_CH2.Location = New System.Drawing.Point(16, 84)
        Me.ledAlarm_HitterSSR_CH2.Name = "ledAlarm_HitterSSR_CH2"
        Me.ledAlarm_HitterSSR_CH2.Renderer = Nothing
        Me.ledAlarm_HitterSSR_CH2.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterSSR_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterSSR_CH2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterSSR_CH2.TabIndex = 2
        '
        'ledAlarm_HitterSSR_CH1
        '
        Me.ledAlarm_HitterSSR_CH1.AutoSize = True
        Me.ledAlarm_HitterSSR_CH1.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterSSR_CH1.BlinkInterval = 500
        Me.ledAlarm_HitterSSR_CH1.Label = "CH1"
        Me.ledAlarm_HitterSSR_CH1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterSSR_CH1.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterSSR_CH1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterSSR_CH1.Location = New System.Drawing.Point(16, 52)
        Me.ledAlarm_HitterSSR_CH1.Name = "ledAlarm_HitterSSR_CH1"
        Me.ledAlarm_HitterSSR_CH1.Renderer = Nothing
        Me.ledAlarm_HitterSSR_CH1.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterSSR_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterSSR_CH1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterSSR_CH1.TabIndex = 1
        '
        'ledAlarm_HitterSSR_No_Error
        '
        Me.ledAlarm_HitterSSR_No_Error.AutoSize = True
        Me.ledAlarm_HitterSSR_No_Error.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterSSR_No_Error.BlinkInterval = 500
        Me.ledAlarm_HitterSSR_No_Error.Label = "No Error"
        Me.ledAlarm_HitterSSR_No_Error.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterSSR_No_Error.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterSSR_No_Error.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterSSR_No_Error.Location = New System.Drawing.Point(16, 20)
        Me.ledAlarm_HitterSSR_No_Error.Name = "ledAlarm_HitterSSR_No_Error"
        Me.ledAlarm_HitterSSR_No_Error.Renderer = Nothing
        Me.ledAlarm_HitterSSR_No_Error.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterSSR_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterSSR_No_Error.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterSSR_No_Error.TabIndex = 0
        '
        'GroupBox29
        '
        Me.GroupBox29.Controls.Add(Me.ledAlarm_HitterEOCR_CH9)
        Me.GroupBox29.Controls.Add(Me.ledAlarm_HitterEOCR_CH8)
        Me.GroupBox29.Controls.Add(Me.ledAlarm_HitterEOCR_CH7)
        Me.GroupBox29.Controls.Add(Me.ledAlarm_HitterEOCR_CH6)
        Me.GroupBox29.Controls.Add(Me.ledAlarm_HitterEOCR_CH5)
        Me.GroupBox29.Controls.Add(Me.ledAlarm_HitterEOCR_CH4)
        Me.GroupBox29.Controls.Add(Me.ledAlarm_HitterEOCR_CH3)
        Me.GroupBox29.Controls.Add(Me.ledAlarm_HitterEOCR_CH2)
        Me.GroupBox29.Controls.Add(Me.ledAlarm_HitterEOCR_CH1)
        Me.GroupBox29.Controls.Add(Me.ledAlarm_HitterEOCR_No_Error)
        Me.GroupBox29.Location = New System.Drawing.Point(619, 12)
        Me.GroupBox29.Name = "GroupBox29"
        Me.GroupBox29.Size = New System.Drawing.Size(141, 348)
        Me.GroupBox29.TabIndex = 60
        Me.GroupBox29.TabStop = False
        Me.GroupBox29.Text = "히터 EOCR"
        Me.GroupBox29.Visible = False
        '
        'ledAlarm_HitterEOCR_CH9
        '
        Me.ledAlarm_HitterEOCR_CH9.AutoSize = True
        Me.ledAlarm_HitterEOCR_CH9.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterEOCR_CH9.BlinkInterval = 500
        Me.ledAlarm_HitterEOCR_CH9.Label = "CH9"
        Me.ledAlarm_HitterEOCR_CH9.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterEOCR_CH9.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterEOCR_CH9.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterEOCR_CH9.Location = New System.Drawing.Point(16, 308)
        Me.ledAlarm_HitterEOCR_CH9.Name = "ledAlarm_HitterEOCR_CH9"
        Me.ledAlarm_HitterEOCR_CH9.Renderer = Nothing
        Me.ledAlarm_HitterEOCR_CH9.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterEOCR_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterEOCR_CH9.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterEOCR_CH9.TabIndex = 9
        '
        'ledAlarm_HitterEOCR_CH8
        '
        Me.ledAlarm_HitterEOCR_CH8.AutoSize = True
        Me.ledAlarm_HitterEOCR_CH8.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterEOCR_CH8.BlinkInterval = 500
        Me.ledAlarm_HitterEOCR_CH8.Label = "CH8"
        Me.ledAlarm_HitterEOCR_CH8.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterEOCR_CH8.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterEOCR_CH8.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterEOCR_CH8.Location = New System.Drawing.Point(16, 276)
        Me.ledAlarm_HitterEOCR_CH8.Name = "ledAlarm_HitterEOCR_CH8"
        Me.ledAlarm_HitterEOCR_CH8.Renderer = Nothing
        Me.ledAlarm_HitterEOCR_CH8.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterEOCR_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterEOCR_CH8.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterEOCR_CH8.TabIndex = 8
        '
        'ledAlarm_HitterEOCR_CH7
        '
        Me.ledAlarm_HitterEOCR_CH7.AutoSize = True
        Me.ledAlarm_HitterEOCR_CH7.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterEOCR_CH7.BlinkInterval = 500
        Me.ledAlarm_HitterEOCR_CH7.Label = "CH7"
        Me.ledAlarm_HitterEOCR_CH7.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterEOCR_CH7.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterEOCR_CH7.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterEOCR_CH7.Location = New System.Drawing.Point(16, 244)
        Me.ledAlarm_HitterEOCR_CH7.Name = "ledAlarm_HitterEOCR_CH7"
        Me.ledAlarm_HitterEOCR_CH7.Renderer = Nothing
        Me.ledAlarm_HitterEOCR_CH7.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterEOCR_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterEOCR_CH7.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterEOCR_CH7.TabIndex = 7
        '
        'ledAlarm_HitterEOCR_CH6
        '
        Me.ledAlarm_HitterEOCR_CH6.AutoSize = True
        Me.ledAlarm_HitterEOCR_CH6.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterEOCR_CH6.BlinkInterval = 500
        Me.ledAlarm_HitterEOCR_CH6.Label = "CH6"
        Me.ledAlarm_HitterEOCR_CH6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterEOCR_CH6.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterEOCR_CH6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterEOCR_CH6.Location = New System.Drawing.Point(16, 212)
        Me.ledAlarm_HitterEOCR_CH6.Name = "ledAlarm_HitterEOCR_CH6"
        Me.ledAlarm_HitterEOCR_CH6.Renderer = Nothing
        Me.ledAlarm_HitterEOCR_CH6.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterEOCR_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterEOCR_CH6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterEOCR_CH6.TabIndex = 6
        '
        'ledAlarm_HitterEOCR_CH5
        '
        Me.ledAlarm_HitterEOCR_CH5.AutoSize = True
        Me.ledAlarm_HitterEOCR_CH5.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterEOCR_CH5.BlinkInterval = 500
        Me.ledAlarm_HitterEOCR_CH5.Label = "CH5"
        Me.ledAlarm_HitterEOCR_CH5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterEOCR_CH5.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterEOCR_CH5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterEOCR_CH5.Location = New System.Drawing.Point(16, 180)
        Me.ledAlarm_HitterEOCR_CH5.Name = "ledAlarm_HitterEOCR_CH5"
        Me.ledAlarm_HitterEOCR_CH5.Renderer = Nothing
        Me.ledAlarm_HitterEOCR_CH5.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterEOCR_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterEOCR_CH5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterEOCR_CH5.TabIndex = 5
        '
        'ledAlarm_HitterEOCR_CH4
        '
        Me.ledAlarm_HitterEOCR_CH4.AutoSize = True
        Me.ledAlarm_HitterEOCR_CH4.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterEOCR_CH4.BlinkInterval = 500
        Me.ledAlarm_HitterEOCR_CH4.Label = "CH4"
        Me.ledAlarm_HitterEOCR_CH4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterEOCR_CH4.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterEOCR_CH4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterEOCR_CH4.Location = New System.Drawing.Point(16, 148)
        Me.ledAlarm_HitterEOCR_CH4.Name = "ledAlarm_HitterEOCR_CH4"
        Me.ledAlarm_HitterEOCR_CH4.Renderer = Nothing
        Me.ledAlarm_HitterEOCR_CH4.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterEOCR_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterEOCR_CH4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterEOCR_CH4.TabIndex = 4
        '
        'ledAlarm_HitterEOCR_CH3
        '
        Me.ledAlarm_HitterEOCR_CH3.AutoSize = True
        Me.ledAlarm_HitterEOCR_CH3.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterEOCR_CH3.BlinkInterval = 500
        Me.ledAlarm_HitterEOCR_CH3.Label = "CH3"
        Me.ledAlarm_HitterEOCR_CH3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterEOCR_CH3.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterEOCR_CH3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterEOCR_CH3.Location = New System.Drawing.Point(16, 116)
        Me.ledAlarm_HitterEOCR_CH3.Name = "ledAlarm_HitterEOCR_CH3"
        Me.ledAlarm_HitterEOCR_CH3.Renderer = Nothing
        Me.ledAlarm_HitterEOCR_CH3.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterEOCR_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterEOCR_CH3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterEOCR_CH3.TabIndex = 3
        '
        'ledAlarm_HitterEOCR_CH2
        '
        Me.ledAlarm_HitterEOCR_CH2.AutoSize = True
        Me.ledAlarm_HitterEOCR_CH2.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterEOCR_CH2.BlinkInterval = 500
        Me.ledAlarm_HitterEOCR_CH2.Label = "CH2"
        Me.ledAlarm_HitterEOCR_CH2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterEOCR_CH2.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterEOCR_CH2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterEOCR_CH2.Location = New System.Drawing.Point(16, 84)
        Me.ledAlarm_HitterEOCR_CH2.Name = "ledAlarm_HitterEOCR_CH2"
        Me.ledAlarm_HitterEOCR_CH2.Renderer = Nothing
        Me.ledAlarm_HitterEOCR_CH2.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterEOCR_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterEOCR_CH2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterEOCR_CH2.TabIndex = 2
        '
        'ledAlarm_HitterEOCR_CH1
        '
        Me.ledAlarm_HitterEOCR_CH1.AutoSize = True
        Me.ledAlarm_HitterEOCR_CH1.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterEOCR_CH1.BlinkInterval = 500
        Me.ledAlarm_HitterEOCR_CH1.Label = "CH1"
        Me.ledAlarm_HitterEOCR_CH1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterEOCR_CH1.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterEOCR_CH1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterEOCR_CH1.Location = New System.Drawing.Point(16, 52)
        Me.ledAlarm_HitterEOCR_CH1.Name = "ledAlarm_HitterEOCR_CH1"
        Me.ledAlarm_HitterEOCR_CH1.Renderer = Nothing
        Me.ledAlarm_HitterEOCR_CH1.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterEOCR_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterEOCR_CH1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterEOCR_CH1.TabIndex = 1
        '
        'ledAlarm_HitterEOCR_No_Error
        '
        Me.ledAlarm_HitterEOCR_No_Error.AutoSize = True
        Me.ledAlarm_HitterEOCR_No_Error.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterEOCR_No_Error.BlinkInterval = 500
        Me.ledAlarm_HitterEOCR_No_Error.Label = "No Error"
        Me.ledAlarm_HitterEOCR_No_Error.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterEOCR_No_Error.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterEOCR_No_Error.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterEOCR_No_Error.Location = New System.Drawing.Point(16, 20)
        Me.ledAlarm_HitterEOCR_No_Error.Name = "ledAlarm_HitterEOCR_No_Error"
        Me.ledAlarm_HitterEOCR_No_Error.Renderer = Nothing
        Me.ledAlarm_HitterEOCR_No_Error.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_HitterEOCR_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterEOCR_No_Error.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterEOCR_No_Error.TabIndex = 0
        '
        'GroupBox26
        '
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_EMS2)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_MC2)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_MC1)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_Safety2)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_Safety1)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_TempHeavy)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_SMOKE)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_TempLight)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_EMS)
        Me.GroupBox26.Controls.Add(Me.ledEMSAlarm_NO_Error)
        Me.GroupBox26.Location = New System.Drawing.Point(7, 381)
        Me.GroupBox26.Name = "GroupBox26"
        Me.GroupBox26.Size = New System.Drawing.Size(418, 204)
        Me.GroupBox26.TabIndex = 59
        Me.GroupBox26.TabStop = False
        Me.GroupBox26.Text = "EMS Alarm"
        '
        'ledEMSAlarm_MC2
        '
        Me.ledEMSAlarm_MC2.AutoSize = True
        Me.ledEMSAlarm_MC2.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_MC2.BlinkInterval = 500
        Me.ledEMSAlarm_MC2.Label = "구동부 메인 M/C2 POWER OFF"
        Me.ledEMSAlarm_MC2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_MC2.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_MC2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_MC2.Location = New System.Drawing.Point(218, 153)
        Me.ledEMSAlarm_MC2.Name = "ledEMSAlarm_MC2"
        Me.ledEMSAlarm_MC2.Renderer = Nothing
        Me.ledEMSAlarm_MC2.Size = New System.Drawing.Size(194, 32)
        Me.ledEMSAlarm_MC2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_MC2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_MC2.TabIndex = 8
        '
        'ledEMSAlarm_MC1
        '
        Me.ledEMSAlarm_MC1.AutoSize = True
        Me.ledEMSAlarm_MC1.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_MC1.BlinkInterval = 500
        Me.ledEMSAlarm_MC1.Label = "구동부 메인 M/C1 POWER OFF"
        Me.ledEMSAlarm_MC1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_MC1.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_MC1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_MC1.Location = New System.Drawing.Point(218, 120)
        Me.ledEMSAlarm_MC1.Name = "ledEMSAlarm_MC1"
        Me.ledEMSAlarm_MC1.Renderer = Nothing
        Me.ledEMSAlarm_MC1.Size = New System.Drawing.Size(194, 32)
        Me.ledEMSAlarm_MC1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_MC1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_MC1.TabIndex = 7
        '
        'ledEMSAlarm_Safety2
        '
        Me.ledEMSAlarm_Safety2.AutoSize = True
        Me.ledEMSAlarm_Safety2.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_Safety2.BlinkInterval = 500
        Me.ledEMSAlarm_Safety2.Label = "세이프티 컨트롤러-2 알람"
        Me.ledEMSAlarm_Safety2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_Safety2.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_Safety2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_Safety2.Location = New System.Drawing.Point(218, 82)
        Me.ledEMSAlarm_Safety2.Name = "ledEMSAlarm_Safety2"
        Me.ledEMSAlarm_Safety2.Renderer = Nothing
        Me.ledEMSAlarm_Safety2.Size = New System.Drawing.Size(194, 32)
        Me.ledEMSAlarm_Safety2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_Safety2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_Safety2.TabIndex = 6
        '
        'ledEMSAlarm_Safety1
        '
        Me.ledEMSAlarm_Safety1.AutoSize = True
        Me.ledEMSAlarm_Safety1.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_Safety1.BlinkInterval = 500
        Me.ledEMSAlarm_Safety1.Label = "세이프티 컨트롤러-1 알람"
        Me.ledEMSAlarm_Safety1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_Safety1.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_Safety1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_Safety1.Location = New System.Drawing.Point(218, 49)
        Me.ledEMSAlarm_Safety1.Name = "ledEMSAlarm_Safety1"
        Me.ledEMSAlarm_Safety1.Renderer = Nothing
        Me.ledEMSAlarm_Safety1.Size = New System.Drawing.Size(194, 32)
        Me.ledEMSAlarm_Safety1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_Safety1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_Safety1.TabIndex = 5
        '
        'ledEMSAlarm_TempHeavy
        '
        Me.ledEMSAlarm_TempHeavy.AutoSize = True
        Me.ledEMSAlarm_TempHeavy.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_TempHeavy.BlinkInterval = 500
        Me.ledEMSAlarm_TempHeavy.Label = "컨트롤박스 내부 온도 알람2"
        Me.ledEMSAlarm_TempHeavy.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_TempHeavy.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_TempHeavy.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_TempHeavy.Location = New System.Drawing.Point(11, 119)
        Me.ledEMSAlarm_TempHeavy.Name = "ledEMSAlarm_TempHeavy"
        Me.ledEMSAlarm_TempHeavy.Renderer = Nothing
        Me.ledEMSAlarm_TempHeavy.Size = New System.Drawing.Size(194, 32)
        Me.ledEMSAlarm_TempHeavy.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_TempHeavy.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_TempHeavy.TabIndex = 4
        '
        'ledEMSAlarm_SMOKE
        '
        Me.ledEMSAlarm_SMOKE.AutoSize = True
        Me.ledEMSAlarm_SMOKE.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_SMOKE.BlinkInterval = 500
        Me.ledEMSAlarm_SMOKE.Label = "컨트롤박스 연기감지 센서 알람"
        Me.ledEMSAlarm_SMOKE.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_SMOKE.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_SMOKE.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_SMOKE.Location = New System.Drawing.Point(11, 153)
        Me.ledEMSAlarm_SMOKE.Name = "ledEMSAlarm_SMOKE"
        Me.ledEMSAlarm_SMOKE.Renderer = Nothing
        Me.ledEMSAlarm_SMOKE.Size = New System.Drawing.Size(212, 32)
        Me.ledEMSAlarm_SMOKE.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_SMOKE.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_SMOKE.TabIndex = 3
        '
        'ledEMSAlarm_TempLight
        '
        Me.ledEMSAlarm_TempLight.AutoSize = True
        Me.ledEMSAlarm_TempLight.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_TempLight.BlinkInterval = 500
        Me.ledEMSAlarm_TempLight.Label = "컨트롤박스 내부 온도 알람1"
        Me.ledEMSAlarm_TempLight.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_TempLight.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_TempLight.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_TempLight.Location = New System.Drawing.Point(11, 86)
        Me.ledEMSAlarm_TempLight.Name = "ledEMSAlarm_TempLight"
        Me.ledEMSAlarm_TempLight.Renderer = Nothing
        Me.ledEMSAlarm_TempLight.Size = New System.Drawing.Size(194, 32)
        Me.ledEMSAlarm_TempLight.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_TempLight.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_TempLight.TabIndex = 2
        '
        'ledEMSAlarm_EMS
        '
        Me.ledEMSAlarm_EMS.AutoSize = True
        Me.ledEMSAlarm_EMS.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_EMS.BlinkInterval = 500
        Me.ledEMSAlarm_EMS.Label = "긴급정지 알람 (EMS -1)"
        Me.ledEMSAlarm_EMS.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_EMS.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_EMS.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_EMS.Location = New System.Drawing.Point(11, 48)
        Me.ledEMSAlarm_EMS.Name = "ledEMSAlarm_EMS"
        Me.ledEMSAlarm_EMS.Renderer = Nothing
        Me.ledEMSAlarm_EMS.Size = New System.Drawing.Size(194, 32)
        Me.ledEMSAlarm_EMS.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_EMS.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_EMS.TabIndex = 1
        '
        'ledEMSAlarm_NO_Error
        '
        Me.ledEMSAlarm_NO_Error.AutoSize = True
        Me.ledEMSAlarm_NO_Error.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_NO_Error.BlinkInterval = 500
        Me.ledEMSAlarm_NO_Error.Label = "None"
        Me.ledEMSAlarm_NO_Error.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_NO_Error.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_NO_Error.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_NO_Error.Location = New System.Drawing.Point(11, 16)
        Me.ledEMSAlarm_NO_Error.Name = "ledEMSAlarm_NO_Error"
        Me.ledEMSAlarm_NO_Error.Renderer = Nothing
        Me.ledEMSAlarm_NO_Error.Size = New System.Drawing.Size(75, 32)
        Me.ledEMSAlarm_NO_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_NO_Error.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_NO_Error.TabIndex = 0
        '
        'GroupBox28
        '
        Me.GroupBox28.Controls.Add(Me.ledDoorAlarm_Door8)
        Me.GroupBox28.Controls.Add(Me.ledDoorAlarm_Door7)
        Me.GroupBox28.Controls.Add(Me.ledDoorAlarm_Door6)
        Me.GroupBox28.Controls.Add(Me.ledDoorAlarm_Door5)
        Me.GroupBox28.Controls.Add(Me.ledDoorAlarm_Door4)
        Me.GroupBox28.Controls.Add(Me.ledDoorAlarm_Door3)
        Me.GroupBox28.Controls.Add(Me.ledDoorAlarm_Door2)
        Me.GroupBox28.Controls.Add(Me.ledDoorAlarm_Door1)
        Me.GroupBox28.Controls.Add(Me.ledDoorAlarm_Safety_Door)
        Me.GroupBox28.Controls.Add(Me.ledDoorAlarm_NoError)
        Me.GroupBox28.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox28.Name = "GroupBox28"
        Me.GroupBox28.Size = New System.Drawing.Size(229, 356)
        Me.GroupBox28.TabIndex = 58
        Me.GroupBox28.TabStop = False
        Me.GroupBox28.Text = "Door Alarm"
        '
        'ledDoorAlarm_Door8
        '
        Me.ledDoorAlarm_Door8.AutoSize = True
        Me.ledDoorAlarm_Door8.BackColor = System.Drawing.Color.Transparent
        Me.ledDoorAlarm_Door8.BlinkInterval = 500
        Me.ledDoorAlarm_Door8.Label = "암실 세이프티 도어 개방8"
        Me.ledDoorAlarm_Door8.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledDoorAlarm_Door8.LedColor = System.Drawing.Color.Red
        Me.ledDoorAlarm_Door8.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledDoorAlarm_Door8.Location = New System.Drawing.Point(11, 309)
        Me.ledDoorAlarm_Door8.Name = "ledDoorAlarm_Door8"
        Me.ledDoorAlarm_Door8.Renderer = Nothing
        Me.ledDoorAlarm_Door8.Size = New System.Drawing.Size(217, 32)
        Me.ledDoorAlarm_Door8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledDoorAlarm_Door8.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledDoorAlarm_Door8.TabIndex = 9
        '
        'ledDoorAlarm_Door7
        '
        Me.ledDoorAlarm_Door7.AutoSize = True
        Me.ledDoorAlarm_Door7.BackColor = System.Drawing.Color.Transparent
        Me.ledDoorAlarm_Door7.BlinkInterval = 500
        Me.ledDoorAlarm_Door7.Label = "암실 세이프티 도어 개방7"
        Me.ledDoorAlarm_Door7.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledDoorAlarm_Door7.LedColor = System.Drawing.Color.Red
        Me.ledDoorAlarm_Door7.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledDoorAlarm_Door7.Location = New System.Drawing.Point(11, 277)
        Me.ledDoorAlarm_Door7.Name = "ledDoorAlarm_Door7"
        Me.ledDoorAlarm_Door7.Renderer = Nothing
        Me.ledDoorAlarm_Door7.Size = New System.Drawing.Size(217, 32)
        Me.ledDoorAlarm_Door7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledDoorAlarm_Door7.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledDoorAlarm_Door7.TabIndex = 8
        '
        'ledDoorAlarm_Door6
        '
        Me.ledDoorAlarm_Door6.AutoSize = True
        Me.ledDoorAlarm_Door6.BackColor = System.Drawing.Color.Transparent
        Me.ledDoorAlarm_Door6.BlinkInterval = 500
        Me.ledDoorAlarm_Door6.Label = "암실 세이프티 도어 개방6"
        Me.ledDoorAlarm_Door6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledDoorAlarm_Door6.LedColor = System.Drawing.Color.Red
        Me.ledDoorAlarm_Door6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledDoorAlarm_Door6.Location = New System.Drawing.Point(11, 245)
        Me.ledDoorAlarm_Door6.Name = "ledDoorAlarm_Door6"
        Me.ledDoorAlarm_Door6.Renderer = Nothing
        Me.ledDoorAlarm_Door6.Size = New System.Drawing.Size(194, 32)
        Me.ledDoorAlarm_Door6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledDoorAlarm_Door6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledDoorAlarm_Door6.TabIndex = 7
        '
        'ledDoorAlarm_Door5
        '
        Me.ledDoorAlarm_Door5.AutoSize = True
        Me.ledDoorAlarm_Door5.BackColor = System.Drawing.Color.Transparent
        Me.ledDoorAlarm_Door5.BlinkInterval = 500
        Me.ledDoorAlarm_Door5.Label = "암실 세이프티 도어 개방5"
        Me.ledDoorAlarm_Door5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledDoorAlarm_Door5.LedColor = System.Drawing.Color.Red
        Me.ledDoorAlarm_Door5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledDoorAlarm_Door5.Location = New System.Drawing.Point(11, 212)
        Me.ledDoorAlarm_Door5.Name = "ledDoorAlarm_Door5"
        Me.ledDoorAlarm_Door5.Renderer = Nothing
        Me.ledDoorAlarm_Door5.Size = New System.Drawing.Size(217, 32)
        Me.ledDoorAlarm_Door5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledDoorAlarm_Door5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledDoorAlarm_Door5.TabIndex = 6
        '
        'ledDoorAlarm_Door4
        '
        Me.ledDoorAlarm_Door4.AutoSize = True
        Me.ledDoorAlarm_Door4.BackColor = System.Drawing.Color.Transparent
        Me.ledDoorAlarm_Door4.BlinkInterval = 500
        Me.ledDoorAlarm_Door4.Label = "암실 세이프티 도어 개방4"
        Me.ledDoorAlarm_Door4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledDoorAlarm_Door4.LedColor = System.Drawing.Color.Red
        Me.ledDoorAlarm_Door4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledDoorAlarm_Door4.Location = New System.Drawing.Point(11, 180)
        Me.ledDoorAlarm_Door4.Name = "ledDoorAlarm_Door4"
        Me.ledDoorAlarm_Door4.Renderer = Nothing
        Me.ledDoorAlarm_Door4.Size = New System.Drawing.Size(194, 32)
        Me.ledDoorAlarm_Door4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledDoorAlarm_Door4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledDoorAlarm_Door4.TabIndex = 5
        '
        'ledDoorAlarm_Door3
        '
        Me.ledDoorAlarm_Door3.AutoSize = True
        Me.ledDoorAlarm_Door3.BackColor = System.Drawing.Color.Transparent
        Me.ledDoorAlarm_Door3.BlinkInterval = 500
        Me.ledDoorAlarm_Door3.Label = "암실 세이프티 도어 개방3"
        Me.ledDoorAlarm_Door3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledDoorAlarm_Door3.LedColor = System.Drawing.Color.Red
        Me.ledDoorAlarm_Door3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledDoorAlarm_Door3.Location = New System.Drawing.Point(11, 148)
        Me.ledDoorAlarm_Door3.Name = "ledDoorAlarm_Door3"
        Me.ledDoorAlarm_Door3.Renderer = Nothing
        Me.ledDoorAlarm_Door3.Size = New System.Drawing.Size(200, 32)
        Me.ledDoorAlarm_Door3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledDoorAlarm_Door3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledDoorAlarm_Door3.TabIndex = 4
        '
        'ledDoorAlarm_Door2
        '
        Me.ledDoorAlarm_Door2.AutoSize = True
        Me.ledDoorAlarm_Door2.BackColor = System.Drawing.Color.Transparent
        Me.ledDoorAlarm_Door2.BlinkInterval = 500
        Me.ledDoorAlarm_Door2.Label = "암실 세이프티 도어 개방2"
        Me.ledDoorAlarm_Door2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledDoorAlarm_Door2.LedColor = System.Drawing.Color.Red
        Me.ledDoorAlarm_Door2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledDoorAlarm_Door2.Location = New System.Drawing.Point(11, 116)
        Me.ledDoorAlarm_Door2.Name = "ledDoorAlarm_Door2"
        Me.ledDoorAlarm_Door2.Renderer = Nothing
        Me.ledDoorAlarm_Door2.Size = New System.Drawing.Size(194, 32)
        Me.ledDoorAlarm_Door2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledDoorAlarm_Door2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledDoorAlarm_Door2.TabIndex = 3
        '
        'ledDoorAlarm_Door1
        '
        Me.ledDoorAlarm_Door1.AutoSize = True
        Me.ledDoorAlarm_Door1.BackColor = System.Drawing.Color.Transparent
        Me.ledDoorAlarm_Door1.BlinkInterval = 500
        Me.ledDoorAlarm_Door1.Label = "암실 세이프티 도어 개방1"
        Me.ledDoorAlarm_Door1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledDoorAlarm_Door1.LedColor = System.Drawing.Color.Red
        Me.ledDoorAlarm_Door1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledDoorAlarm_Door1.Location = New System.Drawing.Point(11, 84)
        Me.ledDoorAlarm_Door1.Name = "ledDoorAlarm_Door1"
        Me.ledDoorAlarm_Door1.Renderer = Nothing
        Me.ledDoorAlarm_Door1.Size = New System.Drawing.Size(178, 32)
        Me.ledDoorAlarm_Door1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledDoorAlarm_Door1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledDoorAlarm_Door1.TabIndex = 2
        '
        'ledDoorAlarm_Safety_Door
        '
        Me.ledDoorAlarm_Safety_Door.AutoSize = True
        Me.ledDoorAlarm_Safety_Door.BackColor = System.Drawing.Color.Transparent
        Me.ledDoorAlarm_Safety_Door.BlinkInterval = 500
        Me.ledDoorAlarm_Safety_Door.Label = "세이프티 도어 루프 에러"
        Me.ledDoorAlarm_Safety_Door.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledDoorAlarm_Safety_Door.LedColor = System.Drawing.Color.Red
        Me.ledDoorAlarm_Safety_Door.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledDoorAlarm_Safety_Door.Location = New System.Drawing.Point(11, 52)
        Me.ledDoorAlarm_Safety_Door.Name = "ledDoorAlarm_Safety_Door"
        Me.ledDoorAlarm_Safety_Door.Renderer = Nothing
        Me.ledDoorAlarm_Safety_Door.Size = New System.Drawing.Size(194, 32)
        Me.ledDoorAlarm_Safety_Door.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledDoorAlarm_Safety_Door.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledDoorAlarm_Safety_Door.TabIndex = 1
        '
        'ledDoorAlarm_NoError
        '
        Me.ledDoorAlarm_NoError.AutoSize = True
        Me.ledDoorAlarm_NoError.BackColor = System.Drawing.Color.Transparent
        Me.ledDoorAlarm_NoError.BlinkInterval = 500
        Me.ledDoorAlarm_NoError.Label = "None"
        Me.ledDoorAlarm_NoError.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledDoorAlarm_NoError.LedColor = System.Drawing.Color.Red
        Me.ledDoorAlarm_NoError.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledDoorAlarm_NoError.Location = New System.Drawing.Point(11, 20)
        Me.ledDoorAlarm_NoError.Name = "ledDoorAlarm_NoError"
        Me.ledDoorAlarm_NoError.Renderer = Nothing
        Me.ledDoorAlarm_NoError.Size = New System.Drawing.Size(75, 32)
        Me.ledDoorAlarm_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledDoorAlarm_NoError.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledDoorAlarm_NoError.TabIndex = 0
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.ledAlarm_Hitter_CH9)
        Me.GroupBox10.Controls.Add(Me.ledAlarm_Hitter_CH8)
        Me.GroupBox10.Controls.Add(Me.ledAlarm_Hitter_CH7)
        Me.GroupBox10.Controls.Add(Me.ledAlarm_Hitter_CH6)
        Me.GroupBox10.Controls.Add(Me.ledAlarm_Hitter_CH5)
        Me.GroupBox10.Controls.Add(Me.ledAlarm_Hitter_CH4)
        Me.GroupBox10.Controls.Add(Me.ledAlarm_Hitter_CH3)
        Me.GroupBox10.Controls.Add(Me.ledAlarm_Hitter_CH2)
        Me.GroupBox10.Controls.Add(Me.ledAlarm_Hitter_CH1)
        Me.GroupBox10.Controls.Add(Me.ledAlarm_Hitter_No_Error)
        Me.GroupBox10.Location = New System.Drawing.Point(472, 12)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(141, 348)
        Me.GroupBox10.TabIndex = 10
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "히터 온도 이상"
        Me.GroupBox10.Visible = False
        '
        'ledAlarm_Hitter_CH9
        '
        Me.ledAlarm_Hitter_CH9.AutoSize = True
        Me.ledAlarm_Hitter_CH9.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Hitter_CH9.BlinkInterval = 500
        Me.ledAlarm_Hitter_CH9.Label = "CH9"
        Me.ledAlarm_Hitter_CH9.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Hitter_CH9.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Hitter_CH9.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Hitter_CH9.Location = New System.Drawing.Point(16, 308)
        Me.ledAlarm_Hitter_CH9.Name = "ledAlarm_Hitter_CH9"
        Me.ledAlarm_Hitter_CH9.Renderer = Nothing
        Me.ledAlarm_Hitter_CH9.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_Hitter_CH9.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Hitter_CH9.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Hitter_CH9.TabIndex = 9
        '
        'ledAlarm_Hitter_CH8
        '
        Me.ledAlarm_Hitter_CH8.AutoSize = True
        Me.ledAlarm_Hitter_CH8.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Hitter_CH8.BlinkInterval = 500
        Me.ledAlarm_Hitter_CH8.Label = "CH8"
        Me.ledAlarm_Hitter_CH8.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Hitter_CH8.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Hitter_CH8.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Hitter_CH8.Location = New System.Drawing.Point(16, 276)
        Me.ledAlarm_Hitter_CH8.Name = "ledAlarm_Hitter_CH8"
        Me.ledAlarm_Hitter_CH8.Renderer = Nothing
        Me.ledAlarm_Hitter_CH8.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_Hitter_CH8.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Hitter_CH8.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Hitter_CH8.TabIndex = 8
        '
        'ledAlarm_Hitter_CH7
        '
        Me.ledAlarm_Hitter_CH7.AutoSize = True
        Me.ledAlarm_Hitter_CH7.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Hitter_CH7.BlinkInterval = 500
        Me.ledAlarm_Hitter_CH7.Label = "CH7"
        Me.ledAlarm_Hitter_CH7.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Hitter_CH7.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Hitter_CH7.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Hitter_CH7.Location = New System.Drawing.Point(16, 244)
        Me.ledAlarm_Hitter_CH7.Name = "ledAlarm_Hitter_CH7"
        Me.ledAlarm_Hitter_CH7.Renderer = Nothing
        Me.ledAlarm_Hitter_CH7.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_Hitter_CH7.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Hitter_CH7.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Hitter_CH7.TabIndex = 7
        '
        'ledAlarm_Hitter_CH6
        '
        Me.ledAlarm_Hitter_CH6.AutoSize = True
        Me.ledAlarm_Hitter_CH6.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Hitter_CH6.BlinkInterval = 500
        Me.ledAlarm_Hitter_CH6.Label = "CH6"
        Me.ledAlarm_Hitter_CH6.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Hitter_CH6.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Hitter_CH6.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Hitter_CH6.Location = New System.Drawing.Point(16, 212)
        Me.ledAlarm_Hitter_CH6.Name = "ledAlarm_Hitter_CH6"
        Me.ledAlarm_Hitter_CH6.Renderer = Nothing
        Me.ledAlarm_Hitter_CH6.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_Hitter_CH6.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Hitter_CH6.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Hitter_CH6.TabIndex = 6
        '
        'ledAlarm_Hitter_CH5
        '
        Me.ledAlarm_Hitter_CH5.AutoSize = True
        Me.ledAlarm_Hitter_CH5.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Hitter_CH5.BlinkInterval = 500
        Me.ledAlarm_Hitter_CH5.Label = "CH5"
        Me.ledAlarm_Hitter_CH5.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Hitter_CH5.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Hitter_CH5.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Hitter_CH5.Location = New System.Drawing.Point(16, 180)
        Me.ledAlarm_Hitter_CH5.Name = "ledAlarm_Hitter_CH5"
        Me.ledAlarm_Hitter_CH5.Renderer = Nothing
        Me.ledAlarm_Hitter_CH5.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_Hitter_CH5.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Hitter_CH5.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Hitter_CH5.TabIndex = 5
        '
        'ledAlarm_Hitter_CH4
        '
        Me.ledAlarm_Hitter_CH4.AutoSize = True
        Me.ledAlarm_Hitter_CH4.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Hitter_CH4.BlinkInterval = 500
        Me.ledAlarm_Hitter_CH4.Label = "CH4"
        Me.ledAlarm_Hitter_CH4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Hitter_CH4.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Hitter_CH4.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Hitter_CH4.Location = New System.Drawing.Point(16, 148)
        Me.ledAlarm_Hitter_CH4.Name = "ledAlarm_Hitter_CH4"
        Me.ledAlarm_Hitter_CH4.Renderer = Nothing
        Me.ledAlarm_Hitter_CH4.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_Hitter_CH4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Hitter_CH4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Hitter_CH4.TabIndex = 4
        '
        'ledAlarm_Hitter_CH3
        '
        Me.ledAlarm_Hitter_CH3.AutoSize = True
        Me.ledAlarm_Hitter_CH3.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Hitter_CH3.BlinkInterval = 500
        Me.ledAlarm_Hitter_CH3.Label = "CH3"
        Me.ledAlarm_Hitter_CH3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Hitter_CH3.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Hitter_CH3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Hitter_CH3.Location = New System.Drawing.Point(16, 116)
        Me.ledAlarm_Hitter_CH3.Name = "ledAlarm_Hitter_CH3"
        Me.ledAlarm_Hitter_CH3.Renderer = Nothing
        Me.ledAlarm_Hitter_CH3.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_Hitter_CH3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Hitter_CH3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Hitter_CH3.TabIndex = 3
        '
        'ledAlarm_Hitter_CH2
        '
        Me.ledAlarm_Hitter_CH2.AutoSize = True
        Me.ledAlarm_Hitter_CH2.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Hitter_CH2.BlinkInterval = 500
        Me.ledAlarm_Hitter_CH2.Label = "CH2"
        Me.ledAlarm_Hitter_CH2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Hitter_CH2.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Hitter_CH2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Hitter_CH2.Location = New System.Drawing.Point(16, 84)
        Me.ledAlarm_Hitter_CH2.Name = "ledAlarm_Hitter_CH2"
        Me.ledAlarm_Hitter_CH2.Renderer = Nothing
        Me.ledAlarm_Hitter_CH2.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_Hitter_CH2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Hitter_CH2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Hitter_CH2.TabIndex = 2
        '
        'ledAlarm_Hitter_CH1
        '
        Me.ledAlarm_Hitter_CH1.AutoSize = True
        Me.ledAlarm_Hitter_CH1.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Hitter_CH1.BlinkInterval = 500
        Me.ledAlarm_Hitter_CH1.Label = "CH1"
        Me.ledAlarm_Hitter_CH1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Hitter_CH1.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Hitter_CH1.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Hitter_CH1.Location = New System.Drawing.Point(16, 52)
        Me.ledAlarm_Hitter_CH1.Name = "ledAlarm_Hitter_CH1"
        Me.ledAlarm_Hitter_CH1.Renderer = Nothing
        Me.ledAlarm_Hitter_CH1.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_Hitter_CH1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Hitter_CH1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Hitter_CH1.TabIndex = 1
        '
        'ledAlarm_Hitter_No_Error
        '
        Me.ledAlarm_Hitter_No_Error.AutoSize = True
        Me.ledAlarm_Hitter_No_Error.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_Hitter_No_Error.BlinkInterval = 500
        Me.ledAlarm_Hitter_No_Error.Label = "No Error"
        Me.ledAlarm_Hitter_No_Error.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_Hitter_No_Error.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_Hitter_No_Error.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_Hitter_No_Error.Location = New System.Drawing.Point(16, 20)
        Me.ledAlarm_Hitter_No_Error.Name = "ledAlarm_Hitter_No_Error"
        Me.ledAlarm_Hitter_No_Error.Renderer = Nothing
        Me.ledAlarm_Hitter_No_Error.Size = New System.Drawing.Size(124, 30)
        Me.ledAlarm_Hitter_No_Error.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_Hitter_No_Error.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_Hitter_No_Error.TabIndex = 0
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.ledAxisAlarm_NoError)
        Me.GroupBox12.Controls.Add(Me.ledAxisAlarm_XAxis)
        Me.GroupBox12.Controls.Add(Me.ledAxisAlarm_ZAxis)
        Me.GroupBox12.Controls.Add(Me.ledAxisAlarm_Y2Axis)
        Me.GroupBox12.Controls.Add(Me.ledAxisAlarm_YAxis)
        Me.GroupBox12.Controls.Add(Me.ledAxisAlarm_THETA4Axis)
        Me.GroupBox12.Controls.Add(Me.ledAxisAlarm_THETA1Axis)
        Me.GroupBox12.Controls.Add(Me.ledAxisAlarm_THETA2Axis)
        Me.GroupBox12.Controls.Add(Me.ledAxisAlarm_THETA3Axis)
        Me.GroupBox12.Controls.Add(Me.ledAxisAlarm_ContactAxis)
        Me.GroupBox12.Controls.Add(Me.ledAxisAlarm_NONE2)
        Me.GroupBox12.Controls.Add(Me.ledAxisAlarm_NONE3)
        Me.GroupBox12.Controls.Add(Me.ledAxisAlarm_ALIGNAxis)
        Me.GroupBox12.Controls.Add(Me.ledAxisAlarm_STOPERAxis)
        Me.GroupBox12.Location = New System.Drawing.Point(241, 12)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(103, 284)
        Me.GroupBox12.TabIndex = 54
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Axis Alarm"
        '
        'ledAxisAlarm_NoError
        '
        Me.ledAxisAlarm_NoError.AutoSize = True
        Me.ledAxisAlarm_NoError.BackColor = System.Drawing.Color.Transparent
        Me.ledAxisAlarm_NoError.BlinkInterval = 500
        Me.ledAxisAlarm_NoError.Label = "No Error"
        Me.ledAxisAlarm_NoError.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAxisAlarm_NoError.LedColor = System.Drawing.Color.Red
        Me.ledAxisAlarm_NoError.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAxisAlarm_NoError.Location = New System.Drawing.Point(10, 20)
        Me.ledAxisAlarm_NoError.Name = "ledAxisAlarm_NoError"
        Me.ledAxisAlarm_NoError.Renderer = Nothing
        Me.ledAxisAlarm_NoError.Size = New System.Drawing.Size(86, 32)
        Me.ledAxisAlarm_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAxisAlarm_NoError.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAxisAlarm_NoError.TabIndex = 13
        '
        'ledAxisAlarm_XAxis
        '
        Me.ledAxisAlarm_XAxis.AutoSize = True
        Me.ledAxisAlarm_XAxis.BackColor = System.Drawing.Color.Transparent
        Me.ledAxisAlarm_XAxis.BlinkInterval = 500
        Me.ledAxisAlarm_XAxis.Label = "X"
        Me.ledAxisAlarm_XAxis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAxisAlarm_XAxis.LedColor = System.Drawing.Color.Red
        Me.ledAxisAlarm_XAxis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAxisAlarm_XAxis.Location = New System.Drawing.Point(7, 445)
        Me.ledAxisAlarm_XAxis.Name = "ledAxisAlarm_XAxis"
        Me.ledAxisAlarm_XAxis.Renderer = Nothing
        Me.ledAxisAlarm_XAxis.Size = New System.Drawing.Size(75, 32)
        Me.ledAxisAlarm_XAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAxisAlarm_XAxis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAxisAlarm_XAxis.TabIndex = 0
        Me.ledAxisAlarm_XAxis.Visible = False
        '
        'ledAxisAlarm_ZAxis
        '
        Me.ledAxisAlarm_ZAxis.AutoSize = True
        Me.ledAxisAlarm_ZAxis.BackColor = System.Drawing.Color.Transparent
        Me.ledAxisAlarm_ZAxis.BlinkInterval = 500
        Me.ledAxisAlarm_ZAxis.Label = "Z"
        Me.ledAxisAlarm_ZAxis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAxisAlarm_ZAxis.LedColor = System.Drawing.Color.Red
        Me.ledAxisAlarm_ZAxis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAxisAlarm_ZAxis.Location = New System.Drawing.Point(10, 84)
        Me.ledAxisAlarm_ZAxis.Name = "ledAxisAlarm_ZAxis"
        Me.ledAxisAlarm_ZAxis.Renderer = Nothing
        Me.ledAxisAlarm_ZAxis.Size = New System.Drawing.Size(75, 32)
        Me.ledAxisAlarm_ZAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAxisAlarm_ZAxis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAxisAlarm_ZAxis.TabIndex = 2
        '
        'ledAxisAlarm_Y2Axis
        '
        Me.ledAxisAlarm_Y2Axis.AutoSize = True
        Me.ledAxisAlarm_Y2Axis.BackColor = System.Drawing.Color.Transparent
        Me.ledAxisAlarm_Y2Axis.BlinkInterval = 500
        Me.ledAxisAlarm_Y2Axis.Label = "Y2"
        Me.ledAxisAlarm_Y2Axis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAxisAlarm_Y2Axis.LedColor = System.Drawing.Color.Red
        Me.ledAxisAlarm_Y2Axis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAxisAlarm_Y2Axis.Location = New System.Drawing.Point(7, 413)
        Me.ledAxisAlarm_Y2Axis.Name = "ledAxisAlarm_Y2Axis"
        Me.ledAxisAlarm_Y2Axis.Renderer = Nothing
        Me.ledAxisAlarm_Y2Axis.Size = New System.Drawing.Size(86, 32)
        Me.ledAxisAlarm_Y2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAxisAlarm_Y2Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAxisAlarm_Y2Axis.TabIndex = 3
        Me.ledAxisAlarm_Y2Axis.Visible = False
        '
        'ledAxisAlarm_YAxis
        '
        Me.ledAxisAlarm_YAxis.AutoSize = True
        Me.ledAxisAlarm_YAxis.BackColor = System.Drawing.Color.Transparent
        Me.ledAxisAlarm_YAxis.BlinkInterval = 500
        Me.ledAxisAlarm_YAxis.Label = "Y"
        Me.ledAxisAlarm_YAxis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAxisAlarm_YAxis.LedColor = System.Drawing.Color.Red
        Me.ledAxisAlarm_YAxis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAxisAlarm_YAxis.Location = New System.Drawing.Point(10, 52)
        Me.ledAxisAlarm_YAxis.Name = "ledAxisAlarm_YAxis"
        Me.ledAxisAlarm_YAxis.Renderer = Nothing
        Me.ledAxisAlarm_YAxis.Size = New System.Drawing.Size(75, 32)
        Me.ledAxisAlarm_YAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAxisAlarm_YAxis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAxisAlarm_YAxis.TabIndex = 1
        '
        'ledAxisAlarm_THETA4Axis
        '
        Me.ledAxisAlarm_THETA4Axis.AutoSize = True
        Me.ledAxisAlarm_THETA4Axis.BackColor = System.Drawing.Color.Transparent
        Me.ledAxisAlarm_THETA4Axis.BlinkInterval = 500
        Me.ledAxisAlarm_THETA4Axis.Label = "THETA4"
        Me.ledAxisAlarm_THETA4Axis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAxisAlarm_THETA4Axis.LedColor = System.Drawing.Color.Red
        Me.ledAxisAlarm_THETA4Axis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAxisAlarm_THETA4Axis.Location = New System.Drawing.Point(10, 212)
        Me.ledAxisAlarm_THETA4Axis.Name = "ledAxisAlarm_THETA4Axis"
        Me.ledAxisAlarm_THETA4Axis.Renderer = Nothing
        Me.ledAxisAlarm_THETA4Axis.Size = New System.Drawing.Size(86, 32)
        Me.ledAxisAlarm_THETA4Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAxisAlarm_THETA4Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAxisAlarm_THETA4Axis.TabIndex = 7
        Me.ledAxisAlarm_THETA4Axis.Visible = False
        '
        'ledAxisAlarm_THETA1Axis
        '
        Me.ledAxisAlarm_THETA1Axis.AutoSize = True
        Me.ledAxisAlarm_THETA1Axis.BackColor = System.Drawing.Color.Transparent
        Me.ledAxisAlarm_THETA1Axis.BlinkInterval = 500
        Me.ledAxisAlarm_THETA1Axis.Label = "TEHTA1"
        Me.ledAxisAlarm_THETA1Axis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAxisAlarm_THETA1Axis.LedColor = System.Drawing.Color.Red
        Me.ledAxisAlarm_THETA1Axis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAxisAlarm_THETA1Axis.Location = New System.Drawing.Point(10, 116)
        Me.ledAxisAlarm_THETA1Axis.Name = "ledAxisAlarm_THETA1Axis"
        Me.ledAxisAlarm_THETA1Axis.Renderer = Nothing
        Me.ledAxisAlarm_THETA1Axis.Size = New System.Drawing.Size(86, 32)
        Me.ledAxisAlarm_THETA1Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAxisAlarm_THETA1Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAxisAlarm_THETA1Axis.TabIndex = 4
        Me.ledAxisAlarm_THETA1Axis.Visible = False
        '
        'ledAxisAlarm_THETA2Axis
        '
        Me.ledAxisAlarm_THETA2Axis.AutoSize = True
        Me.ledAxisAlarm_THETA2Axis.BackColor = System.Drawing.Color.Transparent
        Me.ledAxisAlarm_THETA2Axis.BlinkInterval = 500
        Me.ledAxisAlarm_THETA2Axis.Label = "THETA2"
        Me.ledAxisAlarm_THETA2Axis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAxisAlarm_THETA2Axis.LedColor = System.Drawing.Color.Red
        Me.ledAxisAlarm_THETA2Axis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAxisAlarm_THETA2Axis.Location = New System.Drawing.Point(10, 148)
        Me.ledAxisAlarm_THETA2Axis.Name = "ledAxisAlarm_THETA2Axis"
        Me.ledAxisAlarm_THETA2Axis.Renderer = Nothing
        Me.ledAxisAlarm_THETA2Axis.Size = New System.Drawing.Size(86, 32)
        Me.ledAxisAlarm_THETA2Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAxisAlarm_THETA2Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAxisAlarm_THETA2Axis.TabIndex = 5
        Me.ledAxisAlarm_THETA2Axis.Visible = False
        '
        'ledAxisAlarm_THETA3Axis
        '
        Me.ledAxisAlarm_THETA3Axis.AutoSize = True
        Me.ledAxisAlarm_THETA3Axis.BackColor = System.Drawing.Color.Transparent
        Me.ledAxisAlarm_THETA3Axis.BlinkInterval = 500
        Me.ledAxisAlarm_THETA3Axis.Label = "THETA3"
        Me.ledAxisAlarm_THETA3Axis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAxisAlarm_THETA3Axis.LedColor = System.Drawing.Color.Red
        Me.ledAxisAlarm_THETA3Axis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAxisAlarm_THETA3Axis.Location = New System.Drawing.Point(10, 180)
        Me.ledAxisAlarm_THETA3Axis.Name = "ledAxisAlarm_THETA3Axis"
        Me.ledAxisAlarm_THETA3Axis.Renderer = Nothing
        Me.ledAxisAlarm_THETA3Axis.Size = New System.Drawing.Size(86, 32)
        Me.ledAxisAlarm_THETA3Axis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAxisAlarm_THETA3Axis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAxisAlarm_THETA3Axis.TabIndex = 6
        Me.ledAxisAlarm_THETA3Axis.Visible = False
        '
        'ledAxisAlarm_ContactAxis
        '
        Me.ledAxisAlarm_ContactAxis.AutoSize = True
        Me.ledAxisAlarm_ContactAxis.BackColor = System.Drawing.Color.Transparent
        Me.ledAxisAlarm_ContactAxis.BlinkInterval = 500
        Me.ledAxisAlarm_ContactAxis.Label = "Contact"
        Me.ledAxisAlarm_ContactAxis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAxisAlarm_ContactAxis.LedColor = System.Drawing.Color.Red
        Me.ledAxisAlarm_ContactAxis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAxisAlarm_ContactAxis.Location = New System.Drawing.Point(6, 380)
        Me.ledAxisAlarm_ContactAxis.Name = "ledAxisAlarm_ContactAxis"
        Me.ledAxisAlarm_ContactAxis.Renderer = Nothing
        Me.ledAxisAlarm_ContactAxis.Size = New System.Drawing.Size(75, 32)
        Me.ledAxisAlarm_ContactAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAxisAlarm_ContactAxis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAxisAlarm_ContactAxis.TabIndex = 12
        Me.ledAxisAlarm_ContactAxis.Visible = False
        '
        'ledAxisAlarm_NONE2
        '
        Me.ledAxisAlarm_NONE2.AutoSize = True
        Me.ledAxisAlarm_NONE2.BackColor = System.Drawing.Color.Transparent
        Me.ledAxisAlarm_NONE2.BlinkInterval = 500
        Me.ledAxisAlarm_NONE2.Label = "NONE"
        Me.ledAxisAlarm_NONE2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAxisAlarm_NONE2.LedColor = System.Drawing.Color.Red
        Me.ledAxisAlarm_NONE2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAxisAlarm_NONE2.Location = New System.Drawing.Point(6, 252)
        Me.ledAxisAlarm_NONE2.Name = "ledAxisAlarm_NONE2"
        Me.ledAxisAlarm_NONE2.Renderer = Nothing
        Me.ledAxisAlarm_NONE2.Size = New System.Drawing.Size(75, 32)
        Me.ledAxisAlarm_NONE2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAxisAlarm_NONE2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAxisAlarm_NONE2.TabIndex = 8
        Me.ledAxisAlarm_NONE2.Visible = False
        '
        'ledAxisAlarm_NONE3
        '
        Me.ledAxisAlarm_NONE3.AutoSize = True
        Me.ledAxisAlarm_NONE3.BackColor = System.Drawing.Color.Transparent
        Me.ledAxisAlarm_NONE3.BlinkInterval = 500
        Me.ledAxisAlarm_NONE3.Label = "NONE"
        Me.ledAxisAlarm_NONE3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAxisAlarm_NONE3.LedColor = System.Drawing.Color.Red
        Me.ledAxisAlarm_NONE3.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAxisAlarm_NONE3.Location = New System.Drawing.Point(6, 284)
        Me.ledAxisAlarm_NONE3.Name = "ledAxisAlarm_NONE3"
        Me.ledAxisAlarm_NONE3.Renderer = Nothing
        Me.ledAxisAlarm_NONE3.Size = New System.Drawing.Size(75, 32)
        Me.ledAxisAlarm_NONE3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAxisAlarm_NONE3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAxisAlarm_NONE3.TabIndex = 9
        Me.ledAxisAlarm_NONE3.Visible = False
        '
        'ledAxisAlarm_ALIGNAxis
        '
        Me.ledAxisAlarm_ALIGNAxis.AutoSize = True
        Me.ledAxisAlarm_ALIGNAxis.BackColor = System.Drawing.Color.Transparent
        Me.ledAxisAlarm_ALIGNAxis.BlinkInterval = 500
        Me.ledAxisAlarm_ALIGNAxis.Label = "Align"
        Me.ledAxisAlarm_ALIGNAxis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAxisAlarm_ALIGNAxis.LedColor = System.Drawing.Color.Red
        Me.ledAxisAlarm_ALIGNAxis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAxisAlarm_ALIGNAxis.Location = New System.Drawing.Point(6, 348)
        Me.ledAxisAlarm_ALIGNAxis.Name = "ledAxisAlarm_ALIGNAxis"
        Me.ledAxisAlarm_ALIGNAxis.Renderer = Nothing
        Me.ledAxisAlarm_ALIGNAxis.Size = New System.Drawing.Size(75, 32)
        Me.ledAxisAlarm_ALIGNAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAxisAlarm_ALIGNAxis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAxisAlarm_ALIGNAxis.TabIndex = 11
        Me.ledAxisAlarm_ALIGNAxis.Visible = False
        '
        'ledAxisAlarm_STOPERAxis
        '
        Me.ledAxisAlarm_STOPERAxis.AutoSize = True
        Me.ledAxisAlarm_STOPERAxis.BackColor = System.Drawing.Color.Transparent
        Me.ledAxisAlarm_STOPERAxis.BlinkInterval = 500
        Me.ledAxisAlarm_STOPERAxis.Label = "Stoper"
        Me.ledAxisAlarm_STOPERAxis.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAxisAlarm_STOPERAxis.LedColor = System.Drawing.Color.Red
        Me.ledAxisAlarm_STOPERAxis.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAxisAlarm_STOPERAxis.Location = New System.Drawing.Point(6, 316)
        Me.ledAxisAlarm_STOPERAxis.Name = "ledAxisAlarm_STOPERAxis"
        Me.ledAxisAlarm_STOPERAxis.Renderer = Nothing
        Me.ledAxisAlarm_STOPERAxis.Size = New System.Drawing.Size(75, 32)
        Me.ledAxisAlarm_STOPERAxis.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAxisAlarm_STOPERAxis.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAxisAlarm_STOPERAxis.TabIndex = 10
        Me.ledAxisAlarm_STOPERAxis.Visible = False
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.ledEQPAlarm_Heavy)
        Me.GroupBox18.Controls.Add(Me.ledEQPAlarm_Light)
        Me.GroupBox18.Controls.Add(Me.ledEQPAlarm_None2)
        Me.GroupBox18.Controls.Add(Me.ledEQPAlarm_None)
        Me.GroupBox18.Location = New System.Drawing.Point(365, 12)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(88, 155)
        Me.GroupBox18.TabIndex = 55
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "EQP Alarm"
        '
        'ledEQPAlarm_Heavy
        '
        Me.ledEQPAlarm_Heavy.AutoSize = True
        Me.ledEQPAlarm_Heavy.BackColor = System.Drawing.Color.Transparent
        Me.ledEQPAlarm_Heavy.BlinkInterval = 500
        Me.ledEQPAlarm_Heavy.Label = "Heavy"
        Me.ledEQPAlarm_Heavy.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEQPAlarm_Heavy.LedColor = System.Drawing.Color.Red
        Me.ledEQPAlarm_Heavy.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEQPAlarm_Heavy.Location = New System.Drawing.Point(11, 116)
        Me.ledEQPAlarm_Heavy.Name = "ledEQPAlarm_Heavy"
        Me.ledEQPAlarm_Heavy.Renderer = Nothing
        Me.ledEQPAlarm_Heavy.Size = New System.Drawing.Size(75, 32)
        Me.ledEQPAlarm_Heavy.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEQPAlarm_Heavy.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEQPAlarm_Heavy.TabIndex = 3
        '
        'ledEQPAlarm_Light
        '
        Me.ledEQPAlarm_Light.AutoSize = True
        Me.ledEQPAlarm_Light.BackColor = System.Drawing.Color.Transparent
        Me.ledEQPAlarm_Light.BlinkInterval = 500
        Me.ledEQPAlarm_Light.Label = "Light"
        Me.ledEQPAlarm_Light.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEQPAlarm_Light.LedColor = System.Drawing.Color.Red
        Me.ledEQPAlarm_Light.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEQPAlarm_Light.Location = New System.Drawing.Point(11, 84)
        Me.ledEQPAlarm_Light.Name = "ledEQPAlarm_Light"
        Me.ledEQPAlarm_Light.Renderer = Nothing
        Me.ledEQPAlarm_Light.Size = New System.Drawing.Size(75, 32)
        Me.ledEQPAlarm_Light.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEQPAlarm_Light.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEQPAlarm_Light.TabIndex = 2
        '
        'ledEQPAlarm_None2
        '
        Me.ledEQPAlarm_None2.AutoSize = True
        Me.ledEQPAlarm_None2.BackColor = System.Drawing.Color.Transparent
        Me.ledEQPAlarm_None2.BlinkInterval = 500
        Me.ledEQPAlarm_None2.Label = "None"
        Me.ledEQPAlarm_None2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEQPAlarm_None2.LedColor = System.Drawing.Color.Red
        Me.ledEQPAlarm_None2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEQPAlarm_None2.Location = New System.Drawing.Point(11, 52)
        Me.ledEQPAlarm_None2.Name = "ledEQPAlarm_None2"
        Me.ledEQPAlarm_None2.Renderer = Nothing
        Me.ledEQPAlarm_None2.Size = New System.Drawing.Size(75, 32)
        Me.ledEQPAlarm_None2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEQPAlarm_None2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEQPAlarm_None2.TabIndex = 1
        '
        'ledEQPAlarm_None
        '
        Me.ledEQPAlarm_None.AutoSize = True
        Me.ledEQPAlarm_None.BackColor = System.Drawing.Color.Transparent
        Me.ledEQPAlarm_None.BlinkInterval = 500
        Me.ledEQPAlarm_None.Label = "None"
        Me.ledEQPAlarm_None.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEQPAlarm_None.LedColor = System.Drawing.Color.Red
        Me.ledEQPAlarm_None.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEQPAlarm_None.Location = New System.Drawing.Point(11, 20)
        Me.ledEQPAlarm_None.Name = "ledEQPAlarm_None"
        Me.ledEQPAlarm_None.Renderer = Nothing
        Me.ledEQPAlarm_None.Size = New System.Drawing.Size(75, 32)
        Me.ledEQPAlarm_None.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEQPAlarm_None.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEQPAlarm_None.TabIndex = 0
        '
        'GroupBox36
        '
        Me.GroupBox36.Controls.Add(Me.ledAlarm_XAxis_OVER_CURRENT)
        Me.GroupBox36.Controls.Add(Me.ledAlarm_XAxis_AMP_OVER)
        Me.GroupBox36.Controls.Add(Me.ledAlarm_XAxis_Axis_NoError)
        Me.GroupBox36.Location = New System.Drawing.Point(494, 940)
        Me.GroupBox36.Name = "GroupBox36"
        Me.GroupBox36.Size = New System.Drawing.Size(167, 121)
        Me.GroupBox36.TabIndex = 67
        Me.GroupBox36.TabStop = False
        Me.GroupBox36.Text = "X Axis Alarm"
        Me.GroupBox36.Visible = False
        '
        'ledAlarm_XAxis_OVER_CURRENT
        '
        Me.ledAlarm_XAxis_OVER_CURRENT.AutoSize = True
        Me.ledAlarm_XAxis_OVER_CURRENT.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_XAxis_OVER_CURRENT.BlinkInterval = 500
        Me.ledAlarm_XAxis_OVER_CURRENT.Label = "X축 과전류 알람"
        Me.ledAlarm_XAxis_OVER_CURRENT.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_XAxis_OVER_CURRENT.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_XAxis_OVER_CURRENT.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_XAxis_OVER_CURRENT.Location = New System.Drawing.Point(11, 84)
        Me.ledAlarm_XAxis_OVER_CURRENT.Name = "ledAlarm_XAxis_OVER_CURRENT"
        Me.ledAlarm_XAxis_OVER_CURRENT.Renderer = Nothing
        Me.ledAlarm_XAxis_OVER_CURRENT.Size = New System.Drawing.Size(178, 32)
        Me.ledAlarm_XAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_XAxis_OVER_CURRENT.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_XAxis_OVER_CURRENT.TabIndex = 2
        '
        'ledAlarm_XAxis_AMP_OVER
        '
        Me.ledAlarm_XAxis_AMP_OVER.AutoSize = True
        Me.ledAlarm_XAxis_AMP_OVER.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_XAxis_AMP_OVER.BlinkInterval = 500
        Me.ledAlarm_XAxis_AMP_OVER.Label = "X축 AMP 과온 알람"
        Me.ledAlarm_XAxis_AMP_OVER.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_XAxis_AMP_OVER.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_XAxis_AMP_OVER.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_XAxis_AMP_OVER.Location = New System.Drawing.Point(11, 52)
        Me.ledAlarm_XAxis_AMP_OVER.Name = "ledAlarm_XAxis_AMP_OVER"
        Me.ledAlarm_XAxis_AMP_OVER.Renderer = Nothing
        Me.ledAlarm_XAxis_AMP_OVER.Size = New System.Drawing.Size(194, 32)
        Me.ledAlarm_XAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_XAxis_AMP_OVER.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_XAxis_AMP_OVER.TabIndex = 1
        '
        'ledAlarm_XAxis_Axis_NoError
        '
        Me.ledAlarm_XAxis_Axis_NoError.AutoSize = True
        Me.ledAlarm_XAxis_Axis_NoError.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_XAxis_Axis_NoError.BlinkInterval = 500
        Me.ledAlarm_XAxis_Axis_NoError.Label = "No Error"
        Me.ledAlarm_XAxis_Axis_NoError.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_XAxis_Axis_NoError.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_XAxis_Axis_NoError.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_XAxis_Axis_NoError.Location = New System.Drawing.Point(11, 20)
        Me.ledAlarm_XAxis_Axis_NoError.Name = "ledAlarm_XAxis_Axis_NoError"
        Me.ledAlarm_XAxis_Axis_NoError.Renderer = Nothing
        Me.ledAlarm_XAxis_Axis_NoError.Size = New System.Drawing.Size(134, 32)
        Me.ledAlarm_XAxis_Axis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_XAxis_Axis_NoError.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_XAxis_Axis_NoError.TabIndex = 0
        '
        'GroupBox35
        '
        Me.GroupBox35.Controls.Add(Me.ledAlarm_HitterAxis_OVER_CURRENT)
        Me.GroupBox35.Controls.Add(Me.ledAlarm_HitterAxis_AMP_OVER)
        Me.GroupBox35.Controls.Add(Me.ledAlarm_HitterAxis_NoError)
        Me.GroupBox35.Location = New System.Drawing.Point(148, 940)
        Me.GroupBox35.Name = "GroupBox35"
        Me.GroupBox35.Size = New System.Drawing.Size(167, 121)
        Me.GroupBox35.TabIndex = 66
        Me.GroupBox35.TabStop = False
        Me.GroupBox35.Text = "Hitter Axis Alarm"
        Me.GroupBox35.Visible = False
        '
        'ledAlarm_HitterAxis_OVER_CURRENT
        '
        Me.ledAlarm_HitterAxis_OVER_CURRENT.AutoSize = True
        Me.ledAlarm_HitterAxis_OVER_CURRENT.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterAxis_OVER_CURRENT.BlinkInterval = 500
        Me.ledAlarm_HitterAxis_OVER_CURRENT.Label = "히터 과전류 알람"
        Me.ledAlarm_HitterAxis_OVER_CURRENT.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterAxis_OVER_CURRENT.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterAxis_OVER_CURRENT.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterAxis_OVER_CURRENT.Location = New System.Drawing.Point(11, 84)
        Me.ledAlarm_HitterAxis_OVER_CURRENT.Name = "ledAlarm_HitterAxis_OVER_CURRENT"
        Me.ledAlarm_HitterAxis_OVER_CURRENT.Renderer = Nothing
        Me.ledAlarm_HitterAxis_OVER_CURRENT.Size = New System.Drawing.Size(178, 32)
        Me.ledAlarm_HitterAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterAxis_OVER_CURRENT.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterAxis_OVER_CURRENT.TabIndex = 2
        '
        'ledAlarm_HitterAxis_AMP_OVER
        '
        Me.ledAlarm_HitterAxis_AMP_OVER.AutoSize = True
        Me.ledAlarm_HitterAxis_AMP_OVER.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterAxis_AMP_OVER.BlinkInterval = 500
        Me.ledAlarm_HitterAxis_AMP_OVER.Label = "히터 AMP 과온 알람"
        Me.ledAlarm_HitterAxis_AMP_OVER.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterAxis_AMP_OVER.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterAxis_AMP_OVER.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterAxis_AMP_OVER.Location = New System.Drawing.Point(11, 52)
        Me.ledAlarm_HitterAxis_AMP_OVER.Name = "ledAlarm_HitterAxis_AMP_OVER"
        Me.ledAlarm_HitterAxis_AMP_OVER.Renderer = Nothing
        Me.ledAlarm_HitterAxis_AMP_OVER.Size = New System.Drawing.Size(194, 32)
        Me.ledAlarm_HitterAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterAxis_AMP_OVER.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterAxis_AMP_OVER.TabIndex = 1
        '
        'ledAlarm_HitterAxis_NoError
        '
        Me.ledAlarm_HitterAxis_NoError.AutoSize = True
        Me.ledAlarm_HitterAxis_NoError.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_HitterAxis_NoError.BlinkInterval = 500
        Me.ledAlarm_HitterAxis_NoError.Label = "No Error"
        Me.ledAlarm_HitterAxis_NoError.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_HitterAxis_NoError.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_HitterAxis_NoError.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_HitterAxis_NoError.Location = New System.Drawing.Point(11, 20)
        Me.ledAlarm_HitterAxis_NoError.Name = "ledAlarm_HitterAxis_NoError"
        Me.ledAlarm_HitterAxis_NoError.Renderer = Nothing
        Me.ledAlarm_HitterAxis_NoError.Size = New System.Drawing.Size(143, 32)
        Me.ledAlarm_HitterAxis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_HitterAxis_NoError.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_HitterAxis_NoError.TabIndex = 0
        '
        'GroupBox34
        '
        Me.GroupBox34.Controls.Add(Me.ledAlarm_UnLoaderAxis_OVER_CURRENT)
        Me.GroupBox34.Controls.Add(Me.ledAlarm_UnLoaderAxis_AMP_OVER)
        Me.GroupBox34.Controls.Add(Me.ledAlarm_UnLoaderAxis_NoError)
        Me.GroupBox34.Location = New System.Drawing.Point(321, 940)
        Me.GroupBox34.Name = "GroupBox34"
        Me.GroupBox34.Size = New System.Drawing.Size(167, 121)
        Me.GroupBox34.TabIndex = 65
        Me.GroupBox34.TabStop = False
        Me.GroupBox34.Text = "UnLoader Axis Alarm"
        Me.GroupBox34.Visible = False
        '
        'ledAlarm_UnLoaderAxis_OVER_CURRENT
        '
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT.AutoSize = True
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT.BlinkInterval = 500
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT.Label = "언로더 과전류 알람"
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT.Location = New System.Drawing.Point(11, 84)
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT.Name = "ledAlarm_UnLoaderAxis_OVER_CURRENT"
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT.Renderer = Nothing
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT.Size = New System.Drawing.Size(178, 32)
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_UnLoaderAxis_OVER_CURRENT.TabIndex = 2
        '
        'ledAlarm_UnLoaderAxis_AMP_OVER
        '
        Me.ledAlarm_UnLoaderAxis_AMP_OVER.AutoSize = True
        Me.ledAlarm_UnLoaderAxis_AMP_OVER.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_UnLoaderAxis_AMP_OVER.BlinkInterval = 500
        Me.ledAlarm_UnLoaderAxis_AMP_OVER.Label = "언로더 AMP 과온 알람"
        Me.ledAlarm_UnLoaderAxis_AMP_OVER.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_UnLoaderAxis_AMP_OVER.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_UnLoaderAxis_AMP_OVER.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_UnLoaderAxis_AMP_OVER.Location = New System.Drawing.Point(11, 52)
        Me.ledAlarm_UnLoaderAxis_AMP_OVER.Name = "ledAlarm_UnLoaderAxis_AMP_OVER"
        Me.ledAlarm_UnLoaderAxis_AMP_OVER.Renderer = Nothing
        Me.ledAlarm_UnLoaderAxis_AMP_OVER.Size = New System.Drawing.Size(194, 32)
        Me.ledAlarm_UnLoaderAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_UnLoaderAxis_AMP_OVER.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_UnLoaderAxis_AMP_OVER.TabIndex = 1
        '
        'ledAlarm_UnLoaderAxis_NoError
        '
        Me.ledAlarm_UnLoaderAxis_NoError.AutoSize = True
        Me.ledAlarm_UnLoaderAxis_NoError.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_UnLoaderAxis_NoError.BlinkInterval = 500
        Me.ledAlarm_UnLoaderAxis_NoError.Label = "No Error"
        Me.ledAlarm_UnLoaderAxis_NoError.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_UnLoaderAxis_NoError.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_UnLoaderAxis_NoError.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_UnLoaderAxis_NoError.Location = New System.Drawing.Point(11, 20)
        Me.ledAlarm_UnLoaderAxis_NoError.Name = "ledAlarm_UnLoaderAxis_NoError"
        Me.ledAlarm_UnLoaderAxis_NoError.Renderer = Nothing
        Me.ledAlarm_UnLoaderAxis_NoError.Size = New System.Drawing.Size(156, 32)
        Me.ledAlarm_UnLoaderAxis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_UnLoaderAxis_NoError.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_UnLoaderAxis_NoError.TabIndex = 0
        '
        'GroupBox33
        '
        Me.GroupBox33.Controls.Add(Me.ledAlarm_LoaderAxis_OVER_CURRENT)
        Me.GroupBox33.Controls.Add(Me.ledAlarm_LoaderAxis_AMP_OVER)
        Me.GroupBox33.Controls.Add(Me.ledAlarm_LoaderAxis_NoError)
        Me.GroupBox33.Location = New System.Drawing.Point(670, 940)
        Me.GroupBox33.Name = "GroupBox33"
        Me.GroupBox33.Size = New System.Drawing.Size(167, 121)
        Me.GroupBox33.TabIndex = 64
        Me.GroupBox33.TabStop = False
        Me.GroupBox33.Text = "Loader Axis Alarm"
        Me.GroupBox33.Visible = False
        '
        'ledAlarm_LoaderAxis_OVER_CURRENT
        '
        Me.ledAlarm_LoaderAxis_OVER_CURRENT.AutoSize = True
        Me.ledAlarm_LoaderAxis_OVER_CURRENT.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_LoaderAxis_OVER_CURRENT.BlinkInterval = 500
        Me.ledAlarm_LoaderAxis_OVER_CURRENT.Label = "로더 과전류 알람"
        Me.ledAlarm_LoaderAxis_OVER_CURRENT.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_LoaderAxis_OVER_CURRENT.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_LoaderAxis_OVER_CURRENT.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_LoaderAxis_OVER_CURRENT.Location = New System.Drawing.Point(11, 84)
        Me.ledAlarm_LoaderAxis_OVER_CURRENT.Name = "ledAlarm_LoaderAxis_OVER_CURRENT"
        Me.ledAlarm_LoaderAxis_OVER_CURRENT.Renderer = Nothing
        Me.ledAlarm_LoaderAxis_OVER_CURRENT.Size = New System.Drawing.Size(178, 32)
        Me.ledAlarm_LoaderAxis_OVER_CURRENT.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_LoaderAxis_OVER_CURRENT.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_LoaderAxis_OVER_CURRENT.TabIndex = 2
        '
        'ledAlarm_LoaderAxis_AMP_OVER
        '
        Me.ledAlarm_LoaderAxis_AMP_OVER.AutoSize = True
        Me.ledAlarm_LoaderAxis_AMP_OVER.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_LoaderAxis_AMP_OVER.BlinkInterval = 500
        Me.ledAlarm_LoaderAxis_AMP_OVER.Label = "로더 AMP 과온 알람"
        Me.ledAlarm_LoaderAxis_AMP_OVER.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_LoaderAxis_AMP_OVER.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_LoaderAxis_AMP_OVER.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_LoaderAxis_AMP_OVER.Location = New System.Drawing.Point(11, 52)
        Me.ledAlarm_LoaderAxis_AMP_OVER.Name = "ledAlarm_LoaderAxis_AMP_OVER"
        Me.ledAlarm_LoaderAxis_AMP_OVER.Renderer = Nothing
        Me.ledAlarm_LoaderAxis_AMP_OVER.Size = New System.Drawing.Size(194, 32)
        Me.ledAlarm_LoaderAxis_AMP_OVER.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_LoaderAxis_AMP_OVER.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_LoaderAxis_AMP_OVER.TabIndex = 1
        '
        'ledAlarm_LoaderAxis_NoError
        '
        Me.ledAlarm_LoaderAxis_NoError.AutoSize = True
        Me.ledAlarm_LoaderAxis_NoError.BackColor = System.Drawing.Color.Transparent
        Me.ledAlarm_LoaderAxis_NoError.BlinkInterval = 500
        Me.ledAlarm_LoaderAxis_NoError.Label = "No Error"
        Me.ledAlarm_LoaderAxis_NoError.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledAlarm_LoaderAxis_NoError.LedColor = System.Drawing.Color.Red
        Me.ledAlarm_LoaderAxis_NoError.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledAlarm_LoaderAxis_NoError.Location = New System.Drawing.Point(11, 20)
        Me.ledAlarm_LoaderAxis_NoError.Name = "ledAlarm_LoaderAxis_NoError"
        Me.ledAlarm_LoaderAxis_NoError.Renderer = Nothing
        Me.ledAlarm_LoaderAxis_NoError.Size = New System.Drawing.Size(134, 32)
        Me.ledAlarm_LoaderAxis_NoError.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledAlarm_LoaderAxis_NoError.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledAlarm_LoaderAxis_NoError.TabIndex = 0
        '
        'ledEMSAlarm_EMS2
        '
        Me.ledEMSAlarm_EMS2.AutoSize = True
        Me.ledEMSAlarm_EMS2.BackColor = System.Drawing.Color.Transparent
        Me.ledEMSAlarm_EMS2.BlinkInterval = 500
        Me.ledEMSAlarm_EMS2.Label = "긴급정지 알람 (EMS -2)"
        Me.ledEMSAlarm_EMS2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right
        Me.ledEMSAlarm_EMS2.LedColor = System.Drawing.Color.Red
        Me.ledEMSAlarm_EMS2.LedSize = New System.Drawing.SizeF(30.0!, 30.0!)
        Me.ledEMSAlarm_EMS2.Location = New System.Drawing.Point(218, 14)
        Me.ledEMSAlarm_EMS2.Name = "ledEMSAlarm_EMS2"
        Me.ledEMSAlarm_EMS2.Renderer = Nothing
        Me.ledEMSAlarm_EMS2.Size = New System.Drawing.Size(194, 32)
        Me.ledEMSAlarm_EMS2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.[On]
        Me.ledEMSAlarm_EMS2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Rectangular
        Me.ledEMSAlarm_EMS2.TabIndex = 9
        '
        'frmPLCControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1792, 1055)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.GroupBox36)
        Me.Controls.Add(Me.GroupBox35)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.GroupBox34)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox33)
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
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox24.ResumeLayout(False)
        Me.GroupBox24.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox21.ResumeLayout(False)
        Me.GroupBox21.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox27.ResumeLayout(False)
        Me.GroupBox42.ResumeLayout(False)
        Me.GroupBox42.PerformLayout()
        Me.GroupBox41.ResumeLayout(False)
        Me.GroupBox41.PerformLayout()
        Me.GroupBox39.ResumeLayout(False)
        Me.GroupBox39.PerformLayout()
        Me.GroupBox40.ResumeLayout(False)
        Me.GroupBox40.PerformLayout()
        Me.GroupBox38.ResumeLayout(False)
        Me.GroupBox38.PerformLayout()
        Me.GroupBox37.ResumeLayout(False)
        Me.GroupBox37.PerformLayout()
        Me.GroupBox32.ResumeLayout(False)
        Me.GroupBox32.PerformLayout()
        Me.GroupBox31.ResumeLayout(False)
        Me.GroupBox31.PerformLayout()
        Me.GroupBox30.ResumeLayout(False)
        Me.GroupBox30.PerformLayout()
        Me.GroupBox29.ResumeLayout(False)
        Me.GroupBox29.PerformLayout()
        Me.GroupBox26.ResumeLayout(False)
        Me.GroupBox26.PerformLayout()
        Me.GroupBox28.ResumeLayout(False)
        Me.GroupBox28.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox36.ResumeLayout(False)
        Me.GroupBox36.PerformLayout()
        Me.GroupBox35.ResumeLayout(False)
        Me.GroupBox35.PerformLayout()
        Me.GroupBox34.ResumeLayout(False)
        Me.GroupBox34.PerformLayout()
        Me.GroupBox33.ResumeLayout(False)
        Me.GroupBox33.PerformLayout()
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
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox24 As System.Windows.Forms.GroupBox
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
    Friend WithEvents ledServoAlarm_ZAxis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledServoAlarm_Y1Axis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledServoAlarm_XAxis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
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
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
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
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
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
    Friend WithEvents GroupBox21 As System.Windows.Forms.GroupBox
    Friend WithEvents ledEQPStatus_Reset As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEQPStatus_STOP As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEQPStatus_PAUSE As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEQPStatus_RUN As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
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
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
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
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents ledMagazineErrorStatus_Reserved07 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledMagazineErrorStatus_Reserved06 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledMagazineErrorStatus_Reserved05 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledMagazineErrorStatus_Reserved04 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledMagazineErrorStatus_Reserved03 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledMagazineErrorStatus_Reserved02 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledMagazineErrorStatus_Reserved01 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledMagazineErrorStatus_Down As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
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
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents ledSysStatus_SystemIDLE As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_SystemLoading As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_Processing As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_ManualMode As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_AutoMode As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_TeachingMode As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_PowerDown As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledSysStatus_PowerON As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox27 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox38 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_ZAxis_OVER_CURRENT As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_ZAxis_AMP_OVER As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_ZAxis_Axis_NoError As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox37 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_YAxis_OVER_CURRENT As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_YAxis_AMP_OVER As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_YAxis_Axis_NoError As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox36 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_XAxis_OVER_CURRENT As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_XAxis_AMP_OVER As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_XAxis_Axis_NoError As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox35 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_HitterAxis_OVER_CURRENT As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterAxis_AMP_OVER As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterAxis_NoError As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox34 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_UnLoaderAxis_OVER_CURRENT As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_UnLoaderAxis_AMP_OVER As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_UnLoaderAxis_NoError As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox33 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_LoaderAxis_OVER_CURRENT As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_LoaderAxis_AMP_OVER As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_LoaderAxis_NoError As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox32 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_HitterOverZone2_CH9 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone2_CH8 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone2_CH7 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone2_CH6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone2_CH5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone2_CH4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone2_CH3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone2_CH2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone2_CH1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone2_No_Error As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox31 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_HitterOverZone1_CH9 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone1_CH8 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone1_CH7 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone1_CH6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone1_CH5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone1_CH4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone1_CH3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone1_CH2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone1_CH1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterOverZone1_No_Error As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox30 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_HitterSSR_CH9 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterSSR_CH8 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterSSR_CH7 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterSSR_CH6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterSSR_CH5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterSSR_CH4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterSSR_CH3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterSSR_CH2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterSSR_CH1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterSSR_No_Error As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox29 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_HitterEOCR_CH9 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterEOCR_CH8 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterEOCR_CH7 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterEOCR_CH6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterEOCR_CH5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterEOCR_CH4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterEOCR_CH3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterEOCR_CH2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterEOCR_CH1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_HitterEOCR_No_Error As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox26 As System.Windows.Forms.GroupBox
    Friend WithEvents ledEMSAlarm_SMOKE As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_TempLight As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_EMS As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_NO_Error As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox28 As System.Windows.Forms.GroupBox
    Friend WithEvents ledDoorAlarm_Door5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledDoorAlarm_Door4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledDoorAlarm_Door3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledDoorAlarm_Door2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledDoorAlarm_Door1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledDoorAlarm_Safety_Door As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledDoorAlarm_NoError As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_Hitter_CH9 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Hitter_CH8 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Hitter_CH7 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Hitter_CH6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Hitter_CH5 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Hitter_CH4 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Hitter_CH3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Hitter_CH2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Hitter_CH1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Hitter_No_Error As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAxisAlarm_NoError As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAxisAlarm_ContactAxis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAxisAlarm_ALIGNAxis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAxisAlarm_STOPERAxis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAxisAlarm_NONE3 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAxisAlarm_NONE2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAxisAlarm_THETA4Axis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAxisAlarm_THETA3Axis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAxisAlarm_THETA2Axis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAxisAlarm_THETA1Axis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAxisAlarm_Y2Axis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAxisAlarm_ZAxis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAxisAlarm_YAxis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAxisAlarm_XAxis As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents ledEQPAlarm_Heavy As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEQPAlarm_Light As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEQPAlarm_None2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEQPAlarm_None As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_TempHeavy As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledDoorAlarm_Door7 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledDoorAlarm_Door6 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox42 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_Theta4Axis_OVER_CURRENT As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Theta4Axis_AMP_OVER As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Theta4Axis_Axis_NoError As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox41 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_Theta3Axis_OVER_CURRENT As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Theta3Axis_AMP_OVER As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Theta3Axis_Axis_NoError As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox39 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_Theta2Axis_OVER_CURRENT As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Theta2Axis_AMP_OVER As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Theta2Axis_Axis_NoError As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents GroupBox40 As System.Windows.Forms.GroupBox
    Friend WithEvents ledAlarm_Theta1Axis_OVER_CURRENT As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Theta1Axis_AMP_OVER As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledAlarm_Theta1Axis_Axis_NoError As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledDoorAlarm_Door8 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_MC2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_MC1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_Safety2 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_Safety1 As LBSoft.IndustrialCtrls.Leds.LBLed
    Friend WithEvents ledEMSAlarm_EMS2 As LBSoft.IndustrialCtrls.Leds.LBLed

End Class
