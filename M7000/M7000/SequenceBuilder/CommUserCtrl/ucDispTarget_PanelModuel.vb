Public Class ucDispTarget_PanelModuel

    Dim m_targetSize As ucSampleInfos.sSampleSize   ' = New System.Drawing.Size(900, 600)
    Dim m_targetType As ucSampleInfos.eSampleType
    Dim m_sampleColor As ucSampleInfos.sSampleColor 'ucDispCommon.eSampleColor
    Dim m_dTemp As Double
    Dim m_MeasureImg As System.Drawing.Image = Nothing
    Dim m_bVisibleTemp As Boolean
    Dim m_ptColor As System.Drawing.Color

    Dim Img As Bitmap
    Dim Graphics As Graphics
    'Dim drawString As String = "x"
    'Dim drawFont As New Font("Arial", 5)
    'Dim drawBrush As New SolidBrush(Color.Black)

    Public Event evSetPoint(ByVal pt As ucDispPointSetting.sPoint)
    Public Event evSavePoint(ByVal pt As ucDispPointSetting.sPoint)

#Region "Creator"


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Private Sub init()
        tlpLayout.Dock = DockStyle.Fill
        lblInfo.Dock = DockStyle.Fill
        pbDisplay.Dock = DockStyle.Fill
        lblCurrentPos.Dock = DockStyle.Fill
        m_targetSize.Height = 900
        m_targetSize.Width = 600
        pbDisplay.BackgroundImageLayout = ImageLayout.Stretch
        DisplayInit()
    End Sub

#End Region

#Region "Properties"

    Public Property TargetSize As ucSampleInfos.sSampleSize
        Get
            Return m_targetSize
        End Get
        Set(ByVal value As ucSampleInfos.sSampleSize)
            m_targetSize = value
            UpdateDisp()
        End Set
    End Property

    Public Property TargetType As ucSampleInfos.eSampleType
        Get
            Return m_targetType
        End Get
        Set(ByVal value As ucSampleInfos.eSampleType)
            m_targetType = value
            UpdateDisp()
        End Set
    End Property


    Public Property SampleColor As ucSampleInfos.sSampleColor
        Get
            Return m_sampleColor
        End Get
        Set(ByVal value As ucSampleInfos.sSampleColor)
            m_sampleColor = value
            UpdateDisp()
        End Set
    End Property


    Public Property Temp As Double
        Get
            Return m_dTemp
        End Get
        Set(ByVal value As Double)
            m_dTemp = value
            UpdateDisp()
        End Set
    End Property

    Public WriteOnly Property MeasureImage As System.Drawing.Image
        Set(ByVal value As System.Drawing.Image)
            m_MeasureImg = value
            UpdateDisp()
        End Set
    End Property


    Public WriteOnly Property VisibleTemp As Boolean
        Set(ByVal value As Boolean)
            m_bVisibleTemp = value
            UpdateDisp()
        End Set
    End Property

    Public Property PointColor As System.Drawing.Color
        Get
            Return m_ptColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            m_ptColor = value
        End Set
    End Property





