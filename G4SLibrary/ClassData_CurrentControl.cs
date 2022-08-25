using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G4xHMI
{
    enum CURRENT_MEASURE_BIT
    {
        CURRENT_BIT_VDD = (1 << 0),
        CURRENT_BIT_VCI = (1 << 1),
        CURRENT_BIT_VBAT = (1 << 2),
        //CURRENT_BIT_VSS,
        //CURRENT_BIT_VEXT1,
        //CURRENT_BIT_VEXT2,
        //CURRENT_BIT_TVDD,
        //CURRENT_BIT_TVCI,

        CURRENT_BIT_FORCE_UNIT_uA = (1 << 28),
        CURRENT_BIT_FORCE_UNIT_mA = (1 << 29),
        CURRENT_BIT_FORCE_UNIT_AUTO = (CURRENT_BIT_FORCE_UNIT_uA | CURRENT_BIT_FORCE_UNIT_mA),

        CURRENT_BIT_ALL = (1 << 31),  // UNUSED
    }

    enum CURRENT_MULTI_RACK_BIT
    {
        BIT_TYPE_1 = 0,
        BIT_TYPE_2 = 1,

        BIT_TYPE_2_OFF = BIT_TYPE_1,
        BIT_TYPE_2_ON = BIT_TYPE_2,
 
        BIT_AUTO_CURRENT_RES_ON = (1<<1),
    }

    class ClassData_CurrentControl
    {
        private CURRENT_MEASURE_BIT m_voltageOption_CurrentMeasure;
        private int m_voltageOption_MultiRack;

        public UInt32 IDD;
        public UInt32 ICI;
        public UInt32 IBAT;

        public ClassData_CurrentControl()
        {
            try
            {
                initData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ClassData_CurrentControl() : " + ex.ToString());
            }
        }

        public void initData()
        {
            voltageOption_CurrentMeasure = 0;
            voltageOption_MultiRack = 0;
            IDD = 0;
            ICI = 0;
            IBAT = 0;
        }

        public CURRENT_MEASURE_BIT voltageOption_CurrentMeasure
        {
            get { return m_voltageOption_CurrentMeasure; }
            set { m_voltageOption_CurrentMeasure = value; }
        }

        public int voltageOption_MultiRack
        {
            get { return m_voltageOption_MultiRack; }
            set { m_voltageOption_MultiRack = value; }
        }
    }
}
