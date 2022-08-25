Imports System.Windows.Forms

Public Class ucConfigMultiRS232



#Region "Define"

    Private Event evAddConfigList()

    Dim m_sConfigData() As sMultiRS232
    Dim m_nCnt As Integer = 0

    Property Setting() As sMultiRS232()
        Get
            Return m_sConfigData
        End Get
        Set(ByVal value As sMultiRS232())
            If value Is Nothing = False Then
                m_sConfigData = value
                m_nCnt = m_sConfigData.Length
                UpdateConfigList()
            End If
        End Set
    End Property

    Structure sMultiRS232
        Dim bIsOffline As Boolean
        Dim sSerialInfo As CComSerial.sSerialPortInfo
        Dim nAllocationCh_From As Integer
        Dim nAllocationCh_To As Integer
        Dim iAllocationCh() As Integer
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

        txtChAlloStart.Text = 1
        txtChAlloEnd.Text = 32
    End Sub

    Private Function GetValueFromUI(ByRef ConfigData As sMultiRS232) As Boolean

        Try
            ConfigData.nAllocationCh_From = CInt(txtChAlloStart.Text)
            ConfigData.nAllocationCh_To = CInt(txtChAlloEnd.Text)
            'Boar max range 입력만 가능하게 변경(리스트나 콤보박스 형태로 변환 될거 같음) ' 2013-03-18 승현 
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try

        ConfigData.iAllocationCh = ucConfigRS485.GetChannelAssignList(ConfigData.nAllocationCh_From, ConfigData.nAllocationCh_To)

        With ConfigData
            With .sSerialInfo
                .sPortName = ucDispRs232.COMPORT
                .nBaudRate = ucDispRs232.BAUDRATE
                .nParity = ucDispRs232.PARITYBIT
                .nStopBits = ucDispRs232.STOPBIT
                .nDataBits = ucDispRs232.DATABIT
                .sSendTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucDispRs232.SendTerminator)
                .sRcvTerminator = ucConfigRs232.ConvertIntTerminatorToString(ucDispRs232.RcvTerminator)
            End With

            ConfigData.bIsOffline = chkOFFLine.Checked
        End With

        Return True
    End Function


    Private Sub SetValueToUI(ByVal ConfigData As sMultiRS232)
        txtChAlloStart.Text = ConfigData.nAllocationCh_From
        txtChAlloEnd.Text = ConfigData.nAllocationCh_To

        With ConfigData
            With .sSerialInfo
                ucDispRs232.COMPORT = .sPortName
                ucDispRs232.BAUDRATE = .nBaudRate
                ucDispRs232.PARITYBIT = .nParity
                ucDispRs232.STOPBIT = .nStopBits
                ucDispRs232.DATABIT = .nDataBits
                ucDispRs232.RcvTerminator = ucConfigRs232.ConvertStringToIntTerminator(.sRcvTerminator)
                ucDispRs232.SendTerminator = ucConfigRs232.ConvertStringToIntTerminator(.sSendTerminator)
            End With

            chkOFFLine.Checked = ConfigData.bIsOffline
        End With
    End Sub

#Region "Config 정보 배열 ADD, Delete Function"

    Private Sub addConfigData(ByVal ConfigData As sMultiRS232)

        ReDim Preserve m_sConfigData(m_nCnt)

        m_sConfigData(m_nCnt) = ConfigData

        m_nCnt += 1
    End Sub

    Private Sub delConfigData(ByVal nIdx As Integer)
        If m_sConfigData Is Nothing Then Exit Sub

        If m_sConfigData.Length <= nIdx Then Exit Sub

        If m_sConfigData.Length = 1 Then
            m_sConfigData = Nothing
            m_nCnt = 0
        Else
            m_nCnt -= 1

            Dim configBuf(m_nCnt) As sMultiRS232
            Dim n As Integer = 0
            For i As Integer = 0 To m_sConfigData.Length - 1
                If i <> nIdx Then
                    configBuf(n) = m_sConfigData(i)
                    n += 1
                End If
            Next

            m_sConfigData = configBuf.Clone
        End If
    End Sub

#End Region

  


    

    Private Sub addConfigList(ByVal ConfigData As sMultiRS232)
        Dim sData(3) As String

        sData(0) = ConfigList.GetListItemCount + 1
        With ConfigData.sSerialInfo
            sData(1) = .sPortName & "/" & .nBaudRate ' "PortNo:" & .sPortName & "/" & "Baud:" & .nBaudRate
        End With
        sData(2) = CStr(ConfigData.nAllocationCh_From) & "~" & CStr(ConfigData.nAllocationCh_To)

        If ConfigData.bIsOffline = True Then
            sData(3) = "OFF-Line"
        Else
            sData(3) = "ON-Line"
        End If

        ConfigList.AddRowData(sData)
    End Sub

    Private Sub UpdateConfigList()

        ConfigList.ClearAllData()
        If m_sConfigData Is Nothing Then Exit Sub
        For i As Integer = 0 To m_sConfigData.Length - 1
            addConfigList(m_sConfigData(i))
        Next

    End Sub

 

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click

        Dim sConfig As sMultiRS232 = Nothing

        GetValueFromUI(sConfig)

        addConfigData(sConfig)

        UpdateConfigList()

    End Sub


    Private Sub btnListDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListDel.Click
        Dim SelectedNo As Integer
        ConfigList.GetSelectedRowNumber(SelectedNo)
        delConfigData(SelectedNo)
        UpdateConfigList()

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        m_sConfigData = Nothing
        m_nCnt = 0
        ConfigList.ClearAllData()

    End Sub



    Private Sub ConfigList_evSelectedIndexChanged(ByVal nRow As Integer) Handles ConfigList.evSelectedIndexChanged
        Dim configBuf As sMultiRS232

        If m_sConfigData Is Nothing Then Exit Sub

        configBuf = m_sConfigData(nRow)

        SetValueToUI(configBuf)
    End Sub


End Class
