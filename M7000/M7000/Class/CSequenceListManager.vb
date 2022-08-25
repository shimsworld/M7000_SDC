Imports System.IO

Public Class CSequenceListManager

#Region "Define"

    Dim m_sPathSequenceFolder As String = "\Sequence"
    Dim sSeqList As String = Application.StartupPath & m_sPathSequenceFolder & "\seqList.ini"
    Dim seqFileExtention As String = "seq"
    Dim sFileTitle As String = "Sequence List File"


    Public Structure SequenceListInfo
        Dim sPath As String
        Dim sSequenceName As String
        Dim sDescriptions As String
        Dim nSampleType As ucSampleInfos.eSampleType
    End Structure

    Dim m_SeqList() As SequenceListInfo
    Dim m_cntSequence As Integer

#End Region

#Region "Creator"


#End Region
    Public Sub New()
        m_SeqList = Nothing

        If LoadSequencelist() = False Then
            MsgBox("Sequence builder could not find sequence files or a files was damaged")
        End If
        'SearchSequenceFilesInSequenceFolder()
    End Sub

#Region "Properties"

    Public Property SequenceList As SequenceListInfo()
        Get
            Return m_SeqList
        End Get
        Set(ByVal value As SequenceListInfo())
            m_SeqList = value
        End Set
    End Property

    Public ReadOnly Property Counter As Integer
        Get
            Return m_cntSequence
        End Get
    End Property

#End Region

    

    Public Function LoadSequencelist() As Boolean

        If File.Exists(sSeqList) = False Then Return False

        Dim loader As New CIOSeqListInfo(sSeqList)
        Dim sTemp As String

        sTemp = CStr(loader.LoadIniValue(CIOSeqListInfo.eSecID.eFileInfo, 0, CIOSeqListInfo.eKeyID.FileTitle))

        If sTemp <> sFileTitle Then Return False

        m_cntSequence = loader.LoadIniValue(CIOSeqListInfo.eSecID.eFileInfo, 0, CIOSeqListInfo.eKeyID.eNumberOfSequence)

        ReDim m_SeqList(m_cntSequence - 1)


        Try

            For i As Integer = 0 To m_cntSequence - 1

                m_SeqList(i).sSequenceName = loader.LoadIniValue(CIOSeqListInfo.eSecID.eSequenceInfo, i, CIOSeqListInfo.eKeyID.eSequenceName)
                m_SeqList(i).sDescriptions = loader.LoadIniValue(CIOSeqListInfo.eSecID.eSequenceInfo, i, CIOSeqListInfo.eKeyID.eSequenceDescription)
                m_SeqList(i).sPath = loader.LoadIniValue(CIOSeqListInfo.eSecID.eSequenceInfo, i, CIOSeqListInfo.eKeyID.eSequencePath)
                m_SeqList(i).nSampleType = CInt(loader.LoadIniValue(CIOSeqListInfo.eSecID.eSequenceInfo, i, CIOSeqListInfo.eKeyID.eSampleType))

                'loader.SaveIniValue(CIOSeqListInfo.eSecID.eSequenceInfo, i, CIOSeqListInfo.eKeyID.eSequenceName, m_SeqList(i).sSequenceName)
                'loader.SaveIniValue(CIOSeqListInfo.eSecID.eSequenceInfo, i, CIOSeqListInfo.eKeyID.eSequenceDescription, m_SeqList(i).sDescriptions)
                'loader.SaveIniValue(CIOSeqListInfo.eSecID.eSequenceInfo, i, CIOSeqListInfo.eKeyID.eSequencePath, m_SeqList(i).sPath)
            Next
      
        Catch ex As Exception
            m_SeqList = Nothing
            Return False
        End Try

        Return True
    End Function


    Public Sub SaveSequenceList()

        'List 파일이 있으면 무조건 삭제하고 다시 만들어서 정보를 저장함.
        'If File.Exists(sSeqList) = True Then
        '    File.Delete(sSeqList)
        'End If

        'File.Create(sSeqList)

        If File.Exists(sSeqList) = True Then
            File.Delete(sSeqList)
        End If

        Dim saver As New CIOSeqListInfo(sSeqList)

        saver.SaveIniValue(CIOSeqListInfo.eSecID.eFileInfo, 0, CIOSeqListInfo.eKeyID.FileTitle, sFileTitle)

        If m_SeqList Is Nothing Then
            saver.SaveIniValue(CIOSeqListInfo.eSecID.eFileInfo, 0, CIOSeqListInfo.eKeyID.eNumberOfSequence, "0")
        Else
            saver.SaveIniValue(CIOSeqListInfo.eSecID.eFileInfo, 0, CIOSeqListInfo.eKeyID.eNumberOfSequence, CStr(m_cntSequence))

            For i As Integer = 0 To m_cntSequence - 1
                saver.SaveIniValue(CIOSeqListInfo.eSecID.eSequenceInfo, i, CIOSeqListInfo.eKeyID.eSampleType, m_SeqList(i).nSampleType)
                saver.SaveIniValue(CIOSeqListInfo.eSecID.eSequenceInfo, i, CIOSeqListInfo.eKeyID.eSequenceName, m_SeqList(i).sSequenceName)
                saver.SaveIniValue(CIOSeqListInfo.eSecID.eSequenceInfo, i, CIOSeqListInfo.eKeyID.eSequenceDescription, m_SeqList(i).sDescriptions)
                saver.SaveIniValue(CIOSeqListInfo.eSecID.eSequenceInfo, i, CIOSeqListInfo.eKeyID.eSequencePath, m_SeqList(i).sPath)
            Next
        End If

    End Sub


    
        ''' <summary>
        ''' Update the sequence list information
        ''' search and update sequende file save folder
        ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub SearchSequenceFilesInSequenceFolder()


        'Sequence List Folder 확인 
        If Directory.Exists(Application.StartupPath & m_sPathSequenceFolder) = False Then
            Directory.CreateDirectory(Application.StartupPath & m_sPathSequenceFolder)
        End If
        Dim sSequenceFolderFiles() As String
        Dim nCntSequenceFile As Integer
        Dim sSequenceFiles() As String = Nothing
        sSequenceFolderFiles = Directory.GetFiles(Application.StartupPath & m_sPathSequenceFolder)

        If sSequenceFolderFiles Is Nothing = False Then

            Dim arrTemp As Array
            For i As Integer = 0 To sSequenceFolderFiles.Length - 1
                arrTemp = Split(sSequenceFolderFiles(i), ".", -1)
                If arrTemp(1) = seqFileExtention Then
                    ReDim Preserve sSequenceFiles(nCntSequenceFile)
                    sSequenceFiles(nCntSequenceFile) = sSequenceFolderFiles(i)
                    'sSequenceFiles(nCntSequenceFile) = sPathSequenceFolder(i)
                    nCntSequenceFile += 1
                End If
            Next

            m_cntSequence = nCntSequenceFile
            ReDim m_SeqList(nCntSequenceFile - 1)



            For i As Integer = 0 To m_SeqList.Length - 1
                m_SeqList(i).sPath = sSequenceFiles(i)
                'm_SeqList(i).sPath = sPathSequenceFolder & "\" & sSequenceFiles(i)
            Next
        Else
            m_SeqList = Nothing
            m_cntSequence = 0
        End If

        'SaveSequenceList()
    End Sub

    ''' <summary>
    ''' Add sequence list
    ''' </summary>
    ''' <param name="info"></param>
    ''' <remarks></remarks>
    Public Sub Add(ByVal info As SequenceListInfo)
        ReDim Preserve m_SeqList(m_cntSequence)
        m_SeqList(m_cntSequence) = info
        m_cntSequence += 1

        SaveSequenceList()
    End Sub

    ''' <summary>
    ''' Delete Sequenc list and Sequence File
    ''' 
    ''' </summary>
    ''' <param name="idx"></param>
    ''' <remarks></remarks>
    Public Sub Del(ByVal idx As Integer)

        If m_cntSequence = 0 Then Exit Sub
        If m_SeqList Is Nothing = True Then Exit Sub

        If m_cntSequence = 1 Then
            For i As Integer = 0 To m_SeqList.Length - 1
                If File.Exists(Application.StartupPath & m_SeqList(i).sPath) = True Then
                    File.Delete(Application.StartupPath & m_SeqList(i).sPath)
                End If
            Next
            Clear()
        Else
            Dim seqList(m_cntSequence - 2) As SequenceListInfo

            m_cntSequence = 0
            For i As Integer = 0 To seqList.Length '- 1 'm_cntSequence - 1
                If i <> idx Then
                    seqList(m_cntSequence) = m_SeqList(i)
                    m_cntSequence += 1
                Else
                    If File.Exists(Application.StartupPath & m_SeqList(m_cntSequence).sPath) = True Then
                        File.Delete(Application.StartupPath & m_SeqList(m_cntSequence).sPath)
                    End If
                End If
            Next

            m_SeqList = seqList.Clone
        End If
        SaveSequenceList()
    End Sub


    ''' <summary>
    ''' Clear Sequence list and All Sequence File
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        m_SeqList = Nothing
        m_cntSequence = 0

        SaveSequenceList()
    End Sub


    Public Sub Update(ByVal idx As Integer, ByVal info As SequenceListInfo)
        m_SeqList(idx) = info
        SaveSequenceList()
    End Sub

