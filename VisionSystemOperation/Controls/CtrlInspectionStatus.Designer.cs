
namespace VisionSystemOperation.Controls
{
    partial class CtrlInspectionStatus
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
            this.pnlOK = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOK = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblNG = new System.Windows.Forms.Label();
            this.pnlNG = new System.Windows.Forms.Panel();
            this.pnlOK.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlNG.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOK
            // 
            this.pnlOK.BackColor = System.Drawing.Color.LightGreen;
            this.pnlOK.Controls.Add(this.panel2);
            this.pnlOK.Location = new System.Drawing.Point(0, 0);
            this.pnlOK.Name = "pnlOK";
            this.pnlOK.Padding = new System.Windows.Forms.Padding(4);
            this.pnlOK.Size = new System.Drawing.Size(85, 50);
            this.pnlOK.TabIndex = 9;
            this.pnlOK.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(77, 42);
            this.panel2.TabIndex = 6;
            // 
            // lblOK
            // 
            this.lblOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOK.ForeColor = System.Drawing.Color.LightGreen;
            this.lblOK.Location = new System.Drawing.Point(2, 2);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(73, 38);
            this.lblOK.TabIndex = 10;
            this.lblOK.Text = "OK";
            this.lblOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.lblNG);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2);
            this.panel4.Size = new System.Drawing.Size(77, 42);
            this.panel4.TabIndex = 6;
            // 
            // lblNG
            // 
            this.lblNG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNG.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNG.ForeColor = System.Drawing.Color.Red;
            this.lblNG.Location = new System.Drawing.Point(2, 2);
            this.lblNG.Name = "lblNG";
            this.lblNG.Size = new System.Drawing.Size(73, 38);
            this.lblNG.TabIndex = 10;
            this.lblNG.Text = "NG";
            this.lblNG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlNG
            // 
            this.pnlNG.BackColor = System.Drawing.Color.Red;
            this.pnlNG.Controls.Add(this.panel4);
            this.pnlNG.Location = new System.Drawing.Point(0, 63);
            this.pnlNG.Name = "pnlNG";
            this.pnlNG.Padding = new System.Windows.Forms.Padding(4);
            this.pnlNG.Size = new System.Drawing.Size(85, 50);
            this.pnlNG.TabIndex = 10;
            this.pnlNG.Visible = false;
            // 
            // CtrlInspectionStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNG);
            this.Controls.Add(this.pnlOK);
            this.Name = "CtrlInspectionStatus";
            this.Size = new System.Drawing.Size(86, 120);
            this.pnlOK.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlNG.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblOK;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblNG;
        private System.Windows.Forms.Panel pnlNG;
    }
}
