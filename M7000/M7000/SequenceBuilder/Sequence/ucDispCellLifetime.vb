Public Class ucDispCellLifetime



#Region "Define"

    Dim m_nViewMode As eViewMode = eViewMode.eAllView

    Public Shared m_sCaptions_SrcMode() As String = New String() {"CC", "CV", "PC", "PV", "PCV"}
    'Dim sONOFF() As String = New String() {"OFF", "ON"}
    Dim m_sSettings As sSourceSetting

    Public Event evAddSettings(ByRef Settings As sSourceSetting) 'sBias
    Public Event evSourceModeChange(ByVal SourceMode As CDevM6000PLUS.eMode)
    Public Event evRevMode(ByVal bRevMode As Boolean)
    Public Event evBiasValueChange(ByVal Biasvalue As Double)
    Public Event evBiasAmplitudeChange(ByVal Biasvalue As Double)
    Public Event evFrequencyChange(ByVal Biasvalue As Double)
    Public Event evDutyChange(ByVal Biasvalue As Double)
    Public Event evDutyDivisionChange(ByVal bDutyDivision As Boolean)
    Public Event evConstantBrightnessChange(ByVal CBMode As Boolean)


#Region "Structure"


    Structure sSourceSetting
        Dim bEnable As Boolean
        Dim Mode As CDevM6000PLUS.eMode
        Dim bEnableRevMode As Boolean
        Dim dBias As Double
        Dim dAmplitude As Double
        Dim Pulse As sPulse
        Dim nConstantBrightnessMode As Boolean
    End Structure

    Structure sPulse
        Dim dFrequency As Double
        Dim dDuty As Double
        Dim bEnableDutyDivision As Boolean
    End Structure


#End Region

#Region "Enum"
    Public Enum eViewMode
        eAllView
        eMinimum
    End Enum

    Public Enum eConstantBrightness
        ModeOFF
        ModeON
    End Enum
#End Region


