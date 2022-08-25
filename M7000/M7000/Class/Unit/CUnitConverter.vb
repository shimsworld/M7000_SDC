Public Class CUnitConverter


#Region "String"

    Public m_sDefUnitCaptions() As String    '=   New String() {"V", "A", "W", "Ohm", "m^2", "CurrentDensity"}



    Public Structure sValueDisp
        Dim nTypeOfVal As CUnitConverter.eType
        Dim nUnit() As CUnitCommonNode.eMKSUnit
        Dim nDispDigit As Integer
    End Structure

    Public Enum eType
        Voltage = 0
        Ampere = 1
        Power = 2
        Resistance = 3
        Area = 4
        CurrentDensity = 5
    End Enum

#End Region


#Region "Initialization"


    Public Sub New(ByVal ntype As eType, ByVal value As Double)

        temperature = New CUnitTemperature
        time = New CUnitTime

        m_sDefUnitCaptions = GetDefUnit()

        Select Case ntype
            Case eType.Voltage
                convertor = New CunitVoltage(value, ntype)
            Case eType.Ampere
                convertor = New CUnitAmpere(value, ntype)
            Case eType.Power
                convertor = New CUnitPower(value, ntype)
            Case eType.Resistance
                convertor = New CUnitResistance(value, ntype)
            Case eType.Area
                convertor = New CUnitArea(value, ntype)
            Case eType.CurrentDensity
                convertor = New CUnitCurrentDensity(value, eType.Ampere, eType.Area)
        End Select
    End Sub

    Public Sub New()
        temperature = New CUnitTemperature
        time = New CUnitTime
    End Sub


#End Region




#Region "Children"

    Public temperature As CUnitTemperature ' = New CUnitTemperature
    Public time As CUnitTime   ' = New CUnitTime
    Public convertor As CUnitCommonNode

