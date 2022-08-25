Imports System.Windows.Forms


Public Class CMcFile

#Region "Define"
    Dim sExpFilterNames() As String = New String() {"CSV(*.csv)|*.csv", "RCP(*.rcp)|*.rcp", "Excel(*.xls)|*.xls", "INI(*.ini)|*.ini",
                                                     "BAK(*.bak)|*.bak", "PLI(*.pli)|*.pli", "PLL(*.pll)|*.pll", "PLM(*.plm)|*.plm",
                                                     "PLP(*.plp)|*.plp", "PLX(*.plx)|*.plx", "SEQ(*.seq)|*.seq", "SGI(*.sgi)|*.sgi", "EXE(*.exe)|*.exe", "INC(*.inc)|*.inc", "BMP(*.bmp)|*.bmp"}
    Dim sExpUppercaseNames() As String = New String() {"CSV", "RCP", "XLS", "INI", "BAK", "PLI", "PLL", "PLM", "PLP", "PLX", "SEQ", "SGI", "EXE", "INC", "BMP"}
    Dim sExpLowercaseNames() As String = New String() {"csv", "rcp", "xls", "ini", "bak", "pli", "pll", "plm", "plp", "plx", "seq", "sgi", "exe", "inc", "bmp"}
    Dim sInitilDirectorys() As String = New String() {"", "", "", "", "", "", "", "", "", "",
                                                      "\Sequence", "\Recipes\Signal Generator", "", "\Recipes\PG Register"}
    Dim gFileInfo As sFILENAME
    Dim g_strCurrentPath As String
    Private g_strDefaultPath As String



    Public Enum eFileType
        eCSV
        eRCP
        eExcel
        eINI
        eBAK
        ePLI
        ePLL
        ePLM
        ePLP
        ePLX
        eSEQ
        eSGI
        eEXE
        eINC
        eBMP
    End Enum

#End Region


#Region "Structure"

    Public Structure sFILENAME
        Dim strPathAndFName As String
        Dim strOnlyFName As String
        Dim strFNameAndExt As String
        Dim strOnlyExt As String
        Dim strFPath As String
        Dim strDate As String
    End Structure

#End Region


#Region "Functions"


