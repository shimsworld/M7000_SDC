Imports System
Imports System.IO
Imports System.Threading
Imports CCommLib
Imports System.Windows.Forms

Public Class CDevK23x
    Inherits CDevSMUCommonNode

#Region "Define"

    ' Dim m_sDevInfo As String
    ' Dim m_nAddress As Integer
    '  Dim m_Config As CComCommonNode.sCommInfo
    Dim communicator As CComAPI
    Dim m_KeithleyInfos As ucKeithleySMUSettings.sKeithley
    Dim m_DeviceRange As sRangeAndIntegTime
    ' Private sRange() As String = New String() {"Auto", "1nA", "10nA", "100nA", "1uA", "10uA", "100uA", "1mA", "10mA", "100mA", "1A"}

    Private sCurrentRangeName_K236() As String = New String() {"Auto", "1nA", "10nA", "100nA", "1uA", "10uA", "100uA", "1mA", "10mA", "100mA"}
    Private dCurrentRangeValue_K236() As Double = New Double() {0, 1 * 10 ^ -9, 10 * 10 ^ -9, 100 * 10 ^ -9, 1 * 10 ^ -6, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 10 * 10 ^ -3, 100 * 10 ^ -3}

    Private sVoltageRangeName_K236() As String = New String() {"Auto", "1.5V", "15V", "110V", "1100V"}
    Private dVoltageRangeValue_K236() As Double = New Double() {0, 1.5, 15, 110, 1100}

    Private sCurrentRangeName_K237() As String = New String() {"Auto", "1nA", "10nA", "100nA", "1uA", "10uA", "100uA", "1mA", "10mA", "100mA", "1A"}
    Private dCurrentRangeValue_K237() As Double = New Double() {0, 1 * 10 ^ -9, 10 * 10 ^ -9, 100 * 10 ^ -9, 1 * 10 ^ -6, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 10 * 10 ^ -3, 100 * 10 ^ -3, 1}

    Private sVoltageRangeName_K237() As String = New String() {"Auto", "1.5V", "15V", "110V"}
    Private dVoltageRangeValue_K237() As Double = New Double() {0, 1.5, 15, 110}


    Private sCurrentRangeName_K238() As String = New String() {"Auto", "1nA", "10nA", "100nA", "1uA", "10uA", "100uA", "1mA", "10mA", "100mA", "1A"}
    Private dCurrentRangeValue_K238() As Double = New Double() {0, 1 * 10 ^ -9, 10 * 10 ^ -9, 100 * 10 ^ -9, 1 * 10 ^ -6, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 10 * 10 ^ -3, 100 * 10 ^ -3, 1}

    Private sVoltageRangeName_K238() As String = New String() {"Auto", "1.5V", "15V", "110V"}
    Private dVoltageRangeValue_K238() As Double = New Double() {0, 1.5, 15, 110}

    Private sIntegTime() As String = New String() {"416uSec", "4mSec", "16.67mSec", "20mSec"}
    Private sIntegTimeCommand() As String = New String() {"S0", "S1", "S2", "S3"}  ' Manual 확인 필요 설정 값이 Command어떻게 보내는지

    Private sSourceModeName() As String = New String() {"Current", "Voltage"}
    Private Const MEASURE_DATA = 5
    Private Const MEASURE_TIME = 1


 


#Region "Enum"

    Public Enum eSMUMode
        eCurrent
        eVoltage
    End Enum
    Public Enum eTerminal
        eRear
        eFront
    End Enum
    Public Enum eWireMode
        e2Wire
        e4Wire
    End Enum
    Public Enum eIntegTime
        e416uSec
        e4mSec
        e16_67mSec
        e20mSec
    End Enum

    Public Enum eItem
        eSource
        eDelay
        eMeasure
        eTime
    End Enum

    Public Enum eDevice
        K236
        K237
        K238
    End Enum

#End Region

#End Region

#Region "Propertys"

    Public WriteOnly Property SetKeithleyInfos() As ucKeithleySMUSettings.sKeithley
        Set(ByVal value As ucKeithleySMUSettings.sKeithley)
            m_KeithleyInfos = value
        End Set
    End Property

  
#End Region

