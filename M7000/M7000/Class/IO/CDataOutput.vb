Imports System.IO
Imports CSpectrometerLib

Public Class cDataOutput

#Region "Define"
    Dim iResultDataNumber As Integer = 1

    Dim sReportTitle_Lifetime As String = "[Lifetime Measurement Data]"
    Dim sReportTitle_IVL As String = "[IVL Meas Condition]"
    Dim sReportTitle_Angle As String = "[Viewing Angle Meas Condition]"
    Dim sReportTitle_ImageSticking As String = "[Image Sticking Data]"
    Dim sreportTitle_SpectrumData As String = "[Spectrum Data]"
    Dim sMeasMode() As String = New String() {"KeepingMode", "OperationMode"}
    Dim sBiasMode() As String = New String() {"CC", "CV", "PC", "PV", "PCV"}
    Dim FileName As String
    Dim sFileType() As String = New String() {".csv", ".xlsx"}

    Dim m_sDfaultFileSavePath As String '최종 데이터 저장 경로 및 파일명을 저장 할 변수

    Public m_sSavePath_LT() As String
    Public m_sSavePath_LT_SpectrumData() As String
    Public m_sSavePath_LT_Backup() As String
    Public m_sSavePath_LT_SpectrumData_Backup() As String

    Public m_sSavePath_Sweep() As String
    Public m_sSavePath_Sweep_SpectrumData() As String
    Public m_sSavePath_Sweep_Backup() As String
    Public m_sSavePath_Sweep_SpectrumData_Backup() As String

    Private m_sPATH_Default As String = Application.StartupPath & "\Data\"
    Private cExcelCVT As CExcelConverter

    Dim m_TestStartTime() As Date '각 파일의 데이터 저장 시작 시간
    Dim m_Lifetime() As TimeSpan '시작 시간에서 현재 시간을  뺀 시간
    Dim m_nCntSaveData() As Integer ' 저장된 포인트 수
    Dim m_nCntRedSaveData() As Integer ' 저장된 포인트 수
    Dim m_nCntGreenSaveData() As Integer ' 저장된 포인트 수
    Dim m_nCntBlueSaveData() As Integer ' 저장된 포인트 수
    Dim m_nCntBlackSaveData() As Integer
    Dim m_SeqInfo As CSequenceManager.sSequenceInfo
    Dim m_nCh As Integer
    Dim m_nFileType As eFileType

    'Dim MeasureData As sMeasuredData

    'Structure sMeasuredData
    '    Dim Time As Date
    '    Dim HourPass As Double
    '    Dim dBiasVolt As Double
    '    Dim dAmplitudeVolt As Double
    '    Dim dBiasCurr As Double
    '    Dim dAmplitudeCurr As Double
    '    Dim dLuminance As Double
    '    Dim dPDcurr As Double
    '    Dim dTemperature As Double
    'End Structure

#End Region

#Region "Properties"

    Public ReadOnly Property numberOfSaveFile As Integer
        Get
            Return m_SeqInfo.nCounter
        End Get
    End Property

    Public Property StartTime As Date()
        Get
            Return m_TestStartTime.Clone
        End Get
        Set(ByVal value As Date())
            m_TestStartTime = value.Clone
        End Set
    End Property

    Public Property SavedDataCounter As Integer()
        Get
            Return m_nCntSaveData.Clone
        End Get
        Set(ByVal value As Integer())
            m_nCntSaveData = value.Clone
        End Set
    End Property
    Public Property RedSavedDataCounter As Integer()
        Get
            Return m_nCntRedSaveData.Clone
        End Get
        Set(ByVal value As Integer())
            m_nCntRedSaveData = value.Clone
        End Set
    End Property
    Public Property GreenSavedDataCounter As Integer()
        Get
            Return m_nCntGreenSaveData.Clone
        End Get
        Set(ByVal value As Integer())
            m_nCntGreenSaveData = value.Clone
        End Set
    End Property
    Public Property BlueSavedDataCounter As Integer()
        Get
            Return m_nCntBlueSaveData.Clone
        End Get
        Set(ByVal value As Integer())
            m_nCntBlueSaveData = value.Clone
        End Set
    End Property
    Public Property BlackSavedDataCounter As Integer()
        Get
            Return m_nCntBlackSaveData.Clone
        End Get
        Set(ByVal value As Integer())
            m_nCntBlackSaveData = value.Clone
        End Set
    End Property

    Public ReadOnly Property Lifetime As TimeSpan()
        Get
            Return m_Lifetime.Clone
        End Get
    End Property


    Public ReadOnly Property SavePath_LT(ByVal idx As Integer) As String
        Get
            Return m_sSavePath_LT_Backup(idx)
        End Get
    End Property

#End Region

#Region "Enum"
    Public Enum eFileType
        eCSV
        eExcel
    End Enum

#End Region

