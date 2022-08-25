Imports System
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Text
Imports System.Math
Imports CCommLib

Public Class CDevSG

#Region "Define"


    Dim strLogTemp As String
    Public Const Max_DAC_Channel As Integer = 108
    Public Const Max_ADC_Channel As Integer = 56
    Public Const Max_Pulse_Channel As Integer = 54



    Public Const Max_LimitVolt As Integer = 5
    Public Const Min_LimitVolt As Integer = -5

    Public Const Max_ADC_Limit_Channel As Integer = 16

    Dim m_InitValue As sInitialParam
    Dim cConUnit As CUnitCommonNode
    Dim communicator As CComAPI


    Dim m_bIsConnected As Boolean = False
    Dim strRetrunData As String
    Dim strCommand As String
    Dim strEco As String
    Dim bRcvData As Boolean

    '  Dim byReadData() As Byte
    Dim bySetData() As Byte
    Dim byGetData() As Byte
    Dim byFieldData() As Byte

    Dim nData_Len As Integer

    Public CH As Integer = 0
    Public ADDR As Integer = 0


    Dim m_MainPower_Schannel As Integer
    Dim m_MainPower_Echannel As Integer
    Dim m_SubPower_Schannel As Integer
    Dim m_SubPower_Echannel As Integer
    Dim m_Signal_Schannel As Integer
    Dim m_Signal_Echannel As Integer


    Dim m_PDSense_Schannel As Integer
    Dim m_PDSense_Echannel As Integer
    Dim m_TempSense_Schannel As Integer
    Dim m_TempSense_Echannel As Integer
    Dim m_CurrentSense_Schannel As Integer
    Dim m_CurrentSense_Echannel As Integer

    Dim m_MinTemp As Double = 0
    Dim m_MaxTemp As Double = 150
    Dim m_MinPD As Double = -100 'uA
    Dim m_MaxPD As Double = 100 'uA
    Dim m_MinCurr As Double = -1 'A
    Dim m_MaxCurr As Double = 1 'A
    Dim m_MaxAdcVal As Double = 5
    Dim m_MinAdcVal As Double = -5



    Public Cal_DacSlope() As Double
    Public Cal_DacOffset() As Double
    Public Cal_AdcSlope() As Double
    Public Cal_AdcOffset() As Double

    Public CalApply As Boolean = False 'Cal 적용 여부

#Region "Enum"

    Enum eDacMode
        eDCMode
        ePulseMode
    End Enum
    Enum eCalApply
        eNone
        eApply
    End Enum
    Enum eOnOff
        eOFF
        eON
    End Enum
    Enum eFoutput
        eHigh
        eLow
    End Enum
    Enum eLimitAlarm
        eNoAlarm
        eVoltLimit
        eCurrentLimit
        eTempLimit
    End Enum

    Public Enum eModeType
        eMainPower
        eSubPower
        eSignalPower
    End Enum
    Public Enum eSenseType
        ePD
        eTemp
        eCurrent
    End Enum
    Public Enum eErrorCode
        eSuccess
        eErrAction
        eErrInit
        eErrFrame 'crc code
        eErrCommand 'invaldi command
        eErrComplete 'Running
        eErrSet
        ' 0 정상 상태 0x00 명령 정상 수행
        '1 동작 오류 0x01 설정한 에러가 동작 중 발생한 경우
        '2 장비 초기화 오류 0x02 장비 초기화 수행 오류
        '3 수신 프레임 오류 0x03 수신된 데이터의 프레임 오류 / CRC 오류
        '4 수신 명령 오류 0x04 수신된 명령이 존재하지 않음
        '5 명령 수행 중 오류 0x05 이전에 받은 명령을 수행 중인 경우
        '6 명령 설정 오류 0x06 설정 동작 명령에 실패한 경우
        '```
        '정의되지 않은 오류 0xFF 정의되지 않은 오류 발생할 경우
    End Enum

#End Region



#Region "Properties"



    Public Structure sSettingParam
        Dim nIdx As Integer 'Signal 의 번호 0 ~ 25 번 까지의, Main Power,Sub Power도 같은 개념으로 적용
        Dim sSignalName As String
        Dim Mode As eDacMode
        Dim DCOutputCh As eFoutput
        Dim dBias As Double
        Dim dAmplitude As Double
        Dim PulseParam As sPulseParam
    End Structure

    Public Structure sMeasParam
        Dim PDValue() As Double
        Dim TempValue() As Double
        Dim CurrentValue() As Double
    End Structure

    Public Structure sLimit
        Dim dTempLimit As Double
        Dim dCurrentLimit As Double
        Dim nAverCount As Integer
    End Structure

    Public Structure sPulseParam
        Dim Period As Double
        Dim Width As Double
        Dim Delay As Double
    End Structure

    Public Structure sBoardInfo
        Dim sModel As String
        Dim sSerialNo As String
        Dim sDate As String
        Dim sFirmwareVer As String
        Dim sFPGAVer As String
        Dim nDACChannel As Integer
        Dim nADCChannel As Integer
        Dim nAUXChannel As Integer
    End Structure

#End Region

#End Region

#Region "SG Command"
    '공통 명령


    Const SG_STX As Byte = &H2
    Const SG_ETX As Byte = &H3

    '공통 명령
    Const SG_COMMON As Byte = &H0
    Const SG_PING As Byte = &H0
    Const SG_RESET As Byte = &H1
    Const SG_SREGISTER As Byte = &H10
    Const SG_MOTION As Byte = &H11

    '동작 설정/조회
    Const SG_SET_ERR As Byte = &H1
    Const SG_GET_ERR As Byte = &H0

    Const SG_SET_INQUIRY As Byte = &H1
    Const SG_DAC_CHOUT As Byte = &H0
    Const SG_ALL_DACCH As Byte = &H1
    Const SG_ADC_SYNCTIME As Byte = &H10
    Const SG_SETPREQ As Byte = &H21
    Const SG_AMP As Byte = &H22
    ' Const QUIN_SAMPLE As Byte = &H23
    Const QUIN_OnOff As Byte = &H20

    '상태 조회/측정
    Const SG_Limit_Alarm As Byte = &H20
    Const SG_INQ_MEAS As Byte = &H2
    Const SG_ADCMEAS As Byte = &H0
    Const SG_ALL_ADCCH As Byte = &H1
    Const SG_AUX_ADC As Byte = &H2
    Const SG_AUX_ADC_ALLCH As Byte = &H3
    Const SG_SYNC_ALLADC As Byte = &H4
    Const SG_AUX_ADC_CH As Byte = &H11
    Const SG_SAVE As Byte = &H14

    '생산 공통명령
    Const SG_PROD_COM As Byte = &H80
    Const SG_BOARD_INFO As Byte = &H2
    Const SG_RES_INIT As Byte = &H10
    Const SG_SAVEINIT As Byte = &H15
    Const SG_Cal_Apply As Byte = &H20
    '생산 동작 설정/조회
    Const SG_PRODUCTION As Byte = &H81
    Const SG_FPGA_REG As Byte = &H0
    Const SG_DAC_REG As Byte = &H10
    Const SG_ADC_REG As Byte = &H11
    Const SG_FLASH_REG As Byte = &H12
    Const SG_FLASH_MEMORY As Byte = &H13
    Const SG_CLOCK_GENREG As Byte = &H14
    Const SG_SIGNAL_GENREG As Byte = &H15
    Const SG_GPO_PORTOUT As Byte = &H20
    Const SG_GPIO_PORTOUT As Byte = &H21
    Const SG_DGPIO As Byte = &H22
    Const SG_TRIG_PORT As Byte = &H23
    Const SG_TRIG_DELAY As Byte = &H24

    '생산 상태 조회/측정 명령 (0x82)
    Const SG_PROD_STATE As Byte = &H82
    Const SG_GPI_PORT As Byte = &H0
    Const SG_GPIO_PORTIN As Byte = &H1



    '측정 보상
    'Const SG_MEAS_COMPENSATION As Byte = &HF0
    'Const SG_DAC_SLPOE As Byte = &H0
    'Const SG_DAC_OFFSET As Byte = &H1
    'Const SG_ADC_SLOPE As Byte = &H10
    'Const SG_ADC_OFFSET As Byte = &H11
    'Const SG_AUX_ADC_SLOPE As Byte = &H12
    'Const SG_AUX_ADC_OFFSET As Byte = &H13
    'Const SG_WAVE_DAC_SLOPE As Byte = &H20
    'Const SG_WAVE_DAC_OFFSET As Byte = &H21
    'Const SG_WAVE_AMP As Byte = &H22
    'Const SG_WAVE_INTERVAL As Byte = &H23
    'Const SG_WAVE_CYCLE As Byte = &H24
    'Const SG_WAVE_FFT As Byte = &H25
    'Const SG_FFT_INIT As Byte = &H26
    'Const SG_FFT_CH As Byte = &H27

    'Const SG_RESERVED As Byte = &H0


    'Const SG_FFT_READ As Byte = &H20



    'Signal Generator manual 4.8.1
    Const SG_Command As Byte = &H21

    Const SG_Out_OneChannel As Byte = &H0
    Const SG_Out_AllChannel As Byte = &H1

    Const SG_Mode_OneChannel As Byte = &H10
    Const SG_Mode_AllChannel As Byte = &H11

    Const SG_OnOFF_OneChannel As Byte = &H20
    Const SG_OnOFF_AllChannel As Byte = &H21

    Const SG_FinalOut_OneChannel As Byte = &H22
    Const SG_FinalOut_AllChannel As Byte = &H23

    Const SG_Pulse_OneChannel As Byte = &H24
    Const SG_Pulse_AllChannel As Byte = &H25
    Const SG_Pulse_AllChannelSync As Byte = &H2A

    Const SG_ReadADc_OneChannel As Byte = &H26
    Const SG_ReadADc_AllChannel As Byte = &H27

    Const SG_AverCountADc_OneChannel As Byte = &H28
    Const SG_AverCountADc_AllChannel As Byte = &H29


    Const SG_LimitOutputADc_OneChannel As Byte = &H30
    Const SG_LimitOutputADc_AllChannel As Byte = &H31

    Const SG_TempLimitADc_OneChannel As Byte = &H32
    Const SG_TempLimitADc_AllChannel As Byte = &H33

    Const SG_GPIO_InOutSet As Byte = &H40
    Const SG_GPIO_ReadIn As Byte = &H41
    Const SG_GPIO_OnOFf As Byte = &H42

    Const SG_GPO_OnOFf As Byte = &H43

    '보상 값 적용
    Const SG_Compensation As Byte = &HF0
    Const SG_Dac_Slope As Byte = &H0
    Const SG_Dac_Offset As Byte = &H1

    Const SG_ADc_Slope As Byte = &H10
    Const SG_ADc_Offset As Byte = &H11
#End Region



#Region "Creator, Dispose and init"

    Public Structure sInitialParam
        Dim dDACMaxValue() As Double
        Dim dADCMaxValue() As Double
    End Structure

    Public Sub New(ByVal initParam As sInitialParam)
        communicator = New CComAPI(CComCommonNode.eCommType.eSerial)
        ReDim Cal_DacSlope(Max_DAC_Channel - 1)
        ReDim Cal_DacOffset(Max_DAC_Channel - 1)
        ReDim Cal_AdcSlope(Max_ADC_Channel - 1)
        ReDim Cal_AdcOffset(Max_ADC_Channel - 1)
        m_InitValue = initParam

        'main , sub , signal power 1 ~ 54
        m_MainPower_Schannel = 39 'ch num
        m_MainPower_Echannel = 54 'ch num

        m_SubPower_Schannel = 27 'ch num
        m_SubPower_Echannel = 38 'ch num

        m_Signal_Schannel = 1 'ch num
        m_Signal_Echannel = 26 'ch num


        m_PDSense_Schannel = 1
        m_PDSense_Echannel = 24


        m_TempSense_Schannel = 25
        m_TempSense_Echannel = 40


        m_CurrentSense_Schannel = 41
        m_CurrentSense_Echannel = 56


    End Sub
#End Region
#Region "2013 09 05 추가 "


#Region "ConverRange"
    Public Function ConvertSet_ADCLimitRange(ByVal inDacChannel As Integer, ByVal inValue As Double) As Double
        Try
            Return (inValue + m_InitValue.dADCMaxValue(inDacChannel - 1)) / Math.Abs(m_InitValue.dADCMaxValue(inDacChannel - 1) * 2) * Math.Abs(Max_LimitVolt * 2) - Math.Abs(Max_LimitVolt)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try

    End Function
    Public Function ConvertGet_ADCLimitRange(ByVal inADChannel As Integer, ByVal inValue As Double) As Double
        Try
            Return (inValue + Max_LimitVolt) / Math.Abs(Max_LimitVolt * 2) * Math.Abs(m_InitValue.dADCMaxValue(inADChannel - 1) * 2) - Math.Abs(m_InitValue.dADCMaxValue(inADChannel - 1))
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try
    End Function
    Public Function ConvertSet_DACLimitRange(ByVal inDacChannel As Integer, ByVal inValue As Double) As Double
        Try
            Return (inValue + m_InitValue.dDACMaxValue(inDacChannel - 1)) / Math.Abs(m_InitValue.dDACMaxValue(inDacChannel - 1) * 2) * Math.Abs(Max_LimitVolt * 2) - Math.Abs(Max_LimitVolt)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try

    End Function
    Public Function ConvertGet_DACLimitRange(ByVal inADChannel As Integer, ByVal inValue As Double) As Double
        Try
            Return (inValue + Max_LimitVolt) / Math.Abs(Max_LimitVolt * 2) * Math.Abs(m_InitValue.dDACMaxValue(inADChannel - 1) * 2) - Math.Abs(m_InitValue.dDACMaxValue(inADChannel - 1))
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try
    End Function
