Public Class CUnitTemperature
    Inherits CUnitCommonNode

    Dim dKelvinAtZeroCelsius As Double = 273.15

#Region "Enums"

    Public Enum eTempUnit
        eCelsius
        eKelvin
    End Enum

#End Region

#Region "Initialization"

    Public Sub New(ByVal aa As Double)
        MyBase.new(aa)


    End Sub

    Public Sub New()

    End Sub

  
#End Region


#Region "Temp Unit Converter"

    Public Function convertUnitTempToCelsius(ByVal dUnitTemp As Double, ByVal nTempUnit As eTempUnit) As Double
        Dim celsiusTemp As Double
        Select Case nTempUnit
            Case eTempUnit.eCelsius
                celsiusTemp = dUnitTemp
            Case eTempUnit.eKelvin
                celsiusTemp = convertTempKelvinToCelsius(dUnitTemp)
        End Select
        Return celsiusTemp
    End Function

    Public Function convertTempCelsiusToKelvin(ByVal dCelsius As Double) As Double

        Return dCelsius + dKelvinAtZeroCelsius
    End Function

    Public Function convertTempKelvinToCelsius(ByVal dKelvin As Double) As Double
        Return dKelvin - dKelvinAtZeroCelsius
    End Function

#End Region


End Class
