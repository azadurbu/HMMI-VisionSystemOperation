namespace VisionSystemOperation.Forms
{
    partial class FormPLCInterface
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnReadyOn = new System.Windows.Forms.Button();
            this.btnSeqInitialize = new System.Windows.Forms.Button();
            this.btnReadyOff = new System.Windows.Forms.Button();
            this.btnInspEnd = new System.Windows.Forms.Button();
            this.btnInspStart = new System.Windows.Forms.Button();
            this.btnResultERR = new System.Windows.Forms.Button();
            this.btnResultOK = new System.Windows.Forms.Button();
            this.btnResultNG = new System.Windows.Forms.Button();
            this.btnBTMachOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpVisionSeq = new System.Windows.Forms.TableLayoutPanel();
            this.lblVisionSeq = new System.Windows.Forms.Label();
            this.txbVisionSeqStartAddress = new System.Windows.Forms.TextBox();
            this.btnPLCParamSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPLCVinID = new System.Windows.Forms.Label();
            this.txbPLCVinIdStartAddress = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPLCSeq = new System.Windows.Forms.Label();
            this.txbPLCSeqStartAddress = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlcCarOption = new System.Windows.Forms.Label();
            this.txbPLCCarOptStartAddress = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlcCarModel = new System.Windows.Forms.Label();
            this.txbPLCCarModelStartAddress = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlcCarEngine = new System.Windows.Forms.Label();
            this.txbPLCCarEngStartAddress = new System.Windows.Forms.TextBox();
            this.tmKeepAlive = new System.Windows.Forms.Timer(this.components);
            this.tlpMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tlpConnect = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txbPLCIP = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txbPLCPort = new System.Windows.Forms.TextBox();
            this.btnAliveStatus = new System.Windows.Forms.Button();
            this.chkKeepAlive = new System.Windows.Forms.CheckBox();
            this.btnPLCConnection = new System.Windows.Forms.Button();
            this.dgvPLCInterface = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxInterfaceArea = new System.Windows.Forms.ComboBox();
            this.lblVinID = new System.Windows.Forms.Label();
            this.lblCarType = new System.Windows.Forms.Label();
            this.btnReadVinID = new System.Windows.Forms.Button();
            this.btnReadCarType = new System.Windows.Forms.Button();
            this.btnRefreshPLCMap = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tlpVisionSeq.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tlpMainLayout.SuspendLayout();
            this.tlpConnect.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLCInterface)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(3, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 55);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VisionStatus/BitOnOff";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Controls.Add(this.btnReadyOn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSeqInitialize, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnReadyOff, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInspEnd, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInspStart, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnResultERR, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnResultOK, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnResultNG, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBTMachOK, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 32);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnReadyOn
            // 
            this.btnReadyOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReadyOn.Location = new System.Drawing.Point(3, 3);
            this.btnReadyOn.Name = "btnReadyOn";
            this.btnReadyOn.Size = new System.Drawing.Size(92, 26);
            this.btnReadyOn.TabIndex = 0;
            this.btnReadyOn.Text = "READY ON";
            this.btnReadyOn.UseVisualStyleBackColor = true;
            this.btnReadyOn.Click += new System.EventHandler(this.btnReadyOn_Click);
            // 
            // btnSeqInitialize
            // 
            this.btnSeqInitialize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSeqInitialize.Location = new System.Drawing.Point(787, 3);
            this.btnSeqInitialize.Name = "btnSeqInitialize";
            this.btnSeqInitialize.Size = new System.Drawing.Size(94, 26);
            this.btnSeqInitialize.TabIndex = 0;
            this.btnSeqInitialize.Text = "INITIALIZE";
            this.btnSeqInitialize.UseVisualStyleBackColor = true;
            this.btnSeqInitialize.Click += new System.EventHandler(this.btnSeqInitialize_Click);
            // 
            // btnReadyOff
            // 
            this.btnReadyOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReadyOff.Location = new System.Drawing.Point(101, 3);
            this.btnReadyOff.Name = "btnReadyOff";
            this.btnReadyOff.Size = new System.Drawing.Size(92, 26);
            this.btnReadyOff.TabIndex = 0;
            this.btnReadyOff.Text = "READY OFF";
            this.btnReadyOff.UseVisualStyleBackColor = true;
            this.btnReadyOff.Click += new System.EventHandler(this.btnReadyOff_Click);
            // 
            // btnInspEnd
            // 
            this.btnInspEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInspEnd.Location = new System.Drawing.Point(689, 3);
            this.btnInspEnd.Name = "btnInspEnd";
            this.btnInspEnd.Size = new System.Drawing.Size(92, 26);
            this.btnInspEnd.TabIndex = 0;
            this.btnInspEnd.Text = "VISION END";
            this.btnInspEnd.UseVisualStyleBackColor = true;
            this.btnInspEnd.Click += new System.EventHandler(this.btnInspEnd_Click);
            // 
            // btnInspStart
            // 
            this.btnInspStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInspStart.Location = new System.Drawing.Point(297, 3);
            this.btnInspStart.Name = "btnInspStart";
            this.btnInspStart.Size = new System.Drawing.Size(92, 26);
            this.btnInspStart.TabIndex = 0;
            this.btnInspStart.Text = "VISION START";
            this.btnInspStart.UseVisualStyleBackColor = true;
            this.btnInspStart.Click += new System.EventHandler(this.btnInspStart_Click);
            // 
            // btnResultERR
            // 
            this.btnResultERR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResultERR.Location = new System.Drawing.Point(591, 3);
            this.btnResultERR.Name = "btnResultERR";
            this.btnResultERR.Size = new System.Drawing.Size(92, 26);
            this.btnResultERR.TabIndex = 0;
            this.btnResultERR.Text = "ERR";
            this.btnResultERR.UseVisualStyleBackColor = true;
            this.btnResultERR.Click += new System.EventHandler(this.btnResultERR_Click);
            // 
            // btnResultOK
            // 
            this.btnResultOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResultOK.Location = new System.Drawing.Point(395, 3);
            this.btnResultOK.Name = "btnResultOK";
            this.btnResultOK.Size = new System.Drawing.Size(92, 26);
            this.btnResultOK.TabIndex = 0;
            this.btnResultOK.Text = "LAST COMPL";
            this.btnResultOK.UseVisualStyleBackColor = true;
            this.btnResultOK.Click += new System.EventHandler(this.btnResultOK_Click);
            // 
            // btnResultNG
            // 
            this.btnResultNG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResultNG.Location = new System.Drawing.Point(493, 3);
            this.btnResultNG.Name = "btnResultNG";
            this.btnResultNG.Size = new System.Drawing.Size(92, 26);
            this.btnResultNG.TabIndex = 0;
            this.btnResultNG.Text = "VISION NG";
            this.btnResultNG.UseVisualStyleBackColor = true;
            this.btnResultNG.Click += new System.EventHandler(this.btnResultNG_Click);
            // 
            // btnBTMachOK
            // 
            this.btnBTMachOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBTMachOK.Location = new System.Drawing.Point(199, 3);
            this.btnBTMachOK.Name = "btnBTMachOK";
            this.btnBTMachOK.Size = new System.Drawing.Size(92, 26);
            this.btnBTMachOK.TabIndex = 1;
            this.btnBTMachOK.Text = "BT MATCH OK";
            this.btnBTMachOK.UseVisualStyleBackColor = true;
            this.btnBTMachOK.Click += new System.EventHandler(this.btnBTMachOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(3, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(890, 103);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Start Address";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 7;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel7.Controls.Add(this.tlpVisionSeq, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnPLCParamSave, 6, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel6, 5, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel5, 4, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel4, 3, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(884, 80);
            this.tableLayoutPanel7.TabIndex = 19;
            // 
            // tlpVisionSeq
            // 
            this.tlpVisionSeq.ColumnCount = 1;
            this.tlpVisionSeq.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVisionSeq.Controls.Add(this.lblVisionSeq, 0, 0);
            this.tlpVisionSeq.Controls.Add(this.txbVisionSeqStartAddress, 0, 1);
            this.tlpVisionSeq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVisionSeq.Location = new System.Drawing.Point(3, 3);
            this.tlpVisionSeq.Name = "tlpVisionSeq";
            this.tlpVisionSeq.RowCount = 2;
            this.tlpVisionSeq.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVisionSeq.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVisionSeq.Size = new System.Drawing.Size(117, 74);
            this.tlpVisionSeq.TabIndex = 19;
            // 
            // lblVisionSeq
            // 
            this.lblVisionSeq.AutoSize = true;
            this.lblVisionSeq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVisionSeq.Location = new System.Drawing.Point(3, 0);
            this.lblVisionSeq.Name = "lblVisionSeq";
            this.lblVisionSeq.Size = new System.Drawing.Size(111, 37);
            this.lblVisionSeq.TabIndex = 1;
            this.lblVisionSeq.Text = "VISION SEQ";
            this.lblVisionSeq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbVisionSeqStartAddress
            // 
            this.txbVisionSeqStartAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbVisionSeqStartAddress.Location = new System.Drawing.Point(3, 40);
            this.txbVisionSeqStartAddress.Name = "txbVisionSeqStartAddress";
            this.txbVisionSeqStartAddress.Size = new System.Drawing.Size(111, 24);
            this.txbVisionSeqStartAddress.TabIndex = 0;
            // 
            // btnPLCParamSave
            // 
            this.btnPLCParamSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPLCParamSave.Location = new System.Drawing.Point(741, 3);
            this.btnPLCParamSave.Name = "btnPLCParamSave";
            this.btnPLCParamSave.Size = new System.Drawing.Size(140, 74);
            this.btnPLCParamSave.TabIndex = 0;
            this.btnPLCParamSave.Text = "Save";
            this.btnPLCParamSave.UseVisualStyleBackColor = true;
            this.btnPLCParamSave.Click += new System.EventHandler(this.btnPLCParamSave_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.lblPLCVinID, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.txbPLCVinIdStartAddress, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(618, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(117, 74);
            this.tableLayoutPanel6.TabIndex = 16;
            // 
            // lblPLCVinID
            // 
            this.lblPLCVinID.AutoSize = true;
            this.lblPLCVinID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPLCVinID.Location = new System.Drawing.Point(3, 0);
            this.lblPLCVinID.Name = "lblPLCVinID";
            this.lblPLCVinID.Size = new System.Drawing.Size(111, 37);
            this.lblPLCVinID.TabIndex = 1;
            this.lblPLCVinID.Text = "PLC VIN ID";
            this.lblPLCVinID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbPLCVinIdStartAddress
            // 
            this.txbPLCVinIdStartAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbPLCVinIdStartAddress.Location = new System.Drawing.Point(3, 40);
            this.txbPLCVinIdStartAddress.Name = "txbPLCVinIdStartAddress";
            this.txbPLCVinIdStartAddress.Size = new System.Drawing.Size(111, 24);
            this.txbPLCVinIdStartAddress.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblPLCSeq, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txbPLCSeqStartAddress, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(126, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(117, 74);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // lblPLCSeq
            // 
            this.lblPLCSeq.AutoSize = true;
            this.lblPLCSeq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPLCSeq.Location = new System.Drawing.Point(3, 0);
            this.lblPLCSeq.Name = "lblPLCSeq";
            this.lblPLCSeq.Size = new System.Drawing.Size(111, 37);
            this.lblPLCSeq.TabIndex = 1;
            this.lblPLCSeq.Text = "PLC SEQ";
            this.lblPLCSeq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbPLCSeqStartAddress
            // 
            this.txbPLCSeqStartAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbPLCSeqStartAddress.Location = new System.Drawing.Point(3, 40);
            this.txbPLCSeqStartAddress.Name = "txbPLCSeqStartAddress";
            this.txbPLCSeqStartAddress.Size = new System.Drawing.Size(111, 24);
            this.txbPLCSeqStartAddress.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.lblPlcCarOption, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.txbPLCCarOptStartAddress, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(495, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(117, 74);
            this.tableLayoutPanel5.TabIndex = 18;
            // 
            // lblPlcCarOption
            // 
            this.lblPlcCarOption.AutoSize = true;
            this.lblPlcCarOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlcCarOption.Location = new System.Drawing.Point(3, 0);
            this.lblPlcCarOption.Name = "lblPlcCarOption";
            this.lblPlcCarOption.Size = new System.Drawing.Size(111, 37);
            this.lblPlcCarOption.TabIndex = 1;
            this.lblPlcCarOption.Text = "PLC CAR OPTION";
            this.lblPlcCarOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbPLCCarOptStartAddress
            // 
            this.txbPLCCarOptStartAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbPLCCarOptStartAddress.Location = new System.Drawing.Point(3, 40);
            this.txbPLCCarOptStartAddress.Name = "txbPLCCarOptStartAddress";
            this.txbPLCCarOptStartAddress.Size = new System.Drawing.Size(111, 24);
            this.txbPLCCarOptStartAddress.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lblPlcCarModel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txbPLCCarModelStartAddress, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(249, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(117, 74);
            this.tableLayoutPanel3.TabIndex = 16;
            // 
            // lblPlcCarModel
            // 
            this.lblPlcCarModel.AutoSize = true;
            this.lblPlcCarModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlcCarModel.Location = new System.Drawing.Point(3, 0);
            this.lblPlcCarModel.Name = "lblPlcCarModel";
            this.lblPlcCarModel.Size = new System.Drawing.Size(111, 37);
            this.lblPlcCarModel.TabIndex = 1;
            this.lblPlcCarModel.Text = "PLC CAR MODEL";
            this.lblPlcCarModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbPLCCarModelStartAddress
            // 
            this.txbPLCCarModelStartAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbPLCCarModelStartAddress.Location = new System.Drawing.Point(3, 40);
            this.txbPLCCarModelStartAddress.Name = "txbPLCCarModelStartAddress";
            this.txbPLCCarModelStartAddress.Size = new System.Drawing.Size(111, 24);
            this.txbPLCCarModelStartAddress.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lblPlcCarEngine, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txbPLCCarEngStartAddress, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(372, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(117, 74);
            this.tableLayoutPanel4.TabIndex = 17;
            // 
            // lblPlcCarEngine
            // 
            this.lblPlcCarEngine.AutoSize = true;
            this.lblPlcCarEngine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlcCarEngine.Location = new System.Drawing.Point(3, 0);
            this.lblPlcCarEngine.Name = "lblPlcCarEngine";
            this.lblPlcCarEngine.Size = new System.Drawing.Size(111, 37);
            this.lblPlcCarEngine.TabIndex = 1;
            this.lblPlcCarEngine.Text = "PLC CAR ENGINE";
            this.lblPlcCarEngine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbPLCCarEngStartAddress
            // 
            this.txbPLCCarEngStartAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbPLCCarEngStartAddress.Location = new System.Drawing.Point(3, 40);
            this.txbPLCCarEngStartAddress.Name = "txbPLCCarEngStartAddress";
            this.txbPLCCarEngStartAddress.Size = new System.Drawing.Size(111, 24);
            this.txbPLCCarEngStartAddress.TabIndex = 0;
            // 
            // tmKeepAlive
            // 
            this.tmKeepAlive.Interval = 1000;
            this.tmKeepAlive.Tick += new System.EventHandler(this.tmKeepAlive_Tick);
            // 
            // tlpMainLayout
            // 
            this.tlpMainLayout.ColumnCount = 1;
            this.tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tlpMainLayout.Controls.Add(this.tlpConnect, 0, 0);
            this.tlpMainLayout.Controls.Add(this.dgvPLCInterface, 0, 4);
            this.tlpMainLayout.Controls.Add(this.tableLayoutPanel8, 0, 3);
            this.tlpMainLayout.Controls.Add(this.groupBox2, 0, 1);
            this.tlpMainLayout.Controls.Add(this.groupBox1, 0, 2);
            this.tlpMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpMainLayout.Name = "tlpMainLayout";
            this.tlpMainLayout.RowCount = 5;
            this.tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.755649F));
            this.tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.37778F));
            this.tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.26665F));
            this.tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.26665F));
            this.tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.33327F));
            this.tlpMainLayout.Size = new System.Drawing.Size(896, 597);
            this.tlpMainLayout.TabIndex = 15;
            // 
            // tlpConnect
            // 
            this.tlpConnect.ColumnCount = 9;
            this.tlpConnect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpConnect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpConnect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpConnect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpConnect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tlpConnect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tlpConnect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tlpConnect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tlpConnect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tlpConnect.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tlpConnect.Controls.Add(this.tableLayoutPanel11, 1, 0);
            this.tlpConnect.Controls.Add(this.btnAliveStatus, 4, 0);
            this.tlpConnect.Controls.Add(this.chkKeepAlive, 3, 0);
            this.tlpConnect.Controls.Add(this.btnPLCConnection, 2, 0);
            this.tlpConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConnect.Location = new System.Drawing.Point(3, 3);
            this.tlpConnect.Name = "tlpConnect";
            this.tlpConnect.RowCount = 1;
            this.tlpConnect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConnect.Size = new System.Drawing.Size(890, 52);
            this.tlpConnect.TabIndex = 13;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.txbPLCIP, 0, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(172, 46);
            this.tableLayoutPanel10.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "PLC IP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbPLCIP
            // 
            this.txbPLCIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbPLCIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txbPLCIP.Location = new System.Drawing.Point(3, 26);
            this.txbPLCIP.Name = "txbPLCIP";
            this.txbPLCIP.Size = new System.Drawing.Size(166, 24);
            this.txbPLCIP.TabIndex = 0;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.txbPLCPort, 0, 1);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(181, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(172, 46);
            this.tableLayoutPanel11.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "PLC Port";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbPLCPort
            // 
            this.txbPLCPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbPLCPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txbPLCPort.Location = new System.Drawing.Point(3, 26);
            this.txbPLCPort.Name = "txbPLCPort";
            this.txbPLCPort.Size = new System.Drawing.Size(166, 24);
            this.txbPLCPort.TabIndex = 0;
            // 
            // btnAliveStatus
            // 
            this.btnAliveStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAliveStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAliveStatus.Location = new System.Drawing.Point(715, 3);
            this.btnAliveStatus.Name = "btnAliveStatus";
            this.btnAliveStatus.Size = new System.Drawing.Size(29, 46);
            this.btnAliveStatus.TabIndex = 11;
            this.btnAliveStatus.UseVisualStyleBackColor = true;
            // 
            // chkKeepAlive
            // 
            this.chkKeepAlive.AutoSize = true;
            this.chkKeepAlive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkKeepAlive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkKeepAlive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.chkKeepAlive.Location = new System.Drawing.Point(537, 3);
            this.chkKeepAlive.Name = "chkKeepAlive";
            this.chkKeepAlive.Size = new System.Drawing.Size(172, 46);
            this.chkKeepAlive.TabIndex = 12;
            this.chkKeepAlive.Text = "Keep Alive";
            this.chkKeepAlive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkKeepAlive.UseVisualStyleBackColor = true;
            this.chkKeepAlive.CheckedChanged += new System.EventHandler(this.chkKeepAlive_CheckedChanged);
            // 
            // btnPLCConnection
            // 
            this.btnPLCConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPLCConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnPLCConnection.Location = new System.Drawing.Point(359, 3);
            this.btnPLCConnection.Name = "btnPLCConnection";
            this.btnPLCConnection.Size = new System.Drawing.Size(172, 46);
            this.btnPLCConnection.TabIndex = 0;
            this.btnPLCConnection.Text = "Connect";
            this.btnPLCConnection.UseVisualStyleBackColor = true;
            this.btnPLCConnection.Click += new System.EventHandler(this.btnPLCConnection_Click);
            // 
            // dgvPLCInterface
            // 
            this.dgvPLCInterface.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPLCInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPLCInterface.Location = new System.Drawing.Point(3, 292);
            this.dgvPLCInterface.Name = "dgvPLCInterface";
            this.dgvPLCInterface.RowTemplate.Height = 23;
            this.dgvPLCInterface.Size = new System.Drawing.Size(890, 302);
            this.dgvPLCInterface.TabIndex = 7;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 7;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.lblVinID, 6, 0);
            this.tableLayoutPanel8.Controls.Add(this.lblCarType, 4, 0);
            this.tableLayoutPanel8.Controls.Add(this.btnReadVinID, 5, 0);
            this.tableLayoutPanel8.Controls.Add(this.btnReadCarType, 3, 0);
            this.tableLayoutPanel8.Controls.Add(this.btnRefreshPLCMap, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 231);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(890, 55);
            this.tableLayoutPanel8.TabIndex = 14;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.cbxInterfaceArea, 0, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(127, 49);
            this.tableLayoutPanel9.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Interface Area";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxInterfaceArea
            // 
            this.cbxInterfaceArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxInterfaceArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbxInterfaceArea.FormattingEnabled = true;
            this.cbxInterfaceArea.Location = new System.Drawing.Point(3, 27);
            this.cbxInterfaceArea.Name = "cbxInterfaceArea";
            this.cbxInterfaceArea.Size = new System.Drawing.Size(121, 26);
            this.cbxInterfaceArea.TabIndex = 4;
            this.cbxInterfaceArea.SelectedIndexChanged += new System.EventHandler(this.cbxInterfaceArea_SelectedIndexChanged);
            // 
            // lblVinID
            // 
            this.lblVinID.AutoSize = true;
            this.lblVinID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVinID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblVinID.Location = new System.Drawing.Point(754, 0);
            this.lblVinID.Name = "lblVinID";
            this.lblVinID.Size = new System.Drawing.Size(133, 55);
            this.lblVinID.TabIndex = 9;
            this.lblVinID.Text = "label3";
            this.lblVinID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCarType
            // 
            this.lblCarType.AutoSize = true;
            this.lblCarType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCarType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCarType.Location = new System.Drawing.Point(488, 0);
            this.lblCarType.Name = "lblCarType";
            this.lblCarType.Size = new System.Drawing.Size(127, 55);
            this.lblCarType.TabIndex = 9;
            this.lblCarType.Text = "label3";
            this.lblCarType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReadVinID
            // 
            this.btnReadVinID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReadVinID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnReadVinID.Location = new System.Drawing.Point(621, 3);
            this.btnReadVinID.Name = "btnReadVinID";
            this.btnReadVinID.Size = new System.Drawing.Size(127, 49);
            this.btnReadVinID.TabIndex = 0;
            this.btnReadVinID.Text = "Read VIN ID";
            this.btnReadVinID.UseVisualStyleBackColor = true;
            this.btnReadVinID.Click += new System.EventHandler(this.btnReadVinID_Click);
            // 
            // btnReadCarType
            // 
            this.btnReadCarType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReadCarType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnReadCarType.Location = new System.Drawing.Point(355, 3);
            this.btnReadCarType.Name = "btnReadCarType";
            this.btnReadCarType.Size = new System.Drawing.Size(127, 49);
            this.btnReadCarType.TabIndex = 10;
            this.btnReadCarType.Text = "Read Car Type";
            this.btnReadCarType.UseVisualStyleBackColor = true;
            this.btnReadCarType.Click += new System.EventHandler(this.btnReadCarType_Click);
            // 
            // btnRefreshPLCMap
            // 
            this.btnRefreshPLCMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefreshPLCMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnRefreshPLCMap.Location = new System.Drawing.Point(136, 3);
            this.btnRefreshPLCMap.Name = "btnRefreshPLCMap";
            this.btnRefreshPLCMap.Size = new System.Drawing.Size(127, 49);
            this.btnRefreshPLCMap.TabIndex = 8;
            this.btnRefreshPLCMap.Text = "Load PLC Data";
            this.btnRefreshPLCMap.UseVisualStyleBackColor = true;
            this.btnRefreshPLCMap.Click += new System.EventHandler(this.btnRefreshPLCMap_Click);
            // 
            // FormPLCInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 597);
            this.Controls.Add(this.tlpMainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPLCInterface";
            this.Text = "FormPLCInterface";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPLCInterface_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tlpVisionSeq.ResumeLayout(false);
            this.tlpVisionSeq.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tlpMainLayout.ResumeLayout(false);
            this.tlpConnect.ResumeLayout(false);
            this.tlpConnect.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLCInterface)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReadyOn;
        private System.Windows.Forms.Button btnResultOK;
        private System.Windows.Forms.Button btnInspStart;
        private System.Windows.Forms.Button btnReadyOff;
        private System.Windows.Forms.Button btnInspEnd;
        private System.Windows.Forms.Button btnResultERR;
        private System.Windows.Forms.Button btnResultNG;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbPLCCarOptStartAddress;
        private System.Windows.Forms.Label lblPlcCarOption;
        private System.Windows.Forms.TextBox txbPLCCarEngStartAddress;
        private System.Windows.Forms.Label lblPlcCarEngine;
        private System.Windows.Forms.TextBox txbPLCCarModelStartAddress;
        private System.Windows.Forms.Label lblPlcCarModel;
        private System.Windows.Forms.TextBox txbPLCSeqStartAddress;
        private System.Windows.Forms.Label lblPLCSeq;
        private System.Windows.Forms.TextBox txbPLCVinIdStartAddress;
        private System.Windows.Forms.Label lblPLCVinID;
        private System.Windows.Forms.Button btnPLCParamSave;
        private System.Windows.Forms.Button btnSeqInitialize;
        private System.Windows.Forms.Timer tmKeepAlive;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tlpVisionSeq;
        private System.Windows.Forms.Label lblVisionSeq;
        private System.Windows.Forms.TextBox txbVisionSeqStartAddress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tlpMainLayout;
        private System.Windows.Forms.TableLayoutPanel tlpConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAliveStatus;
        private System.Windows.Forms.CheckBox chkKeepAlive;
        private System.Windows.Forms.TextBox txbPLCIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbPLCPort;
        private System.Windows.Forms.Button btnPLCConnection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxInterfaceArea;
        private System.Windows.Forms.Label lblVinID;
        private System.Windows.Forms.Label lblCarType;
        private System.Windows.Forms.Button btnReadVinID;
        private System.Windows.Forms.Button btnReadCarType;
        private System.Windows.Forms.Button btnRefreshPLCMap;
        private System.Windows.Forms.DataGridView dgvPLCInterface;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Button btnBTMachOK;
    }
}