#End Region
#Region "Main Power 0~15"
    Public Function MainPower_Off(ByVal inAddrs As Integer, ByVal inch As Integer) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim inModeType As eModeType = eModeType.eMainPower


        Dim OnOffMode() As cDevSG.eOnOff = Nothing
        If Get_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then       '(에러코드 , 설정  Onoff 0:Off Mode , 1:On Mode  , max  채널 54)
            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer
        ConvertPowerChannel(inModeType, tStartChannel, tEndChannel)
        For Cnt = tStartChannel To tEndChannel
            OnOffMode(Cnt - 1) = eOnOff.eOFF
        Next

        If Set_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then
            Return False
        End If

        ''''''''''''''GPO Output
        If inModeType = eModeType.eMainPower Then

            Dim SetValue() As Boolean = Nothing
            If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

                Return False
            End If


            For Cnt = 0 To SetValue.Length - 1

                SetValue(Cnt) = False

            Next

            Dim tBitNum As Double = 0
            For Cnt = 0 To SetValue.Length - 1
                If SetValue(Cnt) = True Then
                    tBitNum += 2 ^ Cnt
                End If
            Next

            Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        End If
        ''''''''''''''GPO Output
        Return True
    End Function
    Public Function MainPower_Off(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim inModeType As eModeType = eModeType.eMainPower

        Dim tSChannel As Integer
        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)

        If Set_OnoffOneChannel(inAddrs, inch, ret, eOnOff.eOFF, tSChannel) = False Then
            Return False

        End If


        ''''''''''''''GPO Output
        If inModeType = eModeType.eMainPower Then



            Dim SetValue() As Boolean = Nothing
            If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

                Return False
            End If


            For Cnt = 0 To SetValue.Length - 1
                If Cnt = inSetChannel Then
                    If SetValue(Cnt) = True Then
                        SetValue(Cnt) = False
                    End If
                End If
            Next

            Dim tBitNum As Double = 0
            For Cnt = 0 To SetValue.Length - 1
                If SetValue(Cnt) = True Then
                    tBitNum += 2 ^ Cnt
                End If
            Next

            Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        End If
        ''''''''''''''GPO Output
        Return True
    End Function

    Public Function MainPower_BiasSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByVal inSetPara As sSettingParam) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer
        Dim inModeType As eModeType = eModeType.eMainPower


        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If
        tSChannel = tSChannel + (inSetChannel)



        Dim tBias As Double = ConvertSet_DACLimitRange(tSChannel, inSetPara.dBias)
        Dim tAmplitude As Double = ConvertSet_DACLimitRange(tSChannel, inSetPara.dAmplitude)


        Dim tDacMode As eDacMode = inSetPara.Mode
        Dim tFOutput As eFoutput = inSetPara.DCOutputCh
        Dim tPulseSet As sPulseParam = inSetPara.PulseParam


        If CalApply = True Then
            tBias = tBias * Cal_DacSlope(tSChannel * 2 - 2) + Cal_DacOffset(tSChannel * 2 - 2)
            tAmplitude = tAmplitude * Cal_DacSlope(tSChannel * 2 - 1) + Cal_DacOffset(tSChannel * 2 - 1)
        End If

        '''''''''''''''' Dac Mode 설정
        If Set_SelectModeOneChannel(inAddrs, inch, ret, tDacMode, tSChannel - 1) = False Then
            Return False

        End If
        '''''''''''''''' Dac Mode 설정


        If tDacMode = eDacMode.eDCMode Then

            If Set_FinalOutputOneChannel(inAddrs, inch, ret, tFOutput, tSChannel - 1) = False Then
                Return False
            End If


        ElseIf tDacMode = eDacMode.ePulseMode Then

            If Set_PulseOneChannel(inAddrs, inch, ret, tPulseSet, tSChannel - 1) = False Then
                Return False
            End If


        End If



        'High Bias Set
        If Set_OutputOneChannel(inAddrs, inch, ret, tBias, tSChannel * 2 - 2) = False Then
            Return False
        End If

        'Low Bias Set
        If Set_OutputOneChannel(inAddrs, inch, ret, tAmplitude, tSChannel * 2 - 1) = False Then
            Return False
        End If






        'Dim Mode As eDacMode
        'Dim DCOutputCh As eFoutput
        'Dim dBias As Double
        'Dim dAmplitude As Double
        'Dim PulseParam As sPulseParam



        Return True
    End Function
    Public Function MainPower_BiasSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel() As Integer, ByVal inSetPara() As sSettingParam) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer
        Dim inModeType As eModeType = eModeType.eMainPower


        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        Dim tBias As Double
        Dim tAmplitude As Double


        Dim tDacBias() As Double = Nothing
        Dim tDacMode() As eDacMode = Nothing
        Dim tFOutput() As eFoutput = Nothing
        Dim tPulseSet() As sPulseParam = Nothing


        '''''''''''''''' Dac Mode 설정 전체 읽기
        If Get_SelectModeAllChannel(inAddrs, inch, ret, tDacMode) = False Then
            Return False
        End If
        '''''''''''''''' Dac Foutput 설정 전체 읽기
        If Get_FinalOutputAllChannel(inAddrs, inch, ret, tFOutput) = False Then
            Return False
        End If
        '''''''''''''''' Dac Pulse 설정 전체 읽기
        If Get_PulseAllChannel(inAddrs, inch, ret, tPulseSet) = False Then
            Return False
        End If
        '''''''''''''''' Dac Pulse 설정 전체 읽기
        If Get_OutputAllChannel(inAddrs, inch, ret, tDacBias) = False Then
            Return False
        End If


        For Cnt = 0 To inSetChannel.Length - 1
            tDacMode((tSChannel - 1) + inSetChannel(Cnt)) = inSetPara(Cnt).Mode
            tFOutput((tSChannel - 1) + inSetChannel(Cnt)) = inSetPara(Cnt).DCOutputCh
            tPulseSet((tSChannel - 1) + inSetChannel(Cnt)) = inSetPara(Cnt).PulseParam
            If CalApply = True Then
                tBias = ConvertSet_DACLimitRange(tSChannel, inSetPara(Cnt).dBias) * Cal_DacSlope(tSChannel * 2 - 2) + Cal_DacOffset(tSChannel * 2 - 2)
                tAmplitude = ConvertSet_DACLimitRange(tSChannel, inSetPara(Cnt).dAmplitude) * Cal_DacSlope(tSChannel * 2 - 1) + Cal_DacOffset(tSChannel * 2 - 1)
            End If
            tDacBias(tSChannel * 2 - 2) = tBias
            tDacBias(tSChannel * 2 - 1) = tAmplitude
        Next

        '''''''''''''''' Dac Mode 전체 설정
        If Set_SelectModeAllChannel(inAddrs, inch, ret, tDacMode) = False Then
            Return False
        End If
        '''''''''''''''' Dac Foutput 전체 설정
        If Set_FinalOutputAllChannel(inAddrs, inch, ret, tFOutput) = False Then
            Return False
        End If
        '''''''''''''''' Dac Pulse 전체 설정
        If Set_PulseAllChannel(inAddrs, inch, ret, tPulseSet) = False Then
            Return False
        End If
        '''''''''''''''' Dac Output 전체 설정
        If Set_OutputAllChannel(inAddrs, inch, ret, tDacBias) = False Then
            Return False
        End If
        Return True
    End Function

    Public Function MainPower_On(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel() As Integer) As Boolean

        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim inModeType As eModeType = eModeType.eMainPower

        If inSetChannel Is Nothing Then
            MsgBox("채널 정보가 부족합니다(Not enough channel information)")
            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer


        If ChkPowerChannel(inModeType, inSetChannel, tStartChannel) = False Then
            Return False
        End If



        If ConvertPowerChannel(inModeType, tStartChannel, tEndChannel) = False Then
            Return False
        End If


        Dim OnOffMode() As cDevSG.eOnOff = Nothing
        If Get_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then       '(에러코드 , 설정  Onoff 0:Off Mode , 1:On Mode  , max  채널 54)
            Return False
        End If



        For Cnt = 0 To inSetChannel.Length - 1
            OnOffMode((tStartChannel - 1) + inSetChannel(Cnt)) = eOnOff.eON
        Next


        If Set_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then
            Return False
        End If
        '''''''''''''''' OnOff 설정

        ''''''''''''''GPO Output
        If inModeType = eModeType.eMainPower Then



            Dim SetValue() As Boolean = Nothing
            If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

                Return False
            End If


            For Cnt = 0 To inSetChannel.Length - 1

                SetValue(inSetChannel(Cnt)) = True

            Next


            ''수정 필요
            'For Cnt = 0 To Max_ADC_Limit_Channel - 1


            '    If SetValue(Cnt) = False Then
            '        SetValue(Cnt) = True
            '    End If

            'Next

            Dim tBitNum As Double = 0
            For Cnt = 0 To SetValue.Length - 1
                If SetValue(Cnt) = True Then
                    tBitNum += 2 ^ Cnt
                End If
            Next

            Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        End If
        ''''''''''''''GPO Output
        Return True
    End Function
    Public Function MainPower_On(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer
        Dim inModeType As eModeType = eModeType.eMainPower

        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)

        If Set_OnoffOneChannel(inAddrs, inch, ret, eOnOff.eON, tSChannel) = False Then
            Return False
        End If
        '''''''''''''''' OnOff 설정

        ''''''''''''''GPO Output
        If inModeType = eModeType.eMainPower Then

            Dim SetValue() As Boolean = Nothing
            If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

                Return False
            End If
            For Cnt = 0 To SetValue.Length - 1
                If Cnt = inSetChannel Then
                    If SetValue(Cnt) = False Then
                        SetValue(Cnt) = True
                    End If
                End If
            Next

            Dim tBitNum As Double = 0
            For Cnt = 0 To SetValue.Length - 1
                If SetValue(Cnt) = True Then
                    tBitNum += 2 ^ Cnt
                End If
            Next

            Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        End If
        ''''''''''''''GPO Output

        Return True
    End Function

    Public Function MainPower_CurrMeas(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef OutCurrValue() As Double) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim inSenseType As eSenseType = eSenseType.eCurrent


        Dim ReadValue() As Double = Nothing
        If Get_ReadADcAllChannel(inAddrs, inch, ret, ReadValue) = False Then

            Return False
        End If


        Dim tStartChannel As Integer
        Dim tEndChannel As Integer


        ConvertSenseChannel(inSenseType, tStartChannel, tEndChannel)
        ReDim OutCurrValue(tEndChannel - tStartChannel)


        For Cnt = tStartChannel To tEndChannel
            If CalApply = False Then
                OutCurrValue(Cnt - tStartChannel) = ConvertGet_ADCLimitRange(tStartChannel, ReadValue(Cnt - 1))
            ElseIf CalApply = True Then
                OutCurrValue(Cnt - tStartChannel) = ConvertGet_ADCLimitRange(tStartChannel, ReadValue(Cnt - 1)) * Cal_AdcSlope(Cnt - 1) + Cal_AdcOffset(Cnt - 1)
            End If
        Next

        Return True



    End Function
    Public Function MainPower_CurrMeas(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByRef OutCurrValue As Double) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim inSenseType As eSenseType = eSenseType.eCurrent

        Dim tSChannel As Integer
        Dim ReadValue As Double

        If ChkSenseChannel(inSenseType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)


        '읽는 부분 수정
        ''Dim ReadValue1() As Double = Nothing
        ''If Get_ReadADcAllChannel(inAddrs, inch, ret, ReadValue1) = False Then

        ''    Return False
        ''End If


        ''Dim tStartChannel As Integer
        ''Dim tEndChannel As Integer


        ''ConvertSenseChannel(inSenseType, tStartChannel, tEndChannel)



        ''If CalApply = False Then
        ''    ReadValue = ConvertGet_ADCLimitRange(tSChannel, ReadValue1(tStartChannel - 1 + inSetChannel))
        ''Else
        ''    ReadValue = ConvertGet_ADCLimitRange(tSChannel, ReadValue1(tStartChannel - 1 + inSetChannel)) * Cal_AdcSlope(tSChannel) + Cal_AdcOffset(tSChannel)
        ''End If

        ''OutCurrValue = ReadValue
        '읽는 부분 수정

        If Get_ReadADcOneChannel(inAddrs, inch, ret, ReadValue, tSChannel) = False Then

            Return False
        End If

        If CalApply = False Then
            ReadValue = ConvertGet_ADCLimitRange(tSChannel, ReadValue)
        Else
            ReadValue = ConvertGet_ADCLimitRange(tSChannel, ReadValue) * Cal_AdcSlope(tSChannel) + Cal_AdcOffset(tSChannel)
        End If

        OutCurrValue = ReadValue

        Return True
    End Function

    Public Function MainPower_TempMeas(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef OutTempValue() As Double) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim inSenseType As eSenseType = eSenseType.eTemp


        Dim ReadValue() As Double = Nothing
        If Get_ReadADcAllChannel(inAddrs, inch, ret, ReadValue) = False Then

            Return False
        End If


        Dim tStartChannel As Integer
        Dim tEndChannel As Integer


        ConvertSenseChannel(inSenseType, tStartChannel, tEndChannel)
        ReDim OutTempValue(tEndChannel - tStartChannel)


        For Cnt = tStartChannel To tEndChannel
            If CalApply = False Then
                OutTempValue(Cnt - tStartChannel) = ConvertGet_ADCLimitRange(tStartChannel, ReadValue(Cnt - 1))
            ElseIf CalApply = True Then
                OutTempValue(Cnt - tStartChannel) = ConvertGet_ADCLimitRange(tStartChannel, ReadValue(Cnt - 1)) * Cal_AdcSlope(Cnt - 1) + Cal_AdcOffset(Cnt - 1)
            End If
        Next

        Return True



    End Function
    Public Function MainPower_TempMeas(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByRef OutTempValue As Double) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim inSenseType As eSenseType = eSenseType.eTemp

        Dim tSChannel As Integer
        Dim ReadValue As Double

        If ChkSenseChannel(inSenseType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)


        '읽는 부분 수정
        ''Dim ReadValue1() As Double = Nothing
        ''If Get_ReadADcAllChannel(inAddrs, inch, ret, ReadValue1) = False Then

        ''    Return False
        ''End If


        ''Dim tStartChannel As Integer
        ''Dim tEndChannel As Integer


        ''ConvertSenseChannel(inSenseType, tStartChannel, tEndChannel)



        ''If CalApply = False Then
        ''    ReadValue = ConvertGet_ADCLimitRange(tSChannel, ReadValue1(tStartChannel - 1 + inSetChannel))
        ''Else
        ''    ReadValue = ConvertGet_ADCLimitRange(tSChannel, ReadValue1(tStartChannel - 1 + inSetChannel)) * Cal_AdcSlope(tSChannel) + Cal_AdcOffset(tSChannel)
        ''End If


        ''OutTempValue = ReadValue
        '읽는 부분 수정


        If Get_ReadADcOneChannel(inAddrs, inch, ret, ReadValue, tSChannel) = False Then

            Return False
        End If

        If CalApply = False Then
            ReadValue = ConvertGet_ADCLimitRange((tSChannel + 1), ReadValue)
        Else
            ReadValue = ConvertGet_ADCLimitRange((tSChannel + 1), ReadValue) * Cal_AdcSlope(tSChannel) + Cal_AdcOffset(tSChannel)
        End If

        OutTempValue = ReadValue

        Return True
    End Function

    Public Function MainPower_LimitClear(ByVal inAddrs As Integer, ByVal inch As Integer) As Boolean
        Dim ret As Integer
        If cResisterInit(inAddrs, inch, ret) = False Then
            Return False
        End If
        Return True
    End Function

    Public Function MainPower_CurrLimitAlarmChk(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef OutAlarm() As eLimitAlarm) As Boolean
        'Limit curr 알람 확인
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim ReadAlarm() As eLimitAlarm = Nothing

        If Get_LimitAlarm(inAddrs, inch, ret, ReadAlarm) = False Then


            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer

        ConvertSenseChannel(eSenseType.eCurrent, tStartChannel, tEndChannel)

        ReDim OutAlarm(tEndChannel - tStartChannel)

        For Cnt = tStartChannel To tEndChannel
            OutAlarm(Cnt - tStartChannel) = ReadAlarm(Cnt - 1)
        Next



        Return True
    End Function
    Public Function MainPower_CurrLimitAlarmChk(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByRef OutAlarm As eLimitAlarm) As Boolean
        'Limit curr 알람 확인
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim tSChannel As Integer
        Dim ReadAlarm() As eLimitAlarm = Nothing

        If ChkSenseChannel(eSenseType.eCurrent, inSetChannel, tSChannel) = False Then
            Return False
        End If



        If Get_LimitAlarm(inAddrs, inch, ret, ReadAlarm) = False Then

            Return False
        End If

        OutAlarm = ReadAlarm(inSetChannel - 1)

        Return True
    End Function

    Public Function MainPower_TempLimitAlarmChk(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef OutAlarm() As eLimitAlarm) As Boolean
        'Limit 온도 알람 확인
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim ReadAlarm() As eLimitAlarm = Nothing

        If Get_LimitAlarm(inAddrs, inch, ret, ReadAlarm) = False Then
            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer

        ConvertSenseChannel(eSenseType.eTemp, tStartChannel, tEndChannel)

        ReDim OutAlarm(tEndChannel - tStartChannel)

        For Cnt = tStartChannel To tEndChannel
            OutAlarm(Cnt - tStartChannel) = ReadAlarm(Cnt - 1)
        Next

        Return True
    End Function
    Public Function MainPower_TempLimitAlarmChk(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByRef OutAlarm As eLimitAlarm) As Boolean
        'Limit 온도 알람 확인
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim tSChannel As Integer
        Dim ReadAlarm() As eLimitAlarm = Nothing

        If ChkSenseChannel(eSenseType.eTemp, inSetChannel, tSChannel) = False Then
            Return False
        End If



        If Get_LimitAlarm(inAddrs, inch, ret, ReadAlarm) = False Then

            Return False
        End If

        OutAlarm = ReadAlarm(inSetChannel - 1)

        Return True
    End Function

    Public Function MainPower_TempLimitSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal InSetLimit As sLimit) As Boolean
        'Temp Sense 만 해당
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim ReadValue() As Double = Nothing

        If Get_ADcTempLimitAllChannel(inAddrs, inch, ret, ReadValue) = False Then

            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer

        ConvertSenseChannel(eSenseType.eTemp, tStartChannel, tEndChannel)
        Dim tSetTempLimit As Integer = ConvertSet_ADCLimitRange(1, InSetLimit.dTempLimit)


        For Cnt = 0 To ReadValue.Length - 1

            'If inCalApply = False Then
            '    tSetTempLimit = tSetTempLimit
            'ElseIf inCalApply = True Then
            '    'tSetTempLimit = InSetLimitTemp
            '    tSetTempLimit = tSetTempLimit * Cal_AdcSlope(Cnt - 1) + Cal_AdcOffset(Cnt - 1)
            'End If
            ReadValue(Cnt) = tSetTempLimit
        Next

        If AverageSetSense(eSenseType.eTemp, inAddrs, inch, InSetLimit.nAverCount) = False Then
            Return False
        End If


        If Set_ADcTempLimitAllChannel(inAddrs, inch, ret, ReadValue) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function MainPower_TempLimitSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByVal InSetLimit As sLimit) As Boolean
        'Temp Sense 만 해당
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim tSChannel As Integer


        If ChkSenseChannel(eSenseType.eTemp, inSetChannel, tSChannel) = False Then
            Return False
        End If
        Dim tSetTempLimit As Integer = ConvertSet_ADCLimitRange(tSChannel, InSetLimit.dTempLimit)
        tSChannel = tSChannel + (inSetChannel - 1)


        'If inCalApply = False Then
        '    tSetTempLimit = tSetTempLimit
        'ElseIf inCalApply = True Then
        '    'tSetTempLimit = InSetLimitTemp
        '    tSetTempLimit = tSetTempLimit * Cal_AdcSlope(tSChannel) + Cal_AdcOffset(tSChannel)
        'End If

        If AverageSetSense(eSenseType.eTemp, inAddrs, inch, inSetChannel, InSetLimit.nAverCount) = False Then
            Return False
        End If


        If Set_ADcTempLimitOneChannel(inAddrs, inch, ret, tSetTempLimit, 0) = False Then

            Return False
        End If




        Return True
    End Function
    Public Function MainPower_TempLimitSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel() As Integer, ByVal InSetLimit() As sLimit) As Boolean
        'Temp Sense 만 해당
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim tSChannel As Integer

        If ChkSenseChannel(eSenseType.eTemp, inSetChannel, tSChannel) = False Then
            Return False
        End If

        'Limit Current Set
        Dim ReadValue() As Double = Nothing

        If Get_ADcTempLimitAllChannel(inAddrs, inch, ret, ReadValue) = False Then
            Return False
        End If


        For Cnt = 0 To inSetChannel.Length - 1
            ReadValue(inSetChannel(Cnt)) = ConvertSet_ADCLimitRange(tSChannel, InSetLimit(Cnt).dTempLimit)
        Next

        If Set_ADcTempLimitAllChannel(inAddrs, inch, ret, ReadValue) = False Then
            Return False
        End If

        'Limit Current Set


        'Average Count Set
        Dim ReadCount() As Double = Nothing
        If Get_ADcAverCountAllChannel(inAddrs, inch, ret, ReadCount) = False Then
            Return False
        End If
        For Cnt = 0 To inSetChannel.Length - 1
            ReadCount((tSChannel - 1) + inSetChannel(Cnt)) = InSetLimit(Cnt).nAverCount
        Next
        If Set_ADcAverCountAllChannel(inAddrs, inch, ret, ReadCount) = False Then
            Return False
        End If
        'Average Count Set
        Return True
    End Function

    Public Function MainPower_CurrLimitSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal InSetLimit As sLimit) As Boolean
        'Current Sense 만 해당
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim ReadValue() As Double = Nothing

        If Get_ADcLimitAllChannel(inAddrs, inch, ret, ReadValue) = False Then

            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer

        ConvertSenseChannel(eSenseType.eCurrent, tStartChannel, tEndChannel)
        Dim tSetCurrLimit As Integer = ConvertSet_ADCLimitRange(tStartChannel, InSetLimit.dCurrentLimit)

        For Cnt = 0 To ReadValue.Length - 1

            'If inCalApply = False Then
            '    tSetCurrLimit = tSetCurrLimit
            'ElseIf inCalApply = True Then
            '    'tSetTempLimit = InSetLimitTemp
            '    tSetCurrLimit = tSetCurrLimit * Cal_AdcSlope(Cnt - 1) + Cal_AdcOffset(Cnt - 1)
            'End If
            ReadValue(Cnt) = tSetCurrLimit
        Next
        If AverageSetSense(eSenseType.eCurrent, inAddrs, inch, InSetLimit.nAverCount) = False Then
            Return False
        End If

        If Set_ADcLimitAllChannel(inAddrs, inch, ret, ReadValue) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function MainPower_CurrLimitSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByVal InSetLimit As sLimit) As Boolean
        'Current Sense 만 해당
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim tSChannel As Integer

        If ChkSenseChannel(eSenseType.eCurrent, inSetChannel, tSChannel) = False Then
            Return False
        End If
        Dim tSetCurrLimit As Integer = ConvertSet_ADCLimitRange(tSChannel, InSetLimit.dCurrentLimit)

        tSChannel = tSChannel + (inSetChannel - 1)

        'If inCalApply = False Then
        '    tSetCurrLimit = tSetCurrLimit
        'ElseIf inCalApply = True Then
        '    'tSetTempLimit = InSetLimitTemp
        '    tSetCurrLimit = tSetCurrLimit * Cal_AdcSlope(tSChannel) + Cal_AdcOffset(tSChannel)
        'End If
        If AverageSetSense(eSenseType.eCurrent, inAddrs, inch, inSetChannel, InSetLimit.nAverCount) = False Then
            Return False
        End If



        If Set_ADcLimitOneChannel(inAddrs, inch, ret, tSetCurrLimit, inSetChannel) = False Then

            Return False
        End If




        Return True
    End Function
    Public Function MainPower_CurrLimitSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel() As Integer, ByVal InSetLimit() As sLimit) As Boolean
        'Current Sense 만 해당
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim tSChannel As Integer

        If ChkSenseChannel(eSenseType.eCurrent, inSetChannel, tSChannel) = False Then
            Return False
        End If
        Dim ReadValue() As Double = Nothing

        If Get_ADcLimitAllChannel(inAddrs, inch, ret, ReadValue) = False Then
            Return False
        End If


        For Cnt = 0 To inSetChannel.Length - 1
            ReadValue(inSetChannel(Cnt)) = ConvertSet_ADCLimitRange(tSChannel, InSetLimit(Cnt).dCurrentLimit)
        Next

        If Set_ADcLimitAllChannel(inAddrs, inch, ret, ReadValue) = False Then
            Return False
        End If




        'Average Count Set
        Dim ReadCount() As Double = Nothing
        If Get_ADcAverCountAllChannel(inAddrs, inch, ret, ReadCount) = False Then
            Return False
        End If
        For Cnt = 0 To inSetChannel.Length - 1
            ReadCount((tSChannel - 1) + inSetChannel(Cnt)) = InSetLimit(Cnt).nAverCount
        Next
        If Set_ADcAverCountAllChannel(inAddrs, inch, ret, ReadCount) = False Then
            Return False
        End If
        'Average Count Set

        Return True
    End Function
