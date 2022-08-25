Public Class ucDispMultiCtrlOfListType
    Inherits ucDispMultiCtrlCommonNode


    Public Sub New(ByVal maxCh As Integer, ByVal seedIdx As Integer)
        MyBase.New()
        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        MyBase.m_nMaxCh = maxCh
        MyBase.m_nSeedIndex = seedIdx
        MyBase.init()
        initialization()
    End Sub


    Private Sub initialization()
        gridList.Location = New System.Drawing.Point(0, 0)
        gridList.Dock = DockStyle.Fill
        gridList.RowLineNum = m_nMaxCh
        gridList.ReAdjustRow()
    End Sub

    Private Sub ucDispMultiCtrlOfListType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

End Class
