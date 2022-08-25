Public Class ucSGOutputDefine


#Region "Define"

    Dim m_SGOutputInfo As sSGOutputInfo

    Dim m_sCaptionPGSignals() As String = New String() {"MainPower1", "MainPower2",
                                                                                  "SubPower1", "SubPower2", "SubPower3", "SubPower4", "SubPower5", "SubPower6", "SubPower7", "SubPower8", "SubPower9", "SubPower10", "SubPower11", "SubPower12",
                                                                                  "Signal1", "Signal2", "Signal3", "Signal4", "Signal5", "Signal6", "Signal7", "Signal8", "Signal9", "Signal10", "Signal11", "Signal12",
                                                                                  "Signal13", "Signal14", "Signal15", "Signal16", "Signal17", "Signal18", "Signal19", "Signal20", "Signal21", "Signal22", "Signal23", "Signal24", "Signal25", "Signal26"}

    Public Structure sSGOutputInfo
        Dim sMainPowerOfCh() As sSGChInfo
        Dim strSignalName() As String
        Dim sCtrlUISignalSettings As sCtrlUIDispInfo
    End Structure

    Public Structure sSGChInfo
        Dim nMainPower1 As Integer
        Dim nMainPower2 As Integer
    End Structure

    Public Structure sCtrlUIDispInfo
        Dim nRedSignal As ucDispSignalGenerator.ePGSignal
        Dim nGreenSignal As ucDispSignalGenerator.ePGSignal
        Dim nBlueSignal As ucDispSignalGenerator.ePGSignal
    End Structure

#End Region


#Region "Creator and Init"


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()

        cbSelMainPower1.Items.Clear()
        cbSelMainPower2.Items.Clear()
        For i As Integer = 0 To 15
            cbSelMainPower1.Items.Add(Format(i, "00"))
            cbSelMainPower2.Items.Add(Format(i, "00"))
        Next

        cbSelSGOuputLine.Items.Clear()
        For i As Integer = 0 To m_sCaptionPGSignals.Length - 1
            cbSelSGOuputLine.Items.Add(m_sCaptionPGSignals(i))
        Next


        cbSelMajorCtrlSignal_Red.Items.Clear()
        cbSelMajorCtrlSignal_Green.Items.Clear()
        cbSelMajorCtrlSignal_Blue.Items.Clear()
        For i As Integer = 0 To m_sCaptionPGSignals.Length - 1
            cbSelMajorCtrlSignal_Red.Items.Add(m_sCaptionPGSignals(i))
            cbSelMajorCtrlSignal_Green.Items.Add(m_sCaptionPGSignals(i))
            cbSelMajorCtrlSignal_Blue.Items.Add(m_sCaptionPGSignals(i))
        Next

        ListMainPower.UseCheckBoxex = False
        ListOutputName.UseCheckBoxex = False

    End Sub

#End Region

#Region "Property"


    Public Property Setting As sSGOutputInfo
        Get
            If GetValueFromUI() = False Then
                MsgBox("설정 값을 확인하여 주십시오.")
            End If
            Return m_SGOutputInfo
        End Get
        Set(ByVal value As sSGOutputInfo)
            m_SGOutputInfo = value
            SetValueToUI()
        End Set
    End Property
#End Region



