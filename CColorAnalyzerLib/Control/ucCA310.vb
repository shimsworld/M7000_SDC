Public Class ucCA310

#Region "Defines"
    'Dim m_SettingInfos As CDevCA310.sSettings

    Public Event evConnection()
    Public Event evDisconnection()
    Public Event evUpdateState()
    Public Event evSettings()
    Public Event evZeroCal()
    Public Event evMeasure()

    Public Event evSetSyncMode(ByVal modeValue As Single)
    Public Event evSetDispMode(ByVal mode As Integer)
    Public Event evSetDispDigits(ByVal mode As Integer)
    Public Event evSetAverageMode(ByVal mode As Integer)
    Public Event evSetBrightnessUnit(ByVal mode As Integer)
    Public Event evSetCalMode(ByVal mode As Integer)


#End Region

#Region "Properties"

    'Public Property Settings As CDevCA310.sSettings
    '    Get
    '        GetValueFromUI()
    '        Return m_SettingInfos
    '    End Get
    '    Set(value As CDevCA310.sSettings)
    '        m_SettingInfos = value
    '        SetValueToUI()
    '    End Set
    'End Property

    Public WriteOnly Property MeasuredData As String
        Set(value As String)
            Label1.Text = value
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
        'With cbSelSyncMode
        '    .Items.Clear()
        '    .Items.Add(CDevCA310.eSyncMode.NTSC.ToString)
        '    .Items.Add(CDevCA310.eSyncMode.PAL.ToString)
        '    .Items.Add(CDevCA310.eSyncMode.EXT.ToString)
        '    .Items.Add(CDevCA310.eSyncMode.UNIV.ToString)
        '    .Items.Add(CDevCA310.eSyncMode.Frequency)
        'End With

        'With cbSelDisplayMode
        '    .Items.Clear()
        '    .Items.Add(CDevCA310.eDispMode.Lvxy.ToString)
        '    .Items.Add(CDevCA310.eDispMode.Tdudv.ToString)
        '    .Items.Add(CDevCA310.eDispMode.AnalyzerMode_NoAnalog.ToString)
        '    .Items.Add(CDevCA310.eDispMode.AnalyzerMode_G_Standard.ToString)
        '    .Items.Add(CDevCA310.eDispMode.AnalyzerMode_R_Standard.ToString)
        '    .Items.Add(CDevCA310.eDispMode.uDot_vDot.ToString)
        '    .Items.Add(CDevCA310.eDispMode.FlickerMode.ToString)
        '    .Items.Add(CDevCA310.eDispMode.XYZ.ToString)
        '    .Items.Add(CDevCA310.eDispMode.JEITAFlicker.ToString)
        'End With

        'With cbSelDispDigits
        '    .Items.Clear()
        '    .Items.Add(CDevCA310.eDispDigit.digit_3.ToString)
        '    .Items.Add(CDevCA310.eDispDigit.digit_4.ToString)
        'End With

        'With cbSelAveragingMode
        '    .Items.Clear()
        '    .Items.Add(CDevCA310.eAveragingMode.SLOW.ToString)
        '    .Items.Add(CDevCA310.eAveragingMode.FAST.ToString)
        '    .Items.Add(CDevCA310.eAveragingMode.AUTO.ToString)
        'End With

        'With cbSelBrightnessUnit
        '    .Items.Clear()
        '    .Items.Add(CDevCA310.eBrightnessUnit.fL.ToString)
        '    .Items.Add(CDevCA310.eBrightnessUnit.cd_m2.ToString)
        'End With

        'With cbSelDefCalMode
        '    .Items.Clear()
        '    .Items.Add(CDevCA310.eCalibrationMode.e6500K.ToString)
        '    .Items.Add(CDevCA310.eCalibrationMode.e9300K.ToString)
        'End With

    End Sub

#End Region

