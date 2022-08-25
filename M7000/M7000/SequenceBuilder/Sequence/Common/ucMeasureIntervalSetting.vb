Public Class ucMeasureIntervalSetting

#Region "Define"

    Dim m_SetTime() As sSetTime


    Structure sSetTime
        Dim Interval As CTime.sTimeValue
        Dim Change As CTime.sTimeValue
    End Structure

    Public Property Setting As ucMeasureIntervalSetting.sSetTime()
        Get
            GetSetTime(m_SetTime)
            Return m_SetTime
        End Get
        Set(ByVal value As ucMeasureIntervalSetting.sSetTime())
            If value Is Nothing = False Then
                m_SetTime = value
                SetSetTime(value)
            End If

        End Set
    End Property

    Public Property Setting_OneValue As ucMeasureIntervalSetting.sSetTime()
        Get
            Get_IntervaChangelTime(m_SetTime)
            Return m_SetTime
        End Get
        Set(value As ucMeasureIntervalSetting.sSetTime())
            Set_IntervaChangelTime(value)
            m_SetTime = value
        End Set
    End Property

    Public Event evErrMsgSend(ByVal ErrMsg As String)

    Public Event evIntervalTimeChange(ByVal IntervalTime As Double)
    Public Event evChangeTimeChange(ByVal ChangeTime As Double)

