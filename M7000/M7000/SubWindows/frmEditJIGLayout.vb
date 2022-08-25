Imports System
Imports System.IO
Imports MoveGraphLibrary
Imports System.Convert
Imports RectangleGeneral

Public Class frmEditJIGLayout

#Region "Define"

    Private m_numOfJIG As Integer
    Private m_JIGInfo() As frmSettingWind.sJIGLayoutInfo

    Private mover() As Mover

    Private RectJIG() As RectangleGeneral.RectangleGeneral
    Private swapPos As Rectangle
    Private fixedSwapPos As Boolean = False

    Private title() As TextMR
    Private txtRectJIGPos() As TextMR
    Private txtRectJIGSize() As TextMR

    Private bShowCovers() As Boolean

    Private RectJIGColors() As Color '= New Color() {Color.LightBlue, Color.Cyan, Color.Yellow, Color.LightGreen}

    Private sizefStrs As SizeF()
    Private radius As Integer, halfstrip As Integer
    Private strs As String() = New String() {"Circles' radius", "Half strip width"}
    Private bAfterInit As Boolean = False

    Dim CurrentClientSize As Size
    Dim BeforClientSize As Size

    Public windowPriority As CWindowInfo

    Private nTopMostWindowIndex As Integer = 0

    Dim BoxCheck As Boolean = False '지그 이동 확인용도

#End Region



#Region "Property"

    Public ReadOnly Property JIGLocation As Point()
        Get
            Dim location(RectJIG.Length - 1) As Point

            For i As Integer = 0 To RectJIG.Length - 1
                location(i) = New System.Drawing.Point(RectJIG(i).Rectangle.X, RectJIG(i).Rectangle.Y)
            Next
            Return location.Clone
        End Get
    End Property

    Public ReadOnly Property JIGSize As Size()
        Get
            Dim sizeInfos(RectJIG.Length - 1) As Size
            For i As Integer = 0 To RectJIG.Length - 1
                sizeInfos(i) = New System.Drawing.Size(RectJIG(i).Rectangle.Width, RectJIG(i).Rectangle.Height)
                'sizeInfos(i).Height = RectJIG(i).Rectangle.Height
            Next
            Return sizeInfos.Clone
        End Get
    End Property

