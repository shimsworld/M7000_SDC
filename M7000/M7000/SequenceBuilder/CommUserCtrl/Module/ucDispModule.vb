Public Class ucDispModule



#Region "Defines"


    Friend WithEvents ucPGImageSweep As M7000.ucDispPGImageSweep


    Dim m_PGInfo As frmPatternGeneratorSetting.sPGInfos

    Dim m_bVisibleInitCodeEditTabPage As Boolean = True
    Dim m_bVisiblePowerCtrlTabPage As Boolean = True
    Dim m_bVisiblePatternEditTabPage As Boolean = True

    Dim m_nID As Integer

#End Region

#Region "Creator And Init"



    Public Sub New(ByVal ID As Integer)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_nID = ID
        init()
    End Sub

    Private Sub init()


        tcMain.Dock = DockStyle.Fill


        ucPGInitCode.Dock = DockStyle.Fill

        ucPGPower.Location = New System.Drawing.Point(0, 0)


        ucPGImageSweep = New M7000.ucDispPGImageSweep(g_sPATH_PG_IMAGE & "\ucDispModule" & CStr(m_nID))
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


        '  ucPGGrayScale.Location = New System.Drawing.Point(0, 0)
    End Sub


#End Region

#Region "Properties"


    Public Property Settings As frmPatternGeneratorSetting.sPGInfos
        Get
            GetValueFromUI()
            Return m_PGInfo
        End Get
        Set(ByVal value As frmPatternGeneratorSetting.sPGInfos)
            m_PGInfo = value
            SetValueToUI()
        End Set
    End Property

    Public Property VisibleInitCodeEditTabPage As Boolean
        Get
            Return m_bVisibleInitCodeEditTabPage
        End Get
        Set(ByVal value As Boolean)
            m_bVisibleInitCodeEditTabPage = value
            updateViewSettings()
        End Set
    End Property

    Public Property VisiblePowerControlTabPage As Boolean
        Get
            Return m_bVisiblePowerCtrlTabPage
        End Get
        Set(ByVal value As Boolean)
            m_bVisiblePowerCtrlTabPage = value
            updateViewSettings()
        End Set
    End Property

    Public Property VisiblePatternEditTabPage As Boolean
        Get
            Return m_bVisiblePatternEditTabPage
        End Get
        Set(ByVal value As Boolean)
            m_bVisiblePatternEditTabPage = value
            updateViewSettings()
        End Set
    End Property


#End Region

#Region "Functions"


    Private Sub SetValueToUI()
        '  ucPGGrayScale.Datas = m_PGInfo.sGrayScale
        Try
            ucPGInitCode.Datas = m_PGInfo.sInitCodeInfo
            ucPGPower.Datas = m_PGInfo.sPwr
            ucPGImageSweep.Datas = m_PGInfo.sImageInfos
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GetValueFromUI()
        ' m_PGInfo.sGrayScale = ucPGGrayScale.Datas
        Dim sInitCode As UcDispPGInitCode.sInitCodeInfo = Nothing

        'ucPGImageSweep.FlushImageMemory()
        ' ucPGImageSweep.Dispose()

        m_PGInfo.sPwr = ucPGPower.Datas

        ucPGInitCode.GetPGInitCodeList(sInitCode)

        m_PGInfo.sInitCodeInfo = ucPGInitCode.Datas
        m_PGInfo.sImageInfos = ucPGImageSweep.Datas
    End Sub

    Private Sub updateViewSettings()

        tcMain.Controls.Clear()

        If m_bVisibleInitCodeEditTabPage = True Then tcMain.Controls.Add(Me.tpRegImsi)

        If m_bVisiblePowerCtrlTabPage = True Then tcMain.Controls.Add(Me.tpPower)

        If m_bVisiblePatternEditTabPage = True Then tcMain.Controls.Add(Me.tpImageSweep)

    End Sub

#End Region

   
    Private Sub ucDispModule_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        ucPGImageSweep.Dispose()
    End Sub
End Class
