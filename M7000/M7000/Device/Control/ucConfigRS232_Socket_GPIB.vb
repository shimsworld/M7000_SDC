Imports CCommLib
Imports CSMULib

Public Class ucConfigRS232_Socket_GPIB

#Region "Define"
    Dim m_sCommType() As String = New String() {"UDP", "TCP/IP", "Serial", "GPIB", "USB"}
    Dim m_sDeviceListNames() As String = Nothing
    Dim m_sConfigData() As sConfig
    ' Dim m_DeviceType As eDeviceType
#End Region

#Region "Enum"
    Public Enum eDeviceType
        eKeithley
        eSwitch
    End Enum

#End Region

#Region "Structure"

    Structure sConfig
        Dim communicationType As CComCommonNode.eCommType
        Dim settings As CComCommonNode.sCommInfo
        Dim nAllocationCh_From As Integer
        Dim nAllocationCh_To As Integer
        Dim iAllocationCh() As Integer
        Dim device As Integer   'Device Model Index
        Dim sRangeList As CDevSMUCommonNode.sRangeAndIntegTime
    End Structure
#End Region

#Region "Property"

    Property Setting() As sConfig()
        Get
            Return m_sConfigData
        End Get
        Set(ByVal value As sConfig())
            If value Is Nothing = False Then
                m_sConfigData = value
                For i As Integer = 0 To value.Length - 1
                    LoadDataSetting(value(i))
                Next
            End If

        End Set
    End Property
#End Region


#Region "Creator, Dispose and Init"
    Public Sub New(ByVal sDeviceList() As String)
        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_sDeviceListNames = sDeviceList.Clone
        init()
    End Sub

    Private Sub init()
        gbConfig.Location = New System.Drawing.Point(0, 0)
        gbConfig.Dock = DockStyle.Fill

        With cbSelDeviceSelect
            .Items.Clear()
            For i As Integer = 0 To m_sDeviceListNames.Length - 1
                .Items.Add(m_sDeviceListNames(i))
            Next
            .SelectedIndex = 0
        End With


        With cbSelCommType
            .Items.Clear()
            For i As Integer = 0 To m_sCommType.Length - 1
                .Items.Add(m_sCommType(i))
            Next
            .SelectedIndex = 0
        End With

        txtIPBox1.Text = 192
        txtIPBox2.Text = 168
        txtIPBox3.Text = 0
        txtIPBox4.Text = 5
        txtChAlloStart.Text = 1
        txtChAlloEnd.Text = 32
        txtPort.Text = 6000
        tbAddressNumber.Text = 16
    End Sub
