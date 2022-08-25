Public Class CUnitResistance
    Inherits CUnitCommonNode

#Region "Define"

    Dim m_sMyDefUnit As String = "Ohm"
    ' Dim m_sUnit As String
#End Region

#Region "Property"


    Public Overloads ReadOnly Property Unit() As String
        Get
            Return m_sUnit
        End Get
    End Property

#End Region



#Region "Init"

    Public Sub New(ByVal dValue As Double, ByVal nDefUnit As CUnitConverter.eType)
        MyBase.New(dValue)
        m_nDefUnitType = nDefUnit
        m_sMyDefUnit = CUnitConverter.GetDefUnit(nDefUnit)
    End Sub



#End Region

#Region "Functions"

    Public Overrides Function ConvertTo(ByVal targetUnit As CUnitCommonNode.eMKSUnit) As Double
        m_sUnit = m_sUnitCaptions(targetUnit) & m_sMyDefUnit
        Return MyBase.ConvertTo(targetUnit)
    End Function

#End Region

End Class