#Region "Creator, Disposer, Init"

    Public Sub New(ByVal devType As eDevice)
        MyBase.New()
        m_MyModel = devType

           Select m_MyModel

            Case eModel.KEITHLEY_K236
                m_DeviceRange.sCurrentListName = sCurrentRangeName_K236.Clone
                m_DeviceRange.sVoltageListName = sVoltageRangeName_K236.Clone
                m_DeviceRange.dCurrentListValue = dCurrentRangeValue_K236.Clone
                m_DeviceRange.dVoltageListValue = dVoltageRangeValue_K236.Clone
                m_DeviceRange.sIntegTimeListName = sIntegTime.Clone

            Case eModel.KEITHLEY_K237
                m_DeviceRange.sCurrentListName = sCurrentRangeName_K237.Clone
                m_DeviceRange.sVoltageListName = sVoltageRangeName_K237.Clone
                m_DeviceRange.dCurrentListValue = dCurrentRangeValue_K237.Clone
                m_DeviceRange.dVoltageListValue = dVoltageRangeValue_K237.Clone
                m_DeviceRange.sIntegTimeListName = sIntegTime.Clone

            Case eModel.kEITHLEY_K238
                m_DeviceRange.sCurrentListName = sCurrentRangeName_K238.Clone
                m_DeviceRange.sVoltageListName = sVoltageRangeName_K238.Clone
                m_DeviceRange.dCurrentListValue = dCurrentRangeValue_K238.Clone
                m_DeviceRange.dVoltageListValue = dVoltageRangeValue_K238.Clone
                m_DeviceRange.sIntegTimeListName = sIntegTime.Clone
        End Select

        m_DeviceRange.sSourceModeName = sSourceModeName.Clone
    End Sub

#End Region

#Region "Communication"

    Public Overrides Function Connection(ByVal Config As CComCommonNode.sCommInfo) As Boolean
        m_bIsConnected = False
        m_ConfigInfo = Config
        communicator = New CComAPI(m_ConfigInfo.commType)
        Dim sIDNInfos As String = Nothing
        If communicator.Communicator.Connect(m_ConfigInfo) <> CComCommonNode.eReturnCode.OK Then
            MsgBox(communicator.Communicator.StateMessage)
            Return False
        End If

        If IDN(sIDNInfos) = False Then Return False

        m_bIsConnected = True
        Return True
    End Function

    Public Overrides Sub Disconnection()
        '     If m_bIsConnected = True Then
        communicator.Communicator.Disconnect()
        '  End If
        m_bIsConnected = False
    End Sub

#End Region


