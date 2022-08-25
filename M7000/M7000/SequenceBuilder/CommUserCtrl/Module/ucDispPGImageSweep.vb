Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.IO
Imports System.Windows.Forms
Imports G4SDataLibrary
Imports System.Threading

Public Class ucDispPGImageSweep


#Region "Defines"


    Friend WithEvents FilmstripControl As Filmstrip.FilmstripControl



    '=====================================================
    'only for GnT Systems Module Driver
    Dim GnTDriveData As G4SDataLibrary.CDriveData

    Dim m_sModelNames() As String = Nothing

    '==================================================

    Public Structure sImageListItem
        'Dim myImage As Image   '이미지는 없어도 될것 같음, 경로만 가지고 있어도 될 듯
        Dim bIsSelected As Boolean
        Dim sImageName As String
        Dim sPathImageFile As String
        Dim sDelayTime As Integer
    End Structure

    Public Structure sPGImageInfos
        Dim numOfImage As Integer
        Dim modelName As String
        Dim nACFImageIdx As Integer
        Dim bEnableModelDownload As Boolean
        Dim measImage() As sImageListItem '배열은 40개로 초기화 될 것이며, measImage() 배열중 1개의 이미지에 해당하는 배열값의 isSelected 변수가 True로 설정, 나머지는 False 로 설정될 것임.
        Dim SlideImage() As sImageListItem '배열은 40 개로 초기화 될것이며, 슬라이드 시킬 이미지를에 해당하는 배열의 isSelected 변수를 True로 설정
        Dim BurnInImage() As sImageListItem
    End Structure

    Dim m_PGImageInfos As sPGImageInfos
    Dim m_MeasImage() As sImageListItem
    Dim m_BurnInimage() As sImageListItem
    Dim m_SweepImage() As sImageListItem
    Dim sPath_PGImage As String  ' g_sPATH_SHARED_DATA & "PGImage\"
    Dim m_ViewMode As eViewMode = eViewMode._Lifetime_G4S
    Dim m_ChannelNo As Integer = 0


    Public Enum eViewMode
        _Lifetime_G4S
        _ImageSweep
        _ImageSticking
    End Enum

#End Region

#Region "Creator and Init"

    Public Sub New(ByVal imagePath As String)
        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        sPath_PGImage = imagePath

        init()
    End Sub

    Public Sub init()
        'pbPreview.Location = New System.Drawing.Point(0, 0)
        'pbPreview.Dock = DockStyle.Fill
        'txtPath.Text = Application.StartupPath & "\SamplePictures" '"C:\Users\Public\Pictures\SamplePictures"
        'sPath_PGImage = txtPath.Text


        If g_ConfigInfos.PGConfig.nDeviceType = CDevPGCommonNode.eDevModel._G4S Then
            GnTDriveData = New G4SDataLibrary.CDriveData(Application.StartupPath & "\G5")
        End If

        Try
            If Directory.Exists(sPath_PGImage) = False Then
                Directory.CreateDirectory(sPath_PGImage)
            End If

            ''Default Folder(PG에 저장된 이미지와 동기화된 이미지 정보를 저장 하는 폴더)에서 이미지를 읽어서 이미지 수 만큼 초기화
            '  LoadImage(sPath_PGImage)
        Catch ex As Exception

        End Try

        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer2.Dock = DockStyle.Fill
        SplitContainer3.Dock = DockStyle.Fill

        gbSettings.Dock = DockStyle.Fill

        gbModel.Dock = DockStyle.Fill

        'm_PGImageInfos.measImage = m_MeasImage.Clone
        'm_PGImageInfos.SlideImage = m_SweepImageList.Clone

        tlpMain.Location = New System.Drawing.Point(0, 0)
        tlpMain.Dock = DockStyle.Fill

        gbMeasurementImage.Location = New System.Drawing.Point(0, 0)
        gbMeasurementImage.Dock = DockStyle.Fill

        gbBurnInImage.Location = New System.Drawing.Point(0, 0)
        gbBurnInImage.Dock = DockStyle.Fill

        gbAgingImage.Location = New System.Drawing.Point(0, 0)
        gbAgingImage.Dock = DockStyle.Fill


        gbImagePreview.Dock = DockStyle.Fill
        'pnList.Dock = DockStyle.Fill
        'pnPreview.Dock = DockStyle.Fill
        ''   Me.FilmstripControl1.AutoScroll = True
        CreateFilmstripCtrl()


        pnAgingImageList.Location = New System.Drawing.Point(0, 0)
        pnAgingImageList.Dock = DockStyle.Fill

        ucMeasurementImageList.Dock = DockStyle.Fill

        pnAgingImageList.ClearRow()
        pnAgingImageList.RowLineNum = 0

        'If GnTDriveData.UpdateModelList(m_sModelNames) = False Then
        '    MsgBox("구동기 Model 정보를 찾을 수 없습니다.")
        'Else
        '    With cbSelModel
        '        .Items.Clear()
        '        .Text = ""
        '        For i As Integer = 0 To m_sModelNames.Length - 1
        '            .Items.Add(m_sModelNames(i))
        '        Next
        '        .SelectedIndex = 0
        '    End With
        'End If


        FlushImageMemory()
    End Sub


