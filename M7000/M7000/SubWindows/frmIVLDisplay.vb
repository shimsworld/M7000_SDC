Public Class frmIVLDisplay

    Dim m_Main As frmMain
    Dim m_Test As CSeqProcessor
    Dim m_DisplayMode As ucSequenceBuilder.eRcpMode

#Region "Define"
    Dim sIVLDataHeaders() As String = New String() {"No.", "Mode", "Area(cm^2)", "Temperature('C)", "Voltage(V)", "Current(A)", "J(mA/cm^2)", "Abs J(mA/cm^2)", _
                                                    "Luminance(cd/m^2)", "Current Efficiency(cd/A)", "Power Efficiency(Im/W)", "QE(%)", _
                                                    "CIE_x", "CIE_y", "CIE_u'", "CIE_v'", "CCT"}


    Dim sViewAngleDataHeaders() As String = New String() {"No.", "Mode", "Area(cm^2)", "Temperature('C)", "Voltage(V)", "Current(A)", "J(mA/cm^2)", "Abs J(mA/cm^2)", _
                                                    "Luminance(cd/m^2)", "Current Efficiency(cd/A)", "Power Efficiency(Im/W)", "QE(%)", _
                                                    "CIE_x", "CIE_y", "CIE_u'", "CIE_v'", "CCT", "Angle(')"}
    '{"No.", "Mode", "Color", "Area(cm^2)", "Temperature('C)", _
    '                                                          "Voltage(V)_Red", "Current(A)_Red", "Voltage(V)_Green", "Current(A)_Green", "Voltage(V)_Blue", "Current(A)_Blue", "Tot_Currnet(A)", _
    '                                                          "J(mA/cm^2)", "Abs J(mA/cm^2)", "Angle(')", "Luminance(cd/m^2)", "Current Efficiency(cd/A)", "QE(%)", _
    '                                                          "CIE_x", "CIE_y", "CIE_u'", "CIE_v'", "delta_u'v'", "CCT"}

  
    ' Dim sData() As String
    Public m_bIsStopIVL As Boolean = False

    Public Property IsStopIVL As Boolean
        Get
            Return m_bIsStopIVL
        End Get
        Set(ByVal value As Boolean)
            m_bIsStopIVL = value
        End Set
    End Property

#End Region


#Region "Delegate"


    Private Delegate Sub DelCallSub()
    'Private Delegate Sub DelClearSub()
    'Private Delegate Sub DelList(ByVal sData() As String)
    'Private Delegate Sub DelPlotData(ByVal sData() As frmMain.sIVLMeasure)
    'Private Delegate Sub DelPlotMode(ByVal nMode As ucDispGraph.eIVLPlotMode)
    Private Delegate Sub delinteger(ByVal nValue As Integer)
    Private Delegate Sub delString(ByVal strValue As String)

    Public Sub ShowFrame()
        If Me.InvokeRequired = True Then
            Dim Del2 As DelCallSub = New DelCallSub(AddressOf ShowFrame)
            Try
                Invoke(Del2, Nothing)
            Catch ex As Exception
                Exit Sub
            End Try
        Else

            Try
                Me.Show()

            Catch w As System.ComponentModel.Win32Exception

                Console.WriteLine(w.Message)
                Console.WriteLine(w.ErrorCode.ToString())
                Console.WriteLine(w.NativeErrorCode.ToString())
                Console.WriteLine(w.StackTrace)
                Console.WriteLine(w.Source)
                Dim e As New Exception()
                e = w.GetBaseException()
                Console.WriteLine(e.Message)
            End Try
        End If
    End Sub


    Public Sub HideFrame()
        If Me.InvokeRequired = True Then
            Dim Del2 As DelCallSub = New DelCallSub(AddressOf HideFrame)
            Try
                Invoke(Del2, Nothing)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            Me.Hide()
        End If
    End Sub

    Public Sub ChannelInfo(ByVal nCh As Integer)
        If Me.InvokeRequired = True Then
            Dim Del As delinteger = New delinteger(AddressOf ChannelInfo)
            Try
                Invoke(Del, nCh)
            Catch ex As Exception
                Exit Sub
            End Try
        Else

            Me.Text = "Sweep Indicator" & " [TEG" & ucDispJIG.convertIncNumberToMatrixValue(nCh) & "]" '& "-" & Format(CInt(nCh) + 1, "00") & "]" ' "/ CH" & Format(CInt(nCh) + 1, "00") & "]"
            lblChannel.Text = "[TEG" & ucDispJIG.convertIncNumberToMatrixValue(nCh) & "]" '& "-" & Format(CInt(nCh) + 1, "00") & "]"
        End If

    End Sub

    Public Sub SweepMode(ByVal mode As String)
        If Me.InvokeRequired = True Then
            Dim Del As delString = New delString(AddressOf SweepMode)
            Try
                Invoke(Del, mode)
            Catch ex As Exception
                Exit Sub
            End Try
        Else
            lblSweepMode.Text = mode
        End If
    End Sub
    'Private Sub SetDataDisplay(ByVal sData() As String)  'ByVal label As System.Windows.Forms.StatusStrip,
    '    If dispListView.InvokeRequired = True Then
    '        Dim del2 As DelList = New DelList(AddressOf SetDataDisplay)
    '        Try
    '            Invoke(del2, sData)
    '        Catch ex As Exception
    '            Exit Sub
    '        End Try
    '    Else
    '        dispListView.AddRowData(sData)
    '    End If
    'End Sub

    'Private Sub DataClear()
    '    If Me.InvokeRequired = True Then
    '        Dim Del2 As DelCallSub = New DelCallSub(AddressOf DataClear)
    '        Try
    '            Invoke(Del2, Nothing)
    '        Catch ex As Exception
    '            Exit Sub
    '        End Try
    '    Else
    '        dispListView.ClearAllData()

    '    End If
    'End Sub

    'Private Sub SetPlotDisplay(ByVal measureData() As frmMain.sIVLMeasure)  'ByVal label As System.Windows.Forms.StatusStrip,
    '    If dispGraph.InvokeRequired = True Then
    '        Dim del2 As DelPlotData = New DelPlotData(AddressOf SetPlotDisplay)
    '        Try
    '            Invoke(del2, measureData)
    '        Catch ex As Exception
    '            Exit Sub
    '        End Try
    '    Else
    '        dispGraph.SetPlotData(measureData)
    '    End If
    'End Sub

    'Private Sub SetPoltGraphMode(ByVal nMode As ucDispGraph.eIVLPlotMode)  'ByVal label As System.Windows.Forms.StatusStrip,
    '    If dispGraph.InvokeRequired = True Then
    '        Dim del2 As DelPlotMode = New DelPlotMode(AddressOf SetPoltGraphMode)
    '        Try
    '            Invoke(del2, nMode)
    '        Catch ex As Exception
    '            Exit Sub
    '        End Try
    '    Else
    '        SetPoltGraphMode(nMode)
    '    End If
    'End Sub

