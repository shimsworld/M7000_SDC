Public Class ucDispSampleCommonNode


    ' Protected sequenceMgr As CSequenceManager
    Protected m_SampleInfo As String ' ucDispRcpCommon.sSampleInfos

    Protected m_nChNo As Integer
    Protected m_sCellTitle As String 'cell identification title(number or name) on the JIG
    Protected m_nCellNo As Integer
    Protected m_OutlineColor_Selected As Color    '= Color.Lime 'd
    Protected m_OutlineColor_UnSelected As Color '= Color.Black
    Protected m_bIsSelected As Boolean
    Protected m_dOutlineWidth As Double '= 3
    Protected m_CellSatus As eCellState
    Protected m_CellColor_ON As Color '= Color.White
    Protected m_CellColor_OFF As Color ' = Color.Black
    Protected m_CellColor_Meas As Color 'Indicate the measuring status whit the color and text

    Protected m_bIsLoadedSeq As Boolean
    Protected m_bIsLoadedSavePath As Boolean
    Protected m_sRcpTitle As String
    Protected m_dTemp As Double
    Protected m_bVisibleTemp As Boolean
    Protected m_sSavePath As String
    Protected m_nStatus As CScheduler.eChSchedulerSTATE
    Protected m_StatusFont As System.Drawing.Font

    Protected m_ModeTime_Current As TimeSpan
    Protected m_ModeTime_SetValue As CTime.sTimeValue

    Protected m_DispDatas() As String




    Public Event evRunExperiment(ByVal nCh As Integer)
    Public Event evStopExperiment(ByVal nCh As Integer)
    Public Event evClickLoadSequence(ByVal ch As Integer)
    Public Event evClickUnloadSeqeunce(ByVal ch As Integer)
    Public Event evClickEditSequence(ByVal ch As Integer)
    Public Event evSavePath(ByVal nCh As Integer)
    Public Event evSelected(ByVal nCh As Integer, ByVal CellNo As Integer)
    Public Event evUnSelected(ByVal nCh As Integer, ByVal CellNo As Integer)

    Public Event evClickTempIndicator(ByVal nCh As Integer)


    Public Enum eCellState
        eOFF
        eON
        eMeasuring
    End Enum

   

