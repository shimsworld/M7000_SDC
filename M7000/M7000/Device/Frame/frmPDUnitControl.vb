Imports CCommLib

Public Class frmPDUnitControl


#Region "Defines"

    Dim m_Main As frmMain

    Dim m_nSelGroup As Integer = 0
    Dim tbRatio() As System.Windows.Forms.TextBox
    Dim tbOffset() As System.Windows.Forms.TextBox

    Dim btnGetCalData() As System.Windows.Forms.Button
    Dim btnSetCalData() As System.Windows.Forms.Button

    Dim m_sConfig() As ucConfigMultiRS232.sMultiRS232

#End Region


#Region "Creator And Dispose, Initialization"


    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_Main = main
        m_sConfig = config.PDMeasurementUnit
        init()
    End Sub

    Private Sub init()

        ReDim tbRatio(CDevPDUnit.System_Ch - 1)
        ReDim tbOffset(CDevPDUnit.System_Ch - 1)

        ReDim btnGetCalData(CDevPDUnit.System_Ch - 1)
        ReDim btnSetCalData(CDevPDUnit.System_Ch - 1)

        Dim boxSize As Size = New Size(100, 21)
        Dim DefPointColumn1 As Point = New Point(75, 55)
        Dim DefPointColumn2 As Point = New Point(176, 55)
        Dim DefPointColumn3 As Point = New Point(477, 55)
        Dim DefPointColumn4 As Point = New Point(578, 55)
        Dim margine As Size = New Size(3, 3)

        Dim btnSize As Size = New Size(60, 23)
        Dim btnDefPtnCol01 As Point = New Point(280, 53)
        Dim btnDefPtnCol02 As Point = New Point(342, 53)
        Dim btnDefPtnCol03 As Point = New Point(682, 53)
        Dim btnDefPtnCol04 As Point = New Point(744, 53)

        With cboSelDevice
            .Items.Clear()
            For i As Integer = 0 To m_sConfig.Length - 1
                .Items.Add(i)
            Next
            .SelectedIndex = 0
        End With

        For i As Integer = 0 To tbRatio.Length - 1

            tbRatio(i) = New System.Windows.Forms.TextBox
            tbOffset(i) = New System.Windows.Forms.TextBox

            btnGetCalData(i) = New System.Windows.Forms.Button
            btnSetCalData(i) = New System.Windows.Forms.Button

            GroupBox1.Controls.Add(tbRatio(i))
            GroupBox1.Controls.Add(tbOffset(i))
            GroupBox1.Controls.Add(btnGetCalData(i))
            GroupBox1.Controls.Add(btnSetCalData(i))

            If i < 16 Then
                tbRatio(i).Size = boxSize
                tbRatio(i).Location = New System.Drawing.Point(DefPointColumn1.X, (boxSize.Height * i) + DefPointColumn1.Y + margine.Height)

                tbOffset(i).Size = boxSize
                tbOffset(i).Location = New System.Drawing.Point(DefPointColumn2.X, (boxSize.Height * i) + DefPointColumn2.Y + margine.Height)

                btnGetCalData(i).Size = btnSize
                btnGetCalData(i).Location = New System.Drawing.Point(btnDefPtnCol01.X, (btnSize.Height * i) + btnDefPtnCol01.Y + margine.Height)
                btnGetCalData(i).Text = "Read"
                btnGetCalData(i).Name = i
                AddHandler btnGetCalData(i).Click, AddressOf btnGetCalData_Click


                btnSetCalData(i).Size = btnSize
                btnSetCalData(i).Location = New System.Drawing.Point(btnDefPtnCol02.X, (btnSize.Height * i) + btnDefPtnCol02.Y + margine.Height)
                btnSetCalData(i).Text = "Write"
                btnSetCalData(i).Name = i
                AddHandler btnSetCalData(i).Click, AddressOf btnSetCalData_Click
            Else
                tbRatio(i).Size = boxSize
                tbRatio(i).Location = New System.Drawing.Point(DefPointColumn3.X, (boxSize.Height * (i - 16)) + DefPointColumn3.Y + margine.Height)
                tbOffset(i).Size = boxSize
                tbOffset(i).Location = New System.Drawing.Point(DefPointColumn4.X, (boxSize.Height * (i - 16)) + DefPointColumn4.Y + margine.Height)

                btnGetCalData(i).Size = btnSize
                btnGetCalData(i).Location = New System.Drawing.Point(btnDefPtnCol03.X, (btnSize.Height * (i - 16)) + btnDefPtnCol03.Y + margine.Height)
                btnGetCalData(i).Text = "Read"
                btnGetCalData(i).Name = i
                AddHandler btnGetCalData(i).Click, AddressOf btnGetCalData_Click
                btnSetCalData(i).Size = btnSize
                btnSetCalData(i).Location = New System.Drawing.Point(btnDefPtnCol04.X, (btnSize.Height * (i - 16)) + btnDefPtnCol04.Y + margine.Height)
                btnSetCalData(i).Text = "Write"
                btnSetCalData(i).Name = i
                AddHandler btnSetCalData(i).Click, AddressOf btnSetCalData_Click
            End If

        Next

    End Sub


