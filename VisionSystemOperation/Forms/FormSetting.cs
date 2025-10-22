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
    public partial class FormSetting : Form
    {
        private FormMdi formMdi;
        public FormSetting(FormMdi _formMdi)
        {
            formMdi = _formMdi;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            Machine.sequence = new Sequence(formMdi);
        }

        public void SetImg(string imagePath)
        {
            Image img = Image.FromFile(imagePath);
            pbxCapturedImg.Image = img;
        }
    }
}
