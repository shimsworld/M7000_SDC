Imports CCommLib

Public Class CDevSP790
    Inherits CDevTCCommonNode

    Dim communicator As CComAPI

    Dim m_nNumOfDev As Integer
    Dim m_numOfChPerDev As Integer
    Dim bySetData() As Byte
    Dim byGetData() As Byte
    Dim byFieldData() As Byte
    Dim nData_Len As Integer

    'Dim m_Settings() As sSettings

    Public Enum eCHANNEL
        CH1 = 0
    End Enum


    'Public Structure sSettings
    '    Dim devID As Integer
    '    Dim numOfCh As Integer
    '    Dim m_Settings() As sParams
    'End Structure

    'Public Structure sParams
    '    Dim measTemp As Double 'PV
    '    Dim setTemp As Double 'SP
    '    Dim bIsRun As Boolean
    'End Structure


#Region "MC Command"
    '공통 명령
    'Const STX As Byte = &H2
    'Const ETX As Byte = &H3

    Const STX As String = Chr(2)
    Const ETX As String = vbCrLf
    Const COMMA As String = ","

    'Module Control 명령
    Const MC_Command As Byte = &H22
    Const MC_DirverInitialize As Byte = &H0
    Const MC_DisplayONOFF As Byte = &H1
    Const MC_Register_ReadWrite As Byte = &H2
    Const MC_PatternSet As Byte = &H3

    '*PROCESS
    Const NPV As String = "0001"
    Const NSP As String = "0002"
    Const MVOUT As String = "0006"
    Const HEAT_MVOUT As String = "0007"
    Const COOL_MVOUT As String = "0008"
    Const PIDNO As String = "0009"
    Const NOWSTS As String = "0010"  'Bit- 0:STOP / 1:FIX RUN / 2:PROG RUN / 5:AT / 6:AUTO/MAN

    '*FUNCTION
    Const SET_PTNO As String = "0100"
    Const MODE As String = "0101"    'Word- 1:RUN / 2:HOLD / 3:STEP / 4:RESET / 5:MAN / 6:AUTO / 7:FIX / 8:PROG
    Const OPMODE As String = "0104"
    Const PWRMODE As String = "0105"
    Const HOLDONOFF As String = "0117"
    Const STEPONOFF As String = "0118"

    '*SET POINT
    Const SP1 As String = "0201"
    Const SP2 As String = "0202"
    Const SP3 As String = "0203"
    Const SP4 As String = "0204"

#End Region

#Region "Property"

    Public Overrides Property DevAddr As Integer
        Get
            Return ID485
        End Get
        Set(ByVal value As Integer)
            ID485 = value
        End Set
    End Property

    Public Overrides ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property

    Public Overrides Property NumOfChannelPerDev As Integer
        Get
            Return m_numOfChPerDev
        End Get
        Set(ByVal value As Integer)
            m_numOfChPerDev = value
        End Set

    End Property

#End Region

#Region "Connection/Disconnection"


    Public Overrides Function Connection(ByVal configInfo As CCommLib.CComCommonNode.sCommInfo) As Boolean
        Dim strTempCommand As String = ""
        Dim strRetData As String = ""

        'configInfo.sSerialInfo.sCMDTerminator = vbCrLf
        'configInfo.sSerialInfo.sTerminator = vbCrLf

        If communicator.Communicator.Connect(configInfo) = False Then
            m_bIsConnected = False
            Return False
        End If
        m_bIsConnected = True
        Return True
    End Function

    Public Overrides Sub Disconnection()
        communicator.Communicator.Disconnect()
    End Sub

#End Region

#Region "Creator & Dispose"

    Public Sub New(ByVal numOfDev As Integer)
        MyBase.New()
        m_MyModel = eModel._SP790
        m_nNumOfDev = numOfDev
        m_numOfChPerDev = 1
        communicator = New CComAPI(CComCommonNode.eCommType.eSerial)

        ReDim m_Settings(m_nNumOfDev - 1)
        Dim tempParam(0) As sParams

        For i As Integer = 0 To m_Settings.Length - 1
            m_Settings(i).devID = i
            m_Settings(i).numOfCh = 1
            m_Settings(i).Setting = tempParam.Clone
        Next
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region