#Region "Property"

    Public Property Settings As sSourceSetting
        Get
            GetValueFormUI()
            Return m_sSettings
        End Get
        Set(ByVal value As sSourceSetting)
            SetValueToUI(value)
            m_sSettings = value
        End Set
    End Property

    Public Property Title As String
        Get
            Return gbSource.Text
        End Get
        Set(value As String)
            gbSource.Text = value
        End Set
    End Property

    Public WriteOnly Property SetBiasMode As CDevM6000PLUS.eMode
        Set(ByVal value As CDevM6000PLUS.eMode)
            cbBiasMode.SelectedIndex = value
        End Set
    End Property

    Public WriteOnly Property SetReverse As Boolean
        Set(ByVal value As Boolean)
            chkBiasReverse.Checked = value
        End Set
    End Property

    Public WriteOnly Property SetValue As Double
        Set(ByVal value As Double)
            txtBiasValue.Text = value
        End Set
    End Property

    Public WriteOnly Property SetAmplitude As Double
        Set(ByVal value As Double)
            txtAmplitude.Text = value
        End Set
    End Property

    Public WriteOnly Property SetFrequency As Double
        Set(ByVal value As Double)
            txtFrequency.Text = value
        End Set
    End Property

    Public WriteOnly Property SetDuty As Double
        Set(ByVal value As Double)
            txtDuty.Text = value
        End Set
    End Property

    Public WriteOnly Property SetDutyDivisionMod As Boolean
        Set(ByVal value As Boolean)
            chkDutuDivision.Checked = value
        End Set
    End Property

    Public WriteOnly Property SetConstantBrightness As Boolean
        Set(ByVal value As Boolean)
            chkConstantBrightness.Checked = value
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

                Case eViewMode.eMinimum

                    Dim XStartPoint As Integer = 10
                    Dim YStartPoint As Integer = 20

                    Dim XStepSize As Integer = 15
                    Dim YStepSize As Integer = 8

                    Dim UnitStepSize As Integer = 6

                    lblMode.Text = "Mode"
                    lblMode.Location = New Point(XStartPoint, YStartPoint)
                    cbBiasMode.Location = New Point(XStartPoint, lblMode.Location.Y + lblMode.Size.Height + YStepSize)

                    lblSetRev.Text = "Set Rev"
                    lblSetRev.Location = New Point((cbBiasMode.Location.X + cbBiasMode.Size.Width + XStepSize), YStartPoint)
                    chkBiasReverse.Location = New Point((cbBiasMode.Location.X + cbBiasMode.Size.Width + XStepSize + 2), lblSetRev.Location.Y + lblSetRev.Size.Height + YStepSize + 1)

                    lblValue.Text = "Value"
                    lblValue.Location = New Point((lblSetRev.Location.X + lblSetRev.Size.Width + XStepSize), YStartPoint)
                    txtBiasValue.Location = New Point((lblSetRev.Location.X + lblSetRev.Size.Width + XStepSize), lblValue.Size.Height + lblValue.Location.Y + YStepSize)
                    lblValueUnit.Location = New Point((txtBiasValue.Location.X + txtBiasValue.Size.Width + UnitStepSize), txtBiasValue.Location.Y + 3)

                    lblAmplitude.Text = "Amplitude"
                    lblAmplitude.Location = New Point(lblValueUnit.Location.X + lblValueUnit.Size.Width + XStepSize, YStartPoint)
                    txtAmplitude.Location = New Point(lblValueUnit.Location.X + lblValueUnit.Size.Width + XStepSize, lblAmplitude.Size.Height + lblAmplitude.Location.Y + YStepSize)
                    lblAmpUnit.Location = New Point(txtAmplitude.Location.X + txtAmplitude.Size.Width + UnitStepSize, lblAmplitude.Size.Height + lblAmplitude.Location.Y + YStepSize + 3)

                    lblFrequency.Text = "Frequency"
                    lblFrequency.Location = New Point(lblAmpUnit.Location.X + lblAmpUnit.Size.Width + XStepSize, YStartPoint)
                    txtFrequency.Location = New Point(lblAmpUnit.Location.X + lblAmpUnit.Size.Width + XStepSize, lblFrequency.Size.Height + lblFrequency.Location.Y + YStepSize)
                    lblFrequencyUnit.Location = New Point(txtFrequency.Location.X + txtFrequency.Size.Width + UnitStepSize, lblFrequency.Size.Height + lblFrequency.Location.Y + YStepSize + 3)

                    lblDuty.Text = "Duty"
                    lblDuty.Location = New Point(lblFrequencyUnit.Location.X + lblFrequencyUnit.Size.Width + XStepSize, YStartPoint)

                    'Dim DutyMode As Label = New Label ' 신규 추가

                    'With DutyMode
                    '    .Name = "lblDutyMode"
                    '    .Size = New Size(10, 20)
                    '    .Text = "1/"
                    '    .Visible = True
                    'End With

                    'DutyMode.Location = New Point(lblFrequencyUnit.Location.X + lblFrequencyUnit.Size.Width + XStepSize, lblDuty.Size.Height + lblDuty.Location.Y + YStepSize)
                    'txtDuty.Location = New Point(DutyMode.Location.X + DutyMode.Size.Width + UnitStepSize, lblDuty.Size.Height + lblDuty.Location.Y + YStepSize)
                    txtDuty.Location = New Point(lblFrequencyUnit.Location.X + lblFrequencyUnit.Size.Width + XStepSize, lblDuty.Size.Height + lblDuty.Location.Y + YStepSize)
                    lblDutyPercent.Location = New Point(txtDuty.Location.X + txtDuty.Size.Width + UnitStepSize, lblDuty.Size.Height + lblDuty.Location.Y + YStepSize + 3)
                    chkDutuDivision.Location = New Point(lblDutyPercent.Location.X + lblDutyPercent.Size.Width + UnitStepSize, lblDuty.Size.Height + lblDuty.Location.Y + YStepSize + 4)
                    chkConstantBrightness.Location = New Point(chkDutuDivision.Location.X + chkDutuDivision.Size.Width + UnitStepSize + 10, lblDuty.Size.Height + lblDuty.Location.Y + YStepSize - 3)

                    gbSource.Location = New Point(0, 0)
                    gbSource.Size = New Size(chkDutuDivision.Location.X + UnitStepSize, chkDutuDivision.Location.Y + UnitStepSize)

                    btnAdd.Visible = False

            End Select

        End Set
    End Property

    Public WriteOnly Property VisibleChkEnable As Boolean
        Set(ByVal value As Boolean)
            chkEnable.Visible = value
        End Set
    End Property

    Public WriteOnly Property EnabledSourceMode As Boolean
        Set(ByVal value As Boolean)
            ' lblMode.Enabled = value
            cbBiasMode.Enabled = value
        End Set
    End Property

    Public WriteOnly Property EnabledBias As Boolean
        Set(ByVal value As Boolean)
            ' lblValue.Enabled = value
            ' lblValueUnit.Enabled = value
            txtBiasValue.Enabled = value
        End Set
    End Property

    Public WriteOnly Property VisibleSourceMode As Boolean
        Set(ByVal value As Boolean)
            lblMode.Visible = value
            cbBiasMode.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleSetRev As Boolean
        Set(ByVal value As Boolean)
            lblSetRev.Visible = value
            chkBiasReverse.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleBias As Boolean
        Set(ByVal value As Boolean)
            lblValue.Visible = value
            txtBiasValue.Visible = value
            lblValueUnit.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleAmplitude As Boolean
        Set(ByVal value As Boolean)
            lblAmplitude.Visible = value
            txtAmplitude.Visible = value
            lblAmpUnit.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleFrequency As Boolean
        Set(ByVal value As Boolean)
            lblFrequency.Visible = value
            txtFrequency.Visible = value
            lblFrequencyUnit.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleDuty As Boolean
        Set(ByVal value As Boolean)
            lblDuty.Visible = value
            txtDuty.Visible = value
            lblDutyPercent.Visible = value
            chkDutuDivision.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleConstantBright As Boolean
        Set(ByVal value As Boolean)
            chkConstantBrightness.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleBtnADD As Boolean
        Set(ByVal value As Boolean)
            btnAdd.Visible = value
        End Set
    End Property

