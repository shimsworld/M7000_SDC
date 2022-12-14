Public Class ucMeasureSweepRegion

#Region "Define"
    Dim m_SetBias() As sSetSweepRegion
    Dim m_bIsVisibleUnit As Boolean = True
    Dim m_SweepType As eSweepType
    Dim m_UnitType As ucSweepSetting.eUnitType
    Dim m_SweepList() As Double

    Public Event evErrMsgSend(ByVal ErrMsg As String)

    '  Public Event evStepBiasChange(ByVal StepBias As Double)
    ' Public Event evChangeBiasChange(ByVal ChangeBias As Double)

#End Region

#Region "Structure"

    Structure sSetSweepRegion
        Dim nSweepNumber As Integer
        Dim dStart As Double
        Dim dStop As Double
        Dim dStep As Double
        Dim nPoint As Integer
        Dim nRed As Integer
        Dim nGreen As Integer
        Dim nBlue As Integer
        Dim nLevel As Double
        Dim nGrayValue() As ucDispPGGrayScale.sPGGrayScale
    End Structure

#End Region


#Region "Enum"

    Public Enum eSweepDirection
        eForward
        eReverse
    End Enum

    Public Enum eSweepType
        _IVLSweep
        _GraySweep
        _UserPattern
        _ViewingAngle
        _RGBSweep
    End Enum

#End Region


#Region "Property"

    ' GraySetting,  Setting  Common Change
    Public WriteOnly Property GraySetting As ucDispPGGrayScale.sPGGrayScale()
        Set(ByVal value As ucDispPGGrayScale.sPGGrayScale())
            If value Is Nothing = False Then
                GraySetFormUI(value)
            End If
        End Set
    End Property

    Public Property Setting As ucMeasureSweepRegion.sSetSweepRegion()
        Get
            GetValueFromUI(m_SetBias)
            Return m_SetBias
        End Get
        Set(ByVal value As ucMeasureSweepRegion.sSetSweepRegion())
            If value Is Nothing = False Then
                m_SetBias = value
                SetValueToUI(m_SetBias)
            End If

        End Set
    End Property


    Public Property SweepList As Double()
        Get
            GetValueFromUI(m_SetBias)
            m_SweepList = MakeSweepList(m_SetBias)
            Return m_SweepList
        End Get
        Set(ByVal value As Double())
            m_SweepList = value 'MakeSweepList(m_SetBias)
        End Set
    End Property


    Public Property IsVisibleUnit As Boolean
        Get
            Return m_bIsVisibleUnit
        End Get
        Set(ByVal value As Boolean)
            m_bIsVisibleUnit = value
            If m_bIsVisibleUnit = True Then
                lblStartValueUnit.Visible = True
                lblStepValueUnit.Visible = True
                lblStopValueUnit.Visible = True
            Else
                lblStartValueUnit.Visible = False
                lblStepValueUnit.Visible = False
                lblStopValueUnit.Visible = False
            End If

        End Set
    End Property


    Public Property SweepType As eSweepType
        Get
            Return m_SweepType
        End Get
        Set(ByVal value As eSweepType)
            If m_SweepType <> value Then
                m_SweepType = value
                UpdateSweepType()
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


#End Region

#Region "Init"


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        gbSweepCommon.Location = New System.Drawing.Point(0, 0)
        gbSweepCommon.Dock = DockStyle.Fill

        m_SweepType = eSweepType._IVLSweep

        SetListVier(m_SweepType)
    End Sub