#Region "Function"

    '"""""""""""""""""""""""""""""""""""""""""""
    'AMI : SP790 모델명 및 Version 표시
    'RSD : D-Register의 연속 Read
    'RRD : D-Register의 Random Read
    'WSD : D-Register의 연속 Write
    'WRD : D-Register의 Random Write
    'STD : D-Register의 Random 등록
    'CLD : STD에서 등록된 D-Register의 Call
    'SP : 설정온도
    'PV : 현재온도
    '"""""""""""""""""""""""""""""""""""""""""""
    Public Overrides Function DevINFO(ByVal addr As Integer, ByRef sInfo As String) As eReturnCode
        Dim Info As String = Nothing

        If AMI(addr, Info) = False Then Return eReturnCode.FuncErr

        Return eReturnCode.OK
    End Function

    Public Overrides Function OperationRun(ByVal addr As Integer) As eReturnCode
        Dim FieldData As String = Nothing
        Dim SetValue() As String = Nothing
        Dim ret As String = Nothing

        Dim DataNum As Integer = 1

        FieldData = ConvertDataNum(addr) & "WSD" & COMMA & ConvertDataNum(DataNum) & COMMA & MODE & COMMA & "0001"

        FieldData = STX & FieldData & Hex(CheckSum(FieldData)) & ETX
        'FieldData = STX & addr & "WSD" & COMMA & "02" & COMMA & "0201" & COMMA & SetValue & ETX

        If communicator.Communicator.SendToString(FieldData, ret) = False Then
            Return False
        Else
            If ret <> Nothing Then
                If ErrCheck(ret) = True Then
                    Return True
                Else
                    Return False
                End If

            End If
        End If

        Return True
    End Function

    Public Overrides Function OperationStop(ByVal addr As Integer) As eReturnCode
        Dim FieldData As String = Nothing
        Dim SetValue() As String = Nothing
        Dim ret As String = Nothing

        Dim DataNum As Integer = 1

        FieldData = ConvertDataNum(addr) & "WSD" & COMMA & ConvertDataNum(DataNum) & COMMA & MODE & COMMA & "0004"

        FieldData = STX & FieldData & Hex(CheckSum(FieldData)) & ETX

        If communicator.Communicator.SendToString(FieldData, ret) = False Then
            Return False
        Else
            If ret <> Nothing Then
                If ErrCheck(ret) = True Then
                    Return True
                Else
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Public Function AMI(ByVal addr As Integer, ByVal retData As String) As Boolean
        Dim FieldData As String = Nothing
        Dim ret As String = Nothing

        FieldData = STX & "AMI" & ETX

        If communicator.Communicator.SendToString(FieldData, ret) = False Then
            Return False
        Else
            If ret <> Nothing Then
                If DataParsing(ret, retData) = False Then
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Public Function RSD(ByVal addr As Integer, ByRef retData As sParams) As Boolean
        Dim FieldData As String = Nothing
        Dim ret As String = Nothing


        FieldData = ConvertDataNum(addr) & "RSD" & COMMA & "02" & COMMA & NPV

        FieldData = STX & FieldData & Hex(CheckSum(FieldData)) & ETX

        'FieldData = STX & addr & "RSD" & COMMA & "02" & COMMA & "0001" & ETX

        If communicator.Communicator.SendToString(FieldData, ret) = False Then
            Return False
        Else
            If ret <> Nothing Then
                If ConvertMeasData(ret, retData) = False Then
                    Return False
                End If
            End If
        End If

        retData.measTemp = retData.measTemp / 10   'PV
        retData.setTemp = retData.setTemp / 10     'SP

        Return True
    End Function

    Public Function RRD(ByVal addr As Integer, ByVal DataNum As Integer, ByVal retData As String) As Boolean
        Dim FieldData As String = Nothing
        Dim ret As String = Nothing


        FieldData = ConvertDataNum(addr) & "RRD" & COMMA & ConvertDataNum(DataNum) & COMMA

        For idx As Integer = 0 To DataNum - 1
            If idx <> DataNum - 1 Then
                FieldData = FieldData & ConvertDReg(idx + 1) & COMMA
            Else
                FieldData = FieldData & ConvertDReg(idx + 1)
            End If
        Next

        FieldData = STX & FieldData & Hex(CheckSum(FieldData)) & ETX


        'STX addrRRD,dataNum,Reg-1,Reg-2

        If communicator.Communicator.SendToString(FieldData, ret) = False Then
            Return False
        Else
            If ret <> Nothing Then
                If DataParsing(ret, retData) = False Then
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Public Function WSD(ByVal addr As Integer, ByVal DataNum As Integer, ByVal retData() As String) As Boolean
        Dim FieldData As String = Nothing
        Dim SetValue() As String = Nothing
        Dim ret As String = Nothing

        ReDim SetValue(retData.Length - 1)

        If retData Is Nothing = False Then

            FieldData = ConvertDataNum(addr) & "WSD" & COMMA & ConvertDataNum(DataNum) & COMMA & NSP & COMMA

            For idx As Integer = 0 To retData.Length - 1
                retData(idx) = retData(idx) * 10
                SetValue(idx) = ConvertDReg(retData(idx))

                If idx <> SetValue.Length - 1 Then
                    FieldData = FieldData & SetValue(idx) & COMMA
                Else
                    FieldData = FieldData & SetValue(idx)
                End If
            Next

            FieldData = STX & FieldData & Hex(CheckSum(FieldData)) & ETX
            'FieldData = STX & addr & "WSD" & COMMA & "02" & COMMA & "0201" & COMMA & SetValue & ETX

            If communicator.Communicator.SendToString(FieldData, ret) = False Then
                Return False
            Else
                If ret <> Nothing Then
                    If ErrCheck(ret) = True Then
                        Return True
                    Else
                        Return False
                    End If

                End If
            End If
        Else
            Return False
        End If

        Return True
    End Function

    Public Function WRD(ByVal addr As Integer, ByVal DataNum As Integer, ByVal retData() As String) As Boolean
        Dim FieldData As String = Nothing
        Dim ret As String = Nothing
        Dim SetValue() As String = Nothing

        FieldData = ConvertDataNum(addr) & "WRD" & COMMA & ConvertDataNum(DataNum) & COMMA

        For idx As Integer = 0 To retData.Length - 1

            retData(idx) = retData(idx) * 10
            SetValue(idx) = ConvertDReg(retData(idx))

            If idx <> SetValue.Length - 1 Then
                FieldData = FieldData & SetValue(idx) & COMMA
            Else
                FieldData = FieldData & SetValue(idx)
            End If
        Next

        FieldData = STX & FieldData & ETX

        'FieldData = STX & addr & "WRD" & COMMA & "개수" & COMMA & "D-RegNO1" & COMMA & "D-RegNO2" & "..." & "SUM" & ETX

        If communicator.Communicator.SendToString(FieldData, ret) = False Then
            Return False
        Else
            If ret <> Nothing Then
                'If DataParsing(ret, retData) = False Then
                '    Return False
                'End If
            End If
        End If

        Return True
    End Function

    Public Function STD(ByVal addr As Integer, ByVal retData As String) As Boolean
        Dim FieldData As String = Nothing
        Dim ret As String = Nothing

        FieldData = STX & addr & "STD" & COMMA & "개수" & COMMA & "D-RegNO1" & COMMA & "D-RegNO2" & "..." & "SUM" & ETX

        If communicator.Communicator.SendToString(FieldData, ret) = False Then
            Return False
        Else
            If ret <> Nothing Then
                If DataParsing(ret, retData) = False Then
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Public Function CLD(ByVal addr As Integer, ByVal retData As String) As Boolean
        Dim FieldData As String = Nothing
        Dim ret As String = Nothing

        FieldData = STX & addr & "CLD" & "SUM" & ETX

        If communicator.Communicator.SendToString(FieldData, ret) = False Then
            Return False
        Else
            If ret <> Nothing Then
                If DataParsing(ret, retData) = False Then
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Public Function ErrorResponse(ByVal addr As Integer, ByVal retData As String) As Boolean
        Dim FieldData As String = Nothing
        Dim ret As String = Nothing

        FieldData = STX & addr & "NG" & ETX

        If communicator.Communicator.SendToString(FieldData, ret) = False Then
            Return False
        Else
            If ret <> Nothing Then
                If DataParsing(ret, retData) = False Then
                    Return False
                End If
            End If
        End If

        Return True
    End Function


