Public Class CTime

    Public Structure sG_TIME
        Dim nHour As Integer
        Dim nMinute As Integer
        Dim nSecond As Integer
        Dim nYear As Integer
        Dim nMonth As Integer
        Dim nDay As Integer
    End Structure

    Public Structure sTimeValue
        Dim nSecound As Long
        Dim dMin As Double
        Dim dHour As Double
    End Structure

    Public Sub New()

    End Sub

    Public Shared Function GetCurrentTimeToStringType() As String
        Dim sCurrTime As sG_TIME
        Dim strTBuf As String = Nothing
        Dim arrBuf As Array = Nothing
        Dim strCurrTime As String

        With sCurrTime
            'strTBuf = Format(Now, "HH:mm:ss")
            'arrBuf = Split(strTBuf, ":", -1)
            '.nHour = CInt(arrBuf(0))
            '.nMinute = CInt(arrBuf(1))
            '.nSecond = CInt(arrBuf(2))

            'strTBuf = Format(Now, "MM/dd/yyyy")
            'arrBuf = Split(strTBuf, "-", -1)
            '.nYear = CInt(arrBuf(2))
            '.nMonth = CInt(arrBuf(0))
            '.nDay = CInt(arrBuf(1))

            .nHour = Now.Hour
            .nMinute = Now.Minute
            .nSecond = Now.Second

            .nYear = Now.Year
            .nMonth = Now.Month
            .nDay = Now.Day


            strCurrTime = Format(.nMonth, "00") & "/" & Format(.nDay, "00") & "/" & Format(.nYear, "0000") & " " & _
            Format(.nHour, "00") & ":" & Format(.nMinute, "00") & ":" & Format(.nSecond, "00")
        End With

        Return strCurrTime
    End Function

    Public Function GetTime() As sG_TIME
        Dim sCurrTime As sG_TIME
        Dim strTBuf As String
        Dim arrBuf As Array

        With sCurrTime
            strTBuf = Format(Now, "HH:mm:ss")
            arrBuf = Split(strTBuf, ":", -1)
            .nHour = CInt(arrBuf(0))
            .nMinute = CInt(arrBuf(1))
            .nSecond = CInt(arrBuf(2))

            strTBuf = Format(Now, "MM/dd/yyyy")
            arrBuf = Split(strTBuf, "-", -1)
            .nYear = CInt(arrBuf(2))
            .nMonth = CInt(arrBuf(0))
            .nDay = CInt(arrBuf(1))
        End With

        Return sCurrTime
    End Function

    Public Shared Function GetYYYYMMDD() As String
        Dim sCurrTime As sG_TIME
        Dim strCurrTime As String

        With sCurrTime
            .nYear = Now.Year
            .nMonth = Now.Month
            .nDay = Now.Day

            strCurrTime = Format(.nYear, "0000") & Format(.nMonth, "00") & Format(.nDay, "00")
        End With

        Return strCurrTime

    End Function
    Public Shared Function GetYMD() As String
        Dim sCurrTime As sG_TIME
        Dim strCurrTime As String

        With sCurrTime
            .nYear = Now.Year
            .nMonth = Now.Month
            .nDay = Now.Day

            strCurrTime = Format(.nYear, "0000") & Format(.nMonth, "00") & Format(.nDay, "00")
        End With

        Return strCurrTime

    End Function
    Public Shared Function GetYMD_HMS() As String
        Dim sCurrTime As sG_TIME
        Dim strCurrTime As String

        With sCurrTime
            .nHour = Now.Hour
            .nMinute = Now.Minute
            .nSecond = Now.Second

            .nYear = Now.Year
            .nMonth = Now.Month
            .nDay = Now.Day

            strCurrTime = Format(.nYear, "0000") & Format(.nMonth, "00") & Format(.nDay, "00") & "_" & _
            Format(.nHour, "00") & Format(.nMinute, "00") & Format(.nSecond, "00")
        End With

        Return strCurrTime

    End Function

    Public Function ConvertToDate(ByVal sTime As sG_TIME) As Date
        Dim time As String
        With sTime
            time = Format(.nMonth, "00") & "/" & Format(.nDay, "00") & "/" & Format(.nYear, "0000") & " " & _
           Format(.nHour, "00") & ":" & Format(.nMinute, "00") & ":" & Format(.nSecond, "00")
        End With
        Return Date.Parse(time)
    End Function

    Public Function ConvertToDate(ByVal sTime As String) As Date
        Return Date.Parse(sTime)
    End Function

    Public Function CalDeltaTime(ByVal startTime As Date) As TimeSpan
        Return Now.Subtract(startTime)
    End Function

    Private Function GetTime_Sec(ByVal in_PreTime As String, ByVal in_CurrentTime As String) As String

        GetTime_Sec = ""

        If in_PreTime = "" Or in_CurrentTime = "" Then
            GetTime_Sec = "0"
            Exit Function
        End If
        'modified by mocha 20081009
        Dim prevtime, current As Date
        prevtime = in_PreTime
        current = in_CurrentTime

        Dim diff As Long
        diff = DateDiff(DateInterval.Second, prevtime, current)

        GetTime_Sec = diff

        Dim timelog As String = in_PreTime + " , " + in_CurrentTime + " , " + GetTime_Sec

        Return GetTime_Sec

    End Function



