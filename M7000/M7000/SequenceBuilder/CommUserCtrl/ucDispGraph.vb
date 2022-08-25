Imports ZedGraph
Imports System.Threading

Public Class ucDispGraph


    Public Sub New()
        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub



#Region "Defines"
    '  Public Event evMouseClick()
    Public Event evMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
    Public Event evMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)

    Public Enum eGraphMode
        eEL
        eDrive
        eReference
        eELNormalized
    End Enum

    Public Structure sCaptions
        Dim strTitle As String
        Dim strXaxis As String
        Dim strY1axis As String
        Dim strY2axis As String
    End Structure

    Public Structure sPointValue
        Dim dValue1 As Double
        Dim dTime_Hour As Double
    End Structure

    '--------For Lcr Long-Term Test System--------------------------------------------

    Dim m_PlotItemInfo() As frmMain.eMeasureItem

    'Public Structure sPlotItem
    '    Dim eFunction As CLCRIMPType.eParam
    'End Structure

    '-----------------------------------------------------
    Dim m_sXAxisTitle As String
    Dim m_sY1AxisTitle As String
    Dim m_sY2AxisTitle As String
    Dim m_numOfPlotCurve As Integer
    Dim m_sCurveName() As String
    Dim m_LineColors() As Color
    Dim m_bScaleXAuto As Boolean
    Dim m_dScaleXmin As Double
    Dim m_dScaleXmax As Double

    Dim m_XAxisScaleType As eAxisType = eAxisType.eLinear
    Dim m_Y1AxisScaleType As eAxisType = eAxisType.eLog
    Dim m_Y2AxisScaleType As eAxisType = eAxisType.eLog




    '
    Dim m_selectMode As eIVLPlotMode
    Dim m_XAxisItem As eIVLPlotData = eIVLPlotData.eVolt
    Dim m_YAxisItem As eIVLPlotData = eIVLPlotData.eJ

    '******Data 저장용*****
    ' Private m_IVLData() As frmIVL.sIVLData
    Private m_dVoltage() As Double '= {1, 2, 3, 4, 5, 6, 7, 7, 8, 9, 0}
    Private m_dCurrent() As Double '= {1, 2, 3, 4, 5, 6, 7, 7, 8, 9, 0}
    Private m_dABSCurrent() As Double
    Private m_dJ() As Double
    Private m_dABS_J() As Double
    Private m_dCdm2() As Double
    Private m_dCdA() As Double
    Private m_dlmW() As Double
    Private m_dAngle() As Double
    Private m_dQE() As Double

    Private m_dIntencity()() As Double
    Private m_nWavelength()() As Integer

    Private m_OutData() As frmMain.sCellIVLMeasure
    Private m_PanelOutData() As frmMain.sPanelIVLMeasure

    Dim m_dPointValueX As Double
    Dim m_dPointValueY As Double

    Dim m_nSelectPoint As Integer

    '  Dim m_CursorValue As CCalSlope.sNumericalPoint

    Dim m_SelectCurve As ZedGraph.CurveItem


    Dim m_sPlotCaptions() As String = New String() {"Nothing", "Volt(V)", "Current(A)", "J(mA/cm2)", "cd/A", "lm/W", _
                                                 "Quantum Efficiancy", "cd/m2(Fill)", "cd/m2", "CIEx", "CIEy", "Abs Current(A)", _
                                               "Log10(Abs Current(A))", "Abs J(mA/cm2)", "Intencity", "WaveLength", "Angle", "QE(%)", _
                                               "ELVDD Volt(V)", "ELVDD Current(A)", "ELVSS Volt(V)", "ELVSS Current(A)", "DR(V)", "DG(V)", "DB(V)"}

    Dim m_sModeCaptions() As String = New String() {"EL", "Drive(Current)", "Reference", "EL Normalized"}

    '--------For LCR Long Term Test System----------------------------------------------------------------------------
    Dim sIMPTypeParams() As String = New String() {"CPD", "CPQ", "CPG", "CPRP", "CSD", "CSQ", "CSRS", "LPD", "LPQ", "LPG",
     "LPRP", "LPRD", "LSD", "LSQ", "LSRS", "LSRD", "RX", "ZTD", "ZTR", "GB", "YTD", "YTR", "VDID"}


    '------------------------------------------------------------------------------------





#End Region

#Region "Enum:"

    Public Enum eIVLPlotMode
        eVvsC       '0
        eVvsABS_C   '1
        eVvsCdm2    '2
        eVvsCdA     '3
        eVvslmW     '4
        eJvsCdm2    '5
        eJvsCdA     '6
        eJvslmW     '7
        eJvsV       '8
        eVvsJ       '9
        eVvsABS_J   '10
        eCdm2vsCdA  '11
        eSpectrum   '12
        eAnglevsCdm2 '13
        eVvsQE
        eQEvsCdm2
        eAnglevsQE
        eAnglevsCdA
        eAnglevslmW
    End Enum

    Public Enum eIVLPlotData
        eNothing            '00
        eVolt               '01
        eCurrent            '02
        eJ                  '03
        eCd_A               '04
        elm_W               '05
        eQuantumEfficiency  '06
        eCd_m2_Fill         '07
        eCd_m2              '08
        eCIEx               '09
        eCIEy               '10
        eAbsCurrent         '11
        eLog10AbsCurrent    '12
        eAbsJ               '13
        eIntencity          '14
        eWaveLength         '15
        eAngle              '16
        eQE
    End Enum

    Public Enum eAxisType
        eLinear = 0
        eLog
    End Enum

#End Region


#Region "Propertys"

    Public Property XAxisTitle() As String
        Get
            Return m_sXAxisTitle
        End Get
        Set(ByVal value As String)
            m_sXAxisTitle = value
            GraphInit()
        End Set
    End Property

    Public Property Y1AxisTitle() As String
        Get
            Return m_sY1AxisTitle
        End Get
        Set(ByVal value As String)
            m_sY1AxisTitle = value
            GraphInit()
        End Set
    End Property

    Public Property Y2AxisTitle() As String
        Get
            Return m_sY2AxisTitle
        End Get
        Set(ByVal value As String)
            m_sY2AxisTitle = value
            GraphInit()
        End Set
    End Property

    Public Property numOfPlots() As Integer
        Get
            Return m_numOfPlotCurve
        End Get
        Set(ByVal value As Integer)
            m_numOfPlotCurve = value
            If m_sCurveName.Length = m_numOfPlotCurve Then
                GraphInit()
            Else
                MsgBox("Plot Item 수가 맞지 않습니다.")
            End If
        End Set
    End Property

    Public Property PlotIndex() As String()
        Get
            Return m_sCurveName
        End Get
        Set(ByVal value As String())
            m_sCurveName = value
            If m_sCurveName.Length = m_numOfPlotCurve Then
                GraphInit()
            Else
                MsgBox("Plot Item 수가 맞지 않습니다.")
            End If
        End Set
    End Property

    Public Property PlotColor() As Color()
        Get
            Return m_LineColors
        End Get
        Set(ByVal value As Color())
            m_LineColors = value
            If m_sCurveName.Length = m_numOfPlotCurve Then
                GraphInit()
            Else
                MsgBox("Plot Item 수가 맞지 않습니다.")
            End If
        End Set
    End Property

    Public Property XAxisScale_MinValue() As Double
        Get
            Return m_dScaleXmin
        End Get
        Set(ByVal value As Double)
            m_dScaleXmin = value
        End Set
    End Property

    Public Property XAxisScale_MaxValue() As Double
        Get
            Return m_dScaleXmax
        End Get
        Set(ByVal value As Double)
            m_dScaleXmax = value
        End Set
    End Property

    Public Property XAxisScale_Auto() As Boolean
        Get
            Return m_bScaleXAuto
        End Get
        Set(ByVal value As Boolean)
            m_bScaleXAuto = value
        End Set
    End Property

    Public ReadOnly Property PointValueX() As Double
        Get
            Return m_dPointValueX
        End Get
    End Property

    Public ReadOnly Property PointValueY() As Double
        Get
            Return m_dPointValueY
        End Get
    End Property

    Public WriteOnly Property IsShowPointValues() As Boolean
        Set(ByVal value As Boolean)
            zgGraph.IsShowPointValues = value
        End Set
    End Property

    'Public ReadOnly Property CursorValue() As CCalSlope.sNumericalPoint
    '    Get
    '        Return m_CursorValue
    '    End Get
    'End Property

    Public ReadOnly Property SelectedCurve() As ZedGraph.CurveItem
        Get
            Return m_SelectCurve
        End Get
    End Property

    Public ReadOnly Property SelectedPoint() As Integer
        Get
            Return m_nSelectPoint
        End Get
    End Property

    'Public WriteOnly Property WritePlotData() As frmMain.sIVLMeasure()
    '    Set(ByVal value As frmMain.sIVLMeasure())
    '        SetPlotData(value)
    '    End Set
    'End Property

    Public WriteOnly Property PlotMode() As eIVLPlotMode
        Set(ByVal value As eIVLPlotMode)
            m_selectMode = value
            'PlotIVLData(value)
        End Set
    End Property

