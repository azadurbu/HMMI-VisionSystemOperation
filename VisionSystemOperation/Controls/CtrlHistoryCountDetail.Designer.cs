
namespace VisionSystemOperation.Controls
{
    partial class CtrlHistoryCountDetail
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
            this.lblHistoryCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Count: ";
            // 
            // lblHistoryCount
            // 
            this.lblHistoryCount.AutoSize = true;
            this.lblHistoryCount.Location = new System.Drawing.Point(48, 0);
            this.lblHistoryCount.Name = "lblHistoryCount";
            this.lblHistoryCount.Size = new System.Drawing.Size(17, 12);
            this.lblHistoryCount.TabIndex = 4;
            this.lblHistoryCount.Text = "00";
            // 
            // CtrlHistoryCountDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblHistoryCount);
            this.Controls.Add(this.label1);
            this.Name = "CtrlHistoryCountDetail";
            this.Size = new System.Drawing.Size(1980, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHistoryCount;
    }
}
