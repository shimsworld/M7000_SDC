Imports System

Public Class ucCS100A



#Region "Defines"
    Dim m_SettingInfos As CDevCS100A.sSettings

    Public Event evConnection()
    Public Event evDisconnection()

    Public Event evMeasure()

    Public Event evSetMeasMode(ByVal mode As CDevCS100A.eMeasuringMode)
    Public Event evSetSpeedMode(ByVal mode As CDevCS100A.eSpeedmode)
    Public Event evSetCalibrationMode(ByVal mode As CDevCS100A.eCalibrationMode)



#End Region

#Region "Properties"

    Public Property Settings As CDevCS100A.sSettings
        Get
            GetValueFromUI()
            Return m_SettingInfos
        End Get
        Set(value As CDevCS100A.sSettings)
            m_SettingInfos = value
            SetValueToUI()
        End Set
    End Property

    Public WriteOnly Property MeasuredData As String
        Set(value As String)
            Label1.Text = value
        End Set
    End Property



#End Region

#Region "Creator, Disposer And init"


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Private Sub init()
        With cbSelMeasMode
            .Items.Clear()
            .Items.Add(CDevCS100A.eMeasuringMode._ABS.ToString)
            .Items.Add(CDevCS100A.eMeasuringMode._DIFF.ToString)
            .SelectedIndex = 0
        End With

        With cbSelSpeedMode
            .Items.Clear()
            .Items.Add(CDevCS100A.eSpeedmode._FAST.ToString)
            .Items.Add(CDevCS100A.eSpeedmode._SLOW.ToString)
            .SelectedIndex = 0
        End With

        With cbSelCalibrationMode
            .Items.Clear()
            .Items.Add(CDevCS100A.eCalibrationMode._Preset.ToString)
            .Items.Add(CDevCS100A.eCalibrationMode._Vari.ToString)
            .SelectedIndex = 0
        End With

    End Sub

#End Region

#Region "Functions"

    Private Function GetValueFromUI() As Boolean

        With m_SettingInfos

            .measuringMode = cbSelMeasMode.SelectedIndex
            .speedMode = cbSelSpeedMode.SelectedIndex
            .calibrationMode = cbSelSpeedMode.SelectedIndex

        End With


        Return False
    End Function

    Private Sub SetValueToUI()

        With m_SettingInfos
            cbSelMeasMode.SelectedIndex = .measuringMode
            cbSelSpeedMode.SelectedIndex = .speedMode
            cbSelSpeedMode.SelectedIndex = .calibrationMode
        End With

    End Sub

#End Region

    Private Sub btnConnection_Click(sender As System.Object, e As System.EventArgs) Handles btnConnection.Click
        RaiseEvent evConnection()
    End Sub

    Private Sub btnDisConnection_Click(sender As System.Object, e As System.EventArgs) Handles btnDisConnection.Click
        RaiseEvent evDisconnection()
    End Sub

    Private Sub btnMeasure_Click(sender As System.Object, e As System.EventArgs) Handles btnMeasure.Click
        RaiseEvent evMeasure()
    End Sub

    Private Sub btnSetMeasuringMode_Click(sender As System.Object, e As System.EventArgs) Handles btnSetMeasuringMode.Click
        GetValueFromUI()
        RaiseEvent evSetMeasMode(m_SettingInfos.measuringMode)
    End Sub

    Private Sub btnSetSpeedMode_Click(sender As System.Object, e As System.EventArgs) Handles btnSetSpeedMode.Click
        GetValueFromUI()
        RaiseEvent evSetSpeedMode(m_SettingInfos.speedMode)
    End Sub

    Private Sub btnSetCalibrationMode_Click(sender As System.Object, e As System.EventArgs) Handles btnSetCalibrationMode.Click
        GetValueFromUI()
        RaiseEvent evSetCalibrationMode(m_SettingInfos.calibrationMode)
    End Sub
End Class