#End Region



#Region "Create, Dispose and init"
    Public Sub New(ByVal nDisplayMode As ucSequenceBuilder.eRcpMode)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        ' m_Main = main
        m_DisplayMode = nDisplayMode
        Init()
        '  m_Config = config
    End Sub
#End Region


    Public Sub Init()

        spContainer.Location = New System.Drawing.Point(0, 0)
        spContainer.Dock = DockStyle.Fill

        TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill

        TableLayoutPanel2.Dock = DockStyle.Fill

        btnStop.Location = New System.Drawing.Point(0, 0)
        btnStop.Dock = DockStyle.Fill

        btnHide.Location = New System.Drawing.Point(0, 0)
        btnHide.Dock = DockStyle.Fill

        dispGraph.Location = New System.Drawing.Point(0, 0)
        dispGraph.Dock = DockStyle.Fill
        dispGraph2.Dock = DockStyle.Fill
        dispGraph3.Dock = DockStyle.Fill
        dispGraph4.Dock = DockStyle.Fill
        'dispGraph5.Dock = DockStyle.Fill
        'dispGraph6.Dock = DockStyle.Fill

        dispListView.Location = New System.Drawing.Point(0, 0)
        dispListView.Dock = DockStyle.Fill

        lblMeasStatus.Location = New System.Drawing.Point(0, 0)
        lblMeasStatus.Dock = DockStyle.Fill

        
        Dim sBufHeaders() As String = Nothing

        Select Case m_DisplayMode
            Case ucSequenceBuilder.eRcpMode.eCell_IVL, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                sBufHeaders = g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItemName.Clone
            Case ucSequenceBuilder.eRcpMode.eViewingAngle
                sBufHeaders = g_SystemOptions.sOptionData.SaveOptions.nDataVAPlotItemName.Clone
        End Select

        'If m_DisplayMode = ucSequenceBuilder.eRcpMode.eCell_IVL Then
        '    sBufHeaders = g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItemName.Clone
        'ElseIf m_DisplayMode = ucSequenceBuilder.eRcpMode.eViewingAngle Then
        '    sBufHeaders = sViewAngleDataHeaders.Clone
        'End If

        dispListView.ColHeader = sBufHeaders.Clone
        Dim colWidthRatio As String = ""

        Dim nWidth As Integer = Fix(190 / sBufHeaders.Length)
        For i As Integer = 0 To sBufHeaders.Length - 1
            colWidthRatio = colWidthRatio & "," & CStr(nWidth)
        Next
        colWidthRatio = colWidthRatio.TrimStart(",")
        'colWidthRatio = "6,7,10"
        'Dim nWidth As Integer = Fix(190 / (sBufHeaders.Length - 2))
        'For i As Integer = 0 To sBufHeaders.Length - 4
        '    colWidthRatio = colWidthRatio & "," & CStr(nWidth)
        'Next

        dispListView.ColHeaderWidthRatio = colWidthRatio
        dispListView.ClearAllData()

    End Sub

    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click
        HideFrame()
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        lblMeasStatus.Text = "STOP"
        lblMeasStatus.ForeColor = Color.OrangeRed
        m_bIsStopIVL = True
    End Sub

End Class