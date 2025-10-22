using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionSystemOperation.Device.PLC_Library
{

    public enum ePLC_CMDType
    {
        READ_REQ = 54,
        READ_RES = 55,
        WRITE_REQ = 58,
        WRITE_RES = 59
    }

    public enum eDataType
    {
        BIT = 0,
        BYTE,
        WORD,
        DWORD,
        LWORD
    }

    public enum eXGT_SERVER_ERR
    {
        XGT_ENET_DATA_TYPE_ERROR = 24, //// 데이터 타입 에러
        XGT_ENET_HEADER_ERROR = 75, //“LGIS-GLOFA”가 아니거나 “LSIS-XGT”가 아닌 경우 
        XGT_ENET_HEADER_LENGTH_ERROR = 76,// length 정보 오류 
        XGT_ENET_HEADER_CHECKSUM_ERROR = 77,// 체크섬 오류 
        XGT_ENET_HEADER_COMMAND_ERROR = 78,// unknown command
        XGT_ENET_DEVICE_TYPE_ERROR = 10,//없는 디바이스를 요청하는 경우와 같이 디바이스에 관련된 에러 
        XGT_ENET_ADDRESS_FORMAT_ERROR = 11,//변수명이 4보다 작거나 16보다 큰 경우와 같이 어드레스에 관련된 에러
        XGT_ENET_DATA_ERROR = 12,//연속읽기인데 바이트 타입이 아닌 경우
        XGT_ENET_SEVER_ERROR = 1000
    }

    public struct sPacketData
    {
        public string Data;
        public int Byte;

        public sPacketData(string data, int Byte)
        {
            this.Data = data;
            this.Byte = Byte;
        }

        public sPacketData CopyTo()
        {
            sPacketData newData = new sPacketData(this.Data, this.Byte);

            return newData;
        }
    }

    //// LS_PLC Header TotalByte 40
    public class PLCHeader
    {
        private const int BASE_BYTE = 2;// 1 Word / 2 Byte

        public sPacketData CompanyID { get; set; } = new sPacketData("LSIS-XGT", 8); //8Byte
        private sPacketData Reserved { get; set; } = new sPacketData("0000", 2); //dont care
        private sPacketData PlcInfo { get; set; } = new sPacketData("0000", 2); //2Byte  dont care 
        private sPacketData Cpuinfo { get; set; } = new sPacketData("00", 1); //1Byte  Client -> PLC: dont care, PLC->Client: XGK(0xA0), XGI(0xA4), XGR(0xA8)
        private sPacketData SrcFrame { get; set; } = new sPacketData("33", 1); //1Byte  Client -> PLC : 0x33,  PLC -> Client : 0x11 
        private sPacketData InvokeID { get; set; } = new sPacketData("0000", 2); //2Byte
        private sPacketData AppLength { get; set; } = new sPacketData("0000", 2);//2Byte Application Instruction Data Length
        private sPacketData FNetPostion { get; set; } = new sPacketData("00", 1);//1Byte, Client -> PLC: dont care
        private sPacketData ReservedBCC { get; set; } = new sPacketData("00", 1);//1Byte, Byte Sum of Application Header 

        public string GetHeder(int appDataLength)
        {
            string header = "";

            /////CompanyID Convert String2Hex
            string strComIDToHex = "";
            byte[] cIDAsciiArr = ASCIIEncoding.ASCII.GetBytes(CompanyID.Data);
            for (int i = 0; i < cIDAsciiArr.Length; i++)
            {
                string hex = Convert.ToString(cIDAsciiArr[i], 16).ToUpper();
                strComIDToHex += hex;
            }

            int dataLength = appDataLength / BASE_BYTE;
            AppLength = new sPacketData(dataLength.ToString("X2") + "00", 2);
            int j = 0;

            //////DEC -> HEX
            header = strComIDToHex + Convert.ToInt32(Reserved.Data, 16).ToString("X" + Reserved.Data.Length.ToString())
                            + Convert.ToInt32(PlcInfo.Data, 16).ToString("X" + PlcInfo.Data.Length.ToString())
                            + Convert.ToInt32(Cpuinfo.Data, 16).ToString("X" + Cpuinfo.Data.Length.ToString())
                            + Convert.ToInt32(SrcFrame.Data, 16).ToString("X" + SrcFrame.Data.Length.ToString())
                            + Convert.ToInt32(InvokeID.Data, 16).ToString("X" + InvokeID.Data.Length.ToString())
                            + Convert.ToInt32(AppLength.Data, 16).ToString("X" + AppLength.Data.Length.ToString())
                            + Convert.ToInt32(FNetPostion.Data, 16).ToString("X" + FNetPostion.Data.Length.ToString())
                            + Convert.ToInt32(ReservedBCC.Data, 16).ToString("X" + ReservedBCC.Data.Length.ToString());

            return header;
        }
        public PLCHeader CopyTo()
        {
            PLCHeader newData = new PLCHeader();

            newData.CompanyID = this.CompanyID.CopyTo();
            newData.Reserved = this.Reserved.CopyTo();
            newData.PlcInfo = this.PlcInfo.CopyTo();
            newData.Cpuinfo = this.Cpuinfo.CopyTo();
            newData.SrcFrame = this.SrcFrame.CopyTo();
            newData.InvokeID = this.InvokeID.CopyTo();
            newData.FNetPostion = this.FNetPostion.CopyTo();
            newData.ReservedBCC = this.ReservedBCC.CopyTo();

            newData.AppLength = this.AppLength;

            return newData;
        }
        public int GetHeaderByteSize()
        {
            return CompanyID.Byte + Reserved.Byte + PlcInfo.Byte + Cpuinfo.Byte + SrcFrame.Byte + InvokeID.Byte + AppLength.Byte + FNetPostion.Byte + ReservedBCC.Byte;
        }
    }

    public class PLCAppInstData ///Application Instruction Data
    {
        private ePLC_CMDType CMDType { get; set; } = new ePLC_CMDType();
        private sPacketData RWReqResDataH { get; set; } = new sPacketData("5400", 2); //2Byte   ReadReq = 54, ReadRes = 55, WriteReq = 58, WriteRes = 59
        public sPacketData DataTypeH { get; set; } = new sPacketData("0000", 2);  //2Byte   BIT=Hx00, BYTE=Hx01, WORD=Hx02, DWORD=Hx03, LWORD=Hx04
        private sPacketData DataReservedH { get; set; } = new sPacketData("0000", 2); //2Byte, dont care
        public sPacketData BlockCntH { get; set; } = new sPacketData("0100", 2); //2Byte     1Block = ValueCnt, ValueName
        public sPacketData ValueNameH { get; set; } = new sPacketData("%MW100", 2); //2Byte     M = AreaType, P/M/D  2. W = DataType, X=Bit/B=Byte,W=Word,D=DWord,L=LWord    3.100 = Address
        public sPacketData WriteLength { get; set; } = new sPacketData("", 2); // 2Byte
        public sPacketData WriteData { get; set; } = new sPacketData("", sizeof(bool));

        public string ValueNameCntH
        {
            get { return ValueNameH.Data.Length.ToString("D2") + "00"; }
        }

        public PLCAppInstData(ePLC_CMDType cmdType)
        {
            this.CMDType = cmdType;

            switch (cmdType)
            {
                case ePLC_CMDType.READ_REQ:
                    this.RWReqResDataH = new sPacketData(((int)ePLC_CMDType.READ_REQ).ToString("D2") + "00", 2);
                    break;
                case ePLC_CMDType.READ_RES:
                    this.RWReqResDataH = new sPacketData(((int)ePLC_CMDType.READ_RES).ToString("D2") + "00", 2);
                    break;
                case ePLC_CMDType.WRITE_REQ:
                    this.RWReqResDataH = new sPacketData(((int)ePLC_CMDType.WRITE_REQ).ToString("D2") + "00", 2);
                    break;
                case ePLC_CMDType.WRITE_RES:
                    this.RWReqResDataH = new sPacketData(((int)ePLC_CMDType.WRITE_RES).ToString("D2") + "00", 2);
                    break;
                default:
                    break;
            }
        }

        public PLCAppInstData CopyTo()
        {
            PLCAppInstData newData = new PLCAppInstData(this.CMDType);

            newData.RWReqResDataH = this.RWReqResDataH.CopyTo();
            newData.DataTypeH = this.DataTypeH.CopyTo();
            newData.DataReservedH = this.DataReservedH.CopyTo();
            newData.BlockCntH = this.BlockCntH.CopyTo();
            newData.ValueNameH = this.ValueNameH.CopyTo();
            newData.WriteLength = this.WriteLength.CopyTo();
            newData.WriteData = this.WriteData.CopyTo();

            return newData;
        }

        public string GetDataByHex()
        {
            string appDataMsg = "";

            byte[] valNameAsciiArr = ASCIIEncoding.ASCII.GetBytes(ValueNameH.Data);
            string strValNameToHex = "";
            for (int i = 0; i < valNameAsciiArr.Length; i++)
            {
                string hex = Convert.ToString(valNameAsciiArr[i], 16).ToUpper();
                strValNameToHex += hex;
            }
             
            appDataMsg = Convert.ToInt32(RWReqResDataH.Data, 16).ToString("x" + RWReqResDataH.Data.Length.ToString())
                            + Convert.ToInt32(DataTypeH.Data, 16).ToString("x" + DataTypeH.Data.Length.ToString())
                            + Convert.ToInt32(DataReservedH.Data, 16).ToString("x" + DataReservedH.Data.Length.ToString())
                            + Convert.ToInt32(BlockCntH.Data, 16).ToString("x" + BlockCntH.Data.Length.ToString())
                            + Convert.ToInt32(ValueNameCntH, 16).ToString("x" + ValueNameCntH.Length.ToString())
                            + strValNameToHex;
            if(CMDType == ePLC_CMDType.WRITE_REQ)
            {
                appDataMsg += (WriteLength.Data + WriteData.Data);
            }

            return appDataMsg;
        }
    }

    public class ReadRequestData ///////Packet -> Header Inform + Application Instruction
    {
        public PLCHeader Header { get; set; } = new PLCHeader();
        public PLCAppInstData AppInstData { get; set; } = new PLCAppInstData(ePLC_CMDType.READ_REQ);
        private eDataType DataType { get; set; } = new eDataType();

        public ReadRequestData(string CompanyID, string addressName, string blockCnt, eDataType dataType)
        {
            DataType = dataType;
            Header.CompanyID = new sPacketData(CompanyID, 8);

            AppInstData.DataTypeH = new sPacketData(DataType2HexString(dataType), 2);

            string bcCount = blockCnt.Length.ToString("D2") + "00";
            AppInstData.BlockCntH = new sPacketData(bcCount, 2);

            AppInstData.ValueNameH = new sPacketData(addressName, 2);

        }

        private string DataType2HexString(eDataType dataType)
        {
            string dataHexType = "";

            switch (dataType)
            {
                case eDataType.BIT:
                    dataHexType = ((int)eDataType.BIT).ToString("D2") + "00";
                    break;
                case eDataType.BYTE:
                    dataHexType = ((int)eDataType.BYTE).ToString("D2") + "00";
                    break;
                case eDataType.WORD:
                    dataHexType = ((int)eDataType.WORD).ToString("D2") + "00";
                    break;
                case eDataType.DWORD:
                    dataHexType = ((int)eDataType.DWORD).ToString("D2") + "00";
                    break;
                case eDataType.LWORD:
                    dataHexType = ((int)eDataType.LWORD).ToString("D2") + "00";
                    break;
            }

            return dataHexType;
        }

        public string GetReqData()
        {
            string sendMsg = "";

            string appHexData = AppInstData.GetDataByHex();
            string headerMsg = Header.GetHeder(appHexData.Length);

            sendMsg = headerMsg + appHexData;

            return sendMsg;
        }
    }
    public class ReadRespondData
    {
        public int ErrorNum { get; set; } = 0;

        public int GetValueData(string resData, int splitStartIdx)
        {
            int result = -1;

            string recvAppData = resData.Substring(splitStartIdx, resData.Length - splitStartIdx);

            int subIdx = 0;
            string readRes = recvAppData.Substring(subIdx, 4); ///2Byte   ReadRes = 55, WriteRes = 59

            subIdx += 4;
            string resDataType = recvAppData.Substring(subIdx, 4);
            int dataTypeIdx = Convert.ToInt32(resDataType.Substring(0, 2)); // 0=Bit, 1=Byte, 2=Word, 3=Dword, 4=Lword

            subIdx += 8;//reserved Data pass
            string errorType = recvAppData.Substring(subIdx, 4);
            if(errorType.Contains("F"))
            {
                subIdx += 4;//reserved Data pass
                ErrorNum = Convert.ToInt32(recvAppData.Substring(subIdx, 2));
            }
            else
            {
                subIdx += 4;
                int readResBlockCnt = Convert.ToInt32(recvAppData.Substring(subIdx, 4).Substring(0, 2));

                subIdx += 4;
                int byteCount = Convert.ToInt32(recvAppData.Substring(subIdx, 4).Substring(0, 2)); //there is byteCount of HexData in data, ex) byteCount = 2, Word DataType

                subIdx += 4;
                string hexData = Convert.ToInt32(recvAppData.Substring(subIdx, byteCount * 2)).ToString(); //there is byteCount of HexData in data, ex) byteCount = 2, Word DataType

                int j = 0;
                int value = int.Parse(hexData, System.Globalization.NumberStyles.HexNumber);
                result = value;
            }

            return result;
        }
    }

    public class WriteRequestData
    {
        public PLCHeader Header { get; set; } = new PLCHeader();
        public PLCAppInstData AppInstData { get; set; } = new PLCAppInstData(ePLC_CMDType.WRITE_REQ);
        private eDataType DataType { get; set; } = new eDataType();

        public WriteRequestData(string CompanyID, string addressName, string blockCnt, eDataType dataType)
        {
            DataType = dataType;

            Header.CompanyID = new sPacketData(CompanyID, 8);

            AppInstData.DataTypeH = new sPacketData(DataType2HexString(dataType), 2);

            string bcCount = blockCnt.Length.ToString("D2") + "00";
            AppInstData.BlockCntH = new sPacketData(bcCount, 2);

            AppInstData.ValueNameH = new sPacketData(addressName, 2);
        }

        private string DataType2HexString(eDataType dataType)
        {
            string dataHexType = "";

            switch (dataType)
            {
                case eDataType.BIT:
                    dataHexType = ((int)eDataType.BIT).ToString("D2") + "00";
                    break;
                case eDataType.BYTE:
                    dataHexType = ((int)eDataType.BYTE).ToString("D2") + "00";
                    break;
                case eDataType.WORD:
                    dataHexType = ((int)eDataType.WORD).ToString("D2") + "00";
                    break;
                case eDataType.DWORD:
                    dataHexType = ((int)eDataType.DWORD).ToString("D2") + "00";
                    break;
                case eDataType.LWORD:
                    dataHexType = ((int)eDataType.LWORD).ToString("D2") + "00";
                    break;
            }

            return dataHexType;
        }

        private short BitData2Word(bool[] bitData) //1Word == 2Byte
        {
            short wordData = 0;

            int typeSize = (sizeof(short) * 8);
            if (bitData.Length > (sizeof(short) * 8)) return wordData;

            int bitSize = typeSize;
            // This assumes the array never contains more than 8 elements!
            int index = bitSize - bitData.Length;
            // Loop through the array
            foreach (bool b in bitData)
            {
                // if the element is 'true' set the bit at that position
                if (b)
                    wordData |= (short)(1 << ((bitSize - 1) - index));

                index++;
            }

            return wordData;
        }

        private byte BitData2Byte(bool[] bitData) //1Byte == 8Bit
        {
            byte byteData = 0;

            int typeSize = (sizeof(byte) * 8);
            if (bitData.Length > typeSize) return byteData;

            int bitSize = typeSize;
            // This assumes the array never contains more than 8 elements!
            int index = bitSize - bitData.Length;
            // Loop through the array
            foreach (bool b in bitData)
            {
                // if the element is 'true' set the bit at that position
                if (b)
                    byteData |= (byte)(1 << ((bitSize - 1) - index));

                index++;
            }

            return byteData;
        }

        private int BitData2DWord(bool[] bitData) //DWord == 4Byte
        {
            Int32 dWordData = 0;

            //string sBin = "";
            //foreach (bool item in bitData)
            //{
            //    sBin += (item == true ? "1" : "0");
            //}
            //dWordData = Convert.ToInt32(sBin, 2);


            int typeSize = (sizeof(Int32) * 8);
            if (bitData.Length > typeSize) return dWordData;

            int bitSize = typeSize;
            // This assumes the array never contains more than 8 elements!
            int index = bitSize - bitData.Length;
            // Loop through the array
            foreach (bool b in bitData)
            {
                // if the element is 'true' set the bit at that position
                if (b)
                    dWordData |= (Int32)(1 << ((bitSize - 1) - index));

                index++;
            }

            return dWordData;
        }
        private long BitData2LWord(bool[] bitData) //LWord == 8Byte
        {
            long lWordData = 0;

            string sBin = "";
            foreach (bool item in bitData)
            {
                sBin += (item == true ? "1" : "0");
            }
            lWordData = Convert.ToInt64(sBin, 2);

            //int typeSize = (sizeof(Int64) * 8);
            //if (bitData.Length > typeSize) return lWordData;

            //int bitSize = typeSize;
            //// This assumes the array never contains more than 8 elements!
            //int index = bitSize - bitData.Length;
            //// Loop through the array
            //foreach (bool b in bitData)
            //{
            //    // if the element is 'true' set the bit at that position
            //    if (b)
            //        lWordData |= (Int64)(1 << ((bitSize - 1) - index));

            //    index++;
            //}

            return lWordData;
        }

        private sPacketData GetWriteHexDataPacket(bool[] writeBitData)
        {
            sPacketData writeDataPacket = new sPacketData();

            switch (DataType)
            {
                case eDataType.BIT:
                    string hex = (writeBitData[0] == true ? "01" : "00");

                    writeDataPacket.Data = hex;
                    writeDataPacket.Byte = sizeof(bool); //1bit
                    break;
                case eDataType.BYTE:
                    byte bData = BitData2Byte(writeBitData);
                    hex = bData.ToString("X" + sizeof(byte));

                    writeDataPacket.Data = hex;
                    writeDataPacket.Byte = sizeof(byte);
                    break;
                case eDataType.WORD:
                    short sData = BitData2Word(writeBitData);
                    hex = sData.ToString("X" + sizeof(short));

                    writeDataPacket.Data = hex;
                    writeDataPacket.Byte = sizeof(short);
                    break;
                case eDataType.DWORD:
                    int uiData = BitData2DWord(writeBitData);
                    hex = uiData.ToString("X" + sizeof(uint));

                    writeDataPacket.Data = hex;
                    writeDataPacket.Byte = sizeof(uint);
                    break;
                case eDataType.LWORD:
                    long lData = BitData2LWord(writeBitData);
                    hex = lData.ToString("X" + sizeof(long));

                    writeDataPacket.Data = hex;
                    writeDataPacket.Byte = sizeof(ulong);
                    break;
                default:
                    break;
            }

            return writeDataPacket;
        }

        public string GetReqData(bool[] writeBitData)
        {
            string sendMsg = "";

            AppInstData.WriteData = GetWriteHexDataPacket(writeBitData);

            if(DataType == eDataType.BIT)
            {
                AppInstData.WriteLength = new sPacketData("0001", 2);
            }
            else
            {
                AppInstData.WriteLength = new sPacketData((AppInstData.WriteData.Byte).ToString("D2") + "00", 2);
            }

             string appHexData = AppInstData.GetDataByHex();
            string headerMsg = Header.GetHeder(appHexData.Length);

            sendMsg = headerMsg + appHexData;

            return sendMsg;
        }
    }
    public class WriteRespondData
    {
        public int ErrorNum { get; set; } = 0;

        public void CheckValueData(string resData, int splitStartIdx)
        {
            string recvAppData = resData.Substring(splitStartIdx, resData.Length - splitStartIdx);

            int subIdx = 0;
            string readRes = recvAppData.Substring(subIdx, 4); //////2Byte   ReadRes = 55, WriteRes = 59

            subIdx += 4;
            string resDataType = recvAppData.Substring(subIdx, 4);
            int dataTypeIdx = Convert.ToInt32(resDataType.Substring(0, 2)); // 0=Bit, 1=Byte, 2=Word, 3=Dword, 4=Lword

            subIdx += 8;//reserved Data pass
            string errorType = recvAppData.Substring(subIdx, 4);
            if (errorType.Contains("F"))
            {
                subIdx += 4;//reserved Data pass
                ErrorNum = Convert.ToInt32(recvAppData.Substring(subIdx, 2));
            }
            else
            {
                subIdx += 4;
                int readResBlockCnt = Convert.ToInt32(recvAppData.Substring(subIdx, 4).Substring(0, 2));
            }
        }
    }

}
