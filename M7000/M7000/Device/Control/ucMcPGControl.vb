Imports System.Threading
Imports System.IO
Imports System.Text
Imports System.Net
Public Class ucMcPGControl


#Region "Define"
    Private g_strBaudTable() As String = New String() {"50", "75", "110", "134", "150", "300", "600", _
"1200", "1800", "2400", "4800", "7200", "9600", "19200", "38400", "57600", "115200", "230400", "460800", "921600"}


    Public fMain As frmMain
    Public devCH As Integer = 0
    Public devAddr As Integer = 0
    Dim m_nSelDev As Integer

    Public Enum ePattern
        eSingleColor = 1
        e5by5Pattern
        e5by5Pattern_UserDefColor
        eH_3ColorLine = 16
        eV_3ColorLine
    End Enum


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



    Private Sub btn_chaddrset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        cbo_pallet.SelectedIndex = 0
        init_Portlist(cboPort)
        cbo_Pattern.SelectedIndex = 0
    End Sub
    Private Sub btn_connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
    Public Function fSGConnection(ByVal inConfig As CCommLib.CComSerial.sSerialPortInfo) As Boolean

        If fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.Connection(g_ConfigInfos.PGConfig.McPGCtrlBDConfig(m_nSelDev).sSerialInfo) = True Then

            Dim ret As Integer



            tbError.Text = ret

            Return fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.cPing(devAddr, devCH, ret)
        End If

        Return False
    End Function
    Public Sub fSGDisConnection()

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.DisConnection()

    End Sub


    Private Sub btn_chaddrset_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_chaddrset.Click
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

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        fSGDisConnection()
        Button9.BackColor = Color.Red
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.cPing(devAddr, devCH, ret)

        tbError.Text = ret
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmPGSendRecieveLog.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim tBoardInfoArr() As Byte = Nothing
        Dim ret As Integer
        Dim tError As Boolean
        Dim tListArr(1) As String


        tError = fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.cBoardInfo(devAddr, devCH, tBoardInfoArr, ret)
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ret As Integer

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.cReset(devAddr, devCH, ret)
        tbError.Text = ret
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.cSaveData(devAddr, devCH, ret)
        tbError.Text = ret
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim tStr As String = Nothing
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.cResisterRead(devAddr, devCH, tStr, ret)
        TextBox2.Text = tStr
        tbError.Text = ret
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.cResisterInit(devAddr, devCH, ret)
        tbError.Text = ret
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim tint As Integer
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.cComplete(devAddr, devCH, tint, ret)
        TextBox1.Text = tint
        tbError.Text = ret
    End Sub



    Private Sub btn_driverinit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_driverinit.Click
        Dim ret As Integer

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.Set_Initialize(devAddr, devCH, ret)

    End Sub

    Private Sub btn_setdisaplyonoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setdisaplyonoff.Click
        Dim ret As Integer
        Dim SetOnOFF As cDevMcPGControl.eOnOff = cDevMcPGControl.eOnOff.eON

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.Set_DisplayOnOFF(devAddr, devCH, ret, SetOnOFF)

    End Sub

    Private Sub btn_getdisaplyonoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getdisaplyonoff.Click
        Dim ret As Integer
        Dim GetOnOFF As cDevMcPGControl.eOnOff

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.Get_DisplayOnOFF(devAddr, devCH, ret, GetOnOFF)
    End Sub

    Private Sub btn_regwrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_regwrite.Click
        Dim ret As Integer

        Dim RegAddrs As Integer = 0
        Dim RegValue(2) As Integer

        RegValue(0) = 1
        RegValue(1) = 2
        RegValue(2) = 3

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.Set_RegReadWrite(devAddr, devCH, ret, RegAddrs, RegValue)
    End Sub

    Private Sub btn_regread_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_regread.Click
        Dim ret As Integer

        Dim RegAddrs As Integer = 0
        Dim ReadRegValue As String = Nothing

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.Get_RegReadWrite(devAddr, cbo_pallet.SelectedIndex, ret, RegAddrs, ReadRegValue)
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        UcSingleList2.ClearAllData()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Try
            If Int("&H" & TextBox3.Text) >= 0 Or TextBox3.Text <> "" Then
                List_Val.Items.Add(TextBox3.Text)

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        List_Val.Items.Clear()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If tbRegName.Text = "" Or tbAddress.Text = "" Or List_Val.Items.Count <= 0 Then
            MsgBox("설정 값 을 입력 해주세요 ")

        Else
            Dim rStr(3) As String
            rStr(0) = tbRegName.Text
            rStr(1) = tbAddress.Text
            rStr(2) = List_Val.Items.Count

            Dim tStr As String = Nothing
            Dim cc As New ListBox.ObjectCollection(List_Val)


            For Cnt As Integer = 0 To List_Val.Items.Count - 1
                If Cnt = 0 Then
                    tStr = List_Val.Items(Cnt)
                Else
                    tStr = tStr & "," & List_Val.Items(Cnt)
                End If

            Next

            rStr(3) = tStr
            UcSingleList2.AddRowData(rStr)
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim ret As Integer
        Dim SetOnOFF As cDevMcPGControl.eOnOff = cDevMcPGControl.eOnOff.eON


        Dim RegAddrs As Integer = 0
        Dim RegValue() As String
        Dim RegValueint() As Integer


        If UcSingleList2.RowCounts = 0 Then
            MsgBox("List 에 정보가 없습니다!")
            Return
        End If

        For Cnt As Integer = 0 To UcSingleList2.RowCounts - 1

            Dim tReadStr() As String = Nothing
            UcSingleList2.GetRowData(Cnt, tReadStr)

            RegValue = tReadStr(3).Split(",")
            ReDim RegValueint(RegValue.Length - 1)
            For Cnt1 As Integer = 0 To RegValue.Length - 1
                RegValueint(Cnt1) = Int(RegValue(Cnt1))
            Next

            If fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.Set_RegReadWrite(devAddr, devCH, ret, Int(tReadStr(1)), (RegValueint)) = False Then
                Exit Sub
            End If
        Next

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.Set_DisplayOnOFF(devAddr, devCH, ret, SetOnOFF)

    End Sub

    Private Sub UcFrameModuleControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Init()
    End Sub

    Private Sub cbo_Pattern_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Pattern.SelectedIndexChanged
        If cbo_Pattern.SelectedIndex = 0 Then
            GrpPattern1.Visible = True
            GrpPattern2.Visible = False
            GrpPattern3.Visible = False
            GrpPattern1.Text = "Pattern Color"
        ElseIf cbo_Pattern.SelectedIndex = 1 Then
            GrpPattern1.Visible = True
            GrpPattern2.Visible = False
            GrpPattern3.Visible = False
            GrpPattern1.Text = "Pattern Color"
        ElseIf cbo_Pattern.SelectedIndex = 2 Then
            GrpPattern1.Visible = True
            GrpPattern2.Visible = False
            GrpPattern3.Visible = False
            GrpPattern1.Text = "Pattern Color"
        ElseIf cbo_Pattern.SelectedIndex = 3 Then
            GrpPattern1.Visible = True
            GrpPattern2.Visible = True
            GrpPattern3.Visible = True
            GrpPattern1.Text = "Pattern R"
        ElseIf cbo_Pattern.SelectedIndex = 4 Then
            GrpPattern1.Visible = True
            GrpPattern2.Visible = True
            GrpPattern3.Visible = True
            GrpPattern1.Text = "Pattern R"
        ElseIf cbo_Pattern.SelectedIndex = 5 Then
            GrpPattern1.Visible = True
            GrpPattern2.Visible = True
            GrpPattern3.Visible = True
        End If
    End Sub

    Dim cRed As Integer
    Dim cBlue As Integer
    Dim cGreen As Integer
    Dim cWhite As Integer
    Private Sub trk_r_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk_r.Scroll
        txtRvalue.Text = trk_r.Value
        numr.Value = trk_r.Value
        cRed = trk_r.Value
    End Sub
    Private Sub trk_g_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk_g.Scroll
        txtGvalue.Text = trk_g.Value
        numg.Value = trk_g.Value

        cGreen = trk_g.Value
    End Sub
    Private Sub trk_b_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk_b.Scroll
        txtBvalue.Text = trk_b.Value
        numb.Value = trk_b.Value

        cBlue = trk_b.Value
        ChangePannelColor(0, cRed, cGreen, cBlue, cWhite)
    End Sub

    Private Sub numr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numr.KeyDown
        If e.KeyCode = Keys.Enter Then
            trk_r.Value = numr.Value
            txtRvalue.Text = numr.Value
            cRed = numr.Value
            ChangePannelColor(0, cRed, cGreen, cBlue, cWhite)
        End If
    End Sub
    Private Sub numr_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numr.ValueChanged
        trk_r.Value = numr.Value
        txtRvalue.Text = numr.Value
        cRed = numr.Value
        ChangePannelColor(0, cRed, cGreen, cBlue, cWhite)
    End Sub

    Private Sub numg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numg.KeyDown
        If e.KeyCode = Keys.Enter Then
            trk_g.Value = numg.Value
            txtGvalue.Text = numg.Value
            cGreen = numg.Value
            ChangePannelColor(0, cRed, cGreen, cBlue, cWhite)
        End If
    End Sub

    Private Sub numg_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numg.ValueChanged
        trk_g.Value = numg.Value
        txtGvalue.Text = numg.Value
        cGreen = numg.Value
        ChangePannelColor(0, cRed, cGreen, cBlue, cWhite)
    End Sub

    Private Sub numb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numb.KeyDown
        If e.KeyCode = Keys.Enter Then
            trk_b.Value = numb.Value
            txtBvalue.Text = numb.Value
            cBlue = numb.Value
            ChangePannelColor(0, cRed, cGreen, cBlue, cWhite)
        End If
    End Sub


    Private Sub numb_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numb.ValueChanged
        trk_b.Value = numb.Value
        txtBvalue.Text = numb.Value
        cBlue = numb.Value
        ChangePannelColor(0, cRed, cGreen, cBlue, cWhite)
    End Sub

    Private Sub trk_w_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trk_w.Scroll
        txtwvalue.Text = trk_w.Value
        numw.Value = trk_w.Value
        cWhite = trk_w.Value

        trk_r.Value = trk_w.Value
        trk_g.Value = trk_w.Value
        trk_b.Value = trk_w.Value

        ChangePannelColor(1, cRed, cGreen, cBlue, cWhite)
    End Sub

    Private Sub numw_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numw.KeyDown
        If e.KeyCode = Keys.Enter Then
            trk_w.Value = numw.Value
            txtwvalue.Text = numw.Value
            cWhite = numw.Value


            trk_r.Value = numw.Value
            trk_g.Value = numw.Value
            trk_b.Value = numw.Value


            ChangePannelColor(1, cRed, cGreen, cBlue, cWhite)
        End If
    End Sub
    Private Sub numw_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numw.ValueChanged
        trk_w.Value = numw.Value
        txtwvalue.Text = numw.Value
        cWhite = numw.Value



        trk_r.Value = numw.Value
        trk_g.Value = numw.Value
        trk_b.Value = numw.Value
        ChangePannelColor(1, cRed, cGreen, cBlue, cWhite)
    End Sub
    Enum eMode
        eRGB
        eWhite
    End Enum
    Public Function ChangePannelColor(ByVal InMode As eMode, ByVal inR As Integer, ByVal inG As Integer, ByVal inB As Integer, ByVal inW As Integer) As Boolean

        Dim ChkBoxArr() As CheckBox = {chk_pt1, chk_pt2, chk_pt3}
        Dim PNLArr() As Panel = {pnl_p1, pnl_p2, pnl_p3}

        If InMode = eMode.eRGB Then

            If cbo_Pattern.SelectedIndex = 0 Or cbo_Pattern.SelectedIndex = 1 Or cbo_Pattern.SelectedIndex = 2 Then

                PNLArr(0).BackColor = System.Drawing.Color.FromArgb(CType(CType(inR, Byte), Integer), CType(CType(inG, Byte), Integer), CType(CType(inB, Byte), Integer))

            Else

                PNLArr(0).BackColor = System.Drawing.Color.FromArgb(CType(CType(inR, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
                PNLArr(1).BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(inG, Byte), Integer), CType(CType(0, Byte), Integer))
                PNLArr(2).BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(inB, Byte), Integer))


            End If

            ' PNLArr(Cnt).BackColor = System.Drawing.Color.FromArgb(CType(CType(inR, Byte), Integer), CType(CType(inG, Byte), Integer), CType(CType(inB, Byte), Integer))
        ElseIf InMode = eMode.eWhite Then
            If cbo_Pattern.SelectedIndex = 0 Or cbo_Pattern.SelectedIndex = 1 Or cbo_Pattern.SelectedIndex = 2 Then

                PNLArr(0).BackColor = System.Drawing.Color.FromArgb(CType(CType(inW, Byte), Integer), CType(CType(inW, Byte), Integer), CType(CType(inW, Byte), Integer))

            Else

                PNLArr(0).BackColor = System.Drawing.Color.FromArgb(CType(CType(inW, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
                PNLArr(1).BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(inW, Byte), Integer), CType(CType(0, Byte), Integer))
                PNLArr(2).BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(inW, Byte), Integer))


            End If

            ' PNLArr(Cnt).BackColor = System.Drawing.Color.FromArgb(CType(CType(inW, Byte), Integer), CType(CType(inW, Byte), Integer), CType(CType(inW, Byte), Integer))
        End If

        Return True
    End Function

    Private Sub btn_set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_set.Click
        Dim ret As Integer
        Dim Index As ePattern

        Select Case cbo_Pattern.SelectedIndex
            Case 0
                Index = ePattern.eSingleColor
            Case 1
                Index = ePattern.e5by5Pattern
            Case 2
                Index = ePattern.e5by5Pattern_UserDefColor
            Case 3
                Index = ePattern.eH_3ColorLine
            Case 4
                Index = ePattern.eV_3ColorLine
            Case Else
                Index = -1
        End Select

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.Set_Pattern(devAddr, devCH, ret, Index, trk_r.Value, trk_g.Value, trk_b.Value)

    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_on.Click

        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.Set_Initialize(devAddr, devCH, ret)

        Thread.Sleep(500)

        Thread.Sleep(500)
        Dim SetOnOFF As cDevMcPGControl.eOnOff = cDevMcPGControl.eOnOff.eON

        If fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.Set_DisplayOnOFF(devAddr, devCH, ret, SetOnOFF) = True Then
            btn_on.BackColor = Color.Green
        End If
    End Sub

    Private Sub btn_Off_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Off.Click
        Dim ret As Integer
        Dim SetOnOFF As cDevMcPGControl.eOnOff = cDevMcPGControl.eOnOff.eOFF

        If fMain.cPG.PatternGenerator(m_nSelDev).cMcPGCtrl.Set_DisplayOnOFF(devAddr, devCH, ret, SetOnOFF) = True Then
            btn_on.BackColor = Color.Gray
        End If
    End Sub
End Class
