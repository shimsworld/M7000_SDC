Public Class ucM6100



#Region "Defines"
    Dim m_SettingInfos As CDevM6100.sM6100Setting
    Dim ucCtrlM6100 As ucM6100Settings

    Public Event evConnection()
    Public Event evDisconnection()
    Public Event evMeasure()
    Public Event evBiasOn(ByVal dBias As Double)
    Public Event evBiasOn2(ByVal dBias As Double, ByVal dAmplitude As Double, ByVal dFrequency As Double, ByVal dduty As Double)
    Public Event evBiasOff()
    Public Event evSetDeviceSettings(ByVal sInfos As CDevM6100.sM6100Setting, ByVal ch As Integer)

#End Region


#Region "Property"

    Public WriteOnly Property ControlUI As CDevSMUCommonNode.sRangeAndIntegTime
        Set(ByVal value As CDevSMUCommonNode.sRangeAndIntegTime)
            ucCtrlM6100.ControlUI = value
        End Set
    End Property

    Public Property Settings As CDevM6100.sM6100Setting
        Get
            m_SettingInfos = ucCtrlM6100.Settings
            Return m_SettingInfos
        End Get
        Set(ByVal value As CDevM6100.sM6100Setting)
            ucCtrlM6100.Settings = value
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
        ucCtrlM6100 = New ucM6100Settings
        Me.Controls.Add(Me.ucCtrlM6100)
        ucCtrlM6100.Location = New System.Drawing.Point(15, 76)
        ucCtrlM6100.Size = New System.Drawing.Size(526, 277)
    End Sub
#End Region


    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        RaiseEvent evConnection()
    End Sub

    Private Sub btnDisConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisConnection.Click
        RaiseEvent evDisconnection()
    End Sub

    Private Sub btnSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetting.Click
        m_SettingInfos = ucCtrlM6100.Settings

        RaiseEvent evSetDeviceSettings(m_SettingInfos, 1)
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

End Class