#Region "Parser Function"

    Public Function ConvertMeasData(ByVal Res As String, ByRef ret As sParams) As Boolean
        Dim sRcvData() As String
        Dim TempInfo(1) As String
        Dim ConvertByte(1) As Byte

        'Res = "01RSD,OK,01F4,012C"
        sRcvData = Res.Split(",")

        If sRcvData Is Nothing Then Return False

        TempInfo(0) = sRcvData(sRcvData.Length - 2)
        TempInfo(1) = sRcvData(sRcvData.Length - 1)

        Try

            ConvertByte(0) = "&H" & TempInfo(0).Substring(0, 2)
            ConvertByte(1) = "&H" & TempInfo(0).Substring(2, 2)

            ret.measTemp = fConvertInt16Byte(ConvertByte)


            ConvertByte(0) = "&H" & TempInfo(1).Substring(0, 2)
            ConvertByte(1) = "&H" & TempInfo(1).Substring(2, 2)

            ret.setTemp = fConvertInt16Byte(ConvertByte)

            'ret.measTemp = ret.measTemp / 10   'PV
            'ret.setTemp = ret.setTemp / 10     'SP

        Catch ex As Exception

        End Try


        Return True
    End Function

    Public Function ConvertDReg(ByVal setData As String) As String
        Dim Reg() As Byte = Nothing
        Dim SetValue As String = Nothing

        'setData = setData * 10

        Reg = fConvertByteInt16(setData)

        For i As Integer = 0 To Reg.Length - 1
            If Reg(i).ToString.Length = 1 Then
                SetValue = SetValue & "0" & Reg(i)
            Else
                If Hex(Reg(i)).Length = 1 Then
                    SetValue = SetValue & "0" & Hex(Reg(i))
                Else
                    SetValue = SetValue & Hex(Reg(i))
                End If
            End If

        Next

        Return SetValue
    End Function

    Public Function ConvertDataNum(ByVal setData As String) As String
        Dim Reg As Byte = Nothing
        Dim SetValue As String = Nothing

        Reg = fConvertByteInt8(setData)


        If Reg.ToString.Length = 1 Then
            SetValue = SetValue & "0" & Reg
        Else
            If Hex(Reg).Length = 1 Then
                SetValue = SetValue & "0" & Hex(Reg)
            Else
                SetValue = SetValue & Hex(Reg)
            End If
        End If


        Return SetValue
    End Function

    Public Function DataParsing(ByVal Res As String, ByRef ret As String) As Boolean
        Dim sRcvData() As String
        Dim TempInfo(1) As String


        Res = "01RSD,OK,01F4,012C "
        sRcvData = Res.Split(",")

        TempInfo(0) = sRcvData(2)
        TempInfo(1) = sRcvData(3)


        Dim ConvertByte(1) As Byte

        ConvertByte(0) = &H1
        ConvertByte(1) = &H2C


        fConvertInt16Byte(ConvertByte)


        fConvertByteInt16(300)

        Return True

    End Function

    Public Function DataParsing(ByVal Res() As String) As Boolean

        Return True
    End Function

    Public Function ErrCheck(ByVal Res As String) As Boolean
        Dim CmdBuff() As String

        CmdBuff = Res.Split(",")

        If CmdBuff(1).Substring(0, 2) <> "OK" Then
            Return False
        End If

        Return True
    End Function

    Public Function CheckSum(ByVal str As String) As Byte
        Dim SumData As Integer

        For idx As Integer = 0 To str.ToString.Length - 1
            SumData = SumData + Asc(str.Substring(idx, 1))
        Next
        Dim bBuff() As Byte = fConvertByteInt16(SumData)

        Return bBuff(1)
    End Function

