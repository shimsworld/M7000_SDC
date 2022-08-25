Public Class ucConfigMotion


#Region "Define"

    Private Event evAddConfigList()

    Dim m_sConfigData() As CDevMotion_AJIN.sMotionParams
    Dim m_nCnt As Integer = 0

    Property Setting() As CDevMotion_AJIN.sMotionParams()
        Get
            Return m_sConfigData
        End Get
        Set(ByVal value As CDevMotion_AJIN.sMotionParams())
            If value Is Nothing = False Then
                m_sConfigData = value
                m_nCnt = m_sConfigData.Length
                UpdateConfigList()
            End If
        End Set
    End Property


#End Region

#Region "Creator, Disposer and init"


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        init()
    End Sub

    Private Sub init()
        gbConfig.Location = New System.Drawing.Point(0, 0)
        gbConfig.Dock = DockStyle.Fill
    End Sub
#End Region



    Private Function GetValueFromUI(ByRef ConfigData As CDevMotion_AJIN.sMotionParams) As Boolean

        Try
            ConfigData.ePulseOutMethod = cbo_pulsemethod.SelectedIndex
            ConfigData.eEncInputMethod = cbo_encodermethod.SelectedIndex
            ConfigData.eMotionAxis = cbo_axis.SelectedIndex
            ConfigData.eMotionAxisInverting = cb_AixsInverting.SelectedIndex
            ConfigData.dVelocity = tbVelocity.Text
            ConfigData.dAcceleration = tbAccel.Text
            ConfigData.dDeceleration = tbDecel.Text
            ConfigData.dStartSpeed = tbStartSpeed.Text
            ConfigData.dUnitPulse = tbUnitPulse.Text
            ConfigData.dMaxSpeed = tbMaximumSpeed.Text
            ConfigData.dHomeSpeed = tbHomeSpeed.Text
            ConfigData.bDirectionInverting = CBool(cbo_DirectionInverting.SelectedIndex)

            'If chkSlowLimit_Plus.Checked = True Then
            '    ConfigData.nIO_Limit_P = CDevMotion_AJIN.eSTATE._ON
            'Else
            '    ConfigData.nIO_Limit_P = CDevMotion_AJIN.eSTATE._OFF
            'End If

            'If chkSlowLimit_Minus.Checked = True Then
            '    ConfigData.nIO_Limit_M = CDevMotion_AJIN.eSTATE._ON
            'Else
            '    ConfigData.nIO_Limit_M = CDevMotion_AJIN.eSTATE._OFF
            'End If

            'If chkSpeedLimit_Plus.Checked = True Then
            '    ConfigData.nIO_SLimit_P = CDevMotion_AJIN.eSTATE._ON
            'Else
            '    ConfigData.nIO_SLimit_P = CDevMotion_AJIN.eSTATE._OFF
            'End If

            'If chkSpeedLimit_Minus.Checked = True Then
            '    ConfigData.nIO_SLimit_M = CDevMotion_AJIN.eSTATE._ON
            'Else
            '    ConfigData.nIO_SLimit_M = CDevMotion_AJIN.eSTATE._OFF
            'End If

            'If chkAlarm.Checked = True Then
            '    ConfigData.nIO_Alarm = CDevMotion_AJIN.eSTATE._ON
            'Else
            '    ConfigData.nIO_Alarm = CDevMotion_AJIN.eSTATE._OFF
            'End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try

        Return True
    End Function


    Private Sub SetValueToUI(ByVal ConfigData As CDevMotion_AJIN.sMotionParams)

        With ConfigData
            cbo_pulsemethod.SelectedIndex = ConfigData.ePulseOutMethod
            cbo_encodermethod.SelectedIndex = ConfigData.eEncInputMethod
            cbo_axis.SelectedIndex = ConfigData.eMotionAxis
            cb_AixsInverting.SelectedIndex = ConfigData.eMotionAxisInverting
            tbVelocity.Text = ConfigData.dVelocity
            tbAccel.Text = ConfigData.dAcceleration
            tbDecel.Text = ConfigData.dDeceleration
            tbStartSpeed.Text = ConfigData.dStartSpeed
            tbUnitPulse.Text = ConfigData.dUnitPulse
            tbMaximumSpeed.Text = ConfigData.dMaxSpeed
            tbHomeSpeed.Text = ConfigData.dHomeSpeed
            If ConfigData.bDirectionInverting = False Then
                cbo_DirectionInverting.SelectedIndex = 0
            Else
                cbo_DirectionInverting.SelectedIndex = 1
            End If

            'If ConfigData.nIO_Limit_P = CDevMotion_AJIN.eSTATE._ON Then
            '    chkSlowLimit_Plus.Checked = True
            'Else
            '    chkSlowLimit_Plus.Checked = False
            'End If

            'If ConfigData.nIO_Limit_M = CDevMotion_AJIN.eSTATE._ON Then
            '    chkSlowLimit_Minus.Checked = True
            'Else
            '    chkSlowLimit_Minus.Checked = False
            'End If

            'If ConfigData.nIO_SLimit_P = CDevMotion_AJIN.eSTATE._ON Then
            '    chkSpeedLimit_Plus.Checked = True
            'Else
            '    chkSpeedLimit_Plus.Checked = False
            'End If
            'If ConfigData.nIO_SLimit_M = CDevMotion_AJIN.eSTATE._ON Then
            '    chkSpeedLimit_Minus.Checked = True
            'Else
            '    chkSpeedLimit_Minus.Checked = False
            'End If

            'If ConfigData.nIO_Alarm = CDevMotion_AJIN.eSTATE._ON Then
            '    chkAlarm.Checked = True
            'Else
            '    chkAlarm.Checked = False
            'End If

        End With
    End Sub

