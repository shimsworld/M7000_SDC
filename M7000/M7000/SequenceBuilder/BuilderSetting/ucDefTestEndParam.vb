Public Class ucDefTestEndParam

    '여기서 선택된 Test End Parameter 를 ucTestEndParam 에 표시

#Region "Define"

    Dim m_SelectedTestEndParams() As ucTestEndParam.eTestEndParam
    Dim m_cntTestEndParam As Integer = 0

#End Region

#Region "Properties"

    Public Property Settings As ucTestEndParam.eTestEndParam()
        Get
            Return m_SelectedTestEndParams
        End Get
        Set(value As ucTestEndParam.eTestEndParam())
            m_SelectedTestEndParams = value
            If m_SelectedTestEndParams Is Nothing = False Then
                m_cntTestEndParam = m_SelectedTestEndParams.Length
                UpdateList()
            End If
        End Set
    End Property

    Public Property Title As String
        Get
            Return gbMain.Text
        End Get
        Set(value As String)
            gbMain.Text = value
        End Set
    End Property

#End Region

#Region "Creator And Disposer, Init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Private Sub init()

        gbMain.Location = New System.Drawing.Point(0, 0)
        gbMain.Dock = DockStyle.Fill


        With cbSelParam
            .Items.Clear()
            For i As Integer = 0 To ucTestEndParam.sCaptions_EndParam.Length - 1
                .Items.Add(ucTestEndParam.sCaptions_EndParam(i))
            Next
            .SelectedIndex = 0
        End With

        Dim ListHeader() As String = New String() {"No.", "Param"}
        Dim ListColWidthRatio As String = "20, 80"

        ucList.ColHeader = ListHeader
        ucList.ColHeaderWidthRatio = ListColWidthRatio

        ucList.UseCheckBoxex = False

    End Sub

#End Region

#Region "Functions"

    Private Sub addList()

        If m_SelectedTestEndParams Is Nothing = False Then

            For i As Integer = 0 To m_SelectedTestEndParams.Length - 1
                If m_SelectedTestEndParams(i) = cbSelParam.SelectedIndex Then
                    MsgBox("Already registered.")
                    Exit Sub
                End If
            Next
        End If

        ReDim Preserve m_SelectedTestEndParams(m_cntTestEndParam)
        m_SelectedTestEndParams(m_cntTestEndParam) = cbSelParam.SelectedIndex
        m_cntTestEndParam += 1

        UpdateList()

    End Sub

    Private Sub ClearList()
        m_SelectedTestEndParams = Nothing
        m_cntTestEndParam = 0
        UpdateList()
    End Sub

    Private Sub DelList()
        Dim nSelRowIdx As Integer
        Dim listRetCode As ucDispListView.eUcListErrCode

        listRetCode = ucList.GetSelectedRowNumber(nSelRowIdx)

        If listRetCode <> ucDispListView.eUcListErrCode.eNoError Then MsgBox(listRetCode.ToString)

        If m_cntTestEndParam = 0 Then
            Exit Sub
        ElseIf m_cntTestEndParam = 1 Then
            ClearList()
        Else

            Dim buff(m_SelectedTestEndParams.Length - 2) As ucTestEndParam.eTestEndParam
            m_cntTestEndParam = 0
            For i As Integer = 0 To m_SelectedTestEndParams.Length - 1
                If i <> nSelRowIdx Then
                    buff(m_cntTestEndParam) = m_SelectedTestEndParams(i)
                    m_cntTestEndParam += 1
                End If
            Next

            m_SelectedTestEndParams = buff.Clone
            UpdateList()
        End If

    End Sub

    Private Sub UpdateList()
        ucList.ClearAllData()

        If m_SelectedTestEndParams Is Nothing Then Exit Sub

        Dim sListRow(1) As String
        For i As Integer = 0 To m_SelectedTestEndParams.Length - 1
            sListRow(0) = CStr(i + 1)
            sListRow(1) = ucTestEndParam.sCaptions_EndParam(m_SelectedTestEndParams(i))
            ucList.AddRowData(sListRow)
        Next
    End Sub

#End Region

#Region "Event Functions"

    Private Sub ucDefTestEndParam_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        UpdateList()
    End Sub


    Private Sub btnADD_Click(sender As System.Object, e As System.EventArgs) Handles btnADD.Click
        addList()
    End Sub

    Private Sub DelToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DelToolStripMenuItem.Click
        DelList()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        ClearList()
    End Sub

#End Region



End Class
