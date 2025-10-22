namespace VisionSystemOperation.MasterImage.UIForm
{
    partial class frmToolPMAlign
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
            this.cogPMAlignEditV21 = new Cognex.VisionPro.PMAlign.CogPMAlignEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogPMAlignEditV21)).BeginInit();
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
            this.ui_lb_vppFilename.Size = new System.Drawing.Size(892, 30);
            this.ui_lb_vppFilename.TabIndex = 263;
            this.ui_lb_vppFilename.Text = "Selected FileName";
            this.ui_lb_vppFilename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cogPMAlignEditV21
            // 
            this.cogPMAlignEditV21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogPMAlignEditV21.Location = new System.Drawing.Point(0, 30);
            this.cogPMAlignEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogPMAlignEditV21.Name = "cogPMAlignEditV21";
            this.cogPMAlignEditV21.Size = new System.Drawing.Size(892, 522);
            this.cogPMAlignEditV21.SuspendElectricRuns = false;
            this.cogPMAlignEditV21.TabIndex = 264;
            // 
            // frmToolPMAlign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 552);
            this.Controls.Add(this.cogPMAlignEditV21);
            this.Controls.Add(this.ui_lb_vppFilename);
            this.Name = "frmToolPMAlign";
            this.Text = "frmToolPMAlign";
            ((System.ComponentModel.ISupportInitialize)(this.cogPMAlignEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label ui_lb_vppFilename;
        private Cognex.VisionPro.PMAlign.CogPMAlignEditV2 cogPMAlignEditV21;
    }
}