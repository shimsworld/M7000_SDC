using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G4xHMI
{
    public class CONST
    {
        public class ETHERNET
        {
            public class BUFFER_SIZE
            {
                public const int SIZE_1024 = 1024;
                public const int SIZE_4096 = 4096;
                public const int SIZE_8192 = 8192;
                public const int SIZE_MAX = SIZE_8192;
            }

            // 패킷 에러 상수
            public class PACKET_ERROR
            {
                public const int UNKNOWN = 0;
                public const int HEADER = -1;
                public const int TAILER = -2;
                public const int CRC = -3;
                public const int NONE = -4;
            }

            // PC 원격
            public class PC
            {
                public const byte HEADER = 0xAA;
                public const byte TAILER = 0xCC;
            }

            public enum POWER_STATUS
            {
                MRACK_POWER_STATE_ON,
                MRACK_POWER_STATE_OFF,
                MRACK_POWER_STATE_LCD_ON,
                MRACK_POWER_STATE_LCD_OFF,

                MRACK_POWER_STATE_NONE = 99,
            }
     
        }

        public class DEVICE
        {
            public const int PAGE_MAX = 30;
        }
    }
}
