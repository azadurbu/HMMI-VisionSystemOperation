
namespace VisionSystemOperation.Controls
{
    partial class CtrlCameraPlc
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picPLCStatus = new System.Windows.Forms.PictureBox();
            this.picCameraStatus = new System.Windows.Forms.PictureBox();
            this.picLightStatus = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPLCStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCameraStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLightStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(87, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "PLC";
            // 
            // picPLCStatus
            // 
            this.picPLCStatus.Image = global::VisionSystemOperation.Properties.Resources.circle_grey_icon;
            this.picPLCStatus.Location = new System.Drawing.Point(116, 5);
            this.picPLCStatus.Name = "picPLCStatus";
            this.picPLCStatus.Size = new System.Drawing.Size(16, 16);
            this.picPLCStatus.TabIndex = 3;
            this.picPLCStatus.TabStop = false;
            this.picPLCStatus.DoubleClick += new System.EventHandler(this.picPLCStatus_DoubleClick);
            // 
            // picCameraStatus
            // 
            this.picCameraStatus.Image = global::VisionSystemOperation.Properties.Resources.cycle_green_icon;
            this.picCameraStatus.Location = new System.Drawing.Point(48, 5);
            this.picCameraStatus.Name = "picCameraStatus";
            this.picCameraStatus.Size = new System.Drawing.Size(16, 16);
            this.picCameraStatus.TabIndex = 2;
            this.picCameraStatus.TabStop = false;
            this.picCameraStatus.Click += new System.EventHandler(this.picCameraStatus_Click);
            // 
            // picLightStatus
            // 
            this.picLightStatus.Image = global::VisionSystemOperation.Properties.Resources.circle_grey_icon;
            this.picLightStatus.Location = new System.Drawing.Point(191, 5);
            this.picLightStatus.Name = "picLightStatus";
            this.picLightStatus.Size = new System.Drawing.Size(16, 16);
            this.picLightStatus.TabIndex = 5;
            this.picLightStatus.TabStop = false;
            this.picLightStatus.Click += new System.EventHandler(this.picLightStatus_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(156, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Light";
            // 
            // CtrlCameraPlc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picLightStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picPLCStatus);
            this.Controls.Add(this.picCameraStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CtrlCameraPlc";
            this.Size = new System.Drawing.Size(218, 62);
            ((System.ComponentModel.ISupportInitialize)(this.picPLCStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCameraStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLightStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picCameraStatus;
        private System.Windows.Forms.PictureBox picPLCStatus;
        private System.Windows.Forms.PictureBox picLightStatus;
        private System.Windows.Forms.Label label3;
    }
}
