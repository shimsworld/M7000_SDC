Public Class CDevVisionCameraAPI
    Public myVisionCamera As CDevVisionCameraCommonNode

    Public Sub New(ByVal device As CDevVisionCameraCommonNode.eModel, ByVal dispPanel As System.Windows.Forms.Panel, ByVal procPanel As System.Windows.Forms.Panel)

        Select Case device

            Case CDevVisionCameraCommonNode.eModel._GC1290
                myVisionCamera = New CDevGC1290(dispPanel, procPanel)
            Case CDevVisionCameraCommonNode.eModel._SVSCamera
                myVisionCamera = New CDevSVSCamera(dispPanel, procPanel)
        End Select
    End Sub
End Class