#End Region

    Public Sub DisplayInit()
        If m_targetSize.Width <= 0 Or m_targetSize.Height <= 0 Then Exit Sub
        Img = New Bitmap(CInt(m_targetSize.Width), CInt(m_targetSize.Height))
        Graphics = Graphics.FromImage(Img)

    End Sub

    Private Sub UpdateDisp()
        Dim sType As String = ""
        Dim sSeperator As String = "     "

        Select Case m_targetType
            Case ucSampleInfos.eSampleType.eCell
                sType = "Cell"

                Select Case m_sampleColor.nDefColor
                    Case ucSampleInfos.eSampleColor._SingleColor_R
                        pbDisplay.BackColor = Color.Red
                    Case ucSampleInfos.eSampleColor._SingleColor_G
                        pbDisplay.BackColor = Color.Green
                    Case ucSampleInfos.eSampleColor._SingleColor_B
                        pbDisplay.BackColor = Color.Blue
                    Case ucSampleInfos.eSampleColor._MixedColor
                        pbDisplay.BackColor = m_sampleColor.sampleColor
                End Select

            Case ucSampleInfos.eSampleType.ePanel
                sType = "Panel"
            Case ucSampleInfos.eSampleType.eModule
                sType = "Module"
        End Select

        lblInfo.Text = "Type : " & sType & sSeperator & "Size : " & CStr(m_targetSize.Width) & "*" & CStr(m_targetSize.Height)

        If m_bVisibleTemp = True Then
            lblInfo.Text = lblInfo.Text & sSeperator & "Temp : " & CStr(m_dTemp)
        End If

        If m_MeasureImg Is Nothing = False Then
            pbDisplay.BackgroundImage = m_MeasureImg
        Else
            pbDisplay.BackColor = Color.White
        End If

    End Sub



    Private Sub pbDisplay_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDisplay.MouseClick
        Dim pt As ucDispPointSetting.sPoint
        Dim pt2 As ucDispPointSetting.sPoint
        Dim dRatioX As Double
        Dim dRatioY As Double
        Dim targetPt As ucDispPointSetting.sPoint

        pt.X = pbDisplay.Size.Width - e.Location.X
        pt.Y = e.Location.Y
        pt.ptColor = m_ptColor

        pt2.X = e.Location.X
        pt2.Y = e.Location.Y
        pt2.ptColor = m_ptColor
        DrawPoint(pt2)

        dRatioX = pt.X / pbDisplay.Size.Width
        dRatioY = pt.Y / pbDisplay.Size.Height

        targetPt.X = Format(dRatioX * m_targetSize.Width, "0.0")
        targetPt.Y = Format(dRatioY * m_targetSize.Height, "0.0")
        targetPt.ptColor = pt.ptColor

        RaiseEvent evSavePoint(targetPt)
    End Sub

    Private Sub pbDisplay_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbDisplay.MouseHover

     
    End Sub

    Private Sub pbDisplay_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbDisplay.MouseLeave

    End Sub

    Private Sub pbDisplay_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDisplay.MouseMove
        Dim pt As Point
        Dim dRatioX As Double
        Dim dRatioY As Double
      
        Dim dTargetX As Double
        Dim dTargetY As Double

        pt.X = pbDisplay.Size.Width - e.Location.X
        pt.Y = e.Location.Y

        dRatioX = pt.X / pbDisplay.Size.Width
        dRatioY = pt.Y / pbDisplay.Size.Height

        dTargetX = dRatioX * m_targetSize.Width
        dTargetY = dRatioY * m_targetSize.Height

        lblCurrentPos.Text = "X : " & CStr(Format(dTargetX, "0.0")) & "        " & "Y : " & CStr(Format(dTargetY, "0.0"))
    End Sub

    Public Sub DrawRatio(ByVal nX As Integer, ByVal nY As Integer, ByRef ptTarget() As ucDispPointSetting.sPoint)
        PbDisplay_Clear()

        Dim xl, xl2 As Double
        Dim yl, yl2 As Double
        Dim dRatioX, dRatioX2 As Double
        Dim dRatioY, dRatioY2 As Double
        Dim px, px2 As Integer
        Dim py, py2 As Integer
        Dim nTargetNum As Integer = (nX * nY) - 1
        Dim nXpNum As Integer = (nX * 2) - 1
        Dim nYpNum As Integer = (nY * 2) - 1

        Dim x As Integer = pbDisplay.Size.Width
        Dim y As Integer = pbDisplay.Size.Height

        Dim rx As Integer
        Dim ry As Integer

        Dim nbx(nTargetNum) As Integer
        Dim nby(nTargetNum) As Integer

        Dim pt As ucDispPointSetting.sPoint
        Dim targetPt As ucDispPointSetting.sPoint
        Dim nTarget As Integer

        xl2 = m_targetSize.Width
        yl2 = m_targetSize.Height

        xl = m_targetSize.Width / nX
        yl = m_targetSize.Height / nY

        dRatioX = xl / m_targetSize.Width
        dRatioY = yl / m_targetSize.Height

        dRatioX2 = xl2 / m_targetSize.Width
        dRatioY2 = yl2 / m_targetSize.Height

        px = dRatioX * pbDisplay.Size.Width
        px2 = dRatioX2 * pbDisplay.Size.Width
        py = dRatioY * pbDisplay.Size.Height
        py2 = dRatioY2 * pbDisplay.Size.Height

        pbDisplay.Image = Img

        rx = px / 2
        ry = py / 2

        For i As Integer = 1 To nTargetNum + 1
            nbx(i - 1) = rx * i
        Next

        For i = 1 To nTargetNum + 1
            nby(i - 1) = ry * i
        Next

        Dim drawP As ucDispPointSetting.sPoint

        For i = 0 To (nY * 2) - 1 Step 2
            For j As Integer = 0 To (nY * 2) - 1 Step 2
                drawP.X = nbx(j)
                drawP.Y = nby(i)
                drawP.ptColor = m_ptColor
                DrawPoint(drawP)
            Next
        Next

        ReDim ptTarget(nTargetNum)

        For i = 0 To nYpNum Step 2
            For j = 0 To nXpNum Step 2
                pt.X = nbx(j)
                pt.Y = nby(i)

                dRatioX = pt.X / pbDisplay.Size.Width
                dRatioY = pt.Y / pbDisplay.Size.Height
                dRatioX = Format(dRatioX, "0.00")
                dRatioY = Format(dRatioY, "0.00")


                targetPt.X = dRatioX * m_targetSize.Width
                targetPt.Y = dRatioY * m_targetSize.Height
                targetPt.ptColor = m_ptColor

                ptTarget(nTarget).X = targetPt.X
                ptTarget(nTarget).Y = targetPt.Y

                RaiseEvent evSavePoint(targetPt)
                nTarget = nTarget + 1
            Next
        Next

        For x1 As Integer = 0 To x Step px
            Graphics.DrawLine(New Pen(Color.DarkGray, 1), x1, 0, x1, py2)
        Next x1

        For y1 As Integer = 0 To y Step py
            Graphics.DrawLine(New Pen(Color.DarkGray, 1), 0, y1, px2, y1)
        Next y1


        Me.Refresh()

    End Sub

    Public Sub PbDisplay_Clear()
        Dim x As Integer = pbDisplay.Size.Width
        Dim y As Integer = pbDisplay.Size.Height
        Img = New Bitmap(x, y)
        Graphics = Graphics.FromImage(Img)

        pbDisplay.Image = Img
        pbDisplay.Refresh()

    End Sub

    Public Sub PbDisplay_Del(ByVal TargetDel As ucDispPointSetting.sPoint)
        Dim sBrush As New SolidBrush(Color.Red)
        Dim rect As Rectangle
        Dim px, py As Integer
        Dim pt As ucDispPointSetting.sPoint

        pt = PbDisplay_CalPoint(TargetDel)

        px = pt.X
        py = pt.Y

        rect = New Rectangle(px - 4, py - 4, 8, 8)
        Graphics = Graphics.FromImage(Img)
        pbDisplay.Image = Img
        Graphics.FillRectangle(sBrush, rect)
    End Sub

    Private Sub DrawPoint(ByVal TargetPoint As ucDispPointSetting.sPoint)
        Dim sBrush As New SolidBrush(TargetPoint.ptColor)
        Dim rect As Rectangle

        rect = New Rectangle(CInt(TargetPoint.X - 4), CInt(TargetPoint.Y - 4), 8, 8)
        Graphics = Graphics.FromImage(Img)
    
        pbDisplay.Image = Img
        Graphics.FillEllipse(sBrush, rect)


    End Sub

    Public Sub PointToDrawPaint(ByVal TargetPoint As ucDispPointSetting.sPoint)

        Dim pt As ucDispPointSetting.sPoint

        pt = PbDisplay_CalPoint(TargetPoint)
        pt.ptColor = m_ptColor
        DrawPoint(pt)

        RaiseEvent evSavePoint(TargetPoint)
    End Sub

    Public Sub DrawPoints(ByVal TargetPoint() As ucDispPointSetting.sPoint)    ' 현재 m_MeasPointInfo.MeasPoint 출력
        If TargetPoint Is Nothing Then
            Exit Sub
        End If

        PbDisplay_Clear()

        Dim pt As ucDispPointSetting.sPoint
        Dim nPtCount As Integer

        nPtCount = TargetPoint.Length

        For i As Integer = 0 To nPtCount - 1
            RaiseEvent evSetPoint(TargetPoint(i))

            pt = PbDisplay_CalPoint(TargetPoint(i))
            DrawPoint(pt)
        Next
    End Sub

    Private Function PbDisplay_CalPoint(ByVal TargetPoint As ucDispPointSetting.sPoint) As ucDispPointSetting.sPoint
        Dim x, y As Double
        Dim dRatioX, dRatioY As Double
        Dim px, py As Double

        x = m_targetSize.Width - TargetPoint.X
        y = TargetPoint.Y

        dRatioX = x / m_targetSize.Width
        dRatioY = y / m_targetSize.Height

        px = dRatioX * pbDisplay.Size.Width
        py = dRatioY * pbDisplay.Size.Height

        TargetPoint.X = px
        TargetPoint.Y = py

        Return TargetPoint
    End Function

    Private Sub ucDispTarget_PanelModuel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DisplayInit()
    End Sub
End Class