#End Region


#Region "Propertes"

    Public Property Datas() As sPGImageInfos
        Get
            GetValueFromUI()
            Return m_PGImageInfos
        End Get
        Set(ByVal value As sPGImageInfos)

            m_PGImageInfos = value
            m_PGImageInfos.measImage = value.measImage.Clone
            If value.BurnInImage Is Nothing = False Then
                m_PGImageInfos.BurnInImage = value.BurnInImage.Clone
            End If

            m_PGImageInfos.SlideImage = value.SlideImage.Clone

            m_PGImageInfos.modelName = value.modelName
            m_PGImageInfos.numOfImage = value.numOfImage

            If m_PGImageInfos.numOfImage = 0 Then Exit Property

            m_MeasImage = m_PGImageInfos.measImage.Clone

            If m_ViewMode = eViewMode._ImageSticking Then
                m_BurnInimage = m_PGImageInfos.BurnInImage.Clone
            Else
                m_SweepImage = m_PGImageInfos.SlideImage.Clone
            End If

            SetValueToUI()

        End Set
    End Property

    Public Property VisibleMode As eViewMode
        Get
            Return m_ViewMode
        End Get
        Set(ByVal value As eViewMode)
            m_ViewMode = value
            UpdateViewMode()
        End Set
    End Property