#End Region
#Region "Sub Power 0~ 11"
    Public Function SubPower_Off(ByVal inAddrs As Integer, ByVal inch As Integer) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim inModeType As eModeType = eModeType.eSubPower


        Dim OnOffMode() As cDevSG.eOnOff = Nothing
        If Get_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then       '(에러코드 , 설정  Onoff 0:Off Mode , 1:On Mode  , max  채널 54)
            Return False
        End If



        Dim tStartChannel As Integer
        Dim tEndChannel As Integer
        ConvertPowerChannel(inModeType, tStartChannel, tEndChannel)
        For Cnt = tStartChannel To tEndChannel
            OnOffMode(Cnt - 1) = eOnOff.eOFF
        Next



        If Set_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then
            Return False
        End If

        ''''''''''''''GPO Output
        If inModeType = eModeType.eMainPower Then



            Dim SetValue() As Boolean = Nothing
            If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

                Return False
            End If


            For Cnt = 0 To SetValue.Length - 1

                SetValue(Cnt) = False

            Next

            Dim tBitNum As Double = 0
            For Cnt = 0 To SetValue.Length - 1
                If SetValue(Cnt) = True Then
                    tBitNum += 2 ^ Cnt
                End If
            Next

            Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        End If
        ''''''''''''''GPO Output
        Return True
    End Function
    Public Function SubPower_Off(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim inModeType As eModeType = eModeType.eSubPower

        Dim tSChannel As Integer
        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)

        If Set_OnoffOneChannel(inAddrs, inch, ret, eOnOff.eOFF, tSChannel) = False Then
            Return False

        End If


        ''''''''''''''GPO Output
        If inModeType = eModeType.eMainPower Then



            Dim SetValue() As Boolean = Nothing
            If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

                Return False
            End If


            For Cnt = 0 To SetValue.Length - 1
                If Cnt = inSetChannel Then
                    If SetValue(Cnt) = True Then
                        SetValue(Cnt) = False
                    End If
                End If
            Next

            Dim tBitNum As Double = 0
            For Cnt = 0 To SetValue.Length - 1
                If SetValue(Cnt) = True Then
                    tBitNum += 2 ^ Cnt
                End If
            Next

            Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        End If
        ''''''''''''''GPO Output
        Return True
    End Function

    Public Function SubPower_BiasSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByVal inSetPara As sSettingParam) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer
        Dim inModeType As eModeType = eModeType.eSubPower


        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If
        tSChannel = tSChannel + (inSetChannel)



        Dim tBias As Double = ConvertSet_DACLimitRange(tSChannel, inSetPara.dBias)
        Dim tAmplitude As Double = ConvertSet_DACLimitRange(tSChannel, inSetPara.dAmplitude)


        Dim tDacMode As eDacMode = inSetPara.Mode
        Dim tFOutput As eFoutput = inSetPara.DCOutputCh
        Dim tPulseSet As sPulseParam = inSetPara.PulseParam


        If CalApply = True Then
            tBias = tBias * Cal_DacSlope(tSChannel * 2 - 2) + Cal_DacOffset(tSChannel * 2 - 2)
            tAmplitude = tAmplitude * Cal_DacSlope(tSChannel * 2 - 1) + Cal_DacOffset(tSChannel * 2 - 1)
        End If


        'High Bias Set
        If Set_OutputOneChannel(inAddrs, inch, ret, tBias, tSChannel * 2 - 2) = False Then
            Return False
        End If

        'Low Bias Set
        If Set_OutputOneChannel(inAddrs, inch, ret, tAmplitude, tSChannel * 2 - 1) = False Then
            Return False
        End If


        '''''''''''''''' Dac Mode 설정
        If Set_SelectModeOneChannel(inAddrs, inch, ret, tDacMode, tSChannel - 1) = False Then
            Return False

        End If
        '''''''''''''''' Dac Mode 설정


        If tDacMode = eDacMode.eDCMode Then

            If Set_FinalOutputOneChannel(inAddrs, inch, ret, tFOutput, tSChannel - 1) = False Then
                Return False
            End If


        ElseIf tDacMode = eDacMode.ePulseMode Then

            If Set_PulseOneChannel(inAddrs, inch, ret, tPulseSet, tSChannel - 1) = False Then
                Return False
            End If


        End If




        'Dim Mode As eDacMode
        'Dim DCOutputCh As eFoutput
        'Dim dBias As Double
        'Dim dAmplitude As Double
        'Dim PulseParam As sPulseParam



        Return True
    End Function
    Public Function SubPower_BiasSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel() As Integer, ByVal inSetPara() As sSettingParam) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer
        Dim inModeType As eModeType = eModeType.eSubPower


        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If
        Dim tBias As Double
        Dim tAmplitude As Double


        Dim tDacBias() As Double = Nothing
        Dim tDacMode() As eDacMode = Nothing
        Dim tFOutput() As eFoutput = Nothing
        Dim tPulseSet() As sPulseParam = Nothing


        '''''''''''''''' Dac Mode 설정 전체 읽기
        If Get_SelectModeAllChannel(inAddrs, inch, ret, tDacMode) = False Then
            Return False
        End If
        '''''''''''''''' Dac Foutput 설정 전체 읽기
        If Get_FinalOutputAllChannel(inAddrs, inch, ret, tFOutput) = False Then
            Return False
        End If
        '''''''''''''''' Dac Pulse 설정 전체 읽기
        If Get_PulseAllChannel(inAddrs, inch, ret, tPulseSet) = False Then
            Return False
        End If
        '''''''''''''''' Dac Pulse 설정 전체 읽기
        If Get_OutputAllChannel(inAddrs, inch, ret, tDacBias) = False Then
            Return False
        End If


        For Cnt = 0 To inSetChannel.Length - 1
            tDacMode((tSChannel - 1) + inSetChannel(Cnt)) = inSetPara(Cnt).Mode
            tFOutput((tSChannel - 1) + inSetChannel(Cnt)) = inSetPara(Cnt).DCOutputCh
            tPulseSet((tSChannel - 1) + inSetChannel(Cnt)) = inSetPara(Cnt).PulseParam
            If CalApply = True Then
                tBias = ConvertSet_DACLimitRange(tSChannel, inSetPara(Cnt).dBias) * Cal_DacSlope(tSChannel * 2 - 2) + Cal_DacOffset(tSChannel * 2 - 2)
                tAmplitude = ConvertSet_DACLimitRange(tSChannel, inSetPara(Cnt).dAmplitude) * Cal_DacSlope(tSChannel * 2 - 1) + Cal_DacOffset(tSChannel * 2 - 1)
            End If
            tDacBias(tSChannel * 2 - 2) = tBias
            tDacBias(tSChannel * 2 - 1) = tAmplitude
        Next

        '''''''''''''''' Dac Mode 전체 설정
        If Set_SelectModeAllChannel(inAddrs, inch, ret, tDacMode) = False Then
            Return False
        End If
        '''''''''''''''' Dac Foutput 전체 설정
        If Set_FinalOutputAllChannel(inAddrs, inch, ret, tFOutput) = False Then
            Return False
        End If
        '''''''''''''''' Dac Pulse 전체 설정
        If Set_PulseAllChannel(inAddrs, inch, ret, tPulseSet) = False Then
            Return False
        End If
        '''''''''''''''' Dac Output 전체 설정
        If Set_OutputAllChannel(inAddrs, inch, ret, tDacBias) = False Then
            Return False
        End If
        Return True
    End Function


    Public Function SubPower_On(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel() As Integer) As Boolean
        ''수정 필요 사용 X
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim inModeType As eModeType = eModeType.eSubPower

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer

        If ChkPowerChannel(inModeType, inSetChannel, tStartChannel) = False Then
            Return False
        End If




        If ConvertPowerChannel(inModeType, tStartChannel, tEndChannel) = False Then
            Return False
        End If


        Dim OnOffMode() As cDevSG.eOnOff = Nothing
        If Get_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then       '(에러코드 , 설정  Onoff 0:Off Mode , 1:On Mode  , max  채널 54)
            Return False
        End If

        For Cnt = 0 To inSetChannel.Length - 1
            OnOffMode((tStartChannel - 1) + inSetChannel(Cnt)) = eOnOff.eON
        Next

        'For Cnt = tStartChannel To tEndChannel
        '    OnOffMode(Cnt - 1) = eOnOff.eON
        'Next


        If Set_SyncAllChannel(inAddrs, inch, ret, OnOffMode) = False Then
            Return False
        End If
        '''''''''''''''' OnOff 설정

        Return True
    End Function
    Public Function SubPower_On(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer
        Dim inModeType As eModeType = eModeType.eSubPower

        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)

        If Set_OnoffOneChannel(inAddrs, inch, ret, eOnOff.eON, tSChannel) = False Then
            Return False
        End If
        '''''''''''''''' OnOff 설정

        ''''''''''''''GPO Output
        If inModeType = eModeType.eMainPower Then

            Dim SetValue() As Boolean = Nothing
            If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

                Return False
            End If
            For Cnt = 0 To SetValue.Length - 1
                If Cnt = inSetChannel Then
                    If SetValue(Cnt) = False Then
                        SetValue(Cnt) = True
                    End If
                End If
            Next

            Dim tBitNum As Double = 0
            For Cnt = 0 To SetValue.Length - 1
                If SetValue(Cnt) = True Then
                    tBitNum += 2 ^ Cnt
                End If
            Next

            Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        End If
        ''''''''''''''GPO Output

        Return True
    End Function
#End Region
#Region "Sig Power 0~25"
    Public Function SIGPower_Off(ByVal inAddrs As Integer, ByVal inch As Integer) As Boolean
        'Dim Cnt As Integer = 0
        'Dim ret As Integer = 0
        'Dim inModeType As eModeType = eModeType.eSignalPower
        'Dim OnOffMode() As cDevSG.eOnOff = Nothing
        'If Get_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then       '(에러코드 , 설정  Onoff 0:Off Mode , 1:On Mode  , max  채널 54)
        '    Return False
        'End If



        'Dim tStartChannel As Integer
        'Dim tEndChannel As Integer
        'ConvertPowerChannel(inModeType, tStartChannel, tEndChannel)
        'For Cnt = tStartChannel To tEndChannel
        '    OnOffMode(Cnt - 1) = eOnOff.eOFF
        'Next



        'If Set_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then
        '    Return False
        'End If

        ' ''''''''''''''GPO Output
        'If inModeType = eModeType.eMainPower Then



        '    Dim SetValue() As Boolean = Nothing
        '    If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

        '        Return False
        '    End If


        '    For Cnt = 0 To SetValue.Length - 1

        '        SetValue(Cnt) = False

        '    Next

        '    Dim tBitNum As Double = 0
        '    For Cnt = 0 To SetValue.Length - 1
        '        If SetValue(Cnt) = True Then
        '            tBitNum += 2 ^ Cnt
        '        End If
        '    Next

        '    Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        'End If
        ' ''''''''''''''GPO Output

        '//////sig off 시 DC 설정 으로 0 V Set On




        If PowerBiasSet(eModeType.eSignalPower, inAddrs, inch, 0, 0, False, eDacMode.eDCMode) = False Then
            Return False
        End If
        Dim tChannelArr() As Integer
        ReDim tChannelArr(25)
        For Cnt As Integer = 0 To tChannelArr.Length - 1
            tChannelArr(Cnt) = Cnt
        Next
        If SIGPower_On(inAddrs, inch, tChannelArr) = False Then
            Return False
        End If
        '//////sig off 시 DC 설정 으로 0 V Set On

        Return True
    End Function
    Public Function SIGPower_Off(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer) As Boolean
        'Dim Cnt As Integer = 0
        'Dim ret As Integer = 0
        'Dim inModeType As eModeType = eModeType.eSubPower

        'Dim tSChannel As Integer
        'If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
        '    Return False
        'End If

        'tSChannel = tSChannel + (inSetChannel - 1)

        'If Set_OnoffOneChannel(inAddrs, inch, ret, eOnOff.eOFF, tSChannel) = False Then
        '    Return False

        'End If


        ' ''''''''''''''GPO Output
        'If inModeType = eModeType.eMainPower Then



        '    Dim SetValue() As Boolean = Nothing
        '    If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

        '        Return False
        '    End If


        '    For Cnt = 0 To SetValue.Length - 1
        '        If Cnt = inSetChannel Then
        '            If SetValue(Cnt) = True Then
        '                SetValue(Cnt) = False
        '            End If
        '        End If
        '    Next

        '    Dim tBitNum As Double = 0
        '    For Cnt = 0 To SetValue.Length - 1
        '        If SetValue(Cnt) = True Then
        '            tBitNum += 2 ^ Cnt
        '        End If
        '    Next

        '    Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        'End If
        ' ''''''''''''''GPO Output

        '//////sig off 시 DC 설정 으로 0 V Set On
        Dim tSet As New sSettingParam
        tSet.dBias = 0
        tSet.DCOutputCh = eFoutput.eHigh
        tSet.Mode = eDacMode.eDCMode
        If SIGPower_BiasSet(inAddrs, inch, inSetChannel, tSet) = False Then
            Return False
        End If
        If SIGPower_On(inAddrs, inch, inSetChannel) = False Then
            Return False
        End If
        '//////sig off 시 DC 설정 으로 0 V Set On
        Return True
    End Function

    Public Function SIGPower_BiasSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByVal inSetPara As sSettingParam) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer
        Dim inModeType As eModeType = eModeType.eSignalPower


        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If
        tSChannel = tSChannel + (inSetChannel)



        Dim tBias As Double = ConvertSet_DACLimitRange(tSChannel, inSetPara.dBias)
        Dim tAmplitude As Double = ConvertSet_DACLimitRange(tSChannel, inSetPara.dAmplitude)


        Dim tDacMode As eDacMode = inSetPara.Mode
        Dim tFOutput As eFoutput = inSetPara.DCOutputCh
        Dim tPulseSet As sPulseParam = inSetPara.PulseParam


        If CalApply = True Then
            tBias = tBias * Cal_DacSlope(tSChannel * 2 - 2) + Cal_DacOffset(tSChannel * 2 - 2)
            tAmplitude = tAmplitude * Cal_DacSlope(tSChannel * 2 - 1) + Cal_DacOffset(tSChannel * 2 - 1)
        End If


        'High Bias Set
        If Set_OutputOneChannel(inAddrs, inch, ret, tBias, tSChannel * 2 - 2) = False Then
            Return False
        End If

        'Low Bias Set
        If Set_OutputOneChannel(inAddrs, inch, ret, tAmplitude, tSChannel * 2 - 1) = False Then
            Return False
        End If


        '''''''''''''''' Dac Mode 설정
        If Set_SelectModeOneChannel(inAddrs, inch, ret, tDacMode, tSChannel - 1) = False Then
            Return False

        End If
        '''''''''''''''' Dac Mode 설정


        If tDacMode = eDacMode.eDCMode Then

            If Set_FinalOutputOneChannel(inAddrs, inch, ret, tFOutput, tSChannel - 1) = False Then
                Return False
            End If


        ElseIf tDacMode = eDacMode.ePulseMode Then

            If Set_PulseOneChannel(inAddrs, inch, ret, tPulseSet, tSChannel - 1) = False Then
                Return False
            End If


        End If




        'Dim Mode As eDacMode
        'Dim DCOutputCh As eFoutput
        'Dim dBias As Double
        'Dim dAmplitude As Double
        'Dim PulseParam As sPulseParam



        Return True
    End Function
    Public Function SIGPower_BiasSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel() As Integer, ByVal inSetPara() As sSettingParam) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer
        Dim inModeType As eModeType = eModeType.eSignalPower


        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If
        Dim tBias As Double
        Dim tAmplitude As Double


        Dim tDacBias() As Double = Nothing
        Dim tDacMode() As eDacMode = Nothing
        Dim tFOutput() As eFoutput = Nothing
        Dim tPulseSet() As sPulseParam = Nothing


        '''''''''''''''' Dac Mode 설정 전체 읽기
        If Get_SelectModeAllChannel(inAddrs, inch, ret, tDacMode) = False Then
            Return False
        End If
        '''''''''''''''' Dac Foutput 설정 전체 읽기
        If Get_FinalOutputAllChannel(inAddrs, inch, ret, tFOutput) = False Then
            Return False
        End If
        '''''''''''''''' Dac Pulse 설정 전체 읽기
        If Get_PulseAllChannel(inAddrs, inch, ret, tPulseSet) = False Then
            Return False
        End If
        '''''''''''''''' Dac Pulse 설정 전체 읽기
        If Get_OutputAllChannel(inAddrs, inch, ret, tDacBias) = False Then
            Return False
        End If


        For Cnt = 0 To inSetChannel.Length - 1
            tDacMode((tSChannel - 1) + inSetChannel(Cnt)) = inSetPara(Cnt).Mode
            tFOutput((tSChannel - 1) + inSetChannel(Cnt)) = inSetPara(Cnt).DCOutputCh
            tPulseSet((tSChannel - 1) + inSetChannel(Cnt)) = inSetPara(Cnt).PulseParam
            If CalApply = True Then
                tBias = ConvertSet_DACLimitRange(tSChannel, inSetPara(Cnt).dBias) * Cal_DacSlope(tSChannel * 2 - 2) + Cal_DacOffset(tSChannel * 2 - 2)
                tAmplitude = ConvertSet_DACLimitRange(tSChannel, inSetPara(Cnt).dAmplitude) * Cal_DacSlope(tSChannel * 2 - 1) + Cal_DacOffset(tSChannel * 2 - 1)
            End If
            tDacBias(tSChannel * 2 - 2) = tBias
            tDacBias(tSChannel * 2 - 1) = tAmplitude
        Next

        '''''''''''''''' Dac Mode 전체 설정
        If Set_SelectModeAllChannel(inAddrs, inch, ret, tDacMode) = False Then
            Return False
        End If
        '''''''''''''''' Dac Foutput 전체 설정
        If Set_FinalOutputAllChannel(inAddrs, inch, ret, tFOutput) = False Then
            Return False
        End If
        '''''''''''''''' Dac Pulse 전체 설정
        If Set_PulseAllChannel(inAddrs, inch, ret, tPulseSet) = False Then
            Return False
        End If
        '''''''''''''''' Dac Output 전체 설정
        If Set_OutputAllChannel(inAddrs, inch, ret, tDacBias) = False Then
            Return False
        End If
        Return True
    End Function

    Public Function SIGPower_On(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel() As Integer) As Boolean
        ''수정 필요 사용 X
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim inModeType As eModeType = eModeType.eSignalPower

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer

        If ChkPowerChannel(inModeType, inSetChannel, tStartChannel) = False Then
            Return False
        End If


        If ConvertPowerChannel(inModeType, tStartChannel, tEndChannel) = False Then
            Return False
        End If


        Dim OnOffMode() As cDevSG.eOnOff = Nothing
        If Get_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then       '(에러코드 , 설정  Onoff 0:Off Mode , 1:On Mode  , max  채널 54)
            Return False
        End If


        For Cnt = 0 To inSetChannel.Length - 1
            OnOffMode((tStartChannel - 1) + inSetChannel(Cnt)) = eOnOff.eON
        Next
        'For Cnt = tStartChannel To tEndChannel
        '    OnOffMode(Cnt - 1) = eOnOff.eON
        'Next


        If Set_SyncAllChannel(inAddrs, inch, ret, OnOffMode) = False Then
            Return False
        End If
        '''''''''''''''' OnOff 설정

        ''''''''''''''GPO Output
        If inModeType = eModeType.eMainPower Then



            Dim SetValue() As Boolean = Nothing
            If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

                Return False
            End If

            ''수정 필요
            For Cnt = 0 To Max_ADC_Limit_Channel - 1


                If SetValue(Cnt) = False Then
                    SetValue(Cnt) = True
                End If

            Next

            Dim tBitNum As Double = 0
            For Cnt = 0 To SetValue.Length - 1
                If SetValue(Cnt) = True Then
                    tBitNum += 2 ^ Cnt
                End If
            Next

            Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        End If
        ''''''''''''''GPO Output
        Return True
    End Function
    Public Function SIGPower_On(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer
        Dim inModeType As eModeType = eModeType.eSignalPower

        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)

        If Set_OnoffOneChannel(inAddrs, inch, ret, eOnOff.eON, tSChannel) = False Then
            Return False
        End If
        '''''''''''''''' OnOff 설정

        ''''''''''''''GPO Output
        If inModeType = eModeType.eMainPower Then

            Dim SetValue() As Boolean = Nothing
            If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

                Return False
            End If
            For Cnt = 0 To SetValue.Length - 1
                If Cnt = inSetChannel Then
                    If SetValue(Cnt) = False Then
                        SetValue(Cnt) = True
                    End If
                End If
            Next

            Dim tBitNum As Double = 0
            For Cnt = 0 To SetValue.Length - 1
                If SetValue(Cnt) = True Then
                    tBitNum += 2 ^ Cnt
                End If
            Next

            Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        End If
        ''''''''''''''GPO Output

        Return True
    End Function
#End Region

#Region "PD 0 ~ 23"
    Public Function PD_Meas(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef OutPDValue() As Double) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim ReadValue() As Double = Nothing
        Dim inSenseType As eSenseType = eSenseType.ePD
        If Get_ReadADcAllChannel(inAddrs, inch, ret, ReadValue) = False Then

            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer

        ConvertSenseChannel(inSenseType, tStartChannel, tEndChannel)
        ReDim OutPDValue(tEndChannel - tStartChannel)


        For Cnt = tStartChannel To tEndChannel
            If CalApply = False Then
                OutPDValue(Cnt - tStartChannel) = ConvertGet_ADCLimitRange(tStartChannel, ReadValue(Cnt - 1))
            ElseIf CalApply = True Then

                OutPDValue(Cnt - tStartChannel) = ConvertGet_ADCLimitRange(tStartChannel, ReadValue(Cnt - 1)) * Cal_AdcSlope(Cnt - 1) + Cal_AdcOffset(Cnt - 1)
            End If

        Next



        Return True
    End Function
    Public Function PD_Meas(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByRef OutPDValue As Double) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim inSenseType As eSenseType = eSenseType.ePD
        Dim tSChannel As Integer
        Dim ReadValue As Double

        If ChkSenseChannel(inSenseType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)

        '읽는 부분 수정
        ''Dim ReadValue1() As Double = Nothing
        ''If Get_ReadADcAllChannel(inAddrs, inch, ret, ReadValue1) = False Then

        ''    Return False
        ''End If


        ''Dim tStartChannel As Integer
        ''Dim tEndChannel As Integer


        ''ConvertSenseChannel(inSenseType, tStartChannel, tEndChannel)


        ''If CalApply = False Then
        ''    ReadValue = ConvertGet_ADCLimitRange(tSChannel, ReadValue1(tStartChannel - 1 + inSetChannel))
        ''Else
        ''    ReadValue = ConvertGet_ADCLimitRange(tSChannel, ReadValue1(tStartChannel - 1 + inSetChannel)) * Cal_AdcSlope(tSChannel) + Cal_AdcOffset(tSChannel)
        ''End If


        ''OutPDValue = ReadValue
        '읽는 부분 수정




        If Get_ReadADcOneChannel(inAddrs, inch, ret, ReadValue, tSChannel) = False Then

            Return False
        End If


        If CalApply = False Then
            ReadValue = ConvertGet_ADCLimitRange(tSChannel + 1, ReadValue)
        ElseIf CalApply = True Then

            ReadValue = ConvertGet_ADCLimitRange(tSChannel + 1, ReadValue) * Cal_AdcSlope(tSChannel) + Cal_AdcOffset(tSChannel)
        End If


        OutPDValue = ReadValue

        Return True
    End Function

    Public Function PD_AverLimitSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal InSetLimit As sLimit) As Boolean

        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim inSenseType As eSenseType = eSenseType.ePD
        Dim ReadValue() As Double = Nothing

        If Get_ADcAverCountAllChannel(inAddrs, inch, ret, ReadValue) = False Then

            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer

        ConvertSenseChannel(inSenseType, tStartChannel, tEndChannel)


        For Cnt = tStartChannel To tEndChannel
            ReadValue(Cnt - 1) = InSetLimit.nAverCount
        Next


        If Set_ADcAverCountAllChannel(inAddrs, inch, ret, ReadValue) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function PD_AverLimitSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByVal nAvgCount As Integer) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim inSenseType As eSenseType = eSenseType.ePD
        Dim tSChannel As Integer

        If ChkSenseChannel(inSenseType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)


        If Set_ADcAverCountOneChannel(inAddrs, inch, ret, nAvgCount, tSChannel) = False Then
            Return False
        End If

        Dim retAvgCnt As Integer = 0

        If Get_ADcAverCountOneChannel(inAddrs, inch, ret, retAvgCnt, tSChannel) = False Then
            Return False
        End If


        Return True
    End Function
    Public Function PD_AverLimitSet(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel() As Integer, ByVal InSetLimit() As sLimit) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim inSenseType As eSenseType = eSenseType.ePD
        Dim tSChannel As Integer

        If ChkSenseChannel(inSenseType, inSetChannel, tSChannel) = False Then
            Return False
        End If


        'Average Count Set
        Dim ReadCount() As Double = Nothing
        If Get_ADcAverCountAllChannel(inAddrs, inch, ret, ReadCount) = False Then
            Return False
        End If
        For Cnt = 0 To inSetChannel.Length - 1
            ReadCount((tSChannel - 1) + inSetChannel(Cnt)) = InSetLimit(Cnt).nAverCount
        Next
        If Set_ADcAverCountAllChannel(inAddrs, inch, ret, ReadCount) = False Then
            Return False
        End If
        'Average Count Set

        Return True
    End Function

