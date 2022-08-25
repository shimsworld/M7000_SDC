Imports System.IO

Public Class ucDispPointSetting



#Region "Defiens"

    Dim m_MeasPointInfo As sMeasurePointInfos
    Dim m_tempPoints As sPoint
    Dim m_MeasureImagePath As String
    Dim m_SelectedColor As System.Drawing.Color
    Dim m_Color1 As System.Drawing.Color
    Dim m_color2 As System.Drawing.Color

    Public Structure sMeasurePointInfos
        Dim marginFromAlignMark As sPoint
        Dim MeasPoint() As sPoint
    End Structure

    Public Structure sPoint
        Dim X As Double
        Dim Y As Double
        Dim ptColor As System.Drawing.Color
    End Structure

#End Region

#Region "Creator"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        UcDispTarget_PanelModuel1.VisibleTemp = False

        init()
    End Sub

#End Region


#Region "Properties"


    Public Property Settings() As sMeasurePointInfos
        Get
            GetValueFromUI()
            Return m_MeasPointInfo
        End Get
        Set(ByVal value As sMeasurePointInfos)
            m_MeasPointInfo = value
            SetValueToUI()
        End Set
    End Property


    Public Property targetSize As ucSampleInfos.sSampleSize
        Get
            Return UcDispTarget_PanelModuel1.TargetSize
        End Get
        Set(ByVal value As ucSampleInfos.sSampleSize)
            UcDispTarget_PanelModuel1.TargetSize = value
        End Set
    End Property

    Public Property TargetType As ucSampleInfos.eSampleType
        Get
            Return UcDispTarget_PanelModuel1.TargetType
        End Get
        Set(ByVal value As ucSampleInfos.eSampleType)
            UcDispTarget_PanelModuel1.TargetType = value
        End Set
    End Property

    Public Property Temp As Double
        Get
            Return UcDispTarget_PanelModuel1.Temp
        End Get
        Set(ByVal value As Double)
            UcDispTarget_PanelModuel1.Temp = value
        End Set
    End Property

#End Region


#Region "Function"

    Private Function GetValueFromUI() As Boolean
        Dim nCnt As Integer = 0
        Dim dXpos() As Double = Nothing
        Dim dYpos() As Double = Nothing

        If tbMarginX.Text = "" Or tbMarginY.Text = "" Then
            Return False
        End If

        m_MeasPointInfo.marginFromAlignMark.X = CDbl(tbMarginX.Text)
        m_MeasPointInfo.marginFromAlignMark.Y = CDbl(tbMarginY.Text)

        'nCnt = UcDispListView1.GetListItemCount

        'ReDim dXpos(nCnt - 1)
        'ReDim dYpos(nCnt - 1)

        'UcDispListView1.GetColumnData(1, dXpos)
        'UcDispListView1.GetColumnData(2, dYpos)

        'If UcDispListView1.GetListItemCount <= 0 Then Return False

        'ReDim m_MeasPointInfo.MeasPoint(nCnt - 1)
        'For i As Integer = 0 To nCnt - 1
        '    m_MeasPointInfo.MeasPoint(i).X = dXpos(i)
        '    m_MeasPointInfo.MeasPoint(i).Y = dYpos(i)
        'Next

        Return True
    End Function


    Private Sub SetValueToUI()

        UcDispTarget_PanelModuel1.DrawPoints(m_MeasPointInfo.MeasPoint)
        tbMarginX.Text = m_MeasPointInfo.marginFromAlignMark.X
        tbMarginY.Text = m_MeasPointInfo.marginFromAlignMark.Y
    End Sub

    Public Function LoadWindowEnv() As Boolean

        Dim sFileTitle As String = "User Environment Setting Information"
        Dim sVersion As String = "1.0.0"

        Dim sTemp As String

        If File.Exists(g_sFilePath_UserSettings) = False Then
            Return False
        End If

        Dim Loader As New CUserSettingsINI(g_sFilePath_UserSettings)

        'Load File Infos
        sTemp = Loader.LoadIniValue(CUserSettingsINI.eSecID._FileInfo, 0, CUserSettingsINI.eKeyID._FileTitle)
        If sTemp <> sFileTitle Then Return False
        sTemp = Loader.LoadIniValue(CUserSettingsINI.eSecID._FileInfo, 0, CUserSettingsINI.eKeyID._FileVersion)
        If sTemp <> sVersion Then Return False

        m_MeasureImagePath = Loader.LoadIniValue(CUserSettingsINI.eSecID._MeasPtSetWind, 0, CUserSettingsINI.eKeyID._MeasPtSetWind_BackGraoundImagePath)
        Try
            m_Color1 = Color.FromArgb(Loader.LoadIniValue(CUserSettingsINI.eSecID._MeasPtSetWind, 0, CUserSettingsINI.eKeyID._MeasPtSetWind_Color1))
            m_color2 = Color.FromArgb(Loader.LoadIniValue(CUserSettingsINI.eSecID._MeasPtSetWind, 0, CUserSettingsINI.eKeyID._MeasPtSetWind_Color2))
        Catch ex As Exception
            Return False
        End Try
        

        Return True
    End Function

    Public Sub SaveWindowEnv()


        'Dim file As New CMcFile
        Dim fileInfo As CMcFile.sFILENAME = Nothing
        Dim sFileTitle As String = "User Environment Setting Information"
        Dim sVersion As String = "1.0.0"

        If Directory.Exists(g_sPATH_CONFIG) = False Then
            Directory.CreateDirectory(g_sPATH_CONFIG)
        End If

        If File.Exists(g_sFilePath_UserSettings) = True Then
            File.Delete(g_sFilePath_UserSettings)
        End If

        Dim saver As New CUserSettingsINI(g_sFilePath_UserSettings)

        'Save File Infos
        saver.SaveIniValue(CUserSettingsINI.eSecID._FileInfo, 0, CUserSettingsINI.eKeyID._FileTitle, sFileTitle)
        saver.SaveIniValue(CUserSettingsINI.eSecID._FileInfo, 0, CUserSettingsINI.eKeyID._FileVersion, sVersion)

        saver.SaveIniValue(CUserSettingsINI.eSecID._MeasPtSetWind, 0, CUserSettingsINI.eKeyID._MeasPtSetWind_BackGraoundImagePath, m_MeasureImagePath)
        saver.SaveIniValue(CUserSettingsINI.eSecID._MeasPtSetWind, 0, CUserSettingsINI.eKeyID._MeasPtSetWind_Color1, m_Color1.ToArgb)
        saver.SaveIniValue(CUserSettingsINI.eSecID._MeasPtSetWind, 0, CUserSettingsINI.eKeyID._MeasPtSetWind_Color2, m_color2.ToArgb)

    End Sub