#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbChannel.Items.Clear()

        For idx As Integer = 0 To CDevPDUnit.System_Ch - 1
            cbChannel.Items.Add("CH" & idx + 1)
        Next

        cbChannel.SelectedIndex = 0
    End Sub

    'BaudRate :19200
    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        Dim config As CComSerial.sSerialPortInfo = Nothing
        Dim RetData As String = Nothing

        '  config.commType = CComCommonNode.eCommType.eSerial
        config.sPortName = UcConfigRs232.COMPORT
        config.nBaudRate = UcConfigRs232.BAUDRATE
        config.nParity = UcConfigRs232.PARITYBIT
        config.nDataBits = UcConfigRs232.DATABIT
        config.nStopBits = UcConfigRs232.STOPBIT
        config.sRcvTerminator = UcConfigRs232.ConvertIntTerminatorToString(UcConfigRs232.RcvTerminator)
        config.sSendTerminator = vbCrLf

        If m_Main.cPG.PatternGenerator(m_nSelGroup).cMcPDMeasUnit(0).Connection(config) = True Then

        End If

        If m_Main.cPG.PatternGenerator(m_nSelGroup).cMcPDMeasUnit(0).Connection(config) = True Then
            If m_Main.cPG.PatternGenerator(m_nSelGroup).cMcPDMeasUnit(0).ReadDevInfo(RetData) = True Then
                RetData = RetData.TrimStart("(")
                RetData = RetData.TrimEnd(")")

                tbQueryMsg.AppendText("Connection Complete")
                tbQueryMsg.AppendText(vbCrLf)
                tbQueryMsg.AppendText(RetData)
                tbQueryMsg.AppendText(vbCrLf)
            Else
                tbQueryMsg.AppendText("Connection Fail")
                tbQueryMsg.AppendText(vbCrLf)
            End If

        Else
            tbQueryMsg.AppendText("Connection Fail")
            tbQueryMsg.AppendText(vbCrLf)

            Exit Sub
        End If
    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click
        m_Main.cPG.PatternGenerator(m_nSelGroup).cMcPDMeasUnit(0).Disconnection()

        tbQueryMsg.AppendText("Disonnection Complete")
        tbQueryMsg.AppendText(vbCrLf)
    End Sub


    Private Sub btnReadCalibrationData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadCalibrationData.Click

        Dim RetCalData() As CDevPDUnit.sCalParam = Nothing

        If m_Main.cPG.PatternGenerator(m_nSelGroup).cMcPDMeasUnit(0).IsConnected = False Then Exit Sub


        If m_Main.cPG.PatternGenerator(m_nSelGroup).cMcPDMeasUnit(0).ReadAllCalData(RetCalData) = False Then
            lbStatus.Text = "Read Cal. Data Fail"
            lbStatus.BackColor = Color.OrangeRed
            Exit Sub
        End If

        For idx As Integer = 0 To RetCalData.Length - 1

            tbRatio(idx).Text = RetCalData(idx).Ratio
            tbOffset(idx).Text = RetCalData(idx).Offset

            tbQueryMsg.AppendText("CH" & idx + 1 & " : " & RetCalData(idx).Ratio & "," & RetCalData(idx).Offset)

            tbQueryMsg.AppendText(vbCrLf)
        Next

        lbStatus.Text = "Read Cal. Data"
        lbStatus.BackColor = Color.Yellow

        lbStatus.Text = "Read Cal. Data Complete"
        lbStatus.BackColor = Color.Lime
    End Sub

    Private Sub btnReadPDCurrent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadPDCurrent.Click
        Dim dRetPDCurrent As String = Nothing
        Dim chNum As Integer = cbChannel.SelectedIndex
        Dim ResultPDCurrent As String = Nothing

        If m_Main.cPG.PatternGenerator(m_nSelGroup).cMcPDMeasUnit(0).IsConnected = False Then Exit Sub

        m_Main.cPG.PatternGenerator(m_nSelGroup).cMcPDMeasUnit(0).MeasurementPDCurrent(chNum, dRetPDCurrent)

        ResultPDCurrent = dRetPDCurrent * m_Main.cPG.PatternGenerator(m_nSelGroup).cMcPDMeasUnit(0).sCalData(chNum).Ratio + m_Main.cPG.PatternGenerator(m_nSelGroup).cMcPDMeasUnit(0).sCalData(chNum).Offset

        lbPDCurrent.Text = ResultPDCurrent

        tbQueryMsg.AppendText("Ref PD. Current(CH" & chNum + 1 & ") :")
        tbQueryMsg.AppendText(vbCrLf)
        tbQueryMsg.AppendText(ResultPDCurrent)
        tbQueryMsg.AppendText(vbCrLf)
    End Sub



    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        tbQueryMsg.Text = ""

    End Sub


