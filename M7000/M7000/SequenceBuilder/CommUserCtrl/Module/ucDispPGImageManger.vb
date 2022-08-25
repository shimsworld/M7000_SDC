Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.IO
Imports System.Windows.Forms

Public Class ucDispPGImageManger


    Dim m_sPath As String
    Dim m_sSubstringDirectory As String

#Region "Creator and Init"

    Public Sub New()


        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()

        tlpMain.Location = New System.Drawing.Point(0, 0)
        tlpMain.Dock = DockStyle.Fill

        pnPreview.Location = New System.Drawing.Point(0, 0)
        pnPreview.Dock = DockStyle.Fill

        '     pbPreview.Location = New System.Drawing.Point(0, 0)
        '   pbPreview.Dock = DockStyle.Fill

        pnFolderBrowser.Location = New System.Drawing.Point(0, 0)
        pnFolderBrowser.Dock = DockStyle.Fill

        folderbrowser.Location = New System.Drawing.Point(0, 0)
        folderbrowser.Dock = DockStyle.Fill

    End Sub

#End Region

  

    Private Sub folderbrowser_evAfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles folderbrowser.evAfterSelect
        ImageLoad()
    End Sub
   
    Private Sub folderbrowser_evClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles folderbrowser.evClick
    End Sub

    Public Sub ImageLoad()
        Dim FolderPath As String
        folderbrowser.Update()
        FolderPath = folderbrowser.SelectedFile.Path
        Try
            Dim dirinfo As DirectoryInfo = New DirectoryInfo(FolderPath)
            Dim images As List(Of Filmstrip.FilmstripImage) = New List(Of Filmstrip.FilmstripImage)
            Dim filelist As FileInfo() = dirinfo.GetFiles("*.jpg")

            For Each f As FileInfo In filelist

                Dim thisimage As Image = Image.FromFile(f.FullName)
                Dim newimageObjects As Filmstrip.FilmstripImage = New Filmstrip.FilmstripImage(thisimage, f.FullName)
                images.Add(newimageObjects)
            Next

            FilmstripControl1.ClearAllImages()
            FilmstripControl1.AddImageRange(images.ToArray)
            FilmstripControl1.Update()

        Catch ex As Exception

        End Try
    End Sub
  
   
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim ImagePath As String
        ImagePath = FilmstripControl1.SelectedImageDescription
        Dim thisimage As Image = Image.FromFile(ImagePath)

        With SaveFileDialog
            .Title = "UploadFile"
            .Filter = "JEPG(*.jpg)|*.jpg|BMP(*.bmp)|*.bmp"
            .InitialDirectory = "App.path"
            .OverwritePrompt = False
            .AddExtension = True
        End With
       
        If SaveFileDialog.ShowDialog = DialogResult.OK Then
            thisimage.Save(SaveFileDialog.FileName)
        End If
    End Sub

    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click

        Dim thisimage As Image = Nothing
        Dim thisimagename() As String = Nothing
        Dim newimageObjects As Filmstrip.FilmstripImage = Nothing
        Dim images As List(Of Filmstrip.FilmstripImage) = New List(Of Filmstrip.FilmstripImage)
        Try
            If OpenFileDialog.ShowDialog = DialogResult.OK Then

                For Each filename In OpenFileDialog.FileNames
                    thisimage = Image.FromFile(filename)
                    newimageObjects = New Filmstrip.FilmstripImage(thisimage, filename)
                    images.Add(newimageObjects)

                    thisimagename = filename.Split("\")
                    thisimage.Save(folderbrowser.SelectedFile.Path & "\" & thisimagename(thisimagename.Length - 1))
                Next
                FilmstripControl1.AddImageRange(images.ToArray)
            End If
        Catch ex As Exception

        End Try


    End Sub

End Class
