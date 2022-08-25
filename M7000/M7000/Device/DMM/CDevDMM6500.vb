Imports System.Windows.Forms
Imports System.IO
Imports CCommLib

Public Class CDevDMM6500


    Public Communicator As CCommLib.CComAPI
    Dim m_bIsConnected As Boolean = False
    Dim m_ConfigInfo As CComCommonNode.sCommInfo
    Dim m_Settings As sSetting


    Public m_MyModel As eModel
    Public Shared sCurrentRagne6500() As String = New String() {"Auto", "10uA", "100uA", "1mA", "10mA", "100mA", "1A", "3A"}
    Public Shared dCurrentRagne6500_Vaule() As Double = New Double() {0, 10 * 10 ^ -6, 100 * 10 ^ -6, 1 * 10 ^ -3, 10 * 10 ^ -3, 0.1, 1, 3}
    Public Shared sVoltageRange6500() As String = New String() {"Auto", "100mV", "1V", "10V", "100V", "1000V"}
    Public Shared dVoltageRange6500_Value() As Double = New Double() {0, 100 * 10 ^ -3, 1, 10, 100, 1000}
    Public Shared sSupportDeviceList() As String = New String() {"DMM6500"}
    Public Shared sMeasureMode() As String = New String() {"Current", "Voltage"}


#Region "Enum"
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

    Public Enum eTerminalMode
        eRear
        eFront
    End Enum

    Public Enum eSMUCH
        eChA
        eChB
    End Enum

    Public Enum eONOFF
        eOFF
        eON
    End Enum

    Public Enum eModel
        eDMM6500
    End Enum
#End Region

#Region "Structure"
    Public Structure sSetting
        Dim SourceChannel As eSMUCH
        Dim SourceMode As eSMUMode
        Dim WireMode As eProve
        Dim SourceDelay_Sec As Double
        Dim LimitVoltage As Double
        Dim LimitCurrent As Double
        Dim TerminalMode As eTerminalMode
        Dim MeasureMode As eMeasValue
        Dim NumOfMeasData As Integer
        Dim MeasureDelay_Sec As Double
        Dim IntegTime_Sec As Double
        Dim CurrentAutoRange As Boolean
        Dim VoltageAutoRange As Boolean
        Dim Amplitude As Double 'pulse
        Dim PulseOnTime As Double 'pulse
        Dim PulseOffTime As Double 'pulse 
        Dim NumberOfPulse As Double 'pulse
        ' Dim SourceRange As Double  차 후 Manual Range 설정 부분 필요 _PSK
        '  Dim MeasureRange As Double
        Dim MeasureValueType As eMeasValue
        Dim MeasureDelayAuto As Boolean
        Dim nIntegTimeIndex As Integer
        Dim nVoltageRangeIndex As Integer
        Dim nCurrentRangeIndex As Integer
    End Structure
#End Region


#Region "Property"
    Public Property IsConnection() As Boolean
        Get
            Return m_bIsConnected
        End Get
        Set(value As Boolean)
            m_bIsConnected = value
        End Set
    End Property

    Public Property Settings As sSetting
        Get
            Return m_Settings
        End Get
        Set(value As sSetting)
            m_Settings = value
        End Set
    End Property

    Public Property Config As CComCommonNode.sCommInfo
        Get
            Return m_ConfigInfo
        End Get
        Set(value As CComCommonNode.sCommInfo)
            m_ConfigInfo = value
        End Set
    End Property
