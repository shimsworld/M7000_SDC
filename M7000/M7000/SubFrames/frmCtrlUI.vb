Public Class frmCtrlUI



#Region "Define"
    Public myParent As frmMain
    Public WithEvents ControlUI As ucDispMultiCtrlUI

    Dim m_MaxCh As Integer
    Dim m_DispType As ucDispCtrlUICommonNode.eType

    Dim m_bSelectedAllCh As Boolean = False
    Dim m_bSelectedSequenceLoadJig As Boolean = False
    Dim m_bSelectedSequenceLoadCh As Boolean = False
#End Region

#Region "Delegate"

    Private Delegate Sub DelCallSub()

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

#End Region

#Region "Creator & Init"

    Public Sub New(ByVal maxCh As Integer, ByVal type As ucDispMultiCtrlCommonNode.eType)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_MaxCh = maxCh
        m_DispType = type
        init()
    End Sub

    Private Sub init()
          ControlUI = New ucDispMultiCtrlUI(m_DispType, m_MaxCh)
        ControlUI.Visible = False

        Me.Controls.Add(ControlUI)
        ControlUI.Location = New System.Drawing.Point(0, 0)
        ControlUI.Dock = DockStyle.Fill

        UcDispStateMsg1.Dock = DockStyle.Bottom

    End Sub




#End Region

    Public Property SelectedSequenceLoadJig(ByVal nJig As Integer) As Boolean
        Get
            Return m_bSelectedSequenceLoadJig
        End Get
        Set(ByVal value As Boolean)
            m_bSelectedSequenceLoadJig = value
            If m_bSelectedSequenceLoadJig = True Then
                ControlUI.control.dispJIG(nJig).IsSelected = True
            Else
                '  For i As Integer = 0 To g_ConfigInfos.numOfJIG - 1
                ControlUI.control.dispJIG(nJig).IsSelected = False
                '  Next
            End If
        End Set
    End Property

    Public Property SelectedSequenceLoadCh(ByVal nCh As Integer) As Boolean
        Get
            Return m_bSelectedSequenceLoadCh
        End Get
        Set(ByVal value As Boolean)
            Dim nJig As Integer
            m_bSelectedSequenceLoadCh = value
            nJig = frmSettingWind.GetAllocationValue(nCh, frmSettingWind.eChAllocationItem.eJIG_No)

            If m_bSelectedSequenceLoadCh = True Then
                ControlUI.control.dispJIG(nJig).ChannelNo = nCh
                ControlUI.control.dispJIG(nJig).IsSelectedChannel = True
            Else
                '  For i As Integer = 0 To g_ConfigInfos.numOfJIG - 1
                ControlUI.control.dispJIG(nJig).ChannelNo = nCh
                ControlUI.control.dispJIG(nJig).IsSelectedChannel = False
                '  Next
            End If
        End Set
    End Property

    Public Property SelectedAllCh As Boolean
        Get
            Return m_bSelectedAllCh
        End Get
        Set(ByVal value As Boolean)
            m_bSelectedAllCh = value
            If m_bSelectedAllCh = True Then
                For i As Integer = 0 To g_ConfigInfos.numOfJIG - 1
                    ControlUI.control.dispJIG(i).IsSelected = True
                Next
            Else
                For i As Integer = 0 To g_ConfigInfos.numOfJIG - 1
                    ControlUI.control.dispJIG(i).IsSelected = False
                Next
            End If
        End Set
    End Property

    Private Sub ControlUI_evClickTempIndicator(ByVal nJIGNo As Integer) Handles ControlUI.evClickTempIndicator

        '모니터링용도로만 쓰기때문에 제외함 'yjs
        Dim dlg As New frmTempWind

        Dim nChNo() As Integer = frmSettingWind.CheckCombinedChannelAsJIG(nJIGNo)

        For i As Integer = 0 To nChNo.Length - 1
            If myParent.cTimeScheduler.g_ChSchedulerStatus(nChNo(i)) <> CScheduler.eChSchedulerSTATE.eIdle Then
                MsgBox("Sequence is running. Please use it after ending the currently set sequence.")
                Exit Sub
            End If
        Next

        If nChNo.Length <= 0 Then Exit Sub

        Dim nDevGroup As Integer = frmSettingWind.GetAllocationValue(nChNo(0), frmSettingWind.eChAllocationItem.eGroupOfTC)
        Dim nDevID As Integer = frmSettingWind.GetAllocationValue(nChNo(0), frmSettingWind.eChAllocationItem.eDevNoOfTC)
        Dim nCh As Integer = frmSettingWind.GetAllocationValue(nChNo(0), frmSettingWind.eChAllocationItem.eChOfTC)

        dlg.StartPosition = FormStartPosition.CenterParent

        myParent.cTC(nDevGroup).GetSetTemp(nDevID, dlg.tbTemp.Text)

        If dlg.ShowDialog() = DialogResult.OK Then
            myParent.cTC(nDevGroup).SetTemp(nDevID, nCh, dlg.Temp)
        End If

    End Sub

    Private Sub frmCtrlUI_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ControlUI.Visible = True
    End Sub


End Class