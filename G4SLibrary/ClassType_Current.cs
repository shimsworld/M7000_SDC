using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G4xHMI
{
    public class ClassType_Current
    {
        public enum UNIT_TYPE
        {
            TYPE_NONE,
            TYPE_uA,
            TYPE_mA,
        }

        Int32 _data;

        Int32 _fraction;

        public ClassType_Current()
        {
            data = 0;
            fraction = 1;
        }

        public void resetData()
        {
            data = 0;
            fraction = 1;
        }

        public Int32 data
        {
            set { _data = value; }
            get { return _data; }
        }

        public Int32 fraction
        {
            set { _fraction = value; }
            get { return _fraction; }
        }

        public void setData(Int32 value, Int32 frac)
        {
            data = value;
            fraction = frac;
        }

        public Double getCurrent(UNIT_TYPE type)
        {
            Double res = 0;

            switch (type)
            {
                case UNIT_TYPE.TYPE_mA:
                    res = (Double)this.data / this.fraction / 1000;
                    break;
                case UNIT_TYPE.TYPE_uA:
                    res = (Double)this.data / this.fraction;
                    break;
                case UNIT_TYPE.TYPE_NONE:
                    res = (Double)this.data;
                    break;
            }

            return res;
        }

        public int getMilliData()
        {
            int res = 0;

            if (this.data <= 0) return 0;

            res = (int) ((Double)this.data / this.fraction / 1000);

            return res;
        }

        public int getData()
        {
            return this.data;
        }

        public Double getOptimalCurrent()
        {
            if(this.data/this.fraction >= 1000) return ((Double)this.data / this.fraction / 1000);
            else return ((Double)this.data / this.fraction);
        }

        public UNIT_TYPE getOptimalUnitType()
        {
            if (this.data / this.fraction >= 1000) return UNIT_TYPE.TYPE_mA;
            else return UNIT_TYPE.TYPE_uA;
        }

        public string getOptimalUnitString()
        {
            if (this.data/this.fraction >= 1000) return "mA";
            else return "uA";
        }
    }
}
