Public Class CDevSpectrometerAPI
    Public WithEvents mySpectrometer As CDevSpectrometerCommonNode


    Public Event evError(ByVal errCode As Integer)


    Public Sub New(ByVal device As CDevSpectrometerCommonNode.eModel)

        Select Case device

            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_SR3AR
                mySpectrometer = New CDevSR_3AR
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_SRUL2
                mySpectrometer = New CDevSR_UL2
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_UA_10
                mySpectrometer = New CDevUA_10
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR650
                mySpectrometer = New CDevPR650
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR655
                mySpectrometer = New CDevPR655
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR670
                mySpectrometer = New CDevPR670
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR705
                mySpectrometer = New CDevPR705
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR730
                mySpectrometer = New CDevPR730
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_PR740
                mySpectrometer = New CDevPR740
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000
                mySpectrometer = New CDevCS1000
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS1000A
                mySpectrometer = New CDevCS1000A
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000
                mySpectrometer = New CDevCS2000
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_AVANTES
                mySpectrometer = New CDevAvantes
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_LABSPHERE
                mySpectrometer = New CDevLabsphere
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_DarsaPro
                mySpectrometer = New CDevDarsaPro
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_OceanOptics
            Case CDevSpectrometerCommonNode.eModel.SPECTROMETER_CS2000A
                mySpectrometer = New cDevCS2000A
                ' mySpectrometer = New CDevOceanOptics
        End Select

    End Sub

    Private Sub mySpectrometer_evError(ByVal errorCode As Integer) Handles mySpectrometer.evError
        RaiseEvent evError(errorCode)
    End Sub

End Class
