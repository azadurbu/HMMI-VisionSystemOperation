
namespace VisionSystemOperation.Controls
{
    partial class CtrlLogDisplay
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
            this.lbxLogMessage = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbxLogMessage
            // 
            this.lbxLogMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxLogMessage.FormattingEnabled = true;
            this.lbxLogMessage.HorizontalScrollbar = true;
            this.lbxLogMessage.ItemHeight = 15;
            this.lbxLogMessage.Location = new System.Drawing.Point(0, 0);
            this.lbxLogMessage.Margin = new System.Windows.Forms.Padding(0);
            this.lbxLogMessage.Name = "lbxLogMessage";
            this.lbxLogMessage.Size = new System.Drawing.Size(958, 62);
            this.lbxLogMessage.TabIndex = 1;
            // 
            // CtrlLogDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbxLogMessage);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CtrlLogDisplay";
            this.Size = new System.Drawing.Size(958, 62);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxLogMessage;
    }
}
