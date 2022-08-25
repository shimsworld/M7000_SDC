Public Class ucBM7A


    Dim m_SettingInfos As CDevBM_7A.sSettings

    Public Event evConnection()
    Public Event evDisconnection()
    Public Event evMeasure()

    Public Event evSetRangeMode(ByVal mode As CDevBM_7A.eMeasRange, ByVal X As Double, ByVal Y As Double, ByVal Z As Double)
    Public Event evSetSpeedMode(ByVal mode As CDevBM_7A.eMeasSpeed)
    Public Event evSetAverageMode(ByVal mode As CDevBM_7A.eAverage)
    Public Event evSetFactorNumber(ByVal mode As Integer)




#Region "Properties"

    Public Property Settings As CDevBM_7A.sSettings
        Get
            GetValueFromUI()
            Return m_SettingInfos
        End Get
        Set(value As CDevBM_7A.sSettings)
            m_SettingInfos = value
            SetValueToUI()
        End Set
    End Property

    Public WriteOnly Property MeasuredData As String
        Set(value As String)
            Label1.Text = value
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
        With cbSelRangeMode
            .Items.Clear()
            .Items.Add(CDevBM_7A.eMeasRange._AUTO.ToString)
            .Items.Add(CDevBM_7A.eMeasRange._MANUAL.ToString)
            .SelectedIndex = 0
        End With
        txtXRange.Text = 3
        txtYRange.Text = 3
        txtZRange.Text = 3

        With cbSelSpeedMode
            .Items.Clear()
            .Items.Add(CDevBM_7A.eMeasSpeed._SLOW.ToString)
            .Items.Add(CDevBM_7A.eMeasSpeed._FAST.ToString)
            .SelectedIndex = 0
        End With

        With cbSelAverageMode
            .Items.Clear()
            .Items.Add(CDevBM_7A.eAverage._SINGLE.ToString)
            .Items.Add(CDevBM_7A.eAverage._AVERAGE.ToString)
            .SelectedIndex = 0
        End With

        txtFactornumber.Text = 0
    End Sub

    Private Function GetValueFromUI() As Boolean

        With m_SettingInfos

            .RangeMode = cbSelRangeMode.SelectedIndex
            .RangeXFactor = txtXRange.Text
            .RangeYFactor = txtYRange.Text
            .RangeZFactor = txtZRange.Text
            .nFactorNumber = txtFactornumber.Text
            .speedMode = cbSelSpeedMode.SelectedIndex
            .AverageMode = cbSelAverageMode.SelectedIndex

        End With


        Return False
    End Function

    Private Sub SetValueToUI()

        With m_SettingInfos
            cbSelRangeMode.SelectedIndex = .RangeMode
            txtXRange.Text = .RangeXFactor
            txtYRange.Text = .RangeYFactor
            txtZRange.Text = .RangeZFactor
            txtFactornumber.Text = .nFactorNumber
            cbSelSpeedMode.SelectedIndex = .speedMode
            cbSelAverageMode.SelectedIndex = .AverageMode
        End With

    End Sub
    Private Sub btnConnection_Click(sender As System.Object, e As System.EventArgs) Handles btnConnection.Click
        RaiseEvent evConnection()
    End Sub

    Private Sub btnDisConnection_Click(sender As System.Object, e As System.EventArgs) Handles btnDisConnection.Click
        RaiseEvent evDisconnection()
    End Sub

    Private Sub btnMeasure_Click(sender As System.Object, e As System.EventArgs) Handles btnMeasure.Click
        RaiseEvent evMeasure()
    End Sub

    Private Sub btnSetRangeMode_Click(sender As System.Object, e As System.EventArgs) Handles btnSetRangeMode.Click
        GetValueFromUI()
        RaiseEvent evSetRangeMode(m_SettingInfos.RangeMode, m_SettingInfos.RangeXFactor, m_SettingInfos.RangeYFactor, m_SettingInfos.RangeZFactor)
    End Sub

    Private Sub btnSetSpeedMode_Click(sender As System.Object, e As System.EventArgs) Handles btnSetSpeedMode.Click
        GetValueFromUI()
        RaiseEvent evSetSpeedMode(m_SettingInfos.speedMode)
    End Sub

    Private Sub btnSetAverageMode_Click(sender As System.Object, e As System.EventArgs) Handles btnSetAverageMode.Click
        GetValueFromUI()
        RaiseEvent evSetAverageMode(m_SettingInfos.AverageMode)
    End Sub

    Private Sub cbSelRangeMode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbSelRangeMode.SelectedIndexChanged
        If cbSelRangeMode.SelectedIndex = CDevBM_7A.eMeasRange._AUTO Then
            txtXRange.Enabled = False
            txtYRange.Enabled = False
            txtZRange.Enabled = False
        Else
            txtXRange.Enabled = True
            txtYRange.Enabled = True
            txtZRange.Enabled = True
        End If
    End Sub

    Private Sub btnSetFactornumber_Click(sender As System.Object, e As System.EventArgs) Handles btnSetFactornumber.Click
        GetValueFromUI()
        RaiseEvent evSetFactorNumber(m_SettingInfos.nFactorNumber)
    End Sub
End Class
