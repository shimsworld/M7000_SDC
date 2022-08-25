'Imports CCommLib

Public Class ucConfigRS232_RS485


#Region "Define"
    Dim m_sCommType() As String = New String() {"RS232", "RS485"}
    Dim m_sDeviceListNames() As String = Nothing
    Dim m_sConfigData() As sConfig
#End Region

#Region "Enum"
    Public Enum eDeviceType
        eKeithley
        eSwitch
    End Enum

#End Region

#Region "Structure"
    Structure sConfig
        Dim device As Integer   'Device Model Index
        Dim communicationType As CComCommonNode.eCommType
        Dim subCommunicationType As Integer
        Dim settings As CComCommonNode.sCommInfo
        Dim numberOfDevice As Integer
        Dim nSeedAddress As Integer
        Dim nAllocationCh_From As Integer
        Dim nAllocationCh_To As Integer
        Dim iAllocationCh() As Integer
        Dim bIsOffline As Boolean
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
                    ConfigListUP(value(i))
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
        gbConfig.Dock = Windows.Forms.DockStyle.Fill

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

        txtChAlloStart.Text = 1
        txtChAlloEnd.Text = 32
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

        Select Case cbSelCommType.SelectedIndex
            Case 0   'RS232
                ucDispRs232.Enabled = True
                tbNumOfDevice.Enabled = False
                txtAddress.Enabled = False
            Case 1  'RS485
                ucDispRs232.Enabled = True
                tbNumOfDevice.Enabled = True
                txtAddress.Enabled = True
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


    'Private Sub LoadDataSetting(ByVal ConfigData As sConfig)
    '    Dim sData(4) As String

    '    Select Case ConfigData.communicationType
    '        Case CComCommonNode.eCommType.eTCP
    '            sData(0) = ConfigList.GetListItemCount + 1
    '            sData(1) = ConfigData.communicationType.ToString
    '            With ConfigData.settings.sLanInfo
    '                sData(2) = .sIPAddress & "/" & CStr(.nPort)
    '            End With
    '            sData(3) = CStr(ConfigData.iAllocationCh(0)) & "~" & CStr(ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1))
    '        Case CComCommonNode.eCommType.eUDP
    '            sData(0) = ConfigList.GetListItemCount + 1
    '            sData(1) = ConfigData.communicationType.ToString
    '            With ConfigData.settings.sLanInfo
    '                sData(2) = .sIPAddress & "/" & CStr(.nPort)
    '            End With
    '            sData(3) = CStr(ConfigData.iAllocationCh(0)) & "~" & CStr(ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1))
    '        Case CComCommonNode.eCommType.eSerial
    '            sData(0) = ConfigList.GetListItemCount + 1
    '            sData(1) = ConfigData.communicationType.ToString
    '            With ConfigData.settings.sSerialInfo
    '                sData(2) = .sPortName & "/" & .nBaudRate ' "PortNo:" & .sPortName & "/" & "Baud:" & .nBaudRate
    '            End With
    '            sData(3) = CStr(ConfigData.iAllocationCh(0)) & "~" & CStr(ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1))
    '        Case CComCommonNode.eCommType.eGPIB
    '            sData(0) = ConfigList.GetListItemCount + 1
    '            sData(1) = ConfigData.communicationType.ToString
    '            With ConfigData.settings.sGPIBInfo
    '                sData(2) = .nAddress
    '            End With
    '            sData(3) = CStr(ConfigData.iAllocationCh(0)) & "~" & CStr(ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1))
    '    End Select

    '    sData(4) = m_sDeviceListNames(ConfigData.device)

    '    ConfigList.AddRowData(sData)

    '    With ConfigData
    '        cbSelDeviceSelect.SelectedIndex = .device
    '        cbSelCommType.SelectedIndex = .communicationType
    '        txtChAlloStart.Text = ConfigData.iAllocationCh(0)
    '        txtChAlloEnd.Text = ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1)
    '    End With
    'End Sub


    Private Sub SetValueToUI(ByVal ConfigData As sConfig)

        With ConfigData
            Select Case ConfigData.communicationType

                Case CComCommonNode.eCommType.eSerial
                    cbSelCommType.SelectedIndex = .subCommunicationType
                    With .settings.sSerialInfo
                        ucDispRs232.COMPORT = .sPortName
                        ucDispRs232.BAUDRATE = .nBaudRate
                        ucDispRs232.PARITYBIT = .nParity
                        ucDispRs232.STOPBIT = .nStopBits
                        ucDispRs232.DATABIT = .nDataBits
                        ucDispRs232.RcvTerminator = ucConfigRs232.ConvertStringToIntTerminator(.sRcvTerminator)
                        ucDispRs232.SendTerminator = ucConfigRs232.ConvertStringToIntTerminator(.sSendTerminator)
                    End With

            End Select

            txtChAlloStart.Text = .nAllocationCh_From
            txtChAlloEnd.Text = .nAllocationCh_To
            tbNumOfDevice.Text = .numberOfDevice
            txtAddress.Text = .nSeedAddress
            cbSelDeviceSelect.SelectedIndex = .device
            chkOFFLine.Checked = .bIsOffline
        End With

    End Sub

    Private Function GetValueFromUI(ByRef ConfigData As sConfig) As Boolean


        Dim typeOfComm As CComCommonNode.eCommType
        Dim typeOfSubComm As Integer = cbSelCommType.SelectedIndex
        Select Case typeOfSubComm
            Case 0 'RS232
                typeOfComm = CComCommonNode.eCommType.eSerial
            Case 1 'RS485
                typeOfComm = CComCommonNode.eCommType.eSerial
            Case Else
                Return False
        End Select


        Try
            ConfigData.device = cbSelDeviceSelect.SelectedIndex
            ConfigData.communicationType = typeOfComm
            ConfigData.subCommunicationType = typeOfSubComm
            ConfigData.settings.commType = typeOfComm

            ConfigData.nAllocationCh_From = CInt(txtChAlloStart.Text)
            ConfigData.nAllocationCh_To = CInt(txtChAlloEnd.Text)

            If cbSelCommType.SelectedIndex = 1 Then  'RS485 일때
                ConfigData.numberOfDevice = CInt(tbNumOfDevice.Text)
                ConfigData.nSeedAddress = CInt(txtAddress.Text)
            Else
                ConfigData.numberOfDevice = 0
                ConfigData.nSeedAddress = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try

        ConfigData.iAllocationCh = ucConfigRS485.GetChannelAssignList(ConfigData.nAllocationCh_From, ConfigData.nAllocationCh_To)

        With ConfigData.settings.sSerialInfo
            .sPortName = ucDispRs232.COMPORT
            .nBaudRate = ucDispRs232.BAUDRATE
            .nParity = ucDispRs232.PARITYBIT
            .nStopBits = ucDispRs232.STOPBIT
            .nDataBits = ucDispRs232.DATABIT
            .sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucDispRs232.SendTerminator)
            .sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucDispRs232.RcvTerminator)
        End With

        ConfigData.bIsOffline = chkOFFLine.Checked

        Return True
    End Function


    Private Sub ConfigListUP(ByVal ConfigData As sConfig)
        Dim sData(3) As String

        '   sData(0) = ConfigList.GetListItemCount + 1
        sData(0) = m_sCommType(ConfigData.subCommunicationType)
        With ConfigData.settings.sSerialInfo
            sData(1) = .sPortName & "/" & .nBaudRate ' "PortNo:" & .sPortName & "/" & "Baud:" & .nBaudRate
        End With
        sData(2) = CStr(ConfigData.nAllocationCh_From) & "~" & CStr(ConfigData.nAllocationCh_To)
        sData(3) = m_sDeviceListNames(ConfigData.device)

        ConfigList.AddRowData(sData)
    End Sub


    Private Sub ConfigList_evSelectedIndexChanged(ByVal nRow As Integer) Handles ConfigList.evSelectedIndexChanged
        Dim configBuf As sConfig

        If m_sConfigData Is Nothing Then Exit Sub

        configBuf = m_sConfigData(nRow)

        SetValueToUI(configBuf)

    End Sub

End Class
