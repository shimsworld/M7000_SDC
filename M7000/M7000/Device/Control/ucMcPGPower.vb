Imports System.Threading
Imports System.IO
Imports System.Text
Imports System.Net

Public Class ucMcPGPower

#Region "Defines"

    Public fMain As frmMain

    Public devCH As Integer = 0
    Public devAddr As Integer = 0
    Dim m_nSelDev As Integer = 0
    Private g_strBaudTable() As String = New String() {"50", "75", "110", "134", "150", "300", "600", _
"1200", "1800", "2400", "4800", "7200", "9600", "19200", "38400", "57600", "115200", "230400", "460800", "921600"}

#End Region


#Region "Properties"

    Public Property selectedDevice As Integer
        Get
            Return m_nSelDev
        End Get
        Set(ByVal value As Integer)
            m_nSelDev = value
        End Set
    End Property

#End Region


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

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim configinfo As CCommLib.CComSerial.sSerialPortInfo
        configinfo.sPortName = cboPort.Text
        configinfo.nBaudRate = cbBaudRate.Text
        configinfo.nDataBits = 8
        configinfo.nHandShake = Ports.Handshake.None
        configinfo.nParity = Ports.Parity.None
        configinfo.nStopBits = Ports.StopBits.One
        configinfo.sSendTerminator = vbCrLf
        configinfo.sRcvTerminator = vbCrLf


        If fSGConnection(configinfo) = True Then
            txt_err.Text = "Connect"
            MsgBox("연결 성공", MsgBoxStyle.Critical, "Care!!")
            Button9.BackColor = Color.Green
        Else
            txt_err.Text = "DisConnect"
            fSGDisConnection()
            MsgBox("연결 실패", MsgBoxStyle.Critical, "Care!!")
            Button9.BackColor = Color.Red
        End If
    End Sub
    Sub init_Portlist(ByVal cmbbox As ComboBox)

        Dim comPorts() As String = Nothing
        CCommLib.CComSerial.FindComPorts(comPorts)

        cmbbox.DataSource = comPorts.Clone
        cmbbox.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Public Sub Init()


        With cbBaudRate
            .Items.Clear()
            For i As Integer = 0 To g_strBaudTable.Length - 1
                .Items.Add(g_strBaudTable(i))
            Next
            .SelectedIndex = 15
        End With
        init_Portlist(cboPort)
    End Sub
    Public Function fSGConnection(ByVal inConfig As CCommLib.CComSerial.sSerialPortInfo) As Boolean

        If fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Connection(g_ConfigInfos.PGConfig.McPGPwrConfig(m_nSelDev).sSerialInfo) = True Then

            Dim ret As Integer

            tbError.Text = ret

            Return fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.cPing(devAddr, devCH, ret)
        End If

        Return False
    End Function

    Public Sub fSGDisConnection()
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.DisConnection()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        fSGDisConnection()
        Button9.BackColor = Color.Red
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.cPing(devAddr, devCH, ret)

        tbError.Text = ret
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmPGSendRecieveLog.Show()
    End Sub


    Private Sub btn_setoutputonoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setoutputonoff.Click
        'Power Channel Onoff Set
        Dim ret As Integer
        Dim SetValue As cDevMcPGPower.eOnOff = cDevMcPGPower.eOnOff.eON
        Dim channel As Integer = 0 '채널 번호 0 ~ 7
        Dim tbitnum As Integer
        Dim txtchkArr() As CheckBox = {chk_00, chk_01, chk_02, chk_03, chk_04}
        Dim tNum As Integer
        For Cnt As Integer = 0 To txtchkArr.Length - 1


            If txtchkArr(Cnt).Checked = True Then
                tNum = 2 ^ Cnt
                tbitnum = tbitnum + tNum
            End If

        Next
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_PowerOnOff(devAddr, devCH, ret, SetValue, channel, tbitnum)
    End Sub

    Private Sub btn_getoutputonoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getoutputonoff.Click
        'Power Channel Onoff Get
        Dim ret As Integer
        Dim SetValue As cDevMcPGPower.eOnOff
        Dim channel As Integer = 0 '채널 번호 0

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Get_PowerOnOff(devAddr, devCH, ret, SetValue, channel)
    End Sub

    Private Sub btn_SetoutputVal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SetoutputVal.Click
        'Power Port Output set
        Dim ret As Integer
        Dim SetValue As Double = 2 '설정 값 (V)
        Dim channel As Integer = 0 '채널 번호 0
        Dim Port As Integer = 0 '포트번호 0~4

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_PowerOutput(devAddr, devCH, ret, channel, Port, SetValue)
    End Sub

    Private Sub btn_GetoutputVal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GetoutputVal.Click
        'Power Port Output Get
        Dim ret As Integer
        Dim GetValue As Double = 0 '설정 값 (V)
        Dim channel As Integer = 0 '채널 번호 0
        Dim Port As Integer = 4 '포트번호 0~4

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Get_PowerOutput(devAddr, devCH, ret, channel, Port, GetValue)
    End Sub

    Private Sub btn_getinputmeasurement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getinputmeasurement.Click
        'Power Inputmeasurement Get
        Dim ret As Integer
        Dim GetVoltValue As Double = 0 '설정 값 (V)
        Dim GetCurrValue As Double = 0 '설정 값 (V)

        Dim channel As Integer = 0 '채널 번호 0
        Dim Port As Integer = 0 '포트번호 0~4

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Get_PowerInputMeasure(devAddr, devCH, ret, Port, GetVoltValue, GetCurrValue)
    End Sub

    Private Sub btn_setinputlimit1ch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setinputlimit1ch.Click
        'Power 1ch LimitValue Set
        Dim ret As Integer
        Dim LimitValue As Double = 1
        Dim Port As Integer = 0 '포트번호 0~4

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_PowerInputLimit(devAddr, devCH, ret, Port, LimitValue)
    End Sub

    Private Sub btn_getinputlimit1ch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getinputlimit1ch.Click
        'Power 1ch LimitValue Get
        Dim ret As Integer
        Dim LimitValue As Double
        Dim Port As Integer = 2 '포트번호 0~4

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Get_PowerInputLimit(devAddr, devCH, ret, Port, LimitValue)
    End Sub

    Private Sub btn_setinputlimitallch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setinputlimitallch.Click
        'Power all LimitValue Set
        Dim ret As Integer
        Dim LimitValue() As Double
        '   Dim Port As Integer = 0 '포트번호 0~4
        ReDim LimitValue(4)

        For cnt As Integer = 0 To LimitValue.Length - 1
            LimitValue(cnt) = 1
        Next

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_PowerAllInputLimit(devAddr, devCH, ret, LimitValue)
    End Sub

    Private Sub btn_getinputlimitallch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getinputlimitallch.Click
        'Power all LimitValue Get
        Dim ret As Integer
        Dim LimitValue() As Double = Nothing
        '   Dim Port As Integer = 0 '포트번호 0~4

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Get_PowerAllInputLimit(devAddr, devCH, ret, LimitValue)
    End Sub


    Private Sub btn_setondelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setondelay.Click
        'Power all Ondelay Set
        Dim ret As Integer
        Dim OnDelayValue() As Integer
        '   Dim Port As Integer = 0 '포트번호 0~4
        ReDim OnDelayValue(4)

        For cnt As Integer = 0 To OnDelayValue.Length - 1
            OnDelayValue(cnt) = 1 '1 = 1ms
        Next

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_PowerOnDelay(devAddr, devCH, ret, OnDelayValue)
    End Sub

    Private Sub btn_getondelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getondelay.Click
        'Power all Ondelay Get
        Dim ret As Integer
        Dim OnDelayValue() As Integer = Nothing
        '   Dim Port As Integer = 0 '포트번호 0~4

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Get_PowerOnDelay(devAddr, devCH, ret, OnDelayValue)
    End Sub

    Private Sub btn_setoffdelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setoffdelay.Click
        'Power all Offdelay Set
        Dim ret As Integer
        Dim OffDelayValue() As Integer
        '   Dim Port As Integer = 0 '포트번호 0~4
        ReDim OffDelayValue(4)

        For cnt As Integer = 0 To OffDelayValue.Length - 1
            OffDelayValue(cnt) = 1 '1 = 1ms
        Next

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_PowerOnDelay(devAddr, devCH, ret, OffDelayValue)
    End Sub

    Private Sub btn_getoffdelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getoffdelay.Click
        'Power all Offdelay Get
        Dim ret As Integer
        Dim OffDelayValue() As Integer = Nothing
        '   Dim Port As Integer = 0 '포트번호 0~4

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Get_PowerOnDelay(devAddr, devCH, ret, OffDelayValue)
    End Sub

    Private Sub btn_outputon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_outputon.Click

        Dim ret As Integer
        Dim TextArrOnDelay() As TextBox = {tbOnDelay_V1, tbOnDelay_V2, tbOnDelay_V3, tbOnDelay_V4, tbOnDelay_V5}
        Dim TextArrOffDelay() As TextBox = {tbOffDelay_V1, tbOffDelay_V2, tbOffDelay_V3, tbOffDelay_V4, tbOffDelay_V5}
        Dim TextArrSetValue() As TextBox = {tbVoltage_V1, tbVoltage_V2, tbVoltage_V3, tbVoltage_V4, tbVoltage_V5}

        'Power all Ondelay Set
        Dim OnDelayValue() As Integer
        '   Dim Port As Integer = 0 '포트번호 0~4
        ReDim OnDelayValue(4)
        For cnt As Integer = 0 To OnDelayValue.Length - 1
            OnDelayValue(cnt) = CDbl(TextArrOnDelay(cnt).Text) ' 1= 1ms
        Next

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_PowerOnDelay(devAddr, devCH, ret, OnDelayValue)



        Dim OffDelayValue() As Integer
        ReDim OffDelayValue(4)
        For cnt As Integer = 0 To OffDelayValue.Length - 1
            OffDelayValue(cnt) = CDbl(TextArrOffDelay(cnt).Text) '1 = 1ms
        Next
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_PowerOffDelay(devAddr, devCH, ret, OffDelayValue)

        ''Power Port Output set
        Dim txtchkArr() As CheckBox = {chk_00, chk_01, chk_02, chk_03, chk_04}
        Dim Output As Double = 0 '설정 값 (V)
        Dim pChannel As Integer = 0 '채널 번호 0
        Dim Port As Integer = 0 '포트번호 0~4

        For Cnt As Integer = 0 To txtchkArr.Length - 1
            If txtchkArr(Cnt).Checked = True Then
                fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_PowerOutput(devAddr, devCH, ret, pChannel, Cnt, CDbl(TextArrSetValue(Cnt).Text))

            End If

        Next




        'Power Channel Onoff Set

        Dim tbitnum As Integer

        Dim tNum As Integer
        For Cnt As Integer = 0 To txtchkArr.Length - 1


            If txtchkArr(Cnt).Checked = True Then
                tNum = 2 ^ Cnt
                tbitnum = tbitnum + tNum
            End If

        Next

        Dim SetValue As cDevMcPGPower.eOnOff = cDevMcPGPower.eOnOff.eON
        Dim channel As Integer = 0 '채널 번호 0 ~ 7

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_PowerOnOff(devAddr, devCH, ret, SetValue, channel, tbitnum)
    End Sub

    Private Sub btn_outputoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_outputoff.Click
        'Power Channel Onoff Set
        Dim ret As Integer
        Dim SetValue As cDevMcPGPower.eOnOff = cDevMcPGPower.eOnOff.eOFF
        Dim channel As Integer = 0 '채널 번호 0 ~ 7
        Dim tbitnum As Integer
        Dim txtchkArr() As CheckBox = {chk_00, chk_01, chk_02, chk_03, chk_04}
        Dim tNum As Integer
        For Cnt As Integer = 0 To txtchkArr.Length - 1


            If txtchkArr(Cnt).Checked = True Then
                tNum = 2 ^ Cnt
                tbitnum = tbitnum + tNum
            End If

        Next
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_PowerOnOff(devAddr, devCH, ret, SetValue, channel, tbitnum)
    End Sub

    Private Sub btn_LimitSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_LimitSet.Click
        'Power all LimitValue Set
        Dim ret As Integer
        Dim TextBoxArr() As TextBox = {tbILimit_V1, tbILimit_V2, tbILimit_V3, tbILimit_V4, tbILimit_V5}
        Dim LimitValue() As Double
        '   Dim Port As Integer = 0 '포트번호 0~4
        ReDim LimitValue(4)

        For cnt As Integer = 0 To LimitValue.Length - 1
            LimitValue(cnt) = CDbl(TextBoxArr(cnt).Text)
        Next

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_PowerAllInputLimit(devAddr, devCH, ret, LimitValue)
    End Sub

    Private Sub UcframePower_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Init()
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim tBoardInfoArr() As Byte = Nothing
        Dim ret As Integer
        Dim tError As Boolean
        Dim tListArr(1) As String


        tError = fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.cBoardInfo(devAddr, devCH, tBoardInfoArr, ret)
        tbError.Text = ret


        If tError = True Then
            UcSingleList1.ClearAllData()

            Dim tModleStr As String = ""
            Dim TempStr As String = ""
            '/////////////// Model //////////////////////
            For i As Integer = 8 To 22
                tModleStr = Convert.ToChar(tBoardInfoArr(i))
                TempStr &= tModleStr
            Next

            tListArr(0) = "Model"
            tListArr(1) = TempStr

            UcSingleList1.AddRowData(tListArr)

            Dim tSerialStr As String = ""
            TempStr = ""
            '/////////////// Serial No //////////////////////
            For i = 23 To 32
                tSerialStr = Convert.ToChar(tBoardInfoArr(i))
                If tSerialStr = "-" Then
                    tSerialStr = "."
                End If
                TempStr &= tSerialStr
            Next
            tListArr(0) = "Serial No"
            tListArr(1) = TempStr

            UcSingleList1.AddRowData(tListArr)
            '/////////////// Date //////////////////////
            Dim tDate As String = ""
            tDate = Convert.ToUInt16(tBoardInfoArr(33)) + 2000 & " " & Convert.ToUInt16(tBoardInfoArr(34)) & " " & Convert.ToUInt16(tBoardInfoArr(35))

            tListArr(0) = "Date"
            tListArr(1) = tDate

            UcSingleList1.AddRowData(tListArr)
            '/////////////// Etc //////////////////////
            Dim tfirmVer As String = ""
            Dim tFpgaVer As String = ""
            Dim tDacChannel As String = ""
            Dim tAdcChannel As String = ""
            Dim tAuxChannel As String = ""


            tfirmVer = Convert.ToByte(tBoardInfoArr(36)) & " " & Convert.ToByte(tBoardInfoArr(37)) / 100


            tListArr(0) = "Firmware Ver"
            tListArr(1) = tfirmVer

            UcSingleList1.AddRowData(tListArr)


            tFpgaVer = Convert.ToByte(tBoardInfoArr(38)) & " " & Convert.ToByte(tBoardInfoArr(39)) / 100



            tListArr(0) = "Fpga Ver"
            tListArr(1) = tFpgaVer

            UcSingleList1.AddRowData(tListArr)

            tDacChannel = Convert.ToByte(tBoardInfoArr(40))


            tListArr(0) = "Dac Channel"
            tListArr(1) = tDacChannel

            UcSingleList1.AddRowData(tListArr)

            tAdcChannel = Convert.ToByte(tBoardInfoArr(41))


            tListArr(0) = "ADC Channel"
            tListArr(1) = tAdcChannel

            UcSingleList1.AddRowData(tListArr)


            tAuxChannel = Convert.ToByte(tBoardInfoArr(42))



            tListArr(0) = "Aux Channel"
            tListArr(1) = tAuxChannel

            UcSingleList1.AddRowData(tListArr)

        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim tint As Integer
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.cComplete(devAddr, devCH, tint, ret)
        TextBox1.Text = tint
        tbError.Text = ret
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim tStr As String = Nothing
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.cResisterRead(devAddr, devCH, tStr, ret)
        TextBox2.Text = tStr
        tbError.Text = ret
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ret As Integer

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.cReset(devAddr, devCH, ret)
        tbError.Text = ret
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.cSaveData(devAddr, devCH, ret)
        tbError.Text = ret
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.cResisterInit(devAddr, devCH, ret)
        tbError.Text = ret
    End Sub

    Private Sub btn_setalarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setalarm.Click

        '   cDevPower.Set_LimitAlarm(devAddr, devCH, ret) '(에러코드 ,설정 할 전체 채널 수 )
    End Sub

    Private Sub btn_GetAalarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GetAalarm.Click
        ' Limit Alarm 조회
        '   Dim ReadAlarm() As cDevPower.eLimitAlarm


        '   cDevPower.Get_LimitAlarm(devAddr, devCH, ret, ReadAlarm) '(에러코드 ,설정 할 전체 채널 수 ) 'ch 56
    End Sub

    Private Sub GroupBox10_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox10.Enter

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim GetVoltValue As Double = 0 '설정 값 (V)
        Dim GetCurrValue As Double = 0 '설정 값 (V)

        Dim Port As Integer = 1 '채널 번호 0
        Dim ret As Integer = 0

        For Cnt As Integer = 0 To 4
            If fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Get_PowerInputMeasure(devAddr, devCH, ret, Cnt, GetVoltValue, GetCurrValue) = False Then
                Return
            End If

            If Cnt = 0 Then
                txt_voltv1.Text = GetVoltValue
                txt_currv1.Text = GetCurrValue
            ElseIf Cnt = 1 Then
                txt_voltv2.Text = GetVoltValue
                txt_currv2.Text = GetCurrValue
            ElseIf Cnt = 2 Then
                txt_voltv3.Text = GetVoltValue
                txt_currv3.Text = GetCurrValue
            ElseIf Cnt = 3 Then
                txt_voltv4.Text = GetVoltValue
                txt_currv4.Text = GetCurrValue

            ElseIf Cnt = 4 Then
                txt_voltv5.Text = GetVoltValue
                txt_currv5.Text = GetCurrValue
            End If
        Next

    End Sub

    Private Sub btn_setdacslope_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setdacslope.Click
        'DAC Slope 설정

        Dim ret As Integer
        Dim SetSlopeValue As Single = 3
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 4
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_DacSlope(devAddr, devCH, ret, SetSlopeValue, SelectChannelNum)
    End Sub

    Private Sub btn_getdacslope_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getdacslope.Click
        'DAC Slope 설정 읽기

        Dim ret As Integer
        Dim ReadSlopeValue As Single
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 4
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Get_DacSlope(devAddr, devCH, ret, ReadSlopeValue, SelectChannelNum)
    End Sub

    Private Sub btn_setdacoffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setdacoffset.Click
        'DAC Offset 설정

        Dim ret As Integer
        Dim SetOffsetValue As Single = 9.876543
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~4
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_DacOffset(devAddr, devCH, ret, SetOffsetValue, SelectChannelNum)
    End Sub

    Private Sub btn_getdacoffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getdacoffset.Click
        'DAC Offset 설정 읽기

        Dim ret As Integer
        Dim ReadOffsetValue As Single
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 4

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Get_DacOffset(devAddr, devCH, ret, ReadOffsetValue, SelectChannelNum)
    End Sub

    Private Sub btn_setadcslope_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setadcslope.Click
        'ADc Slope 설정

        Dim ret As Integer
        Dim SetSlopeValue As Single = 1.234567
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~4
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_ADcSlope(devAddr, devCH, ret, SetSlopeValue, SelectChannelNum)
    End Sub

    Private Sub btn_getadcslope_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getadcslope.Click
        'ADC Slope 설정 읽기

        Dim ret As Integer
        Dim ReadSlopeValue As Single
        Dim SelectChannelNum As Integer = 0 'Channel 0 ~ 4
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Get_ADcSlope(devAddr, devCH, ret, ReadSlopeValue, SelectChannelNum)
    End Sub

    Private Sub btn_setadcoffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setadcoffset.Click
        'ADC Offset 설정

        Dim ret As Integer
        Dim SetOffsetValue As Single = 9.876543
        Dim SelectChannelNum As Integer = 4 'Channel 0 ~ 4
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Set_ADcOffset(devAddr, devCH, ret, SetOffsetValue, SelectChannelNum)
    End Sub

    Private Sub btn_getadcoffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getadcoffset.Click
        'ADC Offset 설정 읽기

        Dim ret As Integer
        Dim ReadOffsetValue As Single
        Dim SelectChannelNum As Integer = 4 'Channel 0 ~4
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGPwr.Get_ADcOffset(devAddr, devCH, ret, ReadOffsetValue, SelectChannelNum)
    End Sub
End Class
