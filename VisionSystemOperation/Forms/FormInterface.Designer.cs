
namespace VisionSystemOperation.Forms
{
    partial class FormInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInterface));
            this.ui_gb_display = new System.Windows.Forms.GroupBox();
            this.cogDisplayToolbar = new Cognex.VisionPro.CogDisplayToolbarV2();
            this.cogDisplay = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplayStatusBarV21 = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.fpn_image = new System.Windows.Forms.FlowLayoutPanel();
            this.btnImageLoad = new System.Windows.Forms.Button();
            this.lbImage = new System.Windows.Forms.Label();
            this.lbAlignStaus = new System.Windows.Forms.Label();
            this.ui_gb_recipe = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoadRcp = new System.Windows.Forms.Button();
            this.lblSelectedRcp = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.ui_pn_right = new System.Windows.Forms.GroupBox();
            this.dgvROISetList = new System.Windows.Forms.DataGridView();
            this.ui_pn_roiApply = new System.Windows.Forms.FlowLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.btnSetRoiSize = new System.Windows.Forms.Button();
            this.txtSetRoiSize = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.ui_fpn_gridAddDel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnGridDel = new System.Windows.Forms.Button();
            this.btnGridModify = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.fpnStep = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCamList = new System.Windows.Forms.ComboBox();
            this.rtbResultTable = new System.Windows.Forms.RichTextBox();
            this.ui_gb_inspect = new System.Windows.Forms.GroupBox();
            this.btnInspect = new System.Windows.Forms.Button();
            this.tblpDiplayRcp = new System.Windows.Forms.TableLayoutPanel();
            this.tblpRecipeBlock = new System.Windows.Forms.TableLayoutPanel();
            this.tblpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tbcInterfaceType = new System.Windows.Forms.TabControl();
            this.inpection = new System.Windows.Forms.TabPage();
            this.plc = new System.Windows.Forms.TabPage();
            this.btnLoadPMAlignTool = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.ui_gb_display.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).BeginInit();
            this.fpn_image.SuspendLayout();
            this.ui_gb_recipe.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ui_pn_right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvROISetList)).BeginInit();
            this.ui_pn_roiApply.SuspendLayout();
            this.ui_fpn_gridAddDel.SuspendLayout();
            this.fpnStep.SuspendLayout();
            this.ui_gb_inspect.SuspendLayout();
            this.tblpDiplayRcp.SuspendLayout();
            this.tblpRecipeBlock.SuspendLayout();
            this.tblpMain.SuspendLayout();
            this.tbcInterfaceType.SuspendLayout();
            this.inpection.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_gb_display
            // 
            this.ui_gb_display.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ui_gb_display.Controls.Add(this.cogDisplayToolbar);
            this.ui_gb_display.Controls.Add(this.cogDisplay);
            this.ui_gb_display.Controls.Add(this.cogDisplayStatusBarV21);
            this.ui_gb_display.Controls.Add(this.fpn_image);
            this.ui_gb_display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_gb_display.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ui_gb_display.Location = new System.Drawing.Point(3, 101);
            this.ui_gb_display.Name = "ui_gb_display";
            this.ui_gb_display.Size = new System.Drawing.Size(920, 537);
            this.ui_gb_display.TabIndex = 266;
            this.ui_gb_display.TabStop = false;
            this.ui_gb_display.Text = "Display( Image )";
            // 
            // cogDisplayToolbar
            // 
            this.cogDisplayToolbar.Location = new System.Drawing.Point(3, 66);
            this.cogDisplayToolbar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cogDisplayToolbar.Name = "cogDisplayToolbar";
            this.cogDisplayToolbar.Size = new System.Drawing.Size(261, 32);
            this.cogDisplayToolbar.TabIndex = 264;
            // 
            // cogDisplay
            // 
            this.cogDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay.DoubleTapZoomCycleLength = 2;
            this.cogDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay.Location = new System.Drawing.Point(3, 66);
            this.cogDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay.MouseWheelSensitivity = 1D;
            this.cogDisplay.Name = "cogDisplay";
            this.cogDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay.OcxState")));
            this.cogDisplay.Size = new System.Drawing.Size(914, 418);
            this.cogDisplay.TabIndex = 134;
            // 
            // cogDisplayStatusBarV21
            // 
            this.cogDisplayStatusBarV21.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBarV21.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBarV21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cogDisplayStatusBarV21.Location = new System.Drawing.Point(3, 484);
            this.cogDisplayStatusBarV21.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.cogDisplayStatusBarV21.Name = "cogDisplayStatusBarV21";
            this.cogDisplayStatusBarV21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBarV21.Size = new System.Drawing.Size(914, 50);
            this.cogDisplayStatusBarV21.TabIndex = 132;
            this.cogDisplayStatusBarV21.Use3DCoordinateSpaceTree = false;
            // 
            // fpn_image
            // 
            this.fpn_image.Controls.Add(this.btnImageLoad);
            this.fpn_image.Controls.Add(this.lbImage);
            this.fpn_image.Controls.Add(this.btnSaveImage);
            this.fpn_image.Controls.Add(this.btnLoadPMAlignTool);
            this.fpn_image.Controls.Add(this.lbAlignStaus);
            this.fpn_image.Dock = System.Windows.Forms.DockStyle.Top;
            this.fpn_image.Location = new System.Drawing.Point(3, 21);
            this.fpn_image.Name = "fpn_image";
            this.fpn_image.Size = new System.Drawing.Size(914, 45);
            this.fpn_image.TabIndex = 263;
            // 
            // btnImageLoad
            // 
            this.btnImageLoad.AutoSize = true;
            this.btnImageLoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnImageLoad.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnImageLoad.Location = new System.Drawing.Point(3, 3);
            this.btnImageLoad.Name = "btnImageLoad";
            this.btnImageLoad.Padding = new System.Windows.Forms.Padding(5);
            this.btnImageLoad.Size = new System.Drawing.Size(64, 35);
            this.btnImageLoad.TabIndex = 237;
            this.btnImageLoad.Text = "Load";
            this.btnImageLoad.UseVisualStyleBackColor = true;
            this.btnImageLoad.Click += new System.EventHandler(this.btnImageLoad_Click);
            // 
            // lbImage
            // 
            this.lbImage.BackColor = System.Drawing.SystemColors.Window;
            this.lbImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbImage.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImage.Location = new System.Drawing.Point(73, 3);
            this.lbImage.Margin = new System.Windows.Forms.Padding(3);
            this.lbImage.Name = "lbImage";
            this.lbImage.Size = new System.Drawing.Size(394, 35);
            this.lbImage.TabIndex = 243;
            this.lbImage.Text = "Selected Image";
            this.lbImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbAlignStaus
            // 
            this.lbAlignStaus.BackColor = System.Drawing.Color.Tomato;
            this.lbAlignStaus.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbAlignStaus.Location = new System.Drawing.Point(630, 3);
            this.lbAlignStaus.Margin = new System.Windows.Forms.Padding(3);
            this.lbAlignStaus.Name = "lbAlignStaus";
            this.lbAlignStaus.Padding = new System.Windows.Forms.Padding(3);
            this.lbAlignStaus.Size = new System.Drawing.Size(58, 35);
            this.lbAlignStaus.TabIndex = 254;
            this.lbAlignStaus.Text = "0.0";
            this.lbAlignStaus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAlignStaus.Visible = false;
            this.lbAlignStaus.DoubleClick += new System.EventHandler(this.lbAlignStaus_DoubleClick);
            // 
            // ui_gb_recipe
            // 
            this.ui_gb_recipe.Controls.Add(this.tableLayoutPanel1);
            this.ui_gb_recipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_gb_recipe.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ui_gb_recipe.Location = new System.Drawing.Point(3, 3);
            this.ui_gb_recipe.Name = "ui_gb_recipe";
            this.ui_gb_recipe.Size = new System.Drawing.Size(730, 86);
            this.ui_gb_recipe.TabIndex = 267;
            this.ui_gb_recipe.TabStop = false;
            this.ui_gb_recipe.Text = "Recipe";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnLoadRcp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSelectedRcp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(724, 62);
            this.tableLayoutPanel1.TabIndex = 264;
            // 
            // btnLoadRcp
            // 
            this.btnLoadRcp.AutoSize = true;
            this.btnLoadRcp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoadRcp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadRcp.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoadRcp.Location = new System.Drawing.Point(437, 3);
            this.btnLoadRcp.Name = "btnLoadRcp";
            this.btnLoadRcp.Padding = new System.Windows.Forms.Padding(5);
            this.btnLoadRcp.Size = new System.Drawing.Size(138, 56);
            this.btnLoadRcp.TabIndex = 260;
            this.btnLoadRcp.Text = "Car Recipe Load";
            this.btnLoadRcp.UseVisualStyleBackColor = true;
            this.btnLoadRcp.Click += new System.EventHandler(this.btnLoadRcp_Click);
            // 
            // lblSelectedRcp
            // 
            this.lblSelectedRcp.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblSelectedRcp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSelectedRcp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectedRcp.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelectedRcp.Location = new System.Drawing.Point(3, 3);
            this.lblSelectedRcp.Margin = new System.Windows.Forms.Padding(3);
            this.lblSelectedRcp.Name = "lblSelectedRcp";
            this.lblSelectedRcp.Size = new System.Drawing.Size(428, 56);
            this.lblSelectedRcp.TabIndex = 263;
            this.lblSelectedRcp.Text = "Selected Recipe";
            this.lblSelectedRcp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(581, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 56);
            this.btnSave.TabIndex = 264;
            this.btnSave.Text = "Parameter Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ui_pn_right
            // 
            this.ui_pn_right.Controls.Add(this.dgvROISetList);
            this.ui_pn_right.Controls.Add(this.ui_pn_roiApply);
            this.ui_pn_right.Controls.Add(this.ui_fpn_gridAddDel);
            this.ui_pn_right.Controls.Add(this.fpnStep);
            this.ui_pn_right.Controls.Add(this.rtbResultTable);
            this.ui_pn_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_pn_right.Location = new System.Drawing.Point(935, 3);
            this.ui_pn_right.Name = "ui_pn_right";
            this.ui_pn_right.Size = new System.Drawing.Size(394, 641);
            this.ui_pn_right.TabIndex = 268;
            this.ui_pn_right.TabStop = false;
            // 
            // dgvROISetList
            // 
            this.dgvROISetList.AllowUserToAddRows = false;
            this.dgvROISetList.AllowUserToDeleteRows = false;
            this.dgvROISetList.AllowUserToResizeRows = false;
            this.dgvROISetList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvROISetList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvROISetList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvROISetList.Location = new System.Drawing.Point(3, 63);
            this.dgvROISetList.MultiSelect = false;
            this.dgvROISetList.Name = "dgvROISetList";
            this.dgvROISetList.RowHeadersVisible = false;
            this.dgvROISetList.RowTemplate.Height = 23;
            this.dgvROISetList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvROISetList.Size = new System.Drawing.Size(388, 344);
            this.dgvROISetList.TabIndex = 251;
            this.dgvROISetList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvROISetList_CellClick);
            this.dgvROISetList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvROISetList_CellContentClick);
            this.dgvROISetList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvROISetList_CellDoubleClick);
            // 
            // ui_pn_roiApply
            // 
            this.ui_pn_roiApply.Controls.Add(this.label18);
            this.ui_pn_roiApply.Controls.Add(this.btnSetRoiSize);
            this.ui_pn_roiApply.Controls.Add(this.txtSetRoiSize);
            this.ui_pn_roiApply.Controls.Add(this.label19);
            this.ui_pn_roiApply.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ui_pn_roiApply.Location = new System.Drawing.Point(3, 407);
            this.ui_pn_roiApply.Name = "ui_pn_roiApply";
            this.ui_pn_roiApply.Size = new System.Drawing.Size(388, 35);
            this.ui_pn_roiApply.TabIndex = 253;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(211, 28);
            this.label18.TabIndex = 274;
            this.label18.Text = "Batch Change of ROI Size";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label18.Visible = false;
            // 
            // btnSetRoiSize
            // 
            this.btnSetRoiSize.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSetRoiSize.Location = new System.Drawing.Point(220, 3);
            this.btnSetRoiSize.Name = "btnSetRoiSize";
            this.btnSetRoiSize.Size = new System.Drawing.Size(64, 25);
            this.btnSetRoiSize.TabIndex = 0;
            this.btnSetRoiSize.Text = "Apply";
            this.btnSetRoiSize.UseVisualStyleBackColor = true;
            this.btnSetRoiSize.Visible = false;
            this.btnSetRoiSize.Click += new System.EventHandler(this.btnSetRoiSize_Click);
            // 
            // txtSetRoiSize
            // 
            this.txtSetRoiSize.Location = new System.Drawing.Point(290, 3);
            this.txtSetRoiSize.Name = "txtSetRoiSize";
            this.txtSetRoiSize.Size = new System.Drawing.Size(84, 29);
            this.txtSetRoiSize.TabIndex = 273;
            this.txtSetRoiSize.Text = "100";
            this.txtSetRoiSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSetRoiSize.Visible = false;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.Location = new System.Drawing.Point(3, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 28);
            this.label19.TabIndex = 275;
            this.label19.Text = "%";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ui_fpn_gridAddDel
            // 
            this.ui_fpn_gridAddDel.Controls.Add(this.btnAddItem);
            this.ui_fpn_gridAddDel.Controls.Add(this.btnGridDel);
            this.ui_fpn_gridAddDel.Controls.Add(this.btnGridModify);
            this.ui_fpn_gridAddDel.Controls.Add(this.label16);
            this.ui_fpn_gridAddDel.Controls.Add(this.txtName);
            this.ui_fpn_gridAddDel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ui_fpn_gridAddDel.Location = new System.Drawing.Point(3, 442);
            this.ui_fpn_gridAddDel.Name = "ui_fpn_gridAddDel";
            this.ui_fpn_gridAddDel.Size = new System.Drawing.Size(388, 35);
            this.ui_fpn_gridAddDel.TabIndex = 0;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.AutoSize = true;
            this.btnAddItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddItem.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAddItem.Location = new System.Drawing.Point(3, 3);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Padding = new System.Windows.Forms.Padding(2);
            this.btnAddItem.Size = new System.Drawing.Size(49, 29);
            this.btnAddItem.TabIndex = 269;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnGridDel
            // 
            this.btnGridDel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGridDel.AutoSize = true;
            this.btnGridDel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGridDel.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGridDel.Location = new System.Drawing.Point(58, 3);
            this.btnGridDel.Name = "btnGridDel";
            this.btnGridDel.Padding = new System.Windows.Forms.Padding(2);
            this.btnGridDel.Size = new System.Drawing.Size(45, 29);
            this.btnGridDel.TabIndex = 270;
            this.btnGridDel.Text = "Del";
            this.btnGridDel.UseVisualStyleBackColor = true;
            this.btnGridDel.Click += new System.EventHandler(this.btnGridDel_Click);
            // 
            // btnGridModify
            // 
            this.btnGridModify.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGridModify.AutoSize = true;
            this.btnGridModify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGridModify.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGridModify.Location = new System.Drawing.Point(109, 3);
            this.btnGridModify.Name = "btnGridModify";
            this.btnGridModify.Padding = new System.Windows.Forms.Padding(2);
            this.btnGridModify.Size = new System.Drawing.Size(71, 29);
            this.btnGridModify.TabIndex = 270;
            this.btnGridModify.Text = "Modify";
            this.btnGridModify.UseVisualStyleBackColor = true;
            this.btnGridModify.Click += new System.EventHandler(this.btnGridModify_Click);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(186, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 28);
            this.label16.TabIndex = 271;
            this.label16.Text = "Name";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(3, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(138, 29);
            this.txtName.TabIndex = 272;
            // 
            // fpnStep
            // 
            this.fpnStep.Controls.Add(this.label1);
            this.fpnStep.Controls.Add(this.cbxCamList);
            this.fpnStep.Dock = System.Windows.Forms.DockStyle.Top;
            this.fpnStep.Location = new System.Drawing.Point(3, 25);
            this.fpnStep.Name = "fpnStep";
            this.fpnStep.Size = new System.Drawing.Size(388, 38);
            this.fpnStep.TabIndex = 248;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "CAMERA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxCamList
            // 
            this.cbxCamList.FormattingEnabled = true;
            this.cbxCamList.Location = new System.Drawing.Point(81, 3);
            this.cbxCamList.Name = "cbxCamList";
            this.cbxCamList.Size = new System.Drawing.Size(194, 27);
            this.cbxCamList.TabIndex = 0;
            this.cbxCamList.SelectedIndexChanged += new System.EventHandler(this.cbxCamList_SelectedIndexChanged);
            // 
            // rtbResultTable
            // 
            this.rtbResultTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbResultTable.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbResultTable.Location = new System.Drawing.Point(3, 477);
            this.rtbResultTable.Name = "rtbResultTable";
            this.rtbResultTable.Size = new System.Drawing.Size(388, 161);
            this.rtbResultTable.TabIndex = 0;
            this.rtbResultTable.Text = "";
            // 
            // ui_gb_inspect
            // 
            this.ui_gb_inspect.Controls.Add(this.btnInspect);
            this.ui_gb_inspect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_gb_inspect.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ui_gb_inspect.Location = new System.Drawing.Point(739, 3);
            this.ui_gb_inspect.Name = "ui_gb_inspect";
            this.ui_gb_inspect.Size = new System.Drawing.Size(178, 86);
            this.ui_gb_inspect.TabIndex = 269;
            this.ui_gb_inspect.TabStop = false;
            this.ui_gb_inspect.Text = "Inspection";
            // 
            // btnInspect
            // 
            this.btnInspect.AutoSize = true;
            this.btnInspect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInspect.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInspect.Location = new System.Drawing.Point(3, 21);
            this.btnInspect.Name = "btnInspect";
            this.btnInspect.Padding = new System.Windows.Forms.Padding(5);
            this.btnInspect.Size = new System.Drawing.Size(172, 62);
            this.btnInspect.TabIndex = 261;
            this.btnInspect.Text = "Run";
            this.btnInspect.UseVisualStyleBackColor = true;
            this.btnInspect.Click += new System.EventHandler(this.btnInspect_Click);
            // 
            // tblpDiplayRcp
            // 
            this.tblpDiplayRcp.ColumnCount = 1;
            this.tblpDiplayRcp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblpDiplayRcp.Controls.Add(this.tblpRecipeBlock, 0, 0);
            this.tblpDiplayRcp.Controls.Add(this.ui_gb_display, 0, 1);
            this.tblpDiplayRcp.Cursor = System.Windows.Forms.Cursors.Default;
            this.tblpDiplayRcp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpDiplayRcp.Location = new System.Drawing.Point(3, 3);
            this.tblpDiplayRcp.Name = "tblpDiplayRcp";
            this.tblpDiplayRcp.RowCount = 2;
            this.tblpDiplayRcp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblpDiplayRcp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblpDiplayRcp.Size = new System.Drawing.Size(926, 641);
            this.tblpDiplayRcp.TabIndex = 270;
            // 
            // tblpRecipeBlock
            // 
            this.tblpRecipeBlock.ColumnCount = 2;
            this.tblpRecipeBlock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tblpRecipeBlock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblpRecipeBlock.Controls.Add(this.ui_gb_recipe, 0, 0);
            this.tblpRecipeBlock.Controls.Add(this.ui_gb_inspect, 1, 0);
            this.tblpRecipeBlock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpRecipeBlock.Location = new System.Drawing.Point(3, 3);
            this.tblpRecipeBlock.Name = "tblpRecipeBlock";
            this.tblpRecipeBlock.RowCount = 1;
            this.tblpRecipeBlock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblpRecipeBlock.Size = new System.Drawing.Size(920, 92);
            this.tblpRecipeBlock.TabIndex = 271;
            // 
            // tblpMain
            // 
            this.tblpMain.ColumnCount = 2;
            this.tblpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblpMain.Controls.Add(this.tblpDiplayRcp, 0, 0);
            this.tblpMain.Controls.Add(this.ui_pn_right, 1, 0);
            this.tblpMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.tblpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpMain.Location = new System.Drawing.Point(3, 3);
            this.tblpMain.Name = "tblpMain";
            this.tblpMain.RowCount = 1;
            this.tblpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblpMain.Size = new System.Drawing.Size(1332, 647);
            this.tblpMain.TabIndex = 271;
            // 
            // tbcInterfaceType
            // 
            this.tbcInterfaceType.Controls.Add(this.inpection);
            this.tbcInterfaceType.Controls.Add(this.plc);
            this.tbcInterfaceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcInterfaceType.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbcInterfaceType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbcInterfaceType.Location = new System.Drawing.Point(0, 0);
            this.tbcInterfaceType.Name = "tbcInterfaceType";
            this.tbcInterfaceType.SelectedIndex = 0;
            this.tbcInterfaceType.Size = new System.Drawing.Size(1346, 686);
            this.tbcInterfaceType.TabIndex = 272;
            this.tbcInterfaceType.SelectedIndexChanged += new System.EventHandler(this.tbcInterfaceType_SelectedIndexChanged);
            // 
            // inpection
            // 
            this.inpection.Controls.Add(this.tblpMain);
            this.inpection.Location = new System.Drawing.Point(4, 29);
            this.inpection.Name = "inpection";
            this.inpection.Padding = new System.Windows.Forms.Padding(3);
            this.inpection.Size = new System.Drawing.Size(1338, 653);
            this.inpection.TabIndex = 0;
            this.inpection.Text = "Inpection";
            this.inpection.UseVisualStyleBackColor = true;
            // 
            // plc
            // 
            this.plc.Location = new System.Drawing.Point(4, 29);
            this.plc.Name = "plc";
            this.plc.Padding = new System.Windows.Forms.Padding(3);
            this.plc.Size = new System.Drawing.Size(1338, 653);
            this.plc.TabIndex = 1;
            this.plc.Text = "PLC";
            this.plc.UseVisualStyleBackColor = true;
            // 
            // btnLoadPMAlignTool
            // 
            this.btnLoadPMAlignTool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadPMAlignTool.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoadPMAlignTool.Location = new System.Drawing.Point(550, 3);
            this.btnLoadPMAlignTool.Name = "btnLoadPMAlignTool";
            this.btnLoadPMAlignTool.Size = new System.Drawing.Size(74, 35);
            this.btnLoadPMAlignTool.TabIndex = 255;
            this.btnLoadPMAlignTool.Text = "Align";
            this.btnLoadPMAlignTool.UseVisualStyleBackColor = true;
            this.btnLoadPMAlignTool.Visible = false;
            this.btnLoadPMAlignTool.Click += new System.EventHandler(this.btnLoadPMAlignTool_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveImage.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSaveImage.Location = new System.Drawing.Point(473, 3);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Padding = new System.Windows.Forms.Padding(3);
            this.btnSaveImage.Size = new System.Drawing.Size(71, 35);
            this.btnSaveImage.TabIndex = 242;
            this.btnSaveImage.Text = "Regist";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Visible = false;
            // 
            // FormInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 686);
            this.Controls.Add(this.tbcInterfaceType);
            this.Name = "FormInterface";
            this.Text = "FormInterface";
            this.Load += new System.EventHandler(this.FormInterface_Load);
            this.ui_gb_display.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).EndInit();
            this.fpn_image.ResumeLayout(false);
            this.fpn_image.PerformLayout();
            this.ui_gb_recipe.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ui_pn_right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvROISetList)).EndInit();
            this.ui_pn_roiApply.ResumeLayout(false);
            this.ui_pn_roiApply.PerformLayout();
            this.ui_fpn_gridAddDel.ResumeLayout(false);
            this.ui_fpn_gridAddDel.PerformLayout();
            this.fpnStep.ResumeLayout(false);
            this.fpnStep.PerformLayout();
            this.ui_gb_inspect.ResumeLayout(false);
            this.ui_gb_inspect.PerformLayout();
            this.tblpDiplayRcp.ResumeLayout(false);
            this.tblpRecipeBlock.ResumeLayout(false);
            this.tblpMain.ResumeLayout(false);
            this.tbcInterfaceType.ResumeLayout(false);
            this.inpection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox ui_gb_display;
        public Cognex.VisionPro.Display.CogDisplay cogDisplay;
        private System.Windows.Forms.FlowLayoutPanel fpn_image;
        private System.Windows.Forms.Button btnImageLoad;
        private System.Windows.Forms.Label lbImage;
        private System.Windows.Forms.Label lbAlignStaus;
        private System.Windows.Forms.GroupBox ui_gb_recipe;
        private System.Windows.Forms.Button btnLoadRcp;
        public System.Windows.Forms.Label lblSelectedRcp;
        private System.Windows.Forms.GroupBox ui_pn_right;
        public System.Windows.Forms.DataGridView dgvROISetList;
        private System.Windows.Forms.FlowLayoutPanel fpnStep;
        private System.Windows.Forms.RichTextBox rtbResultTable;
        private System.Windows.Forms.GroupBox ui_gb_inspect;
        private System.Windows.Forms.Button btnInspect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCamList;
        private System.Windows.Forms.FlowLayoutPanel ui_pn_roiApply;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnSetRoiSize;
        private System.Windows.Forms.TextBox txtSetRoiSize;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.FlowLayoutPanel ui_fpn_gridAddDel;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnGridDel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Cognex.VisionPro.CogDisplayToolbarV2 cogDisplayToolbar;
        private System.Windows.Forms.TableLayoutPanel tblpDiplayRcp;
        private System.Windows.Forms.TableLayoutPanel tblpRecipeBlock;
        private System.Windows.Forms.TableLayoutPanel tblpMain;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBarV21;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGridModify;
        private System.Windows.Forms.TabControl tbcInterfaceType;
        private System.Windows.Forms.TabPage inpection;
        private System.Windows.Forms.TabPage plc;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnLoadPMAlignTool;
    }
}