#End Region


    Private Sub SetListVier(ByVal SweepType As eSweepType)
        If SweepType = eSweepType._UserPattern Then
            ucListMeasSweep.ColHeader = {"No.", "Red", " Green", "Blue"}
            ucListMeasSweep.ColHeaderWidthRatio = "10, 20, 20, 20"
        Else
            ucListMeasSweep.ColHeader = {"No.", "Start", " Stop", "Step", "Point"}
            ucListMeasSweep.ColHeaderWidthRatio = "16, 21, 21, 21, 21"
        End If
    End Sub

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
        Dim SweepDirection As eSweepDirection
        Dim sData(4) As String

        If m_SweepType = eSweepType._UserPattern Then
            ReDim sData(3)
        Else
            ReDim sData(4)
            sData(4) = tbPoint.Text
            If sData(4) = "NaN" Then
                MsgBox("Sweep Point set Error")
                Exit Sub
            End If
        End If

        sData(0) = ucListMeasSweep.GetListItemCount + 1
        sData(1) = tbStart.Text
        sData(2) = tbStop.Text
        sData(3) = tbStep.Text

        '   sData(4) = tbPoint.Text
        'Sweep Mode 별 Pattern Get Set 변경 해줘야 함.
        If ucListMeasSweep.GetListItemCount <> 0 Then

            If m_SweepType <> eSweepType._UserPattern Then
                If CDbl(sData(1)) <= CDbl(sData(2)) Then
                    SweepDirection = eSweepDirection.eForward
                Else
                    SweepDirection = eSweepDirection.eReverse
                End If

                If CheckChangeSweepList(ucListMeasSweep.GetListItemCount, CDbl(sData(1)), SweepDirection) = False Then
                    RaiseEvent evErrMsgSend("Sweep List set Error")
                    MsgBox("Sweep List set Error")
                Else
                    ucListMeasSweep.AddRowData(sData)
                End If
            Else
                ucListMeasSweep.AddRowData(sData)
            End If

        Else
            ucListMeasSweep.AddRowData(sData)
        End If
    End Sub

    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    SaveFile()
    'End Sub

    'Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
    '    LoadFile()
    'End Sub

    'Private Sub tbStepBias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbStepBias.TextChanged
    '    Dim TempText() As String = Split(tbStepBias.Text, ".")
    '    Dim TempText2 As String = ""

    '    If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

    '    If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

    '    If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

    '    If TempText(TempText.Length - 1) = "" Then Exit Sub
    '    If TempText(TempText.Length - 1) = "" Then Exit Sub

    '    Try
    '        RaiseEvent evStepBiasChange(CDbl(tbStepBias.Text))
    '    Catch ex As Exception
    '        RaiseEvent evStepBiasChange(0)
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub tbChangeBias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbChangeBias.TextChanged
    '    Dim TempText() As String = Split(tbChangeBias.Text, ".")
    '    Dim TempText2 As String = ""

    '    If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

    '    If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

    '    If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

    '    If TempText(TempText.Length - 1) = "" Then Exit Sub
    '    If TempText(TempText.Length - 1) = "" Then Exit Sub

    '    Try
    '        RaiseEvent evChangeBiasChange(CDbl(tbChangeBias.Text))
    '    Catch ex As Exception
    '        RaiseEvent evChangeBiasChange(0)
    '        Exit Sub
    '    End Try
    'End Sub

#End Region

