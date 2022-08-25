Public Class CUnitCurrentDensity
    Inherits CUnitCommonNode

#Region "Define"

    Dim m_sMyDefUnit1 As String = "A"
    Dim m_sMyDefUnit2 As String = "m^2"
    ' Dim m_sUnit As String
#End Region

#Region "Property"


    Public Overrides ReadOnly Property Unit() As String
        Get
            Return m_sUnit
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultUnit() As String
        Get
            Return m_sMyDefUnit1 & "/" & m_sMyDefUnit2
        End Get
    End Property

#End Region


#Region "Init"

    Public Sub New(ByVal dValue As Double, ByVal nDefUnit1 As CUnitConverter.eType, ByVal nDefUnit2 As CUnitConverter.eType)
        MyBase.New(dValue)
        m_sMyDefUnit1 = CUnitConverter.GetDefUnit(nDefUnit1)
        m_sMyDefUnit2 = CUnitConverter.GetDefUnit(nDefUnit2)
        m_nDefUnitType = CUnitConverter.eType.CurrentDensity
    End Sub





#End Region


#Region "Functions"

    Public Overrides Function ConvertToDef(ByVal dValue As Double, ByVal ValueUnit1 As eMKSUnit, ByVal ValueUnit2 As eMKSUnit) As Double
        Dim dOrder As Double
        Dim dArea As Double
        Dim dAmpere As Double

        dAmpere = m_dUnit(ValueUnit1)
        dArea = (m_dUnit(ValueUnit2) ^ 2)

        dOrder = dAmpere / dArea

        m_dValue = m_dValue * dOrder

        Return m_dValue
        Return 0
    End Function


    Public Overrides Function ConvertTo(ByVal targetAmpereUnit As CUnitCommonNode.eMKSUnit, ByVal targetAreaUnit As CUnitCommonNode.eMKSUnit) As Double

        Dim dOrder As Double
        Dim dArea As Double
        Dim dAmpere As Double

        dArea = (m_dUnit(targetAreaUnit) ^ 2)
        dAmpere = m_dUnit(targetAmpereUnit)

        dOrder = dAmpere / dArea

        m_dValue = m_dValue / dOrder

        m_sUnit = m_sUnitCaptions(targetAmpereUnit) & m_sMyDefUnit1 & "/" & m_sUnitCaptions(targetAreaUnit) & m_sMyDefUnit2

        Return m_dValue
    End Function


#End Region

End Class
