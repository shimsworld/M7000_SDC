Imports System
Imports System.Threading
Imports NationalInstruments.NI4882


Public Class CComGPIB
    Inherits CComCommonNode

    Dim bIsConnected As Boolean = False
    Dim boardId As Integer = 0
    Dim primaryAddress As Integer
    Dim currentSecondaryAddress As Integer
    ' Dim GpibDevice As NationalInstruments.NI4882.Device

    Dim sTerminator As String = ""


#Region "Structure"

    Public Structure sGPIBInfos
        Dim nAddress As Integer
    End Structure


#End Region

#Region "Properties"

    Public Property Terminator As String
        Get
            Return sTerminator
        End Get
        Set(ByVal value As String)
            sTerminator = value
        End Set
    End Property

#End Region

#Region "GPIB Control Function"

    Public Sub New()
        MyBase.New()
        m_CommType = eCommType.eGPIB
        m_bIsOffline = False

    End Sub

    ' ''' <summary>
    ' ''' GPIB Connection Function, address parameter is GPIB address
    ' ''' </summary>
    ' ''' <param name="address"></param>
    ' ''' <remarks></remarks>

    Public Overrides Function Connect(ByVal config As sGPIBInfos) As eReturnCode
        Dim success As eReturnCode = eReturnCode.FuncErr

        bIsConnected = False

        primaryAddress = config.nAddress
        currentSecondaryAddress = 0

        'GpibDevice = New Device(CInt(boardId), CByte(primaryAddress), CByte(currentSecondaryAddress))

        'GpibDevice.Reset()
        'GpibDevice.ParallelPollConfigure(0)
        'GpibDevice.Clear()

        bIsConnected = True

        success = eReturnCode.OK

        Return success
    End Function


    Public Overrides Function Connect(ByVal sInfo As sCommInfo) As eReturnCode

       Dim success As eReturnCode = eReturnCode.FuncErr

        bIsConnected = False
        Try
            primaryAddress = sInfo.sGPIBInfo.nAddress
            currentSecondaryAddress = 0

            'GpibDevice = New Device(CInt(boardId), CByte(primaryAddress), CByte(currentSecondaryAddress))

            'GpibDevice.Reset()
            'GpibDevice.ParallelPollConfigure(0)
            'GpibDevice.Clear()

            bIsConnected = True

            success = eReturnCode.OK

            Return success

        Catch ex As Exception
            m_sStateMsg = ex.Message.ToString
            Return success
        End Try

        success = eReturnCode.OK
        Return success

    End Function


    Public Sub Disconnection()
        ' GpibDevice.Dispose()
    End Sub

#End Region

#Region "데이터 읽기/쓰기"
    Public Overrides Function BufClear() As CComCommonNode.eReturnCode
        '    GpibDevice.Clear()
        Return eReturnCode.OK
    End Function
    Public Overrides Function SendToString(ByVal textToSend As String, ByRef outData As String) As CComCommonNode.eReturnCode
        Dim strTemp As String = ""
        Dim rcvData As String = ""
        Dim nCnt As Integer = 0
        If bIsConnected = True Then

            Try

                ' GpibDevice.Write(textToSend & sTerminator)
            Catch ex As Exception

                ' GpibDevice.ParallelPollConfigure(0)

                Try
                    '    GpibDevice.Write(textToSend & sTerminator)
                Catch ex2 As Exception
                    m_sStateMsg = ex.Message.ToString
                    Return eReturnCode.FuncErr
                End Try
            End Try


            Try

                'Do
                Windows.Forms.Application.DoEvents()
                '.Reset()

                'Thread.Sleep(200)
                'strTemp = GpibDevice.ReadString(24)
                rcvData = rcvData & strTemp

                nCnt = nCnt + 1

                'If nCnt > 10 Then
                '    Exit Do
                'End If
                'If rcvData.Substring(rcvData.Length - 1, 1) = vbLf Then Exit Do
                'Loop


            rcvData = InsertCommonEscapeSequences(rcvData)

            Catch ex As Exception
                m_sStateMsg = ex.Message.ToString
                Return eReturnCode.FuncErr
            End Try
            outData = rcvData
        Else
            m_sStateMsg = "It is not connected"
            Return eReturnCode.FuncErr
        End If
        Return eReturnCode.OK
    End Function

    Public Overrides Function SendToString(ByVal textToSend As String) As CComCommonNode.eReturnCode
        Dim strTemp As String = ""
        Dim rcvData As String = ""
        If bIsConnected = True Then

            Try
                ' GpibDevice.Write(textToSend & sTerminator)
            Catch ex As Exception
                '  GpibDevice.ParallelPollConfigure(0)

                Try
                    '    GpibDevice.Write(textToSend & sTerminator)
                Catch ex2 As Exception
                    m_sStateMsg = ex.Message.ToString
                    Return eReturnCode.FuncErr
                End Try

            End Try

        Else
            Return eReturnCode.FuncErr
        End If
        Return eReturnCode.OK

    End Function

#End Region

#Region "Support Functions"


    Public Shared Function ReplaceCommonEscapeSequences(ByVal s As String) As String

        Return s.Replace("\n", ControlChars.Lf).Replace("\r", ControlChars.Cr)
    End Function 'ReplaceCommonEscapeSequences

    Public Shared Function InsertCommonEscapeSequences(ByVal s As String) As String
        Return s.Replace(ControlChars.Lf, "").Replace(ControlChars.Cr, "")
        ' Return s.Replace(ControlChars.Lf, "\n").Replace(ControlChars.Cr, "\r")
    End Function 'InsertCommonEscapeSequences

#End Region


End Class
