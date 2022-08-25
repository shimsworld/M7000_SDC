Imports System.IO.Ports
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib

Public Class CDevK24xx
    Inherits CDevSMUCommonNode

    Dim communicator As CComAPI '= New CComAPI(CComCommonNode.eCommType.eSerial)
    Dim m_KeithleyInfos As ucKeithleySMUSettings.sKeithley

#Region "Define Global Variable"
    '  Dim m_DeviceNumber As eDevice
    Dim m_DeviceRange As sRangeAndIntegTime

    Private sCurrentRangeName_K2400() As String = New String() {"Auto", "1uA", "10uA", "100uA", "1mA", "10mA", "100mA", "1A"}
    Private sVoltageRangeName_K2400() As String = New String() {"Auto", "200mA", "2V", "20V", "200V"}
    Private dCurrentRangeValue_K2400() As Double = New Double() {0, 1 * 10 ^ -6, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 10 * 10 ^ -3, 100 * 10 ^ -3, 1}
    Private dVoltageRangeValue_K2400() As Double = New Double() {0, 0.2, 2, 20, 200}

    Private sCurrentRangeName_K2410() As String = New String() {"Auto", "1uA", "10uA", "100uA", "1mA", "20mA", "100mA", "1A"}
    Private sVoltageRangeName_K2410() As String = New String() {"Auto", "200mA", "2V", "20V", "1000V"}
    Private dCurrentRangeValue_K2410() As Double = New Double() {0, 1 * 10 ^ -6, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 20 * 10 ^ -3, 100 * 10 ^ -3, 1}
    Private dVoltageRangeValue_K2410() As Double = New Double() {0, 0.2, 2, 20, 1000}

    Private sCurrentRangeName_K2420() As String = New String() {"Auto", "10uA", "100uA", "1mA", "10mA", "100mA", "1A", "3A"}
    Private sVoltageRangeName_K2420() As String = New String() {"Auto", "200mV", "2V", "20V", "60V"}
    Private dCurrentRangeValue_K2420() As Double = New Double() {0, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 10 * 10 ^ -3, 100 * 10 ^ -3, 1, 3}
    Private dVoltageRangeValue_K2420() As Double = New Double() {0, 0.2, 2, 20, 60}

    Private sCurrentRangeName_K2425() As String = New String() {"Auto", "10uA", "100uA", "1mA", "10mA", "100mA", "1A", "3A"}
    Private sVoltageRangeName_K2425() As String = New String() {"Auto", "200mV", "2V", "20V", "100V"}
    Private dCurrentRangeValue_K2425() As Double = New Double() {0, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 10 * 10 ^ -3, 100 * 10 ^ -3, 1, 3}
    Private dVoltageRangeValue_K2425() As Double = New Double() {0, 0.2, 2, 20, 100}

    Private sCurrentRangeName_K2430() As String = New String() {"Auto", "10uA", "100uA", "1mA", "10mA", "100mA", "1A", "3A", "10A"}
    Private sVoltageRangeName_K2430() As String = New String() {"Auto", "200mV", "2V", "20V", "100V"}
    Private dCurrentRangeValue_K2430() As Double = New Double() {0, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 10 * 10 ^ -3, 100 * 10 ^ -3, 1, 3, 10}
    Private dVoltageRangeValue_K2430() As Double = New Double() {0, 0.2, 2, 20, 100}

    Private sCurrentRangeName_K2440() As String = New String() {"Auto", "10uA", "100uA", "1mA", "10mA", "100mA", "1A", "5A"}
    Private sVoltageRangeName_K2440() As String = New String() {"Auto", "200mV", "2V", "10V", "40V"}
    Private dCurrentRangeValue_K2440() As Double = New Double() {0, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 10 * 10 ^ -3, 100 * 10 ^ -3, 1, 5}
    Private dVoltageRangeValue_K2440() As Double = New Double() {0, 0.2, 2, 10, 40}

    Private sCurrentRangeName_K2450() As String = New String() {"Auto", "1uA", "10uA", "100uA", "1mA", "10mA", "100mA", "1A"}
    Private sVoltageRangeName_K2450() As String = New String() {"Auto", "20mV", "200mV", "2V", "20V", "200V"}
    Private dCurrentRangeValue_K2450() As Double = New Double() {0, 1 * 10 ^ -6, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 10 * 10 ^ -3, 100 * 10 ^ -3, 1}
    Private dVoltageRangeValue_K2450() As Double = New Double() {0, 0.02, 0.2, 2, 20, 200}

    Private sSourceModeName() As String = New String() {"Current", "Voltage"}

    'Public Enum eTransferState
    '    eReady
    '    eTransferingData
    '    eReciveFail_TimeOut
    '    eReciveComplete
    '    eReciveFail_NoData
    'End Enum
    '
    'Private g_eRS232Status As eTransferState
