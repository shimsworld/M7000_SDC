using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Security.AccessControl;


namespace G4xHMI
{
    public enum UpdateSection
    {
        START       = 0x01,
        STOP        = 0x02,
        CONTINUE    = 0x03
    }

    public enum ControlDevice
    {
        POWER_ON        = 0x11,
        POWER_OFF       = 0x12,
        DISPLAY_ON      = 0x13,
        DISPLAY_OFF     = 0x14,
        PATTERN_ON      = 0x15,
        PATTERN_OFF     = 0x16,
        PATTERN_NEXT    = 0x17,
        PATTERN_PREV    = 0x18,
        PATTERN_CHANGE  = 0x19,
        NAND_FORMAT     = 0x21,
        CTSP_ON         = 0x31,
        CTSP_OFF        = 0x31,
        START           = 0x41,
        AUTO            = 0x42,
        PREV            = 0x43,
        NEXT            = 0x44,
        START_LONG      = 0x51,
        AUTO_LONG       = 0x52,
        PREV_LONG       = 0x53,
        NEXT_LONG       = 0x54
    }
    public enum G5Interface
    {
        REQUEST_STATUS = 0x01,
        REQUEST_TOUCH = 0x02,
        REQUEST_PATTERN = 0x11,
        REQUEST_MODULE = 0x12,
        REQUEST_POWERON = 0x13,
        REQUEST_POWEROFF = 0x14,
        UPDATE_PATTERN_LIST = 0x21,
        UPDATE_MODULE = 0x22,
        UPDATE_POWERON = 0x23,
        UPDATE_POWEROFF = 0x24,
        UPDATE_INIT_CODE_NAME = 0x25,
        UPDATE_MODULE_NAME = 0x26,
        UPDATE_PATTERN_LIST_NAME = 0x27,
        UPDATE_PATTERN_LIST_NAME2 = 0x29,
        UPDATE_PATTERN_LIST2 = 0x2A,
        CONTROL_DEVICE = 0x31,
        CURRENT_CONTROL = 0x32, // CURRENT CONTROL : G4S Added
        MULTI_RACK_CONTROL = 0x33, // Multi Rack CONTROLL : G4S Added
        UPDATE_IMAGE = 0x41,
        UPDATE_FIRMWARE = 0x42,
        UPDATE_FPGR = 0x43,
        UPDATE_CONFIG = 0x51,     //Config Data
        FWUPGRADE_CMD = 0x61, // FW-UPGRADE
        FWUPGRADE_IMG = 0x62, // FW-UPGRADE
        GNTICMD_CTL = 0x63, // GNT-I (GnT system Interpreter)
    }


    public enum G5InterfaceAck
    {
        REQUEST_STATUS      = 0x81,
        REQUEST_TOUCH       = 0x82,
        REQUEST_PATTERN     = 0x91,
        REQUEST_MODULE      = 0x92,
        REQUEST_POWERON     = 0x93,
        REQUEST_POWEROFF    = 0x94,
        UPDATE_PATTERN      = 0xA1,
        UPDATE_MODULE       = 0xA2,
        UPDATE_POWERON      = 0xA3,
        UPDATE_POWEROFF     = 0xA4,
        CONTROL_DEVICE      = 0xB1,
        CURRENT_CONTROL     = 0xB2, // CURRENT CONTROL : G4S Added
        MULTI_RACK_CONTROL  = 0xB3, // Multi Rack CONTROLL : G4S Added
        UPDATE_IMAGE        = 0xC1,
        UPDATE_FIRMWARE     = 0xC2,
        UPDATE_FPGR         = 0xC3,
        UPDATE_CONFIG       = 0xD1,
        FWUPGRADE_REQ       = 0xD2, // FW-UPGRADE
        GNTICMD_REQ         = 0xE3, // GNT-I (GnT system Interpreter)
    }

    public enum G5InterfaceUpgrade    // FW-UPGRADE
    {
        START_UPGRADE   = 0x01,
        IAP_READY       = 0x02,
        FLASH_ERASE     = 0x03,
        RECV_READY      = 0x04,
        SEND_START      = 0x05,
        DATA            = 0x06,
        CRC             = 0x07,
        RESET           = 0x08,
        STATUS          = 0x09,
        DONE            = 0x0A,

