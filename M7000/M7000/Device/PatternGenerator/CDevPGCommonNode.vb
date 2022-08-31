Imports G4xHMI
Imports G4SDataLibrary
Imports System.Threading
Imports CCommLib

Public Class CDevPGCommonNode


#Region "Define"

    Public Event evChangedConnectedClients(ByVal list() As String)
    Public Event evDisconnectedToClient(ByVal targetCh As Integer)
    Public Event evStatusMessage(ByVal msg As String)

    Public cMcPG() As cDevMcPG  '1개의 Device는 8개의 모듈 담당
    Public cMcPDMeasUnit() As CDevPDUnit  '1개의 Device는 32개의 PD 센싱 (모듈당 1개의 PD로 센싱하면 32채널임)
    Public cMcPGPwr As cDevMcPGPower
    Public cMcPGCtrl As cDevMcPGControl
    Public cMcEIPPG As CDevEIPPG

    Protected m_MyModel As eDevModel
    Protected m_ConfigInfo As CCommLib.CComCommonNode.sCommInfo
    Protected m_CommStatus As CCommLib.CComCommonNode.eTransferState
    Protected m_bIsConnected As Boolean = False
    Protected m_bIsConnectedSubCh() As Boolean
    Protected m_bIsPaused As Boolean = False    'Sequence Routine을 일시 정지 시킵니다. 개별 제어 시에 중복 접근을 막기 위하여.
    Protected m_SeqRoutineStatus() As eSequenceState
    Protected m_SeqRoutineBeforStatus() As eSequenceState
    Protected m_SubSeqRoutineStatus() As eSubSequenceState
    Protected m_MeasuredData() As sMeasuredDatas
    Protected m_sStatusMsg As String
    Protected m_GraySweepMeas As Boolean = False
    Dim m_bEnableEvent As Boolean = False

    Protected myParent As frmMain

    Protected m_GrayScale As ucDispPGGrayScale.sPGGrayScale

    Shared sSupportDeviceList() As String = New String() {"Nothing", "McPG", "G4S", "EIP"}

    '====================================================================
    'Only for GnT System Module Driver : G4s
    Protected m_sGnTModelNames() As String    'Model Directory Names

    Public GnT_DriveData As G4SDataLibrary.CDriveData   '채널별 구동 데이터 저장 



#Region "Enums"


    Public Enum eDevModel
        _Nothing
        _McPG
        _G4S
        _EIP
    End Enum

    'Public Enum eSequenceState
    '    eidle
    '    ePowerON
    '    ePowerOFF
    '    eSetPattern
    '    eAutoSlide
    '    eCheckState
    '    eMeasuring
    '    eReset
    'End Enum

    Public Enum eSequenceState
        eidle
        eON
        eReset
        eMeasuring
        eSetPattern
        eAutoSlide
        eCheckState
        eReadCal
        eChangePattern_Next
        eChangePattern_Befor
        eGnT_Update_DriveData_All
        eGnT_Update_DriveData_Model
        eGnT_Update_DriveData_Pattern
        eGnT_Update_DriveData_Initial
        eGnT_Update_DriveData_Faild
        eGnT_Update_DriveData_OK
    End Enum

    Public Enum eSubSequenceState
        eIDEL
        eGraySweep
        eLifetime
        eSubReset
    End Enum

#End Region




    Public Structure sPGConfigParams
        Dim nDevice As eDevModel
        Dim sMcPGConfig() As CSeqRoutineMcPG.sInitParam
        Dim sG4SConfig As CDevG4S.sInitParam
    End Structure

    Public Structure sMeasuredDatas
        Dim sMcPG As CSeqRoutineMcPG.sMeasuredData
        Dim sG4S As CDevG4S.sG4SDatas
    End Structure

#End Region

#Region "Properties"


    Public Overridable Property GraySweepMeasStatus() As Boolean
        Get
            Return m_GraySweepMeas
        End Get
        Set(ByVal value As Boolean)
            m_GraySweepMeas = value
        End Set
    End Property


    Public Overridable ReadOnly Property SubChannelStatus() As eSubSequenceState()
        Get
            Return m_SubSeqRoutineStatus
        End Get
    End Property

    '======================================================================

    Public Shared ReadOnly Property SupportDeviceNames() As String()
        Get
            Return sSupportDeviceList.Clone
        End Get
    End Property

    Public Overridable ReadOnly Property MeasuredData(ByVal ch As Integer) As sMeasuredDatas ' CSeqRoutineMcPG.sMeasuredData
        Get
            Return m_MeasuredData(ch)
        End Get
    End Property


    Public Overridable Property Model As eDevModel
        Get
            Return m_MyModel
        End Get
        Set(ByVal value As eDevModel)
            m_MyModel = value
        End Set
    End Property

    Public Overridable Property Config As CCommLib.CComCommonNode.sCommInfo
        Get
            Return m_ConfigInfo
        End Get
        Set(ByVal value As CCommLib.CComCommonNode.sCommInfo)
            m_ConfigInfo = value
        End Set
    End Property

    Public Overridable ReadOnly Property IsConnected As Boolean
        Get
            Return m_bIsConnected
        End Get
    End Property

    Public Overridable ReadOnly Property IsConnectedSubChannel As Boolean()
        Get
            Return m_bIsConnectedSubCh
        End Get
    End Property


    Public Overridable Property EnableSequenceRoutinePaused()
        Get
            Return m_bIsPaused
        End Get
        Set(ByVal value)
            m_bIsPaused = value
        End Set
    End Property

    Public Overridable ReadOnly Property ChannelStatus() As eSequenceState()
        Get
            Return m_SeqRoutineStatus
        End Get
    End Property

    Public Overridable ReadOnly Property BeforStatus() As eSequenceState()
        Get
            Return m_SeqRoutineBeforStatus
        End Get
    End Property


    Public Overridable Property StatusMessage As String
        Get
            Return m_sStatusMsg
        End Get
        Set(ByVal value As String)
            m_sStatusMsg = value
            If m_bEnableEvent = True Then
                RasieEvent_StateMessage(m_sStatusMsg)
            End If
        End Set
    End Property


    Public Overridable ReadOnly Property ClientList As String()
        Get
            Return Nothing
        End Get
    End Property


    Public Overridable Property EnableEvent As Boolean
        Get
            Return m_bEnableEvent
        End Get
        Set(ByVal value As Boolean)
            m_bEnableEvent = value
        End Set
    End Property



    '=====================================================
    'Only for GNT Systems Module Driver : G4s
    '=====================================================
    Public Overridable ReadOnly Property ModelNames As String()
        Get
            Return m_sGnTModelNames
        End Get
    End Property

    Public Overridable Function EIPPG_ON() As Boolean
        Return False
    End Function
    Public Overridable Function EIPPG_OFF() As Boolean
        Return False
    End Function


    'Public Property OffLineMode() As Boolean
    '    Get
    '        Return m_bIsOffLine
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        m_bIsOffLine = Value
    '    End Set
    'End Property


