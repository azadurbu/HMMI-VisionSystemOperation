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
    public partial class CtrlCarTypeVin : UserControl
    {
        private delegate void ShowDisplayDele(string carType, string vinID);
        public CtrlCarTypeVin()
        {
            InitializeComponent();
        }

        public void CarTypeVinIDDisplay(string carType, string vinID)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    ShowDisplayDele callBack = CarTypeVinIDDisplay;
                    BeginInvoke(callBack, carType, vinID);      // 221019 메인에서 CAM 이미지 크게 보기
                    return;
                }

                this.lblCarType.Text = carType;
                this.lblVinNo.Text = vinID;
            }
            catch (Exception)
            {
            }
        }
    }
}
