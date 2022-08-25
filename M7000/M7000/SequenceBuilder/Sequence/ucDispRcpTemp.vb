Public Class ucDispRcpTemp


#Region "Define"
    Dim sState() As String = New String() {"OFF", "ON"}

    Dim m_nViewMode As eViewMode = eViewMode.eAllView

    Public Event evTempAdd(ByVal TargetTemp As Double, ByVal DevTemp As Double)
    Public Event evTempUPdate(ByVal Temp As Double, ByVal Time As Double)

    Public Event evTargetTempChage(ByVal temp As Double)
    Public Event evTempTimeChange(ByVal time As Double)

    Public Enum eViewMode
        eAllView
        eMinimum
    End Enum

#End Region






#Region "Properties"

    Public Property TartgetTemp As Double
        Get
            Return CDbl(txtTargetTemp.Text)
        End Get
        Set(ByVal value As Double)
            txtTargetTemp.Text = value
        End Set
    End Property

    Public Property StableTime As Double
        Get
            Return CDbl(txtStableTime.Text) * 60
        End Get
        Set(ByVal value As Double)
            txtStableTime.Text = value / 60
        End Set
    End Property

    Public WriteOnly Property VisibleTargetTemp As Boolean
        Set(ByVal value As Boolean)
            txtTargetTemp.Visible = value
            lblTargetTemp.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleStableTime As Boolean
        Set(ByVal value As Boolean)
            txtStableTime.Visible = value
            lblStabilizationTime.Visible = value
        End Set
    End Property

    Public Property ViewMode As eViewMode
        Get
            Return m_nViewMode
        End Get
        Set(ByVal value As eViewMode)
            m_nViewMode = value

            Select Case m_nViewMode
                Case eViewMode.eAllView
                    txtTargetTemp.Visible = True
                    txtStableTime.Visible = True
                    btnAdd.Visible = True
                    btnUpdate.Visible = True
                    lblStabilizationTime.Visible = True
                    Label2.Visible = True
                Case eViewMode.eMinimum
                    txtTargetTemp.Visible = True
                    txtStableTime.Visible = False
                    btnAdd.Visible = False
                    btnUpdate.Visible = False
                    lblStabilizationTime.Visible = False
                    Label2.Visible = False
            End Select

        End Set
    End Property

#End Region


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        gbTemperature.Location = New System.Drawing.Point(0, 0)
        gbTemperature.Dock = DockStyle.Fill

        tlpPanel2.Location = New System.Drawing.Point(0, 0)
        tlpPanel2.Dock = DockStyle.Fill

        Panel1.Dock = DockStyle.Fill

        btnAdd.Dock = DockStyle.Fill
        btnUpdate.Dock = DockStyle.Fill
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'If txtTargetTemp.Text = "" Then
        '    Exit Sub
        'ElseIf txtModeTime.Text = "" Then
        '    Exit Sub
        'End If

        'RaiseEvent evTempadd(CDbl(txtTargetTemp.Text), CDbl(txtModeTime.Text))

        Try
            RaiseEvent evTempAdd(CDbl(txtTargetTemp.Text), CDbl(txtStableTime.Text))
        Catch ex As Exception
            '예외 처리 필요.
        End Try

    End Sub


    Private Sub btnTemperatureUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

       
        '  Dim bTimeAccumulate As Boolean

        'If txtTargetTemp.Text = "" Then
        '    Exit Sub
        'ElseIf txtModeTime.Text = "" Then
        '    Exit Sub
        'End If

        ''If cbTimeApply.SelectedIndex <> 0 Then
        ''    bTimeAccumulate = True
        ''Else
        ''    bTimeAccumulate = False
        ''End If

        'RaiseEvent evTempUPdate(CDbl(txtTargetTemp.Text), CDbl(txtModeTime.Text))
        Try
            RaiseEvent evTempUPdate(CDbl(txtTargetTemp.Text), CDbl(txtStableTime.Text))
        Catch ex As Exception
            '예외 처리 필요.
        End Try

    End Sub


#Region "Change Value"

    Private Sub txtTargetTemp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTargetTemp.TextChanged
        ' If txtTargetTemp.Text = "" Then Exit Sub

        '2013-04-19 텍스트 입력 예외 처리 추가.

        Dim TempText() As String = Split(txtTargetTemp.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Try
            RaiseEvent evTargetTempChage(CDbl(txtTargetTemp.Text))
        Catch ex As Exception
            RaiseEvent evTargetTempChage(0)
        End Try

        ' RaiseEvent evTargetTempChage(CDbl(txtTargetTemp.Text))
    End Sub

    Private Sub txtModeTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStableTime.TextChanged
        'If txtModeTime.Text = "" Then Exit Sub
        'RaiseEvent evTempTimeChange(CDbl(txtModeTime.Text))

        ' If txtModeTime.Text = "" Then Exit Sub

        '2013-04-19 텍스트 입력 예외 처리 추가.

        Dim TempText() As String = Split(txtStableTime.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Try
            RaiseEvent evTempTimeChange(CDbl(txtStableTime.Text))
        Catch ex As Exception
            RaiseEvent evTempTimeChange(0)
        End Try


    End Sub

    'Private Sub cbTimeApply_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim bTimeAccumulate As Boolean

    '    If cbTimeApply.SelectedIndex <> 0 Then
    '        bTimeAccumulate = True
    '    Else
    '        bTimeAccumulate = False
    '    End If
    '    RaiseEvent evTempTimeApply(bTimeAccumulate)
    'End Sub

#End Region



End Class
