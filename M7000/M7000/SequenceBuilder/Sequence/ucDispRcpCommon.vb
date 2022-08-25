Public Class ucDispRcpCommon


#Region "Defines & Structure"

    Public Event evUpdate()

#End Region

#Region "Property"

    Public Property Settings As ucSampleInfos.sSampleInfos
        Get
            Return ucDispSampleInfos.Settings
        End Get
        Set(ByVal value As ucSampleInfos.sSampleInfos)
            ucDispSampleInfos.Settings = value
        End Set
    End Property

    Public Property CommonSettings As ucSequenceBuilder.sRcpCommon
        Get

            Return ucDispCommonConditions.Settings
        End Get
        Set(ByVal value As ucSequenceBuilder.sRcpCommon)
            ucDispCommonConditions.Settings = value
        End Set
    End Property

    Public WriteOnly Property VisibleSeqTitle As Boolean
        Set(ByVal value As Boolean)
            ucDispSampleInfos.VisibleSeqTitle = value
        End Set
    End Property

    Public WriteOnly Property VisibleSampleType As Boolean
        Set(ByVal value As Boolean)
            ucDispSampleInfos.VisibleSampleType = value
        End Set
    End Property

    Public WriteOnly Property VisibleSampleColor As Boolean
        Set(ByVal value As Boolean)
            ucDispSampleInfos.VisibleSampleColor = value
        End Set
    End Property

    Public WriteOnly Property VisibleSampleSize As Boolean
        Set(ByVal value As Boolean)
            ucDispSampleInfos.VisibleSampleSize = value
        End Set
    End Property

    Public WriteOnly Property VisibleFillFactor As Boolean
        Set(ByVal value As Boolean)
            ucDispSampleInfos.VisibleFillFactor = value
        End Set
    End Property

    Public WriteOnly Property VisibleComment As Boolean
        Set(ByVal value As Boolean)
            ucDispSampleInfos.VisibleComment = value
        End Set
    End Property

    Public WriteOnly Property VisibleDefTemp As Boolean
        Set(ByVal value As Boolean)
            ucDispCommonConditions.VisibleDefTemp = value
        End Set
    End Property

    Public WriteOnly Property VisibleACFMode As Boolean
        Set(ByVal value As Boolean)
            ucDispCommonConditions.VisibleACFMode = value
        End Set
    End Property

    Public WriteOnly Property VisibleLimitSettings As Boolean
        Set(ByVal value As Boolean)
            ucDispCommonConditions.VisibleLimitSettings = value
        End Set
    End Property

    Public WriteOnly Property VisibleSeqEndCondition As Boolean
        Set(ByVal value As Boolean)
            ucDispCommonConditions.VisibleSeqEndCondition = value
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
        'tbComment.Location = New System.Drawing.Point(0, 0)
        'tbComment.Dock = DockStyle.Fill

        ' gbCommon.Visible = False

    End Sub


#End Region


#Region "Functions"



#End Region



    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        RaiseEvent evUpdate()
    End Sub

    Private Sub UcCommonConditions1_Load(sender As System.Object, e As System.EventArgs) Handles ucDispCommonConditions.Load

    End Sub
End Class