        EXPIRE_TIMEOUT  = 0xB0,

        RES_CRC_OK      = 0x81,
        RES_CRC_ERR     = 0x82,
        RES_ERASE_ERR   = 0x83,
        RES_WRITE_ERR   = 0x84,
        RES_CMD_TIMEOUT = 0x85,
    }

    public enum G5InterfaceGNTScenario  // GNT-I (GnT system Interpreter)
    {
        START       = 0x01,
        SEND_START  = 0x02,
        DATA        = 0x03,
        CRC         = 0x04,
        DONE        = 0x05,
        VER_CHECK   = 0x06,
        GET_TEXT    = 0x07,
        GET_CODE    = 0x08,
        GET_MAKE_TEXT   = 0x09,
        MAKE_CODE   = 0x0A,
        EXPIRE_TIMEOUT  = 0xB0,
        CRC_OK      = 0x81,
        CRC_ERR     = 0x82,
        ERASE_ERR   = 0x83,
        WRITE_ERR   = 0x84,
        TIMEOUT_ERR = 0x85,
        MAKE_CODE_OK    = 0x86,
        MAKE_CODE_ERR   = 0x87,
    }

    public enum G5InterfaceCurrentConrol    // Current Control
    {
        CALI_GAIN_START         = 0x1,    /* GAIN CALIBRATION : correct RS(9.998) ohm. */
        CALI_MEAS_CURRENT       = 0x2,    /* current measure auto uA/mA */
        CALI_RAW_MEAS_CURRENT   = 0x3,    /* none. calibration current measure data */
        CALI_RSP_DONE           = 0x4,
        CALI_RSP_NO_POWER       = 0x5,
        CALI_RSP_ERROR          = 0x6,
        CALI_START              = 0x7,    /* START : POWER ON (mA Mode) : unused */
        CALI_END                = 0x8,    /* END   : POWER OFF */
        CALI_ZERO_SET           = 0x9,    /* ZEROSET CALIBRATION */
        CALI_OFFSET_START       = 0xA,   /* OFFSET CALIBRATION : correct current variable  */
        CALI_MODE_START_mA      = 0xB,   /* START mA Mode : POWER ON uA */
        CALI_MODE_START_uA      = 0xC,   /* START mA Mode : POWER ON uA */
        CALI_MEAS_CURRENT_mA    = 0xD,   /* current measure data mA */
        CALI_MEAS_CURRENT_uA    = 0xE,   /* current measure data uA */

        NORMAL_MEAS_CURRENT    = 0x11,   /* Measure Current Only */
    }

    public enum G5InterfaceMultiRackControl // Multi Rack Control
    {
        MRACM_CMD_UNKNOWN           = 0x00,

        MRACK_CMD_RACK_START        = 0x01,
        MRACK_CMD_RACK_END          = 0x02,
        MRACK_CMD_POWER_ON          = 0x03, /* START 키로 제어 되는 전원 onf : 구동 이니셜 사용 */
        MRACK_CMD_POWER_OFF         = 0x04, /* START 키로 제어 되는 전원 off : 구도 이니셜 사용 */
        MRACK_CMD_LCD_ON_AGING      = 0x05, /* AUTO 키로 제어 되는 LCD 전원 on : 단순 전원 차단 */
        MRACK_CMD_LCD_OFF_AGING     = 0x06, /* AUTO 키로 제어 되는 LCD 전원 on : 단순 전원 차단 */
        MRACK_CMD_GET_CURRENT       = 0x07, /* 전류 측정 데이터 요청 : AGING DATA TYPE 1 을 보내도록 한다 */
        MRACK_CMD_REALTIME_DATA     = 0x08, /* 멀티 랙 에이징 데이터 요청 */
        MRACK_CMD_PATTERN_NEXT      = 0x09, /* NEXT PATTERN */
        MRACK_CMD_PATTERN_BACK      = 0x0A, /* BACK PATTERN */
        MRACK_CMD_PATTERN_CHANGE    = 0x0B, /* 특정 PATTERN 번호 */

