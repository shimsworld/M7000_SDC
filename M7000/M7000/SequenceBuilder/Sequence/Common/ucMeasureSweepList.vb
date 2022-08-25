Public Class ucMeasureSweepList

#Region "Define"
    Dim m_UserSweepList() As Double

    Public Event evBiasChange(ByVal Bias As Double)

    Dim m_UnitType As ucSweepSetting.eUnitType

#End Region

#Region "Structure and Enum"


#End Region

#Region "Property"

    Public Property Setting As Double()
        Get
            GetValueFormUI(m_UserSweepList)
            Return m_UserSweepList
        End Get
        Set(ByVal value As Double())
            If value Is Nothing = False Then
                m_UserSweepList = value
                SetValueToUI(m_UserSweepList)
            End If

        End Set
    End Property

    Public Property UnitType As ucSweepSetting.eUnitType
        Get
            Return m_UnitType
        End Get
        Set(ByVal value As ucSweepSetting.eUnitType)

            If m_UnitType <> value Then
                m_UnitType = value
                UpdateUnitType()
            End If
        End Set
    End Property

    Public Property Title As String
        Get
            Return gbSweepList.Text
        End Get
        Set(ByVal value As String)
            gbSweepList.Text = value
        End Set
    End Property


#End Region

#Region "Init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        gbSweepList.Location = New System.Drawing.Point(0, 0)
        gbSweepList.Dock = DockStyle.Fill
    End Sub
#End Region

#Region "Event"

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ucListMeasSweep.ClearAllData()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim SelectedListNo As Integer

        ucListMeasSweep.GetSelectedRowNumber(SelectedListNo)

        ucListMeasSweep.DelSelectedRow(SelectedListNo)

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim sData(1) As String

        sData(0) = ucListMeasSweep.GetListItemCount + 1
        sData(1) = tbBias.Text

        ucListMeasSweep.AddRowData(sData)

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveFile()
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        LoadFile()
    End Sub

    Private Sub tbBias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBias.TextChanged
        Dim TempText() As String = Split(tbBias.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        If TempText(TempText.Length - 1) = "" Then Exit Sub
        If TempText(TempText.Length - 1) = "" Then Exit Sub

        Try
            RaiseEvent evBiasChange(CDbl(tbBias.Text))
        Catch ex As Exception
            RaiseEvent evBiasChange(0)
            Exit Sub
        End Try
    End Sub

#End Region

#Region "Function"

    Private Function GetValueFormUI(ByRef sweepListInfo() As Double) As Boolean

        Dim nNumber() As Integer = Nothing
        Dim dBias() As Double = Nothing
        Dim nCnt As Integer

        nCnt = ucListMeasSweep.GetListItemCount

        If ucListMeasSweep.GetListItemCount <= 0 Then Return False

        ReDim nNumber(nCnt - 1)
        ReDim dBias(nCnt - 1)
        ReDim sweepListInfo(nCnt - 1)
        '  ReDim sweepListInfo.nNumber(nCnt - 1)

        ucListMeasSweep.GetColumnData(0, nNumber)
        ucListMeasSweep.GetColumnData(1, dBias)

        For i As Integer = 0 To ucListMeasSweep.GetListItemCount - 1
            ' sweepListInfo.nNumber(i) = nNumber(i)
            If m_UnitType = ucSweepSetting.eUnitType._milliAmpere Then
                sweepListInfo(i) = dBias(i) / 1000   '입력은 mA 단위 --> 실제 사용은 A단위
            Else
                sweepListInfo(i) = dBias(i)
            End If
        Next

        Return True
    End Function

    Private Sub SetValueToUI(ByVal sweepListInfo() As Double)

        Dim sdata(1) As String

        ucListMeasSweep.ClearAllData()

        For i As Integer = 0 To sweepListInfo.Length - 1
            sdata(0) = CStr(i + 1)
            If m_UnitType = ucSweepSetting.eUnitType._milliAmpere Then
                sdata(1) = sweepListInfo(i) * 1000
            Else
                sdata(1) = sweepListInfo(i)
            End If

            ucListMeasSweep.AddRowData(sdata)
        Next

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

#End Region

    Private Sub UpdateUnitType()
        lblValueUnit.Text = ucSweepSetting.m_sCaptions_Unit(m_UnitType)

        If m_UnitType = ucSweepSetting.eUnitType._Degree Then
            Label1.Text = "Value : "
        Else
            Label1.Text = "Bias : "
        End If
    End Sub


End Class
