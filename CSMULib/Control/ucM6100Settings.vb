Imports System.Windows.Forms

Public Class ucM6100Settings

#Region "Define"
    Dim m_sSettings As CDevM6100.sM6100Setting
    Dim sCurrentRange As String()
#End Region

#Region "Structure"
    Public Structure sM6100
        Dim SourceMode As eSMUMode
    End Structure
#End Region

#Region "Enum"
    Public Enum eSMUMode
        eCurrent
        eVoltage
        ePulseVoltage
    End Enum
#End Region

#Region "Property"

    Public WriteOnly Property ControlUI As CDevSMUCommonNode.sRangeAndIntegTime
        Set(ByVal value As CDevSMUCommonNode.sRangeAndIntegTime)
            ControlUIInit(value)
        End Set
    End Property

    Public Property Settings As CDevM6100.sM6100Setting
        Get
            GetFormUI()
            Return m_sSettings
        End Get
        Set(ByVal value As CDevM6100.sM6100Setting)
            SetFormUI(value)
            m_sSettings = value
        End Set
    End Property
#End Region


#Region "Functions"
    Public Sub GetFormUI()

        With m_sSettings
            If rbCC.Checked = True Then
                .SourceMode = eSMUMode.eCurrent
            ElseIf rbCV.Checked = True Then
                .SourceMode = eSMUMode.eVoltage
            ElseIf rbPCV.Checked = True Then
                .SourceMode = eSMUMode.ePulseVoltage
            End If

            If cboCurrRange.SelectedIndex = 0 Then
                .CurrentRange = 100
            ElseIf cboCurrRange.SelectedIndex = 1 Then
                .CurrentRange = 10
            ElseIf cboCurrRange.SelectedIndex = 2 Then
                .CurrentRange = 1
            ElseIf cboCurrRange.SelectedIndex = 3 Then
                .CurrentRange = 0.1
            ElseIf cboCurrRange.SelectedIndex = 4 Then
                .CurrentRange = 0.01
            End If
        End With
    End Sub

    Public Sub SetFormUI(ByVal settings As CDevM6100.sM6100Setting)

        With settings
            If .SourceMode = eSMUMode.eCurrent Then
                rbCC.Checked = True
            ElseIf .SourceMode = eSMUMode.eVoltage Then
                rbCV.Checked = True
            ElseIf .SourceMode = eSMUMode.ePulseVoltage Then
                rbPCV.Checked = True
            End If
            If .CurrentRange = 100 Then
                cboCurrRange.SelectedIndex = 0
            ElseIf .CurrentRange = 10 Then
                cboCurrRange.SelectedIndex = 1
            ElseIf .CurrentRange = 1 Then
                cboCurrRange.SelectedIndex = 2
            ElseIf .CurrentRange = 0.1 Then
                cboCurrRange.SelectedIndex = 3
            ElseIf .CurrentRange = 0.01 Then
                cboCurrRange.SelectedIndex = 4
            End If
        End With
    End Sub


    Public Sub ControlUIInit(ByVal setting As CDevSMUCommonNode.sRangeAndIntegTime)
        cboCurrRange.Items.Clear()

        For i As Integer = 0 To setting.dCurrentListValue.Length - 1
            cboCurrRange.Items.Add(setting.sCurrentListName(i))
        Next

        cboCurrRange.SelectedIndex = 0
    End Sub

    Public Sub Init()
        gbM6100.Location = New System.Drawing.Point(0, 0)
        gbM6100.Dock = Windows.Forms.DockStyle.Fill

        cboCurrRange.Items.Clear()
        cboCurrRange.Items.Add("Nothing")
    End Sub
#End Region

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        Init()
    End Sub
End Class