#End Region

#Region "Structure"
  
#End Region

#Region "Enum"
    Public Enum eSMUMode
        eCurrent
        eVoltage
        ePulseCurrent
        ePulseVoltage
    End Enum

    Public Enum eTerminal
        eRear
        eFront
    End Enum

    Public Enum eMeasValue
        eCurrent
        eVoltage
        ePower
        eResistance
    End Enum

    Public Enum eProve
        e2Prove
        e4Prove
    End Enum

    'Public Enum eDevice
    '    K2400
    '    K2410
    '    K2420
    '    K2425
    '    K2430
    '    K2440
    '    K2450
    'End Enum

    Public Enum eOffState 'Off-State ADD- YSH - 2014-09-29
        eNORMal = 0
        eHighIMPedance
        eZERO
        eGUARd
    End Enum

#End Region

#Region "Properties"
    'Public WriteOnly Property SetKeithleyInfos() As ucKeithleySMUSettings.sKeithley
    '    Set(ByVal value As ucKeithleySMUSettings.sKeithley)
    '        m_KeithleyInfos = value
    '    End Set
    'End Property

#End Region

#Region "Creator, Disposer, Init"

    Public Sub New(ByVal devType As CDevSMUCommonNode.eModel)
        MyBase.New()
        m_MyModel = devType
        ' m_DeviceNumber = devType

        Select Case m_MyModel
            Case eModel.KEITHLEY_K2400
                m_DeviceRange.sCurrentListName = sCurrentRangeName_K2400.Clone
                m_DeviceRange.sVoltageListName = sVoltageRangeName_K2400.Clone
                m_DeviceRange.dCurrentListValue = dCurrentRangeValue_K2400.Clone
                m_DeviceRange.dVoltageListValue = dVoltageRangeValue_K2400.Clone
            Case eModel.KEITHLEY_K2410
                m_DeviceRange.sCurrentListName = sCurrentRangeName_K2410.Clone
                m_DeviceRange.sVoltageListName = sVoltageRangeName_K2410.Clone
                m_DeviceRange.dCurrentListValue = dCurrentRangeValue_K2410.Clone
                m_DeviceRange.dVoltageListValue = dVoltageRangeValue_K2410.Clone
            Case eModel.KEITHLEY_K2420
                m_DeviceRange.sCurrentListName = sCurrentRangeName_K2420.Clone
                m_DeviceRange.sVoltageListName = sVoltageRangeName_K2420.Clone
                m_DeviceRange.dCurrentListValue = dCurrentRangeValue_K2420.Clone
                m_DeviceRange.dVoltageListValue = dVoltageRangeValue_K2420.Clone
            Case eModel.KEITHLEY_K2425
                m_DeviceRange.sCurrentListName = sCurrentRangeName_K2425.Clone
                m_DeviceRange.sVoltageListName = sVoltageRangeName_K2425.Clone
                m_DeviceRange.dCurrentListValue = dCurrentRangeValue_K2425.Clone
                m_DeviceRange.dVoltageListValue = dVoltageRangeValue_K2425.Clone
            Case eModel.KEITHLEY_K2430
                m_DeviceRange.sCurrentListName = sCurrentRangeName_K2430.Clone
                m_DeviceRange.sVoltageListName = sVoltageRangeName_K2430.Clone
                m_DeviceRange.dCurrentListValue = dCurrentRangeValue_K2430.Clone
                m_DeviceRange.dVoltageListValue = dVoltageRangeValue_K2430.Clone
            Case eModel.KEITHLEY_K2440
                m_DeviceRange.sCurrentListName = sCurrentRangeName_K2440.Clone
                m_DeviceRange.sVoltageListName = sVoltageRangeName_K2440.Clone
                m_DeviceRange.dCurrentListValue = dCurrentRangeValue_K2440.Clone
                m_DeviceRange.dVoltageListValue = dVoltageRangeValue_K2440.Clone
            Case eModel.KEITHLEY_K2450
                m_DeviceRange.sCurrentListName = sCurrentRangeName_K2450.Clone
                m_DeviceRange.sVoltageListName = sVoltageRangeName_K2450.Clone
                m_DeviceRange.dCurrentListValue = dCurrentRangeValue_K2450.Clone
                m_DeviceRange.dVoltageListValue = dVoltageRangeValue_K2450.Clone
        End Select
        m_DeviceRange.sSourceModeName = sSourceModeName.Clone
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

        '2 K2410 Off-State Stting  - YSH -2014-09-29
        If m_MyModel = eModel.KEITHLEY_K2410 Then
            If SetOutput_OffState(eOffState.eNORMal) = False Then Return False
        End If

        '3 Cell On
        If Output(True) = False Then Return False

        Return True

    End Function

    Public Overrides Function SetBias(ByVal dBias As Double) As Boolean
        If SetBiasLevel(dBias) = False Then Return False
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
        If Output(False) = False Then Return False
        Thread.Sleep(100)
        If Reset() = False Then Return False

        If m_MyModel = eModel.KEITHLEY_K2410 Then
            If SetOutput_OffState(eOffState.eNORMal) = False Then Return False 'Off state add - YSH -2014-09-29
        End If

        Return True
    End Function

    Public Overrides Function Measure(ByRef outVolt As Double, ByRef outCurrent As Double) As Boolean

        If ClearBuffer() = False Then Return False

        Select Case m_MyModel
            Case eModel.KEITHLEY_K2400 To eModel.KEITHLEY_K2440
                If MeasData_K2400(outVolt, outCurrent) = False Then Return False
            Case eModel.KEITHLEY_K2450
                If MeasData_K2450(outVolt, outCurrent) = False Then Return False
        End Select

        Return True

    End Function

    Public Overrides Function IDN(ByRef strInfo As String) As Boolean
        Dim sCommand As String = "*IDN?"
        Dim sRcvData As String = ""
        Dim sModel As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        If sRcvData = "" Then Return False

        Select Case Model
            Case eModel.KEITHLEY_K2400
                sModel = "2400"
            Case eModel.KEITHLEY_K2410
                sModel = "2410"
            Case eModel.KEITHLEY_K2420
                sModel = "2420"
            Case eModel.KEITHLEY_K2425
                sModel = "2425"
            Case eModel.KEITHLEY_K2430
                sModel = "2430"
            Case eModel.KEITHLEY_K2440
                sModel = "2440"
            Case eModel.KEITHLEY_K2450
                sModel = "2450"
        End Select

        If sRcvData.Contains(sModel) = False Then Return False

        strInfo = sRcvData
        Return True
    End Function