#Region "Properties"

    Public Overridable Property Title As String
        Get
            Return m_sCellTitle
        End Get
        Set(ByVal value As String)
            m_sCellTitle = value
        End Set
    End Property

    Public Overridable Property CellNo As Integer
        Get
            Return m_nCellNo
        End Get
        Set(value As Integer)
            m_nCellNo = value
        End Set
    End Property

    Public Overridable Property Channel As Integer
        Get
            Return m_nChNo
        End Get
        Set(ByVal value As Integer)
            m_nChNo = value
        End Set
    End Property

    Public Overridable Property OutlineWidth As Double
        Get
            Return m_dOutlineWidth
        End Get
        Set(ByVal value As Double)
            m_dOutlineWidth = value
        End Set
    End Property

    Public Overridable Property OutlineColor_Selected As Color
        Get
            Return m_OutlineColor_Selected
        End Get
        Set(ByVal value As Color)
            m_OutlineColor_UnSelected = value
        End Set
    End Property

    Public Overridable Property OutlineColor_Unselected As Color
        Get
            Return m_OutlineColor_UnSelected
        End Get
        Set(ByVal value As Color)
            m_OutlineColor_UnSelected = value
        End Set
    End Property

    Public Overridable Property IsSelected As Boolean
        Get
            Return m_bIsSelected
        End Get
        Set(ByVal value As Boolean)
            m_bIsSelected = value
        End Set
    End Property

    Public Overridable Property CellStatus As eCellState
        Get
            Return m_CellSatus
        End Get
        Set(ByVal value As eCellState)
            m_CellSatus = value
        End Set
    End Property

    Public Overridable Property CellColor_ON As Color
        Get
            Return m_CellColor_ON
        End Get
        Set(ByVal value As Color)
            m_CellColor_ON = value
        End Set
    End Property

    Public Overridable Property CellColor_OFF As Color
        Get
            Return m_CellColor_OFF
        End Get
        Set(ByVal value As Color)
            m_CellColor_OFF = value
        End Set
    End Property

    Public Overridable Property CellColor_Meas As Color
        Get
            Return m_CellColor_Meas
        End Get
        Set(ByVal value As Color)
            m_CellColor_Meas = value
        End Set
    End Property

    Public Overridable Property IsLoadedSequenceInfo As Boolean
        Get
            Return m_bIsLoadedSeq
        End Get
        Set(ByVal value As Boolean)
            m_bIsLoadedSeq = value
        End Set
    End Property

    Public Overridable Property IsLoadedSavePath As Boolean
        Get
            Return m_bIsLoadedSavePath
        End Get
        Set(ByVal value As Boolean)
            m_bIsLoadedSavePath = value
        End Set
    End Property


    Public Overridable WriteOnly Property RecipeTitle As String
        Set(ByVal value As String)
            m_sRcpTitle = value
        End Set
    End Property


    Public Overridable WriteOnly Property SavePath As String
        Set(ByVal value As String)
            m_sSavePath = value
        End Set
    End Property

    Public Overridable Property Status As CScheduler.eChSchedulerSTATE
        Get
            Return m_nStatus
        End Get
        Set(ByVal value As CScheduler.eChSchedulerSTATE)
            m_nStatus = value
        End Set
    End Property

    Public Overridable Property StatusFont As System.Drawing.Font
        Get
            Return m_StatusFont
        End Get
        Set(ByVal value As System.Drawing.Font)
            m_StatusFont = value
        End Set
    End Property

    Public Overridable WriteOnly Property ModeTime_Current As TimeSpan
        Set(ByVal value As TimeSpan)
            m_ModeTime_Current = value
        End Set
    End Property

    Public Overridable WriteOnly Property ModeTime_SetValue As CTime.sTimeValue
        Set(ByVal value As CTime.sTimeValue)
            m_ModeTime_SetValue = value
        End Set
    End Property

    Public Overridable Property Temperatuer As Double
        Get
            Return m_dTemp
        End Get
        Set(ByVal value As Double)
            m_dTemp = value
        End Set
    End Property


    Public Overridable Property VisibleTemp As Boolean
        Get
            Return m_bVisibleTemp
        End Get
        Set(ByVal value As Boolean)
            m_bVisibleTemp = value
        End Set
    End Property


    Public Overridable WriteOnly Property Infomation As String
        Set(ByVal value As String)
            m_SampleInfo = value
        End Set
    End Property

    Public Overridable WriteOnly Property Datas As String()
        Set(ByVal value As String())
            m_DispDatas = value.Clone
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
        '   sequenceMgr = New CSequenceManager

        m_OutlineColor_Selected = Color.Lime 'd
        m_OutlineColor_UnSelected = Color.Black
        m_CellColor_ON = Color.White
        m_CellColor_OFF = Color.Black
        m_dOutlineWidth = 3
    End Sub




#Region "Context Menu Event handler functions"


    Private Sub 실험시작ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 실험시작ToolStripMenuItem.Click
        RaiseEvent evRunExperiment(m_nChNo)
    End Sub

    Private Sub 실험정지ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 실험정지ToolStripMenuItem.Click
        RaiseEvent evStopExperiment(m_nChNo)
    End Sub


    Private Sub LoadSequenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadSequenceToolStripMenuItem.Click
        'If sequenceMgr.LoadTestSequence() = False Then
        '    MsgBox("Canceled")
        'Else
        '    '   dispCh(ch).RecipeTitle(sequenceMgr(ch).SequenceInfo.sSampleInfos.sTitle)
        '    'm_SampleInfo()
        'End If

        RaiseEvent evClickLoadSequence(m_nChNo)

    End Sub


    Private Sub SavePathToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePathToolStripMenuItem.Click
        RaiseEvent evSavePath(m_nChNo)
    End Sub

    Private Sub UnloadSequenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnloadSequenceToolStripMenuItem.Click
        RaiseEvent evClickUnloadSeqeunce(m_nChNo)
    End Sub

    Private Sub EditSequenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditSequenceToolStripMenuItem.Click

        Dim builder As New frmSequenceBuilder

        If builder.ShowDialog = DialogResult.OK Then

            'MyBase.sequenceMgr(ch) = builder.se
        End If
    End Sub

#End Region

    Protected Sub SetSavePath()
        RaiseEvent evSavePath(m_nChNo)
    End Sub

    Protected Sub SelectStateChange(ByVal bIsSelected As Boolean)
        If bIsSelected = True Then
            RaiseEvent evSelected(m_nChNo, m_nCellNo)
        Else
            RaiseEvent evUnSelected(m_nChNo, m_nCellNo)
        End If
    End Sub

    Protected Sub ClickTempIndicator()
        RaiseEvent evClickTempIndicator(m_nChNo)
    End Sub

End Class