#Region "Function"

    Private Function GetValueFromUI(ByRef biasInfo() As sSetSweepRegion) As Boolean
        Dim nSweepListNumber() As Integer
        Dim dStart() As Double = Nothing
        Dim dStop() As Double = Nothing
        Dim dStep() As Double = Nothing
        Dim nPoint() As Double = Nothing
        Dim nCnt As Integer
        Dim dRed() As Double = Nothing
        Dim dGreen() As Double = Nothing
        Dim dBlue() As Double = Nothing
        Dim dLevel() As Double = Nothing
        nCnt = ucListMeasSweep.GetListItemCount

        If ucListMeasSweep.GetListItemCount <= 0 Then Return False

        ReDim nSweepListNumber(nCnt - 1)
        ReDim dStart(nCnt - 1)
        ReDim dStop(nCnt - 1)
        ReDim dStep(nCnt - 1)
        ReDim nPoint(nCnt - 1)
        ReDim biasInfo(nCnt - 1)
        ReDim dRed(nCnt - 1)
        ReDim dGreen(nCnt - 1)
        ReDim dBlue(nCnt - 1)
        ReDim dLevel(nCnt - 1)

        ucListMeasSweep.GetColumnData(0, nSweepListNumber)

        If m_SweepType = eSweepType._UserPattern Then
            ucListMeasSweep.GetColumnData(1, dRed)
            ucListMeasSweep.GetColumnData(2, dGreen)
            ucListMeasSweep.GetColumnData(3, dBlue)
        Else
            ucListMeasSweep.GetColumnData(1, dStart)
            ucListMeasSweep.GetColumnData(2, dStop)
            ucListMeasSweep.GetColumnData(3, dStep)
            ucListMeasSweep.GetColumnData(4, nPoint)
            '    ucListMeasSweep.GetColumnData(5, dLevel)
        End If


        For i As Integer = 0 To ucListMeasSweep.GetListItemCount - 1
            biasInfo(i).nSweepNumber = nSweepListNumber(i)
            If m_SweepType = eSweepType._UserPattern Then
                biasInfo(i).nRed = dRed(i)
                biasInfo(i).nGreen = dGreen(i)
                biasInfo(i).nBlue = dBlue(i)
            Else
                biasInfo(i).dStart = dStart(i)
                biasInfo(i).dStop = dStop(i)
                biasInfo(i).dStep = dStep(i)
                biasInfo(i).nPoint = Math.Ceiling(nPoint(i))
                '  biasInfo(i).nLevel = dLevel(i)
            End If
        Next

        Return True
    End Function

    Public Shared Function MakeSweepList(ByVal sweepRegions() As sSetSweepRegion) As Double()
        Dim dStartValue, dStopValue, dStepValue As Double
        Dim nPoint, nTotPoint As Integer

        Dim dArrSweepList() As Double = Nothing
        Dim arrSweepList() As Double

        If sweepRegions Is Nothing Then Return Nothing

        Dim i, nCnt As Integer

        For nCnt = 0 To sweepRegions.Length - 1

            dStartValue = sweepRegions(nCnt).dStart 'SweepParameter(nCnt).dStart
            dStopValue = sweepRegions(nCnt).dStop
            dStepValue = sweepRegions(nCnt).dStep
            nPoint = sweepRegions(nCnt).nPoint

            If dStartValue < dStopValue Then   '정방향 Sweep -Bias --> +Bias

            Else   '역방향 Sweep +Bias --> -Bias
                dStepValue = -Math.Abs(dStepValue)
            End If

            ReDim Preserve dArrSweepList(nPoint + nTotPoint - 1)

            dArrSweepList(0 + nTotPoint) = dStartValue
            For i = 1 To nPoint - 1
                dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue))
            Next

            nTotPoint = nTotPoint + nPoint

        Next

        'With sIVLCominfos

        '    If .sweepMode = ucDispRcpIVLSweep.eSweepMode.eCycle Then
        '        Dim dArrBuf(dArrSweepList.Length - 1) As Double

        '        ReDim Preserve dArrSweepList(dArrSweepList.Length + dArrBuf.Length - 1)

        '        For j As Integer = dArrBuf.Length To dArrSweepList.Length - 1
        '            dArrSweepList(i) = dArrSweepList(dArrSweepList.Length - i - 1)
        '        Next
        '    End If
        'End With

        arrSweepList = dArrSweepList.Clone

        Return arrSweepList

    End Function

    Public Function MakeSweepList_Linear(ByVal SweepParameter() As ucMeasureSweepRegion.sSetSweepRegion, ByRef arrSweepList() As Double) As Boolean

        Dim dStartValue, dStopValue, dStepValue As Double
        Dim nPoint, nTotPoint As Integer

        Dim dArrSweepList() As Double = Nothing
        ' Dim iNumOfDataIV, iNumOfDataIVL As Integer
        Dim i, nCnt As Integer

        On Error GoTo MakeSweep


        For nCnt = 0 To SweepParameter.Length - 1

            dStartValue = SweepParameter(nCnt).dStart
            dStopValue = SweepParameter(nCnt).dStop
            dStepValue = SweepParameter(nCnt).dStep
            nPoint = SweepParameter(nCnt).nPoint

            If dStartValue < dStopValue Then   '정방향 Sweep -Bias --> +Bias

            Else   '역방향 Sweep +Bias --> -Bias
                dStepValue = -Math.Abs(dStepValue)
            End If


            ReDim Preserve dArrSweepList(nPoint + nTotPoint - 1)

            dArrSweepList(0 + nTotPoint) = dStartValue
            For i = 1 To nPoint - 1
                dArrSweepList(i + nTotPoint) = CDbl(CStr(dArrSweepList(i + nTotPoint - 1) + dStepValue))
            Next

            nTotPoint = nTotPoint + nPoint

        Next

        arrSweepList = dArrSweepList.Clone

        Return True