#End Region
#End Region





#Region "MainFunction"

#Region "Property"

    Public Property MainPowerStartChannel() As Integer
        Get
            Return m_MainPower_Schannel
        End Get
        Set(ByVal value As Integer)
            If value >= m_MainPower_Echannel Then
                MsgBox("End Channel 보다 크거나 같을 수 없습니다(Can not be greater than or equal to End Channel)!!")
            Else
                m_MainPower_Schannel = value
            End If

        End Set
    End Property
    Public Property MainPowerEndChannel() As Integer
        Get
            Return m_MainPower_Echannel
        End Get
        Set(ByVal value As Integer)
            If value <= m_MainPower_Schannel Then
                MsgBox("Start Channel 보다 작거나 같을 수 없습니다(Can not be less than or equal to Start Channel)!!")
            Else
                m_MainPower_Echannel = value
            End If

        End Set
    End Property
    Public Property SubPowerStartChannel() As Integer
        Get
            Return m_SubPower_Schannel
        End Get
        Set(ByVal value As Integer)
            If value >= m_SubPower_Echannel Then
                MsgBox("End Channel 보다 크거나 같을 수 없습니다(Can not be greater than or equal to End Channel)!!")
            Else
                m_SubPower_Schannel = value
            End If

        End Set
    End Property
    Public Property SubPowerEndChannel() As Integer
        Get
            Return m_SubPower_Echannel
        End Get
        Set(ByVal value As Integer)
            If value <= m_SubPower_Schannel Then
                MsgBox("Start Channel 보다 작거나 같을 수 없습니다(Can not be less than or equal to Start Channel)!!")
            Else
                m_SubPower_Echannel = value
            End If

        End Set
    End Property
    Public Property SignalPowerStartChannel() As Integer
        Get
            Return m_Signal_Schannel
        End Get
        Set(ByVal value As Integer)
            If value >= m_Signal_Echannel Then
                MsgBox("End Channel 보다 크거나 같을 수 없습니다(Can not be greater than or equal to End Channel)!!")
            Else
                m_Signal_Schannel = value
            End If

        End Set
    End Property
    Public Property SignalPowerEndChannel() As Integer
        Get
            Return m_Signal_Echannel
        End Get
        Set(ByVal value As Integer)
            If value <= m_Signal_Schannel Then
                MsgBox("Start Channel 보다 작거나 같을 수 없습니다(Can not be less than or equal to Start Channel)!!")
            Else
                m_Signal_Echannel = value
            End If

        End Set
    End Property
    Public Property PDSenseStartChannel() As Integer
        Get
            Return m_PDSense_Schannel
        End Get
        Set(ByVal value As Integer)
            If value >= m_PDSense_Echannel Then
                MsgBox("End Channel 보다 크거나 같을 수 없습니다(Can not be greater than or equal to End Channel)!!")
            Else
                m_PDSense_Schannel = value
            End If

        End Set
    End Property
    Public Property PDSenseEndChannel() As Integer
        Get
            Return m_PDSense_Echannel
        End Get
        Set(ByVal value As Integer)
            If value <= m_PDSense_Schannel Then
                MsgBox("Start Channel 보다 작거나 같을 수 없습니다(Can not be less than or equal to Start Channel)!!")
            Else
                m_PDSense_Echannel = value
            End If

        End Set
    End Property
    Public Property TempSenserStartChannel() As Integer
        Get
            Return m_TempSense_Schannel
        End Get
        Set(ByVal value As Integer)
            If value >= m_TempSense_Echannel Then
                MsgBox("End Channel 보다 크거나 같을 수 없습니다(Can not be greater than or equal to End Channel)!!")
            Else
                m_TempSense_Schannel = value
            End If

        End Set
    End Property
    Public Property TempSenseEndChannel() As Integer
        Get
            Return m_TempSense_Echannel
        End Get
        Set(ByVal value As Integer)
            If value <= m_TempSense_Schannel Then
                MsgBox("Start Channel 보다 작거나 같을 수 없습니다(Can not be less than or equal to Start Channel)!!")
            Else
                m_TempSense_Echannel = value
            End If

        End Set
    End Property
    Public Property CurrentSenseStartChannel() As Integer
        Get
            Return m_CurrentSense_Schannel
        End Get
        Set(ByVal value As Integer)
            If value >= m_CurrentSense_Echannel Then
                MsgBox("End Channel 보다 크거나 같을 수 없습니다(Can not be greater than or equal to End Channel)!!")
            Else
                m_CurrentSense_Schannel = value
            End If

        End Set
    End Property
    Public Property CurrentSenseEndChannel() As Integer
        Get
            Return m_CurrentSense_Echannel
        End Get
        Set(ByVal value As Integer)
            If value <= m_CurrentSense_Schannel Then
                MsgBox("Start Channel 보다 작거나 같을 수 없습니다(Can not be less than or equal to Start Channel)!!")
            Else
                m_CurrentSense_Echannel = value
            End If

        End Set
    End Property

    Public ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property
#End Region

#Region "Init"

    Public Function PowerReadCal(ByVal inAddrs As Integer, ByVal inch As Integer) As Boolean
        Dim ret As Integer
        ReDim Cal_DacSlope(Max_DAC_Channel - 1)
        ReDim Cal_DacOffset(Max_DAC_Channel - 1)


        For Cnt As Integer = 0 To Max_DAC_Channel - 1


            If Get_DacSlope(inAddrs, inch, ret, Cal_DacSlope(Cnt), Cnt) = False Then
                Return False
            End If
            Application.DoEvents()
            Thread.Sleep(10)
            If Get_DacOffset(inAddrs, inch, ret, Cal_DacOffset(Cnt), Cnt) = False Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function SenseReadCal(ByVal inAddrs As Integer, ByVal inch As Integer) As Boolean
        Dim ret As Integer
        ReDim Cal_AdcSlope(Max_ADC_Channel - 1)
        ReDim Cal_AdcOffset(Max_ADC_Channel - 1)


        For Cnt As Integer = 0 To Max_ADC_Channel - 1

            If Get_ADcSlope(inAddrs, inch, ret, Cal_AdcSlope(Cnt), Cnt) = False Then
                Return False
            End If
            Application.DoEvents()
            Thread.Sleep(10)
            If Get_ADcOffset(inAddrs, inch, ret, Cal_AdcOffset(Cnt), Cnt) = False Then
                Return False
            End If


        Next
        Return True
    End Function
#End Region


#Region "Adc Sense"
    Public Function ChkSenseChannel(ByVal inSenseType As eSenseType, ByVal inSetChannel As Integer, ByRef OutStartChannel As Integer) As Boolean

        If inSenseType = eSenseType.ePD Then
            Dim tSum As Integer = (m_PDSense_Echannel - m_PDSense_Schannel) + 1
            If tSum < 0 Then
                MsgBox("The channel number is incorrect.!!")
                Return False
            End If

            If tSum < inSetChannel Then
                MsgBox("The channel number is incorrect.!!")
                Return False
            End If

            OutStartChannel = m_PDSense_Schannel

        ElseIf inSenseType = eSenseType.eTemp Then
            Dim tSum As Integer = (m_TempSense_Echannel - m_TempSense_Schannel) + 1
            If tSum < 0 Then
                MsgBox("The channel number is incorrect.!!")
                Return False
            End If

            If tSum < inSetChannel Then
                MsgBox("The channel number is incorrect.!!")
                Return False
            End If

            OutStartChannel = m_TempSense_Schannel

        ElseIf inSenseType = eSenseType.eCurrent Then
            Dim tSum As Integer = (m_CurrentSense_Echannel - m_CurrentSense_Schannel) + 1
            If tSum < 0 Then
                MsgBox("The channel number is incorrect.!!")
                Return False
            End If

            If tSum < inSetChannel Then
                MsgBox("The channel number is incorrect.!!")
                Return False
            End If

            OutStartChannel = m_CurrentSense_Schannel

        End If

        Return True
    End Function
    Public Function ChkSenseChannel(ByVal inSenseType As eSenseType, ByVal inSetChannel() As Integer, ByRef OutStartChannel As Integer) As Boolean
        Dim nCnt As Integer
        For nCnt = 0 To inSetChannel.Length - 1


            If inSenseType = eSenseType.ePD Then
                Dim tSum As Integer = (m_PDSense_Echannel - m_PDSense_Schannel) + 1
                If tSum < 0 Then
                    MsgBox("The channel number is incorrect.!!")
                    Return False
                End If

                If tSum < inSetChannel(nCnt) Then
                    MsgBox("The channel number is incorrect.!!")
                    Return False
                End If

                OutStartChannel = m_PDSense_Schannel

            ElseIf inSenseType = eSenseType.eTemp Then
                Dim tSum As Integer = (m_TempSense_Echannel - m_TempSense_Schannel) + 1
                If tSum < 0 Then
                    MsgBox("The channel number is incorrect.!!")
                    Return False
                End If

                If tSum < inSetChannel(nCnt) Then
                    MsgBox("The channel number is incorrect.!!")
                    Return False
                End If

                OutStartChannel = m_TempSense_Schannel

            ElseIf inSenseType = eSenseType.eCurrent Then
                Dim tSum As Integer = (m_CurrentSense_Echannel - m_CurrentSense_Schannel) + 1
                If tSum < 0 Then
                    MsgBox("The channel number is incorrect.!!")
                    Return False
                End If

                If tSum < inSetChannel(nCnt) Then
                    MsgBox("The channel number is incorrect.!!")
                    Return False
                End If

                OutStartChannel = m_CurrentSense_Schannel

            End If
        Next
        Return True
    End Function
    Public Function ConvertSenseChannel(ByVal inSenseType As eSenseType, ByRef OutStartChannel As Integer, ByRef OutEndChannel As Integer) As Boolean

        If inSenseType = eSenseType.ePD Then
            OutStartChannel = m_PDSense_Schannel
            OutEndChannel = m_PDSense_Echannel
        ElseIf inSenseType = eSenseType.eTemp Then
            OutStartChannel = m_TempSense_Schannel
            OutEndChannel = m_TempSense_Echannel
        ElseIf inSenseType = eSenseType.eCurrent Then

            OutStartChannel = m_CurrentSense_Schannel
            OutEndChannel = m_CurrentSense_Echannel
        End If
        Return True
    End Function
    Public Function LimitClear(ByVal inAddrs As Integer, ByVal inch As Integer) As Boolean

        Dim ret As Integer

        If cResisterInit(inAddrs, inch, ret) = False Then
            Return False
        End If


        Return True
    End Function
    Public Function LimitCurrAlarmChk(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef OutAlarm() As eLimitAlarm) As Boolean
        'Limit curr 알람 확인
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim ReadAlarm() As eLimitAlarm = Nothing

        If Get_LimitAlarm(inAddrs, inch, ret, ReadAlarm) = False Then


            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer

        ConvertSenseChannel(eSenseType.eCurrent, tStartChannel, tEndChannel)

        ReDim OutAlarm(tEndChannel - tStartChannel)

        For Cnt = tStartChannel To tEndChannel
            OutAlarm(Cnt - tStartChannel) = ReadAlarm(Cnt - 1)
        Next



        Return True
    End Function
    Public Function LimitCurrAlarmChk(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByRef OutAlarm As eLimitAlarm) As Boolean
        'Limit curr 알람 확인
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim tSChannel As Integer
        Dim ReadAlarm() As eLimitAlarm = Nothing

        If ChkSenseChannel(eSenseType.eCurrent, inSetChannel, tSChannel) = False Then
            Return False
        End If



        If Get_LimitAlarm(inAddrs, inch, ret, ReadAlarm) = False Then

            Return False
        End If

        OutAlarm = ReadAlarm(inSetChannel - 1)

        Return True
    End Function
    Public Function LimitTempAlarmChk(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef OutAlarm() As eLimitAlarm) As Boolean
        'Limit 온도 알람 확인
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim ReadAlarm() As eLimitAlarm = Nothing

        If Get_LimitAlarm(inAddrs, inch, ret, ReadAlarm) = False Then


            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer

        ConvertSenseChannel(eSenseType.eTemp, tStartChannel, tEndChannel)

        ReDim OutAlarm(tEndChannel - tStartChannel)

        For Cnt = tStartChannel To tEndChannel
            OutAlarm(Cnt - tStartChannel) = ReadAlarm(Cnt - 1)
        Next



        Return True
    End Function
    Public Function LimitTempAlarmChk(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByRef OutAlarm As eLimitAlarm) As Boolean
        'Limit 온도 알람 확인
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim tSChannel As Integer
        Dim ReadAlarm() As eLimitAlarm = Nothing

        If ChkSenseChannel(eSenseType.eTemp, inSetChannel, tSChannel) = False Then
            Return False
        End If



        If Get_LimitAlarm(inAddrs, inch, ret, ReadAlarm) = False Then

            Return False
        End If

        OutAlarm = ReadAlarm(inSetChannel - 1)

        Return True
    End Function
    Public Function LimitTempSetSense(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal InSetLimitTemp As Double) As Boolean
        'Temp Sense 만 해당
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSetTempLimit As Integer = (InSetLimitTemp * 10) / 150 - 5
        Dim ReadValue() As Double = Nothing

        If Get_ADcTempLimitAllChannel(inAddrs, inch, ret, ReadValue) = False Then

            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer

        ConvertSenseChannel(eSenseType.eTemp, tStartChannel, tEndChannel)

        For Cnt = 0 To ReadValue.Length - 1

            'If inCalApply = False Then
            '    tSetTempLimit = tSetTempLimit
            'ElseIf inCalApply = True Then
            '    'tSetTempLimit = InSetLimitTemp
            '    tSetTempLimit = tSetTempLimit * Cal_AdcSlope(Cnt - 1) + Cal_AdcOffset(Cnt - 1)
            'End If
            ReadValue(Cnt) = tSetTempLimit
        Next


        If Set_ADcTempLimitAllChannel(inAddrs, inch, ret, ReadValue) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function LimitTempSetSense(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByVal InSetLimitTemp As Integer) As Boolean
        'Temp Sense 만 해당
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSetTempLimit As Integer = (InSetLimitTemp * 10) / 150 - 5
        Dim tSChannel As Integer


        If ChkSenseChannel(eSenseType.eTemp, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)


        'If inCalApply = False Then
        '    tSetTempLimit = tSetTempLimit
        'ElseIf inCalApply = True Then
        '    'tSetTempLimit = InSetLimitTemp
        '    tSetTempLimit = tSetTempLimit * Cal_AdcSlope(tSChannel) + Cal_AdcOffset(tSChannel)
        'End If
        If Set_ADcTempLimitOneChannel(inAddrs, inch, ret, tSetTempLimit, 0) = False Then

            Return False
        End If




        Return True
    End Function
    Public Function LimitCurrSetSense(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal InSetLimitCurr As Integer) As Boolean
        'Current Sense 만 해당
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSetCurrLimit As Integer = ((InSetLimitCurr + 1) / 2) * 10 - 5
        Dim ReadValue() As Double = Nothing

        If Get_ADcLimitAllChannel(inAddrs, inch, ret, ReadValue) = False Then

            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer

        ConvertSenseChannel(eSenseType.eCurrent, tStartChannel, tEndChannel)


        For Cnt = 0 To ReadValue.Length - 1

            'If inCalApply = False Then
            '    tSetCurrLimit = tSetCurrLimit
            'ElseIf inCalApply = True Then
            '    'tSetTempLimit = InSetLimitTemp
            '    tSetCurrLimit = tSetCurrLimit * Cal_AdcSlope(Cnt - 1) + Cal_AdcOffset(Cnt - 1)
            'End If
            ReadValue(Cnt) = tSetCurrLimit
        Next


        If Set_ADcLimitAllChannel(inAddrs, inch, ret, ReadValue) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function LimitCurrSetSense(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByVal inSetLimitCurr As Integer) As Boolean
        'Current Sense 만 해당
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSetCurrLimit As Integer = ((inSetLimitCurr + 1) / 2) * 10 - 5
        Dim tSChannel As Integer

        If ChkSenseChannel(eSenseType.eCurrent, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)

        'If inCalApply = False Then
        '    tSetCurrLimit = tSetCurrLimit
        'ElseIf inCalApply = True Then
        '    'tSetTempLimit = InSetLimitTemp
        '    tSetCurrLimit = tSetCurrLimit * Cal_AdcSlope(tSChannel) + Cal_AdcOffset(tSChannel)
        'End If
        If Set_ADcLimitOneChannel(inAddrs, inch, ret, tSetCurrLimit, inSetChannel) = False Then

            Return False
        End If




        Return True
    End Function
    Public Function AverageSetSense(ByVal inSenseType As eSenseType, ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetAver As Integer) As Boolean

        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim ReadValue() As Double = Nothing

        If Get_ADcAverCountAllChannel(inAddrs, inch, ret, ReadValue) = False Then

            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer

        ConvertSenseChannel(inSenseType, tStartChannel, tEndChannel)


        For Cnt = tStartChannel To tEndChannel
            ReadValue(Cnt - 1) = inSetAver
        Next


        If Set_ADcAverCountAllChannel(inAddrs, inch, ret, ReadValue) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function AverageSetSense(ByVal inSenseType As eSenseType, ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByVal inSetAver As Integer) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim tSChannel As Integer

        If ChkSenseChannel(inSenseType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)


        If Set_ADcAverCountOneChannel(inAddrs, inch, ret, inSetAver, tSChannel) = False Then

            Return False
        End If




        Return True
    End Function
    Public Function ReadSense(ByVal inSenseType As eSenseType, ByVal inAddrs As Integer, ByVal inch As Integer, ByRef OutPDValue() As Double, ByVal inCalApply As Boolean) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim ReadValue() As Double = Nothing

        If Get_ReadADcAllChannel(inAddrs, inch, ret, ReadValue) = False Then

            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer

        ConvertSenseChannel(inSenseType, tStartChannel, tEndChannel)
        ReDim OutPDValue(tEndChannel - tStartChannel)


        For Cnt = tStartChannel To tEndChannel
            If inCalApply = False Then
                OutPDValue(Cnt - tStartChannel) = ReadValue(Cnt - 1)
            ElseIf inCalApply = True Then

                OutPDValue(Cnt - tStartChannel) = ReadValue(Cnt - 1) * Cal_AdcSlope(Cnt - 1) + Cal_AdcOffset(Cnt - 1)
            End If

        Next



        Return True
    End Function
    Public Function ReadSense(ByVal inSenseType As eSenseType, ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByRef OutValue As Double, ByVal inCalApply As Boolean) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim tSChannel As Integer
        Dim ReadValue As Double

        If ChkSenseChannel(inSenseType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)


        If Get_ReadADcOneChannel(inAddrs, inch, ret, ReadValue, tSChannel) = False Then

            Return False
        End If


        If inCalApply = False Then
            ReadValue = ReadValue
        ElseIf inCalApply = True Then

            ReadValue = ReadValue * Cal_AdcSlope(tSChannel) + Cal_AdcOffset(tSChannel)
        End If


        If inSenseType = eSenseType.ePD Then
            ReadValue = (5 + ReadValue) / 10 * 200 - 100
        ElseIf inSenseType = eSenseType.eCurrent Then
            ReadValue = (5 + ReadValue) / 10 * 150
        ElseIf inSenseType = eSenseType.eTemp Then
            ReadValue = (5 + ReadValue) / 10 * 2 - 1
        End If

        OutValue = ReadValue

        Return True
    End Function
