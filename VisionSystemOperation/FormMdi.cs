using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;

using VisionSystemOperation.Class;
using VisionSystemOperation.Controls;
using VisionSystemOperation.Device;
using VisionSystemOperation.Forms;
using AlignCheck.MasterImage;
using VisionSystemOperation.MasterImage.UIForm;
using VisionSystemOperation.Device.PLC_Library;
using VisionSystemOperation.Inspection.MotorCar.Model;

namespace VisionSystemOperation
{
    public partial class FormMdi : Form
    {

        private CtrlHeader ctrlHeader = null;
        private CtrlCarTypeVin ctrlCarTypeVin = null;
        private CtrlCameraPlc ctrlCameraPlc = null;
        private CtrlHistoryCountDetail ctrlHistoryCountDetail = null;
        private CtrlHistoryData ctrlHistoryData = null;
        private CtrlLogDisplay ctrlLogDisplay = null;
        private CtrlButton ctrlButton = null;

        //menu pages
        private Forms.FormMain formMainWindow = null;
        private FormCamera formCamera = null;
        private FormInterface formInterface = null;
        private FormDB formDB = null;
        private FormLog formLog = null;
        private FormSetting formSetting = null;
        private FormShift formShift = null;

        public CtrlButton CtrlButton { get => ctrlButton; }
        public FormMain FormMainWindow { get => formMainWindow; }
        public CtrlCarTypeVin CtrlCarTypeVin { get => ctrlCarTypeVin; set => ctrlCarTypeVin = value; }
        public int TotalinspCount = 0;
        private Timer inactivityTimer;
        private DateTime lastMouseMoveTime;
        public FormMdi()
        {
            InitializeComponent();

            // to hide the form_controls from mdi_form
            MenuStrip menu = new MenuStrip();
            MainMenuStrip = menu;
            TotalinspCount = InspCountToday();
            lblInspCounter.Text = TotalinspCount.ToString();

            inactivityTimer = new Timer();
            inactivityTimer.Interval = Machine.config.setup.inActiveThread;
            inactivityTimer.Tick += InactivityTimer_Tick;
            inactivityTimer.Start();

            ResetInactivityTimer();

            string version = "v1.1.1";
            Machine.logger.WriteAsync(eLogType.INFORMATION, "=================================Version : " + version);
            Machine.logger.WriteAsync(eLogType.SEQ, "=================================Version : " + version);
        }

        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now - lastMouseMoveTime;
            int timeDiff = (int)span.TotalMilliseconds;
            
            if (timeDiff > Machine.config.setup.inActiveThread)
            {
                OpenMainFormIfNotFocused();
            }
        }

        private void OpenMainFormIfNotFocused()
        {
            // If FormInterface is currently active, skip opening MainForm
            foreach (Form child in this.MdiChildren)
            {
                if (child is FormInterface)
                    return;
            }

            // Otherwise, bring MainForm to front
            foreach (Form child in this.MdiChildren)
            {
                if (child is FormMain)
                {
                    child.BringToFront();
                    child.Activate();
                    break;
                }
            }
        }


        public void ResetInactivityTimer()
        {
            lastMouseMoveTime = DateTime.Now;
        }

        private void FormMdi_Load(object sender, EventArgs e)
        {
            Machine.sequence = new Sequence(this);
            Machine.sequence.OnCountChange += InspCount();
            AddControls();
            formMainWindow = new Forms.FormMain();
            formMainWindow.MdiParent = this;
            formMainWindow.WindowState = FormWindowState.Maximized;
            formMainWindow.Show();
        }             

        private void AddControls()
        {
            ctrlHeader = new CtrlHeader();
            pnlHeader.Controls.Add(ctrlHeader);
            ctrlHeader.Dock = DockStyle.Fill;

            ctrlCarTypeVin = new CtrlCarTypeVin();
            pnlTypeVin.Controls.Add(ctrlCarTypeVin);

            ctrlCameraPlc = new CtrlCameraPlc();
            pnlCamPlcStatus.Controls.Add(ctrlCameraPlc);
            ctrlCameraPlc.Dock = DockStyle.Right;
            ctrlCameraPlc.CameraStatus(true);

            ctrlLogDisplay = new CtrlLogDisplay();
            pnlLog.Controls.Add(ctrlLogDisplay);
            ctrlLogDisplay.Dock = DockStyle.Fill;

            ctrlButton = new CtrlButton();
            pnlInspectionStartStop.Controls.Add(ctrlButton);
            ctrlButton.Dock = DockStyle.Fill;
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            if (formMainWindow == null)
                formMainWindow = new Forms.FormMain();
                
            formMainWindow.MdiParent = this;
            formMainWindow.WindowState = FormWindowState.Maximized;
            formMainWindow.Show();
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            if(formCamera == null)
                formCamera = new Forms.FormCamera();

            formCamera.MdiParent = this;
            formCamera.WindowState = FormWindowState.Maximized;
            formCamera.Show();
        }

        private delegate void ShowInterfaceDele();      
        public void ShowInterface()
        {
            if (this.InvokeRequired)
            {
                ShowInterfaceDele callBack = ShowInterface;
                BeginInvoke(callBack);      // 221019 메인에서 CAM 이미지 크게 보기
                return;
            }

            if (formInterface == null)
                formInterface = new FormInterface();
            formInterface.MdiParent = this;
            formInterface.WindowState = FormWindowState.Maximized;
            formInterface.Show();

        }

