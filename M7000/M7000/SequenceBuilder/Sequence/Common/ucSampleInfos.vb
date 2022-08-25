Public Class ucSampleInfos


#Region "Defines & Structure"

    Dim m_SampleInfo As ucSampleInfos.sSampleInfos

    Dim sSampleType() As String = New String() {"Unit Cell", "Panel", "Module"}
    Dim sColor() As String = New String() {"RED", "GREEN", "BLUE", "WHITE"}

    Public Enum eSampleType
        eCell
        ePanel
        eModule
    End Enum

    ''샘플의 컬러 종류에는
    ''단색 물질로 구성된, R,G,B,W 소자와
    ''R,G,B Pixel의 조합으로 W 및 컬러를 생성하는 방식이 있음.

    Public Enum eSampleColor
        _SingleColor_R  'Single color
        _SingleColor_G  'Single color
        _SingleColor_B  'Single color
        _SingleColor_W  'Single color
        _MixedColor     'Mixed Color
    End Enum

    Public Structure sSampleSize
        Dim Height As Double
        Dim Width As Double
    End Structure

    Public Structure sSampleColor
        Dim nDefColor As eSampleColor
        Dim sampleColor As Color
    End Structure

    Public Structure sSampleInfos
        Dim sampleType As eSampleType
        Dim sampleColor As sSampleColor
        Dim sTitle As String
        Dim SampleSize As sSampleSize
        Dim dFillFactor As Double
        Dim sComment As String
    End Structure

#End Region

#Region "Property"

    Public Property Settings As ucSampleInfos.sSampleInfos
        Get
            GetValueFromUI()
            Return m_SampleInfo
        End Get
        Set(ByVal value As ucSampleInfos.sSampleInfos)
            m_SampleInfo = value
            SetValueToUI()
        End Set
    End Property


    Public WriteOnly Property VisibleSeqTitle As Boolean
        Set(ByVal value As Boolean)
            lblTitle.Visible = value
            tbSeqTitle.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleSampleType As Boolean
        Set(ByVal value As Boolean)
            cbSelSampleType.Visible = value
            lblSampleType.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleSampleColor As Boolean
        Set(ByVal value As Boolean)
            cbSampleColor.Visible = value
            lblSampleColor.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleSampleSize As Boolean
        Set(ByVal value As Boolean)
            gbSampleSize.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleFillFactor As Boolean
        Set(ByVal value As Boolean)
            gbFillFactor.Visible = value
        End Set
    End Property

    Public WriteOnly Property VisibleComment As Boolean
        Set(ByVal value As Boolean)
            gbComment.Visible = value
        End Set
    End Property

#End Region

#Region "Creator"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub

    Private Sub init()
        tbComment.Location = New System.Drawing.Point(0, 0)
        tbComment.Dock = DockStyle.Fill

        ' gbCommon.Visible = False

        With cbSelSampleType
            .Items.Clear()
            For i As Integer = 0 To sSampleType.Length - 1
                .Items.Add(sSampleType(i))
            Next
            .SelectedIndex = 0
        End With

        With cbSampleColor
            .Items.Clear()
            For i As Integer = 0 To sColor.Length - 1
                .Items.Add(sColor(i))
            Next
            .SelectedIndex = 3
        End With

    End Sub

#End Region


