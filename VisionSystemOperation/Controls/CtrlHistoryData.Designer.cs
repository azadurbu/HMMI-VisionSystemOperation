
namespace VisionSystemOperation.Controls
{
    partial class CtrlHistoryData
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
            this.dataGridHistoryDataList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistoryDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridHistoryDataList
            // 
            this.dataGridHistoryDataList.AllowUserToAddRows = false;
            this.dataGridHistoryDataList.AllowUserToDeleteRows = false;
            this.dataGridHistoryDataList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridHistoryDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHistoryDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHistoryDataList.Location = new System.Drawing.Point(0, 0);
            this.dataGridHistoryDataList.Name = "dataGridHistoryDataList";
            this.dataGridHistoryDataList.ReadOnly = true;
            this.dataGridHistoryDataList.RowHeadersWidth = 62;
            this.dataGridHistoryDataList.RowTemplate.Height = 23;
            this.dataGridHistoryDataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridHistoryDataList.Size = new System.Drawing.Size(1980, 150);
            this.dataGridHistoryDataList.TabIndex = 0;
            this.dataGridHistoryDataList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridHistoryDataList_CellContentDoubleClick);
            // 
            // CtrlHistoryData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridHistoryDataList);
            this.Name = "CtrlHistoryData";
            this.Size = new System.Drawing.Size(1980, 150);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHistoryDataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridHistoryDataList;
    }
}
