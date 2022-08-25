Public Class ucDispMultiCtrlUI

    Dim m_nMaxCh As Integer
    Dim m_seedIndex As Integer = 0


    Public Event evClickTempIndicator(ByVal nJIGNo As Integer)

    Public WithEvents control As ucDispMultiCtrlCommonNode

    Public Sub New(ByVal type As ucDispMultiCtrlCommonNode.eType, ByVal maxCh As Integer)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init(type, maxCh)
    End Sub


    Private Sub init(ByVal type As ucDispMultiCtrlCommonNode.eType, ByVal maxCh As Integer)

        m_nMaxCh = maxCh
        Select Case type

            Case ucDispMultiCtrlCommonNode.eType.ListType
                control = New ucDispMultiCtrlOfListType(maxCh, 0)
            Case ucDispMultiCtrlCommonNode.eType.ListTypeForQC
                control = New ucDispMultiCtrlOfListTypeForQC(maxCh, 0)
            Case ucDispMultiCtrlCommonNode.eType.CustomTypeForQC
                control = New ucDispMultiCtrlOfCustomTypeForQC(maxCh, 0)
            Case ucDispMultiCtrlCommonNode.eType.JIGLayout
                control = New ucDispMultiCtrlOfJIGLayout(maxCh, 0, g_SystemSettings.JIGLayoutInfos)
        End Select
        Control_init()
    End Sub

#Region "Initialization List Type Control for QC"

    Private Sub Control_init()
        Me.Controls.Add(control)
        control.Location = New System.Drawing.Point(0, 0)
        control.Dock = DockStyle.Fill
    End Sub

#End Region

    Private Sub control_evClickTempIndicator(ByVal nJIGNo As Integer) Handles control.evClickTempIndicator
        RaiseEvent evClickTempIndicator(nJIGNo)
    End Sub

End Class
