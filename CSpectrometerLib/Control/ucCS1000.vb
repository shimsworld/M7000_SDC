Public Class ucCS1000

#Region "Defines"
    Dim m_SettingInfos As CDevSpectrometerCommonNode.DeviceOption

    Public Event evConnection()
    Public Event evDisconnection()
    Public Event evSetRemoteMode()
    Public Event evSetLocalMode()
    Public Event evMeasure()
    Public Event evMeasureStop()
    Public Event evSetDeviceSettings(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption)
    Public Event evSetAperture(ByVal mode As CDevCS1000.eAperture)
    Public Event evSetMeasuringSpeed(ByVal mode As CDevCS1000.eMeasSpeed, ByVal value As Double)
#End Region

#Region "Property"
    Public Property Settings As CDevSpectrometerCommonNode.DeviceOption
        Get
            GetValueFromUI()
            Return m_SettingInfos
        End Get
        Set(ByVal value As CDevSpectrometerCommonNode.DeviceOption)
            m_SettingInfos = value
            SetValueToUI()
        End Set
    End Property

    Public WriteOnly Property MeasuredData As String
        Set(ByVal value As String)
            lblMeasuredDatas.Text = value
        End Set
    End Property

#End Region

#Region "Creator, Disposer And init"
    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Public Sub init()
        'With cbSetAperture
        '    .Items.Clear()
        '    .Items.Add("Nothing")
        'End With

        With cbSetMeasSpeed
            .Items.Clear()
            .Items.Add("Nothing")
        End With
    End Sub
#End Region

#Region "Functions"
    Private Function GetValueFromUI() As Boolean
        With m_SettingInfos
            '  .ApertureIndex = cbSetAperture.SelectedIndex
            .MeasSpeedIndex = cbSetMeasSpeed.SelectedIndex
            .MeasSpeedValue = txtMeasSpeed.Text
        End With

        Return False
    End Function

    Private Sub SetValueToUI()
        With m_SettingInfos
            Try
                '  cbSetAperture.SelectedIndex = .ApertureIndex
                cbSetMeasSpeed.SelectedIndex = .MeasSpeedIndex
                txtMeasSpeed.Text = .MeasSpeedValue
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End With

    End Sub

    Public Sub ControlUIInit(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption)

        m_SettingInfos = sInfos

        'With cbSetAperture
        '    .Items.Clear()
        '    For i As Integer = 0 To m_SettingInfos.ApertureList.Length - 1
        '        .Items.Add(m_SettingInfos.ApertureList(i).sApertureName)
        '    Next
        '    .SelectedIndex = 0
        'End With

        With cbSetMeasSpeed
            .Items.Clear()
            For i As Integer = 0 To m_SettingInfos.MeasSpeedList.Length - 1
                .Items.Add(m_SettingInfos.MeasSpeedList(i).sSpeedName)
            Next
            .SelectedIndex = 0
        End With

        txtMeasSpeed.Text = 0
    End Sub

    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        RaiseEvent evConnection()
    End Sub

    Private Sub btnDisConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisConnection.Click
        RaiseEvent evDisconnection()
    End Sub

    Private Sub btnRemote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemote.Click
        RaiseEvent evSetRemoteMode()
    End Sub

    Private Sub btnLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocal.Click
        RaiseEvent evSetLocalMode()
    End Sub

    Private Sub btnSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetting.Click
        GetValueFromUI()
        RaiseEvent evSetDeviceSettings(m_SettingInfos)
    End Sub

    Private Sub btnMeasure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeasure.Click
        RaiseEvent evMeasure()
    End Sub

    Private Sub btnSetApertureMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GetValueFromUI()
        RaiseEvent evSetAperture(m_SettingInfos.ApertureList(m_SettingInfos.ApertureIndex).nApertureCodeIndex)
    End Sub

    Private Sub btnSetMeasuringSpeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetMeasuringSpeed.Click
        GetValueFromUI()
        RaiseEvent evSetMeasuringSpeed(m_SettingInfos.MeasSpeedList(m_SettingInfos.MeasSpeedIndex).nMeasSpeedCodeIndex, m_SettingInfos.MeasSpeedValue)
    End Sub

#End Region

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        RaiseEvent evMeasureStop()
    End Sub
End Class
