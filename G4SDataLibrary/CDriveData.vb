Imports System
Imports System.IO



Public Class CDriveData

#Region "Define"

    Dim m_sPath_GNT As String

    Dim m_InitialDataInfo As sInitialInfo
    Dim m_ModelTimingData As sModelTimeData
    Dim m_PatternListData1() As sPatternList   '최대 90개의 패턴 데이터를 30개씩 3번에 나누어 전송한다. 따라서, 3개의 배열에 30개씩의 Pattern Item Data를 가지도록 데이터를 정의함
    Dim m_PatternListData2() As sPatternList

    Dim m_Config As sConfig

    Dim m_ImageList As ArrayList

    Dim m_GNTScenario As GNTIBinFile

    Dim m_EEPROM_Page_Size As Integer = 264  'G4s --> 264Byte

    Dim m_SelectedModelName As String

#Region "Structure"


    Public Structure sConfig
        Dim Login_pass As String
        Dim Count_Rack As Integer
        Dim Count_Hub As Integer
        Dim Image_Delay As Integer
        Dim Edit As String
        Dim firmware_name As String
        Dim Fpga_name As String
        Dim FTP_URL As String
        Dim FTP_Directory As String
        Dim FTP_Name As String
        Dim FTP_Pass As String
    End Structure

    'Public Structure sConfigData
    '    Dim Pattern_AutoTime As UInt32
    '    Dim Power_Internal As UInt16
    '    Dim Power_InternalOff As UInt16
    '    Dim Scrool_Speed_X As Byte
    '    Dim Scrool_Speed_Y As Byte
    'End Structure

    Public Structure sModelTimeData
        Dim Type As Byte
        Dim nInterface As Byte
        Dim Power As sPower
        Dim Resolution As sResolution
        Dim Timing As sTiming
        Dim Signal As sSignal
        Dim Initial_BIT As SByte   ' Integer
        Dim Touch As Byte
        Dim Backlight As sBacklight
        Dim Channel As Byte
        Dim Pattern_AutoTime As Integer
        Dim Power_AutoOnTime As Int16
        Dim Power_AutoOffTime As Int16
        Dim ScrollSpeed_X As Byte
        Dim ScrollSpeed_Y As Byte
        Dim PatternName As String
        Dim PatternName2 As String
    End Structure

    Public Structure sInitialInfo
        Dim fileName_On As String
        Dim fileName_Off As String
        Dim fileName_Scenario As String
    End Structure

    Public Structure sPatternList
        Dim Idx As Integer
        Dim Len As Integer
        Dim PatternItem() As sPatternItem
    End Structure

    Public Structure sPatternItem
        Dim sImageName As String
        Dim MainCode As Byte
        Dim SubCode As Byte
        Dim Red As Byte
        Dim Green As Byte
        Dim Blue As Byte
        Dim Vdd As Int16
        Dim Vci As Int16
        Dim ELVDD As Int16
        Dim ELVSS As Int16
        Dim Clock As Int32
        Dim Pause As Int16
    End Structure

    Public Structure sPower
        Dim ELVDD As Int16
        Dim ELVSS As Int16
        Dim VDD As Int16
        Dim VCI As Int16
        Dim VEXT1 As Int16
        Dim VEXT2 As Int16
    End Structure

    Public Structure sResolution
        Dim Width As Int16
        Dim Height As Int16
    End Structure

    Public Structure sTiming
        Dim HSPW As Int16
        Dim HBPD As Int16
        Dim HFPD As Int16
        Dim VSPW As Int16
        Dim VBPD As Int16
        Dim VFPD As Int16
        Dim Clock As Integer
    End Structure

    Public Structure sSignal
        Dim DOTCLK As Byte
        Dim Enable As Byte
        Dim VSYNC As Byte
        Dim HSYNC As Byte
    End Structure

    Public Structure sBacklight
        Dim BLU As Byte
        Dim Current As Int16
    End Structure


    Public Structure ClassImage
        Dim Data() As Byte
        Dim Name As String
    End Structure


    Public Structure GNTIBinFile
        Dim Name As String
        Dim Data() As Byte
        Dim Page As Integer
    End Structure

