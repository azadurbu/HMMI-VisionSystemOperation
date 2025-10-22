using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms;
using System.Diagnostics;

using VisionSystemOperation.Device;
using VisionSystemOperation.Forms;
using VisionSystemOperation.Inspection;
using VisionSystemOperation.Device.Camera;
using VisionSystemOperation.Device.Light;
using VisionSystemOperation.Device.PLC_Library;

namespace VisionSystemOperation.Forms
{
    public partial class FormErrorInfomation : Form
    {
        private FormMdi formMdi;
        FormInterface Interface { get; set; } = null;
        public FormErrorInfomation(FormMdi _formMdi)
        {
            InitializeComponent();
            formMdi = _formMdi;
        }
        public void SetMessage(string msg, bool isViewBtn)
        {
            rtbErrInfoMsg.Clear();
            rtbErrInfoMsg.Text = msg;

            Machine.logger.WriteAsync(eLogType.ERROR, "Show Error Message. :" + msg);
        }

        private void btnShowAreaInspForm_Click(object sender, EventArgs e)
        {
            try
            {
                formMdi.ShowInterface();
                formMdi.CtrlButton.Stop();
                this.Close();

                //if (Interface == null)
                //    Interface = new FormInterface();
                //Interface.MdiParent = this;
                //Interface.WindowState = FormWindowState.Maximized;
                //Interface.Show();
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(1);

                MessageBox.Show(sf.GetMethod().Name + " " + ex.Message);
            }
        }

        private void RulebaseDlgClosed(object sender, FormClosedEventArgs e)
        {
            //   string path = "";
            //    Machine.m_rulebaseInspManager.LoadInspFilterData(path);
            //    Machine.m_rulebaseInspManager.SettingInspectionFilter();
        }

