Imports System.Threading
Imports System.IO
Imports CCommLib


Public Class ucMcPG

#Region "Define"

    Public fMain As frmMain
    Public devCH As Integer = 0
    Public devAddr As Integer = 0
    Dim m_nSelDev As Integer

#End Region

#Region "properties"

    Public Property selectedDevice As Integer
        Get
            Return m_nSelDev
        End Get
        Set(ByVal value As Integer)
            m_nSelDev = value
        End Set
    End Property

#End Region


    Private Sub btn_chaddrset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_chaddrset.Click
        Try
            If Int(txt_addrs.Text) >= 0 And Int(txt_ch.Text) >= 0 Then
                devAddr = Int(txt_addrs.Text)
                devCH = Int(txt_ch.Text)
            Else
                MsgBox("설정 값은 0 보다 커야 합니다.")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btn_log_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_log.Click
        frmPGSendRecieveLog.Show()
    End Sub

    Private Sub btn_connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_connect.Click
        Dim configinfo As CCommLib.CComCommonNode.sCommInfo = Nothing 'CComSocket.sSocketInfo
        configinfo.commType = CComCommonNode.eCommType.eTCP
        configinfo.sLanInfo.sIPAddress = txt_ip.Text
        configinfo.sLanInfo.nPort = txt_port.Text

        If fSGConnection(configinfo.sLanInfo) = True Then
            txt_err.Text = "Connect"
            MsgBox("연결 성공", MsgBoxStyle.Critical, "Care!!")
            btn_connect.BackColor = Color.Green
        Else
            txt_err.Text = "DisConnect"
            fSGDisConnection()
            MsgBox("연결 실패", MsgBoxStyle.Critical, "Care!!")
            btn_connect.BackColor = Color.Red
        End If
    End Sub

#Region "Connection & Disconnection"
    Public Function fSGConnection(ByVal inConfig As CComSocket.sSockInfos) As Boolean

        If g_ConfigInfos.PGConfig.McPGConfig Is Nothing Then Return False


        If fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Connection(inConfig) = True Then

            Dim ret As Integer



            tbError.Text = ret

            Return fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).cPing(devAddr, devCH, ret)
        End If

        Return False
    End Function
    Public Function fSGDisConnection() As Boolean
        If fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).DisConnection() = False Then
            MsgBox("Port 확인")
            Return False
        End If
        Return True
    End Function