#End Region


    Public Sub New(ByVal JIGInfo() As frmSettingWind.sJIGLayoutInfo)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_numOfJIG = JIGInfo.Length
        m_JIGInfo = JIGInfo.Clone
        init()
    End Sub

    Private Sub init()
        ReDim mover(m_numOfJIG - 1)
        ReDim RectJIG(m_numOfJIG - 1)
        ReDim title(m_numOfJIG - 1)
        ReDim bShowCovers(m_numOfJIG - 1) ' As Boolean

        ReDim txtRectJIGPos(m_numOfJIG - 1)
        ReDim txtRectJIGSize(m_numOfJIG - 1)

        ReDim RectJIGColors(m_numOfJIG - 1)

        '  ReDim bRefreshFlag(numWindow - 1)

        For i As Integer = 0 To m_numOfJIG - 1
            mover(i) = New Mover

            RectJIGColors(i) = m_JIGInfo(i).JIGBackgroundColor
            '     bRefreshFlag(i) = true
        Next
        'Font = new Font ("Times New Roman", 14);

        sizefStrs = Auxi_Geometry.MeasureStrings(Me, strs)
        ' Prepare_lrsView()

        '  ccChange = New CommentedControlLTP(Me, comboChang, Side.E, StringAlignment.Center, 4, "Changeable resizing")
        radius = 1
        halfstrip = 1

        'DefineRectangles()
        ''  comboChangeResizing.SelectedIndex = Convert.ToInt32(rg_Change.Resizing)
        'RenewMover()
        bAfterInit = True
    End Sub

    Private Sub frmEditJIGLayout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DefineRectangles()
        RenewMover()

        CurrentClientSize = Me.ClientSize

        tstbClientSizeWidth.Text = Width
        tstbClientSizeHeight.Text = Height

        ' lblCanvasEnd.Location = New System.Drawing.Point(Width - lblCanvasEnd.Size.Width, Height - lblCanvasEnd.Size.Height)
    End Sub


    ' -------------------------------------------------        DefineRectangles
    Private Sub DefineRectangles()
        CurrentClientSize = Me.ClientSize
        Dim nW As Integer = CurrentClientSize.Width
        Dim nH As Integer = CurrentClientSize.Height

        '  Dim windSizeW As Integer = nW \ numOfWindowCol
        'Dim windSizeH As Integer = nH \ numOfWindowRaw
        Dim RectRangeWMin As Integer = 10
        Dim RectRangeWMax As Integer = 500
        Dim RectRangeHMin As Integer = 10
        Dim RectRangeHMax As Integer = 500

        Dim strTemp As String
        Dim rectSize(m_numOfJIG - 1) As Size
        Dim rectPoint(m_numOfJIG - 1) As Point

        Dim rr As New RectRange(RectRangeWMin, RectRangeWMax, RectRangeHMin, RectRangeHMax)
        Dim txtPos As Rectangle
        ' Dim nCnt As Integer = 0
        '  Dim sTemp As String


        'For nRaw As Integer = 0 To numOfWindowRaw - 1
        '    For nCol As Integer = 0 To numOfWindowCol - 1
        '        rect(nCnt).panel_H = windSizeH - margineH
        '        rect(nCnt).panel_W = windSizeW - margineW

        '        rect(nCnt).panel_X = (nCol * windSizeW) + margineX
        '        rect(nCnt).panel_Y = (nRaw * windSizeH) + margineY

        '        nCnt += 1
        '    Next
        'Next



        windowPriority = New CWindowInfo(m_numOfJIG)

        For i As Integer = 0 To m_numOfJIG - 1
            RectJIG(i) = New RectangleGeneral.RectangleGeneral(New Rectangle(m_JIGInfo(i).JIGLocation.X, m_JIGInfo(i).JIGLocation.Y, m_JIGInfo(i).JIGSize.Width, m_JIGInfo(i).JIGSize.Height), rr, radius, halfstrip, RectJIGColors(i))

            txtPos = RectJIG(i).Rectangle



            strTemp = "JIG" & CStr(m_JIGInfo(i).JIGNo)
            title(i) = New TextMR(Me, New Point(txtPos.X + (txtPos.Width \ 2), txtPos.Y + (txtPos.Height \ 2)), strTemp, New Font("Times New Roman", 12, FontStyle.Bold), Color.Black)
            txtRectJIGPos(i) = New TextMR(Me, New Point(txtPos.X + 60, txtPos.Y + 10), "X : 0000, Y : 0000", New Font("Times New Roman", 10, FontStyle.Regular), Color.Black)
            txtRectJIGSize(i) = New TextMR(Me, New Point(txtPos.X + txtPos.Width - 60, txtPos.Y + txtPos.Height - 10), "W : 0000, H : 0000", New Font("Times New Roman", 10, FontStyle.Regular), Color.Black)
            'txtInHwType(i) = New TextMR(Me, New Point(txtPos.X + txtPos.Width - 40, txtPos.Y + 10), m_InHwType(i).ToString, New Font("Times New Roman", 10, FontStyle.Regular), Color.Black)

            '좌표 숫자 표시 - 서경축
            txtRectJIGPos(i).Text = "X : " & Format(txtPos.X, "000") & ", Y : " & Format(txtPos.Y, "000")
            txtRectJIGSize(i).Text = "W : " & Format(txtPos.Width, "000") & ", H : " & Format(txtPos.Height, "000")








            'If m_InResolution(i).Res_H = 0 And m_InResolution(i).Res_W = 0 Then
            '    sTemp = "No Signal"
            'Else
            '    sTemp = CStr(m_InResolution(i).Res_W) & " X " & CStr(m_InResolution(i).Res_H)
            'End If
            ''sTemp = CStr(m_InResolution(i).Res_W) & " X " & CStr(m_InResolution(i).Res_H)
            'txtInRes(i) = New TextMR(Me, New Point(txtPos.X + 50, txtPos.Y + txtPos.Height - 10), sTemp, New Font("Times New Roman", 10, FontStyle.Regular), Color.Black)

            'calculationOutRectInfo(i)
        Next

    End Sub
    ' -------------------------------------------------        RenewMover
    Private Sub RenewMover()

        For i As Integer = 0 To m_numOfJIG - 1
            mover(i).Clear()
            mover(i).Add(RectJIG(i))
            mover(i).Add(title(i))
            mover(i).Add(txtRectJIGPos(i))
            mover(i).Add(txtRectJIGSize(i))
            'mover(i).Add(txtInHwType(i))
            'mover(i).Add(txtInRes(i))
        Next

    End Sub

    ' -------------------------------------------------        OnMouseDown
    Dim mosue As System.Windows.Forms.MouseButtons
    Private Sub frmScreenLayout_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        '  Dim pos As Point


        Dim nCountSelectWindow As Integer = 0

        mosue = e.Button

        For i As Integer = 0 To m_numOfJIG - 1

            bShowCovers(i) = False
            ' bRefreshFlag(i) = False
            If mover(i).Catch(e.Location, e.Button) Then
                '    bShowCovers(i) = True
                '    nCountSelectWindow += 1
                'Else
                '    bShowCovers(i) = False
            End If
        Next

        CheckOverlab(e.Location, bShowCovers, nCountSelectWindow)

        '지그 체크 확인 - 서경축
        For a As Integer = 0 To m_JIGInfo.Length - 1
            If bShowCovers(a) = True Then
                BoxCheck = True
                Exit For
            Else
                If a = m_JIGInfo.Length - 1 Then
                    BoxCheck = False
                End If
            End If
        Next

        'Dim stemp As String
        'For i As Integer = 0 To numWindow - 1
        '    stemp = stemp & "," & bShowCovers(i).ToString
        'Next
        'Me.Text = stemp

        If nCountSelectWindow = 0 Then 'Screen이 선택 됫을음 나타냄

            '   RaiseEvent evSelectScreen()
        ElseIf nCountSelectWindow = 1 Then '1개의 윈도우만 선택됨
            For i As Integer = 0 To m_numOfJIG - 1
                If bShowCovers(i) = True Then nTopMostWindowIndex = i
            Next

            windowPriority.SetPriority(nTopMostWindowIndex, 0)
            '  bRefreshFlag = bShowCovers
            '  RaiseEvent evSelectWindow(nTopMostWindowIndex)
            '  ElseIf nCountSelectWindow = 2 Then

            'If window(nTopMostWindowIndex).MouseSelPos = 0 Then

            'End If

        Else '여러개의 윈도우가 선택됨

            'If nCountSelectWindow = 2 Then

            'Else
            nTopMostWindowIndex = windowPriority.GetTopWindowIndexOfSelectedWindows(bShowCovers)


            'For i As Integer = 0 To numWindow - 1

            '    If bShowCovers(i) = True Then

            '        For p As Integer = 0 To numWindow - 1
            '            If windowPriority.Priority(p) = i Then


            '                nTopMostWindowIndex = i
            '            End If
            '        Next

            '    End If

            '    ' bRefreshFlag(nTopMostWindowIndex) = False
            'Next5
            bShowCovers(nTopMostWindowIndex) = True

            windowPriority.SetPriority(nTopMostWindowIndex, 0)
            'bRefreshFlag(nTopMostWindowIndex) = True
            '    RaiseEvent evSelectWindow(nTopMostWindowIndex)

            '  End If

        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then

            If fixedSwapPos = False Then
                fixedSwapPos = True
                swapPos = RectJIG(nTopMostWindowIndex).Rectangle

            End If
            Me.Text = "Select Window = " & CStr(nTopMostWindowIndex + 1) & "/ X = " & CStr(swapPos.X) & " Y = " & CStr(swapPos.Y) & " H = " & CStr(swapPos.Height) & " W = " & CStr(swapPos.Width)
        End If

        'Me.Text = " /number of select window = " & CStr(nCountSelectWindow) & _
        '       " /Show Covers = " & CStr(bShowCovers(0)) & "," & CStr(bShowCovers(1)) & "," & CStr(bShowCovers(2)) & "," & CStr(bShowCovers(3))

        Invalidate()
    End Sub

    Private Sub CheckOverlab(ByVal nPt As System.Drawing.Point, ByRef selWindow() As Boolean, ByRef cntSelWind As Integer)
        Dim rect As Rectangle
        Dim wind(m_numOfJIG - 1) As Boolean
        Dim selCount As Integer = 0
        Dim margine As Integer = 2
        For i As Integer = 0 To m_numOfJIG - 1
            rect = RectJIG(i).Rectangle

            If nPt.X > rect.X - margine And nPt.X < rect.X + rect.Width + margine And nPt.Y > rect.Y - margine And nPt.Y < rect.Y + rect.Height + margine Then
                wind(i) = True
                selCount += 1

            Else
                wind(i) = False

            End If
        Next
        selWindow = wind.Clone
        cntSelWind = selCount
    End Sub

    Private Sub frmScreenLayout_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp


        'Dim bufWindow As RectangleGeneral.RectangleGeneral
        Dim cnt As Integer
        Dim topIdx As Integer = nTopMostWindowIndex
        mosue = e.Button
        CheckOverlab(e.Location, bShowCovers, cnt)



        'Dim stemp As String
        'For i As Integer = 0 To numWindow - 1
        '    stemp = stemp & "," & bShowCovers(i).ToString
        'Next
        'Me.Text = stemp

        For i As Integer = 0 To m_numOfJIG - 1
            mover(i).Release()
        Next

        If e.Button = Windows.Forms.MouseButtons.Right Then

            If cnt = 2 Then
                Dim swapCh(1) As Integer
                Dim swapCnt As Integer
                'Dim rect1 As CDevMSV.sRect_TABLE
                'Dim rect2 As CDevMSV.sRect_TABLE
                Dim bufRect As Rectangle

                For i As Integer = 0 To m_numOfJIG - 1
                    If bShowCovers(i) = True Then
                        swapCh(swapCnt) = i : swapCnt += 1
                    End If
                Next

                For i As Integer = 0 To 1
                    If swapCh(i) = topIdx Then
                        '  window(i).Rectangle = New System.Drawing.Rectangle(swapPos.Location, swapPos.Size)
                        RectJIG(topIdx).Location(swapPos.X, swapPos.Y)
                        RectJIG(topIdx).Size(swapPos.Width, swapPos.Height)
                    End If
                Next



                bufRect = RectJIG(swapCh(0)).Rectangle

                RectJIG(swapCh(0)).Location(RectJIG(swapCh(1)).Rectangle.X, RectJIG(swapCh(1)).Rectangle.Y)
                RectJIG(swapCh(0)).Size(RectJIG(swapCh(1)).Rectangle.Width, RectJIG(swapCh(1)).Rectangle.Height)
                ' rect = window(swapCh(0)).Rectangle
                title(swapCh(0)).Location = New System.Drawing.Point(RectJIG(swapCh(0)).Rectangle.X + (RectJIG(swapCh(0)).Rectangle.Width \ 2), RectJIG(swapCh(0)).Rectangle.Y + (RectJIG(swapCh(0)).Rectangle.Height \ 2))
                txtRectJIGPos(swapCh(0)).Location = New System.Drawing.Point(RectJIG(swapCh(0)).Rectangle.X + 60, RectJIG(swapCh(0)).Rectangle.Y + 10)
                txtRectJIGSize(swapCh(0)).Location = New System.Drawing.Point(RectJIG(swapCh(0)).Rectangle.X + RectJIG(swapCh(0)).Rectangle.Width - 60, RectJIG(swapCh(0)).Rectangle.Y + RectJIG(swapCh(0)).Rectangle.Height - 10)
                'txtInHwType(swapCh(0)).Location = New System.Drawing.Point(window(swapCh(0)).Rectangle.X + window(swapCh(0)).Rectangle.Width - 40, window(swapCh(0)).Rectangle.Y + 10)
                'txtInRes(swapCh(0)).Location = New System.Drawing.Point(window(swapCh(0)).Rectangle.X + 50, window(swapCh(0)).Rectangle.Y + window(swapCh(0)).Rectangle.Height - 10)

                RectJIG(swapCh(1)).Location(bufRect.X, bufRect.Y)
                RectJIG(swapCh(1)).Size(bufRect.Width, bufRect.Height)
                '   window(swapCh(1)).Rectangle = bufRect
                title(swapCh(1)).Location = New System.Drawing.Point(RectJIG(swapCh(1)).Rectangle.X + (RectJIG(swapCh(1)).Rectangle.Width \ 2), RectJIG(swapCh(1)).Rectangle.Y + (RectJIG(swapCh(1)).Rectangle.Height \ 2))
                txtRectJIGPos(swapCh(1)).Location = New System.Drawing.Point(RectJIG(swapCh(1)).Rectangle.X + 60, RectJIG(swapCh(1)).Rectangle.Y + 10)
                txtRectJIGSize(swapCh(1)).Location = New System.Drawing.Point(RectJIG(swapCh(1)).Rectangle.X + RectJIG(swapCh(1)).Rectangle.Width - 60, RectJIG(swapCh(1)).Rectangle.Y + RectJIG(swapCh(1)).Rectangle.Height - 10)
                'txtInHwType(swapCh(1)).Location = New System.Drawing.Point(RectJIG(swapCh(1)).Rectangle.X + RectJIG(swapCh(1)).Rectangle.Width - 40, RectJIG(swapCh(1)).Rectangle.Y + 10)
                'txtInRes(swapCh(1)).Location = New System.Drawing.Point(RectJIG(swapCh(1)).Rectangle.X + 50, RectJIG(swapCh(1)).Rectangle.Y + RectJIG(swapCh(1)).Rectangle.Height - 10)

                'rect1.panel_X = RectJIG(swapCh(0)).Rectangle.X
                'rect1.panel_Y = RectJIG(swapCh(0)).Rectangle.Y
                'rect1.panel_H = RectJIG(swapCh(0)).Rectangle.Height
                'rect1.panel_W = RectJIG(swapCh(0)).Rectangle.Width

                'rect2.panel_X = RectJIG(swapCh(1)).Rectangle.X
                'rect2.panel_Y = RectJIG(swapCh(1)).Rectangle.Y
                'rect2.panel_H = RectJIG(swapCh(1)).Rectangle.Height
                'rect2.panel_W = RectJIG(swapCh(1)).Rectangle.Width

                Me.Text = "Swap " & CStr(swapCh(0) + 1) & " (" & RectJIG(swapCh(0)).Rectangle.ToString & ") " & " And " & CStr(swapCh(1) + 1) & " (" & RectJIG(swapCh(1)).Rectangle.ToString & ") "

                '     RaiseEvent evSwapWindow(swapCh(0), rect1, swapCh(1), rect2)


            End If

            Invalidate()

            'For i As Integer = 0 To numWindow - 1
            '    calculationOutRectInfo(i)
            'Next

            fixedSwapPos = False

        End If

        'If e.Button = Windows.Forms.MouseButtons.Left Then

        '    RaiseEvent evChangedWindow(topIdx, m_WindowRect(topIdx), windRect)

        'End If


        '  Dim stemp As String
        'stemp = ""
        'For i As Integer = 0 To numWindow - 1
        '    stemp = stemp & "," & bShowCovers(i).ToString
        'Next
        'Me.Text = stemp

        Invalidate()

    End Sub

    Dim beforPos As Point = New System.Drawing.Point(0, 0)

    Private Sub frmScreenLayout_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim rect As Rectangle
        Dim nCountSelectWindow As Integer = 0

        Dim pt As System.Drawing.Point = e.Location


        'For i As Integer = 0 To numWindow - 1
        '    ' bRefreshFlag(i) = False
        'Next

        'For i As Integer = 0 To numWindow - 1

        '    If i = nTopMostWindowIndex Then
        '  CheckScreenBoundary(pt, nTopMostWindowIndex, outSideBoundary_Left, outSideBoundary_Right, outSideBoundary_Top, outSideBoundary_Bottom)

        'If outSideBoundary_Left = True Or outSideBoundary_Right = True Or outSideBoundary_Top = True Or outSideBoundary_Bottom = True Then
        '    Invalidate()
        '    Exit Sub
        'End If

        Dim i As Integer = nTopMostWindowIndex

        rect = RectJIG(i).Rectangle

        'If 0 > rect.X Then
        '    rect.X = 0
        '    pt.X = 0 = rect.X + (rect.Width \ 2)

        'End If

        'If 0 > rect.Y Then
        '    rect.Y = 0
        '    pt.Y = rect.Y + (rect.Height \ 2)

        'End If

        'If CurrentClientSize.Width < rect.X + rect.Width Then
        '    rect.X = CurrentClientSize.Width - rect.Width
        '    pt.X = rect.X + (rect.Width \ 2)

        'End If

        'If CurrentClientSize.Height < rect.Y + rect.Height Then
        '    rect.Y = CurrentClientSize.Height - rect.Height
        '    pt.Y = rect.Y + (rect.Width \ 2)
        'End If


        RectJIG(i).Rectangle = rect

        If mover(i).Move(e.Location) Then
            rect = RectJIG(i).Rectangle
            title(i).Location = New System.Drawing.Point(rect.X + (rect.Width \ 2), rect.Y + (rect.Height \ 2))
            txtRectJIGPos(i).Location = New System.Drawing.Point(rect.X + 60, rect.Y + 10)
            txtRectJIGSize(i).Location = New System.Drawing.Point(rect.X + rect.Width - 60, rect.Y + rect.Height - 10)

            txtRectJIGPos(i).Text = "X : " & Format(rect.X, "000") & ", Y : " & Format(rect.Y, "000")
            txtRectJIGSize(i).Text = "W : " & Format(rect.Width, "000") & ", H : " & Format(rect.Height, "000")

            Invalidate()
        End If


        Dim cnt As Integer

        CheckOverlab(e.Location, bShowCovers, cnt)

        If cnt <> 0 Then

            For i = 0 To m_numOfJIG - 1
                bShowCovers(i) = False
                'bRefreshFlag(i) = False
            Next
            bShowCovers(nTopMostWindowIndex) = True

        End If

    End Sub

    Dim isBusy As Boolean = False

    Private Sub frmEditJIGLayout_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim grfx As Graphics = e.Graphics

        Dim idx As Integer

        For p As Integer = m_numOfJIG - 1 To 0 Step -1

            ' idx = windowPriority.Priority(p)
            idx = p
            RectJIG(idx).Draw(grfx)
            title(idx).Draw(grfx)
            txtRectJIGPos(idx).Draw(grfx)

            ''txtInHwType(idx).Draw(grfx)
            ''txtInRes(idx).Draw(grfx)
            txtRectJIGSize(idx).Draw(grfx)
        Next

        'If bShowCovers(0) = True And bShowCovers(1) = True And bShowCovers(2) = True And bShowCovers(3) = True Then
        '    mover(nTopMostWindowIndex).Item(0).DrawCover(grfx)
        'Else


        For i As Integer = 0 To m_numOfJIG - 1

            If bShowCovers(i) = True Then
                mover(i).Item(0).DrawCover(grfx)
            End If
        Next

        'mover(nTopMostWindowIndex).Item(0).DrawCover(grfx)

        'End If
    End Sub

    '    Private Sub frmEditJIGLayout_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
    '        On Error GoTo sizeChangeError

    '        If isBusy = True Then Exit Sub

    '        isBusy = True

    '        Dim rect As Rectangle
    '        '  Dim rectBackup(numWindow - 1) As Rectangle
    '        Dim dRatioH As Double ' = Me.ClientSize.Height
    '        Dim dRatioW As Double ' = Me.ClientSize.Width

    '        Dim changeRateX(m_numOfJIG - 1) As Double
    '        Dim changeRateY(m_numOfJIG - 1) As Double
    '        Dim changeRateH(m_numOfJIG - 1) As Double
    '        Dim changeRateW(m_numOfJIG - 1) As Double

    '        BeforClientSize = CurrentClientSize
    '        CurrentClientSize = Me.ClientSize


    '        If CurrentClientSize.Height <= 0 Or CurrentClientSize.Width <= 0 Or BeforClientSize.Height <= 0 Or BeforClientSize.Width <= 0 Then
    '            isBusy = False
    '            Exit Sub
    '        End If



    '        dRatioH = CurrentClientSize.Height / BeforClientSize.Height
    '        dRatioW = CurrentClientSize.Width / BeforClientSize.Width

    '        'For i As Integer = 0 To numWindow - 1
    '        '    rectBackup(i) = window(i).Rectangle

    '        '    ' changeRateX(i) = 
    '        '    Next

    '        For i As Integer = 0 To m_numOfJIG - 1
    '            rect = RectJIG(i).Rectangle
    '            rect.X = rect.X * dRatioW
    '            rect.Y = rect.Y * dRatioH
    '            rect.Width = rect.Width * dRatioW
    '            rect.Height = rect.Height * dRatioH
    '            RectJIG(i).Rectangle = rect
    '            'title(i).Location = New System.Drawing.Point(rect.X + (rect.Width \ 2), rect.Y + (rect.Height \ 2))
    '            'txtRectJIGPos(i).Location = New System.Drawing.Point(rect.X + 60, rect.Y + 10)
    '            'txtRectJIGSize(i).Location = New System.Drawing.Point(rect.X + rect.Width - 60, rect.Y + rect.Height - 10)
    '            'txtInHwType(i).Location = New System.Drawing.Point(rect.X + rect.Width - 40, rect.Y + 10)
    '            'txtInRes(i).Location = New System.Drawing.Point(rect.X + 50, rect.Y + rect.Height - 10)

    '            ' calculationOutRectInfo(i)

    '            '  bRefreshFlag(i) = True
    '        Next

    '        Invalidate()

    '        '    RaiseEvent evChangedScreenSize(CurrentClientSize.Width, CurrentClientSize.Height)

    '        isBusy = False
    '        Exit Sub

    'sizeChangeError:

    '        'For i As Integer = 0 To numWindow - 1
    '        '    calculationOutRectInfo(i)
    '        'Next

    '        isBusy = False
    '    End Sub

    ' 좌표 입력 버튼 이벤트 - 서경축
    Private Sub tsBtnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnMove.Click

        Dim rect As Rectangle

        If BoxCheck = False Then
            MsgBox("지그를 선택해주세요")
            Exit Sub
        End If

        Dim LoX As Integer = Nothing
        Dim LoY As Integer = Nothing

        If tstbLocationX.Text = "" Or tstbLocationY.Text = "" Then
            MsgBox("값을 입력해주세요")
            Exit Sub
        End If

        LoX = tstbLocationX.Text
        LoY = tstbLocationY.Text

        rect = RectJIG(nTopMostWindowIndex).Rectangle

        rect.X = LoX
        rect.Y = LoY

        RectJIG(nTopMostWindowIndex).Rectangle = rect
        title(nTopMostWindowIndex).Location = New System.Drawing.Point(rect.X + (rect.Width \ 2), rect.Y + (rect.Height \ 2))
        txtRectJIGPos(nTopMostWindowIndex).Location = New System.Drawing.Point(rect.X + 60, rect.Y + 10)
        txtRectJIGSize(nTopMostWindowIndex).Location = New System.Drawing.Point(rect.X + rect.Width - 60, rect.Y + rect.Height - 10)

        txtRectJIGPos(nTopMostWindowIndex).Text = "X : " & Format(rect.X, "000") & ", Y : " & Format(rect.Y, "000")
        txtRectJIGSize(nTopMostWindowIndex).Text = "W : " & Format(rect.Width, "000") & ", H : " & Format(rect.Height, "000")

        Invalidate()
    End Sub

    Private Sub tsBtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub tsBtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub


    'Private Sub tstbClientSizeWidth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstbClientSizeWidth.TextChanged
    '    Dim width As Integer
    '    Dim height As Integer

    '    Try
    '        width = tstbClientSizeWidth.Text
    '        height = tstbClientSizeHeight.Text
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try
    '    '  lblCanvasEnd.Location = New System.Drawing.Point(width - lblCanvasEnd.Size.Width, height - lblCanvasEnd.Size.Height)
    'End Sub

    'Private Sub tstbClientSizeHeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstbClientSizeHeight.TextChanged
    '    Dim width As Integer
    '    Dim height As Integer

    '    Try
    '        width = tstbClientSizeWidth.Text
    '        height = tstbClientSizeHeight.Text
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try
    '    lblCanvasEnd.Location = New System.Drawing.Point(width - lblCanvasEnd.Size.Width, height - lblCanvasEnd.Size.Height)
    'End Sub

    Private Sub frmEditJIGLayout_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        'Dim width As Integer = Me.ClientSize.Width
        'Dim height As Integer = Me.ClientSize.Height

        'Try
        '    tstbClientSizeWidth.Text = width
        '    tstbClientSizeHeight.Text = height
        'Catch ex As Exception
        '    Exit Sub
        'End Try
        'lblCanvasEnd.Location = New System.Drawing.Point(width - lblCanvasEnd.Size.Width, height - lblCanvasEnd.Size.Height)
    End Sub


    Private Sub tstbLocationX_TextChanged(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tstbLocationX.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8)
    End Sub

    Private Sub tstbLocationY_TextChanged(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tstbLocationY.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8)
    End Sub
