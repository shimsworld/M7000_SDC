Imports System.IO.Ports
Imports System.Threading
Imports System.Text.Encoding
Imports CCommLib

Public Class CDevK26xx
    Inherits CDevSMUCommonNode
    '  Dim m_Config As CComCommonNode.sCommInfo

    Dim communicator As CComAPI '= New CComAPI(CComCommonNode.eCommType.eSerial)
    Dim m_KeithleyInfos As ucKeithleySMUSettings.sKeithley
    Dim m_ChNum As String

#Region "Define"
    Dim m_DeviceRange As sRangeAndIntegTime

    Private sCurrentRangeName_K2601() As String = New String() {"Auto", "100nA", "1uA", "10uA", "100uA", "1mA", "10mA", "100mA", "1A", "3A"}
    Private sVoltageRangeName_K2601() As String = New String() {"Auto", "100mA", "1V", "6V", "40V"}
    Private dCurrentRangeValue_K2601() As Double = New Double() {0, 100 * 10 ^ -9, 1 * 10 ^ -6, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 10 * 10 ^ -3, 100 * 10 ^ -3, 1, 3}
    Private dVoltageRangeValue_K2601() As Double = New Double() {0, 0.1, 1, 6, 40}

    Private sCurrentRangeName_K2602() As String = New String() {"Auto", "100nA", "1uA", "10uA", "100uA", "1mA", "10mA", "100mA", "1A", "3A"}
    Private sVoltageRangeName_K2602() As String = New String() {"Auto", "100mA", "1V", "6V", "40V"}
    Private dCurrentRangeValue_K2602() As Double = New Double() {0, 100 * 10 ^ -9, 1 * 10 ^ -6, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 10 * 10 ^ -3, 100 * 10 ^ -3, 1, 3}
    Private dVoltageRangeValue_K2602() As Double = New Double() {0, 0.1, 1, 6, 40}

    Private sCurrentRangeName_K2635() As String = New String() {"Auto", "100pA", "1nA", "10nA", "100nA", "1uA", "10uA", "100uA", "1mA", "10mA", "100mA", "1A", "1.5A"}
    Private sVoltageRangeName_K2635() As String = New String() {"Auto", "200mA", "2V", "20V", "200V"}
    Private dCurrentRangeValue_K2635() As Double = New Double() {0, 100 * 10 ^ -12, 1 * 10 ^ -9, 10 * 10 ^ -9, 100 * 10 ^ -9, 1 * 10 ^ -6, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 10 * 10 ^ -3, 100 * 10 ^ -3, 1, 1.5}
    Private dVoltageRangeValue_K2635() As Double = New Double() {0, 0.2, 2, 20, 200}

    Private sCurrentRangeName_K2636() As String = New String() {"Auto", "1nA", "10nA", "100nA", "1uA", "10uA", "100uA", "1mA", "10mA", "100mA", "1A", "1.5A"}
    Private sVoltageRangeName_K2636() As String = New String() {"Auto", "200mA", "2V", "20V", "200V"}
    Private dCurrentRangeValue_K2636() As Double = New Double() {0, 1 * 10 ^ -9, 10 * 10 ^ -9, 100 * 10 ^ -9, 1 * 10 ^ -6, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 10 * 10 ^ -3, 100 * 10 ^ -3, 1, 1.5}
    Private dVoltageRangeValue_K2636() As Double = New Double() {0, 0.2, 2, 20, 200}

    Private sChName() As String = New String() {"a", "b"}
    Private sSourceModeName() As String = New String() {"Current", "Voltage"}
    Private sSourceModeNamePulse() As String = New String() {"Current", "Voltage", "Pulse Current", "Pulse Voltage"}
    Public Enum eTransferState
        eReady
        eTransferingData
        eReciveFail_TimeOut
        eReciveComplete
        eReciveFail_NoData
    End Enum

    Private g_eRS232Status As eTransferState

    'Dim m_eSRCMode As eSMUMode
    'Dim m_eMeasMode As eSMUMode
    'Dim m_eMeasValue As eMeasValue
    'Dim m_eWireMode As eProve

    'Dim m_bAutoRange_Src As Boolean
    'Dim m_bAutoRange_Meas As Boolean
    'Dim m_dSrcRangeVal As Double
    'Dim m_dMeasRangeVal As Double
    'Dim m_dLimitVoltage As Double
    'Dim m_dLimitCurrent As Double
    'Dim m_dSrcLevel As Double

    'Dim m_nMeasDataNum As Integer
    'Dim m_dSrcDelay As Double
    'Dim m_dMeasDelay As Double
    'Dim m_dIntegTime As Double

