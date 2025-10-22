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

using VisionSystemOperation.Device;

namespace VisionSystemOperation.Controls
{
    public partial class CtrlLogDisplay : UserControl
    {
        public CtrlLogDisplay()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbxLogMessage.Items.Add(DateTime.Now.ToString());
            lbxLogMessage.SelectedIndex = lbxLogMessage.Items.Count - 1;
        }

        private delegate void AddLogDele(string message);
        internal void AddLog(string message)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    AddLogDele callBack = AddLog;
                    BeginInvoke(callBack, message);
                    return;
                }
                if (lbxLogMessage.Items.Count >= 200)
                    lbxLogMessage.Items.Clear();

                string content = "[ " + Machine.logger.GetTimeString() + " ] ";
                content += message;

                lbxLogMessage.Items.Add(content);
                lbxLogMessage.SelectedIndex = lbxLogMessage.Items.Count - 1;
            }
            catch (Exception err)
            {
                Machine.logger.WriteAsync(eLogType.ERROR, MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.ToString());
            }
        }
    }
}
