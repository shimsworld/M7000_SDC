Public Class ucSweepSetting


#Region "Define"

    Public Event ChangedSweepType(ByVal type As eSweepType)

    Public Shared m_sCaptions_SweepType() As String = New String() {"Standard", "User Pattern", "RGB Pattern"} '220825 Update by JKY : RGB Pattern 추가
    Public Shared m_sCaptions_Unit() As String = New String() {"V", "mA", "Deg"}

    Dim m_SweepType As eSweepType

    Public Enum eSweepType
        _Standard
        _UserPattern
        '220825 Update by JKY : RGB Pattern 추가
        _RGBPattern
    End Enum

    Public Enum eUnitType
        _Voltage
        _milliAmpere
        _Degree
    End Enum

#End Region

#Region "Properties"

    Public Property MainTitle As String
        Get
            Return gbMain.Text
        End Get
        Set(ByVal value As String)
            gbMain.Text = value
        End Set
    End Property


    Public Property SweepType As eSweepType
        Get
            Return m_SweepType
        End Get
        Set(value As eSweepType)
            m_SweepType = value
            cbSelSweepType.SelectedIndex = m_SweepType
            '          UpdateSweepType()
        End Set
    End Property

#End Region

#Region "Creator, Disposer And Init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        gbMain.Dock = DockStyle.Fill

        ucRGBSweepRegion.Location = New System.Drawing.Point(5, Label1.Location.Y + 20) '220825 Update by JKY
        ucSweepRegion.Location = New System.Drawing.Point(5, Label1.Location.Y + 20)
        ucUserPatternList.Location = New System.Drawing.Point(5, Label1.Location.Y + 20)

        With cbSelSweepType
            .Items.Clear()
            For i As Integer = 0 To m_sCaptions_SweepType.Length - 1
                .Items.Add(m_sCaptions_SweepType(i))
            Next
            .SelectedIndex = 0
        End With

    End Sub

#End Region


    Private Sub cbSelSweepType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelSweepType.SelectedIndexChanged

        m_SweepType = cbSelSweepType.SelectedIndex
        UpdateSweepType()
    End Sub


    Private Sub UpdateSweepType()
        '220825 Update by JKY : RGB Pattern Type 추가
        Select Case m_SweepType
            'Case eSweepMode._SingleValue
            '    ucSweepRegion.Visible = False
            '    ucUserPatternList.Visible = False
            '    lblSingleValue.Visible = True
            '    tbSingleValue.Visible = True
            '    lblSingleValueUnit.Visible = True
            Case eSweepType._Standard
                ucSweepRegion.Visible = True
                ucUserPatternList.Visible = False
                ucRGBSweepRegion.Visible = False
                lblSingleValue.Visible = False
                tbSingleValue.Visible = False
                lblSingleValueUnit.Visible = False
            Case eSweepType._UserPattern
                ucSweepRegion.Visible = False
                ucUserPatternList.Visible = True
                ucRGBSweepRegion.Visible = False
                lblSingleValue.Visible = False
                tbSingleValue.Visible = False
                lblSingleValueUnit.Visible = False
            Case eSweepType._RGBPattern
                ucSweepRegion.Visible = False
                ucUserPatternList.Visible = False
                ucRGBSweepRegion.Visible = True
                lblSingleValue.Visible = False
                tbSingleValue.Visible = False
                lblSingleValueUnit.Visible = False
            Case Else

        End Select

    End Sub



End Class