#Region "Config 정보 배열 ADD, Delete Function"

    Private Sub addConfigData(ByVal ConfigData As CDevMotion_AJIN.sMotionParams)

        ReDim Preserve m_sConfigData(m_nCnt)

        m_sConfigData(m_nCnt) = ConfigData

        m_nCnt += 1
    End Sub

    Private Sub delConfigData(ByVal nIdx As Integer)
        If m_sConfigData Is Nothing Then Exit Sub

        If m_sConfigData.Length <= nIdx Then Exit Sub

        If m_sConfigData.Length = 1 Then
            m_sConfigData = Nothing
            m_nCnt = 0
        Else
            m_nCnt -= 1

            Dim configBuf(m_nCnt - 1) As CDevMotion_AJIN.sMotionParams
            Dim n As Integer = 0
            For i As Integer = 0 To m_sConfigData.Length - 1
                If i <> nIdx Then
                    configBuf(n) = m_sConfigData(i)
                    n += 1
                End If
            Next

            m_sConfigData = configBuf.Clone
        End If
    End Sub

#End Region



    Private Sub addConfigList(ByVal idx As Integer, ByVal ConfigData As CDevMotion_AJIN.sMotionParams)
        Dim sData(12) As String
        With ConfigData
            sData(0) = Format(idx, "00")
            sData(1) = .ePulseOutMethod.ToString
            sData(2) = .eEncInputMethod.ToString
            sData(3) = .eMotionAxis.ToString
            sData(4) = .eMotionAxisInverting.ToString
            sData(5) = .dVelocity
            sData(6) = .dAcceleration
            sData(7) = .dDeceleration
            sData(8) = .dUnitPulse
            sData(9) = .dStartSpeed
            sData(10) = .dMaxSpeed
            sData(11) = CStr(.bDirectionInverting)
            sData(12) = .dHomeSpeed
        End With
        ConfigList.AddRowData(sData)
    End Sub

    Private Sub UpdateConfigList()

        ConfigList.ClearAllData()
        If m_sConfigData Is Nothing Then Exit Sub
        For i As Integer = 0 To m_sConfigData.Length - 1
            addConfigList(i, m_sConfigData(i))
        Next

    End Sub

    Private Sub ModifyConfigList(ByVal idx As Integer, ByVal configdata As CDevMotion_AJIN.sMotionParams)
        m_sConfigData(idx) = configdata
        UpdateConfigList()
    End Sub



    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click

        Dim sConfig As CDevMotion_AJIN.sMotionParams = Nothing

        GetValueFromUI(sConfig)

        addConfigData(sConfig)

        UpdateConfigList()

    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Dim sConfig As CDevMotion_AJIN.sMotionParams = Nothing
        Dim selectedRow As Integer
        Dim retCode As ucDispListView.eUcListErrCode

        retCode = ConfigList.GetSelectedRowNumber(selectedRow)
        If retCode <> ucDispListView.eUcListErrCode.eNoError Then
            MsgBox(retCode.ToString)
            Exit Sub
        End If

        GetValueFromUI(sConfig)

        ModifyConfigList(selectedRow, sConfig)

    End Sub


    Private Sub btnListDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListDel.Click
        Dim SelectedNo As Integer
        ConfigList.GetSelectedRowNumber(SelectedNo)
        delConfigData(SelectedNo)
        UpdateConfigList()

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        m_sConfigData = Nothing
        m_nCnt = 0
        ConfigList.ClearAllData()

    End Sub



    Private Sub ConfigList_evSelectedIndexChanged(ByVal nRow As Integer) Handles ConfigList.evSelectedIndexChanged
        Dim configBuf As CDevMotion_AJIN.sMotionParams

        If m_sConfigData Is Nothing Then Exit Sub

        configBuf = m_sConfigData(nRow)

        SetValueToUI(configBuf)
    End Sub


    Private Sub chkSpeedLimit_Plus_CheckedChanged(sender As Object, e As EventArgs)
        'If chkSpeedLimit_Plus.Checked = True Then
        '    lblIO_Limit_P.BackColor = Color.Red
        'Else
        '    lblIO_Limit_P.BackColor = Color.Gainsboro
        'End If
    End Sub

    Private Sub chkSpeedLimit_Minus_CheckedChanged(sender As Object, e As EventArgs)
        'If chkSpeedLimit_Minus.Checked = True Then
        '    lblIO_Limit_M.BackColor = Color.Red
        'Else
        '    lblIO_Limit_M.BackColor = Color.Gainsboro
        'End If
    End Sub

    Private Sub chkSlowLimit_Plus_CheckedChanged(sender As Object, e As EventArgs)
        'If chkSlowLimit_Plus.Checked = True Then
        '    lblIO_SLimit_P.BackColor = Color.Red
        'Else
        '    lblIO_SLimit_P.BackColor = Color.Gainsboro
        'End If
    End Sub

    Private Sub chkSlowLimit_Minus_CheckedChanged(sender As Object, e As EventArgs)
        'If chkSlowLimit_Minus.Checked = True Then
        '    lblIO_SLimit_M.BackColor = Color.Red
        'Else
        '    lblIO_SLimit_M.BackColor = Color.Gainsboro
        'End If
    End Sub

    Private Sub chkAlarm_CheckedChanged(sender As Object, e As EventArgs)
        'If chkAlarm.Checked = True Then
        '    lblIO_Alarm.BackColor = Color.Red
        'Else
        '    lblIO_Alarm.BackColor = Color.Gainsboro
        'End If
    End Sub
End Class
