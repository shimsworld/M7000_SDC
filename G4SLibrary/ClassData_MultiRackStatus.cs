using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G4xHMI
{
    public class FunctionClass
    {
        public static byte[] BlockCopy(byte[] source, int start, int count)
        {
            byte[] dst = new byte[count];
            Buffer.BlockCopy(source, start, dst, 0, count);
            return dst;
        }

        public static string GetStringBulider(byte[] data)
        {
            StringBuilder dataBuilder = new StringBuilder();
            dataBuilder.Append(Encoding.ASCII.GetString(data, 0, data.Length));
            return dataBuilder.ToString();
        }
    }

    public class ClassData_MultiRackStatus
    {
        public enum  AVG
        {
            VAL_REAL,   // 사용않함.
            VAL_MIN,
            VAL_AVG,
            VAL_MAX,

            MAX_ITEM,
        }

        const Int32 FIXED_FRACTION = 100;

        public int CurrentIP;

        // DATA
        public Int32 SubCommand;
        public Int32 VoltageOption;
        public Int32 Fraction;
        public ClassType_Current IDDValue;
        public ClassType_Current ICIValue;
        public ClassType_Current IBATValue;

        //bool avgFirstDeny;  // 에이징시작후 첫번째 데이터는 평균에서 뺀다, 최하 값이 너무 낮음..ㅋ
        public ClassType_Current[] IDDAvgs;
        public ClassType_Current[] ICIAvgs;
        public ClassType_Current[] IBATAvgs;

        public CONST.ETHERNET.POWER_STATUS PowerStatus;
        public Int32 AgingDataType;
        public Int32 Main;              // Pattern Main Code
        public Int32 Sub;               // Pattern Sub Code
        public Int32 PatternIndex;      // Pattern Number
        public Int32 DeviceVersion;

        public UInt32 Red;
        public UInt32 Green;
        public UInt32 Blue;

        public bool validIDD;
        public bool validICI;
        public bool validIBAT;

        public bool MeasureStat_PowerValid; // white only by JKKIM

        public int TestConditionNumber;

        string PatternName;

        // CONTROL
        private int m_PowerCnt_On;
        private int m_PowerCnt_Off;
        private bool m_PowerCnt_StatSave;

        public ClassData_MultiRackStatus()
        {
            IDDValue = new ClassType_Current();
            ICIValue = new ClassType_Current();
            IBATValue = new ClassType_Current();

            //avgFirstDeny = false;
            IDDAvgs = new ClassType_Current[(int)AVG.MAX_ITEM];
            ICIAvgs = new ClassType_Current[(int)AVG.MAX_ITEM];
            IBATAvgs = new ClassType_Current[(int)AVG.MAX_ITEM];

            for (int i = 0; i < (int)AVG.MAX_ITEM; ++i)
            {
                IDDAvgs[i] = new ClassType_Current();
                ICIAvgs[i] = new ClassType_Current();
                IBATAvgs[i] = new ClassType_Current();
            }

            // 유니크한 상태 초기 설정
            PowerStatus = CONST.ETHERNET.POWER_STATUS.MRACK_POWER_STATE_NONE;
            PowerCnt_On = 0;
            PowerCnt_Off = 0;
            PowerCnt_StatSave = false;

            ResetData();
            //ClearAverage();
        }

        public void ResetData()
        {
            CurrentIP = 0;
            SubCommand = 0;
            VoltageOption = 0;
            Fraction = FIXED_FRACTION;

            IDDValue.resetData();
            ICIValue.resetData();
            IBATValue.resetData();

            validIDD = false;
            validICI = false;
            validIBAT = false;

            Main = 0;
            Sub = 0;
            PatternIndex = 0;
            DeviceVersion = 0;

            Red = 0;
            Green = 0;
            Blue = 0;

            MeasureStat_PowerValid = false;

            AgingDataType = 0;
            PatternName = "";
        }

#if false
        public void ClearAverage()
        {
            //avgFirstDeny = false;
            avgFirstDeny = true; // white only by JKKIM

            TestConditionNumber = 0;

            for (int i = 0; i < (int)AVG.MAX_ITEM; ++i)
            {
                IDDAvgs[i].data = -1;
                ICIAvgs[i].data = -1;
                IBATAvgs[i].data = -1;
            }

            if (Global_G5.AverageData != null)
            {
                Global_G5.AverageData.ResetData();
            }

            ResetData();
        }

        private void AddAverageCurrentValue(int Ip)
        {
            if (avgFirstDeny == false)
            {
                avgFirstDeny = true;
                return;
            }

            // MIN
            if (IDDAvgs[(int)AVG.VAL_MIN].data == -1 && IDDValue.getMilliData() > 0)
            {
                IDDAvgs[(int)AVG.VAL_MIN].setData(IDDValue.data, IDDValue.fraction);
            }
            else
            {
                if (IDDAvgs[(int)AVG.VAL_MIN].data > IDDValue.data && IDDValue.getMilliData() > 0)
                {
                    IDDAvgs[(int)AVG.VAL_MIN].setData(IDDValue.data, IDDValue.fraction);
                }
            }

            if (ICIAvgs[(int)AVG.VAL_MIN].data == -1 && ICIValue.getMilliData() > 0)
            {
                ICIAvgs[(int)AVG.VAL_MIN].setData(ICIValue.data, ICIValue.fraction);
            }
            else
            {
                if (ICIAvgs[(int)AVG.VAL_MIN].data > ICIValue.data && ICIValue.getMilliData() > 0)
                {
                    ICIAvgs[(int)AVG.VAL_MIN].setData(ICIValue.data, ICIValue.fraction);
                }
            }

            if (IBATAvgs[(int)AVG.VAL_MIN].data == -1 && IBATValue.getMilliData() > 0)
            {
                IBATAvgs[(int)AVG.VAL_MIN].setData(IBATValue.data, IBATValue.fraction);
            }
            else
            {
                if (IBATAvgs[(int)AVG.VAL_MIN].data > IBATValue.data && IBATValue.getMilliData() > 0)
                {
                    IBATAvgs[(int)AVG.VAL_MIN].setData(IBATValue.data, IBATValue.fraction);
                }
            }

            // AVG
#if true
            if (Global_G5.AverageData != null)
            {
                if (IBATValue.getMilliData() <= 0 || ICIValue.getMilliData() <= 0 || IDDValue.getMilliData() <= 0)
                {

                }
                else
                {
                    TestConditionNumber = Global_G5.AgingTimeControl.GetAgingCount();
                    Global_G5.AverageData.AddData(Ip);
                    Global_G5.ChamberControl.AddPFFailCount(Ip, TestConditionNumber);
                }
            }
#else
            if (IDDAvgs[(int)AVG.VAL_AVG].data == -1)
            {
                IDDAvgs[(int)AVG.VAL_AVG].setData(IDDValue.data, IDDValue.fraction);
            }
            else
            {
                IDDAvgs[(int)AVG.VAL_AVG].data = (IDDAvgs[(int)AVG.VAL_AVG].data + IDDValue.data) / 2;
                IDDAvgs[(int)AVG.VAL_AVG].fraction = IDDValue.fraction;
            }

            if (ICIAvgs[(int)AVG.VAL_AVG].data == -1)
            {
                ICIAvgs[(int)AVG.VAL_AVG].setData(ICIValue.data, ICIValue.fraction);
            }
            else
            {
                ICIAvgs[(int)AVG.VAL_AVG].data = (ICIAvgs[(int)AVG.VAL_AVG].data + ICIValue.data) / 2;
                ICIAvgs[(int)AVG.VAL_AVG].fraction = ICIValue.fraction;
            }

            if (IBATAvgs[(int)AVG.VAL_AVG].data == -1)
            {
                IBATAvgs[(int)AVG.VAL_AVG].setData(IBATValue.data, IBATValue.fraction);
            }
            else
            {
                IBATAvgs[(int)AVG.VAL_AVG].data = (IBATAvgs[(int)AVG.VAL_AVG].data + IBATValue.data) / 2;
                IBATAvgs[(int)AVG.VAL_AVG].fraction = IBATValue.fraction;
            }
#endif

            // MAX
            if (IDDAvgs[(int)AVG.VAL_MAX].data == -1)
            {
                IDDAvgs[(int)AVG.VAL_MAX].setData(IDDValue.data, IDDValue.fraction);
            }
            else
            {
                if (IDDAvgs[(int)AVG.VAL_MAX].data < IDDValue.data)
                {
                    IDDAvgs[(int)AVG.VAL_MAX].setData(IDDValue.data, IDDValue.fraction);
                }
            }

            if (ICIAvgs[(int)AVG.VAL_MAX].data == -1)
            {
                ICIAvgs[(int)AVG.VAL_MAX].setData(ICIValue.data, ICIValue.fraction);
            }
            else
            {
                if (ICIAvgs[(int)AVG.VAL_MAX].data < ICIValue.data)
                {
                    ICIAvgs[(int)AVG.VAL_MAX].setData(ICIValue.data, ICIValue.fraction);
                }
            }

            if (IBATAvgs[(int)AVG.VAL_MAX].data == -1)
            {
                IBATAvgs[(int)AVG.VAL_MAX].setData(IBATValue.data, IBATValue.fraction);
            }
            else
            {
                if (IBATAvgs[(int)AVG.VAL_MAX].data < IBATValue.data)
                {
                    IBATAvgs[(int)AVG.VAL_MAX].setData(IBATValue.data, IBATValue.fraction);
                }
            }
        }
#endif

        public int PowerCnt_On
        {
            set { m_PowerCnt_On = value; }
            get { return m_PowerCnt_On;  }
        }

        public int PowerCnt_Off
        {
            set { m_PowerCnt_Off = value;}
            get { return m_PowerCnt_Off; }
        }

        
        private bool PowerCnt_StatSave
        {
            set { m_PowerCnt_StatSave = value;  }
            get { return m_PowerCnt_StatSave;   }
        }

        private G5InterfaceMultiRackControl GetSubCommand(byte[] data)
        {
            G5InterfaceMultiRackControl cmd;

            cmd = (G5InterfaceMultiRackControl) (DefineUtils.Left_Shift_Byte(data[0], 3) | DefineUtils.Left_Shift_Byte(data[1], 2)
                        | DefineUtils.Left_Shift_Byte(data[2], 1) | DefineUtils.Left_Shift_Byte(data[3], 0));

            return cmd;
        }

        private void SetSubCommand(byte[] data)
        {
            SubCommand = DefineUtils.Left_Shift_Byte(data[0], 3)| DefineUtils.Left_Shift_Byte(data[1], 2)
                        | DefineUtils.Left_Shift_Byte(data[2], 1) | DefineUtils.Left_Shift_Byte(data[3], 0);
        }

        private void SetSubCommand(G5InterfaceMultiRackControl cmd)
        {
            SubCommand = (int)cmd;
        }

        private void SetPatternInfo(byte[] data)
        {
            Main = data[0];
            Sub = data[1];
        }

        private int GetPatternIndex(byte[] data)
        {
           return (int)data[0];
        }

        private void SetPatternIndex(byte[] data)
        {
            PatternIndex = data[0];
        }

        private void SetPatternColor(byte[] data)
        {
            Red = data[0];
            Green = data[1];
            Blue = data[2];
        }

        private void SetPowerStatus(byte[] data)
        {
            //CONST.ETHERNET.POWER_STATUS tmpStatus = (CONST.ETHERNET.POWER_STATUS)data[0];

            PowerStatus = (CONST.ETHERNET.POWER_STATUS)data[0];

            if (PowerCnt_StatSave)
            {
                if (PowerStatus == CONST.ETHERNET.POWER_STATUS.MRACK_POWER_STATE_LCD_OFF 
                    || PowerStatus == CONST.ETHERNET.POWER_STATUS.MRACK_POWER_STATE_OFF
                    || PowerStatus == CONST.ETHERNET.POWER_STATUS.MRACK_POWER_STATE_NONE)
                {
                    PowerCnt_Off++;
                    PowerCnt_StatSave = false;
                }
            }
            else
            {
                if (PowerStatus == CONST.ETHERNET.POWER_STATUS.MRACK_POWER_STATE_LCD_ON
                    || PowerStatus == CONST.ETHERNET.POWER_STATUS.MRACK_POWER_STATE_ON
                    || PowerStatus == CONST.ETHERNET.POWER_STATUS.MRACK_POWER_STATE_NONE)
                {
                    PowerCnt_On++;
                    PowerCnt_StatSave = true;
                }
            }
        }

        private void SetDeviceVersion(byte[] data)
        {
            DeviceVersion = data[0];
        }

        private void SetAgingDataType(byte[] data)
        {
            AgingDataType = data[0];
        }

        private void SetValueIDD(byte[] data)
        {
            IDDValue.data = DefineUtils.Left_Shift_Byte(data[0], 3) | DefineUtils.Left_Shift_Byte(data[1], 2)
                    | DefineUtils.Left_Shift_Byte(data[2], 1) | DefineUtils.Left_Shift_Byte(data[3], 0);

            IDDValue.fraction = Fraction;
        }

        private void SetValueICI(byte[] data)
        {
            ICIValue.data = DefineUtils.Left_Shift_Byte(data[0], 3) | DefineUtils.Left_Shift_Byte(data[1], 2)
                    | DefineUtils.Left_Shift_Byte(data[2], 1) | DefineUtils.Left_Shift_Byte(data[3], 0);

            ICIValue.fraction = Fraction;
        }

        private void SetValueIBAT(byte[] data)
        {
            IBATValue.data = DefineUtils.Left_Shift_Byte(data[0], 3) | DefineUtils.Left_Shift_Byte(data[1], 2)
                    | DefineUtils.Left_Shift_Byte(data[2], 1) | DefineUtils.Left_Shift_Byte(data[3], 0);

            IBATValue.fraction = Fraction;
        }

        private bool GetMeasureStat_PowerValid(byte[] data)
        {
            byte tmp = 0;
            tmp = data[0];

            // [0] : Power On Valid
            if ((tmp & 0x01) != 0) return true;   // white only by JKKIM
            else return false;
        }

        private void SetMeasureStat(byte[] data)
        {
            byte tmp = 0;

            tmp = data[0];

            // [0] : Power On Valid
            if ((tmp & 0x01) != 0) MeasureStat_PowerValid = true;   // white only by JKKIM
            else MeasureStat_PowerValid = false;

            // [1:7] : RSV
        }

        private void SetMeasureStat_PowerValid(bool tmp)
        {
            MeasureStat_PowerValid = tmp;
        }

        private void SetImageName(byte[] data)
        {
            int index = 0;
            foreach (byte item in data)
            {
                if (item != 0x00) index++;
                else break;   
            }

            PatternName = FunctionClass.GetStringBulider(FunctionClass.BlockCopy(data, 0, index));
        }

        public void SetData(byte[] data, int Ip)
        {
            G5InterfaceMultiRackControl tmpSubCommand = G5InterfaceMultiRackControl.MRACM_CMD_UNKNOWN;

            try
            {
                this.CurrentIP = Ip;
                
                //SetSubCommand((FunctionClass.BlockCopy(data, 0, 4))); // org

                tmpSubCommand = GetSubCommand((FunctionClass.BlockCopy(data, 6, 4)));

                // 에이징 커먼드만 저장
                //if (tmpSubCommand != G5InterfaceMultiRackControl.MRACK_RES_AUTO_AGING_DATA)
                //{
                //    SetMeasureStat_PowerValid(false);
                //    return;
                //}

                // Power valid : 파워온후 약 1.8초가 지났는가.
                /*
                if (GetMeasureStat_PowerValid((FunctionClass.BlockCopy(data, 25, 1))) == false)
                {
                    SetMeasureStat_PowerValid(false);
                    return;
                }
                */

                // 요구하는 패턴 인가? 
                /*
                if (GetPatternIndex((FunctionClass.BlockCopy(data, 7, 1))) + 1 != Global_G5.AgingConfig.PatternCurrentMeasNo)
                {
                    SetMeasureStat_PowerValid(false);
                    return;   // white only by JKKIM
                }
                */

                if (tmpSubCommand == G5InterfaceMultiRackControl.MRACK_CMD_REALTIME_DATA)
                {

                    // 이전 데이터 초기화.
                    ResetData();
                    this.CurrentIP = Ip;

                    // set data
                    SetSubCommand(tmpSubCommand);
                   
                    SetDeviceVersion((FunctionClass.BlockCopy(data, 12, 1)));

                  //  SetPatternInfo((FunctionClass.BlockCopy(data, 4, 2)));
              
                    SetPatternIndex((FunctionClass.BlockCopy(data, 13, 1)));

                    SetValueIDD((FunctionClass.BlockCopy(data, 14, 4)));
                    SetValueICI((FunctionClass.BlockCopy(data, 18, 4)));
                    SetValueIBAT((FunctionClass.BlockCopy(data, 22, 4)));

                    SetAgingDataType((FunctionClass.BlockCopy(data, 26, 1)));

                    SetPatternColor((FunctionClass.BlockCopy(data, 27, 3)));

                    SetPowerStatus((FunctionClass.BlockCopy(data, 30, 1)));

                    // index 25 RSV
                    SetMeasureStat((FunctionClass.BlockCopy(data, 31, 1)));
                                                      

                    //SetSubCommand(tmpSubCommand);

                    //SetPatternInfo((FunctionClass.BlockCopy(data, 4, 2)));
                    //SetDeviceVersion((FunctionClass.BlockCopy(data, 6, 1)));
                    //SetPatternIndex((FunctionClass.BlockCopy(data, 7, 1)));

                    //SetValueIDD((FunctionClass.BlockCopy(data, 8, 4)));
                    //SetValueICI((FunctionClass.BlockCopy(data, 12, 4)));
                    //SetValueIBAT((FunctionClass.BlockCopy(data, 16, 4)));

                    //SetAgingDataType((FunctionClass.BlockCopy(data, 20, 1)));
                    //SetPatternColor((FunctionClass.BlockCopy(data, 21, 3)));
                    //SetPowerStatus((FunctionClass.BlockCopy(data, 24, 1)));

                    //// index 25 RSV
                    //SetMeasureStat((FunctionClass.BlockCopy(data, 25, 1)));

                    //if (data.Length > 26) SetImageName((FunctionClass.BlockCopy(data, 26, 30)));
                   
                }

             
                //Report();

                // 평균 구하기.
                /*
                if (SubCommand == (int)G5InterfaceMultiRackControl.MRACK_RES_AUTO_AGING_DATA)
                {
                    if (PowerStatus == CONST.ETHERNET.POWER_STATUS.MRACK_POWER_STATE_LCD_ON
                        || PowerStatus == CONST.ETHERNET.POWER_STATUS.MRACK_POWER_STATE_ON)
                    {
                        AddAverageCurrentValue(Ip);
                    }
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("ClassData_MultiRackStatus.SetData()" + ex.ToString());
            }
        }

        private void Report()
        {
            string report = "***** Multi Rack Report*****";

            report += "\r\n" + "SubCommand: 0x" + SubCommand.ToString("X") + ", Aging Data Type : " + AgingDataType.ToString() + ", DevVer: " + DeviceVersion.ToString() + ", Frac: " + Fraction.ToString();
            report += "\r\n" + "IDD: " + IDDValue.getOptimalCurrent().ToString() + IDDValue.getOptimalUnitString();
            report += "\r\n" + "ICI: " + ICIValue.getOptimalCurrent().ToString() + ICIValue.getOptimalUnitString();
            report += "\r\n" + "IBAT:" + IBATValue.getOptimalCurrent().ToString() + IBATValue.getOptimalUnitString();
            report += "\r\n" + "Main : " + Main.ToString() + ", Sub: " + Sub.ToString() + ", PattIdx: " + PatternIndex.ToString() + ", Name: " + PatternName;
            report += "\r\n" + "Color (0x" + Red.ToString("x") + ", 0x" + Green.ToString("x") + ", 0x" + Blue.ToString("x") + ")";
            report += "\r\n" + "VoltageOpt: 0x" + VoltageOption.ToString("X") + ", Valid: " + validIDD.ToString() + "," + validICI.ToString() + ", " + validIBAT.ToString();

            MessageBox.Show(report);
        }
    }
}
