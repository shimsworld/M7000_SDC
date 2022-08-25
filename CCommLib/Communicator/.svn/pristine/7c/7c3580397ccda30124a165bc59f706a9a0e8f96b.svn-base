Imports System.Windows.Forms

Public Class ucConfigGPIB
#Region "Initialization"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub Init()

        gbTitle.Location = New Drawing.Point(0, 0)
        gbTitle.Dock = DockStyle.Fill

        gbTitle.ForeColor = Me.ForeColor
        Label1.ForeColor = Me.ForeColor

        tbAddressNumber.Text = 0
    End Sub
#End Region

#Region "Define Property"
    Public Property Title() As String
        Get
            Return gbTitle.Text
        End Get
        Set(ByVal Value As String)
            gbTitle.Text = Value
        End Set
    End Property

    Public Property ADDRESS() As Integer
        Get
            Return CInt(tbAddressNumber.Text)
        End Get
        Set(ByVal value As Integer)
            tbAddressNumber.Text = CStr(value)
        End Set
    End Property
#End Region


End Class
