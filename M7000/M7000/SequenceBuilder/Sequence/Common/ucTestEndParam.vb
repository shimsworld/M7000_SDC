Public Class ucTestEndParam

#Region "Define"

    Public Event evTestEndParameChange(ByVal TestEndPara As eTestEndParam)
    Public Event evTestEndValuechange(ByVal TestEndValue As Double)

    Public Shared sCaptions_EndParam() As String = New String() {"Time(hrs)", "Loop count", "Volt(V)", "Curr(mA)", "PD Curr(uA)", "Lumi(%)", "Lumi_D(%)"}
    Dim m_TestEndpara() As sTestEndParam
    Dim m_UsedTestEndParam() As eTestEndParam


    'Public Event AddTestEndpara(ByVal Settings As ucControlPannel.sTestEndParam)

    Enum eTestEndParam
        eTime = 0
        eLoopCount
        eVolt
        eCurr
        ePDCurr
        eLumi
        eLumi_Delta
        eHightVolt
        eHighCurrent
    End Enum


#Region "Structure"

    Public Structure sTestEndParam
        Dim nTypeOfParam As eTestEndParam
        Dim dValue As Double   '시간단위는 Sec, 전압 = V, 전류 = 
    End Structure

#End Region

#Region "Property"

    Public Property Title() As String
        Get
            Return gbTestEndPara.Text
        End Get
        Set(ByVal value As String)
            gbTestEndPara.Text = value
        End Set
    End Property

    Public WriteOnly Property UsedParams As eTestEndParam()
        Set(value As eTestEndParam())
            m_UsedTestEndParam = value
            UpdateSettings()
        End Set
    End Property

    Public Property Settings As sTestEndParam()
        Get
            GetFormUI()
            Return m_TestEndpara
        End Get
        Set(ByVal value As sTestEndParam())
            If value Is Nothing = False Then
                SetFormUI(value)
                m_TestEndpara = value
            End If
        End Set
    End Property

    Public WriteOnly Property SetTestEndpara As eTestEndParam
        Set(ByVal value As eTestEndParam)
            cbEndPara.SelectedIndex = value
        End Set
    End Property

    Public WriteOnly Property SetTestEndvalue As Double
        Set(ByVal value As Double)
            txtEndValue.Text = value
        End Set
    End Property


#End Region