#End Region

#Region "Convert Function"
    Private Function fConvertInt16Byte(ByVal inValueArr() As Byte) As Int16
        Dim bVal(1) As Byte

        Dim convertedValue As CUnitCommonNode.SplitUINT16

        convertedValue.ByteData_L = inValueArr(1)
        convertedValue.ByteData_H = inValueArr(0)

        Return convertedValue.UINT16_Data
    End Function


    Public Function fConvertByteInt16(ByVal inValue As Int16) As Byte()
        Dim bVal(1) As Byte

        Dim convertedValue As CUnitCommonNode.SplitUINT16
        convertedValue.UINT16_Data = inValue


        bVal(1) = (convertedValue.ByteData_L)
        bVal(0) = (convertedValue.ByteData_H)

        Return bVal
    End Function

    Private Function fConvertInt8Byte(ByVal inValue As Byte) As Integer


        Dim bVal As Integer



        Dim convertedValue As CUnitCommonNode.SplitUINT8
        convertedValue.ByteData = inValue


        bVal = convertedValue.UINT8_Data



        Return bVal
    End Function

    Private Function fConvertByteInt8(ByVal inValue As Integer) As Byte
        Dim bVal As Byte

        Dim convertedValue As CUnitCommonNode.SplitUINT8
        convertedValue.UINT8_Data = inValue


        bVal = (convertedValue.ByteData)

        Return bVal
    End Function