#End Region




#Region "Communication"

    Public Overrides Function Connection(ByVal Config As CComCommonNode.sCommInfo) As Boolean
        Dim sInfo As String = ""
        m_bIsConnected = False
        m_ConfigInfo = Config
        communicator = New CComAPI(m_ConfigInfo.commType)

        If communicator.Communicator.Connect(m_ConfigInfo) <> CComCommonNode.eReturnCode.OK Then
            MsgBox(communicator.Communicator.StateMessage)
            Return False
        End If

        If IDN(sInfo) = False Then Return False

        m_bIsConnected = True
        Return True
    End Function


    Public Overrides Sub Disconnection()
        '   If m_bIsConnected = True Then

        communicator.Communicator.Disconnect()
        '   End If
        m_bIsConnected = False
    End Sub

#End Region

#Region "Function"


    Public Function Reset() As Boolean
        Dim sCommand As String = "*RST"

        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
        Return True
    End Function

    Public Function Output(ByVal bOnOff As Boolean) As Boolean
        Dim sCommand As String = ""

        Select Case m_MyModel
            Case eModel.KEITHLEY_K2400 To eModel.KEITHLEY_K2440
                If bOnOff = True Then
                    sCommand = ":OUTPUT:STATE ON"
                Else
                    sCommand = ":OUTPUT:STATE OFF"
                End If
            Case eModel.KEITHLEY_K2450
                If bOnOff = True Then
                    sCommand = ":OUTP ON"
                Else
                    sCommand = ":OUTP OFF"
                End If
        End Select

        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function

    Public Function SetBiasLevel(ByVal dBias As Double) As Boolean
        Dim sCommand As String = ""

        Select Case m_KeithleyInfos.SourceMode
            Case eSMUMode.eCurrent
                sCommand = ":SOURCE:CURRENT " & CStr(dBias)
            Case eSMUMode.eVoltage
                sCommand = ":SOURCE:VOLTAGE " & CStr(dBias)
        End Select

        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
        Return True
    End Function

    Public Function MeasData_K2400(ByRef outVolt As Double, ByRef outCurrent As Double) As Boolean
        Dim sRcvData As String = ""
        Dim sCommand As String = "READ?"
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        If sRcvData = "" Then Return False

        If Parse_K2400(sRcvData, outVolt, outCurrent) = False Then Return False

        Return True
    End Function

    Public Function MeasData_K2450(ByRef outVolt As Double, ByRef outCurrent As Double) As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""
        Dim strRange As String = ""

        sCommand = ":MEASure:Voltage?"
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CCommLib.CComCommonNode.eReturnCode.OK Then Return False

        If sRcvData = "" Then Return False
        outVolt = sRcvData

        sCommand = ":MEASure:Current?"
        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CCommLib.CComCommonNode.eReturnCode.OK Then Return False

        If sRcvData = "" Then Return False
        outCurrent = sRcvData
        Return True
    End Function

    Public Function ClearBuffer() As Boolean
        Dim sCommand As String = ":TRAC:CLE"
        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function

    Public Function SetTerminalMode(ByVal TerminalMode As ucKeithleySMUSettings.eTerminalMode) As Boolean
        Dim sCommand As String = ""

        If TerminalMode = ucKeithleySMUSettings.eTerminalMode.eFront Then
            sCommand = ":ROUte:TERMinals FRONT"
        ElseIf TerminalMode = ucKeithleySMUSettings.eTerminalMode.eRear Then
            sCommand = ":ROUte:TERMinals REAR"
        End If

        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function

    Public Function SetWireMode(ByVal WireMode As ucKeithleySMUSettings.eProve) As Boolean
        Dim sCommand As String = ""

        Select Case m_MyModel
            Case eModel.KEITHLEY_K2400 To eModel.KEITHLEY_K2440
                If WireMode = ucKeithleySMUSettings.eProve.e2Prove Then
                    sCommand = ":SYSTem:RSENse 0"
                ElseIf WireMode = ucKeithleySMUSettings.eProve.e4Prove Then
                    sCommand = ":SYSTem:RSENse 1"
                End If

            Case eModel.KEITHLEY_K2450
                If WireMode = ucKeithleySMUSettings.eProve.e2Prove Then
                    sCommand = "VOLT:RSEN OFF"
                ElseIf WireMode = ucKeithleySMUSettings.eProve.e4Prove Then
                    sCommand = "VOLT:RSEN ON"
                End If
        End Select

        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function

    Private Function SetMeasureMode() As Boolean
        Dim sCommand As String = ""

        With m_KeithleyInfos
            If .MeasureMode = ucKeithleySMUSettings.eMeasValue.eCurrent Then
                If .CurrentAutoRange = True Then
                    sCommand = ":SENSe:Current:RANGE:AUTO ON"
                Else
                    sCommand = ":SENSe:CURRent:RANGe:AUTO OFF"
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                    sCommand = ":SENS:CURR:RANG " & CStr(m_DeviceRange.dCurrentListValue(m_KeithleyInfos.nCurrentRangeIndex))
                End If
                If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            ElseIf .MeasureMode = ucKeithleySMUSettings.eMeasValue.eVoltage Then
                If .CurrentAutoRange = True Then
                    sCommand = ":SENSe:VOLTAGE:RANGE:AUTO ON"
                Else
                    sCommand = ":SENSe:VOLTAGE:RANGE:AUTO OFF"
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                    sCommand = ":SENS:VOLT:RANG " & CStr(m_DeviceRange.dVoltageListValue(m_KeithleyInfos.nVoltageRangeIndex))
                End If
                If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
            End If

        End With

        Return True
    End Function

    Private Function SetSourceMode() As Boolean
        Dim sCommand As String = ""

        With m_KeithleyInfos
            If .SourceMode = ucKeithleySMUSettings.eSMUMode.eCurrent Then

                Select Case m_MyModel
                    Case eModel.KEITHLEY_K2400 To eModel.KEITHLEY_K2440
                        sCommand = ":CONFigure:VOLTAGE"
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                        sCommand = ":SOURCE:FUNCtion CURRENT"
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                        sCommand = ":SOURCE:CURRENT:MODE FIX"
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                        sCommand = ":VOLTAGE:PROTECTION " & CStr(.LimitVoltage)
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                    Case eModel.KEITHLEY_K2450
                        sCommand = ":FUNC ""VOLTage"""
                        If communicator.Communicator.SendToString(sCommand) <> CCommLib.CComCommonNode.eReturnCode.OK Then Return False

                        sCommand = ":SOURCE:FUNCtion CURRENT"
                        If communicator.Communicator.SendToString(sCommand) <> CCommLib.CComCommonNode.eReturnCode.OK Then Return False

                        sCommand = ":SOURce:CURRent:VLIMit " & CStr(.LimitVoltage)
                        If communicator.Communicator.SendToString(sCommand) <> CCommLib.CComCommonNode.eReturnCode.OK Then Return False

                End Select

                If .CurrentAutoRange = True Then
                    sCommand = ":SOURCE:CURRent:RANGE:AUTO ON"
                Else
                    sCommand = ":SOURCE:CURRent:RANGE:AUTO OFF"
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                    sCommand = ":SOURce:CURRent:RANGe " & CStr(m_DeviceRange.dCurrentListValue(m_KeithleyInfos.nCurrentRangeIndex))
                End If

                If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False


            ElseIf .SourceMode = ucKeithleySMUSettings.eSMUMode.eVoltage Then
                Select Case m_MyModel
                    Case eModel.KEITHLEY_K2400 To eModel.KEITHLEY_K2440
                        sCommand = ":CONFigure:CURRENT"
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                        sCommand = ":SOURCE:FUNCtion VOLTAGE"
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                        sCommand = ":SOURCE:VOLTAGE:MODE FIX"
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                        sCommand = ":CURRENT:PROTECTION " & CStr(.LimitCurrent)
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                    Case eModel.KEITHLEY_K2450
                        sCommand = ":FUNC ""CURRent"""
                        If communicator.Communicator.SendToString(sCommand) <> CCommLib.CComCommonNode.eReturnCode.OK Then Return False

                        sCommand = ":SOURCE:FUNCtion VOLTAGE"
                        If communicator.Communicator.SendToString(sCommand) <> CCommLib.CComCommonNode.eReturnCode.OK Then Return False

                        sCommand = ":SOURce:VOLTage:ILIMit " & CStr(.LimitCurrent)
                        If communicator.Communicator.SendToString(sCommand) <> CCommLib.CComCommonNode.eReturnCode.OK Then Return False

                End Select

                If .VoltageAutoRange = True Then
                    sCommand = ":SOURCE:VOLTAGE:RANGE:AUTO ON"
                Else
                    sCommand = ":SOURCE:VOLTAGE:RANGE:AUTO OFF"
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                    sCommand = ":SOURce:VOLTage:RANGe " & CStr(m_DeviceRange.dVoltageListValue(m_KeithleyInfos.nVoltageRangeIndex))
                End If
                If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
            End If
        End With

        Return True
    End Function

    Public Function SetInit() As Boolean
        Dim sCommand As String = ""

        Reset()

        '터미널 모드 추가
        With m_KeithleyInfos

            'If .WireMode = ucKeithleySMUSettings.eProve.e2Prove Then
            '    sCommand = ":SYSTem:RSENse 0"
            'ElseIf .WireMode = ucKeithleySMUSettings.eProve.e4Prove Then
            '    sCommand = ":SYSTem:RSENse 1"
            'End If
            'If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False


            '1. SetWire
            If SetWireMode(.WireMode) = False Then Return False

            '2. SetTerminal
            If SetTerminalMode(.TerminalMode) = False Then Return False

            '3. SetSourceMode
            If SetSourceMode() = False Then Return False

            '4. SetMeasureMode
            If SetMeasureMode() = False Then Return False


            sCommand = ":SENSe:AVERage:COUNt " & CStr(.NumOfMeasData)
            If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            sCommand = ":SOUR:DEL " & CStr(.SourceDelay_Sec)
            If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            sCommand = ":SENSe:CURRent:DC:NPLCycles " & CStr(.IntegTime_Sec)
            If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            sCommand = ":SENSe:VOLTage:DC:NPLCycles " & CStr(.IntegTime_Sec)
            If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False


            'Select Case .SourceMode
            '    Case eSMUMode.eCurrent
            '        sCommand = ":CONFigure:VOLTAGE"
            '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            '        sCommand = ":SOURCE:FUNCtion CURRENT"
            '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            '        sCommand = ":SOURCE:CURRENT:MODE FIX"
            '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            '        sCommand = ":VOLTAGE:PROTECTION " & CStr(.LimitVoltage)
            '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            '        If .CurrentAutoRange = True Then
            '            sCommand = ":SOURCE:CURRent:RANGE:AUTO ON"
            '        Else
            '            '     sCommand = "smua.source.autorangei = smua.AUTORANGE_OFF"
            '            '    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
            '            '  sCommand = "smua.source.rangei = " & CStr(m_DeviceRange.dCurrentListValue(m_KeithleyInfos.nCurrentRangeIndex))
            '        End If
            '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False


            '    Case eSMUMode.eVoltage
            '        sCommand = ":CONFigure:CURRENT"
            '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            '        sCommand = ":SOURCE:FUNCtion VOLTAGE"
            '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            '        sCommand = ":SOURCE:VOLTAGE:MODE FIX"
            '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            '        sCommand = ":CURRENT:PROTECTION " & CStr(.LimitCurrent)
            '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            '        If .VoltageAutoRange = True Then
            '            sCommand = ":SOURCE:VOLTAGE:RANGE:AUTO ON"
            '        Else
            '            '   sCommand = "smua.source.autorangei = smua.AUTORANGE_OFF"
            '            '   If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
            '            '    sCommand = "smua.source.rangev = " & CStr(m_DeviceRange.dVoltageListValue(m_KeithleyInfos.nVoltageRangeIndex))
            '        End If
            '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            'End Select



            'Select Case .MeasureMode
            '    Case eSMUMode.eCurrent
            '        'DCV : 0
            '        'DCA : 1
            '        'Ohm : 2
            '        'Watts : 3
            '        'sCommand = "display.smua.measure.func = 0"
            '        'If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            '        If .CurrentAutoRange = True Then
            '            sCommand = ":SENSe:Current:RANGE:AUTO ON"
            '        Else
            '            sCommand = "smua.measure.autorangei = smua.AUTORANGE_OFF"
            '            '  If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
            '            '  sCommand = "smua.measure.rangei = " & CStr(m_DeviceRange.dCurrentListValue(m_KeithleyInfos.nCurrentRangeIndex))
            '        End If
            '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            '    Case eSMUMode.eVoltage
            '        '  sCommand = "display.smua.measure.func = 1"
            '        '  If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            '        If .CurrentAutoRange = True Then
            '            sCommand = ":SENSe:VOLTAGE:RANGE:AUTO ON"
            '        Else
            '            '  sCommand = "smua.measure.autorangev = smua.AUTORANGE_OFF"
            '            '   If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
            '            '  sCommand = "smua.measure.rangev = " & CStr(m_DeviceRange.dVoltageListValue(m_KeithleyInfos.nVoltageRangeIndex))
            '        End If
            '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            'End Select

            Return True
        End With

    End Function

    Private Function Parse_K2400(ByVal in_Data As String, ByRef out_Volt As Double, ByRef out_Current As Double) As Boolean

        '+5.000000E+00,-5.827877E-11,+9.910000E+37,+4.598203E+02,+2.150800E+04
        '+1.000000E+00,+2.216835E-09,+9.910000E+37,+8.307366E+03,+2.151000E+04
        '데이터 : +1.000000E+00,+2.216835E-09 : 전압, 전류

        On Error GoTo error111

        Dim arrTemp As Array
        Dim buff As String
        Dim symbol As String

        Dim strCurrent As String
        Dim strVolt As String

        arrTemp = Split(in_Data, ",", -1)

        '********************
        'VOLT
        buff = arrTemp(0)
        symbol = buff.Chars(0)

        If symbol = "-" Then
            strVolt = buff.Substring(0)
        Else
            strVolt = buff.Substring(1)
        End If
        out_Volt = CDbl(strVolt)

        '********************
        'CURRENT
        symbol = ""
        buff = arrTemp(1)
        symbol = buff.Chars(0)

        If symbol = "-" Then
            strCurrent = buff.Substring(0)
        Else
            strCurrent = buff.Substring(1)
        End If

        out_Current = CDbl(strCurrent)

        Return True

