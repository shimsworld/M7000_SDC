Imports System


Public Class ucHEXA50
#Region "Defines"
    Dim m_SettingInfos As CDevHEXA50.sSettings

    Dim sMeasureMode() As String = New String() {"Command", "Continous"}
    Dim sIntegrationTime() As String = New String() {"32ms", "64ms", "128ms", "256ms", "512ms", "1024ms"}
    Public sIntegrationTimeValue() As Double = New Double() {1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024}
    Dim sReferenceCurrent() As String = New String() {"20(Amp5)", "80(Amp4)", "320(Amp3)", "1280(Amp2)", "5120(Amp1)"}
    Dim sDivider() As String = New String() {"1", "2", "4", "8", "16"}
    Dim sOffset() As String = New String() {"0", "15", "31", "63"}
    Dim sRange() As String = New String() {"Auto", "1", "2", "3", "4", "5"}
    Public HEXARANGE As Integer
    Public HEXAMODE As CDevHEXA50.eMeasMode

    Public Event evConnection()
    Public Event evDisconnection()

    Public Event evMeasure()

    Public Event evSetMeasMode(ByVal mode As CDevHEXA50.eMode)
    Public Event evSetIntegTime(ByVal mode As CDevHEXA50.eIntegTime)
    Public Event evSetRefCurrent(ByVal mode As CDevHEXA50.eRefCurrent)
    Public Event evSetDivider(ByVal mode As CDevHEXA50.eDivider)
    Public Event evSetOffset(ByVal mode As CDevHEXA50.eOffset)
    Public Event evSetRange(ByVal mode As Integer)

#End Region

#Region "Properties"

    Public Property Settings As CDevHEXA50.sSettings
        Get
            GetValueFromUI()
            Return m_SettingInfos
        End Get
        Set(value As CDevHEXA50.sSettings)
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
            For i As Integer = 0 To sMeasureMode.Length - 1
                .Items.Add(sMeasureMode(i))
            Next
            .SelectedIndex = 0
        End With

        With ComboBox1
            .Items.Clear()
            For i As Integer = 0 To sIntegrationTime.Length - 1
                .Items.Add(sIntegrationTime(i))
            Next
            .SelectedIndex = 5
        End With

        With cbSelIntegTime
            .Items.Clear()
            For i As Integer = 0 To sIntegrationTime.Length - 1
                .Items.Add(sIntegrationTime(i))
            Next
            .SelectedIndex = 5
        End With
        With cbSelRefCurrent
            .Items.Clear()
            For i As Integer = 0 To sReferenceCurrent.Length - 1
                .Items.Add(sReferenceCurrent(i))
            Next
            .SelectedIndex = 3
        End With
        With cbSelDivider
            .Items.Clear()
            For i As Integer = 0 To sDivider.Length - 1
                .Items.Add(sDivider(i))
            Next
            .SelectedIndex = 0
        End With
        With cbSelOffset
            .Items.Clear()
            For i As Integer = 0 To sOffset.Length - 1
                .Items.Add(sOffset(i))
            Next
            .SelectedIndex = 0
        End With

        With cbSelRange
            .Items.Clear()
            For i As Integer = 0 To sRange.Length - 1
                .Items.Add(sRange(i))
            Next
            .SelectedIndex = 0
        End With

    End Sub

#End Region

#Region "Functions"

    Private Function GetValueFromUI() As Boolean

        ReDim Preserve m_SettingInfos.SettingInfo(7)
        With m_SettingInfos

            .SettingInfo(m_SettingInfos.RangeIndex).Mode = cbSelMeasMode.SelectedIndex
            .SettingInfo(m_SettingInfos.RangeIndex).IntegTime = cbSelIntegTime.SelectedIndex
            .SettingInfo(m_SettingInfos.RangeIndex).ReferenceCurrent = cbSelRefCurrent.SelectedIndex
            .SettingInfo(m_SettingInfos.RangeIndex).Divider = cbSelDivider.SelectedIndex
            .SettingInfo(m_SettingInfos.RangeIndex).Offset = cbSelOffset.SelectedIndex
            .SettingInfo(m_SettingInfos.RangeIndex).IntegTimeVal = sIntegrationTimeValue(cbSelIntegTime.SelectedIndex)
            .Range = cbSelRange.SelectedIndex
            If .Range = CDevHEXA50.eRange.eAuto Then
                .RangeIndex = 0
            Else
                .RangeIndex = cbSelRange.SelectedIndex - 1
            End If

            If RadioButton1.Checked = True Then
                HEXAMODE = CDevHEXA50.eMeasMode.eAuto
            Else
                HEXAMODE = CDevHEXA50.eMeasMode.eManual
            End If

            HEXARANGE = ComboBox1.SelectedIndex
        End With


        Return False
    End Function

    Private Sub SetValueToUI()

        With m_SettingInfos
            cbSelMeasMode.SelectedIndex = .SettingInfo(m_SettingInfos.RangeIndex).Mode
            cbSelIntegTime.SelectedIndex = .SettingInfo(m_SettingInfos.RangeIndex).IntegTime
            cbSelRefCurrent.SelectedIndex = .SettingInfo(m_SettingInfos.RangeIndex).ReferenceCurrent
            cbSelDivider.SelectedIndex = .SettingInfo(m_SettingInfos.RangeIndex).Divider
            cbSelOffset.SelectedIndex = .SettingInfo(m_SettingInfos.RangeIndex).Offset
            cbSelRange.SelectedIndex = .Range
        End With

        If HEXAMODE = CDevHEXA50.eMeasMode.eAuto Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If

        ComboBox1.SelectedIndex = HEXARANGE
    End Sub