#End Region

#Region "Enum"

    Public Enum eSMUCH
        eChA
        eChB
    End Enum

    Public Enum eSMUMode
        eCurrent
        eVoltage
        ePulseCurrent
        ePulseVoltage
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

    Public Enum eDevice
        K2635
        K2636
    End Enum
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

        Select Case m_MyModel

            Case eModel.KEITHLEY_K2601
                m_DeviceRange.sCurrentListName = sCurrentRangeName_K2601.Clone
                m_DeviceRange.sVoltageListName = sVoltageRangeName_K2601.Clone
                m_DeviceRange.dCurrentListValue = dCurrentRangeValue_K2601.Clone
                m_DeviceRange.dVoltageListValue = dVoltageRangeValue_K2601.Clone
                m_DeviceRange.sSourceModeName = sSourceModeName.Clone
            Case eModel.KEITHLEY_K2602
                m_DeviceRange.sCurrentListName = sCurrentRangeName_K2602.Clone
                m_DeviceRange.sVoltageListName = sVoltageRangeName_K2602.Clone
                m_DeviceRange.dCurrentListValue = dCurrentRangeValue_K2602.Clone
                m_DeviceRange.dVoltageListValue = dVoltageRangeValue_K2602.Clone
                m_DeviceRange.sSourceModeName = sSourceModeNamePulse.Clone
            Case eModel.KEITHLEY_K2635
                m_DeviceRange.sCurrentListName = sCurrentRangeName_K2635.Clone
                m_DeviceRange.sVoltageListName = sVoltageRangeName_K2635.Clone
                m_DeviceRange.dCurrentListValue = dCurrentRangeValue_K2635.Clone
                m_DeviceRange.dVoltageListValue = dVoltageRangeValue_K2635.Clone
                m_DeviceRange.sSourceModeName = sSourceModeName.Clone
            Case eModel.KEITHLEY_K2636
                m_DeviceRange.sCurrentListName = sCurrentRangeName_K2636.Clone
                m_DeviceRange.sVoltageListName = sVoltageRangeName_K2636.Clone
                m_DeviceRange.dCurrentListValue = dCurrentRangeValue_K2636.Clone
                m_DeviceRange.dVoltageListValue = dVoltageRangeValue_K2636.Clone
                m_DeviceRange.sSourceModeName = sSourceModeName.Clone
        End Select



    End Sub

#End Region


#Region "Communication"

    Public Overrides Function Connection(ByVal Config As CComCommonNode.sCommInfo) As Boolean
        Dim sInfo As String = ""
        m_bIsConnected = False
        m_ConfigInfo = Config
        communicator = New CComAPI(m_ConfigInfo.commType)
        communicator.Communicator.TimeOut = 10

        If communicator.Communicator.Connect(m_ConfigInfo) <> CComCommonNode.eReturnCode.OK Then
            MsgBox(communicator.Communicator.StateMessage)
            Return False
        End If

        If IDN(sInfo) = False Then Return False

        m_bIsConnected = True
        Return True

    End Function

    Public Overrides Sub Disconnection()
        '  If m_bIsConnected = True Then
        communicator.Communicator.Disconnect()
        '   End If
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
        If SetBiasLevel(dBias) = False Then Return False
        Return True
    End Function

    Public Overrides Function FinalizeSweep() As Boolean
        If Output(False) = False Then Return False
        If Reset() = False Then Return False
        Return True
    End Function

    Public Overrides Function Measure(ByRef dVoltage As Double, ByRef dCurrent As Double) As Boolean
        If Meas(eMeasValue.eVoltage, dVoltage) = False Then Return False
        If Meas(eMeasValue.eCurrent, dCurrent) = False Then Return False
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

    Public Overrides Function IDN(ByRef strInfo As String) As Boolean
        Dim sCommand As String = "*IDN?"
        Dim sRcvData As String = ""
        Dim sModel As String = ""

        If communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            MsgBox(communicator.Communicator.StateMessage)
            Return False
        End If

        If sRcvData = "" Then Return False

        Select Case Model
            Case eModel.KEITHLEY_K2601
                sModel = "2601"
            Case eModel.KEITHLEY_K2602
                sModel = "2602"
            Case eModel.KEITHLEY_K2635
                sModel = "2635"
            Case eModel.KEITHLEY_K2636
                sModel = "2636"
        End Select

        If sRcvData.Contains(sModel) = False Then Return False
        strInfo = sRcvData
        Return True
    End Function

