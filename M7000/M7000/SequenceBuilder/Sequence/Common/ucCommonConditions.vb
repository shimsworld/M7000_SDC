Public Class ucCommonConditions

#Region "Defines & Structure"

    Dim m_CommonInfo As ucSequenceBuilder.sRcpCommon

    Dim sCaption_ACFModes() As String = New String() {"Disable(Fixed Position)", "Auto Centering", "Auto Centering And Focusing"}

#End Region

#Region "Property"


    Public Property Settings As ucSequenceBuilder.sRcpCommon
        Get
            GetValueFromUI()
            Return m_CommonInfo
        End Get
        Set(ByVal value As ucSequenceBuilder.sRcpCommon)
            m_CommonInfo = value
            SetValueToUI()
        End Set
    End Property

    Public WriteOnly Property VisibleDefTemp As Boolean
        Set(ByVal value As Boolean)
            lblDefTemp.Visible = value
            tbDefaultTemp.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleACFMode As Boolean
        Set(ByVal value As Boolean)
            lblACFMode.Visible = value
            cbSelACFMode.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleLimitSettings As Boolean
        Set(ByVal value As Boolean)
            UcLimitSetting1.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleSeqEndCondition As Boolean
        Set(ByVal value As Boolean)
            ucSeqEndParam.Visible = value
        End Set
    End Property

#End Region

#Region "Creator"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Private Sub init()


        With cbSelACFMode
            .Items.Clear()
            For idx As Integer = 0 To sCaption_ACFModes.Length - 1
                .Items.Add(sCaption_ACFModes(idx))
            Next
            .SelectedIndex = 0
        End With

    End Sub


#End Region

#Region "Functions"

    Private Sub GetValueFromUI()

        With m_CommonInfo
            .dDefaultTemp = tbDefaultTemp.Text
            .nACFMode = cbSelACFMode.SelectedIndex
            .sLimits = UcLimitSetting1.Settings
            .sSequenceEnd = ucSeqEndParam.Settings
        End With

    End Sub

    Private Sub SetValueToUI()

        With m_CommonInfo

            tbDefaultTemp.Text = .dDefaultTemp
            cbSelACFMode.SelectedIndex = .nACFMode
            UcLimitSetting1.Settings = .sLimits
            ucSeqEndParam.Settings = .sSequenceEnd

        End With

    End Sub

#End Region

End Class
