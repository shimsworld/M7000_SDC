Imports System.Threading
Imports System.IO
Imports System.Text
Imports System.Net
Imports CCommLib

Public Class frmSGControl


#Region "Defines"

    Public myParent As frmMain
    Dim m_Config() As ucConfigRS485.sRS485Config
    Dim m_nSelDevice As Integer

    Public devCH As Integer = 0
    Public devAddr As Integer = 0
    Private g_strBaudTable() As String = New String() {"50", "75", "110", "134", "150", "300", "600", _
"1200", "1800", "2400", "4800", "7200", "9600", "19200", "38400", "57600", "115200", "230400", "460800", "921600"}
    Public WithEvents UcDacFrame1 As UcDacFrame

#End Region


#Region "Create, Dispose and init"

    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myParent = main
        m_Config = config.SGConfig
        m_nSelDevice = 0
    End Sub

    Private Sub frmSGControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim cc As Byte = &HF
        'MsgBox(CStr(Int(cc)))
        Init()
    End Sub


    Public Sub Init()

        Me.UcDacFrame1 = New UcDacFrame()
        Me.Panel4.Controls.Add(Me.UcDacFrame1)
        '
        'UcDacFrame1
        '
        Me.UcDacFrame1.AutoScroll = True
        Me.UcDacFrame1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcDacFrame1.Location = New System.Drawing.Point(0, 0)
        Me.UcDacFrame1.Name = "UcDacFrame1"
        Me.UcDacFrame1.Size = New System.Drawing.Size(1074, 795)
        Me.UcDacFrame1.TabIndex = 0

        cboType.SelectedIndex = 0
        With cbBaudRate
            .Items.Clear()
            For i As Integer = 0 To g_strBaudTable.Length - 1
                .Items.Add(g_strBaudTable(i))
            Next
            .SelectedIndex = 15
        End With

        init_Portlist(cboPort)

        InitDacUC()

        With cbSelDevice
            .Items.Clear()
            For i As Integer = 0 To m_Config.Length - 1
                .Items.Add(i + 1)
            Next
            .SelectedIndex = m_nSelDevice
        End With

        'test
        cbo_subch.SelectedIndex = 0
        cbo_sigch.SelectedIndex = 0
        cbo_Mainch.SelectedIndex = 0
    End Sub

#End Region
 


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ret As Integer
        myParent.cMcSG(m_nSelDevice).cSG.cPing(devAddr, devCH, ret)

        tbError.Text = ret
    End Sub

  
    Public Sub InitDacUC()
        'UcDataGridView1.RowLineNum = 108
        'Dim TextBox As DataGridViewTextBoxCell
        'For Cnum As Integer = 0 To 3
        '    For Rnum As Integer = 0 To 108 - 1

        '        If Cnum = 1 Then
        '            UcDataGridView1.DataGridView1.Rows(Rnum).Cells(Cnum).Value = "Set"
        '        End If

        '        If Cnum = 3 Then

        '            UcDataGridView1.DataGridView1.Rows(Rnum).Cells(Cnum).Value = "Read"
        '        End If

        '        If Cnum = 2 Then
        '            TextBox = UcDataGridView1.DataGridView1.Rows(Rnum).Cells(Cnum)
        '            TextBox.ReadOnly = True
        '        End If
        '    Next
        'Next


        AddHandler UcDacFrame1.UcChannelMouseMove, AddressOf UcChannelMouseMove
        AddHandler UcDacFrame1.UcChannelDacGet, AddressOf UcChannelDacGet
        AddHandler UcDacFrame1.UcChannelDacSet, AddressOf UcChannelDacSet
        AddHandler UcDacFrame1.UcChannelDacOnOFF, AddressOf UcChannelDacOnOFF
        AddHandler UcDacFrame1.UcChannelDacCheckClick, AddressOf UcChannelDacCheckClick
        AddHandler UcDacFrame1.UcChannelCalSet, AddressOf UcChannelCalSet
        AddHandler UcDacFrame1.UcChannelCalGet, AddressOf UcChannelCalGet

        AddHandler UcADcFrame1.UcChannelMouseMove, AddressOf UcChannelMouseMove
        AddHandler UcADcFrame1.UcChannelADcRead, AddressOf UcChannelADcRead
        AddHandler UcADcFrame1.UcChannelADcSetAver, AddressOf UcChannelADcSetAver
        AddHandler UcADcFrame1.UcChannelADcSetLimitTemp, AddressOf UcChannelADcSetLimitTemp
        AddHandler UcADcFrame1.UcChannelADcSetLimit, AddressOf UcChannelADcSetLimit
        AddHandler UcADcFrame1.UcChannelADcCheckClick, AddressOf UcChannelADcCheckClick
        AddHandler UcADcFrame1.UcChannelADcCalSet, AddressOf UcChannelADcCalSet
        AddHandler UcADcFrame1.UcChannelADcCalGet, AddressOf UcChannelADcCalGet




        AddHandler Ucgpio1.UcGPO_Set, AddressOf UcGPO_Set
        AddHandler Ucgpio1.UcGPO_Read, AddressOf UcGPO_Read

        AddHandler Ucgpio1.UcGPIO_OutSet, AddressOf UcGPIO_OutSet
        AddHandler Ucgpio1.UcGPIO_OutRead, AddressOf UcGPIO_OutRead

        AddHandler Ucgpio1.UcGPIO_IN_Read, AddressOf UcGPIO_IN_Read
        AddHandler Ucgpio1.UcGPIO_Out_Set, AddressOf UcGPIO_Out_Set
        AddHandler Ucgpio1.UcGPIO_Out_Read, AddressOf UcGPIO_Out_Read


    End Sub
#Region "Signal Generator Dac"
    Public Sub UcChannelMouseMove(ByVal gCondi As UcDacChannel.Condi)

        For cnt As Integer = 0 To cDevSG.Max_Pulse_Channel - 1
            If cnt = gCondi.ChannelNum Then
                UcDacFrame1.ChanDac(cnt).BackColor = Color.Khaki
                UcDacFrame1.ChanDac(cnt).Chk_CH.Checked = True
                txt_sCh.Text = UcDacFrame1.ChanDac(cnt).Chk_CH.Text
            Else
                UcDacFrame1.ChanDac(cnt).BackColor = Color.LightGray
                '  UcDacFrame1.ChanDac(cnt).Chk_CH.Checked = False
            End If


        Next
        '  grb_Dac.Enabled = False

    End Sub
    Public Sub UcChannelCalSet(ByVal gCondi As UcDacChannel.Condi)

        Dim tDacChk As Integer

        If gCondi.ChkDacCh1 = True Then
            tDacChk = 0
        ElseIf gCondi.ChkDacCh2 = True Then
            tDacChk = 1
        End If
        Dim tDacChNum As Integer = gCondi.ChannelNum * 2 + tDacChk

        Dim calDlg As frmSGCalibration = New frmSGCalibration(Me)
        calDlg.selectedDevice = m_nSelDevice
        calDlg.DACCondition = gCondi
        calDlg.Mode = frmSGCalibration.eSetMode.eDACMode
        calDlg.Text = "DAC Calibration Ch " & CStr(Format(tDacChNum, "00"))
        calDlg.ChannelNumber = tDacChNum
        calDlg.Show()

    End Sub
    Public Sub UcChannelCalGet(ByVal gCondi As UcDacChannel.Condi)
        Dim SelectChannelNum As Integer
        Dim inCh As Integer = gCondi.ChannelNum
        Dim ReadSlopeValue As Single
        Dim ReadOffsetValue As Single
        Dim ret As Integer


        If gCondi.ChkDacCh1 = True Then
            SelectChannelNum = gCondi.DacChannelNum(0)
        ElseIf gCondi.ChkDacCh2 = True Then
            SelectChannelNum = gCondi.DacChannelNum(1)
        End If

        If myParent.cMcSG(m_nSelDevice).cSG.Get_DacSlope(devAddr, devCH, ret, ReadSlopeValue, SelectChannelNum) = False Then

            Exit Sub

        End If
        UcDacFrame1.ChanDac(inCh).txt_ratio.Text = ReadSlopeValue

        If myParent.cMcSG(m_nSelDevice).cSG.Get_DacOffset(devAddr, devCH, ret, ReadOffsetValue, SelectChannelNum) = False Then

            Exit Sub

        End If
        UcDacFrame1.ChanDac(inCh).txt_offset.Text = ReadOffsetValue

    End Sub
    Public Sub UcChannelDacGet(ByVal gCondi As UcDacChannel.Condi)

        ' 개별 채널 설정 값 읽기
        Dim ret As Integer
        Dim inCh As Integer = gCondi.ChannelNum
        Dim GetValue(1) As Double
        Dim SelectChannelNum(1) As Integer





        For Cnt As Integer = 0 To 1
            SelectChannelNum(Cnt) = gCondi.DacChannelNum(Cnt)
            If myParent.cMcSG(m_nSelDevice).cSG.Get_OutputOneChannel(devAddr, devCH, ret, GetValue(Cnt), SelectChannelNum(Cnt)) = False Then
                Exit Sub
            End If
            UcDacFrame1.ChanDac(inCh).ReadDacLabelArr(Cnt).Text = GetValue(Cnt)
        Next
    End Sub
    Public Sub UcChannelDacSet(ByVal gCondi As UcDacChannel.Condi)

        ' 개별 채널 설정 실행
        Dim ret As Integer
        Dim inCh As Integer = gCondi.ChannelNum
        Dim SetMode As cDevSG.eDacMode
        Dim SetFoutputMode As cDevSG.eFoutput
        Dim SetValue(1) As Double
        Dim SelectChannelNum(1) As Integer

        '   Dim SetPulseMode() As cDevSG.mPulseSet


        Dim ReadOffsetValue As Single
        Dim ReadSlopeValue As Single


        If gCondi.ChkMode = 0 Then
            'DC Mode
            SetMode = cDevSG.eDacMode.eDCMode
            myParent.cMcSG(m_nSelDevice).cSG.Set_SelectModeOneChannel(devAddr, devCH, ret, SetMode, inCh) '(에러코드 , 설정 할 Mode 0:DC Mode , 1:Pulse Mode  , 설정할  채널 )

            If gCondi.ChkDacCh1 = True Then
                SetFoutputMode = cDevSG.eFoutput.eHigh

                myParent.cMcSG(m_nSelDevice).cSG.Set_FinalOutputOneChannel(devAddr, devCH, ret, SetFoutputMode, inCh) '(에러코드 , 설정 할 Mode 0:Even Mode , 1:ODD Mode  , 설정할  채널 ( 0 ~ 53 ))

            ElseIf gCondi.ChkDacCh2 = True Then
                SetFoutputMode = cDevSG.eFoutput.eLow
                myParent.cMcSG(m_nSelDevice).cSG.Set_FinalOutputOneChannel(devAddr, devCH, ret, SetFoutputMode, inCh) '(에러코드 , 설정 할 Mode 0:Even Mode , 1:ODD Mode  , 설정할  채널 ( 0 ~ 53 ))

            End If


        ElseIf gCondi.ChkMode = 1 Then
            'Pulse Mode
            SetMode = cDevSG.eDacMode.ePulseMode
            myParent.cMcSG(m_nSelDevice).cSG.Set_SelectModeOneChannel(devAddr, devCH, ret, SetMode, inCh) '(에러코드 , 설정 할 Mode 0:DC Mode , 1:Pulse Mode  , 설정할  채널 )


            Dim SetPulseMode As cDevSG.sPulseParam

            With SetPulseMode

                .Width = gCondi.Width
                .Period = gCondi.Period
                .Delay = gCondi.Delay
            End With

            myParent.cMcSG(m_nSelDevice).cSG.Set_PulseOneChannel(devAddr, devCH, ret, SetPulseMode, inCh) '(에러코드 , 설정 할 Width : 상승 구간 Delay : 지연구간 Period : 주기  , 설정할  채널 ( 0 ~ 53 ))

        End If


        For Cnt As Integer = 0 To 1

            SelectChannelNum(Cnt) = gCondi.DacChannelNum(Cnt)

            If chk_CalApply.Checked = True Then

                myParent.cMcSG(m_nSelDevice).cSG.Get_DacSlope(devAddr, devCH, ret, ReadSlopeValue, SelectChannelNum(Cnt))
                myParent.cMcSG(m_nSelDevice).cSG.Get_DacOffset(devAddr, devCH, ret, ReadOffsetValue, SelectChannelNum(Cnt))


                SetValue(Cnt) = gCondi.DacSetVolt(Cnt) * ReadSlopeValue + ReadOffsetValue
            Else
                SetValue(Cnt) = gCondi.DacSetVolt(Cnt)
            End If


            If myParent.cMcSG(m_nSelDevice).cSG.Set_OutputOneChannel(devAddr, devCH, ret, SetValue(Cnt), SelectChannelNum(Cnt)) = False Then
                Exit Sub
            End If
        Next


    End Sub
    Public Sub UcChannelDacOnOFF(ByVal gCondi As UcDacChannel.Condi)
        'Signal Generator
        '개별 Dac 채널 OnOff 설정
        Dim ret As Integer
        Dim inCh As Integer = gCondi.ChannelNum
        Dim SetMode As cDevSG.eOnOff
        Dim SelectChannelNum As Integer = 0 'ch 0 ~ 53

        If gCondi.OnOff = True Then
            SetMode = cDevSG.eOnOff.eOFF
            If myParent.cMcSG(m_nSelDevice).cSG.Set_OnoffOneChannel(devAddr, devCH, ret, SetMode, inCh) = True Then   '(에러코드 , 설정 할 Onoff 0:Off Mode , 1:On Mode  , 설정할  채널 ( 0 ~ 53 ))
            End If
        ElseIf gCondi.OnOff = False Then
            SetMode = cDevSG.eOnOff.eON
            If myParent.cMcSG(m_nSelDevice).cSG.Set_OnoffOneChannel(devAddr, devCH, ret, SetMode, inCh) = False Then   '(에러코드 , 설정 할 Onoff 0:Off Mode , 1:On Mode  , 설정할  채널 ( 0 ~ 53 ))
            End If
        End If
        DacOnOFfCheck()

    End Sub
    Public Sub UcChannelDacCheckClick(ByVal gCondi As UcDacChannel.Condi)
        Dim tChkCnt As Integer = 0
        Dim tTempString As String = ""
        For cnt As Integer = 0 To cDevSG.Max_Pulse_Channel - 1

            If UcDacFrame1.ChanDac(cnt).Chk_CH.Checked = True Then
                UcDacFrame1.ChanDac(cnt).BackColor = Color.Khaki
                tTempString = tTempString & UcDacFrame1.ChanDac(cnt).Chk_CH.Text & " , "
                tChkCnt = tChkCnt + 1
            ElseIf UcDacFrame1.ChanDac(cnt).Chk_CH.Checked = False Then
                UcDacFrame1.ChanDac(cnt).BackColor = Color.LightGray

            End If


        Next

        txt_sCh.Text = tTempString
        'If tChkCnt > 1 Then

        '    grb_Dac.Enabled = True

        'Else
        '    grb_Dac.Enabled = False
        'End If
    End Sub
    Public Function DacReadSetData() As Boolean

        'Signal Generator
        '전체 채널 Dac 출력 모드 설정 읽기
        Dim ret As Integer
        Dim SetMode() As cDevSG.eDacMode = Nothing 'max ch54
        Dim Cnt As Integer

        If myParent.cMcSG(m_nSelDevice).cSG.Get_SelectModeAllChannel(devAddr, devCH, ret, SetMode) = False Then
            Return False
        End If


        For Cnt = 0 To SetMode.Length - 1
            If SetMode(Cnt) = cDevSG.eDacMode.eDCMode Then
                UcDacFrame1.ChanDac(Cnt).rdo_dcMode.Checked = True
            ElseIf SetMode(Cnt) = cDevSG.eDacMode.ePulseMode Then
                UcDacFrame1.ChanDac(Cnt).rdo_pulseMode.Checked = True
            End If
        Next


        Dim ReadFOutput() As cDevSG.eFoutput = Nothing 'max ch 54
        If myParent.cMcSG(m_nSelDevice).cSG.Get_FinalOutputAllChannel(devAddr, devCH, ret, ReadFOutput) = False Then
            Return False
        End If

        For Cnt = 0 To ReadFOutput.Length - 1
            If SetMode(Cnt) = cDevSG.eFoutput.eHigh Then
                UcDacFrame1.ChanDac(Cnt).rdo_ch1.Checked = True
            ElseIf SetMode(Cnt) = cDevSG.eFoutput.eLow Then
                UcDacFrame1.ChanDac(Cnt).rdo_ch2.Checked = True
            End If
        Next


        'Signal Generator
        '전체 채널Dac 설정 값 읽기
        '   Dim ret As Integer
        Dim ReadValue() As Double = Nothing

        If myParent.cMcSG(m_nSelDevice).cSG.Get_OutputAllChannel(devAddr, devCH, ret, ReadValue) = False Then
            Return False
        End If

        For Cnt = 0 To (ReadValue.Length / 2) - 1

            UcDacFrame1.ChanDac(Cnt).txt_HighDAC.Text = CStr(ReadValue(Cnt * 2)) ' Format(ReadValue(Cnt * 2), "0.0")
            UcDacFrame1.ChanDac(Cnt).txt_LowDAC.Text = CStr(ReadValue(Cnt * 2 + 1))  'Format(ReadValue(Cnt * 2 + 1),"0.0")
        Next




        Dim ReadPulseSet() As cDevSG.sPulseParam = Nothing
        If myParent.cMcSG(m_nSelDevice).cSG.Get_PulseAllChannel(devAddr, devCH, ret, ReadPulseSet) = False Then
            Return False
        End If

        For Cnt = 0 To ReadPulseSet.Length - 1

            UcDacFrame1.ChanDac(Cnt).txt_period.Text = ReadPulseSet(Cnt).Period / 1000
            UcDacFrame1.ChanDac(Cnt).txt_width.Text = ReadPulseSet(Cnt).Width / 1000
            UcDacFrame1.ChanDac(Cnt).txt_delay.Text = ReadPulseSet(Cnt).Delay / 1000
        Next

        Return True
    End Function
    Public Function DacOnOFfCheck() As Boolean
        'Signal Generator
        '전체 Dac 채널 OnOff 설정읽기
        Dim ret As Integer
        Dim ReadMode() As cDevSG.eOnOff = Nothing


        If myParent.cMcSG(m_nSelDevice).cSG.Get_OnOffAllChannel(devAddr, devCH, ret, ReadMode) = False Then
            Return False

        End If

        For Cnt As Integer = 0 To ReadMode.Length - 1


            If ReadMode(Cnt) = cDevSG.eOnOff.eON Then
                UcDacFrame1.ChanDac(Cnt).gCondition.OnOff = True
                UcDacFrame1.ChanDac(Cnt).btnOnOff.Text = "OFF"
                UcDacFrame1.ChanDac(Cnt).btnOnOff.BackColor = Color.LightGreen

            ElseIf ReadMode(Cnt) = cDevSG.eOnOff.eOFF Then
                UcDacFrame1.ChanDac(Cnt).gCondition.OnOff = False
                UcDacFrame1.ChanDac(Cnt).btnOnOff.Text = "ON"
                UcDacFrame1.ChanDac(Cnt).btnOnOff.BackColor = Color.Blue

            End If

        Next
        Return True
    End Function