#End Region

#Region "Delegate Functions"


    Private Delegate Sub ZedGraphFuncCall(ByVal graphCtrl As ZedGraph.ZedGraphControl)
    Private Delegate Sub FuncCall()

    'Private Sub GraphRefresh(ByVal graphCtrl As ZedGraph.ZedGraphControl)
    '    If graphCtrl.InvokeRequired = True Then
    '        Dim delRefresh As ZedGraphFuncCall = New ZedGraphFuncCall(AddressOf GraphRefresh)
    '        Invoke(delRefresh) 'delRefresh
    '    Else
    '        graphCtrl.Refresh()
    '    End If
    'End Sub

    Private Sub GraphRefresh()
        If zgGraph.InvokeRequired = True Then
            Dim delRefresh As FuncCall = New FuncCall(AddressOf GraphRefresh)
            Invoke(delRefresh) 'delRefresh
        Else
            zgGraph.Refresh()
        End If
    End Sub

#End Region

    Private Sub init()
        zgGraph.Dock = DockStyle.Fill
        m_sXAxisTitle = "X Axis Title"
        m_sY1AxisTitle = "Y Axis Title"
        m_sY2AxisTitle = "Y2 Axis Title"
        m_numOfPlotCurve = 1
        m_sCurveName = New String() {"Test"}
        m_LineColors = New Color() {Color.Yellow}
    End Sub

