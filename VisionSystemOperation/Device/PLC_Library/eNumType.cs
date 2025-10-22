using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionSystemOperation.Device.PLC_Library
{
    public enum eSeqStep
    {
        SEQ_STOP,
        SEQ_START,
        SEQ_START_WAIT,
        SEQ_INIT,
        SEQ_READ_CAR_ID,
        SEQ_READ_CAR_TYPE,
        SEQ_GRAB,
        SEQ_START_INSP,
        SEQ_END_INSP,
        SEQ_SEND_RESULT,
        SEQ_SAVE_IMAGE,
        SEQ_DELETE_DATA,
        SEQ_END,
        SEQ_ERROR,
    }
    public enum eVision2PLCSeq
    {
        READY_ON,
        AUTO_START,
        BT_MATCH_OK,
        BT_UNMATCH,
        MASK_COMPL, // No use
        VISION_START,
        VISION_END,
        VISION_NG,
        LAST_COMPL,
        MASK_PASS, // No use
        VISION_PASS,
        COM_CHK_FLICKER,
        ERROR,
        AIR_ERROR, // No use
        PC_COMM_ERROR,
        EM_STOP,
        SEQ_COUNT
    }
    public enum ePLC2VisionSeq
    {
        READY_ON,
        AUTO_START,
        VISION_START,
        VISION_OK,
        RBT_VISION_2ND_POS,
        RBT_HOME_POS,
        SHTL_HOME_POS,
        WORK_COMPL_RST,
        STN_WORK_COMPL,
        EMPTY,
        EMPTY1,
        COMM_CHK_FLICKER,
        ERROR,
        EMPTY2,
        EMPTY3,
        EM_STOP,
        SEQ_COUNT
    }

    public enum eReadSignalType
    {
        ALLIVE,
        CAR_ID,
        CAR_TYPE,
        SEQ
    }

    public enum eInspResult
    {
        OK,
        NG,
        ERROR,
    }
}
