Imports CCommLib
Imports G4xHMI
Imports System.Threading
Imports System
Imports System.IO
Imports G4SDataLibrary

Public Class CDevG4S
    Inherits CDevPGCommonNode

#Region "Define"


    Dim g_sPath_MyGnT As String = Application.StartupPath & "\G5"
    Dim g_sPath_MyGnT_Image As String = g_sPath_MyGnT & "\Image"
    Dim g_sPath_MyGnT_Model As String = g_sPath_MyGnT & "\Model"
    Dim g_sPath_MyGnT_Config As String = g_sPath_MyGnT & "\Config.ini"
    Dim g_sPath_MyGnT_ModelList As String = g_sPath_MyGnT & "\ModelList.ini"

    Dim gntPath As String = "C:\G5"
    Dim gntPath_Image As String = gntPath & "\Image"
    Dim gntPath_Model As String = gntPath & "\Model"
    Dim gntPath_Config As String = gntPath & "\Config.ini"
    Dim gntPath_ModelList As String = gntPath & "\ModelList.ini"

    Dim WithEvents server As CComTCPServer

    Dim m_CommSettings As CCommLib.CComSocket.sSockInfos   'Server IP And Port


    Dim GnT_DataModule As New ClassData_MultiRackStatus   'Data Frame Generation Class

    Dim GnT_GNTI As Class_GTITransfer    'Scenario Status Control

    Dim m_nMaxCh As Integer     '
    Dim m_nSeedIndex As Integer    'G4S 장비(Client) 중에서 가장 작은 IP 번호(ex: 192.168.0.11 에서 11)
    Dim requestQueue As Queue
    '  Dim g_SeqRoutineStatus() As eSequenceState
    Dim m_setInfos() As sG4SSettings   'G4s Control settings
    'Dim m_MeasuredDatas() As sG4SDatas 'G4s Measurement data


    Public Structure sG4SSettings
        Dim nCh As Integer
        Dim eState As eSequenceState    '현재 상태
        Dim eBeforState As eSequenceState   '이전 상태
        Dim nPatternIdx As Integer
        Dim autoSlide As sG4SAutoSlideSettings
        Dim sModelName As String
    End Structure


    Public Structure sInitParam
        Dim nServerOpenTime_sec As Integer
        Dim sServerIP As String
        Dim nServerPort As Integer
        Dim sSeedIP As String
        Dim bIsOffLine As Boolean
        Dim nNumberOfDev As Integer
        Dim nAllocationCh_From As Integer
        Dim nAllocationCh_To As Integer
        Dim iAllocationCh() As Integer
    End Structure


    Public Structure sG4SAutoSlideSettings
        Dim nAutoSlidePatternIdx() As Integer
        Dim dAutoSlideDelays() As Single
    End Structure

    Public Structure sG4SDatas
        Dim Device As eDevice
        Dim PowerState As ePowerState
        Dim MeasState As Boolean
        Dim nPatternIdx As Integer
        Dim IDD_mA As Double
        Dim ICI_mA As Double
        Dim IBAT_mA As Double
        Dim nColor_Red As Integer
        Dim nColor_Green As Integer
        Dim nColor_Blue As Integer
    End Structure

    Public Enum ePowerState
        _ON
        _OFF
    End Enum

    Public Enum eDevice
        G5_G2x = 1
        FPMS = 2
        G4x = 3
    End Enum



#End Region

#Region "Properties"

    Public Overrides ReadOnly Property IsConnectedSubChannel As Boolean()
        Get
            Return MyBase.IsConnectedSubChannel
        End Get
    End Property


    Public Overrides ReadOnly Property ChannelStatus As CDevPGCommonNode.eSequenceState()
        Get
            Dim state(m_setInfos.Length - 1) As eSequenceState
            For i As Integer = 0 To m_setInfos.Length - 1
                state(i) = m_setInfos(i).eState
            Next
            m_SeqRoutineBeforStatus = state.Clone
            Return MyBase.BeforStatus
        End Get
    End Property

    Public Overrides ReadOnly Property BeforStatus As CDevPGCommonNode.eSequenceState()
        Get
            Dim state(m_setInfos.Length - 1) As eSequenceState
            For i As Integer = 0 To m_setInfos.Length - 1
                state(i) = m_setInfos(i).eBeforState
            Next
            Return MyBase.BeforStatus
        End Get
    End Property

    Public Overrides ReadOnly Property ClientList As String()
        Get
            Return server.ClientList.Clone
        End Get
    End Property


    Public Overrides ReadOnly Property ModelNames As String()
        Get
            Return m_sGnTModelNames
        End Get
    End Property

    Public Overrides Property StatusMessage As String
        Get
            Return MyBase.StatusMessage
        End Get
        Set(ByVal value As String)
            MyBase.StatusMessage = value
        End Set
    End Property

#End Region

#Region "Creator, Disposer And init"



    Dim check_Process As Boolean = False

    Dim bufSetInfo As sG4SSettings
    Dim sWaitTimes() As Single
    Dim nAutoSlidePatternCnt() As Integer
    Dim sAutoSlidePatternDispTimes() As Single  '표시된 시작 시간
    Dim sAutoSlidePatternDispDeltaTime() As Single   '패턴 표시된 시간으로 부터 지난 시간
    Dim bAutoSlideState() As Boolean    '초기 상태 확인, 
    Dim dataList()() As CDevG4S.sG4SDatas
    Dim dataCnt() As Integer

    '명령 처리 타임아웃 확인용
    Dim sTimeOutStartTime() As Single  '시작 시간
    Dim sTimeOutDeltaTime() As Single '경과 시간   = 현재시간 - 시작 시간

    Dim nErrorCount() As Integer '연속 오류 카운트 '접속 끈긴걸로 해석 하고 강제 접속 종료. 루틴 정지

    Dim nCntCh As Integer = 0


    Public Sub New(ByVal parent As frmMain, ByVal seedIdx As Integer, ByVal numberOfDev As Integer)

        '     Comm = New CCommLib.CComAPI(CCommunicator.eCommType.eTCP)
        '   Comm.Communicator.TimeOut = 1000
        m_nMaxCh = numberOfDev
        m_nSeedIndex = seedIdx

        ' ReDim g_SeqRoutineStatus(m_nMaxCh - 1)
        ReDim m_setInfos(m_nMaxCh - 1)
        ReDim MyBase.m_bIsConnectedSubCh(m_nMaxCh - 1)
        ' ReDim m_MeasuredDatas(m_nMaxCh - 1)
        ReDim MyBase.m_MeasuredData(m_nMaxCh - 1)


        '=Use Sequence Routine==========================
        ReDim sWaitTimes(m_nMaxCh - 1)
        ReDim nAutoSlidePatternCnt(m_nMaxCh - 1)
        ReDim sAutoSlidePatternDispTimes(m_nMaxCh - 1)   '표시된 시작 시간
        ReDim sAutoSlidePatternDispDeltaTime(m_nMaxCh - 1)    '패턴 표시된 시간으로 부터 지난 시간
        ReDim bAutoSlideState(m_nMaxCh - 1)     '초기 상태 확인, 
        ReDim dataList(m_nMaxCh - 1)
        ReDim dataCnt(m_nMaxCh - 1)

        '명령 처리 타임아웃 확인용
        ReDim sTimeOutStartTime(m_nMaxCh - 1)   '시작 시간
        ReDim sTimeOutDeltaTime(m_nMaxCh - 1)  '경과 시간   = 현재시간 - 시작 시간
        ReDim nErrorCount(m_nMaxCh - 1)
        '============================================
        '
        server = New CComTCPServer
        requestQueue = New Queue
        MyBase.myParent = parent
        For i As Integer = 0 To m_nMaxCh - 1
            m_setInfos(i).nCh = i
            m_setInfos(i).eState = eSequenceState.eidle
            m_setInfos(i).eBeforState = eSequenceState.eidle
            m_bIsConnectedSubCh(i) = False
        Next

        If CopyGnTModelInfo() = False Then
            MsgBox("구동 파일 정보를 찾을 수 없습니다.")
        End If
        'If Directory.Exists(g_sPath_MyGnT) = False Then
        '    Directory.CreateDirectory(g_sPath_MyGnT)
        '    Directory.CreateDirectory(g_sPath_MyGnT & "\Model")
        '    Directory.CreateDirectory(g_sPath_MyGnT & "\Image")
        'End If

        ' ReDim GnT_DriveData(m_nMaxCh - 1)
        'ReDim GnT_GNTI(m_nMaxCh - 1)

        GnT_DriveData = New G4SDataLibrary.CDriveData(g_sPath_MyGnT)
        GnT_GNTI = New Class_GTITransfer

        'For i As Integer = 0 To m_nMaxCh - 1
        '    'GnT_DriveData(i) = New G4SDataLibrary.CDriveData(g_sPath_MyGnT)
        'Next

        If GnT_DriveData.UpdateModelList(m_sGnTModelNames) = False Then m_sGnTModelNames = Nothing

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Overrides Sub Dispose()
        'Disconnection()
        'cM6000 = Nothing
        Finalize()
    End Sub

#End Region

