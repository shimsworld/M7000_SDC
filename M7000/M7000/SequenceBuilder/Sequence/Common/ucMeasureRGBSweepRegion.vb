Public Class ucMeasureRGBSweepRegion '220825 Update by JKY : IVL RGB Sweep Region 추가

#Region "Define"
    Dim m_SetBias() As sSetSweepRegion
    Dim m_bIsVisibleUnit As Boolean = True
    Dim m_SweepType As eSweepType
    Dim m_UnitType As ucSweepSetting.eUnitType
    Dim m_SweepList() As Double
    Dim m_sPowerType() As String = New String() {"Vdd", "Vss", "Dr", "Dg", "Db"}

    Public rbSweepList(4) As RadioButton
    Public cbUseList(4) As CheckBox
    Public txtVCList(4, 12) As TextBox

    Public Event evErrMsgSend(ByVal ErrMsg As String)

    '  Public Event evStepBiasChange(ByVal StepBias As Double)
    ' Public Event evChangeBiasChange(ByVal ChangeBias As Double)

#End Region

#Region "Structure"

    Structure sSetSweepRegion
        Dim nSweepNumber As Integer
        Dim SweepType As ePowerType
        Dim dStart As Double
        Dim dStop As Double
        Dim dStep As Double
        Dim nPoint As Integer
        Dim setPowerValue() As sSetPowerRegion
    End Structure

    Structure sSetPowerRegion
        Dim PowerType As ePowerType
        Dim dStopV As Double
        Dim dStopC As Double
        Dim bIsUse As Boolean
    End Structure

#End Region


#Region "Enum"

    Public Enum eSweepDirection
        eForward
        eReverse
    End Enum

    Public Enum ePowerType
        eVdd
        eVss
        eDr
        eDg
        eDb
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

    Public Property Setting As ucMeasureRGBSweepRegion.sSetSweepRegion()
        Get
            GetValueFromUI(m_SetBias)
            Return m_SetBias
        End Get
        Set(ByVal value As ucMeasureRGBSweepRegion.sSetSweepRegion())
            If value Is Nothing = False Then
                m_SetBias = value
                SetValueToUI(m_SetBias)
            End If

        End Set
    End Property

    Public Property SweepList As Double()
        Get
            GetValueFromUI(m_SetBias)
            m_SweepList = MakeRGBSweepList(m_SetBias)
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
                CheckedChangeUIState()
                'UpdateUnitType()
            End If

        End Set
    End Property

#End Region

#Region "Init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        rbSweepList = New RadioButton() {rbSweep1, rbSweep2, rbSweep3, rbSweep4, rbSweep5}
        cbUseList = New CheckBox() {cbUse1, cbUse2, cbUse3, cbUse4, cbUse5}
        txtVCList = New TextBox(,) {
            {tbV1, tbC1},
            {tbV2, tbC2},
            {tbV3, tbC3},
            {tbV4, tbC4},
            {tbV5, tbC5}}

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        gbSweepCommon.Location = New System.Drawing.Point(0, 0)
        gbSweepCommon.Dock = DockStyle.Fill

        rbSweep1.Checked = True
        cbUse1.Checked = True
        cbUse2.Checked = True

        '220826 Update by JKY : 사용하는 PS 개수에 따라 Visible Change
        For i = 0 To txtVCList.GetLength(0) - 1
            If i < g_ConfigInfos.IVLPowerSupplyConfig.settings.Length Then
                rbSweepList(i).Visible = True
                cbUseList(i).Visible = True
                For j = 0 To txtVCList.GetLength(1) - 1
                    txtVCList(i, j).Visible = True
                Next
            Else
                rbSweepList(i).Visible = False
                cbUseList(i).Visible = False
                For j = 0 To txtVCList.GetLength(1) - 1
                    txtVCList(i, j).Visible = False
                Next
            End If
        Next

        SetListVier()
    End Sub