#Region "Creator and inititalization"

     Public Sub New(ByVal sequence As CSequenceManager.sSequenceInfo, ByVal numOfCh As Integer, Optional ByVal bDate As Boolean = False)
        m_SeqInfo = sequence

        m_nCh = numOfCh

        ReDim m_sSavePath_LT((m_SeqInfo.nCounter * sequence.sRecipes(m_SeqInfo.nCounter - 1).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length) - 1)
        ReDim m_sSavePath_LT_Backup((m_SeqInfo.nCounter * sequence.sRecipes(m_SeqInfo.nCounter - 1).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length) - 1)
        ReDim m_sSavePath_LT_SpectrumData((m_SeqInfo.nCounter * sequence.sRecipes(m_SeqInfo.nCounter - 1).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length) - 1)
        ReDim m_sSavePath_LT_SpectrumData_Backup((m_SeqInfo.nCounter * sequence.sRecipes(m_SeqInfo.nCounter - 1).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length) - 1)

        ReDim m_sSavePath_Sweep(m_SeqInfo.nCounter - 1)
        ReDim m_sSavePath_Sweep_Backup(m_SeqInfo.nCounter - 1)
        ReDim m_sSavePath_Sweep_SpectrumData(m_SeqInfo.nCounter - 1)
        ReDim m_sSavePath_Sweep_SpectrumData_Backup(m_SeqInfo.nCounter - 1)

        ReDim m_TestStartTime((m_SeqInfo.nCounter * sequence.sRecipes(m_SeqInfo.nCounter - 1).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length) - 1)  '각 파일의 데이터 저장 시작 시간
        ReDim m_Lifetime((m_SeqInfo.nCounter * sequence.sRecipes(m_SeqInfo.nCounter - 1).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length) - 1)  '시작 시간에서 현재 시간을  뺀 시간
        ReDim m_nCntSaveData((m_SeqInfo.nCounter * sequence.sRecipes(m_SeqInfo.nCounter - 1).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length) - 1)  ' 저장된 포인트 수
        ReDim m_nCntRedSaveData((m_SeqInfo.nCounter * sequence.sRecipes(m_SeqInfo.nCounter - 1).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length) - 1)  ' 저장된 포인트 수
        ReDim m_nCntGreenSaveData((m_SeqInfo.nCounter * sequence.sRecipes(m_SeqInfo.nCounter - 1).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length) - 1)  ' 저장된 포인트 수
        ReDim m_nCntBlueSaveData((m_SeqInfo.nCounter * sequence.sRecipes(m_SeqInfo.nCounter - 1).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length) - 1)  ' 저장된 포인트 수
        ReDim m_nCntBlackSaveData((m_SeqInfo.nCounter * sequence.sRecipes(m_SeqInfo.nCounter - 1).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length) - 1)
        CreateSaveDirectory(bDate)

    End Sub

    Dim sDate As String = CTime.GetYMD & "\"
    '  Dim sDataTypeFolder() As String = New String() {"IVL Sweep\" & sDate, "Lifetime\" & sDate, "Viewing Angle\" & sDate}
    Dim sDataTypeFolder() As String = New String() {"IVL Sweep\", "Lifetime\", "Viewing Angle\", "Lifetime_IVL\"}
    Public Sub DataTypeFolder(ByRef sFolder As String, ByVal nMode As ucSequenceBuilder.eRcpMode)
        Select Case nMode
            Case ucSequenceBuilder.eRcpMode.eNothing
                sFolder = ""
            Case ucSequenceBuilder.eRcpMode.eCell_IVL, ucSequenceBuilder.eRcpMode.ePanel_IVL, ucSequenceBuilder.eRcpMode.eModuel_IVL
                sFolder = sDataTypeFolder(0)
            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.ePanel_Lifetime, ucSequenceBuilder.eRcpMode.eModule_Lifetime
                sFolder = sDataTypeFolder(1)
            Case ucSequenceBuilder.eRcpMode.eViewingAngle
                sFolder = sDataTypeFolder(2)
            Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                sFolder = sDataTypeFolder(3)
        End Select
    End Sub

    Private Sub CreateSaveDirectory(ByVal bDate As Boolean)
        If bDate = True Then
            If m_SeqInfo.sCommon.saveInfo.strPathAndFName Is Nothing = False Then
                For idx As Integer = 0 To m_SeqInfo.sRecipes.Length - 1
                    Select Case m_SeqInfo.sRecipes(idx).nMode
                        Case ucSequenceBuilder.eRcpMode.eCell_IVL, ucSequenceBuilder.eRcpMode.ePanel_IVL, ucSequenceBuilder.eRcpMode.eModuel_IVL
                            If Directory.Exists(m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(0) & m_SeqInfo.sCommon.saveInfo.strOnlyFName) = False Then Directory.CreateDirectory(m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(0) & m_SeqInfo.sCommon.saveInfo.strOnlyFName)
                        Case ucSequenceBuilder.eRcpMode.eViewingAngle
                            If Directory.Exists(m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(2) & m_SeqInfo.sCommon.saveInfo.strOnlyFName) = False Then Directory.CreateDirectory(m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(2) & m_SeqInfo.sCommon.saveInfo.strOnlyFName)
                        Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.ePanel_Lifetime, ucSequenceBuilder.eRcpMode.eModule_Lifetime
                            If Directory.Exists(m_SeqInfo.sCommon.saveInfo.strFPath & m_SeqInfo.sCommon.saveInfo.strOnlyFName) = False Then Directory.CreateDirectory(m_SeqInfo.sCommon.saveInfo.strFPath & m_SeqInfo.sCommon.saveInfo.strOnlyFName)
                        Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                            If Directory.Exists(m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(3) & m_SeqInfo.sCommon.saveInfo.strOnlyFName) = False Then Directory.CreateDirectory(m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(3) & m_SeqInfo.sCommon.saveInfo.strOnlyFName)
                    End Select
                Next
            Else   '저장 경로를 입력 하지 않았을 경우 Default 저장 경로 생성

                For idx As Integer = 0 To m_SeqInfo.sRecipes.Length - 1
                    Select Case m_SeqInfo.sRecipes(idx).nMode
                        Case ucSequenceBuilder.eRcpMode.eCell_IVL, ucSequenceBuilder.eRcpMode.eModuel_IVL, ucSequenceBuilder.eRcpMode.ePanel_IVL
                            If Directory.Exists(m_sPATH_Default & sDataTypeFolder(0)) = False Then Directory.CreateDirectory(m_sPATH_Default & sDataTypeFolder(0))
                        Case ucSequenceBuilder.eRcpMode.eViewingAngle
                            If Directory.Exists(m_sPATH_Default & sDataTypeFolder(2)) = False Then Directory.CreateDirectory(m_sPATH_Default & sDataTypeFolder(2))
                        Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eModule_Lifetime, ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                            If Directory.Exists(m_sPATH_Default) = False Then Directory.CreateDirectory(m_sPATH_Default)
                        Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                            If Directory.Exists(m_sPATH_Default & sDataTypeFolder(3)) = False Then Directory.CreateDirectory(m_sPATH_Default & sDataTypeFolder(3))
                    End Select
                Next

            End If
        End If
    End Sub

    Public Sub CreateSaveFile(ByVal idx As Integer, Optional ByVal nNumMeasPoint As Integer = 0, Optional ByVal bIVLSavedata As Boolean = False)
        ' Dim nNumOfReport As Integer = m_SeqInfo.nCounterLifeTime + m_SeqInfo.nCounterPatternMeas
        Dim sCaptionAndTEGNumber As String = "PANEL" & Format(m_nCh + 1, "00") 'ucDispJIG.convertIncNumberToMatrixValue(m_nCh)

        If m_SeqInfo.sCommon.saveInfo.strPathAndFName Is Nothing = False Then
            Select Case m_SeqInfo.sRecipes(idx).nMode
                Case ucSequenceBuilder.eRcpMode.eCell_IVL, ucSequenceBuilder.eRcpMode.ePanel_IVL, ucSequenceBuilder.eRcpMode.eModuel_IVL

                    If Directory.Exists(m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(0) & m_SeqInfo.sCommon.saveInfo.strOnlyFName) = False Then Directory.CreateDirectory(m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(0) & m_SeqInfo.sCommon.saveInfo.strOnlyFName)

                    If m_SeqInfo.sRecipes(idx).sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
                        m_sSavePath_Sweep(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(0) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & "BAK_" & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_Sweep_Backup(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(0) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"
                        m_sSavePath_Sweep_SpectrumData(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(0) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & "BAK_" & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_Sweep_SpectrumData_Backup(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(0) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"
                    Else
                        m_sSavePath_Sweep(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(0) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & "BAK_" & sCaptionAndTEGNumber & "_IV_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_Sweep_Backup(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(0) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & sCaptionAndTEGNumber & "_IV_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"
                        m_sSavePath_Sweep_SpectrumData(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(0) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & "BAK_" & sCaptionAndTEGNumber & "_IV_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_Sweep_SpectrumData_Backup(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(0) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & sCaptionAndTEGNumber & "_IV_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"
                    End If

                Case ucSequenceBuilder.eRcpMode.eViewingAngle
                    m_sSavePath_Sweep(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(2) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & "BAK_" & sCaptionAndTEGNumber & "_Angle_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                    m_sSavePath_Sweep_Backup(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(2) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & sCaptionAndTEGNumber & "_Angle_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"
                    m_sSavePath_Sweep_SpectrumData(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(2) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & "BAK_" & sCaptionAndTEGNumber & "_Angle_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                    m_sSavePath_Sweep_SpectrumData_Backup(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(2) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & sCaptionAndTEGNumber & "_Angle_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"

                Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.ePanel_Lifetime, ucSequenceBuilder.eRcpMode.eModule_Lifetime
                    'If Directory.Exists(m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(1)) = False Then Directory.CreateDirectory(m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(1))
                    '' For i As Integer = 0 To m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                    'm_sSavePath_LT(nNumMeasPoint) = m_sPATH_Default & "BAK_" & sCaptionAndTEGNumber & "_Data" & "_Index" & nNumMeasPoint + 1 & ".Bak"
                    'm_sSavePath_LT_Backup(nNumMeasPoint) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(1) & sCaptionAndTEGNumber & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_P" & nNumMeasPoint + 1 & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).X & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).Y & ".csv"
                    'm_sSavePath_LT_SpectrumData(nNumMeasPoint) = m_sPATH_Default & "BAK_" & sCaptionAndTEGNumber & "_SpectrumData" & "_Index" & nNumMeasPoint + 1 & ".Bak"
                    'm_sSavePath_LT_SpectrumData_Backup(nNumMeasPoint) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(1) & sCaptionAndTEGNumber & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_P" & nNumMeasPoint + 1 & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).X & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).Y & ".csv"
                    ''   Next

                    'If File.Exists(m_sSavePath_LT(nNumMeasPoint)) = True Then
                    '    File.Delete(m_sSavePath_LT(nNumMeasPoint))
                    'End If
                    'If File.Exists(m_sSavePath_LT_SpectrumData(nNumMeasPoint)) = True Then
                    '    File.Delete(m_sSavePath_LT_SpectrumData(nNumMeasPoint))
                    'End If

                    If Directory.Exists(m_SeqInfo.sCommon.saveInfo.strFPath) = False Then Directory.CreateDirectory(m_SeqInfo.sCommon.saveInfo.strFPath)
                    ' For i As Integer = 0 To m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
                    m_sSavePath_LT(nNumMeasPoint) = m_sPATH_Default & "BAK_" & sCaptionAndTEGNumber & "_Data" & "_Index" & nNumMeasPoint + 1 & ".Bak"
                    m_sSavePath_LT_Backup(nNumMeasPoint) = m_SeqInfo.sCommon.saveInfo.strFPath & sCaptionAndTEGNumber & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_P" & nNumMeasPoint + 1 & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).X & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).Y & ".csv"
                    m_sSavePath_LT_SpectrumData(nNumMeasPoint) = m_sPATH_Default & "BAK_" & sCaptionAndTEGNumber & "_SpectrumData" & "_Index" & nNumMeasPoint + 1 & ".Bak"
                    m_sSavePath_LT_SpectrumData_Backup(nNumMeasPoint) = m_SeqInfo.sCommon.saveInfo.strFPath & sCaptionAndTEGNumber & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_P" & nNumMeasPoint + 1 & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).X & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).Y & ".csv"
                    '   Next

                    If File.Exists(m_sSavePath_LT(nNumMeasPoint)) = True Then
                        File.Delete(m_sSavePath_LT(nNumMeasPoint))
                    End If
                    If File.Exists(m_sSavePath_LT_SpectrumData(nNumMeasPoint)) = True Then
                        File.Delete(m_sSavePath_LT_SpectrumData(nNumMeasPoint))
                    End If
                Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                    If bIVLSavedata = True Then
                        m_sSavePath_Sweep(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(3) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & "BAK_" & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_Sweep_Backup(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(3) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"
                        m_sSavePath_Sweep_SpectrumData(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(3) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & "BAK_" & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_Sweep_SpectrumData_Backup(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(3) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"

                    Else
                        m_sSavePath_LT(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(3) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & "BAK_" & sCaptionAndTEGNumber & "_LifetimeData_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_LT_Backup(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(3) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & sCaptionAndTEGNumber & "_LifetimeData_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"
                        m_sSavePath_LT_SpectrumData(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(3) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & "BAK_" & sCaptionAndTEGNumber & "_LifetimeData_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_LT_SpectrumData_Backup(idx) = m_SeqInfo.sCommon.saveInfo.strFPath & sDataTypeFolder(3) & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "\" & sCaptionAndTEGNumber & "_LifetimeData_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"
                    End If

            End Select

        Else   '저장 경로를 입력 하지 않았을 경우 Default 저장 경로 생성

            Select Case m_SeqInfo.sRecipes(idx).nMode

                Case ucSequenceBuilder.eRcpMode.eCell_IVL, ucSequenceBuilder.eRcpMode.eModuel_IVL, ucSequenceBuilder.eRcpMode.ePanel_IVL
                    '  m_sSavePath(i) = g_sPATH_ResultData 

                    If m_SeqInfo.sRecipes(idx).sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
                        m_sSavePath_Sweep(idx) = m_sPATH_Default & sDataTypeFolder(0) & "BAK_" & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_Sweep_Backup(idx) = m_sPATH_Default & sDataTypeFolder(0) & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"
                        m_sSavePath_Sweep_SpectrumData(idx) = m_sPATH_Default & sDataTypeFolder(0) & "BAK_" & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_Sweep_SpectrumData_Backup(idx) = m_sPATH_Default & sDataTypeFolder(0) & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"

                    Else
                        m_sSavePath_Sweep(idx) = m_sPATH_Default & sDataTypeFolder(0) & "BAK_" & sCaptionAndTEGNumber & "_IV_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_Sweep_Backup(idx) = m_sPATH_Default & sDataTypeFolder(0) & sCaptionAndTEGNumber & "_IV_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"
                        m_sSavePath_Sweep_SpectrumData(idx) = m_sPATH_Default & sDataTypeFolder(0) & "BAK_" & sCaptionAndTEGNumber & "_IV_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_Sweep_SpectrumData_Backup(idx) = m_sPATH_Default & sDataTypeFolder(0) & sCaptionAndTEGNumber & "_IV_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"

                    End If

                Case ucSequenceBuilder.eRcpMode.eViewingAngle
                    m_sSavePath_Sweep(idx) = m_sPATH_Default & sDataTypeFolder(2) & "BAK_" & sCaptionAndTEGNumber & "_Angle_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                    m_sSavePath_Sweep_Backup(idx) = m_sPATH_Default & sDataTypeFolder(2) & sCaptionAndTEGNumber & "_Angle_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"
                    m_sSavePath_Sweep_SpectrumData(idx) = m_sPATH_Default & sDataTypeFolder(2) & "BAK_" & sCaptionAndTEGNumber & "_Angle_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                    m_sSavePath_Sweep_SpectrumData_Backup(idx) = m_sPATH_Default & sDataTypeFolder(2) & sCaptionAndTEGNumber & "_Angle_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"


                Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eModule_Lifetime, ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                    m_sSavePath_LT(idx) = m_sSavePath_LT(idx) = m_sPATH_Default & "BAK_" & sCaptionAndTEGNumber & "_Data.Bak"
                    m_sSavePath_LT_Backup(idx) = m_sPATH_Default & sCaptionAndTEGNumber & "_LifetimeData_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"
                    m_sSavePath_LT_SpectrumData(idx) = m_sPATH_Default & "BAK_" & sCaptionAndTEGNumber & "_SpectrumData.Bak"
                    m_sSavePath_LT_SpectrumData_Backup(idx) = m_sPATH_Default & sCaptionAndTEGNumber & "_LifetimeData_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"


                Case ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                    If bIVLSavedata = True Then
                        m_sSavePath_Sweep(idx) = m_sPATH_Default & sDataTypeFolder(3) & "BAK_" & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_Sweep_Backup(idx) = m_sPATH_Default & sDataTypeFolder(3) & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"
                        m_sSavePath_Sweep_SpectrumData(idx) = m_sPATH_Default & sDataTypeFolder(3) & "BAK_" & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_Sweep_SpectrumData_Backup(idx) = m_sPATH_Default & sDataTypeFolder(3) & sCaptionAndTEGNumber & "_IVL_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"

                    Else
                        m_sSavePath_LT(idx) = m_sPATH_Default & sDataTypeFolder(3) & "BAK_" & sCaptionAndTEGNumber & "_LifetimeData_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_LT_Backup(idx) = m_sPATH_Default & sDataTypeFolder(3) & sCaptionAndTEGNumber & "_LifetimeData_Index" & CStr(idx + 1) & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"
                        m_sSavePath_LT_SpectrumData(idx) = m_sPATH_Default & sDataTypeFolder(3) & "BAK_" & sCaptionAndTEGNumber & "_LifetimeData_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".Bak"
                        m_sSavePath_LT_SpectrumData_Backup(idx) = m_sPATH_Default & sDataTypeFolder(3) & sCaptionAndTEGNumber & "_LifetimeData_Index" & CStr(idx + 1) & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & CTime.GetYMD_HMS & ".csv"

                    End If

            End Select

        End If

        If bIVLSavedata = False Then
            m_nCntSaveData(nNumMeasPoint) = 0
            m_nCntRedSaveData(nNumMeasPoint) = 0
            m_nCntGreenSaveData(nNumMeasPoint) = 0
            m_nCntBlueSaveData(nNumMeasPoint) = 0
            m_nCntBlackSaveData(nNumMeasPoint) = 0
        End If

        Dim fs As System.IO.FileStream
        Dim bSpecFileCreate As Boolean = False

        If bIVLSavedata = False Then
            ' For i As Integer = 0 To m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
            If m_sSavePath_LT(nNumMeasPoint) <> "" Then
                If File.Exists(m_sSavePath_LT(nNumMeasPoint)) = False Then
                    fs = File.Create(m_sSavePath_LT(nNumMeasPoint))
                    fs.Close()
                    Try
                        File.Copy(m_sSavePath_LT(nNumMeasPoint), m_sSavePath_LT_Backup(nNumMeasPoint), True)
                    Catch ex As Exception
                        'MsgBox("CrateSaveFile" & ex.Message)
                    End Try
                End If
            End If

            If m_sSavePath_LT_SpectrumData(nNumMeasPoint) <> "" Then
                If File.Exists(m_sSavePath_LT_SpectrumData(nNumMeasPoint)) = False Then
                    fs = File.Create(m_sSavePath_LT_SpectrumData(nNumMeasPoint))
                    fs.Close()
                    Try
                        File.Copy(m_sSavePath_LT_SpectrumData(nNumMeasPoint), m_sSavePath_LT_SpectrumData_Backup(nNumMeasPoint), True)
                    Catch ex As Exception
                        'MsgBox("CrateSaveFile" & ex.Message)
                    End Try
                End If
            End If
            ' Next

        End If


        If m_sSavePath_Sweep(idx) <> "" Then
            If File.Exists(m_sSavePath_Sweep(idx)) = False Then
                fs = File.Create(m_sSavePath_Sweep(idx))
                fs.Close()
                Try
                    File.Copy(m_sSavePath_Sweep(idx), m_sSavePath_Sweep_Backup(idx), True)
                Catch ex As Exception
                    'MsgBox("CrateSaveFile" & ex.Message)
                End Try
            End If
        End If

        If m_sSavePath_Sweep_SpectrumData(idx) <> "" Then
            If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eCell_IVL Or m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then
                If m_SeqInfo.sRecipes(idx).sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
                    bSpecFileCreate = True
                Else
                    bSpecFileCreate = False
                End If
            Else
                bSpecFileCreate = True
            End If

            If bSpecFileCreate = True Then
                If File.Exists(m_sSavePath_Sweep_SpectrumData(idx)) = False Then
                    fs = File.Create(m_sSavePath_Sweep_SpectrumData(idx))
                    fs.Close()
                    Try
                        File.Copy(m_sSavePath_Sweep_SpectrumData(idx), m_sSavePath_Sweep_SpectrumData_Backup(idx), True)
                    Catch ex As Exception
                        'MsgBox("CrateSaveFile" & ex.Message)
                    End Try
                End If
            End If
        End If

    End Sub

#End Region

#Region "Function"
    'CIM DATA Create
    'Public Function CreateSaveFileCIM() As Boolean

    '    Dim fs As System.IO.FileStream

    '    For i As Integer = 0 To m_sSavePath_RDP_IVL.Length - 1
    '        Try
    '            '경로 없으면 생성
    '            If Directory.Exists(g_sPATH_ResultDataRDP) = False Then
    '                Directory.CreateDirectory(g_sPATH_ResultDataRDP)
    '            End If
    '            fs = File.Create(m_sSavePath_RDP_IVL(i))
    '            fs.Close()
    '        Catch ex As Exception
    '            Return False
    '        End Try
    '    Next

    '    For i As Integer = 0 To m_sSavePath_RDP_IVL_SPectrum.Length - 1
    '        Try
    '            If Directory.Exists(g_sPATH_ResultDataRDP) = False Then
    '                Directory.CreateDirectory(g_sPATH_ResultDataRDP)
    '            End If
    '            fs = File.Create(m_sSavePath_RDP_IVL_SPectrum(i))
    '            fs.Close()
    '        Catch ex As Exception
    '            Return False
    '        End Try
    '    Next

    '    For i As Integer = 0 To m_sSavePath_RDP_LT.Length - 1
    '        Try
    '            '경로 없으면 생성
    '            If Directory.Exists(g_sPATH_ResultDataRDP) = False Then
    '                Directory.CreateDirectory(g_sPATH_ResultDataRDP)
    '            End If
    '            fs = File.Create(m_sSavePath_RDP_LT(i))
    '            fs.Close()
    '        Catch ex As Exception
    '            Return False
    '        End Try
    '    Next

    '    For i As Integer = 0 To m_sSavePath_RDP_LT_Spectrum.Length - 1
    '        Try
    '            '경로 없으면 생성
    '            If Directory.Exists(g_sPATH_ResultDataRDP) = False Then
    '                Directory.CreateDirectory(g_sPATH_ResultDataRDP)
    '            End If
    '            fs = File.Create(m_sSavePath_RDP_LT_Spectrum(i))
    '            fs.Close()
    '        Catch ex As Exception
    '            Return False
    '        End Try
    '    Next
    '    Return True
    'End Function
    'Public Function DeleteSaveFileCIM() As Boolean

    '    Dim fs As System.IO.FileStream

    '    For i As Integer = 0 To m_sSavePath_RDP_IVL.Length - 1
    '        Try

    '            If File.Exists(m_sSavePath_RDP_IVL(i)) = True Then
    '                File.Delete(m_sSavePath_RDP_IVL(i))
    '            End If
    '        Catch ex As Exception
    '            Return False
    '        End Try
    '    Next

    '    For i As Integer = 0 To m_sSavePath_RDP_IVL_SPectrum.Length - 1
    '        Try
    '            If File.Exists(m_sSavePath_RDP_IVL_SPectrum(i)) = True Then
    '                File.Delete(m_sSavePath_RDP_IVL_SPectrum(i))
    '            End If
    '        Catch ex As Exception
    '            Return False
    '        End Try
    '    Next

    '    For i As Integer = 0 To m_sSavePath_RDP_LT.Length - 1
    '        Try
    '            If File.Exists(m_sSavePath_RDP_LT(i)) = True Then
    '                File.Delete(m_sSavePath_RDP_LT(i))
    '            End If
    '        Catch ex As Exception
    '            Return False
    '        End Try
    '    Next

    '    For i As Integer = 0 To m_sSavePath_RDP_LT_Spectrum.Length - 1
    '        Try
    '            If File.Exists(m_sSavePath_RDP_LT_Spectrum(i)) = True Then
    '                File.Delete(m_sSavePath_RDP_LT_Spectrum(i))
    '            End If
    '        Catch ex As Exception
    '            Return False
    '        End Try
    '    Next
    '    Return True
    'End Function

#Region "Save_Log"
    Public Function PostionLog(ByVal nRecipe As Integer, ByVal nCh As Integer, ByVal dCommand() As Double, ByVal dActual() As Double, ByVal dRealDistane() As Double) As Boolean
        Dim sTemp(0) As String
        Dim sTime As String
        Dim cntLine As Integer = 0
        Dim fs As System.IO.FileStream
        Dim cYear As String = Format(Now, "yyyy")
        Dim cMonth As String = Format(Now, "MM")
        Dim cDay As String = Format(Now, "dd")
        Dim sPath As String
        Dim strCurrTime As String

        sPath = g_sPATH_POSTION_LOG & nCh & "_" & cYear & cMonth & cDay & ".csv"

        'If bStandardOrMeas = True Then
        '    sPath = g_sPATH_POSTION_LOG & nCh & "_StandardPos" & cYear & cMonth & cDay & ".csv"
        'Else
        '    sPath = g_sPATH_POSTION_LOG & nCh & "_MeasPos" & cYear & cMonth & cDay & ".csv"
        'End If

        If File.Exists(g_sPATH_POSTION_LOG) = False Then
            Directory.CreateDirectory(g_sPATH_POSTION_LOG)
        End If

        strCurrTime = CTime.GetCurrentTimeToStringType

        If m_nCntSaveData(nRecipe) = 0 Then
            If File.Exists(sPath) = False Then
                fs = File.Create(sPath)
                fs.Close()
            End If


            ReDim sTemp(2)
            sTemp(cntLine) = "CommandPosition,,,, ActualPosition,,,,RealPos" : cntLine += 1
            sTemp(cntLine) = "X,Y,Z,,X,Y,Z" : cntLine += 1
            sTime = 0 'm_TotalMeasTime(idx) '"0"

        Else
            '   m_Lifetime(nRecipe) = Now.Subtract(m_TestStartTime(nRecipe))
            '  sTime = CStr(Format(m_Lifetime(nRecipe).TotalHours + m_TotalMeasTime(nRecipe), "0.000"))
        End If

        sTemp(cntLine) = dCommand(0) & "," & dCommand(1) & "," & dCommand(2) & ",," & dActual(0) & "," & dActual(1) & "," & dActual(2) & ",," & _
                                                      dRealDistane(0) & "," & dRealDistane(1) & "," & dRealDistane(2)

        If WriteFile(iResultDataNumber, sPath, sTemp) = False Then Return False


        Return True
    End Function
    'Sequence List의 Recipe Index 중 Lifetime에 해당 하는 부분 만 전달.
    'Public Sub CreateSaveFile()

    '    If m_SeqInfo.sCommon.saveInfo.strPathAndFName Is Nothing = False Then
    '        If Directory.Exists(m_SeqInfo.sCommon.saveInfo.strFPath) = False Then Exit Sub
    '    End If

    '    Dim fs As System.IO.FileStream

    '    If m_sSavePath_Backup Is Nothing Then Exit Sub

    '    For i As Integer = 0 To m_sSavePath_Backup.Length - 1
    '        If m_sSavePath_Backup(i) <> "" Then
    '            If File.Exists(m_sSavePath_Backup(i)) = False Then
    '                fs = File.Create(m_sSavePath_Backup(i))
    '                fs.Close()
    '                Try
    '                    File.Copy(m_sSavePath_Backup(i), m_sSavePath(i), True)
    '                Catch ex As Exception
    '                    'MsgBox("CrateSaveFile" & ex.Message)
    '                End Try
    '            End If
    '        End If
    '    Next
    'End Sub

#Region "SaveDataPoint Functions "

    'Sequence List의 Recipe Index 중 Lifetime에 해당 하는 부분 만 전달.

    Public Function SaveLTDataPoint(ByVal idx As Integer, ByVal sLTDatas As frmMain.sMeasureParams, ByVal MeasPointNum As Integer, Optional ByVal sTempData As String = "") As Boolean

        Dim sTemp As String = ""
        Dim sTime As String = ""
        Dim strCurrTime As String
        Dim sSaveData() As String = Nothing

        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        If m_nCntSaveData(MeasPointNum) = 0 Then
            m_TestStartTime(MeasPointNum) = Date.Parse(strCurrTime)
            sTemp = "0"
        Else
            m_Lifetime(MeasPointNum) = Now.Subtract(m_TestStartTime(MeasPointNum))
            sTemp = CStr(Format(m_Lifetime(MeasPointNum).TotalHours, "0.000"))
        End If

        sTime = CTime.GetCurrentTimeToStringType

        ConvertLTDataToArray(sLTDatas, sTemp, sTime, MeasPointNum, sSaveData)

        sTemp = ""

        For i As Integer = 0 To sSaveData.Length - 1
            sTemp = sTemp & sSaveData(i) & ","
        Next

        sTemp = sTemp & sTempData & ","

        sTemp = sTemp.TrimEnd(",")

        Try
            If WriteFile(1, m_sSavePath_LT(MeasPointNum), sTemp) = False Then Return False
        Catch ex As Exception

        End Try


        Try
            File.Copy(m_sSavePath_LT(MeasPointNum), m_sSavePath_LT_Backup(MeasPointNum), True)
            '여기서 LT데이터 RDP 함수로 전송해서 백업데이터 저장
        Catch ex As Exception
            ' MsgBox("SaveDataPoint" & ex.Message)
        End Try

        m_nCntSaveData(MeasPointNum) += 1

        Return True
    End Function


    Public Function SaveLTRedDataPoint(ByVal idx As Integer, ByVal sLTDatas As frmMain.sMeasureParams, ByVal MeasPointNum As Integer, Optional ByVal sTempData As String = "") As Boolean

        Dim sTemp As String = ""
        Dim sTime As String = ""
        Dim strCurrTime As String
        Dim sSaveData() As String = Nothing
        Dim sCaptionAndTEGNumber As String = "PANEL" & Format(m_nCh + 1, "00") 'ucDispJIG.convertIncNumberToMatrixValue(m_nCh)
        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        'If m_nCntRedSaveData(MeasPointNum) = 0 Then
        '    m_TestStartTime(MeasPointNum) = Date.Parse(strCurrTime)
        '    sTemp = "0"
        'Else
        m_Lifetime(MeasPointNum) = Now.Subtract(m_TestStartTime(MeasPointNum))
        sTemp = CStr(Format(m_Lifetime(MeasPointNum).TotalHours, "0.000"))
        '  End If

        sTime = CTime.GetCurrentTimeToStringType

        ConvertLTDataToArray_RED(sLTDatas, sTemp, sTime, MeasPointNum, sSaveData)

        sTemp = ""

        For i As Integer = 0 To sSaveData.Length - 1
            sTemp = sTemp & sSaveData(i) & ","
        Next

        sTemp = sTemp & sTempData & ","

        sTemp = sTemp.TrimEnd(",")

        Try
            If WriteFile(1, m_SeqInfo.sCommon.saveInfo.strFPath & sCaptionAndTEGNumber & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & "RED" & "_P" & MeasPointNum + 1 & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(MeasPointNum).X & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(MeasPointNum).Y & ".csv", sTemp) = False Then Return False

        Catch ex As Exception

        End Try


        m_nCntRedSaveData(MeasPointNum) += 1

        Return True
    End Function

    Public Function SaveLTGreenDataPoint(ByVal idx As Integer, ByVal sLTDatas As frmMain.sMeasureParams, ByVal MeasPointNum As Integer, Optional ByVal sTempData As String = "") As Boolean

        Dim sTemp As String = ""
        Dim sTime As String = ""
        Dim strCurrTime As String
        Dim sSaveData() As String = Nothing
        Dim sCaptionAndTEGNumber As String = "PANEL" & Format(m_nCh + 1, "00") 'ucDispJIG.convertIncNumberToMatrixValue(m_nCh)
        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        'If m_nCntGreenSaveData(MeasPointNum) = 0 Then
        '    m_TestStartTime(MeasPointNum) = Date.Parse(strCurrTime)
        '    sTemp = "0"
        'Else
        m_Lifetime(MeasPointNum) = Now.Subtract(m_TestStartTime(MeasPointNum))
        sTemp = CStr(Format(m_Lifetime(MeasPointNum).TotalHours, "0.000"))
        ' End If

        sTime = CTime.GetCurrentTimeToStringType

        ConvertLTDataToArray_GREEN(sLTDatas, sTemp, sTime, MeasPointNum, sSaveData)

        sTemp = ""

        For i As Integer = 0 To sSaveData.Length - 1
            sTemp = sTemp & sSaveData(i) & ","
        Next

        sTemp = sTemp & sTempData & ","

        sTemp = sTemp.TrimEnd(",")
        Try
            If WriteFile(1, m_SeqInfo.sCommon.saveInfo.strFPath & sCaptionAndTEGNumber & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & "GREEN" & "_P" & MeasPointNum + 1 & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(MeasPointNum).X & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(MeasPointNum).Y & ".csv", sTemp) = False Then Return False

        Catch ex As Exception

        End Try
        'If WriteFile(1, m_sSavePath_LT(MeasPointNum), sTemp) = False Then Return False

        'Try
        '    File.Copy(m_sSavePath_LT(MeasPointNum), m_sSavePath_LT_Backup(MeasPointNum), True)
        '    '여기서 LT데이터 RDP 함수로 전송해서 백업데이터 저장
        'Catch ex As Exception
        '    ' MsgBox("SaveDataPoint" & ex.Message)
        'End Try

        m_nCntGreenSaveData(MeasPointNum) += 1

        Return True
    End Function

    Public Function SaveLTBlueDataPoint(ByVal idx As Integer, ByVal sLTDatas As frmMain.sMeasureParams, ByVal MeasPointNum As Integer, Optional ByVal sTempData As String = "") As Boolean

        Dim sTemp As String = ""
        Dim sTime As String = ""
        Dim strCurrTime As String
        Dim sSaveData() As String = Nothing
        Dim sCaptionAndTEGNumber As String = "PANEL" & Format(m_nCh + 1, "00") 'ucDispJIG.convertIncNumberToMatrixValue(m_nCh)
        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        'If m_nCntBlueSaveData(MeasPointNum) = 0 Then
        '    m_TestStartTime(MeasPointNum) = Date.Parse(strCurrTime)
        '    sTemp = "0"
        'Else
        m_Lifetime(MeasPointNum) = Now.Subtract(m_TestStartTime(MeasPointNum))
        sTemp = CStr(Format(m_Lifetime(MeasPointNum).TotalHours, "0.000"))
        'End If

        sTime = CTime.GetCurrentTimeToStringType

        ConvertLTDataToArray_BLUE(sLTDatas, sTemp, sTime, MeasPointNum, sSaveData)

        sTemp = ""

        For i As Integer = 0 To sSaveData.Length - 1
            sTemp = sTemp & sSaveData(i) & ","
        Next

        sTemp = sTemp & sTempData & ","

        sTemp = sTemp.TrimEnd(",")
        Try
            If WriteFile(1, m_SeqInfo.sCommon.saveInfo.strFPath & sCaptionAndTEGNumber & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & "BLUE" & "_P" & MeasPointNum + 1 & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(MeasPointNum).X & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(MeasPointNum).Y & ".csv", sTemp) = False Then Return False

        Catch ex As Exception

        End Try
        'If WriteFile(1, m_sSavePath_LT(MeasPointNum), sTemp) = False Then Return False

        'Try
        '    File.Copy(m_sSavePath_LT(MeasPointNum), m_sSavePath_LT_Backup(MeasPointNum), True)
        '    '여기서 LT데이터 RDP 함수로 전송해서 백업데이터 저장
        'Catch ex As Exception
        '    ' MsgBox("SaveDataPoint" & ex.Message)
        'End Try

        m_nCntBlueSaveData(MeasPointNum) += 1

        Return True
    End Function

    Public Function SaveLTBlackDataPoint(ByVal idx As Integer, ByVal sLTDatas As frmMain.sMeasureParams, ByVal MeasPointNum As Integer, Optional ByVal sTempData As String = "") As Boolean

        Dim sTemp As String = ""
        Dim sTime As String = ""
        Dim strCurrTime As String
        Dim sSaveData() As String = Nothing
        Dim sCaptionAndTEGNumber As String = "PANEL" & Format(m_nCh + 1, "00") 'ucDispJIG.convertIncNumberToMatrixValue(m_nCh)
        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        'If m_nCntBlackSaveData(MeasPointNum) = 0 Then
        '    m_TestStartTime(MeasPointNum) = Date.Parse(strCurrTime)
        '    sTemp = "0"
        'Else
        m_Lifetime(MeasPointNum) = Now.Subtract(m_TestStartTime(MeasPointNum))
        sTemp = CStr(Format(m_Lifetime(MeasPointNum).TotalHours, "0.000"))
        'End If

        sTime = CTime.GetCurrentTimeToStringType

        ConvertLTDataToArray_BLACK(sLTDatas, sTemp, sTime, MeasPointNum, sSaveData)

        sTemp = ""

        For i As Integer = 0 To sSaveData.Length - 1
            sTemp = sTemp & sSaveData(i) & ","
        Next

        sTemp = sTemp & sTempData & ","

        sTemp = sTemp.TrimEnd(",")
        Try
            If WriteFile(1, m_SeqInfo.sCommon.saveInfo.strFPath & sCaptionAndTEGNumber & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & "BLACK" & "_P" & MeasPointNum + 1 & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(MeasPointNum).X & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(MeasPointNum).Y & ".csv", sTemp) = False Then Return False

        Catch ex As Exception

        End Try
        'If WriteFile(1, m_sSavePath_LT(MeasPointNum), sTemp) = False Then Return False

        'Try
        '    File.Copy(m_sSavePath_LT(MeasPointNum), m_sSavePath_LT_Backup(MeasPointNum), True)
        '    '여기서 LT데이터 RDP 함수로 전송해서 백업데이터 저장
        'Catch ex As Exception
        '    ' MsgBox("SaveDataPoint" & ex.Message)
        'End Try

        m_nCntBlackSaveData(MeasPointNum) += 1

        Return True
    End Function

    Public Function SaveLTDataPoint(ByVal idx As Integer, ByVal sLTDatas As frmMain.sMeasureParams, ByVal sMeasdata As frmMain.sCellLTMeasureParam, Optional ByVal sTempData As String = "") As Boolean

        Dim sTemp As String = ""
        Dim sTime As String = ""
        Dim strCurrTime As String
        Dim sSaveData() As String = Nothing
        Dim sSpectrumData As String = Nothing

        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        If m_nCntSaveData(idx) = 0 Then
            m_TestStartTime(idx) = Date.Parse(strCurrTime)
            sTemp = "0"
        Else
            m_Lifetime(idx) = Now.Subtract(m_TestStartTime(idx))
            sTemp = CStr(Format(m_Lifetime(idx).TotalHours, "0.000"))
        End If

        sTime = CTime.GetCurrentTimeToStringType

        ConvertLTDataToArray(sLTDatas, sTemp, sTime, 0, sSaveData)

        sTemp = ""

        For i As Integer = 0 To sSaveData.Length - 1
            sTemp = sTemp & sSaveData(i) & ","
        Next

        '2칸 띄어쓰기 필요..
        'sTemp = sTemp & "," & "," ' & "," & ","

        'Spectrum Data Write
        'If sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity Is Nothing = False Then
        '    For IntensityCnt As Integer = 0 To sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity.Length - 1
        '        sSpectrumData = sSpectrumData & "," & Format(sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity(IntensityCnt), "0.000000")
        '    Next
        'End If
        'sSpectrumData = sSpectrumData.Trim(",")

        'sTemp = sTemp & sTempData & sSpectrumData & ","

        sTemp = sTemp.TrimEnd(",")

        If WriteFile(1, m_sSavePath_LT(idx), sTemp) = False Then Return False

        Try
            File.Copy(m_sSavePath_LT(idx), m_sSavePath_LT_Backup(idx), True)
            'If g_SystemOptions.sOptionData.SaveOptions.bUsedBackupPath = True Then
            '    File.Copy(m_sSavePath_LT(idx), m_sSavePath_LT_Mirroring(idx), True) '미러링 추가
            'End If
        Catch ex As Exception
            ' MsgBox("SaveDataPoint" & ex.Message)
        End Try

        m_nCntSaveData(idx) += 1

        Return True
    End Function
    Public Function SaveLTDataPoint(ByVal idx As Integer, ByVal sDatas() As String) As Boolean

        Dim sTemp As String = ""
        Dim strCurrTime As String

        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        If m_nCntSaveData(idx) = 0 Then
            m_TestStartTime(idx) = Date.Parse(strCurrTime)
            sTemp = "0"
        Else
            m_Lifetime(idx) = Now.Subtract(m_TestStartTime(idx))
            sTemp = CStr(Format(m_Lifetime(idx).TotalHours, "0.000"))
        End If

        sTemp = sTemp & "," & CTime.GetCurrentTimeToStringType

        For i As Integer = 0 To sDatas.Length - 1
            sTemp = sTemp & "," & sDatas(i)
        Next

        If WriteFile(1, m_sSavePath_LT(idx), sTemp) = False Then Return False

        Try
            File.Copy(m_sSavePath_LT(idx), m_sSavePath_LT_Backup(idx), True)
        Catch ex As Exception
            ' MsgBox("SaveDataPoint" & ex.Message)
        End Try

        m_nCntSaveData(idx) += 1

        Return True
    End Function

    'CSeqRoutineSG.sMeasuredData 추가 CJS
    Public Function SaveLTDataPoint(ByVal idx As Integer, ByVal sDatas As CSeqRoutineSG.sMeasuredData, ByVal spectrumData() As CDevPR730.tData, ByVal dTemp As Double, ByVal dPercentLumi As Double) As Boolean
        Dim sTemp As String = ""
        Dim strCurrTime As String

        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        If m_nCntSaveData(idx) = 0 Then
            m_TestStartTime(idx) = Date.Parse(strCurrTime)
            sTemp = "0"
        Else
            m_Lifetime(idx) = Now.Subtract(m_TestStartTime(idx))
            sTemp = CStr(m_Lifetime(idx).TotalHours)
        End If

        sTemp = sTemp & "," & CTime.GetCurrentTimeToStringType

        'ELVDD I, ELVSS I, PD I, ELVDD Temp, ELVSS Temp
        sTemp = sTemp & "," & sDatas.dELVDD_V & "," & sDatas.dELVDD_I & "," & sDatas.dELVSS_V & "," & sDatas.dELVDD_I & "," & dTemp & "," & dPercentLumi
        For i As Integer = 0 To spectrumData.Length - 1
            sTemp += sTemp & "," & spectrumData(i).D6.s2YY & "," & spectrumData(i).D2.s2XX & "," & spectrumData(i).D2.s3YY & "," & spectrumData(i).D2.s4ZZ & "," &
                spectrumData(i).D6.s3xx & "," & spectrumData(i).D6.s4yy & "," & spectrumData(i).D6.s5uu & "," & spectrumData(i).D6.s6vv
        Next

        If WriteFile(1, m_sSavePath_LT(idx), sTemp) = False Then Return False

        Try
            File.Copy(m_sSavePath_LT(idx), m_sSavePath_LT_Backup(idx), True)
        Catch ex As Exception
            ' MsgBox("SaveDataPoint" & ex.Message)
        End Try

        m_nCntSaveData(idx) += 1

        Return True

    End Function


    Public Function SaveLTDataPoint(ByVal idx As Integer, ByVal sDatas As CSeqRoutineMcPG.sMeasuredData) As Boolean
        Dim sTemp As String = ""
        Dim strCurrTime As String

        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        'Hour Pass,	Time(MM/DD/YY hh:mm:ss)
        If m_nCntSaveData(idx) = 0 Then
            m_TestStartTime(idx) = Date.Parse(strCurrTime)
            sTemp = "0"
            sTemp = sTemp & "," & CTime.GetCurrentTimeToStringType
        Else
            m_Lifetime(idx) = Now.Subtract(m_TestStartTime(idx))
            sTemp = CStr(m_Lifetime(idx).TotalHours)
            sTemp = sTemp & "," & CTime.GetCurrentTimeToStringType
        End If


        'V1,V2,V3,V4,V5,I1,I2,I3,I4,I5
        For i As Integer = 0 To sDatas.dVoltage.Length - 1
            sTemp = sTemp & "," & sDatas.dVoltage(sDatas.nPowerChNo(i))
        Next

        For i As Integer = 0 To sDatas.dCurrent.Length - 1
            sTemp = sTemp & "," & sDatas.dCurrent(sDatas.nPowerChNo(i))
        Next


        'Temp, Luminance(%), Luminance(cd/m2), X, Y, Z, CIE1931 x, CIE1931 y, CIE 1976 u', CIE 1976 v', Message
        'sTemp = sTemp & "," & 

        If WriteFile(1, m_sSavePath_LT(idx), sTemp) = False Then Return False

        Try
            File.Copy(m_sSavePath_LT(idx), m_sSavePath_LT_Backup(idx), True)
        Catch ex As Exception
            ' MsgBox("SaveDataPoint" & ex.Message)
        End Try

        m_nCntSaveData(idx) += 1

        Return True

    End Function


    Public Function SaveLTDataPoint(ByVal idx As Integer, ByVal sDatas As CDevG4S.sG4SDatas, ByVal ColorData() As CColorAnalyzerLib.CDevCAxxxCMD.sDatas, ByVal dPercentLumi() As Double) As Boolean
        Dim sTemp As String = ""
        Dim strCurrTime As String

        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        'Hour Pass,	Time(MM/DD/YY hh:mm:ss)
        If m_nCntSaveData(idx) = 0 Then
            m_TestStartTime(idx) = Date.Parse(strCurrTime)
            sTemp = "0"
            sTemp = sTemp & "," & CTime.GetCurrentTimeToStringType
        Else
            m_Lifetime(idx) = Now.Subtract(m_TestStartTime(idx))
            sTemp = CStr(m_Lifetime(idx).TotalHours)
            sTemp = sTemp & "," & CTime.GetCurrentTimeToStringType
        End If

        'IDD
        sTemp = sTemp & "," & sDatas.IDD_mA
        'ICI
        sTemp = sTemp & "," & sDatas.ICI_mA
        'IBAT
        sTemp = sTemp & "," & sDatas.IBAT_mA


        'Temp, Luminance(%), Luminance(cd/m2), X, Y, Z, CIE1931 x, CIE1931 y, CIE 1976 u', CIE 1976 v', Message

        For i As Integer = 0 To ColorData.Length - 1
            sTemp = sTemp & "," & ColorData(i).Lv & "," & _
                ColorData(i).sx & "," & ColorData(i).sy & "," & _
                ColorData(i).X & "," & ColorData(i).Y & "," & ColorData(i).Z & "," & _
                dPercentLumi(i)
        Next

        'sTemp = sTemp & "," & 

        '
        If WriteFile(1, m_sSavePath_LT(idx), sTemp) = False Then Return False

        Try
            File.Copy(m_sSavePath_LT(idx), m_sSavePath_LT_Backup(idx), True)
        Catch ex As Exception
            ' MsgBox("SaveDataPoint" & ex.Message)
        End Try

        m_nCntSaveData(idx) += 1

        Return True

    End Function


    Public Function SaveLTDataPoint(ByVal idx As Integer, ByVal sDatas() As CDevPGCommonNode.sMeasuredDatas, ByVal ColorData() As frmMain.sColorAnalyzerData, ByVal dPercentLumi()() As Double, ByVal pt() As ucDispPointSetting.sPoint, ByVal CMDPt() As ucDispPointSetting.sPoint) As Boolean
        Dim sTemp As String = ""
        Dim strCurrTime As String

        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        'Hour Pass,	Time(MM/DD/YY hh:mm:ss)
        If m_nCntSaveData(idx) = 0 Then
            m_TestStartTime(idx) = Date.Parse(strCurrTime)
            sTemp = "0,0"
            sTemp = sTemp & "," & CTime.GetCurrentTimeToStringType
        Else
            m_Lifetime(idx) = Now.Subtract(m_TestStartTime(idx))
            sTemp = CStr(m_Lifetime(idx).TotalHours)
            sTemp = sTemp & "," & CStr(m_Lifetime(idx).TotalMinutes)
            sTemp = sTemp & "," & CTime.GetCurrentTimeToStringType
        End If


        ' Luminance(cd/m2), CIE1931 x, CIE1931 y, CCT, MPCD, u, v, Luminance(%)

        For patternIdx As Integer = 0 To sDatas.Length - 1
            'IDD
            sTemp = sTemp & "," & sDatas(patternIdx).sG4S.IDD_mA
            'ICI
            sTemp = sTemp & "," & sDatas(patternIdx).sG4S.ICI_mA
            'IBAT
            sTemp = sTemp & "," & sDatas(patternIdx).sG4S.IBAT_mA
            For ptIdx As Integer = 0 To ColorData(patternIdx).sCA310.Length - 1
                sTemp = sTemp & "," & Format(ColorData(patternIdx).sCA310(ptIdx).Lv, "0.0000") & "," & _
                                      Format(ColorData(patternIdx).sCA310(ptIdx).sx, "0.0000") & "," & _
                                      Format(ColorData(patternIdx).sCA310(ptIdx).sy, "0.0000") & "," & _
                                      Format(ColorData(patternIdx).sCA310(ptIdx).CCT, "0.0000") & "," & _
                                      Format(ColorData(patternIdx).sCA310(ptIdx).MPCD, "0.0000") & "," & _
                                      Format(ColorData(patternIdx).sCA310(ptIdx).ud, "0.0000") & "," & _
                                     Format(ColorData(patternIdx).sCA310(ptIdx).vd, "0.0000") & "," & _
                                      Format(dPercentLumi(patternIdx)(ptIdx), "0.000") '& "," & _
                'Format(pt(ptIdx).X, "0.000") & "," & _
                'Format(pt(ptIdx).Y, "0.000") & "," & _
                'Format(CMDPt(ptIdx).X, "0.000") & "," & _
                'Format(CMDPt(ptIdx).Y, "0.000")
                'LEX
            Next
        Next

        '
        If WriteFile(1, m_sSavePath_LT(idx), sTemp) = False Then Return False

        Try
            File.Copy(m_sSavePath_LT(idx), m_sSavePath_LT_Backup(idx), True)
        Catch ex As Exception
            ' MsgBox("SaveDataPoint" & ex.Message)
        End Try

        m_nCntSaveData(idx) += 1

        Return True
    End Function

    Public Function SaveLTDataPoint(ByVal idx As Integer, ByVal sDatas As CSeqRoutineMcPG.sMeasuredData, ByVal spectrumData() As CDevPR730.tData, ByVal dTemp As Double, ByVal dPercentLumi As Double) As Boolean
        Dim sTemp As String = ""
        Dim strCurrTime As String

        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        'Hour Pass,	Time(MM/DD/YY hh:mm:ss)
        If m_nCntSaveData(idx) = 0 Then
            m_TestStartTime(idx) = Date.Parse(strCurrTime)
            sTemp = "0"
            sTemp = sTemp & "," & CTime.GetCurrentTimeToStringType
        Else
            m_Lifetime(idx) = Now.Subtract(m_TestStartTime(idx))
            sTemp = CStr(m_Lifetime(idx).TotalHours)
            sTemp = sTemp & "," & CTime.GetCurrentTimeToStringType
        End If

        'V1,V2,V3,V4,V5,I1,I2,I3,I4,I5
        For i As Integer = 0 To sDatas.dVoltage.Length - 1
            sTemp = sTemp & "," & sDatas.dVoltage(sDatas.nPowerChNo(i))
        Next

        For i As Integer = 0 To sDatas.dCurrent.Length - 1
            sTemp = sTemp & "," & sDatas.dCurrent(sDatas.nPowerChNo(i))
        Next

        'Temp, Luminance(%), Luminance(cd/m2), X, Y, Z, CIE1931 x, CIE1931 y, CIE 1976 u', CIE 1976 v', Message

        sTemp = sTemp & "," & dTemp & "," & dPercentLumi.ToString

        For i As Integer = 0 To spectrumData.Length - 1
            sTemp = sTemp & "," & spectrumData(i).D6.s2YY & "," & _
                spectrumData(i).D2.s2XX & "," & spectrumData(i).D2.s3YY & "," & spectrumData(i).D2.s4ZZ & "," & _
                spectrumData(i).D6.s3xx & "," & spectrumData(i).D6.s4yy & "," & spectrumData(i).D6.s5uu & "," & spectrumData(i).D6.s6vv & "," & _
                spectrumData(i).D6.Comn.striOMeasQCode
        Next

        'sTemp = sTemp & "," & 

        '
        If WriteFile(1, m_sSavePath_LT(idx), sTemp) = False Then Return False

        Try
            File.Copy(m_sSavePath_LT(idx), m_sSavePath_LT_Backup(idx), True)
        Catch ex As Exception
            ' MsgBox("SaveDataPoint" & ex.Message)
        End Try

        m_nCntSaveData(idx) += 1

        Return True

    End Function

    Public Function SaveDataPoint(ByVal idx As Integer, ByVal dDatas() As Double) As Boolean

        Dim sTemp As String = ""

        Dim strCurrTime As String

        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        If m_nCntSaveData(idx) = 0 Then
            m_TestStartTime(idx) = Date.Parse(strCurrTime)
            sTemp = "0"
            sTemp = sTemp & "," & CTime.GetCurrentTimeToStringType
        Else
            m_Lifetime(idx) = Now.Subtract(m_TestStartTime(idx))
            sTemp = CStr(m_Lifetime(idx).TotalHours)
            sTemp = sTemp & "," & CTime.GetCurrentTimeToStringType
        End If

        For i As Integer = 0 To dDatas.Length - 1
            sTemp = sTemp & "," & CStr(dDatas(i))
        Next

        If WriteFile(1, m_sSavePath_LT(idx), sTemp) = False Then Return False

        Try
            File.Copy(m_sSavePath_LT(idx), m_sSavePath_LT_Backup(idx), True)
        Catch ex As Exception
            '  MsgBox("SaveDataPoint" & ex.Message)
        End Try

        Return True
    End Function

    Public Function SaveDataIVL(ByVal rcpInfo As ucSequenceBuilder.sRecipeInfo, ByVal sData As frmMain.sCellIVLMeasureParams) As Boolean
        Dim sTemp() As String
        Dim cntLine As Integer = 0
        Dim cntSpec As Integer = 0
        Dim idx As Integer = rcpInfo.recipeIndex
        Dim ChkSpectrum As Boolean = False
        Dim sSaveData() As String = Nothing

        ReDim sTemp(sData.sIVLMeasure(0).Length - 1)

        For sweepPoint As Integer = 0 To sData.sIVLMeasure(0).Length - 1

            For colorIdx As Integer = 0 To sData.sIVLMeasure.Length - 1

                If rcpInfo.nMode = ucSequenceBuilder.eRcpMode.eCell_IVL Or rcpInfo.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then

                    ConvertIVLDataToArray(sData.sIVLMeasure(colorIdx)(sweepPoint), sweepPoint, sSaveData, ChkSpectrum)

                    For i As Integer = 0 To sSaveData.Length - 1
                        sTemp(cntLine) = sTemp(cntLine) & "," & sSaveData(i)
                    Next

                    sTemp(cntLine) = sTemp(cntLine).TrimStart(",")

                ElseIf rcpInfo.nMode = ucSequenceBuilder.eRcpMode.eViewingAngle Then
                    ' ''If colorIdx = 0 Then
                    ' ''    sTemp(cntLine) = sweepPoint + 1 & "," & .nMeasMode.ToString & "," & .sColorName & "," & .dArea_cm & "," & .dTemperature
                    ' ''End If

                    ' ''sTemp(cntLine) = sTemp(cntLine) & "," & .dVoltage & _
                    ' ''                                  "," & .dCurrent & _
                    ' ''                                  "," & .dAngle & _
                    ' ''                                  "," & .dCdm2 & _
                    ' ''                                  "," & Format(.dCIEx, "0.0000") & _
                    ' ''                                  "," & Format(.dCIEy, "0.0000") & _
                    ' ''                                  "," & .dCCT & _
                    ' ''                                  "," & .dLumi_Percent & _
                    ' ''                                  "," & Format(.dDelta_udvd, "0.0000") & _
                    ' ''                                  "," & Format(.dCIEu, "0.0000") & _
                    ' ''                                  "," & Format(.dCIEv, "0.0000") & _
                    ' ''                                  "," & .dCdA & _
                    ' ''                                  "," & .dJ & _
                    ' ''                                  "," & .dAbs_J & _
                    ' ''                                  "," & .dQE
                End If

            Next
            cntLine += 1
        Next

        '  ReDim Preserve sTemp(cntLine - 1)

        If WriteFile(iResultDataNumber, m_sSavePath_Sweep(idx), sTemp) = False Then Return False

        Try
            File.Copy(m_sSavePath_Sweep(idx), m_sSavePath_Sweep_Backup(idx), True)
        Catch ex As Exception

        End Try

        Return True
    End Function
    Public Function SaveDataIVLExcel(ByVal rcpInfo As ucSequenceBuilder.sRecipeInfo, ByVal sData As frmMain.sCellIVLMeasureParams, ByVal SpectrumBiasList()() As Double, ByVal bColorAnalysis As Boolean) As Boolean
        Dim cntSpec As Integer = 0
        Dim idx As Integer = rcpInfo.recipeIndex

        cExcelCVT = New CExcelConverter

        '1. Excel Connect
        If cExcelCVT.connectExcel() = False Then
            Return False
        End If


        '2. Data Insert
        '2-1 IVL Data Insert
        'Sweep Point 갯수 만큼 배열 초기화
        Dim sIVLData(sData.sIVLMeasure(0).Length - 1, g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems.Length - 1) As Double
        Dim sIVLDataHeader(0, g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems.Length - 1) As String
        Dim sIVLColorAnalysis(0, 1) As String

        Dim sSaveData() As String = Nothing

        '=========================== IVL ==============================
        'IVL Header 저장
        For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems.Length - 1
            sIVLDataHeader(0, i) = "[" & g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItemName(i) & "]"
        Next
        cExcelCVT.SheetSave(1, 1, 1, sIVLDataHeader)

        'IVL Data 저장
        For sweepPoint As Integer = 0 To sData.sIVLMeasure(0).Length - 1
            ConvertIVLDataToArray(sData.sIVLMeasure(0)(sweepPoint), sweepPoint, sSaveData, False)
            For nCnt As Integer = 0 To sSaveData.Length - 1
                sIVLData(sweepPoint, nCnt) = sSaveData(nCnt)
            Next
        Next
        cExcelCVT.SheetSave(1, 1, 2, sIVLData)

        '=============================================================================


        '2-2 Spectrum Data & Normal Spectrum Data Insert
        If rcpInfo.sIVLSweepInfo.sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
            If sData.sArrySpectrometer Is Nothing Then Return False
            If sData.sNormalSpectrometer Is Nothing Then Return False
            If SpectrumBiasList Is Nothing Then Return False

            'Spectrum Point 갯수 만큼 배열 초기화
            Dim sIVLSpectrumData(sData.sArrySpectrometer(0)(0).D5.i3nm.Length - 1, SpectrumBiasList(0).Length) As Double
            Dim sIVLNormalSpectrumData(sData.sArrySpectrometer(0)(0).D5.i3nm.Length - 1, SpectrumBiasList(0).Length) As Double
            Dim sIVLSpectrumDataHeader(0, SpectrumBiasList(0).Length) As String

            '=========================== Spectrum ==============================
            'Spectrum Header 저장
            sIVLSpectrumDataHeader(0, 0) = "Wavelength | Bias"
            For i As Integer = 0 To SpectrumBiasList(0).Length - 1
                sIVLSpectrumDataHeader(0, i + 1) = "[" & SpectrumBiasList(0)(i) & "]"
            Next
            cExcelCVT.SheetSave(2, 1, 1, sIVLSpectrumDataHeader)

            'Spectrum Data 저장
            For i As Integer = 0 To sData.sArrySpectrometer(0)(0).D5.s4Intensity.Length - 1
                For sweepPoint As Integer = 0 To sData.sArrySpectrometer(0).Length - 1
                    If sweepPoint = 0 Then
                        sIVLSpectrumData(i, sweepPoint) = sData.sArrySpectrometer(0)(sweepPoint).D5.i3nm(i)
                    End If
                    sIVLSpectrumData(i, sweepPoint + 1) = sData.sArrySpectrometer(0)(sweepPoint).D5.s4Intensity(i)
                Next
            Next
            cExcelCVT.SheetSave(2, 1, 2, sIVLSpectrumData)
            '========================================================================



            '===========================Normal Spectrum ============================
            'Spectrum Header 저장
            cExcelCVT.SheetSave(3, 1, 1, sIVLSpectrumDataHeader)

            'Normal Spectrum Data 저장
            For i As Integer = 0 To sData.sArrySpectrometer(0)(0).D5.s4Intensity.Length - 1
                For sweepPoint As Integer = 0 To sData.sArrySpectrometer(0).Length - 1
                    If sweepPoint = 0 Then
                        sIVLNormalSpectrumData(i, sweepPoint) = sData.sArrySpectrometer(0)(sweepPoint).D5.i3nm(i)
                    End If
                    sIVLNormalSpectrumData(i, sweepPoint + 1) = sData.sNormalSpectrometer(sweepPoint)(i)
                Next
            Next
            cExcelCVT.SheetSave(3, 1, 2, sIVLNormalSpectrumData)
            '========================================================================



            '======================ColorName & Real Current 저장====================
            If bColorAnalysis = True Then
                sIVLColorAnalysis(0, 0) = sData.sIVLMeasure(0)(sData.sIVLMeasure.Length + 1).sMeteralValue.sColorName
                sIVLColorAnalysis(0, 1) = sData.sIVLMeasure(0)(sData.sIVLMeasure.Length + 1).sMeteralValue.dRealCurrent
                cExcelCVT.SheetSave(1, g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems.Length + 1, sData.sIVLMeasure(0).Length + 1, sIVLColorAnalysis)
            End If
            '==========================================================================

        End If

        '3. Sheet1 번으로 포커스
        cExcelCVT.SheetSelect(1)

        '4. SaveAs
        cExcelCVT.saveAsWorkbook(m_sSavePath_Sweep_Backup(idx))

        '5. Excel Disconnect
        cExcelCVT.disconnectExcel()

        Return True
    End Function
    Public Overloads Function SaveIVLSpectrumData(ByVal recipe As ucSequenceBuilder.sRecipeInfo, ByVal sData As frmMain.sCellIVLMeasureParams, ByVal SpectrumBiasList()() As Double) As Boolean
        Dim sTemp(sData.sArrySpectrometer(0)(0).D5.i3nm.Length + 3) As String
        Dim cntLine As Integer = 0
        Dim nCnt As Integer
        Dim idx As Integer = recipe.recipeIndex

        If sData.sArrySpectrometer Is Nothing Then Return True
        If SpectrumBiasList Is Nothing Then Return False

        sTemp(cntLine) = sreportTitle_SpectrumData & g_strFileVer : cntLine += 1
        sTemp(cntLine) = "" : cntLine += 1

        'If recipe.nMode = ucSequenceBuilder.eRcpMode.eCell_IVL Then
        '    For colorIdx As Integer = 0 To SpectrumBiasList.Length - 1
        '        For nCnt = 0 To SpectrumBiasList(colorIdx).Length - 1
        '            sTemp(cntLine) = sTemp(cntLine) & "," & "[" & sData.sIVLMeasure(colorIdx)(nCnt).sColorName & "]"
        '        Next
        '    Next
        'Else
        '    sTemp(cntLine) = ""
        'End If

        'cntLine += 1

        If recipe.nMode = ucSequenceBuilder.eRcpMode.eCell_IVL Then
            sTemp(cntLine) = "Wavelength | Bias"
            '   idx = recipe.recipeIndex_IVL
        ElseIf recipe.nMode = ucSequenceBuilder.eRcpMode.eViewingAngle Then
            sTemp(cntLine) = "Wavelength | Angle"
            ' idx = recipe.recipeIndex_ViewingAngle
        End If


        For colorIdx As Integer = 0 To SpectrumBiasList.Length - 1
            For nCnt = 0 To SpectrumBiasList(colorIdx).Length - 1
                'If recipe.nMode = ucSequenceBuilder.eRcpMode.eCell_IVL Then
                '   sTemp(cntLine) = sTemp(cntLine) & "," & "[" & sData.sIVLMeasure(colorIdx)(nCnt).sColorName & "]"
                sTemp(cntLine) = sTemp(cntLine) & "," & "[" & SpectrumBiasList(colorIdx)(nCnt) & "]"
                '  Else
                '  sTemp(cntLine) = sTemp(cntLine) & "," & "[" & SpectrumBiasList(colorIdx)(nCnt) & "]"
                ' End If
            Next
        Next

        cntLine += 1

        For i As Integer = 0 To sData.sArrySpectrometer(0)(0).D5.s4Intensity.Length - 1

            For colorIdx As Integer = 0 To sData.sArrySpectrometer.Length - 1

                For sweepPoint As Integer = 0 To sData.sArrySpectrometer(colorIdx).Length - 1

                    If sweepPoint = 0 And colorIdx = 0 Then
                        sTemp(cntLine) = sData.sArrySpectrometer(colorIdx)(sweepPoint).D5.i3nm(i)
                    End If

                    sTemp(cntLine) = sTemp(cntLine) & "," & sData.sArrySpectrometer(colorIdx)(sweepPoint).D5.s4Intensity(i)
                Next

            Next
            cntLine += 1
        Next


        ReDim Preserve sTemp(cntLine - 1)

        If WriteFile(iResultDataNumber, m_sSavePath_Sweep_SpectrumData(idx), sTemp) = False Then Return False

        Try
            File.Copy(m_sSavePath_Sweep_SpectrumData(idx), m_sSavePath_Sweep_SpectrumData_Backup(idx), True)
        Catch ex As Exception

        End Try

        Return True
        'Dim sTemp(sData.sSpectrometer(0).D5.i3nm.Length + 2) As String
        'Dim cntLine As Integer = 0
        'Dim idx As Integer

        'If sData.sSpectrometer Is Nothing Then Return True
        'If SpectrumBiasList Is Nothing Then Return False

        'sTemp(cntLine) = sreportTitle_SpectrumData & g_strFileVer : cntLine += 1
        'sTemp(cntLine) = "" : cntLine += 1

        'If recipe.nMode = ucSequenceBuilder.eRcpMode.eCell_IVL Then
        '    sTemp(cntLine) = "Wavelength | Bias"
        '    idx = recipe.recipeIndex_IVL
        'ElseIf recipe.nMode = ucSequenceBuilder.eRcpMode.eViewingAngle Then
        '    sTemp(cntLine) = "Wavelength | Angle"
        '    idx = recipe.recipeIndex_ViewingAngle
        'End If


        'For nCnt As Integer = 0 To SpectrumBiasList.Length - 1
        '    sTemp(cntLine) = sTemp(cntLine) & "," & "[" & SpectrumBiasList(nCnt) & "]"
        'Next
        'cntLine += 1


        'For i As Integer = 0 To sData.sSpectrometer(0).D5.s4Intensity.Length - 1
        '    For sweepPoint As Integer = 0 To sData.sSpectrometer.Length - 1

        '        If sweepPoint = 0 Then
        '            sTemp(cntLine) = sData.sSpectrometer(sweepPoint).D5.i3nm(i)
        '        End If

        '        sTemp(cntLine) = sTemp(cntLine) & "," & sData.sSpectrometer(sweepPoint).D5.s4Intensity(i)
        '    Next

        '    cntLine += 1
        'Next


        'ReDim Preserve sTemp(cntLine - 1)

        'If WriteFile(iResultDataNumber, m_sSavePath_SpectrumData(idx), sTemp) = False Then Return False

        'Try
        '    File.Copy(m_sSavePath_SpectrumData(idx), m_sSavePath_SpectrumData_Backup(idx), True)
        'Catch ex As Exception

        'End Try

        'Return True
    End Function
    'CIM DATA
    'Public Function SaveDataPointCIM_IVL(ByVal idx As Integer, ByVal sData As frmMain.sCellIVLMeasureParams) As Boolean
    '    Dim sTemp() As String
    '    Dim cntLine As Integer = 0
    '    Dim cntSpec As Integer = 0

    '    Dim sSaveData() As String = Nothing

    '    ReDim sTemp(sData.sIVLMeasure(0).Length - 1)

    '    For sweepPoint As Integer = 0 To sData.sIVLMeasure(0).Length - 1

    '        For colorIdx As Integer = 0 To sData.sIVLMeasure.Length - 1

    '            ConvertIVLDataToArray(sData.sIVLMeasure(colorIdx)(sweepPoint), sweepPoint, sSaveData)

    '            For i As Integer = 0 To sSaveData.Length - 1
    '                sTemp(cntLine) = sTemp(cntLine) & "     " & sSaveData(i)
    '            Next

    '            sTemp(cntLine) = "DATA MEASURE     " & m_nCntSaveData(idx) & "     *     *     *     *     *     *     *     *     *     *     *     " & sTemp(cntLine).TrimStart(" ")

    '            ' ''If colorIdx = 0 Then
    '            ' ''    sTemp(cntLine) = sweepPoint + 1 & "," & .nMeasMode.ToString & "," & .sColorName & "," & .dArea_cm & "," & .dTemperature
    '            ' ''End If

    '            ' ''sTemp(cntLine) = sTemp(cntLine) & "," & .dVoltage & _
    '            ' ''                                  "," & .dCurrent & _
    '            ' ''                                  "," & .dAngle & _
    '            ' ''                                  "," & .dCdm2 & _
    '            ' ''                                  "," & Format(.dCIEx, "0.0000") & _
    '            ' ''                                  "," & Format(.dCIEy, "0.0000") & _
    '            ' ''                                  "," & .dCCT & _
    '            ' ''                                  "," & .dLumi_Percent & _
    '            ' ''                                  "," & Format(.dDelta_udvd, "0.0000") & _
    '            ' ''                                  "," & Format(.dCIEu, "0.0000") & _
    '            ' ''                                  "," & Format(.dCIEv, "0.0000") & _
    '            ' ''                                  "," & .dCdA & _
    '            ' ''                                  "," & .dJ & _
    '            ' ''                                  "," & .dAbs_J & _
    '            ' ''                                  "," & .dQE

    '        Next
    '        cntLine += 1
    '        m_nCntSaveData(idx) += 1
    '    Next
    '    ' m_nCntSaveData(idx) += 1

    '    '  ReDim Preserve sTemp(cntLine - 1)
    '    '20161011 yjs
    '    'SaveDataPointCIM(idx, sData.sIVLMeasure.Clone)
    '    'Dim sTemp As String = ""
    '    'Dim sHourPass As String = ""

    '    'For cnt As Integer = 0 To sDatas.Length - 1
    '    '    Select Case g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems(cnt)
    '    '        'Case frmOptionWindow.eIVLDataIndex.e
    '    '        '    Dim arr() As String = sDatas(cnt).ToString.Split(" ")
    '    '        '    sDatas(cnt) = arr(0) & arr(1)

    '    '    End Select

    '    '    sTemp += sDatas(cnt)

    '    '    If cnt <> sDatas.Length - 1 Then
    '    '        sTemp = sTemp & " "
    '    '    End If
    '    'Next

    '    'If m_SaveAppendState <> eSaveApeenState.eNone Then
    '    '    If g_sSystemOption.sOutputParamEdit.ReportMessageInfoForSWAppend = True Then
    '    '        sTemp = sTemp & "," & sSaveAppendState(m_SaveAppendState)
    '    '    End If
    '    '    m_SaveAppendState = eSaveApeenState.eNone
    '    'End If

    '    'sTemp = "DATA MEASURE " & m_nCntSaveData(idx) + 1 & " * * * * * * * * * * * " & sTemp

    '    If WriteFile(iResultDataNumber + 1, m_sSavePath_RDP_IVL(idx), sTemp) = False Then Return False '경로
    '    Return True
    'End Function
    'Public Function SaveDataPointCIM_Spectrum(ByVal recipe As ucSequenceBuilder.sRecipeInfo, ByVal sData As frmMain.sCellIVLMeasureParams, ByVal SpectrumBiasList()() As Double, ByVal idx As Integer) As Boolean
    '    Try

    '        Dim sTemp(sData.sArrySpectrometer(0)(0).D5.i3nm.Length + 3) As String
    '        Dim sTemp2(sData.sArrySpectrometer(0)(0).D5.i3nm.Length + 3) As String
    '        Dim cntLine As Integer = 0
    '        Dim cnt As Integer = 0
    '        Dim sCnt As Integer = 1  'meas cnt 1부터
    '        If sData.sArrySpectrometer Is Nothing Then Return True
    '        If SpectrumBiasList Is Nothing Then Return False

    '        For i As Integer = 0 To sData.sArrySpectrometer(0)(0).D5.s4Intensity.Length - 1
    '            For colorIdx As Integer = 0 To sData.sArrySpectrometer.Length - 1

    '                For sweepPoint As Integer = 0 To sData.sArrySpectrometer(colorIdx).Length - 1
    '                    '"DATA MEASURE     " & sCnt & "     *     *     *     *     *     *     *     *     *     *     *     " &

    '                    If sweepPoint = 0 And colorIdx = 0 Then
    '                        sTemp(cntLine) = sData.sArrySpectrometer(colorIdx)(sweepPoint).D5.i3nm(i)
    '                        sTemp2(cntLine) = sData.sArrySpectrometer(colorIdx)(sweepPoint).D5.i3nm(i)
    '                    End If

    '                    ' "DATA MEASURE     " & sCnt & "     *     *     *     *     *     *     *     *     *     *     *     " &
    '                    sTemp2(cntLine) = sTemp2(cntLine) & "    " & sData.sArrySpectrometer(colorIdx)(sweepPoint).D5.s4Intensity(i)
    '                    '"DATA MEASURE     " & m_nCntSaveData(cnt) + sCnt & "     *     *     *     *     *     *     *     *     *     *     *     " & sTemp(cntLine) & " " &

    '                Next
    '                sTemp(cntLine) = "DATA MEASURE     " & sCnt & "     *     *     *     *     *     *     *     *     *     *     *     " & sTemp2(cntLine)
    '                ' sCnt += 1
    '                ' sCnt += 1
    '            Next

    '            cntLine += 1
    '            sCnt += 1
    '        Next

    '        ReDim Preserve sTemp(cntLine - 1)
    '        If WriteFile(iResultDataNumber + 1, m_sSavePath_RDP_IVL_SPectrum(idx), sTemp) = False Then Return False
    '        Try
    '            'File.Copy(m_sSavePath_Sweep_SpectrumData(idx), m_sSavePath_Sweep_SpectrumData_Backup(idx), True)
    '        Catch ex As Exception

    '        End Try

    '        Return True
    '    Catch ex As Exception

    '    End Try
    'End Function
    'Public Function SaveDataPointCIM_LT(ByVal idx As Integer, ByVal sLTDatas As frmMain.sMeasureParams, Optional ByVal sTempData As String = "") As Boolean
    '    Dim sTemp As String = ""
    '    Dim sHourPass As String = ""
    '    Dim sTime As String = ""
    '    Dim strCurrTime As String
    '    Dim sSaveData() As String = Nothing
    '    'For cnt As Integer = 0 To sDatas.Length - 1
    '    '    Select Case g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems(cnt)
    '    '        'Case frmOptionWindow.eIVLDataIndex.e
    '    '        '    Dim arr() As String = sDatas(cnt).ToString.Split(" ")
    '    '        '    sDatas(cnt) = arr(0) & arr(1)

    '    '    End Select

    '    '    sTemp += sDatas(cnt)

    '    '    If cnt <> sDatas.Length - 1 Then
    '    '        sTemp = sTemp & " "
    '    '    End If
    '    'Next

    '    'If m_SaveAppendState <> eSaveApeenState.eNone Then
    '    '    If g_sSystemOption.sOutputParamEdit.ReportMessageInfoForSWAppend = True Then
    '    '        sTemp = sTemp & "," & sSaveAppendState(m_SaveAppendState)
    '    '    End If
    '    '    m_SaveAppendState = eSaveApeenState.eNone
    '    'End If
    '    If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

    '    strCurrTime = CTime.GetCurrentTimeToStringType

    '    If m_nCntSaveData(idx) = 0 Then
    '        m_TestStartTime(idx) = Date.Parse(strCurrTime)
    '        sTemp = "0"
    '    Else
    '        m_Lifetime(idx) = Now.Subtract(m_TestStartTime(idx))
    '        sTemp = CStr(Format(m_Lifetime(idx).TotalHours, "0.000"))
    '    End If

    '    sTime = CTime.GetCurrentTimeToStringType

    '    ConvertLTDataToArray(sLTDatas, sTemp, sTime, sSaveData)

    '    sTemp = ""

    '    For i As Integer = 0 To sSaveData.Length - 1
    '        sTemp = sTemp & sSaveData(i) & ","
    '    Next

    '    sTemp = sTemp & sTempData & ","

    '    sTemp = sTemp.TrimEnd(",")
    '    sTemp = "DATA MEASURE     " & m_nCntSaveData(idx) & "     *     *     *     *     *     *     *     *     *     *     *     " & sTemp

    '    If WriteFile(iResultDataNumber + 1, m_sSavePath_RDP_LT(idx), sTemp) = False Then Return False '경로
    '    Return True
    'End Function
    'Public Function SaveDataPointCIM_LTSpectrum(ByVal idx As Integer, ByVal sRecipeInfos As ucSequenceBuilder.sRecipeInfo, ByVal sMeasdata As frmMain.sCellLTMeasureParam) As Boolean
    '    Dim sTemp(3) As String
    '    Dim cntLine As Integer = 0
    '    Dim sHourPass As String = Nothing
    '    Dim sSeparator As String = ","
    '    Dim sCnt As Integer = 1  'meas cnt 1부터

    '    If m_nCntSaveData(idx) = 1 Then
    '        For i As Integer = 0 To sMeasdata.opticalData.sSpectrometerData.D5.i3nm.Length - 1
    '            sTemp(cntLine) = sTemp(cntLine) & "," & sMeasdata.opticalData.sSpectrometerData.D5.i3nm(i)
    '        Next
    '        cntLine += 1
    '    End If
    '    If m_nCntSaveData(idx) = 1 Then
    '        sHourPass = 0
    '    Else
    '        m_Lifetime(idx) = Now.Subtract(m_TestStartTime(idx))
    '        sHourPass = CStr(Format(m_Lifetime(idx).TotalHours, "0.000"))
    '    End If

    '    ' If g_SystemOptions.sOptionData.SaveOptions.bDataFormatCompanyMcsciecne = True Then
    '    'sTemp(cntLine) = sHourPass & "," & CTime.GetCurrentTimeToStringType
    '    ' sTemp(cntLine) = sTemp(cntLine) & "," & sMeasdata.opticalData.sSpectrometerData.D6.s2YY & "," & Format(sMeasdata.opticalData.dLumi_Percent, "0.0")
    '    ' Else
    '    sTemp(cntLine) = sHourPass & "," & Format(sMeasdata.opticalData.dLumi_Percent, "0.00")  ' & "," & CTime.GetCurrentTimeToStringType
    '    sTemp(cntLine) = sTemp(cntLine) & "," & Format(sMeasdata.eletricalData.dVoltage, "0.00") & "," & CTime.GetCurrentTimeToStringType
    '    '  End If


    '    For nIntensityCnt As Integer = 0 To sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity.Length - 1
    '        sTemp(cntLine) = "DATA MEASURE     " & m_nCntSaveData(idx) + 1 & "     *     *     *     *     *     *     *     *     *     *     *     " & sTemp(cntLine) & sTemp(cntLine) & "," & sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity(nIntensityCnt)
    '    Next
    '    cntLine += 1
    '    'sTemp = "DATA MEASURE " & m_nCntSaveData(idx) + 1 & " * * * * * * * * * * * " & sTemp
    '    ReDim Preserve sTemp(cntLine - 1)
    '    If WriteFile(iResultDataNumber + 1, m_sSavePath_RDP_LT_Spectrum(idx), sTemp) = False Then Return False

    '    Try
    '    Catch ex As Exception

    '    End Try

    '    Return True
    'End Function

    'Public Overloads Function SaveLTAngleSpectrumDataPoint(ByVal sRecipeInfos As ucSequenceBuilder.sRecipeInfo, ByVal sMeasdata() As frmMain.sOpticalMeasData, ByVal dSweepValue() As Double, ByVal type As ucDispRcpCommon.eSampleColor) As Boolean
    '    Dim sTemp(sMeasdata.Length) As String
    '    Dim cntLine As Integer = 0
    '    Dim sHourPass As String = Nothing
    '    Dim idx As Integer = sRecipeInfos.recipeIndex_LifeTime
    '    Dim sSeparator As String = ","


    '    If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

    '    If m_nCntSaveData(idx) = 1 Then
    '        ReDim sTemp(sTemp.Length + 1)
    '        sTemp(cntLine) = sreportTitle_SpectrumData & g_strFileVer : cntLine += 1
    '        sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

    '        sTemp(cntLine) = "Filename : " & sSeparator & m_SeqInfo.sCommon.saveInfo.strOnlyFName : cntLine += 1

    '        Dim measItem() As ucDispRcpCommon.eSampleColor = CSeqProcessor.GetMeasColorItemInfoFromLTRcp(sRecipeInfos.sLifetimeInfo)
    '        sTemp(cntLine) = "Color : " & sSeparator
    '        For i As Integer = 0 To measItem.Length - 1
    '            sTemp(cntLine) = sTemp(cntLine) & measItem(i).ToString & sSeparator
    '        Next
    '        cntLine += 1
    '        sTemp(cntLine) = "" : cntLine += 1 '구분용 공란


    '        sTemp(cntLine) = "[Hour Pass(hrs)], [Time(MM/DD/YY hh:mm:ss)], [Color_Angle(')], [Luminance(Cd/m^2)], [Luminance(%)]"

    '        For i As Integer = 0 To sMeasdata(0).sSpectrometerData.D5.i3nm.Length - 1
    '            sTemp(cntLine) = sTemp(cntLine) & "," & "[" & sMeasdata(0).sSpectrometerData.D5.i3nm(i) & "]"
    '            ' sTemp(cntLine) = sTemp(cntLine) & "," & spectrumData.D5.i3nm(i)  '헤더 [380] -> 380 변경
    '        Next
    '        cntLine += 1
    '    End If

    '    If m_nCntSaveData(idx) = 1 Then
    '        sHourPass = 0
    '    Else
    '        m_Lifetime(idx) = Now.Subtract(m_TestStartTime(idx))
    '        sHourPass = CStr(Format(m_Lifetime(idx).TotalHours, "0.000"))
    '    End If

    '    Dim sCaption_Color() As String = New String() {"R", "G", "B", "Mixed Color"}

    '    For i As Integer = 0 To sMeasdata.Length - 1
    '        If i = 0 Then
    '            sTemp(cntLine) = sHourPass & "," & CTime.GetCurrentTimeToStringType
    '        Else
    '            sTemp(cntLine) = ",," '& "Wad_" & dSweepValue(i) & "," & sMeasdata(i).sSpectrometerData.D6.s2YY & "," & sMeasdata(i).dLumi_Percent
    '        End If

    '        sTemp(cntLine) = sTemp(cntLine) & "," & sCaption_Color(Type) & "_" & dSweepValue(i) & "'" & "," & sMeasdata(i).sSpectrometerData.D6.s2YY & "," & sMeasdata(i).dLumi_Percent

    '        For k As Integer = 0 To sMeasdata(i).sSpectrometerData.D5.s4Intensity.Length - 1
    '            sTemp(cntLine) = sTemp(cntLine) & "," & sMeasdata(i).sSpectrometerData.D5.s4Intensity(k)
    '        Next
    '        cntLine += 1
    '    Next


    '    ReDim Preserve sTemp(cntLine - 1)

    '    If WriteFile(iResultDataNumber, m_sSavePath_SpectrumData(idx), sTemp) = False Then Return False

    '    Try
    '        File.Copy(m_sSavePath_SpectrumData(idx), m_sSavePath_SpectrumData_Backup(idx), True)
    '    Catch ex As Exception

    '    End Try
    '    '   End If

    '    Return True
    'End Function

    Public Overloads Function SaveLTAngleSpectrumDataPoint(ByVal idx As Integer, ByVal sRecipeInfos As ucSequenceBuilder.sRecipeInfo, ByVal sMeasdata As frmMain.sCellLTMeasureParam, ByVal nNumMeasPoint As Integer) As Boolean
        Dim sTemp(3) As String
        Dim cntLine As Integer = 0
        Dim sHourPass As String = Nothing
        '   Dim idx As Integer = sRecipeInfos.recipeIndex_LifeTime
        Dim sSeparator As String = ","

        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        If m_nCntSaveData(nNumMeasPoint) = 1 Then
            ReDim sTemp(sTemp.Length + 4)
            sTemp(cntLine) = sreportTitle_SpectrumData & g_strFileVer : cntLine += 1
            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

            sTemp(cntLine) = "Filename : " & sSeparator & m_SeqInfo.sCommon.saveInfo.strOnlyFName : cntLine += 1

            'Dim measItem() As ucSampleInfos.eSampleColor = CSeqProcessor.GetMeasColorItemInfoFromLTRcp(sRecipeInfos.sLifetimeInfo)
            'sTemp(cntLine) = "Color : " & sSeparator
            'For i As Integer = 0 To measItem.Length - 1
            '    sTemp(cntLine) = sTemp(cntLine) & measItem(i).ToString & sSeparator
            'Next
            'cntLine += 1
            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

            sTemp(cntLine) = "[Hour Pass(hrs)], [Time(MM/DD/YY hh:mm:ss)], [Luminance(Cd/m^2)], [Luminance(%)]"

            For i As Integer = 0 To sMeasdata.opticalData.sSpectrometerData.D5.i3nm.Length - 1
                sTemp(cntLine) = sTemp(cntLine) & "," & "[" & sMeasdata.opticalData.sSpectrometerData.D5.i3nm(i) & "]"
                ' sTemp(cntLine) = sTemp(cntLine) & "," & spectrumData.D5.i3nm(i)  '헤더 [380] -> 380 변경
            Next
            cntLine += 1
        End If


        If m_nCntSaveData(nNumMeasPoint) = 1 Then
            sHourPass = 0
        Else
            m_Lifetime(nNumMeasPoint) = Now.Subtract(m_TestStartTime(nNumMeasPoint))
            sHourPass = CStr(Format(m_Lifetime(nNumMeasPoint).TotalHours, "0.000"))
        End If

        sTemp(cntLine) = sHourPass & "," & CTime.GetCurrentTimeToStringType

        ' sTemp(cntLine) = "," '& "Wad_" & dSweepValue(i) & "," & sMeasdata(i).sSpectrometerData.D6.s2YY & "," & sMeasdata(i).dLumi_Percent


        sTemp(cntLine) = sTemp(cntLine) & "," & sMeasdata.opticalData.sSpectrometerData.D6.s2YY & "," & Format(sMeasdata.opticalData.dLumi_Percent, "0.0")

        For nIntensityCnt As Integer = 0 To sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity.Length - 1
            sTemp(cntLine) = sTemp(cntLine) & "," & sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity(nIntensityCnt)
        Next
        cntLine += 1

        ReDim Preserve sTemp(cntLine - 1)

        Try
            If WriteFile(1, m_sSavePath_LT_SpectrumData(nNumMeasPoint), sTemp) = False Then Return False
        Catch ex As Exception

        End Try


        Try
            File.Copy(m_sSavePath_LT_SpectrumData(nNumMeasPoint), m_sSavePath_LT_SpectrumData_Backup(nNumMeasPoint), True)
        Catch ex As Exception

        End Try
        '   End If

        Return True
    End Function


    Public Overloads Function SaveLTAngleSpectrumDataPoint_RED(ByVal idx As Integer, ByVal sMeasdata As frmMain.sCellLTMeasureParam, ByVal nNumMeasPoint As Integer) As Boolean
        Dim sTemp(3) As String
        Dim cntLine As Integer = 0
        Dim sHourPass As String = Nothing
        '   Dim idx As Integer = sRecipeInfos.recipeIndex_LifeTime
        Dim sSeparator As String = ","
        Dim sCaptionAndTEGNumber As String = "PANEL" & Format(m_nCh + 1, "00") 'ucDispJIG.convertIncNumberToMatrixValue(m_nCh)
        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        If m_nCntRedSaveData(nNumMeasPoint) = 1 Then
            ReDim sTemp(sTemp.Length + 4)
            sTemp(cntLine) = sreportTitle_SpectrumData & g_strFileVer : cntLine += 1
            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

            sTemp(cntLine) = "Filename : " & sSeparator & m_SeqInfo.sCommon.saveInfo.strOnlyFName : cntLine += 1

            'Dim measItem() As ucSampleInfos.eSampleColor = CSeqProcessor.GetMeasColorItemInfoFromLTRcp(sRecipeInfos.sLifetimeInfo)
            'sTemp(cntLine) = "Color : " & sSeparator
            'For i As Integer = 0 To measItem.Length - 1
            '    sTemp(cntLine) = sTemp(cntLine) & measItem(i).ToString & sSeparator
            'Next
            'cntLine += 1
            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

            sTemp(cntLine) = "[Hour Pass(hrs)], [Time(MM/DD/YY hh:mm:ss)], [Luminance(Cd/m^2)], [Luminance(%)]"

            For i As Integer = 0 To sMeasdata.opticalData.sSpectrometerData.D5.i3nm.Length - 1
                sTemp(cntLine) = sTemp(cntLine) & "," & "[" & sMeasdata.opticalData.sSpectrometerData.D5.i3nm(i) & "]"
                ' sTemp(cntLine) = sTemp(cntLine) & "," & spectrumData.D5.i3nm(i)  '헤더 [380] -> 380 변경
            Next
            cntLine += 1
        End If


        ' If m_nCntRedSaveData(nNumMeasPoint) = 1 Then
        'sHourPass = 0
        '  Else
        m_Lifetime(nNumMeasPoint) = Now.Subtract(m_TestStartTime(nNumMeasPoint))
        sHourPass = CStr(Format(m_Lifetime(nNumMeasPoint).TotalHours, "0.000"))
        '  End If

        sTemp(cntLine) = sHourPass & "," & CTime.GetCurrentTimeToStringType

        ' sTemp(cntLine) = "," '& "Wad_" & dSweepValue(i) & "," & sMeasdata(i).sSpectrometerData.D6.s2YY & "," & sMeasdata(i).dLumi_Percent


        sTemp(cntLine) = sTemp(cntLine) & "," & sMeasdata.opticalData.sSpectrometerData.D6.s2YY & "," & Format(sMeasdata.opticalData.dLumi_Percent, "0.0")

        For nIntensityCnt As Integer = 0 To sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity.Length - 1
            sTemp(cntLine) = sTemp(cntLine) & "," & sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity(nIntensityCnt)
        Next
        cntLine += 1

        ReDim Preserve sTemp(cntLine - 1)
        Try
            If WriteFile(1, m_SeqInfo.sCommon.saveInfo.strFPath & sCaptionAndTEGNumber & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & "RED" & "_P" & nNumMeasPoint + 1 & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).X & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).Y & ".csv", sTemp) = False Then Return False

        Catch ex As Exception

        End Try
        'If WriteFile(iResultDataNumber, m_sSavePath_LT_SpectrumData(nNumMeasPoint), sTemp) = False Then Return False

        'Try
        '    File.Copy(m_sSavePath_LT_SpectrumData(nNumMeasPoint), m_sSavePath_LT_SpectrumData_Backup(nNumMeasPoint), True)
        'Catch ex As Exception

        'End Try
        '   End If

        Return True
    End Function


    Public Overloads Function SaveLTAngleSpectrumDataPoint_GREEN(ByVal idx As Integer, ByVal sMeasdata As frmMain.sCellLTMeasureParam, ByVal nNumMeasPoint As Integer) As Boolean
        Dim sTemp(3) As String
        Dim cntLine As Integer = 0
        Dim sHourPass As String = Nothing
        '   Dim idx As Integer = sRecipeInfos.recipeIndex_LifeTime
        Dim sSeparator As String = ","
        Dim sCaptionAndTEGNumber As String = "PANEL" & Format(m_nCh + 1, "00") 'ucDispJIG.convertIncNumberToMatrixValue(m_nCh)
        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        If m_nCntGreenSaveData(nNumMeasPoint) = 1 Then
            ReDim sTemp(sTemp.Length + 4)
            sTemp(cntLine) = sreportTitle_SpectrumData & g_strFileVer : cntLine += 1
            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

            sTemp(cntLine) = "Filename : " & sSeparator & m_SeqInfo.sCommon.saveInfo.strOnlyFName : cntLine += 1

            'Dim measItem() As ucSampleInfos.eSampleColor = CSeqProcessor.GetMeasColorItemInfoFromLTRcp(sRecipeInfos.sLifetimeInfo)
            'sTemp(cntLine) = "Color : " & sSeparator
            'For i As Integer = 0 To measItem.Length - 1
            '    sTemp(cntLine) = sTemp(cntLine) & measItem(i).ToString & sSeparator
            'Next
            'cntLine += 1
            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

            sTemp(cntLine) = "[Hour Pass(hrs)], [Time(MM/DD/YY hh:mm:ss)], [Luminance(Cd/m^2)], [Luminance(%)]"

            For i As Integer = 0 To sMeasdata.opticalData.sSpectrometerData.D5.i3nm.Length - 1
                sTemp(cntLine) = sTemp(cntLine) & "," & "[" & sMeasdata.opticalData.sSpectrometerData.D5.i3nm(i) & "]"
                ' sTemp(cntLine) = sTemp(cntLine) & "," & spectrumData.D5.i3nm(i)  '헤더 [380] -> 380 변경
            Next
            cntLine += 1
        End If


        '  If m_nCntGreenSaveData(nNumMeasPoint) = 1 Then
        'sHourPass = 0
        '  Else
        m_Lifetime(nNumMeasPoint) = Now.Subtract(m_TestStartTime(nNumMeasPoint))
        sHourPass = CStr(Format(m_Lifetime(nNumMeasPoint).TotalHours, "0.000"))
        ' End If

        sTemp(cntLine) = sHourPass & "," & CTime.GetCurrentTimeToStringType

        ' sTemp(cntLine) = "," '& "Wad_" & dSweepValue(i) & "," & sMeasdata(i).sSpectrometerData.D6.s2YY & "," & sMeasdata(i).dLumi_Percent


        sTemp(cntLine) = sTemp(cntLine) & "," & sMeasdata.opticalData.sSpectrometerData.D6.s2YY & "," & Format(sMeasdata.opticalData.dLumi_Percent, "0.0")

        For nIntensityCnt As Integer = 0 To sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity.Length - 1
            sTemp(cntLine) = sTemp(cntLine) & "," & sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity(nIntensityCnt)
        Next
        cntLine += 1

        ReDim Preserve sTemp(cntLine - 1)

        Try
            If WriteFile(1, m_SeqInfo.sCommon.saveInfo.strFPath & sCaptionAndTEGNumber & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & "GREEN" & "_P" & nNumMeasPoint + 1 & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).X & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).Y & ".csv", sTemp) = False Then Return False

        Catch ex As Exception

        End Try

        'If WriteFile(iResultDataNumber, m_sSavePath_LT_SpectrumData(nNumMeasPoint), sTemp) = False Then Return False

        'Try
        '    File.Copy(m_sSavePath_LT_SpectrumData(nNumMeasPoint), m_sSavePath_LT_SpectrumData_Backup(nNumMeasPoint), True)
        'Catch ex As Exception

        'End Try
        '   End If

        Return True
    End Function


    Public Overloads Function SaveLTAngleSpectrumDataPoint_BLUE(ByVal idx As Integer, ByVal sMeasdata As frmMain.sCellLTMeasureParam, ByVal nNumMeasPoint As Integer) As Boolean
        Dim sTemp(3) As String
        Dim cntLine As Integer = 0
        Dim sHourPass As String = Nothing
        '   Dim idx As Integer = sRecipeInfos.recipeIndex_LifeTime
        Dim sSeparator As String = ","
        Dim sCaptionAndTEGNumber As String = "PANEL" & Format(m_nCh + 1, "00") 'ucDispJIG.convertIncNumberToMatrixValue(m_nCh)
        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        If m_nCntBlueSaveData(nNumMeasPoint) = 1 Then
            ReDim sTemp(sTemp.Length + 4)
            sTemp(cntLine) = sreportTitle_SpectrumData & g_strFileVer : cntLine += 1
            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

            sTemp(cntLine) = "Filename : " & sSeparator & m_SeqInfo.sCommon.saveInfo.strOnlyFName : cntLine += 1

            'Dim measItem() As ucSampleInfos.eSampleColor = CSeqProcessor.GetMeasColorItemInfoFromLTRcp(sRecipeInfos.sLifetimeInfo)
            'sTemp(cntLine) = "Color : " & sSeparator
            'For i As Integer = 0 To measItem.Length - 1
            '    sTemp(cntLine) = sTemp(cntLine) & measItem(i).ToString & sSeparator
            'Next
            'cntLine += 1
            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

            sTemp(cntLine) = "[Hour Pass(hrs)], [Time(MM/DD/YY hh:mm:ss)], [Luminance(Cd/m^2)], [Luminance(%)]"

            For i As Integer = 0 To sMeasdata.opticalData.sSpectrometerData.D5.i3nm.Length - 1
                sTemp(cntLine) = sTemp(cntLine) & "," & "[" & sMeasdata.opticalData.sSpectrometerData.D5.i3nm(i) & "]"
                ' sTemp(cntLine) = sTemp(cntLine) & "," & spectrumData.D5.i3nm(i)  '헤더 [380] -> 380 변경
            Next
            cntLine += 1
        End If


        '  If m_nCntBlueSaveData(nNumMeasPoint) = 1 Then
        'sHourPass = 0
        '   Else
        m_Lifetime(nNumMeasPoint) = Now.Subtract(m_TestStartTime(nNumMeasPoint))
        sHourPass = CStr(Format(m_Lifetime(nNumMeasPoint).TotalHours, "0.000"))
        '  End If

        sTemp(cntLine) = sHourPass & "," & CTime.GetCurrentTimeToStringType

        ' sTemp(cntLine) = "," '& "Wad_" & dSweepValue(i) & "," & sMeasdata(i).sSpectrometerData.D6.s2YY & "," & sMeasdata(i).dLumi_Percent


        sTemp(cntLine) = sTemp(cntLine) & "," & sMeasdata.opticalData.sSpectrometerData.D6.s2YY & "," & Format(sMeasdata.opticalData.dLumi_Percent, "0.0")

        For nIntensityCnt As Integer = 0 To sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity.Length - 1
            sTemp(cntLine) = sTemp(cntLine) & "," & sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity(nIntensityCnt)
        Next
        cntLine += 1

        ReDim Preserve sTemp(cntLine - 1)
        Try
            If WriteFile(1, m_SeqInfo.sCommon.saveInfo.strFPath & sCaptionAndTEGNumber & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & "BLUE" & "_P" & nNumMeasPoint + 1 & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).X & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).Y & ".csv", sTemp) = False Then Return False

        Catch ex As Exception

        End Try
        'If WriteFile(iResultDataNumber, m_sSavePath_LT_SpectrumData(nNumMeasPoint), sTemp) = False Then Return False

        'Try
        '    File.Copy(m_sSavePath_LT_SpectrumData(nNumMeasPoint), m_sSavePath_LT_SpectrumData_Backup(nNumMeasPoint), True)
        'Catch ex As Exception

        'End Try
        '   End If

        Return True
    End Function
    Public Overloads Function SaveLTAngleSpectrumDataPoint_BLACK(ByVal idx As Integer, ByVal sMeasdata As frmMain.sCellLTMeasureParam, ByVal nNumMeasPoint As Integer) As Boolean
        Dim sTemp(3) As String
        Dim cntLine As Integer = 0
        Dim sHourPass As String = Nothing
        '   Dim idx As Integer = sRecipeInfos.recipeIndex_LifeTime
        Dim sSeparator As String = ","
        Dim sCaptionAndTEGNumber As String = "PANEL" & Format(m_nCh + 1, "00") 'ucDispJIG.convertIncNumberToMatrixValue(m_nCh)
        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        If m_nCntBlackSaveData(nNumMeasPoint) = 1 Then
            ReDim sTemp(sTemp.Length + 4)
            sTemp(cntLine) = sreportTitle_SpectrumData & g_strFileVer : cntLine += 1
            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

            sTemp(cntLine) = "Filename : " & sSeparator & m_SeqInfo.sCommon.saveInfo.strOnlyFName : cntLine += 1

            'Dim measItem() As ucSampleInfos.eSampleColor = CSeqProcessor.GetMeasColorItemInfoFromLTRcp(sRecipeInfos.sLifetimeInfo)
            'sTemp(cntLine) = "Color : " & sSeparator
            'For i As Integer = 0 To measItem.Length - 1
            '    sTemp(cntLine) = sTemp(cntLine) & measItem(i).ToString & sSeparator
            'Next
            'cntLine += 1
            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

            sTemp(cntLine) = "[Hour Pass(hrs)], [Time(MM/DD/YY hh:mm:ss)], [Luminance(Cd/m^2)], [Luminance(%)]"

            For i As Integer = 0 To sMeasdata.opticalData.sSpectrometerData.D5.i3nm.Length - 1
                sTemp(cntLine) = sTemp(cntLine) & "," & "[" & sMeasdata.opticalData.sSpectrometerData.D5.i3nm(i) & "]"
                ' sTemp(cntLine) = sTemp(cntLine) & "," & spectrumData.D5.i3nm(i)  '헤더 [380] -> 380 변경
            Next
            cntLine += 1
        End If


        ' If m_nCntBlackSaveData(nNumMeasPoint) = 1 Then
        'sHourPass = 0
        ' Else
        m_Lifetime(nNumMeasPoint) = Now.Subtract(m_TestStartTime(nNumMeasPoint))
        sHourPass = CStr(Format(m_Lifetime(nNumMeasPoint).TotalHours, "0.000"))
        '  End If

        sTemp(cntLine) = sHourPass & "," & CTime.GetCurrentTimeToStringType

        ' sTemp(cntLine) = "," '& "Wad_" & dSweepValue(i) & "," & sMeasdata(i).sSpectrometerData.D6.s2YY & "," & sMeasdata(i).dLumi_Percent


        sTemp(cntLine) = sTemp(cntLine) & "," & sMeasdata.opticalData.sSpectrometerData.D6.s2YY & "," & Format(sMeasdata.opticalData.dLumi_Percent, "0.0")

        For nIntensityCnt As Integer = 0 To sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity.Length - 1
            sTemp(cntLine) = sTemp(cntLine) & "," & sMeasdata.opticalData.sSpectrometerData.D5.s4Intensity(nIntensityCnt)
        Next
        cntLine += 1

        ReDim Preserve sTemp(cntLine - 1)
        Try
            If WriteFile(1, m_SeqInfo.sCommon.saveInfo.strFPath & sCaptionAndTEGNumber & "_Spectrum" & "_" & m_SeqInfo.sCommon.saveInfo.strOnlyFName & "_" & "BLACK_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).X & "_" & m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint(nNumMeasPoint).Y & ".csv", sTemp) = False Then Return False

        Catch ex As Exception

        End Try
        'If WriteFile(iResultDataNumber, m_sSavePath_LT_SpectrumData(nNumMeasPoint), sTemp) = False Then Return False

        'Try
        '    File.Copy(m_sSavePath_LT_SpectrumData(nNumMeasPoint), m_sSavePath_LT_SpectrumData_Backup(nNumMeasPoint), True)
        'Catch ex As Exception

        'End Try
        '   End If

        Return True
    End Function

    Public Overloads Function SaveLTSpectrumDataPoint(ByVal idx As Integer, ByVal spectrumData() As CDevPR705.tData, ByVal dPercentLumi As Double) As Boolean
        Dim sTemp(spectrumData.Length - 1 + 6) As String
        Dim cntLine As Integer = 0

        Dim strCurrTime As String

        If m_SeqInfo.sRecipes(idx).nMode = ucSequenceBuilder.eRcpMode.eChangeTemperature Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        sTemp(cntLine) = "" : cntLine += 1
        sTemp(cntLine) = "" : cntLine += 1

        sTemp(cntLine) = "Luminance(%) : " & dPercentLumi : cntLine += 1
        sTemp(cntLine) = "Hour Pass(hrs) : "

        If m_nCntSaveData(idx) = 0 Then
            m_TestStartTime(idx) = Date.Parse(strCurrTime)
            sTemp(cntLine) = sTemp(cntLine) & "0" : cntLine += 1
        Else
            m_Lifetime(idx) = Now.Subtract(m_TestStartTime(idx))
            sTemp(cntLine) = sTemp(cntLine) & CStr(m_Lifetime(idx).TotalHours) : cntLine += 1
        End If

        sTemp(cntLine) = "Time(MM/DD/YY hh:mm:ss) : " & CTime.GetCurrentTimeToStringType : cntLine += 1



        For i As Integer = 0 To spectrumData(0).D5.i3nm.Length - 1
            sTemp(cntLine) = sTemp(cntLine) & "," & spectrumData(0).D5.i3nm(i)
        Next
        cntLine += 1

        For i As Integer = 0 To spectrumData.Length - 1
            sTemp(cntLine) += "P" & Format(i + 1, "00")
            For j As Integer = 0 To spectrumData(i).D5.s4Intensity.Length - 1
                sTemp(cntLine) = sTemp(cntLine) & "," & spectrumData(i).D5.s4Intensity(j)
            Next
            cntLine += 1
        Next


        ReDim Preserve sTemp(cntLine - 1)
        Try
            If WriteFile(iResultDataNumber, m_sSavePath_LT_SpectrumData(idx), sTemp) = False Then Return False
        Catch ex As Exception

        End Try


        Try
            File.Copy(m_sSavePath_LT_SpectrumData(idx), m_sSavePath_LT_SpectrumData_Backup(idx), True)
        Catch ex As Exception

        End Try

        Return True
    End Function


    Dim m_RefSpectrum() As CDevPR730.tData
    Dim m_BeforTimeHour As Double

    Public Function SaveDataPointImageSticking(ByVal idx As Integer, ByVal sDatas As CSeqRoutineMcPG.sMeasuredData, ByVal spectrumData() As CDevPR730.tData) As Boolean
        Dim sTemp As String = ""
        Dim strCurrTime As String
        Dim dBurnInTime As Double

        If m_SeqInfo.sRecipes(idx).nMode <> ucSequenceBuilder.eRcpMode.eModule_ImageSticking Then Return False

        strCurrTime = CTime.GetCurrentTimeToStringType

        'Hour Pass,	Time(MM/DD/YY hh:mm:ss)
        If m_nCntSaveData(idx) = 0 Then
            m_TestStartTime(idx) = Date.Parse(strCurrTime)
            sTemp = "0"   'Total Hour(Hour Pass)
            sTemp = sTemp & "," & CTime.GetCurrentTimeToStringType  'Current Date And Time
            m_RefSpectrum = spectrumData.Clone
            dBurnInTime = 0
            m_BeforTimeHour = 0
        Else
            m_Lifetime(idx) = Now.Subtract(m_TestStartTime(idx))
            sTemp = CStr(m_Lifetime(idx).TotalHours)  'Total Hour(Hour Pass)
            sTemp = sTemp & "," & CTime.GetCurrentTimeToStringType  'Current Date And Time
            dBurnInTime = m_Lifetime(idx).TotalHours - m_BeforTimeHour
            m_BeforTimeHour = m_Lifetime(idx).TotalHours
        End If

        sTemp = CStr(m_nCntSaveData(idx)) & "," & sTemp  'No 

        sTemp = sTemp & "," & CStr(dBurnInTime)

        For i As Integer = 0 To spectrumData.Length - 1
            sTemp = sTemp & "," & spectrumData(i).D6.s2YY & "," & _
                spectrumData(i).D2.s2XX & "," & spectrumData(i).D2.s3YY & "," & spectrumData(i).D2.s4ZZ & "," & _
                spectrumData(i).D6.s3xx & "," & spectrumData(i).D6.s4yy & "," & spectrumData(i).D6.s5uu & "," & spectrumData(i).D6.s6vv & "," & _
                spectrumData(i).D6.Comn.striOMeasQCode
        Next

        If m_nCntSaveData(idx) = 0 Then
            sTemp = sTemp & ", ,ASAP,Initial Measurement"
        Else
            Dim dRimg As Double 'Residual Image or Image Sticking Factor(IS)
            Dim dT0Sum As Double
            Dim dTnSum As Double

            For i As Integer = 1 To m_RefSpectrum.Length - 1
                dT0Sum = dT0Sum + m_RefSpectrum(i).D6.s2YY
            Next

            For i As Integer = 1 To spectrumData.Length - 1
                dTnSum = dTnSum + spectrumData(i).D6.s2YY
            Next
            dRimg = Math.Abs(1 - (dTnSum / spectrumData(0).D6.s2YY) / (dT0Sum / m_RefSpectrum(0).D6.s2YY)) * 100

            sTemp = sTemp & "," & Format(dRimg, "00.00") & ",ASAP,"
        End If

        'sTemp = sTemp & "," & 

        '
        'If WriteFile(2, m_sSavePath_Backup(idx), sTemp) = False Then Return False

        'Try
        '    File.Copy(m_sSavePath_Backup(idx), m_sSavePath(idx), True)
        'Catch ex As Exception
        '    ' MsgBox("SaveDataPoint" & ex.Message)
        'End Try

        m_nCntSaveData(idx) += 1

        Return True

    End Function

#End Region


#Region "SaveHeaderInfo Functions"

    Public Sub SaveHeaderInfoOfLT(ByVal idx As Integer, ByVal TestRecipe As ucSequenceBuilder.sRecipeInfo, Optional ByVal nNumMeasPoint As Integer = 0)

        If m_sSavePath_LT_Backup.Length <= idx Then Exit Sub

        If m_nCntSaveData(idx) > 0 Then Exit Sub

        '  CreateSaveFile(idx)

        Select Case TestRecipe.nMode

            Case ucSequenceBuilder.eRcpMode.eCell_Lifetime, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                SaveHeaderInfoOfCellLifetime(idx, TestRecipe.sLifetimeInfo, nNumMeasPoint)
            Case ucSequenceBuilder.eRcpMode.ePanel_Lifetime
                SaveHeaderInfoOfPannelLifetime(idx, TestRecipe.sLifetimeInfo.sCommon, TestRecipe.sLifetimeInfo.sPanelInfos)
            Case ucSequenceBuilder.eRcpMode.eModule_Lifetime
                SaveHeaderInfoOfModuleLifetime(idx, TestRecipe.sLifetimeInfo.sCommon, TestRecipe.sLifetimeInfo.sModuleInfos)
        End Select

    End Sub

    Public Sub SaveHeaderInfoOfIVL(ByVal idx As Integer, ByVal TestRecipe As ucSequenceBuilder.sRecipeInfo)
        If m_sSavePath_Sweep_Backup.Length <= idx Then Exit Sub

        Select Case TestRecipe.nMode
            Case ucSequenceBuilder.eRcpMode.eCell_IVL, ucSequenceBuilder.eRcpMode.eViewingAngle, ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL
                SaveHeaderInfoOfCellIVL(idx, TestRecipe)
            Case ucSequenceBuilder.eRcpMode.ePanel_IVL

            Case ucSequenceBuilder.eRcpMode.eModuel_IVL

        End Select
    End Sub

    Public Sub SaveHeaderInfoOfIVL(ByVal idx As Integer, ByVal TestRecipe As ucSequenceBuilder.sRecipeInfo, ByVal measTime As Double, ByVal standbyTime As Double)
        If m_sSavePath_Sweep_Backup.Length <= idx Then Exit Sub

        Select Case TestRecipe.nMode
            Case ucSequenceBuilder.eRcpMode.eCell_IVL
                SaveHeaderInfoOfCellIVL(idx, TestRecipe)
            Case ucSequenceBuilder.eRcpMode.ePanel_IVL

            Case ucSequenceBuilder.eRcpMode.eModuel_IVL

        End Select
    End Sub

    Private Sub SaveHeaderInfoOfCellIVL(ByVal idx As Integer, ByVal sRecipeInfo As ucSequenceBuilder.sRecipeInfo)
        Dim sTemp(8) As String
        Dim cntLine As Integer = 0
        '  Dim sColorName As String = Nothing
        'Title
        ' sTemp(cntLine) = sReportTitle_IVL & g_strFileVer : cntLine += 1
        '  sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

        With sRecipeInfo
            If sRecipeInfo.nMode = ucSequenceBuilder.eRcpMode.eCell_IVL Or sRecipeInfo.nMode = ucSequenceBuilder.eRcpMode.eCell_LifetimeAndIVL Then
                'Title
                If g_SystemOptions.sOptionData.SaveOptions.sIVLHeader.bFileversion = True Then
                    sTemp(cntLine) = sReportTitle_IVL & g_strFileVer : cntLine += 1
                    sTemp(cntLine) = "" : cntLine += 1 '구분용 공란
                End If

                If g_SystemOptions.sOptionData.SaveOptions.sIVLHeader.bFilename = True Then
                    sTemp(cntLine) = "Filename :" & "," & m_SeqInfo.sCommon.saveInfo.strOnlyFName : cntLine += 1
                End If

                If g_SystemOptions.sOptionData.SaveOptions.sIVLHeader.bBiasMode = True Then
                    sTemp(cntLine) = "Bias Mode :" & "," & "[" & sRecipeInfo.sIVLSweepInfo.sCommon.biasMode.ToString & "]" : cntLine += 1
                End If

                If g_SystemOptions.sOptionData.SaveOptions.sIVLHeader.bMeasMode = True Then
                    sTemp(cntLine) = "Measure Mode :" & "," & "[" & sRecipeInfo.sIVLSweepInfo.sCommon.measItem.ToString & "]" : cntLine += 1
                End If

                If g_SystemOptions.sOptionData.SaveOptions.sIVLHeader.bSweepMode = True Then
                    sTemp(cntLine) = "Sweep Mode : " & "," & "[Bias]" : cntLine += 1
                End If

                If g_SystemOptions.sOptionData.SaveOptions.sIVLHeader.bLuminanceMeasLevel = True Then
                    sTemp(cntLine) = "Luminance Meas Level : " & "," & "[" & sRecipeInfo.sIVLSweepInfo.sCommon.dLMeasLevel & "]" : cntLine += 1
                End If

                If cntLine <> 0 Then
                    sTemp(cntLine) = "" : cntLine += 1 '구분용 공란
                End If

                'sTemp(cntLine) = "[No.]" & "," & "[Mode]" & "," & "[Area(cm^2)]" & "," & "[Temperature('C)]" & _
                '                                  "," & "[Voltage(V)]" & _
                '                                  "," & "[Current(A)]" & _
                '                                  "," & "[Luminance(Cd/m^2)]" & _
                '                                  "," & "[CIE_x]" & _
                '                                  "," & "[CIE_y]" & _
                '                                  "," & "[CCT]" & _
                '                                  "," & "[Current Efficiency(cd/A)]" & _
                '                                  "," & "[J(mA/cm^2)]" & _
                '                                  "," & "[CIE_u']" & _
                '                                  "," & "[CIE_v']" & _
                '                                  "," & "[Power Efficiency(lm/W)]" & _
                '                                  "," & "[Abs J(mA/cm^2)]" & _
                '                                  "," & "[QE(%)]"

                sTemp(cntLine) = ConvertIVLHeaderToString()     'YJS Header Convert

            ElseIf sRecipeInfo.nMode = ucSequenceBuilder.eRcpMode.eViewingAngle Then
                ' ''    ReDim sTemp(5)
                ' ''    'Title
                ' ''    sTemp(cntLine) = sReportTitle_Angle & g_strFileVer : cntLine += 1
                ' ''    sTemp(cntLine) = "" : cntLine += 1 '구분용 공란
                ' ''    sTemp(cntLine) = "Filename :" & "," & m_SeqInfo.sCommon.saveInfo.strOnlyFName : cntLine += 1
                ' ''    '   sTemp(cntLine) = "Bias Mode :" & "," & "[" & sRecipeInfo.sViewingAngleInfo.sCommon.nBiasMode.ToString & "]" : cntLine += 1
                ' ''    sTemp(cntLine) = "Sweep Mode : " & "," & "[Angle]" : cntLine += 1
                ' ''    ' sTemp(cntLine) = "Bias : " & "," & "[" & sRecipeInfo.sViewingAngleInfo.sCommon.dBiasValue & "]" : cntLine += 1

                ' ''    sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

                ' ''    '정승재
                ' ''    sTemp(cntLine) = "[No.]" & _
                ' ''                         "," & "[Mode]" & _
                ' ''                         "," & "[Color]" & _
                ' ''                         "," & "[Area(cm^2)]" & _
                ' ''                         "," & "[Temperature('C)]" & _
                ' ''                         "," & "[Voltage(V)_Red]" & _
                ' ''                         "," & "[Current(mA)_Red]" & _
                ' ''                         "," & "[Voltage(V)_Green]" & _
                ' ''                         "," & "[Current(mA)_Green]" & _
                ' ''                         "," & "[Voltage(V)_Blue]" & _
                ' ''                         "," & "[Current(mA)_Blue]" & _
                ' ''                         "," & "[Angle(')]" & _
                ' ''                         "," & "[Luminance(Cd/m^2)]" & _
                ' ''                         "," & "[CIE_x]" & _
                ' ''                         "," & "[CIE_y]" & _
                ' ''                         "," & "[CCT]" & _
                ' ''                         "," & "[Luminance(%)]" & _
                ' ''                         "," & "[delta_u'v']" & _
                ' ''                         "," & "[CIE_u']" & _
                ' ''                         "," & "[CIE_v']" & _
                ' ''                         "," & "[Current Efficiency(cd/A)]" & _
                ' ''                         "," & "[J(mA/cm^2)]" & _
                ' ''                         "," & "[Abs J(mA/cm^2)]" & _
                ' ''                         "," & "[QE(%)]"

            End If


            '   sTemp(cntLine) = "Measurement Time(min) : " & "," & "[" & measTime & "]" : cntLine += 1
            ' sTemp(cntLine) = "Standby Time(min) : " & "," & "[" & standbyTime & "]" : cntLine += 1
            '   sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

            'sTemp(cntLine) = "[No.]" & "," & "[Mode]" & "," & "[Area(cm^2)]" & "," & "[Voltage(V)]" & "," & "[Current(A)]" & "," & "[ABS_I(A)]" & "," & "[Current density(mA/cm^2)]" & _
            '  "," & "[Abs J(mA/cm^2)]" & "," & "[Luminance(Cd/m^2)]" & "," & "[Current Efficiency(cd/A)]" & "," & "[Power Efficiency(Im/W)]" & _
            '   "," & "[QE(%)]" & "," & "[CIE_x]" & "," & "[CIE_y]" & "," & "[Log10(Abs Current)]" & "," & "[Temperature('C)]"




            'If sCommon.measItem = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
            '    Dim nCnt As Integer = 0
            '    Dim sSpec() As String = Nothing

            '    For i As Integer = 380 To 780 Step 2
            '        ReDim Preserve sSpec(nCnt)
            '        sSpec(nCnt) = CStr(i)
            '        nCnt += 1
            '    Next

            '    '   ReDim Preserve sTemp(cntLine - 1)
            '    For i As Integer = 0 To sSpec.Length - 1
            '        sTemp(cntLine) = sTemp(cntLine) & "," & sSpec(i)
            '    Next

            'End If

            cntLine += 1

        End With

        ReDim Preserve sTemp(cntLine - 1)

        WriteFile(iResultDataNumber, m_sSavePath_Sweep(idx), sTemp)

        Try
            File.Copy(m_sSavePath_Sweep(idx), m_sSavePath_Sweep_Backup(idx), True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveHeaderInfoOfCellLifetime(ByVal idx As Integer, ByVal sLifetimeInfos As ucSequenceBuilder.sRcpLifetime, ByVal nNumMeasPoint As Integer)
        Dim sTemp(21) As String
        Dim cntLine As Integer = 0
        Dim sSeparator As String = ","

        'Title
        If g_SystemOptions.sOptionData.SaveOptions.sLifetimeHeader.bFileversion = True Then
            sTemp(cntLine) = sReportTitle_Lifetime & g_strFileVer : cntLine += 1
            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란
        End If


        With sLifetimeInfos

            'Test Condition"
            If g_SystemOptions.sOptionData.SaveOptions.sLifetimeHeader.bFilename = True Then
                sTemp(cntLine) = "Filename : " & sSeparator & m_SeqInfo.sCommon.saveInfo.strOnlyFName : cntLine += 1 'Ch 번호 앞에서 처리하게 변경. 2013-04-22 승현
            End If

            If g_SystemOptions.sOptionData.SaveOptions.sLifetimeHeader.bMeasMode = True Then
                sTemp(cntLine) = "Meas. Mode :" & sSeparator & "[" & sMeasMode(sLifetimeInfos.sCommon.nMode) & "]" : cntLine += 1
            End If

            If g_SystemOptions.sOptionData.SaveOptions.sLifetimeHeader.bRenewalTime = True Then
                sTemp(cntLine) = "Renewal Time(H) :" & sSeparator & "[" & sLifetimeInfos.sCommon.sSetInfosTheRefPD.RenewalTime.dHour & "]" : cntLine += 1
                sTemp(cntLine) = "Renewal Time(M) :" & sSeparator & "[" & sLifetimeInfos.sCommon.sSetInfosTheRefPD.RenewalTime.dMin & "]" : cntLine += 1
            End If

            If g_SystemOptions.sOptionData.SaveOptions.sLifetimeHeader.bBiasMode = True Then
                sTemp(cntLine) = "Bias Mode : " & sSeparator
                For i As Integer = 0 To .sCellInfos.Length - 1
                    If .sCellInfos(i).bEnable = True Then
                        sTemp(cntLine) = sTemp(cntLine) & "[" & sBiasMode(.sCellInfos(i).Mode) & "]" & sSeparator
                    End If

                Next
                cntLine += 1


                sTemp(cntLine) = "Bias : "
                sTemp(cntLine + 1) = "Amplitude : "
                sTemp(cntLine + 2) = "Frequency : "
                sTemp(cntLine + 3) = "Duty : "

                For i As Integer = 0 To .sCellInfos.Length - 1

                    If .sCellInfos(i).bEnable = True Then
                        Select Case sLifetimeInfos.sCellInfos(i).Mode

                            Case CDevM6000PLUS.eMode.eCC, CDevM6000PLUS.eMode.eCV
                                sTemp(cntLine) = sTemp(cntLine) & sSeparator & .sCellInfos(i).dBias.ToString

                                '    sTemp(cntLine) = 
                            Case CDevM6000PLUS.eMode.ePC, CDevM6000PLUS.eMode.ePV, CDevM6000PLUS.eMode.ePCV
                                sTemp(cntLine) = sTemp(cntLine) & sSeparator & .sCellInfos(i).dBias
                                sTemp(cntLine + 1) = sTemp(cntLine + 1) & sSeparator & .sCellInfos(i).dAmplitude
                                sTemp(cntLine + 2) = sTemp(cntLine + 2) & sSeparator & .sCellInfos(i).Pulse.dFrequency
                                sTemp(cntLine + 3) = sTemp(cntLine + 3) & sSeparator & .sCellInfos(i).Pulse.dDuty
                        End Select
                    End If

                Next
                cntLine += 4
            End If

            If cntLine <> 0 Then
                sTemp(cntLine) = "" : cntLine += 1 '구분용 공란
            End If


            '    sTemp(cntLine) = "[Hour Pass(hrs)]" & sSeparator & "[Time]" & sSeparator & "[Area(cm^2)]" & sSeparator & "[Temp('C)]"

            Dim nCnt As Integer
            For i As Integer = 0 To .sCellInfos.Length - 1
                If .sCellInfos(i).bEnable = True Then
                    sTemp(cntLine) = ConvertLTHeaderToString()
                    nCnt += 1
                End If
            Next

            cntLine += 1

        End With

        ReDim Preserve sTemp(cntLine - 1)

        ' For i As Integer = 0 To m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
        Try
            WriteFile(1, m_sSavePath_LT(nNumMeasPoint), sTemp)
        Catch ex As Exception

        End Try


        Try
            File.Copy(m_sSavePath_LT(nNumMeasPoint), m_sSavePath_LT_Backup(nNumMeasPoint), True)
        Catch ex As Exception

            'MsgBox("SaveHeaderInfo" & ex.Message)
        End Try
        ' Next


    End Sub
    
    Public Sub SaveHeaderInfoOfCellLifetime_RGB(ByVal idx As Integer, ByVal sPath As String, ByVal sLifetimeInfos As ucSequenceBuilder.sRcpLifetime, ByVal nNumMeasPoint As Integer)
        Dim sTemp(21) As String
        Dim cntLine As Integer = 0
        Dim sSeparator As String = ","

        'Title
        If g_SystemOptions.sOptionData.SaveOptions.sLifetimeHeader.bFileversion = True Then
            sTemp(cntLine) = sReportTitle_Lifetime & g_strFileVer : cntLine += 1
            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란
        End If


        With sLifetimeInfos

            'Test Condition"
            If g_SystemOptions.sOptionData.SaveOptions.sLifetimeHeader.bFilename = True Then
                sTemp(cntLine) = "Filename : " & sSeparator & m_SeqInfo.sCommon.saveInfo.strOnlyFName : cntLine += 1 'Ch 번호 앞에서 처리하게 변경. 2013-04-22 승현
            End If

            If g_SystemOptions.sOptionData.SaveOptions.sLifetimeHeader.bMeasMode = True Then
                sTemp(cntLine) = "Meas. Mode :" & sSeparator & "[" & sMeasMode(sLifetimeInfos.sCommon.nMode) & "]" : cntLine += 1
            End If

            If g_SystemOptions.sOptionData.SaveOptions.sLifetimeHeader.bRenewalTime = True Then
                sTemp(cntLine) = "Renewal Time(H) :" & sSeparator & "[" & sLifetimeInfos.sCommon.sSetInfosTheRefPD.RenewalTime.dHour & "]" : cntLine += 1
                sTemp(cntLine) = "Renewal Time(M) :" & sSeparator & "[" & sLifetimeInfos.sCommon.sSetInfosTheRefPD.RenewalTime.dMin & "]" : cntLine += 1
            End If

            If g_SystemOptions.sOptionData.SaveOptions.sLifetimeHeader.bBiasMode = True Then
                sTemp(cntLine) = "Bias Mode : " & sSeparator
                For i As Integer = 0 To .sCellInfos.Length - 1
                    If .sCellInfos(i).bEnable = True Then
                        sTemp(cntLine) = sTemp(cntLine) & "[" & sBiasMode(.sCellInfos(i).Mode) & "]" & sSeparator
                    End If

                Next
                cntLine += 1


                sTemp(cntLine) = "Bias : "
                sTemp(cntLine + 1) = "Amplitude : "
                sTemp(cntLine + 2) = "Frequency : "
                sTemp(cntLine + 3) = "Duty : "

                For i As Integer = 0 To .sCellInfos.Length - 1

                    If .sCellInfos(i).bEnable = True Then
                        Select Case sLifetimeInfos.sCellInfos(i).Mode

                            Case CDevM6000PLUS.eMode.eCC, CDevM6000PLUS.eMode.eCV
                                sTemp(cntLine) = sTemp(cntLine) & sSeparator & .sCellInfos(i).dBias.ToString

                                '    sTemp(cntLine) = 
                            Case CDevM6000PLUS.eMode.ePC, CDevM6000PLUS.eMode.ePV, CDevM6000PLUS.eMode.ePCV
                                sTemp(cntLine) = sTemp(cntLine) & sSeparator & .sCellInfos(i).dBias
                                sTemp(cntLine + 1) = sTemp(cntLine + 1) & sSeparator & .sCellInfos(i).dAmplitude
                                sTemp(cntLine + 2) = sTemp(cntLine + 2) & sSeparator & .sCellInfos(i).Pulse.dFrequency
                                sTemp(cntLine + 3) = sTemp(cntLine + 3) & sSeparator & .sCellInfos(i).Pulse.dDuty
                        End Select
                    End If

                Next
                cntLine += 4
            End If

            If cntLine <> 0 Then
                sTemp(cntLine) = "" : cntLine += 1 '구분용 공란
            End If


            '    sTemp(cntLine) = "[Hour Pass(hrs)]" & sSeparator & "[Time]" & sSeparator & "[Area(cm^2)]" & sSeparator & "[Temp('C)]"

            Dim nCnt As Integer
            For i As Integer = 0 To .sCellInfos.Length - 1
                If .sCellInfos(i).bEnable = True Then
                    sTemp(cntLine) = ConvertLTHeaderToString()
                    nCnt += 1
                End If
            Next

            cntLine += 1

        End With

        ReDim Preserve sTemp(cntLine - 1)

        ' For i As Integer = 0 To m_SeqInfo.sRecipes(0).sLifetimeInfo.sCommon.sMeasPoints.MeasPoint.Length - 1
        Try
            WriteFile(1, sPath, sTemp)
        Catch ex As Exception

        End Try


        'Try
        '    File.Copy(m_sSavePath_LT(nNumMeasPoint), m_sSavePath_LT_Backup(nNumMeasPoint), True)
        'Catch ex As Exception

        '    'MsgBox("SaveHeaderInfo" & ex.Message)
        'End Try
        '' Next


    End Sub
  
    Private Function ConvertIVLHeaderToString() As String
        Dim sReturn As String = ""

        For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems.Length - 1
            sReturn += "[" & g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItemName(i) & "],"
        Next

        sReturn = sReturn.TrimEnd(",")

        Return sReturn

    End Function
    Private Function ConvertLTHeaderToString() As String
        Dim sReturn As String = ""

        For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItems.Length - 1
            sReturn += "[" & g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItemName(i) & "],"
        Next
        sReturn = sReturn.TrimEnd(",")
        Return sReturn
    End Function
    'Public Sub SaveHeaderInfoOfCIM_IVL(ByVal idx As Integer, ByVal sParam As sCIMReportItem)
    '    Dim sTemp() As String
    '    Dim cntLine As Integer = 0
    '    Dim sHeader As String = Nothing
    '    'Dim voltUnit As String = CUnitConverter.GetCaptionAndUnit("", g_sSystemOption.DispGroup.dispVolt)
    '    'Dim CurrUnit As String = CUnitConverter.GetCaptionAndUnit("", g_sSystemOption.DispGroup.dispCurrent)
    '    'Dim PDCurrUnit As String = CUnitConverter.GetCaptionAndUnit("", g_sSystemOption.DispGroup.dispPhotocurrent)


    '    If m_nCntSaveData(idx) > 0 Then Exit Sub

    '    ReDim Preserve sTemp(cntLine)

    '    sHeader = "ITEM PANEL MODULETYPE MODULEID PROCESSID PRODUCTID STEPID PROD_TYPE BATCHID H_PANELID E_PANELID P_PANELID OPERID COMP_COUNT PPID GRADE CODE R_GRADE MAP_IMAGE" & _
    '           " L_TIME U_TIME S_TIME E_TIME " & _
    '           "NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE"
    '    sTemp(cntLine) = sHeader ' "MAGAZINE_ID HOUR_PASSED(HR) TIME TYPE SOURCE VOLT(V) CURRENT(MA) PHOTO(UA) INTENSITY(%) PV"
    '    cntLine += 1
    '    ReDim Preserve sTemp(cntLine)
    '    sHeader = "ITEM MEASURE POINT_NO POINT_ID X1 Y1 X2 Y2 GATELINE1 DATALINE1 GATELINE2 DATALINE2 IMAGE_FILE NO_USE"
    '    For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems.Length - 1
    '        'If g_sSystemOption.sOutputParamEdit.ReportParam(i) = 6 Then     '6번 Voltage
    '        '    sHeader = sHeader & " " & frmOptionWindow.ConvertReportParamItemToString(g_sSystemOption.sOutputParamEdit.ReportParam(i)) + voltUnit
    '        'ElseIf g_sSystemOption.sOutputParamEdit.ReportParam(i) = 7 Then         '7번 Current
    '        '    sHeader = sHeader & " " & frmOptionWindow.ConvertReportParamItemToString(g_sSystemOption.sOutputParamEdit.ReportParam(i)) + CurrUnit
    '        'ElseIf g_sSystemOption.sOutputParamEdit.ReportParam(i) = 8 Then         '8번 PdCurrent
    '        '    sHeader = sHeader & " " & frmOptionWindow.ConvertReportParamItemToString(g_sSystemOption.sOutputParamEdit.ReportParam(i)) + PDCurrUnit
    '        'Else
    '        'sHeader = sHeader & " " & frmOptionWindow.ConvertReportParamItemToString(g_sSystemOption.sOutputParamEdit.ReportRdpParam(i))
    '        'End If
    '        sHeader = sHeader & " " & g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems_RDP(i)
    '    Next

    '    'param option header 가져옴
    '    'For i As Integer = 0 To g_sSystemOption.sOutputParamEdit.ReportParam.Length - 1
    '    '    sHeader = sHeader & " " & frmOptionWindow.ConvertReportParamItemToString(g_sSystemOption.sOutputParamEdit.ReportParam(i))
    '    'Next

    '    'frmOptionWindow.ConvertReportParamItemToString(g_sSystemOption.sOutputParamEdit.ReportParam(idx))
    '    'MAGAZINEID HOUR_PASSED(HR) TIME TYPE SOURCE VOLT(V) CURRENT(MA) PHOTO(UA) INTENSITY(%) PV"
    '    '" ORDER MODE VOLT(V) CURRENT(A) J(MA/CM^2) CD/A LM/W QUANTUM_EFFICIENCY(%) LUMINANCEFULL(CD/M^2) LUMINANCE(CD/M^2) CIEX CIEY ABS_CURRENT(A) ABS_J(MA/CM^2) PV(TEMPERATURE) RGB TARGETSOURCE"
    '    sTemp(cntLine) = sHeader
    '    cntLine += 1

    '    ReDim Preserve sTemp(cntLine)
    '    sHeader = "DATA PANEL" & sParam.sModuleType & sParam.sModuleID & sParam.sPROCESSID & sParam.sPRODUCTID & sParam.sSTEPID & sParam.sPROD_TYPE & sParam.sBATCHID & _
    '                sParam.sH_PANELID & sParam.sE_PANELID & sParam.sP_PANELID & sParam.sOPERID & "     1     *     OK     OOOO     OK" & "     *     *     *" & sParam.sS_TIME & sParam.sE_TIME & _
    '                      "     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *    "

    '    'sHeader = "DATA PANEL" & sParam.sModuleType & sParam.sModuleID & sParam.sPROCESSID & sParam.sPRODUCTID & sParam.sSTEPID & sParam.sPROD_TYPE & sParam.sBATCHID & _
    '    '            sParam.sH_PANELID & sParam.sE_PANELID & sParam.sP_PANELID & sParam.sOPERID & " 1 * OK OOOO OK" & _
    '    '                  " * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *"
    '    sTemp(cntLine) = sHeader
    '    cntLine += 1

    '    'ReDim Preserve sTemp(cntLine)   '24 Line
    '    'sHeader = "DATA MEASURE" & " * * * * * * * * * * * * * " & _
    '    '""
    '    'sTemp(cntLine) = sHeader
    '    'cntLine += 1

    '    ReDim Preserve sTemp(cntLine - 1)

    '    WriteFile(iResultDataNumber + 1, m_sSavePath_RDP_IVL(idx), sTemp)
    'End Sub
    'Public Sub SaveHeaderInfoOfCIM_Spectrum(ByVal recipe As ucSequenceBuilder.sRecipeInfo, ByVal idx As Integer, ByVal sParam As sCIMReportItem, ByVal SpectrumBiasList()() As Double)
    '    Try

    '        Dim sTemp() As String
    '        Dim cntLine As Integer = 0
    '        Dim sHeader As String = Nothing
    '        If SpectrumBiasList Is Nothing Then Return

    '        ' If m_nCntSaveData(idx) > 0 Then Exit Sub
    '        ReDim Preserve sTemp(cntLine)

    '        sHeader = "ITEM PANEL MODULETYPE MODULEID PROCESSID PRODUCTID STEPID PROD_TYPE BATCHID H_PANELID E_PANELID P_PANELID OPERID COMP_COUNT PPID GRADE CODE R_GRADE MAP_IMAGE" & _
    '               " L_TIME U_TIME S_TIME E_TIME " & _
    '               "NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE"
    '        sTemp(cntLine) = sHeader ' "MAGAZINE_ID HOUR_PASSED(HR) TIME TYPE SOURCE VOLT(V) CURRENT(MA) PHOTO(UA) INTENSITY(%) PV"
    '        cntLine += 1
    '        ReDim Preserve sTemp(cntLine)
    '        sHeader = "ITEM MEASURE POINT_NO POINT_ID X1 Y1 X2 Y2 GATELINE1 DATALINE1 GATELINE2 DATALINE2 IMAGE_FILE NO_USE"
    '        If recipe.nMode = ucSequenceBuilder.eRcpMode.eCell_IVL Then
    '            sHeader = sHeader & " " & "WAVELENGTH_BIAS"
    '            For colorIdx As Integer = 0 To SpectrumBiasList.Length - 1
    '                For nCnt = 0 To SpectrumBiasList(colorIdx).Length - 1
    '                    'sTemp(cntLine) = sTemp(cntLine) & " " & "Voltage_" & SpectrumBiasList(colorIdx)(nCnt)
    '                    sHeader = sHeader & " " & "VOLTAGE_" & SpectrumBiasList(colorIdx)(nCnt)
    '                Next
    '            Next
    '        End If
    '        If recipe.nMode = recipe.nMode = ucSequenceBuilder.eRcpMode.eViewingAngle Then
    '            sHeader = sHeader & " " & "WAVELENGTH_ANGLE"
    '            For colorIdx As Integer = 0 To SpectrumBiasList.Length - 1
    '                For nCnt = 0 To SpectrumBiasList(colorIdx).Length - 1
    '                    'sTemp(cntLine) = sTemp(cntLine) & " " & "Voltage_" & SpectrumBiasList(colorIdx)(nCnt)
    '                    sHeader = sHeader & " " & "VOLTAGE_" & SpectrumBiasList(colorIdx)(nCnt)
    '                Next
    '            Next
    '        End If
    '        'frmOptionWindow.ConvertReportParamItemToString(g_sSystemOption.sOutputParamEdit.ReportParam(idx))
    '        'MAGAZINEID HOUR_PASSED(HR) TIME TYPE SOURCE VOLT(V) CURRENT(MA) PHOTO(UA) INTENSITY(%) PV"
    '        '" ORDER MODE VOLT(V) CURRENT(A) J(MA/CM^2) CD/A LM/W QUANTUM_EFFICIENCY(%) LUMINANCEFULL(CD/M^2) LUMINANCE(CD/M^2) CIEX CIEY ABS_CURRENT(A) ABS_J(MA/CM^2) PV(TEMPERATURE) RGB TARGETSOURCE"
    '        sTemp(cntLine) = sHeader
    '        cntLine += 1

    '        ReDim Preserve sTemp(cntLine)
    '        sHeader = "DATA PANEL" & sParam.sModuleType & sParam.sModuleID & sParam.sPROCESSID & sParam.sPRODUCTID & sParam.sSTEPID & sParam.sPROD_TYPE & sParam.sBATCHID & _
    '                    sParam.sH_PANELID & sParam.sE_PANELID & sParam.sP_PANELID & sParam.sOPERID & "     1     *     OK     OOOO     OK" & "     *     *     *" & sParam.sS_TIME & sParam.sE_TIME & _
    '                          "     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *    "

    '        'sHeader = "DATA PANEL" & sParam.sModuleType & sParam.sModuleID & sParam.sPROCESSID & sParam.sPRODUCTID & sParam.sSTEPID & sParam.sPROD_TYPE & sParam.sBATCHID & _
    '        '            sParam.sH_PANELID & sParam.sE_PANELID & sParam.sP_PANELID & sParam.sOPERID & " 1 * OK OOOO OK" & _
    '        '                  " * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *"
    '        sTemp(cntLine) = sHeader
    '        cntLine += 1

    '        'ReDim Preserve sTemp(cntLine)   '24 Line
    '        'sHeader = "DATA MEASURE" & " * * * * * * * * * * * * * " & _
    '        '""
    '        'sTemp(cntLine) = sHeader
    '        'cntLine += 1

    '        ReDim Preserve sTemp(cntLine - 1)
    '        WriteFile(iResultDataNumber + 1, m_sSavePath_RDP_IVL_SPectrum(idx), sTemp)
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Public Sub SaveHeaderInfoOfCIM_LT(ByVal idx As Integer, ByVal sParam As sCIMReportItem)
    '    Dim sTemp() As String
    '    Dim cntLine As Integer = 0
    '    Dim sHeader As String = Nothing
    '    'Dim voltUnit As String = CUnitConverter.GetCaptionAndUnit("", g_sSystemOption.DispGroup.dispVolt)
    '    'Dim CurrUnit As String = CUnitConverter.GetCaptionAndUnit("", g_sSystemOption.DispGroup.dispCurrent)
    '    'Dim PDCurrUnit As String = CUnitConverter.GetCaptionAndUnit("", g_sSystemOption.DispGroup.dispPhotocurrent)


    '    If m_nCntSaveData(idx) > 0 Then Exit Sub

    '    ReDim Preserve sTemp(cntLine)

    '    sHeader = "ITEM PANEL MODULETYPE MODULEID PROCESSID PRODUCTID STEPID PROD_TYPE BATCHID H_PANELID E_PANELID P_PANELID OPERID COMP_COUNT PPID GRADE CODE R_GRADE MAP_IMAGE" & _
    '           " L_TIME U_TIME S_TIME E_TIME " & _
    '           "NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE"
    '    sTemp(cntLine) = sHeader ' "MAGAZINE_ID HOUR_PASSED(HR) TIME TYPE SOURCE VOLT(V) CURRENT(MA) PHOTO(UA) INTENSITY(%) PV"
    '    cntLine += 1
    '    ReDim Preserve sTemp(cntLine)
    '    sHeader = "ITEM MEASURE POINT_NO POINT_ID X1 Y1 X2 Y2 GATELINE1 DATALINE1 GATELINE2 DATALINE2 IMAGE_FILE NO_USE"
    '    For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItems.Length - 1
    '        'If g_sSystemOption.sOutputParamEdit.ReportParam(i) = 6 Then     '6번 Voltage
    '        '    sHeader = sHeader & " " & frmOptionWindow.ConvertReportParamItemToString(g_sSystemOption.sOutputParamEdit.ReportParam(i)) + voltUnit
    '        'ElseIf g_sSystemOption.sOutputParamEdit.ReportParam(i) = 7 Then         '7번 Current
    '        '    sHeader = sHeader & " " & frmOptionWindow.ConvertReportParamItemToString(g_sSystemOption.sOutputParamEdit.ReportParam(i)) + CurrUnit
    '        'ElseIf g_sSystemOption.sOutputParamEdit.ReportParam(i) = 8 Then         '8번 PdCurrent
    '        '    sHeader = sHeader & " " & frmOptionWindow.ConvertReportParamItemToString(g_sSystemOption.sOutputParamEdit.ReportParam(i)) + PDCurrUnit
    '        'Else
    '        'sHeader = sHeader & " " & frmOptionWindow.ConvertReportParamItemToString(g_sSystemOption.sOutputParamEdit.ReportRdpParam(i))
    '        'End If
    '        sHeader = sHeader & " " & g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItems_RDP(i)
    '    Next

    '    'param option header 가져옴
    '    'For i As Integer = 0 To g_sSystemOption.sOutputParamEdit.ReportParam.Length - 1
    '    '    sHeader = sHeader & " " & frmOptionWindow.ConvertReportParamItemToString(g_sSystemOption.sOutputParamEdit.ReportParam(i))
    '    'Next

    '    'frmOptionWindow.ConvertReportParamItemToString(g_sSystemOption.sOutputParamEdit.ReportParam(idx))
    '    'MAGAZINEID HOUR_PASSED(HR) TIME TYPE SOURCE VOLT(V) CURRENT(MA) PHOTO(UA) INTENSITY(%) PV"
    '    '" ORDER MODE VOLT(V) CURRENT(A) J(MA/CM^2) CD/A LM/W QUANTUM_EFFICIENCY(%) LUMINANCEFULL(CD/M^2) LUMINANCE(CD/M^2) CIEX CIEY ABS_CURRENT(A) ABS_J(MA/CM^2) PV(TEMPERATURE) RGB TARGETSOURCE"
    '    sTemp(cntLine) = sHeader
    '    cntLine += 1

    '    ReDim Preserve sTemp(cntLine)
    '    sHeader = "DATA PANEL" & sParam.sModuleType & sParam.sModuleID & sParam.sPROCESSID & sParam.sPRODUCTID & sParam.sSTEPID & sParam.sPROD_TYPE & sParam.sBATCHID & _
    '                    sParam.sH_PANELID & sParam.sE_PANELID & sParam.sP_PANELID & sParam.sOPERID & "     1     *     OK     OOOO     OK" & "     *     *     *" & sParam.sS_TIME & sParam.sE_TIME & _
    '                          "     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *    "

    '    'sHeader = "DATA PANEL" & sParam.sModuleType & sParam.sModuleID & sParam.sPROCESSID & sParam.sPRODUCTID & sParam.sSTEPID & sParam.sPROD_TYPE & sParam.sBATCHID & _
    '    '            sParam.sH_PANELID & sParam.sE_PANELID & sParam.sP_PANELID & sParam.sOPERID & " 1 * OK OOOO OK" & _
    '    '                  " * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *"
    '    sTemp(cntLine) = sHeader
    '    cntLine += 1

    '    'ReDim Preserve sTemp(cntLine)   '24 Line
    '    'sHeader = "DATA MEASURE" & " * * * * * * * * * * * * * " & _
    '    '""
    '    'sTemp(cntLine) = sHeader
    '    'cntLine += 1

    '    ReDim Preserve sTemp(cntLine - 1)

    '    WriteFile(iResultDataNumber + 1, m_sSavePath_RDP_LT(idx), sTemp)
    'End Sub
    'Public Sub SaveHeaderInfoOfCIM_LTSpectrum(ByVal idx As Integer, ByVal sParam As sCIMReportItem)
    '    Dim sTemp() As String
    '    Dim cntLine As Integer = 0
    '    Dim sHeader As String = Nothing
    '    'If SpectrumBiasList Is Nothing Then Return

    '    If m_nCntSaveData(idx) > 0 Then Exit Sub

    '    cntLine += 2    '두줄공백추가
    '    ReDim Preserve sTemp(cntLine)

    '    sHeader = "ITEM PANEL MODULETYPE MODULEID PROCESSID PRODUCTID STEPID PROD_TYPE BATCHID H_PANELID E_PANELID P_PANELID OPERID COMP_COUNT PPID GRADE CODE R_GRADE MAP_IMAGE" & _
    '           " L_TIME U_TIME S_TIME E_TIME " & _
    '           "NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE NO_USE"
    '    sTemp(cntLine) = sHeader ' "MAGAZINE_ID HOUR_PASSED(HR) TIME TYPE SOURCE VOLT(V) CURRENT(MA) PHOTO(UA) INTENSITY(%) PV"
    '    cntLine += 1
    '    ReDim Preserve sTemp(cntLine)
    '    '헤더추가
    '    sHeader = "ITEM MEASURE POINT_NO POINT_ID X1 Y1 X2 Y2 GATELINE1 DATALINE1 GATELINE2 DATALINE2 IMAGE_FILE NO_USE HOUR_PASS TIME LUMINANCE_CD LUMINANCE_PERCENT LIFETIME INTENSITYPERCENT MEASUREVOLTAGE MEASURETIME "
    '    ' 기존 : "ITEM MEASURE POINT_NO POINT_ID X1 Y1 X2 Y2 GATELINE1 DATALINE1 GATELINE2 DATALINE2 IMAGE_FILE NO_USE"
    '    sTemp(cntLine) = sHeader
    '    cntLine += 1

    '    ReDim Preserve sTemp(cntLine)
    '    sHeader = "DATA PANEL" & sParam.sModuleType & sParam.sModuleID & sParam.sPROCESSID & sParam.sPRODUCTID & sParam.sSTEPID & sParam.sPROD_TYPE & sParam.sBATCHID & _
    '                    sParam.sH_PANELID & sParam.sE_PANELID & sParam.sP_PANELID & sParam.sOPERID & "     1     *     OK     OOOO     OK" & "     *     *     *" & sParam.sS_TIME & sParam.sE_TIME & _
    '                          "     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *     *    "
    '    sTemp(cntLine) = sHeader
    '    cntLine += 1

    '    'ReDim Preserve sTemp(cntLine)   '24 Line
    '    'sHeader = "DATA MEASURE" & " * * * * * * * * * * * * * " & _
    '    '""
    '    'sTemp(cntLine) = sHeader
    '    'cntLine += 1

    '    ReDim Preserve sTemp(cntLine - 1)
    '    WriteFile(iResultDataNumber + 1, m_sSavePath_RDP_LT_Spectrum(idx), sTemp)
    'End Sub
    'Private Function ConvertIVLHeaderToString() As String
    '    Dim sReturn As String = ""

    '    For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems.Length - 1
    '        sReturn += g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotConvertItems(i) & ","
    '    Next

    '    sReturn = sReturn.TrimEnd(",")

    '    Return sReturn

    '    'For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems.Length - 1
    '    '    sReturn += "[" & g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItemName(i) & "],"
    '    'Next

    '    'sReturn = sReturn.TrimEnd(",")

    '    'Return sReturn


    'End Function
    'Private Function ConvertLTHeaderToString() As String

    '    Dim sReturn As String = ""
    '    For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItems.Length - 1
    '        sReturn += "[" & g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotConvertItems(i) & "],"
    '    Next
    '    sReturn = sReturn.TrimEnd(",")
    '    Return sReturn
    '    'For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItems.Length - 1
    '    '    sReturn += "[" & g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItemName(i) & "],"
    '    'Next
    '    'sReturn = sReturn.TrimEnd(",")
    '    'Return sReturn
    'End Function
    Public Function ConvertVADataToArray(ByVal Data As frmMain.sCellIVLMeasure, ByVal nSweepPoint As Integer, ByRef sData() As String) As Boolean
        Try
            With Data
                ReDim sData(g_SystemOptions.sOptionData.SaveOptions.nDataVAPlotItems.Length - 1)
                For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataVAPlotItems.Length - 1
                    Select Case g_SystemOptions.sOptionData.SaveOptions.nDataVAPlotItems(i)
                        Case frmOptionWindow.eVADataIndex.eEmpty
                            sData(i) = "0"
                        Case frmOptionWindow.eVADataIndex.eNo
                            sData(i) = nSweepPoint + 1
                        Case frmOptionWindow.eVADataIndex.eMode
                            sData(i) = .nMeasMode
                        Case frmOptionWindow.eVADataIndex.eArea
                            sData(i) = Format(.dArea_cm, "0.0000")
                        Case frmOptionWindow.eVADataIndex.eTemperature
                            sData(i) = .dTemperature
                        Case frmOptionWindow.eVADataIndex.eVoltage
                            sData(i) = .dVoltage
                        Case frmOptionWindow.eVADataIndex.eCurrent
                            sData(i) = .dCurrent
                        Case frmOptionWindow.eVADataIndex.eLuminance_Fill
                            sData(i) = .dLuminance_Fill_Cdm2
                        Case frmOptionWindow.eVADataIndex.eLuminance
                            sData(i) = .dLuminance_Cdm2
                        Case frmOptionWindow.eVADataIndex.eCIEx
                            sData(i) = Format(.dCIEx, "0.0000")
                        Case frmOptionWindow.eVADataIndex.eCIEy
                            sData(i) = Format(.dCIEy, "0.0000")
                        Case frmOptionWindow.eVADataIndex.eCCT
                            sData(i) = .dCCT
                        Case frmOptionWindow.eVADataIndex.eCurrentEfficiency
                            sData(i) = .dCdA
                        Case frmOptionWindow.eVADataIndex.eJ
                            sData(i) = .dJ
                        Case frmOptionWindow.eVADataIndex.eCIEu
                            sData(i) = Format(.dCIEu, "0.0000")
                        Case frmOptionWindow.eVADataIndex.eCIEv
                            sData(i) = Format(.dCIEv, "0.0000")
                        Case frmOptionWindow.eVADataIndex.ePowerEfficiency
                            sData(i) = .dlmW
                        Case frmOptionWindow.eVADataIndex.eAbsJ
                            sData(i) = .dAbs_J
                        Case frmOptionWindow.eVADataIndex.eQE
                            sData(i) = .dQE
                        Case frmOptionWindow.eVADataIndex.eFWHM
                            sData(i) = .dFWHM
                        Case frmOptionWindow.eVADataIndex.eAngle
                            sData(i) = .dAngle
                        Case frmOptionWindow.eVADataIndex.eDuv
                            sData(i) = .dDelta_CIE1960
                        Case frmOptionWindow.eVADataIndex.eELmaxIntensity
                            sData(i) = .dWavePeakValue
                        Case frmOptionWindow.eVADataIndex.eELmax
                            sData(i) = .nWavePeaklength
                        Case frmOptionWindow.eVADataIndex.eCRI
                            sData(i) = .dCRI
                            'Case frmOptionWindow.eVADataIndex.eViewingAngle
                            '    sData(i) = .dAngle
                        Case frmOptionWindow.eVADataIndex.eDuprimevprime
                            sData(i) = .dDelta_CIE1976
                    End Select

                Next
            End With
        Catch ex As Exception
            sData = Nothing
            Return False
        End Try

        Return True
    End Function
    Public Function ConvertLTDataToArray(ByVal Data As frmMain.sMeasureParams, ByVal dHourPassed As String, ByVal dTime As String, ByVal Point As Integer, ByRef sData() As String) As Boolean
        Try
            With Data
                ReDim sData(g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItemName.Length - 1)
                For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItemName.Length - 1
                    Select Case g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItems(i)
                        Case frmOptionWindow.eLTDataIndex.eEmpty
                            sData(i) = "0"
                        Case frmOptionWindow.eLTDataIndex.eHourPass
                            sData(i) = dHourPassed
                        Case frmOptionWindow.eLTDataIndex.eTime
                            sData(i) = dTime
                        Case frmOptionWindow.eLTDataIndex.eArea
                            sData(i) = Format(.sCellLTParams.dCellArea, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eTemp
                            sData(i) = .dTemp
                        Case frmOptionWindow.eLTDataIndex.eVoltage
                            sData(i) = Format(.sCellLTParams.LTData(Point).eletricalData.dVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eDeltaVoltage
                            sData(i) = Format(.sCellLTParams.LTData(Point).eletricalData.dDeltaVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eAmplitudeVoltage
                            sData(i) = Format(.sCellLTParams.LTData(Point).eletricalData.dHighVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.LTData(Point).eletricalData.dCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrent_Per
                            sData(i) = Format(.sCellLTParams.LTData(Point).eletricalData.dCurrent_Per, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eDeltaCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dDeltaCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.LTData(Point).eletricalData.dDeltaCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eAmplitudeCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dHighCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.LTData(Point).eletricalData.dHighCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrentDensity
                            'sData(i) = Format(.sCellLTParams.LTData.dCurrentDensity, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.LTData(Point).dCurrentDensity, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminance_Fill_cdm2
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.dLumi_Fill_Cd_m2, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminance_cdm2
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.dLumi_Cd_m2, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminanace_Per
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.dLumi_Percent, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eCurrentEfficiency
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.dLumi_Cd_A, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrentEfficiency_Per
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.dLumi_Cd_A_Percent, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eQE
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.dQE, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEx
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.sSpectrometerData.D6.s3xx, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEy
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.sSpectrometerData.D6.s4yy, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEu
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.sSpectrometerData.D6.s5uu, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEv
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.sSpectrometerData.D6.s6vv, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eDeltauv
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.dDeltaudvd, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCCT
                            sData(i) = .sCellLTParams.LTData(Point).opticalData.sSpectrometerData.D4.s3KelvinT
                        Case frmOptionWindow.eLTDataIndex.eSpectrumSum_Per
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.dSpectrumSum_Per, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eELMax
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.dELMax, "0.0")
                        Case frmOptionWindow.eLTDataIndex.eFHWM
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.dFWHM, "0.0")
                        Case frmOptionWindow.eLTDataIndex.eCHNum
                            sData(i) = "CH" & .sCellLTParams.dCHNum & "-" & (Point + 1)
                        Case frmOptionWindow.eLTDataIndex.eLuminance_Fill_Per
                            sData(i) = Format(.sCellLTParams.LTData(Point).opticalData.dLumi_Percent, "0.00")

                            'Case frmOptionWindow.eLTDataIndex.eIntegWL1
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak1_Integ
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL2
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak2_Integ
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL3
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak3_Integ
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL4
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak4_Integ
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL_Photopic1
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak1_Integ_Lumi
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL_Photopic2
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak2_Integ_Lumi
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL_Photopic3
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak3_Integ_Lumi
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL_Photopic4
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak4_Integ_Lumi
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL1_Per
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak1_Integral_Relative
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL2_Per
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak2_Integral_Relative
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL3_Per
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak3_Integral_Relative
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL4_Per
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak4_Integral_Relative
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL_Photopic1_Per
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak1_Integral_Relative_Lumi
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL_Photopic2_Per
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak2_Integral_Relative_Lumi
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL_Photopic3_Per
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak3_Integral_Relative_Lumi
                            'Case frmOptionWindow.eLTDataIndex.eIntegWL_Photopic4_Per
                            '    sData(i) = .sCellLTParams.LTData.opticalData.dPeak4_Integral_Relative_Lumi
                    End Select
                Next
            End With
        Catch ex As Exception

        End Try
        Return True
    End Function

    Public Function ConvertLTDataToArray_RED(ByVal Data As frmMain.sMeasureParams, ByVal dHourPassed As String, ByVal dTime As String, ByVal Point As Integer, ByRef sData() As String) As Boolean
        Try
            With Data
                ReDim sData(g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItemName.Length - 1)
                For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItemName.Length - 1
                    Select Case g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItems(i)
                        Case frmOptionWindow.eLTDataIndex.eEmpty
                            sData(i) = "0"
                        Case frmOptionWindow.eLTDataIndex.eHourPass
                            sData(i) = dHourPassed
                        Case frmOptionWindow.eLTDataIndex.eTime
                            sData(i) = dTime
                        Case frmOptionWindow.eLTDataIndex.eArea
                            sData(i) = Format(.sCellLTParams.dCellArea, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eTemp
                            sData(i) = .dTemp
                        Case frmOptionWindow.eLTDataIndex.eVoltage
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).eletricalData.dVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eDeltaVoltage
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).eletricalData.dDeltaVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eAmplitudeVoltage
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).eletricalData.dHighVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).eletricalData.dCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrent_Per
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).eletricalData.dCurrent_Per, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eDeltaCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dDeltaCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).eletricalData.dDeltaCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eAmplitudeCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dHighCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).eletricalData.dHighCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrentDensity
                            'sData(i) = Format(.sCellLTParams.LTData.dCurrentDensity, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).dCurrentDensity, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminance_Fill_cdm2
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.dLumi_Fill_Cd_m2, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminance_cdm2
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.dLumi_Cd_m2, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminanace_Per
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.dLumi_Percent, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eCurrentEfficiency
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.dLumi_Cd_A, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrentEfficiency_Per
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.dLumi_Cd_A_Percent, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eQE
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.dQE, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEx
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.sSpectrometerData.D6.s3xx, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEy
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.sSpectrometerData.D6.s4yy, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEu
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.sSpectrometerData.D6.s5uu, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEv
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.sSpectrometerData.D6.s6vv, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eDeltauv
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.dDeltaudvd, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCCT
                            sData(i) = .sCellLTParams.RedLTData(Point).opticalData.sSpectrometerData.D4.s3KelvinT
                        Case frmOptionWindow.eLTDataIndex.eSpectrumSum_Per
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.dSpectrumSum_Per, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eELMax
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.dELMax, "0.0")
                        Case frmOptionWindow.eLTDataIndex.eFHWM
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.dFWHM, "0.0")
                        Case frmOptionWindow.eLTDataIndex.eCHNum
                            sData(i) = "CH" & .sCellLTParams.dCHNum & "-" & (Point + 1)
                        Case frmOptionWindow.eLTDataIndex.eLuminance_Fill_Per
                            sData(i) = Format(.sCellLTParams.RedLTData(Point).opticalData.dLumi_Percent, "0.00")
                    End Select
                Next
            End With
        Catch ex As Exception

        End Try
        Return True
    End Function
    Public Function ConvertLTDataToArray_GREEN(ByVal Data As frmMain.sMeasureParams, ByVal dHourPassed As String, ByVal dTime As String, ByVal Point As Integer, ByRef sData() As String) As Boolean
        Try
            With Data
                ReDim sData(g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItemName.Length - 1)
                For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItemName.Length - 1
                    Select Case g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItems(i)
                        Case frmOptionWindow.eLTDataIndex.eEmpty
                            sData(i) = "0"
                        Case frmOptionWindow.eLTDataIndex.eHourPass
                            sData(i) = dHourPassed
                        Case frmOptionWindow.eLTDataIndex.eTime
                            sData(i) = dTime
                        Case frmOptionWindow.eLTDataIndex.eArea
                            sData(i) = Format(.sCellLTParams.dCellArea, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eTemp
                            sData(i) = .dTemp
                        Case frmOptionWindow.eLTDataIndex.eVoltage
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).eletricalData.dVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eDeltaVoltage
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).eletricalData.dDeltaVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eAmplitudeVoltage
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).eletricalData.dHighVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).eletricalData.dCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrent_Per
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).eletricalData.dCurrent_Per, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eDeltaCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dDeltaCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).eletricalData.dDeltaCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eAmplitudeCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dHighCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).eletricalData.dHighCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrentDensity
                            'sData(i) = Format(.sCellLTParams.LTData.dCurrentDensity, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).dCurrentDensity, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminance_Fill_cdm2
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.dLumi_Fill_Cd_m2, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminance_cdm2
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.dLumi_Cd_m2, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminanace_Per
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.dLumi_Percent, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eCurrentEfficiency
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.dLumi_Cd_A, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrentEfficiency_Per
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.dLumi_Cd_A_Percent, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eQE
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.dQE, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEx
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.sSpectrometerData.D6.s3xx, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEy
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.sSpectrometerData.D6.s4yy, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEu
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.sSpectrometerData.D6.s5uu, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEv
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.sSpectrometerData.D6.s6vv, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eDeltauv
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.dDeltaudvd, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCCT
                            sData(i) = .sCellLTParams.GreenLTData(Point).opticalData.sSpectrometerData.D4.s3KelvinT
                        Case frmOptionWindow.eLTDataIndex.eSpectrumSum_Per
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.dSpectrumSum_Per, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eELMax
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.dELMax, "0.0")
                        Case frmOptionWindow.eLTDataIndex.eFHWM
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.dFWHM, "0.0")
                        Case frmOptionWindow.eLTDataIndex.eCHNum
                            sData(i) = "CH" & .sCellLTParams.dCHNum & "-" & (Point + 1)
                        Case frmOptionWindow.eLTDataIndex.eLuminance_Fill_Per
                            sData(i) = Format(.sCellLTParams.GreenLTData(Point).opticalData.dLumi_Percent, "0.00")
                    End Select
                Next
            End With
        Catch ex As Exception

        End Try
        Return True
    End Function

    Public Function ConvertLTDataToArray_BLUE(ByVal Data As frmMain.sMeasureParams, ByVal dHourPassed As String, ByVal dTime As String, ByVal Point As Integer, ByRef sData() As String) As Boolean
        Try
            With Data
                ReDim sData(g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItemName.Length - 1)
                For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItemName.Length - 1
                    Select Case g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItems(i)
                        Case frmOptionWindow.eLTDataIndex.eEmpty
                            sData(i) = "0"
                        Case frmOptionWindow.eLTDataIndex.eHourPass
                            sData(i) = dHourPassed
                        Case frmOptionWindow.eLTDataIndex.eTime
                            sData(i) = dTime
                        Case frmOptionWindow.eLTDataIndex.eArea
                            sData(i) = Format(.sCellLTParams.dCellArea, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eTemp
                            sData(i) = .dTemp
                        Case frmOptionWindow.eLTDataIndex.eVoltage
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).eletricalData.dVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eDeltaVoltage
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).eletricalData.dDeltaVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eAmplitudeVoltage
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).eletricalData.dHighVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).eletricalData.dCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrent_Per
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).eletricalData.dCurrent_Per, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eDeltaCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dDeltaCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).eletricalData.dDeltaCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eAmplitudeCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dHighCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).eletricalData.dHighCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrentDensity
                            'sData(i) = Format(.sCellLTParams.LTData.dCurrentDensity, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).dCurrentDensity, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminance_Fill_cdm2
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.dLumi_Fill_Cd_m2, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminance_cdm2
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.dLumi_Cd_m2, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminanace_Per
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.dLumi_Percent, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eCurrentEfficiency
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.dLumi_Cd_A, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrentEfficiency_Per
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.dLumi_Cd_A_Percent, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eQE
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.dQE, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEx
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.sSpectrometerData.D6.s3xx, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEy
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.sSpectrometerData.D6.s4yy, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEu
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.sSpectrometerData.D6.s5uu, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEv
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.sSpectrometerData.D6.s6vv, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eDeltauv
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.dDeltaudvd, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCCT
                            sData(i) = .sCellLTParams.BlueLTData(Point).opticalData.sSpectrometerData.D4.s3KelvinT
                        Case frmOptionWindow.eLTDataIndex.eSpectrumSum_Per
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.dSpectrumSum_Per, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eELMax
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.dELMax, "0.0")
                        Case frmOptionWindow.eLTDataIndex.eFHWM
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.dFWHM, "0.0")
                        Case frmOptionWindow.eLTDataIndex.eCHNum
                            sData(i) = "CH" & .sCellLTParams.dCHNum & "-" & (Point + 1)
                        Case frmOptionWindow.eLTDataIndex.eLuminance_Fill_Per
                            sData(i) = Format(.sCellLTParams.BlueLTData(Point).opticalData.dLumi_Percent, "0.00")
                    End Select
                Next
            End With
        Catch ex As Exception

        End Try
        Return True
    End Function

    Public Function ConvertLTDataToArray_BLACK(ByVal Data As frmMain.sMeasureParams, ByVal dHourPassed As String, ByVal dTime As String, ByVal Point As Integer, ByRef sData() As String) As Boolean
        Try
            With Data
                ReDim sData(g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItemName.Length - 1)
                For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItemName.Length - 1
                    Select Case g_SystemOptions.sOptionData.SaveOptions.nDataLTPlotItems(i)
                        Case frmOptionWindow.eLTDataIndex.eEmpty
                            sData(i) = "0"
                        Case frmOptionWindow.eLTDataIndex.eHourPass
                            sData(i) = dHourPassed
                        Case frmOptionWindow.eLTDataIndex.eTime
                            sData(i) = dTime
                        Case frmOptionWindow.eLTDataIndex.eArea
                            sData(i) = Format(.sCellLTParams.dCellArea, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eTemp
                            sData(i) = .dTemp
                        Case frmOptionWindow.eLTDataIndex.eVoltage
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).eletricalData.dVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eDeltaVoltage
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).eletricalData.dDeltaVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eAmplitudeVoltage
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).eletricalData.dHighVoltage, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).eletricalData.dCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrent_Per
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).eletricalData.dCurrent_Per, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eDeltaCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dDeltaCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).eletricalData.dDeltaCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eAmplitudeCurrent
                            ' sData(i) = Format(.sCellLTParams.LTData.eletricalData.dHighCurrent, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).eletricalData.dHighCurrent, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrentDensity
                            'sData(i) = Format(.sCellLTParams.LTData.dCurrentDensity, "0.00000E-0")
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).dCurrentDensity, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminance_Fill_cdm2
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.dLumi_Fill_Cd_m2, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminance_cdm2
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.dLumi_Cd_m2, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eLuminanace_Per
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.dLumi_Percent, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eCurrentEfficiency
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.dLumi_Cd_A, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCurrentEfficiency_Per
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.dLumi_Cd_A_Percent, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eQE
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.dQE, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEx
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.sSpectrometerData.D6.s3xx, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEy
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.sSpectrometerData.D6.s4yy, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEu
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.sSpectrometerData.D6.s5uu, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCIEv
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.sSpectrometerData.D6.s6vv, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eDeltauv
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.dDeltaudvd, "0.000")
                        Case frmOptionWindow.eLTDataIndex.eCCT
                            sData(i) = .sCellLTParams.BlackLTData(Point).opticalData.sSpectrometerData.D4.s3KelvinT
                        Case frmOptionWindow.eLTDataIndex.eSpectrumSum_Per
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.dSpectrumSum_Per, "0.00")
                        Case frmOptionWindow.eLTDataIndex.eELMax
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.dELMax, "0.0")
                        Case frmOptionWindow.eLTDataIndex.eFHWM
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.dFWHM, "0.0")
                        Case frmOptionWindow.eLTDataIndex.eCHNum
                            sData(i) = "CH" & .sCellLTParams.dCHNum & "-" & (Point + 1)
                        Case frmOptionWindow.eLTDataIndex.eLuminance_Fill_Per
                            sData(i) = Format(.sCellLTParams.BlackLTData(Point).opticalData.dLumi_Percent, "0.00")
                    End Select
                Next
            End With
        Catch ex As Exception

        End Try
        Return True
    End Function

    Public Function ConvertIVLDataToArray(ByVal Data As frmMain.sCellIVLMeasure, ByVal nSweepPoint As Integer, ByRef sData() As String, ByRef ChkIVL As Boolean) As Boolean
        Try
            With Data
                'If .nMeasMode = ucDispRcpIVLSweep.eMeasureItems.eIVL Then
                '    ChkIVL = True
                'End If

                '10개로 선언은 뒤에 10개 짜르기 위함 (임시방편임)
                'ReDim sData(g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems.Length - 1)
                ReDim sData(g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems.Length - 1)
                '  For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems.Length - 1
                For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems.Length - 1
                    Select Case g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems(i)
                        Case frmOptionWindow.eIVLDataIndex.eEmpty
                            sData(i) = "0"
                        Case frmOptionWindow.eIVLDataIndex.eNo
                            sData(i) = nSweepPoint + 1
                        Case frmOptionWindow.eIVLDataIndex.eMode
                            sData(i) = .nMeasMode
                        Case frmOptionWindow.eIVLDataIndex.eArea
                            sData(i) = Format(.dArea_cm, "0.0000")
                            'Case frmOptionWindow.eIVLDataIndex.eTemperature
                            '    sData(i) = .dTemperature
                        Case frmOptionWindow.eIVLDataIndex.eVoltage
                            sData(i) = .dVoltage
                        Case frmOptionWindow.eIVLDataIndex.eCurrent
                            sData(i) = .dCurrent
                        Case frmOptionWindow.eIVLDataIndex.eABSCurrent
                            sData(i) = .dABS_I
                        Case frmOptionWindow.eIVLDataIndex.eLuminance_Fill
                            sData(i) = .dLuminance_Fill_Cdm2
                        Case frmOptionWindow.eIVLDataIndex.eLuminance
                            '휘도값이 있으면 IVL 모드라고 판단
                            sData(i) = .dLuminance_Cdm2
                            If .dLuminance_Cdm2 <> 0.0 Then
                                ChkIVL = True
                            End If
                        Case frmOptionWindow.eIVLDataIndex.eCIEx
                            sData(i) = Format(.dCIEx, "0.000")
                        Case frmOptionWindow.eIVLDataIndex.eCIEy
                            sData(i) = Format(.dCIEy, "0.000")
                        Case frmOptionWindow.eIVLDataIndex.eCCT
                            sData(i) = .dCCT
                        Case frmOptionWindow.eIVLDataIndex.eCurrentEfficiency
                            sData(i) = .dCdA
                        Case frmOptionWindow.eIVLDataIndex.eJ
                            sData(i) = .dJ
                        Case frmOptionWindow.eIVLDataIndex.eCIEu
                            sData(i) = Format(.dCIEu, "0.000")
                        Case frmOptionWindow.eIVLDataIndex.eCIEv
                            sData(i) = Format(.dCIEv, "0.000")
                        Case frmOptionWindow.eIVLDataIndex.ePowerEfficiency
                            sData(i) = .dlmW
                        Case frmOptionWindow.eIVLDataIndex.eAbsJ
                            sData(i) = .dAbs_J
                        Case frmOptionWindow.eIVLDataIndex.eQE
                            sData(i) = .dQE
                            'Case frmOptionWindow.eIVLDataIndex.eBR_Red
                            '    sData(i) = .sMeteralValue.sRed.dBrightnessRequirements
                            'Case frmOptionWindow.eIVLDataIndex.eBR_Green
                            '    sData(i) = .sMeteralValue.sGreen.dBrightnessRequirements
                            'Case frmOptionWindow.eIVLDataIndex.eBR_Blue
                            '    sData(i) = .sMeteralValue.sBlue.dBrightnessRequirements
                            'Case frmOptionWindow.eIVLDataIndex.eBR_White
                            '    sData(i) = .sMeteralValue.sWhite.dBrightnessRequirements
                            'Case frmOptionWindow.eIVLDataIndex.eLR_Red
                            '    sData(i) = .sMeteralValue.sRed.dLuminanceRatio
                            'Case frmOptionWindow.eIVLDataIndex.eLR_Green
                            '    sData(i) = .sMeteralValue.sGreen.dLuminanceRatio
                            'Case frmOptionWindow.eIVLDataIndex.eLR_Blue
                            '    sData(i) = .sMeteralValue.sBlue.dLuminanceRatio
                            'Case frmOptionWindow.eIVLDataIndex.eLR_White
                            '    sData(i) = .sMeteralValue.sWhite.dLuminanceRatio
                        Case frmOptionWindow.eIVLDataIndex.eFWHM
                            sData(i) = .dFWHM
                        Case frmOptionWindow.eIVLDataIndex.eX
                            sData(i) = .dX
                        Case frmOptionWindow.eIVLDataIndex.eY
                            sData(i) = .dY
                        Case frmOptionWindow.eIVLDataIndex.eZ
                            sData(i) = .dZ
                        Case frmOptionWindow.eIVLDataIndex.eLe
                            sData(i) = .dLe
                        Case frmOptionWindow.eIVLDataIndex.eDuv
                            sData(i) = .dDelta_CIE1960
                        Case frmOptionWindow.eIVLDataIndex.eViewingAngle
                            sData(i) = .dAngle
                            'Case frmOptionWindow.eIVLDataIndex.eELmaxIntensity
                            '    sData(i) = .dWavePeakValue
                            'Case frmOptionWindow.eIVLDataIndex.eELmax
                            '    sData(i) = .nWavePeaklength
                            'Case frmOptionWindow.eIVLDataIndex.eCRI
                            '    sData(i) = .dCRI
                            'Case frmOptionWindow.eIVLDataIndex.eDuprimevprime
                            '    sData(i) = .dDelta_CIE1976
                            'Case frmOptionWindow.eIVLDataIndex.eTime
                            '    sData(i) = .time
                            'Case frmOptionWindow.eIVLDataIndex.ePeak1_Integral
                            '    sData(i) = .dPeak1_Integ
                            'Case frmOptionWindow.eIVLDataIndex.ePeak2_Integral
                            '    sData(i) = .dPeak2_Integ
                            'Case frmOptionWindow.eIVLDataIndex.ePeak1_Integral_Relative
                            '    sData(i) = .dPeak1_Integral_Relative
                            'Case frmOptionWindow.eIVLDataIndex.ePeak2_Integral_Relative
                            '    sData(i) = .dPeak2_Integral_Relative
                            'Case frmOptionWindow.eIVLDataIndex.ePeak1_Lamda
                            '    sData(i) = .dPeak1_Lamda
                            'Case frmOptionWindow.eIVLDataIndex.ePeak2_Lamda
                            '    sData(i) = .dPeak2_Lamda
                            'Case frmOptionWindow.eIVLDataIndex.ePeak1_Lamda_Relative
                            '    sData(i) = .dPeak1_Lamda_Relative
                            'Case frmOptionWindow.eIVLDataIndex.ePeak2_Lamda_Relative
                            '    sData(i) = .dPeak2_Lamda_Relative

                    End Select
                Next
            End With
        Catch ex As Exception
            sData = Nothing
            Return False
        End Try

        Return True
    End Function

    'Public Function ConvertIVLDataToArrayList(ByVal Data As frmMain.sCellIVLMeasure, ByVal measCnt As Integer, ByRef sData() As String) As Boolean
    '    Try
    '        With Data
    '            ReDim sData(g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems.Length - 1)
    '            For i As Integer = 0 To g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems.Length - 1
    '                Select Case g_SystemOptions.sOptionData.SaveOptions.nDataIVLPlotItems(i)
    '                    Case frmOptionWindow.eIVLDataIndex.eNo
    '                        sData(i) = measCnt + 1
    '                    Case frmOptionWindow.eIVLDataIndex.eMode
    '                        sData(i) = .nMeasMode.ToString
    '                    Case frmOptionWindow.eIVLDataIndex.eArea
    '                        sData(i) = .dArea_cm
    '                    Case frmOptionWindow.eIVLDataIndex.eTemperature
    '                        sData(i) = .dTemperature
    '                    Case frmOptionWindow.eIVLDataIndex.eVoltage
    '                        sData(i) = .dVoltage
    '                    Case frmOptionWindow.eIVLDataIndex.eCurrent
    '                        sData(i) = .dCurrent
    '                    Case frmOptionWindow.eIVLDataIndex.eLuminance
    '                        sData(i) = .dCdm2
    '                    Case frmOptionWindow.eIVLDataIndex.eCIEx
    '                        sData(i) = .dCIEx
    '                    Case frmOptionWindow.eIVLDataIndex.eCIEy
    '                        sData(i) = .dCIEy
    '                    Case frmOptionWindow.eIVLDataIndex.eCCT
    '                        sData(i) = .dCCT
    '                    Case frmOptionWindow.eIVLDataIndex.eCurrentEfficiency
    '                        sData(i) = .dCdA
    '                    Case frmOptionWindow.eIVLDataIndex.eJ
    '                        sData(i) = .dJ
    '                    Case frmOptionWindow.eIVLDataIndex.eCIEu
    '                        sData(i) = .dCIEu
    '                    Case frmOptionWindow.eIVLDataIndex.eCIEv
    '                        sData(i) = .dCIEv
    '                    Case frmOptionWindow.eIVLDataIndex.ePowerEfficiency
    '                        sData(i) = .dlmW
    '                    Case frmOptionWindow.eIVLDataIndex.eAbsJ
    '                        sData(i) = .dAbs_J
    '                    Case frmOptionWindow.eIVLDataIndex.eQE
    '                        sData(i) = .dQE
    '                End Select
    '            Next
    '            'sData(0) = measCnt + 1
    '            'sData(1) = .nMeasMode.ToString
    '            'sData(2) = .dArea_cm
    '            'sData(3) = .dTemperature
    '            'sData(4) = .dVoltage
    '            'sData(5) = .dCurrent
    '            'sData(6) = .dJ
    '            'sData(7) = .dAbs_J
    '            'sData(8) = .dCdm2
    '            'sData(9) = .dCdA
    '            'sData(10) = .dlmW
    '            'sData(11) = .dQE
    '            'sData(12) = .dCIEx
    '            'sData(13) = .dCIEy
    '            'sData(14) = .dCIEu
    '            'sData(15) = .dCIEv
    '            'sData(16) = .dCCT

    '        End With
    '    Catch ex As Exception
    '        sData = Nothing
    '        Return False
    '    End Try

    '    Return True

    'End Function

    Private Sub SaveHeaderInfoOfPannelLifetime(ByVal idx As Integer, ByVal sCommon As ucDispRcpLifetime.sLifetimeCommonInfos, ByVal sPanelInfos As ucDispSignalGenerator.sSGDatas)
        Dim sTemp(8) As String
        Dim cntLine As Integer = 0
        Dim sHeaders As String = "ELVDD V,ELVDD I,ELVSS V,ELVSS I,Temp,Luminance(%),Luminance(cd/m2),X,Y,Z,x,y,u,v"

        'Title
        ReDim sTemp(cntLine)
        sTemp(cntLine) = sReportTitle_Lifetime & g_strFileVer : cntLine += 1
        ReDim Preserve sTemp(cntLine)
        sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

        With sCommon

            'Test Condition"
            ReDim Preserve sTemp(cntLine)
            sTemp(cntLine) = m_SeqInfo.sCommon.saveInfo.strOnlyFName : cntLine += 1 'Ch 번호 앞에서 처리하게 변경. 2013-04-22 승현 "Ch" & m_SeqInfo.CommSettings.SavePathInfo.strOnlyFName : cntLine += 1
            ReDim Preserve sTemp(cntLine)
            sTemp(cntLine) = "Meas. Mode :" & "," & "[" & sMeasMode(sCommon.nMode) & "]" : cntLine += 1

            For i As Integer = 0 To sPanelInfos.sParamData.Length - 1

                If sPanelInfos.sParamData(i).eSignal = ucDispSignalGenerator.ePGSignal.MainPower1 Then
                    If sPanelInfos.sParamData(i).eSrcMode = CDevSG.eDacMode.eDCMode Then
                        ReDim Preserve sTemp(cntLine)
                        sTemp(cntLine) = "Bias" & i & " :" & "," & "[" & sPanelInfos.sParamData(i).dBias & "]" : cntLine += 1
                    ElseIf sPanelInfos.sParamData(i).eSrcMode = CDevSG.eDacMode.ePulseMode Then
                        ReDim Preserve sTemp(cntLine)
                        sTemp(cntLine) = "Bias" & i & " :" & "," & "[" & sPanelInfos.sParamData(i).dBias & "]" : cntLine += 1
                        ReDim Preserve sTemp(cntLine)
                        sTemp(cntLine) = "Amplitude" & i & " :" & "," & "[" & sPanelInfos.sParamData(i).dAmplitude & "]" : cntLine += 1

                        ReDim Preserve sTemp(cntLine)
                        sTemp(cntLine) = "Pulse Delay" & i & " :" & "," & "[" & sPanelInfos.sParamData(i).sPulse.Delay & "]" : cntLine += 1
                        ReDim Preserve sTemp(cntLine)
                        sTemp(cntLine) = "Period" & i & " :" & "," & "[" & sPanelInfos.sParamData(i).sPulse.Period & "]" : cntLine += 1
                        ReDim Preserve sTemp(cntLine)
                        sTemp(cntLine) = "width" & i & " :" & "," & "[" & sPanelInfos.sParamData(i).sPulse.Width & "]" : cntLine += 1
                    End If
                End If

                If sPanelInfos.sParamData(i).eSignal = ucDispSignalGenerator.ePGSignal.MainPower2 Then
                    If sPanelInfos.sParamData(i).eSrcMode = CDevSG.eDacMode.eDCMode Then
                        ReDim Preserve sTemp(cntLine)
                        sTemp(cntLine) = "Bias" & i & " :" & "," & "[" & sPanelInfos.sParamData(i).dBias & "]" : cntLine += 1
                    ElseIf sPanelInfos.sParamData(i).eSrcMode = CDevSG.eDacMode.ePulseMode Then
                        ReDim Preserve sTemp(cntLine)
                        sTemp(cntLine) = "Bias" & i & " :" & "," & "[" & sPanelInfos.sParamData(i).dBias & "]" : cntLine += 1
                        ReDim Preserve sTemp(cntLine)
                        sTemp(cntLine) = "Amplitude" & i & " :" & "," & "[" & sPanelInfos.sParamData(i).dAmplitude & "]" : cntLine += 1
                        ReDim Preserve sTemp(cntLine)
                        sTemp(cntLine) = "Pulse Delay" & i & " :" & "," & "[" & sPanelInfos.sParamData(i).sPulse.Delay & "]" : cntLine += 1
                        ReDim Preserve sTemp(cntLine)
                        sTemp(cntLine) = "Period" & i & " :" & "," & "[" & sPanelInfos.sParamData(i).sPulse.Period & "]" : cntLine += 1
                        ReDim Preserve sTemp(cntLine)
                        sTemp(cntLine) = "width" & i & " :" & "," & "[" & sPanelInfos.sParamData(i).sPulse.Width & "]" : cntLine += 1
                    End If
                End If

            Next

            ReDim Preserve sTemp(cntLine)
            sTemp(cntLine) = "Measurement Point : " & sCommon.sMeasPoints.MeasPoint.Length

            ReDim Preserve sTemp(cntLine)
            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란



            ReDim Preserve sTemp(cntLine)
            sTemp(cntLine) = " , , "
            For i As Integer = 0 To sCommon.sMeasPoints.MeasPoint.Length - 1
                sTemp(cntLine) += "P" & Format(i + 1, "00") & ", , , , , , , , , , , , ,"
            Next
            cntLine += 1
            'ELVDD I, ELVSS I, PD I, ELVDD Temp, ELVSS Temp
            ReDim Preserve sTemp(cntLine)
            sTemp(cntLine) = "[Hour Pass(hrs)]" & "," & "[Time]" & ","
            For i As Integer = 0 To sCommon.sMeasPoints.MeasPoint.Length - 1
                sTemp(cntLine) += sHeaders & ","
            Next
            cntLine += 1

        End With

        ReDim Preserve sTemp(cntLine - 1)

        WriteFile(iResultDataNumber, m_sSavePath_LT(idx), sTemp)

        Try
            File.Copy(m_sSavePath_LT(idx), m_sSavePath_LT_Backup(idx), True)
        Catch ex As Exception

            'MsgBox("SaveHeaderInfo" & ex.Message)
        End Try

    End Sub

    Private Sub SaveHeaderInfoOfModuleLifetime(ByVal idx As Integer, ByVal sCommon As ucDispRcpLifetime.sLifetimeCommonInfos, ByVal sModuleInfos As frmPatternGeneratorSetting.sPGInfos)
        Dim sTemp(29) As String
        Dim cntLine As Integer = 0

        'Title
        sTemp(cntLine) = sReportTitle_Lifetime & g_strFileVer : cntLine += 1
        sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

        With sCommon

            'Test Condition"
            sTemp(cntLine) = m_SeqInfo.sCommon.saveInfo.strOnlyFName : cntLine += 1 'Ch 번호 앞에서 처리하게 변경. 2013-04-22 승현 "Ch" & m_SeqInfo.CommSettings.SavePathInfo.strOnlyFName : cntLine += 1

            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

            Dim measPatternIdx() As Integer = Nothing
            Dim patternCnt As Integer
            For i As Integer = 0 To sModuleInfos.sImageInfos.measImage.Length - 1
                If sModuleInfos.sImageInfos.measImage(i).bIsSelected = True Then
                    ReDim Preserve measPatternIdx(patternCnt)
                    measPatternIdx(patternCnt) = i
                    patternCnt += 1
                End If
            Next
            sTemp(cntLine) = "Number of measurement pattern :," & CStr(patternCnt) : cntLine += 1
            sTemp(cntLine) = "Number of measurement point :," & sCommon.sMeasPoints.MeasPoint.Length.ToString : cntLine += 1

            sTemp(cntLine) = "Measurement Point(X_Y) : ,"
            For i As Integer = 0 To sCommon.sMeasPoints.MeasPoint.Length - 1
                sTemp(cntLine) = sTemp(cntLine) & Format(sCommon.sMeasPoints.MeasPoint(i).X, "0.000") & "_" & Format(sCommon.sMeasPoints.MeasPoint(i).Y, "0.000") & ","
            Next
            cntLine += 1


            sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

            sTemp(cntLine) = "[Hour Pass(hrs)]" & "," & "[Hour Pass(min)]" & "," & "[Time(MM/DD/YY hh:mm:ss)]"   ': cntLine += 1  'Viewer Parsing으로 인해 PDCurr <->Lumi 변경 by CJS 20130703

            For patternIdx As Integer = 0 To measPatternIdx.Length - 1
                sTemp(cntLine) = sTemp(cntLine) & "," & "[Image" & Format(patternIdx, "00") & "_IDD(mA)]"
                sTemp(cntLine) = sTemp(cntLine) & "," & "[Image" & Format(patternIdx, "00") & "_ICI(mA)]"
                sTemp(cntLine) = sTemp(cntLine) & "," & "[Image" & Format(patternIdx, "00") & "_IBAT(mA)]"

                For ptIdx As Integer = 0 To sCommon.sMeasPoints.MeasPoint.Length - 1
                    sTemp(cntLine) = sTemp(cntLine) & "," & _
                        "[Image" & Format(patternIdx, "00") & "_P" & Format(ptIdx, "00") & "_Luminance(cd/m2)]," & _
                        "[Image" & Format(patternIdx, "00") & "_P" & Format(ptIdx, "00") & "_CIE1931 x]," & _
                        "[Image" & Format(patternIdx, "00") & "_P" & Format(ptIdx, "00") & "_CIE1931 y]," & _
                        "[Image" & Format(patternIdx, "00") & "_P" & Format(ptIdx, "00") & "_CCT]," & _
                        "[Image" & Format(patternIdx, "00") & "_P" & Format(ptIdx, "00") & "_MPCD]," & _
                        "[Image" & Format(patternIdx, "00") & "_P" & Format(ptIdx, "00") & "_u']," & _
                        "[Image" & Format(patternIdx, "00") & "_P" & Format(ptIdx, "00") & "_v']," & _
                        "[Image" & Format(patternIdx, "00") & "_P" & Format(ptIdx, "00") & "_Luminance(%)] "  ' & _
                    '"[Image" & Format(patternIdx, "00") & "_P" & Format(ptIdx, "00") & "_pt_x]," & _
                    '"[Image" & Format(patternIdx, "00") & "_P" & Format(ptIdx, "00") & "_pt_y]," & _
                    '"[Image" & Format(patternIdx, "00") & "_P" & Format(ptIdx, "00") & "_CMD_pt_x]," & _
                    '"[Image" & Format(patternIdx, "00") & "_P" & Format(ptIdx, "00") & "_CMD_pt_y]"

                    'LEX_20141208_pt x y  
                Next
            Next

            sTemp(cntLine) = sTemp(cntLine) : cntLine += 1


        End With

        ReDim Preserve sTemp(cntLine - 1)

        WriteFile(iResultDataNumber, m_sSavePath_LT(idx), sTemp)

        Try
            File.Copy(m_sSavePath_LT(idx), m_sSavePath_LT_Backup(idx), True)
        Catch ex As Exception

            'MsgBox("SaveHeaderInfo" & ex.Message)
        End Try

    End Sub

    Private Function SaveHeaderInfoOfImageSticking(ByVal idx As Integer, ByVal sTestInfo As ucSequenceBuilder.sRcpPatternMeasure) As Boolean

        Dim sTemp() As String
        Dim cntLine As Integer = 0
        Dim sCommonHeaders As String = "No,Total Time(Hour),Date,Burn-in Time(Hour)"
        Dim sPointHeaders() As String = New String() {"Luminance(cd/m2)", "X", "Y", "Z", "x", "y", "u'", "v'", "Message"}
        Dim sResultHeaders As String = "Rimg, Tr, Remark"
        If m_SeqInfo.sRecipes(idx).nMode <> ucSequenceBuilder.eRcpMode.eModule_ImageSticking Then Return False

        'Title
        ReDim sTemp(cntLine)
        sTemp(cntLine) = sReportTitle_ImageSticking & g_strFileVer : cntLine += 1
        ReDim Preserve sTemp(cntLine)
        sTemp(cntLine) = "[Image Sticking Data]" : cntLine += 1
        ReDim Preserve sTemp(cntLine)
        sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

        ReDim Preserve sTemp(cntLine)
        sTemp(cntLine) = "Measurement Points : ," & sTestInfo.sMeasPoints.MeasPoint.Length : cntLine += 1


        ReDim Preserve sTemp(cntLine)
        sTemp(cntLine) = "" : cntLine += 1 '구분용 공란


        ReDim Preserve sTemp(cntLine)
        sTemp(cntLine) = sCommonHeaders
        For i As Integer = 0 To sTestInfo.sMeasPoints.MeasPoint.Length - 1
            For n As Integer = 0 To sPointHeaders.Length - 1
                sTemp(cntLine) = sTemp(cntLine) & "," & "P" & Format(i + 1, "0") & "_" & sPointHeaders(n)
            Next
        Next
        sTemp(cntLine) = sTemp(cntLine) & "," & sResultHeaders
        cntLine += 1


        ReDim Preserve sTemp(cntLine - 1)

        'WriteFile(2, m_sSavePath_Backup(idx), sTemp)

        'Try
        '    File.Copy(m_sSavePath_Backup(idx), m_sSavePath(idx), True)
        'Catch ex As Exception
        '    'MsgBox("SaveHeaderInfo" & ex.Message)
        'End Try

        Return True
    End Function

