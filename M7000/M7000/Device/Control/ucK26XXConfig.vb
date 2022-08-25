Imports CCommLib

Public Class ucK26XXConfig

#Region "Define"
    Dim sCommType() As String = New String() {"TCP/IP", "UDP", "Serial", "GPIB"}

    Dim sConfigData() As sK26XXConfig

#End Region


#Region "Structure"

    Structure sK26XXConfig
        Dim communicationType As CComCommonNode.eCommType
        Dim settings As CComCommonNode.sCommInfo
        Dim nAllocationCh_From As Integer
        Dim nAllocationCh_To As Integer
        Dim iAllocationCh() As Integer
    End Structure
#End Region

#Region "Property"

    Property Setting() As sK26XXConfig()
        Get
            Return sConfigData
        End Get
        Set(ByVal value As sK26XXConfig())
            If value Is Nothing = False Then
                sConfigData = value
                For i As Integer = 0 To value.Length - 1
                    LoadDataSetting(value(i))
                Next
            End If
        End Set
    End Property
#End Region


#Region "Creator, Dispose and Init"
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
        txtIPBox3.Text = 0
        txtIPBox4.Text = 5
        txtChAlloStart.Text = 1
        txtChAlloEnd.Text = 32
        txtPort.Text = 6000
        tbAddressNumber.Text = 16
    End Sub
#End Region

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click
        Dim m_K26XXConfig As sK26XXConfig = Nothing

        GetSettingForm(m_K26XXConfig)

        ConfigDataUpdate(m_K26XXConfig)

        ConfigListUP(m_K26XXConfig)
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
        End Select
    End Sub


    Private Sub ConfigDataUpdate(ByVal ConfigData As sK26XXConfig)

        Dim ConfigDataBuff(ConfigList.GetListItemCount) As sK26XXConfig

        If ConfigList.GetListItemCount = 0 Then
            ConfigDataBuff(0) = ConfigData

        Else
            ReDim ConfigDataBuff(ConfigList.GetListItemCount)

            For i = 0 To sConfigData.Length - 1 '데이터 Length 에러
                If i = sConfigData.Length Then
                    ConfigDataBuff(i) = ConfigData
                Else
                    ConfigDataBuff(i) = sConfigData(i)
                End If
            Next

        End If

        sConfigData = ConfigDataBuff.Clone

    End Sub

    Private Sub ConfigListDataDelete(ByVal DeleteNo As Integer)

        If DeleteNo <> 0 Then
            Dim ConfigDataBuff(sConfigData.Length - 2) As sK26XXConfig

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


    Private Sub LoadDataSetting(ByVal ConfigData As sK26XXConfig)
        Dim sData(3) As String

        Select Case ConfigData.communicationType
            Case CComCommonNode.eCommType.eTCP
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sLanInfo
                    sData(2) = .sIPAddress & "/" & CStr(.nPort)
                End With
                sData(3) = CStr(ConfigData.iAllocationCh(0)) & "~" & CStr(ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1))
            Case CComCommonNode.eCommType.eUDP
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sLanInfo
                    sData(2) = .sIPAddress & "/" & CStr(.nPort)
                End With
                sData(3) = CStr(ConfigData.iAllocationCh(0)) & "~" & CStr(ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1))
            Case CComCommonNode.eCommType.eSerial
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sSerialInfo
                    sData(2) = .sPortName & "/" & .nBaudRate ' "PortNo:" & .sPortName & "/" & "Baud:" & .nBaudRate
                End With
                sData(3) = CStr(ConfigData.iAllocationCh(0)) & "~" & CStr(ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1))
            Case CComCommonNode.eCommType.eGPIB
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sGPIBInfo
                    sData(2) = .nAddress
                End With
        End Select

        ConfigList.AddRowData(sData)

        With ConfigData
            cbSelCommType.SelectedIndex = .communicationType
            txtChAlloStart.Text = ConfigData.iAllocationCh(0)
            txtChAlloEnd.Text = ConfigData.iAllocationCh(ConfigData.iAllocationCh.Length - 1)
        End With
    End Sub


    Private Function GetSettingForm(ByRef ConfigData As sK26XXConfig) As Boolean

        Dim iIP(3) As Integer

        Dim typeOfComm As CComCommonNode.eCommType = cbSelCommType.SelectedIndex

        Try
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
                .sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucDispRs232.RcvTerminator)
                .sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucDispRs232.SendTerminator)
            End With

        ElseIf typeOfComm = CComCommonNode.eCommType.eGPIB Then

            With ConfigData.settings.sGPIBInfo
                .nAddress = CInt(tbAddressNumber.Text)
            End With

        Else
            Return False
        End If
        Return True
    End Function


    Private Sub ConfigListUP(ByVal ConfigData As sK26XXConfig)
        Dim sData(3) As String

        Select Case ConfigData.communicationType
            Case CComCommonNode.eCommType.eTCP
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
            Case CComCommonNode.eCommType.eGPIB
                sData(0) = ConfigList.GetListItemCount + 1
                sData(1) = ConfigData.communicationType.ToString
                With ConfigData.settings.sGPIBInfo
                    sData(2) = .nAddress
                End With
                sData(3) = CStr(ConfigData.nAllocationCh_From) & "~" & CStr(ConfigData.nAllocationCh_To)

        End Select

        ConfigList.AddRowData(sData)
    End Sub
End Class