#End Region


    Private Sub SetListVier()
        ucListMeasSweep.ColHeader = {"No.", "SweepType", "Start", "Stop", "Step", "Point", "else"}
        ucListMeasSweep.ColHeaderWidthRatio = "10, 20, 15, 15, 15, 15, 20"
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
        Dim sData(6) As String

        sData(5) = tbPoint.Text
        If sData(5) = "NaN" Then
            MsgBox("Sweep Point set Error")
            Exit Sub
        End If

        For i = 0 To txtVCList.GetLength(0) - 1
            If cbUseList(i).Checked Then
                If rbSweepList(i).Checked Then
                    sData(0) = ucListMeasSweep.GetListItemCount + 1
                    sData(1) = i
                    sData(2) = tbStart.Text
                    sData(3) = txtVCList(i, 0).Text
                    sData(4) = tbStep.Text
                    sData(5) = tbPoint.Text
                    sData(6) += $"{i},{txtVCList(i, 0).Text},{txtVCList(i, 1).Text},"
                Else
                    sData(6) += $"{i},{txtVCList(i, 0).Text},{txtVCList(i, 1).Text},"
                End If
            Else
                sData(6) += $"{i},{0},{0},"
            End If
        Next

        'ucListMeasSweep.AddRowData(sData)

        '   sData(4) = tbPoint.Text
        'Sweep Mode 별 Pattern Get Set 변경 해줘야 함.
        If ucListMeasSweep.GetListItemCount <> 0 Then
            If CDbl(sData(2)) <= CDbl(sData(3)) Then
                SweepDirection = eSweepDirection.eForward
            Else
                SweepDirection = eSweepDirection.eReverse
            End If

            If CheckChangeSweepList(ucListMeasSweep.GetListItemCount, CDbl(sData(2)), SweepDirection) = False Then
                RaiseEvent evErrMsgSend("Sweep List set Error")
                MsgBox("Sweep List set Error")
            Else
                ucListMeasSweep.AddRowData(sData)
            End If
        Else
            ucListMeasSweep.AddRowData(sData)
        End If
    End Sub

#End Region

