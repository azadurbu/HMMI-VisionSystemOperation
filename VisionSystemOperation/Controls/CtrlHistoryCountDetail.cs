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
    public partial class CtrlHistoryCountDetail : UserControl
    {
        public CtrlHistoryCountDetail()
        {
            InitializeComponent();
        }

        public void Counter(int val)
        {
            lblHistoryCount.Text = val.ToString();
        }
    }
}