#Region "New Graph Control Functions"

    'Public Sub ClearGraph()
    '    Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane
    '    zgGraph.GraphPane.CurveList.Clear()
    '    GraphRefresh()
    'End Sub

    Public Sub InitGraph()

        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane

        myPane.Y2AxisList.Clear()
        myPane.YAxisList.Clear()
        zgGraph.GraphPane.CurveList.Clear()

        ' Set the titles and axis labels
        myPane.Title.Text = "" 'Main Graph"
        myPane.Title.FontSpec.Size = 10
        myPane.XAxis.Title.Text = "Time(Hour)"
        myPane.XAxis.Title.FontSpec.Size = 10
        ' myPane.YAxis.Title.Text = "Amplitude(V)"
        '   myPane.YAxis.Title.FontSpec.Size = 10

        myPane.XAxis.Scale.FontSpec.Size = 10
        ' myPane.YAxis.Scale.FontSpec.Size = 10

        ''Add gridlines to the plot, and make them gray
        myPane.XAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.XAxis.MajorGrid.IsVisible = True
        '  myPane.YAxis.MajorGrid.IsVisible = True


        myPane.XAxis.MajorGrid.Color = Color.LightGray
        '  myPane.YAxis.MajorGrid.Color = Color.LightGray
        myPane.XAxis.Type = AxisType.Linear 'AxisType.Log

        ' Fill the axis background with a color gradient
        myPane.Legend.Fill = New Fill(Color.Black, Color.LightGray)
        '  myPane.Chart.Fill = New Fill(Color.WhiteSmoke, Color.SteelBlue, 20.0F)
        myPane.Chart.Fill = New Fill(Color.Black, Color.Black, 100.0F)
        ' Fill the pane background with a color gradient
        myPane.Fill = New Fill(Color.White, Color.Red, 45.0F)

        '  Dim list As PointPairList = New PointPairList()
        GraphRefresh()

    End Sub

    Public Sub InitGraph(ByVal items() As frmMain.eMeasureItem)

        m_PlotItemInfo = items.Clone

        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane

        myPane.Y2AxisList.Clear()
        myPane.YAxisList.Clear()
        zgGraph.GraphPane.CurveList.Clear()

        Dim sYTitle() As String = Nothing
        Dim pList(m_PlotItemInfo.Length - 1) As PointPairList ' = New PointPairList()

        CreateSelPlotModeMenu(sYTitle)

        'Dim pList2 As PointPairList = New PointPairList()

        For i As Integer = 0 To m_PlotItemInfo.Length - 1
            pList(i) = New PointPairList
            myPane.AddYAxis(sYTitle(i))
            myPane.AddCurve(sYTitle(i), pList(i), Color.Yellow, SymbolType.None)
            myPane.CurveList(i).IsY2Axis = False
            myPane.CurveList(i).YAxisIndex = i
            myPane.YAxisList.Item(i).Title.FontSpec.Size = 10
            myPane.YAxisList.Item(i).Scale.FontSpec.Size = 10
            myPane.YAxisList.Item(i).Scale.MaxAuto = True
            myPane.YAxisList.Item(i).Scale.MinAuto = True
            myPane.YAxisList.Item(i).MajorGrid.IsVisible = True
            myPane.YAxisList.Item(i).MajorGrid.Color = Color.LightGray

       
        Next


        ' Set the titles and axis labels

        myPane.Title.Text = "" 'Main Graph"
        myPane.Title.FontSpec.Size = 10
        myPane.XAxis.Title.Text = "Time(Hour)"
        myPane.XAxis.Title.FontSpec.Size = 10
        'myPane.YAxis.Title.Text = "Amplitude(V)"
        'myPane.YAxis.Title.FontSpec.Size = 10

        myPane.XAxis.Scale.FontSpec.Size = 10
        '  myPane.YAxis.Scale.FontSpec.Size = 10

        ''Add gridlines to the plot, and make them gray
        myPane.XAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.XAxis.MajorGrid.IsVisible = True
        '  myPane.YAxis.MajorGrid.IsVisible = True
        myPane.XAxis.MajorGrid.Color = Color.LightGray
        '  myPane.YAxis.MajorGrid.Color = Color.LightGray
        myPane.XAxis.Type = AxisType.Linear 'AxisType.Log

        ' Fill the axis background with a color gradient
        myPane.Legend.Fill = New Fill(Color.Black, Color.LightGray)
        '  myPane.Chart.Fill = New Fill(Color.WhiteSmoke, Color.SteelBlue, 20.0F)
        myPane.Chart.Fill = New Fill(Color.Black, Color.Black, 100.0F)
        ' Fill the pane background with a color gradient
        myPane.Fill = New Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0F)

        ' myPane.AddCurve("Value2", pList2, Color.Orange, SymbolType.None)

        '  Dim list As PointPairList = New PointPairList()
        GraphRefresh()
    End Sub

    Public Sub GraphInitDualAxis()

        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane

        zgGraph.GraphPane.CurveList.Clear()

        ' Set the titles and axis labels
        myPane.Title.Text = "" 'Main Graph"
        myPane.Title.FontSpec.Size = 10
        myPane.XAxis.Title.Text = "Time(sec)"
        myPane.XAxis.Title.FontSpec.Size = 10
        myPane.YAxis.Title.Text = "Amplitude(V)"
        myPane.YAxis.Title.FontSpec.Size = 10

        myPane.AddY2Axis("Amplitude(V)")
        myPane.Y2Axis.Title.Text = "Amplitude(V)"
        myPane.Y2Axis.Title.FontSpec.Size = 10


        myPane.XAxis.Scale.FontSpec.Size = 10
        myPane.YAxis.Scale.FontSpec.Size = 10

        myPane.Y2Axis.Scale.FontSpec.Size = 10

        ''Add gridlines to the plot, and make them gray
        myPane.XAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.IsVisible = True

        myPane.Y2Axis.MajorGrid.IsVisible = True

        myPane.Y2Axis.Scale.MaxAuto = True
        myPane.Y2Axis.Scale.MinAuto = True

        myPane.XAxis.MajorGrid.Color = Color.LightGray
        myPane.YAxis.MajorGrid.Color = Color.LightGray
        myPane.Y2Axis.MajorGrid.Color = Color.LightGray
        myPane.XAxis.Type = AxisType.Linear 'AxisType.Log

        ' Fill the axis background with a color gradient
        myPane.Legend.Fill = New Fill(Color.Black, Color.LightGray)
        '  myPane.Chart.Fill = New Fill(Color.WhiteSmoke, Color.SteelBlue, 20.0F)
        myPane.Chart.Fill = New Fill(Color.Black, Color.Black, 100.0F)
        ' Fill the pane background with a color gradient
        myPane.Fill = New Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0F)

        Dim list As PointPairList = New PointPairList()

        'Dim Ch1Curve As ZedGraph.CurveItem = myPane.AddCurve("CH1", list, Color.Yellow, ZedGraph.SymbolType.None)
        'Dim Ch2Curve As ZedGraph.CurveItem = myPane.AddCurve("CH2", list, Color.LightBlue, ZedGraph.SymbolType.None)
        'Dim Ch3Curve As ZedGraph.CurveItem = myPane.AddCurve("CH3", list, Color.LightPink, ZedGraph.SymbolType.None)
        'Dim Ch4Curve As ZedGraph.CurveItem = myPane.AddCurve("CH4", list, Color.Lime, ZedGraph.SymbolType.None)

        'Ch1Curve.Label.FontSpec = New FontSpec("CH1", 7, Color.Black, True, False, False)
        'Ch2Curve.Label.FontSpec = New FontSpec("CH2", 7, Color.Black, True, False, False)
        'Ch3Curve.Label.FontSpec = New FontSpec("CH3", 7, Color.Black, True, False, False)
        'Ch4Curve.Label.FontSpec = New FontSpec("CH4", 7, Color.Black, True, False, False)

        myPane.Y2Axis.IsVisible = True

        GraphRefresh()

    End Sub

    Public Sub GraphInitDualAxis(ByVal caption As sCaptions)

        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane

        zgGraph.GraphPane.CurveList.Clear()

        ' Set the titles and axis labels
        myPane.Title.Text = caption.strTitle
        myPane.Title.FontSpec.Size = 10
        myPane.XAxis.Title.Text = caption.strXaxis
        myPane.XAxis.Title.FontSpec.Size = 10
        myPane.YAxis.Title.Text = caption.strY1axis
        myPane.YAxis.Title.FontSpec.Size = 10

        myPane.AddY2Axis(caption.strY2axis)
        myPane.Y2Axis.Title.Text = caption.strY2axis
        myPane.Y2Axis.Title.FontSpec.Size = 10


        myPane.XAxis.Scale.FontSpec.Size = 10
        myPane.YAxis.Scale.FontSpec.Size = 10

        myPane.Y2Axis.Scale.FontSpec.Size = 10

        ''Add gridlines to the plot, and make them gray
        myPane.XAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.IsVisible = True

        myPane.Y2Axis.MajorGrid.IsVisible = True

        myPane.Y2Axis.Scale.MaxAuto = True
        myPane.Y2Axis.Scale.MinAuto = True

        myPane.XAxis.MajorGrid.Color = Color.LightGray
        myPane.YAxis.MajorGrid.Color = Color.LightGray
        myPane.Y2Axis.MajorGrid.Color = Color.LightGray
        myPane.XAxis.Type = AxisType.Linear 'AxisType.Log

        ' Fill the axis background with a color gradient
        myPane.Legend.Fill = New Fill(Color.Black, Color.LightGray)
        '  myPane.Chart.Fill = New Fill(Color.WhiteSmoke, Color.SteelBlue, 20.0F)
        myPane.Chart.Fill = New Fill(Color.Black, Color.Black, 100.0F)
        ' Fill the pane background with a color gradient
        myPane.Fill = New Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0F)

        Dim list As PointPairList = New PointPairList()

        myPane.Y2Axis.IsVisible = True

        GraphRefresh()

    End Sub

    Public Sub GraphInit()

        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane

        zgGraph.GraphPane.CurveList.Clear()

        ' Set the titles and axis labels
        myPane.Title.Text = "" 'Main Graph"
        myPane.Title.FontSpec.Size = 10
        myPane.XAxis.Title.Text = "Voltage"
        myPane.XAxis.Title.FontSpec.Size = 15
        myPane.YAxis.Title.Text = "Current"
        myPane.YAxis.Title.FontSpec.Size = 15


        myPane.XAxis.Scale.FontSpec.Size = 13
        myPane.YAxis.Scale.FontSpec.Size = 13


        ''Add gridlines to the plot, and make them gray
        myPane.XAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.YAxis.MajorGrid.IsZeroLine = False
        myPane.XAxis.MajorGrid.IsZeroLine = False
        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.IsVisible = True
        myPane.XAxis.IsAxisSegmentVisible = False
        myPane.YAxis.IsAxisSegmentVisible = False

        myPane.XAxis.MajorGrid.Color = Color.LightGray
        myPane.YAxis.MajorGrid.Color = Color.LightGray

        myPane.XAxis.Type = AxisType.Linear 'AxisType.Log

        ' Fill the axis background with a color gradient
        myPane.Legend.Fill = New Fill(Color.Black, Color.LightGray)
        '  myPane.Chart.Fill = New Fill(Color.WhiteSmoke, Color.SteelBlue, 20.0F)
        myPane.Chart.Fill = New Fill(Color.Black, Color.Black, 100.0F)
        ' Fill the pane background with a color gradient
        myPane.Fill = New Fill(Color.White, Color.White, 45.0F)

        Dim pLit As PointPairList = New PointPairList()

        myPane.AddCurve("", pLit, Color.OrangeRed, SymbolType.None)
        'myCurve.Label.FontSpec = New FontSpec("CH1", 7, Color.Black, True, False, False)
        '        myCurve.IsY2Axis = True
        GraphRefresh()
    End Sub

    Public Sub GraphInit(ByVal title As sCaptions)

        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane

        zgGraph.GraphPane.CurveList.Clear()
        ' Set the titles and axis labels
        myPane.Title.Text = title.strTitle '"My Test Date Graph"
        myPane.XAxis.Title.Text = title.strXaxis '"Time(sec)"
        myPane.YAxis.Title.Text = title.strY1axis '"Amplitude(V)"

        ''Add gridlines to the plot, and make them gray
        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.IsVisible = True
        myPane.XAxis.MajorGrid.Color = Color.DarkGray
        myPane.YAxis.MajorGrid.Color = Color.DarkGray

        myPane.XAxis.Type = AxisType.Linear 'AxisType.Log

        ' Fill the axis background with a color gradient
        myPane.Chart.Fill = New Fill(Color.WhiteSmoke, Color.SteelBlue, 20.0F)

        ' Fill the pane background with a color gradient
        myPane.Fill = New Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0F)

        zgGraph.Update()
        zgGraph.Refresh()
    End Sub

    Public Sub GraphInit(ByVal mode As eGraphMode)

        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane

        zgGraph.GraphPane.CurveList.Clear()
        ' Set the titles and axis labels
        myPane.Title.Text = m_sModeCaptions(mode)
        myPane.XAxis.Title.Text = "Time(sec)"
        myPane.YAxis.Title.Text = "Amplitude(V)"

        ''Add gridlines to the plot, and make them gray
        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.IsVisible = True
        myPane.XAxis.MajorGrid.Color = Color.DarkGray
        myPane.YAxis.MajorGrid.Color = Color.DarkGray

        myPane.XAxis.Type = AxisType.Linear 'AxisType.Log

        ' Fill the axis background with a color gradient
        myPane.Chart.Fill = New Fill(Color.WhiteSmoke, Color.SteelBlue, 20.0F)

        ' Fill the pane background with a color gradient
        myPane.Fill = New Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0F)

        zgGraph.Update()
        zgGraph.Refresh()
    End Sub

    Public Sub GraphInitIVL()

        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane 'zgMainGraph.GraphPane
        Dim cntPlots As Integer

        zgGraph.GraphPane.CurveList.Clear()

        ' Set the titles and axis labels
        myPane.Title.Text = m_sPlotCaptions(m_XAxisItem) & " vs " & m_sPlotCaptions(m_YAxisItem)
        myPane.Title.FontSpec.Size = 10
        myPane.XAxis.Title.Text = m_sPlotCaptions(m_XAxisItem)
        myPane.XAxis.Title.FontSpec.Size = 10
        myPane.YAxis.Title.Text = m_sPlotCaptions(m_YAxisItem)
        myPane.YAxis.Title.FontSpec.Size = 10

        myPane.XAxis.Scale.FontSpec.Size = 10
        myPane.YAxis.Scale.FontSpec.Size = 10

        If m_bScaleXAuto = True Then
            myPane.XAxis.Scale.MaxAuto = True
            myPane.XAxis.Scale.MinAuto = True
        Else
            myPane.XAxis.Scale.Min = m_dScaleXmin
            myPane.XAxis.Scale.Max = m_dScaleXmax
        End If

        ''Add gridlines to the plot, and make them gray
        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.IsVisible = True
        myPane.XAxis.MajorGrid.Color = Color.LightGray
        myPane.YAxis.MajorGrid.Color = Color.LightGray

        myPane.XAxis.Type = m_XAxisScaleType 'AxisType.Linear 'AxisType.Log  '
        myPane.YAxis.Type = m_Y1AxisScaleType 'AxisType.Log
        ' Fill the axis background with a color gradient
        myPane.Legend.Fill = New Fill(Color.Black, Color.LightGray)
        '  myPane.Chart.Fill = New Fill(Color.WhiteSmoke, Color.SteelBlue, 20.0F)
        myPane.Chart.Fill = New Fill(Color.Black, Color.Black, 100.0F)
        ' Fill the pane background with a color gradient
        myPane.Fill = New Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0F)

        Dim list As PointPairList = New PointPairList()

        Dim plotCurves(m_numOfPlotCurve) As ZedGraph.CurveItem ' = myPane.AddCurve("Spectrum", list, Color.Yellow, ZedGraph.SymbolType.None)
        'Dim Ch2Curve As ZedGraph.CurveItem = myPane.AddCurve("CH2", list, Color.LightBlue, ZedGraph.SymbolType.None)
        'Dim Ch3Curve As ZedGraph.CurveItem = myPane.AddCurve("CH3", list, Color.LightPink, ZedGraph.SymbolType.None)
        'Dim Ch4Curve As ZedGraph.CurveItem = myPane.AddCurve("CH4", list, Color.Lime, ZedGraph.SymbolType.None)

        For cntPlots = 0 To m_numOfPlotCurve - 1
            plotCurves(cntPlots) = myPane.AddCurve("", list, m_LineColors(cntPlots), ZedGraph.SymbolType.None)
            plotCurves(cntPlots).Label.FontSpec = New FontSpec(m_sCurveName(cntPlots), 7, Color.Black, True, False, False)
        Next
        GraphRefresh()

    End Sub

    Public Sub AddYAxis(ByVal sTitle As String, ByVal fontColor As System.Drawing.Color, ByVal bisY2Axis As Boolean)

        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane

        If bisY2Axis = False Then
            myPane.AddYAxis(sTitle)
            myPane.YAxisList(myPane.YAxisList.Count - 1).Title.Text = sTitle
            myPane.YAxisList(myPane.YAxisList.Count - 1).Title.FontSpec.Size = 8
            myPane.YAxisList(myPane.YAxisList.Count - 1).Scale.FontSpec.Size = 8
            myPane.YAxisList(myPane.YAxisList.Count - 1).MajorGrid.IsVisible = True
            myPane.YAxisList(myPane.YAxisList.Count - 1).MajorGrid.Color = ColorTranslator.FromOle((ColorTranslator.ToWin32(fontColor) - 5)) 'Color.LightGray
            myPane.YAxisList(myPane.YAxisList.Count - 1).Title.FontSpec.FontColor = fontColor
        Else
            myPane.AddY2Axis(sTitle)
            myPane.Y2AxisList(myPane.Y2AxisList.Count - 1).Title.FontSpec.Size = 8
            myPane.Y2AxisList(myPane.Y2AxisList.Count - 1).Scale.FontSpec.Size = 8
            myPane.Y2AxisList(myPane.Y2AxisList.Count - 1).MajorGrid.IsVisible = True
            myPane.Y2AxisList(myPane.Y2AxisList.Count - 1).MajorGrid.Color = ColorTranslator.FromOle((ColorTranslator.ToOle(fontColor) - 5)) ' Color.LightGray
            myPane.Y2AxisList(myPane.Y2AxisList.Count - 1).IsVisible = True
            myPane.Y2AxisList(myPane.Y2AxisList.Count - 1).Title.Text = sTitle
            myPane.Y2AxisList(myPane.Y2AxisList.Count - 1).Title.FontSpec.FontColor = fontColor
        End If

    End Sub

    'Public Sub DrawingGraph(ByVal waveData As CDataProcess.sWaveData, ByVal sLabel As String, ByVal lineColor As Color, ByVal fIsY2Axis As Boolean)
    '    Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane
    '    myPane.XAxis.Scale.MaxAuto = True
    '    myPane.XAxis.Scale.MinAuto = True

    '    If waveData.dAmplitude.Length <= 0 Or waveData.dTime.Length <= 0 Then Exit Sub

    '    Dim pList As PointPairList = New PointPairList()

    '    'If chCurve.NPts <> 0 Then
    '    '    chCurve.Clear()
    '    'End If

    '    'If myPane.CurveList(ch).NPts <> 0 Then
    '    '    myPane.CurveList(ch).Clear()
    '    'End If
    '    pList.Add(waveData.dTime, waveData.dAmplitude)

    '    Dim myCurve As LineItem

    '    myCurve = myPane.AddCurve(sLabel, pList, lineColor, SymbolType.None)
    '    myCurve.Label.FontSpec = New FontSpec(sLabel, 7, Color.Black, True, False, False)
    '    'Dim color As double = Convert.ToSingle(em.Drawing.Color.Yellow, double)

    '    myCurve.IsY2Axis = fIsY2Axis

    '    ' Calculate the Axis Scale Ranges
    '    zgGraph.AxisChange()
    '    GraphRefresh()
    'End Sub

    'Public Sub DrawingGraph(ByVal waveData As CDataProcess.sWaveData, ByVal sLabel As String, ByVal lineColor As Color, _
    '                        ByVal fIsY2Axis As Boolean, ByVal YAxisIndex As Integer)

    '    Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane
    '    myPane.XAxis.Scale.MaxAuto = True
    '    myPane.XAxis.Scale.MinAuto = True

    '    If waveData.dAmplitude.Length <= 0 Or waveData.dTime.Length <= 0 Then Exit Sub

    '    Dim pList As PointPairList = New PointPairList()
    '    Dim time() As Double
    '    Dim proc As New CDataProcess

    '    time = proc.TimeShiftToZero(waveData.dTime)

    '    pList.Add(time, waveData.dAmplitude)   'waveData.dTime

    '    Dim myCurve As LineItem

    '    myCurve = myPane.AddCurve(sLabel, pList, lineColor, SymbolType.None)
    '    myCurve.Label.FontSpec = New FontSpec(sLabel, 7, Color.Black, True, False, False)

    '    myCurve.IsY2Axis = fIsY2Axis
    '    myCurve.YAxisIndex = YAxisIndex

    '    ' Calculate the Axis Scale Ranges
    '    zgGraph.AxisChange()
    '    GraphRefresh()
    'End Sub