#End Region
#Region "Signal Generator Adc"
    Public Sub UcChannelMouseMove(ByVal gCondi As UcADcChannel.Condi)

        For cnt As Integer = 0 To cDevSG.Max_ADC_Channel - 1
            If cnt = gCondi.m_ChannelNum Then
                UcADcFrame1.ChanADc(cnt).BackColor = Color.Khaki

                UcADcFrame1.ChanADc(cnt).Chk_CH.Checked = True
                txt_sCh1.Text = UcADcFrame1.ChanADc(cnt).Chk_CH.Text
            Else
                UcADcFrame1.ChanADc(cnt).BackColor = Color.LightGray

                UcADcFrame1.ChanADc(cnt).Chk_CH.Checked = False
            End If


        Next
        grb_Adc.Enabled = False
    End Sub
    Public Sub UcChannelADcCalSet(ByVal gCondi As UcADcChannel.Condi)
        Dim tDacChNum As Integer = gCondi.m_ChannelNum
        Dim calDlg As New frmSGCalibration(Me)
        calDlg.selectedDevice = m_nSelDevice
        calDlg.ADCCondition = gCondi
        calDlg.Mode = frmSGCalibration.eSetMode.eADCMode
        calDlg.Text = "ADC Calibration Ch " & CStr(Format(tDacChNum, "00"))
        calDlg.ChannelNumber = tDacChNum
        calDlg.Show()

    End Sub
    Public Sub UcChannelADcSetLimitTemp(ByVal gCondi As UcADcChannel.Condi)
        'Signal Generator
        '1채널 Adc Limit 온도 Set

        Dim ret As Integer
        Dim inch As Integer = gCondi.m_ChannelNum
        If inch > 39 Or inch < 24 Then

            MsgBox("선택된 채널은 설정 할 수 없습니다!!")
            Exit Sub
        End If
        inch = inch - 24

        Dim SetLimitTempValue As Double = gCondi.m_LimitValueTemp
        If myParent.cMcSG(m_nSelDevice).cSG.Set_ADcTempLimitOneChannel(devAddr, devCH, ret, SetLimitTempValue, inch) = False Then
            Exit Sub
        End If

        Dim GetLimitTempValue As Double
        If myParent.cMcSG(m_nSelDevice).cSG.Get_ADcTempLimitOneChannel(devAddr, devCH, ret, GetLimitTempValue, inch) = False Then
            Exit Sub
        End If

        UcADcFrame1.ChanADc(inch + 24).txt_readlimittemp.Text = GetLimitTempValue
    End Sub
    Public Sub UcChannelADcCalGet(ByVal gCondi As UcADcChannel.Condi)
        Dim SelectChannelNum As Integer
        Dim inCh As Integer = gCondi.m_ChannelNum
        Dim ReadSlopeValue As Single
        Dim ReadOffsetValue As Single
        Dim ret As Integer



        If myParent.cMcSG(m_nSelDevice).cSG.Get_ADcSlope(devAddr, devCH, ret, ReadSlopeValue, SelectChannelNum) = False Then

            Exit Sub

        End If
        UcADcFrame1.ChanADc(inCh).txt_ratio.Text = ReadSlopeValue

        If myParent.cMcSG(m_nSelDevice).cSG.Get_ADcOffset(devAddr, devCH, ret, ReadOffsetValue, SelectChannelNum) = False Then

            Exit Sub

        End If
        UcADcFrame1.ChanADc(inCh).txt_offset.Text = ReadOffsetValue

    End Sub
    Public Sub UcChannelADcRead(ByVal gCondi As UcADcChannel.Condi)
        'Signal Generator
        '1채널 ADC Read
        Dim ret As Integer
        Dim ReadValue As Double
        Dim inch As Integer = gCondi.m_ChannelNum

        If myParent.cMcSG(m_nSelDevice).cSG.Get_ReadADcOneChannel(devAddr, devCH, ret, ReadValue, inch) = False Then

            Exit Sub
        End If

        Dim ReadSlopeValue As Single
        Dim ReadOffsetValue As Single
        If chk_CalApply.Checked = True Then

            myParent.cMcSG(m_nSelDevice).cSG.Get_ADcSlope(devAddr, devCH, ret, ReadSlopeValue, inch)
            myParent.cMcSG(m_nSelDevice).cSG.Get_ADcOffset(devAddr, devCH, ret, ReadOffsetValue, inch)

            ReadValue = ReadValue * ReadSlopeValue + ReadOffsetValue


        End If

        Dim sum As Double
        Dim aver As Double
        With UcADcFrame1.ChanADc(inch).gCondition
            .m_RealValue = ReadValue
            If ReadValue < .m_Min Then

                .m_Min = ReadValue
            End If

            If ReadValue > .m_Max Then

                .m_Max = ReadValue
            End If
            .m_Count = .m_Count + 1

            If .m_Count > 1 Then

                sum = .m_Average + ReadValue
                aver = sum / 2
                .m_Average = aver
            ElseIf .m_Count = 1 Then

                .m_Average = ReadValue

            End If

            .m_Abs = Math.Abs(.m_Max - .m_Min)


            UcADcFrame1.ChanADc(inch).tbAdcRead.Text = ReadValue
            UcADcFrame1.ChanADc(inch).tbAdcMin.Text = .m_Min
            UcADcFrame1.ChanADc(inch).tbAdcMax.Text = .m_Max
            UcADcFrame1.ChanADc(inch).txt_ABSadc.Text = .m_Abs
            UcADcFrame1.ChanADc(inch).tbAdcAver.Text = .m_Average
            UcADcFrame1.ChanADc(inch).tbAdcCount.Text = .m_Count
        End With




    End Sub
    Public Sub UcChannelADcSetAver(ByVal gCondi As UcADcChannel.Condi)

        Dim ret As Integer
        Dim SetAverCount As Double = gCondi.m_AverageCount
        Dim inch As Integer = gCondi.m_ChannelNum

        If myParent.cMcSG(m_nSelDevice).cSG.Set_ADcAverCountOneChannel(devAddr, devCH, ret, SetAverCount, inch) = False Then
            Exit Sub
        End If

        Dim GetAverCount As Double
        If myParent.cMcSG(m_nSelDevice).cSG.Get_ADcAverCountOneChannel(devAddr, devCH, ret, GetAverCount, inch) = False Then
            Exit Sub
        End If

        UcADcFrame1.ChanADc(inch).txt_readavercount.Text = GetAverCount
    End Sub
    Public Sub UcChannelADcSetLimit(ByVal gCondi As UcADcChannel.Condi)

        Dim ret As Integer
        Dim SetLimitValue As Double = gCondi.m_LimitValue
        Dim inch As Integer = gCondi.m_ChannelNum
        If inch < 40 Then

            MsgBox("선택된 채널은 설정 할 수 없습니다!!")
            Exit Sub
        End If
        inch = inch - 40
        If myParent.cMcSG(m_nSelDevice).cSG.Set_ADcLimitOneChannel(devAddr, devCH, ret, SetLimitValue, inch) = False Then
            Exit Sub
        End If

        Dim GetLimitValue As Double
        If myParent.cMcSG(m_nSelDevice).cSG.Get_ADcLimitOneChannel(devAddr, devCH, ret, GetLimitValue, inch) = False Then
            Exit Sub
        End If

        UcADcFrame1.ChanADc(inch + 40).txt_readlimitcurr.Text = GetLimitValue
    End Sub
    Public Sub UcChannelADcCheckClick(ByVal gCondi As UcADcChannel.Condi)
        Dim tChkCnt As Integer = 0
        Dim tChkLimitTemp As Boolean = True
        Dim tChkLimitCurr As Boolean = True

        Dim tTempString As String = ""
        For cnt As Integer = 0 To cDevSG.Max_ADC_Channel - 1

            If UcADcFrame1.ChanADc(cnt).Chk_CH.Checked = True Then
                UcADcFrame1.ChanADc(cnt).BackColor = Color.Khaki
                tTempString = tTempString & UcADcFrame1.ChanADc(cnt).Chk_CH.Text & " , "
                tChkCnt = tChkCnt + 1


                If cnt >= myParent.cMcSG(m_nSelDevice).cSG.TempSenserStartChannel - 1 And cnt <= myParent.cMcSG(m_nSelDevice).cSG.TempSenseEndChannel - 1 Then

                Else
                    tChkLimitTemp = False
                End If


                If cnt >= myParent.cMcSG(m_nSelDevice).cSG.CurrentSenseStartChannel - 1 And cnt <= myParent.cMcSG(m_nSelDevice).cSG.CurrentSenseEndChannel - 1 Then

                Else
                    tChkLimitCurr = False
                End If


            ElseIf UcADcFrame1.ChanADc(cnt).Chk_CH.Checked = False Then
                UcADcFrame1.ChanADc(cnt).BackColor = Color.LightGray

            End If


        Next

        txt_sCh1.Text = tTempString

        If tChkLimitCurr = True Then
            btn_multiLimitCurr.Enabled = True
        Else
            btn_multiLimitCurr.Enabled = False
        End If


        If tChkLimitTemp = True Then
            btn_multiLimittemp.Enabled = True
        Else
            btn_multiLimittemp.Enabled = False
        End If

        If tChkCnt > 1 Then

            grb_Adc.Enabled = True

        Else
            grb_Adc.Enabled = False
        End If
    End Sub
