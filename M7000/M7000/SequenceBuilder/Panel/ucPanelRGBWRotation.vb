Public Class ucPanelRGBWRotation

#Region "Define"
    Dim m_RGBRotationParameter As CSeqRoutineSG.sRGBRotationInfos
#End Region

#Region "Structure"
  
#End Region


#Region "Creator & Disposer & init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        grbRotationSettings.Location = New System.Drawing.Point(0, 0)
        grbRotationSettings.Dock = DockStyle.Fill
    End Sub

#End Region

#Region "Property"
    Public Property Settings As CSeqRoutineSG.sRGBRotationInfos
        Get
            GetValueFromUI(m_RGBRotationParameter)
            Return m_RGBRotationParameter
        End Get
        Set(ByVal value As CSeqRoutineSG.sRGBRotationInfos)
            If value.sRotationParameter Is Nothing = False Then
                m_RGBRotationParameter = value
                SetValueFromUI(m_RGBRotationParameter)
            End If
        End Set
    End Property
#End Region


#Region "Function"

    Private Function GetValueFromUI(ByRef rotationInfo As CSeqRoutineSG.sRGBRotationInfos) As Boolean
        Dim nCnt As Integer
        Dim sSignalName() As String = Nothing
        Dim dDelay() As Double = Nothing
        Dim dRed() As Double = Nothing
        Dim dGreen() As Double = Nothing
        Dim dBlue() As Double = Nothing

        rotationInfo.bRotationUse = chkRotationUse.Checked
        nCnt = ucListRGB.GetListItemCount
        ReDim rotationInfo.sRotationParameter(nCnt - 1)

        If ucListRGB.GetListItemCount <= 0 Then Return False

        ReDim sSignalName(nCnt - 1)
        ReDim dDelay(nCnt - 1)
        ReDim dRed(nCnt - 1)
        ReDim dGreen(nCnt - 1)
        ReDim dBlue(nCnt - 1)

        ucListRGB.GetColumnData(1, sSignalName)
        ucListRGB.GetColumnData(2, dDelay)
        ucListRGB.GetColumnData(3, dRed)
        ucListRGB.GetColumnData(4, dGreen)
        ucListRGB.GetColumnData(5, dBlue)

        For i As Integer = 0 To ucListRGB.GetListItemCount - 1
            rotationInfo.sRotationParameter(i).sSignalName = sSignalName(i)
            rotationInfo.sRotationParameter(i).dDelay = dDelay(i)
            rotationInfo.sRotationParameter(i).dRed = dRed(i)
            rotationInfo.sRotationParameter(i).dGreen = dGreen(i)
            rotationInfo.sRotationParameter(i).dBlue = dBlue(i)
        Next

        Return True
    End Function


    Private Sub SetValueFromUI(ByVal rotationInfo As CSeqRoutineSG.sRGBRotationInfos)

        Dim sdata(5) As String

        chkRotationUse.Checked = rotationInfo.bRotationUse
        ucListRGB.ClearAllData()

        For i As Integer = 0 To rotationInfo.sRotationParameter.Length - 1
            sdata(0) = ucListRGB.GetListItemCount
            sdata(1) = rotationInfo.sRotationParameter(i).sSignalName
            sdata(2) = rotationInfo.sRotationParameter(i).dDelay
            sdata(3) = rotationInfo.sRotationParameter(i).dRed
            sdata(4) = rotationInfo.sRotationParameter(i).dGreen
            sdata(5) = rotationInfo.sRotationParameter(i).dBlue

            ucListRGB.AddRowData(sdata)
        Next

    End Sub

#End Region


#Region "Event Function"
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ucListRGB.ClearAllData()
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim sData(5) As String
        Dim sOffBias As String = tbOffBias.Text

        sData(0) = ucListRGB.GetListItemCount + 1
        sData(2) = tbRGBDelay.Text

        If rdoRed.Checked = True Then
            sData(1) = "Red"
            sData(3) = tbRGBValue.Text
            sData(4) = sOffBias
            sData(5) = sOffBias
        ElseIf rdoGreen.Checked = True Then
            sData(1) = "Green"
            sData(3) = sOffBias
            sData(4) = tbRGBValue.Text
            sData(5) = sOffBias
        ElseIf rdoBlue.Checked = True Then
            sData(1) = "Blue"
            sData(3) = sOffBias
            sData(4) = sOffBias
            sData(5) = tbRGBValue.Text
        ElseIf rdoWhite.Checked = True Then
            sData(1) = "White"
            sData(3) = tbRGBValue.Text
            sData(4) = tbRGBValue.Text
            sData(5) = tbRGBValue.Text
        End If

        ucListRGB.AddRowData(sData)

    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim SelectedListNo As Integer

        ucListRGB.GetSelectedRowNumber(SelectedListNo)

        ucListRGB.DelSelectedRow(SelectedListNo)
    End Sub


    Private Sub chkRotationUse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRotationUse.CheckedChanged
        If chkRotationUse.Checked = True Then
            grbRotationSettings.Enabled = True
        Else
            grbRotationSettings.Enabled = False
        End If
    End Sub

#End Region


   

End Class
