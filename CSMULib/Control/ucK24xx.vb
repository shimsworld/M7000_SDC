Public Class ucK24xx


#Region "Defines"
    Dim m_SettingInfos As ucKeithleySMUSettings.sKeithley
    Dim ucCtrlKeithley As ucKeithleySMUSettings

    Public Event evConnection()
    Public Event evDisconnection()
    Public Event evMeasure()
    Public Event evBiasOn(ByVal dBias As Double)
    Public Event evBiasOn2(ByVal dBias As Double, ByVal dAmplitude As Double, ByVal dFrequency As Double, ByVal dduty As Double)
    Public Event evBiasOff()
    Public Event evSetDeviceSettings(ByVal sInfos As ucKeithleySMUSettings.sKeithley)

#End Region

#Region "Property"
    Public WriteOnly Property ControlUI As CDevSMUCommonNode.sRangeAndIntegTime
        Set(ByVal value As CDevSMUCommonNode.sRangeAndIntegTime)
            ucCtrlKeithley.ControlUI = value
        End Set
    End Property

    Public Property Settings As ucKeithleySMUSettings.sKeithley
        Get
            m_SettingInfos = ucCtrlKeithley.Settings
            Return m_SettingInfos
        End Get
        Set(ByVal value As ucKeithleySMUSettings.sKeithley)
            ucCtrlKeithley.Settings = value
            m_SettingInfos = value
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
        ucCtrlKeithley = New ucKeithleySMUSettings
        Me.Controls.Add(Me.ucCtrlKeithley)
        ucCtrlKeithley.Location = New System.Drawing.Point(15, 76)
        ucCtrlKeithley.Size = New System.Drawing.Size(540, 350)
        ucCtrlKeithley.DisplayMode = CDevSMUCommonNode.eModel.KEITHLEY_K2400
    End Sub
#End Region


    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        RaiseEvent evConnection()
    End Sub

    Private Sub btnDisConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisConnection.Click
        RaiseEvent evDisconnection()
    End Sub

    Private Sub btnSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetting.Click
        m_SettingInfos = ucCtrlKeithley.Settings
        RaiseEvent evSetDeviceSettings(m_SettingInfos)
    End Sub

    Private Sub btnMeasure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeasure.Click
        RaiseEvent evMeasure()
    End Sub

   

    Private Sub btnBiasOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBiasOff.Click
        RaiseEvent evBiasOff()
    End Sub

    Private Sub btnBiasOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBiasOn.Click
        RaiseEvent evBiasOn(CDbl(tbBias.Text))
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        RaiseEvent evBiasOn(CDbl(tbBias.Text))
    End Sub
End Class
