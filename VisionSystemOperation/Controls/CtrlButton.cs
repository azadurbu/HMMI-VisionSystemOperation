using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;
//using GlassViewer; // MEER 2024.08.23
using System.Runtime.InteropServices;

using Inspection;
using VisionSystemOperation.Device;
using VisionSystemOperation.Device.PLC_Library;

namespace VisionSystemOperation.Controls
{
    public enum eProgramMode
    {
        Inspection,
        Stop,
        ByPass,
        Test,
    }

    public partial class CtrlButton : UserControl
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_MAXIMIZE = 3;
        [DllImport("User32", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern void SetForegroundWindow(IntPtr hWnd);

        public eProgramMode CurProgramMode { get; set; } = eProgramMode.Inspection;

        public CtrlButton()
        {
            InitializeComponent();
        }

        private void CtrlButton_Load(object sender, EventArgs e)
        {
            try
            {
                //Start();
                //EnableButton(CurProgramMode);
            }
            catch (Exception err)
            {
                string strErr = err.ToString();
                Machine.logger.WriteAsync(eLogType.ERROR, "CtrlButton_Load Err : " + strErr);
                //FormMain.Instance().Log(eLogType.ERROR, MethodBase.Ge-tCurrentMethod().Name.ToString() + " : " + err.ToString(), DateTime.Now, true);
            }
        }

        public void Start()
        {
            //Check Device Connecting Status before Sequence run
            bool isCamConnect = false, isPLCConnect = false, isLightConnect = false;
            Machine.sequence.CurrentDeviceStatus(out isCamConnect, out isPLCConnect, out isLightConnect);
            if (!isCamConnect || !isPLCConnect || !isLightConnect)
            {
                string message = $"[Connect Error] CamConnect = {isCamConnect.ToString()},  PLCConnect = {isPLCConnect.ToString()},  LightConnect = {isLightConnect.ToString()}";
                Machine.logger.WriteAsync(eLogType.ERROR, message);

                Machine.sequence.IsSeqData[(int)eVision2PLCSeq.PC_COMM_ERROR] = true;
                if (!Machine.plc.WriteVistion2PLCSeq(Machine.sequence.IsSeqData, 16)) //1Word = 2byte = 16bit
                {
                    if (Machine.plc.ERR_MSG != "")
                        Machine.logger.WriteAsync(eLogType.ERROR, "Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString());
                }

                MessageBox.Show(message);
                return;
            }
            //

            CurProgramMode = eProgramMode.Inspection;
            Machine.sequence.StartSequence(eSeqStep.SEQ_START);
            EnableButton(CurProgramMode);

            TowerLampManager.StartLampOn();
        }

        private void btnInspection_Click(object sender, EventArgs e)
        {
            try
            {
                Machine.logger.WriteAsync(eLogType.SEQ, "Click Inspection Button.");

                Machine.plc.IsVisionSeqRecvData[(int)eVision2PLCSeq.VISION_PASS] = false;
                Machine.sequence.IsSeqData[(int)eVision2PLCSeq.VISION_PASS] = false;

                if (!Machine.plc.WriteVistion2PLCSeq(Machine.plc.IsVisionSeqRecvData, 16)) //1Word = 2byte = 16bit
                {
                    string errMsg = "Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG;
                    MessageBox.Show(errMsg);
                    return;
                }
                Start();

            }
            catch (Exception err)
            {
                Machine.logger.WriteAsync(eLogType.SEQ, MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.ToString());
            }
        }
        public void Stop()
        {
            try
            {
                ////Log 추가
                //FormMain.Instance().LogDisplayControl.AddLog("--Stop--");

                Machine.plc.IsVisionSeqRecvData[(int)eVision2PLCSeq.VISION_PASS] = false;
                Machine.sequence.IsSeqData[(int)eVision2PLCSeq.VISION_PASS] = false;
                Machine.plc.IsVisionSeqRecvData[(int)eVision2PLCSeq.READY_ON] = false;
                Machine.plc.IsVisionSeqRecvData[(int)eVision2PLCSeq.AUTO_START] = false;
                Machine.sequence.IsSeqData[(int)eVision2PLCSeq.READY_ON] = false;
                Machine.sequence.IsSeqData[(int)eVision2PLCSeq.AUTO_START] = false;
                if (!Machine.plc.WriteVistion2PLCSeq(Machine.plc.IsVisionSeqRecvData, 16)) //1Word = 2byte = 16bit
                {
                    string errMsg = "Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG;
                    MessageBox.Show(errMsg);
                    return;
                }
                TowerLampManager.ReadyLampOn();

                Machine.logger.WriteAsync(eLogType.SEQ, "--Stop--");
                CurProgramMode = eProgramMode.Stop;
                Machine.sequence.SeqStep = eSeqStep.SEQ_STOP;
                EnableButton(CurProgramMode);
            }
            catch (Exception err)
            {
                //Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                Machine.logger.WriteAsync(eLogType.ERROR, MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.ToString());
                //Logger.Write(eLogType.ERROR, MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.ToString());
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                ////Log 추가
                //FormMain.Instance().LogDisplayControl.AddLog("Click Stop Buttom.");
                Machine.logger.WriteAsync(eLogType.SEQ, "Click Stop Buttom.");

                DialogResult result = MessageBox.Show("Stop?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    Machine.logger.WriteAsync(eLogType.SEQ, "Cancel Stop ");
                    return;
                }

                Stop();
            }
            catch (Exception err)
            {
                //Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                Machine.logger.WriteAsync(eLogType.ERROR, MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.ToString());
                //Logger.Write(eLogType.ERROR, MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.ToString());
            }
        }

        public void EnableButton(eProgramMode type)
        {
            try
            {
                switch (type)
                {
                    case eProgramMode.Inspection:
                        if (btnInspection.InvokeRequired)       //220817

                        {
                            btnInspection.BeginInvoke(new Action(() => btnInspection.Enabled = false));
                            btnStop.BeginInvoke(new Action(() => btnStop.Enabled = true));
                            btnByPass.BeginInvoke(new Action(() => btnByPass.Enabled = true));
                        }
                        else
                        {
                            btnInspection.Enabled = false;
                            btnStop.Enabled = true;
                            btnByPass.Enabled = true;
                        }
                        break;
                    case eProgramMode.Stop:

                        if (btnInspection.InvokeRequired)       //220817

                        {
                            btnInspection.BeginInvoke(new Action(() => btnInspection.Enabled = true));
                            btnStop.BeginInvoke(new Action(() => btnStop.Enabled = false));
                            btnByPass.BeginInvoke(new Action(() => btnByPass.Enabled = true));
                        }
                        else
                        {
                            btnInspection.Enabled = true;
                            btnStop.Enabled = false;
                            btnByPass.Enabled = true;
                        }
                        break;
                    case eProgramMode.ByPass:

                        if (btnInspection.InvokeRequired)       //220817

                        {
                            btnInspection.BeginInvoke(new Action(() => btnInspection.Enabled = true));
                            btnStop.BeginInvoke(new Action(() => btnStop.Enabled = true));
                            btnByPass.BeginInvoke(new Action(() => btnByPass.Enabled = false));
                        }
                        else
                        {

                            btnInspection.Enabled = true;
                            btnStop.Enabled = true;
                            btnByPass.Enabled = false;
                        }
                        break;
                    case eProgramMode.Test:

                        if (btnInspection.InvokeRequired)       //220817

                        {
                            btnInspection.BeginInvoke(new Action(() => btnInspection.Enabled = true));
                            btnStop.BeginInvoke(new Action(() => btnStop.Enabled = true));
                        }
                        else
                        {

                            btnInspection.Enabled = true;
                            btnStop.Enabled = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception err)
            {
                //Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                Machine.logger.WriteAsync(eLogType.ERROR, MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.ToString());
                //Logger.Write(eLogType.ERROR, MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.ToString());
            }
        }

        DateTime StartTime = DateTime.Now;
        DateTime EndTime = DateTime.Now;
        TimeSpan OpenSpan = new TimeSpan();
        private void btnHistory_Click(object sender, EventArgs e)
        {
            EndTime = DateTime.Now;
            OpenSpan = EndTime - StartTime;
            if (OpenSpan.Ticks < 10000000)
                return;

            StartTime = DateTime.Now;
            Process[] processes = Process.GetProcesses();
            foreach (Process proc in processes)
            {
                if ("GlassViewer".Equals(proc.ProcessName))
                {
                    string name = proc.MainWindowTitle;
                    if (name == "")
                        break;
                    IntPtr procHandler = FindWindow(null, name);
                    ShowWindow(procHandler, SW_MAXIMIZE);
                    SetForegroundWindow(procHandler);
                    return;
                }
            }
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = Path.Combine(Directory.GetCurrentDirectory() + "\\GlassViewer.exe");
            // psi.Arguments = Settings.Instance().Operation.ImageFolderPath; // MEER 2024.08.21 DISABLED
            Process.Start(psi);
            //Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "GlassViewer.exe"));
        }

        public void ByPass()
        {
            try
            {
                Machine.plc.IsVisionSeqRecvData[(int)eVision2PLCSeq.VISION_PASS] = true;
                Machine.sequence.IsSeqData[(int)eVision2PLCSeq.VISION_PASS] = true;
                if (!Machine.plc.WriteVistion2PLCSeq(Machine.sequence.IsSeqData, 16)) //1Word = 2byte = 16bit
                {
                    if (Machine.plc.ERR_MSG != "")
                        Machine.logger.WriteAsync(eLogType.ERROR, "Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString());

                    MessageBox.Show("Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString());
                    return;
                }



                CurProgramMode = eProgramMode.ByPass;
                Machine.sequence.StartSequence(eSeqStep.SEQ_START);
                EnableButton(CurProgramMode);

                TowerLampManager.StartLampOn();

            }
            catch (Exception err)
            {
                //Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                Machine.logger.WriteAsync(eLogType.ERROR, MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.ToString());
                //Logger.Write(eLogType.ERROR, MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.ToString());
            }
        }

        private void btnByPass_Click(object sender, EventArgs e)
        {
            ByPass();
        }
    }
}
