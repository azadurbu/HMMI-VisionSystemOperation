namespace VisionSystemOperation.Inspection.MotorCar.Model
{
    partial class FormCarRecipe
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
            this.gbCarModel = new System.Windows.Forms.GroupBox();
            this.dgvCarModel = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddCarModel = new System.Windows.Forms.Button();
            this.btnDelCarModel = new System.Windows.Forms.Button();
            this.btnModCarModel = new System.Windows.Forms.Button();
            this.gbEngine = new System.Windows.Forms.GroupBox();
            this.dgvCarEngineType = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddCarEngineType = new System.Windows.Forms.Button();
            this.btnDelCarEngineType = new System.Windows.Forms.Button();
            this.btnModCarEngineType = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenRecipeFolder = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.txbPLCIdx = new System.Windows.Forms.TextBox();
            this.btnSetNoneType = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tlpCarTypeSetting = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tlpOptSection = new System.Windows.Forms.TableLayoutPanel();
            this.tlpUseOpt = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpdateSelOpt = new System.Windows.Forms.Button();
            this.dgvCarUseOpts = new System.Windows.Forms.DataGridView();
            this.tlpMoveOpts2UseOpt = new System.Windows.Forms.TableLayoutPanel();
            this.btnMovOptList2SingleUseOpt = new System.Windows.Forms.Button();
            this.btnMovOptList2MultiUseOpt = new System.Windows.Forms.Button();
            this.tlpOptsList = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddOptionDBList = new System.Windows.Forms.Button();
            this.btnDelOptionDBList = new System.Windows.Forms.Button();
            this.btnModOptionDBList = new System.Windows.Forms.Button();
            this.dgvCarOptTypes = new System.Windows.Forms.DataGridView();
            this.lbxModelNameList = new System.Windows.Forms.ListBox();
            this.gbCarModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarModel)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.gbEngine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarEngineType)).BeginInit();
            this.flowLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tlpCarTypeSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tlpOptSection.SuspendLayout();
            this.tlpUseOpt.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarUseOpts)).BeginInit();
            this.tlpMoveOpts2UseOpt.SuspendLayout();
            this.tlpOptsList.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarOptTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCarModel
            // 
            this.gbCarModel.Controls.Add(this.dgvCarModel);
            this.gbCarModel.Controls.Add(this.flowLayoutPanel2);
            this.gbCarModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCarModel.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.gbCarModel.Location = new System.Drawing.Point(3, 5);
            this.gbCarModel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gbCarModel.Name = "gbCarModel";
            this.gbCarModel.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gbCarModel.Size = new System.Drawing.Size(285, 522);
            this.gbCarModel.TabIndex = 4;
            this.gbCarModel.TabStop = false;
            this.gbCarModel.Text = "Car Model";
            // 
            // dgvCarModel
            // 
            this.dgvCarModel.AllowUserToAddRows = false;
            this.dgvCarModel.AllowUserToDeleteRows = false;
            this.dgvCarModel.AllowUserToResizeRows = false;
            this.dgvCarModel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarModel.Location = new System.Drawing.Point(3, 25);
            this.dgvCarModel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvCarModel.MultiSelect = false;
            this.dgvCarModel.Name = "dgvCarModel";
            this.dgvCarModel.ReadOnly = true;
            this.dgvCarModel.RowHeadersVisible = false;
            this.dgvCarModel.RowTemplate.Height = 23;
            this.dgvCarModel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarModel.Size = new System.Drawing.Size(279, 450);
            this.dgvCarModel.TabIndex = 0;
            this.dgvCarModel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarModel_CellClick);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnAddCarModel);
            this.flowLayoutPanel2.Controls.Add(this.btnDelCarModel);
            this.flowLayoutPanel2.Controls.Add(this.btnModCarModel);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 475);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(279, 42);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // btnAddCarModel
            // 
            this.btnAddCarModel.Location = new System.Drawing.Point(3, 5);
            this.btnAddCarModel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAddCarModel.Name = "btnAddCarModel";
            this.btnAddCarModel.Size = new System.Drawing.Size(60, 33);
            this.btnAddCarModel.TabIndex = 3;
            this.btnAddCarModel.Text = "Add";
            this.btnAddCarModel.UseVisualStyleBackColor = true;
            this.btnAddCarModel.Click += new System.EventHandler(this.btnAddCarModel_Click);
            // 
            // btnDelCarModel
            // 
            this.btnDelCarModel.Location = new System.Drawing.Point(69, 5);
            this.btnDelCarModel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDelCarModel.Name = "btnDelCarModel";
            this.btnDelCarModel.Size = new System.Drawing.Size(60, 33);
            this.btnDelCarModel.TabIndex = 4;
            this.btnDelCarModel.Text = "Del";
            this.btnDelCarModel.UseVisualStyleBackColor = true;
            this.btnDelCarModel.Click += new System.EventHandler(this.btnDelCarModel_Click);
            // 
            // btnModCarModel
            // 
            this.btnModCarModel.Location = new System.Drawing.Point(135, 5);
            this.btnModCarModel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnModCarModel.Name = "btnModCarModel";
            this.btnModCarModel.Size = new System.Drawing.Size(60, 33);
            this.btnModCarModel.TabIndex = 2;
            this.btnModCarModel.Text = "Mod";
            this.btnModCarModel.UseVisualStyleBackColor = true;
            this.btnModCarModel.Click += new System.EventHandler(this.btnModCarModel_Click);
            // 
            // gbEngine
            // 
            this.gbEngine.Controls.Add(this.dgvCarEngineType);
            this.gbEngine.Controls.Add(this.flowLayoutPanel6);
            this.gbEngine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEngine.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.gbEngine.Location = new System.Drawing.Point(294, 5);
            this.gbEngine.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gbEngine.Name = "gbEngine";
            this.gbEngine.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gbEngine.Size = new System.Drawing.Size(285, 522);
            this.gbEngine.TabIndex = 8;
            this.gbEngine.TabStop = false;
            this.gbEngine.Text = "Engine";
            // 
            // dgvCarEngineType
            // 
            this.dgvCarEngineType.AllowUserToAddRows = false;
            this.dgvCarEngineType.AllowUserToDeleteRows = false;
            this.dgvCarEngineType.AllowUserToResizeRows = false;
            this.dgvCarEngineType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarEngineType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarEngineType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarEngineType.Location = new System.Drawing.Point(3, 25);
            this.dgvCarEngineType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvCarEngineType.MultiSelect = false;
            this.dgvCarEngineType.Name = "dgvCarEngineType";
            this.dgvCarEngineType.ReadOnly = true;
            this.dgvCarEngineType.RowHeadersVisible = false;
            this.dgvCarEngineType.RowTemplate.Height = 23;
            this.dgvCarEngineType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarEngineType.Size = new System.Drawing.Size(279, 450);
            this.dgvCarEngineType.TabIndex = 0;
            this.dgvCarEngineType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarEngineType_CellClick);
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.btnAddCarEngineType);
            this.flowLayoutPanel6.Controls.Add(this.btnDelCarEngineType);
            this.flowLayoutPanel6.Controls.Add(this.btnModCarEngineType);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 475);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(279, 42);
            this.flowLayoutPanel6.TabIndex = 2;
            // 
            // btnAddCarEngineType
            // 
            this.btnAddCarEngineType.Location = new System.Drawing.Point(3, 5);
            this.btnAddCarEngineType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAddCarEngineType.Name = "btnAddCarEngineType";
            this.btnAddCarEngineType.Size = new System.Drawing.Size(60, 33);
            this.btnAddCarEngineType.TabIndex = 3;
            this.btnAddCarEngineType.Text = "Add";
            this.btnAddCarEngineType.UseVisualStyleBackColor = true;
            this.btnAddCarEngineType.Click += new System.EventHandler(this.btnAddCarEngineType_Click);
            // 
            // btnDelCarEngineType
            // 
            this.btnDelCarEngineType.Location = new System.Drawing.Point(69, 5);
            this.btnDelCarEngineType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDelCarEngineType.Name = "btnDelCarEngineType";
            this.btnDelCarEngineType.Size = new System.Drawing.Size(60, 33);
            this.btnDelCarEngineType.TabIndex = 4;
            this.btnDelCarEngineType.Text = "Del";
            this.btnDelCarEngineType.UseVisualStyleBackColor = true;
            this.btnDelCarEngineType.Click += new System.EventHandler(this.btnDelCarEngineType_Click);
            // 
            // btnModCarEngineType
            // 
            this.btnModCarEngineType.Location = new System.Drawing.Point(135, 5);
            this.btnModCarEngineType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnModCarEngineType.Name = "btnModCarEngineType";
            this.btnModCarEngineType.Size = new System.Drawing.Size(60, 33);
            this.btnModCarEngineType.TabIndex = 2;
            this.btnModCarEngineType.Text = "Mod";
            this.btnModCarEngineType.UseVisualStyleBackColor = true;
            this.btnModCarEngineType.Click += new System.EventHandler(this.btnModCarEngineType_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.44444F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88889F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 541);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1165, 48);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel6.Controls.Add(this.btnOpenRecipeFolder, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(1006, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(156, 42);
            this.tableLayoutPanel6.TabIndex = 11;
            // 
            // btnOpenRecipeFolder
            // 
            this.btnOpenRecipeFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenRecipeFolder.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnOpenRecipeFolder.Location = new System.Drawing.Point(3, 3);
            this.btnOpenRecipeFolder.Name = "btnOpenRecipeFolder";
            this.btnOpenRecipeFolder.Size = new System.Drawing.Size(150, 36);
            this.btnOpenRecipeFolder.TabIndex = 11;
            this.btnOpenRecipeFolder.Text = "Open Folder";
            this.btnOpenRecipeFolder.UseVisualStyleBackColor = true;
            this.btnOpenRecipeFolder.Click += new System.EventHandler(this.btnOpenRecipeFolder_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.97042F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.48413F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.97042F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.48413F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txbName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txbPLCIdx, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSetNoneType, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(197, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(803, 42);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(367, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "PLC Index";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbName
            // 
            this.txbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbName.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.txbName.Location = new System.Drawing.Point(123, 3);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(238, 27);
            this.txbName.TabIndex = 1;
            // 
            // txbPLCIdx
            // 
            this.txbPLCIdx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPLCIdx.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.txbPLCIdx.Location = new System.Drawing.Point(487, 3);
            this.txbPLCIdx.Name = "txbPLCIdx";
            this.txbPLCIdx.Size = new System.Drawing.Size(238, 27);
            this.txbPLCIdx.TabIndex = 1;
            // 
            // btnSetNoneType
            // 
            this.btnSetNoneType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetNoneType.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnSetNoneType.Location = new System.Drawing.Point(731, 3);
            this.btnSetNoneType.Name = "btnSetNoneType";
            this.btnSetNoneType.Size = new System.Drawing.Size(69, 36);
            this.btnSetNoneType.TabIndex = 2;
            this.btnSetNoneType.Text = "None";
            this.btnSetNoneType.UseVisualStyleBackColor = true;
            this.btnSetNoneType.Click += new System.EventHandler(this.btnSetNoneType_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Controls.Add(this.btnUpdate, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tlpCarTypeSetting, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lbxModelNameList, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1406, 592);
            this.tableLayoutPanel4.TabIndex = 10;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(1174, 541);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(229, 48);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tlpCarTypeSetting
            // 
            this.tlpCarTypeSetting.ColumnCount = 3;
            this.tlpCarTypeSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCarTypeSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCarTypeSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCarTypeSetting.Controls.Add(this.gbCarModel, 0, 0);
            this.tlpCarTypeSetting.Controls.Add(this.gbEngine, 1, 0);
            this.tlpCarTypeSetting.Controls.Add(this.groupBox1, 2, 0);
            this.tlpCarTypeSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCarTypeSetting.Location = new System.Drawing.Point(3, 3);
            this.tlpCarTypeSetting.Name = "tlpCarTypeSetting";
            this.tlpCarTypeSetting.RowCount = 1;
            this.tlpCarTypeSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCarTypeSetting.Size = new System.Drawing.Size(1165, 532);
            this.tlpCarTypeSetting.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tlpOptSection);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(585, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 526);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OPT";
            // 
            // tlpOptSection
            // 
            this.tlpOptSection.ColumnCount = 3;
            this.tlpOptSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpOptSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpOptSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpOptSection.Controls.Add(this.tlpUseOpt, 0, 0);
            this.tlpOptSection.Controls.Add(this.tlpMoveOpts2UseOpt, 1, 0);
            this.tlpOptSection.Controls.Add(this.tlpOptsList, 2, 0);
            this.tlpOptSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOptSection.Location = new System.Drawing.Point(3, 23);
            this.tlpOptSection.Name = "tlpOptSection";
            this.tlpOptSection.RowCount = 1;
            this.tlpOptSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOptSection.Size = new System.Drawing.Size(571, 500);
            this.tlpOptSection.TabIndex = 15;
            // 
            // tlpUseOpt
            // 
            this.tlpUseOpt.ColumnCount = 1;
            this.tlpUseOpt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUseOpt.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tlpUseOpt.Controls.Add(this.dgvCarUseOpts, 0, 0);
            this.tlpUseOpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUseOpt.Location = new System.Drawing.Point(3, 3);
            this.tlpUseOpt.Name = "tlpUseOpt";
            this.tlpUseOpt.RowCount = 2;
            this.tlpUseOpt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpUseOpt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpUseOpt.Size = new System.Drawing.Size(250, 494);
            this.tlpUseOpt.TabIndex = 9;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.Controls.Add(this.btnUpdateSelOpt, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 447);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(244, 44);
            this.tableLayoutPanel5.TabIndex = 10;
            // 
            // btnUpdateSelOpt
            // 
            this.btnUpdateSelOpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateSelOpt.Location = new System.Drawing.Point(76, 5);
            this.btnUpdateSelOpt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnUpdateSelOpt.Name = "btnUpdateSelOpt";
            this.btnUpdateSelOpt.Size = new System.Drawing.Size(91, 34);
            this.btnUpdateSelOpt.TabIndex = 7;
            this.btnUpdateSelOpt.Text = "Update";
            this.btnUpdateSelOpt.UseVisualStyleBackColor = true;
            this.btnUpdateSelOpt.Click += new System.EventHandler(this.btnUpdateSelOpt_Click);
            // 
            // dgvCarUseOpts
            // 
            this.dgvCarUseOpts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarUseOpts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarUseOpts.Location = new System.Drawing.Point(3, 3);
            this.dgvCarUseOpts.Name = "dgvCarUseOpts";
            this.dgvCarUseOpts.RowTemplate.Height = 23;
            this.dgvCarUseOpts.Size = new System.Drawing.Size(244, 438);
            this.dgvCarUseOpts.TabIndex = 0;
            this.dgvCarUseOpts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarUseOpts_CellClick);
            // 
            // tlpMoveOpts2UseOpt
            // 
            this.tlpMoveOpts2UseOpt.ColumnCount = 3;
            this.tlpMoveOpts2UseOpt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMoveOpts2UseOpt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlpMoveOpts2UseOpt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMoveOpts2UseOpt.Controls.Add(this.btnMovOptList2SingleUseOpt, 1, 1);
            this.tlpMoveOpts2UseOpt.Controls.Add(this.btnMovOptList2MultiUseOpt, 1, 2);
            this.tlpMoveOpts2UseOpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMoveOpts2UseOpt.Location = new System.Drawing.Point(259, 3);
            this.tlpMoveOpts2UseOpt.Name = "tlpMoveOpts2UseOpt";
            this.tlpMoveOpts2UseOpt.RowCount = 4;
            this.tlpMoveOpts2UseOpt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMoveOpts2UseOpt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tlpMoveOpts2UseOpt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tlpMoveOpts2UseOpt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMoveOpts2UseOpt.Size = new System.Drawing.Size(51, 494);
            this.tlpMoveOpts2UseOpt.TabIndex = 14;
            // 
            // btnMovOptList2SingleUseOpt
            // 
            this.btnMovOptList2SingleUseOpt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMovOptList2SingleUseOpt.Location = new System.Drawing.Point(-14, 209);
            this.btnMovOptList2SingleUseOpt.Name = "btnMovOptList2SingleUseOpt";
            this.btnMovOptList2SingleUseOpt.Size = new System.Drawing.Size(80, 35);
            this.btnMovOptList2SingleUseOpt.TabIndex = 12;
            this.btnMovOptList2SingleUseOpt.Text = "<";
            this.btnMovOptList2SingleUseOpt.UseVisualStyleBackColor = true;
            this.btnMovOptList2SingleUseOpt.Click += new System.EventHandler(this.btnMovOptList2SingleUseOpt_Click);
            // 
            // btnMovOptList2MultiUseOpt
            // 
            this.btnMovOptList2MultiUseOpt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMovOptList2MultiUseOpt.Location = new System.Drawing.Point(-14, 250);
            this.btnMovOptList2MultiUseOpt.Name = "btnMovOptList2MultiUseOpt";
            this.btnMovOptList2MultiUseOpt.Size = new System.Drawing.Size(80, 35);
            this.btnMovOptList2MultiUseOpt.TabIndex = 13;
            this.btnMovOptList2MultiUseOpt.Text = "<<";
            this.btnMovOptList2MultiUseOpt.UseVisualStyleBackColor = true;
            this.btnMovOptList2MultiUseOpt.Click += new System.EventHandler(this.btnMovOptList2UseOpts_Click);
            // 
            // tlpOptsList
            // 
            this.tlpOptsList.ColumnCount = 1;
            this.tlpOptsList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOptsList.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tlpOptsList.Controls.Add(this.dgvCarOptTypes, 0, 0);
            this.tlpOptsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOptsList.Location = new System.Drawing.Point(316, 3);
            this.tlpOptsList.Name = "tlpOptsList";
            this.tlpOptsList.RowCount = 2;
            this.tlpOptsList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpOptsList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpOptsList.Size = new System.Drawing.Size(252, 494);
            this.tlpOptsList.TabIndex = 10;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel7.Controls.Add(this.btnAddOptionDBList, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnDelOptionDBList, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnModOptionDBList, 2, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 447);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(246, 44);
            this.tableLayoutPanel7.TabIndex = 11;
            // 
            // btnAddOptionDBList
            // 
            this.btnAddOptionDBList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddOptionDBList.Location = new System.Drawing.Point(3, 5);
            this.btnAddOptionDBList.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAddOptionDBList.Name = "btnAddOptionDBList";
            this.btnAddOptionDBList.Size = new System.Drawing.Size(67, 34);
            this.btnAddOptionDBList.TabIndex = 6;
            this.btnAddOptionDBList.Text = "Add";
            this.btnAddOptionDBList.UseVisualStyleBackColor = true;
            this.btnAddOptionDBList.Click += new System.EventHandler(this.btnAddCarOption_Click);
            // 
            // btnDelOptionDBList
            // 
            this.btnDelOptionDBList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelOptionDBList.Location = new System.Drawing.Point(76, 5);
            this.btnDelOptionDBList.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDelOptionDBList.Name = "btnDelOptionDBList";
            this.btnDelOptionDBList.Size = new System.Drawing.Size(92, 34);
            this.btnDelOptionDBList.TabIndex = 7;
            this.btnDelOptionDBList.Text = "Del";
            this.btnDelOptionDBList.UseVisualStyleBackColor = true;
            this.btnDelOptionDBList.Click += new System.EventHandler(this.btnDelOptionDBList_Click);
            // 
            // btnModOptionDBList
            // 
            this.btnModOptionDBList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnModOptionDBList.Location = new System.Drawing.Point(174, 5);
            this.btnModOptionDBList.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnModOptionDBList.Name = "btnModOptionDBList";
            this.btnModOptionDBList.Size = new System.Drawing.Size(69, 34);
            this.btnModOptionDBList.TabIndex = 5;
            this.btnModOptionDBList.Text = "Mod";
            this.btnModOptionDBList.UseVisualStyleBackColor = true;
            this.btnModOptionDBList.Click += new System.EventHandler(this.btnModOptionDBList_Click);
            // 
            // dgvCarOptTypes
            // 
            this.dgvCarOptTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarOptTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarOptTypes.Location = new System.Drawing.Point(3, 3);
            this.dgvCarOptTypes.Name = "dgvCarOptTypes";
            this.dgvCarOptTypes.RowTemplate.Height = 23;
            this.dgvCarOptTypes.Size = new System.Drawing.Size(246, 438);
            this.dgvCarOptTypes.TabIndex = 0;
            this.dgvCarOptTypes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarOptTypes_CellClick);
            // 
            // lbxModelNameList
            // 
            this.lbxModelNameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxModelNameList.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.lbxModelNameList.FormattingEnabled = true;
            this.lbxModelNameList.ItemHeight = 20;
            this.lbxModelNameList.Location = new System.Drawing.Point(1174, 3);
            this.lbxModelNameList.Name = "lbxModelNameList";
            this.lbxModelNameList.Size = new System.Drawing.Size(229, 532);
            this.lbxModelNameList.TabIndex = 10;
            // 
            // FormCarRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 592);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Name = "FormCarRecipe";
            this.Text = "FormCarRecipe";
            this.Load += new System.EventHandler(this.FormCarRecipe_Load);
            this.gbCarModel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarModel)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.gbEngine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarEngineType)).EndInit();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tlpCarTypeSetting.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tlpOptSection.ResumeLayout(false);
            this.tlpUseOpt.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarUseOpts)).EndInit();
            this.tlpMoveOpts2UseOpt.ResumeLayout(false);
            this.tlpOptsList.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarOptTypes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCarModel;
        private System.Windows.Forms.DataGridView dgvCarModel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnAddCarModel;
        private System.Windows.Forms.Button btnDelCarModel;
        private System.Windows.Forms.Button btnModCarModel;
        private System.Windows.Forms.GroupBox gbEngine;
        private System.Windows.Forms.DataGridView dgvCarEngineType;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Button btnAddCarEngineType;
        private System.Windows.Forms.Button btnDelCarEngineType;
        private System.Windows.Forms.Button btnModCarEngineType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.TextBox txbPLCIdx;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tlpCarTypeSetting;
        private System.Windows.Forms.ListBox lbxModelNameList;
        private System.Windows.Forms.Button btnOpenRecipeFolder;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCarOptTypes;
        private System.Windows.Forms.Button btnAddOptionDBList;
        private System.Windows.Forms.DataGridView dgvCarUseOpts;
        private System.Windows.Forms.Button btnDelOptionDBList;
        private System.Windows.Forms.Button btnModOptionDBList;
        private System.Windows.Forms.Button btnUpdateSelOpt;
        private System.Windows.Forms.Button btnSetNoneType;
        private System.Windows.Forms.TableLayoutPanel tlpOptsList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tlpUseOpt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tlpOptSection;
        private System.Windows.Forms.TableLayoutPanel tlpMoveOpts2UseOpt;
        private System.Windows.Forms.Button btnMovOptList2SingleUseOpt;
        private System.Windows.Forms.Button btnMovOptList2MultiUseOpt;
    }
}