#Region "Function"

    Private Function GetValueFromUI(ByRef biasInfo() As sSetSweepRegion) As Boolean
        Dim nSweepListNumber() As Integer
        Dim nSweepType() As Integer
        Dim dStart() As Double = Nothing
        Dim dStop() As Double = Nothing
        Dim dStep() As Double = Nothing
        Dim nPoint() As Double = Nothing
        Dim sVCData() As String = Nothing
        Dim nCnt As Integer
        nCnt = ucListMeasSweep.GetListItemCount

        If ucListMeasSweep.GetListItemCount <= 0 Then Return False

        ReDim nSweepListNumber(nCnt - 1)
        ReDim nSweepType(nCnt - 1)
        ReDim dStart(nCnt - 1)
        ReDim dStop(nCnt - 1)
        ReDim dStep(nCnt - 1)
        ReDim nPoint(nCnt - 1)
        ReDim sVCData(nCnt - 1)
        ReDim biasInfo(nCnt - 1)

        ucListMeasSweep.GetColumnData(0, nSweepListNumber)
        ucListMeasSweep.GetColumnData(1, nSweepType)
        ucListMeasSweep.GetColumnData(2, dStart)
        ucListMeasSweep.GetColumnData(3, dStop)
        ucListMeasSweep.GetColumnData(4, dStep)
        ucListMeasSweep.GetColumnData(5, nPoint)
        ucListMeasSweep.GetColumnData(6, sVCData)

        For i As Integer = 0 To ucListMeasSweep.GetListItemCount - 1
            biasInfo(i).nSweepNumber = nSweepListNumber(i)
            biasInfo(i).SweepType = nSweepType(i)
            biasInfo(i).dStart = dStart(i)
            biasInfo(i).dStop = dStop(i)
            biasInfo(i).dStep = dStep(i)
            biasInfo(i).nPoint = nPoint(i)

            Dim datas() As String = sVCData(i).Split(",")
            ReDim biasInfo(i).setPowerValue(4)
            For j = 0 To 4
                biasInfo(i).setPowerValue(j).PowerType = CInt(datas(j * 3 + 0))
                biasInfo(i).setPowerValue(j).dStopV = CDbl(datas(j * 3 + 1))
                biasInfo(i).setPowerValue(j).dStopC = CDbl(datas(j * 3 + 2))
                biasInfo(i).setPowerValue(j).bIsUse = If(CDbl(datas(j * 3 + 1)) = 0, False, True)
            Next
        Next

        Return True
    End Function

    Public Shared Function MakeRGBSweepList(ByVal sweepRegions() As sSetSweepRegion) As Double()
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

    Private Sub SetValueToUI(ByVal biasInfo() As sSetSweepRegion)

        Dim sdata(6) As String

        ucListMeasSweep.ClearAllData()

        For i = 0 To biasInfo.Length - 1
            sdata(0) = biasInfo(i).nSweepNumber
            For j = 0 To 4
                If j = biasInfo(i).SweepType Then
                    sdata(1) = biasInfo(i).SweepType
                    sdata(2) = biasInfo(i).dStart
                    sdata(3) = biasInfo(i).dStop
                    sdata(4) = biasInfo(i).dStep
                    sdata(5) = biasInfo(i).nPoint
                    sdata(6) += $"{j},{biasInfo(i).setPowerValue(j).dStopV},{biasInfo(i).setPowerValue(j).dStopC},"
                Else
                    sdata(6) += $"{j},{biasInfo(i).setPowerValue(j).dStopV},{biasInfo(i).setPowerValue(j).dStopC},"
                End If
            Next
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

        Try
            beforeChangeStop = CDbl(sData(2))

            If SweepDirection = eSweepDirection.eForward Then
                If beforeChangeStop >= ChangeStop Then
                    Return False
                End If
            ElseIf SweepDirection = eSweepDirection.eReverse Then
                If beforeChangeStop <= ChangeStop Then
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function
#End Region

    Private Sub rbSweep_CheckedChanged(sender As Object, e As EventArgs) Handles rbSweep1.CheckedChanged, rbSweep2.CheckedChanged, rbSweep3.CheckedChanged, rbSweep4.CheckedChanged, rbSweep5.CheckedChanged
        CheckedChangeUIState()
    End Sub

    Private Sub cbUse_CheckedChanged(sender As Object, e As EventArgs) Handles cbUse1.CheckedChanged, cbUse2.CheckedChanged, cbUse3.CheckedChanged, cbUse4.CheckedChanged, cbUse5.CheckedChanged
        CheckedChangeUIState()
    End Sub

    Private Sub tbStart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbStart.TextChanged, tbStop.TextChanged
        CalSweepPoint()
    End Sub

    Private Sub tbV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbV1.TextChanged, tbV2.TextChanged, tbV3.TextChanged, tbV4.TextChanged, tbV5.TextChanged
        CalSweepPoint()
    End Sub

    Private Sub tbC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbC1.TextChanged, tbC2.TextChanged, tbC3.TextChanged, tbC4.TextChanged, tbC5.TextChanged
        CalSweepPoint()
    End Sub

    Private Sub tbStep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbStep.TextChanged
        CalSweepPoint()
    End Sub

    Private Sub CheckedChangeUIState()
        For i = 0 To txtVCList.GetLength(0) - 1
            If cbUseList(i).Checked Then
                For j = 0 To txtVCList.GetLength(1) - 1
                    rbSweepList(i).Enabled = True
                    txtVCList(i, j).Enabled = True
                Next
            Else
                For j = 0 To txtVCList.GetLength(1) - 1
                    rbSweepList(i).Enabled = False
                    txtVCList(i, j).Enabled = False
                Next
            End If
        Next
        For i = 0 To txtVCList.GetLength(0) - 1
            If rbSweepList(i).Checked Then
                If UnitType = ucSweepSetting.eUnitType._Voltage Then
                    lblSweepPS.Text = m_sPowerType(i) & Chr(13) & "V Sweep"
                    tbStop.Text = txtVCList(i, 0).Text
                Else
                    lblSweepPS.Text = m_sPowerType(i) & Chr(13) & "mA Sweep"
                    tbStop.Text = txtVCList(i, 1).Text
                End If
            End If
        Next
    End Sub

    Private Sub CalSweepPoint()
        Dim dStart As Double
        Dim dStop As Double
        Dim dStopV() As Double
        Dim dStopC() As Double
        Dim dStep As Double
        Dim dDelta As Double
        Dim sPoint As String = Nothing

        ReDim dStopV(txtVCList.GetLength(0))
        ReDim dStopC(txtVCList.GetLength(0))

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

        For i = 0 To txtVCList.GetLength(0) - 1
            Try
                dStopV(i) = CDbl(txtVCList(i, 0).Text)
                If rbSweepList(i).Checked Then
                    tbStop.Text = txtVCList(i, 0).Text
                End If
            Catch ex As Exception
                dStopV(i) = 0
            End Try
            Try
                dStopC(i) = CDbl(txtVCList(i, 1).Text)
                If rbSweepList(i).Checked Then
                    tbStop.Text = txtVCList(i, 1).Text
                End If
            Catch ex As Exception
                dStopC(i) = 0
            End Try
        Next

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

    Private Sub UpdateSweepType()

        lblPoint.Visible = True
        tbPoint.Visible = True
        SetListVier()
    End Sub

End Class
