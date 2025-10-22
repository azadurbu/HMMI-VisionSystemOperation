namespace MasterImage.UIForm
{
    partial class FormToolPMMultiAlign
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ui_lb_vppFilename = new System.Windows.Forms.Label();
            this.cogPMAlignMultiEditV21 = new Cognex.VisionPro.PMAlign.CogPMAlignMultiEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogPMAlignMultiEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_lb_vppFilename
            // 
            this.ui_lb_vppFilename.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ui_lb_vppFilename.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ui_lb_vppFilename.Dock = System.Windows.Forms.DockStyle.Top;
            this.ui_lb_vppFilename.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lb_vppFilename.Location = new System.Drawing.Point(0, 0);
            this.ui_lb_vppFilename.Margin = new System.Windows.Forms.Padding(3);
            this.ui_lb_vppFilename.Name = "ui_lb_vppFilename";
            this.ui_lb_vppFilename.Size = new System.Drawing.Size(1022, 30);
            this.ui_lb_vppFilename.TabIndex = 261;
            this.ui_lb_vppFilename.Text = "Selected FileName";
            this.ui_lb_vppFilename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cogPMAlignMultiEditV21
            // 
            this.cogPMAlignMultiEditV21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogPMAlignMultiEditV21.Location = new System.Drawing.Point(0, 30);
            this.cogPMAlignMultiEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogPMAlignMultiEditV21.Name = "cogPMAlignMultiEditV21";
            this.cogPMAlignMultiEditV21.Size = new System.Drawing.Size(1022, 585);
            this.cogPMAlignMultiEditV21.SuspendElectricRuns = false;
            this.cogPMAlignMultiEditV21.TabIndex = 262;
            // 
            // frmToolAlign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 615);
            this.Controls.Add(this.cogPMAlignMultiEditV21);
            this.Controls.Add(this.ui_lb_vppFilename);
            this.Name = "frmToolAlign";
            this.Text = "Align Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmToolAlign_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.cogPMAlignMultiEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label ui_lb_vppFilename;
        private Cognex.VisionPro.PMAlign.CogPMAlignMultiEditV2 cogPMAlignMultiEditV21;
    }
}