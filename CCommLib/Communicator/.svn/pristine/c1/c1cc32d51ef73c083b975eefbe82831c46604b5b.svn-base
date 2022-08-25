Imports System.Windows.Forms


Public Class ucConfigRS485

    Dim sConfigData() As sRS485Config

    Dim m_nDispMode As eDispMode = eDispMode.eVerticalArrange

    Public Enum eDispMode
        eHorizontalArrange
        eVerticalArrange
    End Enum

    Public Structure sRS485Config
        Dim bIsOffline As Boolean
        Dim numberOfDevice As Integer
        Dim nSeedAddress As Integer
        Dim sSerialInfo As CComSerial.sSerialPortInfo
        Dim nAllocationCh_From As Integer
        Dim nAllocationCh_To As Integer
        Dim iAllocationCh() As Integer
    End Structure


    Public Property Title() As String
        Get
            Return gbConfig.Text
        End Get
        Set(ByVal value As String)
            gbConfig.Text = value
        End Set
    End Property

    Public Property Setting() As sRS485Config()
        Get
            Return sConfigData
        End Get
        Set(ByVal value As sRS485Config())
            If value Is Nothing = False Then
                sConfigData = value
                For i As Integer = 0 To value.Length - 1
                    LoadDataSetting(value(i))
                Next
            End If
        End Set
    End Property

    Public Property DispMode As eDispMode
        Get
            Return m_nDispMode
        End Get
        Set(ByVal value As eDispMode)
            m_nDispMode = value
            UpdateDisp()

        End Set
    End Property



    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        gbConfig.Location = New System.Drawing.Point(0, 0)
        gbConfig.Dock = DockStyle.Fill
        txtAddress.Text = 0
    End Sub

    Private Sub UpdateDisp()
        Select Case m_nDispMode

            Case eDispMode.eVerticalArrange
                ' gbConfig.Size = New System.Drawing.Size(592, 374)
                ConfigList.Location = New System.Drawing.Point(6, 211)
            Case eDispMode.eHorizontalArrange
                ' gbConfig.Size = New System.Drawing.Size(1173, 227)
                ConfigList.Location = New System.Drawing.Point(btnADD.Location.X + btnADD.Size.Width + 10, btnADD.Location.Y)
        End Select
    End Sub

    Private Sub GetSettingForm(ByRef ConfigData As sRS485Config)
        Dim nCh As Integer = Nothing

        With ConfigData
            .numberOfDevice = CInt(tbNumOfDevice.Text)
            .nSeedAddress = CInt(txtAddress.Text)
            With .sSerialInfo
                .sPortName = UcConfigRs232.COMPORT
                .nBaudRate = UcConfigRs232.BAUDRATE
                .nParity = UcConfigRs232.PARITYBIT
                .nStopBits = UcConfigRs232.STOPBIT
                .nDataBits = UcConfigRs232.DATABIT
                .sRcvTerminator = UcConfigRs232.ConvertIntTerminatorToString(UcConfigRs232.RcvTerminator)
                .sSendTerminator = UcConfigRs232.ConvertIntTerminatorToString(UcConfigRs232.SendTerminator)
            End With
            .nAllocationCh_From = CInt(txtChAlloStart.Text)
            .nAllocationCh_To = CInt(txtChAlloEnd.Text)

            nCh = (CInt(txtChAlloEnd.Text) - CInt(txtChAlloStart.Text))

            ReDim .iAllocationCh(nCh)
            For i = 0 To nCh
                .iAllocationCh(i) = CInt(txtChAlloStart.Text) + i
            Next
            .bIsOffline = chkOFFLine.Checked
        End With
    End Sub

    Private Sub SetValueToUI(ByVal Config As sRS485Config)
        With Config
            tbNumOfDevice.Text = .numberOfDevice
            txtAddress.Text = .nSeedAddress
            txtChAlloStart.Text = .nAllocationCh_From
            txtChAlloEnd.Text = .nAllocationCh_To

            With .sSerialInfo
                UcConfigRs232.COMPORT = .sPortName
                UcConfigRs232.BAUDRATE = .nBaudRate
                UcConfigRs232.PARITYBIT = .nParity
                UcConfigRs232.STOPBIT = .nStopBits
                UcConfigRs232.DATABIT = .nDataBits
                UcConfigRs232.RcvTerminator = UcConfigRs232.ConvertStringToIntTerminator(.sRcvTerminator)
                UcConfigRs232.SendTerminator = UcConfigRs232.ConvertStringToIntTerminator(.sSendTerminator)
                '.sRcvTerminator = UcConfigRs232.ConvertIntTerminatorToString(UcConfigRs232.RcvTerminator)
                '.sSendTerminator = UcConfigRs232.ConvertIntTerminatorToString(UcConfigRs232.SendTerminator)
            End With
        End With
    End Sub

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click
        Dim Config As sRS485Config = Nothing

        GetSettingForm(Config)

        ConfigDataUpdate(Config)

        ConfigListUP(Config)

    End Sub

    Private Sub ConfigListUP(ByVal ConfigData As sRS485Config)

        Dim sData(6) As String

        With ConfigData
            sData(0) = ConfigList.GetListItemCount + 1
            sData(1) = .numberOfDevice
            sData(2) = .nSeedAddress
            sData(3) = .sSerialInfo.sPortName & "," & .sSerialInfo.nBaudRate & "," & .sSerialInfo.nDataBits
            sData(4) = txtChAlloStart.Text & "~" & txtChAlloEnd.Text
            If .bIsOffline = True Then
                sData(5) = "OFF-LINE"
            Else
                sData(5) = "ON-LINE"
            End If
        End With

        ConfigList.AddRowData(sData)

    End Sub


    Private Sub LoadDataSetting(ByVal ConfigData As sRS485Config)

        Dim sData(6) As String

        With ConfigData
            sData(0) = ConfigList.GetListItemCount + 1
            sData(1) = .numberOfDevice
            sData(2) = .nSeedAddress
            sData(3) = .sSerialInfo.sPortName & "," & .sSerialInfo.nBaudRate & "," & .sSerialInfo.nDataBits
            sData(4) = .nAllocationCh_From & "~" & .nAllocationCh_To ' .iAllocationCh(0) & "~" & .iAllocationCh(.iAllocationCh.Length - 1)
            If .bIsOffline = True Then
                sData(5) = "OFF-LINE"
            Else
                sData(5) = "ON-LINE"
            End If
        End With

        ConfigList.AddRowData(sData)

        With ConfigData
            tbNumOfDevice.Text = .numberOfDevice
            txtAddress.Text = .nSeedAddress
            txtChAlloStart.Text = .nAllocationCh_From '.iAllocationCh(0)
            txtChAlloEnd.Text = .nAllocationCh_To '.iAllocationCh(.iAllocationCh.Length - 1)
        End With

    End Sub

    Private Sub ConfigDataUpdate(ByVal ConfigData As sRS485Config)

        Dim ConfigDataBuff(ConfigList.GetListItemCount) As sRS485Config

        If ConfigList.GetListItemCount = 0 Then
            ConfigDataBuff(0) = ConfigData
        Else
            ReDim ConfigDataBuff(ConfigList.GetListItemCount)

            For i = 0 To sConfigData.Length
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

        Dim ConfigDataBuff(sConfigData.Length - 2) As sRS485Config

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


    Public Shared Function GetChannelAssignList(ByVal start As Integer, ByVal nEnd As Integer) As Integer()
        Dim nCh As Integer
        Dim nList() As Integer
        nCh = nEnd - start

        ReDim nList(nCh)
        For i = 0 To nCh
            nList(i) = start + i
        Next
        Return nList.Clone
    End Function

    Private Sub ConfigList_evSelectedIndexChanged(ByVal nRow As Integer) Handles ConfigList.evSelectedIndexChanged
        Dim configBuf As sRS485Config

        If sConfigData Is Nothing Then Exit Sub

        configBuf = sConfigData(nRow)

        SetValueToUI(configBuf)
    End Sub
  
End Class