#End Region


    Public Sub CreateFilmstripCtrl()

        If FilmstripControl Is Nothing = False Then
            FilmstripControl.Dispose()
            Application.DoEvents()
            Thread.Sleep(100)
        End If

        FilmstripControl = New Filmstrip.FilmstripControl
        gbImagePreview.Controls.Add(FilmstripControl)

        FilmstripControl.BackColor = System.Drawing.SystemColors.Control
        FilmstripControl.ContextMenuStrip = Me.menuSelectImage
        FilmstripControl.ImageNavLeftLayout = System.Windows.Forms.ImageLayout.Center
        FilmstripControl.ImageNavRightLayout = System.Windows.Forms.ImageLayout.Center
        FilmstripControl.Location = New System.Drawing.Point(25, 47)
        FilmstripControl.Name = "FilmstripControl1"
        FilmstripControl.Size = New System.Drawing.Size(299, 179)
        FilmstripControl.TabIndex = 1 ''''''''''''''''''''''''''''''''''''''''''''''

        FilmstripControl.Dock = DockStyle.Fill
    End Sub


    'Dim PointThisImage As Image
    'Dim PointNewimageObj As Filmstrip.FilmstripImage

    Public Sub FlushImageMemory()


        Try
            'pnAgingImageList.ClearRow()
            'ucMeasurementImageList.ClearRow()
            'BurnInImagePic.Dispose()

            If thisimage Is Nothing = False Then
                For idx As Integer = 0 To thisimage.Length - 1
                    thisimage(idx).Dispose()
                    thisimage(idx) = Nothing
                Next
            End If

            If newimageObjects Is Nothing = False Then
                For idx As Integer = 0 To newimageObjects.Length - 1
                    'FilmstripControl1.RemoveImage(newimageObjects(idx).Id)
                    newimageObjects(idx).Image = Nothing
                Next
            End If

            If FilmstripControl.ImagesCollection Is Nothing = False Then
                '  FilmstripControl1.ImagesCollection = Nothing
            End If

            FilmstripControl.ClearSelection()
            FilmstripControl.ClearAllImages()

            Application.DoEvents()
            Thread.Sleep(100)
        Catch ex As Exception

        End Try
        'PointThisImage = thisimage.Clone
        'PointNewimageObj = newimageObjects.Clone

        'For i As Integer = 0 To m_MeasImage.Length - 1 '
        '    Image.FromFile(m_MeasImage(i).sPathImageFile).Dispose()
        'Next

        'MeasurementImagePic.Dispose()
        'MeasurementImagePic.Image = Nothing




        ' FilmstripControl1.Dispose()
        ' FilmstripControl1 = Nothing

    End Sub


#Region "Functions"

    Private Sub UpdateViewMode()

        Select Case m_ViewMode

            Case eViewMode._ImageSweep
                '   gbSingleImage.Visible = False
                '  gbMultiImage.Location = New System.Drawing.Point(0, 0)
                '  gbMultiImage.Dock = DockStyle.Fill
                menuSelectImage.Items(0).Visible = True
                menuSelectImage.Items(1).Visible = False
                menuSelectImage.Items(2).Visible = False
                menuSelectImage.Items(0).Text = "Select Image Add to Measure Image."
                gbAgingImage.Text = "Image List"

                gbMeasurementImage.Visible = False
                gbBurnInImage.Visible = False
                gbAgingImage.Visible = True

                gbSettings.Visible = True
                SplitContainer1.SplitterDistance = SplitContainer1.Size.Height - SplitContainer1.Size.Height
            Case eViewMode._Lifetime_G4S
                'Dim margin As Size
                'margin.Height = 3
                'margin.Width = 3
                'gbSingleImage.Visible = True
                'gbMultiImage.Visible = True
                'gbSingleImage.Location = New System.Drawing.Point(margin.Width, margin.Height)
                'gbMultiImage.Location = New System.Drawing.Point(gbSingleImage.Location.X, gbSingleImage.Location.Y + gbSingleImage.Size.Height + margin.Height)


                menuSelectImage.Items(0).Visible = True
                'menuSelectImage.Items(0).Text = "Select Image Add to Measure Image"
                menuSelectImage.Items(1).Visible = True
                'menuSelectImage.Items(1).Text = "Select Image Add to Slide Image List."
                menuSelectImage.Items(2).Visible = True
                'menuSelectImage.Items(2).Text = "Select Image Add to Slide Image List."


                gbAgingImage.Text = "Slide Image List"

                gbMeasurementImage.Visible = True
                gbBurnInImage.Visible = False
                gbAgingImage.Visible = True

                gbSettings.Visible = True
                SplitContainer1.SplitterDistance = SplitContainer1.Size.Height / 2 - 20
                SplitContainer2.SplitterDistance = 353
                SplitContainer3.SplitterDistance = 100

            Case eViewMode._ImageSticking

                menuSelectImage.Items(0).Visible = True
                menuSelectImage.Items(0).Text = "Select Image Add to Measure Image"
                menuSelectImage.Items(1).Visible = True
                menuSelectImage.Items(1).Text = "Select Image Add to Burn-in Image"
                menuSelectImage.Items(2).Visible = False

                gbMeasurementImage.Visible = True
                gbBurnInImage.Visible = True
                gbAgingImage.Visible = False

                gbSettings.Visible = False
                SplitContainer1.SplitterDistance = SplitContainer1.Size.Height / 2

        End Select
    End Sub

    Dim thisimage() As Image
    Dim newimageObjects() As Filmstrip.FilmstripImage

    'Public Sub LoadImage(ByVal sPath As String)
    '    Try
    '        Dim dirinfo As DirectoryInfo = New DirectoryInfo(sPath)
    '        Dim filelist As FileInfo() = dirinfo.GetFiles("*.bmp")
    '        'Dim thisimage() As Image
    '        'Dim newimageObjects() As Filmstrip.FilmstripImage

    '        Dim images As List(Of Filmstrip.FilmstripImage) = New List(Of Filmstrip.FilmstripImage)

    '        If filelist.Length = 0 Or filelist Is Nothing Then Exit Sub

    '        m_PGImageInfos.numOfImage = filelist.Length
    '        ReDim m_MeasImage(m_PGImageInfos.numOfImage - 1)
    '        ReDim m_BurnInimage(m_PGImageInfos.numOfImage - 1)
    '        ReDim m_SweepImage(m_PGImageInfos.numOfImage - 1)
    '        ReDim thisimage(m_PGImageInfos.numOfImage - 1)
    '        ReDim newimageObjects(m_PGImageInfos.numOfImage - 1)

    '        For i As Integer = 0 To filelist.Length - 1
    '            thisimage(i) = Image.FromFile(filelist(i).FullName)
    '            newimageObjects(i) = New Filmstrip.FilmstripImage(thisimage(i), filelist(i).FullName)
    '            Dim BuffImageName() As String = Split(filelist(i).FullName, "\", -1)
    '            'm_MeasImage(i).myImage = thisimage
    '            m_MeasImage(i).sImageName = BuffImageName(BuffImageName.Length - 1)
    '            m_MeasImage(i).sPathImageFile = filelist(i).FullName
    '            m_BurnInimage(i).sImageName = BuffImageName(BuffImageName.Length - 1)
    '            m_BurnInimage(i).sPathImageFile = filelist(i).FullName
    '            'm_SweepImageList(i).myImage = thisimage
    '            m_SweepImage(i).sImageName = BuffImageName(BuffImageName.Length - 1)
    '            m_SweepImage(i).sPathImageFile = filelist(i).FullName
    '            images.Add(newimageObjects(i))
    '        Next

    '        FilmstripControl1.ClearAllImages()
    '        FilmstripControl1.AddImageRange(images.ToArray)
    '        FilmstripControl1.Update()

    '        ' images = Nothing
    '    Catch ex As Exception

    '    End Try

    'End Sub



    Public Sub LoadImage(ByVal filelist() As String)
        Try
            'Dim dirinfo As DirectoryInfo = New DirectoryInfo(sPath)
            'Dim filelist As FileInfo() = dirinfo.GetFiles("*.bmp")
            'Dim thisimage() As Image
            'Dim newimageObjects() As Filmstrip.FilmstripImage

            Dim images As List(Of Filmstrip.FilmstripImage) = New List(Of Filmstrip.FilmstripImage)

            If filelist.Length = 0 Or filelist Is Nothing Then Exit Sub

            m_PGImageInfos.numOfImage = filelist.Length
            ReDim m_MeasImage(m_PGImageInfos.numOfImage - 1)
            ReDim m_BurnInimage(m_PGImageInfos.numOfImage - 1)
            ReDim m_SweepImage(m_PGImageInfos.numOfImage - 1)
            ReDim thisimage(m_PGImageInfos.numOfImage - 1)
            ReDim newimageObjects(m_PGImageInfos.numOfImage - 1)

            For i As Integer = 0 To filelist.Length - 1
                thisimage(i) = Image.FromFile(filelist(i))
                newimageObjects(i) = New Filmstrip.FilmstripImage(thisimage(i), filelist(i))
                Dim BuffImageName() As String = Split(filelist(i), "\", -1)
                'm_MeasImage(i).myImage = thisimage
                m_MeasImage(i).sImageName = BuffImageName(BuffImageName.Length - 1)
                m_MeasImage(i).sPathImageFile = filelist(i)
                m_BurnInimage(i).sImageName = BuffImageName(BuffImageName.Length - 1)
                m_BurnInimage(i).sPathImageFile = filelist(i)
                'm_SweepImageList(i).myImage = thisimage
                m_SweepImage(i).sImageName = BuffImageName(BuffImageName.Length - 1)
                m_SweepImage(i).sPathImageFile = filelist(i)
                images.Add(newimageObjects(i))
            Next

            FilmstripControl.ClearAllImages()
            FilmstripControl.AddImageRange(images.ToArray)
            FilmstripControl.Update()
            ' images = Nothing
        Catch ex As Exception

        End Try

    End Sub






    Private Sub Update_GnT_DriveData()

        If m_sModelNames Is Nothing = True Then
            MsgBox("구동기 Model 정보를 찾을 수 없습니다.")
            Exit Sub
        End If

        ' CreateFilmstripCtrl()
        FlushImageMemory()

        'FilmstripControl1.ImagesCollection = Nothing

        GnTDriveData.ModelName = m_sModelNames(cbSelModel.SelectedIndex)

        If GnTDriveData.UpdateModelInfo() = False Then
            MsgBox("구동기 Model 정보를 로드 할 수 없습니다.")
            Exit Sub
        End If

        Dim modelData As G4SDataLibrary.CDriveData.sModelTimeData = GnTDriveData.Read
        Dim scenario As G4SDataLibrary.CDriveData.GNTIBinFile = GnTDriveData.GNTIScenario
        Dim patternListData() As G4SDataLibrary.CDriveData.sPatternList

        tbPattern.Text = modelData.PatternName
        tbInitial.Text = scenario.Name

        If GnTDriveData.UpdatePatternListInfo(modelData.PatternName) = False Then
            MsgBox("Error Pattern Info")
            Exit Sub
        Else
            patternListData = GnTDriveData.PatternList1

            'patternListData 정보의 경로를 분석 해서 이미지 파일을, g_sPath_pg_image로 복사
            '복사 전에 초기화
            Try
                My.Computer.FileSystem.DeleteDirectory(sPath_PGImage, FileIO.DeleteDirectoryOption.DeleteAllContents)

                Application.DoEvents()
                Thread.Sleep(100)

                My.Computer.FileSystem.CreateDirectory(sPath_PGImage)
            Catch ex As Exception
                MsgBox("빌더 실행에 치명적인 에러가 발생하였습니다.")
            End Try

            Dim srcImgPath As String
            '     Dim destImgPath As String
            Dim filePathList(patternListData(0).Len - 1) As String
            Dim ImgIndex As Integer = 0
            For i As Integer = 0 To patternListData.Length - 1
                For n As Integer = 0 To patternListData(i).PatternItem.Length - 1
                    If patternListData(i).PatternItem(n).MainCode = 0 Then  'MainCode = 0 이면 이미지
                        srcImgPath = Application.StartupPath & "\G5\Image\" & CStr(modelData.Resolution.Width) & "_" & CStr(modelData.Resolution.Height) & "\" & patternListData(i).PatternItem(n).sImageName & ".bmp"
                    ElseIf patternListData(i).PatternItem(n).MainCode = 1 Then

                        Dim image As Bitmap = CreateBMPImage(patternListData(i).PatternItem(n).Red, patternListData(i).PatternItem(n).Green, patternListData(i).PatternItem(n).Blue)
                        srcImgPath = sPath_PGImage & "\" & Format(ImgIndex, "00") & "_" & patternListData(i).PatternItem(n).sImageName & ".bmp"

                        image.Save(srcImgPath)

                    Else
                        Dim fileName As String = CStr(patternListData(i).PatternItem(n).MainCode) & "_" & Format(patternListData(i).PatternItem(n).SubCode, "000") & ".BMP"
                        srcImgPath = Application.StartupPath & "\G4s_Internal_Pattern_Image\" & fileName
                    End If
                    '  destImgPath = g_sPATH_PG_IMAGE & "\" & Format(ImgIndex,"00") & 
                    filePathList(ImgIndex) = srcImgPath
                    ImgIndex += 1
                    If patternListData(0).Len = ImgIndex Then
                        Exit For
                    End If
                Next

                If patternListData(0).Len = ImgIndex Then
                    Exit For
                End If

            Next



            'Filmstrip에(업데이트)
            LoadImage(filePathList)

            'LoadImage(g_sPATH_PG_IMAGE)
        End If

        'If GnTDriveData.UpdatePatternImage() = False Then
        '    MsgBox("Pattern Image Update Error")
        '    Exit Sub
        'End If

        If GnTDriveData.LoadGNTIScenario() = False Then
            MsgBox("GNTI Scenario File not found")
            Exit Sub
        End If

    End Sub

    Private Sub GetValueFromUI()

        Dim bufData() As Object = Nothing

        If m_MeasImage Is Nothing Then Exit Sub


        If m_MeasImage Is Nothing = False Then
            For i As Integer = 0 To m_MeasImage.Length - 1
                m_MeasImage(i).bIsSelected = False
            Next

            For j As Integer = 0 To ucMeasurementImageList.RowLineNum - 1
                ucMeasurementImageList.GetRowData(j, bufData)
                'listData(j) = bufData.Clone
                If bufData Is Nothing = False Then
                    For i As Integer = 0 To m_MeasImage.Length - 1
                        If m_MeasImage(i).bIsSelected = False Then
                            If m_MeasImage(i).sImageName = bufData(0) Then
                                m_MeasImage(i).bIsSelected = True
                                m_MeasImage(i).sDelayTime = bufData(1)
                            Else
                                m_MeasImage(i).bIsSelected = False
                            End If
                        End If
                    Next
                End If
            Next
            m_PGImageInfos.measImage = m_MeasImage.Clone
            ' m_PGImageInfos.SlideImage = m_MeasImage.Clone
        End If

        'For i As Integer = 0 To m_MeasImage.Length - 1
        '    If m_MeasImage(i).sImageName = lblMeasurementImageName.Text Then
        '        m_MeasImage(i).bIsSelected = True
        '    Else
        '        m_MeasImage(i).bIsSelected = False
        '    End If
        'Next

        If m_BurnInimage Is Nothing = False Then
            For i As Integer = 0 To m_BurnInimage.Length - 1
                If m_BurnInimage(i).sImageName = lblBurnInImageName.Text Then
                    m_BurnInimage(i).bIsSelected = True
                Else
                    m_BurnInimage(i).bIsSelected = False
                End If
            Next
            m_PGImageInfos.BurnInImage = m_BurnInimage.Clone
        End If

        'Dim listData(pnList.RowLineNum - 1)() As String

        If m_SweepImage Is Nothing = False Then
            For i As Integer = 0 To m_SweepImage.Length - 1
                m_SweepImage(i).bIsSelected = False
            Next

            For j As Integer = 0 To pnAgingImageList.RowLineNum - 1
                pnAgingImageList.GetRowData(j, bufData)
                'listData(j) = bufData.Clone
                If bufData Is Nothing = False Then
                    For i As Integer = 0 To m_SweepImage.Length - 1
                        If m_SweepImage(i).bIsSelected = False Then
                            If m_SweepImage(i).sImageName = bufData(0) Then
                                m_SweepImage(i).bIsSelected = True
                                m_SweepImage(i).sDelayTime = bufData(1)
                            Else
                                m_SweepImage(i).bIsSelected = False
                            End If
                        End If
                    Next
                End If
            Next
            m_PGImageInfos.SlideImage = m_SweepImage.Clone
        End If

        m_PGImageInfos.numOfImage = m_PGImageInfos.SlideImage.Length


        If cbSelModel.SelectedIndex >= 0 Then
            m_PGImageInfos.modelName = m_sModelNames(cbSelModel.SelectedIndex)
        End If

        m_PGImageInfos.bEnableModelDownload = chkDownloadModel.Checked

        If tbACFImage.Text = "" Then
            MsgBox("Auto Centering용 이미지가 설정되지 않았습니다.")
            m_PGImageInfos.nACFImageIdx = 0
        End If

        m_PGImageInfos.nACFImageIdx = tbACFImage.Text

    End Sub


    Private Sub SetValueToUI()

        pnAgingImageList.ClearRow()
        ucMeasurementImageList.ClearRow()

        'MeasurementImagePic.Image = Nothing
        Dim selectedIdx As Integer = FindStringArrayIndex(m_sModelNames.Clone, m_PGImageInfos.modelName)

        If selectedIdx >= 0 Then
            cbSelModel.SelectedIndex = selectedIdx
            Application.DoEvents()
            Thread.Sleep(10)
            Update_GnT_DriveData()
            Application.DoEvents()
            Thread.Sleep(100)
        End If

        For idx As Integer = 0 To m_MeasImage.Length - 1
            If File.Exists(m_MeasImage(idx).sPathImageFile) = False Then Exit Sub
        Next

        Dim sData(1) As String

        m_MeasImage = m_PGImageInfos.measImage.Clone

        For i As Integer = 0 To m_MeasImage.Length - 1
            If m_MeasImage(i).bIsSelected = True Then
                Try
                    sData(0) = m_MeasImage(i).sImageName ' BuffData.sImageName
                    sData(1) = m_MeasImage(i).sDelayTime.ToString ' BuffData.sDelayTime.ToString

                    ucMeasurementImageList.AddRowData(sData)

                Catch ex As Exception

                End Try

            End If

        Next
        'For i As Integer = 0 To m_MeasImage.Length - 1 ' m_MeasImage.Length - 1
        '    If m_MeasImage(i).bIsSelected = True Then
        '        MeasurementImagePic.Image = Image.FromFile(m_MeasImage(i).sPathImageFile) 'm_MeasImage(i).myImage aaaaa
        '        MeasurementImagePic.SizeMode = PictureBoxSizeMode.Zoom
        '        lblMeasurementImageName.Text = m_MeasImage(i).sImageName
        '        Exit For
        '    End If
        'Next

        If m_ViewMode = eViewMode._ImageSticking Then

            m_BurnInimage = m_PGImageInfos.BurnInImage.Clone

            For i As Integer = 0 To m_BurnInimage.Length - 1
                If m_BurnInimage(i).bIsSelected = True Then
                    BurnInImagePic.Image = Image.FromFile(m_BurnInimage(i).sPathImageFile)
                    BurnInImagePic.SizeMode = PictureBoxSizeMode.Zoom
                    lblBurnInImageName.Text = m_BurnInimage(i).sImageName
                End If
            Next

        Else

            m_SweepImage = m_PGImageInfos.SlideImage.Clone

            For i As Integer = 0 To m_SweepImage.Length - 1
                If m_SweepImage(i).bIsSelected = True Then
                    Try
                        sData(0) = m_SweepImage(i).sImageName ' BuffData.sImageName
                        sData(1) = m_SweepImage(i).sDelayTime.ToString ' BuffData.sDelayTime.ToString

                        pnAgingImageList.AddRowData(sData)

                    Catch ex As Exception

                    End Try

                End If

            Next
        End If


        chkDownloadModel.Checked = m_PGImageInfos.bEnableModelDownload

        tbACFImage.Text = m_PGImageInfos.nACFImageIdx
        'MeasurementImagePic.Dispose()

    End Sub


    Public Sub SetMeasurementImage()
        'Dim ImageName() As String = Nothing

        'MeasurementImagePic.Image = FilmstripControl1.SelectedImage
        'MeasurementImagePic.SizeMode = PictureBoxSizeMode.Zoom
        'ImageName = FilmstripControl1.SelectedImageDescription.Split("\")
        'lblMeasurementImageName.Text = ImageName(ImageName.Length - 1)

        ''MeasurementImagePic.Dispose()

        Dim Buffimagename() As String = Nothing
        Dim BuffData As sImageListItem = Nothing
        Dim sData(1) As String
        Buffimagename = FilmstripControl.SelectedImageDescription.Split("\")

        If FilmstripControl.SelectedImage Is Nothing Then
            Exit Sub
        End If


        'BuffData.myImage = FilmstripControl1.SelectedImage  aaaaa
        BuffData.sImageName = Buffimagename(Buffimagename.Length - 1)
        Try
            BuffData.sDelayTime = txtDelaytime.Text
        Catch ex As Exception
            BuffData.sDelayTime = 3
        End Try


        sData(0) = BuffData.sImageName
        sData(1) = BuffData.sDelayTime.ToString

        Select Case m_ViewMode

            Case eViewMode._Lifetime_G4S
                ucMeasurementImageList.AddRowData(sData)
            Case eViewMode._ImageSweep
                pnAgingImageList.AddRowData(sData)
        End Select

    End Sub

    Public Sub SetBurnInImage()
        Dim ImageName() As String = Nothing

        BurnInImagePic.Image = FilmstripControl.SelectedImage
        BurnInImagePic.SizeMode = PictureBoxSizeMode.Zoom
        ImageName = FilmstripControl.SelectedImageDescription.Split("\")
        lblBurnInImageName.Text = ImageName(ImageName.Length - 1)
    End Sub

    Public Sub SetSweepImageList()
        Dim Buffimagename() As String = Nothing
        Dim BuffData As sImageListItem = Nothing
        Dim sData(1) As String
        Buffimagename = FilmstripControl.SelectedImageDescription.Split("\")

        If FilmstripControl.SelectedImage Is Nothing Then
            Exit Sub
        End If


        'BuffData.myImage = FilmstripControl1.SelectedImage  aaaaa
        BuffData.sImageName = Buffimagename(Buffimagename.Length - 1)
        Try
            BuffData.sDelayTime = txtDelaytime.Text
        Catch ex As Exception
            BuffData.sDelayTime = 0
        End Try


        sData(0) = BuffData.sImageName
        sData(1) = BuffData.sDelayTime.ToString

        pnAgingImageList.AddRowData(sData)


    End Sub

    Public Sub SetACImage()

        Dim Buffimagename() As String = Nothing
        Dim SelectedImgIdx As Integer
        Buffimagename = FilmstripControl.SelectedImageDescription.Split("\")

        If Buffimagename Is Nothing Then
            tbACFImage.Text = ""
            Exit Sub
        End If

        Dim selectedImageName As String = Buffimagename(Buffimagename.Length - 1)

        If selectedImageName = "" Then
            MsgBox("이미지가 선택되지 않았습니다. 클릭후 선택하세요")
            Exit Sub
        End If

        For i As Integer = 0 To m_MeasImage.Length - 1
            If m_MeasImage(i).sImageName = selectedImageName Then
                SelectedImgIdx = i
                Exit For
            End If
        Next

        m_PGImageInfos.nACFImageIdx = SelectedImgIdx
        tbACFImage.Text = SelectedImgIdx

    End Sub

    'Public Sub List_UP()

    '    Dim nrow As Integer
    '    Dim sData1() As String = Nothing
    '    Dim sData2() As String = Nothing
    '    If ucSweepImageDataGrid.DataGridView1.SelectedCells Is Nothing Then
    '        MsgBox("파일을 선택하여 주십시오.")
    '        Exit Sub

    '    ElseIf ucSweepImageDataGrid.SelectedRowNum = 0 Then
    '        MsgBox("첫번째 파일입니다.")
    '        Exit Sub

    '    End If

    '    nrow = ucSweepImageDataGrid.SelectedRowNum

    '    Data_UP(ucSweepImageDataGrid.SelectedRowNum)

    '    ucSweepImageDataGrid.GetRowData(nrow - 1, sData1)
    '    ucSweepImageDataGrid.GetRowData(nrow, sData2)

    '    ucSweepImageDataGrid.SetRowData(nrow - 1, sData2)
    '    ucSweepImageDataGrid.SetRowData(nrow, sData1)
    'End Sub

    'Public Sub List_Down()
    '    Dim nrow As Integer
    '    Dim sData1() As String = Nothing
    '    Dim sData2() As String = Nothing
    '    If ucSweepImageDataGrid.DataGridView1.SelectedCells Is Nothing Then
    '        MsgBox("파일을 선택하여 주십시오.")
    '        Exit Sub

    '    ElseIf ucSweepImageDataGrid.SelectedRowNum = m_DataNumber - 1 Then
    '        MsgBox("마지막 파일입니다.")
    '        Exit Sub

    '    End If

    '    nrow = ucSweepImageDataGrid.SelectedRowNum

    '    Data_Down(nrow)

    '    ucSweepImageDataGrid.GetRowData(nrow, sData1)
    '    ucSweepImageDataGrid.GetRowData(nrow + 1, sData2)

    '    ucSweepImageDataGrid.SetRowData(nrow, sData2)
    '    ucSweepImageDataGrid.SetRowData(nrow + 1, sData1)
    'End Sub

    'Public Sub Data_UP(ByVal nrow As Integer)
    '    Dim BuffData As sImageListItem

    '    BuffData = m_SweepImageList.sSweepImageList(nrow - 1)

    '    m_SweepImageList.sSweepImageList(nrow - 1) = m_SweepImageList.sSweepImageList(nrow)
    '    m_SweepImageList.sSweepImageList(nrow) = BuffData
    'End Sub

    'Public Sub Data_Down(ByVal nrow As Integer)
    '    Dim BuffData As sImageListItem

    '    BuffData = m_SweepImageList.sSweepImageList(nrow + 1)

    '    m_SweepImageList.sSweepImageList(nrow + 1) = m_SweepImageList.sSweepImageList(nrow)
    '    m_SweepImageList.sSweepImageList(nrow) = BuffData
    'End Sub




#End Region


#Region "Event Handler Functions"

    Private Sub tlpMain_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tlpMain.Paint

    End Sub

    Private Sub ucDispPGImageSweep_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        FlushImageMemory()
    End Sub


    Private Sub ucDispPGImageSweep_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim PGNo As Integer = 0 'frmChAllocation.GetAllocationValue(m_ChannelNo, frmChAllocation.eChAllocationItem.eDevNoOfPG)

        'txtPath.Text = g_sPATH_IMAGE_MANAGER & "Dev_" & Format(PGNo + 1, "00")
        'sPath_PGImage = txtPath.Text

        '  LoadImage(g_sPATH_PG_IMAGE)
    End Sub

    Private Sub btnFolderBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If FolderBrowserDialog.ShowDialog = DialogResult.OK Then

        '    txtPath.Text = FolderBrowserDialog.SelectedPath
        'End If
        'LoadImage(txtPath.Text)
        'txtPath.Text = g_sPATH_PG_IMAGE
        'LoadImage(txtPath.Text)

    End Sub

    Private Sub 선택된이미지를Sweep이미지로설정ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 선택된이미지를Sweep이미지로설정ToolStripMenuItem.Click
        If m_ViewMode = eViewMode._ImageSticking Then
            SetBurnInImage()
        Else
            SetSweepImageList()
        End If

    End Sub

    Private Sub 선택된이미지를측정이미지로설정ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 선택된이미지를측정이미지로설정ToolStripMenuItem.Click
        SetMeasurementImage()
    End Sub

    Private Sub 선택된이미지를AlignToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 선택된이미지를AlignToolStripMenuItem.Click
        SetACImage()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        Dim menuItem As System.Windows.Forms.ToolStripMenuItem = sender
        Dim ctxMenu As System.Windows.Forms.ContextMenuStrip = menuItem.Owner

        If ctxMenu.SourceControl.Name = "pnAgingImageList" Then
            pnAgingImageList.ClearRow()
            pnAgingImageList.RowLineNum = 0

        ElseIf ctxMenu.SourceControl.Name = "ucMeasurementImageList" Then
            ucMeasurementImageList.ClearRow()
            ucMeasurementImageList.RowLineNum = 0
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        Dim menuItem As System.Windows.Forms.ToolStripMenuItem = sender
        Dim ctxMenu As System.Windows.Forms.ContextMenuStrip = menuItem.Owner
        Dim nrow As DataGridViewRow = Nothing

        If ctxMenu.SourceControl.Name = "pnAgingImageList" Then
            nrow = pnAgingImageList.DataGridView.Rows(pnAgingImageList.SelectedRowNum)
            pnAgingImageList.DataGridView.Rows.Remove(nrow)

        ElseIf ctxMenu.SourceControl.Name = "ucMeasurementImageList" Then
            nrow = ucMeasurementImageList.DataGridView.Rows(ucMeasurementImageList.SelectedRowNum)
            ucMeasurementImageList.DataGridView.Rows.Remove(nrow)
        End If
    End Sub

    'Private Sub UpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpToolStripMenuItem.Click
    '    List_UP()

    'End Sub

    'Private Sub DownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownToolStripMenuItem.Click
    '    List_Down()

    'End Sub

    'Private Sub ucSweepImageDataGrid_evEditData() Handles ucSweepImageDataGrid.evEditData
    '    Dim BufData() As Object = Nothing

    '    If m_SweepImageList.sSweepImageList Is Nothing Then
    '        Exit Sub
    '    End If
    '    EditValue(BufData)
    'End Sub


#End Region
  
    Private Sub txtDelaytime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDelaytime.TextChanged

        Dim delayTime As Integer

        Try
            delayTime = CInt(txtDelaytime.Text)
        Catch ex As Exception
            delayTime = 3
        End Try

        If delayTime < 3 Then
            txtDelaytime.Text = "3"
        End If

    End Sub

    Private Sub cbSelModel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelModel.SelectedIndexChanged


        Update_GnT_DriveData()




    End Sub



    Private Function CreateBMPImage(ByVal red As Integer, ByVal green As Integer, ByVal blue As Integer) As Bitmap

        Dim image As New Bitmap(165, 295)

        Dim pixelColor As System.Drawing.Color = Color.FromArgb(red, green, blue)
        For X As Integer = 0 To image.Width - 1
            For Y As Integer = 0 To image.Height - 1
                image.SetPixel(X, Y, pixelColor)
            Next
        Next

        Return image
    End Function



    Private Function FindStringArrayIndex(ByVal srcArray() As String, ByVal str As String) As Integer

        Dim idx As Integer = -1

        For i As Integer = 0 To srcArray.Length - 1
            If srcArray(i) = str Then
                idx = i
                Exit For
            End If
        Next

        Return idx
    End Function
   

End Class
