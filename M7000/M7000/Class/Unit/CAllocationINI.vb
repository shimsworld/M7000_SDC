Public Class CAllocationINI

    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub

    Private strSection() As String = New String() {"File Info", "Allocation Data", "JIG Layout", "Display"}

    Private strKey() As String = New String() {"File Title", "File Version",
                                                 "MaxCh", "Num Of Items", "Channel Allocation Item", "Channel Allocation Value",
                                                 "JIGNo", "SampleType", "NumOfSample", "JIGSize", "JIGLocation", "CellLayoutCol", "CellLayoutRow", _
                                                 "JIGBackgroundColor", "JIGOutlineColor_Sel", "JIGOutlineColor_Unsel", "JIGOutlineWidth", "Font of status", "Font Style of status", _
                                                  "DisplayMode", "JIGEnableMultiSelect", "JIGAddText"}

    Public Enum eSecID
        eFileInfo
        eAllocationData
        eJIGLayoutData
        eDisplay
    End Enum

    Public Enum eKeyID
        FileTitle
        FileVersion
        eMaxCh          'Allocation Info
        eNumOfItem
        eChAlocItem
        eValue
        eJL_JIGNo           'JIG Layout Info
        eJL_SampleType
        eJL_NumOfSample
        eJL_JIGSize
        eJL_JIGLocation
        eJL_CellLayoutCol
        eJL_CellLayoutRow
        eJL_JIGBackgroundColor
        eJL_JIGOutlineColor_Sel
        eJL_JIGOutlineColor_Unsel
        eJL_JIGOutlineWidth
        _JL_StatusMsgFont
        _JL_StatusMsgFont_FontStyle
        eDisplayMode               'UI Display
        eJL_JIGEnableMultiSelect
        eJL_JIGAddText
    End Enum

    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal value As String)

        Dim sSection As String
        If nSection = eSecID.eAllocationData Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        IniWriteValue(sSection, strKey(nKey), value)
    End Sub


    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String)
        Dim sSection As String
        Dim sKey As String
        If nSection = eSecID.eAllocationData Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        sKey = strKey(nKey) & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID) As String
        Dim sSection As String
        If nSection = eSecID.eAllocationData Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        Return IniReadValue(sSection, strKey(nkey))
    End Function

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID, ByVal keyIndex As Integer) As String
        Dim sSection As String
        Dim sKey As String
        If nSection = eSecID.eAllocationData Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")

        Else
            sSection = strSection(nSection)
        End If
        sKey = strKey(nkey) & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function


End Class