#Region "Calibration Data Read/Write"

    Private Sub btnGetCalData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim btn As Windows.Forms.Button = sender
        Dim RetCalData As CDevPDUnit.sCalParam = Nothing
        Dim idx As Integer = btn.Name

        If m_Main.cPG.PatternGenerator(m_nSelGroup).cMcPDMeasUnit(0).IsConnected = False Then Exit Sub

        m_Main.cPG.PatternGenerator(m_nSelGroup).cMcPDMeasUnit(0).ReadCalData(idx, RetCalData)

        tbOffset(idx).Text = RetCalData.Offset
        tbRatio(idx).Text = RetCalData.Ratio
    End Sub

    Private Sub btnSetCalData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim btn As Windows.Forms.Button = sender
        Dim RetCalData As CDevPDUnit.sCalParam = Nothing

        Dim idx As Integer = btn.Name
        If m_Main.cPG.PatternGenerator(m_nSelGroup).cMcPDMeasUnit(0).IsConnected = False Then Exit Sub

        If RetCalData.Ratio.Substring(0, 1) = "-" Then
            RetCalData.Ratio = Format(CDbl(tbRatio(idx).Text), "0.00000")
        Else
            RetCalData.Ratio = Format(CDbl(tbRatio(idx).Text), "0.000000")
        End If

        If RetCalData.Offset.Substring(0, 1) = "-" Then
            RetCalData.Offset = Format(CDbl(tbOffset(idx).Text), "0.00000")
        Else
            RetCalData.Offset = Format(CDbl(tbOffset(idx).Text), "0.000000")
        End If

        m_Main.cPG.PatternGenerator(m_nSelGroup).cMcPDMeasUnit(0).WriteCalData(idx, RetCalData)
    End Sub

#End Region

    Private Sub cboSelDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSelDevice.SelectedIndexChanged

        Dim nIdx As Integer = cboSelDevice.SelectedIndex

        If m_sConfig Is Nothing Then Exit Sub

        UcConfigRs232.COMPORT = m_sConfig(nIdx).sSerialInfo.sPortName
        UcConfigRs232.BAUDRATE = m_sConfig(nIdx).sSerialInfo.nBaudRate
        UcConfigRs232.PARITYBIT = m_sConfig(nIdx).sSerialInfo.nParity
        UcConfigRs232.DATABIT = m_sConfig(nIdx).sSerialInfo.nDataBits
        UcConfigRs232.STOPBIT = m_sConfig(nIdx).sSerialInfo.nStopBits
        UcConfigRs232.RcvTerminator = UcConfigRs232.ConvertStringToIntTerminator(m_sConfig(nIdx).sSerialInfo.sRcvTerminator)
    End Sub
End Class