#End Region
#Region "Dac Power"
    Public Function PowerPulseSet(ByVal inModeType As eModeType, ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inPulse As sPulseParam) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim PulseValue() As cDevSG.sPulseParam = Nothing


        If Get_PulseAllChannel(inAddrs, inch, ret, PulseValue) = False Then
            Return False
        End If
        Dim tStartChannel As Integer
        Dim tEndChannel As Integer
        ConvertPowerChannel(inModeType, tStartChannel, tEndChannel)

        For Cnt = tStartChannel To tEndChannel

            PulseValue(Cnt - 1) = inPulse

        Next



        If Set_PulseAllChannel(inAddrs, inch, ret, PulseValue) = False Then
            Return False

        End If


        Return True
    End Function
    Public Function PowerPulseSet(ByVal inModeType As eModeType, ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByVal inPulse As sPulseParam) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer
        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)
        If Set_PulseOneChannel(inAddrs, inch, ret, inPulse, tSChannel) = False Then
            Return False

        End If


        Return True
    End Function
    Public Function PowerFinalOutput(ByVal inModeType As eModeType, ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inMode As eFoutput) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim FinalOutput() As cDevSG.eFoutput = Nothing 'max ch 54
        If Get_FinalOutputAllChannel(inAddrs, inch, ret, FinalOutput) = False Then       '(에러코드 , 설정  Onoff 0:Off Mode , 1:On Mode  , max  채널 54)
            Return False
        End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer
        ConvertPowerChannel(inModeType, tStartChannel, tEndChannel)

        For Cnt = tStartChannel To tEndChannel
            FinalOutput(Cnt - 1) = inMode
        Next


        'For Cnt = 0 To FinalOutput.Length - 1

        '    If Cnt >= (m_MainPower_Schannel - 1) And Cnt <= (m_MainPower_Echannel - 1) Then
        '        FinalOutput(Cnt) = inMode
        '    End If
        'Next

        If Set_FinalOutputAllChannel(inAddrs, inch, ret, FinalOutput) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function PowerFinalOutput(ByVal inModeType As eModeType, ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByVal inMode As eFoutput) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer
        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)
        If Set_FinalOutputOneChannel(inAddrs, inch, ret, inMode, tSChannel) = False Then
            Return False

        End If
        Return True
    End Function
    Public Function PowerBiasSet(ByVal inModeType As eModeType, ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inBiasHigh As Double, ByVal inBiasLow As Double, ByVal inCalApply As Boolean, ByVal inDacMode As eDacMode) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0


        Dim tStartChannel As Integer
        Dim tEndChannel As Integer
        ConvertPowerChannel(inModeType, tStartChannel, tEndChannel)

        '''''''''''''''' Dac Mode 설정
        Dim SetMode() As cDevSG.eDacMode = Nothing 'max ch54

        If Get_SelectModeAllChannel(inAddrs, inch, ret, SetMode) = False Then
            Return False
        End If



        For Cnt = tStartChannel To tEndChannel
            SetMode(Cnt - 1) = inDacMode
        Next


        If Set_SelectModeAllChannel(inAddrs, inch, ret, SetMode) = False Then
            Return False
        End If

        Thread.Sleep(300)
        '''''''''''''''' Dac Mode 설정


        Dim ReadValue() As Double = Nothing

        If Get_OutputAllChannel(inAddrs, inch, ret, ReadValue) = False Then

            Return False
        End If




        For Cnt = (tStartChannel) To (tEndChannel)




            If inCalApply = False Then
                ReadValue(Cnt * 2 - 2) = inBiasHigh

                ReadValue(Cnt * 2 - 1) = inBiasLow






            ElseIf inCalApply = True Then

                ReadValue(Cnt * 2 - 2) = inBiasHigh * Cal_DacSlope(Cnt * 2 - 2) + Cal_DacOffset(Cnt * 2 - 2)

                ReadValue(Cnt * 2 - 1) = inBiasLow * Cal_DacSlope(Cnt * 2 - 1) + Cal_DacOffset(Cnt * 2 - 1)

            End If

        Next
        If Set_OutputAllChannel(inAddrs, inch, ret, ReadValue) = False Then
            Return False
        End If

        Return True
    End Function
    Public Function PowerBiasSet(ByVal inModeType As eModeType, ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer, ByVal inBiasHigh As Double, ByVal inBiasLow As Double, ByVal inCalApply As Boolean, ByVal inDacMode As eDacMode) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer
        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If


        tSChannel = tSChannel + (inSetChannel)



        If inCalApply = False Then



            'High Bias Set
            If Set_OutputOneChannel(inAddrs, inch, ret, inBiasHigh, tSChannel * 2 - 2) = False Then
                Return False

            End If

            'Low Bias Set
            If Set_OutputOneChannel(inAddrs, inch, ret, inBiasLow, tSChannel * 2 - 1) = False Then
                Return False

            End If



        ElseIf inCalApply = True Then


            inBiasHigh = inBiasHigh * Cal_DacSlope(tSChannel * 2 - 2) + Cal_DacOffset(tSChannel * 2 - 2)
            'High Bias Set
            If Set_OutputOneChannel(inAddrs, inch, ret, inBiasHigh, tSChannel * 2 - 2) = False Then
                Return False

            End If
            inBiasLow = inBiasLow * Cal_DacSlope(tSChannel * 2 - 1) + Cal_DacOffset(tSChannel * 2 - 1)
            'Low Bias Set
            If Set_OutputOneChannel(inAddrs, inch, ret, inBiasLow, tSChannel * 2 - 1) = False Then
                Return False

            End If

        End If


        '''''''''''''''' Dac Mode 설정
        If Set_SelectModeOneChannel(inAddrs, inch, ret, inDacMode, tSChannel - 1) = False Then
            Return False

        End If
        '''''''''''''''' Dac Mode 설정

        ''High Bias Set
        'If Set_OutputOneChannel(inAddrs, inch, ret, inBiasHigh, tSChannel * 2 - 1) = False Then
        '    Return False

        'End If

        ''Low Bias Set
        'If Set_OutputOneChannel(inAddrs, inch, ret, inBiasLow, tSChannel * 2) = False Then
        '    Return False

        'End If





        Return True
    End Function
    Public Function PowerOn(ByVal inModeType As eModeType, ByVal inAddrs As Integer, ByVal inch As Integer) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0




        '''''''''''''''' Dac Mode 설정
        'Dim SetMode() As cDevSG.eDacMode 'max ch54

        'If Get_SelectModeAllChannel(inAddrs, inch, ret, SetMode) = False Then
        '    Return False
        'End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer
        ConvertPowerChannel(inModeType, tStartChannel, tEndChannel)

        'For Cnt = tStartChannel To tEndChannel
        '    SetMode(Cnt - 1) = inDacMode
        'Next


        'If Set_SelectModeAllChannel(inAddrs, inch, ret, SetMode) = False Then
        '    Return False
        'End If
        '''''''''''''''' Dac Mode 설정



        '''''''''''''''' OnOff 설정
        Dim OnOffMode() As cDevSG.eOnOff = Nothing


        If Get_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then       '(에러코드 , 설정  Onoff 0:Off Mode , 1:On Mode  , max  채널 54)

            Return False
        End If



        For Cnt = tStartChannel To tEndChannel
            OnOffMode(Cnt - 1) = eOnOff.eON
        Next

        If Set_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then
            Return False
        End If
        '''''''''''''''' OnOff 설정

        ''''''''''''''GPO Output
        If inModeType = eModeType.eMainPower Then



            Dim SetValue() As Boolean = Nothing
            If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

                Return False
            End If


            For Cnt = 0 To SetValue.Length - 1
                SetValue(Cnt) = True
            Next

            Dim tBitNum As Double = 0
            For Cnt = 0 To SetValue.Length - 1
                If SetValue(Cnt) = True Then
                    tBitNum += 2 ^ Cnt
                End If
            Next

            Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        End If
        ''''''''''''''GPO Output
        Return True

    End Function
    Public Function PowerSyncOn(ByVal inModeType As eModeType, ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel() As Integer) As Boolean
        ''수정 필요 사용 X
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer

        If inSetChannel Is Nothing Then
            MsgBox("Channel Data Nothing")
            Return False
        End If


        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If


        '''''''''''''''' Dac Mode 설정
        'Dim SetMode() As cDevSG.eDacMode 'max ch54

        'If Get_SelectModeAllChannel(inAddrs, inch, ret, SetMode) = False Then
        '    Return False
        'End If

        Dim tStartChannel As Integer
        Dim tEndChannel As Integer
        ConvertPowerChannel(inModeType, tStartChannel, tEndChannel)

        'For Cnt = 0 To inSetChannel.Length - 1

        '    SetMode(inSetChannel(Cnt)) = eDacMode.ePulseMode
        'Next


        'If Set_SelectModeAllChannel(inAddrs, inch, ret, SetMode) = False Then
        '    Return False
        'End If
        '''''''''''''''' Dac Mode 설정


        '''''''''''''''' OnOff 설정
        Dim OnOffMode() As cDevSG.eOnOff = Nothing


        If Get_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then       '(에러코드 , 설정  Onoff 0:Off Mode , 1:On Mode  , max  채널 54)

            Return False
        End If


        For Cnt = 0 To inSetChannel.Length - 1

            OnOffMode(tStartChannel + (inSetChannel(Cnt) - 1)) = eOnOff.eON
        Next



        If Set_SyncAllChannel(inAddrs, inch, ret, OnOffMode) = False Then
            Return False
        End If
        '''''''''''''''' OnOff 설정

        ''''''''''''''GPO Output
        If inModeType = eModeType.eMainPower Then



            Dim SetValue() As Boolean = Nothing
            If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

                Return False
            End If

            ''수정 필요
            For Cnt = 0 To inSetChannel.Length - 1


                If SetValue(inSetChannel(Cnt)) = False Then
                    SetValue(inSetChannel(Cnt)) = True
                End If

            Next

            Dim tBitNum As Double = 0
            For Cnt = 0 To SetValue.Length - 1
                If SetValue(Cnt) = True Then
                    tBitNum += 2 ^ Cnt
                End If
            Next

            Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        End If
        ''''''''''''''GPO Output
        Return True
    End Function
    Public Function PowerOn(ByVal inModeType As eModeType, ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer
        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)
        '''''''''''''''' Dac Mode 설정
        'If Set_SelectModeOneChannel(inAddrs, inch, ret, inDacMode, tSChannel) = False Then
        '    Return False

        'End If
        '''''''''''''''' Dac Mode 설정


        '''''''''''''''' OnOff 설정
        If Set_OnoffOneChannel(inAddrs, inch, ret, eOnOff.eON, tSChannel) = False Then
            Return False

        End If
        '''''''''''''''' OnOff 설정

        ''''''''''''''GPO Output
        If inModeType = eModeType.eMainPower Then



            Dim SetValue() As Boolean = Nothing
            If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

                Return False
            End If


            For Cnt = 0 To SetValue.Length - 1
                If Cnt = inSetChannel Then
                    If SetValue(Cnt) = False Then
                        SetValue(Cnt) = True
                    End If
                End If
            Next

            Dim tBitNum As Double = 0
            For Cnt = 0 To SetValue.Length - 1
                If SetValue(Cnt) = True Then
                    tBitNum += 2 ^ Cnt
                End If
            Next

            Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        End If
        ''''''''''''''GPO Output

        Return True
    End Function
    Public Function PowerOff(ByVal inModeType As eModeType, ByVal inAddrs As Integer, ByVal inch As Integer) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0

        Dim OnOffMode() As cDevSG.eOnOff = Nothing


        If Get_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then       '(에러코드 , 설정  Onoff 0:Off Mode , 1:On Mode  , max  채널 54)

            Return False
        End If


        Dim tStartChannel As Integer
        Dim tEndChannel As Integer
        ConvertPowerChannel(inModeType, tStartChannel, tEndChannel)

        For Cnt = tStartChannel To tEndChannel
            OnOffMode(Cnt - 1) = eOnOff.eOFF
        Next

        If Set_OnOffAllChannel(inAddrs, inch, ret, OnOffMode) = False Then
            Return False
        End If

        ''''''''''''''GPO Output
        If inModeType = eModeType.eMainPower Then



            Dim SetValue() As Boolean = Nothing
            If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

                Return False
            End If


            For Cnt = 0 To SetValue.Length - 1

                SetValue(Cnt) = False

            Next

            Dim tBitNum As Double = 0
            For Cnt = 0 To SetValue.Length - 1
                If SetValue(Cnt) = True Then
                    tBitNum += 2 ^ Cnt
                End If
            Next

            Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        End If
        ''''''''''''''GPO Output
        Return True
    End Function
    Public Function PowerOff(ByVal inModeType As eModeType, ByVal inAddrs As Integer, ByVal inch As Integer, ByVal inSetChannel As Integer) As Boolean
        Dim Cnt As Integer = 0
        Dim ret As Integer = 0
        Dim tSChannel As Integer
        If ChkPowerChannel(inModeType, inSetChannel, tSChannel) = False Then
            Return False
        End If

        tSChannel = tSChannel + (inSetChannel - 1)

        If Set_OnoffOneChannel(inAddrs, inch, ret, eOnOff.eOFF, tSChannel) = False Then
            Return False

        End If


        ''''''''''''''GPO Output
        If inModeType = eModeType.eMainPower Then



            Dim SetValue() As Boolean = Nothing
            If Get_GPO_Out(inAddrs, inch, ret, SetValue) = False Then

                Return False
            End If


            For Cnt = 0 To SetValue.Length - 1
                If Cnt = inSetChannel Then
                    If SetValue(Cnt) = True Then
                        SetValue(Cnt) = False
                    End If
                End If
            Next

            Dim tBitNum As Double = 0
            For Cnt = 0 To SetValue.Length - 1
                If SetValue(Cnt) = True Then
                    tBitNum += 2 ^ Cnt
                End If
            Next

            Set_GPO_Out(inAddrs, inch, ret, tBitNum)
        End If
        ''''''''''''''GPO Output
        Return True
    End Function
    Public Function ChkPowerChannel(ByVal inType As eModeType, ByVal inSetChannel As Integer, ByRef OutStartChannel As Integer) As Boolean

        If inType = eModeType.eMainPower Then
            Dim tSum As Integer = (m_MainPower_Echannel - m_MainPower_Schannel) + 1
            If tSum < 0 Then
                MsgBox("The channel number is incorrect.!!")
                Return False
            End If

            If tSum < inSetChannel Then
                MsgBox("The channel number is incorrect.!!")
                Return False
            End If

            OutStartChannel = m_MainPower_Schannel
            'If inSetChannel > m_MainPower_Echannel Then
            '    MsgBox("채널 번호가 맞지 않습니다.!!")
            '    Return False
            'End If

            'If inSetChannel < m_MainPower_Schannel Then
            '    MsgBox("채널 번호가 맞지 않습니다.!!")
            '    Return False
            'End If
        ElseIf inType = eModeType.eSubPower Then
            Dim tSum As Integer = (m_SubPower_Echannel - m_SubPower_Schannel) + 1
            If tSum < 0 Then
                MsgBox("The channel number is incorrect.!!")
                Return False
            End If

            If tSum < inSetChannel Then
                MsgBox("The channel number is incorrect.!!")
                Return False
            End If

            OutStartChannel = m_SubPower_Schannel
            'If inSetChannel > m_SubPower_Echannel Then
            '    MsgBox("채널 번호가 맞지 않습니다.!!")
            '    Return False
            'End If

            'If inSetChannel < m_SubPower_Schannel Then
            '    MsgBox("채널 번호가 맞지 않습니다.!!")
            '    Return False
            'End If
        ElseIf inType = eModeType.eSignalPower Then
            Dim tSum As Integer = (m_Signal_Echannel - m_Signal_Schannel) + 1
            If tSum < 0 Then
                MsgBox("The channel number is incorrect.!!")
                Return False
            End If

            If tSum < inSetChannel Then
                MsgBox("The channel number is incorrect.!!")
                Return False
            End If

            OutStartChannel = m_Signal_Schannel
            'If inSetChannel > m_Signal_Echannel Then
            '    MsgBox("채널 번호가 맞지 않습니다.!!")
            '    Return False
            'End If

            'If inSetChannel < m_Signal_Schannel Then
            '    MsgBox("채널 번호가 맞지 않습니다.!!")
            '    Return False
            'End If
        End If

        Return True
    End Function
    Public Function ChkPowerChannel(ByVal inType As eModeType, ByVal inSetChannel() As Integer, ByRef OutStartChannel As Integer) As Boolean
        Dim nCnt As Integer
        For nCnt = 0 To inSetChannel.Length - 1
            If inType = eModeType.eMainPower Then
                Dim tSum As Integer = (m_MainPower_Echannel - m_MainPower_Schannel)
                If tSum < 0 Then
                    MsgBox("The channel number is incorrect.!!")
                    Return False
                End If

                If tSum < inSetChannel(nCnt) Then
                    MsgBox("The channel number is incorrect.!!")
                    Return False
                End If

                OutStartChannel = m_MainPower_Schannel
                'If inSetChannel > m_MainPower_Echannel Then
                '    MsgBox("채널 번호가 맞지 않습니다.!!")
                '    Return False
                'End If

                'If inSetChannel < m_MainPower_Schannel Then
                '    MsgBox("채널 번호가 맞지 않습니다.!!")
                '    Return False
                'End If
            ElseIf inType = eModeType.eSubPower Then
                Dim tSum As Integer = (m_SubPower_Echannel - m_SubPower_Schannel)
                If tSum < 0 Then
                    MsgBox("The channel number is incorrect.!!")
                    Return False
                End If

                If tSum < inSetChannel(nCnt) Then
                    MsgBox("The channel number is incorrect.!!")
                    Return False
                End If

                OutStartChannel = m_SubPower_Schannel
                'If inSetChannel > m_SubPower_Echannel Then
                '    MsgBox("채널 번호가 맞지 않습니다.!!")
                '    Return False
                'End If

                'If inSetChannel < m_SubPower_Schannel Then
                '    MsgBox("채널 번호가 맞지 않습니다.!!")
                '    Return False
                'End If
            ElseIf inType = eModeType.eSignalPower Then
                Dim tSum As Integer = (m_Signal_Echannel - m_Signal_Schannel)
                If tSum < 0 Then
                    MsgBox("The channel number is incorrect.!!")
                    Return False
                End If

                If tSum < inSetChannel(nCnt) Then
                    MsgBox("The channel number is incorrect.!!")
                    Return False
                End If

                OutStartChannel = m_Signal_Schannel
                'If inSetChannel > m_Signal_Echannel Then
                '    MsgBox("채널 번호가 맞지 않습니다.!!")
                '    Return False
                'End If

                'If inSetChannel < m_Signal_Schannel Then
                '    MsgBox("채널 번호가 맞지 않습니다.!!")
                '    Return False
                'End If
            End If
        Next


        Return True
    End Function
    Public Function ConvertPowerChannel(ByVal inModeType As eModeType, ByRef OutStartChannel As Integer, ByRef OutEndChannel As Integer) As Boolean

        If inModeType = eModeType.eMainPower Then
            OutStartChannel = m_MainPower_Schannel
            OutEndChannel = m_MainPower_Echannel
        ElseIf inModeType = eModeType.eSignalPower Then
            OutStartChannel = m_Signal_Schannel
            OutEndChannel = m_Signal_Echannel
        ElseIf inModeType = eModeType.eSubPower Then

            OutStartChannel = m_SubPower_Schannel
            OutEndChannel = m_SubPower_Echannel
        End If
        Return True
    End Function
#End Region
#End Region

#Region "Comm"
    Public Function Connection(ByVal config As CComSerial.sSerialPortInfo) As Boolean

        config.sRcvTerminator = Chr(&H3)
        Dim ret As Integer = communicator.Communicator.Connect(config)

        If ret <> 1 Then
            Return False
        End If

        m_bIsConnected = True
        Return True
    End Function

    Public Sub DisConnection()
        communicator.Communicator.Disconnect()

        m_bIsConnected = False

    End Sub

#End Region


