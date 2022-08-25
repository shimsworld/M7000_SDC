Public Class ucRefPDSetting

#Region "Define"

    Public Structure sLuminance
        Dim eEnableRenewalMode As eRefPDMode
        Dim RenewalTime As CTime.sTimeValue
    End Structure

    Dim sState() As String = New String() {"OFF", "Once", "Change Recipe"}

    Dim m_LumiSet As sLuminance

    Public Event evGetData(ByVal renewalMode As eRefPDMode, ByVal dTime As Double)
    Public Event evRefPDRenewalChange(ByVal bRenewal As eRefPDMode)
    Public Event evRefPDRenewalTimechange(ByVal dRenewalTime As Double)

    Enum eRefPDMode
        OFF = 0
        Once = 1
        ChangeRecipe = 2
    End Enum


    Property Setting As sLuminance
        Get
            GetUIData()
            Return m_LumiSet
        End Get
        Set(ByVal value As sLuminance)

            SetUIData(value)

        End Set
    End Property

    Public WriteOnly Property SetRenewalMode As eRefPDMode
        Set(value As eRefPDMode)

            cbRenewalMode.SelectedIndex = value

            'If value = False Then
            '    cbRenewalMode.SelectedIndex = 0
            'Else
            '    cbRenewalMode.SelectedIndex = 1
            'End If
        End Set

    End Property


    Public WriteOnly Property SetRenewalTime As Double
        Set(value As Double)
            txtRenewalTime.Text = value
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
        gbRefPD.Location = New System.Drawing.Point(0, 0)
        gbRefPD.Dock = DockStyle.Fill

        With cbRenewalMode
            .Items.Clear()
            For i As Integer = 0 To sState.Length - 1
                .Items.Add(sState(i))
            Next
            .SelectedIndex = 0
        End With
    End Sub

    Public Sub GetUIData()
        m_LumiSet.eEnableRenewalMode = cbRenewalMode.SelectedIndex
        m_LumiSet.RenewalTime = CTime.Convert_SecToTimeValue((CDbl(txtRenewalTime.Text)) * 60)

        RaiseEvent evGetData(m_LumiSet.eEnableRenewalMode, m_LumiSet.RenewalTime.nSecound)
    End Sub

    Public Sub SetUIData(ByVal in_data As sLuminance)

        cbRenewalMode.SelectedIndex = in_data.eEnableRenewalMode

        'If in_data.bEnableRenewalMode = False Then
        '    cbRenewalMode.SelectedIndex = 0
        'ElseIf in_data.bEnableRenewalMode = True Then
        '    cbRenewalMode.SelectedIndex = 1
        'End If

        txtRenewalTime.Text = in_data.RenewalTime.dMin
    End Sub

    Private Sub cbRenewalMode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbRenewalMode.SelectedIndexChanged

        If cbRenewalMode.SelectedItem = "OFF" Then
            txtRenewalTime.Enabled = False
            txtRenewalTime.Text = "0"
        Else
            txtRenewalTime.Enabled = True
        End If

        RaiseEvent evRefPDRenewalChange(cbRenewalMode.SelectedIndex)
    End Sub

    Private Sub txtRenewalTime_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRenewalTime.TextChanged
        'If txtRenewalTime.Text <> "" Then
        '    RaiseEvent evRefPDRenewalTimechange(CDbl(txtRenewalTime.Text))
        'End If

        Dim TempText() As String = Split(txtRenewalTime.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        If TempText(TempText.Length - 1) = "" Then Exit Sub

        Try
            RaiseEvent evRefPDRenewalTimechange(CDbl(txtRenewalTime.Text))
        Catch ex As Exception
            RaiseEvent evRefPDRenewalTimechange(0)
            Exit Sub
        End Try
    End Sub

#Region "Shared Functions"

    Public Shared Function ConvertStrRefPDModeToInt(ByVal str As String) As eRefPDMode
        Select Case str
            Case eRefPDMode.OFF.ToString
                Return eRefPDMode.OFF
            Case eRefPDMode.Once.ToString
                Return eRefPDMode.Once
            Case eRefPDMode.ChangeRecipe.ToString
                Return eRefPDMode.ChangeRecipe
            Case Else
                Return -1
        End Select
    End Function

#End Region

End Class
