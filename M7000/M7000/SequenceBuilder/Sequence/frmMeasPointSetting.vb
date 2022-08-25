Imports System.IO

Public Class frmMeasPointSetting


    ' Dim m_MeasPointInfo As ucDispPointSetting.sMeasurePointInfos


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub

    Private Sub init()
        ucDispPointSetting.Location = New System.Drawing.Point(0, 0)
        ucDispPointSetting.Dock = DockStyle.Fill
    End Sub

#Region "Properties"

    Public Property Settings As ucDispPointSetting.sMeasurePointInfos
        Get
            Return ucDispPointSetting.Settings
        End Get
        Set(ByVal value As ucDispPointSetting.sMeasurePointInfos)
            ucDispPointSetting.Settings = value
        End Set
    End Property

    Public Property targetSize As ucSampleInfos.sSampleSize
        Get
            Return ucDispPointSetting.targetSize   'UcDispTarget_PanelModuel1.TargetSize
        End Get
        Set(ByVal value As ucSampleInfos.sSampleSize)
            ucDispPointSetting.targetSize = value '  UcDispTarget_PanelModuel1.TargetSize = value
        End Set
    End Property

    Public Property TargetType As ucSampleInfos.eSampleType
        Get
            Return ucDispPointSetting.TargetType ' UcDispTarget_PanelModuel1.TargetType
        End Get
        Set(ByVal value As ucSampleInfos.eSampleType)
            ucDispPointSetting.TargetType = value
        End Set
    End Property

    Public Property Temp As Double
        Get
            Return ucDispPointSetting.Temp ' UcDispTarget_PanelModuel1.Temp
        End Get
        Set(ByVal value As Double)
            ucDispPointSetting.Temp = value
        End Set
    End Property



#End Region

#Region "Functions"


    Private Sub frmMeasPointSetting_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ucDispPointSetting.SaveWindowEnv()
    End Sub


#End Region

    Private Sub frmMeasPointSetting_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
        Timer1.Interval = 100
        Timer1.Enabled = True
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim currentSize As Size = Me.Size
        Me.Size = New System.Drawing.Size(currentSize.Width + 2, currentSize.Height + 2)
        Timer1.Enabled = False
    End Sub
End Class