MakeSweep:
        Return False

    End Function


    Private Sub GraySetFormUI(ByVal grayInfo() As ucDispPGGrayScale.sPGGrayScale)

        Dim sdata(3) As String

        ucListMeasSweep.ClearAllData()

        For i As Integer = 0 To grayInfo.Length - 1
            sdata(0) = i + 1
            sdata(1) = grayInfo(i).nRed
            sdata(2) = grayInfo(i).nGreen
            sdata(3) = grayInfo(i).nBlue

            ucListMeasSweep.AddRowData(sdata)
        Next

    End Sub



    Private Sub SetValueToUI(ByVal biasInfo() As sSetSweepRegion)

        Dim sdata(4) As String

        ucListMeasSweep.ClearAllData()

        For i As Integer = 0 To biasInfo.Length - 1

            If m_SweepType = eSweepType._UserPattern Then
                ReDim sdata(3)
                sdata(0) = biasInfo(i).nSweepNumber
                sdata(1) = biasInfo(i).nRed
                sdata(2) = biasInfo(i).nGreen
                sdata(3) = biasInfo(i).nBlue
            Else
                sdata(0) = biasInfo(i).nSweepNumber
                sdata(1) = biasInfo(i).dStart
                sdata(2) = biasInfo(i).dStop
                sdata(3) = biasInfo(i).dStep
                sdata(4) = biasInfo(i).nPoint
                '   sdata(5) = biasInfo(i).nLevel
            End If

            ucListMeasSweep.AddRowData(sdata)
        Next

    End Sub

    'Private Sub SaveFile()
    '    Dim cFile As New CMcFile
    '    Dim FilePath As CMcFile.sFILENAME = Nothing
    '    If cFile.GetSaveFileName(CMcFile.eFileType.eRCP, FilePath) = False Then
    '        Exit Sub
    '    End If
    'End Sub

    'Private Sub LoadFile()
    '    Dim cFile As New CMcFile
    '    Dim FilePath As CMcFile.sFILENAME = Nothing
    '    If cFile.GetLoadFileName(CMcFile.eFileType.eRCP, FilePath) = False Then
    '        Exit Sub
    '    End If
    'End Sub

    Private Function CheckChangeSweepList(ByVal CheckLineNumber As Integer, ByVal ChangeStop As Double, ByVal SweepDirection As eSweepDirection) As Boolean
        Dim sData() As String = Nothing
        Dim beforeChangeStop As Double

        ucListMeasSweep.GetRowData(CheckLineNumber - 1, sData)

        beforeChangeStop = CDbl(sData(1))

        If SweepDirection = eSweepDirection.eForward Then
            If beforeChangeStop >= ChangeStop Then
                Return False
            End If
        ElseIf SweepDirection = eSweepDirection.eReverse Then
            If beforeChangeStop <= ChangeStop Then
                Return False
            End If
        End If

        Return True
    End Function