End Class



Public Class CWindowInfo

    Dim m_numWindow As Integer

    Dim nWindowP() As Integer  'index = priority, value = windowNumber

    Public ReadOnly Property Priority() As Integer()
        Get
            Return nWindowP.Clone
        End Get
    End Property

    Public ReadOnly Property TopWindowNum As Integer
        Get

            Return nWindowP(0)
        End Get
    End Property

    Public Sub New(ByVal numWindow As Integer)
        m_numWindow = numWindow
        ReDim nWindowP(m_numWindow - 1)
        For i As Integer = 0 To m_numWindow - 1
            nWindowP(i) = i
        Next
    End Sub


    Public Sub SetPriority(ByVal targetWindow As Integer, ByVal Priority As Integer)

        Dim BackupWindow As Integer

        'BackupWindow = nWindowP(Priority)

        'For i As Integer = 0 To m_numWindow - 1
        '    If nWindowP(i) = targetWindow Then
        '        nWindowP(i) = BackupWindow
        '    End If
        'Next

        'nWindowP(Priority) = targetWindow

        '   Dim sTempWindow As Integer
        nWindowP(0) = targetWindow

        For i As Integer = 0 To m_numWindow - 1
            BackupWindow = nWindowP(i)
            If BackupWindow = targetWindow Then Exit For
            nWindowP(i) = targetWindow
        Next

        'BackupWindow = nWindowP(0)
        'If BackupWindow = targetWindow Then Exit Sub
        'nWindowP(0) = targetWindow

        'sTempWindow = nWindowP(1)
        'If BackupWindow = targetWindow Then Exit Sub
        'nWindowP(1) = BackupWindow

        'BackupWindow = nWindowP(2)
        'If sTempWindow = targetWindow Then Exit Sub
        'nWindowP(2) = sTempWindow

        'If BackupWindow = targetWindow Then Exit Sub
        'nWindowP(3) = BackupWindow

    End Sub

    Public Sub setPriority(ByVal Priority() As Integer)
        nWindowP = Priority.Clone
    End Sub

    Public Function GetTopWindowIndexOfSelectedWindows(ByVal bSel() As Boolean) As Integer

        Dim minP As Integer = m_numWindow - 1

        For i As Integer = 0 To m_numWindow - 1

            If bSel(i) = True Then

                For p As Integer = 0 To m_numWindow - 1
                    If nWindowP(p) = i Then
                        If p < minP Then
                            minP = p
                        End If
                    End If
                Next

            End If

            ' bRefreshFlag(nTopMostWindowIndex) = False
        Next

        Return nWindowP(minP)

    End Function
End Class