Imports System.IO
Imports System.Threading

Public Class UcDispPGImageManager


#Region "Define"

    Dim m_PGImageInfos As ucDispPGImageSweep.sPGImageInfos
    Public m_ImageData As sImageManager
    Dim m_nCntImage As Integer
    Dim m_ListRowIndex As Integer

#End Region

    Public pDisplayImage As Image

    Public Structure sImageManager
        Dim fImageSync As Boolean
        Dim ImageItem() As sImageListItem
        Dim ImageCnt As Integer
    End Structure

    Public Structure sImageListItem
        Dim ImageIndex As String
        Dim sImageName As String
        Dim sPathImageFile As String
    End Structure


#Region "Property"

    Public Property Settings() As sImageManager
        Get
            LoadConfiguration(m_ImageData) '      'GetValuetoGridView()
            Return m_ImageData
        End Get
        Set(ByVal value As sImageManager)
            'm_ImageData = value

            'If m_ImageData Is Nothing = False Then
            '    ReDim m_ImageData(m_DeviceNo - 1)
            '    UpdateList()
            'End If
        End Set
    End Property

   
#End Region


#Region "Creator"
    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Private Sub init()  
        cboImageIndex.Items.Clear()
        ucDispDataGrid.ClearRow()

        For idx As Integer = 0 To 40 - 1
            cboImageIndex.Items.Add(idx)
        Next

    End Sub