#End Region

    Private Sub btn_disconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_disconnect.Click
        fSGDisConnection()
        btn_connect.BackColor = Color.Red
    End Sub

    Private Sub btn_ping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ping.Click
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).cPing(devAddr, devCH, ret)

        tbError.Text = ret
    End Sub


    Private Sub btn_boardinfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_boardinfo.Click
        Dim tBoardInfoArr() As Byte = Nothing
        Dim ret As Integer
        Dim tError As Boolean
        Dim tListArr(1) As String


        tError = fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).cBoardInfo(devAddr, devCH, tBoardInfoArr, ret)
        tbError.Text = ret


        If tError = True Then
            UcSingleList1.ClearAllData()

            Dim tModleStr As String = ""
            Dim TempStr As String = ""
            '/////////////// Model //////////////////////
            For i As Integer = 8 To 22
                tModleStr = Convert.ToChar(tBoardInfoArr(i))
                TempStr &= tModleStr
            Next

            tListArr(0) = "Model"
            tListArr(1) = TempStr

            UcSingleList1.AddRowData(tListArr)

            Dim tSerialStr As String = ""
            TempStr = ""
            '/////////////// Serial No //////////////////////
            For i = 23 To 32
                tSerialStr = Convert.ToChar(tBoardInfoArr(i))
                If tSerialStr = "-" Then
                    tSerialStr = "."
                End If
                TempStr &= tSerialStr
            Next
            tListArr(0) = "Serial No"
            tListArr(1) = TempStr

            UcSingleList1.AddRowData(tListArr)
            '/////////////// Date //////////////////////
            Dim tDate As String = ""
            tDate = Convert.ToUInt16(tBoardInfoArr(33)) + 2000 & " " & Convert.ToUInt16(tBoardInfoArr(34)) & " " & Convert.ToUInt16(tBoardInfoArr(35))

            tListArr(0) = "Date"
            tListArr(1) = tDate

            UcSingleList1.AddRowData(tListArr)
            '/////////////// Etc //////////////////////
            Dim tfirmVer As String = ""
            Dim tFpgaVer As String = ""
            Dim tDacChannel As String = ""
            Dim tAdcChannel As String = ""
            Dim tAuxChannel As String = ""


            tfirmVer = Convert.ToByte(tBoardInfoArr(36)) & " " & Convert.ToByte(tBoardInfoArr(37)) / 100


            tListArr(0) = "Firmware Ver"
            tListArr(1) = tfirmVer

            UcSingleList1.AddRowData(tListArr)


            tFpgaVer = Convert.ToByte(tBoardInfoArr(38)) & " " & Convert.ToByte(tBoardInfoArr(39)) / 100



            tListArr(0) = "Fpga Ver"
            tListArr(1) = tFpgaVer

            UcSingleList1.AddRowData(tListArr)

            tDacChannel = Convert.ToByte(tBoardInfoArr(40))


            tListArr(0) = "Dac Channel"
            tListArr(1) = tDacChannel

            UcSingleList1.AddRowData(tListArr)

            tAdcChannel = Convert.ToByte(tBoardInfoArr(41))


            tListArr(0) = "ADC Channel"
            tListArr(1) = tAdcChannel

            UcSingleList1.AddRowData(tListArr)


            tAuxChannel = Convert.ToByte(tBoardInfoArr(42))



            tListArr(0) = "Aux Channel"
            tListArr(1) = tAuxChannel

            UcSingleList1.AddRowData(tListArr)

        End If

    End Sub

    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click
        Dim ret As Integer

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).cReset(devAddr, devCH, ret)
        tbError.Text = ret

    End Sub

    Private Sub btn_savedata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_savedata.Click
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).cSaveData(devAddr, devCH, ret)
        tbError.Text = ret
    End Sub

    Private Sub btn_regread_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_regread.Click

        Dim tStr As String = Nothing
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).cResisterRead(devAddr, devCH, tStr, ret)
        TextBox2.Text = tStr
        tbError.Text = ret
    End Sub

    Private Sub btn_reginit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reginit.Click

        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).cResisterInit(devAddr, devCH, ret)
        tbError.Text = ret
    End Sub

    Private Sub btn_getcomplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getcomplete.Click
        Dim tint As Integer
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).cComplete(devAddr, devCH, tint, ret)
        TextBox1.Text = tint
        tbError.Text = ret

    End Sub

    Private Sub btn_seqclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_seqclear.Click
        ListClear()
    End Sub
    Public Sub ListClear()
        UcSingleList2.ClearAllData()

    End Sub
    Dim MeasThread As Thread
    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

        'cFlag.FormClose = True
        'MeasThread = New Thread(AddressOf Loop_Meas)
        'MeasThread.Start()

        '   imgListAdd()
    End Sub
    Public Sub Loop_Meas()


        'Dim ExitLoopCount As Integer = 0

        'Do While cFlag.FormClose


        '    Application.DoEvents()


        '    Dim QCount As Integer
        '    Dim MeasBuff As Cqueue = New Cqueue
        '    SyncLock cMeasQueue

        '        QCount = cMeasQueue.Count
        '        If QCount > 0 Then
        '            MeasBuff = cMeasQueue.Dequeue
        '        End If

        '    End SyncLock

        '    If gCondition.Measure = True And QCount = 0 Then
        '        ExitLoopCount = 0
        '        cMeasQueue.Clear()
        '        btn_Start.Text = "Start"
        '        gCondition.Measure = False

        '    End If

        '    If QCount > 0 Then



        '        Dim StepNo As Integer = ExitLoopCount Mod (gCondition.MeasureCount) + 1
        '        Dim LoopNo As Integer = (ExitLoopCount) \ (gCondition.MeasureCount) + 1


        '        ExitLoopCount = ExitLoopCount + 1
        '        gCondition.Measure = True


        '        If MeasBuff.MeasMode = Cqueue.cMeasMode.ViewImage Then
        '            ''If MeasBuff.ImagePath.Substring(MeasBuff.ImagePath.Length - 3, 3) = "avi" Then
        '            ''    cDevPkd3200.StopMovie() '동영상 뿌리기
        '            ''    cDevPkd3200.PlayMovie(CStr(MeasBuff.ImagePath)) '동영상 뿌리기

        '            ''Else
        '            ''    cDevPkd3200.ViewImage(CStr(MeasBuff.ImagePath)) '이미지 뿌리기

        '            ''End If
        '            '


        '            UcImageView1.TextStatus("Image Path : " & CStr(MeasBuff.ImagePath) & vbCr & "LoopCount : " & CStr(LoopNo) & "," & "Step No : " & CStr(StepNo - 1))
        '            Thread.Sleep(500)

        '            Dim Tvalue As Integer = CDbl(MeasBuff.DelayTime)

        '            Tvalue = Tvalue * 1000
        '            Dim t_cnt As Integer = 0
        '            Dim d_cnt As Integer = Tvalue / 100
        '            Do
        '                If cDevPkd3200.eFlag.eMeas = False Then
        '                    Exit Do
        '                End If
        '                ' 
        '                Application.DoEvents()

        '                Thread.Sleep(100)
        '                t_cnt = t_cnt + 1
        '                UcImageView1.TextStatus("Delay : " & CStr(Tvalue / 1000) & " sec , " & CStr(t_cnt * 0.1) & " sec" & vbCr & "LoopCount : " & CStr(LoopNo) & " , " & "Step No : " & CStr(StepNo - 1))
        '                If t_cnt >= d_cnt Then
        '                    Exit Do
        '                End If
        '            Loop
        '            If MeasBuff.ImagePath.Substring(MeasBuff.ImagePath.Length - 3, 3) = "avi" Then
        '                cDevPkd3200.StopMovie() '동영상 뿌리기


        '            End If

        '        ElseIf MeasBuff.MeasMode = Cqueue.cMeasMode.STartDelay Then

        '            Dim Tvalue As Integer = CDbl(MeasBuff.DelayTime)

        '            Tvalue = Tvalue * 1000
        '            Dim t_cnt As Integer = 0
        '            Dim d_cnt As Integer = Tvalue / 100
        '            Do
        '                If cDevPkd3200.eFlag.eMeas = False Then
        '                    Exit Do
        '                End If
        '                ' 
        '                Application.DoEvents()

        '                Thread.Sleep(100)
        '                t_cnt = t_cnt + 1
        '                UcImageView1.TextStatus("Delay : " & CStr(Tvalue / 1000) & " sec , " & CStr(t_cnt * 0.1) & " sec" & vbCr & "LoopCount : " & CStr(LoopNo) & " , " & "Step No : " & CStr(StepNo - 1))
        '                If t_cnt >= d_cnt Then
        '                    Exit Do
        '                End If
        '            Loop

        '        End If



        '    Else
        '        ExitLoopCount = 0
        '        cDevPkd3200.eFlag.eMeas = False
        '        UcImageView1.TextStatus("Meas End")
        '    End If

        'Loop


    End Sub
    Private Sub btn_seqadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_seqadd.Click

        Try
            If img_list.SelectedItem <> "" And CDbl(txt_delay.Text) >= 0 Then
                AddSequenceImage(img_list.SelectedItem, (txt_delay.Text))
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Public Sub AddSequenceImage(ByVal in_ImageName As String, ByVal inTime As String)





        If IsNumeric(inTime) = False Then
            inTime = "0"
        End If



        Dim WriteData(1) As String
        If img_list.SelectedItem = "" Then
            img_list.SelectedIndex = 0
        End If


        WriteData(0) = CStr(in_ImageName)
        WriteData(1) = CStr(inTime)

        UcSingleList2.AddRowData(WriteData)



    End Sub

    Private Sub UcframePG_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Init()

    End Sub
    Public Sub Init()

        Dim Cnt As Integer
        cbo_imagenum.Items.Clear()
        img_list.Items.Clear()
        For Cnt = 1 To 40

            cbo_imagenum.Items.Add("Image " & CStr(Format(Cnt, "00")))
            img_list.Items.Add("" & CStr(Format(Cnt, "00")))
        Next
        cbo_imagenum.SelectedIndex = 0



    End Sub

    Private Sub btn_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Start.Click
        RcpSlideRun()
    End Sub
    Public Function RcpSlideRun() As Boolean


        'interval set
        Dim ret As Integer
        Dim GetInterval() As Integer = Nothing

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Get_SlideInterval(devAddr, devCH, ret, GetInterval)

        Dim Rcount As Integer = (UcSingleList2.RowCounts)
        Dim RStr() As String = Nothing

        For cnt As Integer = 0 To Rcount - 1
            UcSingleList2.GetRowData(cnt, RStr)
            GetInterval(RStr(0) - 1) = RStr(1) * 10 '초단위로 바꿈
        Next

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Set_SlideInterval(devAddr, devCH, ret, GetInterval)
        'interval set

        'image set
        Dim SelectImage() As Integer = Nothing '이미지 Selection 상태

        For cnt As Integer = 0 To Rcount - 1
            ReDim Preserve SelectImage(cnt)
            UcSingleList2.GetRowData(cnt, RStr)
            SelectImage(cnt) = RStr(0) - 1 '초단위로 바꿈
        Next

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Set_ImageSelection(devAddr, devCH, ret, SelectImage)

        'image set
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Set_SlideShowRun(devAddr, devCH, ret)

        Return True
    End Function

    Public tImagePath() As String

    Public Sub imgListAdd()
        img_list.Items.Clear()


        Dim tfolderpath As String = "C:\Users\jhlee\Desktop"

        Dim tFilesArr() As String


        tFilesArr = Directory.GetFiles(tfolderpath)

        Dim tCnt As Integer = 0

        For Cnt As Integer = 0 To tFilesArr.Length - 1
            Dim f_Extention As New FileInfo(tFilesArr(Cnt))
            If f_Extention.Extension = ".bmp" Or f_Extention.Extension = ".JPG" Or f_Extention.Extension = ".JPEG" Then
                ReDim Preserve tImagePath(tCnt)
                tImagePath(tCnt) = tFilesArr(Cnt)
                Dim tSplitArr() As String = tFilesArr(Cnt).Split("\")

                img_list.Items.Add(tSplitArr(tSplitArr.Length - 1))
                tCnt = tCnt + 1
            End If
        Next
    End Sub



    Private Sub btn_imgupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imgupload.Click
        ' 이미지 파일을 장비에 다운로드
        Dim ret As Integer
        Dim FOpendlg As New OpenFileDialog

        If FOpendlg.ShowDialog = DialogResult.OK Then

            If FOpendlg.FileName <> "" Then
                fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Set_FileDown(devAddr, devCH, ret, FOpendlg.FileName, cbo_imagenum.SelectedIndex)
            End If
        End If

    End Sub

    Private Sub img_list_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles img_list.DoubleClick
        '   Dim tImg As Image = Image.FromFile(tImagePath(img_list.SelectedIndex))
        Dim ret As Integer
        Dim filename As String = Nothing
        Dim outimage As Image = Nothing
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Get_Fileup(devAddr, devCH, ret, (img_list.SelectedIndex + 1), filename, outimage) ' devCH, 0, filename, outimage)
        PictureBox1.Image = outimage
    End Sub

    Private Sub img_list_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles img_list.MouseClick

    End Sub

    Private Sub img_list_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles img_list.SelectedIndexChanged
        If img_list.SelectedItem <> "" Then



        End If
    End Sub


    Private Sub btn_filedown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_filedown.Click
        ' 이미지 파일을 장비에 다운로드
        Dim ret As Integer
        If img_list.SelectedIndex >= 0 Then
            fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Set_FileDown(devAddr, devCH, ret, tImagePath(img_list.SelectedIndex), 0)
        Else
            MsgBox("이미지를 선택 해주세요")
        End If

    End Sub

    Private Sub btn_fileup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_fileup.Click
        Dim ret As Integer
        Dim filename As String = Nothing
        Dim outimage As Image = Nothing
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Get_Fileup(devAddr, devCH, ret, 0, filename, outimage) ' devCH, 0, filename, outimage)
    End Sub

    Private Sub btn_sliderun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sliderun.Click
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Set_SlideShowRun(devAddr, devCH, ret)
    End Sub

    Private Sub btn_slidestop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_slidestop.Click
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Set_SlideShowStop(devAddr, devCH, ret)
    End Sub

    Private Sub btn_imageSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imageSelection.Click
        Dim ret As Integer
        Dim SelectImage(1) As Integer '이미지 번호
        SelectImage(0) = 2
        SelectImage(1) = 3
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Set_ImageSelection(devAddr, devCH, ret, SelectImage)


    End Sub


    Private Sub btn_getimageselection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getimageselection.Click
        Dim ret As Integer
        Dim GetSelectImageNum() As Boolean = Nothing '이미지 Selection 상태

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Get_ImageSelection(devAddr, devCH, ret, GetSelectImageNum)
    End Sub

    Private Sub btn_setslideinterval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setslideinterval.Click
        Dim ret As Integer
        Dim SetInterval() As Integer

        ReDim SetInterval(40 - 1)

        For Cnt As Integer = 0 To SetInterval.Length - 1
            SetInterval(Cnt) = 30 '1value =100ms
        Next
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Set_SlideInterval(devAddr, devCH, ret, SetInterval)
    End Sub

    Private Sub btn_getslideinterval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_getslideinterval.Click
        Dim ret As Integer
        Dim GetInterval() As Integer = Nothing

        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Get_SlideInterval(devAddr, devCH, ret, GetInterval)
    End Sub

    Private Sub btn_imgdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imgdelete.Click

    End Sub

    Private Sub btn_stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_stop.Click
        Dim ret As Integer
        fMain.cPG.PatternGenerator(m_nSelDev).cMcPG(0).Set_SlideShowStop(devAddr, devCH, ret)
    End Sub
End Class
