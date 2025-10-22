using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlignCheck.MasterImage.Utility
{
    public delegate void ObjectNameInputEventHandler(string name);

    public partial class ObjectNameDlg : Form
    {
        public ObjectNameInputEventHandler changeNameEvent;

        public ObjectNameDlg()
        {
            InitializeComponent();
        }

        private void btSaveName_Click(object sender, EventArgs e)
        {
            changeNameEvent(tbName.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}