#End Region

#Region "Event Functions"

    Private Sub init()
        spcMain.Dock = DockStyle.Fill

        gbPosition.Location = New System.Drawing.Point(gbPosition.Margin.Left, gbPosition.Margin.Top)

        gbPointList.Location = New System.Drawing.Point(gbPointList.Margin.Left, gbPosition.Height + gbPosition.Margin.Bottom + 2)
        gbMargin.Location = New System.Drawing.Point(gbMargin.Left, gbPosition.Height + gbPointList.Height + gbPointList.Margin.Bottom + gbPosition.Margin.Bottom + 2)

        spcMain.SplitterDistance = spcMain.Size.Width - gbPointList.Size.Width - gbPointList.Margin.Left - gbPointList.Margin.Right - 6


    End Sub

    Private Sub ucDispPointSetting_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        UcDispListView1.ClearAllData()
        SetValueToUI()

        spcMain.SplitterDistance = spcMain.Size.Width - gbPointList.Size.Width - gbPointList.Margin.Left - gbPointList.Margin.Right - 6


        AdjDispTarget()
    End Sub


    Private Sub ucDispPointSetting_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        UcDispListView1.ClearAllData()

        SetValueToUI()

        If LoadWindowEnv() = True Then

            If File.Exists(m_MeasureImagePath) = False Then
                UcDispTarget_PanelModuel1.MeasureImage = Nothing
            Else
                UcDispTarget_PanelModuel1.MeasureImage = Image.FromFile(m_MeasureImagePath)
            End If

            tsBtnPointColor1.Image = CreateSingleColorBitmapImg(30, 30, m_Color1)
            tsBtnPointColor2.Image = CreateSingleColorBitmapImg(30, 30, m_color2)
            m_SelectedColor = m_Color1
            tsBtnPointColor1.Checked = True
            tsBtnPointColor2.Checked = False
        Else
            tsBtnPointColor1.Image = CreateSingleColorBitmapImg(30, 30, Color.Black)
            tsBtnPointColor2.Image = CreateSingleColorBitmapImg(30, 30, Color.White)
            m_SelectedColor = m_Color1
            tsBtnPointColor1.Checked = True
            tsBtnPointColor2.Checked = False
        End If

        UcDispTarget_PanelModuel1.PointColor = m_SelectedColor



        Me.Update()
    End Sub


    Private Sub UcDispTarget_PanelModuel1_evSavePoint(ByVal pt As ucDispPointSetting.sPoint) Handles UcDispTarget_PanelModuel1.evSavePoint

        Dim nrow As Integer
        UcDispListView1.GetNumOfRowData(nrow)
        If nrow = 10 Then
            UcDispTarget_PanelModuel1.PbDisplay_Del(pt)
            MsgBox("더이상 포인트를 추가할 수 없습니다. 최대 10개까지 입력 가능합니다.")
            Exit Sub
        End If

        If m_MeasPointInfo.MeasPoint Is Nothing Then
            ReDim m_MeasPointInfo.MeasPoint(0)
            m_MeasPointInfo.MeasPoint(0) = pt
        Else
            Dim nCnt As Integer = m_MeasPointInfo.MeasPoint.Length
            ReDim Preserve m_MeasPointInfo.MeasPoint(nCnt)
            m_MeasPointInfo.MeasPoint(nCnt) = pt
        End If

        Dim sData(1) As String
        sData(0) = Format(pt.X, "0.0")
        sData(1) = Format(pt.Y, "0.0")
        UcDispListView1.AddRowData_AutoCountListNo(sData)

        ' Dim DataPoint(0) As ucDispPointSetting.sPoint


        'DataPoint(0) = pt
        'If m_MeasPointInfo.MeasPoint Is Nothing Then
        '    m_MeasPointInfo.MeasPoint = DataPoint
        '    Exit Sub
        'End If


        'Dim n As Integer = m_MeasPointInfo.MeasPoint.Length
        'Dim TargetPoint(n) As ucDispPointSetting.sPoint

        'For i As Integer = 0 To n
        '    If i = n Then
        '        TargetPoint(i) = pt
        '    Else
        '        TargetPoint(i) = m_MeasPointInfo.MeasPoint(i)
        '    End If
        'Next

        'm_MeasPointInfo.MeasPoint = TargetPoint
    End Sub

    Private Sub UcDispTarget_PanelModuel1_evSetPoint(ByVal pt As sPoint) Handles UcDispTarget_PanelModuel1.evSetPoint
        Dim sData(1) As String

        sData(0) = Format(pt.X, "0.0")
        sData(1) = Format(pt.Y, "0.0")
        UcDispListView1.AddRowData_AutoCountListNo(sData)
    End Sub

    Private Sub tsBtnShortCut_P1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnShortCut_P1.Click
        UcDispListView1.ClearAllData()
        m_MeasPointInfo.MeasPoint = Nothing

        Dim TargetPoint() As sPoint = Nothing
        UcDispTarget_PanelModuel1.DrawRatio(1, 1, TargetPoint)

    End Sub

    Private Sub tsBtnShortCut_P2by2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnShortCut_P2by2.Click
        UcDispListView1.ClearAllData()
        m_MeasPointInfo.MeasPoint = Nothing

        Dim TargetPoint() As sPoint = Nothing
        UcDispTarget_PanelModuel1.DrawRatio(2, 2, TargetPoint)
    End Sub

    Private Sub tsBtnShortCut_P3by3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnShortCut_P3by3.Click
        UcDispListView1.ClearAllData()
        m_MeasPointInfo.MeasPoint = Nothing

        Dim TargetPoint() As sPoint = Nothing
        UcDispTarget_PanelModuel1.DrawRatio(3, 3, TargetPoint)
    End Sub

    Private Sub tsBtnShortCut_P3by4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnShortCut_P3by4.Click
        UcDispListView1.ClearAllData()
        m_MeasPointInfo.MeasPoint = Nothing

        Dim TargetPoint() As sPoint = Nothing
        UcDispTarget_PanelModuel1.DrawRatio(3, 4, TargetPoint)
    End Sub

    Private Sub tsBtnShortCut_P5by5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnShortCut_P5by5.Click
        UcDispListView1.ClearAllData()
        m_MeasPointInfo.MeasPoint = Nothing

        Dim TargetPoint() As sPoint = Nothing
        UcDispTarget_PanelModuel1.DrawRatio(5, 5, TargetPoint)
    End Sub


    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        UcDispListView1.ListUP()
        Dim nAllRow As Integer
        Dim sData() As String = Nothing
        nAllRow = UcDispListView1.GetListItemCount

        ReDim Preserve m_MeasPointInfo.MeasPoint(nAllRow - 1)
        For i As Integer = 0 To nAllRow - 1
            UcDispListView1.GetRowData(i, sData)
            m_MeasPointInfo.MeasPoint(i).X = sData(0)
            m_MeasPointInfo.MeasPoint(i).Y = sData(1)
        Next
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        UcDispListView1.ListDOWN()
        Dim nAllRow As Integer
        Dim sData() As String = Nothing
        nAllRow = UcDispListView1.GetListItemCount

        ReDim Preserve m_MeasPointInfo.MeasPoint(nAllRow - 1)
        For i As Integer = 0 To nAllRow - 1
            UcDispListView1.GetRowData(i, sData)
            m_MeasPointInfo.MeasPoint(i).X = sData(0)
            m_MeasPointInfo.MeasPoint(i).Y = sData(1)
        Next
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim nSelectedListNo, nSelectedListNo1 As Integer
        Dim eListErrCode As ucDispListView.eUcListErrCode

        eListErrCode = UcDispListView1.GetSelectedRowNumber(nSelectedListNo)

        If eListErrCode = ucDispListView.eUcListErrCode.eNothingData Then
            Exit Sub
        End If

        UcDispListView1.GetSelectedRowNumber(nSelectedListNo1)
        UcDispListView1.DelSelectedRow(nSelectedListNo)

        Dim TargetDraw As sPoint
        TargetDraw = m_MeasPointInfo.MeasPoint(nSelectedListNo)
        UcDispTarget_PanelModuel1.PbDisplay_Del(TargetDraw)


        Dim nPtLength As Integer
        Dim j As Integer = 0
        Dim TargetPoint() As sPoint
        nPtLength = m_MeasPointInfo.MeasPoint.Length

        If nPtLength - 2 < 0 Then
            ReDim TargetPoint(0)
        Else
            ReDim TargetPoint(nPtLength - 2)
        End If

        If nPtLength - 2 < 0 Then
            m_MeasPointInfo.MeasPoint = Nothing
            Exit Sub
        End If

        For i As Integer = 0 To nPtLength - 2
            If i = nSelectedListNo Then
                j = j + 1
                If j <= nPtLength - 1 Then
                    TargetPoint(i) = m_MeasPointInfo.MeasPoint(j)
                End If
            Else
                If j <= nPtLength - 1 Then
                    TargetPoint(i) = m_MeasPointInfo.MeasPoint(j)
                End If
            End If
            j = j + 1
        Next

        m_MeasPointInfo.MeasPoint = TargetPoint
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        UcDispListView1.ClearAllData()
        UcDispTarget_PanelModuel1.PbDisplay_Clear()
        m_MeasPointInfo.MeasPoint = Nothing
    End Sub

