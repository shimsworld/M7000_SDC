Public Class ucDispSampleUI


    Public WithEvents sample As ucDispSampleCommonNode
    Public myType As ucSampleInfos.eSampleType '= ucDispRcpCommon.eSampleType.eCell

    Public Event evRunExperiment(ByVal nCh As Integer)
    Public Event evStopExperiment(ByVal nCh As Integer)
    Public Event evClickLoadSequence(ByVal ch As Integer)
    Public Event evClickUnloadSeqeunce(ByVal ch As Integer)
    Public Event evClickEditSequence()
    Public Event evSavePath(ByVal ch As Integer)
    'Public Event evSelectStateChange(ByVal ch As Integer, ByVal bIsSelected As Boolean)
    Public Event evSelected(ByVal ch As Integer, ByVal CellNo As Integer)   'ch : channel number in total channel, cellNo : Cell No in JIG
    Public Event evUnSelected(ByVal ch As Integer, ByVal CellNo As Integer)





#Region "Property"

    Public Property Channel As Integer
        Get
            Return sample.Channel
        End Get
        Set(ByVal value As Integer)
            sample.Channel = value
        End Set
    End Property


    Public Property IsSelected As Integer
        Get
            Return sample.IsSelected
        End Get
        Set(ByVal value As Integer)
            sample.IsSelected = value
        End Set
    End Property


    Public Property CellStatus As ucDispSampleCommonNode.eCellState
        Get
            Return sample.CellStatus
        End Get
        Set(ByVal value As ucDispSampleCommonNode.eCellState)
            sample.CellStatus = value
        End Set
    End Property

    Public Property StatusFont As System.Drawing.Font
        Get
            Return sample.StatusFont
        End Get
        Set(ByVal value As System.Drawing.Font)
            sample.StatusFont = value
        End Set
    End Property


    Public WriteOnly Property ModeTime_Current As TimeSpan
        Set(ByVal value As TimeSpan)
            sample.ModeTime_Current = value
        End Set
    End Property

    Public WriteOnly Property ModeTime_SetValue As CTime.sTimeValue
        Set(ByVal value As CTime.sTimeValue)
            sample.ModeTime_SetValue = value
        End Set
    End Property

    Public Property CellColor_ON As Color
        Get
            Return sample.CellColor_ON
        End Get
        Set(ByVal value As Color)
            sample.CellColor_ON = value
        End Set
    End Property

    Public Property CellColor_OFF As Color
        Get
            Return sample.CellColor_OFF
        End Get
        Set(ByVal value As Color)
            sample.CellColor_OFF = value
        End Set
    End Property

    Public Property CellColor_Meas As Color
        Get
            Return sample.CellColor_Meas
        End Get
        Set(ByVal value As Color)
            sample.CellColor_Meas = value
        End Set
    End Property


    Public WriteOnly Property Information As String
        Set(ByVal value As String)
            sample.Infomation = value
        End Set
    End Property



#End Region



#Region "Create, Dispose, Init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Public Sub New(ByVal type As ucSampleInfos.eSampleType, ByVal seqMgr As CSequenceManager)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        myType = type
        init(seqMgr)
    End Sub

    Private Sub init()

        Select Case myType

            Case ucSampleInfos.eSampleType.eCell
                sample = New ucDispSampleUnitCell
                sample.VisibleTemp = False
            Case ucSampleInfos.eSampleType.ePanel
                sample = New ucDispSamplePanelModule
            Case ucSampleInfos.eSampleType.eModule
                sample = New ucDispSamplePanelModule
                sample.VisibleTemp = False
            Case Else
                MsgBox("Error")
        End Select

        Control_init()
    End Sub


    Private Sub init(ByVal seqMgr As CSequenceManager)

        Select Case myType

            Case ucSampleInfos.eSampleType.eCell
                sample = New ucDispSampleUnitCell(seqMgr)
                sample.VisibleTemp = False
            Case ucSampleInfos.eSampleType.ePanel
                sample = New ucDispSamplePanelModule(seqMgr)
            Case ucSampleInfos.eSampleType.eModule
                sample = New ucDispSamplePanelModule(seqMgr)
                sample.VisibleTemp = False
            Case Else
                MsgBox("Error")
        End Select

        Control_init()
    End Sub


    Private Sub Control_init()
        Me.Controls.Add(sample)
        sample.Location = New System.Drawing.Point(0, 0)
        sample.Dock = DockStyle.Fill
    End Sub


#End Region

    Private Sub sample_evClickEditSequence(ByVal ch As Integer) Handles sample.evClickEditSequence
        RaiseEvent evClickEditSequence()
    End Sub

    Private Sub sample_evClickLoadSequence(ByVal ch As Integer) Handles sample.evClickLoadSequence
        RaiseEvent evClickLoadSequence(ch)
    End Sub

    Private Sub sample_evClickUnloadSeqeunce(ByVal ch As Integer) Handles sample.evClickUnloadSeqeunce
        RaiseEvent evClickUnloadSeqeunce(ch)
    End Sub

    Private Sub sample_evRunExperiment(ByVal nCh As Integer) Handles sample.evRunExperiment
        RaiseEvent evRunExperiment(nCh)
    End Sub

    Private Sub sample_evSavePath(ByVal nCh As Integer) Handles sample.evSavePath
        RaiseEvent evSavePath(nCh)
    End Sub

    Private Sub sample_evSelected(ByVal nCh As Integer, ByVal CellNo As Integer) Handles sample.evSelected
        RaiseEvent evSelected(nCh, CellNo)
    End Sub

    Private Sub sample_evUnSelected(ByVal nCh As Integer, ByVal CellNo As Integer) Handles sample.evUnSelected
        RaiseEvent evUnSelected(nCh, CellNo)
    End Sub

    Private Sub sample_evStopExperiment(ByVal nCh As Integer) Handles sample.evStopExperiment
        RaiseEvent evStopExperiment(nCh)
    End Sub


End Class
