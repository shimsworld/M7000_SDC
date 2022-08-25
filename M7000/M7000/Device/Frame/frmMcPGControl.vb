Public Class frmMcPGControl


    Dim m_Main As frmMain

#Region "Defiens"

    Public cFlag As sFlag

#Region "Structure"

    Public Structure sFlag
        Dim Tempisconnect As Boolean
        Dim FormClose As Boolean
    End Structure

#End Region

#End Region


#Region "Creator, Dispos and Initialization Funnction"

    Public Sub New(ByVal main As frmMain, ByVal config As frmConfigDevice.sConfig)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_Main = main
        init()

    End Sub

    Private Sub init()
        UcFrameModuleControl.fMain = m_Main
        UcframePG.fMain = m_Main
        UcframePower.fMain = m_Main
    End Sub

#End Region

    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        cFlag.FormClose = False
    End Sub

    Private Sub frmPGControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
