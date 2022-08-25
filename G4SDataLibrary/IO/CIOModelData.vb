Public Class CIOModelData
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub


    Private strSection() As String = New String() {"TSP", "INITIAL", "MODEL"}

    Private strKey() As String = New String() {"DELETE_SHOW", _
                                               "DELETE_DAYS", "CTSP_INTERVAL", "CTSP_AXIS_X", "CTSP_AXIS_Y", "CTSP_REF_MIN", "CTSP_REF_MAX", "CTSP_DEL_MIN", "CTSP_DEL_MAX", _
                                               "ON",
                                               "OFF", "SCENARIO", _
                                               "TYPE",
                                               "INTERFACE_BIT", "ELVDD", "ELVSS", _
                                               "VDD", "VCI", "VEXT1", "VEXT2", "WIDTH", "HEIGHT", _
                                               "HSPW", "HBPD", "HFPD", "VSPW", "VBPD", "VFPD", "CLOCK", "DOTCLOCK", "ENABLE", _
                                               "VSYNC", "HSYNC", "INITIAL_BIT", "TOUCH", "BLU", "BLU_CURRENT", "CHANNEL_NUM", "PATTERN_INTERVAL", _
                                               "POWER_INTERVAL", "POWER_INTERVALOFF", "SCROLL_SPEED_X", _
                                               "SCROLL_SPEED_Y", "PATTERN_NAME", "PATTERN_NAME2"}


    Public Enum eSecID
        _TSP
        _INITIAL
        _MODEL
    End Enum

    Public Enum eKeyID
        _TSP_DELETE_SHOW
        _TSP_DELETE_DAYS
        _TSP_CTSP_INTERVAL
        _TSP_CTSP_AXIS_X
        _TSP_CTSP_AXIS_Y
        _TSP_CTSP_REF_MIN
        _TSP_CTSP_REF_MAX
        _TSP_CTSP_DEL_MIN
        _TSP_CTSP_DEL_MAX
        _INITIAL_ON
        _INITIAL_OFF
        _INITIAL_SCENARIO
        _MODEL_TYPE
        _MODEL_INTERFACE_BIT
        _MODEL_ELVDD
        _MODEL_ELVSS
        _MODEL_VDD
        _MODEL_VCI
        _MODEL_VEXT1
        _MODEL_VEXT2
        _MODEL_WIDTH
        _MODEL_HEIGHT
        _MODEL_HSPW
        _MODEL_HBPD
        _MODEL_HFPD
        _MODEL_VSPW
        _MODEL_VBPD
        _MODEL_VFPD
        _MODEL_CLOCK
        _MODEL_DOTCLOCK
        _MODEL_ENABLE
        _MODEL_VSYNC
        _MODEL_HSYNC
        _MODEL_INITIAL_BIT
        _MODEL_TOUCH
        _MODEL_BLU
        _MODEL_BLU_CURRENT
        _MODEL_CHANNEL_NUM
        _MODEL_PATTERN_INTERVAL
        _MODEL_POWER_INTERVAL
        _MODEL_POWER_INTERVALOFF
        _MODEL_SCROLL_SPEED_X
        _MODEL_SCROLL_SPEED_Y
        _MODEL_PATTERN_NAME
        _MODEL_PATTERN_NAME2
    End Enum


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="nKey"></param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal nKey As eKeyID, ByVal value As String)
        Dim sSection As String = strSection(nSection)

        IniWriteValue(sSection, strKey(nKey), value)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="rcpSectionIndex">0 부터 입력</param>
    ''' <param name="nKey"></param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal value As String)
        Dim sSection As String = strSection(nSection) & Format(rcpSectionIndex + 1, "00")

        IniWriteValue(sSection, strKey(nKey), value)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="rcpSectionIndex">0 부터 입력</param>
    ''' <param name="nKey"></param>
    ''' <param name="keyIndex">0부터 입력</param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String)
        Dim sSection As String
        Dim sKey As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        sKey = strKey(nKey) & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="nkey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal nkey As eKeyID) As String
        Dim sSection As String = strSection(nSection)

        Return IniReadValue(sSection, strKey(nkey))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="rcpSectionIndex">0 부터 입력</param>+
    ''' <param name="nkey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID) As String
        Dim sSection As String

        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")

        Return IniReadValue(sSection, strKey(nkey))
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="rcpSectionIndex">0 부터 입력</param>
    ''' <param name="nkey"></param>
    ''' <param name="keyIndex">0 부터 입력</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID, ByVal keyIndex As Integer) As String
        Dim sSection As String
        Dim sKey As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        sKey = strKey(nkey) & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function

End Class


Public Class CViewerLinkInfoINI
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub


    Private strSection() As String = New String() {"Common"}

    Private strKey() As String = New String() {"NumberOfLinkFile", "Path"}


    Public Enum eSecID
        eCommon

    End Enum


    Public Enum eKeyID
        NumberOfLinkFile
        Path
    End Enum


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="rcpSectionIndex">0 부터 입력</param>
    ''' <param name="nKey"></param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal value As String)
        Dim sSection As String

        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")

        IniWriteValue(sSection, strKey(nKey), value)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="rcpSectionIndex">0 부터 입력</param>
    ''' <param name="nKey"></param>
    ''' <param name="keyIndex">0부터 입력</param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String)
        Dim sSection As String
        Dim sKey As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        sKey = strKey(nKey) & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="rcpSectionIndex">0 부터 입력</param>+
    ''' <param name="nkey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID) As String
        Dim sSection As String

        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")

        Return IniReadValue(sSection, strKey(nkey))
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nSection"></param>
    ''' <param name="rcpSectionIndex">0 부터 입력</param>
    ''' <param name="nkey"></param>
    ''' <param name="keyIndex">0 부터 입력</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID, ByVal keyIndex As Integer) As String
        Dim sSection As String
        Dim sKey As String
        sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        sKey = strKey(nkey) & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function

End Class