#Region "API Functions"

    Public Overrides Sub GetRangeList(ByRef range As CDevSMUCommonNode.sRangeAndIntegTime)
        range = m_DeviceRange
    End Sub

    Public Overrides Function InitializeSweep(ByVal settings As ucKeithleySMUSettings.sKeithley) As Boolean
        'Initialize Sequence
        m_KeithleyInfos = settings
        '1. Initialize Device
        If SetInit() = False Then Return False

        '2
        If Output(True) = False Then Return False

        Return True
    End Function

    Public Overrides Function SetBias(ByVal dBias As Double) As Boolean
        If SetValue(dBias) = False Then Return False
        Return True
    End Function

    Public Overrides Function OutputOn() As Boolean
        If Output(True) = False Then Return False
        Return True
    End Function

    Public Overrides Function OutputOff() As Boolean
        If Output(False) = False Then Return False
        Return True
    End Function

    Public Overrides Function Initializ(ByVal settings As ucKeithleySMUSettings.sKeithley) As Boolean
        'Initialize Sequence
        m_KeithleyInfos = settings
        If SetInit() = False Then Return False
        Return True
    End Function

    Public Overrides Function FinalizeSweep() As Boolean
        If SetBias(0) = False Then Return False
        If Output(False) = False Then Return False
        If Reset() = False Then Return False
        Return True
    End Function

    Public Overrides Function Measure(ByRef outVolt As Double, ByRef outCurrent As Double) As Boolean
        Dim sCommand As String = ""

        Dim sRcvData As String = Nothing

        Dim dSourcrData As Double
        Dim dMeasureData As Double



        If communicator.Communicator.SendToString("G1,0,0" & "X", sRcvData) <> CComCommonNode.eReturnCode.OK Then
            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)
            Thread.Sleep(500)
            Output(True)
            Thread.Sleep(500)
            If communicator.Communicator.SendToString("G1,0,0" & "X", sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If

        End If


        If Parse_K238(0, sRcvData, dSourcrData) = False Then Return False


        If communicator.Communicator.SendToString("G4,0,0" & "X", sRcvData) <> CComCommonNode.eReturnCode.OK Then
            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)
            Thread.Sleep(500)
            Output(True)
            Thread.Sleep(500)
            If communicator.Communicator.SendToString("G4,0,0" & "X", sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
        End If


        If Parse_K238(0, sRcvData, dMeasureData) = False Then Return False

        'Reset()
        'Thread.Sleep(500)
        '   communicator.Communicator.Disconnect()
        ' communicator.Communicator.Connect(m_ConfigInfo)
        '   communicator.Communicator.BufClear()

        '     Output(True)

            If m_KeithleyInfos.SourceMode = ucKeithleySMUSettings.eSMUMode.eCurrent Then
                outVolt = dMeasureData
                outCurrent = dSourcrData
            ElseIf m_KeithleyInfos.SourceMode = ucKeithleySMUSettings.eSMUMode.eVoltage Then
                outVolt = dSourcrData
                outCurrent = dMeasureData
            End If


            'Select Case m_KeithleyInfos.SourceMode
            '    Case eItem.eSource
            '        sCommand = "G1,0,0" & "X"

            '    Case eItem.eDelay
            '        sCommand = "G2,0,0" & "X"

            '    Case eItem.eMeasure
            '        sCommand = "G4,0,0" & "X"

            '    Case eItem.eTime
            '        sCommand = "G8,0,0" & "X"

            'End Select

        Return True
    End Function

    Public Overrides Function IDN(ByRef strInfo As String) As Boolean
        Dim sCommand As String = "U0"
        Dim sRcvData As String = ""
        Dim sModel As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If

        End If

        If sRcvData = "" Then Return False

        'Select Case Model
        '    Case eModel.KEITHLEY_K236
        '        sModel = "236"
        '    Case eModel.kEITHLEY_K238
        '        sModel = "238"
        'End Select

        'If sRcvData.Contains(sModel) = False Then Return False
        strInfo = sRcvData
        Return True
    End Function
#End Region

#Region "Test Command"

    Public Function TESTCommand(ByVal sCommand As String) As Boolean

        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function

    Public Function TESTCommandQur(ByVal sCommand As String, ByRef sRcvData As String) As Boolean

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function

#End Region

#Region "Function"


    Public Function Reset() As Boolean
        Dim sCommand As String = "*RST"

        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)
            If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If

        End If

        communicator.Communicator.Disconnect()
        communicator.Communicator.Connect(m_ConfigInfo)

        Return True
    End Function

    Public Function Output(ByVal bOnOff As Boolean) As Boolean
        Dim sCommand As String = ""

        If bOnOff = True Then
            sCommand = "N1" & "X"
        Else
            sCommand = "N0" & "X"
        End If

        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then

            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)
            If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
        End If

        Return True
    End Function

    Public Function SetOutputSense(ByVal bOnOff As Boolean) As Boolean
        Dim sCommand As String = ""

        If bOnOff = True Then
            sCommand = "O0" + "X"
        Else
            sCommand = "O1" & "X"
        End If

        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)

            If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If

        End If


        Return True
    End Function

    Public Function SetCompliance(ByVal sCompLevel As String) As Boolean

        If communicator.Communicator.SendToString("L" + sCompLevel + "," + "0" + "X") <> CComCommonNode.eReturnCode.OK Then
            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)

            If communicator.Communicator.SendToString("L" + sCompLevel + "," + "0" + "X") <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
        End If


        Return True
    End Function

    Public Function SetNPLC(ByVal nIntegIndex As eIntegTime) As Boolean
        Dim sRcvData As String = Nothing

        'If communicator.Communicator.SendToString("S2" + "X", sRcvData) <> CComCommonNode.eReturnCode.OK Then
        If communicator.Communicator.SendToString(sIntegTimeCommand(nIntegIndex) + "X", sRcvData) <> CComCommonNode.eReturnCode.OK Then
            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)
            If communicator.Communicator.SendToString(sIntegTimeCommand(nIntegIndex) + "X", sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
        End If

        Return True

    End Function

    Public Function SetBiasMode() As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""
        Select Case m_KeithleyInfos.SourceMode
            Case eSMUMode.eCurrent
                sCommand = "F1" & "," & "0" & "X"
            Case eSMUMode.eVoltage
                sCommand = "F0" & "," & "0" & "X"
        End Select

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
        End If

        Return True

    End Function

    Public Function SetTriggerDisable() As Boolean

        If communicator.Communicator.SendToString("R0" + "X") <> CComCommonNode.eReturnCode.OK Then
            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)
            If communicator.Communicator.SendToString("R0" + "X") <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
        End If

        Return True
    End Function

    Public Function SetTriggerEnable() As Boolean

        If communicator.Communicator.SendToString("R1" + "X") <> CComCommonNode.eReturnCode.OK Then
            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)
            If communicator.Communicator.SendToString("R1" + "X") <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
        End If

        If communicator.Communicator.SendToString("T0,0,0,1" + "X") <> CComCommonNode.eReturnCode.OK Then
            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)
            If communicator.Communicator.SendToString("T0,0,0,1" + "X") <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
        End If


        Return True

    End Function

    Public Function SetValue(ByVal In_sValue As Double) As Boolean

        Dim strValue As String
        Dim strRange As String = ""
        '    Dim SrCVdATA As String = ""

        strValue = CStr(In_sValue)

        If m_KeithleyInfos.VoltageAutoRange = True Then
            strRange = "0"
        Else
            'Range 맞게 값을 설정 해야 함.
            strRange = CStr(m_KeithleyInfos.nVoltageRangeIndex)
        End If
        'communicator.Communicator.Disconnect()
        'communicator.Communicator.Connect(m_ConfigInfo)

        If communicator.Communicator.SendToString("B" & strValue & "," & strRange & "," + CStr(m_KeithleyInfos.SourceDelay_Sec) & "X") <> CComCommonNode.eReturnCode.OK Then
            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)
            If communicator.Communicator.SendToString("B" & strValue & "," & strRange & "," + CStr(m_KeithleyInfos.SourceDelay_Sec) & "X") <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
        End If
        Thread.Sleep(100)

        ' Bias 셋팅 후, 통신 재 연결 해야 설정 값이 적용됨.

        communicator.Communicator.Disconnect()
        communicator.Communicator.Connect(m_ConfigInfo)

        Output(True)
        Return True

    End Function

    Public Function SetIntegTime(ByVal mode As eIntegTime) As Boolean
        Dim sCommand As String = ""

        Select Case mode
            Case eIntegTime.e416uSec
                sCommand = "S0" & "X"
            Case eIntegTime.e4mSec
                sCommand = "S1" & "X"
            Case eIntegTime.e16_67mSec
                sCommand = "S2" & "X"
            Case eIntegTime.e20mSec
                sCommand = "S3" & "X"
        End Select

        If communicator.Communicator.SendToString("S2" + "X") <> CComCommonNode.eReturnCode.OK Then

            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)
            If communicator.Communicator.SendToString("S2" + "X") <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
        End If

        Return True
    End Function

    Public Function SetInit() As Boolean
        Dim sCommand As String = ""
        Dim nTimeOutCnt As Integer = 0
        Dim mode As eSMUMode
        '     Reset()
        'communicator.Communicator.Disconnect()
        'communicator.Communicator.Connect(m_ConfigInfo)
        ' Thread.Sleep(2000)
        '터미널 모드 추가
        Application.DoEvents()
        Thread.Sleep(100)

        With m_KeithleyInfos


            'Bias, Range, SourceDelay 셋팅 부분이라 Bias는 0으로 처리
            If SetValue(0) = False Then Return False

            'communicator.Communicator.Disconnect()
            'communicator.Communicator.Connect(m_ConfigInfo)
            'If Reset() = False Then Return False

            Select Case .SourceMode
                Case eSMUMode.eCurrent


                    Do

                        Application.DoEvents()
                        Thread.Sleep(100)

                        sCommand = "F1" & "," & "0" & "X"
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                            Return False
                        End If

                        If GetSMUMode(mode) = True Then
                            If mode = eSMUMode.eCurrent Then
                                Exit Do
                            End If
                        End If

                        If nTimeOutCnt > 10 Then
                            Return False
                        End If

                        nTimeOutCnt += 1
                    Loop

                  



                    'sCommand = "F1" & "," & "0" & "X"
                    'If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                    Application.DoEvents()
                    Thread.Sleep(100)


                    sCommand = "L" & CStr(.LimitVoltage) + "," & "0" & "X"
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                        communicator.Communicator.Disconnect()
                        communicator.Communicator.Connect(m_ConfigInfo)
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                            Return False
                        End If
                    End If



                Case eSMUMode.eVoltage



                    Do

                        Application.DoEvents()
                        Thread.Sleep(100)

                        sCommand = "F0" & "," & "0" & "X"
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                            Return False
                        End If

                        If GetSMUMode(mode) = True Then
                            If mode = eSMUMode.eVoltage Then
                                Exit Do
                            End If
                        End If

                        If nTimeOutCnt > 10 Then
                            Return False
                        End If

                        nTimeOutCnt += 1
                    Loop


                    'sCommand = "F0" & "," & "0" & "X"
                    'If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                    '    communicator.Communicator.Disconnect()
                    '    communicator.Communicator.Connect(m_ConfigInfo)
                    '    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                    '        Return False
                    '    End If
                    'End If

                    'sCommand = "F0" & "," & "0" & "X"
                    'If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                    Application.DoEvents()
                    Thread.Sleep(100)

                    sCommand = "L" & CStr(.LimitCurrent) + "," & "0" & "X"
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                        communicator.Communicator.Disconnect()
                        communicator.Communicator.Connect(m_ConfigInfo)
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                            Return False
                        End If
                    End If

            End Select

            If m_MyModel <> eModel.KEITHLEY_K236 And m_MyModel <> eModel.KEITHLEY_K237 And m_MyModel <> eModel.kEITHLEY_K238 Then
                If SetNPLC(m_KeithleyInfos.nIntegTimeIndex) = False Then Return False
            End If
            Output(False)

            'communicator.Communicator.Disconnect()
            'communicator.Communicator.Connect(m_ConfigInfo)
            'Bias, Range, SourceDelay 셋팅 부분이라 Bias는 0으로 처리
            ' If SetValue(0) = False Then Return False

            'NPLC셋팅


            Return True
        End With

    End Function

    Private Function Parse_K238(ByVal mode As eItem, ByVal sData As String, ByRef sOutData As Double) As Boolean
        Dim buff As String
        Dim arrTemp As Array

        Try
            arrTemp = Split(sData, ",", -1)

            buff = arrTemp(0)

            If mode = eItem.eSource Or mode = eItem.eMeasure Then
                buff = buff.Substring(MEASURE_DATA, buff.Length - MEASURE_DATA)
            ElseIf mode = eItem.eDelay Or mode = eItem.eTime Then
                buff = buff.Substring(MEASURE_TIME, buff.Length - MEASURE_TIME)
            End If

            sOutData = CDbl(buff)
        Catch ex As Exception
            Return False
        End Try


        Return True
    End Function

    Public Overrides Function test() As Boolean
        Dim sCommand As String = "U3"
        Dim sRcvData As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            communicator.Communicator.Disconnect()
            communicator.Communicator.Connect(m_ConfigInfo)
            If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If

        End If


        If sRcvData = "" Then Return False

        Return True
    End Function


    Private Function GetSMUMode(ByRef mode As eSMUMode) As Boolean
        Dim sCommand As String = "U3"
        Dim sRcvData As String = ""
        Dim sMode As String

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        If sRcvData = "" Then Return False

        If sRcvData.Length < 5 Then Return False
        sMode = sRcvData.Substring(0, 5)

        Select Case sMode

            Case "NSDCV"
                mode = eSMUMode.eVoltage
            Case "NSDCI"
                mode = eSMUMode.eCurrent
            Case Else
                Return False
        End Select

        Return True
    End Function
#End Region
End Class
