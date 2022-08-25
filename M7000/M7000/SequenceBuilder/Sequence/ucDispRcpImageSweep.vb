Public Class ucDispRcpImageSweep


#Region "Defines"

    Public Event evADDImageSweepRcp()
    Public Event evUpdateImageSweepRcp()

    Structure sMoudleImageSweepInfos
        Dim MeasItems() As ucDispPGImageSweep.sImageListItem
        Dim MeasPoint() As ucDispPointSetting.sMeasurePointInfos
        Dim numofImage As Integer
    End Structure

    Dim m_rcpImageSweep As ucSequenceBuilder.sRcpImageSweep
    Dim m_PGImageList As ucDispPGImageSweep.sPGImageInfos
    Dim m_ModuleImageList As sMoudleImageSweepInfos
    Dim m_MeasPoint As ucDispPointSetting.sMeasurePointInfos

#End Region

#Region "Property"
    Public Property Settings As ucSequenceBuilder.sRcpImageSweep
        Get
            Return m_rcpImageSweep
        End Get
        Set(ByVal value As ucSequenceBuilder.sRcpImageSweep)
            m_rcpImageSweep = value
        End Set
    End Property

#End Region

#Region "Creator and Init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()

        tlpPanel2.Location = New System.Drawing.Point(0, 0)
        tlpPanel2.Dock = DockStyle.Fill

        Panel1.Dock = DockStyle.Fill

        gbSweepList.Location = New System.Drawing.Point(0, 0)
        gbSweepList.Dock = DockStyle.Fill

        ucImageList.Dock = DockStyle.Fill
        ucImageList.RowLineNum = 0

        btnADD.Dock = DockStyle.Fill
        btnUpdate.Dock = DockStyle.Fill
        btnEdit.Dock = DockStyle.Fill
        btnMeasPoint.Dock = DockStyle.Fill

    End Sub


#End Region


    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click
        RaiseEvent evADDImageSweepRcp()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        RaiseEvent evUpdateImageSweepRcp()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim dlg As New frmPatternGeneratorSetting

        dlg.ucPGImageSweep.VisibleMode = ucDispPGImageSweep.eViewMode._ImageSweep

        If dlg.ShowDialog = DialogResult.OK Then
            'm_rcpImageSweep.sModuleInfos = dlg.Settings
            m_PGImageList = m_rcpImageSweep.sModuleInfos.sImageInfos
            UpdateDisplay()
        End If
        SelectedItem(m_PGImageList, m_MeasPoint)  '2013-08-09 추가 선택한 SweepImage정보 m_ModuleImageList 구조체에 전달
    End Sub

    Private Sub btnMeasPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeasPoint.Click
        Dim dlg As New frmMeasPointSetting

        If dlg.ShowDialog = DialogResult.OK Then
            For i As Integer = 0 To m_ModuleImageList.MeasPoint.Length - 1
                m_ModuleImageList.MeasPoint(i) = dlg.ucDispPointSetting.Settings
            Next
        End If

    End Sub

    Private Sub SelectedItem(ByVal m_PGImageList As ucDispPGImageSweep.sPGImageInfos, ByVal m_MeasPoint As ucDispPointSetting.sMeasurePointInfos)

        Dim icount As Integer = 0
        For i As Integer = 0 To m_PGImageList.numOfImage - 1
            If m_PGImageList.SlideImage(i).bIsSelected = True Then
                ReDim Preserve m_ModuleImageList.MeasItems(icount)
                ReDim Preserve m_ModuleImageList.MeasPoint(icount)
                m_ModuleImageList.MeasItems(icount) = m_PGImageList.SlideImage(i)
                m_ModuleImageList.MeasPoint(icount).MeasPoint = m_MeasPoint.MeasPoint
                icount += 1
                m_ModuleImageList.numofImage = icount
            End If
        Next

        m_rcpImageSweep.ImageSweepInfo = m_ModuleImageList
    End Sub

    Private Sub UpdateDisplay()
        Dim rowData() As DataGridViewRow
        ' Dim cellData As DataGridViewCell
        Dim imgCell() As DataGridViewImageCell
        Dim imgNameCell() As DataGridViewTextBoxCell
        Dim DelayCell() As DataGridViewTextBoxCell
        Dim btnCell() As DataGridViewButtonCell


        ucImageList.ClearRow()
        Dim nCntRow As Integer = 0
        For i As Integer = 0 To m_PGImageList.numOfImage - 1
            If m_PGImageList.SlideImage(i).bIsSelected = True Then
                nCntRow += 1
            End If
        Next

        ReDim rowData(nCntRow - 1)
        ReDim imgCell(nCntRow - 1)
        ReDim imgNameCell(nCntRow - 1)
        ReDim DelayCell(nCntRow - 1)
        ReDim btnCell(nCntRow - 1)

        For i As Integer = 0 To rowData.Length - 1
            rowData(i) = New DataGridViewRow
            imgCell(i) = New DataGridViewImageCell
            imgNameCell(i) = New DataGridViewTextBoxCell
            DelayCell(i) = New DataGridViewTextBoxCell
            btnCell(i) = New DataGridViewButtonCell
        Next

        nCntRow = 0
        For i As Integer = 0 To m_PGImageList.numOfImage - 1

            If m_PGImageList.SlideImage(i).bIsSelected = True Then
                imgCell(nCntRow).Value = Image.FromFile(m_PGImageList.SlideImage(i).sPathImageFile)  'm_PGImageList.SlideImage(i).myImage  
                imgCell(nCntRow).ImageLayout = DataGridViewImageCellLayout.Stretch
                imgNameCell(nCntRow).Value = m_PGImageList.SlideImage(i).sImageName
                DelayCell(nCntRow).Value = m_PGImageList.SlideImage(i).sDelayTime
                btnCell(nCntRow).Value = "Edit"

                rowData(nCntRow).HeaderCell.Value = Format(nCntRow, "00")
                rowData(nCntRow).Cells.Add(imgCell(nCntRow))
                rowData(nCntRow).Cells.Add(imgNameCell(nCntRow))
                rowData(nCntRow).Cells.Add(DelayCell(nCntRow))
                rowData(nCntRow).Cells.Add(btnCell(nCntRow))

                ucImageList.AddRowData(rowData(nCntRow))

                nCntRow += 1
            End If

        Next

    End Sub


    Private Sub ucImageList_evMeasPointEdit(ByVal MeasPoint As ucDispPointSetting.sMeasurePointInfos, ByVal SelectedRowNum As Integer) Handles ucImageList.evMeasPointEdit
        m_ModuleImageList.MeasPoint(SelectedRowNum).MeasPoint = MeasPoint.MeasPoint
        ' ModuleImageList = m_ModuleImageList
    End Sub


End Class
