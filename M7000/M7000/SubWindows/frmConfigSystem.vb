Imports System.IO

Public Class frmConfigSystem


#Region "Define"

    Shared sDevices() As String = New String() {"M6000",
                                          "Signal Generator",
                                          "Pattern Generator",
                                          "PD Measurmentor",
                                          "Temperature Controller",
                                          "PLC",
                                          "EZ Servo",
                                          "ACF Camera",
                                          "Spectroradiometer",
                                          "SMU(IVL)",
                                          "Switch",
                                          "Color Analyzer",
                                          "BCR",
                                          "Strobe",
                                          "DMM",
                                          "IVLPowerSupply"'김세훈
                                             }


    Shared sDeviceName() As String = New String() {"M6000",
                                         "SG",
                                         "PG",
                                         "PD",
                                         "TC",
                                         "PLC",
                                         "Motion",
                                         "CCD(ACF)",
                                         "Spectrometer",
                                         "SMU(IVL)",
                                         "Switch",
                                         "CA",
                                         "BCR",
                                         "Strobe",
                                         "DMM",
                                         "IVLPowerSupply"'김세훈
                                            }


    '"NX1", _                                          "98585 Temp/Humi Reader", _


    Const sFileTitle As String = "SYSTEM CONFIGURATION INFORMATION"

    Dim m_nDeviceItems() As eDeviceItem
    Dim m_nCntDevice As Integer


    Public Enum eDeviceItem
        eSMU_M6000
        eMcSG
        ePG
        ePDMeasurement
        eTC
        ePLC
        eMotion
        eCamera
        eSpectroradiometer
        eSMU_IVL
        eSwitch
        eColorAnalyzer
        eBCR
        eStrobe
        eDMM
        eIVLPowerSupply
    End Enum


#End Region


#Region "Creator and init"

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        init()
    End Sub


    Private Sub init()


        ucDispList.UseCheckBoxex = False
        ucDispList.FullRawSelection = True

        If LoadInfo(m_nDeviceItems) = False Then
            MsgBox("Check System Configuration Settings")
        End If

        With cbSelDevice
            .Items.Clear()
            For i As Integer = 0 To sDevices.Length - 1
                .Items.Add(sDevices(i))
            Next
            .SelectedIndex = 0
        End With

        SetValueToUI()
    End Sub


    Private Sub frmConfigSystem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetValueToUI()
    End Sub

#End Region

#Region "Properties"

    Public Property Settings() As eDeviceItem()
        Get
            GetValueFromUI()
            Return m_nDeviceItems.Clone
        End Get
        Set(ByVal value As eDeviceItem())
            m_nDeviceItems = value.Clone
            m_nCntDevice = m_nDeviceItems.Length
        End Set
    End Property

    Public Property Counter As Integer
        Get
            Return m_nCntDevice
        End Get
        Set(ByVal value As Integer)
            m_nCntDevice = value
        End Set
    End Property

#End Region


#Region "Functions"

    Public Function GetValueFromUI() As Boolean
        m_nCntDevice = ucDispList.GetListItemCount

        ReDim m_nDeviceItems(m_nCntDevice - 1)

        For i As Integer = 0 To m_nCntDevice - 1
            Dim sData() As String = Nothing
            ucDispList.GetRowData(i, sData)
            m_nDeviceItems(i) = ConvertStringToDeviceItem(sData(0))
            If m_nDeviceItems(i) < 0 Then
                MsgBox("Undefined Device Detected")
                Return False
            End If
        Next

        Return True
    End Function

    Public Sub SetValueToUI()
        ucDispList.ClearAllData()
        Dim sData(0) As String

        If sDevices.Length <= m_nCntDevice Then Exit Sub

        For i As Integer = 0 To m_nCntDevice - 1
            If m_nDeviceItems(i) >= 0 Then
                sData(0) = sDevices(m_nDeviceItems(i))
                ucDispList.AddRowData_AutoCountListNo(sData)
            Else
                sData(0) = "Undefined Component"
                ucDispList.AddRowData_AutoCountListNo(sData)
            End If

        Next
    End Sub

    Public Sub SaveInfo()
        CreatePath()

        Dim Saver As New CIOSystemConfig(g_sFilePath_SystemConfig)

        Saver.SaveIniValue(CIOSystemConfig.eSecID.eFileInfo, 0, CIOSystemConfig.eKeyID.FileTitle, sFileTitle)

        Saver.SaveIniValue(CIOSystemConfig.eSecID.eSystemConfigInfo, 0, CIOSystemConfig.eKeyID.eNumberOfDeviceType, CStr(m_nCntDevice))

        For i As Integer = 0 To m_nCntDevice - 1
            Saver.SaveIniValue(CIOSystemConfig.eSecID.eSystemConfigInfo, 0, CIOSystemConfig.eKeyID.eDevice, i, sDevices(m_nDeviceItems(i)))
        Next

    End Sub

    Public Shared Function LoadInfo(ByRef nDeviceItems() As eDeviceItem) As Boolean

        If File.Exists(g_sFilePath_SystemConfig) = False Then Return False

        Dim cntDevice As Integer

        Dim Loader As New CIOSystemConfig(g_sFilePath_SystemConfig)
        Dim sTemp As String
        sTemp = Loader.LoadIniValue(CIOSystemConfig.eSecID.eFileInfo, 0, CIOSystemConfig.eKeyID.FileTitle)

        If sTemp <> sFileTitle Then Return False

        cntDevice = Loader.LoadIniValue(CIOSystemConfig.eSecID.eSystemConfigInfo, 0, CIOSystemConfig.eKeyID.eNumberOfDeviceType)

        Dim itemBuf(cntDevice - 1) As eDeviceItem

        For i As Integer = 0 To cntDevice - 1
            itemBuf(i) = ConvertStringToDeviceItem(Loader.LoadIniValue(CIOSystemConfig.eSecID.eSystemConfigInfo, 0, CIOSystemConfig.eKeyID.eDevice, i))
        Next
        nDeviceItems = itemBuf.Clone

        Return True
    End Function

    Private Sub CreatePath()
        If Directory.Exists(g_sPATH_CONFIG) = False Then
            Directory.CreateDirectory(g_sPATH_CONFIG)
        End If
    End Sub