#End Region

#Region "Drawing Curve"

    Public Sub AddPlotPoint(ByVal index As frmMain.eMeasureItem, ByVal datas As sPointValue)

        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane

        Dim CurveListIndex As Integer = index

        ' Dim chCurve As ZedGraph.CurveItem = myPane.CurveList(ch)
        Dim CurveList1 As PointPairList = myPane.CurveList(CurveListIndex).Points ' New PointPairList()

        'If myPane.CurveList(0).NPts <> 0 Then
        '    myPane.CurveList(0).Clear()
        'End If
        CurveList1.Add(datas.dTime_Hour, datas.dValue1)


        myPane.CurveList(CurveListIndex).Points = CurveList1


        If myPane.CurveList(CurveListIndex).IsVisible = True Then
            myPane.XAxis.Scale.Min = CurveList1.Item(0).X
            myPane.XAxis.Scale.Max = CurveList1.Item(CurveList1.Count - 1).X * 1.05
            myPane.YAxisList(CurveListIndex).Scale.MinAuto = True
            myPane.YAxisList(CurveListIndex).Scale.MaxAuto = True
        End If

        'myPane.XAxis.Scale.MaxAuto = True
        'myPane.XAxis.Scale.MinAuto = True
        Try
            zgGraph.AxisChange()
        Catch ex As Exception

        End Try

        GraphRefresh()
    End Sub

    Private Sub DrawingGraph(ByVal arrData As Array, ByVal dInterval As Double)
        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane
        Dim inData(arrData.Length - 1) As Double
        If arrData.Length <= 0 Then
            Exit Sub
        End If

        arrData.CopyTo(inData, 0)

        If m_bScaleXAuto = True Then
            myPane.XAxis.Scale.MaxAuto = True
            myPane.XAxis.Scale.MinAuto = True
        Else
            myPane.XAxis.Scale.Min = m_dScaleXmin
            myPane.XAxis.Scale.Max = m_dScaleXmax
        End If

        Dim arrXVal(arrData.Length - 1) As Double 'Time
        Dim arrYVal(arrData.Length - 1) As Double 'Voltage
        Dim cnt As Integer

        ' Dim chCurve As ZedGraph.CurveItem = myPane.CurveList(ch)
        Dim ch1List As PointPairList = New PointPairList()

        If myPane.CurveList(0).NPts <> 0 Then
            myPane.CurveList(0).Clear()
        End If

        For cnt = 0 To arrData.Length - 1
            arrYVal(cnt) = inData(cnt)
            arrXVal(cnt) = dInterval * cnt
            ch1List.Add(arrXVal(cnt), arrYVal(cnt))
        Next

        myPane.CurveList(0).Points = ch1List

        zgGraph.AxisChange()
        GraphRefresh()

    End Sub

    Private Sub DrawingGraph(ByVal xData() As Double, ByVal yData() As Double)
        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane

        If xData Is Nothing Or yData Is Nothing Then
            GraphRefresh()
            Exit Sub
        End If

        If xData.Length <= 0 Or xData.Length <> yData.Length Then
            Exit Sub
        End If

        If m_bScaleXAuto = True Then
            myPane.XAxis.Scale.MaxAuto = True
            myPane.XAxis.Scale.MinAuto = True
        Else
            myPane.XAxis.Scale.Min = m_dScaleXmin
            myPane.XAxis.Scale.Max = m_dScaleXmax
        End If

        Dim cnt As Integer

        ' Dim chCurve As ZedGraph.CurveItem = myPane.CurveList(ch)
        '  Dim ch1List As PointPairList = New PointPairList()


        If myPane.CurveList(0).NPts <> 0 Then
            myPane.CurveList(0).Clear()
        End If

        Dim curve As LineItem = Nothing
        curve = myPane.CurveList(0)
        Dim list As IPointListEdit = curve.Points

        For cnt = 0 To xData.Length - 1
            'If xData(cnt) = 0 Or yData(cnt) = 0 Then

            ' Else
            list.Add(xData(cnt), yData(cnt))
            ' End If
            '  ch1List.Add(xData(cnt), yData(cnt))
        Next

        myPane.CurveList(0).Points = list

        zgGraph.Invalidate()
        zgGraph.AxisChange()

    End Sub

    Public Sub DrawingGraph(ByVal ch As Integer, ByVal arrData As Array, ByVal dInterval As Double)
        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane

        myPane.XAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MinAuto = True

        Dim inData(arrData.Length - 1) As Double

        If arrData.Length <= 0 Then
            Exit Sub
        End If

        arrData.CopyTo(inData, 0)

        Dim arrXVal(arrData.Length - 1) As Double 'Time
        Dim arrYVal(arrData.Length - 1) As Double 'Voltage(V)

        Dim cnt As Integer

        Dim pList As PointPairList = New PointPairList()

        For cnt = 0 To arrData.Length - 1
            arrXVal(cnt) = dInterval * cnt
            arrYVal(cnt) = inData(cnt)
            pList.Add(arrXVal(cnt), arrYVal(cnt))
        Next

        Dim myCurve As LineItem

        Select Case ch
            Case 0    'Driveing signal(Current)
                myCurve = myPane.AddCurve("CH1", pList, Color.Yellow, SymbolType.None)
                myCurve.Label.FontSpec = New FontSpec("CH1", 7, Color.Black, True, False, False)
                myCurve.IsY2Axis = True
                'myPane.CurveList(0).Points = ch1List
            Case 1    'Ref. signal
                myCurve = myPane.AddCurve("CH2", pList, Color.White, SymbolType.None)
                myCurve.Label.FontSpec = New FontSpec("CH2", 7, Color.Black, True, False, False)
                'myCurve.IsY2Axis = True
                'myPane.CurveList(1).Points = ch2List
            Case 2    'EL Signal
                myCurve = myPane.AddCurve("CH3", pList, Color.Green, SymbolType.None)
                myCurve.Label.FontSpec = New FontSpec("CH3", 7, Color.Black, True, False, False)
                myCurve.IsY2Axis = True
                'myPane.CurveList(2).Points = ch3List
            Case 3    'Trigger Signal
                myCurve = myPane.AddCurve("CH4", pList, Color.Cyan, SymbolType.None)  'Trigger
                myCurve.Label.FontSpec = New FontSpec("CH4", 7, Color.Black, True, False, False)
                'myCurve.IsY2Axis = True
                'myPane.CurveList(3).Points = ch4List
        End Select

        ' Calculate the Axis Scale Ranges
        zgGraph.AxisChange()
        GraphRefresh()

    End Sub


    'Public Sub DrawingGraph(ByVal data() As CDataProcess.sWaveData)
    '    Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane

    '    myPane.CurveList.Clear()
    '    Dim nCurveLen As Integer
    '    Dim nDataLen As Integer
    '    Dim nCntCurve As Integer

    '    nCurveLen = data.Length
    '    nDataLen = data(0).dAmplitude.Length

    '    Dim myCurve As ZedGraph.CurveItem

    '    Dim dPlotX(nCurveLen - 1)() As Double
    '    Dim dPlotY(nCurveLen - 1)() As Double

    '    For nCntCurve = 0 To nCurveLen - 1
    '        dPlotY(nCntCurve) = data(nCntCurve).dAmplitude.Clone
    '        dPlotX(nCntCurve) = data(nCntCurve).dTime.Clone
    '        myCurve = myPane.AddCurve("", dPlotX(nCntCurve), dPlotY(nCntCurve), LineColor(nCntCurve), ZedGraph.SymbolType.None)
    '    Next
    '    zgGraph.AxisChange()
    '    GraphRefresh()

    'End Sub

    'Public Sub DrawingGraph(ByVal data As CDataProcess.sWaveData)

    '    Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane
    '    myPane.CurveList.Clear()

    '    Dim nDataLen As Integer
    '    Dim myCurve As ZedGraph.CurveItem

    '    nDataLen = data.dAmplitude.Length

    '    Dim dPlotX() As Double
    '    Dim dPlotY() As Double

    '    dPlotY = data.dAmplitude
    '    dPlotX = data.dTime

    '    myCurve = myPane.AddCurve("", dPlotX, dPlotY, Color.Yellow, ZedGraph.SymbolType.None)
    '    zgGraph.AxisChange()
    '    GraphRefresh()
    'End Sub

    Public Sub PlotData(ByVal arrData() As UShort)

        Dim numData As Integer = arrData.Length
        Dim nDataPoint(numData - 1) As Integer
        Dim spectrumData(numData - 1) As UShort
        Dim nCnt As Integer

        If arrData Is Nothing Then
            Exit Sub
        End If

        For nCnt = 0 To numData - 1
            nDataPoint(nCnt) = nCnt
            spectrumData(nCnt) = arrData(nCnt)
        Next

        m_dScaleXmin = nDataPoint(0)
        m_dScaleXmax = nDataPoint(nDataPoint.Length - 1)
        DrawingGraph(spectrumData, 1)
    End Sub

    Public Sub PlotData(ByVal numOfData As Integer, ByVal xData() As Double, ByVal yData() As Double)
        Dim xPlotBuf(numOfData - 1) As Double
        Dim yPlotbuf(numOfData - 1) As Double

        Array.Copy(xData, xPlotBuf, numOfData)
        Array.Copy(yData, yPlotbuf, numOfData)

        DrawingGraph(xPlotBuf, yPlotbuf)
    End Sub

    Public Sub SetYAxisLevelHighLight(ByVal dValue As Double)

        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane
        myPane.GraphObjList.Clear()
        Dim dScaleXmin As Double = myPane.XAxis.Scale.Min
        Dim dScaleXMax As Double = myPane.XAxis.Scale.Max

        Dim Line As LineObj = New LineObj(System.Drawing.Color.Red, dScaleXmin, dValue, dScaleXMax, dValue - 1)

        myPane.GraphObjList.Add(Line)
        GraphRefresh()

    End Sub

    Public Sub SetXAxisLevelLine(ByVal dValue() As Double)

        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane
        myPane.GraphObjList.Clear()
        Dim dScaleYmin As Double = myPane.YAxis.Scale.Min
        Dim dScaleYMax As Double = myPane.YAxis.Scale.Max

        Dim Line As LineObj

        For i As Integer = 0 To dValue.Length - 1
            Line = New LineObj(System.Drawing.Color.Blue, dValue(i), dScaleYMax, dValue(i) - 1, dScaleYmin)



            myPane.GraphObjList.Add(Line)
        Next

        GraphRefresh()

    End Sub

    Public Sub SetLine(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double)
        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane
        'myPane.GraphObjList.Clear()
        Dim dScaleYmin As Double = myPane.YAxis.Scale.Min
        Dim dScaleYMax As Double = myPane.YAxis.Scale.Max

        Dim Line As LineObj = New LineObj

        ' For i As Integer = 0 To dValue.Length - 1
        Line = New LineObj(System.Drawing.Color.OrangeRed, x1, y1, x2, y2)

        myPane.GraphObjList.Add(Line)
        ' Next

        GraphRefresh()

    End Sub

    Public Sub ClearLine()
        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane
        myPane.GraphObjList.Clear()
        GraphRefresh()
    End Sub

