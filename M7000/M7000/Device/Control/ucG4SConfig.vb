Public Class ucG4SConfig

#Region "Defines"

    Dim m_sConfigData As CDevG4S.sInitParam



#End Region


    Public Property Setting() As CDevG4S.sInitParam
        Get
            GetValueFormUI(m_sConfigData)
            Return m_sConfigData
        End Get
        Set(ByVal value As CDevG4S.sInitParam)
            m_sConfigData = value
            SetValueToUI()
        End Set
    End Property

    Public Property Title As String
        Get
            Return gbConfig.Text
        End Get
        Set(ByVal value As String)
            gbConfig.Text = value
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

    End Sub



    Private Function GetValueFormUI(ByRef ConfigData As CDevG4S.sInitParam) As Boolean

        Dim iIP(3) As Integer
        Dim nCh As Integer

        Try
            ConfigData.nAllocationCh_From = CInt(txtChAlloStart.Text)
            ConfigData.nAllocationCh_To = CInt(txtChAlloEnd.Text)

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try

        nCh = CInt(txtChAlloEnd.Text) - CInt(txtChAlloStart.Text)
        ReDim ConfigData.iAllocationCh(nCh)
        For i = 0 To nCh
            ConfigData.iAllocationCh(i) = CInt(txtChAlloStart.Text) + i
        Next

        iIP(0) = CInt(txtIPBox1.Text)
        iIP(1) = CInt(txtIPBox2.Text)
        iIP(2) = CInt(txtIPBox3.Text)
        iIP(3) = CInt(txtIPBox4.Text)

        With ConfigData
            ' .iDeviceNo = cbHWNum.SelectedIndex
            .sServerIP = iIP(0) & "." & iIP(1) & "." & iIP(2) & "." & iIP(3)
            .nServerPort = CInt(txtPort.Text)
        End With

        iIP(0) = CInt(tbSeedIP01.Text)
        iIP(1) = CInt(tbSeedIP02.Text)
        iIP(2) = CInt(tbSeedIP03.Text)
        iIP(3) = CInt(tbSeedIP04.Text)

        ConfigData.sSeedIP = iIP(0) & "." & iIP(1) & "." & iIP(2) & "." & iIP(3)

        ConfigData.nNumberOfDev = CInt(tbNumOfDev.Text)
        ConfigData.nServerOpenTime_sec = CInt(tbServerOpenTime.Text)

        ConfigData.bIsOffLine = chkOFFLine.Checked

        Return True
    End Function


    Private Sub SetValueToUI()
        Dim arrBuf As Array

        With m_sConfigData
            arrBuf = Split(.sServerIP, ".", -1)
            txtIPBox1.Text = arrBuf(0)
            txtIPBox2.Text = arrBuf(1)
            txtIPBox3.Text = arrBuf(2)
            txtIPBox4.Text = arrBuf(3)
            txtPort.Text = .nServerPort

            arrBuf = Split(.sSeedIP, ".", -1)
            tbSeedIP01.Text = arrBuf(0)
            tbSeedIP02.Text = arrBuf(1)
            tbSeedIP03.Text = arrBuf(2)
            tbSeedIP04.Text = arrBuf(3)

            tbNumOfDev.Text = .nNumberOfDev
            tbServerOpenTime.Text = CStr(.nServerOpenTime_sec)

            txtChAlloStart.Text = .nAllocationCh_From
            txtChAlloEnd.Text = .nAllocationCh_To
            chkOFFLine.Checked = .bIsOffLine
        End With
    End Sub



End Class
