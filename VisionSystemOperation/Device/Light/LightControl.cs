using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VisionSystemOperation.Device.Light
{
    public class LightControl
    {
        private TcpClient client;
        private NetworkStream stream = null;

        public string str_ip;
        public int iport;

        public LightControl()
        {
            str_ip = "192.168.0.200";
            iport = 9000;
        }

        public bool isConnected()
        {
            if (client == null)
                return false;

            return client.Connected;
        }

        // 서버에 연결하는 메서드
        public bool Connect(string ipAddress, int port)
        {
            try
            {
                if(stream != null)
                {
                    if(stream.CanRead)
                    {
                        stream.Dispose();
                    }
                }
                // TcpClient 객체 생성 및 서버에 연결 시도
                client = new TcpClient(ipAddress, port);
                stream = client.GetStream();
                Console.WriteLine("Connected to server.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed: " + ex.Message);
                return false;
            }
        }

        public void SetPrimeryData()
        {
            Machine.lightmodule.SetChannelDimmingGroup(5, Machine.config.setup.lightProperty.Channel5);
            Machine.lightmodule.SetChannelDimmingGroup(6, Machine.config.setup.lightProperty.Channel6);
            Machine.lightmodule.SetChannelDimmingGroup(7, Machine.config.setup.lightProperty.Channel7);
            Machine.lightmodule.SetChannelDimmingGroup(8, Machine.config.setup.lightProperty.Channel8);
            Machine.lightmodule.SetChannelDimmingGroup(1, Machine.config.setup.lightProperty.Channel1);
            Machine.lightmodule.SetChannelDimmingGroup(2, Machine.config.setup.lightProperty.Channel2);
            Machine.lightmodule.SetChannelDimmingGroup(3, Machine.config.setup.lightProperty.Channel3);
            Machine.lightmodule.SetChannelDimmingGroup(4, Machine.config.setup.lightProperty.Channel4);
            Machine.lightmodule.SetChannelDimmingGroup(9, Machine.config.setup.lightProperty.Channel9);
            Machine.lightmodule.SetChannelDimmingGroup(10, Machine.config.setup.lightProperty.Channel10);
        }

        // 데이터를 전송하는 메서드
        public bool SendData(string data)
        {
            if (stream != null && stream.CanWrite)
            {
                // 문자열을 ASCII 인코딩으로 바이트 배열로 변환
                byte[] buffer = Encoding.ASCII.GetBytes(data);

                // 데이터 전송
                stream.Write(buffer, 0, buffer.Length);
                return true;
            }
            else
            {
                Console.WriteLine("Cannot send data. Stream is not writable.");
                return false;
            }
        }

        // 데이터를 비동기로 전송하는 메서드
        public bool SendDataAsync(string data)
        {
            if (stream != null && stream.CanWrite)
            {
                // 문자열을 UTF-8 인코딩으로 바이트 배열로 변환
                byte[] buffer = Encoding.ASCII.GetBytes(data);

                // 데이터 비동기 전송
                stream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("Data sent: " + data);
                return true;
            }
            else
            {
                Console.WriteLine("Cannot send data. Stream is not writable.");
                return false;
            }
        }

        // 데이터를 비동기로 수신하는 메서드
        public async Task<string> ReceiveDataAsync()
        {
            if (stream != null && stream.CanRead)
            {
                byte[] buffer = new byte[256]; // 수신 버퍼 크기
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                // 수신된 데이터를 문자열로 변환
                string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Data received: " + receivedData);
                return receivedData;
            }
            else
            {
                Console.WriteLine("Cannot receive data. Stream is not readable.");
                return null;
            }
        }

        // 특정 채널의 Dimming 값을 읽어오는 메서드
        public async Task<int> ReadChannelDimmingAsync(int channel)
        {
            if (stream != null && stream.CanWrite && stream.CanRead)
            {
                // 명령어 생성 (특정 채널 Dimming 값 읽기)
                string command = $"*R01$";
                byte[] buffer = Encoding.ASCII.GetBytes(command);

                // 데이터 비동기 전송
                await stream.WriteAsync(buffer, 0, buffer.Length);
                Console.WriteLine("Command sent: " + command);

                // 응답 수신
                byte[] responseBuffer = new byte[256];
                int bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                string response = Encoding.ASCII.GetString(responseBuffer, 0, bytesRead);
                Console.WriteLine("Response received: " + response);

                // 응답에서 Dimming 값 추출 (예: *1000,0200,0150,2020$)
                if (response.StartsWith("*") && response.EndsWith("$"))
                {
                    string[] dimmingValues = response.TrimStart('*').TrimEnd('$').Split(',');
                    if (dimmingValues.Length > channel && int.TryParse(dimmingValues[channel], out int dimmingValue))
                    {
                        return dimmingValue;
                    }
                }
            }
            else
            {
                Console.WriteLine("Cannot read data. Stream is not readable or writable.");
            }
            return -1; // 오류 발생 시 -1 반환
        }

        // 특정 채널의 Dimming 값을 설정하는 메서드
        public bool SetChannelDimmingAsync(int channel, int dimmingValue)
        {
            if (stream != null && stream.CanWrite)
            {
                // 명령어 생성 (특정 채널 Dimming 값 설정)
                string command = $"*W{channel:D2}{dimmingValue:D4}$";
                byte[] buffer = Encoding.ASCII.GetBytes(command);

                // 데이터 비동기 전송
                stream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("Command sent: " + command);
                ReceiveData();
                return true;
            }
            else
            {
                Console.WriteLine("Cannot send data. Stream is not writable.");
                return false;
            }
        }

        //public async Task IncreaseChannelDimmingAsync(int channel)
        //{
        //    // 현재 Dimming 값 읽어오기
        //    int currentDimming = await ReadChannelDimmingAsync(channel);
        //    if (currentDimming == -1)
        //    {
        //        Console.WriteLine("Failed to read current dimming value.");
        //        return;
        //    }

        //    Console.WriteLine($"현재 {channel} ch 값 : {currentDimming}");

        //    int newDimming = currentDimming + 200;
        //    if (newDimming > 4000)
        //    {
        //        newDimming = 4000;
        //    }

        //    // 새로운 Dimming 값 설정
        //    await SetChannelDimmingAsync(channel, newDimming);
        //    Console.WriteLine($"Channel {channel} dimming value increased from {currentDimming} to {newDimming}.");
        //}

        //public async Task DecreaseChannelDimmingAsync(int channel)
        //{
        //    // 현재 Dimming 값 읽어오기
        //    int currentDimming = await ReadChannelDimmingAsync(channel);
        //    if (currentDimming == -1)
        //    {
        //        Console.WriteLine("Failed to read current dimming value.");
        //        return;
        //    }

        //    Console.WriteLine($"현재 {channel} ch 값 : {currentDimming}");

        //    int newDimming = currentDimming - 200;
        //    if (newDimming < 0)
        //    {
        //        newDimming = 0;
        //    }

        //    // 새로운 Dimming 값 설정
        //    await SetChannelDimmingAsync(channel, newDimming);
        //    Console.WriteLine($"Channel {channel} dimming value decreased from {currentDimming} to {newDimming}.");
        //}

        // 특정 채널의 Dimming 값을 설정하는 메서드
        public string ReceiveData()
        {
            if (stream != null && stream.CanRead)
            {
                byte[] buffer = new byte[256]; // 수신 버퍼 크기

                stream.ReadTimeout = 3000;//ms
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                // 수신된 데이터를 문자열로 변환
                string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Data received: " + receivedData);
                return receivedData;
            }
            else
            {
                Console.WriteLine("Cannot receive data. Stream is not readable.");
                return null;
            }
        }

        // 특정 채널의 Dimming 값을 설정하는 메서드
        public bool SetChannelDimming(int channel, int dimmingValue)
        {
            if (stream != null && stream.CanWrite)
            {
                // 명령어 생성 (특정 채널 Dimming 값 설정)
                string command = $"*W{channel:D2}{dimmingValue:D4}$";
                byte[] buffer = Encoding.ASCII.GetBytes(command);

                // 데이터 비동기 전송
                stream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("Command sent: " + command);
                ReceiveData();
                return true;
            }
            else
            {
                Console.WriteLine("Cannot send data. Stream is not writable.");
                return false;
            }
        }

        // light command by changel and onoff
        public string LightCommand(int channel, int onOff)
        {
            onOff = onOff == 0 || onOff == 1 ? onOff : 0;
            string chs = channel == 10 ? channel.ToString() : "0" + channel.ToString();
            return "*O" + chs + onOff + "$";
        }

        public void SetChannelDimmingGroup(int channel, int dimmingValue)
        {
            int sleepTime = 120;
            while (SetChannelDimming(channel, dimmingValue))
            {
                System.Threading.Thread.Sleep(sleepTime);
                break;
            }
        }


        public void LightOnOffByChannel(int channel, int onOff)
        {
            int sleepTime = 120;
            string command = LightCommand(channel, onOff);
            if (onOff == 1)
            {
                while (SendData(command))
                {
                    System.Threading.Thread.Sleep(sleepTime);
                    break;
                }
            }

            while (SendData(command))
            {
                System.Threading.Thread.Sleep(sleepTime);
                break;
            }
        }
    }
}
