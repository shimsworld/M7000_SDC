Public Class CUnitTime
    Inherits CUnitCommonNode



#Region "Enums"

    Public Enum eTimeUnit
        eHour
        eMinute
        eSec
        emili_Sec
    End Enum

#End Region

#Region "Initialization"

    Public Sub New()
        MyBase.new()


    End Sub


#End Region


#Region "Time Convert"

    Public Function convertUnitTimeTomilliSec(ByVal dUnitTime As Double, ByVal nTimeUnit As eTimeUnit) As Double
        Dim timeVal_mSec As Double


        Select Case nTimeUnit
            Case eTimeUnit.emili_Sec
                timeVal_mSec = dUnitTime
            Case eTimeUnit.eSec
                timeVal_mSec = convertTimeSecTomiliSec(dUnitTime)
            Case eTimeUnit.eMinute
                timeVal_mSec = convertTimeMinuteTomiliSec(dUnitTime)
            Case eTimeUnit.eHour
                timeVal_mSec = convertTimeHourTomiliSec(dUnitTime)
        End Select
        Return timeVal_mSec
    End Function

    Public Function convertTimeHourToMinute(ByVal dHour As Double) As Double
        Dim dUnitVal As Double
        dUnitVal = dHour * 60
        Return dUnitVal
    End Function

    Public Function convertTimeHourToSec(ByVal dHour As Double) As Double
        Dim dUnitValue As Double
        dUnitValue = dHour * 3600
        Return dUnitValue
    End Function

    Public Function convertTimeHourTomiliSec(ByVal dHour As Double) As Double
        Dim dUnitVal As Double
        Dim dSec As Double
        dSec = convertTimeHourToSec(dHour)
        dUnitVal = convertTimeSecTomiliSec(dSec)
        Return dUnitVal
    End Function


    Public Function convertTimeMinuteToHour(ByVal dMinute As Double) As Double
        Dim dUnitVal As Double
        dUnitVal = dMinute / 60
        Return dUnitVal
    End Function

    Public Function convertTimeMinuteToSec(ByVal dMinute As Double) As Double
        Dim dUnitVal As Double
        dUnitVal = dMinute * 60
        Return dUnitVal
    End Function

    Public Function convertTimeMinuteTomiliSec(ByVal dMinute As Double) As Double
        Dim dUnitVal As Double
        Dim dSec As Double
        dSec = convertTimeMinuteToSec(dMinute)
        dUnitVal = convertTimeSecTomiliSec(dSec)
        Return dUnitVal
    End Function


    Public Function convertTimeSecToHour(ByVal dSec As Double) As Double
        Dim dUnitVal As Double
        dUnitVal = dSec / 3600
        Return dUnitVal
    End Function

    Public Function convertTimeSecToMinute(ByVal dSec As Double) As Double
        Dim dUnitVal As Double
        dUnitVal = dSec / 60
        Return dUnitVal
    End Function

    Public Function convertTimeSecTomiliSec(ByVal dSec As Double) As Double
        Dim dUnitVal As Double
        dUnitVal = dSec * 1000
        Return dUnitVal
    End Function

    Public Function convertTimemiliSecToHour(ByVal dmiliSec As Double) As Double
        Dim dUnitVal As Double
        Dim dSec As Double
        dSec = convertTimemiliSecToSec(dmiliSec)
        dUnitVal = dSec / 3600
        Return dUnitVal
    End Function

    Public Function convertTimemiliSecToMinute(ByVal dmiliSec As Double) As Double
        Dim dUnitVal As Double
        Dim dSec As Double
        dSec = convertTimemiliSecToSec(dmiliSec)
        dUnitVal = dSec / 60
        Return dUnitVal
    End Function

    Public Function convertTimemiliSecToSec(ByVal dmiliSec As Double) As Double
        Dim dUnitVal As Double
        dUnitVal = dmiliSec / 1000
        Return dUnitVal
    End Function

#End Region


    Public Overrides Function converter() As Double
        Return 100
    End Function


    'Public Overrides Function converter(ByVal a As Integer) As Double

    'End Function

    Public Overloads Function convertUnit(ByVal a As Double) As Double
        Return a
    End Function

End Class
