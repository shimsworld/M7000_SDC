Public Class frmCheckContact

    Private m_Contact As frmOptionWindow.sContact

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub
#Region "Propertys"

    Public Property Settings() As frmOptionWindow.sContact
        Get
            GetValueToUI()
            Return m_Contact
        End Get
        Set(ByVal value As frmOptionWindow.sContact)
            m_Contact = value
        End Set
    End Property

#End Region

#Region "Create&Initialize"

    Public Sub init()

       
    End Sub

#End Region


    Private Sub frmCheckContact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetValueToUI()
    End Sub

    Private Sub SetValueToUI()
        tbBias.Text = m_Contact.dContactBias
        tbPassLv.Text = m_Contact.dPassLevel
        tbMargin.Text = m_Contact.dBiasMargin
    End Sub

    Private Sub GetValueToUI()
        m_Contact.dContactBias = CDbl(tbBias.Text)
        m_Contact.dPassLevel = CDbl(tbPassLv.Text)
        m_Contact.dBiasMargin = CDbl(tbMargin.Text)
    End Sub


End Class