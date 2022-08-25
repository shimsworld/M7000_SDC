Imports CCommLib

Public Class ucM6000Config

#Region "Define"

    ' Public sM6000Config As 

    Dim sCommType() As String = New String() {"UDP", "TCP/IP", "Serial", "GPIB", "USB", "TCP/IP(Multi)"}

    ' Dim m_M6000Config As sConfig

    Private Event evAddConfigList()

    Dim sConfigData() As sM6000Config

    Property Setting() As sM6000Config()
        Get
            Return sConfigData
        End Get
        Set(ByVal value As sM6000Config())
            If value Is Nothing = False Then
                sConfigData = value
                For i As Integer = 0 To value.Length - 1
                    LoadDataSetting(value(i))
                Next
            End If
        End Set
    End Property

    Structure sM6000Config
        Dim numberOfBoard As Integer
        Dim communicationType As CComCommonNode.eCommType
        Dim settings As CComCommonNode.sCommInfo
        Dim nAllocationCh_From As Integer
        Dim nAllocationCh_To As Integer
        Dim iAllocationCh() As Integer
        Dim BoarMaxRange() As sM6000DeviceMaxRange
    End Structure

    Structure sM6000DeviceMaxRange
        Dim Volt As Double
        Dim Current As Double
    End Structure

#End Region


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()

    End Sub

    Private Sub init()
        gbConfig.Location = New System.Drawing.Point(0, 0)
        gbConfig.Dock = DockStyle.Fill

        With cbSelCommType
            .Items.Clear()
            For i As Integer = 0 To sCommType.Length - 1
                .Items.Add(sCommType(i))
            Next
            .SelectedIndex = 0
        End With

        txtIPBox1.Text = 192
        txtIPBox2.Text = 168
        txtIPBox3.Text = 124
        txtIPBox4.Text = 1
        txtChAlloStart.Text = 1
        txtChAlloEnd.Text = 32
        txtPort.Text = 7001
        txtBoardMaxCurrent.Text = 0
        txtBoarMaxVolt.Text = 0
    End Sub


    Private Sub cbSelCommType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelCommType.SelectedIndexChanged
        Dim typeOfComm As CComCommonNode.eCommType = cbSelCommType.SelectedIndex
        Select Case typeOfComm
            Case CComCommonNode.eCommType.eSerial
                ucDispRs232.Enabled = True
                gbIPSet.Enabled = False
            Case CComCommonNode.eCommType.eTCP
                gbIPSet.Enabled = True
                ucDispRs232.Enabled = False
            Case CComCommonNode.eCommType.eUDP
                gbIPSet.Enabled = True
                ucDispRs232.Enabled = False
            Case CComCommonNode.eCommType.eTCP_MultiSocket
                gbIPSet.Enabled = True
                ucDispRs232.Enabled = False
        End Select
    End Sub

    Private Function GetSettingForm(ByRef ConfigData As sM6000Config) As Boolean

        Dim iIP(3) As Integer

        Dim typeOfComm As CComCommonNode.eCommType = cbSelCommType.SelectedIndex
        Try
            ConfigData.communicationType = typeOfComm
            ConfigData.settings.commType = typeOfComm
            ConfigData.numberOfBoard = tbNumOfBoard.Text

            ConfigData.nAllocationCh_From = CInt(txtChAlloStart.Text)
            ConfigData.nAllocationCh_To = CInt(txtChAlloEnd.Text)


            'Boar max range 입력만 가능하게 변경(리스트나 콤보박스 형태로 변환 될거 같음) ' 2013-03-18 승현 
            ReDim ConfigData.BoarMaxRange(0)
            ConfigData.BoarMaxRange(0).Volt = CDbl(txtBoarMaxVolt.Text)
            ConfigData.BoarMaxRange(0).Current = CDbl(txtBoardMaxCurrent.Text)


        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try

        ConfigData.iAllocationCh = ucConfigRS485.GetChannelAssignList(ConfigData.nAllocationCh_From, ConfigData.nAllocationCh_To)

        If typeOfComm = CComCommonNode.eCommType.eTCP Or typeOfComm = CComCommonNode.eCommType.eUDP Or typeOfComm = CComCommonNode.eCommType.eTCP_MultiSocket Then
            iIP(0) = CInt(txtIPBox1.Text)
            iIP(1) = CInt(txtIPBox2.Text)
            iIP(2) = CInt(txtIPBox3.Text)
            iIP(3) = CInt(txtIPBox4.Text)

            With ConfigData
                With .settings.sLanInfo
                    ' .iDeviceNo = cbHWNum.SelectedIndex
                    .sIPAddress = iIP(0) & "." & iIP(1) & "." & iIP(2) & "." & iIP(3)
                    .nPort = CInt(txtPort.Text)
                End With
            End With

        ElseIf typeOfComm = CComCommonNode.eCommType.eSerial Then
            With ConfigData
                With .settings.sSerialInfo
                    .sPortName = ucDispRs232.COMPORT
                    .nBaudRate = ucDispRs232.BAUDRATE
                    .nParity = ucDispRs232.PARITYBIT
                    .nStopBits = ucDispRs232.STOPBIT
                    .nDataBits = ucDispRs232.DATABIT
                    .sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucDispRs232.RcvTerminator)
                    .sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucDispRs232.SendTerminator)
                End With
            End With
        Else
            Return False
        End If
        Return True
    End Function



    Private Sub ConfigListUP(ByVal ConfigData As sM6000Config)
        Dim sData(3) As String

        Select Case ConfigData.communicationType
            Case CComCommonNode.eCommType.eTCP, CComCommonNode.eCommType.eTCP_MultiSocket
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sLanInfo
                    sData(2) = .sIPAddress & "/" & CStr(.nPort)
                End With
                sData(3) = CStr(ConfigData.nAllocationCh_From) & "~" & CStr(ConfigData.nAllocationCh_To)
            Case CComCommonNode.eCommType.eUDP
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sLanInfo
                    sData(2) = .sIPAddress & "/" & CStr(.nPort)
                End With
                sData(3) = CStr(ConfigData.nAllocationCh_From) & "~" & CStr(ConfigData.nAllocationCh_To)
            Case CComCommonNode.eCommType.eSerial
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sSerialInfo
                    sData(2) = .sPortName & "/" & .nBaudRate ' "PortNo:" & .sPortName & "/" & "Baud:" & .nBaudRate
                End With
                sData(3) = CStr(ConfigData.nAllocationCh_From) & "~" & CStr(ConfigData.nAllocationCh_To)
        End Select

        ConfigList.AddRowData(sData)
    End Sub

    Private Sub LoadDataSetting(ByVal ConfigData As sM6000Config)
        Dim sData(3) As String

        Select Case ConfigData.communicationType
            Case CComCommonNode.eCommType.eTCP, CComCommonNode.eCommType.eTCP_MultiSocket
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sLanInfo
                    sData(2) = .sIPAddress & "/" & CStr(.nPort)
                End With

                If ConfigData.iAllocationCh Is Nothing = False Then
                    sData(3) = CStr(ConfigData.iAllocationCh(0)) & "~" & CStr(ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1))
                End If

            Case CComCommonNode.eCommType.eUDP
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sLanInfo
                    sData(2) = .sIPAddress & "/" & CStr(.nPort)
                End With

                If ConfigData.iAllocationCh Is Nothing = False Then
                    sData(3) = CStr(ConfigData.iAllocationCh(0)) & "~" & CStr(ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1))
                End If

            Case CComCommonNode.eCommType.eSerial
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sSerialInfo
                    sData(2) = .sPortName & "/" & .nBaudRate ' "PortNo:" & .sPortName & "/" & "Baud:" & .nBaudRate
                End With

                If ConfigData.iAllocationCh Is Nothing = False Then
                    sData(3) = CStr(ConfigData.iAllocationCh(0)) & "~" & CStr(ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1))
                End If

        End Select

        ConfigList.AddRowData(sData)

        With ConfigData
            cbSelCommType.SelectedIndex = .communicationType
            tbNumOfBoard.Text = .numberOfBoard
            If ConfigData.iAllocationCh Is Nothing = False Then
                txtChAlloStart.Text = ConfigData.iAllocationCh(0)
                txtChAlloEnd.Text = ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1)
            Else
                txtChAlloStart.Text = "0"
                txtChAlloEnd.Text = "0"
            End If

        End With
    End Sub

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click

        Dim m_M6000Config As sM6000Config = Nothing

        GetSettingForm(m_M6000Config)

        ConfigDataAdd(m_M6000Config)

        ConfigListUP(m_M6000Config)


    End Sub


    Private Sub btnListDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListDel.Click
        Dim SelectedNo As Integer

        ConfigList.GetSelectedRowNumber(SelectedNo)


        ConfigListDataDelete(SelectedNo)

        ConfigList.DelSelectedRow(SelectedNo)


    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        sConfigData = Nothing

        ConfigList.ClearAllData()

    End Sub

    Private Sub ConfigDataAdd(ByVal ConfigData As sM6000Config)

        '  Dim ConfigDataBuff(ConfigList.GetListItemCount) As sM6000Config

        ReDim Preserve sConfigData(ConfigList.GetListItemCount)

        sConfigData(ConfigList.GetListItemCount) = ConfigData


        'If ConfigList.GetListItemCount = 0 Then
        '    ConfigDataBuff(0) = ConfigData
        '    'ReDim ConfigDataBuff(ConfigList.GetListItemCount)
        '    ' sConfigData(0) = ConfigData
        'Else
        '    '  ReDim ConfigDataBuff(ConfigList.GetListItemCount)

        '    For i = 0 To sConfigData.Length - 1 '데이터 Length 에러
        '        If i = sConfigData.Length Then
        '            ConfigDataBuff(i) = ConfigData
        '        Else
        '            ConfigDataBuff(i) = sConfigData(i)
        '        End If
        '    Next

        '    ' ConfigDataBuff = sConfigData.Clone

        'End If

        'sConfigData = ConfigDataBuff.Clone

    End Sub

    Private Sub ConfigListDataDelete(ByVal DeleteNo As Integer)

        If DeleteNo <> 0 Then
            Dim ConfigDataBuff(sConfigData.Length - 2) As sM6000Config

            For i = 0 To sConfigData.Length - 1

                If i >= DeleteNo Then
                    If i = sConfigData.Length - 1 Then
                        sConfigData = ConfigDataBuff.Clone
                        Exit Sub
                    End If
                    ConfigDataBuff(i) = sConfigData(i + 1)

                Else
                    ConfigDataBuff(i) = sConfigData(i)
                End If
            Next
        End If

    End Sub

    Private Sub ConfigList_evSelectedIndexChanged(ByVal nRow As Integer) Handles ConfigList.evSelectedIndexChanged
        Dim configBuf As sM6000Config

        If sConfigData Is Nothing Then Exit Sub

        configBuf = sConfigData(nRow)

        SetValueToUI(configBuf)

    End Sub

    Private Sub SetValueToUI(ByVal ConfigData As sM6000Config)
        Dim sData(3) As String

        With ConfigData
            Select Case ConfigData.communicationType

                Case CComCommonNode.eCommType.eTCP, CComCommonNode.eCommType.eTCP_MultiSocket
                    Dim sIPaddress() As String

                    sIPaddress = Split(.settings.sLanInfo.sIPAddress, ".", -1)

                    ' cbSelCommType.SelectedIndex = CComCommonNode.eCommType.eTCP

                    Try
                        txtIPBox1.Text = sIPaddress(0)
                        txtIPBox2.Text = sIPaddress(1)
                        txtIPBox3.Text = sIPaddress(2)
                        txtIPBox4.Text = sIPaddress(3)
                        txtPort.Text = .settings.sLanInfo.nPort
                    Catch ex As Exception
                        MsgBox("Setting Error")
                        Exit Sub
                    End Try

                Case CComCommonNode.eCommType.eUDP
                    Dim sIPaddress() As String

                    sIPaddress = Split(.settings.sLanInfo.sIPAddress, ".", -1)

                    cbSelCommType.SelectedIndex = CComCommonNode.eCommType.eUDP
                    txtChAlloStart.Text = .nAllocationCh_From
                    txtChAlloEnd.Text = .nAllocationCh_To

                    Try
                        txtIPBox1.Text = sIPaddress(0)
                        txtIPBox2.Text = sIPaddress(1)
                        txtIPBox3.Text = sIPaddress(2)
                        txtIPBox4.Text = sIPaddress(3)
                        txtPort.Text = .settings.sLanInfo.nPort
                    Catch ex As Exception
                        MsgBox("Setting Error")
                        Exit Sub
                    End Try


                Case CComCommonNode.eCommType.eSerial
                    cbSelCommType.SelectedIndex = CComCommonNode.eCommType.eSerial
                    With .settings.sSerialInfo
                        ucDispRs232.COMPORT = .sPortName
                        ucDispRs232.BAUDRATE = .nBaudRate
                        ucDispRs232.PARITYBIT = .nParity
                        ucDispRs232.STOPBIT = .nStopBits
                        ucDispRs232.DATABIT = .nDataBits
                        ucDispRs232.RcvTerminator = ucConfigRs232.ConvertStringToIntTerminator(.sRcvTerminator)
                        ucDispRs232.SendTerminator = ucConfigRs232.ConvertStringToIntTerminator(.sSendTerminator)
                    End With

                Case CComCommonNode.eCommType.eGPIB

            End Select


            With ConfigData
                cbSelCommType.SelectedIndex = .communicationType
                tbNumOfBoard.Text = .numberOfBoard
                txtChAlloStart.Text = .nAllocationCh_From
                txtChAlloEnd.Text = .nAllocationCh_To
            End With
        End With

    End Sub

End Class
