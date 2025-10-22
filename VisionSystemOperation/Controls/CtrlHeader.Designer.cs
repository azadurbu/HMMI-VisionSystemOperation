
namespace VisionSystemOperation.Controls
{
    partial class CtrlHeader
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlHeader));
            this.pnlSoftareTitle = new System.Windows.Forms.Panel();
            this.labelSoftwareTitle = new System.Windows.Forms.Label();
            this.pnlMainMenu = new System.Windows.Forms.Panel();
            this.pictureBoxCompanyLogo = new System.Windows.Forms.PictureBox();
            this.pnlSoftareTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompanyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSoftareTitle
            // 
            this.pnlSoftareTitle.Controls.Add(this.labelSoftwareTitle);
            this.pnlSoftareTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSoftareTitle.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlSoftareTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlSoftareTitle.Name = "pnlSoftareTitle";
            this.pnlSoftareTitle.Size = new System.Drawing.Size(342, 44);
            this.pnlSoftareTitle.TabIndex = 0;
            // 
            // labelSoftwareTitle
            // 
            this.labelSoftwareTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSoftwareTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSoftwareTitle.Location = new System.Drawing.Point(0, 0);
            this.labelSoftwareTitle.Name = "labelSoftwareTitle";
            this.labelSoftwareTitle.Size = new System.Drawing.Size(342, 44);
            this.labelSoftwareTitle.TabIndex = 1;
            this.labelSoftwareTitle.Text = "CarBody OneShot Vision System";
            this.labelSoftwareTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMainMenu
            // 
            this.pnlMainMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMainMenu.Location = new System.Drawing.Point(1202, 0);
            this.pnlMainMenu.Name = "pnlMainMenu";
            this.pnlMainMenu.Size = new System.Drawing.Size(538, 44);
            this.pnlMainMenu.TabIndex = 1;
            // 
            // pictureBoxCompanyLogo
            // 
            this.pictureBoxCompanyLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCompanyLogo.Image = global::VisionSystemOperation.Properties.Resources.HyundaiLogo;
            this.pictureBoxCompanyLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxCompanyLogo.InitialImage")));
            this.pictureBoxCompanyLogo.Location = new System.Drawing.Point(342, 0);
            this.pictureBoxCompanyLogo.Name = "pictureBoxCompanyLogo";
            this.pictureBoxCompanyLogo.Size = new System.Drawing.Size(860, 44);
            this.pictureBoxCompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCompanyLogo.TabIndex = 2;
            this.pictureBoxCompanyLogo.TabStop = false;
            // 
            // CtrlHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxCompanyLogo);
            this.Controls.Add(this.pnlMainMenu);
            this.Controls.Add(this.pnlSoftareTitle);
            this.Name = "CtrlHeader";
            this.Size = new System.Drawing.Size(1740, 44);
            this.Load += new System.EventHandler(this.CtrlHeader_Load);
            this.pnlSoftareTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCompanyLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSoftareTitle;
        private System.Windows.Forms.Panel pnlMainMenu;
        private System.Windows.Forms.PictureBox pictureBoxCompanyLogo;
        private System.Windows.Forms.Label labelSoftwareTitle;
    }
}