#End Region



    Private Sub btnConnection_Click(sender As System.Object, e As System.EventArgs) Handles btnConnection.Click
        RaiseEvent evConnection()
    End Sub

    Private Sub btnDisConnection_Click(sender As System.Object, e As System.EventArgs) Handles btnDisConnection.Click
        RaiseEvent evDisconnection()
    End Sub

    Private Sub btnMeasure_Click(sender As System.Object, e As System.EventArgs) Handles btnMeasure.Click
        GetValueFromUI()

        RaiseEvent evMeasure()
    End Sub

    Private Sub btnSetMeasuringMode_Click(sender As System.Object, e As System.EventArgs) Handles btnSetMeasuringMode.Click
        GetValueFromUI()
        RaiseEvent evSetMeasMode(m_SettingInfos.SettingInfo(m_SettingInfos.Range).Mode)
    End Sub

    Private Sub btnSetIntegTime_Click(sender As System.Object, e As System.EventArgs) Handles btnSetIntegTime.Click
        GetValueFromUI()
        RaiseEvent evSetIntegTime(m_SettingInfos.SettingInfo(m_SettingInfos.Range).IntegTime)
    End Sub

    Private Sub btnSetRefCurrent_Click(sender As System.Object, e As System.EventArgs) Handles btnSetRefCurrent.Click
        GetValueFromUI()
        RaiseEvent evSetRefCurrent(m_SettingInfos.SettingInfo(m_SettingInfos.Range).ReferenceCurrent)
    End Sub

    Private Sub btnSetDivider_Click(sender As System.Object, e As System.EventArgs) Handles btnSetDivider.Click
        GetValueFromUI()
        RaiseEvent evSetDivider(m_SettingInfos.SettingInfo(m_SettingInfos.Range).Divider)
    End Sub

    Private Sub btnSetOffset_Click(sender As System.Object, e As System.EventArgs) Handles btnSetOffset.Click
        GetValueFromUI()
        RaiseEvent evSetOffset(m_SettingInfos.SettingInfo(m_SettingInfos.Range).Offset)
    End Sub

    Private Sub btnSetRange_Click(sender As System.Object, e As System.EventArgs) Handles btnSetRange.Click
        GetValueFromUI()
        RaiseEvent evSetRange(m_SettingInfos.Range)
    End Sub

    Private Sub cbSelRange_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbSelRange.SelectedIndexChanged
        If cbSelRange.SelectedIndex = 0 Then
            m_SettingInfos.Range = CDevHEXA50.eRange.eAuto
            m_SettingInfos.RangeIndex = 0
        ElseIf cbSelRange.SelectedIndex = 1 Then
            m_SettingInfos.RangeIndex = 0
            m_SettingInfos.Range = CDevHEXA50.eRange.e1
        ElseIf cbSelRange.SelectedIndex = 2 Then
            m_SettingInfos.RangeIndex = 1
            m_SettingInfos.Range = CDevHEXA50.eRange.e2
        ElseIf cbSelRange.SelectedIndex = 3 Then
            m_SettingInfos.RangeIndex = 2
            m_SettingInfos.Range = CDevHEXA50.eRange.e3
        ElseIf cbSelRange.SelectedIndex = 4 Then
            m_SettingInfos.RangeIndex = 3
            m_SettingInfos.Range = CDevHEXA50.eRange.e4
        ElseIf cbSelRange.SelectedIndex = 5 Then
            m_SettingInfos.RangeIndex = 4
            m_SettingInfos.Range = CDevHEXA50.eRange.e5
        End If
    End Sub
End Class
