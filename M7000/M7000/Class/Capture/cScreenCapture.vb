Public Class cScreenCapture

    Public frmCaptureArea As Form = New Form

    Public captureAreaLocation As Point
    Public captureAreaSize As Size


    Private Delegate Function HideFrame() As Windows.Forms.Form

    Public Sub New()

        frmCaptureArea.Text = "Click Here and Drag"
        frmCaptureArea.FormBorderStyle = FormBorderStyle.SizableToolWindow
        frmCaptureArea.Opacity = 0.5
        frmCaptureArea.ControlBox = False

    End Sub

    Public Sub SelectArea()
        frmCaptureArea.Location = New System.Drawing.Point(captureAreaLocation.X, captureAreaLocation.Y)
        frmCaptureArea.Size = New System.Drawing.Size(captureAreaSize.Width, captureAreaSize.Height)

        frmCaptureArea.Show()
    End Sub

    Public Sub CaptureImage()
        frmCaptureArea.Hide()
        Dim area As Rectangle
        Dim capture As System.Drawing.Bitmap
        Dim graph As Graphics
        area = frmCaptureArea.Bounds
        capture = New System.Drawing.Bitmap(area.Width, area.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(capture)
        graph.CopyFromScreen(area.X, area.Y, 0, 0, area.Size, CopyPixelOperation.SourceCopy)

        Dim save As New SaveFileDialog

        Try
            save.Title = "Save File"
            save.FileName = "Screenshot"
            save.Filter = "bmp |*.bmp"
            If save.ShowDialog() = DialogResult.OK Then
                capture.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Bmp)

                'PictureBox1.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png)
            End If
        Catch ex As Exception
        End Try

        capture.Dispose()
        graph.Dispose()

      
    End Sub


    Public Sub CaptureImage(ByVal strCaptInfo As String)

        Dim area As Rectangle
        Dim capture As System.Drawing.Bitmap
        Dim graph As Graphics
        area = frmCaptureArea.Bounds
        capture = New System.Drawing.Bitmap(area.Width, area.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(capture)
        graph.CopyFromScreen(area.X, area.Y, 0, 0, area.Size, CopyPixelOperation.SourceCopy)

        Dim save As New SaveFileDialog

        'If cVision.myVisionCamera.SaveGrabImage(g_SystemOptions.sOptionData.CCDData.strCaptureCCDPath & "\" & strName & "_" & CTime.GetYMD_HMS & ".bmp") = False Then
        '    Return False
        'End If

        Try
            save.Title = "Save File"
            save.FileName = g_SystemOptions.sOptionData.CCDData.strCaptureCCDPath & "\" & strCaptInfo & ".bmp"
            save.Filter = "bmp |*.bmp"

            capture.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Bmp)

        Catch ex As Exception
        End Try

        capture.Dispose()
        graph.Dispose()

    End Sub

End Class
