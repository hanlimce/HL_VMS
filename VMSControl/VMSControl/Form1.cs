using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Media;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace VMSControl
{
    public partial class Form1 : Form
    {
        /*
         * Define
         */
        public static int SPLUS_LENGTH = 21;
        public static int NOTIFICATION_LENGTH = 6;
        public static string g_configIniDirectory = @"C:\Hanlim\IniProfiles";
        public static string g_configIniPath = @"C:\Hanlim\IniProfiles\setup.ini";
        public static string g_logPath = @"C:\Hanlim\Log";
        public static string g_soundPath = @"C:\Hanlim\Sound";

        bool _loraConnection = false;       // 시리얼 통신 열기 유무
        bool _vmsConnection = false;        // vms 통신 연결 유무

        List<byte> _listLoraRBuff = new List<byte>();
        List<byte> mLoraDataBuff = new List<byte>();

        int _laraDataSize = 21; 



        TcpClient _tcpClient;
        //접속시 사용한 IP PORT
        int _vmsPort = 5000;
        IPAddress _ipAddress;// = "192.168.0.201";

        byte[] _vmsRBuff = new byte[512];
        
        bool _isDanger = false; // 위험 사항 표시

        private SoundPlayer _player = new SoundPlayer();

        int _type = 0;  // 0: 소통원활, 1: 지체, 2: 정체, 3: 사고
        int _oldType = -1;


        int _tickCnt = 0;           // 
        int _tickValue = 60;        //
                                    //
        int _serialReCon = 0;
        int _vmsReCon = 0;

        bool _isPlay = true;        // 기본은 소리 나옴이고, 체크 풀리면 소리 꺼짐


        int _velocity = 0;
        bool isfirstBoot = true;
        int pastEventCode = 0xFF;

        #region INI system dll
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        string[] portList;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
#if !DEBUG
            Height = 580;
#endif
            DirectoryInfo di = new DirectoryInfo(g_configIniDirectory);
            if (di.Exists == false)
            {
                di.Create();
            }
            IPAddress.TryParse(tbServerIP.Text, out _ipAddress);    // VMP  서버 IP 설정
            int.TryParse(tbServerPort.Text, out _vmsPort);          // VMS 서버 Port 설정

            portList = System.IO.Ports.SerialPort.GetPortNames();


            if (portList.Length > 0)
            {
                comboBoxCom1.Items.AddRange(portList);
                //제일 처음에 위치한 녀석을 선택
                comboBoxCom1.SelectedIndex = 0;
            }
            LoadIni();

            _tickValue = (int)numericUpDownTick.Value;   //초기값 가지고 오기

            timerTick.Start();

            isfirstBoot = true;
            connectionSerial(); // 로라 연결
            connetionServer();  // 전광판 연결
        }

        private void LoadIni()
        {
            StringBuilder tmp = new StringBuilder(5000);
            int result = GetPrivateProfileString("SETUP", "PORT", "", tmp, 5000, g_configIniPath);
            if (result == 0)
            {
                if (File.Exists(g_configIniPath) == false)
                {
                    File.Create(g_configIniPath);
                }
            }
            else
            {
                int index = 0;
                foreach(string port in portList)
                {
                    if (tmp.Equals(port))
                    {
                        comboBoxCom1.SelectedIndex = index;
                        break;
                    }
                    index++;
                }

            }
        }

        private void buttonOpenSerial_Click(object sender, EventArgs e)
        {
            connectionSerial();
        }

        private void connectionSerial()
        {
            try
            {
                if (_loraConnection)    // 연결 되어 있으면 닫기
                {
                    serialPortLora.Close();
                    _loraConnection = false;

                    WirteTextBox("로라 연결 닫기!!");
                    
                    return;
                }

                if (_loraConnection == false)    // 닫혀 있으면 다시 열기
                {
                    WirteTextBox("로라 연결 시도");

                    WritePrivateProfileString("SETUP", "PORT", comboBoxCom1.Text, g_configIniPath);
                    serialPortLora.PortName = comboBoxCom1.Text;
                    serialPortLora.Open();

                    WirteTextBox("로라 연결 성공!!");

                    _loraConnection = serialPortLora.IsOpen;
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                WirteTextBox(ex.Message);
            }
        }

        private void serialPortLora_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(LoraReceived));
        }

        private void LoraReceived(object s, EventArgs e)
        {
            int RecvSize = serialPortLora.BytesToRead;
            byte[] buff = new byte[RecvSize];

            if (RecvSize > 0)
            {
                WirteTextBox($"Serial Read{RecvSize}");
                serialPortLora.Read(buff, 0, RecvSize);

                LoraDataCotrol(buff);
            }
        }

        private void LoraDataCotrol(byte[] buff)
        {
            _listLoraRBuff.AddRange(buff);

            WirteTextBox(BitConverter.ToString(buff));


            ReadDataCut();

            //int iCnt = 0;
            //while (_listLoraRBuff.Count >= _laraDataSize)  // 길이 다르면 처리 하는 부분 필요
            //{
            //    ReadDataCut();
            //    if (iCnt++ > _laraDataSize)      // 길이 다름 다를때 로그 남겨야 함
            //    {

            //        byte[] strByte = _listLoraRBuff.ToArray();
            //        string str = string.Format("길이 오류!!! {0}: {1}", _listLoraRBuff.Count, System.Text.Encoding.UTF8.GetString(strByte));
            //        Console.WriteLine(str);

            //        WirteTextBox(str);
            //        _listLoraRBuff.Clear();
            //        break;
            //    }

            //}
        }


        private void ReadDataCut()
        {
#if false
            int index = 0;
            foreach (byte data in _listLoraRBuff)
            {
                //Console.WriteLine("{0}: {1}", index, data);

                if (data == 0x3C)
                {
                    if (_listLoraRBuff.Count >= index + _laraDataSize)
                    {
                        if (_listLoraRBuff[index + 5] == 0x3E)
                        {
                            // 데이터 처리 하는곳 !!!!!!!!!

                            Console.WriteLine("size2: " + _listLoraRBuff.Count);

                            byte[] readData = new byte[_laraDataSize];

                            for (int i = 0; i < _laraDataSize; i++)
                            {
                                readData[i] = _listLoraRBuff[index + i];
                            }

                            byte alram = readData[2];                       // E0, FF 만 받음

                            WriteTextBox(readData, true, false);

                            _listLoraRBuff.RemoveRange(0, index + _laraDataSize);      // 사용한 버퍼 비우기

                            //if (alram == 0xE0 && _isDanger == false)    // 위험 신호 중에는 속도값 사용하지 않음
                            if (alram == 0xE0)                            // 속도값 신호 받으면 속도값 사용
                            {
                                int velocity = readData[4];
                                _velocity = velocity;

                                //byte[] sendData = new byte[6];
                                //sendData[0] = 0x3C;
                                //sendData[1] = 0x00;
                                //sendData[2] = 0xF0;
                                //sendData[3] = 0x00;
                                //sendData[4] = readData[4];
                                //sendData[5] = 0x3E;

                                //string tmp = Encoding.Default.GetString(sendData);
                                Console.WriteLine("속도는 : {0}", velocity);

                                SendVms(velocity);
                            }
                            else if (alram > 0xF0 && alram <= 0xF5) // 게이트웨이에서 전송하지 않음
                            {
                                _isDanger = true;
                                Console.WriteLine("알람 위험 위험!! {0}", readData[2]);
                                SendVms(0xFF);
                            }
                            else if (alram == 0xFF)  // 미니로 부터 받는 위험 사항, 캐치카도 이걸로 줌
                            {
                                byte danger = readData[3];
                                if (danger == 0x01)
                                {
                                    _isDanger = true;
                                    Console.WriteLine("위험 알람 설정 {0}", readData[2]);
                                    _tickCnt = 0;
                                }
                                else
                                {
                                    _isDanger = false;
                                    Console.WriteLine("위험 알람 해제 {0}", readData[2]);
                                    _tickCnt = 0;
                                }

                                SendVms(_velocity);  // 사고 해제
                            }

                            //Console.WriteLine("size3: " + ReadBuff.Count);
                            break;
                        }
                    }
                    else
                    {
                        break;  // 길이가 짧으면 이번에는 없음
                    }
                }
                index++;
            }

#else
            int index = 0;
            bool isStart = false;
            bool isEnd = false;
            foreach (byte data in _listLoraRBuff)
            {
                if (data == 0x3C)
                {
                    isStart = true;
                    mLoraDataBuff.Clear();
                    mLoraDataBuff.Add(data);
                    index++;
                }
                else if (data == 0x3E && isStart)
                {
                    isStart = false;
                    isEnd = true;
                    mLoraDataBuff.Add(data);
                    index++;
                    _listLoraRBuff.RemoveRange(0, index);
                    if (mLoraDataBuff.Count == SPLUS_LENGTH)
                    {
                        int alert = mLoraDataBuff[6];

                        byte[] parsingBuf = mLoraDataBuff.ToArray();
                        WirteTextBox($"SPLUS Data Receive{alert}");
                        WirteTextBox(BitConverter.ToString(parsingBuf));
                        SendVms(alert);
                    }
                    else if (mLoraDataBuff.Count == NOTIFICATION_LENGTH)
                    {
                        int alert = mLoraDataBuff[3];

                        byte[] parsingBuf = mLoraDataBuff.ToArray();
                        WirteTextBox($"NOTI Data Receive{alert}");
                        WirteTextBox(BitConverter.ToString(parsingBuf));
                        SendVms(alert);
                    }
                    break;
                }
                else if (isStart)
                {
                    mLoraDataBuff.Add(data);
                    index++;
                }
                  
            }

            if (isStart)
            {
                if (!isEnd)
                {
                    isStart = false;
                    mLoraDataBuff.Clear();
                }
            }
            else
            {
                _listLoraRBuff.Clear();
            }

#endif

        }

        private void WriteTextBox(byte[] buff, bool isRead, bool isTcp)
        {
            string readData = "";

            DateTime dt = DateTime.Now;

            readData = string.Format("[{0:D2}:{1:D2}:{2:D2}:{3:D2}] - ", dt.Hour, dt.Minute, dt.Second, dt.Millisecond);

            if (isRead)
            {
                readData += " <- ";
            }
            else
            {
                readData += " -> ";
            }
            //readData += Encoding.Default.GetString(buff) + "/r/n";

            if (isTcp)
            {
                readData += Encoding.Default.GetString(buff) + Environment.NewLine;
            }
            else
            {

                foreach (byte data in buff)
                {
                    readData += "[" + data.ToString("X2") + "]";
                }
                readData += Environment.NewLine;
            }

            string str = readData + textBoxLoraData.Text;   // 받은 데이터 표시
            textBoxLoraData.Invoke(new Action<string>(doInvoke), str);

            SaveLog(readData);
        }

        private void WirteTextBox(string readData)
        {
            DateTime dt = DateTime.Now;

            readData = string.Format("[{0:D2}:{1:D2}:{2:D2}:{3:D2}] - {4}", dt.Hour, dt.Minute, dt.Second, dt.Millisecond, readData);
            readData += Environment.NewLine;
            string str = readData + textBoxLoraData.Text;   // 받은 데이터 표시
            textBoxLoraData.Invoke(new Action<string>(doInvoke), str);

            SaveLog(readData);
        }

        static int oldDay = -1;
        public static void SaveLog(string strLog)
        {
            if (strLog == null)
                return;

            DateTime dt = DateTime.Now;

            if (oldDay != dt.Day)    // 이전 날과 다르면 폴드 생성
            {
                DirectoryInfo di = new DirectoryInfo(g_logPath);

                if (!di.Exists)
                {
                    di.Create();        // 경로 생성
                }

                string fileName = string.Format("{0}/{1:D4}{2:D2}{3:D2}.txt", g_logPath, dt.Year, dt.Month, dt.Day);
                FileInfo fi = new FileInfo(fileName);

                File.AppendAllText(fileName, strLog, Encoding.Default);
            }
        }

        public void doInvoke(string _strPrint)
        {
            textBoxLoraData.Text = _strPrint;

            if (textBoxLoraData.Lines.Length > 100)
            {
                textBoxLoraData.Text = textBoxLoraData.Text.Remove(textBoxLoraData.Text.LastIndexOf(Environment.NewLine));
            }
        }

        private void buttonConnectionServer_Click(object sender, EventArgs e)
        {
            if(_vmsConnection == false)
            {
                connetionServer();
            }
            else
            {
                WirteTextBox("VMS 연결 끊기!!");
                if (_tcpClient != null)
                {
                    if (_tcpClient.Client.IsBound)
                        _tcpClient.Close();

                    _tcpClient = null;
                }
            }
        }

        private void connetionServer()
        {
            try
            {
                WirteTextBox("VMS 연결 시도");

                //if (_tcpClient != null && _vmsConnection /*mTcpClient.Connected*/)
                //    return; //연결이 되어 있는데 또 연결 방지용, 서버쪽에 연결된 노드가 늘어남

                IPAddress.TryParse(tbServerIP.Text, out _ipAddress);    // VMP  서버 IP 설정
                int.TryParse(tbServerPort.Text, out _vmsPort);          // VMS 서버 Port 설정

                if (_tcpClient == null)
                {
                    _tcpClient = new TcpClient();
                    _tcpClient.BeginConnect(_ipAddress, _vmsPort, onCompleteConnect, _tcpClient);
                }
            }
            catch (Exception ex)
            {
                WirteTextBox("connetion " + ex.Message);
            }
        }

        void onCompleteConnect(IAsyncResult iar)
        {
            TcpClient tcpc;

            try
            {
                //iar.AsyncWaitHandle.WaitOne(1000, false);

                tcpc = (TcpClient)iar.AsyncState;
                tcpc.EndConnect(iar);
                _vmsRBuff = new byte[512];
                tcpc.GetStream().BeginRead(_vmsRBuff, 0, _vmsRBuff.Length, onCompleteReadFromServerStream, tcpc);
                _vmsConnection = true; //연결 성공

                WirteTextBox("VMS 연결 성공!!");

                if (isfirstBoot)
                {
                    SendVms(0);
                    isfirstBoot = false;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(exc.Message);
                _vmsConnection = false; //연결 실패
                WirteTextBox("complete connect " + ex.Message);
            }
        }

        void onCompleteReadFromServerStream(IAsyncResult iar)
        {
            TcpClient tcpc;
            int nCountBytesReceivedFromServer;
            string strReceived;

            try
            {
                if (_tcpClient != null && _tcpClient.Connected)
                {
                    tcpc = (TcpClient)iar.AsyncState;
                    nCountBytesReceivedFromServer = tcpc.GetStream().EndRead(iar);

                    if (nCountBytesReceivedFromServer == 0)
                    {
                        _vmsConnection = false; //연결 실패
                        WirteTextBox("VMS Connection broken.");
                        //MessageBox.Show("Connection broken.");
                        return;
                    }
                    strReceived = Encoding.Default.GetString(_vmsRBuff, 0, nCountBytesReceivedFromServer);
                    string s1 = Encoding.Default.GetString(_vmsRBuff, 0, nCountBytesReceivedFromServer - 1);

                    //if(mRx[nCountBytesReceivedFromServer-1] != '\n') return;
                    WriteTextBox(Encoding.UTF8.GetBytes(s1), true, true);

                    _vmsRBuff = new byte[512];
                    tcpc.GetStream().BeginRead(_vmsRBuff, 0, _vmsRBuff.Length, onCompleteReadFromServerStream, tcpc);

                    _vmsConnection = true; //연결 성공
                }
            }
            catch (Exception ex)
            {
                //_vmsConnection = false; //연결 실패
                WirteTextBox("complete server " + ex.Message);
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SendVms(int velocity)
        {
#if false
            string sendString = string.Format("![000/E0606 /S1000 /C1전방 작업중 주의 운행!! !]");

            if (_isDanger == false)
            {
                 sendString = string.Format("![000/E0606 /S1000 /C2전방 작업중 안전 운행! !]");


                //if(velocity == 0xAA) // 테스트 버튼
                //{
                //    _type = 0;  // 0: 소통원활, 1: 지체, 2: 정체, 3: 사고
                //    sendString = string.Format("![000소통원활/C1 75km//h  !]");
                //}

                //if (velocity < 0xff && velocity > 60)
                //{
                //    _type = 0;  // 0: 소통원활, 1: 지체, 2: 정체, 3: 사고
                //    sendString = string.Format("![000소통원활 /C2{0}km//h !]", velocity);
                //}
                //else if (velocity <= 60 && velocity > 30)
                //{
                //    _type = 1;  // 0: 소통원활, 1: 지체, 2: 정체, 3: 사고
                //    sendString = string.Format("![000소통원활 /C1{0}km//h !]", velocity);
                //}
                //else if (velocity <= 30 && velocity > 10)
                //{
                //    _type = 2;  // 0: 소통원활, 1: 지체, 2: 정체, 3: 사고
                //    sendString = string.Format("![000전방지체 /C3{0}km//h !]", velocity);
                //}
                //else if (velocity <= 10 && velocity >= 0)
                //{
                //    _type = 3;  // 0: 소통원활, 1: 서행, 2: 지체, 3: 정체
                //    sendString = string.Format("![000전방정체 /C4{0}km//h !]", velocity);
                //}
                //else
                //{
                //    _type = 3;  // 0: 소통원활, 1: 서행, 2: 지체, 3: 정체
                //    sendString = string.Format("![000전방정체 /C4{0}km//h !]", velocity);
                //}
            }
            else
            {
                _type = 4;  // 0: 소통원활, 1: 서행, 2: 지체, 3: 정체, 4: 사고
                sendString = string.Format("![000/E0606 /S1000 /C1전방 작업중 주의 운행!! !]");
            }

#else

            bool isRefresh = false;

            //string sendString = "![000/E0606 /S1000 /C2밀폐지역 가스 측정치 /C4정상 /C2입니다 !]";
            string sendString = "![000/E0606/S1000/C1안전사항/C2을 준수하여 작업하시기 바랍니다!!!]";

            if (pastEventCode != velocity)
            {
                pastEventCode = velocity;

                isRefresh = true;
                
                switch (velocity)
                {
                    case 0x73:
                        /*
                         * 폭염 주의
                         */
                        sendString = "![000/E5555/S7000/C1폭염 /C3주의보 /C2단계!]";
                        break;
                    case 0x74:
                        /*
                         * 폭염 주의
                         */
                        sendString = "![000/E5555/S7000/C1 폭염 경고 /C2단계!]";
                        break;
                    case 0x00:
                        sendString = "![000/E0606/S1000/C1안전사항/C2을 준수하여 작업하시기 바랍니다!!!]";
                        break;
                    case 0x51:
                        /*
                         * O2 주의
                         */
                        //sendString = "![000/E0606 /S1000 /C1산소 /C2측정치 이상 감지 주의하세요 !]";
                        sendString = "![000/E5555/S7000/C1산소 /C2측정치 /C3주의 !]";
                        break;
                    case 0x61:
                        /*
                         * O2 경고
                         */
                        //sendString = "![000/E0606 /S1000 /C1산소  /C2측청치 이상 발생 대피하세요 !]";
                        sendString = "![000/E5555/S7000/C1산소 /C2측청치 /C1경고 !]";
                        break;
                    case 0x52:
                        /*
                         * CO 주의
                         */
                        //sendString = "![000/E0606 /S1000 /C1일산화탄소 /C2감지 주의하세요 !]";
                        sendString = "![000/E5555/S7000/C1일산화탄소 /C3주의 !]";
                        break;
                    case 0x62:
                        /*
                         * CO 경고
                         */
                        //sendString = "![000/E0606 /S1000 /C1일산화탄소 /C2높음 대피하세요 !]";
                        sendString = "![000/E5555/S7000/C1일산화탄소 경고 !]";
                        break;
                    case 0x53:
                        /*
                         * H2S 주의
                         */
                        //sendString = "![000/E0606 /S1000 /C1황화수소 /C2감지 주의하세요 !]";
                        sendString = "![000/E5555/S7000/C1황화수소 /C3주의 !]";
                        break;
                    case 0x63:
                        /*
                         * H2S 경고
                         */
                        //sendString = "![000/E0606 /S1000 /C1황화수소 /C2높음 대피하세요 !]"; 
                        sendString = "![000/E5555/S7000/C1황화수소 경고 !]";
                        break;
                    case 0x54:
                        /*
                         * 가연성가스 주의
                         */
                        //sendString = "![000/E0606 /S1000 /C1폭발 위험 /C2감지 주의하세요 !]";
                        sendString = "![000/E5555/S7000/C1가연성 가스 /C3주의 !]";
                        break;
                    case 0x64:
                        /*
                         * 가연성가스 경고
                         */
                        //sendString = "![000/E0606 /S1000 /C1폭발 위험 /C2높음 대피하세요 !]";
                        sendString = "![000/E5555/S7000/C1가연성 가스 경고 !]";
                        break;
                    /*
                     *  해제 코드
                     */
                    case 0x6A:
                    case 0x6B:
                    case 0x6C:
                    case 0x6D:
                        //sendString = "![000/E0606 /S1000 /C2밀폐지역 가스 측정치 /C4정상 /C2입니다 !]";                   
                        sendString = "![000/E0606/S1000/C1안전사항/C2을 준수하여 작업하시기 바랍니다!!!]";
                        break;
                }
            }
            
#endif
            // 20240103 부산 항만 소리 사용하지 않음
            //VmsSoundPlay(_type);

            if (isRefresh)
            {
                isRefresh = false;
                byte[] sendData;

                //sendData = Encoding.ASCII.GetBytes(sendString);
                sendData = Encoding.Default.GetBytes(sendString);
                
                try
                {
                    connetionServer();
                    Thread.Sleep(200);  // 서버 연결 후 조금 기다렸다가 데이터 보내야 함

                    if (_vmsConnection)
                    {

                        if (_tcpClient != null)
                        {
                            if (_tcpClient.Client.Connected)
                            {

                                WriteTextBox(sendData, false, true);
                                _tcpClient.GetStream().BeginWrite(sendData, 0, sendData.Length, onCompleteWriteToServer, _tcpClient);

                                //WriteTextBox(sendData, false, true);
                            }
                        }
                    }

                    WirteTextBox("VMS 연결 끊기!!");
                    if (_tcpClient != null)
                    {
                        if (_tcpClient.Client.IsBound)
                            _tcpClient.Close();

                        _tcpClient = null;
                    }

                }
                catch (Exception ex)
                {
                    WirteTextBox(ex.Message);
                }
            }
            

            //try
            //{
            //    if (_vmsConnection)
            //    {

            //        if (_tcpClient != null)
            //        {
            //            if (_tcpClient.Client.Connected)
            //            {

            //                WriteTextBox(sendData, false, true);
            //                _tcpClient.GetStream().BeginWrite(sendData, 0, sendData.Length, onCompleteWriteToServer, _tcpClient);

            //                //WriteTextBox(sendData, false, true);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _vmsConnection = false;
            //    //MessageBox.Show(exc.Message);
            //    WirteTextBox(ex.Message);
            //}
        }


        void onCompleteWriteToServer(IAsyncResult iar)
        {
            TcpClient tcpc;

            try
            {
                tcpc = (TcpClient)iar.AsyncState;
                tcpc.GetStream().EndWrite(iar);
                //bCompleted = true;
            }
            catch (Exception ex)
            {
                //bCompleted = false;
                //MessageBox.Show(exc.Message);
                WirteTextBox(ex.Message);
            }
        }

        void VmsSoundPlay(int type)
        {

            if (_isPlay == false)   // 소리 출력 하지 않으면 소리 안나오게 변경
                return;

            // 이전 값이랑 같으면 변경하지 않음
            if (type == _oldType)
            {
                return;
            }

            _player.Stop();
            _oldType = type;

            //System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            //System.IO.Stream s = a.GetManifestResourceStream("<AssemblyName>.smooth.wav");

            if (checkBoxSound.Checked == false)     // 소리 설정하지않으면 나오지 않음
                return;


            switch (type)
            {
                case 0: // 소통원활
                    //s = a.GetManifestResourceStream(@"C:\catchcar\sound\smooth.wav");
                    //_player.SoundLocation = @"C:\catchcar\sound\smooth.wav";
                    _player.SoundLocation = @"C:\catchcar\sound\smooth2.wav";
                    break;
                case 1: // 소통원활
                    //s = a.GetManifestResourceStream(@"C:\catchcar\sound\smooth.wav");
                    //_player.SoundLocation = @"C:\catchcar\sound\smooth.wav";
                    _player.SoundLocation = @"C:\catchcar\sound\smooth2.wav";
                    break;
                case 2: // 정체
                    //s = a.GetManifestResourceStream(@"C:\catchcar\sound\delay.wav");
                    //_player.SoundLocation = @"C:\catchcar\sound\delay.wav";
                    _player.SoundLocation = @"C:\catchcar\sound\smooth2.wav";
                    break;
                case 3: // 정체
                    //s = a.GetManifestResourceStream(@"C:\catchcar\sound\logjam.wav");
                    //_player.SoundLocation = @"C:\catchcar\sound\logjam.wav";
                    _player.SoundLocation = @"C:\catchcar\sound\logjam2.wav";
                    break;
                case 4: // 사고발생
                    //s = a.GetManifestResourceStream(@"C:\catchcar\sound\accident.wavtextBoxLoraData
                    //_player.SoundLocation = @"C:\catchcar\sound\accident.wav";
                    _player.SoundLocation = @"C:\catchcar\sound\accident2.wav";
                    break;
                default: // 사고발생
                    //s = a.GetManifestResourceStream(@"C:\catchcar\sound\smooth.wav");
                    //_player.SoundLocation = @"C:\catchcar\sound\smooth.wav";
                    _player.SoundLocation = @"C:\catchcar\sound\smooth2.wav";
                    break;
            }

            //_player = new SoundPlayer(s);
            //_player.Load();
            _player.PlayLooping();
        }

        private void trackBarVelocity_ValueChanged(object sender, EventArgs e)
        {
            labelSetVelocity.Text = trackBarVelocity.Value.ToString();
        }

        private void buttonSago_Click(object sender, EventArgs e)
        {
            SendVms(0xFF);
        }

        private void buttonVelocity_Click(object sender, EventArgs e)
        {
            int velocity = trackBarVelocity.Value;
            SendVms(velocity);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] buff = new byte[6];
            //buff[0] = (byte)'t';
            //buff[1] = (byte)'e';
            //buff[2] = (byte)'s';
            //buff[3] = (byte)'t';
            //buff[4] = (byte)'g';

            buff[0] = 0x3C;
            buff[1] = 0xf1;
            buff[2] = 0xFF;
            buff[3] = 0x01;
            buff[4] = 0x00;
            buff[5] = 0x3E;

            //LoraDataCotrol(buff);
            SendVms(0x53);

        }

        private void buttonSoundPlay_Click(object sender, EventArgs e)
        {
            int type = int.Parse(textBoxType.Text);
            _type = type;

            // 20240103 부산 항만 소리 사용하지 않음
            //VmsSoundPlay(type);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] buff = new byte[6];
            buff[0] = 0x3C;
            buff[1] = 0xf1;
            buff[2] = 0xFF;
            buff[3] = 0x00;
            buff[4] = 0x00;
            buff[5] = 0x3E;
            //LoraDataCotrol(buff);
            SendVms(0x54);
        }

        private void checkBoxSound_CheckedChanged(object sender, EventArgs e)
        {
            if (_isPlay)
            {
                _player.Stop();
                _isPlay = false;
            }
            else
            {
                _isPlay = true;
            }
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            
            labelDate.Text = string.Format("{0:D4}-{1:D2}-{2:D2}", dt.Year, dt.Month, dt.Day);
            labelTime.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", dt.Hour, dt.Minute, dt.Second);

            if (_loraConnection)
            {
                buttonOpenSerial.Text = "닫기";
                labelSerialStatus.BackColor = Color.LightGreen;
                labelSerialStatus.Text = "열림";
                //textBoxLoraPortName.Enabled = false;
                _serialReCon = 0;
            }
            else
            {
                buttonOpenSerial.Text = "열기";
                labelSerialStatus.BackColor = Color.Red;
                labelSerialStatus.Text = "닫힘";

                if (_serialReCon++ > 60) // 1분 후 자동 재연결
                {
                    connectionSerial(); // 로라 연결
                    _serialReCon = 0;
                }
            }


            if (_vmsConnection) //연결 성공
            {
                labelVmsStatus.BackColor = Color.LightGreen;
                labelVmsStatus.Text = "연결중";
                buttonConnectionServer.Text = "끊기";
            }
            else
            {
                labelVmsStatus.BackColor = Color.Red;
                labelVmsStatus.Text = "끊어짐";
                buttonConnectionServer.Text = "연결";

                if (_vmsReCon++ > 60) // 1분 후 자동 재연결
                {
                    connetionServer();  // 전광판 연결
                    _vmsReCon = 0;
                }
            }

            if (_isDanger)  // 위험 신호일 시 정해진 시간 후 위험 신호 풀리게 함
            {
                _tickCnt++;

                if(_tickCnt > _tickValue)
                {
                    _isDanger = false;
                    _tickCnt = 0;
                }
            }

            if (_isDanger)
            {
                labelDanger.Text = "위험 발생";
                labelDanger.BackColor = Color.Red;
            }
            else
            {
                labelDanger.Text = "위험 해제";
                labelDanger.BackColor = Color.Green;
            }

            labelVelocity.Text = _velocity.ToString();

            labelTick.Text = (_tickValue - _tickCnt).ToString();

        }

        private void buttonSetTick_Click(object sender, EventArgs e)
        {
            _tickValue = (int)numericUpDownTick.Value;
        }

        private void buttonDataClear_Click(object sender, EventArgs e)
        {
            textBoxLoraData.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_vmsConnection)
            {
                if (_tcpClient != null)
                    _tcpClient.Close();

            }

            if (_loraConnection)
            {
                if (serialPortLora != null)
                    serialPortLora.Close();

            }
            

        }

        private void textBoxLoraData_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