#Region "Functions"

    Private Function GetValueFromUI() As Boolean

        'With m_SettingInfos
        '    Try
        '        .syncMode = cbSelSyncMode.SelectedIndex
        '        If .syncMode >= CDevCA310.eSyncMode.Frequency Then
        '            .syncMode = CSng(tbSyncModeFreqValue.Text)
        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex.Message.ToString)
        '    End Try

        '    .dispMode = cbSelDisplayMode.SelectedIndex

        '    .avgMode = cbSelAveragingMode.SelectedIndex

        '    .dispDigits = cbSelDispDigits.SelectedIndex

        '    .brightnessMode = cbSelBrightnessUnit.SelectedIndex

        '    .calMode = cbSelDefCalMode.SelectedIndex
        'End With


        Return False
    End Function

    Private Sub SetValueToUI()

        'With m_SettingInfos
        '    If .syncMode >= CDevCA310.eSyncMode.Frequency Then
        '        cbSelSyncMode.SelectedIndex = CDevCA310.eSyncMode.Frequency
        '        tbSyncModeFreqValue.Text = .syncMode
        '    Else
        '        cbSelSyncMode.SelectedIndex = CInt(.syncMode)
        '    End If

        '    cbSelDisplayMode.SelectedIndex = .dispMode
        '    cbSelDispDigits.SelectedIndex = .dispDigits
        '    cbSelAveragingMode.SelectedIndex = .avgMode
        '    cbSelBrightnessUnit.SelectedIndex = .brightnessMode

        '    lblDeviceInfo.Text = "Model = " & .devInfo.sModel & vbCrLf
        '    lblDeviceInfo.Text = lblDeviceInfo.Text & "FW Version = " & .devInfo.sFirmwareVersion & vbCrLf
        '    lblDeviceInfo.Text = lblDeviceInfo.Text & "ID Number = " & CStr(.devInfo.nIDNumber) & vbCrLf
        '    lblDeviceInfo.Text = lblDeviceInfo.Text & "Comm. Port = " & .devInfo.sCommPort & vbCrLf

        '    cbSelDefCalMode.SelectedIndex = .calMode - 1
        'End With
    End Sub

#End Region


#Region "Event Functions"


    Private Sub btnConnection_Click(sender As System.Object, e As System.EventArgs) Handles btnConnection.Click
        RaiseEvent evConnection()
    End Sub

    Private Sub btnDisConnection_Click(sender As System.Object, e As System.EventArgs) Handles btnDisConnection.Click
        RaiseEvent evDisconnection()
    End Sub

    Private Sub btnUpdateState_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdateState.Click
        RaiseEvent evUpdateState()
    End Sub

    Private Sub btnSetting_Click(sender As System.Object, e As System.EventArgs) Handles btnSetting.Click
        RaiseEvent evSettings()
    End Sub

    Private Sub btnZeroCal_Click(sender As System.Object, e As System.EventArgs) Handles btnZeroCal.Click
        RaiseEvent evZeroCal()
    End Sub

    Private Sub btnMeasure_Click(sender As System.Object, e As System.EventArgs) Handles btnMeasure.Click
        RaiseEvent evMeasure()
    End Sub

#End Region




    Private Sub btnSetSyncMode_Click(sender As System.Object, e As System.EventArgs) Handles btnSetSyncMode.Click
        GetValueFromUI()
        'RaiseEvent evSetSyncMode(m_SettingInfos.syncMode)
    End Sub

    Private Sub btnSetDispMode_Click(sender As System.Object, e As System.EventArgs) Handles btnSetDispMode.Click
        GetValueFromUI()
        'RaiseEvent evSetDispMode(m_SettingInfos.dispMode)
    End Sub

    Private Sub btnSetDispDigits_Click(sender As System.Object, e As System.EventArgs) Handles btnSetDispDigits.Click
        GetValueFromUI()
        'RaiseEvent evSetDispDigits(m_SettingInfos.dispDigits)
    End Sub

    Private Sub btnSetAverageMode_Click(sender As System.Object, e As System.EventArgs) Handles btnSetAverageMode.Click
        GetValueFromUI()
        'RaiseEvent evSetAverageMode(m_SettingInfos.avgMode)
    End Sub

    Private Sub btnSetBrightnessUnit_Click(sender As System.Object, e As System.EventArgs) Handles btnSetBrightnessUnit.Click
        GetValueFromUI()
        'RaiseEvent evSetBrightnessUnit(m_SettingInfos.brightnessMode)
    End Sub

    Private Sub btnSetCalMode_Click(sender As System.Object, e As System.EventArgs) Handles btnSetCalMode.Click
        GetValueFromUI()
        'RaiseEvent evSetCalMode(m_SettingInfos.calMode)
    End Sub


End Class
