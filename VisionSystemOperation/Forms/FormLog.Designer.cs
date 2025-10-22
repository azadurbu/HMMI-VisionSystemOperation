
namespace VisionSystemOperation.Forms
{
    partial class FormLog
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
            this.label1 = new System.Windows.Forms.Label();
            this.tblLayoutMaster = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeSearchFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimeSearchTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbxAll = new System.Windows.Forms.CheckBox();
            this.cbxInsp = new System.Windows.Forms.CheckBox();
            this.cbxCam = new System.Windows.Forms.CheckBox();
            this.cbxLight = new System.Windows.Forms.CheckBox();
            this.cbxDio = new System.Windows.Forms.CheckBox();
            this.cbxSeq = new System.Windows.Forms.CheckBox();
            this.cbxInfo = new System.Windows.Forms.CheckBox();
            this.cbxError = new System.Windows.Forms.CheckBox();
            this.cbxResult = new System.Windows.Forms.CheckBox();
            this.dataGridLogData = new System.Windows.Forms.DataGridView();
            this.tblLayoutMaster.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLogData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "log";
            // 
            // tblLayoutMaster
            // 
            this.tblLayoutMaster.ColumnCount = 1;
            this.tblLayoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMaster.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tblLayoutMaster.Controls.Add(this.dataGridLogData, 0, 1);
            this.tblLayoutMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMaster.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMaster.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutMaster.Name = "tblLayoutMaster";
            this.tblLayoutMaster.RowCount = 2;
            this.tblLayoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblLayoutMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutMaster.Size = new System.Drawing.Size(1587, 707);
            this.tblLayoutMaster.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.dateTimeSearchFrom);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.dateTimeSearchTo);
            this.flowLayoutPanel1.Controls.Add(this.btnSearch);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1587, 40);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "From";
            // 
            // dateTimeSearchFrom
            // 
            this.dateTimeSearchFrom.Location = new System.Drawing.Point(40, 2);
            this.dateTimeSearchFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimeSearchFrom.Name = "dateTimeSearchFrom";
            this.dateTimeSearchFrom.Size = new System.Drawing.Size(211, 21);
            this.dateTimeSearchFrom.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "To";
            // 
            // dateTimeSearchTo
            // 
            this.dateTimeSearchTo.Location = new System.Drawing.Point(284, 2);
            this.dateTimeSearchTo.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimeSearchTo.Name = "dateTimeSearchTo";
            this.dateTimeSearchTo.Size = new System.Drawing.Size(211, 21);
            this.dateTimeSearchTo.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(504, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(7, 0, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 27);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.cbxAll);
            this.flowLayoutPanel2.Controls.Add(this.cbxInsp);
            this.flowLayoutPanel2.Controls.Add(this.cbxCam);
            this.flowLayoutPanel2.Controls.Add(this.cbxLight);
            this.flowLayoutPanel2.Controls.Add(this.cbxDio);
            this.flowLayoutPanel2.Controls.Add(this.cbxSeq);
            this.flowLayoutPanel2.Controls.Add(this.cbxInfo);
            this.flowLayoutPanel2.Controls.Add(this.cbxError);
            this.flowLayoutPanel2.Controls.Add(this.cbxResult);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(587, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(988, 34);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // cbxAll
            // 
            this.cbxAll.AutoSize = true;
            this.cbxAll.Checked = true;
            this.cbxAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAll.Location = new System.Drawing.Point(3, 3);
            this.cbxAll.Name = "cbxAll";
            this.cbxAll.Size = new System.Drawing.Size(46, 16);
            this.cbxAll.TabIndex = 6;
            this.cbxAll.Text = "ALL";
            this.cbxAll.UseVisualStyleBackColor = true;
            this.cbxAll.CheckedChanged += new System.EventHandler(this.cbxAll_CheckedChanged);
            // 
            // cbxInsp
            // 
            this.cbxInsp.AutoSize = true;
            this.cbxInsp.Location = new System.Drawing.Point(55, 3);
            this.cbxInsp.Name = "cbxInsp";
            this.cbxInsp.Size = new System.Drawing.Size(52, 16);
            this.cbxInsp.TabIndex = 7;
            this.cbxInsp.Text = "INSP";
            this.cbxInsp.UseVisualStyleBackColor = true;
            this.cbxInsp.CheckedChanged += new System.EventHandler(this.cbxInsp_CheckedChanged);
            // 
            // cbxCam
            // 
            this.cbxCam.AutoSize = true;
            this.cbxCam.Location = new System.Drawing.Point(113, 3);
            this.cbxCam.Name = "cbxCam";
            this.cbxCam.Size = new System.Drawing.Size(52, 16);
            this.cbxCam.TabIndex = 8;
            this.cbxCam.Text = "CAM";
            this.cbxCam.UseVisualStyleBackColor = true;
            this.cbxCam.CheckedChanged += new System.EventHandler(this.cbxCam_CheckedChanged);
            // 
            // cbxLight
            // 
            this.cbxLight.AutoSize = true;
            this.cbxLight.Location = new System.Drawing.Point(171, 3);
            this.cbxLight.Name = "cbxLight";
            this.cbxLight.Size = new System.Drawing.Size(59, 16);
            this.cbxLight.TabIndex = 9;
            this.cbxLight.Text = "LIGHT";
            this.cbxLight.UseVisualStyleBackColor = true;
            this.cbxLight.CheckedChanged += new System.EventHandler(this.cbxLight_CheckedChanged);
            // 
            // cbxDio
            // 
            this.cbxDio.AutoSize = true;
            this.cbxDio.Location = new System.Drawing.Point(236, 3);
            this.cbxDio.Name = "cbxDio";
            this.cbxDio.Size = new System.Drawing.Size(44, 16);
            this.cbxDio.TabIndex = 10;
            this.cbxDio.Text = "DIO";
            this.cbxDio.UseVisualStyleBackColor = true;
            this.cbxDio.CheckedChanged += new System.EventHandler(this.cbxDio_CheckedChanged);
            // 
            // cbxSeq
            // 
            this.cbxSeq.AutoSize = true;
            this.cbxSeq.Location = new System.Drawing.Point(286, 3);
            this.cbxSeq.Name = "cbxSeq";
            this.cbxSeq.Size = new System.Drawing.Size(49, 16);
            this.cbxSeq.TabIndex = 11;
            this.cbxSeq.Text = "SEQ";
            this.cbxSeq.UseVisualStyleBackColor = true;
            this.cbxSeq.CheckedChanged += new System.EventHandler(this.cbxSeq_CheckedChanged);
            // 
            // cbxInfo
            // 
            this.cbxInfo.AutoSize = true;
            this.cbxInfo.Location = new System.Drawing.Point(341, 3);
            this.cbxInfo.Name = "cbxInfo";
            this.cbxInfo.Size = new System.Drawing.Size(52, 16);
            this.cbxInfo.TabIndex = 12;
            this.cbxInfo.Text = "INFO";
            this.cbxInfo.UseVisualStyleBackColor = true;
            this.cbxInfo.CheckedChanged += new System.EventHandler(this.cbxInfo_CheckedChanged);
            // 
            // cbxError
            // 
            this.cbxError.AutoSize = true;
            this.cbxError.Location = new System.Drawing.Point(399, 3);
            this.cbxError.Name = "cbxError";
            this.cbxError.Size = new System.Drawing.Size(65, 16);
            this.cbxError.TabIndex = 13;
            this.cbxError.Text = "ERROR";
            this.cbxError.UseVisualStyleBackColor = true;
            this.cbxError.CheckedChanged += new System.EventHandler(this.cbxError_CheckedChanged);
            // 
            // cbxResult
            // 
            this.cbxResult.AutoSize = true;
            this.cbxResult.Location = new System.Drawing.Point(470, 3);
            this.cbxResult.Name = "cbxResult";
            this.cbxResult.Size = new System.Drawing.Size(71, 16);
            this.cbxResult.TabIndex = 14;
            this.cbxResult.Text = "RESULT";
            this.cbxResult.UseVisualStyleBackColor = true;
            this.cbxResult.CheckedChanged += new System.EventHandler(this.cbxResult_CheckedChanged);
            // 
            // dataGridLogData
            // 
            this.dataGridLogData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridLogData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLogData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridLogData.Location = new System.Drawing.Point(3, 43);
            this.dataGridLogData.Name = "dataGridLogData";
            this.dataGridLogData.RowHeadersWidth = 62;
            this.dataGridLogData.RowTemplate.Height = 23;
            this.dataGridLogData.Size = new System.Drawing.Size(1581, 661);
            this.dataGridLogData.TabIndex = 2;
            // 
            // FormLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1587, 707);
            this.Controls.Add(this.tblLayoutMaster);
            this.Controls.Add(this.label1);
            this.Name = "FormLog";
            this.Text = "FormLog";
            this.tblLayoutMaster.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLogData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tblLayoutMaster;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimeSearchFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimeSearchTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridLogData;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox cbxAll;
        private System.Windows.Forms.CheckBox cbxInsp;
        private System.Windows.Forms.CheckBox cbxCam;
        private System.Windows.Forms.CheckBox cbxLight;
        private System.Windows.Forms.CheckBox cbxDio;
        private System.Windows.Forms.CheckBox cbxSeq;
        private System.Windows.Forms.CheckBox cbxInfo;
        private System.Windows.Forms.CheckBox cbxError;
        private System.Windows.Forms.CheckBox cbxResult;
    }
}