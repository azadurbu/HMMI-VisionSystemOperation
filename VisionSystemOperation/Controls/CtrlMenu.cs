using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionSystemOperation.Forms;

namespace VisionSystemOperation.Controls
{
    public partial class CtrlMenu : UserControl
    {
        private Forms.FormMain formMainWindow = null;
        private Forms.FormCamera formCamera = null;
        FormMdi parentForm = null;
        public CtrlMenu()
        {
            InitializeComponent();
            parentForm = this.Parent as FormMdi;
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            formMainWindow = new Forms.FormMain();
            formMainWindow.MdiParent = parentForm;
            formMainWindow.WindowState = FormWindowState.Maximized;
            formMainWindow.Show();
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            formCamera = new Forms.FormCamera();
            formCamera.MdiParent = parentForm;
            formCamera.WindowState = FormWindowState.Maximized;
            formCamera.Show();
        }
    }
}
