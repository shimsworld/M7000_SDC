Public Class ucLabsphere

#Region "Defines"
    Dim m_SettingInfos As CDevSpectrometerCommonNode.DeviceOption

    Public Event evConnection()
    Public Event evDisconnection()
    Public Event evSetIntegtimeAverage(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption)
    Public Event evMeasure()
    Public Event evAutoExpose()
    Public Event evDarkMeasure()
    Public Event evSetDeviceSettings(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption)

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
        txtIntegrationTime.Text = 8
        txtAveragecount.Text = 10
    End Sub
#End Region

#Region "Functions"
    Private Function GetValueFromUI() As Boolean
        With m_SettingInfos
            .MeasSpeedValue = txtIntegrationTime.Text
            .NumOfAverage = txtAveragecount.Text
        End With

        Return False
    End Function

    Private Sub SetValueToUI()
        With m_SettingInfos
            Try
                txtIntegrationTime.Text = .MeasSpeedValue
                txtAveragecount.Text = .NumOfAverage
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

        'With cbSetMeasSpeed
        '    .Items.Clear()
        '    For i As Integer = 0 To m_SettingInfos.MeasSpeedList.Length - 1
        '        .Items.Add(m_SettingInfos.MeasSpeedList(i).sSpeedName)
        '    Next
        '    .SelectedIndex = 0
        'End With

        'txtMeasSpeed.Text = 0

        txtIntegrationTime.Text = sInfos.MeasSpeedValue
        txtAveragecount.Text = sInfos.NumOfAverage

    End Sub

    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        RaiseEvent evConnection()
    End Sub

    Private Sub btnDisConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisConnection.Click
        RaiseEvent evDisconnection()
    End Sub

    Private Sub btnSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetting.Click
        GetValueFromUI()
        RaiseEvent evSetDeviceSettings(m_SettingInfos)
    End Sub

    Private Sub btnMeasure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeasure.Click
        RaiseEvent evMeasure()
    End Sub

    Private Sub btnSetIntegAverage_Click(sender As System.Object, e As System.EventArgs) Handles btnSetIntegAverage.Click
        GetValueFromUI()
        RaiseEvent evSetIntegtimeAverage(m_SettingInfos)
    End Sub

    Private Sub btnSetAutoExpose_Click(sender As System.Object, e As System.EventArgs) Handles btnSetAutoExpose.Click
        RaiseEvent evAutoExpose()
    End Sub

    Private Sub btnDarkMeasure_Click(sender As System.Object, e As System.EventArgs) Handles btnDarkMeasure.Click
        RaiseEvent evDarkMeasure()
    End Sub
#End Region




End Class