#Region "시간 변환 (초 --> 시간, 분, 초 / 시간 --> 초)"

    Private Const Sec_OneHour = 3600
    Private Const Min_OneHour = 60

    ''' --------------------------------------------------------------------------------
    ''' Class.Method:	CMcTime.Convert_HourToHMS
    ''' <summary>
    ''' Convert the input time(hour) to hour,Min,sec(hh:mm:ss)
    ''' </summary>
    ''' <param name="in_dHour">
    ''' 	[Hour Value as Type Double]
    ''' 	Value Type: <see cref="Double" />	(System.Double)
    ''' </param>
    ''' <exception cref="System.ApplicationException">
    ''' 	Thrown when... 
    ''' </exception>
    ''' <returns><see cref="String" />	(System.String)</returns>
    ''' <remarks><para><pre>
    ''' RevisionHistory: 
    ''' --------------------------------------------------------------------------------
    ''' Date		Name			Description
    ''' --------------------------------------------------------------------------------
    ''' 2009-10-29	Administrator		Initial Creation
    ''' 
    ''' </pre></para>
    ''' </remarks>
    ''' --------------------------------------------------------------------------------
    Public Shared Function Convert_HourToHMS(ByVal in_dHour As Double) As String

        Dim LSec As Long
        Dim arrBuf As Array
        Dim H, M, S As Long
        LSec = Convert_HourToSec(in_dHour)

        arrBuf = Convert_SecToHMS(LSec)

        H = arrBuf(0)
        M = arrBuf(1)
        S = arrBuf(2)

        Return Format(H, "00") & ":" & Format(M, "00") & ":" & Format(S, "00")

    End Function

    Public Shared Function Convert_HourToSec(ByVal in_dHour As Double) As Long

        Dim iSec As Long

        iSec = in_dHour * 3600

        Return iSec

    End Function

    Public Shared Function Convert_HourToMin(ByVal hour As Double) As Double
        Dim min As Double
        min = hour * 60
        Return min
    End Function

    Public Shared Function Convert_SecToHMS(ByVal in_iSec As Long) As Long()

        '  Dim dBuff_Integer As Double
        Dim dBuff_Deciamal As Double
        Dim dBuff, dBuff1 As Double
        Dim lBuff_Sec As Long
        Dim H, M, S As Long

        Dim arrTime_HMS(2) As Long

        '1.초를 시간으로
        dBuff = in_iSec / Sec_OneHour
        dBuff1 = in_iSec Mod Sec_OneHour  '남은 초
        dBuff_Deciamal = dBuff1 / Sec_OneHour

        H = dBuff - dBuff_Deciamal

        ' 남은 시간을 분으로
        dBuff = dBuff_Deciamal * Min_OneHour
        lBuff_Sec = dBuff1 Mod Min_OneHour
        dBuff1 = lBuff_Sec / Min_OneHour

        M = dBuff - dBuff1

        S = lBuff_Sec

        arrTime_HMS(0) = H
        arrTime_HMS(1) = M
        arrTime_HMS(2) = S

        Return arrTime_HMS

    End Function



    Public Shared Function Convert_SecToHour(ByVal in_iSec As Long) As Double

        Dim dBuff As Double

        '1.초를 시간으로
        dBuff = in_iSec / Sec_OneHour

        Return dBuff

    End Function

    Public Shared Function Convert_SecToMin(ByVal sec As Integer) As Double
        Return sec / 60
    End Function

    Public Shared Function Convert_MinToHour(ByVal min As Integer) As Double
        Return min / 60
    End Function

    Public Shared Function Convert_MinToSec(ByVal min As Integer) As Double
        Return min * 60
    End Function

    Public Shared Function Convert_HMStoHour(ByVal in_Hour As Double, ByVal in_Min As Double, ByVal in_Sec As Double) As String

        Dim Hour As Double

        Hour = Hour + in_Hour
        Hour = Hour + (CDbl(in_Min) / 60) 'Min -> Hour
        Hour = Hour + (CDbl(in_Sec) / (60 * 60)) 'Sec -> Hour

        Return Format(Hour, "00.0000")

    End Function

    Public Shared Function Convert_HoureToTimeValue(ByVal hour As Double) As sTimeValue
        Dim sTime As sTimeValue
        sTime.dHour = hour
        sTime.dMin = Convert_HourToMin(hour)
        sTime.nSecound = Convert_HourToSec(hour)
        Return sTime
    End Function

    Public Shared Function Convert_SecToTimeValue(ByVal sec As Integer) As sTimeValue
        Dim sTime As sTimeValue
        sTime.dHour = Convert_SecToHour(sec)
        sTime.dMin = Convert_SecToMin(sec)
        sTime.nSecound = sec
        Return sTime
    End Function

    Public Shared Function Convert_MinToTimeValue(ByVal min As Double) As sTimeValue
        Dim sTime As sTimeValue
        sTime.dHour = Convert_MinToHour(min)
        sTime.dMin = min
        sTime.nSecound = Convert_MinToSec(min)
        Return sTime
    End Function
#End Region





End Class
