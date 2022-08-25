using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G4xHMI
{
    public class CurrentMeasure
    {
        public static void SendMeasureCurrent()
        {
            ClassData_CurrentControl opt = new ClassData_CurrentControl();

            opt.voltageOption_CurrentMeasure = 0;
            opt.voltageOption_CurrentMeasure |= CURRENT_MEASURE_BIT.CURRENT_BIT_VDD;
            opt.voltageOption_CurrentMeasure |= CURRENT_MEASURE_BIT.CURRENT_BIT_VCI;
            opt.voltageOption_CurrentMeasure |= CURRENT_MEASURE_BIT.CURRENT_BIT_VBAT;
            opt.voltageOption_CurrentMeasure |= CURRENT_MEASURE_BIT.CURRENT_BIT_FORCE_UNIT_AUTO;

            // TCP/IP Send
            //DefineUtils.Send_Packet_Ext((int)G5Interface.CURRENT_CONTROL, (int)G5InterfaceCurrentConrol.NORMAL_MEAS_CURRENT, opt, 100);

            // Serial Send Test
            //size = protocol.Make_Packet((int)G5Interface.CURRENT_CONTROL, (int)G5InterfaceCurrentConrol.NORMAL_MEAS_CURRENT, opt, ref Send_Packet);
            //SendByteData(Send_Packet, 0, size);
        }

        public static byte[] SendMultiRackControl(G5InterfaceMultiRackControl SubCommand)
        {
           return SendMultiRackControl(SubCommand, 0);
        }
        
        public static byte[] SendMultiRackControl(G5InterfaceMultiRackControl SubCommand, int PatternNumber)
        {
            Class_Protocol.TcpIp.G5_TCPIP Protocol;
			byte[] Send_Packet = null;

            Protocol = new Class_Protocol.TcpIp.G5_TCPIP();
            ClassData_CurrentControl opt = new ClassData_CurrentControl();

            PatternNumber = (PatternNumber << 8) & 0xFF00;
            opt.voltageOption_MultiRack = PatternNumber;// (CURRENT_MULTI_RACK_BIT)PatternNumber;

            switch (SubCommand)
            {
                case G5InterfaceMultiRackControl.MRACK_CMD_RACK_START:
                    break;
                case G5InterfaceMultiRackControl.MRACK_CMD_RACK_END:
                    break;
                case G5InterfaceMultiRackControl.MRACK_CMD_POWER_ON:
                    break;
                case G5InterfaceMultiRackControl.MRACK_CMD_POWER_OFF:
                    break;
                case G5InterfaceMultiRackControl.MRACK_CMD_LCD_ON_AGING:
                    break;
                case G5InterfaceMultiRackControl.MRACK_CMD_LCD_OFF_AGING:
                    break;
                case G5InterfaceMultiRackControl.MRACK_CMD_GET_CURRENT:
                    opt.voltageOption_MultiRack |= (int)CURRENT_MULTI_RACK_BIT.BIT_TYPE_1;
                    break;
                case G5InterfaceMultiRackControl.MRACK_CMD_REALTIME_DATA:
                    opt.voltageOption_MultiRack |= (int)CURRENT_MULTI_RACK_BIT.BIT_TYPE_1;
                    //DefineUtils.Send_Packet_RealTimeCurrent((int)G5Interface.MULTI_RACK_CONTROL, (int)SubCommand, opt, 0);
                    //return; /* RETURN */
                    break;
                case G5InterfaceMultiRackControl.MRACK_CMD_PATTERN_NEXT:
                    break;
                case G5InterfaceMultiRackControl.MRACK_CMD_PATTERN_BACK:
                    break;
                case G5InterfaceMultiRackControl.MRACK_CMD_PATTERN_CHANGE:
                    opt.voltageOption_MultiRack |= (int)CURRENT_MULTI_RACK_BIT.BIT_TYPE_1;
                    opt.voltageOption_MultiRack |= (int)CURRENT_MULTI_RACK_BIT.BIT_AUTO_CURRENT_RES_ON;
                    opt.voltageOption_MultiRack |= (((3 & 0x7) << 16));   // valid 3 sec : white only
                    break;
                case G5InterfaceMultiRackControl.MRACK_RES_AUTO_AGING_DATA:
                    /* 서버에서 요청하는 것인 아님. */
                    break;
                default:
                    return Send_Packet;
            }

            Protocol.Make_Packet_Ext((int)G5Interface.MULTI_RACK_CONTROL, (int)SubCommand, (object)opt, ref Send_Packet);

            return Send_Packet;
        }



        /// <summary>
        /// Set Model Name(CMD = G4xHMI.G5Interface.UPDATE_MODULE_NAME = 0x26)
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="modelName"></param>
        /// <param name="Packet_Data"></param>
        /// <returns></returns>
        public static bool Make_Packet_SetModuleName(string modelName, ref byte[] Packet_Data, ref string errMsg)
        {
            try
            {
                int Data_Len = 30;
                int Packet_Len = Data_Len + 10;
                Packet_Data = new byte[Packet_Len];

                Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[02] = 0x00;                                                 // TYPE
                Packet_Data[03] = (byte)G5Interface.UPDATE_MODULE_NAME;    // (byte)Code;                                           // CMD
                Packet_Data[04] = (byte)((Data_Len >> 8) & 0x00FF);                     // LENGTH HIGH
                Packet_Data[05] = (byte)(Data_Len & 0x00FF);                            // LENGTH LOW

                //  Class_Drive.Class_Data Value = Global_G5.Drive.Read();
                // Buffer.BlockCopy(Encoding.Default.GetBytes(Global_G5.MODEL_NAME), 0, Packet_Data, 6, (Global_G5.MODEL_NAME.Length <= 30 ? Global_G5.MODEL_NAME.Length : 30));
                Buffer.BlockCopy(Encoding.Default.GetBytes(modelName), 0, Packet_Data, 6, (modelName.Length <= 30 ? modelName.Length : 30));

                ushort crc = 0;
                CRC16 Crc16 = new CRC16();
                crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);                      // CRC Make
                Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);              // CRC16 HIGH
                Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);                     // CRC16 LOW
                Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;                 // TAILER
                Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;                 // TAILER 

                return true;
            }
            catch (Exception ex)
            {
                //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_0x23()", ex.ToString());
                errMsg = ex.ToString();
                return false;
            }
        }

        /// <summary>
        /// Set Module Data, (CMD = G4xHMI.G5Interface.UPDATE_MODULE = 0x22)
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Packet_Data"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool Make_Packet_SetModuleData(G4SDataLibrary.CDriveData.sModelTimeData Value, ref byte[] Packet_Data, ref string errMsg)
        {
            try
            {
                //if (Global_G5.Drive != null)
                //{
                int Data_Len = (int)TimingIndex.DATASIZE;
                int Packet_Len = Data_Len + 10;
                Packet_Data = new byte[Packet_Len];

                Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[02] = 0x00;                                                 // TYPE
                Packet_Data[03] = (byte)G4xHMI.G5Interface.UPDATE_MODULE; // 0x22; // (byte)Code;                                           // CMD
                Packet_Data[04] = (byte)((Data_Len >> 8) & 0x00FF);                     // LENGTH HIGH
                Packet_Data[05] = (byte)(Data_Len & 0x00FF);                            // LENGTH LOW

                // Class_Drive.Class_Data Value = Global_G5.Drive.Read();
                int Temp = 6;

                Packet_Data[Temp + (int)(int)TimingIndex.TYPE] = (byte)Value.Type;                                     // TYPE                         
                Packet_Data[Temp + (int)(int)TimingIndex.BIT] = (byte)Value.nInterface;                                     // Interface Bit                         
                Packet_Data[Temp + (int)(int)TimingIndex.ELVDD] = DefineUtils.Shift_Data(Value.Power.ELVDD, 2);               // POWER
                Packet_Data[Temp + (int)(int)TimingIndex.ELVDD + 1] = DefineUtils.Shift_Data(Value.Power.ELVDD, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.ELVSS] = DefineUtils.Shift_Data(Value.Power.ELVSS, 2);
                Packet_Data[Temp + (int)(int)TimingIndex.ELVSS + 1] = DefineUtils.Shift_Data(Value.Power.ELVSS, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.VDD] = DefineUtils.Shift_Data(Value.Power.VDD, 2);
                Packet_Data[Temp + (int)(int)TimingIndex.VDD + 1] = DefineUtils.Shift_Data(Value.Power.VDD, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.VCI] = DefineUtils.Shift_Data(Value.Power.VCI, 2);
                Packet_Data[Temp + (int)(int)TimingIndex.VCI + 1] = DefineUtils.Shift_Data(Value.Power.VCI, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.VEXT1] = DefineUtils.Shift_Data(Value.Power.VEXT1, 2);
                Packet_Data[Temp + (int)(int)TimingIndex.VEXT1 + 1] = DefineUtils.Shift_Data(Value.Power.VEXT1, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.VEXT2] = DefineUtils.Shift_Data(Value.Power.VEXT2, 2);
                Packet_Data[Temp + (int)(int)TimingIndex.VEXT2 + 1] = DefineUtils.Shift_Data(Value.Power.VEXT2, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.WIDTH] = DefineUtils.Shift_Data(Value.Resolution.Width, 2);               // RESOLUTION
                Packet_Data[Temp + (int)(int)TimingIndex.WIDTH + 1] = DefineUtils.Shift_Data(Value.Resolution.Width, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.HEIGHT] = DefineUtils.Shift_Data(Value.Resolution.Height, 2);
                Packet_Data[Temp + (int)(int)TimingIndex.HEIGHT + 1] = DefineUtils.Shift_Data(Value.Resolution.Height, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.HSPW] = DefineUtils.Shift_Data(Value.Timing.HSPW, 2);                // TIMING
                Packet_Data[Temp + (int)(int)TimingIndex.HSPW + 1] = DefineUtils.Shift_Data(Value.Timing.HSPW, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.HBPD] = DefineUtils.Shift_Data(Value.Timing.HBPD, 2);
                Packet_Data[Temp + (int)(int)TimingIndex.HBPD + 1] = DefineUtils.Shift_Data(Value.Timing.HBPD, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.HFPD] = DefineUtils.Shift_Data(Value.Timing.HFPD, 2);
                Packet_Data[Temp + (int)(int)TimingIndex.HFPD + 1] = DefineUtils.Shift_Data(Value.Timing.HFPD, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.VSPW] = DefineUtils.Shift_Data(Value.Timing.VSPW, 2);
                Packet_Data[Temp + (int)(int)TimingIndex.VSPW + 1] = DefineUtils.Shift_Data(Value.Timing.VSPW, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.VBPD] = DefineUtils.Shift_Data(Value.Timing.VBPD, 2);
                Packet_Data[Temp + (int)(int)TimingIndex.VBPD + 1] = DefineUtils.Shift_Data(Value.Timing.VBPD, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.VFPD] = DefineUtils.Shift_Data(Value.Timing.VFPD, 2);
                Packet_Data[Temp + (int)(int)TimingIndex.VFPD + 1] = DefineUtils.Shift_Data(Value.Timing.VFPD, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.CLOCK] = DefineUtils.Shift_Data(Value.Timing.Clock, 4);
                Packet_Data[Temp + (int)(int)TimingIndex.CLOCK + 1] = DefineUtils.Shift_Data(Value.Timing.Clock, 3);
                Packet_Data[Temp + (int)(int)TimingIndex.CLOCK + 2] = DefineUtils.Shift_Data(Value.Timing.Clock, 2);
                Packet_Data[Temp + (int)(int)TimingIndex.CLOCK + 3] = DefineUtils.Shift_Data(Value.Timing.Clock, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.CLOCK + 4] = DefineUtils.Shift_Data(Value.Signal.DOTCLK, 1);                        // SIGNAL
                Packet_Data[Temp + (int)(int)TimingIndex.ENABLE] = DefineUtils.Shift_Data(Value.Signal.Enable, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.VSYNC] = DefineUtils.Shift_Data(Value.Signal.VSYNC, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.HSYNC] = DefineUtils.Shift_Data(Value.Signal.HSYNC, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.INITIAL] = DefineUtils.Shift_Data(Value.Initial_BIT, 1);                             // INITIAL
                Packet_Data[Temp + (int)(int)TimingIndex.TOUCH] = DefineUtils.Shift_Data(Value.Touch, 1);                           // TOUCH
                Packet_Data[Temp + (int)(int)TimingIndex.BLU] = DefineUtils.Shift_Data(Value.Backlight.BLU, 1);                             // BACKLIGHT
                Packet_Data[Temp + (int)(int)TimingIndex.CURRENT] = DefineUtils.Shift_Data(Value.Backlight.Current, 2);
                Packet_Data[Temp + (int)(int)TimingIndex.CURRENT + 1] = DefineUtils.Shift_Data(Value.Backlight.Current, 1);
                Packet_Data[Temp + (int)(int)TimingIndex.CHANNEL] = (byte)Value.Channel;

                ushort crc = 0;
                CRC16 Crc16 = new CRC16();
                crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);                      // CRC Make
                Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);              // CRC16 HIGH
                Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);                     // CRC16 LOW
                Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;                 // TAILER
                Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;                 // TAILER 

                return true;
                // }
            }
            catch (Exception ex)
            {
                //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_0x22()", ex.ToString());

                errMsg = ex.ToString();
                return false;
            }
        }


        /// <summary>
        /// Get Module Data, (CMD = G4xHMI.G5Interface.REQUEST_MODULE = 0x12)
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Packet_Data"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool Make_Packet_GetModuleData(ref byte[] Packet_Data, ref string errMsg)
        {
            try
            {
                //if (Global_G5.Drive != null)
                //{
                int Data_Len = 8;
                int Packet_Len = Data_Len + 10;
                Packet_Data = new byte[Packet_Len];

                Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[02] = 0x00;                                                 // TYPE
                Packet_Data[03] = (byte)G4xHMI.G5Interface.REQUEST_MODULE; // 0x22; // (byte)Code;                                           // CMD
                Packet_Data[04] = (byte)((Data_Len >> 8) & 0x00FF);                     // LENGTH HIGH
                Packet_Data[05] = (byte)(Data_Len & 0x00FF);                            // LENGTH LOW

                //DATA Begin , 8Byte
                Packet_Data[06] = 0x00;
                Packet_Data[07] = 0x00;
                Packet_Data[08] = 0x00;
                Packet_Data[09] = 0x00;
                Packet_Data[10] = 0x00;
                Packet_Data[11] = 0x00;
                Packet_Data[12] = 0x00;
                Packet_Data[13] = 0x00;
                //DATA End

                ushort crc = 0;
                CRC16 Crc16 = new CRC16();
                crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);                      // CRC Make
                Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);              // CRC16 HIGH
                Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);                     // CRC16 LOW
                Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;                 // TAILER
                Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;                 // TAILER 

                return true;
                // }
            }
            catch (Exception ex)
            {
                //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_0x22()", ex.ToString());

                errMsg = ex.ToString();
                return false;
            }
        }


        /// <summary>
        /// Set Config Data, (CMD = G4xHMI.G5Interface.UPDATE_CONFIG = 0x51)
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Packet_Data"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool Make_Packet_ConfigData(G4SDataLibrary.CDriveData.sModelTimeData Value, ref byte[] Packet_Data, ref string errMsg)
        {
            try
            {
                //if (Global_G5.Drive != null)
                //{
                int Data_Len = (int)ConfigData.DATASIZE;
                int Packet_Len = Data_Len + 10;
                Packet_Data = new byte[Packet_Len];

                Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[02] = 0x00;                                                 // TYPE
                Packet_Data[03] = (byte)G4xHMI.G5Interface.UPDATE_CONFIG;  // 0x51; //(byte)Code;                                           // CMD
                Packet_Data[04] = (byte)((Data_Len >> 8) & 0x00FF);                     // LENGTH HIGH
                Packet_Data[05] = (byte)(Data_Len & 0x00FF);                            // LENGTH LOW

                //Class_Drive.Class_Data Value = Global_G5.Drive.Read(0);
                int Temp = 6;
                Packet_Data[Temp + (int)ConfigData.PATTERNTIME] = DefineUtils.Shift_Data(Value.Pattern_AutoTime, 4);               // Pattern Auto Time
                Packet_Data[Temp + (int)ConfigData.PATTERNTIME + 1] = DefineUtils.Shift_Data(Value.Pattern_AutoTime, 3);
                Packet_Data[Temp + (int)ConfigData.PATTERNTIME + 2] = DefineUtils.Shift_Data(Value.Pattern_AutoTime, 2);
                Packet_Data[Temp + (int)ConfigData.PATTERNTIME + 3] = DefineUtils.Shift_Data(Value.Pattern_AutoTime, 1);

                Packet_Data[Temp + (int)ConfigData.POWERON] = DefineUtils.Shift_Data(Value.Power_AutoOnTime, 2);                 // Power Auto Time
                Packet_Data[Temp + (int)ConfigData.POWERON + 1] = DefineUtils.Shift_Data(Value.Power_AutoOnTime, 1);
                Packet_Data[Temp + (int)ConfigData.POWEROFF] = DefineUtils.Shift_Data(Value.Power_AutoOffTime, 2);                 // Power Auto Time
                Packet_Data[Temp + (int)ConfigData.POWEROFF + 1] = DefineUtils.Shift_Data(Value.Power_AutoOffTime, 1);
                Packet_Data[Temp + (int)ConfigData.SCROLLX] = DefineUtils.Shift_Data(Value.ScrollSpeed_X, 1);                 // Scroll Speed - X
                Packet_Data[Temp + (int)ConfigData.SCROLLY] = DefineUtils.Shift_Data(Value.ScrollSpeed_Y, 1);                 // Scroll Speed - Y

                Packet_Data[Temp + (int)ConfigData.RESERVED] = 0x00;                                                 // Reserved
                Packet_Data[Temp + (int)ConfigData.RESERVED + 1] = 0x00;
                ushort crc = 0;
                CRC16 Crc16 = new CRC16();
                crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);                      // CRC Make
                Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);              // CRC16 HIGH
                Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);                     // CRC16 LOW
                Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;                 // TAILER
                Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;                 // TAILER 

                return true;
                //}
            }
            catch (Exception ex)
            {
                errMsg = ex.ToString();
                return false;
                // Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_0x51()", ex.ToString());
            }
        }

        // Pattern Name : 0x27, 0x29 공용 소스 입니다.
        /// <summary>
        /// Set Pattern List Name
        /// </summary>
        /// <param name="Code">Command(CMD), Value Type = G4xHMI.G5Interface,  G4xHMI.G5Interface.UPDATE_PATTERN_LIST_NAME = 0x27, G4xHMI.G5Interface.UPDATE_PATTERN_LIST_NAME2 = 0x29</param>
        /// <param name="patternListName"></param>
        /// <param name="Packet_Data"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool Make_Packet_SetPatternListName(int Code, string patternListName, ref byte[] Packet_Data, ref string errMsg)
        {
            try
            {
                int Data_Len = 30;
                int Packet_Len = Data_Len + 10;
                Packet_Data = new byte[Packet_Len];

                Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[02] = 0x00;                                                 // TYPE
                Packet_Data[03] = (byte)Code;                                           // CMD           G4xHMI.G5Interface.UPDATE_PATTERN_LIST_NAME = 0x27, G4xHMI.G5Interface.UPDATE_PATTERN_LIST_NAME2 = 0x29
                Packet_Data[04] = (byte)((Data_Len >> 8) & 0x00FF);                     // LENGTH HIGH
                Packet_Data[05] = (byte)(Data_Len & 0x00FF);                            // LENGTH LOW

                Buffer.BlockCopy(Encoding.Default.GetBytes(patternListName), 0, Packet_Data, 6, (patternListName.Length <= 30 ? patternListName.Length : 30));

                ushort crc = 0;
                CRC16 Crc16 = new CRC16();
                crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);                      // CRC Make
                Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);              // CRC16 HIGH
                Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);                     // CRC16 LOW
                Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;                 // TAILER
                Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;                 // TAILER 

                return true;
            }
            catch (Exception ex)
            {
                //Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_0x27()", ex.ToString());
                errMsg = ex.ToString();
                return false;
            }
        }


        //Pattern Data : 0x21, 0x2A 공용 소스 입니다.
        /// <summary>
        /// Set Pattern List
        /// </summary>
        /// <param name="Code">Command(CMD), Value Type = G4xHMI.G5Interface(G4xHMI.G5Interface.UPDATE_PATTERN_LIST = 0x21, G4xHMI.G5Interface.UPDATE_PATTERN_LIST2 = 0x2A)</param>
        /// <param name="Index"></param>
        /// <param name="Packet_Data"></param>
        public static bool Make_Packet_SetPatternList(int Code, G4SDataLibrary.CDriveData.sPatternList patternList, ref byte[] Packet_Data, ref string errMsg)
        {
            try
            {
                if (patternList.PatternItem != null)
                {
                    int Data_Len = (int)PatternListIndex.DATASIZE;
                    int Packet_Len = Data_Len + 10;
                    Packet_Data = new byte[Packet_Len];

                    Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                    Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                    Packet_Data[02] = 0x00;                                                 // TYPE
                    Packet_Data[03] = (byte)Code;                                           // CMD  //G4xHMI.G5Interface.UPDATE_PATTERN_LIST = 0x21, G4xHMI.G5Interface.UPDATE_PATTERN_LIST2 = 0x2A
                    Packet_Data[04] = (byte)((Data_Len >> 8) & 0xFF);                       // LENGTH HIGH
                    Packet_Data[05] = (byte)((Data_Len >> 0) & 0xFF);                       // LENGTH LOW

                    Packet_Data[(int)PatternListIndex.INDEX] = (byte)patternList.Idx;    //Index;                                          // Pattern List Index (0~3)
                    Packet_Data[(int)PatternListIndex.LENGTH] = (byte)patternList.Len;   //Pattern.Count;                       // Pattern Count

                    for (int i = 0; i < CONST.DEVICE.PAGE_MAX; i++)
                    {
                        int Count = (patternList.Idx * CONST.DEVICE.PAGE_MAX) + i;
                        if (Count < patternList.Len) //Global_G5.Pattern.Count)
                        {
                            int Temp = ((int)PatternListIndex.SUBSIZE * i) + 8;

                            //Class_Pattern.Class_Data Pattern = Global_G5.Pattern.Read(Count);
                            G4SDataLibrary.CDriveData.sPatternItem Pattern = patternList.PatternItem[Count];

                            Buffer.BlockCopy(Encoding.Default.GetBytes(Pattern.sImageName), 0, Packet_Data, Temp, (Pattern.sImageName.Length <= 30 ? Pattern.sImageName.Length : 30));
                            Packet_Data[Temp + (int)PatternSubIndex.MAIN] = (byte)Pattern.MainCode;  //.PatternItem(Count).   //.Code_Main;               // Main Code
                            Packet_Data[Temp + (int)PatternSubIndex.SUB] = (byte)Pattern.SubCode;                // Sub Code
                            Packet_Data[Temp + (int)PatternSubIndex.RED] = (byte)Pattern.Red;               // RGB_Red
                            Packet_Data[Temp + (int)PatternSubIndex.GREEN] = (byte)Pattern.Green;             // RGB_Green
                            Packet_Data[Temp + (int)PatternSubIndex.BLUE] = (byte)Pattern.Blue;              // RGB_Blue
                            Packet_Data[Temp + (int)PatternSubIndex.VDD] = DefineUtils.Shift_Data(Pattern.Vdd, 2);      // VDD
                            Packet_Data[Temp + (int)PatternSubIndex.VDD + 1] = DefineUtils.Shift_Data(Pattern.Vdd, 1);
                            Packet_Data[Temp + (int)PatternSubIndex.VCL] = DefineUtils.Shift_Data(Pattern.Vci, 2);      // VCI
                            Packet_Data[Temp + (int)PatternSubIndex.VCL + 1] = DefineUtils.Shift_Data(Pattern.Vci, 1);
                            Packet_Data[Temp + (int)PatternSubIndex.ELVDD] = DefineUtils.Shift_Data(Pattern.ELVDD, 2);      // VCI
                            Packet_Data[Temp + (int)PatternSubIndex.ELVDD + 1] = DefineUtils.Shift_Data(Pattern.ELVDD, 1);
                            Packet_Data[Temp + (int)PatternSubIndex.ELVSS] = DefineUtils.Shift_Data(Pattern.ELVSS, 2);      // VCI
                            Packet_Data[Temp + (int)PatternSubIndex.ELVSS + 1] = DefineUtils.Shift_Data(Pattern.ELVSS, 1);
                            Packet_Data[Temp + (int)PatternSubIndex.CLOCK] = DefineUtils.Shift_Data(Pattern.Clock, 4);          // Clock
                            Packet_Data[Temp + (int)PatternSubIndex.CLOCK + 1] = DefineUtils.Shift_Data(Pattern.Clock, 3);
                            Packet_Data[Temp + (int)PatternSubIndex.CLOCK + 2] = DefineUtils.Shift_Data(Pattern.Clock, 2);
                            Packet_Data[Temp + (int)PatternSubIndex.CLOCK + 3] = DefineUtils.Shift_Data(Pattern.Clock, 1);
                            Packet_Data[Temp + (int)PatternSubIndex.PAUSE] = DefineUtils.Shift_Data(Pattern.Pause, 2);          // Pause
                            Packet_Data[Temp + (int)PatternSubIndex.PAUSE + 1] = DefineUtils.Shift_Data(Pattern.Pause, 1);
                        }
                    }

                    ushort crc = 0;
                    CRC16 Crc16 = new CRC16();
                    crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);                      // CRC Make
                    Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);              // CRC16 HIGH
                    Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);                     // CRC16 LOW
                    Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;                 // TAILER
                    Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;                 // TAILER 

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                errMsg = ex.ToString();
                return false;
                //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_0x21()", ex.ToString());
            }
        }


        /// <summary>
        /// Control Device(CMD : 0x31)
        /// </summary>
        /// <param name="MainCode">Main Command(Type =  G4xHMI.ControlDevice, Power ON : 0x11, ... NAND Flash Format : 0x21)</param>
        /// <param name="SubCode">Sub Command(Not use, Set to 0)</param>
        /// <param name="Packet_Data"></param>
        /// <param name="errMsg"></param>
        public static bool Make_Packet_ControlDevice(int MainCode, int SubCode, ref byte[] Packet_Data, ref string errMsg)
        {
            try
            {
                int Data_Len = 12;
                int Packet_Len = Data_Len + 10;
                Packet_Data = new byte[Packet_Len];

                Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[02] = 0x00;                                                 // TYPE
                Packet_Data[03] = (byte)G5Interface.CONTROL_DEVICE;   //0x31;                                           // CMD
                Packet_Data[04] = (byte)((Data_Len >> 8) & 0x00FF);                     // LENGTH HIGH
                Packet_Data[05] = (byte)(Data_Len & 0x00FF);                            // LENGTH LOW

                Packet_Data[06] = DefineUtils.Shift_Data(MainCode, 4);                  // Main Code
                Packet_Data[07] = DefineUtils.Shift_Data(MainCode, 3);
                Packet_Data[08] = DefineUtils.Shift_Data(MainCode, 2);
                Packet_Data[09] = DefineUtils.Shift_Data(MainCode, 1);

                Packet_Data[10] = DefineUtils.Shift_Data(SubCode, 4);                   // Sub Code
                Packet_Data[11] = DefineUtils.Shift_Data(SubCode, 3);
                Packet_Data[12] = DefineUtils.Shift_Data(SubCode, 2);
                Packet_Data[13] = DefineUtils.Shift_Data(SubCode, 1);

                Packet_Data[14] = 0x00;                                                 // Reserved
                Packet_Data[15] = 0x00;
                Packet_Data[16] = 0x00;
                Packet_Data[17] = 0x00;

                ushort crc = 0;
                CRC16 Crc16 = new CRC16();
                crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);                      // CRC Make
                Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);              // CRC16 HIGH
                Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);                     // CRC16 LOW
                Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;                 // TAILER
                Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;                 // TAILER 
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.ToString();
                return false;
                //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_0x31()", ex.ToString());
            }
        }

        /// <summary>
        /// Update Bitmap Image Information,
        /// Value Type = G4xHMI.G5Interface.UPDATE_IMAGE = 0x41
        /// 응답이 Success 이면 Image Data를 설정한 Pattern Size 만큼 Ethernet 으로 구동기에 Download
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Packet_Data"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool Make_Packet_UpdateBMPImageInfo(int Index, G4SDataLibrary.CDriveData.ClassImage Value, ref byte[] Packet_Data, ref string errMsg)
        {
            try
            {
                int Data_Len = 39;
                int Packet_Len = Data_Len + 10;
                Packet_Data = new byte[Packet_Len];

                Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[02] = 0x00;                                                 // TYPE
                Packet_Data[03] = (byte)G4xHMI.G5Interface.UPDATE_IMAGE;                                           // CMD             G4xHMI.G5Interface.UPDATE_IMAGE
                Packet_Data[04] = (byte)((Data_Len >> 8) & 0x00FF);                     // LENGTH HIGH
                Packet_Data[05] = (byte)(Data_Len & 0x00FF);                            // LENGTH LOW


                //Class_Pattern.CalssImage Value = (Class_Pattern.CalssImage)Global_G5.UpdateImage[Index];
                //Class_Pattern.CalssImage Value = Global_G5.Pattern.ReadImageData(Index);
                //Class_Updates.Class_Image.Class_Data Value = Global_G5.Updates.Image.Read(Index);
                int Width_Pixel = (int)(Value.Data[21] << 24)
                                + (int)(Value.Data[20] << 16)
                                + (int)(Value.Data[19] << 08)
                                + (int)(Value.Data[18] << 00);
                int Hight_Pixel = (int)(Value.Data[25] << 24)
                                + (int)(Value.Data[24] << 16)
                                + (int)(Value.Data[23] << 08)
                                + (int)(Value.Data[22] << 00);

                int Width_Four_Drain = (((Width_Pixel * 3) % 4) == 0) ? 0 : (4 - ((Width_Pixel * 3) % 4));

                int Length = (Width_Pixel * 3 * Hight_Pixel) + (Hight_Pixel * Width_Four_Drain);

                int Width = Width_Pixel;
                int Height = Hight_Pixel;
                string Name = Value.Name;

                Packet_Data[06] = (byte)Index;                                          // Image Index

                Packet_Data[07] = DefineUtils.Shift_Data(Length, 4);                                // Size
                Packet_Data[08] = DefineUtils.Shift_Data(Length, 3);
                Packet_Data[09] = DefineUtils.Shift_Data(Length, 2);
                Packet_Data[10] = DefineUtils.Shift_Data(Length, 1);

                Packet_Data[11] = DefineUtils.Shift_Data(Width, 2);                                 // Width
                Packet_Data[12] = DefineUtils.Shift_Data(Width, 1);

                Packet_Data[13] = DefineUtils.Shift_Data(Height, 2);                                // Height
                Packet_Data[14] = DefineUtils.Shift_Data(Height, 1);

                byte[] PatternName = Encoding.Default.GetBytes(Name);                   // Name
                for (int j = 0; j < PatternName.Length; j++)
                {
                    if (j < 30)
                        Packet_Data[15 + j] = PatternName[j];
                }

                ushort crc = 0;
                CRC16 Crc16 = new CRC16();
                crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);                      // CRC Make
                Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);              // CRC16 HIGH
                Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);                     // CRC16 LOW
                Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;                 // TAILER
                Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;                 // TAILER 

                return true;
            }
            catch (Exception ex)
            {

                errMsg = ex.ToString();
                return false;
                //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_0x41()", ex.ToString());
            }
        }

        // BMP파일 전송, 한번에 전송.
        // 대기 시간은. Btn_Image_Click() 이벤트 핸들러 참조.
        // 별도의 패킹이 필요 없으며, 파일 전체를 전송
        // 검사기 쪽에서는 이미지 사이즈가 모두 오면 수신 완료함.

        /// <summary>
        /// Image Download : 0xFF(CMD 없이 이미지만 전송)
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="Index"></param>
        /// <param name="Packet_Data"></param>
        public static bool Make_Packet_SendImage(int Index, G4SDataLibrary.CDriveData.ClassImage Value, ref byte[] Packet_Data, ref string errMsg)
        {

            try
            {
                //Value = (Class_Pattern.CalssImage)Global_G5.UpdateImage[Index];
                //Class_Pattern.CalssImage Value = Global_G5.Pattern.ReadImageData(Index);
                //Class_Updates.Class_Image.Class_Data Value = Global_G5.Updates.Image.Read(Index);
                int Length = Value.Data.Length;

                int Width_Pixel = (int)(Value.Data[21] << 24)
                                + (int)(Value.Data[20] << 16)
                                + (int)(Value.Data[19] << 08)
                                + (int)(Value.Data[18] << 00);
                int Hight_Pixel = (int)(Value.Data[25] << 24)
                                + (int)(Value.Data[24] << 16)
                                + (int)(Value.Data[23] << 08)
                                + (int)(Value.Data[22] << 00);

                int Width_Four_Drain = (((Width_Pixel * 3) % 4) == 0) ? 0 : (4 - ((Width_Pixel * 3) % 4));
                int Width_Len = ((Width_Pixel * 3) + Width_Four_Drain);

                int Packet_Len = (Width_Pixel * 3 * Hight_Pixel) + (Hight_Pixel * Width_Four_Drain);
                Packet_Data = new byte[Packet_Len];

                for (int i = 0; i < Hight_Pixel; i++)
                {
                    for (int j = 0; j < Width_Len; j++)
                    {
                        Packet_Data[(i * Width_Len) + j] = Value.Data[(((Hight_Pixel - 1) - i) * Width_Len) + j + 54];
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                string subLog = "";
                if (Value.Data != null)
                {
                    subLog = "Image Index : " + Index.ToString() + " File : " + Value.Name + " Check!!";
                }
                else
                {
                    subLog = "Image Index : " + Index.ToString() + " NULL";
                }

                errMsg = subLog + "/" + ex.ToString();
                return false;
                //       Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_0xFF()", ex.ToString() + subLog);
            }
        }

        /// <summary>
        /// Text Based Initial Code , Use SubCode Param <> G4xHMI.G5InterfaceGNTScenario.DATA
        /// </summary>
        /// <param name="Code">Value = G4xHMI.G5Interface.GNTICMD_CTL = 0x63</param>
        /// <param name="SubCode">Value = G4xHMI.G5InterfaceGNTScenario </param>
        /// <param name="Info"></param>
        /// <param name="Packet_Data"></param>
        public static bool Make_Packet_GNTI_CMD(int Code, int SubCode, int Info, ref byte[] Packet_Data, ref string errMsg)    // GNTI
        {
            try
            {
                int Data_Len = 8;
                int Packet_Len = Data_Len + 10;
                Packet_Data = new byte[Packet_Len];

                Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[02] = 0x00;                                                 // TYPE
                Packet_Data[03] = (byte)Code;                                           // CMD
                Packet_Data[04] = (byte)((Data_Len >> 8) & 0x00FF);                     // LENGTH HIGH
                Packet_Data[05] = (byte)(Data_Len & 0x00FF);                            // LENGTH LOW

                Packet_Data[06] = DefineUtils.Shift_Data(SubCode, 4);                  // Sub Code
                Packet_Data[07] = DefineUtils.Shift_Data(SubCode, 3);
                Packet_Data[08] = DefineUtils.Shift_Data(SubCode, 2);
                Packet_Data[09] = DefineUtils.Shift_Data(SubCode, 1);

                Packet_Data[10] = DefineUtils.Shift_Data(Info, 4);                  // Info
                Packet_Data[11] = DefineUtils.Shift_Data(Info, 3);
                Packet_Data[12] = DefineUtils.Shift_Data(Info, 2);
                Packet_Data[13] = DefineUtils.Shift_Data(Info, 1);

                ushort crc = 0;
                CRC16 Crc16 = new CRC16();
                crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);                      // CRC Make
                Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);              // CRC16 HIGH
                Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);                     // CRC16 LOW
                Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;                 // TAILER
                Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;                 // TAILER 
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.ToString();
                return false;
                //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_GNTI_CMD()", ex.ToString());
            }
        }
        
        //
        // DefineUtils.Send_Packet((int)G5Interface.GNTICMD_CTL, (int)G5InterfaceGNTScenario.DATA, 0x00, 1);
        //
        /*
                      case (int)G5Interface.GNTICMD_CTL:  // GNTI
                        if (First_Data == (int)G5InterfaceGNTScenario.DATA)
                                Make_Packet_GNTI_File_BIN(Code, First_Data, Global_G5.GNTI.FileIndex, ref Packet_Data);
                        else
                            Make_Packet_GNTI_CMD(Code, First_Data, Second_Data, ref Packet_Data);
                        break;
        */
        /// <summary>
        /// Text Based Initial Code , Use SubCode Param = G4xHMI.G5InterfaceGNTScenario.DATA
        /// </summary>
        /// <param name="Code">Value = G4xHMI.G5Interface.GNTICMD_CTL = 0x63</param>
        /// <param name="SubCode">Value = G4xHMI.G5InterfaceGNTScenario</param>
        /// <param name="Index"></param>
        /// <param name="EEPROMPageSize"></param>
        /// <param name="Value"></param>
        /// <param name="Packet_Data"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool Make_Packet_GNTI_File_BIN(int Code, int SubCode, int Index, int EEPROMPageSize, G4SDataLibrary.CDriveData.GNTIBinFile Value, ref byte[] Packet_Data, ref string errMsg)
        {
            try
            {
                int Data_Len = EEPROMPageSize + (3 + 4);
                int Packet_Len = Data_Len + 10;
                Packet_Data = new byte[Packet_Len];

                // Command
                Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[02] = 0x00;                                                 // TYPE
                Packet_Data[03] = (byte)Code;                                           // CMD
                Packet_Data[04] = (byte)((Data_Len >> 8) & 0x00FF);                     // LENGTH HIGH
                Packet_Data[05] = (byte)(Data_Len & 0x00FF);                            // LENGTH LOW

                // Data
                Packet_Data[06] = DefineUtils.Shift_Data(SubCode, 4);                  // Sub Code
                Packet_Data[07] = DefineUtils.Shift_Data(SubCode, 3);
                Packet_Data[08] = DefineUtils.Shift_Data(SubCode, 2);
                Packet_Data[09] = DefineUtils.Shift_Data(SubCode, 1);

                int Section = 0x03;
                int Length = EEPROMPageSize;

                //Class_Updates.Class_BinFile.Class_Data Value = Global_G5.Updates.GNTIScenario.Read();
                //Class_Updates.Class_GNTIBinFile.Class_Data Value = Global_G5.Updates.GNTIScenario.Read();

                if (Index == 0)
                {
                    Section = 0x01;
                }
                else if (Index == (Value.Page - 1))
                {
                    Section = 0x02;
                    Length = Value.Data.Length - (Index * EEPROMPageSize);
                    //System.Windows.Forms.MessageBox.Show("##### Index :" + Index.ToString() + " Length :" + Length.ToString());
                }

                Packet_Data[10] = (byte)Section;                                        // Section
                Packet_Data[11] = DefineUtils.Shift_Data(Index, 2);                     // Sequence
                Packet_Data[12] = DefineUtils.Shift_Data(Index, 1);

                System.Array.Copy(Value.Data, Index * EEPROMPageSize, Packet_Data, (9 + 4), Length);

                ushort crc = 0;
                CRC16 Crc16 = new CRC16();
                crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);                      // CRC Make
                Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);              // CRC16 HIGH
                Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);                     // CRC16 LOW
                Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;                 // TAILER
                Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;                 // TAILER 

                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.ToString();
                return false;
                //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_GNTI_File_BIN()", ex.ToString());
            }
        }

        /// <summary>
        /// Initial Code Name Setup, CMD =0x25=G4xHMI.G5Interface.UPDATE_INIT_CODE_NAME
        /// </summary>
        /// <param name="name">Data.ini, Initial Section, SCENARIO Item</param>
        /// <param name="Packet_Data"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool Make_Packet_InitialCodeNameSetup(string name, ref byte[] Packet_Data, ref string errMsg)
        {
            try
            {
                int Data_Len = 30;
                int Packet_Len = Data_Len + 10;
                Packet_Data = new byte[Packet_Len];

                Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                Packet_Data[02] = 0x00;                                                 // TYPE
                Packet_Data[03] = (byte)G4xHMI.G5Interface.UPDATE_INIT_CODE_NAME;                                           // CMD             G4xHMI.G5Interface.UPDATE_IMAGE
                Packet_Data[04] = (byte)((Data_Len >> 8) & 0x00FF);                     // LENGTH HIGH
                Packet_Data[05] = (byte)(Data_Len & 0x00FF);                            // LENGTH LOW

                byte[] PatternName = Encoding.Default.GetBytes(name);                   // Name
                for (int j = 0; j < PatternName.Length; j++)
                {
                    if (j < 30)
                        Packet_Data[6 + j] = PatternName[j];
                }

                ushort crc = 0;
                CRC16 Crc16 = new CRC16();
                crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);                      // CRC Make
                Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);              // CRC16 HIGH
                Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);                     // CRC16 LOW
                Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;                 // TAILER
                Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;                 // TAILER 

                return true;
            }
            catch (Exception ex)
            {

                errMsg = ex.ToString();
                return false;
                //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_0x41()", ex.ToString());
            }
        }


    }
}