        private void btnInterface_Click(object sender, EventArgs e)
        {

            ShowInterface();
            //FormPLCInterface formPLCInterface = new FormPLCInterface();
            //formPLCInterface.Show();
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            //if (formDB == null)
            formDB = new FormDB();
            formDB.MdiParent = this;
            formDB.WindowState = FormWindowState.Maximized;
            formDB.Show();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            //if (formLog == null)
            formLog = new FormLog();
            formLog.MdiParent = this;
            formLog.WindowState = FormWindowState.Maximized;
            formLog.Show();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (formSetting == null)
                formSetting = new FormSetting(this);
            formSetting.MdiParent = this;
            formSetting.WindowState = FormWindowState.Maximized;
            formSetting.Show();
        }

        public void UpdateUI(string imgPath)
        {
            if (formSetting != null)
                formSetting.SetImg(imgPath);

        }
        public void Log(eLogType type, string message, DateTime dateTime, bool isUIUpdate = false)
        {
            Machine.logger.WriteAsync(type, message);
            //Console.WriteLine(message);
            if (this.ctrlLogDisplay != null)
            {
                this.ctrlLogDisplay.AddLog(message);
            }
        }

        private void FormMdi_FormClosed(object sender, FormClosedEventArgs e)
        {
            CtrlButton.Stop();
            Machine.Terminate();
        }

        XGPLCManager PLC { get; set; } = new XGPLCManager("", 0);
        private void tmDeviseConnectionStatus_Tick(object sender, EventArgs e)
        {
            bool p = Machine.plc.IsConnected();
            ctrlCameraPlc.PLCStatus(p);

            bool c = Machine.camManager.IsOpen();
            ctrlCameraPlc.CameraStatus(c);

            bool l = Machine.lightmodule.isConnected();
            ctrlCameraPlc.LightStatus(c);

        }

        private delegate string InspCountDele();      
        public string InspCount()
        {
            if (this.InvokeRequired)
            {
                InspCountDele callBack = InspCount;
                BeginInvoke(callBack);      // 221019 메인에서 CAM 이미지 크게 보기
                return "";
            }
            TotalinspCount = InspCountToday();
            lblInspCounter.Text = TotalinspCount.ToString();
            return TotalinspCount.ToString();
        }

        public int InspCountToday()
        {
            var shift = ShiftManager.CurrentShift();
            DateTime ShiftStart = DateTime.Today;
            DateTime ShiftEnd = DateTime.Now;
            if (shift == "D")
            {
                ShiftStart = DateTime.Today.Add(System.TimeSpan.Parse(Machine.config.setup.shiftProperty.DayShiftStart));
                ShiftEnd = DateTime.Today.Add(System.TimeSpan.Parse(Machine.config.setup.shiftProperty.DayShiftEnd));
            }
            else if (shift == "N")
            {
                TimeSpan now = DateTime.Now.TimeOfDay;

                var s = System.TimeSpan.Parse(Machine.config.setup.shiftProperty.NightShiftStart);
                var e = System.TimeSpan.Parse(Machine.config.setup.shiftProperty.NightShiftEnd);

                ShiftStart = DateTime.Today.Add(System.TimeSpan.Parse(Machine.config.setup.shiftProperty.NightShiftStart));
                ShiftEnd = DateTime.Today.Add(System.TimeSpan.Parse(Machine.config.setup.shiftProperty.NightShiftEnd));

                if (now.Hours >= s.Hours && now.Hours <= 23)
                {
                    ShiftEnd = ShiftEnd.AddDays(1);
                }
                else if (now.Hours >= 0 && now.Hours <= e.Hours)
                {
                    ShiftStart = ShiftStart.AddDays(-1);
                }
            }
            List<InspectionResultDB> insp = null;
            insp = Machine.HanMechDBHelper.GetInspectionResults(ShiftStart, ShiftEnd);
            if (insp == null) return 0;

           int count = insp.Count();
            return count;
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            formShift = new FormShift();
            formShift.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Machine.ShowErrorInfoDlg("Error occured. : " , true, this);

        }
        
        public Car ReadCarTypeFromPLC()
        {
            int modelIdx = 0;
            int engineIdx = 0;
            int[] carOptionPLCArray = null;
            int[] modelIdxs = Machine.carManager.GetCarModelIndexList();
            int[] engineIdxs = Machine.carManager.GetCarOptEngIndexList(Inspection.MotorCar.eCarOptEngType.Engine);
            int[] optionIdxs = Machine.carManager.GetCarOptEngIndexList(Inspection.MotorCar.eCarOptEngType.Option);

            Car currentCar = null;
            int readCount = 3;
            for (int i = 0; i < readCount; i++)
            {
                Machine.plc.ReadCarTypeIdx(ref modelIdxs, ref engineIdxs, ref optionIdxs, out modelIdx, out engineIdx, out carOptionPLCArray);
                //Load Recipe
                Car car = Machine.carManager.GetCarByIdx(modelIdx, engineIdx, carOptionPLCArray);
                if (modelIdx == -1 || engineIdx == -1) // Should not Model idx == -1
                {
                    currentCar = null;
                }
                if (car != null)
                {
                    currentCar = car;
                    break;
                }
                System.Threading.Thread.Sleep(500);
            }

            return currentCar;
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            Car car = ReadCarTypeFromPLC();
            string carName = car.GetCarFullName();
        }
    }
}