#End Region

    Private Function WriteFile(ByVal iFileNum As Integer, ByVal FilePath As String, ByVal sMsg() As String) As Boolean

        Dim newfilepath As String = ""
        newfilepath = FilePath
        Dim sr As StreamWriter
        Try
            ' FileOpen(iFileNum, newfilepath, OpenMode.Append, OpenAccess.Write, OpenShare.Shared) '파일을 열고
            sr = New StreamWriter(newfilepath, True)
        Catch ex As Exception

            '  FileClose(iFileNum)
            sr.Close()
            Return False
        End Try
        Threading.Thread.Sleep(100)
        Try
            For i As Integer = 0 To sMsg.Length - 1
                '  PrintLine(iFileNum, sMsg(i))
                sr.WriteLine(sMsg(i))
            Next
        Catch ex As Exception
            sr.Close()
            ' FileClose(iFileNum)
        End Try


        '파일에 쓰고
        sr.Close()
        ' FileClose(iFileNum)
        Return True
        'Dim newfilepath As String = ""
        'newfilepath = FilePath

        'Try
        '    FileOpen(iFileNum, newfilepath, OpenMode.Append, OpenAccess.Write, OpenShare.Shared) '파일을 열고
        'Catch ex As Exception
        '    ' Log_System("[WriteFile() :: mdlLog][Message : " & ex.Message.ToString & "][File Num = " & CStr(iFileNum) & "][File Path = " & newfilepath & " ]")
        '    FileClose(iFileNum)
        '    Return False
        'End Try
        'Threading.Thread.Sleep(100)
        'Try
        '    For i As Integer = 0 To sMsg.Length - 1
        '        PrintLine(iFileNum, sMsg(i))
        '    Next
        'Catch ex As Exception
        '    FileClose(iFileNum)
        'End Try


        ''파일에 쓰고
        'FileClose(iFileNum)
        'Return True
    End Function

    Private Function WriteFile(ByVal iFileNum As Integer, ByVal FilePath As String, ByVal strMsg As String) As Boolean

        Dim newfilepath As String = ""
        newfilepath = FilePath
        Dim sr As StreamWriter
        Try
            sr = New StreamWriter(newfilepath, True)
            ' FileOpen(iFileNum, newfilepath, OpenMode.Append, OpenAccess.Write, OpenShare.Shared) '파일을 열고
        Catch ex As Exception
            sr.Close()
            '  FileClose(iFileNum)
            Return False
        End Try

        Threading.Thread.Sleep(100)
        Try
            sr.WriteLine(strMsg)
            ' PrintLine(iFileNum, strMsg)
        Catch ex As Exception
            'FileClose(iFileNum)
            sr.Close()
        End Try


        '파일에 쓰고
        sr.Close()
        'FileClose(iFileNum)
        Return True


        'Dim newfilepath As String = ""
        'newfilepath = FilePath

        'Try
        '    FileOpen(iFileNum, newfilepath, OpenMode.Append, OpenAccess.Write, OpenShare.Shared) '파일을 열고
        'Catch ex As Exception
        '    FileClose(iFileNum)
        '    Return False
        'End Try

        'Threading.Thread.Sleep(100)
        'Try
        '    PrintLine(iFileNum, strMsg)
        'Catch ex As Exception
        '    FileClose(iFileNum)
        'End Try


        ''파일에 쓰고
        'FileClose(iFileNum)
        'Return True
    End Function

    Public Function CrateSaveFile(ByVal Path As String) As Boolean

        Dim fs As System.IO.FileStream
        If Directory.Exists(Path) = False Then
            File.Delete(Path)
        End If
        '        If Directory.Exists(Path) = False Then Return False

        fs = File.Create(Path)
        fs.Close()

        Return True
    End Function


    Public Function WriteFile(ByVal Path As String, ByVal sMsg() As String)
        If CrateSaveFile(Path) = False Then Return False
        Try
            FileOpen(1, Path, OpenMode.Append, OpenAccess.Write, OpenShare.Shared)
        Catch ex As Exception
            FileClose(1)
            Return False
        End Try

        For i As Integer = 0 To sMsg.Length - 1
            PrintLine(1, sMsg(i))
        Next

        '파일에 쓰고
        FileClose(1)

        Return True
    End Function