#End Region





#Region "Set/Get"

    Public Overrides Function SetTemperature(ByVal addr As Integer, ByVal TempData As Double) As eReturnCode
        Dim FieldData As String = Nothing
        Dim SetValue As String = Nothing
        Dim ret As String = Nothing
        Dim retData As String = CStr(TempData)

        If retData Is Nothing = False Then

            FieldData = ConvertDataNum(addr) & "WSD" & COMMA & ConvertDataNum(1) & COMMA & SP1 & COMMA


            retData = retData * 10
            SetValue = ConvertDReg(retData)

            FieldData = FieldData & SetValue

            'If idx <> SetValue.Length - 1 Then
            '    FieldData = FieldData & SetValue & COMMA
            'Else
            '    FieldData = FieldData & SetValue
            'End If

            FieldData = STX & FieldData & Hex(CheckSum(FieldData)) & ETX
            'FieldData = STX & addr & "WSD" & COMMA & "02" & COMMA & "0201" & COMMA & SetValue & ETX

            If communicator.Communicator.SendToString(FieldData, ret) = False Then
                Return False
            Else
                If ret <> Nothing Then
                    If ErrCheck(ret) = True Then
                        Return True
                    Else
                        Return False
                    End If

                End If
            End If
        Else
            Return False
        End If

        Return True
    End Function

    Public Overrides Function SetTemperature(ByVal addr As Integer, ByVal DataNum As Integer, ByVal retData As String) As eReturnCode
        Dim FieldData As String = Nothing
        Dim SetValue As String = Nothing
        Dim ret As String = Nothing


        If retData Is Nothing = False Then

            FieldData = ConvertDataNum(addr) & "WSD" & COMMA & ConvertDataNum(DataNum) & COMMA & SP1 & COMMA


            retData = retData * 10
            SetValue = ConvertDReg(retData)

            FieldData = FieldData & SetValue

            'If idx <> SetValue.Length - 1 Then
            '    FieldData = FieldData & SetValue & COMMA
            'Else
            '    FieldData = FieldData & SetValue
            'End If

            FieldData = STX & FieldData & Hex(CheckSum(FieldData)) & ETX
            'FieldData = STX & addr & "WSD" & COMMA & "02" & COMMA & "0201" & COMMA & SetValue & ETX

            If communicator.Communicator.SendToString(FieldData, ret) = False Then
                Return False
            Else
                If ret <> Nothing Then
                    If ErrCheck(ret) = True Then
                        Return True
                    Else
                        Return False
                    End If

                End If
            End If
        Else
            Return False
        End If

        Return True
    End Function


    Public Overrides Function GetTemperature(ByVal addr As Integer, ByRef retData As sParams) As eReturnCode
        Dim FieldData As String = Nothing
        Dim ret As String = Nothing
        Dim sRetData As sParams = Nothing


        FieldData = ConvertDataNum(addr) & "RSD" & COMMA & "02" & COMMA & NPV

        FieldData = STX & FieldData & Hex(CheckSum(FieldData)) & ETX

        'FieldData = STX & addr & "RSD" & COMMA & "02" & COMMA & "0001" & ETX

        If communicator.Communicator.SendToString(FieldData, ret) = False Then
            Return False
        Else
            If ret <> Nothing Then
                If ConvertMeasData(ret, sRetData) = False Then
                    Return False
                End If
            End If
        End If

        retData.measTemp = sRetData.measTemp / 10   'PV
        retData.setTemp = sRetData.setTemp / 10     'SP

        Return True
    End Function

#End Region
#End Region
End Class
