Imports System.IO


Public Class CIOInitialCode


#Region "Defien"

    Public m_FileInfo As CMcFile.sFILENAME
    Dim m_nFileNum As Integer = 100
    Dim m_InitCode()() As cDevMcPGControl.sRegisterInfos

    Const sMARK_ANNOTATION As String = "//"
    Const sMARK_PACKET As String = ";;"
    Const sMARK_PACKET_COMMENT As String = "*"
#End Region


#Region "Propreties"

    Public Property InitCodes As cDevMcPGControl.sRegisterInfos()()
        Get
            Return m_InitCode
        End Get
        Set(ByVal value As cDevMcPGControl.sRegisterInfos()())
            m_InitCode = value.Clone
        End Set
    End Property
#End Region

#Region "Creator, Disposer And Init"

    Public Sub New()
        init()
    End Sub


    Private Sub init()
        m_InitCode = Nothing
    End Sub

#End Region

    Public Function LoadInitialCodeFile() As Boolean
        Return LoadInitialCodeFile(m_InitCode)
    End Function

    Public Function LoadInitialCodeFile(ByRef initCodes()() As cDevMcPGControl.sRegisterInfos) As Boolean

        Dim cFile As New CMcFile

        If cFile.GetLoadFileName(CMcFile.eFileType._INC, m_FileInfo) = False Then Return False

        FileOpen(m_nFileNum, m_FileInfo.strPathAndFName, OpenMode.Input, OpenAccess.Read, OpenShare.Shared) '파일을 열고

        Dim sLineBuf As String
        Dim initCode As cDevMcPGControl.sRegisterInfos
        Dim initCodePacket() As cDevMcPGControl.sRegisterInfos
        Dim nCntCode As Integer = 0
        Dim nCntPacket As Integer = 0
        Dim arrBuf As Array

        Do

            Try
                sLineBuf = FileSystem.LineInput(m_nFileNum)
            Catch ex As Exception
                Exit Do
            End Try

            If sLineBuf <> "" Then

                'Fine Packet Mark 
                If sLineBuf.Contains(sMARK_PACKET) = True Then
                    ReDim Preserve initCodes(nCntPacket)
                    initCodePacket = Nothing
                    nCntCode = 0
                    Do
                        Try
                            sLineBuf = FileSystem.LineInput(m_nFileNum)
                        Catch ex As Exception
                            Exit Do
                        End Try

                        If sLineBuf = "" Then Exit Do

                        initCode.sCommet = ""

                        'Fine and remove the Annotation
                        If sLineBuf.Contains(sMARK_ANNOTATION) = True Then   '주석이 있는경우
                            sLineBuf = sLineBuf.TrimStart(" ")
                            If sLineBuf.StartsWith(sMARK_ANNOTATION) = False Then
                                arrBuf = Split(sLineBuf, sMARK_ANNOTATION, -1)
                                sLineBuf = arrBuf(0)

                                For i As Integer = 1 To arrBuf.Length - 1
                                    initCode.sCommet = initCode.sCommet & arrBuf(i) & " / "
                                Next

                                initCode.sCommet.TrimEnd(" ")
                                initCode.sCommet.TrimEnd("/")

                                arrBuf = Split(sLineBuf, " ", -1)

                                initCode.nTarget = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(0)))

                                If initCode.nTarget = cDevMcPGControl.eTargetReg.Delay Then
                                    initCode.nDelay = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(1) & arrBuf(2)))
                                    initCode.nRegAddr = 0
                                    initCode.nDataLen = 0
                                    initCode.nRegValue = Nothing
                                Else
                                    initCode.nRegAddr = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(1)))
                                    initCode.nDataLen = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(2)))
                                    ReDim initCode.nRegValue(initCode.nDataLen - 1)
                                    For i As Integer = 0 To initCode.nDataLen - 1 ' arrBuf.Length - 4
                                        initCode.nRegValue(i) = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(i + 3)))
                                    Next
                                    initCode.nDelay = 0
                                End If


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

                            End If

                        Else '주석이 없는 경우

                            arrBuf = Split(sLineBuf, " ", -1)


                            initCode.nTarget = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(0)))

                            If initCode.nTarget = cDevMcPGControl.eTargetReg.Delay Then
                                initCode.nDelay = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(1) & arrBuf(2)))
                                initCode.nRegAddr = 0
                                initCode.nDataLen = 0
                                initCode.nRegValue = Nothing
                            Else
                                initCode.nRegAddr = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(1)))
                                initCode.nDataLen = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(2)))
                                ReDim initCode.nRegValue(initCode.nDataLen - 1)

                                If initCode.nDataLen = (arrBuf.Length - 3) Then
                                    For i As Integer = 0 To initCode.nDataLen - 1 ' arrBuf.Length - 4
                                        initCode.nRegValue(i) = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(i + 3)))
                                    Next
                                End If

                                initCode.nDelay = 0
                            End If


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

                        End If



                    Loop

                    initCodes(nCntPacket) = initCodePacket.Clone
                    nCntPacket += 1
                End If
                '  If sLineBuf = "//" Then

            End If

        Loop

        '파일을 닫고
        FileClose(m_nFileNum)

        m_InitCode = initCodes.Clone
        Return True
    End Function

    Public Function LoadInitialCodeFile(ByVal initCodesPath As CMcFile.sFILENAME) As cDevMcPGControl.sRegisterInfos()()

        Dim cFile As New CMcFile

        'If cFile.GetLoadFileName(CMcFile.eFileType.eINC, m_FileInfo) = False Then Return False
        If File.Exists(initCodesPath.strPathAndFName) = False Then Return Nothing

        FileOpen(m_nFileNum, initCodesPath.strPathAndFName, OpenMode.Input, OpenAccess.Read, OpenShare.Shared) '파일을 열고

        Dim sLineBuf As String
        Dim initCode As cDevMcPGControl.sRegisterInfos = Nothing
        Dim initCodePacket() As cDevMcPGControl.sRegisterInfos
        Dim nCntCode As Integer = 0
        Dim nCntPacket As Integer = 0
        Dim arrBuf As Array

        Do

            Try
                sLineBuf = FileSystem.LineInput(m_nFileNum)
            Catch ex As Exception
                Exit Do
            End Try

            If sLineBuf <> "" Then

                'Fine Packet Mark 
                If sLineBuf.Contains(sMARK_PACKET) = True Then
                    ReDim Preserve InitCodes(nCntPacket)
                    initCodePacket = Nothing
                    nCntCode = 0
                    Do
                        Try
                            sLineBuf = FileSystem.LineInput(m_nFileNum)
                        Catch ex As Exception
                            Exit Do
                        End Try

                        If sLineBuf = "" Then Exit Do

                        initCode.sCommet = ""

                        'Fine and remove the Annotation
                        If sLineBuf.StartsWith(sMARK_PACKET_COMMENT) = True Then  '"*" 주석 
                            sLineBuf = sLineBuf.TrimStart(" ")
                            sLineBuf = sLineBuf.TrimStart("*")
                            initCode.nTarget = cDevMcPGControl.eTargetReg.Packet_Comment
                            initCode.nDelay = 0
                            initCode.nRegAddr = 0
                            initCode.nDataLen = 0
                            initCode.nRegValue = Nothing
                            initCode.sCommet = sLineBuf
                        Else
                            If sLineBuf.Contains(sMARK_ANNOTATION) = True Then   '주석이 있는경우
                                sLineBuf = sLineBuf.TrimStart(" ")
                                If sLineBuf.StartsWith(sMARK_ANNOTATION) = False Then
                                    arrBuf = Split(sLineBuf, sMARK_ANNOTATION, -1)
                                    sLineBuf = arrBuf(0)

                                    'For i As Integer = 1 To arrBuf.Length - 1
                                    '    initCode.sCommet = initCode.sCommet & arrBuf(i) & " // "
                                    'Next

                                    For i As Integer = 1 To arrBuf.Length - 1
                                        If i > 1 Then
                                            initCode.sCommet = initCode.sCommet & " //" & arrBuf(i)
                                        Else
                                            initCode.sCommet = initCode.sCommet & arrBuf(i)
                                        End If
                                    Next

                                    initCode.sCommet.TrimStart(" ")
                                    initCode.sCommet.TrimEnd(" ")
                                    initCode.sCommet.TrimEnd("//")

                                    arrBuf = Split(sLineBuf, " ", -1)

                                    initCode.nTarget = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(0)))

                                    If initCode.nTarget = cDevMcPGControl.eTargetReg.Delay Then
                                        initCode.nDelay = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(1) & arrBuf(2)))
                                        initCode.nRegAddr = 0
                                        initCode.nDataLen = 0
                                        initCode.nRegValue = Nothing
                                    Else
                                        initCode.nRegAddr = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(1)))
                                        initCode.nDataLen = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(2)))
                                        ReDim initCode.nRegValue(initCode.nDataLen - 1)
                                        For i As Integer = 0 To initCode.nDataLen - 1 ' arrBuf.Length - 4
                                            initCode.nRegValue(i) = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(i + 3)))
                                        Next
                                        initCode.nDelay = 0
                                    End If


                                    'ReDim Preserve initCodePacket(nCntCode)
                                    'initCodePacket(nCntCode).nTarget = initCode.nTarget
                                    'initCodePacket(nCntCode).nDelay = initCode.nDelay
                                    'initCodePacket(nCntCode).nDataLen = initCode.nDataLen
                                    'initCodePacket(nCntCode).nRegAddr = initCode.nRegAddr
                                    'initCodePacket(nCntCode).sCommet = initCode.sCommet
                                    'If initCode.nRegValue Is Nothing = False Then
                                    '    initCodePacket(nCntCode).nRegValue = initCode.nRegValue.Clone
                                    'Else
                                    '    initCodePacket(nCntCode).nRegValue = Nothing
                                    'End If

                                    'nCntCode += 1

                                End If

                            Else '주석이 없는 경우

                                arrBuf = Split(sLineBuf, " ", -1)


                                initCode.nTarget = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(0)))

                                If initCode.nTarget = cDevMcPGControl.eTargetReg.Delay Then
                                    initCode.nDelay = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(1) & arrBuf(2)))
                                    initCode.nRegAddr = 0
                                    initCode.nDataLen = 0
                                    initCode.nRegValue = Nothing
                                Else
                                    initCode.nRegAddr = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(1)))
                                    initCode.nDataLen = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(2)))
                                    ReDim initCode.nRegValue(initCode.nDataLen - 1)

                                    If initCode.nDataLen = (arrBuf.Length - 3) Then
                                        For i As Integer = 0 To initCode.nDataLen - 1 ' arrBuf.Length - 4
                                            initCode.nRegValue(i) = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(i + 3)))
                                        Next
                                    End If

                                    initCode.nDelay = 0
                                End If


                                'ReDim Preserve initCodePacket(nCntCode)
                                'initCodePacket(nCntCode).nTarget = initCode.nTarget
                                'initCodePacket(nCntCode).nDelay = initCode.nDelay
                                'initCodePacket(nCntCode).nDataLen = initCode.nDataLen
                                'initCodePacket(nCntCode).nRegAddr = initCode.nRegAddr
                                'initCodePacket(nCntCode).sCommet = initCode.sCommet
                                'If initCode.nRegValue Is Nothing = False Then
                                '    initCodePacket(nCntCode).nRegValue = initCode.nRegValue.Clone
                                'Else
                                '    initCodePacket(nCntCode).nRegValue = Nothing
                                'End If

                                'nCntCode += 1

                            End If


                        End If

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

                    Loop

                    InitCodes(nCntPacket) = initCodePacket.Clone
                    nCntPacket += 1
                End If
                '  If sLineBuf = "//" Then

            End If

        Loop

        '파일을 닫고
        FileClose(m_nFileNum)

        m_InitCode = InitCodes.Clone
        Return m_InitCode
    End Function

    Public Function SaveInitialCodeFile(ByVal initCodes As UcDispPGInitCode.sInitCodeInfo) As Boolean
        Dim cFile As New CMcFile
        Dim sLineBuf As String = ""
        Dim nTarget As cDevMcPGControl.eTargetReg

        If cFile.GetSaveFileName(CMcFile.eFileType._INC, m_FileInfo) = False Then Return False

        Try
            FileOpen(m_nFileNum, m_FileInfo.strPathAndFName, OpenMode.Append, OpenAccess.Write, OpenShare.Shared) '파일을 열고
        Catch ex As Exception
            FileClose(m_nFileNum)
            Return False
        End Try

        For i As Integer = 0 To initCodes.InitCodeData.Length - 1
            sLineBuf = ";;" & cDevMcPGControl.eTargetReg.Packet.ToString & " " & i + 1
            PrintLine(m_nFileNum, sLineBuf)

            For j As Integer = 0 To initCodes.InitCodeData(i).Length - 1
                With initCodes.InitCodeData(i)(j)

                    nTarget = .nTarget

                    Select Case nTarget
                        '   Case cDevMcPGControl.eTargetReg.Packet
                        ' sLineBuf = ";;" & cDevMcPGControl.eTargetReg.Packet.ToString & " " & i + 1

                        Case cDevMcPGControl.eTargetReg.Mipi
                            sLineBuf = ConverStrHexToString(Hex(nTarget)) & " " & ConverStrHexToString(Hex(.nRegAddr)) & " " & ConverStrHexToString(Hex(.nDataLen)) & " " & _
                                       ConverStrHexToString(Hex(.nRegValue(0))) & " " & ConverStrHexToString(Hex(.nRegValue(1)))

                            If initCodes.InitCodeData(i)(j).sCommet <> "" Or initCodes.InitCodeData(i)(j).sCommet <> Nothing Then
                                sLineBuf = sLineBuf & " " & "//" & .sCommet
                            End If

                        Case cDevMcPGControl.eTargetReg.Packet_Comment
                            sLineBuf = "*" & .sCommet

                        Case cDevMcPGControl.eTargetReg.Delay
                            sLineBuf = ConverStrHexToString(Hex(nTarget)) & " " & "00" & " " & ConverStrHexToString(Hex(.nDelay))
                    End Select
                End With

                PrintLine(m_nFileNum, sLineBuf)
            Next

            sLineBuf = ""
            PrintLine(m_nFileNum, sLineBuf)
        Next

        FileClose(m_nFileNum)

        Return True
    End Function

    Public Function LoadInitialCodeFile(ByRef initCodes As UcDispPGInitCode.sInitCodeInfo) As Boolean

        Dim cFile As New CMcFile

        If cFile.GetLoadFileName(CMcFile.eFileType._INC, m_FileInfo) = False Then Return False

        FileOpen(m_nFileNum, m_FileInfo.strPathAndFName, OpenMode.Input, OpenAccess.Read, OpenShare.Shared) '파일을 열고

        Dim sLineBuf As String
        Dim initCode As cDevMcPGControl.sRegisterInfos = Nothing
        Dim initCodePacket() As cDevMcPGControl.sRegisterInfos
        Dim nCntCode As Integer = 0
        Dim nCntPacket As Integer = 0
        Dim arrBuf As Array

        Do

            Try
                sLineBuf = FileSystem.LineInput(m_nFileNum)
            Catch ex As Exception
                Exit Do
            End Try

            If sLineBuf <> "" Then

                'Fine Packet Mark 
                If sLineBuf.Contains(sMARK_PACKET) = True Then
                    ReDim Preserve initCodes.InitCodeData(nCntPacket)
                    initCodePacket = Nothing
                    nCntCode = 0
                    Do
                        Try
                            sLineBuf = FileSystem.LineInput(m_nFileNum)
                        Catch ex As Exception
                            Exit Do
                        End Try

                        If sLineBuf = "" Then Exit Do

                        initCode.sCommet = ""

                        'Fine and remove the Annotation
                        If sLineBuf.StartsWith(sMARK_PACKET_COMMENT) = True Then  '"**" 주석 
                            sLineBuf = sLineBuf.TrimStart(" ")
                            sLineBuf = sLineBuf.TrimStart("*")
                            initCode.nTarget = cDevMcPGControl.eTargetReg.Packet_Comment
                            initCode.nDelay = 0
                            initCode.nRegAddr = 0
                            initCode.nDataLen = 0
                            initCode.nRegValue = Nothing
                            initCode.sCommet = sLineBuf

                        Else
                            If sLineBuf.Contains(sMARK_ANNOTATION) = True Then   '주석이 있는경우
                                sLineBuf = sLineBuf.TrimStart(" ")
                                If sLineBuf.StartsWith(sMARK_ANNOTATION) = False Then
                                    arrBuf = Split(sLineBuf, sMARK_ANNOTATION, -1)
                                    sLineBuf = arrBuf(0)

                                    For i As Integer = 1 To arrBuf.Length - 1
                                        If i > 1 Then
                                            initCode.sCommet = initCode.sCommet & " //" & arrBuf(i)
                                        Else
                                            initCode.sCommet = initCode.sCommet & arrBuf(i)
                                        End If
                                    Next

                                    initCode.sCommet.TrimStart(" ")
                                    initCode.sCommet.TrimEnd(" ")
                                    initCode.sCommet.TrimEnd("//")

                                    arrBuf = Split(sLineBuf, " ", -1)

                                    initCode.nTarget = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(0)))

                                    If initCode.nTarget = cDevMcPGControl.eTargetReg.Delay Then
                                        initCode.nDelay = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(1) & arrBuf(2)))
                                        initCode.nRegAddr = 0
                                        initCode.nDataLen = 0
                                        initCode.nRegValue = Nothing
                                    Else
                                        initCode.nRegAddr = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(1)))
                                        initCode.nDataLen = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(2)))
                                        ReDim initCode.nRegValue(initCode.nDataLen - 1)
                                        For i As Integer = 0 To initCode.nDataLen - 1 ' arrBuf.Length - 4
                                            initCode.nRegValue(i) = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(i + 3)))
                                        Next
                                        initCode.nDelay = 0
                                    End If

                                Else

                                End If

                            Else '주석이 없는 경우

                                sLineBuf.TrimEnd(" ")

                                arrBuf = Split(sLineBuf, " ", -1)

                                initCode.nTarget = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(0)))

                                If initCode.nTarget = cDevMcPGControl.eTargetReg.Delay Then
                                    initCode.nDelay = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(1) & arrBuf(2)))
                                    initCode.nRegAddr = 0
                                    initCode.nDataLen = 0
                                    initCode.nRegValue = Nothing
                                Else
                                    initCode.nRegAddr = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(1)))
                                    initCode.nDataLen = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(2)))
                                    ReDim initCode.nRegValue(initCode.nDataLen - 1)

                                    If initCode.nDataLen = (arrBuf.Length - 3) Then
                                        For i As Integer = 0 To initCode.nDataLen - 1 ' arrBuf.Length - 4
                                            initCode.nRegValue(i) = Convert.ToInt32(ConvertStrHEXToByte(arrBuf(i + 3)))
                                        Next
                                    End If

                                    initCode.nDelay = 0
                                End If

                            End If

                        End If


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
                    Loop

                    initCodes.InitCodeData(nCntPacket) = initCodePacket.Clone
                    nCntPacket += 1
                End If
                '  If sLineBuf = "//" Then

            End If

        Loop

        '파일을 닫고
        FileClose(m_nFileNum)

        initCodes.FileInfo = m_FileInfo
        m_InitCode = initCodes.InitCodeData.Clone
        Return True
    End Function


    Public Shared Function ConvertStrHEXToByte(ByVal strHex As String) As Byte
        Return "&H" & strHex
    End Function

    Public Shared Function ConverStrHexToString(ByVal strHex As String) As String

        If strHex.Length = 1 Then
            strHex = "0" & strHex
        End If
        Return strHex
    End Function
End Class
