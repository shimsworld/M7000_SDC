Public Class frmPatternGeneratorSetting



#Region "Defines"


    Friend WithEvents ucPGImageSweep As M7000.ucDispPGImageSweep

    Dim m_bVisibleInitCodeTabPage As Boolean
    Dim m_bVisiblePowerCtrlTabPage As Boolean
    Dim m_bVisiblePatternTabPage As Boolean
    'Friend WithEvents PGImageSweep As ucDispPGImageSweep
    Dim m_PGInfo As sPGInfos
   
    Public Structure sPGInfos
        Dim sPwr As ucDispPGPower.sPGPwr
        Dim sImageInfos As ucDispPGImageSweep.sPGImageInfos
        Dim sGrayScale As ucDispPGGrayScale.sPGGrayScale
        Dim sReg As ucDispPGReg.sPGReg
        Dim sInitCodeInfo As UcDispPGInitCode.sInitCodeInfo
        'Dim sInitCode()() As cDevMcPGControl.sRegisterInfos  'Initial Code 수정 전
    End Structure

#End Region

#Region "Creator And Init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()

        tcMain.Location = New System.Drawing.Point(0, 0)


        ucPGInitCode.Dock = DockStyle.Fill

        ucPGImageSweep = New M7000.ucDispPGImageSweep(g_sPATH_PG_IMAGE & "\frmPGSettings")
        ucPGImageSweep.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ucPGImageSweep.Location = New System.Drawing.Point(3, 1)
        ucPGImageSweep.Name = "ucPGImageSweep"
        ucPGImageSweep.Size = New System.Drawing.Size(1018, 586)
        ucPGImageSweep.TabIndex = 0
        ucPGImageSweep.VisibleMode = M7000.ucDispPGImageSweep.eViewMode._Lifetime_G4S
        Me.tpImageSweep.Controls.Add(Me.ucPGImageSweep)
        ucPGImageSweep.Dock = DockStyle.Fill
     
    End Sub


#End Region

#Region "Properties"


    Public Property Datas As sPGInfos
        Get
            GetValueFromUI()
            Return m_PGInfo
        End Get
        Set(ByVal value As sPGInfos)
            m_PGInfo = value
            SetValueToUI()
        End Set
    End Property


    Public WriteOnly Property VisibleInitCodeTabPage As Boolean
        Set(ByVal value As Boolean)
            m_bVisibleInitCodeTabPage = value
            updateViewSetting()
        End Set
    End Property

    Public WriteOnly Property VisiblePowerCtrlTabPage As Boolean
        Set(ByVal value As Boolean)
            m_bVisiblePowerCtrlTabPage = value
            updateViewSetting()
        End Set
    End Property

    Public WriteOnly Property VisiblePatternTabPage As Boolean
        Set(ByVal value As Boolean)
            m_bVisiblePatternTabPage = value
            updateViewSetting()
        End Set
    End Property


#End Region

#Region "Functions"


    Private Sub SetValueToUI()
        ucPGGrayScale.Datas = m_PGInfo.sGrayScale
        ucPGImageSweep.Datas = m_PGInfo.sImageInfos
        ucPGInitCode.Datas = m_PGInfo.sInitCodeInfo

        ucPGPower.Datas = m_PGInfo.sPwr

    End Sub

    Private Sub GetValueFromUI()
        m_PGInfo.sGrayScale = ucPGGrayScale.Datas
        m_PGInfo.sImageInfos = ucPGImageSweep.Datas
        m_PGInfo.sInitCodeInfo = ucPGInitCode.Datas
        m_PGInfo.sPwr = ucPGPower.Datas
    End Sub

    Private Sub updateViewSetting()
        tcMain.Controls.Clear()

        If m_bVisibleInitCodeTabPage = True Then tcMain.Controls.Add(Me.tpRegIMSI)
        If m_bVisiblePowerCtrlTabPage = True Then tcMain.Controls.Add(Me.tpPower_RGB)
        If m_bVisiblePatternTabPage = True Then tcMain.Controls.Add(Me.tpImageSweep)
    End Sub
#End Region





    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    End Sub

    Private Sub frmPatternGeneratorSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim PGNo As Integer = frmChAllocation.GetAllocationValue(m_Ch, frmChAllocation.eChAllocationItem.eDevNoOfPG)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

    End Sub
End Class