#End Region

#End Region

#Region "Creator and init"

    Public Sub New()
        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()


        gbSource.Location = New System.Drawing.Point(2, chkEnable.Location.Y + chkEnable.Size.Height + 10)

        With cbBiasMode
            .Items.Clear()
            For i As Integer = 0 To m_sCaptions_SrcMode.Length - 1
                .Items.Add(m_sCaptions_SrcMode(i))
            Next
            .SelectedIndex = 0
        End With

        chkEnable.Checked = True
        'With cbONOFF
        '    .Items.Clear()
        '    For i As Integer = 0 To sMode.Length - 1
        '        .Items.Add(sONOFF(i))
        '    Next
        '    .SelectedIndex = 0
        'End With
    End Sub

#End Region

    Private Sub GetValueFormUI()

        With m_sSettings

            .bEnable = chkEnable.Checked
            .Mode = cbBiasMode.SelectedIndex
            .dBias = CDbl(txtBiasValue.Text)
            .bEnableRevMode = chkBiasReverse.Checked

            .dAmplitude = CDbl(txtAmplitude.Text)
            .Pulse.dFrequency = CDbl(txtFrequency.Text)
            .Pulse.dDuty = CDbl(txtDuty.Text)
            .Pulse.bEnableDutyDivision = chkDutuDivision.Checked

            .nConstantBrightnessMode = chkConstantBrightness.Checked
        End With

    End Sub

    Private Sub SetValueToUI(ByVal Settings As sSourceSetting)

        'With Settings

        '    cbBiasMode.SelectedIndex = .Mode
        '    txtBiasValue.Text = .dBias

        '    chkBiasReverse.Checked = .bEnableRevMode
        '    txtAmplitude.Text = .dAmplitude
        '    txtFrequency.Text = .Pulse.dFrequency
        '    txtDuty.Text = .Pulse.dDuty
        '    chkBiasReverse.Checked = .Pulse.bEnableDutyDivision
        'End With
        With Settings

            chkEnable.Checked = .bEnable
            gbSource.Enabled = .bEnable
            cbBiasMode.SelectedIndex = .Mode
            txtBiasValue.Text = .dBias

            chkBiasReverse.Checked = .bEnableRevMode
            txtAmplitude.Text = .dAmplitude
            txtFrequency.Text = .Pulse.dFrequency
            txtDuty.Text = .Pulse.dDuty
            chkDutuDivision.Checked = .Pulse.bEnableDutyDivision
            chkConstantBrightness.Checked = .nConstantBrightnessMode
        End With
    End Sub

    Private Sub chkDutyMod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDutuDivision.CheckedChanged

        If chkDutuDivision.Checked = True Then
            lblDutyPercent.Text = ""
            lblDuty.Text = "Duty : 1/"
        Else
            lblDutyPercent.Text = "%"
            lblDuty.Text = "    Duty :"
        End If

        RaiseEvent evDutyDivisionChange(chkDutuDivision.Checked)

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        GetValueFormUI()
        RaiseEvent evAddSettings(m_sSettings)
    End Sub

    Private Sub chkBiasReverse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBiasReverse.CheckedChanged
        If chkBiasReverse.Checked = True Then
            txtBiasValue.BackColor = Color.Red
            txtAmplitude.BackColor = Color.Red
            chkBiasReverse.Text = "(-)"
        ElseIf chkBiasReverse.Checked = False Then
            txtBiasValue.BackColor = Color.White
            txtAmplitude.BackColor = Color.White
            chkBiasReverse.Text = "(+)"
        End If

        RaiseEvent evRevMode(chkBiasReverse.Checked)

    End Sub

    Private Sub cbONOFF_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbBiasMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBiasMode.SelectedIndexChanged
        Select Case cbBiasMode.SelectedItem
            Case "CC"
                lblValueUnit.Text = "mA"
                lblAmpUnit.Text = "mA"
                txtAmplitude.Enabled = False
                txtFrequency.Enabled = False
                txtDuty.Enabled = False
                chkConstantBrightness.Enabled = True

            Case "CV"
                lblValueUnit.Text = "V"
                lblAmpUnit.Text = "V"
                txtAmplitude.Enabled = False
                txtFrequency.Enabled = False
                txtDuty.Enabled = False
                chkConstantBrightness.Enabled = True

            Case "PC"
                lblValueUnit.Text = "mA"
                lblAmpUnit.Text = "mA"
                txtAmplitude.Enabled = True
                txtFrequency.Enabled = True
                txtDuty.Enabled = True

                chkConstantBrightness.Enabled = False
                chkConstantBrightness.Checked = False
            Case "PV"
                lblValueUnit.Text = "V"
                lblAmpUnit.Text = "V"
                txtAmplitude.Enabled = True
                txtFrequency.Enabled = True
                txtDuty.Enabled = True

                chkConstantBrightness.Enabled = False
                chkConstantBrightness.Checked = False
            Case "PCV"
                lblValueUnit.Text = "V"
                lblAmpUnit.Text = "mA"
                txtAmplitude.Enabled = True
                txtFrequency.Enabled = True
                txtDuty.Enabled = True

                chkConstantBrightness.Enabled = False
                chkConstantBrightness.Checked = False
        End Select


        RaiseEvent evSourceModeChange(cbBiasMode.SelectedIndex)

    End Sub

    Private Sub chkConstantBrightness_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConstantBrightness.CheckedChanged
        'If chkConstantBrightness.Checked = False Then
        '    m_LifetimeInfos.sCommon.nConstantBrightnessMode = eConstantBrightness.ModeOFF
        'ElseIf chkConstantBrightness.Checked = True Then
        '    m_LifetimeInfos.sCommon.nConstantBrightnessMode = eConstantBrightness.ModeON
        'End If

        RaiseEvent evConstantBrightnessChange(chkConstantBrightness.Checked)
    End Sub

    Private Sub txtBiasValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBiasValue.TextChanged

        Dim TempText() As String = Split(txtBiasValue.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지



        Dim dValue As Double
        Dim Setting As frmOptionWindow.sOPTIONDATa = Nothing

        Try

            frmOptionWindow.LoadSystemOption(Setting)   'LEX_20140325

            If cbBiasMode.SelectedIndex = 0 Then
                Setting.ParamRange.sPMX.Min.dBias = -50
                Setting.ParamRange.sPMX.Max.dBias = 50
            ElseIf cbBiasMode.SelectedIndex = 1 Then
                Setting.ParamRange.sPMX.Min.dBias = -20
                Setting.ParamRange.sPMX.Max.dBias = 20
            End If


            If Setting.ParamRange.sPMX.Min.dBias > txtBiasValue.Text Or Setting.ParamRange.sPMX.Max.dBias < txtBiasValue.Text Then
                MsgBox("범위를 벗어났습니다.")
                txtBiasValue.Text = 0
                Exit Sub
            Else
                dValue = CDbl(txtBiasValue.Text)
            End If

        Catch ex As Exception
            dValue = 0
            Exit Sub
        End Try

        RaiseEvent evBiasValueChange(dValue)
    End Sub

    Private Sub txtAmplitude_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmplitude.TextChanged

        Dim TempText() As String = Split(txtAmplitude.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Dim dValue As Double
        Try
            dValue = CDbl(txtAmplitude.Text)
        Catch ex As Exception
            dValue = 0
            Exit Sub
        End Try
        If txtAmplitude.Text <> "" Then
            RaiseEvent evBiasAmplitudeChange(dValue)
        End If
    End Sub

    Private Sub txtFrequency_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFrequency.TextChanged
        'If txtFrequency.Text <> "" Then
        '    RaiseEvent evFrequencyChange(CDbl(txtFrequency.Text))
        'End If

        Dim TempText() As String = Split(txtFrequency.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Try
            RaiseEvent evFrequencyChange(CDbl(txtFrequency.Text))
        Catch ex As Exception
            ' dValue = 0
            Exit Sub
        End Try

    End Sub

    Private Sub txtDuty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDuty.TextChanged
        'If txtDuty.Text <> "" Then
        '    RaiseEvent evDutyChange(CDbl(txtDuty.Text))
        'End If
        Dim TempText() As String = Split(txtDuty.Text, ".")
        Dim TempText2 As String = ""

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Try
            RaiseEvent evDutyChange(CDbl(txtDuty.Text))
        Catch ex As Exception
            ' dValue = 0
            Exit Sub
        End Try
    End Sub


    Private Sub ucDispCellLifetime_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

    End Sub

    Private Sub chkEnable_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkEnable.CheckedChanged
        m_sSettings.bEnable = chkEnable.Checked
        gbSource.Enabled = chkEnable.Checked
    End Sub
End Class