#Region "Abstract Functions"

    Public Overrides Function Connection(ByVal config As CCommLib.CComSocket.sSockInfos, ByVal timeOut As Single) As Boolean
        m_CommSettings = config

        'server open
        StopThread()

        Application.DoEvents()
        Thread.Sleep(100)

        Open(timeOut)

        Do
            Application.DoEvents()
            Thread.Sleep(100)
        Loop Until server.IsServerClosed = True

        'Server 접속 후 처리 대기
        Application.DoEvents()
        Thread.Sleep(10)

        For i As Integer = 0 To m_nMaxCh - 1
            If server.IsConnectedClients(i + m_nSeedIndex) = True Then
                MyBase.m_bIsConnectedSubCh(i) = True
            Else
                MyBase.m_bIsConnectedSubCh(i) = False
            End If
        Next

        If server.numberOfClients > 0 Then
            MyBase.m_bIsConnected = True
        Else
            MyBase.m_bIsConnected = False
            Return False
        End If

        StartThread()

        Return True
    End Function

    Public Overrides Sub Disconnection()
        Close()

        For i As Integer = 0 To m_nMaxCh - 1
            If server.clients(i + m_nSeedIndex) Is Nothing = False Then
                server.CloseClient(i + m_nSeedIndex)
                m_bIsConnectedSubCh(i) = False
            End If
        Next

        MyBase.m_bIsConnected = False
        'MyBase.RaiseEvent_ChangedConnectedClients(List)
    End Sub

    Public Overrides Sub Disconnection(ByVal ch As Integer)
        server.CloseClient(ch + m_nSeedIndex)
        m_bIsConnectedSubCh(ch) = False
    End Sub

#End Region

