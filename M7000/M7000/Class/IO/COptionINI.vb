Public Class COptionINI
    Inherits cls_INI

    Public Sub New(ByVal INIPath As String)
        path = INIPath
    End Sub


    Private strSection() As String = New String() {"File Info", "Common", "Parameter Range", _
                                                   "Display Unit", "Display Color", "Display Common", _
                                                   "Constant Brightness", "Out Data Display", "Link", _
                                                   "ACF", "LifetimeLimit", "Motion", "CCD", "Temperature", "Spectrometer", "Save Options", "SystemAdmin", "Process", "Check Contact"}

    Private strKey() As String = New String() {"File Title", "FIle Version", _
                                               "PMX Range Low Bias", "PMX Range High Bias", "PMX Range Low Amplitude", "PMX Range High Amplitude", "PMX Range Low Pulse Duty", "PMX Range High Pulse Duty", _
                                               "PMX Range Low Pulse Frequency", "PMX Range High Pulse Frequency", _
                                               "AMX Range Low SubPower", "AMX Range High SubPower", "AMX Range Low Signal", "AMX Range High Signal", "AMX Range Low MainPower", "AMX Range High MainPower", _
                                               "Disp Volt Unit", "Disp Volt Digit", "Disp Current Unit", "Disp Current Digit", "Disp Photourrent Unit", "Disp Photourrent Digit", "Disp Integral Digit", "Disp Integral Relative Digit", _
                                               "Disp Color Num", "Disp Color State", "Disp Color Value", "DISP CH TYPE", _
                                               "Cal Apply", "Degree", "PD Deviation", "Bias Range CC", "Bias Range CV", _
                                               "Num Of Output Data Display(MDX)", _
                                               "Path of data viewer", "Enable data viewer link", _
                                               "ACF Mode", _
                                               "Focusing Region Start", "Focusing Region Stop", "Focusing Scan Resolution", "Focusing Param", "DefThreshold", "Low Intensity Threshold", "High Intensity Threshold", _
                                               "CCD Resolution_Width", "CCD Resolution_High", _
                                               "CCD To Spectrometer Distance X", "CCD To Spectrometer Distance Y", "CCD To Spectrometer Distance Z", _
                                               "CCD To HEXA Distance X", "CCD To HEXA Distance Y", "CCD To HEXA Distance Z", _
                                               "CCD To MCR Distance X", "CCD To MCR Distance Y", "CCD To MCR Distance Z", _
                                               "CCD Position X", "CCD Position Y", "CCD Position Z", _
                                               "Spectrometer Position X", "Spectrometer Position Y", "Spectrometer Position Z", _
                                               "HEXA Position X", "HEXA Position Y", "HEXA Position Z", _
                                               "Blob Filter", "Min Blob Radius", "Pixel per distance(1mm)_Width", "Pixel per distance(1mm)_High", "Low Intensity Limit", "Gray Level Limit", _
                                               "Min Voltage", "Max Voltage", "Min Current", "Max Current", _
                                               "Standard Distance X", "Standard Distance Y", "Standard Distance Z", "Standard Distance Theta Y", "Standard Distance Theta",
                                               "Start Position X", "Start Position Y", "Start Position Z", "Start Position Theta Y", "Start Position Theta",
                                               "End Position X", "End Position Y", "End Position Z", "End Position Theta Y", "End Position Theta", _
                                               "Cal Position X", "Cal Position Y", "Cal Position Z", "Cal Position Theta Y", "Cal Position Theta",
                                               "Position Per Distance X", "Position Per Distance Y", "Position Per Distance Z", "Position Per Distance Theta Y", "Position Per Distance Theta",
                                               "Position Per Distance Use", "Cal Theta Deviation", "Cal Theta Ratio", "Cal Theta Offset", "Cal WAD Factor X", "Cal WAD Factor Y", "Cal WAD Factor Z", _
                                               "CCD Exposure Value", "CCD Image Capture", "CCD Image Capture Level", _
                                               "Temperature Margin", "Temperature Limit Alarm Low", "Temperature Limit Alarm High", _
                                               "Spectrometer Gain IVL", "Spectrometer Gain Lifetime", "Spectrometer Gain Angle", "Spectrometer Aperture IVL", "Spectrometer Speed Mode IVL", "Spectrometer Aperture Sweep", "Spectrometer Speed Mode Sweep", "Spectrometer IVL Exposure Time", "Spectrometer IVL Measure Mode", _
                                               "INTENSITY_ADJ_SOURCEMODE", "INTENSITY_ADJ_BIAS", "INTENSITY_ADJ_STEP", "INTENSITY_ADJ_LIMIT", _
                                               "INTENSITY_ADJ_SETTING_SRC_MODE", "INTENSITY_ADJ_SETTING_WIRE_MODE", "INTENSITY_ADJ_SETTING_SRC_DELAY",
                                               "INTENSITY_ADJ_SETTING_LIMIT_V", "INTENSITY_ADJ_SETTING_LIMIT_I", "INTENSITY_ADJ_SETTING_SRC_AUTORANGE", "INTENSITY_ADJ_SETTING_TERMINAL_MODE",
                                               "INTENSITY_ADJ_SETTING_MEAS_MODE", "INTENSITY_ADJ_SETTING_NUM_OF_MEASDATA", "INTENSITY_ADJ_SETTING_MEAS_DELAY_SEC", "INTENSITY_ADJ_SETTING_INTEG_TIME_SEC", "  INTENSITY_ADJ_SETTING_INTEG_TIME_INDEX",
                                               "INTENSITY_ADJ_SETTING_MEAS_AUTORANGE", "INTENSITY_ADJ_SETTING_MEAS_VAL_TYPE", "INTENSITY_ADJ_SETTING_MEAS_DELAY_AUTO",
                                               "MODULE_CONDITION_PATTERN_NO", "IMAGE_ANALYSIS_MODE",
                                               "SAVE_FILE_NAME_RULE_ADD_CH_NUM", "SAVE_FILE_NAME_RULE_ADD_DATE", "SAVE_FILE_NAME_RULE_ADD_USER_INPUT", "SAVE_FILE_NAME_RULE_ADD_EXP_MODE", "SAVE_FILE_NAME_RULE_TEG_TO_TEGCHANNEL", "SAVE_DEFAULT_PATH", "SAVE_BACKUP_PATH", "SAVE_USED_BACKUP_PATH", "SAVE_SPECTRUM_JIG1_8_PICK1_START", "SAVE_SPECTRUM_JIG1_8_PICK1_END", "SAVE_SPECTRUM_JIG1_8_PICK2_START", "SAVE_SPECTRUM_JIG1_8_PICK2_END", _
                                               "SAVE_SPECTRUM_JIG9_16_PICK1_START", "SAVE_SPECTRUM_JIG9_16_PICK1_END", "SAVE_SPECTRUM_JIG9_16_PICK2_START", "SAVE_SPECTRUM_JIG9_16__PICK2_END", "SAVE_SPECTRUM_JIG17_24_PICK1_START", "SAVE_SPECTRUM_JIG17_24_PICK1_END", "SAVE_SPECTRUM_JIG17_24_PICK2_START", "SAVE_SPECTRUM_JIG17_24_PICK2_END", "SAVE_SPECTRUM_JIG25_32_PICK1_START", "SAVE_SPECTRUM_JIG25_32_PICK1_END", "SAVE_SPECTRUM_JIG25_32_PICK2_START", "SAVE_SPECTRUM_JIG25_32_PICK2_END", _
                                               "SAVE_LUMINANCE_PERCENT_SPECTRUM_DATA_SAVE", "SAVE_LUMINACNE_CORRECTION", "SAVE_FILETYPE", "SAVE_CAL_REAL_CURRENT", _
                                               "SAVE_IVLHEADER_FILEVERSION", "SAVE_IVLHEADER_FILENAME", "SAVE_IVLHEADER_MEASMODE", "SAVE_IVLHEADER_BIASMODE", "SAVE_IVLHEADER_SWEEPMODE", "SAVE_IVLHEADER_LUMINANCEMEASLEVEL", _
                                               "IVLDATA_INDEX_COUNT", "IVLDATA_INDEX", "IVLDATA_INDEX_NAME", _
                                               "SAVE_LTHEADER_FILEVERSION", "SAVE_LTHEADER_FILENAME", "SAVE_LTHEADER_MEASMODE", "SAVE_LTHEADER_BIASMODE", "SAVE_LTHEADER_RENEWALTIME", _
                                               "LTDATA_INDEX_COUNT", "LTDATA_INDEX", "LTDATA_INDEX_NAME", _
                                               "SAVE_VAHEADER_FILEVERSION", "SAVE_VAHEADER_FILENAME", "SAVE_VAHEADER_MEASMODE", "SAVE_VAHEADER_BIASMODE", _
                                               "SAVE_VAHEADER_SWEEPMODE", "VADATA_INDEX_COUNT", "VADATA_INDEX", "VADATA_INDEX_NAME", _
                                                "Admin Password", "LogIn State", " SAFETY_PASS", "Safety LogIn State", "ProcessID", _
                                                "VISIBLE_DISPLAY_CHANNEL_MOVE_BUTTON", "VISIBLE_DISPLAY_ANGLE_MOVE_BUTTON", _
                                                "Sampleinfo_Heigth", "Ssmpleinfo_Width", "Sampleinfo_Fillfactor", _
                                                "MATERIALDATA_RED_CIEx", "MATERIALDATA_RED_CIEy", "MATERIALDATA_RED_APERTURERATIO", "MATERIALDATA_RED_TRANSMITTANCEPOLARIZERS", _
                                                "MATERIALDATA_GREEN_CIEx", "MATERIALDATA_GREEN_CIEy", "MATERIALDATA_GREEN_APERTURERATIO", "MATERIALDATA_GREEN_TRANSMITTANCEPOLARIZERS", _
                                                "MATERIALDATA_BLUE_CIEx", "MATERIALDATA_BLUE_CIEy", "MATERIALDATA_BLUE_APERTURERATIO", "MATERIALDATA_BLUE_TRANSMITTANCEPOLARIZERS", _
                                                "MATERIALDATA_WHITE_CIEx", "MATERIALDATA_WHITE_CIEy", "MATERIALDATA_WHITE_APERTURERATIO", "MATERIALDATA_WHITE_TRANSMITTANCEPOLARIZERS", "MATERIALDATA_WHITE_BRIGHTNESSREQUIREMENTS", _
                                               "CONTACT BIAS", "CONTACT PASS LEVEL", "CONTACT MARGIN"}


    Public Enum eSecID
        eFileInfo
        eCommon
        eParameterRange
        eDisplayUnit
        eDisplayColor
        eDisplayCommon
        eConstantBrightness
        OutDataDisplay_MDX
        eLink
        eACF
        eLifetimeLimit
        eMotion
        eCCD
        eTemperature
        eSpectrometer
        eSaveOptions
        eSystemAdmin
        eProcess
        eCheckContact
    End Enum

    Public Enum eKeyID
        FILE_TITLE       'File Info
        FILE_VERSION
        PMX_RANGE_LOW_BIAS
        PMX_RANGE_HIGH_BIAS
        PMX_RANGE_LOW_AMPLITUDE
        PMX_RANGE_HIGH_AMPLITUDE
        PMX_RANGE_LOW_PULSE_DUTY
        PMX_RANGE_HIGH_PULSE_DUTY
        PMX_RANGE_LOW_PULSE_FREQUENCY
        PMX_RANGE_HIGH_PULSE_FREQUENCY
        AMX_RANGE_LOW_SUBPOWER
        AMX_RANGE_HIGH_SUBPOWER
        AMX_RANGE_LOW_SIGNAL
        AMX_RANGE_HIGH_SIGNAL
        AMX_RANGE_LOW_MAINPOWER
        AMX_RANGE_HIGH_MAINPOWER
        DISP_UNIT_VOLTAGE
        DISP_DIGIT_VOLTAGE
        DISP_UNIT_CURRENT
        DISP_DIGIT_CURRENT
        DISP_UNIT_PHOTOCURRENT
        DISP_DIGIT_PHOTOCURRENT
        DISP_DIGIT_INTEGRAL
        DISP_DIGIT_INTEGRALRELATIVE
        DISP_COLOR_NUM_OF_STATE
        DISP_COLOR_STATE
        DISP_COLOR_VALUE
        DISP_CH_DISP_TYPE
        CONSTANT_B_CAL_APPLY
        CONSTANT_B_DEGREE
        CONSTANT_B_PD_DEVIATION
        CONSTANT_B_BIAS_RANGE_CC
        CONSTANT_B_BIAS_RANGE_CV
        NUMOF_OUTDATA_DISPLAY_MDX
        LINK_PATH_OF_DATA_VIEWER
        LINK_ENABLE_DATA_VIEWER_LINK
        ACF_MODE
        FOCUSING_REGION_START
        FOCUSING_REGION_STOP
        FOCUSING_SCAN_RESOLUTION
        FOCUSING_PARAM
        DEFINE_THRESHOLD
        LOW_INTENSITY_THRESHOLD
        HIGH_INTENSITY_THRESHOLD
        CCD_RESOLUTION_WIDTH
        CCD_RESOLUTION_HIGH
        CCD_TO_SPECTROMETER_DISTANCE_X
        CCD_TO_SPECTROMETER_DISTANCE_Y
        CCD_TO_SPECTROMETER_DISTANCE_Z
        CCD_TO_HEXA_DISTANCE_X 'CCD to HEXA Position
        CCD_TO_HEXA_DISTANCE_Y
        CCD_TO_HEXA_DISTANCE_Z
        CCD_TO_MCR_DISTANCE_X
        CCD_TO_MCR_DISTANCE_Y
        CCD_TO_MCR_DISTANCE_Z
        CCD_POSITION_X
        CCD_POSITION_Y
        CCD_POSITION_Z
        SPECTROMETER_POSITION_X
        SPECTROMETER_POSITION_Y
        SPECTROMETER_POSITION_Z
        HEXA_POSITION_X 'HEXA Position
        HEXA_POSITION_Y
        HEXA_POSITION_Z
        BLOD_FILTER
        MIN_BLOB_RADIUS
        PIXEL_PER_DISTANCE_WIDTH
        PIXEL_PER_DISTANCE_HIGH
        LOW_INTENSITY_LIMIT
        GRAY_LEVEL_LIMIT
        MIN_VOLTAGE
        MAX_VOLTAGE
        MIN_CURRENT
        MAX_CURRENT
        STANDARD_DISTANCE_X
        STANDARD_DISTANCE_Y
        STANDARD_DISTANCE_Z
        STANDARD_DISTANCE_Theta_Y
        STANDARD_DISTANCE_Theta
        START_POSITION_X
        START_POSITION_Y
        START_POSITION_Z
        START_POSITION_Theta_Y
        START_POSITION_Theta
        END_POSITION_X
        END_POSITION_Y
        END_POSITION_Z
        END_POSITION_Theta_Y
        END_POSITION_Theta
        CAL_POSITION_X
        CAL_POSITION_Y
        CAL_POSITION_Z
        CAL_POSITION_Theta_Y
        CAL_POSITION_Theta
        POSITION_PER_DISTANCE_X
        POSITION_PER_DISTANCE_Y
        POSITION_PER_DISTANCE_Z
        POSITION_PER_DISTANCE_Theta_Y
        POSITION_PER_DISTANCE_Theta
        POSITION_PER_DISTANCE_USE
        CAL_THETA_DEVIATION
        CAL_THETA_RATIO
        CAL_THETA_OFFSET
        CAL_WAD_FACTOR_X
        CAL_WAD_FACTOR_Y
        CAL_WAD_FACTOR_Z
        CCD_EXPOSURE_VALUE
        CCD_CAPTURE_IMAGE_PATH
        CCD_CAPTURE_IMAGE_LEVEL
        TEMPERATURE_MARGIN
        TEMPERATURE_LIMIT_ALARM_LOW
        TEMPERATURE_LIMIT_ALARM_HIGH
        SPECTROMETER_GAIN_IVL
        SPECTROMETER_GAIN_LIFETIME
        SPECTROMETER_GAIN_ANGLE
        SPECTROMETER_APERTURE
        SPECTROMETER_SPEEDMODE
        SPECTROMETER_IVL_APERTURE
        SPECTROMETER_IVL_SPEEDMODE
        SPECTROMETER_IVL_EXPOSURETIME
        SPECTROMETER_IVL_MEASUREMODE
        INTENSITY_ADJ_SOURCEMODE
        INTENSITY_ADJ_BIAS
        INTENSITY_ADJ_STEP
        INTENSITY_ADJ_LIMIT
        INTENSITY_ADJ_SETTING_SRC_MODE
        INTENSITY_ADJ_SETTING_WIRE_MODE
        INTENSITY_ADJ_SETTING_SRC_DELAY
        INTENSITY_ADJ_SETTING_LIMIT_V
        INTENSITY_ADJ_SETTING_LIMIT_I
        INTENSITY_ADJ_SETTING_CURRENG_RANGE
        INTENSITY_ADJ_SETTING_TERMINAL_MODE
        INTENSITY_ADJ_SETTING_MEAS_MODE
        INTENSITY_ADJ_SETTING_NUM_OF_MEASDATA
        INTENSITY_ADJ_SETTING_MEAS_DELAY_SEC
        INTENSITY_ADJ_SETTING_INTEG_TIME_SEC
        INTENSITY_ADJ_SETTING_INTEG_TIME_INDEX
        INTENSITY_ADJ_SETTING_VOLTAGE_RANGE
        INTENSITY_ADJ_SETTING_MEAS_VAL_TYPE
        INTENSITY_ADJ_SETTING_MEAS_DELAY_AUTO
        MODULE_CONDITION_PATTERN_NO
        IMAGE_ANALYSIS_MODE
        SAVE_FILE_NAME_RULE_ADD_CH_NUM
        SAVE_FILE_NAME_RULE_ADD_DATE
        SAVE_FILE_NAME_RULE_ADD_USER_INPUT
        SAVE_FILE_NAME_RULE_ADD_EXP_MODE
        SAVE_FILE_NAME_RULE_TEG_TO_TEGCHANNEL
        SAVE_DEFAULT_PATH
        SAVE_BACKUP_PATH
        SAVE_USED_BACKUP_PATH
        SAVE_SPECTRUM_PICK1_START
        SAVE_SPECTRUM_PICK1_END
        SAVE_SPECTRUM_PICK2_START
        SAVE_SPECTRUM_PICK2_END
        SAVE_SPECTRUM_PICK3_START
        SAVE_SPECTRUM_PICK3_END
        SAVE_SPECTRUM_PICK4_START
        SAVE_SPECTRUM_PICK4_END
        SAVE_SPECTRUM_JIG17_24_PICK1_START
        SAVE_SPECTRUM_JIG17_24_PICK1_END
        SAVE_SPECTRUM_JIG17_24_PICK2_START
        SAVE_SPECTRUM_JIG17_24_PICK2_END
        SAVE_SPECTRUM_JIG25_32_PICK1_START
        SAVE_SPECTRUM_JIG25_32_PICK1_END
        SAVE_SPECTRUM_JIG25_32_PICK2_START
        SAVE_SPECTRUM_JIG25_32_PICK2_END
        SAVE_LUMINANCE_PERCENT_SPECTRUM_DATA_SAVE
        SAVE_LUMINACNE_CORRECTION
        SAVE_FILETYPE
        SAVE_CAL_REAL_CURRENT
        SAVE_IVLHEADER_FILEVERSION
        SAVE_IVLHEADER_FILENAME
        SAVE_IVLHEADER_MEASMODE
        SAVE_IVLHEADER_BIASMODE
        SAVE_IVLHEADER_SWEEPMODE
        SAVE_IVLHEADER_LUMINANCEMEASLEVEL
        SAVE_IVLDATAINDEXCOUNT
        SAVE_IVLDATAINDEX
        SAVE_IVLDATAINDEXNAME
        SAVE_LTHEADER_FILEVERSION
        SAVE_LTHEADER_FILENAME
        SAVE_LTHEADER_MEASMODE
        SAVE_LTHEADER_BIASMODE
        SAVE_LTHEADER_RENEWALTIME
        SAVE_LTDATAINDEXCOUNT
        SAVE_LTDATAINDEX
        SAVE_LTDATAINDEXNAME
        SAVE_VAHEADER_FILEVERSION
        SAVE_VAHEADER_FILENAME
        SAVE_VAHEADER_MEASMODE
        SAVE_VAHEADER_BIASMODE
        SAVE_VAHEADER_SWEEPMODE
        SAVE_VADATAINDEXCOUNT
        SAVE_VADATAINDEX
        SAVE_VADATAINDEXNAME
        ADMIN_PASS
        ADMIN_LOGIN_STATUS
        SAFETY_PASS
        SAFETY_LOGIN_STATUS
        PROCESSID
        VISIBLE_DISPLAY_CHANNEL_MOVE_BUTTON
        VISIBLE_DISPLAY_ANGLE_MOVE_BUTTON
        SAMPLEINFO_HEIGHT
        SAMPLEINFO_WIDTH
        SAMPLEINFO_FILLFACTOR
        MATERIALDATA_RED_CIEx
        MATERIALDATA_RED_CIEy
        MATERIALDATA_RED_APERTURERATIO
        MATERIALDATA_RED_TRANSMITTANCEPOLARIZERS
        MATERIALDATA_GREEN_CIEx
        MATERIALDATA_GREEN_CIEy
        MATERIALDATA_GREEN_APERTURERATIO
        MATERIALDATA_GREEN_TRANSMITTANCEPOLARIZERS
        MATERIALDATA_BLUE_CIEx
        MATERIALDATA_BLUE_CIEy
        MATERIALDATA_BLUE_APERTURERATIO
        MATERIALDATA_BLUE_TRANSMITTANCEPOLARIZERS
        MATERIALDATA_WHITE_CIEx
        MATERIALDATA_WHITE_CIEy
        MATERIALDATA_WHITE_APERTURERATIO
        MATERIALDATA_WHITE_TRANSMITTANCEPOLARIZERS
        MATERIALDATA_WHITE_BRIGHTNESSREQUIREMENTS
        CONTACT_BIAS
        CONTACT_PASSLV
        CONTACT_MARGIN
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

        If nSection = eSecID.eFileInfo Then
            sSection = strSection(nSection)
        Else
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        End If

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

        If nSection = eSecID.eFileInfo Then
            sSection = strSection(nSection)
        Else
            sSection = strSection(nSection) & Format(rcpSectionIndex + 1, "00")
        End If

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

