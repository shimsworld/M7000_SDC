
Imports System.Windows.Forms
Public Class ucDispPGGrayScale



#Region "Define"

    Dim m_RGBColor As sPGGrayScale

    Public Structure sPGGrayScale
        Dim nWhite As Integer
        Dim nRed As Integer
        Dim nGreen As Integer
        Dim nBlue As Integer
    End Structure

#End Region


#Region "Creator and Init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Public Sub init()
        trackbarW.SetRange(0, 255)
        trackbarR.SetRange(0, 255)
        trackbarG.SetRange(0, 255)
        trackbarB.SetRange(0, 255)
    End Sub

#End Region

#Region "Properties"


    Public Property Datas() As sPGGrayScale
        Get
            Return m_RGBColor
        End Get
        Set(ByVal value As sPGGrayScale)
            m_RGBColor = value '
            SetValueToUI()
        End Set
    End Property

#End Region

    Private Sub SetValueToUI()

        Dim m_RGB As sPGGrayScale
        m_RGB = m_RGBColor

        txtRed.Text = m_RGB.nRed
        txtBlue.Text = m_RGB.nBlue
        txtGreen.Text = m_RGB.nGreen
        txtWhite.Text = m_RGB.nWhite

    End Sub

    Private Sub GetValueToUI()
        m_RGBColor.nRed = txtRed.Text
        m_RGBColor.nBlue = txtBlue.Text
        m_RGBColor.nGreen = txtGreen.Text
        m_RGBColor.nWhite = txtWhite.Text
    End Sub


    Private Sub ChangeColor()
        Dim Color As Color = Color.FromArgb(255, m_RGBColor.nRed, m_RGBColor.nGreen, m_RGBColor.nBlue)

        txtColorSet.BackColor = Color
        txtRed.Text = trackbarR.Value
        txtBlue.Text = trackbarB.Value
        txtGreen.Text = trackbarG.Value

        Me.Refresh()
    End Sub

    Private Sub trackbarR_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackbarR.Scroll

        m_RGBColor.nRed = trackbarR.Value

        ChangeColor()

    End Sub

    Private Sub trackbarG_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackbarG.Scroll

        m_RGBColor.nGreen = trackbarG.Value
        ' txtGreen.Text = trackbarG.Value
        ChangeColor()

    End Sub

    Private Sub trackbarB_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackbarB.Scroll

        m_RGBColor.nBlue = trackbarB.Value
        '  txtBlue.Text = trackbarB.Value
        ChangeColor()

    End Sub

    Private Sub trackbarW_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackbarW.Scroll

        m_RGBColor.nWhite = trackbarW.Value
        txtWhite.Text = trackbarW.Value

        trackbarR.Value = trackbarW.Value
        m_RGBColor.nRed = trackbarR.Value
        '  txtRed.Text = trackbarR.Value

        trackbarG.Value = trackbarW.Value
        m_RGBColor.nGreen = trackbarG.Value
        '  txtGreen.Text = trackbarG.Value

        trackbarB.Value = trackbarW.Value
        m_RGBColor.nBlue = trackbarB.Value
        '  txtBlue.Text = trackbarB.Value
        ChangeColor()
    End Sub


    Private Sub txtWhite_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWhite.TextChanged
        trackbarW.Value = txtWhite.Text
        m_RGBColor.nWhite = trackbarW.Value

        ChangeColor()
    End Sub


    Private Sub txtRed_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRed.TextChanged
        trackbarR.Value = txtRed.Text
        m_RGBColor.nRed = trackbarR.Value

        ChangeColor()
    End Sub

    Private Sub txtGreen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGreen.TextChanged
        trackbarG.Value = txtGreen.Text
        m_RGBColor.nGreen = trackbarG.Value

        ChangeColor()
    End Sub

    Private Sub txtBlue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBlue.TextChanged
        trackbarB.Value = txtBlue.Text
        m_RGBColor.nBlue = trackbarB.Value

        ChangeColor()
    End Sub
End Class
