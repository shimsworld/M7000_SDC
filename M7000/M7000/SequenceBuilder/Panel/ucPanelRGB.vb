Public Class ucPanelRGB

#Region "Define"
    Dim m_sSettings As sRGBSignal
#End Region

#Region "Structure"
    Public Structure sRGBSignal
        Dim dRed As Double
        Dim dGreen As Double
        Dim dBlue As Double
    End Structure
#End Region


#Region "Creator"
    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        gbRGBSignal.Location = New System.Drawing.Point(0, 0)
        gbRGBSignal.Dock = DockStyle.Fill
    End Sub

#End Region


#Region "Properties"
    Public Property Setting As sRGBSignal
        Get
            GetFormUI()
            Return m_sSettings
        End Get
        Set(ByVal value As sRGBSignal)
            m_sSettings = value
            SetFormUI(m_sSettings)
        End Set
    End Property
#End Region


#Region "Function"

    Private Sub GetFormUI()

        With m_sSettings
            .dRed = CDbl(tbRed.Text)
            .dGreen = CDbl(tbGreen.Text)
            .dBlue = CDbl(tbBlue.Text)
        End With
    End Sub

    Private Sub SetFormUI(ByVal RGBSignal As sRGBSignal)

        With RGBSignal
            tbRed.Text = CStr(.dRed)
            tbGreen.Text = CStr(.dGreen)
            tbBlue.Text = CStr(.dBlue)
        End With
    End Sub
#End Region


End Class