#End Region

#End Region

#Region "Properties"

    Sub New()
        ' TODO: Complete member initialization 

        ReDim m_PatternListData1(2)
        ReDim m_PatternListData2(2)



    End Sub

    Public ReadOnly Property Read As sModelTimeData
        Get
            Return m_ModelTimingData
        End Get
    End Property


    Public ReadOnly Property Config As sConfig
        Get
            Return m_Config
        End Get
    End Property


    Public ReadOnly Property UpdateImage As ArrayList
        Get
            Return m_ImageList
        End Get
    End Property

    Public ReadOnly Property GNTIScenario As GNTIBinFile
        Get
            Return m_GNTScenario
        End Get
    End Property

    Public ReadOnly Property EEPROMPageSize
        Get
            Return m_EEPROM_Page_Size
        End Get
    End Property

    Public Property ModelName As String
        Get
            Return m_SelectedModelName
        End Get
        Set(value As String)
            m_SelectedModelName = value
        End Set
    End Property

    Public ReadOnly Property PatternListName As String
        Get
            Return m_ModelTimingData.PatternName
        End Get
    End Property

    Public ReadOnly Property PatternListName2 As String
        Get
            Return m_ModelTimingData.PatternName2
        End Get
    End Property


    Public ReadOnly Property PatternList1 As sPatternList()
        Get
            Return m_PatternListData1
        End Get
    End Property

    Public ReadOnly Property PatternList2 As sPatternList()
        Get
            Return m_PatternListData2
        End Get
    End Property


#End Region

#Region "Creator"

    Public Sub New(ByVal GntPath As String)
        m_sPath_GNT = GntPath   'applicationStartUpPath & "\G5"
        m_ImageList = New ArrayList()

        m_GNTScenario.Data = Nothing
        m_GNTScenario.Name = ""
        m_GNTScenario.Page = 0

        If LoadConfigData(m_sPath_GNT & "\Config.ini") = False Then
            MsgBox("Don't find file.[Config.ini] ")
        End If
    End Sub