#End Region

#Region "IVL Display Functions"


    Public Overridable Function SetPlotData(ByVal inIVLData() As frmMain.sPanelIVLMeasure) As Boolean


        If inIVLData Is Nothing Then Return False

        Try
            m_PanelOutData = inIVLData.Clone
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        ReDim m_dVoltage(inIVLData.Length - 1)
        ReDim m_dCurrent(inIVLData.Length - 1)
        ReDim m_dABSCurrent(inIVLData.Length - 1)
        ReDim m_dJ(inIVLData.Length - 1)
        ReDim m_dABS_J(inIVLData.Length - 1)
        ReDim m_dCdm2(inIVLData.Length - 1)
        ReDim m_dCdA(inIVLData.Length - 1)
        ReDim m_dlmW(inIVLData.Length - 1)
        '  ReDim m_dIntencity(inSpec.Length - 1)
        '  ReDim m_nWavelength(inSpec.Length - 1)

        For i As Integer = 0 To inIVLData.Length - 1
            'm_dVoltage(i) = inIVLData(i).d
            'm_dCurrent(i) = inIVLData(i).dCurrent * 1000
            'm_dABSCurrent(i) = inIVLData(i).dABS_I
            'm_dJ(i) = inIVLData(i).dJ
            'm_dABS_J(i) = inIVLData(i).dAbs_J
            m_dCdA(i) = inIVLData(i).dCdA
            m_dCdm2(i) = inIVLData(i).dCdm2
            m_dlmW(i) = inIVLData(i).dlmW


        Next

        'For i As Integer = 0 To inSpec.Length - 1
        '    m_dIntencity(i) = inSpec(i).D5.s4Intensity
        '    m_nWavelength(i) = inSpec(i).D5.i3nm
        'Next

        Return True
    End Function

    Public Function SetPlotData(ByVal inIVLData() As frmMain.sCellIVLMeasure) As Boolean

        If inIVLData Is Nothing Then Return False

        Try
            m_OutData = inIVLData.Clone
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        ReDim m_dVoltage(inIVLData.Length - 1)
        ReDim m_dCurrent(inIVLData.Length - 1)
        ReDim m_dABSCurrent(inIVLData.Length - 1)
        ReDim m_dJ(inIVLData.Length - 1)
        ReDim m_dABS_J(inIVLData.Length - 1)
        ReDim m_dCdm2(inIVLData.Length - 1)
        ReDim m_dCdA(inIVLData.Length - 1)
        ReDim m_dlmW(inIVLData.Length - 1)
        ReDim m_dAngle(inIVLData.Length - 1)
        ReDim m_dQE(inIVLData.Length - 1)

        '  ReDim m_dIntencity(inSpec.Length - 1)
        '  ReDim m_nWavelength(inSpec.Length - 1)

        For i As Integer = 0 To inIVLData.Length - 1
            m_dVoltage(i) = inIVLData(i).dVoltage
            m_dCurrent(i) = inIVLData(i).dCurrent
            m_dABSCurrent(i) = inIVLData(i).dABS_I
            m_dJ(i) = inIVLData(i).dJ
            m_dABS_J(i) = inIVLData(i).dAbs_J
            m_dCdA(i) = inIVLData(i).dCdA
            m_dCdm2(i) = inIVLData(i).dLuminance_Cdm2
            m_dlmW(i) = inIVLData(i).dlmW
            m_dAngle(i) = inIVLData(i).dAngle
            m_dQE(i) = inIVLData(i).dQE
        Next

        'For i As Integer = 0 To inSpec.Length - 1
        '    m_dIntencity(i) = inSpec(i).D5.s4Intensity
        '    m_nWavelength(i) = inSpec(i).D5.i3nm
        'Next

        Return True
    End Function

    Public Sub PlotIVLData(ByVal mode As eIVLPlotMode)

        Dim myPane As GraphPane = zgGraph.GraphPane

        m_selectMode = mode

        PlotIVLData()

        'Select Case m_selectMode

        '    Case eIVLPlotMode.eVvsC   '0
        '        myPane.Title.Text = "Voltag - Current Graph" ' 제목
        '        myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"Current(mA)" X 축
        '        myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCurrent) '"Voltage" 'Y 축
        '        DrawingGraph(m_dVoltage, m_dCurrent)
        '    Case eIVLPlotMode.eVvsABS_C '1
        '        myPane.Title.Text = "Voltage - ABS_Current Graph" ' 제목
        '        myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) 'X 축
        '        myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eAbsCurrent) 'Y 축
        '        DrawingGraph(m_dVoltage, m_dABSCurrent)
        '    Case eIVLPlotMode.eVvsCdA '3
        '        myPane.Title.Text = "Voltage - Cd/A Graph" ' 제목
        '        myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"Cd/A" 'X 축
        '        myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_A) '"Voltage(V)" 'Y 축
        '        DrawingGraph(m_dVoltage, m_dCdA)
        '    Case eIVLPlotMode.eVvsCdm2 '2
        '        myPane.Title.Text = "Voltage - Cd/m2 Graph" ' 제목
        '        myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"Cd/m2" 'X 축
        '        myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_m2) '"Voltage(V)" 'Y 축
        '        DrawingGraph(m_dVoltage, m_dCdm2)
        '    Case eIVLPlotMode.eVvslmW '4
        '        myPane.Title.Text = "VoltAGE - lm/W Graph" ' 제목
        '        myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"lm/W" 'X 축
        '        myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.elm_W) '"Voltage(V)" 'Y 축
        '        DrawingGraph(m_dVoltage, m_dlmW)
        '    Case eIVLPlotMode.eJvsCdA '6
        '        myPane.Title.Text = "J - Cd/A Graph" ' 제목
        '        myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eJ) '"Cd/A" 'X 축
        '        myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_A) '"J(mA/cm2)" 'Y 축
        '        DrawingGraph(m_dJ, m_dCdA)
        '    Case eIVLPlotMode.eJvsCdm2 '5
        '        myPane.Title.Text = "J - Cd/m2 Graph" ' 제목
        '        myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eJ) '"Cd/m2" 'X 축
        '        myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_m2) '"J(mA/cm2)" 'Y 축
        '        DrawingGraph(m_dJ, m_dCdm2)
        '    Case eIVLPlotMode.eVvsJ   '9
        '        myPane.Title.Text = "Voltage - J Graph" ' 제목
        '        myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"J(mA/cm2)" 'X 축
        '        myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eJ) '"Voltage(V)" 'Y 축
        '        DrawingGraph(m_dVoltage, m_dJ)
        '    Case eIVLPlotMode.eVvsABS_J
        '        myPane.Title.Text = "Voltage - ABS_J Graph" ' 제목
        '        myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"Current(mA)" 'X 축
        '        myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eAbsCurrent) '"Voltage(V)" 'Y 축
        '        DrawingGraph(m_dVoltage, m_dCurrent)
        '    Case eIVLPlotMode.eJvslmW '7
        '        myPane.Title.Text = "J - lm/W Graph" ' 제목
        '        myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eJ) '"lm/W" 'X 축
        '        myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.elm_W) '"J(mA/cm2)" 'Y 축
        '        DrawingGraph(m_dJ, m_dlmW)
        '    Case eIVLPlotMode.eJvsV
        '        myPane.Title.Text = "J - Voltage Graph" ' 제목
        '        myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eJ) '"Voltage(V)" 'X 축
        '        myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"J(mA/cm2)" 'Y 축
        '        DrawingGraph(m_dJ, m_dVoltage)
        '    Case eIVLPlotMode.eCdm2vsCdA
        '        myPane.Title.Text = "Cd/m2 - Cd/A Graph" ' 제목
        '        myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_m2) '"Cd/A" 'X 축
        '        myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_A) '"Cd/m2" 'Y 축
        '        DrawingGraph(m_dCdA, m_dCdm2)
        '    Case eIVLPlotMode.eSpectrum
        '        'myPane.Title.Text = "WaveLength - Intencity Graph" ' 제목
        '        'myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eWaveLength) '"Cd/A" 'X 축
        '        'myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eIntencity) '"Cd/m2" 'Y 축
        '        '    DrawingGraph(m_nWavelength, m_dIntencity)

        'End Select

    End Sub


    Public Sub PlotIVLData()

        Dim myPane As GraphPane = zgGraph.GraphPane

        Select Case m_selectMode

            Case eIVLPlotMode.eVvsC   '0
                myPane.Title.Text = "Voltag - Current Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"Current(mA)" X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCurrent) '"Voltage" 'Y 축
                DrawingGraph(m_dVoltage, m_dCurrent)
            Case eIVLPlotMode.eVvsABS_C '1
                myPane.Title.Text = "Voltage - ABS_Current Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eAbsCurrent) 'Y 축
                DrawingGraph(m_dVoltage, m_dABSCurrent)
            Case eIVLPlotMode.eVvsCdA '3
                myPane.Title.Text = "Voltage - cd/A Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"Cd/A" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_A) '"Voltage(V)" 'Y 축
                DrawingGraph(m_dVoltage, m_dCdA)
            Case eIVLPlotMode.eVvsCdm2 '2
                myPane.Title.Text = "Voltage - cd/m2 Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"Cd/m2" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_m2) '"Voltage(V)" 'Y 축
                DrawingGraph(m_dVoltage, m_dCdm2)
            Case eIVLPlotMode.eVvslmW '4
                myPane.Title.Text = "Voltage - lm/W Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"lm/W" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.elm_W) '"Voltage(V)" 'Y 축
                DrawingGraph(m_dVoltage, m_dlmW)
            Case eIVLPlotMode.eJvsCdA '6
                myPane.Title.Text = "J - cd/A Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eJ) '"Cd/A" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_A) '"J(mA/cm2)" 'Y 축
                DrawingGraph(m_dJ, m_dCdA)
            Case eIVLPlotMode.eJvsCdm2 '5
                myPane.Title.Text = "J - cd/m2 Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eJ) '"Cd/m2" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_m2) '"J(mA/cm2)" 'Y 축
                DrawingGraph(m_dJ, m_dCdm2)
            Case eIVLPlotMode.eVvsJ   '9
                myPane.Title.Text = "Voltage - J Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"J(mA/cm2)" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eJ) '"Voltage(V)" 'Y 축
                DrawingGraph(m_dVoltage, m_dJ)
            Case eIVLPlotMode.eVvsABS_J
                myPane.Title.Text = "Voltage - ABS_J Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"Current(mA)" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eAbsJ) '"Voltage(V)" 'Y 축
                DrawingGraph(m_dVoltage, m_dABS_J)
            Case eIVLPlotMode.eJvslmW '7
                myPane.Title.Text = "J - lm/W Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eJ) '"lm/W" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.elm_W) '"J(mA/cm2)" 'Y 축
                DrawingGraph(m_dJ, m_dlmW)
            Case eIVLPlotMode.eJvsV
                myPane.Title.Text = "J - Voltage Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eJ) '"Voltage(V)" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"J(mA/cm2)" 'Y 축
                DrawingGraph(m_dJ, m_dVoltage)
            Case eIVLPlotMode.eCdm2vsCdA
                myPane.Title.Text = "cd/m2 - cd/A Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_m2) '"Cd/A" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_A) '"Cd/m2" 'Y 축
                DrawingGraph(m_dCdm2, m_dCdA)
            Case eIVLPlotMode.eSpectrum
                'myPane.Title.Text = "WaveLength - Intencity Graph" ' 제목
                'myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eWaveLength) '"Cd/A" 'X 축
                'myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eIntencity) '"Cd/m2" 'Y 축
                'DrawingGraph(m_nWavelength, m_dIntencity)
            Case eIVLPlotMode.eAnglevsCdm2
                myPane.Title.Text = "Viewer Angle - Cd/m2 Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eAngle) '"Cd/A" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_m2) '"Cd/m2" 'Y 축
                DrawingGraph(m_dAngle, m_dCdm2)
            Case eIVLPlotMode.eQEvsCdm2
                myPane.Title.Text = "Luminance - QE Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_m2) '"Cd/A" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eQE) '"Cd/m2" 'Y 축
                DrawingGraph(m_dCdm2, m_dQE)
            Case eIVLPlotMode.eVvsQE
                myPane.Title.Text = "Voltage - QE Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eVolt) '"Cd/A" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eQE) '"Cd/m2" 'Y 축
                DrawingGraph(m_dVoltage, m_dQE)
            Case eIVLPlotMode.eAnglevsQE
                myPane.Title.Text = "Viewer Angle - QE Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eAngle) '"Cd/A" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eQE) '"Cd/m2" 'Y 축
                DrawingGraph(m_dAngle, m_dQE)
            Case eIVLPlotMode.eAnglevsCdA
                myPane.Title.Text = "Viewer Angle - cd/A Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eAngle) '"Cd/A" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eCd_A) '"Cd/m2" 'Y 축
                DrawingGraph(m_dAngle, m_dCdA)
            Case eIVLPlotMode.eAnglevslmW
                myPane.Title.Text = "Viewer Angle - lm/W Graph" ' 제목
                myPane.XAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.eAngle) '"Cd/A" 'X 축
                myPane.YAxis.Title.Text = m_sPlotCaptions(eIVLPlotData.elm_W) '"Cd/m2" 'Y 축
                DrawingGraph(m_dAngle, m_dlmW)
        End Select

    End Sub

