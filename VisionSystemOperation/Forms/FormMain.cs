using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VisionSystemOperation.Device;
using VisionSystemOperation.Controls;
using System.Reflection;
using VisionSystemOperation.Inspection;
using Cognex.VisionPro;

namespace VisionSystemOperation.Forms
{
    public partial class FormMain : Form
    {

        private CtrlCameraView ctrlCameraView = null;
        private List<CtrlCameraView> CtrlCameraViews = new List<CtrlCameraView>();
        private CtrlHistoryCountDetail ctrlHistoryCountDetail = null;
        private CtrlLogDisplay ctrlLogDisplay = null;
        private CtrlInspectionStatus ctrlInspectionStatus = null;
        private List<CtrlInspectionStatus> ctrlInspectionStatuses = new List<CtrlInspectionStatus>();

        public FormMain()
        {
            InitializeComponent();
            AddControls();

            tmWritePLCHeartBit.Start();
        }

        private void AddControls()
        {
            try
            {
                //ctrlCameraView = new CtrlCameraView();
                //flowPnlCameraView.Controls.Add(ctrlCameraView);
                //ctrlCameraView.Dock = DockStyle.Fill;

                var camCount = Machine.config.setup.maxCamCount;

                List<Device.Camera.CameraProperty> cameraProperties = Machine.config.setup.cameraProp;
                int usingCam = 0;
                for (int i = 0; i < camCount; i++)
                {
                    if (cameraProperties[i].Using == "Yes")
                        usingCam++;
                }

                var width = flowPnlCameraView.Width / usingCam;
                flowPnlCameraView.Controls.Clear();


                var spaceBetween = 0;
                for (int i = 0; i < camCount; i++)
                {
                    if (cameraProperties[i].Using == "Yes")
                    {
                        CtrlCameraView ctrlCameraView = new CtrlCameraView();
                        ctrlCameraView.Tag = i;
                        ctrlCameraView.Width = width - 8;
                        flowPnlCameraView.Controls.Add(ctrlCameraView);
                        CtrlCameraViews.Add(ctrlCameraView);

                        ctrlInspectionStatus = new CtrlInspectionStatus();
                        pnlInspStatus.Controls.Add(ctrlInspectionStatus);

                        spaceBetween = pnlInspStatus.Width / (usingCam + 1);
                        ctrlInspectionStatus.Left = i * spaceBetween;
                        //(i * spaceBetween) + (spaceBetween / 2) - (ctrlInspectionStatus.Width / 2);

                        ctrlInspectionStatuses.Add(ctrlInspectionStatus);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check to Camera parameter using or no using");
            }
           
        }

        public void InitializeUI()
        {
            for (int i = 0; i < CtrlCameraViews.Count; i++)
            {
                CtrlCameraViews[i].InitializeUI();
            }
            ctrlInspectionStatus.InitializeUI();
        }

        //jskim 20250408 check using Camera s
        public void UpdateUI(int camIdx, Bitmap bmp, ResultConstants isOK, CogGraphicInteractiveCollection cogGraphic)
        {
            try
            {
                int _camIdx = camIdx;
                if (CtrlCameraViews.Count <= camIdx)
                    _camIdx = CtrlCameraViews.Count - 1; 

                if (isOK == ResultConstants.OK)
                    CtrlCameraViews[_camIdx].UpdateDisplay(bmp, 1, true, cogGraphic);
                else
                    CtrlCameraViews[_camIdx].UpdateDisplay(bmp, 1, false, cogGraphic);
                if (isOK == ResultConstants.OK)
                    ctrlInspectionStatuses[_camIdx].UpdateUI(true);
                else
                    ctrlInspectionStatuses[_camIdx].UpdateUI(false);

                GC.Collect();
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                Machine.logger.WriteAsync(eLogType.ERROR, MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.ToString());
            }
        }
        //jskim 20250408 check using Camera e

        //jskim 20250408 check using Camera s
        internal void SaveDisplayImages(string imagePath, string fileName)
        {
            try
            {
                List<Device.Camera.CameraProperty> cameraProperties = Machine.config.setup.cameraProp;
                for (int camIdx = 0; camIdx < cameraProperties.Count; camIdx++)
                {
                    if (@cameraProperties[camIdx].Using == "No") continue;

                    int dpNum = camIdx;
                    if (CtrlCameraViews.Count <= dpNum)
                        dpNum = CtrlCameraViews.Count - 1;

                    CtrlCameraViews[dpNum].SaveDisplayImage(imagePath, fileName + $"_{camIdx}");

                }
                //for (int i = 0; i < CtrlCameraViews.Count; i++)
                //{
                //    CtrlCameraViews[i].SaveDisplayImage(imagePath, fileName + $"_{i}");
                //}
                GC.Collect();
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                Machine.logger.WriteAsync(eLogType.ERROR, MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.ToString());
            }
            //try
            //{
            //    for (int i = 0; i < CtrlCameraViews.Count; i++)
            //    {
            //        CtrlCameraViews[i].SaveDisplayImage(imagePath, fileName + $"_{i}");
            //    }
            //    GC.Collect();
            //}
            //catch (Exception err)
            //{
            //    Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            //    Machine.logger.WriteAsync(eLogType.ERROR, MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.ToString());
            //}
        }
        //jskim 20250408 check using Camera e

        private void tmWritePLCHeartBit_Tick(object sender, EventArgs e)
        {
            if (Machine.plc == null) return;

            if(Machine.plc.IsConnected())
            {
                Machine.plc.WriteHeartBit();
            }
        }
    }
}