#End Region



    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        gbTime.Location = New System.Drawing.Point(0, 0)
        gbTime.Dock = DockStyle.Fill
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim sData(1) As String
        sData(0) = txtIntervalTime.Text
        sData(1) = txtChangeTime.Text

        If g_SequenceBuilderOptions.dMeasureIntervalMin > CDbl(txtIntervalTime.Text) Or g_SequenceBuilderOptions.dMeasureIntervalMax < CDbl(txtIntervalTime.Text) Then
            MsgBox("Interval Time Setting Error")
            Exit Sub
        End If

        If ucListMeasInterval.GetListItemCount <> 0 Then
            If CheckChangeTime(ucListMeasInterval.GetListItemCount, CDbl(sData(1))) = False Then
                RaiseEvent evErrMsgSend("Change Time Setting Error")
                MsgBox("Change Time Setting Error")
            Else
                ucListMeasInterval.AddRowData(sData)
            End If
        Else
            ucListMeasInterval.AddRowData(sData)
        End If

    End Sub

    Private Sub Get_IntervaChangelTime(ByRef timeInfo() As sSetTime)

        ReDim timeInfo(0)

        If txtIntervalTime.Text Is Nothing Or txtIntervalTime.Text = "" Then
            Exit Sub
        End If

        timeInfo(0).Interval = CTime.Convert_HoureToTimeValue(txtIntervalTime.Text)
        timeInfo(0).Change = CTime.Convert_HoureToTimeValue(txtIntervalTime.Text + 1)

    End Sub

    Private Sub Set_IntervaChangelTime(ByVal timeInfo() As sSetTime)

        If txtIntervalTime.Text Is Nothing Or txtIntervalTime.Text = "" Then
            Exit Sub
        End If

        txtIntervalTime.Text = timeInfo(0).Interval.dHour
        txtChangeTime.Text = timeInfo(0).Change.dHour
    End Sub


    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        ucListMeasInterval.ClearAllData()

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim SelectedListNo As Integer

        ucListMeasInterval.GetSelectedRowNumber(SelectedListNo)

        ucListMeasInterval.DelSelectedRow(SelectedListNo)

    End Sub


    Private Sub btnListUP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListUP.Click

        ucListMeasInterval.ListUP()
    End Sub

    Private Sub btnListDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListDown.Click

        ucListMeasInterval.ListDOWN()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveFile()
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        LoadFile()

    End Sub

    Private Sub SaveFile()
        Dim cFile As New CMcFile
        Dim FilePath As CMcFile.sFILENAME = Nothing
        If cFile.GetSaveFileName(CMcFile.eFileType._RCP, FilePath) = False Then
            Exit Sub
        End If
    End Sub

    Private Sub LoadFile()
        Dim cFile As New CMcFile
        Dim FilePath As CMcFile.sFILENAME = Nothing
        If cFile.GetLoadFileName(CMcFile.eFileType._RCP, FilePath) = False Then
            Exit Sub
        End If
    End Sub

    Private Function GetSetTime(ByRef timeInfo() As sSetTime) As Boolean

        Dim dInterval() As Double = Nothing
        Dim dChange() As Double = Nothing
        Dim nCnt As Integer

        nCnt = ucListMeasInterval.GetListItemCount

        ReDim dInterval(nCnt - 1)
        ReDim dChange(nCnt - 1)
        ReDim timeInfo(nCnt - 1)

        If ucListMeasInterval.GetListItemCount <= 0 Then Return False

        ucListMeasInterval.GetColumnData(0, dInterval)
        ucListMeasInterval.GetColumnData(1, dChange)

        For i As Integer = 0 To ucListMeasInterval.GetListItemCount - 1
            timeInfo(i).Interval = CTime.Convert_HoureToTimeValue(dInterval(i))
            timeInfo(i).Change = CTime.Convert_HoureToTimeValue(dChange(i))
        Next

        Return True
    End Function

    Private Sub SetSetTime(ByVal timeInfo() As sSetTime)

        Dim sdata(1) As String

        ucListMeasInterval.ClearAllData()

        For i As Integer = 0 To timeInfo.Length - 1
            sdata(0) = timeInfo(i).Interval.dHour
            sdata(1) = timeInfo(i).Change.dHour
            ucListMeasInterval.AddRowData(sdata)
        Next

    End Sub

    Private Function CheckChangeTime(ByVal CheckLineNumber As Integer, ByVal ChangeTime As Double) As Boolean
        Dim sData() As String = Nothing
        'Dim sData2() As String = Nothing
        Dim ChangeTime1 As Double
        'Dim ChangeTime2 As Double

        ucListMeasInterval.GetRowData(CheckLineNumber - 1, sData)
        'ucListMeasInterval.GetRowData(CheckLineNumber, sData2)

        ChangeTime1 = CDbl(sData(0))
        'ChangeTime2 = CDbl(sData2(1))

        If ChangeTime1 >= ChangeTime Then
            Return False
        End If

        'If ChangeTime1 >= ChangeTime2 Then
        '    Return False
        'End If

        Return True
    End Function

    Private Sub txtIntervalTime_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIntervalTime.TextChanged
        'If txtIntervalTime.Text <> "" Then
        '    RaiseEvent evIntervalTimeChange(CDbl(txtIntervalTime.Text))
        'End If
        Dim TempText() As String = Split(txtIntervalTime.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        If TempText(TempText.Length - 1) = "" Then Exit Sub
        If TempText(TempText.Length - 1) = "" Then Exit Sub

        Try
            RaiseEvent evIntervalTimeChange(CDbl(txtIntervalTime.Text))
        Catch ex As Exception
            RaiseEvent evIntervalTimeChange(0)
            Exit Sub
        End Try

    End Sub

    Private Sub txtChangeTime_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtChangeTime.TextChanged
        'If txtChangeTime.Text <> "" Then
        '    RaiseEvent evChangeTimeChange(CDbl(txtChangeTime.Text))
        'End If
        Dim TempText() As String = Split(txtChangeTime.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        If TempText(TempText.Length - 1) = "" Then Exit Sub
        If TempText(TempText.Length - 1) = "" Then Exit Sub

        Try
            RaiseEvent evChangeTimeChange(CDbl(txtChangeTime.Text))
        Catch ex As Exception
            RaiseEvent evChangeTimeChange(0)
            Exit Sub
        End Try
    End Sub

    'Private Sub GetSetTime()

    '    Dim iListCount As Integer

    '    'Dim SelectedListNo As Integer = Nothing
    '    Dim sLineData1() As String = Nothing
    '    Dim iModeNo1 As Integer = Nothing

    '    'Dim dSetModeTIme() As Double
    '    Dim dSetIntervalTime() As Double
    '    Dim dSetChangeTime() As Double

    '    Dim i1 As Integer = 0
    '    Dim i2 As Integer = 0

    '    iListCount = UcDispListView1.GetListItemCount

    '    'ReDim dSetModeTIme(iListCount - 1)
    '    ReDim dSetIntervalTime(iListCount - 1)
    '    ReDim dSetChangeTime(iListCount - 1)

    '    For i = 0 To iListCount - 1

    '        UcDispListView1.GetRowData(i, sLineData1)

    '        iModeNo1 = CInt(sLineData1(0).Substring(sLineData1(0).Length - 1, 1))

    '        If sLineData1(1).ToString <> CStr("-") Then

    '            ReDim Preserve m_SetTime(i1)

    '            With m_SetTime(i1)
    '                .dModeTime = CDbl(sLineData1(1).Clone)
    '                .dIntervalTime = Nothing
    '                .dChangeTime = Nothing
    '            End With

    '            i1 = i1 + 1
    '            i2 = 0

    '        ElseIf sLineData1(2).ToString <> CStr("-") And sLineData1(3).ToString <> CStr("-") Then

    '            dSetIntervalTime(i2) = CDbl(sLineData1(2).Clone)
    '            dSetChangeTime(i2) = CDbl(sLineData1(3).Clone)

    '            With m_SetTime(i1 - 1)
    '                ReDim Preserve .dIntervalTime(i2)
    '                ReDim Preserve .dChangeTime(i2)
    '            End With

    '            i2 = i2 + 1
    '        End If

    '        If i2 <> 0 Then
    '            With m_SetTime(i1 - 1)
    '                .dIntervalTime(i2 - 1) = CDbl(sLineData1(2).Clone)
    '                .dChangeTime(i2 - 1) = CDbl(sLineData1(3).Clone)
    '            End With
    '        End If

    '    Next

    '    'UcDispListView1.GetSelectedRowNumber(SelectedListNo)

    'End Sub



    'Private Sub ListADD2(ByVal Listdata() As String)

    '    'Dim AddDatabuff(AddData.Length - 1)

    '    'AddDatabuff = AddData.Clone

    '    ' Dim iListCount As Integer

    '    Dim sData(3) As String
    '    Dim sPreLineData(3) As String

    '    If UcDispListView1.GetListItemCount <> 0 Then

    '        UcDispListView1.GetRowData(UcDispListView1.GetListItemCount - 1, sPreLineData)

    '        sData(0) = (UcDispListView1.GetListItemCount + 1)

    '        Select Case sPreLineData(1)
    '            Case sPreLineData(1) = "-"
    '                sData(1) = "-"
    '                sData(2) = txtIntervalTime.Text
    '                sData(3) = txtChangeTime.Text
    '            Case Else
    '                sData(1) = txtModeTime.Text
    '                sData(2) = "-"
    '                sData(3) = "-"
    '        End Select
    '    Else
    '        sData(1) = txtModeTime.Text
    '        sData(2) = "-"
    '        sData(3) = "-"
    '    End If

    '    UcDispListView1.AddItems(sData)

    'End Sub


    'Private Sub LIST_UP()

    '    Dim SelectedListNo As Integer = Nothing
    '    Dim sLineData1() As String = Nothing
    '    Dim sLineData2() As String = Nothing
    '    Dim iModeNo1 As Integer = Nothing
    '    Dim iModeNo2 As Integer = Nothing

    '    UcDispListView1.GetSelectedRowNumber(SelectedListNo)

    '    If SelectedListNo = UcDispListView1.GetListItemCount Then
    '        Exit Sub
    '    End If

    '    UcDispListView1.GetRowData(SelectedListNo - 1, sLineData1)
    '    UcDispListView1.GetRowData(SelectedListNo, sLineData2)

    '    UcDispListView1.ListUP()
    '    UcDispListView1.SetRowData(SelectedListNo, sLineData1)


    '    'iModeNo1 = CInt(sLineData1(0).ToString().Substring(sLineData1(0).Length - 1, 1))
    '    'iModeNo2 = CInt(sLineData2(0).ToString().Substring(sLineData2(0).Length - 1, 1))

    '    'If iModeNo1 < iModeNo2 Then
    '    '    sLineData1(0) = "Mode#" & iModeNo2
    '    '    sLineData2(0) = "Mode#" & iModeNo1

    '    '    If SelectedListNo <> 0 And sLineData1(1).Substring(0) = "-" Then
    '    '        sLineData2(0) = "Mode#" & iModeNo2
    '    '    End If
    '    'End If

    '    'UcDispListView1.SetRowData(SelectedListNo - 1, sLineData2, SelectedListNo)
    '    'UcDispListView1.SetRowData(SelectedListNo, sLineData1, SelectedListNo + 1)

    'End Sub

    'Private Sub LIST_DOWN()

    '    Dim SelectedListNo As Integer = Nothing
    '    Dim sLineData1() As String = Nothing
    '    Dim sLineData2() As String = Nothing
    '    Dim iModeNo1 As Integer = Nothing
    '    Dim iModeNo2 As Integer = Nothing

    '    UcDispListView1.GetSelectedRowNumber(SelectedListNo)

    '    If SelectedListNo = UcDispListView1.GetListItemCount Then
    '        Exit Sub
    '    End If

    '    UcDispListView1.GetRowData(SelectedListNo, sLineData1)
    '    UcDispListView1.GetRowData(SelectedListNo + 1, sLineData2)

    '    UcDispListView1.SetRowData(SelectedListNo, sLineData2)



    '    UcDispListView1.SetRowData(SelectedListNo + 1, sLineData1)

    '    'iModeNo1 = CInt(sLineData1(0).Substring(sLineData1(0).Length - 1, 1))
    '    'iModeNo2 = CInt(sLineData2(0).Substring(sLineData2(0).Length - 1, 1))

    '    'If iModeNo1 < iModeNo2 Then

    '    '    sLineData1(0) = "Mode#" & iModeNo2
    '    '    sLineData2(0) = "Mode#" & iModeNo1
    '    '    If SelectedListNo <> 0 And sLineData1(1).Substring(0) = "-" Then
    '    '        sLineData2(0) = "Mode#" & iModeNo2
    '    '    End If
    '    'End If

    '    'UcDispListView1.SetRowData(SelectedListNo, sLineData2, SelectedListNo + 1)
    '    'UcDispListView1.SetRowData(SelectedListNo + 1, sLineData1, SelectedListNo + 2)
    'End Sub


    Private Sub ucMeasureIntervalSetting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
