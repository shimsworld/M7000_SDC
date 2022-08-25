Imports System.Windows.Forms

Public Class ucConfigSocket


#Region "Define"


    Private Event evAddConfigList()

    Dim sConfigData() As sConfig
    Dim m_nDispMode As eDispMode = eDispMode.eVerticalArrange

    Structure sConfig
        Dim settings As CComSocket.sSockInfos
        Dim bIsOffLine As Boolean
        Dim nAllocationCh_From As Integer
        Dim nAllocationCh_To As Integer
        Dim iAllocationCh() As Integer
    End Structure

    Structure sM6000DeviceMaxRange
        Dim Volt As Double
        Dim Current As Double
    End Structure


    Public Enum eDispMode
        eHorizontalArrange
        eVerticalArrange
    End Enum

#End Region



#Region "Properties"

    Public Property Setting() As sConfig()
        Get
            Return sConfigData
        End Get
        Set(ByVal value As sConfig())
            If value Is Nothing = False Then
                sConfigData = value
                For i As Integer = 0 To value.Length - 1
                    ADDConfigList(value(i))
                Next
            End If
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

    Public Property DispMode As eDispMode
        Get
            Return m_nDispMode
        End Get
        Set(ByVal value As eDispMode)
            m_nDispMode = value
            UpdateDisp()

        End Set
    End Property

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

        txtIPBox1.Text = 192
        txtIPBox2.Text = 168
        txtIPBox3.Text = 0
        txtIPBox4.Text = 5
        txtChAlloStart.Text = 1
        txtChAlloEnd.Text = 32
        txtPort.Text = 6000
    End Sub


    Private Sub UpdateDisp()
        Select Case m_nDispMode

            Case eDispMode.eVerticalArrange
                gbConfig.Size = New System.Drawing.Size(656, 250)
                ConfigList.Location = New System.Drawing.Point(11, 127)
            Case eDispMode.eHorizontalArrange
                gbConfig.Size = New System.Drawing.Size(1193, 131)
                ConfigList.Location = New System.Drawing.Point(btnADD.Location.X + btnADD.Size.Width + 10, btnADD.Location.Y)
        End Select
    End Sub


    Private Function GetValueFormUI(ByRef ConfigData As sConfig) As Boolean

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
            With .settings
                ' .iDeviceNo = cbHWNum.SelectedIndex
                .sIPAddress = iIP(0) & "." & iIP(1) & "." & iIP(2) & "." & iIP(3)
                .nPort = CInt(txtPort.Text)
            End With
        End With

        ConfigData.bIsOffLine = chkOFFLine.Checked

        Return True
    End Function


    Private Sub SetValueToUI(ByVal nSelRow As Integer)
        Dim arrBuf As Array

        With sConfigData(nSelRow)
            arrBuf = Split(.settings.sIPAddress, ".", -1)
            txtIPBox1.Text = arrBuf(0)
            txtIPBox2.Text = arrBuf(1)
            txtIPBox3.Text = arrBuf(2)
            txtIPBox4.Text = arrBuf(3)
            txtPort.Text = .settings.nPort

            txtChAlloStart.Text = .nAllocationCh_From
            txtChAlloEnd.Text = .nAllocationCh_To
            chkOFFLine.Checked = .bIsOffLine
        End With
    End Sub




    Private Sub ADDConfigList(ByVal ConfigData As sConfig)
        Dim sData(4) As String

        sData(0) = ConfigList.GetListItemCount + 1
        With ConfigData.settings
            sData(1) = .sIPAddress & "/" & CStr(.nPort)
        End With
        sData(2) = CStr(ConfigData.nAllocationCh_From) & "~" & CStr(ConfigData.nAllocationCh_To)
        If ConfigData.bIsOffLine = True Then
            sData(3) = "OFF-LINE"
        Else
            sData(3) = "ON-LINE"
        End If
        ConfigList.AddRowData(sData)
    End Sub


    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click

        Dim Config As sConfig = Nothing

        GetValueFormUI(Config)

        UpdateInfo(Config)

        ADDConfigList(Config)


    End Sub


    Private Sub btnListDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListDel.Click
        Dim SelectedNo As Integer

        ConfigList.GetSelectedRowNumber(SelectedNo)


        Delete(SelectedNo)

        ConfigList.DelSelectedRow(SelectedNo)


    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        sConfigData = Nothing

        ConfigList.ClearAllData()

    End Sub

    Private Sub UpdateInfo(ByVal ConfigData As sConfig)

        Dim ConfigDataBuff(ConfigList.GetListItemCount) As sConfig

        If ConfigList.GetListItemCount = 0 Then
            ConfigDataBuff(0) = ConfigData
            'ReDim ConfigDataBuff(ConfigList.GetListItemCount)
            ' sConfigData(0) = ConfigData
        Else
            ReDim ConfigDataBuff(ConfigList.GetListItemCount)

            For i = 0 To sConfigData.Length - 1 '데이터 Length 에러
                If i = sConfigData.Length Then
                    ConfigDataBuff(i) = ConfigData
                Else
                    ConfigDataBuff(i) = sConfigData(i)
                End If
            Next

            ' ConfigDataBuff = sConfigData.Clone

        End If

        sConfigData = ConfigDataBuff.Clone

    End Sub

    Private Sub Delete(ByVal DeleteNo As Integer)

        If DeleteNo <> 0 Then
            Dim ConfigDataBuff(sConfigData.Length - 2) As sConfig

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
        SetValueToUI(nRow)
    End Sub

 
End Class