#End Region

    Public Function Connection(ByVal config As CComCommonNode.sCommInfo) As Boolean
        Dim sInfo As String = """"

        m_bIsConnected = False
        config.sLanInfo.sRcvTerminator = vbCrLf
        config.sLanInfo.sSendTerminator = vbCrLf
        m_configInfo = config
        Communicator = New CComAPI(m_ConfigInfo.commType)
        m_MyModel = eModel.eDMM6500

        If Communicator.Communicator.Connect(m_ConfigInfo) <> CComCommonNode.eReturnCode.OK Then
            MsgBox(Communicator.Communicator.StateMessage)
            Return False
        End If

        If IDN(sInfo) = False Then Return False
        m_bIsConnected = True

        Return True

    End Function


    Public Sub Disconnection()
        Communicator.Communicator.Disconnect()
        m_bIsConnected = False
    End Sub

    Public Function IDN(ByRef str As String) As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""

        sCommand = "*IDN?"
        If Communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then Return False

        str = sRcvData
        Return True
    End Function



    Public Function Measure(ByRef dValue As Double) As Boolean
        Dim sCommand As String = ""
        Dim sRcvData As String = ""

        sCommand = ":READ?"

        If Communicator.Communicator.SendToString(sCommand, sRcvData) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        dValue = sRcvData
        Return True
    End Function


    Public Function Abort() As Boolean
        Dim sCommand As String = ""

        sCommand = ":ABORt"
        If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        Return True
    End Function

    Public Function Initiate() As Boolean
        Dim sCommand As String = ":INITiate"
        If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        Return True
    End Function

    Public Function AverageCount(ByVal count As Integer) As Boolean
        Dim sCommand As String = ""

        If m_Settings.MeasureMode = eMeasValue.eVoltage Then
            sCommand = "VOLTage:AVERage:COUNt " & m_Settings.NumOfMeasData
        ElseIf m_Settings.MeasureMode = eMeasValue.eCurrent Then
            sCommand = "CURRent:AVERage:COUNt " & m_Settings.NumOfMeasData
        End If

        If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If

        Return True
    End Function

    Public Function DelayAuto() As Boolean
        Dim sCommand As String = ""

        If m_Settings.MeasureDelayAuto = True Then
            If m_Settings.MeasureMode = eMeasValue.eVoltage Then
                sCommand = "VOLTage:DELay:AUTO ON"
            Else
                sCommand = "CURRent:DELay:AUTO ON"
            End If

            If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
        Else
            If m_Settings.MeasureMode = eMeasValue.eVoltage Then
                sCommand = "VOLTage:DELay:AUTO OFF"

                If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
                sCommand = "VOLTage:DELay:USER " & m_Settings.MeasureDelay_Sec

                If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
            Else
                sCommand = "CURRent:DELay:AUTO OFF"

                If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
                sCommand = "CURRent:DELay:USER " & m_Settings.MeasureDelay_Sec

                If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
            End If

        End If

        'If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
        '    Return False
        'End If
        Return True

    End Function

    Public Function NPLC() As Boolean
        Dim sCommand As String = ""

        If m_Settings.MeasureMode = eMeasValue.eVoltage Then
            sCommand = "VOLTage:NPLCycles " & m_Settings.IntegTime_Sec
        Else
            sCommand = "CURRent:NPLCycles " & m_Settings.IntegTime_Sec
        End If

        If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        Return True
    End Function

    Public Function SetRange(ByVal mode As Boolean) As Boolean
        Dim sCommand As String = ""

        If mode = True Then
            If m_Settings.MeasureMode = eMeasValue.eVoltage Then
                sCommand = "VOLTage:RANGe:AUTO ON"
            Else
                sCommand = "CURRent:RANGe:AUTO ON"
            End If
            If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                Return False
            End If
        Else
            If m_Settings.MeasureMode = eMeasValue.eVoltage Then
                sCommand = "VOLTage:RANGe:AUTO OFF"
                If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If

                sCommand = "VOLTage:RANGe " & dVoltageRange6500_Value(m_Settings.nVoltageRangeIndex)
                If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
            Else
                sCommand = "CURRent:RANGe:AUTO OFF"
                If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If

                sCommand = "CURRent:RANGe " & dCurrentRagne6500_Vaule(m_Settings.nCurrentRangeIndex)
                If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
                    Return False
                End If
            End If
        End If




        Return True
    End Function

    Public Function SetMeasureMode(ByVal mode As eMeasValue) As Boolean
        Dim sCommand As String = ""

        If mode = eMeasValue.eVoltage Then
            sCommand = ":FUNCtion ""VOLTage"""
        ElseIf mode = eMeasValue.eCurrent Then
            sCommand = ":FUNCtion ""CURRent"""
        End If

        If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        m_Settings.MeasureMode = mode
        Return True
    End Function

    Public Function StatusClear() As Boolean
        Dim sCommand As String = ""

        sCommand = ":STATus:CLEar"

        If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        Return True
    End Function

    Public Function TraceClear() As Boolean
        Dim sCommand As String = ""

        sCommand = ":TRACe:CLEar"
        If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then
            Return False
        End If
        Return True
    End Function
    Public Function TerminalMode(ByVal mode As eTerminalMode) As Boolean

        Dim sCommand As String = ""

        If TerminalMode = eTerminalMode.eFront Then
            sCommand = ":ROUte:TERMinals FRONT"
        ElseIf TerminalMode = eTerminalMode.eRear Then
            sCommand = ":ROUte:TERMinals REAR"
        End If

        If Communicator.Communicator.SendToString(sCommand) <> CComCommonNode.eReturnCode.OK Then Return False
        Return True
    End Function

    Public Function InitializeSweep(ByVal settings As sSetting) As Boolean
        m_Settings = settings


        '   If TerminalMode(m_Settings.TerminalMode) = False Then Return False


        If SetMeasureMode(m_Settings.MeasureMode) = False Then Return False


        If SetRange(m_Settings.CurrentAutoRange) = False Then Return False

        If DelayAuto() = False Then Return False

        If NPLC() = False Then Return False

        'If AverageCount(m_Settings.NumOfMeasData) = False Then Return False


        '   If Initiate() = False Then Return False

        Return True
    End Function
    Public Shared ReadOnly Property SupportDeviceNames() As String()
        Get
            Return sSupportDeviceList.Clone
        End Get
    End Property

End Class