#End Region
#Region "Signal Generator GPIO"


    Public Sub UcGPO_Set(ByVal gCondi As Ucgpio.Condi)
        Dim ret As Integer
        Dim SetValue As Double = gCondi.m_GPO
        myParent.cMcSG(m_nSelDevice).cSG.Set_GPO_Out(devAddr, devCH, ret, SetValue)

    End Sub


    Public Sub UcGPO_Read(ByVal gCondi As Ucgpio.Condi)
        Dim GetValue() As Boolean = Nothing
        Dim ret As Integer
        myParent.cMcSG(m_nSelDevice).cSG.Get_GPO_Out(devAddr, devCH, ret, GetValue)


        Dim ctrGPO() As CheckBox
        With Ucgpio1
            ctrGPO = {.chkPO0, .chkPO1, .chkPO2, .chkPO3, .chkPO4, .chkPO5, .chkPO6, .chkPO7, .chkPO8, .chkPO9, .chkPO10, .chkPO11, .chkPO12, .chkPO13, .chkPO14, .chkPO15}

        End With

        For Cnt As Integer = 0 To GetValue.Length - 1

            ctrGPO(Cnt).Checked = GetValue(Cnt)
        Next
    End Sub
    Public Sub UcGPIO_OutSet(ByVal gCondi As Ucgpio.Condi)
        'Signal Generator
        'GPIO INPUT & OUTPUT 설정

        Dim ret As Integer
        Dim SetValue As Double = gCondi.m_GPIO_D


        myParent.cMcSG(m_nSelDevice).cSG.Set_GPIO_Out(devAddr, devCH, ret, SetValue)


    End Sub
    Public Sub UcGPIO_OutRead(ByVal gCondi As Ucgpio.Condi)
        Dim ret As Integer
        Dim GetValue() As Boolean = Nothing
        Dim ctrGPO() As CheckBox
        With Ucgpio1
            ctrGPO = {.chkGPIOD0, .chkGPIOD1, .chkGPIOD2, .chkGPIOD3, .chkGPIOD4, .chkGPIOD5, .chkGPIOD6, .chkGPIOD7, .chkGPIOD8, .chkGPIOD9, .chkGPIOD10, .chkGPIOD11, .chkGPIOD12, .chkGPIOD13, .chkGPIOD14, .chkGPIOD15}

        End With

        If myParent.cMcSG(m_nSelDevice).cSG.Get_GPIO_Out(devAddr, devCH, ret, GetValue) = False Then

            Exit Sub
        End If


        For Cnt As Integer = 0 To GetValue.Length - 1

            ctrGPO(Cnt).Checked = GetValue(Cnt)
        Next
    End Sub


    Public Sub UcGPIO_IN_Read(ByVal gCondi As Ucgpio.Condi)
        Dim GetValue() As Double = Nothing
        Dim ret As Integer
        Dim ctrGpioIn() As CheckBox
        With Ucgpio1
            ctrGpioIn = {.chkGPIOIn_I0, .chkGPIOIn_1, .chkGPIOIn2, .chkGPIOIn3, .chkGPIOIn4, .chkGPIOIn5, .chkGPIOIn6, .chkGPIOIn7, .chkGPIOIn8, .chkGPIOIn9, .chkGPIOIn10, .chkGPIOIn11, .chkGPIOIn12, .chkGPIOIn13, .chkGPIOIn14, .chkGPIOIn15}
            'For i As Integer = 0 To 15
            '    If ctrGpioIn(i).Checked = True Then
            '        SetValue += 2 ^ i
            '    End If
            'Next
        End With

        Dim strRcvData As String = ""

        myParent.cMcSG(m_nSelDevice).cSG.Get_GPIO_ReadIN(devAddr, devCH, ret, GetValue)
        For Cnt As Integer = 0 To GetValue.Length - 1

            ctrGpioIn(Cnt).Checked = GetValue(Cnt)
        Next
    End Sub
    Public Sub UcGPIO_Out_Set(ByVal gCondi As Ucgpio.Condi)

        'Signal Generator
        'GPIO OUTPUT ONOFF 설정 
        Dim SetValue As Double = gCondi.m_GPIO_O
        Dim ret As Integer

        myParent.cMcSG(m_nSelDevice).cSG.Set_GPIO_OnOff(devAddr, devCH, ret, SetValue)

    End Sub
    Public Sub UcGPIO_Out_Read(ByVal gCondi As Ucgpio.Condi)
        Dim GetValue() As Boolean = Nothing
        Dim ret As Integer
        Dim ctlGpioOut() As CheckBox
        With Ucgpio1
            ctlGpioOut = {.chkGPIOOut_0, .chkGPIOOut_1, .chkGPIOOut_I2, .chkGPIOOut_3, .chkGPIOOut_4, .chkGPIOOut_5, .chkGPIOOut_6, .chkGPIOOut_7, .chkGPIOOut_8, .chkGPIOOut_9, .chkGPIOOut_10, .chkGPIOOut_11, .chkGPIOOut_12, .chkGPIOOut_13, .chkGPIOOut_14, .chkGPIOOut_15}


        End With

        myParent.cMcSG(m_nSelDevice).cSG.Get_GPIO_OnOff(devAddr, devCH, ret, GetValue)


        For Cnt As Integer = 0 To GetValue.Length - 1

            ctlGpioOut(Cnt).Checked = GetValue(Cnt)
        Next
    End Sub





#End Region

    Sub init_Portlist(ByVal cmbbox As ComboBox)

        Dim comPorts() As String = Nothing
        CComSerial.FindComPorts(comPorts)

        cmbbox.DataSource = comPorts.Clone
        cmbbox.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim ret As Integer

        myParent.cMcSG(m_nSelDevice).cSG.cReset(devAddr, devCH, ret)
        tbError.Text = ret

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmSGSendRecieveLog.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim ret As Integer
        myParent.cMcSG(m_nSelDevice).cSG.cResisterInit(devAddr, devCH, ret)
        tbError.Text = ret
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Dim tStr As String = Nothing
        Dim ret As Integer
        myParent.cMcSG(m_nSelDevice).cSG.cResisterRead(devAddr, devCH, tStr, ret)
        TextBox2.Text = tStr
        tbError.Text = ret

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim tint As Integer
        Dim ret As Integer
        myParent.cMcSG(m_nSelDevice).cSG.cComplete(devAddr, devCH, tint, ret)
        TextBox1.Text = tint
        tbError.Text = ret

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim ret As Integer
        myParent.cMcSG(m_nSelDevice).cSG.cSaveData(devAddr, devCH, ret)
        tbError.Text = ret

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click

        Dim configinfo As CComSerial.sSerialPortInfo = m_Config(m_nSelDevice).sSerialInfo
        'configinfo.sPortName = cboPort.Text
        'configinfo.nBaudRate = cbBaudRate.Text
        'configinfo.nDataBits = 8
        'configinfo.nHandShake = Ports.Handshake.None
        'configinfo.nParity = Ports.Parity.None
        'configinfo.nStopBits = Ports.StopBits.One
        'configinfo.sTerminator = vbCrLf
        'configinfo.sCMDTerminator = vbCrLf

        If myParent.cMcSG(m_nSelDevice).cSG.IsConnected = False Then

            If myParent.cMcSG(m_nSelDevice).Connection(m_Config(m_nSelDevice)) = True Then
                'cDevSG.PowerReadCal(devAddr, devCH)
                'cDevSG.SenseReadCal(devAddr, devCH)
                InitDAc()
                DacReadSetData()
                txt_err.Text = "Connect"
                MsgBox("연결 성공", MsgBoxStyle.Critical, "Care!!")
                btnConnection.BackColor = Color.Green
                btnConnection.Enabled = False
            Else
                txt_err.Text = "DisConnect"
                myParent.cMcSG(m_nSelDevice).Disconnection()
                MsgBox("연결 실패", MsgBoxStyle.Critical, "Care!!")
                btnConnection.BackColor = Color.Red
                btnConnection.Enabled = True
            End If
        End If

    End Sub
    Public Function InitDAc() As Boolean
        Return DacOnOFfCheck()
    End Function

    Public Function fSGConnection(ByVal inConfig As CComSerial.sSerialPortInfo) As Boolean

        'If myParent.cMcSG(m_nSelDevice).Connection(inConfig) = True Then

        '    Dim ret As Integer

        '    tbError.Text = ret

        '    Return myParent.cMcSG(m_nSelDevice).cSG.cPing(devAddr, devCH, ret)
        'End If

        'Return False
        Return True
    End Function


    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnection.Click
        myParent.cMcSG(m_nSelDevice).DisConnection()
        btnConnection.BackColor = Color.Red
        btnConnection.Enabled = True
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim ret As Integer
        Dim tError As Boolean
        Dim tListArr(1) As String
        Dim boardInfos As cDevSG.sBoardInfo = Nothing

        tError = myParent.cMcSG(m_nSelDevice).cSG.cBoardInfo(devAddr, devCH, boardInfos, ret)
        tbError.Text = ret

        If tError = True Then
            UcSingleList1.ClearAllData()

            '/////////////// Model //////////////////////
            tListArr(0) = "Model"
            tListArr(1) = boardInfos.sModel

            UcSingleList1.AddRowData(tListArr)

            tListArr(0) = "Serial No"
            tListArr(1) = boardInfos.sSerialNo

            UcSingleList1.AddRowData(tListArr)
           
            tListArr(0) = "Date"
            tListArr(1) = boardInfos.sDate

            UcSingleList1.AddRowData(tListArr)
           
            tListArr(0) = "Firmware Ver"
            tListArr(1) = boardInfos.sFirmwareVer

            UcSingleList1.AddRowData(tListArr)

            tListArr(0) = "Fpga Ver"
            tListArr(1) = boardInfos.sFPGAVer

            UcSingleList1.AddRowData(tListArr)

            tListArr(0) = "Dac Channel"
            tListArr(1) = boardInfos.nDACChannel

            UcSingleList1.AddRowData(tListArr)

            tListArr(0) = "ADC Channel"
            tListArr(1) = boardInfos.nADCChannel

            UcSingleList1.AddRowData(tListArr)

            tListArr(0) = "Aux Channel"
            tListArr(1) = boardInfos.nAUXChannel

            UcSingleList1.AddRowData(tListArr)

        End If
    End Sub


    Private Sub UcDataGridView1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '   AddHandler UcDataGridView1.GridClick, AddressOf fDacRead

    End Sub
#Region "DAC Click"

    'Public Function fDacRead() As Boolean
    '    Dim tC() As Integer
    '    Dim tR() As Integer

    '    Dim ret As Integer = UcDataGridView1.CheckGridClick(tR, tC)

    '    If ret = ucDataGridView.eUcGridSelect.eOne Then

    '        If tC(0) = 1 Then

    '        ElseIf tC(0) = 3 Then

    '        End If

    '    End If
    'End Function