#Region "Functions"

    Public Function CopyGnTModelInfo() As Boolean

        Dim flgCopyImage As Boolean = False
        Dim flgCopyModel As Boolean = False

        'Check GnT SW Setup Path
        If Directory.Exists(gntPath) = False Then Return False


        'Copy Config.ini
        If File.Exists(gntPath_Config) = True Then
            If File.Exists(g_sPath_MyGnT_Config) = True Then
                File.Delete(g_sPath_MyGnT_Config)
            End If

            File.Copy(gntPath_Config, g_sPath_MyGnT_Config)

        End If

        If File.Exists(gntPath_ModelList) = True Then
            If File.Exists(g_sPath_MyGnT_ModelList) = True Then
                File.Delete(g_sPath_MyGnT_ModelList)
            End If

            File.Copy(gntPath_ModelList, g_sPath_MyGnT_ModelList)

        End If

        'Copy ModelList.ini

        '이미지 폴더가 있으면 복사, 없으면 폴더만 생성
        If Directory.Exists(g_sPath_MyGnT) = False Then
            Directory.CreateDirectory(g_sPath_MyGnT)
        End If

        If Directory.Exists(gntPath_Image) = True Then
            If Directory.Exists(g_sPath_MyGnT_Image) = True Then
                My.Computer.FileSystem.DeleteDirectory(g_sPath_MyGnT_Image, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If

            flgCopyImage = True

        End If

        If Directory.Exists(g_sPath_MyGnT_Image) = False Then
            Directory.CreateDirectory(g_sPath_MyGnT_Image)
        End If

        'Model 폴더가 있으면 복사, 없으면 폴더만 생성ㄴ
        If Directory.Exists(gntPath_Model) = True Then
            If Directory.Exists(g_sPath_MyGnT_Model) = True Then
                My.Computer.FileSystem.DeleteDirectory(g_sPath_MyGnT_Model, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If

            flgCopyModel = True
        End If

        If Directory.Exists(g_sPath_MyGnT_Model) = False Then
            Directory.CreateDirectory(g_sPath_MyGnT_Model)
        End If

        Application.DoEvents()
        Thread.Sleep(100)

        If flgCopyImage = True Then
            My.Computer.FileSystem.CopyDirectory(gntPath_Image, g_sPath_MyGnT_Image)
        End If

        If flgCopyModel = True Then
            My.Computer.FileSystem.CopyDirectory(gntPath_Model, g_sPath_MyGnT_Model)
        End If

        Return True
    End Function


    Public Sub Open(ByVal timeout As Single)
        server.ServerOpenTime = timeout
        server.Open()
    End Sub

    Public Sub Close()
        server.Close()
        StopThread()
    End Sub

    Public Function PowerOn(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        byFrame = CurrentMeasure.SendMultiRackControl(G5InterfaceMultiRackControl.MRACK_CMD_POWER_ON)



        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, False) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        'If Comm.Communicator.SendToBytes(byFrame, byRcvFrame) = CCommunicator.eReturnCode.OK Then

        'Else
        '    Return False
        'End If

        Return True
    End Function

    Public Function PowerOff(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        byFrame = CurrentMeasure.SendMultiRackControl(G5InterfaceMultiRackControl.MRACK_CMD_POWER_OFF)

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, False) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        'If Comm.Communicator.SendToBytes(byFrame, byRcvFrame) = CCommunicator.eReturnCode.OK Then

        'Else
        '    Return False
        'End If

        Return True
    End Function

    Public Function GetCurrent(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        byFrame = CurrentMeasure.SendMultiRackControl(G5InterfaceMultiRackControl.MRACK_CMD_GET_CURRENT)

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, False) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        'If Comm.Communicator.SendToBytes(byFrame, byRcvFrame) = CCommunicator.eReturnCode.OK Then

        'Else
        '    Return False
        'End If

        Return True
    End Function

    Public Function GetRealTimeData(ByVal devID As Integer, ByRef datas As sG4SDatas) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing

        byFrame = CurrentMeasure.SendMultiRackControl(G5InterfaceMultiRackControl.MRACK_CMD_REALTIME_DATA)

        'If server.clients Then
        If server.clients(devID) Is Nothing Then Return False

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        If byRcvFrame Is Nothing = True Then
            StatusMessage = "Receive data Nothing, Dev IP : " & Format(devID, "000")
            Return False
        End If

        Try
            GnT_DataModule.SetData(byRcvFrame, 0)

            With datas

                .Device = GnT_DataModule.DeviceVersion
                .nPatternIdx = GnT_DataModule.PatternIndex
                .IDD_mA = GnT_DataModule.IDDValue.getCurrent(ClassType_Current.UNIT_TYPE.TYPE_mA)
                .ICI_mA = GnT_DataModule.ICIValue.getCurrent(ClassType_Current.UNIT_TYPE.TYPE_mA)
                .IBAT_mA = GnT_DataModule.IBATValue.getCurrent(ClassType_Current.UNIT_TYPE.TYPE_mA)
                .nColor_Red = GnT_DataModule.Red
                .nColor_Blue = GnT_DataModule.Blue
                .nColor_Green = GnT_DataModule.Green
                .PowerState = GnT_DataModule.PowerStatus
                .MeasState = GnT_DataModule.MeasureStat_PowerValid
            End With
        Catch ex As Exception
            StatusMessage = ex.ToString
            server.clients(devID).ClearStateMsg()
            Return False
        End Try

        Return True
    End Function


    Public Function GetRealTimeData_Avg(ByVal devID As Integer, ByRef datas As sG4SDatas, ByVal avgCnt As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim dataList(avgCnt - 1) As Double

        byFrame = CurrentMeasure.SendMultiRackControl(G5InterfaceMultiRackControl.MRACK_CMD_REALTIME_DATA)

        For i As Integer = 0 To dataList.Length - 1
            Application.DoEvents()
            Thread.Sleep(1000)
            If server.clients(devID).SendToBytes(byFrame, byRcvFrame) <> CComCommonNode.eReturnCode.OK Then
                StatusMessage = server.clients(devID).StateMessage
                server.clients(devID).ClearStateMsg()
                Return False
            End If

            GnT_DataModule.SetData(byRcvFrame, 0)

            With datas

                .Device = GnT_DataModule.DeviceVersion
                .nPatternIdx = GnT_DataModule.PatternIndex
                .IDD_mA = GnT_DataModule.IDDValue.getCurrent(ClassType_Current.UNIT_TYPE.TYPE_mA)
                .ICI_mA = GnT_DataModule.ICIValue.getCurrent(ClassType_Current.UNIT_TYPE.TYPE_mA)
                .IBAT_mA = GnT_DataModule.IBATValue.getCurrent(ClassType_Current.UNIT_TYPE.TYPE_mA)
                .nColor_Red = GnT_DataModule.Red
                .nColor_Blue = GnT_DataModule.Blue
                .nColor_Green = GnT_DataModule.Green
                .PowerState = GnT_DataModule.PowerStatus
                .MeasState = GnT_DataModule.MeasureStat_PowerValid
            End With
            dataList(i) = datas.IBAT_mA
        Next

        Dim dValue As Double = CDataSort.MedianFilter(dataList)

        datas.IBAT_mA = dValue

        Return True
    End Function

    Public Function PatternNext(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        byFrame = CurrentMeasure.SendMultiRackControl(G5InterfaceMultiRackControl.MRACK_CMD_PATTERN_NEXT)

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, False) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        Return True
    End Function

    Public Function PatternBack(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        byFrame = CurrentMeasure.SendMultiRackControl(G5InterfaceMultiRackControl.MRACK_CMD_PATTERN_BACK)

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, False) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        Return True
    End Function

    Public Function PatternChange(ByVal devID As Integer, ByVal patternNo As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        byFrame = CurrentMeasure.SendMultiRackControl(G5InterfaceMultiRackControl.MRACK_CMD_PATTERN_CHANGE, patternNo)

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, False) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        'If Comm.Communicator.SendToBytes(byFrame, byRcvFrame) = CCommunicator.eReturnCode.OK Then

        'Else
        '    Return False
        'End If

        Return True
    End Function


    Public Function GetStatus(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim commander As New G4xHMI.Class_Protocol.TcpIp.G5_TCPIP ' (G5InterfaceMultiRackControl.MRACK_CMD_PATTERN_CHANGE, patternNo)

        'commander.Make_Packet(
        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, False) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If
        'If Comm.Communicator.SendToBytes(byFrame, byRcvFrame) = CCommunicator.eReturnCode.OK Then

        'Else
        '    Return False
        'End If

        Return True
    End Function


#Region "구동데이터 관련"

    Public Function UpdateAll(ByVal devId As Integer) As Boolean


        If UpdateModel(devId) = False Then

            Return False
        End If


        If SendPatternList(devId) = False Then

            Return False
        End If


        If SendBMPImage(devId) = False Then

            Return False
        End If


        '시나리오만 날리면 된다. 아자~~!
        If TestBaseInitial(devId) = False Then
            Return False

        End If

        Return True
    End Function

    Public Function UpdateModel(ByVal devId As Integer) As Boolean

        StatusMessage = "Update Drive"

        If SetModelName(devId) = False Then
            StatusMessage = "Update Drive : Update model name error"
            Return False
        End If


        If SetModelData(devId) = False Then
            StatusMessage = "Update Drive : Update Model Data error"
            Return False
        End If


        If SetConfigData(devId) = False Then
            StatusMessage = "Update Drive : Update Config error"
            Return False
        End If

        StatusMessage = "Update Drive : Completed"
        Return True
    End Function

    Public Function SendPatternList(ByVal devId As Integer) As Boolean

        StatusMessage = "Pattern Update : Sent Pattern List Name"

        If SetPatternListName(devId) = False Then
            StatusMessage = "Pattern Update : Sent Pattern List Name Error"
            Return False
        End If


        StatusMessage = "Pattern Update : Sent Pattern List"

        If SetPatternList(devId) = False Then
            StatusMessage = "Pattern Update : Sent Pattern List Error"

            Return False
        End If
        StatusMessage = "Pattern Update : Completed Pattern List Update"
        Return True
    End Function

    Public Function SendBMPImage(ByVal devId As Integer) As Boolean

        Dim imageCnt As Integer = GnT_DriveData.UpdateImage.Count

        If imageCnt > 0 Then

            StatusMessage = "Nand Format"

            If NandFormat(devId) = False Then
                StatusMessage = "Nand Format Error"
                Return False
            End If


            For i As Integer = 0 To 100
                StatusMessage = "Nand Format - " & i.ToString("D2") & "%"
                Application.DoEvents()
                Thread.Sleep(40)
            Next

            Dim Drive As G4SDataLibrary.CDriveData.sModelTimeData = GnT_DriveData.Read

            For idx As Integer = 0 To imageCnt - 1

                '1
                StatusMessage = "Update BMP Image Info " & Format(idx + 1, "00")

                If SetBMPImgInfo(devId, idx) = False Then
                    StatusMessage = "Update BMP Image Info Error" & Format(idx + 1, "00")
                    Return False
                End If

                Dim width As Integer = Drive.Resolution.Width
                Dim height As Integer = Drive.Resolution.Height
                Dim Sleep As Integer = width * height * 3

                Sleep = Sleep / GnT_DriveData.Config.Image_Delay / 10

                '2
                StatusMessage = "Update BMP Image" & Format(idx + 1, "00")

                DownloadImage(devId, idx)

                For i As Integer = 0 To 100
                    Application.DoEvents()
                    Thread.Sleep(Sleep)
                Next

                If GnT_DriveData.Config.Image_Delay > 0 Then
                    StatusMessage = "Delay: " & GnT_DriveData.Config.Image_Delay.ToString() & " ms"
                    For i As Integer = 0 To GnT_DriveData.Config.Image_Delay
                        Application.DoEvents()
                        Thread.Sleep(1)
                    Next
                End If

            Next

        End If

        StatusMessage = "Pattern Update : Downloaded BMP Image"

        Return True
    End Function

    Public Function TestBaseInitial(ByVal devId As Integer) As Boolean

        Dim upgradeRun As Boolean = True
        Dim fileSize As Integer = 0
        Dim crc As UShort = 0

        Dim diffTime As TimeSpan

        Try

            Dim Value As G4SDataLibrary.CDriveData.GNTIBinFile = GnT_DriveData.GNTIScenario
            GnT_GNTI.InitValue()

            If Value.Name <> "" Then

                StatusMessage = "Firmware Update"

                Dim Crc16 As New G4xHMI.CRC16
                crc = Crc16.crc16(Value.Data, 0, Value.Data.Length)

                fileSize = Value.Data.Length

                If fileSize < GnT_DriveData.EEPROMPageSize Then
                    StatusMessage = "GnT Scenario : File size small! "
                    Return False
                End If

                StatusMessage = "GnT Scenario : START "

                StatusMessage = "GnT Scenario Info : Size :" & CStr(Value.Data.Length) & ", Page :" & Value.Page.ToString() & ", CRC :" & crc.ToString()

                If SetTextBasedInitialCodeCMD(devId, G5InterfaceGNTScenario.START, fileSize, 1) = False Then
                    StatusMessage = "Gnt Scenario Info : Start Error"
                    Return False
                End If

                'GNTI.State = CInt(Class_GTITransfer._STATE.SENT_GNTI_STARTED)

                ''Init Time out
                GnT_GNTI.ExpireNotiTime()
                'GNTI.TimeOut = CInt(Class_GTITransfer._TIMEOUT.READY)

                GnT_GNTI.InitValue()

                GnT_GNTI.TimeOut = CInt(Class_GTITransfer._TIMEOUT.DATA)
                GnT_GNTI.State = CInt(Class_GTITransfer._STATE.LOOP_DATA_SEND)

                While upgradeRun


                    If GnT_GNTI.OldState <> GnT_GNTI.State Then

                        'State Reset
                        GnT_GNTI.OldState = GnT_GNTI.State

                        'Time out reset
                        GnT_GNTI.ExpireNotiTime()
                    Else

                        diffTime = DateTime.Now - GnT_GNTI.NotiTime

                        If diffTime.Seconds >= GnT_GNTI.TimeOut Then
                            StatusMessage = "GnT Scenario : Time Error !" & diffTime.ToString()
                            Return False
                        End If

                    End If

                    Select Case GnT_GNTI.State


                        Case CInt(Class_GTITransfer._STATE.LOOP_DATA_SEND)
                            If (GnT_GNTI.OldFileIndex <> GnT_GNTI.FileIndex) Then


                                GnT_GNTI.OldFileIndex = GnT_GNTI.FileIndex

                                If GnT_GNTI.FileIndex < Value.Page Then
                                    GnT_GNTI.ExpireNotiTime()

                                    If SetTextBasedInitialCodeData(devId, G5InterfaceGNTScenario.DATA, GnT_GNTI.FileIndex, CInt(Class_GTITransfer._TIMEOUT.DATA)) = False Then
                                        StatusMessage = "GnT Scenario : Upload Error "
                                        Return False
                                    End If

                                    'DefineUtils.Send_Packet((int)G5Interface.GNTICMD_CTL, (int)G5InterfaceGNTScenario.DATA, 0x00, 1);
                                    StatusMessage = "GnT Scenario : Upload Text - " & (GnT_GNTI.FileIndex + 1).ToString() & " / " & Value.Page.ToString()

                                    GnT_GNTI.IncIndex()

                                Else
                                    ''// EOF
                                    GnT_GNTI.State = CInt(Class_GTITransfer._STATE.SENT_DATA_CRC)
                                End If

                            End If
                        Case CInt(Class_GTITransfer._STATE.SENT_DATA_CRC)

                            StatusMessage = "GnT Scenario Sent CRC : " & crc.ToString() & " Size : " & fileSize.ToString()

                            If SetTextBasedInitialCodeCMD(devId, G5InterfaceGNTScenario.CRC, crc, CInt(Class_GTITransfer._TIMEOUT.WIAT_CRC)) = False Then
                                StatusMessage = "GnT Scenario Sent CRC : Error "

                                Return False
                            End If
                            ' DefineUtils.Send_Packet((int)G5Interface.GNTICMD_CTL, (int)G5InterfaceGNTScenario.CRC, crc, 1);
                            GnT_GNTI.TimeOut = CInt(Class_GTITransfer._TIMEOUT.WAIT_MAKE_CODE)
                            GnT_GNTI.State = CInt(Class_GTITransfer._STATE.WAIT_INTERNAL_CODE_MAKE)
                            StatusMessage = "GNT Scenario : CRC OK !"
                            'break;

                        Case CInt(Class_GTITransfer._STATE.WAIT_INTERNAL_CODE_MAKE)
                            '//Global_G5.GNTI.State = (int)Class_GTITransfer.STATE.LOOP_UPGRADE_DONE;        // 인터널 코드 작성 체크를 할경우, 여기서 종료 하지 안음.
                            GnT_GNTI.State = CInt(Class_GTITransfer._STATE.WAIT_INTERNAL_CODE_MAKE)   ' // 인터널 코드 작성을 기다립니다, 타임아웃 길게 잡음.
                            GnT_GNTI.TimeOut = CInt(Class_GTITransfer._TIMEOUT.WAIT_MAKE_CODE)

                            StatusMessage = "GNT Scenario : Wait Making Internal code !"

                            If SetTextBasedInitialCodeCMD(devId, G5InterfaceGNTScenario.MAKE_CODE, 0, CInt(Class_GTITransfer._TIMEOUT.WAIT_MAKE_CODE)) = False Then
                                StatusMessage = "GNT Scenario : Making Internal code error !"
                                Return False
                            End If

                            'Send Message    OnMessage(new MessageEventArgs("GNT Scenario : CRC OK !", true));
                            'break;

                            GnT_GNTI.State = CInt(Class_GTITransfer._STATE.LOOP_INTERNAL_CODE_DONE)   ' // 인터널 코드 작성을 기다립니다, 타임아웃 길게 잡음.
                            GnT_GNTI.TimeOut = CInt(Class_GTITransfer._TIMEOUT.WAIT_MAKE_CODE)

                        Case CInt(Class_GTITransfer._STATE.LOOP_INTERNAL_CODE_DONE)

                            'DefineUtils.Send_Packet((int)G5Interface.UPDATE_INITIAL_NAME/*0x25*/, 0x00, 0x00, 100); // Initial Name


                            If ReceiveMode(devId, GnT_GNTI.TimeOut) = False Then
                                StatusMessage = "GNT Scenario : Done Error !"
                                Return False
                            End If
                            StatusMessage = "GnT Scenario : Done!!"
                            upgradeRun = False

                        Case Else

                            StatusMessage = "GnT Scenario : Unknown Cur State : " & GnT_GNTI.State.ToString()
                            Return False
                    End Select

                End While


            Else
                StatusMessage = "GNT Interpreter Scenario not select"
                Return False
            End If

        Catch ex As Exception
            StatusMessage = ex.ToString()
            ' MyBase.RasieEvent_StateMessage(MyBase.m_sStatusMsg)
            Return False
        End Try

        Return True
    End Function

#Region "Model Data Functions"

    Public Function SetModelName(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim ErrMsg As String = Nothing
        Dim Value As G4SDataLibrary.CDriveData.sModelTimeData = GnT_DriveData.Read

        ' WriteLogMsg("Set Model Name")

        If CurrentMeasure.Make_Packet_SetModuleName(GnT_DriveData.ModelName, byFrame, ErrMsg) = False Then
            StatusMessage = ErrMsg
            Return False
        End If

        ' WriteLogMsg("Send Frame", byFrame)

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, True) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        If CheckRcvFrame(byRcvFrame, byRcvFrame) = False Then
            StatusMessage = "Received data frame Error"
            Return False
        End If

        Return True
    End Function

    Public Function SetModelData(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim ErrMsg As String = Nothing
        Dim Value As G4SDataLibrary.CDriveData.sModelTimeData = GnT_DriveData.Read

        If CurrentMeasure.Make_Packet_SetModuleData(Value, byFrame, ErrMsg) = False Then
            StatusMessage = ErrMsg
            Return False
        End If

        'WriteLogMsg("Send Frame", byFrame)

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, True) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        If CheckRcvFrame(byRcvFrame, byRcvFrame) = False Then
            StatusMessage = "Received data frame Error"
            Return False
        End If

        Return True
    End Function


    Public Function GetModelData(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim ErrMsg As String = Nothing
        'Dim Value As G4SDataLibrary.CDriveData.sModelTimeData '= DriveData.Read

        'WriteLogMsg("Get Model Data")

        If CurrentMeasure.Make_Packet_GetModuleData(byFrame, ErrMsg) = False Then
            StatusMessage = ErrMsg
            Return False
        End If


        'WriteLogMsg("Send Frame", byFrame)


        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, True) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If


        If CheckRcvFrame(byRcvFrame, byRcvFrame) = False Then
            StatusMessage = "Received data frame Error"
            Return False
        End If

        Return True
    End Function


    Public Function SetConfigData(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim ErrMsg As String = Nothing
        Dim Value As G4SDataLibrary.CDriveData.sModelTimeData = GnT_DriveData.Read

        If CurrentMeasure.Make_Packet_ConfigData(Value, byFrame, ErrMsg) = False Then
            StatusMessage = ErrMsg
            Return False
        End If

        'WriteLogMsg("Send Frame", byFrame)

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, True) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        If CheckRcvFrame(byRcvFrame, byRcvFrame) = False Then
            StatusMessage = "Received data frame Error"
            Return False
        End If

        Return True
    End Function

#End Region

#Region "Pattern Data Functions"

    Public Function SetPatternListName(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim ErrMsg As String = Nothing
        Dim Value As G4SDataLibrary.CDriveData.sModelTimeData = GnT_DriveData.Read

        If CurrentMeasure.Make_Packet_SetPatternListName(G4xHMI.G5Interface.UPDATE_PATTERN_LIST_NAME, Value.PatternName, byFrame, ErrMsg) = False Then
            StatusMessage = ErrMsg
            Return False
        End If

        'WriteLogMsg("Send Frame", byFrame)

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, True) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        If CheckRcvFrame(byRcvFrame, byRcvFrame) = False Then
            StatusMessage = "Received data frame Error"
            Return False
        End If


        Return True
    End Function

    Public Function SetPatternListName2(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim ErrMsg As String = Nothing
        Dim Value As G4SDataLibrary.CDriveData.sModelTimeData = GnT_DriveData.Read

        If CurrentMeasure.Make_Packet_SetPatternListName(G4xHMI.G5Interface.UPDATE_PATTERN_LIST_NAME2, Value.PatternName2, byFrame, ErrMsg) = False Then
            StatusMessage = ErrMsg
            Return False
        End If

        '   WriteLogMsg("Send Frame", byFrame)

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, True) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        If CheckRcvFrame(byRcvFrame, byRcvFrame) = False Then
            StatusMessage = "Received data frame Error"
            Return False
        End If

        Return True
    End Function

    Public Function SetPatternList(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim ErrMsg As String = Nothing
        Dim Value() As G4SDataLibrary.CDriveData.sPatternList = GnT_DriveData.PatternList1

        For idx As Integer = 0 To Value.Length - 1

            If CurrentMeasure.Make_Packet_SetPatternList(G4xHMI.G5Interface.UPDATE_PATTERN_LIST, Value(idx), byFrame, ErrMsg) = False Then
                StatusMessage = ErrMsg
                Return False
            End If

            '  WriteLogMsg("Send Frame", byFrame)

            If server.clients(devID).SendToBytes(byFrame, byRcvFrame, True) <> CComCommonNode.eReturnCode.OK Then
                StatusMessage = server.clients(devID).StateMessage
                server.clients(devID).ClearStateMsg()
                Return False
            End If

            If CheckRcvFrame(byRcvFrame, byRcvFrame) = False Then
                StatusMessage = "Received data frame Error"
                Return False
            End If
        Next


        Return True
    End Function


    Public Function NandFormat(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim ErrMsg As String = Nothing
        'Dim Value As G4SDataLibrary.CDriveData.sModelTimeData = DriveData.Read

        If CurrentMeasure.Make_Packet_ControlDevice(G4xHMI.ControlDevice.NAND_FORMAT, 0, byFrame, ErrMsg) = False Then
            StatusMessage = ErrMsg
            Return False
        End If

        'WriteLogMsg("Send Frame", byFrame)

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, True) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        If CheckRcvFrame(byRcvFrame, byRcvFrame) = False Then
            StatusMessage = "Received data frame Error"
            Return False
        End If

        Return True
    End Function


    Public Function SetBMPImgInfo(ByVal devID As Integer, ByVal imageIdx As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim ErrMsg As String = Nothing
        Dim Value As G4SDataLibrary.CDriveData.ClassImage = GnT_DriveData.UpdateImage(imageIdx)

        If CurrentMeasure.Make_Packet_UpdateBMPImageInfo(imageIdx, Value, byFrame, ErrMsg) = False Then
            StatusMessage = ErrMsg
            Return False
        End If

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, False) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        Return True
    End Function

    Public Function DownloadImage(ByVal devID As Integer, ByVal imageIdx As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim ErrMsg As String = Nothing
        Dim Value As G4SDataLibrary.CDriveData.ClassImage = GnT_DriveData.UpdateImage(imageIdx)

        If CurrentMeasure.Make_Packet_SendImage(imageIdx, Value, byFrame, ErrMsg) = False Then
            StatusMessage = ErrMsg
            Return False
        End If

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, False) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        Return True
    End Function


#End Region


#Region "TestBaseInitial"


    Public Function SetTextBasedInitialCodeCMD(ByVal devID As Integer, ByVal subCmd As G4xHMI.G5InterfaceGNTScenario, ByVal info As Integer, ByVal timeOut As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim ErrMsg As String = Nothing

        If CurrentMeasure.Make_Packet_GNTI_CMD(G4xHMI.G5Interface.GNTICMD_CTL, subCmd, info, byFrame, ErrMsg) = False Then
            StatusMessage = ErrMsg
            Return False
        End If

        'WriteLogMsg("Send Frame", byFrame)

        server.clients(devID).TimeOut = timeOut
        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, True) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        If CheckRcvFrame(byFrame, byRcvFrame) = False Then
            StatusMessage = "Received data frame Error"
            Return False
        End If

        Return True
    End Function


    Public Function SetTextBasedInitialCodeData(ByVal devID As Integer, ByVal subCmd As G4xHMI.G5InterfaceGNTScenario, ByVal index As Integer, ByVal timeOut As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim ErrMsg As String = Nothing
        Dim Value As G4SDataLibrary.CDriveData.GNTIBinFile = GnT_DriveData.GNTIScenario

        If CurrentMeasure.Make_Packet_GNTI_File_BIN(G4xHMI.G5Interface.GNTICMD_CTL, subCmd, index, GnT_DriveData.EEPROMPageSize, Value, byFrame, ErrMsg) = False Then
            StatusMessage = ErrMsg
            Return False
        End If

        'WriteLogMsg("Send Frame", byFrame)

        server.clients(devID).TimeOut = timeOut
        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, True) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        If CheckRcvFrame(byFrame, byRcvFrame) = False Then
            StatusMessage = "Received data frame Error"
            Return False
        End If

        Return True
    End Function

    Public Function InitialCodeNameSetup(ByVal devID As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim ErrMsg As String = Nothing
        Dim Value As G4SDataLibrary.CDriveData.GNTIBinFile = GnT_DriveData.GNTIScenario

        If CurrentMeasure.Make_Packet_InitialCodeNameSetup(Value.Name, byFrame, ErrMsg) = False Then
            StatusMessage = ErrMsg
            Return False
        End If

        'WriteLogMsg("Send Frame", byFrame)

        If server.clients(devID).SendToBytes(byFrame, byRcvFrame, True) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        If CheckRcvFrame(byRcvFrame, byRcvFrame) = False Then
            StatusMessage = "Received data frame Error"
            Return False
        End If

        Return True
    End Function



    Public Function ReceiveMode(ByVal devID As Integer, ByVal timeOut As Integer) As Boolean
        Dim byFrame() As Byte = Nothing
        Dim byRcvFrame() As Byte = Nothing
        Dim ErrMsg As String = Nothing


        'WriteLogMsg("Receive Mode")

        server.clients(devID).TimeOut = timeOut
        If server.clients(devID).ReciveToBytes(byRcvFrame) <> CComCommonNode.eReturnCode.OK Then
            StatusMessage = server.clients(devID).StateMessage
            server.clients(devID).ClearStateMsg()
            Return False
        End If

        If CheckRcvFrame(byRcvFrame) = False Then
            StatusMessage = "Received data frame Error"
        End If

        Return True
    End Function


#End Region

    Private Function CheckRcvFrame(ByRef rcvFrame() As Byte) As Boolean

        Dim dataFrame() As Byte = Nothing

        For i As Integer = rcvFrame.Length - 1 To 0 Step -1
            If rcvFrame(i) = G4xHMI.CONST.ETHERNET.PC.TAILER Then
                ReDim dataFrame(i)
                Array.Copy(rcvFrame, dataFrame, i + 1)
                Exit For
            End If
        Next

        If dataFrame Is Nothing = True Then Return False

        rcvFrame = dataFrame.Clone

        'Check CRC
        Dim crc As UShort

        Dim CRC16 As New G4xHMI.CRC16

        crc = CRC16.crc16(dataFrame, 0, dataFrame.Length - 4)

        Dim rcvCrc As CUnitCommonNode.SplitUINT16

        rcvCrc.ByteData_H = dataFrame(dataFrame.Length - 4)
        rcvCrc.ByteData_L = dataFrame(dataFrame.Length - 3)

        'CRC 에러 메시지 리턴
        If crc <> rcvCrc.UINT16_Data Then Return False

        Dim rcvCMD As Byte = dataFrame(3)


        Select Case rcvCMD

            Case CByte(G4xHMI.G5InterfaceAck.GNTICMD_REQ)  'Rcv CMD = 0xE3

                'Int 값으로 비교 할 경우
                Dim rcvSubCMD As CUnitCommonNode.SplitUINT32
                rcvSubCMD.ByteData0 = dataFrame(6)
                rcvSubCMD.ByteData1 = dataFrame(7)
                rcvSubCMD.ByteData2 = dataFrame(8)
                rcvSubCMD.ByteData3 = dataFrame(9)

                Select Case dataFrame(6)
                    Case CByte(G4xHMI.G5InterfaceGNTScenario.START)
                        Return True
                    Case CByte(G4xHMI.G5InterfaceGNTScenario.DATA)
                        Return True
                    Case CByte(G4xHMI.G5InterfaceGNTScenario.MAKE_CODE)
                        Return True
                    Case CByte(G4xHMI.G5InterfaceGNTScenario.CRC)
                        Return True
                    Case CByte(G4xHMI.G5InterfaceGNTScenario.DONE)
                        Return True
                    Case CByte(G4xHMI.G5InterfaceGNTScenario.CRC_OK)
                        Return True
                    Case CByte(G4xHMI.G5InterfaceGNTScenario.CRC_ERR)
                        Return False
                    Case Else
                        Return False
                End Select

            Case Else

                Return True

        End Select


        'Array.FindIndex(rcvFrame, G4xHMI.CONST.ETHERNET.PC.TAILER
        Return True
    End Function

    Private Function CheckRcvFrame(ByVal sendFrame() As Byte, ByRef rcvFrame() As Byte) As Boolean

        Dim dataFrame() As Byte = Nothing

        For i As Integer = rcvFrame.Length - 1 To 0 Step -1
            If rcvFrame(i) = G4xHMI.CONST.ETHERNET.PC.TAILER Then
                ReDim dataFrame(i)
                Array.Copy(rcvFrame, dataFrame, i + 1)
                Exit For
            End If
        Next

        If dataFrame Is Nothing = True Then Return False

        rcvFrame = dataFrame.Clone

        'Check CRC
        Dim crc As UShort

        Dim CRC16 As New G4xHMI.CRC16

        crc = CRC16.crc16(dataFrame, 0, dataFrame.Length - 4)

        Dim rcvCrc As CUnitCommonNode.SplitUINT16

        rcvCrc.ByteData_H = dataFrame(dataFrame.Length - 4)
        rcvCrc.ByteData_L = dataFrame(dataFrame.Length - 3)

        'CRC 에러 메시지 리턴
        If crc <> rcvCrc.UINT16_Data Then Return False


        Dim rcvCMD As Byte = dataFrame(3)


        Select Case rcvCMD

            Case CByte(G4xHMI.G5InterfaceAck.GNTICMD_REQ)  'Rcv CMD = 0xE3

                'Int 값으로 비교 할 경우
                Dim rcvSubCMD As CUnitCommonNode.SplitUINT32
                rcvSubCMD.ByteData0 = dataFrame(6)
                rcvSubCMD.ByteData1 = dataFrame(7)
                rcvSubCMD.ByteData2 = dataFrame(8)
                rcvSubCMD.ByteData3 = dataFrame(9)
                Dim sendSubCMD As CUnitCommonNode.SplitUINT32
                sendSubCMD.ByteData0 = sendFrame(9)
                sendSubCMD.ByteData0 = sendFrame(8)
                sendSubCMD.ByteData0 = sendFrame(7)
                sendSubCMD.ByteData0 = sendFrame(6)

                Select Case dataFrame(6)
                    Case CByte(G4xHMI.G5InterfaceGNTScenario.START)
                        If dataFrame(9) <> sendFrame(6) Then Return False
                    Case CByte(G4xHMI.G5InterfaceGNTScenario.DATA)
                        If dataFrame(9) <> sendFrame(6) Then Return False
                    Case CByte(G4xHMI.G5InterfaceGNTScenario.MAKE_CODE)
                        If dataFrame(9) <> sendFrame(6) Then Return False
                    Case CByte(G4xHMI.G5InterfaceGNTScenario.CRC)
                        If dataFrame(6) <> CByte(G4xHMI.G5InterfaceGNTScenario.CRC_OK) Then Return False
                    Case CByte(G4xHMI.G5InterfaceGNTScenario.DONE)
                        Return True
                    Case CByte(G4xHMI.G5InterfaceGNTScenario.CRC_OK)
                        Return True
                    Case CByte(G4xHMI.G5InterfaceGNTScenario.CRC_ERR)
                        Return False
                    Case Else
                        Return False
                End Select

            Case Else

                Return True

        End Select
        'Array.FindIndex(rcvFrame, G4xHMI.CONST.ETHERNET.PC.TAILER
        Return True
    End Function

#End Region


#End Region

#Region "Sequence Routine"

    Public Overrides Function Request(ByVal nCh As Integer, ByVal state As eSequenceState) As Boolean
        'Dim reqInfos As sSettingInfo

        'reqInfos.nCh = nCh
        'reqInfos.SourceSetting = setting
        'SyncLock requestQueue.SyncRoot
        '    requestQueue.Enqueue(reqInfos)
        'End SyncLock

        If nCh < 0 Or nCh > m_nMaxCh - 1 Then Return False
        Dim setInfos As sG4SSettings = Nothing

        setInfos.nCh = nCh
        setInfos.eBeforState = m_setInfos(nCh).eState
        setInfos.eState = state
        setInfos.nPatternIdx = 0
        setInfos.autoSlide = m_setInfos(nCh).autoSlide
        setInfos.sModelName = m_setInfos(nCh).sModelName

        requestQueue.Enqueue(setInfos)
        '    g_SeqRoutineStatus(nCh) = state

        Return True
    End Function

    Public Overrides Function Request(ByVal nCh As Integer, ByVal state As eSequenceState, ByVal PatternIdx As Integer) As Boolean
        'Dim reqInfos As sSettingInfo

        'reqInfos.nCh = nCh
        'reqInfos.SourceSetting = setting
        'SyncLock requestQueue.SyncRoot
        '    requestQueue.Enqueue(reqInfos)
        'End SyncLock

        If nCh < 0 Or nCh > m_nMaxCh - 1 Then Return False

        Dim setInfos As sG4SSettings = Nothing

        setInfos.nCh = nCh
        setInfos.eBeforState = m_setInfos(nCh).eState
        setInfos.eState = state
        setInfos.nPatternIdx = PatternIdx
        setInfos.autoSlide = m_setInfos(nCh).autoSlide
        setInfos.sModelName = m_setInfos(nCh).sModelName

        requestQueue.Enqueue(setInfos)

        Return True
    End Function


    Public Overrides Function Request(ByVal nCh As Integer, ByVal state As eSequenceState, ByVal autoSlideInfo As sG4SAutoSlideSettings) As Boolean
        'Dim reqInfos As sSettingInfo

        'reqInfos.nCh = nCh
        'reqInfos.SourceSetting = setting
        'SyncLock requestQueue.SyncRoot
        '    requestQueue.Enqueue(reqInfos)
        'End SyncLock

        If nCh < 0 Or nCh > m_nMaxCh - 1 Then Return False

        Dim setInfos As sG4SSettings = Nothing

        setInfos.nCh = nCh
        setInfos.eBeforState = m_setInfos(nCh).eState
        setInfos.eState = state
        setInfos.autoSlide = autoSlideInfo
        nAutoSlidePatternCnt(nCntCh) = 0
        setInfos.sModelName = m_setInfos(nCh).sModelName

        requestQueue.Enqueue(setInfos)

        Return True
    End Function


    Public Overrides Function Request(ByVal nCh As Integer, ByVal state As eSequenceState, ByVal modelName As String) As Boolean
        'Dim reqInfos As sSettingInfo

        'reqInfos.nCh = nCh
        'reqInfos.SourceSetting = setting
        'SyncLock requestQueue.SyncRoot
        '    requestQueue.Enqueue(reqInfos)
        'End SyncLock

        If nCh < 0 Or nCh > m_nMaxCh - 1 Then Return False
        Dim setInfos As sG4SSettings = Nothing

        setInfos.nCh = nCh
        setInfos.eBeforState = m_setInfos(nCh).eState
        setInfos.eState = state
        setInfos.nPatternIdx = 0
        setInfos.autoSlide = m_setInfos(nCh).autoSlide
        setInfos.sModelName = modelName

        requestQueue.Enqueue(setInfos)
        '    g_SeqRoutineStatus(nCh) = state

        Return True
    End Function


    Public Sub ResetAll()
        For i As Integer = 0 To m_nMaxCh - 1
            Dim setInfos As sG4SSettings = Nothing

            setInfos.nCh = i
            setInfos.eBeforState = m_setInfos(i).eState
            setInfos.eState = eSequenceState.eReset
            setInfos.nPatternIdx = 0

            requestQueue.Enqueue(setInfos)
        Next
    End Sub



    Dim trdG4s As Thread
    Dim fStopTrd As Boolean

    Private Sub StartThread()
        trdG4s = New Thread(AddressOf trdRoutine)
        trdG4s.Priority = ThreadPriority.Normal
        trdG4s.Start()
        fStopTrd = False
    End Sub

    Private Sub StopThread()
        fStopTrd = True
    End Sub


   

    Private Sub trdRoutine()

        'Dim check_Process As Boolean = False

        'Dim bufSetInfo As sG4SSettings
        'Dim sWaitTimes(m_nMaxCh - 1) As Single
        'Dim nAutoSlidePatternCnt(m_nMaxCh - 1) As Integer
        'Dim sAutoSlidePatternDispTimes(m_nMaxCh - 1) As Single  '표시된 시작 시간
        'Dim sAutoSlidePatternDispDeltaTime(m_nMaxCh - 1) As Single   '패턴 표시된 시간으로 부터 지난 시간
        'Dim bAutoSlideState(m_nMaxCh - 1) As Boolean    '초기 상태 확인, 
        'Dim dataList(m_nMaxCh - 1)() As CDevG4S.sG4SDatas
        'Dim dataCnt(m_nMaxCh - 1) As Integer

        ''명령 처리 타임아웃 확인용
        'Dim sTimeOutStartTime(m_nMaxCh - 1) As Single  '시작 시간
        'Dim sTimeOutDeltaTime(m_nMaxCh - 1) As Single '경과 시간   = 현재시간 - 시작 시간

        Dim bChekTimeOut(m_nMaxCh - 1) As Boolean

        For i As Integer = 0 To bChekTimeOut.Length - 1
            bChekTimeOut(i) = False
        Next

        'Dim nCntCh As Integer = 0

        'WriteLogMsg("G4S Sequence Routine Start")
        MyBase.myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_SEQ_ROUTINE_START)

        Do
            Application.DoEvents()
            Thread.Sleep(10)

            If fStopTrd = True Then
                Exit Do
            End If

            If nErrorCount(nCntCh) > 10 Then
                m_setInfos(nCntCh).eState = eSequenceState.eidle
                myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_ERROR_COUNT_OVER_Client_Nothing, "Device Request Nothing, Check Device" & Format(nCntCh))

                '접속 상태 갱신
                server.CloseClient(nCntCh + m_nSeedIndex)
                m_bIsConnectedSubCh(nCntCh) = False
                nErrorCount(nCntCh) = 0
            End If

            If requestQueue.Count <> 0 Then
                bufSetInfo = requestQueue.Dequeue
                m_setInfos(bufSetInfo.nCh) = bufSetInfo
            End If

            Select Case m_setInfos(nCntCh).eState

                Case eSequenceState.eidle
                    'Application.DoEvents()
                    'Thread.Sleep(100)
                    bAutoSlideState(nCntCh) = False
                Case eSequenceState.eON
                    If PowerOn(nCntCh + m_nSeedIndex) = True Then

                        Dim data As CDevG4S.sG4SDatas

                        If GetRealTimeData(nCntCh + m_nSeedIndex, data) = True Then
                            nErrorCount(nCntCh) = 0
                            MyBase.m_MeasuredData(nCntCh).sG4S = data
                        Else
                            nErrorCount(nCntCh) += 1
                            myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "GetRealTimeData Function Error, Channel : " & Format(nCntCh))
                            'WriteLogMsg("GetRealTimeData Function Error, Channel : " & Format(nCntCh))
                        End If

                        m_setInfos(nCntCh).eBeforState = m_setInfos(nCntCh).eState
                        m_setInfos(nCntCh).eState = eSequenceState.eCheckState
                    Else
                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "Power On Function Error, Channel : " & Format(nCntCh))
                        nErrorCount(nCntCh) += 1

                        'WriteLogMsg("PowerOn Function Error, Channel : " & Format(nCntCh))
                    End If


                Case eSequenceState.eCheckState

                    Dim data As CDevG4S.sG4SDatas
                    If GetRealTimeData(nCntCh + m_nSeedIndex, data) = True Then
                        ' m_MeasuredDatas(nCntCh) = data
                        nErrorCount(nCntCh) = 0
                        MyBase.m_MeasuredData(nCntCh).sG4S = data
                        If MyBase.m_MeasuredData(nCntCh).sG4S.MeasState = True And MyBase.m_MeasuredData(nCntCh).sG4S.PowerState = ePowerState._ON Then
                            m_setInfos(nCntCh).eBeforState = m_setInfos(nCntCh).eState
                            m_setInfos(nCntCh).eState = eSequenceState.eMeasuring
                        End If
                    Else
                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "GetRealTimeData Function Error, Channel : " & Format(nCntCh))
                        nErrorCount(nCntCh) += 1
                        'WriteLogMsg("GetRealTimeData Function Error, Channel : " & Format(nCntCh))
                    End If

                Case eSequenceState.eSetPattern

                    If PatternChange(nCntCh + m_nSeedIndex, m_setInfos(nCntCh).nPatternIdx) = True Then
                        'm_setInfos(nCntCh).eState = m_setInfos(nCntCh).eBeforState
                        nErrorCount(nCntCh) = 0
                        sTimeOutStartTime(nCntCh) = 0
                        sTimeOutStartTime(nCntCh) = timer_Sec()
                        'aa()

                        Do
                            Thread.Sleep(200)
                            Application.DoEvents()

                            Dim data As CDevG4S.sG4SDatas
                            If GetRealTimeData(nCntCh + m_nSeedIndex, data) = True Then
                                'm_MeasuredDatas(nCntCh) = data
                                nErrorCount(nCntCh) = 0
                                MyBase.m_MeasuredData(nCntCh).sG4S = data
                            Else
                                myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "GetRealTimeData Function Error, Channel : " & Format(nCntCh))
                                nErrorCount(nCntCh) += 1
                                'WriteLogMsg("GetRealTimeData Function Error, Channel : " & Format(nCntCh))
                            End If

                            If m_MeasuredData(nCntCh).sG4S.nPatternIdx = m_setInfos(nCntCh).nPatternIdx Then
                                'Changed pattern
                                Application.DoEvents()
                                Thread.Sleep(100)
                                ''순서가 바뀌어진 이유??
                                'm_setInfos(nCntCh).eState = eSequenceState.eMeasuring
                                'm_setInfos(nCntCh).eBeforState = m_setInfos(nCntCh).eState

                                m_setInfos(nCntCh).eBeforState = m_setInfos(nCntCh).eState
                                m_setInfos(nCntCh).eState = eSequenceState.eMeasuring
                                Exit Do
                            Else
                                'Not changed pattern
                                sTimeOutDeltaTime(nCntCh) = timer_Sec() - sTimeOutStartTime(nCntCh)
                                If sTimeOutDeltaTime(nCntCh) < 0 Then sTimeOutDeltaTime(nCntCh) = sTimeOutDeltaTime(nCntCh) + 3600
                                If sTimeOutDeltaTime(nCntCh) >= 2 Then
                                    myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "SetPattern Time Out, Channel : " & Format(nCntCh))
                                    'WriteLogMsg("SetPattern Time Out, Channel : " & Format(nCntCh))
                                    Exit Do
                                End If
                            End If
                        Loop
                    Else
                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "Pattern Change Function Error, Channel : " & Format(nCntCh))
                        nErrorCount(nCntCh) += 1
                    End If

                Case eSequenceState.eChangePattern_Next

                    If PatternNext(nCntCh + m_nSeedIndex) = True Then
                        nErrorCount(nCntCh) = 0
                        m_setInfos(nCntCh).eState = m_setInfos(nCntCh).eBeforState
                        m_setInfos(nCntCh).eBeforState = m_setInfos(nCntCh).eState
                    End If
                 
                Case eSequenceState.eChangePattern_Befor

                    If PatternBack(nCntCh + m_nSeedIndex) = True Then
                        nErrorCount(nCntCh) = 0
                        m_setInfos(nCntCh).eState = m_setInfos(nCntCh).eBeforState
                        m_setInfos(nCntCh).eBeforState = m_setInfos(nCntCh).eState
                    End If

                Case eSequenceState.eAutoSlide

                    If bAutoSlideState(nCntCh) = True Then

                        sAutoSlidePatternDispDeltaTime(nCntCh) = timer_Sec() - sAutoSlidePatternDispTimes(nCntCh)
                        If sAutoSlidePatternDispDeltaTime(nCntCh) < 0 Then sAutoSlidePatternDispDeltaTime(nCntCh) = sAutoSlidePatternDispDeltaTime(nCntCh) + 3600


                        If sAutoSlidePatternDispDeltaTime(nCntCh) >= m_setInfos(nCntCh).autoSlide.dAutoSlideDelays(nAutoSlidePatternCnt(nCntCh)) Then

                            If PatternChange(nCntCh + m_nSeedIndex, m_setInfos(nCntCh).autoSlide.nAutoSlidePatternIdx(nAutoSlidePatternCnt(nCntCh))) = True Then
                                nErrorCount(nCntCh) = 0
                                sAutoSlidePatternDispTimes(nCntCh) = timer_Sec()
                                nAutoSlidePatternCnt(nCntCh) += 1
                                If nAutoSlidePatternCnt(nCntCh) >= m_setInfos(nCntCh).autoSlide.nAutoSlidePatternIdx.Length Then  '패턴 인덱스 보다 크면, 카운드 값 리셋
                                    nAutoSlidePatternCnt(nCntCh) = 0
                                End If

                            Else ' Exception 
                                myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "PatternChange Function Error, Channel : " & Format(nCntCh) & StatusMessage)
                                nErrorCount(nCntCh) += 1
                                'WriteLogMsg("PatternChange Function Error, Channel : " & Format(nCntCh))
                            End If

                            Application.DoEvents()
                            Thread.Sleep(100)

                            Dim data As CDevG4S.sG4SDatas = Nothing

                            If GetRealTimeData(nCntCh + m_nSeedIndex, data) = True Then
                                nErrorCount(nCntCh) = 0
                                MyBase.m_MeasuredData(nCntCh).sG4S = data
                            Else
                                myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "GetRealTimeData Function Error, Channel : " & Format(nCntCh) & StatusMessage)
                                nErrorCount(nCntCh) += 1
                                'WriteLogMsg("GetRealTimeData Function Error, Channel : " & Format(nCntCh))
                            End If

                        End If

                    Else

                        If PatternChange(nCntCh + m_nSeedIndex, m_setInfos(nCntCh).autoSlide.nAutoSlidePatternIdx(nAutoSlidePatternCnt(nCntCh))) = True Then
                            nErrorCount(nCntCh) = 0
                            sAutoSlidePatternDispTimes(nCntCh) = timer_Sec()
                            nAutoSlidePatternCnt(nCntCh) += 1
                            If nAutoSlidePatternCnt(nCntCh) >= m_setInfos(nCntCh).autoSlide.nAutoSlidePatternIdx.Length Then  '패턴 인덱스 보다 크면, 카운드 값 리셋
                                nAutoSlidePatternCnt(nCntCh) = 0
                            End If
                        Else ' Exception 
                            myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "PatternChange Function Error, Channel : " & Format(nCntCh) & StatusMessage)
                            nErrorCount(nCntCh) += 1
                            'WriteLogMsg("PatternChange Function Error, Channel : " & Format(nCntCh))
                        End If
                        bAutoSlideState(nCntCh) = True
                    End If


                Case eSequenceState.eMeasuring

                    'Dim data(9) As CDevG4S.sG4SDatas
                    'For i As Integer = 0 To data.Length - 1
                    'Next

                    If m_setInfos(nCntCh).eBeforState = eSequenceState.eMeasuring Then
                        ReDim Preserve dataList(nCntCh)(dataCnt(nCntCh))
                    Else
                        dataCnt(nCntCh) = 0
                        ReDim dataList(nCntCh)(dataCnt(nCntCh))
                        Dim data1 As CDevG4S.sG4SDatas
                        data1.IBAT_mA = 0
                        data1.ICI_mA = 0
                        data1.IDD_mA = 0
                        MyBase.m_MeasuredData(nCntCh).sG4S = data1
                    End If

                    Dim data As CDevG4S.sG4SDatas = Nothing
                    Dim filteredData As CDevG4S.sG4SDatas = Nothing
                    Application.DoEvents()
                    Thread.Sleep(10)
                    If GetRealTimeData(nCntCh + m_nSeedIndex, data) = True Then
                        nErrorCount(nCntCh) = 0
                        'm_MeasuredDatas(nCntCh) = data
                        dataList(nCntCh)(dataCnt(nCntCh)) = data

                        filteredData = MedianFilter(dataList(nCntCh))

                        MyBase.m_MeasuredData(nCntCh).sG4S = filteredData ' m_MeasuredDatas(nCntCh)
                        'If m_MeasuredData(nCntCh).sG4S.IBAT_mA < 1 Then
                        '    MsgBox("test")
                        'End If
                    Else
                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "GetRealTimeData Function Error, Channel : " & Format(nCntCh))
                        nErrorCount(nCntCh) += 1
                        'WriteLogMsg("GetRealTimeData Function Error, Channel : " & Format(nCntCh))
                    End If

                    dataCnt(nCntCh) += 1

                    m_setInfos(nCntCh).eBeforState = eSequenceState.eMeasuring

                Case eSequenceState.eReset

                    If PowerOff(nCntCh + m_nSeedIndex) = True Then
                        nErrorCount(nCntCh) = 0
                        m_setInfos(nCntCh).eBeforState = m_setInfos(nCntCh).eState
                        m_setInfos(nCntCh).eState = eSequenceState.eidle

                        With MyBase.m_MeasuredData(nCntCh).sG4S
                            .IBAT_mA = 0
                            .ICI_mA = 0
                            .IDD_mA = 0
                            .MeasState = False
                            .PowerState = ePowerState._OFF
                        End With

                    Else
                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "PowerOff Function Error, Channel : " & Format(nCntCh))
                        nErrorCount(nCntCh) += 1
                        'WriteLogMsg("PowerOff Function Error, Channel : " & Format(nCntCh))
                    End If

                Case eSequenceState.eGnT_Update_DriveData_All

                    If m_sGnTModelNames Is Nothing Then Exit Sub
                    If m_sGnTModelNames.Length = 0 Then Exit Sub

                    Dim modelData As G4SDataLibrary.CDriveData.sModelTimeData
                    Dim patternList() As String = Nothing




                    If PowerOff(nCntCh + m_nSeedIndex) = True Then
                        nErrorCount(nCntCh) = 0
                        m_setInfos(nCntCh).eBeforState = m_setInfos(nCntCh).eState
                        m_setInfos(nCntCh).eState = eSequenceState.eidle

                        With MyBase.m_MeasuredData(nCntCh).sG4S
                            .IBAT_mA = 0
                            .ICI_mA = 0
                            .IDD_mA = 0
                            .MeasState = False
                            .PowerState = ePowerState._OFF
                        End With

                    Else
                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "PowerOff Function Error, Channel : " & Format(nCntCh))
                        nErrorCount(nCntCh) += 1
                        'WriteLogMsg("PowerOff Function Error, Channel : " & Format(nCntCh))
                    End If

                    Application.DoEvents()
                    Thread.Sleep(1000)

                    GnT_DriveData.ModelName = m_setInfos(nCntCh).sModelName

                    '0 입력된 모델 파일과, 모델 정보 리스트를 비교해서 정보가 없으면 중단.


                    '1. 선택된 구동파일의 정보를 업데이트(가져온다), 없으면 중지 되어야 함.
                    If GnT_DriveData.UpdateModelInfo() = False Then
                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "GNT Model Update Error, Channel : " & Format(nCntCh))
                        'LEX_2015
                        '다운로드 중단 처리필요, 상태도 전달해야 한다.
                        m_setInfos(nCntCh).eBeforState = eSequenceState.eGnT_Update_DriveData_All
                        m_setInfos(nCntCh).eState = eSequenceState.eGnT_Update_DriveData_Faild
                    End If

                    Thread.Sleep(100)

                    modelData = GnT_DriveData.Read

                    Application.DoEvents()
                    Thread.Sleep(100)

                    '2. PC에 저장 되어 있는 Pattern List를 로드해서, 모델 파일에 저장되어 있는 Pattern Name과 비교후 매치이 되는 부분이 없으면 중단
                    If GnT_DriveData.UpdatePatternList(patternList) = False Then
                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "GNT Model Update Error, Channel : " & Format(nCntCh))
                        'LEX_2015
                        '다운로드 중단 처리필요, 상태도 전달해야 한다.
                        m_setInfos(nCntCh).eBeforState = eSequenceState.eGnT_Update_DriveData_All
                        m_setInfos(nCntCh).eState = eSequenceState.eGnT_Update_DriveData_Faild
                    End If

                    Application.DoEvents()
                    Thread.Sleep(100)

                    '3. 선된택 패턴 정보를 갱신
                    If GnT_DriveData.UpdatePatternListInfo(modelData.PatternName) = False Then
                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "GNT Pattern Info Update Error, Channel : " & Format(nCntCh))
                        'LEX_2015
                        '다운로드 중단 처리필요, 상태도 전달해야 한다.
                        m_setInfos(nCntCh).eBeforState = eSequenceState.eGnT_Update_DriveData_All
                        m_setInfos(nCntCh).eState = eSequenceState.eGnT_Update_DriveData_Faild
                    End If

                    Application.DoEvents()
                    Thread.Sleep(100)

                    '4. 패턴에 사용된 이미지가 있으면 이미지 정보를 로드
                    If GnT_DriveData.UpdatePatternImage() = False Then
                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "Pattern Image Update Error, Channel : " & Format(nCntCh))
                        'LEX_2015
                        '다운로드 중단 처리필요, 상태도 전달해야 한다.
                        m_setInfos(nCntCh).eBeforState = eSequenceState.eGnT_Update_DriveData_All
                        m_setInfos(nCntCh).eState = eSequenceState.eGnT_Update_DriveData_Faild
                    End If

                    Application.DoEvents()
                    Thread.Sleep(100)

                    '5. 모델 데이터에 기록된(Data.ini파일) Scenario 정보를 로드
                    If GnT_DriveData.LoadGNTIScenario() = False Then
                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "GNT Scenario Update Error, Channel : " & Format(nCntCh))
                        'LEX_2015
                        '다운로드 중단 처리필요, 상태도 전달해야 한다.
                        m_setInfos(nCntCh).eBeforState = eSequenceState.eGnT_Update_DriveData_All
                        m_setInfos(nCntCh).eState = eSequenceState.eGnT_Update_DriveData_Faild
                    End If

                    Application.DoEvents()
                    Thread.Sleep(100)

                    'modelData.PatternName
                    '6. Updatea DriveData All

                    If UpdateAll(nCntCh + m_nSeedIndex) = False Then
                        myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "GNT Model Update Error, Channel : " & Format(nCntCh) & m_sStatusMsg)
                        'LEX_2015
                        '다운로드 중단 처리필요, 상태도 전달해야 한다.
                        m_setInfos(nCntCh).eBeforState = eSequenceState.eGnT_Update_DriveData_All
                        m_setInfos(nCntCh).eState = eSequenceState.eGnT_Update_DriveData_Faild
                    Else
                        m_setInfos(nCntCh).eBeforState = eSequenceState.eGnT_Update_DriveData_All
                        m_setInfos(nCntCh).eState = eSequenceState.eGnT_Update_DriveData_OK
                    End If


                Case eSequenceState.eGnT_Update_DriveData_OK

                    If bChekTimeOut(nCntCh) = False Then
                        bChekTimeOut(nCntCh) = True
                        sTimeOutStartTime(nCntCh) = timer_Sec()
                    Else
                        sTimeOutDeltaTime(nCntCh) = timer_Sec() - sTimeOutStartTime(nCntCh)
                        If sTimeOutDeltaTime(nCntCh) < 0 Then sTimeOutDeltaTime(nCntCh) = sTimeOutDeltaTime(nCntCh) + 3600
                        If sTimeOutDeltaTime(nCntCh) >= 10 Then  '10초 대기
                            bChekTimeOut(nCntCh) = False
                            m_setInfos(nCntCh).eBeforState = eSequenceState.eGnT_Update_DriveData_OK
                            m_setInfos(nCntCh).eState = eSequenceState.eidle
                            'myParent.g_StateMsgHandler.messageToUserErrorCode(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_FUNCTION_ERROR, "SetPattern Time Out, Channel : " & Format(nCntCh))
                            'WriteLogMsg("SetPattern Time Out, Channel : " & Format(nCntCh))
                        End If
                    End If

                Case eSequenceState.eGnT_Update_DriveData_Faild
                    m_setInfos(nCntCh).eBeforState = eSequenceState.eGnT_Update_DriveData_Faild
                    m_setInfos(nCntCh).eState = eSequenceState.eidle
                Case eSequenceState.eGnT_Update_DriveData_Model


                Case eSequenceState.eGnT_Update_DriveData_Pattern


                Case eSequenceState.eGnT_Update_DriveData_Initial


            End Select

            nCntCh += 1

            If nCntCh >= m_nMaxCh Then
                nCntCh = 0
            End If

        Loop

        myParent.g_StateMsgHandler.messageToString(CStateMsg.eType.eMSG_Log, CStateMsg.eStateMsg.eDEV_G4s_MSG_SEQ_ROUTINE_STOP)
        'WriteLogMsg("G4S Sequence Routine End")'

    End Sub


    Private Function MedianFilter(ByVal datas() As CDevG4S.sG4SDatas) As CDevG4S.sG4SDatas

        Dim dataList_IBAT(datas.Length - 1) As Double

        For i As Integer = 0 To datas.Length - 1
            dataList_IBAT(i) = datas(i).IBAT_mA
        Next

        Dim sortedDatas() As Double = CDataSort.BubbleSort_RemoveZero(dataList_IBAT, dataList_IBAT.Length)
        Dim dValue As Double
        If sortedDatas Is Nothing Then Return Nothing

        If sortedDatas.Length > 1 Then
            dValue = sortedDatas(Fix(sortedDatas.Length / 2))
        ElseIf sortedDatas.Length = 1 Then
            dValue = sortedDatas(sortedDatas.Length - 1)
        Else
            Return Nothing
        End If

        For i As Integer = 0 To datas.Length - 1
            If dValue = datas(i).IBAT_mA Then
                Return datas(i)
            End If
        Next

        Return datas(datas.Length - 1)
    End Function


    Private Function timer_Sec() As Single
        Return CSng((Now.Minute * 60) + Now.Second + (Now.Millisecond / 1000))
    End Function


    Dim g_sFilePath_SystemLog As String = Application.StartupPath & "\Log\" & "SystemLog_" & Format(Now.Year, "0000") & Format(Now.Month, "00") & Format(Now.Day, "00") & "_" & Format(Now.Hour, "00") & Format(Now.Minute, "00") & Format(Now.Second, "00") & ".ini"


    Public Sub WriteLogMsg(ByVal STR As String)

        If System.IO.Directory.Exists(Application.StartupPath & "\Log\") = False Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Log\")
        End If

        Try
            FileOpen(4, g_sFilePath_SystemLog, OpenMode.Append, OpenAccess.Write, OpenShare.Shared) '파일을 열고
        Catch ex As Exception
            FileClose(4)
        End Try

        Dim cYear As String = Now.Year 'Format(Now, "yyyy")
        Dim cMonth As String = Now.Month ' Format(Now, "MM")
        Dim cDay As String = Now.Day  'Format(Now, "dd")

        Dim cHour As String = Now.Hour '(Now, "HH")
        Dim cMin As String = Now.Minute ' Format(Now, "mm")
        Dim cSec As String = Now.Second 'Format(Now, "ss")

        STR = cYear & "-" & cMonth & "-" & cDay & " " & cHour & ":" & cMin & ":" & cSec & "  " & STR

        PrintLine(4, STR)

        '파일에 쓰고
        FileClose(4)
    End Sub

#End Region

#Region "Event Functions"


    Private Sub server_evChangedConnectedClients(list() As String) Handles server.evChangedConnectedClients
        MyBase.RaiseEvent_ChangedConnectedClients(list)
    End Sub

    Private Sub server_evStatusMessage(msg As String) Handles server.evStatusMessage
        MyBase.RasieEvent_StateMessage(msg)
    End Sub


    'Private Sub RaiseEvent_StatusMessage(ByVal msg As String)
    '    MyBase.RasieEvent_StateMessage(msg)
    '    Application.DoEvents()
    '    Thread.Sleep(10)
    'End Sub

#End Region

End Class