#End Region

    Public Sub FlushImage()
        pbImageView.Image = Nothing

        If pDisplayImage Is Nothing = False Then
            pDisplayImage.Dispose()
        End If

        If m_ImageData.ImageItem Is Nothing = False Then
            For idx As Integer = 0 To m_ImageData.ImageItem.Length - 1
                Image.FromFile(m_ImageData.ImageItem(idx).sPathImageFile).Dispose()
            Next
        End If
    End Sub

    Public Sub ClearData()
        m_ImageData = Nothing
        m_nCntImage = 0
        UpdateList()
    End Sub

    Public Sub DelData(ByVal nSelRow As Integer)
        Try
            Dim tempData As sImageManager
            Dim nCnt As Integer

            ReDim tempData.ImageItem(m_ImageData.ImageItem.Length - 2)

            For i As Integer = 0 To m_ImageData.ImageItem.Length - 1
                If i <> nSelRow Then
                    tempData.ImageItem(nCnt) = m_ImageData.ImageItem(i)
                    nCnt += 1
                End If
            Next

            m_ImageData.ImageItem = tempData.ImageItem.Clone
            m_ImageData.ImageCnt = m_ImageData.ImageItem.Length
            m_nCntImage -= 1

            UpdateList()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub AddData(ByVal bufData As sImageListItem)

        If m_nCntImage < 0 Then m_nCntImage = 0 '카운터 에러 방지

        If m_nCntImage >= 40 Then
            MsgBox("Image Count Limit. (40)")
            Exit Sub
        End If

        ReDim Preserve m_ImageData.ImageItem(m_nCntImage)         '고정으로 배열 40개를 만든 후 데이터를 저장함.
        m_ImageData.ImageItem(m_nCntImage) = bufData
        AddList(m_ImageData.ImageItem(m_nCntImage))
        m_nCntImage += 1

        m_ImageData.ImageCnt = m_ImageData.ImageItem.Length                  '데이터를 저장할 때마다 nLenSignal의 개수가 증가

    End Sub

    Public Sub UpdateList()
        ucDispDataGrid.ClearRow()
        If m_ImageData.ImageItem Is Nothing Then Exit Sub
        For i As Integer = 0 To m_ImageData.ImageItem.Length - 1
            AddList(m_ImageData.ImageItem(i))
        Next
    End Sub

    Public Sub AddList(ByVal Param As sImageListItem)    '
        Dim sData(2) As String

        sData(0) = Param.ImageIndex
        sData(1) = Param.sImageName
        sData(2) = Param.sPathImageFile

        ucDispDataGrid.AddRowData(sData)
    End Sub

    Public Sub ModifyData(ByVal bufData As sImageListItem)
        Dim nSelRow As Integer = ucDispDataGrid.SelectedRowNum
        m_ImageData.ImageItem(nSelRow) = bufData
        ModifyList(m_ImageData.ImageItem(nSelRow))
    End Sub
    Public Sub ModifyList(ByVal Param As sImageListItem)    '
        Dim sData(2) As String
        '  Dim listindex As Integer

        sData(0) = Param.ImageIndex.ToString
        sData(1) = Param.sImageName.ToString
        sData(2) = Param.sPathImageFile.ToString

        'listindex = m_Param.eSignalName
        ucDispDataGrid.AddModifyData(sData)  'm_traData.nLenSignal - 1

    End Sub

    Public Sub EditValue(ByVal bufdata() As Object)
        ucDispDataGrid.GetRowData(ucDispDataGrid.SelectedRowNum, bufdata)
    End Sub


    Public Sub SetValuetoGridView()
        For i As Integer = 0 To m_ImageData.ImageItem.Length - 1
            ucDispDataGrid.DataGridView.Rows(i).Cells(0).Value = m_ImageData.ImageItem(i).ImageIndex.ToString
            ucDispDataGrid.DataGridView.Rows(i).Cells(1).Value = m_ImageData.ImageItem(i).sImageName.ToString
            ucDispDataGrid.DataGridView.Rows(i).Cells(2).Value = m_ImageData.ImageItem(i).sPathImageFile.ToString
        Next
    End Sub

    Public Sub GetValuetoGridView()
        If m_ImageData.ImageCnt <> 0 Then
            For i As Integer = 0 To m_ImageData.ImageItem.Length - 1
                m_ImageData.ImageItem(i).ImageIndex = ucDispDataGrid.DataGridView.Rows(i).Cells(0).Value
                m_ImageData.ImageItem(i).sImageName = ucDispDataGrid.DataGridView.Rows(i).Cells(1).Value
                m_ImageData.ImageItem(i).sPathImageFile = ucDispDataGrid.DataGridView.Rows(i).Cells(2).Value
            Next
        End If
    End Sub

    Private Sub ucDispDataGrid_evEditData() Handles ucDispDataGrid.evEditData
        Dim BufData() As Object = Nothing

        If m_ImageData.ImageItem Is Nothing Then
            Exit Sub
        End If
        EditValue(BufData)
    End Sub

    Private Sub UcDataGridView1_evShowUI() Handles ucDispDataGrid.evShowUI
        If m_ImageData.ImageItem Is Nothing Then
            Exit Sub
        Else
            If m_ImageData.ImageCnt > ucDispDataGrid.SelectedRowNum Then
                ShowValueToUI(m_ImageData.ImageItem(ucDispDataGrid.SelectedRowNum))
            End If
        End If

    End Sub


    Public Sub ShowValueToUI(ByVal bufdata As sImageListItem)
        If pDisplayImage Is Nothing = False Then
            pDisplayImage.Dispose()
        End If
        pbImageView.Image = Nothing

        If bufdata.ImageIndex <> "" Then
            cboImageIndex.SelectedIndex = bufdata.ImageIndex

            If bufdata.sPathImageFile <> Nothing Then
                'pbImageView.Image = Image.FromFile(bufdata.sPathImageFile)
                'Dim aa As FileStream = New FileStream(bufdata.sPathImageFile, FileMode.Open, FileAccess.Read)
                pDisplayImage = Image.FromFile(bufdata.sPathImageFile)
                pbImageView.Image = pDisplayImage

                cboImageIndex.SelectedIndex = bufdata.ImageIndex
                tbImageName.Text = bufdata.sImageName
                tbImagePath.Text = bufdata.sPathImageFile
            End If
        End If

    End Sub

    Public Function GetValueFromUI(ByRef param As sImageListItem) As Boolean
        With param

            If cboImageIndex.SelectedIndex < 0 Or tbImageName.Text = "" Or tbImagePath.Text = "" Then
                MsgBox("Image Add Before Open Image")
                Return False
            Else
                .ImageIndex = cboImageIndex.SelectedIndex
                .sImageName = Format(CInt(.ImageIndex), "00") & "_" & tbImageName.Text
                .sPathImageFile = tbImagePath.Text
            End If
        End With

        Return True
    End Function


    Private Sub btnAddImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddImage.Click
        Dim param As sImageListItem = Nothing
        If GetValueFromUI(param) = False Then Exit Sub
        AddData(param)
    End Sub

    Private Sub btnDelImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelImage.Click
        Dim nSelRow As Integer = ucDispDataGrid.SelectedRowNum
        DelData(nSelRow)
    End Sub

    Private Sub btnClearImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearImage.Click
        ClearData()
    End Sub

    Private Sub btnChangeImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeImage.Click
        Dim param As sImageListItem = Nothing
        If GetValueFromUI(param) = False Then Exit Sub
        ModifyData(param)
    End Sub

    Private Sub chkImageSync_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkImageSync.CheckedChanged
        If chkImageSync.Checked = True Then
            m_ImageData.fImageSync = True
            lblBtnHighlight.BackColor = Color.SpringGreen
        ElseIf chkImageSync.Checked = False Then
            m_ImageData.fImageSync = False
            lblBtnHighlight.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub btnImageOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImageOpen.Click
        Dim FOpendlg As New CMcFile
        Dim fileNameInfo As CMcFile.sFILENAME = Nothing

        If FOpendlg.GetLoadFileName(CMcFile.eFileType._BMP, g_sPATH_PG_IMAGE, fileNameInfo) = True Then

            tbImagePath.Text = fileNameInfo.strPathAndFName
            tbImageName.Text = fileNameInfo.strFNameAndExt

        End If

    End Sub


    Public Function SaveConfiguration() As Boolean 'ByVal ImageInfos As sImageManager

        GetValuetoGridView()

        'Dim file As New CMcFile
        Dim fileInfo As CMcFile.sFILENAME = Nothing
        Dim sFileTitle As String = "PG Image Manager Information"
        Dim sVersion As String = "1.0.0"

        If Directory.Exists(g_sPATH_PG_IMAGE) = False Then
            Directory.CreateDirectory(g_sPATH_PG_IMAGE)
        End If

        If File.Exists(g_sFilePath_PGImage) = True Then
            File.Delete(g_sFilePath_PGImage)
        End If

        Dim ImgManagerSaver As New CPGImiageINI(g_sFilePath_PGImage)

        'Save File Infos
        ImgManagerSaver.SaveIniValue(CPGImiageINI.eSecID.eFileInfo, 0, CConfigINI.eKeyID.FileTitle, sFileTitle)
        ImgManagerSaver.SaveIniValue(CPGImiageINI.eSecID.eFileInfo, 0, CConfigINI.eKeyID.FileVersion, sVersion)

        ImgManagerSaver.SaveIniValue(CPGImiageINI.eSecID.eImageState, 0, CPGImiageINI.eKeyID.eImageCounter, m_ImageData.ImageCnt)
        ImgManagerSaver.SaveIniValue(CPGImiageINI.eSecID.eImageState, 0, CPGImiageINI.eKeyID.eImageSyncStatus, m_ImageData.fImageSync)

        For idx As Integer = 0 To m_ImageData.ImageCnt - 1
            Try
                With m_ImageData
                    ImgManagerSaver.SaveIniValue(CPGImiageINI.eSecID.eImageManagerInfo, idx, CPGImiageINI.eKeyID.eImageIndex, .ImageItem(idx).ImageIndex)
                    ImgManagerSaver.SaveIniValue(CPGImiageINI.eSecID.eImageManagerInfo, idx, CPGImiageINI.eKeyID.eImageName, .ImageItem(idx).sImageName)
                    ImgManagerSaver.SaveIniValue(CPGImiageINI.eSecID.eImageManagerInfo, idx, CPGImiageINI.eKeyID.eImagePath, .ImageItem(idx).sPathImageFile)
                End With
            Catch ex As Exception

            End Try
        Next

        ImageFileUpdata()

        Return True
    End Function

    Public Function LoadConfiguration(ByRef ImageInfos As sImageManager) As Boolean


        Dim sFileTitle As String = "PG Image Manager Information"
        Dim sVersion As String = "1.0.0"

        Dim sTemp As String

        If File.Exists(g_sFilePath_PGImage) = False Then
            Return False
        End If

        Dim ImgManagerLoader As New CPGImiageINI(g_sFilePath_PGImage)

        'Load File Infos
        sTemp = ImgManagerLoader.LoadIniValue(CConfigINI.eSecID.eFileInfo, 0, CConfigINI.eKeyID.FileTitle)
        If sTemp <> sFileTitle Then Return False
        sTemp = ImgManagerLoader.LoadIniValue(CConfigINI.eSecID.eFileInfo, 0, CConfigINI.eKeyID.FileVersion)
        If sTemp <> sVersion Then Return False


        ImageInfos.ImageCnt = ImgManagerLoader.LoadIniValue(CPGImiageINI.eSecID.eImageState, 0, CPGImiageINI.eKeyID.eImageCounter)
        ImageInfos.fImageSync = ImgManagerLoader.LoadIniValue(CPGImiageINI.eSecID.eImageState, 0, CPGImiageINI.eKeyID.eImageSyncStatus)

        ReDim ImageInfos.ImageItem(ImageInfos.ImageCnt - 1) 'ImageInfos.ImageItem(39)
        For idx As Integer = 0 To ImageInfos.ImageCnt - 1
            'For idx As Integer = 0 To 40 - 1
            Try
                With ImageInfos
                    .ImageItem(idx).ImageIndex = ImgManagerLoader.LoadIniValue(CPGImiageINI.eSecID.eImageManagerInfo, idx, CPGImiageINI.eKeyID.eImageIndex)
                    .ImageItem(idx).sImageName = ImgManagerLoader.LoadIniValue(CPGImiageINI.eSecID.eImageManagerInfo, idx, CPGImiageINI.eKeyID.eImageName)
                    .ImageItem(idx).sPathImageFile = ImgManagerLoader.LoadIniValue(CPGImiageINI.eSecID.eImageManagerInfo, idx, CPGImiageINI.eKeyID.eImagePath)
                End With

            Catch ex As Exception
                With ImageInfos
                    .ImageItem(idx).ImageIndex = 0
                    .ImageItem(idx).sImageName = ""
                    .ImageItem(idx).sPathImageFile = ""
                End With
            End Try
        Next

        Return True
    End Function

    Private Function ImageFileUpdata() As Boolean
     
        Try


            FlushImage()
           
            If My.Computer.FileSystem.DirectoryExists(g_sPATH_IMAGE_BACKUP) = True Then
                My.Computer.FileSystem.DeleteDirectory(g_sPATH_IMAGE_BACKUP, FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory(g_sPATH_IMAGE_BACKUP)
            Else
                My.Computer.FileSystem.CreateDirectory(g_sPATH_IMAGE_BACKUP)
            End If

            If My.Computer.FileSystem.DirectoryExists(g_sPATH_IMAGE_BACKUP) = True Then   '이미지 백업 폴더에 리스트의 이미지를 하나씩 복사 저장
                For idx As Integer = 0 To m_ImageData.ImageCnt - 1
                    My.Computer.FileSystem.CopyFile(m_ImageData.ImageItem(idx).sPathImageFile, g_sPATH_IMAGE_BACKUP & "\" & m_ImageData.ImageItem(idx).sImageName)
                Next
            End If

            '이미지 백업 폴더에 파일 정보 저장
            My.Computer.FileSystem.CopyFile(g_sFilePath_PGImage, g_sPATH_IMAGE_BACKUP & "\" & "ImageManager.ini")

            '이미지 Shared 폴더 지움

            If My.Computer.FileSystem.DirectoryExists(g_sPATH_PG_IMAGE) = True Then
                My.Computer.FileSystem.DeleteDirectory(g_sPATH_PG_IMAGE, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If

            Application.DoEvents()
            Thread.Sleep(100)

            '이미지 백업 폴더를 이미지 폴더로 저장

            If My.Computer.FileSystem.DirectoryExists(g_sPATH_IMAGE_BACKUP) = True Then
                My.Computer.FileSystem.CopyDirectory(g_sPATH_IMAGE_BACKUP, g_sPATH_PG_IMAGE)

                '백업 폴더 삭제
                My.Computer.FileSystem.DeleteDirectory(g_sPATH_IMAGE_BACKUP, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If

        Catch ex As Exception
            MsgBox("Close Open File.")
            Return False

        End Try

        MsgBox("Setting is Complete.")
        Return True
    End Function

    Private Sub UcDispPGImageManager_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        Dim sPath As String = g_sPATH_PG_IMAGE

        If LoadDirectoryImage(sPath) = False Then
            MsgBox("동기화 폴더의 파일에 문제가 있습니다. 동기화 작업을 다시 수행하여 주십시오.")
        End If

    End Sub


    '-----------------------------------------------------------------------

    Private Sub UcDispImageManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim sPath As String = g_sPATH_PG_IMAGE

        'If LoadDirectoryImage(sPath) = False Then
        '    MsgBox("동기화 폴더의 파일에 문제가 있습니다. 동기화 작업을 다시 수행하여 주십시오.")
        'End If

    End Sub


    Private Function LoadDirectoryImage(ByVal sPath As String) As Boolean
        Try
            Dim dirinfo As DirectoryInfo = New DirectoryInfo(sPath)
            Dim filelist As FileInfo() = dirinfo.GetFiles("*.bmp")

            'Dim images As List(Of Filmstrip.FilmstripImage) = New List(Of Filmstrip.FilmstripImage)

            If filelist.Length = 0 Or filelist Is Nothing Then
                ucDispDataGrid.ClearRow()
                m_nCntImage = 0
                Return False
            End If

            ucDispDataGrid.ClearRow()
            'ucImageList.ClearAllData()

            '...Shared/PGImage Folder에 위치한 BMP(패턴 이미지)를 로드해서 보여주어야 함.
            'If LoadConfiguration(m_ImageData) = False Then Return False 'configation은 이미지 원본 파일의 저장 경로와 파일의 수를 저장하고 있음.

            ReDim Preserve m_ImageData.ImageItem(filelist.Length - 1)

            For i As Integer = 0 To filelist.Length - 1
                Dim BuffImageName() As String = Split(filelist(i).FullName, "\", -1)
                Dim arrBuf As Array = Split(BuffImageName(BuffImageName.Length - 1), "_", -1)

                Try
                    m_ImageData.ImageItem(i).ImageIndex = arrBuf(0)
                Catch ex As Exception

                    '동기화 폴더에 저장될때의 파일명 규칙 정의 Index_ImageName.bmp --> 00_ImageName.bmp
                    'index번호가 중복 되면 안됨
                    'index가 건너 뛰어질경우, 1,2,3,5??
                    '0번 Index가 없을 경우
                    Return False
                End Try
                m_ImageData.ImageItem(i).sImageName = BuffImageName(BuffImageName.Length - 1)
                m_ImageData.ImageItem(i).sPathImageFile = filelist(i).FullName
                ' images.Add(newimageObjects)

                AddList(m_ImageData.ImageItem(i))
                'thisimage.Dispose()
                m_ImageData.ImageCnt += 1
            Next

            'chkImageSync.Checked = m_ImageData.fImageSync  ???

            m_nCntImage = m_ImageData.ImageCnt

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    'Dim SelectImage As Image
    'Public Sub ucImageList_evSelectedIndexChanged(ByVal nRow As Integer) Handles ucImageList.evSelectedIndexChanged
    '    If nRow < 0 Then
    '        Exit Sub
    '    Else
    '        Dim SelectImage As Image = Nothing

    '        ListRowIndex = nRow

    '        Dim Data() As String = Nothing
    '        ucImageList.GetRowData(ListRowIndex, Data)

    '        SelectImage = Image.FromFile(Data(1))

    '        SelectImage.Dispose()
    '    End If
    'End Sub



End Class
