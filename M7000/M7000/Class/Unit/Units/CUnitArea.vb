Public Class CUnitArea
    Inherits CUnitCommonNode

#Region "Define"

    Dim m_sMyDefUnit As String   'm^2
    ' Dim m_sUnit As String


    Public Enum eUnitArea
        sequ
    End Enum
#End Region

#Region "Property"


#End Region



#Region "Init"

    Public Sub New(ByVal dValue As Double, ByVal nDefUnit As CUnitConverter.eType)
        MyBase.New(dValue)
        m_nDefUnitType = nDefUnit
        m_sMyDefUnit = CUnitConverter.GetDefUnit(nDefUnit)
    End Sub




#End Region

#Region "Functions"

    Public Overrides Function ToExa() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.Exa) ^ 2)
    End Function
    Public Overrides Function ToPeta() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.Peta) ^ 2)
    End Function

    Public Overrides Function ToTera() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.Tera) ^ 2)
    End Function

    Public Overrides Function ToGiga() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.Giga) ^ 2)
    End Function

    Public Overrides Function ToMega() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.Mega) ^ 2)
    End Function

    Public Overrides Function ToKilo() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.Kilo) ^ 2)
    End Function

    Public Overrides Function ToHecto() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.hecto) ^ 2)
    End Function

    Public Overrides Function ToDeca() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.deca) ^ 2)
    End Function

    Public Overrides Function ToDeci() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.deci) ^ 2)
    End Function

    Public Overrides Function ToCenti() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.centi) ^ 2)
    End Function

    Public Overrides Function ToMili() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.mili) ^ 2)
    End Function

    Public Overrides Function ToMicro() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.micro) ^ 2)
    End Function

    Public Overrides Function ToNano() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.nano) ^ 2)
    End Function

    Public Overrides Function ToPico() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.pico) ^ 2)
    End Function

    Public Overrides Function ToFemto() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.femto) ^ 2)
    End Function

    Public Overrides Function ToAto() As Double
        Return m_dValue / (m_dUnit(eMKSUnit.ato) ^ 2)
    End Function

    Public Overrides Function ConvertToDef(ByVal dValue As Double, ByVal ValueUnit As CUnitCommonNode.eMKSUnit) As Double
        Return m_dValue * (m_dUnit(ValueUnit) ^ 2)
    End Function

    Public Overrides Function ConvertTo(ByVal targetUnit As CUnitCommonNode.eMKSUnit) As Double
        m_sUnit = m_sUnitCaptions(targetUnit) & m_nDefUnitType
        Dim dOrder As Double = m_dUnit(targetUnit) ^ 2
        m_dValue = m_dValue / dOrder
        Return m_dValue
    End Function

#End Region

End Class