        private void SelectByPassOrInspStart()
        {
            DialogResult dialogResult = MessageBox.Show("Use Vision Pass mode?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
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
                formMdi.CtrlButton.EnableButton(VisionSystemOperation.Controls.eProgramMode.ByPass);
            }
            else
            {
                Machine.plc.IsVisionSeqRecvData[(int)eVision2PLCSeq.VISION_PASS] = false;
                Machine.sequence.IsSeqData[(int)eVision2PLCSeq.VISION_PASS] = false;
                if (!Machine.plc.WriteVistion2PLCSeq(Machine.sequence.IsSeqData, 16)) //1Word = 2byte = 16bit
                {
                    if (Machine.plc.ERR_MSG != "")
                        Machine.logger.WriteAsync(eLogType.ERROR, "Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString());

                    MessageBox.Show("Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString());
                    return;
                }

                formMdi.CtrlButton.EnableButton(VisionSystemOperation.Controls.eProgramMode.Inspection);
            }
        }

        private void btnCamInitialize_Click(object sender, EventArgs e)
        {
            try
            {
                Machine.config.LoadConfig();
                eCameraStatus status = Machine.camManager.Initialize(Machine.config.setup.cameraProp, Machine.config.setup.maxCamCount);

                if (status != eCameraStatus.CAM_CONNECTION_SUCCESS)
                {
                    Machine.logger.WriteAsync(eLogType.ERROR, status.ToString());
                    MessageBox.Show("Cam Initialize Error. " + status.ToString());
                    return;
                }

                string str = "";
                for (int camNo = 0; camNo < Machine.camManager._cameraList.Count; camNo++)
                {
                    if (!Machine.camManager._cameraList[camNo].IsOpen())
                    {
                        str += "#" + (camNo + 1) + " Camera" + "\n";
                    }
                }
                if (str != "")//jskim 20210621
                {
                    string msg = "Fail Connected.\n" + str;
                    SetMessage(msg, true);
                    return;
                }

                Machine.logger.WriteAsync(eLogType.CAMERA, "Cam Initialize Success");

                //Machine.mMainForm.updateStatusUI();

                Machine.logger.WriteAsync(eLogType.CAMERA, "Cam Initialize Sequence Complete");

                SelectByPassOrInspStart();
                Machine.sequence.StartSequence(eSeqStep.SEQ_START);
                TowerLampManager.StartLampOn();

                this.Close();
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(1);

                MessageBox.Show(sf.GetMethod().Name + " " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPLCInitialize_Click(object sender, EventArgs e)
        {
            Machine.plc.Load();
            if(!Machine.plc.Connect())
            {
                string msg = "Fail PLC Connected.\n";
                SetMessage(msg, true);
                return;
            }
            Machine.logger.WriteAsync(eLogType.DIO, "PLC Initialize Success");

            Machine.plc.InitStatusFlagData();
            Machine.logger.WriteAsync(eLogType.DIO, "PLC Initialize Sequence Complete");

            SelectByPassOrInspStart();
            Machine.sequence.StartSequence(eSeqStep.SEQ_START);
            TowerLampManager.StartLampOn();

            this.Close();
        }

        private void btnLightInitialize_Click(object sender, EventArgs e)
        {
            bool r = Machine.lightmodule.Connect(Machine.lightmodule.str_ip, Machine.lightmodule.iport);
            if(!r)
            {
                string msg = "Fail Light Connected.\n";
                SetMessage(msg, true);
                return;
            }
            Machine.logger.WriteAsync(eLogType.LIGHT, "Light Initialize Success");

            SelectByPassOrInspStart();
            Machine.sequence.StartSequence(eSeqStep.SEQ_START);
            TowerLampManager.StartLampOn();

            this.Close();
        }

        private void btnStartInspSeq_Click(object sender, EventArgs e)
        {
            Machine.logger.WriteAsync(eLogType.SEQ, "Click Start Insp Seq");

            SelectByPassOrInspStart();

            Machine.sequence.SeqStep = Device.PLC_Library.eSeqStep.SEQ_START_WAIT;
            Machine.sequence.StartSequence(eSeqStep.SEQ_START_INSP);
            TowerLampManager.StartLampOn();

            this.Close();
        }

        private void btnResultOK_Click(object sender, EventArgs e)
        {
            Machine.logger.WriteAsync(eLogType.SEQ, "Click Result OK Seq");

            Machine.sequence.IsSeqData[(int)eVision2PLCSeq.LAST_COMPL] = true;
            Machine.sequence.IsSeqData[(int)eVision2PLCSeq.VISION_NG] = false;
            Machine.sequence.IsSeqData[(int)eVision2PLCSeq.ERROR] = false;
            Machine.sequence.IsSeqData[(int)eVision2PLCSeq.VISION_END] = true;

            SelectByPassOrInspStart();

            Machine.sequence.StartSequence(eSeqStep.SEQ_SEND_RESULT);
            TowerLampManager.StartLampOn();

            this.Close();
        }

        private void btnResultNG_Click(object sender, EventArgs e)
        {
            Machine.logger.WriteAsync(eLogType.SEQ, "Click Result NG Seq");

            Machine.sequence.IsSeqData[(int)eVision2PLCSeq.VISION_NG] = true;
            Machine.sequence.IsSeqData[(int)eVision2PLCSeq.LAST_COMPL] = false;
            Machine.sequence.IsSeqData[(int)eVision2PLCSeq.ERROR] = false;
            Machine.sequence.IsSeqData[(int)eVision2PLCSeq.VISION_END] = true;

            SelectByPassOrInspStart();

            Machine.sequence.StartSequence(Device.PLC_Library.eSeqStep.SEQ_SEND_RESULT);
            TowerLampManager.StartLampOn();

            this.Close();
        }


        private void btnInitSequnce_Click(object sender, EventArgs e)
        {
            Machine.logger.WriteAsync(eLogType.SEQ, "Click Initialize Seq");

            SelectByPassOrInspStart();

            Machine.sequence.StartSequence(Device.PLC_Library.eSeqStep.SEQ_START_WAIT);
            TowerLampManager.StartLampOn();

            this.Close();
        }

        private void FormErrorInfomation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Interface = null;
        }
    }
}