#End Region

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        Dim fileDlg As New CMcFile
        Dim fileInfo As CMcFile.sFILENAME = Nothing

        If fileDlg.GetLoadFileName(CMcFile.eFileType._BMP, g_sPATH_PG_IMAGE, fileInfo) = True Then
            m_MeasureImagePath = fileInfo.strPathAndFName

            UcDispTarget_PanelModuel1.MeasureImage = Image.FromFile(fileInfo.strPathAndFName)
        End If
    End Sub


    Private Sub ToolStripColorPicker2_SelectedColorChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripColorPicker2.SelectedColorChanged

        ' If tsBtnPointColor1.Checked = True Then
        Dim image As Bitmap = CreateSingleColorBitmapImg(30, 30, ToolStripColorPicker2.Color)
        'Dim g As System.Drawing.Graphics = Graphics.FromImage(image) '= New System.Drawing.Graphics
        'Dim pencel As System.Drawing.Pen = New System.Drawing.Pen(ToolStripColorPicker2.Color)
        'Dim rect As System.Drawing.Rectangle = New System.Drawing.Rectangle(0, 0, 50, 50)
        'g.DrawRectangle(pencel, rect)
        'image = New Bitmap(50, 50, g)

        'image = New Bitmap(30, 30)

        'For x As Integer = 0 To image.Size.Width - 1
        '    For y As Integer = 0 To image.Size.Height - 1
        '        image.SetPixel(x, y, ToolStripColorPicker2.Color)
        '    Next
        'Next

        If tsBtnPointColor1.Checked = True Then
            tsBtnPointColor1.Image = image
            m_Color1 = ToolStripColorPicker2.Color
            m_SelectedColor = m_Color1
        ElseIf tsBtnPointColor2.Checked = True Then
            tsBtnPointColor2.Image = image
            m_color2 = ToolStripColorPicker2.Color
            m_SelectedColor = m_color2
        End If

        UcDispTarget_PanelModuel1.PointColor = m_SelectedColor

    End Sub

    Private Function CreateSingleColorBitmapImg(ByVal imgSize_width As Integer, ByVal imgSize_height As Integer, ByVal colorInfo As System.Drawing.Color) As System.Drawing.Bitmap
        Dim image As Bitmap = New Bitmap(imgSize_width, imgSize_height)

        For x As Integer = 0 To image.Size.Width - 1
            For y As Integer = 0 To image.Size.Height - 1
                image.SetPixel(x, y, colorInfo)
            Next
        Next

        Return image
    End Function


    Private Sub tsBtnPointColor1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnPointColor1.Click
        tsBtnPointColor1.Checked = True
        tsBtnPointColor2.Checked = False

        m_SelectedColor = m_Color1

        UcDispTarget_PanelModuel1.PointColor = m_SelectedColor
    End Sub

    Private Sub tsBtnPointColor2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnPointColor2.Click
        tsBtnPointColor1.Checked = False
        tsBtnPointColor2.Checked = True

        m_SelectedColor = m_color2

        UcDispTarget_PanelModuel1.PointColor = m_SelectedColor
    End Sub



    Private Sub AdjDispTarget()
        Dim dispArea As Size = New System.Drawing.Size(spcMain.SplitterDistance - 3, spcMain.Size.Height - 3)
        Dim targetSize As ucSampleInfos.sSampleSize = UcDispTarget_PanelModuel1.TargetSize  'real size(mm)

        If targetSize.Height > targetSize.Width Then  '세로 형태

            Dim ratio As Double = targetSize.Width / targetSize.Height

            UcDispTarget_PanelModuel1.Size = New System.Drawing.Size(dispArea.Height * ratio, dispArea.Height)
        ElseIf targetSize.Height < targetSize.Width Then  '가로 형태
            Dim ratio As Double = targetSize.Height / targetSize.Width
            UcDispTarget_PanelModuel1.Size = New System.Drawing.Size(dispArea.Width, dispArea.Width * ratio)
        Else
            UcDispTarget_PanelModuel1.Size = New System.Drawing.Size(dispArea.Height, dispArea.Height)
        End If

        UcDispTarget_PanelModuel1.Location = New System.Drawing.Point((dispArea.Width / 2) - (UcDispTarget_PanelModuel1.Size.Width / 2), (dispArea.Height / 2) - (UcDispTarget_PanelModuel1.Size.Height / 2))
    End Sub



    Private Sub btnPosAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPosAdd.Click
        Dim Target As sPoint
        Dim sampleSize As ucSampleInfos.sSampleSize = UcDispTarget_PanelModuel1.TargetSize

        Dim nRow As Integer
        UcDispListView1.GetNumOfRowData(nRow)
        If nRow = 10 Then
            MsgBox("더이상 포인트를 추가할 수 없습니다. 최대 10개까지 입력 가능합니다.")
            Exit Sub
        End If

        Try
            Target.X = Format(CDbl(tbInput_XPos.Text), "0.000")
        Catch ex As Exception
            MsgBox("입력 값을 확인하여 주십시오.")
            Exit Sub
        End Try


        If sampleSize.Width < Target.X Then
            MsgBox("측정 위치 설정 값은 샘플의 발광면의 크기보다 클수 없습니다. 입력 값을 확인하여 주십시오.")
            Exit Sub
        End If

        Try
            Target.Y = Format(CDbl(tbInput_YPos.Text), "0.000")
        Catch ex As Exception
            MsgBox("입력 값을 확인하여 주십시오.")
            Exit Sub
        End Try

        If sampleSize.Height < Target.Y Then
            MsgBox("측정 위치 설정 값은 샘플의 발광면의 크기보다 클수 없습니다. 입력 값을 확인하여 주십시오.")
            Exit Sub
        End If

        Target.ptColor = m_SelectedColor

        UcDispTarget_PanelModuel1.PointToDrawPaint(Target)

    End Sub
End Class

