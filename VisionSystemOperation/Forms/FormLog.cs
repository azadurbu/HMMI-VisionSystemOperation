using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionSystemOperation.Class;
using VisionSystemOperation.Device;

namespace VisionSystemOperation.Forms
{
    public partial class FormLog : Form
    {
        List<LoggerUI> logs = null;

        private List<eLogType> checkBoxType = new List<eLogType>();
        public FormLog()
        {
            InitializeComponent();
            checkBoxType.Add(eLogType.ALL);
            dataGridLogData.DataSource = Machine.logger.LoadLogs(checkBoxType, null, null);
            dateTimeSearchFrom.Value = Machine.startDate;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridLogData.DataSource = Machine.logger.LoadLogs(checkBoxType, dateTimeSearchFrom.Value, dateTimeSearchTo.Value);
        }

        private void cbxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAll.Checked)
            {
                cbxAll.Checked = true;
                checkBoxType.Clear();
                checkBoxType.Add(eLogType.ALL);
                dataGridLogData.DataSource = Machine.logger.LoadLogs(checkBoxType, dateTimeSearchFrom.Value, dateTimeSearchTo.Value);
            }
        }

        private void cbxInsp_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxType.Remove(eLogType.INSPECTION);
            if (cbxInsp.Checked)
            {
                cbxAll.Checked = false;
                cbxInsp.Checked = true;
                checkBoxType.Add(eLogType.INSPECTION);
                checkBoxType.Remove(eLogType.ALL);
                dataGridLogData.DataSource = Machine.logger.LoadLogs(checkBoxType, dateTimeSearchFrom.Value, dateTimeSearchTo.Value);
            }
            else if (!cbxInsp.Checked && !cbxCam.Checked && !cbxLight.Checked && !cbxDio.Checked && !cbxSeq.Checked && !cbxInfo.Checked && !cbxError.Checked && !cbxResult.Checked)
            {
                cbxAll.Checked = true;
            }
        }

        private void cbxCam_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxType.Remove(eLogType.CAMERA);
            if (cbxCam.Checked)
            {
                cbxAll.Checked = false;
                cbxCam.Checked = true;
                checkBoxType.Add(eLogType.CAMERA);
                checkBoxType.Remove(eLogType.ALL);
                dataGridLogData.DataSource = Machine.logger.LoadLogs(checkBoxType, dateTimeSearchFrom.Value, dateTimeSearchTo.Value);
            }
            else if (!cbxInsp.Checked && !cbxCam.Checked && !cbxLight.Checked && !cbxDio.Checked && !cbxSeq.Checked && !cbxInfo.Checked && !cbxError.Checked && !cbxResult.Checked)
            {
                cbxAll.Checked = true;
            }
        }

        private void cbxLight_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxType.Remove(eLogType.LIGHT);
            if (cbxLight.Checked)
            {
                cbxAll.Checked = false;
                cbxLight.Checked = true;
                checkBoxType.Add(eLogType.LIGHT);
                checkBoxType.Remove(eLogType.ALL);
                dataGridLogData.DataSource = Machine.logger.LoadLogs(checkBoxType, dateTimeSearchFrom.Value, dateTimeSearchTo.Value);
            }
            else if (!cbxInsp.Checked && !cbxCam.Checked && !cbxLight.Checked && !cbxDio.Checked && !cbxSeq.Checked && !cbxInfo.Checked && !cbxError.Checked && !cbxResult.Checked)
            {
                cbxAll.Checked = true;
            }
        }

        private void cbxDio_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxType.Remove(eLogType.DIO);
            if (cbxDio.Checked)
            {
                cbxAll.Checked = false;
                cbxDio.Checked = true;
                checkBoxType.Add(eLogType.DIO);
                checkBoxType.Remove(eLogType.ALL);
                dataGridLogData.DataSource = Machine.logger.LoadLogs(checkBoxType, dateTimeSearchFrom.Value, dateTimeSearchTo.Value);
            }
            else if (!cbxInsp.Checked && !cbxCam.Checked && !cbxLight.Checked && !cbxDio.Checked && !cbxSeq.Checked && !cbxInfo.Checked && !cbxError.Checked && !cbxResult.Checked)
            {
                cbxAll.Checked = true;
            }
        }

        private void cbxSeq_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxType.Remove(eLogType.SEQ);
            if (cbxSeq.Checked)
            {
                cbxAll.Checked = false;
                cbxSeq.Checked = true;
                checkBoxType.Add(eLogType.SEQ);
                checkBoxType.Remove(eLogType.ALL);
                dataGridLogData.DataSource = Machine.logger.LoadLogs(checkBoxType, dateTimeSearchFrom.Value, dateTimeSearchTo.Value);
            }
            else if (!cbxInsp.Checked && !cbxCam.Checked && !cbxLight.Checked && !cbxDio.Checked && !cbxSeq.Checked && !cbxInfo.Checked && !cbxError.Checked && !cbxResult.Checked)
            {
                cbxAll.Checked = true;
            }
        }

        private void cbxInfo_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxType.Remove(eLogType.INFORMATION);
            if (cbxInfo.Checked)
            {
                cbxAll.Checked = false;
                cbxInfo.Checked = true;
                checkBoxType.Add(eLogType.INFORMATION);
                checkBoxType.Remove(eLogType.ALL);
                dataGridLogData.DataSource = Machine.logger.LoadLogs(checkBoxType, dateTimeSearchFrom.Value, dateTimeSearchTo.Value);
            }
            else if (!cbxInsp.Checked && !cbxCam.Checked && !cbxLight.Checked && !cbxDio.Checked && !cbxSeq.Checked && !cbxInfo.Checked && !cbxError.Checked && !cbxResult.Checked)
            {
                cbxAll.Checked = true;
            }
        }

        private void cbxError_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxType.Remove(eLogType.ERROR);
            if (cbxError.Checked)
            {
                cbxAll.Checked = false;
                cbxError.Checked = true;
                checkBoxType.Add(eLogType.ERROR);
                checkBoxType.Remove(eLogType.ALL);
                dataGridLogData.DataSource = Machine.logger.LoadLogs(checkBoxType, dateTimeSearchFrom.Value, dateTimeSearchTo.Value);
            }
            else if (!cbxInsp.Checked && !cbxCam.Checked && !cbxLight.Checked && !cbxDio.Checked && !cbxSeq.Checked && !cbxInfo.Checked && !cbxError.Checked && !cbxResult.Checked)
            {
                cbxAll.Checked = true;
            }
        }

        private void cbxResult_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxType.Remove(eLogType.RESULT);
            if (cbxResult.Checked)
            {
                cbxAll.Checked = false;
                cbxResult.Checked = true;
                checkBoxType.Add(eLogType.RESULT);
                checkBoxType.Remove(eLogType.ALL);
                dataGridLogData.DataSource = Machine.logger.LoadLogs(checkBoxType, dateTimeSearchFrom.Value, dateTimeSearchTo.Value);
            }
            else if (!cbxInsp.Checked && !cbxCam.Checked && !cbxLight.Checked && !cbxDio.Checked && !cbxSeq.Checked && !cbxInfo.Checked && !cbxError.Checked && !cbxResult.Checked)
            {
                cbxAll.Checked = true;
            }
        }

        private void HookMouseMoveEvents(Control parent)
        {
            parent.MouseMove += ChildForm_MouseMove;
            foreach (Control ctrl in parent.Controls)
            {
                HookMouseMoveEvents(ctrl); // recursive
            }
        }

        private void ChildForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.MdiParent is FormMdi mdiParent)
            {
                mdiParent.ResetInactivityTimer();
            }
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            HookMouseMoveEvents(this);
        }
    }
}
