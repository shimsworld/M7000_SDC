using System;
using System.Collections.Generic;
using System.Text;

namespace G4xHMI
{
    // 통신 관련 - TCP
    public class Class_Protocol
    {
        public class TcpIp
        {
            // 통신 프로토콜 - PC 모니터링
            public class G5_TCPIP
            {
                public void Make_Packet(int Code, int First_Data, int Second_Data, ref byte[] Packet_Data)
                {
                    try
                    {
                        switch (Code)
                        {
                            // Check State
                            case (int)G5Interface.REQUEST_STATUS:   // 0x01
                                Make_Packet_0x01(Code, ref Packet_Data);
                                break;
                            // Control Device
                            case (int)G5Interface.CONTROL_DEVICE:   // 0x31
                                Make_Packet_0x31(Code, First_Data, Second_Data, ref Packet_Data);
                                break;
                            case (int)G5Interface.CURRENT_CONTROL: // 0x32
                                Make_Packet_CURRENT_CONTROL(Code, First_Data, Second_Data, ref Packet_Data);
                                break;
                            case (int)G5Interface.MULTI_RACK_CONTROL: // 0x33
                                Make_Packet_MULTI_RACK_CONTROL(Code, First_Data, Second_Data, ref Packet_Data);
                                break;
                            default:
                                Packet_Data = null;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet(int)", ex.ToString());
                    }
                }

                public void Make_Packet_Ext(int Code, int First_Data, object Second_Data, ref byte[] Packet_Data)
                {
                    try
                    {
                        switch (Code)
                        {
                            case (int)G5Interface.REQUEST_STATUS: // 0x01,
                                break;
                            case (int)G5Interface.REQUEST_TOUCH:  // 0x02,
                                break;
                            case (int)G5Interface.REQUEST_PATTERN:// 0x11,
                                break;
                            case (int)G5Interface.REQUEST_MODULE: // 0x12,
                                break;
                            case (int)G5Interface.REQUEST_POWERON:// 0x13,
                                break;
                            case (int)G5Interface.REQUEST_POWEROFF:// 0x14,
                                break;
                            case (int)G5Interface.UPDATE_PATTERN_LIST: // 0x21,
                                break;
                            case (int)G5Interface.UPDATE_MODULE:  // 0x22,
                                break;
                            case (int)G5Interface.UPDATE_POWERON: // 0x23,
                                break;
                            case (int)G5Interface.UPDATE_POWEROFF:// 0x24,
                                break;
                            case (int)G5Interface.CONTROL_DEVICE: // 0x31,
                                break;
                            case (int)G5Interface.UPDATE_IMAGE:   // 0x41,
                                break;
                            case (int)G5Interface.UPDATE_FIRMWARE:// 0x42,
                                break;
                            case (int)G5Interface.UPDATE_FPGR:    // 0x43,
                                break;
                            case (int)G5Interface.UPDATE_CONFIG:  // 0x51,
                                break;
                            case (int)G5Interface.FWUPGRADE_CMD:  // 0x61, // JKKIM ADDED : FW-UPGRADE
                                break;
                            case (int)G5Interface.FWUPGRADE_IMG:  // 0x62, // JKKIM ADDED : FW-UPGRADE
                                break;
                            case (int)G5Interface.GNTICMD_CTL:    // 0x63, // JKKIM ADDED : GNT-I (GnT system Interpreter)
                                break;
                            case (int)G5Interface.CURRENT_CONTROL: // 0x32
                                Make_Packet_CURRENT_CONTROL(Code, First_Data, Second_Data, ref Packet_Data);
                                break;
                            case (int)G5Interface.MULTI_RACK_CONTROL: // 0x33
                                Make_Packet_MULTI_RACK_CONTROL(Code, First_Data, Second_Data, ref Packet_Data);
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet(object)", ex.ToString());
                    }
                }

                private void Make_Packet_Empty(int Code, ref byte[] Packet_Data)
                {
                    try
                    {
                        int Packet_Len = 18;
                        int Data_Len = Packet_Len - 10;
                        Packet_Data = new byte[Packet_Len];

                        Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                        Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                        Packet_Data[02] = 0x00;                                                 // TYPE
                        Packet_Data[03] = (byte)Code;                                           // CODE
                        Packet_Data[04] = (byte)((Data_Len >> 8) & 0x00FF);                     // LENGTH HIGH
                        Packet_Data[05] = (byte)(Data_Len & 0x00FF);                            // LENGTH LOW
                        
                        ushort crc = 0;
                        CRC16 Crc16 = new CRC16();
                        crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);                      // CRC Make
                        Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);              // CRC16 HIGH
                        Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);                     // CRC16 LOW
                        Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;                 // TAILER
                        Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;                 // TAILER 
                    }
                    catch (Exception ex)
                    {
                        //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_Empty()", ex.ToString());
                    }
                }
                private void Make_Packet_0x01(int Code, ref byte[] Packet_Data)
                {
                    try
                    {
                        int Data_Len = 8;
                        int Packet_Len = Data_Len + 10;
                        Packet_Data = new byte[Packet_Len];

                        Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                        Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                        Packet_Data[02] = 0x00;                                                 // TYPE
                        Packet_Data[03] = (byte)Code;                                           // CODE
                        Packet_Data[04] = (byte)((Data_Len >> 8) & 0x00FF);                     // LENGTH HIGH
                        Packet_Data[05] = (byte)(Data_Len & 0x00FF);                            // LENGTH LOW

                        Packet_Data[06] = 0x00;                                                 // Reserved
                        Packet_Data[07] = 0x00;                                                 
                        Packet_Data[08] = 0x00;                                                 
                        Packet_Data[09] = 0x00;                                                 
                        Packet_Data[10] = 0x00;                                                 
                        Packet_Data[11] = 0x00;                                                 
                        Packet_Data[12] = 0x00;                                                 
                        Packet_Data[13] = 0x00;                                                 

                        ushort crc = 0;
                        CRC16 Crc16 = new CRC16();
                        crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);                      // CRC Make
                        Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);              // CRC16 HIGH
                        Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);                     // CRC16 LOW
                        Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;                 // TAILER
                        Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;                 // TAILER 
                    }
                    catch (Exception ex)
                    {
                        //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_0x01()", ex.ToString());
                    }
                }
   
                private void Make_Packet_0x31(int Code, int MainCode, int SubCode, ref byte[] Packet_Data)
                {
                    try
                    {
                        int Data_Len = 12;
                        int Packet_Len = Data_Len + 10;
                        Packet_Data = new byte[Packet_Len];

                        Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                        Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                             // HEADER
                        Packet_Data[02] = 0x00;                                                 // TYPE
                        Packet_Data[03] = (byte)Code;                                           // CMD
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
                    }
                    catch (Exception ex)
                    {
                        //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_0x31()", ex.ToString());
                    }
                }

                public int Make_Packet_MULTI_RACK_CONTROL(int Code, int MainCode, object SecondData, ref byte[] Packet_Data)
                {
                    /* Command 0xx31 */
                    int size = 0;

                    ClassData_CurrentControl opt = (ClassData_CurrentControl)SecondData;

                    //MessageBox.Show("Voltage Option " + opt.voltageOption);

                    try
                    {
                        int Data_Len = 8;
                        int Packet_Len = Data_Len + 10;
                        Packet_Data = new byte[Packet_Len];

                        Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                   // HEADER
                        Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                   // HEADER
                        Packet_Data[02] = 0x00;                                 // TYPE
                        Packet_Data[03] = (byte)Code;                           // CMD
                        Packet_Data[04] = (byte)((Data_Len >> 8) & 0x00FF);     // LENGTH HIGH
                        Packet_Data[05] = (byte)(Data_Len & 0x00FF);            // LENGTH LOW

                        Packet_Data[06] = DefineUtils.Shift_Data(MainCode, 4);   // Sub Command
                        Packet_Data[07] = DefineUtils.Shift_Data(MainCode, 3);
                        Packet_Data[08] = DefineUtils.Shift_Data(MainCode, 2);
                        Packet_Data[09] = DefineUtils.Shift_Data(MainCode, 1);

                        Packet_Data[10] = DefineUtils.Shift_Data((int)opt.voltageOption_MultiRack, 4); // Voltage Option
                        Packet_Data[11] = DefineUtils.Shift_Data((int)opt.voltageOption_MultiRack, 3);
                        Packet_Data[12] = DefineUtils.Shift_Data((int)opt.voltageOption_MultiRack, 2);
                        Packet_Data[13] = DefineUtils.Shift_Data((int)opt.voltageOption_MultiRack, 1);

                        ushort crc = 0;
                        CRC16 Crc16 = new CRC16();
                        crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);          // CRC Make
                        Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);  // CRC16 HIGH
                        Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);         // CRC16 LOW
                        Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;           // TAILER
                        Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;           // TAILER 

                        size = Packet_Len;
                    }
                    catch (Exception ex)
                    {
                        //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_MULTI_RACK_CONTROL()", ex.ToString());
                    }

                    return size;
                }

                public int Make_Packet_CURRENT_CONTROL(int Code, int MainCode, object SecondData, ref byte[] Packet_Data)
                {
                    /* Command 0xx31 */
                    int size = 0;

                    ClassData_CurrentControl opt = (ClassData_CurrentControl)SecondData;

                    //MessageBox.Show("Voltage Option " + opt.voltageOption);

                    try
                    {
                        int Data_Len = 20;
                        int Packet_Len = Data_Len + 10;
                        Packet_Data = new byte[Packet_Len];

                        Packet_Data[00] = CONST.ETHERNET.PC.HEADER;                   // HEADER
                        Packet_Data[01] = CONST.ETHERNET.PC.HEADER;                   // HEADER
                        Packet_Data[02] = 0x00;                                 // TYPE
                        Packet_Data[03] = (byte)Code;                           // CMD
                        Packet_Data[04] = (byte)((Data_Len >> 8) & 0x00FF);     // LENGTH HIGH
                        Packet_Data[05] = (byte)(Data_Len & 0x00FF);            // LENGTH LOW

                        Packet_Data[06] = DefineUtils.Shift_Data(MainCode, 4);   // Sub Command
                        Packet_Data[07] = DefineUtils.Shift_Data(MainCode, 3);
                        Packet_Data[08] = DefineUtils.Shift_Data(MainCode, 2);
                        Packet_Data[09] = DefineUtils.Shift_Data(MainCode, 1);

                        Packet_Data[10] = DefineUtils.Shift_Data((int)opt.voltageOption_CurrentMeasure, 4); // Voltage Option
                        Packet_Data[11] = DefineUtils.Shift_Data((int)opt.voltageOption_CurrentMeasure, 3);
                        Packet_Data[12] = DefineUtils.Shift_Data((int)opt.voltageOption_CurrentMeasure, 2);
                        Packet_Data[13] = DefineUtils.Shift_Data((int)opt.voltageOption_CurrentMeasure, 1);

                        Packet_Data[14] = DefineUtils.Shift_Data((int)opt.IDD, 4);   // IDD
                        Packet_Data[15] = DefineUtils.Shift_Data((int)opt.IDD, 3);
                        Packet_Data[16] = DefineUtils.Shift_Data((int)opt.IDD, 2);
                        Packet_Data[17] = DefineUtils.Shift_Data((int)opt.IDD, 1);

                        Packet_Data[18] = DefineUtils.Shift_Data((int)opt.ICI, 4);   // ICI
                        Packet_Data[19] = DefineUtils.Shift_Data((int)opt.ICI, 3);
                        Packet_Data[20] = DefineUtils.Shift_Data((int)opt.ICI, 2);
                        Packet_Data[21] = DefineUtils.Shift_Data((int)opt.ICI, 1);

                        Packet_Data[22] = DefineUtils.Shift_Data((int)opt.IBAT, 4);  // IBAT
                        Packet_Data[23] = DefineUtils.Shift_Data((int)opt.IBAT, 3);
                        Packet_Data[24] = DefineUtils.Shift_Data((int)opt.IBAT, 2);
                        Packet_Data[25] = DefineUtils.Shift_Data((int)opt.IBAT, 1);

                        ushort crc = 0;
                        CRC16 Crc16 = new CRC16();
                        crc = Crc16.crc16(Packet_Data, 0, Packet_Len - 4);          // CRC Make
                        Packet_Data[Packet_Len - 4] = (byte)((crc >> 8) & 0x00FF);  // CRC16 HIGH
                        Packet_Data[Packet_Len - 3] = (byte)(crc & 0x00FF);         // CRC16 LOW
                        Packet_Data[Packet_Len - 2] = CONST.ETHERNET.PC.TAILER;           // TAILER
                        Packet_Data[Packet_Len - 1] = CONST.ETHERNET.PC.TAILER;           // TAILER 

                        size = Packet_Len;
                    }
                    catch (Exception ex)
                    {
                        //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Make_Packet_CURRENT_CONTROL()", ex.ToString());
                    }

                    return size;
                }
                
                // 수신된 패킷 내용을 적용 및 저장
                /*
                public bool Recv_Packet(object sender, Class_Ethernet.DataArgs e)
                {
                    try
                    {
                        byte[] Packet = new byte[e.Data.Length - 10];

                        Buffer.BlockCopy(e.Data, 6, Packet, 0, e.Data.Length - 10);

                        string IpAddress = e.IpAddress;
                        for (int i = 0; i < 3; i++)
                        {
                            int Temp = IpAddress.IndexOf(".", 0);
                            IpAddress = IpAddress.Substring(Temp + 1);
                        }
                        int Ip = int.Parse(IpAddress);

                        switch ((G5InterfaceAck)e.Code)
                        {
                            case G5InterfaceAck.REQUEST_STATUS:
                                Global_G5.Watchs.Status[Ip - 1].SetData(Packet);
                                Global_G5.MeasControl.modelDataFetch(Ip - 1, Global_G5.Watchs.Status[Ip - 1].ModelName, Global_G5.Watchs.Status[Ip - 1].PatListName);
                                break;       // Power
                            case G5InterfaceAck.REQUEST_TOUCH:
                                //Setup_Packet_0x82(e.IpAddress, e.Data );
                                break;       // Tsp
                            case G5InterfaceAck.FWUPGRADE_REQ:  // ADDED JKKIM : FW-UPGRADE
                                FW_Upgrade(e, Packet);
                                break;
                            case G5InterfaceAck.GNTICMD_REQ:    // GNTI
                                GNTI_Process(e, Packet);
                                break;
                            case G5InterfaceAck.CURRENT_CONTROL:
                                // 구미 옥타 에이징 장비에서는 일단 여기로 들어 오지 않습니다.
                                Global_G5.DataCurrent[Ip - 1].SetData(Packet);
                                break;
                            case G5InterfaceAck.MULTI_RACK_CONTROL:
                                Global_G5.DataMultiRack[Ip - 1].SetData(Packet, Ip);
                                break;
                            default: break;
                        }
                    }
                    catch (Exception ex)
                    {
                        //Debug.Message.Show("Class_Protocol.cs", "Protocol - TCPIP - G5_TCPIP", "Recv_Packet()", ex.ToString());
                    }

                    return true;
                }
                */

            }
        }
    }

    public class CRC16
    {
        private readonly byte[] auchCRCHi = new byte[256];
        private readonly byte[] auchCRCLo = new byte[256];

        public CRC16()
        {
            auchCRCHi[0] = 0x00;
            auchCRCHi[1] = 0xC1;
            auchCRCHi[2] = 0x81;
            auchCRCHi[3] = 0x40;
            auchCRCHi[4] = 0x01;
            auchCRCHi[5] = 0xC0;
            auchCRCHi[6] = 0x80;
            auchCRCHi[7] = 0x41;
            auchCRCHi[8] = 0x01;
            auchCRCHi[9] = 0xC0;
            auchCRCHi[10] = 0x80;
            auchCRCHi[11] = 0x41;
            auchCRCHi[12] = 0x00;
            auchCRCHi[13] = 0xC1;
            auchCRCHi[14] = 0x81;

            auchCRCHi[15] = 0x40;
            auchCRCHi[16] = 0x01;
            auchCRCHi[17] = 0xC0;
            auchCRCHi[18] = 0x80;
            auchCRCHi[19] = 0x41;
            auchCRCHi[20] = 0x00;
            auchCRCHi[21] = 0xC1;
            auchCRCHi[22] = 0x81;
            auchCRCHi[23] = 0x40;
            auchCRCHi[24] = 0x00;
            auchCRCHi[25] = 0xC1;
            auchCRCHi[26] = 0x81;
            auchCRCHi[27] = 0x40;
            auchCRCHi[28] = 0x01;
            auchCRCHi[29] = 0xC0;

            auchCRCHi[30] = 0x80;
            auchCRCHi[31] = 0x41;
            auchCRCHi[32] = 0x01;
            auchCRCHi[33] = 0xC0;
            auchCRCHi[34] = 0x80;
            auchCRCHi[35] = 0x41;
            auchCRCHi[36] = 0x00;
            auchCRCHi[37] = 0xC1;
            auchCRCHi[38] = 0x81;
            auchCRCHi[39] = 0x40;
            auchCRCHi[40] = 0x00;
            auchCRCHi[41] = 0xC1;
            auchCRCHi[42] = 0x81;
            auchCRCHi[43] = 0x40;
            auchCRCHi[44] = 0x01;

            auchCRCHi[45] = 0xC0;
            auchCRCHi[46] = 0x80;
            auchCRCHi[47] = 0x41;
            auchCRCHi[48] = 0x00;
            auchCRCHi[49] = 0xC1;
            auchCRCHi[50] = 0x81;
            auchCRCHi[51] = 0x40;
            auchCRCHi[52] = 0x01;
            auchCRCHi[53] = 0xC0;
            auchCRCHi[54] = 0x80;
            auchCRCHi[55] = 0x41;
            auchCRCHi[56] = 0x01;
            auchCRCHi[57] = 0xC0;
            auchCRCHi[58] = 0x80;
            auchCRCHi[59] = 0x41;

            auchCRCHi[60] = 0x00;
            auchCRCHi[61] = 0xC1;
            auchCRCHi[62] = 0x81;
            auchCRCHi[63] = 0x40;
            auchCRCHi[64] = 0x01;
            auchCRCHi[65] = 0xC0;
            auchCRCHi[66] = 0x80;
            auchCRCHi[67] = 0x41;
            auchCRCHi[68] = 0x00;
            auchCRCHi[69] = 0xC1;
            auchCRCHi[70] = 0x81;
            auchCRCHi[71] = 0x40;
            auchCRCHi[72] = 0x00;
            auchCRCHi[73] = 0xC1;
            auchCRCHi[74] = 0x81;

            auchCRCHi[75] = 0x40;
            auchCRCHi[76] = 0x01;
            auchCRCHi[77] = 0xC0;
            auchCRCHi[78] = 0x80;
            auchCRCHi[79] = 0x41;
            auchCRCHi[80] = 0x00;
            auchCRCHi[81] = 0xC1;
            auchCRCHi[82] = 0x81;
            auchCRCHi[83] = 0x40;
            auchCRCHi[84] = 0x01;
            auchCRCHi[85] = 0xC0;
            auchCRCHi[86] = 0x80;
            auchCRCHi[87] = 0x41;
            auchCRCHi[88] = 0x01;
            auchCRCHi[89] = 0xC0;

            auchCRCHi[90] = 0x80;
            auchCRCHi[91] = 0x41;
            auchCRCHi[92] = 0x00;
            auchCRCHi[93] = 0xC1;
            auchCRCHi[94] = 0x81;
            auchCRCHi[95] = 0x40;
            auchCRCHi[96] = 0x00;
            auchCRCHi[97] = 0xC1;
            auchCRCHi[98] = 0x81;
            auchCRCHi[99] = 0x40;
            auchCRCHi[100] = 0x01;
            auchCRCHi[101] = 0xC0;
            auchCRCHi[102] = 0x80;
            auchCRCHi[103] = 0x41;
            auchCRCHi[104] = 0x01;

            auchCRCHi[105] = 0xC0;
            auchCRCHi[106] = 0x80;
            auchCRCHi[107] = 0x41;
            auchCRCHi[108] = 0x00;
            auchCRCHi[109] = 0xC1;
            auchCRCHi[110] = 0x81;
            auchCRCHi[111] = 0x40;
            auchCRCHi[112] = 0x01;
            auchCRCHi[113] = 0xC0;
            auchCRCHi[114] = 0x80;
            auchCRCHi[115] = 0x41;
            auchCRCHi[116] = 0x00;
            auchCRCHi[117] = 0xC1;
            auchCRCHi[118] = 0x81;
            auchCRCHi[119] = 0x40;

            auchCRCHi[120] = 0x00;
            auchCRCHi[121] = 0xC1;
            auchCRCHi[122] = 0x81;
            auchCRCHi[123] = 0x40;
            auchCRCHi[124] = 0x01;
            auchCRCHi[125] = 0xC0;
            auchCRCHi[126] = 0x80;
            auchCRCHi[127] = 0x41;
            auchCRCHi[128] = 0x01;
            auchCRCHi[129] = 0xC0;
            auchCRCHi[130] = 0x80;
            auchCRCHi[131] = 0x41;
            auchCRCHi[132] = 0x00;
            auchCRCHi[133] = 0xC1;
            auchCRCHi[134] = 0x81;

            auchCRCHi[135] = 0x40;
            auchCRCHi[136] = 0x00;
            auchCRCHi[137] = 0xC1;
            auchCRCHi[138] = 0x81;
            auchCRCHi[139] = 0x40;
            auchCRCHi[140] = 0x01;
            auchCRCHi[141] = 0xC0;
            auchCRCHi[142] = 0x80;
            auchCRCHi[143] = 0x41;
            auchCRCHi[144] = 0x00;
            auchCRCHi[145] = 0xC1;
            auchCRCHi[146] = 0x81;
            auchCRCHi[147] = 0x40;
            auchCRCHi[148] = 0x01;
            auchCRCHi[149] = 0xC0;

            auchCRCHi[150] = 0x80;
            auchCRCHi[151] = 0x41;
            auchCRCHi[152] = 0x01;
            auchCRCHi[153] = 0xC0;
            auchCRCHi[154] = 0x80;
            auchCRCHi[155] = 0x41;
            auchCRCHi[156] = 0x00;
            auchCRCHi[157] = 0xC1;
            auchCRCHi[158] = 0x81;
            auchCRCHi[159] = 0x40;
            auchCRCHi[160] = 0x00;
            auchCRCHi[161] = 0xC1;
            auchCRCHi[162] = 0x81;
            auchCRCHi[163] = 0x40;
            auchCRCHi[164] = 0x01;

            auchCRCHi[165] = 0xC0;
            auchCRCHi[166] = 0x80;
            auchCRCHi[167] = 0x41;
            auchCRCHi[168] = 0x01;
            auchCRCHi[169] = 0xC0;
            auchCRCHi[170] = 0x80;
            auchCRCHi[171] = 0x41;
            auchCRCHi[172] = 0x00;
            auchCRCHi[173] = 0xC1;
            auchCRCHi[174] = 0x81;
            auchCRCHi[175] = 0x40;
            auchCRCHi[176] = 0x01;
            auchCRCHi[177] = 0xC0;
            auchCRCHi[178] = 0x80;
            auchCRCHi[179] = 0x41;

            auchCRCHi[180] = 0x00;
            auchCRCHi[181] = 0xC1;
            auchCRCHi[182] = 0x81;
            auchCRCHi[183] = 0x40;
            auchCRCHi[184] = 0x00;
            auchCRCHi[185] = 0xC1;
            auchCRCHi[186] = 0x81;
            auchCRCHi[187] = 0x40;
            auchCRCHi[188] = 0x01;
            auchCRCHi[189] = 0xC0;
            auchCRCHi[190] = 0x80;
            auchCRCHi[191] = 0x41;
            auchCRCHi[192] = 0x00;
            auchCRCHi[193] = 0xC1;
            auchCRCHi[194] = 0x81;

            auchCRCHi[195] = 0x40;
            auchCRCHi[196] = 0x01;
            auchCRCHi[197] = 0xC0;
            auchCRCHi[198] = 0x80;
            auchCRCHi[199] = 0x41;
            auchCRCHi[200] = 0x01;
            auchCRCHi[201] = 0xC0;
            auchCRCHi[202] = 0x80;
            auchCRCHi[203] = 0x41;
            auchCRCHi[204] = 0x00;
            auchCRCHi[205] = 0xC1;
            auchCRCHi[206] = 0x81;
            auchCRCHi[207] = 0x40;
            auchCRCHi[208] = 0x01;
            auchCRCHi[209] = 0xC0;

            auchCRCHi[210] = 0x80;
            auchCRCHi[211] = 0x41;
            auchCRCHi[212] = 0x00;
            auchCRCHi[213] = 0xC1;
            auchCRCHi[214] = 0x81;
            auchCRCHi[215] = 0x40;
            auchCRCHi[216] = 0x00;
            auchCRCHi[217] = 0xC1;
            auchCRCHi[218] = 0x81;
            auchCRCHi[219] = 0x40;
            auchCRCHi[220] = 0x01;
            auchCRCHi[221] = 0xC0;
            auchCRCHi[222] = 0x80;
            auchCRCHi[223] = 0x41;
            auchCRCHi[224] = 0x01;

            auchCRCHi[225] = 0xC0;
            auchCRCHi[226] = 0x80;
            auchCRCHi[227] = 0x41;
            auchCRCHi[228] = 0x00;
            auchCRCHi[229] = 0xC1;
            auchCRCHi[230] = 0x81;
            auchCRCHi[231] = 0x40;
            auchCRCHi[232] = 0x00;
            auchCRCHi[233] = 0xC1;
            auchCRCHi[234] = 0x81;
            auchCRCHi[235] = 0x40;
            auchCRCHi[236] = 0x01;
            auchCRCHi[237] = 0xC0;
            auchCRCHi[238] = 0x80;
            auchCRCHi[239] = 0x41;

            auchCRCHi[240] = 0x00;
            auchCRCHi[241] = 0xC1;
            auchCRCHi[242] = 0x81;
            auchCRCHi[243] = 0x40;
            auchCRCHi[244] = 0x01;
            auchCRCHi[245] = 0xC0;
            auchCRCHi[246] = 0x80;
            auchCRCHi[247] = 0x41;
            auchCRCHi[248] = 0x01;
            auchCRCHi[249] = 0xC0;
            auchCRCHi[250] = 0x80;
            auchCRCHi[251] = 0x41;
            auchCRCHi[252] = 0x00;
            auchCRCHi[253] = 0xC1;
            auchCRCHi[254] = 0x81;
            auchCRCHi[255] = 0x40;


            auchCRCLo[0] = 0x00;
            auchCRCLo[1] = 0xC0;
            auchCRCLo[2] = 0xC1;
            auchCRCLo[3] = 0x01;
            auchCRCLo[4] = 0xC3;
            auchCRCLo[5] = 0x03;
            auchCRCLo[6] = 0x02;
            auchCRCLo[7] = 0xC2;
            auchCRCLo[8] = 0xC6;
            auchCRCLo[9] = 0x06;
            auchCRCLo[10] = 0x07;
            auchCRCLo[11] = 0xC7;
            auchCRCLo[12] = 0x05;
            auchCRCLo[13] = 0xC5;
            auchCRCLo[14] = 0xC4;

            auchCRCLo[15] = 0x04;
            auchCRCLo[16] = 0xCC;
            auchCRCLo[17] = 0x0C;
            auchCRCLo[18] = 0x0D;
            auchCRCLo[19] = 0xCD;
            auchCRCLo[20] = 0x0F;
            auchCRCLo[21] = 0xCF;
            auchCRCLo[22] = 0xCE;
            auchCRCLo[23] = 0x0E;
            auchCRCLo[24] = 0x0A;
            auchCRCLo[25] = 0xCA;
            auchCRCLo[26] = 0xCB;
            auchCRCLo[27] = 0x0B;
            auchCRCLo[28] = 0xC9;
            auchCRCLo[29] = 0x09;

            auchCRCLo[30] = 0x08;
            auchCRCLo[31] = 0xC8;
            auchCRCLo[32] = 0xD8;
            auchCRCLo[33] = 0x18;
            auchCRCLo[34] = 0x19;
            auchCRCLo[35] = 0xD9;
            auchCRCLo[36] = 0x1B;
            auchCRCLo[37] = 0xDB;
            auchCRCLo[38] = 0xDA;
            auchCRCLo[39] = 0x1A;
            auchCRCLo[40] = 0x1E;
            auchCRCLo[41] = 0xDE;
            auchCRCLo[42] = 0xDF;
            auchCRCLo[43] = 0x1F;
            auchCRCLo[44] = 0xDD;

            auchCRCLo[45] = 0x1D;
            auchCRCLo[46] = 0x1C;
            auchCRCLo[47] = 0xDC;
            auchCRCLo[48] = 0x14;
            auchCRCLo[49] = 0xD4;
            auchCRCLo[50] = 0xD5;
            auchCRCLo[51] = 0x15;
            auchCRCLo[52] = 0xD7;
            auchCRCLo[53] = 0x17;
            auchCRCLo[54] = 0x16;
            auchCRCLo[55] = 0xD6;
            auchCRCLo[56] = 0xD2;
            auchCRCLo[57] = 0x12;
            auchCRCLo[58] = 0x13;
            auchCRCLo[59] = 0xD3;

            auchCRCLo[60] = 0x11;
            auchCRCLo[61] = 0xD1;
            auchCRCLo[62] = 0xD0;
            auchCRCLo[63] = 0x10;
            auchCRCLo[64] = 0xF0;
            auchCRCLo[65] = 0x30;
            auchCRCLo[66] = 0x31;
            auchCRCLo[67] = 0xF1;
            auchCRCLo[68] = 0x33;
            auchCRCLo[69] = 0xF3;
            auchCRCLo[70] = 0xF2;
            auchCRCLo[71] = 0x32;
            auchCRCLo[72] = 0x36;
            auchCRCLo[73] = 0xF6;
            auchCRCLo[74] = 0xF7;

            auchCRCLo[75] = 0x37;
            auchCRCLo[76] = 0xF5;
            auchCRCLo[77] = 0x35;
            auchCRCLo[78] = 0x34;
            auchCRCLo[79] = 0xF4;
            auchCRCLo[80] = 0x3C;
            auchCRCLo[81] = 0xFC;
            auchCRCLo[82] = 0xFD;
            auchCRCLo[83] = 0x3D;
            auchCRCLo[84] = 0xFF;
            auchCRCLo[85] = 0x3F;
            auchCRCLo[86] = 0x3E;
            auchCRCLo[87] = 0xFE;
            auchCRCLo[88] = 0xFA;
            auchCRCLo[89] = 0x3A;

            auchCRCLo[90] = 0x3B;
            auchCRCLo[91] = 0xFB;
            auchCRCLo[92] = 0x39;
            auchCRCLo[93] = 0xF9;
            auchCRCLo[94] = 0xF8;
            auchCRCLo[95] = 0x38;
            auchCRCLo[96] = 0x28;
            auchCRCLo[97] = 0xE8;
            auchCRCLo[98] = 0xE9;
            auchCRCLo[99] = 0x29;
            auchCRCLo[100] = 0xEB;
            auchCRCLo[101] = 0x2B;
            auchCRCLo[102] = 0x2A;
            auchCRCLo[103] = 0xEA;
            auchCRCLo[104] = 0xEE;

            auchCRCLo[105] = 0x2E;
            auchCRCLo[106] = 0x2F;
            auchCRCLo[107] = 0xEF;
            auchCRCLo[108] = 0x2D;
            auchCRCLo[109] = 0xED;
            auchCRCLo[110] = 0xEC;
            auchCRCLo[111] = 0x2C;
            auchCRCLo[112] = 0xE4;
            auchCRCLo[113] = 0x24;
            auchCRCLo[114] = 0x25;
            auchCRCLo[115] = 0xE5;
            auchCRCLo[116] = 0x27;
            auchCRCLo[117] = 0xE7;
            auchCRCLo[118] = 0xE6;
            auchCRCLo[119] = 0x26;

            auchCRCLo[120] = 0x22;
            auchCRCLo[121] = 0xE2;
            auchCRCLo[122] = 0xE3;
            auchCRCLo[123] = 0x23;
            auchCRCLo[124] = 0xE1;
            auchCRCLo[125] = 0x21;
            auchCRCLo[126] = 0x20;
            auchCRCLo[127] = 0xE0;
            auchCRCLo[128] = 0xA0;
            auchCRCLo[129] = 0x60;
            auchCRCLo[130] = 0x61;
            auchCRCLo[131] = 0xA1;
            auchCRCLo[132] = 0x63;
            auchCRCLo[133] = 0xA3;
            auchCRCLo[134] = 0xA2;

            auchCRCLo[135] = 0x62;
            auchCRCLo[136] = 0x66;
            auchCRCLo[137] = 0xA6;
            auchCRCLo[138] = 0xA7;
            auchCRCLo[139] = 0x67;
            auchCRCLo[140] = 0xA5;
            auchCRCLo[141] = 0x65;
            auchCRCLo[142] = 0x64;
            auchCRCLo[143] = 0xA4;
            auchCRCLo[144] = 0x6C;
            auchCRCLo[145] = 0xAC;
            auchCRCLo[146] = 0xAD;
            auchCRCLo[147] = 0x6D;
            auchCRCLo[148] = 0xAF;
            auchCRCLo[149] = 0x6F;

            auchCRCLo[150] = 0x6E;
            auchCRCLo[151] = 0xAE;
            auchCRCLo[152] = 0xAA;
            auchCRCLo[153] = 0x6A;
            auchCRCLo[154] = 0x6B;
            auchCRCLo[155] = 0xAB;
            auchCRCLo[156] = 0x69;
            auchCRCLo[157] = 0xA9;
            auchCRCLo[158] = 0xA8;
            auchCRCLo[159] = 0x68;
            auchCRCLo[160] = 0x78;
            auchCRCLo[161] = 0xB8;
            auchCRCLo[162] = 0xB9;
            auchCRCLo[163] = 0x79;
            auchCRCLo[164] = 0xBB;

            auchCRCLo[165] = 0x7B;
            auchCRCLo[166] = 0x7A;
            auchCRCLo[167] = 0xBA;
            auchCRCLo[168] = 0xBE;
            auchCRCLo[169] = 0x7E;
            auchCRCLo[170] = 0x7F;
            auchCRCLo[171] = 0xBF;
            auchCRCLo[172] = 0x7D;
            auchCRCLo[173] = 0xBD;
            auchCRCLo[174] = 0xBC;
            auchCRCLo[175] = 0x7C;
            auchCRCLo[176] = 0xB4;
            auchCRCLo[177] = 0x74;
            auchCRCLo[178] = 0x75;
            auchCRCLo[179] = 0xB5;

            auchCRCLo[180] = 0x77;
            auchCRCLo[181] = 0xB7;
            auchCRCLo[182] = 0xB6;
            auchCRCLo[183] = 0x76;
            auchCRCLo[184] = 0x72;
            auchCRCLo[185] = 0xB2;
            auchCRCLo[186] = 0xB3;
            auchCRCLo[187] = 0x73;
            auchCRCLo[188] = 0xB1;
            auchCRCLo[189] = 0x71;
            auchCRCLo[190] = 0x70;
            auchCRCLo[191] = 0xB0;
            auchCRCLo[192] = 0x50;
            auchCRCLo[193] = 0x90;
            auchCRCLo[194] = 0x91;

            auchCRCLo[195] = 0x51;
            auchCRCLo[196] = 0x93;
            auchCRCLo[197] = 0x53;
            auchCRCLo[198] = 0x52;
            auchCRCLo[199] = 0x92;
            auchCRCLo[200] = 0x96;
            auchCRCLo[201] = 0x56;
            auchCRCLo[202] = 0x57;
            auchCRCLo[203] = 0x97;
            auchCRCLo[204] = 0x55;
            auchCRCLo[205] = 0x95;
            auchCRCLo[206] = 0x94;
            auchCRCLo[207] = 0x54;
            auchCRCLo[208] = 0x9C;
            auchCRCLo[209] = 0x5C;

            auchCRCLo[210] = 0x5D;
            auchCRCLo[211] = 0x9D;
            auchCRCLo[212] = 0x5F;
            auchCRCLo[213] = 0x9F;
            auchCRCLo[214] = 0x9E;
            auchCRCLo[215] = 0x5E;
            auchCRCLo[216] = 0x5A;
            auchCRCLo[217] = 0x9A;
            auchCRCLo[218] = 0x9B;
            auchCRCLo[219] = 0x5B;
            auchCRCLo[220] = 0x99;
            auchCRCLo[221] = 0x59;
            auchCRCLo[222] = 0x58;
            auchCRCLo[223] = 0x98;
            auchCRCLo[224] = 0x88;

            auchCRCLo[225] = 0x48;
            auchCRCLo[226] = 0x49;
            auchCRCLo[227] = 0x89;
            auchCRCLo[228] = 0x4B;
            auchCRCLo[229] = 0x8B;
            auchCRCLo[230] = 0x8A;
            auchCRCLo[231] = 0x4A;
            auchCRCLo[232] = 0x4E;
            auchCRCLo[233] = 0x8E;
            auchCRCLo[234] = 0x8F;
            auchCRCLo[235] = 0x4F;
            auchCRCLo[236] = 0x8D;
            auchCRCLo[237] = 0x4D;
            auchCRCLo[238] = 0x4C;
            auchCRCLo[239] = 0x8C;

            auchCRCLo[240] = 0x44;
            auchCRCLo[241] = 0x84;
            auchCRCLo[242] = 0x85;
            auchCRCLo[243] = 0x45;
            auchCRCLo[244] = 0x87;
            auchCRCLo[245] = 0x47;
            auchCRCLo[246] = 0x46;
            auchCRCLo[247] = 0x86;
            auchCRCLo[248] = 0x82;
            auchCRCLo[249] = 0x42;
            auchCRCLo[250] = 0x43;
            auchCRCLo[251] = 0x83;
            auchCRCLo[252] = 0x41;
            auchCRCLo[253] = 0x81;
            auchCRCLo[254] = 0x80;
            auchCRCLo[255] = 0x40;

        }

        public UInt16 crc16(byte[] modbusframe, int iStart, int iLen)
        {
            uint i;
            uint index;
            uint crc_Low = 0xFF;
            uint crc_High = 0xFF;

            try
            {
                for (i = (uint)iStart; i < (uint)iLen; i++)
                {
                    index = crc_High ^ modbusframe[i];
                    crc_High = crc_Low ^ auchCRCHi[index];
                    crc_Low = (byte)auchCRCLo[index];
                }
            }
            catch (Exception ex)
            {
                //Debug.Message.Show("Class_Protocol.cs", "CRC16", "crc16()", ex.ToString());
            }

            return (UInt16)((crc_High << 8) | crc_Low);

        }

        public UInt16 crc16(byte[] modbusframe)
        {
            return crc16(modbusframe, 0, modbusframe.Length);
        }
    }    
}