#End Region

#Region "Load"

    'Private Function LoadFile(ByVal iFileNum As Integer, ByVal FilePath As String, ByVal strMsg As String) As Boolean

    '    Dim newfilepath As String = ""
    '    newfilepath = FilePath

    '    Try
    '        FileOpen(iFileNum, newfilepath, OpenMode.Append, OpenAccess.Write, OpenShare.Shared) '파일을 열고
    '    Catch ex As Exception
    '        FileClose(iFileNum)
    '        Return False
    '    End Try

    '    Dim abc As FileStream


    '    PrintLine(iFileNum, strMsg)

    '    '파일에 쓰고
    '    FileClose(iFileNum)
    '    Return True
    'End Function

    'Private Sub LoadHeaderInfo(ByVal FilePath As String, ByRef TestRecipe As ucControlPannel.sTestRecipe)

    '    If FilePath Is Nothing = True Then
    '        Exit Sub
    '    End If

    '    Try
    '        FileOpen(1, FilePath, OpenMode.Append, OpenAccess.Read, OpenShare.Shared) '파일을 열고
    '    Catch ex As Exception
    '        FileClose(1)
    '        Exit Sub
    '    End Try






    '    Dim sTemp(7) As String
    '    Dim cntLine As Integer = 0

    '    'Title
    '    sTemp(cntLine) = g_strMainTitle & g_strVer : cntLine += 1
    '    sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

    '    With TestRecipe.LifeTimeModeParams

    '        'Test Condition"
    '        sTemp(cntLine) = "Ch" & m_SeqInfo.CommSettings.SavePathInfo.strOnlyFName : cntLine += 1
    '        sTemp(cntLine) = "Meas. Mode :" & "," & sMeasMode(.LifeTimeMode) : cntLine += 1
    '        sTemp(cntLine) = "Bias Mode :" & "," & sBiasMode(.sSourceSetting.Mode) : cntLine += 1

    '        Select Case .sSourceSetting.Mode
    '            Case CDevM6000.eMode.eCC Or CDevM6000.eMode.eCV
    '                sTemp(cntLine) = "Bias :" & "," & .sSourceSetting.dBias : cntLine += 1

    '                '    sTemp(cntLine) = 
    '            Case CDevM6000.eMode.ePC Or CDevM6000.eMode.ePV Or CDevM6000.eMode.ePCV
    '                sTemp(cntLine) = "Bias :" & "," & .sSourceSetting.dBias & "," & _
    '                                 "Amplitude :" & "," & .sSourceSetting.dAmplitude & "," & _
    '                                 "Frequency :" & "," & .sSourceSetting.Pulse.dFrequency & "," & _
    '                                 "Duty :" & "," & .sSourceSetting.Pulse.dDuty : cntLine += 1
    '        End Select

    '        sTemp(cntLine) = "" : cntLine += 1 '구분용 공란

    '        Select Case .sSourceSetting.Mode
    '            Case CDevM6000.eMode.eCC Or CDevM6000.eMode.eCV
    '                sTemp(cntLine) = "Time" & "," & "Hour Pass(hrs)" & "," & "Volt(V)" & "," & "Curr(mA)" & "," & _
    '                   "Luminance(%)" & "," & "PDCurr(uA)" & "," & "Temp(℃)" : cntLine += 1
    '            Case CDevM6000.eMode.ePC Or CDevM6000.eMode.ePV Or CDevM6000.eMode.ePCV
    '                sTemp(cntLine) = "Time" & "," & "Hour Pass(hrs)" & "," & "Volt(V)" & "," & "High Volt(V)" & "," & _
    '                 "Curr(mA)" & "," & "High Curr(mA)" & "Luminance(%)" & "," & "PDCurr(uA)" & "," & "Temp(℃)" : cntLine += 1
    '        End Select

    '    End With


    '    WriteFile(iResultDataNumber, m_sSavePath, sTemp)

    '    Try
    '        File.Copy(m_sSavePath_Backup, m_sSavePath, True)
    '    Catch ex As Exception

    '    End Try


    'End Sub

#End Region


#End Region

End Class