#End Region

    Public Function UpdateModelList(ByRef ModelList() As String) As Boolean

        If Directory.Exists(m_sPath_GNT) = False Then Return False
        If Directory.Exists(m_sPath_GNT & "\Model") = False Then Return False

        Dim directoryList() As String = Nothing
        directoryList = Directory.GetDirectories(m_sPath_GNT & "\Model")

        If directoryList Is Nothing Then Return False

        If directoryList.Length = 0 Then Return False

        Dim arrTemp As Array
        ReDim ModelList(directoryList.Length - 1)
        For i As Integer = 0 To directoryList.Length - 1
            arrTemp = Split(directoryList(i), "\", -1)
            ModelList(i) = arrTemp(arrTemp.Length - 1)
        Next

        Return True
    End Function


    'Public Function UpdateModelInfo(ByVal modelNames As String) As Boolean

    '    LoadModuleData(m_sPath_GNT & "\Model\" & modelNames & "\Data.ini")
    '    Return True
    'End Function

    Public Function UpdatePatternList(ByRef PatternList() As String) As Boolean

        Dim patternPath As String = m_sPath_GNT & "\Model\" & m_SelectedModelName & "\Pattern"
        If Directory.Exists(patternPath) = False Then Return False

        Dim sFileList() As String = Nothing
        sFileList = Directory.GetFiles(patternPath)

        Dim nCntPattern As Integer = 0

        For i As Integer = 0 To sFileList.Length - 1
            Dim sFileInfo As CMcFile.sFILENAME = Nothing
            If CMcFile.FilePathParser(sFileList(i), sFileInfo) = False Then Return False

            If sFileInfo.strOnlyExt = "ini" Or sFileInfo.strOnlyExt = "INI" Then
                ReDim Preserve PatternList(nCntPattern)
                PatternList(nCntPattern) = sFileInfo.strOnlyFName
                nCntPattern += 1
            End If
        Next

        Return True
    End Function

    Public Function UpdateModelInfo() As Boolean

        Dim path_modelName As String = m_sPath_GNT & "\Model\" & m_SelectedModelName
        Dim path_pattern As String = m_sPath_GNT & "\Model\" & m_SelectedModelName & "\Pattern\"

        If LoadModuleData(path_modelName & "\Data.ini") = False Then Return False

        If m_ModelTimingData.PatternName <> "" Then
            If LoadPatternData(m_PatternListData1, path_pattern & m_ModelTimingData.PatternName & ".ini") = False Then Return False
        End If

        If m_ModelTimingData.PatternName2 <> "" Then
            If LoadPatternData(m_PatternListData2, path_pattern & m_ModelTimingData.PatternName2 & ".ini") = False Then Return False
        End If

        Return True
    End Function

    Public Function UpdatePatternListInfo(ByVal patternName As String) As Boolean
        Dim path_pattern As String = m_sPath_GNT & "\Model\" & m_SelectedModelName & "\Pattern\"
        If m_ModelTimingData.PatternName <> "" Then
            If LoadPatternData(m_PatternListData1, path_pattern & patternName & ".ini") = False Then Return False
        Else
            Return False
        End If
        Return True
    End Function

    Public Function UpdatePatternImage() As Boolean

        m_ImageList = Nothing

        m_ImageList = New ArrayList

        If m_PatternListData1 Is Nothing Then Return False

        For idx As Integer = 0 To m_PatternListData1.Length - 1
            If m_PatternListData1(idx).PatternItem Is Nothing Then Return False
            If m_PatternListData1(idx).PatternItem.Length <= 0 Then Return False
        Next

        m_ImageList.Clear()

        For idx As Integer = 0 To m_PatternListData1.Length - 1
            If m_PatternListData1(idx).Len > 0 Then
                For item As Integer = 0 To m_PatternListData1(idx).PatternItem.Length - 1
                    If m_PatternListData1(idx).PatternItem(item).MainCode = 0 Then
                        If m_PatternListData1(idx).PatternItem(item).sImageName <> "" Then
                            LoadImage(m_PatternListData1(idx).PatternItem(item).sImageName)
                        End If
                    End If
                Next
            End If
        Next

        Return True
    End Function

    Public Function LoadImage(ByVal imageName As String) As Boolean

        Dim path_Image As String = m_sPath_GNT & "\Image\" & CStr(m_ModelTimingData.Resolution.Width) & "_" & CStr(m_ModelTimingData.Resolution.Height) & "\" & imageName & ".bmp"

        If File.Exists(path_Image) = False Then Return False

        Dim data As ClassImage


        data.Data = System.IO.File.ReadAllBytes(path_Image)
        data.Name = imageName

        m_ImageList.Add(data)

        Return True
    End Function

    Public Function LoadGNTIScenario() As Boolean
        Dim path_Scenario As String = m_sPath_GNT & "\Model\" & m_SelectedModelName & "\Scenario\" & m_InitialDataInfo.fileName_Scenario

        m_GNTScenario.Data = Nothing
        m_GNTScenario.Name = ""
        m_GNTScenario.Page = 0

        If File.Exists(path_Scenario) = False Then Return False

        m_GNTScenario.Name = m_InitialDataInfo.fileName_Scenario
        m_GNTScenario.Data = System.IO.File.ReadAllBytes(path_Scenario)
        m_GNTScenario.Page = Math.Floor(m_GNTScenario.Data.Length / m_EEPROM_Page_Size) + 1
        Return True
    End Function

    Public Function LoadModuleData(ByVal filePath As String) As Boolean

        If File.Exists(filePath) = False Then Return False

        Dim loader As New CIOModelData(filePath)

        With m_ModelTimingData
            .Type = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_TYPE)
            .nInterface = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_INTERFACE_BIT)
            .Power.ELVDD = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_ELVDD)
            .Power.ELVSS = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_ELVSS)
            .Power.VDD = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_VDD)
            .Power.VCI = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_VCI)
            .Power.VEXT1 = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_VEXT1)
            .Power.VEXT2 = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_VEXT2)
            .Resolution.Width = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_WIDTH)
            .Resolution.Height = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_HEIGHT)
            .Timing.HSPW = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_HSPW)
            .Timing.HBPD = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_HBPD)
            .Timing.HFPD = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_HFPD)
            .Timing.VSPW = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_VSPW)
            .Timing.VBPD = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_VBPD)
            .Timing.VFPD = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_VFPD)
            .Timing.Clock = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_CLOCK)
            .Signal.DOTCLK = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_DOTCLOCK)
            .Signal.Enable = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_ENABLE)
            .Signal.VSYNC = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_VSYNC)
            .Signal.HSYNC = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_HSYNC)
            .Initial_BIT = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_INITIAL_BIT)
            .Touch = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_TOUCH)
            .Backlight.BLU = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_BLU)
            .Backlight.Current = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_BLU_CURRENT)
            .Channel = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_CHANNEL_NUM)
            .Pattern_AutoTime = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_PATTERN_INTERVAL)
            .Power_AutoOnTime = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_POWER_INTERVAL)
            .Power_AutoOffTime = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_POWER_INTERVALOFF)
            .ScrollSpeed_X = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_SCROLL_SPEED_X)
            .ScrollSpeed_Y = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_SCROLL_SPEED_Y)
            .PatternName = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_PATTERN_NAME)
            .PatternName2 = loader.LoadIniValue(CIOModelData.eSecID._MODEL, CIOModelData.eKeyID._MODEL_PATTERN_NAME2)
        End With

        With m_InitialDataInfo
            .fileName_On = loader.LoadIniValue(CIOModelData.eSecID._INITIAL, CIOModelData.eKeyID._INITIAL_ON)
            .fileName_Off = loader.LoadIniValue(CIOModelData.eSecID._INITIAL, CIOModelData.eKeyID._INITIAL_OFF)
            .fileName_Scenario = loader.LoadIniValue(CIOModelData.eSecID._INITIAL, CIOModelData.eKeyID._INITIAL_SCENARIO)
        End With
        'Initial 

        Return True
    End Function


    Public Function LoadConfigData(ByVal filePath As String) As Boolean

        If File.Exists(filePath) = False Then Return False

        Dim loader As New CIOConfigData(filePath)

        With m_Config


            'T_Config
            .Login_pass = loader.LoadIniValue(CIOConfigData.eSecID._T_CONFIG, CIOConfigData.eKeyID._T_CONFIG_LOGIN_PASSWORD)
            .Count_Rack = loader.LoadIniValue(CIOConfigData.eSecID._T_CONFIG, CIOConfigData.eKeyID._T_CONFIG_COUNT_RACK)
            .Count_Hub = loader.LoadIniValue(CIOConfigData.eSecID._T_CONFIG, CIOConfigData.eKeyID._T_CONFIG_COUNT_HUB)
            .Edit = loader.LoadIniValue(CIOConfigData.eSecID._T_CONFIG, CIOConfigData.eKeyID._T_CONFIG_EDIT)
            .Image_Delay = loader.LoadIniValue(CIOConfigData.eSecID._T_CONFIG, CIOConfigData.eKeyID._T_CONFIG_IMAGE_DELAY)

            'Firmware
            .firmware_name = loader.LoadIniValue(CIOConfigData.eSecID._FIRMWARE, CIOConfigData.eKeyID._FIRMWARE_NAME)

            'FPGA
            .Fpga_name = loader.LoadIniValue(CIOConfigData.eSecID._FPGA, CIOConfigData.eKeyID._FPGA_NAME)

            'FTP
            .FTP_URL = loader.LoadIniValue(CIOConfigData.eSecID._FTP, CIOConfigData.eKeyID._FTP_URL)
            .FTP_Directory = loader.LoadIniValue(CIOConfigData.eSecID._FTP, CIOConfigData.eKeyID._FTP_DIRECTORY)
            .FTP_Name = loader.LoadIniValue(CIOConfigData.eSecID._FTP, CIOConfigData.eKeyID._FTP_NAME)
            .FTP_Pass = loader.LoadIniValue(CIOConfigData.eSecID._FTP, CIOConfigData.eKeyID._FTP_PASSWORD)

        End With

        Return True
    End Function




    Public Function LoadPatternData(ByRef patternList() As sPatternList, ByVal filePath As String) As Boolean

        If File.Exists(filePath) = False Then Return False

        Dim loader As New CIOPatternList(filePath)
        Const MAX_PATTERN_LEN As Integer = 90

        '     ReDim patternList.PatternItem(lenOfPattern - 1)

        Dim patternItems(MAX_PATTERN_LEN - 1) As sPatternItem
        Dim nCntOfPattern As Integer = 0
        Dim sTemp As String = ""

        For i As Integer = 0 To patternItems.Length - 1

            sTemp = ""
            With patternItems(i)
                sTemp = loader.LoadIniValue(CIOPatternList.eSecID._LIST, i, CIOPatternList.eKeyID._NAME)

                If sTemp <> "" Then
                    .sImageName = sTemp ' loader.LoadIniValue(CIOPatternList.eSecID._LIST, i, CIOPatternList.eKeyID._NAME)
                    .MainCode = loader.LoadIniValue(CIOPatternList.eSecID._LIST, i, CIOPatternList.eKeyID._MAIN)
                    .SubCode = loader.LoadIniValue(CIOPatternList.eSecID._LIST, i, CIOPatternList.eKeyID._SUB)
                    .Red = loader.LoadIniValue(CIOPatternList.eSecID._LIST, i, CIOPatternList.eKeyID._RED)
                    .Green = loader.LoadIniValue(CIOPatternList.eSecID._LIST, i, CIOPatternList.eKeyID._GREEN)
                    .Blue = loader.LoadIniValue(CIOPatternList.eSecID._LIST, i, CIOPatternList.eKeyID._BLUE)
                    .Vdd = loader.LoadIniValue(CIOPatternList.eSecID._LIST, i, CIOPatternList.eKeyID._VDD)
                    .Vci = loader.LoadIniValue(CIOPatternList.eSecID._LIST, i, CIOPatternList.eKeyID._VCI)
                    .ELVDD = loader.LoadIniValue(CIOPatternList.eSecID._LIST, i, CIOPatternList.eKeyID._ELVDD)
                    .ELVSS = loader.LoadIniValue(CIOPatternList.eSecID._LIST, i, CIOPatternList.eKeyID._ELVSS)
                    .Clock = loader.LoadIniValue(CIOPatternList.eSecID._LIST, i, CIOPatternList.eKeyID._CLOCK)
                    .Pause = loader.LoadIniValue(CIOPatternList.eSecID._LIST, i, CIOPatternList.eKeyID._PAUSE)
                    nCntOfPattern += 1
                Else
                    .sImageName = sTemp ' loader.LoadIniValue(CIOPatternList.eSecID._LIST, i, CIOPatternList.eKeyID._NAME)
                    .MainCode = 0
                    .SubCode = 0
                    .Red = 0
                    .Green = 0
                    .Blue = 0
                    .Vdd = 0
                    .Vci = 0
                    .ELVDD = 0
                    .ELVSS = 0
                    .Clock = 0
                    .Pause = 0
                End If

            End With
        Next

        'patternList.Len = nCntOfPattern
        'patternList.PatternItem = patternItems.Clone

        ReDim patternList(2)

        Dim nPatternLen As Integer = 30  '30 개씩 나눠서 담기위해서
        Dim tempPatternItem(nPatternLen - 1) As sPatternItem
        Dim tempPatternLen As Integer = 0
        Dim count As Integer

        For i As Integer = 0 To patternList.Length - 1

            If ((i + 1) * nPatternLen) <= nCntOfPattern Then  '30, 60, 90 개보다 크거나 같으면, 30개씩 쪼개야 하므로 무조건 30개
                tempPatternLen = nPatternLen
            Else   '30, 60, 90보자 작은 경우,
                tempPatternLen = nCntOfPattern - (i * nPatternLen)
                If tempPatternLen < 0 Then
                    tempPatternLen = 0
                End If
            End If

            For item As Integer = 0 To tempPatternItem.Length - 1
                count = (i * nPatternLen) + item
                tempPatternItem(item) = patternItems(count)
            Next
            patternList(i).Idx = i
            patternList(i).Len = nCntOfPattern ' tempPatternLen
            patternList(i).PatternItem = tempPatternItem.Clone
        Next

        Return True
    End Function


End Class