#Region "Functions"

    Private Function GetValueFromUI() As Boolean

        Dim nCntOutputAssign As Integer = ListMainPower.GetListItemCount
        Dim sRowData() As String = Nothing

        ReDim m_SGOutputInfo.sMainPowerOfCh(nCntOutputAssign - 1)
        For i As Integer = 0 To nCntOutputAssign - 1
            If ListMainPower.GetRowData(i, sRowData) = ucDispListView.eUcListErrCode.eNoError Then
                m_SGOutputInfo.sMainPowerOfCh(i).nMainPower1 = sRowData(0)
                m_SGOutputInfo.sMainPowerOfCh(i).nMainPower2 = sRowData(1)
            Else
                Return False
            End If
        Next

        Dim nCntOutputLine As Integer = ListOutputName.GetListItemCount

        ReDim m_SGOutputInfo.strSignalName(nCntOutputLine - 1)
        For i As Integer = 0 To nCntOutputLine - 1
            If ListOutputName.GetRowData(i, sRowData) = ucDispListView.eUcListErrCode.eNoError Then
                m_SGOutputInfo.strSignalName(i) = sRowData(1)
            Else
                Return False
            End If
        Next

        m_SGOutputInfo.sCtrlUISignalSettings.nRedSignal = cbSelMajorCtrlSignal_Red.SelectedIndex
        m_SGOutputInfo.sCtrlUISignalSettings.nGreenSignal = cbSelMajorCtrlSignal_Green.SelectedIndex
        m_SGOutputInfo.sCtrlUISignalSettings.nBlueSignal = cbSelMajorCtrlSignal_Blue.SelectedIndex

        Return True
    End Function

    Private Sub SetValueToUI()
        ListMainPower.ClearAllData()
        ListOutputName.ClearAllData()

        Dim strBuf(1) As String

        If m_SGOutputInfo.sMainPowerOfCh Is Nothing = False Then
            For i As Integer = 0 To m_SGOutputInfo.sMainPowerOfCh.Length - 1
                strBuf(0) = CStr(m_SGOutputInfo.sMainPowerOfCh(i).nMainPower1)
                strBuf(1) = CStr(m_SGOutputInfo.sMainPowerOfCh(i).nMainPower2)
                ListMainPower.AddRowData(strBuf)
            Next
        End If

        If m_SGOutputInfo.strSignalName Is Nothing = False Then
            For i As Integer = 0 To m_SGOutputInfo.strSignalName.Length - 1
                strBuf(0) = m_sCaptionPGSignals(i)
                strBuf(1) = m_SGOutputInfo.strSignalName(i)
                ListOutputName.AddRowData(strBuf)
            Next
        End If

        If m_SGOutputInfo.sCtrlUISignalSettings.nRedSignal <= -1 Then
            cbSelMajorCtrlSignal_Red.Text = "Undefined"
        End If
        If m_SGOutputInfo.sCtrlUISignalSettings.nGreenSignal <= -1 Then
            cbSelMajorCtrlSignal_Green.Text = "Undefined"
        End If
        If m_SGOutputInfo.sCtrlUISignalSettings.nBlueSignal <= -1 Then
            cbSelMajorCtrlSignal_Blue.Text = "Undefined"
        End If

        cbSelMajorCtrlSignal_Red.SelectedIndex = m_SGOutputInfo.sCtrlUISignalSettings.nRedSignal
        cbSelMajorCtrlSignal_Green.SelectedIndex = m_SGOutputInfo.sCtrlUISignalSettings.nGreenSignal
        cbSelMajorCtrlSignal_Blue.SelectedIndex = m_SGOutputInfo.sCtrlUISignalSettings.nBlueSignal

    End Sub

#End Region

  
   

#Region "Output Assignment"

 


    Private Sub btnAddOutputAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddOutputAssign.Click
        Dim sInfo(1) As String
        sInfo(0) = CStr(cbSelMainPower1.SelectedIndex)
        sInfo(1) = CStr(cbSelMainPower2.SelectedIndex)
        ListMainPower.AddRowData(sInfo)
    End Sub

    Private Sub btnDelOutputAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelOutputAssign.Click
        Dim nSelRow As Integer

        If ListMainPower.GetSelectedRowNumber(nSelRow) <> ucDispListView.eUcListErrCode.eNoError Then Exit Sub

        ListMainPower.DelSelectedRow(nSelRow)

    End Sub

    Private Sub btnClearOutputAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearOutputAssign.Click
        ListMainPower.ClearAllData()
    End Sub

#End Region


#Region "Output Name"


    Private Sub btnAddOutputName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddOutputName.Click
        Dim sInfo(1) As String
        sInfo(0) = m_sCaptionPGSignals(cbSelSGOuputLine.SelectedIndex)
        sInfo(1) = tbOutputLineName.Text

        ListOutputName.AddRowData(sInfo)
    End Sub

    Private Sub btnDelOutputName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelOutputName.Click
        Dim nSelRow As Integer

        If ListOutputName.GetSelectedRowNumber(nSelRow) <> ucDispListView.eUcListErrCode.eNoError Then Exit Sub

        ListOutputName.DelSelectedRow(nSelRow)
    End Sub

    Private Sub btnClearOutputName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearOutputName.Click
        ListOutputName.ClearAllData()
    End Sub

#End Region

  

  
End Class