End Class


Public Class CIOSeqListInfo
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub

    Private strSection() As String = New String() {"File Info", "Sequence Info"}


    Private strKey() As String = New String() {
"File Title", _
"Sample Type", "Number Of Sequence", "Sequence Name", "Sequence Description", "Sequece Path"
 }


    Public Enum eSecID
        eFileInfo
        eSequenceInfo
    End Enum

    Public Enum eKeyID
        FileTitle
        eSampleType
        eNumberOfSequence
        eSequenceName
        eSequenceDescription
        eSequencePath
    End Enum

    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal value As String)
        Dim sSection As String
        If nSection = eSecID.eSequenceInfo Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        IniWriteValue(sSection, strKey(nKey), value)
    End Sub


    Public Sub SaveIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nKey As eKeyID, ByVal keyIndex As Integer, ByVal value As String)
        Dim sSection As String
        Dim sKey As String
        If nSection = eSecID.eSequenceInfo Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        sKey = strKey(nKey) & Format(keyIndex + 1, "00")
        IniWriteValue(sSection, sKey, value)
    End Sub

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID) As String
        Dim sSection As String
        If nSection = eSecID.eSequenceInfo Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        Return IniReadValue(sSection, strKey(nkey))
    End Function

    Public Function LoadIniValue(ByVal nSection As eSecID, ByVal rcpSectionIndex As Integer, ByVal nkey As eKeyID, ByVal keyIndex As Integer) As String
        Dim sSection As String
        Dim sKey As String
        If nSection = eSecID.eSequenceInfo Then
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        Else
            sSection = strSection(nSection)
        End If
        sKey = strKey(nkey) & Format(keyIndex + 1, "00")
        Return IniReadValue(sSection, sKey)
    End Function


End Class
