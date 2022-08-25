Imports System.Threading

Public Class ucDispStateMsg

#Region "Define"

    'Dim m_State As sStateMessage

    'Public Structure sStateMessage
    '    Dim nCh As Integer
    '    Dim eState As CV7000ACFState.eACFState
    '    Dim dParam1 As Double
    'End Structure

#End Region



#Region "Control Event Functions"

    Private Sub ucV7000StateMsg_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged

    End Sub

    Private Sub gbMain_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbMain.SizeChanged
        FitControlSizeAndLocation()
        initListACFInfo()
    End Sub


    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearList()
    End Sub

    Private Sub btnClear_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnClear.MouseMove
        btnClear.BackColor = Color.Yellow
        btnClear.ForeColor = Color.Black
    End Sub

    Private Sub btnClear_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.MouseLeave
        btnClear.BackColor = Color.DimGray
        btnClear.ForeColor = Color.White
    End Sub

#End Region


#Region "Property"


    'Public WriteOnly Property SetStateMessage() As sStateMessage
    '    Set(ByVal Value As sStateMessage)
    '        m_State = Value
    '        StateParser(m_State)
    '    End Set
    'End Property

#End Region


#Region "Functions"

    Public Sub init()

        gbMain.Dock = DockStyle.Fill
        ' Timer1.Enabled = True

    End Sub

    Private Sub FitControlSizeAndLocation()

        Dim colRatio() As Double = New Double() {90, 10}
        '   Dim sizeBuf As System.Drawing.Size
        Dim sizeBufX As Double
        Dim sizeBufY As Double

        Dim sizeMainFrameX As Double
        Dim sizeMainFrameY As Double
        Dim margineX As Integer = 8
        Dim margineY As Integer = 24

        sizeMainFrameX = gbMain.Size.Width
        sizeMainFrameY = gbMain.Size.Height


        sizeBufX = (sizeMainFrameX - margineX) / 100
        sizeBufY = (sizeMainFrameY - margineY) / 100

        listStateMessage.Size = New System.Drawing.Size(sizeBufX * colRatio(0), sizeBufY * 100)
        listStateMessage.Location = New System.Drawing.Point(margineX / 2, 16)

        pnControl.Size = New System.Drawing.Size(sizeBufX * colRatio(1), sizeBufY * 100)
        pnControl.Location = New System.Drawing.Point((margineX / 2) + listStateMessage.Size.Width + 2, 16)

    End Sub


    'Private Sub StateParser(ByVal info As sStateMessage)


    '    Dim strStateMsg As String
    '    Dim nCh As Integer

    '    nCh = info.nCh + 1

    '    Select Case info.eState

    '        Case CV7000ACFState.eACFState.eReady

    '        Case CV7000ACFState.eACFState.eCompleted_AC

    '        Case CV7000ACFState.eACFState.eCompleted_AF

    '        Case CV7000ACFState.eACFState.eRunningAC

    '        Case CV7000ACFState.eACFState.eRunningAF

    '        Case CV7000ACFState.eACFState.eAF_Fail_LowIntensity
    '            strStateMsg = "[State : Auto Focusing][Message : 셀의 밝기가 어둡거나 켜지지 않았습니다.]"
    '        Case CV7000ACFState.eACFState.eAF_Fail_NotDetectedCellBlob
    '            strStateMsg = "[State : Auto Focusing][Message : 셀의 밝기가 너무 어두워 데이터 처리를 할 수 없습니다.]"
    '        Case CV7000ACFState.eACFState.eAC_Fail_LowIntensity
    '            strStateMsg = "[State : Auto Centering][Message : 셀의 밝기가 너무 어둡거나 켜지지 않았습니다.]"
    '        Case CV7000ACFState.eACFState.eAC_Fail_NotDetectedCellBlob
    '            strStateMsg = "[State : Auto Centering][Message : 셀의 밝기가 너무 어두어 데이터 처리를 할 수 없습니다.]"
    '        Case CV7000ACFState.eACFState.eCell_Intensity_Adjust
    '            strStateMsg = "[State : Cell Intensity adjust][Message : Increase the cell bias = " & CDbl(m_State.dParam1) & " ]"
    '        Case CV7000ACFState.eACFState.eFail_Cell_Intensity_Adjust_Check_Cell
    '            strStateMsg = "[State : Cell Intensity adjust][Message : 셀의 상태를 확인하여 주십시오. ]"
    '        Case CV7000ACFState.eACFState.eCompleted_Cell_Intensity_Adjust
    '            strStateMsg = "[State : Cell Intensity adjust][Message : 셀 밝기 조정 완료 ]"
    '        Case CV7000ACFState.eACFState.eFail_ACF_Bias_Setting
    '            strStateMsg = "[State : Cell Intensity adjust][Message : Failed Cell Bias Setting ]"
    '    End Select
    '    SetListACFInfo(nCh, strStateMsg)
    'End Sub


#End Region


#Region "ListView Control Fucntion"
    Private Sub initListACFInfo()

        Dim sizeX As Double
        Dim colRatio() As Double = New Double() {20, 15, 65}

        With listStateMessage
            sizeX = (.Size.Width - 10) / 100
            .View = View.Details
            .AllowColumnReorder = True
            .GridLines = True
            .Columns.Clear()
            .Columns.Add("Date", CInt(sizeX * colRatio(0)), HorizontalAlignment.Center)
            .Columns.Add("Channel", CInt(sizeX * colRatio(1)), HorizontalAlignment.Left)
            .Columns.Add("Message", CInt(sizeX * colRatio(2)), HorizontalAlignment.Left)

        End With
    End Sub

    Public Sub ClearList()
        listStateMessage.Items.Clear()
    End Sub

    Public Sub SetList(ByVal nCh As Integer, ByVal strMsg As String)

        Dim cYear As String = Format(Now, "yyyy")
        Dim cMonth As String = Format(Now, "MM")
        Dim cDay As String = Format(Now, "dd")

        Dim cHour As String = Format(Now, "HH")
        Dim cMin As String = Format(Now, "mm")
        Dim cSec As String = Format(Now, "ss")

        Dim sDate As String = cYear & cMonth & cDay & "_" & cHour & cMin & cSec

        Try
            Dim item As New ListViewItem(sDate)  'NO
            item.SubItems.Add(CStr(nCh))   'Yw
            item.SubItems.Add(strMsg)   'Yw
            '   listStateMessage.Items.AddRange(New ListViewItem() {item})
            listStateMessage.Items.AddRange(New ListViewItem() {item})

            If listStateMessage.Items.Count > 1 Then
                Dim lastItem As ListViewItem = listStateMessage.Items(listStateMessage.Items.Count - 1)
                listStateMessage.Items(listStateMessage.Items.Count - 1).Remove()
                listStateMessage.Items.Insert(0, lastItem)
                listStateMessage.Items(0).BackColor = Color.LightSeaGreen
            End If

            If listStateMessage.Items.Count >= 1 Then

                Application.DoEvents()
                Thread.Sleep(500)
                listStateMessage.Items(0).BackColor = Color.White
            End If


        Catch ex As Exception
            Debug.WriteLine("Try Catch Error : Set data to ListGamma")
        End Try
    End Sub



#End Region



    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    '    If listStateMessage.Items.Count >= 1 Then
    '        listStateMessage.Items(0).BackColor = Color.White
    '    End If

    'End Sub

    Private Sub ucV7000StateMsg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        init()
        btnClear.BackColor = Color.DimGray
        btnClear.ForeColor = Color.White
        btnClear.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    End Sub



End Class