#End Region

#Region "Menu Item Event Functions"


    Private Sub CreateSelPlotModeMenu(ByRef sCaptions() As String)
        '  Dim tsItemCollection As ToolStripItemCollection = grpMenu.Items()
        ' Dim tsItem As ToolStripItem  '= tsItemCollection.Item(0)
        Dim tsmItem As ToolStripMenuItem = tsmSelectPlotMode
        Dim tsmItemDropDown(m_PlotItemInfo.Length - 1) As ToolStripMenuItem
        ReDim sCaptions(m_PlotItemInfo.Length - 1)
        Dim sTemp As String = ""

        tsmItem.DropDownItems.Clear()
        ' Dim index As Integer

        For i As Integer = 0 To m_PlotItemInfo.Length - 1

            Select Case m_PlotItemInfo(i)

                Case frmMain.eMeasureItem.Temp
                    sTemp = "Time(Hour) vs Temp"
                    sCaptions(i) = "Temp"
                Case frmMain.eMeasureItem.Cell_Voltage
                    sTemp = "Time(Hour) vs Volt(V)"
                    sCaptions(i) = "Volt"
                Case frmMain.eMeasureItem.Cell_Current
                    sTemp = "Time(Hour) vs Current"
                    sCaptions(i) = "Current"
                Case frmMain.eMeasureItem.Luminance_Rate
                    sTemp = "Time(Hour) vs Luminance"
                    sCaptions(i) = "Luminance"
                Case frmMain.eMeasureItem.PD_Current
                    sTemp = "Time(Hour) vs PD_Current"
                    sCaptions(i) = "PD_Current"
            End Select

            tsmItemDropDown(i) = New ToolStripMenuItem
            tsmItemDropDown(i).Text = "Func" & Format(i + 1, "00") & " " & sTemp
            tsmItemDropDown(i).CheckOnClick = True
            tsmItemDropDown(i).Checked = True
            tsmItemDropDown(i).Name = CStr(i)
            AddHandler tsmItemDropDown(i).CheckedChanged, AddressOf SelectPlotItem_CheckedChange
            tsmItem.DropDownItems.Add(tsmItemDropDown(i))

        Next

    End Sub

    Private Sub SelectPlotItem_CheckedChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim tsmItem As ToolStripMenuItem = sender
        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane
        'Dim numCurve As Integer = myPane.CurveList.Count
        'Dim lineItem(numCurve - 1) As ZedGraph.LineItem = myPane.CurveList.Clone

        If tsmItem.Checked = True Then
            myPane.CurveList(CInt(tsmItem.Name)).IsVisible = True
            myPane.YAxisList(CInt(tsmItem.Name)).IsVisible = True
            myPane.CurveList(CInt(tsmItem.Name)).Label.IsVisible = True
        Else
            myPane.CurveList(CInt(tsmItem.Name)).IsVisible = False
            myPane.YAxisList(CInt(tsmItem.Name)).IsVisible = False
            myPane.CurveList(CInt(tsmItem.Name)).Label.IsVisible = False
        End If

        GraphRefresh()
    End Sub

    Private Sub tsmSelectPlotItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim dlgSelPlot As New frmPlotItemSelectWind  'YSR_20120425

        'dlgSelPlot.setData(m_sPlotCaptions, m_XAxisItem, m_YAxisItem, m_XAxisScaleType, m_YAxisScaleType)

        'If dlgSelPlot.ShowDialog = DialogResult.OK Then
        '    dlgSelPlot.getPlotItem(m_XAxisItem, m_YAxisItem, m_XAxisScaleType, m_YAxisScaleType)
        '    GraphInitIVL()
        '      PlotData()
        'End If

    End Sub



    Private Sub tsmSaveImageAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSaveImageAs.Click
        zgGraph.SaveAsBitmap()
    End Sub

    Private Sub tsmPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmPageSetup.Click
        zgGraph.DoPageSetup()
    End Sub

    Private Sub tsmPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmPrint.Click
        zgGraph.DoPrint()
    End Sub

    Private Sub tsmShowPointValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmShowPointValues.Click
        If zgGraph.IsShowPointValues = True Then
            zgGraph.IsShowPointValues = False
        Else
            zgGraph.IsShowPointValues = True
        End If
    End Sub

    Private Sub ZoomEnableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomEnableToolStripMenuItem.Click
        zgGraph.IsEnableZoom = True
        '   zgGraph.IsEnableSelection = False
    End Sub

    Private Sub tsmUnZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmUnZoom.Click
        zgGraph.ZoomOutAll(zgGraph.GraphPane)

        zgGraph.IsEnableZoom = False
        zgGraph.IsEnableSelection = True

        'zgGraph.

    End Sub