#Region "Send Command"
    Public Sub fLogDisplay(ByRef inListView As ucSingleList, ByVal inString As String)

        inListView.AddRowData(inString)
    End Sub
    Public Function SendCommand(ByVal inStr As String) As Boolean
        Return communicator.Communicator.SendToString(inStr)
    End Function

    Public Function SendCommand(ByVal byCmp() As Byte) As Byte()

        Dim byRcvData() As Byte = Nothing
        Dim nLength As Integer = Nothing
        Dim byCrc As Byte = Nothing
        Dim dec As String = Nothing

        strLogTemp = ""

        For i As Integer = 0 To byCmp.Length - 4
            byCrc = byCrc Xor byCmp(i + 1)
        Next

        byCrc = byCrc Xor &H67
        byCmp(byCmp.Length - 2) = byCrc


        communicator.Communicator.SendToBytes(byCmp, byRcvData)





        Dim str As String = ""
        Dim str1 As String = ""

        For i As Integer = 0 To byCmp.Length - 1
            'item.SubItems.Add(Hex(byCmp(i)))
            Dim tSTr As String = Hex(byCmp(i)).ToString
            If tSTr.Length = 1 Then
                tSTr = "0" & tSTr
            End If
            str = " " & tSTr
            str1 &= str
        Next

        fLogDisplay(frmSGSendRecieveLog.LogSend, str1)





        str = ""
        str1 = ""
        If byRcvData Is Nothing Then
        Else

            For i As Integer = 0 To byRcvData.Length - 1
                'item.SubItems.Add(Hex(byCmp(i)))
                Dim tSTr As String = Hex(byRcvData(i)).ToString
                If tSTr.Length = 1 Then
                    tSTr = "0" & tSTr
                End If
                str = " " & tSTr
                str1 &= str
            Next
            fLogDisplay(frmSGSendRecieveLog.LogRcv, str1)
            If byRcvData.Length < 10 Then
                '  MsgBox("수신된 데이타가 없습니다.")
                Return Nothing
            End If

            str1 = ""
        End If


        Return byRcvData

    End Function
    Private Function Set_FieldInfo(ByVal inAddrs As Integer, ByVal inch As Integer, ByVal Cmd1 As Byte, ByVal Cmd2 As Byte, ByVal Err As Byte, ByVal Len As Integer, ByVal Data() As Byte, ByRef outSetData() As Byte) As Boolean


        Try

            Dim toutData() As Byte
            Dim tCnt As Integer = 0
            ReDim toutData(9 + Len)


            toutData(0) = SG_STX  'stx
            toutData(1) = "&H" & Hex(inAddrs) 'addrs
            toutData(2) = "&H" & Hex(inch) 'ch
            toutData(3) = Cmd1 'cmd 1byte
            toutData(4) = Cmd2 'cmd 1byte

            toutData(5) = Err '"&H" & Hex(Err) 'err 1byte


            Dim tLenArr() As Byte = fConvertByteInt16(Len)


            toutData(6) = tLenArr(0) '"&H" & Hex(tLenArr(0)) 'cmd 1byte
            toutData(7) = tLenArr(1) '"&H" & Hex(tLenArr(1)) 'cmd 1byte



            If Len > 0 Then

                For nCnt As Integer = 1 To Len
                    toutData(7 + nCnt) = Data(nCnt - 1)
                    tCnt = 7 + nCnt
                Next
            Else
                tCnt = 7

            End If
            toutData(tCnt + 1) = 0 'CRC
            toutData(tCnt + 2) = SG_ETX

            outSetData = toutData.Clone

            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function

#End Region
#Region "Common Command"
    'Ping
    Private Function Err_Check(ByVal inGetByte() As Byte, ByRef outErrCode As Integer, ByRef outDataLength As Integer, Optional ByVal inChkDataLength As Integer = 0) As Boolean
        Try
            If inGetByte Is Nothing Then
                MsgBox("No data received.")
                Return False
            End If

            Dim tcByteArr(1) As Byte
            tcByteArr(0) = byGetData(6)
            tcByteArr(1) = byGetData(7)

            Dim tLength As Integer = fConvertInt16Byte(tcByteArr)
            If inChkDataLength <> 0 Then
                If tLength <> inChkDataLength Then
                    MsgBox("The number of received data is not correct.")
                    Return False
                End If
            End If
            outDataLength = tLength
            outErrCode = Int(byGetData(5))

            Select Case byGetData(5)
                Case &H0
                    Return True
                Case &H1
                    Return True
                Case &H2
                    MsgBox(eErrorCode.eErrInit.ToString)
                    Return True
                Case &H3
                    MsgBox(eErrorCode.eErrFrame.ToString)
                    Return True
                Case &H4
                    MsgBox(eErrorCode.eErrCommand.ToString)
                    Return True
                Case &H5
                    MsgBox(eErrorCode.eErrComplete.ToString)
                    Return True
                Case &H6
                    MsgBox(eErrorCode.eErrSet.ToString)
                    Return True
                Case Else
                    MsgBox("UnKnown Error")
                    'Case &HFF
                    '    Return True
            End Select


        Catch ex As Exception

            MsgBox(ex.ToString)
            Return False
        End Try
        '   frmMain.lbl_status.Text = "에러 발생"
        '   MsgBox("에러 발생 : Err_Check() ", MsgBoxStyle.Critical, "Care!!")
        Return True
    End Function
    'ping (0x00)


    Enum eRcvDataLength
        eNone = 0
        eBoard = 35
        e2Byte = 2
        e3Byte = 3
        e1Byte = 1
        e4Byte = 4
        eStartData = 8
        eChByte = 1
        eReserve = 1

    End Enum
#Region "Common Function"
    Public Function cPing(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer) As Boolean
        '보드 와의 통신 확인 유무 ,   'Ping (0x00)
        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_COMMON, SG_PING, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)

        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then ' byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.eNone : 수신될 바이트 길이
            Return False
        End If
        Return True
    End Function
    Public Function cReset(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer) As Boolean
        '	보드 리셋 (0x01)
        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_COMMON, SG_RESET, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If



        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If

        'If CInt(byGetData(6)) <> 0 Then
        '    MsgBox("Reset Error")
        '    Return False
        'End If

        Return True
    End Function

    Public Function cBoardInfo(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef boardInfos As sBoardInfo, ByRef outErrCode As Integer) As Boolean
        '보드 정보 확인 (0x02)
        ReDim byFieldData(Nothing)

        nData_Len = 0
        If Set_FieldInfo(inAddrs, inch, SG_COMMON, SG_BOARD_INFO, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eBoard) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.e1Byte : 수신될 바이트 길이
            Return False
        End If

        Dim tModleStr As String = ""
        Dim TempStr As String = ""
        '/////////////// Model //////////////////////
        For i As Integer = 8 To 22
            tModleStr = Convert.ToChar(byGetData(i))
            TempStr &= tModleStr
        Next

        boardInfos.sModel = TempStr

        Dim tSerialStr As String = ""
        TempStr = ""
        '/////////////// Serial No //////////////////////
        For i = 23 To 32
            tSerialStr = Convert.ToChar(byGetData(i))
            If tSerialStr = "-" Then
                tSerialStr = "."
            End If
            TempStr &= tSerialStr
        Next

        boardInfos.sSerialNo = TempStr

        '/////////////// Date //////////////////////
        Dim tDate As String = ""
        tDate = Convert.ToUInt16(byGetData(33)) + 2000 & " " & Convert.ToUInt16(byGetData(34)) & " " & Convert.ToUInt16(byGetData(35))
        boardInfos.sDate = tDate

        '/////////////// Etc //////////////////////
        Dim tfirmVer As String = ""
        Dim tFpgaVer As String = ""
        Dim tDacChannel As String = ""
        Dim tAdcChannel As String = ""
        Dim tAuxChannel As String = ""

        tfirmVer = Convert.ToByte(byGetData(36)) & " " & Convert.ToByte(byGetData(37)) / 100
        boardInfos.sFirmwareVer = tfirmVer
        tFpgaVer = Convert.ToByte(byGetData(38)) & " " & Convert.ToByte(byGetData(39)) / 100
        boardInfos.sFPGAVer = tFpgaVer
        tDacChannel = Convert.ToByte(byGetData(40))
        boardInfos.nDACChannel = tDacChannel
        tAdcChannel = Convert.ToByte(byGetData(41))
        boardInfos.nADCChannel = tAdcChannel
        tAuxChannel = Convert.ToByte(byGetData(42))
        boardInfos.nAUXChannel = tAuxChannel

        Return True
    End Function
    Public Function cSaveData(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer) As Boolean
        '저장 항목 들을 메모리에 저장 (0x14)
        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_COMMON, SG_SAVE, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.eNone : 수신될 바이트 길이
            Return False
        End If


        Return True
    End Function
    Public Function cResisterInit(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer) As Boolean
        '상태 레지스터  초기화 (0x10)
        ReDim byFieldData(1)

        byFieldData(0) = 0
        byFieldData(1) = 0

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_COMMON, SG_RES_INIT, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.eNone : 수신될 바이트 길이
            Return False
        End If
        Return True
    End Function
    Public Function cResisterRead(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef nRegState As String, ByRef outErrCode As Integer) As Boolean
        '상태 레지스터  조회 (0x10)
        ReDim byFieldData(Nothing)
        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_COMMON, SG_RES_INIT, SG_GET_ERR, 0, byFieldData, bySetData) = False Then
            Return False
        End If



        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.e2Byte) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.e2Byte : 수신될 바이트 길이
            Return False
        End If


        nRegState = ""
        For cnt As Integer = eRcvDataLength.eStartData To eRcvDataLength.eStartData + 1
            Dim tHexStr As String = Hex(byGetData(cnt)).ToString
            If tHexStr.Length = 1 Then
                nRegState = nRegState & "0" & Hex(byGetData(cnt)).ToString & " "

            Else
                nRegState = nRegState & Hex(byGetData(cnt)).ToString & " "
            End If

            If cnt = eRcvDataLength.eStartData Then
                fCheckAlarm(True, byGetData(cnt)) '첫번 째 Byte 알람 분석
            ElseIf cnt = eRcvDataLength.eStartData + 1 Then
                fCheckAlarm(False, byGetData(cnt)) '두번 째 Byte 알람 분석
            End If
        Next



        Return True
    End Function
    Public Function cComplete(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef nMotionStatus As Integer, ByRef outErrCode As Integer) As Boolean
        '이전 명령어 완료 상대 퐉인 (0x11)
        ReDim byFieldData(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_COMMON, SG_MOTION, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If



        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.e1Byte) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.e1Byte : 수신될 바이트 길이
            Return False
        End If

        nMotionStatus = byGetData(8)  'nMotion = 0 '수행완료 nMotion = 1 '수행중

        Return True
    End Function
#End Region


#End Region

#Region "Set Function"
    Public Function Set_OutputOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inSetValue As Double, ByVal inChannel As Integer) As Boolean
        '개별 채널 DAC SET (0x2100)
        '채널은 0 ~ 107 채널 만 가능
        ReDim byFieldData(3)
        Dim tScaleVal As Double = fConvertSetDouble(inSetValue)
        Dim tConverUnit() As Byte = fConvertByteInt16(tScaleVal)


        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = 0 'reserved
        byFieldData(2) = tConverUnit(0) 'OutPut 1/2 Byte
        byFieldData(3) = tConverUnit(1) 'OutPut 2/2 Byte

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_Out_OneChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.eNone : 수신될 Data 바이트 길이
            Return False
        End If
        Return True
    End Function
    Public Function Set_OutputAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inSetValueArr() As Double) As Boolean
        '전체 채널 DAC Set (0x2101)
        '채널은 0 ~ 107 채널 만 가능
        Dim tCount As Integer = 2 '2byte
        ReDim byFieldData((inSetValueArr.Length) * tCount - 1)

        If inSetValueArr.Length <> Max_DAC_Channel Then
            MsgBox("데이터 배열 크기와 맥스 채널 크기가 같지 않습니다 (Data array size is not equal to Max channel size)!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If

        Dim tConverUnit() As Byte



        For Cnt As Integer = 0 To inSetValueArr.Length - 1 '0 ~ 107 순서 대로 설정 
            tConverUnit = fConvertByteInt16(fConvertSetDouble(inSetValueArr(Cnt)))
            byFieldData(tCount * (Cnt) + 0) = tConverUnit(0) 'OutPut 1/2 Byte
            byFieldData(tCount * (Cnt) + 1) = tConverUnit(1) 'OutPut 2/2 Byte


        Next

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_Out_AllChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If



        byGetData = SendCommand(bySetData)

        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.e1Byte : 수신될 바이트 길이
            Return False
        End If
        Return True
    End Function
    Public Function Set_SelectModeOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inMode As eDacMode, ByVal inChannel As Integer) As Boolean
        '개별 채널 Dac 출력 모드 설정   (0x2110)
        'ch 0 ~ 53 만 가능
        ReDim byFieldData(2)

        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = "&H" & Hex(0) 'reserved
        byFieldData(2) = "&H" & Hex(inMode) 'dac output mode 0:dc mode 1:pulse mode

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_Mode_OneChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_SelectModeAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inModeArr() As eDacMode) As Boolean
        '전체 채널 Dac 출력 모드 설정  (0x2111)
        'max ch54
        ReDim byFieldData((inModeArr.Length) - 1)


        If inModeArr.Length <> Max_Pulse_Channel Then
            MsgBox("데이터 배열 크기와 맥스 채널 크기가 같지 않습니다 (Data array size is not equal to Max channel size)!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If



        Dim tCount As Integer = 1

        For Cnt As Integer = 0 To inModeArr.Length - 1

            byFieldData(tCount * (Cnt)) = inModeArr(Cnt)


        Next


        nData_Len = byFieldData.Length




        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_Mode_AllChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)


        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.eNone : 수신될 Data 바이트 길이
            Return False
        End If
        Return True
    End Function
    Public Function Set_OnoffOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inOnOff As eOnOff, ByVal inChannel As Integer) As Boolean
        '개별 채널 OnOff 설정 (0x2120)
        'Max ch 54
        ReDim byFieldData(2)

        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = "&H" & Hex(0) 'reserved
        byFieldData(2) = "&H" & Hex(inOnOff) 'On or OFf

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_OnOFF_OneChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_OnOffAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inOnOffArr() As eOnOff) As Boolean
        '전체 채널 OnOff 설정 (0x2121)
        'max ch 54
        ReDim byFieldData((inOnOffArr.Length) - 1)


        If inOnOffArr.Length <> Max_Pulse_Channel Then
            MsgBox("데이터 배열 크기와 맥스 채널 크기가 같지 않습니다 (Data array size is not equal to Max channel size)!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If


        Dim tCount As Integer = 1

        For Cnt As Integer = 0 To inOnOffArr.Length - 1

            byFieldData(tCount * (Cnt)) = inOnOffArr(Cnt)


        Next


        nData_Len = byFieldData.Length




        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_OnOFF_AllChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.eNone : 수신될 Data 바이트 길이
            Return False
        End If
        Return True
    End Function
    Public Function Set_SyncAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inOnOffArr() As eOnOff) As Boolean
        '전체 채널 Sync 설정 (0x2129)
        'max ch 54
        ReDim byFieldData((inOnOffArr.Length) - 1)


        If inOnOffArr.Length <> Max_Pulse_Channel Then
            MsgBox("데이터 배열 크기와 맥스 채널 크기가 같지 않습니다 (Data array size is not equal to Max channel size)!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If


        Dim tCount As Integer = 1

        For Cnt As Integer = 0 To inOnOffArr.Length - 1

            byFieldData(tCount * (Cnt)) = inOnOffArr(Cnt)


        Next


        nData_Len = byFieldData.Length




        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_Pulse_AllChannelSync, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.eNone : 수신될 Data 바이트 길이
            Return False
        End If
        Return True
    End Function
    Public Function Set_FinalOutputOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inFOut As eFoutput, ByVal inChannel As Integer) As Boolean
        '개별 채널 Foutput 설정 (0x2122)
        'ch 0~ 53
        ReDim byFieldData(2)

        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = "&H" & Hex(0) 'reserved
        byFieldData(2) = "&H" & Hex(inFOut) 'dac Final output mode 0:Even 1:Odd

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_FinalOut_OneChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , eRcvDataLength.eNone : 수신될 Data 바이트 길이
            Return False
        End If
        Return True
    End Function
    Public Function Set_FinalOutputAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inFOutputArr() As eFoutput) As Boolean
        '전체 채널 Final output 설정 (0x2123)
        'max ch 54
        ReDim byFieldData((inFOutputArr.Length) - 1)


        If inFOutputArr.Length <> Max_Pulse_Channel Then
            MsgBox("데이터 배열 크기와 맥스 채널 크기가 같지 않습니다 (Data array size is not equal to Max channel size)!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If


        Dim tCount As Integer = 1

        For Cnt As Integer = 0 To inFOutputArr.Length - 1

            byFieldData(tCount * (Cnt) + 0) = inFOutputArr(Cnt)


        Next


        nData_Len = byFieldData.Length




        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_FinalOut_AllChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , tRcvDataLength : 수신될 Data 바이트 길이
            Return False
        End If
        Return True
    End Function
    Public Function Set_PulseOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inPulseInfo As sPulseParam, ByVal inChannel As Integer) As Boolean
        '개별 채널 Pulse 설정 (0x2124)
        'ch 0 ~ 53
        ReDim byFieldData(10)


        Dim tConverUnit() As Byte



        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = "&H" & Hex(0) 'reserved

        'Pulse Period
        Dim tSet As Integer = inPulseInfo.Period / 10 * 1000 'us Unit
        tConverUnit = fConvert24ByteInt(tSet)
        byFieldData(2) = tConverUnit(0)
        byFieldData(3) = tConverUnit(1)
        byFieldData(4) = tConverUnit(2)

        'Pulse width
        tSet = inPulseInfo.Width / 10 * 1000 'us Unit
        tConverUnit = fConvert24ByteInt(tSet)
        byFieldData(5) = tConverUnit(0)
        byFieldData(6) = tConverUnit(1)
        byFieldData(7) = tConverUnit(2)

        'Pulse Delay
        tSet = inPulseInfo.Delay / 100 * 1000 'us Unit
        tConverUnit = fConvert24ByteInt(tSet)
        byFieldData(8) = tConverUnit(0)
        byFieldData(9) = tConverUnit(1)
        byFieldData(10) = tConverUnit(2)


        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_Pulse_OneChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_PulseAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inPulseArr() As sPulseParam) As Boolean
        '전체 채널 Pulse 설정 (0x2125)
        'max ch 54
        Dim tCount As Integer = 3 * 3
        ReDim byFieldData((inPulseArr.Length) * tCount - 1)


        If inPulseArr.Length <> Max_Pulse_Channel Then
            MsgBox("데이터 배열 크기와 맥스 채널 크기가 같지 않습니다 (Data array size is not equal to Max channel size)!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If


        Dim tConverUnit() As Byte


        For Cnt As Integer = 0 To inPulseArr.Length - 1


            'Pulse Period
            tConverUnit = fConvert24ByteInt(inPulseArr(Cnt).Period / 10 * 1000) 'us Unit
            byFieldData(tCount * (Cnt) + 0) = tConverUnit(0)
            byFieldData(tCount * (Cnt) + 1) = tConverUnit(1)
            byFieldData(tCount * (Cnt) + 2) = tConverUnit(2)

            'Pulse width
            tConverUnit = fConvert24ByteInt(inPulseArr(Cnt).Width / 10 * 1000) 'us Unit
            byFieldData(tCount * (Cnt) + 3) = tConverUnit(0)
            byFieldData(tCount * (Cnt) + 4) = tConverUnit(1)
            byFieldData(tCount * (Cnt) + 5) = tConverUnit(2)

            'Pulse Delay

            tConverUnit = fConvert24ByteInt(inPulseArr(Cnt).Delay / 100 * 1000) 'us Unit
            byFieldData(tCount * (Cnt) + 6) = tConverUnit(0)
            byFieldData(tCount * (Cnt) + 7) = tConverUnit(1)
            byFieldData(tCount * (Cnt) + 8) = tConverUnit(2)
        Next


        nData_Len = byFieldData.Length




        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_Pulse_AllChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  ,  eRcvDataLength.eNone : 수신될 Data 바이트 길이
            Return False
        End If

        Return True
    End Function
    Public Function Set_ADcAverCountOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inSetCount As Double, ByVal inChannel As Integer) As Boolean


        '1채널 Adc Aver Set (0x2128)

        'If inSetCount < 10 Then
        '    MsgBox("설정 값 이 범위를 벗어났습니다!! ( 10 ~ 200 )", MsgBoxStyle.Critical, "Care!!")
        '    Return False

        'End If


        'If inSetCount > 200 Then
        '    MsgBox("설정 값 이 범위를 벗어났습니다!! ( 10 ~ 200 )", MsgBoxStyle.Critical, "Care!!")
        '    Return False

        'End If


        ReDim byFieldData(2)


        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = 0 'reserved
        byFieldData(2) = "&H" & Hex(inSetCount)

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_AverCountADc_OneChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_ADcAverCountAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inSetCount() As Double) As Boolean


        '전체 채널 Adc Aver Set (0x2129)
        'max ch 56



        Dim tCount As Integer = 1
        ReDim byFieldData((inSetCount.Length) * tCount - 1)


        If inSetCount.Length <> Max_ADC_Channel Then
            MsgBox("데이터 배열 크기와 맥스 채널 크기가 같지 않습니다 (Data array size is not equal to Max channel size)!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If


        For Cnt As Integer = 0 To Max_ADC_Channel - 1

            '    tConverUnit = fConvertByteInt16(inSetCount(Cnt))

            byFieldData(tCount * (Cnt) + 0) = inSetCount(Cnt)
            '  byFieldData(tCount * (Cnt) + 1) = tConverUnit(1)

        Next


        nData_Len = byFieldData.Length




        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_AverCountADc_AllChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_ADcTempLimitOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inSetLimit As Double, ByVal inChannel As Integer) As Boolean
        '1채널 Adc Limit Set (0x2130)
        'ch 0 ~ 55
        ReDim byFieldData(3)


        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = 0 'reserved

        Dim tConverUnit() As Byte

        tConverUnit = fConvertByteInt16(fConvertSetDoubleADC(inSetLimit))
        byFieldData(2) = tConverUnit(0)
        byFieldData(3) = tConverUnit(1)


        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_TempLimitADc_OneChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_ADcLimitOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inSetLimit As Double, ByVal inChannel As Integer) As Boolean
        '1채널 Adc Limit Set (0x2130)
        ' 'Channel 0 ~ 15 , adc - 41 ~ 56
        ReDim byFieldData(3)


        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = 0 'reserved

        Dim tConverUnit() As Byte

        tConverUnit = fConvertByteInt16(fConvertSetDoubleADC(inSetLimit))
        byFieldData(2) = tConverUnit(0)
        byFieldData(3) = tConverUnit(1)


        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_LimitOutputADc_OneChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_ADcTempLimitAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inLimitValue() As Double) As Boolean
        '전체 채널 Adc Limit 온도 Set(0x2131)
        'max ch 56
        Dim tCount As Integer = 2
        ReDim byFieldData((inLimitValue.Length) * tCount - 1)


        If inLimitValue.Length <> Max_ADC_Limit_Channel Then
            MsgBox("데이터 배열 크기와 맥스 채널 크기가 같지 않습니다 (Data array size is not equal to Max channel size)!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If


        Dim tConverUnit() As Byte


        For Cnt As Integer = 0 To Max_ADC_Limit_Channel - 1

            tConverUnit = fConvertByteInt16(fConvertSetDoubleADC(inLimitValue(Cnt)))

            byFieldData(tCount * (Cnt) + 0) = tConverUnit(0)
            byFieldData(tCount * (Cnt) + 1) = tConverUnit(1)

        Next


        nData_Len = byFieldData.Length




        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_TempLimitADc_AllChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_ADcLimitAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inLimitValue() As Double) As Boolean
        '전체 채널 Adc Limit Set(0x2131)
        ' (ADC 41 ~ 56 ) ch15
        Dim tCount As Integer = 2
        ReDim byFieldData((inLimitValue.Length) * tCount - 1)


        If inLimitValue.Length <> Max_ADC_Limit_Channel Then
            MsgBox("데이터 배열 크기와 맥스 채널 크기가 같지 않습니다 (Data array size is not equal to Max channel size)!!", MsgBoxStyle.Critical, "Care!!")
            Return False
        End If


        Dim tConverUnit() As Byte


        For Cnt As Integer = 0 To Max_ADC_Limit_Channel - 1

            tConverUnit = fConvertByteInt16(fConvertSetDoubleADC(inLimitValue(Cnt)))

            byFieldData(tCount * (Cnt) + 0) = tConverUnit(0)
            byFieldData(tCount * (Cnt) + 1) = tConverUnit(1)

        Next


        nData_Len = byFieldData.Length




        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_LimitOutputADc_AllChannel, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_GPO_Out(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inSetValue As Integer) As Boolean
        '개별 채널 DAC SET
        ReDim byFieldData(1)

        Dim tLenArr() As Byte = fConvertByteInt16(inSetValue)


        byFieldData(0) = tLenArr(0)
        byFieldData(1) = tLenArr(1)


        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_GPO_OnOFf, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_GPIO_Out(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inSetValue As Integer) As Boolean
        'GPIO INPUT & OUTPUT 설정 
        ReDim byFieldData(1)

        Dim tLenArr() As Byte = fConvertByteInt16(inSetValue)


        byFieldData(0) = tLenArr(0)
        byFieldData(1) = tLenArr(1)


        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_GPIO_InOutSet, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_GPIO_OnOff(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inSetValue As Integer) As Boolean
        'GPIO OUTPUT ONOFF 설정 (0x2142)
        ReDim byFieldData(1)

        Dim tLenArr() As Byte = fConvertByteInt16(inSetValue)


        byFieldData(0) = tLenArr(0)
        byFieldData(1) = tLenArr(1)


        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_GPIO_OnOFf, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then
            Return False
        End If
        Return True
    End Function
    Public Function Set_LimitAlarm(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer) As Boolean
        'Limit Alarm 초기화 (0x20)

        ReDim byFieldData(Max_ADC_Channel - 1)




        Dim tCount As Integer = 1

        For Cnt As Integer = 0 To byFieldData.Length - 1

            byFieldData(Cnt) = eLimitAlarm.eNoAlarm '초기화 이기 때문에 강제로 Noalarm


        Next


        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, SG_COMMON, SG_Limit_Alarm, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If
        Return True

    End Function
    Public Function Set_CalApply(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inApply As eCalApply) As Boolean
        'Cal Apply 설정 (0x8020)

        ReDim byFieldData(0)






        byFieldData(0) = inApply '초기화 이기 때문에 강제로 Noalarm



        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, SG_PROD_COM, SG_Cal_Apply, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If
        Return True

    End Function
    Public Function Set_DacSlope(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inValue As Single, ByVal inChannel As Integer) As Boolean
        'DAC SLope 설정 ( 0xF000)

        ReDim byFieldData(5)






        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = 0 'reserved

        Dim tLenArr() As Byte = fConvertByteSingle(inValue)

        byFieldData(2) = tLenArr(0)
        byFieldData(3) = tLenArr(1)
        byFieldData(4) = tLenArr(2)
        byFieldData(5) = tLenArr(3)


        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, SG_Compensation, SG_Dac_Slope, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If
        Return True

    End Function
    Public Function Set_DacOffset(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inValue As Single, ByVal inChannel As Integer) As Boolean
        'DAC Offset 설정 ( 0xF001)

        ReDim byFieldData(5)


        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = 0 'reserved

        Dim tLenArr() As Byte = fConvertByteSingle(inValue)

        byFieldData(2) = tLenArr(0)
        byFieldData(3) = tLenArr(1)
        byFieldData(4) = tLenArr(2)
        byFieldData(5) = tLenArr(3)


        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, SG_Compensation, SG_Dac_Offset, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If
        Return True

    End Function
    Public Function Set_ADcSlope(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inValue As Single, ByVal inChannel As Integer) As Boolean
        'ADC SLope 설정 ( 0xF010)

        ReDim byFieldData(5)






        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = 0 'reserved

        Dim tLenArr() As Byte = fConvertByteSingle(inValue)

        byFieldData(2) = tLenArr(0)
        byFieldData(3) = tLenArr(1)
        byFieldData(4) = tLenArr(2)
        byFieldData(5) = tLenArr(3)


        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, SG_Compensation, SG_ADc_Slope, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If
        Return True

    End Function
    Public Function Set_ADcOffset(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByVal inValue As Single, ByVal inChannel As Integer) As Boolean
        'ADC Offset 설정 ( 0xF011)

        ReDim byFieldData(5)


        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        byFieldData(1) = 0 'reserved

        Dim tLenArr() As Byte = fConvertByteSingle(inValue)

        byFieldData(2) = tLenArr(0)
        byFieldData(3) = tLenArr(1)
        byFieldData(4) = tLenArr(2)
        byFieldData(5) = tLenArr(3)


        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, SG_Compensation, SG_ADc_Offset, SG_SET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.eNone) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If
        Return True

    End Function
