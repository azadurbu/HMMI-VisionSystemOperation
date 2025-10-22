using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlignCheck.MasterImage.Utility.UserForm
{
    public partial class frmMeasureNG : Form
    {
        public frmMeasureNG()
        {
            InitializeComponent();
        }

        public void SetObjectDistance(List<string[]> _sizeResult, List<string[]> _objectDistanceResult)
        {
            List<string[]> newObjectDistanceResult = new List<string[]>();

            foreach(string[] item in _objectDistanceResult)
            {
                if (item[1] == "NG")
                    newObjectDistanceResult.Add(item);
            }

            dgvObjectDistanceResult.Rows.Clear();

            foreach(string[] item in newObjectDistanceResult)
            {
                dgvObjectDistanceResult.Rows.Add(item);
            }

            List<string[]> newsizeResult = new List<string[]>();

            foreach(string[] item in _sizeResult)
            {
                if (item[1] == "NG")
                    newsizeResult.Add(item);
            }

            dgvSizeMeasure.Rows.Clear();
            foreach(string[] item in newsizeResult)
            {
                dgvSizeMeasure.Rows.Add(item);
            }   
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