#End Region


#Region "Function"

    Public Function Reset() As Boolean
        Dim sCommand As String = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".reset()"
        Dim sRcvData As String = ""
 If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
        Return True
    End Function

    Public Function Output(ByVal bOnOff As Boolean) As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""


        If bOnOff = True Then
            sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.output = smu" & sChName(m_KeithleyInfos.SourceChannel) & ".OUTPUT_ON"
        Else
            sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.output = smu" & sChName(m_KeithleyInfos.SourceChannel) & ".OUTPUT_OFF"
        End If

        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
        ' If CPort.SendToString(sCommand, sRcvMsg) = False Then
        'Return False
        ' End If

        Return True
    End Function

    Public Function SetBiasLevel(ByVal dBias As Double) As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""
        With m_KeithleyInfos
            Select Case .SourceMode
                Case eSMUMode.eCurrent
                    sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.leveli = " & CStr(dBias)
                Case eSMUMode.eVoltage
                    sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.levelv = " & CStr(dBias)
                Case eSMUMode.ePulseCurrent
                    sCommand = "PulseIMeasureV(smu" & sChName(m_KeithleyInfos.SourceChannel) & "," & CStr(dBias) & "," & CStr(.Amplitude) & "," & CStr(.PulseOnTime) & "," & CStr(.PulseOffTime) & "," & CStr(.NumberOfPulse) & ")"
                Case eSMUMode.ePulseVoltage
                    sCommand = "PulseVMeasureI(smu" & sChName(m_KeithleyInfos.SourceChannel) & "," & CStr(dBias) & "," & CStr(.Amplitude) & "," & CStr(.PulseOnTime) & "," & CStr(.PulseOffTime) & "," & CStr(.NumberOfPulse) & ")"
            End Select
        End With

        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
        Return True
    End Function

    Public Function SetInit() As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""

        Reset()

        With m_KeithleyInfos

            '1.SetWire
            If SetWireMode(.WireMode) = False Then Return False

            '2.SetSourceMode
            If SetSourceMode() = False Then Return False

            '3.SetMeasureMode 
            If SetMeasureMode() = False Then Return False

            sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.count = " & CStr(.NumOfMeasData)
            If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            If .MeasureDelayAuto = True Then
                sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.delay = -1"
            Else
                sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.delay = " & CStr(.MeasureDelay_Sec) 'm_dMeasDelay
            End If
           If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
            sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.delay = " & CStr(.SourceDelay_Sec)
            If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            Select Case .SourceMode

                Case eSMUMode.eVoltage Or eSMUMode.eCurrent
                    sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.nplc = " & CStr(.IntegTime_Sec)
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                Case eSMUMode.ePulseCurrent Or eSMUMode.ePulseVoltage

                    Dim nplc As Double = .PulseOnTime / 2
                    If nplc < 0.001 Then
                        nplc = 0.001
                    End If
                    sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.nplc = " & CStr(nplc)
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
            End Select


            Return True
        End With


        'If m_eWireMode = eProve.e2Prove Then
        '    sCommand = "smua.sense = 0" '& CStr(0)
        'ElseIf m_eWireMode = eProve.e4Prove Then
        '    sCommand = "smua.sense = 1" '& CStr(1)
        'End If

        '  If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False


        'Select Case m_eSRCMode
        '    Case eSMUMode.eCurrent
        '        sCommand = "smua.source.func = 0"
        '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        '        sCommand = "smua.source.limitv = " & CStr(m_dLimitVoltage)
        '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        '        If m_bAutoRange_Src = True Then
        '            sCommand = "smua.source.autorangei = smua.AUTORANGE_ON"
        '        Else
        '            sCommand = "smua.source.autorangei = smua.AUTORANGE_OFF"
        '            If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
        '            sCommand = "smua.source.rangei = " & CStr(m_dSrcRangeVal)
        '        End If
        '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        '        sCommand = "smua.source.leveli = " & CStr(m_dSrcLevel)
        '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False


        '    Case eSMUMode.eVoltage
        '        sCommand = "smua.source.func = 1"
        '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        '        sCommand = "smua.source.limitv = " & CStr(m_dLimitCurrent)
        '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        '        If m_bAutoRange_Src = True Then
        '            sCommand = "smua.source.autorangev = smua.AUTORANGE_ON"
        '        Else
        '            sCommand = "smua.source.autorangev = smua.AUTORANGE_OFF"
        '            If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
        '            sCommand = "smua.source.rangev = " & CStr(m_dSrcRangeVal)
        '        End If
        '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        '        sCommand = "smua.source.levelv = " & CStr(m_dSrcLevel)
        '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
        'End Select



        'Select Case m_eMeasMode
        '    Case eSMUMode.eCurrent
        '        'DCV : 0
        '        'DCA : 1
        '        'Ohm : 2
        '        'Watts : 3
        '        sCommand = "display.smua.measure.func = 0"
        '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        '        If m_bAutoRange_Meas = True Then
        '            sCommand = "smua.measure.autorangei = smua.AUTORANGE_ON"
        '        Else
        '            sCommand = "smua.measure.autorangei = smua.AUTORANGE_OFF"
        '            If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
        '            sCommand = "smua.measure.rangei = " & CStr(m_dMeasRangeVal)
        '        End If
        '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        '    Case eSMUMode.eVoltage
        '        sCommand = "display.smua.measure.func = 1"
        '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        '        If m_bAutoRange_Meas = True Then
        '            sCommand = "smua.measure.autorangev = smua.AUTORANGE_ON"
        '        Else
        '            sCommand = "smua.measure.autorangev = smua.AUTORANGE_OFF"
        '            If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
        '            sCommand = "smua.measure.rangev = " & CStr(m_dMeasRangeVal)
        '        End If
        '        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        'End Select


        'sCommand = "smua.measure.count = " & CStr(m_nMeasDataNum)
        'If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        'If ClassK2635S.bAutoMeasDelay = True Then
        '    sCommand = "smua.measure.delay = -1"
        'Else
        '    sCommand = "smu" & sSMUChs(ClassK2635S.SourceChannel) & ".measure.delay = " & CStr(g_SYSOpt.dMeasDelay_Sec) 'm_dMeasDelay
        'End If

        'sCommand = "smua.measure.delay = " & CStr(m_dMeasDelay)
        'If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False



        'sCommand = "smua.source.delay = " & CStr(m_dSrcDelay)
        'If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        'sCommand = "smua.measure.nplc = " & CStr(m_dIntegTime)
        'If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

        'Return True
    End Function

    Public Function Meas(ByVal MeasType As eMeasValue, ByRef outValue As Double) As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""

        ' Perform the measurement and store the readings in the buffer
        Select Case MeasType
            Case eMeasValue.eCurrent
                sCommand = "print(smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.i())"

                If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                    ' sRcvData = sRcvData.TrimEnd(sCMDTerminator)
                    outValue = CDbl(sRcvData)
                Else
                    If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        ' sRcvData = sRcvData.TrimEnd(sCMDTerminator)
                        outValue = CDbl(sRcvData)
                    Else
                        Return False
                    End If
                End If

            Case eMeasValue.eVoltage
                sCommand = "print(smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.v())"
                If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                    '   sRcvData = sRcvData.TrimEnd(sCMDTerminator)
                    outValue = CDbl(sRcvData)
                Else
                    If communicator.Communicator.SendToString(sCommand, sRcvData) = CComCommonNode.eReturnCode.OK Then
                        ' sRcvData = sRcvData.TrimEnd(sCMDTerminator)
                        outValue = CDbl(sRcvData)
                    Else
                        Return False
                    End If
                End If

                'Case eMeasValue.ePower
                '    outValue = _Driver.Measurement.Power.Measure(sSMUChs(m_eSMUCh))
                'Case eMeasValue.eResistance
                '    outValue = _Driver.Measurement.Resistance.Measure(sSMUChs(m_eSMUCh))
        End Select

        Return True

    End Function


    Public Function SetWireMode(ByVal WireMode As ucKeithleySMUSettings.eProve) As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""

        If WireMode = ucKeithleySMUSettings.eProve.e2Prove Then
            sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".sense = 0"
        ElseIf WireMode = ucKeithleySMUSettings.eProve.e4Prove Then
            sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".sense = 1"
        End If

       If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
        Return True
    End Function


    Public Function SetSourceMode() As Boolean

        Dim sCommand As String = ""
        Dim sRcvData As String = ""

        With m_KeithleyInfos

            Select Case .SourceMode
                Case eSMUMode.eCurrent
                    sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.func = 0"
                   If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                    sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.limitv = " & CStr(.LimitVoltage)
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                    If .CurrentAutoRange = True Then
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.autorangei = smu" & sChName(m_KeithleyInfos.SourceChannel) & ".AUTORANGE_ON"
                    Else
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.autorangei = smu" & sChName(m_KeithleyInfos.SourceChannel) & ".AUTORANGE_OFF"
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.rangei = " & CStr(m_DeviceRange.dCurrentListValue(.nCurrentRangeIndex))
                    End If
                  If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                    ' sCommand = "smua.source.leveli = " & CStr(m_dSrcLevel)
                    'If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False


                Case eSMUMode.eVoltage
                    sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.func = 1"
                   If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                    sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.limiti = " & CStr(.LimitCurrent)
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                    If .VoltageAutoRange = True Then
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.autorangev = smu" & sChName(m_KeithleyInfos.SourceChannel) & ".AUTORANGE_ON"
                    Else
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.autorangev = smu" & sChName(m_KeithleyInfos.SourceChannel) & ".AUTORANGE_OFF"
                       If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.rangev = " & CStr(m_DeviceRange.dVoltageListValue(.nVoltageRangeIndex))
                    End If
                   If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                    '  sCommand = "smua.source.levelv = " & CStr(m_dSrcLevel)
                    ' If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                Case eSMUMode.ePulseCurrent
                    sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.func = 0"
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                    sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.limitv = " & CStr(.LimitVoltage)
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                    If .VoltageAutoRange = True Then
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.autorangei = smu" & sChName(m_KeithleyInfos.SourceChannel) & ".AUTORANGE_ON"
                    Else
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.autorangei = smu" & sChName(m_KeithleyInfos.SourceChannel) & ".AUTORANGE_OFF"
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.rangei = " & CStr(m_DeviceRange.dCurrentListValue(.nCurrentRangeIndex))
                    End If
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                Case eSMUMode.ePulseVoltage
                    sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.func = 1"
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                    sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.limiti = " & CStr(.LimitCurrent)
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                    If .VoltageAutoRange = True Then
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.autorangev = smu" & sChName(m_KeithleyInfos.SourceChannel) & ".AUTORANGE_ON"
                    Else
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.autorangev = smu" & sChName(m_KeithleyInfos.SourceChannel) & ".AUTORANGE_OFF"
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".source.rangev = " & CStr(m_DeviceRange.dVoltageListValue(.nVoltageRangeIndex))
                    End If
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

            End Select
        End With

        Return True
    End Function

    Public Function SetMeasureMode() As Boolean

        Dim sCommand As String = ""
        Dim sRcvData As String = ""

        With m_KeithleyInfos
            Select Case .MeasureMode
                Case eMeasValue.eCurrent
                    'DCV : 0
                    'DCA : 1
                    'Ohm : 2
                    'Watts : 3
                    sCommand = "display.smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.func = 0"
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                    If .CurrentAutoRange = True Then
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.autorangei = smu" & sChName(m_KeithleyInfos.SourceChannel) & ".AUTORANGE_ON"
                    Else
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.autorangei = smu" & sChName(m_KeithleyInfos.SourceChannel) & ".AUTORANGE_OFF"
                      If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.rangei = " & CStr(m_DeviceRange.dCurrentListValue(.nCurrentRangeIndex))
                    End If
                  If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                Case eMeasValue.eVoltage
                    sCommand = "display.smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.func = 1"
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False

                    If .VoltageAutoRange = True Then
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.autorangev = smu" & sChName(m_KeithleyInfos.SourceChannel) & ".AUTORANGE_ON"
                    Else
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.autorangev = smu" & sChName(m_KeithleyInfos.SourceChannel) & ".AUTORANGE_OFF"
                        If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
                        sCommand = "smu" & sChName(m_KeithleyInfos.SourceChannel) & ".measure.rangev = " & CStr(m_DeviceRange.dVoltageListValue(.nVoltageRangeIndex))
                    End If
                    If communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False


            End Select
        End With
        Return True
    End Function
#End Region


End Class
