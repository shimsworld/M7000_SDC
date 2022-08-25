Imports System.IO


Public Class frmBrightSetting
    Dim ucBrightSettings As ucBrightSetting
    Public m_IndexNum As Integer
    Dim m_MaxCh As Integer
    Dim strCalibrationParam() As String = {"A Factor", "B Factor", "C Factor", "D Factor", "E Factor", "F Factor", "G Factor", "H Factor", "I Factor", "J Factor", "K Factor"}
    Dim sChBrightCal(,) As String

    Public Sub New(ByVal IndexNum As Integer, ByVal chNum As Integer)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_IndexNum = IndexNum
        m_MaxCh = chNum
        init()
    End Sub

    Public Sub init()
        ucBrightSettings = New ucBrightSetting(m_IndexNum, m_MaxCh)

        Controls.Add(ucBrightSettings)
        ucBrightSettings.BringToFront()
        ucBrightSettings.Location = New Point(20, 30)
        ucBrightSettings.Size = New Size(680, 390)
        ucBrightSettings.ChannelLine = 10
        ucBrightSettings.AutoScroll = True
        ucBrightSettings.BorderStyle = BorderStyle.FixedSingle

        For idx As Integer = 0 To m_IndexNum - 1
            ucBrightSettings.FactorName(idx) = strCalibrationParam(idx)
        Next

        For idx As Integer = 0 To m_MaxCh - 1
            ucBrightSettings.ChannelName(idx) = "CH"
        Next

    End Sub


    Private Sub frmBrightSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' ReDim sChBrightCal(m_IndexNum - 1, g_nMaxCh - 1)
        '   Dim CalData(,) As String = Nothing

        '   LoadOptions(CalData) 'sChBrightCal
        'LoadBrightCalData(sChBrightCal)

    End Sub


    Public Function SaveOptions(ByVal CalData(,) As String) As Boolean
        Dim str As String

        FileOpen(1, g_sPATH_SYSINI & g_BrightCal_FileName, OpenMode.Output)

        str = "[Calibration Factor]"
        PrintLine(1, str)

        If CalData Is Nothing = True Then
            MsgBox("Input Value Error!!")
            FileClose(1)
            Return False
        End If

        For idx As Integer = 0 To m_IndexNum - 1
            str = idx + 1 & " Factor :" & vbCrLf

            For jdx As Integer = 0 To m_MaxCh - 1
                str = str & CalData(idx, jdx) & ","
            Next

            str = str.TrimEnd(",")
            PrintLine(1, str)
        Next

        FileClose(1)

        Return True
    End Function

    Public Function LoadOptions(ByRef CalData(,) As String) As Boolean
        Dim fs1 As FileStream
        Dim sr1 As StreamReader

        ReDim CalData(m_IndexNum - 1, g_nMaxCh - 1)

        If File.Exists(g_sPATH_SYSINI & g_BrightCal_FileName) = False Then
            Return False
        Else
            fs1 = New FileStream(g_sPATH_SYSINI & g_BrightCal_FileName, FileMode.Open, FileAccess.Read)
            sr1 = New StreamReader(fs1, System.Text.Encoding.Default)
        End If

        Dim nCnt As Integer
        Dim i As Integer = 0
        Dim sLine As String = sr1.ReadLine()
        Dim arrVal As Array = Nothing
        Dim arrBuff(0) As CUnitCommonNode.eMKSUnit

        Try

            If sLine = "[Calibration Factor]" Then

            Else
                'MsgBox("File Load Error.")
                fs1.Close()
                sr1.Close()
                Return False
            End If

            While (Not sLine Is Nothing) '(Not sLine Is Nothing)

                sLine = sr1.ReadLine()

                '해당 Line이 Null값인 경우 빠져나간다.
                If sLine = "" Then
                    Exit While
                End If

                Try

                    If sLine = nCnt + 1 & " Factor :" Then
                        sLine = sr1.ReadLine()
                        arrVal = Split(sLine, ",", -1)

                        For jdx As Integer = 0 To arrVal.Length - 1
                            CalData(nCnt, jdx) = arrVal(jdx)
                        Next
                    End If

                Catch ex As Exception
                    fs1.Close()
                    sr1.Close()
                    Return False
                End Try

             
                nCnt = nCnt + 1

            End While


        Catch ex As Exception
            fs1.Close()
            sr1.Close()
        End Try

        fs1.Close()
        sr1.Close()

        '********************************************************
        '모듈파일에 저장
        '##################
        '로드된 값을 설정

        sChBrightCal = CalData.Clone

        SetOption()

        Return True
    End Function

    Public Sub SetOption()
        For idx As Integer = 0 To m_IndexNum - 1
            For jdx As Integer = 0 To g_nMaxCh - 1
                ucBrightSettings.tbInput(idx, jdx).Text = Format(CDbl(sChBrightCal(idx, jdx)), "0.00000")
            Next
        Next
    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If MsgBox("Are you sure?", MsgBoxStyle.OkCancel, "ChAllocation") = MsgBoxResult.Ok Then
            '  SaveAllocationData(SystemChAllocation)  'YSR

            ReDim sChBrightCal(m_IndexNum - 1, g_nMaxCh - 1)

            For idx As Integer = 0 To m_IndexNum - 1
                For jdx As Integer = 0 To g_nMaxCh - 1
                    sChBrightCal(idx, jdx) = ucBrightSettings.tbInput(idx, jdx).Text
                Next
            Next

            If SaveOptions(sChBrightCal) = False Then
                Exit Sub
            End If

            'If SaveBrightCalData(sChBrightCal) = False Then
            '    Exit Sub
            'End If
            Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class