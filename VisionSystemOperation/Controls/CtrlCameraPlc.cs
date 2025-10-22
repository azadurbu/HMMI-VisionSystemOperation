using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionSystemOperation.Controls
{
    public partial class CtrlCameraPlc : UserControl
    {
        public CtrlCameraPlc()
        {
            InitializeComponent();
        }

        public void CameraStatus(bool b)
        {
            picCameraStatus.Image = b ? StatusImage(true) : StatusImage(false);
        }

        public void PLCStatus(bool b)
        {
            picPLCStatus.Image = b ? StatusImage(true) : StatusImage(false);
        }

        public void LightStatus(bool b)
        {
            picLightStatus.Image = b ? StatusImage(true) : StatusImage(false);
        }

        private Bitmap StatusImage(bool b)
        {
            if (b)
                return VisionSystemOperation.Properties.Resources.cycle_green_icon;
            else
                return VisionSystemOperation.Properties.Resources.circle_grey_icon;
        }

        private void picPLCStatus_DoubleClick(object sender, EventArgs e)
        {
            int i = 0;
        }

        private void picCameraStatus_Click(object sender, EventArgs e)
        {
            int i = 0;
        }

        private void picLightStatus_Click(object sender, EventArgs e)
        {
            int i = 0;
        }
    }
}