#End Region
#Region "Get Function"
    Public Function Get_ADcOffset(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outValue As Single, ByVal inChannel As Integer) As Boolean
        'ADC Offset 설정읽기 ( 0xF011)
        ReDim byFieldData(0)
        byFieldData(0) = "&H" & Hex(inChannel)
        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, SG_Compensation, SG_ADc_Offset, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then '
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e4Byte 'ch byte + reserve byte + data byte ( 2byte)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If


        Dim tByteArr(3) As Byte
        Dim tDVal As Single
        tByteArr(0) = byGetData(eRcvDataLength.eStartData + 2)
        tByteArr(1) = byGetData(eRcvDataLength.eStartData + 3)
        tByteArr(2) = byGetData(eRcvDataLength.eStartData + 4)
        tByteArr(3) = byGetData(eRcvDataLength.eStartData + 5)


        tDVal = fConvertSingleByte(tByteArr)
        outValue = tDVal
        Return True

    End Function
    Public Function Get_ADcSlope(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outValue As Single, ByVal inChannel As Integer) As Boolean
        'ADC SLope 설정읽기 ( 0xF010)
        ReDim byFieldData(0)
        byFieldData(0) = "&H" & Hex(inChannel)
        nData_Len = byFieldData.Length


        If Set_FieldInfo(inAddrs, inch, SG_Compensation, SG_ADc_Slope, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then '
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e4Byte 'ch byte + reserve byte + data byte ( 2byte)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If


        Dim tByteArr(3) As Byte
        Dim tDVal As Single
        tByteArr(0) = byGetData(eRcvDataLength.eStartData + 2)
        tByteArr(1) = byGetData(eRcvDataLength.eStartData + 3)
        tByteArr(2) = byGetData(eRcvDataLength.eStartData + 4)
        tByteArr(3) = byGetData(eRcvDataLength.eStartData + 5)


        tDVal = fConvertSingleByte(tByteArr)
        outValue = tDVal
        Return True

    End Function
    Public Function Get_DacOffset(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outValue As Single, ByVal inChannel As Integer) As Boolean
        'DAC Offset 설정읽기 ( 0xF001)
        ReDim byFieldData(0)
        byFieldData(0) = "&H" & Hex(inChannel)
        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, SG_Compensation, SG_Dac_Offset, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then '
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e4Byte 'ch byte + reserve byte + data byte ( 2byte)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If


        Dim tByteArr(3) As Byte
        Dim tDVal As Single
        tByteArr(0) = byGetData(eRcvDataLength.eStartData + 2)
        tByteArr(1) = byGetData(eRcvDataLength.eStartData + 3)
        tByteArr(2) = byGetData(eRcvDataLength.eStartData + 4)
        tByteArr(3) = byGetData(eRcvDataLength.eStartData + 5)


        tDVal = fConvertSingleByte(tByteArr)
        outValue = tDVal
        Return True

    End Function
    Public Function Get_DacSlope(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outValue As Single, ByVal inChannel As Integer) As Boolean
        'DAC SLope 설정읽기 ( 0xF000)
        ReDim byFieldData(0)
        byFieldData(0) = "&H" & Hex(inChannel)
        nData_Len = byFieldData.Length



        If Set_FieldInfo(inAddrs, inch, SG_Compensation, SG_Dac_Slope, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then '
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e4Byte 'ch byte + reserve byte + data byte ( 2byte)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If


        Dim tByteArr(3) As Byte
        Dim tDVal As Single
        tByteArr(0) = byGetData(eRcvDataLength.eStartData + 2)
        tByteArr(1) = byGetData(eRcvDataLength.eStartData + 3)
        tByteArr(2) = byGetData(eRcvDataLength.eStartData + 4)
        tByteArr(3) = byGetData(eRcvDataLength.eStartData + 5)


        tDVal = fConvertSingleByte(tByteArr)
        outValue = tDVal


        Return True

    End Function
    Public Function Get_CalApply(ByVal inAddrs As Integer, ByVal inch As Integer,
ByRef outErrCode As Integer, ByRef outApply As eCalApply) As Boolean
        'Cal Apply 읽기 (0x8020)
        ReDim byFieldData(Nothing)

        nData_Len = 0

        outApply = Nothing

        If Set_FieldInfo(inAddrs, inch, SG_PROD_COM, SG_Cal_Apply, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then '
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.e1Byte) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If



        outApply = Int(byGetData(eRcvDataLength.eStartData))



        Return True

    End Function
    Public Function Get_LimitAlarm(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef inLimitAlarm() As eLimitAlarm) As Boolean
        'Limit Alarm 조회 (0x20)
        ReDim byFieldData(Nothing)

        nData_Len = 0



        If Set_FieldInfo(inAddrs, inch, SG_COMMON, SG_Limit_Alarm, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then '
            Return False
        End If


        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, Max_ADC_Channel) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , inSetChannel  : 수신될 바이트 길이
            Return False
        End If

        ReDim inLimitAlarm(Max_ADC_Channel - 1)

        For Cnt As Integer = 0 To Max_ADC_Channel - 1

            inLimitAlarm(Cnt) = fConvertInt8Byte(byGetData(eRcvDataLength.eStartData + Cnt))

        Next

        Return True

    End Function
    Public Function Get_GPIO_OnOff(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue() As Boolean) As Boolean
        '상태 레지스터  초기화
        ReDim byFieldData(Nothing)
        ReDim outGetValue(Nothing)
        '   outGetValue = 0
        '  Dim tConverUnit() As Byte = fConvertByteSingle(inSetValue)

        '    byFieldData(0) = "&H" & Hex(inChannel) 'channel
        '

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_GPIO_OnOFf, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.e2Byte '
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If


        Try
            Dim tByteArr(1) As Byte
            Dim tDVal As Integer
            tByteArr(0) = byGetData(eRcvDataLength.eStartData + 0)
            tByteArr(1) = byGetData(eRcvDataLength.eStartData + 1)

            tDVal = fConvertInt16Byte(tByteArr)

            Dim tBinLength As String = DecToBin(tDVal)
            ReDim outGetValue(15)

            Dim tStr As String
            For Cnt As Integer = 0 To tBinLength.Length - 1

                tStr = tBinLength.Substring(tBinLength.Length - 1 - Cnt, 1)

                If tStr = "0" Then
                    outGetValue(Cnt) = False
                ElseIf tStr = "1" Then
                    outGetValue(Cnt) = True

                End If
            Next


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        Return True
    End Function
    Public Function Get_GPIO_ReadIN(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue() As Double) As Boolean
        '상태 레지스터  초기화
        ReDim byFieldData(Nothing)
        '   outGetValue = 0
        '  Dim tConverUnit() As Byte = fConvertByteSingle(inSetValue)

        '    byFieldData(0) = "&H" & Hex(inChannel) 'channel
        '

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_GPIO_ReadIn, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.e2Byte) = False Then
            Return False
        End If

        Try
            Dim tByteArr(1) As Byte
            Dim tDVal As Integer
            tByteArr(0) = byGetData(eRcvDataLength.eStartData + 0)
            tByteArr(1) = byGetData(eRcvDataLength.eStartData + 1)

            tDVal = fConvertInt16Byte(tByteArr)

            Dim tBinLength As String = DecToBin(tDVal)
            ReDim outGetValue(15)

            Dim tStr As String
            For Cnt As Integer = 0 To tBinLength.Length - 1

                tStr = tBinLength.Substring(tBinLength.Length - 1 - Cnt, 1)

                If tStr = "0" Then
                    outGetValue(Cnt) = False
                ElseIf tStr = "1" Then
                    outGetValue(Cnt) = True

                End If
            Next


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        Return True
    End Function
    Public Function Get_GPIO_Out(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue() As Boolean) As Boolean
        'GPIO INPUT & OUTPUT 설정 read
        ReDim byFieldData(Nothing)
        '   outGetValue = 0
        '  Dim tConverUnit() As Byte = fConvertByteSingle(inSetValue)

        '    byFieldData(0) = "&H" & Hex(inChannel) 'channel
        '

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_GPIO_InOutSet, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.e2Byte '
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If




        Try
            Dim tByteArr(1) As Byte
            Dim tDVal As Integer
            tByteArr(0) = byGetData(eRcvDataLength.eStartData + 0)
            tByteArr(1) = byGetData(eRcvDataLength.eStartData + 1)

            tDVal = fConvertInt16Byte(tByteArr)

            Dim tBinLength As String = DecToBin(tDVal)
            ReDim outGetValue(15)

            Dim tStr As String
            For Cnt As Integer = 0 To tBinLength.Length - 1

                tStr = tBinLength.Substring(tBinLength.Length - 1 - Cnt, 1)

                If tStr = "0" Then
                    outGetValue(Cnt) = False
                ElseIf tStr = "1" Then
                    outGetValue(Cnt) = True

                End If
            Next


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try


        Return True

    End Function
    Public Function Get_GPO_Out(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue() As Boolean) As Boolean
        'gpi out 읽기
        ReDim byFieldData(Nothing)
        '   outGetValue = 0
        '  Dim tConverUnit() As Byte = fConvertByteSingle(inSetValue)

        '    byFieldData(0) = "&H" & Hex(inChannel) 'channel
        '

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_GPO_OnOFf, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, eRcvDataLength.e2Byte) = False Then
            Return False
        End If

        Try
            Dim tByteArr(1) As Byte
            Dim tDVal As Integer
            tByteArr(0) = byGetData(eRcvDataLength.eStartData + 0)
            tByteArr(1) = byGetData(eRcvDataLength.eStartData + 1)

            tDVal = fConvertInt16Byte(tByteArr)

            Dim tBinLength As String = DecToBin(tDVal)
            ReDim outGetValue(15)

            Dim tStr As String
            If tBinLength = "0" Then
                For Cnt As Integer = 0 To outGetValue.Length - 1
                    outGetValue(Cnt) = False
                Next
            Else
                For Cnt As Integer = 0 To tBinLength.Length - 1

                    tStr = tBinLength.Substring(tBinLength.Length - 1 - Cnt, 1)

                    If tStr = "0" Then
                        outGetValue(Cnt) = False
                    ElseIf tStr = "1" Then
                        outGetValue(Cnt) = True

                    End If
                Next
            End If



        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        Return True
    End Function
    Public Function Get_ADcTempLimitAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue() As Double) As Boolean
        '전체 채널 Adc Limit 전류 Set (0x2131)
        'max ch 41 - 56
        ReDim byFieldData(Nothing)

        Dim tCount As Integer = 2

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_TempLimitADc_AllChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = Max_ADC_Limit_Channel * tCount
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If


        Try

            ReDim outGetValue(Max_ADC_Limit_Channel - 1)
            Dim tByteArr(1) As Byte

            For cnt As Integer = 0 To Max_ADC_Limit_Channel - 1

                tByteArr(0) = byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 0)
                tByteArr(1) = byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 1)

                outGetValue(cnt) = fConvertGetDoubleADC(fConvertInt16Byte(tByteArr))

            Next





        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        Return True
    End Function
    Public Function Get_ADcAverCountAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue() As Double) As Boolean
        '전체 채널 Adc Aver Set Read (0x2129)
        ReDim byFieldData(Nothing)

        Dim tCount As Integer = 1

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_AverCountADc_AllChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = Max_ADC_Channel * tCount
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If


        Try

            ReDim outGetValue(Max_ADC_Channel - 1)
            Dim tByteArr(1) As Byte

            For cnt As Integer = 0 To Max_ADC_Channel - 1

                'tByteArr(0) = byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 0)
                'tByteArr(1) = byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 1)

                outGetValue(cnt) = Int(byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 0))

            Next





        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        Return True

    End Function
    Public Function Get_ADcLimitAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue() As Double) As Boolean
        '전체 채널 Adc Limit 전류 Set (0x2131)
        'max ch 56
        ReDim byFieldData(Nothing)

        Dim tCount As Integer = 2

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_LimitOutputADc_AllChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = Max_ADC_Limit_Channel * tCount
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If


        Try

            ReDim outGetValue(Max_ADC_Limit_Channel - 1)
            Dim tByteArr(1) As Byte

            For cnt As Integer = 0 To Max_ADC_Limit_Channel - 1

                tByteArr(0) = byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 0)
                tByteArr(1) = byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 1)

                outGetValue(cnt) = fConvertGetDoubleADC(fConvertInt16Byte(tByteArr))

            Next





        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        Return True
    End Function
    Public Function Get_ADcLimitOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue As Double, ByVal inChannel As Integer) As Boolean
        '1 채널 Adc Limit 전류 Set (0x2130)
        ' 'Channel 0 ~ 15 , adc - 41 ~ 56
        ReDim byFieldData(0)
        outGetValue = 0
        '  Dim tConverUnit() As Byte = fConvertByteSingle(inSetValue)

        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        '

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_LimitOutputADc_OneChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)

        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e2Byte 'ch byte + reserve byte + data byte ( 2byte)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If


        Try
            If Int(byGetData(eRcvDataLength.eStartData)) = inChannel Then

                Dim tByteArr(1) As Byte
                tByteArr(0) = byGetData(eRcvDataLength.eStartData + 2)
                tByteArr(1) = byGetData(eRcvDataLength.eStartData + 3)


                outGetValue = fConvertGetDoubleADC(fConvertInt16Byte(tByteArr))

            Else

                MsgBox("Data is incorrect!!", MsgBoxStyle.Critical, "Care!!")

                Return False
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
        Return True
    End Function
    Public Function Get_ADcTempLimitOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue As Double, ByVal inChannel As Integer) As Boolean
        '1 채널 Adc Limit 전류 Set (0x2130)
        'ch 1 ~ 16
        ReDim byFieldData(0)
        outGetValue = 0
        '  Dim tConverUnit() As Byte = fConvertByteSingle(inSetValue)

        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        '

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_TempLimitADc_OneChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)

        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e2Byte 'ch byte + reserve byte + data byte ( 2byte)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If


        Try
            If Int(byGetData(eRcvDataLength.eStartData)) = inChannel Then

                Dim tByteArr(1) As Byte
                tByteArr(0) = byGetData(eRcvDataLength.eStartData + 2)
                tByteArr(1) = byGetData(eRcvDataLength.eStartData + 3)


                outGetValue = fConvertGetDoubleADC(fConvertInt16Byte(tByteArr))

            Else

                MsgBox("Data is incorrect!!", MsgBoxStyle.Critical, "Care!!")

                Return False
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
        Return True
    End Function
    Public Function Get_ADcAverCountOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue As Double, ByVal inChannel As Integer) As Boolean
        '1채널 Adc Aver Set Read (0x2128)
        ReDim byFieldData(0)
        outGetValue = Nothing

        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        '

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_AverCountADc_OneChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e1Byte
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If


        Try
            If Int(byGetData(eRcvDataLength.eStartData)) = inChannel Then



                outGetValue = Int(byGetData(eRcvDataLength.eStartData + 2))

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try


        Return True

    End Function
    Public Function Get_ReadADcOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue As Double, ByVal inChannel As Integer) As Boolean
        '1채널 ADC Read (0x2126)
        'ch 0 ~ 55
        ReDim byFieldData(0)
        outGetValue = 0

        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        '

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_ReadADc_OneChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e2Byte 'ch byte + reserve byte + data byte ( 2byte)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , tRcvDataLength : 수신될 Data 바이트 길이

            Return False
        End If



        Try
            If Int(byGetData(eRcvDataLength.eStartData)) = inChannel Then

                Dim tByteArr(1) As Byte
                tByteArr(0) = byGetData(eRcvDataLength.eStartData + 2) '+2 reserve 1byte
                tByteArr(1) = byGetData(eRcvDataLength.eStartData + 3)


                outGetValue = fConvertGetDoubleADC(fConvertInt16Byte(tByteArr))
            Else
                MsgBox("Data is incorrect!!", MsgBoxStyle.Critical, "Care!!")
                Return False
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
        Return True
    End Function
    Public Function Get_ReadADcAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue() As Double) As Boolean
        '전체 채널 ADC Read (0x2127)
        'max ch 56
        ReDim byFieldData(Nothing)
        Dim tCount As Integer = 2

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_ReadADc_AllChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        byGetData = SendCommand(bySetData)

        Dim tRcvDataLength As Integer = Max_ADC_Channel * tCount '
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If

        Try

            ReDim outGetValue(Max_ADC_Channel - 1)

            For cnt As Integer = 0 To Max_ADC_Channel - 1

                Dim tByteArr(1) As Byte
                tByteArr(0) = byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 0)
                tByteArr(1) = byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 1)
                outGetValue(cnt) = fConvertGetDoubleADC(fConvertInt16Byte(tByteArr))

            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        Return True


    End Function
    Public Function Get_PulseAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue() As sPulseParam) As Boolean
        '전체 채널 Pulse 설정 읽기(0x2125)
        'max ch 54
        ReDim byFieldData(Nothing)
        ReDim outGetValue(Nothing)
        Dim tCount As Integer = 3 * 3 '한채널당 3개 항목 1개 항목당 3byte

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_Pulse_AllChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)

        Dim tRcvDataLength As Integer = Max_Pulse_Channel * tCount
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If




        Try

            ReDim outGetValue(Max_Pulse_Channel - 1)

            Dim tByteArr(2) As Byte
            For cnt As Integer = 0 To Max_Pulse_Channel - 1


                tByteArr(0) = Int(byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 0))
                tByteArr(1) = Int(byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 1))
                tByteArr(2) = Int(byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 2))
                outGetValue(cnt).Period = fConvertInt24Byte(tByteArr) * 10

                tByteArr(0) = Int(byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 3))
                tByteArr(1) = Int(byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 4))
                tByteArr(2) = Int(byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 5))
                outGetValue(cnt).Width = fConvertInt24Byte(tByteArr) * 10

                tByteArr(0) = Int(byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 6))
                tByteArr(1) = Int(byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 7))
                tByteArr(2) = Int(byGetData(eRcvDataLength.eStartData + (tCount * cnt) + 8))
                outGetValue(cnt).Delay = fConvertInt24Byte(tByteArr) * 100


            Next





        Catch ex As Exception

            MsgBox(ex.ToString)
            Return False
        End Try


        Return True

    End Function
    Public Function Get_PulseOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outPulseInfo As sPulseParam, ByVal inChannel As Integer) As Boolean
        '개별 채널 Pulse 설정 (0x2124)
        'ch 0 ~ 53
        ReDim byFieldData(0)

        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_Pulse_OneChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e3Byte * 3 'ch byte + reserve byte + data byte ( 3 byte) * 3 종류 값
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If


        Try
            If Int(byGetData(eRcvDataLength.eStartData)) = inChannel Then

                Dim tByteArr(2) As Byte
                tByteArr(0) = (byGetData(eRcvDataLength.eStartData + 2))
                tByteArr(1) = (byGetData(eRcvDataLength.eStartData + 3))
                tByteArr(2) = (byGetData(eRcvDataLength.eStartData + 4))
                outPulseInfo.Period = fConvertInt24Byte(tByteArr) * 10

                tByteArr(0) = (byGetData(eRcvDataLength.eStartData + 5))
                tByteArr(1) = (byGetData(eRcvDataLength.eStartData + 6))
                tByteArr(2) = (byGetData(eRcvDataLength.eStartData + 7))
                outPulseInfo.Width = fConvertInt24Byte(tByteArr) * 10

                tByteArr(0) = (byGetData(eRcvDataLength.eStartData + 8))
                tByteArr(1) = (byGetData(eRcvDataLength.eStartData + 9))
                tByteArr(2) = (byGetData(eRcvDataLength.eStartData + 10))
                outPulseInfo.Delay = fConvertInt24Byte(tByteArr) * 100


            Else

                MsgBox("Data is incorrect!!", MsgBoxStyle.Critical, "Care!!")
                Return True
            End If




        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        Return True

    End Function
    Public Function Get_FinalOutputAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue() As eFoutput) As Boolean
        '전체 채널 Final output 설정읽기 (0x2123)
        'max ch 54
        ReDim byFieldData(Nothing)
        ReDim outGetValue(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_FinalOut_AllChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = Max_Pulse_Channel 'data byte 
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If


        Try
            Dim tCount As Integer = 1


            ReDim outGetValue(Max_Pulse_Channel - 1)


            For cnt As Integer = 0 To Max_Pulse_Channel - 1


                outGetValue(cnt) = Int(byGetData(eRcvDataLength.eStartData + (tCount * cnt)))

            Next



        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        Return True
    End Function
    Public Function Get_FinalOutputOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef inFOut As eFoutput, ByVal inChannel As Integer) As Boolean
        '개별 채널 Foutput 설정 (0x2122)
        'ch 0~ 53
        ReDim byFieldData(0)
        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        '

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_FinalOut_OneChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)

        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e1Byte 'ch byte + reserve byte + data byte (1byte)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , tRcvDataLength : 수신될 Data 바이트 길이
            Return False
        End If


        Try

            If Int(byGetData(eRcvDataLength.eStartData)) = inChannel Then
                inFOut = Int(byGetData(eRcvDataLength.eStartData + 2)) '+2 는 reserve 1byte


            Else
                MsgBox("Data is incorrect!!", MsgBoxStyle.Critical, "Care!!")
                Return False
            End If




        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
        Return True

    End Function
    Public Function Get_OnOffAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue() As eOnOff) As Boolean
        '전체 채널 Onf 설정 일기 (0x2121)
        'max ch 54
        ReDim byFieldData(Nothing)
        ReDim outGetValue(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_OnOFF_AllChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = Max_Pulse_Channel ' data byte 
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, Max_Pulse_Channel) = False Then
            Return False
        End If



        Try


            Dim tCount As Integer = 1



            ReDim outGetValue(Max_Pulse_Channel - 1)


            For cnt As Integer = 0 To Max_Pulse_Channel - 1


                outGetValue(cnt) = Int(byGetData(eRcvDataLength.eStartData + (tCount * cnt)))

            Next







        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
        Return True

    End Function
    Public Function Get_SyncAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue() As eOnOff, ByVal inMaxChannel As Integer) As Boolean
        '전체 채널 SYnc 설정 일기 (0x2129)
        'max ch 54
        ReDim byFieldData(Nothing)
        ReDim outGetValue(Nothing)

        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_Pulse_AllChannelSync, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = inMaxChannel ' data byte 
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, inMaxChannel) = False Then
            Return False
        End If



        Try


            Dim tCount As Integer = 1



            ReDim outGetValue(inMaxChannel - 1)


            For cnt As Integer = 0 To inMaxChannel - 1


                outGetValue(cnt) = Int(byGetData(eRcvDataLength.eStartData + (tCount * cnt)))

            Next







        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
        Return True

    End Function
    Public Function Get_OnoffOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outOnOff As eOnOff, ByVal inChannel As Integer) As Boolean
        '개별 채널 OnOff 설정 읽기 (0x2120)
        ReDim byFieldData(0)

        byFieldData(0) = "&H" & Hex(inChannel) 'channel

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_OnOFF_OneChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e1Byte 'ch byte + reserve byte + data byte ( 1byte)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If


        Try
            If Int(byGetData(eRcvDataLength.eStartData)) = inChannel Then
                outOnOff = Int(byGetData(eRcvDataLength.eStartData + 2)) '+2 인 이유 reserve 1byte 

            Else

                MsgBox("Data is incorrect!!", MsgBoxStyle.Critical, "Care!!")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try




        Return True
    End Function
    Public Function Get_SelectModeAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue() As eDacMode) As Boolean
        '전체 채널 Dac 출력 모드 설정 읽기 (0x2111)
        ReDim byFieldData(Nothing)


        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_Mode_AllChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)

        Dim tRcvDataLength As Integer = Max_Pulse_Channel
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If



        Try


            Dim tCount As Integer = 1



            ReDim outGetValue(Max_Pulse_Channel - 1)


            For cnt As Integer = 0 To Max_Pulse_Channel - 1


                outGetValue(cnt) = Int(byGetData(eRcvDataLength.eStartData + (tCount * cnt)))

            Next



        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        Return True
    End Function
    Public Function Get_SelectModeOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outMode As eDacMode, ByVal inChannel As Integer) As Boolean
        '개별 채널 Dac 출력 모드 설정 읽기   (0x2110)
        'ch 0 ~ 53 만 가능
        ReDim byFieldData(0)
        outMode = Nothing

        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        '

        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_Mode_OneChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e1Byte 'ch byte + reserve byte + data byte ( 1byte)
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then
            Return False
        End If


        Try
            If Int(byGetData(eRcvDataLength.eStartData)) = inChannel Then
                outMode = byGetData(eRcvDataLength.eStartData + 2) '+2인 이유는 reserved byte


            Else

                MsgBox("Data is incorrect!!", MsgBoxStyle.Critical, "Care!!")
                Return False
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

        Return True
    End Function
    Public Function Get_OutputAllChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue() As Double) As Boolean
        '전체 채널 DAC 읽기 (0x2101) 
        'max channel 108
        ReDim byFieldData(Nothing)


        nData_Len = 0

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_Out_AllChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        ' bySetData = Set_FiledInfo()
        byGetData = SendCommand(bySetData)

        Dim tRcvDataLength As Integer = Max_DAC_Channel * 2 ' 채널 당 2byte
        Dim outDataLen As Integer
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , tRcvDataLength : 수신될 Data 바이트 길이
            Return False
        End If






        Try
            Dim tCount As Integer = 2 '2byte



            ReDim outGetValue(Max_DAC_Channel - 1) '데이터 갯수 만큼 재할당


            For cnt As Integer = 0 To Max_DAC_Channel - 1


                Dim tByteArr(1) As Byte
                tByteArr(0) = byGetData(8 + (tCount * cnt) + 0)
                tByteArr(1) = byGetData(8 + (tCount * cnt) + 1)


                outGetValue(cnt) = fConvertGetDouble(fConvertInt16Byte(tByteArr))

            Next


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try






        Return True

    End Function
    Public Function Get_OutputOneChannel(ByVal inAddrs As Integer, ByVal inch As Integer, ByRef outErrCode As Integer, ByRef outGetValue As Double, ByVal inChannel As Integer) As Boolean
        '개별 채널 DAC Get
        'max channel 108
        ReDim byFieldData(0)
        outGetValue = Nothing
        byFieldData(0) = "&H" & Hex(inChannel) 'channel
        nData_Len = byFieldData.Length

        If Set_FieldInfo(inAddrs, inch, SG_Command, SG_Out_OneChannel, SG_GET_ERR, nData_Len, byFieldData, bySetData) = False Then
            Return False
        End If

        byGetData = SendCommand(bySetData)
        Dim outDataLen As Integer
        Dim tRcvDataLength As Integer = eRcvDataLength.eChByte + eRcvDataLength.eReserve + eRcvDataLength.e2Byte 'ch byte + reserve byte + data byte ( 2byte)
        If Err_Check(byGetData, outErrCode, outDataLen, tRcvDataLength) = False Then 'byGetData : 수신 data , OutErrcode : 에러 유무  , tRcvDataLength : 수신될 바이트 길이
            Return False
        End If



        Try
            If Int(byGetData(eRcvDataLength.eStartData)) = inChannel Then
                Dim tByteArr(1) As Byte
                tByteArr(0) = byGetData(eRcvDataLength.eStartData + 2) '+2 를 하는 이유 Reserve 1Byte
                tByteArr(1) = byGetData(eRcvDataLength.eStartData + 3)




                Dim tScaleVal As Double = fConvertGetDouble(fConvertInt16Byte(tByteArr))
                outGetValue = tScaleVal

            Else

                MsgBox("Data is incorrect!!", MsgBoxStyle.Critical, "Care!!")
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try




        Return True
    End Function
    Public Function fCheckAlarm(ByVal inType As Boolean, ByVal inValue As Byte) As String

        Dim rStr As String = Dec2Bin(fConvertInt8Byte(inValue))
        Dim t2BinStr As String = "0"
        If rStr.Length <= 8 Then
            For Cnt As Integer = rStr.Length - 1 To 0 Step -1
                t2BinStr = rStr.Substring(Cnt, 1)

                If inType = True Then
                    'Register Error Check  1st Byte

                    If t2BinStr = "1" Then
                        Select Case Cnt

                            Case 0
                                MsgBox("TBD")
                            Case 1
                                MsgBox("TBD")
                            Case 2
                                MsgBox("TBD")
                            Case 3
                                MsgBox("TBD")
                            Case 4
                                MsgBox("TBD")
                            Case 5
                                MsgBox("TBD")
                            Case 6
                                MsgBox("TBD")
                            Case 7
                                MsgBox("TBD")

                        End Select
                    End If

                ElseIf inType = False Then
                    'Register Error Check  2nd Byte

                    If t2BinStr = "1" Then
                        Select Case Cnt

                            Case 0
                                MsgBox("TBD")
                            Case 1
                                MsgBox("TBD")
                            Case 2
                                MsgBox("TBD")
                            Case 3
                                MsgBox("TBD")
                            Case 4
                                MsgBox("TBD")
                            Case 5
                                MsgBox("TBD")
                            Case 6
                                MsgBox("Limit Alarm")
                                Return "Limit Alarm"
                            Case 7
                                MsgBox("TBD")

                        End Select
                    End If
                End If

            Next

        Else
            MsgBox("The received value is incorrect!!", MsgBoxStyle.Critical, "Care!!")
            Return "Error"
        End If
        Return "Success"
    End Function
