
namespace VisionSystemOperation.Controls
{
    partial class CtrlMenu
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
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnDB = new System.Windows.Forms.Button();
            this.btnInterface = new System.Windows.Forms.Button();
            this.btnCamera = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSetting
            // 
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Image = global::VisionSystemOperation.Properties.Resources.setting_icon;
            this.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.Location = new System.Drawing.Point(428, 0);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(85, 43);
            this.btnSetting.TabIndex = 5;
            this.btnSetting.Text = "Setting";
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSetting.UseVisualStyleBackColor = true;
            // 
            // btnLog
            // 
            this.btnLog.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnLog.FlatAppearance.BorderSize = 0;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Image = global::VisionSystemOperation.Properties.Resources.log_icon;
            this.btnLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLog.Location = new System.Drawing.Point(359, 0);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(63, 43);
            this.btnLog.TabIndex = 4;
            this.btnLog.Text = "Log";
            this.btnLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLog.UseVisualStyleBackColor = true;
            // 
            // btnDB
            // 
            this.btnDB.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnDB.FlatAppearance.BorderSize = 0;
            this.btnDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDB.Image = global::VisionSystemOperation.Properties.Resources.database_icon;
            this.btnDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDB.Location = new System.Drawing.Point(292, 0);
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(61, 43);
            this.btnDB.TabIndex = 3;
            this.btnDB.Text = "DB";
            this.btnDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDB.UseVisualStyleBackColor = true;
            // 
            // btnInterface
            // 
            this.btnInterface.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnInterface.FlatAppearance.BorderSize = 0;
            this.btnInterface.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInterface.Image = global::VisionSystemOperation.Properties.Resources.icon_interface_28;
            this.btnInterface.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInterface.Location = new System.Drawing.Point(189, 0);
            this.btnInterface.Name = "btnInterface";
            this.btnInterface.Size = new System.Drawing.Size(97, 43);
            this.btnInterface.TabIndex = 2;
            this.btnInterface.Text = "Interface";
            this.btnInterface.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInterface.UseVisualStyleBackColor = true;
            // 
            // btnCamera
            // 
            this.btnCamera.FlatAppearance.BorderSize = 0;
            this.btnCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCamera.Image = global::VisionSystemOperation.Properties.Resources.camera_icon;
            this.btnCamera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCamera.Location = new System.Drawing.Point(88, 0);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(95, 43);
            this.btnCamera.TabIndex = 1;
            this.btnCamera.Text = "Camera";
            this.btnCamera.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCamera.UseVisualStyleBackColor = true;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // btnMain
            // 
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Image = global::VisionSystemOperation.Properties.Resources.monitor_icon;
            this.btnMain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMain.Location = new System.Drawing.Point(3, 0);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(79, 43);
            this.btnMain.TabIndex = 0;
            this.btnMain.Text = "Main";
            this.btnMain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // CtrlMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnDB);
            this.Controls.Add(this.btnInterface);
            this.Controls.Add(this.btnCamera);
            this.Controls.Add(this.btnMain);
            this.Name = "CtrlMenu";
            this.Size = new System.Drawing.Size(532, 42);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Button btnInterface;
        private System.Windows.Forms.Button btnDB;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnSetting;
    }
}