#End Region

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Public Sub init()
        gbTestEndPara.Location = New System.Drawing.Point(0, 0)
        gbTestEndPara.Dock = DockStyle.Fill


        'With cbEndPara
        '    .Items.Clear()
        '    For i As Integer = 0 To sCaptions_EndParam.Length - 1
        '        .Items.Add(sCaptions_EndParam(i))
        '    Next
        '    .SelectedIndex = 0
        'End With

        UpdateSettings()

      

    End Sub

    Public Sub GetFormUI()
        Dim sData() As String = Nothing
        Dim sDataBuff() As String = Nothing
        Dim nListCount As Integer
        Dim TestEndPara As eTestEndParam = Nothing

        nListCount = ucListTestEnd.GetListItemCount()

        ReDim m_TestEndpara(nListCount - 1)

        For i = 0 To nListCount - 1
            ucListTestEnd.GetRowData(i, sData)
            With m_TestEndpara(i)
                .nTypeOfParam = ConvertEndParamStringToInt(sData(0))
                If .nTypeOfParam = eTestEndParam.eTime Then
                    .dValue = CTime.Convert_HourToSec(CDbl(sData(1)))
                Else
                    .dValue = CDbl(sData(1))
                End If
            End With
        Next
    End Sub

    Public Sub SetFormUI(ByVal Settings() As sTestEndParam)

        Dim sData(2) As String

        ucListTestEnd.ClearAllData()

        For i As Integer = 0 To Settings.Length - 1
            sData(0) = i + 1
            sData(1) = sCaptions_EndParam(Settings(i).nTypeOfParam)
            'Select Case Settings(i).nTypeOfParam
            '    Case eTestEndParam.eTime
            '        sData(1) = sCaptions_EndParam(eTestEndParam.eTime)
            '    Case eTestEndParam.eLoopCount
            '        sData(1) = sCaptions_EndParam(eTestEndParam.eLoopCount)
            '    Case eTestEndParam.eVolt
            '        sData(1) = sCaptions_EndParam(eTestEndParam.eVolt)
            '    Case eTestEndParam.eCurr
            '        sData(1) = sCaptions_EndParam(eTestEndParam.eCurr)
            '    Case eTestEndParam.ePDCurr
            '        sData(1) = sCaptions_EndParam(eTestEndParam.ePDCurr)
            '    Case eTestEndParam.eLumi
            '        sData(1) = sCaptions_EndParam(eTestEndParam.eLumi)
            'End Select

            If Settings(i).nTypeOfParam = eTestEndParam.eTime Then
                sData(2) = CTime.Convert_SecToHour(Settings(i).dValue)
            Else
                sData(2) = Settings(i).dValue
            End If

            ucListTestEnd.AddRowData(sData)

        Next
    End Sub

    Private Sub UpdateSettings()
        With cbEndPara
            .Items.Clear()
            If m_UsedTestEndParam Is Nothing = False Then
                For i As Integer = 0 To m_UsedTestEndParam.Length - 1
                    .Items.Add(sCaptions_EndParam(m_UsedTestEndParam(i)))
                Next
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim sData(2) As String

        If txtEndValue.Text = "" Then
            txtEndValue.Text = 0
        End If


        sData(0) = ucListTestEnd.GetListItemCount + 1
        sData(1) = sCaptions_EndParam(m_UsedTestEndParam(cbEndPara.SelectedIndex))
        sData(2) = txtEndValue.Text

        ' If CheckList() = False Then   '???
        ucListTestEnd.AddRowData(sData)
        'End If

    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click

        Dim SelectedLineNo As Integer

        ucListTestEnd.GetSelectedRowNumber(SelectedLineNo)
        ucListTestEnd.DelSelectedRow(SelectedLineNo)
        IndexNumberChange(SelectedLineNo)

    End Sub

    Private Sub cbEndPara_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEndPara.SelectedIndexChanged
        Dim TestEndParam As eTestEndParam = m_UsedTestEndParam(cbEndPara.SelectedIndex)

        If TestEndParam < 0 Then Exit Sub

        lblEndValue.Text = sCaptions_EndParam(TestEndParam)

        RaiseEvent evTestEndParameChange(TestEndParam)

    End Sub

    Private Function CheckList() As Boolean  'What is this functions purpose?
        Dim sData() As String
        Dim sDataBuff() As String = Nothing
        Dim ListCount As Integer

        ListCount = ucListTestEnd.GetListItemCount()

        If ListCount = 0 Then
            Return False
        End If

        For i = 0 To ListCount - 1
            ucListTestEnd.GetRowData(i, sDataBuff)
            If sDataBuff(0).ToString = cbEndPara.SelectedItem Then
                sData = sDataBuff.Clone
                sData(sDataBuff.Length - 1) = txtEndValue.Text

                ucListTestEnd.SetRowData(i, sData, i + 1)
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub IndexNumberChange(ByVal Line_No As Integer)

        Dim ListCount As Integer
        Dim sData() As String = Nothing

        ListCount = ucListTestEnd.GetListItemCount()

        For i = Line_No To (ListCount - 1)
            ucListTestEnd.GetRowData(i, sData)
            ucListTestEnd.SetRowData(i, sData, i + 1)
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GetFormUI()
    End Sub


    Public Shared Function ConvertStrTestEndParamToInt(ByVal str As String) As eTestEndParam
        Select Case str
            Case eTestEndParam.eTime.ToString
                Return eTestEndParam.eTime
            Case eTestEndParam.eVolt.ToString
                Return eTestEndParam.eVolt
            Case eTestEndParam.eCurr.ToString
                Return eTestEndParam.eCurr
            Case eTestEndParam.ePDCurr.ToString
                Return eTestEndParam.ePDCurr
            Case eTestEndParam.eLumi.ToString
                Return eTestEndParam.eLumi
            Case eTestEndParam.eLoopCount.ToString
                Return eTestEndParam.eLoopCount
            Case eTestEndParam.eLumi_Delta.ToString
                Return eTestEndParam.eLumi_Delta
            Case Else
                Return -1
        End Select
    End Function

    Private Function ConvertEndParamStringToInt(ByVal str As String) As eTestEndParam
        Dim nEndParam As eTestEndParam
        For i As Integer = 0 To sCaptions_EndParam.Length - 1
            If str = sCaptions_EndParam(i) Then
                nEndParam = i
            End If
        Next
        Return nEndParam
    End Function

    Public Shared Function ConvertEnumEndParamStringToInt(ByVal str As String) As eTestEndParam
        Select Case str
            Case ucTestEndParam.eTestEndParam.eVolt.ToString
                Return ucTestEndParam.eTestEndParam.eVolt
            Case ucTestEndParam.eTestEndParam.eCurr.ToString
                Return ucTestEndParam.eTestEndParam.eCurr
            Case ucTestEndParam.eTestEndParam.eHightVolt.ToString
                Return ucTestEndParam.eTestEndParam.eHightVolt
            Case ucTestEndParam.eTestEndParam.eHighCurrent.ToString
                Return ucTestEndParam.eTestEndParam.eHighCurrent
            Case ucTestEndParam.eTestEndParam.eLumi.ToString
                Return ucTestEndParam.eTestEndParam.eLumi
            Case ucTestEndParam.eTestEndParam.ePDCurr.ToString
                Return ucTestEndParam.eTestEndParam.ePDCurr
            Case ucTestEndParam.eTestEndParam.eTime.ToString
                Return ucTestEndParam.eTestEndParam.eTime
            Case ucTestEndParam.eTestEndParam.eLoopCount.ToString
                Return ucTestEndParam.eTestEndParam.eLoopCount
            Case ucTestEndParam.eTestEndParam.eLumi_Delta.ToString
                Return ucTestEndParam.eTestEndParam.eLumi_Delta
            Case Else
                Return -1
        End Select
    End Function

    Private Sub txtEndValue_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEndValue.TextChanged
        'If txtEndValue.Text <> "" Then
        '    RaiseEvent evTestEndValuechange(CDbl(txtEndValue.Text))
        'End If

        Dim TempText() As String = Split(txtEndValue.Text, ".")

        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지


        Try
            RaiseEvent evTestEndValuechange(CDbl(txtEndValue.Text))
        Catch ex As Exception
            RaiseEvent evTestEndValuechange(0)
        End Try
    End Sub
End Class
