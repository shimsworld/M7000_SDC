using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G4xHMI
{



    public class Class_GTITransfer
    {
        public enum _STATE
        {
            LOOP_IDLE,
            SENT_GNTI_STARTED,
            WAIT_READY,
            SENT_FLASH_ERASE,
            WAIT_DATA_READY,
            SENT_SEND_START,
            LOOP_DATA_SEND,
            SENT_DATA_CRC,
            WAIT_DATA_CRC,
            WAIT_INTERNAL_CODE_MAKE,
            LOOP_DATA_CRC_CHECKED,
            LOOP_DATA_CRC_OK,
            LOOP_DATA_CRC_ERR,
            LOOP_INTERNAL_CODE_DONE,
            LOOP_STATUS,
            LOOP_ETC_ERROR_REPORT,
            LOOP_ERROR_NOT_SUPPORT,
        }

        public enum _TIMEOUT
        {
            READY = 10,
            DATA = 5,
            WIAT_CRC = 15,  // DUMP TIME..
            WAIT_MAKE_CODE = 20,
        }


        public int FileIndex;
        public int State;
        public int OldFileIndex;
        public int OldState;
        public int TimeOut;

        public DateTime NotiTime;

        // Construct
        public Class_GTITransfer()
        {
            InitValue();
        }

        public void InitValue()
        {
            FileIndex = 0;
            OldFileIndex = -1;
            State = -1;
            OldState = -1;
            TimeOut = (int)Class_GTITransfer._STATE.WAIT_READY;

            NotiTime = DateTime.Now;
        }

        // ToDo: 크리티컬 섹션 동기화.
        // Interface
        public void ExpireNotiTime()
        {
            NotiTime = DateTime.Now;
        }

        public void IndexReset()
        {
            FileIndex = 0;
            OldFileIndex = -1;
        }

        public int IncIndex()
        {
            ++FileIndex;

            return FileIndex;
        }

        public void SetState(int curState)
        {
            State = curState;
        }

        public int GetState()
        {
            return State;
        }

    }
}

