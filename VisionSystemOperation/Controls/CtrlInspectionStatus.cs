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
    public partial class CtrlInspectionStatus : UserControl
    {
        public CtrlInspectionStatus()
        {
            InitializeComponent();
            InspStateOK();
        }

        private delegate void InitializeUIDele();
        private delegate void UpdateImageDele(bool IsOk);      // 221019 메인에서 CAM 이미지 크게 보기
        public void UpdateUI(bool isOK)
        {
            if (this.InvokeRequired)
            {
                UpdateImageDele callBack = UpdateUI;
                BeginInvoke(callBack, isOK);      // 221019 메인에서 CAM 이미지 크게 보기
                return;
            }

            if (isOK)
            {
                InspStateOK();
            }
            else
            {
                InspStateNG();
            }
        }
        public void InitializeUI()
        {
            if (this.InvokeRequired)
            {
                InitializeUIDele callBack = InitializeUI;
                BeginInvoke(callBack);      // 221019 메인에서 CAM 이미지 크게 보기
                return;
            }

            //lblOK.ForeColor = Color.Black;
            //lblNG.ForeColor = Color.Black;
        }

        public void InspStateOK()
        {
            pnlNG.Visible = false;
            pnlOK.Visible = true;
            pnlOK.Location = new Point(0, 0);
        }

        public void InspStateNG()
        {
            pnlOK.Visible = false;
            pnlNG.Visible = true;
            pnlNG.Location = new Point(0, 0);
        }
    }
}