#End Region

#Region "Creator, Disposer And Init"

    Public Sub New()

    End Sub


    Public Overridable Sub Dispose()

    End Sub

#End Region


#Region "Functions"

    Public Overridable Function Connection(ByVal config As CSeqRoutineMcPG.sCommInfo) As Boolean
        Return False
    End Function

    Public Overridable Function Connection(ByVal config As CCommLib.CComSocket.sSockInfos, ByVal timeOut As Single) As Boolean
        'm_CommSettings = config

        ''server open
        'Open(timeOut)

        'Do
        '    Application.DoEvents()
        '    Thread.Sleep(1)
        'Loop Until server.IsServerClosed = True

        'StartThread()
        Return False
    End Function
    Public Overridable Function Connection(ByVal config As CCommLib.CComCommonNode.sCommInfo) As Boolean
        Return False
    End Function
    Public Overridable Function Connection(ByVal config As CComSerial.sSerialPortInfo) As Boolean
        Return False
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub Disconnection()

    End Sub

    Public Overridable Sub Disconnection(ByVal ch As Integer)

    End Sub


    Public Overridable Function Request(ByVal ch As Integer, ByVal state As eSequenceState) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' McPG use only
    ''' </summary>
    ''' <param name="ch"></param>
    ''' <param name="state"></param>
    ''' <param name="setting"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Request(ByVal ch As Integer, ByVal state As eSequenceState, ByVal setting As CSeqRoutineMcPG.sSettingParam) As Boolean
        Return False
    End Function


    ''' <summary>
    ''' G4s Pattern Generator use only
    ''' </summary>
    ''' <param name="ch"></param>
    ''' <param name="state"></param>
    ''' <param name="autoSlideInfo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Request(ByVal ch As Integer, ByVal state As eSequenceState, ByVal autoSlideInfo As CDevG4S.sG4SAutoSlideSettings) As Boolean
        Return False
    End Function

    ''' <summary>
    ''' G4s Pattern Generator use only
    ''' </summary>
    ''' <param name="nCh"></param>
    ''' <param name="state"></param>
    ''' <param name="PatternIdx"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Request(ByVal nCh As Integer, ByVal state As eSequenceState, ByVal PatternIdx As Integer) As Boolean
        Return False
    End Function



    ''' <summary>
    ''' G4s Pattern Generator use only
    ''' </summary>
    ''' <param name="nCh"></param>
    ''' <param name="state"></param>
    ''' <param name="modelName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Request(ByVal nCh As Integer, ByVal state As eSequenceState, ByVal modelName As String) As Boolean
        Return False
    End Function

#End Region


#Region "Event Functions"


    Public Sub RaiseEvent_ChangedConnectedClients(ByVal list() As String)
        RaiseEvent evChangedConnectedClients(list)
        Application.DoEvents()
        Thread.Sleep(10)
    End Sub

    Public Sub RasieEvent_StateMessage(ByVal msg As String)
        RaiseEvent evStatusMessage(msg)
        Application.DoEvents()
        Thread.Sleep(10)
    End Sub

    Public Sub RaiseEvent_DisconnectedClient(ByVal targetCh As Integer)
        RaiseEvent evDisconnectedToClient(targetCh)
        Application.DoEvents()
        Thread.Sleep(10)
    End Sub


#End Region

#Region "other functions"

    Public Shared Function ConvertDeviceModelStringToInt(ByVal str As String) As eDevModel
        Select Case str
            Case eDevModel._Nothing.ToString
                Return eDevModel._Nothing
            Case eDevModel._McPG.ToString
                Return eDevModel._McPG
            Case eDevModel._G4S.ToString
                Return eDevModel._G4S
            Case eDevModel._EIP.ToString
                Return eDevModel._EIP
            Case Else
                Return -1
        End Select
    End Function

#End Region






End Class