#Region "Functions"

    Private Sub GetValueFromUI()

        With m_SampleInfo
            .sampleType = cbSelSampleType.SelectedIndex
            .sTitle = tbSeqTitle.Text
            .sComment = tbComment.Text
            .sampleColor.nDefColor = cbSampleColor.SelectedIndex
            Select Case .sampleColor.nDefColor
                Case ucSampleInfos.eSampleColor._SingleColor_R
                    .sampleColor.sampleColor = Color.Red
                Case ucSampleInfos.eSampleColor._SingleColor_G
                    .sampleColor.sampleColor = Color.Green
                Case ucSampleInfos.eSampleColor._SingleColor_B
                    .sampleColor.sampleColor = Color.Blue
                Case ucSampleInfos.eSampleColor._SingleColor_W
                    .sampleColor.sampleColor = Color.White
                Case ucSampleInfos.eSampleColor._MixedColor

            End Select

            Try
                .dFillFactor = tbFillFactor.Text
            Catch ex As Exception
                .dFillFactor = 0
            End Try

            Try
                .SampleSize.Width = tbSizeWidth.Text
            Catch ex As Exception
                .SampleSize.Width = 0
            End Try

            Try
                .SampleSize.Height = tbSizeHight.Text
            Catch ex As Exception
                .SampleSize.Height = 0
            End Try

        End With

    End Sub


    Private Sub SetValueToUI()
        With m_SampleInfo
            cbSelSampleType.SelectedIndex = .sampleType
            tbSeqTitle.Text = .sTitle
            cbSampleColor.SelectedIndex = .sampleColor.nDefColor
            'Select Case .sampleColor.nDefColor
            '    Case eSampleColor.eRed
            '        .sampleColor.sampleColor = Color.Red
            '    Case eSampleColor.eGreen
            '        .sampleColor.sampleColor = Color.Green
            '    Case eSampleColor.eBlue
            '        .sampleColor.sampleColor = Color.Blue
            '    Case eSampleColor.eWhite
            '        .sampleColor.sampleColor = Color.White
            '    Case eSampleColor.eUserDef
            'End Select
            tbFillFactor.Text = .dFillFactor
            tbSizeWidth.Text = .SampleSize.Width
            tbSizeHight.Text = .SampleSize.Height
            tbComment.Text = .sComment

            tbSizeArea.Text = Format(.SampleSize.Width * .SampleSize.Height, "0.000")

        End With

    End Sub

#End Region


    Private Sub tbSizeArea_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbSizeArea.TextChanged
        Dim TempText() As String = Split(tbSizeArea.Text, ".")
        Dim TempText2 As String = ""

        'Dim m_OptInfo As frmOptionWindow.sOPTIONDATa = Nothing
        'frmOptionWindow.LoadSystemOption(m_OptInfo)

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Dim dValue As Double

        Try
            If tbSizeArea.Text = "-" Or tbSizeArea.Text = "-0" Then
                Return
            End If

            dValue = CDbl(tbSizeArea.Text)

        Catch ex As Exception
            tbSizeArea.Text = "0"
            Exit Sub
        End Try

        tbSizeWidth.Text = Format(Math.Sqrt(dValue), "0.0000")
        tbSizeHight.Text = Format(Math.Sqrt(dValue), "0.0000")

    End Sub

    Private Sub tbSizeHight_TextChanged(sender As Object, e As EventArgs) Handles tbSizeHight.TextChanged
        Dim TempText() As String = Split(tbSizeHight.Text, ".")
        Dim TempText2 As String = ""

        'Dim m_OptInfo As frmOptionWindow.sOPTIONDATa = Nothing
        'frmOptionWindow.LoadSystemOption(m_OptInfo)

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Dim dValue As Double

        Try
            If tbSizeHight.Text = "-" Or tbSizeHight.Text = "-0" Then
                Return
            End If

            dValue = CDbl(tbSizeHight.Text)

        Catch ex As Exception
            tbSizeHight.Text = "0"
            Exit Sub
        End Try

        ' tbSizeWidth.Text = Format(Math.Sqrt(dValue), "0.0000")
        'tbSizeHight.Text = Format(Math.Sqrt(dValue), "0.0000")

    End Sub

    Private Sub tbSizeWidth_TextChanged(sender As Object, e As EventArgs) Handles tbSizeWidth.TextChanged
        Dim TempText() As String = Split(tbSizeWidth.Text, ".")
        Dim TempText2 As String = ""

        'Dim m_OptInfo As frmOptionWindow.sOPTIONDATa = Nothing
        'frmOptionWindow.LoadSystemOption(m_OptInfo)

        If TempText(TempText.Length - 1) = "" Then Exit Sub ' . 누르면 안되게 ex ) 0 누르고 . 누르면  0 으로 자동 형변환 처리되는거 방지

        If TempText(0) = "" Then Exit Sub ' . 누르고 5 누르면 0.5 되게 

        If TempText.Length > 1 And Val(TempText(TempText.Length - 1)) = 0 Then Exit Sub ' 0.000 누르면 형변환 되는거 방지

        Dim dValue As Double

        Try
            If tbSizeWidth.Text = "-" Or tbSizeWidth.Text = "-0" Then
                Return
            End If

            dValue = CDbl(tbSizeWidth.Text)

        Catch ex As Exception
            tbSizeWidth.Text = "0"
            Exit Sub
        End Try

        ' tbSizeWidth.Text = Format(Math.Sqrt(dValue), "0.0000")
        'tbSizeHight.Text = Format(Math.Sqrt(dValue), "0.0000")

    End Sub
End Class