        MRACK_RES_AUTO_AGING_DATA   = 0x21, /* 오토 패턴 체인지 할경우, 패턴 바꾸지 전에 로그를 남길 데이터 */
    }

    public enum InterfaceType
    {
        CPU = 0,
        RGB = 1,
        LVDS = 2,
        MIPI_COMMAND = 3,
        MIPI_VIDEO = 4
    }

    public enum ListUpMode
    {
        POWER_ON = 0,
        POWER_OFF = 1,
        FPGA = 2,
        FW = 3,
        PATTERN = 4,
        GNTI_SCENARIO = 5   // GNTI
    }

    public enum TimingIndex
    {
        TYPE = 0,                                // TYPE                         
        BIT = 1,                                     // Interface Bit                         
        ELVDD = 2,                   // POWER
        ELVSS = 4,
        VDD = 6,
        VCI = 8,
        VEXT1 = 10,
        VEXT2 = 12,
        WIDTH = 14,             // RESOLUTION
        HEIGHT = 16,
        HSPW = 18,                // TIMING
        HBPD = 20,
        HFPD = 22,
        VSPW = 24,
        VBPD = 26,
        VFPD = 28,
        CLOCK = 30,
        ENABLE = 35,
        VSYNC = 36,
        HSYNC = 37,
        INITIAL = 38,
        TOUCH = 39,                           // TOUCH
        BLU = 40,
        CURRENT = 41,
        CHANNEL = 43,
        DATASIZE = 44
    }


    public enum ConfigData
    {
        PATTERNTIME = 0,
        //Packet_Data[Temp + (int)ConfigData.PATTERNTIME + 1] = DefineUtils.Shift_Data(Value.Pattern_AutoTime, 3);
        //Packet_Data[Temp + (int)ConfigData.PATTERNTIME + 2] = DefineUtils.Shift_Data(Value.Pattern_AutoTime, 2);
        //Packet_Data[Temp + (int)ConfigData.PATTERNTIME + 3] = DefineUtils.Shift_Data(Value.Pattern_AutoTime, 1);
        POWERON = 4,
        POWEROFF = 6,
        SCROLLX = 8,
        SCROLLY = 9,
        RESERVED = 10,
        //RESERVED =11
        DATASIZE = 12
    }


    public enum PatternListIndex
    {
        INDEX = 6,
        LENGTH = 7,
        SUBSIZE = 49,
        DATASIZE = 1472,
    }

    public enum PatternSubIndex
    {
        MAIN = 30,
        SUB = 31,                // Sub Code
        RED = 32,               // RGB_Red
        GREEN = 33,             // RGB_Green
        BLUE = 34,              // RGB_Blue
        VDD = 35,       // VDD
        VCL = 37,      // VCI
        ELVDD = 39,      // VCI
        ELVSS = 41,      // VCI
        CLOCK = 43,         // Clock
        PAUSE = 47,          // Pause
    }


    public class DefineUtils
    {
        public static byte Shift_Data(int Data, int Byte_Cnt)
        {
            byte Result = 0;

            try
            {
                switch (Byte_Cnt)
                {
                    case 4: Result = (byte)((Data >> 24) & 0xFF); break;
                    case 3: Result = (byte)((Data >> 16) & 0xFF); break;
                    case 2: Result = (byte)((Data >> 08) & 0xFF); break;
                    case 1: Result = (byte)((Data >> 00) & 0xFF); break;
                }
            }
            catch (Exception ex)
            {
                Result = 0;
                //Debug.Message.Show("Class_Util.cs", "Shift_Data()", ex.ToString());
            }

            return Result;
        }

        public static byte Right_Shift_Byte(UInt32 ulData, int iShift_Cnt)
        {
            byte ucResult = 0;

            ucResult = (byte)((ulData >> (8 * iShift_Cnt)) & 0xFF);

            return ucResult;
        }

        public static Int32 Left_Shift_Byte(byte ucData, Int32 iShift_Cnt)
        {
            Int32 data = (Int32)(ucData & 0xFF);
            Int32 ulResult = 0;

            ulResult = ((data << (8 * iShift_Cnt)) & (0x000000FF << (8 * iShift_Cnt)));

            return ulResult;
        }
    }
}
