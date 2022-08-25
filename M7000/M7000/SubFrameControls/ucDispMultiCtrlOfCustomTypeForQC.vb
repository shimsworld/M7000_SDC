Public Class ucDispMultiCtrlOfCustomTypeForQC
    Inherits ucDispMultiCtrlCommonNode

    'Public dispChannel() As ucDispCtrlUIOfCustomTypeForQC

    Public Sub New(ByVal maxCh As Integer, ByVal seedIdx As Integer)
        MyBase.New()
        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        MyBase.m_nMaxCh = maxCh
        MyBase.m_nSeedIndex = seedIdx
        MyBase.init()
        MyBase.m_nType = eType.CustomTypeForQC
        Initialization()
    End Sub

#Region "Initialization Custom Control for QC"


    Private Sub Initialization()

        ReDim DispChCustom_QC(m_nMaxCh - 1)

        Me.Size = New Drawing.Size(Me.Size.Width, 100 * g_nMaxCh)

        For i = 0 To m_nMaxCh - 1
            CustomCtrl_SetLocation(i)    ''1
        Next

    End Sub


    ' Dim g_SizeW As Integer = 80
    Dim g_LocOffset_Y As Integer = 8
    Dim g_LocOffset_Y1 As Integer = 3

    Private Sub CustomCtrl_SetLocation(ByVal in_Num As Integer)

        Dim Location_X, Location_Y, Size_H, Size_W As Double
        Dim dH As Integer = 1
        Dim nPontsize As Integer = 12

        Size_H = 105
        Size_W = 1550
        Location_X = 0
        Location_Y = ((Size_H + g_LocOffset_Y1) * in_Num) + g_LocOffset_Y


        DispChCustom_QC(in_Num) = New ucDispCtrlUIOfCustomTypeForQC() '.eType.CustomTypeForQC)

        Me.Controls.Add(DispChCustom_QC(in_Num))
        '    Me.Controls.Add(testButton(in_Num))
        With DispChCustom_QC(in_Num) 'testButton(in_Num) '

            '.AccessibleRole = AccessibleRole.Default
            '.FlatStyle = FlatStyle.Standard
            '.Font = New System.Drawing.Font("Arial", nPontsize, FontStyle.Bold)
            '.BackColor = Color.LightGreen
            .Location = New System.Drawing.Point(Location_X, Location_Y)
            .Size = New System.Drawing.Size(Size_W, Size_H)
            .Channel = MyBase.m_nSeedIndex + in_Num
            '.TextAlign = ContentAlignment.MiddleCenter 'ContentAlignment.MiddleCenter   ' System.Drawing.ContentAlignment.MiddleCenter
            '.TabIndex = in_Num
            '.Tag = in_Num
            '.Text = "CH" & Format(in_Num + 1, "00")
            AddHandler DispChCustom_QC(in_Num).evClickEditSequence, AddressOf EditSequenceButton_Click
            AddHandler DispChCustom_QC(in_Num).evClickLoadSequence, AddressOf LoadSequenceButton_Click
            AddHandler DispChCustom_QC(in_Num).evClickSaveSeqeunce, AddressOf SaveSequenceButton_Click

            ' .fControlWind = Me '체크 테이터 전송용 2013-03-19 승현
        End With

    End Sub


    Private Sub EditSequenceButton_Click(ByVal ch As Integer)

        Dim builder As New frmSequenceBuilder

        If builder.ShowDialog = DialogResult.OK Then

            'MyBase.sequenceMgr(ch) = builder.se
        End If
        ' MsgBox("Click Edit Button Ch" & CStr(ch))
    End Sub

    Private Sub LoadSequenceButton_Click(ByVal ch As Integer)

        'Dim openFileDlg As New OpenFileDialog
        'Dim sFilePath As String
        'With OpenfileDlg
        '    .Title = "LoadFile"
        '    '.Filter = "eoi(*.eoi)|*.eoi"
        '    .Filter = "SEQ(*.Seq)|*.seq"
        '    .InitialDirectory = Application.StartupPath & "\Sequence\"
        '    .AddExtension = True
        'End With


        'If openFileDlg.ShowDialog = DialogResult.OK Then
        '    sFilePath = openFileDlg.FileName

        'End If

        If m_sequenceMgr(ch).LoadTestSequence() = False Then
            MsgBox("Canceled")
        Else
            DispChCustom_QC(ch).RecipeTitle(m_sequenceMgr(ch).SequenceInfo.sSampleInfos.sTitle)
        End If

    End Sub

    Private Sub SaveSequenceButton_Click(ByVal ch As Integer)
        MsgBox("Click Save Button Ch" & CStr(ch))
    End Sub


#End Region


End Class
