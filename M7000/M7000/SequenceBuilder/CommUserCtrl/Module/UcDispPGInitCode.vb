Imports System.IO

Public Class UcDispPGInitCode


    'Dim m_InitCodeData()() As cDevMcPGControl.sRegisterInfos
    Dim initCodeLoader As New CIOInitialCode

    Dim m_InitCodeInfo As sInitCodeInfo

    Dim m_bIsVisibleOnlyGrid As Boolean = False

    Public Structure sInitCodeInfo
        Dim InitCodeData()() As cDevMcPGControl.sRegisterInfos
        Dim FileInfo As CMcFile.sFILENAME
    End Structure
#Region "Property"

    Public Property Datas() As sInitCodeInfo 'cDevMcPGControl.sRegisterInfos()()
        Get
            Return m_InitCodeInfo '.InitCodeData 'm_InitCodeData
        End Get
        Set(ByVal value As sInitCodeInfo) 'cDevMcPGControl.sRegisterInfos()())
            m_InitCodeInfo = value '  m_InitCodeData = value
            UpdateList()
        End Set
    End Property

    Public Property IsVisibleOnlyGrid As Boolean
        Get
            Return m_bIsVisibleOnlyGrid
        End Get
        Set(ByVal value As Boolean)
            m_bIsVisibleOnlyGrid = value
            If m_bIsVisibleOnlyGrid = True Then
                SplitContainer1.SplitterDistance = SplitContainer1.Size.Width
                SplitContainer1.Panel2.Hide()
                SplitContainer2.Visible = False
            Else
                SplitContainer1.Panel2.Show()
                SplitContainer2.Visible = True
            End If

        End Set
    End Property