#End Region

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click
        Dim sConfig As sConfig = Nothing

        GetValueFromUI(sConfig)

        ConfigDataUpdate(sConfig)

        ConfigListUP(sConfig)

    End Sub

    Private Sub btnListDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListDel.Click
        Dim SelectedNo As Integer

        ConfigList.GetSelectedRowNumber(SelectedNo)

        ConfigListDataDelete(SelectedNo)

        ConfigList.DelSelectedRow(SelectedNo)


    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        m_sConfigData = Nothing

        ConfigList.ClearAllData()

    End Sub

    Private Sub cbSelCommType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelCommType.SelectedIndexChanged
        Dim typeOfComm As CComCommonNode.eCommType = cbSelCommType.SelectedIndex
        Select Case typeOfComm
            Case CComCommonNode.eCommType.eSerial
                ucDispRs232.Enabled = True
                gbIPSet.Enabled = False
                gbGPIBSet.Enabled = False
            Case CComCommonNode.eCommType.eTCP
                gbIPSet.Enabled = True
                ucDispRs232.Enabled = False
                gbGPIBSet.Enabled = False
            Case CComCommonNode.eCommType.eUDP
                gbIPSet.Enabled = True
                ucDispRs232.Enabled = False
                gbGPIBSet.Enabled = False
            Case CComCommonNode.eCommType.eGPIB
                gbGPIBSet.Enabled = True
                ucDispRs232.Enabled = False
                gbIPSet.Enabled = False
            Case CComCommonNode.eCommType.eUSB
                gbGPIBSet.Enabled = False
                ucDispRs232.Enabled = False
                gbIPSet.Enabled = False
        End Select
    End Sub



    Private Sub ConfigDataUpdate(ByVal ConfigData As sConfig)
        ReDim Preserve m_sConfigData(ConfigList.GetListItemCount)
        m_sConfigData(ConfigList.GetListItemCount) = ConfigData
    End Sub

    Private Sub ConfigListDataDelete(ByVal DeleteNo As Integer)

        If DeleteNo <> 0 Then
            Dim ConfigDataBuff(m_sConfigData.Length - 2) As sConfig

            For i = 0 To m_sConfigData.Length - 1

                If i >= DeleteNo Then
                    If i = m_sConfigData.Length - 1 Then
                        m_sConfigData = ConfigDataBuff.Clone
                        Exit Sub
                    End If
                    ConfigDataBuff(i) = m_sConfigData(i + 1)

                Else
                    ConfigDataBuff(i) = m_sConfigData(i)
                End If
            Next
        End If

    End Sub


    Private Sub LoadDataSetting(ByVal ConfigData As sConfig)
        Dim sData(4) As String

        Select Case ConfigData.communicationType
            Case CComCommonNode.eCommType.eTCP
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sLanInfo
                    sData(2) = .sIPAddress & "/" & CStr(.nPort)
                End With

            Case CComCommonNode.eCommType.eUDP
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sLanInfo
                    sData(2) = .sIPAddress & "/" & CStr(.nPort)
                End With
            Case CComCommonNode.eCommType.eSerial
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sSerialInfo
                    sData(2) = .sPortName & "/" & .nBaudRate ' "PortNo:" & .sPortName & "/" & "Baud:" & .nBaudRate
                End With
            Case CComCommonNode.eCommType.eGPIB
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sGPIBInfo
                    sData(2) = .nAddress
                End With
            Case CComCommonNode.eCommType.eUSB
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                sData(2) = ""
        End Select

        If ConfigData.iAllocationCh Is Nothing = False Then
            sData(3) = CStr(ConfigData.iAllocationCh(0)) & "~" & CStr(ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1))
        Else
            sData(3) = "Nothing"
        End If

        sData(4) = m_sDeviceListNames(ConfigData.device)

        ConfigList.AddRowData(sData)

        With ConfigData
            cbSelDeviceSelect.SelectedIndex = .device
            cbSelCommType.SelectedIndex = .communicationType
            If ConfigData.iAllocationCh Is Nothing = False Then
                txtChAlloStart.Text = ConfigData.iAllocationCh(0)
                txtChAlloEnd.Text = ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1)
            Else
                txtChAlloStart.Text = "0"
                txtChAlloEnd.Text = "0"
            End If

        End With
    End Sub


    Private Sub SetValueToUI(ByVal ConfigData As sConfig)
        Dim sData(3) As String

        With ConfigData
            Select Case ConfigData.communicationType

                Case CComCommonNode.eCommType.eTCP
                    Dim sIPaddress() As String

                    sIPaddress = Split(.settings.sLanInfo.sIPAddress, ".", -1)

                    cbSelCommType.SelectedIndex = CComCommonNode.eCommType.eTCP

                    txtIPBox1.Text = sIPaddress(0)
                    txtIPBox2.Text = sIPaddress(1)
                    txtIPBox3.Text = sIPaddress(2)
                    txtIPBox4.Text = sIPaddress(3)
                    txtPort.Text = .settings.sLanInfo.nPort

                Case CComCommonNode.eCommType.eUDP
                    Dim sIPaddress() As String

                    sIPaddress = Split(.settings.sLanInfo.sIPAddress, ".", -1)

                    cbSelCommType.SelectedIndex = CComCommonNode.eCommType.eUDP
                    txtChAlloStart.Text = .nAllocationCh_From
                    txtChAlloEnd.Text = .nAllocationCh_To

                    txtIPBox1.Text = sIPaddress(0)
                    txtIPBox2.Text = sIPaddress(1)
                    txtIPBox3.Text = sIPaddress(2)
                    txtIPBox4.Text = sIPaddress(3)
                    txtPort.Text = .settings.sLanInfo.nPort

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
                    cbSelCommType.SelectedIndex = CComCommonNode.eCommType.eGPIB
                    tbAddressNumber.Text = .settings.sGPIBInfo.nAddress
                Case CComCommonNode.eCommType.eUSB
                    cbSelCommType.SelectedIndex = CComCommonNode.eCommType.eUSB
            End Select

            txtChAlloStart.Text = .nAllocationCh_From
            txtChAlloEnd.Text = .nAllocationCh_To
            cbSelDeviceSelect.SelectedIndex = .device
        End With

    End Sub

    Private Function GetValueFromUI(ByRef ConfigData As sConfig) As Boolean

        Dim iIP(3) As Integer

        Dim typeOfComm As CComCommonNode.eCommType = cbSelCommType.SelectedIndex


        Try
            ConfigData.device = cbSelDeviceSelect.SelectedIndex
            ConfigData.communicationType = typeOfComm
            ConfigData.settings.commType = typeOfComm

            ConfigData.nAllocationCh_From = CInt(txtChAlloStart.Text)
            ConfigData.nAllocationCh_To = CInt(txtChAlloEnd.Text)

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try

        ConfigData.iAllocationCh = ucConfigRS485.GetChannelAssignList(ConfigData.nAllocationCh_From, ConfigData.nAllocationCh_To)

        If typeOfComm = CComCommonNode.eCommType.eTCP Or typeOfComm = CComCommonNode.eCommType.eUDP Then
            iIP(0) = CInt(txtIPBox1.Text)
            iIP(1) = CInt(txtIPBox2.Text)
            iIP(2) = CInt(txtIPBox3.Text)
            iIP(3) = CInt(txtIPBox4.Text)

            With ConfigData.settings.sLanInfo
                .sIPAddress = iIP(0) & "." & iIP(1) & "." & iIP(2) & "." & iIP(3)
                .nPort = CInt(txtPort.Text)
            End With


        ElseIf typeOfComm = CComCommonNode.eCommType.eSerial Then

            With ConfigData.settings.sSerialInfo
                .sPortName = ucDispRs232.COMPORT
                .nBaudRate = ucDispRs232.BAUDRATE
                .nParity = ucDispRs232.PARITYBIT
                .nStopBits = ucDispRs232.STOPBIT
                .nDataBits = ucDispRs232.DATABIT
                .sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucDispRs232.SendTerminator)
                .sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucDispRs232.RcvTerminator)
            End With

        ElseIf typeOfComm = CComCommonNode.eCommType.eGPIB Then

            With ConfigData.settings.sGPIBInfo
                .nAddress = CInt(tbAddressNumber.Text)
            End With

        ElseIf typeOfComm = CComCommonNode.eCommType.eUSB Then

        Else
            Return False
        End If
        Return True
    End Function


    Private Sub ConfigListUP(ByVal ConfigData As sConfig)
        Dim sData(4) As String

        Select Case ConfigData.communicationType
            Case CComCommonNode.eCommType.eTCP
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sLanInfo
                    sData(2) = .sIPAddress & "/" & CStr(.nPort)
                End With
            Case CComCommonNode.eCommType.eUDP
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sLanInfo
                    sData(2) = .sIPAddress & "/" & CStr(.nPort)
                End With
            Case CComCommonNode.eCommType.eSerial
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sSerialInfo
                    sData(2) = .sPortName & "/" & .nBaudRate ' "PortNo:" & .sPortName & "/" & "Baud:" & .nBaudRate
                End With
            Case CComCommonNode.eCommType.eGPIB
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sGPIBInfo
                    sData(2) = .nAddress
                End With
            Case CComCommonNode.eCommType.eUSB
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                sData(2) = ""

        End Select
        sData(3) = CStr(ConfigData.nAllocationCh_From) & "~" & CStr(ConfigData.nAllocationCh_To)
        sData(4) = m_sDeviceListNames(ConfigData.device)

        ConfigList.AddRowData(sData)
    End Sub

  
    Private Sub ConfigList_evSelectedIndexChanged(ByVal nRow As Integer) Handles ConfigList.evSelectedIndexChanged
        Dim configBuf As sConfig

        If m_sConfigData Is Nothing Then Exit Sub

        configBuf = m_sConfigData(nRow)

        SetValueToUI(configBuf)

    End Sub

  
End Class
