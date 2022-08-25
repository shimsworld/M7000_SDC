Public Class ucPR705
#Region "Defines"
    Dim m_SettingInfos As CDevSpectrometerCommonNode.DeviceOption

    Public Event evConnection()
    Public Event evDisconnection()
    Public Event evSetRemoteMode()
    Public Event evSetLocalMode()
    Public Event evMeasure()
    Public Event evSetDeviceSettings(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption)

#End Region


#Region "Properties"

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


    Private Sub init()
        With cbSetAperture
            .Items.Clear()
            .Items.Add("Nothing")
        End With

        With cbSetLens
            .Items.Clear()
            .Items.Add("Nothing")
        End With

    End Sub

#End Region

#Region "Functions"


    Private Function GetValueFromUI() As Boolean
        With m_SettingInfos
            .ApertureIndex = cbSetAperture.SelectedIndex
            .LensIndex = cbSetLens.SelectedIndex
            '   .MeasSpeedIndex = cbSetMeasSpeed.SelectedIndex
        End With

        Return False
    End Function

    Private Sub SetValueToUI()
        With m_SettingInfos
            Try
                cbSetAperture.SelectedIndex = .ApertureIndex
                cbSetLens.SelectedIndex = .LensIndex
                ' cbSetMeasSpeed.SelectedIndex = .MeasSpeedIndex
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End With

    End Sub

    Public Sub ControlUIInit(ByVal sInfos As CDevSpectrometerCommonNode.DeviceOption)

        m_SettingInfos = sInfos

        With cbSetAperture
            .Items.Clear()
            For i As Integer = 0 To m_SettingInfos.ApertureList.Length - 1
                .Items.Add(m_SettingInfos.ApertureList(i).sApertureName)
            Next
            .SelectedIndex = 0
        End With

        'With cbSetMeasSpeed
        '    .Items.Clear()
        '    For i As Integer = 0 To m_SettingInfos.MeasSpeedList.Length - 1
        '        .Items.Add(m_SettingInfos.MeasSpeedList(i).sSpeedName)
        '    Next
        '    .SelectedIndex = 0
        'End With

        With cbSetLens
            .Items.Clear()
            For i As Integer = 0 To m_SettingInfos.LensList.Length - 1
                .Items.Add(m_SettingInfos.LensList(i).sLensName)
            Next
            .SelectedIndex = 0
        End With
    End Sub
#End Region



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

    Private Sub btnMeasure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeasure.Click
        RaiseEvent evMeasure()
    End Sub

    Private Sub btnSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetting.Click
        GetValueFromUI()
        RaiseEvent evSetDeviceSettings(m_SettingInfos)
    End Sub

End Class