#End Region

#Region "Convert Function"
    Private Function fConvertInt8Byte(ByVal inValue As Byte) As Integer


        Dim bVal As Integer



        Dim convertedValue As CUnitCommonNode.SplitUINT8
        convertedValue.ByteData = inValue


        bVal = convertedValue.UINT8_Data



        Return bVal
    End Function
    Private Function fConvertByteInt16(ByVal inValue As Integer) As Byte()


        Dim bVal(1) As Byte



        Dim convertedValue As CUnitCommonNode.SplitUINT16
        convertedValue.UINT16_Data = inValue


        bVal(1) = (convertedValue.ByteData_L)
        bVal(0) = (convertedValue.ByteData_H)



        Return bVal
    End Function
    Private Function fConvertInt16Byte(ByVal inValueArr() As Byte) As Integer


        Dim bVal(1) As Byte



        Dim convertedValue As CUnitCommonNode.SplitUINT16



        convertedValue.ByteData_L = inValueArr(1)
        convertedValue.ByteData_H = inValueArr(0)



        Return convertedValue.UINT16_Data
    End Function
    Private Function fConvertInt24Byte(ByVal inValueArr() As Byte) As UInteger


        Dim bVal(1) As Byte



        Dim convertedValue As CUnitCommonNode.SplitUINT24



        convertedValue.ByteDataL = inValueArr(2)
        convertedValue.ByteDataM = inValueArr(1)
        convertedValue.ByteDataH = inValueArr(0)



        Return convertedValue.UINT24_Data
    End Function
    Private Function fConvert24ByteInt(ByVal inValue As UInteger) As Byte()


        Dim bVal(2) As Byte



        Dim convertedValue As CUnitCommonNode.SplitUINT24
        convertedValue.UINT24_Data = inValue


        bVal(2) = convertedValue.ByteDataL
        bVal(1) = convertedValue.ByteDataM
        bVal(0) = convertedValue.ByteDataH



        Return bVal
    End Function
    Private Function fConvertSingleByte(ByVal inValueArr() As Byte) As Single

        Dim bVal(3) As Byte

        Try

            If inValueArr.Length = 4 Then
                Dim convertedValue As CUnitCommonNode.SplitSingle

                convertedValue.ByteData0_L = inValueArr(0)
                convertedValue.ByteData0_H = inValueArr(1)
                convertedValue.ByteData1_L = inValueArr(2)
                convertedValue.ByteData1_H = inValueArr(3)


                If inValueArr(0) = &HFF And inValueArr(1) = &HFF And inValueArr(2) = &HFF And inValueArr(3) = &HFF Then
                    Return 0
                Else
                    Return convertedValue.SingleData
                End If

            Else
                Return 0
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try

        Return 0

    End Function
    Private Function fConvertByteSingle(ByVal inValue As Single) As Byte()

        Dim bVal(3) As Byte



        Dim convertedValue As CUnitCommonNode.SplitSingle
        convertedValue.SingleData = inValue


        bVal(0) = convertedValue.ByteData0_L '
        bVal(1) = convertedValue.ByteData0_H 'convertedValue.ByteData0_H
        bVal(2) = convertedValue.ByteData1_L
        bVal(3) = convertedValue.ByteData1_H



        Return bVal
    End Function
    Private Function DecToBin(ByVal ival As Long) As String
        Dim redata As String = ""
        Do Until ival = 0
            redata = CStr((ival Mod 2)) + redata
            ival = ival \ 2
        Loop
        If redata = "" Then

            redata = "0"
        End If

        Return redata
    End Function
    Public Function fConvertGetDoubleADC(ByVal inValue As Double) As Double
        Return (inValue / &HFFFF) * 10 - 5

        'Return (inValue / ((2 ^ 15) - 1)) * 10 - 5
    End Function
    Public Function fConvertSetDoubleADC(ByVal inValue As Double) As Double
        Return ((inValue + 5) / 10) * ((2 ^ 16) - 1) 'Int16 변환 수식
    End Function
    Public Function fConvertGetDouble(ByVal inValue As Double) As Double
        Return (inValue / &H3FFF) * 10 - 5
    End Function
    Public Function fConvertSetDouble(ByVal inValue As Double) As Double
        Return ((inValue + 5) / 10) * ((2 ^ 14) - 1) 'Int16 변환 수식
    End Function
    Public Function Dec2Bin(ByVal inValue As Integer) As String


        Dim d As Integer
        Dim n As Integer = inValue
        Dim m As Integer
        Dim ret As String = ""

        Do
            d = n \ 2 '몫
            m = n Mod 2 '나머지
            ret = CStr(m) & ret '나머지 보관(문자열)

            n = d
        Loop Until d < 2

        If d > 0 Then ret = d & ret

        Return ret
    End Function
#End Region

End Class
