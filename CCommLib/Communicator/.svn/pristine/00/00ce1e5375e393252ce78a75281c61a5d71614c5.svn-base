Imports System.Windows.Forms

Public Class ucConfigMultiGPIB

#Region "Define"

    Private Event evAddConfigList()

    Dim m_sConfigData() As sMultiGPIB
    Dim m_nCnt As Integer = 0

    Property Setting() As sMultiGPIB()
        Get
            Return m_sConfigData
        End Get
        Set(ByVal value As sMultiGPIB())
            If value Is Nothing = False Then
                m_sConfigData = value
                m_nCnt = m_sConfigData.Length
                UpdateConfigList()
            End If
        End Set
    End Property

    Public Structure sMultiGPIB
        Dim bIsOffline As Boolean
        Dim sGPIBInfo As CComGPIB.sGPIBInfos
        'Dim numberOfDevice As Integer
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

    Private Function GetValueFromUI(ByRef ConfigData As sMultiGPIB) As Boolean

        Try
            ConfigData.nAllocationCh_From = CInt(txtChAlloStart.Text)
            ConfigData.nAllocationCh_To = CInt(txtChAlloEnd.Text)
            'Boar max range 입력만 가능하게 변경(리스트나 콤보박스 형태로 변환 될거 같음) ' 2013-03-18 승현 
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try

        ConfigData.iAllocationCh = ucConfigRS485.GetChannelAssignList(ConfigData.nAllocationCh_From, ConfigData.nAllocationCh_To)

        ConfigData.sGPIBInfo.nAddress = ucDispGPIB.ADDRESS
        
        ConfigData.bIsOffline = chkOFFLine.Checked

        Return True
    End Function


    Private Sub SetValueToUI(ByVal ConfigData As sMultiGPIB)
        txtChAlloStart.Text = ConfigData.nAllocationCh_From
        txtChAlloEnd.Text = ConfigData.nAllocationCh_To

        ucDispGPIB.ADDRESS = ConfigData.sGPIBInfo.nAddress

        chkOFFLine.Checked = ConfigData.bIsOffline

    End Sub

#Region "Config 정보 배열 ADD, Delete Function"

    Private Sub addConfigData(ByVal ConfigData As sMultiGPIB)

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

            Dim configBuf(m_nCnt) As sMultiGPIB
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

    Private Sub addConfigList(ByVal ConfigData As sMultiGPIB)
        Dim sData(3) As String

        sData(0) = ConfigList.GetListItemCount + 1

        sData(1) = ConfigData.sGPIBInfo.nAddress

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

        Dim sConfig As sMultiGPIB = Nothing

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
        Dim configBuf As sMultiGPIB

        If m_sConfigData Is Nothing Then Exit Sub

        configBuf = m_sConfigData(nRow)

        SetValueToUI(configBuf)
    End Sub

End Class
