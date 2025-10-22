
namespace VisionSystemOperation.Forms
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.tblHistory = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHistoryCountDetails = new System.Windows.Forms.Panel();
            this.tabLayoutMaster = new System.Windows.Forms.TableLayoutPanel();
            this.flowPnlCameraView = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlInspStatus = new System.Windows.Forms.Panel();
            this.tmWritePLCHeartBit = new System.Windows.Forms.Timer(this.components);
            this.pnlHistory.SuspendLayout();
            this.tblHistory.SuspendLayout();
            this.tabLayoutMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHistory
            // 
            this.pnlHistory.Controls.Add(this.tblHistory);
            this.pnlHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHistory.Location = new System.Drawing.Point(5, 1015);
            this.pnlHistory.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(3552, 365);
            this.pnlHistory.TabIndex = 4;
            // 
            // tblHistory
            // 
            this.tblHistory.ColumnCount = 1;
            this.tblHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblHistory.Controls.Add(this.pnlHistoryCountDetails, 0, 0);
            this.tblHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblHistory.Location = new System.Drawing.Point(0, 0);
            this.tblHistory.Margin = new System.Windows.Forms.Padding(0);
            this.tblHistory.Name = "tblHistory";
            this.tblHistory.RowCount = 1;
            this.tblHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblHistory.Size = new System.Drawing.Size(3552, 365);
            this.tblHistory.TabIndex = 0;
            // 
            // pnlHistoryCountDetails
            // 
            this.pnlHistoryCountDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHistoryCountDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlHistoryCountDetails.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHistoryCountDetails.Name = "pnlHistoryCountDetails";
            this.pnlHistoryCountDetails.Size = new System.Drawing.Size(3552, 365);
            this.pnlHistoryCountDetails.TabIndex = 0;
            // 
            // tabLayoutMaster
            // 
            this.tabLayoutMaster.ColumnCount = 1;
            this.tabLayoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabLayoutMaster.Controls.Add(this.flowPnlCameraView, 0, 0);
            this.tabLayoutMaster.Controls.Add(this.pnlInspStatus, 0, 1);
            this.tabLayoutMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLayoutMaster.Location = new System.Drawing.Point(0, 0);
            this.tabLayoutMaster.Margin = new System.Windows.Forms.Padding(0);
            this.tabLayoutMaster.Name = "tabLayoutMaster";
            this.tabLayoutMaster.RowCount = 2;
            this.tabLayoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabLayoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tabLayoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tabLayoutMaster.Size = new System.Drawing.Size(1918, 639);
            this.tabLayoutMaster.TabIndex = 1;
            // 
            // flowPnlCameraView
            // 
            this.flowPnlCameraView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPnlCameraView.Location = new System.Drawing.Point(3, 2);
            this.flowPnlCameraView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowPnlCameraView.Name = "flowPnlCameraView";
            this.flowPnlCameraView.Size = new System.Drawing.Size(1912, 570);
            this.flowPnlCameraView.TabIndex = 1;
            // 
            // pnlInspStatus
            // 
            this.pnlInspStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInspStatus.Location = new System.Drawing.Point(3, 576);
            this.pnlInspStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlInspStatus.Name = "pnlInspStatus";
            this.pnlInspStatus.Size = new System.Drawing.Size(1912, 61);
            this.pnlInspStatus.TabIndex = 6;
            // 
            // tmWritePLCHeartBit
            // 
            this.tmWritePLCHeartBit.Interval = 1000;
            this.tmWritePLCHeartBit.Tick += new System.EventHandler(this.tmWritePLCHeartBit_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1918, 639);
            this.Controls.Add(this.tabLayoutMaster);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "Main";
            this.pnlHistory.ResumeLayout(false);
            this.tblHistory.ResumeLayout(false);
            this.tabLayoutMaster.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.TableLayoutPanel tblHistory;
        private System.Windows.Forms.Panel pnlHistoryCountDetails;
        private System.Windows.Forms.TableLayoutPanel tabLayoutMaster;
        private System.Windows.Forms.Panel pnlInspStatus;
        private System.Windows.Forms.FlowLayoutPanel flowPnlCameraView;
        private System.Windows.Forms.Timer tmWritePLCHeartBit;
    }
}