using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace VisionSystemOperation.Device
{
    public static class TowerLampManager
    {
        public static string ErrorMsg { get; set; } = "";
        private static void SendDatatoTowerLamp(byte[] data)
        {
            Socket clientSock = null;
            clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSock.Connect("192.168.0.100", 10000);

            byte[] recvBuffer = new byte[1400];
            if (clientSock.Connected)
            {
                ////Receive();
                //byte[] buffer = Encoding.ASCII.GetBytes(message);

                ////IAsyncResult r =  clientSock.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(SendCallBack), message);// 비동기 전송</span> 
                //SocketError errCode;
                //IAsyncResult r = clientSock.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, out errCode, new AsyncCallback(SendCallBack), message);// 비동기 전송</span> 

                clientSock.Send(data);

                clientSock.ReceiveTimeout = 2000;
                int recvSize = clientSock.Receive(recvBuffer);
                string frame = Encoding.Default.GetString((recvBuffer), 0, recvSize); //Encoding.Unicode.GetString(recvBuffer, 0, nReadSize);

                //frameBuffer = new byte[recvSize];

                //for (int k = 0; k < recvSize; k++)
                //{
                //    if (recvBuffer[k] == 0)
                //    {
                //        length = k;
                //        break;
                //    }
                //}


            }
            clientSock.Close();
        }
        private static byte BitData2Byte(bool[] bitData) //1Byte == 8Bit
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
        public static bool StartLampOn()
        {
            bool result = true;
            try
            {
                bool[] bRunnigData = { false, false, false, false, false, false, false, true }; // Green Turn on
                bool[] soundOff = { false, false, false, false, false, false, false, false };

                byte[] towerData = new byte[3];
                towerData[0] = 0x57;
                towerData[1] = BitData2Byte(bRunnigData);
                towerData[2] = BitData2Byte(soundOff);

                SendDatatoTowerLamp(towerData);
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
                result = false;
            }

            return result;
        }

        public static bool LampOff()
        {
            bool result = true;
            try
            {
                bool[] bStopData = { false, false, false, false, false, false, false, false }; // Turn off
                bool[] soundOff = { false, false, false, false, false, false, false, false };

                byte[] towerData = new byte[3];
                towerData[0] = 0x57;
                towerData[1] = BitData2Byte(bStopData);
                towerData[2] = BitData2Byte(soundOff);

                SendDatatoTowerLamp(towerData);

            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
                result = false;
            }

            return result;
        }

        public static bool ReadyLampOn()
        {
            bool result = true;
            try
            {
                //bool[] bWarnningData = new bool[sizeof(byte)];
                bool[] bWarnningData = { false, false, false, false, false, false, true, false }; // Orange Turn on
                bool[] soundOff = { false, false, false, false, false, false, false, false };

                byte[] towerData = new byte[3];
                towerData[0] = 0x57;
                towerData[1] = BitData2Byte(bWarnningData);
                towerData[2] = BitData2Byte(soundOff);

                SendDatatoTowerLamp(towerData);

            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
                result = false;
            }

            return result;

        }

        public static bool StopLampOn()
        {
            bool result = true;
            try
            {
                //bool[] bStopData = new bool[sizeof(byte)];
                bool[] bStopData = { false, false, false, false, false, true, false, false }; // Red Turn on
                bool[] soundOn = { false, false, false, false, false, true, false, false };

                byte[] towerData = new byte[3];
                towerData[0] = 0x57;
                towerData[1] = BitData2Byte(bStopData);
                towerData[2] = BitData2Byte(soundOn);

                SendDatatoTowerLamp(towerData);
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
                result = false;
            }

            return result;
        }
    }
}
