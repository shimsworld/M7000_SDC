Public Class ucDispCtrlUICommonNode


    '    Protected WithEvents sequenceMgr As CSequenceManager
    Protected m_nChannel As Integer
    Protected m_nType As eType






    Public Enum eType
        JIGLayout
        CustomTypeForQC
    End Enum


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub

    Private Sub init()
        '  sequenceMgr = New CSequenceManager

    End Sub


#Region "Properties"


    Public Overridable Property Channel As Integer
        Get
            Return m_nChannel
        End Get
        Set(ByVal value As Integer)
            m_nChannel = value
        End Set
    End Property

    Public Overridable ReadOnly Property Type As eType
        Get
            Return m_nType
        End Get
    End Property

#End Region



#Region "Context Menu Items Event Functions"

    Private Sub TestRunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestRunToolStripMenuItem.Click

    End Sub

    Private Sub TestStopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestStopToolStripMenuItem.Click

    End Sub

    Private Sub LoadSequenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadSequenceToolStripMenuItem.Click

    End Sub

    Private Sub SaveSequenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveSequenceToolStripMenuItem.Click

    End Sub

    Private Sub SequenceBuilderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SequenceBuilderToolStripMenuItem.Click

    End Sub

#End Region




End Class