#End Region

#Region "Axis Scale Log/Linear"


    Private Sub XAxisScaleLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XAxisScaleLogToolStripMenuItem.Click
        Dim menuItem As System.Windows.Forms.ToolStripMenuItem = sender
        Dim parentInternal As System.Windows.Forms.ContextMenuStrip = menuItem.Owner
        Dim grph As ZedGraph.ZedGraphControl = parentInternal.SourceControl
        grph.GraphPane.XAxis.Type = AxisType.Log 'AxisType.Log
        grph.GraphPane.XAxis.Scale.MinAuto = True
        grph.GraphPane.XAxis.Scale.MaxAuto = True
        grph.AxisChange()
        GraphRefresh()
    End Sub

    Private Sub XAxisScaleLinearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XAxisScaleLinearToolStripMenuItem.Click
        Dim menuItem As System.Windows.Forms.ToolStripMenuItem = sender
        Dim parentInternal As System.Windows.Forms.ContextMenuStrip = menuItem.Owner
        Dim grph As ZedGraph.ZedGraphControl = parentInternal.SourceControl

        grph.GraphPane.XAxis.Type = AxisType.Linear 'AxisType.Log
        grph.GraphPane.XAxis.Scale.MinAuto = True
        grph.GraphPane.XAxis.Scale.MaxAuto = True
        grph.AxisChange()
        'zgMainGraphRefresh()
        GraphRefresh()
    End Sub

    Private Sub Y1AxisScaleLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Y1AxisScaleLogToolStripMenuItem.Click
        Dim menuItem As System.Windows.Forms.ToolStripMenuItem = sender
        Dim parentInternal As System.Windows.Forms.ContextMenuStrip = menuItem.Owner
        Dim grph As ZedGraph.ZedGraphControl = parentInternal.SourceControl

        grph.GraphPane.YAxis.Type = AxisType.Log 'AxisType.Log
        grph.GraphPane.YAxis.Scale.MaxAuto = True
        grph.GraphPane.YAxis.Scale.MinAuto = True
        grph.AxisChange()
        'zgMainGraphRefresh()
        GraphRefresh()
    End Sub

    Private Sub Y1AxisScaleLinearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Y1AxisScaleLinearToolStripMenuItem.Click
        Dim menuItem As System.Windows.Forms.ToolStripMenuItem = sender
        Dim parentInternal As System.Windows.Forms.ContextMenuStrip = menuItem.Owner
        Dim grph As ZedGraph.ZedGraphControl = parentInternal.SourceControl

        grph.GraphPane.YAxis.Type = AxisType.Linear 'AxisType.Log
        grph.GraphPane.YAxis.Scale.MaxAuto = True
        grph.GraphPane.YAxis.Scale.MinAuto = True
        grph.AxisChange()
        'zgMainGraphRefresh()
        GraphRefresh()
    End Sub

    Private Sub Y2AxisScaleLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Y2AxisScaleLogToolStripMenuItem.Click
        Dim menuItem As System.Windows.Forms.ToolStripMenuItem = sender
        Dim parentInternal As System.Windows.Forms.ContextMenuStrip = menuItem.Owner
        Dim grph As ZedGraph.ZedGraphControl = parentInternal.SourceControl

        grph.GraphPane.Y2Axis.Type = AxisType.Log 'AxisType.Log
        grph.GraphPane.Y2Axis.Scale.MaxAuto = True
        grph.GraphPane.Y2Axis.Scale.MinAuto = True
        grph.AxisChange()
        'zgMainGraphRefresh()
        GraphRefresh()
    End Sub

    Private Sub Y2AxisScaleLinearToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Y2AxisScaleLinearToolStripMenuItem1.Click
        Dim menuItem As System.Windows.Forms.ToolStripMenuItem = sender
        Dim parentInternal As System.Windows.Forms.ContextMenuStrip = menuItem.Owner
        Dim grph As ZedGraph.ZedGraphControl = parentInternal.SourceControl

        grph.GraphPane.Y2Axis.Type = AxisType.Linear 'AxisType.Log
        grph.GraphPane.Y2Axis.Scale.MaxAuto = True
        grph.GraphPane.Y2Axis.Scale.MinAuto = True
        grph.AxisChange()
        'zgMainGraphRefresh()
        GraphRefresh()
    End Sub