#End Region

    Private Sub tbStart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbStart.TextChanged
        If m_SweepType <> eSweepType._UserPattern Then
            CalSweepPoint()
        End If
    End Sub

    Private Sub tbStop_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbStop.TextChanged
        If m_SweepType <> eSweepType._UserPattern Then
            CalSweepPoint()
        End If
    End Sub

    Private Sub tbStep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbStep.TextChanged
        If m_SweepType <> eSweepType._UserPattern Then
            CalSweepPoint()
        End If
    End Sub

    Private Sub CalSweepPoint()
        Dim dStart As Double
        Dim dStop As Double
        Dim sPoint As String = Nothing
        Dim dStep As Double
        Dim dDelta As Double

        Try
            dStart = CDbl(tbStart.Text)
        Catch ex As Exception
            dStart = 0
            Exit Sub
        End Try

        Try
            dStop = CDbl(tbStop.Text)
        Catch ex As Exception
            dStop = 0
            Exit Sub
        End Try

        Try
            dStep = CDbl(tbStep.Text)
        Catch ex As Exception
            dStep = 0
            Exit Sub
        End Try

        If dStart < dStop Then
            dDelta = dStop - dStart
        Else
            dDelta = dStart - dStop
        End If

        sPoint = CStr((dDelta / dStep) + 1)
        tbPoint.Text = sPoint

    End Sub

    Private Function MakeSweepList_Linear(ByVal StartVal As Double, ByVal StopVal As Double, ByVal nPoint As Integer, ByRef StepVal As Double, ByRef arrSweepList() As Double) As Boolean

        Dim dStartBias, dStopBias As Double
        Dim dDelta1, dDelta2 As Double
        Dim dChangeStep As Double

        Dim dArrSweepList() As Double
        Dim iNumOfDataIV, iNumOfDataIVL As Integer
        Dim i As Integer

        On Error GoTo MakeSweep

        dStartBias = CDbl(StartVal)
        dStopBias = CDbl(StopVal)

        If dStartBias < dStopBias Then   '정방향 Sweep -Bias --> +Bias
            dDelta1 = dStopBias - dStartBias
            StepVal = dDelta1 / (nPoint - 1)
        Else   '역방향 Sweep +Bias --> -Bias
            dDelta1 = dStartBias - dStopBias
            StepVal = dDelta1 / (nPoint - 1)
            StepVal = -Math.Abs(StepVal)
        End If

        ReDim dArrSweepList(nPoint - 1)

        dArrSweepList(0) = dStartBias
        For i = 1 To nPoint - 1
            dArrSweepList(i) = CDbl(CStr(dArrSweepList(i - 1) + StepVal))
        Next

        arrSweepList = dArrSweepList.Clone

        Return True

MakeSweep:
        Return False

    End Function


    Private Sub UpdateUnitType()
        lblStartValueUnit.Text = ucSweepSetting.m_sCaptions_Unit(m_UnitType)
        lblStepValueUnit.Text = ucSweepSetting.m_sCaptions_Unit(m_UnitType)
        lblStopValueUnit.Text = ucSweepSetting.m_sCaptions_Unit(m_UnitType)
    End Sub

    Private Sub UpdateSweepType()

        Select Case m_SweepType

            Case eSweepType._IVLSweep
                gbSweepCommon.Text = "IVL Sweep Region"
                lblPoint.Visible = True
                tbPoint.Visible = True
                lblStart.Text = "Start :"
                lblStop.Text = "Stop :"
                lblStep.Text = "Step :"
                IsVisibleUnit = True
            Case eSweepType._GraySweep
                gbSweepCommon.Text = "Gray Scale Sweep Region"
                lblPoint.Visible = True
                tbPoint.Visible = True
                lblStart.Text = "Start :"
                lblStop.Text = "Stop :"
                lblStep.Text = "Step :"

                IsVisibleUnit = False
            Case eSweepType._UserPattern
                gbSweepCommon.Text = "Gray Scale Sweep Table"
                lblPoint.Visible = False
                tbPoint.Visible = False
                lblStart.Text = "Red :"
                lblStop.Text = "Blue :"
                lblStep.Text = "Green :"

                IsVisibleUnit = False
            Case eSweepType._ViewingAngle
                gbSweepCommon.Text = "Viewing Angle Sweep Table"
                lblPoint.Visible = True
                tbPoint.Visible = True
                lblStart.Text = "Start"
                lblStop.Text = "Stop"
                lblStep.Text = "Step"

                IsVisibleUnit = True
            Case Else
                gbSweepCommon.Text = "Undefined"
                IsVisibleUnit = False
        End Select

        SetListVier(m_SweepType)
    End Sub


End Class