#End Region

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Private Sub init()

        SplitContainer1.Location = New System.Drawing.Point(0, 0)
        SplitContainer1.Dock = DockStyle.Fill
        ucDataGrid.Location = New System.Drawing.Point(0, 0)
        ucDataGrid.Dock = DockStyle.Fill

        gbControl.Location = New System.Drawing.Point(0, 0)
        gbControl.Dock = DockStyle.Fill
        gbImportExport.Location = New System.Drawing.Point(0, 0)
        gbImportExport.Dock = DockStyle.Fill

        SplitContainer1.Panel2.Show()

        SplitContainer2.Visible = True
    End Sub

    Public Shared Function ConvertTargetRegIntToString(ByVal val As cDevMcPGControl.eTargetReg) As String
        If val = cDevMcPGControl.eTargetReg.Mipi Then
            Return cDevMcPGControl.eTargetReg.Mipi.ToString
        ElseIf val = cDevMcPGControl.eTargetReg.DriverIC Then
            Return cDevMcPGControl.eTargetReg.DriverIC.ToString
        ElseIf val = cDevMcPGControl.eTargetReg.Delay Then
            Return cDevMcPGControl.eTargetReg.Delay.ToString
        ElseIf val = cDevMcPGControl.eTargetReg.Packet Then
            Return cDevMcPGControl.eTargetReg.Packet.ToString
        ElseIf val = cDevMcPGControl.eTargetReg.Packet_Comment Then
            Return cDevMcPGControl.eTargetReg.Packet_Comment.ToString
        Else
            Return ""
        End If
    End Function

    Public Shared Function ConvertTargetRegStrToInt(ByVal val As String) As cDevMcPGControl.eTargetReg
        If val = cDevMcPGControl.eTargetReg.Mipi.ToString Then
            Return cDevMcPGControl.eTargetReg.Mipi
        ElseIf val = cDevMcPGControl.eTargetReg.DriverIC.ToString Then
            Return cDevMcPGControl.eTargetReg.DriverIC
        ElseIf val = cDevMcPGControl.eTargetReg.Delay.ToString Then
            Return cDevMcPGControl.eTargetReg.Delay
        ElseIf val = cDevMcPGControl.eTargetReg.Packet.ToString Then
            Return cDevMcPGControl.eTargetReg.Packet
        ElseIf val = cDevMcPGControl.eTargetReg.Packet_Comment.ToString Then
            Return cDevMcPGControl.eTargetReg.Packet_Comment
        Else
            Return -1
        End If
    End Function

    Public Sub ClearData()
        m_InitCodeInfo = Nothing ' m_InitCodeData = Nothing
        'nCntSignal = 0
        UpdateList()
    End Sub


    Private Sub btnLoadInitCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadInitCode.Click
        If initCodeLoader.LoadInitialCodeFile(m_InitCodeInfo) = False Then Exit Sub

        '  LoadInitialCode()
        UpdateList()

        ucDataGrid.ReAdjustRow()
    End Sub

    Private Sub btnSaveInitCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveInitCode.Click
        Dim InitCodeInfos As UcDispPGInitCode.sInitCodeInfo = Nothing
        GetPGInitCodeList(InitCodeInfos)

        If initCodeLoader.SaveInitialCodeFile(InitCodeInfos) = False Then Exit Sub



        'm_InitCodeInfo = InitCodeInfo
        'UpdateList()
        'ucDataGrid.ReAdjustRow()
    End Sub

    'Public Function SaveInitialCode(ByVal InitCodeInfo As UcDispPGInitCode.sInitCodeInfo) As Boolean

    '    If initCodeLoader.SaveInitialCodeFile(InitCodeInfo) = False Then Return False

    '    Return True
    'End Function

    'Public Function LoadInitialCode() As Boolean
    '    If initCodeLoader.LoadInitialCodeFile(m_InitCodeInfo) = False Then Return False

    '    Return True
    'End Function

    'Public Function SaveInitialCode(ByVal configInfos()() As cDevMcPGControl.sRegisterInfos) As Boolean

    '    Return True
    'End Function

    Public Sub GetPGInitCodeList(ByRef InitCodeInfos As UcDispPGInitCode.sInitCodeInfo)
        Dim rstr() As String = New String() {"", "", "", "", "", "", ""}
        Dim nTarget As cDevMcPGControl.eTargetReg

        Dim initCode As cDevMcPGControl.sRegisterInfos = Nothing
        Dim initCodePacket() As cDevMcPGControl.sRegisterInfos = Nothing
        Dim nCntCode As Integer = 0
        Dim nCntPacket As Integer = 0


        For idx As Integer = 0 To ucDataGrid.RowLineNum - 1
            ucDataGrid.GetRowData(idx, rstr)

            nTarget = ConvertTargetRegStrToInt(rstr(1))

            'If nTarget = cDevMcPGControl.eTargetReg.Packet Then
            '    ReDim Preserve InitCodeInfos.InitCodeData(nCntPacket)

            'End If

            'rstr {No,  Target,  McAddr, Len, Value, Comment}
            Select Case nTarget
                Case cDevMcPGControl.eTargetReg.Mipi
                    initCode.nTarget = nTarget
                    initCode.nRegAddr = Convert.ToInt32(CIOInitialCode.ConvertStrHEXToByte(rstr(2)))
                    initCode.nDataLen = Convert.ToInt32(CIOInitialCode.ConvertStrHEXToByte(rstr(3)))
                    initCode.nDelay = 0
                    initCode.sCommet = rstr(6)


                    ' arrBuf = Split(rstr(4), ",", -1)
                    ReDim initCode.nRegValue(1)

                    For i As Integer = 0 To initCode.nRegValue.Length - 1
                        initCode.nRegValue(i) = Convert.ToInt32(CIOInitialCode.ConvertStrHEXToByte(rstr(i + 4)))
                    Next

                Case cDevMcPGControl.eTargetReg.Packet
                    initCode.nTarget = nTarget

                Case cDevMcPGControl.eTargetReg.Packet_Comment
                    initCode.nTarget = nTarget
                    initCode.nRegAddr = 0
                    initCode.nDataLen = 0
                    initCode.nDelay = 0
                    initCode.sCommet = rstr(6)
                    initCode.nRegValue = Nothing

                Case cDevMcPGControl.eTargetReg.Delay
                    initCode.nTarget = nTarget
                    initCode.nRegAddr = 0
                    initCode.nDataLen = 0
                    initCode.nDelay = rstr(4)
                    initCode.sCommet = ""
                    initCode.nRegValue = Nothing

                Case cDevMcPGControl.eTargetReg.DriverIC

            End Select

            If initCode.nTarget <> cDevMcPGControl.eTargetReg.Packet Then
                ReDim Preserve initCodePacket(nCntCode)
                initCodePacket(nCntCode).nTarget = initCode.nTarget
                initCodePacket(nCntCode).nDelay = initCode.nDelay
                initCodePacket(nCntCode).nDataLen = initCode.nDataLen
                initCodePacket(nCntCode).nRegAddr = initCode.nRegAddr
                initCodePacket(nCntCode).sCommet = initCode.sCommet

                If initCode.nRegValue Is Nothing = False Then
                    initCodePacket(nCntCode).nRegValue = initCode.nRegValue.Clone
                Else
                    initCodePacket(nCntCode).nRegValue = Nothing
                End If

                nCntCode += 1
            ElseIf initCode.nTarget = cDevMcPGControl.eTargetReg.Packet Then
                ReDim Preserve InitCodeInfos.InitCodeData(nCntPacket)

                If nCntPacket >= 1 Then
                    InitCodeInfos.InitCodeData(nCntPacket - 1) = initCodePacket.Clone
                End If

                nCntPacket += 1
                initCodePacket = Nothing
                nCntCode = 0
            End If
        Next


        If initCodePacket Is Nothing = False Then
            '맨 매지막 패킷
            InitCodeInfos.InitCodeData(nCntPacket - 1) = initCodePacket.Clone
        End If

        Dim cFile As New CMcFile
        Dim m_FileInfo As CMcFile.sFILENAME = Nothing

        If lblFilePath.Text <> "" Then
            If cFile.GetFileName(CMcFile.eFileType._INC, lblFilePath.Text, m_FileInfo) = False Then

            End If

            InitCodeInfos.FileInfo = m_FileInfo
            m_InitCodeInfo.FileInfo = m_FileInfo
        Else
            InitCodeInfos.FileInfo = Nothing
            m_InitCodeInfo.FileInfo = Nothing
        End If


        If initCodePacket Is Nothing = False Then
            m_InitCodeInfo.InitCodeData = InitCodeInfos.InitCodeData.Clone
        Else
            m_InitCodeInfo.InitCodeData = Nothing
        End If



    End Sub

    Public Sub UpdateList()
        Dim ChCnt As Integer = 0
        Dim bReadOnly As Boolean

        ucDataGrid.ClearRow()
        If m_InitCodeInfo.InitCodeData Is Nothing = False Then
            txtComments.Text = m_InitCodeInfo.FileInfo.strOnlyFName
            lblFilePath.Text = m_InitCodeInfo.FileInfo.strPathAndFName

            For i As Integer = 0 To m_InitCodeInfo.InitCodeData.Length - 1
                Dim rStr() As String = New String() {"", "", "", "", "", "", ""}
                rStr(1) = cDevMcPGControl.eTargetReg.Packet.ToString '& " " & i + 1
                rStr(2) = i + 1
                'ucDispDataGrid.AddRowData(rStr)
                ChCnt += 1
                rStr(0) = ChCnt
                ucDataGrid.AddRowData(rStr)
                ucDataGrid.RowReadOnly(True)
                ucDataGrid.RowColorChange(Color.Red)

                For n As Integer = 0 To m_InitCodeInfo.InitCodeData(i).Length - 1
                    rStr(1) = m_InitCodeInfo.InitCodeData(i)(n).nTarget.ToString
                    If m_InitCodeInfo.InitCodeData(i)(n).nTarget = cDevMcPGControl.eTargetReg.Delay Then
                        rStr(2) = "" 'Addr
                        rStr(3) = "" 'Data Len
                        rStr(4) = m_InitCodeInfo.InitCodeData(i)(n).nDelay   'Delay or Value
                        rStr(5) = ""
                        rStr(6) = m_InitCodeInfo.InitCodeData(i)(n).sCommet '""
                    ElseIf m_InitCodeInfo.InitCodeData(i)(n).nTarget = cDevMcPGControl.eTargetReg.Packet_Comment Then
                        '  rStr(1) = "Packet_Comment"
                        rStr(2) = "" 'Addr
                        rStr(3) = "" 'Data Len
                        rStr(4) = ""  'Delay or Value1
                        rStr(5) = ""  'Delay or Value2
                        rStr(6) = m_InitCodeInfo.InitCodeData(i)(n).sCommet
                    Else
                        rStr(2) = Hex(m_InitCodeInfo.InitCodeData(i)(n).nRegAddr) 'Addr
                        rStr(3) = m_InitCodeInfo.InitCodeData(i)(n).nDataLen 'Data Len
                        Dim tStr As String = ""
                        Dim sNonHex As String = ""
                        For Cnt As Integer = 0 To m_InitCodeInfo.InitCodeData(i)(n).nRegValue.Length - 1

                            If Hex(m_InitCodeInfo.InitCodeData(i)(n).nRegValue(Cnt)).Length = 1 Then
                                sNonHex = "0" & Hex(m_InitCodeInfo.InitCodeData(i)(n).nRegValue(Cnt))
                            Else
                                sNonHex = Hex(m_InitCodeInfo.InitCodeData(i)(n).nRegValue(Cnt))
                            End If

                            rStr(Cnt + 4) = sNonHex
                            'tStr = tStr & "," & sNonHex 'Format(Hex(m_InitCodeInfo.InitCodeData(i)(n).nRegValue(Cnt)), "00")
                        Next
                        ' tStr = tStr.TrimStart(",")
                        ' rStr(4) = tStr
                        rStr(6) = m_InitCodeInfo.InitCodeData(i)(n).sCommet '""
                    End If

                    'ucDispDataGrid.AddRowData(rStr)
                    ChCnt += 1
                    rStr(0) = ChCnt

                    If rStr(2) = "BF" Then
                        bReadOnly = False
                    Else
                        bReadOnly = True
                    End If

                    ucDataGrid.AddRowData(rStr)
                    ucDataGrid.RowReadOnly(bReadOnly)
                Next

            Next

            For i As Integer = 0 To 3  '수정 필요. 현재 4번째 Col까지만 수정 못하도록 함.
                ucDataGrid.ColReadOnly(i, True)
            Next

        End If

    End Sub


    Private Sub ucDataGrid_evShowUI() Handles ucDataGrid.evShowUI

        GetRowData()
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim nSelRow As Integer = ucDataGrid.SelectedRowNum
        ucDataGrid.DeleteSelectedRow(nSelRow)

        '   GetList()
        UpdateList()

    End Sub


    Private Sub GetRowData()
        Dim sData() As String = Nothing
        ucDataGrid.GetRowData(ucDataGrid.SelectedRowNum, sData)

        txtTarget.Text = sData(1)
        txtAddr.Text = sData(2)
        txtLength.Text = sData(3)
        txtValue.Text = sData(4)
        txtCommand.Text = sData(5)

    End Sub

  
End Class