#End Region

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        If cboType.SelectedIndex = 0 Then
            'DAC
            UcDacFrame1.Visible = True
            UcADcFrame1.Visible = False
            Ucgpio1.Visible = False
        ElseIf cboType.SelectedIndex = 1 Then
            'ADC
            UcDacFrame1.Visible = False
            UcADcFrame1.Visible = True
            Ucgpio1.Visible = False
        ElseIf cboType.SelectedIndex = 2 Then
            'GPIO
            UcDacFrame1.Visible = True
            UcADcFrame1.Visible = True
            Ucgpio1.Visible = True

        End If
    End Sub




    Private Sub btn_set1ch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_set1ch.Click

        'Signal Generator
        '1채널 Dac OutPut 설정 
        Dim ret As Integer
        Dim SetValue As Double = 3
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 107

        myParent.cMcSG(m_nSelDevice).cSG.Set_OutputOneChannel(devAddr, devCH, ret, SetValue, SelectChannelNum)  '(에러코드 , 설정 값 , 설정 할 채널 넘버)


    End Sub

    Private Sub btn_get1ch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_get1ch.Click
        'Signal Generator
        '1채널 Dac 설정값 읽기
        Dim ret As Integer
        Dim ReadValue As Double
        Dim SelectChannelNum As Integer = 0  'max channel 108

        myParent.cMcSG(m_nSelDevice).cSG.Get_OutputOneChannel(devAddr, devCH, ret, ReadValue, SelectChannelNum) '(에러코드 , 읽을  값 , 읽을 채널 넘버)

    End Sub

    Private Sub btn_setallch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setallch.Click
        'Signal Generator
        '전체 Dac 채널 설정
        Dim ret As Integer
        Dim SetValue() As Double
        Dim MaxChannel As Integer = cDevSG.Max_DAC_Channel

        ReDim SetValue(cDevSG.Max_DAC_Channel) 'max channel 108

        For Cnt As Integer = 0 To MaxChannel - 1
            SetValue(Cnt) = 3 'Volt 값
        Next
        '채널은 0 ~ 107 채널 만 가능
        myParent.cMcSG(m_nSelDevice).cSG.Set_OutputAllChannel(devAddr, devCH, ret, SetValue) '(에러코드 , 설정 할 전체 채널 값 배열() , 설정할 전체 채널 갯수)
    End Sub

    Private Sub btn_getallch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getallch.Click
        'Signal Generator
        '전체 채널Dac 설정 값 읽기
        Dim ret As Integer
        Dim ReadValue() As Double = Nothing

        myParent.cMcSG(m_nSelDevice).cSG.Get_OutputAllChannel(devAddr, devCH, ret, ReadValue) '(에러코드 , 설정 할 전체 채널 값 배열() , 설정할 전체 채널 갯수)
    End Sub

    Private Sub btn_setmode1ch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setmode1ch.Click
        'Signal Generator
        '개별 채널 Dac 출력 모드 설정
        Dim ret As Integer
        Dim SetMode As cDevSG.eDacMode = cDevSG.eDacMode.ePulseMode
        Dim SelectChannelNum As Integer = 0 'ch 0 ~ 53 만 가능

        myParent.cMcSG(m_nSelDevice).cSG.Set_SelectModeOneChannel(devAddr, devCH, ret, SetMode, SelectChannelNum) '(에러코드 , 설정 할 Mode 0:DC Mode , 1:Pulse Mode  , 설정할  채널 )
    End Sub

    Private Sub btn_Getmode1ch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Getmode1ch.Click
        'Signal Generator
        '개별 채널 Dac 출력 모드 설정 읽기
        Dim ret As Integer
        Dim SetMode As cDevSG.eDacMode
        Dim SelectChannelNum As Integer = 0 'ch 0 ~ 53 만 가능

        myParent.cMcSG(m_nSelDevice).cSG.Get_SelectModeOneChannel(devAddr, devCH, ret, SetMode, SelectChannelNum) '(에러코드 , 설정  Mode 0:DC Mode , 1:Pulse Mode  , 설정할  채널 )


    End Sub

    Private Sub btn_setmodeallch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setmodeallch.Click
        'Signal Generator
        '전체 채널 Dac 출력 모드 설정
        Dim ret As Integer
        Dim SetMode() As cDevSG.eDacMode
        Dim MaxChannel As Integer = cDevSG.Max_Pulse_Channel

        ReDim SetMode(MaxChannel - 1) 'max ch54
        For Cnt As Integer = 0 To MaxChannel - 1
            SetMode(Cnt) = cDevSG.eDacMode.ePulseMode
        Next

        myParent.cMcSG(m_nSelDevice).cSG.Set_SelectModeAllChannel(devAddr, devCH, ret, SetMode) '(에러코드 , 설정 할 Mode 0:DC Mode , 1:Pulse Mode  , 설정할  채널 )
    End Sub

    Private Sub btn_getmodeallch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getmodeallch.Click
        'Signal Generator
        '전체 채널 Dac 출력 모드 설정 읽기
        Dim ret As Integer
        Dim SetMode() As cDevSG.eDacMode = Nothing 'max ch54

        myParent.cMcSG(m_nSelDevice).cSG.Get_SelectModeAllChannel(devAddr, devCH, ret, SetMode) '(에러코드 , 설정 Mode 0:DC Mode , 1:Pulse Mode  , 설정할  채널 )
    End Sub


    Private Sub btn_chaddrset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_chaddrset.Click

        Try
            If Int(txt_addrs.Text) >= 0 And Int(txt_ch.Text) >= 0 Then
                devAddr = Int(txt_addrs.Text)
                devCH = Int(txt_ch.Text)
            Else
                MsgBox("설정 값은 0 보다 커야 합니다.")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub bnt_set1chOnoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnt_set1chOnoff.Click
        'Signal Generator
        '개별 Dac 채널 OnOff 설정
        Dim ret As Integer
        Dim SetMode As cDevSG.eOnOff = cDevSG.eOnOff.eOFF
        Dim SelectChannelNum As Integer = 0 'ch 0 ~ 53 max ch 54

        myParent.cMcSG(m_nSelDevice).cSG.Set_OnoffOneChannel(devAddr, devCH, ret, SetMode, SelectChannelNum) '(에러코드 , 설정 할 Onoff 0:Off Mode , 1:On Mode  , 설정할  채널 ( 0 ~ 53 ))
    End Sub

    Private Sub bnt_get1chOnoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnt_get1chOnoff.Click
        'Signal Generator
        '개별 Dac 채널 OnOff 설정 읽기
        Dim ret As Integer
        Dim ReadMode As cDevSG.eOnOff
        Dim SelectChannelNum As Integer = 0 'ch 0 ~ 53 max ch 54

        myParent.cMcSG(m_nSelDevice).cSG.Get_OnoffOneChannel(devAddr, devCH, ret, ReadMode, SelectChannelNum) '(에러코드 , 설정 할 Onoff 0:Off Mode , 1:On Mode  , 설정할  채널 ( 0 ~ 53 ))
    End Sub


    Private Sub bnt_setallchOnoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnt_setallchOnoff.Click
        'Signal Generator
        '전체 Dac 채널 OnOff 설정
        Dim ret As Integer
        Dim SetMode() As cDevSG.eOnOff
        Dim MaxChannel As Integer = cDevSG.Max_Pulse_Channel
        ReDim SetMode(MaxChannel - 1) 'max ch 54
        For cnt As Integer = 0 To MaxChannel - 1
            SetMode(cnt) = cDevSG.eOnOff.eOFF
        Next

        myParent.cMcSG(m_nSelDevice).cSG.Set_OnOffAllChannel(devAddr, devCH, ret, SetMode) '(에러코드 , 설정 할 Onoff 0:Off Mode , 1:On Mode  , max  채널 54)
    End Sub

    Private Sub bnt_getallchOnoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnt_getallchOnoff.Click
        'Signal Generator
        '전체 Dac 채널 OnOff 설정읽기
        Dim ret As Integer
        Dim ReadMode() As cDevSG.eOnOff = Nothing


        myParent.cMcSG(m_nSelDevice).cSG.Get_OnOffAllChannel(devAddr, devCH, ret, ReadMode) '(에러코드 , 설정  Onoff 0:Off Mode , 1:On Mode  , max  채널 54)
    End Sub


    Private Sub bnt_set1chfOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnt_set1chfOutput.Click
        'Signal Generator
        '개별Dac 채널 Final output 설정
        Dim ret As Integer
        Dim SetMode As cDevSG.eFoutput = cDevSG.eFoutput.eLow
        Dim SelectChannelNum As Integer = 0 'ch 0 ~ 53

        myParent.cMcSG(m_nSelDevice).cSG.Set_FinalOutputOneChannel(devAddr, devCH, ret, SetMode, SelectChannelNum) '(에러코드 , 설정 할 Mode 0:Even Mode , 1:ODD Mode  , 설정할  채널 ( 0 ~ 53 ))
    End Sub

    Private Sub bnt_Get1chfOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnt_Get1chfOutput.Click
        'Signal Generator
        '개별Dac 채널 Final output 설정 읽기
        Dim ret As Integer
        Dim ReadFOutput As cDevSG.eFoutput
        Dim SelectChannelNum As Integer = 0 'ch 0 ~ 53

        myParent.cMcSG(m_nSelDevice).cSG.Get_FinalOutputOneChannel(devAddr, devCH, ret, ReadFOutput, SelectChannelNum) '(에러코드 , 설정 할 Mode 0:Even Mode , 1:ODD Mode  , 설정할  채널 ( 0 ~ 53 ))
    End Sub


    Public Sub UcCh_AllChk(ByVal inChkBool As Boolean)
        Dim Cnt As Integer
        Dim MaxChannel As Integer = cDevSG.Max_Pulse_Channel
        If cboType.SelectedIndex = 0 Then
            For Cnt = 0 To MaxChannel - 1


                UcDacFrame1.ChanDac(Cnt).Chk_CH.Checked = inChkBool

            Next

            grb_Dac.Enabled = True
            Dim gCondi As UcDacChannel.Condi = Nothing
            UcChannelDacCheckClick(gCondi)

        ElseIf cboType.SelectedIndex = 1 Then
            For Cnt = 0 To MaxChannel - 1


                UcADcFrame1.ChanADc(Cnt).Chk_CH.Checked = inChkBool

            Next
            grb_Adc.Enabled = inChkBool
            Dim gCondi As UcADcChannel.Condi
            UcChannelADcCheckClick(gCondi)
        End If




    End Sub

    Private Sub Chk_All_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_All.CheckedChanged
        UcCh_AllChk(Chk_All.Checked)
    End Sub


    Private Sub btn_setalarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setalarm.Click
        'Signal Generator
        ' Limit Alarm 초기화
        Dim ret As Integer
        '  Dim TotalChannelNum As Integer = 

        myParent.cMcSG(m_nSelDevice).cSG.Set_LimitAlarm(devAddr, devCH, ret) '(에러코드 ,설정 할 전체 채널 수 )
    End Sub

    Private Sub btn_GetAalarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GetAalarm.Click
        'Signal Generator
        ' Limit Alarm 조회
        Dim ret As Integer
        Dim ReadAlarm() As cDevSG.eLimitAlarm = Nothing


        myParent.cMcSG(m_nSelDevice).cSG.Get_LimitAlarm(devAddr, devCH, ret, ReadAlarm) '(에러코드 ,설정 할 전체 채널 수 ) 'ch 56
    End Sub
    Private Sub bnt_setallchfOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnt_setallchfOutput.Click
        'Signal Generator
        '전체 Dac 채널 Final output 설정
        Dim ret As Integer
        Dim SetMode() As cDevSG.eFoutput
        Dim MaxChannel As Integer = cDevSG.Max_Pulse_Channel
        ReDim SetMode(MaxChannel - 1) 'max ch 54
        For cnt As Integer = 0 To MaxChannel - 1
            SetMode(cnt) = cDevSG.eFoutput.eLow
        Next


        myParent.cMcSG(m_nSelDevice).cSG.Set_FinalOutputAllChannel(devAddr, devCH, ret, SetMode) '(에러코드 , 설정 할 Mode 0:Even Mode , 1:ODD Mode  , max ch 54)
    End Sub
    Private Sub bnt_getallchfOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnt_getallchfOutput.Click
        'Signal Generator
        '전체 Dac 채널 Final output 설정 읽기
        Dim ret As Integer
        Dim ReadFOutput() As cDevSG.eFoutput = Nothing 'max ch 54
        myParent.cMcSG(m_nSelDevice).cSG.Get_FinalOutputAllChannel(devAddr, devCH, ret, ReadFOutput) '(에러코드 , 설정 할 Mode 0:Even Mode , 1:ODD Mode  , max ch 54)


    End Sub

    Private Sub bnt_set1chpulse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnt_set1chpulse.Click
        'Signal Generator
        '개별 Dac 채널 Pulse 설정
        Dim ret As Integer
        Dim SetMode As cDevSG.sPulseParam
        With SetMode
            .Period = 500
            .Width = 100

            .Delay = 100
        End With

        Dim SelectChannelNum As Integer = 3 'ch 0 ~ 53

        myParent.cMcSG(m_nSelDevice).cSG.Set_PulseOneChannel(devAddr, devCH, ret, SetMode, SelectChannelNum) '(에러코드 , 설정 할 Width : 상승 구간 Delay : 지연구간 Period : 주기  , 설정할  채널 ( 0 ~ 53 ))
    End Sub

    Private Sub bnt_get1chpulse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnt_get1chpulse.Click
        'Signal Generator
        '개별 Dac 채널 Pulse 설정 읽기
        Dim ret As Integer
        Dim Getpulse As cDevSG.sPulseParam

        Dim SelectChannelNum As Integer = 0 'ch 0 ~ 53

        myParent.cMcSG(m_nSelDevice).cSG.Get_PulseOneChannel(devAddr, devCH, ret, Getpulse, SelectChannelNum) '(에러코드 , 설정 할 Width : 상승 구간 Delay : 지연구간 Period : 주기  , 설정할  채널 ( 0 ~ 53 ))
    End Sub

    Private Sub bnt_setallchpulse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnt_setallchpulse.Click
        'Signal Generator
        '전체 Dac 채널 Pulse 설정
        Dim ret As Integer
        Dim SetMode() As cDevSG.sPulseParam
        Dim MaxChannel As Integer = cDevSG.Max_Pulse_Channel
        ReDim SetMode(MaxChannel - 1) 'max ch 54
        For cnt As Integer = 0 To MaxChannel - 1
            With SetMode(cnt)
                SetMode(cnt).Width = 500
                SetMode(cnt).Period = 1000
                SetMode(cnt).Delay = 100
            End With
        Next


        myParent.cMcSG(m_nSelDevice).cSG.Set_PulseAllChannel(devAddr, devCH, ret, SetMode) '(에러코드 , 설정 할 Width : 상승 구간 Delay : 지연구간 Period : 주기  ,max ch 54)
    End Sub

    Private Sub bnt_getallchpulse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnt_getallchpulse.Click
        'Signal Generator
        '전체 Dac 채널 Pulse 설정 읽기
        Dim ret As Integer
        Dim SetMode() As cDevSG.sPulseParam = Nothing


        myParent.cMcSG(m_nSelDevice).cSG.Get_PulseAllChannel(devAddr, devCH, ret, SetMode) '(에러코드 , 설정 할 Width : 상승 구간 Delay : 지연구간 Period : 주기  ,max ch 54)
    End Sub

    Private Sub btn_readadc1ch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_readadc1ch.Click
        'Signal Generator
        '1채널 ADC Read
        Dim ret As Integer
        Dim ReadValue As Double
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 55

        myParent.cMcSG(m_nSelDevice).cSG.Get_ReadADcOneChannel(devAddr, devCH, ret, ReadValue, SelectChannelNum)

    End Sub


    Private Sub btn_readadcallch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_readadcallch.Click
        'Signal Generator
        '전체 채널 ADC Read
        Dim ret As Integer
        Dim ReadValue() As Double = Nothing
        Dim MaxChannel As Integer = cDevSG.Max_ADC_Channel
        myParent.cMcSG(m_nSelDevice).cSG.Get_ReadADcAllChannel(devAddr, devCH, ret, ReadValue) '(에러코드 , 설정 할 전체 채널 값 배열() , 설정할 전체 채널 갯수)
    End Sub

    Private Sub btn_Setaver1ch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Setaver1ch.Click
        'Signal Generator
        '1채널 Adc Aver Set

        Dim ret As Integer
        Dim SetCount As Double = 101
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 55

        myParent.cMcSG(m_nSelDevice).cSG.Set_ADcAverCountOneChannel(devAddr, devCH, ret, SetCount, SelectChannelNum)
    End Sub

    Private Sub btn_getaver1ch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getaver1ch.Click
        'Signal Generator
        '1채널 Adc Aver Set Read

        Dim ret As Integer
        Dim ReadValue As Double
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 55

        myParent.cMcSG(m_nSelDevice).cSG.Get_ADcAverCountOneChannel(devAddr, devCH, ret, ReadValue, SelectChannelNum)
    End Sub

    Private Sub btn_setlimit1ch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setlimit1ch.Click
        'Signal Generator
        '1채널 Adc Limit 전류 Set

        Dim ret As Integer
        Dim SetValue As Double = 2
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 15 , adc - 41 ~ 56

        myParent.cMcSG(m_nSelDevice).cSG.Set_ADcLimitOneChannel(devAddr, devCH, ret, SetValue, SelectChannelNum)
    End Sub

    Private Sub btn_getlimit1ch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getlimit1ch.Click
        'Signal Generator
        '1채널 Adc Limit 전류 Set Read

        Dim ret As Integer
        Dim ReadValue As Double
        Dim SelectChannelNum As Integer = 0 ' 'Channel 0 ~ 15 , adc - 41 ~ 56

        myParent.cMcSG(m_nSelDevice).cSG.Get_ADcLimitOneChannel(devAddr, devCH, ret, ReadValue, SelectChannelNum)
    End Sub
    Private Sub btn_setlimitallch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setlimitallch.Click
        'Signal Generator
        '전체 채널 Adc Limit전류 Set

        Dim ret As Integer
        Dim SetValue() As Double


        Dim MaxChannel As Integer = cDevSG.Max_ADC_Limit_Channel

        ReDim SetValue(MaxChannel - 1)
        For cnt As Integer = 0 To MaxChannel - 1 'Channel 0 ~ 15 , adc - 41 ~ 56
            SetValue(cnt) = 2
        Next


        myParent.cMcSG(m_nSelDevice).cSG.Set_ADcLimitAllChannel(devAddr, devCH, ret, SetValue)
    End Sub
    Private Sub btn_getlimitallch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getlimitallch.Click
        'Signal Generator
        '전체 채널 Adc Limit전류 Set read

        Dim ret As Integer
        Dim SetValue() As Double = Nothing ' 'Channel 0 ~ 15 , adc - 41 ~ 56

        myParent.cMcSG(m_nSelDevice).cSG.Get_ADcLimitAllChannel(devAddr, devCH, ret, SetValue)
    End Sub


    Private Sub btn_setlimitTemp1ch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setlimitTemp1ch.Click
        'Signal Generator
        '1채널 Adc Limit 온도 Set

        Dim ret As Integer
        Dim SetValue As Double = 2
        Dim SelectChannelNum As Integer = 0 ' 'Channel 0 ~ 15 , adc - 25 ~40

        myParent.cMcSG(m_nSelDevice).cSG.Set_ADcTempLimitOneChannel(devAddr, devCH, ret, SetValue, SelectChannelNum)
    End Sub

    Private Sub btn_GetlimitTemp1ch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GetlimitTemp1ch.Click
        'Signal Generator
        '1채널 Adc Limit 온도 Set Read

        Dim ret As Integer
        Dim ReadValue As Double
        Dim SelectChannelNum As Integer = 0 ' 'Channel 0 ~ 15 , adc - 25 ~40

        myParent.cMcSG(m_nSelDevice).cSG.Get_ADcTempLimitOneChannel(devAddr, devCH, ret, ReadValue, SelectChannelNum)
    End Sub

    Private Sub btn_setlimitTempallch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setlimitTempallch.Click
        'Signal Generator
        '전체 채널 Adc Limit 온도 Set

        Dim ret As Integer
        Dim SetValue() As Double

        Dim MaxChannel As Integer = cDevSG.Max_ADC_Limit_Channel
        ReDim SetValue(MaxChannel - 1)
        For cnt As Integer = 0 To MaxChannel - 1 ' 'Channel 0 ~ 15 , adc - 25 ~40
            SetValue(cnt) = 10
        Next


        myParent.cMcSG(m_nSelDevice).cSG.Set_ADcTempLimitAllChannel(devAddr, devCH, ret, SetValue)
    End Sub

    Private Sub btn_getlimitTempallch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getlimitTempallch.Click
        'Signal Generator
        '전체 채널 Adc Limit 온도 Set read

        Dim ret As Integer
        Dim SetValue() As Double = Nothing

        myParent.cMcSG(m_nSelDevice).cSG.Get_ADcTempLimitAllChannel(devAddr, devCH, ret, SetValue)
    End Sub


    Private Sub btn_gpio_Inputset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gpio_Inputset.Click
        'Signal Generator
        'GPIO INPUT & OUTPUT 설정

        Dim ret As Integer
        Dim SetValue As Double
        Dim ctrGPO() As CheckBox
        With Ucgpio1
            ctrGPO = {.chkGPIOD0, .chkGPIOD1, .chkGPIOD2, .chkGPIOD3, .chkGPIOD4, .chkGPIOD5, .chkGPIOD6, .chkGPIOD7, .chkGPIOD8, .chkGPIOD9, .chkGPIOD10, .chkGPIOD11, .chkGPIOD12, .chkGPIOD13, .chkGPIOD14, .chkGPIOD15}

        End With

        For i As Integer = 0 To 15
            If ctrGPO(i).Checked = True Then '체크 된 항목만 output  설정
                SetValue += 2 ^ i
            End If
        Next


        myParent.cMcSG(m_nSelDevice).cSG.Set_GPIO_Out(devAddr, devCH, ret, SetValue)
    End Sub

    Private Sub btn_gpio_Inputget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gpio_Inputget.Click
        'Signal Generator
        'GPIO INPUT & OUTPUT 설정 읽기

        Dim ret As Integer
        Dim SetValue() As Boolean = Nothing
        Dim ctrGPO() As CheckBox = Nothing
        With Ucgpio1
            ctrGPO = {.chkGPIOD0, .chkGPIOD1, .chkGPIOD2, .chkGPIOD3, .chkGPIOD4, .chkGPIOD5, .chkGPIOD6, .chkGPIOD7, .chkGPIOD8, .chkGPIOD9, .chkGPIOD10, .chkGPIOD11, .chkGPIOD12, .chkGPIOD13, .chkGPIOD14, .chkGPIOD15}

        End With

        myParent.cMcSG(m_nSelDevice).cSG.Get_GPIO_Out(devAddr, devCH, ret, SetValue)


        For Cnt As Integer = 0 To SetValue.Length - 1

            ctrGPO(Cnt).Checked = SetValue(Cnt)
        Next
    End Sub

    Private Sub btn_setgpio_out_onoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setgpio_out_onoff.Click

        'Signal Generator
        'GPIO OUTPUT ONOFF 설정 
        Dim SetValue As Double
        Dim ret As Integer
        With Ucgpio1
            Dim ctlGpioOut() As CheckBox = {.chkGPIOOut_0, .chkGPIOOut_1, .chkGPIOOut_I2, .chkGPIOOut_3, .chkGPIOOut_4, .chkGPIOOut_5, .chkGPIOOut_6, .chkGPIOOut_7, .chkGPIOOut_8, .chkGPIOOut_9, .chkGPIOOut_10, .chkGPIOOut_11, .chkGPIOOut_12, .chkGPIOOut_13, .chkGPIOOut_14, .chkGPIOOut_15}
            For i As Integer = 0 To 15
                If ctlGpioOut(i).Checked = True Then
                    SetValue += 2 ^ i
                End If
            Next
        End With
        myParent.cMcSG(m_nSelDevice).cSG.Set_GPIO_OnOff(devAddr, devCH, ret, SetValue)
    End Sub

    Private Sub btn_getgpio_out_onoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getgpio_out_onoff.Click
        'Signal Generator
        'GPIO OUTPUT ONOFF 설정 읽기
        Dim SetValue() As Boolean = Nothing
        Dim ret As Integer
        Dim ctlGpioOut() As CheckBox = Nothing
        With Ucgpio1
            ctlGpioOut = {.chkGPIOOut_0, .chkGPIOOut_1, .chkGPIOOut_I2, .chkGPIOOut_3, .chkGPIOOut_4, .chkGPIOOut_5, .chkGPIOOut_6, .chkGPIOOut_7, .chkGPIOOut_8, .chkGPIOOut_9, .chkGPIOOut_10, .chkGPIOOut_11, .chkGPIOOut_12, .chkGPIOOut_13, .chkGPIOOut_14, .chkGPIOOut_15}


        End With

        myParent.cMcSG(m_nSelDevice).cSG.Get_GPIO_OnOff(devAddr, devCH, ret, SetValue)


        For Cnt As Integer = 0 To SetValue.Length - 1

            ctlGpioOut(Cnt).Checked = SetValue(Cnt)
        Next
    End Sub

    Private Sub btn_setgpo_out_onoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setgpo_out_onoff.Click

        'Signal Generator
        'GPO OUTPUT ONOFF 설정 
        Dim SetValue As Double
        Dim ret As Integer
        With Ucgpio1
            Dim ctrGPO() As CheckBox = {.chkPO0, .chkPO1, .chkPO2, .chkPO3, .chkPO4, .chkPO5, .chkPO6, .chkPO7, .chkPO8, .chkPO9, .chkPO10, .chkPO11, .chkPO12, .chkPO13, .chkPO14, .chkPO15}
            For i As Integer = 0 To 15
                If ctrGPO(i).Checked = True Then
                    SetValue += 2 ^ i
                End If
            Next
        End With
        myParent.cMcSG(m_nSelDevice).cSG.Set_GPO_Out(devAddr, devCH, ret, SetValue)
    End Sub

    Private Sub btn_getgpo_out_onoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getgpo_out_onoff.Click
        'Signal Generator
        'GPO OUTPUT ONOFF 설정 읽기
        Dim SetValue() As Boolean = Nothing
        Dim ret As Integer
        Dim ctrGPO() As CheckBox
        With Ucgpio1
            ctrGPO = {.chkPO0, .chkPO1, .chkPO2, .chkPO3, .chkPO4, .chkPO5, .chkPO6, .chkPO7, .chkPO8, .chkPO9, .chkPO10, .chkPO11, .chkPO12, .chkPO13, .chkPO14, .chkPO15}

        End With

        myParent.cMcSG(m_nSelDevice).cSG.Get_GPO_Out(devAddr, devCH, ret, SetValue)


        For Cnt As Integer = 0 To SetValue.Length - 1

            ctrGPO(Cnt).Checked = SetValue(Cnt)
        Next
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        'GPIO REadin
        Dim SetValue() As Double = Nothing
        Dim ret As Integer
        Dim ctrGpioIn() As CheckBox
        With Ucgpio1
            ctrGpioIn = {.chkGPIOIn_I0, .chkGPIOIn_1, .chkGPIOIn2, .chkGPIOIn3, .chkGPIOIn4, .chkGPIOIn5, .chkGPIOIn6, .chkGPIOIn7, .chkGPIOIn8, .chkGPIOIn9, .chkGPIOIn10, .chkGPIOIn11, .chkGPIOIn12, .chkGPIOIn13, .chkGPIOIn14, .chkGPIOIn15}
            'For i As Integer = 0 To 15
            '    If ctrGpioIn(i).Checked = True Then
            '        SetValue += 2 ^ i
            '    End If
            'Next
        End With

        Dim strRcvData As String = ""

        myParent.cMcSG(m_nSelDevice).cSG.Get_GPIO_ReadIN(devAddr, devCH, ret, SetValue)
        For Cnt As Integer = 0 To SetValue.Length - 1

            ctrGpioIn(Cnt).Checked = SetValue(Cnt)
        Next
    End Sub

    Private Sub btn_setCalApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setCalApply.Click
        'Signal Generator
        'Cal Apply 설정

        Dim ret As Integer
        Dim SetValue As cDevSG.eCalApply = cDevSG.eCalApply.eApply
        myParent.cMcSG(m_nSelDevice).cSG.Set_CalApply(devAddr, devCH, ret, SetValue)
    End Sub

    Private Sub btn_getCalApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getCalApply.Click
        'Signal Generator
        'Cal Apply 설정 읽기

        Dim ret As Integer
        Dim SetValue As cDevSG.eCalApply
        myParent.cMcSG(m_nSelDevice).cSG.Get_CalApply(devAddr, devCH, ret, SetValue)
    End Sub

    Private Sub btn_setdacslope_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setdacslope.Click
        'Signal Generator
        'DAC Slope 설정

        Dim ret As Integer
        Dim SetSlopeValue As Single = 3
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 107
        myParent.cMcSG(m_nSelDevice).cSG.Set_DacSlope(devAddr, devCH, ret, SetSlopeValue, SelectChannelNum)
    End Sub

    Private Sub btn_getdacslope_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getdacslope.Click
        'Signal Generator
        'DAC Slope 설정 읽기

        Dim ret As Integer
        Dim ReadSlopeValue As Single
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 107
        myParent.cMcSG(m_nSelDevice).cSG.Get_DacSlope(devAddr, devCH, ret, ReadSlopeValue, SelectChannelNum)
    End Sub

    Private Sub btn_setdacoffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setdacoffset.Click
        'Signal Generator
        'DAC Offset 설정

        Dim ret As Integer
        Dim SetOffsetValue As Single = 9.876543
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 107
        myParent.cMcSG(m_nSelDevice).cSG.Set_DacOffset(devAddr, devCH, ret, SetOffsetValue, SelectChannelNum)
    End Sub

    Private Sub btn_getdacoffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getdacoffset.Click
        'Signal Generator
        'DAC Offset 설정 읽기

        Dim ret As Integer
        Dim ReadOffsetValue As Single
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 107

        myParent.cMcSG(m_nSelDevice).cSG.Get_DacOffset(devAddr, devCH, ret, ReadOffsetValue, SelectChannelNum)
    End Sub


    Private Sub btn_setadcslope_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setadcslope.Click
        'Signal Generator
        'ADc Slope 설정

        Dim ret As Integer
        Dim SetSlopeValue As Single = 1.234567
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 55
        myParent.cMcSG(m_nSelDevice).cSG.Set_ADcSlope(devAddr, devCH, ret, SetSlopeValue, SelectChannelNum)
    End Sub

    Private Sub btn_getadcslope_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getadcslope.Click
        'Signal Generator
        'ADC Slope 설정 읽기

        Dim ret As Integer
        Dim ReadSlopeValue As Single
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 55
        myParent.cMcSG(m_nSelDevice).cSG.Get_ADcSlope(devAddr, devCH, ret, ReadSlopeValue, SelectChannelNum)
    End Sub

    Private Sub btn_setadcoffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setadcoffset.Click
        'Signal Generator
        'ADC Offset 설정

        Dim ret As Integer
        Dim SetOffsetValue As Single = 9.876543
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 55
        myParent.cMcSG(m_nSelDevice).cSG.Set_ADcOffset(devAddr, devCH, ret, SetOffsetValue, SelectChannelNum)
    End Sub

    Private Sub btn_getadcoffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getadcoffset.Click
        'Signal Generator
        'ADC Offset 설정 읽기

        Dim ret As Integer
        Dim ReadOffsetValue As Single
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 55
        myParent.cMcSG(m_nSelDevice).cSG.Get_ADcOffset(devAddr, devCH, ret, ReadOffsetValue, SelectChannelNum)
    End Sub

    Private Sub chk_CalApply_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_CalApply.CheckedChanged

    End Sub

    Private Sub chk_CalApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_CalApply.Click
        'Dim ret As Integer
        'Dim SetValue As cDevSG.eCalApply
        'If chk_CalApply.Checked = True Then
        '    SetValue = cDevSG.eCalApply.eApply
        '    cDevSG.Set_CalApply(ret, SetValue)
        'Else
        '    SetValue = cDevSG.eCalApply.eNone
        '    cDevSG.Set_CalApply(ret, SetValue)
        'End If
    End Sub



    Private Sub btn_dacmultichOnoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_dacmultichOnoff.Click
        Dim ret As Integer
        Dim ReadMode() As cDevSG.eOnOff = Nothing
        Dim SetMode() As cDevSG.eDacMode = Nothing 'max ch54
        Dim ReadFOutput() As cDevSG.eFoutput = Nothing 'max ch 54
        Dim SePulsetMode() As cDevSG.sPulseParam = Nothing
        Dim ReadValue() As Double = Nothing

        If myParent.cMcSG(m_nSelDevice).cSG.Get_SelectModeAllChannel(devAddr, devCH, ret, SetMode) = False Then
            Exit Sub
        End If

        If myParent.cMcSG(m_nSelDevice).cSG.Get_FinalOutputAllChannel(devAddr, devCH, ret, ReadFOutput) = False Then
            Exit Sub
        End If

        If myParent.cMcSG(m_nSelDevice).cSG.Get_PulseAllChannel(devAddr, devCH, ret, SePulsetMode) = False Then
            Exit Sub
        End If

        If myParent.cMcSG(m_nSelDevice).cSG.Get_OutputAllChannel(devAddr, devCH, ret, ReadValue) = False Then
            Exit Sub
        End If

        If myParent.cMcSG(m_nSelDevice).cSG.Get_OnOffAllChannel(devAddr, devCH, ret, ReadMode) = False Then
            Exit Sub
        End If

        For Cnt As Integer = 0 To cDevSG.Max_Pulse_Channel - 1
            If UcDacFrame1.ChanDac(Cnt).Chk_CH.Checked = True Then
                If UcDacFrame1.ChanDac(Cnt).CheckSetError = True Then

                    If UcDacFrame1.ChanDac(Cnt).gCondition.ChkMode = 0 Then
                        SetMode(Cnt) = cDevSG.eDacMode.eDCMode

                        If UcDacFrame1.ChanDac(Cnt).gCondition.ChkDacCh1 = True Then
                            ReadFOutput(Cnt) = cDevSG.eFoutput.eHigh

                        ElseIf UcDacFrame1.ChanDac(Cnt).gCondition.ChkDacCh2 = True Then
                            ReadFOutput(Cnt) = cDevSG.eFoutput.eLow

                        End If


                    ElseIf UcDacFrame1.ChanDac(Cnt).gCondition.ChkMode = 1 Then
                        SetMode(Cnt) = cDevSG.eDacMode.ePulseMode
                        SePulsetMode(Cnt).Period = UcDacFrame1.ChanDac(Cnt).gCondition.Period
                        SePulsetMode(Cnt).Width = UcDacFrame1.ChanDac(Cnt).gCondition.Width
                        SePulsetMode(Cnt).Delay = UcDacFrame1.ChanDac(Cnt).gCondition.Delay

                    End If


                    Dim SelectChannelNum(1) As Integer
                    For Cnt1 As Integer = 0 To 1

                        SelectChannelNum(Cnt1) = UcDacFrame1.ChanDac(Cnt).gCondition.DacChannelNum(Cnt1)

                        If chk_CalApply.Checked = True Then
                            ReadValue(Cnt * 2 + Cnt1) = UcDacFrame1.ChanDac(Cnt).gCondition.DacSetVolt(Cnt) * myParent.cMcSG(m_nSelDevice).cSG.Cal_DacSlope(Cnt * 2 + Cnt1) + myParent.cMcSG(m_nSelDevice).cSG.Cal_DacOffset(Cnt1 * 2 + Cnt1)
                        Else
                            ReadValue(Cnt * 2 + Cnt1) = UcDacFrame1.ChanDac(Cnt).gCondition.DacSetVolt(Cnt1)
                        End If
                    Next
                    ReadMode(Cnt) = cDevSG.eOnOff.eON
                Else
                    Exit Sub
                End If
            End If
        Next

        If myParent.cMcSG(m_nSelDevice).cSG.Set_SelectModeAllChannel(devAddr, devCH, ret, SetMode) = False Then
            Exit Sub
        End If

        If myParent.cMcSG(m_nSelDevice).cSG.Set_FinalOutputAllChannel(devAddr, devCH, ret, ReadFOutput) = False Then
            Exit Sub
        End If

        If myParent.cMcSG(m_nSelDevice).cSG.Set_PulseAllChannel(devAddr, devCH, ret, SePulsetMode) = False Then
            Exit Sub
        End If

        If myParent.cMcSG(m_nSelDevice).cSG.Set_OutputAllChannel(devAddr, devCH, ret, ReadValue) = False Then
            Exit Sub
        End If

        If chk_Sync.Checked = False Then
            If myParent.cMcSG(m_nSelDevice).cSG.Set_OnOffAllChannel(devAddr, devCH, ret, ReadMode) = True Then
                DacOnOFfCheck()
            End If
        Else
            If myParent.cMcSG(m_nSelDevice).cSG.Set_SyncAllChannel(devAddr, devCH, ret, ReadMode) = True Then
                DacOnOFfCheck()
            End If
        End If

    End Sub

    Private Sub chk_Sync_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Sync.CheckedChanged

    End Sub

    Private Sub btn_Setaverallch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Setaverallch.Click
        'Signal Generator
        '전체 채널 Adc Aver count Set

        Dim ret As Integer
        Dim SetValueCount() As Double
        Dim MaxChannel As Integer = cDevSG.Max_ADC_Channel
        ReDim SetValueCount(MaxChannel - 1)
        For cnt As Integer = 0 To MaxChannel - 1 'max ch 56
            SetValueCount(cnt) = 20
        Next

        myParent.cMcSG(m_nSelDevice).cSG.Set_ADcAverCountAllChannel(devAddr, devCH, ret, SetValueCount)
    End Sub

    Private Sub btn_getaverallch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getaverallch.Click
        'Signal Generator
        '전체 채널 Adc Aver count Get

        Dim ret As Integer
        Dim SetValueCount() As Double = Nothing



        myParent.cMcSG(m_nSelDevice).cSG.Get_ADcAverCountAllChannel(devAddr, devCH, ret, SetValueCount)
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        'Signal Generator
        '전체 Dac 채널 OnOff 설정
        Dim ret As Integer
        Dim SetMode() As cDevSG.eOnOff
        Dim MaxChannel As Integer = cDevSG.Max_DAC_Channel

        ReDim SetMode(MaxChannel - 1) 'max ch 54
        For cnt As Integer = 0 To MaxChannel - 1
            SetMode(cnt) = cDevSG.eOnOff.eOFF
        Next

        myParent.cMcSG(m_nSelDevice).cSG.Set_SyncAllChannel(devAddr, devCH, ret, SetMode) '(에러코드 , 설정 할 Onoff 0:SYnc Off Mode , 1:SYcn On Mode  , max  채널 54)
    End Sub


    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub rdo_ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_ch1.CheckedChanged

    End Sub

    Private Sub txt_dacHsetmulti_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_dacHsetmulti.TextChanged
        If Chk_All.Checked = True Then
            For Cnt As Integer = 0 To cDevSG.Max_Pulse_Channel - 1
                If UcDacFrame1.ChanDac(Cnt).Chk_CH.Checked = True Then
                    UcDacFrame1.ChanDac(Cnt).txt_HighDAC.Text = txt_dacHsetmulti.Text
                End If
            Next
        End If

    End Sub

    Private Sub rdo_ch1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdo_ch1.Click

        For Cnt As Integer = 0 To cDevSG.Max_Pulse_Channel - 1
            If UcDacFrame1.ChanDac(Cnt).Chk_CH.Checked = True Then
                UcDacFrame1.ChanDac(Cnt).rdo_ch1.Checked = rdo_ch1.Checked
            End If
        Next
    End Sub

    Private Sub rdo_ch2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_ch2.CheckedChanged
        For Cnt As Integer = 0 To cDevSG.Max_Pulse_Channel - 1
            If UcDacFrame1.ChanDac(Cnt).Chk_CH.Checked = True Then
                UcDacFrame1.ChanDac(Cnt).rdo_ch2.Checked = rdo_ch2.Checked
            End If

        Next
    End Sub

    Private Sub rdo_dcMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_dcMode.CheckedChanged

    End Sub

    Private Sub rdo_dcMode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdo_dcMode.Click
        For Cnt As Integer = 0 To cDevSG.Max_Pulse_Channel - 1
            If UcDacFrame1.ChanDac(Cnt).Chk_CH.Checked = True Then
                UcDacFrame1.ChanDac(Cnt).rdo_dcMode.Checked = rdo_dcMode.Checked
            End If
        Next

        txt_period.Enabled = False
        txt_width.Enabled = False
        txt_delay.Enabled = False
    End Sub

    Private Sub rdo_pulseMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_pulseMode.CheckedChanged

    End Sub

    Private Sub rdo_pulseMode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdo_pulseMode.Click
        For Cnt As Integer = 0 To cDevSG.Max_Pulse_Channel - 1
            If UcDacFrame1.ChanDac(Cnt).Chk_CH.Checked = True Then
                UcDacFrame1.ChanDac(Cnt).rdo_pulseMode.Checked = rdo_pulseMode.Checked
            End If
        Next


        txt_period.Enabled = True
        txt_width.Enabled = True
        txt_delay.Enabled = True
    End Sub

    Private Sub btn_DacmultichRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DacmultichRead.Click
        Dim ret As Integer
        Dim ReadValue() As Double = Nothing

        If myParent.cMcSG(m_nSelDevice).cSG.Get_OutputAllChannel(devAddr, devCH, ret, ReadValue) = False Then
            Exit Sub
        End If

        For Cnt = 0 To cDevSG.Max_Pulse_Channel - 1
            If UcDacFrame1.ChanDac(Cnt).Chk_CH.Checked = True Then
                UcDacFrame1.ChanDac(Cnt).lbl_realdac1.Text = ReadValue(Cnt * 2)
                UcDacFrame1.ChanDac(Cnt).lbl_realdac2.Text = ReadValue(Cnt * 2 + 1)
            End If

        Next

    End Sub


    Private Sub btn_dacmultichoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_dacmultichoff.Click
        Dim ret As Integer
        Dim ReadMode() As cDevSG.eOnOff = Nothing

        If myParent.cMcSG(m_nSelDevice).cSG.Get_OnOffAllChannel(devAddr, devCH, ret, ReadMode) = False Then
            Exit Sub
        End If

        For Cnt As Integer = 0 To cDevSG.Max_Pulse_Channel - 1
            If UcDacFrame1.ChanDac(Cnt).Chk_CH.Checked = True Then

                ReadMode(Cnt) = cDevSG.eOnOff.eOFF

            End If
        Next

        If myParent.cMcSG(m_nSelDevice).cSG.Set_OnOffAllChannel(devAddr, devCH, ret, ReadMode) = True Then
            DacOnOFfCheck()
        End If

    End Sub

    Private Sub txt_dacLsetmulti_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_dacLsetmulti.TextChanged
        If Chk_All.Checked = True Then
            For Cnt As Integer = 0 To cDevSG.Max_Pulse_Channel - 1
                If UcDacFrame1.ChanDac(Cnt).Chk_CH.Checked = True Then
                    UcDacFrame1.ChanDac(Cnt).txt_LowDAC.Text = txt_dacLsetmulti.Text
                End If
            Next
        End If

    End Sub

    Private Sub txt_period_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_period.TextChanged
        If Chk_All.Checked = True Then
            For Cnt As Integer = 0 To cDevSG.Max_Pulse_Channel - 1
                If UcDacFrame1.ChanDac(Cnt).Chk_CH.Checked = True Then
                    UcDacFrame1.ChanDac(Cnt).txt_period.Text = txt_period.Text
                End If
            Next
        End If
    End Sub

    Private Sub txt_width_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_width.TextChanged
        If Chk_All.Checked = True Then
            For Cnt As Integer = 0 To cDevSG.Max_Pulse_Channel - 1
                If UcDacFrame1.ChanDac(Cnt).Chk_CH.Checked = True Then
                    UcDacFrame1.ChanDac(Cnt).txt_width.Text = txt_width.Text
                End If
            Next
        End If
    End Sub

    Private Sub txt_delay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_delay.TextChanged
        If Chk_All.Checked = True Then
            For Cnt As Integer = 0 To cDevSG.Max_Pulse_Channel - 1
                If UcDacFrame1.ChanDac(Cnt).Chk_CH.Checked = True Then
                    UcDacFrame1.ChanDac(Cnt).txt_delay.Text = txt_delay.Text
                End If
            Next
        End If
    End Sub

    Private Sub txt_avercount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_avercount.TextChanged
        If grb_Adc.Enabled = True Then
            For Cnt As Integer = 0 To cDevSG.Max_ADC_Channel - 1
                If UcADcFrame1.ChanADc(Cnt).Chk_CH.Checked = True Then
                    UcADcFrame1.ChanADc(Cnt).txt_avercount.Text = txt_avercount.Text
                End If
            Next
        End If
    End Sub

    Private Sub txt_limitTemp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_limitTemp.TextChanged
        If grb_Adc.Enabled = True Then
            For Cnt As Integer = 0 To cDevSG.Max_ADC_Channel - 1
                If UcADcFrame1.ChanADc(Cnt).Chk_CH.Checked = True Then
                    UcADcFrame1.ChanADc(Cnt).txt_limittemp.Text = txt_limitTemp.Text
                End If
            Next
        End If
    End Sub

    Private Sub txt_limit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_limit.TextChanged
        If grb_Adc.Enabled = True Then
            For Cnt As Integer = 0 To cDevSG.Max_ADC_Channel - 1
                If UcADcFrame1.ChanADc(Cnt).Chk_CH.Checked = True Then
                    UcADcFrame1.ChanADc(Cnt).txt_limit.Text = txt_limit.Text
                End If
            Next
        End If
    End Sub

    Private Sub btn_multiLimittemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_multiLimittemp.Click
        Dim ret As Integer
        Dim SetValue() As Double = Nothing


        If myParent.cMcSG(m_nSelDevice).cSG.Get_ADcTempLimitAllChannel(devAddr, devCH, ret, SetValue) = False Then
            Exit Sub
        End If



        For Cnt As Integer = 0 To cDevSG.Max_ADC_Channel - 1
            If UcADcFrame1.ChanADc(Cnt).Chk_CH.Checked = True Then

                SetValue(Cnt - (myParent.cMcSG(m_nSelDevice).cSG.TempSenserStartChannel - 1)) = UcADcFrame1.ChanADc(Cnt).gCondition.m_LimitValueTemp

            End If
        Next


        myParent.cMcSG(m_nSelDevice).cSG.Set_ADcTempLimitAllChannel(devAddr, devCH, ret, SetValue)
    End Sub

    Private Sub btn_read_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_read.Click
        'Signal Generator
        '전체 채널 ADC Read
        Dim ret As Integer
        Dim ReadValue() As Double = Nothing

        If myParent.cMcSG(m_nSelDevice).cSG.Get_ReadADcAllChannel(devAddr, devCH, ret, ReadValue) = False Then
            Exit Sub
        End If

        For Cnt As Integer = 0 To cDevSG.Max_ADC_Channel - 1
            If UcADcFrame1.ChanADc(Cnt).Chk_CH.Checked = True Then

                If chk_CalApply.Checked = True Then


                    ReadValue(Cnt) = ReadValue(Cnt) * myParent.cMcSG(m_nSelDevice).cSG.Cal_AdcSlope(Cnt) + myParent.cMcSG(m_nSelDevice).cSG.Cal_AdcOffset(Cnt)


                End If

                Dim sum As Double
                Dim aver As Double

                With UcADcFrame1.ChanADc(Cnt).gCondition
                    .m_RealValue = ReadValue(Cnt)
                    If ReadValue(Cnt) < .m_Min Then

                        .m_Min = ReadValue(Cnt)
                    End If

                    If ReadValue(Cnt) > .m_Max Then

                        .m_Max = ReadValue(Cnt)
                    End If
                    .m_Count = .m_Count + 1

                    If .m_Count > 1 Then

                        sum = .m_Average + ReadValue(Cnt)
                        aver = sum / 2
                        .m_Average = aver
                    ElseIf .m_Count = 1 Then

                        .m_Average = ReadValue(Cnt)

                    End If

                    .m_Abs = Math.Abs(.m_Max - .m_Min)


                    UcADcFrame1.ChanADc(Cnt).tbAdcRead.Text = ReadValue(Cnt)
                    UcADcFrame1.ChanADc(Cnt).tbAdcMin.Text = .m_Min
                    UcADcFrame1.ChanADc(Cnt).tbAdcMax.Text = .m_Max
                    UcADcFrame1.ChanADc(Cnt).txt_ABSadc.Text = .m_Abs
                    UcADcFrame1.ChanADc(Cnt).tbAdcAver.Text = .m_Average
                    UcADcFrame1.ChanADc(Cnt).tbAdcCount.Text = .m_Count
                End With





            End If
        Next



        ''''''''''''''''''''''''''''
        'Signal Generator
        '1채널 ADC Read




    End Sub

    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click

        For Cnt As Integer = 0 To cDevSG.Max_ADC_Channel - 1
            If UcADcFrame1.ChanADc(Cnt).Chk_CH.Checked = True Then
                UcADcFrame1.ChanADc(Cnt).init()
            End If
        Next

    End Sub

    Private Sub btn_multiaverset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_multiaverset.Click
        Dim ret As Integer
        Dim SetValueCount() As Double = Nothing



        If myParent.cMcSG(m_nSelDevice).cSG.Get_ADcAverCountAllChannel(devAddr, devCH, ret, SetValueCount) = False Then
            Exit Sub
        End If



        For Cnt As Integer = 0 To cDevSG.Max_ADC_Channel - 1
            If UcADcFrame1.ChanADc(Cnt).Chk_CH.Checked = True Then

                SetValueCount(Cnt) = UcADcFrame1.ChanADc(Cnt).gCondition.m_AverageCount

            End If
        Next


        myParent.cMcSG(m_nSelDevice).cSG.Set_ADcAverCountAllChannel(devAddr, devCH, ret, SetValueCount)

    End Sub

    Private Sub btn_multiLimitCurr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_multiLimitCurr.Click
        Dim ret As Integer
        Dim SetValue() As Double = Nothing


        If myParent.cMcSG(m_nSelDevice).cSG.Get_ADcLimitAllChannel(devAddr, devCH, ret, SetValue) = False Then
            Exit Sub
        End If



        For Cnt As Integer = 0 To cDevSG.Max_ADC_Channel - 1
            If UcADcFrame1.ChanADc(Cnt).Chk_CH.Checked = True Then

                SetValue(Cnt - (myParent.cMcSG(m_nSelDevice).cSG.CurrentSenseStartChannel - 1)) = UcADcFrame1.ChanADc(Cnt).gCondition.m_LimitValueTemp

            End If
        Next


        myParent.cMcSG(m_nSelDevice).cSG.Set_ADcLimitAllChannel(devAddr, devCH, ret, SetValue)
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        For i As Integer = 0 To UcDacFrame1.ChanDac.Length - 1
            If UcDacFrame1.ChanDac(i).LoadRecipe() = True Then
                UcDacFrame1.ChanDac(i).SetValueToUI()
            End If

        Next

    End Sub

    Private Sub grb_Dac_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grb_Dac.Enter

    End Sub

    Private Sub btn_DacmultichSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DacmultichSet.Click
        Dim ret As Integer
        Dim ReadMode() As cDevSG.eOnOff = Nothing
        Dim SetMode() As cDevSG.eDacMode = Nothing 'max ch54
        Dim ReadFOutput() As cDevSG.eFoutput = Nothing 'max ch 54
        Dim SePulsetMode() As cDevSG.sPulseParam = Nothing
        Dim ReadValue() As Double = Nothing

        If myParent.cMcSG(m_nSelDevice).cSG.Get_SelectModeAllChannel(devAddr, devCH, ret, SetMode) = False Then
            Exit Sub
        End If
        Thread.Sleep(200)
        If myParent.cMcSG(m_nSelDevice).cSG.Get_FinalOutputAllChannel(devAddr, devCH, ret, ReadFOutput) = False Then
            Exit Sub
        End If
        Thread.Sleep(200)
        If myParent.cMcSG(m_nSelDevice).cSG.Get_PulseAllChannel(devAddr, devCH, ret, SePulsetMode) = False Then
            Exit Sub
        End If
        Thread.Sleep(200)
        If myParent.cMcSG(m_nSelDevice).cSG.Get_OutputAllChannel(devAddr, devCH, ret, ReadValue) = False Then
            Exit Sub
        End If

        Thread.Sleep(200)
        For Cnt As Integer = 0 To cDevSG.Max_Pulse_Channel - 1
            If UcDacFrame1.ChanDac(Cnt).Chk_CH.Checked = True Then
                If UcDacFrame1.ChanDac(Cnt).CheckSetError = True Then

                    If UcDacFrame1.ChanDac(Cnt).gCondition.ChkMode = 0 Then
                        SetMode(Cnt) = cDevSG.eDacMode.eDCMode

                        If UcDacFrame1.ChanDac(Cnt).gCondition.ChkDacCh1 = True Then
                            ReadFOutput(Cnt) = cDevSG.eFoutput.eHigh

                        ElseIf UcDacFrame1.ChanDac(Cnt).gCondition.ChkDacCh2 = True Then
                            ReadFOutput(Cnt) = cDevSG.eFoutput.eLow

                        End If


                    ElseIf UcDacFrame1.ChanDac(Cnt).gCondition.ChkMode = 1 Then
                        SetMode(Cnt) = cDevSG.eDacMode.ePulseMode
                        SePulsetMode(Cnt).Period = UcDacFrame1.ChanDac(Cnt).gCondition.Period
                        SePulsetMode(Cnt).Width = UcDacFrame1.ChanDac(Cnt).gCondition.Width
                        SePulsetMode(Cnt).Delay = UcDacFrame1.ChanDac(Cnt).gCondition.Delay

                    End If


                    Dim SelectChannelNum(1) As Integer
                    For Cnt1 As Integer = 0 To 1

                        SelectChannelNum(Cnt1) = UcDacFrame1.ChanDac(Cnt).gCondition.DacChannelNum(Cnt1)

                        If chk_CalApply.Checked = True Then
                            ReadValue(Cnt * 2 + Cnt1) = UcDacFrame1.ChanDac(Cnt).gCondition.DacSetVolt(Cnt) * myParent.cMcSG(m_nSelDevice).cSG.Cal_DacSlope(Cnt * 2 + Cnt1) + myParent.cMcSG(m_nSelDevice).cSG.Cal_DacOffset(Cnt1 * 2 + Cnt1)
                        Else
                            ReadValue(Cnt * 2 + Cnt1) = UcDacFrame1.ChanDac(Cnt).gCondition.DacSetVolt(Cnt1)
                        End If
                    Next

                Else
                    Exit Sub
                End If
            End If
        Next

        If myParent.cMcSG(m_nSelDevice).cSG.Set_SelectModeAllChannel(devAddr, devCH, ret, SetMode) = False Then
            Exit Sub
        End If

        If myParent.cMcSG(m_nSelDevice).cSG.Set_FinalOutputAllChannel(devAddr, devCH, ret, ReadFOutput) = False Then
            Exit Sub
        End If

        If myParent.cMcSG(m_nSelDevice).cSG.Set_PulseAllChannel(devAddr, devCH, ret, SePulsetMode) = False Then
            Exit Sub
        End If

        If myParent.cMcSG(m_nSelDevice).cSG.Set_OutputAllChannel(devAddr, devCH, ret, ReadValue) = False Then
            Exit Sub
        End If


    End Sub

    Private Sub btnSetDAC_Low_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDAC_Low.Click

        Dim ReadValue() As Double = Nothing
        Dim tMode As cDevSG.eModeType = cDevSG.eModeType.eSubPower
        Dim tOutMode As cDevSG.eDacMode


        If rdo_subdc.Checked = True Then

            tOutMode = cDevSG.eDacMode.eDCMode
        Else
            tOutMode = cDevSG.eDacMode.ePulseMode
        End If

        If chk_suball.Checked = True Then
            myParent.cMcSG(m_nSelDevice).cSG.PowerBiasSet(tMode, devAddr, devCH, txt_SubHigh.Text, txt_SubLow.Text, False, tOutMode)

        Else

            myParent.cMcSG(m_nSelDevice).cSG.PowerBiasSet(tMode, devAddr, devCH, cbo_subch.SelectedIndex, txt_SubHigh.Text, txt_SubLow.Text, False, tOutMode)

        End If

        Thread.Sleep(300)
        If rdo_subdc.Checked = True Then

            Dim tFinalOut As cDevSG.eFoutput
            If rdo_subhigh.Checked = True Then
                tFinalOut = cDevSG.eFoutput.eHigh
            Else
                tFinalOut = cDevSG.eFoutput.eLow
            End If
            tOutMode = cDevSG.eDacMode.eDCMode

            If chk_suball.Checked = True Then


                myParent.cMcSG(m_nSelDevice).cSG.PowerFinalOutput(tMode, devAddr, devCH, tFinalOut)



            Else

                myParent.cMcSG(m_nSelDevice).cSG.PowerFinalOutput(tMode, devAddr, devCH, cbo_subch.SelectedIndex, tFinalOut)



            End If

            Thread.Sleep(300)
        Else


            Dim SetMode As cDevSG.sPulseParam
            With SetMode
                .Period = txtperiod.Text * 1000
                .Width = txtwidth.Text * 1000

                .Delay = txtdelay.Text * 1000
            End With

            tOutMode = cDevSG.eDacMode.ePulseMode


            If chk_suball.Checked = True Then
                myParent.cMcSG(m_nSelDevice).cSG.PowerPulseSet(tMode, devAddr, devCH, SetMode)
            Else

                myParent.cMcSG(m_nSelDevice).cSG.PowerPulseSet(tMode, devAddr, devCH, cbo_subch.SelectedIndex, SetMode)

            End If

            Thread.Sleep(300)
            '  cDevSG.PowerOn(tMode, devAddr, devCH, cbo_subch.SelectedIndex, tOutMode)

        End If

        If chk_suball.Checked = True Then

            If CheckBox1.Checked = True Then
                Dim ChannelArr() As Integer
                ReDim ChannelArr(11)
                For Cnt As Integer = 0 To ChannelArr.Length - 1
                    ChannelArr(Cnt) = Cnt
                Next
                myParent.cMcSG(m_nSelDevice).cSG.PowerSyncOn(tMode, devAddr, devCH, ChannelArr)
            Else
                myParent.cMcSG(m_nSelDevice).cSG.PowerOn(tMode, devAddr, devCH)
            End If



        Else

            myParent.cMcSG(m_nSelDevice).cSG.PowerOn(tMode, devAddr, devCH, cbo_subch.SelectedIndex)

        End If

    End Sub

    Private Sub Button11_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim tMode As cDevSG.eModeType = cDevSG.eModeType.eSubPower
        If chk_suball.Checked = True Then
            myParent.cMcSG(m_nSelDevice).cSG.PowerOff(tMode, devAddr, devCH)
        Else
            myParent.cMcSG(m_nSelDevice).cSG.PowerOff(tMode, devAddr, devCH, cbo_subch.SelectedIndex)
        End If

    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click

        Dim ReadValue() As Double = Nothing
        Dim tMode As cDevSG.eModeType = cDevSG.eModeType.eSignalPower
        Dim tOutMode As cDevSG.eDacMode


        If rdo_subdc.Checked = True Then

            tOutMode = cDevSG.eDacMode.eDCMode
        Else
            tOutMode = cDevSG.eDacMode.ePulseMode
        End If

        If chk_sigall.Checked = True Then
            myParent.cMcSG(m_nSelDevice).cSG.PowerBiasSet(tMode, devAddr, devCH, txt_SubHigh.Text, txt_SubLow.Text, False, tOutMode)

        Else

            myParent.cMcSG(m_nSelDevice).cSG.PowerBiasSet(tMode, devAddr, devCH, cbo_sigch.SelectedIndex, txt_SubHigh.Text, txt_SubLow.Text, False, tOutMode)

        End If

        Thread.Sleep(300)
        If rdo_subdc.Checked = True Then

            Dim tFinalOut As cDevSG.eFoutput
            If rdo_subhigh.Checked = True Then
                tFinalOut = cDevSG.eFoutput.eHigh
            Else
                tFinalOut = cDevSG.eFoutput.eLow
            End If
            tOutMode = cDevSG.eDacMode.eDCMode

            If chk_sigall.Checked = True Then
                myParent.cMcSG(m_nSelDevice).cSG.PowerFinalOutput(tMode, devAddr, devCH, tFinalOut)
            Else
                myParent.cMcSG(m_nSelDevice).cSG.PowerFinalOutput(tMode, devAddr, devCH, cbo_sigch.SelectedIndex, tFinalOut)
            End If

            Thread.Sleep(300)
        Else


            Dim SetMode As cDevSG.sPulseParam
            With SetMode
                .Period = txtperiod.Text * 1000
                .Width = txtwidth.Text * 1000

                .Delay = txtdelay.Text * 1000
            End With

            tOutMode = cDevSG.eDacMode.ePulseMode


            If chk_sigall.Checked = True Then
                myParent.cMcSG(m_nSelDevice).cSG.PowerPulseSet(tMode, devAddr, devCH, SetMode)
            Else

                myParent.cMcSG(m_nSelDevice).cSG.PowerPulseSet(tMode, devAddr, devCH, cbo_sigch.SelectedIndex, SetMode)

            End If

            Thread.Sleep(300)
            '  cDevSG.PowerOn(tMode, devAddr, devCH, cbo_subch.SelectedIndex, tOutMode)

        End If

        If chk_sigall.Checked = True Then

            If CheckBox2.Checked = True Then
                Dim ChannelArr() As Integer
                ReDim ChannelArr(11)
                For Cnt As Integer = 0 To ChannelArr.Length - 1
                    ChannelArr(Cnt) = Cnt
                Next
                myParent.cMcSG(m_nSelDevice).cSG.PowerSyncOn(tMode, devAddr, devCH, ChannelArr)
            Else
                myParent.cMcSG(m_nSelDevice).cSG.PowerOn(tMode, devAddr, devCH)
            End If



        Else

            myParent.cMcSG(m_nSelDevice).cSG.PowerOn(tMode, devAddr, devCH, cbo_sigch.SelectedIndex)

        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim tMode As cDevSG.eModeType = cDevSG.eModeType.eSignalPower
        If chk_sigall.Checked = True Then
            myParent.cMcSG(m_nSelDevice).cSG.PowerOff(tMode, devAddr, devCH)
        Else
            myParent.cMcSG(m_nSelDevice).cSG.PowerOff(tMode, devAddr, devCH, cbo_sigch.SelectedIndex)
        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim tMode As cDevSG.eModeType = cDevSG.eModeType.eMainPower
        If chk_sigall.Checked = True Then
            myParent.cMcSG(m_nSelDevice).cSG.PowerOff(tMode, devAddr, devCH)
        Else
            myParent.cMcSG(m_nSelDevice).cSG.PowerOff(tMode, devAddr, devCH, cbo_Mainch.SelectedIndex)
        End If
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click

        Dim ReadValue() As Double = Nothing
        Dim tMode As cDevSG.eModeType = cDevSG.eModeType.eMainPower
        Dim tOutMode As cDevSG.eDacMode


        If rdo_subdc.Checked = True Then

            tOutMode = cDevSG.eDacMode.eDCMode
        Else
            tOutMode = cDevSG.eDacMode.ePulseMode
        End If

        If chk_mainall.Checked = True Then
            myParent.cMcSG(m_nSelDevice).cSG.PowerBiasSet(tMode, devAddr, devCH, txt_SubHigh.Text, txt_SubLow.Text, False, tOutMode)

        Else

            myParent.cMcSG(m_nSelDevice).cSG.PowerBiasSet(tMode, devAddr, devCH, cbo_Mainch.SelectedIndex, txt_SubHigh.Text, txt_SubLow.Text, False, tOutMode)

        End If

        Thread.Sleep(300)
        If rdo_subdc.Checked = True Then

            Dim tFinalOut As cDevSG.eFoutput
            If rdo_subhigh.Checked = True Then
                tFinalOut = cDevSG.eFoutput.eHigh
            Else
                tFinalOut = cDevSG.eFoutput.eLow
            End If
            tOutMode = cDevSG.eDacMode.eDCMode

            If chk_mainall.Checked = True Then


                myParent.cMcSG(m_nSelDevice).cSG.PowerFinalOutput(tMode, devAddr, devCH, tFinalOut)



            Else

                myParent.cMcSG(m_nSelDevice).cSG.PowerFinalOutput(tMode, devAddr, devCH, cbo_Mainch.SelectedIndex, tFinalOut)



            End If

            Thread.Sleep(300)
        Else


            Dim SetMode As cDevSG.sPulseParam
            With SetMode
                .Period = txtperiod.Text * 1000
                .Width = txtwidth.Text * 1000

                .Delay = txtdelay.Text * 1000
            End With

            tOutMode = cDevSG.eDacMode.ePulseMode


            If chk_mainall.Checked = True Then
                myParent.cMcSG(m_nSelDevice).cSG.PowerPulseSet(tMode, devAddr, devCH, SetMode)
            Else

                myParent.cMcSG(m_nSelDevice).cSG.PowerPulseSet(tMode, devAddr, devCH, cbo_Mainch.SelectedIndex, SetMode)

            End If

            Thread.Sleep(300)
            '  cDevSG.PowerOn(tMode, devAddr, devCH, cbo_subch.SelectedIndex, tOutMode)

        End If

        If chk_mainall.Checked = True Then

            If CheckBox2.Checked = True Then
                Dim ChannelArr() As Integer
                ReDim ChannelArr(11)
                For Cnt As Integer = 0 To ChannelArr.Length - 1
                    ChannelArr(Cnt) = Cnt
                Next
                myParent.cMcSG(m_nSelDevice).cSG.PowerSyncOn(tMode, devAddr, devCH, ChannelArr)
            Else
                myParent.cMcSG(m_nSelDevice).cSG.PowerOn(tMode, devAddr, devCH)
            End If



        Else

            myParent.cMcSG(m_nSelDevice).cSG.PowerOn(tMode, devAddr, devCH, cbo_Mainch.SelectedIndex)

        End If
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click



        Dim tMode As cDevSG.eModeType = cDevSG.eModeType.eSignalPower
        Dim Average As Double = 20 '
        Dim SetChannel As Double = 1
        myParent.cMcSG(m_nSelDevice).cSG.AverageSetSense(tMode, devAddr, devCH, SetChannel, Average)
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click


        Dim tMode As cDevSG.eModeType = cDevSG.eModeType.eSignalPower
        Dim Average As Double = 27
        myParent.cMcSG(m_nSelDevice).cSG.AverageSetSense(tMode, devAddr, devCH, Average)

    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click

        Dim LimitTemp As Double = 0
        Dim SetChannel As Double = 1
        myParent.cMcSG(m_nSelDevice).cSG.LimitTempSetSense(devAddr, devCH, SetChannel, LimitTemp)
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click


        Dim LimitTemp As Double = 0
        myParent.cMcSG(m_nSelDevice).cSG.LimitTempSetSense(devAddr, devCH, LimitTemp)
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click

        Dim LimitCurr As Double = 1
        Dim SetChannel As Double = 1
        myParent.cMcSG(m_nSelDevice).cSG.LimitCurrSetSense(devAddr, devCH, SetChannel, LimitCurr)
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click

        Dim LimitCurr As Double = 0
        myParent.cMcSG(m_nSelDevice).cSG.LimitCurrSetSense(devAddr, devCH, LimitCurr)
    End Sub


    Private Sub cbSelDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelDevice.SelectedIndexChanged
        m_nSelDevice = cbSelDevice.SelectedIndex
        If myParent.cMcSG(m_nSelDevice).cSG.IsConnected = True Then
            btnConnection.Enabled = False
        Else
            btnConnection.Enabled = True
        End If
    End Sub


    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub
End Class