#End Region


#Region "Control Event Functions"

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click
        Dim sDev(0) As String
        sDev(0) = sDevices(cbSelDevice.SelectedIndex)
        ucDispList.AddRowData_AutoCountListNo(sDev)
    End Sub

    Private Sub DelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelToolStripMenuItem.Click
        Dim selectedIdx As Integer

        ucDispList.GetSelectedRowNumber(selectedIdx)

        ucDispList.DelSelectedRow(selectedIdx)
    End Sub

    Private Sub UpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpToolStripMenuItem.Click
        ucDispList.ListUP()
    End Sub

    Private Sub DownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownToolStripMenuItem.Click
        ucDispList.ListDOWN()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        ucDispList.ClearAllData()
    End Sub




    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        GetValueFromUI()
        SaveInfo()
    End Sub

#End Region


#Region "Support Functions"


    Public Shared Function ConvertDeviceItemToString(ByVal dev As eDeviceItem) As String
        Dim sDevName As String
        Select Case dev
            Case eDeviceItem.eSMU_M6000
                sDevName = sDeviceName(eDeviceItem.eSMU_M6000)
            Case eDeviceItem.eMcSG
                sDevName = sDeviceName(eDeviceItem.eMcSG)
            Case eDeviceItem.ePG
                sDevName = sDeviceName(eDeviceItem.ePG)
            Case eDeviceItem.ePDMeasurement
                sDevName = sDeviceName(eDeviceItem.ePDMeasurement)
            Case eDeviceItem.eTC
                sDevName = sDeviceName(eDeviceItem.eTC)
            Case eDeviceItem.ePLC
                sDevName = sDeviceName(eDeviceItem.ePLC)
            Case eDeviceItem.eMotion
                sDevName = sDeviceName(eDeviceItem.eMotion)
            Case eDeviceItem.eCamera
                sDevName = sDeviceName(eDeviceItem.eCamera)
            Case eDeviceItem.eSpectroradiometer
                sDevName = sDeviceName(eDeviceItem.eSpectroradiometer)
            Case eDeviceItem.eSMU_IVL
                sDevName = sDeviceName(eDeviceItem.eSMU_IVL)
            Case eDeviceItem.eSwitch
                sDevName = sDeviceName(eDeviceItem.eSwitch)
            Case eDeviceItem.eColorAnalyzer
                sDevName = sDeviceName(eDeviceItem.eColorAnalyzer)
            Case eDeviceItem.eBCR
                sDevName = sDeviceName(eDeviceItem.eBCR)
            Case eDeviceItem.eStrobe
                sDevName = sDeviceName(eDeviceItem.eStrobe)
            Case eDeviceItem.eDMM
                sDevName = sDeviceName(eDeviceItem.eDMM)
                '김세훈
            Case eDeviceItem.eIVLPowerSupply
                sDevName = sDeviceName(eDeviceItem.eIVLPowerSupply)
            Case Else
                sDevName = Nothing
        End Select

        Return sDevName
    End Function

    Public Shared Function ConvertStringToDeviceItem(ByVal str As String) As eDeviceItem

        'Dim strDevices() As String = New String() {"M6000", _
        '                                  "Signal Generator", _
        '                                  "Pattern Generator", _
        '                                  "PD Measurmentor", _
        '                                  "Temprature Controller", _
        '                                  "PLC", _
        '                                  "AJIN", _
        '                                  "GC1290", _
        '                                  "PR730", _
        '                                  "PR705", _
        '                                  "SR3AR", _
        '                                  "SMU for IVL", _
        '                                  "Switch"}


        '"NX1", _
        '                                "98585 Temp/Humi Reader", _

        Select Case str
            Case sDevices(eDeviceItem.eSMU_M6000)    '0
                Return eDeviceItem.eSMU_M6000
            Case sDevices(eDeviceItem.eMcSG)   '1
                Return eDeviceItem.eMcSG
            Case sDevices(eDeviceItem.ePG) '2
                Return eDeviceItem.ePG
            Case sDevices(eDeviceItem.ePDMeasurement)  '3
                Return eDeviceItem.ePDMeasurement
            Case sDevices(eDeviceItem.eTC)  '4
                Return eDeviceItem.eTC
                'Case strDevices(eDeviceItem.eTC_NX1)  '5
                '    Return eDeviceItem.eTC_NX1
                'Case strDevices(eDeviceItem.eTHC_98585)  '6
                '    Return eDeviceItem.eTHC_98585
            Case sDevices(eDeviceItem.ePLC)  '7
                Return eDeviceItem.ePLC
            Case sDevices(eDeviceItem.eMotion)   '8
                Return eDeviceItem.eMotion
            Case sDevices(eDeviceItem.eCamera)   '9
                Return eDeviceItem.eCamera
                'Case sDevices(eDeviceItem.ePR730)   '10
                '    Return eDeviceItem.ePR730
                'Case sDevices(eDeviceItem.ePR705)   '11
                '    Return eDeviceItem.ePR705
                'Case sDevices(eDeviceItem.eSR3AR)   '12
                '    Return eDeviceItem.eSR3AR
            Case sDevices(eDeviceItem.eSpectroradiometer)
                Return eDeviceItem.eSpectroradiometer
            Case sDevices(eDeviceItem.eSMU_IVL)   '13
                Return eDeviceItem.eSMU_IVL
            Case sDevices(eDeviceItem.eSwitch)  '14
                Return eDeviceItem.eSwitch
            Case sDevices(eDeviceItem.eColorAnalyzer)
                Return eDeviceItem.eColorAnalyzer
            Case sDevices(eDeviceItem.eBCR)
                Return eDeviceItem.eBCR
            Case sDevices(eDeviceItem.eStrobe)
                Return eDeviceItem.eStrobe
            Case sDevices(eDeviceItem.eDMM)
                Return eDeviceItem.eDMM
                '김세훈
            Case sDevices(eDeviceItem.eIVLPowerSupply)
                Return eDeviceItem.eIVLPowerSupply
                'Case strDevices(eDeviceItem.eTC_TD500)   '15
                '    Return eDeviceItem.eTC_TD500
                'Case strDevices(eDeviceItem.eTC_SP790)   '16
                '    Return eDeviceItem.eTC_SP790
            Case Else
                Return -1
        End Select

    End Function

    Public Shared Function FindDevice(ByVal dev As eDeviceItem) As Boolean
        For i As Integer = 0 To g_ConfigInfos.nDevice.Length - 1
            If g_ConfigInfos.nDevice(i) = dev Then
                Return True
            End If
        Next
        Return False
    End Function

#End Region


End Class



Public Class CIOSystemConfig
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub

    Private strSection() As String = New String() {"File Info", "System Configuration"}


    Private strKey() As String = New String() {
"File Title",
"Number Of Device Type", "Device"
 }


    Public Enum eSecID
        eFileInfo
        eSystemConfigInfo
    End Enum

    Public Enum eKeyID
        FileTitle
        eNumberOfDeviceType
        eDevice
    End Enum

    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal value As String)
        Dim sSection As String
        If nSection = eSecID.eSystemConfigInfo Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        IniWriteValue(sSection, strKey(nKey), value)
    End Sub


    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String)
        Dim sSection As String
        Dim sKey As String
        If nSection = eSecID.eSystemConfigInfo Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        sKey = strKey(nKey) & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID) As String
        Dim sSection As String
        If nSection = eSecID.eSystemConfigInfo Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        Return IniReadValue(sSection, strKey(nkey))
    End Function

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID, ByVal keyIndex As Integer) As String
        Dim sSection As String
        Dim sKey As String
        If nSection = eSecID.eSystemConfigInfo Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        sKey = strKey(nkey) & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function


End Class