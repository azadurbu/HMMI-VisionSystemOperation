using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionSystemOperation.Class;
using VisionSystemOperation.Device.Camera;
using VisionSystemOperation.Device.Light;
using VisionSystemOperation.Device.PLC_Library;
using VisionSystemOperation.Inspection.MotorCar;
using VisionSystemOperation.Inspection;
using VisionSystemOperation.Forms;
using System.Threading;
using System.Windows.Forms;

namespace VisionSystemOperation.Device
{
    public class Machine
    {
        public static LightControl lightmodule = null;
        public static Config config = null  ;
        public static CameraManager camManager = null;
        public static Logger logger = null;
        public static Sequence sequence = null;
        public static XGPLCManager plc = new XGPLCManager("", 0);
        public static CarManager carManager = null;
        public static InspectionManager inspManager = null;
        public static DateTime startDate;
        public static HanMechDBHelper HanMechDBHelper = null;

        private static FormErrorInfomation FormErrorInfomation = null;
        private static Thread formErrInfoThread = null;
        private static bool isFormErrInfoOpen = false;

        public static void Terminate()
        {
            camManager.Terminate();
        }

        public static void Initialize()
        {
            try
            {
                startDate = new DateTime(2024, 12, 02); //starting date of the software for log
                logger = new Logger();
                logger.Initialize();
                config = new Config();
                config.LoadConfig();

                lightmodule = new LightControl();
                lightmodule.Connect(lightmodule.str_ip, lightmodule.iport);
                lightmodule.SetPrimeryData();

                camManager = new CameraManager();
                camManager.Initialize(Machine.config.setup.cameraProp, config.setup.maxCamCount);

                carManager = new CarManager();
                carManager.LoadDB();

                plc = new XGPLCManager("", 0);
                plc.Load();
                plc.Connect();

                plc.InitStatusFlagData();

                inspManager = new InspectionManager(config.setup.maxCamCount);

                HanMechDBHelper = new HanMechDBHelper(config.setup.DBconnectionString);
                HanMechDBHelper.Connection();

            }
            catch (Exception ex)
            {
                string str = ex.ToString();
            }
        }
        public static void ShowErrorInfoDlg(string msg, bool viewBtn, FormMdi _formMdi)
        {
            if(isFormErrInfoOpen)
            {
                formErrInfoThread.Abort();
                formErrInfoThread = null;

            }
            FormErrorInfomation = new FormErrorInfomation(_formMdi);

            FormErrorInfomation.SetMessage(msg, viewBtn);
            FormErrorInfomation.FormClosed += FormErrorInfomation_FormClosed;
            isFormErrInfoOpen = true;

            Machine.logger.WriteAsync(eLogType.ERROR, "Show Error Information Dialog. " + msg);

            formErrInfoThread = new Thread(() => FormErrorInfomation.ShowDialog());
            formErrInfoThread.Start();
        }
        private static void FormErrorInfomation_FormClosed(object sender, FormClosedEventArgs e)
        {
            isFormErrInfoOpen = false;
            FormErrorInfomation.FormClosed -= FormErrorInfomation_FormClosed;
        }
    }
}