#End Region

    Public ReadOnly Property PlotItemIndex() As String()
        Get
            Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane
            Dim sPlotIndexs(myPane.CurveList.Count - 1) As String

            For i As Integer = 0 To myPane.CurveList.Count - 1
                sPlotIndexs(i) = myPane.CurveList(i).Label.Text
            Next
            Return sPlotIndexs
        End Get
    End Property

    Public ReadOnly Property PlotItemLineColor() As Color()
        Get
            Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane
            Dim sPlotIndexs(myPane.CurveList.Count - 1) As Color

            For i As Integer = 0 To myPane.CurveList.Count - 1
                sPlotIndexs(i) = myPane.CurveList(i).Color
            Next
            Return sPlotIndexs
        End Get
    End Property

    Public Sub ChangeLineColor(ByVal index As Integer, ByVal colorInfo As Color)
        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane
        If myPane.CurveList.Count <= index Then Exit Sub
        myPane.CurveList(index).Color = colorInfo

        zgGraph.Refresh()
    End Sub

    Private Sub ChangeLineColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeLineColorToolStripMenuItem.Click

        Dim myPane As ZedGraph.GraphPane = zgGraph.GraphPane
        Dim numCurve As Integer = myPane.CurveList.Count
        Dim curveList As ZedGraph.CurveList = myPane.CurveList

        Dim lineItem(numCurve - 1) As ZedGraph.LineItem

        For i As Integer = 0 To numCurve - 1
            lineItem(i) = curveList(i)
        Next

        Dim dlg As frmGrpPlotItemSelector = New frmGrpPlotItemSelector


        Dim sPlotItemIndex(numCurve - 1) As String
        Dim sPlotItemColor(numCurve - 1) As System.Drawing.Color

        For i As Integer = 0 To numCurve - 1
            sPlotItemIndex(i) = lineItem(i).Label.Text
            sPlotItemColor(i) = lineItem(i).Color
        Next


        dlg.ItemIndex = sPlotItemIndex
        dlg.ItemColor = sPlotItemColor

        If dlg.ShowDialog = DialogResult.OK Then
            sPlotItemIndex = dlg.ItemIndex
            sPlotItemColor = dlg.ItemColor

            For i As Integer = 0 To numCurve - 1
                lineItem(i).Color = sPlotItemColor(i)
            Next

        Else

        End If

        zgGraph.Refresh()

    End Sub

    Private Sub zgGraph_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles zgGraph.MouseClick

        Dim a As Integer = 0

        'RaiseEvent evMouseClick()
    End Sub


    Private Function zgGraph_MouseDownEvent(ByVal sender As ZedGraph.ZedGraphControl, ByVal e As System.Windows.Forms.MouseEventArgs) As Boolean Handles zgGraph.MouseDownEvent

        RaiseEvent evMouseDown(e)

        If zgGraph.IsEnableVZoom = False And zgGraph.IsEnableHZoom = False Then
            Return True
        End If
        Return False
    End Function


    Private Function zgGraph_MouseUpEvent(ByVal sender As ZedGraph.ZedGraphControl, ByVal e As System.Windows.Forms.MouseEventArgs) As Boolean Handles zgGraph.MouseUpEvent
        'Dim a As Integer = 0
        RaiseEvent evMouseUp(e)
        If zgGraph.IsEnableVZoom = False And zgGraph.IsEnableHZoom = False Then
            Return True
        End If
        Return False

    End Function

    Private Function zgGraph_PointValueEvent(ByVal sender As ZedGraph.ZedGraphControl, ByVal pane As ZedGraph.GraphPane, ByVal curve As ZedGraph.CurveItem, ByVal iPt As Integer) As String Handles zgGraph.PointValueEvent

        Dim pointPare As ZedGraph.PointPair

        pointPare = curve.Item(iPt)

        m_SelectCurve = curve

        m_nSelectPoint = iPt

        m_dPointValueX = pointPare.X
        m_dPointValueY = pointPare.Y

        Dim mousePt As Point = Control.MousePosition

        Return pointPare.ToString

    End Function

    Dim data1 As sPointValue
    Dim data2 As sPointValue
    Dim data3 As sPointValue



    Private Sub btnTestAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestAdd.Click

        data1.dTime_Hour = data1.dTime_Hour + 1
        data1.dValue1 = 3
        AddPlotPoint(0, data1)


    End Sub

   
    Private Sub btnTestInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestInit.Click
        ReDim m_PlotItemInfo(0)
        m_PlotItemInfo(0) = 1
        

        InitGraph(m_PlotItemInfo)
    End Sub

  
#Region "Graph Menu Event"
    Private Sub tsmVoltageVSCurrent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmVoltageVSCurrent.Click
        PlotIVLData(eIVLPlotMode.eVvsC)
    End Sub

    Private Sub tsmVoltageVSABS_Current_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmVoltageVSABS_Current.Click
        PlotIVLData(eIVLPlotMode.eVvsABS_C)
    End Sub

    Private Sub tsmVoltageVSJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmVoltageVSJ.Click
        PlotIVLData(eIVLPlotMode.eVvsJ)
    End Sub

    Private Sub tsmVoltageVSABS_J_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmVoltageVSABS_J.Click
        PlotIVLData(eIVLPlotMode.eVvsABS_J)
    End Sub

    Private Sub tsmVoltageVSLuminance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmVoltageVSLuminance.Click
        PlotIVLData(eIVLPlotMode.eVvsCdm2)
    End Sub

    Private Sub tsmVoltageVSCdA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmVoltageVSCdA.Click
        PlotIVLData(eIVLPlotMode.eVvsCdA)
    End Sub

    Private Sub tsmVoltageVSlmW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmVoltageVSlmW.Click
        PlotIVLData(eIVLPlotMode.eVvslmW)
    End Sub

    Private Sub tsmJVSVoltage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmJVSVoltage.Click
        PlotIVLData(eIVLPlotMode.eJvsV)
    End Sub

    Private Sub tsmJVSLuminance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmJVSLuminance.Click
        PlotIVLData(eIVLPlotMode.eJvsCdm2)
    End Sub

    Private Sub tsmJVSCdA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmJVSCdA.Click
        PlotIVLData(eIVLPlotMode.eJvsCdA)
    End Sub

    Private Sub tsmJVSlmW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmJVSlmW.Click
        PlotIVLData(eIVLPlotMode.eJvslmW)
    End Sub

    Private Sub tsmLuminanceVSCdA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmLuminanceVSCdA.Click
        PlotIVLData(eIVLPlotMode.eCdm2vsCdA)
    End Sub

    Private Sub tsmAngleVSLuminance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAngleVSLuminance.Click
        PlotIVLData(eIVLPlotMode.eAnglevsCdm2)
    End Sub
    Private Sub AngleVSQEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AngleVSQEToolStripMenuItem.Click
        PlotIVLData(eIVLPlotMode.eAnglevsQE)
    End Sub
    Private Sub AngleVSCdAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AngleVSCdAToolStripMenuItem.Click
        PlotIVLData(eIVLPlotMode.eAnglevsCdA)
    End Sub

    Private Sub AngleVSLmWToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AngleVSLmWToolStripMenuItem.Click
        PlotIVLData(eIVLPlotMode.eAnglevslmW)
    End Sub
#End Region

   


End Class
