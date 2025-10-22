using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cognex.VisionPro.PMAlign;

namespace MasterImage.UIForm
{
    public partial class FormToolPMAlign : Form
    {
        public CogPMAlignEditV2 cogPMAlignEdit { get { return this.cogPMAlignEditV21; } }

        public FormToolPMAlign()
        {
            InitializeComponent();
        }

        private void frmToolAlign_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("작업한 내용을 저장하시겠습니까?", "저장", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
