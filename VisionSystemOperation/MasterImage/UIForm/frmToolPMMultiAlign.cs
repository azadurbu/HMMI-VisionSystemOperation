using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cognex.VisionPro.PMAlign;

namespace VisionSystemOperation.MasterImage.UIForm
{
    public partial class FormToolPMMultiAlign : Form
    {
        public CogPMAlignMultiEditV2 cogPMAlignEdit { get { return this.cogPMAlignMultiEditV21; } }

        public FormToolPMMultiAlign()
        {
            InitializeComponent();
        }


        private void frmToolAlign_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Save your Patterns job?", "Save", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void cogPMAlignMultiEditV21_Load(object sender, EventArgs e)
        {
            this.cogPMAlignMultiEditV21.ChangeUICues += CogPMAlignMultiEditV21_ChangeUICues;
            this.cogPMAlignMultiEditV21.VisibleChanged += CogPMAlignMultiEditV21_VisibleChanged;
            this.cogPMAlignMultiEditV21.SubjectChanged += CogPMAlignMultiEditV21_SubjectChanged;
            this.cogPMAlignMultiEditV21.ShapeClick += CogPMAlignMultiEditV21_ShapeClick;
            this.cogPMAlignMultiEditV21.BindingContextChanged += CogPMAlignMultiEditV21_BindingContextChanged;
            this.cogPMAlignMultiEditV21.ContextMenuChanged += CogPMAlignMultiEditV21_ContextMenuChanged;
            this.cogPMAlignMultiEditV21.ControlAdded += CogPMAlignMultiEditV21_ControlAdded;
        }

        private void CogPMAlignMultiEditV21_ChangeUICues(object sender, UICuesEventArgs e)
        {
            int i = 0;
        }

        private void CogPMAlignMultiEditV21_VisibleChanged(object sender, EventArgs e)
        {
            int i = 0;
        }

        private void CogPMAlignMultiEditV21_SubjectChanged(object sender, EventArgs e)
        {
            int i = 0;
        }

        private void CogPMAlignMultiEditV21_ShapeClick(object sender, Cognex.VisionPro.CogShapeEventArgs e)
        {
            int i = 0;
        }

        private void CogPMAlignMultiEditV21_BindingContextChanged(object sender, EventArgs e)
        {
            int i = 0;
        }

        private void CogPMAlignMultiEditV21_ContextMenuChanged(object sender, EventArgs e)
        {
            int i = 0;
        }

        private void CogPMAlignMultiEditV21_ControlAdded(object sender, ControlEventArgs e)
        {
            int i = 0;
        }
    }
}
