Public Class ucConfigMcPGGroup




#Region "Define"

    Private Event evAddConfigList()

    Dim m_sConfigData() As sMcPGGroupInfos
    Dim m_nCnt As Integer

    Property Setting() As sMcPGGroupInfos()
        Get
            Return m_sConfigData
        End Get
        Set(ByVal value As sMcPGGroupInfos())
            If value Is Nothing = False Then
                m_sConfigData = value
                m_nCnt = m_sConfigData.Length
                UpdateConfigList()
            End If
        End Set
    End Property

    Structure sMcPGGroupInfos
        Dim nSeedCh As Integer
        Dim bEnablePG As Boolean
        Dim bEnablePGPwr As Boolean
        Dim bEnablePGCtrl As Boolean
        Dim bEnablePDUnit As Boolean
        Dim nPGNoFrom As Integer
        Dim nPGNoTo As Integer
        Dim nPGNo() As Integer
        Dim nPGPwrNo As Integer
        Dim nPGCtrlBDNo As Integer
        Dim nPDUnitNoFrom As Integer
        Dim nPDUnitNoTo As Integer
        Dim nPDUnitNo() As Integer
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

    End Sub

    Private Function GetValueFromUI(ByRef ConfigData As sMcPGGroupInfos) As Boolean

        Try
            ConfigData.nSeedCh = tbSeedCh.Text

            ConfigData.bEnablePDUnit = chkEnablePDUnit.Checked
            ConfigData.bEnablePG = chkEnablePG.Checked
            ConfigData.bEnablePGCtrl = chkEnablePGCtrlBD.Checked
            ConfigData.bEnablePGPwr = chkEnablePGPwr.Checked

            If ConfigData.bEnablePDUnit = True Then
                ConfigData.nPDUnitNoFrom = CInt(tbPDUnitNoFrom.Text)
                ConfigData.nPDUnitNoTo = CInt(tbPDUnitNoTo.Text)
                ConfigData.nPDUnitNo = CCommLib.ucConfigRS485.GetChannelAssignList(ConfigData.nPDUnitNoFrom, ConfigData.nPDUnitNoTo)
            End If

            If ConfigData.bEnablePG = True Then
                ConfigData.nPGNoFrom = CInt(tbPGNoFrom.Text)
                ConfigData.nPGNoTo = CInt(tbPGNoTo.Text)
                ConfigData.nPGNo = CCommLib.ucConfigRS485.GetChannelAssignList(ConfigData.nPGNoFrom, ConfigData.nPGNoTo)
            End If

            If ConfigData.bEnablePGCtrl = True Then
                ConfigData.nPGCtrlBDNo = CInt(tbPGCtrlBDNo.Text)
            End If

            If ConfigData.bEnablePGPwr = True Then
                ConfigData.nPGPwrNo = CInt(tbPGPwrNo.Text)
            End If

            'Boar max range 입력만 가능하게 변경(리스트나 콤보박스 형태로 변환 될거 같음) ' 2013-03-18 승현 
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try

        Return True
    End Function



    Private Sub SetValueToUI(ByVal ConfigData As sMcPGGroupInfos)

        tbSeedCh.Text = ConfigData.nSeedCh
        chkEnablePDUnit.Checked = ConfigData.bEnablePDUnit
        chkEnablePG.Checked = ConfigData.bEnablePG
        chkEnablePGCtrlBD.Checked = ConfigData.bEnablePGCtrl
        chkEnablePGPwr.Checked = ConfigData.bEnablePGPwr

        If ConfigData.bEnablePDUnit = True Then
            tbPDUnitNoFrom.Text = ConfigData.nPDUnitNoFrom
            tbPDUnitNoTo.Text = ConfigData.nPDUnitNoTo
        End If

        If ConfigData.bEnablePG = True Then
            tbPGNoFrom.Text = ConfigData.nPGNoFrom
            tbPGNoTo.Text = ConfigData.nPGNoTo
        End If

        If ConfigData.bEnablePGCtrl = True Then
            tbPGCtrlBDNo.Text = ConfigData.nPGCtrlBDNo
        End If

        If ConfigData.bEnablePGPwr = True Then
            tbPGPwrNo.Text = ConfigData.nPGPwrNo
        End If
    End Sub


#Region "Config 정보 배열 ADD, Delete Function"

    Private Sub addConfigData(ByVal ConfigData As sMcPGGroupInfos)

        ReDim Preserve m_sConfigData(m_nCnt)

        m_sConfigData(m_nCnt) = ConfigData

        m_nCnt += 1
    End Sub

    Private Sub delConfigData(ByVal nIdx As Integer)
        If m_sConfigData Is Nothing Then Exit Sub

        If m_sConfigData.Length <= nIdx Then Exit Sub

        If m_sConfigData.Length = 1 Then
            m_sConfigData = Nothing
            m_nCnt -= 1   'aaa
        Else
            m_nCnt -= 1   'aaa

            Dim configBuf(m_nCnt - 1) As sMcPGGroupInfos
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


    Private Sub addConfigList(ByVal ConfigData As sMcPGGroupInfos)
        Dim sData(5) As String

        sData(0) = ConfigList.GetListItemCount + 1
        With ConfigData

            sData(1) = ConfigData.nSeedCh

            If .bEnablePG = True Then
                sData(2) = CStr(.nPGNoFrom) & " ~ " & CStr(.nPGNoTo)
            Else
                sData(2) = "Disable"
            End If
            ' "PortNo:" & .sPortName & "/" & "Baud:" & .nBaudRate

            If .bEnablePGPwr = True Then
                sData(3) = CStr(.nPGPwrNo)
            Else
                sData(3) = "Disable"
            End If

            If .bEnablePGCtrl = True Then
                sData(4) = CStr(.nPGCtrlBDNo)
            Else
                sData(4) = "Disable"
            End If

            If .bEnablePDUnit = True Then
                sData(5) = CStr(.nPDUnitNoFrom) & " ~ " & CStr(.nPDUnitNoTo)
            Else
                sData(5) = "Disable"
            End If

        End With
        ConfigList.AddRowData(sData)
    End Sub

    Private Sub UpdateConfigList()

        ConfigList.ClearAllData()

        If m_sConfigData Is Nothing = True Then
            Exit Sub
        End If

        ConfigList.ClearAllData()
        For i As Integer = 0 To m_sConfigData.Length - 1
            addConfigList(m_sConfigData(i))
        Next

    End Sub



    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click

        Dim sConfig As sMcPGGroupInfos = Nothing

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
        Dim configBuf As sMcPGGroupInfos

        If m_sConfigData Is Nothing Then Exit Sub

        configBuf = m_sConfigData(nRow)

        SetValueToUI(configBuf)
    End Sub



End Class