#End Region


    Public Shared Function GetDefUnit() As String()
        Dim sCaptions(5) As String
        sCaptions(0) = "V"
        '  {"V", "A", "W", "Ohm", "m^2", "CurrentDensity"}
        sCaptions(1) = "A"
        sCaptions(2) = "W"
        sCaptions(3) = "Ohm"
        sCaptions(4) = "m^2"
        Return sCaptions.Clone
    End Function

    Public Shared Function GetValueType() As String()
        Dim sCaptions(5) As String
        sCaptions(0) = "Voltage"
        '  {"V", "A", "W", "Ohm", "m^2", "CurrentDensity"}
        sCaptions(1) = "Current"
        sCaptions(2) = "Power"
        sCaptions(3) = "Resistance"
        sCaptions(4) = "Area"
        sCaptions(5) = "CurrentDensity"
        Return sCaptions.Clone
    End Function

    ''' <summary>
    ''' "Voltage(unit), Current(Unit), Current Density(unit), Power(unit) 등"  형태의 값을 리턴
    ''' </summary>
    ''' <param name="dispInfo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCaptionAndUnit(ByVal dispInfo As CUnitConverter.sValueDisp) As String
        Dim sUnit As String
        Dim sValueType() As String = GetValueType()
        Dim sUnitList() As String = CUnitCommonNode.GetUnitList
        Dim sDefUnitList() As String = GetDefUnit()
        If dispInfo.nTypeOfVal <> CUnitConverter.eType.CurrentDensity Then
            sUnit = sValueType(dispInfo.nTypeOfVal) & "(" & sUnitList(dispInfo.nUnit(0)) & sDefUnitList(dispInfo.nTypeOfVal) & ")"
        Else
            sUnit = sValueType(dispInfo.nTypeOfVal) & "(" & sUnitList(dispInfo.nUnit(0)) & sDefUnitList(CUnitConverter.eType.Ampere) & "/" & sUnitList(dispInfo.nUnit(1)) & sDefUnitList(CUnitConverter.eType.Area) & ")"
        End If
        Return sUnit
    End Function

    ''' <summary>
    ''' 사용자 정의 Caption 입력 가능
    ''' (ex) Caption = "Voc" 이라면 "Voc(unit)"  형태의 값을 리턴
    ''' </summary>
    ''' <param name="sCaption"></param>
    ''' <param name="dispInfo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCaptionAndUnit(ByVal sCaption As String, ByVal dispInfo As CUnitConverter.sValueDisp) As String
        Dim sUnit As String
        Dim sUnitList() As String = CUnitCommonNode.GetUnitList
        Dim sDefUnitList() As String = GetDefUnit()
        If dispInfo.nTypeOfVal <> CUnitConverter.eType.CurrentDensity Then
            sUnit = sCaption & "(" & sUnitList(dispInfo.nUnit(0)) & sDefUnitList(dispInfo.nTypeOfVal) & ")"
        Else
            sUnit = sCaption & "(" & sUnitList(dispInfo.nUnit(0)) & sDefUnitList(CUnitConverter.eType.Ampere) & "/" & sUnitList(dispInfo.nUnit(1)) & sDefUnitList(CUnitConverter.eType.Area) & ")"
        End If
        Return sUnit
    End Function

    ''' <summary>
    ''' Return Unit
    ''' ex) A, mA, uA ...
    ''' </summary>
    ''' <param name="dispInfo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetUnit(ByVal dispInfo As CUnitConverter.sValueDisp) As String
        Dim sUnit As String
        Dim sUnitList() As String = CUnitCommonNode.GetUnitList
        Dim sDefUnitList() As String = GetDefUnit()
        If dispInfo.nTypeOfVal <> CUnitConverter.eType.CurrentDensity Then
            sUnit = sUnitList(dispInfo.nUnit(0)) & sDefUnitList(dispInfo.nTypeOfVal)
        Else
            sUnit = sUnitList(dispInfo.nUnit(0)) & sDefUnitList(CUnitConverter.eType.Ampere) & "/" & sUnitList(dispInfo.nUnit(1)) & sDefUnitList(CUnitConverter.eType.Area)
        End If
        Return sUnit
    End Function

    Public Shared Function GetCaption(ByVal dispInfo As CUnitConverter.sValueDisp) As String
        Dim sCaption As String
        Dim sValueType() As String = GetValueType()
        sCaption = sValueType(dispInfo.nTypeOfVal)
        Return sCaption
    End Function


    Public Shared Sub GetCaptionAndUnit(ByVal targetLabel As System.Windows.Forms.Label, ByVal dispInfo As CUnitConverter.sValueDisp)
        Dim sUnit As String
        Dim sValueType() As String = GetValueType()
        Dim sUnitList() As String = CUnitCommonNode.GetUnitList
        Dim sDefUnitList() As String = GetDefUnit()
        If dispInfo.nTypeOfVal <> CUnitConverter.eType.CurrentDensity Then
            sUnit = sValueType(dispInfo.nTypeOfVal) & "(" & sUnitList(dispInfo.nUnit(0)) & sDefUnitList(dispInfo.nTypeOfVal) & ")"
        Else
            sUnit = sValueType(dispInfo.nTypeOfVal) & "(" & sUnitList(dispInfo.nUnit(0)) & sDefUnitList(CUnitConverter.eType.Ampere) & "/" & sUnitList(dispInfo.nUnit(1)) & sDefUnitList(CUnitConverter.eType.Area) & ")"
        End If
        targetLabel.Text = sUnit
    End Sub

    Public Shared Sub GetCaptionAndUnit(ByVal targetCtrl_Unit As System.Windows.Forms.Label, ByVal dispInfo As CUnitConverter.sValueDisp, ByVal sTitle1 As String)
        Dim sUnit As String
        Dim sValueType() As String = CUnitConverter.GetValueType
        Dim sUnitList() As String = CUnitCommonNode.GetUnitList
        Dim sDefUnitList() As String = CUnitConverter.GetDefUnit
        If dispInfo.nTypeOfVal <> CUnitConverter.eType.CurrentDensity Then
            sUnit = sTitle1 & "(" & sUnitList(dispInfo.nUnit(0)) & sDefUnitList(dispInfo.nTypeOfVal) & ")"
        Else
            sUnit = sTitle1 & "(" & sUnitList(dispInfo.nUnit(0)) & sDefUnitList(CUnitConverter.eType.Ampere) & "/" & sUnitList(dispInfo.nUnit(1)) & sDefUnitList(CUnitConverter.eType.Area) & ")"
        End If
        targetCtrl_Unit.Text = sUnit
    End Sub


    Public Shared Sub updateDisp(ByVal targetCtrl_Value As LBSoft.IndustrialCtrls.Meters.LBDigitalMeter, ByVal dispInfo As CUnitConverter.sValueDisp, ByVal value As Double)
        Dim cvt As New CUnitConverter(dispInfo.nTypeOfVal, value)
        Dim dConvertedValue As Double
        Dim sValue As String
        Dim sValueType() As String = CUnitConverter.GetValueType
        If dispInfo.nTypeOfVal <> CUnitConverter.eType.CurrentDensity Then
            dConvertedValue = cvt.convertor.ConvertTo(dispInfo.nUnit(0))
            sValue = FormatNumber(Math.Abs(dConvertedValue), dispInfo.nDispDigit, TriState.True, TriState.False, TriState.False)
        Else
            dConvertedValue = cvt.convertor.ConvertTo(dispInfo.nUnit(0), dispInfo.nUnit(1))
            sValue = FormatNumber(Math.Abs(dConvertedValue), dispInfo.nDispDigit, TriState.True, TriState.False, TriState.False)
        End If
        targetCtrl_Value.Format = convertFormat(sValue)
        targetCtrl_Value.Value = dConvertedValue
    End Sub


    Public Shared Sub updateDisp(ByVal targetCtrl_Unit As System.Windows.Forms.Label, ByVal targetCtrl_Value As LBSoft.IndustrialCtrls.Meters.LBDigitalMeter, ByVal dispInfo As CUnitConverter.sValueDisp, ByVal value As Double)
        Dim cvt As New CUnitConverter(dispInfo.nTypeOfVal, value)
        Dim dConvertedValue As Double
        Dim sValue As String
        Dim sUnit As String
        Dim sValueType() As String = CUnitConverter.GetValueType
        If dispInfo.nTypeOfVal <> CUnitConverter.eType.CurrentDensity Then
            dConvertedValue = cvt.convertor.ConvertTo(dispInfo.nUnit(0))
            sValue = FormatNumber(Math.Abs(dConvertedValue), dispInfo.nDispDigit, TriState.True, TriState.False, TriState.False)
            sUnit = sValueType(dispInfo.nTypeOfVal) & "(" & cvt.convertor.Unit & ")"   '지워도 될것 같음.
        Else
            dConvertedValue = cvt.convertor.ConvertTo(dispInfo.nUnit(0), dispInfo.nUnit(1))
            sValue = FormatNumber(Math.Abs(dConvertedValue), dispInfo.nDispDigit, TriState.True, TriState.False, TriState.False)
            sUnit = sValueType(dispInfo.nTypeOfVal) & "(" & cvt.convertor.Unit & ")"    '지워도 될것 같음.

        End If
        targetCtrl_Value.Format = convertFormat(sValue)
        targetCtrl_Value.Value = dConvertedValue
        targetCtrl_Unit.Text = sUnit
    End Sub

   

    Public Shared Sub updateDisp(ByVal targetCtrl_Value As System.Windows.Forms.Label, ByVal dispInfo As CUnitConverter.sValueDisp, ByVal value As Double)
        Dim cvt As New CUnitConverter(dispInfo.nTypeOfVal, value)
        Dim dConvertedValue As Double
        Dim sValue As String
        Dim sUnit As String
        Dim sValueType() As String = CUnitConverter.GetValueType
        If dispInfo.nTypeOfVal <> CUnitConverter.eType.CurrentDensity Then
            dConvertedValue = cvt.convertor.ConvertTo(dispInfo.nUnit(0))
            sValue = FormatNumber(Math.Abs(dConvertedValue), dispInfo.nDispDigit, TriState.True, TriState.False, TriState.False)
            sUnit = sValueType(dispInfo.nTypeOfVal) & "(" & cvt.convertor.Unit & ")"
        Else
            dConvertedValue = cvt.convertor.ConvertTo(dispInfo.nUnit(0), dispInfo.nUnit(1))
            sValue = FormatNumber(Math.Abs(dConvertedValue), dispInfo.nDispDigit, TriState.True, TriState.False, TriState.False)
            sUnit = sValueType(dispInfo.nTypeOfVal) & "(" & cvt.convertor.Unit & ")"    '지워도 될것 같음.
        End If
        Dim Foramt As String
        Dim dValue As Double

        Foramt = convertFormat(sValue)
        dValue = dConvertedValue

        targetCtrl_Value.Text = Format(dConvertedValue, convertFormat(sValue))

    End Sub

    Public Shared Sub updateDisp(ByVal targetCtrl_Value As System.Windows.Forms.Label, ByVal dispInfo As CUnitConverter.sValueDisp, ByVal value As String)
        Dim arr As Array
        Dim dConvertedValue() As Double = Nothing
        Dim RetData() As String = Nothing
        Dim sValue As String
        Dim sUnit As String

        arr = Split(value, ",")

        ReDim RetData(arr.Length - 1)
        ReDim dConvertedValue(arr.Length - 1)

        For idx As Integer = 0 To arr.Length - 1
            Dim cvt As New CUnitConverter(dispInfo.nTypeOfVal, arr(idx))

        
            Dim sValueType() As String = CUnitConverter.GetValueType
            If dispInfo.nTypeOfVal <> CUnitConverter.eType.CurrentDensity Then
                dConvertedValue(idx) = cvt.convertor.ConvertTo(dispInfo.nUnit(0))
                sValue = FormatNumber(Math.Abs(dConvertedValue(idx)), dispInfo.nDispDigit, TriState.True, TriState.False, TriState.False)
                sUnit = sValueType(dispInfo.nTypeOfVal) & "(" & cvt.convertor.Unit & ")"
            Else
                dConvertedValue(idx) = cvt.convertor.ConvertTo(dispInfo.nUnit(0), dispInfo.nUnit(1))
                sValue = FormatNumber(Math.Abs(dConvertedValue(idx)), dispInfo.nDispDigit, TriState.True, TriState.False, TriState.False)
                sUnit = sValueType(dispInfo.nTypeOfVal) & "(" & cvt.convertor.Unit & ")"    '지워도 될것 같음.
            End If
            Dim Foramt As String
            Dim dValue As Double

            Foramt = convertFormat(sValue)
            dValue = dConvertedValue(idx)

            RetData(idx) = Format(dConvertedValue(idx), convertFormat(sValue))
        Next
       

        targetCtrl_Value.Text = RetData(0) & "," & RetData(1) 'Format(dConvertedValue, convertFormat(sValue))

    End Sub


    'Public Shared Sub updateDisp(ByVal targetCtrl As LabelGradient.LabelGradient, ByVal dispInfo As CUnitConverter.sValueDisp, ByVal value As Double)
    '    Dim cvt As New CUnitConverter(dispInfo.nTypeOfVal, value)
    '    Dim dConvertedValue As Double
    '    Dim sValue As String
    '    Dim sValueType() As String = CUnitConverter.GetValueType
    '    If dispInfo.nTypeOfVal <> CUnitConverter.eType.CurrentDensity Then
    '        dConvertedValue = cvt.convertor.ConvertTo(dispInfo.nUnit(0))
    '        sValue = FormatNumber(dConvertedValue, dispInfo.nDispDigit, TriState.True, TriState.False, TriState.False)
    '    Else
    '        dConvertedValue = cvt.convertor.ConvertTo(dispInfo.nUnit(0), dispInfo.nUnit(1))
    '        sValue = FormatNumber(dConvertedValue, dispInfo.nDispDigit, TriState.True, TriState.False, TriState.False)
    '    End If
    '    targetCtrl.Text = sValue
    'End Sub

    Public Shared Sub updateDisp(ByVal targetCtrl As System.Windows.Forms.TextBox, ByVal dispInfo As CUnitConverter.sValueDisp, ByVal value As Double)
        Dim cvt As New CUnitConverter(dispInfo.nTypeOfVal, value)
        Dim dConvertedValue As Double
        Dim sValue As String
        Dim sValueType() As String = CUnitConverter.GetValueType
        If dispInfo.nTypeOfVal <> CUnitConverter.eType.CurrentDensity Then
            dConvertedValue = cvt.convertor.ConvertTo(dispInfo.nUnit(0))
            sValue = FormatNumber(dConvertedValue, dispInfo.nDispDigit, TriState.True, TriState.False, TriState.False)
        Else
            dConvertedValue = cvt.convertor.ConvertTo(dispInfo.nUnit(0), dispInfo.nUnit(1))
            sValue = FormatNumber(dConvertedValue, dispInfo.nDispDigit, TriState.True, TriState.False, TriState.False)
        End If
        targetCtrl.Text = sValue

    End Sub


    Private Shared Function convertFormat(ByVal sValue As String) As String
        Dim numDigitDecimal As Integer
        Dim numDigitAfterDecimal As Integer
        Dim arrBuf As Array = Split(sValue, ".", -1)
        Dim sCvtFormat As String = ""

        numDigitDecimal = arrBuf(0).ToString.Length
        numDigitAfterDecimal = arrBuf(1).ToString.Length
        For i As Integer = 0 To numDigitDecimal - 1
            sCvtFormat = sCvtFormat & "0"
        Next

        sCvtFormat = sCvtFormat & "."

        For i As Integer = 0 To numDigitAfterDecimal - 1
            sCvtFormat = sCvtFormat & "0"
        Next
        Return sCvtFormat
    End Function

    ''' <summary>
    ''' double 형 값을 입력(ex, -8124.123911231)하고, 변환할 형태(소수점이하 표시 자리수, 단위 등)를 설정하면
    '''  String 형 값을 출력 (ex, -8124.123)
    ''' </summary>
    ''' <param name="dispInfo"></param>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ValueConvertToFormatted(ByVal dispInfo As CUnitConverter.sValueDisp, ByVal value As Double) As String
        Dim cvt As New CUnitConverter(dispInfo.nTypeOfVal, value)
        Dim dConvertedValue As Double
        Dim sValue As String
        Dim sValueType() As String = CUnitConverter.GetValueType
        If dispInfo.nTypeOfVal <> CUnitConverter.eType.CurrentDensity Then
            dConvertedValue = cvt.convertor.ConvertTo(dispInfo.nUnit(0))
            sValue = FormatNumber(dConvertedValue, dispInfo.nDispDigit, TriState.True, TriState.False, TriState.False)
        Else
            dConvertedValue = cvt.convertor.ConvertTo(dispInfo.nUnit(0), dispInfo.nUnit(1))
            sValue = FormatNumber(dConvertedValue, dispInfo.nDispDigit, TriState.True, TriState.False, TriState.False)
        End If
        Return sValue
    End Function

    ''' <summary>
    ''' 입력된 값에 단위를 반영한 값을 리턴, 입력 = 1A, 일때 mA로 변환하면, 1000mA를 리턴
    ''' </summary>
    ''' <param name="dispInfo"></param>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ValueConvert(ByVal dispInfo As CUnitConverter.sValueDisp, ByVal value As Double) As Double
        Dim cvt As New CUnitConverter(dispInfo.nTypeOfVal, value)
        Dim dConvertedValue As Double
        Dim sValueType() As String = CUnitConverter.GetValueType
        If dispInfo.nTypeOfVal <> CUnitConverter.eType.CurrentDensity Then
            dConvertedValue = cvt.convertor.ConvertTo(dispInfo.nUnit(0))
        Else
            dConvertedValue = cvt.convertor.ConvertTo(dispInfo.nUnit(0), dispInfo.nUnit(1))
        End If
        Return dConvertedValue
    End Function



End Class