error111:

        out_Volt = 0
        out_Current = 0

        Return False
    End Function


#Region "Off - State"
    ''' <summary>
    ''' SMU cell off tatus
    ''' K2400 seriese default 'Normal'.
    ''' K2410 only defualt 'Gaurd'.
    ''' </summary>
    ''' <param name="Mode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetOutput_OffState(ByVal Mode As eOffState) As Boolean 'Off State ADD - YSH - 2014-09-26

        Dim sCommand As String = ":OUTPut:SMODe"

        If Mode = eOffState.eHighIMPedance Then
            sCommand = sCommand & " HIMPedance"
        ElseIf Mode = eOffState.eGUARd Then
            sCommand = sCommand & " GUARd"
        ElseIf Mode = eOffState.eZERO Then
            sCommand = sCommand & " ZERO"
        Else
            sCommand = sCommand & " NORMal"
        End If

        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        Return True
    End Function

    ''' <summary>
    ''' SMU Output off stauts Query
    ''' </summary>
    ''' <param name="Mode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetOutput_OffState(ByRef Mode As eOffState) As Boolean 'Off State ADD - YSH - 2014-09-26

        Dim sCommand As String = ":OUTPut:SMODe?"
        Dim sRcvData As String = ""
        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
        If sRcvData = "" Then Return False
        sRcvData = sRcvData.TrimEnd(vbLf)
        sRcvData = sRcvData.TrimEnd(vbCr)

        If sRcvData = "HIMP" Then
            Mode = eOffState.eHighIMPedance
        ElseIf sRcvData = "GUAR" Then
            Mode = eOffState.eGUARd
        ElseIf sRcvData = "ZERO" Then
            Mode = eOffState.eZERO
        ElseIf sRcvData = "NORM" Then
            Mode = eOffState.eNORMal
        Else
            Return False
        End If

        Return True
    End Function

#End Region

#End Region

End Class
