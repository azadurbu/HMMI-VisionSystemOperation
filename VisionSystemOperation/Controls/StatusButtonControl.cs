using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionSystemOperation.Controls
{
    public enum ProcessStage
    {
        WAITING,
        WORKING,
        SUCCESS,
        ERROR
    }

    public partial class StatusButtonControl : UserControl
    {
        public StatusButtonControl()
        {
            InitializeComponent();
            SetProcessStage(ProcessStage.WAITING);
        }

        public string Title { get { return lblTitle.Text; } set { lblTitle.Text = value; } }
        public void SetTitle(string title)
        {
            lblTitle.Text = title;
        }


        public void SetProcessStage(ProcessStage stage)
        {
            switch (stage)
            {
                case ProcessStage.WORKING:
                    lblTitle.BackColor = Color.LightSkyBlue;
                    lblTitle.ForeColor = Color.Black;
                    
                    break;
                case ProcessStage.WAITING:
                    lblTitle.BackColor = Color.Bisque;
                    lblTitle.ForeColor = Color.Black;
                    break;
                case ProcessStage.SUCCESS:
                    lblTitle.BackColor = Color.DarkSeaGreen;
                    lblTitle.ForeColor = Color.Black;
                    break;
                case ProcessStage.ERROR:
                    lblTitle.BackColor = Color.Crimson;
                    lblTitle.ForeColor = Color.White;
                    break;
            }
            //progressBar.Visible = stage == ProcessStage.WORKING;
            //this.Invalidate();
        }
        public event EventHandler<EventArgs> OnDoubleClickEvent;

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClickEvent?.Invoke(this, e);
        }
    }
}