#End Region

    Public Function GetSaveFileName(ByVal type As eFileType, ByRef outFileName As sFILENAME) As Boolean

        Dim arrBuf As Array
        Dim strTemp As String
        Dim i As Integer
        Dim SavefileDlg As New System.Windows.Forms.SaveFileDialog

        Dim cYear As String = Format(Now, "yyyy")
        Dim cMonth As String = Format(Now, "MM")
        Dim cDay As String = Format(Now, "dd")

        Dim cHour As String = Format(Now, "HH")
        Dim cMin As String = Format(Now, "mm")
        Dim cSec As String = Format(Now, "ss")


        With SavefileDlg
            .Title = "SaveFile"
            .Filter = sExpFilterNames(type) '"CSV(*.csv)|*.csv"
            .InitialDirectory = "App.path" 'SYSTemOption.outPut.strDefSavePathOfRcpFile
            .OverwritePrompt = False
            .AddExtension = True
        End With

        With outFileName
            .strDate = cYear & cMonth & cDay & "_" & cHour & cMin & cSec
            If SavefileDlg.ShowDialog = DialogResult.OK Then
                strTemp = SavefileDlg.FileName

                arrBuf = Split(strTemp, ".", -1)

                If arrBuf(arrBuf.Length - 1) = sExpUppercaseNames(type) Or arrBuf(arrBuf.Length - 1) = sExpLowercaseNames(type) Then

                Else
                    strTemp = strTemp & "." & sExpUppercaseNames(type)
                End If

                .strPathAndFName = strTemp

                If strTemp = "" Then
                    Return False
                End If

                arrBuf = Split(strTemp, "\", -1)
                .strFPath = arrBuf(0) & "\"

                If arrBuf.Length > 2 Then
                    For i = 1 To arrBuf.Length - 2
                        .strFPath = .strFPath & arrBuf(i) & "\"
                    Next
                    strTemp = arrBuf(arrBuf.Length - 1)
                    arrBuf = Split(strTemp, ".", -1)
                    .strFNameAndExt = strTemp
                    .strOnlyFName = arrBuf(0)
                    If arrBuf.Length > 2 Then
                        For i = 1 To arrBuf.Length - 2
                            .strOnlyFName = .strOnlyFName & "." & arrBuf(i)
                        Next
                    End If

                    .strOnlyExt = arrBuf(arrBuf.Length - 1)
                Else
                    strTemp = arrBuf(arrBuf.Length - 1)
                    arrBuf = Split(strTemp, ".", -1)
                    .strFNameAndExt = strTemp
                    .strOnlyFName = arrBuf(0)
                    If arrBuf.Length > 2 Then
                        For i = 1 To arrBuf.Length - 2
                            .strOnlyFName = .strOnlyFName & "." & arrBuf(i)
                        Next
                    End If

                    .strOnlyExt = arrBuf(arrBuf.Length - 1)

                End If

                Return True
            Else
                Return False
            End If

        End With

    End Function


    Public Function GetSaveFileName(ByVal type As eFileType, ByVal sInitialDirectory As String, ByRef outFileName As sFILENAME) As Boolean

        Dim arrBuf As Array
        Dim strTemp As String
        Dim i As Integer
        Dim SavefileDlg As New System.Windows.Forms.SaveFileDialog

        Dim cYear As String = Format(Now, "yyyy")
        Dim cMonth As String = Format(Now, "MM")
        Dim cDay As String = Format(Now, "dd")

        Dim cHour As String = Format(Now, "HH")
        Dim cMin As String = Format(Now, "mm")
        Dim cSec As String = Format(Now, "ss")


        With SavefileDlg
            .Title = "SaveFile"
            .Filter = sExpFilterNames(type) '"CSV(*.csv)|*.csv"
            .InitialDirectory = sInitialDirectory
            .OverwritePrompt = False
            .AddExtension = True
        End With

        With outFileName
            .strDate = cYear & cMonth & cDay & "_" & cHour & cMin & cSec
            If SavefileDlg.ShowDialog = DialogResult.OK Then
                strTemp = SavefileDlg.FileName

                arrBuf = Split(strTemp, ".", -1)

                If arrBuf(arrBuf.Length - 1) = sExpUppercaseNames(type) Or arrBuf(arrBuf.Length - 1) = sExpLowercaseNames(type) Then

                Else
                    strTemp = strTemp & "." & sExpUppercaseNames(type)
                End If

                .strPathAndFName = strTemp

                If strTemp = "" Then
                    Return False
                End If

                arrBuf = Split(strTemp, "\", -1)
                .strFPath = arrBuf(0) & "\"

                If arrBuf.Length > 2 Then
                    For i = 1 To arrBuf.Length - 2
                        .strFPath = .strFPath & arrBuf(i) & "\"
                    Next
                    strTemp = arrBuf(arrBuf.Length - 1)
                    arrBuf = Split(strTemp, ".", -1)
                    .strFNameAndExt = strTemp
                    .strOnlyFName = arrBuf(0)
                    If arrBuf.Length > 2 Then
                        For i = 1 To arrBuf.Length - 2
                            .strOnlyFName = .strOnlyFName & "." & arrBuf(i)
                        Next
                    End If

                    .strOnlyExt = arrBuf(arrBuf.Length - 1)
                Else
                    strTemp = arrBuf(arrBuf.Length - 1)
                    arrBuf = Split(strTemp, ".", -1)
                    .strFNameAndExt = strTemp
                    .strOnlyFName = arrBuf(0)
                    If arrBuf.Length > 2 Then
                        For i = 1 To arrBuf.Length - 2
                            .strOnlyFName = .strOnlyFName & "." & arrBuf(i)
                        Next
                    End If

                    .strOnlyExt = arrBuf(arrBuf.Length - 1)

                End If

                Return True
            Else
                Return False
            End If

        End With

    End Function


    Public Function GetFileName(ByVal type As eFileType, ByVal sFilePath As String, ByRef outFileName As sFILENAME) As Boolean

        Dim arrBuf As Array
        Dim strTemp As String
        Dim i As Integer
        Dim SavefileDlg As New System.Windows.Forms.SaveFileDialog

        Dim cYear As String = Format(Now, "yyyy")
        Dim cMonth As String = Format(Now, "MM")
        Dim cDay As String = Format(Now, "dd")

        Dim cHour As String = Format(Now, "HH")
        Dim cMin As String = Format(Now, "mm")
        Dim cSec As String = Format(Now, "ss")


        With outFileName
            .strDate = cYear & cMonth & cDay & "_" & cHour & cMin & cSec
            strTemp = sFilePath 'SavefileDlg.FileName

            arrBuf = Split(strTemp, ".", -1)

            If arrBuf(arrBuf.Length - 1) = sExpUppercaseNames(type) Or arrBuf(arrBuf.Length - 1) = sExpLowercaseNames(type) Then

            Else
                strTemp = strTemp & "." & sExpUppercaseNames(type)
            End If

            .strPathAndFName = strTemp

            If strTemp = "" Then
                Return False
            End If

            arrBuf = Split(strTemp, "\", -1)
            .strFPath = arrBuf(0) & "\"

            If arrBuf.Length > 2 Then
                For i = 1 To arrBuf.Length - 2
                    .strFPath = .strFPath & arrBuf(i) & "\"
                Next
                strTemp = arrBuf(arrBuf.Length - 1)
                arrBuf = Split(strTemp, ".", -1)
                .strFNameAndExt = strTemp
                .strOnlyFName = arrBuf(0)
                If arrBuf.Length > 2 Then
                    For i = 1 To arrBuf.Length - 2
                        .strOnlyFName = .strOnlyFName & "." & arrBuf(i)
                    Next
                End If

                .strOnlyExt = arrBuf(arrBuf.Length - 1)
            Else
                strTemp = arrBuf(arrBuf.Length - 1)
                arrBuf = Split(strTemp, ".", -1)
                .strFNameAndExt = strTemp
                .strOnlyFName = arrBuf(0)
                If arrBuf.Length > 2 Then
                    For i = 1 To arrBuf.Length - 2
                        .strOnlyFName = .strOnlyFName & "." & arrBuf(i)
                    Next
                End If

                .strOnlyExt = arrBuf(arrBuf.Length - 1)

            End If

            Return True


        End With

    End Function


    Public Shared Function FilePathParser(ByVal sFilePath As String, ByRef outFileName As sFILENAME) As Boolean

        Dim arrBuf As Array
        Dim strTemp As String
        Dim i As Integer
        Dim SavefileDlg As New System.Windows.Forms.SaveFileDialog

        Dim cYear As String = Format(Now, "yyyy")
        Dim cMonth As String = Format(Now, "MM")
        Dim cDay As String = Format(Now, "dd")

        Dim cHour As String = Format(Now, "HH")
        Dim cMin As String = Format(Now, "mm")
        Dim cSec As String = Format(Now, "ss")


        With outFileName
            .strDate = cYear & cMonth & cDay & "_" & cHour & cMin & cSec
            strTemp = sFilePath 'SavefileDlg.FileName

            arrBuf = Split(strTemp, ".", -1)

            .strPathAndFName = strTemp

            If strTemp = "" Then
                Return False
            End If

            arrBuf = Split(strTemp, "\", -1)
            .strFPath = arrBuf(0) & "\"

            If arrBuf.Length > 2 Then
                For i = 1 To arrBuf.Length - 2
                    .strFPath = .strFPath & arrBuf(i) & "\"
                Next
                strTemp = arrBuf(arrBuf.Length - 1)
                arrBuf = Split(strTemp, ".", -1)
                .strFNameAndExt = strTemp
                .strOnlyFName = arrBuf(0)
                If arrBuf.Length > 2 Then
                    For i = 1 To arrBuf.Length - 2
                        .strOnlyFName = .strOnlyFName & "." & arrBuf(i)
                    Next
                End If

                .strOnlyExt = arrBuf(arrBuf.Length - 1)
            Else
                strTemp = arrBuf(arrBuf.Length - 1)
                arrBuf = Split(strTemp, ".", -1)
                .strFNameAndExt = strTemp
                .strOnlyFName = arrBuf(0)
                If arrBuf.Length > 2 Then
                    For i = 1 To arrBuf.Length - 2
                        .strOnlyFName = .strOnlyFName & "." & arrBuf(i)
                    Next
                End If

                .strOnlyExt = arrBuf(arrBuf.Length - 1)

            End If

            Return True

        End With
    End Function


    Public Function GetDefaultSaveFileName(ByVal nch As Integer, ByVal type As eFileType, ByRef outFileName As sFILENAME) As Boolean


        Dim arrBuf As Array
        Dim strTemp As String
        Dim i As Integer
        'Dim SavefileDlg As New System.Windows.Forms.SaveFileDialog

        Dim cYear As String = Format(Now, "yyyy")
        Dim cMonth As String = Format(Now, "MM")
        Dim cDay As String = Format(Now, "dd")

        Dim cHour As String = Format(Now, "HH")
        Dim cMin As String = Format(Now, "mm")
        Dim cSec As String = Format(Now, "ss")

        'With SavefileDlg
        '    .Title = "SaveFile"
        '    .Filter = sExpFilterNames(type) '"CSV(*.csv)|*.csv"
        '    If type = eFileType.eCSV Then   'CSV 파일은 데이터 파일 저장용
        '        .InitialDirectory = "App.path" 'SYSTemOption.outPut.strDefSavePathOfDataFile
        '    ElseIf type = eFileType.eRCP Then   'RCP 파일은 Recipe 파일 저장용
        '        .InitialDirectory = "App.path" 'SYSTemOption.outPut.strDefSavePathOfRcpFile
        '    Else
        '        .InitialDirectory = "App.path"
        '    End If
        '    .OverwritePrompt = False
        '    .AddExtension = True
        'End With

        With outFileName
            .strDate = cYear & cMonth & cDay & "_" & cHour & cMin & cSec
            'If SavefileDlg.ShowDialog = DialogResult.OK Then

            strTemp = g_strDefaultPath & "Ch" & Format(nch + 1, "000") & "." & sExpLowercaseNames(type)

            arrBuf = Split(strTemp, ".", -1)

            If arrBuf(arrBuf.Length - 1) = sExpUppercaseNames(type) Or arrBuf(arrBuf.Length - 1) = sExpLowercaseNames(type) Then

            Else
                strTemp = strTemp & "." & sExpUppercaseNames(type)
            End If

            .strPathAndFName = strTemp

            If strTemp = "" Then
                Return False
            End If

            arrBuf = Split(strTemp, "\", -1)
            .strFPath = arrBuf(0) & "\"

            If arrBuf.Length > 2 Then
                For i = 1 To arrBuf.Length - 2
                    .strFPath = .strFPath & arrBuf(i) & "\"
                Next
                strTemp = arrBuf(arrBuf.Length - 1)
                arrBuf = Split(strTemp, ".", -1)
                .strFNameAndExt = strTemp
                .strOnlyFName = arrBuf(0)
                If arrBuf.Length > 2 Then
                    For i = 1 To arrBuf.Length - 2
                        .strOnlyFName = .strOnlyFName & "." & arrBuf(i)
                    Next
                End If

                .strOnlyExt = arrBuf(arrBuf.Length - 1)
            Else
                strTemp = arrBuf(arrBuf.Length - 1)
                arrBuf = Split(strTemp, ".", -1)
                .strFNameAndExt = strTemp
                .strOnlyFName = arrBuf(0)
                If arrBuf.Length > 2 Then
                    For i = 1 To arrBuf.Length - 2
                        .strOnlyFName = .strOnlyFName & "." & arrBuf(i)
                    Next
                End If

                .strOnlyExt = arrBuf(arrBuf.Length - 1)

            End If

            Return True
            'Else
            'Return False
            'End If

        End With

    End Function

    Public Function GetLoadFileName(ByVal type As eFileType, ByRef outFileName As sFILENAME) As Boolean

        Dim arrBuf As Array
        Dim strTemp As String
        Dim i As Integer
        Dim OpenfileDlg As New System.Windows.Forms.OpenFileDialog
        Dim cYear As String = Format(Now, "yyyy")
        Dim cMonth As String = Format(Now, "MM")
        Dim cDay As String = Format(Now, "dd")

        Dim cHour As String = Format(Now, "HH")
        Dim cMin As String = Format(Now, "mm")
        Dim cSec As String = Format(Now, "ss")

        With OpenfileDlg
            .Title = "LoadFile"
            '.Filter = "eoi(*.eoi)|*.eoi"
            .Filter = sExpFilterNames(type) '"CSV(*.csv)|*.csv"
            .InitialDirectory = "App.path" 'SYSTemOption.outPut.strDefSavePathOfRcpFile
            .AddExtension = True
        End With

        With outFileName
            .strDate = cYear & cMonth & cDay & "_" & cHour & cMin & cSec
            If OpenfileDlg.ShowDialog = DialogResult.OK Then
                strTemp = OpenfileDlg.FileName

                arrBuf = Split(strTemp, ".", -1)

                If arrBuf(arrBuf.Length - 1) = sExpUppercaseNames(type) Or arrBuf(arrBuf.Length - 1) = sExpLowercaseNames(type) Then

                Else
                    strTemp = strTemp & "." & sExpUppercaseNames(type)
                End If

                .strPathAndFName = strTemp

                If strTemp = "" Then
                    Return False
                End If

                arrBuf = Split(strTemp, "\", -1)
                .strFPath = arrBuf(0) & "\"

                If arrBuf.Length > 2 Then
                    For i = 1 To arrBuf.Length - 2
                        .strFPath = .strFPath & arrBuf(i) & "\"
                    Next
                    strTemp = arrBuf(arrBuf.Length - 1)
                    arrBuf = Split(strTemp, ".", -1)
                    .strFNameAndExt = strTemp
                    .strOnlyFName = arrBuf(0)
                    If arrBuf.Length > 2 Then
                        For i = 1 To arrBuf.Length - 2
                            .strOnlyFName = .strOnlyFName & "." & arrBuf(i)
                        Next
                    End If

                    .strOnlyExt = arrBuf(arrBuf.Length - 1)
                Else
                    strTemp = arrBuf(arrBuf.Length - 1)
                    arrBuf = Split(strTemp, ".", -1)
                    .strFNameAndExt = strTemp
                    .strOnlyFName = arrBuf(0)
                    If arrBuf.Length > 2 Then
                        For i = 1 To arrBuf.Length - 2
                            .strOnlyFName = .strOnlyFName & "." & arrBuf(i)
                        Next
                    End If

                    .strOnlyExt = arrBuf(arrBuf.Length - 1)

                End If

                Return True
            Else
                Return False
            End If

        End With

    End Function

    Public Function GetLoadFileName(ByVal type As eFileType, ByVal sInitialDirectory As String, ByRef outFileName As sFILENAME) As Boolean

        Dim arrBuf As Array
        Dim strTemp As String
        Dim i As Integer
        Dim OpenfileDlg As New System.Windows.Forms.OpenFileDialog
        Dim cYear As String = Format(Now, "yyyy")
        Dim cMonth As String = Format(Now, "MM")
        Dim cDay As String = Format(Now, "dd")

        Dim cHour As String = Format(Now, "HH")
        Dim cMin As String = Format(Now, "mm")
        Dim cSec As String = Format(Now, "ss")

        With OpenfileDlg
            .Title = "LoadFile"
            .Filter = sExpFilterNames(type)
            .InitialDirectory = sInitialDirectory
            .AddExtension = True
        End With

        With outFileName
            .strDate = cYear & cMonth & cDay & "_" & cHour & cMin & cSec
            If OpenfileDlg.ShowDialog = DialogResult.OK Then
                strTemp = OpenfileDlg.FileName

                arrBuf = Split(strTemp, ".", -1)

                If arrBuf(arrBuf.Length - 1) = sExpUppercaseNames(type) Or arrBuf(arrBuf.Length - 1) = sExpLowercaseNames(type) Then

                Else
                    strTemp = strTemp & "." & sExpUppercaseNames(type)
                End If

                .strPathAndFName = strTemp

                If strTemp = "" Then
                    Return False
                End If

                arrBuf = Split(strTemp, "\", -1)
                .strFPath = arrBuf(0) & "\"

                If arrBuf.Length > 2 Then
                    For i = 1 To arrBuf.Length - 2
                        .strFPath = .strFPath & arrBuf(i) & "\"
                    Next
                    strTemp = arrBuf(arrBuf.Length - 1)
                    arrBuf = Split(strTemp, ".", -1)
                    .strFNameAndExt = strTemp
                    .strOnlyFName = arrBuf(0)
                    If arrBuf.Length > 2 Then
                        For i = 1 To arrBuf.Length - 2
                            .strOnlyFName = .strOnlyFName & "." & arrBuf(i)
                        Next
                    End If

                    .strOnlyExt = arrBuf(arrBuf.Length - 1)
                Else
                    strTemp = arrBuf(arrBuf.Length - 1)
                    arrBuf = Split(strTemp, ".", -1)
                    .strFNameAndExt = strTemp
                    .strOnlyFName = arrBuf(0)
                    If arrBuf.Length > 2 Then
                        For i = 1 To arrBuf.Length - 2
                            .strOnlyFName = .strOnlyFName & "." & arrBuf(i)
                        Next
                    End If

                    .strOnlyExt = arrBuf(arrBuf.Length - 1)

                End If

                Return True
            Else
                Return False
            End If

        End With

    End Function

    Public Function FindFolder(ByRef outPath As String) As Boolean
        Dim folderDlg As System.Windows.Forms.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog

        If folderDlg.ShowDialog() = DialogResult.OK Then
            outPath = folderDlg.SelectedPath
        Else
            Return False
        End If
        Return True
    End Function

End Class
