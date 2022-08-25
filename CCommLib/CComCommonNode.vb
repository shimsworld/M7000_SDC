
Public Class CComCommonNode


#Region "Defines"

    'Dim cUDP As CComSocket
    'Dim cSerial As CComSerial

    Protected m_CommType As eCommType
    Protected m_CommStatus As sCommState
    Protected m_bIsOffline As Boolean = False
    Protected m_sStateMsg As String
    Protected m_DataType As CComSerial.eDataType = CComSerial.eDataType.eString

    Protected m_dTimeOut As Double
    Protected m_bRcvCont As Boolean = True
    Protected m_bModeRcvCont As Boolean = False
    Protected m_sRcvCont As String = False
    ' Protected g_eRS232Status As CCommunicator.eTransferState


    Public Event evDataRecivedToString(ByVal str As String)
    Public Event evDataRecivedToByte(ByVal nByte() As Byte)



#End Region

#Region "Structures"

    Public Structure sCommInfo
        Dim sSerialInfo As CComSerial.sSerialPortInfo
        Dim sLanInfo As CComSocket.sSockInfos
        Dim sGPIBInfo As CComGPIB.sGPIBInfos
        Dim commType As eCommType
    End Structure

    Public Structure sCommState
        Dim serialStatus As eTransferState
    End Structure


#End Region


#Region "Enums"

    Public Enum eCommType
        eUDP
        eTCP
        eSerial
        eGPIB
        eUSB
        eTCP_MultiSocket
    End Enum

    Public Enum eSubCommType
        eRS232
        eRS485
    End Enum

    Public Enum eTransferState
        eReady
        eTransferingData
        eReciveFail_TimeOut
        eReciveFail_TimeOut_Counter
        eReciveComplete
        eReciveFail_NoData
        eClosedComPort
        eSendComplete
    End Enum


    Public Enum eReturnCode
        NoSupport = 0
        OK = 1
        FuncErr
    End Enum

#End Region


#Region "Properties"

    Public Overridable ReadOnly Property Status() As sCommState
        Get
            Return m_CommStatus
        End Get
    End Property

    Public Overridable ReadOnly Property StateMessage As String
        Get
            Return m_sStateMsg
        End Get
    End Property

    Public Overridable Property IsOffLine() As Boolean
        Get
            Return m_bIsOffline
        End Get
        Set(ByVal value As Boolean)
            m_bIsOffline = value
        End Set
    End Property

    Public Overridable Property DataType As CComSerial.eDataType
        Get
            Return m_DataType
        End Get
        Set(ByVal value As CComSerial.eDataType)
            m_DataType = value
        End Set
    End Property

    Public Overridable Property TimeOut As Double
        Get
            Return m_dTimeOut
        End Get
        Set(ByVal value As Double)
            m_dTimeOut = value
        End Set
    End Property
    Public Overridable Property RcvContinousData As Boolean


        Get
            Return m_bRcvCont
        End Get
        Set(value As Boolean)
            m_bRcvCont = value
        End Set
    End Property

    Public Overridable Property Configure() As CComSerial.sSerialPortInfo
        Get
            Return Nothing
        End Get
        Set(ByVal value As CComSerial.sSerialPortInfo)

        End Set
    End Property

    Public ReadOnly Property TransferStatus As sCommState
        Get
            Return m_CommStatus
        End Get
    End Property
#End Region


    Public Sub New()

    End Sub

    Public Overridable Function Connect(ByVal commInfo As sCommInfo) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function Connect(ByVal sInfo As CComSerial.sSerialPortInfo) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Sub Connect(ByVal sIP As CComSocket.sSockInfos)

    End Sub

    Public Overridable Function Connect(ByVal sGPIB As CComGPIB.sGPIBInfos) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Sub Disconnect()

    End Sub

    ''' <summary>
    ''' String Type 명령 전송, 응답에 대하여 확인 하지 않음.
    ''' </summary>
    ''' <param name="textToSend"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SendToString(ByVal textToSend As String) As eReturnCode

        Return eReturnCode.NoSupport
    End Function

    ''' <summary>
    ''' String Type 명령 전송, Query 명령 또는 Ack(응답)에대한 값을 반환함.
    ''' </summary>
    ''' <param name="textToSend"></param>
    ''' <param name="outData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SendToString(ByVal textToSend As String, ByRef outData As String) As eReturnCode

        Return eReturnCode.NoSupport
    End Function
    Public Overridable Function BufClear() As eReturnCode

        Return eReturnCode.NoSupport
    End Function

    ''' <summary>
    ''' Byte() 명령 전송, Query 명령 또는 ACK(응답)에 대한 값을 반환함.
    ''' </summary>
    ''' <param name="Wbyte"></param>
    ''' <param name="outData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SendToBytes(ByVal Wbyte() As Byte, ByRef outData() As Byte) As eReturnCode

        Return eReturnCode.NoSupport
    End Function

    ''' <summary>
    ''' Byte() 명령 전송, 응답에 대한 명령을 확인하지 않음.
    ''' </summary>
    ''' <param name="Wbyte"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SendToBytes(ByVal Wbyte() As Byte) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function SendToBytes(ByVal Wbyte() As Byte, ByRef rcvData() As Byte, ByVal bQuerry As Boolean) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    ''' <summary>
    '''  Byte() 명령 전송,  ACK(응답)에 대한 값을 지정한 길이 만큼 반환함.
    ''' </summary>
    ''' <param name="Wbyte">송신 데이터</param>
    ''' <param name="outData">수신 데이터</param>
    ''' <param name="RcvDataLen">Image 데이터가 정상 수신될때 수신할 데이터의 길이를 지정 </param>
    '''  <param name="RcvDataLen_Error">Image 데이터가 없을 경우 수신할 데이터의 길이를 지정 </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SendToBytes(ByVal Wbyte() As Byte, ByRef outData() As Byte, ByVal RcvDataLen As Integer, ByVal RcvDataLen_Error As Integer) As eReturnCode
        Return eReturnCode.NoSupport
    End Function


    ''' <summary>
    ''' 수신 전용 함수
    ''' </summary>
    ''' <param name="outData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public Overridable Function ReciveToString(ByRef outData As String) As eReturnCode
        Return eReturnCode.NoSupport
    End Function

    Public Overridable Function ReciveToBytes(ByRef outData() As Byte) As eReturnCode
        Return eReturnCode.NoSupport
    End Function


    Public Sub ClearStateMsg()
        m_sStateMsg = ""
    End Sub

    Protected Sub DataRecivedToString(ByVal str As String)
        RaiseEvent evDataRecivedToString(str)
    End Sub

    Protected Sub DataRecivedToByte(ByVal nByte() As Byte)
        RaiseEvent evDataRecivedToByte(nByte)
    End Sub

End Class
